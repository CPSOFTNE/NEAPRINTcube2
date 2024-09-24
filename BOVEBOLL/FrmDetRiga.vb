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
      hh_RigaSS.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229875776, "Riga"), "0", 9, 0, 999999999)
      hh_Descr.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526229885777, "Descrizione"), 0, True)
      hh_Note2.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526229895787, "Note"), 0, True)
      hh_Misura1.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229905794, "Base"), "#,##0.00", 15)
      hh_Misura2.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229915801, "Altezza"), "#,##0.00", 15)
      hh_Misura3.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229925808, "Misura 3"), "#,##0.00", 15)
      hh_Colli.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229935803, "Colli"), "#,##0.00", 15)
      hh_Quant.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229945807, "Quantità"), "#,##0.00", 15)
      hh_Riga.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229955814, "RigaBolla"), "0", 9, 0, 999999999)
      hh_Tipork.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526229965824, "Tipork"), 0, True)
      hh_anno.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526229975828, "Anno"), "0", 4, 0, 9999)
      hh_serie.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526229985835, "Serie"), 0, True)
      hh_numdoc.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130513526230075902, "NumDoc"), "0", 9, 0, 999999999)
      codditt.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130513526230085903, "Codditt"), 0, True)
      'grvDetRiga.NTSSetParam(oMenu, oApp.Tr(Me, 129793264250461189, "q"))
      'hh_RigaSS.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793933587022637, "Riga"), "0", 9, 0, 999999999)
      'hh_Descr.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933587442679, "Descrizione"), 0, True)
      'hh_Note2.NTSSetParamSTR(oMenu, oApp.Tr(Me, 129793933587442679, "Note"), 0, True)
      'hh_Misura1.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793940268722835, "Misura1"), "0", 9, 0, 999999999)
      'hh_Misura2.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793940268722835, "Misura2"), "0", 9, 0, 999999999)
      'hh_Misura3.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793940268722835, "Misura3"), "0", 9, 0, 999999999)
      'hh_Colli.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793940268722835, "Colli"), "0", 9, 0, 999999999)
      'hh_Quant.NTSSetParamNUM(oMenu, oApp.Tr(Me, 129793940268722835, "Quantità"), "0", 9, 0, 999999999)
      'hh_codart.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131968873566002097, "codArt"), 0, True)
      'hh_codartclifor.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131968873566158394, "Codice Articolo"), 0, True)
      'hh_prezzo.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131968873566314633, "Prezzo"), "#,##0.00", 15)


      NTSFormAddDataBinding(dcHh, Me)
      GctlSetRoules()

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
  Public oCleHh As CLBVEBOLL
  Public dsHh As New DataSet
  Public oCallParams As CLE__CLDP
  Public dcHh As BindingSource = New BindingSource
  Public dcHhgr As BindingSource = New BindingSource
  Public CPNERigaOrdine As Integer

  Private Sub FrmDetRiga_ActivatedFirst(sender As Object, e As System.EventArgs) Handles Me.ActivatedFirst
