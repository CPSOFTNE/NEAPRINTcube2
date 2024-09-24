Imports NTSInformatica.CLN__STD
Imports System.Data.Common
Imports NTSInformatica
Imports System.IO
Imports System
Imports NTSInformatica.CLE__APP
Public Class CLDHHAVCO
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
  Public Sub CPNELeggiCommesse(ByRef ds As DataSet, ditta As String, IntConto As Integer, IntCommessa As Integer, DataCons As Date)
    Dim StrSql As String = ""
    Dim datecmp As Integer
    Try

      StrSql = "select commess.* FROM commess INNER JOIN testord ON (commess.co_numord = testord.td_numord) AND (commess.co_serie = testord.td_serie) AND (commess.co_anno = testord.td_anno) AND (commess.co_tipork = testord.td_tipork) AND (commess.codditt = testord.codditt) "
      StrSql += " where commess.codditt = " & CStrSQL(ditta)

      'If IntConto = 0 And IntCommessa = 0 Then
      '  StrSql += " and co_conto = -999"
      'Else
      '  If IntConto <> 0 Then
      '    StrSql += " and td_conto = " & IntConto.ToString
      '  End If
      '  If IntCommessa <> 0 Then
      '    StrSql += " and co_comme = " & IntCommessa.ToString
      '  End If
      'End If

      datecmp = DateTime.Compare(DataCons, #1/1/1900#)

      If IntConto = 0 And IntCommessa = 0 Then
        StrSql += " and co_conto = -999"
      Else
        If IntConto <> 0 Then
          StrSql += " and td_conto = " & IntConto.ToString
        End If
        If IntCommessa <> 0 Then
          StrSql += " and co_comme = " & IntCommessa.ToString
        End If
      End If
      If datecmp <> 0 Then
        StrSql += " and td_datcons >= " & CDataSQL(DataCons) 'DataCons.ToString("dd/MM/yyyy") & ") "'
      End If

      CPNEPulisciDs(ds, "Commesse")
      ds = OpenRecordset(StrSql, DBTIPO.DBAZI, "Commesse", ds)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
End Class
