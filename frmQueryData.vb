Imports wf = System.Windows.Forms
Imports str = System.Text.RegularExpressions

Public Enum StatusTypes
    Currently
    Ever
End Enum
Public Class frmQueryData
    Inherits System.Windows.Forms.Form


    ' My intention w/this regex is to 

    ' Public CodePattern As New System.Text.RegularExpressions.Regex("(\b(?<AccLetter>[B-FV][A-ZG]?)-?(?<AccNumber>\d{4})\b)+", System.Text.RegularExpressions.RegexOptions.Compiled Or System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    Public CodePattern As New str.Regex("(\b(?<AccLetter>(V[GM]|[XYZ][A-Z]|[BCDEF][A-GJ-NP-Z]|[A-M]))-?(?<AccNumber>\d{4})\b)+" _
            , System.Text.RegularExpressions.RegexOptions.Compiled Or _
            System.Text.RegularExpressions.RegexOptions.IgnoreCase)

    ' Test out saving status off to a member var & waiting 
    ' until form.load to set the control.
    Private Stat As Object
    Private Prog As Object
    Private Tick As Object
    Private m_ContactDate As DateTime
    Private m_NumTarget As Integer
    Private m_NumKroger As Integer

    Private m_NumIGP As Integer
    Private m_NumNetwork As Integer
    Private m_NumNetSmok As Integer

    Private m_txtAccLetter As String = String.Empty
    Private m_txtAccNumber As String = String.Empty

    Friend WithEvents tcQueryParameters As System.Windows.Forms.TabControl
    Friend WithEvents tpCommon As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbTickle As System.Windows.Forms.ComboBox
    Friend WithEvents btnAccessCodeListBuilder As System.Windows.Forms.Button
    Friend WithEvents chkUseNameList As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseQueriedAccessCodeList As System.Windows.Forms.CheckBox
    Friend WithEvents btnUseNameList As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tpLessCommon As System.Windows.Forms.TabPage
    Friend WithEvents cmbSex As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbRecruitProgVersion As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBirthDay As System.Windows.Forms.TextBox
    Friend WithEvents btnPopContactDatePicker As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtContactDate As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnShowBDayPicker As System.Windows.Forms.Button
    Friend WithEvents cbStatusType As System.Windows.Forms.ComboBox
    Friend WithEvents txtAccCode As System.Windows.Forms.TextBox
    Friend WithEvents chkLimitPersonTypes As System.Windows.Forms.CheckBox
    Private m_NumStarbucks As Integer

    ' Private m_booUseQueriedAccessCodeList As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        BindStatusCombo()
        BindTicklerCombo()

    With Me.cmbRecruitProgVersion
      .DisplayMember = "SamplingProgramVersions.Notes"
      .ValueMember = "SamplingProgramVersions.RecruitProgVersion"
      .DataSource = TrackerApp.Tracker1
      .SelectedItem = Nothing
    End With

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents btnQuery As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents epInfo As System.Windows.Forms.ErrorProvider
  Friend WithEvents ep As System.Windows.Forms.ErrorProvider
  Friend WithEvents btnClear As System.Windows.Forms.Button
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents txtMaxRecs As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQueryData))
    Me.btnCancel = New System.Windows.Forms.Button
    Me.btnQuery = New System.Windows.Forms.Button
    Me.epInfo = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.btnAccessCodeListBuilder = New System.Windows.Forms.Button
    Me.txtLastName = New System.Windows.Forms.TextBox
    Me.txtFirstName = New System.Windows.Forms.TextBox
    Me.ep = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.btnClear = New System.Windows.Forms.Button
    Me.txtMaxRecs = New System.Windows.Forms.TextBox
    Me.Label10 = New System.Windows.Forms.Label
    Me.Label11 = New System.Windows.Forms.Label
    Me.tcQueryParameters = New System.Windows.Forms.TabControl
    Me.tpCommon = New System.Windows.Forms.TabPage
    Me.txtAccCode = New System.Windows.Forms.TextBox
    Me.cbStatusType = New System.Windows.Forms.ComboBox
    Me.Label9 = New System.Windows.Forms.Label
    Me.chkLimitPersonTypes = New System.Windows.Forms.CheckBox
    Me.Label13 = New System.Windows.Forms.Label
    Me.cmbTickle = New System.Windows.Forms.ComboBox
    Me.chkUseNameList = New System.Windows.Forms.CheckBox
    Me.chkUseQueriedAccessCodeList = New System.Windows.Forms.CheckBox
    Me.btnUseNameList = New System.Windows.Forms.Button
    Me.Label4 = New System.Windows.Forms.Label
    Me.cmbStatus = New System.Windows.Forms.ComboBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.tpLessCommon = New System.Windows.Forms.TabPage
    Me.cmbSex = New System.Windows.Forms.ComboBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.cmbRecruitProgVersion = New System.Windows.Forms.ComboBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.txtBirthDay = New System.Windows.Forms.TextBox
    Me.btnPopContactDatePicker = New System.Windows.Forms.Button
    Me.Label7 = New System.Windows.Forms.Label
    Me.txtContactDate = New System.Windows.Forms.TextBox
    Me.Label12 = New System.Windows.Forms.Label
    Me.btnShowBDayPicker = New System.Windows.Forms.Button
    CType(Me.epInfo, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ep, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.tcQueryParameters.SuspendLayout()
    Me.tpCommon.SuspendLayout()
    Me.tpLessCommon.SuspendLayout()
    Me.SuspendLayout()
    '
    'btnCancel
    '
    Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.btnCancel.CausesValidation = False
    Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnCancel.Location = New System.Drawing.Point(30, 343)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(75, 23)
    Me.btnCancel.TabIndex = 5
    Me.btnCancel.Text = "&Cancel"
    '
    'btnQuery
    '
    Me.btnQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnQuery.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnQuery.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnQuery.Location = New System.Drawing.Point(570, 343)
    Me.btnQuery.Name = "btnQuery"
    Me.btnQuery.Size = New System.Drawing.Size(88, 23)
    Me.btnQuery.TabIndex = 0
    Me.btnQuery.Text = "&Fetch Data"
    '
    'epInfo
    '
    Me.epInfo.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
    Me.epInfo.ContainerControl = Me
    Me.epInfo.Icon = CType(resources.GetObject("epInfo.Icon"), System.Drawing.Icon)
    '
    'btnAccessCodeListBuilder
    '
    Me.epInfo.SetIconPadding(Me.btnAccessCodeListBuilder, 10)
    Me.btnAccessCodeListBuilder.Location = New System.Drawing.Point(392, 21)
    Me.btnAccessCodeListBuilder.Name = "btnAccessCodeListBuilder"
    Me.btnAccessCodeListBuilder.Size = New System.Drawing.Size(80, 24)
    Me.btnAccessCodeListBuilder.TabIndex = 3
    Me.btnAccessCodeListBuilder.Text = "Build List..."
    '
    'txtLastName
    '
    Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.epInfo.SetIconAlignment(Me.txtLastName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
    Me.txtLastName.Location = New System.Drawing.Point(184, 126)
    Me.txtLastName.Name = "txtLastName"
    Me.txtLastName.Size = New System.Drawing.Size(201, 23)
    Me.txtLastName.TabIndex = 13
    '
    'txtFirstName
    '
    Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.epInfo.SetIconAlignment(Me.txtFirstName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
    Me.txtFirstName.Location = New System.Drawing.Point(184, 92)
    Me.txtFirstName.Name = "txtFirstName"
    Me.txtFirstName.Size = New System.Drawing.Size(201, 23)
    Me.txtFirstName.TabIndex = 9
    '
    'ep
    '
    Me.ep.ContainerControl = Me
    '
    'btnClear
    '
    Me.btnClear.CausesValidation = False
    Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnClear.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnClear.Location = New System.Drawing.Point(583, 32)
    Me.btnClear.Name = "btnClear"
    Me.btnClear.Size = New System.Drawing.Size(75, 23)
    Me.btnClear.TabIndex = 4
    Me.btnClear.TabStop = False
    Me.btnClear.Text = "&Clear All"
    '
    'txtMaxRecs
    '
    Me.txtMaxRecs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.txtMaxRecs.Location = New System.Drawing.Point(122, 316)
    Me.txtMaxRecs.Name = "txtMaxRecs"
    Me.txtMaxRecs.Size = New System.Drawing.Size(39, 23)
    Me.txtMaxRecs.TabIndex = 4
    '
    'Label10
    '
    Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(29, 321)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(86, 16)
    Me.Label10.TabIndex = 39
    Me.Label10.Text = "Fetch at most"
    '
    'Label11
    '
    Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(170, 321)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(92, 16)
    Me.Label11.TabIndex = 40
    Me.Label11.Text = "recruit records"
    '
    'tcQueryParameters
    '
    Me.tcQueryParameters.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.tcQueryParameters.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
    Me.tcQueryParameters.Controls.Add(Me.tpCommon)
    Me.tcQueryParameters.Controls.Add(Me.tpLessCommon)
    Me.tcQueryParameters.HotTrack = True
    Me.tcQueryParameters.Location = New System.Drawing.Point(27, 61)
    Me.tcQueryParameters.Name = "tcQueryParameters"
    Me.tcQueryParameters.SelectedIndex = 0
    Me.tcQueryParameters.ShowToolTips = True
    Me.tcQueryParameters.Size = New System.Drawing.Size(635, 250)
    Me.tcQueryParameters.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
    Me.tcQueryParameters.TabIndex = 3
    '
    'tpCommon
    '
    Me.tpCommon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.tpCommon.Controls.Add(Me.txtAccCode)
    Me.tpCommon.Controls.Add(Me.cbStatusType)
    Me.tpCommon.Controls.Add(Me.Label9)
    Me.tpCommon.Controls.Add(Me.chkLimitPersonTypes)
    Me.tpCommon.Controls.Add(Me.Label13)
    Me.tpCommon.Controls.Add(Me.cmbTickle)
    Me.tpCommon.Controls.Add(Me.btnAccessCodeListBuilder)
    Me.tpCommon.Controls.Add(Me.chkUseNameList)
    Me.tpCommon.Controls.Add(Me.chkUseQueriedAccessCodeList)
    Me.tpCommon.Controls.Add(Me.btnUseNameList)
    Me.tpCommon.Controls.Add(Me.Label4)
    Me.tpCommon.Controls.Add(Me.cmbStatus)
    Me.tpCommon.Controls.Add(Me.txtLastName)
    Me.tpCommon.Controls.Add(Me.Label2)
    Me.tpCommon.Controls.Add(Me.txtFirstName)
    Me.tpCommon.Controls.Add(Me.Label3)
    Me.tpCommon.Location = New System.Drawing.Point(4, 28)
    Me.tpCommon.Name = "tpCommon"
    Me.tpCommon.Padding = New System.Windows.Forms.Padding(3)
    Me.tpCommon.Size = New System.Drawing.Size(627, 218)
    Me.tpCommon.TabIndex = 0
    Me.tpCommon.Text = "Common Parameters"
    Me.tpCommon.ToolTipText = "The most common things to specify"
    Me.tpCommon.UseVisualStyleBackColor = True
    '
    'txtAccCode
    '
    Me.txtAccCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtAccCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtAccCode.Location = New System.Drawing.Point(184, 22)
    Me.txtAccCode.Name = "txtAccCode"
    Me.txtAccCode.Size = New System.Drawing.Size(75, 23)
    Me.txtAccCode.TabIndex = 2
    '
    'cbStatusType
    '
    Me.cbStatusType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cbStatusType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cbStatusType.FormattingEnabled = True
    Me.cbStatusType.Items.AddRange(New Object() {"Ever", "Currently"})
    Me.cbStatusType.Location = New System.Drawing.Point(389, 59)
    Me.cbStatusType.Name = "cbStatusType"
    Me.cbStatusType.Size = New System.Drawing.Size(97, 24)
    Me.cbStatusType.TabIndex = 7
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(47, 28)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(127, 16)
    Me.Label9.TabIndex = 37
    Me.Label9.Text = "Having Access Code:"
    '
    'chkLimitPersonTypes
    '
    Me.chkLimitPersonTypes.Enabled = False
    Me.chkLimitPersonTypes.Location = New System.Drawing.Point(404, 162)
    Me.chkLimitPersonTypes.Name = "chkLimitPersonTypes"
    Me.chkLimitPersonTypes.Size = New System.Drawing.Size(164, 20)
    Me.chkLimitPersonTypes.TabIndex = 16
    Me.chkLimitPersonTypes.Text = "Limit person types"
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(92, 162)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(83, 16)
    Me.Label13.TabIndex = 14
    Me.Label13.Text = "Who need...:"
    '
    'cmbTickle
    '
    Me.cmbTickle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.cmbTickle.Location = New System.Drawing.Point(184, 158)
    Me.cmbTickle.Name = "cmbTickle"
    Me.cmbTickle.Size = New System.Drawing.Size(201, 24)
    Me.cmbTickle.TabIndex = 15
    '
    'chkUseNameList
    '
    Me.chkUseNameList.Location = New System.Drawing.Point(484, 90)
    Me.chkUseNameList.Name = "chkUseNameList"
    Me.chkUseNameList.Size = New System.Drawing.Size(69, 24)
    Me.chkUseNameList.TabIndex = 11
    Me.chkUseNameList.Text = "Use list"
    '
    'chkUseQueriedAccessCodeList
    '
    Me.chkUseQueriedAccessCodeList.Location = New System.Drawing.Point(484, 22)
    Me.chkUseQueriedAccessCodeList.Name = "chkUseQueriedAccessCodeList"
    Me.chkUseQueriedAccessCodeList.Size = New System.Drawing.Size(69, 24)
    Me.chkUseQueriedAccessCodeList.TabIndex = 4
    Me.chkUseQueriedAccessCodeList.Text = "Use list"
    '
    'btnUseNameList
    '
    Me.btnUseNameList.Location = New System.Drawing.Point(392, 90)
    Me.btnUseNameList.Name = "btnUseNameList"
    Me.btnUseNameList.Size = New System.Drawing.Size(80, 24)
    Me.btnUseNameList.TabIndex = 10
    Me.btnUseNameList.Text = "Build List..."
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(39, 128)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(135, 16)
    Me.Label4.TabIndex = 12
    Me.Label4.Text = "With Last Names Like:"
    '
    'cmbStatus
    '
    Me.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cmbStatus.Location = New System.Drawing.Point(184, 59)
    Me.cmbStatus.Name = "cmbStatus"
    Me.cmbStatus.Size = New System.Drawing.Size(201, 24)
    Me.cmbStatus.TabIndex = 6
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(94, 64)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(79, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "With Status:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(38, 94)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(137, 16)
    Me.Label3.TabIndex = 8
    Me.Label3.Text = "With First Names Like:"
    '
    'tpLessCommon
    '
    Me.tpLessCommon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.tpLessCommon.Controls.Add(Me.cmbSex)
    Me.tpLessCommon.Controls.Add(Me.Label5)
    Me.tpLessCommon.Controls.Add(Me.cmbRecruitProgVersion)
    Me.tpLessCommon.Controls.Add(Me.Label6)
    Me.tpLessCommon.Controls.Add(Me.txtBirthDay)
    Me.tpLessCommon.Controls.Add(Me.btnPopContactDatePicker)
    Me.tpLessCommon.Controls.Add(Me.Label7)
    Me.tpLessCommon.Controls.Add(Me.txtContactDate)
    Me.tpLessCommon.Controls.Add(Me.Label12)
    Me.tpLessCommon.Controls.Add(Me.btnShowBDayPicker)
    Me.tpLessCommon.Location = New System.Drawing.Point(4, 28)
    Me.tpLessCommon.Name = "tpLessCommon"
    Me.tpLessCommon.Padding = New System.Windows.Forms.Padding(3)
    Me.tpLessCommon.Size = New System.Drawing.Size(627, 218)
    Me.tpLessCommon.TabIndex = 1
    Me.tpLessCommon.Text = "More"
    Me.tpLessCommon.ToolTipText = "Additional query parameters you can specify"
    Me.tpLessCommon.UseVisualStyleBackColor = True
    '
    'cmbSex
    '
    Me.cmbSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cmbSex.Items.AddRange(New Object() {"M", "F", "U"})
    Me.cmbSex.Location = New System.Drawing.Point(186, 24)
    Me.cmbSex.Name = "cmbSex"
    Me.cmbSex.Size = New System.Drawing.Size(108, 24)
    Me.cmbSex.TabIndex = 5
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(83, 29)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(96, 16)
    Me.Label5.TabIndex = 23
    Me.Label5.Text = "Having Gender:"
    '
    'cmbRecruitProgVersion
    '
    Me.cmbRecruitProgVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.cmbRecruitProgVersion.Location = New System.Drawing.Point(186, 61)
    Me.cmbRecruitProgVersion.Name = "cmbRecruitProgVersion"
    Me.cmbRecruitProgVersion.Size = New System.Drawing.Size(200, 24)
    Me.cmbRecruitProgVersion.TabIndex = 6
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(5, 66)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(180, 16)
    Me.Label6.TabIndex = 25
    Me.Label6.Text = "Sampled by Program Version:"
    '
    'txtBirthDay
    '
    Me.txtBirthDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtBirthDay.Location = New System.Drawing.Point(186, 98)
    Me.txtBirthDay.Name = "txtBirthDay"
    Me.txtBirthDay.Size = New System.Drawing.Size(168, 23)
    Me.txtBirthDay.TabIndex = 7
    '
    'btnPopContactDatePicker
    '
    Me.btnPopContactDatePicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnPopContactDatePicker.Location = New System.Drawing.Point(358, 132)
    Me.btnPopContactDatePicker.Name = "btnPopContactDatePicker"
    Me.btnPopContactDatePicker.Size = New System.Drawing.Size(32, 24)
    Me.btnPopContactDatePicker.TabIndex = 39
    Me.btnPopContactDatePicker.Text = "..."
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(72, 98)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(106, 16)
    Me.Label7.TabIndex = 26
    Me.Label7.Text = "Having Birthdate:"
    '
    'txtContactDate
    '
    Me.txtContactDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtContactDate.Location = New System.Drawing.Point(186, 132)
    Me.txtContactDate.Name = "txtContactDate"
    Me.txtContactDate.Size = New System.Drawing.Size(168, 23)
    Me.txtContactDate.TabIndex = 38
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(38, 132)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(143, 16)
    Me.Label12.TabIndex = 40
    Me.Label12.Text = "Who was contacted on:"
    '
    'btnShowBDayPicker
    '
    Me.btnShowBDayPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnShowBDayPicker.Location = New System.Drawing.Point(358, 98)
    Me.btnShowBDayPicker.Name = "btnShowBDayPicker"
    Me.btnShowBDayPicker.Size = New System.Drawing.Size(32, 24)
    Me.btnShowBDayPicker.TabIndex = 8
    Me.btnShowBDayPicker.Text = "..."
    '
    'frmQueryData
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
    Me.ClientSize = New System.Drawing.Size(697, 379)
    Me.Controls.Add(Me.tcQueryParameters)
    Me.Controls.Add(Me.btnClear)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.txtMaxRecs)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.btnQuery)
    Me.Controls.Add(Me.btnCancel)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "frmQueryData"
    Me.ShowInTaskbar = False
    Me.Text = "Fetch Recruit Data from the Server"
    CType(Me.epInfo, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ep, System.ComponentModel.ISupportInitialize).EndInit()
    Me.tcQueryParameters.ResumeLayout(False)
    Me.tpCommon.ResumeLayout(False)
    Me.tpCommon.PerformLayout()
    Me.tpLessCommon.ResumeLayout(False)
    Me.tpLessCommon.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub frmQueryData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If (Not Stat Is Nothing) AndAlso IsNumeric(Stat) Then
      Me.cmbStatus.SelectedValue = CType(Stat, Integer)
    Else
      Me.cmbStatus.SelectedItem = Nothing
    End If

    If (Not Prog Is Nothing) AndAlso IsNumeric(Prog) Then
      Me.cmbRecruitProgVersion.SelectedIndex = CType(Prog, Integer)
    Else
      Me.cmbRecruitProgVersion.SelectedItem = Nothing
    End If

    If TypeOf Tick Is String AndAlso Tick.ToString.Length > 0 Then
      Me.cmbTickle.SelectedItem = Tick
    Else
      Me.cmbTickle.SelectedItem = Nothing
      Me.cmbTickle.SelectedItem = Nothing
    End If

    With Me.epInfo
      .SetError(Me.txtFirstName, "You can just type the first few characters of the " _
         & "name--so 'Ter' will return matches for 'Terry', 'Terri', 'Teresea', etc.")
      .SetError(Me.txtLastName, "You can just type the first few characters of the " _
         & "name--so 'Jon' will return matches for 'Jones', 'Jonson', etc.")
      .SetError(Me.btnPopContactDatePicker, "Click the button at left to select a value from the list of all contacts to date.")
      .SetError(Me.chkLimitPersonTypes, "This is for specifying the # of Network/IGP type people you want.")
    End With

  End Sub

  Private Sub btnShowBDayPicker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowBDayPicker.Click
    Dim picker As New frmDateTimePicker
    If picker.ShowDialog = wf.DialogResult.OK Then
      Me.txtBirthDay.Text = picker.DateTime.ToShortDateString
    End If
  End Sub

  'Public Property GetUpdatedAddresses() As Boolean
  '  Get
  '    Return Me.chkGetUpdatedAddresses.Checked
  '  End Get
  '  Set(ByVal Value As Boolean)
  '    Me.chkGetUpdatedAddresses.Checked = Value
  '  End Set
  'End Property

  'Public Property GetReminderEligibles() As Boolean
  '  Get
  '    Return Me.chkReminderEligible.Checked
  '  End Get
  '  Set(ByVal Value As Boolean)
  '    Me.chkReminderEligible.Checked = Value
  '  End Set
  'End Property

  Public Property UseQueriedNameList() As Boolean
    Get
      Return Me.chkUseNameList.Checked
    End Get
    Set(ByVal Value As Boolean)
      Me.chkUseNameList.Checked = Value
    End Set
  End Property

  Public Property UseQueriedAccessCodeList() As Boolean
    Get
      Return Me.chkUseQueriedAccessCodeList.Checked
    End Get
    Set(ByVal Value As Boolean)
      Me.chkUseQueriedAccessCodeList.Checked = Value
    End Set
  End Property

  Public Property ProgVersionIs() As Object
    Get
      Dim drv As DataRowView
      Dim p As TrackerData.SamplingProgramVersionsRow
      drv = CType(Me.cmbRecruitProgVersion.SelectedItem, DataRowView)
      If drv Is Nothing Then
        Return DBNull.Value
        Prog = Nothing
      Else
        p = CType(drv.Row, TrackerData.SamplingProgramVersionsRow)
        Return p.RecruitProgVersion
      End If
    End Get
    Set(ByVal Value As Object)
      Me.cmbRecruitProgVersion.SelectedItem = Value
      Prog = Value
    End Set
  End Property

  Public Property TicklerToBeDone() As Object
    Get
      Dim drv As DataRowView
      Dim t As TrackerData.TicklerRow
      drv = CType(Me.cmbTickle.SelectedItem, DataRowView)
      If drv Is Nothing Then
        Return DBNull.Value
        Tick = Nothing
      Else
        t = CType(drv.Row, TrackerData.TicklerRow)
        Return t.ToBeDone
      End If
    End Get
    Set(ByVal Value As Object)
      If TypeOf Value Is String AndAlso Value.ToString.Length > 0 Then
        ' wtf?
        ' If Not Me.cmbTickle.SelectedValue Is Nothing Then
        Me.cmbTickle.SelectedValue = Value

        ' End If
        Tick = Value
        Me.chkLimitPersonTypes.Enabled = True
      Else
        Me.chkLimitPersonTypes.Enabled = False
      End If
    End Set
  End Property

  Public Property AccLetterIs() As Object
    Get
      If Me.m_txtAccLetter.Length = 0 Then
        Return DBNull.Value
      Else
        Return Me.m_txtAccLetter
      End If
      'With Me.txtAccLetter
      '  If .Text.Length > 0 Then
      '    Return .Text
      '  Else
      '    Return DBNull.Value
      '  End If
      'End With
    End Get
    Set(ByVal Value As Object)
      If (Not Value Is Nothing) AndAlso Value.GetType.Name = "String" Then
        Me.m_txtAccLetter = Value.ToString
      End If
    End Set
  End Property

  Public Property AccNumberIs() As Object
    Get
      If Me.m_txtAccNumber.Length = 0 Then
        Return DBNull.Value
      Else
        Return Me.m_txtAccNumber
      End If
      'If IsNumeric(Me.txtAccNumber.Text) Then
      '  Return Me.txtAccNumber.Text
      'Else
      '  Return DBNull.Value
      'End If
    End Get
    Set(ByVal Value As Object)
      If IsNumeric(Value) AndAlso CType(Value, Integer) > 0 Then
        Me.m_txtAccNumber = Value.ToString
      End If
    End Set
  End Property

  Public Sub SetAccCode()
    If Me.m_txtAccLetter.Length > 0 Then
      Me.txtAccCode.Text = Me.m_txtAccLetter & "-" & Me.m_txtAccNumber
    End If
  End Sub

  Public Property BirthDate() As Object
    Get
      If Me.txtBirthDay.Text.Length > 0 AndAlso IsDate(Me.txtBirthDay.Text) Then
        Return DateTime.Parse(Me.txtBirthDay.Text)
      Else
        Return DBNull.Value
      End If
    End Get
    Set(ByVal Value As Object)
      'If IsDate(Value) AndAlso CType(Value, DateTime) > DateTime.MinValue Then
      '   Me.txtBirthDay.Text = CType(Value, DateTime).ToShortDateString
      'End If
      ' IsDate() causes exceptions when passed an empty string--I'm coding around that for perf reasons.
      If TypeOf Value Is String Then
        If Value.ToString.Length = 0 Then Return
      Else
        If IsDate(Value) Then
          If CType(Value, DateTime) > DateTime.MinValue Then
            Me.txtBirthDay.Text = CType(Value, DateTime).ToShortDateString
          End If
        End If
      End If
    End Set
  End Property

  Public Property ContactDate() As Object
    Get
      If m_ContactDate > DateTime.MinValue Then
        Return m_ContactDate
      Else
        Return DBNull.Value
      End If
      'If IsDate(Me.txtContactDate.Text) Then
      '   Return DateTime.Parse(Me.txtContactDate.Text)
      'Else
      '   Return DBNull.Value
      'End If
    End Get
    Set(ByVal Value As Object)
      If IsDate(Value) AndAlso CType(Value, DateTime) > DateTime.MinValue Then
        m_ContactDate = CType(Value, DateTime)
        Me.txtContactDate.Text = m_ContactDate.ToString
      End If
    End Set
  End Property

  Public Property NumTarget() As Integer
    Set(ByVal Value As Integer)
      m_NumTarget = Value
    End Set
    Get
      Return Me.m_NumTarget
    End Get
  End Property

  Public Property NumIGP() As Integer
    Get
      Return Me.m_NumIGP
    End Get
    Set(ByVal value As Integer)
      Me.m_NumIGP = value
    End Set
  End Property

  Public Property NumNetwork() As Integer
    Get
      Return Me.m_NumNetwork
    End Get
    Set(ByVal value As Integer)
      Me.m_NumNetwork = value
    End Set
  End Property
  Public Property NumNetSmok() As Integer
    Get
      Return Me.m_NumNetSmok
    End Get
    Set(ByVal value As Integer)
      Me.m_NumNetSmok = value
    End Set
  End Property
  Public Property NumKroger() As Integer
    Get
      Return Me.m_NumKroger
    End Get
    Set(ByVal Value As Integer)
      m_NumKroger = Value
    End Set
  End Property

  Public Property NumStarbucks() As Integer
    Get
      Return Me.m_NumStarbucks
    End Get
    Set(ByVal Value As Integer)
      m_NumStarbucks = Value
    End Set
  End Property

  Public Property MaxRecs() As Object
    Get
      If IsNumeric(Me.txtMaxRecs.Text) AndAlso Integer.Parse(Me.txtMaxRecs.Text) > 0 Then
        Return Integer.Parse(Me.txtMaxRecs.Text)
      Else
        Return DBNull.Value
      End If
    End Get
    Set(ByVal Value As Object)
      If IsNumeric(Value) AndAlso CType(Value, Integer) > 0 Then
        Me.txtMaxRecs.Text = CType(Value, Integer).ToString
      End If
    End Set
  End Property

  'Public Property ForStudy() As Int16
  '   Get
  '      Return CType(Me.cmbStudy.SelectedItem, Int16)
  '   End Get
  '   Set(ByVal Value As Int16)
  '      Me.cmbStudy.SelectedItem = Value
  '   End Set
  'End Property

  Public Property FirstNameLike() As Object
    Get
      If Me.txtFirstName.Text.Length > 0 Then
        Return Me.txtFirstName.Text & "%"
      Else
        ' Return Me.txtFirstName.Text
        Return DBNull.Value
      End If
    End Get
    Set(ByVal Value As Object)
      Dim val As String = String.Empty
      If (Not Value Is Nothing) AndAlso Value.GetType.Name = "String" Then
        val = CType(Value, String)
      End If
      With Me.txtFirstName
        If val.EndsWith("%") Then
          val = val.TrimEnd(New Char() {"%"c})
        End If
        .Text = val
      End With
    End Set
  End Property

  Public Property LastNameLike() As Object
    Get
      With Me.txtLastName
        If .Text.Length > 0 Then
          Return .Text & "%"
        Else
          Return DBNull.Value
        End If
      End With
    End Get
    Set(ByVal Value As Object)
      Dim val As String = String.Empty
      If (Not Value Is Nothing) AndAlso Value.GetType.Name = "String" Then
        val = CType(Value, String)
      End If
      With Me.txtLastName
        If val.EndsWith("%") Then
          val = val.TrimEnd(New Char() {"%"c})
        End If
        .Text = val
      End With
    End Set
  End Property

  Public Property Status() As Object
    Get
      Dim drv As DataRowView
      Dim s As TrackerData.StatusesRow
      drv = CType(Me.cmbStatus.SelectedItem, DataRowView)
      If drv Is Nothing Then
        Return DBNull.Value
      Else
        s = CType(drv.Row, TrackerData.StatusesRow)
        Return s.Status
      End If
    End Get
    Set(ByVal Value As Object)
      Stat = Value
    End Set
  End Property

  Public Property StatusType() As Object
    Get
      Select Case cbStatusType.Text
        Case StatusTypes.Currently.ToString
          Return StatusTypes.Currently
        Case StatusTypes.Ever.ToString
          Return StatusTypes.Ever.ToString
        Case Else
          Return DBNull.Value
      End Select
    End Get
    Set(ByVal value As Object)
      If value Is Nothing Then
        Me.cbStatusType.Text = StatusTypes.Currently.ToString
      Else
        Me.cbStatusType.Text = value.ToString
      End If
    End Set
  End Property

  Public Property SexIs() As Object
    Get
      If Me.cmbSex.SelectedItem Is Nothing Then
        Return DBNull.Value
      Else
        Return CType(Me.cmbSex.SelectedItem, String)
      End If
    End Get
    Set(ByVal Value As Object)
      Me.cmbSex.SelectedItem = Value
    End Set
  End Property

  'Private Sub txtAccLetter_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
  '  With txtAccLetter
  '    If .Text.Length > 0 Then
  '      Select Case .Text
  '        Case "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M"
  '          Me.ep.SetError(Me.txtAccLetter, "")
  '        Case Else
  '          Me.ep.SetError(Me.txtAccLetter, "Access codes for GHC people start with letters between A and M")
  '          e.Cancel = True
  '      End Select
  '    End If
  '  End With
  'End Sub

  Private Sub txtAccCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAccCode.Validating
    If Not ParseAccCode() Then
      Me.ep.SetError(Me.txtAccCode, "Not a valid access code--please correct.")
      e.Cancel = True
    Else
      Me.ep.SetError(Me.txtAccCode, "")
    End If
  End Sub

  Private Function ParseAccCode() As Boolean
    Dim m As System.Text.RegularExpressions.Match
    Dim ret As Boolean = True
    Me.m_txtAccLetter = String.Empty
    Me.m_txtAccNumber = String.Empty
    With Me.txtAccCode
      If .Text.Length > 0 Then
        m = Me.CodePattern.Match(.Text)
        If m.Success Then
          Me.m_txtAccLetter = m.Groups("AccLetter").Value
          Me.m_txtAccNumber = m.Groups("AccNumber").Value
        Else
          ret = False
        End If
      End If
    End With
    Return ret
  End Function

  Private Sub txtBirthDay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBirthDay.Validating
    With txtBirthDay
      If .Text.Length > 0 Then
        If IsDate(.Text) Then
          ep.SetError(txtBirthDay, "")
        Else
          ep.SetError(txtBirthDay, "Don't recognize '" & .Text & "' as a date")
          e.Cancel = True
        End If
      End If
    End With
  End Sub

  Private Sub txtContactDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtContactDate.Validating
    With txtContactDate
      If .Text.Length > 0 Then
        If IsDate(.Text) Then
          ep.SetError(txtContactDate, "")
          m_ContactDate = DateTime.Parse(.Text)
          .Text = m_ContactDate.ToString
        Else
          ep.SetError(txtContactDate, "'" & .Text & "' is not clearly a date--please correct.")
        End If
      End If
    End With
  End Sub

  'Private Sub txtAccNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
  '  With Me.txtAccNumber
  '    If .Text.Length > 0 Then
  '      If IsNumeric(.Text) AndAlso .Text.Length = 4 Then
  '        ep.SetError(txtAccNumber, "")
  '      Else
  '        ep.SetError(txtAccNumber, "This must be a four-digit number")
  '        e.Cancel = True
  '      End If
  '    End If
  '  End With
  'End Sub

  Private Sub txtMaxRecs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMaxRecs.Validating
    With Me.txtMaxRecs
      If .Text.Length > 0 Then
        If IsNumeric(.Text) AndAlso Integer.Parse(.Text) > 0 Then
          ep.SetError(txtMaxRecs, "")
        Else
          ep.SetError(txtMaxRecs, "This must either be null, or a positive integer")
          e.Cancel = True
        End If
      End If
    End With
  End Sub

  Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
    With Me
      .txtAccCode.Text = String.Empty
      .txtFirstName.Text = String.Empty
      .txtLastName.Text = String.Empty
      .cmbStatus.SelectedItem = Nothing
      ' .cmbStatus.SelectedIndex = 0
      .cmbStatus.SelectedIndex = -1
      .txtBirthDay.Text = String.Empty
      .cmbRecruitProgVersion.SelectedItem = Nothing
      .cmbRecruitProgVersion.SelectedIndex = -1
      .cmbSex.SelectedItem = Nothing
      .txtMaxRecs.Text = String.Empty
      .txtContactDate.Text = String.Empty
      .cmbTickle.SelectedItem = Nothing
      .cmbTickle.SelectedItem = Nothing

      '.cmbTickle.SelectedIndex = -1
      '.cmbTickle.SelectedIndex = -1
      m_ContactDate = Nothing
      Tick = Nothing
    End With
  End Sub

  Private Sub btnPopContactDatePicker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPopContactDatePicker.Click
    Dim f As New frmContactDatePicker
    f.ShowDialog(Me)
  End Sub

  Private Sub btnAccessCodeListBuilder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccessCodeListBuilder.Click
    Dim f As New frmQueriedAccessCodeList
    Me.chkUseQueriedAccessCodeList.Checked = (f.ShowDialog(Me) = wf.DialogResult.OK)
  End Sub

  Private Sub chkUseQueriedAccessCodeList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles chkUseQueriedAccessCodeList.CheckedChanged, chkUseNameList.CheckedChanged
    ' This would have been fun, but it also disables chkUseQueriedAccessCodeList
    ' Me.gbOptionalCriteria.Enabled = Not Me.chkUseQueriedAccessCodeList.Checked
    Dim chk As CheckBox = CType(sender, CheckBox)
    Dim my_button As Button = Nothing
    Select Case chk.Name
      Case "chkUseQueriedAccessCodeList"
        my_button = Me.btnAccessCodeListBuilder
      Case "chkUseNameList"
        my_button = Me.btnUseNameList
    End Select

    For Each p As TabPage In Me.tcQueryParameters.Controls
      ToggleEnabledOnAllBut(p, chk, my_button)
    Next

  End Sub

  Private Sub ToggleEnabledOnAllBut(ByVal container As Control, ByVal the_check_box As CheckBox, ByVal the_button As Button)
    For Each c As Control In container.Controls
      Select Case c.Name
        Case the_check_box.Name, the_button.Name
          ' do nothing
        Case Else
          c.Enabled = Not the_check_box.Checked
      End Select
    Next
  End Sub

  Private Sub AutoTab(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    Select Case e.KeyCode
      Case Keys.Alt, Keys.Back, Keys.Control, Keys.ControlKey, Keys.Delete, Keys.End, Keys.Home
        ' do nothing
      Case Else
        Dim t As TextBox = CType(sender, TextBox)
        If t.Text.Length = t.MaxLength Then
          Dim t2 As Control = Me.GetNextControl(t, True)
          If t2 Is Nothing Then
            Console.WriteLine(t.Name & ".GetNextControl returns Nothing")
          Else
            If t2.CanFocus Then
              t2.Focus()
            Else
              Console.WriteLine("Next control is " & t2.Name & ", which can't receive the focus")
            End If
          End If
        End If

    End Select
  End Sub

  Private Sub cmbStudy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ' MessageBox.Show(cmbStudy.Text)
    BindStatusCombo()
    BindTicklerCombo()
  End Sub

  Private Sub BindStatusCombo()
    With Me.cmbStatus
      .DataSource = TrackerApp.Tracker1.Statuses.DefaultView
      '.DisplayMember = "Statuses.StatusDescription"
      '.ValueMember = "Statuses.Status"
      .DisplayMember = "StatusDescription"
      .ValueMember = "Status"
      .SelectedItem = Nothing
    End With
  End Sub
  Private Sub BindTicklerCombo()
    With Me.cmbTickle
      .DataSource = TrackerApp.Tracker1.Tickler.DefaultView
      .DisplayMember = "ToBeDone"
      .ValueMember = "ToBeDone"
      .SelectedItem = Nothing
    End With
  End Sub

  Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click

    If Me.txtAccCode.Text.Length > 0 And Me.m_txtAccLetter.Length = 0 OrElse Me.m_txtAccLetter.Length > 0 And Me.txtAccCode.Text.Length = 0 Then
      Me.ParseAccCode()
    End If

    ' Me.ParseAccCode()
    ' Me.Owner.Text &= " (" & Me.cmbStudy.Text & ")"

  End Sub


  Private Sub chkLimitPersonTypes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLimitPersonTypes.CheckedChanged
    If Me.chkLimitPersonTypes.Checked Then
      If Not Me.cmbTickle.SelectedItem Is Nothing Then
        Try
          Me.Cursor = Cursors.WaitCursor
          Dim s As StatusBarPanel = CType(Me.Owner, frmTracker).pStatus
          Dim oldtext As String = s.Text
          s.Text = "Please be patient--this takes a hojillion years."
          ' sbMainX.Panels(2).Text = "Please be patient--this takes a hojillion years."
          Dim f As New frmLimitPersonTypes
          f.ToBeDone = Me.cmbTickle.Text
          f.ShowDialog(Me)
          s.Text = oldtext
          Me.Cursor = Cursors.Default
        Catch ex As Exception
          Me.Cursor = Cursors.Default
          Throw ex
        End Try
      End If
    End If
  End Sub

  Private Sub cmbTickle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTickle.SelectedIndexChanged
    If Not Me.cmbTickle.SelectedItem Is Nothing Then
      Me.chkLimitPersonTypes.Enabled = True
    Else
      With Me.chkLimitPersonTypes
        .Enabled = False
        .Checked = False
      End With
    End If
  End Sub

  Private Sub btnUseNameList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUseNameList.Click
    Dim f As New frmQueriedNames
    Me.chkUseNameList.Checked = (f.ShowDialog(Me) = wf.DialogResult.OK)

  End Sub

End Class
