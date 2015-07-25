Imports System.IO
Imports System.Runtime.InteropServices

Public Class MainBotProxyForm
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
    Private myPath As String

    'Import Proxies
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
        ListBox1.SelectedIndex = 0
    End Sub
    'Clear Accounts
    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        ListBox1.Items.Clear()
    End Sub
    'Save
    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        Dim sw As New StreamWriter(myPath)
        For Each line As String In ListBox1.Items
            sw.WriteLine(line)
        Next
        sw.Close()
    End Sub
    'Close
    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        Close()
    End Sub
    'Proxy Load
    Private Sub Proxy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sr As StreamReader
        myPath = Application.StartupPath + "\\1Data.txt"
        If File.Exists(myPath) = True Then

            sr = New StreamReader(myPath)

        Else

            Exit Sub

        End If

        Dim currentLine As String = ""

        While sr.EndOfStream = False

            currentLine = sr.ReadLine

            ListBox1.Items.Add(currentLine)

        End While

        sr.Close()

    End Sub
    'Enable Proxy
    Private Sub CheckBoxX1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxX1.CheckedChanged
        If CheckBoxX1.Checked = True Then

        Else

        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        If MainForm.MainEE.Text = "3" Then
            MainForm.MainEE.Text = "4"
        End If
    End Sub
End Class