Imports System.Xml
Imports System.Xml.Linq
Imports System.IO
Imports System.IO.Compression
Imports System.IO.Compression.ZipFile
Imports System.Environment
Imports System.String
Imports System.Reflection
Imports System.Xml.Serialization
Imports System.Net

Public Class Main
#Region "------------=================== Alpha Update 1.0 - Rework Component and Block Defining System  ===================------------"
    'Class Declerations
    Public FILENAME As String = String.Empty 'Set the filename variable to an empty string
    Public models As Model 'Set the access of the model class through models
    Public TotalBlockCount As Integer = 0
    Public Shared WorkingPath As String = Nothing
    Public _model As New Model 'Grant access to the model class through _model
    Public status As Boolean = True
    Public subPanels As New List(Of CubeBlock) 'Set a new variable subpanels as a list of cube blocks through the cubeblock class

    'Component Delecrations
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

    Public CubeBlocks As String = Directory.GetCurrentDirectory & "\SE Resources\CubeBlocks.sbc" 'Prepackaged XML file containing all space engineers block definitions
    Public BlockDefinitionDictonary As New Dictionary(Of String, DefinitionsDefinition)
    Public ModBlockDefinitionDictionary As New Dictionary(Of String, DefinitionsDefinition)

    'Deserialize Cube Information
    Public Sub DeserializeCubes()
        Dim DefinitionData As New Definitions()
        Dim xmlSerializer As XmlSerializer = New XmlSerializer(GetType(Definitions))
        Dim streamread As New StreamReader(CubeBlocks)
        DefinitionData = xmlSerializer.Deserialize(streamread)
        For Each BlockDefinition In DefinitionData.CubeBlocks()
            BlockDefinitionDictonary.Add(BlockDefinition.Id.SubtypeId.ToString(), BlockDefinition)
        Next
    End Sub
#End Region

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

#End Region

#Region "------------=================== Initilize List Definitions ===================------------"
    Public ModdedCubeblockDefinitions As New Dictionary(Of Integer, String) 'a dictonary containing the cubeblock.sbc files from all the mods a user has installed
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

#Region "------------=================== Function To Unzip Mod Files to the Temp Folder ===================------------"
    Dim appData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Dim sepath As String = appData + "\SpaceEngineers\Mods"
    Dim bppath As String = appData + "\SpaceEngineers\Blueprints\Local"
    Dim extractto As String = My.Settings.SpaceEngineersWorkingDirectory
    Function UnpackAll(pat As String, Optional destPath As String = "") As Integer 'Unpack all the space engineers mods from %AppData%\Roaming\SpaceEngineers\Mods and to a folder in the root directory of the C drive
        UnpackAll = 0
        If Not Directory.Exists(pat) Then Return Nothing
        If Not Directory.Exists(destPath) Then 'Test if the folder exists and if not then create the folder and cd into it
            Try
                destPath = extractto + "\" + UnpackAll.ToString
                Directory.CreateDirectory(destPath)
            Catch ex As Exception
            End Try
        End If
        If Not Directory.Exists(destPath) Then Return Nothing
        For Each zfn In Directory.GetFiles(pat, "*.sbm") 'For each zipfilename in the given directory extract them to the given folder
            Try
                destPath = extractto + "\" + UnpackAll.ToString
                ZipFile.ExtractToDirectory(zfn, destPath)
                UnpackAll += 1
            Catch ex As Exception
            End Try
        Next
    End Function
#End Region

