Public Class Configurator

    'Save Settings Button
    Private Sub SaveSettingsBtn_Click(sender As Object, e As EventArgs) Handles SaveSettingsBtn.Click
        My.Settings.Save()
    End Sub
End Class