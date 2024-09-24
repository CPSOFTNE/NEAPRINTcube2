Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Imports System.Windows.Forms
Public Class FRMHHSTORICO
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

  Public Sub InitializeComponent()
    Me.NtsPanel1 = New NTSInformatica.NTSPanel()
    Me.grStorico = New NTSInformatica.NTSGrid()
    Me.grvStorico = New NTSInformatica.NTSGridView()
    Me.mo_riga = New NTSInformatica.NTSGridColumn()
    Me.mo_codart = New NTSInformatica.NTSGridColumn()
    Me.mo_descr = New NTSInformatica.NTSGridColumn()
    Me.mo_unmis = New NTSInformatica.NTSGridColumn()
    Me.mo_colli = New NTSInformatica.NTSGridColumn()
    Me.mo_colpre = New NTSInformatica.NTSGridColumn()
    Me.mo_coleva = New NTSInformatica.NTSGridColumn()
    Me.mo_ump = New NTSInformatica.NTSGridColumn()
    Me.mo_quant = New NTSInformatica.NTSGridColumn()
    Me.mo_quapre = New NTSInformatica.NTSGridColumn()
    Me.mo_quaeva = New NTSInformatica.NTSGridColumn()
    Me.mo_flevapre = New NTSInformatica.NTSGridColumn()
    Me.mo_flevas = New NTSInformatica.NTSGridColumn()
    Me.mo_prezzo = New NTSInformatica.NTSGridColumn()
    Me.mo_scont1 = New NTSInformatica.NTSGridColumn()
    Me.mo_scont2 = New NTSInformatica.NTSGridColumn()
    Me.mo_datcons = New NTSInformatica.NTSGridColumn()
    Me.mo_confermato = New NTSInformatica.NTSGridColumn()
    Me.mo_rilasciato = New NTSInformatica.NTSGridColumn()
    Me.mo_aperto = New NTSInformatica.NTSGridColumn()
    Me.mo_ricimp = New NTSInformatica.NTSGridColumn()
    Me.mo_provv = New NTSInformatica.NTSGridColumn()
    Me.mo_provv2 = New NTSInformatica.NTSGridColumn()
    Me.mo_controp = New NTSInformatica.NTSGridColumn()
    Me.mo_codiva = New NTSInformatica.NTSGridColumn()
    Me.mo_stasino = New NTSInformatica.NTSGridColumn()
    Me.mo_codcfam = New NTSInformatica.NTSGridColumn()
    Me.mo_commeca = New NTSInformatica.NTSGridColumn()
    Me.mo_subcommeca = New NTSInformatica.NTSGridColumn()
    Me.mo_codcena = New NTSInformatica.NTSGridColumn()
    Me.mo_note = New NTSInformatica.NTSGridColumn()
    Me.mo_valore = New NTSInformatica.NTSGridColumn()
    Me.mo_datconsor = New NTSInformatica.NTSGridColumn()
    Me.mo_codclie = New NTSInformatica.NTSGridColumn()
    Me.mo_perqta = New NTSInformatica.NTSGridColumn()
    Me.mo_valoremm = New NTSInformatica.NTSGridColumn()
    Me.mo_flkit = New NTSInformatica.NTSGridColumn()
    Me.mo_ktriga = New NTSInformatica.NTSGridColumn()
    Me.mo_oatipo = New NTSInformatica.NTSGridColumn()
    Me.mo_oaanno = New NTSInformatica.NTSGridColumn()
    Me.mo_oaserie = New NTSInformatica.NTSGridColumn()
    Me.mo_oanum = New NTSInformatica.NTSGridColumn()
    Me.mo_oariga = New NTSInformatica.NTSGridColumn()
    Me.mo_oasalcon = New NTSInformatica.NTSGridColumn()
    Me.mo_pmtaskid = New NTSInformatica.NTSGridColumn()
    Me.mo_pmqtadis = New NTSInformatica.NTSGridColumn()
    Me.mo_pmvaldis = New NTSInformatica.NTSGridColumn()
    Me.mo_matric = New NTSInformatica.NTSGridColumn()
    CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.NtsPanel1.SuspendLayout()
    CType(Me.grStorico, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grvStorico, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.NtsPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.NtsPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
    Me.NtsPanel1.Appearance.Options.UseBackColor = True
    Me.NtsPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
    Me.NtsPanel1.Controls.Add(Me.grStorico)
    Me.NtsPanel1.Cursor = System.Windows.Forms.Cursors.Default
    Me.NtsPanel1.Location = New System.Drawing.Point(3, 2)
    Me.NtsPanel1.Name = "NtsPanel1"
    Me.NtsPanel1.Size = New System.Drawing.Size(549, 294)
    Me.NtsPanel1.TabIndex = 0
    Me.NtsPanel1.Text = "NtsPanel1"
    '
    'grStorico
    '
    Me.grStorico.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    '
    '
    '
    Me.grStorico.EmbeddedNavigator.Name = ""
    Me.grStorico.Location = New System.Drawing.Point(0, 4)
    Me.grStorico.MainView = Me.grvStorico
    Me.grStorico.Name = "grStorico"
    Me.grStorico.Size = New System.Drawing.Size(546, 287)
    Me.grStorico.TabIndex = 0
    Me.grStorico.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvStorico})
    '
    'grvStorico
    '
    Me.grvStorico.ActiveFilterEnabled = False
    Me.grvStorico.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.mo_riga, Me.mo_codart, Me.mo_descr, Me.mo_unmis, Me.mo_colli, Me.mo_colpre, Me.mo_coleva, Me.mo_ump, Me.mo_quant, Me.mo_quapre, Me.mo_quaeva, Me.mo_flevapre, Me.mo_flevas, Me.mo_prezzo, Me.mo_scont1, Me.mo_scont2, Me.mo_datcons, Me.mo_confermato, Me.mo_rilasciato, Me.mo_aperto, Me.mo_ricimp, Me.mo_provv, Me.mo_provv2, Me.mo_controp, Me.mo_codiva, Me.mo_stasino, Me.mo_codcfam, Me.mo_commeca, Me.mo_subcommeca, Me.mo_codcena, Me.mo_note, Me.mo_valore, Me.mo_datconsor, Me.mo_codclie, Me.mo_perqta, Me.mo_valoremm, Me.mo_flkit, Me.mo_ktriga, Me.mo_oatipo, Me.mo_oaanno, Me.mo_oaserie, Me.mo_oanum, Me.mo_oariga, Me.mo_oasalcon, Me.mo_pmtaskid, Me.mo_pmqtadis, Me.mo_pmvaldis, Me.mo_matric})
    Me.grvStorico.Enabled = True
    Me.grvStorico.GridControl = Me.grStorico

    Me.grvStorico.Name = "grvStorico"
    Me.grvStorico.NTSAllowDelete = True
    Me.grvStorico.NTSAllowInsert = True
    Me.grvStorico.NTSAllowUpdate = True
    Me.grvStorico.NTSMenuContext = Nothing
    Me.grvStorico.OptionsCustomization.AllowRowSizing = True
    Me.grvStorico.OptionsFilter.AllowFilterEditor = False
    Me.grvStorico.OptionsNavigation.EnterMoveNextColumn = True
    Me.grvStorico.OptionsNavigation.UseTabKey = False
    Me.grvStorico.OptionsSelection.EnableAppearanceFocusedRow = False
    Me.grvStorico.OptionsView.ColumnAutoWidth = False
    Me.grvStorico.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
    Me.grvStorico.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
    Me.grvStorico.OptionsView.ShowGroupPanel = False
    Me.grvStorico.RowHeight = 14
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
    Me.mo_riga.VisibleIndex = 0
    '
    'mo_codart
    '
    Me.mo_codart.AppearanceCell.Options.UseBackColor = True
    Me.mo_codart.AppearanceCell.Options.UseTextOptions = True
    Me.mo_codart.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_codart.Caption = "Cod. Art"
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
    Me.mo_codart.Visible = True
    Me.mo_codart.VisibleIndex = 1
    '
    'mo_descr
    '
    Me.mo_descr.AppearanceCell.Options.UseBackColor = True
    Me.mo_descr.AppearanceCell.Options.UseTextOptions = True
    Me.mo_descr.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_descr.Caption = "Descrizione"
    Me.mo_descr.Enabled = True
    Me.mo_descr.FieldName = "mo_descr"
    Me.mo_descr.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_descr.Name = "mo_descr"
    Me.mo_descr.NTSRepositoryComboBox = Nothing
    Me.mo_descr.NTSRepositoryItemCheck = Nothing
    Me.mo_descr.NTSRepositoryItemMemo = Nothing
    Me.mo_descr.NTSRepositoryItemText = Nothing
    Me.mo_descr.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_descr.OptionsFilter.AllowFilter = False
    Me.mo_descr.Visible = True
    Me.mo_descr.VisibleIndex = 2
    '
    'mo_unmis
    '
    Me.mo_unmis.AppearanceCell.Options.UseBackColor = True
    Me.mo_unmis.AppearanceCell.Options.UseTextOptions = True
    Me.mo_unmis.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_unmis.Caption = "U. M."
    Me.mo_unmis.Enabled = True
    Me.mo_unmis.FieldName = "mo_unmis"
    Me.mo_unmis.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_unmis.Name = "mo_unmis"
    Me.mo_unmis.NTSRepositoryComboBox = Nothing
    Me.mo_unmis.NTSRepositoryItemCheck = Nothing
    Me.mo_unmis.NTSRepositoryItemMemo = Nothing
    Me.mo_unmis.NTSRepositoryItemText = Nothing
    Me.mo_unmis.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_unmis.OptionsFilter.AllowFilter = False
    Me.mo_unmis.Visible = True
    Me.mo_unmis.VisibleIndex = 3
    '
    'mo_colli
    '
    Me.mo_colli.AppearanceCell.Options.UseBackColor = True
    Me.mo_colli.AppearanceCell.Options.UseTextOptions = True
    Me.mo_colli.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_colli.Caption = "Colli ord."
    Me.mo_colli.Enabled = True
    Me.mo_colli.FieldName = "mo_colli"
    Me.mo_colli.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_colli.Name = "mo_colli"
    Me.mo_colli.NTSRepositoryComboBox = Nothing
    Me.mo_colli.NTSRepositoryItemCheck = Nothing
    Me.mo_colli.NTSRepositoryItemMemo = Nothing
    Me.mo_colli.NTSRepositoryItemText = Nothing
    Me.mo_colli.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_colli.OptionsFilter.AllowFilter = False
    Me.mo_colli.Visible = True
    Me.mo_colli.VisibleIndex = 4
    '
    'mo_colpre
    '
    Me.mo_colpre.AppearanceCell.Options.UseBackColor = True
    Me.mo_colpre.AppearanceCell.Options.UseTextOptions = True
    Me.mo_colpre.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_colpre.Caption = "Colli pren."
    Me.mo_colpre.Enabled = True
    Me.mo_colpre.FieldName = "mo_colpre"
    Me.mo_colpre.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_colpre.Name = "mo_colpre"
    Me.mo_colpre.NTSRepositoryComboBox = Nothing
    Me.mo_colpre.NTSRepositoryItemCheck = Nothing
    Me.mo_colpre.NTSRepositoryItemMemo = Nothing
    Me.mo_colpre.NTSRepositoryItemText = Nothing
    Me.mo_colpre.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_colpre.OptionsFilter.AllowFilter = False
    Me.mo_colpre.Visible = True
    Me.mo_colpre.VisibleIndex = 5
    '
    'mo_coleva
    '
    Me.mo_coleva.AppearanceCell.Options.UseBackColor = True
    Me.mo_coleva.AppearanceCell.Options.UseTextOptions = True
    Me.mo_coleva.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_coleva.Caption = "Colli evasi"
    Me.mo_coleva.Enabled = True
    Me.mo_coleva.FieldName = "mo_coleva"
    Me.mo_coleva.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_coleva.Name = "mo_coleva"
    Me.mo_coleva.NTSRepositoryComboBox = Nothing
    Me.mo_coleva.NTSRepositoryItemCheck = Nothing
    Me.mo_coleva.NTSRepositoryItemMemo = Nothing
    Me.mo_coleva.NTSRepositoryItemText = Nothing
    Me.mo_coleva.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_coleva.OptionsFilter.AllowFilter = False
    Me.mo_coleva.Visible = True
    Me.mo_coleva.VisibleIndex = 6
    '
    'mo_ump
    '
    Me.mo_ump.AppearanceCell.Options.UseBackColor = True
    Me.mo_ump.AppearanceCell.Options.UseTextOptions = True
    Me.mo_ump.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_ump.Caption = "UMP"
    Me.mo_ump.Enabled = True
    Me.mo_ump.FieldName = "mo_ump"
    Me.mo_ump.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_ump.Name = "mo_ump"
    Me.mo_ump.NTSRepositoryComboBox = Nothing
    Me.mo_ump.NTSRepositoryItemCheck = Nothing
    Me.mo_ump.NTSRepositoryItemMemo = Nothing
    Me.mo_ump.NTSRepositoryItemText = Nothing
    Me.mo_ump.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_ump.OptionsFilter.AllowFilter = False
    Me.mo_ump.Visible = True
    Me.mo_ump.VisibleIndex = 7
    '
    'mo_quant
    '
    Me.mo_quant.AppearanceCell.Options.UseBackColor = True
    Me.mo_quant.AppearanceCell.Options.UseTextOptions = True
    Me.mo_quant.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_quant.Caption = "Q.tà ordin."
    Me.mo_quant.Enabled = True
    Me.mo_quant.FieldName = "mo_quant"
    Me.mo_quant.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_quant.Name = "mo_quant"
    Me.mo_quant.NTSRepositoryComboBox = Nothing
    Me.mo_quant.NTSRepositoryItemCheck = Nothing
    Me.mo_quant.NTSRepositoryItemMemo = Nothing
    Me.mo_quant.NTSRepositoryItemText = Nothing
    Me.mo_quant.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_quant.OptionsFilter.AllowFilter = False
    Me.mo_quant.Visible = True
    Me.mo_quant.VisibleIndex = 8
    '
    'mo_quapre
    '
    Me.mo_quapre.AppearanceCell.Options.UseBackColor = True
    Me.mo_quapre.AppearanceCell.Options.UseTextOptions = True
    Me.mo_quapre.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_quapre.Caption = "Q.tà pren."
    Me.mo_quapre.Enabled = True
    Me.mo_quapre.FieldName = "mo_quapre"
    Me.mo_quapre.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_quapre.Name = "mo_quapre"
    Me.mo_quapre.NTSRepositoryComboBox = Nothing
    Me.mo_quapre.NTSRepositoryItemCheck = Nothing
    Me.mo_quapre.NTSRepositoryItemMemo = Nothing
    Me.mo_quapre.NTSRepositoryItemText = Nothing
    Me.mo_quapre.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_quapre.OptionsFilter.AllowFilter = False
    Me.mo_quapre.Visible = True
    Me.mo_quapre.VisibleIndex = 9
    '
    'mo_quaeva
    '
    Me.mo_quaeva.AppearanceCell.Options.UseBackColor = True
    Me.mo_quaeva.AppearanceCell.Options.UseTextOptions = True
    Me.mo_quaeva.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_quaeva.Caption = "Q.tà evasa"
    Me.mo_quaeva.Enabled = True
    Me.mo_quaeva.FieldName = "mo_quaeva"
    Me.mo_quaeva.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_quaeva.Name = "mo_quaeva"
    Me.mo_quaeva.NTSRepositoryComboBox = Nothing
    Me.mo_quaeva.NTSRepositoryItemCheck = Nothing
    Me.mo_quaeva.NTSRepositoryItemMemo = Nothing
    Me.mo_quaeva.NTSRepositoryItemText = Nothing
    Me.mo_quaeva.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_quaeva.OptionsFilter.AllowFilter = False
    Me.mo_quaeva.Visible = True
    Me.mo_quaeva.VisibleIndex = 10
    '
    'mo_flevapre
    '
    Me.mo_flevapre.AppearanceCell.Options.UseBackColor = True
    Me.mo_flevapre.AppearanceCell.Options.UseTextOptions = True
    Me.mo_flevapre.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_flevapre.Caption = "Pr. totale"
    Me.mo_flevapre.Enabled = True
    Me.mo_flevapre.FieldName = "mo_flevapre"
    Me.mo_flevapre.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_flevapre.Name = "mo_flevapre"
    Me.mo_flevapre.NTSRepositoryComboBox = Nothing
    Me.mo_flevapre.NTSRepositoryItemCheck = Nothing
    Me.mo_flevapre.NTSRepositoryItemMemo = Nothing
    Me.mo_flevapre.NTSRepositoryItemText = Nothing
    Me.mo_flevapre.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_flevapre.OptionsFilter.AllowFilter = False
    Me.mo_flevapre.Visible = True
    Me.mo_flevapre.VisibleIndex = 11
    '
    'mo_flevas
    '
    Me.mo_flevas.AppearanceCell.Options.UseBackColor = True
    Me.mo_flevas.AppearanceCell.Options.UseTextOptions = True
    Me.mo_flevas.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_flevas.Caption = "Evas. totale"
    Me.mo_flevas.Enabled = True
    Me.mo_flevas.FieldName = "mo_flevas"
    Me.mo_flevas.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_flevas.Name = "mo_flevas"
    Me.mo_flevas.NTSRepositoryComboBox = Nothing
    Me.mo_flevas.NTSRepositoryItemCheck = Nothing
    Me.mo_flevas.NTSRepositoryItemMemo = Nothing
    Me.mo_flevas.NTSRepositoryItemText = Nothing
    Me.mo_flevas.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_flevas.OptionsFilter.AllowFilter = False
    Me.mo_flevas.Visible = True
    Me.mo_flevas.VisibleIndex = 12
    '
    'mo_prezzo
    '
    Me.mo_prezzo.AppearanceCell.Options.UseBackColor = True
    Me.mo_prezzo.AppearanceCell.Options.UseTextOptions = True
    Me.mo_prezzo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_prezzo.Caption = "Prezzo"
    Me.mo_prezzo.Enabled = True
    Me.mo_prezzo.FieldName = "mo_prezzo"
    Me.mo_prezzo.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_prezzo.Name = "mo_prezzo"
    Me.mo_prezzo.NTSRepositoryComboBox = Nothing
    Me.mo_prezzo.NTSRepositoryItemCheck = Nothing
    Me.mo_prezzo.NTSRepositoryItemMemo = Nothing
    Me.mo_prezzo.NTSRepositoryItemText = Nothing
    Me.mo_prezzo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_prezzo.OptionsFilter.AllowFilter = False
    Me.mo_prezzo.Visible = True
    Me.mo_prezzo.VisibleIndex = 13
    '
    'mo_scont1
    '
    Me.mo_scont1.AppearanceCell.Options.UseBackColor = True
    Me.mo_scont1.AppearanceCell.Options.UseTextOptions = True
    Me.mo_scont1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_scont1.Caption = "Sconto 1"
    Me.mo_scont1.Enabled = True
    Me.mo_scont1.FieldName = "mo_scont1"
    Me.mo_scont1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_scont1.Name = "mo_scont1"
    Me.mo_scont1.NTSRepositoryComboBox = Nothing
    Me.mo_scont1.NTSRepositoryItemCheck = Nothing
    Me.mo_scont1.NTSRepositoryItemMemo = Nothing
    Me.mo_scont1.NTSRepositoryItemText = Nothing
    Me.mo_scont1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_scont1.OptionsFilter.AllowFilter = False
    Me.mo_scont1.Visible = True
    Me.mo_scont1.VisibleIndex = 14
    '
    'mo_scont2
    '
    Me.mo_scont2.AppearanceCell.Options.UseBackColor = True
    Me.mo_scont2.AppearanceCell.Options.UseTextOptions = True
    Me.mo_scont2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_scont2.Caption = "Sconto 2"
    Me.mo_scont2.Enabled = True
    Me.mo_scont2.FieldName = "mo_scont2"
    Me.mo_scont2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_scont2.Name = "mo_scont2"
    Me.mo_scont2.NTSRepositoryComboBox = Nothing
    Me.mo_scont2.NTSRepositoryItemCheck = Nothing
    Me.mo_scont2.NTSRepositoryItemMemo = Nothing
    Me.mo_scont2.NTSRepositoryItemText = Nothing
    Me.mo_scont2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_scont2.OptionsFilter.AllowFilter = False
    Me.mo_scont2.Visible = True
    Me.mo_scont2.VisibleIndex = 15
    '
    'mo_datcons
    '
    Me.mo_datcons.AppearanceCell.Options.UseBackColor = True
    Me.mo_datcons.AppearanceCell.Options.UseTextOptions = True
    Me.mo_datcons.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_datcons.Caption = "Data cons."
    Me.mo_datcons.Enabled = True
    Me.mo_datcons.FieldName = "mo_datcons"
    Me.mo_datcons.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_datcons.Name = "mo_datcons"
    Me.mo_datcons.NTSRepositoryComboBox = Nothing
    Me.mo_datcons.NTSRepositoryItemCheck = Nothing
    Me.mo_datcons.NTSRepositoryItemMemo = Nothing
    Me.mo_datcons.NTSRepositoryItemText = Nothing
    Me.mo_datcons.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_datcons.OptionsFilter.AllowFilter = False
    Me.mo_datcons.Visible = True
    Me.mo_datcons.VisibleIndex = 16
    '
    'mo_confermato
    '
    Me.mo_confermato.AppearanceCell.Options.UseBackColor = True
    Me.mo_confermato.AppearanceCell.Options.UseTextOptions = True
    Me.mo_confermato.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_confermato.Caption = "Confermato"
    Me.mo_confermato.Enabled = True
    Me.mo_confermato.FieldName = "mo_confermato"
    Me.mo_confermato.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_confermato.Name = "mo_confermato"
    Me.mo_confermato.NTSRepositoryComboBox = Nothing
    Me.mo_confermato.NTSRepositoryItemCheck = Nothing
    Me.mo_confermato.NTSRepositoryItemMemo = Nothing
    Me.mo_confermato.NTSRepositoryItemText = Nothing
    Me.mo_confermato.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_confermato.OptionsFilter.AllowFilter = False
    Me.mo_confermato.Visible = True
    Me.mo_confermato.VisibleIndex = 17
    '
    'mo_rilasciato
    '
    Me.mo_rilasciato.AppearanceCell.Options.UseBackColor = True
    Me.mo_rilasciato.AppearanceCell.Options.UseTextOptions = True
    Me.mo_rilasciato.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_rilasciato.Caption = "Rilasciato"
    Me.mo_rilasciato.Enabled = True
    Me.mo_rilasciato.FieldName = "mo_rilasciato"
    Me.mo_rilasciato.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_rilasciato.Name = "mo_rilasciato"
    Me.mo_rilasciato.NTSRepositoryComboBox = Nothing
    Me.mo_rilasciato.NTSRepositoryItemCheck = Nothing
    Me.mo_rilasciato.NTSRepositoryItemMemo = Nothing
    Me.mo_rilasciato.NTSRepositoryItemText = Nothing
    Me.mo_rilasciato.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_rilasciato.OptionsFilter.AllowFilter = False
    Me.mo_rilasciato.Visible = True
    Me.mo_rilasciato.VisibleIndex = 18
    '
    'mo_aperto
    '
    Me.mo_aperto.AppearanceCell.Options.UseBackColor = True
    Me.mo_aperto.AppearanceCell.Options.UseTextOptions = True
    Me.mo_aperto.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_aperto.Caption = "Aperto"
    Me.mo_aperto.Enabled = True
    Me.mo_aperto.FieldName = "mo_aperto"
    Me.mo_aperto.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_aperto.Name = "mo_aperto"
    Me.mo_aperto.NTSRepositoryComboBox = Nothing
    Me.mo_aperto.NTSRepositoryItemCheck = Nothing
    Me.mo_aperto.NTSRepositoryItemMemo = Nothing
    Me.mo_aperto.NTSRepositoryItemText = Nothing
    Me.mo_aperto.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_aperto.OptionsFilter.AllowFilter = False
    Me.mo_aperto.Visible = True
    Me.mo_aperto.VisibleIndex = 19
    '
    'mo_ricimp
    '
    Me.mo_ricimp.AppearanceCell.Options.UseBackColor = True
    Me.mo_ricimp.AppearanceCell.Options.UseTextOptions = True
    Me.mo_ricimp.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_ricimp.Caption = "Prov. a val."
    Me.mo_ricimp.Enabled = True
    Me.mo_ricimp.FieldName = "mo_ricimp"
    Me.mo_ricimp.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_ricimp.Name = "mo_ricimp"
    Me.mo_ricimp.NTSRepositoryComboBox = Nothing
    Me.mo_ricimp.NTSRepositoryItemCheck = Nothing
    Me.mo_ricimp.NTSRepositoryItemMemo = Nothing
    Me.mo_ricimp.NTSRepositoryItemText = Nothing
    Me.mo_ricimp.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_ricimp.OptionsFilter.AllowFilter = False
    Me.mo_ricimp.Visible = True
    Me.mo_ricimp.VisibleIndex = 20
    '
    'mo_provv
    '
    Me.mo_provv.AppearanceCell.Options.UseBackColor = True
    Me.mo_provv.AppearanceCell.Options.UseTextOptions = True
    Me.mo_provv.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_provv.Caption = "Provv. 1"
    Me.mo_provv.Enabled = True
    Me.mo_provv.FieldName = "mo_provv"
    Me.mo_provv.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_provv.Name = "mo_provv"
    Me.mo_provv.NTSRepositoryComboBox = Nothing
    Me.mo_provv.NTSRepositoryItemCheck = Nothing
    Me.mo_provv.NTSRepositoryItemMemo = Nothing
    Me.mo_provv.NTSRepositoryItemText = Nothing
    Me.mo_provv.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_provv.OptionsFilter.AllowFilter = False
    Me.mo_provv.Visible = True
    Me.mo_provv.VisibleIndex = 21
    '
    'mo_provv2
    '
    Me.mo_provv2.AppearanceCell.Options.UseBackColor = True
    Me.mo_provv2.AppearanceCell.Options.UseTextOptions = True
    Me.mo_provv2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_provv2.Caption = "Provv. 2"
    Me.mo_provv2.Enabled = True
    Me.mo_provv2.FieldName = "mo_provv2"
    Me.mo_provv2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_provv2.Name = "mo_provv2"
    Me.mo_provv2.NTSRepositoryComboBox = Nothing
    Me.mo_provv2.NTSRepositoryItemCheck = Nothing
    Me.mo_provv2.NTSRepositoryItemMemo = Nothing
    Me.mo_provv2.NTSRepositoryItemText = Nothing
    Me.mo_provv2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_provv2.OptionsFilter.AllowFilter = False
    Me.mo_provv2.Visible = True
    Me.mo_provv2.VisibleIndex = 22
    '
    'mo_controp
    '
    Me.mo_controp.AppearanceCell.Options.UseBackColor = True
    Me.mo_controp.AppearanceCell.Options.UseTextOptions = True
    Me.mo_controp.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_controp.Caption = "Controp."
    Me.mo_controp.Enabled = True
    Me.mo_controp.FieldName = "mo_controp"
    Me.mo_controp.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_controp.Name = "mo_controp"
    Me.mo_controp.NTSRepositoryComboBox = Nothing
    Me.mo_controp.NTSRepositoryItemCheck = Nothing
    Me.mo_controp.NTSRepositoryItemMemo = Nothing
    Me.mo_controp.NTSRepositoryItemText = Nothing
    Me.mo_controp.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_controp.OptionsFilter.AllowFilter = False
    Me.mo_controp.Visible = True
    Me.mo_controp.VisibleIndex = 23
    '
    'mo_codiva
    '
    Me.mo_codiva.AppearanceCell.Options.UseBackColor = True
    Me.mo_codiva.AppearanceCell.Options.UseTextOptions = True
    Me.mo_codiva.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_codiva.Caption = "Cod. IVA"
    Me.mo_codiva.Enabled = True
    Me.mo_codiva.FieldName = "mo_codiva"
    Me.mo_codiva.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_codiva.Name = "mo_codiva"
    Me.mo_codiva.NTSRepositoryComboBox = Nothing
    Me.mo_codiva.NTSRepositoryItemCheck = Nothing
    Me.mo_codiva.NTSRepositoryItemMemo = Nothing
    Me.mo_codiva.NTSRepositoryItemText = Nothing
    Me.mo_codiva.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_codiva.OptionsFilter.AllowFilter = False
    Me.mo_codiva.Visible = True
    Me.mo_codiva.VisibleIndex = 24
    '
    'mo_stasino
    '
    Me.mo_stasino.AppearanceCell.Options.UseBackColor = True
    Me.mo_stasino.AppearanceCell.Options.UseTextOptions = True
    Me.mo_stasino.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_stasino.Caption = "Stampa riga"
    Me.mo_stasino.Enabled = True
    Me.mo_stasino.FieldName = "mo_stasino"
    Me.mo_stasino.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_stasino.Name = "mo_stasino"
    Me.mo_stasino.NTSRepositoryComboBox = Nothing
    Me.mo_stasino.NTSRepositoryItemCheck = Nothing
    Me.mo_stasino.NTSRepositoryItemMemo = Nothing
    Me.mo_stasino.NTSRepositoryItemText = Nothing
    Me.mo_stasino.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_stasino.OptionsFilter.AllowFilter = False
    Me.mo_stasino.Visible = True
    Me.mo_stasino.VisibleIndex = 25
    '
    'mo_codcfam
    '
    Me.mo_codcfam.AppearanceCell.Options.UseBackColor = True
    Me.mo_codcfam.AppearanceCell.Options.UseTextOptions = True
    Me.mo_codcfam.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_codcfam.Caption = "Linea/Fam."
    Me.mo_codcfam.Enabled = True
    Me.mo_codcfam.FieldName = "mo_codcfam"
    Me.mo_codcfam.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_codcfam.Name = "mo_codcfam"
    Me.mo_codcfam.NTSRepositoryComboBox = Nothing
    Me.mo_codcfam.NTSRepositoryItemCheck = Nothing
    Me.mo_codcfam.NTSRepositoryItemMemo = Nothing
    Me.mo_codcfam.NTSRepositoryItemText = Nothing
    Me.mo_codcfam.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_codcfam.OptionsFilter.AllowFilter = False
    Me.mo_codcfam.Visible = True
    Me.mo_codcfam.VisibleIndex = 26
    '
    'mo_commeca
    '
    Me.mo_commeca.AppearanceCell.Options.UseBackColor = True
    Me.mo_commeca.AppearanceCell.Options.UseTextOptions = True
    Me.mo_commeca.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_commeca.Caption = "Comm. C.A."
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
    Me.mo_commeca.VisibleIndex = 27
    '
    'mo_subcommeca
    '
    Me.mo_subcommeca.AppearanceCell.Options.UseBackColor = True
    Me.mo_subcommeca.AppearanceCell.Options.UseTextOptions = True
    Me.mo_subcommeca.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_subcommeca.Caption = "Sub C. "
    Me.mo_subcommeca.Enabled = True
    Me.mo_subcommeca.FieldName = "mo_subcommeca"
    Me.mo_subcommeca.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_subcommeca.Name = "mo_subcommeca"
    Me.mo_subcommeca.NTSRepositoryComboBox = Nothing
    Me.mo_subcommeca.NTSRepositoryItemCheck = Nothing
    Me.mo_subcommeca.NTSRepositoryItemMemo = Nothing
    Me.mo_subcommeca.NTSRepositoryItemText = Nothing
    Me.mo_subcommeca.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_subcommeca.OptionsFilter.AllowFilter = False
    Me.mo_subcommeca.Visible = True
    Me.mo_subcommeca.VisibleIndex = 28
    '
    'mo_codcena
    '
    Me.mo_codcena.AppearanceCell.Options.UseBackColor = True
    Me.mo_codcena.AppearanceCell.Options.UseTextOptions = True
    Me.mo_codcena.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_codcena.Caption = "Centro CA"
    Me.mo_codcena.Enabled = True
    Me.mo_codcena.FieldName = "mo_codcena"
    Me.mo_codcena.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_codcena.Name = "mo_codcena"
    Me.mo_codcena.NTSRepositoryComboBox = Nothing
    Me.mo_codcena.NTSRepositoryItemCheck = Nothing
    Me.mo_codcena.NTSRepositoryItemMemo = Nothing
    Me.mo_codcena.NTSRepositoryItemText = Nothing
    Me.mo_codcena.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_codcena.OptionsFilter.AllowFilter = False
    Me.mo_codcena.Visible = True
    Me.mo_codcena.VisibleIndex = 29
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
    Me.mo_note.VisibleIndex = 30
    '
    'mo_valore
    '
    Me.mo_valore.AppearanceCell.Options.UseBackColor = True
    Me.mo_valore.AppearanceCell.Options.UseTextOptions = True
    Me.mo_valore.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_valore.Caption = "Valore da evadere"
    Me.mo_valore.Enabled = True
    Me.mo_valore.FieldName = "mo_valore"
    Me.mo_valore.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_valore.Name = "mo_valore"
    Me.mo_valore.NTSRepositoryComboBox = Nothing
    Me.mo_valore.NTSRepositoryItemCheck = Nothing
    Me.mo_valore.NTSRepositoryItemMemo = Nothing
    Me.mo_valore.NTSRepositoryItemText = Nothing
    Me.mo_valore.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_valore.OptionsFilter.AllowFilter = False
    Me.mo_valore.Visible = True
    Me.mo_valore.VisibleIndex = 31
    '
    'mo_datconsor
    '
    Me.mo_datconsor.AppearanceCell.Options.UseBackColor = True
    Me.mo_datconsor.AppearanceCell.Options.UseTextOptions = True
    Me.mo_datconsor.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_datconsor.Caption = "Dt.consegna originaria"
    Me.mo_datconsor.Enabled = True
    Me.mo_datconsor.FieldName = "mo_datconsor"
    Me.mo_datconsor.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_datconsor.Name = "mo_datconsor"
    Me.mo_datconsor.NTSRepositoryComboBox = Nothing
    Me.mo_datconsor.NTSRepositoryItemCheck = Nothing
    Me.mo_datconsor.NTSRepositoryItemMemo = Nothing
    Me.mo_datconsor.NTSRepositoryItemText = Nothing
    Me.mo_datconsor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_datconsor.OptionsFilter.AllowFilter = False
    Me.mo_datconsor.Visible = True
    Me.mo_datconsor.VisibleIndex = 32
    '
    'mo_codclie
    '
    Me.mo_codclie.AppearanceCell.Options.UseBackColor = True
    Me.mo_codclie.AppearanceCell.Options.UseTextOptions = True
    Me.mo_codclie.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_codclie.Caption = "Cod.cliente"
    Me.mo_codclie.Enabled = True
    Me.mo_codclie.FieldName = "mo_codclie"
    Me.mo_codclie.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_codclie.Name = "mo_codclie"
    Me.mo_codclie.NTSRepositoryComboBox = Nothing
    Me.mo_codclie.NTSRepositoryItemCheck = Nothing
    Me.mo_codclie.NTSRepositoryItemMemo = Nothing
    Me.mo_codclie.NTSRepositoryItemText = Nothing
    Me.mo_codclie.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_codclie.OptionsFilter.AllowFilter = False
    Me.mo_codclie.Visible = True
    Me.mo_codclie.VisibleIndex = 33
    '
    'mo_perqta
    '
    Me.mo_perqta.AppearanceCell.Options.UseBackColor = True
    Me.mo_perqta.AppearanceCell.Options.UseTextOptions = True
    Me.mo_perqta.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_perqta.Caption = "Prz/Qta"
    Me.mo_perqta.Enabled = True
    Me.mo_perqta.FieldName = "mo_perqta"
    Me.mo_perqta.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_perqta.Name = "mo_perqta"
    Me.mo_perqta.NTSRepositoryComboBox = Nothing
    Me.mo_perqta.NTSRepositoryItemCheck = Nothing
    Me.mo_perqta.NTSRepositoryItemMemo = Nothing
    Me.mo_perqta.NTSRepositoryItemText = Nothing
    Me.mo_perqta.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_perqta.OptionsFilter.AllowFilter = False
    Me.mo_perqta.Visible = True
    Me.mo_perqta.VisibleIndex = 34
    '
    'mo_valoremm
    '
    Me.mo_valoremm.AppearanceCell.Options.UseBackColor = True
    Me.mo_valoremm.AppearanceCell.Options.UseTextOptions = True
    Me.mo_valoremm.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_valoremm.Caption = "Valore riga t."
    Me.mo_valoremm.Enabled = True
    Me.mo_valoremm.FieldName = "mo_valoremm"
    Me.mo_valoremm.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_valoremm.Name = "mo_valoremm"
    Me.mo_valoremm.NTSRepositoryComboBox = Nothing
    Me.mo_valoremm.NTSRepositoryItemCheck = Nothing
    Me.mo_valoremm.NTSRepositoryItemMemo = Nothing
    Me.mo_valoremm.NTSRepositoryItemText = Nothing
    Me.mo_valoremm.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_valoremm.OptionsFilter.AllowFilter = False
    Me.mo_valoremm.Visible = True
    Me.mo_valoremm.VisibleIndex = 35
    '
    'mo_flkit
    '
    Me.mo_flkit.AppearanceCell.Options.UseBackColor = True
    Me.mo_flkit.AppearanceCell.Options.UseTextOptions = True
    Me.mo_flkit.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_flkit.Caption = "Tipo kit"
    Me.mo_flkit.Enabled = True
    Me.mo_flkit.FieldName = "mo_flkit"
    Me.mo_flkit.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_flkit.Name = "mo_flkit"
    Me.mo_flkit.NTSRepositoryComboBox = Nothing
    Me.mo_flkit.NTSRepositoryItemCheck = Nothing
    Me.mo_flkit.NTSRepositoryItemMemo = Nothing
    Me.mo_flkit.NTSRepositoryItemText = Nothing
    Me.mo_flkit.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_flkit.OptionsFilter.AllowFilter = False
    Me.mo_flkit.Visible = True
    Me.mo_flkit.VisibleIndex = 36
    '
    'mo_ktriga
    '
    Me.mo_ktriga.AppearanceCell.Options.UseBackColor = True
    Me.mo_ktriga.AppearanceCell.Options.UseTextOptions = True
    Me.mo_ktriga.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_ktriga.Caption = "Rif. riga kitRif. riga kit"
    Me.mo_ktriga.Enabled = True
    Me.mo_ktriga.FieldName = "mo_ktriga"
    Me.mo_ktriga.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_ktriga.Name = "mo_ktriga"
    Me.mo_ktriga.NTSRepositoryComboBox = Nothing
    Me.mo_ktriga.NTSRepositoryItemCheck = Nothing
    Me.mo_ktriga.NTSRepositoryItemMemo = Nothing
    Me.mo_ktriga.NTSRepositoryItemText = Nothing
    Me.mo_ktriga.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_ktriga.OptionsFilter.AllowFilter = False
    Me.mo_ktriga.Visible = True
    Me.mo_ktriga.VisibleIndex = 37
    '
    'mo_oatipo
    '
    Me.mo_oatipo.AppearanceCell.Options.UseBackColor = True
    Me.mo_oatipo.AppearanceCell.Options.UseTextOptions = True
    Me.mo_oatipo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_oatipo.Caption = "Tipo ordine ap."
    Me.mo_oatipo.Enabled = True
    Me.mo_oatipo.FieldName = "mo_oatipo"
    Me.mo_oatipo.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_oatipo.Name = "mo_oatipo"
    Me.mo_oatipo.NTSRepositoryComboBox = Nothing
    Me.mo_oatipo.NTSRepositoryItemCheck = Nothing
    Me.mo_oatipo.NTSRepositoryItemMemo = Nothing
    Me.mo_oatipo.NTSRepositoryItemText = Nothing
    Me.mo_oatipo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_oatipo.OptionsFilter.AllowFilter = False
    Me.mo_oatipo.Visible = True
    Me.mo_oatipo.VisibleIndex = 38
    '
    'mo_oaanno
    '
    Me.mo_oaanno.AppearanceCell.Options.UseBackColor = True
    Me.mo_oaanno.AppearanceCell.Options.UseTextOptions = True
    Me.mo_oaanno.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_oaanno.Caption = "Anno ordine ap."
    Me.mo_oaanno.Enabled = True
    Me.mo_oaanno.FieldName = "mo_oaanno"
    Me.mo_oaanno.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_oaanno.Name = "mo_oaanno"
    Me.mo_oaanno.NTSRepositoryComboBox = Nothing
    Me.mo_oaanno.NTSRepositoryItemCheck = Nothing
    Me.mo_oaanno.NTSRepositoryItemMemo = Nothing
    Me.mo_oaanno.NTSRepositoryItemText = Nothing
    Me.mo_oaanno.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_oaanno.OptionsFilter.AllowFilter = False
    Me.mo_oaanno.Visible = True
    Me.mo_oaanno.VisibleIndex = 39
    '
    'mo_oaserie
    '
    Me.mo_oaserie.AppearanceCell.Options.UseBackColor = True
    Me.mo_oaserie.AppearanceCell.Options.UseTextOptions = True
    Me.mo_oaserie.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_oaserie.Caption = "Serie ordine ap."
    Me.mo_oaserie.Enabled = True
    Me.mo_oaserie.FieldName = "mo_oaserie"
    Me.mo_oaserie.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_oaserie.Name = "mo_oaserie"
    Me.mo_oaserie.NTSRepositoryComboBox = Nothing
    Me.mo_oaserie.NTSRepositoryItemCheck = Nothing
    Me.mo_oaserie.NTSRepositoryItemMemo = Nothing
    Me.mo_oaserie.NTSRepositoryItemText = Nothing
    Me.mo_oaserie.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_oaserie.OptionsFilter.AllowFilter = False
    Me.mo_oaserie.Visible = True
    Me.mo_oaserie.VisibleIndex = 40
    '
    'mo_oanum
    '
    Me.mo_oanum.AppearanceCell.Options.UseBackColor = True
    Me.mo_oanum.AppearanceCell.Options.UseTextOptions = True
    Me.mo_oanum.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_oanum.Caption = "Numero ord. ap."
    Me.mo_oanum.Enabled = True
    Me.mo_oanum.FieldName = "mo_oanum"
    Me.mo_oanum.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_oanum.Name = "mo_oanum"
    Me.mo_oanum.NTSRepositoryComboBox = Nothing
    Me.mo_oanum.NTSRepositoryItemCheck = Nothing
    Me.mo_oanum.NTSRepositoryItemMemo = Nothing
    Me.mo_oanum.NTSRepositoryItemText = Nothing
    Me.mo_oanum.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_oanum.OptionsFilter.AllowFilter = False
    Me.mo_oanum.Visible = True
    Me.mo_oanum.VisibleIndex = 41
    '
    'mo_oariga
    '
    Me.mo_oariga.AppearanceCell.Options.UseBackColor = True
    Me.mo_oariga.AppearanceCell.Options.UseTextOptions = True
    Me.mo_oariga.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_oariga.Caption = "Riga ordine ap."
    Me.mo_oariga.Enabled = True
    Me.mo_oariga.FieldName = "mo_oariga"
    Me.mo_oariga.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_oariga.Name = "mo_oariga"
    Me.mo_oariga.NTSRepositoryComboBox = Nothing
    Me.mo_oariga.NTSRepositoryItemCheck = Nothing
    Me.mo_oariga.NTSRepositoryItemMemo = Nothing
    Me.mo_oariga.NTSRepositoryItemText = Nothing
    Me.mo_oariga.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_oariga.OptionsFilter.AllowFilter = False
    Me.mo_oariga.Visible = True
    Me.mo_oariga.VisibleIndex = 42
    '
    'mo_oasalcon
    '
    Me.mo_oasalcon.AppearanceCell.Options.UseBackColor = True
    Me.mo_oasalcon.AppearanceCell.Options.UseTextOptions = True
    Me.mo_oasalcon.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_oasalcon.Caption = "Saldo ordine ap."
    Me.mo_oasalcon.Enabled = True
    Me.mo_oasalcon.FieldName = "mo_oasalcon"
    Me.mo_oasalcon.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_oasalcon.Name = "mo_oasalcon"
    Me.mo_oasalcon.NTSRepositoryComboBox = Nothing
    Me.mo_oasalcon.NTSRepositoryItemCheck = Nothing
    Me.mo_oasalcon.NTSRepositoryItemMemo = Nothing
    Me.mo_oasalcon.NTSRepositoryItemText = Nothing
    Me.mo_oasalcon.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_oasalcon.OptionsFilter.AllowFilter = False
    Me.mo_oasalcon.Visible = True
    Me.mo_oasalcon.VisibleIndex = 43
    '
    'mo_pmtaskid
    '
    Me.mo_pmtaskid.AppearanceCell.Options.UseBackColor = True
    Me.mo_pmtaskid.AppearanceCell.Options.UseTextOptions = True
    Me.mo_pmtaskid.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_pmtaskid.Caption = "Id.Task"
    Me.mo_pmtaskid.Enabled = True
    Me.mo_pmtaskid.FieldName = "mo_pmtaskid"
    Me.mo_pmtaskid.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_pmtaskid.Name = "mo_pmtaskid"
    Me.mo_pmtaskid.NTSRepositoryComboBox = Nothing
    Me.mo_pmtaskid.NTSRepositoryItemCheck = Nothing
    Me.mo_pmtaskid.NTSRepositoryItemMemo = Nothing
    Me.mo_pmtaskid.NTSRepositoryItemText = Nothing
    Me.mo_pmtaskid.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_pmtaskid.OptionsFilter.AllowFilter = False
    Me.mo_pmtaskid.Visible = True
    Me.mo_pmtaskid.VisibleIndex = 44
    '
    'mo_pmqtadis
    '
    Me.mo_pmqtadis.AppearanceCell.Options.UseBackColor = True
    Me.mo_pmqtadis.AppearanceCell.Options.UseTextOptions = True
    Me.mo_pmqtadis.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_pmqtadis.Caption = "PMQTADIS"
    Me.mo_pmqtadis.Enabled = True
    Me.mo_pmqtadis.FieldName = "mo_pmqtadis"
    Me.mo_pmqtadis.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_pmqtadis.Name = "mo_pmqtadis"
    Me.mo_pmqtadis.NTSRepositoryComboBox = Nothing
    Me.mo_pmqtadis.NTSRepositoryItemCheck = Nothing
    Me.mo_pmqtadis.NTSRepositoryItemMemo = Nothing
    Me.mo_pmqtadis.NTSRepositoryItemText = Nothing
    Me.mo_pmqtadis.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_pmqtadis.OptionsFilter.AllowFilter = False
    Me.mo_pmqtadis.Visible = True
    Me.mo_pmqtadis.VisibleIndex = 45
    '
    'mo_pmvaldis
    '
    Me.mo_pmvaldis.AppearanceCell.Options.UseBackColor = True
    Me.mo_pmvaldis.AppearanceCell.Options.UseTextOptions = True
    Me.mo_pmvaldis.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_pmvaldis.Caption = "PMVALDIS"
    Me.mo_pmvaldis.Enabled = True
    Me.mo_pmvaldis.FieldName = "mo_pmvaldis"
    Me.mo_pmvaldis.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_pmvaldis.Name = "mo_pmvaldis"
    Me.mo_pmvaldis.NTSRepositoryComboBox = Nothing
    Me.mo_pmvaldis.NTSRepositoryItemCheck = Nothing
    Me.mo_pmvaldis.NTSRepositoryItemMemo = Nothing
    Me.mo_pmvaldis.NTSRepositoryItemText = Nothing
    Me.mo_pmvaldis.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_pmvaldis.OptionsFilter.AllowFilter = False
    Me.mo_pmvaldis.Visible = True
    Me.mo_pmvaldis.VisibleIndex = 46
    '
    'mo_matric
    '
    Me.mo_matric.AppearanceCell.Options.UseBackColor = True
    Me.mo_matric.AppearanceCell.Options.UseTextOptions = True
    Me.mo_matric.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.mo_matric.Caption = "Barcode"
    Me.mo_matric.Enabled = True
    Me.mo_matric.FieldName = "mo_matric"
    Me.mo_matric.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.mo_matric.Name = "mo_matric"
    Me.mo_matric.NTSRepositoryComboBox = Nothing
    Me.mo_matric.NTSRepositoryItemCheck = Nothing
    Me.mo_matric.NTSRepositoryItemMemo = Nothing
    Me.mo_matric.NTSRepositoryItemText = Nothing
    Me.mo_matric.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.mo_matric.OptionsFilter.AllowFilter = False
    Me.mo_matric.Visible = True
    Me.mo_matric.VisibleIndex = 47
    '
    'FRMHHSTORICO
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
    Me.ClientSize = New System.Drawing.Size(554, 298)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(554, 298)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(554, 298)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsPanel1)
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FRMHHSTORICO"
    Me.Text = "STORICO"
    CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).EndInit()
