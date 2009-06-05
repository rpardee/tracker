Imports wf = System.Windows.Forms

Public Class frmQueriedNames
   Inherits System.Windows.Forms.Form
   Private cn As SqlClient.SqlConnection
  Private FullNames As TrackerData.FullNamesDataTable = TrackerApp.tracker1.FullNames
   Private sqlRetrieve As New SqlClient.SqlCommand("select f.FullName, f.RecruitID, f.AccCode " _
                                 & "from FullNames_vw as f INNER JOIN " _
                                 & "QueriedNames as n " _
                                 & "on f.RecruitID = n.RecruitID " _
                                 & "where n.AddedBy = USER ", cn)
   Private sqlCreate As SqlClient.SqlCommand
   Private sqlUpdate As SqlClient.SqlCommand
   Private sqlDelete As SqlClient.SqlCommand
   Private sda As New SqlClient.SqlDataAdapter(sqlRetrieve)

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
   Friend WithEvents dg As System.Windows.Forms.DataGrid
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents dgtsFullNames As System.Windows.Forms.DataGridTableStyle
   Friend WithEvents tbcFullName As System.Windows.Forms.DataGridTextBoxColumn
   Friend WithEvents btnFindRecruitIDs As System.Windows.Forms.Button
   Friend WithEvents tbcAccCode As System.Windows.Forms.DataGridTextBoxColumn
   Friend WithEvents btnClearList As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.dg = New System.Windows.Forms.DataGrid
      Me.dgtsFullNames = New System.Windows.Forms.DataGridTableStyle
      Me.tbcFullName = New System.Windows.Forms.DataGridTextBoxColumn
      Me.tbcAccCode = New System.Windows.Forms.DataGridTextBoxColumn
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnFindRecruitIDs = New System.Windows.Forms.Button
      Me.btnClearList = New System.Windows.Forms.Button
      CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'dg
      '
      Me.dg.AllowNavigation = False
      Me.dg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dg.DataMember = ""
      Me.dg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.dg.Location = New System.Drawing.Point(11, 10)
      Me.dg.Name = "dg"
      Me.dg.Size = New System.Drawing.Size(650, 370)
      Me.dg.TabIndex = 0
      Me.dg.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgtsFullNames})
      '
      'dgtsFullNames
      '
      Me.dgtsFullNames.DataGrid = Me.dg
      Me.dgtsFullNames.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.tbcFullName, Me.tbcAccCode})
      Me.dgtsFullNames.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.dgtsFullNames.MappingName = "FullNames"
      '
      'tbcFullName
      '
      Me.tbcFullName.Format = ""
      Me.tbcFullName.FormatInfo = Nothing
      Me.tbcFullName.HeaderText = "Name"
      Me.tbcFullName.MappingName = "FullName"
      Me.tbcFullName.NullText = ""
      Me.tbcFullName.Width = 250
      '
      'tbcAccCode
      '
      Me.tbcAccCode.Format = ""
      Me.tbcAccCode.FormatInfo = Nothing
      Me.tbcAccCode.HeaderText = "Access Code"
      Me.tbcAccCode.MappingName = "AccCode"
      Me.tbcAccCode.ReadOnly = True
      Me.tbcAccCode.Width = 150
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCancel.Location = New System.Drawing.Point(11, 420)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(100, 29)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "&Cancel"
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnOK.Location = New System.Drawing.Point(672, 420)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(100, 29)
      Me.btnOK.TabIndex = 2
      Me.btnOK.Text = "&OK"
      '
      'btnFindRecruitIDs
      '
      Me.btnFindRecruitIDs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnFindRecruitIDs.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnFindRecruitIDs.Location = New System.Drawing.Point(672, 351)
      Me.btnFindRecruitIDs.Name = "btnFindRecruitIDs"
      Me.btnFindRecruitIDs.Size = New System.Drawing.Size(100, 29)
      Me.btnFindRecruitIDs.TabIndex = 3
      Me.btnFindRecruitIDs.Text = "Find"
      '
      'btnClearList
      '
      Me.btnClearList.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnClearList.Location = New System.Drawing.Point(672, 10)
      Me.btnClearList.Name = "btnClearList"
      Me.btnClearList.Size = New System.Drawing.Size(100, 29)
      Me.btnClearList.TabIndex = 4
      Me.btnClearList.Text = "Clear List"
      '
      'frmQueriedNames
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(8, 20)
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(778, 462)
      Me.ControlBox = False
      Me.Controls.Add(Me.btnClearList)
      Me.Controls.Add(Me.btnFindRecruitIDs)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.dg)
      Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "frmQueriedNames"
      Me.ShowInTaskbar = False
      Me.Text = "List Names"
      CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub SetUpCommands()
      Dim prm As SqlClient.SqlParameter
      sqlCreate = New SqlClient.SqlCommand
      With sqlCreate
         .Connection = cn
         .CommandText = "insert into dbo.QueriedNames (RecruitID) values (@RecruitID)"
         prm = New SqlClient.SqlParameter("@RecruitID", SqlDbType.Int)
         prm.SourceColumn = "RecruitID"
         prm.SourceVersion = DataRowVersion.Current
         .Parameters.Add(prm)
      End With
      sqlUpdate = New SqlClient.SqlCommand
      With sqlUpdate
         .Connection = cn
         .CommandText = "update QueriedNames " _
                  & "set RecruitID = @NewRecruitID " _
                  & "where RecruitID = @OldRecruitID AND " _
                  & "      AddedBy = USER"
         prm = New SqlClient.SqlParameter("@NewRecruitID", SqlDbType.Int)
         prm.SourceColumn = "RecruitID"
         prm.SourceVersion = DataRowVersion.Proposed
         .Parameters.Add(prm)

         prm = New SqlClient.SqlParameter("@OldRecruitID", SqlDbType.Int)
         prm.SourceColumn = "RecruitID"
         prm.SourceVersion = DataRowVersion.Original
         .Parameters.Add(prm)
      End With
      sqlDelete = New SqlClient.SqlCommand
      With sqlDelete
         .Connection = cn
         .CommandText = "delete from QueriedNames " _
                     & "where RecruitID = @RecruitID AND " _
                     & "AddedBy = USER"
         prm = New SqlClient.SqlParameter("@RecruitID", SqlDbType.Int)
         prm.SourceColumn = "RecruitID"
         prm.SourceVersion = DataRowVersion.Original
         .Parameters.Add(prm)
      End With
      With sda
         .InsertCommand = sqlCreate
         .DeleteCommand = sqlDelete
         .UpdateCommand = sqlUpdate
      End With
   End Sub

   Private Sub frmQueriedAccessCodeList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cn = CType(Me.Owner.Owner, frmTracker).SqlConnection1
      If FullNames.Count = 0 Then
         RefreshData()
      End If
      ' FullNames.DefaultView.Sort = "FullName"
      With Me.dg
      '.DataSource = TrackerApp.Tracker1
         '.DataMember = "FullNames"
         .DataSource = FullNames
      End With
   End Sub

   Private Sub RefreshData()

      With FullNames
         If .Count > 0 Then
            .Clear()
         End If
      End With

      Try
         sqlRetrieve.Connection = cn
         sda.Fill(FullNames)
      Catch e As Exception
         MessageBox.Show(e.ToString)
      End Try
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    If TrackerApp.Tracker1.HasChanges Then
      ' check if anybody needs finding--if so, try to find them.
      FindNames()
    End If
      ' check if anybody has an error--if so, refuse to close
      If FullNames.HasErrors Then
         MessageBox.Show("Please delete or correct the names that were not found.", "Can't continue", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
         ' insert recruitids into QueriedNames
         If WriteRecruitIDs() Then
            Me.DialogResult = wf.DialogResult.OK
         End If
      End If
   End Sub

   Private Sub FrmClosing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    If TrackerApp.Tracker1.HasChanges Then
      If MessageBox.Show("Save your changes to the list of names?", "List changed!", MessageBoxButtons.YesNo) = wf.DialogResult.Yes Then
        If WriteRecruitIDs() Then
          ' do nothing
        Else
          e.Cancel = True
        End If
      Else
        FullNames.RejectChanges()
      End If
    End If
   End Sub

   Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
      FullNames.RejectChanges()
      Me.Close()
   End Sub

   Private Function WriteRecruitIDs() As Boolean
      Dim ret As Boolean
      'Dim cmd As New SqlClient.SqlCommand("delete from QueriedNames where AddedBy = USER", cn)
      Try
         cn.Open()
         SetUpCommands()
         sda.Update(FullNames)
         ret = True
      Catch ex As Exception
         MessageBox.Show(ex.ToString)
         ret = False
      Finally
         If cn.State = ConnectionState.Open Then cn.Close()
      End Try
      Return ret
   End Function

   Private Sub btnFindRecruitIDs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindRecruitIDs.Click
      FindNames()
   End Sub

   Private Sub FindNames()
      Dim Newbies As New DataView(FullNames)
      Newbies.RowStateFilter = DataViewRowState.ModifiedCurrent
      FindNames(Newbies)
      Newbies.RowFilter = "IsNull(RecruitID, -1) = -1"
      Newbies.RowStateFilter = DataViewRowState.CurrentRows
      FindNames(Newbies)

   End Sub

   Private Sub FindNames(ByVal dv As DataView)
      ' Find each name in the view FullNames_vw and retrieve the RecruitID if possible
      If dv.Count > 0 Then
         Dim cmd As New SqlClient.SqlCommand("select recruitid, AccCode " _
                                             & "from fullnames_vw " _
                                             & "where FullName = @ThisName AND " _
                                             & "      Study = @Study", cn)
         Dim prmThisName As New SqlClient.SqlParameter("@ThisName", SqlDbType.VarChar)
         cmd.Parameters.Add(prmThisName)
         Dim prmStudy As New SqlClient.SqlParameter("@Study", SqlDbType.Int)
         cmd.Parameters.Add(prmStudy)
      Dim n As TrackerData.FullNamesRow = Nothing
      Dim newname As TrackerData.FullNamesRow = Nothing
         ' Dim RecruitID As Object
         Try
            With FullNames
               Console.WriteLine("Searching for " & dv.Count.ToString & " rows")
               cn.Open()
          ' For Each n As TrackerData.FullNamesRow In .Rows
               For Each drv As DataRowView In dv
            n = CType(drv.Row, TrackerData.FullNamesRow)
                  prmThisName.Value = n.FullName
                  Dim dr As SqlClient.SqlDataReader
                  dr = cmd.ExecuteReader
                  If dr.HasRows Then
                     While dr.Read
                        Dim rid As Integer = dr.GetInt32(0)
                        Dim acc As String = dr.GetString(1)
                        If FullNames.Select("RecruitID = " & rid.ToString).Length > 0 Then
                           ' This RecruitID was already found--do nothing
                           ' (But what about a case where two pre-existing recs 
                           ' had their names swapped by the user?  Ignore this for now).
                           n.Delete()
                        Else
                           ' We have a new RecruitID--either edit the current record or,
                           ' if this is a subsequent record for a name that appears > 1
                           ' time in the db, add a new row to the datatable.
                           If n.IsRecruitIDNull Then
                              n.RecruitID = rid
                              n.AccCode = acc
                              n.RowError = ""
                           Else
                              newname = FullNames.NewFullNamesRow
                              With newname
                                 .FullName = n.FullName
                                 .RecruitID = rid
                                 .AccCode = acc
                              End With
                              FullNames.Rows.Add(newname)
                              MessageBox.Show("There is more than one """ & n.FullName & """ in the database--I'll add them all.  You will have to delete the ones you don't want, on the basis of their Access Code.", "Which """ & n.FullName & """ do you want?", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                           End If

                        End If
                     End While
                  Else
                     n.RowError = "This name was not found in the database"
                  End If
                  dr.Close()
               Next
               ' .AcceptChanges()
            End With
         Catch cex As System.Data.ConstraintException
            Console.WriteLine(cex.Message)
            Console.WriteLine(cex.ToString)
            If cex.Message.IndexOf("AccCode") > 0 Then
               If Not newname Is Nothing Then
                  ' newname was the rwo that threw the error--kill it
                  FullNames.Rows.Remove(newname)
               Else
                  ' It was n--kill that
                  FullNames.Rows.Remove(n)
               End If
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString)
         Finally
            If cn.State = ConnectionState.Open Then cn.Close()
         End Try
      End If
   End Sub

    Private Sub btnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearList.Click
        For i As Integer = (FullNames.Rows.Count - 1) To 0 Step -1
            FullNames.Rows(i).Delete()
        Next i
    End Sub
End Class
