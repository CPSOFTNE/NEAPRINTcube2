Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports NTSInformatica.CLE__APP
Public Class CLEHHTABE
  Inherits CLE__BASE
  Public oCldhh As CLDHHTABE
  Dim strErr As String = ""
  Dim oTmp As Object = Nothing
  Public OMenu As Object
  Dim drxxx As DataRow
  Public CPNEstrZoomTipoTab As String
  Public CPNEintRigaCorrente As Integer

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
    If MyBase.strNomeDal = "BD__BASE" Then MyBase.strNomeDal = "BDHHTABE"

    MyBase.Init(App, oScriptEngine, oCleLbmenu, strTabella, False, "", "")
    oCldhh = CType(MyBase.ocldBase, CLDHHTABE)
    oCldhh.Init(oApp)



    If CLN__STD.NTSIstanziaDll(oApp.ServerDir, oApp.NetDir, "BEHHTABE", "BEHHTABE", oTmp, strErr, False, "", "") = False Then
      Throw New NTSException(oApp.Tr(Me, 128607611686875000, "ERRORE in fase di creazione Entity:" & vbCrLf & "|" & strErr & "|"))
      Return False
    End If

    DSShared.Tables.Add("XXX")
    With DSShared.Tables("XXX")
      '.Columns.Add("",GetType())
      .Rows.Add()
      drxxx = .Rows(0)
      With .Rows(0)
        '!=""
      End With
    End With
    AddHandler DSShared.Tables("XXX").ColumnChanging, AddressOf CPNEBeforeColUpdate_XXX
    AddHandler DSShared.Tables("XXX").ColumnChanged, AddressOf CPNEAfterColUpdate_XXX

    Return True
  End Function


  Public Overridable Sub CPNEBeforeColUpdate_XXX(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
TRY
    Dim dtXTest As New DataTable
    Dim StrXTest As String = ""
    If e.Row!codditt.ToString = "" And e.Column.ColumnName <> "codditt" Then
      e.Row!codditt = strDittaCorrente
    End If
    'e.ProposedValue = UCase(e.ProposedValue.ToString)
    Select Case e.Column.ColumnName.ToLower
      Case "xx_codice"
        If Not IsNumeric(e.ProposedValue) Then
          ThrowRemoteEvent(New NTSEventArgs("", "Il valore non è valido"))
          If e.Row!xx_codice.ToString = "" Then
            e.ProposedValue = "0"
          Else
            e.ProposedValue = e.Row!xx_codice
          End If
        Else
          If Not CPNEControllaSeCodiceEsiste(e.ProposedValue.ToString, CPNEintRigaCorrente) Then
            If e.Row!xx_codice.ToString = "" Then
              e.ProposedValue = "0"
            Else
              e.ProposedValue = e.Row!xx_codice
            End If
          End If
        End If
        'If oCldhh.ValCodiceDb(e.ProposedValue.ToString, strDittaCorrente, "tabella", "tipocampochiave", StrXTest, dtXTest) Then
        '  If dtXTest.Rows.Count = 0 Then
        '    e.Row!xx_campo = ""
        '  Else
        '    e.Row!xx_campo = StrXTest
        '    e.Row!xx_campo1 = dtXTest.Rows(0)!Nomecampo
        '  End If
        'Else
        '  ThrowRemoteEvent(New NTSEventArgs("", "Il campo non è valido"))
        '  e.ProposedValue = "0" ' oppure "" a seconda del tipo di campo
        '  e.Row!xx_campo = ""
        'End If

    End Select
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Overridable Sub CPNEAfterColUpdate_XXX(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)

    Try
      e.Row.EndEdit()
      e.Row.EndEdit()
      Select Case e.Column.ColumnName.ToLower
        Case ""
      End Select
    Catch ex As Exception
      '--------------------------------------------------------------
      
   CLN__STD.GestErr(ex, Me, "")

      '--------------------------------------------------------------
    End Try
  End Sub

  Public Sub CPNECancRiga(ByVal dr As DataRow)
TRY
    If IsNothing(dr) Then
      Return
    End If
    Dim Evento As New NTSEventArgs(CLN__STD.ThMsg.MSG_NOYES, "Sicuro di cancellare la riga?")
    ThrowRemoteEvent(Evento)
    If Evento.RetValue = ThMsg.RETVALUE_NO Then
      Return
    End If
    dr.Delete()
    SalvaGriglia()
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub

  Public Sub CPNERipristinaRiga(ByVal dr As DataRow)
TRY
    If IsNothing(dr) Then
      Return
    End If
    Dim Evento As New NTSEventArgs(CLN__STD.ThMsg.MSG_NOYES, "Sicuro di ripristinare la riga?")
    ThrowRemoteEvent(Evento)
    If Evento.RetValue = ThMsg.RETVALUE_NO Then
      Return
    End If
    dr.RejectChanges()

Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub

  Public Function CPNEBeforeUpdateGriglia(ByVal dr As DataRow) As Boolean
    Try
      If IsNothing(dr) Then
        Return True
      End If
      '''test compiati tutti i campi se no return false
      'If dr!.ToString = "" Then
      '  ThrowRemoteEvent(New NTSEventArgs("", "Prima inserire"))
      '  Return False
      'End If

      SalvaGriglia()
    Catch ex As Exception
      If InStr(ex.Message.ToUpper, " PRIMARY ") <> 0 Or InStr(ex.Message.ToUpper, " PRIMARIA ") <> 0 Then
        ThrowRemoteEvent(New NTSEventArgs("", "ATTENZIONE COMBINAZIONE GIA' UTILIZZATA!!!" & vbCrLf & "CAMBIARLA O RIPRISITNARE"))
      Else
        
   CLN__STD.GestErr(ex, Me, "")

      End If
      Return False
    End Try
    Return True
  End Function
  Private Sub SalvaGriglia()
TRY
    oCldhh.ScriviTabellaSemplice(strDittaCorrente, "nometabella", DSShared.Tables("nomedatatable"), "", "", "")
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Sub CPNECaricaTabFirme()
TRY
    RemoveHandler dsShared.Tables("XXX").ColumnChanging, AddressOf CPNEBeforeColUpdate_XXX
    RemoveHandler dsShared.Tables("XXX").ColumnChanged, AddressOf CPNEAfterColUpdate_XXX
    oCldhh.CPNEPulisciDs(dsShared, "XXX")
    oCldhh.CPNECaricaTabFirme(dsShared, strDittaCorrente)
    AddHandler dsShared.Tables("XXX").ColumnChanging, AddressOf CPNEBeforeColUpdate_XXX
    AddHandler dsShared.Tables("XXX").ColumnChanged, AddressOf CPNEAfterColUpdate_XXX
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Sub CPNECaricaTabPostille()
TRY
    RemoveHandler dsShared.Tables("XXX").ColumnChanging, AddressOf CPNEBeforeColUpdate_XXX
    RemoveHandler dsShared.Tables("XXX").ColumnChanged, AddressOf CPNEAfterColUpdate_XXX
    oCldhh.CPNEPulisciDs(dsShared, "XXX")
    oCldhh.CPNECaricaTabPostille(dsShared, strDittaCorrente)
    AddHandler dsShared.Tables("XXX").ColumnChanging, AddressOf CPNEBeforeColUpdate_XXX
    AddHandler dsShared.Tables("XXX").ColumnChanged, AddressOf CPNEAfterColUpdate_XXX
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Sub CPNECaricaTabPreamboli()
TRY
    RemoveHandler dsShared.Tables("XXX").ColumnChanging, AddressOf CPNEBeforeColUpdate_XXX
    RemoveHandler dsShared.Tables("XXX").ColumnChanged, AddressOf CPNEAfterColUpdate_XXX
    oCldhh.CPNEPulisciDs(dsShared, "XXX")
    oCldhh.CPNECaricaTabPreamboli(dsShared, strDittaCorrente)
    AddHandler dsShared.Tables("XXX").ColumnChanging, AddressOf CPNEBeforeColUpdate_XXX
    AddHandler dsShared.Tables("XXX").ColumnChanged, AddressOf CPNEAfterColUpdate_XXX
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Sub CPNECaricaTabUM()
TRY
    RemoveHandler dsShared.Tables("XXX").ColumnChanging, AddressOf CPNEBeforeColUpdate_XXX
    RemoveHandler dsShared.Tables("XXX").ColumnChanged, AddressOf CPNEAfterColUpdate_XXX
    oCldhh.CPNEPulisciDs(dsShared, "XXX")
    oCldhh.CPNECaricaTabUM(dsShared, strDittaCorrente)
    AddHandler dsShared.Tables("XXX").ColumnChanging, AddressOf CPNEBeforeColUpdate_XXX
    AddHandler dsShared.Tables("XXX").ColumnChanged, AddressOf CPNEAfterColUpdate_XXX
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Function CPNESalva() As Boolean
TRY

    ' cancello record
    oCldhh.CPNECancellaTabella(strNomeTabella)

    ' inserisco i record
    For i = 0 To dsShared.Tables("XXX").Rows.Count - 1
      oCldhh.CPNEAggionraTabella(strNomeTabella, strDittaCorrente, dsShared.Tables("XXX").Rows(i))
    Next
    Return True
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function

  'Public Overrides Function Salva(ByVal bDelete As Boolean) As Boolean
  '  Dim bResult As Boolean = False
  '  Try
  '    '----------------------------------------
  '    'controlli pre-salvataggio (solo se non è una delete)
  '    If Not bDelete Then
  '      If Not TestPreSalva() Then Return False
  '    End If

  '----------------------------------------
  'chiamo il dal per salvare
  'If strActLog <> "-1" Then
  '  bResult = ocldBase.ScriviTabellaSemplice(strDittaCorrente, strNomeTabella, dsShared.Tables("XXX"), "", "", "")
  'Else
  '  bResult = ocldBase.ScriviTabellaSemplice(strDittaCorrente, strNomeTabella, dsShared.Tables("XXX"), _
  '            strActLogProg, strActLogNomOggLog, strActLogDesLog)
  'End If

  ' cancello record
  '    oCldhh.CPNECancellaTabella(strNomeTabella)

  '    ' inserisco i record
  '    For i = 0 To dsShared.Tables("XXX").Rows.Count - 1
  '      oCldhh.CPNEAggionraTabella(strNomeTabella, strDittaCorrente, dsShared.Tables("XXX").Rows(i))
  '    Next


  '    'If bResult Then
  '    'cancello i record delle descrizioni in lingua
  '    'oCldhh.CancellaGmerlin(strDittaCorrente)
  '    bHasChanges = False
  '    'End If

  '    Return bResult
  '  Catch ex As Exception
  '    '--------------------------------------------------------------
  '    If GestErrorCallThrow() Then
  '      CLN__STD.GestErr(ex, Me, "")
  '    Else
  '      ThrowRemoteEvent(New NTSEventArgs("", GestError(ex, Me, "", oApp.InfoError, "", False)))
  '    End If
  '    '--------------------------------------------------------------
  '  End Try
  'End Function
  Private Function CPNEControllaSeCodiceEsiste(ByVal strCodice As String, ByVal intRigaCorrente As Integer) As Boolean
TRY
    For i = 0 To dsShared.Tables("XXX").Rows.Count - 1
      If i <> intRigaCorrente Then
        If dsShared.Tables("XXX").Rows(i)!xx_codice.ToString = strCodice Then
          ThrowRemoteEvent(New NTSEventArgs("", "Codice già esistente"))
          Return False
        End If
      End If
    Next
    Return True
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function
  Public Function ValidaRigaGriglia(ByVal nRow As Integer) As Boolean
TRY
    If nRow < 0 Then Return True
    If nRow > dsShared.Tables("XXX").Rows.Count Then Return True
    If dsShared.Tables("XXX").Rows(nRow)!xx_codice.ToString = "" Then
      ThrowRemoteEvent(New NTSEventArgs("", "Indicare il Codice prima di salvare la riga."))
      Return False
    End If
    Return True
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function
End Class
