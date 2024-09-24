Imports NTSInformatica.CLN__STD
Imports System.Data.Common
Imports NTSInformatica
Imports System.IO
Imports System
Imports NTSInformatica.CLE__APP
Public Class CLHORHLMO
  Inherits CLDORHLMO
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
  Public Function CPNEControllaSeFiniti(ByVal drMOVORD As DataRow) As Boolean

    Dim strSql As String = ""
    Try

      Dim dttmp As New DataTable
      strSql = "SELECT *"
      strSql += " FROM movord"
      strSql += " where mo_tipork = 'H' and mo_codart = " & CStrSQL(drMOVORD!mo_codart.ToString) & " and mo_commeca = " & drMOVORD!mo_commeca.ToString
      dttmp = OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI)
      If dttmp.Rows.Count <= 0 Then Return True

      strSql = "SELECT *"
      strSql += " FROM cpproduzione"
      strSql += " where pr_tiporkOP = " & CStrSQL(dttmp.Rows(0)!mo_tipork.ToString) & " and pr_annoOP = " & dttmp.Rows(0)!mo_anno.ToString & " and pr_SerieOP = " & CStrSQL(dttmp.Rows(0)!mo_serie.ToString) & " and pr_numordOP = " & dttmp.Rows(0)!mo_numord.ToString & " and pr_RigaOP = " & dttmp.Rows(0)!mo_riga.ToString
      dttmp = OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI)
      If dttmp.Rows.Count <= 0 Then
        Return True
      Else
        If dttmp.Rows(0)!pr_FineFine.ToString = "S" Then Return True
      End If
      Return False
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Function
End Class
