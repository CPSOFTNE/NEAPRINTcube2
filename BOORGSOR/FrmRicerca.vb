Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Imports System.Windows.Forms
Public Class FrmRicerca
 

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
    oPar = Param
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
        Me.NtsPanelForm = New NTSInformatica.NTSPanel()
        Me.NtsPanelGriglia = New NTSInformatica.NTSPanel()
        Me.grRigheOrdPre = New NTSInformatica.NTSGrid()
        Me.grvRigheOrdPre = New NTSInformatica.NTSGridView()
        Me.xx_sel = New NTSInformatica.NTSGridColumn()
        Me.td_tipork = New NTSInformatica.NTSGridColumn()
        Me.td_anno = New NTSInformatica.NTSGridColumn()
        Me.td_serie = New NTSInformatica.NTSGridColumn()
        Me.td_numord = New NTSInformatica.NTSGridColumn()
        Me.td_datord = New NTSInformatica.NTSGridColumn()
        Me.an_descr1 = New NTSInformatica.NTSGridColumn()
        Me.an_conto = New NTSInformatica.NTSGridColumn()
        Me.mo_commeca = New NTSInformatica.NTSGridColumn()
        Me.td_codagen = New NTSInformatica.NTSGridColumn()
        Me.xx_agente = New NTSInformatica.NTSGridColumn()
        Me.td_codagen2 = New NTSInformatica.NTSGridColumn()
        Me.xx_agenzia = New NTSInformatica.NTSGridColumn()
        Me.mo_note = New NTSInformatica.NTSGridColumn()
        Me.mo_descr = New NTSInformatica.NTSGridColumn()
        Me.td_tipobf = New NTSInformatica.NTSGridColumn()
        Me.NtsLabel1 = New NTSInformatica.NTSLabel()
        Me.NtsPanelFiltri = New NTSInformatica.NTSPanel()
        Me.cmdCPNEDuplica = New NTSInformatica.NTSButton()
        Me.cmdSeleziona = New NTSInformatica.NTSButton()
        Me.cmdAnnulla = New NTSInformatica.NTSButton()
        Me.cmdRicerca = New NTSInformatica.NTSButton()
        Me.NtsPanelFiltriDx = New NTSInformatica.NTSPanel()
        Me.Cbxx_Tipo = New NTSInformatica.NTSComboBox()
        Me.Edxx_CodAgenA = New NTSInformatica.NTSTextBoxNum()
        Me.Edxx_CodAgenDa = New NTSInformatica.NTSTextBoxNum()
        Me.NtsLabel7 = New NTSInformatica.NTSLabel()
        Me.Edxx_AgenziaA = New NTSInformatica.NTSTextBoxNum()
        Me.Edxx_AgenziaDa = New NTSInformatica.NTSTextBoxNum()
        Me.edxx_ContoA = New NTSInformatica.NTSTextBoxNum()
        Me.NtsLabel8 = New NTSInformatica.NTSLabel()
        Me.NtsLabel9 = New NTSInformatica.NTSLabel()
        Me.NtsLabel10 = New NTSInformatica.NTSLabel()
        Me.NtsLabel11 = New NTSInformatica.NTSLabel()
        Me.edxx_ContoDa = New NTSInformatica.NTSTextBoxNum()
        Me.NtsLabel12 = New NTSInformatica.NTSLabel()
        Me.NtsPanelFiltriSx = New NTSInformatica.NTSPanel()
        Me.Edxx_SerieA = New NTSInformatica.NTSTextBoxStr()
        Me.Edxx_SerieDa = New NTSInformatica.NTSTextBoxStr()
        Me.NtsLabel6 = New NTSInformatica.NTSLabel()
        Me.edxx_CommessaA = New NTSInformatica.NTSTextBoxNum()
        Me.edxx_NumdocA = New NTSInformatica.NTSTextBoxNum()
        Me.edxx_CommessaDa = New NTSInformatica.NTSTextBoxNum()
        Me.edxx_NumdocDa = New NTSInformatica.NTSTextBoxNum()
        Me.Edxx_AnnoA = New NTSInformatica.NTSTextBoxNum()
        Me.NtsLabel5 = New NTSInformatica.NTSLabel()
        Me.NtsLabel4 = New NTSInformatica.NTSLabel()
        Me.NtsLabel3 = New NTSInformatica.NTSLabel()
        Me.NtsLabel2 = New NTSInformatica.NTSLabel()
        Me.Edxx_AnnoDa = New NTSInformatica.NTSTextBoxNum()
        Me.lbFiltriSxDa = New NTSInformatica.NTSLabel()
        Me.PnCPNEPnMain = New NTSInformatica.NTSPanel()
        Me.NtsLabel13 = New NTSInformatica.NTSLabel()
        Me.edxx_descrtitolo = New NTSInformatica.NTSTextBoxStr()
        CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NtsPanelForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NtsPanelForm.SuspendLayout()
        CType(Me.NtsPanelGriglia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NtsPanelGriglia.SuspendLayout()
        CType(Me.grRigheOrdPre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvRigheOrdPre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NtsPanelFiltri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NtsPanelFiltri.SuspendLayout()
        CType(Me.NtsPanelFiltriDx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NtsPanelFiltriDx.SuspendLayout()
        CType(Me.Cbxx_Tipo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edxx_CodAgenA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edxx_CodAgenDa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edxx_AgenziaA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edxx_AgenziaDa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edxx_ContoA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edxx_ContoDa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NtsPanelFiltriSx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NtsPanelFiltriSx.SuspendLayout()
        CType(Me.Edxx_SerieA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edxx_SerieDa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edxx_CommessaA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edxx_NumdocA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edxx_CommessaDa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edxx_NumdocDa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edxx_AnnoA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Edxx_AnnoDa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnCPNEPnMain.SuspendLayout()
        CType(Me.edxx_descrtitolo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NtsPanelForm
        '
        Me.NtsPanelForm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NtsPanelForm.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.NtsPanelForm.Appearance.Options.UseBackColor = True
        Me.NtsPanelForm.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.NtsPanelForm.Controls.Add(Me.NtsPanelGriglia)
        Me.NtsPanelForm.Controls.Add(Me.NtsLabel1)
        Me.NtsPanelForm.Controls.Add(Me.NtsPanelFiltri)
        Me.NtsPanelForm.Location = New System.Drawing.Point(4, 4)
        Me.NtsPanelForm.Name = "NtsPanelForm"
        Me.NtsPanelForm.Size = New System.Drawing.Size(588, 491)
        '
        'NtsPanelGriglia
        '
        Me.NtsPanelGriglia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NtsPanelGriglia.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.NtsPanelGriglia.Appearance.Options.UseBackColor = True
        Me.NtsPanelGriglia.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.NtsPanelGriglia.Controls.Add(Me.grRigheOrdPre)
        Me.NtsPanelGriglia.Location = New System.Drawing.Point(9, 231)
        Me.NtsPanelGriglia.Name = "NtsPanelGriglia"
        Me.NtsPanelGriglia.Size = New System.Drawing.Size(576, 257)
        '
        'grRigheOrdPre
        '
        Me.grRigheOrdPre.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grRigheOrdPre.Location = New System.Drawing.Point(1, 3)
        Me.grRigheOrdPre.MainView = Me.grvRigheOrdPre
        Me.grRigheOrdPre.Name = "grRigheOrdPre"
        Me.grRigheOrdPre.Size = New System.Drawing.Size(569, 247)
        Me.grRigheOrdPre.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvRigheOrdPre})
        '
        'grvRigheOrdPre
        '
        Me.grvRigheOrdPre.ActiveFilterEnabled = False
        Me.grvRigheOrdPre.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.xx_sel, Me.td_tipork, Me.td_anno, Me.td_serie, Me.td_numord, Me.td_datord, Me.an_descr1, Me.an_conto, Me.mo_commeca, Me.td_codagen, Me.xx_agente, Me.td_codagen2, Me.xx_agenzia, Me.mo_note, Me.mo_descr, Me.td_tipobf})
        Me.grvRigheOrdPre.Enabled = True
        Me.grvRigheOrdPre.GridControl = Me.grRigheOrdPre
        Me.grvRigheOrdPre.Name = "grvRigheOrdPre"
        Me.grvRigheOrdPre.OptionsCustomization.AllowRowSizing = True
        Me.grvRigheOrdPre.OptionsFilter.AllowFilterEditor = False
        Me.grvRigheOrdPre.OptionsNavigation.EnterMoveNextColumn = True
        Me.grvRigheOrdPre.OptionsNavigation.UseTabKey = False
        Me.grvRigheOrdPre.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.grvRigheOrdPre.OptionsView.ColumnAutoWidth = False
        Me.grvRigheOrdPre.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden
        Me.grvRigheOrdPre.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.grvRigheOrdPre.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grvRigheOrdPre.OptionsView.ShowGroupPanel = False
        '
        'xx_sel
        '
        Me.xx_sel.AppearanceCell.Options.UseBackColor = True
        Me.xx_sel.AppearanceCell.Options.UseTextOptions = True
        Me.xx_sel.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.xx_sel.Caption = "Seleziona"
        Me.xx_sel.Enabled = True
        Me.xx_sel.FieldName = "xx_sel"
        Me.xx_sel.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.xx_sel.Name = "xx_sel"
        Me.xx_sel.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.xx_sel.OptionsFilter.AllowFilter = False
        Me.xx_sel.Visible = True
        Me.xx_sel.VisibleIndex = 14
        '
        'td_tipork
        '
        Me.td_tipork.AppearanceCell.Options.UseBackColor = True
        Me.td_tipork.AppearanceCell.Options.UseTextOptions = True
        Me.td_tipork.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.td_tipork.Caption = "Tipo"
        Me.td_tipork.Enabled = False
        Me.td_tipork.FieldName = "td_tipork"
        Me.td_tipork.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.td_tipork.Name = "td_tipork"
        Me.td_tipork.OptionsColumn.AllowEdit = False
        Me.td_tipork.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.td_tipork.OptionsColumn.ReadOnly = True
        Me.td_tipork.OptionsFilter.AllowFilter = False
        Me.td_tipork.Visible = True
        Me.td_tipork.VisibleIndex = 0
        '
        'td_anno
        '
        Me.td_anno.AppearanceCell.Options.UseBackColor = True
        Me.td_anno.AppearanceCell.Options.UseTextOptions = True
        Me.td_anno.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.td_anno.Caption = "Anno"
        Me.td_anno.Enabled = False
        Me.td_anno.FieldName = "td_anno"
        Me.td_anno.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.td_anno.Name = "td_anno"
        Me.td_anno.OptionsColumn.AllowEdit = False
        Me.td_anno.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.td_anno.OptionsColumn.ReadOnly = True
        Me.td_anno.OptionsFilter.AllowFilter = False
        Me.td_anno.Visible = True
        Me.td_anno.VisibleIndex = 1
        '
        'td_serie
        '
        Me.td_serie.AppearanceCell.Options.UseBackColor = True
        Me.td_serie.AppearanceCell.Options.UseTextOptions = True
        Me.td_serie.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.td_serie.Caption = "Serie"
        Me.td_serie.Enabled = False
        Me.td_serie.FieldName = "td_serie"
        Me.td_serie.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.td_serie.Name = "td_serie"
        Me.td_serie.OptionsColumn.AllowEdit = False
        Me.td_serie.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.td_serie.OptionsColumn.ReadOnly = True
        Me.td_serie.OptionsFilter.AllowFilter = False
        Me.td_serie.Visible = True
        Me.td_serie.VisibleIndex = 2
        '
        'td_numord
        '
        Me.td_numord.AppearanceCell.Options.UseBackColor = True
        Me.td_numord.AppearanceCell.Options.UseTextOptions = True
        Me.td_numord.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.td_numord.Caption = "Numero"
        Me.td_numord.Enabled = False
        Me.td_numord.FieldName = "td_numord"
        Me.td_numord.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.td_numord.Name = "td_numord"
        Me.td_numord.OptionsColumn.AllowEdit = False
        Me.td_numord.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.td_numord.OptionsColumn.ReadOnly = True
        Me.td_numord.OptionsFilter.AllowFilter = False
        Me.td_numord.Visible = True
        Me.td_numord.VisibleIndex = 3
        '
        'td_datord
        '
        Me.td_datord.AppearanceCell.Options.UseBackColor = True
        Me.td_datord.AppearanceCell.Options.UseTextOptions = True
        Me.td_datord.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.td_datord.Caption = "Data"
        Me.td_datord.Enabled = False
        Me.td_datord.FieldName = "td_datord"
        Me.td_datord.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.td_datord.Name = "td_datord"
        Me.td_datord.OptionsColumn.AllowEdit = False
        Me.td_datord.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.td_datord.OptionsColumn.ReadOnly = True
        Me.td_datord.OptionsFilter.AllowFilter = False
        Me.td_datord.Visible = True
        Me.td_datord.VisibleIndex = 4
        '
        'an_descr1
        '
        Me.an_descr1.AppearanceCell.Options.UseBackColor = True
        Me.an_descr1.AppearanceCell.Options.UseTextOptions = True
        Me.an_descr1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.an_descr1.Caption = "Des.Cli."
        Me.an_descr1.Enabled = False
        Me.an_descr1.FieldName = "an_descr1"
        Me.an_descr1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.an_descr1.Name = "an_descr1"
        Me.an_descr1.OptionsColumn.AllowEdit = False
        Me.an_descr1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.an_descr1.OptionsColumn.ReadOnly = True
        Me.an_descr1.OptionsFilter.AllowFilter = False
        Me.an_descr1.Visible = True
        Me.an_descr1.VisibleIndex = 5
        '
        'an_conto
        '
        Me.an_conto.AppearanceCell.Options.UseBackColor = True
        Me.an_conto.AppearanceCell.Options.UseTextOptions = True
        Me.an_conto.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.an_conto.Caption = "Cod.Cli."
        Me.an_conto.Enabled = False
        Me.an_conto.FieldName = "an_conto"
        Me.an_conto.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.an_conto.Name = "an_conto"
        Me.an_conto.OptionsColumn.AllowEdit = False
        Me.an_conto.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.an_conto.OptionsColumn.ReadOnly = True
        Me.an_conto.OptionsFilter.AllowFilter = False
        Me.an_conto.Visible = True
        Me.an_conto.VisibleIndex = 6
        '
        'mo_commeca
        '
        Me.mo_commeca.AppearanceCell.Options.UseBackColor = True
        Me.mo_commeca.AppearanceCell.Options.UseTextOptions = True
        Me.mo_commeca.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.mo_commeca.Caption = "Commessa"
        Me.mo_commeca.Enabled = False
        Me.mo_commeca.FieldName = "mo_commeca"
        Me.mo_commeca.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.mo_commeca.Name = "mo_commeca"
        Me.mo_commeca.OptionsColumn.AllowEdit = False
        Me.mo_commeca.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.mo_commeca.OptionsColumn.ReadOnly = True
        Me.mo_commeca.OptionsFilter.AllowFilter = False
        Me.mo_commeca.Visible = True
        Me.mo_commeca.VisibleIndex = 7
        '
        'td_codagen
        '
        Me.td_codagen.AppearanceCell.Options.UseBackColor = True
        Me.td_codagen.AppearanceCell.Options.UseTextOptions = True
        Me.td_codagen.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.td_codagen.Caption = "Agente"
        Me.td_codagen.Enabled = False
        Me.td_codagen.FieldName = "td_codagen"
        Me.td_codagen.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.td_codagen.Name = "td_codagen"
        Me.td_codagen.OptionsColumn.AllowEdit = False
        Me.td_codagen.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.td_codagen.OptionsColumn.ReadOnly = True
        Me.td_codagen.OptionsFilter.AllowFilter = False
        Me.td_codagen.Visible = True
        Me.td_codagen.VisibleIndex = 8
        '
        'xx_agente
        '
        Me.xx_agente.AppearanceCell.Options.UseBackColor = True
        Me.xx_agente.AppearanceCell.Options.UseTextOptions = True
        Me.xx_agente.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.xx_agente.Caption = "Desc.Agente"
        Me.xx_agente.Enabled = False
        Me.xx_agente.FieldName = "xx_agente"
        Me.xx_agente.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.xx_agente.Name = "xx_agente"
        Me.xx_agente.OptionsColumn.AllowEdit = False
        Me.xx_agente.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.xx_agente.OptionsColumn.ReadOnly = True
        Me.xx_agente.OptionsFilter.AllowFilter = False
        Me.xx_agente.Visible = True
        Me.xx_agente.VisibleIndex = 9
        '
        'td_codagen2
        '
        Me.td_codagen2.AppearanceCell.Options.UseBackColor = True
        Me.td_codagen2.AppearanceCell.Options.UseTextOptions = True
        Me.td_codagen2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.td_codagen2.Caption = "Agenzia"
        Me.td_codagen2.Enabled = False
        Me.td_codagen2.FieldName = "td_codagen2"
        Me.td_codagen2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.td_codagen2.Name = "td_codagen2"
        Me.td_codagen2.OptionsColumn.AllowEdit = False
        Me.td_codagen2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.td_codagen2.OptionsColumn.ReadOnly = True
        Me.td_codagen2.OptionsFilter.AllowFilter = False
        Me.td_codagen2.Visible = True
        Me.td_codagen2.VisibleIndex = 10
        '
        'xx_agenzia
        '
        Me.xx_agenzia.AppearanceCell.Options.UseBackColor = True
        Me.xx_agenzia.AppearanceCell.Options.UseTextOptions = True
        Me.xx_agenzia.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.xx_agenzia.Caption = "Desc.Agenzia"
        Me.xx_agenzia.Enabled = False
        Me.xx_agenzia.FieldName = "xx_agenzia"
        Me.xx_agenzia.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.xx_agenzia.Name = "xx_agenzia"
        Me.xx_agenzia.OptionsColumn.AllowEdit = False
        Me.xx_agenzia.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.xx_agenzia.OptionsColumn.ReadOnly = True
        Me.xx_agenzia.OptionsFilter.AllowFilter = False
        Me.xx_agenzia.Visible = True
        Me.xx_agenzia.VisibleIndex = 11
        '
        'mo_note
        '
        Me.mo_note.AppearanceCell.Options.UseBackColor = True
        Me.mo_note.AppearanceCell.Options.UseTextOptions = True
        Me.mo_note.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.mo_note.Caption = "Note"
        Me.mo_note.Enabled = False
        Me.mo_note.FieldName = "mo_note"
        Me.mo_note.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.mo_note.Name = "mo_note"
        Me.mo_note.OptionsColumn.AllowEdit = False
        Me.mo_note.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.mo_note.OptionsColumn.ReadOnly = True
        Me.mo_note.OptionsFilter.AllowFilter = False
        Me.mo_note.Visible = True
        Me.mo_note.VisibleIndex = 12
        '
        'mo_descr
        '
        Me.mo_descr.AppearanceCell.Options.UseBackColor = True
        Me.mo_descr.AppearanceCell.Options.UseTextOptions = True
        Me.mo_descr.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.mo_descr.Caption = "Titolo"
        Me.mo_descr.Enabled = False
        Me.mo_descr.FieldName = "mo_descr"
        Me.mo_descr.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.mo_descr.Name = "mo_descr"
        Me.mo_descr.OptionsColumn.AllowEdit = False
        Me.mo_descr.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.mo_descr.OptionsColumn.ReadOnly = True
        Me.mo_descr.OptionsFilter.AllowFilter = False
        Me.mo_descr.Visible = True
        Me.mo_descr.VisibleIndex = 13
        '
        'td_tipobf
        '
        Me.td_tipobf.AppearanceCell.Options.UseBackColor = True
        Me.td_tipobf.AppearanceCell.Options.UseTextOptions = True
        Me.td_tipobf.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.td_tipobf.Caption = "Tipo BF"
        Me.td_tipobf.Enabled = True
        Me.td_tipobf.FieldName = "td_tipobf"
        Me.td_tipobf.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.td_tipobf.Name = "td_tipobf"
        Me.td_tipobf.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.td_tipobf.OptionsFilter.AllowFilter = False
        '
        'NtsLabel1
        '
        Me.NtsLabel1.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel1.Location = New System.Drawing.Point(28, 2)
        Me.NtsLabel1.Name = "NtsLabel1"
        Me.NtsLabel1.Size = New System.Drawing.Size(85, 13)
        Me.NtsLabel1.Text = "Filtri di selezione"
        Me.NtsLabel1.UseMnemonic = False
        '
        'NtsPanelFiltri
        '
        Me.NtsPanelFiltri.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NtsPanelFiltri.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.NtsPanelFiltri.Appearance.Options.UseBackColor = True
        Me.NtsPanelFiltri.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.NtsPanelFiltri.Controls.Add(Me.cmdCPNEDuplica)
        Me.NtsPanelFiltri.Controls.Add(Me.cmdSeleziona)
        Me.NtsPanelFiltri.Controls.Add(Me.cmdAnnulla)
        Me.NtsPanelFiltri.Controls.Add(Me.cmdRicerca)
        Me.NtsPanelFiltri.Controls.Add(Me.NtsPanelFiltriDx)
        Me.NtsPanelFiltri.Controls.Add(Me.NtsPanelFiltriSx)
        Me.NtsPanelFiltri.Location = New System.Drawing.Point(9, 9)
        Me.NtsPanelFiltri.Name = "NtsPanelFiltri"
        Me.NtsPanelFiltri.Size = New System.Drawing.Size(576, 219)
        '
        'cmdCPNEDuplica
        '
        Me.cmdCPNEDuplica.Location = New System.Drawing.Point(131, 184)
        Me.cmdCPNEDuplica.Name = "cmdCPNEDuplica"
        Me.cmdCPNEDuplica.Size = New System.Drawing.Size(112, 23)
        Me.cmdCPNEDuplica.Text = "Duplica Documento"
        '
        'cmdSeleziona
        '
        Me.cmdSeleziona.Location = New System.Drawing.Point(4, 184)
        Me.cmdSeleziona.Name = "cmdSeleziona"
        Me.cmdSeleziona.Size = New System.Drawing.Size(100, 23)
        Me.cmdSeleziona.Text = "Apri Documento"
        '
        'cmdAnnulla
        '
        Me.cmdAnnulla.Location = New System.Drawing.Point(339, 184)
        Me.cmdAnnulla.Name = "cmdAnnulla"
        Me.cmdAnnulla.Size = New System.Drawing.Size(75, 23)
        Me.cmdAnnulla.Text = "Annulla"
        '
        'cmdRicerca
        '
        Me.cmdRicerca.Location = New System.Drawing.Point(501, 184)
        Me.cmdRicerca.Name = "cmdRicerca"
        Me.cmdRicerca.Size = New System.Drawing.Size(75, 23)
        Me.cmdRicerca.Text = "Ricerca"
        '
        'NtsPanelFiltriDx
        '
        Me.NtsPanelFiltriDx.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.NtsPanelFiltriDx.Appearance.Options.UseBackColor = True
        Me.NtsPanelFiltriDx.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.NtsPanelFiltriDx.Controls.Add(Me.edxx_descrtitolo)
        Me.NtsPanelFiltriDx.Controls.Add(Me.NtsLabel13)
        Me.NtsPanelFiltriDx.Controls.Add(Me.Cbxx_Tipo)
        Me.NtsPanelFiltriDx.Controls.Add(Me.Edxx_CodAgenA)
        Me.NtsPanelFiltriDx.Controls.Add(Me.Edxx_CodAgenDa)
        Me.NtsPanelFiltriDx.Controls.Add(Me.NtsLabel7)
        Me.NtsPanelFiltriDx.Controls.Add(Me.Edxx_AgenziaA)
        Me.NtsPanelFiltriDx.Controls.Add(Me.Edxx_AgenziaDa)
        Me.NtsPanelFiltriDx.Controls.Add(Me.edxx_ContoA)
        Me.NtsPanelFiltriDx.Controls.Add(Me.NtsLabel8)
        Me.NtsPanelFiltriDx.Controls.Add(Me.NtsLabel9)
        Me.NtsPanelFiltriDx.Controls.Add(Me.NtsLabel10)
        Me.NtsPanelFiltriDx.Controls.Add(Me.NtsLabel11)
        Me.NtsPanelFiltriDx.Controls.Add(Me.edxx_ContoDa)
        Me.NtsPanelFiltriDx.Controls.Add(Me.NtsLabel12)
        Me.NtsPanelFiltriDx.Location = New System.Drawing.Point(295, 10)
        Me.NtsPanelFiltriDx.Name = "NtsPanelFiltriDx"
        Me.NtsPanelFiltriDx.Size = New System.Drawing.Size(275, 156)
        '
        'Cbxx_Tipo
        '
        Me.Cbxx_Tipo.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cbxx_Tipo.Location = New System.Drawing.Point(101, 106)
        Me.Cbxx_Tipo.Name = "Cbxx_Tipo"
        Me.Cbxx_Tipo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Cbxx_Tipo.Properties.DropDownRows = 30
        Me.Cbxx_Tipo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.Cbxx_Tipo.Size = New System.Drawing.Size(166, 20)
        '
        'Edxx_CodAgenA
        '
        Me.Edxx_CodAgenA.Cursor = System.Windows.Forms.Cursors.Default
        Me.Edxx_CodAgenA.EditValue = "999"
        Me.Edxx_CodAgenA.Location = New System.Drawing.Point(177, 54)
        Me.Edxx_CodAgenA.Name = "Edxx_CodAgenA"
        Me.Edxx_CodAgenA.Properties.Appearance.Options.UseTextOptions = True
        Me.Edxx_CodAgenA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.Edxx_CodAgenA.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.Edxx_CodAgenA.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.Edxx_CodAgenA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Edxx_CodAgenA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Edxx_CodAgenA.Size = New System.Drawing.Size(90, 20)
        '
        'Edxx_CodAgenDa
        '
        Me.Edxx_CodAgenDa.Cursor = System.Windows.Forms.Cursors.Default
        Me.Edxx_CodAgenDa.EditValue = "0"
        Me.Edxx_CodAgenDa.Location = New System.Drawing.Point(81, 54)
        Me.Edxx_CodAgenDa.Name = "Edxx_CodAgenDa"
        Me.Edxx_CodAgenDa.Properties.Appearance.Options.UseTextOptions = True
        Me.Edxx_CodAgenDa.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.Edxx_CodAgenDa.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.Edxx_CodAgenDa.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.Edxx_CodAgenDa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Edxx_CodAgenDa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Edxx_CodAgenDa.Size = New System.Drawing.Size(92, 20)
        '
        'NtsLabel7
        '
        Me.NtsLabel7.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel7.Location = New System.Drawing.Point(177, 7)
        Me.NtsLabel7.Name = "NtsLabel7"
        Me.NtsLabel7.Size = New System.Drawing.Size(90, 17)
        Me.NtsLabel7.Text = "A"
        Me.NtsLabel7.UseMnemonic = False
        '
        'Edxx_AgenziaA
        '
        Me.Edxx_AgenziaA.Cursor = System.Windows.Forms.Cursors.Default
        Me.Edxx_AgenziaA.EditValue = "999"
        Me.Edxx_AgenziaA.Location = New System.Drawing.Point(177, 80)
        Me.Edxx_AgenziaA.Name = "Edxx_AgenziaA"
        Me.Edxx_AgenziaA.Properties.Appearance.Options.UseTextOptions = True
        Me.Edxx_AgenziaA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.Edxx_AgenziaA.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.Edxx_AgenziaA.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.Edxx_AgenziaA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Edxx_AgenziaA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Edxx_AgenziaA.Size = New System.Drawing.Size(90, 20)
        '
        'Edxx_AgenziaDa
        '
        Me.Edxx_AgenziaDa.Cursor = System.Windows.Forms.Cursors.Default
        Me.Edxx_AgenziaDa.EditValue = "0"
        Me.Edxx_AgenziaDa.Location = New System.Drawing.Point(81, 80)
        Me.Edxx_AgenziaDa.Name = "Edxx_AgenziaDa"
        Me.Edxx_AgenziaDa.Properties.Appearance.Options.UseTextOptions = True
        Me.Edxx_AgenziaDa.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.Edxx_AgenziaDa.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.Edxx_AgenziaDa.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.Edxx_AgenziaDa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Edxx_AgenziaDa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Edxx_AgenziaDa.Size = New System.Drawing.Size(90, 20)
        '
        'edxx_ContoA
        '
        Me.edxx_ContoA.Cursor = System.Windows.Forms.Cursors.Default
        Me.edxx_ContoA.EditValue = "99999999"
        Me.edxx_ContoA.Location = New System.Drawing.Point(177, 27)
        Me.edxx_ContoA.Name = "edxx_ContoA"
        Me.edxx_ContoA.Properties.Appearance.Options.UseTextOptions = True
        Me.edxx_ContoA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.edxx_ContoA.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.edxx_ContoA.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.edxx_ContoA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edxx_ContoA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edxx_ContoA.Size = New System.Drawing.Size(90, 20)
        '
        'NtsLabel8
        '
        Me.NtsLabel8.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel8.Location = New System.Drawing.Point(3, 30)
        Me.NtsLabel8.Name = "NtsLabel8"
        Me.NtsLabel8.Size = New System.Drawing.Size(72, 17)
        Me.NtsLabel8.Text = "Cliente"
        Me.NtsLabel8.UseMnemonic = False
        '
        'NtsLabel9
        '
        Me.NtsLabel9.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel9.Location = New System.Drawing.Point(5, 57)
        Me.NtsLabel9.Name = "NtsLabel9"
        Me.NtsLabel9.Size = New System.Drawing.Size(72, 17)
        Me.NtsLabel9.Text = "Agente"
        Me.NtsLabel9.UseMnemonic = False
        '
        'NtsLabel10
        '
        Me.NtsLabel10.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel10.Location = New System.Drawing.Point(3, 83)
        Me.NtsLabel10.Name = "NtsLabel10"
        Me.NtsLabel10.Size = New System.Drawing.Size(72, 17)
        Me.NtsLabel10.Text = "Agenzia"
        Me.NtsLabel10.UseMnemonic = False
        '
        'NtsLabel11
        '
        Me.NtsLabel11.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel11.Location = New System.Drawing.Point(3, 109)
        Me.NtsLabel11.Name = "NtsLabel11"
        Me.NtsLabel11.Size = New System.Drawing.Size(92, 17)
        Me.NtsLabel11.Text = "Seleziona Tipo"
        Me.NtsLabel11.UseMnemonic = False
        '
        'edxx_ContoDa
        '
        Me.edxx_ContoDa.Cursor = System.Windows.Forms.Cursors.Default
        Me.edxx_ContoDa.EditValue = "0"
        Me.edxx_ContoDa.Location = New System.Drawing.Point(81, 27)
        Me.edxx_ContoDa.Name = "edxx_ContoDa"
        Me.edxx_ContoDa.Properties.Appearance.Options.UseTextOptions = True
        Me.edxx_ContoDa.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.edxx_ContoDa.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.edxx_ContoDa.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.edxx_ContoDa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edxx_ContoDa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edxx_ContoDa.Size = New System.Drawing.Size(90, 20)
        '
        'NtsLabel12
        '
        Me.NtsLabel12.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel12.Location = New System.Drawing.Point(81, 7)
        Me.NtsLabel12.Name = "NtsLabel12"
        Me.NtsLabel12.Size = New System.Drawing.Size(90, 17)
        Me.NtsLabel12.Text = "Da"
        Me.NtsLabel12.UseMnemonic = False
        '
        'NtsPanelFiltriSx
        '
        Me.NtsPanelFiltriSx.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.NtsPanelFiltriSx.Appearance.Options.UseBackColor = True
        Me.NtsPanelFiltriSx.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.NtsPanelFiltriSx.Controls.Add(Me.Edxx_SerieA)
        Me.NtsPanelFiltriSx.Controls.Add(Me.Edxx_SerieDa)
        Me.NtsPanelFiltriSx.Controls.Add(Me.NtsLabel6)
        Me.NtsPanelFiltriSx.Controls.Add(Me.edxx_CommessaA)
        Me.NtsPanelFiltriSx.Controls.Add(Me.edxx_NumdocA)
        Me.NtsPanelFiltriSx.Controls.Add(Me.edxx_CommessaDa)
        Me.NtsPanelFiltriSx.Controls.Add(Me.edxx_NumdocDa)
        Me.NtsPanelFiltriSx.Controls.Add(Me.Edxx_AnnoA)
        Me.NtsPanelFiltriSx.Controls.Add(Me.NtsLabel5)
        Me.NtsPanelFiltriSx.Controls.Add(Me.NtsLabel4)
        Me.NtsPanelFiltriSx.Controls.Add(Me.NtsLabel3)
        Me.NtsPanelFiltriSx.Controls.Add(Me.NtsLabel2)
        Me.NtsPanelFiltriSx.Controls.Add(Me.Edxx_AnnoDa)
        Me.NtsPanelFiltriSx.Controls.Add(Me.lbFiltriSxDa)
        Me.NtsPanelFiltriSx.Location = New System.Drawing.Point(4, 10)
        Me.NtsPanelFiltriSx.Name = "NtsPanelFiltriSx"
        Me.NtsPanelFiltriSx.Size = New System.Drawing.Size(275, 156)
        '
        'Edxx_SerieA
        '
        Me.Edxx_SerieA.Cursor = System.Windows.Forms.Cursors.Default
        Me.Edxx_SerieA.Location = New System.Drawing.Point(177, 57)
        Me.Edxx_SerieA.Name = "Edxx_SerieA"
        Me.Edxx_SerieA.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.Edxx_SerieA.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.Edxx_SerieA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Edxx_SerieA.Properties.MaxLength = 65536
        Me.Edxx_SerieA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Edxx_SerieA.Size = New System.Drawing.Size(90, 20)
        '
        'Edxx_SerieDa
        '
        Me.Edxx_SerieDa.Cursor = System.Windows.Forms.Cursors.Default
        Me.Edxx_SerieDa.Location = New System.Drawing.Point(81, 57)
        Me.Edxx_SerieDa.Name = "Edxx_SerieDa"
        Me.Edxx_SerieDa.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.Edxx_SerieDa.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.Edxx_SerieDa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Edxx_SerieDa.Properties.MaxLength = 65536
        Me.Edxx_SerieDa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Edxx_SerieDa.Size = New System.Drawing.Size(90, 20)
        '
        'NtsLabel6
        '
        Me.NtsLabel6.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel6.Location = New System.Drawing.Point(177, 7)
        Me.NtsLabel6.Name = "NtsLabel6"
        Me.NtsLabel6.Size = New System.Drawing.Size(90, 17)
        Me.NtsLabel6.Text = "A"
        Me.NtsLabel6.UseMnemonic = False
        '
        'edxx_CommessaA
        '
        Me.edxx_CommessaA.Cursor = System.Windows.Forms.Cursors.Default
        Me.edxx_CommessaA.EditValue = "9999999999"
        Me.edxx_CommessaA.Location = New System.Drawing.Point(177, 117)
        Me.edxx_CommessaA.Name = "edxx_CommessaA"
        Me.edxx_CommessaA.Properties.Appearance.Options.UseTextOptions = True
        Me.edxx_CommessaA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.edxx_CommessaA.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.edxx_CommessaA.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.edxx_CommessaA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edxx_CommessaA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edxx_CommessaA.Size = New System.Drawing.Size(90, 20)
        '
        'edxx_NumdocA
        '
        Me.edxx_NumdocA.Cursor = System.Windows.Forms.Cursors.Default
        Me.edxx_NumdocA.EditValue = "999999"
        Me.edxx_NumdocA.Location = New System.Drawing.Point(177, 87)
        Me.edxx_NumdocA.Name = "edxx_NumdocA"
        Me.edxx_NumdocA.Properties.Appearance.Options.UseTextOptions = True
        Me.edxx_NumdocA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.edxx_NumdocA.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.edxx_NumdocA.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.edxx_NumdocA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edxx_NumdocA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edxx_NumdocA.Size = New System.Drawing.Size(90, 20)
        '
        'edxx_CommessaDa
        '
        Me.edxx_CommessaDa.Cursor = System.Windows.Forms.Cursors.Default
        Me.edxx_CommessaDa.EditValue = "0"
        Me.edxx_CommessaDa.Location = New System.Drawing.Point(81, 117)
        Me.edxx_CommessaDa.Name = "edxx_CommessaDa"
        Me.edxx_CommessaDa.Properties.Appearance.Options.UseTextOptions = True
        Me.edxx_CommessaDa.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.edxx_CommessaDa.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.edxx_CommessaDa.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.edxx_CommessaDa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edxx_CommessaDa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edxx_CommessaDa.Size = New System.Drawing.Size(90, 20)
        '
        'edxx_NumdocDa
        '
        Me.edxx_NumdocDa.Cursor = System.Windows.Forms.Cursors.Default
        Me.edxx_NumdocDa.EditValue = "0"
        Me.edxx_NumdocDa.Location = New System.Drawing.Point(81, 87)
        Me.edxx_NumdocDa.Name = "edxx_NumdocDa"
        Me.edxx_NumdocDa.Properties.Appearance.Options.UseTextOptions = True
        Me.edxx_NumdocDa.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.edxx_NumdocDa.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.edxx_NumdocDa.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.edxx_NumdocDa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edxx_NumdocDa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edxx_NumdocDa.Size = New System.Drawing.Size(90, 20)
        '
        'Edxx_AnnoA
        '
        Me.Edxx_AnnoA.Cursor = System.Windows.Forms.Cursors.Default
        Me.Edxx_AnnoA.EditValue = "2099"
        Me.Edxx_AnnoA.Location = New System.Drawing.Point(177, 27)
        Me.Edxx_AnnoA.Name = "Edxx_AnnoA"
        Me.Edxx_AnnoA.Properties.Appearance.Options.UseTextOptions = True
        Me.Edxx_AnnoA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.Edxx_AnnoA.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.Edxx_AnnoA.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.Edxx_AnnoA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Edxx_AnnoA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Edxx_AnnoA.Size = New System.Drawing.Size(90, 20)
        '
        'NtsLabel5
        '
        Me.NtsLabel5.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel5.Location = New System.Drawing.Point(3, 30)
        Me.NtsLabel5.Name = "NtsLabel5"
        Me.NtsLabel5.Size = New System.Drawing.Size(72, 17)
        Me.NtsLabel5.Text = "Anno"
        Me.NtsLabel5.UseMnemonic = False
        '
        'NtsLabel4
        '
        Me.NtsLabel4.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel4.Location = New System.Drawing.Point(3, 60)
        Me.NtsLabel4.Name = "NtsLabel4"
        Me.NtsLabel4.Size = New System.Drawing.Size(72, 17)
        Me.NtsLabel4.Text = "Serie"
        Me.NtsLabel4.UseMnemonic = False
        '
        'NtsLabel3
        '
        Me.NtsLabel3.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel3.Location = New System.Drawing.Point(3, 90)
        Me.NtsLabel3.Name = "NtsLabel3"
        Me.NtsLabel3.Size = New System.Drawing.Size(72, 17)
        Me.NtsLabel3.Text = "Numero"
        Me.NtsLabel3.UseMnemonic = False
        '
        'NtsLabel2
        '
        Me.NtsLabel2.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel2.Location = New System.Drawing.Point(3, 120)
        Me.NtsLabel2.Name = "NtsLabel2"
        Me.NtsLabel2.Size = New System.Drawing.Size(72, 17)
        Me.NtsLabel2.Text = "Commessa"
        Me.NtsLabel2.UseMnemonic = False
        '
        'Edxx_AnnoDa
        '
        Me.Edxx_AnnoDa.Cursor = System.Windows.Forms.Cursors.Default
        Me.Edxx_AnnoDa.EditValue = "0"
        Me.Edxx_AnnoDa.Location = New System.Drawing.Point(81, 27)
        Me.Edxx_AnnoDa.Name = "Edxx_AnnoDa"
        Me.Edxx_AnnoDa.Properties.Appearance.Options.UseTextOptions = True
        Me.Edxx_AnnoDa.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.Edxx_AnnoDa.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.Edxx_AnnoDa.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.Edxx_AnnoDa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Edxx_AnnoDa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Edxx_AnnoDa.Size = New System.Drawing.Size(90, 20)
        '
        'lbFiltriSxDa
        '
        Me.lbFiltriSxDa.BackColor = System.Drawing.Color.Transparent
        Me.lbFiltriSxDa.Location = New System.Drawing.Point(81, 7)
        Me.lbFiltriSxDa.Name = "lbFiltriSxDa"
        Me.lbFiltriSxDa.Size = New System.Drawing.Size(90, 17)
        Me.lbFiltriSxDa.Text = "Da"
        Me.lbFiltriSxDa.UseMnemonic = False
        '
        'PnCPNEPnMain
        '
        Me.PnCPNEPnMain.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PnCPNEPnMain.Appearance.Options.UseBackColor = True
        Me.PnCPNEPnMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PnCPNEPnMain.Controls.Add(Me.NtsPanelForm)
        Me.PnCPNEPnMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnCPNEPnMain.FreeLayout = True
        Me.PnCPNEPnMain.Location = New System.Drawing.Point(0, 0)
        Me.PnCPNEPnMain.Name = "PnCPNEPnMain"
        Me.PnCPNEPnMain.Size = New System.Drawing.Size(595, 498)
        '
        'NtsLabel13
        '
        Me.NtsLabel13.BackColor = System.Drawing.Color.Transparent
        Me.NtsLabel13.Location = New System.Drawing.Point(3, 137)
        Me.NtsLabel13.Name = "NtsLabel13"
        Me.NtsLabel13.Size = New System.Drawing.Size(92, 17)
        Me.NtsLabel13.Text = "Descr.Titolo"
        Me.NtsLabel13.UseMnemonic = False
        '
        'edxx_descrtitolo
        '
        Me.edxx_descrtitolo.EditValue = ""
        Me.edxx_descrtitolo.Location = New System.Drawing.Point(101, 136)
        Me.edxx_descrtitolo.Name = "edxx_descrtitolo"
        Me.edxx_descrtitolo.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.edxx_descrtitolo.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.edxx_descrtitolo.Properties.AutoHeight = False
        Me.edxx_descrtitolo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edxx_descrtitolo.Properties.MaxLength = 65536
        Me.edxx_descrtitolo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edxx_descrtitolo.Size = New System.Drawing.Size(166, 20)
        '
        'FrmRicerca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(595, 498)
        Me.Controls.Add(Me.PnCPNEPnMain)
        Me.Name = "FrmRicerca"
        Me.Text = "SELEZIONA PREVENTIVI / ORDINI"
        CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NtsPanelForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NtsPanelForm.ResumeLayout(False)
        CType(Me.NtsPanelGriglia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NtsPanelGriglia.ResumeLayout(False)
        CType(Me.grRigheOrdPre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvRigheOrdPre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NtsPanelFiltri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NtsPanelFiltri.ResumeLayout(False)
        CType(Me.NtsPanelFiltriDx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NtsPanelFiltriDx.ResumeLayout(False)
        CType(Me.Cbxx_Tipo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edxx_CodAgenA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edxx_CodAgenDa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edxx_AgenziaA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edxx_AgenziaDa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edxx_ContoA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edxx_ContoDa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NtsPanelFiltriSx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NtsPanelFiltriSx.ResumeLayout(False)
        CType(Me.Edxx_SerieA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edxx_SerieDa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edxx_CommessaA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edxx_NumdocA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edxx_CommessaDa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edxx_NumdocDa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edxx_AnnoA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Edxx_AnnoDa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnCPNEPnMain.ResumeLayout(False)
        CType(Me.edxx_descrtitolo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
    Private components As System.ComponentModel.IContainer
  Public oCleHh As CLFORGSOR
  Public dsHh As New DataSet
  Public dcHh As BindingSource = New BindingSource
  Public dcHhGr As BindingSource = New BindingSource
  Public dttOut As New DataTable
  Public oPar As CLE__CLDP
  Public CPNEbPassataDaSelPrev As Boolean
  Public bCPNEConferma As Boolean = False
  Public bCPNEDuplica As Boolean = False
  Public drCPNERigaSel As DataRow = Nothing
  Public StrForzaTipork As String = ""

    Public Overridable Sub Bindcontrols()
        Try
            '-------------------------------------------------
            'se i controlli erano già  stati precedentemente collegati, li scollego
            NTSFormClearDataBinding(Me)

            xx_sel.NTSSetParamCHK(oMenu, oApp.Tr(Me, 131231813727527021, "Seleziona"), "S", "N")
            grvRigheOrdPre.NTSSetParam(oMenu, oApp.Tr(Me, 131231728034646607, "grvRigheOrdPre"))
            Cbxx_Tipo.NTSDbField = "XXX.xx_tipo"
            Edxx_CodAgenA.NTSDbField = "XXX.xx_codagena"
            Edxx_CodAgenDa.NTSDbField = "XXX.xx_codagenda"
            Edxx_AgenziaA.NTSDbField = "XXX.xx_agenziaa"
            Edxx_AgenziaDa.NTSDbField = "XXX.xx_agenziada"
            edxx_ContoA.NTSDbField = "XXX.xx_contoa"
            edxx_ContoDa.NTSDbField = "XXX.xx_contoda"
            Edxx_SerieA.NTSDbField = "XXX.xx_seriea"
            Edxx_SerieDa.NTSDbField = "XXX.xx_serieda"
            edxx_NumdocA.NTSDbField = "XXX.xx_numdoca"
            edxx_NumdocDa.NTSDbField = "XXX.xx_numdocda"
            edxx_CommessaA.NTSDbField = "XXX.xx_commessaa"
            edxx_CommessaDa.NTSDbField = "XXX.xx_commessada"

            edxx_descrtitolo.NTSDbField = "XXX.xx_descrtitolo"

            Edxx_AnnoA.NTSDbField = "XXX.xx_annoa"
            Edxx_AnnoDa.NTSDbField = "XXX.xx_annoda"
            Cbxx_Tipo.NTSSetParam(oApp.Tr(Me, 131231728061426827, "Cbxx_Tipo"))
            Edxx_CodAgenA.NTSSetParamTabe(oMenu, oApp.Tr(Me, 131231728061431827, "Edxx_CodAgenA"), tabcage)
            Edxx_CodAgenDa.NTSSetParamTabe(oMenu, oApp.Tr(Me, 131231728061436830, "Edxx_CodAgenDa"), tabcage)
            Edxx_AgenziaA.NTSSetParamTabe(oMenu, oApp.Tr(Me, 131231728061446838, "Edxx_AgenziaA"), tabcage)
            Edxx_AgenziaDa.NTSSetParamTabe(oMenu, oApp.Tr(Me, 131231728061451841, "Edxx_AgenziaDa"), tabcage)
            edxx_ContoA.NTSSetParamTabe(oMenu, oApp.Tr(Me, 131231728061456845, "edxx_ContoA"), tabanagrac)
            edxx_ContoDa.NTSSetParamTabe(oMenu, oApp.Tr(Me, 131231728061481866, "edxx_ContoDa"), tabanagrac)
            Edxx_SerieA.NTSSetParam(oMenu, oApp.Tr(Me, 131231728061486866, "Edxx_SerieA"), 3)
            Edxx_SerieDa.NTSSetParam(oMenu, oApp.Tr(Me, 131231728061491870, "Edxx_SerieDa"), 3)
            edxx_CommessaA.NTSSetParam(oMenu, oApp.Tr(Me, 131231728061501873, "edxx_CommessaA"))
            edxx_NumdocA.NTSSetParam(oMenu, oApp.Tr(Me, 131231728061506880, "edxx_NumdocA"))
            edxx_CommessaDa.NTSSetParam(oMenu, oApp.Tr(Me, 131231728061511884, "edxx_CommessaDa"))

            edxx_descrtitolo.NTSSetParam(oMenu, oApp.Tr(Me, 131231728061511884, "edxx_descrtitolo"), 40, True)

            edxx_NumdocDa.NTSSetParam(oMenu, oApp.Tr(Me, 131231728061516890, "edxx_NumdocDa"))
            Edxx_AnnoA.NTSSetParam(oMenu, oApp.Tr(Me, 131231728061521891, "Edxx_AnnoA"))
            Edxx_AnnoDa.NTSSetParam(oMenu, oApp.Tr(Me, 131231728061547085, "Edxx_AnnoDa"))

            td_tipork.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131231810102904649, "Tipo"), 0, True)
            td_anno.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131231810102914749, "Anno"), "0", 4, 0, 9999)
            td_serie.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131231810102924762, "Serie"), 0, True)
            td_numord.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131231810102934763, "Numero"), "0", 9, 0, 999999999)
            td_datord.NTSSetParamDATA(oMenu, oApp.Tr(Me, 131231810102944773, "Data"), True)
            an_descr1.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131231810102954784, "Des.Cli."), 0, True)
            an_conto.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131231810102964781, "Cod.Cli."), "0", 9, 0, 999999999)
            mo_commeca.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131231810102974795, "Commessa"), "0", 9, 0, 999999999)
            td_codagen.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131231810102984805, "Agente"), "0", 4, 0, 9999)
            xx_agente.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131231810102994812, "Desc.Agente"), 0, True)
            td_codagen2.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131231810103004813, "Agenzia"), "0", 4, 0, 9999)
            xx_agenzia.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131231810103014823, "Desc.Agenzia"), 0, True)
            mo_note.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131231810103024830, "Note"), 0, True)
            mo_descr.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131231810103034840, "Titolo"), 0, True)


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
          Case "CPNE.AssociaOrdiniPrev"
            BindORDINIPREV()
          Case "CPNE.ENComm"
            If e.Message = "S" Then
              edxx_CommessaDa.Enabled = True
            Else
              edxx_CommessaDa.Enabled = False
            End If
            edxx_CommessaA.Enabled = edxx_CommessaDa.Enabled
        End Select
      End If
    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------
    End Try
  End Sub

  Private Sub FrmRicerca_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
