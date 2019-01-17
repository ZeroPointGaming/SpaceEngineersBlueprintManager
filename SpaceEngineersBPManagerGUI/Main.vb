Imports System.Xml
Imports System.Xml.Linq
Imports System.IO
Imports System.IO.Compression
Imports System.IO.Compression.ZipFile
Imports System.Environment
Imports System.String


Public Class Main
#Region "------------=================== REFINERY CALCULATIONS ===================------------"
    'URANIUM CALCULATIONS
    Dim UraniumAmmount As Integer 'Ammount of uranium needed ORE
    Dim UraniumIngotInput As Integer 'Ammount of uranium ingots output
    Dim UraniumConversion As Double = 0.0056 'Uranium ore to ingot conversion rate per kilogram of ore
    Dim UIngotCraftTimeBase As Double = 3.077 'Uranoum craft time per kilogram of ore
    Dim CostOfUraniumOre = UraniumAmmount * UraniumConversion
    Dim UraniumCraftTime = UraniumAmmount * UIngotCraftTimeBase

    'IRON CALCULATIONS
    Dim IronAmmount As Integer
    Dim IronIngotOutput As Integer
    Dim IronConversion As Double = 0.56
    Dim IIngotConversionTimeBase As Double = 0.038
    Dim CostOfIronOre = IronAmmount * IronConversion
    Dim IronCraftTime = IronAmmount * IIngotConversionTimeBase

    'NICKEL CALCULATIONS
    Dim NickelAmmount As Integer
    Dim NickelIngotOutput As Integer
    Dim NickelConversion As Double = 0.32
    Dim NIngotConversionTimeBase As Double = 1.538
    Dim CostOfNickel = NickelAmmount * NickelConversion
    Dim NickelCraftTime = NickelAmmount * NIngotConversionTimeBase

    'COBALT CALCULATIONS
    Dim CobaltAmmout As Integer
    Dim CobaltIngotOutput As Integer
    Dim CobaltConversion As Double = 0.24
    Dim CIngotConversionTimeBase As Double = 3.077
    Dim CostOfCobalt = CobaltAmmout * CobaltConversion
    Dim CobaltCraftTime = CobaltAmmout * CobaltCraftTime

    'MAGNESIUM CALCULATIONS
    Dim MagnesiumAmmount As Integer
    Dim MagnesiumIngotOutput As Integer
    Dim MagnesiumConversion As Double = 0.0056
    Dim MIngotConversionTimeBase As Double = 0.385
    Dim MagnesiumCostOfCobalt = MagnesiumAmmount * MagnesiumConversion
    Dim MagnesiumCraftTime = MagnesiumAmmount * MIngotConversionTimeBase

    'SILICON CALCULATIONS
    Dim SiliconAmmount As Integer
    Dim SiliconIngotOutput As Integer
    Dim SiliconConversion As Double = 0.56
    Dim SIngotConversionTimeBase As Double = 0.462
    Dim CostOfSilicon = SiliconAmmount * SiliconConversion
    Dim SiliconCraftTime = SiliconAmmount & SIngotConversionTimeBase

    'SILVER CALCULATIONS
    Dim SilverAmmount As Integer
    Dim SilverIngotOutput As Integer
    Dim SilverConversion As Double = 0.08
    Dim SilverIngotConversionTimeBase As Double = 0.769
    Dim CostOfSilver = SilverAmmount * SilverConversion
    Dim SilverCraftTime = SilverAmmount * SilverCraftTime

    'GOLD CALCULATIONS
    Dim GoldAmmount As Integer
    Dim GoldIngotOutput As Integer
    Dim GoldConversion As Double = 0.008
    Dim GIngotConversionTimeBase As Double = 0.308
    Dim CostOfGold = GoldAmmount * GoldConversion
    Dim GoldCraftTime = GoldAmmount * GoldCraftTime

    'PLATINUM CALCULATIONS
    Dim PlatinumAmmount As Integer
    Dim PlatinumIngotOutput As Integer
    Dim PlatinumConversion As Double = 0.004
    Dim PIngotConversionTimeBase As Double = 3.077
    Dim CostOfPlatinum = PlatinumAmmount * PlatinumConversion
    Dim PlatinumCrafTime = PlatinumAmmount & PlatinumCrafTime

    'STONE CALCULATIONS
    Dim StoneAmmount As Integer
    Dim StoneIngotOutput As Integer
    Dim StoneConversion As Double = 0.72
    Dim StoneBrickConversionTimeBase As Double = 0.077
    Dim CostOfStone = StoneAmmount * StoneConversion
    Dim StoneCraftTime = StoneAmmount * StoneCraftTime
#End Region

#Region "------------=================== Public Class Declerations ===================------------"
    Public FILENAME As String = String.Empty 'Set the filename variable to an empty string
    Public models As Model 'Set the access of the model class through models
    Public productionBlocks As New Panel
    Public gridsinfo As CubeGrid 'Set access to cubegrid class through gridsinfo
    Public TotalBlockCount As Integer = 0
    Public fileloader As New OpenFileDialog 'Set the open dialog as an accessible variable
    Public Shared WorkingPath As String = Nothing
    Public _model As Model 'Grant access to the model class through _model
    Public subPanels As New List(Of CubeBlock) 'Set a new variable subpanels as a list of cube blocks through the cubeblock class
#End Region

#Region "------------=================== Initilize List Definitions ===================------------"
    Public ListOfModBlocks As List(Of String) = Nothing
    Public ModdedCubeblockDefinitions As List(Of String) = Nothing
    Public ListOfVanillaBlocks() As String = {"LargeSteelCatwalkCorner", "SmallSuspension1x1mirrored", "SmallSuspension3x3mirrored", "SmallSuspension5x5mirrored", "SmParachute", "HalfArmorBlock", "HalfSlopeArmorBlock", "HeavyHalfArmorBlock", "HeavyHalfSlopeArmorBlock", "LargeHalfSlopeArmorBlock", "LargeHeavyHalfSlopeArmorBlock", "LargeHeavyHalfArmorBlock", "Window1x2SideRightInv", "MyObjectBuilder_Door", "MyObjectBuilder_AirVent", "MyObjectBuilder_GravityGenerator", "MyObjectBuilder_AirtightHangarDoor", "MyObjectBuilder_Passage", "MyObjectBuilder_GravityGeneratorSphere", "LargeHalfArmorBlock", "SmallHalfArmorBlock", "LargeBlockBatteryBlock", "SmallBlockBatteryBlock", "LargeBlockArmorBlock", "LargeBlockArmorSlope", "LargeBlockArmorCorner", "LargeBlockArmorCornerInv", "LargeRoundArmor_Slope", "LargeRoundArmor_Corner", "LargeRoundArmor_CornerInv", "LargeHeavyBlockArmorBlock", "LargeHeavyBlockArmorSlope", "LargeHeavyBlockArmorCorner", "LargeHeavyBlockArmorCornerInv", "SmallBlockArmorBlock", "SmallBlockArmorSlope", "SmallBlockArmorCorner", "SmallBlockArmorCornerInv", "SmallHeavyBlockArmorBlock", "SmallHeavyBlockArmorSlope", "SmallHeavyBlockArmorCorner", "SmallHeavyBlockArmorCornerInv", "LargeBlockArmorRoundedSlope", "LargeBlockArmorRoundedCorner", "LargeBlockArmorAngledSlope", "LargeBlockArmorAngledCorner", "LargeHeavyBlockArmorRoundedSlope", "LargeHeavyBlockArmorRoundedCorner", "LargeHeavyBlockArmorAngledSlope", "LargeHeavyBlockArmorAngledCorner", "SmallBlockArmorRoundedSlope", "SmallBlockArmorRoundedCorner", "SmallBlockArmorAngledSlope", "SmallBlockArmorAngledCorner", "SmallHeavyBlockArmorRoundedSlope", "SmallHeavyBlockArmorRoundedCorner", "SmallHeavyBlockArmorAngledSlope", "SmallHeavyBlockArmorAngledCorner", "LargeBlockArmorRoundSlope", "LargeBlockArmorRoundCorner", "LargeBlockArmorRoundCornerInv", "LargeHeavyBlockArmorRoundSlope", "LargeHeavyBlockArmorRoundCorner", "LargeHeavyBlockArmorRoundCornerInv", "SmallBlockArmorRoundSlope", "SmallBlockArmorRoundCorner", "SmallBlockArmorRoundCornerInv", "SmallHeavyBlockArmorRoundSlope", "SmallHeavyBlockArmorRoundCorner", "SmallHeavyBlockArmorRoundCornerInv", "LargeBlockArmorSlope2BaseSmooth", "LargeBlockArmorSlope2TipSmooth", "LargeBlockArmorCorner2BaseSmooth", "LargeBlockArmorCorner2TipSmooth", "LargeBlockArmorInvCorner2BaseSmooth", "LargeBlockArmorInvCorner2TipSmooth", "LargeHeavyBlockArmorSlope2BaseSmooth", "LargeHeavyBlockArmorSlope2TipSmooth", "LargeHeavyBlockArmorCorner2BaseSmooth", "LargeHeavyBlockArmorCorner2TipSmooth", "LargeHeavyBlockArmorInvCorner2BaseSmooth", "LargeHeavyBlockArmorInvCorner2TipSmooth", "SmallBlockArmorSlope2BaseSmooth", "SmallBlockArmorSlope2TipSmooth", "SmallBlockArmorCorner2BaseSmooth", "SmallBlockArmorCorner2TipSmooth", "SmallBlockArmorInvCorner2BaseSmooth", "SmallBlockArmorInvCorner2TipSmooth", "SmallHeavyBlockArmorSlope2BaseSmooth", "SmallHeavyBlockArmorSlope2TipSmooth", "SmallHeavyBlockArmorCorner2BaseSmooth", "SmallHeavyBlockArmorCorner2TipSmooth", "SmallHeavyBlockArmorInvCorner2BaseSmooth", "SmallHeavyBlockArmorInvCorner2TipSmooth", "LargeBlockArmorSlope2Base", "LargeBlockArmorSlope2Tip", "LargeBlockArmorCorner2Base", "LargeBlockArmorCorner2Tip", "LargeBlockArmorInvCorner2Base", "LargeBlockArmorInvCorner2Tip", "LargeHeavyBlockArmorSlope2Base", "LargeHeavyBlockArmorSlope2Tip", "LargeHeavyBlockArmorCorner2Base", "LargeHeavyBlockArmorCorner2Tip", "LargeHeavyBlockArmorInvCorner2Base", "LargeHeavyBlockArmorInvCorner2Tip", "SmallBlockArmorSlope2Base", "SmallBlockArmorSlope2Tip", "SmallBlockArmorCorner2Base", "SmallBlockArmorCorner2Tip", "SmallBlockArmorInvCorner2Base", "SmallBlockArmorInvCorner2Tip", "SmallHeavyBlockArmorSlope2Base", "SmallHeavyBlockArmorSlope2Tip", "SmallHeavyBlockArmorCorner2Base", "SmallHeavyBlockArmorCorner2Tip", "SmallHeavyBlockArmorInvCorner2Base", "SmallHeavyBlockArmorInvCorner2Tip", "ControlPanel", "SmallProgrammableBlock", "SmallControlPanel", "LargeGatlingTurret", "SmallGatlingTurret", "LargeMissileTurret", "SmallMissileTurret", "LargeInteriorTurret", "Passage", "Door", "LargeBlockRadioAntenna", "LargeBlockBeacon", "SmallBlockBeacon", "LargeBlockFrontLight", "SmallLight", "SmallBlockSmallLight", "LargeBlockLight_1corner", "LargeBlockLight_2corner", "SmallBlockLight_1corner", "SmallBlockLight_2corner", "LargeWindowSquare", "LargeWindowEdge", "LargeStairs", "LargeRamp", "LargeSteelCatwalk", "LargeSteelCatwalk2Sides", "LargeSteelCatwalkPlate", "LargeCoverWall", "LargeCoverWallHalf", "LargeWarhead", "SmallWarhead", "LargeDecoy", "SmallDecoy", "LargeBlockInteriorWall", "LargeInteriorPillar", "LargeBlockLandingGear", "LargeProjector", "SmallProjector", "LargeRefinery", "Blast Furnace", "BlastFurnace", "OxygenGenerator", "LargeAssembler", "LargeOreDetector", "LargeMedicalRoom", "GravityGenerator", "GravityGeneratorSphere", "LargeJumpDrive", "LargeBlockCockpit", "LargeBlockCockpitSeat", "SmallBlockCockpit", "DBSmallBlockFighterCockpit", "CockpitOpen", "PassengerSeatLarge", "PassengerSeatSmall", "LargeBlockCryoChamber", "SmallBlockLandingGear", "SmallBlockFrontLight", "SmallMissileLauncher", "LargeMissileLauncher", "MediumMissileLauncher", "SmallRocketLauncherReload", "SmallGatlingGun", "SmallBlockDrill", "LargeBlockDrill", "SmallBlockOreDetector", "SmallBlockSensor", "LargeBlockSensor", "SmallBlockSoundBlock", "LargeBlockSoundBlock", "SmallTextPanel", "SmallLCDPanelWide", "SmallLCDPanel", "LargeBlockCorner_LCD_1", "LargeBlockCorner_LCD_2", "LargeBlockCorner_LCD_Flat_1", "LargeBlockCorner_LCD_Flat_2", "SmallBlockCorner_LCD_1", "SmallBlockCorner_LCD_2", "SmallBlockCorner_LCD_Flat_1", "SmallBlockCorner_LCD_Flat_2", "OxygenTankSmall", "OxygenGeneratorSmall", "LargeTextPanel", "LargeLCDPanel", "LargeLCDPanelWide", "SmallBlockRadioAntenna", "LargeBlockRemoteControl", "SmallBlockRemoteControl", "AirVent", "SmallAirVent", "OxygenTank", "LargeHydrogenTank", "SmallHydrogenTank", "LargeProductivityModule", "LargeEffectivenessModule", "LargeEnergyModule", "SmallBlockSmallContainer", "SmallBlockMediumContainer", "SmallBlockLargeContainer", "LargeBlockSmallContainer", "LargeBlockLargeContainer", "SmallBlockSmallThrust", "SmallBlockLargeThrust", "LargeBlockSmallThrust", "LargeBlockLargeThrust", "LargeBlockLargeHydrogenThrust", "LargeBlockSmallHydrogenThrust", "SmallBlockLargeHydrogenThrust", "SmallBlockSmallHydrogenThrust", "LargeBlockLargeAtmosphericThrust", "LargeBlockSmallAtmosphericThrust", "SmallBlockLargeAtmosphericThrust", "SmallBlockSmallAtmosphericThrust", "SmallCameraBlock", "LargeCameraBlock", "LargeBlockGyro", "SmallBlockGyro", "SmallBlockSmallGenerator", "SmallBlockLargeGenerator", "LargeBlockSmallGenerator", "LargeBlockLargeGenerator", "LargePistonBase", "LargePistonTop", "SmallPistonBase", "SmallPistonTop", "LargeStator", "Suspension3x3", "Suspension5x5", "Suspension1x1", "SmallSuspension3x3", "SmallSuspension5x5", "SmallSuspension1x1", "LargeRotor", "SmallStator", "SmallRotor", "LargeAdvancedStator", "LargeAdvancedRotor", "SmallAdvancedStator", "SmallAdvancedRotor", "ButtonPanelLarge", "ButtonPanelSmall", "TimerBlockLarge", "TimerBlockSmall", "LargeRailStraight", "LargeBlockSolarPanel", "SmallBlockSolarPanel", "LargeBlockOxygenFarm", "Oxygen", "Window1x2Slope", "Window1x2Inv", "Window1x2Face", "Window1x2SideLeft", "Window1x2SideRight", "Window1x1Slope", "Window1x1Face", "Window1x1Side", "Window1x1Inv", "Window1x2Flat", "Window1x2FlatInv", "Window1x1Flat", "Window1x1FlatInv", "Window3x3Flat", "Window3x3FlatInv", "Window2x3Flat", "Window2x3FlatInv", "SmallBlockConveyor", "LargeBlockConveyor", "Collector", "CollectorSmall", "Connector", "ConnectorSmall", "ConnectorMedium", "ConveyorTube", "ConveyorTubeSmall", "ConveyorTubeMedium", "ConveyorFrameMedium", "ConveyorTubeCurved", "ConveyorTubeSmallCurved", "ConveyorTubeCurvedMedium", "SmallShipConveyorHub", "LargeBlockConveyorSorter", "MediumBlockConveyorSorter", "SmallBlockConveyorSorter", "VirtualMassLarge", "VirtualMassSmall", "SpaceBallLarge", "SpaceBallSmall", "SmallRealWheel1x1", "SmallRealWheel", "SmallRealWheel5x5", "RealWheel1x1", "RealWheel", "RealWheel5x5", "Wheel1x1", "SmallWheel1x1", "Wheel3x3", "SmallWheel3x3", "Wheel5x5", "SmallWheel5x5", "LargeShipGrinder", "SmallShipGrinder", "LargeShipWelder", "SmallShipWelder", "LargeShipMergeBlock", "SmallShipMergeBlock", "ArmorAlpha", "ArmorCenter", "LargeProgrammableBlock", "ArmorCorner", "ArmorInvCorner", "ArmorSide", "SmallArmorCenter", "SmallArmorCorner", "SmallArmorInvCorner", "SmallArmorSide", "LargeBlockLaserAntenna", "SmallBlockLaserAntenna", "AirtightHangarDoor", "LargeBlockSlideDoor", "DebugSphereLarge"}
