Public Class frmLetters
    Inherits System.Windows.Forms.Form
  Dim rt As Tracker.TrackerData.RecruitsDataTable = TrackerApp.tracker1.Recruits
  Dim dvAsc As New System.Data.DataView(rt)
   Dim dvDesc As New System.Data.DataView(rt)


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
   Friend WithEvents cmbStartName As System.Windows.Forms.ComboBox
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmbStopName As System.Windows.Forms.ComboBox
   Friend WithEvents mocal As System.Windows.Forms.MonthCalendar
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.cmbStartName = New System.Windows.Forms.ComboBox
      Me.cmbStopName = New System.Windows.Forms.ComboBox
      Me.mocal = New System.Windows.Forms.MonthCalendar
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnOK = New System.Windows.Forms.Button
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'cmbStartName
      '
      Me.cmbStartName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbStartName.Location = New System.Drawing.Point(8, 288)
      Me.cmbStartName.Name = "cmbStartName"
      Me.cmbStartName.Size = New System.Drawing.Size(168, 24)
      Me.cmbStartName.TabIndex = 0
      '
      'cmbStopName
      '
      Me.cmbStopName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbStopName.Location = New System.Drawing.Point(248, 288)
      Me.cmbStopName.Name = "cmbStopName"
      Me.cmbStopName.Size = New System.Drawing.Size(168, 24)
      Me.cmbStopName.TabIndex = 1
      '
      'mocal
      '
      Me.mocal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.mocal.Location = New System.Drawing.Point(8, 40)
      Me.mocal.Name = "mocal"
      Me.mocal.TabIndex = 2
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(8, 336)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.TabIndex = 3
      Me.btnCancel.Text = "&Cancel"
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(341, 336)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.TabIndex = 4
      Me.btnOK.Text = "&OK"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(8, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(252, 19)
      Me.Label1.TabIndex = 5
      Me.Label1.Text = "What date shall we print on these letters?"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(8, 256)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(98, 19)
      Me.Label2.TabIndex = 6
      Me.Label2.Text = "Print letters for:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(184, 288)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(56, 19)
      Me.Label3.TabIndex = 7
      Me.Label3.Text = "through:"
      '
      'frmLetters
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(432, 370)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.mocal)
      Me.Controls.Add(Me.cmbStopName)
      Me.Controls.Add(Me.cmbStartName)
      Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "frmLetters"
      Me.ShowInTaskbar = False
      Me.Text = "Print Recruit Letters"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub frmLetters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      dvAsc.Sort = "FullName"
      dvDesc.Sort = "FullName DESC"

      With Me.cmbStartName
         .DataSource = dvAsc
         .DisplayMember = "FullName"
      End With
      With Me.cmbStopName
         .DataSource = dvDesc
         .DisplayMember = "FullName"
      End With
   End Sub
   Public WriteOnly Property RecruitID() As Integer
      Set(ByVal Value As Integer)
         dvAsc.RowFilter = "RecruitID = " & Value.ToString
         dvDesc.RowFilter = "RecruitID = " & Value.ToString
      End Set
   End Property
   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      Dim StartIndex As Integer = dvAsc.Find(Me.cmbStartName.Text)
      Dim StopIndex As Integer = dvAsc.Find(Me.cmbStopName.Text)
      Dim Recruits As New ArrayList

      For i As Integer = StartIndex To StopIndex
         ' Console.WriteLine("Row: " & i.ToString & " is " & r.FullName)
      Recruits.Add(CType(dvAsc.Item(i).Row(), TrackerData.RecruitsRow))
      Next

    TrackerApp.FillMailTo(CType(Me.Owner, frmTracker).SqlConnection1, Me.mocal.SelectionStart, Recruits)

   End Sub
End Class
