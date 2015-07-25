Imports DevComponents.DotNetBar
Public Class MainBotSettingsForm

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        My.Settings.Subscribe = TextBoxX1.Text
        My.Settings.Comment = TextBoxX2.Text
        My.Settings.Like1 = TextBoxX3.Text
        My.Settings.Favourite = TextBoxX4.Text
        My.Settings.Flag = TextBoxX5.Text
        My.Settings.Navigate = TextBoxX6.Text
        My.Settings.Sign_In = TextBoxX7.Text
        MessageBoxEx.Show("The changes have been saved!", "Updated Values!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        TextBoxX1.Clear()
        TextBoxX1.Text = "4000"
        TextBoxX2.Clear()
        TextBoxX2.Text = "4000"
        TextBoxX3.Clear()
        TextBoxX3.Text = "4000"
        TextBoxX4.Clear()
        TextBoxX4.Text = "4000"
        TextBoxX5.Clear()
        TextBoxX5.Text = "4000"
        TextBoxX6.Clear()
        TextBoxX6.Text = "2000"
        TextBoxX7.Clear()
        TextBoxX7.Text = "4000"
        If MessageBoxEx.Show("Would you like to save the default values?", "Save Values?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            ButtonX2.PerformClick()
        End If
    End Sub

    Private Sub MainBotSettingsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBoxX1.Text = My.Settings.Subscribe
        TextBoxX2.Text = My.Settings.Comment
        TextBoxX3.Text = My.Settings.Like1
        TextBoxX4.Text = My.Settings.Favourite
        TextBoxX5.Text = My.Settings.Flag
        TextBoxX6.Text = My.Settings.Navigate
        TextBoxX7.Text = My.Settings.Sign_In
    End Sub
End Class