Me.NtsPanel1.ResumeLayout(False)
    CType(Me.grStorico, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grvStorico, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).EndInit()
Me.PnCPNEPnMain.ResumeLayout(False)
Me.ResumeLayout(False)

  End Sub
#End Region
  Private components As System.ComponentModel.IContainer
  Public oCleHh As CLFORGSOR
  Public dsHh As New DataSet
  Public oCallParams As CLE__CLDP
  Public dcHh As BindingSource = New BindingSource
  Public dcHhGr As BindingSource = New BindingSource

  Public Overridable Sub Bindcontrols()
    Try
      '-------------------------------------------------
      'se i controlli erano già  stati precedentemente collegati, li scollego
      NTSFormClearDataBinding(Me)

      grvStorico.NTSSetParam(oMenu, oApp.Tr(Me, 131248895857566381, "Storico"))
      mo_riga.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857576395, "Riga"), "0", 9, 0, 999999999)
      mo_codart.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857586399, "Cod. Art"), 0, True)
      mo_descr.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857596403, "Descrizione"), 0, True)
      mo_unmis.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857606397, "U. M."), 0, True)
      mo_colli.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857616404, "Colli ord."), "#,##0.00", 15)
      mo_colpre.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857626411, "Colli pren."), "#,##0.00", 15)
      mo_coleva.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857636418, "Colli evasi"), "#,##0.00", 15)
      mo_ump.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857646429, "UMP"), 0, True)
      mo_quant.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857656436, "Q.tà ordin."), "#,##0.00", 15)
      mo_quapre.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857666443, "Q.tà pren."), "#,##0.00", 15)
      mo_quaeva.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857676453, "Q.tà evasa"), "#,##0.00", 15)
      mo_flevapre.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857686460, "Pr. totale"), 0, True)
      mo_flevas.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857696464, "Evas. totale"), 0, True)
      mo_prezzo.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857706468, "Prezzo"), "#,##0.00", 15)
      mo_scont1.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857716479, "Sconto 1"), "#,##0.00", 15)
      mo_scont2.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857726486, "Sconto 2"), "#,##0.00", 15)
      mo_datcons.NTSSetParamDATA(oMenu, oApp.Tr(Me, 131248895857736490, "Data cons."), True)
      mo_confermato.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857746494, "Confermato"), 0, True)
      mo_rilasciato.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857756504, "Rilasciato"), 0, True)
      mo_aperto.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857761642, "Aperto"), 0, True)
      mo_ricimp.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857766639, "Prov. a val."), 0, True)
      mo_provv.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857771653, "Provv. 1"), "#,##0.00", 15)
      mo_provv2.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857776643, "Provv. 2"), "#,##0.00", 15)
      mo_controp.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857781666, "Controp."), "0", 4, 0, 9999)
      mo_codiva.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857786651, "Cod. IVA"), "0", 4, 0, 9999)
      mo_stasino.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857791683, "Stampa riga"), 0, True)
      mo_codcfam.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857796664, "Linea/Fam."), 0, True)
      mo_commeca.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857801664, "Comm. C.A."), "0", 9, 0, 999999999)
      mo_subcommeca.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857806668, "Sub C. "), 0, True)
      mo_codcena.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857811684, "Centro CA"), "0", 9, 0, 999999999)
      mo_note.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857816682, "Note"), 0, True)
      mo_valore.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857821701, "Valore da evadere"), "#,##0.00", 15)
      mo_datconsor.NTSSetParamDATA(oMenu, oApp.Tr(Me, 131248895857826583, "Dt.consegna originaria"), True)
      mo_codclie.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857831692, "Cod.cliente"), "0", 9, 0, 999999999)
      mo_perqta.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857836689, "Prz/Qta"), "#,##0.00", 15)
      mo_valoremm.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857841594, "Valore riga t."), "#,##0.00", 15)
      mo_flkit.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857846693, "Tipo kit"), 0, True)
      mo_ktriga.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857851710, "Rif. riga kitRif. riga kit"), "0", 9, 0, 999999999)
      mo_oatipo.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857856704, "Tipo ordine ap."), 0, True)
      mo_oaanno.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857861608, "Anno ordine ap."), "0", 4, 0, 9999)
      mo_oaserie.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857866708, "Serie ordine ap."), 0, True)
      mo_oanum.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857871724, "Numero ord. ap."), "0", 9, 0, 999999999)
      mo_oariga.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857876712, "Riga ordine ap."), "0", 9, 0, 999999999)
      mo_oasalcon.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857881741, "Saldo ordine ap."), 0, True)
      mo_pmtaskid.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857886725, "Id.Task"), "0", 9, 0, 999999999)
      mo_pmqtadis.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857891738, "PMQTADIS"), "#,##0.00", 15)
      mo_pmvaldis.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131248895857896732, "PMVALDIS"), "#,##0.00", 15)
      mo_matric.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131248895857901736, "Barcode"), 0, True)


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

  Private Sub FRMHHSTORICO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
TRY
    'dsHh = oCleHh.dsShared

    dsHh = oCleHh.DsZoomCPNE

    CType(oCleHh, CLFORGSOR).CPNECaricaStorico()

    dsHh = CType(oCleHh, CLFORGSOR).DsZoomCPNE
    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = dsHh.Tables("CPNE.STORICO")
    AggGriglia()
    Bindcontrols()

    grvStorico.NTSAllowInsert = False
    grvStorico.NTSAllowDelete = False
    grvStorico.Enabled = False


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
    dcHhGr.DataSource = dsHh.Tables("CPNE.STORICO")
    grStorico.DataSource = dcHhGr
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
End Class
