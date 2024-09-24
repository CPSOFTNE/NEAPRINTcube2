Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Imports System.Windows.Forms
Public Class FrmSelOc
#Region "Standard"


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
  Public Overridable Sub InitEntity(ByRef cleSt As CLBVEBOLL)
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

  Public Sub InitializeComponent()
    Me.NtsPanel1 = New NTSInformatica.NTSPanel()
    Me.grSelOc = New NTSInformatica.NTSGrid()
    Me.grvSelOc = New NTSInformatica.NTSGridView()
    Me.mo_anno = New NTSInformatica.NTSGridColumn()
    Me.mo_serie = New NTSInformatica.NTSGridColumn()
    Me.mo_numord = New NTSInformatica.NTSGridColumn()
    Me.mo_riga = New NTSInformatica.NTSGridColumn()
    Me.mo_codart = New NTSInformatica.NTSGridColumn()
    Me.mo_codartclifor = New NTSInformatica.NTSGridColumn()
    Me.td_DatOrd = New NTSInformatica.NTSGridColumn()
    Me.mo_datCons = New NTSInformatica.NTSGridColumn()
    Me.mo_commeca = New NTSInformatica.NTSGridColumn()
    Me.xx_colli = New NTSInformatica.NTSGridColumn()
    Me.xx_quant = New NTSInformatica.NTSGridColumn()
    Me.mo_note = New NTSInformatica.NTSGridColumn()
    Me.td_riferim = New NTSInformatica.NTSGridColumn()
    Me.td_cup = New NTSInformatica.NTSGridColumn()
    Me.td_cig = New NTSInformatica.NTSGridColumn()
    Me.td_riferimpa = New NTSInformatica.NTSGridColumn()
    Me.xx_sel = New NTSInformatica.NTSGridColumn()
    Me.cmdRicerca = New NTSInformatica.NTSButton()
    Me.cmdAnnulla = New NTSInformatica.NTSButton()
    Me.cmdSeleziona = New NTSInformatica.NTSButton()
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.NtsPanel1.SuspendLayout()
    CType(Me.grSelOc, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grvSelOc, System.ComponentModel.ISupportInitialize).BeginInit()
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
    'NtsPanel1
    '
    Me.NtsPanel1.AllowDrop = True
    Me.NtsPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
    Me.NtsPanel1.Appearance.Options.UseBackColor = True
    Me.NtsPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
    Me.NtsPanel1.Controls.Add(Me.grSelOc)
    Me.NtsPanel1.Controls.Add(Me.cmdRicerca)
    Me.NtsPanel1.Controls.Add(Me.cmdAnnulla)
    Me.NtsPanel1.Controls.Add(Me.cmdSeleziona)
    Me.NtsPanel1.Cursor = System.Windows.Forms.Cursors.Default
    Me.NtsPanel1.Location = New System.Drawing.Point(4, 2)
    Me.NtsPanel1.Name = "NtsPanel1"
    Me.NtsPanel1.NTSActiveTrasparency = True
    Me.NtsPanel1.Size = New System.Drawing.Size(657, 261)
    Me.NtsPanel1.TabIndex = 0
    Me.NtsPanel1.Text = "NtsPanel1"
    '
    'grSelOc
    '
    '
    '
    '
    Me.grSelOc.EmbeddedNavigator.Name = ""
    Me.grSelOc.Location = New System.Drawing.Point(9, 47)
    Me.grSelOc.MainView = Me.grvSelOc
    Me.grSelOc.Name = "grSelOc"
    Me.grSelOc.Size = New System.Drawing.Size(645, 210)
    Me.grSelOc.TabIndex = 12
    Me.grSelOc.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvSelOc})
    '
    'grvSelOc
    '
    Me.grvSelOc.ActiveFilterEnabled = False
    Me.grvSelOc.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.mo_anno, Me.mo_serie, Me.mo_numord, Me.mo_riga, Me.mo_codart, Me.mo_codartclifor, Me.td_DatOrd, Me.mo_datCons, Me.mo_commeca, Me.xx_colli, Me.xx_quant, Me.mo_note, Me.td_riferim, Me.td_cup, Me.td_cig, Me.td_riferimpa, Me.xx_sel})
    Me.grvSelOc.Enabled = True
    Me.grvSelOc.GridControl = Me.grSelOc
    Me.grvSelOc.MaxRowHeight = 9999
    Me.grvSelOc.MinRowHeight = 14
    Me.grvSelOc.Name = "grvSelOc"
    Me.grvSelOc.NTSAllowDelete = True
    Me.grvSelOc.NTSAllowInsert = True
    Me.grvSelOc.NTSAllowUpdate = True
    Me.grvSelOc.NTSForceShowGroupPanel = -9
    Me.grvSelOc.NTSMenuContext = Nothing
    Me.grvSelOc.OptionsCustomization.AllowRowSizing = True
    Me.grvSelOc.OptionsFilter.AllowFilterEditor = False
    Me.grvSelOc.OptionsNavigation.EnterMoveNextColumn = True
    Me.grvSelOc.OptionsNavigation.UseTabKey = False
    Me.grvSelOc.OptionsSelection.EnableAppearanceFocusedRow = False
    Me.grvSelOc.OptionsView.ColumnAutoWidth = False
    Me.grvSelOc.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
    Me.grvSelOc.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
    Me.grvSelOc.OptionsView.ShowGroupPanel = False
    Me.grvSelOc.RowHeight = 14
    '
    'mo_anno
    '
    Me.mo_anno.AppearanceCell.Options.UseBackColor = True
    Me.mo_anno.AppearanceCell.Options.UseTextOptions = True
    Me.mo_anno.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_anno.Caption = "Anno"
    Me.mo_anno.Enabled = True
    Me.mo_anno.FieldName = "mo_anno"
    Me.mo_anno.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_anno.Name = "mo_anno"
    Me.mo_anno.NTSRepositoryComboBox = Nothing
    Me.mo_anno.NTSRepositoryItemCheck = Nothing
    Me.mo_anno.NTSRepositoryItemMemo = Nothing
    Me.mo_anno.NTSRepositoryItemText = Nothing
    Me.mo_anno.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_anno.OptionsFilter.AllowFilter = False
    Me.mo_anno.Visible = True
    Me.mo_anno.VisibleIndex = 0
    '
    'mo_serie
    '
    Me.mo_serie.AppearanceCell.Options.UseBackColor = True
    Me.mo_serie.AppearanceCell.Options.UseTextOptions = True
    Me.mo_serie.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_serie.Caption = "Serie"
    Me.mo_serie.Enabled = True
    Me.mo_serie.FieldName = "mo_serie"
    Me.mo_serie.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_serie.Name = "mo_serie"
    Me.mo_serie.NTSRepositoryComboBox = Nothing
    Me.mo_serie.NTSRepositoryItemCheck = Nothing
    Me.mo_serie.NTSRepositoryItemMemo = Nothing
    Me.mo_serie.NTSRepositoryItemText = Nothing
    Me.mo_serie.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_serie.OptionsFilter.AllowFilter = False
    Me.mo_serie.Visible = True
    Me.mo_serie.VisibleIndex = 1
    '
    'mo_numord
    '
    Me.mo_numord.AppearanceCell.Options.UseBackColor = True
    Me.mo_numord.AppearanceCell.Options.UseTextOptions = True
    Me.mo_numord.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_numord.Caption = "Numero"
    Me.mo_numord.Enabled = True
    Me.mo_numord.FieldName = "mo_numord"
    Me.mo_numord.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_numord.Name = "mo_numord"
    Me.mo_numord.NTSRepositoryComboBox = Nothing
    Me.mo_numord.NTSRepositoryItemCheck = Nothing
    Me.mo_numord.NTSRepositoryItemMemo = Nothing
    Me.mo_numord.NTSRepositoryItemText = Nothing
    Me.mo_numord.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_numord.OptionsFilter.AllowFilter = False
    Me.mo_numord.Visible = True
    Me.mo_numord.VisibleIndex = 2
    '
    'mo_riga
    '
    Me.mo_riga.AppearanceCell.Options.UseBackColor = True
    Me.mo_riga.AppearanceCell.Options.UseTextOptions = True
    Me.mo_riga.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_riga.Caption = "Riga"
    Me.mo_riga.Enabled = True
    Me.mo_riga.FieldName = "mo_riga"
    Me.mo_riga.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_riga.Name = "mo_riga"
    Me.mo_riga.NTSRepositoryComboBox = Nothing
    Me.mo_riga.NTSRepositoryItemCheck = Nothing
    Me.mo_riga.NTSRepositoryItemMemo = Nothing
    Me.mo_riga.NTSRepositoryItemText = Nothing
    Me.mo_riga.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_riga.OptionsFilter.AllowFilter = False
    Me.mo_riga.Visible = True
    Me.mo_riga.VisibleIndex = 3
    '
    'mo_codart
    '
    Me.mo_codart.AppearanceCell.Options.UseBackColor = True
    Me.mo_codart.AppearanceCell.Options.UseTextOptions = True
    Me.mo_codart.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_codart.Caption = "Cod. Art."
    Me.mo_codart.Enabled = True
    Me.mo_codart.FieldName = "mo_codart"
    Me.mo_codart.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_codart.Name = "mo_codart"
    Me.mo_codart.NTSRepositoryComboBox = Nothing
    Me.mo_codart.NTSRepositoryItemCheck = Nothing
    Me.mo_codart.NTSRepositoryItemMemo = Nothing
    Me.mo_codart.NTSRepositoryItemText = Nothing
    Me.mo_codart.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_codart.OptionsFilter.AllowFilter = False
    '
    'mo_codartclifor
    '
    Me.mo_codartclifor.AppearanceCell.Options.UseBackColor = True
    Me.mo_codartclifor.AppearanceCell.Options.UseTextOptions = True
    Me.mo_codartclifor.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_codartclifor.Caption = "Codice Articolo"
    Me.mo_codartclifor.Enabled = True
    Me.mo_codartclifor.FieldName = "mo_codartclifor"
    Me.mo_codartclifor.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_codartclifor.Name = "mo_codartclifor"
    Me.mo_codartclifor.NTSRepositoryComboBox = Nothing
    Me.mo_codartclifor.NTSRepositoryItemCheck = Nothing
    Me.mo_codartclifor.NTSRepositoryItemMemo = Nothing
    Me.mo_codartclifor.NTSRepositoryItemText = Nothing
    Me.mo_codartclifor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_codartclifor.OptionsFilter.AllowFilter = False
    Me.mo_codartclifor.Visible = True
    Me.mo_codartclifor.VisibleIndex = 4
    '
    'td_DatOrd
    '
    Me.td_DatOrd.AppearanceCell.Options.UseBackColor = True
    Me.td_DatOrd.AppearanceCell.Options.UseTextOptions = True
    Me.td_DatOrd.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.td_DatOrd.Caption = "Data Ordine"
    Me.td_DatOrd.Enabled = True
    Me.td_DatOrd.FieldName = "td_DatOrd"
    Me.td_DatOrd.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.td_DatOrd.Name = "td_DatOrd"
    Me.td_DatOrd.NTSRepositoryComboBox = Nothing
    Me.td_DatOrd.NTSRepositoryItemCheck = Nothing
    Me.td_DatOrd.NTSRepositoryItemMemo = Nothing
    Me.td_DatOrd.NTSRepositoryItemText = Nothing
    Me.td_DatOrd.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.td_DatOrd.OptionsFilter.AllowFilter = False
    Me.td_DatOrd.Visible = True
    Me.td_DatOrd.VisibleIndex = 5
    '
    'mo_datCons
    '
    Me.mo_datCons.AppearanceCell.Options.UseBackColor = True
    Me.mo_datCons.AppearanceCell.Options.UseTextOptions = True
    Me.mo_datCons.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_datCons.Caption = "Data Cons."
    Me.mo_datCons.Enabled = True
    Me.mo_datCons.FieldName = "mo_datCons"
    Me.mo_datCons.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_datCons.Name = "mo_datCons"
    Me.mo_datCons.NTSRepositoryComboBox = Nothing
    Me.mo_datCons.NTSRepositoryItemCheck = Nothing
    Me.mo_datCons.NTSRepositoryItemMemo = Nothing
    Me.mo_datCons.NTSRepositoryItemText = Nothing
    Me.mo_datCons.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_datCons.OptionsFilter.AllowFilter = False
    Me.mo_datCons.Visible = True
    Me.mo_datCons.VisibleIndex = 6
    '
    'mo_commeca
    '
    Me.mo_commeca.AppearanceCell.Options.UseBackColor = True
    Me.mo_commeca.AppearanceCell.Options.UseTextOptions = True
    Me.mo_commeca.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_commeca.Caption = "Commessa"
    Me.mo_commeca.Enabled = True
    Me.mo_commeca.FieldName = "mo_commeca"
    Me.mo_commeca.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_commeca.Name = "mo_commeca"
    Me.mo_commeca.NTSRepositoryComboBox = Nothing
    Me.mo_commeca.NTSRepositoryItemCheck = Nothing
    Me.mo_commeca.NTSRepositoryItemMemo = Nothing
    Me.mo_commeca.NTSRepositoryItemText = Nothing
    Me.mo_commeca.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_commeca.OptionsFilter.AllowFilter = False
    Me.mo_commeca.Visible = True
    Me.mo_commeca.VisibleIndex = 7
    '
    'xx_colli
    '
    Me.xx_colli.AppearanceCell.Options.UseBackColor = True
    Me.xx_colli.AppearanceCell.Options.UseTextOptions = True
    Me.xx_colli.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.xx_colli.Caption = "Colli"
    Me.xx_colli.Enabled = True
    Me.xx_colli.FieldName = "xx_colli"
    Me.xx_colli.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.xx_colli.Name = "xx_colli"
    Me.xx_colli.NTSRepositoryComboBox = Nothing
    Me.xx_colli.NTSRepositoryItemCheck = Nothing
    Me.xx_colli.NTSRepositoryItemMemo = Nothing
    Me.xx_colli.NTSRepositoryItemText = Nothing
    Me.xx_colli.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.xx_colli.OptionsFilter.AllowFilter = False
    Me.xx_colli.Visible = True
    Me.xx_colli.VisibleIndex = 8
    '
    'xx_quant
    '
    Me.xx_quant.AppearanceCell.Options.UseBackColor = True
    Me.xx_quant.AppearanceCell.Options.UseTextOptions = True
    Me.xx_quant.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.xx_quant.Caption = "Quant"
    Me.xx_quant.Enabled = True
    Me.xx_quant.FieldName = "xx_quant"
    Me.xx_quant.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.xx_quant.Name = "xx_quant"
    Me.xx_quant.NTSRepositoryComboBox = Nothing
    Me.xx_quant.NTSRepositoryItemCheck = Nothing
    Me.xx_quant.NTSRepositoryItemMemo = Nothing
    Me.xx_quant.NTSRepositoryItemText = Nothing
    Me.xx_quant.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.xx_quant.OptionsFilter.AllowFilter = False
    Me.xx_quant.Visible = True
    Me.xx_quant.VisibleIndex = 9
    '
    'mo_note
    '
    Me.mo_note.AppearanceCell.Options.UseBackColor = True
    Me.mo_note.AppearanceCell.Options.UseTextOptions = True
    Me.mo_note.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_note.Caption = "Note"
    Me.mo_note.Enabled = True
    Me.mo_note.FieldName = "mo_note"
    Me.mo_note.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_note.Name = "mo_note"
    Me.mo_note.NTSRepositoryComboBox = Nothing
    Me.mo_note.NTSRepositoryItemCheck = Nothing
    Me.mo_note.NTSRepositoryItemMemo = Nothing
    Me.mo_note.NTSRepositoryItemText = Nothing
    Me.mo_note.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_note.OptionsFilter.AllowFilter = False
    Me.mo_note.Visible = True
    Me.mo_note.VisibleIndex = 11
    '
    'td_riferim
    '
    Me.td_riferim.AppearanceCell.Options.UseBackColor = True
    Me.td_riferim.AppearanceCell.Options.UseTextOptions = True
    Me.td_riferim.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.td_riferim.Caption = "Riferimenti"
    Me.td_riferim.Enabled = True
    Me.td_riferim.FieldName = "td_riferim"
    Me.td_riferim.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.td_riferim.Name = "td_riferim"
    Me.td_riferim.NTSRepositoryComboBox = Nothing
    Me.td_riferim.NTSRepositoryItemCheck = Nothing
    Me.td_riferim.NTSRepositoryItemMemo = Nothing
    Me.td_riferim.NTSRepositoryItemText = Nothing
    Me.td_riferim.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.td_riferim.OptionsFilter.AllowFilter = False
    Me.td_riferim.Visible = True
    Me.td_riferim.VisibleIndex = 12
    '
    'td_cup
    '
    Me.td_cup.AppearanceCell.Options.UseBackColor = True
    Me.td_cup.AppearanceCell.Options.UseTextOptions = True
    Me.td_cup.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.td_cup.Caption = "Cup"
    Me.td_cup.Enabled = True
    Me.td_cup.FieldName = "td_cup"
    Me.td_cup.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.td_cup.Name = "td_cup"
    Me.td_cup.NTSRepositoryComboBox = Nothing
    Me.td_cup.NTSRepositoryItemCheck = Nothing
    Me.td_cup.NTSRepositoryItemMemo = Nothing
    Me.td_cup.NTSRepositoryItemText = Nothing
    Me.td_cup.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.td_cup.OptionsFilter.AllowFilter = False
    Me.td_cup.Visible = True
    Me.td_cup.VisibleIndex = 13
    '
    'td_cig
    '
    Me.td_cig.AppearanceCell.Options.UseBackColor = True
    Me.td_cig.AppearanceCell.Options.UseTextOptions = True
    Me.td_cig.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.td_cig.Caption = "Cig"
    Me.td_cig.Enabled = True
    Me.td_cig.FieldName = "td_cig"
    Me.td_cig.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.td_cig.Name = "td_cig"
    Me.td_cig.NTSRepositoryComboBox = Nothing
    Me.td_cig.NTSRepositoryItemCheck = Nothing
    Me.td_cig.NTSRepositoryItemMemo = Nothing
    Me.td_cig.NTSRepositoryItemText = Nothing
    Me.td_cig.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.td_cig.OptionsFilter.AllowFilter = False
    Me.td_cig.Visible = True
    Me.td_cig.VisibleIndex = 14
    '
    'td_riferimpa
    '
    Me.td_riferimpa.AppearanceCell.Options.UseBackColor = True
    Me.td_riferimpa.AppearanceCell.Options.UseTextOptions = True
    Me.td_riferimpa.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.td_riferimpa.Caption = "Rif. PA"
    Me.td_riferimpa.Enabled = True
    Me.td_riferimpa.FieldName = "td_riferimpa"
    Me.td_riferimpa.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.td_riferimpa.Name = "td_riferimpa"
    Me.td_riferimpa.NTSRepositoryComboBox = Nothing
    Me.td_riferimpa.NTSRepositoryItemCheck = Nothing
    Me.td_riferimpa.NTSRepositoryItemMemo = Nothing
    Me.td_riferimpa.NTSRepositoryItemText = Nothing
    Me.td_riferimpa.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.td_riferimpa.OptionsFilter.AllowFilter = False
    Me.td_riferimpa.Visible = True
    Me.td_riferimpa.VisibleIndex = 15
    '
    'xx_sel
    '
    Me.xx_sel.AppearanceCell.Options.UseBackColor = True
    Me.xx_sel.AppearanceCell.Options.UseTextOptions = True
    Me.xx_sel.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.xx_sel.Caption = "Sel."
    Me.xx_sel.Enabled = True
    Me.xx_sel.FieldName = "xx_sel"
    Me.xx_sel.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.xx_sel.Name = "xx_sel"
    Me.xx_sel.NTSRepositoryComboBox = Nothing
    Me.xx_sel.NTSRepositoryItemCheck = Nothing
    Me.xx_sel.NTSRepositoryItemMemo = Nothing
    Me.xx_sel.NTSRepositoryItemText = Nothing
    Me.xx_sel.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.xx_sel.OptionsFilter.AllowFilter = False
    Me.xx_sel.Visible = True
    Me.xx_sel.VisibleIndex = 10
    '
    'cmdRicerca
    '
    Me.cmdRicerca.ImagePath = ""
    Me.cmdRicerca.ImageText = ""
    Me.cmdRicerca.Location = New System.Drawing.Point(19, 10)
    Me.cmdRicerca.Name = "cmdRicerca"
    Me.cmdRicerca.NTSContextMenu = Nothing
    Me.cmdRicerca.Size = New System.Drawing.Size(119, 30)
    Me.cmdRicerca.TabIndex = 11
    Me.cmdRicerca.Text = "Ricerca"
    '
    'cmdAnnulla
    '
    Me.cmdAnnulla.ImagePath = ""
    Me.cmdAnnulla.ImageText = ""
    Me.cmdAnnulla.Location = New System.Drawing.Point(519, 10)
    Me.cmdAnnulla.Name = "cmdAnnulla"
    Me.cmdAnnulla.NTSContextMenu = Nothing
    Me.cmdAnnulla.Size = New System.Drawing.Size(119, 30)
    Me.cmdAnnulla.TabIndex = 10
    Me.cmdAnnulla.Text = "Annulla"
    '
    'cmdSeleziona
    '
    Me.cmdSeleziona.ImagePath = ""
    Me.cmdSeleziona.ImageText = ""
    Me.cmdSeleziona.Location = New System.Drawing.Point(269, 10)
    Me.cmdSeleziona.Name = "cmdSeleziona"
    Me.cmdSeleziona.NTSContextMenu = Nothing
    Me.cmdSeleziona.Size = New System.Drawing.Size(119, 30)
    Me.cmdSeleziona.TabIndex = 9
    Me.cmdSeleziona.Text = "Seleziona"
    '
    'FrmSelOc
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
    Me.ClientSize = New System.Drawing.Size(673, 266)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(673, 266)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(673, 266)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsPanel1)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FrmSelOc"
    Me.Text = "ASSOCIA CON L'IMPEGNO CLIENTE APERTO"
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).EndInit()
Me.NtsPanel1.ResumeLayout(False)
    CType(Me.grSelOc, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grvSelOc, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).EndInit()