#End Region

#Region "------------=================== Initilize Procedural Control Generation Definitions ===================------------"
    Dim NUMBER_OF_PANELS = 0
    Const MAIN_PANEL_WIDTH As Integer = 1000
    Const MAIN_PANEL_HEIGHT As Integer = 1000
    Const MAIN_PANEL_TOP As Integer = 50
    Const MAIN_PANEL_LEFT As Integer = 50
    Const PANEL_COLUMNS As Integer = 5
    Const PANEL_WIDTH_MARGIN As Integer = 10
    Const PANEL_HEIGHT_MARGIN As Integer = 10
    Const PANEL_WIDTH As Integer = (MAIN_PANEL_WIDTH / PANEL_COLUMNS) - PANEL_WIDTH_MARGIN
    Dim PANEL_ROWS As Integer = 0
    Dim PANEL_HEIGHT As Integer = 0
    Dim PICTURE_BOX_MARGIN As Integer = 0
    Dim PICTURE_BOX_WIDTH As Integer = PANEL_WIDTH
    Dim PICTURE_BOX_HEIGHT As Integer = 0
    Const PICTURE_BOX_TOP As Integer = 0
    Const PICTURE_BOX_LEFT As Integer = 0
    Dim LABEL_WIDTH As Integer = PANEL_WIDTH
    Dim LABEL_HEIGHT As Integer = 0
    Dim LABEL_TOP As Integer = 0
    Dim LABEL_LEFT As Int16 = 0
#End Region

#Region "------------=================== Initialize Component Constants ===================------------"
    Public SteelPlateCount As Integer = 0
    Public InteriorPlateCount As Integer = 0
    Public Computer As Integer = 0
    Public Superconducter As Integer = 0
    Public Canvas As Integer = 0
    Public Girder As Integer = 0
    Public BulletproofGlass As Integer = 0
    Public ConstructionComponent As Integer = 0
    Public DetectorComponent As Integer = 0
    Public Displays As Integer = 0
    Public Explosives As Integer = 0
    Public GravityGeneratorComponents As Integer = 0
    Public LargeSteelTube As Integer = 0
    Public SmallSteelTube As Integer = 0
    Public MedicalComponents As Integer = 0
    Public MetalGrid As Integer = 0
    Public TwoHundredMMMissileContainer As Integer = 0
    Public Motor As Integer = 0
    Public NATOAmmoContainer As Integer = 0
    Public NATOAmmoMagazine As Integer = 0
    Public PowerCell As Integer = 0
    Public RadioCommunicationComponents As Integer = 0
    Public ReactorComponents As Integer = 0
    Public SolarCell As Integer = 0
    Public ThrusterComponents As Integer = 0
#End Region


#Region "------------=================== Main Functions ===================------------"
#Region "------------=================== Function to recalculate control sizes for the flow layout panel ===================------------"
    Sub CalulateControlSizes(numberOfPanels As Integer)
        PANEL_ROWS = Math.Ceiling(NUMBER_OF_PANELS / PANEL_COLUMNS)
        'PANEL_HEIGHT = (MAIN_PANEL_HEIGHT / PANEL_ROWS) - PANEL_HEIGHT_MARGIN
        PANEL_HEIGHT = 200
        PICTURE_BOX_MARGIN = 0.1 * PANEL_HEIGHT
        PICTURE_BOX_HEIGHT = 0.8 * PANEL_HEIGHT
        LABEL_HEIGHT = 0.1 * PANEL_HEIGHT
        LABEL_TOP = PICTURE_BOX_HEIGHT + PANEL_HEIGHT_MARGIN
    End Sub
#End Region

#Region "------------=================== Function to search strings ===================------------"
    Private Function FindWords(ByVal TextSearched As String, ByVal Paragraph As String) As Integer
        Dim location As Integer = 0
        Dim occurances As Integer = 0
        Do
            location = TextSearched.IndexOf(Paragraph, location)
            If location <> -1 Then
                occurances += 1
                location += Paragraph.Length
            End If
        Loop Until location = -1
        Return occurances
    End Function
#End Region

#Region "------------=================== Function To Unzip Mod Files to the Temp Folder ===================------------"
    Dim appData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Dim sepath As String = appData + "\SpaceEngineers\Mods"
    Dim bppath As String = appData + "\SpaceEngineers\Blueprints\Local"
    Dim extractto As String = "C:\SETools\unpacked_mods"
    Function unpackAll(pat As String, Optional destPath As String = "") As Integer 'Unpack all the space engineers mods from %AppData%\Roaming\SpaceEngineers\Mods and to a folder in the root directory of the C drive
        unpackAll = 0
        If Not Directory.Exists(pat) Then Return Nothing
        If Not Directory.Exists(destPath) Then 'Test if the folder exists and if not then create the folder and cd into it
            Try
                destPath = extractto + "\" + unpackAll.ToString
                Directory.CreateDirectory(destPath)
            Catch ex As Exception
            End Try
        End If
        If Not Directory.Exists(destPath) Then Return Nothing
        For Each zfn In Directory.GetFiles(pat, "*.sbm") 'For each zipfilename in the given directory extract them to the given folder
            Try
                destPath = extractto + "\" + unpackAll.ToString
                ZipFile.ExtractToDirectory(zfn, destPath)
                unpackAll += 1
            Catch ex As Exception
            End Try
        Next
    End Function
#End Region