#Region "------------=================== Functions to Calculate Component Counts ===================------------ |> FINISHED <|"
    Public Function CalculateComponents(inputblock As String, inputcount As Integer, flag As Boolean, search As String)
        Dim count As Integer = 0

        Try
            If flag = True Then 'Vanilla Blocks
                Select Case search
                    Case "SteelPlate"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("SteelPlate") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "InteriorPlate"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("InteriorPlate") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "SmallTube"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("SmallTube") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "LargeTube"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("LargeTube") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Computer"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Computer") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Construction"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Construction") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Detector"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Detector") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "GravityGenerator"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("GravityGenerator") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Medical"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Medical") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "MetalGrid"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("MetalGrid") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "RadioCommunication"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("RadioCommunication") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Reactor"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Reactor") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Thrust"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Thrust") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Canvas"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Canvas") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Display"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Display") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Girder"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Girder") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Motor"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Motor") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "PowerCell"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("PowerCell") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "SolarCell"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("SolarCell") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Superconductor"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Superconductor") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "BulletproofGlass"
                        For Each component In BlockDefinitionDictonary(inputblock).Components()
                            If component.Subtype.ToString().Contains("BulletproofGlass") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                End Select
            ElseIf flag = False Then 'Modded Blocks
                Select Case search
                    Case "SteelPlate"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("SteelPlate") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "InteriorPlate"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("InteriorPlate") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "SmallTube"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("SmallTube") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "LargeTube"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("LargeTube") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Computer"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Computer") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Construction"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Construction") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Detector"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Detector") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "GravityGenerator"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("GravityGenerator") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Medical"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Medical") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "MetalGrid"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("MetalGrid") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "RadioCommunication"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("RadioCommunication") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Reactor"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Reactor") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Thrust"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Thrust") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Canvas"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Canvas") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Display"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Display") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Girder"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Girder") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Motor"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Motor") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "PowerCell"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("PowerCell") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "SolarCell"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("SolarCell") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "Superconductor"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("Superconductor") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                    Case "BulletproofGlass"
                        For Each component In ModBlockDefinitionDictionary(inputblock).Components()
                            If component.Subtype.ToString().Contains("BulletproofGlass") Then
                                count = (component.Count * inputcount)
                            End If
                        Next
                End Select
            End If
        Catch ex As Exception
            'Debug stack trace
            MessageBox.Show("Error Occurred - Stack Trace" + vbNewLine + "Block Name: " + inputblock.ToString() + vbNewLine + ex.ToString())
        End Try

        'Return the counted component
        Return count
    End Function
#End Region

#Region "------------=================== Function To Reset Controls Systems ===================------------"
    Public Sub ResetControlSystems()
        'Reset flag
        status = True

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

        'Reset Form Title
        Me.Text = "Space Engineers Blueprint Manager"

        GC.Collect() 'Finalize Cleanup with a garbage collector call
    End Sub
#End Region

#Region "------------=================== Function to Load ALL modded block data into a Dictionary ===================------------"
    Public Sub LoadModDefinitions()
        Dim modpath As String = My.Settings.SpaceEngineersWorkingDirectory
        Dim id As Integer = 0
        Dim Cleaner As New XMLCleaner()

        For Each folder In Directory.GetDirectories(modpath)
            Dim folder_complete As String = folder.ToString() + "\Data"

            Try
                For Each file In Directory.GetFiles(folder_complete, "CubeBlocks.sbc") 'For each zipfilename in the given directory extract them to the given folder
                    Dim moddedxml As String = Cleaner.CleanXML(System.IO.File.ReadAllText(file))
                    Dim DefinitionData As New Definitions()
                    Dim xmlSerializer As XmlSerializer = New XmlSerializer(GetType(Definitions))

                    Try
                        Dim streamread As New StringReader(moddedxml)
                        DefinitionData = xmlSerializer.Deserialize(streamread)
                    Catch ex As Exception

                    End Try

                    For Each BlockDefinition In DefinitionData.CubeBlocks()
                        Try
                            If Not ModBlockDefinitionDictionary(BlockDefinition.Id.SubtypeId.ToString()) Is Nothing Then
                                'Block already exists dont add it
                            Else
                                ModBlockDefinitionDictionary.Add(BlockDefinition.Id.SubtypeId.ToString(), BlockDefinition)
                            End If
                        Catch ex As Exception

                        End Try
                    Next
                Next

                id += 1
            Catch ex As Exception

            End Try
        Next
    End Sub
#End Region

