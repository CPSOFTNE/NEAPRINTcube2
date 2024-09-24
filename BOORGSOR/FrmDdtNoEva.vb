Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Imports System.Windows.Forms

Public Class FrmDdtNoEva
  Private Moduli_P As Integer = bsModAll
  Private ModuliExt_P As Integer = bsModExtAll
  Private ModuliSup_P As Integer = 0
  Private ModuliSupExt_P As Integer = 0
  Private ModuliPtn_P As Integer = 0
  Private ModuliPtnExt_P As Integer = 0

  Public Overloads Function Init(ByRef Menu As CLE__MENU, ByRef Param As CLE__CLDP, Optional ByVal Ditta As String = "", Optional ByRef SharedControls As CLE__EVNT = Nothing) As Boolean
    oMenu = Menu
    oApp = oMenu.App
    oCallParams = Param
    If Ditta <> "" Then
      DittaCorrente = Ditta
    Else
      DittaCorrente = oApp.Ditta
    End If
    Me.GctlTipoDoc = ""

    InitializeComponent()
    Me.MinimumSize = Me.Size
    Dim strErr As String = ""
    Return True
  End Function
  Public Overridable Sub InitControls()
    Dim i As Integer = 0
    Try
      '-------------------------------------------------
      'carico le immagini della toolbar
      Try

      Catch ex As Exception
        'non gestisco l'errore: se non c'è una immagine prendo quella standard
      End Try

      '-------------------------------------------------
      'completo le informazioni dei controlli
      '-------------------------------------------------
      'chiamo lo script per inizializzare i controlli caricati con source ext
      NTSScriptExec("InitControls", Me, Nothing)
    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------
    End Try
  End Sub

  Public Overridable Sub Bindcontrols()
    Try
      '-------------------------------------------------
      'se i controlli erano già  stati precedentemente collegati, li scollego
      NTSFormClearDataBinding(Me)


      edxx_DataRif.NTSDbField = "CPNEDdtNoEva.xx_datarif"
      edxx_Distinta.NTSDbField = "CPNEDdtNoEva.xx_distinta"
      edxx_Riferim.NTSDbField = "CPNEDdtNoEva.xx_riferim"
      edxx_codart.NTSDbField = "CPNEDdtNoEva.xx_codart"
      grvDdtNoEv.NTSSetParam(oMenu, oApp.Tr(Me, 129793264250461189, "q"))
      edxx_DataRif.NTSSetParam(oMenu, oApp.Tr(Me, 129793264285334676, "Data Riferimento"), True)
      edxx_Distinta.NTSSetParam(oMenu, oApp.Tr(Me, 129793264285374680, "Distinta"), 0, True)
      edxx_Riferim.NTSSetParam(oMenu, oApp.Tr(Me, 129793264285384681, "Riferimento"), 0, True)
      edxx_codart.NTSSetParam(oMenu, oApp.Tr(Me, 129793264286204763, "codice articolo"), 0, True)
      tm_datdoc.NTSSetParamDATA(oMenu, oApp.Tr(Me, 129793933586962631, "Data Doc."), True)
      an_conto.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793933586972632, "Cod. Conto"), "0", 9, 0, 999999999)
      an_descr1.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933586982633, "Descr. Conto"), 0, True)
      tm_anno.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793933586992634, "Anno"), "0", 4, 0, 9999)
      tm_serie.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933587002635, "Serie"), 0, True)
      tm_numdoc.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793933587012636, "Num Doc"), "0", 9, 0, 999999999)
      mm_riga.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793933587022637, "Riga"), "0", 9, 0, 999999999)
      mm_commeca.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793933587032638, "Commessa"), "0", 9, 0, 999999999)
      tm_tipobf.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793933587042639, "Tipo BF"), "0", 0)
      tm_riferim.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933587222657, "Riferimenti"), 0, True)
      mm_magaz.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793933587232658, "Magaz."), "0", 4, 0, 9999)
      xx_colliresidui.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793933587262661, "Colli Res"), "0", 0)
      mm_codartCliFor.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933587432678, "Codice Articolo"), 0, True)
      mm_descr.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933587442679, "Descrizione"), 0, True)
      mm_desint.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933587452680, "Descrizione Interna"), 0, True)
      hh_pos1.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933587462681, "Pos1"), 0, True)
      hh_pos2.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933587472682, "Pos2"), 0, True)
      hh_pos3.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933587482683, "Pos3"), 0, True)
      hh_pos4.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793940268692835, "Pos4"), 0, True)
      xx_codart.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793940268702835, "CodArt PF"), 0, True)
      xx_codartclifor.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793940268712835, "Codice Articolo PF"), 0, True)
      xx_codartclifor.NTSForzaVisZoom = True  ' Beretta 2015-02-19 ------------------------
      xx_pzsel.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793940268722835, "Pz Sel"), "0", 9, 0, 999999999)
      xx_seltut.NTSSetParamCHK(oMenu, oApp.Tr(Me, 129793940268732835, "Seleziona tutto"), "S", "N")

      NTSFormAddDataBinding(dcHh, Me)
      GctlSetRoules()

    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------
    End Try
  End Sub

  Public Overridable Sub InitEntity(ByRef cleSt As CLEORGSOR)
