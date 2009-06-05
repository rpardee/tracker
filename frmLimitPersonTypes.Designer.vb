<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLimitPersonTypes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.TodobytypecountsvwBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.Tracker = New Tracker.TrackerData
    Me.Todo_by_type_counts_vwTableAdapter = New Tracker.TrackerDataTableAdapters.todo_by_type_counts_vwTableAdapter
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.TobedoneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PersontypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WantedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TodobytypecountsvwBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Tracker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TobedoneDataGridViewTextBoxColumn, Me.PersontypeDataGridViewTextBoxColumn, Me.NumDataGridViewTextBoxColumn, Me.WantedDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.TodobytypecountsvwBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(13, 39)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(547, 173)
        Me.DataGridView1.TabIndex = 0
        '
        'TodobytypecountsvwBindingSource
        '
        Me.TodobytypecountsvwBindingSource.DataMember = "todo_by_type_counts_vw"
    Me.TodobytypecountsvwBindingSource.DataSource = Me.Tracker
        Me.TodobytypecountsvwBindingSource.Filter = ""
        '
        'CHCR
        '
    Me.Tracker.DataSetName = "Tracker"
    Me.Tracker.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Todo_by_type_counts_vwTableAdapter
        '
        Me.Todo_by_type_counts_vwTableAdapter.ClearBeforeFill = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Location = New System.Drawing.Point(482, 233)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(78, 47)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(13, 233)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 47)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TobedoneDataGridViewTextBoxColumn
        '
        Me.TobedoneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.TobedoneDataGridViewTextBoxColumn.DataPropertyName = "tobedone"
        Me.TobedoneDataGridViewTextBoxColumn.HeaderText = "Task"
        Me.TobedoneDataGridViewTextBoxColumn.Name = "TobedoneDataGridViewTextBoxColumn"
        Me.TobedoneDataGridViewTextBoxColumn.ReadOnly = True
        Me.TobedoneDataGridViewTextBoxColumn.Width = 65
        '
        'PersontypeDataGridViewTextBoxColumn
        '
        Me.PersontypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PersontypeDataGridViewTextBoxColumn.DataPropertyName = "persontype"
        Me.PersontypeDataGridViewTextBoxColumn.HeaderText = "Source"
        Me.PersontypeDataGridViewTextBoxColumn.Name = "PersontypeDataGridViewTextBoxColumn"
        Me.PersontypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.PersontypeDataGridViewTextBoxColumn.Width = 77
        '
        'NumDataGridViewTextBoxColumn
        '
        Me.NumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.NumDataGridViewTextBoxColumn.DataPropertyName = "num"
        Me.NumDataGridViewTextBoxColumn.HeaderText = "# Available"
        Me.NumDataGridViewTextBoxColumn.Name = "NumDataGridViewTextBoxColumn"
        Me.NumDataGridViewTextBoxColumn.ReadOnly = True
        Me.NumDataGridViewTextBoxColumn.ToolTipText = "The number of people available in the db."
        Me.NumDataGridViewTextBoxColumn.Width = 104
        '
        'WantedDataGridViewTextBoxColumn
        '
        Me.WantedDataGridViewTextBoxColumn.DataPropertyName = "Wanted"
        Me.WantedDataGridViewTextBoxColumn.HeaderText = "# Wanted"
        Me.WantedDataGridViewTextBoxColumn.MaxInputLength = 5
        Me.WantedDataGridViewTextBoxColumn.Name = "WantedDataGridViewTextBoxColumn"
        Me.WantedDataGridViewTextBoxColumn.ToolTipText = "The number of people you want for this run."
        Me.WantedDataGridViewTextBoxColumn.Width = 150
        '
        'frmLimitPersonTypes
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(573, 293)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmLimitPersonTypes"
        Me.Text = "Specify person type numbers"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TodobytypecountsvwBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Tracker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
  Friend WithEvents Tracker As Tracker.TrackerData
  Friend WithEvents TodobytypecountsvwBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents Todo_by_type_counts_vwTableAdapter As Tracker.TrackerDataTableAdapters.todo_by_type_counts_vwTableAdapter
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TobedoneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersontypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WantedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
