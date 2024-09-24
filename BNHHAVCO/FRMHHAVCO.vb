Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Public Class FRMHHAVCO
#Region "Standard"
  Private Moduli_P As Integer = bsModAll
  Private ModuliExt_P As Integer = bsModExtAll
  Private ModuliSup_P As Integer = 0
  Private ModuliSupExt_P As Integer = 0
  Private ModuliPtn_P As Integer = 0
  Private ModuliPtnExt_P As Integer = 0

  Dim IntTipoStampa As Integer = 0 ' 0 = video, 1 = carta

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

    '------------------------------------------------
    'creo e attivo l'entity e inizializzo la funzione che dovrÃ  rilevare gli eventi dall'ENTITY
    Dim strErr As String = ""
    Dim oTmp As Object = Nothing
    If CLN__STD.NTSIstanziaDll(oApp.ServerDir, oApp.NetDir, "BNHHAVCO", "BEHHAVCO", oTmp, strErr, False, "", "") = False Then
      oApp.MsgBoxErr(oApp.Tr(Me, 128271029889882656, "ERRORE in fase di creazione Entity:" & vbCrLf & "|" & strErr & "|"))
      Return False
    End If
    oCleHh = CType(oTmp, CLEHHAVCO)
    oCleHh.AssociaDs(dsHh)
    oCleHh.OMenu = oMenu
    '------------------------------------------------
    
    AddHandler oCleHh.RemoteEvent, AddressOf GestisciEventiEntity
    If oCleHh.Init(oApp, NTSScript, oMenu.oCleComm, "", False, "", "") = False Then Return False

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

  Public Sub InitializeComponent()
    Me.NtsLabel1 = New NTSInformatica.NTSLabel()
    Me.NtsLabel2 = New NTSInformatica.NTSLabel()
    Me.edxx_conto = New NTSInformatica.NTSTextBoxNum()
    Me.edxx_commessa = New NTSInformatica.NTSTextBoxNum()
    Me.lbxx_desconto = New NTSInformatica.NTSLabel()
    Me.CmdRicerca = New NTSInformatica.NTSButton()
    Me.grdett = New NTSInformatica.NTSGrid()
    Me.grvdett = New NTSInformatica.NTSGridView()
    Me.co_comme = New NTSInformatica.NTSGridColumn()
    Me.hh_inizfl = New NTSInformatica.NTSGridColumn()
    Me.hh_iniznote = New NTSInformatica.NTSGridColumn()
    Me.hh_macfl = New NTSInformatica.NTSGridColumn()
    Me.hh_macnote = New NTSInformatica.NTSGridColumn()
    Me.hh_prepfl = New NTSInformatica.NTSGridColumn()
    Me.hh_prepnote = New NTSInformatica.NTSGridColumn()
    Me.hh_approvfl = New NTSInformatica.NTSGridColumn()
    Me.hh_approvnote = New NTSInformatica.NTSGridColumn()
    Me.hh_stofffl = New NTSInformatica.NTSGridColumn()
    Me.hh_stoffnote = New NTSInformatica.NTSGridColumn()
    Me.hh_stdigfl = New NTSInformatica.NTSGridColumn()
    Me.hh_stdignote = New NTSInformatica.NTSGridColumn()
    Me.hh_stserfl = New NTSInformatica.NTSGridColumn()
    Me.hh_stsernote = New NTSInformatica.NTSGridColumn()
    Me.hh_staltfl = New NTSInformatica.NTSGridColumn()
    Me.hh_staltnote = New NTSInformatica.NTSGridColumn()
    Me.hh_plastfl = New NTSInformatica.NTSGridColumn()
    Me.hh_plastnote = New NTSInformatica.NTSGridColumn()
    Me.hh_vernfl = New NTSInformatica.NTSGridColumn()
    Me.hh_vernnote = New NTSInformatica.NTSGridColumn()
    Me.hh_legpmfl = New NTSInformatica.NTSGridColumn()
    Me.hh_legpmnote = New NTSInformatica.NTSGridColumn()
    Me.hh_legeditfl = New NTSInformatica.NTSGridColumn()
    Me.hh_legeditnote = New NTSInformatica.NTSGridColumn()
    Me.hh_cartfl = New NTSInformatica.NTSGridColumn()
    Me.hh_cartnote = New NTSInformatica.NTSGridColumn()
    Me.hh_conffl = New NTSInformatica.NTSGridColumn()
    Me.hh_confnote = New NTSInformatica.NTSGridColumn()
    Me.hh_altro1fl = New NTSInformatica.NTSGridColumn()
    Me.hh_altro1note = New NTSInformatica.NTSGridColumn()
    Me.hh_altro2fl = New NTSInformatica.NTSGridColumn()
    Me.hh_altro2note = New NTSInformatica.NTSGridColumn()
    Me.hh_altro3fl = New NTSInformatica.NTSGridColumn()
    Me.hh_altro3note = New NTSInformatica.NTSGridColumn()
    Me.hh_altro4fl = New NTSInformatica.NTSGridColumn()
    Me.hh_altro4note = New NTSInformatica.NTSGridColumn()
    Me.hh_evasofl = New NTSInformatica.NTSGridColumn()
    Me.hh_evasonote = New NTSInformatica.NTSGridColumn()
    Me.NtsGroupBox1 = New NTSInformatica.NTSGroupBox()
    Me.NtsLabel3 = New NTSInformatica.NTSLabel()
    Me.edxx_data = New NTSInformatica.NTSTextBoxData()
    CType(Me.edxx_conto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edxx_commessa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grdett, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grvdett, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NtsGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.NtsGroupBox1.SuspendLayout()
    CType(Me.edxx_data.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
    'NtsLabel1
    '
    Me.NtsLabel1.AutoSize = True
    Me.NtsLabel1.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel1.Location = New System.Drawing.Point(7, 26)
    Me.NtsLabel1.Name = "NtsLabel1"
    Me.NtsLabel1.NTSDbField = ""
    Me.NtsLabel1.Size = New System.Drawing.Size(36, 13)
    Me.NtsLabel1.TabIndex = 0
    Me.NtsLabel1.Text = "Conto"
    Me.NtsLabel1.Tooltip = ""
    Me.NtsLabel1.UseMnemonic = False
    '
    'NtsLabel2
    '
    Me.NtsLabel2.AutoSize = True
    Me.NtsLabel2.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel2.Location = New System.Drawing.Point(7, 58)
    Me.NtsLabel2.Name = "NtsLabel2"
    Me.NtsLabel2.NTSDbField = ""
    Me.NtsLabel2.Size = New System.Drawing.Size(58, 13)
    Me.NtsLabel2.TabIndex = 1
    Me.NtsLabel2.Text = "Commessa"
    Me.NtsLabel2.Tooltip = ""
    Me.NtsLabel2.UseMnemonic = False
    '
    'edxx_conto
    '
    Me.edxx_conto.Cursor = System.Windows.Forms.Cursors.Default
    Me.edxx_conto.Location = New System.Drawing.Point(99, 23)
    Me.edxx_conto.Name = "edxx_conto"
    Me.edxx_conto.NTSDbField = ""
    Me.edxx_conto.NTSFormat = "0"
    Me.edxx_conto.NTSForzaVisZoom = False
    Me.edxx_conto.NTSOldValue = ""
    Me.edxx_conto.Properties.Appearance.Options.UseTextOptions = True
    Me.edxx_conto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.edxx_conto.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edxx_conto.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edxx_conto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edxx_conto.Properties.MaxLength = 65536
    Me.edxx_conto.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edxx_conto.Size = New System.Drawing.Size(94, 20)
    Me.edxx_conto.TabIndex = 2
    '
    'edxx_commessa
    '
    Me.edxx_commessa.Cursor = System.Windows.Forms.Cursors.Default
    Me.edxx_commessa.Location = New System.Drawing.Point(99, 55)
    Me.edxx_commessa.Name = "edxx_commessa"
    Me.edxx_commessa.NTSDbField = ""
    Me.edxx_commessa.NTSFormat = "0"
    Me.edxx_commessa.NTSForzaVisZoom = False
    Me.edxx_commessa.NTSOldValue = ""
    Me.edxx_commessa.Properties.Appearance.Options.UseTextOptions = True
    Me.edxx_commessa.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.edxx_commessa.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edxx_commessa.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edxx_commessa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edxx_commessa.Properties.MaxLength = 65536
    Me.edxx_commessa.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edxx_commessa.Size = New System.Drawing.Size(94, 20)
    Me.edxx_commessa.TabIndex = 3
    '
    'lbxx_desconto
    '
    Me.lbxx_desconto.BackColor = System.Drawing.Color.Transparent
    Me.lbxx_desconto.Location = New System.Drawing.Point(209, 26)
    Me.lbxx_desconto.Name = "lbxx_desconto"
    Me.lbxx_desconto.NTSDbField = ""
    Me.lbxx_desconto.Size = New System.Drawing.Size(259, 13)
    Me.lbxx_desconto.TabIndex = 4
    Me.lbxx_desconto.Text = "NtsLabel3"
    Me.lbxx_desconto.Tooltip = ""
    Me.lbxx_desconto.UseMnemonic = False
    '
    'CmdRicerca
    '
    Me.CmdRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.CmdRicerca.ImageText = ""
    Me.CmdRicerca.Location = New System.Drawing.Point(503, 12)
    Me.CmdRicerca.Name = "CmdRicerca"
    Me.CmdRicerca.Size = New System.Drawing.Size(75, 45)
    Me.CmdRicerca.TabIndex = 5
    Me.CmdRicerca.Text = "&Ricerca"
    '
    'grdett
    '
    Me.grdett.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    '
    '
    '
    Me.grdett.EmbeddedNavigator.Name = ""
    Me.grdett.Location = New System.Drawing.Point(12, 134)
    Me.grdett.MainView = Me.grvdett
    Me.grdett.Name = "grdett"
    Me.grdett.Size = New System.Drawing.Size(566, 223)
    Me.grdett.TabIndex = 6
    Me.grdett.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvdett})
    '
    'grvdett
    '
    Me.grvdett.ActiveFilterEnabled = False
    Me.grvdett.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.co_comme, Me.hh_inizfl, Me.hh_iniznote, Me.hh_macfl, Me.hh_macnote, Me.hh_prepfl, Me.hh_prepnote, Me.hh_approvfl, Me.hh_approvnote, Me.hh_stofffl, Me.hh_stoffnote, Me.hh_stdigfl, Me.hh_stdignote, Me.hh_stserfl, Me.hh_stsernote, Me.hh_staltfl, Me.hh_staltnote, Me.hh_plastfl, Me.hh_plastnote, Me.hh_vernfl, Me.hh_vernnote, Me.hh_legpmfl, Me.hh_legpmnote, Me.hh_legeditfl, Me.hh_legeditnote, Me.hh_cartfl, Me.hh_cartnote, Me.hh_conffl, Me.hh_confnote, Me.hh_altro1fl, Me.hh_altro1note, Me.hh_altro2fl, Me.hh_altro2note, Me.hh_altro3fl, Me.hh_altro3note, Me.hh_altro4fl, Me.hh_altro4note, Me.hh_evasofl, Me.hh_evasonote})
    Me.grvdett.CustomizationFormBounds = New System.Drawing.Rectangle(629, 334, 216, 183)
    Me.grvdett.Enabled = True
    Me.grvdett.GridControl = Me.grdett
    Me.grvdett.Name = "grvdett"
    Me.grvdett.NTSAllowDelete = True
    Me.grvdett.NTSAllowInsert = True
    Me.grvdett.NTSAllowUpdate = True
    Me.grvdett.NTSMenuContext = Nothing
    Me.grvdett.OptionsCustomization.AllowRowSizing = True
    Me.grvdett.OptionsFilter.AllowFilterEditor = False
    Me.grvdett.OptionsNavigation.EnterMoveNextColumn = True
    Me.grvdett.OptionsNavigation.UseTabKey = False
    Me.grvdett.OptionsSelection.EnableAppearanceFocusedRow = False
    Me.grvdett.OptionsView.ColumnAutoWidth = False
    Me.grvdett.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
    Me.grvdett.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
    Me.grvdett.OptionsView.ShowGroupPanel = False
    Me.grvdett.RowHeight = 14
    '
    'co_comme
    '
    Me.co_comme.AppearanceCell.Options.UseBackColor = True
    Me.co_comme.AppearanceCell.Options.UseTextOptions = True
    Me.co_comme.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.co_comme.Caption = "Commessa"
    Me.co_comme.Enabled = True
    Me.co_comme.FieldName = "co_comme"
    Me.co_comme.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.co_comme.Name = "co_comme"
    Me.co_comme.NTSRepositoryComboBox = Nothing
    Me.co_comme.NTSRepositoryItemCheck = Nothing
    Me.co_comme.NTSRepositoryItemMemo = Nothing
    Me.co_comme.NTSRepositoryItemText = Nothing
    Me.co_comme.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.co_comme.OptionsFilter.AllowFilter = False
    Me.co_comme.Visible = True
    Me.co_comme.VisibleIndex = 0
    '
    'hh_inizfl
    '
    Me.hh_inizfl.AppearanceCell.Options.UseBackColor = True
    Me.hh_inizfl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_inizfl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_inizfl.Caption = "Iniziato"
    Me.hh_inizfl.Enabled = True
    Me.hh_inizfl.FieldName = "hh_inizfl"
    Me.hh_inizfl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_inizfl.Name = "hh_inizfl"
    Me.hh_inizfl.NTSRepositoryComboBox = Nothing
    Me.hh_inizfl.NTSRepositoryItemCheck = Nothing
    Me.hh_inizfl.NTSRepositoryItemMemo = Nothing
    Me.hh_inizfl.NTSRepositoryItemText = Nothing
    Me.hh_inizfl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_inizfl.OptionsFilter.AllowFilter = False
    Me.hh_inizfl.Visible = True
    Me.hh_inizfl.VisibleIndex = 1
    '
    'hh_iniznote
    '
    Me.hh_iniznote.AppearanceCell.Options.UseBackColor = True
    Me.hh_iniznote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_iniznote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_iniznote.Caption = "Note Iniziato"
    Me.hh_iniznote.Enabled = True
    Me.hh_iniznote.FieldName = "hh_iniznote"
    Me.hh_iniznote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_iniznote.Name = "hh_iniznote"
    Me.hh_iniznote.NTSRepositoryComboBox = Nothing
    Me.hh_iniznote.NTSRepositoryItemCheck = Nothing
    Me.hh_iniznote.NTSRepositoryItemMemo = Nothing
    Me.hh_iniznote.NTSRepositoryItemText = Nothing
    Me.hh_iniznote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_iniznote.OptionsFilter.AllowFilter = False
    Me.hh_iniznote.Visible = True
    Me.hh_iniznote.VisibleIndex = 2
    '
    'hh_macfl
    '
    Me.hh_macfl.AppearanceCell.Options.UseBackColor = True
    Me.hh_macfl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_macfl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_macfl.Caption = "Grafica MAC"
    Me.hh_macfl.Enabled = True
    Me.hh_macfl.FieldName = "hh_macfl"
    Me.hh_macfl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_macfl.Name = "hh_macfl"
    Me.hh_macfl.NTSRepositoryComboBox = Nothing
    Me.hh_macfl.NTSRepositoryItemCheck = Nothing
    Me.hh_macfl.NTSRepositoryItemMemo = Nothing
    Me.hh_macfl.NTSRepositoryItemText = Nothing
    Me.hh_macfl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_macfl.OptionsFilter.AllowFilter = False
    Me.hh_macfl.Visible = True
    Me.hh_macfl.VisibleIndex = 3
    '
    'hh_macnote
    '
    Me.hh_macnote.AppearanceCell.Options.UseBackColor = True
    Me.hh_macnote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_macnote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_macnote.Caption = "Note Grafica MAC"
    Me.hh_macnote.Enabled = True
    Me.hh_macnote.FieldName = "hh_macnote"
    Me.hh_macnote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_macnote.Name = "hh_macnote"
    Me.hh_macnote.NTSRepositoryComboBox = Nothing
    Me.hh_macnote.NTSRepositoryItemCheck = Nothing
    Me.hh_macnote.NTSRepositoryItemMemo = Nothing
    Me.hh_macnote.NTSRepositoryItemText = Nothing
    Me.hh_macnote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_macnote.OptionsFilter.AllowFilter = False
    Me.hh_macnote.Visible = True
    Me.hh_macnote.VisibleIndex = 4
    '
    'hh_prepfl
    '
    Me.hh_prepfl.AppearanceCell.Options.UseBackColor = True
    Me.hh_prepfl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_prepfl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_prepfl.Caption = "Preparazione"
    Me.hh_prepfl.Enabled = True
    Me.hh_prepfl.FieldName = "hh_prepfl"
    Me.hh_prepfl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_prepfl.Name = "hh_prepfl"
    Me.hh_prepfl.NTSRepositoryComboBox = Nothing
    Me.hh_prepfl.NTSRepositoryItemCheck = Nothing
    Me.hh_prepfl.NTSRepositoryItemMemo = Nothing
    Me.hh_prepfl.NTSRepositoryItemText = Nothing
    Me.hh_prepfl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_prepfl.OptionsFilter.AllowFilter = False
    Me.hh_prepfl.Visible = True
    Me.hh_prepfl.VisibleIndex = 5
    '
    'hh_prepnote
    '
    Me.hh_prepnote.AppearanceCell.Options.UseBackColor = True
    Me.hh_prepnote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_prepnote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_prepnote.Caption = "Note Preparazione"
    Me.hh_prepnote.Enabled = True
    Me.hh_prepnote.FieldName = "hh_prepnote"
    Me.hh_prepnote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_prepnote.Name = "hh_prepnote"
    Me.hh_prepnote.NTSRepositoryComboBox = Nothing
    Me.hh_prepnote.NTSRepositoryItemCheck = Nothing
    Me.hh_prepnote.NTSRepositoryItemMemo = Nothing
    Me.hh_prepnote.NTSRepositoryItemText = Nothing
    Me.hh_prepnote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_prepnote.OptionsFilter.AllowFilter = False
    Me.hh_prepnote.Visible = True
    Me.hh_prepnote.VisibleIndex = 6
    '
    'hh_approvfl
    '
    Me.hh_approvfl.AppearanceCell.Options.UseBackColor = True
    Me.hh_approvfl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_approvfl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_approvfl.Caption = "Approvazione cliente"
    Me.hh_approvfl.Enabled = True
    Me.hh_approvfl.FieldName = "hh_approvfl"
    Me.hh_approvfl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_approvfl.Name = "hh_approvfl"
    Me.hh_approvfl.NTSRepositoryComboBox = Nothing
    Me.hh_approvfl.NTSRepositoryItemCheck = Nothing
    Me.hh_approvfl.NTSRepositoryItemMemo = Nothing
    Me.hh_approvfl.NTSRepositoryItemText = Nothing
    Me.hh_approvfl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_approvfl.OptionsFilter.AllowFilter = False
    Me.hh_approvfl.Visible = True
    Me.hh_approvfl.VisibleIndex = 7
    '
    'hh_approvnote
    '
    Me.hh_approvnote.AppearanceCell.Options.UseBackColor = True
    Me.hh_approvnote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_approvnote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_approvnote.Caption = "Note Approvazione cliente"
    Me.hh_approvnote.Enabled = True
    Me.hh_approvnote.FieldName = "hh_approvnote"
    Me.hh_approvnote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_approvnote.Name = "hh_approvnote"
    Me.hh_approvnote.NTSRepositoryComboBox = Nothing
    Me.hh_approvnote.NTSRepositoryItemCheck = Nothing
    Me.hh_approvnote.NTSRepositoryItemMemo = Nothing
    Me.hh_approvnote.NTSRepositoryItemText = Nothing
    Me.hh_approvnote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_approvnote.OptionsFilter.AllowFilter = False
    Me.hh_approvnote.Visible = True
    Me.hh_approvnote.VisibleIndex = 8
    '
    'hh_stofffl
    '
    Me.hh_stofffl.AppearanceCell.Options.UseBackColor = True
    Me.hh_stofffl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_stofffl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_stofffl.Caption = "Stampa offset"
    Me.hh_stofffl.Enabled = True
    Me.hh_stofffl.FieldName = "hh_stofffl"
    Me.hh_stofffl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_stofffl.Name = "hh_stofffl"
    Me.hh_stofffl.NTSRepositoryComboBox = Nothing
    Me.hh_stofffl.NTSRepositoryItemCheck = Nothing
    Me.hh_stofffl.NTSRepositoryItemMemo = Nothing
    Me.hh_stofffl.NTSRepositoryItemText = Nothing
    Me.hh_stofffl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_stofffl.OptionsFilter.AllowFilter = False
    Me.hh_stofffl.Visible = True
    Me.hh_stofffl.VisibleIndex = 9
    '
    'hh_stoffnote
    '
    Me.hh_stoffnote.AppearanceCell.Options.UseBackColor = True
    Me.hh_stoffnote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_stoffnote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_stoffnote.Caption = "Note Stampa offset"
    Me.hh_stoffnote.Enabled = True
    Me.hh_stoffnote.FieldName = "hh_stoffnote"
    Me.hh_stoffnote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_stoffnote.Name = "hh_stoffnote"
    Me.hh_stoffnote.NTSRepositoryComboBox = Nothing
    Me.hh_stoffnote.NTSRepositoryItemCheck = Nothing
    Me.hh_stoffnote.NTSRepositoryItemMemo = Nothing
    Me.hh_stoffnote.NTSRepositoryItemText = Nothing
    Me.hh_stoffnote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_stoffnote.OptionsFilter.AllowFilter = False
    Me.hh_stoffnote.Visible = True
    Me.hh_stoffnote.VisibleIndex = 10
    '
    'hh_stdigfl
    '
    Me.hh_stdigfl.AppearanceCell.Options.UseBackColor = True
    Me.hh_stdigfl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_stdigfl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_stdigfl.Caption = "Stampa digitale"
    Me.hh_stdigfl.Enabled = True
    Me.hh_stdigfl.FieldName = "hh_stdigfl"
    Me.hh_stdigfl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_stdigfl.Name = "hh_stdigfl"
    Me.hh_stdigfl.NTSRepositoryComboBox = Nothing
    Me.hh_stdigfl.NTSRepositoryItemCheck = Nothing
    Me.hh_stdigfl.NTSRepositoryItemMemo = Nothing
    Me.hh_stdigfl.NTSRepositoryItemText = Nothing
    Me.hh_stdigfl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_stdigfl.OptionsFilter.AllowFilter = False
    Me.hh_stdigfl.Visible = True
    Me.hh_stdigfl.VisibleIndex = 11
    '
    'hh_stdignote
    '
    Me.hh_stdignote.AppearanceCell.Options.UseBackColor = True
    Me.hh_stdignote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_stdignote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_stdignote.Caption = "Note Stampa digitale"
    Me.hh_stdignote.Enabled = True
    Me.hh_stdignote.FieldName = "hh_stdignote"
    Me.hh_stdignote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_stdignote.Name = "hh_stdignote"
    Me.hh_stdignote.NTSRepositoryComboBox = Nothing
    Me.hh_stdignote.NTSRepositoryItemCheck = Nothing
    Me.hh_stdignote.NTSRepositoryItemMemo = Nothing
    Me.hh_stdignote.NTSRepositoryItemText = Nothing
    Me.hh_stdignote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_stdignote.OptionsFilter.AllowFilter = False
    Me.hh_stdignote.Visible = True
    Me.hh_stdignote.VisibleIndex = 12
    '
    'hh_stserfl
    '
    Me.hh_stserfl.AppearanceCell.Options.UseBackColor = True
    Me.hh_stserfl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_stserfl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_stserfl.Caption = "Stampa serigrafica"
    Me.hh_stserfl.Enabled = True
    Me.hh_stserfl.FieldName = "hh_stserfl"
    Me.hh_stserfl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_stserfl.Name = "hh_stserfl"
    Me.hh_stserfl.NTSRepositoryComboBox = Nothing
    Me.hh_stserfl.NTSRepositoryItemCheck = Nothing
    Me.hh_stserfl.NTSRepositoryItemMemo = Nothing
    Me.hh_stserfl.NTSRepositoryItemText = Nothing
    Me.hh_stserfl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_stserfl.OptionsFilter.AllowFilter = False
    Me.hh_stserfl.Visible = True
    Me.hh_stserfl.VisibleIndex = 13
    '
    'hh_stsernote
    '
    Me.hh_stsernote.AppearanceCell.Options.UseBackColor = True
    Me.hh_stsernote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_stsernote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_stsernote.Caption = "Note Stampa serigrafica"
    Me.hh_stsernote.Enabled = True
    Me.hh_stsernote.FieldName = "hh_stsernote"
    Me.hh_stsernote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_stsernote.Name = "hh_stsernote"
    Me.hh_stsernote.NTSRepositoryComboBox = Nothing
    Me.hh_stsernote.NTSRepositoryItemCheck = Nothing
    Me.hh_stsernote.NTSRepositoryItemMemo = Nothing
    Me.hh_stsernote.NTSRepositoryItemText = Nothing
    Me.hh_stsernote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_stsernote.OptionsFilter.AllowFilter = False
    Me.hh_stsernote.Visible = True
    Me.hh_stsernote.VisibleIndex = 14
    '
    'hh_staltfl
    '
    Me.hh_staltfl.AppearanceCell.Options.UseBackColor = True
    Me.hh_staltfl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_staltfl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_staltfl.Caption = "Stampa altro"
    Me.hh_staltfl.Enabled = True
    Me.hh_staltfl.FieldName = "hh_staltfl"
    Me.hh_staltfl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_staltfl.Name = "hh_staltfl"
    Me.hh_staltfl.NTSRepositoryComboBox = Nothing
    Me.hh_staltfl.NTSRepositoryItemCheck = Nothing
    Me.hh_staltfl.NTSRepositoryItemMemo = Nothing
    Me.hh_staltfl.NTSRepositoryItemText = Nothing
    Me.hh_staltfl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_staltfl.OptionsFilter.AllowFilter = False
    Me.hh_staltfl.Visible = True
    Me.hh_staltfl.VisibleIndex = 15
    '
    'hh_staltnote
    '
    Me.hh_staltnote.AppearanceCell.Options.UseBackColor = True
    Me.hh_staltnote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_staltnote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_staltnote.Caption = "Note Stampa altro"
    Me.hh_staltnote.Enabled = True
    Me.hh_staltnote.FieldName = "hh_staltnote"
    Me.hh_staltnote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_staltnote.Name = "hh_staltnote"
    Me.hh_staltnote.NTSRepositoryComboBox = Nothing
    Me.hh_staltnote.NTSRepositoryItemCheck = Nothing
    Me.hh_staltnote.NTSRepositoryItemMemo = Nothing
    Me.hh_staltnote.NTSRepositoryItemText = Nothing
    Me.hh_staltnote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_staltnote.OptionsFilter.AllowFilter = False
    Me.hh_staltnote.Visible = True
    Me.hh_staltnote.VisibleIndex = 16
    '
    'hh_plastfl
    '
    Me.hh_plastfl.AppearanceCell.Options.UseBackColor = True
    Me.hh_plastfl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_plastfl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_plastfl.Caption = "Plastificazione"
    Me.hh_plastfl.Enabled = True
    Me.hh_plastfl.FieldName = "hh_plastfl"
    Me.hh_plastfl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_plastfl.Name = "hh_plastfl"
    Me.hh_plastfl.NTSRepositoryComboBox = Nothing
    Me.hh_plastfl.NTSRepositoryItemCheck = Nothing
    Me.hh_plastfl.NTSRepositoryItemMemo = Nothing
    Me.hh_plastfl.NTSRepositoryItemText = Nothing
    Me.hh_plastfl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_plastfl.OptionsFilter.AllowFilter = False
    Me.hh_plastfl.Visible = True
    Me.hh_plastfl.VisibleIndex = 17
    '
    'hh_plastnote
    '
    Me.hh_plastnote.AppearanceCell.Options.UseBackColor = True
    Me.hh_plastnote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_plastnote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_plastnote.Caption = "Note Plastificazione"
    Me.hh_plastnote.Enabled = True
    Me.hh_plastnote.FieldName = "hh_plastnote"
    Me.hh_plastnote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_plastnote.Name = "hh_plastnote"
    Me.hh_plastnote.NTSRepositoryComboBox = Nothing
    Me.hh_plastnote.NTSRepositoryItemCheck = Nothing
    Me.hh_plastnote.NTSRepositoryItemMemo = Nothing
    Me.hh_plastnote.NTSRepositoryItemText = Nothing
    Me.hh_plastnote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_plastnote.OptionsFilter.AllowFilter = False
    Me.hh_plastnote.Visible = True
    Me.hh_plastnote.VisibleIndex = 18
    '
    'hh_vernfl
    '
    Me.hh_vernfl.AppearanceCell.Options.UseBackColor = True
    Me.hh_vernfl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_vernfl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_vernfl.Caption = "Verniciatura"
    Me.hh_vernfl.Enabled = True
    Me.hh_vernfl.FieldName = "hh_vernfl"
    Me.hh_vernfl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_vernfl.Name = "hh_vernfl"
    Me.hh_vernfl.NTSRepositoryComboBox = Nothing
    Me.hh_vernfl.NTSRepositoryItemCheck = Nothing
    Me.hh_vernfl.NTSRepositoryItemMemo = Nothing
    Me.hh_vernfl.NTSRepositoryItemText = Nothing
    Me.hh_vernfl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_vernfl.OptionsFilter.AllowFilter = False
    Me.hh_vernfl.Visible = True
    Me.hh_vernfl.VisibleIndex = 19
    '
    'hh_vernnote
    '
    Me.hh_vernnote.AppearanceCell.Options.UseBackColor = True
    Me.hh_vernnote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_vernnote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_vernnote.Caption = "Note Verniciatura"
    Me.hh_vernnote.Enabled = True
    Me.hh_vernnote.FieldName = "hh_vernnote"
    Me.hh_vernnote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_vernnote.Name = "hh_vernnote"
    Me.hh_vernnote.NTSRepositoryComboBox = Nothing
    Me.hh_vernnote.NTSRepositoryItemCheck = Nothing
    Me.hh_vernnote.NTSRepositoryItemMemo = Nothing
    Me.hh_vernnote.NTSRepositoryItemText = Nothing
    Me.hh_vernnote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_vernnote.OptionsFilter.AllowFilter = False
    Me.hh_vernnote.Visible = True
    Me.hh_vernnote.VisibleIndex = 20
    '
    'hh_legpmfl
    '
    Me.hh_legpmfl.AppearanceCell.Options.UseBackColor = True
    Me.hh_legpmfl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_legpmfl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_legpmfl.Caption = "Legatoria p.m./piega"
    Me.hh_legpmfl.Enabled = True
    Me.hh_legpmfl.FieldName = "hh_legpmfl"
    Me.hh_legpmfl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_legpmfl.Name = "hh_legpmfl"
    Me.hh_legpmfl.NTSRepositoryComboBox = Nothing
    Me.hh_legpmfl.NTSRepositoryItemCheck = Nothing
    Me.hh_legpmfl.NTSRepositoryItemMemo = Nothing
    Me.hh_legpmfl.NTSRepositoryItemText = Nothing
    Me.hh_legpmfl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_legpmfl.OptionsFilter.AllowFilter = False
    Me.hh_legpmfl.Visible = True
    Me.hh_legpmfl.VisibleIndex = 21
    '
    'hh_legpmnote
    '
    Me.hh_legpmnote.AppearanceCell.Options.UseBackColor = True
    Me.hh_legpmnote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_legpmnote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_legpmnote.Caption = "Note Legatoria p.m./piega"
    Me.hh_legpmnote.Enabled = True
    Me.hh_legpmnote.FieldName = "hh_legpmnote"
    Me.hh_legpmnote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_legpmnote.Name = "hh_legpmnote"
    Me.hh_legpmnote.NTSRepositoryComboBox = Nothing
    Me.hh_legpmnote.NTSRepositoryItemCheck = Nothing
    Me.hh_legpmnote.NTSRepositoryItemMemo = Nothing
    Me.hh_legpmnote.NTSRepositoryItemText = Nothing
    Me.hh_legpmnote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_legpmnote.OptionsFilter.AllowFilter = False
    Me.hh_legpmnote.Visible = True
    Me.hh_legpmnote.VisibleIndex = 22
    '
    'hh_legeditfl
    '
    Me.hh_legeditfl.AppearanceCell.Options.UseBackColor = True
    Me.hh_legeditfl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_legeditfl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_legeditfl.Caption = "Legatoria editoriale"
    Me.hh_legeditfl.Enabled = True
    Me.hh_legeditfl.FieldName = "hh_legeditfl"
    Me.hh_legeditfl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_legeditfl.Name = "hh_legeditfl"
    Me.hh_legeditfl.NTSRepositoryComboBox = Nothing
    Me.hh_legeditfl.NTSRepositoryItemCheck = Nothing
    Me.hh_legeditfl.NTSRepositoryItemMemo = Nothing
    Me.hh_legeditfl.NTSRepositoryItemText = Nothing
    Me.hh_legeditfl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_legeditfl.OptionsFilter.AllowFilter = False
    Me.hh_legeditfl.Visible = True
    Me.hh_legeditfl.VisibleIndex = 23
    '
    'hh_legeditnote
    '
    Me.hh_legeditnote.AppearanceCell.Options.UseBackColor = True
    Me.hh_legeditnote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_legeditnote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_legeditnote.Caption = "Note Legatoria editoriale"
    Me.hh_legeditnote.Enabled = True
    Me.hh_legeditnote.FieldName = "hh_legeditnote"
    Me.hh_legeditnote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_legeditnote.Name = "hh_legeditnote"
    Me.hh_legeditnote.NTSRepositoryComboBox = Nothing
    Me.hh_legeditnote.NTSRepositoryItemCheck = Nothing
    Me.hh_legeditnote.NTSRepositoryItemMemo = Nothing
    Me.hh_legeditnote.NTSRepositoryItemText = Nothing
    Me.hh_legeditnote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_legeditnote.OptionsFilter.AllowFilter = False
    Me.hh_legeditnote.Visible = True
    Me.hh_legeditnote.VisibleIndex = 24
    '
    'hh_cartfl
    '
    Me.hh_cartfl.AppearanceCell.Options.UseBackColor = True
    Me.hh_cartfl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_cartfl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_cartfl.Caption = "Cartotecnica"
    Me.hh_cartfl.Enabled = True
    Me.hh_cartfl.FieldName = "hh_cartfl"
    Me.hh_cartfl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_cartfl.Name = "hh_cartfl"
    Me.hh_cartfl.NTSRepositoryComboBox = Nothing
    Me.hh_cartfl.NTSRepositoryItemCheck = Nothing
    Me.hh_cartfl.NTSRepositoryItemMemo = Nothing
    Me.hh_cartfl.NTSRepositoryItemText = Nothing
    Me.hh_cartfl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_cartfl.OptionsFilter.AllowFilter = False
    Me.hh_cartfl.Visible = True
    Me.hh_cartfl.VisibleIndex = 25
    '
    'hh_cartnote
    '
    Me.hh_cartnote.AppearanceCell.Options.UseBackColor = True
    Me.hh_cartnote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_cartnote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_cartnote.Caption = "Note Cartotecnica"
    Me.hh_cartnote.Enabled = True
    Me.hh_cartnote.FieldName = "hh_cartnote"
    Me.hh_cartnote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_cartnote.Name = "hh_cartnote"
    Me.hh_cartnote.NTSRepositoryComboBox = Nothing
    Me.hh_cartnote.NTSRepositoryItemCheck = Nothing
    Me.hh_cartnote.NTSRepositoryItemMemo = Nothing
    Me.hh_cartnote.NTSRepositoryItemText = Nothing
    Me.hh_cartnote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_cartnote.OptionsFilter.AllowFilter = False
    Me.hh_cartnote.Visible = True
    Me.hh_cartnote.VisibleIndex = 26
    '
    'hh_conffl
    '
    Me.hh_conffl.AppearanceCell.Options.UseBackColor = True
    Me.hh_conffl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_conffl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_conffl.Caption = "Confezione"
    Me.hh_conffl.Enabled = True
    Me.hh_conffl.FieldName = "hh_conffl"
    Me.hh_conffl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_conffl.Name = "hh_conffl"
    Me.hh_conffl.NTSRepositoryComboBox = Nothing
    Me.hh_conffl.NTSRepositoryItemCheck = Nothing
    Me.hh_conffl.NTSRepositoryItemMemo = Nothing
    Me.hh_conffl.NTSRepositoryItemText = Nothing
    Me.hh_conffl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_conffl.OptionsFilter.AllowFilter = False
    Me.hh_conffl.Visible = True
    Me.hh_conffl.VisibleIndex = 27
    '
    'hh_confnote
    '
    Me.hh_confnote.AppearanceCell.Options.UseBackColor = True
    Me.hh_confnote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_confnote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_confnote.Caption = "Note Confezione"
    Me.hh_confnote.Enabled = True
    Me.hh_confnote.FieldName = "hh_confnote"
    Me.hh_confnote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_confnote.Name = "hh_confnote"
    Me.hh_confnote.NTSRepositoryComboBox = Nothing
    Me.hh_confnote.NTSRepositoryItemCheck = Nothing
    Me.hh_confnote.NTSRepositoryItemMemo = Nothing
    Me.hh_confnote.NTSRepositoryItemText = Nothing
    Me.hh_confnote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_confnote.OptionsFilter.AllowFilter = False
    Me.hh_confnote.Visible = True
    Me.hh_confnote.VisibleIndex = 28
    '
    'hh_altro1fl
    '
    Me.hh_altro1fl.AppearanceCell.Options.UseBackColor = True
    Me.hh_altro1fl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_altro1fl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_altro1fl.Caption = "Altro 1"
    Me.hh_altro1fl.Enabled = True
    Me.hh_altro1fl.FieldName = "hh_altro1fl"
    Me.hh_altro1fl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_altro1fl.Name = "hh_altro1fl"
    Me.hh_altro1fl.NTSRepositoryComboBox = Nothing
    Me.hh_altro1fl.NTSRepositoryItemCheck = Nothing
    Me.hh_altro1fl.NTSRepositoryItemMemo = Nothing
    Me.hh_altro1fl.NTSRepositoryItemText = Nothing
    Me.hh_altro1fl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_altro1fl.OptionsFilter.AllowFilter = False
    Me.hh_altro1fl.Visible = True
    Me.hh_altro1fl.VisibleIndex = 29
    '
    'hh_altro1note
    '
    Me.hh_altro1note.AppearanceCell.Options.UseBackColor = True
    Me.hh_altro1note.AppearanceCell.Options.UseTextOptions = True
    Me.hh_altro1note.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_altro1note.Caption = "Note Altro 1"
    Me.hh_altro1note.Enabled = True
    Me.hh_altro1note.FieldName = "hh_altro1note"
    Me.hh_altro1note.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_altro1note.Name = "hh_altro1note"
    Me.hh_altro1note.NTSRepositoryComboBox = Nothing
    Me.hh_altro1note.NTSRepositoryItemCheck = Nothing
    Me.hh_altro1note.NTSRepositoryItemMemo = Nothing
    Me.hh_altro1note.NTSRepositoryItemText = Nothing
    Me.hh_altro1note.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_altro1note.OptionsFilter.AllowFilter = False
    Me.hh_altro1note.Visible = True
    Me.hh_altro1note.VisibleIndex = 30
    '
    'hh_altro2fl
    '
    Me.hh_altro2fl.AppearanceCell.Options.UseBackColor = True
    Me.hh_altro2fl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_altro2fl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_altro2fl.Caption = "Altro 2"
    Me.hh_altro2fl.Enabled = True
    Me.hh_altro2fl.FieldName = "hh_altro2fl"
    Me.hh_altro2fl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_altro2fl.Name = "hh_altro2fl"
    Me.hh_altro2fl.NTSRepositoryComboBox = Nothing
    Me.hh_altro2fl.NTSRepositoryItemCheck = Nothing
    Me.hh_altro2fl.NTSRepositoryItemMemo = Nothing
    Me.hh_altro2fl.NTSRepositoryItemText = Nothing
    Me.hh_altro2fl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_altro2fl.OptionsFilter.AllowFilter = False
    Me.hh_altro2fl.Visible = True
    Me.hh_altro2fl.VisibleIndex = 31
    '
    'hh_altro2note
    '
    Me.hh_altro2note.AppearanceCell.Options.UseBackColor = True
    Me.hh_altro2note.AppearanceCell.Options.UseTextOptions = True
    Me.hh_altro2note.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_altro2note.Caption = "Note Altro 2"
    Me.hh_altro2note.Enabled = True
    Me.hh_altro2note.FieldName = "hh_altro2note"
    Me.hh_altro2note.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_altro2note.Name = "hh_altro2note"
    Me.hh_altro2note.NTSRepositoryComboBox = Nothing
    Me.hh_altro2note.NTSRepositoryItemCheck = Nothing
    Me.hh_altro2note.NTSRepositoryItemMemo = Nothing
    Me.hh_altro2note.NTSRepositoryItemText = Nothing
    Me.hh_altro2note.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_altro2note.OptionsFilter.AllowFilter = False
    Me.hh_altro2note.Visible = True
    Me.hh_altro2note.VisibleIndex = 32
    '
    'hh_altro3fl
    '
    Me.hh_altro3fl.AppearanceCell.Options.UseBackColor = True
    Me.hh_altro3fl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_altro3fl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_altro3fl.Caption = "Altro 3"
    Me.hh_altro3fl.Enabled = True
    Me.hh_altro3fl.FieldName = "hh_altro3fl"
    Me.hh_altro3fl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_altro3fl.Name = "hh_altro3fl"
    Me.hh_altro3fl.NTSRepositoryComboBox = Nothing
    Me.hh_altro3fl.NTSRepositoryItemCheck = Nothing
    Me.hh_altro3fl.NTSRepositoryItemMemo = Nothing
    Me.hh_altro3fl.NTSRepositoryItemText = Nothing
    Me.hh_altro3fl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_altro3fl.OptionsFilter.AllowFilter = False
    Me.hh_altro3fl.Visible = True
    Me.hh_altro3fl.VisibleIndex = 33
    '
    'hh_altro3note
    '
    Me.hh_altro3note.AppearanceCell.Options.UseBackColor = True
    Me.hh_altro3note.AppearanceCell.Options.UseTextOptions = True
    Me.hh_altro3note.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_altro3note.Caption = "Note Altro 3"
    Me.hh_altro3note.Enabled = True
    Me.hh_altro3note.FieldName = "hh_altro3note"
    Me.hh_altro3note.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_altro3note.Name = "hh_altro3note"
    Me.hh_altro3note.NTSRepositoryComboBox = Nothing
    Me.hh_altro3note.NTSRepositoryItemCheck = Nothing
    Me.hh_altro3note.NTSRepositoryItemMemo = Nothing
    Me.hh_altro3note.NTSRepositoryItemText = Nothing
    Me.hh_altro3note.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_altro3note.OptionsFilter.AllowFilter = False
    Me.hh_altro3note.Visible = True
    Me.hh_altro3note.VisibleIndex = 34
    '
    'hh_altro4fl
    '
    Me.hh_altro4fl.AppearanceCell.Options.UseBackColor = True
    Me.hh_altro4fl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_altro4fl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_altro4fl.Caption = "Altro 4"
    Me.hh_altro4fl.Enabled = True
    Me.hh_altro4fl.FieldName = "hh_altro4fl"
    Me.hh_altro4fl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_altro4fl.Name = "hh_altro4fl"
    Me.hh_altro4fl.NTSRepositoryComboBox = Nothing
    Me.hh_altro4fl.NTSRepositoryItemCheck = Nothing
    Me.hh_altro4fl.NTSRepositoryItemMemo = Nothing
    Me.hh_altro4fl.NTSRepositoryItemText = Nothing
    Me.hh_altro4fl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_altro4fl.OptionsFilter.AllowFilter = False
    Me.hh_altro4fl.Visible = True
    Me.hh_altro4fl.VisibleIndex = 35
    '
    'hh_altro4note
    '
    Me.hh_altro4note.AppearanceCell.Options.UseBackColor = True
    Me.hh_altro4note.AppearanceCell.Options.UseTextOptions = True
    Me.hh_altro4note.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_altro4note.Caption = "Note Altro 4"
    Me.hh_altro4note.Enabled = True
    Me.hh_altro4note.FieldName = "hh_altro4note"
    Me.hh_altro4note.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_altro4note.Name = "hh_altro4note"
    Me.hh_altro4note.NTSRepositoryComboBox = Nothing
    Me.hh_altro4note.NTSRepositoryItemCheck = Nothing
    Me.hh_altro4note.NTSRepositoryItemMemo = Nothing
    Me.hh_altro4note.NTSRepositoryItemText = Nothing
    Me.hh_altro4note.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_altro4note.OptionsFilter.AllowFilter = False
    Me.hh_altro4note.Visible = True
    Me.hh_altro4note.VisibleIndex = 36
    '
    'hh_evasofl
    '
    Me.hh_evasofl.AppearanceCell.Options.UseBackColor = True
    Me.hh_evasofl.AppearanceCell.Options.UseTextOptions = True
    Me.hh_evasofl.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_evasofl.Caption = "Evaso"
    Me.hh_evasofl.Enabled = True
    Me.hh_evasofl.FieldName = "hh_evasofl"
    Me.hh_evasofl.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_evasofl.Name = "hh_evasofl"
    Me.hh_evasofl.NTSRepositoryComboBox = Nothing
    Me.hh_evasofl.NTSRepositoryItemCheck = Nothing
    Me.hh_evasofl.NTSRepositoryItemMemo = Nothing
    Me.hh_evasofl.NTSRepositoryItemText = Nothing
    Me.hh_evasofl.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_evasofl.OptionsFilter.AllowFilter = False
    Me.hh_evasofl.Visible = True
    Me.hh_evasofl.VisibleIndex = 37
    '
    'hh_evasonote
    '
    Me.hh_evasonote.AppearanceCell.Options.UseBackColor = True
    Me.hh_evasonote.AppearanceCell.Options.UseTextOptions = True
    Me.hh_evasonote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_evasonote.Caption = "Note Evaso"
    Me.hh_evasonote.Enabled = True
    Me.hh_evasonote.FieldName = "hh_evasonote"
    Me.hh_evasonote.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_evasonote.Name = "hh_evasonote"
    Me.hh_evasonote.NTSRepositoryComboBox = Nothing
    Me.hh_evasonote.NTSRepositoryItemCheck = Nothing
    Me.hh_evasonote.NTSRepositoryItemMemo = Nothing
    Me.hh_evasonote.NTSRepositoryItemText = Nothing
    Me.hh_evasonote.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_evasonote.OptionsFilter.AllowFilter = False
    Me.hh_evasonote.Visible = True
    Me.hh_evasonote.VisibleIndex = 38
    '
    'NtsGroupBox1
    '
    Me.NtsGroupBox1.AllowDrop = True
    Me.NtsGroupBox1.Appearance.BackColor = System.Drawing.Color.Transparent
    Me.NtsGroupBox1.Appearance.Options.UseBackColor = True
    Me.NtsGroupBox1.Controls.Add(Me.NtsLabel3)
    Me.NtsGroupBox1.Controls.Add(Me.edxx_data)
    Me.NtsGroupBox1.Controls.Add(Me.edxx_conto)
    Me.NtsGroupBox1.Controls.Add(Me.NtsLabel1)
    Me.NtsGroupBox1.Controls.Add(Me.NtsLabel2)
    Me.NtsGroupBox1.Controls.Add(Me.lbxx_desconto)
    Me.NtsGroupBox1.Controls.Add(Me.edxx_commessa)
    Me.NtsGroupBox1.Cursor = System.Windows.Forms.Cursors.Default
    Me.NtsGroupBox1.Location = New System.Drawing.Point(12, 12)
    Me.NtsGroupBox1.Name = "NtsGroupBox1"
    Me.NtsGroupBox1.Size = New System.Drawing.Size(485, 116)
    Me.NtsGroupBox1.TabIndex = 7
    Me.NtsGroupBox1.Text = "Filtri Ricerca"
    '
    'NtsLabel3
    '
    Me.NtsLabel3.AutoSize = True
    Me.NtsLabel3.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel3.Location = New System.Drawing.Point(7, 90)
    Me.NtsLabel3.Name = "NtsLabel3"
    Me.NtsLabel3.NTSDbField = ""
    Me.NtsLabel3.Size = New System.Drawing.Size(79, 13)
    Me.NtsLabel3.TabIndex = 6
    Me.NtsLabel3.Text = "Data consegna"
    Me.NtsLabel3.Tooltip = ""
    Me.NtsLabel3.UseMnemonic = False
    '
    'edxx_data
    '
    Me.edxx_data.Cursor = System.Windows.Forms.Cursors.Default
    Me.edxx_data.Location = New System.Drawing.Point(99, 87)
    Me.edxx_data.Name = "edxx_data"
    Me.edxx_data.NTSDbField = ""
    Me.edxx_data.NTSForzaVisZoom = False
    Me.edxx_data.NTSOldValue = ""
    Me.edxx_data.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edxx_data.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edxx_data.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edxx_data.Properties.MaxLength = 65536
    Me.edxx_data.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edxx_data.Size = New System.Drawing.Size(94, 20)
    Me.edxx_data.TabIndex = 5
    '
    'FRMHHAVCO
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
    Me.ClientSize = New System.Drawing.Size(590, 371)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(590, 371)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(590, 371)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsGroupBox1)
    Me.PnCPNEPnMain.Controls.Add(Me.grdett)
    Me.PnCPNEPnMain.Controls.Add(Me.CmdRicerca)
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FRMHHAVCO"
    Me.Text = "STATO AVANZAMENTO LAVORI"
    CType(Me.edxx_conto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edxx_commessa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grdett, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grvdett, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NtsGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.NtsGroupBox1.ResumeLayout(False)
    Me.NtsGroupBox1.PerformLayout()
    CType(Me.edxx_data.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).EndInit()
Me.PnCPNEPnMain.ResumeLayout(False)
Me.ResumeLayout(False)

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
#End Region

  Private components As System.ComponentModel.IContainer
  Public oCleHh As CLEHHAVCO
  Public dsHh As New DataSet
  Public oCallParams As CLE__CLDP
  Public dcHh As BindingSource = New BindingSource
  Public dcHhgr As BindingSource = New BindingSource

  Public Overridable Sub Bindcontrols()
    Try
      '-------------------------------------------------
      'se i controlli erano già  stati precedentemente collegati, li scollego
      NTSFormClearDataBinding(Me)

      '-------------------------------------------------
      'collego il BindingSource ai vari controlli 
      edxx_conto.NTSDbField = "XXX.xx_conto"
      edxx_commessa.NTSDbField = "XXX.xx_commessa"
      lbxx_desconto.NTSDbField = "XXX.xx_desconto"
      edxx_data.NTSDbField = "XXX.xx_data"

      grvdett.NTSSetParam(oMenu, oApp.Tr(Me, 131279271971261591, "Griglia"))
      co_comme.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131279271971271608, "Commessa"), "0", 9, 0, 999999999)
      hh_inizfl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Partenza"), "S", "N")
      hh_iniznote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Partenza"), 0, True, True)

      hh_macfl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Grafica MAC"), "S", "N")
      hh_macnote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Grafica MAC"), 0, True, True)
      hh_prepfl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Preparazione"), "S", "N")
      hh_prepnote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note preparazione"), 0, True, True)
      hh_approvfl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Approvaz. cliente"), "S", "N")
      hh_approvnote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Approvaz. cliente"), 0, True, True)
      hh_stofffl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Stampa offset"), "S", "N")
      hh_stoffnote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Stampa offset"), 0, True, True)
      hh_stdigfl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Stampa digitale"), "S", "N")
      hh_stdignote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Stampa digitale"), 0, True, True)
      hh_stserfl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Stampa serigrafica"), "S", "N")
      hh_stsernote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Stampa serigrafica"), 0, True, True)
      hh_staltfl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Stampa altro"), "S", "N")
      hh_staltnote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Stampa altro"), 0, True, True)
      hh_plastfl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Plastificazione"), "S", "N")
      hh_plastnote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Plastificazione"), 0, True, True)
      hh_vernfl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Verniciatura"), "S", "N")
      hh_vernnote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Verniciatura"), 0, True, True)
      hh_legpmfl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Legatoria p.m./piega"), "S", "N")
      hh_legpmnote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Legatoria p.m./piega"), 0, True, True)
      hh_legeditfl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Legatoria editoriale"), "S", "N")
      hh_legeditnote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Legatoria editoriale"), 0, True, True)
      hh_cartfl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Cartotecnica"), "S", "N")
      hh_cartnote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Cartotecnica"), 0, True, True)
      hh_conffl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Confezione"), "S", "N")
      hh_confnote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Confezione"), 0, True, True)
      hh_altro1fl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Altro 1"), "S", "N")
      hh_altro1note.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Altro 1"), 0, True, True)
      hh_altro2fl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Altro 2"), "S", "N")
      hh_altro2note.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Altro 2"), 0, True, True)
      hh_altro3fl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Altro 3"), "S", "N")
      hh_altro3note.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Altro 3"), 0, True, True)
      hh_altro4fl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Altro 4"), "S", "N")
      hh_altro4note.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Altro 4"), 0, True, True)
      hh_evasofl.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131279271971281724, "Evaso"), "S", "N")
      hh_evasonote.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131279271971291725, "Note Evaso"), 0, True, True)

      edxx_conto.NTSSetParamTabe(oMenu, oApp.Tr(Me, 131279271971321752, "Conto"), tabanagrac)
      edxx_commessa.NTSSetParamTabe(oMenu, oApp.Tr(Me, 131279271971361774, "Commessa"), tabcommess)


      NTSFormAddDataBinding(dcHh, Me)
      '-------------------------------------------------
      'per agganciare al dataset i vari controlli


    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------
    End Try
  End Sub

  Private Sub FRMHHAVCO_ActivatedFirst(sender As Object, e As System.EventArgs) Handles Me.ActivatedFirst
