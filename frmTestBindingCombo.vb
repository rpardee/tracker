Public Class frmTestBindingCombo
    Inherits System.Windows.Forms.Form
   Private myCurrencyManager As CurrencyManager

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
   Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.ComboBox1 = New System.Windows.Forms.ComboBox
      Me.Button1 = New System.Windows.Forms.Button
      Me.TextBox1 = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'ComboBox1
      '
      Me.ComboBox1.DisplayMember = "ContactTypes.ContactType"
      Me.ComboBox1.Location = New System.Drawing.Point(8, 32)
      Me.ComboBox1.Name = "ComboBox1"
      Me.ComboBox1.Size = New System.Drawing.Size(272, 21)
      Me.ComboBox1.TabIndex = 0
      Me.ComboBox1.ValueMember = "ContactTypes.ContactType"
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(32, 168)
      Me.Button1.Name = "Button1"
      Me.Button1.TabIndex = 1
      Me.Button1.Text = "Button1"
      '
      'TextBox1
      '
      Me.TextBox1.Location = New System.Drawing.Point(56, 80)
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.TabIndex = 2
      Me.TextBox1.Text = "TextBox1"
      '
      'frmTestBindingCombo
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(292, 270)
      Me.Controls.Add(Me.TextBox1)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.ComboBox1)
      Me.Name = "frmTestBindingCombo"
      Me.Text = "frmTestBindingCombo"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub frmTestBindingCombo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim db As New Binding("DisplayMember", TrackerApp.Tracker1, "RecruitContacts.ContactDate")

    With Me.ComboBox1

      .DataSource = TrackerApp.Tracker1
      .DisplayMember = "RecruitContacts.ContactDate"
      .ValueMember = .DisplayMember
      ' .ValueMember = "ContactTypes.ContactType"
      ' .DataBindings.Add("SelectedValue", TrackerApp.Tracker1, "RecruitContacts.ContactType")
    End With

    Me.TextBox1.DataBindings.Add("Text", TrackerApp.Tracker1, "RecruitContacts.ContactType")
      myCurrencyManager = CType(Me.BindingContext(Me.ComboBox1.DataSource, "RecruitContacts"), CurrencyManager)
   End Sub

   Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
      Me.Text = "Combobox value is now " & Me.ComboBox1.SelectedValue.ToString
   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      ' Dim cm As CurrencyManager = CType(Me.BindingContext(Me.ComboBox1.DataSource, Me.ComboBox1.ValueMember), CurrencyManager)
      'Dim cm As CurrencyManager = CType(Me.BindingContext(Me.ComboBox1.DataSource, "RecruitContacts"), CurrencyManager)
      'cm.Position += 1
      myCurrencyManager.Position += 1
      Me.Text = "Now on record: " & myCurrencyManager.Position.ToString
   End Sub
End Class