TRY
    CType(oCleHh, CLFORGSOR).AssociaDs(dsHh)
    CType(oCleHh, CLFORGSOR).CaricaDsXXX()
    dsHh = CType(oCleHh, CLFORGSOR).DsZoomCPNE
    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = dsHh.Tables("XXX")
    AggGriglia()
    Bindcontrols()

    grvRigheOrdPre.NTSAllowInsert = False
    grvRigheOrdPre.NTSAllowDelete = False
    'grvRigheOrdPre.Enabled = False

    Me.Cbxx_Tipo.DataSource = CType(oCleHh, CLFORGSOR).DsZoomCPNE.Tables("CBTIPODOC")
    Me.Cbxx_Tipo.ValueMember = "codice"
    Me.Cbxx_Tipo.DisplayMember = "valore"

    'If CPNEbPassataDaSelPrev Then
    '  Cbxx_Tipo.Enabled = False

    'Else
    '  Cbxx_Tipo.Enabled = True
    'End If
    'If CType(oCleHh, CLFORGSOR).bCPNEDuplica Then
    '  Cbxx_Tipo.Enabled = False

    'Else
    '  Cbxx_Tipo.Enabled = True

    'End If

    GctlSetRoules()
    CType(oCleHh, CLFORGSOR).DsZoomCPNE.Tables("XXX").Rows(0)!xx_tipo = StrForzaTipork
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
    dcHhGr.DataSource = dsHh.Tables("RIGHEPREVORD")
    grRigheOrdPre.DataSource = dcHhGr
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub BindORDINIPREV()
TRY
    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = dsHh.Tables("RIGHEPREVORD")
    grRigheOrdPre.DataSource = dcHh
    NTSFormAddDataBinding(dcHh, Me)
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnulla.Click
TRY
    oPar.bPar1 = False
    dttOut = Nothing
    Me.Close()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

    'Private Sub cmdSeleziona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeleziona.Click
    'If dsHh Is Nothing Then Return
    '' riccardo 21-07-2017
    'If dsHh.Tables("RIGHEPREVORD") Is Nothing Then
    '  oApp.MsgBoxInfo("Attenzione! Selezionare una riga prima di premere apri !")
    '  Return
    'End If
    'If dsHh.Tables("RIGHEPREVORD").Rows.Count > 0 Then
    '  CPNEPreparaDati()
    '  oCleHh.bCPNEDuplica = False
    'Else
    '  oPar.bPar1 = False
    '  dttOut = Nothing
    'End If
    'Me.Close()
    ' End Sub


    Private Sub cmdRicerca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRicerca.Click
        Try
            ValidaLastControl()
            Cursor.Current = Cursors.WaitCursor
            oCleHh.CPNEApriGrigliaOrdiniPrev(edxx_descrtitolo.Text)
            'CType(oCleHh, CLFORGSOR).CPNEApriGrigliaOrdiniPrev()
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            '-------------------------------------------------
            CLN__STD.GestErr(ex, Me, "")
            '-------------------------------------------------
        End Try
    End Sub
    'Private Sub cmdCPNEDuplica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCPNEDuplica.Click

    '  Dim lNewProgr As Integer = 0
    '  Dim nNewAnno As Integer = 0
    '  Dim strNewSerie As String = ""
    '  Dim strNewTipork As String = ""
    '  Dim strSoloSerie As String = ""
    '  Dim dttTmp As New DataTable
    '  Dim frmOpen As FRMORSEOR = Nothing


    '  If dsHh Is Nothing Then Return
    '  If dsHh.Tables("RIGHEPREVORD").Rows.Count > 0 Then
    '    CPNEPreparaDati()
    '    oCleHh.bCPNEDuplica = True
    '  Else
    '    oPar.bPar1 = False
    '    dttOut = Nothing
    '  End If

    '  '''''=====================================================================================================

    '  ''''Try
    '  ''''  If oCleHh.bNew Then
    '  ''''    oApp.MsgBoxInfo(oApp.Tr(Me, 128602555183593750, "Il comando può essere utilizzato solo su documenti già salvati"))
    '  ''''    Return
    '  ''''  End If

    '  ''''  If oCleHh.bHasChangesET Then
    '  ''''    oApp.MsgBoxErr(oApp.Tr(Me, 128602622670156250, "Il documento ha subito delle modifiche dopo la sua apertura. Duplicazione non possibile"))
    '  ''''    Return
    '  ''''  End If

    '  ''''  '''''Esce se è in corso una modifica di un record
    '  ''''  Cursor = Cursors.WaitCursor
    '  ''''  'If Not oCleHh.RecordSalva(dcGsorRighe.Position, False, Nothing) Then Return
    '  ''''  Cursor = Cursors.Default

    '  ''''  '-----------------------------
    '  ''''  strSoloSerie = oMenu.GetSettingBusDitt(DittaCorrente, "Bsorgsor", "OpzioniDocUt", ".", "SoloSerie", "?", Cbxx_Tipo.SelectedValue.ToString(), "?")
    '  ''''  If strSoloSerie = "" Then strSoloSerie = " "

    '  ''''  '-----------------------------
    '  ''''  '''''''visualizzo la form
    '  ''''  'frmOpen = CType(NTSNewFormModal("FRMORSEOR"), FRMORSEOR)
    '  ''''  'frmOpen.Init(oMenu, Nothing, DittaCorrente, Nothing)
    '  ''''  'AddHandler oCleHh.RemoteEvent, AddressOf frmOpen.GestisciEventiEntity
    '  ''''  'frmOpen.oCleGsor = oCleGsor
    '  ''''  'frmOpen.Text = oApp.Tr(Me, 128776135797240000, "Estremi nuovo documento")
    '  ''''  'dttTmp = Cbxx_Tipo.DataSource.Clone
    '  ''''  'For Each dtrT As DataRow In CType(Cbxx_Tipo.DataSource, DataTable).Rows
    '  ''''  '  dttTmp.ImportRow(dtrT)
    '  ''''  'Next
    '  ''''  'frmOpen.cbTipo.DataSource = dttTmp
    '  ''''  'frmOpen.cbTipo.ValueMember = Cbxx_Tipo.ValueMember
    '  ''''  'frmOpen.cbTipo.DisplayMember = Cbxx_Tipo.DisplayMember
    '  ''''  'frmOpen.cbTipo.SelectedValue = Cbxx_Tipo.SelectedValue
    '  ''''  'frmOpen.cbTipo.Enabled = True

    '  ''''  'frmOpen.edAnno.Text = edAnnoDoc.Text
    '  ''''  'If strSoloSerie <> "?" Then
    '  ''''  '  frmOpen.edSerie.Text = strSoloSerie
    '  ''''  '  frmOpen.edSerie.Enabled = False
    '  ''''  'Else
    '  ''''  '  frmOpen.edSerie.Text = edSerieDoc.Text
    '  ''''  'End If
    '  ''''  'frmOpen.strTiporkOrig = cbTipoDoc.SelectedValue

    '  ''''  '--------------------------------------------
    '  ''''  '''''''propongo anno e serie dell'ultimo documento creato
    '  ''''  'frmOpen.edAnno.Text = oMenu.GetSettingBusDitt(DittaCorrente, "BNORGSOR", "Recent", ".", "LastDocNewAnno", frmOpen.edAnno.Text, " ", frmOpen.edAnno.Text)
    '  ''''  'frmOpen.edSerie.Text = oMenu.GetSettingBusDitt(DittaCorrente, "BNORGSOR", "Recent", ".", "LastDocNewSerie", frmOpen.edSerie.Text, " ", frmOpen.edSerie.Text).PadLeft(1)

    '  ''''  'frmOpen.ShowDialog()
    '  ''''  'RemoveHandler oCleHh.RemoteEvent, AddressOf frmOpen.GestisciEventiEntity

    '  ''''  ''''''ho selezionato annulla
    '  ''''  'If frmOpen.bOk = False Then Return

    '  ''''  'strNewTipork = frmOpen.cbTipo.SelectedValue
    '  ''''  'nNewAnno = NTSCInt(frmOpen.edAnno.Text)
    '  ''''  'strNewSerie = frmOpen.edSerie.Text.ToUpper
    '  ''''  'lNewProgr = NTSCInt(frmOpen.edNumero.Text)

    '  ''''  'If nNewAnno = 0 Then Return
    '  ''''  'If strNewSerie = "" Then Return
    '  ''''  'If lNewProgr = 0 Then Return

    '  ''''  'If strNewTipork = cbTipoDoc.SelectedValue And _
    '  ''''  '   lNewProgr = NTSCInt(oCleGsor.dttET.Rows(0)!et_numdoc) And _
    '  ''''  '   strNewSerie = NTSCStr(oCleGsor.dttET.Rows(0)!et_serie) And _
    '  ''''  '   nNewAnno = NTSCInt(oCleGsor.dttET.Rows(0)!et_anno) Then Return

    '  ''''  'Cursor = Cursors.WaitCursor

    '  ''''  '''''''inoltre se cambio tipork devo ricaricare anche la griglia ...
    '  ''''  '  If oCleGsor.dttET.Rows(0)!et_tipork.ToString <> strNewTipork Then
    '  ''''  '    GctlTipoDoc = strNewTipork
    '  ''''  '    GctlSetRoules()
    '  ''''  '    GestisciGrigliaTCO()
    '  ''''  '  End If

    '  ''''  '  If CType(frxorgsor.oCleGsor, CLFORGSOR).CPNEDuplicaDoc(strNewTipork, nNewAnno, strNewSerie, lNewProgr, NTSCInt(frmOpen.edConto.Text), NTSCInt(frmOpen.edTipoBf.Text)) Then
    '  ''''  '    frxorgsor.cbTipoDoc.SelectedValue = strNewTipork
    '  ''''  '    frxorgsor.edAnnoDoc.Text = nNewAnno.ToString
    '  ''''  '    frxorgsor.edSerieDoc.Text = strNewSerie
    '  ''''  '    frxorgsor.edNumDoc.Text = lNewProgr.ToString
    '  ''''  '    If frxorgsor.cbTipoDoc.SelectedValue.ToString = "Q" Then
    '  ''''  '      If frxorgsor.ckEt_flevas.Checked = False Then
    '  ''''  '        frxorgsor.GctlSetVisEnab(frxorgsor.ckEt_flevas, False)
    '  ''''  '      Else
    '  ''''  '        ckEt_flevas.Enabled = False
    '  ''''  '      End If
    '  ''''  '    Else
    '  ''''  '      ckEt_flevas.Enabled = False
    '  ''''  '    End If
    '  ''''  '    grvRighe.NTSMoveFirstRowColunn()
    '  ''''  '    tsGsor.SelectedTabPageIndex = 0
    '  ''''  '    GctlSetVisEnab(frxorgsor.tlbSalva, False)
    '  ''''  '    oCleGsor.bDocNonModificabile = False

    '  ''''  '    SetStato(1, False)

    '  ''''  '    oApp.MsgBoxInfo(oApp.Tr(Me, 128602591253906250, "Duplicazione documento terminata"))

    '  ''''Catch ex As Exception
    '  ''''  '-------------------------------------------------
    '  ''''  CLN__STD.GestErr(ex, Me, "")
    '  ''''  '-------------------------------------------------	
    '  ''''  'Ripristina()
    '  ''''Finally
    '  ''''  If Not frmOpen Is Nothing Then frmOpen.Dispose()
    '  ''''  frmOpen = Nothing
    '  ''''  Cursor = Cursors.Default
    '  ''''End Try

    '  ''''''===========================================================================================


    '  ' CType(oCleHh, CLFORGSOR).CPNEDuplicaDoc(dsHh.Tables("RIGHEPREVORD").Rows(0)!td_tipork.ToString, CInt(dsHh.Tables("RIGHEPREVORD").Rows(0)!td_anno), dsHh.Tables("RIGHEPREVORD").Rows(0)!td_serie.ToString, CInt(dsHh.Tables("RIGHEPREVORD").Rows(0)!td_numord), CInt(dsHh.Tables("RIGHEPREVORD").Rows(0)!an_conto), CInt(dsHh.Tables("RIGHEPREVORD").Rows(0)!td_tipobf))



    '  Me.Close()
    'End Sub
    Private Sub CPNEPreparaDati()
TRY
    oPar.bPar1 = True
    oPar.strPar2 = grvRigheOrdPre.GetFocusedRowCellValue(td_serie).ToString
    oPar.strPar4 = grvRigheOrdPre.GetFocusedRowCellValue(td_numord).ToString
    oPar.strPar3 = grvRigheOrdPre.GetFocusedRowCellValue(an_conto).ToString
    oPar.strPar5 = grvRigheOrdPre.GetFocusedRowCellValue(td_tipobf).ToString
    oPar.strPar1 = grvRigheOrdPre.GetFocusedRowCellValue(td_anno).ToString

    grvRigheOrdPre.NTSGetCurrentDataRow!xx_sel = "S"
    dsHh.Tables("RIGHEPREVORD").AcceptChanges()

    'memorizzo l'elenco dei documenti da aprire e lo restituisco a bsveboll
    dttOut = New DataTable
    dttOut.Columns.Add("td_tipork", GetType(String))
    dttOut.Columns.Add("td_anno", GetType(Integer))
    dttOut.Columns.Add("td_serie", GetType(String))
    dttOut.Columns.Add("td_numord", GetType(Integer))
    For Each dtrT As DataRow In dsHh.Tables("RIGHEPREVORD").Select("xx_sel = 'S'", "td_tipork, td_anno, td_serie, td_numord")
      dttOut.Rows.Add(New Object() {dtrT!td_tipork, dtrT!td_anno, dtrT!td_serie, dtrT!td_numord})
    Next
    dttOut.AcceptChanges()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub cmdCPNEDuplica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCPNEDuplica.Click
TRY
    If IsNothing(grvRigheOrdPre.NTSGetCurrentDataRow) Then
      oApp.MsgBoxInfo("Prima Seleziona la riga")
    Else
      bCPNEDuplica = True
      bCPNEConferma = True
      drCPNERigaSel = grvRigheOrdPre.NTSGetCurrentDataRow
      Me.Close()
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub cmdSeleziona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeleziona.Click
TRY
    If IsNothing(grvRigheOrdPre.NTSGetCurrentDataRow) Then
      oApp.MsgBoxInfo("Prima Seleziona la riga")
    Else
      bCPNEDuplica = False
      bCPNEConferma = True
      drCPNERigaSel = grvRigheOrdPre.NTSGetCurrentDataRow
      Me.Close()
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
End Class
