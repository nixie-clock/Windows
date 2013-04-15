Module Core

    Public Declare Function EmptyWorkingSet Lib "psapi.dll" (ByVal hProcess As Integer) As Integer
    Public images() As Bitmap = {My.Resources.t0, My.Resources.t1, My.Resources.t2, My.Resources.t3, My.Resources.t4, My.Resources.t5, My.Resources.t6, My.Resources.t7, My.Resources.t8, My.Resources.t9}
    Public arraylen As Integer, converted() As Integer, i As Integer, base As Integer
    Public allsounds As Boolean, centered As Boolean
End Module
