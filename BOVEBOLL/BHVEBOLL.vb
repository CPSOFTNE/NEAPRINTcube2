Imports NTSInformatica.CLN__STD
Imports System.Data.Common
Imports NTSInformatica
Imports System.IO
Imports System
Imports NTSInformatica.CLE__APP
Public Class CLHVEBOLL
  Inherits CLDVEBOLL

  Public Sub CPNEPulisciDs(ByRef ds As DataSet, ByVal StrNomeTab As String)
    Dim str As String = StrNomeTab
    Try
      If ds.Tables.Contains(StrNomeTab) Then
        ds.Tables(StrNomeTab).Clear()
        ds.Tables.Remove(StrNomeTab)
      End If
    Catch ex As Exception
      '--------------------------------------------------------------
      Throw (New NTSException(GestError(ex, Me, str, oApp.InfoError, "", False)))
      '--------------------------------------------------------------
    End Try
  End Sub
  Public Function CPNECtrlCommessa(ByVal intCommessa As Integer) As Boolean
    Dim StrSql As String = ""
    Dim dtTmp As DataTable
    Try

      StrSql = "SELECT *"
      StrSql += " FROM commess"
      StrSql += " WHERE co_comme=" & intCommessa
      dtTmp = OpenRecordset(StrSql, CLE__APP.DBTIPO.DBAZI)
      If dtTmp.Rows.Count > 0 Then
        Return True
      Else
        Return False
      End If
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Function

  Public Function CPNERigheCommDaEva(Intocmmessa As Integer, Ditta As String) As DataTable
    Dim STrSql As String = ""
    Try
      STrSql = "SELECT mo_commeca FROM movord WHERE mo_tipork = " & CStrSQL("R") & " AND mo_commeca = " & CDblSQL(Intocmmessa) & " AND mo_flevas = 'C' and codditt = " & CStrSQL(Ditta)
      Return OpenRecordset(STrSql, DBTIPO.DBAZI)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Function
End Class