TRY
    grvDetRiga.Columns("hh_riga").FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo("hh_riga = " & IntRiga.ToString)
    dsHh.Tables("CPNEdtDetRiga").Columns("hh_riga").DefaultValue = IntRiga.ToString
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub


  Private Sub FRMVEBOLL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    Me.hh_RigaSS = New NTSInformatica.NTSGridColumn()
    Me.hh_Descr = New NTSInformatica.NTSGridColumn()
    Me.hh_Note2 = New NTSInformatica.NTSGridColumn()
    Me.hh_Misura1 = New NTSInformatica.NTSGridColumn()
    Me.hh_Misura2 = New NTSInformatica.NTSGridColumn()
    Me.hh_Misura3 = New NTSInformatica.NTSGridColumn()
    Me.hh_Colli = New NTSInformatica.NTSGridColumn()
    Me.hh_Quant = New NTSInformatica.NTSGridColumn()
    Me.hh_Riga = New NTSInformatica.NTSGridColumn()
    Me.hh_Tipork = New NTSInformatica.NTSGridColumn()
    Me.hh_anno = New NTSInformatica.NTSGridColumn()
    Me.hh_serie = New NTSInformatica.NTSGridColumn()
    Me.hh_numdoc = New NTSInformatica.NTSGridColumn()
    Me.codditt = New NTSInformatica.NTSGridColumn()
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.grvDetRiga.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.hh_RigaSS, Me.hh_Descr, Me.hh_Note2, Me.hh_Misura1, Me.hh_Misura2, Me.hh_Misura3, Me.hh_Colli, Me.hh_Quant, Me.hh_Riga, Me.hh_Tipork, Me.hh_anno, Me.hh_serie, Me.hh_numdoc, Me.codditt})
    Me.grvDetRiga.Enabled = True
    Me.grvDetRiga.GridControl = Me.grDetRiga
    Me.grvDetRiga.MaxRowHeight = 9999
    Me.grvDetRiga.MinRowHeight = 14
    Me.grvDetRiga.Name = "grvDetRiga"
    Me.grvDetRiga.NTSAllowDelete = True
    Me.grvDetRiga.NTSAllowInsert = True
    Me.grvDetRiga.NTSAllowUpdate = True
    Me.grvDetRiga.NTSForceShowGroupPanel = -9
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
    'hh_RigaSS
    '
    Me.hh_RigaSS.AppearanceCell.Options.UseBackColor = True
    Me.hh_RigaSS.AppearanceCell.Options.UseTextOptions = True
    Me.hh_RigaSS.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_RigaSS.Caption = "Riga"
    Me.hh_RigaSS.Enabled = False
    Me.hh_RigaSS.FieldName = "hh_RigaSS"
    Me.hh_RigaSS.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_RigaSS.Name = "hh_RigaSS"
    Me.hh_RigaSS.NTSRepositoryComboBox = Nothing
    Me.hh_RigaSS.NTSRepositoryItemCheck = Nothing
    Me.hh_RigaSS.NTSRepositoryItemMemo = Nothing
    Me.hh_RigaSS.NTSRepositoryItemText = Nothing
    Me.hh_RigaSS.OptionsColumn.AllowEdit = False
    Me.hh_RigaSS.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_RigaSS.OptionsColumn.ReadOnly = True
    Me.hh_RigaSS.OptionsFilter.AllowFilter = False
    Me.hh_RigaSS.Visible = True
    Me.hh_RigaSS.VisibleIndex = 0
    '
    'hh_Descr
    '
    Me.hh_Descr.AppearanceCell.Options.UseBackColor = True
    Me.hh_Descr.AppearanceCell.Options.UseTextOptions = True
    Me.hh_Descr.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_Descr.Caption = "Descrizione"
    Me.hh_Descr.Enabled = True
    Me.hh_Descr.FieldName = "hh_Descr"
    Me.hh_Descr.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_Descr.Name = "hh_Descr"
    Me.hh_Descr.NTSRepositoryComboBox = Nothing
    Me.hh_Descr.NTSRepositoryItemCheck = Nothing
    Me.hh_Descr.NTSRepositoryItemMemo = Nothing
    Me.hh_Descr.NTSRepositoryItemText = Nothing
    Me.hh_Descr.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_Descr.OptionsFilter.AllowFilter = False
    Me.hh_Descr.Visible = True
    Me.hh_Descr.VisibleIndex = 1
    '
    'hh_Note2
    '
    Me.hh_Note2.AppearanceCell.Options.UseBackColor = True
    Me.hh_Note2.AppearanceCell.Options.UseTextOptions = True
    Me.hh_Note2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_Note2.Caption = "Note"
    Me.hh_Note2.Enabled = True
    Me.hh_Note2.FieldName = "hh_Note2"
    Me.hh_Note2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_Note2.Name = "hh_Note2"
    Me.hh_Note2.NTSRepositoryComboBox = Nothing
    Me.hh_Note2.NTSRepositoryItemCheck = Nothing
    Me.hh_Note2.NTSRepositoryItemMemo = Nothing
    Me.hh_Note2.NTSRepositoryItemText = Nothing
    Me.hh_Note2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_Note2.OptionsFilter.AllowFilter = False
    Me.hh_Note2.Visible = True
    Me.hh_Note2.VisibleIndex = 2
    '
    'hh_Misura1
    '
    Me.hh_Misura1.AppearanceCell.Options.UseBackColor = True
    Me.hh_Misura1.AppearanceCell.Options.UseTextOptions = True
    Me.hh_Misura1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_Misura1.Caption = "Base"
    Me.hh_Misura1.Enabled = True
    Me.hh_Misura1.FieldName = "hh_Misura1"
    Me.hh_Misura1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_Misura1.Name = "hh_Misura1"
    Me.hh_Misura1.NTSRepositoryComboBox = Nothing
    Me.hh_Misura1.NTSRepositoryItemCheck = Nothing
    Me.hh_Misura1.NTSRepositoryItemMemo = Nothing
    Me.hh_Misura1.NTSRepositoryItemText = Nothing
    Me.hh_Misura1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_Misura1.OptionsFilter.AllowFilter = False
    Me.hh_Misura1.Visible = True
    Me.hh_Misura1.VisibleIndex = 3
    '
    'hh_Misura2
    '
    Me.hh_Misura2.AppearanceCell.Options.UseBackColor = True
    Me.hh_Misura2.AppearanceCell.Options.UseTextOptions = True
    Me.hh_Misura2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_Misura2.Caption = "Altezza"
    Me.hh_Misura2.Enabled = True
    Me.hh_Misura2.FieldName = "hh_Misura2"
    Me.hh_Misura2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_Misura2.Name = "hh_Misura2"
    Me.hh_Misura2.NTSRepositoryComboBox = Nothing
    Me.hh_Misura2.NTSRepositoryItemCheck = Nothing
    Me.hh_Misura2.NTSRepositoryItemMemo = Nothing
    Me.hh_Misura2.NTSRepositoryItemText = Nothing
    Me.hh_Misura2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_Misura2.OptionsFilter.AllowFilter = False
    Me.hh_Misura2.Visible = True
    Me.hh_Misura2.VisibleIndex = 4
    '
    'hh_Misura3
    '
    Me.hh_Misura3.AppearanceCell.Options.UseBackColor = True
    Me.hh_Misura3.AppearanceCell.Options.UseTextOptions = True
    Me.hh_Misura3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_Misura3.Caption = "Misura 3"
    Me.hh_Misura3.Enabled = True
    Me.hh_Misura3.FieldName = "hh_Misura3"
    Me.hh_Misura3.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_Misura3.Name = "hh_Misura3"
    Me.hh_Misura3.NTSRepositoryComboBox = Nothing
    Me.hh_Misura3.NTSRepositoryItemCheck = Nothing
    Me.hh_Misura3.NTSRepositoryItemMemo = Nothing
    Me.hh_Misura3.NTSRepositoryItemText = Nothing
    Me.hh_Misura3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_Misura3.OptionsFilter.AllowFilter = False
    Me.hh_Misura3.Visible = True
    Me.hh_Misura3.VisibleIndex = 5
    '
    'hh_Colli
    '
    Me.hh_Colli.AppearanceCell.Options.UseBackColor = True
    Me.hh_Colli.AppearanceCell.Options.UseTextOptions = True
    Me.hh_Colli.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_Colli.Caption = "Colli"
    Me.hh_Colli.Enabled = True
    Me.hh_Colli.FieldName = "hh_Colli"
    Me.hh_Colli.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_Colli.Name = "hh_Colli"
    Me.hh_Colli.NTSRepositoryComboBox = Nothing
    Me.hh_Colli.NTSRepositoryItemCheck = Nothing
    Me.hh_Colli.NTSRepositoryItemMemo = Nothing
    Me.hh_Colli.NTSRepositoryItemText = Nothing
    Me.hh_Colli.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_Colli.OptionsFilter.AllowFilter = False
    Me.hh_Colli.Visible = True
    Me.hh_Colli.VisibleIndex = 6
    '
    'hh_Quant
    '
    Me.hh_Quant.AppearanceCell.Options.UseBackColor = True
    Me.hh_Quant.AppearanceCell.Options.UseTextOptions = True
    Me.hh_Quant.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_Quant.Caption = "Quantità"
    Me.hh_Quant.Enabled = False
    Me.hh_Quant.FieldName = "hh_Quant"
    Me.hh_Quant.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_Quant.Name = "hh_Quant"
    Me.hh_Quant.NTSRepositoryComboBox = Nothing
    Me.hh_Quant.NTSRepositoryItemCheck = Nothing
    Me.hh_Quant.NTSRepositoryItemMemo = Nothing
    Me.hh_Quant.NTSRepositoryItemText = Nothing
    Me.hh_Quant.OptionsColumn.AllowEdit = False
    Me.hh_Quant.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_Quant.OptionsColumn.ReadOnly = True
    Me.hh_Quant.OptionsFilter.AllowFilter = False
    Me.hh_Quant.Visible = True
    Me.hh_Quant.VisibleIndex = 7
    '
    'hh_Riga
    '
    Me.hh_Riga.AppearanceCell.Options.UseBackColor = True
    Me.hh_Riga.AppearanceCell.Options.UseTextOptions = True
    Me.hh_Riga.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_Riga.Caption = "RigaBolla"
    Me.hh_Riga.Enabled = False
    Me.hh_Riga.FieldName = "hh_riga"
    Me.hh_Riga.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_Riga.Name = "hh_Riga"
    Me.hh_Riga.NTSRepositoryComboBox = Nothing
    Me.hh_Riga.NTSRepositoryItemCheck = Nothing
    Me.hh_Riga.NTSRepositoryItemMemo = Nothing
    Me.hh_Riga.NTSRepositoryItemText = Nothing
    Me.hh_Riga.OptionsColumn.AllowEdit = False
    Me.hh_Riga.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_Riga.OptionsColumn.ReadOnly = True
    Me.hh_Riga.OptionsFilter.AllowFilter = False
    '
    'hh_Tipork
    '
    Me.hh_Tipork.AppearanceCell.Options.UseBackColor = True
    Me.hh_Tipork.AppearanceCell.Options.UseTextOptions = True
    Me.hh_Tipork.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.hh_Tipork.Caption = "Tipork"
    Me.hh_Tipork.Enabled = False
    Me.hh_Tipork.FieldName = "hh_Tipork"
    Me.hh_Tipork.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.hh_Tipork.Name = "hh_Tipork"
    Me.hh_Tipork.NTSRepositoryComboBox = Nothing
    Me.hh_Tipork.NTSRepositoryItemCheck = Nothing
    Me.hh_Tipork.NTSRepositoryItemMemo = Nothing
    Me.hh_Tipork.NTSRepositoryItemText = Nothing
    Me.hh_Tipork.OptionsColumn.AllowEdit = False
    Me.hh_Tipork.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.hh_Tipork.OptionsColumn.ReadOnly = True
    Me.hh_Tipork.OptionsFilter.AllowFilter = False
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
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FrmDetRiga"
    Me.Text = "DETTAGLIO RIGA"
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).EndInit()
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
    If oCleHh.CPNEValidaGriCPNEDetRiga(dcHhgr.Position) Then
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
