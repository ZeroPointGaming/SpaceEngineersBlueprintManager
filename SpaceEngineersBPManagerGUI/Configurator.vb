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
        TextBox5.ForeColor = My.Settings.ThemeForeColor
        TextBox5.BackColor = My.Settings.ThemeBackColor
        TextBox6.ForeColor = My.Settings.ThemeForeColor
        TextBox6.BackColor = My.Settings.ThemeBackColor

        TextBox1.Text = My.Settings.SpaceEngineersDirectory
        TextBox2.Text = My.Settings.SpaceEngineersBPDirectory
        TextBox3.Text = My.Settings.SpaceEngineersModsDirectory
        TextBox4.Text = My.Settings.SpaceEngineersWorkingDirectory
        TextBox5.Text = My.Settings.BlockImgWidth
        TextBox6.Text = My.Settings.BlockImgHeight
    End Sub

    'Save Settings Button
    Private Sub SaveSettingsBtn_Click(sender As Object, e As EventArgs) Handles SaveSettingsBtn.Click
        Try
            My.Settings.SpaceEngineersDirectory = TextBox1.Text
        Catch ex As Exception
            MessageBox.Show("Error in Space Engineers Game Directory! Could not save changes. Try restarting the application in administrator mode.")
        End Try
        Try
            My.Settings.SpaceEngineersBPDirectory = TextBox2.Text
        Catch ex As Exception
            MessageBox.Show("Error in space enginers blueprint Directory! Could not save changes. Try restarting the application in administrator mode.")
        End Try
        Try
            My.Settings.SpaceEngineersWorkingDirectory = TextBox4.Text
        Catch ex As Exception
            MessageBox.Show("Error in application working directory! Could not save changes. Try restarting the application in administrator mode.")
        End Try
        Try
            My.Settings.SpaceEngineersModsDirectory = TextBox3.Text
        Catch ex As Exception
            MessageBox.Show("Error in space engineers mod directory! Could not save changes. Try restarting the application in administrator mode.")
        End Try
        Try
            My.Settings.ThemeBackColor = BackColorBtn.BackColor
        Catch ex As Exception
            MessageBox.Show("Error saving text color.")
        End Try
        Try
            My.Settings.ThemeForeColor = BackColorBtn.ForeColor
        Catch ex As Exception
            MessageBox.Show("Error saving back color.")
        End Try
        Try
            My.Settings.BlockImgWidth = TextBox5.Text
        Catch ex As Exception
            MessageBox.Show("Error saving block image width, make sure the value is a number between 1-999.")
        End Try
        Try
            My.Settings.BlockImgHeight = TextBox6.Text
        Catch ex As Exception
            MessageBox.Show("Error saving block image height, make sure the value is a number between 1-999.")
        End Try
        Try
            My.Settings.Save()
        Catch ex As Exception
            MessageBox.Show("There was an error saving the settings file, try running the application as administrator!")
        End Try

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
        TextBox5.ForeColor = My.Settings.ThemeForeColor
        TextBox5.BackColor = My.Settings.ThemeBackColor
        TextBox6.ForeColor = My.Settings.ThemeForeColor
        TextBox6.BackColor = My.Settings.ThemeBackColor
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
        TextBox5.ForeColor = My.Settings.ThemeForeColor
        TextBox5.BackColor = My.Settings.ThemeBackColor
        TextBox6.ForeColor = My.Settings.ThemeForeColor
        TextBox6.BackColor = My.Settings.ThemeBackColor
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
        TextBox5.ForeColor = My.Settings.ThemeForeColor
        TextBox5.BackColor = My.Settings.ThemeBackColor
        TextBox6.ForeColor = My.Settings.ThemeForeColor
        TextBox6.BackColor = My.Settings.ThemeBackColor
    End Sub

    Private Sub Configurator_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Main.Show()
    End Sub
End Class