#Region "------------=================== Function to check for updates of the program ===================------------"
    Public Function CheckUpdates(version As String)
        Dim Flag As Boolean

        Try
            Dim wr As HttpWebRequest = CType(WebRequest.Create("https://raw.githubusercontent.com/ZeroPointGaming/SpaceEngineersBlueprintManager/master/version.ver"), HttpWebRequest)
            Dim ws As HttpWebResponse = CType(wr.GetResponse(), HttpWebResponse)
            Dim SR As StreamReader = New StreamReader(ws.GetResponseStream())
            Dim vers As String = SR.ReadToEnd()

            If vers = Assembly.GetExecutingAssembly().GetName().Version.ToString() Then
                Flag = True
                MessageBox.Show(vers + " Is the latest version, your all up to date!")
            Else
                Flag = False
                MessageBox.Show("Updates are available!" + vbNewLine + "Your Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + vbNewLine + "Latest Version: " + vers.ToString() + vbNewLine + vbNewLine + "Visit the github to download the latest version!" + vbNewLine + "https://github.com/ZeroPointGaming/SpaceEngineersBlueprintManager/releases")
            End If
        Catch ex As Exception
            MessageBox.Show("There was an error checking for an update!" + vbNewLine + "Your Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + vbNewLine + "Check the github manually for a newer version here: " + vbNewLine + "https://github.com/ZeroPointGaming/SpaceEngineersBlueprintManager/releases")
        End Try

        Return Flag
    End Function
#End Region
#End Region

#Region "------------=================== Primary Function to load the blueprint ===================------------"
    Public Sub OpenFileFunction()
        'Call the reset function
        ResetControlSystems()

        'pre-load initialization
        Dim fileloader As New OpenFileDialog()
        fileloader.ShowDialog() 'Display the open dialog to select what file to load
        FILENAME = fileloader.FileName 'Setting the filename variable to the user selected file from the open dialog

        'Catch error if user cancles the loading dialog
        Try
            WorkingPath = Path.GetDirectoryName(fileloader.FileName)
            models = New Model 'Create a reference to the Model class
            models.Load(FILENAME) 'Initiate the loading sequence to get the information from the XML file
        Catch ex As Exception
            MessageBox.Show("Error: No file selected!")
            status = False
        End Try

        If status = True Then
            'Grabbing information from XML filet
            Dim blockNames As List(Of String)
            Dim display As String = ""
            Dim gridsizeenum As String = ""
            Dim ownername As String = ""
            Try
                blockNames = models.print.cubes.cubeBlocks.Select(Function(x) x.SubtypeName).ToList() 'List of blocks in the blueprint
                display = models.print.displayname 'Gets the owner of the blueprint
                gridsizeenum = models.print.cubes.enumerator 'Gets the gridsize of the blueprint
                ownername = models.print._id.subtype 'returns the name of the blueprint
            Catch ex As Exception
                ex = Nothing
            End Try

            'Load the information about the blueprint (ownername, grid name, grid type) into the title of the form
            Dim OwnerVariable As String = ""
            Dim DisplayVariable As String = ""
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
                Dim newPicture As New PictureBox With {
                    .Height = My.Settings.BlockImgHeight,
                    .Width = My.Settings.BlockImgWidth,
                    .Top = PICTURE_BOX_TOP,
                    .Left = PICTURE_BOX_LEFT,
                    .BackgroundImageLayout = ImageLayout.Stretch
                }

                'Workaround for blocks with no/wrong subtype names
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
                Dim newLabel As New Label With {
                    .Height = LABEL_HEIGHT,
                    .Width = LABEL_WIDTH,
                    .BackColor = Color.Transparent,
                    .ForeColor = Color.Orange,
                    .Font = New Font("Segoe UI", 8, FontStyle.Regular)
                }
                'If block is not vanilla then give it its default block name
                If Not ListOfVanillaBlocks.Contains(newPanel.SubtypeName) Then
                    newLabel.Text = newPanel.SubtypeName & "(" & newPanel.count & ")"
                ElseIf newPanel.SubtypeName = "" Then
                    newPanel.SubtypeName = newPanel.username
                End If
                'Temporary Block Naming Function
                newLabel.Text = newPanel.SubtypeName & " | Count: (" & newPanel.count & ")"
                'Append the label of the block name and its count to the image generated before
                newPicture.Controls.Add(newLabel)

                'Calculate the ammount of components needed per set of blocks |>>FINISHED<<|
                For Each block In ListOfVanillaBlocks
                    If newPanel.SubtypeName = block Then
                        SteelPlateCount += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "SteelPlate")
                        InteriorPlateCount += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "InteriorPlate")
                        Computer += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "Computer")
                        Superconducter += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "Superconductor")
                        Canvas += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "Canvas")
                        Girder += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "Girder")
                        BulletproofGlass += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "BulletproofGlass")
                        ConstructionComponent += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "Construction")
                        DetectorComponent += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "Detector")
                        Displays += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "Display")
                        MetalGrid += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "MetalGrid")
                        SmallSteelTube += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "SmallTube")
                        GravityGeneratorComponents += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "GravityGenerator")
                        LargeSteelTube += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "LargeTube")
                        MedicalComponents += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "Medical")
                        Motor += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "Motor")
                        PowerCell += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "PowerCell")
                        RadioCommunicationComponents += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "RadioCommunication")
                        ReactorComponents += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "Reactor")
                        SolarCell += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "SolarCell")
                        ThrusterComponents += CalculateComponents(newPanel.SubtypeName, newPanel.count, True, "Thrust")
                    End If
                Next

                'Calculate components for modded blocks
                For Each block In ModBlockDefinitionDictionary
                    If block.Key.ToString() = newPanel.SubtypeName.ToString() Then
                        SteelPlateCount += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "SteelPlate")
                        InteriorPlateCount += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "InteriorPlate")
                        Computer += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "Computer")
                        Superconducter += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "Superconductor")
                        Canvas += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "Canvas")
                        Girder += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "Girder")
                        BulletproofGlass += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "BulletproofGlass")
                        ConstructionComponent += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "Construction")
                        DetectorComponent += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "Detector")
                        Displays += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "Display")
                        MetalGrid += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "MetalGrid")
                        SmallSteelTube += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "SmallTube")
                        GravityGeneratorComponents += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "GravityGenerator")
                        LargeSteelTube += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "LargeTube")
                        MedicalComponents += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "Medical")
                        Motor += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "Motor")
                        PowerCell += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "PowerCell")
                        RadioCommunicationComponents += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "RadioCommunication")
                        ReactorComponents += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "Reactor")
                        SolarCell += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "SolarCell")
                        ThrusterComponents += CalculateComponents(newPanel.SubtypeName, newPanel.count, False, "Thrust")
                    End If
                Next

                'add count of current block to total block count
                TotalBlockCount += newPanel.count
                'Add items to the list box for information output
                ListBox1.Items.Add(newPanel.SubtypeName & " | BlockCount: " & " (" & newPanel.count.ToString & ")")
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
            'Components List ListBox2
            ListBox2.Items.Add(SteelPlateCount.ToString("N0") & " Steel Plates")
            ListBox2.Items.Add(InteriorPlateCount.ToString("N0") & " Interior Plates")
            ListBox2.Items.Add(Computer.ToString("N0") & " Computers")
            ListBox2.Items.Add(Superconducter.ToString("N0") & " Super Conductors")
            ListBox2.Items.Add(Canvas.ToString("N0") & " Canvas")
            ListBox2.Items.Add(Girder.ToString("N0") & " Girders")
            ListBox2.Items.Add(BulletproofGlass.ToString("N0") & " Blluetproof Glass")
            ListBox2.Items.Add(ConstructionComponent.ToString("N0") & " Construction Components")
            ListBox2.Items.Add(DetectorComponent.ToString("N0") & " Detector Components")
            ListBox2.Items.Add(Displays.ToString("N0") & " Displays")
            ListBox2.Items.Add(GravityGeneratorComponents.ToString("N0") & " Gravity Generator Components")
            ListBox2.Items.Add(LargeSteelTube.ToString("N0") & " Large Steel Tubes")
            ListBox2.Items.Add(SmallSteelTube.ToString("N0") & " Small Steel Tubes")
            ListBox2.Items.Add(MedicalComponents.ToString("N0") & " Medical Components")
            ListBox2.Items.Add(MetalGrid.ToString("N0") & " Metal Grids")
            ListBox2.Items.Add(Motor.ToString("N0") & " Motors")
            ListBox2.Items.Add(PowerCell.ToString("N0") & " Power Cells")
            ListBox2.Items.Add(RadioCommunicationComponents.ToString("N0") & " Radio Communication Components")
            ListBox2.Items.Add(ReactorComponents.ToString("N0") & " Reactor Components")
            ListBox2.Items.Add(SolarCell.ToString("N0") & " Solar Cells")
            ListBox2.Items.Add(ThrusterComponents.ToString("N0") & " Thruster Components")

            'Materials List ListBox3
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

            'Raw Materials List ListBox4
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
                ListBox4.Items.Add(SiliconAmmount.ToString("N0") & " KGs Silicon Ore | " & SiliconCraftTime.ToString() & " Minutes In Refinery")
            ElseIf SiliconCraftTime > 1 Then
                SiliconCraftTime = Math.Round(((SiliconAmmount * 0.462) / 60) / 60, 2) 'Hours
                ListBox4.Items.Add(SiliconAmmount.ToString("N0") & " KGs Silicon Ore | " & SiliconCraftTime.ToString() & " Hours In Refinery")
            End If
            If StoneCraftTime < 1 Then
                StoneCraftTime = Math.Round(((StoneAmmount * 0.077) / 60), 2) 'Minutes
                ListBox4.Items.Add(StoneAmmount.ToString("N0") & " KGs Stones | " & StoneCraftTime.ToString() & " Minutes In Refinery")
            ElseIf StoneCraftTime > 1 Then
                StoneCraftTime = Math.Round(((StoneAmmount * 0.077) / 60) / 60, 2) 'Hours
                ListBox4.Items.Add(StoneAmmount.ToString("N0") & " KGs Stones | " & StoneCraftTime.ToString() & " Hours In Refinery")
            End If
            If PlatinumCrafTime < 1 Then
                PlatinumCrafTime = Math.Round(((PlatinumAmmount * 3.077) / 60), 2) 'Minutes
                ListBox4.Items.Add(PlatinumAmmount.ToString("N0") & " KGs Platinum Ore | " & PlatinumCrafTime.ToString() & " Minutes In Refinery")
            ElseIf PlatinumCrafTime > 1 Then
                PlatinumCrafTime = Math.Round(((PlatinumAmmount * 3.077) / 60) / 60, 2) 'Hours
                ListBox4.Items.Add(PlatinumAmmount.ToString("N0") & " KGs Platinum Ore | " & PlatinumCrafTime.ToString() & " Hours In Refinery")
            End If
            If GoldCraftTime < 1 Then
                GoldCraftTime = Math.Round(((GoldAmmount * 0.308) / 60), 2) 'Minutes
                ListBox4.Items.Add(GoldAmmount.ToString("N0") & " KGs Gold Ore | " & GoldCraftTime.ToString() & " Minutes In Refinery")
            ElseIf GoldCraftTime > 1 Then
                GoldCraftTime = Math.Round(((GoldAmmount * 0.308) / 60) / 60, 2) 'Hours
                ListBox4.Items.Add(GoldAmmount.ToString("N0") & " KGs Gold Ore | " & GoldCraftTime.ToString() & " Hours In Refinery")
            End If
            If SilverCraftTime < 1 Then
                SilverCraftTime = Math.Round(((SilverAmmount * 0.769) / 60), 2) 'Minutes
                ListBox4.Items.Add(SilverAmmount.ToString("N0") & " KGs Silver Ore | " & SilverCraftTime.ToString() & " Minutes In Refinery")
            ElseIf SilverCraftTime > 1 Then
                SilverCraftTime = Math.Round(((SilverAmmount * 0.769) / 60) / 60, 2) 'Hours
                ListBox4.Items.Add(SilverAmmount.ToString("N0") & " KGs Silver Ore | " & SilverCraftTime.ToString() & " Hours In Refinery")
            End If
            If MagnesiumCraftTime < 1 Then
                MagnesiumCraftTime = Math.Round(((MagnesiumAmmount * 0.385) / 60), 2) 'Minutes
                ListBox4.Items.Add(MagnesiumAmmount.ToString("N0") & " KGs Magnesium Ore | " & MagnesiumCraftTime.ToString() & " Minutes In Refinery")
            ElseIf MagnesiumCraftTime > 1 Then
                MagnesiumCraftTime = Math.Round(((MagnesiumAmmount * 0.385) / 60) / 60, 2) 'Hours
                ListBox4.Items.Add(MagnesiumAmmount.ToString("N0") & " KGs Magnesium Ore | " & MagnesiumCraftTime.ToString() & " Hours In Refinery")
            End If
            If CobaltCraftTime < 1 Then
                CobaltCraftTime = Math.Round(((CobaltAmmout * 3.077) / 60), 2) 'Minutes
                ListBox4.Items.Add(CobaltAmmout.ToString("N0") & " KGs Silicon Ore | " & CobaltCraftTime.ToString() & " Minutes In Refinery")
            ElseIf CobaltCraftTime > 1 Then
                CobaltCraftTime = Math.Round(((CobaltAmmout * 3.077) / 60) / 60, 2) 'Hours
                ListBox4.Items.Add(CobaltAmmout.ToString("N0") & " KGs Silicon Ore | " & CobaltCraftTime.ToString() & " Hours In Refinery")
            End If
            If NickelCraftTime < 1 Then
                NickelCraftTime = Math.Round(((NickelAmmount * 1.538) / 60), 2) 'Minutes
                ListBox4.Items.Add(NickelAmmount.ToString("N0") & " KGs Silicon Ore | " & NickelCraftTime.ToString() & " Minutes In Refinery")
            ElseIf NickelCraftTime > 1 Then
                NickelCraftTime = Math.Round(((NickelAmmount * 1.538) / 60) / 60, 2) 'Hours
                ListBox4.Items.Add(NickelAmmount.ToString("N0") & " KGs Silicon Ore | " & NickelCraftTime.ToString() & " Hours In Refinery")
            End If
            If UraniumCraftTime < 1 Then
                UraniumCraftTime = Math.Round(((UraniumAmmount * 3.077) / 60), 2) 'Minutes
                ListBox4.Items.Add(UraniumAmmount.ToString("N0") & " KGs Uranium Ore | " & UraniumCraftTime.ToString() & " Minutes In Refinery")
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
        End If

        fileloader.Dispose()
    End Sub