TRY
    oCleHh = cleSt
    AddHandler oCleHh.RemoteEvent, AddressOf GestisciEventiEntity
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Public ReadOnly Property Moduli() As Integer
    Get
      Return Moduli_P
    End Get
  End Property
  Public ReadOnly Property ModuliExt() As Integer
    Get
      Return ModuliExt_P
    End Get
  End Property
  Public ReadOnly Property ModuliSup() As Integer
    Get
      Return ModuliSup_P
    End Get
  End Property
  Public ReadOnly Property ModuliSupExt() As Integer
    Get
      Return ModuliSupExt_P
    End Get
  End Property
  Public ReadOnly Property ModuliPtn() As Integer
    Get
      Return ModuliPtn_P
    End Get
  End Property
  Public ReadOnly Property ModuliPtnExt() As Integer
    Get
      Return ModuliPtnExt_P
    End Get
  End Property
  Public Overloads Overrides Sub GestisciEventiEntity(ByVal sender As Object, ByRef e As NTSEventArgs)
    Dim strTmp As String
    Dim i As Integer = 0
    If Not IsMyThrowRemoteEvent() Then Return 'il messaggio non è per questa form ...
    MyBase.GestisciEventiEntity(sender, e)
    Try
      If Len(e.TipoEvento) > 5 Then
        If Mid(e.TipoEvento, 1, 5).ToUpper = "CPNE." Then
        Select e.TipoEvento
            Case "CPNE.LanciaCaronte2"
              Dim oPar As New CLE__CLDP
              oPar.Ditta = oCleHh.strDittaCorrente
              oPar.strNomProg = "BNVEBOLL"
              oPar.dPar1 = CDec(Mid(e.Message, 1, InStr(e.Message, "|") - 1))
              'oPar.strPar1 = Mid(e.Message, InStr(e.Message, "|") + 1)
              'Dim strStringa = Mid(e.Message, InStr(e.Message, "|") + 1)
              oPar.strPar1 = Mid(e.Message, InStr(e.Message, "|") + 1)
              'oPar.strPar2 = Mid(e.Message, InStr(e.Message, "#") + 1)

              oMenu.RunChild("NTSInformatica", "FRMHHCARO", "", oCleHh.strDittaCorrente, "", "BNHHCARO", oPar, "", True, True)

              If oPar.strPar1 = "|OK|" Then
                strTmp = CType(oCleHh, CLBORGSOR).CPNETrovaCodart(CInt(oPar.dPar1), grvDdtNoEv.NTSGetCurrentDataRow!xx_codartclifor.ToString)

                grvDdtNoEv.NTSGetCurrentDataRow!xx_codart = strTmp
                ValidaLastControl()


              End If

              Return


          End Select
        End If
      End If
    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------
    End Try
  End Sub
  Private Sub FRMHHELCO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Try
      If e.KeyCode = Keys.F5 Then
        If grvDdtNoEv.Focused Then
          If grvDdtNoEv.FocusedColumn.Name.ToLower = "xx_codartclifor" Then
            If oMenu.GetSettingBus("Bsorgsor", "Opzioni", ".", "BSHHGEAR", "N", " ", "N") = "S" Then
              CPNEBNHHGEAR()
              ' Beretta inizio 2015-02-20 ---------------------------------
            Else
              ' Beretta inizio 2015-03-20 ---------------------------------
              Dim oParam As New CLE__CLDP
              Dim bCPNEZoomStandard As Boolean = True
              If oMenu.GetSettingBus("BSVEBOLL", "OPTPERS", ".", "ZoomProdottoFinito", "N", " ", "N") = "S" Then
                If oMenu.GetSettingBus("BSVEBOLL", "OPTPERS", ".", "ZoomProdottoFinitoSalta", "S", " ", "S") = "N" Then
                  bCPNEZoomStandard = False
                End If
              End If
              If bCPNEZoomStandard = False Then
                Dim oPar As New CLE__CLDP
                oPar.Ditta = DittaCorrente
                oPar.strNomProg = "BNORGSOR"
                If Not IsNothing(grvDdtNoEv.NTSGetCurrentDataRow) Then
                  oPar.strPar1 = "NN" & "|" & grvDdtNoEv.NTSGetCurrentDataRow!mm_codartclifor.ToString
                Else
                  oPar.strPar1 = "NN" & "|" & "0"
                End If
                oPar.strPar1 = oPar.strPar1 & "#" & lContoCF
                oPar.strPar1 = oPar.strPar1 & "G" & oMenu.GetSettingBus("BSVEBOLL", "OPZIONI", ".", "CPMaterialeCL", "1", " ", "1")
                oPar.strPar1 = oPar.strPar1 & "T" & oMenu.GetSettingBus("BSVEBOLL", "OPZIONI", ".", "CPLavorazione", "2", " ", "2")
                If oMenu.GetSettingBus("BSVEBOLL", "OPZIONI", ".", "CPCDepBloccaGrezzo", "S", " ", "S") = "S" Then
                  oPar.strPar1 = oPar.strPar1 & "Z" & "False"
                End If

                oMenu.RunChild("NTSInformatica", "FRMHHGRTR", "", DittaCorrente, "", "BNHHGRTR", oPar, "", True, True)

                If InStr(oPar.strPar1, "|OK|") > 0 Then
                  Dim strcodart As String = ""
                  strcodart = CType(oCleHh, CLBORGSOR).CPNEAggiornaCodArtPRod(Mid(oPar.strPar1, 9, InStr(oPar.strPar1, "#") - 1 - 8), Mid(oPar.strPar1, InStr(oPar.strPar1, "#") + 1))
                  If strcodart <> "" Then
                    Dim strCodartclifor As String = CType(oCleHh, CLBORGSOR).CPNETrovaCodartCliFor(strcodart)
                    If IsNothing(grvDdtNoEv.NTSGetCurrentDataRow) Then
                      grvDdtNoEv.FocusedColumn = grvDdtNoEv.Columns("xx_codartclifor")
                      grvDdtNoEv.SetFocusedValue(strCodartclifor)
                    Else
                      grvDdtNoEv.NTSGetCurrentDataRow!xx_codartclifor = strCodartclifor
                      grvDdtNoEv.FocusedColumn.AbsoluteIndex = grvDdtNoEv.FocusedColumn.AbsoluteIndex + 1
                    End If
                  End If
                Else
                  If IsNothing(grvDdtNoEv.NTSGetCurrentDataRow) Then
                    grvDdtNoEv.FocusedColumn = grvDdtNoEv.Columns("xx_codartclifor")
                    grvDdtNoEv.SetFocusedValue(grvDdtNoEv.NTSGetCurrentDataRow!mm_codartclifor.ToString)
                  Else
                    grvDdtNoEv.NTSGetCurrentDataRow!xx_codartclifor = grvDdtNoEv.NTSGetCurrentDataRow!mm_codartclifor.ToString
                    grvDdtNoEv.FocusedColumn.AbsoluteIndex = grvDdtNoEv.FocusedColumn.AbsoluteIndex + 1
                  End If

                End If

              Else
                ' Beretta fine 2015-03-20 ---------------------------------
                'Dim oParam As New CLE__CLDP
                ValidaLastControl()
                NTSZOOM.strIn = ""
                oParam.lContoCF = 0
                NTSZOOM.ZoomStrIn("ZOOMARTICO", DittaCorrente, oParam)
                If NTSZOOM.strIn <> "" Then
                  'If IsNothing(grvDdtNoEv.NTSGetCurrentDataRow) Then
                  'Dim StrTmp As String
                  'StrTmp = CType(oCleHh, CLFORGSOR).CPNETrovaCodartCliFor(NTSZOOM.strIn)
                  'grvDdtNoEv.NTSGetCurrentDataRow!xx_codartclifor = StrTmp
                  grvDdtNoEv.NTSGetCurrentDataRow!xx_codart = NTSZOOM.strIn
                  'Else
                  '  grvDdtNoEv.NTSGetCurrentDataRow!xx_codartclifor = NTSZOOM.strIn
                  'End If
                  ValidaLastControl()
                End If
                ' Beretta fine 2015-02-20 ---------------------------------
                ' Beretta inizio 2015-03-20 ---------------------------------
              End If
              ' Beretta fine 2015-03-20 ---------------------------------
            End If
          End If
        End If
        Return
      End If
    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------	
    End Try
  End Sub
  Private Sub CPNEBNHHGEAR()
TRY
    'parametri zoom sono di tipo CLE__CLDP 		
    If grvDdtNoEv.Focused Then
      Dim parametriChil As New CLE__CLDP
      parametriChil.dPar1 = CInt(oCleHh.dsShared.Tables("testa").Rows(0)!et_conto)
      parametriChil.strPar1 = grvDdtNoEv.NTSGetCurrentDataRow!mm_codartclifor.ToString
      oMenu.RunChild("NTSInformatica", "FRMHHGEAR", "Generatore articoli", oCleHh.strDittaCorrente, "", "BNHHGEAR", parametriChil, "", True, True)
      If parametriChil.strPar1 <> "" Then
        Dim StrTmp As String = parametriChil.strPar1
        StrTmp = CType(oCleHh, CLBORGSOR).CPNETrovaCodartCliFor(StrTmp)
        grvDdtNoEv.NTSGetCurrentDataRow!xx_codartclifor = StrTmp
        ValidaLastControl()
        'StrTmp = CType(oCleHh, CLFORGSOR).CPNETrovaCodartCliFor(StrTmp)
        'grvDdtNoEv.NTSGetCurrentDataRow!xx_codartclifor = StrTmp

        'ValidaLastControl()

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
  Private components As System.ComponentModel.IContainer
  Public oCleHh As CLEORGSOR
  Public dsHh As New DataSet
  Public oCallParams As CLE__CLDP
  Public dcHh As BindingSource = New BindingSource
  Public dcHhgr As BindingSource = New BindingSource
  Public lContoCF As Decimal


  Private Sub FRMORGSOR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
