Imports DevComponents.DotNetBar

Public Class CommentGrabberForm
    Public Sub scrapecomments()
        Try
            Dim theelementcollection As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("div")
            For Each curElement2 As HtmlElement In theelementcollection
                If curElement2.GetAttribute("dir").Contains("ltr") Then
                    ListBox1.Items.Add(curElement2.InnerText)
                End If
            Next
        Catch
        End Try
        ListBox1.Items.Remove(" BrowseUpload Create AccountSign In Search")
    End Sub

    Public Sub removedups()
        Dim i, j As Integer
        Dim Arr As New ArrayList
        Dim ItemFound As Boolean
        For i = 0 To ListBox1.Items.Count - 1
            ItemFound = False
            For j = 0 To i - 1
                If ListBox1.Items.Item(i) = ListBox1.Items.Item(j) Then
                    ItemFound = True
                    Exit For
                End If
            Next j
            If Not ItemFound Then
                Arr.Add(ListBox1.Items.Item(i))
            End If
        Next i
        ListBox1.Items.Clear()
        ListBox1.Items.AddRange(Arr.ToArray)
        Arr = Nothing
    End Sub
    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        WebBrowser1.Navigate(TextBoxX1.Text)
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            scrapecomments()
            removedups()
        End If
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        Dim FileNumber As Integer = FreeFile()
        FileOpen(FileNumber, "Comments1.txt", OpenMode.Output)
        For Each Item As Object In ListBox1.Items
            PrintLine(FileNumber, Item.ToString)
        Next
        FileClose(FileNumber)
        MessageBoxEx.Show("Accounts Will Be Saved In The Same Spot Where You Have Youtube Bot!", "Comments Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class