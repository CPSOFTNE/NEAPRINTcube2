Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Public Class FROORGSOR
  Inherits FRMORGSOR
  Public oPar As CLE__CLDP

  Dim EDXX_TIPORKPADRE As NTSTextBoxStr
  Dim EDXX_SERIEPADRE As NTSTextBoxStr
  Dim EDXX_ANNOPADRE As NTSTextBoxNum
  Dim EDXX_NUMPADRE As NTSTextBoxNum

  Dim EDXX_TIPORKPREV As NTSTextBoxStr
  Dim EDXX_SERIEPREV As NTSTextBoxStr
  Dim EDXX_ANNOPREV As NTSTextBoxNum
  Dim EDXX_NUMPREV As NTSTextBoxNum


  Public Overrides Sub InitControls()
TRY
    MyBase.InitControls()
    Dim strErr As String = ""
    Dim oTmp As Object = Nothing
    CLN__STD.NTSIstanziaDll(oApp.ServerDir, oApp.NetDir, "BOORGSOR", "BEORGSOR", oTmp, strErr, False, "", "")


    'If Not IsNothing(NTSFindControlByName(Me, "tlbCPNESelPrev")) Then
    '  AddHandler CType(NTSFindControlByName(Me, "tlbCPNESelPrev"), NTSBarMenuItem).ItemClick, AddressOf tlbCPNESelPrev_Click
    'End If

    'CType(NTSFindControlByName(Me, "tlbCPNESelPrev"), NTSBarMenuItem).ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F11)

    If Not IsNothing(NTSFindControlByName(Me, "CMDCPNESTORICO")) Then
      AddHandler CType(NTSFindControlByName(Me, "CMDCPNESTORICO"), NTSButton).Click, AddressOf CMDCPNESTORICO_Click
    End If

    GeneraECollegaOggettiARuntime()

    'CType(NTSFindControlByName(Me, "EDXX_TIPORKPADRE"), NTSTextBoxStr).Enabled = False
    'CType(NTSFindControlByName(Me, "EDXX_SERIEPADRE"), NTSTextBoxStr).Enabled = False
    'CType(NTSFindControlByName(Me, "EDXX_ANNOPADRE"), NTSTextBoxNum).Enabled = False
    'CType(NTSFindControlByName(Me, "EDXX_NUMPADRE"), NTSTextBoxNum).Enabled = False

    'CType(NTSFindControlByName(Me, "EDXX_TIPORKPREV"), NTSTextBoxStr).Enabled = False
    'CType(NTSFindControlByName(Me, "EDXX_SERIEPREV"), NTSTextBoxStr).Enabled = False
    'CType(NTSFindControlByName(Me, "EDXX_ANNOPREV"), NTSTextBoxNum).Enabled = False
    'CType(NTSFindControlByName(Me, "EDXX_NUMPREV"), NTSTextBoxNum).Enabled = False
    AddHandler CType(NTSFindControlByName(Me, "tlbstacom"), NTSBarMenuItem).ItemClick, AddressOf tlbstacom_ItemClick
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub GeneraECollegaOggettiARuntime()
    Try
      EDXX_TIPORKPADRE = CType(NTSFindControlByName(Me, "EDXX_TIPORKPADRE"), NTSTextBoxStr)
      EDXX_SERIEPADRE = CType(NTSFindControlByName(Me, "EDXX_SERIEPADRE"), NTSTextBoxStr)
      EDXX_ANNOPADRE = CType(NTSFindControlByName(Me, "EDXX_ANNOPADRE"), NTSTextBoxNum)
      EDXX_NUMPADRE = CType(NTSFindControlByName(Me, "EDXX_NUMPADRE"), NTSTextBoxNum)

      EDXX_TIPORKPREV = CType(NTSFindControlByName(Me, "EDXX_TIPORKPREV"), NTSTextBoxStr)
      EDXX_SERIEPREV = CType(NTSFindControlByName(Me, "EDXX_SERIEPREV"), NTSTextBoxStr)
      EDXX_ANNOPREV = CType(NTSFindControlByName(Me, "EDXX_ANNOPREV"), NTSTextBoxNum)
      EDXX_NUMPREV = CType(NTSFindControlByName(Me, "EDXX_NUMPREV"), NTSTextBoxNum)

      CType(NTSFindControlByName(Me, "EDXX_TIPORKPADRE"), NTSTextBoxStr).Enabled = False
      CType(NTSFindControlByName(Me, "EDXX_SERIEPADRE"), NTSTextBoxStr).Enabled = False
      CType(NTSFindControlByName(Me, "EDXX_ANNOPADRE"), NTSTextBoxNum).Enabled = False
      CType(NTSFindControlByName(Me, "EDXX_NUMPADRE"), NTSTextBoxNum).Enabled = False

      CType(NTSFindControlByName(Me, "EDXX_TIPORKPREV"), NTSTextBoxStr).Enabled = False
      CType(NTSFindControlByName(Me, "EDXX_SERIEPREV"), NTSTextBoxStr).Enabled = False
      CType(NTSFindControlByName(Me, "EDXX_ANNOPREV"), NTSTextBoxNum).Enabled = False
      CType(NTSFindControlByName(Me, "EDXX_NUMPREV"), NTSTextBoxNum).Enabled = False

    Catch ex As Exception
      MsgBox(ex.ToString)
    End Try
  End Sub

  Public Overridable Sub tlbstacom_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
    Try
      'parametri zoom sono di tipo CLE__CLDP 												
      Dim parametriChil As New CLE__CLDP
      parametriChil.dPar1 = CInt(edEt_conto.Text)
      If Not IsNothing(grvRighe.NTSGetCurrentDataRow) Then
        parametriChil.dPar2 = CInt(grvRighe.NTSGetCurrentDataRow!ec_commeca)
      Else
        parametriChil.dPar2 = 0
      End If
      oMenu.RunChild("NTSInformatica", "FRMHHAVCO", "Avanzamento commessa", DittaCorrente, "", "BNHHAVCO", parametriChil, "", True, True)
    Catch ex As Exception
      CLN__STD.GestErr(ex, Me, "")
    End Try

  End Sub
  'Public Overrides Sub FRMORGSOR_Load(ByVal sender As Object, ByVal e As System.EventArgs)
  '  MyBase.FRMORGSOR_Load(sender, e)
  '  'riccardo
  '  CType(NTSFindControlByName(Me, "CMDCPNESTORICO"), NTSButton).Visible = False

  'End Sub
  'Public Overrides Sub FRMORGSOR_ActivatedFirst(ByVal sender As Object, ByVal e As System.EventArgs)
  '  MyBase.FRMORGSOR_ActivatedFirst(sender, e)
  '  CType(NTSFindControlByName(Me, "CMDCPNESTORICO"), NTSButton).Visible = False
  'End Sub
  Public Overrides Sub tlbZoom_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    'Dim strappoggio As String

    'riccardo 21-07-2017
    'CType(oCleGsor, CLFORGSOR).intAnnoOr = edAnnoDoc.Text

    If edNumDoc.Focused Or cbTipoDoc.Focused Then
      If cbTipoDoc.SelectedValue = "O" Then
        MyBase.tlbZoom_ItemClick(sender, e)
      Else
        Dim formDaLan As New FrmRicerca
        oPar = New CLE__CLDP

        formDaLan.Init(oMenu, oPar, DittaCorrente)
        formDaLan.InitEntity(oCleGsor)
        formDaLan.CPNEbPassataDaSelPrev = False
        formDaLan.StrForzaTipork = cbTipoDoc.SelectedValue
        formDaLan.ShowDialog()
        If formDaLan.bCPNEConferma Then
          If formDaLan.bCPNEDuplica Then

            Dim strNewTipork As String = cbTipoDoc.SelectedValue
            Dim nNewAnno As Integer = edAnnoDoc.Text
            Dim strNewSerie As String = edSerieDoc.Text
            Dim lNewProgr As Integer = oCleGsor.LegNuma(IIf(cbTipoDoc.SelectedValue.ToString() = "V", "VV", cbTipoDoc.SelectedValue.ToString()).ToString, edSerieDoc.Text, NTSCInt(edAnnoDoc.Text))


            cbTipoDoc.SelectedValue = formDaLan.drCPNERigaSel!td_tipork
            edAnnoDoc.Text = formDaLan.drCPNERigaSel!td_anno
            edSerieDoc.Text = formDaLan.drCPNERigaSel!td_serie
            edNumDoc.Text = formDaLan.drCPNERigaSel!td_numord
            tlbApri_ItemClick(Me, Nothing)




            If strNewTipork = cbTipoDoc.SelectedValue And _
               lNewProgr = NTSCInt(oCleGsor.dttET.Rows(0)!et_numdoc) And _
               strNewSerie = NTSCStr(oCleGsor.dttET.Rows(0)!et_serie) And _
               nNewAnno = NTSCInt(oCleGsor.dttET.Rows(0)!et_anno) Then Return

            Me.Cursor = Cursors.WaitCursor

            'inoltre se cambio tipork devo ricaricare anche la griglia ...
            If oCleGsor.dttET.Rows(0)!et_tipork.ToString <> strNewTipork Then
              GctlTipoDoc = strNewTipork
              GctlSetRoules()
              GestisciGrigliaTCO()
            End If
            'giorgio sezione standard
            If oCleGsor.DuplicaDoc(strNewTipork, nNewAnno, strNewSerie, lNewProgr, NTSCInt(edEt_conto.Text), NTSCInt(edEt_tipobf.Text)) Then
              cbTipoDoc.SelectedValue = strNewTipork
              edAnnoDoc.Text = nNewAnno.ToString
              edSerieDoc.Text = strNewSerie
              edNumDoc.Text = lNewProgr.ToString
              If cbTipoDoc.SelectedValue.ToString = "Q" Then
                If ckEt_flevas.Checked = False Then
                  GctlSetVisEnab(ckEt_flevas, False)
                Else
                  ckEt_flevas.Enabled = False
                End If
              Else
                ckEt_flevas.Enabled = False
              End If
              grvRighe.NTSMoveFirstRowColunn()
              tsGsor.SelectedTabPageIndex = 0
              GctlSetVisEnab(tlbSalva, False)
              oCleGsor.bDocNonModificabile = False

              SetStato(1, False)

              '================================= calcolo commessa standard 
              '''For i = 0 To oCleGsor.dttEC.Rows.Count - 1
              '''  oCleGsor.dttEC.Rows(i)!ec_commeca = 0
              '''  oCleGsor.CorpoTestPreSalva(oCleGsor.dttEC, i)
              '''  oCleGsor.RecordSalva(oCleGsor.dttEC.Rows(i), False, Nothing)
              '''Next
              ''''For i = 0 To oCleGsor.dttEC.Rows.Count - 1
              ''''  If (oCleGsor.dttET.Rows(0)!et_tipork.ToString = "R"  And oCleGsor.dttEC.Rows(i)!ec_commeca = 0_Then
              ''''    'GetMemDttArti(dtrEC!ec_codart.ToString)

              ''''    oCleGsor.dttEC.Rows(i)!ec_commeca = CType(oCleComm, CLELBMENU).GeneraNumCommeca(strDittaCorrente, _
              ''''                        dttET.Rows(0)!et_tipork.ToString, NTSCInt(dttET.Rows(0)!et_anno), _
              ''''                        dttET.Rows(0)!et_serie.ToString, NTSCInt(dttET.Rows(0)!et_numdoc), NTSCInt(dtrEC!ec_riga), _
              ''''                        NTSCInt(dttET.Rows(0)!et_tipobf), NTSCInt(dttET.Rows(0)!et_conto), NTSCStr(dtrEC!ec_codart), _
              ''''                        NTSCStr(dtrEC!ec_descr), NTSCStr(dtrEC!ec_desint), NTSCStr(dtrEC!ec_note), _
              ''''                        NTSCDate(dttET.Rows(0)!et_datdoc).ToShortDateString, strRetSubCommeca, "O", "", strError)

              ''''    oCleGsor.dttEC.Rows(i)!ec_subcommeca = strRetSubCommeca
              ''''    If strError <> "" Then ThrowRemoteEvent(New NTSEventArgs("", strError))

              ''''  End If
              ''''Next i

              '=====================================

              oApp.MsgBoxInfo(oApp.Tr(Me, 128602591253906250, "Duplicazione documento terminata"))

              'pulisco i recent dei documenti da aprire
              dttOpens.Clear()
                '========== 12 02 2020 riccardo
                'tlbApriRecent.Visible = False
                '=============================
              Else
              oApp.MsgBoxErr(oApp.Tr(Me, 128602620241093750, "Duplicazione documento non eseguita"))
              Ripristina()
            End If
            'giorgio sezione standard fine






            Dim Drt As DataRow = oCleGsor.dttET.Rows(0)
            Drt!et_confermato = "N"
            Drt!et_rilasciato = "N"
            Drt!et_aperto = "N"

            Drt!et_datdoc = Now.Date
            Drt!et_ultagg = Now
            Drt!hh_DataInv = Now.Date
            Drt!hh_DatAgg = Now.Date

            If (strNewTipork = "R" And formDaLan.drCPNERigaSel!td_tipork = "R") Or (strNewTipork = "Q" And formDaLan.drCPNERigaSel!td_tipork = "R") Then
              Drt!hh_tiporkPrev = ""
              Drt!hh_annoPrev = 0
              Drt!hh_seriePrev = ""
              Drt!hh_NumPrev = 0

              Drt!hh_tiporkPadre = ""
              Drt!hh_annoPadre = 0
              Drt!hh_seriePadre = ""
              Drt!hh_NumPadre = 0
            Else
              Drt!hh_tiporkPrev = formDaLan.drCPNERigaSel!td_tipork
              Drt!hh_annoPrev = formDaLan.drCPNERigaSel!td_anno
              Drt!hh_seriePrev = formDaLan.drCPNERigaSel!td_serie
              Drt!hh_NumPrev = formDaLan.drCPNERigaSel!td_numord

              Drt!hh_tiporkPadre = formDaLan.drCPNERigaSel!td_tipork
              Drt!hh_annoPadre = formDaLan.drCPNERigaSel!td_anno
              Drt!hh_seriePadre = formDaLan.drCPNERigaSel!td_serie
              Drt!hh_NumPadre = formDaLan.drCPNERigaSel!td_numord
            End If

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
          Else
            cbTipoDoc.SelectedValue = formDaLan.drCPNERigaSel!td_tipork
            edAnnoDoc.Text = formDaLan.drCPNERigaSel!td_anno
            edSerieDoc.Text = formDaLan.drCPNERigaSel!td_serie
            edNumDoc.Text = formDaLan.drCPNERigaSel!td_numord
            tlbApri_ItemClick(Me, Nothing)
          End If
        End If
        formDaLan.Dispose()
        formDaLan = Nothing





        'If oPar.bPar1 = False Then Return

        'If Not formDaLan.dttOut Is Nothing Then
        '  'la selezione documenti mi ha passato un elenco di documenti da aprire: memorizzo l'elenco
        '  dttOpens = formDaLan.dttOut.Copy
        '  formDaLan.dttOut.Clear()
        '  formDaLan.dttOut = Nothing
        'End If

        'formDaLan.Dispose()
        'formDaLan = Nothing

        'If dttOpens.Rows.Count > 1 Then
        '  GctlSetVisEnab(tlbApriRecent, True)

        '  edSerieDoc.Text = dttOpens.Rows(0)!td_serie.ToString
        '  edNumDoc.Text = dttOpens.Rows(0)!td_numord.ToString
        '  edAnnoDoc.Text = dttOpens.Rows(0)!td_anno.ToString
        '  cbTipoDoc.SelectedValue = dttOpens.Rows(0)!td_tipork.ToString

        'Else
        '  strappoggio = dttOpens.Rows(0)!td_tipork.ToString
        '  dttOpens.Clear()
        '  tlbApriRecent.Visible = False
        '  'riccardo inserire tipork dal combo box

        '  edSerieDoc.Text = oPar.strPar2
        '  edNumDoc.Text = oPar.strPar4
        '  cbTipoDoc.SelectedValue = strappoggio

        'End If


        'tlbApri_ItemClick(Me, Nothing)
      End If
    ElseIf CType(Me.NTSFindControlByName(Me, "edxx_CodFirma"), NTSTextBoxNum).Focused Then
      CType(oCleGsor, CLFORGSOR).CPNEstrZoomTipoTab = "tabhhfir"
      ApriTabella("Firme")
    ElseIf CType(Me.NTSFindControlByName(Me, "edxx_CodPostilla"), NTSTextBoxNum).Focused Then
      CType(oCleGsor, CLFORGSOR).CPNEstrZoomTipoTab = "tabhhpos"
      ApriTabella("Postille")
    ElseIf CType(Me.NTSFindControlByName(Me, "edxx_CodPreambolo"), NTSTextBoxNum).Focused Then
      CType(oCleGsor, CLFORGSOR).CPNEstrZoomTipoTab = "tabhhpre"
      ApriTabella("Preamboli")
    ElseIf CType(Me.NTSFindControlByName(Me, "edxx_CodTipIVA"), NTSTextBoxNum).Focused Then
      CType(oCleGsor, CLFORGSOR).CPNEstrZoomTipoTab = "tabhhtip"
      ApriTabella("TipiIva")
    Else
      MyBase.tlbZoom_ItemClick(sender, e)
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub FROORGSOR_ActivatedFirst(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ActivatedFirst
TRY
    Me.Height += 100
    tsGsor.Height += 100
    TabPage1.Height += 100
      '================12 02 2020 riccardo NON ESISTE PIù NELLA CUBE
      'pnTestataSx.Height += 100
      '=====================
      Me.MinimumSize = New Size(Me.MinimumSize.Width, Me.MinimumSize.Height + 100)
    CType(Me.NTSFindControlByName(Me, "edxx_CodSpD"), NTSTextBoxStr).NTSSetParamZoom("ZOOMTABPORT")
    CType(Me.NTSFindControlByName(Me, "edxx_CodFirma"), NTSTextBoxNum).NTSForzaVisZoom = True
    CType(Me.NTSFindControlByName(Me, "edxx_CodPostilla"), NTSTextBoxNum).NTSForzaVisZoom = True
    CType(Me.NTSFindControlByName(Me, "edxx_CodPreambolo"), NTSTextBoxNum).NTSForzaVisZoom = True
    CType(Me.NTSFindControlByName(Me, "edxx_CodTipIVA"), NTSTextBoxNum).NTSForzaVisZoom = True

    Me.MinimumSize = New System.Drawing.Size(Me.MinimumSize.Width + 200, Me.MinimumSize.Height)

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub ApriTabella(ByVal TipoTab As String)
TRY
    CType(oCleGsor, CLFORGSOR).CPNEstrZoomCodice = ""
    CType(oCleGsor, CLFORGSOR).CPNEstrZoomTipoTab = TipoTab
    Dim formDaLanApriTab As New FRMHHZOOM
    formDaLanApriTab.Init(oMenu, Nothing, DittaCorrente)
    formDaLanApriTab.InitEntity(oCleGsor)
    formDaLanApriTab.ShowDialog()
    formDaLanApriTab.Dispose()
    formDaLanApriTab = Nothing
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Public Overrides Sub tlbApri_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    MyBase.tlbApri_ItemClick(sender, e)
    If cbTipoDoc.SelectedValue = "Q" Then
      EDXX_TIPORKPADRE.Visible = True
      EDXX_SERIEPADRE.Visible = True
      EDXX_ANNOPADRE.Visible = True
      EDXX_NUMPADRE.Visible = True

      EDXX_TIPORKPREV.Visible = False
      EDXX_SERIEPREV.Visible = False
      EDXX_ANNOPREV.Visible = False
      EDXX_NUMPREV.Visible = False
    Else
      EDXX_TIPORKPREV.Visible = True
      EDXX_SERIEPREV.Visible = True
      EDXX_ANNOPREV.Visible = True
      EDXX_NUMPREV.Visible = True

      EDXX_TIPORKPADRE.Visible = False
      EDXX_SERIEPADRE.Visible = False
      EDXX_ANNOPADRE.Visible = False
      EDXX_NUMPADRE.Visible = False

    End If
    'CType(NTSFindControlByName(Me, "tlbCPNESelPrev"), NTSBarMenuItem).Enabled = False

    'If pnTestataClforn.Visible Then
    '  If dsGsor.Tables("TESTA").Rows(0)!et_tipork <> "R" Then
    '    CType(NTSFindControlByName(Me, "CMDCPNESTORICO"), NTSButton).Visible = False
    '  Else
    '    CType(NTSFindControlByName(Me, "CMDCPNESTORICO"), NTSButton).Visible = True
    '  End If
    'End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  'Public Overrides Sub tlbApri_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

  '  ' riccardo 24-07-2017
  '  'edNumDoc.Text = oPar.strPar4

  '  If Trim(edNumDoc.Text) = "" Then edNumDoc.Text = 0
  '  If CInt(edNumDoc.Text) = 0 Then
  '    CType(oCleGsor, CLFORGSOR).strTipodocOr = cbTipoDoc.SelectedValue
  '    CType(oCleGsor, CLFORGSOR).intAnnoOr = edAnnoDoc.Text
  '    CType(oCleGsor, CLFORGSOR).strserieOr = edSerieDoc.Text
  '    Dim formDaLan As New FrmRicerca
  '    oPar = New CLE__CLDP
  '    formDaLan.Init(oMenu, oPar, DittaCorrente)
  '    formDaLan.InitEntity(oCleGsor)
  '    formDaLan.CPNEbPassataDaSelPrev = False
  '    formDaLan.ShowDialog()


  '    If oPar.bPar1 = False Then Return

  '    If Not formDaLan.dttOut Is Nothing Then
  '      'la selezione documenti mi ha passato un elenco di documenti da aprire: memorizzo l'elenco
  '      dttOpens = formDaLan.dttOut.Copy
  '      formDaLan.dttOut.Clear()
  '      formDaLan.dttOut = Nothing
  '    End If

  '    formDaLan.Dispose()
  '    formDaLan = Nothing

  '    CType(oCleGsor, CLFORGSOR).intNumOr = oCleGsor.LegNuma(CType(oCleGsor, CLFORGSOR).strTipodocOr, CType(oCleGsor, CLFORGSOR).strserieOr, CType(oCleGsor, CLFORGSOR).intAnnoOr)


  '    If dttOpens.Rows.Count > 1 Then
  '      GctlSetVisEnab(tlbApriRecent, True)
  '      cbTipoDoc.SelectedValue = dttOpens.Rows(0)!td_tipork.ToString
  '      edSerieDoc.Text = dttOpens.Rows(0)!td_serie.ToString
  '      edNumDoc.Text = dttOpens.Rows(0)!td_numord.ToString
  '      edAnnoDoc.Text = dttOpens.Rows(0)!td_anno.ToString
  '    Else
  '      cbTipoDoc.SelectedValue = dttOpens.Rows(0)!td_tipork.ToString
  '      dttOpens.Clear()
  '      tlbApriRecent.Visible = False
  '      edSerieDoc.Text = oPar.strPar2
  '      edNumDoc.Text = oPar.strPar4
  '      edAnnoDoc.Text = oPar.strPar1
  '    End If

  '    tlbApri_ItemClick(Me, Nothing)

  '    If CType(oCleGsor, CLFORGSOR).bCPNEDuplica Then
  '      CType(oCleGsor, CLFORGSOR).CPNEDuplicaDoc(CType(oCleGsor, CLFORGSOR).strTipodocOr, CType(oCleGsor, CLFORGSOR).intAnnoOr, CType(oCleGsor, CLFORGSOR).strserieOr, CType(oCleGsor, CLFORGSOR).intNumOr, CInt(oPar.strPar3), CInt(oPar.strPar5))

  '      cbTipoDoc.SelectedValue = CType(oCleGsor, CLFORGSOR).strTipodocOr
  '      edAnnoDoc.Text = CType(oCleGsor, CLFORGSOR).intAnnoOr
  '      edSerieDoc.Text = CType(oCleGsor, CLFORGSOR).strserieOr
  '      edNumDoc.Text = CType(oCleGsor, CLFORGSOR).intNumOr
  '    End If
  '  Else
  '    MyBase.tlbApri_ItemClick(sender, e)
  '  End If

  '  If cbTipoDoc.SelectedValue = "Q" Then
  '    CType(NTSFindControlByName(Me, "EDXX_TIPORKPADRE"), NTSTextBoxStr).Visible = True
  '    CType(NTSFindControlByName(Me, "EDXX_SERIEPADRE"), NTSTextBoxStr).Visible = True
  '    CType(NTSFindControlByName(Me, "EDXX_ANNOPADRE"), NTSTextBoxNum).Visible = True
  '    CType(NTSFindControlByName(Me, "EDXX_NUMPADRE"), NTSTextBoxNum).Visible = True

  '    CType(NTSFindControlByName(Me, "EDXX_TIPORKPREV"), NTSTextBoxStr).Visible = False
  '    CType(NTSFindControlByName(Me, "EDXX_SERIEPREV"), NTSTextBoxStr).Visible = False
  '    CType(NTSFindControlByName(Me, "EDXX_ANNOPREV"), NTSTextBoxNum).Visible = False
  '    CType(NTSFindControlByName(Me, "EDXX_NUMPREV"), NTSTextBoxNum).Visible = False
  '  Else
  '    CType(NTSFindControlByName(Me, "EDXX_TIPORKPREV"), NTSTextBoxStr).Visible = True
  '    CType(NTSFindControlByName(Me, "EDXX_SERIEPREV"), NTSTextBoxStr).Visible = True
  '    CType(NTSFindControlByName(Me, "EDXX_ANNOPREV"), NTSTextBoxNum).Visible = True
  '    CType(NTSFindControlByName(Me, "EDXX_NUMPREV"), NTSTextBoxNum).Visible = True

  '    CType(NTSFindControlByName(Me, "EDXX_TIPORKPADRE"), NTSTextBoxStr).Visible = False
  '    CType(NTSFindControlByName(Me, "EDXX_SERIEPADRE"), NTSTextBoxStr).Visible = False
  '    CType(NTSFindControlByName(Me, "EDXX_ANNOPADRE"), NTSTextBoxNum).Visible = False
  '    CType(NTSFindControlByName(Me, "EDXX_NUMPADRE"), NTSTextBoxNum).Visible = False

  '  End If
  '  'CType(NTSFindControlByName(Me, "tlbCPNESelPrev"), NTSBarMenuItem).Enabled = False

  '  If pnTestataClforn.Visible Then
  '    If dsGsor.Tables("TESTA").Rows(0)!et_tipork <> "R" Then
  '      CType(NTSFindControlByName(Me, "CMDCPNESTORICO"), NTSButton).Visible = False
  '    Else
  '      CType(NTSFindControlByName(Me, "CMDCPNESTORICO"), NTSButton).Visible = True
  '    End If
  '  End If
  'End Sub
  Public Overrides Sub tlbNuovo_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    MyBase.tlbNuovo_ItemClick(sender, e)
    If cbTipoDoc.SelectedValue = "Q" Then
      EDXX_TIPORKPADRE.Visible = True
      EDXX_SERIEPADRE.Visible = True
      EDXX_ANNOPADRE.Visible = True
      EDXX_NUMPADRE.Visible = True

      EDXX_TIPORKPREV.Visible = False
      EDXX_SERIEPREV.Visible = False
      EDXX_ANNOPREV.Visible = False
      EDXX_NUMPREV.Visible = False
    Else
      EDXX_TIPORKPREV.Visible = True
      EDXX_SERIEPREV.Visible = True
      EDXX_ANNOPREV.Visible = True
      EDXX_NUMPREV.Visible = True

      EDXX_TIPORKPADRE.Visible = False
      EDXX_SERIEPADRE.Visible = False
      EDXX_ANNOPADRE.Visible = False
      EDXX_NUMPADRE.Visible = False

    End If
    'CType(NTSFindControlByName(Me, "tlbCPNESelPrev"), NTSBarMenuItem).Enabled = True

    'If pnTestataClforn.Visible Then
    '  If dsGsor.Tables("TESTA").Rows(0)!et_tipork <> "R" Then
    '    CType(NTSFindControlByName(Me, "CMDCPNESTORICO"), NTSButton).Visible = False
    '  Else
    '    CType(NTSFindControlByName(Me, "CMDCPNESTORICO"), NTSButton).Visible = True
    '  End If
    'End If

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Public Overrides Sub GestisciEventiEntity(ByVal sender As Object, ByRef e As NTSEventArgs)
TRY

    If Mid(e.TipoEvento, 1, 4) = "CPNE" Then
      Select Case e.TipoEvento

      End Select
    Else
      If 1 = 1 Then 'If CType(oCleGsor, CLFORGSOR).bCPNEDuplica Then 'giorgio123
          If e.Message = "Modificare la data di consegna su tutte le righe di questo documento?" Then
            e.RetValue = "YES"
            Return
          End If
          If e.Message = "La data di consegna indicata in testata è inferiore alla data dell'ordine/impegno.
Proseguire ugualmente?" Then
            e.RetValue = "YES"
            Return
          End If
          If e.Message = "Modificare il Codice contropartita vendite/acquisti su tutte le righe di questo documento?" Then
          e.RetValue = "YES"
          Return
        End If
        MyBase.GestisciEventiEntity(sender, e)
      Else
        MyBase.GestisciEventiEntity(sender, e)
      End If
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Public Overridable Sub CMDCPNESTORICO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
Try
      If fmDocTop.Visible Then
        'If pnTestataClforn.Visible Then
        Dim formDaLan As New FRMHHSTORICO
        oPar = New CLE__CLDP
        formDaLan.Init(oMenu, oPar, DittaCorrente)
        formDaLan.InitEntity(oCleGsor)
        formDaLan.ShowDialog()

        formDaLan.Dispose()
        formDaLan = Nothing
      Else

      End If

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  'Public Overridable Sub tlbCPNESelPrev_Click(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
  '  CType(oCleGsor, CLFORGSOR).strTipodocOr = cbTipoDoc.SelectedValue
  '  CType(oCleGsor, CLFORGSOR).intAnnoOr = CInt(edAnnoDoc.Text)
  '  CType(oCleGsor, CLFORGSOR).strserieOr = edSerieDoc.Text
  '  CType(oCleGsor, CLFORGSOR).intNumOr = CInt(edNumDoc.Text)

  '  Dim formDaLan As New FrmRicerca
  '  oPar = New CLE__CLDP
  '  formDaLan.Init(oMenu, oPar, DittaCorrente)
  '  formDaLan.InitEntity(oCleGsor)
  '  formDaLan.CPNEbPassataDaSelPrev = True
  '  formDaLan.ShowDialog()



  '  If oPar.bPar1 = False Then Return

  '  If Not formDaLan.dttOut Is Nothing Then
  '    'la selezione documenti mi ha passato un elenco di documenti da aprire: memorizzo l'elenco
  '    dttOpens = formDaLan.dttOut.Copy
  '    formDaLan.dttOut.Clear()
  '    formDaLan.dttOut = Nothing
  '  End If

  '  formDaLan.Dispose()
  '  formDaLan = Nothing

  '  If dttOpens.Rows.Count > 1 Then
  '    GctlSetVisEnab(tlbApriRecent, True)

  '    edSerieDoc.Text = dttOpens.Rows(0)!td_serie.ToString
  '    edNumDoc.Text = dttOpens.Rows(0)!td_numord.ToString
  '  Else
  '    dttOpens.Clear()
  '    tlbApriRecent.Visible = False

  '    'edSerieDoc.Text = oPar.strPar2
  '    'edNumDoc.Text = oPar.strPar4
  '  End If
  '  'edEt_conto.Visible = False

  '  tlbApri_ItemClick(Me, Nothing)
  '  CType(oCleGsor, CLFORGSOR).CPNEDuplicaDoc(CType(oCleGsor, CLFORGSOR).strTipodocOr, CType(oCleGsor, CLFORGSOR).intAnnoOr, CType(oCleGsor, CLFORGSOR).strserieOr, CType(oCleGsor, CLFORGSOR).intNumOr, CInt(oPar.strPar3), CInt(oPar.strPar5))
  '  'edEt_conto.Visible = True

  '  CType(NTSFindControlByName(Me, "tlbCPNESelPrev"), NTSBarMenuItem).Enabled = False

  'End Sub
  Public Overrides Sub SetStato(ByVal nStato As Integer, ByVal bRicaricaGctlInStato1 As Boolean)
TRY
    MyBase.SetStato(nStato, bRicaricaGctlInStato1)
    Select Case nStato
      Case 0
        CType(NTSFindControlByName(Me, "CMDCPNESTORICO"), NTSButton).Visible = False
      Case 1
        If dsGsor.Tables("TESTA").Rows(0)!et_tipork <> "R" Then
          CType(NTSFindControlByName(Me, "CMDCPNESTORICO"), NTSButton).Visible = False
        Else
          CType(NTSFindControlByName(Me, "CMDCPNESTORICO"), NTSButton).Visible = True
        End If
    End Select
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub tlbNuovoOrdineDaPrec_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    Dim DrEt As DataRow = oCleGsor.dttET.Rows(0)
    Dim StrTipo As String = DrEt!et_tipork.ToString
    Dim IntAnno As Integer = CInt(DrEt!et_anno)
    Dim StrSerie As String = DrEt!et_serie.ToString
    Dim IntNumOrd As Integer = CInt(DrEt!et_numdoc)

    '============= RICCARDO 06 02 2020 per disattivare il flevas altrimenti non si riesce a copiare =============
    If oCleGsor.dttET.Rows(0)!et_flevas = "S" Then
      oCleGsor.dttET.Rows(0)!et_flevas = "N"
    End If

    '============ RICCARDO  
    oCleGsor.bHasChangesET = False
    '=======================

    MyBase.tlbNuovoOrdineDaPrec_ItemClick(sender, e)
      If StrTipo <> DrEt!et_tipork.ToString Or IntAnno <> CInt(DrEt!et_anno) Or StrSerie <> DrEt!et_serie.ToString Or IntNumOrd <> CInt(DrEt!et_numdoc) Then
        DrEt!hh_tiporkPadre = StrTipo
        DrEt!hh_annoPadre = IntAnno
        DrEt!hh_seriePadre = StrSerie
        DrEt!hh_NumPadre = IntNumOrd
        If DrEt!et_tipork.ToString = "R" Then
          DrEt!hh_tiporkPrev = StrTipo
          DrEt!hh_annoPrev = IntAnno
          DrEt!hh_seriePrev = StrSerie
          DrEt!hh_NumPrev = IntNumOrd
        End If
      End If

      edet_datdoc.Text = Date.Now

    Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  'Public Overrides Sub Bindcontrols()

  '  EDXX_TIPORKPADRE.NTSDbField = "TESTA.hh_tiporkpadre"
  '  EDXX_SERIEPADRE.NTSDbField = "TESTA.hh_seriepadre"
  '  EDXX_ANNOPADRE.NTSDbField = "TESTA.hh_annopadre"
  '  EDXX_NUMPADRE.NTSDbField = "TESTA.hh_numpadre"

  '  EDXX_TIPORKPREV.NTSDbField = "TESTA.hh_tiporkprev"
  '  EDXX_SERIEPREV.NTSDbField = "TESTA.hh_serieprev"
  '  EDXX_ANNOPREV.NTSDbField = "TESTA.hh_annoprev"
  '  EDXX_NUMPREV.NTSDbField = "TESTA.hh_numprev"

  '  'CType(NTSFindControlByName(Me, "EDXX_SERIEPADRE"), NTSTextBoxStr).Enabled = False
  '  'CType(NTSFindControlByName(Me, "EDXX_ANNOPADRE"), NTSTextBoxNum).Enabled = False
  '  'CType(NTSFindControlByName(Me, "EDXX_NUMPADRE"), NTSTextBoxNum).Enabled = False

  '  'CType(NTSFindControlByName(Me, "EDXX_TIPORKPREV"), NTSTextBoxStr).Enabled = False
  '  'CType(NTSFindControlByName(Me, "EDXX_SERIEPREV"), NTSTextBoxStr).Enabled = False
  '  'CType(NTSFindControlByName(Me, "EDXX_ANNOPREV"), NTSTextBoxNum).Enabled = False
  '  'CType(NTSFindControlByName(Me, "EDXX_NUMPREV"), NTSTextBoxNum).Enabled = False


  '  MyBase.Bindcontrols()
  'End Sub
End Class
