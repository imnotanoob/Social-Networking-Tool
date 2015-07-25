Imports System.Net.CookieCollection
Imports System.Net.CookieContainer
Imports System.Net.Cookie
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Management
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Class MainBotForm

    <Runtime.InteropServices.DllImport("wininet.dll", SetLastError:=True)>
    Private Shared Function InternetSetOption(ByVal hInternet As IntPtr, ByVal dwOption As Integer, ByVal lpBuffer As IntPtr, ByVal lpdwBufferLength As Integer) As Boolean
    End Function
    Public Structure Struct_INTERNET_PROXY_INFO
        Public dwAccessType As Integer
        Public proxy As IntPtr
        Public proxyBypass As IntPtr
    End Structure
    Private Sub RefreshIESettings(ByVal strProxy As String)
        Const INTERNET_OPTION_PROXY As Integer = 38
        Const INTERNET_OPEN_TYPE_PROXY As Integer = 3
        Dim struct_IPI As Struct_INTERNET_PROXY_INFO
        ' Filling in structure                
        struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY
        struct_IPI.proxy = Marshal.StringToHGlobalAnsi(strProxy)
        struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local")
        ' Allocating memory                
        Dim intptrStruct As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI))
        ' Converting structure to IntPtr             
        Marshal.StructureToPtr(struct_IPI, intptrStruct, True)
        Dim iReturn As Boolean = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, System.Runtime.InteropServices.Marshal.SizeOf(struct_IPI))
    End Sub
    Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32
    Const WM_CLOSE = &H10
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Int32
    Dim youtube As String = "http://www.youtube.com"
    Dim proxycounter As Integer

#Region "Account Group Box"
    'Add Account
    Private Sub ButtonX9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX9.Click
        ListBox1.Items.Add(TextBoxX2.Text)
        Label1.Text = "Current Account(s): " & ListBox1.Items.Count
    End Sub
    'Clear Accounts
    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        ListBox1.Items.Clear()
        Label1.Text = "Current Account(s): " & ListBox1.Items.Count
    End Sub
    'Import Accounts
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Try
            Dim asd As New OpenFileDialog
            asd.Filter = ("Text Files|*.txt")
            asd.ShowDialog()
            Dim streamread As New IO.StreamReader(asd.FileName)
            While (streamread.Peek() > -1)
                ListBox1.Items.Add(streamread.ReadLine)
            End While
            streamread.Close()

        Catch ex As Exception
        End Try
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
        Label1.Text = "Current Account(s): " & ListBox1.Items.Count
    End Sub


#End Region

#Region "Comment Group Box"
    'Add Comment
    Private Sub ButtonX8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX8.Click
        ListBox2.Items.Add(TextBoxX3.Text)
        Label2.Text = "Current Comment(s): " & ListBox2.Items.Count
    End Sub
    'Import Comments
    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        Try
            Dim asd As New OpenFileDialog
            asd.Filter = ("Text Files|*.txt")
            asd.ShowDialog()
            Dim streamread As New IO.StreamReader(asd.FileName)
            While (streamread.Peek() > -1)
                ListBox2.Items.Add(streamread.ReadLine)
            End While
            streamread.Close()

        Catch ex As Exception
        End Try
        Dim i, j As Integer
        Dim Arr As New ArrayList
        Dim ItemFound As Boolean
        For i = 0 To ListBox2.Items.Count - 1
            ItemFound = False
            For j = 0 To i - 1
                If ListBox2.Items.Item(i) = ListBox2.Items.Item(j) Then
                    ItemFound = True
                    Exit For
                End If
            Next j
            If Not ItemFound Then
                Arr.Add(ListBox2.Items.Item(i))
            End If
        Next i
        ListBox2.Items.Clear()
        ListBox2.Items.AddRange(Arr.ToArray)
        Arr = Nothing
        Label2.Text = "Current Comment(s): " & ListBox2.Items.Count
    End Sub
    'Clear Comments
    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        ListBox2.Items.Clear()
        Label2.Text = "Current Comment(s): " & ListBox2.Items.Count
    End Sub

#End Region

