Public Class frmRecruitBrowser
  Inherits System.Windows.Forms.Form
  Implements DataboundForm
    Private MainForm As frmTracker
    Friend WithEvents tbcPersonType As System.Windows.Forms.DataGridTextBoxColumn
    Private NavCount As Int16

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
  Friend WithEvents dgTracker As System.Windows.Forms.DataGrid
    Friend WithEvents dgsRecruits As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents tbcAccCode As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcFirst As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcMiddle As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcLast As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcSuffix As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcAddedOn As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcSex As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcDOB As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcLastVisit As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcSampleProgram As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dgsContacts As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents tbcContactDate As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcInitiator As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcResult As System.Windows.Forms.DataGridTextBoxColumn
    ' Friend WithEvents tbcType As System.Windows.Forms.DataGridTextBoxColumn
    ' Friend WithEvents tbcType As DataGridComboBoxColumn
    Friend WithEvents tbcType As DGColumnStyles.DataGridComboBoxColumn ' DataGridBoundComboLib.DataGridComboBoxColumn
    ' Friend WithEvents tbcNotes As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcNotes As DGColumnStyles.WrappingTextBoxColumn
    Friend WithEvents tbcStaffPerson As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dgsStatuses As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents tbcDate As System.Windows.Forms.DataGridTextBoxColumn
    ' Friend WithEvents tbcStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcStatus As DGColumnStyles.DataGridComboBoxColumn
    Friend WithEvents tbcRecordedBy As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dgsPhoneNumbers As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents tbcAreaCode As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcPhoneNumber As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcPhoneType As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcSource As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcExtension As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcPhoneRecordedBy As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dgsAddresses As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents tbcPreference As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcLine1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcLine2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcCity As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcState As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcZip As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcAddrRecordedBy As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcBounceDate As System.Windows.Forms.DataGridTextBoxColumn
    ' Friend WithEvents tbcStatusTest As System.Windows.Forms.DataGridTextBoxColumn
    ' Friend WithEvents tbcStatusTest As DGColumnStyles.DataGridComboBoxColumn
    Friend WithEvents tbcTypeDescription As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcCurrentStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbcEMailAddress As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dvRecruits As System.Data.DataView
    Friend WithEvents tbcIncentive As System.Windows.Forms.DataGridTextBoxColumn

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.dgTracker = New System.Windows.Forms.DataGrid
        Me.dvRecruits = New System.Data.DataView
        Me.dgsRecruits = New System.Windows.Forms.DataGridTableStyle
        Me.tbcAccCode = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcFirst = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcMiddle = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcLast = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcSuffix = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcSex = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcDOB = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcEMailAddress = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcLastVisit = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcAddedOn = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcSampleProgram = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcCurrentStatus = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcIncentive = New System.Windows.Forms.DataGridTextBoxColumn
        Me.dgsContacts = New System.Windows.Forms.DataGridTableStyle
        Me.tbcContactDate = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcType = New DGColumnStyles.DataGridComboBoxColumn
        Me.tbcInitiator = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcResult = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcNotes = New DGColumnStyles.WrappingTextBoxColumn
        Me.tbcStaffPerson = New System.Windows.Forms.DataGridTextBoxColumn
        Me.dgsStatuses = New System.Windows.Forms.DataGridTableStyle
        Me.tbcDate = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcStatus = New DGColumnStyles.DataGridComboBoxColumn
        Me.tbcRecordedBy = New System.Windows.Forms.DataGridTextBoxColumn
        Me.dgsPhoneNumbers = New System.Windows.Forms.DataGridTableStyle
        Me.tbcAreaCode = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcPhoneNumber = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcExtension = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcPhoneType = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcSource = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcPhoneRecordedBy = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcTypeDescription = New System.Windows.Forms.DataGridTextBoxColumn
        Me.dgsAddresses = New System.Windows.Forms.DataGridTableStyle
        Me.tbcPreference = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcLine1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcLine2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcCity = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcState = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcZip = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcAddrRecordedBy = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcBounceDate = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcPersonType = New System.Windows.Forms.DataGridTextBoxColumn
    CType(Me.dgTracker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvRecruits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
    'dgTracker
        '
    Me.dgTracker.BackgroundColor = System.Drawing.Color.LightGray
    Me.dgTracker.CaptionText = "Recruits"
    Me.dgTracker.DataMember = ""
    Me.dgTracker.DataSource = Me.dvRecruits
    Me.dgTracker.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dgTracker.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dgTracker.Location = New System.Drawing.Point(0, 0)
    Me.dgTracker.Name = "dgTracker"
    Me.dgTracker.Size = New System.Drawing.Size(896, 422)
    Me.dgTracker.TabIndex = 0
    Me.dgTracker.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgsRecruits, Me.dgsContacts, Me.dgsStatuses, Me.dgsPhoneNumbers, Me.dgsAddresses})
        '
        'dvRecruits
        '
        Me.dvRecruits.AllowNew = False
        '
        'dgsRecruits
        '
        Me.dgsRecruits.AlternatingBackColor = System.Drawing.Color.Lavender
    Me.dgsRecruits.DataGrid = Me.dgTracker
        Me.dgsRecruits.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.tbcAccCode, Me.tbcFirst, Me.tbcMiddle, Me.tbcLast, Me.tbcSuffix, Me.tbcSex, Me.tbcDOB, Me.tbcEMailAddress, Me.tbcLastVisit, Me.tbcAddedOn, Me.tbcSampleProgram, Me.tbcCurrentStatus, Me.tbcIncentive, Me.tbcPersonType})
        Me.dgsRecruits.GridLineColor = System.Drawing.SystemColors.ControlText
        Me.dgsRecruits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgsRecruits.MappingName = "Recruits"
        Me.dgsRecruits.PreferredColumnWidth = 175
        '
        'tbcAccCode
        '
        Me.tbcAccCode.Format = ""
        Me.tbcAccCode.FormatInfo = Nothing
        Me.tbcAccCode.HeaderText = "Access Code"
        Me.tbcAccCode.MappingName = "AccCode"
        Me.tbcAccCode.ReadOnly = True
        Me.tbcAccCode.Width = 80
        '
        'tbcFirst
        '
        Me.tbcFirst.Format = ""
        Me.tbcFirst.FormatInfo = Nothing
        Me.tbcFirst.HeaderText = "First"
        Me.tbcFirst.MappingName = "FirstName"
        Me.tbcFirst.Width = 75
        '
        'tbcMiddle
        '
        Me.tbcMiddle.Format = ""
        Me.tbcMiddle.FormatInfo = Nothing
        Me.tbcMiddle.HeaderText = "Middle"
        Me.tbcMiddle.MappingName = "MiddleName"
        Me.tbcMiddle.NullText = ""
        Me.tbcMiddle.Width = 30
        '
        'tbcLast
        '
        Me.tbcLast.Format = ""
        Me.tbcLast.FormatInfo = Nothing
        Me.tbcLast.HeaderText = "Last"
        Me.tbcLast.MappingName = "LastName"
        Me.tbcLast.Width = 75
        '
        'tbcSuffix
        '
        Me.tbcSuffix.Format = ""
        Me.tbcSuffix.FormatInfo = Nothing
        Me.tbcSuffix.HeaderText = "Suffix"
        Me.tbcSuffix.MappingName = "NameSuffix"
        Me.tbcSuffix.NullText = ""
        Me.tbcSuffix.Width = 50
        '
        'tbcSex
        '
        Me.tbcSex.Format = ""
        Me.tbcSex.FormatInfo = Nothing
        Me.tbcSex.HeaderText = "Sex"
        Me.tbcSex.MappingName = "Sex"
        Me.tbcSex.NullText = ""
        Me.tbcSex.Width = 50
        '
        'tbcDOB
        '
        Me.tbcDOB.Format = "MM/dd/yyyy"
        Me.tbcDOB.FormatInfo = Nothing
        Me.tbcDOB.HeaderText = "DOB"
        Me.tbcDOB.MappingName = "BDate"
        Me.tbcDOB.Width = 90
        '
        'tbcEMailAddress
        '
        Me.tbcEMailAddress.Format = ""
        Me.tbcEMailAddress.FormatInfo = Nothing
        Me.tbcEMailAddress.HeaderText = "E-Mail Address"
        Me.tbcEMailAddress.MappingName = "EMailAddress"
        Me.tbcEMailAddress.Width = 175
        '
        'tbcLastVisit
        '
        Me.tbcLastVisit.Format = "MM/dd/yyyy"
        Me.tbcLastVisit.FormatInfo = Nothing
        Me.tbcLastVisit.HeaderText = "Last Visit"
        Me.tbcLastVisit.MappingName = "LastVistDate"
        Me.tbcLastVisit.Width = 90
        '
        'tbcAddedOn
        '
        Me.tbcAddedOn.Format = "MM/dd/yyyy"
        Me.tbcAddedOn.FormatInfo = Nothing
        Me.tbcAddedOn.HeaderText = "Added On"
        Me.tbcAddedOn.MappingName = "AddedDate"
        Me.tbcAddedOn.NullText = ""
        Me.tbcAddedOn.Width = 90
        '
        'tbcSampleProgram
        '
        Me.tbcSampleProgram.Format = ""
        Me.tbcSampleProgram.FormatInfo = Nothing
        Me.tbcSampleProgram.HeaderText = "Sample Program"
        Me.tbcSampleProgram.MappingName = "RecruitProgVersion"
        Me.tbcSampleProgram.Width = 60
        '
        'tbcCurrentStatus
        '
        Me.tbcCurrentStatus.Format = ""
        Me.tbcCurrentStatus.FormatInfo = Nothing
        Me.tbcCurrentStatus.HeaderText = "Current Status"
        Me.tbcCurrentStatus.MappingName = "StatusDescription"
        Me.tbcCurrentStatus.ReadOnly = True
        Me.tbcCurrentStatus.Width = 175
        '
        'tbcIncentive
        '
        Me.tbcIncentive.Format = ""
        Me.tbcIncentive.FormatInfo = Nothing
        Me.tbcIncentive.HeaderText = "Incentive"
        Me.tbcIncentive.MappingName = "Incentive"
        Me.tbcIncentive.Width = 125
        '
        'dgsContacts
        '
        Me.dgsContacts.AlternatingBackColor = System.Drawing.Color.Lavender
    Me.dgsContacts.DataGrid = Me.dgTracker
        Me.dgsContacts.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.tbcContactDate, Me.tbcType, Me.tbcInitiator, Me.tbcResult, Me.tbcNotes, Me.tbcStaffPerson})
        Me.dgsContacts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgsContacts.MappingName = "RecruitContacts"
        '
        'tbcContactDate
        '
        Me.tbcContactDate.Format = "g"
        Me.tbcContactDate.FormatInfo = Nothing
        Me.tbcContactDate.HeaderText = "Date"
        Me.tbcContactDate.MappingName = "ContactDate"
        Me.tbcContactDate.Width = 200
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
        Me.tbcStaffPerson.Width = 75
        '
        'dgsStatuses
        '
        Me.dgsStatuses.AlternatingBackColor = System.Drawing.Color.Lavender
    Me.dgsStatuses.DataGrid = Me.dgTracker
        Me.dgsStatuses.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.tbcDate, Me.tbcStatus, Me.tbcRecordedBy})
        Me.dgsStatuses.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgsStatuses.MappingName = "RecruitStatuses"
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
        'tbcStatus
        '
        Me.tbcStatus.Format = ""
        Me.tbcStatus.FormatInfo = Nothing
        Me.tbcStatus.HeaderText = "Status"
        Me.tbcStatus.MappingName = "Status"
        Me.tbcStatus.NullText = ""
        Me.tbcStatus.Width = 75
        '
        'tbcRecordedBy
        '
        Me.tbcRecordedBy.Format = ""
        Me.tbcRecordedBy.FormatInfo = Nothing
        Me.tbcRecordedBy.HeaderText = "Recorded By"
        Me.tbcRecordedBy.MappingName = "AddedBy"
        Me.tbcRecordedBy.Width = 75
        '
        'dgsPhoneNumbers
        '
        Me.dgsPhoneNumbers.AlternatingBackColor = System.Drawing.Color.Lavender
    Me.dgsPhoneNumbers.DataGrid = Me.dgTracker
        Me.dgsPhoneNumbers.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.tbcAreaCode, Me.tbcPhoneNumber, Me.tbcExtension, Me.tbcPhoneType, Me.tbcSource, Me.tbcPhoneRecordedBy, Me.tbcTypeDescription})
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
        Me.tbcPhoneRecordedBy.Width = 75
        '
        'tbcTypeDescription
        '
        Me.tbcTypeDescription.Format = ""
        Me.tbcTypeDescription.FormatInfo = Nothing
        Me.tbcTypeDescription.HeaderText = "Type Description"
        Me.tbcTypeDescription.MappingName = "TypeDescription"
        Me.tbcTypeDescription.Width = 120
        '
        'dgsAddresses
        '
        Me.dgsAddresses.AlternatingBackColor = System.Drawing.Color.Lavender
    Me.dgsAddresses.DataGrid = Me.dgTracker
        Me.dgsAddresses.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.tbcPreference, Me.tbcLine1, Me.tbcLine2, Me.tbcCity, Me.tbcState, Me.tbcZip, Me.tbcAddrRecordedBy, Me.tbcBounceDate})
        Me.dgsAddresses.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgsAddresses.MappingName = "Addresses"
        '
        'tbcPreference
        '
        Me.tbcPreference.Format = ""
        Me.tbcPreference.FormatInfo = Nothing
        Me.tbcPreference.HeaderText = "Preference"
        Me.tbcPreference.MappingName = "PreferenceRank"
        Me.tbcPreference.NullText = ""
        Me.tbcPreference.Width = 50
        '
        'tbcLine1
        '
        Me.tbcLine1.Format = ""
        Me.tbcLine1.FormatInfo = Nothing
        Me.tbcLine1.HeaderText = "Line 1"
        Me.tbcLine1.MappingName = "Line1"
        Me.tbcLine1.NullText = ""
        Me.tbcLine1.Width = 200
        '
        'tbcLine2
        '
        Me.tbcLine2.Format = ""
        Me.tbcLine2.FormatInfo = Nothing
        Me.tbcLine2.HeaderText = "Line 2"
        Me.tbcLine2.MappingName = "Line2"
        Me.tbcLine2.NullText = ""
        Me.tbcLine2.Width = 150
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
        Me.tbcState.Width = 75
        '
        'tbcZip
        '
        Me.tbcZip.Format = "00000-0000"
        Me.tbcZip.FormatInfo = Nothing
        Me.tbcZip.HeaderText = "Zip"
        Me.tbcZip.MappingName = "Zip"
        Me.tbcZip.NullText = ""
        Me.tbcZip.Width = 75
        '
        'tbcAddrRecordedBy
        '
        Me.tbcAddrRecordedBy.Format = ""
        Me.tbcAddrRecordedBy.FormatInfo = Nothing
        Me.tbcAddrRecordedBy.HeaderText = "Recorded By"
        Me.tbcAddrRecordedBy.MappingName = "AddedBy"
        Me.tbcAddrRecordedBy.NullText = ""
        Me.tbcAddrRecordedBy.Width = 75
        '
        'tbcBounceDate
        '
        Me.tbcBounceDate.Format = "MM/dd/yyyy"
        Me.tbcBounceDate.FormatInfo = Nothing
        Me.tbcBounceDate.HeaderText = "Bounce Date"
        Me.tbcBounceDate.MappingName = "BounceDate"
        Me.tbcBounceDate.NullText = ""
        Me.tbcBounceDate.Width = 90
        '
        'tbcPersonType
        '
        Me.tbcPersonType.Format = ""
        Me.tbcPersonType.FormatInfo = Nothing
        Me.tbcPersonType.HeaderText = "Type"
        Me.tbcPersonType.MappingName = "PersonType"
        Me.tbcPersonType.ReadOnly = True
        Me.tbcPersonType.Width = 175
        '
        'frmRecruitBrowser
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(896, 422)
    Me.Controls.Add(Me.dgTracker)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmRecruitBrowser"
        Me.Text = "CHCR Recruit Browser"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.dgTracker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvRecruits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

  Public Sub BindGrid(ByVal ds As TrackerData)
    With Me.dgTracker
      ' Me.DataView1.Table = ds.Recruits
      .DataSource = ds
      .DataMember = ds.Recruits.TableName
      ' .DataSource = Me.DataView1
    End With

    ' Lets try to track the position of the contacts list.
    Dim cmContacts As CurrencyManager
    cmContacts = CType(Me.BindingContext(dgTracker.DataSource, "Recruits.Contacts"), CurrencyManager)
    AddHandler cmContacts.CurrentChanged, AddressOf OnCurrentContact

    ' And likewise for the statuses list.
    Dim cmStatuses As CurrencyManager
    cmStatuses = CType(Me.BindingContext(dgTracker.DataSource, "Recruits.Status History"), CurrencyManager)
    AddHandler cmStatuses.CurrentChanged, AddressOf OnCurrentStatus

  End Sub

    Private Sub frmRecruitBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainForm = CType(Me.MdiParent, frmTracker)
        MainForm.pStatus.Text = "Ready"
        With Me.tbcType.ColumnComboBox
      .DataSource = TrackerApp.Tracker1.ContactTypes
            .DisplayMember = "ContactTypeDescription"
            .ValueMember = "ContactType"
            Me.dgsContacts.PreferredRowHeight = .Height + 1
        End With

        With Me.tbcStatus.ColumnComboBox
      .DataSource = TrackerApp.Tracker1.Statuses.DefaultView
            .DisplayMember = "StatusDescription"
            .ValueMember = "Status"
            Me.dgsStatuses.PreferredRowHeight = .Height + 1
        End With
    End Sub

  Private Sub OnCurrentContact(ByVal sender As Object, ByVal e As System.EventArgs)

    Dim x As BindingManagerBase = CType(sender, BindingManagerBase)
    If Not x.IsBindingSuspended Then
      Dim drv As DataRowView = CType(x.Current, DataRowView)
      If drv.IsNew() Then
        Dim c As TrackerData.RecruitContactsRow = CType(drv.Row, TrackerData.RecruitContactsRow)
        c.ContactDate = Now
      End If

    End If
  End Sub

  Private Sub OnCurrentStatus(ByVal sender As Object, ByVal e As System.EventArgs)

    Dim x As BindingManagerBase = CType(sender, BindingManagerBase)
    If Not x.IsBindingSuspended Then
      Dim drv As DataRowView = CType(x.Current, DataRowView)
      If drv.IsNew() Then
        Dim c As TrackerData.RecruitStatusesRow = CType(drv.Row, TrackerData.RecruitStatusesRow)
        c.StatusDate = Now
      End If

    End If
  End Sub

  Public Function FixingToSave() As Boolean Implements DataboundForm.EndPendingEdits
    Try
      'Dim bmb As BindingManagerBase
      'With Me.dgTracker
      '   bmb = .BindingContext(.DataSource, .DataMember)
      'End With
      'bmb.EndCurrentEdit()
      TrackerApp.FlushDataGrid(Me.dgTracker)
      Return True
    Catch ex As System.Data.NoNullAllowedException
      MessageBox.Show(ex.Message)
      Return False
    End Try
  End Function

  Public ReadOnly Property CurrentRecruitID() As Integer Implements DataboundForm.CurrentRecruitID
    Get
      Dim cm As CurrencyManager
      With dgTracker
        cm = CType(.BindingContext(.DataSource, .DataMember), CurrencyManager)
        Dim drv As DataRowView = CType(cm.Current, DataRowView)
        Return CType(drv.Row, TrackerData.RecruitsRow).RecruitID
      End With
    End Get
  End Property
End Class
