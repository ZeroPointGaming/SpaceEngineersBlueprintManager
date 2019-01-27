Imports System.IO
Imports System.IO.Compression

Public Class LocalBlueprintManager
    Public BPWorkingDirectory = My.Settings.SpaceEngineersWorkingDirectory + "\Blueprints"
    'Set theme colors
    Private Sub LocalBlueprintManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Check if blueprints folder exists for workshop blueprints
        Try
            If Not Directory.Exists(BPWorkingDirectory) Then
                Directory.CreateDirectory(BPWorkingDirectory)
            End If
        Catch ex As Exception
        End Try

        Me.BackColor = My.Settings.ThemeBackColor
        Me.ForeColor = My.Settings.ThemeForeColor
        ListBox1.BackColor = My.Settings.ThemeBackColor
        ListBox2.BackColor = My.Settings.ThemeBackColor
        ListBox1.ForeColor = My.Settings.ThemeForeColor
        ListBox2.ForeColor = My.Settings.ThemeForeColor

        'load local blueprints
        If Directory.Exists(My.Settings.SpaceEngineersBPDirectory + "\Local") Then
            For Each folder In Directory.GetDirectories(My.Settings.SpaceEngineersBPDirectory + "\Local")
                Dim bppath As String = folder + "bp.sbc"
                ListBox1.Items.Add(folder.Split("\").Last.ToString())
            Next
        End If

        'load workshop blueprints
        If Directory.Exists(My.Settings.SpaceEngineersBPDirectory + "\Workshop") Then
            For Each file In Directory.GetFiles(My.Settings.SpaceEngineersBPDirectory + "\Workshop")
                'unzip the bp to workingdir/temp/bpid
                'read info from /bpid/bp.sbc
                'load /bpid/temp.png into a image box for preview
            Next
        End If
    End Sub

    Private Sub LocalBlueprintManager_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Main.Show()
    End Sub
End Class