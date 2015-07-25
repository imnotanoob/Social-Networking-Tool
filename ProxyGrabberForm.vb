Imports DevComponents.DotNetBar
Imports System.Net
Imports System.Text.RegularExpressions


Public Class ProxyGrabberForm
    Private Server As String
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        If RadioButton1.Checked = True Then
            Server = "http://www.digitalcybersoft.com/ProxyList/fresh-proxy-list.shtml"
        ElseIf RadioButton2.Checked = True Then
            Server = "http://aliveproxy.com/us-proxy-list/"
        ElseIf RadioButton3.Checked = True Then
            Server = "http://proxy-ip-list.com/"
        Else
            If TextBoxX1.Text = "" Then
                MessageBoxEx.Show("Invalid URL", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Server = TextBoxX1.Text
            End If
        End If
        Try
            Dim enumerator As IEnumerator
            Try
                enumerator = Regex.Matches(New WebClient().DownloadString(Server), "\d{1,4}\.\d{1,4}\.\d{1,4}\.\d{1,4}\:\d{2,5}").GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As Match = DirectCast(enumerator.Current, Match)
                    Me.ListBox1.Items.Add(current)
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        Catch exception1 As Exception

        End Try

    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        Dim FileNumber As Integer = FreeFile()
        FileOpen(FileNumber, "Proxy List.txt", OpenMode.Output)
        For Each Item As Object In ListBox1.Items
            PrintLine(FileNumber, Item.ToString)
        Next
        FileClose(FileNumber)
        MessageBoxEx.Show("Proxy list was saved. It can be found in the same folder as the bot..", "Proxy List", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            TextBoxX1.Enabled = True
        Else
            TextBoxX1.Enabled = False
        End If
    End Sub
End Class