Imports Google.GData.Client
Imports Google.GData.Extensions
Imports Google.GData.YouTube
Imports Google.GData.YouTube.YouTubeService
Imports Google.GData.Extensions.MediaRss
Imports Google.YouTube
Imports System.Management
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Text
Imports DevComponents.DotNetBar
Public Class YouTubeAPIBotForm

    Private isVideoOK As Boolean
    Private settings As YouTubeRequestSettings
    Private dVideoID As String
    Private oldVideoURL As String
    Private request As YouTubeRequest
    Private YWT As Thread
    Private dLike As Boolean
    Private dComment As Boolean
    Private dSubscribe As Boolean
    Private dFlag As Boolean
    Private dDislike As Boolean
    Private dFavorite As Boolean
    Private didWeStart As Boolean
    Private accountsFile As String
    Private commentsFile As String
    Private proxiesFile As String
    Private dUseProxies As Boolean
    'Test Proxy
    Private Function TestProxy(ByVal p As String) As Boolean
        Dim flag As Boolean
        Try
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://google.de"), HttpWebRequest)
            request.Method = "GET"
            request.ContentType = "application/x-www-form-urlencoded"
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; de; rv:1.9.2.2) Gecko/20100316 Firefox/3.6.2"
            request.Timeout = &H1388
            request.CookieContainer = New CookieContainer
            Dim proxy As New WebProxy(p, True)
            request.Proxy = proxy
            Dim response As HttpWebResponse = DirectCast(request.GetResponse, HttpWebResponse)
            Dim reader As New StreamReader(response.GetResponseStream)
            flag = True
        Catch exception1 As Exception
            Dim exception As Exception = exception1
            flag = False
        End Try
        Return flag
    End Function
    'Get Proxies
    Public Function getProxy(ByVal s As String) As Object
        Return ("http://" & s & "/")
    End Function
    'Get username
    Public Function getAccount(ByVal s As String) As Object
        Return s.Substring(0, s.IndexOf(":"))
    End Function
    'Get Password
    Public Function getPassword(ByVal s As String) As Object
        Return s.Substring((s.IndexOf(":") + 1), ((s.Length - s.IndexOf(":")) - 1))
    End Function
    'Random Comment
    Public Function RandomNumber(ByVal MaxNumber As Integer, Optional ByVal MinNumber As Integer = 0) As Integer
        Dim random As New Random(((15 * DateTime.Now.Second) + DateTime.Now.Minute))
        If (MinNumber > MaxNumber) Then
            Dim num2 As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = num2
        End If
        Return random.Next(MinNumber, MaxNumber)
    End Function
    'Functions
    Private Sub YTWorkerThread1()
        Dim strArray As String()
        Dim numArray As Integer()
        Dim strArray3 As String()
        If Me.CheckLike.Checked = True Then
            Me.dLike = True
        End If
        If Me.CheckDislike.Checked = True Then
            Me.dDislike = True
        Else
            Me.dDislike = False
        End If
        If Me.CheckSubsribe.Checked = True Then
            Me.dSubscribe = True
        Else
            Me.dSubscribe = False
        End If
        If Me.CheckComment.Checked = True Then
            Me.dComment = True
        Else
            Me.dComment = False
        End If
        If Me.CheckFlag.Checked = True Then
            Me.dFlag = True
        Else
            Me.dFlag = False
        End If
        If Me.CheckFavorite.Checked = True Then
            Me.dFavorite = True
        Else
            Me.dFavorite = False
        End If
        If Me.CheckUseProxies.Checked = True Then
            Me.dUseProxies = True
        Else
            Me.dUseProxies = False
        End If
        Me.addLog("Initializing Bot...")
        If Me.dUseProxies Then
            strArray3 = File.ReadAllLines(Me.proxiesFile)
            numArray = New Integer((strArray3.Length + 1) - 1) {}
            Dim index As Integer = 0
            Dim str As String
            For Each str In strArray3
                numArray(index) = -1
                index += 1
            Next
            Me.addLog("All Proxies Read!")
        End If
        If Me.dComment Then
            strArray = File.ReadAllLines(Me.commentsFile)
            Me.addLog("All Comments read!")
        End If
        Me.addLog("Starting Bot...")
        Dim strArray2 As String() = File.ReadAllLines(Me.accountsFile)
        Dim num2 As Integer = 1
        Dim str2 As String
        For Each str2 In strArray2
            Dim video As Video
            Dim num6 As Integer
            Dim factory As GDataRequestFactory
            Me.addLog(Convert.ToString("Using account: " & Me.getAccount(str2)))
            Me.settings = New YouTubeRequestSettings(Me.YouTubeConnect1("6zyKPblhBzAyWK558X61WaDhBmi4"), Me.YouTubeConnect1("A6LZevdMdZxUCYs3Dy6FW6/ysus3B+DxCvxyRbyXs6RNCaDH6uCFPK5bRT/9RF/DBz8HdnDTvlaYBcygsuy+AuD2Ny8kCmygeRSl6ndtqzR1WKaAAuL9CTkj6csKNRSnq+C4"), Convert.ToString(Me.getAccount(str2)), Convert.ToString(Me.getPassword(str2)))
            Me.request = New YouTubeRequest(Me.settings)
