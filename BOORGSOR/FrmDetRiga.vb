Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Imports System.Windows.Forms

Public Class FrmDetRiga
  Private Moduli_P As Integer = bsModAll
  Private ModuliExt_P As Integer = bsModExtAll
  Private ModuliSup_P As Integer = 0
  Private ModuliSupExt_P As Integer = 0
  Private ModuliPtn_P As Integer = 0
  Private ModuliPtnExt_P As Integer = 0
  Public IntRiga As Integer = 0
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
      grvDetRiga.NTSSetParam(oMenu, oApp.Tr(Me, 130513526229865763, "dett.riga"))
      hh_rigass.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229875776, "Riga"), "0", 9, 0, 999999999)
      hh_descr.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526229885777, "Descrizione"), 0, True)
      hh_note2.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526229895787, "Note"), 0, True)
      hh_misura1.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229905794, "Base"), "#,##0.00", 15)
      hh_misura2.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229915801, "Altezza"), "#,##0.00", 15)
      hh_misura3.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229925808, "Misura 3"), "#,##0.000", 15)
      hh_colli.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229935803, "Colli"), "#,##0.00", 15)
      hh_quant.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229945807, "Quantità"), "#,##0.000", 15)
      hh_riga.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229955814, "RigaBolla"), "0", 9, 0, 999999999)
      hh_tipork.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526229965824, "Tipork"), 0, True)
      hh_anno.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229975828, "Anno"), "0", 4, 0, 9999)
      hh_serie.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526229985835, "Serie"), 0, True)
      hh_numdoc.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526230075902, "NumDoc"), "0", 9, 0, 999999999)
      codditt.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526230085903, "Codditt"), 0, True)
      hh_codartclifor.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526229965824, "CodArtCliFor"), 0, True)
      hh_tipoart.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526229965824, "TipoArt"), 0, True)
      hh_intest.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526229965824, "IntEst"), 0, True)
      'grvDetRiga.NTSSetParam(oMenu, oApp.Tr(Me, 129793264250461189, "q"))
      'hh_RigaSS.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793933587022637, "Riga"), "0", 9, 0, 999999999)
      'hh_Descr.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933587442679, "Descrizione"), 0, True)
      'hh_Note2.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933587442679, "Note"), 0, True)
      'hh_Misura1.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793940268722835, "Misura1"), "0", 9, 0, 999999999)
      'hh_Misura2.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793940268722835, "Misura2"), "0", 9, 0, 999999999)
      'hh_Misura3.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793940268722835, "Misura3"), "0", 9, 0, 999999999)
      'hh_Colli.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793940268722835, "Colli"), "0", 9, 0, 999999999)
      'hh_Quant.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793940268722835, "Quantità"), "0", 9, 0, 999999999)


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
    Dim strTmp() As String
    Dim i As Integer = 0
    If Not IsMyThrowRemoteEvent() Then Return 'il messaggio non è per questa form ...
    MyBase.GestisciEventiEntity(sender, e)
    Try
      If e.TipoEvento.Length < 10 Then Return
      strTmp = e.TipoEvento.Split(CType("|", Char))
      For i = 0 To strTmp.Length - 1
        Select Case strTmp(i).Substring(0, 10)
        End Select
      Next
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
  Public CPNERigaOrdine As Integer

  Private Sub FrmDetRiga_ActivatedFirst(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ActivatedFirst
TRY
    grvDetRiga.Columns("hh_riga").FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo("hh_riga = " & IntRiga.ToString)
    dsHh.Tables("CPNEdtDetRiga").Columns("hh_riga").DefaultValue = IntRiga.ToString
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub


  Private Sub FRMORGSOR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
TRY
    dsHh = oCleHh.dsShared
    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = dsHh.Tables("CPNEdtDetRiga")


    AggGriglia()
    Bindcontrols()
    'grvDetRiga.NTSAllowInsert = False
    grvDetRiga.NTSAllowDelete = False

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
    'If dsHh.Tables("CPNEdtDetRiga").Rows.Count > 0 Then
    '  DataTable table = GetDataTableResults();
    'Dim a As DataTable = dsHh.Tables("CPNEdtDetRiga").Select("hh_Riga =10").CopyToDataTable()
    'Dim ds As new DataSet = CPNEdtDetRigaClone
    ' ds.Merge(dsHh.Tables("CPNEdtDetRiga").Select("hh_Riga =10"))
    ' copy.Merge(myDataTable.Select("Foo='Bar'"));
    'dcHhgr.DataSource = ds.Tables(0)
    'Dim aa As DataRow() = dsHh.Tables("CPNEdtDetRiga").Select("hh_Riga =10")
    'dcHhgr.DataSource = aa
    'dcHhgr.DataSource = dsHh.Tables("CPNEdtDetRiga").Select("hh_Riga =10")
    'Else
    dcHhgr.DataSource = dsHh.Tables("CPNEdtDetRiga")
    'Dim x As NTSGridView = New NTSGridView()
    'Dim grvdetriga2 As NTSGridView = grvDetRiga
    'grvdetriga2.SelectRow = "hh_Riga = 10"
    'grDetRiga.MainView = x

    'End If

    grDetRiga.DataSource = dcHhgr
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Public Sub InitializeComponent()
    Me.grDetRiga = New NTSInformatica.NTSGrid()
    Me.grvDetRiga = New NTSInformatica.NTSGridView()
    Me.hh_rigass = New NTSInformatica.NTSGridColumn()
    Me.hh_descr = New NTSInformatica.NTSGridColumn()
    Me.hh_note2 = New NTSInformatica.NTSGridColumn()
    Me.hh_misura1 = New NTSInformatica.NTSGridColumn()
    Me.hh_misura2 = New NTSInformatica.NTSGridColumn()
    Me.hh_misura3 = New NTSInformatica.NTSGridColumn()
    Me.hh_colli = New NTSInformatica.NTSGridColumn()
    Me.hh_quant = New NTSInformatica.NTSGridColumn()
    Me.hh_riga = New NTSInformatica.NTSGridColumn()
    Me.hh_tipork = New NTSInformatica.NTSGridColumn()
    Me.hh_anno = New NTSInformatica.NTSGridColumn()
    Me.hh_serie = New NTSInformatica.NTSGridColumn()
    Me.hh_numdoc = New NTSInformatica.NTSGridColumn()
    Me.codditt = New NTSInformatica.NTSGridColumn()
    Me.hh_codartclifor = New NTSInformatica.NTSGridColumn()
    Me.hh_tipoart = New NTSInformatica.NTSGridColumn()
    Me.hh_intest = New NTSInformatica.NTSGridColumn()
    CType(Me.grDetRiga, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grvDetRiga, System.ComponentModel.ISupportInitialize).BeginInit()
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
    'grDetRiga
    '
    Me.grDetRiga.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    '
    '
    '
    Me.grDetRiga.EmbeddedNavigator.Name = ""
    Me.grDetRiga.Location = New System.Drawing.Point(2, 1)
    Me.grDetRiga.MainView = Me.grvDetRiga
    Me.grDetRiga.Name = "grDetRiga"
    Me.grDetRiga.Size = New System.Drawing.Size(579, 216)
    Me.grDetRiga.TabIndex = 0
    Me.grDetRiga.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvDetRiga})
    '
    'grvDetRiga
    '
    Me.grvDetRiga.ActiveFilterEnabled = False
    Me.grvDetRiga.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.hh_rigass, Me.hh_descr, Me.hh_note2, Me.hh_misura1, Me.hh_misura2, Me.hh_misura3, Me.hh_colli, Me.hh_quant, Me.hh_riga, Me.hh_tipork, Me.hh_anno, Me.hh_serie, Me.hh_numdoc, Me.codditt, Me.hh_codartclifor, Me.hh_tipoart, Me.hh_intest})
    Me.grvDetRiga.Enabled = True
    Me.grvDetRiga.GridControl = Me.grDetRiga
    Me.grvDetRiga.Name = "grvDetRiga"
    Me.grvDetRiga.NTSAllowDelete = True
    Me.grvDetRiga.NTSAllowInsert = True
    Me.grvDetRiga.NTSAllowUpdate = True
    Me.grvDetRiga.NTSMenuContext = Nothing
    Me.grvDetRiga.OptionsCustomization.AllowRowSizing = True
    Me.grvDetRiga.OptionsFilter.AllowFilterEditor = False
    Me.grvDetRiga.OptionsNavigation.EnterMoveNextColumn = True
    Me.grvDetRiga.OptionsNavigation.UseTabKey = False
    Me.grvDetRiga.OptionsSelection.EnableAppearanceFocusedRow = False
    Me.grvDetRiga.OptionsView.ColumnAutoWidth = False
    Me.grvDetRiga.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
    Me.grvDetRiga.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
    Me.grvDetRiga.OptionsView.ShowGroupPanel = False
    Me.grvDetRiga.RowHeight = 14
    '
    'hh_rigass
    '
    Me.hh_rigass.AppearanceCell.Options.UseBackColor = True
    Me.hh_rigass.AppearanceCell.Options.UseTextOptions = True
    Me.hh_rigass.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_rigass.Caption = "Riga"
    Me.hh_rigass.Enabled = False
    Me.hh_rigass.FieldName = "hh_rigass"
    Me.hh_rigass.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_rigass.Name = "hh_rigass"
    Me.hh_rigass.NTSRepositoryComboBox = Nothing
    Me.hh_rigass.NTSRepositoryItemCheck = Nothing
    Me.hh_rigass.NTSRepositoryItemMemo = Nothing
    Me.hh_rigass.NTSRepositoryItemText = Nothing
    Me.hh_rigass.OptionsColumn.AllowEdit = False
    Me.hh_rigass.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_rigass.OptionsColumn.ReadOnly = True
    Me.hh_rigass.OptionsFilter.AllowFilter = False
    Me.hh_rigass.Visible = True
    Me.hh_rigass.VisibleIndex = 0
    '
    'hh_descr
    '
    Me.hh_descr.AppearanceCell.Options.UseBackColor = True
    Me.hh_descr.AppearanceCell.Options.UseTextOptions = True
    Me.hh_descr.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_descr.Caption = "Descrizione"
    Me.hh_descr.Enabled = False
    Me.hh_descr.FieldName = "hh_descr"
    Me.hh_descr.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_descr.Name = "hh_descr"
    Me.hh_descr.NTSRepositoryComboBox = Nothing
    Me.hh_descr.NTSRepositoryItemCheck = Nothing
    Me.hh_descr.NTSRepositoryItemMemo = Nothing
    Me.hh_descr.NTSRepositoryItemText = Nothing
    Me.hh_descr.OptionsColumn.AllowEdit = False
    Me.hh_descr.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_descr.OptionsColumn.ReadOnly = True
    Me.hh_descr.OptionsFilter.AllowFilter = False
    Me.hh_descr.Visible = True
    Me.hh_descr.VisibleIndex = 1
    '
    'hh_note2
    '
    Me.hh_note2.AppearanceCell.Options.UseBackColor = True
    Me.hh_note2.AppearanceCell.Options.UseTextOptions = True
    Me.hh_note2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_note2.Caption = "Note"
    Me.hh_note2.Enabled = False
    Me.hh_note2.FieldName = "hh_note2"
    Me.hh_note2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_note2.Name = "hh_note2"
    Me.hh_note2.NTSRepositoryComboBox = Nothing
    Me.hh_note2.NTSRepositoryItemCheck = Nothing
    Me.hh_note2.NTSRepositoryItemMemo = Nothing
    Me.hh_note2.NTSRepositoryItemText = Nothing
    Me.hh_note2.OptionsColumn.AllowEdit = False
    Me.hh_note2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_note2.OptionsColumn.ReadOnly = True
    Me.hh_note2.OptionsFilter.AllowFilter = False
    Me.hh_note2.Visible = True
    Me.hh_note2.VisibleIndex = 2
    '
    'hh_misura1
    '
    Me.hh_misura1.AppearanceCell.Options.UseBackColor = True
    Me.hh_misura1.AppearanceCell.Options.UseTextOptions = True
    Me.hh_misura1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_misura1.Caption = "Base"
    Me.hh_misura1.Enabled = False
    Me.hh_misura1.FieldName = "hh_misura1"
    Me.hh_misura1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_misura1.Name = "hh_misura1"
    Me.hh_misura1.NTSRepositoryComboBox = Nothing
    Me.hh_misura1.NTSRepositoryItemCheck = Nothing
    Me.hh_misura1.NTSRepositoryItemMemo = Nothing
    Me.hh_misura1.NTSRepositoryItemText = Nothing
    Me.hh_misura1.OptionsColumn.AllowEdit = False
    Me.hh_misura1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_misura1.OptionsColumn.ReadOnly = True
    Me.hh_misura1.OptionsFilter.AllowFilter = False
    Me.hh_misura1.Visible = True
    Me.hh_misura1.VisibleIndex = 3
    '
    'hh_misura2
    '
    Me.hh_misura2.AppearanceCell.Options.UseBackColor = True
    Me.hh_misura2.AppearanceCell.Options.UseTextOptions = True
    Me.hh_misura2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_misura2.Caption = "Altezza"
    Me.hh_misura2.Enabled = False
    Me.hh_misura2.FieldName = "hh_misura2"
    Me.hh_misura2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_misura2.Name = "hh_misura2"
    Me.hh_misura2.NTSRepositoryComboBox = Nothing
    Me.hh_misura2.NTSRepositoryItemCheck = Nothing
    Me.hh_misura2.NTSRepositoryItemMemo = Nothing
    Me.hh_misura2.NTSRepositoryItemText = Nothing
    Me.hh_misura2.OptionsColumn.AllowEdit = False
    Me.hh_misura2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_misura2.OptionsColumn.ReadOnly = True
    Me.hh_misura2.OptionsFilter.AllowFilter = False
    Me.hh_misura2.Visible = True
    Me.hh_misura2.VisibleIndex = 4
    '
    'hh_misura3
    '
    Me.hh_misura3.AppearanceCell.Options.UseBackColor = True
    Me.hh_misura3.AppearanceCell.Options.UseTextOptions = True
    Me.hh_misura3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_misura3.Caption = "Misura 3"
    Me.hh_misura3.Enabled = False
    Me.hh_misura3.FieldName = "hh_misura3"
    Me.hh_misura3.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_misura3.Name = "hh_misura3"
    Me.hh_misura3.NTSRepositoryComboBox = Nothing
    Me.hh_misura3.NTSRepositoryItemCheck = Nothing
    Me.hh_misura3.NTSRepositoryItemMemo = Nothing
    Me.hh_misura3.NTSRepositoryItemText = Nothing
    Me.hh_misura3.OptionsColumn.AllowEdit = False
    Me.hh_misura3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_misura3.OptionsColumn.ReadOnly = True
    Me.hh_misura3.OptionsFilter.AllowFilter = False
    Me.hh_misura3.Visible = True
    Me.hh_misura3.VisibleIndex = 5
    '
    'hh_colli
    '
    Me.hh_colli.AppearanceCell.Options.UseBackColor = True
    Me.hh_colli.AppearanceCell.Options.UseTextOptions = True
    Me.hh_colli.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_colli.Caption = "Colli"
    Me.hh_colli.Enabled = False
    Me.hh_colli.FieldName = "hh_coll"
    Me.hh_colli.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_colli.Name = "hh_colli"
    Me.hh_colli.NTSRepositoryComboBox = Nothing
    Me.hh_colli.NTSRepositoryItemCheck = Nothing
    Me.hh_colli.NTSRepositoryItemMemo = Nothing
    Me.hh_colli.NTSRepositoryItemText = Nothing
    Me.hh_colli.OptionsColumn.AllowEdit = False
    Me.hh_colli.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_colli.OptionsColumn.ReadOnly = True
    Me.hh_colli.OptionsFilter.AllowFilter = False
    Me.hh_colli.Visible = True
    Me.hh_colli.VisibleIndex = 6
    '
    'hh_quant
    '
    Me.hh_quant.AppearanceCell.Options.UseBackColor = True
    Me.hh_quant.AppearanceCell.Options.UseTextOptions = True
    Me.hh_quant.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_quant.Caption = "Quantità"
    Me.hh_quant.Enabled = True
    Me.hh_quant.FieldName = "hh_quant"
    Me.hh_quant.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_quant.Name = "hh_quant"
    Me.hh_quant.NTSRepositoryComboBox = Nothing
    Me.hh_quant.NTSRepositoryItemCheck = Nothing
    Me.hh_quant.NTSRepositoryItemMemo = Nothing
    Me.hh_quant.NTSRepositoryItemText = Nothing
    Me.hh_quant.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_quant.OptionsFilter.AllowFilter = False
    Me.hh_quant.Visible = True
    Me.hh_quant.VisibleIndex = 7
    '
    'hh_riga
    '
    Me.hh_riga.AppearanceCell.Options.UseBackColor = True
    Me.hh_riga.AppearanceCell.Options.UseTextOptions = True
    Me.hh_riga.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_riga.Caption = "RigaBolla"
    Me.hh_riga.Enabled = False
    Me.hh_riga.FieldName = "hh_riga"
    Me.hh_riga.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_riga.Name = "hh_riga"
    Me.hh_riga.NTSRepositoryComboBox = Nothing
    Me.hh_riga.NTSRepositoryItemCheck = Nothing
    Me.hh_riga.NTSRepositoryItemMemo = Nothing
    Me.hh_riga.NTSRepositoryItemText = Nothing
    Me.hh_riga.OptionsColumn.AllowEdit = False
    Me.hh_riga.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_riga.OptionsColumn.ReadOnly = True
    Me.hh_riga.OptionsFilter.AllowFilter = False
    '
    'hh_tipork
    '
    Me.hh_tipork.AppearanceCell.Options.UseBackColor = True
    Me.hh_tipork.AppearanceCell.Options.UseTextOptions = True
    Me.hh_tipork.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_tipork.Caption = "Tipork"
    Me.hh_tipork.Enabled = False
    Me.hh_tipork.FieldName = "hh_tipork"
    Me.hh_tipork.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_tipork.Name = "hh_tipork"
    Me.hh_tipork.NTSRepositoryComboBox = Nothing
    Me.hh_tipork.NTSRepositoryItemCheck = Nothing
    Me.hh_tipork.NTSRepositoryItemMemo = Nothing
    Me.hh_tipork.NTSRepositoryItemText = Nothing
    Me.hh_tipork.OptionsColumn.AllowEdit = False
    Me.hh_tipork.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_tipork.OptionsColumn.ReadOnly = True
    Me.hh_tipork.OptionsFilter.AllowFilter = False
    '
    'hh_anno
    '
    Me.hh_anno.AppearanceCell.Options.UseBackColor = True
    Me.hh_anno.AppearanceCell.Options.UseTextOptions = True
    Me.hh_anno.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_anno.Caption = "Anno"
    Me.hh_anno.Enabled = False
    Me.hh_anno.FieldName = "hh_anno"
    Me.hh_anno.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_anno.Name = "hh_anno"
    Me.hh_anno.NTSRepositoryComboBox = Nothing
    Me.hh_anno.NTSRepositoryItemCheck = Nothing
    Me.hh_anno.NTSRepositoryItemMemo = Nothing
    Me.hh_anno.NTSRepositoryItemText = Nothing
    Me.hh_anno.OptionsColumn.AllowEdit = False
    Me.hh_anno.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_anno.OptionsColumn.ReadOnly = True
    Me.hh_anno.OptionsFilter.AllowFilter = False
    '
    'hh_serie
    '
    Me.hh_serie.AppearanceCell.Options.UseBackColor = True
    Me.hh_serie.AppearanceCell.Options.UseTextOptions = True
    Me.hh_serie.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_serie.Caption = "Serie"
    Me.hh_serie.Enabled = False
    Me.hh_serie.FieldName = "hh_serie"
    Me.hh_serie.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_serie.Name = "hh_serie"
    Me.hh_serie.NTSRepositoryComboBox = Nothing
    Me.hh_serie.NTSRepositoryItemCheck = Nothing
    Me.hh_serie.NTSRepositoryItemMemo = Nothing
    Me.hh_serie.NTSRepositoryItemText = Nothing
    Me.hh_serie.OptionsColumn.AllowEdit = False
    Me.hh_serie.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_serie.OptionsColumn.ReadOnly = True
    Me.hh_serie.OptionsFilter.AllowFilter = False
    '
    'hh_numdoc
    '
    Me.hh_numdoc.AppearanceCell.Options.UseBackColor = True
    Me.hh_numdoc.AppearanceCell.Options.UseTextOptions = True
    Me.hh_numdoc.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_numdoc.Caption = "NumDoc"
    Me.hh_numdoc.Enabled = False
    Me.hh_numdoc.FieldName = "hh_numdoc"
    Me.hh_numdoc.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_numdoc.Name = "hh_numdoc"
    Me.hh_numdoc.NTSRepositoryComboBox = Nothing
    Me.hh_numdoc.NTSRepositoryItemCheck = Nothing
    Me.hh_numdoc.NTSRepositoryItemMemo = Nothing
    Me.hh_numdoc.NTSRepositoryItemText = Nothing
    Me.hh_numdoc.OptionsColumn.AllowEdit = False
    Me.hh_numdoc.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_numdoc.OptionsColumn.ReadOnly = True
    Me.hh_numdoc.OptionsFilter.AllowFilter = False
    '
    'codditt
    '
    Me.codditt.AppearanceCell.Options.UseBackColor = True
    Me.codditt.AppearanceCell.Options.UseTextOptions = True
    Me.codditt.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.codditt.Caption = "Codditt"
    Me.codditt.Enabled = False
    Me.codditt.FieldName = "codditt"
    Me.codditt.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.codditt.Name = "codditt"
    Me.codditt.NTSRepositoryComboBox = Nothing
    Me.codditt.NTSRepositoryItemCheck = Nothing
    Me.codditt.NTSRepositoryItemMemo = Nothing
    Me.codditt.NTSRepositoryItemText = Nothing
    Me.codditt.OptionsColumn.AllowEdit = False
    Me.codditt.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.codditt.OptionsColumn.ReadOnly = True
    Me.codditt.OptionsFilter.AllowFilter = False
    '
    'hh_codartclifor
    '
    Me.hh_codartclifor.AppearanceCell.Options.UseBackColor = True
    Me.hh_codartclifor.AppearanceCell.Options.UseTextOptions = True
    Me.hh_codartclifor.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_codartclifor.Caption = "Codice Articolo"
    Me.hh_codartclifor.Enabled = False
    Me.hh_codartclifor.FieldName = "hh_codartclifor"
    Me.hh_codartclifor.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_codartclifor.Name = "hh_codartclifor"
    Me.hh_codartclifor.NTSRepositoryComboBox = Nothing
    Me.hh_codartclifor.NTSRepositoryItemCheck = Nothing
    Me.hh_codartclifor.NTSRepositoryItemMemo = Nothing
    Me.hh_codartclifor.NTSRepositoryItemText = Nothing
    Me.hh_codartclifor.OptionsColumn.AllowEdit = False
    Me.hh_codartclifor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_codartclifor.OptionsColumn.ReadOnly = True
    Me.hh_codartclifor.OptionsFilter.AllowFilter = False
    Me.hh_codartclifor.Visible = True
    Me.hh_codartclifor.VisibleIndex = 8
    '
    'hh_tipoart
    '
    Me.hh_tipoart.AppearanceCell.Options.UseBackColor = True
    Me.hh_tipoart.AppearanceCell.Options.UseTextOptions = True
    Me.hh_tipoart.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_tipoart.Caption = "Tipo Articolo"
    Me.hh_tipoart.Enabled = False
    Me.hh_tipoart.FieldName = "hh_tipoart"
    Me.hh_tipoart.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_tipoart.Name = "hh_tipoart"
    Me.hh_tipoart.NTSRepositoryComboBox = Nothing
    Me.hh_tipoart.NTSRepositoryItemCheck = Nothing
    Me.hh_tipoart.NTSRepositoryItemMemo = Nothing
    Me.hh_tipoart.NTSRepositoryItemText = Nothing
    Me.hh_tipoart.OptionsColumn.AllowEdit = False
    Me.hh_tipoart.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_tipoart.OptionsColumn.ReadOnly = True
    Me.hh_tipoart.OptionsFilter.AllowFilter = False
    Me.hh_tipoart.Visible = True
    Me.hh_tipoart.VisibleIndex = 9
    '
    'hh_intest
    '
    Me.hh_intest.AppearanceCell.Options.UseBackColor = True
    Me.hh_intest.AppearanceCell.Options.UseTextOptions = True
    Me.hh_intest.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_intest.Caption = "Int / Est"
    Me.hh_intest.Enabled = True
    Me.hh_intest.FieldName = "hh_intest"
    Me.hh_intest.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_intest.Name = "hh_intest"
    Me.hh_intest.NTSRepositoryComboBox = Nothing
    Me.hh_intest.NTSRepositoryItemCheck = Nothing
    Me.hh_intest.NTSRepositoryItemMemo = Nothing
    Me.hh_intest.NTSRepositoryItemText = Nothing
    Me.hh_intest.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_intest.OptionsFilter.AllowFilter = False
    Me.hh_intest.Visible = True
    Me.hh_intest.VisibleIndex = 10
    '
    'FrmDetRiga
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
    Me.PnCPNEPnMain.Controls.Add(Me.grDetRiga)
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FrmDetRiga"
    Me.Text = "DETTAGLIO RIGA"
    CType(Me.grDetRiga, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grvDetRiga, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).EndInit()
Me.PnCPNEPnMain.ResumeLayout(False)
Me.ResumeLayout(False)

  End Sub
  Private Sub CmdEsci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
TRY
    Dim DR As DataRow()
    DR = dsHh.Tables("CPNEdtDetRiga").Select("hh_riga>=0")
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
  
  
  
  Private Sub grvDetRiga_NTSBeforeRowUpdate(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles grvDetRiga.NTSBeforeRowUpdate, grvDetRiga.NTSBeforeRowUpdate, grvDetRiga.NTSBeforeRowUpdate
TRY
    If CType(oCleHh, CLBORGSOR).CPNEValidaGriCPNEDetRiga(dcHhgr.Position) Then
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

  Private Sub grvDetRiga_NTSNewRow(sender As Object, e As System.EventArgs) Handles grvDetRiga.NTSNewRow
TRY

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub grDetRiga_Click(sender As System.Object, e As System.EventArgs) Handles grDetRiga.Click
TRY

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
End Class