#End Region

#Region "------------=================== Main Event Handlers ===================------------"
#Region "------------=================== MainForm Load Event Handler ===================------------"
    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        'Set directory settings first time run
        If My.Settings.IdentifierAplha = 0 Then
            Try
                'Check if the program directory exists & if not then create it
                If Not Directory.Exists("C:\SETools") Then
                    Try
                        Directory.CreateDirectory("C:\SETools")
                    Catch ex As Exception
                    End Try
                End If
                'Check if the mod extraction directory exists in the C drive & if not then create it
                If Not Directory.Exists(My.Settings.SpaceEngineersWorkingDirectory) Then
                    Try
                        Directory.CreateDirectory(My.Settings.SpaceEngineersWorkingDirectory)
                    Catch ex As Exception
                    End Try
                End If

                'Set default settings
                My.Settings.SpaceEngineersDirectory = "C:\Program Files (x86)\Steam\steamapps\common\Space Engineers"
                My.Settings.SpaceEngineersModsDirectory = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SpaceEngineers\Mods")
                My.Settings.SpaceEngineersBPDirectory = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SpaceEngineers\Blueprints")
                My.Settings.SpaceEngineersWorkingDirectory = "C:\SETools\unpacked_mods"

                My.Settings.IdentifierAplha = 1
                My.Settings.Save()
            Catch ex As Exception
            End Try
        End If

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
        PictureBox1.BackColor = My.Settings.ThemeBackColor

        'Failsafe if user deletes working folders remake them
        Try
            'Check if the app directory exists in the filesystem & if not then create it
            If Not Directory.Exists(My.Settings.SpaceEngineersWorkingDirectory) Then
                Try
                    MessageBox.Show("Failed to locate the application's working directory " + My.Settings.SpaceEngineersWorkingDirectory.ToString() + ", Creating directory now!")
                    Directory.CreateDirectory(My.Settings.SpaceEngineersWorkingDirectory)
                Catch ex As Exception
                    MessageBox.Show("There was an error creating the directory " + My.Settings.SpaceEngineersWorkingDirectory.ToString() + " try restarting the application in administrator mode.")
                End Try
            End If
            'Check if the space engineers game installation directory exists
            If Not Directory.Exists(My.Settings.SpaceEngineersDirectory) Then
                Try
                    MessageBox.Show("Failed to locate Space Engineers game directory at " + My.Settings.SpaceEngineersDirectory.ToString() + ", Creating directory now!")
                    Directory.CreateDirectory(My.Settings.SpaceEngineersDirectory)
                Catch ex As Exception
                    MessageBox.Show("There was an error creating the directory " + My.Settings.SpaceEngineersDirectory.ToString() + " try restarting the application in administrator mode.")
                End Try
            End If
            'Check if the space engineers mod folder exists
            If Not Directory.Exists(My.Settings.SpaceEngineersModsDirectory) Then
                MessageBox.Show("Cannot find the space engineers mod directory " + My.Settings.SpaceEngineersModsDirectory.ToString() + ", Check application settings")
            End If

            If Not Directory.Exists(My.Settings.SpaceEngineersBPDirectory) Then
                MessageBox.Show("Cannot find the space engineers bp directory " + My.Settings.SpaceEngineersBPDirectory.ToString() + ", Check application settings")
            End If
        Catch ex As Exception
        End Try

        'Load Vanilla Block Definitions
        DeserializeCubes()

        'Load modded block definitions
        LoadModDefinitions()
    End Sub
