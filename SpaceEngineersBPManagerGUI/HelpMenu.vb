Public Class HelpMenu
    Private Sub HelpMenu_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Main.Show()
    End Sub
End Class