TRY
    If Not IsNothing(oCallParams) Then
      dsHh.Tables("XXX").Rows(0)!xx_conto = oCallParams.dPar1
      dsHh.Tables("XXX").Rows(0)!xx_commessa = oCallParams.dPar2
      Ricerca()
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub FRMHHAVCO_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
TRY

    ValidaLastControl()
    oCleHh.CPNESalvaRiga(grvdett.NTSGetCurrentDataRow)

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub FRM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
TRY
    dsHh = oCleHh.dsShared
    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = dsHh.Tables("XXX")
    aggiornaGriglia()
    Bindcontrols()
    GctlSetRoules()
    GctlApplicaDefaultValue()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub GestisciEventiEntity(ByVal sender As Object, ByRef e As NTSEventArgs)

    If Not IsMyThrowRemoteEvent() Then Return 'il messaggio non è per questa form ...
    MyBase.GestisciEventiEntity(sender, e)
    Try
      If e.TipoEvento.Length < 5 Then Return
      If Mid(e.TipoEvento, 1, 4) = "CPNE" Then
        Select Case e.TipoEvento
          Case ""

        End Select
      End If
    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------
    End Try
  End Sub
  Private Sub Ricerca()
TRY

    ValidaLastControl()
    oCleHh.CPNESalvaRiga(grvdett.NTSGetCurrentDataRow)

    If oCleHh.CPNERicerca() Then
      aggiornaGriglia()
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub CmdRicerca_Click(sender As System.Object, e As System.EventArgs) Handles CmdRicerca.Click
TRY
    Ricerca()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub aggiornaGriglia()
TRY
    dcHhgr = Nothing
    dcHhgr = New BindingSource()
    dcHhgr.DataSource = dsHh.Tables("Commesse")
    grdett.DataSource = dcHhgr
    grvdett.NTSAllowInsert = False
    grvdett.NTSAllowDelete = False
    grvdett.Enabled = True
    co_comme.Enabled = False
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub grdett_Click(sender As System.Object, e As System.EventArgs) Handles grdett.Click
TRY

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub grvdett_NTSBeforeRowUpdate(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles grvdett.NTSBeforeRowUpdate
TRY

    ValidaLastControl()
    If Not oCleHh.CPNESalvaRiga(grvdett.NTSGetCurrentDataRow) Then
      e.Allow = False
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
End Class

