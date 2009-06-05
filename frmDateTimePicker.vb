
Public Class frmDateTimePicker
   Inherits System.Windows.Forms.Form
   Private m_DateTime As DateTime = Nothing
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
   Friend WithEvents MoCal As System.Windows.Forms.MonthCalendar
   Friend WithEvents TimePicker As System.Windows.Forms.DateTimePicker
   Friend WithEvents lblPrompt As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.MoCal = New System.Windows.Forms.MonthCalendar
      Me.TimePicker = New System.Windows.Forms.DateTimePicker
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnOK = New System.Windows.Forms.Button
      Me.lblPrompt = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'MoCal
      '
      Me.MoCal.Location = New System.Drawing.Point(24, 72)
      Me.MoCal.Name = "MoCal"
      Me.MoCal.TabIndex = 0
      '
      'TimePicker
      '
      Me.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.TimePicker.Location = New System.Drawing.Point(24, 272)
      Me.TimePicker.Name = "TimePicker"
      Me.TimePicker.ShowUpDown = True
      Me.TimePicker.Size = New System.Drawing.Size(220, 23)
      Me.TimePicker.TabIndex = 1
      '
      'btnCancel
      '
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(24, 312)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.TabIndex = 2
      Me.btnCancel.Text = "&Cancel"
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(168, 312)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.TabIndex = 3
      Me.btnOK.Text = "&OK"
      '
      'lblPrompt
      '
      Me.lblPrompt.AutoSize = True
      Me.lblPrompt.Location = New System.Drawing.Point(24, 8)
      Me.lblPrompt.Name = "lblPrompt"
      Me.lblPrompt.Size = New System.Drawing.Size(129, 19)
      Me.lblPrompt.TabIndex = 4
      Me.lblPrompt.Text = "Please choose a date"
      '
      'frmDateTimePicker
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(264, 341)
      Me.Controls.Add(Me.lblPrompt)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.TimePicker)
      Me.Controls.Add(Me.MoCal)
      Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
      Me.Name = "frmDateTimePicker"
      Me.Text = "Date/Time Picker"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub frmDateTimePicker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      m_DateTime = Nothing
   End Sub
   Public Property Prompt() As String
      Get
         Return Me.lblPrompt.Text
      End Get
      Set(ByVal Value As String)
         Me.lblPrompt.Text = Value
      End Set
   End Property
   Public Property DateTime() As DateTime
      Get
         Return m_DateTime
      End Get
      Set(ByVal Value As DateTime)
         m_DateTime = Value
      End Set
   End Property

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      ' There's got to be a nicer way to do this--read up on datetimes...

      m_DateTime = System.DateTime.Parse(Me.MoCal.SelectionStart.Date.ToShortDateString & " " & Me.TimePicker.Value.TimeOfDay.ToString)
   End Sub

   Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
      m_DateTime = System.DateTime.MinValue
   End Sub
End Class
