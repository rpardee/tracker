Public Structure Tab : Implements IComparable
   Public sda As System.Data.SqlClient.SqlDataAdapter
   Public t As System.Data.DataTable
   Public Order As Byte

   Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
      Dim other As Tab = CType(obj, Tab)
      If Me.Order > other.Order Then
         Return 1
      End If
      If Me.Order = other.Order Then
         Return 0
      End If
      Return -1
   End Function
End Structure

