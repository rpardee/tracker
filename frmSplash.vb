Public Class frmSplash
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
   Friend WithEvents Label1 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.Label1 = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Verdana", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(8, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(464, 152)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Cranking up.... Please be patient."
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'frmSplash
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(13, 30)
      Me.ClientSize = New System.Drawing.Size(480, 168)
      Me.Controls.Add(Me.Label1)
      Me.Cursor = System.Windows.Forms.Cursors.AppStarting
      Me.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
      Me.Name = "frmSplash"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Starting CHCR Tracker..."
      Me.ResumeLayout(False)

   End Sub

#End Region

End Class
