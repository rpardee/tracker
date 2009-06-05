Imports se = System.Environment

Interface DataboundForm
  Function EndPendingEdits() As Boolean
  ReadOnly Property CurrentRecruitID() As Integer
End Interface

Public Enum Studies
  ProjectQuit
  ProjectTwo
  ProjectThree
End Enum
Public Enum SQLServers
  Development = 0
  DevNet = 1
  Production = 2
End Enum
<Serializable(), Xml.Serialization.XmlRoot()> _
Public Class ppSettings
    ' Const SettingsFileName As String = "AppSettings.xml"
    Const SettingsFileName As String = "AppSettings.bin"
    ' FormatterAssemblyStyle.Simple
    <NonSerialized()> _
    Dim Formatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
    ' Public Study As Studies = Studies.ProjectQuit
    Public Study As Integer
    Public Server As SQLServers = SQLServers.Production
    Public SexIs As String
    Public AccLetter As String
    Public AccNumber As String
    Public Status As String
    Public StatusType As String
    Public FirstNameLike As String
    Public LastNameLike As String
    Public ProgVersion As String
    Public BirthDate As String
    Public MaxRecs As String
    Public ContactDate As String
    Public GetUpdatedAddresses As Boolean
    Public GetReminderEligibles As Boolean
    Public UseQueriedNameList As Boolean
    Public UseQueriedAccessCodeList As Boolean
    Public LastDetailTabPage As Integer
    Public TicklerToBeDone As String

    Public Sub New()
        MyBase.new()
        Formatter.AssemblyFormat = Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
    End Sub
    Public Sub Save()
        Dim fs As New System.IO.IsolatedStorage.IsolatedStorageFileStream(SettingsFileName, IO.FileMode.Create)
        'Dim x As New Xml.Serialization.XmlSerializer(Me.GetType)
        'x.Serialize(fs, Me)
        Formatter.Serialize(fs, Me)
        fs.Flush()
        fs.Close()
    End Sub
    Public Sub Load()
        Try
            ' Beep()
            Dim fs As New System.IO.IsolatedStorage.IsolatedStorageFileStream(SettingsFileName, IO.FileMode.OpenOrCreate)
            If fs.Length > 0 Then
                Dim m As ppSettings
                'Dim x As New Xml.Serialization.XmlSerializer(Me.GetType)
                'm = CType(x.Deserialize(fs), CHCRAppSettings)
                m = CType(Formatter.Deserialize(fs), ppSettings)
                fs.Close()
                Me.Study = m.Study
                Me.Server = m.Server
                Me.SexIs = m.SexIs
                Me.AccLetter = m.AccLetter
                Me.AccNumber = m.AccNumber
                Me.Status = m.Status
                Me.StatusType = m.StatusType
                Me.FirstNameLike = m.FirstNameLike
                Me.LastNameLike = m.LastNameLike
                Me.ProgVersion = m.ProgVersion
                Me.BirthDate = m.BirthDate
                Me.MaxRecs = m.MaxRecs
                Me.ContactDate = m.ContactDate
                Me.GetUpdatedAddresses = m.GetUpdatedAddresses
                Me.GetReminderEligibles = m.GetReminderEligibles
                Me.UseQueriedNameList = m.UseQueriedNameList
                Me.UseQueriedAccessCodeList = m.UseQueriedAccessCodeList
                Me.LastDetailTabPage = m.LastDetailTabPage
                Me.TicklerToBeDone = m.TicklerToBeDone
            Else
                Dim ar As New System.Configuration.AppSettingsReader
                Dim s As SQLServers = CType(ar.GetValue("ServerCode", GetType(Integer)), SQLServers)
                Me.Server = s
            End If
            fs.Close()
        Catch ex As System.IO.IOException
            MessageBox.Show("Problem loading previous settings" & se.NewLine & ex.Message _
                  & se.NewLine & "Going without...", "IO Exception")
        Catch rex As Exception
            MessageBox.Show("Problem loading previous settings" & se.NewLine & rex.Message _
                  & se.NewLine & "Going without...", "Plain Old Exception")
        End Try
    End Sub

    Public Function ConnectStringFromServerEnum() As String
        ' workstation id=MLT15T;packet size=4096;integrated security=SSPI;data source="ctrhs-dbserver";persist security info=False;initial catalog=CHCR
        ' TODO: Find out how to shorten the timeout value.
        Dim s As String = "packet size=4096;" _
                    & "integrated security=SSPI;" _
                    & "persist security info=False;"
        Select Case Server
            Case SQLServers.Development
                s &= "initial catalog=CHCR;data source='MLT15T\LOPLOP'"
            Case SQLServers.Production
                s &= "initial catalog=CHCR;data source='ctrhs-dbserver'"
            Case SQLServers.DevNet
                s &= "initial catalog=PretendCHCR;data source = 'ctrhs-devnet'"
            Case Else
                Throw New ArgumentException("Connection string not defined for server """ & Server.ToString & """")
        End Select
        Return s
    End Function
End Class