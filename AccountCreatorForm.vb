Imports DevComponents.DotNetBar
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Runtime.InteropServices
Imports Microsoft.Win32

Public Class AccountCreatorForm

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Struct_INTERNET_PROXY_INFO
        Public dwAccessType As Integer
        Public proxy As IntPtr
        Public proxyBypass As IntPtr
    End Structure
    <DllImport("wininet.dll", SetLastError:=True)> _
    Private Shared Function InternetSetOption(ByVal hInternet As IntPtr, ByVal dwOption As Integer, ByVal lpBuffer As IntPtr, ByVal lpdwBufferLength As Integer) As Boolean
    End Function
    Private Sub UseProxy(ByVal strProxy As String)
        Dim struct_IPI As Struct_INTERNET_PROXY_INFO
        struct_IPI.dwAccessType = 3
        struct_IPI.proxy = Marshal.StringToHGlobalAnsi(strProxy)
        struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local")
        Dim intptrStruct As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI))
        Marshal.StructureToPtr(struct_IPI, intptrStruct, True)
        Dim iReturn As Boolean = AccountCreatorForm.InternetSetOption(IntPtr.Zero, &H26, intptrStruct, Marshal.SizeOf(struct_IPI))
    End Sub
    Public Sub SetProxy(ByVal ServerName As String, ByVal port As Integer)
        Dim regkey1 As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Internet Settings", RegistryKeyPermissionCheck.Default)
        regkey1.SetValue("ProxyServer", (ServerName & ":" & port.ToString), RegistryValueKind.Unknown)
        regkey1.SetValue("ProxyEnable", True, RegistryValueKind.DWord)
        regkey1.Close()
    End Sub
    Public Function rediff() As Bitmap
        Dim enumerator As IEnumerator
        Try
            Dim current As HtmlElement
            enumerator = Me.WebBrowser2.Document.Images.GetEnumerator
            Do
                If Not enumerator.MoveNext Then
                    Return rediff
                End If
                current = DirectCast(enumerator.Current, HtmlElement)
            Loop While Not current.OuterHtml.ToString.Contains("tb_getimage.php")
            'Dim range As IHTMLControlRange = DirectCast(DirectCast(Me.WebBrowser2.Document.Body.DomElement, HTMLBody).createControlRange, IHTMLControlRange)
            'range.add(DirectCast(current.DomElement, IHTMLControlElement))
            'range.select()
            'range.execCommand("Copy", False, Nothing)
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        Try
            rediff = DirectCast(Clipboard.GetImage, Bitmap)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            ProjectData.ClearProjectError()
        End Try
        Return rediff
    End Function

