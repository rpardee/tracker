Imports sd = System.Data
Imports se = System.Environment
Imports wf = system.Windows.Forms

Public Enum MailingType
  macPQLetter = 0
  macPQReminder = 1
  macGTDLetter = 2
  macGTDThankYou = 3
  macGTDPreincentive = 4
  macGTDThankYouCashReport = 5
  macGTDPreincentiveCashRequest = 6
  macGTDReminder = 7
End Enum

Public Class frmTracker
  Inherits System.Windows.Forms.Form
  Private Adapters As New ArrayList

  Private Refresher As TrackerData

  Private NumAdds As Int32
  Private NumUpdates As Int32
  Private NumDeletes As Int32

  Private frmSplash As Form

  Public Delegate Function GetDataDelegate() As Integer
  Private delSubstantive As New GetDataDelegate(AddressOf GetSubstantiveData)
  Private delLookup As New GetDataDelegate(AddressOf FillLookupTables)
  Private ar As IAsyncResult
  Friend WithEvents SqlUpdateCommand As System.Data.SqlClient.SqlCommand
  Friend WithEvents mnuMailingPreincentive As System.Windows.Forms.MenuItem
  Friend WithEvents mnuAccounting As System.Windows.Forms.MenuItem
  Friend WithEvents mnuAccountingBaselineThankyou As System.Windows.Forms.MenuItem
  Friend WithEvents mnuAccountingPreincentiveOrder As System.Windows.Forms.MenuItem

  Private _StudyName As String

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call
    TrackerApp.Tracker1 = New TrackerData

    TrackerApp.Settings = New ppSettings
    TrackerApp.Settings.Load()

    ' Working around an IDE bug that tends to lose the prop-browser-set table mappings
    With Me.sdaGetSubstantiveData.TableMappings
      .Clear()
      .AddRange(New System.Data.Common.DataTableMapping() _
      {New System.Data.Common.DataTableMapping("Table", "Recruits", New System.Data.Common.DataColumnMapping(-1) {}) _
      , New System.Data.Common.DataTableMapping("Table1", "Addresses", New System.Data.Common.DataColumnMapping(-1) {}) _
      , New System.Data.Common.DataTableMapping("Table2", "PhoneNumbers", New System.Data.Common.DataColumnMapping(-1) {}) _
      , New System.Data.Common.DataTableMapping("Table3", "RecruitContacts", New System.Data.Common.DataColumnMapping(-1) {}) _
      , New System.Data.Common.DataTableMapping("Table4", "RecruitStatuses", New System.Data.Common.DataColumnMapping(-1) {}) _
      , New System.Data.Common.DataTableMapping("Table5", "UpdatedAddresses", New System.Data.Common.DataColumnMapping(-1) {}) _
      })
    End With

    With Me.sdaGetLookupData.TableMappings
      .Clear()
      .AddRange(New System.Data.Common.DataTableMapping() _
         {New System.Data.Common.DataTableMapping("Table", "Studies", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Study", "Study"), New System.Data.Common.DataColumnMapping("StudyName", "StudyName")}) _
         , New System.Data.Common.DataTableMapping("Table1", "Statuses", New System.Data.Common.DataColumnMapping(-1) {}) _
         , New System.Data.Common.DataTableMapping("Table2", "SamplingProgramVersions", New System.Data.Common.DataColumnMapping(-1) {}) _
         , New System.Data.Common.DataTableMapping("Table3", "ContactTypes", New System.Data.Common.DataColumnMapping(-1) {}) _
         , New System.Data.Common.DataTableMapping("Table4", "PhoneNumberTypes", New System.Data.Common.DataColumnMapping(-1) {}) _
         , New System.Data.Common.DataTableMapping("Table5", "Tickler", New System.Data.Common.DataColumnMapping(-1) {}) _
         })
    End With

    With TrackerApp.Tracker1
      .Addresses.StateColumn.DefaultValue = "WA"
      .Addresses.CityColumn.DefaultValue = "Seattle"
      .PhoneNumbers.AreaCodeColumn.DefaultValue = "206"
      .PhoneNumbers.TypeColumn.DefaultValue = "Home"
      .Recruits.DefaultView.AllowNew = False
    End With

    Me.SqlConnection1.ConnectionString = TrackerApp.Settings.ConnectStringFromServerEnum
  End Sub

  'Public Sub New(ByVal frmSplash As Form)
  '   MyBase.New()

  '   'This call is required by the Windows Form Designer.
  '   InitializeComponent()

  '   'Add any initialization after the InitializeComponent() call
  '   Me.frmSplash = frmSplash
  'End Sub

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
  Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
  Friend WithEvents mnuFileBrowseRecruits As System.Windows.Forms.MenuItem
  Friend WithEvents mnuFileExit As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents sdaRecruitStatuses As System.Data.SqlClient.SqlDataAdapter
  Friend WithEvents sdaRecruitContacts As System.Data.SqlClient.SqlDataAdapter
  Friend WithEvents sdaPhoneNumbers As System.Data.SqlClient.SqlDataAdapter
  Friend WithEvents sdaAddresses As System.Data.SqlClient.SqlDataAdapter
  Friend WithEvents sdaRecruits As System.Data.SqlClient.SqlDataAdapter
  Friend WithEvents sbMainX As System.Windows.Forms.StatusBar
  Friend WithEvents pStatus As System.Windows.Forms.StatusBarPanel
  Friend WithEvents pUser As System.Windows.Forms.StatusBarPanel
  Friend WithEvents pServer As System.Windows.Forms.StatusBarPanel
  Friend WithEvents mnuRecruitDetail As System.Windows.Forms.MenuItem
  Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
  Friend WithEvents tbSaveToDb As System.Windows.Forms.ToolBarButton
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents pUserMessage As System.Windows.Forms.StatusBarPanel
  Friend WithEvents mnuFileSave As System.Windows.Forms.MenuItem
  Friend WithEvents mnuTools As System.Windows.Forms.MenuItem
  Friend WithEvents mnuWindow As System.Windows.Forms.MenuItem
  Friend WithEvents tt As System.Windows.Forms.ToolTip
  Friend WithEvents tbCancelChanges As System.Windows.Forms.ToolBarButton
  Friend WithEvents sbChanges As System.Windows.Forms.StatusBarPanel
  Friend WithEvents SqlSelectAddresses As System.Data.SqlClient.SqlCommand
  Friend WithEvents sdaGetLookupData As System.Data.SqlClient.SqlDataAdapter
  Friend WithEvents mnuFileFetchData As System.Windows.Forms.MenuItem
  Friend WithEvents sdaGetSubstantiveData As System.Data.SqlClient.SqlDataAdapter
  Friend WithEvents tbQuery As System.Windows.Forms.ToolBarButton
  Friend WithEvents tbDetail As System.Windows.Forms.ToolBarButton
  Friend WithEvents tbBrowse As System.Windows.Forms.ToolBarButton
  Friend WithEvents tbGenerateMailing As System.Windows.Forms.ToolBarButton
  Friend WithEvents tbRefresh As System.Windows.Forms.ToolBarButton
  Friend WithEvents tbQuickLetter As System.Windows.Forms.ToolBarButton
  Friend WithEvents sqlDeleteRecruitContacts As System.Data.SqlClient.SqlCommand
  Friend WithEvents sqlInsertRecruitContacts As System.Data.SqlClient.SqlCommand
  Friend WithEvents sqlUpdateRecruitContacts As System.Data.SqlClient.SqlCommand
  Friend WithEvents sqlDeletePhoneNumbers As System.Data.SqlClient.SqlCommand
  Friend WithEvents sqlInsertPhoneNumbers As System.Data.SqlClient.SqlCommand
  Friend WithEvents sqlUpdatePhoneNumbers As System.Data.SqlClient.SqlCommand
  Friend WithEvents sqlDeleteAddresses As System.Data.SqlClient.SqlCommand
  Friend WithEvents sqlInsertAddresses As System.Data.SqlClient.SqlCommand
  Friend WithEvents sqlUpdateAddresses As System.Data.SqlClient.SqlCommand
  Friend WithEvents sqlUpdateRecruits As System.Data.SqlClient.SqlCommand
  Friend WithEvents sqlDeleteRecruitStatuses As System.Data.SqlClient.SqlCommand
  Friend WithEvents sqlInsertRecruitStatuses As System.Data.SqlClient.SqlCommand
  Friend WithEvents sqlUpdateRecruitStatuses As System.Data.SqlClient.SqlCommand
  Friend WithEvents tbGenerateReminder As System.Windows.Forms.ToolBarButton
  Friend WithEvents MailSep1 As System.Windows.Forms.ToolBarButton
  Friend WithEvents MailSep2 As System.Windows.Forms.ToolBarButton
  Friend WithEvents ctReports As System.Windows.Forms.ContextMenu
  Friend WithEvents tbReports As System.Windows.Forms.ToolBarButton
  Friend WithEvents mnuReportsStatusOverview As System.Windows.Forms.MenuItem
  Friend WithEvents mnuReportsContactLog As System.Windows.Forms.MenuItem
  Friend WithEvents mnuReports As System.Windows.Forms.MenuItem
  Friend WithEvents mnuMainReportsStatusOverview As System.Windows.Forms.MenuItem
  Friend WithEvents mnuMainReportsContactLog As System.Windows.Forms.MenuItem
  Friend WithEvents tbExtra As System.Windows.Forms.ToolBarButton
  Friend WithEvents sdaUpdatedAddresses As System.Data.SqlClient.SqlDataAdapter
  Friend WithEvents sqlDeleteUpdatedAddresses As System.Data.SqlClient.SqlCommand
  Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
  Friend WithEvents SqlSelectCommand2 As System.Data.SqlClient.SqlCommand
  Friend WithEvents mnuMailingsInvitationLetter As System.Windows.Forms.MenuItem
  Friend WithEvents mnuMailingsThankYou As System.Windows.Forms.MenuItem
  Friend WithEvents mnuMailingsReminder As System.Windows.Forms.MenuItem
  Friend WithEvents mnuMailings As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTracker))
    Me.sdaGetLookupData = New System.Data.SqlClient.SqlDataAdapter
    Me.SqlSelectCommand2 = New System.Data.SqlClient.SqlCommand
    Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
    Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
    Me.mnuFile = New System.Windows.Forms.MenuItem
    Me.mnuFileFetchData = New System.Windows.Forms.MenuItem
    Me.mnuFileSave = New System.Windows.Forms.MenuItem
    Me.MenuItem1 = New System.Windows.Forms.MenuItem
    Me.mnuFileExit = New System.Windows.Forms.MenuItem
    Me.mnuTools = New System.Windows.Forms.MenuItem
    Me.mnuRecruitDetail = New System.Windows.Forms.MenuItem
    Me.mnuFileBrowseRecruits = New System.Windows.Forms.MenuItem
    Me.mnuReports = New System.Windows.Forms.MenuItem
    Me.mnuMainReportsStatusOverview = New System.Windows.Forms.MenuItem
    Me.mnuMainReportsContactLog = New System.Windows.Forms.MenuItem
    Me.mnuMailings = New System.Windows.Forms.MenuItem
    Me.mnuMailingsInvitationLetter = New System.Windows.Forms.MenuItem
    Me.mnuMailingsReminder = New System.Windows.Forms.MenuItem
    Me.mnuMailingsThankYou = New System.Windows.Forms.MenuItem
    Me.mnuMailingPreincentive = New System.Windows.Forms.MenuItem
    Me.mnuAccounting = New System.Windows.Forms.MenuItem
    Me.mnuAccountingBaselineThankyou = New System.Windows.Forms.MenuItem
    Me.mnuAccountingPreincentiveOrder = New System.Windows.Forms.MenuItem
    Me.mnuWindow = New System.Windows.Forms.MenuItem
    Me.sdaRecruitStatuses = New System.Data.SqlClient.SqlDataAdapter
    Me.sqlDeleteRecruitStatuses = New System.Data.SqlClient.SqlCommand
    Me.sqlInsertRecruitStatuses = New System.Data.SqlClient.SqlCommand
    Me.sqlUpdateRecruitStatuses = New System.Data.SqlClient.SqlCommand
    Me.sdaRecruitContacts = New System.Data.SqlClient.SqlDataAdapter
    Me.sqlDeleteRecruitContacts = New System.Data.SqlClient.SqlCommand
    Me.sqlInsertRecruitContacts = New System.Data.SqlClient.SqlCommand
    Me.sqlUpdateRecruitContacts = New System.Data.SqlClient.SqlCommand
    Me.sdaPhoneNumbers = New System.Data.SqlClient.SqlDataAdapter
    Me.sqlDeletePhoneNumbers = New System.Data.SqlClient.SqlCommand
    Me.sqlInsertPhoneNumbers = New System.Data.SqlClient.SqlCommand
    Me.sqlUpdatePhoneNumbers = New System.Data.SqlClient.SqlCommand
    Me.sdaAddresses = New System.Data.SqlClient.SqlDataAdapter
    Me.sqlDeleteAddresses = New System.Data.SqlClient.SqlCommand
    Me.sqlInsertAddresses = New System.Data.SqlClient.SqlCommand
    Me.SqlSelectAddresses = New System.Data.SqlClient.SqlCommand
    Me.sqlUpdateAddresses = New System.Data.SqlClient.SqlCommand
    Me.sdaRecruits = New System.Data.SqlClient.SqlDataAdapter
    Me.SqlUpdateCommand = New System.Data.SqlClient.SqlCommand
    Me.sqlUpdateRecruits = New System.Data.SqlClient.SqlCommand
    Me.sbMainX = New System.Windows.Forms.StatusBar
    Me.pStatus = New System.Windows.Forms.StatusBarPanel
    Me.pUser = New System.Windows.Forms.StatusBarPanel
    Me.pServer = New System.Windows.Forms.StatusBarPanel
    Me.pUserMessage = New System.Windows.Forms.StatusBarPanel
    Me.sbChanges = New System.Windows.Forms.StatusBarPanel
    Me.ToolBar1 = New System.Windows.Forms.ToolBar
    Me.tbSaveToDb = New System.Windows.Forms.ToolBarButton
    Me.tbCancelChanges = New System.Windows.Forms.ToolBarButton
    Me.tbQuery = New System.Windows.Forms.ToolBarButton
    Me.tbDetail = New System.Windows.Forms.ToolBarButton
    Me.tbBrowse = New System.Windows.Forms.ToolBarButton
    Me.MailSep1 = New System.Windows.Forms.ToolBarButton
    Me.tbGenerateMailing = New System.Windows.Forms.ToolBarButton
    Me.tbQuickLetter = New System.Windows.Forms.ToolBarButton
    Me.tbGenerateReminder = New System.Windows.Forms.ToolBarButton
    Me.MailSep2 = New System.Windows.Forms.ToolBarButton
    Me.tbRefresh = New System.Windows.Forms.ToolBarButton
    Me.tbReports = New System.Windows.Forms.ToolBarButton
    Me.ctReports = New System.Windows.Forms.ContextMenu
    Me.mnuReportsStatusOverview = New System.Windows.Forms.MenuItem
    Me.mnuReportsContactLog = New System.Windows.Forms.MenuItem
    Me.tbExtra = New System.Windows.Forms.ToolBarButton
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.tt = New System.Windows.Forms.ToolTip(Me.components)
    Me.sdaGetSubstantiveData = New System.Data.SqlClient.SqlDataAdapter
    Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
    Me.sdaUpdatedAddresses = New System.Data.SqlClient.SqlDataAdapter
    Me.sqlDeleteUpdatedAddresses = New System.Data.SqlClient.SqlCommand
    CType(Me.pStatus, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.pUser, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.pServer, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.pUserMessage, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.sbChanges, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'sdaGetLookupData
    '
    Me.sdaGetLookupData.SelectCommand = Me.SqlSelectCommand2
    Me.sdaGetLookupData.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Studies", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Study", "Study"), New System.Data.Common.DataColumnMapping("StudyName", "StudyName")}), New System.Data.Common.DataTableMapping("Table1", "Statuses", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Status", "Status"), New System.Data.Common.DataColumnMapping("Study", "Study"), New System.Data.Common.DataColumnMapping("StatusDescription", "StatusDescription"), New System.Data.Common.DataColumnMapping("TypicalSequence", "TypicalSequence"), New System.Data.Common.DataColumnMapping("DontContact", "DontContact"), New System.Data.Common.DataColumnMapping("Enrolled", "Enrolled")}), New System.Data.Common.DataTableMapping("Table2", "SamplingProgramVersions", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("RecruitProgVersion", "RecruitProgVersion"), New System.Data.Common.DataColumnMapping("Notes", "Notes")}), New System.Data.Common.DataTableMapping("Table3", "ContactTypes", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ContactType", "ContactType"), New System.Data.Common.DataColumnMapping("ContactTypeDescription", "ContactTypeDescription")}), New System.Data.Common.DataTableMapping("Table4", "PhoneNumberTypes", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Type", "Type")}), New System.Data.Common.DataTableMapping("Table5", "Tickler", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Description", "Description"), New System.Data.Common.DataColumnMapping("RequiredStatus", "RequiredStatus"), New System.Data.Common.DataColumnMapping("DaysAgo", "DaysAgo"), New System.Data.Common.DataColumnMapping("WithoutStatus", "WithoutStatus")})})
    '
    'SqlSelectCommand2
    '
    Me.SqlSelectCommand2.CommandText = "[GetLookupData]"
    Me.SqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure
    Me.SqlSelectCommand2.Connection = Me.SqlConnection1
    Me.SqlSelectCommand2.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing)})
    '
    'SqlConnection1
    '
    Me.SqlConnection1.ConnectionString = "workstation id=MLT15T;packet size=4096;integrated security=SSPI;data source=""ctrh" & _
        "s-dbserver"";persist security info=False;initial catalog=CHCR"
    Me.SqlConnection1.FireInfoMessageEventOnUserErrors = False
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuTools, Me.mnuReports, Me.mnuMailings, Me.mnuAccounting, Me.mnuWindow})
    '
    'mnuFile
    '
    Me.mnuFile.Index = 0
    Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileFetchData, Me.mnuFileSave, Me.MenuItem1, Me.mnuFileExit})
    Me.mnuFile.Text = "File"
    '
    'mnuFileFetchData
    '
    Me.mnuFileFetchData.Index = 0
    Me.mnuFileFetchData.Shortcut = System.Windows.Forms.Shortcut.CtrlQ
    Me.mnuFileFetchData.Text = "Query Data"
    '
    'mnuFileSave
    '
    Me.mnuFileSave.Index = 1
    Me.mnuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
    Me.mnuFileSave.Text = "Save to Database"
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 2
    Me.MenuItem1.Text = "-"
    '
    'mnuFileExit
    '
    Me.mnuFileExit.Index = 3
    Me.mnuFileExit.Text = "E&xit"
    '
    'mnuTools
    '
    Me.mnuTools.Index = 1
    Me.mnuTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRecruitDetail, Me.mnuFileBrowseRecruits})
    Me.mnuTools.Text = "Tools"
    '
    'mnuRecruitDetail
    '
    Me.mnuRecruitDetail.Enabled = False
    Me.mnuRecruitDetail.Index = 0
    Me.mnuRecruitDetail.Shortcut = System.Windows.Forms.Shortcut.CtrlD
    Me.mnuRecruitDetail.Text = "Recruit Detail"
    '
    'mnuFileBrowseRecruits
    '
    Me.mnuFileBrowseRecruits.Enabled = False
    Me.mnuFileBrowseRecruits.Index = 1
    Me.mnuFileBrowseRecruits.Shortcut = System.Windows.Forms.Shortcut.CtrlB
    Me.mnuFileBrowseRecruits.Text = "Browse Recruits"
    '
    'mnuReports
    '
    Me.mnuReports.Index = 2
    Me.mnuReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuMainReportsStatusOverview, Me.mnuMainReportsContactLog})
    Me.mnuReports.Text = "Reports"
    '
    'mnuMainReportsStatusOverview
    '
    Me.mnuMainReportsStatusOverview.Index = 0
    Me.mnuMainReportsStatusOverview.Text = "&Status Overview"
    '
    'mnuMainReportsContactLog
    '
    Me.mnuMainReportsContactLog.Index = 1
    Me.mnuMainReportsContactLog.Text = "&Contact Log"
    '
    'mnuMailings
    '
    Me.mnuMailings.Index = 3
    Me.mnuMailings.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuMailingsInvitationLetter, Me.mnuMailingsReminder, Me.mnuMailingsThankYou, Me.mnuMailingPreincentive})
    Me.mnuMailings.Text = "Mailings"
    '
    'mnuMailingsInvitationLetter
    '
    Me.mnuMailingsInvitationLetter.Index = 0
    Me.mnuMailingsInvitationLetter.Text = "Invitation Letter"
    '
    'mnuMailingsReminder
    '
    Me.mnuMailingsReminder.Index = 1
    Me.mnuMailingsReminder.Text = "Reminder"
    '
    'mnuMailingsThankYou
    '
    Me.mnuMailingsThankYou.Index = 2
    Me.mnuMailingsThankYou.Text = "Thank you"
    '
    'mnuMailingPreincentive
    '
    Me.mnuMailingPreincentive.Index = 3
    Me.mnuMailingPreincentive.Text = "3-Month Preincentive"
    '
    'mnuAccounting
    '
    Me.mnuAccounting.Index = 4
    Me.mnuAccounting.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAccountingBaselineThankyou, Me.mnuAccountingPreincentiveOrder})
    Me.mnuAccounting.Text = "Accounting"
    '
    'mnuAccountingBaselineThankyou
    '
    Me.mnuAccountingBaselineThankyou.Index = 0
    Me.mnuAccountingBaselineThankyou.Text = "Baseline Thank you"
    '
    'mnuAccountingPreincentiveOrder
    '
    Me.mnuAccountingPreincentiveOrder.Index = 1
    Me.mnuAccountingPreincentiveOrder.Text = "Preincentive Order"
    '
    'mnuWindow
    '
    Me.mnuWindow.Index = 5
    Me.mnuWindow.MdiList = True
    Me.mnuWindow.Text = "Window"
    '
    'sdaRecruitStatuses
    '
    Me.sdaRecruitStatuses.DeleteCommand = Me.sqlDeleteRecruitStatuses
    Me.sdaRecruitStatuses.InsertCommand = Me.sqlInsertRecruitStatuses
    Me.sdaRecruitStatuses.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "RecruitStatuses", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("RecruitID", "RecruitID"), New System.Data.Common.DataColumnMapping("StatusDate", "StatusDate"), New System.Data.Common.DataColumnMapping("Status", "Status"), New System.Data.Common.DataColumnMapping("AddedBy", "AddedBy"), New System.Data.Common.DataColumnMapping("AddedDate", "AddedDate"), New System.Data.Common.DataColumnMapping("ModifiedBy", "ModifiedBy"), New System.Data.Common.DataColumnMapping("ModifiedDate", "ModifiedDate")})})
    Me.sdaRecruitStatuses.UpdateCommand = Me.sqlUpdateRecruitStatuses
    '
    'sqlDeleteRecruitStatuses
    '
    Me.sqlDeleteRecruitStatuses.CommandText = resources.GetString("sqlDeleteRecruitStatuses.CommandText")
    Me.sqlDeleteRecruitStatuses.Connection = Me.SqlConnection1
    Me.sqlDeleteRecruitStatuses.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_RecruitID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecruitID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_StatusDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "StatusDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Status", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Status", System.Data.DataRowVersion.Original, Nothing)})
    '
    'sqlInsertRecruitStatuses
    '
    Me.sqlInsertRecruitStatuses.CommandText = resources.GetString("sqlInsertRecruitStatuses.CommandText")
    Me.sqlInsertRecruitStatuses.Connection = Me.SqlConnection1
    Me.sqlInsertRecruitStatuses.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@RecruitID", System.Data.SqlDbType.Int, 4, "RecruitID"), New System.Data.SqlClient.SqlParameter("@StatusDate", System.Data.SqlDbType.DateTime, 8, "StatusDate"), New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.Int, 4, "Status")})
    '
    'sqlUpdateRecruitStatuses
    '
    Me.sqlUpdateRecruitStatuses.CommandText = resources.GetString("sqlUpdateRecruitStatuses.CommandText")
    Me.sqlUpdateRecruitStatuses.Connection = Me.SqlConnection1
    Me.sqlUpdateRecruitStatuses.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@RecruitID", System.Data.SqlDbType.Int, 4, "RecruitID"), New System.Data.SqlClient.SqlParameter("@StatusDate", System.Data.SqlDbType.DateTime, 8, "StatusDate"), New System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.Int, 4, "Status"), New System.Data.SqlClient.SqlParameter("@AddedBy", System.Data.SqlDbType.VarChar, 10, "AddedBy"), New System.Data.SqlClient.SqlParameter("@AddedDate", System.Data.SqlDbType.DateTime, 8, "AddedDate"), New System.Data.SqlClient.SqlParameter("@ModifiedBy", System.Data.SqlDbType.VarChar, 10, "ModifiedBy"), New System.Data.SqlClient.SqlParameter("@ModifiedDate", System.Data.SqlDbType.DateTime, 8, "ModifiedDate"), New System.Data.SqlClient.SqlParameter("@Original_RecruitID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecruitID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_StatusDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "StatusDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Status", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Status", System.Data.DataRowVersion.Original, Nothing)})
    '
    'sdaRecruitContacts
    '
    Me.sdaRecruitContacts.DeleteCommand = Me.sqlDeleteRecruitContacts
    Me.sdaRecruitContacts.InsertCommand = Me.sqlInsertRecruitContacts
    Me.sdaRecruitContacts.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "RecruitContacts", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("RecruitID", "RecruitID"), New System.Data.Common.DataColumnMapping("ContactDate", "ContactDate"), New System.Data.Common.DataColumnMapping("Initiator", "Initiator"), New System.Data.Common.DataColumnMapping("Result", "Result"), New System.Data.Common.DataColumnMapping("Notes", "Notes"), New System.Data.Common.DataColumnMapping("ContactType", "ContactType"), New System.Data.Common.DataColumnMapping("AddedBy", "AddedBy"), New System.Data.Common.DataColumnMapping("AddedDate", "AddedDate"), New System.Data.Common.DataColumnMapping("ModifiedBy", "ModifiedBy"), New System.Data.Common.DataColumnMapping("ModifiedDate", "ModifiedDate")})})
    Me.sdaRecruitContacts.UpdateCommand = Me.sqlUpdateRecruitContacts
    '
    'sqlDeleteRecruitContacts
    '
    Me.sqlDeleteRecruitContacts.CommandText = resources.GetString("sqlDeleteRecruitContacts.CommandText")
    Me.sqlDeleteRecruitContacts.Connection = Me.SqlConnection1
    Me.sqlDeleteRecruitContacts.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_ContactDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_RecruitID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecruitID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ContactType", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactType", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Initiator", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Initiator", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Notes", System.Data.SqlDbType.VarChar, 500, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Notes", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Result", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Result", System.Data.DataRowVersion.Original, Nothing)})
    '
    'sqlInsertRecruitContacts
    '
    Me.sqlInsertRecruitContacts.CommandText = resources.GetString("sqlInsertRecruitContacts.CommandText")
    Me.sqlInsertRecruitContacts.Connection = Me.SqlConnection1
    Me.sqlInsertRecruitContacts.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@RecruitID", System.Data.SqlDbType.Int, 4, "RecruitID"), New System.Data.SqlClient.SqlParameter("@ContactDate", System.Data.SqlDbType.DateTime, 8, "ContactDate"), New System.Data.SqlClient.SqlParameter("@Initiator", System.Data.SqlDbType.VarChar, 20, "Initiator"), New System.Data.SqlClient.SqlParameter("@Result", System.Data.SqlDbType.VarChar, 20, "Result"), New System.Data.SqlClient.SqlParameter("@Notes", System.Data.SqlDbType.VarChar, 500, "Notes"), New System.Data.SqlClient.SqlParameter("@ContactType", System.Data.SqlDbType.Int, 4, "ContactType")})
    '
    'sqlUpdateRecruitContacts
    '
    Me.sqlUpdateRecruitContacts.CommandText = resources.GetString("sqlUpdateRecruitContacts.CommandText")
    Me.sqlUpdateRecruitContacts.Connection = Me.SqlConnection1
    Me.sqlUpdateRecruitContacts.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@RecruitID", System.Data.SqlDbType.Int, 4, "RecruitID"), New System.Data.SqlClient.SqlParameter("@ContactDate", System.Data.SqlDbType.DateTime, 8, "ContactDate"), New System.Data.SqlClient.SqlParameter("@Initiator", System.Data.SqlDbType.VarChar, 20, "Initiator"), New System.Data.SqlClient.SqlParameter("@Result", System.Data.SqlDbType.VarChar, 20, "Result"), New System.Data.SqlClient.SqlParameter("@Notes", System.Data.SqlDbType.VarChar, 500, "Notes"), New System.Data.SqlClient.SqlParameter("@ContactType", System.Data.SqlDbType.Int, 4, "ContactType"), New System.Data.SqlClient.SqlParameter("@AddedBy", System.Data.SqlDbType.VarChar, 10, "AddedBy"), New System.Data.SqlClient.SqlParameter("@AddedDate", System.Data.SqlDbType.DateTime, 8, "AddedDate"), New System.Data.SqlClient.SqlParameter("@ModifiedBy", System.Data.SqlDbType.VarChar, 10, "ModifiedBy"), New System.Data.SqlClient.SqlParameter("@ModifiedDate", System.Data.SqlDbType.DateTime, 8, "ModifiedDate"), New System.Data.SqlClient.SqlParameter("@Original_ContactDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_RecruitID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecruitID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ContactType", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactType", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Initiator", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Initiator", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Notes", System.Data.SqlDbType.VarChar, 500, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Notes", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Result", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Result", System.Data.DataRowVersion.Original, Nothing)})
    '
    'sdaPhoneNumbers
    '
    Me.sdaPhoneNumbers.DeleteCommand = Me.sqlDeletePhoneNumbers
    Me.sdaPhoneNumbers.InsertCommand = Me.sqlInsertPhoneNumbers
    Me.sdaPhoneNumbers.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "PhoneNumbers", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("RecruitID", "RecruitID"), New System.Data.Common.DataColumnMapping("AreaCode", "AreaCode"), New System.Data.Common.DataColumnMapping("PhoneNumber", "PhoneNumber"), New System.Data.Common.DataColumnMapping("Type", "Type"), New System.Data.Common.DataColumnMapping("Source", "Source"), New System.Data.Common.DataColumnMapping("Extension", "Extension"), New System.Data.Common.DataColumnMapping("AddedBy", "AddedBy"), New System.Data.Common.DataColumnMapping("AddedDate", "AddedDate"), New System.Data.Common.DataColumnMapping("ModifiedBy", "ModifiedBy"), New System.Data.Common.DataColumnMapping("ModifiedDate", "ModifiedDate")})})
    Me.sdaPhoneNumbers.UpdateCommand = Me.sqlUpdatePhoneNumbers
    '
    'sqlDeletePhoneNumbers
    '
    Me.sqlDeletePhoneNumbers.CommandText = resources.GetString("sqlDeletePhoneNumbers.CommandText")
    Me.sqlDeletePhoneNumbers.Connection = Me.SqlConnection1
    Me.sqlDeletePhoneNumbers.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_AreaCode", System.Data.SqlDbType.VarChar, 3, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AreaCode", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_PhoneNumber", System.Data.SqlDbType.VarChar, 7, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PhoneNumber", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_RecruitID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecruitID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Extension", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extension", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Source", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Source", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Type", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Type", System.Data.DataRowVersion.Original, Nothing)})
    '
    'sqlInsertPhoneNumbers
    '
    Me.sqlInsertPhoneNumbers.CommandText = resources.GetString("sqlInsertPhoneNumbers.CommandText")
    Me.sqlInsertPhoneNumbers.Connection = Me.SqlConnection1
    Me.sqlInsertPhoneNumbers.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@RecruitID", System.Data.SqlDbType.Int, 4, "RecruitID"), New System.Data.SqlClient.SqlParameter("@AreaCode", System.Data.SqlDbType.VarChar, 3, "AreaCode"), New System.Data.SqlClient.SqlParameter("@PhoneNumber", System.Data.SqlDbType.VarChar, 7, "PhoneNumber"), New System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.VarChar, 20, "Type"), New System.Data.SqlClient.SqlParameter("@Source", System.Data.SqlDbType.VarChar, 15, "Source"), New System.Data.SqlClient.SqlParameter("@Extension", System.Data.SqlDbType.VarChar, 10, "Extension")})
    '
    'sqlUpdatePhoneNumbers
    '
    Me.sqlUpdatePhoneNumbers.CommandText = resources.GetString("sqlUpdatePhoneNumbers.CommandText")
    Me.sqlUpdatePhoneNumbers.Connection = Me.SqlConnection1
    Me.sqlUpdatePhoneNumbers.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@RecruitID", System.Data.SqlDbType.Int, 4, "RecruitID"), New System.Data.SqlClient.SqlParameter("@AreaCode", System.Data.SqlDbType.VarChar, 3, "AreaCode"), New System.Data.SqlClient.SqlParameter("@PhoneNumber", System.Data.SqlDbType.VarChar, 7, "PhoneNumber"), New System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.VarChar, 20, "Type"), New System.Data.SqlClient.SqlParameter("@Source", System.Data.SqlDbType.VarChar, 15, "Source"), New System.Data.SqlClient.SqlParameter("@Extension", System.Data.SqlDbType.VarChar, 10, "Extension"), New System.Data.SqlClient.SqlParameter("@AddedBy", System.Data.SqlDbType.VarChar, 10, "AddedBy"), New System.Data.SqlClient.SqlParameter("@AddedDate", System.Data.SqlDbType.DateTime, 8, "AddedDate"), New System.Data.SqlClient.SqlParameter("@ModifiedBy", System.Data.SqlDbType.VarChar, 10, "ModifiedBy"), New System.Data.SqlClient.SqlParameter("@ModifiedDate", System.Data.SqlDbType.DateTime, 8, "ModifiedDate"), New System.Data.SqlClient.SqlParameter("@Original_AreaCode", System.Data.SqlDbType.VarChar, 3, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AreaCode", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_PhoneNumber", System.Data.SqlDbType.VarChar, 7, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PhoneNumber", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_RecruitID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecruitID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Extension", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extension", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Source", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Source", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Type", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Type", System.Data.DataRowVersion.Original, Nothing)})
    '
    'sdaAddresses
    '
    Me.sdaAddresses.DeleteCommand = Me.sqlDeleteAddresses
    Me.sdaAddresses.InsertCommand = Me.sqlInsertAddresses
    Me.sdaAddresses.SelectCommand = Me.SqlSelectAddresses
    Me.sdaAddresses.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Addresses", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("AddressID", "AddressID"), New System.Data.Common.DataColumnMapping("RecruitID", "RecruitID"), New System.Data.Common.DataColumnMapping("PreferenceRank", "PreferenceRank"), New System.Data.Common.DataColumnMapping("Line1", "Line1"), New System.Data.Common.DataColumnMapping("Line2", "Line2"), New System.Data.Common.DataColumnMapping("City", "City"), New System.Data.Common.DataColumnMapping("State", "State"), New System.Data.Common.DataColumnMapping("Zip", "Zip"), New System.Data.Common.DataColumnMapping("AddedBy", "AddedBy"), New System.Data.Common.DataColumnMapping("AddedDate", "AddedDate"), New System.Data.Common.DataColumnMapping("ModifiedBy", "ModifiedBy"), New System.Data.Common.DataColumnMapping("ModifiedDate", "ModifiedDate"), New System.Data.Common.DataColumnMapping("Country", "Country"), New System.Data.Common.DataColumnMapping("County", "County"), New System.Data.Common.DataColumnMapping("BounceDate", "BounceDate")})})
    Me.sdaAddresses.UpdateCommand = Me.sqlUpdateAddresses
    '
    'sqlDeleteAddresses
    '
    Me.sqlDeleteAddresses.CommandText = resources.GetString("sqlDeleteAddresses.CommandText")
    Me.sqlDeleteAddresses.Connection = Me.SqlConnection1
    Me.sqlDeleteAddresses.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_AddressID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddressID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_BounceDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BounceDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_County", System.Data.SqlDbType.VarChar, 3, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "County", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Line1", System.Data.SqlDbType.VarChar, 25, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Line1", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Line2", System.Data.SqlDbType.VarChar, 25, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Line2", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_ModifiedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ModifiedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_PreferenceRank", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreferenceRank", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_RecruitID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecruitID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_State", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "State", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Zip", System.Data.SqlDbType.VarChar, 9, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Zip", System.Data.DataRowVersion.Original, Nothing)})
    '
    'sqlInsertAddresses
    '
    Me.sqlInsertAddresses.CommandText = resources.GetString("sqlInsertAddresses.CommandText")
    Me.sqlInsertAddresses.Connection = Me.SqlConnection1
    Me.sqlInsertAddresses.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@RecruitID", System.Data.SqlDbType.Int, 4, "RecruitID"), New System.Data.SqlClient.SqlParameter("@PreferenceRank", System.Data.SqlDbType.Int, 4, "PreferenceRank"), New System.Data.SqlClient.SqlParameter("@Line1", System.Data.SqlDbType.VarChar, 25, "Line1"), New System.Data.SqlClient.SqlParameter("@Line2", System.Data.SqlDbType.VarChar, 25, "Line2"), New System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.VarChar, 15, "City"), New System.Data.SqlClient.SqlParameter("@State", System.Data.SqlDbType.VarChar, 2, "State"), New System.Data.SqlClient.SqlParameter("@Zip", System.Data.SqlDbType.VarChar, 9, "Zip"), New System.Data.SqlClient.SqlParameter("@Country", System.Data.SqlDbType.VarChar, 2, "Country"), New System.Data.SqlClient.SqlParameter("@County", System.Data.SqlDbType.VarChar, 3, "County"), New System.Data.SqlClient.SqlParameter("@BounceDate", System.Data.SqlDbType.DateTime, 8, "BounceDate")})
    '
    'SqlSelectAddresses
    '
    Me.SqlSelectAddresses.CommandText = "[GetAddresses]"
    Me.SqlSelectAddresses.CommandType = System.Data.CommandType.StoredProcedure
    Me.SqlSelectAddresses.Connection = Me.SqlConnection1
    Me.SqlSelectAddresses.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing), New System.Data.SqlClient.SqlParameter("@ForStudy", System.Data.SqlDbType.Int, 4)})
    '
    'sqlUpdateAddresses
    '
    Me.sqlUpdateAddresses.CommandText = resources.GetString("sqlUpdateAddresses.CommandText")
    Me.sqlUpdateAddresses.Connection = Me.SqlConnection1
    Me.sqlUpdateAddresses.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@RecruitID", System.Data.SqlDbType.Int, 4, "RecruitID"), New System.Data.SqlClient.SqlParameter("@PreferenceRank", System.Data.SqlDbType.Int, 4, "PreferenceRank"), New System.Data.SqlClient.SqlParameter("@Line1", System.Data.SqlDbType.VarChar, 40, "Line1"), New System.Data.SqlClient.SqlParameter("@Line2", System.Data.SqlDbType.VarChar, 40, "Line2"), New System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.VarChar, 15, "City"), New System.Data.SqlClient.SqlParameter("@State", System.Data.SqlDbType.VarChar, 2, "State"), New System.Data.SqlClient.SqlParameter("@Zip", System.Data.SqlDbType.VarChar, 9, "Zip"), New System.Data.SqlClient.SqlParameter("@Country", System.Data.SqlDbType.VarChar, 2, "Country"), New System.Data.SqlClient.SqlParameter("@County", System.Data.SqlDbType.VarChar, 3, "County"), New System.Data.SqlClient.SqlParameter("@BounceDate", System.Data.SqlDbType.DateTime, 8, "BounceDate"), New System.Data.SqlClient.SqlParameter("@Original_AddressID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddressID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedBy", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_BounceDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BounceDate", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_County", System.Data.SqlDbType.VarChar, 3, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "County", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Line1", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Line1", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Line2", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Line2", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_PreferenceRank", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreferenceRank", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_RecruitID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecruitID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_State", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "State", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Zip", System.Data.SqlDbType.VarChar, 9, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Zip", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@AddressID", System.Data.SqlDbType.Int, 4, "AddressID")})
    '
    'sdaRecruits
    '
    Me.sdaRecruits.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Recruits", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("RecruitID", "RecruitID"), New System.Data.Common.DataColumnMapping("AccLetter", "AccLetter"), New System.Data.Common.DataColumnMapping("AccNumber", "AccNumber"), New System.Data.Common.DataColumnMapping("Sex", "Sex"), New System.Data.Common.DataColumnMapping("Randy", "Randy"), New System.Data.Common.DataColumnMapping("BDate", "BDate"), New System.Data.Common.DataColumnMapping("LastVistDate", "LastVistDate"), New System.Data.Common.DataColumnMapping("LastName", "LastName"), New System.Data.Common.DataColumnMapping("FirstName", "FirstName"), New System.Data.Common.DataColumnMapping("MiddleName", "MiddleName"), New System.Data.Common.DataColumnMapping("NameSuffix", "NameSuffix"), New System.Data.Common.DataColumnMapping("SeqNum", "SeqNum"), New System.Data.Common.DataColumnMapping("RecruitProgVersion", "RecruitProgVersion"), New System.Data.Common.DataColumnMapping("Study", "Study"), New System.Data.Common.DataColumnMapping("AddedBy", "AddedBy"), New System.Data.Common.DataColumnMapping("AddedDate", "AddedDate"), New System.Data.Common.DataColumnMapping("ModifiedBy", "ModifiedBy"), New System.Data.Common.DataColumnMapping("ModifiedDate", "ModifiedDate")})})
    Me.sdaRecruits.UpdateCommand = Me.SqlUpdateCommand
    '
    'SqlUpdateCommand
    '
    Me.SqlUpdateCommand.CommandText = resources.GetString("SqlUpdateCommand.CommandText")
    Me.SqlUpdateCommand.Connection = Me.SqlConnection1
    Me.SqlUpdateCommand.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.VarChar, 20, "LastName"), New System.Data.SqlClient.SqlParameter("@AccLetter", System.Data.SqlDbType.VarChar, 2, "AccLetter"), New System.Data.SqlClient.SqlParameter("@AccNumber", System.Data.SqlDbType.[Char], 4, "AccNumber"), New System.Data.SqlClient.SqlParameter("@Sex", System.Data.SqlDbType.[Char], 1, "Sex"), New System.Data.SqlClient.SqlParameter("@BDate", System.Data.SqlDbType.DateTime, 8, "BDate"), New System.Data.SqlClient.SqlParameter("@LastVistDate", System.Data.SqlDbType.DateTime, 8, "LastVistDate"), New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.VarChar, 20, "FirstName"), New System.Data.SqlClient.SqlParameter("@MiddleName", System.Data.SqlDbType.VarChar, 20, "MiddleName"), New System.Data.SqlClient.SqlParameter("@NameSuffix", System.Data.SqlDbType.VarChar, 7, "NameSuffix"), New System.Data.SqlClient.SqlParameter("@EMailAddress", System.Data.SqlDbType.VarChar, 50, "EMailAddress"), New System.Data.SqlClient.SqlParameter("@RecruitProgVersion", System.Data.SqlDbType.VarChar, 6, "RecruitProgVersion"), New System.Data.SqlClient.SqlParameter("@Incentive", System.Data.SqlDbType.VarChar, 50, "Incentive"), New System.Data.SqlClient.SqlParameter("@PersonType", System.Data.SqlDbType.VarChar, 15, "PersonType"), New System.Data.SqlClient.SqlParameter("@QuitDate", System.Data.SqlDbType.DateTime, 8, "QuitDate"), New System.Data.SqlClient.SqlParameter("@Original_RecruitID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecruitID", System.Data.DataRowVersion.Original, Nothing)})
    '
    'sqlUpdateRecruits
    '
    Me.sqlUpdateRecruits.CommandText = resources.GetString("sqlUpdateRecruits.CommandText")
    Me.sqlUpdateRecruits.Connection = Me.SqlConnection1
    Me.sqlUpdateRecruits.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Sex", System.Data.SqlDbType.[Char], 1, "Sex"), New System.Data.SqlClient.SqlParameter("@Randy", System.Data.SqlDbType.Float, 8, "Randy"), New System.Data.SqlClient.SqlParameter("@BDate", System.Data.SqlDbType.DateTime, 8, "BDate"), New System.Data.SqlClient.SqlParameter("@EMailAddress", System.Data.SqlDbType.VarChar, 50, "EMailAddress"), New System.Data.SqlClient.SqlParameter("@LastVistDate", System.Data.SqlDbType.DateTime, 8, "LastVistDate"), New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.VarChar, 20, "LastName"), New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.VarChar, 20, "FirstName"), New System.Data.SqlClient.SqlParameter("@MiddleName", System.Data.SqlDbType.VarChar, 20, "MiddleName"), New System.Data.SqlClient.SqlParameter("@NameSuffix", System.Data.SqlDbType.VarChar, 7, "NameSuffix"), New System.Data.SqlClient.SqlParameter("@SeqNum", System.Data.SqlDbType.Int, 4, "SeqNum"), New System.Data.SqlClient.SqlParameter("@RecruitProgVersion", System.Data.SqlDbType.VarChar, 6, "RecruitProgVersion"), New System.Data.SqlClient.SqlParameter("@Study", System.Data.SqlDbType.Int, 4, "Study"), New System.Data.SqlClient.SqlParameter("@Incentive", System.Data.SqlDbType.VarChar, 50, "Incentive"), New System.Data.SqlClient.SqlParameter("@Original_RecruitID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecruitID", System.Data.DataRowVersion.Original, Nothing)})
    '
    'sbMainX
    '
    Me.sbMainX.Location = New System.Drawing.Point(0, 390)
    Me.sbMainX.Name = "sbMainX"
    Me.sbMainX.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.pStatus, Me.pUser, Me.pServer, Me.pUserMessage, Me.sbChanges})
    Me.sbMainX.ShowPanels = True
    Me.sbMainX.Size = New System.Drawing.Size(864, 23)
    Me.sbMainX.TabIndex = 2
    '
    'pStatus
    '
    Me.pStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
    Me.pStatus.Name = "pStatus"
    Me.pStatus.Text = "Status: "
    Me.pStatus.Width = 169
    '
    'pUser
    '
    Me.pUser.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
    Me.pUser.Name = "pUser"
    Me.pUser.Text = "User: "
    Me.pUser.Width = 169
    '
    'pServer
    '
    Me.pServer.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
    Me.pServer.Name = "pServer"
    Me.pServer.Text = "Server:"
    Me.pServer.Width = 169
    '
    'pUserMessage
    '
    Me.pUserMessage.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
    Me.pUserMessage.Name = "pUserMessage"
    Me.pUserMessage.Width = 169
    '
    'sbChanges
    '
    Me.sbChanges.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
    Me.sbChanges.Name = "sbChanges"
    Me.sbChanges.Text = "Changes: "
    Me.sbChanges.Width = 169
    '
    'ToolBar1
    '
    Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
    Me.ToolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbSaveToDb, Me.tbCancelChanges, Me.tbQuery, Me.tbDetail, Me.tbBrowse, Me.MailSep1, Me.tbGenerateMailing, Me.tbQuickLetter, Me.tbGenerateReminder, Me.MailSep2, Me.tbRefresh, Me.tbReports, Me.tbExtra})
    Me.ToolBar1.DropDownArrows = True
    Me.ToolBar1.ImageList = Me.ImageList1
    Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
    Me.ToolBar1.Name = "ToolBar1"
    Me.ToolBar1.ShowToolTips = True
    Me.ToolBar1.Size = New System.Drawing.Size(864, 29)
    Me.ToolBar1.TabIndex = 4
    Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
    '
    'tbSaveToDb
    '
    Me.tbSaveToDb.ImageIndex = 4
    Me.tbSaveToDb.Name = "tbSaveToDb"
    Me.tbSaveToDb.Text = "Save"
    Me.tbSaveToDb.ToolTipText = "Save your edits to the database"
    '
    'tbCancelChanges
    '
    Me.tbCancelChanges.ImageIndex = 2
    Me.tbCancelChanges.Name = "tbCancelChanges"
    Me.tbCancelChanges.Text = "Cancel"
    Me.tbCancelChanges.ToolTipText = "Cancel all your edits since the last time you saved to the db."
    '
    'tbQuery
    '
    Me.tbQuery.ImageIndex = 5
    Me.tbQuery.Name = "tbQuery"
    Me.tbQuery.Text = "Query"
    Me.tbQuery.ToolTipText = "Query new records from the database"
    '
    'tbDetail
    '
    Me.tbDetail.Enabled = False
    Me.tbDetail.ImageIndex = 7
    Me.tbDetail.Name = "tbDetail"
    Me.tbDetail.Text = "Detail"
    Me.tbDetail.ToolTipText = "View Details one Recruit at a time"
    '
    'tbBrowse
    '
    Me.tbBrowse.Enabled = False
    Me.tbBrowse.ImageIndex = 6
    Me.tbBrowse.Name = "tbBrowse"
    Me.tbBrowse.Text = "Browse"
    Me.tbBrowse.ToolTipText = "View all Recruits in a sortable list."
    '
    'MailSep1
    '
    Me.MailSep1.Name = "MailSep1"
    Me.MailSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    Me.MailSep1.Text = "-"
    '
    'tbGenerateMailing
    '
    Me.tbGenerateMailing.Enabled = False
    Me.tbGenerateMailing.ImageIndex = 8
    Me.tbGenerateMailing.Name = "tbGenerateMailing"
    Me.tbGenerateMailing.Text = "Letters"
    '
    'tbQuickLetter
    '
    Me.tbQuickLetter.Enabled = False
    Me.tbQuickLetter.ImageIndex = 9
    Me.tbQuickLetter.Name = "tbQuickLetter"
    Me.tbQuickLetter.Text = "Quick Letter"
    Me.tbQuickLetter.ToolTipText = "Generate a letter just for the currently selected person"
    '
    'tbGenerateReminder
    '
    Me.tbGenerateReminder.Enabled = False
    Me.tbGenerateReminder.ImageIndex = 10
    Me.tbGenerateReminder.Name = "tbGenerateReminder"
    Me.tbGenerateReminder.Text = "Reminders"
    Me.tbGenerateReminder.ToolTipText = "Generate a Reminder mailing for the currently queried set of people."
    '
    'MailSep2
    '
    Me.MailSep2.Name = "MailSep2"
    Me.MailSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    '
    'tbRefresh
    '
    Me.tbRefresh.Enabled = False
    Me.tbRefresh.ImageIndex = 3
    Me.tbRefresh.Name = "tbRefresh"
    Me.tbRefresh.Text = "Refresh"
    Me.tbRefresh.ToolTipText = "Re-query the current record out of the db."
    '
    'tbReports
    '
    Me.tbReports.DropDownMenu = Me.ctReports
    Me.tbReports.Name = "tbReports"
    Me.tbReports.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
    Me.tbReports.Text = "Reports"
    Me.tbReports.ToolTipText = "View Reports"
    '
    'ctReports
    '
    Me.ctReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuReportsStatusOverview, Me.mnuReportsContactLog})
    '
    'mnuReportsStatusOverview
    '
    Me.mnuReportsStatusOverview.Index = 0
    Me.mnuReportsStatusOverview.Text = "&Status Overview"
    '
    'mnuReportsContactLog
    '
    Me.mnuReportsContactLog.Index = 1
    Me.mnuReportsContactLog.Text = "&Contact Log"
    '
    'tbExtra
    '
    Me.tbExtra.Name = "tbExtra"
    Me.tbExtra.Visible = False
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "")
    Me.ImageList1.Images.SetKeyName(2, "")
    Me.ImageList1.Images.SetKeyName(3, "")
    Me.ImageList1.Images.SetKeyName(4, "")
    Me.ImageList1.Images.SetKeyName(5, "")
    Me.ImageList1.Images.SetKeyName(6, "")
    Me.ImageList1.Images.SetKeyName(7, "")
    Me.ImageList1.Images.SetKeyName(8, "")
    Me.ImageList1.Images.SetKeyName(9, "")
    Me.ImageList1.Images.SetKeyName(10, "")
    '
    'sdaGetSubstantiveData
    '
    Me.sdaGetSubstantiveData.SelectCommand = Me.SqlSelectCommand1
    Me.sdaGetSubstantiveData.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Recruits", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("RecruitID", "RecruitID"), New System.Data.Common.DataColumnMapping("AccLetter", "AccLetter"), New System.Data.Common.DataColumnMapping("AccNumber", "AccNumber"), New System.Data.Common.DataColumnMapping("AccCode", "AccCode"), New System.Data.Common.DataColumnMapping("Sex", "Sex"), New System.Data.Common.DataColumnMapping("Randy", "Randy"), New System.Data.Common.DataColumnMapping("BDate", "BDate"), New System.Data.Common.DataColumnMapping("EMailAddress", "EMailAddress"), New System.Data.Common.DataColumnMapping("LastVistDate", "LastVistDate"), New System.Data.Common.DataColumnMapping("LastName", "LastName"), New System.Data.Common.DataColumnMapping("FirstName", "FirstName"), New System.Data.Common.DataColumnMapping("MiddleName", "MiddleName"), New System.Data.Common.DataColumnMapping("NameSuffix", "NameSuffix"), New System.Data.Common.DataColumnMapping("SeqNum", "SeqNum"), New System.Data.Common.DataColumnMapping("RecruitProgVersion", "RecruitProgVersion"), New System.Data.Common.DataColumnMapping("Study", "Study"), New System.Data.Common.DataColumnMapping("AddedBy", "AddedBy"), New System.Data.Common.DataColumnMapping("AddedDate", "AddedDate"), New System.Data.Common.DataColumnMapping("ModifiedBy", "ModifiedBy"), New System.Data.Common.DataColumnMapping("ModifiedDate", "ModifiedDate"), New System.Data.Common.DataColumnMapping("StatusDate", "StatusDate"), New System.Data.Common.DataColumnMapping("StatusDescription", "StatusDescription"), New System.Data.Common.DataColumnMapping("PersonType", "PersonType")}), New System.Data.Common.DataTableMapping("Table1", "Addresses", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("AddressID", "AddressID"), New System.Data.Common.DataColumnMapping("RecruitID", "RecruitID"), New System.Data.Common.DataColumnMapping("PreferenceRank", "PreferenceRank"), New System.Data.Common.DataColumnMapping("Line1", "Line1"), New System.Data.Common.DataColumnMapping("Line2", "Line2"), New System.Data.Common.DataColumnMapping("City", "City"), New System.Data.Common.DataColumnMapping("State", "State"), New System.Data.Common.DataColumnMapping("Zip", "Zip"), New System.Data.Common.DataColumnMapping("Country", "Country"), New System.Data.Common.DataColumnMapping("County", "County"), New System.Data.Common.DataColumnMapping("BounceDate", "BounceDate"), New System.Data.Common.DataColumnMapping("AddedBy", "AddedBy"), New System.Data.Common.DataColumnMapping("AddedDate", "AddedDate"), New System.Data.Common.DataColumnMapping("ModifiedBy", "ModifiedBy"), New System.Data.Common.DataColumnMapping("ModifiedDate", "ModifiedDate")}), New System.Data.Common.DataTableMapping("Table2", "PhoneNumbers", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("RecruitID", "RecruitID"), New System.Data.Common.DataColumnMapping("Type", "Type"), New System.Data.Common.DataColumnMapping("AreaCode", "AreaCode"), New System.Data.Common.DataColumnMapping("PhoneNumber", "PhoneNumber"), New System.Data.Common.DataColumnMapping("Extension", "Extension"), New System.Data.Common.DataColumnMapping("Source", "Source"), New System.Data.Common.DataColumnMapping("AddedBy", "AddedBy"), New System.Data.Common.DataColumnMapping("AddedDate", "AddedDate"), New System.Data.Common.DataColumnMapping("ModifiedBy", "ModifiedBy"), New System.Data.Common.DataColumnMapping("ModifiedDate", "ModifiedDate")}), New System.Data.Common.DataTableMapping("Table3", "RecruitContacts", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("RecruitID", "RecruitID"), New System.Data.Common.DataColumnMapping("ContactDate", "ContactDate"), New System.Data.Common.DataColumnMapping("Initiator", "Initiator"), New System.Data.Common.DataColumnMapping("Result", "Result"), New System.Data.Common.DataColumnMapping("Notes", "Notes"), New System.Data.Common.DataColumnMapping("ContactType", "ContactType"), New System.Data.Common.DataColumnMapping("AddedBy", "AddedBy"), New System.Data.Common.DataColumnMapping("AddedDate", "AddedDate"), New System.Data.Common.DataColumnMapping("ModifiedBy", "ModifiedBy"), New System.Data.Common.DataColumnMapping("ModifiedDate", "ModifiedDate")}), New System.Data.Common.DataTableMapping("Table4", "RecruitStatuses", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("RecruitID", "RecruitID"), New System.Data.Common.DataColumnMapping("StatusDate", "StatusDate"), New System.Data.Common.DataColumnMapping("Status", "Status"), New System.Data.Common.DataColumnMapping("AddedBy", "AddedBy"), New System.Data.Common.DataColumnMapping("AddedDate", "AddedDate"), New System.Data.Common.DataColumnMapping("ModifiedBy", "ModifiedBy"), New System.Data.Common.DataColumnMapping("ModifiedDate", "ModifiedDate")}), New System.Data.Common.DataTableMapping("Table5", "UpdatedAddresses", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("AddressID", "AddressID"), New System.Data.Common.DataColumnMapping("RecruitID", "RecruitID"), New System.Data.Common.DataColumnMapping("PreferenceRank", "PreferenceRank"), New System.Data.Common.DataColumnMapping("Line1", "Line1"), New System.Data.Common.DataColumnMapping("Line2", "Line2"), New System.Data.Common.DataColumnMapping("City", "City"), New System.Data.Common.DataColumnMapping("State", "State"), New System.Data.Common.DataColumnMapping("Zip", "Zip"), New System.Data.Common.DataColumnMapping("Country", "Country"), New System.Data.Common.DataColumnMapping("County", "County"), New System.Data.Common.DataColumnMapping("BounceDate", "BounceDate"), New System.Data.Common.DataColumnMapping("AddedBy", "AddedBy"), New System.Data.Common.DataColumnMapping("AddedDate", "AddedDate"), New System.Data.Common.DataColumnMapping("ModifiedBy", "ModifiedBy"), New System.Data.Common.DataColumnMapping("ModifiedDate", "ModifiedDate")})})
    '
    'SqlSelectCommand1
    '
    Me.SqlSelectCommand1.CommandText = "[GetSubstantiveData]"
    Me.SqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure
    Me.SqlSelectCommand1.Connection = Me.SqlConnection1
    Me.SqlSelectCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing), New System.Data.SqlClient.SqlParameter("@RecruitIDIs", System.Data.SqlDbType.Int, 4), New System.Data.SqlClient.SqlParameter("@ForStudy", System.Data.SqlDbType.Int, 4), New System.Data.SqlClient.SqlParameter("@FirstNameLike", System.Data.SqlDbType.VarChar, 20), New System.Data.SqlClient.SqlParameter("@LastNameLike", System.Data.SqlDbType.VarChar, 20), New System.Data.SqlClient.SqlParameter("@CurrentStatusIs", System.Data.SqlDbType.Int, 4), New System.Data.SqlClient.SqlParameter("@StatusEverWas", System.Data.SqlDbType.Int, 4), New System.Data.SqlClient.SqlParameter("@SexIs", System.Data.SqlDbType.VarChar, 1), New System.Data.SqlClient.SqlParameter("@AccLetterIs", System.Data.SqlDbType.VarChar, 2), New System.Data.SqlClient.SqlParameter("@AccNumberIs", System.Data.SqlDbType.VarChar, 4), New System.Data.SqlClient.SqlParameter("@RecruitProgVersionIs", System.Data.SqlDbType.VarChar, 6), New System.Data.SqlClient.SqlParameter("@BDateIs", System.Data.SqlDbType.DateTime, 8), New System.Data.SqlClient.SqlParameter("@MaxRecs", System.Data.SqlDbType.Int, 4), New System.Data.SqlClient.SqlParameter("@ContactDateTime", System.Data.SqlDbType.DateTime, 8), New System.Data.SqlClient.SqlParameter("@UseAccCodeList", System.Data.SqlDbType.Bit, 1), New System.Data.SqlClient.SqlParameter("@UseNameList", System.Data.SqlDbType.Bit, 1), New System.Data.SqlClient.SqlParameter("@GetReminderEligible", System.Data.SqlDbType.Bit, 1), New System.Data.SqlClient.SqlParameter("@GetUpdatedAddresses", System.Data.SqlDbType.Bit, 1), New System.Data.SqlClient.SqlParameter("@HavingTicklerStatus", System.Data.SqlDbType.VarChar, 200), New System.Data.SqlClient.SqlParameter("@NumStarbucks", System.Data.SqlDbType.Int), New System.Data.SqlClient.SqlParameter("@NumKroger", System.Data.SqlDbType.Int), New System.Data.SqlClient.SqlParameter("@NumTarget", System.Data.SqlDbType.Int), New System.Data.SqlClient.SqlParameter("@NumIGP", System.Data.SqlDbType.Int), New System.Data.SqlClient.SqlParameter("@NumNetwork", System.Data.SqlDbType.Int), New System.Data.SqlClient.SqlParameter("@NumNetSmok", System.Data.SqlDbType.Int)})
    '
    'sdaUpdatedAddresses
    '
    Me.sdaUpdatedAddresses.DeleteCommand = Me.sqlDeleteUpdatedAddresses
    Me.sdaUpdatedAddresses.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "UpdatedAddresses", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("AddressID", "AddressID"), New System.Data.Common.DataColumnMapping("RecruitID", "RecruitID"), New System.Data.Common.DataColumnMapping("PreferenceRank", "PreferenceRank"), New System.Data.Common.DataColumnMapping("Line1", "Line1"), New System.Data.Common.DataColumnMapping("Line2", "Line2"), New System.Data.Common.DataColumnMapping("City", "City"), New System.Data.Common.DataColumnMapping("State", "State"), New System.Data.Common.DataColumnMapping("Zip", "Zip")})})
    '
    'sqlDeleteUpdatedAddresses
    '
    Me.sqlDeleteUpdatedAddresses.CommandText = resources.GetString("sqlDeleteUpdatedAddresses.CommandText")
    Me.sqlDeleteUpdatedAddresses.Connection = Me.SqlConnection1
    Me.sqlDeleteUpdatedAddresses.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_AddressID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddressID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Line1", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Line1", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Line2", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Line2", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_PreferenceRank", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PreferenceRank", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_RecruitID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecruitID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_State", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "State", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_Zip", System.Data.SqlDbType.VarChar, 9, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Zip", System.Data.DataRowVersion.Original, Nothing)})
    '
    'frmTracker
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(864, 413)
    Me.Controls.Add(Me.ToolBar1)
    Me.Controls.Add(Me.sbMainX)
    Me.IsMdiContainer = True
    Me.KeyPreview = True
    Me.Menu = Me.MainMenu1
    Me.Name = "frmTracker"
    Me.Text = "OncoNurse Subject Tracking Database"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.pStatus, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.pUser, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.pServer, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.pUserMessage, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.sbChanges, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FileExit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
    Me.Close()
  End Sub

  Private Sub GenerateLetters(ByVal CurrentRecruitOnly As Boolean, Optional ByVal MailingType As MailingType = MailingType.macPQLetter)
    Dim booAccReturns As Boolean

    Me.pStatus.Text = "Calling report"
    If CurrentRecruitOnly Then
      booAccReturns = LaunchMSAccess(MailingType.ToString & "NoSelf")
    Else
      booAccReturns = LaunchMSAccess(MailingType.ToString)
    End If
    If booAccReturns Then
      If vbYes = MessageBox.Show("Add records to the db indicating these " _
               & "letters went out?" _
               , "Record these contacts?" _
               , MessageBoxButtons.YesNo _
               , MessageBoxIcon.Question _
               , MessageBoxDefaultButton.Button1) Then
        Call RecordContacts(MailingType)
      End If
    End If

  End Sub

  Private Sub mnuFileGenerateLetters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMailingsInvitationLetter.Click
    Dim f As New frmLetters
    If f.ShowDialog(Me) = wf.DialogResult.OK Then
      Select Case TrackerApp.Settings.Study
        Case 1, 4 ' Project quit
          GenerateLetters(CurrentRecruitOnly:=False, MailingType:=MailingType.macPQLetter)
        Case 3, 5 ' Guide To Decide
          GenerateLetters(CurrentRecruitOnly:=False, MailingType:=MailingType.macGTDLetter)
        Case Else
          Throw New ArgumentException("TrackerApp.Settings.Study set to unexpected value--it's freaking me out!")
      End Select
    End If
  End Sub

  Private Sub GenerateRemdinder()
    Dim f As New frmLetters
    If f.ShowDialog(Me) = wf.DialogResult.OK Then
      Select Case TrackerApp.Settings.Study
        Case 1, 4 ' Project Quit
          GenerateLetters(False, MailingType.macPQReminder)
        Case 3, 5 ' Guide To Decide
          GenerateLetters(False, MailingType.macGTDReminder)
      End Select
    End If
  End Sub

  Private Sub BrowseRecruits(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFileBrowseRecruits.Click
    ' Throw New Exception("Pretend error message")
    ' Me.SqlDataAdapter1.Fill(Me.Chcr1.Recruits)
    Dim f As New frmRecruitBrowser
    With f
      .MdiParent = Me
      .Show()
      .BindGrid(TrackerApp.Tracker1)
    End With
  End Sub

  Private Sub frmTracker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Me.Text = My.Settings.StudyName & " Subject Tracker"

    ' TODO: Fetch the full name on a worker thread!
    With Me.pUser
      .Text = "Welcome " & GetFullName(System.Environment.UserName)
      .AutoSize = StatusBarPanelAutoSize.Contents
    End With

    With Me.pServer
      .Text = "Server: " & Me.SqlConnection1.DataSource
    End With

    Call PopulateTabArray()

    Me.pStatus.Text = "Fetching the lookup data..."
    If TestDBConnect() Then
      ' ar = delLookup.BeginInvoke(New AsyncCallback(AddressOf LookupCallback), Nothing)
      delLookup.Invoke()
      LookupDataAreHere()
    Else
      Me.pStatus.Text = "Not connected."
    End If

  End Sub

  Public Sub PopulateTabArray()
    Dim t As Tab

    t = New Tab
    With t
      .sda = Me.sdaPhoneNumbers
      .t = TrackerApp.Tracker1.PhoneNumbers
      .Order = 4
    End With
    Adapters.Add(t)

    t = New Tab
    With t
      .sda = Me.sdaAddresses
      .t = TrackerApp.Tracker1.Addresses
      .Order = 5
    End With
    Adapters.Add(t)

    t = New Tab
    With t
      .sda = Me.sdaRecruitContacts
      .t = TrackerApp.Tracker1.RecruitContacts
      .Order = 6
    End With
    Adapters.Add(t)

    t = New Tab
    With t
      .sda = Me.sdaRecruitStatuses
      .t = TrackerApp.Tracker1.RecruitStatuses
      .Order = 7
    End With
    Adapters.Add(t)

    t = New Tab
    With t
      .sda = Me.sdaUpdatedAddresses
      .t = TrackerApp.Tracker1.UpdatedAddresses
      .Order = 8
    End With
    Adapters.Add(t)

    t = New Tab
    With t
      .sda = Me.sdaRecruits
      .t = TrackerApp.Tracker1.Recruits
      .Order = 9
    End With
    Adapters.Add(t)
    Adapters.Sort()
  End Sub

  Private Function TestDBConnect() As Boolean
    Try
      ' Me.pStatus.Text = "Attempting to connect to the db..."
      With Me.SqlConnection1
        .Open()
        .Close()
      End With
      Return True
    Catch sex As SqlClient.SqlException
      MessageBox.Show("Problem--could not connect to the SQL Server" & se.NewLine & se.NewLine _
      & "The error is """ & sex.Message & """")
      Return False
    Catch e As Exception
      MessageBox.Show("Problem connecting to the SQL Server: """ & e.Message & """")
    End Try
  End Function

  Public Sub LookupCallback(ByVal ar1 As IAsyncResult)
    Me.Invoke(New MethodInvoker(AddressOf LookupDataAreHere))
  End Sub

  Public Sub LookupDataAreHere()
    ' Me.pUserMessage.Text = "Retrieved " & delLookup.EndInvoke(ar).ToString & " rows for lookup tables"
    Me.pStatus.Text = "Ready"
    Call mnuFileFetchData_Click(Nothing, Nothing)
  End Sub

  Private Function FillLookupTables() As Integer
    Dim intReturn As Integer
    With TrackerApp.Tracker1
      .Clear()
      ' .EnforceConstraints = False
    End With
    ' tabStudies.sda.Fill(tabStudies.t)
    Try
      intReturn = Me.sdaGetLookupData.Fill(TrackerApp.Tracker1)
      With TrackerApp.Tracker1
        intReturn = .ContactTypes.Count
        intReturn += .Studies.Count
        intReturn += .SamplingProgramVersions.Count
        intReturn += .PhoneNumberTypes.Count
        intReturn += .Statuses.Count
        TrackerApp.ContactTypes = CType(.ContactTypes.Copy, TrackerData.ContactTypesDataTable)
        TrackerApp.Statuses = CType(.Statuses.Copy, TrackerData.StatusesDataTable)
        TrackerApp.PhoneNumberTypes = CType(.PhoneNumberTypes.Copy, TrackerData.PhoneNumberTypesDataTable)
      End With
    Catch ex As System.Data.ConstraintException
      ListErrors()
      MessageBox.Show(ex.ToString)
    End Try

    Return intReturn
  End Function

  Private Sub DataIsChanging(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    ' Beep()
    If Not sender Is Nothing Then
      Debug.WriteLine("Data change event from " & sender.ToString & vbTab & e.Action.ToString)
    End If
    Select Case e.Action
      Case DataRowAction.Add
        NumAdds += 1
      Case DataRowAction.Change
        NumUpdates += 1
      Case DataRowAction.Delete
        NumDeletes += 1
    End Select
    With Me.sbChanges
      .Text = "Changes: " & (NumAdds + NumUpdates + NumDeletes).ToString
      .ToolTipText = NumAdds.ToString & " adds, " & NumUpdates.ToString & " updates, and " & NumDeletes.ToString & " deletes."
    End With
  End Sub

  Private Sub ListErrors()
    Dim t As DataTable
    Dim r As DataRow
    Dim c As DataColumn

    With TrackerApp.Tracker1
      For Each t In .Tables
        Debug.WriteLine("Table: " & t.TableName & vbTab & "Has errors:" & t.HasErrors.ToString)
        If t.HasErrors Then
          For Each r In t.Rows
            If r.HasErrors Then
              Debug.WriteLine("Row error is: " & r.RowError)
              For Each c In r.GetColumnsInError()
                Debug.WriteLine("Column " & c.ColumnName & " error:" & r.GetColumnError(c))
              Next
            End If
          Next
        End If
      Next
    End With
  End Sub

  Public Function EndAllEdits() As Boolean
    For Each f As Form In Me.MdiChildren
      If TypeOf f Is DataboundForm Then
        If Not CType(f, DataboundForm).EndPendingEdits Then
          ' One of the forms was not able to end its pending
          ' edits--bail.  The form should have shown the user
          ' an intelligible error msg in its EndPendingEdits method.
          Return False
        End If
      End If
    Next
    Return True
  End Function

  Public Sub CommitChanges()
    If Not EndAllEdits() Then
      Return
    End If
    If TrackerApp.Tracker1.HasErrors Then
      MessageBox.Show("No can do--there's an error in a field somewhere--look around for the little red exclamation point & fix that, then try to save.", "Can't save right now", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If
    If TrackerApp.Tracker1.HasChanges Then
      Me.pStatus.Text = "Sending changes to the database..."
      Dim a As Tab = Nothing
      Try
        RemoveDataChangeHandlers()
        TrackerApp.Tracker1.EnforceConstraints = False
        Me.SqlConnection1.Open()
        For Each a In Adapters
          Me.pUserMessage.Text = "Updating " & a.t.TableName
          Console.WriteLine("Updating " & a.t.TableName)
          Select Case a.t.TableName
            Case "Addresses"
              ' Do the deletes first.
              a.sda.Update(a.t.Select(Nothing, Nothing, DataViewRowState.Deleted))
            Case Else
              ' do nothing
          End Select
          a.sda.Update(a.t)
        Next
        AddDataChangeHandlers()
      Catch sex As System.Data.SqlClient.SqlException
        Dim msg As String
        msg = "SQL Server ran into problems while saving to table " & a.t.TableName & se.NewLine & se.NewLine
        For Each e As sd.SqlClient.SqlError In sex.Errors
          msg &= "Error#" & e.Number.ToString & ": " & e.Message & se.NewLine
        Next
        MessageBox.Show(msg)
      Finally
        Me.SqlConnection1.Close()
      End Try
      Try
        TrackerApp.Tracker1.EnforceConstraints = True
        Me.pUserMessage.Text = "Save successful."
        MessageBox.Show("Save successful")
      Catch ex As System.Data.ConstraintException
        Dim msg As String
        msg = "Problem re-enabling client-side constraints: " & se.NewLine & se.NewLine _
           & ex.Message
        MessageBox.Show(msg)
        Me.pUserMessage.Text = "Changes committed (constraints disabled)."
      End Try
    Else
      Me.pUserMessage.Text = "No changes to save."
      MessageBox.Show("No changes to save!")
    End If
  End Sub

  Private Sub mnuRecruitDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRecruitDetail.Click
    Dim f As New frmRecruitDetail(TrackerApp.Tracker1)
    With f
      .MdiParent = Me
      .Show()
    End With
  End Sub

  Private Function GetFullName(ByVal ForUser As String) As String
    Dim ui As New UserInfo.user
    Try
      Return ui.GetFullName(ForUser)

    Catch ex As Exception
      Return ForUser
    End Try

    ' TODO: Once this is done on a bkgrnd thread we can stop short-circuiting it
    ' Return ForUser
    'Try
    '   Dim usr As New System.DirectoryServices.DirectoryEntry("LDAP://CN=" & ForUser _
    '                                    & ", OU=Prod" _
    '                                    & ", OU=GHCUsers" _
    '                                    & ", dc=ghcmaster" _
    '                                    & ", dc=ghc" _
    '                                    & ", dc=org")
    '   Return usr.Properties("GivenName")(0).ToString & " " & usr.Properties("sn")(0).ToString
    'Catch e As Exception
    '   Return ForUser
    'End Try
  End Function

  Private Sub mnuFileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileSave.Click
    Me.CommitChanges()
  End Sub

  Private Sub ChangeServer()
    CloseDataForms()
    With Me.SqlConnection1
      If .State <> ConnectionState.Closed Then .Close()
      .ConnectionString = TrackerApp.Settings.ConnectStringFromServerEnum
      If TestDBConnect() Then
        TrackerApp.Tracker1.Clear()

        Me.mnuRecruitDetail.Enabled = False
        Me.mnuFileBrowseRecruits.Enabled = False
        Me.mnuMailings.Enabled = False

        FillLookupTables()
        TrackerApp.Settings.Save()
        Me.pServer.Text = "Server:" & .DataSource
        Me.pStatus.Text = "Ready"
        mnuFileFetchData_Click(Nothing, Nothing)
      End If
    End With
  End Sub

  Private Sub sbMainX_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles sbMainX.PanelClick
    If e.StatusBarPanel Is Me.pServer Then
      If se.UserName = "pardre1" AndAlso MessageBox.Show("Switch servers?", "Switch servers?", MessageBoxButtons.YesNo) = wf.DialogResult.Yes Then
        Select Case TrackerApp.Settings.Server
          Case SQLServers.Development, SQLServers.DevNet
            TrackerApp.Settings.Server = SQLServers.Production
            ChangeServer()
          Case SQLServers.Production, SQLServers.DevNet
            TrackerApp.Settings.Server = SQLServers.Development
            ChangeServer()
          Case Else
            Throw New Exception("Can't switch from undefined server """ & TrackerApp.Settings.Server.ToString & """")
        End Select
      End If
    End If
  End Sub

  Private Sub CloseDataForms()
    Dim f As Form
    For Each f In Me.MdiChildren
      If TypeOf f Is DataboundForm Then
        f.Close()
        f.Dispose()
        f = Nothing
      End If
    Next
  End Sub

  Public Property StudyName() As String
    Get
      Return _StudyName
    End Get
    Set(ByVal Value As String)
      _StudyName = Value
      Me.Text = "CHCR Subject Tracking Database (" & _StudyName & ")"
      pStatus.Text = "Study: " & _StudyName
      Select Case Value
        Case "Project Quit"
          Me.mnuMailingsThankYou.Visible = False
          Me.mnuMailingsReminder.Visible = True
          Me.mnuAccounting.Visible = False
        Case "Guide To Decide"
          Me.mnuMailingsThankYou.Visible = True
          Me.mnuMailingsReminder.Visible = True
          Me.mnuAccounting.Visible = True
      End Select

    End Set
  End Property

  Private Sub mnuFileFetchData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileFetchData.Click

    Dim f As New frmQueryData
    With f
      .SexIs = TrackerApp.Settings.SexIs
      .FirstNameLike = TrackerApp.Settings.FirstNameLike
      .LastNameLike = TrackerApp.Settings.LastNameLike
      .Status = TrackerApp.Settings.Status
      .StatusType = TrackerApp.Settings.StatusType
      .BirthDate = TrackerApp.Settings.BirthDate
      .AccNumberIs = TrackerApp.Settings.AccNumber
      .AccLetterIs = TrackerApp.Settings.AccLetter
      .SetAccCode()
      .ProgVersionIs = TrackerApp.Settings.ProgVersion
      .MaxRecs = TrackerApp.Settings.MaxRecs
      .UseQueriedNameList = TrackerApp.Settings.UseQueriedNameList
      .UseQueriedAccessCodeList = TrackerApp.Settings.UseQueriedAccessCodeList
      .TicklerToBeDone = TrackerApp.Settings.TicklerToBeDone
      If .ShowDialog(Me) = wf.DialogResult.OK Then
        CloseDataForms()
        TrackerApp.Settings.MaxRecs = .MaxRecs.ToString
        TrackerApp.Settings.SexIs = .SexIs.ToString
        TrackerApp.Settings.ProgVersion = .ProgVersionIs.ToString
        TrackerApp.Settings.FirstNameLike = .FirstNameLike.ToString
        TrackerApp.Settings.LastNameLike = .LastNameLike.ToString
        TrackerApp.Settings.Status = .Status.ToString
        TrackerApp.Settings.StatusType = .StatusType.ToString
        TrackerApp.Settings.BirthDate = .BirthDate.ToString
        TrackerApp.Settings.AccNumber = .AccNumberIs.ToString
        TrackerApp.Settings.AccLetter = .AccLetterIs.ToString
        TrackerApp.Settings.ContactDate = .ContactDate.ToString
        TrackerApp.Settings.UseQueriedNameList = .UseQueriedNameList
        TrackerApp.Settings.UseQueriedAccessCodeList = .UseQueriedAccessCodeList
        TrackerApp.Settings.TicklerToBeDone = .TicklerToBeDone.ToString
        TrackerApp.Settings.Save()

        With Me.sdaGetSubstantiveData.SelectCommand
          .Parameters("@FirstNameLike").Value = f.FirstNameLike
          .Parameters("@LastNameLike").Value = f.LastNameLike
          .Parameters("@SexIs").Value = f.SexIs
          .Parameters("@RecruitProgVersionIs").Value = f.ProgVersionIs
          Select Case f.StatusType.ToString
            Case StatusTypes.Currently.ToString
              .Parameters("@CurrentStatusIs").Value = f.Status
              .Parameters("@StatusEverWas").Value = DBNull.Value
            Case StatusTypes.Ever.ToString
              .Parameters("@CurrentStatusIs").Value = DBNull.Value
              .Parameters("@StatusEverWas").Value = f.Status
            Case Else
              .Parameters("@CurrentStatusIs").Value = DBNull.Value
              .Parameters("@StatusEverWas").Value = DBNull.Value
          End Select
          .Parameters("@AccLetterIs").Value = f.AccLetterIs
          .Parameters("@AccNumberIs").Value = f.AccNumberIs
          .Parameters("@BDateIs").Value = f.BirthDate
          .Parameters("@MaxRecs").Value = f.MaxRecs
          .Parameters("@ContactDateTime").Value = f.ContactDate
          .Parameters("@UseAccCodeList").Value = f.UseQueriedAccessCodeList
          .Parameters("@UseNameList").Value = f.UseQueriedNameList
          .Parameters("@HavingTicklerStatus").Value = f.TicklerToBeDone

          If f.chkLimitPersonTypes.Checked Then
            '.Parameters("@NumKroger").Value = f.NumKroger
            '.Parameters("@NumTarget").Value = f.NumTarget
            '.Parameters("@NumStarbucks").Value = f.NumStarbucks
            .Parameters("@NumIGP").Value = f.NumIGP
            .Parameters("@NumNetwork").Value = f.NumNetwork
            .Parameters("@NumNetSmok").Value = f.NumNetSmok
          End If

          ' Special-casing the reminder letter mailing so that users can't gen letters
          ' for the plain Networkers.
          If f.TicklerToBeDone.ToString = "Reminder Letter Sent" Then
            .Parameters("@NumNetwork").Value = 0
            ' .Parameters("@NumNetSmok").Value = 0
            If f.NumIGP = 0 Then
              ' Set this to some crazy high value so we're sure to get everyone.
              If f.MaxRecs Is DBNull.Value Then
                .Parameters("@NumIGP").Value = 99999
              Else
                .Parameters("@NumIGP").Value = f.MaxRecs
              End If
            End If

          End If

          ' Me.tbGenerateReminder.Enabled = f.GetReminderEligibles
          ' MessageBox.Show("ContactDateTime is " & CType(.Parameters("@ContactDateTime").Value, DateTime).ToString)
        End With
        Try
          TrackerApp.Tracker1.EnforceConstraints = False
          Me.pUserMessage.Text = "Retrieving data--please be patient"
          Me.Cursor = Cursors.WaitCursor
          Me.CloseDataForms()
          ' ar = delSubstantive.BeginInvoke(New AsyncCallback(AddressOf CallFormBack), Nothing)
          Me.pUserMessage.Text = "Retrieved " & GetSubstantiveData.ToString & " rows."
          DataAreHere()
        Catch ex As Exception
          MessageBox.Show(ex.ToString)
          Call ListErrors()
        Finally
          Me.Cursor = Cursors.Default
        End Try
      End If
    End With
    f.Dispose()
  End Sub

  Private Function GetSubstantiveData() As Integer
    RemoveDataChangeHandlers()
    With TrackerApp.Tracker1
      ' .Statuses.Clear()
      .RecruitContacts.Clear()
      .RecruitStatuses.Clear()
      .Addresses.Clear()
      .PhoneNumbers.Clear()
      .Recruits.Clear()
      .UpdatedAddresses.Clear()
    End With
    Return Me.sdaGetSubstantiveData.Fill(TrackerApp.Tracker1)
  End Function

  Public Sub DataAreHere()
    ' Me.pUserMessage.Text = "Retrieved " & delSubstantive.EndInvoke(ar).ToString & " rows."
    AddDataChangeHandlers()
    Try
      TrackerApp.Tracker1.EnforceConstraints = True
    Catch ex As System.Data.ConstraintException
      ListErrors()
    End Try

    If TrackerApp.Tracker1.Recruits.Count > 0 Then
      Me.mnuFileBrowseRecruits.Enabled = True
      Me.mnuMailings.Enabled = True
      Me.mnuRecruitDetail.Enabled = True
      Me.tbDetail.Enabled = True
      Me.tbBrowse.Enabled = True
      Me.tbGenerateMailing.Enabled = True
      Me.tbQuickLetter.Enabled = True
      Me.tbRefresh.Enabled = True
      Me.tbGenerateReminder.Enabled = True
      mnuRecruitDetail_Click(Nothing, Nothing)
    Else
      Me.mnuFileBrowseRecruits.Enabled = False
      Me.mnuMailings.Enabled = False
      Me.mnuRecruitDetail.Enabled = False
      Me.tbDetail.Enabled = False
      Me.tbBrowse.Enabled = False
      Me.tbGenerateMailing.Enabled = False
      Me.tbQuickLetter.Enabled = False
      Me.tbGenerateReminder.Enabled = False
    End If

  End Sub

  Public Sub CallFormBack(ByVal ar2 As IAsyncResult)
    delSubstantive.EndInvoke(ar)
    Me.Invoke(New MethodInvoker(AddressOf DataAreHere))
    ' AddHandler TrackerApp.Tracker1.RecruitContacts.RowChanging, New System.Data.DataRowChangeEventHandler(AddressOf RecruitContacts_RowChanging)
  End Sub

  Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
    If e.Button Is Me.tbSaveToDb Then
      mnuFileSave_Click(Nothing, Nothing)
    ElseIf e.Button Is Me.tbCancelChanges Then
      TrackerApp.Tracker1.RejectChanges()
      NumAdds = 0
      NumUpdates = 0
      NumDeletes = 0
      DataIsChanging(Nothing, New DataRowChangeEventArgs(Nothing, DataRowAction.Nothing))
    ElseIf e.Button Is Me.tbQuery Then
      If TrackerApp.Tracker1.HasChanges Then
        MessageBox.Show("You must save or cancel your changes first")
      Else
        mnuFileFetchData_Click(Nothing, Nothing)
      End If
      'If EndAllEdits() Then
      'End If
    ElseIf e.Button Is Me.tbBrowse Then
      ' Dim f As Form
      For Each f As Form In Me.MdiChildren
        If TypeOf f Is frmRecruitBrowser Then
          f.Activate()
          Return
        End If
      Next
      BrowseRecruits(Nothing, Nothing)
    ElseIf e.Button Is Me.tbDetail Then
      ' Dim f As Form
      For Each f As Form In Me.MdiChildren
        If TypeOf f Is frmRecruitDetail Then
          f.Activate()
          Return
        End If
      Next
      mnuRecruitDetail_Click(Nothing, Nothing)
    ElseIf e.Button Is Me.tbGenerateMailing Then
      mnuFileGenerateLetters_Click(Nothing, Nothing)
    ElseIf e.Button Is Me.tbGenerateReminder Then
      GenerateRemdinder()
      ' GenerateLetters(False, MailingType.macPQReminder)
    ElseIf e.Button Is Me.tbQuickLetter Then
      If TypeOf Me.ActiveMdiChild Is DataboundForm Then
        Dim f As New frmLetters
        f.RecruitID = CType(Me.ActiveMdiChild, DataboundForm).CurrentRecruitID
        If f.ShowDialog(Me) = wf.DialogResult.OK Then
          Select Case TrackerApp.Settings.Study
            Case 1, 4 ' Project quit
              GenerateLetters(CurrentRecruitOnly:=True, MailingType:=MailingType.macPQLetter)
            Case 3 ' Guide To Decide
              GenerateLetters(CurrentRecruitOnly:=True, MailingType:=MailingType.macGTDLetter)
            Case Else
              Throw New ArgumentException("TrackerApp.Settings.Study set to unexpected value--it's freaking me out!")
          End Select

        End If
      End If
    ElseIf e.Button Is Me.tbRefresh Then
      RefreshThisRecruit()
    ElseIf e.Button Is Me.tbReports Then
      ' do nothing?  Pop menuitem?
      Dim loc As Point = Me.tbReports.Rectangle.Location
      loc.Offset(0, Me.tbReports.Rectangle.Height)
      CType(Me.tbReports.DropDownMenu, ContextMenu).Show(Me.ToolBar1, loc)
    ElseIf e.Button Is Me.tbExtra Then
      MessageBox.Show("Status filter is currently: " & TrackerApp.Tracker1.Statuses.DefaultView.RowFilter)
      'Dim sfd As New SaveFileDialog
      'If sfd.ShowDialog = DialogResult.OK Then
      '   TrackerApp.Tracker1.WriteXml(sfd.FileName)
      '   MessageBox.Show("Wrote data to " & sfd.FileName)
      'End If
    Else
      MessageBox.Show("Stop--that tickles!")
    End If
  End Sub
  Public Sub RefreshThisRecruit()
    If TypeOf Me.ActiveMdiChild Is DataboundForm Then
      Dim id As Integer = CType(Me.ActiveMdiChild, DataboundForm).CurrentRecruitID
      If Refresher Is Nothing Then
        Refresher = New TrackerData
        Refresher.EnforceConstraints = False
      Else
        Refresher.Clear()
      End If
      With Me.sdaGetSubstantiveData.SelectCommand
        For Each p As SqlClient.SqlParameter In .Parameters
          Select Case p.ParameterName
            Case "@RecruitIDIs"
              p.Value = id
            Case "@ForStudy"
              ' do nothing
            Case Else
              p.Value = DBNull.Value
          End Select
          Debug.WriteLine("Parameter " & p.ParameterName & " = " & p.Value.ToString)
        Next
      End With

      Dim i As Integer = Me.sdaGetSubstantiveData.Fill(Refresher)
      ' Debug.Assert(i = 1, "Problem--refresh did not bring back a single record!")
      Me.pStatus.Text = "Fetched " & i.ToString & " update records"
      TrackerApp.Tracker1.Merge(Refresher)
      Me.sdaGetSubstantiveData.SelectCommand.Parameters("@RecruitIDIs").Value = DBNull.Value
    End If

  End Sub

  Private Sub AddDataChangeHandlers()

    With TrackerApp.Tracker1
      AddHandler .RecruitContacts.RowChanged, AddressOf DataIsChanging
      AddHandler .RecruitContacts.RowDeleted, AddressOf DataIsChanging
      AddHandler .RecruitContacts.ColumnChanging, AddressOf Column_Changing
      AddHandler .RecruitStatuses.RowChanged, AddressOf DataIsChanging
      AddHandler .RecruitStatuses.RowDeleted, AddressOf DataIsChanging
      AddHandler .RecruitStatuses.ColumnChanging, AddressOf Column_Changing
      AddHandler .Addresses.RowChanged, AddressOf DataIsChanging
      AddHandler .Addresses.RowDeleted, AddressOf DataIsChanging
      AddHandler .Addresses.ColumnChanging, AddressOf Column_Changing
      AddHandler .PhoneNumbers.RowChanged, AddressOf DataIsChanging
      AddHandler .PhoneNumbers.RowDeleted, AddressOf DataIsChanging
      AddHandler .Recruits.RowChanged, AddressOf DataIsChanging
      AddHandler .Recruits.RowDeleted, AddressOf DataIsChanging
      AddHandler .UpdatedAddresses.RowDeleted, AddressOf DataIsChanging
    End With
    NumAdds = 0
    NumUpdates = 0
    NumDeletes = 0
    DataIsChanging(Nothing, New DataRowChangeEventArgs(Nothing, DataRowAction.Nothing))
  End Sub

  Private Sub RemoveDataChangeHandlers()
    '          AddHandler a.t.RowChanged, AddressOf DataIsChanging

    With TrackerApp.Tracker1
      RemoveHandler .RecruitContacts.RowChanged, AddressOf DataIsChanging
      RemoveHandler .RecruitContacts.RowDeleted, AddressOf DataIsChanging
      RemoveHandler .RecruitContacts.ColumnChanging, AddressOf Column_Changing
      RemoveHandler .RecruitStatuses.RowChanged, AddressOf DataIsChanging
      RemoveHandler .RecruitStatuses.RowDeleted, AddressOf DataIsChanging
      RemoveHandler .RecruitStatuses.ColumnChanging, AddressOf Column_Changing
      RemoveHandler .Addresses.RowChanged, AddressOf DataIsChanging
      RemoveHandler .Addresses.RowDeleted, AddressOf DataIsChanging
      RemoveHandler .Addresses.ColumnChanging, AddressOf Column_Changing
      RemoveHandler .PhoneNumbers.RowChanged, AddressOf DataIsChanging
      RemoveHandler .PhoneNumbers.RowDeleted, AddressOf DataIsChanging
      RemoveHandler .Recruits.RowChanged, AddressOf DataIsChanging
      RemoveHandler .Recruits.RowDeleted, AddressOf DataIsChanging
      RemoveHandler .UpdatedAddresses.RowDeleted, AddressOf DataIsChanging
    End With
  End Sub

  Public Shared Sub Column_Changing(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
    If e.Column.DataType.ToString = "System.DateTime" AndAlso (Not e.ProposedValue Is System.DBNull.Value) Then
      Dim pd As DateTime = CType(e.ProposedValue, DateTime)
      If pd < #1/1/1753# Or pd > #12/31/9999# Then
        e.Row.SetColumnError(e.Column, "This is not a valid date value")
        Beep()
      Else
        e.Row.SetColumnError(e.Column, "")
      End If
    Else
      e.Row.SetColumnError(e.Column, "")
    End If
  End Sub

  Private Sub RecordContacts(ByVal MailingType As MailingType)
    Dim cmd As New SqlClient.SqlCommand
    Try
      Dim prmStatusDescription As New SqlClient.SqlParameter("@StatusDescription", SqlDbType.VarChar, 30)
      Dim prmStudy As New SqlClient.SqlParameter("@Study", SqlDbType.Int)
      Select Case MailingType
        Case MailingType.macPQLetter, MailingType.macGTDLetter
          prmStatusDescription.Value = "First letter sent"
        Case MailingType.macPQReminder, Tracker.MailingType.macGTDReminder
          prmStatusDescription.Value = "Reminder letter sent"
        Case MailingType.macGTDThankYou
          prmStatusDescription.Value = "Baseline thank-you sent"
        Case Tracker.MailingType.macGTDPreincentive
          prmStatusDescription.Value = "3-Mo preincentive letter sent"
        Case Tracker.MailingType.macGTDThankYouCashReport
          prmStatusDescription.Value = "Thank-you cash reported"
        Case Tracker.MailingType.macGTDPreincentiveCashRequest
          prmStatusDescription.Value = "Preincentive cash ordered"
      End Select
      prmStudy.Value = TrackerApp.Settings.Study
      With cmd
        .Connection = Me.SqlConnection1
        .CommandType = CommandType.StoredProcedure
        ' .CommandText = "RecordInviteLetter"
        .CommandText = "RecordLetter"
        .Parameters.Add(prmStatusDescription)
        .Parameters.Add(prmStudy)
        If .Connection.State <> ConnectionState.Open Then .Connection.Open()
        .ExecuteNonQuery()
        .Connection.Close()
      End With
    Catch sex As System.Data.SqlClient.SqlException
      ' do what here?
      Dim s As String = "Problem recording the " & MailingType.ToString & " letters:" & se.NewLine & se.NewLine & sex.Message
      MessageBox.Show(s)
      Dim x As New ctrhs_devnet.ExceptionMailer
      x.Send(se.UserName, se.MachineName, s & se.NewLine & sex.ToString, "pardee.r@ghc.org", "CHCRTracker")
    Finally
      If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
    End Try
  End Sub

  Private Function LaunchMSAccess(ByVal MacroName As String) As Boolean
    Dim RunLine As String
    Dim EXELoc As String = "C:\Program Files\Microsoft Office\Office\MSACCESS.EXE"
    Dim ReporterLoc As String
    Const ReporterName As String = "CHCRReporter.mde"
    Dim msg As String = String.Empty

    ' Find the msaccess executable.
    If Not System.IO.File.Exists(EXELoc) Then

      ' We've got to look for it--check in the key:
      ' HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\MSACCESS.EXE
      ' the value name is 'Path'.  Tack an msaccess.exe onto it (no backslash needed).
      Dim r As Microsoft.Win32.RegistryKey
      ' r = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Office\9.0\Access\InstallRoot", False)
      r = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\MSACCESS.EXE", False)
      If r Is Nothing Then
        msg = "Problem--could not find the location of the microsoft Access executable in the registry--cannot continue"
      Else

        EXELoc = CType(r.GetValue("Path", "<not found>"), String) & "MSAccess.exe"
        If Not System.IO.File.Exists(EXELoc) Then
          msg = "Problem--could not find Microsoft Access on this machine--cannot continue."
        End If
      End If
      If msg.Length > 0 Then
        MessageBox.Show(msg)
        Dim x As New ctrhs_devnet.ExceptionMailer
        x.Send(se.UserName, se.MachineName, "Could not find msaccess in LaunchMSAccess()", "pardee.r@ghc.org", "CHCRTracker")
        Return False
      End If

    End If
    ' Find the proper mdb.
    ReporterLoc = Application.StartupPath() & "\" & ReporterName
    If Not System.IO.File.Exists(ReporterLoc) Then
      MessageBox.Show("Problem--reporter db not in its expected location: """ & ReporterLoc & """--cannot continue.")
      Dim x As New ctrhs_devnet.ExceptionMailer
      x.Send(se.UserName, se.MachineName, "Could not find """ & ReporterLoc & """ in LaunchMSAccess()", "pardee.r@ghc.org", "CHCRTracker")
      Return False
    End If
    ' "C:\Program Files\Microsoft Office\Office\MSACCESS.EXE"  "\\home\pardre1\Visual Studio Projects\CHCRTracker\bin\CHCRReporter.mde" /x macPQLetter
    Dim dq As String = """"
    RunLine = dq & EXELoc & dq & " " & dq & ReporterLoc & dq & " /x " & MacroName
    Console.WriteLine(RunLine)
    ' Launch msaccess synchronously
    ' I wonder if there's a fancier way of doing this, that would keep the app
    ' responsive...  An asynchronous delegate or some such thing I suppose...
    'Dim si As New System.Diagnostics.ProcessStartInfo
    'With si
    '   .WindowStyle = ProcessWindowStyle.Maximized
    '   .FileName = dq & EXELoc & dq
    '   .Arguments = dq & ReporterLoc & dq & " /x " & MacroName
    'End With
    'Dim p As New System.Diagnostics.Process
    'p.Start(si)

    Shell(RunLine, AppWinStyle.MaximizedFocus, True)
    Return True
  End Function

  Private Sub mnuReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles mnuMainReportsStatusOverview.Click, mnuMainReportsContactLog.Click _
  , mnuReportsStatusOverview.Click, mnuReportsContactLog.Click
    ' http://ctrhs-devnet/pardre1/CHCRContactLog/ContactLog.aspx
    Select Case CType(sender, MenuItem).Text
      Case "&Status Overview"
        System.Diagnostics.Process.Start("http://ctrhs-devnet/pardre1/pqstatusoverview/main.aspx")
      Case "&Contact Log"
        System.Diagnostics.Process.Start("http://ctrhs-devnet/pardre1/CHCRContactLog/ContactLog.aspx")
      Case Else
        MessageBox.Show("Menu item text was """ & CType(sender, MenuItem).Text & """--don't know what to do with that")
    End Select
  End Sub

  Private Sub mnuMailingsReminder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMailingsReminder.Click
    GenerateRemdinder()
  End Sub

  Private Sub mnuMailingsThankYou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMailingsThankYou.Click
    Dim f As New frmLetters

    If f.ShowDialog(Me) = wf.DialogResult.OK Then
      GenerateLetters(False, MailingType.macGTDThankYou)
    End If

  End Sub

  Private Sub mnuMailingPreincentive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMailingPreincentive.Click
    Dim f As New frmLetters
    If f.ShowDialog(Me) = wf.DialogResult.OK Then
      GenerateLetters(False, MailingType.macGTDPreincentive)
    End If
  End Sub

  Private Sub mnuAccountingBaselineThankyou_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAccountingBaselineThankyou.Click
    FillMailToForAccounting()
    GenerateLetters(False, MailingType.macGTDThankYouCashReport)
  End Sub

  Private Sub mnuAccountingPreincentiveOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAccountingPreincentiveOrder.Click
    FillMailToForAccounting()
    GenerateLetters(False, MailingType.macGTDPreincentiveCashRequest)
  End Sub
  Private Sub FillMailToForAccounting()
    Dim Recruits As New ArrayList
    Recruits = ArrayList.Adapter(TrackerApp.Tracker1.Recruits.Select)
    TrackerApp.FillMailTo(Me.SqlConnection1, DateTime.Now, Recruits)
  End Sub
End Class

