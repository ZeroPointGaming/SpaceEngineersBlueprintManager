Public Class Configurator
    'Reload Form Properties
    Private Sub Configurator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ForeColorBtn.BackColor = My.Settings.ThemeBackColor
        ForeColorBtn.ForeColor = My.Settings.ThemeForeColor
        BackColorBtn.ForeColor = My.Settings.ThemeForeColor
        BackColorBtn.BackColor = My.Settings.ThemeBackColor
        Me.ForeColor = My.Settings.ThemeForeColor
        Me.BackColor = My.Settings.ThemeBackColor
        TextBox1.ForeColor = My.Settings.ThemeForeColor
        TextBox1.BackColor = My.Settings.ThemeBackColor
        TextBox2.ForeColor = My.Settings.ThemeForeColor
        TextBox2.BackColor = My.Settings.ThemeBackColor
        TextBox3.ForeColor = My.Settings.ThemeForeColor
        TextBox3.BackColor = My.Settings.ThemeBackColor
        TextBox4.ForeColor = My.Settings.ThemeForeColor
        TextBox4.BackColor = My.Settings.ThemeBackColor

        TextBox1.Text = My.Settings.SpaceEngineersDirectory
        TextBox2.Text = My.Settings.SpaceEngineersBPDirectory
        TextBox3.Text = My.Settings.SpaceEngineersModsDirectory
        TextBox4.Text = My.Settings.SpaceEngineersWorkingDirectory
    End Sub

    'Save Settings Button
    Private Sub SaveSettingsBtn_Click(sender As Object, e As EventArgs) Handles SaveSettingsBtn.Click
        My.Settings.Save()

        'Update Form Properties
        Me.BackColor = My.Settings.ThemeBackColor
        Me.ForeColor = My.Settings.ThemeForeColor

        'Update Control Properties
        ForeColorBtn.BackColor = My.Settings.ThemeBackColor
        ForeColorBtn.ForeColor = My.Settings.ThemeForeColor
        BackColorBtn.ForeColor = My.Settings.ThemeForeColor
        BackColorBtn.BackColor = My.Settings.ThemeBackColor
        TextBox1.ForeColor = My.Settings.ThemeForeColor
        TextBox1.BackColor = My.Settings.ThemeBackColor
        TextBox2.ForeColor = My.Settings.ThemeForeColor
        TextBox2.BackColor = My.Settings.ThemeBackColor
        TextBox3.ForeColor = My.Settings.ThemeForeColor
        TextBox3.BackColor = My.Settings.ThemeBackColor
        TextBox4.ForeColor = My.Settings.ThemeForeColor
        TextBox4.BackColor = My.Settings.ThemeBackColor
    End Sub

    'Fore Color
    Private Sub ForeColorBtn_Click(sender As Object, e As EventArgs) Handles ForeColorBtn.Click
        ColorDialog1.ShowDialog()
        My.Settings.ThemeForeColor = ColorDialog1.Color
        ForeColorBtn.BackColor = My.Settings.ThemeBackColor
        ForeColorBtn.ForeColor = My.Settings.ThemeForeColor
        BackColorBtn.ForeColor = My.Settings.ThemeForeColor
        BackColorBtn.BackColor = My.Settings.ThemeBackColor
        Me.ForeColor = My.Settings.ThemeForeColor
        Me.BackColor = My.Settings.ThemeBackColor
        TextBox1.ForeColor = My.Settings.ThemeForeColor
        TextBox1.BackColor = My.Settings.ThemeBackColor
        TextBox2.ForeColor = My.Settings.ThemeForeColor
        TextBox2.BackColor = My.Settings.ThemeBackColor
        TextBox3.ForeColor = My.Settings.ThemeForeColor
        TextBox3.BackColor = My.Settings.ThemeBackColor
        TextBox4.ForeColor = My.Settings.ThemeForeColor
        TextBox4.BackColor = My.Settings.ThemeBackColor
    End Sub

    'Back Color
    Private Sub BackColorBtn_Click(sender As Object, e As EventArgs) Handles BackColorBtn.Click
        ColorDialog1.ShowDialog()
        My.Settings.ThemeBackColor = ColorDialog1.Color
        ForeColorBtn.BackColor = My.Settings.ThemeBackColor
        ForeColorBtn.ForeColor = My.Settings.ThemeForeColor
        BackColorBtn.ForeColor = My.Settings.ThemeForeColor
        BackColorBtn.BackColor = My.Settings.ThemeBackColor
        Me.ForeColor = My.Settings.ThemeForeColor
        Me.BackColor = My.Settings.ThemeBackColor
        TextBox1.ForeColor = My.Settings.ThemeForeColor
        TextBox1.BackColor = My.Settings.ThemeBackColor
        TextBox2.ForeColor = My.Settings.ThemeForeColor
        TextBox2.BackColor = My.Settings.ThemeBackColor
        TextBox3.ForeColor = My.Settings.ThemeForeColor
        TextBox3.BackColor = My.Settings.ThemeBackColor
        TextBox4.ForeColor = My.Settings.ThemeForeColor
        TextBox4.BackColor = My.Settings.ThemeBackColor
    End Sub

    Private Sub Configurator_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Main.Show()
    End Sub
End Class