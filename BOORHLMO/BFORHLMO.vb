Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports NTSInformatica.CLE__APP
Public Class CLFORHLMO
  Inherits CLEORHLMO
  Public oCldhh As CLDORHLMO
  Dim strErr As String = ""
  Dim oTmp As Object = Nothing
  Public OMenu As Object
  Dim drxxx As DataRow

  Public Sub AssociaDs(ByRef ds As DataSet)
TRY
    dsShared = ds
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Overrides Function Init(ByRef App As CLE__APP, _
                           ByRef oScriptEngine As INT__SCRIPT, ByRef oCleLbmenu As Object, ByVal strTabella As String, _
                           ByVal bFiller1 As Boolean, ByVal strFiller1 As String, _
                           ByVal strFiller2 As String) As Boolean

    Return MyBase.Init(App, oScriptEngine, oCleLbmenu, strTabella, False, "", "")

  End Function


End Class