#Region "Like/Dislike/Flag/UnSub"
    'Dislike
    Private Sub CheckBoxX4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxX4.CheckedChanged
        If CheckBoxX4.Checked Then
            CheckBoxX3.Enabled = False
        Else
            CheckBoxX3.Enabled = True
        End If
    End Sub
    'Like
    Private Sub CheckBoxX3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxX3.CheckedChanged
        If CheckBoxX3.Checked Then
            CheckBoxX4.Enabled = False
        Else
            CheckBoxX4.Enabled = True
        End If
    End Sub
    'Flag
    Private Sub CheckBoxX7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxX6.CheckedChanged
        If CheckBoxX6.Checked Then
            ComboBox1.Enabled = True
        Else
            ComboBox1.Enabled = False
        End If
    End Sub
    'Unsubscribe
    Private Sub CheckBoxX6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxX7.CheckedChanged
        If CheckBoxX6.Checked Then
            MsgBox("Please Enter A Profile URL Not A Video URL", MsgBoxStyle.Information, "Helper")
            CheckBoxX1.Enabled = False
            CheckBoxX2.Enabled = False
            CheckBoxX3.Enabled = False
            CheckBoxX4.Enabled = False
            CheckBoxX5.Enabled = False
            CheckBoxX7.Enabled = False
        Else
            CheckBoxX1.Enabled = True
            CheckBoxX2.Enabled = True
            CheckBoxX3.Enabled = True
            CheckBoxX4.Enabled = True
            CheckBoxX5.Enabled = True
            CheckBoxX7.Enabled = True
        End If
    End Sub
#End Region

