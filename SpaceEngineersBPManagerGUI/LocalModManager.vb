Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Xml.Serialization

Public Class LocalModManager
    Public ModInfoDictonary As New Dictionary(Of String, ModData)

#Region "------------=================== Main Functions ===================------------"
    Dim appData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Dim sepath As String = appData + "\SpaceEngineers\Mods"
    Dim extractto As String = My.Settings.SpaceEngineersWorkingDirectory + "\Temp"

    Function UnpackMod(mods As String, Optional destPath As String = "") 'Unpack all the space engineers mods from %AppData%\Roaming\SpaceEngineers\Mods and to a folder in the root directory of the C drive
        'If attempting to unzip an invalid path return nothing
        'If Not Directory.Exists(mods + ".sbm") Then Return Nothing

        'Check if the temp folder exists in the working diretory
        If Not Directory.Exists(extractto) Then
            Directory.CreateDirectory(extractto)
        End If

        'Attempt to retrieve mod information froms steam workshop
        Dim ModInfo As New ModData()
        Dim ModID As String = (mods.Split("\").Last).TrimEnd(".", "s", "b", "m")
        ModInfo = FetchModInfo(ModID)

        'Try to create a folder in the temp folder with the name of the mod retrieved from steam workshop
        Try
            Directory.CreateDirectory(extractto + "\" + ModInfo.ModName)
        Catch ex As Exception
            MessageBox.Show("Unable to connect to the steam workshop!")
        End Try

        'Finally extract the mod for processing of its data.
        Try
            MessageBox.Show(extractto + "\" + ModInfo.ModName, destPath)
            ZipFile.ExtractToDirectory(extractto + "\" + ModInfo.ModName, destPath)
        Catch ex As Exception
            'MessageBox.Show(ex.ToString())
        End Try

        Return ModInfo
    End Function

    Public Function CreateDocument(ByVal url As String) As HtmlDocument
        Dim wb As New WebBrowser()
        wb.ScriptErrorsSuppressed = True
        wb.DocumentText = New WebClient().DownloadString(url)
        Return wb.Document
    End Function

    Function FetchModInfo(ModId As String)
        Dim modinfo As New ModData()

        Dim steam_workshop As String = "https://steamcommunity.com/sharedfiles/filedetails/?id=" + ModId

        Dim mod_name As String = ""
        Dim mod_author As String = ""

        Try
            Dim Steam_Page As HtmlDocument = CreateDocument(steam_workshop)

            Dim PageElement As HtmlElementCollection = Steam_Page.GetElementsByTagName("div")
            For Each CurElement As HtmlElement In PageElement
                If (CurElement.GetAttribute("className") = "workshopItemTitle") Then
                    mod_name = CurElement.InnerText
                    MessageBox.Show(mod_name.ToString())
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        modinfo.ModDat(mod_name, mod_author)

        Return modinfo
    End Function
#End Region

    'Set theme colors
    Private Sub LocalModManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = My.Settings.ThemeBackColor
        Me.ForeColor = My.Settings.ThemeForeColor

        'Open all mods into the listbox
        Dim modpath As String = My.Settings.SpaceEngineersModsDirectory
        Dim id As Integer = 0
        Dim Cleaner As New XMLCleaner()

        For Each File In Directory.GetFiles(modpath)
            Dim modname As String = File.Split("\").Last.ToString()
            Dim modinfo As New ModData()
            modinfo = UnpackMod(File)

            Try
                ModInfoDictonary.Add(modinfo.ModName, modinfo)
            Catch ex As Exception
                'error adding mod data to the system.
                MessageBox.Show(ex.ToString)
            End Try

            ListBox1.Items.Add(modname.ToString())
            id += 1
        Next
    End Sub

    Private Sub LocalModManager_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Main.Show()
    End Sub

    'Open informaiton reguarding the selected mod
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            Dim modinfo As New ModData()
            modinfo = UnpackMod(My.Settings.SpaceEngineersModsDirectory + "\" + ListBox1.SelectedItem.ToString().TrimEnd(".", "s", "b", "m"))
            MessageBox.Show(My.Settings.SpaceEngineersModsDirectory + "\" + ListBox1.SelectedItem.ToString().TrimEnd(".", "s", "b", "m"))
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class

'Structural class to store the mod information from the steam work shop
Public Class ModData
    Public ModName As String
    Public ModAuthor As String

    Public Sub ModDat(mod_name As String, mod_auth As String)
        ModName = mod_name
        ModAuthor = mod_auth
    End Sub
End Class