#Region "------------=================== Functions to Calculate Component Counts ===================------------"
    'Function to calculate the full value of all the materials needed to build the blueprint  <<|>> Working <<|>>
    Function CalculateResourcesValueSteelPlates(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesSteelPlates().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueInteriorPlates(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesInteriorPlates().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueMetalGrids(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesMetalGrids().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValuesSmallSteelTubes(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesSmallSteelTubes().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueLargeSteelTubes(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesLargeSteelTubes().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueComputers(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesComputers().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueConstructionComponents(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesConstructionComponents().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueDetectorComponents(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesDetectorComponents().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueGravityComponents(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesGravityComponents().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueMedicalComponents(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesMedicalComponents().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueRadioComponents(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesRadioComponents().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueReactorComponents(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesReactorComponents().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueThrusterComponents(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesThrusterComponents().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueCanvas(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesCanvas().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueDisplays(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesDisplays().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueGirders(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesGirders().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueMotors(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesMotors().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValuePowerCells(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesPowerCells().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueSolarCells(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesSolarCells().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueSuperConducters(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesSuperConducters().Value(inputblock) * inputcount
    End Function
    Function CalculateResourcesValueBulletproofGlass(inputblock As String, inputcount As Integer) 'WIP WIP WIP WIP WIP WIP
        Return New CalculateResourcesBulletproofGlass().Value(inputblock) * inputcount
    End Function
#End Region

#Region "------------=================== Function To Reset Controls Systems ===================------------"
    Public Sub ResetControlSystems()
        'Reset Working Path
        WorkingPath = Nothing

        'Reset the image prieview box
        Try
            PictureBox1.BackgroundImage.Dispose()
        Catch ex As Exception
            ex = Nothing
        End Try

        'Reset Total Block Count
        TotalBlockCount = 0

        'Reset Component Counts
        SteelPlateCount = 0
        InteriorPlateCount = 0
        Computer = 0
        Superconducter = 0
        Canvas = 0
        Girder = 0
        BulletproofGlass = 0
        ConstructionComponent = 0
        DetectorComponent = 0
        Displays = 0
        Explosives = 0
        GravityGeneratorComponents = 0
        LargeSteelTube = 0
        SmallSteelTube = 0
        MedicalComponents = 0
        MetalGrid = 0
        TwoHundredMMMissileContainer = 0
        Motor = 0
        NATOAmmoContainer = 0
        NATOAmmoMagazine = 0
        PowerCell = 0
        RadioCommunicationComponents = 0
        ReactorComponents = 0
        SolarCell = 0
        ThrusterComponents = 0

        'Reset Ingot Counts
        IronIngotOutput = 0 'Iron Ingots
        StoneIngotOutput = 0 'Gravel
        PlatinumIngotOutput = 0 'Platinum Ingots
        GoldIngotOutput = 0 'Gold Ingots
        SilverIngotOutput = 0 'Silver Ingots
        SiliconIngotOutput = 0 'Silicon Wafers
        MagnesiumIngotOutput = 0 'Magnesium Powder
        CobaltIngotOutput = 0 'Cobalt Ingots
        NickelIngotOutput = 0 'Nickel Ingots
        UraniumIngotInput = 0 'Uranium Ingots

        ListBox1.Items.Clear() 'Resetting the block types list box when new file is loaded
        ListBox2.Items.Clear() 'Resetting the components list box when new file is loaded
        ListBox3.Items.Clear() 'Resetting the materials list box when new file is loaded
        ListBox4.Items.Clear() 'Resetting the raw materials list box when new file is loaded

        'Remove the flowlayoutpanel controls from memory <<|Fixes A Memory Leak|>> 
        Dim listofcontrols As List(Of Control) = FlowLayoutPanel1.Controls.Cast(Of Control)().ToList()
        For Each control In listofcontrols
            Try
                control.Dispose()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(control)
            Catch ex As Exception
                control.Dispose()
                ex = Nothing
            Finally
                GC.Collect()
            End Try
        Next
        FlowLayoutPanel1.Controls.Clear() 'Reset the procedural controls collection

        Try
            For Each Block In ListOfModBlocks
                ListOfModBlocks.Remove(Block)
            Next Block
        Catch ex As Exception
            ex = Nothing
        End Try

        Try
            ListOfModBlocks.Clear() 'Reset list of modded blocks
        Catch ex As Exception
            ex = Nothing
        End Try

        GC.Collect() 'Finalize Cleanup with a garbage collector call
    End Sub
#End Region

#Region "------------=================== Function to search modded block definitions for the subtype name inputted, find which definition it is, and return some information back ===================------------"
    Public Function SearchModdedCubeDefinitions(subtypesearch As String) 'WIP WIP WIP WIP WIP WIP
        Dim BlockToSearch As String = subtypesearch

        Return Nothing
    End Function
#End Region

#Region "------------=================== Function to Load ALL modded block data into a list ===================------------"
    Public Sub LoadModDefinitions()
        Dim modpath As String = "C:\SETools\unpacked_mods\"

        For Each entry In Directory.GetFiles(modpath, "CubeBlocks.sbc") 'For each zipfilename in the given directory extract them to the given folder
            Dim filereader As StreamReader = New StreamReader(modpath)
            For Each block In entry
                ModdedCubeblockDefinitions.Add(filereader.ReadToEnd(modpath))
            Next block
        Next
    End Sub
#End Region
#End Region


#Region "------------=================== Primary Function to load the blueprint ===================------------"
    Public Sub OpenFileFunction()
        'Call the reset function
        ResetControlSystems()

        'pre-load initialization
        fileloader.ShowDialog() 'Display the open dialog to select what file to load
        FILENAME = fileloader.FileName 'Setting the filename variable to the user selected file from the open dialog

        'Catch error if user cancles the loading dialog
        Try
            WorkingPath = Path.GetDirectoryName(fileloader.FileName)
            models = New Model 'Create a reference to the Model class
            models.Load(FILENAME) 'Initiate the loading sequence to get the information from the XML file
        Catch ex As Exception

        End Try

        'Grabbing information from XML file
        Dim blockNames As List(Of String) = models.print.cubes.cubeBlocks.Select(Function(x) x.SubtypeName).ToList() 'List of blocks in the blueprint
        Dim display As String = models.print.displayname 'Gets the owner of the blueprint
        Dim gridsizeenum As String = models.print.cubes.enumerator 'Gets the gridsize of the blueprint
        Dim ownername As String = models.print._id.subtype 'returns the name of the blueprint

        'Load the information about the blueprint (ownername, grid name, grid type) into the title of the form
        Dim OwnerVariable As String
        Dim DisplayVariable As String
        Try
            OwnerVariable = ownername.ToString
        Catch ex As Exception
            OwnerVariable = "Blueprint Name Not Found"
        End Try
        Try
            DisplayVariable = display.ToString()
        Catch ex As Exception
            DisplayVariable = "Username Not Found"
        End Try
        Me.Text = OwnerVariable.ToString + " | " + gridsizeenum.ToString + " Grid | " + DisplayVariable.ToString

        'Declare functions for reading the information
        Dim reader As New StreamReader(FILENAME) 'Set the second xml reader to the original file name
        Dim doc As XDocument = XDocument.Load(reader) 'Read the xml file to get custom data
        Dim xmlstring As String = doc.ToString 'Read the xml into a string

        'Procedural Control Generation
        _model = New Model()
        _model.Load(FILENAME)
        NUMBER_OF_PANELS = _model.print.cubes.cubeBlocks.Count
        CalulateControlSizes(NUMBER_OF_PANELS) 'Run the calculate control sizes function to properly size the control surfaces

        For panelNumber As Integer = 0 To (NUMBER_OF_PANELS - 1)
            Dim row As Integer = Math.Floor(panelNumber / PANEL_COLUMNS)
            Dim col As Integer = panelNumber Mod PANEL_COLUMNS
            Dim newPanel As CubeBlock = _model.print.cubes.cubeBlocks(panelNumber)

            newPanel.Top = row * (PANEL_HEIGHT + PANEL_HEIGHT_MARGIN)
            newPanel.Left = col * (PANEL_WIDTH + PANEL_WIDTH_MARGIN)
            newPanel.Width = PANEL_WIDTH
            newPanel.Height = PANEL_HEIGHT
            newPanel.BackColor = Color.FromArgb(24, 24, 24)
            newPanel.ForeColor = Color.White
            subPanels.Add(newPanel)

            'simplified query to save code
            Dim blockname As String = newPanel.SubtypeName
            Dim newPicture As New PictureBox()
            newPicture.Height = 80
            newPicture.Width = 80
            newPicture.Top = PICTURE_BOX_TOP
            newPicture.Left = PICTURE_BOX_LEFT
            newPicture.BackgroundImageLayout = ImageLayout.Stretch

            'Workaround for blocks with no subtype names
            Dim avar2 = newPanel.username
            If avar2 = "MyObjectBuilder_OxygenGenerator" And newPanel.SubtypeName = "" Then
                newPanel.SubtypeName = "OxygenGenerator"
                blockname = "OxygenGenerator"
            End If
            If avar2 = "MyObjectBuilder_OxygenTank" And newPanel.SubtypeName = "" Then
                newPanel.SubtypeName = "OxygenTank"
                blockname = "OxygenTank"
            End If
            If avar2 = "MyObjectBuilder_OxygenTank" And newPanel.SubtypeName = "LargeHydrogenTank" Then
                newPanel.SubtypeName = "LargeHydrogenTank"
                blockname = "LargeHydrogenTank"
            End If
            If newPanel.SubtypeName = "Blast Furnace" Then newPanel.SubtypeName = "BlastFurnace"
            If avar2 = "MyObjectBuilder_LargeGatlingTurret" And newPanel.SubtypeName = "" Then
                newPanel.SubtypeName = "LargeGatlingTurret"
                blockname = newPanel.SubtypeName
            End If
            If avar2 = "MyObjectBuilder_LargeMissileTurret" And newPanel.SubtypeName = "" Then
                newPanel.SubtypeName = "LargeMissileTurret"
                blockname = newPanel.SubtypeName
            End If
            If avar2 = "MyObjectBuilder_SmallGatlingGun" And newPanel.SubtypeName = "" Then
                newPanel.SubtypeName = "SmallGatlingGun"
                blockname = newPanel.SubtypeName
            End If
            If avar2 = "MyObjectBuilder_SmallMissileLauncher" And newPanel.SubtypeName = "" Then
                newPanel.SubtypeName = "SmallMissileLauncher"
                blockname = newPanel.SubtypeName
            End If
            If newPanel.SubtypeName = "" Then newPanel.SubtypeName = newPanel.username 'Workaround for blank subtype names

            'Tool Tip Handling
            Dim avar1 As String = newPanel.SubtypeName & " (" & newPanel.count & ")"
            ToolTip1.SetToolTip(newPicture, avar1.ToString)

            'Function to check the blocktype name and cross check if it is a vanilla block or not
            If ListOfVanillaBlocks.Contains(newPanel.SubtypeName) = True Then
                newPicture.BackgroundImage = DirectCast(My.Resources.ResourceManager.GetObject(newPanel.SubtypeName), Bitmap)
                If newPicture.BackgroundImage Is Nothing Then
                    newPicture.BackgroundImage = My.Resources.ModdedItem
                End If
            ElseIf ListOfVanillaBlocks.Contains(newPanel.SubtypeName) = False Then
                newPicture.BackgroundImage = My.Resources.unavailable 'Set modded blocks images as unavailable 
                'Run search for mod function
                'ListOfModBlocks.Add(newPanel.SubtypeName) 'Add the modded block to the list of modded blocks
            End If
            newPicture.BackColor = Color.FromArgb(24, 24, 24)

            'Append the image to the flow layout panel once generated
            FlowLayoutPanel1.Controls.Add(newPicture)

            'Give blocks with no subtype name a proper name to display on the label
            If newPanel.SubtypeName = "MyObjectBuilder_GravityGeneratorSphere" Then
                newPanel.SubtypeName = "GravityGeneratorSphere"
                ToolTip1.SetToolTip(newPicture, newPanel.SubtypeName + " (" + newPanel.count.ToString + ")")
            End If
            If newPanel.SubtypeName = "MyObjectBuilder_Passage" Then
                newPanel.SubtypeName = "Passage"
                ToolTip1.SetToolTip(newPicture, newPanel.SubtypeName + " (" + newPanel.count.ToString + ")")
            End If
            If newPanel.SubtypeName = "MyObjectBuilder_AirtightHangarDoor" Then
                newPanel.SubtypeName = "AirtightHangarDoor"
                ToolTip1.SetToolTip(newPicture, newPanel.SubtypeName + " (" + newPanel.count.ToString + ")")
            End If
            If newPanel.SubtypeName = "MyObjectBuilder_Door" Then
                newPanel.SubtypeName = "Door"
                ToolTip1.SetToolTip(newPicture, newPanel.SubtypeName + " (" + newPanel.count.ToString + ")")
            End If
            If newPanel.SubtypeName = "MyObjectBuilder_AirVent" Then
                newPanel.SubtypeName = "AirVent"
                ToolTip1.SetToolTip(newPicture, newPanel.SubtypeName + " (" + newPanel.count.ToString + ")")
            End If
            If newPanel.SubtypeName = "MyObjectBuilder_GravityGenerator" Then
                newPanel.SubtypeName = "GravityGenerator"
                ToolTip1.SetToolTip(newPicture, newPanel.SubtypeName + " (" + newPanel.count.ToString + ")")
            End If

            'Block count label generation
            Dim newLabel As New Label
            newLabel.Height = LABEL_HEIGHT
            newLabel.Width = LABEL_WIDTH
            'newLabel.Top = LABEL_TOP
            'newLabel.Left = LABEL_LEFT
            newLabel.BackColor = Color.Transparent
            newLabel.ForeColor = Color.Orange
            newLabel.Font = New Font("Segoe UI", 8, FontStyle.Regular)

            'Functions for naming all the blocks WIP
            '>If newPanel.SubtypeName = "ArmorCenter" Then newLabel.Text = "Blast Door Center"
            '>If newPanel.SubtypeName = "ArmorCorner" Then newLabel.Text = "Blast Door Corner"
            '>If newPanel.SubtypeName = "ArmorInvCorner" Then newLabel.Text = "ArmorInvCorner"
            '>If newPanel.SubtypeName = "ArmorSide" Then newLabel.Text = "Blast Door Side"
            '>If newPanel.SubtypeName = "BlastFurnace" Then newLabel.Text = "Blast Furnace"
            '>If newPanel.SubtypeName = "ButtonPanelLarge" Then newLabel.Text = "Large Button Panel"
            'If newPanel.SubtypeName = "" Then newLabel.Text = ""

            'If block is not vanilla then give it its default block name
            If Not ListOfVanillaBlocks.Contains(newPanel.SubtypeName) Then
                newLabel.Text = newPanel.SubtypeName & "(" & newPanel.count & ")"
            ElseIf newPanel.SubtypeName = "" Then
                newPanel.SubtypeName = newPanel.username
            End If

            'Temporary Block Naming Function
            newLabel.Text = newPanel.SubtypeName & "(" & newPanel.count & ")"

            'Append the label of the block name and its count to the image generated before
            newPicture.Controls.Add(newLabel)

            'Calculate the ammount of components needed per set of blocks
            SteelPlateCount += CalculateResourcesValueSteelPlates(newPanel.SubtypeName, newPanel.count) 'Steel Plates
            InteriorPlateCount += CalculateResourcesValueInteriorPlates(newPanel.SubtypeName, newPanel.count)
            Computer += CalculateResourcesValueComputers(newPanel.SubtypeName, newPanel.count)
            Superconducter += CalculateResourcesValueSuperConducters(newPanel.SubtypeName, newPanel.count)
            Canvas += CalculateResourcesValueCanvas(newPanel.SubtypeName, newPanel.count)
            Girder += CalculateResourcesValueGirders(newPanel.SubtypeName, newPanel.count)
            BulletproofGlass += CalculateResourcesValueBulletproofGlass(newPanel.SubtypeName, newPanel.count)
            ConstructionComponent += CalculateResourcesValueConstructionComponents(newPanel.SubtypeName, newPanel.count)
            DetectorComponent += CalculateResourcesValueDetectorComponents(newPanel.SubtypeName, newPanel.count)
            Displays += CalculateResourcesValueDisplays(newPanel.SubtypeName, newPanel.count)
            Explosives += 0
            GravityGeneratorComponents += CalculateResourcesValueGravityComponents(newPanel.SubtypeName, newPanel.count)
            LargeSteelTube += CalculateResourcesValueLargeSteelTubes(newPanel.SubtypeName, newPanel.count)
            SmallSteelTube += CalculateResourcesValuesSmallSteelTubes(newPanel.SubtypeName, newPanel.count)
            MedicalComponents += CalculateResourcesValueMedicalComponents(newPanel.SubtypeName, newPanel.count)
            MetalGrid += CalculateResourcesValueMetalGrids(newPanel.SubtypeName, newPanel.count)
            TwoHundredMMMissileContainer += 0
            Motor += CalculateResourcesValueMotors(newPanel.SubtypeName, newPanel.count)
            NATOAmmoContainer += 0
            NATOAmmoMagazine += 0
            PowerCell += CalculateResourcesValuePowerCells(newPanel.SubtypeName, newPanel.count)
            RadioCommunicationComponents += CalculateResourcesValueRadioComponents(newPanel.SubtypeName, newPanel.count)
            ReactorComponents += CalculateResourcesValueReactorComponents(newPanel.SubtypeName, newPanel.count)
            SolarCell += CalculateResourcesValueSolarCells(newPanel.SubtypeName, newPanel.count)
            ThrusterComponents += CalculateResourcesValueThrusterComponents(newPanel.SubtypeName, newPanel.count)

            'add count of current block to total block count
            TotalBlockCount += newPanel.count

            'Add items to the list box for information output
            ListBox1.Items.Add(newPanel.username.ToString & "|" & newPanel.SubtypeName & "|" & " (" & newPanel.count.ToString & ")")
        Next panelNumber
        'Add total block count to the form name
        Me.Text += " | Block Count: " + TotalBlockCount.ToString("N0")

        '------------=================== Function to Calculate Material Costs ===================------------
        'Iron Calculations
        IronIngotOutput = (SteelPlateCount * 7) + (ReactorComponents * 5) + (Canvas * 0.67) + (Computer * 0.17) + (ConstructionComponent * 3.33) + (DetectorComponent * 1.67) + (Displays * 0.33) + (Girder * 2.33) + (GravityGeneratorComponents * 200) + (InteriorPlateCount * 1.17) + (LargeSteelTube * 10) + (MedicalComponents * 20) + (MetalGrid * 4) + (Motor * 6.67) + (PowerCell * 3.33) + (RadioCommunicationComponents * 2.67) + (ReactorComponents * 5) + (SmallSteelTube * 1.67) + (Superconducter * 3.33) + (ThrusterComponents * 10) 'Calculate how many iron ingots to add based on Steel Plates
        IronAmmount = IronIngotOutput / 0.56
        IronCraftTime = Math.Round(((IronAmmount * 0.038) / 60) / 60) 'Hours
        Dim IronArcTime = Math.Round(((IronAmmount * 0.031) / 60) / 60) 'Hours

        'Silicon Calculations
        SiliconIngotOutput = (BulletproofGlass * 5) + (Canvas * 11.67) + (Computer * 0.07) + (Displays * 1.67) + (PowerCell * 0.33) + (RadioCommunicationComponents * 0.33) + (SolarCell * 2.67)
        SiliconAmmount = SiliconIngotOutput / 0.56
        SiliconCraftTime = Math.Round(((SiliconAmmount * 0.038) / 60) / 60) 'Hours

        'Stone Calculations
        StoneIngotOutput = (ReactorComponents * 6.67)
        StoneAmmount = StoneIngotOutput / 0.72
        StoneCraftTime = Math.Round(((StoneAmmount * 0.077) / 60) / 60) 'Hours

        'Platinum Calculations
        PlatinumIngotOutput = (ThrusterComponents * 0.13)
        PlatinumAmmount = PlatinumIngotOutput / 0.004
        PlatinumCrafTime = Math.Round(((PlatinumAmmount * 3.077) / 60) / 60) 'Hours

        'Gold Calculations
        GoldIngotOutput = (Superconducter * 0.67) + (GravityGeneratorComponents * 3.33) + (ThrusterComponents * 0.33)
        GoldAmmount = GoldIngotOutput / 0.008
        GoldCraftTime = Math.Round(((GoldAmmount * 0.308) / 60) / 60) 'Hours

        'Silver Calculations
        SilverIngotOutput = (GravityGeneratorComponents * 1.67) + (MedicalComponents * 6.67) + (ReactorComponents * 1.67)
        SilverAmmount = SilverIngotOutput / 0.08
        SilverCraftTime = Math.Round(((SilverAmmount * 0.769) / 60) / 60) 'Hours

        'Magnesium Calculations
        MagnesiumIngotOutput = (Explosives * 0.67) + (TwoHundredMMMissileContainer * 0.4) + (NATOAmmoContainer * 1) + (NATOAmmoMagazine * 0.05)
        MagnesiumAmmount = MagnesiumIngotOutput / 0.0056
        MagnesiumCraftTime = Math.Round(((MagnesiumAmmount * 0.385) / 60) / 60) 'Hours

        'Cobalt Calculations
        CobaltIngotOutput = (GravityGeneratorComponents * 73.33) + (MetalGrid * 1) + (ThrusterComponents * 3.33)
        CobaltAmmout = CobaltIngotOutput / 0.24
        CobaltCraftTime = Math.Round(((CobaltAmmout * 3.077) / 60) / 60) 'Hours

        'Nickel Calculations
        NickelIngotOutput = (DetectorComponent * 5) + (MedicalComponents * 23.33) + (MetalGrid * 1.67) + (Motor * 1.67) + (PowerCell * 0.67)
        NickelAmmount = NickelIngotOutput / 0.32
        NickelCraftTime = Math.Round(((CobaltAmmout * 1.538) / 60) / 60) 'Hours

        'Uranium Calculations
        UraniumIngotInput = (TwoHundredMMMissileContainer * 0.03)
        UraniumAmmount = UraniumIngotInput / 0.0056
        UraniumCraftTime = Math.Round(((CobaltAmmout * 3.077) / 60) / 60) 'Hours

        '------------=================== Function to load stuff into the list boxes ===================------------
        'Components List ListBox2                                                                  >>| FINISHED |<<
        ListBox2.Items.Add(SteelPlateCount.ToString("N0") & " Steel Plates") 'Steel Plates
        ListBox2.Items.Add(InteriorPlateCount.ToString("N0") & " Interior Plates") 'Interior Plates
        ListBox2.Items.Add(Computer.ToString("N0") & " Computers") 'Computers
        ListBox2.Items.Add(Superconducter.ToString("N0") & " Super Conductors") 'Super Conductors
        ListBox2.Items.Add(Canvas.ToString("N0") & " Canvas") 'Canvas
        ListBox2.Items.Add(Girder.ToString("N0") & " Girders") 'Girders
        ListBox2.Items.Add(BulletproofGlass.ToString("N0") & " Blluetproof Glass") 'Blluetproof Glass
        ListBox2.Items.Add(ConstructionComponent.ToString("N0") & " Construction Components") 'Construction Components
        ListBox2.Items.Add(DetectorComponent.ToString("N0") & " Detector Components") 'Detector Components
        ListBox2.Items.Add(Displays.ToString("N0") & " Displays") 'Displays
        ListBox2.Items.Add(GravityGeneratorComponents.ToString("N0") & " Gravity Generator Components") 'Gravity Generator Components
        ListBox2.Items.Add(LargeSteelTube.ToString("N0") & " Large Steel Tubes") 'Large Steel Tubes
        ListBox2.Items.Add(SmallSteelTube.ToString("N0") & " Small Steel Tubes") 'Small Steel Tubes
        ListBox2.Items.Add(MedicalComponents.ToString("N0") & " Medical Components") 'Medical Components
        ListBox2.Items.Add(MetalGrid.ToString("N0") & " Metal Grids") 'Metal Grids
        ListBox2.Items.Add(Motor.ToString("N0") & " Motors") 'Motors
        ListBox2.Items.Add(PowerCell.ToString("N0") & " Power Cells") 'Power Cells
        ListBox2.Items.Add(RadioCommunicationComponents.ToString("N0") & " Radio Communication Components") 'Radio Communication Components
        ListBox2.Items.Add(ReactorComponents.ToString("N0") & " Reactor Components") 'Reactor Components
        ListBox2.Items.Add(SolarCell.ToString("N0") & " Solar Cells") 'Solar Cells
        ListBox2.Items.Add(ThrusterComponents.ToString("N0") & " Thruster Components") 'Thruster Components

        'Materials List ListBox3                                                                     >>| FINISHED |<<
        ListBox3.Items.Add(IronIngotOutput.ToString("N0") & " Iron Ingots")
        ListBox3.Items.Add(SiliconIngotOutput.ToString("N0") & " Silicon Wafers")
        ListBox3.Items.Add(StoneAmmount.ToString("N0") & " Stones")
        ListBox3.Items.Add(PlatinumAmmount.ToString("N0") & " Platinum Ingots")
        ListBox3.Items.Add(GoldAmmount.ToString("N0") & " Gold Ingots")
        ListBox3.Items.Add(SilverAmmount.ToString("N0") & " Silver Ingots")
        ListBox3.Items.Add(MagnesiumAmmount.ToString("N0") & " Bags Of Magnesium Powder")
        ListBox3.Items.Add(CobaltAmmout.ToString("N0") & " Cobalt Ingots")
        ListBox3.Items.Add(NickelAmmount.ToString("N0") & " Nickel Ingots")
        ListBox3.Items.Add(UraniumAmmount.ToString("N0") & " Uranium Ingots")

        'Raw Materials List ListBox4                                                                 >>| FINISHED |<<
        If IronCraftTime <= 0 And IronArcTime <= 0 Then
            IronCraftTime = Math.Round(((IronAmmount * 0.038) / 60), 2) 'Minutes
            IronArcTime = Math.Round(((IronAmmount * 0.031) / 60), 2) 'Minutes
            ListBox4.Items.Add(IronAmmount.ToString("N0") & " KGs Iron ore | " & IronCraftTime.ToString() & " Minutes In Refinery OR " & IronArcTime.ToString("N0") & " Minutes In Arc Furnace")
        ElseIf IronCraftTime >= 1 Then
            IronCraftTime = Math.Round(((IronAmmount * 0.038) / 60) / 60, 2) 'Hours
            IronArcTime = Math.Round(((IronAmmount * 0.031) / 60) / 60, 2) 'Hours
            ListBox4.Items.Add(IronAmmount.ToString("N0") & " KGs Iron ore | " & IronCraftTime.ToString() & " Hours In Refinery OR " & IronArcTime.ToString("N0") & " Hours In Arc Furnace")
        End If
        If SiliconCraftTime < 1 Then
            SiliconCraftTime = Math.Round(((SiliconAmmount * 0.462) / 60), 2) 'Minutes
            ListBox4.Items.Add(SiliconAmmount.ToString("N0") & " KGs Silicon Ore | " & SiliconCraftTime.ToString() & " Mintes In Refinery")
        ElseIf SiliconCraftTime > 1 Then
            SiliconCraftTime = Math.Round(((SiliconAmmount * 0.462) / 60) / 60, 2) 'Hours
            ListBox4.Items.Add(SiliconAmmount.ToString("N0") & " KGs Silicon Ore | " & SiliconCraftTime.ToString() & " Hours In Refinery")
        End If
        If StoneCraftTime < 1 Then
            StoneCraftTime = Math.Round(((StoneAmmount * 0.077) / 60), 2) 'Minutes
            ListBox4.Items.Add(StoneAmmount.ToString("N0") & " KGs Stones | " & StoneCraftTime.ToString() & " Mintes In Refinery")
        ElseIf StoneCraftTime > 1 Then
            StoneCraftTime = Math.Round(((StoneAmmount * 0.077) / 60) / 60, 2) 'Hours
            ListBox4.Items.Add(StoneAmmount.ToString("N0") & " KGs Stones | " & StoneCraftTime.ToString() & " Hours In Refinery")
        End If
        If PlatinumCrafTime < 1 Then
            PlatinumCrafTime = Math.Round(((PlatinumAmmount * 3.077) / 60), 2) 'Minutes
            ListBox4.Items.Add(PlatinumAmmount.ToString("N0") & " KGs Platinum Ore | " & PlatinumCrafTime.ToString() & " Mintes In Refinery")
        ElseIf PlatinumCrafTime > 1 Then
            PlatinumCrafTime = Math.Round(((PlatinumAmmount * 3.077) / 60) / 60, 2) 'Hours
            ListBox4.Items.Add(PlatinumAmmount.ToString("N0") & " KGs Platinum Ore | " & PlatinumCrafTime.ToString() & " Hours In Refinery")
        End If
        If GoldCraftTime < 1 Then
            GoldCraftTime = Math.Round(((GoldAmmount * 0.308) / 60), 2) 'Minutes
            ListBox4.Items.Add(GoldAmmount.ToString("N0") & " KGs Gold Ore | " & GoldCraftTime.ToString() & " Mintes In Refinery")
        ElseIf GoldCraftTime > 1 Then
            GoldCraftTime = Math.Round(((GoldAmmount * 0.308) / 60) / 60, 2) 'Hours
            ListBox4.Items.Add(GoldAmmount.ToString("N0") & " KGs Gold Ore | " & GoldCraftTime.ToString() & " Hours In Refinery")
        End If
        If SilverCraftTime < 1 Then
            SilverCraftTime = Math.Round(((SilverAmmount * 0.769) / 60), 2) 'Minutes
            ListBox4.Items.Add(SilverAmmount.ToString("N0") & " KGs Silver Ore | " & SilverCraftTime.ToString() & " Mintes In Refinery")
        ElseIf SilverCraftTime > 1 Then
            SilverCraftTime = Math.Round(((SilverAmmount * 0.769) / 60) / 60, 2) 'Hours
            ListBox4.Items.Add(SilverAmmount.ToString("N0") & " KGs Silver Ore | " & SilverCraftTime.ToString() & " Hours In Refinery")
        End If
        If MagnesiumCraftTime < 1 Then
            MagnesiumCraftTime = Math.Round(((MagnesiumAmmount * 0.385) / 60), 2) 'Minutes
            ListBox4.Items.Add(MagnesiumAmmount.ToString("N0") & " KGs Magnesium Ore | " & MagnesiumCraftTime.ToString() & " Mintes In Refinery")
        ElseIf MagnesiumCraftTime > 1 Then
            MagnesiumCraftTime = Math.Round(((MagnesiumAmmount * 0.385) / 60) / 60, 2) 'Hours
            ListBox4.Items.Add(MagnesiumAmmount.ToString("N0") & " KGs Magnesium Ore | " & MagnesiumCraftTime.ToString() & " Hours In Refinery")
        End If
        If CobaltCraftTime < 1 Then
            CobaltCraftTime = Math.Round(((CobaltAmmout * 3.077) / 60), 2) 'Minutes
            ListBox4.Items.Add(CobaltAmmout.ToString("N0") & " KGs Silicon Ore | " & CobaltCraftTime.ToString() & " Mintes In Refinery")
        ElseIf CobaltCraftTime > 1 Then
            CobaltCraftTime = Math.Round(((CobaltAmmout * 3.077) / 60) / 60, 2) 'Hours
            ListBox4.Items.Add(CobaltAmmout.ToString("N0") & " KGs Silicon Ore | " & CobaltCraftTime.ToString() & " Hours In Refinery")
        End If
        If NickelCraftTime < 1 Then
            NickelCraftTime = Math.Round(((NickelAmmount * 1.538) / 60), 2) 'Minutes
            ListBox4.Items.Add(NickelAmmount.ToString("N0") & " KGs Silicon Ore | " & NickelCraftTime.ToString() & " Mintes In Refinery")
        ElseIf NickelCraftTime > 1 Then
            NickelCraftTime = Math.Round(((NickelAmmount * 1.538) / 60) / 60, 2) 'Hours
            ListBox4.Items.Add(NickelAmmount.ToString("N0") & " KGs Silicon Ore | " & NickelCraftTime.ToString() & " Hours In Refinery")
        End If
        If UraniumCraftTime < 1 Then
            UraniumCraftTime = Math.Round(((UraniumAmmount * 3.077) / 60), 2) 'Minutes
            ListBox4.Items.Add(UraniumAmmount.ToString("N0") & " KGs Uranium Ore | " & UraniumCraftTime.ToString() & " Mintes In Refinery")
        ElseIf UraniumCraftTime > 1 Then
            UraniumCraftTime = Math.Round(((UraniumAmmount * 3.077) / 60) / 60, 2) 'Hours
            ListBox4.Items.Add(UraniumAmmount.ToString("N0") & " KGs Uranium Ore | " & UraniumCraftTime.ToString() & " Hours In Refinery")
        End If

        'Try to load an image of the blueprint if it is available
        Dim bpimagepath As String = WorkingPath + "\thumb.png"
        Try
            PictureBox1.BackgroundImage = Image.FromFile(bpimagepath)
        Catch ex As Exception

        End Try
    End Sub
#End Region


#Region "------------=================== Main Event Handlers ===================------------"
#Region "------------=================== MainForm Load Event Handler ===================------------"
    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        'List of all controls in Main Form
        FlatTabControl1.BaseColor = My.Settings.ThemeBackColor
        FlatTabControl1.ActiveColor = My.Settings.ThemeForeColor
        FlowLayoutPanel1.BackColor = My.Settings.ThemeBackColor
        FlowLayoutPanel1.ForeColor = My.Settings.ThemeForeColor
        ListBox1.BackColor = My.Settings.ThemeBackColor
        ListBox1.ForeColor = My.Settings.ThemeForeColor
        ListBox2.BackColor = My.Settings.ThemeBackColor
        ListBox2.ForeColor = My.Settings.ThemeForeColor
        ListBox3.BackColor = My.Settings.ThemeBackColor
        ListBox3.ForeColor = My.Settings.ThemeForeColor
        ListBox4.BackColor = My.Settings.ThemeBackColor
        ListBox4.ForeColor = My.Settings.ThemeForeColor
        StatusStrip1.BackColor = My.Settings.ThemeBackColor
        StatusStrip1.ForeColor = My.Settings.ThemeForeColor
        PictureBox1.BackColor = My.Settings.ThemeBackColor

        Try
            'Check if the program directory exists & if not then create it
            If Not Directory.Exists("C:\SETools") Then
                Try
                    Directory.CreateDirectory("C:\SETools")
                Catch ex As Exception
                End Try
            End If
            'Check if the mod extraction directory exists in the C drive & if not then create it
            If Not Directory.Exists("C:\SETools\unpacked_mods") Then
                Try
                    Directory.CreateDirectory("C:\SETools\unpacked_mods")
                Catch ex As Exception
                End Try
            End If
            'Check if the file that determins whether or not the program has been run before exists or not & if not then create it
            If Not File.Exists("C:\SETools\Activated.txt") Then
                Try
                    File.CreateText("C:\SETools\Activated.txt")
                    'Unpack all mods
                    unpackAll(sepath, extractto)
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try

        'Load modded block definitions
        LoadModDefinitions()
    End Sub
#End Region

#Region "------------=================== Context Menu And Toolbar Event Handlers ===================------------"
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileFunction()
    End Sub
    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        ResetControlSystems()
    End Sub
    Private Sub OpemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpemToolStripMenuItem.Click
        OpenFileFunction()
    End Sub
    Private Sub ResetToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem1.Click
        ResetControlSystems()
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Hide()
        Configurator.Show()
    End Sub

    'Refresh Theme Controls
    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'List of all controls in Main Form
        FlatTabControl1.BaseColor = My.Settings.ThemeBackColor
        FlatTabControl1.ActiveColor = My.Settings.ThemeForeColor
        FlowLayoutPanel1.BackColor = My.Settings.ThemeBackColor
        FlowLayoutPanel1.ForeColor = My.Settings.ThemeForeColor
        ListBox1.BackColor = My.Settings.ThemeBackColor
        ListBox1.ForeColor = My.Settings.ThemeForeColor
        ListBox2.BackColor = My.Settings.ThemeBackColor
        ListBox2.ForeColor = My.Settings.ThemeForeColor
        ListBox3.BackColor = My.Settings.ThemeBackColor
        ListBox3.ForeColor = My.Settings.ThemeForeColor
        ListBox4.BackColor = My.Settings.ThemeBackColor
        ListBox4.ForeColor = My.Settings.ThemeForeColor
        StatusStrip1.BackColor = My.Settings.ThemeBackColor
        StatusStrip1.ForeColor = My.Settings.ThemeForeColor
        PictureBox1.BackColor = My.Settings.ThemeBackColor
    End Sub
End Class
#End Region
#End Region

'---------------------------===================== Component Calculations =====================---------------------------' |>>RUDEMENTARY NEEDS REVISION<<|

'Values of SteelPlates per block type
Public Class CalculateResourcesSteelPlates
    'Blast Armor
    Private ArmorCorner As Integer = 120
    Private ArmorInvCorner As Integer = 135
    Private ArmorCenter As Integer = 140
    Private ArmorSide As Integer = 130
    Private SmallArmorCenter As Integer = 5
    Private SmallArmorCorner As Integer = 5
    Private SmallArmorInvCorner As Integer = 5
    Private SmallArmorSide As Integer = 5

    'Large Light Armor Blocks
    Private LargeBlockArmorBlock As Integer = 25 'Large Light Armor Block
    Private LargeBlockArmorSlope As Integer = 13 'Large Ligth Armor Slope 
    Private LargeBlockArmorCorner As Integer = 4 'Large Light Armor Corner
    Private LargeBlockArmorCornerInv As Integer = 21 'Large Light Armor Corner Inverted
    Private LargeHalfArmorBlock As Integer = 12 'large light armor half block
    Private LargeHalfSlopeArmorBlock As Integer = 7 'Large light half armor slope
    Private LargeBlockArmorRoundSlope As Integer = 13 'Large light round armor slope
    Private LargeBlockArmorRoundCornerInv As Integer = 21 'Large light round armor corner inverted
    Private LargeBlockArmorRoundCorner As Integer = 4 'Large light round armor corner
    Private LargeBlockArmorSlope2Tip As Integer = 7 'Large light armor 2x1x1 slope tip
    Private LargeBlockArmorSlope2Base As Integer = 19
    Private LargeBlockArmorCorner2Tip As Integer = 4
    Private LargeBlockArmorCorner2Base As Integer = 10 'large light armor 2x1x1 corner base 
    Private LargeBlockArmorInvCorner2Base As Integer = 22
    Private LargeBlockArmorInvCorner2Tip As Integer = 16

    'Large Heavy Armor Blocks
    Private LargeHeavyBlockArmorBlock As Integer = 150
    Private LargeHeavyBlockArmorSlope As Integer = 75
    Private LargeHeavyBlockArmorCorner As Integer = 25
    Private LargeHeavyBlockArmorCornerInv As Integer = 125
    Private LargeHeavyHalfArmorBlock As Integer = 75
    Private LargeHeavyHalfSlopeArmorBlock As Integer = 45
    Private LargeHeavyBlockArmorRoundSlope As Integer = 130
    Private LargeHeavyBlockArmorRoundCorner As Integer = 125
    Private LargeHeavyBlockArmorRoundCornerInv As Integer = 140
    Private LargeHeavyBlockArmorSlope2Base As Integer = 112
    Private LargeHeavyBlockArmorSlope2Tip As Integer = 35
    Private LargeHeavyBlockArmorCorner2Base As Integer = 55
    Private LargeHeavyBlockArmorCorner2Tip As Integer = 19
    Private LargeHeavyBlockArmorInvCorner2Base As Integer = 133
    Private LargeHeavyBlockArmorInvCorner2Tip As Integer = 94

    'Small Light Armor Blocks
    Private SmallBlockArmorBlock As Integer = 1 'Small Light Armor Block
    Private SmallBlockArmorSlope As Integer = 1 'Small Ligth Armor Slope 
    Private SmallBlockArmorCorner As Integer = 1 'Small Light Armor Corner
    Private SmallBlockArmorCornerInv As Integer = 1 'Small Light Armor Corner Inverted
    Private SmallHalfArmorBlock As Integer = 1 'Small light armor half block
    Private SmallHalfSlopeArmorBlock As Integer = 1 'Small light half armor slope
    Private SmallBlockArmorRoundSlope As Integer = 1 'Small light round armor slope
    Private SmallBlockArmorRoundCornerInv As Integer = 1 'Small light round armor corner inverted
    Private SmallBlockArmorRoundCorner As Integer = 1 'Small light round armor corner
    Private SmallBlockArmorSlope2Tip As Integer = 1 'Small light armor 2x1x1 slope tip
    Private SmallBlockArmorSlope2Base As Integer = 1
    Private SmallBlockArmorCorner2Tip As Integer = 1
    Private SmallBlockArmorCorner2Base As Integer = 1 'Small light armor 2x1x1 corner base 
    Private SmallBlockArmorInvCorner2Base As Integer = 1
    Private SmallBlockArmorInvCorner2Tip As Integer = 1

    'Small Heavy Armor Blocks
    Private SmallHeavyBlockArmorBlock As Integer = 2
    Private SmallHeavyBlockArmorSlope As Integer = 1
    Private SmallHeavyBlockArmorCorner As Integer = 1
    Private SmallHeavyBlockArmorCornerInv As Integer = 1
    Private SmallHeavyHalfArmorBlock As Integer = 1
    Private SmallHeavyHalfSlopeArmorBlock As Integer = 1
    Private SmallHeavyBlockArmorRoundSlope As Integer = 1
    Private SmallHeavyBlockArmorRoundCorner As Integer = 1
    Private SmallHeavyBlockArmorRoundCornerInv As Integer = 1
    Private SmallHeavyBlockArmorSlope2Base As Integer = 1
    Private SmallHeavyBlockArmorSlope2Tip As Integer = 1
    Private SmallHeavyBlockArmorCorner2Base As Integer = 1
    Private SmallHeavyBlockArmorCorner2Tip As Integer = 1
    Private SmallHeavyBlockArmorInvCorner2Base As Integer = 1
    Private SmallHeavyBlockArmorInvCorner2Tip As Integer = 1

    'Production Blocks
    Private LargeBlockBatteryBlock As Integer = 80
    Private LargeProjector As Integer = 21
    Private LargeRefinery As Integer = 1200
    Private LargeAssembler As Integer = 150
    Private BlastFurnace As Integer = 120
    Private OxygenGenerator As Integer = 120
    Private LargeOreDetector As Integer = 50
    Private GravityGenerator As Integer = 150
    Private GravityGeneratorSphere As Integer = 150
    Private LargeJumpDrive As Integer = 40
    Private AirVent As Integer = 80
    Private OxygenTank As Integer = 80
    Private LargeHydrogenTank As Integer = 280
    Private LargeProductivityModule As Integer = 100
    Private LargeEffectivenessModule As Integer = 100
    Private LargeEnergyModule As Integer = 100
    Private LargeBlockSmallGenerator As Integer = 80
    Private LargeBlockLargeGenerator As Integer = 1000
    Private LargeBlockSolarPanel As Integer = 4
    Private LargeBlockOxygenFarm As Integer = 40
    Private SmallBlockBatteryBlock As Integer = 25
    Private SmallProjector As Integer = 2
    Private OxygenGeneratorSmall As Integer = 8
    Private ControlPanel As Integer = 1
    Private SmallAirVent As Integer = 8
    Private SmallHydrogenTank As Integer = 80
    Private SmallBlockSolarPanel As Integer = 2
    Private SmallBlockSmallGenerator As Integer = 3
    Private SmallBlockLargeGenerator As Integer =50
    Private OxygenTankSmall As Integer = 14

    'Functional  Blocks
    Private SmallProgrammableBlock As Integer = 2
    Private LargeProgrammableBlock As Integer = 21
    Private SmallBlockRadioAntenna As Integer = 1
    Private LargeBlockRadioAntenna As Integer = 80
    Private LargeBlockLaserAntenna As Integer = 50
    Private SmallBlockLaserAntenna As Integer = 10
    Private AirtightHangarDoor As Integer = 350
    Private Door As Integer = 8
    Private LargeBlockSlideDoor As Integer = 20
    Private LargeBlockBeacon As Integer = 80
    Private SmallBlockBeacon As Integer = 2
    Private ButtonPanelSmall As Integer = 2
    Private LargeBlockLandingGear As Integer = 150
    Private SmallBlockLandingGear As Integer = 2
    Private LargeBlockCockpit As Integer = 30
    Private SmallBlockCockpit As Integer = 10
    Private DBSmallBlockFighterCockpit As Integer = 20
    Private SmallDecoy As Integer = 1
    Private LargeDecoy As Integer = 3
    Private SmallCameraBlock As Integer = 2
    Private LargeCameraBlock As Integer = 2
    Private LargeBlockGyro As Integer = 25
    Private SmallBlockGyro As Integer = 600
    Private SmallBlockOreDetector As Integer = 3
    Private LargeBlockOreDetector As Integer = 50
    Private SmallBlockSensor As Integer = 2
    Private LargeBlockSensor As Integer = 2
    Private LargePistonBase As Integer = 15
    Private LargePistonTop As Integer = 10
    Private SmallPistonBase As Integer =4
    Private SmallPistonTop As Integer = 4
    Private LargeRotor As Integer = 15
    Private SmallRotor As Integer = 5
    Private LargeAdvancedRotor As Integer = 5
    Private SmallAdvancedRotor As Integer = 15
    Private LargeShipMergeBlock As Integer = 12
    Private SmallShipMergeBlock As Integer = 4
    Private VirtualMassLarge As Integer = 90
    Private VirtualMassSmall As Integer = 3
    Private Collector As Integer = 45
    Private CollectorSmall As Integer = 35
    Private Connector As Integer = 150
    Private ConnectorSmall As Integer = 21
    Private ConnectorMedium As Integer 'Unknown what this acutally is??? Cant find in game or in cubeblocks.sbc

    'Weapons
    Private LargeGatlingTurret As Integer = 20
    Private SmallGatlingTurret As Integer = 10
    Private LargeMissileTurret As Integer = 20
    Private SmallMissileTurret As Integer = 10
    Private SmallGatlingGun As Integer = 4
    Private SmallMissileLauncher As Integer = 4
    Private SmallRocketLauncherReload As Integer = 8
    Private LargeInteriorTurret As Integer = 4
    Private LargeMissileLauncher As Integer = 35
    Private MediumMissileLauncher As Integer 'Unknown what this acutally is??? Cant find in game or in cubeblocks.sbc
    Private LargeWarhead As Integer = 20
    Private SmallWarhead As Integer = 4

    'Tools
    Private SmallBlockDrill As Integer = 32
    Private LargeBlockDrill As Integer = 300
    Private LargeShipGrinder As Integer = 20
    Private SmallShipGrinder As Integer = 12
    Private LargeShipWelder As Integer = 12
    Private SmallShipWelder As Integer = 20

    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName
            'Blast Armor
            Case "ArmorCorner"
                _ret = ArmorCorner
            Case "ArmorInvCorner"
                _ret = ArmorInvCorner
            Case "ArmorCenter"
                _ret = ArmorCenter
            Case "ArmorSide"
                _ret = ArmorSide
            Case "SmallArmorCenter"
                _ret = SmallArmorCenter
            Case "SmallArmorCorner"
                _ret = SmallArmorCorner
            Case "SmallArmorInvCorner"
                _ret = SmallArmorInvCorner
            Case "SmallArmorSide"
                _ret = SmallArmorSide

            'Large Light Armor Blocks
            Case "LargeBlockArmorBlock" 'Large Light Armor Block
                _ret = LargeBlockArmorBlock
            Case "LargeBlockArmorSlope" 'Large Ligth Armor Slope 
                _ret = LargeBlockArmorSlope
            Case "LargeBlockArmorCorner" 'Large Light Armor Corner
                _ret = LargeBlockArmorCorner
            Case "LargeBlockArmorCornerInv" 'Large Light Armor Corner Inverted
                _ret = LargeBlockArmorCornerInv
            Case "LargeHalfArmorBlock" 'large light armor half block
                _ret = LargeHalfArmorBlock
            Case "LargeHalfSlopeArmorBlock"
                _ret = LargeHalfSlopeArmorBlock
            Case "LargeBlockArmorRoundCornerInv"
                _ret = LargeBlockArmorRoundCornerInv
            Case "LargeBlockArmorRoundedSlope"
                _ret = LargeBlockArmorRoundSlope
            Case "LargeBlockArmorRoundCorner"
                _ret = LargeBlockArmorRoundCorner
            Case "LargeBlockArmorSlope2Tip"
                _ret = LargeBlockArmorSlope2Tip
            Case "LargeBlockArmorSlope2Base"
                _ret = LargeBlockArmorSlope2Base
            Case "LargeBlockArmorCorner2Base"
                _ret = LargeBlockArmorCorner2Base
            Case "LargeBlockArmorCorner2Tip"
                _ret = LargeBlockArmorCorner2Tip
            Case "LargeBlockArmorInvCorner2Base"
                _ret = LargeBlockArmorInvCorner2Base
            Case "LargeBlockArmorInvCorner2Tip"
                _ret = LargeBlockArmorInvCorner2Tip

            'Large Heavy Armor Blocks
            Case "LargeHeavyHalfArmorBlock"
                _ret = LargeHeavyHalfArmorBlock
            Case "LargeHeavyHalfSlopeArmorBlock"
                _ret = LargeHeavyHalfSlopeArmorBlock
            Case "LargeHeavyBlockArmorBlock"
                _ret = LargeHeavyBlockArmorBlock
            Case "LargeHeavyBlockArmorSlope"
                _ret = LargeHeavyBlockArmorSlope
            Case "LargeHeavyBlockArmorCorner"
                _ret = LargeHeavyBlockArmorCorner
            Case "LargeHeavyBlockArmorCornerInv"
                _ret = LargeHeavyBlockArmorCornerInv
            Case "LargeHeavyBlockArmorRoundCornerInv"
                _ret = LargeHeavyBlockArmorRoundCornerInv
            Case "LargeHeavyBlockArmorRoundedSlope"
                _ret = LargeHeavyBlockArmorRoundSlope
            Case "LargeHeavyBlockArmorRoundCorner"
                _ret = LargeHeavyBlockArmorRoundCorner
            Case "LargeHeavyBlockArmorSlope2Base"
                _ret = LargeHeavyBlockArmorSlope2Base
            Case "LargeHeavyBlockArmorSlope2Tip"
                _ret = LargeHeavyBlockArmorSlope2Tip
            Case "LargeHeavyBlockArmorCorner2Base"
                _ret = LargeHeavyBlockArmorCorner2Base
            Case "LargeHeavyBlockArmorCorner2Tip"
                _ret = LargeHeavyBlockArmorCorner2Tip
            Case "LargeHeavyBlockArmorInvCorner2Base"
                _ret = LargeHeavyBlockArmorInvCorner2Base
            Case "LargeHeavyBlockArmorInvCorner2Tip"
                _ret = LargeHeavyBlockArmorInvCorner2Tip

           'Small Light Armor Blocks
            Case "SmallBlockArmorBlock" 'Small Light Armor Block
                _ret = SmallBlockArmorBlock
            Case "SmallBlockArmorSlope" 'Small Ligth Armor Slope 
                _ret = SmallBlockArmorSlope
            Case "SmallBlockArmorCorner" 'Small Light Armor Corner
                _ret = SmallBlockArmorCorner
            Case "SmallBlockArmorCornerInv" 'Small Light Armor Corner Inverted
                _ret = SmallBlockArmorCornerInv
            Case "SmallHalfArmorBlock" 'Small light armor half block
                _ret = SmallHalfArmorBlock
            Case "SmallHalfSlopeArmorBlock"
                _ret = SmallHalfSlopeArmorBlock
            Case "SmallBlockArmorRoundCornerInv"
                _ret = SmallBlockArmorRoundCornerInv
            Case "SmallBlockArmorRoundedSlope"
                _ret = SmallBlockArmorRoundSlope
            Case "SmallBlockArmorRoundCorner"
                _ret = SmallBlockArmorRoundCorner
            Case "SmallBlockArmorSlope2Tip"
                _ret = SmallBlockArmorSlope2Tip
            Case "SmallBlockArmorSlope2Base"
                _ret = SmallBlockArmorSlope2Base
            Case "SmallBlockArmorCorner2Base"
                _ret = SmallBlockArmorCorner2Base
            Case "SmallBlockArmorCorner2Tip"
                _ret = SmallBlockArmorCorner2Tip
            Case "SmallBlockArmorInvCorner2Base"
                _ret = SmallBlockArmorInvCorner2Base
            Case "SmallBlockArmorInvCorner2Tip"
                _ret = SmallBlockArmorInvCorner2Tip

            'Small Heavy Armor Blocks
            Case "SmallHeavyHalfArmorBlock"
                _ret = SmallHeavyHalfArmorBlock
            Case "SmallHeavyHalfSlopeArmorBlock"
                _ret = SmallHeavyHalfSlopeArmorBlock
            Case "SmallHeavyBlockArmorBlock"
                _ret = SmallHeavyBlockArmorBlock
            Case "SmallHeavyBlockArmorSlope"
                _ret = SmallHeavyBlockArmorSlope
            Case "SmallHeavyBlockArmorCorner"
                _ret = SmallHeavyBlockArmorCorner
            Case "SmallHeavyBlockArmorCornerInv"
                _ret = SmallHeavyBlockArmorCornerInv
            Case "SmallHeavyBlockArmorRoundCornerInv"
                _ret = SmallHeavyBlockArmorRoundCornerInv
            Case "SmallHeavyBlockArmorRoundedSlope"
                _ret = SmallHeavyBlockArmorRoundSlope
            Case "SmallHeavyBlockArmorRoundCorner"
                _ret = SmallHeavyBlockArmorRoundCorner
            Case "SmallHeavyBlockArmorSlope2Base"
                _ret = SmallHeavyBlockArmorSlope2Base
            Case "SmallHeavyBlockArmorSlope2Tip"
                _ret = SmallHeavyBlockArmorSlope2Tip
            Case "SmallHeavyBlockArmorCorner2Base"
                _ret = SmallHeavyBlockArmorCorner2Base
            Case "SmallHeavyBlockArmorCorner2Tip"
                _ret = SmallHeavyBlockArmorCorner2Tip
            Case "SmallHeavyBlockArmorInvCorner2Base"
                _ret = SmallHeavyBlockArmorInvCorner2Base
            Case "SmallHeavyBlockArmorInvCorner2Tip"
                _ret = SmallHeavyBlockArmorInvCorner2Tip

            'Production Blocks
            Case "LargeBlockBatteryBlock"
                _ret = LargeBlockBatteryBlock
            Case "SmallBlockBatteryBlock"
                _ret = SmallBlockBatteryBlock
            Case "LargeProjector"
                _ret = LargeProjector
            Case "SmallProjector"
                _ret = SmallProjector
            Case "LargeRefinery"
                _ret = LargeRefinery
            Case "BlastFurnace"
                _ret = BlastFurnace
            Case "OxygenGenerator"
                _ret = OxygenGenerator
            Case "OxygenGeneratorSmall"
                _ret = OxygenGeneratorSmall
            Case "LargeAssembler"
                _ret = LargeAssembler
            Case "LargeOreDetector"
                _ret = LargeOreDetector
            Case "GravityGenerator"
                _ret = GravityGenerator
            Case "GravityGeneratorSphere"
                _ret = GravityGeneratorSphere
            Case "LargeJumpDrive"
                _ret = LargeJumpDrive
            Case "OxygenTank"
                _ret = OxygenTank
            Case "LargeHydrogenTank"
                _ret = LargeHydrogenTank
            Case "SmallHydrogenTank"
                _ret = SmallHydrogenTank
            Case "OxygenTankSmall"
                _ret = OxygenTankSmall
            Case "LargeProductivityModule"
                _ret = LargeProductivityModule
            Case "LargeEffectivenessModule"
                _ret = LargeEffectivenessModule
            Case "LargeEnergyModule"
                _ret = LargeEnergyModule
            Case "SmallBlockSmallGenerator"
                _ret = SmallBlockSmallGenerator
            Case "SmallBlockLargeGenerator"
                _ret = SmallBlockLargeGenerator
            Case "LargeBlockSmallGenerator"
                _ret = LargeBlockSmallGenerator
            Case "LargeBlockLargeGenerator"
                _ret = LargeBlockLargeGenerator
            Case "LargeBlockSolarPanel"
                _ret = LargeBlockSolarPanel
            Case "SmallBlockSolarPanel"
                _ret = SmallBlockSolarPanel
            Case "LargeBlockOxygenFarm"
                _ret = LargeBlockOxygenFarm

            'Functional Blocks
            Case "ControlPanel"
                _ret = ControlPanel
            Case "SmallControlPanel"
                _ret = ControlPanel
            Case "AirVent"
                _ret = AirVent
            Case "SmallAirVent"
                _ret = SmallAirVent
            Case "SmallProgrammableBlock"
                _ret = SmallProgrammableBlock
            Case "SmallBlockRadioAntenna"
                _ret = SmallBlockRadioAntenna
            Case "LargeBlockLaserAntenna"
                _ret = LargeBlockLaserAntenna
            Case "SmallBlockLaserAntenna"
                _ret = SmallBlockLaserAntenna
            Case "AirtightHangarDoor"
                _ret = AirtightHangarDoor
            Case "LargeBlockSlideDoor"
                _ret = LargeBlockSlideDoor
            Case "Door"
                _ret = Door
            Case "LargeBlockRadioAntenna"
                _ret = LargeBlockRadioAntenna
            Case "LargeBlockBeacon"
                _ret = LargeBlockBeacon
            Case "SmallBlockBeacon"
                _ret = SmallBlockBeacon
            Case "ButtonPanelSmall"
                _ret = ButtonPanelSmall
            Case "LargeBlockLandingGear"
                _ret = LargeBlockLandingGear
            Case "LargeBlockCockpit"
                _ret = LargeBlockCockpit
            Case "SmallBlockCockpit"
                _ret = SmallBlockCockpit
            Case "DBSmallBlockFighterCockpit"
                _ret = DBSmallBlockFighterCockpit
            Case "SmallBlockLandingGear"
                _ret = SmallBlockLandingGear
            Case "LargeDecoy"
                _ret = LargeDecoy
            Case "SmallDecoy"
                _ret = SmallDecoy
            Case "SmallCameraBlock"
                _ret = SmallCameraBlock
            Case "LargeCameraBlock"
                _ret = LargeCameraBlock
            Case "LargeBlockGyro"
                _ret = LargeBlockGyro
            Case "SmallBlockGyro"
                _ret = SmallBlockGyro
            Case "SmallBlockOreDetector"
                _ret = SmallBlockOreDetector
            Case "LargeBlockOreDetector"
                _ret = LargeBlockOreDetector
            Case "SmallBlockSensor"
                _ret = SmallBlockSensor
            Case "LargeBlockSensor"
                _ret = LargeBlockSensor
            Case "LargePistonBase"
                _ret = LargePistonBase
            Case "LargePistonTop"
                _ret = LargePistonTop
            Case "SmallPistonBase"
                _ret = SmallPistonBase
            Case "SmallPistonTop"
                _ret = SmallPistonTop
            Case "LargeRotor"
                _ret = LargeRotor
            Case "SmallRotor"
                _ret = SmallRotor
            Case "LargeAdvancedRotor"
                _ret = LargeAdvancedRotor
            Case "SmallAdvancedRotor"
                _ret = SmallAdvancedRotor
            Case "LargeShipMergeBlock"
                _ret = LargeShipMergeBlock
            Case "SmallShipMergeBlock"
                _ret = SmallShipMergeBlock
            Case "VirtualMassLarge"
                _ret = VirtualMassLarge
            Case "VirtualMassSmall"
                _ret = VirtualMassSmall
            Case "Collector"
                _ret = Collector
            Case "CollectorSmall"
                _ret = CollectorSmall
            Case "Connector"
                _ret = Connector
            Case "ConnectorMedium"
                _ret = ConnectorSmall

            'Weapons
            Case "LargeGatlingTurret"
                _ret = LargeGatlingTurret
            Case "SmallGatlingTurret"
                _ret = SmallGatlingTurret
            Case "LargeMissileTurret"
                _ret = LargeMissileTurret
            Case "SmallMissileTurret"
                _ret = SmallMissileTurret
            Case "SmallGatlingGun"
                _ret = SmallGatlingGun
            Case "SmallMissileLauncher"
                _ret = SmallMissileLauncher
            Case "SmallRocketLauncherReload"
                _ret = SmallRocketLauncherReload
            Case "LargeInteriorTurret"
                _ret = LargeInteriorTurret
            Case "LargeMissileLauncher"
                _ret = LargeMissileLauncher
            Case "MediumMissileLauncher"
                _ret = MediumMissileLauncher
            Case "LargeWarhead"
                _ret = LargeWarhead
            Case "SmallWarhead"
                _ret = SmallWarhead

            'Tools
            Case "SmallBlockDrill"
                _ret = SmallBlockDrill
            Case "LargeBlockDrill"
                _ret = LargeBlockDrill
            Case "LargeShipGrinder"
                _ret = LargeShipGrinder
            Case "SmallShipGrinder"
                _ret = SmallShipGrinder
            Case "LargeShipWelder"
                _ret = LargeShipWelder
            Case "SmallShipWelder"
                _ret = SmallShipWelder

            'Decorations
            Case "SmallLight"

            Case "SmallBlockSmallLight"

            Case "Passage"

            Case "LargeBlockFrontLight"

            Case "LargeBlockLight_1corner"

            Case "LargeBlockLight_2corner"

            Case "SmallBlockLight_1corner"

            Case "SmallBlockLight_2corner"

            Case "LargeStairs"

            Case "LargeRamp"

            Case "LargeSteelCatwalk"

            Case "LargeSteelCatwalk2Sides"

            Case "LargeSteelCatwalkPlate"

            Case "LargeCoverWall"

            Case "LargeCoverWallHalf"

            Case "LargeBlockInteriorWall"

            Case "LargeInteriorPillar"

            Case "SmallBlockFrontLight"

            Case "SmallTextPanel"

            Case "SmallLCDPanelWide"

            Case "SmallLCDPanel"

            Case "LargeBlockCorner_LCD_1"

            Case "LargeBlockCorner_LCD_2"

            Case "LargeBlockCorner_LCD_Flat_1"

            Case "LargeBlockCorner_LCD_Flat_2"

            Case "SmallBlockCorner_LCD_1"

            Case "SmallBlockCorner_LCD_2"

            Case "SmallBlockCorner_LCD_Flat_1"

            Case "SmallBlockCorner_LCD_Flat_2"

            Case "LargeTextPanel"

            Case "LargeLCDPanel"

            Case "LargeLCDPanelWide"

            'Thrusters
            Case "SmallBlockSmallThrust"

            Case "SmallBlockLargeThrust"

            Case "LargeBlockSmallThrust"

            Case "LargeBlockLargeThrust"

            Case "LargeBlockLargeHydrogenThrust"

            Case "LargeBlockSmallHydrogenThrust"

            Case "SmallBlockLargeHydrogenThrust"

            Case "SmallBlockSmallHydrogenThrust"

            Case "LargeBlockLargeAtmosphericThrust"

            Case "LargeBlockSmallAtmosphericThrust"

            Case "SmallBlockLargeAtmosphericThrust"

            Case "SmallBlockSmallAtmosphericThrust"

            'Wheels
            Case "Suspension3x3"

            Case "Suspension5x5"

            Case "Suspension1x1"

            Case "SmallSuspension3x3"

            Case "SmallSuspension5x5"

            Case "SmallSuspension1x1"

            Case "SmallRealWheel1x1"

            Case "SmallRealWheel"

            Case "SmallRealWheel5x5"

            Case "RealWheel1x1"

            Case "RealWheel"

            Case "RealWheel5x5"

            Case "Wheel1x1"

            Case "SmallWheel1x1"

            Case "Wheel3x3"

            Case "SmallWheel3x3"

            Case "Wheel5x5"

            Case "SmallWheel5x5"



            Case "LargeRailStraight"

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesInteriorPlates

    'Functional Blocks
    Private SmallBlockRemoteControl As Integer = 2
    Private LargeBlockRemoteControl As Integer = 10



    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

            'Functional Blocks
            Case "SmallBlockRemoteControl"
                _ret = SmallBlockRemoteControl
            Case "LargeBlockRemoteControl"
                _ret = LargeBlockRemoteControl
        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesMotors


    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesComputers
    'Large production blocks
    Private LargeJumpDrive As Integer = 300

    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesConstructionComponents
    'Large production blocks
    Private LargeJumpDrive As Integer = 40

    'Thrusters
    Private SmallBlockSmallThrust As Integer = 1
    Private SmallBlockLargeThrust As Integer = 2
    Private LargeBlockSmallThrust As Integer = 60
    Private LargeBlockLargeThrust As Integer = 100
    Private LargeBlockLargeHydrogenThrust As Integer = 180
    Private LargeBlockSmallHydrogenThrust As Integer = 60
    Private SmallBlockLargeHydrogenThrust As Integer = 30
    Private SmallBlockSmallHydrogenThrust As Integer = 15
    Private LargeBlockLargeAtmosphericThrust As Integer = 60
    Private LargeBlockSmallAtmosphericThrust As Integer = 50
    Private SmallBlockLargeAtmosphericThrust As Integer = 30
    Private SmallBlockSmallAtmosphericThrust As Integer = 2


    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName
            'Thrusters
            Case "SmallBlockSmallThrust"
                _ret = SmallBlockSmallThrust
            Case "SmallBlockLargeThrust"
                _ret = SmallBlockLargeThrust
            Case "LargeBlockSmallThrust"
                _ret = LargeBlockSmallThrust
            Case "LargeBlockLargeThrust"
                _ret = LargeBlockLargeThrust
            Case "LargeBlockLargeHydrogenThrust"
                _ret = LargeBlockLargeHydrogenThrust
            Case "LargeBlockSmallHydrogenThrust"
                _ret = LargeBlockSmallHydrogenThrust
            Case "SmallBlockLargeHydrogenThrust"
                _ret = SmallBlockLargeHydrogenThrust
            Case "SmallBlockSmallHydrogenThrust"
                _ret = SmallBlockSmallHydrogenThrust
            Case "LargeBlockLargeAtmosphericThrust"
                _ret = LargeBlockLargeAtmosphericThrust
            Case "LargeBlockSmallAtmosphericThrust"
                _ret = LargeBlockSmallAtmosphericThrust
            Case "SmallBlockLargeAtmosphericThrust"
                _ret = SmallBlockLargeAtmosphericThrust
            Case "SmallBlockSmallAtmosphericThrust"
                _ret = SmallBlockSmallAtmosphericThrust

            'Functional Blocks
            Case = "LargeJumpDrive"
                _ret = LargeJumpDrive
        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesGirders
    'Windows
    Private Window1x2Slope As Integer = 16
    Private Window1x2Inv As Integer = 15
    Private Window1x2Face As Integer = 15
    Private Window1x2SideLeft As Integer = 13
    Private Window1x2SideRight As Integer = 13
    Private Window1x2SideRightInv As Integer = 13
    Private Window1x2SideLeftInv As Integer = 13
    Private Window1x1Slope As Integer = 12
    Private Window1x1Face As Integer = 11
    Private Window1x1Side As Integer = 9
    Private Window1x1Inv As Integer = 11
    Private Window1x2Flat As Integer = 15
    Private Window1x2FlatInv As Integer = 15
    Private Window1x1Flat As Integer = 10
    Private Window1x1FlatInv As Integer = 10
    Private Window3x3Flat As Integer = 40
    Private Window3x3FlatInv As Integer = 40
    Private Window2x3Flat As Integer = 25
    Private Window2x3FlatInv As Integer = 25

    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName
            'Windows
            Case "Window1x2Slope"
                _ret = Window1x2Slope
            Case "Window1x2Inv"
                _ret = Window1x2Inv
            Case "Window1x2Face"
                _ret = Window1x2Face
            Case "Window1x2SideLeft"
                _ret = Window1x2SideLeft
            Case "Window1x2SideRight"
                _ret = Window1x2SideRight
            Case "Window1x2SideLeftInv"
                _ret = Window1x2SideLeftInv
            Case "Window1x2SideRightInv"
                _ret = Window1x2SideRightInv
            Case "Window1x1Slope"
                _ret = Window1x1Slope
            Case "Window1x1Face"
                _ret = Window1x1Face
            Case "Window1x1Side"
                _ret = Window1x1Side
            Case "Window1x1Inv"
                _ret = Window1x1Inv
            Case "Window1x2Flat"
                _ret = Window1x2Flat
            Case "Window1x2FlatInv"
                _ret = Window1x2FlatInv
            Case "Window1x1Flat"
                _ret = Window1x1Flat
            Case "Window1x1FlatInv"
                _ret = Window1x1FlatInv
            Case "Window3x3Flat"
                _ret = Window3x3Flat
            Case "Window3x3FlatInv"
                _ret = Window3x3FlatInv
            Case "Window2x3Flat"
                _ret = Window2x3Flat
            Case "Window2x3FlatInv"
                _ret = Window2x3FlatInv
        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesPowerCells
    'Large production blocks
    Private LargeJumpDrive As Integer = 120

    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesDisplays


    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesSmallSteelTubes


    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesLargeSteelTubes
    'Large Production Blocks
    Private LargeJumpDrive As Integer = 40

    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesThrusterComponents
    Private SmallBlockSmallThrust As Integer = 1
    Private SmallBlockLargeThrust As Integer = 12
    Private LargeBlockSmallThrust As Integer = 80
    Private LargeBlockLargeThrust As Integer = 960

    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName
            'Ion Thrusters
            Case "SmallBlockSmallThrust"
                _ret = SmallBlockSmallThrust
            Case "SmallBlockLargeThrust"
                _ret = SmallBlockLargeThrust
            Case "LargeBlockSmallThrust"
                _ret = LargeBlockSmallThrust
            Case "LargeBlockLargeThrust"
                _ret = LargeBlockLargeThrust
        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesSolarCells


    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesReactorComponents


    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesMetalGrids
    'Large Heavy Armor Blocks
    Private LargeHeavyBlockArmorBlock As Integer = 50
    Private LargeHeavyBlockArmorSlope As Integer = 25
    Private LargeHeavyBlockArmorCorner As Integer = 10
    Private LargeHeavyBlockArmorCornerInv As Integer = 50
    Private LargeHeavyHalfArmorBlock As Integer = 25
    Private LargeHeavyHalfSlopeArmorBlock As Integer = 15
    Private LargeHeavyBlockArmorRoundSlope As Integer = 50
    Private LargeHeavyBlockArmorRoundCorner As Integer = 40
    Private LargeHeavyBlockArmorRoundCornerInv As Integer = 50
    Private LargeHeavyBlockArmorSlope2Base As Integer = 45
    Private LargeHeavyBlockArmorSlope2Tip As Integer = 6
    Private LargeHeavyBlockArmorCorner2Base As Integer = 15
    Private LargeHeavyBlockArmorCorner2Tip As Integer = 6
    Private LargeHeavyBlockArmorInvCorner2Base As Integer = 45
    Private LargeHeavyBlockArmorInvCorner2Tip As Integer = 25

    'Small Heavy Armor Blocks
    Private SmallHeavyBlockArmorBlock As Integer = 2
    Private SmallHeavyBlockArmorSlope As Integer = 1
    Private SmallHeavyBlockArmorCorner As Integer = 1
    Private SmallHeavyBlockArmorCornerInv As Integer = 1
    Private SmallHeavyHalfArmorBlock As Integer = 1
    Private SmallHeavyHalfSlopeArmorBlock As Integer = 1
    Private SmallHeavyBlockArmorRoundSlope As Integer = 1
    Private SmallHeavyBlockArmorRoundCorner As Integer = 1
    Private SmallHeavyBlockArmorRoundCornerInv As Integer = 1
    Private SmallHeavyBlockArmorSlope2Base As Integer = 1
    Private SmallHeavyBlockArmorSlope2Tip As Integer = 1
    Private SmallHeavyBlockArmorCorner2Base As Integer = 1
    Private SmallHeavyBlockArmorCorner2Tip As Integer = 1
    Private SmallHeavyBlockArmorInvCorner2Base As Integer = 1
    Private SmallHeavyBlockArmorInvCorner2Tip As Integer = 1

    'Large Production Blocks
    Private LargeMedicalRoom As Integer = 60
    Private LargeJumpDrive As Integer = 50

    'Small Production Blocks


    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName
            'Large Heavy Armor Blocks
            Case "LargeHeavyHalfArmorBlock"
                _ret = LargeHeavyHalfArmorBlock
            Case "LargeHeavyHalfSlopeArmorBlock"
                _ret = LargeHeavyHalfSlopeArmorBlock
            Case "LargeHeavyBlockArmorBlock"
                _ret = LargeHeavyBlockArmorBlock
            Case "LargeHeavyBlockArmorSlope"
                _ret = LargeHeavyBlockArmorSlope
            Case "LargeHeavyBlockArmorCorner"
                _ret = LargeHeavyBlockArmorCorner
            Case "LargeHeavyBlockArmorCornerInv"
                _ret = LargeHeavyBlockArmorCornerInv
            Case "LargeHeavyBlockArmorRoundCornerInv"
                _ret = LargeHeavyBlockArmorRoundCornerInv
            Case "LargeHeavyBlockArmorRoundedSlope"
                _ret = LargeHeavyBlockArmorRoundSlope
            Case "LargeHeavyBlockArmorRoundCorner"
                _ret = LargeHeavyBlockArmorRoundCorner
            Case "LargeHeavyBlockArmorSlope2Base"
                _ret = LargeHeavyBlockArmorSlope2Base
            Case "LargeHeavyBlockArmorSlope2Tip"
                _ret = LargeHeavyBlockArmorSlope2Tip
            Case "LargeHeavyBlockArmorCorner2Base"
                _ret = LargeHeavyBlockArmorCorner2Base
            Case "LargeHeavyBlockArmorCorner2Tip"
                _ret = LargeHeavyBlockArmorCorner2Tip
            Case "LargeHeavyBlockArmorInvCorner2Base"
                _ret = LargeHeavyBlockArmorInvCorner2Base
            Case "LargeHeavyBlockArmorInvCorner2Tip"
                _ret = LargeHeavyBlockArmorInvCorner2Tip

            'Small Heavy Armor Blocks
            Case "SmallHeavyHalfArmorBlock"
                _ret = SmallHeavyHalfArmorBlock
            Case "SmallHeavyHalfSlopeArmorBlock"
                _ret = SmallHeavyHalfSlopeArmorBlock
            Case "SmallHeavyBlockArmorBlock"
                _ret = SmallHeavyBlockArmorBlock
            Case "SmallHeavyBlockArmorSlope"
                _ret = SmallHeavyBlockArmorSlope
            Case "SmallHeavyBlockArmorCorner"
                _ret = SmallHeavyBlockArmorCorner
            Case "SmallHeavyBlockArmorCornerInv"
                _ret = SmallHeavyBlockArmorCornerInv
            Case "SmallHeavyBlockArmorRoundCornerInv"
                _ret = SmallHeavyBlockArmorRoundCornerInv
            Case "SmallHeavyBlockArmorRoundedSlope"
                _ret = SmallHeavyBlockArmorRoundSlope
            Case "SmallHeavyBlockArmorRoundCorner"
                _ret = SmallHeavyBlockArmorRoundCorner
            Case "SmallHeavyBlockArmorSlope2Base"
                _ret = SmallHeavyBlockArmorSlope2Base
            Case "SmallHeavyBlockArmorSlope2Tip"
                _ret = SmallHeavyBlockArmorSlope2Tip
            Case "SmallHeavyBlockArmorCorner2Base"
                _ret = SmallHeavyBlockArmorCorner2Base
            Case "SmallHeavyBlockArmorCorner2Tip"
                _ret = SmallHeavyBlockArmorCorner2Tip
            Case "SmallHeavyBlockArmorInvCorner2Base"
                _ret = SmallHeavyBlockArmorInvCorner2Base
            Case "SmallHeavyBlockArmorInvCorner2Tip"
                _ret = SmallHeavyBlockArmorInvCorner2Tip
        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesGravityComponents
    'Large ProductionB locks
    Private LargeJumpDrive As Integer = 20

    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesMedicalComponents


    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesRadioComponents


    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesSuperConducters
    'Large ProductionB locks
    Private LargeJumpDrive As Integer = 1000

    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesDetectorComponents
    'Large production blocks
    Private LargeJumpDrive As Integer = 20

    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesCanvas


    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName

        End Select
        Return _ret
    End Function
End Class

Public Class CalculateResourcesBulletproofGlass


    'Windows
    Private Window1x2Slope As Integer = 55
    Private Window1x2Inv As Integer = 40
    Private Window1x2Face As Integer = 40
    Private Window1x2SideLeft As Integer = 26
    Private Window1x2SideRight As Integer = 26
    Private Window1x2SideRightInv As Integer = 26
    Private Window1x2SideLeftInv As Integer = 26
    Private Window1x1Slope As Integer = 35
    Private Window1x1Face As Integer = 24
    Private Window1x1Side As Integer = 17
    Private Window1x1Inv As Integer = 17
    Private Window1x2Flat As Integer = 50
    Private Window1x2FlatInv As Integer = 50
    Private Window1x1Flat As Integer = 25
    Private Window1x1FlatInv As Integer = 25
    Private Window3x3Flat As Integer = 196
    Private Window3x3FlatInv As Integer = 196
    Private Window2x3Flat As Integer = 140
    Private Window2x3FlatInv As Integer = 140

    Public Function Value(ByVal BlockName As String) As Integer
        Dim _ret As Integer
        Select Case BlockName
           'Windows
            Case "Window1x2Slope"
                _ret = Window1x2Slope
            Case "Window1x2Inv"
                _ret = Window1x2Inv
            Case "Window1x2Face"
                _ret = Window1x2Face
            Case "Window1x2SideLeft"
                _ret = Window1x2SideLeft
            Case "Window1x2SideRight"
                _ret = Window1x2SideRight
            Case "Window1x2SideLeftInv"
                _ret = Window1x2SideLeftInv
            Case "Window1x2SideRightInv"
                _ret = Window1x2SideRightInv
            Case "Window1x1Slope"
                _ret = Window1x1Slope
            Case "Window1x1Face"
                _ret = Window1x1Face
            Case "Window1x1Side"
                _ret = Window1x1Side
            Case "Window1x1Inv"
                _ret = Window1x1Inv
            Case "Window1x2Flat"
                _ret = Window1x2Flat
            Case "Window1x2FlatInv"
                _ret = Window1x2FlatInv
            Case "Window1x1Flat"
                _ret = Window1x1Flat
            Case "Window1x1FlatInv"
                _ret = Window1x1FlatInv
            Case "Window3x3Flat"
                _ret = Window3x3Flat
            Case "Window3x3FlatInv"
                _ret = Window3x3FlatInv
            Case "Window2x3Flat"
                _ret = Window2x3Flat
            Case "Window2x3FlatInv"
                _ret = Window2x3FlatInv
        End Select
        Return _ret
    End Function
End Class

'---------------------------===================== XML FUNCTIONS =====================---------------------------'

'XML INPUT LOADING FUNCTION
Public Class Model
    Public print As Model
    Public _type As String
    Public _id As ID
    Public displayname As String
    Public enumerator As String
    Public cubes As New CubeGrid

    Public Sub Load(filename As String)
        Try
            Dim reader As New StreamReader(filename)
            Dim doc As XDocument = XDocument.Load(reader)
            Dim firstNode As XElement = doc.FirstNode
            Dim xsiNs = firstNode.GetNamespaceOfPrefix("xsi")
            Dim drawingTypes = firstNode.Elements.FirstOrDefault()
            Dim drawingType = drawingTypes.Elements.FirstOrDefault()
            Dim drawingStr = drawingType.Name.LocalName
            print = doc.Descendants(drawingStr).Select(Function(x) New Model() With {
           ._type = x.Attribute(xsiNs + "type"), .displayname = x.Element("DisplayName"), ._id = x.Elements("Id").Select(Function(y) New ID() With {
                                              .type = y.Attribute("Type"),
                                              .subtype = y.Element("SubtypeId")
                                          }).FirstOrDefault(),
           .cubes = x.Descendants("CubeGrid").Select(Function(y) New CubeGrid() With {
                                                      .enumerator = y.Element("GridSizeEnum"),
                                                      .id = y.Element("EntityId"),
                                                      .SubTypeID = y.Element("SubtypeId"),
                                                      .persistentFlags = y.Element("PersistentFlags"),
                                                      .position = y.Descendants("Position").Select(Function(z) New location() With {
                                                        .x = CType(z.Attribute("x"), Double),
                                                        .y = CType(z.Attribute("y"), Double),
                                                        .z = CType(z.Attribute("z"), Double)
                                                      }).FirstOrDefault(),
                                                      .forward = y.Descendants("Forward").Select(Function(z) New location() With {
                                                        .x = CType(z.Attribute("x"), Double),
                                                        .y = CType(z.Attribute("y"), Double),
                                                        .z = CType(z.Attribute("z"), Double)
                                                      }).FirstOrDefault(),
                                                      .up = y.Descendants("Up").Select(Function(z) New location() With {
                                                        .x = CType(z.Attribute("x"), Double),
                                                        .y = CType(z.Attribute("y"), Double),
                                                        .z = CType(z.Attribute("z"), Double)
                                                      }).FirstOrDefault(),
                                                      .orientation = y.Descendants("Orientation").Select(Function(z) New location() With {
                                                        .w = CType(z.Element("W"), Double),
                                                        .x = CType(z.Element("X"), Double),
                                                        .y = CType(z.Element("Y"), Double),
                                                        .z = CType(z.Element("Z"), Double)
                                                      }).FirstOrDefault(),
                                                      .cubeBlocks = y.Descendants("MyObjectBuilder_CubeBlock").GroupBy(Function(z) New With {Key .subName = CType(z.Element("SubtypeName"), String), Key .userName = CType(z.Attribute(xsiNs + "type"), String)}).Select(Function(z) New CubeBlock() With {
                                                        .SubtypeName = CType(z.FirstOrDefault().Element("SubtypeName"), String),
                                                        .username = z.FirstOrDefault().Attribute(xsiNs + "type"),
                                                        .count = z.Count
                                                      }).OrderBy(Function(z) z.SubtypeName).ToList()
                                                  }).FirstOrDefault()
                                               }).FirstOrDefault()
        Catch ex As Exception
            ex.Data.Clear()
        End Try
    End Sub
End Class
Public Class ID
    Public type As String
    Public subtype As String
End Class
Public Class CubeGrid
    Inherits Panel
    Public id As String
    Public persistentFlags As String
    Public position As location
    Public forward As location
    Public up As location
    Public orientation As location
    Public cubeBlocks As List(Of CubeBlock)
    Public displayname As String
    Public SubTypeID As String
    Public ownername As String
    Public enumerator As String
End Class
Public Class location
    Public w As Double
    Public x As Double
    Public y As Double
    Public z As Double
End Class
Public Class CubeBlock
    Inherits Panel
    Public SubtypeName As String
    Public username As String
    Public count As Integer
End Class