#Region " page functions - like dislike comment subscribe favorite Flag Un-Subscribe"
    Private Sub SignIn()
        WebBrowser1.Navigate("https://www.google.com/accounts/ServiceLogin?uilel=3&service=youtube&passive=true")
        Try
            Dim str() As String = Split(ListBox1.SelectedItem.ToString(), ":")
            WebBrowser1.Document.GetElementById("Email").SetAttribute("value", str(0))
            WebBrowser1.Document.GetElementById("Passwd").SetAttribute("value", str(1))
            WebBrowser1.Navigate("javascript:document.forms[1].submit();void(0);")
        Catch ex As Exception
        End Try
    End Sub
    Public Function RandomNumber(ByVal MaxNumber As Integer, Optional ByVal MinNumber As Integer = 0) As Integer
        Dim r As New Random(System.DateTime.Now.Millisecond)
        If MinNumber > MaxNumber Then
            Dim t As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = t
        End If
        Return r.Next(MinNumber, MaxNumber)
    End Function
    Private Sub unsubscribe1()
        Try
            Dim col As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("span")
            For Each elem As HtmlElement In col
                If elem.GetAttribute("innerText").Contains("Subscribed") Then
                    elem.InvokeMember("click")
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub unsubscribe2()
        Try
            Dim col As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("span")
            For Each elem As HtmlElement In col
                If elem.GetAttribute("innerText").Contains("Unsubscribe") Then
                    elem.InvokeMember("click")
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SubscribeButton()
        Try
            Dim col As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("button")
            For Each elem As HtmlElement In col
                If elem.GetAttribute("innerText").Contains("Subscribe") Then
                    elem.InvokeMember("click")
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub VideoLike()
        Try
            WebBrowser1.Document.GetElementById("watch-like").InvokeMember("click")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub VideoUnLike()
        Try
            WebBrowser1.Document.GetElementById("watch-unlike").InvokeMember("click")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Comment()
        Try
            WebBrowser1.Document.All.GetElementsByName("comment")(0).SetAttribute("value", ListBox2.SelectedItem.ToString)
            Dim col As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("button")
            For Each elem As HtmlElement In col
                If elem.GetAttribute("innerText").Contains("Post") Then
                    elem.InvokeMember("click")
                End If
            Next
        Catch ex As Exception
        End Try
        ListBox2.Items.Remove(ListBox2.SelectedItem)
    End Sub
    Public Sub Drop_down_fav_button()
        Dim theElementCollection As HtmlElementCollection
        theElementCollection = WebBrowser1.Document.GetElementsByTagName("button")
        For Each curElement2 As HtmlElement In theElementCollection
            If curElement2.GetAttribute("title").Equals("Add to favorites or playlist") Then
                curElement2.InvokeMember("click")
            End If
        Next
        Try
            Dim col As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("span")
            For Each elem As HtmlElement In col
                If elem.GetAttribute("innerText").Contains("Favorites") Then
                    elem.InvokeMember("click")
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Public Sub flagdropdown()
        Dim theelementcollection As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("button")
        For Each curElement1 As HtmlElement In theelementcollection
            If curElement1.GetAttribute("id").Contains("watch-flag") Then
                curElement1.InvokeMember("click")
            End If
        Next
    End Sub
    Private Sub flagreason()
        ' Dim theelementcollection1 As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("a")
        ' For Each curElement3 As HtmlElement In theelementcollection1
        'If curElement3.GetAttribute("id").Equals("sp") Then
        'curElement3.InvokeMember("click")
        ' End If
        'Next
        If ComboBox1.Text = "Sexual Content" Then
            Dim theelementcollection1 As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("a")
            For Each curElement3 As HtmlElement In theelementcollection1
                If curElement3.GetAttribute("id").Equals("sc") Then
                    curElement3.InvokeMember("click")
                End If
            Next
        Else
            If ComboBox1.Text = "Violent or Repulsive Content" Then
                Dim theelementcollection1 As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("a")
                For Each curElement3 As HtmlElement In theelementcollection1
                    If curElement3.GetAttribute("id").Equals("vc") Then
                        curElement3.InvokeMember("click")
                    End If
                Next
            Else
                If ComboBox1.Text = "Hateful or Abusive Content" Then
                    Dim theelementcollection1 As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("a")
                    For Each curElement3 As HtmlElement In theelementcollection1
                        If curElement3.GetAttribute("id").Equals("hc") Then
                            curElement3.InvokeMember("click")
                        End If
                    Next
                Else
                    If ComboBox1.Text = "Harmful Dangerous Acts" Then
                        Dim theelementcollection1 As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("a")
                        For Each curElement3 As HtmlElement In theelementcollection1
                            If curElement3.GetAttribute("id").Equals("da") Then
                                curElement3.InvokeMember("click")
                            End If
                        Next
                    Else
                        If ComboBox1.Text = "Child Abuse" Then
                            Dim theelementcollection1 As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("a")
                            For Each curElement3 As HtmlElement In theelementcollection1
                                If curElement3.GetAttribute("id").Equals("ca") Then
                                    curElement3.InvokeMember("click")
                                End If
                            Next
                        Else
                            If ComboBox1.Text = "Spam" Then
                                Dim theelementcollection1 As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("a")
                                For Each curElement3 As HtmlElement In theelementcollection1
                                    If curElement3.GetAttribute("id").Equals("sp") Then
                                        curElement3.InvokeMember("click")
                                    End If
                                Next
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub flagthisvideo()
        Dim theelementcollection9 As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("button")
        For Each curElement2 As HtmlElement In theelementcollection9
            If curElement2.GetAttribute("id").Equals("watch-flag-button") Then

                curElement2.InvokeMember("click")
            End If
        Next
    End Sub
    Public Function GetNews(ByVal xmlUrl As String) As String
        Try
            Dim NewsBuilder As New System.Text.StringBuilder
            Dim NewsFeed As XDocument = XDocument.Load(xmlUrl)
            For Each Element As XElement In NewsFeed...<root>...<newsfeed>...<news>
                NewsBuilder.Append("" & Element.Value & vbCrLf & vbCrLf)
            Next
            Return NewsBuilder.ToString
        Catch ex As Exception
            Return "Could not retrieve MOTD!" & ex.Message
        End Try
    End Function
#End Region

