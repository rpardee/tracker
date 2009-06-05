Public Class frmLimitPersonTypes
    Dim frmQ As frmQueryData

    Public WriteOnly Property ToBeDone() As String

        Set(ByVal value As String)
            Dim f As String = ""
            If value.Length > 0 Then
                f = "ToBeDone = '" & value & "'"
                Me.DataGridView1.Columns(0).Visible = False
            Else
                Me.DataGridView1.Columns(0).Visible = True
            End If
            Me.TodobytypecountsvwBindingSource.Filter = f
        End Set
    End Property

    Private Sub frmLimitPersonTypes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmQ = CType(Me.Owner, frmQueryData)
        'TODO: This line of code loads data into the 'CHCR.todo_by_type_counts_vw' table. You can move, or remove it, as needed.
        With Me.Todo_by_type_counts_vwTableAdapter
            ' Could not find a way to up the timeout period on this guy. :-(
      .Fill(Me.Tracker.todo_by_type_counts_vw)
        End With
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        If TypeOf e.Exception Is System.FormatException Then
            MessageBox.Show("I'm looking for a number here--please try again.")
            e.Cancel = True
        End If
    End Sub

    Private Sub DataGridView1_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        If e.ColumnIndex = 3 AndAlso e.FormattedValue.ToString.Length > 0 Then
            Dim dgv As DataGridView
            Dim have, want As Integer
            dgv = CType(sender, DataGridView)
            have = CType(dgv.CurrentRow.Cells("NumDataGridViewTextBoxColumn").Value, Integer)
            want = CType(e.FormattedValue, Integer)
            If want > have Then
                ' dgv.Rows(e.RowIndex).ErrorText = "You can't have " & want.ToString & " people--there are only " & have.ToString & " available.  Please choose a lower number."
                MessageBox.Show("You can't have " & want.ToString & " people--there are only " & have.ToString & " available.  Please choose a lower number.")
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        frmQ.chkLimitPersonTypes.Checked = False
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

  Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    Dim r As TrackerData.todo_by_type_counts_vwRow
    frmQ.chkLimitPersonTypes.Checked = True
    For Each drv As DataRowView In Me.TodobytypecountsvwBindingSource.List
      r = CType(drv.Row, TrackerData.todo_by_type_counts_vwRow)
      Select Case r.persontype
        Case "IGP"
          frmQ.NumIGP = r.Wanted
        Case "Network"
          frmQ.NumNetwork = r.Wanted
        Case "NetSmok"
          frmQ.NumNetSmok = r.Wanted
        Case "Generic"
          ' do nothing...
        Case Else
          Throw New Exception("Unexpected value of 'persontype'--'" & r.persontype & "'--freaking out!")
      End Select
    Next
    Me.ToBeDone = ""
    Me.DialogResult = Windows.Forms.DialogResult.OK
  End Sub
End Class