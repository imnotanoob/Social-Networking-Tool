<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YouTubeAPIBotForm
    Inherits DevComponents.DotNetBar.Office2007Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(YouTubeAPIBotForm))
        Me.StartButton = New DevComponents.DotNetBar.ButtonX()
        Me.StopButton = New DevComponents.DotNetBar.ButtonX()
        Me.CheckLike = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckDislike = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckComment = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckSubsribe = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckFavorite = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckFlag = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ComboFlag = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.ListBoxLogs = New System.Windows.Forms.ListBox()
        Me.VideoURLTextBox = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBoxVideoInfo = New System.Windows.Forms.ListBox()
        Me.ProgressBarStatus = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ImportAccounts = New DevComponents.DotNetBar.ButtonX()
        Me.ListBoxAccounts = New System.Windows.Forms.ListBox()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.ImportComments = New DevComponents.DotNetBar.ButtonX()
        Me.ListBoxComments = New System.Windows.Forms.ListBox()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CheckUseProxies = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ProxiesButton = New DevComponents.DotNetBar.ButtonX()
        Me.OFDAccounts = New System.Windows.Forms.OpenFileDialog()
        Me.OFDComments = New System.Windows.Forms.OpenFileDialog()
        Me.OFDProxies = New System.Windows.Forms.OpenFileDialog()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.StartButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.StartButton.FocusCuesEnabled = False
        Me.StartButton.Location = New System.Drawing.Point(3, 3)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(197, 22)
        Me.StartButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "Start"
        '
        'StopButton
        '
        Me.StopButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.StopButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.StopButton.Enabled = False
        Me.StopButton.FocusCuesEnabled = False
        Me.StopButton.Location = New System.Drawing.Point(3, 31)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(197, 22)
        Me.StopButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.StopButton.TabIndex = 1
        Me.StopButton.Text = "Stop"
        '
        'CheckLike
        '
        Me.CheckLike.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckLike.BackgroundStyle.Class = ""
        Me.CheckLike.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckLike.FocusCuesEnabled = False
        Me.CheckLike.Location = New System.Drawing.Point(3, 3)
        Me.CheckLike.Name = "CheckLike"
        Me.CheckLike.Size = New System.Drawing.Size(79, 23)
        Me.CheckLike.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckLike.TabIndex = 6
        Me.CheckLike.Text = "Like"
        '
        'CheckDislike
        '
        Me.CheckDislike.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckDislike.BackgroundStyle.Class = ""
        Me.CheckDislike.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckDislike.FocusCuesEnabled = False
        Me.CheckDislike.Location = New System.Drawing.Point(3, 32)
        Me.CheckDislike.Name = "CheckDislike"
        Me.CheckDislike.Size = New System.Drawing.Size(79, 23)
        Me.CheckDislike.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckDislike.TabIndex = 7
        Me.CheckDislike.Text = "Dislike"
        '
        'CheckComment
        '
        Me.CheckComment.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckComment.BackgroundStyle.Class = ""
        Me.CheckComment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckComment.FocusCuesEnabled = False
        Me.CheckComment.Location = New System.Drawing.Point(3, 61)
        Me.CheckComment.Name = "CheckComment"
        Me.CheckComment.Size = New System.Drawing.Size(79, 23)
        Me.CheckComment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckComment.TabIndex = 8
        Me.CheckComment.Text = "Comment"
        '
        'CheckSubsribe
        '
        Me.CheckSubsribe.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckSubsribe.BackgroundStyle.Class = ""
        Me.CheckSubsribe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckSubsribe.FocusCuesEnabled = False
        Me.CheckSubsribe.Location = New System.Drawing.Point(88, 3)
        Me.CheckSubsribe.Name = "CheckSubsribe"
        Me.CheckSubsribe.Size = New System.Drawing.Size(100, 23)
        Me.CheckSubsribe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckSubsribe.TabIndex = 9
        Me.CheckSubsribe.Text = "Subscribe"
        '
        'CheckFavorite
        '
        Me.CheckFavorite.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckFavorite.BackgroundStyle.Class = ""
        Me.CheckFavorite.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckFavorite.FocusCuesEnabled = False
        Me.CheckFavorite.Location = New System.Drawing.Point(88, 32)
        Me.CheckFavorite.Name = "CheckFavorite"
        Me.CheckFavorite.Size = New System.Drawing.Size(100, 23)
        Me.CheckFavorite.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckFavorite.TabIndex = 10
        Me.CheckFavorite.Text = "Favorite"
        '
        'CheckFlag
        '
        Me.CheckFlag.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckFlag.BackgroundStyle.Class = ""
        Me.CheckFlag.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckFlag.FocusCuesEnabled = False
        Me.CheckFlag.Location = New System.Drawing.Point(88, 61)
        Me.CheckFlag.Name = "CheckFlag"
        Me.CheckFlag.Size = New System.Drawing.Size(100, 23)
        Me.CheckFlag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckFlag.TabIndex = 11
        Me.CheckFlag.Text = "Flag"
        '
        'ComboFlag
        '
        Me.ComboFlag.DisplayMember = "Text"
        Me.ComboFlag.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboFlag.FormattingEnabled = True
        Me.ComboFlag.ItemHeight = 14
        Me.ComboFlag.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem4, Me.ComboItem5, Me.ComboItem6})
        Me.ComboFlag.Location = New System.Drawing.Point(3, 90)
        Me.ComboFlag.Name = "ComboFlag"
        Me.ComboFlag.Size = New System.Drawing.Size(197, 20)
        Me.ComboFlag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboFlag.TabIndex = 12
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Dangerous"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Hate"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "Porn"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "Right"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "Spam"
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "Violence"
        '
        'ListBoxLogs
        '
        Me.ListBoxLogs.FormattingEnabled = True
        Me.ListBoxLogs.Location = New System.Drawing.Point(246, 276)
        Me.ListBoxLogs.Name = "ListBoxLogs"
        Me.ListBoxLogs.Size = New System.Drawing.Size(387, 95)
        Me.ListBoxLogs.TabIndex = 13
        '
        'VideoURLTextBox
        '
        '
        '
        '
        Me.VideoURLTextBox.Border.Class = "TextBoxBorder"
        Me.VideoURLTextBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.VideoURLTextBox.Location = New System.Drawing.Point(77, 276)
        Me.VideoURLTextBox.Name = "VideoURLTextBox"
        Me.VideoURLTextBox.Size = New System.Drawing.Size(163, 20)
        Me.VideoURLTextBox.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 278)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Video URL:"
        '
        'ListBoxVideoInfo
        '
        Me.ListBoxVideoInfo.FormattingEnabled = True
        Me.ListBoxVideoInfo.Location = New System.Drawing.Point(12, 302)
        Me.ListBoxVideoInfo.Name = "ListBoxVideoInfo"
        Me.ListBoxVideoInfo.Size = New System.Drawing.Size(228, 82)
        Me.ListBoxVideoInfo.TabIndex = 16
        '
        'ProgressBarStatus
        '
        '
        '
        '
        Me.ProgressBarStatus.BackgroundStyle.Class = ""
        Me.ProgressBarStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarStatus.Location = New System.Drawing.Point(12, 387)
        Me.ProgressBarStatus.Name = "ProgressBarStatus"
        Me.ProgressBarStatus.Size = New System.Drawing.Size(228, 10)
        Me.ProgressBarStatus.TabIndex = 17
        Me.ProgressBarStatus.Text = "ProgressBarX1"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.ImportAccounts)
        Me.GroupPanel1.Controls.Add(Me.ListBoxAccounts)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(200, 258)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.Class = ""
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.Class = ""
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.Class = ""
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 18
        Me.GroupPanel1.Text = "Accounts"
        '
        'ImportAccounts
        '
        Me.ImportAccounts.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ImportAccounts.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ImportAccounts.FocusCuesEnabled = False
        Me.ImportAccounts.Location = New System.Drawing.Point(4, 211)
        Me.ImportAccounts.Name = "ImportAccounts"
        Me.ImportAccounts.Size = New System.Drawing.Size(187, 23)
        Me.ImportAccounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ImportAccounts.TabIndex = 1
        Me.ImportAccounts.Text = "Import Account(s)"
        '
        'ListBoxAccounts
        '
        Me.ListBoxAccounts.FormattingEnabled = True
        Me.ListBoxAccounts.Location = New System.Drawing.Point(4, 4)
        Me.ListBoxAccounts.Name = "ListBoxAccounts"
        Me.ListBoxAccounts.Size = New System.Drawing.Size(187, 199)
        Me.ListBoxAccounts.TabIndex = 0
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.ImportComments)
        Me.GroupPanel2.Controls.Add(Me.ListBoxComments)
        Me.GroupPanel2.Location = New System.Drawing.Point(218, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(200, 258)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.Class = ""
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.Class = ""
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.Class = ""
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 19
        Me.GroupPanel2.Text = "Comments"
        '
        'ImportComments
        '
        Me.ImportComments.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ImportComments.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ImportComments.FocusCuesEnabled = False
        Me.ImportComments.Location = New System.Drawing.Point(4, 211)
        Me.ImportComments.Name = "ImportComments"
        Me.ImportComments.Size = New System.Drawing.Size(187, 23)
        Me.ImportComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ImportComments.TabIndex = 1
        Me.ImportComments.Text = "Import Comment(s)"
        '
        'ListBoxComments
        '
        Me.ListBoxComments.FormattingEnabled = True
        Me.ListBoxComments.Location = New System.Drawing.Point(4, 4)
        Me.ListBoxComments.Name = "ListBoxComments"
        Me.ListBoxComments.Size = New System.Drawing.Size(187, 199)
        Me.ListBoxComments.TabIndex = 0
        '
        'GroupPanel3
        '
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.CheckLike)
        Me.GroupPanel3.Controls.Add(Me.CheckDislike)
        Me.GroupPanel3.Controls.Add(Me.CheckComment)
        Me.GroupPanel3.Controls.Add(Me.CheckSubsribe)
        Me.GroupPanel3.Controls.Add(Me.CheckFavorite)
        Me.GroupPanel3.Controls.Add(Me.CheckFlag)
        Me.GroupPanel3.Controls.Add(Me.ComboFlag)
        Me.GroupPanel3.Location = New System.Drawing.Point(424, 12)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(209, 141)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.Class = ""
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.Class = ""
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.Class = ""
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 20
        Me.GroupPanel3.Text = "Functions"
        '
        'GroupPanel4
        '
        Me.GroupPanel4.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.CheckUseProxies)
        Me.GroupPanel4.Controls.Add(Me.ProxiesButton)
        Me.GroupPanel4.Controls.Add(Me.StartButton)
        Me.GroupPanel4.Controls.Add(Me.StopButton)
        Me.GroupPanel4.Location = New System.Drawing.Point(424, 160)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(209, 110)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.Class = ""
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.Class = ""
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.Class = ""
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 21
        Me.GroupPanel4.Text = "Buttons"
        '
        'CheckUseProxies
        '
        Me.CheckUseProxies.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CheckUseProxies.BackgroundStyle.Class = ""
        Me.CheckUseProxies.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckUseProxies.FocusCuesEnabled = False
        Me.CheckUseProxies.Location = New System.Drawing.Point(106, 59)
        Me.CheckUseProxies.Name = "CheckUseProxies"
        Me.CheckUseProxies.Size = New System.Drawing.Size(94, 23)
        Me.CheckUseProxies.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckUseProxies.TabIndex = 13
        Me.CheckUseProxies.Text = "Enable Proxies"
        '
        'ProxiesButton
        '
        Me.ProxiesButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ProxiesButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ProxiesButton.FocusCuesEnabled = False
        Me.ProxiesButton.Location = New System.Drawing.Point(3, 59)
        Me.ProxiesButton.Name = "ProxiesButton"
        Me.ProxiesButton.Size = New System.Drawing.Size(100, 23)
        Me.ProxiesButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ProxiesButton.TabIndex = 2
        Me.ProxiesButton.Text = "Import Proxies"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Enabled = False
        Me.ButtonX1.FocusCuesEnabled = False
        Me.ButtonX1.Location = New System.Drawing.Point(246, 375)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(387, 22)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 22
        Me.ButtonX1.Text = "Clear Log"
        '
        'YouTubeAPIBotForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 404)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.GroupPanel4)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.ProgressBarStatus)
        Me.Controls.Add(Me.ListBoxVideoInfo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.VideoURLTextBox)
        Me.Controls.Add(Me.ListBoxLogs)
        Me.DoubleBuffered = True
        Me.EnableGlass = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "YouTubeAPIBotForm"
        Me.Text = "MyToobs API Bot"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents StopButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CheckLike As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckDislike As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckComment As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckSubsribe As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckFavorite As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckFlag As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ComboFlag As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ListBoxLogs As System.Windows.Forms.ListBox
    Friend WithEvents VideoURLTextBox As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBoxVideoInfo As System.Windows.Forms.ListBox
    Friend WithEvents ProgressBarStatus As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ListBoxAccounts As System.Windows.Forms.ListBox
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ListBoxComments As System.Windows.Forms.ListBox
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ProxiesButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents OFDAccounts As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OFDComments As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ImportAccounts As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ImportComments As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CheckUseProxies As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents OFDProxies As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX

End Class
