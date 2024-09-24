Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports NTSInformatica.CLE__APP
Public Class CLFORGSOR
  Inherits CLEORGSOR
  Public oCldhh As CLDORGSOR
  Dim strErr As String = ""
  Dim oTmp As Object = Nothing
  Public OMenu As Object
  Dim drxxx As DataRow
  Public DsZoomCPNE As New DataSet
  Public CPNEstrZoomTipoTab As String
  Public CPNEstrZoomCodice As String
  'Public strTipodocOr As String
  'Public intAnnoOr As Integer
  'Public strserieOr As String
  'Public intNumOr As Integer
  'Public bCPNEDuplica As Boolean



  Public Sub AssociaDs(ByRef ds As DataSet)
TRY
    DsZoomCPNE = ds
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub

  Public Overrides Function Init(ByRef App As CLE__APP, ByRef oScriptEngine As INT__SCRIPT, ByRef oCleLbmenu As Object, ByVal strTabella As String, ByVal bFiller1 As Boolean, ByVal strFiller1 As String, ByVal strFiller2 As String) As Boolean
    Init = MyBase.Init(App, oScriptEngine, oCleLbmenu, strTabella, False, "", "")
    oCldhh = CType(MyBase.ocldBase, CLDORGSOR)
  End Function


  Public Overridable Sub CPNEBeforeColUpdate_XXX(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
TRY
    Dim dtXTest As New DataTable
    Dim StrXTest As String = ""
    'If e.Row!campo.ToString = "" And e.Column.ColumnName <> "campo" Then
    '  'e.Row!campo = valore
    'End If
    e.ProposedValue = UCase(e.ProposedValue.ToString)
    Select Case e.Column.ColumnName.ToLower
      Case "xx_contoda", "xx_contoa"
        Dim DtAnagra As New DataTable
        oCldGsor.ValCodiceDb(e.ProposedValue.ToString, strDittaCorrente, "ANAGRA", "N", "", DtAnagra)
        If DtAnagra.Rows.Count <= 0 Then
          ThrowRemoteEvent(New NTSEventArgs("", "Il cliente selezionato non è valido"))
          If e.Column.ColumnName.ToLower = "xx_contoda" Then
            e.ProposedValue = e.Row!xx_contoda
          Else
            e.ProposedValue = e.Row!xx_contoa
          End If
        End If

      Case "xx_codagenda", "xx_codagena"
        Dim DtAgenti As New DataTable
        oCldGsor.ValCodiceDb(e.ProposedValue.ToString, strDittaCorrente, "TABCAGE", "N", "", DtAgenti)
        If DtAgenti.Rows.Count <= 0 Then
          ThrowRemoteEvent(New NTSEventArgs("", "L'agente selezionato non è valido"))
          If e.Column.ColumnName.ToLower = "xx_codagenda" Then
            e.ProposedValue = e.Row!xx_codagenda
          Else
            e.ProposedValue = e.Row!xx_codagena
          End If
        End If
      Case "xx_agenziada", "xx_agenziaa"
        Dim DtAgenzie As New DataTable
        oCldGsor.ValCodiceDb(e.ProposedValue.ToString, strDittaCorrente, "TABCAGE", "N", "", DtAgenzie)
        If DtAgenzie.Rows.Count <= 0 Then
          ThrowRemoteEvent(New NTSEventArgs("", "L'agenzia selezionata non è valida"))
          If e.Column.ColumnName.ToLower = "xx_agenziada" Then
            e.ProposedValue = e.Row!xx_agenziada
          Else
            e.ProposedValue = e.Row!xx_agenziaa
          End If
        End If
      Case "xx_tipo"
        If e.ProposedValue.ToString = "Q" Then
          e.Row!xx_commessada = 0
          e.Row!xx_commessaa = 999999999
          ThrowRemoteEvent(New NTSEventArgs("CPNE.ENComm", "N"))
        Else
          ThrowRemoteEvent(New NTSEventArgs("CPNE.ENComm", "S"))
        End If
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
        Case "xx_annoda"
          e.Row!xx_annoa = e.Row!xx_annoda
        Case "xx_serieda"
          e.Row!xx_seriea = e.Row!xx_serieda
        Case "xx_numdocda"
          e.Row!xx_numdoca = e.Row!xx_numdocda
        Case "xx_commessada"
          e.Row!xx_commessaa = e.Row!xx_commessada
        Case "xx_contoda"
          e.Row!xx_contoa = e.Row!xx_contoda
        Case "xx_codagenda"
          e.Row!xx_codagena = e.Row!xx_codagenda
        Case "xx_agenziada"
          e.Row!xx_agenziaa = e.Row!xx_agenziada
      End Select
    Catch ex As Exception
      '--------------------------------------------------------------
      
   CLN__STD.GestErr(ex, Me, "")

      '--------------------------------------------------------------
    End Try
  End Sub

  'Public Sub CPNECancRiga(ByVal dr As DataRow)
  '  If IsNothing(dr) Then
  '    Return
  '  End If
  '  Dim Evento As New NTSEventArgs(CLN__STD.ThMsg.MSG_NOYES, "Sicuro di cancellare la riga?")
  '  ThrowRemoteEvent(Evento)
  '  If Evento.RetValue = ThMsg.RETVALUE_NO Then
  '    Return
  '  End If
  '  dr.Delete()
  '  SalvaGriglia()
  'End Sub

  'Public Sub CPNERipristinaRiga(ByVal dr As DataRow)
  '  If IsNothing(dr) Then
  '    Return
  '  End If
  '  Dim Evento As New NTSEventArgs(CLN__STD.ThMsg.MSG_NOYES, "Sicuro di ripristinare la riga?")
  '  ThrowRemoteEvent(Evento)
  '  If Evento.RetValue = ThMsg.RETVALUE_NO Then
  '    Return
  '  End If
  '  dr.RejectChanges()

  'End Sub

  'Public Function CPNEBeforeUpdateGriglia(ByVal dr As DataRow) As Boolean
  '  Try
  '    If IsNothing(dr) Then
  '      Return True
  '    End If
  '    '''test compiati tutti i campi se no return false
  '    'If dr!.ToString = "" Then
  '    '  ThrowRemoteEvent(New NTSEventArgs("", "Prima inserire"))
  '    '  Return False
  '    'End If

  '    SalvaGriglia()
  '  Catch ex As Exception
  '    If InStr(ex.Message.ToUpper, " PRIMARY ") <> 0 Or InStr(ex.Message.ToUpper, " PRIMARIA ") <> 0 Then
  '      ThrowRemoteEvent(New NTSEventArgs("", "ATTENZIONE COMBINAZIONE GIA' UTILIZZATA!!!" & vbCrLf & "CAMBIARLA O RIPRISITNARE"))
  '    Else
  '      If GestErrorCallThrow() Then
  '        CLN__STD.GestErr(ex, Me, "")
  '      Else
  '        ThrowRemoteEvent(New NTSEventArgs("", GestError(ex, Me, "", oApp.InfoError, "", False)))
  '      End If
  '    End If
  '    Return False
  '  End Try
  '  Return True
  'End Function
  'Private Sub SalvaGriglia()
  '  oCldhh.ScriviTabellaSemplice(strDittaCorrente, "nometabella", DsZoomCPNE.Tables("nomedatatable"), "", "", "")
  'End Sub
  Public Sub CaricaDsXXX()
TRY
    CaricaCombo()
    If Not DsZoomCPNE.Tables.Contains("XXX") Then
      DsZoomCPNE.Tables.Add("XXX")
      With DsZoomCPNE.Tables("XXX")
        .Columns.Add("xx_tipo", GetType(String))
        .Columns.Add("xx_codagena", GetType(Integer))
        .Columns.Add("xx_codagenda", GetType(Integer))
        .Columns.Add("xx_agenziaa", GetType(Integer))
        .Columns.Add("xx_agenziada", GetType(Integer))
        .Columns.Add("xx_contoa", GetType(Integer))
        .Columns.Add("xx_contoda", GetType(Integer))
        .Columns.Add("xx_seriea", GetType(String))
        .Columns.Add("xx_serieda", GetType(String))
        .Columns.Add("xx_numdoca", GetType(Integer))
        .Columns.Add("xx_numdocda", GetType(Integer))
        .Columns.Add("xx_commessaa", GetType(Integer))
        .Columns.Add("xx_commessada", GetType(Integer))
        .Columns.Add("xx_annoa", GetType(Integer))
        .Columns.Add("xx_annoda", GetType(Integer))
        .Rows.Add()
      End With
    Else
      RemoveHandler DsZoomCPNE.Tables("XXX").ColumnChanging, AddressOf CPNEBeforeColUpdate_XXX
      RemoveHandler DsZoomCPNE.Tables("XXX").ColumnChanged, AddressOf CPNEAfterColUpdate_XXX
    End If
    With DsZoomCPNE.Tables("XXX")
      drxxx = .Rows(0)
      With .Rows(0)
        !xx_tipo = "Q"
        !xx_codagena = 999
        !xx_codagenda = 0
        !xx_agenziaa = 999
        !xx_agenziada = 0
        !xx_contoa = 99999999
        !xx_contoda = 0
        !xx_seriea = ""
        !xx_serieda = ""
        !xx_numdoca = 999999
        !xx_numdocda = 0
        !xx_commessaa = 999999999
        !xx_commessada = 0
        !xx_annoa = Year(Now)
        !xx_annoda = Year(Now)
        '!xx_annoa = intAnnoOr
        '!xx_annoda = intAnnoOr

      End With
    End With
    AddHandler DsZoomCPNE.Tables("XXX").ColumnChanging, AddressOf CPNEBeforeColUpdate_XXX
    AddHandler DsZoomCPNE.Tables("XXX").ColumnChanged, AddressOf CPNEAfterColUpdate_XXX
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub

  Private Sub CaricaCombo()
TRY

    If Not DsZoomCPNE.Tables.Contains("CBTIPODOC") Then
      DsZoomCPNE.Tables.Add("CBTIPODOC")
      With DsZoomCPNE.Tables("CBTIPODOC")
        .Columns.Add("codice", GetType(String))
        .Columns.Add("valore", GetType(String))

        .Rows.Add()
        With .Rows(0)
            !codice = "R"
            !valore = "Ordini clienti"
          End With
        .Rows.Add()
          With .Rows(1)
            !codice = "Q"
            !valore = "Preventivi"
          End With
        End With
    End If
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub

    Public Sub CPNEApriGrigliaOrdiniPrev(ByVal descr As String)
        Try
            Dim strSQL As String = ""
            Dim args2 As NTSEventArgs
            If DsZoomCPNE.Tables.Contains("RIGHEPREVORD") Then

            End If
            CType(oCldGsor, CLHORGSOR).CPNEPulisciDs(DsZoomCPNE, "RIGHEPREVORD")

            CType(oCldGsor, CLHORGSOR).CPNEdtApriOrdiniPrev(DsZoomCPNE, DsZoomCPNE.Tables("XXX").Rows(0), descr)
            args2 = New NTSEventArgs("CPNE.AssociaOrdiniPrev", "")
            Me.ThrowRemoteEvent(args2)

        Catch ex As Exception
            '--------------------------------------------------------------

            CLN__STD.GestErr(ex, Me, "")

            '--------------------------------------------------------------
        End Try
    End Sub
    Public Overrides Sub AfterColUpdate_TESTA(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    Dim dtXTest As New DataTable
    Dim StrXTest As String = ""
    Try
      MyBase.AfterColUpdate_TESTA(sender, e)
      Select Case e.Column.ColumnName.ToLower
        Case "hh_codpreambolo"
          e.Row!xx_codpreambolo = CPNEDecodificaCampiTabelle("TabHHPre", e.Row!hh_codpreambolo.ToString)
        Case "hh_codspd"
          e.Row!xx_codspd = CPNEDecodificaCampiTabelle("tabport", e.Row!hh_codspd.ToString)
        Case "hh_codtipiva"
          e.Row!xx_codtipiva = CPNEDecodificaCampiTabelle("TabHHTip", e.Row!hh_codtipiva.ToString)
        Case "hh_codpostilla"
          e.Row!xx_codpostilla = CPNEDecodificaCampiTabelle("TabHHPos", e.Row!hh_codpostilla.ToString)
        Case "hh_codfirma"
          e.Row!xx_codfirma = CPNEDecodificaCampiTabelle("TabHHFir", e.Row!hh_codfirma.ToString)

      End Select
    Catch ex As Exception
      '--------------------------------------------------------------				
      
   CLN__STD.GestErr(ex, Me, "")

      '--------------------------------------------------------------				
    End Try
  End Sub
  Public Overrides Sub BeforeColUpdate_TESTA(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    Try
      MyBase.BeforeColUpdate_TESTA(sender, e)
      Select Case e.Column.ColumnName.ToLower
        Case "hh_codpreambolo"
          If CPNECtrlCampiTabelle("TabHHPre", e.ProposedValue.ToString) = False Then
            ThrowRemoteEvent(New NTSEventArgs("", oApp.Tr(Me, 127791222103750000, "Codice Preambolo inesistente")))
            e.ProposedValue = e.Row!hh_codpreambolo
          End If
        Case "hh_codspd"
          If CPNECtrlCampiTabelle("tabport", e.ProposedValue.ToString) = False Then
            ThrowRemoteEvent(New NTSEventArgs("", oApp.Tr(Me, 127791222103750000, "Codice Spese doganali inesistente")))
            e.ProposedValue = e.Row!hh_codspd
          End If
        Case "hh_codtipiva"
          If CPNECtrlCampiTabelle("TabHHTip", e.ProposedValue.ToString) = False Then
            ThrowRemoteEvent(New NTSEventArgs("", oApp.Tr(Me, 127791222103750000, "Codice Tipo IVA inesistente")))
            e.ProposedValue = e.Row!hh_codtipiva
          End If
        Case "hh_codpostilla"
          If CPNECtrlCampiTabelle("TabHHPos", e.ProposedValue.ToString) = False Then
            ThrowRemoteEvent(New NTSEventArgs("", oApp.Tr(Me, 127791222103750000, "Codice Postilla inesistente")))
            e.ProposedValue = e.Row!hh_codpostilla
          End If
        Case "hh_codfirma"
          If CPNECtrlCampiTabelle("TabHHFir", e.ProposedValue.ToString) = False Then
            ThrowRemoteEvent(New NTSEventArgs("", oApp.Tr(Me, 127791222103750000, "Codice Firma inesistente")))
            e.ProposedValue = e.Row!hh_codfirma
          End If
        Case "hh_peragen"
          If CDec(e.ProposedValue.ToString) > 100 Or CDec(e.ProposedValue.ToString) < -100 Then
            ThrowRemoteEvent(New NTSEventArgs("", oApp.Tr(Me, 127791222103750000, "La % Agente deve essere compresa tra -100 e +100")))
            e.ProposedValue = e.Row!hh_peragen
          End If
        Case "hh_peragen2"
          If CDec(e.ProposedValue.ToString) > 100 Or CDec(e.ProposedValue.ToString) < -100 Then
            ThrowRemoteEvent(New NTSEventArgs("", oApp.Tr(Me, 127791222103750000, "La % Agenzia deve essere compresa tra -100 e +100")))
            e.ProposedValue = e.Row!hh_peragen2
          End If
        Case "hh_perusg"
          If CDec(e.ProposedValue.ToString) > 100 Or CDec(e.ProposedValue.ToString) < -100 Then
            ThrowRemoteEvent(New NTSEventArgs("", oApp.Tr(Me, 127791222103750000, "La % USG deve essere compresa tra -100 e +100")))
            e.ProposedValue = e.Row!hh_perusg
          End If

      End Select
    Catch ex As Exception
      '--------------------------------------------------------------				
      
   CLN__STD.GestErr(ex, Me, "")

      '--------------------------------------------------------------				
    End Try

  End Sub
  'Public Overrides Sub AfterColUpdate_CORPO(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
  '  Try
  '    MyBase.AfterColUpdate_CORPO(sender, e)
  '    Select Case e.Column.ColumnName.ToLower
  '      'Case "ec_codart"

  '    End Select



  '  Catch ex As Exception
  '    '--------------------------------------------------------------				
  '    If GestErrorCallThrow() Then
  '      CLN__STD.GestErr(ex, Me, "")
  '    Else
  '      ThrowRemoteEvent(New NTSEventArgs("", GestError(ex, Me, "", oApp.InfoError, "", False)))
  '    End If
  '    '--------------------------------------------------------------				
  '  End Try
  'End Sub
  'Public Overrides Sub BeforeColUpdate_CORPO(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
  '  Try
  '    Select Case e.Column.ColumnName.ToLower
  '      'Case "ec_codart"

  '      Case Else
  '        MyBase.BeforeColUpdate_CORPO(sender, e)
  '    End Select

  '  Catch ex As Exception
  '    '--------------------------------------------------------------				
  '    If GestErrorCallThrow() Then
  '      CLN__STD.GestErr(ex, Me, "")
  '    Else
  '      ThrowRemoteEvent(New NTSEventArgs("", GestError(ex, Me, "", oApp.InfoError, "", False)))
  '    End If
  '    '--------------------------------------------------------------			
  '  End Try
  'End Sub
  Function CPNEDecodificaCampiTabelle(ByVal strNomeTabella As String, ByVal strCodice As String) As String
TRY
    Dim dtXTest As New DataTable
    Dim StrXTest As String = ""

    ocldBase.ValCodiceDb(strCodice, strDittaCorrente, strNomeTabella, "S", StrXTest, dtXTest)
    Return StrXTest
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function
  Function CPNECtrlCampiTabelle(ByVal strNomeTabella As String, ByVal strCodice As String) As Boolean
TRY
    Dim dtXTest As New DataTable
    Dim StrXTest As String = ""

    If ocldBase.ValCodiceDb(strCodice, strDittaCorrente, strNomeTabella, "S", StrXTest, dtXTest) Then
      If dtXTest.Rows.Count > 0 Then
        Return True
      Else
        Return False
      End If
    Else
      Return False
    End If
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function
  Public Overrides Function ApriOrdine(ByVal strDitta As String, ByVal bNew As Boolean, ByVal strTipoDoc As String, ByVal nAnno As Integer, ByVal strSerie As String, ByVal lNumdoc As Integer, ByRef ds As System.Data.DataSet) As Boolean
TRY
    ApriOrdine = MyBase.ApriOrdine(strDitta, bNew, strTipoDoc, nAnno, strSerie, lNumdoc, ds)
    If ApriOrdine Then
      If dttET.Rows.Count > 0 Then
        CPNEAggiungiCampiTestata()

        If CInt(dttET.Rows(0)!hh_codpreambolo) > 0 Then
          dttET.Rows(0)!xx_codpreambolo = CPNEDecodificaCampiTabelle("TabHHPre", dttET.Rows(0)!hh_codpreambolo.ToString)
        End If
        If dttET.Rows(0)!hh_codspd.ToString <> "" Then
          dttET.Rows(0)!xx_codspd = CPNEDecodificaCampiTabelle("tabport", dttET.Rows(0)!hh_codspd.ToString)
        End If
        If CInt(dttET.Rows(0)!hh_codtipiva) > 0 Then
          dttET.Rows(0)!xx_codtipiva = CPNEDecodificaCampiTabelle("TabHHTip", dttET.Rows(0)!hh_codtipiva.ToString)
        End If
        If CInt(dttET.Rows(0)!hh_codpostilla) > 0 Then
          dttET.Rows(0)!xx_codpostilla = CPNEDecodificaCampiTabelle("TabHHPos", dttET.Rows(0)!hh_codpostilla.ToString)
        End If
        If CInt(dttET.Rows(0)!hh_codfirma) > 0 Then
          dttET.Rows(0)!xx_codfirma = CPNEDecodificaCampiTabelle("TabHHFir", dttET.Rows(0)!hh_codfirma.ToString)
        End If

        '=======riccardo
        'dttET.Rows(0)!hh_tiporkprev = dttET.Rows(0)!hh_tiporkprev
        'dttET.Rows(0)!hh_annoprev = dttET.Rows(0)!hh_annoprev
        'dttET.Rows(0)!hh_serieprev = dttET.Rows(0)!hh_serieprev
        'dttET.Rows(0)!hh_numprev = dttET.Rows(0)!hh_numprev
        '====================

        bHasChangesET = False
      End If
    End If
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function
  Public Overrides Function NuovoOrdine(ByVal strDitta As String, ByVal strTipoDoc As String, ByVal nAnno As Integer, ByVal strSerie As String, ByVal lNumdoc As Integer) As Boolean
TRY
    NuovoOrdine = MyBase.NuovoOrdine(strDitta, strTipoDoc, nAnno, strSerie, lNumdoc)
    If NuovoOrdine Then
      If dttET.Rows.Count > 0 Then
        CPNEAggiungiCampiTestata()
        CPNEInizCampi()
      End If
    End If
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function
  Sub CPNEAggiungiCampiTestata()
TRY
    If Not dttET.Columns.Contains("xx_codpreambolo") Then
      dttET.Columns.Add("xx_codpreambolo", GetType(String))
      dttET.Columns.Add("xx_codspd", GetType(String))
      dttET.Columns.Add("xx_codtipiva", GetType(String))
      dttET.Columns.Add("xx_codpostilla", GetType(String))
      dttET.Columns.Add("xx_codfirma", GetType(String))

      '============= riccardo 
      'dttET.Columns.Add("xx_tiporkpadre", GetType(String))
      'dttET.Columns.Add("xx_annopadre", GetType(Integer))
      'dttET.Columns.Add("xx_seriepadre", GetType(String))
      'dttET.Columns.Add("xx_numpadre", GetType(Integer))

    End If
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Sub CPNECaricaTabFirme()
TRY
    CType(oCldGsor, CLHORGSOR).CPNEPulisciDs(DsZoomCPNE, "YYY")
    CType(oCldGsor, CLHORGSOR).CPNECaricaTabFirme(DsZoomCPNE, strDittaCorrente)
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Sub CPNECaricaTabPostille()
TRY
    CType(oCldGsor, CLHORGSOR).CPNEPulisciDs(DsZoomCPNE, "YYY")
    CType(oCldGsor, CLHORGSOR).CPNECaricaTabPostille(DsZoomCPNE, strDittaCorrente)
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Sub CPNECaricaTabPreamboli()
TRY
    CType(oCldGsor, CLHORGSOR).CPNEPulisciDs(DsZoomCPNE, "YYY")
    CType(oCldGsor, CLHORGSOR).CPNECaricaTabPreamboli(DsZoomCPNE, strDittaCorrente)
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Sub CPNECaricaTabTipiIva()
TRY
    CType(oCldGsor, CLHORGSOR).CPNEPulisciDs(DsZoomCPNE, "YYY")
    CType(oCldGsor, CLHORGSOR).CPNECaricaTabTipiIva(DsZoomCPNE, strDittaCorrente)
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Sub CPNECaricaStorico()
TRY
    CType(oCldGsor, CLHORGSOR).CPNEPulisciDs(DsZoomCPNE, "CPNE.STORICO")
    CType(oCldGsor, CLHORGSOR).CPNECaricaStorico(DsZoomCPNE, strDittaCorrente, dttET.Rows(0))
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Sub CPNEAggiornaCampoZoom()
TRY

    Select Case CPNEstrZoomTipoTab
      Case "Firme"
        dttET.Rows(0)!hh_CodFirma = CInt(CPNEstrZoomCodice)
      Case "Postille"
        dttET.Rows(0)!hh_CodPostilla = CInt(CPNEstrZoomCodice)
      Case "Preamboli"
        dttET.Rows(0)!hh_CodPreambolo = CInt(CPNEstrZoomCodice)
      Case "TipiIva"
        dttET.Rows(0)!hh_CodTipIVA = CInt(CPNEstrZoomCodice)
    End Select

Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Sub CPNEInizCampi()
TRY
    dttET.Rows(0)!hh_tiporkPadre = ""
    dttET.Rows(0)!hh_seriePadre = ""
    dttET.Rows(0)!hh_annoPadre = 0
    dttET.Rows(0)!hh_numPadre = 0
    dttET.Rows(0)!hh_tiporkPrev = ""
    dttET.Rows(0)!hh_seriePrev = ""
    dttET.Rows(0)!hh_annoPrev = 0
    dttET.Rows(0)!hh_numPrev = 0

    dttET.Rows(0)!hh_PerAgen = 8
    dttET.Rows(0)!hh_PerUsg = 20

    dttET.Rows(0)!hh_DatAgg = Now.Date
    dttET.Rows(0)!hh_DataInv = Now.Date

    dttET.Rows(0)!et_codaspe = 1
    dttET.Rows(0)!et_porto = 1

    dttET.Rows(0)!hh_CodPostilla = 1
    dttET.Rows(0)!hh_CodPreambolo = 1
    dttET.Rows(0)!hh_CodTipIVA = 1
    dttET.Rows(0)!hh_CodFirma = 1
    dttET.Rows(0)!hh_CodTipIVA = 1

    dttET.Rows(0)!xx_codspd = ""
      dttET.Rows(0)!Et_datcons = CDate("01/01/1900")

    Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  'Public Overridable Function CPNEDuplicaDoc(ByVal strNewTipork As String, ByVal nNewAnno As Integer, ByVal strNewSerie As String, _
  '                                      ByVal lNewNumord As Integer, ByVal lNewConto As Integer, ByVal nNewTipobf As Integer) As Boolean
  '  'dal documento aperto, ne crea uno duplicato e setta lo stato di quest'ultimo su nuovo
  '  Dim i As Integer = 0
  '  Dim l As Integer = 0
  '  Dim lNumTmp As Integer = 0
  '  Dim dttTmp, dttAnagra As New DataTable
  '  Dim bRicalcolaPrezziSconti As Boolean = False
  '  Dim strTiporkOrig As String = strTipodocOr
  '  Dim nAnnoOrig As Integer = intAnnoOr
  '  Dim strSerieOrig As String = strserieOr
  '  Dim lNumOrig As Integer = intNumOr
  '  Dim dtrTmp() As DataRow = Nothing
  '  Dim dtrTmp1() As DataRow = Nothing
  '  Dim bLinguaDiv As Boolean = False
  '  Dim strDescr As String = ""
  '  Dim args As NTSEventArgs
  '  Try
  '    '-------------------------------


  '    'devo ricalcolare sempre prezzi/sconti/provv
  '    'se da tipork Q sto creando un O, oppure se da un tipork R o # sto creando un O o un H
  '    'If (dttET.Rows(0)!et_tipork.ToString = "O" And (strNewTipork = "R" Or strNewTipork = "X")) Or _
  '    '     ((dttET.Rows(0)!et_tipork.ToString = "H") And (strNewTipork = "R" Or strNewTipork = "X")) Then
  '    '  bRicalcolaPrezziSconti = True
  '    'End If

  '    ''-------------------------------
  '    'If (dttET.Rows(0)!et_tipork.ToString = "O" And (strNewTipork = "R" Or strNewTipork = "X")) Or _
  '    '  (dttET.Rows(0)!et_tipork.ToString = "H" And (strNewTipork = "R" Or strNewTipork = "X")) Or _
  '    '   (dttET.Rows(0)!et_tipork.ToString = "R" And strNewTipork = "X") Then
  '    '  If lNewConto = 0 Then lNewConto = NTSCInt(dttET.Rows(0)!et_conto)
  '    '  If nNewTipobf = 0 Then nNewTipobf = NTSCInt(dttET.Rows(0)!et_tipobf)
  '    'End If


  '    Dim strTiporkDa As String = dsShared.Tables("TESTA").Rows(0)!et_tipork.ToString
  '    Dim intAnnoDa As Integer = CInt(dsShared.Tables("TESTA").Rows(0)!et_anno.ToString)
  '    Dim strSerieDa As String = dsShared.Tables("TESTA").Rows(0)!et_serie.ToString
  '    Dim intNumdocDa As Integer = CInt(dsShared.Tables("TESTA").Rows(0)!et_numdoc.ToString)


  '    '-------------------------------
  '    'DUPLICO
  '    bNew = True
  '    bHasChangesET = True
  '    bInDuplicadoc = True

  '    'rimuovo il blocco impostato in apertura documento
  '    DocumentLockRemove()

  '    'If (strTiporkOrig = "O" And (strNewTipork = "R" Or strNewTipork = "X")) Or _
  '    '   (strTiporkOrig = "H" And (strNewTipork = "R" Or strNewTipork = "X")) Or _
  '    '   (strTiporkOrig = "R" And strNewTipork = "X") Then

  '    'Else
  '    '  If CBool(oCldGsor.GetSettingBusDitt(strDittaCorrente, "BSORGSOR", "OPZIONI", ".", "UsaDataOdiernaSuDuplica", "0", " ", "0")) Then
  '    '    dsShared.Tables("TESTA").Rows(0)!et_datdoc = NTSCDate(DateTime.Now.ToShortDateString)
  '    '  End If
  '    'End If

  '    'ora la parte in comune: cambio gli estremi del documento
  '    '''''''''If dttET.Rows(0)!et_tipork.ToString = strNewTipork Then
  '    'se il nuovo documento è dello stesso tipo del precedente ...

  '    'cambio gli estremi del documento e devo svuotare il flag di evasione e prenotazione 
  '    '(come se il documento no fosse mai stato evaso)
  '    CambiaNumdoc(dsShared, lNewNumord, strNewSerie, nNewAnno, False)
  '    dttET.Rows(0)!et_flevas = "N"
  '    ApriOrdineSvuotaEvasoPrenotatoPmOfa(dsShared, strNewTipork)
  '    dsShared.AcceptChanges()

  '    ''''''''''Else
  '    'nuovo documento di tipo diverso da quello di origine

  '    '--------------------------
  '    'al caso rimuovo la DB
  '    'If dsShared.Tables("TESTA").Rows(0)!et_tipork.ToString = "H" And strNewTipork <> "H" Then
  '    '  dsShared.Tables("CORPOIMP").Clear()
  '    '  If bModTCO Then dsShared.Tables("CORPOIMPTC").Clear()
  '    '  dsShared.Tables("ATTIVIT").Clear()
  '    '  dsShared.Tables("ASSRIS").Clear()
  '    'End If
  '    'dsShared.AcceptChanges()

  '    '--------------------------
  '    'Se il documento di origine è Impegno cliente (R),
  '    'quello di destinazione è Ordine di produzione (H)
  '    'e l'impostazione di registro è True (-1)
  '    'eredita anno/serie/numero partita
  '    'eredita la ragione sociale 1 e 2 sui riferimenti
  '    'If (dsShared.Tables("TESTA").Rows(0)!et_tipork.ToString = "R" Or dsShared.Tables("TESTA").Rows(0)!et_tipork.ToString = "#") And strNewTipork = "H" Then
  '    '  If bDuplicaR2HEreditaRifImpCli = True Then
  '    '    dsShared.Tables("TESTA").Rows(0)!et_annpar = dsShared.Tables("TESTA").Rows(0)!et_anno
  '    '    dsShared.Tables("TESTA").Rows(0)!et_alfpar = dsShared.Tables("TESTA").Rows(0)!et_serie
  '    '    dsShared.Tables("TESTA").Rows(0)!et_numpar = dsShared.Tables("TESTA").Rows(0)!et_numdoc
  '    '  Else
  '    '    dsShared.Tables("TESTA").Rows(0)!et_annpar = 0
  '    '    dsShared.Tables("TESTA").Rows(0)!et_alfpar = " "
  '    '    dsShared.Tables("TESTA").Rows(0)!et_numpar = 0
  '    '  End If




  '    '  If bDuplicaR2HRagSocSuRiferim = True Then
  '    '    oCldGsor.ValCodiceDb(NTSCInt(dsShared.Tables("TESTA").Rows(0)!et_conto).ToString, strDittaCorrente, "ANAGRA", "N", "", dttTmp)
  '    '    dsShared.Tables("TESTA").Rows(0)!et_riferim = Left(Trim(NTSCStr(dttTmp.Rows(0)!an_descr1) & " " & NTSCStr(dttTmp.Rows(0)!an_descr2)), 50)
  '    '    dttTmp.Clear()
  '    '  End If
  '    'End If


  '    '--------------------------
  '    'cambio gli estremi del documento
  '    LeggiRegistroDoc(strNewTipork)
  '    dsShared.Tables("TESTA").Rows(0)!et_tipork = strNewTipork
  '    CambiaNumdoc(dsShared, lNewNumord, strNewSerie, nNewAnno, False)
  '    Select Case strNewTipork
  '      Case "R", "Q", "Y", "X", "V", "#" : bDocEmesso = True
  '      Case Else : bDocEmesso = False
  '    End Select

  '    '==================================
  '    'CPNEbPassataDaDuplicaDoc = True
  '    dsShared.Tables("TESTA").Rows(0)!et_datcons = Date.Now

  '    '====================================

  '    '--------------------------
  '    'cambio cli/forn e tipobf
  '    'per il fatto che è un nuovo doc (bNew) al cambio del conto vengono ricalcolati agenti, forma pagam, banca, ecc.
  '    oCldGsor.ValCodiceDb(NTSCStr(lNewConto), strDittaCorrente, "ANAGRA", "N", , dttAnagra)
  '    If NTSCInt(dsShared.Tables("TESTA").Rows(0)!et_conto) <> lNewConto Then
  '      ' Se è cambiato il conto e ha la lingua diversa imposto che deve ricaricare le descrizioni degli articoli
  '      oCldGsor.ValCodiceDb(NTSCStr(dsShared.Tables("TESTA").Rows(0)!et_conto), strDittaCorrente, "ANAGRA", "N", , dttTmp)
  '      If dttAnagra.Rows.Count <> 0 And dttTmp.Rows.Count <> 0 Then
  '        If NTSCInt(dttAnagra.Rows(0)!an_codling) <> NTSCInt(dttTmp.Rows(0)!an_codling) Then bLinguaDiv = True
  '      End If

  '      dsShared.Tables("TESTA").Rows(0)!et_conto = lNewConto
  '      bRicalcolaPrezziSconti = True
  '    End If

  '    ''--- Se abilitata, in creazione di un ordine da precedente, preleva la data di sistema anziché quella dell'ordine di origine Then

  '    '--------------------------
  '    If NTSCInt(dsShared.Tables("TESTA").Rows(0)!et_tipobf) <> nNewTipobf Then
  '      dsShared.Tables("TESTA").Rows(0)!et_tipobf = nNewTipobf
  '      'devo cambiare anche i magazzini di riga : già fatto in autom in validaz tipobf
  '    End If

  '    dsShared.Tables("TESTA").Rows(0)!et_confermato = "N"
  '    dsShared.Tables("TESTA").Rows(0)!et_rilasciato = "N"
  '    dsShared.Tables("TESTA").Rows(0)!et_aperto = "N"

  '    '--------------------------
  '    'forzo il ricalcolo di contropartia e codice IVA di riga
  '    If Not (strNewTipork = "R" And strTiporkOrig = "Q") Then
  '      'da preventivo ad impegno devo mantenere codice contropartita e codice iva dell'impegno
  '      BeforeColUpdate_TESTA_et_controp(dsShared.Tables("TESTA"), New System.Data.DataColumnChangeEventArgs(dsShared.Tables("TESTA").Rows(0), dsShared.Tables("TESTA").Columns("et_controp"), dsShared.Tables("TESTA").Rows(0)!et_controp))
  '      BeforeColUpdate_TESTA_et_codese(dsShared.Tables("TESTA"), New System.Data.DataColumnChangeEventArgs(dsShared.Tables("TESTA").Rows(0), dsShared.Tables("TESTA").Columns("et_codese"), dsShared.Tables("TESTA").Rows(0)!et_codese))
  '    End If
  '    'per la valorizzazione dei semilavorati negli ordini di prod rivalido il listino
  '    BeforeColUpdate_TESTA_et_listino(dsShared.Tables("TESTA"), New System.Data.DataColumnChangeEventArgs(dsShared.Tables("TESTA").Rows(0), dsShared.Tables("TESTA").Columns("et_listino"), dsShared.Tables("TESTA").Rows(0)!et_listino))
  '    If NTSCInt(dsShared.Tables("TESTA").Rows(0)!et_magimp) <> 0 And strNewTipork <> "H" Then dsShared.Tables("TESTA").Rows(0)!et_magimp = 0
  '    bTerzista = False
  '    bTerzista = CType(oCleComm, CLELBMENU).IsTerzista(strDittaCorrente, NTSCInt(dsShared.Tables("TESTA").Rows(0)!et_magimp))

  '    dsShared.Tables("TESTA").Rows(0)!et_datdoc = Now.Date
  '    dsShared.Tables("TESTA").Rows(0)!et_ultagg = Now
  '    dsShared.Tables("TESTA").Rows(0)!hh_DataInv = Now.Date
  '    dsShared.Tables("TESTA").Rows(0)!hh_DatAgg = Now.Date

  '    If (strNewTipork = "R" And strTiporkDa = "R") Or (strNewTipork = "Q" And strTiporkDa = "R") Then
  '      dsShared.Tables("TESTA").Rows(0)!hh_tiporkPrev = ""
  '      dsShared.Tables("TESTA").Rows(0)!hh_annoPrev = 0
  '      dsShared.Tables("TESTA").Rows(0)!hh_seriePrev = ""
  '      dsShared.Tables("TESTA").Rows(0)!hh_NumPrev = 0

  '      dsShared.Tables("TESTA").Rows(0)!hh_tiporkPadre = ""
  '      dsShared.Tables("TESTA").Rows(0)!hh_annoPadre = 0
  '      dsShared.Tables("TESTA").Rows(0)!hh_seriePadre = ""
  '      dsShared.Tables("TESTA").Rows(0)!hh_NumPadre = 0
  '    Else
  '      dsShared.Tables("TESTA").Rows(0)!hh_tiporkPrev = strTiporkDa
  '      dsShared.Tables("TESTA").Rows(0)!hh_annoPrev = intAnnoDa
  '      dsShared.Tables("TESTA").Rows(0)!hh_seriePrev = strSerieDa
  '      dsShared.Tables("TESTA").Rows(0)!hh_NumPrev = intNumdocDa

  '      dsShared.Tables("TESTA").Rows(0)!hh_tiporkPadre = strTiporkDa
  '      dsShared.Tables("TESTA").Rows(0)!hh_annoPadre = intAnnoDa
  '      dsShared.Tables("TESTA").Rows(0)!hh_seriePadre = strSerieDa
  '      dsShared.Tables("TESTA").Rows(0)!hh_NumPadre = intNumdocDa
  '    End If

  '    'dsShared.Tables("TESTA").Rows(0)!hh_tiporkPadre = 
  '    'dsShared.Tables("TESTA").Rows(0)!hh_annoPadre = 
  '    '  dsShared.Tables("TESTA").Rows(0)!hh_seriePadre = 
  '    '  dsShared.Tables("TESTA").Rows(0)!hh_NumPadre = 

  '    'dsShared.Tables("TESTA").Rows(0)!hh_tiporkPrev = 
  '    '  dsShared.Tables("TESTA").Rows(0)!hh_annoPrev = 
  '    '  dsShared.Tables("TESTA").Rows(0)!hh_seriePrev = 
  '    '  dsShared.Tables("TESTA").Rows(0)!hh_NumPrev = 

  '    For Each dtrT As DataRow In dsShared.Tables("CORPO").Rows
  '      dtrT!ec_confermato = "N"
  '      dtrT!ec_rilasciato = "N"
  '      dtrT!ec_aperto = "N"
  '      If bRiportaCommDaTestataDupl Then
  '        dtrT!ec_commeca = dttET.Rows(0)!et_commeca
  '        dtrT!ec_subcommeca = dttET.Rows(0)!et_subcommeca
  '      End If

  '    Next




  '    '--------------------------
  '    'tolgo dal documento le righe da non ereditare
  '    'Se il documento di origine è Impegno cliente (R),
  '    'quello di destinazione è Ordine di produzione (H)
  '    'e l'impostazione di registro è True (-1)
  '    'preleva solo le righe che non risultano prenotate a saldo (mo_flevapre <> "S")
  '    If (strTiporkOrig = "R" Or strTiporkOrig = "#") And strNewTipork = "H" And bDuplicaR2HSoloNonPrenot = True Then
  '      dtrTmp = dsShared.Tables("CORPO").Select("ec_flevapre = 'S'")
  '      If dtrTmp.Length > 0 Then
  '        For i = 0 To dtrTmp.Length - 1
  '          If bModTCO Then
  '            dtrTmp1 = dsShared.Tables("CORPOTC").Select("ec_riga = " & NTSCInt(dtrTmp(i)!ec_riga).ToString)
  '            For l = 0 To dtrTmp1.Length - 1
  '              dtrTmp1(l).Delete()
  '            Next
  '          End If
  '          dtrTmp(i).Delete()
  '        Next
  '      End If
  '    End If
  '    dsShared.Tables("CORPO").AcceptChanges()
  '    If (strTiporkOrig = "R" Or strTiporkOrig = "#") And strNewTipork = "H" And bDuplicaR2HEscludiArtNoDiba = True Then
  '      dtrTmp = dsShared.Tables("CORPO").Select("xxo_coddb IS null")
  '      If dtrTmp.Length > 0 Then
  '        For i = 0 To dtrTmp.Length - 1
  '          If bModTCO Then
  '            dtrTmp1 = dsShared.Tables("CORPOTC").Select("ec_riga = " & NTSCInt(dtrTmp(i)!ec_riga).ToString)
  '            For l = 0 To dtrTmp1.Length - 1
  '              dtrTmp1(l).Delete()
  '            Next
  '          End If
  '          dtrTmp(i).Delete()
  '        Next
  '      End If
  '    End If
  '    dsShared.Tables("CORPO").AcceptChanges()
  '    If (strTiporkOrig = "R" Or strTiporkOrig = "#") And strNewTipork = "H" And bDuplicaR2HSoloArtGesComm = True Then
  '      dtrTmp = dsShared.Tables("CORPO").Select("xxo_gescomm = 'N'")
  '      If dtrTmp.Length > 0 Then
  '        For i = 0 To dtrTmp.Length - 1
  '          If bModTCO Then
  '            dtrTmp1 = dsShared.Tables("CORPOTC").Select("ec_riga = " & NTSCInt(dtrTmp(i)!ec_riga).ToString)
  '            For l = 0 To dtrTmp1.Length - 1
  '              dtrTmp1(l).Delete()
  '            Next
  '          End If
  '          dtrTmp(i).Delete()
  '        Next
  '      End If
  '    End If
  '    dsShared.Tables("CORPO").AcceptChanges()
  '    If dsShared.Tables.Contains("CORPOTC") Then dsShared.Tables("CORPOTC").AcceptChanges()
  '    ' se è cambiata la lingua reimposto la descrizione 
  '    'o si è passati da preventivo/imp cli a ordine fornitore
  '    If bLinguaDiv = True Then
  '      If ((strTiporkOrig = "R" Or strTiporkOrig = "#") And (strNewTipork = "H")) Or _
  '         ((strTiporkOrig = "R" Or strTiporkOrig = "#") And (strNewTipork = "O")) Or _
  '         ((strTiporkOrig = "Q") And (strNewTipork = "O")) Then
  '        With dsShared.Tables("CORPO")
  '          For i = 0 To .Rows.Count - 1
  '            If NTSCStr(.Rows(i)!ec_codart) <> "D" And NTSCStr(.Rows(i)!ec_codart) <> "M" Then
  '              If oCldGsor.ValCodiceDb(NTSCStr(.Rows(i)!ec_codart), strDittaCorrente, "ARTICO", "S", strDescr, dttTmp) Then
  '                .Rows(i)!ec_descr = strDescr
  '                .Rows(i)!ec_desint = NTSCStr(dttTmp.Rows(0)!ar_desint)
  '                If (NTSCDec(dttTmp.Rows(0)!ar_pesoca) = 0) And (NTSCStr(dttTmp.Rows(0)!ar_note).Trim <> "") Then
  '                  .Rows(i)!ec_note = NTSCStr(dttTmp.Rows(0)!ar_note)
  '                End If
  '              End If
  '            End If
  '            If NTSCInt(dttAnagra.Rows(0)!an_codling) <> 0 Then
  '              If oCldGsor.ValCodiceDb(NTSCStr(.Rows(i)!ec_codart), strDittaCorrente, "ARTVAL", "S", strDescr, dttTmp, NTSCStr(dttAnagra.Rows(0)!an_codling)) Then
  '                .Rows(i)!ec_descr = strDescr
  '                .Rows(i)!ec_desint = NTSCStr(dttTmp.Rows(0)!ax_desint)
  '              End If
  '            End If
  '            dttTmp.Clear()
  '            dttTmp.Dispose()
  '          Next
  '        End With
  '      End If
  '    End If    'If bLinguaDiv = True Then
  '    dsShared.Tables("CORPO").AcceptChanges()
  '    If bModTCO Then dsShared.Tables("CORPOTC").AcceptChanges()

  '    If dsShared.Tables("CORPO").Rows.Count = 0 Then
  '      If bDuplicaR2HSoloNonPrenot = False And bDuplicaR2HEscludiArtNoDiba = False And bDuplicaR2HSoloArtGesComm = False Then
  '        ThrowRemoteEvent(New NTSEventArgs("", oApp.Tr(Me, 128605996136406250, "Attenzione! Non esistono righe da inserire nel documento di destinazione")))
  '        Return False
  '      Else
  '        If bDuplicaR2HSoloNonPrenot = True Then
  '          ThrowRemoteEvent(New NTSEventArgs("", oApp.Tr(Me, 128605996677343750, "Attenzione! Non esistono righe non prenotate a saldo da inserire nel documento di destinazione")))
  '          Return False
  '        End If
  '        If bDuplicaR2HEscludiArtNoDiba = True Then
  '          ThrowRemoteEvent(New NTSEventArgs("", oApp.Tr(Me, 128605997513125000, "Attenzione! Non esistono righe con articoli con Distinta Base da inserire nel documento di destinazione")))
  '          Return False
  '        End If
  '        If bDuplicaR2HSoloArtGesComm = True Then
  '          ThrowRemoteEvent(New NTSEventArgs("", oApp.Tr(Me, 128605997809687500, "Attenzione! Non esistono righe con articoli gestiti a Commessa da inserire nel documento di destinazione")))
  '          Return False
  '        End If
  '      End If
  '      Return False
  '    End If

  '    '--------------------------
  '    'azzero prenotato, evaso, riferimenti vari a OFA, PM, ...
  '    dttET.Rows(0)!et_flevas = "N"
  '    ApriOrdineSvuotaEvasoPrenotatoPmOfa(dsShared, strNewTipork)
  '    dsShared.AcceptChanges()

  '    '--------------------------
  '    'ricalcolo prezzi/sconti/provvigioni di riga
  '    For i = 0 To dsShared.Tables("CORPO").Rows.Count - 1
  '      If bRicalcolaPrezziSconti Then SettaPrezzo(dsShared.Tables("CORPO").Rows(i), dsShared.Tables("CORPO").Rows(i)!ec_codart.ToString, strVisMemList1, nVisMemNumList)
  '      GetMemDttArti(dsShared.Tables("CORPO").Rows(i)!ec_codart.ToString)
  '      '  dsShared.Tables("CORPO").Rows(i)!ec_codcfam = dttArti.Rows(0)!ar_famprod
  '      If NTSCInt(dttArti.Rows(0)!ar_numecr) <> 0 Then
  '        dsShared.Tables("CORPO").Rows(i)!ec_codcena = dttArti.Rows(0)!ar_numecr
  '      End If
  '      If bRicalcolaPrezziSconti Then SettaSconti(dsShared.Tables("CORPO").Rows(i), NTSCInt(dttArti.Rows(0)!ar_clascon), nClscan)
  '      If bRicalcolaPrezziSconti Then SettaProvvigioni(dsShared.Tables("CORPO").Rows(i), False)

  '      'dsShared.Tables("CORPO").Rows(i)!ec_codart = dsShared.Tables("CORPO").Rows(i)!ec_codart

  '      dsShared.Tables("CORPO").Rows(i)!ec_tiporkor = strTiporkDa
  '      dsShared.Tables("CORPO").Rows(i)!ec_annoor = intAnnoDa
  '      dsShared.Tables("CORPO").Rows(i)!ec_serieor = strSerieDa
  '      dsShared.Tables("CORPO").Rows(i)!ec_numordor = intNumdocDa
  '      dsShared.Tables("CORPO").Rows(i)!ec_rigaor = dsShared.Tables("CORPO").Rows(i)!ec_riga

  '      CorpoTestPreSalva(dsShared.Tables("CORPO"), i)
  '      RecordSalva(dsShared.Tables("CORPO").Rows(i), False, Nothing)

  '    Next

  '    '--------------------------
  '    'se scelgo come documento di destinazione ordine di prod. devo esplodere la distinta base !!!
  '    If strNewTipork = "H" Then
  '      For Each dtrEC As DataRow In dsShared.Tables("CORPO").Rows
  '        ScriviRigheDaDiba(dtrEC, NTSCStr(dtrEC!ec_codart), NTSCInt(dtrEC!ec_fase), NTSCDec(dtrEC!ec_quant), _
  '               NTSCInt(dttET.Rows(0)!et_conto), NTSCInt(dtrEC!ec_commeca), NTSCStr(dtrEC!ec_subcommeca), _
  '               NTSCInt(dtrEC!ec_codcena), NTSCDate(dtrEC!ec_datcons), NTSCStr(dtrEC!ec_codcfam), NTSCInt(dtrEC!ec_perqta), _
  '               NTSCStr(dtrEC!ec_umprz), NTSCStr(dtrEC!ec_unmis), NTSCStr(dtrEC!ec_ump), NTSCDec(dtrEC!ec_colli), False)
  '        ValorizzaProduzione(dtrEC)
  '      Next
  '    End If

  '    ''''''End If    'If dttET.Rows(0)!et_tipork.ToString = strNewTipork Then

  '    '---------------------------
  '    dsShared.Tables("TESTA").Rows(0)!et_flevas = "N"
  '    dsShared.Tables("TESTA").Rows(0)!et_flstam = "N"

  '    '---------------------------
  '    'verifico se devo aggiornare tabnuma al salvataggio
  '    bProgrCambiato = False
  '    If lNewNumord <> LegNuma(IIf(strNewTipork = "V", "VV", strNewTipork).ToString, strNewSerie, nNewAnno) Then bProgrCambiato = True

  '    '---------------------------
  '    'se necessario ricalcolo il valore delle righe
  '    ''''''''''If dttET.Rows(0)!et_tipork.ToString = "H" Then
  '    ''''''''''  'ricalcolo i valori di riga degli impegni collegati e delle lavorazioni
  '    ''''''''''  For i = 0 To dttECIMP.Rows.Count - 1
  '    ''''''''''    SettaValoriRiga(dttECIMP.Rows(i))
  '    ''''''''''  Next
  '    ''''''''''End If
  '    For i = 0 To dttEC.Rows.Count - 1
  '      If dttET.Rows(0)!et_tipork.ToString = "H" Then ValorizzaProduzione(dttEC.Rows(i))
  '      SettaValoriRiga(dttEC.Rows(i))
  '    Next
  '    bDocRetail = False

  '    '---------------------------
  '    'Se impostata l'opzione di registro relativa, duplica anche i records di ALLOLE di tipo file (se esistenti)
  '    '''''''''If bDuplicaAllole = True Then
  '    '''''''''  If Not oCldGsor.DuplicaDocAllole(strDittaCorrente, strTiporkOrig, nAnnoOrig, strSerieOrig, lNumOrig, strNewTipork, nNewAnno, strNewSerie, lNewNumord) Then
  '    '''''''''    oCldGsor.DeleteDocAllole(strDittaCorrente, strNewTipork, nNewAnno, strNewSerie, lNewNumord, True, Nothing)
  '    '''''''''    Return False
  '    '''''''''  End If
  '    '''''''''End If    'If bDuplicaAllole = True Then



  '    bInDuplicadoc = False

  '    dsShared.AcceptChanges()    'forse per ogni riga andrebbe fatta la RecordSalva, sia per il corpo che per gli impegni/lavoraz/assris...


  '    Return True

  '  Catch ex As Exception
  '    '--------------------------------------------------------------
  '    If GestErrorCallThrow() Then
  '      CLN__STD.GestErr(ex, Me, "")
  '    Else
  '      ThrowRemoteEvent(New NTSEventArgs("", GestError(ex, Me, "", oApp.InfoError, "", False)))
  '    End If
  '    '--------------------------------------------------------------	
  '  Finally
  '    bInDuplicadoc = False
  '  End Try
  'End Function
  Public Overrides Function SalvaOrdine(ByVal strState As String) As Boolean
TRY
    CPNEAggiornaStorico()
    CPNEAggiornaPreventivo()
    Return MyBase.SalvaOrdine(strState)
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function

  Public Sub CPNEAggiornaStorico()
TRY
    If bNew = False And dttET.Rows(0)!et_tipork.ToString = "R" Then
      Dim dtRigheOrdine As DataTable = CType(oCldGsor, CLHORGSOR).CPNEAggiornaStoricoCaricaRigheOrdine(strDittaCorrente, dttET.Rows(0))
      If dtRigheOrdine.Rows.Count > 0 Then
        For i = 0 To dtRigheOrdine.Rows.Count - 1
          Dim drRiga As DataRow() = dttEC.Select("ec_riga = " & CInt(dtRigheOrdine.Rows(i)!mo_riga))
          If drRiga.Length = 0 Then
            CPNEAggiornaStoricoRiga(CInt(dtRigheOrdine.Rows(i)!mo_riga), "Cancella")
          Else
            If dtRigheOrdine.Rows(i)!mo_descr.ToString <> drRiga(0)!ec_descr.ToString Or CDec(dtRigheOrdine.Rows(i)!mo_quant) <> CDec(drRiga(0)!ec_quant) Or CInt(dtRigheOrdine.Rows(i)!mo_codvuo) <> CInt(drRiga(0)!ec_codvuo) Or CInt(dtRigheOrdine.Rows(i)!mo_lotto) <> CInt(drRiga(0)!ec_lotto) Or CInt(dtRigheOrdine.Rows(i)!mo_codcena) <> CInt(drRiga(0)!ec_codcena) Or CDec(dtRigheOrdine.Rows(i)!mo_prezzo) <> CDec(drRiga(0)!ec_prezzo) Or dtRigheOrdine.Rows(i)!mo_unmis.ToString <> drRiga(0)!ec_unmis.ToString Or dtRigheOrdine.Rows(i)!mo_desint.ToString <> drRiga(0)!ec_desint.ToString Or dtRigheOrdine.Rows(i)!mo_stasino.ToString <> drRiga(0)!ec_stasino.ToString Or CInt(dtRigheOrdine.Rows(i)!mo_controp) <> CInt(drRiga(0)!ec_controp) Or dtRigheOrdine.Rows(i)!mo_note.ToString <> drRiga(0)!ec_note.ToString Then
              CPNEAggiornaStoricoRiga(CInt(dtRigheOrdine.Rows(i)!mo_riga), "Aggiornata")
            End If
          End If
        Next
      End If
    End If
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub

  Public Sub CPNEAggiornaStoricoRiga(ByVal intRiga As Integer, ByVal StrTipoMod As String)
TRY
    CType(oCldGsor, CLHORGSOR).CPNEAggiornaStoricoRiga(Now.Date, CDec(Now.Hour & "," & Now.Minute), oApp.User.Nome, StrTipoMod, dttET.Rows(0)!et_tipork.ToString, CInt(dttET.Rows(0)!et_anno), dttET.Rows(0)!et_serie.ToString, CInt(dttET.Rows(0)!et_numdoc), intRiga)
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub

  Public Sub CPNEAggiornaPreventivo()
TRY
    Dim intNuovoNumOrd As Integer
    If CInt(dttET.Rows(0)!hh_annoPadre) > 0 Then
      If dttET.Rows(0)!et_tipork.ToString <> "Q" Then
        Dim Evento As New NTSEventArgs(CLN__STD.ThMsg.MSG_NOYES, "Questo ordine è collegato ad un preventivo." & vbCr & "Allineare il preventivo(Si) o crearne uno nuovo(no)?")
        Me.ThrowRemoteEvent(Evento)
        If Evento.RetValue = ThMsg.RETVALUE_NO Then
          intNuovoNumOrd = LegNuma("Q", dttET.Rows(0)!hh_seriePadre.ToString, CInt(dttET.Rows(0)!hh_annoPadre))
          CType(oCldGsor, CLHORGSOR).CPNECreaPreventivo(intNuovoNumOrd, CInt(dttET.Rows(0)!hh_annopadre), dttET.Rows(0)!hh_seriepadre.ToString, CInt(dttET.Rows(0)!hh_NumPadre))

          dttET.Rows(0)!hh_NumPadre = intNuovoNumOrd
          For i = 0 To dttEC.Rows.Count - 1
            dttEC.Rows(0)!ec_annoor = intNuovoNumOrd
          Next
          dttEC.AcceptChanges()
        End If
      End If
      For i = 0 To dttEC.Rows.Count - 1
        CType(oCldGsor, CLHORGSOR).CPNEAggiornaPreventivo(strDittaCorrente, dttEC.Rows(i))
      Next
    End If
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub

  Public Overrides Function CorpoTestPreSalva(ByRef dttCorpo As System.Data.DataTable, ByVal nRow As Integer) As Boolean
TRY
    If Not IsNothing(dttCorpo.Rows(nRow)) Then
      Dim DrEc As DataRow = dttCorpo.Rows(nRow)
      If DrEc!ec_tipork.ToString = "R" Then
        If CInt(DrEc!ec_commeca) = 0 Then
          If DrEc!ec_descr.ToString.Trim = "" Then
            Dim DrsEc As DataRow() = dttCorpo.Select("ec_riga < " & CInt(DrEc!ec_riga), "ec_riga desc")
            If DrsEc.Length > 0 Then
              DrEc!ec_commeca = DrsEc(0)!ec_commeca
            End If
          Else
            DrEc!ec_commeca = CPNEGeneraCommessa(DrEc)
          End If
        End If
      End If
    End If
    CorpoTestPreSalva = MyBase.CorpoTestPreSalva(dttCorpo, nRow)
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function

  Private Function CPNEGeneraCommessa(ByVal DrEc As DataRow) As Integer
TRY
    Dim DtDataOrd As Date = CDate(dttET.Rows(0)!et_datdoc)
    Dim IntAnno As Integer = Year(DtDataOrd)
    Dim IntMese As Integer = Month(DtDataOrd)
    Dim DtHHTabNuma As DataTable = CType(oCldDocu, CLHORGSOR).CPNELeggiHHTabNuma(IntAnno, IntMese)
    Dim DrHHTabNuma As DataRow
    If DtHHTabNuma.Rows.Count = 0 Then
      DtHHTabNuma.Rows.Add()
      DrHHTabNuma = DtHHTabNuma.Rows(0)
      DrHHTabNuma!hh_mese = IntMese
      DrHHTabNuma!hh_anno = IntAnno
      DrHHTabNuma!hh_Prorg = 0
    Else
      DrHHTabNuma = DtHHTabNuma.Rows(0)
    End If
    DrHHTabNuma!hh_Prorg = CInt(DrHHTabNuma!hh_Prorg) + 1
    oCldDocu.ScriviTabellaSemplice(strDittaCorrente, "HHTabNuma", DtHHTabNuma, "", "", "")
    CPNEGeneraCommessa = (IntAnno * 100000) + (IntMese * 1000) + CInt(DrHHTabNuma!hh_Prorg)
    Dim dttTmp As New DataTable
    oCldDocu.ValCodiceDb(CPNEGeneraCommessa.ToString, strDittaCorrente, "COMMESS", "N", "", dttTmp)
    If dttTmp.Rows.Count = 0 Then
      Dim dsTmp As New DataSet
      dsTmp.Tables.Add(dttTmp)
      dttTmp.TableName = "COMMESS"
      oCldhh.SetTableDefaultValueFromDB("COMMESS", dsTmp)
      dttTmp.Rows.Add(dttTmp.NewRow)
      With dttTmp.Rows(0)
        Dim DrEt As DataRow = dttET.Rows(0)
        !codditt = strDittaCorrente
        !co_comme = CPNEGeneraCommessa
        !co_conto = DrEt!et_conto
        !co_descr1 = DrEc!ec_descr
        !co_descr2 = DrEc!ec_desint
        !co_dtaper = DrEt!et_datdoc
        !co_dtagg = NTSCDate(DateTime.Now.ToShortDateString)
        !co_dtchiu = NTSCDate(IntSetDate("31/12/2099"))
        !co_dtscad = NTSCDate(IntSetDate("31/12/2099"))
        !co_note = DrEc!ec_note
        !co_tipork = "R"
        !co_anno = DrEc!ec_anno
        !co_serie = DrEc!ec_serie
        !co_numord = DrEc!ec_numdoc
        !co_riga = DrEc!ec_riga
        !co_listmat = 1
      End With
      If Not oCldhh.ScriviTabellaSemplice(strDittaCorrente, "COMMESS", dttTmp, "", "", "") Then Return 0
    End If
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function

  Public Overrides Sub CorpoOnAddNewRow(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
TRY
    MyBase.CorpoOnAddNewRow(sender, e)
    If e.Row!ec_codart.ToString.Trim = "" Then
      e.Row!ec_codart = "D"
    End If
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Overrides Function AfterColUpdate_CORPO_ec_codart(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) As Boolean
TRY
    AfterColUpdate_CORPO_ec_codart = MyBase.AfterColUpdate_CORPO_ec_codart(sender, e)
    If AfterColUpdate_CORPO_ec_codart Then
      e.Row!ec_provv = dttET.Rows(0)!hh_PerAgen
      e.Row!ec_provv2 = dttET.Rows(0)!hh_PerAgen2
    End If
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function
End Class
