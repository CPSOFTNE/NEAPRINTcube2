Imports NTSInformatica.CLN__STD
Imports System.Data.Common
Imports NTSInformatica
Imports System.IO
Imports System
Imports NTSInformatica.CLE__APP
Public Class CLDHHTABE
  Inherits CLD__BASE

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
  Public Sub CPNECaricaTabFirme(ByRef ds As DataSet, ByVal strDittaCorrente As String)
    Dim strSql As String = ""
    Try

      strSql = "SELECT codditt, tb_codhhFir as xx_codice, tb_deshhFir as xx_descr, tb_deshhUff"
      strSql += " FROM tabhhFir"
      strSql += " where codditt = " & CStrSQL(strDittaCorrente)
      strSql += " ORDER BY tb_codhhFir"
      OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI, "XXX", ds)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
  Public Sub CPNECaricaTabPostille(ByRef ds As DataSet, ByVal strDittaCorrente As String)
    Dim strSql As String
    Try

      strSql = "SELECT codditt, tb_codhhPos as xx_codice, tb_deshhPos as xx_descr"
      strSql += " FROM tabhhPos"
      strSql += " where codditt = " & CStrSQL(strDittaCorrente)
      strSql += " ORDER BY tb_codhhPos"
      OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI, "XXX", ds)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
  Public Sub CPNECaricaTabPreamboli(ByRef ds As DataSet, ByVal strDittaCorrente As String)
    Dim strSql As String
    Try

      strSql = "SELECT codditt, tb_codhhpre as xx_codice, tb_deshhPre as xx_descr"
      strSql += " FROM tabhhpre"
      strSql += " where codditt = " & CStrSQL(strDittaCorrente)
      strSql += " ORDER BY tb_codhhpre"
      OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI, "XXX", ds)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
  Public Sub CPNECaricaTabUM(ByRef ds As DataSet, ByVal strDittaCorrente As String)
    Dim strSql As String
    Try

      strSql = "SELECT codditt, tb_codhhUNMI as xx_codice, tb_deshhunmi as xx_descr"
      strSql += " FROM tabhhUNMIs"
      strSql += " where codditt = " & CStrSQL(strDittaCorrente)
      strSql += " ORDER BY tb_codhhUNMI"
      OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI, "XXX", ds)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
  Public Sub CPNECancellaTabella(ByVal strNomeTabella As String)
    Dim strSql As String = ""
    Try

      strSql = "DELETE from " & strNomeTabella
      Execute(strSql, DBTIPO.DBAZI)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
  Public Sub CPNEAggionraTabella(ByVal strNomeTabella As String, ByVal strDittaCorrente As String, ByVal dr As DataRow)
    Dim strSql As String = ""

    Try

      Select Case strNomeTabella
        Case "tabhhfir"
          strSql = "INSERT INTO tabhhfir"
          strSql += " ( codditt , tb_codhhFir , tb_deshhFir , tb_deshhUff )"
          strSql += " VALUES( " & CStrSQL(strDittaCorrente) & ", " & dr!xx_codice.ToString & ", " & CStrSQL(dr!xx_descr.ToString) & ", " & CStrSQL(dr!tb_deshhUff.ToString) & " )"
        Case "tabhhpos"
          strSql = "INSERT INTO tabhhpos"
          strSql += " ( codditt , tb_codhhPos , tb_deshhPos )"
          strSql += " VALUES( " & CStrSQL(strDittaCorrente) & ", " & dr!xx_codice.ToString & ", " & CStrSQL(dr!xx_descr.ToString) & " )"
        Case "tabhhpre"
          strSql = "INSERT INTO tabhhpre"
          strSql += " ( codditt , tb_codhhpre , tb_deshhPre )"
          strSql += " VALUES( " & CStrSQL(strDittaCorrente) & ", " & dr!xx_codice.ToString & ", " & CStrSQL(dr!xx_descr.ToString) & " )"
        Case "tabhhunmis"
          strSql = "INSERT INTO tabhhunmis"
          strSql += " ( codditt , tb_codhhUNMI , tb_deshhunmi )"
          strSql += " VALUES( " & CStrSQL(strDittaCorrente) & ", " & CStrSQL(dr!xx_codice.ToString) & ", " & CStrSQL(dr!xx_descr.ToString) & " )"
      End Select

      Execute(strSql, DBTIPO.DBAZI)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
End Class
