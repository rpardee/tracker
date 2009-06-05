Imports se = System.Environment
Imports sd = System.DirectoryServices

Public Class TrackerApp
  Shared Sub FlushDataGrid(ByVal dg As DataGrid)
    Dim bmb As BindingManagerBase
    Dim dgs As DataGridColumnStyle
    If dg.TableStyles.Count > 0 Then
      With dg
        dgs = .TableStyles(0).GridColumnStyles(.CurrentCell.ColumnNumber)
        .EndEdit(dgs, .CurrentCell.RowNumber, False)
        bmb = .BindingContext(.DataSource, .DataMember)
      End With
      bmb.EndCurrentEdit()
    Else
      MessageBox.Show("Problem--" & dg.CaptionText & " has no table styles!")
    End If
  End Sub

  Shared sep As String = se.NewLine & se.NewLine

  Shared Sub app_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
    Dim msg As String = "Terribly sorry--you seem to have run into an " _
             & "unanticipated error.  The error is " & sep _
             & e.Exception.Message _
             & "Please tell Roy about this error." & sep _
             & "I have to close now."
    MessageBox.Show(msg, "Yikes--Threading exception!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    If se.UserName = "pardre1" Then
      MessageBox.Show(e.Exception.ToString)
    Else
      ' Dim em As New CHCRTracker.Devnet.ExceptionMailer
      Dim em As New Tracker.ctrhs_devnet.ExceptionMailer
      em.Send(se.UserName, se.MachineName, e.Exception.ToString, "pardee.r@ghc.org", "CHCRTracker")
    End If
    Application.Exit()

  End Sub

  Public Shared Tracker1 As TrackerData
  ' These are for binding dg combos to--for some reason you should
  ' not bind a combo to the same object (dataset) to which the
  ' dg is bound.
  Public Shared ContactTypes As TrackerData.ContactTypesDataTable
  Public Shared Statuses As TrackerData.StatusesDataTable
  Public Shared PhoneNumberTypes As TrackerData.PhoneNumberTypesDataTable
  Public Shared Settings As ppSettings

  Shared frm As frmTracker
  <STAThread()> _
  Shared Sub Main(ByVal args() As String)
    ' Beep()
    ' AddHandler Application.Idle, New EventHandler(AddressOf AppIsIdle)
    AddHandler Application.ThreadException, New System.Threading.ThreadExceptionEventHandler(AddressOf app_ThreadException)
    Dim frmSplash As New frmSplash
    frmSplash.Show()
    ' Application.DoEvents()
    frm = New frmTracker
    frmSplash.Close()
    frmSplash.Dispose()
    frmSplash = Nothing
    ' frm = New frmCHCRTracker(frmSplash)
    Try
      Application.Run(frm)
    Catch e As Exception
      Dim msg As String = "Terribly sorry--you seem to have run into an " _
               & "unanticipated error.  The error is " & sep _
               & """" & e.Message & """" & sep _
               & "Please tell Roy about this error." & sep _
               & "I have to close now."
      MessageBox.Show(msg, "Yikes!", MessageBoxButtons.OK, MessageBoxIcon.Error)
      If se.UserName = "pardre1" Then
        MessageBox.Show(e.ToString)
      Else
        Dim em As New Tracker.ctrhs_devnet.ExceptionMailer
        em.Send(se.UserName, se.MachineName, e.ToString, "pardee.r@ghc.org", "CHCRTracker")
      End If
    End Try

  End Sub

  Shared Sub AppIsIdle(ByVal sender As Object, ByVal e As EventArgs)
    frm.pStatus.Text = "Idle"
    ' CHCR1.RecruitContacts.AddedDateColumn.DefaultValue = Now
  End Sub

  Shared Function GetFullName(ByVal ForUser As String) As String
    Try
      Dim usr As New sd.DirectoryEntry("LDAP://CN=" & ForUser _
                                       & ", OU=PROD" _
                                       & ", OU=GHCUsers" _
                                       & ", dc=ghcmaster" _
                                       & ", dc=ghc" _
                                       & ", dc=org")
      Return usr.Properties("GivenName")(0).ToString & " " & usr.Properties("sn")(0).ToString
    Catch e As Exception
      Return Nothing
    End Try
  End Function

  Shared Sub FillMailTo(ByVal cn As Data.SqlClient.SqlConnection _
              , ByVal LetterDate As Date _
              , ByVal Recruits As ArrayList)
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim pRID As New SqlClient.SqlParameter("@RecruitID", SqlDbType.Int)
    pRID.Direction = ParameterDirection.Input
    Dim pLetterDate As New SqlClient.SqlParameter("@LetterDate", SqlDbType.DateTime)
    pLetterDate.Direction = ParameterDirection.Input
    ' Add the time of day in order to discriminate between different sends on the same day
    Dim ts As TimeSpan = DateTime.Now.Subtract(DateTime.Today)
    pLetterDate.Value = DateTime.op_Addition(LetterDate, ts)
    Dim pStudy As New SqlClient.SqlParameter("@Study", SqlDbType.Int)
    pStudy.Direction = ParameterDirection.Input


    Try
      With cmd
        ' .Connection = Me.SqlConnection1
        .Connection = cn
        .CommandType = CommandType.StoredProcedure
        .CommandText = "ClearMailTo"
        .Parameters.Add(pStudy)
        pStudy.Value = TrackerApp.Settings.Study
        If .Connection.State <> ConnectionState.Open Then .Connection.Open()
        .ExecuteNonQuery()

        .CommandType = CommandType.Text
        .CommandText = "insert into dbo.mailto (RecruitID, Study, LetterDate) values (@RecruitID, @Study, @LetterDate)"
        .Parameters.Add(pRID)
        .Parameters.Add(pLetterDate)
        For Each r As TrackerData.RecruitsRow In Recruits
          pRID.Value = r.RecruitID
          ' pStudy.Value = r.Study
          .ExecuteNonQuery()
        Next
      End With
    Catch sex As System.Data.SqlClient.SqlException
      ' do what here?
      MessageBox.Show("Problem at the server:" & se.NewLine & se.NewLine & sex.Message)
      Dim x As New Tracker.ctrhs_devnet.ExceptionMailer
      x.Send(se.UserName, se.MachineName, sex.ToString, "pardee.r@ghc.org", "CHCRTracker")
    Finally
      If cn.State <> ConnectionState.Closed Then
        cn.Close()
      End If
    End Try
  End Sub

End Class