#Region "Start/Stop Buttons"
    'Start
    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        If ListBox1.Items.Count = 0 Then
        End If

        Try
            ListBox1.SelectedIndex = 0
            ListBox2.SelectedIndex = RandomNumber(ListBox2.Items.Count - 1, 0)
        Catch ex As Exception
        End Try
        SigninTimer.Start()

        ButtonX5.Enabled = False
        ButtonX6.Enabled = True
        TextBoxX1.Enabled = False
        CheckBoxX1.Enabled = False
        CheckBoxX2.Enabled = False
        CheckBoxX3.Enabled = False
        CheckBoxX4.Enabled = False
        CheckBoxX5.Enabled = False
        CheckBoxX6.Enabled = False
        ComboBox1.Enabled = False
    End Sub
    'Stop
    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        SigninTimer.Stop()
        SignoutTimer.Stop()
        LikeTimer.Stop()
        SubscribeTimer.Stop()
        frstSignOut.Stop()
        CommentTimer.Stop()
        NavigateTimer.Stop()
        fix.Stop()
        LoopTimer.Stop()
        Favoritetimer.Stop()
        Flaggit.Stop()
        FlagR.Stop()
        FlagDrop.Stop()
        ButtonX6.Enabled = False
        ButtonX5.Enabled = True
        TextBoxX1.Enabled = True
        CheckBoxX1.Enabled = True
        CheckBoxX2.Enabled = True
        CheckBoxX5.Enabled = True
        CheckBoxX6.Enabled = True
        If CheckBoxX6.Checked Then
            ComboBox1.Enabled = True
        Else
            ComboBox1.Enabled = False
        End If
        If CheckBoxX4.Checked Then
            CheckBoxX3.Enabled = False
        Else
            CheckBoxX3.Enabled = True
        End If
        If CheckBoxX3.Checked Then
            CheckBoxX4.Enabled = False
        Else
            CheckBoxX4.Enabled = True
        End If
    End Sub
