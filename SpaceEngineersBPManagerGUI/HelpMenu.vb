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
        MetroTextBox1.Text = "To check for a newer version of the application simply right click anywhere on the blueprint viewer form, click tools then click check for updates, this will check your version vs the latest version posted on github. If there is a newer version a dialog will prompt you with a link to download the newest version."
    End Sub

    'Using the user configuration menu
    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        MetroTile1.Text = "Using The User Configuration Menu"
        MetroTextBox1.Text = "Using the configuration menu is pretty simple in this application, simply right click anywhere on the blueprint viewer form and select the settings option to open the configurator. Once opened you can change the 4 different directories the application uses for various tasks. The space engineers mod directory will more often than not be correct in your appdata folder. The space engineers game directory is the directory where steam installed the space engineers game, if you do not have the game installed do not worry about this directory. The games working directory is where the application extracts your mods and saves data to and stores information reguarding non-vanilla aspects of the game. The theme coloring buttons can change the background color and text color of most elements across all forms. And last but not least the block image size boxes depict the dimensions of the visual representations of the blocks that are used in a space engineers blueprint. The default size is 80x80."
    End Sub

    'Using the mod manager
    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        MetroTile1.Text = "Using The Mod Manager"
        MetroTextBox1.Text = "The mod manager is currently unavailable due to developmental issues with the steam api, processing time to load 150 mods took 5 minutes to complete, this will continue to be worked on until the processing time of retrieving the data is < 10 seconds."
    End Sub

    'Using the blueprint manager
    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        MetroTile1.Text = "Using The Blueprint Manager"
        MetroTextBox1.Text = "To use the blueprint manager, right click anywhere on the blueprint viewer, click tools and select the blueprint manager."
    End Sub
End Class