#End Region

#Region "------------=================== Context Menu And Toolbar Event Handlers ===================------------"
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
        PictureBox1.BackColor = My.Settings.ThemeBackColor
    End Sub

    'Context Menu And Status Menu Items
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileFunction()
    End Sub
    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        ResetControlSystems()
    End Sub
    Private Sub SettingsContextMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsContextMenuItem.Click
        Me.Hide()
        Configurator.Show()
    End Sub
    Private Sub UpdateContextMenuBtn_Click(sender As Object, e As EventArgs) Handles UpdateContextMenuBtn.Click
        CheckUpdates(Assembly.GetExecutingAssembly().GetName().Version.ToString())
    End Sub

    Private Sub ModManagerContextMenuBtn_Click(sender As Object, e As EventArgs) Handles ModManagerContextMenuBtn.Click
        'Me.Hide()
        'LocalModManager.Show()
    End Sub
    Private Sub BlueprintManagerContextMenuBtn_Click(sender As Object, e As EventArgs) Handles BlueprintManagerContextMenuBtn.Click
        Me.Hide()
        LocalBlueprintManager.Show()
    End Sub
    Private Sub HelpContextMenuBtn_Click(sender As Object, e As EventArgs) Handles HelpContextMenuBtn.Click
        Me.Hide()
        HelpMenu.Show()
    End Sub
