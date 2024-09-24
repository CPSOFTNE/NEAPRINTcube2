Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports NTSInformatica.CLE__APP
Public Class CLFVEBOLL
  Inherits CLEVEBOLL
  Public oCldhh As CLDVEBOLL
  Dim strErr As String = ""
  Dim oTmp As Object = Nothing
  Public OMenu As Object
  Dim drxxx As DataRow
  Dim dtCommesseDaEl As New DataTable

  Public Sub AssociaDs(ByRef ds As DataSet)
TRY
    DSShared = ds
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
    If MyBase.strNomeDal = "BD__BASE" Then MyBase.strNomeDal = "BDVEBOLL"

    MyBase.Init(App, oScriptEngine, oCleLbmenu, strTabella, False, "", "")
    oCldhh = CType(MyBase.ocldBase, CLDVEBOLL)
    oCldhh.Init(oApp)

    If CLN__STD.NTSIstanziaDll(oApp.ServerDir, oApp.NetDir, "BEVEBOLL", "BEVEBOLL", oTmp, strErr, False, "", "") = False Then
      Throw New NTSException(oApp.Tr(Me, 128607611686875000, "ERRORE in fase di creazione Entity:" & vbCrLf & "|" & strErr & "|"))
      Return False
    End If
    dtCommesseDaEl.Columns.Add("hh_commessa", GetType(Integer))

    Return True
  End Function
  Public Overrides Function BeforeColUpdate_CORPO_ec_codart(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) As Boolean
TRY
    Dim args2 As NTSEventArgs
    Dim intCommessa As Integer
    If IsNumeric(e.ProposedValue.ToString) Then
      'If CDbl(e.ProposedValue.ToString) = CLng(e.ProposedValue.ToString) Then
      'e.ProposedValue = CLng(e.ProposedValue.ToString)
      If CType(oCldBoll, CLHVEBOLL).CPNECtrlCommessa(CInt(e.ProposedValue.ToString)) Then
        intCommessa = CInt(e.ProposedValue.ToString)
        args2 = New NTSEventArgs("CPNE.SelezionaOrdini", "R#" & intCommessa.ToString)
        Me.ThrowRemoteEvent(args2)
        args2 = New NTSEventArgs("CPNE.RecordRipristina", "")
        Me.ThrowRemoteEvent(args2)
        If dttEC.Rows(dttEC.Rows.Count - 1)!ec_codart.ToString = e.ProposedValue.ToString Or Trim(dttEC.Rows(dttEC.Rows.Count - 1)!ec_codart.ToString) = "" Then
          BeforeColUpdate_CORPO_ec_codart = MyBase.BeforeColUpdate_CORPO_ec_codart(sender, e)
        Else
          Return True
        End If
      Else
        BeforeColUpdate_CORPO_ec_codart = MyBase.BeforeColUpdate_CORPO_ec_codart(sender, e)
      End If
      'Else
      '  BeforeColUpdate_CORPO_ec_codart = MyBase.BeforeColUpdate_CORPO_ec_codart(sender, e)
      'End If
    Else
      BeforeColUpdate_CORPO_ec_codart = MyBase.BeforeColUpdate_CORPO_ec_codart(sender, e)
    End If


Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function
  Public Overrides Function ApriDoc(strDitta As String, bNew As Boolean, strTipoDoc As String, nAnno As Integer, strSerie As String, lNumdoc As Integer, ByRef ds As System.Data.DataSet) As Boolean
TRY

    ApriDoc = MyBase.ApriDoc(strDitta, bNew, strTipoDoc, nAnno, strSerie, lNumdoc, ds)
    dtCommesseDaEl.Clear()
    For i = 0 To dttEC.Rows.Count - 1
      Dim dr As DataRow = dttEC.Rows(i)
      If dtCommesseDaEl.Select("hh_commessa = " & dr!ec_commeca.ToString).Length = 0 And CInt(dr!ec_commeca) <> 0 Then
        dtCommesseDaEl.Rows.Add()
        dtCommesseDaEl.Rows(dtCommesseDaEl.Rows.Count - 1)!hh_commessa = dr!ec_commeca
      End If
    Next
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function
  Public Overrides Function SalvaDocumento(strState As String) As Boolean
TRY
    SalvaDocumento = MyBase.SalvaDocumento(strState)
    If SalvaDocumento Then
      If strState <> "D" Then
        For i = 0 To dttEC.Rows.Count - 1
          Dim dr As DataRow = dttEC.Rows(i)
          If dtCommesseDaEl.Select("hh_commessa = " & dr!ec_commeca.ToString).Length = 0 And CInt(dr!ec_commeca) <> 0 Then
            dtCommesseDaEl.Rows.Add()
            dtCommesseDaEl.Rows(dtCommesseDaEl.Rows.Count - 1)!hh_commessa = dr!ec_commeca
          End If
        Next
      End If
      For i = 0 To dtCommesseDaEl.Rows.Count - 1
        Dim drCommesseDaEl As DataRow = dtCommesseDaEl.Rows(i)
        Dim dtORd As DataTable = CType(oCldBoll, CLHVEBOLL).CPNERigheCommDaEva(CInt(drCommesseDaEl!hh_commessa), strDittaCorrente)
        Dim StrTmp As String = ""
        Dim DtCommess As New DataTable
        oCldBoll.ValCodiceDb(drCommesseDaEl!hh_commessa.ToString, strDittaCorrente, "commess", "N", StrTmp, DtCommess)
        If dtORd.Rows.Count = 0 Then
          DtCommess.Rows(0).Item("hh_evasofl") = "S"
        Else
          DtCommess.Rows(0)!hh_evasofl = "N"
        End If
        oCldBoll.ScriviTabellaSemplice(strDittaCorrente, "COMMESS", DtCommess, "", "", "")
      Next
    End If
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function
End Class
