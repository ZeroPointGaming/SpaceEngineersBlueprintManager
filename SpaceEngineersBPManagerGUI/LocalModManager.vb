Imports System.ComponentModel
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Xml.Serialization

Public Class LocalModManager
    Public ModInfoDictonary As New Dictionary(Of String, ModData)
    Dim appData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Dim sepath As String = appData + "\SpaceEngineers\Mods"
    Dim extractto As String = My.Settings.SpaceEngineersWorkingDirectory + "\Temp"

    'Background worker to handle extraneious processies
    Public WithEvents BGProcess As New BackgroundWorker
    Public cur_id As String
    Public cur_mod As New ModData()
    Private Sub BGProcess_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BGProcess.DoWork
        cur_mod = FetchModInfo(cur_id)

        Dim modinfo As New ModData()
        Dim mod_name As String = ""
        Dim mod_author As String = ""
        Dim mod_description As String = ""
        Dim steam_workshop As String = ("https://steamcommunity.com/sharedfiles/filedetails/?id=" + cur_id) 'Working as intended

        Dim wb As New WebBrowser With {
            .ScriptErrorsSuppressed = True
        }

        wb.Navigate(steam_workshop)

        Do Until wb.ReadyState = WebBrowserReadyState.Complete
            'Application.DoEvents()
        Loop

        Steam_Page = wb.Document

        Dim PageElement As HtmlElementCollection = Steam_Page.Window.Document.GetElementsByTagName("div")
        For Each CurElement As HtmlElement In PageElement
            If (CurElement.GetAttribute("className") = "workshopItemTitle") Then
                mod_name = CurElement.InnerText
            End If

            If (CurElement.GetAttribute("className") = "friendBlockContent") Then
                mod_author = CurElement.InnerText
            End If

            If (CurElement.GetAttribute("className") = "workshopItemDescription") Then
                mod_description = CurElement.InnerText
            End If
        Next

        modinfo.ModDat(mod_name, mod_author, mod_description)
        cur_mod = modinfo
    End Sub

    'Set theme colors
    Private Sub LocalModManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = My.Settings.ThemeBackColor
        Me.ForeColor = My.Settings.ThemeForeColor

        'Open all mods into the listbox
        Dim modpath As String = My.Settings.SpaceEngineersModsDirectory
        Dim Cleaner As New XMLCleaner()

        For Each File In Directory.GetFiles(modpath)
            Dim modname As String = File.Split("\").LastOrDefault
            cur_id = File.Split("\").Last.ToString().TrimEnd(".", "s", "b", "m")

            BGProcess.RunWorkerAsync()
            BGProcess.WorkerReportsProgress = True

            Dim progress = Nothing
            Do Until progress = 100
                BGProcess.ReportProgress(progress)
            Loop

            Try
                ModInfoDictonary.Add(modname, cur_mod)
            Catch ex As Exception
                'error adding mod data to the system.
                MessageBox.Show(ex.ToString)
            End Try

            ListBox1.Items.Add(modname.ToString())
        Next
    End Sub

#Region "------------=================== Main Functions ===================------------"
    Public Function CreateDocument(ByVal url As String) As HtmlDocument
        Dim wb As New WebBrowser With {
            .ScriptErrorsSuppressed = True,
            .DocumentText = New WebClient().DownloadString(url)
        }

        Do Until wb.ReadyState = WebBrowserReadyState.Complete
            Application.DoEvents()
        Loop

        Return wb.Document
        wb.Dispose()
    End Function

    Public Steam_Page As HtmlDocument
    Function FetchModInfo(ModId As String)

    End Function
#End Region

    Private Sub LocalModManager_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Main.Show()
    End Sub

    'Open informaiton reguarding the selected mod
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            Dim modinfo As New ModData()
            'modinfo = UnpackMod(My.Settings.SpaceEngineersModsDirectory + "\" + ListBox1.SelectedItem.ToString().TrimEnd(".", "s", "b", "m"))
        Catch ex As Exception
        End Try
    End Sub
End Class

'Structural class to store the mod information from the steam work shop
Public Class ModData
    Public ModName As String
    Public ModAuthor As String
    Public ModDescription As String

    Public Sub ModDat(mod_name As String, mod_auth As String, mod_desc As String)
        ModName = mod_name
        ModAuthor = mod_auth
        ModDescription = mod_desc
    End Sub
End Class