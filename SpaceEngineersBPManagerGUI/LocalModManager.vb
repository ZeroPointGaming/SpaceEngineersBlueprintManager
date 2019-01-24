Imports System.IO
Imports System.Xml.Serialization

Public Class LocalModManager
    'Set theme colors
    Private Sub LocalModManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = My.Settings.ThemeBackColor
        Me.ForeColor = My.Settings.ThemeForeColor

        'Open all mods into the listbox
        Dim modpath As String = My.Settings.SpaceEngineersWorkingDirectory
        Dim id As Integer = 0
        Dim Cleaner As New XMLCleaner()

        For Each folder In Directory.GetDirectories(modpath)
            Dim modname As String = ""
            Dim modauthor As String = ""


            ListBox1.Items.Add(id + " | " + modname)
            id += 1
        Next
    End Sub

    Private Sub LocalModManager_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Main.Show()
    End Sub

    'Open informaiton reguarding the selected mod
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class