Label_01B5:
            If Not Me.dUseProxies Then
                GoTo Label_02A1
            End If
            Dim num7 As Integer = Me.RandomNumber(strArray3.Length, 0)
            Dim p As String = Convert.ToString(Me.getProxy(strArray3(num7)))
            Me.addLog(("Using Proxy: " & strArray3(num7)))
            If (numArray(num7) = 2) Then
                Me.addLog("Proxy OK! (2)")
            Else
                If (numArray(num7) = -2) Then
                    Me.addLog("We know already this proxy fails! (-2)")
                    Thread.Sleep(750)
                Else
                    If Me.TestProxy(p) Then
                        Me.addLog("Proxy OK! (2)")
                        numArray(num7) = 2
                        GoTo Label_0269
                    End If
                    Me.addLog("Cannot connect to proxy! Retry with another proxy! (-2)")
                    numArray(num7) = -2
                    Thread.Sleep(750)
                End If
                GoTo Label_01B5
            End If
Label_0269:
            factory = DirectCast(Me.request.Service.RequestFactory, GDataRequestFactory)
            Dim proxy As New WebProxy(p, True) With { _
            .Credentials = CredentialCache.DefaultNetworkCredentials _
            }
            factory.Proxy = proxy
            GoTo Label_02AD
Label_02A1:
            Me.addLog("Not using proxy...")

Label_02AD:
            Try
                Dim entryUri As New Uri(("http://gdata.youtube.com/feeds/api/videos/" & Me.dVideoID))
                video = Me.request.Retrieve(Of Video)(entryUri)
            Catch exception1 As Exception
                Dim exception As Exception = exception1
                If (((((exception.Message.Contains("Credential") Or exception.Message.Contains("credential")) Or exception.Message.Contains("captcha")) Or exception.Message.Contains("Captcha")) Or exception.Message.Contains("verified")) Or exception.Message.Contains("Verified")) Then
                    Me.addLog("Not a valid YouTube account!")
                    GoTo Label_09E0
                End If
                Me.addLog("Proxy failed with YouTube!")
                Me.addLog(exception.Message)
                GoTo Label_01B5
            End Try
            Dim num5 As Integer = 0
