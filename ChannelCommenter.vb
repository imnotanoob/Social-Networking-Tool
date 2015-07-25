Public Class ChannelCommenter
    Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32
    Const WM_CLOSE = &H10
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Int32
    Dim youtube As String = "http://www.youtube.com"
#Region "Clear Browser data"
    Public Sub Clear_Cookies()
        Try
            Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 2", AppWinStyle.Hide)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Clear_History()
        Try
            Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 1", AppWinStyle.Hide)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Clear_Form_Data()
        Try
            Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 16", AppWinStyle.Hide)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Clear_Temp_Files()
        Try
            Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 8 ", AppWinStyle.Hide)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Clear_Saved_Passwords()
        Try
            Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 32", AppWinStyle.Hide)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Clear_All()
        Try
            Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 255", AppWinStyle.Hide)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Clear_Clear_Add_ons_Settings()
        Try
            Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 4351", AppWinStyle.Hide)
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Timers"
    Private Sub VideoNav_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VideoNav.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            WebBrowser1.Navigate("http://www.youtube.com/user/" + ListBox1.SelectedItem)
            CommentTimer.Start()
            VideoNav.Stop()
        End If
    End Sub
    Private Sub SigninTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SigninTimer.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            If WebBrowser1.Document.Body.OuterText.Contains("Sign in to YouTube") Then
                Try
                    Dim str() As String = Split(TextBoxX1.Text, ":")
                    WebBrowser1.Document.GetElementById("Email").SetAttribute("value", str(0))
                    WebBrowser1.Document.GetElementById("Passwd").SetAttribute("value", str(1))
                    Dim allelements As HtmlElementCollection = WebBrowser1.Document.All
                    For Each webpageelement1 As HtmlElement In allelements
                        If webpageelement1.GetAttribute("type") = "submit" Then
                            webpageelement1.InvokeMember("click")
                        End If
                    Next
                Catch ex As Exception
                End Try
            Else
                SignIn()
            End If
        End If
    End Sub
    Private Sub SignoutTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignoutTimer.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            WebBrowser1.Navigate("javascript:document.logoutForm.submit();")
            SignoutTimer.Stop()
            SigninTimer.Start()
        End If
    End Sub
    Private Sub looptimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles looptimer.Tick
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            If ListBox1.SelectedIndex = ListBox1.Items.Count - 1 Then
                WebBrowser1.Navigate("https://www.google.com/accounts/ServiceLogin?uilel=3&service=youtube&passive=true")
                Try
                    ListBox1.SelectedIndex = 0
                Catch ex As Exception
                End Try
                frstSignOut.Start()
                Clear_History()
                Clear_Cookies()
                looptimer.Stop()
            Else
                Try
                    ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
                Catch ex As Exception
                End Try
                SignoutTimer.Start()
                looptimer.Stop()
            End If
        End If
    End Sub
    Private Sub frstSignOut_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frstSignOut.Tick
        WebBrowser1.Navigate(youtube)
        WebBrowser1.Navigate("javascript:document.logoutForm.submit();")
        WebBrowser1.Navigate("https://www.google.com/accounts/ServiceLogin?uilel=3&service=youtube&passive=true")
        frstSignOut.Stop()
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        ListBox2.Items.Remove(ListBox1.SelectedItem)
        Label1.Text = "Current User(s):" & ListBox1.Items.Count
        Label2.Text = "Current Comment(s):" & ListBox1.Items.Count
    End Sub
    Private Sub fix_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fix.Tick
        Dim MyMessage As Int32
        Static Count As Int16
        MyMessage = FindWindow(Nothing, "Message from webpage")
        If Count < 5 Then
            Count = Count + 1
        Else
            If MyMessage <> 0 Then PostMessage(MyMessage, WM_CLOSE, 0, 0)
        End If
    End Sub
    Private Sub CommentTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentTimer.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            comment()
            looptimer.Start()
            CommentTimer.Stop()
        End If
    End Sub
    Private Sub count_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles count.Tick
        Label1.Text = "Current User(s): " & ListBox1.Items.Count()
        Label2.Text = "Current Comment(s):" & ListBox2.Items.Count
    End Sub
#End Region
#Region "Users"
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Dim asd As New OpenFileDialog
        asd.Filter = ("Text Files|*.txt")
        If asd.ShowDialog And Windows.Forms.DialogResult.OK Then
            Dim streamread As New IO.StreamReader(asd.FileName)
            While (streamread.Peek() > -1)
                ListBox1.Items.Add(streamread.ReadLine)
            End While
            streamread.Close()
        End If
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        ListBox1.Items.Add(TextBoxX2.Text)
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        ListBox1.Items.Clear()
    End Sub
#End Region
#Region "Comments"
    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        Dim asd As New OpenFileDialog
        asd.Filter = ("Text Files|*.txt")
        If asd.ShowDialog And Windows.Forms.DialogResult.OK Then
            Dim streamread As New IO.StreamReader(asd.FileName)
            While (streamread.Peek() > -1)
                ListBox2.Items.Add(streamread.ReadLine)
            End While
            streamread.Close()
        End If
    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        ListBox2.Items.Clear()
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        ListBox2.Items.Add(TextBoxX3.Text)
    End Sub
#End Region
#Region "Functions"
    Private Sub SignIn()
        WebBrowser1.Navigate("https://www.google.com/accounts/ServiceLogin?uilel=3&service=youtube&passive=true")
        Try
            Dim asd As HtmlElementCollection = WebBrowser1.Document.All
            For Each Element As HtmlElement In asd
                Dim str() As String = Split(ListBox1.SelectedItem.ToString(), ":")
                WebBrowser1.Document.GetElementById("Email").SetAttribute("value", str(0))
                WebBrowser1.Document.GetElementById("Passwd").SetAttribute("value", str(1))
                If Element.GetAttribute("type") = "submit" Then
                    Element.InvokeMember("click")
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub comment()
        Try
            WebBrowser1.Document.All.GetElementsByName("comment")(0).SetAttribute("value", ListBox2.SelectedItem.ToString)
            Dim col As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("button")
            For Each elem As HtmlElement In col
                If elem.GetAttribute("innerText").Contains("Post Comment") Then
                    elem.InvokeMember("click")
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ButtonX8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX8.Click
        SigninTimer.Stop()
        SignoutTimer.Stop()
        frstSignOut.Stop()
        CommentTimer.Stop()
        fix.Stop()
        looptimer.Stop()
    End Sub
    Private Sub ButtonX7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX7.Click
        If ListBox1.Items.Count = 0 Then
        End If
        Try
            ListBox1.SelectedIndex = 0
        Catch ex As Exception
        End Try
        SigninTimer.Start()
    End Sub
#End Region

    Private Sub ChannelCommenter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fix.Start()
        frstSignOut.Start()
        count.Start()
    End Sub
End Class