TRY
    dsHh = oCleHh.dsShared
    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = dsHh.Tables("CPNEDdtNoEva")


    AggGriglia()
    Bindcontrols()

    grvDdtNoEv.NTSAllowInsert = False
    grvDdtNoEv.NTSAllowDelete = False

    GctlSetRoules()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub AggGriglia()
TRY
    dcHhgr = Nothing
    dcHhgr = New BindingSource()
    dcHhgr.DataSource = dsHh.Tables("CPNEDdtNoEvaRic")
    grDdtNoEv.DataSource = dcHhgr
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Public Sub InitializeComponent()
    Me.grDdtNoEv = New NTSInformatica.NTSGrid()
    Me.grvDdtNoEv = New NTSInformatica.NTSGridView()
    Me.xx_seltut = New NTSInformatica.NTSGridColumn()
    Me.xx_pzsel = New NTSInformatica.NTSGridColumn()
    Me.xx_codartclifor = New NTSInformatica.NTSGridColumn()
    Me.tm_datdoc = New NTSInformatica.NTSGridColumn()
    Me.an_conto = New NTSInformatica.NTSGridColumn()
    Me.an_descr1 = New NTSInformatica.NTSGridColumn()
    Me.tm_anno = New NTSInformatica.NTSGridColumn()
    Me.tm_serie = New NTSInformatica.NTSGridColumn()
    Me.tm_numdoc = New NTSInformatica.NTSGridColumn()
    Me.mm_riga = New NTSInformatica.NTSGridColumn()
    Me.mm_commeca = New NTSInformatica.NTSGridColumn()
    Me.tm_tipobf = New NTSInformatica.NTSGridColumn()
    Me.tm_riferim = New NTSInformatica.NTSGridColumn()
    Me.mm_magaz = New NTSInformatica.NTSGridColumn()
    Me.xx_colliresidui = New NTSInformatica.NTSGridColumn()
    Me.mm_codartCliFor = New NTSInformatica.NTSGridColumn()
    Me.mm_descr = New NTSInformatica.NTSGridColumn()
    Me.mm_desint = New NTSInformatica.NTSGridColumn()
    Me.hh_pos1 = New NTSInformatica.NTSGridColumn()
    Me.hh_pos2 = New NTSInformatica.NTSGridColumn()
    Me.hh_pos3 = New NTSInformatica.NTSGridColumn()
    Me.hh_pos4 = New NTSInformatica.NTSGridColumn()
    Me.xx_codart = New NTSInformatica.NTSGridColumn()
    Me.xx_kgres = New NTSInformatica.NTSGridColumn()
    Me.NtsGroupBox1 = New NTSInformatica.NTSGroupBox()
    Me.edxx_DataRif = New NTSInformatica.NTSTextBoxData()
    Me.CmdConferma = New NTSInformatica.NTSButton()
    Me.CmdEsci = New NTSInformatica.NTSButton()
    Me.CmdCerca = New NTSInformatica.NTSButton()
    Me.edxx_Distinta = New NTSInformatica.NTSTextBoxStr()
    Me.edxx_Riferim = New NTSInformatica.NTSTextBoxStr()
    Me.edxx_codart = New NTSInformatica.NTSTextBoxStr()
    Me.NtsLabel4 = New NTSInformatica.NTSLabel()
    Me.NtsLabel3 = New NTSInformatica.NTSLabel()
    Me.NtsLabel2 = New NTSInformatica.NTSLabel()
    Me.NtsLabel1 = New NTSInformatica.NTSLabel()
    CType(Me.grDdtNoEv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grvDdtNoEv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NtsGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.NtsGroupBox1.SuspendLayout()
    CType(Me.edxx_DataRif.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edxx_Distinta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edxx_Riferim.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edxx_codart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.PnCPNEPnMain = New NTSInformatica.NTSPanel()
CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).BeginInit()
Me.PnCPNEPnMain.SuspendLayout()
Me.SuspendLayout()
    '
    'frmPopup
    '
    
    
    
    
    '
    'frmAuto
    '
    
    
    
    
    '
    'grDdtNoEv
    '
    Me.grDdtNoEv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    '
    '
    '
    Me.grDdtNoEv.EmbeddedNavigator.Name = ""
    Me.grDdtNoEv.Location = New System.Drawing.Point(2, 1)
    Me.grDdtNoEv.MainView = Me.grvDdtNoEv
    Me.grDdtNoEv.Name = "grDdtNoEv"
    Me.grDdtNoEv.Size = New System.Drawing.Size(394, 216)
    Me.grDdtNoEv.TabIndex = 0
    Me.grDdtNoEv.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvDdtNoEv})
    '
    'grvDdtNoEv
    '
    Me.grvDdtNoEv.ActiveFilterEnabled = False
    Me.grvDdtNoEv.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.xx_seltut, Me.xx_pzsel, Me.xx_codartclifor, Me.tm_datdoc, Me.an_conto, Me.an_descr1, Me.tm_anno, Me.tm_serie, Me.tm_numdoc, Me.mm_riga, Me.mm_commeca, Me.tm_tipobf, Me.tm_riferim, Me.mm_magaz, Me.xx_colliresidui, Me.mm_codartCliFor, Me.mm_descr, Me.mm_desint, Me.hh_pos1, Me.hh_pos2, Me.hh_pos3, Me.hh_pos4, Me.xx_codart, Me.xx_kgres})
    Me.grvDdtNoEv.Enabled = True
    Me.grvDdtNoEv.GridControl = Me.grDdtNoEv
    Me.grvDdtNoEv.Name = "grvDdtNoEv"
    Me.grvDdtNoEv.NTSAllowDelete = True
    Me.grvDdtNoEv.NTSAllowInsert = True
    Me.grvDdtNoEv.NTSAllowUpdate = True
    Me.grvDdtNoEv.NTSMenuContext = Nothing
    Me.grvDdtNoEv.OptionsCustomization.AllowRowSizing = True
    Me.grvDdtNoEv.OptionsFilter.AllowFilterEditor = False
    Me.grvDdtNoEv.OptionsNavigation.EnterMoveNextColumn = True
    Me.grvDdtNoEv.OptionsNavigation.UseTabKey = False
    Me.grvDdtNoEv.OptionsSelection.EnableAppearanceFocusedRow = False
    Me.grvDdtNoEv.OptionsView.ColumnAutoWidth = False
    Me.grvDdtNoEv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
    Me.grvDdtNoEv.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
    Me.grvDdtNoEv.OptionsView.ShowGroupPanel = False
    Me.grvDdtNoEv.RowHeight = 14
    '
    'xx_seltut
    '
    Me.xx_seltut.AppearanceCell.Options.UseBackColor = True
    Me.xx_seltut.AppearanceCell.Options.UseTextOptions = True
    Me.xx_seltut.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.xx_seltut.Caption = "Seleziona tutto"
    Me.xx_seltut.Enabled = True
    Me.xx_seltut.FieldName = "xx_seltut"
    Me.xx_seltut.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.xx_seltut.Name = "xx_seltut"
    Me.xx_seltut.NTSRepositoryComboBox = Nothing
    Me.xx_seltut.NTSRepositoryItemCheck = Nothing
    Me.xx_seltut.NTSRepositoryItemMemo = Nothing
    Me.xx_seltut.NTSRepositoryItemText = Nothing
    Me.xx_seltut.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.xx_seltut.OptionsFilter.AllowFilter = False
    Me.xx_seltut.Visible = True
    Me.xx_seltut.VisibleIndex = 0
    '
    'xx_pzsel
    '
    Me.xx_pzsel.AppearanceCell.Options.UseBackColor = True
    Me.xx_pzsel.AppearanceCell.Options.UseTextOptions = True
    Me.xx_pzsel.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.xx_pzsel.Caption = "Pz Sel"
    Me.xx_pzsel.Enabled = True
    Me.xx_pzsel.FieldName = "xx_pzsel"
    Me.xx_pzsel.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.xx_pzsel.Name = "xx_pzsel"
    Me.xx_pzsel.NTSRepositoryComboBox = Nothing
    Me.xx_pzsel.NTSRepositoryItemCheck = Nothing
    Me.xx_pzsel.NTSRepositoryItemMemo = Nothing
    Me.xx_pzsel.NTSRepositoryItemText = Nothing
    Me.xx_pzsel.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.xx_pzsel.OptionsFilter.AllowFilter = False
    Me.xx_pzsel.Visible = True
    Me.xx_pzsel.VisibleIndex = 1
    '
    'xx_codartclifor
    '
    Me.xx_codartclifor.AppearanceCell.Options.UseBackColor = True
    Me.xx_codartclifor.AppearanceCell.Options.UseTextOptions = True
    Me.xx_codartclifor.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.xx_codartclifor.Caption = "Codice Articolo PF"
    Me.xx_codartclifor.Enabled = True
    Me.xx_codartclifor.FieldName = "xx_codartclifor"
    Me.xx_codartclifor.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.xx_codartclifor.Name = "xx_codartclifor"
    Me.xx_codartclifor.NTSRepositoryComboBox = Nothing
    Me.xx_codartclifor.NTSRepositoryItemCheck = Nothing
    Me.xx_codartclifor.NTSRepositoryItemMemo = Nothing
    Me.xx_codartclifor.NTSRepositoryItemText = Nothing
    Me.xx_codartclifor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.xx_codartclifor.OptionsFilter.AllowFilter = False
    Me.xx_codartclifor.Visible = True
    Me.xx_codartclifor.VisibleIndex = 2
    '
    'tm_datdoc
    '
    Me.tm_datdoc.AppearanceCell.Options.UseBackColor = True
    Me.tm_datdoc.AppearanceCell.Options.UseTextOptions = True
    Me.tm_datdoc.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.tm_datdoc.Caption = "Data Doc."
    Me.tm_datdoc.Enabled = False
    Me.tm_datdoc.FieldName = "tm_datdoc"
    Me.tm_datdoc.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.tm_datdoc.Name = "tm_datdoc"
    Me.tm_datdoc.NTSRepositoryComboBox = Nothing
    Me.tm_datdoc.NTSRepositoryItemCheck = Nothing
    Me.tm_datdoc.NTSRepositoryItemMemo = Nothing
    Me.tm_datdoc.NTSRepositoryItemText = Nothing
    Me.tm_datdoc.OptionsColumn.AllowEdit = False
    Me.tm_datdoc.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.tm_datdoc.OptionsColumn.ReadOnly = True
    Me.tm_datdoc.OptionsFilter.AllowFilter = False
    Me.tm_datdoc.Visible = True
    Me.tm_datdoc.VisibleIndex = 3
    '
    'an_conto
    '
    Me.an_conto.AppearanceCell.Options.UseBackColor = True
    Me.an_conto.AppearanceCell.Options.UseTextOptions = True
    Me.an_conto.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.an_conto.Caption = "Cod. Conto"
    Me.an_conto.Enabled = False
    Me.an_conto.FieldName = "an_conto"
    Me.an_conto.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.an_conto.Name = "an_conto"
    Me.an_conto.NTSRepositoryComboBox = Nothing
    Me.an_conto.NTSRepositoryItemCheck = Nothing
    Me.an_conto.NTSRepositoryItemMemo = Nothing
    Me.an_conto.NTSRepositoryItemText = Nothing
    Me.an_conto.OptionsColumn.AllowEdit = False
    Me.an_conto.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.an_conto.OptionsColumn.ReadOnly = True
    Me.an_conto.OptionsFilter.AllowFilter = False
    Me.an_conto.Visible = True
    Me.an_conto.VisibleIndex = 4
    '
    'an_descr1
    '
    Me.an_descr1.AppearanceCell.Options.UseBackColor = True
    Me.an_descr1.AppearanceCell.Options.UseTextOptions = True
    Me.an_descr1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.an_descr1.Caption = "Descr. Conto"
    Me.an_descr1.Enabled = False
    Me.an_descr1.FieldName = "an_descr1"
    Me.an_descr1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.an_descr1.Name = "an_descr1"
    Me.an_descr1.NTSRepositoryComboBox = Nothing
    Me.an_descr1.NTSRepositoryItemCheck = Nothing
    Me.an_descr1.NTSRepositoryItemMemo = Nothing
    Me.an_descr1.NTSRepositoryItemText = Nothing
    Me.an_descr1.OptionsColumn.AllowEdit = False
    Me.an_descr1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.an_descr1.OptionsColumn.ReadOnly = True
    Me.an_descr1.OptionsFilter.AllowFilter = False
    Me.an_descr1.Visible = True
    Me.an_descr1.VisibleIndex = 5
    '
    'tm_anno
    '
    Me.tm_anno.AppearanceCell.Options.UseBackColor = True
    Me.tm_anno.AppearanceCell.Options.UseTextOptions = True
    Me.tm_anno.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.tm_anno.Caption = "Anno"
    Me.tm_anno.Enabled = False
    Me.tm_anno.FieldName = "tm_anno"
    Me.tm_anno.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.tm_anno.Name = "tm_anno"
    Me.tm_anno.NTSRepositoryComboBox = Nothing
    Me.tm_anno.NTSRepositoryItemCheck = Nothing
    Me.tm_anno.NTSRepositoryItemMemo = Nothing
    Me.tm_anno.NTSRepositoryItemText = Nothing
    Me.tm_anno.OptionsColumn.AllowEdit = False
    Me.tm_anno.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.tm_anno.OptionsColumn.ReadOnly = True
    Me.tm_anno.OptionsFilter.AllowFilter = False
    Me.tm_anno.Visible = True
    Me.tm_anno.VisibleIndex = 6
    '
    'tm_serie
    '
    Me.tm_serie.AppearanceCell.Options.UseBackColor = True
    Me.tm_serie.AppearanceCell.Options.UseTextOptions = True
    Me.tm_serie.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.tm_serie.Caption = "Serie"
    Me.tm_serie.Enabled = False
    Me.tm_serie.FieldName = "tm_serie"
    Me.tm_serie.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.tm_serie.Name = "tm_serie"
    Me.tm_serie.NTSRepositoryComboBox = Nothing
    Me.tm_serie.NTSRepositoryItemCheck = Nothing
    Me.tm_serie.NTSRepositoryItemMemo = Nothing
    Me.tm_serie.NTSRepositoryItemText = Nothing
    Me.tm_serie.OptionsColumn.AllowEdit = False
    Me.tm_serie.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.tm_serie.OptionsColumn.ReadOnly = True
    Me.tm_serie.OptionsFilter.AllowFilter = False
    Me.tm_serie.Visible = True
    Me.tm_serie.VisibleIndex = 7
    '
    'tm_numdoc
    '
    Me.tm_numdoc.AppearanceCell.Options.UseBackColor = True
    Me.tm_numdoc.AppearanceCell.Options.UseTextOptions = True
    Me.tm_numdoc.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.tm_numdoc.Caption = "Num Doc"
    Me.tm_numdoc.Enabled = False
    Me.tm_numdoc.FieldName = "tm_numdoc"
    Me.tm_numdoc.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.tm_numdoc.Name = "tm_numdoc"
    Me.tm_numdoc.NTSRepositoryComboBox = Nothing
    Me.tm_numdoc.NTSRepositoryItemCheck = Nothing
    Me.tm_numdoc.NTSRepositoryItemMemo = Nothing
    Me.tm_numdoc.NTSRepositoryItemText = Nothing
    Me.tm_numdoc.OptionsColumn.AllowEdit = False
    Me.tm_numdoc.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.tm_numdoc.OptionsColumn.ReadOnly = True
    Me.tm_numdoc.OptionsFilter.AllowFilter = False
    Me.tm_numdoc.Visible = True
    Me.tm_numdoc.VisibleIndex = 8
    '
    'mm_riga
    '
    Me.mm_riga.AppearanceCell.Options.UseBackColor = True
    Me.mm_riga.AppearanceCell.Options.UseTextOptions = True
    Me.mm_riga.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mm_riga.Caption = "Riga"
    Me.mm_riga.Enabled = False
    Me.mm_riga.FieldName = "mm_riga"
    Me.mm_riga.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mm_riga.Name = "mm_riga"
    Me.mm_riga.NTSRepositoryComboBox = Nothing
    Me.mm_riga.NTSRepositoryItemCheck = Nothing
    Me.mm_riga.NTSRepositoryItemMemo = Nothing
    Me.mm_riga.NTSRepositoryItemText = Nothing
    Me.mm_riga.OptionsColumn.AllowEdit = False
    Me.mm_riga.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mm_riga.OptionsColumn.ReadOnly = True
    Me.mm_riga.OptionsFilter.AllowFilter = False
    Me.mm_riga.Visible = True
    Me.mm_riga.VisibleIndex = 9
    '
    'mm_commeca
    '
    Me.mm_commeca.AppearanceCell.Options.UseBackColor = True
    Me.mm_commeca.AppearanceCell.Options.UseTextOptions = True
    Me.mm_commeca.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mm_commeca.Caption = "Commessa"
    Me.mm_commeca.Enabled = False
    Me.mm_commeca.FieldName = "mm_commeca"
    Me.mm_commeca.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mm_commeca.Name = "mm_commeca"
    Me.mm_commeca.NTSRepositoryComboBox = Nothing
    Me.mm_commeca.NTSRepositoryItemCheck = Nothing
    Me.mm_commeca.NTSRepositoryItemMemo = Nothing
    Me.mm_commeca.NTSRepositoryItemText = Nothing
    Me.mm_commeca.OptionsColumn.AllowEdit = False
    Me.mm_commeca.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mm_commeca.OptionsColumn.ReadOnly = True
    Me.mm_commeca.OptionsFilter.AllowFilter = False
    Me.mm_commeca.Visible = True
    Me.mm_commeca.VisibleIndex = 10
    '
    'tm_tipobf
    '
    Me.tm_tipobf.AppearanceCell.Options.UseBackColor = True
    Me.tm_tipobf.AppearanceCell.Options.UseTextOptions = True
    Me.tm_tipobf.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.tm_tipobf.Caption = "Tipo BF"
    Me.tm_tipobf.Enabled = False
    Me.tm_tipobf.FieldName = "tm_tipobf"
    Me.tm_tipobf.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.tm_tipobf.Name = "tm_tipobf"
    Me.tm_tipobf.NTSRepositoryComboBox = Nothing
    Me.tm_tipobf.NTSRepositoryItemCheck = Nothing
    Me.tm_tipobf.NTSRepositoryItemMemo = Nothing
    Me.tm_tipobf.NTSRepositoryItemText = Nothing
    Me.tm_tipobf.OptionsColumn.AllowEdit = False
    Me.tm_tipobf.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.tm_tipobf.OptionsColumn.ReadOnly = True
    Me.tm_tipobf.OptionsFilter.AllowFilter = False
    Me.tm_tipobf.Visible = True
    Me.tm_tipobf.VisibleIndex = 11
    '
    'tm_riferim
    '
    Me.tm_riferim.AppearanceCell.Options.UseBackColor = True
    Me.tm_riferim.AppearanceCell.Options.UseTextOptions = True
    Me.tm_riferim.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.tm_riferim.Caption = "Riferimenti"
    Me.tm_riferim.Enabled = False
    Me.tm_riferim.FieldName = "tm_riferim"
    Me.tm_riferim.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.tm_riferim.Name = "tm_riferim"
    Me.tm_riferim.NTSRepositoryComboBox = Nothing
    Me.tm_riferim.NTSRepositoryItemCheck = Nothing
    Me.tm_riferim.NTSRepositoryItemMemo = Nothing
    Me.tm_riferim.NTSRepositoryItemText = Nothing
    Me.tm_riferim.OptionsColumn.AllowEdit = False
    Me.tm_riferim.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.tm_riferim.OptionsColumn.ReadOnly = True
    Me.tm_riferim.OptionsFilter.AllowFilter = False
    Me.tm_riferim.Visible = True
    Me.tm_riferim.VisibleIndex = 12
    '
    'mm_magaz
    '
    Me.mm_magaz.AppearanceCell.Options.UseBackColor = True
    Me.mm_magaz.AppearanceCell.Options.UseTextOptions = True
    Me.mm_magaz.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mm_magaz.Caption = "Magaz."
    Me.mm_magaz.Enabled = False
    Me.mm_magaz.FieldName = "mm_magaz"
    Me.mm_magaz.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mm_magaz.Name = "mm_magaz"
    Me.mm_magaz.NTSRepositoryComboBox = Nothing
    Me.mm_magaz.NTSRepositoryItemCheck = Nothing
    Me.mm_magaz.NTSRepositoryItemMemo = Nothing
    Me.mm_magaz.NTSRepositoryItemText = Nothing
    Me.mm_magaz.OptionsColumn.AllowEdit = False
    Me.mm_magaz.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mm_magaz.OptionsColumn.ReadOnly = True
    Me.mm_magaz.OptionsFilter.AllowFilter = False
    Me.mm_magaz.Visible = True
    Me.mm_magaz.VisibleIndex = 13
    '
    'xx_colliresidui
    '
    Me.xx_colliresidui.AppearanceCell.Options.UseBackColor = True
    Me.xx_colliresidui.AppearanceCell.Options.UseTextOptions = True
    Me.xx_colliresidui.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.xx_colliresidui.Caption = "Pz Res"
    Me.xx_colliresidui.Enabled = False
    Me.xx_colliresidui.FieldName = "xx_colliresidui"
    Me.xx_colliresidui.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.xx_colliresidui.Name = "xx_colliresidui"
    Me.xx_colliresidui.NTSRepositoryComboBox = Nothing
    Me.xx_colliresidui.NTSRepositoryItemCheck = Nothing
    Me.xx_colliresidui.NTSRepositoryItemMemo = Nothing
    Me.xx_colliresidui.NTSRepositoryItemText = Nothing
    Me.xx_colliresidui.OptionsColumn.AllowEdit = False
    Me.xx_colliresidui.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.xx_colliresidui.OptionsColumn.ReadOnly = True
    Me.xx_colliresidui.OptionsFilter.AllowFilter = False
    Me.xx_colliresidui.Visible = True
    Me.xx_colliresidui.VisibleIndex = 14
    '
    'mm_codartCliFor
    '
    Me.mm_codartCliFor.AppearanceCell.Options.UseBackColor = True
    Me.mm_codartCliFor.AppearanceCell.Options.UseTextOptions = True
    Me.mm_codartCliFor.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mm_codartCliFor.Caption = "Codice Articolo"
    Me.mm_codartCliFor.Enabled = False
    Me.mm_codartCliFor.FieldName = "mm_codartCliFor"
    Me.mm_codartCliFor.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mm_codartCliFor.Name = "mm_codartCliFor"
    Me.mm_codartCliFor.NTSRepositoryComboBox = Nothing
    Me.mm_codartCliFor.NTSRepositoryItemCheck = Nothing
    Me.mm_codartCliFor.NTSRepositoryItemMemo = Nothing
    Me.mm_codartCliFor.NTSRepositoryItemText = Nothing
    Me.mm_codartCliFor.OptionsColumn.AllowEdit = False
    Me.mm_codartCliFor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mm_codartCliFor.OptionsColumn.ReadOnly = True
    Me.mm_codartCliFor.OptionsFilter.AllowFilter = False
    Me.mm_codartCliFor.Visible = True
    Me.mm_codartCliFor.VisibleIndex = 15
    '
    'mm_descr
    '
    Me.mm_descr.AppearanceCell.Options.UseBackColor = True
    Me.mm_descr.AppearanceCell.Options.UseTextOptions = True
    Me.mm_descr.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mm_descr.Caption = "Descrizione"
    Me.mm_descr.Enabled = False
    Me.mm_descr.FieldName = "mm_descr"
    Me.mm_descr.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mm_descr.Name = "mm_descr"
    Me.mm_descr.NTSRepositoryComboBox = Nothing
    Me.mm_descr.NTSRepositoryItemCheck = Nothing
    Me.mm_descr.NTSRepositoryItemMemo = Nothing
    Me.mm_descr.NTSRepositoryItemText = Nothing
    Me.mm_descr.OptionsColumn.AllowEdit = False
    Me.mm_descr.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mm_descr.OptionsColumn.ReadOnly = True
    Me.mm_descr.OptionsFilter.AllowFilter = False
    Me.mm_descr.Visible = True
    Me.mm_descr.VisibleIndex = 16
    '
    'mm_desint
    '
    Me.mm_desint.AppearanceCell.Options.UseBackColor = True
    Me.mm_desint.AppearanceCell.Options.UseTextOptions = True
    Me.mm_desint.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mm_desint.Caption = "Descrizione Interna"
    Me.mm_desint.Enabled = False
    Me.mm_desint.FieldName = "mm_desint"
    Me.mm_desint.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mm_desint.Name = "mm_desint"
    Me.mm_desint.NTSRepositoryComboBox = Nothing
    Me.mm_desint.NTSRepositoryItemCheck = Nothing
    Me.mm_desint.NTSRepositoryItemMemo = Nothing
    Me.mm_desint.NTSRepositoryItemText = Nothing
    Me.mm_desint.OptionsColumn.AllowEdit = False
    Me.mm_desint.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mm_desint.OptionsColumn.ReadOnly = True
    Me.mm_desint.OptionsFilter.AllowFilter = False
    Me.mm_desint.Visible = True
    Me.mm_desint.VisibleIndex = 17
    '
    'hh_pos1
    '
    Me.hh_pos1.AppearanceCell.Options.UseBackColor = True
    Me.hh_pos1.AppearanceCell.Options.UseTextOptions = True
    Me.hh_pos1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_pos1.Caption = "Pos1"
    Me.hh_pos1.Enabled = False
    Me.hh_pos1.FieldName = "hh_pos1"
    Me.hh_pos1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_pos1.Name = "hh_pos1"
    Me.hh_pos1.NTSRepositoryComboBox = Nothing
    Me.hh_pos1.NTSRepositoryItemCheck = Nothing
    Me.hh_pos1.NTSRepositoryItemMemo = Nothing
    Me.hh_pos1.NTSRepositoryItemText = Nothing
    Me.hh_pos1.OptionsColumn.AllowEdit = False
    Me.hh_pos1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_pos1.OptionsColumn.ReadOnly = True
    Me.hh_pos1.OptionsFilter.AllowFilter = False
    Me.hh_pos1.Visible = True
    Me.hh_pos1.VisibleIndex = 18
    '
    'hh_pos2
    '
    Me.hh_pos2.AppearanceCell.Options.UseBackColor = True
    Me.hh_pos2.AppearanceCell.Options.UseTextOptions = True
    Me.hh_pos2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_pos2.Caption = "Pos2"
    Me.hh_pos2.Enabled = False
    Me.hh_pos2.FieldName = "hh_pos2"
    Me.hh_pos2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_pos2.Name = "hh_pos2"
    Me.hh_pos2.NTSRepositoryComboBox = Nothing
    Me.hh_pos2.NTSRepositoryItemCheck = Nothing
    Me.hh_pos2.NTSRepositoryItemMemo = Nothing
    Me.hh_pos2.NTSRepositoryItemText = Nothing
    Me.hh_pos2.OptionsColumn.AllowEdit = False
    Me.hh_pos2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_pos2.OptionsColumn.ReadOnly = True
    Me.hh_pos2.OptionsFilter.AllowFilter = False
    Me.hh_pos2.Visible = True
    Me.hh_pos2.VisibleIndex = 19
    '
    'hh_pos3
    '
    Me.hh_pos3.AppearanceCell.Options.UseBackColor = True
    Me.hh_pos3.AppearanceCell.Options.UseTextOptions = True
    Me.hh_pos3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_pos3.Caption = "Pos3"
    Me.hh_pos3.Enabled = False
    Me.hh_pos3.FieldName = "hh_pos3"
    Me.hh_pos3.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_pos3.Name = "hh_pos3"
    Me.hh_pos3.NTSRepositoryComboBox = Nothing
    Me.hh_pos3.NTSRepositoryItemCheck = Nothing
    Me.hh_pos3.NTSRepositoryItemMemo = Nothing
    Me.hh_pos3.NTSRepositoryItemText = Nothing
    Me.hh_pos3.OptionsColumn.AllowEdit = False
    Me.hh_pos3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_pos3.OptionsColumn.ReadOnly = True
    Me.hh_pos3.OptionsFilter.AllowFilter = False
    Me.hh_pos3.Visible = True
    Me.hh_pos3.VisibleIndex = 20
    '
    'hh_pos4
    '
    Me.hh_pos4.AppearanceCell.Options.UseBackColor = True
    Me.hh_pos4.AppearanceCell.Options.UseTextOptions = True
    Me.hh_pos4.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_pos4.Caption = "Pos4"
    Me.hh_pos4.Enabled = False
    Me.hh_pos4.FieldName = "hh_pos4"
    Me.hh_pos4.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_pos4.Name = "hh_pos4"
    Me.hh_pos4.NTSRepositoryComboBox = Nothing
    Me.hh_pos4.NTSRepositoryItemCheck = Nothing
    Me.hh_pos4.NTSRepositoryItemMemo = Nothing
    Me.hh_pos4.NTSRepositoryItemText = Nothing
    Me.hh_pos4.OptionsColumn.AllowEdit = False
    Me.hh_pos4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_pos4.OptionsColumn.ReadOnly = True
    Me.hh_pos4.OptionsFilter.AllowFilter = False
    Me.hh_pos4.Visible = True
    Me.hh_pos4.VisibleIndex = 21
    '
    'xx_codart
    '
    Me.xx_codart.AppearanceCell.Options.UseBackColor = True
    Me.xx_codart.AppearanceCell.Options.UseTextOptions = True
    Me.xx_codart.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.xx_codart.Caption = "CodArt PF"
    Me.xx_codart.Enabled = False
    Me.xx_codart.FieldName = "xx_codart"
    Me.xx_codart.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.xx_codart.Name = "xx_codart"
    Me.xx_codart.NTSRepositoryComboBox = Nothing
    Me.xx_codart.NTSRepositoryItemCheck = Nothing
    Me.xx_codart.NTSRepositoryItemMemo = Nothing
    Me.xx_codart.NTSRepositoryItemText = Nothing
    Me.xx_codart.OptionsColumn.AllowEdit = False
    Me.xx_codart.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.xx_codart.OptionsColumn.ReadOnly = True
    Me.xx_codart.OptionsFilter.AllowFilter = False
    '
    'xx_kgres
    '
    Me.xx_kgres.AppearanceCell.Options.UseBackColor = True
    Me.xx_kgres.AppearanceCell.Options.UseTextOptions = True
    Me.xx_kgres.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.xx_kgres.Caption = "Qta Res"
    Me.xx_kgres.Enabled = False
    Me.xx_kgres.FieldName = "xx_kgres"
    Me.xx_kgres.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.xx_kgres.Name = "xx_kgres"
    Me.xx_kgres.NTSRepositoryComboBox = Nothing
    Me.xx_kgres.NTSRepositoryItemCheck = Nothing
    Me.xx_kgres.NTSRepositoryItemMemo = Nothing
    Me.xx_kgres.NTSRepositoryItemText = Nothing
    Me.xx_kgres.OptionsColumn.AllowEdit = False
    Me.xx_kgres.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.xx_kgres.OptionsColumn.ReadOnly = True
    Me.xx_kgres.OptionsFilter.AllowFilter = False
    Me.xx_kgres.Visible = True
    Me.xx_kgres.VisibleIndex = 22
    '
    'NtsGroupBox1
    '
    Me.NtsGroupBox1.AllowDrop = True
    Me.NtsGroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.NtsGroupBox1.Appearance.BackColor = System.Drawing.Color.Transparent
    Me.NtsGroupBox1.Appearance.Options.UseBackColor = True
    Me.NtsGroupBox1.Controls.Add(Me.edxx_DataRif)
    Me.NtsGroupBox1.Controls.Add(Me.CmdConferma)
    Me.NtsGroupBox1.Controls.Add(Me.CmdEsci)
    Me.NtsGroupBox1.Controls.Add(Me.CmdCerca)
    Me.NtsGroupBox1.Controls.Add(Me.edxx_Distinta)
    Me.NtsGroupBox1.Controls.Add(Me.edxx_Riferim)
    Me.NtsGroupBox1.Controls.Add(Me.edxx_codart)
    Me.NtsGroupBox1.Controls.Add(Me.NtsLabel4)
    Me.NtsGroupBox1.Controls.Add(Me.NtsLabel3)
    Me.NtsGroupBox1.Controls.Add(Me.NtsLabel2)
    Me.NtsGroupBox1.Controls.Add(Me.NtsLabel1)
    Me.NtsGroupBox1.Cursor = System.Windows.Forms.Cursors.Default
    Me.NtsGroupBox1.Location = New System.Drawing.Point(402, 1)
    Me.NtsGroupBox1.Name = "NtsGroupBox1"
    Me.NtsGroupBox1.Size = New System.Drawing.Size(173, 216)
    Me.NtsGroupBox1.TabIndex = 1
    Me.NtsGroupBox1.Text = "Filtri"
    '
    'edxx_DataRif
    '
    Me.edxx_DataRif.Cursor = System.Windows.Forms.Cursors.Default
    Me.edxx_DataRif.Location = New System.Drawing.Point(65, 74)
    Me.edxx_DataRif.Name = "edxx_DataRif"
    Me.edxx_DataRif.NTSDbField = ""
    Me.edxx_DataRif.NTSForzaVisZoom = False
    Me.edxx_DataRif.NTSOldValue = ""
    Me.edxx_DataRif.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edxx_DataRif.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edxx_DataRif.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edxx_DataRif.Properties.MaxLength = 65536
    Me.edxx_DataRif.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edxx_DataRif.Size = New System.Drawing.Size(100, 20)
    Me.edxx_DataRif.TabIndex = 10
    '
    'CmdConferma
    '
    Me.CmdConferma.ImageText = ""
    Me.CmdConferma.Location = New System.Drawing.Point(9, 154)
    Me.CmdConferma.Name = "CmdConferma"
    Me.CmdConferma.Size = New System.Drawing.Size(156, 23)
    Me.CmdConferma.TabIndex = 9
    Me.CmdConferma.Text = "&Conferma"
    '
    'CmdEsci
    '
    Me.CmdEsci.ImageText = ""
    Me.CmdEsci.Location = New System.Drawing.Point(9, 183)
    Me.CmdEsci.Name = "CmdEsci"
    Me.CmdEsci.Size = New System.Drawing.Size(156, 23)
    Me.CmdEsci.TabIndex = 9
    Me.CmdEsci.Text = "&Annulla"
    '
    'CmdCerca
    '
    Me.CmdCerca.ImageText = ""
    Me.CmdCerca.Location = New System.Drawing.Point(9, 125)
    Me.CmdCerca.Name = "CmdCerca"
    Me.CmdCerca.Size = New System.Drawing.Size(156, 23)
    Me.CmdCerca.TabIndex = 8
    Me.CmdCerca.Text = "&Ricerca"
    '
    'edxx_Distinta
    '
    Me.edxx_Distinta.Cursor = System.Windows.Forms.Cursors.Default
    Me.edxx_Distinta.Location = New System.Drawing.Point(65, 99)
    Me.edxx_Distinta.Name = "edxx_Distinta"
    Me.edxx_Distinta.NTSDbField = ""
    Me.edxx_Distinta.NTSForzaVisZoom = False
    Me.edxx_Distinta.NTSOldValue = ""
    Me.edxx_Distinta.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edxx_Distinta.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edxx_Distinta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edxx_Distinta.Properties.MaxLength = 65536
    Me.edxx_Distinta.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edxx_Distinta.Size = New System.Drawing.Size(100, 20)
    Me.edxx_Distinta.TabIndex = 7
    '
    'edxx_Riferim
    '
    Me.edxx_Riferim.Cursor = System.Windows.Forms.Cursors.Default
    Me.edxx_Riferim.Location = New System.Drawing.Point(65, 47)
    Me.edxx_Riferim.Name = "edxx_Riferim"
    Me.edxx_Riferim.NTSDbField = ""
    Me.edxx_Riferim.NTSForzaVisZoom = False
    Me.edxx_Riferim.NTSOldValue = ""
    Me.edxx_Riferim.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edxx_Riferim.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edxx_Riferim.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edxx_Riferim.Properties.MaxLength = 65536
    Me.edxx_Riferim.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edxx_Riferim.Size = New System.Drawing.Size(100, 20)
    Me.edxx_Riferim.TabIndex = 5
    '
    'edxx_codart
    '
    Me.edxx_codart.Cursor = System.Windows.Forms.Cursors.Default
    Me.edxx_codart.Location = New System.Drawing.Point(65, 21)
    Me.edxx_codart.Name = "edxx_codart"
    Me.edxx_codart.NTSDbField = ""
    Me.edxx_codart.NTSForzaVisZoom = False
    Me.edxx_codart.NTSOldValue = ""
    Me.edxx_codart.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edxx_codart.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edxx_codart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edxx_codart.Properties.MaxLength = 65536
    Me.edxx_codart.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edxx_codart.Size = New System.Drawing.Size(100, 20)
    Me.edxx_codart.TabIndex = 4
    '
    'NtsLabel4
    '
    Me.NtsLabel4.AutoSize = True
    Me.NtsLabel4.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel4.Location = New System.Drawing.Point(6, 102)
    Me.NtsLabel4.Name = "NtsLabel4"
    Me.NtsLabel4.NTSDbField = ""
    Me.NtsLabel4.Size = New System.Drawing.Size(43, 13)
    Me.NtsLabel4.TabIndex = 3
    Me.NtsLabel4.Text = "Distinta"
    Me.NtsLabel4.Tooltip = ""
    Me.NtsLabel4.UseMnemonic = False
    '
    'NtsLabel3
    '
    Me.NtsLabel3.AutoSize = True
    Me.NtsLabel3.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel3.Location = New System.Drawing.Point(6, 76)
    Me.NtsLabel3.Name = "NtsLabel3"
    Me.NtsLabel3.NTSDbField = ""
    Me.NtsLabel3.Size = New System.Drawing.Size(53, 13)
    Me.NtsLabel3.TabIndex = 2
    Me.NtsLabel3.Text = "Data DDT"
    Me.NtsLabel3.Tooltip = ""
    Me.NtsLabel3.UseMnemonic = False
    '
    'NtsLabel2
    '
    Me.NtsLabel2.AutoSize = True
    Me.NtsLabel2.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel2.Location = New System.Drawing.Point(6, 50)
    Me.NtsLabel2.Name = "NtsLabel2"
    Me.NtsLabel2.NTSDbField = ""
    Me.NtsLabel2.Size = New System.Drawing.Size(47, 13)
    Me.NtsLabel2.TabIndex = 1
    Me.NtsLabel2.Text = "Rif. DDT"
    Me.NtsLabel2.Tooltip = ""
    Me.NtsLabel2.UseMnemonic = False
    '
    'NtsLabel1
    '
    Me.NtsLabel1.AutoSize = True
    Me.NtsLabel1.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel1.Location = New System.Drawing.Point(6, 24)
    Me.NtsLabel1.Name = "NtsLabel1"
    Me.NtsLabel1.NTSDbField = ""
    Me.NtsLabel1.Size = New System.Drawing.Size(43, 13)
    Me.NtsLabel1.TabIndex = 0
    Me.NtsLabel1.Text = "Articolo"
    Me.NtsLabel1.Tooltip = ""
    Me.NtsLabel1.UseMnemonic = False
    '
    'FrmDdtNoEva
    '
    '