Label_042A:
            If (num5 > 0) Then
                Thread.Sleep(500)
            End If
            If Me.dLike Then
                Try
                    video.Rating = 5
                    Me.request.Insert(Of Video)(video.RatingsUri, video)
                    Me.addLog("Liked Video!")
                    GoTo Label_0500
                Catch exception16 As Exception
                    Dim exception3 As Exception = exception16
                    If (num5 < 3) Then
                        num5 += 1
                        GoTo Label_042A
                    End If
                    Me.addLog("Could not like Video!")
                    GoTo Label_0500
                End Try
            End If
            If Me.dDislike Then
                Try
                    video.Rating = 1
                    Me.request.Insert(Of Video)(video.RatingsUri, video)
                    Me.addLog("Disliked Video!")
                Catch exception17 As Exception
                    Dim exception4 As Exception = exception17
                    If (num5 < 3) Then
                        num5 += 1
                        GoTo Label_042A
                    End If
                    Me.addLog("Could not dislike video!")
                End Try
            End If
Label_0500:
            num6 = 0
Label_0503:
            If (num6 > 0) Then
                Thread.Sleep(500)
            End If
            If Me.dSubscribe Then
                Try
                    Dim subscription As New Subscription With { _
                        .Type = SubscriptionEntry.SubscriptionType.channel, _
                        .UserName = video.Uploader _
                    }
                    Me.request.Insert(Of Subscription)(New Uri(YouTubeQuery.CreateSubscriptionUri(Convert.ToString(Me.getAccount(str2)))), subscription)
                    Me.addLog(("Subscribed to Channel of uploader: " & video.Uploader))
                Catch exception18 As Exception
                    Dim exception5 As Exception = exception18
                    If (num6 < 3) Then
                        num6 += 1
                        GoTo Label_0503
                    End If
                    Me.addLog("Could not subscribe to channel!")
                End Try
            End If
            Dim num4 As Integer = 0
Label_05AD:
            If (num4 > 0) Then
                Thread.Sleep(500)
            End If
            If Me.dFavorite Then
                Try
                    Dim str6 As String = ("http://gdata.youtube.com/feeds/api/videos/" & Me.dVideoID)
                    Dim service As YouTubeService = Me.request.Service
                    Dim entry As YouTubeEntry = DirectCast(service.Get(str6), YouTubeEntry)
                    Dim uriString As String = "http://gdata.youtube.com/feeds/api/users/default/favorites"
                    service.Insert(Of YouTubeEntry)(New Uri(uriString), entry)
                    Me.addLog("The video has been added to favourites!")
                Catch exception19 As Exception
                    Dim exception6 As Exception = exception19
                    If (num4 < 3) Then
                        num4 += 1
                        GoTo Label_05AD
                    End If
                    Me.addLog("Could not add video to favourites!")
                End Try
            End If
            Dim num3 As Integer = 0
