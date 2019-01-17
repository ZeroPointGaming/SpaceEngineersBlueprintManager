Public Class LocalBlueprintManager
    'Set theme colors
    Private Sub LocalBlueprintManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = My.Settings.ThemeBackColor
        Me.ForeColor = My.Settings.ThemeForeColor
    End Sub


End Class