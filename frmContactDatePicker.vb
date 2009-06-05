Public Class frmContactDatePicker
    Inherits System.Windows.Forms.Form

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
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents dgContacts As System.Windows.Forms.DataGrid
   Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
   Friend WithEvents tbcContactDate As System.Windows.Forms.DataGridTextBoxColumn
   Friend WithEvents tbcContactType As System.Windows.Forms.DataGridTextBoxColumn
   Friend WithEvents tbcCount As System.Windows.Forms.DataGridTextBoxColumn
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnOK = New System.Windows.Forms.Button
      Me.dgContacts = New System.Windows.Forms.DataGrid
      Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
      Me.tbcContactDate = New System.Windows.Forms.DataGridTextBoxColumn
      Me.tbcContactType = New System.Windows.Forms.DataGridTextBoxColumn
      Me.tbcCount = New System.Windows.Forms.DataGridTextBoxColumn
      CType(Me.dgContacts, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCancel.Location = New System.Drawing.Point(16, 376)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.TabIndex = 0
      Me.btnCancel.Text = "&Cancel"
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnOK.Location = New System.Drawing.Point(336, 376)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.TabIndex = 1
      Me.btnOK.Text = "&OK"
      '
      'dgContacts
      '
      Me.dgContacts.AllowNavigation = False
      Me.dgContacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgContacts.BackgroundColor = System.Drawing.Color.LightGray
      Me.dgContacts.CaptionVisible = False
      Me.dgContacts.DataMember = ""
      Me.dgContacts.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.dgContacts.Location = New System.Drawing.Point(16, 8)
      Me.dgContacts.Name = "dgContacts"
      Me.dgContacts.ReadOnly = True
      Me.dgContacts.RowHeadersVisible = False
      Me.dgContacts.Size = New System.Drawing.Size(408, 344)
      Me.dgContacts.TabIndex = 2
      Me.dgContacts.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
      '
      'DataGridTableStyle1
      '
      Me.DataGridTableStyle1.DataGrid = Me.dgContacts
      Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.tbcContactDate, Me.tbcContactType, Me.tbcCount})
      Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGridTableStyle1.MappingName = "ContactsOverview"
      '
      'tbcContactDate
      '
      Me.tbcContactDate.Format = ""
      Me.tbcContactDate.FormatInfo = Nothing
      Me.tbcContactDate.HeaderText = "Date"
      Me.tbcContactDate.MappingName = "contactdate"
      Me.tbcContactDate.Width = 175
      '
      'tbcContactType
      '
      Me.tbcContactType.Format = ""
      Me.tbcContactType.FormatInfo = Nothing
      Me.tbcContactType.HeaderText = "Type"
      Me.tbcContactType.MappingName = "contacttypedescription"
      Me.tbcContactType.Width = 75
      '
      'tbcCount
      '
      Me.tbcCount.Format = ""
      Me.tbcCount.FormatInfo = Nothing
      Me.tbcCount.HeaderText = "# Recruits"
      Me.tbcCount.MappingName = "freq"
      Me.tbcCount.Width = 75
      '
      'frmContactDatePicker
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(448, 402)
      Me.Controls.Add(Me.dgContacts)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "frmContactDatePicker"
      Me.ShowInTaskbar = False
      Me.Text = "Recruit Contacts"
      CType(Me.dgContacts, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub frmContactDatePicker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      RefreshData()
      With Me.dgContacts
      .DataSource = TrackerApp.Tracker1
         .DataMember = "ContactsOverview"
      End With
   End Sub
   Private Sub RefreshData()

    With TrackerApp.Tracker1.ContactsOverview
      If .Count > 0 Then
        .Clear()
      End If
    End With

    Dim c As New SqlClient.SqlCommand("select * from ContactsOverview_vw order by ContactDate DESC")
        c.Connection = CType(Me.Owner.Owner, frmTracker).SqlConnection1
      Dim sda As New SqlClient.SqlDataAdapter(c)
    sda.Fill(TrackerApp.Tracker1.ContactsOverview)

   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      Dim dt As DateTime
      Dim cm As CurrencyManager
      With Me.dgContacts
         cm = CType(.BindingContext(.DataSource, .DataMember), CurrencyManager)
         Dim drv As DataRowView = CType(cm.Current, DataRowView)
      dt = CType(drv.Row, Tracker.TrackerData.ContactsOverviewRow).contactdate()
         CType(Me.Owner, frmQueryData).ContactDate = dt
         ' Console.WriteLine(dt.ToLongTimeString)
      End With
   End Sub
End Class