#End Region

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
    Private Sub NavigateTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavigateTimer.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            WebBrowser1.Navigate(TextBoxX1.Text)
            If CheckBoxX7.Checked Then
                UnSub1.Start()
                NavigateTimer.Stop()
            Else
                SubscribeTimer.Start()
                NavigateTimer.Stop()
            End If
        End If
    End Sub
    Private Sub UnSub2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnSub2.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            unsubscribe2()
            LoopTimer.Start()
            UnSub2.Stop()
        End If
    End Sub
    Private Sub UnSub1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnSub1.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            unsubscribe1()
            UnSub2.Start()
            UnSub1.Stop()
        End If
    End Sub
    Private Sub Flaggit_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Flaggit.Tick
        If CheckBoxX6.Checked Then
            flagthisvideo()
            LoopTimer.Start()
            Flaggit.Stop()
        Else
            LoopTimer.Start()
            Flaggit.Stop()
        End If
    End Sub
    Private Sub FlagR_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlagR.Tick
        If CheckBoxX6.Checked Then
            flagreason()
            Flaggit.Start()
            FlagR.Stop()
        Else
            Flaggit.Start()
            FlagR.Stop()
        End If
    End Sub
    Private Sub FlagDrop_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlagDrop.Tick
        If CheckBoxX6.Checked Then
            flagdropdown()
            FlagR.Start()
            FlagDrop.Stop()
        Else
            FlagR.Start()
            FlagDrop.Stop()
        End If
    End Sub
    Private Sub Favoritetimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Favoritetimer.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            If CheckBoxX5.Checked Then
                Drop_down_fav_button()
                FlagDrop.Start()
                Favoritetimer.Stop()
            Else
                FlagDrop.Start()
                Favoritetimer.Stop()
            End If
        End If
    End Sub
    Private Sub frstSignOut_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frstSignOut.Tick
        WebBrowser1.Navigate(youtube)
        WebBrowser1.Navigate("https://www.google.com/accounts/Logout")
        WebBrowser1.Navigate("https://www.google.com/accounts/ServiceLogin?uilel=3&service=youtube&passive=true")
        frstSignOut.Stop()
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
    Private Sub LoopTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoopTimer.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            If ListBox1.SelectedIndex = ListBox1.Items.Count - 1 Then
                WebBrowser1.Navigate("https://www.google.com/accounts/ServiceLogin?uilel=3&service=youtube&passive=true")
                Try
                    ListBox1.SelectedIndex = 0
                    ListBox2.SelectedIndex = 0
                Catch ex As Exception
                End Try
                frstSignOut.Start()
                Clear_History()
                Clear_Cookies()
                LoopTimer.Stop()
            Else
                If proxycounter = 5 Then
                    proxycounter = 1
                    If MainBotProxyForm.CheckBoxX1.Checked = True Then
                        RefreshIESettings(MainBotProxyForm.ListBox1.SelectedItem.ToString())
                        If MainBotProxyForm.ListBox1.SelectedIndex = MainBotProxyForm.ListBox1.Items.Count - 1 Then
                            MainBotProxyForm.ListBox1.SelectedIndex = 0
                        Else
                            MainBotProxyForm.ListBox1.SelectedIndex = MainBotProxyForm.ListBox1.SelectedIndex + 1
                        End If
                    End If
                End If
                Try
                    ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
                    ListBox2.SelectedIndex = RandomNumber(ListBox2.Items.Count - 1, 0)
                    proxycounter = proxycounter + 1
                Catch ex As Exception
                End Try
                SignoutTimer.Start()
                LoopTimer.Stop()
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
    Private Sub SigninTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SigninTimer.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            If WebBrowser1.Document.Body.OuterText.Contains("Sign in to YouTube") Then
                Try
                    Dim str() As String = Split(ListBox1.SelectedItem.ToString(), ":")
                    WebBrowser1.Document.GetElementById("Email").SetAttribute("value", str(0))
                    WebBrowser1.Document.GetElementById("Passwd").SetAttribute("value", str(1))
                    Dim allelements As HtmlElementCollection = WebBrowser1.Document.All
                    For Each webpageelement1 As HtmlElement In allelements
                        If webpageelement1.GetAttribute("type") = "submit" Then
                            webpageelement1.InvokeMember("click")
                        End If
                    Next
                    ListBox1.Items.Remove(ListBox1.SelectedItem)
                    Label1.Text = "Current Account(s):" & ListBox1.Items.Count
                Catch ex As Exception
                End Try
            Else
                SignIn()
            End If
        End If
    End Sub
    Private Sub LikeTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LikeTimer.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            If CheckBoxX3.Checked Then
                VideoLike()
                CommentTimer.Start()
                LikeTimer.Stop()
            Else
                If CheckBoxX4.Checked Then
                    VideoUnLike()
                    CommentTimer.Start()
                    LikeTimer.Stop()

                Else
                    CommentTimer.Start()
                    LikeTimer.Stop()
                End If
            End If
        End If
    End Sub
    Private Sub CommentTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentTimer.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            If CheckBoxX2.Checked Then
                Comment()
                Favoritetimer.Start()
                CommentTimer.Stop()
            Else
                Favoritetimer.Start()
                CommentTimer.Stop()
            End If
        End If
    End Sub
    Private Sub SubscribeTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubscribeTimer.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            If CheckBoxX1.Checked Then
                SubscribeButton()
                LikeTimer.Start()
                SubscribeTimer.Stop()
            Else
                LikeTimer.Start()
                SubscribeTimer.Stop()
            End If
        End If
    End Sub
#End Region

#Region "Form Loads"
    Private Sub MainBotForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        proxycounter = 1
        fix.Start()
        frstSignOut.Start()
        ComboBox1.Enabled = False
        ButtonX6.Enabled = False
        WebBrowser1.Navigate("http://www.youtube.com")

    End Sub
#End Region

    Private Sub GroupPanel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPanel2.Click
        If MainForm.MainEE.Text = "6" Then
            MainForm.MainEE.Text = "7"
        End If
    End Sub

    Private Sub ButtonX7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX7.Click
        MainBotProxyForm.MdiParent = MainForm
        MainBotProxyForm.Show()
    End Sub

    Private Sub ButtonX10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX10.Click
        MainBotSettingsForm.MdiParent = MainForm
        MainBotSettingsForm.Show()
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If WebBrowser1.Document.Body.OuterText.Contains("View data stored with this account") Then
            SigninTimer.Stop()
            NavigateTimer.Start()
        ElseIf WebBrowser1.Document.Body.OuterText.Contains("Sign in as a different user") Then
            WebBrowser1.Navigate("https://www.google.com/accounts/Logout?continue=https%3A%2F%2Fwww.google.com%2Faccounts%2FServiceLoginAuth%3Fservice%3Dyoutube%26uilel%3D3&il=true&zx=b4mahraf069u")
        End If
    End Sub
End Class