Me.PnCPNEPnMain.ResumeLayout(False)
Me.ResumeLayout(False)

  End Sub
#End Region
  Private components As System.ComponentModel.IContainer
  Public oCleHh As CLBVEBOLL
  Public dsHh As New DataSet
  Public oCallParams As CLE__CLDP
  Public dcHh As BindingSource = New BindingSource
  Public dcHhGr As BindingSource = New BindingSource
  Public gbClapAnnullatoOut As Boolean
  Dim drRigaSelezionata As DataRow

  Public Overridable Sub Bindcontrols()
    Try
      '-------------------------------------------------
      'se i controlli erano già  stati precedentemente collegati, li scollego
      NTSFormClearDataBinding(Me)

      grvSelOc.NTSSetParam(oMenu, oApp.Tr(Me, 130948371683758953, "Associa con l'impegno cliente aperto"))

      xx_colli.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130948395294125052, "Colli"), "#,##0.00", 15)
      xx_quant.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130948395294130055, "Quant"), "#,##0.00", 15)
      mo_anno.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130948393703050353, "Anno"), "0", 4, 0, 9999)
      mo_serie.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130948393703206596, "Serie"), 0, True)
      mo_numord.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130948393703362845, "Numero"), "0", 9, 0, 999999999)
      mo_riga.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130948393703519088, "Riga"), "0", 9, 0, 999999999)
      mo_codart.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130948393703675350, "Cod. Art."), 0, True)
      mo_codartclifor.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130948393703831593, "Codice Articolo"), 0, True)
      td_DatOrd.NTSSetParamDATA(oMenu, oApp.Tr(Me, 130948393703987851, "Data Ordine"), True)
      mo_datCons.NTSSetParamDATA(oMenu, oApp.Tr(Me, 130948393704144129, "Data Cons."), True)
      mo_commeca.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130948393704300353, "Commessa"), "0", 9, 0, 999999999)
      mo_note.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130948393704769113, "Note"), 0, True)
      '=============== riccardo 
      xx_sel.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131723190940602511, "Seleziona"), "S", "N")

      NTSFormAddDataBinding(dcHh, Me)
      GctlSetRoules()

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

  Private Sub FRMSELOC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
