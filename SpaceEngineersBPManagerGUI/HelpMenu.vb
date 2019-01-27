Public Class HelpMenu
    Private Sub HelpMenu_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Main.Show()
    End Sub

    'How to load a blueprint
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        MetroTile1.Text = "How To Load Blueprints"
        MetroTextBox1.Text = "Loading blueprints can be achieved by right clicking anywhere on the main form and select the open function. Navigate to a folder containing a space engineers blueprint file (BLUEPRINT.sbc), workshop blueprint sbm files are currently unsupported. The program will then read the information from the blieprint file and display it in the gui of the application."
    End Sub

    'Checking for application updates
    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        MetroTile1.Text = "Checking For Application Updates"
        MetroTextBox1.Text = ""
    End Sub

    'Using the user configuration menu
    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        MetroTile1.Text = "Using The User Configuration Menu"
        MetroTextBox1.Text = ""
    End Sub

    'Using the mod manager
    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        MetroTile1.Text = "Using The Mod Manager"
        MetroTextBox1.Text = ""
    End Sub

    'Using the blueprint manager
    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        MetroTile1.Text = "Using The Blueprint Manager"
        MetroTextBox1.Text = ""
    End Sub
End Class