End Class
#End Region
#End Region

#Region "---------------------------===================== XML FUNCTIONS =====================---------------------------"
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
                                                      .position = y.Descendants("Position").Select(Function(z) New Location() With {
                                                        .x = CType(z.Attribute("x"), Double),
                                                        .y = CType(z.Attribute("y"), Double),
                                                        .z = CType(z.Attribute("z"), Double)
                                                      }).FirstOrDefault(),
                                                      .forward = y.Descendants("Forward").Select(Function(z) New Location() With {
                                                        .x = CType(z.Attribute("x"), Double),
                                                        .y = CType(z.Attribute("y"), Double),
                                                        .z = CType(z.Attribute("z"), Double)
                                                      }).FirstOrDefault(),
                                                      .up = y.Descendants("Up").Select(Function(z) New Location() With {
                                                        .x = CType(z.Attribute("x"), Double),
                                                        .y = CType(z.Attribute("y"), Double),
                                                        .z = CType(z.Attribute("z"), Double)
                                                      }).FirstOrDefault(),
                                                      .orientation = y.Descendants("Orientation").Select(Function(z) New Location() With {
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
    Public position As Location
    Public forward As Location
    Public up As Location
    Public orientation As Location
    Public cubeBlocks As List(Of CubeBlock)
    Public displayname As String
    Public SubTypeID As String
    Public ownername As String
    Public enumerator As String
End Class
Public Class Location
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
#End Region