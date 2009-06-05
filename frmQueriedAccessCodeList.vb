Public Class frmQueriedAccessCodeList
    Inherits System.Windows.Forms.Form
    Private cn As SqlClient.SqlConnection
    Friend WithEvents rtfFreeList As System.Windows.Forms.RichTextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

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
    Friend WithEvents sdaQueriedAccessCodes As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents sqlSelectQueriedAccessCodes As System.Data.SqlClient.SqlCommand
    Friend WithEvents sqlInsertQueriedAccessCodes As System.Data.SqlClient.SqlCommand
    Friend WithEvents sqlUpdateQueriedAccessCodes As System.Data.SqlClient.SqlCommand
    Friend WithEvents sqlDeleteQueriedAccessCodes As System.Data.SqlClient.SqlCommand
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnClearList As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQueriedAccessCodeList))
        Me.sdaQueriedAccessCodes = New System.Data.SqlClient.SqlDataAdapter
        Me.sqlDeleteQueriedAccessCodes = New System.Data.SqlClient.SqlCommand
        Me.sqlInsertQueriedAccessCodes = New System.Data.SqlClient.SqlCommand
        Me.sqlSelectQueriedAccessCodes = New System.Data.SqlClient.SqlCommand
        Me.sqlUpdateQueriedAccessCodes = New System.Data.SqlClient.SqlCommand
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnClearList = New System.Windows.Forms.Button
        Me.rtfFreeList = New System.Windows.Forms.RichTextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'sdaQueriedAccessCodes
        '
        Me.sdaQueriedAccessCodes.DeleteCommand = Me.sqlDeleteQueriedAccessCodes
        Me.sdaQueriedAccessCodes.InsertCommand = Me.sqlInsertQueriedAccessCodes
        Me.sdaQueriedAccessCodes.SelectCommand = Me.sqlSelectQueriedAccessCodes
        Me.sdaQueriedAccessCodes.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "QueriedAccessCodeList", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("AddedBy", "AddedBy"), New System.Data.Common.DataColumnMapping("AccLetter", "AccLetter"), New System.Data.Common.DataColumnMapping("AccNumber", "AccNumber")})})
        Me.sdaQueriedAccessCodes.UpdateCommand = Me.sqlUpdateQueriedAccessCodes
        '
        'sqlDeleteQueriedAccessCodes
        '
        Me.sqlDeleteQueriedAccessCodes.CommandText = "DELETE FROM QueriedAccessCodeList WHERE (AccLetter = @Original_AccLetter) AND (Ac" & _
            "cNumber = @Original_AccNumber) AND (AddedBy = user)"
        Me.sqlDeleteQueriedAccessCodes.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_AccLetter", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AccLetter", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AccNumber", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AccNumber", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedBy", System.Data.DataRowVersion.Original, Nothing)})
        '
        'sqlInsertQueriedAccessCodes
        '
        Me.sqlInsertQueriedAccessCodes.CommandText = resources.GetString("sqlInsertQueriedAccessCodes.CommandText")
        Me.sqlInsertQueriedAccessCodes.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@AddedBy", System.Data.SqlDbType.VarChar, 10, "AddedBy"), New System.Data.SqlClient.SqlParameter("@AccLetter", System.Data.SqlDbType.VarChar, 2, "AccLetter"), New System.Data.SqlClient.SqlParameter("@AccNumber", System.Data.SqlDbType.VarChar, 4, "AccNumber")})
        '
        'sqlSelectQueriedAccessCodes
        '
        Me.sqlSelectQueriedAccessCodes.CommandText = "SELECT AddedBy, AccLetter, AccNumber FROM QueriedAccessCodeList WHERE (AddedBy = " & _
            "USER)"
        '
        'sqlUpdateQueriedAccessCodes
        '
        Me.sqlUpdateQueriedAccessCodes.CommandText = resources.GetString("sqlUpdateQueriedAccessCodes.CommandText")
        Me.sqlUpdateQueriedAccessCodes.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@AddedBy", System.Data.SqlDbType.VarChar, 10, "AddedBy"), New System.Data.SqlClient.SqlParameter("@AccLetter", System.Data.SqlDbType.VarChar, 2, "AccLetter"), New System.Data.SqlClient.SqlParameter("@AccNumber", System.Data.SqlDbType.VarChar, 4, "AccNumber"), New System.Data.SqlClient.SqlParameter("@Original_AccLetter", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AccLetter", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AccNumber", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AccNumber", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@Original_AddedBy", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AddedBy", System.Data.DataRowVersion.Original, Nothing)})
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(8, 376)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 24)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(178, 376)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(74, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "&OK"
        '
        'btnClearList
        '
        Me.btnClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearList.Location = New System.Drawing.Point(186, 8)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(75, 23)
        Me.btnClearList.TabIndex = 3
        Me.btnClearList.Text = "Clear List"
        '
        'rtfFreeList
        '
        Me.rtfFreeList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtfFreeList.DetectUrls = False
        Me.rtfFreeList.Location = New System.Drawing.Point(9, 10)
        Me.rtfFreeList.Name = "rtfFreeList"
        Me.rtfFreeList.Size = New System.Drawing.Size(171, 344)
        Me.rtfFreeList.TabIndex = 6
        Me.rtfFreeList.Text = ""
        Me.rtfFreeList.WordWrap = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(184, 58)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(80, 176)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Text = "Type or paste in text containing access codes."
        '
        'frmQueriedAccessCodeList
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(274, 410)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.rtfFreeList)
        Me.Controls.Add(Me.btnClearList)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmQueriedAccessCodeList"
        Me.ShowInTaskbar = False
        Me.Text = "List Access Codes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub frmQueriedAccessCodeList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = CType(Me.Owner.Owner, frmTracker).SqlConnection1
        With Me.sdaQueriedAccessCodes
            .SelectCommand.Connection = cn
            .InsertCommand.Connection = cn
            .UpdateCommand.Connection = cn
            .DeleteCommand.Connection = cn
      .Fill(TrackerApp.Tracker1.QueriedAccessCodeList)
        End With
    TrackerApp.Tracker1.QueriedAccessCodeList.AddedByColumn.AllowDBNull = True
    LoadTextBox()
  End Sub

  Private Sub LoadTextBox()
    ' Dim s As String = String.Empty
    Dim s As New System.Text.StringBuilder
    For Each r As TrackerData.QueriedAccessCodeListRow In TrackerApp.Tracker1.QueriedAccessCodeList.Rows
      s.Append(r.AccLetter & "-" & r.AccNumber & System.Environment.NewLine)
    Next
    Me.rtfFreeList.Text = s.ToString
  End Sub

    Private Function ParseText() As Boolean

        Dim m1 As System.Text.RegularExpressions.Match
        Dim mc As System.Text.RegularExpressions.MatchCollection
    Dim dtQueriedAccessCodes As New TrackerData.QueriedAccessCodeListDataTable
        Dim badlines As Integer = 0

        Me.rtfFreeList.Text = Me.rtfFreeList.Text.ToUpper

        For Each line As String In Me.rtfFreeList.Lines
            If line.Length > 0 Then
                mc = frmQueryData.CodePattern.Matches(line)
                If mc.Count > 0 Then
                    For Each m1 In mc
                        With dtQueriedAccessCodes
              Dim r As TrackerData.QueriedAccessCodeListRow = .NewQueriedAccessCodeListRow
                            r.AccLetter = m1.Groups("AccLetter").Value
                            r.AccNumber = m1.Groups("AccNumber").Value
                            If .FindByAccLetterAccNumber(r.AccLetter, r.AccNumber) Is Nothing Then
                                ' list &= "~" & m.Groups("AccLetter").Value & m.Groups("AccNumber").Value & "~" & System.Environment.NewLine
                                .Rows.Add(r)
                            End If
                            With Me.rtfFreeList
                                .Find(line)
                                .SelectionColor = Color.Black
                                .SelectionFont = New Font(.SelectionFont, FontStyle.Regular)
                                .Select(0, 0)
                            End With

                        End With

                    Next
                Else
                    badlines += 1
                    With Me.rtfFreeList
                        .Find(line)
                        .SelectionColor = Color.Red
                        .SelectionFont = New Font(.SelectionFont, FontStyle.Bold)
                        .Select(0, 0)
                    End With

                End If

            End If
        Next
        ' Save the good ones...
    TrackerApp.Tracker1.QueriedAccessCodeList.Merge(dtQueriedAccessCodes)

    Select Case badlines
      Case 0
        Return True
      Case 1
        MessageBox.Show("The red line doesn't appear to be an access code--please fix or remove it.")
        Return False
      Case Else
        MessageBox.Show("The red lines don't appear to be access codes--please fix or remove them.")
        Return False
    End Select

  End Function

  Private Sub ClearCodes()
    'For Each r As CHCR.QueriedAccessCodeListRow In TrackerApp.Tracker1.QueriedAccessCodeList
    '   r.Delete()
    'Next

    With TrackerApp.Tracker1.QueriedAccessCodeList
      For i As Integer = .Rows.Count - 1 To 0 Step -1
        .Rows(i).Delete()
      Next
    End With

  End Sub
  Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    ClearCodes()
    If ParseText() Then
      If TrackerApp.Tracker1.HasChanges Then
        Me.sdaQueriedAccessCodes.Update(TrackerApp.Tracker1.QueriedAccessCodeList)
      End If
      Me.DialogResult = Windows.Forms.DialogResult.OK
    Else
      ' do nothing?
    End If
  End Sub

  Private Sub btnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearList.Click
    ClearCodes()
    Me.rtfFreeList.Text = String.Empty
  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    TrackerApp.Tracker1.QueriedAccessCodeList.RejectChanges()
    Me.DialogResult = Windows.Forms.DialogResult.Cancel
  End Sub
End Class
