Imports wf = System.Windows.Forms

Public Class frmLimitCardNumbers
   Inherits System.Windows.Forms.Form

   Private frmQ As frmQueryData

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
   Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents dgtsIncentiveCardCounts As System.Windows.Forms.DataGridTableStyle
   Friend WithEvents tbcIncentive As System.Windows.Forms.DataGridTextBoxColumn
   Friend WithEvents tbcNumber As System.Windows.Forms.DataGridTextBoxColumn
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.dgtsIncentiveCardCounts = New System.Windows.Forms.DataGridTableStyle
        Me.tbcIncentive = New System.Windows.Forms.DataGridTextBoxColumn
        Me.tbcNumber = New System.Windows.Forms.DataGridTextBoxColumn
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionText = "Pull out how many people for each card type?"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(400, 216)
        Me.DataGrid1.TabIndex = 0
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgtsIncentiveCardCounts})
        '
        'dgtsIncentiveCardCounts
        '
        Me.dgtsIncentiveCardCounts.DataGrid = Me.DataGrid1
        Me.dgtsIncentiveCardCounts.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.tbcIncentive, Me.tbcNumber})
        Me.dgtsIncentiveCardCounts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgtsIncentiveCardCounts.MappingName = "incentive_card_counts_vw"
        '
        'tbcIncentive
        '
        Me.tbcIncentive.Format = ""
        Me.tbcIncentive.FormatInfo = Nothing
        Me.tbcIncentive.HeaderText = "Card Type"
        Me.tbcIncentive.MappingName = "Incentive"
        Me.tbcIncentive.Width = 125
        '
        'tbcNumber
        '
        Me.tbcNumber.Format = ""
        Me.tbcNumber.FormatInfo = Nothing
        Me.tbcNumber.HeaderText = "Number"
        Me.tbcNumber.MappingName = "num_needed"
        Me.tbcNumber.Width = 75
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(312, 232)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 32)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(8, 232)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 32)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        '
        'frmLimitCardNumbers
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(416, 270)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmLimitCardNumbers"
        Me.Text = "Limit Card Numbers"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

  'Private Sub frmLimitCardNumbers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  '   frmQ = CType(Me.Owner, frmQueryData)
  ' Dim desc As String = frmQ.TicklerToBeDone.ToString()
  '   Debug.Assert(desc.Length > 0, "Tickler status description string not set!")
  '   Dim con As SqlClient.SqlConnection = CType(Me.Owner.Owner, frmCHCRTracker).SqlConnection1
  '   Dim cmd As New SqlClient.SqlCommand("select * from incentive_card_counts_vw where description = '" & desc & "'", con)
  '   Dim sda As New SqlClient.SqlDataAdapter(cmd)
  '   TrackerApp.Tracker1.incentive_card_counts_vw.Clear()
  '   sda.Fill(TrackerApp.Tracker1.incentive_card_counts_vw)
  '   With Me.DataGrid1
  '      .DataSource = TrackerApp.Tracker1
  '      .DataMember = TrackerApp.Tracker1.incentive_card_counts_vw.TableName
  '   End With
  'End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    For Each r As TrackerData.incentive_card_counts_vwRow In TrackerApp.Tracker1.incentive_card_counts_vw.Rows
      ' MessageBox.Show("set " & r.incentive & " = " & r.num_needed.ToString)
      Select Case r.incentive
        Case "Target"
          frmQ.NumTarget = r.num_needed
        Case "Kroger"
          frmQ.NumKroger = r.num_needed
        Case "Starbucks"
          frmQ.NumStarbucks = r.num_needed
        Case Else
          Debug.Assert(False, "Unanticipated value of incentive ('" & r.incentive & "')--freaking out.")
      End Select
    Next
    Me.DialogResult = wf.DialogResult.OK
  End Sub
  Private Sub frmLimitCardNumbers_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    TrackerApp.Tracker1.incentive_card_counts_vw.AcceptChanges()
  End Sub

   Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        frmQ.chkLimitPersonTypes.Checked = False
      Me.DialogResult = wf.DialogResult.Cancel
   End Sub

    Private Sub frmLimitCardNumbers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