Label_0650:
            If (num3 > 0) Then
                Thread.Sleep(500)
            End If
            If Me.dComment Then
                Try
                    Dim c As New Comment
                    Dim num8 As Integer = Me.RandomNumber(strArray.Length, 0)
                    c.Content = strArray(num8)
                    Me.request.AddComment(video, c)
                    Me.addLog(("Commented with """ & strArray(num8) & """!"))
                Catch exception20 As Exception
                    Dim exception7 As Exception = exception20
                    If (num3 < 3) Then
                        num3 += 1
                        GoTo Label_0650
                    End If
                    Me.addLog("Could not add comment to video!")
                End Try
            End If
            If Me.dFlag Then
                Select Case Me.ComboFlag.SelectedIndex
                    Case 0
                        Try
                            Dim complaint As New Complaint With { _
                                .Type = ComplaintEntry.ComplaintType.DANGEROUS, _
                                .Content = "This video is dangerous!! My son watched it, this should be deleted" _
                            }
                            Me.request.Insert(Of Complaint)(video.ComplaintUri, complaint)
                            Me.addLog("Flagged as dangerous!")
                        Catch exception21 As Exception
                            Dim exception8 As Exception = exception21
                            Me.addLog("Could not flag video as dangerous!")
                        End Try
                        Exit Select
                    Case 1
                        Try
                            Dim complaint2 As New Complaint With { _
                                .Type = ComplaintEntry.ComplaintType.HATE, _
                                .Content = "This video contains very hateful stuff and should not be shown to public" _
                            }
                            Me.request.Insert(Of Complaint)(video.ComplaintUri, complaint2)
                            Me.addLog("Flagged as hateful!")
                        Catch exception22 As Exception
                            Dim exception9 As Exception = exception22
                            Me.addLog("Could not flag video as hateful!")
                        End Try
                        Exit Select
                    Case 2
                        Try
                            Dim complaint3 As New Complaint With { _
                                .Type = ComplaintEntry.ComplaintType.PORN, _
                                .Content = "A sexual act is on this video! This is nothing for youtube!!" _
                            }
                            Me.request.Insert(Of Complaint)(video.ComplaintUri, complaint3)
                            Me.addLog("Flagged as porn!")
                        Catch exception23 As Exception
                            Dim exception10 As Exception = exception23
                            Me.addLog("Could not flag video as porn!")
                        End Try
                        Exit Select
                    Case 3
                        Try
                            Dim complaint4 As New Complaint With { _
                                .Type = ComplaintEntry.ComplaintType.RIGHTS, _
                                .Content = "This video harms my rights as a person!" _
                            }
                            Me.request.Insert(Of Complaint)(video.ComplaintUri, complaint4)
                            Me.addLog("Flagged as ""rights hurted""!")
                        Catch exception24 As Exception
                            Dim exception11 As Exception = exception24
                            Me.addLog("Could not flag video as ""rights hurted""!")
                        End Try
                        Exit Select
                    Case 4
                        Try
                            Dim complaint5 As New Complaint With { _
                                .Type = ComplaintEntry.ComplaintType.SPAM, _
                                .Content = "Completely useless and just for trolling or spamming..." _
                            }
                            Me.request.Insert(Of Complaint)(video.ComplaintUri, complaint5)
                            Me.addLog("Flagged as spam!")
                        Catch exception25 As Exception
                            Dim exception12 As Exception = exception25
                            Me.addLog("Could not flag video as spam!")
                        End Try
                        Exit Select
                    Case 5
                        Try
                            Dim complaint6 As New Complaint With { _
                                .Type = ComplaintEntry.ComplaintType.VIOLENCE, _
                                .Content = "Cruel acts of violence contained, nothing to show to a youtube audience!!" _
                            }
                            Me.request.Insert(Of Complaint)(video.ComplaintUri, complaint6)
                            Me.addLog("Flagged as violent!")
                        Catch exception26 As Exception
                            Dim exception13 As Exception = exception26
                            Me.addLog("Could not flag video as violent!")
                        End Try
                        Exit Select
                End Select
            End If
Label_09E0:
            num2 += 1
            ListBoxAccounts.Items.Remove(ListBoxAccounts.SelectedItem)
        Next
        Me.addLog("Bot has completed request.")
        Me.StopButton.Enabled = False
        Me.StartButton.Enabled = True
        Me.didWeStart = False

    End Sub
    'Connect
    Public Function YouTubeConnect1(ByVal input As String) As String
        Dim num As Integer
        Dim str As String = "75XYTabcS/UVWdefADqr6RuvN8PBCsQtwx2KLyz+OM3Hk9ghi01ZFlmnjopE=GIJ4"
        Dim builder As New StringBuilder
        Do
            Dim numArray2 As Integer() = New Integer(4 - 1) {}
            Dim numArray As Integer() = New Integer() {0, 0, 0}
            Dim index As Integer = 0
            Do
                numArray2(index) = str.IndexOf(input.Chars(num))
                num += 1
                index += 1
            Loop While (index <= 3)
            numArray(0) = ((numArray2(0) << 2) Or (numArray2(1) >> 4))
            numArray(1) = (((numArray2(1) And 15) << 4) Or (numArray2(2) >> 2))
            numArray(2) = (((numArray2(2) And 3) << 6) Or numArray2(3))
            builder.Append(Strings.Chr(numArray(0)))
            If (numArray2(2) <> &H40) Then
                builder.Append(Strings.Chr(numArray(1)))
            End If
            If (numArray2(3) <> &H40) Then
                builder.Append(Strings.Chr(numArray(2)))
            End If
        Loop While (num < input.Length)
        Return builder.ToString.Replace("%20", " ").Replace("%21", "!").Replace("%3F", "?").Replace("%3D", "=").Replace("%3A", ":")
    End Function
    'Add Logs
    Private Function addLog(ByVal s As String) As Object
        Me.ListBoxLogs.Items.Add(s)
        Me.ListBoxLogs.SelectedIndex = (Me.ListBoxLogs.Items.Count - 1)
        Return True
    End Function
    'Video Private
    Public Function isVideoPrivate(ByVal p As Boolean) As Object
        If p Then
            Return "Yes"
        End If
        Return "No"
    End Function
    'Update INFO for video
    Private Sub UpdateInfoThread()
        Try
            Dim entryUri As New Uri(("http://gdata.youtube.com/feeds/api/videos/" & Me.dVideoID))
            Me.ProgressBarStatus.Value = 20
            Dim video As Video = Me.request.Retrieve(Of Video)(entryUri)
            Me.ProgressBarStatus.Value = 50
            Me.addLog(("Selected Video: " & video.Title))
            Me.ListBoxVideoInfo.Items.Clear()
            Me.ListBoxVideoInfo.Items.Add(video.Title)
            Me.ListBoxVideoInfo.Items.Add(("ID: " & video.VideoId))
            Me.ListBoxVideoInfo.Items.Add(("Uploader: " & video.Uploader))
            Me.ListBoxVideoInfo.Items.Add(("Rating: " & Convert.ToString(video.RatingAverage)))
            Me.ListBoxVideoInfo.Items.Add(("Views: " & video.ViewCount))
            Me.ListBoxVideoInfo.Items.Add(("Comments: " & video.CommmentCount))
            Me.ListBoxVideoInfo.Items.Add(("Private: " & Me.isVideoPrivate(video.Private)))
            Me.ListBoxVideoInfo.Items.Add(("Description: " & video.Description))
            Me.isVideoOK = True
            Me.ProgressBarStatus.Value = 100
        Catch exception1 As Exception
            Dim exception As Exception = exception1
            Me.addLog("Error. The video link mayby invalid please try again.")
            Me.ListBoxVideoInfo.Items.Add("Failed to load Video!")
            Me.isVideoOK = False
            Me.ProgressBarStatus.Value = 0
        End Try
    End Sub
    'Form Load
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.settings = New YouTubeRequestSettings(Me.YouTubeConnect1("6zyKPblhBzAyWK558X61WaDhBmi4"), Me.YouTubeConnect1("A6LZevdMdZxUCYs3Dy6FW6/ysus3B+DxCvxyRbyXs6RNCaDH6uCFPK5bRT/9RF/DBz8HdnDTvlaYBcygsuy+AuD2Ny8kCmygeRSl6ndtqzR1WKaAAuL9CTkj6csKNRSnq+C4"), Me.YouTubeConnect1("NzROCzMy8z818vL4"), Me.YouTubeConnect1("Bv83evy1BTWnDZ8qDyyv8ay8ea74"))
        Me.request = New YouTubeRequest(Me.settings)
        MessageBoxEx.EnableGlass = False
    End Sub
    'When video url is inputted
    Private Sub TextBoxX1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VideoURLTextBox.TextChanged
        If (Me.ProgressBarStatus.Value > 0) Then
            Me.ProgressBarStatus.Value = 0
        End If
        If (Me.VideoURLTextBox.Text.Contains("watch?v=") AndAlso (Me.VideoURLTextBox.Text <> Me.oldVideoURL)) Then
            Me.dVideoID = Me.VideoURLTextBox.Text.Substring((Me.VideoURLTextBox.Text.IndexOf("watch?v=") + 8), 11)
            Me.ProgressBarStatus.Value = 5
            Dim thread As New Thread(New ThreadStart(AddressOf Me.UpdateInfoThread))
            Me.ProgressBarStatus.Value = 10
            thread.Start()
            Me.ListBoxVideoInfo.Items.Add("Getting Video Information...")
            Me.oldVideoURL = VideoURLTextBox.Text
        End If
    End Sub
    'Import Accounts
    Private Sub ImportAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportAccounts.Click
        OFDAccounts.Filter = ("Text Files|*.txt")
        If Me.OFDAccounts.ShowDialog() And Windows.Forms.DialogResult.OK Then
            Me.accountsFile = Me.OFDAccounts.FileName
            Dim streamread As New IO.StreamReader(OFDAccounts.FileName)
            While (streamread.Peek() > -1)
                ListBoxAccounts.Items.Add(streamread.ReadLine)
            End While
            streamread.Close()
            If (Me.accountsFile <> "") Then
                Me.addLog(("Loaded " & Me.ListBoxAccounts.Items.Count & " Accounts"))
            End If
        End If
    End Sub
    'Import Comments
    Private Sub ImportComments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportComments.Click
        OFDComments.Filter = ("Text Files|*.txt")
        If Me.OFDComments.ShowDialog() And Windows.Forms.DialogResult.OK Then

            Me.commentsFile = Me.OFDComments.FileName
            Dim streamread As New IO.StreamReader(OFDComments.FileName)
            While (streamread.Peek() > -1)
                ListBoxComments.Items.Add(streamread.ReadLine)
            End While
            streamread.Close()
            If (Me.accountsFile <> "") Then
                Me.addLog(("Loaded " & Me.ListBoxComments.Items.Count & " Comments"))
            End If
        End If
    End Sub
    'Start Button
    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click
        If Not Me.isVideoOK Then
            Me.addLog("Video is not OK!")
        ElseIf (Me.accountsFile = "") Then
            Me.addLog("No Accounts found!")
        ElseIf (Me.CheckComment.Checked = True And (Me.commentsFile = "")) Then
            Me.addLog("No Comments found!")
        ElseIf ((Me.proxiesFile = "") And Me.CheckUseProxies.Checked = True) Then
            Me.addLog("Proxies File not found!")
        Else
            Me.YWT = New Thread(New ThreadStart(AddressOf Me.YTWorkerThread1))
            Me.YWT.Start()
            Me.StopButton.Enabled = True
            Me.StartButton.Enabled = False
            Me.didWeStart = True
        End If
    End Sub
    'Stop
    Private Sub StopButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopButton.Click
        If Me.didWeStart Then
            Me.YWT.Abort()
            Me.StopButton.Enabled = False
            Me.StartButton.Enabled = True
            Me.addLog("Bot aborted!")
            Me.didWeStart = False
        End If
    End Sub

    Private Sub ProxiesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProxiesButton.Click
        If Me.OFDProxies.ShowDialog() And Windows.Forms.DialogResult.OK Then
            Me.proxiesFile = Me.OFDProxies.FileName
            If (Me.proxiesFile <> "") Then
                Me.addLog(("Loaded Proxies"))
            End If
        End If
    End Sub

    Private Sub CheckDislike_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDislike.CheckedChanged
        If CheckDislike.Checked = True Then
            CheckLike.Checked = False
            CheckLike.Enabled = False
        Else
            CheckLike.Enabled = True
        End If
    End Sub

    Private Sub CheckLike_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckLike.CheckedChanged
        If CheckLike.Checked = True Then
            CheckDislike.Checked = False
            CheckDislike.Enabled = False
        Else
            CheckDislike.Enabled = True
        End If
    End Sub

    Private Sub CheckFlag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFlag.CheckedChanged
        If CheckFlag.Checked = True Then
            ComboFlag.Enabled = True
        Else
            ComboFlag.Enabled = False
        End If
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        ListBoxLogs.Items.Clear()
    End Sub
End Class
