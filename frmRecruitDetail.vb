Imports se = System.Environment
Imports wf = System.Windows.Forms

Public Class frmRecruitDetail
    Inherits System.Windows.Forms.Form
    Implements DataboundForm
    Private cmRecruits As CurrencyManager
    Private cmAddresses As CurrencyManager
    Friend WithEvents tpStudySpecific As System.Windows.Forms.TabPage
    Friend WithEvents cmbPersonType As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblWebQuitDate As System.Windows.Forms.Label
    Friend WithEvents txtWebQuitDate As System.Windows.Forms.TextBox
    Friend WithEvents gbWebEnteredInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtWebName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtWebConsumno As System.Windows.Forms.TextBox
    Friend WithEvents lblWebConsumno As System.Windows.Forms.Label
    Friend WithEvents txtWebCityStateZip As System.Windows.Forms.TextBox
    Friend WithEvents txtWebAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtWebAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtWebBirthDate As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtConsumno As System.Windows.Forms.TextBox
    Friend WithEvents lblConsumNo As System.Windows.Forms.Label
    Friend WithEvents txtWebHomePhone As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnMarkEnrolled As System.Windows.Forms.Button
    Friend WithEvents txtQuitDate As System.Windows.Forms.TextBox
    Friend WithEvents lblQuitDate As System.Windows.Forms.Label
    Friend WithEvents btnMarkNotEnrolled As System.Windows.Forms.Button
    Friend WithEvents gbGHEnrollmentCall As System.Windows.Forms.GroupBox
  Private thisRecruit As TrackerData.RecruitsRow
    Private StatusesToInsert As New Hashtable

    Enum Statuses
        EnrolleeYes
        EnrolleeNo
        NewQuitDate
    End Enum

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents il As System.Windows.Forms.ImageList
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents txtRecNum As System.Windows.Forms.TextBox
  Friend WithEvents Tracker1 As Tracker.TrackerData
  Friend WithEvents btnGoFirst As System.Windows.Forms.Button
  Friend WithEvents btnGoPrevious As System.Windows.Forms.Button
  Friend WithEvents btnGoNext As System.Windows.Forms.Button
  Friend WithEvents btnGoLast As System.Windows.Forms.Button
  Friend WithEvents tpContacts As System.Windows.Forms.TabPage
  Friend WithEvents dgContacts As System.Windows.Forms.DataGrid
  Friend WithEvents tc As System.Windows.Forms.TabControl
  Friend WithEvents tpStatus As System.Windows.Forms.TabPage
  Friend WithEvents dgStatus As System.Windows.Forms.DataGrid
  Friend WithEvents tpAddresses As System.Windows.Forms.TabPage
  Friend WithEvents dgAddresses As System.Windows.Forms.DataGrid

  Friend WithEvents dgsContacts As System.Windows.Forms.DataGridTableStyle
  Friend WithEvents tbcContactDate As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcInitiator As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcResult As System.Windows.Forms.DataGridTextBoxColumn
  ' Friend WithEvents tbcType As System.Windows.Forms.DataGridTextBoxColumn
  ' Friend WithEvents tbcType As DataGridComboBoxColumn
  Friend WithEvents tbcType As DGColumnStyles.DataGridComboBoxColumn
  ' Friend WithEvents tbcNotes As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcNotes As DGColumnStyles.WrappingTextBoxColumn
  Friend WithEvents tbcStaffPerson As System.Windows.Forms.DataGridTextBoxColumn

  Friend WithEvents dgsStatuses As System.Windows.Forms.DataGridTableStyle
  Friend WithEvents tbcDate As System.Windows.Forms.DataGridTextBoxColumn
  ' Friend WithEvents tbcStatus As System.Windows.Forms.DataGridTextBoxColumn
  ' Friend WithEvents tbcStatus As CHCRTracker.DataGridComboBoxColumn
  Friend WithEvents tbcStatus As DGColumnStyles.DataGridComboBoxColumn

  Friend WithEvents tbcRecordedBy As System.Windows.Forms.DataGridTextBoxColumn


  Friend WithEvents txtSex As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtBDate As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents txtNameSuffix As System.Windows.Forms.TextBox
  Friend WithEvents txtLastName As System.Windows.Forms.TextBox
  Friend WithEvents txtMiddleName As System.Windows.Forms.TextBox
  Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents lblCurrentStatus As System.Windows.Forms.Label
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents dgPhoneNumbers As System.Windows.Forms.DataGrid
  Friend WithEvents dgsPhoneNumbers As System.Windows.Forms.DataGridTableStyle
  Friend WithEvents tbcAreaCode As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcPhoneNumber As System.Windows.Forms.DataGridTextBoxColumn
  ' Friend WithEvents tbcPhoneType As System.Windows.Forms.DataGridTextBoxColumn
  ' Friend WithEvents tbcPhoneType As CHCRTracker.DataGridComboBoxColumn
  Friend WithEvents tbcPhoneType As DGColumnStyles.DataGridComboBoxColumn
  Friend WithEvents tbcSource As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcExtension As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcPhoneRecordedBy As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents lblRecInfo As System.Windows.Forms.Label
  Friend WithEvents gbAccessCode As System.Windows.Forms.GroupBox
  Friend WithEvents btnNewAccessCode As System.Windows.Forms.Button
  Friend WithEvents txtAccNum As System.Windows.Forms.TextBox
  Friend WithEvents txtEMailAddress As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents dgsAddresses As System.Windows.Forms.DataGridTableStyle
  Friend WithEvents tbcPreference As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcLine1 As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcLine2 As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcCity As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcState As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcZip As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcRecordedB As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents tbcBounceDate As System.Windows.Forms.DataGridTextBoxColumn
  Friend WithEvents cm As System.Windows.Forms.ContextMenu
  Friend WithEvents mnuAddToAddresses As System.Windows.Forms.MenuItem
  Friend WithEvents mnuDeleteThis As System.Windows.Forms.MenuItem
  Friend WithEvents mnuDeleteAll As System.Windows.Forms.MenuItem

  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecruitDetail))
    Me.ep = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.btnGoFirst = New System.Windows.Forms.Button
    Me.il = New System.Windows.Forms.ImageList(Me.components)
    Me.btnGoPrevious = New System.Windows.Forms.Button
    Me.btnGoNext = New System.Windows.Forms.Button
    Me.btnGoLast = New System.Windows.Forms.Button
    Me.tt = New System.Windows.Forms.ToolTip(Me.components)
    Me.btnNewAccessCode = New System.Windows.Forms.Button
    Me.lblWebQuitDate = New System.Windows.Forms.Label
    Me.lblQuitDate = New System.Windows.Forms.Label
    Me.gbWebEnteredInfo = New System.Windows.Forms.GroupBox
    Me.txtWebHomePhone = New System.Windows.Forms.TextBox
    Me.Label11 = New System.Windows.Forms.Label
    Me.txtWebBirthDate = New System.Windows.Forms.TextBox
    Me.Label10 = New System.Windows.Forms.Label
    Me.txtWebConsumno = New System.Windows.Forms.TextBox
    Me.lblWebConsumno = New System.Windows.Forms.Label
    Me.txtWebCityStateZip = New System.Windows.Forms.TextBox
    Me.txtWebAddress2 = New System.Windows.Forms.TextBox
    Me.Label8 = New System.Windows.Forms.Label
    Me.txtWebAddress1 = New System.Windows.Forms.TextBox
    Me.txtWebName = New System.Windows.Forms.TextBox
    Me.Label7 = New System.Windows.Forms.Label
    Me.txtWebQuitDate = New System.Windows.Forms.TextBox
    Me.btnMarkNotEnrolled = New System.Windows.Forms.Button
    Me.btnMarkEnrolled = New System.Windows.Forms.Button
    Me.txtRecNum = New System.Windows.Forms.TextBox
    Me.Tracker1 = New Tracker.TrackerData
    Me.tc = New System.Windows.Forms.TabControl
    Me.tpContacts = New System.Windows.Forms.TabPage
    Me.dgContacts = New System.Windows.Forms.DataGrid
    Me.dgsContacts = New System.Windows.Forms.DataGridTableStyle
    Me.tbcType = New DGColumnStyles.DataGridComboBoxColumn
    Me.tbcInitiator = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcResult = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcContactDate = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcNotes = New DGColumnStyles.WrappingTextBoxColumn
    Me.tbcStaffPerson = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tpStatus = New System.Windows.Forms.TabPage
    Me.dgStatus = New System.Windows.Forms.DataGrid
    Me.dgsStatuses = New System.Windows.Forms.DataGridTableStyle
    Me.tbcStatus = New DGColumnStyles.DataGridComboBoxColumn
    Me.tbcDate = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcRecordedBy = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tpAddresses = New System.Windows.Forms.TabPage
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.dgAddresses = New System.Windows.Forms.DataGrid
    Me.dgsAddresses = New System.Windows.Forms.DataGridTableStyle
    Me.tbcPreference = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcLine1 = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcLine2 = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcCity = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcState = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcZip = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcRecordedB = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcBounceDate = New System.Windows.Forms.DataGridTextBoxColumn
    Me.Label1 = New System.Windows.Forms.Label
    Me.txtEMailAddress = New System.Windows.Forms.TextBox
    Me.TabPage1 = New System.Windows.Forms.TabPage
    Me.dgPhoneNumbers = New System.Windows.Forms.DataGrid
    Me.dgsPhoneNumbers = New System.Windows.Forms.DataGridTableStyle
    Me.tbcAreaCode = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcPhoneNumber = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcExtension = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcPhoneType = New DGColumnStyles.DataGridComboBoxColumn
    Me.tbcSource = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tbcPhoneRecordedBy = New System.Windows.Forms.DataGridTextBoxColumn
    Me.tpStudySpecific = New System.Windows.Forms.TabPage
    Me.gbGHEnrollmentCall = New System.Windows.Forms.GroupBox
    Me.txtQuitDate = New System.Windows.Forms.TextBox
    Me.txtConsumno = New System.Windows.Forms.TextBox
    Me.lblConsumNo = New System.Windows.Forms.Label
    Me.cmbPersonType = New System.Windows.Forms.ComboBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.txtSex = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtBDate = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.txtNameSuffix = New System.Windows.Forms.TextBox
    Me.txtLastName = New System.Windows.Forms.TextBox
    Me.txtMiddleName = New System.Windows.Forms.TextBox
    Me.txtFirstName = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.lblCurrentStatus = New System.Windows.Forms.Label
    Me.lblRecInfo = New System.Windows.Forms.Label
    Me.gbAccessCode = New System.Windows.Forms.GroupBox
    Me.txtAccNum = New System.Windows.Forms.TextBox
    Me.cm = New System.Windows.Forms.ContextMenu
    Me.mnuAddToAddresses = New System.Windows.Forms.MenuItem
    Me.mnuDeleteThis = New System.Windows.Forms.MenuItem
    Me.mnuDeleteAll = New System.Windows.Forms.MenuItem
    CType(Me.ep, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gbWebEnteredInfo.SuspendLayout()
    CType(Me.Tracker1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.tc.SuspendLayout()
    Me.tpContacts.SuspendLayout()
    CType(Me.dgContacts, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.tpStatus.SuspendLayout()
    CType(Me.dgStatus, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.tpAddresses.SuspendLayout()
    Me.Panel1.SuspendLayout()
    CType(Me.dgAddresses, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabPage1.SuspendLayout()
    CType(Me.dgPhoneNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.tpStudySpecific.SuspendLayout()
    Me.gbGHEnrollmentCall.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.gbAccessCode.SuspendLayout()
    Me.SuspendLayout()
    '
    'ep
    '
    Me.ep.ContainerControl = Me
    '
    'btnGoFirst
    '
    Me.btnGoFirst.Anchor = System.Windows.Forms.AnchorStyles.Bottom
    Me.btnGoFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnGoFirst.ImageIndex = 0
    Me.btnGoFirst.ImageList = Me.il
    Me.btnGoFirst.Location = New System.Drawing.Point(316, 433)
    Me.btnGoFirst.Name = "btnGoFirst"
    Me.btnGoFirst.Size = New System.Drawing.Size(41, 23)
    Me.btnGoFirst.TabIndex = 0
    Me.btnGoFirst.TabStop = False
    Me.tt.SetToolTip(Me.btnGoFirst, "Move to First record")
    '
    'il
    '
    Me.il.ImageStream = CType(resources.GetObject("il.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.il.TransparentColor = System.Drawing.Color.Transparent
    Me.il.Images.SetKeyName(0, "")
    Me.il.Images.SetKeyName(1, "")
    Me.il.Images.SetKeyName(2, "")
    Me.il.Images.SetKeyName(3, "")
    '
    'btnGoPrevious
    '
    Me.btnGoPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom
    Me.btnGoPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnGoPrevious.ImageIndex = 2
    Me.btnGoPrevious.ImageList = Me.il
    Me.btnGoPrevious.Location = New System.Drawing.Point(364, 433)
    Me.btnGoPrevious.Name = "btnGoPrevious"
    Me.btnGoPrevious.Size = New System.Drawing.Size(41, 23)
    Me.btnGoPrevious.TabIndex = 1
    Me.btnGoPrevious.TabStop = False
    Me.tt.SetToolTip(Me.btnGoPrevious, "Move back one record")
    '
    'btnGoNext
    '
    Me.btnGoNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom
    Me.btnGoNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnGoNext.ImageIndex = 3
    Me.btnGoNext.ImageList = Me.il
    Me.btnGoNext.Location = New System.Drawing.Point(453, 433)
    Me.btnGoNext.Name = "btnGoNext"
    Me.btnGoNext.Size = New System.Drawing.Size(40, 23)
    Me.btnGoNext.TabIndex = 2
    Me.btnGoNext.TabStop = False
    Me.tt.SetToolTip(Me.btnGoNext, "Move forward one record")
    '
    'btnGoLast
    '
    Me.btnGoLast.Anchor = System.Windows.Forms.AnchorStyles.Bottom
    Me.btnGoLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnGoLast.ImageIndex = 1
    Me.btnGoLast.ImageList = Me.il
    Me.btnGoLast.Location = New System.Drawing.Point(501, 433)
    Me.btnGoLast.Name = "btnGoLast"
    Me.btnGoLast.Size = New System.Drawing.Size(40, 23)
    Me.btnGoLast.TabIndex = 3
    Me.btnGoLast.TabStop = False
    Me.tt.SetToolTip(Me.btnGoLast, "Move to Last record")
    '
    'btnNewAccessCode
    '
    Me.btnNewAccessCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnNewAccessCode.Location = New System.Drawing.Point(96, 21)
    Me.btnNewAccessCode.Name = "btnNewAccessCode"
    Me.btnNewAccessCode.Size = New System.Drawing.Size(45, 23)
    Me.btnNewAccessCode.TabIndex = 1
    Me.btnNewAccessCode.TabStop = False
    Me.btnNewAccessCode.Text = "&New"
    Me.tt.SetToolTip(Me.btnNewAccessCode, "Assign this person a new Access Code")
    '
    'lblWebQuitDate
    '
    Me.lblWebQuitDate.AutoSize = True
    Me.lblWebQuitDate.Location = New System.Drawing.Point(327, 23)
    Me.lblWebQuitDate.Name = "lblWebQuitDate"
    Me.lblWebQuitDate.Size = New System.Drawing.Size(66, 16)
    Me.lblWebQuitDate.TabIndex = 33
    Me.lblWebQuitDate.Text = "Quit Date:"
    Me.tt.SetToolTip(Me.lblWebQuitDate, "The date the person has committed to quit smoking")
    '
    'lblQuitDate
    '
    Me.lblQuitDate.AutoSize = True
    Me.lblQuitDate.Location = New System.Drawing.Point(284, 25)
    Me.lblQuitDate.Name = "lblQuitDate"
    Me.lblQuitDate.Size = New System.Drawing.Size(66, 16)
    Me.lblQuitDate.TabIndex = 48
    Me.lblQuitDate.Text = "Quit Date:"
    Me.tt.SetToolTip(Me.lblQuitDate, "The date the person has committed to quit smoking")
    '
    'gbWebEnteredInfo
    '
    Me.gbWebEnteredInfo.Controls.Add(Me.txtWebHomePhone)
    Me.gbWebEnteredInfo.Controls.Add(Me.Label11)
    Me.gbWebEnteredInfo.Controls.Add(Me.txtWebBirthDate)
    Me.gbWebEnteredInfo.Controls.Add(Me.Label10)
    Me.gbWebEnteredInfo.Controls.Add(Me.txtWebConsumno)
    Me.gbWebEnteredInfo.Controls.Add(Me.lblWebConsumno)
    Me.gbWebEnteredInfo.Controls.Add(Me.txtWebCityStateZip)
    Me.gbWebEnteredInfo.Controls.Add(Me.txtWebAddress2)
    Me.gbWebEnteredInfo.Controls.Add(Me.Label8)
    Me.gbWebEnteredInfo.Controls.Add(Me.txtWebAddress1)
    Me.gbWebEnteredInfo.Controls.Add(Me.txtWebName)
    Me.gbWebEnteredInfo.Controls.Add(Me.Label7)
    Me.gbWebEnteredInfo.Controls.Add(Me.txtWebQuitDate)
    Me.gbWebEnteredInfo.Controls.Add(Me.lblWebQuitDate)
    Me.gbWebEnteredInfo.Location = New System.Drawing.Point(10, 83)
    Me.gbWebEnteredInfo.Name = "gbWebEnteredInfo"
    Me.gbWebEnteredInfo.Size = New System.Drawing.Size(461, 178)
    Me.gbWebEnteredInfo.TabIndex = 34
    Me.gbWebEnteredInfo.TabStop = False
    Me.gbWebEnteredInfo.Text = "Info Entered on the Website"
    Me.tt.SetToolTip(Me.gbWebEnteredInfo, "This information is not editable.")
    '
    'txtWebHomePhone
    '
    Me.txtWebHomePhone.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txtWebHomePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtWebHomePhone.Location = New System.Drawing.Point(211, 140)
    Me.txtWebHomePhone.Name = "txtWebHomePhone"
    Me.txtWebHomePhone.ReadOnly = True
    Me.txtWebHomePhone.Size = New System.Drawing.Size(99, 23)
    Me.txtWebHomePhone.TabIndex = 44
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(211, 121)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(85, 16)
    Me.Label11.TabIndex = 45
    Me.Label11.Text = "Home Phone:"
    '
    'txtWebBirthDate
    '
    Me.txtWebBirthDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txtWebBirthDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtWebBirthDate.Location = New System.Drawing.Point(211, 90)
    Me.txtWebBirthDate.Name = "txtWebBirthDate"
    Me.txtWebBirthDate.ReadOnly = True
    Me.txtWebBirthDate.Size = New System.Drawing.Size(99, 23)
    Me.txtWebBirthDate.TabIndex = 42
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(211, 71)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(68, 16)
    Me.Label10.TabIndex = 43
    Me.Label10.Text = "Birth date:"
    '
    'txtWebConsumno
    '
    Me.txtWebConsumno.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txtWebConsumno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtWebConsumno.Location = New System.Drawing.Point(211, 42)
    Me.txtWebConsumno.Name = "txtWebConsumno"
    Me.txtWebConsumno.ReadOnly = True
    Me.txtWebConsumno.Size = New System.Drawing.Size(99, 23)
    Me.txtWebConsumno.TabIndex = 40
    '
    'lblWebConsumno
    '
    Me.lblWebConsumno.AutoSize = True
    Me.lblWebConsumno.Location = New System.Drawing.Point(211, 23)
    Me.lblWebConsumno.Name = "lblWebConsumno"
    Me.lblWebConsumno.Size = New System.Drawing.Size(120, 16)
    Me.lblWebConsumno.TabIndex = 41
    Me.lblWebConsumno.Text = "Consumer Number:"
    '
    'txtWebCityStateZip
    '
    Me.txtWebCityStateZip.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txtWebCityStateZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtWebCityStateZip.Location = New System.Drawing.Point(4, 140)
    Me.txtWebCityStateZip.Name = "txtWebCityStateZip"
    Me.txtWebCityStateZip.ReadOnly = True
    Me.txtWebCityStateZip.Size = New System.Drawing.Size(192, 23)
    Me.txtWebCityStateZip.TabIndex = 39
    '
    'txtWebAddress2
    '
    Me.txtWebAddress2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txtWebAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtWebAddress2.Location = New System.Drawing.Point(4, 115)
    Me.txtWebAddress2.Name = "txtWebAddress2"
    Me.txtWebAddress2.ReadOnly = True
    Me.txtWebAddress2.Size = New System.Drawing.Size(192, 23)
    Me.txtWebAddress2.TabIndex = 38
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(4, 71)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(59, 16)
    Me.Label8.TabIndex = 37
    Me.Label8.Text = "Address:"
    '
    'txtWebAddress1
    '
    Me.txtWebAddress1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txtWebAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtWebAddress1.Location = New System.Drawing.Point(4, 90)
    Me.txtWebAddress1.Name = "txtWebAddress1"
    Me.txtWebAddress1.ReadOnly = True
    Me.txtWebAddress1.Size = New System.Drawing.Size(192, 23)
    Me.txtWebAddress1.TabIndex = 36
    '
    'txtWebName
    '
    Me.txtWebName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txtWebName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtWebName.Location = New System.Drawing.Point(4, 42)
    Me.txtWebName.Name = "txtWebName"
    Me.txtWebName.ReadOnly = True
    Me.txtWebName.Size = New System.Drawing.Size(192, 23)
    Me.txtWebName.TabIndex = 34
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(4, 23)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(46, 16)
    Me.Label7.TabIndex = 35
    Me.Label7.Text = "Name:"
    '
    'txtWebQuitDate
    '
    Me.txtWebQuitDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txtWebQuitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtWebQuitDate.Location = New System.Drawing.Point(327, 42)
    Me.txtWebQuitDate.Name = "txtWebQuitDate"
    Me.txtWebQuitDate.ReadOnly = True
    Me.txtWebQuitDate.Size = New System.Drawing.Size(100, 23)
    Me.txtWebQuitDate.TabIndex = 32
    '
    'btnMarkNotEnrolled
    '
    Me.btnMarkNotEnrolled.Location = New System.Drawing.Point(40, 91)
    Me.btnMarkNotEnrolled.Name = "btnMarkNotEnrolled"
    Me.btnMarkNotEnrolled.Size = New System.Drawing.Size(125, 32)
    Me.btnMarkNotEnrolled.TabIndex = 49
    Me.btnMarkNotEnrolled.Text = "No"
    Me.tt.SetToolTip(Me.btnMarkNotEnrolled, "Inform UMich that this person is *not* a GH Enrollee")
    Me.btnMarkNotEnrolled.UseVisualStyleBackColor = True
    '
    'btnMarkEnrolled
    '
    Me.btnMarkEnrolled.Location = New System.Drawing.Point(40, 41)
    Me.btnMarkEnrolled.Name = "btnMarkEnrolled"
    Me.btnMarkEnrolled.Size = New System.Drawing.Size(125, 32)
    Me.btnMarkEnrolled.TabIndex = 46
    Me.btnMarkEnrolled.Text = "Yes"
    Me.tt.SetToolTip(Me.btnMarkEnrolled, "Inform UMich that this person *is* a GH Enrollee")
    Me.btnMarkEnrolled.UseVisualStyleBackColor = True
    '
    'txtRecNum
    '
    Me.txtRecNum.Anchor = System.Windows.Forms.AnchorStyles.Bottom
    Me.txtRecNum.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtRecNum.Location = New System.Drawing.Point(412, 433)
    Me.txtRecNum.Name = "txtRecNum"
    Me.txtRecNum.Size = New System.Drawing.Size(33, 23)
    Me.txtRecNum.TabIndex = 4
    Me.txtRecNum.TabStop = False
    Me.txtRecNum.Text = "0"
    Me.txtRecNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Tracker1
    '
    Me.Tracker1.DataSetName = "Tracker"
    Me.Tracker1.Locale = New System.Globalization.CultureInfo("en-US")
    Me.Tracker1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
    '
    'tc
    '
    Me.tc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.tc.Controls.Add(Me.tpContacts)
    Me.tc.Controls.Add(Me.tpStatus)
    Me.tc.Controls.Add(Me.tpAddresses)
    Me.tc.Controls.Add(Me.TabPage1)
    Me.tc.Controls.Add(Me.tpStudySpecific)
    Me.tc.Location = New System.Drawing.Point(8, 100)
    Me.tc.Name = "tc"
    Me.tc.SelectedIndex = 0
    Me.tc.Size = New System.Drawing.Size(761, 325)
    Me.tc.TabIndex = 8
    '
    'tpContacts
    '
    Me.tpContacts.Controls.Add(Me.dgContacts)
    Me.tpContacts.Location = New System.Drawing.Point(4, 25)
    Me.tpContacts.Name = "tpContacts"
    Me.tpContacts.Size = New System.Drawing.Size(753, 296)
    Me.tpContacts.TabIndex = 0
    Me.tpContacts.Text = "Contacts"
    '
    'dgContacts
    '
    Me.dgContacts.CaptionText = "Contacts between Project Staff and Recruit"
    Me.dgContacts.DataMember = ""
    Me.dgContacts.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dgContacts.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dgContacts.Location = New System.Drawing.Point(0, 0)
    Me.dgContacts.Name = "dgContacts"
    Me.dgContacts.Size = New System.Drawing.Size(753, 296)
    Me.dgContacts.TabIndex = 0
    Me.dgContacts.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgsContacts})
    '
    'dgsContacts
    '
    Me.dgsContacts.BackColor = System.Drawing.Color.Lavender
    Me.dgsContacts.DataGrid = Me.dgContacts
    Me.dgsContacts.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.tbcType, Me.tbcInitiator, Me.tbcResult, Me.tbcContactDate, Me.tbcNotes, Me.tbcStaffPerson})
    Me.dgsContacts.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dgsContacts.MappingName = "RecruitContacts"
    Me.dgsContacts.PreferredRowHeight = 0
    '
    'tbcType
    '
    Me.tbcType.Format = ""
    Me.tbcType.FormatInfo = Nothing
    Me.tbcType.HeaderText = "Type"
    Me.tbcType.MappingName = "ContactType"
    Me.tbcType.NullText = ""
    Me.tbcType.Width = 125
    '
    'tbcInitiator
    '
    Me.tbcInitiator.Format = ""
    Me.tbcInitiator.FormatInfo = Nothing
    Me.tbcInitiator.HeaderText = "Initiated By"
    Me.tbcInitiator.MappingName = "Initiator"
    Me.tbcInitiator.NullText = ""
    Me.tbcInitiator.Width = 90
    '
    'tbcResult
    '
    Me.tbcResult.Format = ""
    Me.tbcResult.FormatInfo = Nothing
    Me.tbcResult.HeaderText = "Result"
    Me.tbcResult.MappingName = "Result"
    Me.tbcResult.NullText = ""
    Me.tbcResult.Width = 75
    '
    'tbcContactDate
    '
    Me.tbcContactDate.Format = "g"
    Me.tbcContactDate.FormatInfo = Nothing
    Me.tbcContactDate.HeaderText = "Date"
    Me.tbcContactDate.MappingName = "ContactDate"
    Me.tbcContactDate.Width = 200
    '
    'tbcNotes
    '
    Me.tbcNotes.Format = ""
    Me.tbcNotes.FormatInfo = Nothing
    Me.tbcNotes.HeaderText = "Notes"
    Me.tbcNotes.MappingName = "Notes"
    Me.tbcNotes.NullText = ""
    Me.tbcNotes.Width = 275
    '
    'tbcStaffPerson
    '
    Me.tbcStaffPerson.Format = ""
    Me.tbcStaffPerson.FormatInfo = Nothing
    Me.tbcStaffPerson.HeaderText = "Staff Person"
    Me.tbcStaffPerson.MappingName = "AddedBy"
    Me.tbcStaffPerson.NullText = ""
    Me.tbcStaffPerson.ReadOnly = True
    Me.tbcStaffPerson.Width = 75
    '
    'tpStatus
    '
    Me.tpStatus.Controls.Add(Me.dgStatus)
    Me.tpStatus.Location = New System.Drawing.Point(4, 25)
    Me.tpStatus.Name = "tpStatus"
    Me.tpStatus.Size = New System.Drawing.Size(753, 296)
    Me.tpStatus.TabIndex = 1
    Me.tpStatus.Text = "Status History"
    '
    'dgStatus
    '
    Me.dgStatus.CaptionText = "Status"
    Me.dgStatus.DataMember = ""
    Me.dgStatus.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dgStatus.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dgStatus.Location = New System.Drawing.Point(0, 0)
    Me.dgStatus.Name = "dgStatus"
    Me.dgStatus.Size = New System.Drawing.Size(753, 296)
    Me.dgStatus.TabIndex = 0
    Me.dgStatus.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgsStatuses})
    '
    'dgsStatuses
    '
    Me.dgsStatuses.AlternatingBackColor = System.Drawing.Color.Lavender
    Me.dgsStatuses.DataGrid = Me.dgStatus
    Me.dgsStatuses.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.tbcStatus, Me.tbcDate, Me.tbcRecordedBy})
    Me.dgsStatuses.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dgsStatuses.MappingName = "RecruitStatuses"
    '
    'tbcStatus
    '
    Me.tbcStatus.Format = ""
    Me.tbcStatus.FormatInfo = Nothing
    Me.tbcStatus.HeaderText = "Status"
    Me.tbcStatus.MappingName = "Status"
    Me.tbcStatus.NullText = ""
    Me.tbcStatus.Width = 275
    '
    'tbcDate
    '
    Me.tbcDate.Format = "g"
    Me.tbcDate.FormatInfo = Nothing
    Me.tbcDate.HeaderText = "Date"
    Me.tbcDate.MappingName = "StatusDate"
    Me.tbcDate.NullText = ""
    Me.tbcDate.Width = 150
    '
    'tbcRecordedBy
    '
    Me.tbcRecordedBy.Format = ""
    Me.tbcRecordedBy.FormatInfo = Nothing
    Me.tbcRecordedBy.HeaderText = "Recorded By"
    Me.tbcRecordedBy.MappingName = "AddedBy"
    Me.tbcRecordedBy.ReadOnly = True
    Me.tbcRecordedBy.Width = 75
    '
    'tpAddresses
    '
    Me.tpAddresses.Controls.Add(Me.Panel1)
    Me.tpAddresses.Controls.Add(Me.Label1)
    Me.tpAddresses.Controls.Add(Me.txtEMailAddress)
    Me.tpAddresses.Location = New System.Drawing.Point(4, 25)
    Me.tpAddresses.Name = "tpAddresses"
    Me.tpAddresses.Size = New System.Drawing.Size(753, 296)
    Me.tpAddresses.TabIndex = 2
    Me.tpAddresses.Text = "Addresses"
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.dgAddresses)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(753, 296)
    Me.Panel1.TabIndex = 27
    '
    'dgAddresses
    '
    Me.dgAddresses.CaptionText = "Mailing Addresses"
    Me.dgAddresses.DataMember = ""
    Me.dgAddresses.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dgAddresses.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dgAddresses.Location = New System.Drawing.Point(0, 0)
    Me.dgAddresses.Name = "dgAddresses"
    Me.dgAddresses.Size = New System.Drawing.Size(753, 296)
    Me.dgAddresses.TabIndex = 1
    Me.dgAddresses.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgsAddresses})
    '
    'dgsAddresses
    '
    Me.dgsAddresses.AlternatingBackColor = System.Drawing.Color.Lavender
    Me.dgsAddresses.DataGrid = Me.dgAddresses
    Me.dgsAddresses.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.tbcPreference, Me.tbcLine1, Me.tbcLine2, Me.tbcCity, Me.tbcState, Me.tbcZip, Me.tbcRecordedB, Me.tbcBounceDate})
    Me.dgsAddresses.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dgsAddresses.MappingName = "Addresses"
    '
    'tbcPreference
    '
    Me.tbcPreference.Format = ""
    Me.tbcPreference.FormatInfo = Nothing
    Me.tbcPreference.HeaderText = "Preference Rank"
    Me.tbcPreference.MappingName = "PreferenceRank"
    Me.tbcPreference.NullText = ""
    Me.tbcPreference.Width = 60
    '
    'tbcLine1
    '
    Me.tbcLine1.Format = ""
    Me.tbcLine1.FormatInfo = Nothing
    Me.tbcLine1.HeaderText = "Line 1"
    Me.tbcLine1.MappingName = "Line1"
    Me.tbcLine1.NullText = ""
    Me.tbcLine1.Width = 175
    '
    'tbcLine2
    '
    Me.tbcLine2.Format = ""
    Me.tbcLine2.FormatInfo = Nothing
    Me.tbcLine2.HeaderText = "Line 2"
    Me.tbcLine2.MappingName = "Line2"
    Me.tbcLine2.NullText = ""
    Me.tbcLine2.Width = 175
    '
    'tbcCity
    '
    Me.tbcCity.Format = ""
    Me.tbcCity.FormatInfo = Nothing
    Me.tbcCity.HeaderText = "City"
    Me.tbcCity.MappingName = "City"
    Me.tbcCity.NullText = ""
    Me.tbcCity.Width = 75
    '
    'tbcState
    '
    Me.tbcState.Format = ""
    Me.tbcState.FormatInfo = Nothing
    Me.tbcState.HeaderText = "State"
    Me.tbcState.MappingName = "State"
    Me.tbcState.NullText = ""
    Me.tbcState.Width = 50
    '
    'tbcZip
    '
    Me.tbcZip.Format = ""
    Me.tbcZip.FormatInfo = Nothing
    Me.tbcZip.HeaderText = "Zip"
    Me.tbcZip.MappingName = "Zip"
    Me.tbcZip.NullText = ""
    Me.tbcZip.Width = 75
    '
    'tbcRecordedB
    '
    Me.tbcRecordedB.Format = ""
    Me.tbcRecordedB.FormatInfo = Nothing
    Me.tbcRecordedB.HeaderText = "Recorded By"
    Me.tbcRecordedB.MappingName = "AddedBy"
    Me.tbcRecordedB.NullText = ""
    Me.tbcRecordedB.Width = 75
    '
    'tbcBounceDate
    '
    Me.tbcBounceDate.Format = ""
    Me.tbcBounceDate.FormatInfo = Nothing
    Me.tbcBounceDate.HeaderText = "Bounce Date"
    Me.tbcBounceDate.MappingName = "BounceDate"
    Me.tbcBounceDate.NullText = ""
    Me.tbcBounceDate.Width = 125
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(8, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(48, 16)
    Me.Label1.TabIndex = 26
    Me.Label1.Text = "E-Mail:"
    '
    'txtEMailAddress
    '
    Me.txtEMailAddress.Location = New System.Drawing.Point(64, 8)
    Me.txtEMailAddress.Name = "txtEMailAddress"
    Me.txtEMailAddress.Size = New System.Drawing.Size(228, 23)
    Me.txtEMailAddress.TabIndex = 25
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.dgPhoneNumbers)
    Me.TabPage1.Location = New System.Drawing.Point(4, 25)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Size = New System.Drawing.Size(753, 296)
    Me.TabPage1.TabIndex = 3
    Me.TabPage1.Text = "Phone Numbers"
    '
    'dgPhoneNumbers
    '
    Me.dgPhoneNumbers.CaptionText = "Phone Numbers"
    Me.dgPhoneNumbers.DataMember = ""
    Me.dgPhoneNumbers.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dgPhoneNumbers.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dgPhoneNumbers.Location = New System.Drawing.Point(0, 0)
    Me.dgPhoneNumbers.Name = "dgPhoneNumbers"
    Me.dgPhoneNumbers.Size = New System.Drawing.Size(753, 296)
    Me.dgPhoneNumbers.TabIndex = 1
    Me.dgPhoneNumbers.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgsPhoneNumbers})
    '
    'dgsPhoneNumbers
    '
    Me.dgsPhoneNumbers.AlternatingBackColor = System.Drawing.Color.Lavender
    Me.dgsPhoneNumbers.DataGrid = Me.dgPhoneNumbers
    Me.dgsPhoneNumbers.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.tbcAreaCode, Me.tbcPhoneNumber, Me.tbcExtension, Me.tbcPhoneType, Me.tbcSource, Me.tbcPhoneRecordedBy})
    Me.dgsPhoneNumbers.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dgsPhoneNumbers.MappingName = "PhoneNumbers"
    '
    'tbcAreaCode
    '
    Me.tbcAreaCode.Format = ""
    Me.tbcAreaCode.FormatInfo = Nothing
    Me.tbcAreaCode.HeaderText = "Area Code"
    Me.tbcAreaCode.MappingName = "AreaCode"
    Me.tbcAreaCode.NullText = ""
    Me.tbcAreaCode.Width = 50
    '
    'tbcPhoneNumber
    '
    Me.tbcPhoneNumber.Format = "000-0000"
    Me.tbcPhoneNumber.FormatInfo = Nothing
    Me.tbcPhoneNumber.HeaderText = "Number"
    Me.tbcPhoneNumber.MappingName = "PhoneNumber"
    Me.tbcPhoneNumber.NullText = ""
    Me.tbcPhoneNumber.Width = 75
    '
    'tbcExtension
    '
    Me.tbcExtension.Format = ""
    Me.tbcExtension.FormatInfo = Nothing
    Me.tbcExtension.HeaderText = "Extension"
    Me.tbcExtension.MappingName = "Extension"
    Me.tbcExtension.NullText = ""
    Me.tbcExtension.Width = 50
    '
    'tbcPhoneType
    '
    Me.tbcPhoneType.Format = ""
    Me.tbcPhoneType.FormatInfo = Nothing
    Me.tbcPhoneType.HeaderText = "Type"
    Me.tbcPhoneType.MappingName = "Type"
    Me.tbcPhoneType.NullText = ""
    Me.tbcPhoneType.Width = 125
    '
    'tbcSource
    '
    Me.tbcSource.Format = ""
    Me.tbcSource.FormatInfo = Nothing
    Me.tbcSource.HeaderText = "Source"
    Me.tbcSource.MappingName = "Source"
    Me.tbcSource.NullText = ""
    Me.tbcSource.Width = 75
    '
    'tbcPhoneRecordedBy
    '
    Me.tbcPhoneRecordedBy.Format = ""
    Me.tbcPhoneRecordedBy.FormatInfo = Nothing
    Me.tbcPhoneRecordedBy.HeaderText = "Recorded By"
    Me.tbcPhoneRecordedBy.MappingName = "AddedBy"
    Me.tbcPhoneRecordedBy.ReadOnly = True
    Me.tbcPhoneRecordedBy.Width = 75
    '
    'tpStudySpecific
    '
    Me.tpStudySpecific.Controls.Add(Me.gbGHEnrollmentCall)
    Me.tpStudySpecific.Controls.Add(Me.txtQuitDate)
    Me.tpStudySpecific.Controls.Add(Me.lblQuitDate)
    Me.tpStudySpecific.Controls.Add(Me.txtConsumno)
    Me.tpStudySpecific.Controls.Add(Me.lblConsumNo)
    Me.tpStudySpecific.Controls.Add(Me.gbWebEnteredInfo)
    Me.tpStudySpecific.Controls.Add(Me.cmbPersonType)
    Me.tpStudySpecific.Controls.Add(Me.Label6)
    Me.tpStudySpecific.Location = New System.Drawing.Point(4, 25)
    Me.tpStudySpecific.Name = "tpStudySpecific"
    Me.tpStudySpecific.Padding = New System.Windows.Forms.Padding(3)
    Me.tpStudySpecific.Size = New System.Drawing.Size(753, 296)
    Me.tpStudySpecific.TabIndex = 4
    Me.tpStudySpecific.Text = "<study specific>"
    Me.tpStudySpecific.ToolTipText = "Information relevant only to PQ people."
    Me.tpStudySpecific.UseVisualStyleBackColor = True
    '
    'gbGHEnrollmentCall
    '
    Me.gbGHEnrollmentCall.Controls.Add(Me.btnMarkNotEnrolled)
    Me.gbGHEnrollmentCall.Controls.Add(Me.btnMarkEnrolled)
    Me.gbGHEnrollmentCall.Location = New System.Drawing.Point(532, 83)
    Me.gbGHEnrollmentCall.Name = "gbGHEnrollmentCall"
    Me.gbGHEnrollmentCall.Size = New System.Drawing.Size(198, 178)
    Me.gbGHEnrollmentCall.TabIndex = 50
    Me.gbGHEnrollmentCall.TabStop = False
    Me.gbGHEnrollmentCall.Text = "Is this person a GH Enrollee?"
    '
    'txtQuitDate
    '
    Me.txtQuitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtQuitDate.Location = New System.Drawing.Point(284, 44)
    Me.txtQuitDate.Name = "txtQuitDate"
    Me.txtQuitDate.Size = New System.Drawing.Size(99, 23)
    Me.txtQuitDate.TabIndex = 47
    '
    'txtConsumno
    '
    Me.txtConsumno.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txtConsumno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtConsumno.Location = New System.Drawing.Point(150, 43)
    Me.txtConsumno.Name = "txtConsumno"
    Me.txtConsumno.ReadOnly = True
    Me.txtConsumno.Size = New System.Drawing.Size(100, 23)
    Me.txtConsumno.TabIndex = 35
    '
    'lblConsumNo
    '
    Me.lblConsumNo.AutoSize = True
    Me.lblConsumNo.Location = New System.Drawing.Point(150, 24)
    Me.lblConsumNo.Name = "lblConsumNo"
    Me.lblConsumNo.Size = New System.Drawing.Size(120, 16)
    Me.lblConsumNo.TabIndex = 36
    Me.lblConsumNo.Text = "Consumer Number:"
    '
    'cmbPersonType
    '
    Me.cmbPersonType.FormattingEnabled = True
    Me.cmbPersonType.Items.AddRange(New Object() {"IGP", "Network", "NetSmok", "Generic", "Intervention", "Control"})
    Me.cmbPersonType.Location = New System.Drawing.Point(10, 43)
    Me.cmbPersonType.Name = "cmbPersonType"
    Me.cmbPersonType.Size = New System.Drawing.Size(120, 24)
    Me.cmbPersonType.TabIndex = 31
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(8, 24)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(84, 16)
    Me.Label6.TabIndex = 30
    Me.Label6.Text = "Person Type:"
    '
    'txtSex
    '
    Me.txtSex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtSex.Location = New System.Drawing.Point(484, 36)
    Me.txtSex.Name = "txtSex"
    Me.txtSex.Size = New System.Drawing.Size(32, 23)
    Me.txtSex.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(484, 16)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(34, 16)
    Me.Label3.TabIndex = 14
    Me.Label3.Text = "Sex:"
    '
    'txtBDate
    '
    Me.txtBDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtBDate.Location = New System.Drawing.Point(528, 36)
    Me.txtBDate.Name = "txtBDate"
    Me.txtBDate.Size = New System.Drawing.Size(100, 23)
    Me.txtBDate.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(528, 16)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(69, 16)
    Me.Label4.TabIndex = 16
    Me.Label4.Text = "Birth Date:"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.txtNameSuffix)
    Me.GroupBox1.Controls.Add(Me.txtLastName)
    Me.GroupBox1.Controls.Add(Me.txtMiddleName)
    Me.GroupBox1.Controls.Add(Me.txtFirstName)
    Me.GroupBox1.Location = New System.Drawing.Point(172, 16)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(304, 52)
    Me.GroupBox1.TabIndex = 1
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Name:"
    '
    'txtNameSuffix
    '
    Me.txtNameSuffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtNameSuffix.Location = New System.Drawing.Point(260, 20)
    Me.txtNameSuffix.Name = "txtNameSuffix"
    Me.txtNameSuffix.Size = New System.Drawing.Size(32, 23)
    Me.txtNameSuffix.TabIndex = 3
    '
    'txtLastName
    '
    Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtLastName.Location = New System.Drawing.Point(152, 20)
    Me.txtLastName.Name = "txtLastName"
    Me.txtLastName.Size = New System.Drawing.Size(100, 23)
    Me.txtLastName.TabIndex = 2
    '
    'txtMiddleName
    '
    Me.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtMiddleName.Location = New System.Drawing.Point(112, 20)
    Me.txtMiddleName.Name = "txtMiddleName"
    Me.txtMiddleName.Size = New System.Drawing.Size(32, 23)
    Me.txtMiddleName.TabIndex = 1
    '
    'txtFirstName
    '
    Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtFirstName.Location = New System.Drawing.Point(8, 20)
    Me.txtFirstName.Name = "txtFirstName"
    Me.txtFirstName.Size = New System.Drawing.Size(100, 23)
    Me.txtFirstName.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(636, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(96, 16)
    Me.Label2.TabIndex = 19
    Me.Label2.Text = "Current Status:"
    '
    'lblCurrentStatus
    '
    Me.lblCurrentStatus.AutoSize = True
    Me.lblCurrentStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblCurrentStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.lblCurrentStatus.Location = New System.Drawing.Point(636, 36)
    Me.lblCurrentStatus.Name = "lblCurrentStatus"
    Me.lblCurrentStatus.Size = New System.Drawing.Size(94, 18)
    Me.lblCurrentStatus.TabIndex = 20
    Me.lblCurrentStatus.Text = "<placeholder>"
    '
    'lblRecInfo
    '
    Me.lblRecInfo.AutoSize = True
    Me.lblRecInfo.Location = New System.Drawing.Point(8, 72)
    Me.lblRecInfo.Name = "lblRecInfo"
    Me.lblRecInfo.Size = New System.Drawing.Size(92, 16)
    Me.lblRecInfo.TabIndex = 24
    Me.lblRecInfo.Text = "<placeholder>"
    '
    'gbAccessCode
    '
    Me.gbAccessCode.Controls.Add(Me.btnNewAccessCode)
    Me.gbAccessCode.Controls.Add(Me.txtAccNum)
    Me.gbAccessCode.Location = New System.Drawing.Point(0, 16)
    Me.gbAccessCode.Name = "gbAccessCode"
    Me.gbAccessCode.Size = New System.Drawing.Size(152, 52)
    Me.gbAccessCode.TabIndex = 0
    Me.gbAccessCode.TabStop = False
    Me.gbAccessCode.Text = "Access Code:"
    '
    'txtAccNum
    '
    Me.txtAccNum.BackColor = System.Drawing.Color.White
    Me.txtAccNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.txtAccNum.Enabled = False
    Me.txtAccNum.ForeColor = System.Drawing.Color.Red
    Me.txtAccNum.Location = New System.Drawing.Point(12, 21)
    Me.txtAccNum.Name = "txtAccNum"
    Me.txtAccNum.Size = New System.Drawing.Size(64, 23)
    Me.txtAccNum.TabIndex = 0
    '
    'cm
    '
    Me.cm.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAddToAddresses, Me.mnuDeleteThis, Me.mnuDeleteAll})
    '
    'mnuAddToAddresses
    '
    Me.mnuAddToAddresses.Index = 0
    Me.mnuAddToAddresses.Text = "Add to Addresses"
    '
    'mnuDeleteThis
    '
    Me.mnuDeleteThis.Index = 1
    Me.mnuDeleteThis.Text = "Delete This"
    '
    'mnuDeleteAll
    '
    Me.mnuDeleteAll.Index = 2
    Me.mnuDeleteAll.Text = "Delete ALL"
    '
    'frmRecruitDetail
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
    Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.ClientSize = New System.Drawing.Size(793, 457)
    Me.Controls.Add(Me.gbAccessCode)
    Me.Controls.Add(Me.lblRecInfo)
    Me.Controls.Add(Me.lblCurrentStatus)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.txtBDate)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtSex)
    Me.Controls.Add(Me.txtRecNum)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.tc)
    Me.Controls.Add(Me.btnGoLast)
    Me.Controls.Add(Me.btnGoNext)
    Me.Controls.Add(Me.btnGoPrevious)
    Me.Controls.Add(Me.btnGoFirst)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "frmRecruitDetail"
    Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
    Me.Text = "Recruit Detail"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.ep, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gbWebEnteredInfo.ResumeLayout(False)
    Me.gbWebEnteredInfo.PerformLayout()
    CType(Me.Tracker1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.tc.ResumeLayout(False)
    Me.tpContacts.ResumeLayout(False)
    CType(Me.dgContacts, System.ComponentModel.ISupportInitialize).EndInit()
    Me.tpStatus.ResumeLayout(False)
    CType(Me.dgStatus, System.ComponentModel.ISupportInitialize).EndInit()
    Me.tpAddresses.ResumeLayout(False)
    Me.tpAddresses.PerformLayout()
    Me.Panel1.ResumeLayout(False)
    CType(Me.dgAddresses, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabPage1.ResumeLayout(False)
    CType(Me.dgPhoneNumbers, System.ComponentModel.ISupportInitialize).EndInit()
    Me.tpStudySpecific.ResumeLayout(False)
    Me.tpStudySpecific.PerformLayout()
    Me.gbGHEnrollmentCall.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.gbAccessCode.ResumeLayout(False)
    Me.gbAccessCode.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Public Sub New(ByVal ds As TrackerData)
    MyBase.New()
    'This call is required by the Windows Form Designer.
    InitializeComponent()
    Me.Tracker1 = ds
  End Sub

  Private Sub ChopTime(ByVal sender As Object, ByVal e As System.Windows.Forms.ConvertEventArgs)
    With e
      If .DesiredType Is GetType(String) Then
        If e.Value Is DBNull.Value Then
          e.Value = String.Empty
        Else
          .Value = CType(e.Value, DateTime).ToShortDateString
        End If
      End If
    End With
  End Sub

  'Private Sub TitleCase(ByVal sender As Object, ByVal e As System.Windows.Forms.ConvertEventArgs)
  '   With e
  '      If .DesiredType Is GetType(String) Then
  '         .Value = StrConv(CType(e.Value, String), VbStrConv.ProperCase)
  '      End If
  '   End With
  'End Sub

  Private Sub EnableGHEnrollmentButtons(ByVal sender As Object, ByVal e As System.EventArgs)
    Select Case Me.lblCurrentStatus.Text
      Case "GH Enrollment SUSPICIOUS"
        Me.gbGHEnrollmentCall.Enabled = True
      Case Else
        Me.gbGHEnrollmentCall.Enabled = False
    End Select
    Beep()
  End Sub

  Private Sub frmRecruitDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Me.txtAccNum.DataBindings.Add("Text", TrackerApp.Tracker1, "Recruits.AccCode")
    Dim dbFirstName As New Binding("Text", TrackerApp.Tracker1, "Recruits.FirstName")
    Me.txtFirstName.DataBindings.Add(dbFirstName)

    Me.txtMiddleName.DataBindings.Add("Text", TrackerApp.Tracker1, "Recruits.MiddleName")

    Dim dbLastName As New System.Windows.Forms.Binding("Text", TrackerApp.Tracker1, "Recruits.LastName")
    Me.txtLastName.DataBindings.Add(dbLastName)

    Me.txtNameSuffix.DataBindings.Add("Text", TrackerApp.Tracker1, "Recruits.NameSuffix")
    Me.txtSex.DataBindings.Add("Text", TrackerApp.Tracker1, "Recruits.Sex")

    Dim db As New System.Windows.Forms.Binding("Text", TrackerApp.Tracker1, "Recruits.BDate")
    AddHandler db.Format, AddressOf ChopTime
    Me.txtEMailAddress.DataBindings.Add("Text", TrackerApp.Tracker1, "Recruits.EMailAddress")

    Me.txtBDate.DataBindings.Add(db)
    Me.lblCurrentStatus.DataBindings.Add("Text", TrackerApp.Tracker1, "Recruits.StatusDescription")
    AddHandler lblCurrentStatus.TextChanged, AddressOf EnableGHEnrollmentButtons



    ' Me.txtIncentive.DataBindings.Add(New Windows.Forms.Binding("Text", TrackerApp.Tracker1, "Recruits.Incentive"))

    ' Me.txtPersonType.DataBindings.Add(New Windows.Forms.Binding("Text", TrackerApp.Tracker1, "Recruits.PersonType"))

    Me.cmbPersonType.DataBindings.Add(New Windows.Forms.Binding("Text", TrackerApp.Tracker1, "Recruits.PersonType"))

    Dim qdb As New System.Windows.Forms.Binding("Text", TrackerApp.Tracker1, "Recruits.QuitDate")
    AddHandler qdb.Format, AddressOf ChopTime
    Me.txtQuitDate.DataBindings.Add(qdb)

    With Me.tbcType.ColumnComboBox
      .DataSource = TrackerApp.Tracker1.ContactTypes.DefaultView
      .DisplayMember = "ContactTypeDescription"
      .ValueMember = "ContactType"
    End With

    With Me.dgContacts
      .DataMember = "Recruits.Contacts"
      .DataSource = TrackerApp.Tracker1
    End With

    ' Lets try to track the position of the contacts list.
    Dim cmContacts As CurrencyManager
    cmContacts = CType(dgContacts.BindingContext(dgContacts.DataSource, dgContacts.DataMember), CurrencyManager)
    AddHandler cmContacts.CurrentChanged, AddressOf OnCurrentContact

    With Me.tbcStatus.ColumnComboBox
      ' .DataSource = TrackerApp.Statuses
      .DataSource = TrackerApp.Tracker1.Statuses.DefaultView
      .DisplayMember = "StatusDescription"
      .ValueMember = "Status"
      '.DataBindings.Add("SelectedValue", TrackerApp.Tracker1, "RecruitStatuses.Status")
    End With

    With Me.dgStatus
      .DataMember = "Recruits.Status History"
      .DataSource = TrackerApp.Tracker1
      .PreferredRowHeight = Me.tbcStatus.ColumnComboBox.Height + 1
    End With

    ' Let's try to do the same for Statuses
    Dim cmStatuses As CurrencyManager
    cmStatuses = CType(dgStatus.BindingContext(dgStatus.DataSource, dgStatus.DataMember), CurrencyManager)
    AddHandler cmStatuses.CurrentChanged, AddressOf OnCurrentContact

    ' MessageBox.Show(Me.dgStatus.DataBindings.Count.ToString)

    With Me.dgAddresses
      .DataMember = "Recruits.Addresses"
      .DataSource = TrackerApp.Tracker1
    End With

    With Me.dgUpdatedAddresses
      .DataMember = "Recruits.Updated addresses"
      .DataSource = TrackerApp.Tracker1
      ' .TableStyles.Add(dgAddresses.TableStyles(0))
      ' .TableStyles = dgAddresses.TableStyles
    End With


    ' Enabling the updated address mover context menu
    Me.tbcUACity.TextBox.ContextMenu = cm
    Me.tbcUALine1.TextBox.ContextMenu = cm
    Me.tbcUALine2.TextBox.ContextMenu = cm
    Me.tbcUAPreference.TextBox.ContextMenu = cm
    Me.tbcUAState.TextBox.ContextMenu = cm
    Me.tbcUAZip.TextBox.ContextMenu = cm

    cmAddresses = CType(Me.dgAddresses.BindingContext(dgAddresses.DataSource, dgAddresses.DataMember), CurrencyManager)
    AddHandler cmAddresses.PositionChanged, AddressOf OnCurrentAddress

    With Me.tbcPhoneType.ColumnComboBox
      .DisplayMember = "Type"
      .ValueMember = "Type"
      .DataSource = TrackerApp.Tracker1.PhoneNumberTypes
    End With

    With Me.dgPhoneNumbers
      .DataMember = "Recruits.Phone Numbers"
      .DataSource = TrackerApp.Tracker1
      .PreferredRowHeight = Me.tbcPhoneType.ColumnComboBox.Height + 1
    End With

    ' me.Tracker1 = TrackerApp.Tracker1
    cmRecruits = CType(Me.txtAccNum.DataBindings.Item("Text").BindingManagerBase, CurrencyManager)
    AddHandler cmRecruits.PositionChanged, AddressOf OnCurrentRecruit
    thisRecruit = GetThisRecruit()
    UpdateRecordHxLabel(thisRecruit)
    UpdateRecNum()

    SetAddressPrefRankDefault()

    ' Me.tc.TabPages.Item(1).Select()
    Me.tc.SelectedIndex = TrackerApp.Settings.LastDetailTabPage
    AddHandler tc.SelectedIndexChanged, AddressOf tc_SelectedIndexChanged
    ' Isn't this clever--we're binding the position property of the currency manager
    ' for the substantive data binding to the .Text property of the record number text box.
    ' Even better would be to bind it to the Position + 1, if that's possible.

    ' Clever--but it annoyed the users that the count didn't start at 1
    ' Me.txtRecNum.DataBindings.Add("Text", cm, "Position")

    'SetDateTimeDefaults()

    'AddHandler Chcr1.RecruitContacts.RecruitContactsRowChanging _
    ', New TrackerData.RecruitContactsRowChangeEventHandler(AddressOf RecruitContacts_RowChange)

    ' AddHandler Me.tbcContactDate.TextBox.Click, New EventHandler(AddressOf RecruitContacts_RowChange)
    'AddHandler Me.tbcContactDate.TextBox.Enter, New EventHandler(AddressOf ContactDate_Clicked)
    'AddHandler Me.tbcDate.TextBox.Enter, New EventHandler(AddressOf ContactDate_Clicked)

    ' AddHandler dgContacts.Click, New EventHandler(AddressOf RecruitContacts_RowChange)


    ' Should we show the PQ tab?
    Me.cmbPersonType.Items.Clear()

    Select Case CType(Me.ParentForm, frmTracker).StudyName
      Case "Proj Quit Phase II"
        Me.tpStudySpecific.Text = "Project Quit"
        Me.gbGHEnrollmentCall.Visible = True
        Me.txtQuitDate.Visible = True
        Me.lblQuitDate.Visible = True
        Me.txtWebQuitDate.Visible = True
        Me.lblWebQuitDate.Visible = True
        Me.txtWebConsumno.Visible = True
        Me.lblWebConsumno.Visible = True
        With Me.cmbPersonType.Items
          .Add("IGP")
          .Add("Network")
          .Add("NetSmok")
          .Add("Generic")
        End With
        With Me.txtConsumno
          .DataBindings.Add("Text", TrackerApp.Tracker1, "Recruits.ConsumNo")
          .ReadOnly = True
          .BackColor = Me.txtWebConsumno.BackColor
        End With
        Me.lblConsumNo.Text = "Consumer Number:"
      Case "Guide To Decide II"
        Me.tpStudySpecific.Text = "Guide To Decide"
        Me.gbGHEnrollmentCall.Visible = False
        Me.txtQuitDate.Visible = False
        Me.lblQuitDate.Visible = False
        Me.txtWebQuitDate.Visible = False
        Me.lblWebQuitDate.Visible = False
        Me.txtWebConsumno.Visible = False
        Me.lblWebConsumno.Visible = False
        With Me.cmbPersonType.Items
          .Add("Control")
          .Add("Intervention")
        End With
        With Me.txtConsumno
          .DataBindings.Add("Text", TrackerApp.Tracker1, "Recruits.Incentive")
          .ReadOnly = False
          .BackColor = Color.White
        End With

        Me.lblConsumNo.Text = "Incentive:"
      Case Else
        Me.tc.TabPages.Remove(Me.tpStudySpecific)
        ' Me.tpStudySpecific.Text = "Something Else"
    End Select

  End Sub

  Private Sub UpdateRecNum()
    Me.txtRecNum.Text = (cmRecruits.Position + 1).ToString
  End Sub

  Private Sub UpdateRecordHxLabel(ByVal thisRecruit As TrackerData.RecruitsRow)
    Dim s As String
    s = "This record was added by user '" & thisRecruit.AddedBy.Trim & "' on " & thisRecruit.AddedDate.ToShortDateString & "."

    ' If IsDBNull(thisRecruit.ModifiedBy) Then
    If thisRecruit.IsModifiedByNull Then
      s &= "  This record has not yet been modified."
    Else
      s &= "  It was last modified by user '" & thisRecruit.ModifiedBy.Trim & "' on " & thisRecruit.ModifiedDate.ToShortDateString & "."
    End If
    Me.lblRecInfo.Text = s
    ' MessageBox.Show(thisRecruit.FirstName)
  End Sub

  Private Function GetThisRecruit() As TrackerData.RecruitsRow
    Dim drv As DataRowView
    drv = CType(cmRecruits.Current, DataRowView)
    Return CType(drv.Row, TrackerData.RecruitsRow)
  End Function

  Private Sub OnCurrentRecruit(ByVal sender As Object, ByVal e As System.EventArgs)
    If Not cmRecruits.IsBindingSuspended Then
      thisRecruit = GetThisRecruit()
      If thisRecruit Is Nothing Then
        MessageBox.Show("Woah, that's weird--GetThisRecruit just returned Nothing.")
      Else
        UpdateRecordHxLabel(thisRecruit)
        UpdateRecNum()
        SetAddressPrefRankDefault()
        If tc.SelectedTab.Text = "Project Quit" Then
          FetchWebData()
        End If
      End If
    End If
  End Sub

  Private Sub OnCurrentAddress(ByVal sender As Object, ByVal e As System.EventArgs)
    ' This should probably be the cmAddresses but let's try this for a sec
    If Not Me.cmAddresses.IsBindingSuspended Then
      SetAddressPrefRankDefault()
    End If
  End Sub

  Private Sub SetAddressPrefRankDefault()
    With TrackerApp.Tracker1.Addresses
      Dim NextPref As Integer
      Dim CurrentMax As Object = .Compute("Max(PreferenceRank)", "RecruitID = " & thisRecruit.RecruitID)
      If CurrentMax Is DBNull.Value Then
        NextPref = 1
      Else
        NextPref = CType(CurrentMax, Integer) + 1
      End If
      ' MessageBox.Show("Next preference rank would be " & NextPref.ToString)
      .PreferenceRankColumn.DefaultValue = NextPref
    End With

  End Sub

  Private Sub OnCurrentContact(ByVal sender As Object, ByVal e As System.EventArgs)

    Dim x As BindingManagerBase = CType(sender, BindingManagerBase)
    ' If TypeOf x.Current Is DataRowView Then
    If Not x.IsBindingSuspended Then
      Dim drv As DataRowView = CType(x.Current, DataRowView)

      If drv.IsNew() Then
        If TypeOf drv.Row Is TrackerData.RecruitContactsRow Then
          Dim c As TrackerData.RecruitContactsRow = CType(drv.Row, TrackerData.RecruitContactsRow)
          c.ContactDate = Now
        ElseIf TypeOf drv.Row Is TrackerData.RecruitStatusesRow Then
          Dim c As TrackerData.RecruitStatusesRow = CType(drv.Row, TrackerData.RecruitStatusesRow)
          c.StatusDate = Now
          ' c.ContactDate = Now
        End If
      End If

    End If
  End Sub

#Region "Navigation Handlers"
  Private Sub btnGoFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoFirst.Click
    Me.cmRecruits.Position = 0
  End Sub

  Private Sub btnGoPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoPrevious.Click
    Me.cmRecruits.Position -= 1
  End Sub

  Private Sub btnGoNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoNext.Click
    Me.cmRecruits.Position += 1
  End Sub

  Private Sub btnGoLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoLast.Click
    Me.cmRecruits.Position = Me.cmRecruits.Count
  End Sub
#End Region

  'Private Sub ContactDate_Clicked(ByVal sender As Object _
  '      , ByVal e As EventArgs)
  '   ' I spent just a little time seeing if I could trace Sender (a DataGridTextBox)
  '   ' back to the column to which it was bound--no dice.  So I set them both here.
  '   ' Its kludgy, but it works.
  '   'TrackerApp.Tracker1.RecruitContacts.ContactDateColumn.DefaultValue = DateTime.Now
  '   'TrackerApp.Tracker1.RecruitStatuses.StatusDateColumn.DefaultValue = DateTime.Now
  'End Sub

  Private Sub btnNewAccessCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewAccessCode.Click
    Dim r As TrackerData.RecruitsRow
    r = GetThisRecruit()
    If r.RowState <> DataRowState.Unchanged Then
      MessageBox.Show("You've got to save your changes to the database first.")
      Return
    End If
    Dim OldCode As String = r.AccCode
    If MessageBox.Show("Are you sure you want to assign this person a new Access Code?  This is not easy to un-do.", "Have a care now...", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = wf.DialogResult.Yes Then
      ' MessageBox.Show("pretend I assigned a new access code to recruit " & r.RecruitID)
      Dim f As frmTracker = CType(Me.MdiParent, frmTracker)
      Dim cmd As New SqlClient.SqlCommand
      Dim t As SqlClient.SqlTransaction = Nothing
      Try
        With cmd
          .Connection = f.SqlConnection1
          If .Connection.State <> ConnectionState.Open Then .Connection.Open()
          t = .Connection.BeginTransaction
          .Transaction = t
          .CommandType = CommandType.StoredProcedure
          .CommandText = "AssignAccCode"
          .Parameters.Add(New SqlClient.SqlParameter("@RecruitID", r.RecruitID))
          .Parameters.Add(New SqlClient.SqlParameter("@Study", r.Study))
        End With
        Dim NewCode As String
        cmd.ExecuteNonQuery()
        With cmd
          .CommandType = CommandType.Text
          .CommandText = "select acccode from recruits where recruitid = @RecruitID"
          .Parameters.Remove(.Parameters("@Study"))
          NewCode = CType(.ExecuteScalar, String)
        End With
        ' f.RefreshThisRecruit()
        Select Case r.Study
          Case 4, 6
            ' project quit 2--pretend we already sent RE recs under the new code so that we don't really send them to umich.
            With cmd
              .Parameters.Clear()
              ' .CommandText = "update pq2_sent_re_recs set accesscode = @NewCode where accesscode = @OldCode"
              .CommandText = "insert into pq2_sent_re_recs(accesscode, sentdate, letter_type, date_record_sent) " & _
                              "select accesscode, sentdate, letter_type, '2007-12-25' as date_record_sent " & _
                              "from pq2_unsent_re_recs_vw " & _
                              "where accesscode = @NewCode"
              .Parameters.Add(New SqlClient.SqlParameter("@NewCode", NewCode))
              ' .Parameters.Add(New SqlClient.SqlParameter("@OldCode", OldCode))
              .ExecuteNonQuery()
            End With

        End Select
        If MessageBox.Show("The new code is '" & NewCode & "'--are you sure you want to go through with this?", "Last chance to bail...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = wf.DialogResult.Yes Then
          TrackerApp.Tracker1.Recruits.AccCodeColumn.ReadOnly = False
          t.Commit()
          f.RefreshThisRecruit()
          TrackerApp.Tracker1.Recruits.AccCodeColumn.ReadOnly = True
          MessageBox.Show("New code assigned.")
        Else
          t.Rollback()
          MessageBox.Show("No changes made.")
        End If
        t = Nothing
        With cmd.Connection
          If .State = ConnectionState.Open Then .Close()
        End With
      Catch sex As SqlClient.SqlException
        If Not t Is Nothing Then
          t.Rollback()
          t = Nothing
        End If
        MessageBox.Show("Unanticipated error at the server: " & se.NewLine _
           & "Error #" & sex.Number & " in proc " & sex.Procedure & ": " & sex.Message & se.NewLine _
           & "No changes were made to the database.")
      Catch ex As Exception
        MessageBox.Show("Unanticipated error : " & se.NewLine _
           & ex.Message & se.NewLine _
           & "No changes were made to the database.")
        Debug.WriteLine(ex.ToString)
        If Not t Is Nothing Then
          t.Rollback()
          t = Nothing
        End If
      End Try
    End If
  End Sub

  Public Function FixingToSave() As Boolean Implements DataboundForm.EndPendingEdits
    ' End any pending edits.
    'MessageBox.Show("Leaving " & Me.Name & " cm says IsEdit is " & CType(cm.Current, DataRowView).IsEdit.ToString)
    Try
      ' Dim bmb As BindingManagerBase
      ' Dim bmb As CurrencyManager
      Me.txtFirstName.Focus()
      TrackerApp.FlushDataGrid(dgContacts)
      TrackerApp.FlushDataGrid(dgAddresses)
      TrackerApp.FlushDataGrid(dgPhoneNumbers)
      TrackerApp.FlushDataGrid(dgStatus)

      'bmb = Me.txtNameSuffix.DataBindings.Item("Text").BindingManagerBase
      '' bmb = BindingContext(TrackerApp.Tracker1, "Recruits")
      'Dim drv As DataRowView = CType(bmb.Current, DataRowView)
      'Dim r As TrackerData.RecruitsRow = CType(drv.Row, TrackerData.RecruitsRow)
      'If drv.IsEdit Then r.EndEdit()
      'bmb.EndCurrentEdit()
      'cmRecruits = Nothing
      'cmRecruits = CType(Me.txtAccNum.DataBindings.Item("Text").BindingManagerBase, CurrencyManager)
      cmRecruits.EndCurrentEdit()

      Return True
    Catch ex As System.Data.NoNullAllowedException
      MessageBox.Show(ex.Message)
      Return False
    End Try
    ' CType(Me.MdiParent, frmCHCRTracker).pServer.Text = "Leaving " & Me.Name & " x says IsEdit is " & CType(x.Current, DataRowView).IsEdit.ToString
    ' Beep()

  End Function

  Private Sub frmRecruitDetail_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    Me.FixingToSave()
    TrackerApp.Settings.Save()
    If TrackerApp.Tracker1.HasChanges Then
      If MessageBox.Show("Save your changes?", "There are uncommitted changes", MessageBoxButtons.YesNo) = wf.DialogResult.Yes Then
        CType(Me.MdiParent, frmTracker).CommitChanges()
      Else
        MessageBox.Show("You must either save or cancel your changes", "Can't leave with uncommitted changes")
        e.Cancel = True
      End If
    End If
  End Sub

  Private Sub NewAddressClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Me.Text = sender.ToString
    Console.WriteLine(sender.ToString)
    Console.WriteLine(sender.GetType.ToString())
  End Sub

  Public ReadOnly Property CurrentRecruitID() As Integer Implements DataboundForm.CurrentRecruitID
    Get
      Return thisRecruit.RecruitID
    End Get
  End Property

  Private Sub mnuAddToAddresses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddToAddresses.Click
    ' MessageBox.Show("Pretend I added the address w/Line 1 = """ & ua.Line1 & """")
    Dim ua As TrackerData.UpdatedAddressesRow = GetCurrentUpdatedAddress()
    Dim newa As TrackerData.AddressesRow = TrackerApp.Tracker1.Addresses.NewAddressesRow
    newa.RecruitID = ua.RecruitID
    newa.Line1 = ua.Line1
    If Not ua.IsLine2Null Then
      newa.Line2 = ua.Line2
    End If
    newa.City = ua.City
    newa.State = ua.State
    newa.Zip = ua.Zip
    Tracker1.Addresses.AddAddressesRow(newa)
    SetAddressPrefRankDefault()
    ua.Delete()
  End Sub

  Private Sub tc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    TrackerApp.Settings.LastDetailTabPage = CType(sender, TabControl).SelectedIndex
  End Sub

  Private Sub mnuDeleteThis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteThis.Click
    Dim ua As TrackerData.UpdatedAddressesRow = GetCurrentUpdatedAddress()
    ua.Delete()
  End Sub

  Private Function GetCurrentUpdatedAddress() As TrackerData.UpdatedAddressesRow
    Dim cm As CurrencyManager
    With Me.dgUpdatedAddresses
      cm = CType(.BindingContext(.DataSource, .DataMember), CurrencyManager)
      Dim drv As DataRowView = CType(cm.Current, DataRowView)
      Return CType(drv.Row, TrackerData.UpdatedAddressesRow)
    End With

  End Function

  Private Sub mnuDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteAll.Click
    Dim cm As CurrencyManager
    cm = CType(Me.BindingContext(TrackerApp.Tracker1, "Recruits"), CurrencyManager)
    Dim drv As DataRowView = CType(cm.Current, DataRowView)
    Dim r As TrackerData.RecruitsRow = CType(drv.Row, TrackerData.RecruitsRow)
    For Each ro As DataRow In r.GetUpdatedAddressesRows
      ro.Delete()
    Next
  End Sub



  Private Sub FetchWebData()
    Dim dr As System.Data.SqlClient.SqlDataReader
    Dim s As String = "select *            " & _
                      "from  pq_web_entered_info_vw " & _
                      "where recruitid = @recruitid"

    Dim cmd As New SqlClient.SqlCommand(s, CType(Me.MdiParent, frmTracker).SqlConnection1)
    cmd.Parameters.Add(New SqlClient.SqlParameter("@recruitid", SqlDbType.Int, 4))
    cmd.Parameters.Item("@recruitid").Value = Me.CurrentRecruitID
    cmd.Connection.Open()
    dr = cmd.ExecuteReader
    ClearWebData()
    With dr
      While .Read()
        Me.txtWebConsumno.Text = .Item("hmomemberid").ToString
        Me.txtWebHomePhone.Text = .Item("homephone").ToString
        Me.txtWebAddress1.Text = .Item("addressline1").ToString
        Me.txtWebAddress2.Text = .Item("addressline2").ToString
        Me.txtWebCityStateZip.Text = .Item("addressline3").ToString
        Me.txtWebBirthDate.Text = .Item("birth_date").ToString
        Me.txtWebName.Text = .Item("name").ToString
        Me.txtWebQuitDate.Text = CDate(.Item("quitdate")).ToString("d")
      End While
      cmd.Connection.Close()
      ' Beep()
    End With
  End Sub

  Private Sub ClearWebData()
    For Each txt As Control In Me.gbWebEnteredInfo.Controls
      If TypeOf txt Is TextBox Then
        txt.Text = String.Empty
      End If
    Next
  End Sub

  Private Sub tc_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tc.SelectedIndexChanged
    If tc.SelectedTab.Text = "Project Quit" Then
      FetchWebData()
    End If
  End Sub

  Private Sub btnMarkEnrolled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarkEnrolled.Click
    InsertStatus(Statuses.EnrolleeYes)
  End Sub
  Private Sub InsertStatus(ByVal which As Statuses)
    If Not StatusesToInsert.ContainsKey(which) Then
      StatusesToInsert.Add(which, FindStatus(which))
    End If

    Dim sr As TrackerData.RecruitStatusesRow = TrackerApp.Tracker1.RecruitStatuses.NewRecruitStatusesRow()
    With sr
      .RecruitID = thisRecruit.RecruitID
      .Status = CType(StatusesToInsert.Item(which), Integer)
      .StatusDate = Date.Now
    End With
    TrackerApp.Tracker1.RecruitStatuses.Rows.Add(sr)
    MessageBox.Show("Done--don't forget to save your changes!")
  End Sub
  Private Function FindStatus(ByVal which As Statuses) As Integer
    Dim ret As Integer = -1
    Dim strSearch As String = String.Empty
    Select Case which
      Case Statuses.EnrolleeNo
        strSearch = "Enrollment DISCONFIRMED"
      Case Statuses.EnrolleeYes
        strSearch = "Enrollment Manually Verif"
      Case Statuses.NewQuitDate
        strSearch = "New quit date"
    End Select

    For Each c As TrackerData.StatusesRow In TrackerApp.Tracker1.Statuses.Select("StatusDescription LIKE '*" & strSearch & "*'")
      ret = c.Status
    Next
    If ret = -1 Then Throw New Exception("Problem!  Didn't find a status corresponding to " & which.ToString & "!")
    Return ret
  End Function

  Private Sub btnMarkNotEnrolled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarkNotEnrolled.Click
    InsertStatus(Statuses.EnrolleeNo)
  End Sub

  Private Sub txtQuitDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuitDate.Validated
    If vbYes = MessageBox.Show("If this person's quit date has changed, then we should send this information to UMich.  Would you like me to add a Status record so that the new quit date goes to UMich?", "New Quit Date?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) Then
      ' MessageBox.Show("Pretend I did that...")
      InsertStatus(Statuses.NewQuitDate)
    End If
  End Sub


End Class