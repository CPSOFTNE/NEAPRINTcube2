Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Public Class FRCORGSOR
  Inherits FRMORGSOR
  Dim OCLEStd As CLBORGSOR

  Public oCleBoll As CLEVEBOLL = Nothing
  Public CPNEIntNumDoc As Integer
  Public CPNEiContoDdtRic As Integer

  Dim CPNEbBloccaMessaggio As Boolean = False

  '''''Bottoni e controlli inizio ============================================================
  Dim tlbSelDDTRic As NTSBarMenuItem
  Dim tlb_Costr As NTSBarMenuItem
  Dim tlbCPNEBNHHGEAR As NTSBarMenuItem
  Dim tlbCpneScaricaFifoCDep As NTSBarMenuItem
  Dim tlbCPNEDetRigaTT As NTSBarMenuItem
  Dim tlbCPNEDUPLICADOC As NTSBarMenuItem
  Dim tlbCPNESALVAPARTITA As NTSBarMenuItem
  Dim tlbCPNESALVAURGENZA As NTSBarMenuItem
  Dim tlbCPNECALCPARTITA As NTSBarMenuItem
  Dim tlbCPNEMODPREZZORIGHE As NTSBarMenuItem
  Dim tlbCPNESALVANOTE As NTSBarMenuItem
  Dim ec_codartclifor As NTSGridColumn
  Dim hh_prezzosucolli As NTSGridColumn
  Dim xx_cpnecolliprod As NTSGridColumn
  Dim hh_note2 As NTSGridColumn
  Dim hh_distintaord As NTSGridColumn
  Dim xx_cpneqtaprod As NTSGridColumn
  Dim lbCPNEDescMsg As NTSLabel
  Dim lbCPNEPartita As NTSLabel
  Dim lbxx_DataOrdineCli As NTSLabel
  Dim edCPNEDispNetPz As NTSTextBoxNum
  Dim edCPNEDispoPz As NTSTextBoxNum
  Dim edCPNEImpPz As NTSTextBoxNum
  Dim edCPNEOrdPz As NTSTextBoxNum
  Dim edxx_DataOrdineCli As NTSTextBoxData
  Dim edxx_partita As NTSTextBoxNum

  '''''Bottoni e controlli fine ============================================================

  Private Sub GeneraECollegaOggettiARuntime()
    Try
      '''' ATTENZIONE LASCIARE QUESTE RIGHE NELL'ORDINE IN CUI SONO per quanto riguarda i MENU' e le GRIGLIE !!!

      ''''If GctlCreaControlloExt(, "CAMPO", Me, , , "", ) Then
      ''''  ZZMULTILINE NON USARE ... UTILIZZARE MEMOBOX
      ''''  obj = CType(NTSFindControlByName(Me, "CAMPO"), )
      ''''  obj.Parent =
      ''''  obj.AutoSize = '0 => FALSE
      ''''  obj.Height = 
      ''''  obj.Width = 
      ''''  obj.Anchor = '5 =>  AnchorStyles.Top Or AnchorStyles.Left
      ''''  obj.Dock =  ' 0 => DockStyle.None
      ''''  obj.BorderStyle = '0 => BorderStyle.None -1 => BorderStyle.Fixed3D
      ''''End If

      ''''If GctlCreaControlloExt(, "tlbSelDDTRic", Me, , , "", ) Then

      ''''  tlbSelDDTRic = CType(NTSFindControlByName(Me, "CAMPO"), )
      ''''  tlbSelDDTRic.Parent =
      ''''  tlbSelDDTRic.AutoSize = '0 => FALSE
      ''''  tlbSelDDTRic.Height = 
      ''''  tlbSelDDTRic.Width = 
      ''''  tlbSelDDTRic.Anchor = '5 =>  AnchorStyles.Top Or AnchorStyles.Left
      ''''  tlbSelDDTRic.Dock =  ' 0 => DockStyle.None
      ''''  tlbSelDDTRic.BorderStyle = '0 => BorderStyle.None -1 => BorderStyle.Fixed3D
      ''''End If
      '''' MENU' INIZIO ===========================================
      'If GctlCreaControlloExt("NTSBarMenuItem", "tlbSelDDTRic", Me, 0, 0, "tlbMnuRecord", "GRIC:0|TEXT:Seleziona DDT Ricevuti|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      tlbSelDDTRic = CType(NTSFindControlByName(Me, "tlbSelDDTRic"), NTSBarMenuItem)
      'End If
      'If GctlCreaControlloExt("NTSBarMenuItem", "tlb_Costr", Me, 0, 0, "tlbMnuRecord", "GRIC:0|TEXT:Costruttore Lamiere|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      tlb_Costr = CType(NTSFindControlByName(Me, "tlb_Costr"), NTSBarMenuItem)
      'End If
      'If GctlCreaControlloExt("NTSBarMenuItem", "tlbCPNEBNHHGEAR", Me, 0, 0, "tlbMnuRecord", "GRIC:0|TEXT:Generatore Articoli|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      tlbCPNEBNHHGEAR = CType(NTSFindControlByName(Me, "tlbCPNEBNHHGEAR"), NTSBarMenuItem)
      'End If
      'If GctlCreaControlloExt("NTSBarMenuItem", "tlbCpneScaricaFifoCDep", Me, 0, 0, "tlbMnuRecord", "GRIC:0|TEXT:Scarico FiFo C/Deposito|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      tlbCpneScaricaFifoCDep = CType(NTSFindControlByName(Me, "tlbCpneScaricaFifoCDep"), NTSBarMenuItem)
      'End If
      'If GctlCreaControlloExt("NTSBarMenuItem", "tlbCPNEMODPREZZORIGHE", Me, 0, 0, "tlbMnuRecord", "GRIC:0|TEXT:Modifica Prezzo Righe|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      tlbCPNEMODPREZZORIGHE = CType(NTSFindControlByName(Me, "tlbCPNEMODPREZZORIGHE"), NTSBarMenuItem)
      'End If
      'If GctlCreaControlloExt("NTSBarMenuItem", "tlbCPNECUP", Me, 0, 0, "tlbMnuFile", "GRIC:0|TEXT:Pubblica amministrazione|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      tlbSelDDTRic = CType(NTSFindControlByName(Me, "tlbCPNECUP"), NTSBarMenuItem)
      'End If
      'If GctlCreaControlloExt("NTSBarMenuItem", "tlbCPNEDetRigaTT", Me, 0, 0, "tlbMnuFile", "GRIC:0|TEXT:Dettaglio riga TT|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      tlbCPNEDetRigaTT = CType(NTSFindControlByName(Me, "tlbCPNEDetRigaTT"), NTSBarMenuItem)
      'End If
      'If GctlCreaControlloExt("NTSBarMenuItem", "tlbCPNEDUPLICADOC", Me, 0, 0, "tlbMnuFile", "GRIC:0|TEXT:Duplica Documento|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      tlbCPNEDUPLICADOC = CType(NTSFindControlByName(Me, "tlbCPNEDUPLICADOC"), NTSBarMenuItem)
      'End If
      'If GctlCreaControlloExt("NTSBarMenuItem", "tlbCPNESALVAPARTITA", Me, 0, 0, "tlbMnuFile", "GRIC:0|TEXT:Salva Partita|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      tlbCPNESALVAPARTITA = CType(NTSFindControlByName(Me, "tlbCPNESALVAPARTITA"), NTSBarMenuItem)
      'End If
      'If GctlCreaControlloExt("NTSBarMenuItem", "tlbCPNESALVAURGENZA", Me, 0, 0, "tlbMnuFile", "GRIC:0|TEXT:Salva Urgenza|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      tlbCPNESALVAURGENZA = CType(NTSFindControlByName(Me, "tlbCPNESALVAURGENZA"), NTSBarMenuItem)
      'End If
      'If GctlCreaControlloExt("NTSBarMenuItem", "tlbCPNECALCPARTITA", Me, 0, 0, "tlbMnuFile", "GRIC:0|TEXT:Calcola Numero Partita|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      tlbCPNECALCPARTITA = CType(NTSFindControlByName(Me, "tlbCPNECALCPARTITA"), NTSBarMenuItem)
      'End If
      'If GctlCreaControlloExt("NTSBarMenuItem", "tlbCPNESALVANOTE", Me, 0, 0, "tlbStrumenti", "GRIC:0|TEXT:Salva Note|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      tlbCPNESALVANOTE = CType(NTSFindControlByName(Me, "tlbCPNESALVANOTE"), NTSBarMenuItem)
      'End If
      '''' MENU' FINE ===========================================
      '''' COLONNE DI GRIGLIA INIZIO ============================
      'If GctlCreaControlloExt("NTSGridColumn", "ec_codartclifor", grvRighe, 0, 0, "", "GRIC:2|TEXT:Codice Articolo|NOME:Codice Articolo|VMIN:|VMAX:|MLEN:0|FORM:|NULL:0|CHEC:|UNCH:|DBAS:Codice Articolo|ZOOM:|ITEM:") Then
      ec_codartclifor = CType(grvRighe.Columns("ec_codartclifor"), NTSGridColumn)
      'End If
      'If GctlCreaControlloExt("NTSGridColumn", "hh_prezzosucolli", grvRighe, 0, 0, "", "GRIC:1|TEXT:Prezzo Su Colli|NOME:Prezzo Su Colli|VMIN:0|VMAX:999999999999999999|MLEN:0|FORM:#,##0.00|NULL:|CHEC:|UNCH:|DBAS:Prezzo Su Colli|ZOOM:|ITEM:") Then
      hh_prezzosucolli = CType(grvRighe.Columns("hh_prezzosucolli"), NTSGridColumn)
      'End If
      'If GctlCreaControlloExt("NTSGridColumn", "xx_cpnecolliprod", grvRighe, 0, 0, "", "GRIC:1|TEXT:Colli da produrre|NOME:Colli da produrre|VMIN:0|VMAX:999999999999999999|MLEN:0|FORM:#,##0.00|NULL:|CHEC:|UNCH:|DBAS:Colli da produrre|ZOOM:|ITEM:") Then
      xx_cpnecolliprod = CType(grvRighe.Columns("xx_cpnecolliprod"), NTSGridColumn)
      'End If
      'If GctlCreaControlloExt("NTSGridColumn", "hh_note2", grvRighe, 0, 0, "", "GRIC:6|TEXT:Note 2|NOME:Note 2|VMIN:|VMAX:|MLEN:0|FORM:|NULL:0|CHEC:|UNCH:|DBAS:Note 2|ZOOM:|ITEM:") Then
      hh_note2 = CType(grvRighe.Columns("hh_note2"), NTSGridColumn)
      'End If
      'If GctlCreaControlloExt("NTSGridColumn", "hh_distintaord", grvRighe, 0, 0, "", "GRIC:2|TEXT:Distinta|NOME:Distinta|VMIN:|VMAX:|MLEN:0|FORM:|NULL:0|CHEC:|UNCH:|DBAS:.|ZOOM:|ITEM:") Then
      hh_distintaord = CType(grvRighe.Columns("hh_distintaord"), NTSGridColumn)
      'End If
      'If GctlCreaControlloExt("NTSGridColumn", "xx_cpneqtaprod", grvRighe, 0, 0, "", "GRIC:1|TEXT:Qta da produrre|NOME:Qta da produrre|VMIN:0|VMAX:999999999999999999|MLEN:0|FORM:#,##0.00|NULL:|CHEC:|UNCH:|DBAS:Qta da produrre|ZOOM:|ITEM:") Then
      xx_cpneqtaprod = CType(grvRighe.Columns("xx_cpneqtaprod"), NTSGridColumn)
      'End If
      '''' COLONNE DI GRIGLIA FINE ============================
      '''' LABEL INIZIO ================================================
      'If GctlCreaControlloExt("NTSLabel", "lbCPNEDescMsg", Me, 20, 10, "pnCorpo", "GRIC:0|TEXT: |NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      lbCPNEDescMsg = CType(NTSFindControlByName(Me, "lbCPNEDescMsg"), NTSLabel)
      '  lbCPNEDescMsg.Parent = pnCorpo
      '  lbCPNEDescMsg.AutoSize = False
      '  lbCPNEDescMsg.Height = 23
      '  lbCPNEDescMsg.Width = 395
      '  lbCPNEDescMsg.Anchor = AnchorStyles.Top Or AnchorStyles.Left
      '  lbCPNEDescMsg.Dock = DockStyle.None
      '  lbCPNEDescMsg.BorderStyle = BorderStyle.Fixed3D
      'End If
      '''' da verificare con debug per vedere se i valori sono uguali e poi togliere le righe con i valori già impostati
      ''''lbPreList.Parent = pnCorpo
      ''''lbPreList.AutoSize = True
      'giorgio lbPreList.Top = 3
      ''''lbPreList.Left = 9
      ''''lbPreList.Height = 13
      ''''lbPreList.Width = 92
      ''''lbPreList.Anchor = AnchorStyles.Top Or AnchorStyles.Right
      ''''lbPreList.Dock = DockStyle.None
      ''''lbPreList.BorderStyle = BorderStyle.None

      ''''lbSconto.Parent = pnCorpo
      ''''lbSconto.AutoSize = True
      'giorgio lbSconto.Top = 3
      ''''lbSconto.Left = 279
      ''''lbSconto.Height = 13
      ''''lbSconto.Width = 64
      ''''lbSconto.Anchor = AnchorStyles.Top Or AnchorStyles.Right
      ''''lbSconto.Dock = DockStyle.None
      ''''lbSconto.BorderStyle = BorderStyle.None

      'If GctlCreaControlloExt("NTSLabel", "lbCPNEPartita", Me, 172, 5, "pnTestataSx", "GRIC:0|TEXT:Partita|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      lbCPNEPartita = CType(NTSFindControlByName(Me, "lbCPNEPartita"), NTSLabel)
      '  lbCPNEPartita.Parent = pnTestataSx
      '  lbCPNEPartita.AutoSize = True
      '  lbCPNEPartita.Height = 13
      '  lbCPNEPartita.Width = 39
      '  lbCPNEPartita.Anchor = AnchorStyles.Top Or AnchorStyles.Left
      '  lbCPNEPartita.Dock = DockStyle.None
      '  lbCPNEPartita.BorderStyle = BorderStyle.None
      'End If
      'If GctlCreaControlloExt("NTSLabel", "lbxx_DataOrdineCli", Me, 7, 530, "pnTestataClforn", "GRIC:0|TEXT:Data ordine del Cliente|NOME:|VMIN:|VMAX:|MLEN:|FORM:|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      lbxx_DataOrdineCli = CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel)
      'lbxx_DataOrdineCli.Parent = pnTestataClforn
      'lbxx_DataOrdineCli.AutoSize = False
      'lbxx_DataOrdineCli.Height = 18
      'lbxx_DataOrdineCli.Width = 120
      'lbxx_DataOrdineCli.Anchor = AnchorStyles.Top Or AnchorStyles.Left
      'lbxx_DataOrdineCli.Dock = DockStyle.None
      'lbxx_DataOrdineCli.BorderStyle = BorderStyle.Fixed3D
      'End If
      '''' LABEL FINE ================================================
      '''' TEXT BOX INIZIO ================================================
      'If GctlCreaControlloExt("NTSTextBoxNum", "edCPNEDispNetPz", Me, 0, 630, "pnCorpo", "GRIC:0|TEXT:|NOME:.|VMIN:-999999999999999999|VMAX:999999999999999999|MLEN:0|FORM:#,##0|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      edCPNEDispNetPz = CType(NTSFindControlByName(Me, "edCPNEDispNetPz"), NTSTextBoxNum)
      '  edCPNEDispNetPz.Parent = pnCorpo
      '  edCPNEDispNetPz.Height = 20
      '  edCPNEDispNetPz.Width = 50
      '  edCPNEDispNetPz.Anchor = AnchorStyles.Top Or AnchorStyles.Left
      '  edCPNEDispNetPz.Dock = DockStyle.None
      'End If
      'If GctlCreaControlloExt("NTSTextBoxNum", "edCPNEDispoPz", Me, 0, 517, "pnCorpo", "GRIC:0|TEXT:|NOME:.|VMIN:-999999999999999999|VMAX:999999999999999999|MLEN:0|FORM:#,##0|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      edCPNEDispoPz = CType(NTSFindControlByName(Me, "edCPNEDispoPz"), NTSTextBoxNum)
      '  edCPNEDispoPz.Parent = pnCorpo
      '  edCPNEDispoPz.Height = 20
      '  edCPNEDispoPz.Width = 43
      '  edCPNEDispoPz.Anchor = AnchorStyles.Top Or AnchorStyles.Left
      '  edCPNEDispoPz.Dock = DockStyle.None
      'End If
      'If GctlCreaControlloExt("NTSTextBoxNum", "edCPNEImpPz", Me, 20, 517, "pnCorpo", "GRIC:0|TEXT:|NOME:.|VMIN:-999999999999999999|VMAX:999999999999999999|MLEN:0|FORM:#,##0|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:GRIC:0|TEXT:|NOME:.|VMIN:-999999999999999999|VMAX:999999999999999999|MLEN:0|FORM:#,##0|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      edCPNEImpPz = CType(NTSFindControlByName(Me, "edCPNEImpPz"), NTSTextBoxNum)
      '  edCPNEImpPz.Parent = pnCorpo
      '  edCPNEImpPz.Height = 20
      '  edCPNEImpPz.Width = 43
      '  edCPNEImpPz.Anchor = AnchorStyles.Top Or AnchorStyles.Left
      '  edCPNEImpPz.Dock = DockStyle.None
      'End If
      'If GctlCreaControlloExt("NTSTextBoxNum", "edCPNEOrdPz", Me, 20, 630, "pnCorpo", "GRIC:0|TEXT:|NOME:.|VMIN:-999999999999999999|VMAX:999999999999999999|MLEN:0|FORM:#,##0|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:GRIC:0|TEXT:|NOME:.|VMIN:-999999999999999999|VMAX:999999999999999999|MLEN:0|FORM:#,##0|NULL:|CHEC:|UNCH:|DBAS:|ZOOM:|ITEM:") Then
      edCPNEOrdPz = CType(NTSFindControlByName(Me, "edCPNEOrdPz"), NTSTextBoxNum)
      '  edCPNEOrdPz.Parent = pnCorpo
      '  edCPNEOrdPz.Height = 20
      '  edCPNEOrdPz.Width = 50
      '  edCPNEOrdPz.Anchor = AnchorStyles.Top Or AnchorStyles.Left
      '  edCPNEOrdPz.Dock = DockStyle.None
      'End If

      ''''edPreList.Parent = pnCorpo
      'giorgio edPreList.Top = 0
      ''''edPreList.Left = 107
      ''''edPreList.Height = 20
      ''''edPreList.Width = 80
      ''''edPreList.Anchor = AnchorStyles.Top Or AnchorStyles.Left
      ''''edPreList.Dock = DockStyle.None

      ''''edSconto.Parent = pnCorpo
      'giorgio edSconto.Top = 0
      ''''edSconto.Left = 344
      ''''edSconto.Height = 20
      ''''edSconto.Width = 57
      ''''edSconto.Anchor = AnchorStyles.Top Or AnchorStyles.Right
      ''''edSconto.Dock = DockStyle.None

      ''''edUltCost.Parent = pnCorpo
      'giorgio edUltCost.Top = 0
      ''''edUltCost.Left = 193
      ''''edUltCost.Height = 20
      ''''edUltCost.Width = 80
      ''''edUltCost.Anchor = AnchorStyles.Top Or AnchorStyles.Right
      ''''edUltCost.Dock = DockStyle.None

      'If GctlCreaControlloExt("NTSTextBoxData", "edxx_DataOrdineCli", Me, 25, 530, "pnTestataClforn", "GRIC:0|TEXT:|NOME:.|VMIN:01/01/1900 00:00:00|VMAX:31/12/2099 00:00:00|MLEN:0|FORM:|NULL:-1|CHEC:|UNCH:|DBAS:TESTA.et_datpar|ZOOM:|ITEM:") Then
      edxx_DataOrdineCli = CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData)
      '  edxx_DataOrdineCli.Parent = pnTestataClforn
      '  edxx_DataOrdineCli.Height = 20
      '  edxx_DataOrdineCli.Width = 100
      '  edxx_DataOrdineCli.Anchor = AnchorStyles.Top Or AnchorStyles.Left
      '  edxx_DataOrdineCli.Dock = DockStyle.None
      'End If

      'If GctlCreaControlloExt("NTSTextBoxNum", "edxx_partita", Me, 169, 98, "pnTestataSx", "GRIC:0|TEXT:|NOME:.|VMIN:-999999999999999999|VMAX:999999999999999999|MLEN:0|FORM:#,##0|NULL:|CHEC:|UNCH:|DBAS:TESTA.et_codstag|ZOOM:|ITEM:") Then
      edxx_partita = CType(NTSFindControlByName(Me, "edxx_partita"), NTSTextBoxNum)
      '  edxx_partita.Parent = pnTestataSx
      '  edxx_partita.Height = 20
      '  edxx_partita.Width = 52
      '  edxx_partita.Anchor = AnchorStyles.Top Or AnchorStyles.Left
      '  edxx_partita.Dock = DockStyle.None
      'End If
      ''''' TEXT BOX FINE ==================================================


      AddHandler CType(NTSFindControlByName(Me, "tlbSelDDTRic"), NTSBarMenuItem).ItemClick, AddressOf tlbSelDDTRic_ItemClick
      AddHandler CType(NTSFindControlByName(Me, "tlb_Costr"), NTSBarMenuItem).ItemClick, AddressOf tlb_Costr_Click
      CType(NTSFindControlByName(Me, "lbCPNEDescMsg"), NTSLabel).ForeColor = Drawing.Color.Red
      AddHandler CType(NTSFindControlByName(Me, "tlbCPNEBNHHGEAR"), NTSBarMenuItem).ItemClick, AddressOf tlbCPNEBNHHGEAR_Click
      AddHandler CType(NTSFindControlByName(Me, "tlbCpneScaricaFifoCDep"), NTSBarMenuItem).ItemClick, AddressOf tlbCpneScaricoFifoCDep_ItemClick
      CType(NTSFindControlByName(Me, "tlbCpneScaricaFifoCDep"), NTSBarMenuItem).ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F10)
      AddHandler CType(NTSFindControlByName(Me, "tlbCPNECUP"), NTSBarMenuItem).ItemClick, AddressOf tlbCPNECUP_ItemClick
      NtsBarManager1.Items("tlbCPNECUP").ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F11)
      AddHandler CType(NTSFindControlByName(Me, "tlbCPNECALCPARTITA"), NTSBarMenuItem).ItemClick, AddressOf tlbCPNECALCPARTITA_ItemClick
      NtsBarManager1.Items("tlbCPNECALCPARTITA").ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F12)
      AddHandler CType(NTSFindControlByName(Me, "tlbCPNESALVAPARTITA"), NTSBarMenuItem).ItemClick, AddressOf tlbCPNESALVAPARTITA_ItemClick
      NtsBarManager1.Items("tlbCPNESALVAPARTITA").ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F6)
      AddHandler CType(NTSFindControlByName(Me, "tlbCPNESALVAURGENZA"), NTSBarMenuItem).ItemClick, AddressOf tlbCPNESALVAURGENZA_ItemClick
      NtsBarManager1.Items("tlbCPNESALVAURGENZA").ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F8)
      AddHandler CType(NTSFindControlByName(Me, "tlbCPNEMODPREZZORIGHE"), NTSBarMenuItem).ItemClick, AddressOf tlbCPNEMODPREZZORIGHE_ItemClick
      NtsBarManager1.Items("tlbCPNEMODPREZZORIGHE").ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F5)
      AddHandler CType(NTSFindControlByName(Me, "tlbCPNESALVANOTE"), NTSBarMenuItem).ItemClick, AddressOf tlbCPNESALVANOTE_ItemClick

      CType(NTSFindControlByName(Me, "lbCPNEPartita"), NTSLabel).ForeColor = Drawing.Color.Red
      CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).ForeColor = Drawing.Color.Red

      If UCase(oMenu.GetSettingBus("Bsorgsor", "OPZIONI", ".", "GestionePartita", "N", " ", "N")) = "S" Then
        CType(NTSFindControlByName(Me, "lbCPNEPartita"), NTSLabel).Visible = True
        CType(NTSFindControlByName(Me, "edxx_partita"), NTSTextBoxNum).Visible = True
        CType(NTSFindControlByName(Me, "tlbCPNECALCPARTITA"), NTSBarMenuItem).Visible = True
        CType(NTSFindControlByName(Me, "tlbCPNESALVAPARTITA"), NTSBarMenuItem).Visible = True
        CType(NTSFindControlByName(Me, "tlbCPNESALVAPARTITA"), NTSBarMenuItem).Enabled = False
        CType(NTSFindControlByName(Me, "tlbCPNESALVAURGENZA"), NTSBarMenuItem).Visible = True
        CType(NTSFindControlByName(Me, "tlbCPNESALVAURGENZA"), NTSBarMenuItem).Enabled = False
      Else
        CType(NTSFindControlByName(Me, "lbCPNEPartita"), NTSLabel).Visible = False
        CType(NTSFindControlByName(Me, "edxx_partita"), NTSTextBoxNum).Visible = False
        CType(NTSFindControlByName(Me, "tlbCPNECALCPARTITA"), NTSBarMenuItem).Visible = False
        CType(NTSFindControlByName(Me, "tlbCPNESALVAPARTITA"), NTSBarMenuItem).Visible = False
        CType(NTSFindControlByName(Me, "tlbCPNESALVAURGENZA"), NTSBarMenuItem).Visible = False
      End If
      If UCase(oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneOrdiniPrioritari", "N", " ", "N")) = "S" Then
        If InStr(UCase(oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "AbilitaOperatoriGestioneOrdiniPrioritari", "N", " ", "N")), UCase(oApp.User.Nome)) > 0 Then
          CType(NTSFindControlByName(Me, "tlbCPNESALVAURGENZA"), NTSBarMenuItem).Visible = True
          CType(NTSFindControlByName(Me, "tlbCPNESALVAURGENZA"), NTSBarMenuItem).Enabled = True
        Else
          CType(NTSFindControlByName(Me, "tlbCPNESALVAURGENZA"), NTSBarMenuItem).Visible = False
          CType(NTSFindControlByName(Me, "tlbCPNESALVAURGENZA"), NTSBarMenuItem).Enabled = False
        End If
        CType(NTSFindControlByName(Me, "lbEt_commeca"), NTSLabel).Text = "Comm/Urgenza."
        CType(NTSFindControlByName(Me, "lbEt_commeca"), NTSLabel).ForeColor = Drawing.Color.Red
        CType(NTSFindControlByName(Me, "edEt_subcommeca"), NTSTextBoxStr).ForeColor = Drawing.Color.Red
      Else
        CType(NTSFindControlByName(Me, "tlbCPNESALVAURGENZA"), NTSBarMenuItem).Visible = False
        CType(NTSFindControlByName(Me, "tlbCPNESALVAURGENZA"), NTSBarMenuItem).Enabled = False

        CType(NTSFindControlByName(Me, "lbEt_commeca"), NTSLabel).Text = "Commessa/subc."
        CType(NTSFindControlByName(Me, "lbEt_commeca"), NTSLabel).ForeColor = Drawing.Color.Black
        CType(NTSFindControlByName(Me, "edEt_subcommeca"), NTSTextBoxStr).ForeColor = Drawing.Color.Black
      End If

      If oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneDataOrdineCliente", "N", " ", "N") = "S" Then
        CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = True
        CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = True
        If InStr(UCase(oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneDataOrdineClienteOperatoriNonAbilitati", "", " ", "")), (oApp.User.Nome)) > 0 Then
          CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Enabled = False
        Else
          CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Enabled = True
        End If
      Else
        CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = False
        CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = False
      End If


      AddHandler CType(NTSFindControlByName(Me, "tlbCPNEDUPLICADOC"), NTSBarMenuItem).ItemClick, AddressOf tlbCPNEDUPLICADOC_ItemClick

      tlbCPNEDUPLICADOC.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F11)

      OCLEStd.sGestOrdineConfermato = UCase(oMenu.GetSettingBus("BSHHGSOR", "OPTPERS", ".", "GestOrdineConfermato", "N", " ", "N"))

      AddHandler CType(NTSFindControlByName(Me, "tlbCPNEDetRigaTT"), NTSBarMenuItem).ItemClick, AddressOf tlbCPNEDetRigaTT_ItemClick
      tlbCPNEDetRigaTT.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F3)

      OCLEStd.strScaricoFifoMultiGrezzi = UCase(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "CPNE", "BNVEBOLL", "OPZIONI", "ScaricoFifoMultiGrezzi", "N", " ", "N"))
      OCLEStd.intScaricoFifoMultiGrezziMarca = CInt(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "CPNE", "BNVEBOLL", "OPZIONI", "ScaricoFifoMultiGrezziMarca", "999", " ", "999"))


      ''''    Case "FRMORIMPE"
      ''''  FRXORIMPE = oIn
      ''''  CType(FRXORIMPE.grvRighe.Columns("ec_codartclifor"), NTSGridColumn).NTSForzaVisZoom = True
      ''''  RemoveHandler FRXORIMPE.tlbZoom.ItemClick, AddressOf FRXORIMPE.tlbZoom_ItemClick
      ''''  AddHandler FRXORIMPE.tlbZoom.ItemClick, AddressOf FRXORIMPE_tlbZoom_ItemClick
      ''''  End Select
      ''''Catch ex As Exception
      ''''  Dim strErr As String = CLN__STD.GestError(ex, Nothing, "", oApp.InfoError, oApp.ErrorLogFile, True)
      ''''End Try


    Catch ex As Exception
      MsgBox(ex.ToString)
    End Try
  End Sub

  Public Overrides Function ApriVisualizzaListini(ByVal nTipoCol As Integer) As Boolean
    Return MyBase.ApriVisualizzaListini(nTipoCol)
  End Function

  Public Overloads Function Init(ByRef Menu As CLE__MENU, ByRef Param As CLE__CLDP, Optional ByVal Ditta As String = "", Optional ByRef SharedControls As CLE__EVNT = Nothing) As Boolean
    Init = MyBase.Init(Menu, Param, Ditta, SharedControls)
    If Init Then
      OCLEStd = CType(oCleGsor, CLBORGSOR)
    End If
  End Function

  Public Overrides Sub tlbApri_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    Dim strMsg As String = ""
    NtsBarManager1.Items("tlbCPNESALVANOTE").Enabled = False
    CType(NTSFindControlByName(Me, "lbCPNEDescMsg"), NTSLabel).Text = ""
    OCLEStd.strScorporo_salva = ""
    OCLEStd.bDocInDuplicazione = False
    ' Gestione Agenti inizio
    'MyBase.tlbApri_ItemClick(sender, e)
    If Me.cbTipoDoc.SelectedItem Is "Impegno cliente" And InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), Me.edSerieDoc.Text) > 0 Then
      If OCLEStd.CPNEEsisteOrdineCreatoVbNet("R", CInt(Me.edAnnoDoc.Text), Me.edSerieDoc.Text, CInt(Me.edNumDoc.Text)) Then
        If Not OCLEStd.CPNEOrdineCreatoVbNet("R", CInt(Me.edAnnoDoc.Text), Me.edSerieDoc.Text, CInt(Me.edNumDoc.Text)) Then
          oApp.MsgBoxErr("Questo documento deve essere gestito con VB6")
          Exit Sub
        End If
      End If
    End If
    If OCLEStd.bGestioneAgentiAgente Then
      If OCLEStd.CPNEAgentiDocValido(cbTipoDoc.SelectedValue.ToString, CInt(edAnnoDoc.Text), edSerieDoc.Text, CInt(edNumDoc.Text)) Then
        MyBase.tlbApri_ItemClick(sender, e)
        If OCLEStd.bGestioneAgentiAgente Then
          'edSerieDoc.Enabled = False
        End If
      End If
    Else
      MyBase.tlbApri_ItemClick(sender, e)
    End If
    ' Gestione Agenti fine
    grvRighe_NTSFocusedRowChanged(Nothing, Nothing)

    Dim bmodifica As Boolean = True
    If dsGsor.Tables("testa").Rows.Count > 0 Then
      If oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSORGSOR", "OPZIONI", ".", "DisabilitaModificaICOPCLavoro", "S", " ", "S") = "S" Then
        If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" And InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieDDTRConCli", " ", " ", " "), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) > 0 Then
          strMsg = "Non modificare questo documento" & vbCr & "Modificare il corrispondente ddt ricevuto"
          bmodifica = False
        End If
        If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "H" Then
          'If oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHDBLP", "OPZIONI", ".", "GestSerieClavInOc", "N", " ", "N") = "S" Then
          '  Dim strSerieClav As String = oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHDBLP", "OPZIONI", ".", "GestSerieClavInOcSerie" & dsGsor.Tables("testa").Rows(0)!et_serie.ToString, "9", " ", "9")
          '  If strSerieClav <> "9" Then
          '    If strSerieClav = dsGsor.Tables("testa").Rows(0)!et_serie.ToString Then
          bmodifica = False
          '    End If
          '  End If
          'End If
          strMsg = "Non modificare questo documento" & vbCr & "Modificare il corrispondente ddt ricevuto/impegno cliente c/deposito"
        End If

        If UCase(oMenu.GetSettingBus("BSHHGSOR", "OPTPERS", ".", "GestOrdineConfermato", "N", " ", "N")) = "S" Then
          If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" And InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) > 0 Then
            If dsGsor.Tables("corpo").Rows.Count > 0 Then
              If OCLEStd.CPNEDocNonModificabileCVenditaCdeposito Then
                bmodifica = False
                strMsg = "Ordine non modificabile. Almeno 1 riga è avanzata in produzione"
              End If
            End If
          End If

          If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" And InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSORGSOR", "OPZIONI", ".", "CDepSerieOrd", "A", " ", "A"), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) > 0 Then
            If dsGsor.Tables("corpo").Rows.Count > 0 Then
              If OCLEStd.CPNEDocNonModificabileCVenditaCdeposito Then
                bmodifica = False
                strMsg = "Ordine non modificabile. Almeno 1 riga è avanzata in produzione"
              End If
            End If
          End If
        End If

        If bmodifica = False Then
          CPNEAttivaDisattivaSavaCanc("D")
          oApp.MsgBoxErr(strMsg)
        End If
      End If


      If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" And InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) > 0 Then
        If InStr(UCase(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHGSOR", "OPZIONI", ".", "AbilitaOperatoriGestioneSospeso", "N", " ", "N")), UCase(oApp.User.Nome)) = 0 Then
          Me.ckEt_sospeso.Enabled = False
        Else
          Me.ckEt_sospeso.Enabled = True
        End If
      End If

      If UCase(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHGSOR", "OPZIONI", ".", "AbilitaOperatoriSbloccoOrdiniGestione", "N", " ", "N")) = "S" Then
        If InStr(UCase(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHGSOR", "OPZIONI", ".", "AbilitaOperatoriSbloccoOrdiniOperatori", "N", " ", "N")), UCase(oApp.User.Nome)) > 0 Then
          If ckEt_confermato.Checked Or ckEt_rilasciato.Checked Or ckEt_flevas.Checked Then
            cbEt_blocco.Enabled = False
          Else
            cbEt_blocco.Enabled = True
          End If
        Else
          cbEt_blocco.Enabled = False
        End If
      End If

      If InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) > 0 Then
        If UCase(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHGSOR", "OPZIONI", ".", "GestioneSoloASaldoDaProdurre", "N", " ", "N")) = "S" Then
          ckEt_soloasa.Text = "Da Produrre"
          ckEt_soloasa.ForeColor = Drawing.Color.Red
        Else
          ckEt_soloasa.Text = "&Solo a saldo"
          ckEt_soloasa.ForeColor = Drawing.Color.Black
        End If
        If UCase(oMenu.GetSettingBus("BSHHGSOR", "OPTPERS", ".", "GestOrdineConfermato", "N", " ", "N")) = "S" Then
          ckEt_confermato.ForeColor = Drawing.Color.Red
          ckEt_rilasciato.ForeColor = Drawing.Color.Red
        Else
          ckEt_confermato.ForeColor = Drawing.Color.Black
          ckEt_rilasciato.ForeColor = Drawing.Color.Black
        End If

      Else
        ckEt_soloasa.Text = "&Solo a saldo"
        ckEt_soloasa.ForeColor = Drawing.Color.Black
        ckEt_confermato.ForeColor = Drawing.Color.Black
        ckEt_rilasciato.ForeColor = Drawing.Color.Black

      End If

      If oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneDataOrdineCliente", "N", " ", "N") = "S" Then
        If InStr(oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneDataOrdineClienteSerie", "0", " ", "0"), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) > 0 Then
          If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" Then
            If dsGsor.Tables("testa").Rows(0)!et_datpar.ToString = "" Then
              dsGsor.Tables("testa").Rows(0)!et_datpar = CDate(dsGsor.Tables("testa").Rows(0)!et_datdoc)
            End If
            'If edEt_datpar.Text = "" Then
            '  edEt_datpar.Text = edet_datdoc.Text
            'End If
          Else
            CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = False
            CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = False
          End If
        Else
          CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = False
          CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = False
        End If
        If InStr(UCase(oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneDataOrdineClienteOperatoriNonAbilitati", "", " ", "")), (oApp.User.Nome)) = 0 Then
          If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" Then
            If InStr(oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneDataOrdineClienteSerie", "0", " ", "0"), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) > 0 Then
              CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = True
              CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = True
              'oApp.MsgBoxInfo("Attenzione!!! La data ordine del Cliente è: " & edEt_datpar.Text & ", modificarla se diversa.")
            Else
              CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = False
              CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = False
            End If
          End If
          edEt_datpar.Enabled = True
        Else
          edEt_datpar.Enabled = False
        End If
      Else
        CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = False
        CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = False
      End If
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Public Overrides Sub tlbNuovo_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    tlbCPNESALVANOTE.Enabled = False
    OCLEStd.strScorporo_salva = ""
    OCLEStd.bDocInDuplicazione = False
    MyBase.tlbNuovo_ItemClick(sender, e)
    If dsGsor.Tables("testa").Rows.Count > 0 Then
      If InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) > 0 Then
        If UCase(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHGSOR", "OPZIONI", ".", "GestioneSoloASaldoDaProdurre", "N", " ", "N")) = "S" Then
          ckEt_soloasa.Text = "Da Produrre"
          ckEt_soloasa.ForeColor = Drawing.Color.Red
        Else
          ckEt_soloasa.Text = "&Solo a saldo"
          ckEt_soloasa.ForeColor = Drawing.Color.Black
        End If
        If UCase(oMenu.GetSettingBus("BSHHGSOR", "OPTPERS", ".", "GestOrdineConfermato", "N", " ", "N")) = "S" Then
          ckEt_confermato.ForeColor = Drawing.Color.Red
          ckEt_rilasciato.ForeColor = Drawing.Color.Red
        Else
          ckEt_confermato.ForeColor = Drawing.Color.Black
          ckEt_rilasciato.ForeColor = Drawing.Color.Black
        End If

      Else
        ckEt_soloasa.Text = "&Solo a saldo"
        ckEt_soloasa.ForeColor = Drawing.Color.Black
        ckEt_confermato.ForeColor = Drawing.Color.Black
        ckEt_rilasciato.ForeColor = Drawing.Color.Black

      End If

      If oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneDataOrdineCliente", "N", " ", "N") = "S" Then
        If InStr(oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneDataOrdineClienteSerie", "0", " ", "0"), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) > 0 Then
          If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" Then
            lbxx_DataOrdineCli.Visible = True
            edxx_DataOrdineCli.Visible = True
            dsGsor.Tables("testa").Rows(0)!et_datpar = Date.Now
            'edEt_datpar.Text = Date.Now
            'oApp.MsgBoxInfo("Attenzione!!! La data ordine del Cliente è: " & CDate(dsGsor.Tables("testa").Rows(0)!et_datpar) & ", modificarla se diversa.")
          Else
            lbxx_DataOrdineCli.Visible = False
            edxx_DataOrdineCli.Visible = False
          End If
        Else
          lbxx_DataOrdineCli.Visible = False
          edxx_DataOrdineCli.Visible = False
        End If
      Else
        lbxx_DataOrdineCli.Visible = False
        edxx_DataOrdineCli.Visible = False
      End If
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub CPNEAttivaDisattivaSavaCanc(ByVal strTipo As String)
TRY
    If strTipo = "A" Then
      tlbSalva.Enabled = True
      tlbCancella.Enabled = True
      NtsBarManager1.Items("tlbCPNESALVAPARTITA").Enabled = False
      'NtsBarManager1.Items("tlbCPNESALVAURGENZA").Enabled = False

      NtsBarManager1.Items("tlbCPNESALVANOTE").Enabled = False
    Else
      tlbSalva.Enabled = False
      tlbCancella.Enabled = False
      If oMenu.GetSettingBus("Bsorgsor", "OPZIONI", ".", "GestionePartita", "N", " ", "N") = "S" Then
        NtsBarManager1.Items("tlbCPNESALVAPARTITA").Enabled = True
      End If
      If UCase(oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneOrdiniPrioritari", "N", " ", "N")) = "S" Then
        If InStr(UCase(oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "AbilitaOperatoriGestioneOrdiniPrioritari", "N", " ", "N")), UCase(oApp.User.Nome)) > 0 Then
          NtsBarManager1.Items("tlbCPNESALVAURGENZA").Enabled = True
        End If
      End If
      If UCase(oMenu.GetSettingBus("BSHHGSOR", "OPTPERS", ".", "GestOrdineConfermato", "N", " ", "N")) = "S" Then
        NtsBarManager1.Items("tlbCPNESALVANOTE").Enabled = True
      End If
    End If

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Public Overrides Sub ckEt_scorpo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
TRY
    MyBase.ckEt_scorpo_CheckedChanged(sender, e)
    If UCase(oMenu.GetSettingBus("BSVEBOLL", "OPZIONI", ".", "GestioneCorrispIvaEsclusa", "N", " ", "N")) = "S" Then
      ''''''''''''GctlSetVisEnab(ec_preziva, True)
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Public Overrides Sub Bindcontrols()
TRY
    edxx_partita.NTSDbField = "TESTA.Et_codstag"
    'NTSFindControlByName(Me, "edxx_DataOrdineCli").NTSDbField = "TESTA.Et_datpar"
    MyBase.Bindcontrols()

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub FROORGSOR_ActivatedFirst(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ActivatedFirst
TRY
    pnTestataClforn.Width = 650

    ' Gestione Agenti inizio
    Dim strGestioneAgenti As String = oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "CPNE", "BNORGSOR", "OPZIONI", "GestioneAgenti", "N", " ", "N")
    If strGestioneAgenti = "S" Then
      OCLEStd.bGestioneAgenti = True
    Else
      OCLEStd.bGestioneAgenti = False
    End If
    If Not OCLEStd.bGestioneAgenti Then
      OCLEStd.bGestioneAgentiAgente = False
      Exit Sub
    End If
    Dim bValido As Boolean = True
    If InStr(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiElenco", "", " ", ""), oApp.User.Nome) > 0 Then
      If oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiAgenteSerie" & oApp.User.Nome, "", " ", "") = "" Then
        oApp.MsgBoxInfo("L'Agente " & oApp.User.Nome & " non ha l'opzione di registro: 'CPNE/BNORGSOR/OPZIONI/GestioneAgentiAgenteSerie" & oApp.User.Nome & "'")
        bValido = False
      Else
        If InStr(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiAgenteSerie" & oApp.User.Nome, "", " ", ""), ";") > 0 Then
          If InStr(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiSerie", "", " ", ""), Mid(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiAgenteSerie" & oApp.User.Nome, "", " ", ""), 1, InStr(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiAgenteSerie" & oApp.User.Nome, "", " ", ""), ";") - 1)) = 0 Then
            oApp.MsgBoxInfo("L'Agente " & oApp.User.Nome & " ha una Serie errata nell'opzione di registro: 'CPNE/BNORGSOR/OPZIONI/GestioneAgentiAgenteSerie" & oApp.User.Nome & "'")
            bValido = False
          End If

          If InStr(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiSerie", "", " ", ""), Mid(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiAgenteSerie" & oApp.User.Nome, "", " ", ""), InStr(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiAgenteSerie" & oApp.User.Nome, "", " ", ""), ";") + 1)) = 0 Then
            oApp.MsgBoxInfo("L'Agente " & oApp.User.Nome & " ha una Serie errata nell'opzione di registro: 'CPNE/BNORGSOR/OPZIONI/GestioneAgentiAgenteSerie" & oApp.User.Nome & "'")
            bValido = False
          End If
        Else
          If InStr(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiSerie", "", " ", ""), oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiAgenteSerie" & oApp.User.Nome, "", " ", "")) = 0 Then
            oApp.MsgBoxInfo("L'Agente " & oApp.User.Nome & " ha una Serie errata nell'opzione di registro: 'CPNE\BNORGSOR/OPZIONI/GestioneAgentiAgenteSerie" & oApp.User.Nome & "'")
            bValido = False
          End If
        End If
        If bValido Then
          If InStr(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiAgenteSerie" & oApp.User.Nome, "", " ", ""), ";") > 0 Then
            OCLEStd.sGestioneAgentiAgenteSerie = Mid(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiAgenteSerie" & oApp.User.Nome, "", " ", ""), 1, InStr(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiAgenteSerie" & oApp.User.Nome, "", " ", ""), ";") - 1)
          Else
            OCLEStd.sGestioneAgentiAgenteSerie = oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiAgenteSerie" & oApp.User.Nome, "", " ", "")
          End If
        End If
      End If
      If bValido Then
        OCLEStd.sGestioneAgentiAgenteCodice = oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiAgenteCodice" & oApp.User.Nome, "", " ", "")
        OCLEStd.sGestioneAgentiAgenteCodice = Mid(OCLEStd.sGestioneAgentiAgenteCodice, 2)
        OCLEStd.sGestioneAgentiAgenteCodice = Mid(OCLEStd.sGestioneAgentiAgenteCodice, 1, InStr(OCLEStd.sGestioneAgentiAgenteCodice, ";") - 1)
        OCLEStd.sGestioneAgentiAgenteTipoBf = oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiTipoBfSerie" & OCLEStd.sGestioneAgentiAgenteSerie, "1", " ", "1")
        OCLEStd.sGestioneAgentiAgenteMagaz = oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestioneAgentiMagazSerie" & OCLEStd.sGestioneAgentiAgenteSerie, "201", " ", "201")

        OCLEStd.bGestioneAgentiAgente = True


      End If
    End If
    If bValido = False Then
      Me.Close()
    End If

    If OCLEStd.bGestioneAgentiAgente Then
      edSerieDoc.Text = OCLEStd.sGestioneAgentiAgenteSerie
      'edSerieDoc.Enabled = False

    End If
    ' Gestione Agenti fine

    'Me.MinimumSize = New System.Drawing.Size(Me.MinimumSize.Width + 200, Me.MinimumSize.Height)
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  ' Gestione Agenti inizio
  Public Overrides Sub tlbCancella_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" Then
      If OCLEStd.CPNEDocNonCancellabile() Then
        Exit Sub
      End If
    End If
    '''' giorgio originale prima fusione bx e bo
    ''''If OCLEStd.bGestioneAgentiAgente Then
    ''''  MyBase.tlbCancella_ItemClick(sender, e)
    ''''  'edSerieDoc.Enabled = False
    ''''Else
    ''''  MyBase.tlbCancella_ItemClick(sender, e)
    ''''End If
    MyBase.tlbCancella_ItemClick(sender, e)
    'If Oclestd.SalvaOrdine("D") Then
    If oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSORGSOR", "OPZIONI", ".", "GestioneDdtResoCDep", "N", " ", "N") = "S" Then
      If Not IsNothing(grvRighe.NTSGetCurrentDataRow) Then
        If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" Then
          If CInt(dsGsor.Tables("testa").Rows(0)!hh_NumDdtReso) > 0 Then ' è c/deposito
            Dim CPNEStrTipo As String = NTSCStr(dsGsor.Tables("testa").Rows(0)!et_tipork)
            Dim CPNEIntAnno As Integer = NTSCInt(dsGsor.Tables("testa").Rows(0)!et_anno)
            Dim CPNEStrSerie As String = NTSCStr(dsGsor.Tables("testa").Rows(0)!et_serie)
            Dim CPNEIntNumOrd As Integer = NTSCInt(dsGsor.Tables("testa").Rows(0)!et_numdoc)
            ' controlla se la cancellazione dell'ordine è andata a buon fine
            If Not OCLEStd.CPNEEsisteOrdine(DittaCorrente, CPNEStrTipo, CPNEIntAnno, CPNEStrSerie, CPNEIntNumOrd) Then

              Dim CPNEStrTipoDoc As String = NTSCStr(dsGsor.Tables("testa").Rows(0)!hh_TiporkDdtReso)
              Dim CPNEIntAnnoDoc As Integer = NTSCInt(dsGsor.Tables("testa").Rows(0)!hh_AnnoDdtReso)
              Dim CPNEStrSerieDoc As String = NTSCStr(dsGsor.Tables("testa").Rows(0)!hh_SerieDdtReso)
              Dim CPNEIntNumDoc As Integer = NTSCInt(dsGsor.Tables("testa").Rows(0)!hh_NumDdtReso)
              If OCLEStd.CPNEEsisteDdtReso(DittaCorrente, CPNEStrTipoDoc, CPNEIntAnnoDoc, CPNEStrSerieDoc, CPNEIntNumDoc) Then

                ' cancella il ddt emesso

                If CPNECreaDoc("D", CPNEStrTipoDoc, CPNEIntAnnoDoc, CPNEStrSerieDoc, CPNEIntNumDoc) Then
                  oApp.MsgBoxErr("Il DDT Emesso N. " & CPNEIntNumDoc & "/" & CPNEStrSerieDoc & " Anno " & CPNEIntAnnoDoc & " è stato cancellato")
                Else
                  oApp.MsgBoxErr("Non è stato possibile cancellare il DDT Emesso N. " & CPNEIntNumDoc & "/" & CPNEStrSerieDoc & " Anno " & CPNEIntAnnoDoc)
                End If
              End If
            End If
          End If
        End If
      End If
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub




  Public Overrides Sub tlbRipristina_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    If OCLEStd.bGestioneAgentiAgente Then
      MyBase.tlbRipristina_ItemClick(sender, e)
      'edSerieDoc.Enabled = False
    Else
      MyBase.tlbRipristina_ItemClick(sender, e)
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Public Overrides Sub tlbSalva_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    If OCLEStd.bGestioneAgentiAgente Then
      MyBase.tlbSalva_ItemClick(sender, e)
      'edSerieDoc.Enabled = False
    Else
      MyBase.tlbSalva_ItemClick(sender, e)
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  ' Gestione Agenti fine
  Public Overrides Sub tlbSelOFA_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    If UCase(oMenu.GetSettingBus("BSHHGSOR", "OPTPERS", ".", "GestOrdineConfermato", "N", " ", "N")) = "S" Then
      If oCleGsor.dttET.Rows(0)!et_tipork.ToString = "X" Then
        CPNEtlbSelOFA_ItemClick()
      Else
        MyBase.tlbSelOFA_ItemClick(sender, e)
      End If
    Else
      MyBase.tlbSelOFA_ItemClick(sender, e)
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Sub CPNEtlbSelOFA_ItemClick()
    Dim oPar As New CLE__CLDP
    Dim dQuant As Decimal = 0
    Dim strCodart As String = ""
    Dim nFase As Integer = 0

    Try

      '=========================================
      OCLEStd.bPassataDaOrdApertiImpTrasf = True
      OCLEStd.CPNEImpostaDalbPassataDaOrdApertiImpTrasf(True, CInt(oCleGsor.dttET.Rows(0)!et_magaz))
      Dim intTipoSfOr As Integer = CInt(oCleGsor.dttET.Rows(0)!et_tipobf)
      '========================================

      '---------------------------
      'controlli preliminari
      ''''''''''''''''''If oCleGsor.dttET.Rows(0)!et_tipork.ToString <> "R" And oCleGsor.dttET.Rows(0)!et_tipork.ToString <> "O" And oCleGsor.dttET.Rows(0)!et_tipork.ToString <> "#" Then
      ''''''''''''''''''  oApp.MsgBoxErr(oApp.Tr(Me, 128582456087343750, "Funzione utilizzabile solo con Impegni clienti, Impegno di commessa e Ordini fornitore"))
      ''''''''''''''''''  Return
      ''''''''''''''''''End If

      If Not oCleGsor.OkTestata() Then
        tsGsor.Focus()
        Return
      End If

      '-----------------------
      'se è una nuova riga con o senza codice articolo proseguo, se è una riga già precedentemente salvata prima la aggiorno
      If Not grvRighe.NTSGetCurrentDataRow Is Nothing Then
        If oCleGsor.dttEC.Rows(dcGsorRighe.Position).RowState = DataRowState.Added Then
          'non devo fare nulla
        ElseIf oCleGsor.dttEC.Rows(dcGsorRighe.Position).RowState = DataRowState.Unchanged Then
          'non devo fare nulla
        Else
          If Not oCleGsor.RecordSalva(dcGsorRighe.Position, False, Nothing) Then Return
        End If
      End If

      If oCleGsor.lConclpriv = CInt(oCleGsor.dttET.Rows(0)!et_conto) Then
        oApp.MsgBoxErr(oApp.Tr(Me, 128582475572812500, "Impossibile acquisire ordini/impegni per un cliente generico privato."))
        Return
      End If

      '---------------------------
      'Codice articolo e q.ta da passare
      ''''''''''''''''''''If grRighe.Focused Then
      ''''''''''''''''''''  If Not grvRighe.NTSGetCurrentDataRow Is Nothing Then
      ''''''''''''''''''''    If grvRighe.FocusedColumn.Name = "ec_codart" Then grvRighe.NTSMoveNextColunn()
      ''''''''''''''''''''    strCodart = NTSCStr(grvRighe.NTSGetCurrentDataRow!ec_codart)
      ''''''''''''''''''''    nFase = NTSCInt(grvRighe.NTSGetCurrentDataRow!ec_fase)
      ''''''''''''''''''''    dQuant = NTSCDec(grvRighe.NTSGetCurrentDataRow!ec_quant)
      ''''''''''''''''''''  End If
      ''''''''''''''''''''End If

      '------------------------
      'Chiama lo zoom ordini aperti
      oPar.strDescr = oCleGsor.GetWhereHlmoOfa(False)
      oPar.strTipo = oCleGsor.dttET.Rows(0)!et_tipork.ToString
      '''''''''''''''oPar.lContoCF = NTSCInt(oCleGsor.dttET.Rows(0)!et_conto)
      oPar.lContoCF = CInt(oCleGsor.dttET.Rows(0)!et_conto)
      oPar.strCodart = strCodart
      oPar.nFase = nFase
      oPar.dImporto = dQuant
      'oPar.lCommessa = NTSCInt(IIf(oCleBoll.bPassaCommessaTestataHLMO, edEt_commeca.Text, 0))
      oPar.bFlag1 = False 'oCleBoll.bNew
      'oPar.nAnno = NTSCInt(edAnnoDoc.Text)
      'oPar.strAlfpar = edSerieDoc.ToString
      'oPar.lNumreg = NTSCInt(edNumDoc.Text)
      oPar.nTipologia = 2                     '0 solo visualizzaz, 2 = possibilità di selez le righe
      oPar.oParam = Nothing                   'se chiamato da veboll qui occorrerà passare il datatable del corpo (oPar.oParam = oCleVeboll.dttEC)
      ''''''''''''oPar.nMastro = NTSCInt(IIf(strCodart <> "", 3, 1))   'colonne di bsorhlmo da visualizzare (in vb6 lShowColumn)
      oPar.nMastro = CInt(IIf(strCodart <> "", 3, 1))   'colonne di bsorhlmo da visualizzare (in vb6 lShowColumn)
      NTSZOOM.ZoomStrIn("ZOOMMOVORD", DittaCorrente, oPar)        'in vb6 la dohlmo

      '==========================================================
      If oPar.oParam Is Nothing Then
        OCLEStd.bPassataDaOrdApertiImpTrasf = False
        OCLEStd.CPNEImpostaDalbPassataDaOrdApertiImpTrasf(False, 0)
      End If
      '=========================================================

      If oPar.oParam Is Nothing Then Return
      'se non premuto 'annulla' in oPar.oParam viene restituito l'elenco delle righe della griglia da trattare!!!
      If CType(oPar.oParam, DataTable).Rows.Count = 0 Then Return

      ''''''''''''''Me.Cursor = Cursors.WaitCursor

      '------------------------
      'ho selezionato qualche cosa

      '-----------------------
      'se è una nuova riga la annullo, verrà reinserita nella ImportaOrdini
      If Not grvRighe.NTSGetCurrentDataRow Is Nothing Then
        If oCleGsor.dttEC.Rows(dcGsorRighe.Position).RowState = DataRowState.Added Then
          oCleGsor.RecordRipristina(dcGsorRighe.Position, dcGsorRighe.Filter)
        End If
      End If


      If Not oCleGsor.ImportaOrdini(CType(oPar.oParam, DataTable)) Then Return

      If oCleGsor.bModPM And oCleGsor.dttET.Rows(0)!et_tipork.ToString = "H" Then
        '...
      End If

      '=========================================
      oCleGsor.dttET.Rows(0)!et_tipobf = intTipoSfOr
      OCLEStd.bPassataDaOrdApertiImpTrasf = False
      OCLEStd.CPNEImpostaDalbPassataDaOrdApertiImpTrasf(False, 0)
      '========================================

      'si posiziona sull'ultima riga
      grvRighe.NTSNuovo()

    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------	
    Finally
      '''''''''''''Me.Cursor = Cursors.Default
    End Try
  End Sub
  Public Overrides Sub LeggiDisponibilitaArticolo(ByVal strCodart As String, ByVal nMagaz As Integer, ByVal nFase As Integer, ByVal lCommeca As Integer, Optional ByVal strGescomm As String = "?")
TRY
    Dim decEsist As Decimal
    Dim decOrdin As Decimal
    Dim decImpeg As Decimal

    MyBase.LeggiDisponibilitaArticolo(strCodart, nMagaz, nFase, lCommeca, strGescomm)
    If UCase(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestionePezziSuDispo", "N", " ", "N")) = "S" Then
      If edDispon.Text = "999.999.999,000" Then
        CType(NTSFindControlByName(Me, "edCPNEDispoPz"), NTSTextBoxNum).Text = "999999999"
        CType(NTSFindControlByName(Me, "edCPNEImpPz"), NTSTextBoxNum).Text = "999999999"
        CType(NTSFindControlByName(Me, "edCPNEDispNetPz"), NTSTextBoxNum).Text = "999999999"
        CType(NTSFindControlByName(Me, "edCPNEOrdPz"), NTSTextBoxNum).Text = "999999999"
      Else
        OCLEStd.CPNEDisponibilitaArticoloColli(strCodart, nMagaz, decEsist, decOrdin, decImpeg)
        CType(NTSFindControlByName(Me, "edCPNEDispoPz"), NTSTextBoxNum).Text = CStr(decEsist - decImpeg + decOrdin)
        CType(NTSFindControlByName(Me, "edCPNEImpPz"), NTSTextBoxNum).Text = CStr(decImpeg)
        CType(NTSFindControlByName(Me, "edCPNEDispNetPz"), NTSTextBoxNum).Text = CStr(decEsist)
        CType(NTSFindControlByName(Me, "edCPNEOrdPz"), NTSTextBoxNum).Text = CStr(decOrdin)
      End If
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub FROVEBOLL_ActivatedFirst(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ActivatedFirst
TRY
    If UCase(oMenu.GetSettingBus("CPNE", "BNORGSOR", "OPZIONI", "GestionePezziSuDispo", "N", " ", "N")) = "S" Then
      edDispon.Location = New System.Drawing.Point(562, 0)
      edDispon.Width = 64
      edImpegnato.Location = New System.Drawing.Point(562, 20)
      edImpegnato.Width = 64
      edDispNetta.Location = New System.Drawing.Point(683, 0)
      edDispNetta.Width = 64
      edOrdinato.Location = New System.Drawing.Point(683, 20)
      edOrdinato.Width = 64

      edCPNEDispoPz.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      edCPNEImpPz.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      edCPNEDispNetPz.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      edCPNEOrdPz.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

      edCPNEDispoPz.Enabled = False
      edCPNEImpPz.Enabled = False
      edCPNEDispNetPz.Enabled = False
      edCPNEOrdPz.Enabled = False
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub FRMORGSOR_ActivatedFirst(ByVal sender As Object, ByVal e As System.EventArgs)
TRY
    MyBase.FRMORGSOR_ActivatedFirst(sender, e)
    grvRighe.NTSGetColumnByName("ec_codartclifor").NTSForzaVisZoom = True
    tlbSelDDTRic.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F7 Or System.Windows.Forms.Keys.Shift)
    tlb_Costr.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F11 Or System.Windows.Forms.Keys.Shift)
    tlbCPNEBNHHGEAR.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F12 Or System.Windows.Forms.Keys.Alt)

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub tlbSelDDTRic_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    If dsGsor.Tables("testa").Rows(0)!et_serie.ToString <> " " And dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" Then
      If UCase(oMenu.GetSettingBus("Bsorgsor", "OPZIONI", ".", "CDepCtrlValSerie", "N", " ", "N")) = "S" Then
        If InStr(UCase(oMenu.GetSettingBus("Bsorgsor", "OPZIONI", ".", "CDepSerieOrd", "D", " ", "D")), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) = 0 Then
          oApp.MsgBoxInfo("Attenzione la serie di questo documento '" & dsGsor.Tables("testa").Rows(0)!et_serie.ToString & "' non è valida." & vbCr & "Cambiare la serie del documento o specificare la serie nel registro di Business nella cartella ""BSORGSOR\OPZIONI"" Voce ""CDepSerieOrd""<C/Deposito Serie Ordine> valore <Serie> " & UCase(oMenu.GetSettingBus("Bsorgsor", "OPZIONI", ".", "CDepSerieOrd", "D", " ", "D")))
          Exit Sub
        End If
      End If
      If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
        With dsGsor.Tables("CPNEDdtNoEva").Rows(0)
          If CInt(!xx_conto) = 0 Or CInt(!xx_tipobf) = 0 Then
            If CInt(!xx_conto) = 0 Then
              oApp.MsgBoxInfo("Prima inserire il cliente")
            ElseIf CInt(dsGsor.Tables("testa").Rows(0)!et_tipobf) = 0 Then
              oApp.MsgBoxInfo("Prima inserire il tipo bolla fattura")
            Else
              oApp.MsgBoxInfo("Prima inserire il tipo bolla fattura collegato al ddt ricevuto")
            End If
          Else
            dsGsor.Tables("CPNEDdtNoEva").Rows(0)!xx_codart = "|"
            OCLEStd.CPNEGestTtRicDDt()
            dsGsor.Tables("CPNEDdtNoEva").Rows(0)!xx_codart = ""

            Dim formDaLan As New FrmDdtNoEva
            formDaLan.Init(oMenu, Nothing, DittaCorrente)
            formDaLan.InitEntity(oCleGsor)
            formDaLan.lContoCF = CDec(oCleGsor.lContoCF)
            formDaLan.ShowDialog()
            formDaLan.Dispose()
            formDaLan = Nothing


            If dsGsor.Tables("CPNEDdtNoEvaRic").Rows.Count > 0 Then
              OCLEStd.CPNEAggiungiRigheDaAttesa()
            End If
          End If
        End With
      Else
        oApp.MsgBoxInfo("Prima posizionarsi su una riga vuota")
      End If
    Else
      oApp.MsgBoxInfo("Funzione non attiva per la serie "" """)
    End If

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Sub ckEt_sospeso_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckEt_sospeso.CheckedChanged
TRY
    tlbSalva.Enabled = True
    OCLEStd.bPassatodaSospeso = True
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Sub tlb_Costr_Click(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    Dim oPar As CLE__CLDP = Nothing
    oPar = New CLE__CLDP
    oPar.Ditta = DittaCorrente
    oPar.strPar1 = "BNORGSOR"
    oPar.dPar1 = CDec(oCleGsor.lContoCF)
    oMenu.RunChild("NTSInformatica", "FRMHHCOLA", "", DittaCorrente, "", "BNHHCOLA", oPar, "", True, True)
    If oPar.strPar1 <> "BNORGSOR" Then
      If NTSCStr(oPar.strPar1) <> NTSCStr(grvRighe.GetFocusedValue) Then
        With DirectCast(grvRighe, NTSGridView)
          '.FocusedColumn = .Columns.Item("ec_codart")
          'frxorgsor.grvRighe.SetFocusedValue(oPar.strPar1)
          .FocusedColumn = .Columns.Item("ec_codartclifor")
          grvRighe.SetFocusedValue(OCLEStd.CPNETrovaCodartCliFor(oPar.strPar1))
          .FocusedColumn = .Columns.Item("ec_misura1")
          grvRighe.SetFocusedValue(oPar.dPar1)
          .FocusedColumn = .Columns.Item("ec_misura2")
          grvRighe.SetFocusedValue(oPar.dPar2)
          .FocusedColumn = .Columns.Item("ec_misura3")
          grvRighe.SetFocusedValue(oPar.dPar3)
          .FocusedColumn = .Columns.Item("ec_codartclifor")
        End With
      End If
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub tlbZoom_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    MyBase.tlbZoom_ItemClick(sender, e)
    Dim oParam As New CLE__CLDP
    Dim strCodartclifor As String
    Select Case grvRighe.FocusedColumn.Name
      Case "ec_codartclifor"
        'ValidaLastControl()
        'NTSZOOM.strIn = ""
        'oParam.lContoCF = oCleGsor.dttET.Rows(0)!et_conto
        'NTSZOOM.ZoomStrIn("ZOOMARTICO", DittaCorrente, oParam)
        'If NTSZOOM.strIn <> "" Then
        '  If IsNothing(NTSFindControlByName(frxorgsor, "grvRighe").NTSGetCurrentDataRow) Then
        '    'oCleGsor.AggiungiRigaCorpo(False, NTSZOOM.strIn, 0, 0)
        '    grvRighe.FocusedColumn = grvRighe.Columns("ec_codart")
        '    'grvRighe.SetFocusedValue(NTSZOOM.strIn)
        '    'grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
        '    Dim strCodartclifor As String = Oclestd.CPNETrovaCodartCliFor(NTSZOOM.strIn)
        '    grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
        '    grvRighe.SetFocusedValue(strCodartclifor)
        '  Else
        '    NTSFindControlByName(frxorgsor, "grvRighe").NTSGetCurrentDataRow!ec_codart = NTSZOOM.strIn
        '  End If
        '  ValidaLastControl()
        'End If



        ValidaLastControl()
        NTSZOOM.strIn = ""
        If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "O" Then
          If UCase(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "CPNE", "BNMGHLAR", "OPZIONI", "CPMultiZoomOrdForn", "N", " ", "N")) = "S" Then
            oParam.bTipoProposto = False
          End If
        End If
        Dim bConArticolo As Boolean = False

        If OCLEStd.sGestOrdineConfermato = "S" Then
          If InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), OCLEStd.dsShared.Tables("TESTA").Rows(0)!et_serie.ToString) > 0 Then
            If dsGsor.Tables("testa").Rows(0)!et_confermato.ToString = "S" Then
              Exit Sub
            End If
          End If
        End If

        If Not IsNothing(grvRighe.NTSGetCurrentDataRow) Then
          If grvRighe.NTSGetCurrentDataRow!ec_codartclifor.ToString <> "" Then
            bConArticolo = True
          End If
        End If
        If bConArticolo = False Then
          ' Beretta inizio 2015-06-23 -------------------------------------
          ' originale
          'oParam.nMagaz = NTSCInt(edEt_magaz.Text)
          ' modifica
          ' Beretta inizio 2016-11-24 --------------------
          ' originale
          oParam.nMagaz = CInt(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "CPNE", "BNMGARTI", "OPZIONI", "CPSmembraArticolo", "0", " ", "0"))
          ' modifica
          If OCLEStd.sGestOrdineConfermato = "S" Then
            If InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), OCLEStd.dsShared.Tables("TESTA").Rows(0)!et_serie.ToString) > 0 Then
              oParam.nMagaz = NTSCInt(edEt_magaz.Text)
            Else
              oParam.nMagaz = CInt(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "CPNE", "BNMGARTI", "OPZIONI", "CPSmembraArticolo", "0", " ", "0"))
            End If
          Else
            oParam.nMagaz = CInt(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "CPNE", "BNMGARTI", "OPZIONI", "CPSmembraArticolo", "0", " ", "0"))
          End If

          ' Beretta fine 2015-06-23 -------------------------------------
          oParam.nListino = NTSCInt(edEt_listino.Text)
          oParam.lContoCF = oCleGsor.lContoCF

          If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "O" Then
            If UCase(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "CPNE", "BNORGSOR", "OPZIONI", "CPProponiCodForn", "N", " ", "N")) = "S" Then
              oParam.strBanc2 = "O"
            End If
          End If
          ' Beretta inizio 2015-03-13 -----------------------------
          If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "M" Then
            If UCase(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "CPSmembraArticolo", "N", " ", "N")) = "S" Then
              oParam.strBanc1 = oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "CPMaterialeCL", "1", " ", "1")
            End If
          End If
          ' Beretta fine 2015-03-13 -----------------------------
          NTSZOOM.ZoomStrIn("ZOOMARTICO", DittaCorrente, oParam)
        Else
          NTSZOOM.strIn = OCLEStd.CPNETrovaCodart(oCleGsor.lContoCF, grvRighe.NTSGetCurrentDataRow!ec_codartclifor.ToString)
        End If

        If NTSZOOM.strIn <> "" Then
          If NTSZOOM.strIn <> "*" Then

            If UCase(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHGSOR", "OPTPERS", ".", "ZoomProdottoFinitoCV", "N", " ", "N")) = "S" Then
              If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
                strCodartclifor = OCLEStd.CPNETrovaCodartCliFor(NTSZOOM.strIn)
              Else
                If grvRighe.NTSGetCurrentDataRow!ec_codartclifor.ToString <> "" Then
                  strCodartclifor = grvRighe.NTSGetCurrentDataRow!ec_codartclifor.ToString
                Else
                  strCodartclifor = OCLEStd.CPNETrovaCodartCliFor(NTSZOOM.strIn)
                End If
              End If
              If strCodartclifor <> "" Then
                Dim drArticolo As DataRow = OCLEStd.CPNERigaArticolo(NTSZOOM.strIn)
                If Not IsNothing(drArticolo) Then


                  If UCase(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHGSOR", "OPZIONI", ".", "GestioneVisFormLavorazione", "N", " ", "N")) = "S" Then
                    If CInt(drArticolo!ar_gruppo) = CInt(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHGSOR", "OPZIONI", ".", "VisFormLavorazioneGruppo", "95", " ", "95")) Then
                      If InStr(strCodartclifor, oMenu.GetSettingBus("CPNE", "BNMGARTI", "OPZIONI", "StrSeparaArt2", "_", " ", "_")) > 0 Then
                        If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
                          'oCleGsor.AggiungiRigaCorpo(False, NTSZOOM.strIn, 0, 0)
                          strCodartclifor = OCLEStd.CPNETrovaCodartCliFor(NTSZOOM.strIn)
                          grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
                          grvRighe.SetFocusedValue(strCodartclifor)
                        Else
                          grvRighe.NTSGetCurrentDataRow!ec_codart = NTSZOOM.strIn
                        End If
                        ValidaLastControl()
                      Else
                        CPNERecordZoomProdottoFinitoCV(strCodartclifor)
                      End If

                    Else
                      Dim tsMarca As Object
                      Dim sMarche As String

                      sMarche = oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHGSOR", "OPZIONI", ".", "VisFormLavorazioneMarca", "N", " ", "N")
                      Dim bTrovato As Boolean = False
                      If sMarche <> "N" Then
                        For Each tsMarca In Split(sMarche, ";")
                          If CStr(tsMarca) = CStr(drArticolo!ar_codmarc) Then
                            If InStr(strCodartclifor, oMenu.GetSettingBus("CPNE", "BNMGARTI", "OPZIONI", "StrSeparaArt2", "_", " ", "_")) > 0 Then
                              If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
                                'oCleGsor.AggiungiRigaCorpo(False, NTSZOOM.strIn, 0, 0)
                                strCodartclifor = OCLEStd.CPNETrovaCodartCliFor(NTSZOOM.strIn)
                                grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
                                grvRighe.SetFocusedValue(strCodartclifor)
                              Else
                                grvRighe.NTSGetCurrentDataRow!ec_codart = NTSZOOM.strIn
                              End If
                              ValidaLastControl()
                            Else
                              CPNERecordZoomProdottoFinitoCV(strCodartclifor)
                            End If
                            bTrovato = True
                            Exit For
                          End If
                        Next
                      End If
                      If bTrovato = False Then
                        If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
                          'oCleGsor.AggiungiRigaCorpo(False, NTSZOOM.strIn, 0, 0)
                          strCodartclifor = OCLEStd.CPNETrovaCodartCliFor(NTSZOOM.strIn)
                          grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
                          grvRighe.SetFocusedValue(strCodartclifor)
                        Else
                          strCodartclifor = OCLEStd.CPNETrovaCodartCliFor(NTSZOOM.strIn)
                          grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
                          grvRighe.SetFocusedValue(strCodartclifor)
                        End If
                      End If
                      ValidaLastControl()
                    End If
                  Else
                    If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
                      'oCleGsor.AggiungiRigaCorpo(False, NTSZOOM.strIn, 0, 0)
                      strCodartclifor = OCLEStd.CPNETrovaCodartCliFor(NTSZOOM.strIn)
                      grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
                      grvRighe.SetFocusedValue(strCodartclifor)
                    Else
                      grvRighe.NTSGetCurrentDataRow!ec_codart = NTSZOOM.strIn
                    End If
                    ValidaLastControl()
                  End If
                Else
                  CPNERecordZoomProdottoFinitoCV(strCodartclifor)
                End If
              End If
            Else
              If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
                'oCleGsor.AggiungiRigaCorpo(False, NTSZOOM.strIn, 0, 0)
                strCodartclifor = OCLEStd.CPNETrovaCodartCliFor(NTSZOOM.strIn)
                grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
                grvRighe.SetFocusedValue(strCodartclifor)
              Else
                grvRighe.NTSGetCurrentDataRow!ec_codart = NTSZOOM.strIn
              End If
              ValidaLastControl()
            End If
          Else
            If Not oParam.oParam Is Nothing Then
              If CType(oParam.oParam, DataTable).Rows.Count > 0 Then
                If NTSCStr(CType(oParam.oParam, DataTable).Rows(0)!codart) <> NTSCStr(grvRighe.GetFocusedValue) Then
                  With DirectCast(grvRighe, NTSGridView)
                    .FocusedColumn = .Columns.Item("ec_codart")
                  End With
                  'grvRighe.SetFocusedValue(NTSCStr(CType(oParam.oParam, DataTable).Rows(0)!codart))
                  'If Not IsNothing(grvRighe.NTSGetCurrentDataRow) Then
                  '  If CType(oParam.oParam, DataTable).Rows.Count > 1 Then
                  '    If NTSCInt(grvRighe.NTSGetCurrentDataRow!xxo_codtagl) = 0 Then
                  '      grvRighe.NTSGetCurrentDataRow!ec_quant = 1
                  '    End If
                  '  End If
                  'End If
                End If
                Application.DoEvents()
                For i = 0 To CType(oParam.oParam, DataTable).Rows.Count - 1
                  Application.DoEvents()
                  oCleGsor.dttEC.Rows.Add()
                  Dim drd As DataRow = oCleGsor.dttEC.Rows(oCleGsor.dttEC.Rows.Count - 1)
                  Dim dro As DataRow = CType(oParam.oParam, DataTable).Rows(i)
                  drd!ec_codart = dro!codart
                  If NTSCInt(drd!xxo_codtagl) = 0 Then
                    drd!ec_colli = 1
                    'drd!ec_quant = 1
                  End If
                Next
                CType(oParam.oParam, DataTable).Clear()
                With DirectCast(grvRighe, NTSGridView)
                  .FocusedColumn = .Columns.Item("ec_codartclifor")
                End With

              End If
            End If
          End If
        End If
    End Select
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub CPNERecordZoomProdottoFinitoCV(ByVal strCodartclifor As String)
TRY
    Dim oPar As New CLE__CLDP


    Dim drArticolo As DataRow = OCLEStd.CPNERigaArticolo(NTSZOOM.strIn)
    If IsNothing(drArticolo) Then
      Exit Sub
    End If

    oPar.Ditta = DittaCorrente
    oPar.strNomProg = "BNORGSOR"
    oPar.strPar2 = "N"

    If drArticolo!ar_coddb.ToString <> "" Then
      oPar.strPar1 = "TT" & "|" & strCodartclifor
      oPar.strPar1 = oPar.strPar1 & "#" & oCleGsor.dttET.Rows(0)!et_conto.ToString
      oPar.strPar1 = oPar.strPar1 & "T" & oMenu.GetSettingBus("BSVEBOLL", "OPZIONI", ".", "CPLavorazione", "2", " ", "2")
    Else
      oPar.strPar1 = "NN" & "|" & strCodartclifor
      oPar.strPar1 = oPar.strPar1 & "#" & oCleGsor.dttET.Rows(0)!et_conto.ToString
      oPar.strPar1 = oPar.strPar1 & "G" & oMenu.GetSettingBus("BSVEBOLL", "OPZIONI", ".", "CPMaterialeCL", "1", " ", "1")
      oPar.strPar1 = oPar.strPar1 & "T" & oMenu.GetSettingBus("BSVEBOLL", "OPZIONI", ".", "CPLavorazione", "2", " ", "2")
    End If

    oMenu.RunChild("NTSInformatica", "FRMHHGRTR", "", DittaCorrente, "", "BNHHGRTR", oPar, "", True, True)

    If InStr(oPar.strPar1, "|OK|") > 0 Then
      Dim dt As New DataTable
      Dim Stringa As String = ""
      Dim strcodart As String = ""
      Dim strAccoppiato As String = Mid(oPar.strPar1, 7, 1)

      If strAccoppiato = "N" Then
        Dim strCodartLatoA As String = Mid(oPar.strPar1, 9, InStr(oPar.strPar1, "#") - 1 - 8)
        Stringa = Mid(oPar.strPar1, InStr(oPar.strPar1, "#") + 1)
        If InStr(Stringa, "#") = 0 Then
          Dim strCodartLatoALav As String = Stringa
          strcodart = OCLEStd.CPNEAggiornaCodArtPRod2(strCodartLatoA, strCodartLatoALav, False, True)
        Else
          Dim strCodartLatoALav As String = Mid(Stringa, 1, InStr(Stringa, "#") - 1)
          Stringa = Mid(Stringa, InStr(Stringa, "#") + 1)
          Dim strInterno1 As String = Mid(Stringa, 1, InStr(Stringa, "#") - 1)
          Stringa = Mid(Stringa, InStr(Stringa, "#") + 1)
          Dim strInterno2 As String = Mid(Stringa, 1, InStr(Stringa, "#") - 1)
          Stringa = Mid(Stringa, InStr(Stringa, "#") + 1)
          Dim strCodartLatoB As String = Mid(Stringa, 1, InStr(Stringa, "#") - 1)
          Dim strCodartLatoBLav As String = Mid(Stringa, InStr(Stringa, "#") + 1)
          Dim bUnito As Boolean = False
          If Mid(oPar.strPar1, 5, 1) = "S" Then
            bUnito = True
          End If

          strcodart = OCLEStd.CPNEAggiornaCodArtPRod6(strCodartLatoA, strCodartLatoALav, strInterno1, strInterno2, strCodartLatoB, strCodartLatoBLav, OCLEStd.CPNETrovaCodart(oCleGsor.lContoCF, strCodartclifor), bUnito, True)
        End If
      Else
        strcodart = OCLEStd.CPNETrovaCodart(oCleGsor.lContoCF, strCodartclifor)
      End If
      If strcodart <> "" Then
        If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
          strCodartclifor = OCLEStd.CPNETrovaCodartCliFor(strcodart)
          grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
          grvRighe.SetFocusedValue(strCodartclifor)
        Else
          grvRighe.NTSGetCurrentDataRow!ec_codartclifor = OCLEStd.CPNETrovaCodartCliFor(strcodart)
        End If
        ValidaLastControl()
      Else
        oApp.MsgBoxInfo("Attenzione non è stato trovato l'articolo!")
      End If
    Else
      If Mid(oPar.strPar1, 1, 3) = "NN|" Then
        Dim strCodartcliforGr As String = Mid(oPar.strPar1, 4, InStr(oPar.strPar1, "#") - 1 - 3)
        If strCodartcliforGr <> "" Then
          If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
            grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
            grvRighe.SetFocusedValue(strCodartcliforGr)
          Else
            grvRighe.NTSGetCurrentDataRow!ec_codartclifor = OCLEStd.CPNETrovaCodart(oCleGsor.lContoCF, strCodartcliforGr)
          End If
          ValidaLastControl()
        Else
          oApp.MsgBoxInfo("Attenzione non è stato trovato l'articolo!")
        End If
      End If
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub grvRighe_NTSFocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
TRY
    MyBase.grvRighe_NTSFocusedRowChanged(sender, e)
      Dim StrTmp As String = ""

    If grvRighe.Focused = False And grRighe.Focused = False Then
      Return
    End If

    Dim bEnabled As Boolean = OCLEStd.CPNERigaModificabile(grvRighe.NTSGetCurrentDataRow, StrTmp)
    lbCPNEDescMsg.Text = StrTmp
    If bEnabled Then
      grvRighe.Enabled = True
      If OCLEStd.sGestOrdineConfermato = "S" Then
        If dsGsor.Tables("testa").Rows.Count > 0 Then
          'If InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), Oclestd.dsShared.Tables("TESTA").Rows(0)!et_serie.ToString) > 0 Then
          If tlbSalva.Enabled Then
            tlbCPNESALVANOTE.Enabled = False
          Else
            tlbCPNESALVANOTE.Enabled = True
          End If
          'End If
        End If
      End If
    Else
      If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString <> "O" Then
        grvRighe.Enabled = False
      End If
      If OCLEStd.sGestOrdineConfermato = "S" Then
        'If InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), Oclestd.dsShared.Tables("TESTA").Rows(0)!et_serie.ToString) > 0 Then
        tlbCPNESALVANOTE.Enabled = True
        'End If
      End If
    End If

    If OCLEStd.sGestOrdineConfermato = "S" Then
      If dsGsor.Tables("testa").Rows.Count > 0 Then
        'If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "X" Then

        'ElseIf dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" Then
        '  If dsGsor.Tables("testa").Rows(0)!et_confermato.ToString = "S" Or dsGsor.Tables("testa").Rows(0)!et_rilasciato.ToString = "S" Then

        '  Else
        '    grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
        '  End If
        'ElseIf dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "O" Then
        '  If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
        '    If grvRighe.Columns("ec_codart").Visible Then
        '      grvRighe.FocusedColumn = grvRighe.Columns("ec_codart")
        '    Else
        '      grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
        '    End If
        '  End If
        '  Else
        '    grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
        '  End If
        If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
          If grvRighe.Columns("ec_codart").Visible Then
            grvRighe.FocusedColumn = grvRighe.Columns("ec_codart")
          Else
            grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
          End If
        End If
      End If

    Else
      grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub tsGsor_SelectedPageChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs)
TRY
    MyBase.tsGsor_SelectedPageChanged(sender, e)
    If tsGsor.SelectedTabPageIndex = CInt("1") Then
      grvRighe_NTSFocusedRowChanged(grvRighe, Nothing)
    End If
    If tsGsor.SelectedTabPageIndex = CInt("3") Then
      '======== 24 09 2018 per fare in modo che si sposti sul campo NOTE !!!! SLAM RICHIESTA DI FRANCESCO .....
      cmdCastelletti.Focus()
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub edNumDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
TRY
    MyBase.edNumDoc_KeyDown(sender, e)
    grvRighe_NTSFocusedRowChanged(Nothing, Nothing)
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub


  Public Overridable Function CPNECreaDoc(ByVal strStato As String, ByVal strTipoDoc As String, ByVal nAnnoDoc As Integer, ByVal strSerieDoc As String, ByVal lNumTmpDoc As Integer) As Boolean
    Try
      '----------------------------------------------------------------------------------------
      '--- Inizializzo BEVEBOLL
      '----------------------------------------------------------------------------------------
      If Not CPNEInizializzaBeveboll() Then Return False

      '----------------------------------------------------------------------------------------
      '--- Legge il progressivo in TABNUMA
      '----------------------------------------------------------------------------------------
      If strStato = "N" Then
        lNumTmpDoc = oCleBoll.LegNuma(strTipoDoc, strSerieDoc, nAnnoDoc)
        CPNEIntNumDoc = lNumTmpDoc
      End If


      '----------------------------
      'preparo l'ambiente
      Dim ds As New DataSet
      If Not oCleBoll.ApriDoc(oApp.Ditta, False, strTipoDoc, nAnnoDoc, strSerieDoc, lNumTmpDoc, ds) Then Return False
      oCleBoll.bInApriDocSilent = True
      If strStato = "N" Then
        If oCleBoll.dsShared.Tables("TESTA").Rows.Count > 0 Then
          oApp.MsgBoxErr("Controllare le numerazioni!")
          Return False
        End If
      End If
      oCleBoll.ResetVar()
      oCleBoll.strVisNoteConto = "N"
      If strStato = "N" Then
        oCleBoll.NuovoDocumento(oApp.Ditta, strTipoDoc, nAnnoDoc, strSerieDoc, lNumTmpDoc)
        oCleBoll.bInNuovoDocSilent = True

        CPNECreaTestataDoc()

        For qq = 0 To dsGsor.Tables("CORPO").Rows.Count - 1
          Dim drRigaOrdine As DataRow = dsGsor.Tables("CORPO").Rows(qq)

          Dim CPNEstrTiporkDdtRic As String = dsGsor.Tables("CORPO").Rows(qq)!ec_tiporkddtric.ToString
          Dim CPNEiAnnoDdtRic As Integer = CInt(dsGsor.Tables("CORPO").Rows(qq)!ec_annoddtric)
          Dim CPNEstrserieDdtRic As String = dsGsor.Tables("CORPO").Rows(qq)!ec_serieDdtRic.ToString
          Dim CPNEiNumDdtRic As Integer = CInt(dsGsor.Tables("CORPO").Rows(qq)!ec_NumDdtRic)
          Dim CPNEiRigaDdtRic As Integer = CInt(dsGsor.Tables("CORPO").Rows(qq)!ec_RigaDdtRic)

          Dim dtDdtRicRiga As DataTable = OCLEStd.CPNETrovaDdtRicevutoRiga(DittaCorrente, CPNEstrTiporkDdtRic, CPNEiAnnoDdtRic, CPNEstrserieDdtRic, CPNEiNumDdtRic, CPNEiRigaDdtRic)
          CPNECreaRigaDoc(drRigaOrdine, dtDdtRicRiga.Rows(0))
        Next

        CPNESettaPiedeDoc()

        oCleBoll.bCreaFilePick = False 'non faccio generare il piking dal salvataggio del documento
      End If
      If Not oCleBoll.SalvaDocumento(strStato) Then
        oApp.MsgBoxErr("Errore al salvataggio!")
        Return False
      End If

      Return True
    Catch ex As Exception
      CLN__STD.GestErr(ex, Me, "")
      Return False
    End Try
  End Function

  Public Overridable Function CPNEInizializzaBeveboll() As Boolean
    Try
      If Not oCleBoll Is Nothing Then Return True
      '------------------------
      'inizializzo BEVEBOLL
      Dim strErr As String = ""
      Dim oTmp As Object = Nothing
      If CLN__STD.NTSIstanziaDll(oApp.ServerDir, oApp.NetDir, "BNMGARTI", "BEVEBOLL", oTmp, strErr, False, "", "") = False Then
        Throw New NTSException(oApp.Tr(Me, 128607611686875006, "ERRORE in fase di creazione Entity:" & vbCrLf & "|" & strErr & "|"))
        Return False
      End If
      oCleBoll = CType(oTmp, CLEVEBOLL)
      '------------------------------------------------
      AddHandler oCleBoll.RemoteEvent, AddressOf GestisciEventiEntity
      If oCleBoll.Init(oApp, oScript, oMenu.oCleComm, "", False, "", "") = False Then Return False
      If Not oCleBoll.InitExt() Then Return False
      oCleBoll.bModuloCRM = False
      oCleBoll.bIsCRMUser = False
      Return True
    Catch ex As Exception
      CLN__STD.GestErr(ex, Me, "")
      Return False
    End Try
  End Function

  Public Overridable Function CPNECreaTestataDoc() As Boolean
    Try
      ' recupero informazioni registro di business
      Dim iRegTipoBf As Integer = CInt(oMenu.GetSettingBusDitt(DittaCorrente, "BSORGSOR", "OPZIONI", ".", "GestioneDdtResoCDepTipoBf", "1", " ", "1"))
      Dim iRegCaus As Integer = CInt(oMenu.GetSettingBusDitt(DittaCorrente, "BSORGSOR", "OPZIONI", ".", "GestioneDdtResoCDepCaus", "1", " ", "1"))
      Dim strRegNote As String = oMenu.GetSettingBusDitt(DittaCorrente, "BSORGSOR", "OPZIONI", ".", "GestioneDdtResoCDepNote", "", " ", "")
      With oCleBoll.dttET.Rows(0)
        'faccio scatenare la onaddnew della testata dell'ordine
        !codditt = oApp.Ditta
        !et_conto = CPNEiContoDdtRic
        !et_conto2 = 0
        !et_datdoc = dsGsor.Tables("testa").Rows(0)!et_datdoc
        !et_tipobf = iRegTipoBf
        !et_causale = iRegCaus
        !et_note = strRegNote
        !et_caustra = 0
        !et_totcoll = 0
        Dim ddtAnagra As DataTable = OCLEStd.CPNETrovaAnagra(DittaCorrente, CInt(dsGsor.Tables("testa").Rows(0)!et_conto))
        !et_riferim = ddtAnagra.Rows(0)!an_descr1
      End With

      If Not oCleBoll.OkTestata Then Return False
      Return True
    Catch ex As Exception
      CLN__STD.GestErr(ex, Me, "")
      Return False
    End Try
  End Function

  Public Overridable Function CPNECreaRigaDoc(ByVal drRigaOrdine As DataRow, ByVal dtDdtRicRiga As DataRow) As Boolean
    Try
      Dim nCausaleMagazzino As Integer = CInt(oMenu.GetSettingBusDitt(DittaCorrente, "BSORGSOR", "OPZIONI", ".", "GestioneDdtResoCDepCaus", "1", " ", "1"))
      'Creo una nuova riga di corpo setto i principali campi poi setto tutti gli altri
      If Not oCleBoll.AggiungiRigaCorpo(False, NTSCStr(dtDdtRicRiga!mm_codart), _
                                               NTSCInt("0"), _
                                               0, _
                                               nCausaleMagazzino, _
                                               NTSCInt(drRigaOrdine!ec_magaz)) Then Return False


      With oCleBoll.dttEC.Rows(oCleBoll.dttEC.Rows.Count - 1)
        !ec_colli = drRigaOrdine!ec_colli
        !ec_quant = drRigaOrdine!ec_quant
        !ec_misura2 = drRigaOrdine!ec_misura2
        !ec_codartclifor = dtDdtRicRiga!mm_codartclifor
        !ec_commeca = dtDdtRicRiga!mm_commeca
      End With

      If Not oCleBoll.RecordSalva(oCleBoll.dttEC.Rows.Count - 1, False, Nothing) Then
        oCleBoll.dttEC.Rows(oCleBoll.dttEC.Rows.Count - 1).Delete()
        Return False
      End If

      Return True
    Catch ex As Exception
      CLN__STD.GestErr(ex, Me, "")
      Return False
    End Try

  End Function

  Public Overridable Function CPNESettaPiedeDoc() As Boolean
    Try
      oCleBoll.CalcolaTotali()
      Return True
    Catch ex As Exception
      CLN__STD.GestErr(ex, Me, "")
      Return False
    End Try
  End Function

  Public Overrides Sub tlbRecordCancella_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    'MyBase.tlbRecordCancella_ItemClick(sender, e)
  
    ''''''''''''''''''''Dim bcancella As Boolean = True
    ''''''''''''''''''''If dsGsor.Tables("testa").Rows(0)!et_tipork = "R" And InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieDDTRConCli", " ", " ", " "), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) Then
    ''''''''''''''''''''  bcancella = False
    ''''''''''''''''''''End If
    ''''''''''''''''''''If dsGsor.Tables("testa").Rows(0)!et_tipork = "H" Then
    ''''''''''''''''''''  If oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHDBLP", "OPZIONI", ".", "GestSerieClavInOc", "N", " ", "N") = "S" Then
    ''''''''''''''''''''    Dim strSerieClav As String = oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHDBLP", "OPZIONI", ".", "GestSerieClavInOcSerie" & dsGsor.Tables("testa").Rows(0)!et_serie.ToString, "9", " ", "9")
    ''''''''''''''''''''    If strSerieClav <> "9" Then
    ''''''''''''''''''''      If strSerieClav = dsGsor.Tables("testa").Rows(0)!et_serie.ToString Then
    ''''''''''''''''''''        bcancella = False
    ''''''''''''''''''''      End If
    ''''''''''''''''''''    End If
    ''''''''''''''''''''  End If
    ''''''''''''''''''''End If

    ''''''''''''''''''''If bcancella = False Then
    ''''''''''''''''''''  oApp.MsgBoxErr("riga non cancellabile" & vbCr & "Cancellare la corrispondente riga dal ddt ricevuto")
    ''''''''''''''''''''  Exit Sub
    ''''''''''''''''''''End If
    If Not OCLEStd.CPNERigaModificabile(grvRighe.NTSGetCurrentDataRow, "") Then
      oApp.MsgBoxInfo("Riga non cancellabile!")
      Exit Sub
    End If
    MyBase.tlbRecordCancella_ItemClick(sender, e)
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub tlbStampa_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    'MyBase.tlbStampa_ItemClick(sender, e)
  
    If OCLEStd.sGestOrdineConfermato = "S" Then
      If InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) = 0 Then
        CPNEImpostaStampeSlam(1)
        If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "O" Or dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "X" Then
          CPNEImpostaStampeSlam(1)
        Else
          tlbStampaVideo_ItemClick(sender, e)
          CPNEImpostaStampa(1)
        End If
      End If
    Else
      MyBase.tlbStampa_ItemClick(sender, e)
      CPNEImpostaStampa(1)
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Sub CPNEImpostaStampeSlam(ByVal nDestin As Integer)
    Dim bNewTmp As Boolean = False
    Try
      'Dim StrWhere As String = "{MOVORD.codditt} = '" & oCleGsor.strDittaCorrente & "'" & _
      '            " And {MOVORD.mo_anno} = " & dsGsor.Tables("TESTA").Rows(0)!et_anno.ToString & _
      '            " AND {MOVORD.mo_numord} = " & dsGsor.Tables("TESTA").Rows(0)!et_numdoc.ToString & _
      '            " AND {MOVORD.mo_serie} = '" & dsGsor.Tables("TESTA").Rows(0)!et_serie.ToString & "'" & _
      '            " AND {MOVORD.mo_tipork} = '" & dsGsor.Tables("TESTA").Rows(0)!et_tipork.ToString & "'" & _
      '            " AND {MOVORD.mo_stasino} <> 'N'" & _
      '            " AND {TESTORD.td_magaz2} <> {KEYORD.ko_magaz}"

      'If ckEt_confermato.Checked = False Then
      '  If ckEt_rilasciato.Checked Then
      '    CPNEEseguiStampa(StrWhere, "BSHHGSOR", "REPORTS7", " ", nDestin, "CPCve3.rpt", "Evasione Valorizzata")
      '  End If
      '  If CType(oCleGsor, CLFORGSOR).bGestioneAgentiAgente Then
      '    CPNEEseguiStampa(StrWhere, "BSHHGSOR", "REPORTS11", " ", nDestin, "BSHHGSOR.rpt", "Ordine c/vendita")
      '  End If
      'Else
      '  CPNEEseguiStampa(StrWhere, "BSHHGSOR", "Reports8", " ", nDestin, "CPCve2.rpt", "Stampe etichette")
      'End If
      '--------------------------------
      'se non posso salvare non posso stampare i nuovi documenti
      If tlbSalva.Enabled = False And oCleGsor.bNew Then
        oApp.MsgBoxErr(oApp.Tr(Me, 128776135739052000, "Impossibile stampare un nuovo ordine non possedendo i privilegi di salvataggio."))
        Return
      End If

      bNewTmp = oCleGsor.bNew

      '--------------------------------
      'salva il documento
      If tlbSalva.Enabled = True Then
        If Not Salva(0, False) Then Return
      End If
      CPNEStampa(nDestin)
      If bNewTmp And tlbSalvanuovo.Checked Then tlbNuovo_ItemClick(tlbNuovo, Nothing)

      '============ riccardo USCITA DOPO LA STAMPA
      'Me.Close()
      RipristinaInterfaccia()

    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------
    End Try
  End Sub

  Public Overridable Sub CPNEStampa(ByVal nDestin As Integer)
    'nDestin: 0 = video, 1 = carta
    Dim nPjob As Object
    Dim nRis As Integer = 0
    Dim strCrpe As String = ""
    Dim i As Integer
    Dim j As Integer

    Dim strKey2 As String = ""
    Dim strReportName As String = "Bshhgsor.rpt"

    Try
      '--------------------------------------------------
      'Non si possono stampare gli impegni di produzione
      If dsGsor.Tables("TESTA").Rows(0)!et_tipork.ToString = "Y" Then
        oApp.MsgBoxErr(oApp.Tr(Me, 127791222114843750, "Si possono stampare solo documenti :" & vbCrLf & " - Ordini di produzione;" & vbCrLf & " - Ordini fornitori;" & vbCrLf & " - Preventivi;" & vbCrLf & " - Impegni clienti;" & vbCrLf & " - Impegni di trasferimento;"))
        Return
      End If

      If dsGsor.Tables("TESTA").Rows(0)!et_valuta.ToString <> "0" Then
        strKey2 = "Reports3"
      ElseIf dsGsor.Tables("TESTA").Rows(0)!et_scorpo.ToString = "S" Then
        strKey2 = "Reports2"
      Else
        strKey2 = "Reports1"
      End If

      '--------------------------------------------------
      'eseguo delle query libere prima della stampa (query memorizzate in regprop di arcproc)
      oCleGsor.RunQueryBeforePrint("BSHHGSOR")

      If dsGsor.Tables("TESTA").Rows(0)!et_tipork.ToString = "R" Or dsGsor.Tables("TESTA").Rows(0)!et_tipork.ToString = "X" Then
        If ckEt_confermato.Checked = False Then
          If ckEt_rilasciato.Checked Then
            strKey2 = "Reports7"
            strReportName = "CPCve3.RPT"
          End If
          If OCLEStd.bGestioneAgentiAgente Then
            strKey2 = "Reports11"
          End If
        Else
          If OCLEStd.bCPNEbNewPerStampa = False Then
            strKey2 = "Reports8"
            strReportName = "CPCve2.RPT"
          End If
        End If

      End If
      OCLEStd.bCPNEbNewPerStampa = False

      '--------------------------------------------------
      'preparo il motore di stampa
      strCrpe = "{MOVORD.codditt} = '" & DittaCorrente & "'" & _
                " And {MOVORD.mo_anno} = " & dsGsor.Tables("TESTA").Rows(0)!et_anno.ToString & _
                " AND {MOVORD.mo_numord} = " & dsGsor.Tables("TESTA").Rows(0)!et_numdoc.ToString & _
                " AND {MOVORD.mo_serie} = '" & dsGsor.Tables("TESTA").Rows(0)!et_serie.ToString & "'" & _
                " AND {MOVORD.mo_tipork} = '" & dsGsor.Tables("TESTA").Rows(0)!et_tipork.ToString & "'" & _
                " AND {MOVORD.mo_stasino} <> 'N'" & _
                " AND {TESTORD.td_magaz2} <> {KEYORD.ko_magaz}"

      If OCLEStd.sGestOrdineConfermato = "S" And ckEt_confermato.Checked Then
        If OCLEStd.bCPNEInvioDirettoInProduzione = False Then
          If dsGsor.Tables("corpo").Rows.Count > 0 Then
            Dim bTT As Boolean = False
            For i = 0 To dsGsor.Tables("corpo").Rows.Count - 1
              If InStr(dsGsor.Tables("corpo").Rows(i)!ec_codartCliFor.ToString, ";") > 0 Then
                bTT = True
                Exit For
              End If
            Next
            If bTT Then
              strCrpe = strCrpe & " AND {CPPRODUZIONE.pr_OpLav} = 4"
            Else
              strCrpe = strCrpe & " AND ({CPPRODUZIONE.pr_OpLav} = 1 or {CPPRODUZIONE.pr_OpLav} = 4 or {CPPRODUZIONE.pr_OpLav} = 6 or (mid({MOVORD.mo_codartCliFor},1,3) = 'LAM' AND {CPPRODUZIONE.pr_OpLav} = 2))"
            End If
          End If
        End If
      End If


      nPjob = oMenu.ReportPEInit(DittaCorrente, Me, "Bshhgsor", strKey2, dsGsor.Tables("TESTA").Rows(0)!et_tipork.ToString, _
                                      0, nDestin, strReportName, False, "Stampa Ordine", False)
      If nPjob Is Nothing Then Return

      '--------------------------------------------------
      'lancio tutti gli eventuali reports (le righe che seguono gestiscono gi il multireport)
      Dim strCPNECrpe As String = strCrpe
      For i = 1 To UBound(CType(nPjob, Array), 2)
        If OCLEStd.sGestOrdineConfermato = "S" And (ckEt_confermato.Checked Or ckEt_rilasciato.Checked) Then
          If i = 2 And OCLEStd.bCPNEInvioDirettoInProduzione = False Then
            strCrpe = strCrpe & " AND {MOVORD.mo_confermato} = 'S'"
          Else
            strCrpe = strCPNECrpe
          End If

        End If
        nRis = oMenu.PESetSelectionFormula(NTSCInt(CType(nPjob, Array).GetValue(0, i)), CrpeResolveFormula(Me, CStr(CType(nPjob, Array).GetValue(2, i)), strCrpe))
        'le formule particolari calcolate da 'CrpeResolveFormula' (ci sono solo in bsveboll, bsorgsor e pochi altri programmi

        For j = 3 To 12
          If Trim(CStr(CType(nPjob, Array).GetValue(j, i))) <> "" Then
            nRis = oMenu.PESetFormula(NTSCInt(CType(nPjob, Array).GetValue(0, i)), CStr(CType(nPjob, Array).GetValue(j, i)), CrpeResolveFormula(Me, CStr(CType(nPjob, Array).GetValue(j + 10, i))))
          End If
        Next j

        nRis = oMenu.ReportPEVai(NTSCInt(CType(nPjob, Array).GetValue(0, i)))
      Next

      '--------------------------------------------------
      'aggiorno il flag di 'Stampato' su testord
      oCleGsor.AggiornaFlagStampato()
      ckEt_flstam.Checked = True

      If tlbStampaEtichetteFinale.Checked Then
        ApriEtichette(1)
      End If

      'stampo la scheda di trasporto se presente
      If oCleGsor.dttSCHETRASP.Rows.Count > 0 Then
        strKey2 = "Reports4"
        strReportName = "BSVESCTR.RPT"
        strCrpe = "{SCHETRASP.codditt} = '" & DittaCorrente & "'" & _
          " And {SCHETRASP.sct_anno} = " & dsGsor.Tables("TESTA").Rows(0)!et_anno.ToString & _
          " AND {SCHETRASP.sct_numdoc} = " & dsGsor.Tables("TESTA").Rows(0)!et_numdoc.ToString & _
          " AND {SCHETRASP.sct_serie} = '" & dsGsor.Tables("TESTA").Rows(0)!et_serie.ToString & "'" & _
          " AND {SCHETRASP.sct_tipork} = '" & dsGsor.Tables("TESTA").Rows(0)!et_tipork.ToString & "'"

        nPjob = oMenu.ReportPEInit(DittaCorrente, Me, "BSHHGSOR", strKey2, dsGsor.Tables("TESTA").Rows(0)!et_tipork.ToString, _
                                        0, nDestin, strReportName, False, "Stampa scheda di trasporto", False)
        If nPjob Is Nothing Then Return

        '--------------------------------------------------
        'lancio tutti gli eventuali reports (le righe che seguono gestiscono gi il multireport)
        For i = 1 To UBound(CType(nPjob, Array), 2)
          nRis = oMenu.PESetSelectionFormula(NTSCInt(CType(nPjob, Array).GetValue(0, i)), CrpeResolveFormula(Me, CStr(CType(nPjob, Array).GetValue(2, i)), strCrpe))
          'le formule particolari calcolate da 'CrpeResolveFormula' (ci sono solo in BSVEBOLL, BSVEBOLL e pochi altri programmi
          For j = 3 To 12
            If Trim(CStr(CType(nPjob, Array).GetValue(j, i))) <> "" Then
              nRis = oMenu.PESetFormula(NTSCInt(CType(nPjob, Array).GetValue(0, i)), CStr(CType(nPjob, Array).GetValue(j, i)), CrpeResolveFormula(Me, CStr(CType(nPjob, Array).GetValue(j + 10, i))))
            End If
          Next j
          nRis = oMenu.ReportPEVai(NTSCInt(CType(nPjob, Array).GetValue(0, i)))
        Next

      End If

    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------
    End Try
  End Sub

  Public Sub CPNEImpostaStampa(ByVal nDestin As Integer)
TRY
    If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" Then
      If oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSORGSOR", "OPZIONI", ".", "StampaResiduoOrdine", "N", " ", "N") = "S" Then

        Dim StrStampaResiduo As String = ""
        Dim ddtImpCli As DataTable
        With dsGsor.Tables("corpo").Rows(0)
          ddtImpCli = OCLEStd.CPNETrovaImpegniClientiCDep(DittaCorrente, !ec_tipork.ToString, CInt(!ec_anno), !ec_serie.ToString, CInt(!ec_numdoc))
        End With
        If ddtImpCli.Rows.Count > 0 Then
          For qq = 0 To ddtImpCli.Rows.Count - 1

            With dsGsor.Tables("corpo")
              If CInt(.Rows(0)!mo_annoDDTRic) > 0 Then
                StrStampaResiduo += StrStampaResiduo & "({movmag.mm_tipork} = 'M' and {movmag.mm_anno} = " & CInt(.Rows(qq)!mo_annoDDTRic) & " and {movmag.mm_serie} = '" & .Rows(qq)!mo_serieDDTRic.ToString & "' and {movmag.mm_numdoc} = " & CInt(.Rows(qq)!mo_numDDTRic) & "  and {movmag.mm_riga} = " & CInt(.Rows(qq)!mo_rigaDDTRic) & ") or "
              End If
            End With
          Next
          If StrStampaResiduo <> "" Then
            StrStampaResiduo = Mid(StrStampaResiduo, 1, Len(StrStampaResiduo) - 4)
            CPNEEseguiStampa(StrStampaResiduo, "BSORGSOR", "REPORTS99", " ", nDestin, "ResiduoAttesa.rpt", "Stampa")
          End If
        End If

      End If
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Sub CPNEEseguiStampa(ByVal StrWhere As String, ByVal strKey1 As String, ByVal strKey2 As String, ByVal strTipoDoc As String, ByVal nDestin As Integer, ByVal strNomeRpt As String, ByVal strCaptionWin As String)
TRY

    Dim nPjob As Object

    nPjob = oMenu.ReportPEInit(oApp.Ditta, Me, strKey1, strKey2, " ", 1, nDestin, strNomeRpt, False, strCaptionWin, False)
    If Not (nPjob Is Nothing) Then
      'lancio tutti gli eventuali reports (gestisce già il multireport)												
      For i = 1 To UBound(CType(nPjob, Array), 2)
        If StrWhere <> "" Then
          oMenu.PESetSelectionFormula(NTSCInt(CType(nPjob, Array).GetValue(0, i)), CrpeResolveFormula(Me, CStr(CType(nPjob, Array).GetValue(2, i)), StrWhere))
        End If

        oMenu.ReportPEVai(NTSCInt(CType(nPjob, Array).GetValue(0, i)))
      Next
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub tlbStampaVideo_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    'MyBase.tlbStampaVideo_ItemClick(sender, e)
  
    If OCLEStd.sGestOrdineConfermato = "S" Then
      If InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) > 0 Then
        CPNEImpostaStampeSlam(0)
      ElseIf dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "O" Or dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "X" Then
        CPNEImpostaStampeSlam(0)
      ElseIf dsGsor.Tables("testa").Rows(0)!et_serie.ToString = "C" Then
        CPNEImpostaStampeSlam(0)
      Else
        MyBase.tlbStampaVideo_ItemClick(sender, e)
        CPNEImpostaStampa(0)
      End If

    Else
      MyBase.tlbStampaVideo_ItemClick(sender, e)
      CPNEImpostaStampa(0)
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overridable Sub tlbCPNEBNHHGEAR_Click(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
    Try
      'parametri zoom sono di tipo CLE__CLDP 		
      If grvRighe.Focused Then
        'If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
        Dim parametriChil As New CLE__CLDP
        'parametriChil.strPar1 = edInvio.Text
        parametriChil.dPar1 = CInt(dsGsor.Tables("testa").Rows(0)!et_conto)
        parametriChil.strPar1 = ""
        oMenu.RunChild("NTSInformatica", "FRMHHGEAR", "Generatore articoli", DittaCorrente, "", "BNHHGEAR", parametriChil, "", True, True)
        If parametriChil.strPar1 <> "" Then
          Dim StrTmp As String = parametriChil.strPar1
          If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
            oCleGsor.AggiungiRigaCorpo(False, StrTmp, 0, 0)
            grvRighe.RefreshData()
            Application.DoEvents()
            CPNEbBloccaMessaggio = True
            dcGsorRighe.MoveLast()
            CPNEbBloccaMessaggio = False
          Else
            grvRighe.NTSGetCurrentDataRow!ec_codart = StrTmp
          End If
          ValidaLastControl()
        End If
        'Else
        '  oApp.MsgBoxInfo("Posizionarsi su di una riga vuota")
        'End If
      Else
        oApp.MsgBoxInfo("Posizionarsi sulla griglia")
      End If
    Catch ex As Exception
      CLN__STD.GestErr(ex, Me, "")
    End Try

  End Sub

  Public Sub tlbCpneScaricoFifoCDep_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    ValidaLastControl()
    If grvRighe.Focused Then
      If oMenu.GetSettingBus("BSVEBOLL", "OPTPERS", ".", "ZoomProdottoFinito", "N", " ", "N") = "S" And oMenu.GetSettingBus("BSVEBOLL", "OPTPERS", ".", "ZoomProdottoFinitoSalta", "S", " ", "S") = "N" Then
        '===================================================================
        Dim oPar As New CLE__CLDP
        oPar.Ditta = DittaCorrente
        oPar.strNomProg = "BNORGSOR"
        'If Not IsNothing(grvRighe.NTSGetCurrentDataRow) Then
        '  oPar.strPar1 = "NN" & "|" & grvRighe.NTSGetCurrentDataRow!mm_codartclifor.ToString
        'Else
        oPar.strPar1 = "NN" & "|" & "0"
        'End If
        oPar.strPar1 = oPar.strPar1 & "#" & oCleGsor.dttET.Rows(0)!et_conto.ToString
        oPar.strPar1 = oPar.strPar1 & "G" & oMenu.GetSettingBus("BSVEBOLL", "OPZIONI", ".", "CPMaterialeCL", "1", " ", "1")
        oPar.strPar1 = oPar.strPar1 & "T" & oMenu.GetSettingBus("BSVEBOLL", "OPZIONI", ".", "CPLavorazione", "2", " ", "2")
        'If oMenu.GetSettingBus("BSVEBOLL", "OPZIONI", ".", "CPCDepBloccaGrezzo", "S", " ", "S") = "S" Then
        '  oPar.strPar1 = oPar.strPar1 & "Z" & "False"
        'End If

        oMenu.RunChild("NTSInformatica", "FRMHHGRTR", "", DittaCorrente, "", "BNHHGRTR", oPar, "", True, True)

        If InStr(oPar.strPar1, "|OK|") > 0 Then
          Dim dt As New DataTable
          Dim strcodart As String = ""
          strcodart = OCLEStd.CPNEAggiornaCodArtPRod(Mid(oPar.strPar1, 9, InStr(oPar.strPar1, "#") - 1 - 8), Mid(oPar.strPar1, InStr(oPar.strPar1, "#") + 1))
          If strcodart <> "" Then
            If OCLEStd.CPNEScaricoFifoCDep(strcodart) Then
              grvRighe.NTSNuovo()
            End If
          Else
            oApp.MsgBoxInfo("Attenzione non è stato trovato l'articolo!")
          End If

        End If


        '=========================================================================================================

      Else
        If UCase(OCLEStd.strScaricoFifoMultiGrezzi) = "S" Then
          If Not IsNothing(grvRighe.NTSGetCurrentDataRow) Then
            If OCLEStd.CPNEValidaCodart(grvRighe.NTSGetCurrentDataRow!ec_codart.ToString) Then
              If OCLEStd.CPNEScaricoFifoCDep(grvRighe.NTSGetCurrentDataRow!ec_codart.ToString) Then
                grvRighe.NTSNuovo()
              End If
            Else
              oApp.MsgBoxInfo("Attenzione non è stato trovato l'articolo!" & vbCrLf & "Oppure l'articolo non è di marca " & OCLEStd.intScaricoFifoMultiGrezziMarca & "!" & vbCrLf & "Oppure l'articolo non ha la distinta base!")
            End If
          Else
            oApp.MsgBoxInfo("Attenzione non è stato trovato l'articolo!")
          End If
        Else
          oApp.MsgBoxInfo("Funzione non disponibile." & vbCr & " Attivare Opzioni 'BSVEBOLL\OPTPERS\ZoomProdottoFinito' = 'S' e 'BSVEBOLL\OPTPERS\ZoomProdottoFinitoSalta' = 'N'")
        End If
      End If
    Else
      oApp.MsgBoxInfo("Posizionarsi sulla griglia")
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Sub tlbCPNECUP_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    Dim formDaLan As New FrmCUP
    formDaLan.Init(oMenu, Nothing, DittaCorrente)
    formDaLan.InitEntity(oCleGsor)
    formDaLan.ShowDialog()
    'sposta righe funzione entity
    formDaLan.Dispose()
    formDaLan = Nothing

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Sub tlbCPNECALCPARTITA_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    dsGsor.Tables("testa").Rows(0)!et_codstag = (OCLEStd.CPNECalcolaPartita(CInt(dsGsor.Tables("testa").Rows(0)!et_anno.ToString)))
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Sub tlbCPNESALVAPARTITA_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    ValidaLastControl()
    If OCLEStd.CPNESalvaPartita() Then
      oApp.MsgBoxInfo("Il salvataggio partita è stato completato")
    Else
      oApp.MsgBoxInfo("Si è verificato un errore!!! Il salvataggio partita non è stato completato")
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Sub tlbCPNESALVAURGENZA_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    ValidaLastControl()
    If OCLEStd.CPNESalvaUrgenza() Then
      oApp.MsgBoxInfo("Il salvataggio urgenza è stato completato")
    Else
      oApp.MsgBoxInfo("Si è verificato un errore!!! Il salvataggio urgenza non è stato completato")
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Sub tlbCPNEMODPREZZORIGHE_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    If grvRighe.Focused Then
      OCLEStd.CPNEModificaPrezzoRighe()
    Else
      oApp.MsgBoxInfo("Posizionarsi sulla griglia")
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Sub tlbCPNESALVANOTE_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    Dim bValido As Boolean = False
    ValidaLastControl()

    If grvRighe.Focused Then
      If Not IsNothing(grvRighe.NTSGetCurrentDataRow) Then
        OCLEStd.strSalvaNote = grvRighe.NTSGetCurrentDataRow!ec_note.ToString
      End If
    Else
      OCLEStd.strSalvaNote = dsGsor.Tables("testa").Rows(0)!et_note.ToString
    End If

    Dim formDaLan As New FrmNOTE
    formDaLan.Init(oMenu, Nothing, DittaCorrente)
    formDaLan.InitEntity(oCleGsor)
    formDaLan.ShowDialog()
    'sposta righe funzione entity
    formDaLan.Dispose()
    formDaLan = Nothing

    If grvRighe.Focused Then
      If Not IsNothing(grvRighe.NTSGetCurrentDataRow) Then
        'grvRighe.Enabled = True
        If OCLEStd.CPNESalvaNoteRiga(grvRighe.NTSGetCurrentDataRow, grvRighe.Enabled) Then
          bValido = True
        End If
      End If
    Else
      If OCLEStd.CPNESalvaNoteTestata() Then
        bValido = True
      End If
    End If
    If bValido Then
      oApp.MsgBoxInfo("Il salvataggio note è stato completato")
    Else
      oApp.MsgBoxInfo("Si è verificato un errore!!! Il salvataggio note non è stato completato")
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Sub tlbCPNEDUPLICADOC_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
    Dim lNewProgr As Integer = 0
    Dim nNewAnno As Integer = 0
    Dim strNewSerie As String = ""
    Dim strNewTipork As String = ""
    Dim strSoloSerie As String = ""
    Dim dttTmp As New DataTable
    Dim frmOpen As FRMORSEOR = Nothing
    Try
      If oCleGsor.bNew Then
        oApp.MsgBoxInfo(oApp.Tr(Me, 128602555183593750, "Il comando può essere utilizzato solo su documenti già salvati"))
        Return
      End If

      If oCleGsor.bHasChangesET Then
        oApp.MsgBoxErr(oApp.Tr(Me, 128602622670156250, "Il documento ha subito delle modifiche dopo la sua apertura. Duplicazione non possibile"))
        Return
      End If

      'Esce se è in corso una modifica di un record
      Cursor = Cursors.WaitCursor
      If Not oCleGsor.RecordSalva(dcGsorRighe.Position, False, Nothing) Then Return
      Cursor = Cursors.Default

      '-----------------------------
      strSoloSerie = oMenu.GetSettingBusDitt(DittaCorrente, "Bsorgsor", "OpzioniDocUt", ".", "SoloSerie", "?", cbTipoDoc.SelectedValue.ToString(), "?")
      If strSoloSerie = "" Then strSoloSerie = " "

      '-----------------------------
      'visualizzo la form
      frmOpen = CType(NTSNewFormModal("FRMORSEOR"), FRMORSEOR)
      frmOpen.Init(oMenu, Nothing, DittaCorrente, Nothing)
      AddHandler oCleGsor.RemoteEvent, AddressOf frmOpen.GestisciEventiEntity
      frmOpen.oCleGsor = oCleGsor
      frmOpen.Text = oApp.Tr(Me, 128776135797240000, "Estremi nuovo documento")
      dttTmp = cbTipoDoc.DataSource.Clone
      For Each dtrT As DataRow In CType(cbTipoDoc.DataSource, DataTable).Rows
        dttTmp.ImportRow(dtrT)
      Next
      frmOpen.cbTipo.DataSource = dttTmp
      frmOpen.cbTipo.ValueMember = cbTipoDoc.ValueMember
      frmOpen.cbTipo.DisplayMember = cbTipoDoc.DisplayMember
      frmOpen.cbTipo.SelectedValue = cbTipoDoc.SelectedValue
      frmOpen.cbTipo.Enabled = True
      frmOpen.edAnno.Text = edAnnoDoc.Text
      If strSoloSerie <> "?" Then
        frmOpen.edSerie.Text = strSoloSerie
        frmOpen.edSerie.Enabled = False
      Else
        frmOpen.edSerie.Text = edSerieDoc.Text
      End If
      frmOpen.strTiporkOrig = cbTipoDoc.SelectedValue

      '--------------------------------------------
      'propongo anno e serie dell'ultimo documento creato
      frmOpen.edAnno.Text = oMenu.GetSettingBusDitt(DittaCorrente, "BNORGSOR", "Recent", ".", "LastDocNewAnno", frmOpen.edAnno.Text, " ", frmOpen.edAnno.Text)
      'frmOpen.edSerie.Text = oMenu.GetSettingBusDitt(DittaCorrente, "BNORGSOR", "Recent", ".", "LastDocNewSerie", frmOpen.edSerie.Text, " ", frmOpen.edSerie.Text).PadLeft(1)

      frmOpen.ShowDialog()
      RemoveHandler oCleGsor.RemoteEvent, AddressOf frmOpen.GestisciEventiEntity

      'ho selezionato annulla
      If frmOpen.bOk = False Then Return

      strNewTipork = frmOpen.cbTipo.SelectedValue
      nNewAnno = NTSCInt(frmOpen.edAnno.Text)
      strNewSerie = frmOpen.edSerie.Text.ToUpper
      lNewProgr = NTSCInt(frmOpen.edNumero.Text)

      If nNewAnno = 0 Then Return
      If strNewSerie = "" Then Return
      If lNewProgr = 0 Then Return

      If strNewTipork = cbTipoDoc.SelectedValue And _
         lNewProgr = NTSCInt(oCleGsor.dttET.Rows(0)!et_numdoc) And _
         strNewSerie = NTSCStr(oCleGsor.dttET.Rows(0)!et_serie) And _
         nNewAnno = NTSCInt(oCleGsor.dttET.Rows(0)!et_anno) Then Return

      Cursor = Cursors.WaitCursor

      'inoltre se cambio tipork devo ricaricare anche la griglia ...
      If oCleGsor.dttET.Rows(0)!et_tipork.ToString <> strNewTipork Then
        GctlTipoDoc = strNewTipork
        GctlSetRoules()
        GestisciGrigliaTCO()
      End If

      If OCLEStd.CPNEDuplicaDoc(strNewTipork, nNewAnno, strNewSerie, lNewProgr, NTSCInt(frmOpen.edConto.Text), NTSCInt(frmOpen.edTipoBf.Text)) Then
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

        oApp.MsgBoxInfo(oApp.Tr(Me, 128602591253906250, "Duplicazione documento terminata"))

        'pulisco i recent dei documenti da aprire
        dttOpens.Clear()
        'tlbApriRecent.Visible = False

        If oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneDataOrdineCliente", "N", " ", "N") = "S" Then
          If InStr(oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneDataOrdineClienteSerie", "0", " ", "0"), strNewSerie) > 0 Then
            If strNewTipork = "R" Then
              'edet_datdoc.Text = Date.Now
              'edEt_datpar.Text = Date.Now
              'oApp.MsgBoxInfo("Attenzione!!! La data ordine del Cliente è: " & dsGsor.Tables("testa").Rows(0)!et_datpar.ToString & ", modificarla se diversa.")
              'oApp.MsgBoxInfo("Attenzione!!! La data ordine del Cliente è: " & edEt_datpar.Text & ", modificarla se diversa.")
              CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = True
              CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = True
              CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Enabled = True
            Else
              CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = False
              CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = False
              CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Enabled = False
            End If
          Else
            CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = False
            CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = False
            CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Enabled = False
          End If
        Else
          CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = False
          CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = False
          CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Enabled = False
        End If
      Else
        oApp.MsgBoxErr(oApp.Tr(Me, 128602620241093750, "Duplicazione documento non eseguita"))
        Ripristina()
      End If
      OCLEStd.CPNEbPassataDaDuplicaDoc = False

    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------	
      Ripristina()
    Finally
      If Not frmOpen Is Nothing Then frmOpen.Dispose()
      frmOpen = Nothing
      Cursor = Cursors.Default
    End Try
  End Sub

  Private Sub tlbCPNEDetRigaTT_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    Dim strDetRiga As String
    strDetRiga = oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSHHGSOR", "OptPers", ".", "CPDettMov", "", " ", "")
    If strDetRiga = "" Then
      oApp.MsgBoxInfo("Chiave di registro BSHHGSOR\OptPers\. CPDettMov, non trovata.")
    Else
      If strDetRiga = "S" Then
        '--- Gestione dettaglio movimento nel caso in cui riga è valorizzata
        If tsGsor.SelectedTabPageIndex = 1 Then
          If Not IsNothing(grvRighe.NTSGetCurrentDataRow) Then
            If OCLEStd.sGestOrdineConfermato <> "S" Then Exit Sub
            If ckEt_confermato.Checked Then
              If Len(grvRighe.NTSGetCurrentDataRow!ec_riga) > 0 Then
                OCLEStd.CPNEGestdtDetRiga(CInt(grvRighe.NTSGetCurrentDataRow!ec_riga))
                If OCLEStd.CPNERitornaSottoGruppo(grvRighe.NTSGetCurrentDataRow!ec_codart.ToString) = 9502 Then
                  Dim bValido As Boolean = True
                  If InStr(grvRighe.NTSGetCurrentDataRow!ec_codartclifor.ToString, "_") > 0 And InStr(grvRighe.NTSGetCurrentDataRow!ec_codartclifor.ToString, ";") = 0 Then
                    bValido = False
                  End If
                  If bValido Then
                    OCLEStd.CPNEScrivehhDetMovord(grvRighe.NTSGetCurrentDataRow)

                    Dim formDaLan As New FrmDetRiga
                    formDaLan.Init(oMenu, Nothing, DittaCorrente)
                    formDaLan.InitEntity(oCleGsor)
                    formDaLan.IntRiga = CInt(grvRighe.NTSGetCurrentDataRow!ec_riga)
                    formDaLan.ShowDialog()
                    'sposta righe funzione entity
                    formDaLan.Dispose()
                    formDaLan = Nothing

                    If dsGsor.Tables("CPNEdtDetRiga").Rows.Count > 0 Then
                      Dim TotQuant As Decimal = 0
                      Dim DR As DataRow()
                      DR = dsGsor.Tables("CPNEdtDetRiga").Select("hh_riga=" & CInt(grvRighe.NTSGetCurrentDataRow!ec_riga))
                      For qq = DR.Length - 1 To 0 Step -1
                        If Not IsDBNull(DR(qq)!hh_quant) Then
                          TotQuant += CDec(DR(qq)!hh_quant)
                        End If
                      Next
                      If TotQuant > 0 Then
                        grvRighe.NTSGetCurrentDataRow!ec_quant = TotQuant
                      End If
                    End If
                  End If
                End If
              End If
            End If
          End If
        End If
      End If
    End If

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub GestisciEventiEntity(ByVal sender As Object, ByRef e As NTSEventArgs)
TRY
    'MyBase.GestisciEventiEntity(sender, e)
  
    'If Not IsMyThrowRemoteEvent() Then Return

    If OCLEStd.bDocInDuplicazione Then
      If e.Message = "Inserire sul documento corrente l'ABI/CAB del cliente/fornitore selezionato?" Then
        e.RetValue = "YES"
        Return
      End If
      If e.Message = "Il cambio della data, del Cliente o Fornitore, della destinazione diversa 1, degli agenti e del listino, con righe inserite nel corpo del documento, può comportare incongruità nel prezzo di listino, negli sconti e nelle provvigioni applicate." Then
        Return
      End If
    End If

    If OCLEStd.bPassataDaModContoOP Then
      If e.Message = "Inserire sul documento corrente l'ABI/CAB del cliente/fornitore selezionato?" Then
        e.RetValue = "YES"
        Return
      End If
      If e.Message = "Il cambio della data, del Cliente o Fornitore, della destinazione diversa 1, degli agenti e del listino, con righe inserite nel corpo del documento, può comportare incongruità nel prezzo di listino, negli sconti e nelle provvigioni applicate." Then
        Return
      End If
    End If

    If InStr(e.Message, "Articolo '") > 0 And InStr(e.Message, "': l'unità di misura") > 0 And InStr(e.Message, "non consentita.") > 0 Then
      If OCLEStd.sGestOrdineConfermato = "S" Then
        If dsGsor.Tables("testa").Rows(0)!et_tipork.ToString = "R" Then
          Dim strCodart As String = Mid(e.Message, InStr(e.Message, "'") + 1)
          strCodart = Mid(strCodart, 1, InStr(strCodart, "'") - 1)
          If InStr(OCLEStd.CPNETrovaCodartCliFor(strCodart), ";") > 0 Then
            Return
          End If
        End If
      End If
    End If

    If OCLEStd.bPassataDaOrdApertiImpTrasf Then
      If e.Message = "Il cambio della data, del Cliente o Fornitore, della destinazione diversa 1, degli agenti e del listino, con righe inserite nel corpo del documento, può comportare incongruità nel prezzo di listino, negli sconti e nelle provvigioni applicate." Then
        Return
      End If
      'If InStr(e.Message, "Attenzione: l'esistenza/disponibilità dell'articolo") > 0 Then
      '  Return
      'End If
      'If InStr(e.Message, "Attenzione: l'esistenza/disponibilità dell'articolo") > 0 Then
      '  Return
      'End If
      If InStr(e.Message, "su tutte le") > 0 Then
        e.RetValue = "YES"
        Return
      End If
    End If

    If OCLEStd.CPNEbPassataDaDuplicaDoc Then
      If e.Message = "Il cambio della data, del Cliente o Fornitore, della destinazione diversa 1, degli agenti e del listino, con righe inserite nel corpo del documento, può comportare incongruità nel prezzo di listino, negli sconti e nelle provvigioni applicate." Then
        Return
      End If
      If e.Message = "Modificare la data di consegna su tutte le righe di questo documento?" Then
        e.RetValue = "YES"
        Return
      End If
    End If
    If InStr(e.Message, "Codice sottocommessa inesistente") > 0 Or InStr(e.Message, "Modificare la subcommessa su tutte le righe di questo documento") > 0 Then
      If UCase(oMenu.GetSettingBus("BSHHGSOR", "OPZIONI", ".", "GestioneOrdiniPrioritari", "N", " ", "N")) = "S" Then
        Return
      End If
    End If

    If InStr(e.Message, "Attenzione: l'esistenza/disponibilità dell'articolo") > 0 And OCLEStd.bCPNEPassataDaGestioneAcconti Then
      Return
    End If
    If InStr(e.Message, "su tutte le") > 0 Then
      If OCLEStd.ForzaMagProduzione Then
        e.RetValue = "YES"
        Return
      End If
    End If
    If InStr(e.Message, "per confezione e Conversione") > 0 Then
      If oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSORGSOR", "OPZIONI", ".", "CtrlMsgConf", "N", " ", "N") = "S" Then
        Return
      End If
    End If
    If InStr(e.Message, "Attenzione! Nel documento sono state automaticamente generate delle commesse il cui numero è composto") > 0 Then
      Return
    End If
    If InStr(e.Message, "Modificare il campo 'Confermato' su tutte le righe di questo documento") > 0 Then
      If OCLEStd.sGestOrdineConfermato = "S" Then
        If InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), OCLEStd.dsShared.Tables("TESTA").Rows(0)!et_serie.ToString) > 0 Then
          e.RetValue = "NO"
          Return
        End If
      End If
    End If
    If InStr(e.Message, "Modificare il campo 'Rilasciato' su tutte le righe di questo documento") > 0 Then
      If OCLEStd.sGestOrdineConfermato = "S" Then
        If InStr(oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSVEBOLL", "OPZIONI", ".", "SerieOrdiniCVendita", "9", " ", "9"), OCLEStd.dsShared.Tables("TESTA").Rows(0)!et_serie.ToString) > 0 _
          Or InStr(UCase(oMenu.GetSettingBus("Bsorgsor", "OPZIONI", ".", "CDepSerieOrd", "D", " ", "D")), dsGsor.Tables("testa").Rows(0)!et_serie.ToString) > 0 Then
          e.RetValue = "NO"
          Return
        End If
      End If
    End If
    If Len(e.TipoEvento) > 5 Then
      If Mid(e.TipoEvento, 1, 5).ToUpper = "CPNE." Then
        Select Case e.TipoEvento
          Case "CPNE.LanciaCaronte"
            Dim oPar As New CLE__CLDP
            oPar.Ditta = DittaCorrente
            oPar.strNomProg = "BNVEBOLL"
            oPar.dPar1 = CDec(Mid(e.Message, 1, InStr(e.Message, "|") - 1))
            oPar.strPar1 = Mid(e.Message, InStr(e.Message, "|") + 1)

            oMenu.RunChild("NTSInformatica", "FRMHHCARO", "", DittaCorrente, "", "BNHHCARO", oPar, "", True, True)

            If oPar.strPar1 = "|OK|" Then
              e.RetValue = oPar.strPar1
            End If
            Return
            '-------------------------------------------------
          Case "CPNE.CreaDoc"
            Dim CPNEStrTipoDoc As String
            Dim CPNEIntAnnoDoc As Integer
            Dim CPNEStrSerieDoc As String
            Dim CPNEIntNumDoc As Integer


            If Strings.Left(e.Message, 1) = "D" Then
              CPNEStrTipoDoc = NTSCStr(dsGsor.Tables("testa").Rows(0)!hh_TiporkDdtReso)
              CPNEIntAnnoDoc = NTSCInt(dsGsor.Tables("testa").Rows(0)!hh_AnnoDdtReso)
              CPNEStrSerieDoc = NTSCStr(dsGsor.Tables("testa").Rows(0)!hh_SerieDdtReso)
              CPNEIntNumDoc = NTSCInt(dsGsor.Tables("testa").Rows(0)!hh_NumDdtReso)
              CPNEiContoDdtRic = 0
            Else
              CPNEStrTipoDoc = "B"
              CPNEIntAnnoDoc = CInt(Mid(e.Message, 2, 4))
              CPNEStrSerieDoc = Mid(e.Message, 6, 1)
              CPNEIntNumDoc = 0
              CPNEiContoDdtRic = CInt(Mid(e.Message, 7))
            End If


            If CPNECreaDoc(Strings.Left(e.Message, 1), CPNEStrTipoDoc, CPNEIntAnnoDoc, CPNEStrSerieDoc, CPNEIntNumDoc) Then
              CPNEIntNumDoc = CInt(oCleBoll.dttET.Rows(0)!et_numdoc)
              e.RetValue = "True|" & CPNEIntNumDoc
            Else
              e.RetValue = "False"
            End If

            Return
          Case "CPNE.AttivaDisattivaScorporo"
            If e.Message = "A" Then
              ec_prezzo.Visible = True
              ec_prezzo.Enabled = True
              ec_preziva.Visible = False
              ec_preziva.Enabled = False

            Else

            End If
          Case "CPNE.StampaRimanenzaAcconti"
            Dim StrWhere As String = "{MOVORD.mo_anno} = " & OCLEStd.CPNEAnnoNewOrdAcconti & _
                " AND {MOVORD.mo_numord} = " & OCLEStd.CPNENumNewOrdAcconti & _
                " AND {MOVORD.mo_serie} = '" & OCLEStd.sSerieDocAccontiCVenditaStampa & "'" & _
                " AND {MOVORD.mo_tipork} = 'R'" & _
                " AND {MOVORD.mo_stasino} <> 'N'" & _
                " AND {TESTORD.td_magaz2} <> {KEYORD.ko_magaz}"
            '" AND {MOVORD.mo_confermato} = 'S'"

            CPNEEseguiStampa(StrWhere, "BSHHGSOR", "REPORTS99", " ", 0, "BSHHGSOR2.rpt", "Stampa Rimanenza")
          Case "CPNE.FocusPrezzo"
            If e.Message = "PREZIVA" Then
              'grvRighe.FocusedColumn = grvRighe.Columns("ec_preziva")
              OCLEStd.bPassataDaApriVisualizzaListini = True
              ApriVisualizzaListini(1)
            Else
              'grvRighe.FocusedColumn = grvRighe.Columns("ec_prezzo")
              OCLEStd.bPassataDaApriVisualizzaListini = True
              ApriVisualizzaListini(0)
              'grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
            End If
            OCLEStd.bPassataDaApriVisualizzaListini = False
          Case "CPNE.LancioPgmRiordinoAFornitore"
            'oMenu.RunChild("BSHHGSO2", "CLSHHGSO2", oApp.Tr(Me, 129663480112850036, "Genera Ordini Da Esistenze"), DittaCorrente, "", "", Nothing, e.Message, True, True)
            'oMenu.RunChild("BNHHORES", "FRMHHORES", oApp.Tr(Me, 129663480112850036, "Genera Ordini Da Esistenze"), DittaCorrente, "", "", Nothing, e.Message, True, True)
            '================ bisogna vedere come passare i parametri a questo programma RICCARDO ============================
            'oMenu.RunChild("NTSInformatica", "FRMHHORES", "Ordini", DittaCorrente, "", "BNHHORES", oCallParams, "", True, True)
            Dim oParam As New CLE__CLDP
            oParam.strParam = e.Message
            oMenu.RunChild("NTSInformatica", "FRMHHORES", "", DittaCorrente, "", "BNHHORES", oParam, "", True, True)

          Case "CPNE.CursoreWait"
            Cursor = Cursors.WaitCursor
          Case "CPNE:CursoreDefault"
            Cursor = Cursors.Default
          Case "CPNE.VisualizzaDataOrdineClienteSi"
            CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = True
            CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = True
            CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Enabled = True
          Case "CPNE.VisualizzaDataOrdineClienteNo"
            CType(NTSFindControlByName(Me, "lbxx_DataOrdineCli"), NTSLabel).Visible = False
            CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Visible = False
            CType(NTSFindControlByName(Me, "edxx_DataOrdineCli"), NTSTextBoxData).Enabled = False
            'Case "CPNE.AbilitaDisabilitaRiga"
            '  If Left(e.Message, InStr(e.Message, "#") - 1) = "A" Then
            '    grvRighe.Enabled = True
            '    grvRighe.NTSGetCurrentDataRow!ec_note = Mid(e.Message, InStr(e.Message, "#") + 1)
            '  Else
            '    grvRighe.Enabled = False
            '  End If
            'giorgio'Case Else
            'giorgio'GestisciEventiEntity(sender, e)
        End Select
        'giorgio'Else
        'giorgio'GestisciEventiEntity(sender, e)

      End If
      'giorgio'Else
    End If
    'If e.Message = "Esiste già un documento con le stesse caratteristiche di quello che si desidera creare." Then
    '  Oclestd.CPNEAttivaDisattivaGestOp(False)
    'End If



    If e.Message = "Prezzo in valuta non modificabile per le righe di documenti di produzione interno." Then
      Return
    End If

    'If e.Message = "Modificare la data di consegna su tutte le righe di questo ordine di produzione (comprese le righe degli impegni di produzione/lavorazioni collegate)?" Then
    '  If DirectCast(sender, NTSInformatica.CLFORGSOR).dttEC.Rows(0)!ec_tipork.ToString = "H" Then
    '    e.RetValue = "YES"
    '  End If
    'End If
    If Strings.Left(e.Message, 44) = "Confermi Prezzo uguale a zero per l'articolo" Then
      If OCLEStd.CPNEbPassataDaDuplicaDoc = False Then
        If Not IsNothing(oCleBoll) Then
          If oCleBoll.dsShared.Tables("TESTA").Rows.Count > 0 Then
            If oCleBoll.dsShared.Tables("TESTA").Rows(0)!et_tipork.ToString = "B" Then
              Return
            End If
          End If
        End If
      Else
        Return
      End If

      If Not IsNothing(dsGsor.Tables("CPNEDdtNoEvaRic")) Then
        If dsGsor.Tables("CPNEDdtNoEvaRic").Rows.Count > 0 Then
          Return
        End If
      End If

      Dim StrCodart As String = Mid(e.Message, 46, InStr(e.Message, "?") - 46)
      Dim StrCodartCliFor As String

      StrCodartCliFor = OCLEStd.CPNETrovaCodartCliFor(StrCodart)

      Dim msg As New NTSEventArgs(CLN__STD.ThMsg.MSG_YESNO, "Confermi Prezzo uguale a zero per l'articolo " & StrCodartCliFor & " ?")
      'Dim msg As New NTSEventArgs(CLN__STD.ThMsg.MSG_YESNO, "Confermi Prezzo uguale a zero per l'articolo '" & grvRighe.NTSGetCurrentDataRow!ec_codartclifor & "' ?")
      If CPNEbBloccaMessaggio Then
        msg.RetValue = ThMsg.RETVALUE_YES
      Else
        MyBase.GestisciEventiEntity(sender, msg)
      End If
    ElseIf Strings.Left(e.Message, 46) = "Confermi quantità uguale a zero per l'articolo" Then
      'Dim StrCodart As String = Mid(e.Message, 48, InStr(e.Message, "?") - 48)
      'Dim StrTmp As String
      'Dim dtTmp As New DataTable

      'StrTmp = "SELECT ar_codartclifor"
      'StrTmp += " FROM artico"
      'StrTmp += " where ar_codart = '" & StrCodart & "'"
      'dtTmp = oCleGsor.oCldGsor.OpenRecordset(StrTmp, CLE__APP.DBTIPO.DBAZI)
      'Dim msg As New NTSEventArgs(CLN__STD.ThMsg.MSG_YESNO, "Confermi quantità uguale a zero per l'articolo " & dtTmp.Rows(0)!ar_codartclifor & " ?")

      If CPNEbBloccaMessaggio Then
        e.RetValue = ThMsg.RETVALUE_YES
        Exit Sub
      Else
        If OCLEStd.sGestOrdineConfermato = "S" Then
          If OCLEStd.bCPNEPassataDaGestioneAcconti Then
            e.RetValue = ThMsg.RETVALUE_YES
            Exit Sub
          End If
        End If
      End If
      Dim msg As New NTSEventArgs(CLN__STD.ThMsg.MSG_YESNO, "Confermi quantità uguale a zero per l'articolo '" & grvRighe.NTSGetCurrentDataRow!ec_codartclifor.ToString & "' ?")
      MyBase.GestisciEventiEntity(sender, msg)
      e.RetValue = msg.RetValue
      Return
    ElseIf Strings.Left(e.Message, 18) = "Per l'articolo kit" And InStr(e.Message, "non sono stati trovati articoli componenti.") > 0 Then
      'Dim StrCodart As String = Mid(e.Message, 46, InStr(e.Message, "?") - 46)
      'Dim StrTmp As String
      'Dim dtTmp As New DataTable

      'StrTmp = "SELECT ar_codartclifor"
      'StrTmp += " FROM artico"
      'StrTmp += " where ar_codart = '" & StrCodart & "'"
      'dtTmp = oCleGsor.oCldGsor.OpenRecordset(StrTmp, CLE__APP.DBTIPO.DBAZI)
      'Dim msg As New NTSEventArgs(CLN__STD.ThMsg.MSG_YESNO, "Confermi Prezzo uguale a zero per l'articolo " & dtTmp.Rows(0)!ar_codartclifor & " ?")
      If oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSORGSOR", "OPZIONI", ".", "MostraMancaKit", "S", " ", "S") = "S" Then
        Dim msg As New NTSEventArgs(CLN__STD.ThMsg.MSG_INFO, "Per l'articolo kit '" & grvRighe.NTSGetCurrentDataRow!ec_codartclifor.ToString & "' non sono stati trovati articoli componenti.")
        MyBase.GestisciEventiEntity(sender, msg)
        e.RetValue = msg.RetValue
        Return
      Else
        Return
      End If

    ElseIf Strings.Left(e.Message, 51) = "Attenzione: l'esistenza/disponibilità dell'articolo" Then
      If OCLEStd.CPNEbPassataDaDuplicaDoc = False And OCLEStd.bPassataDaRigaKit = False Then
        Dim strcodart As String = Mid(e.Message, InStr(e.Message, " '") + 2)
        strcodart = Mid(strcodart, 1, InStr(strcodart, "'") - 1)
        Dim msg As New NTSEventArgs(CLN__STD.ThMsg.MSG_INFO, "Attenzione: l'esistenza/disponibilità dell'articolo '" & OCLEStd.CPNETrovaCodartCliFor(strcodart) & "' è negativa.")
        MyBase.GestisciEventiEntity(sender, msg)
      End If
    ElseIf Strings.Left(e.Message, 126) = "Visto che è stata cambiata la quantità ordinata e/o l'opzione di evasione dell'articolo di questa riga di ORDINE DI PRODUZIONE" Then
      e.RetValue = "YES"
    Else
      MyBase.GestisciEventiEntity(sender, e)
    End If


    'giorgioEnd If

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub InitControls()
TRY
    MyBase.InitControls()
    GeneraECollegaOggettiARuntime()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub ColoraCampoAbiCab()
TRY
    'MyBase.ColoraCampoAbiCab()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  '==================== RICCARDO 18 10 2017 =========================
  Public Overrides Sub FRMORGSOR_Load(ByVal sender As Object, ByVal e As System.EventArgs)
TRY
    If Not oCallParams Is Nothing Then
      If oCallParams.strParam <> "" Then
        Dim strParam As String() = oCallParams.strParam.Split(";"c)
        Select Case strParam(0).Trim.ToUpper
          Case "NUOV", "NUOD"

          Case Else
            If strParam(1) = "R" And strParam(3) = oMenu.GetSettingBusDitt(oCleGsor.strDittaCorrente, "BSORGSOR", "OPZIONI", ".", "HOTSUNSerieOrdini", "T", " ", "T") Then
              oMenu.RunChild("NTSInformatica", "FRMQQGSOR", "Ordini", DittaCorrente, "", "BNQQGSOR", oCallParams, "", True, True)
              Me.Close()
              Exit Sub
            End If
        End Select
      End If
    End If
    MyBase.FRMORGSOR_Load(sender, e)
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  '====================FINE ======================================
  Public Overrides Function Salva(ByVal nStampa As Integer, ByVal bAllowCancel As Boolean) As Boolean
TRY
    OCLEStd.bPassatoDaBottoneSalvataggio = True
    Salva = MyBase.Salva(nStampa, bAllowCancel)
    OCLEStd.bPassatoDaBottoneSalvataggio = False
Catch ex As Exception
'-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      Return False
      '-------------------------------------------------
End Try
  End Function

#Region "old"


  'Private Sub CORPO_NTSDataBindingPositionChanged(ByRef oIn As Object, ByRef oApp As Object)
  '  With frxorgsor.grvRighe.NTSGetCurrentDataRow
  '    If frxorgsor.grvRighe.NTSGetColumnByName("ec_codart").Enabled Then

  '    End If
  '    frxorgsor.GctlSetVisEnab(frxorgsor.ec_colli, False)
  '  End With
  'End Sub


#End Region
  Public Overrides Sub tlbEsci_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
TRY
    MyBase.tlbEsci_ItemClick(sender, e)
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
End Class