TRY

    oCleHh.CPNECaricaOrdiniAperti()

    dsHh = oCleHh.dsShared
    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = dsHh.Tables("CPNE.ORDINIAPERTI")
    AggGriglia()
    Bindcontrols()

    grvSelOc.NTSAllowInsert = False
    grvSelOc.NTSAllowDelete = False
    grvSelOc.NTSAllowUpdate = False
    grvSelOc.Enabled = True


    GctlSetRoules()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub AggGriglia()
TRY
    dcHhGr = Nothing
    dcHhGr = New BindingSource()
    dcHhGr.DataSource = dsHh.Tables("CPNE.ORDINIAPERTI")
    grSelOc.DataSource = dcHhGr
    '=========== riccardo
    For Each col As NTSGridColumn In grvSelOc.Columns
      If col.Name = "xx_sel" Then
        col.Enabled = True
      Else
        col.Enabled = False
      End If
    Next

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub cmdAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles cmdAnnulla.Click
TRY
    gbClapAnnullatoOut = True
    Close()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub cmdRicerca_Click(sender As System.Object, e As System.EventArgs) Handles cmdRicerca.Click
TRY
    oCleHh.CPNECaricaOrdiniAperti()

    dsHh = oCleHh.dsShared
    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = dsHh.Tables("CPNE.ORDINIAPERTI")
    AggGriglia()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub cmdSeleziona_Click(sender As System.Object, e As System.EventArgs) Handles cmdSeleziona.Click
TRY
    oCleHh.CPNECreaRigaDaOrdineAperto(drRigaSelezionata)
    Close()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub grvSelOc_NTSFocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvSelOc.NTSFocusedRowChanged
TRY
    If Not IsNothing(grvSelOc.NTSGetCurrentDataRow) Then
      drRigaSelezionata = grvSelOc.NTSGetCurrentDataRow
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

 
End Class
