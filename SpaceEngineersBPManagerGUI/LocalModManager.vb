Public Class LocalModManager
    'Set theme colors
    Private Sub LocalModManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = My.Settings.ThemeBackColor
        Me.ForeColor = My.Settings.ThemeForeColor
    End Sub


End Class