#Region "Timers"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Me.WebBrowser1.Document.GetElementById("Email").SetAttribute("value", Conversions.ToString(Me.ListBox1.SelectedItem))
            Me.WebBrowser1.Document.GetElementById("Passwd").SetAttribute("value", Me.TextBoxX5.Text)
            Me.WebBrowser1.Document.GetElementById("PasswdAgain").SetAttribute("value", Me.TextBoxX5.Text)
            If Me.ProgressBarX1.Visible Then
                Me.Timer22.Start()
            End If
            Me.Timer1.Stop()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Private Sub Timer17_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer17.Tick
        Try
            If Me.WebBrowser1.DocumentText.Contains(" The website cannot  ") Then
                Dim Rando As New Random
                Me.ListBox2.SelectedIndex = Rando.Next(0, Me.ListBox2.Items.Count)
                Me.UseProxy(Conversions.ToString(Me.ListBox2.SelectedItem))
                Me.WebBrowser2.Navigate("http://register.rediff.com/register/register.php?FormName=user_details")
                Me.WebBrowser1.Navigate("https://www.google.com/accounts/NewAccount?service=adsense")
                Me.Timer12.Start()
                Me.Timer17.Stop()
            End If
            If Me.WebBrowser2.DocumentText.Contains("The website cannot") Then
                Dim Rando As New Random
                Try
                    Me.ListBox2.SelectedIndex = Rando.Next(0, Me.ListBox2.Items.Count)
                    Me.UseProxy(Conversions.ToString(Me.ListBox2.SelectedItem))
                    Me.WebBrowser2.Navigate("http://register.rediff.com/register/register.php?FormName=user_details")
                    Me.WebBrowser1.Navigate("https://www.google.com/accounts/NewAccount?service=adsense")
                    Me.Timer12.Start()
                    Me.Timer17.Stop()
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    ProjectData.ClearProjectError()
                End Try
            End If
            If Me.WebBrowser2.DocumentText.Contains("to webpage cancelled") Then
                Dim Rando As New Random
                Me.ListBox2.SelectedIndex = Rando.Next(0, Me.ListBox2.Items.Count)
                Me.WebBrowser2.Navigate("http://register.rediff.com/register/register.php?FormName=user_details")
                Me.WebBrowser1.Navigate("https://www.google.com/accounts/NewAccount?service=adsense")
                Me.Timer12.Start()
                Me.Timer17.Stop()
            End If
        Catch exception2 As Exception
            ProjectData.SetProjectError(exception2)
            ProjectData.ClearProjectError()
        End Try

    End Sub
    Private Sub Timer12_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer12.Tick
        Me.Label6.Text = Conversions.ToString(CDbl((Conversions.ToDouble(Me.Label6.Text) - 1)))
        If (Conversions.ToDouble(Me.Label6.Text) = 0) Then
            Me.ButtonX7.PerformClick()
            Try
                Me.ListBox3.SelectedIndex += 1
                Me.TextBox3.Text = ""
                Me.Label6.Text = Conversions.ToString(3)
                If Me.CheckBoxX1.Checked Then
                    Dim Rando As New Random
                    Dim Splitter As String() = Nothing
                    Try
                        Me.ListBox2.SelectedIndex = Rando.Next(0, Me.ListBox2.Items.Count)
                        Splitter = Me.ListBox2.SelectedItem.ToString.Split(New Char() {":"c})
                        Me.SetProxy(Splitter(0), Conversions.ToInteger(Splitter(1)))
                    Catch exception1 As Exception
                        ProjectData.SetProjectError(exception1)
                        ProjectData.ClearProjectError()
                    End Try

                End If
                Me.Timer12.Stop()
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError()
            End Try
        End If

    End Sub
    Private Sub Timer29_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer29.Tick
        Try
            Dim VBt_refL0 As IEnumerator
            Try
                VBt_refL0 = Me.WebBrowser1.Document.GetElementsByTagName("span").GetEnumerator
                Do While VBt_refL0.MoveNext
                    Dim refresh As HtmlElement = DirectCast(VBt_refL0.Current, HtmlElement)
                    If (refresh.GetAttribute("className") = "account-link-username-label") Then
                        Dim VBt_refL1 As IEnumerator
                        Try
                            VBt_refL1 = Me.WebBrowser2.Document.GetElementsByTagName("a").GetEnumerator
                            Do While VBt_refL1.MoveNext
                                Dim element As HtmlElement = DirectCast(VBt_refL1.Current, HtmlElement)
                                If (element.GetAttribute("title") = "Inbox") Then
                                    Me.WebBrowser2.Refresh()
                                    Me.Timer15.Start()
                                    Me.Timer29.Stop()
                                End If
                            Loop
                        Finally
                            If TypeOf VBt_refL1 Is IDisposable Then
                                TryCast(VBt_refL1, IDisposable).Dispose()
                            End If
                        End Try
                    End If
                Loop
            Finally
                If TypeOf VBt_refL0 Is IDisposable Then
                    TryCast(VBt_refL0, IDisposable).Dispose()
                End If
            End Try
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            ProjectData.ClearProjectError()
        End Try
        Try
            Dim VBt_refL2 As IEnumerator
            Try
                VBt_refL2 = Me.WebBrowser2.Document.GetElementsByTagName("a").GetEnumerator
                Do While VBt_refL2.MoveNext
                    Dim element As HtmlElement = DirectCast(VBt_refL2.Current, HtmlElement)
                    If (element.GetAttribute("title") = "Inbox") Then
                        Me.WebBrowser1.Document.GetElementById("verifyviaemail").InvokeMember("click")
                    End If
                Loop
            Finally
                If TypeOf VBt_refL2 Is IDisposable Then
                    TryCast(VBt_refL2, IDisposable).Dispose()
                End If
            End Try
        Catch exception2 As Exception
            ProjectData.SetProjectError(exception2)
            ProjectData.ClearProjectError()
        End Try

    End Sub
    Private Sub Timer15_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer15.Tick
        Me.Label27.Text = Conversions.ToString(CDbl((Conversions.ToDouble(Me.Label27.Text) - 1)))
        If (Conversions.ToDouble(Me.Label27.Text) = 0) Then
            Try
                If (Me.Label8.Text = "(1)") Then
                    If Me.ProgressBarX1.Visible Then
                        Me.Button2.Enabled = True
                    Else
                        Me.Button2.Enabled = False
                    End If
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError()
            End Try
            Me.Timer15.Stop()
        End If

    End Sub
#End Region

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.WebBrowser2.Document.GetElementById("DOB_Day").SetAttribute("value", Conversions.ToString(15))
            Me.WebBrowser2.Document.GetElementById("DOB_Month").SetAttribute("value", Conversions.ToString(11))
            Me.WebBrowser2.Document.GetElementById("DOB_Year").SetAttribute("value", Conversions.ToString(&H7C5))
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            ProjectData.ClearProjectError()
        End Try
        Try
            Dim VBt_refL0 As IEnumerator
            Dim VBt_refL1 As IEnumerator
            Try
                VBt_refL0 = Me.WebBrowser2.Document.GetElementsByTagName("input").GetEnumerator
                Do While VBt_refL0.MoveNext
                    Dim element As HtmlElement = DirectCast(VBt_refL0.Current, HtmlElement)
                    If element.GetAttribute("className").StartsWith("captcha") Then
                        If Me.ProgressBarX1.Visible Then
                            element.SetAttribute("value", Me.Label18.Text)
                        Else
                            element.SetAttribute("value", Me.TextBoxX6.Text)
                        End If
                    End If
                Loop
            Finally
                If TypeOf VBt_refL0 Is IDisposable Then
                    TryCast(VBt_refL0, IDisposable).Dispose()
                End If
            End Try
            Try
                VBt_refL1 = Me.WebBrowser2.Document.GetElementsByTagName("input").GetEnumerator
                Do While VBt_refL1.MoveNext
                    Dim element As HtmlElement = DirectCast(VBt_refL1.Current, HtmlElement)
                    If element.GetAttribute("className").StartsWith("submitbtn") Then
                        element.InvokeMember("click")
                    End If
                Loop
            Finally
                If TypeOf VBt_refL1 Is IDisposable Then
                    TryCast(VBt_refL1, IDisposable).Dispose()
                End If
            End Try
            Me.Timer27.Start()
        Catch exception2 As Exception
            ProjectData.SetProjectError(exception2)
            ProjectData.ClearProjectError()
        End Try

    End Sub

    Private Sub AccountCreatorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class