'PnCPNEPnMain
'
Me.PnCPNEPnMain.AllowDrop = True
Me.PnCPNEPnMain.Appearance.BackColor = System.Drawing.Color.Transparent
Me.PnCPNEPnMain.Appearance.Options.UseBackColor = True
Me.PnCPNEPnMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
Me.PnCPNEPnMain.Dock = System.Windows.Forms.DockStyle.Fill
Me.PnCPNEPnMain.Location = New System.Drawing.Point(0, 0)
Me.PnCPNEPnMain.Name = "PnCPNEPnMain"
Me.PnCPNEPnMain.NTSActiveTrasparency = True
Me.PnCPNEPnMain.TabIndex = 3
Me.PnCPNEPnMain.Text = "PnCPNEPnMain"
Me.PnCPNEPnMain.freelayout = True
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.ClientSize = New System.Drawing.Size(581, 221)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(581, 221)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(581, 221)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsGroupBox1)
    Me.PnCPNEPnMain.Controls.Add(Me.grDdtNoEv)
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FrmDdtNoEva"
    Me.Text = "SELEZIONA DDT RICEVUTI APERTI"
    CType(Me.grDdtNoEv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grvDdtNoEv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NtsGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.NtsGroupBox1.ResumeLayout(False)
    Me.NtsGroupBox1.PerformLayout()
    CType(Me.edxx_DataRif.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edxx_Distinta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edxx_Riferim.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edxx_codart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).EndInit()
Me.PnCPNEPnMain.ResumeLayout(False)
Me.ResumeLayout(False)

  End Sub
  Private Sub CmdEsci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEsci.Click
TRY
    Dim DR As DataRow()
    DR = dsHh.Tables("CPNEDdtNoEvaRic").Select("xx_pzsel>=0")
    For I = DR.Length - 1 To 0 Step -1
      DR(I).Delete()
    Next
    Me.Close()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub CmdCerca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCerca.Click
TRY
    If CType(oCleHh, CLBORGSOR).CPNECtrGrigliaSelezionatiTtRicDDt() Then
      If oApp.MsgBoxInfoYesNo_DefYes(oApp.Tr(Me, 127791955341718750, _
                               "Attenzione! Ci sono 1 o più righe selezionate. " & _
                               "Si vuole fare una nuova ricerca?")) = System.Windows.Forms.DialogResult.No Then
        Exit Sub
      End If
    End If
    CType(oCleHh, CLBORGSOR).CPNEGestTtRicDDt()
    AggGriglia()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub CmdConferma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdConferma.Click
TRY
    ValidaLastControl()
    If CType(oCleHh, CLBORGSOR).CPNEValidaGriCPNEDdtNoEvaRic(dcHhgr.Position) Then
      Dim DR As DataRow()
      DR = dsHh.Tables("CPNEDdtNoEvaRic").Select("xx_pzsel=0")
      For I = DR.Length - 1 To 0 Step -1
        DR(I).Delete()
      Next
      dsHh.Tables("CPNEDdtNoEvaRic").AcceptChanges()
      Me.Close()
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub grDdtNoEva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grDdtNoEv.Click, grDdtNoEv.Click
TRY

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub grvDdtNoEva_NTSBeforeRowUpdate(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles grvDdtNoEv.NTSBeforeRowUpdate, grvDdtNoEv.NTSBeforeRowUpdate
TRY
    If CType(oCleHh, CLBORGSOR).CPNEValidaGriCPNEDdtNoEvaRic(dcHhgr.Position) Then
      e.Allow = True
    Else
      e.Allow = False
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
End Class
