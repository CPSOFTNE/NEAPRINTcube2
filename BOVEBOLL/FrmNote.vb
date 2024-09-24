Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Imports System.Windows.Forms
Public Class FrmNote
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
    Me.grAnomalie = New NTSInformatica.NTSGrid()
    Me.grvAnomalie = New NTSInformatica.NTSGridView()
    Me.pr_oplav = New NTSInformatica.NTSGridColumn()
    Me.pr_idan = New NTSInformatica.NTSGridColumn()
    Me.pr_note = New NTSInformatica.NTSGridColumn()
    Me.pr_terminale = New NTSInformatica.NTSGridColumn()
    Me.xx_descope = New NTSInformatica.NTSGridColumn()
    Me.pr_dataanomalia = New NTSInformatica.NTSGridColumn()
    Me.pr_oraanomalia = New NTSInformatica.NTSGridColumn()
    Me.pr_pezzi = New NTSInformatica.NTSGridColumn()
    Me.pr_kg = New NTSInformatica.NTSGridColumn()
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grAnomalie, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grvAnomalie, System.ComponentModel.ISupportInitialize).BeginInit()
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
    'grAnomalie
    '
    Me.grAnomalie.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    '
    '
    '
    Me.grAnomalie.EmbeddedNavigator.Name = ""
    Me.grAnomalie.Location = New System.Drawing.Point(-2, 0)
    Me.grAnomalie.MainView = Me.grvAnomalie
    Me.grAnomalie.Name = "grAnomalie"
    Me.grAnomalie.Size = New System.Drawing.Size(676, 200)
    Me.grAnomalie.TabIndex = 0
    Me.grAnomalie.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvAnomalie})
    '
    'grvAnomalie
    '
    Me.grvAnomalie.ActiveFilterEnabled = False
    Me.grvAnomalie.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.pr_oplav, Me.pr_idan, Me.pr_note, Me.pr_terminale, Me.xx_descope, Me.pr_dataanomalia, Me.pr_oraanomalia, Me.pr_pezzi, Me.pr_kg})
    Me.grvAnomalie.Enabled = True
    Me.grvAnomalie.GridControl = Me.grAnomalie
    Me.grvAnomalie.MaxRowHeight = 9999
    Me.grvAnomalie.MinRowHeight = 14
    Me.grvAnomalie.Name = "grvAnomalie"
    Me.grvAnomalie.NTSAllowDelete = True
    Me.grvAnomalie.NTSAllowInsert = True
    Me.grvAnomalie.NTSAllowUpdate = True
    Me.grvAnomalie.NTSForceShowGroupPanel = -9
    Me.grvAnomalie.NTSMenuContext = Nothing
    Me.grvAnomalie.OptionsCustomization.AllowRowSizing = True
    Me.grvAnomalie.OptionsFilter.AllowFilterEditor = False
    Me.grvAnomalie.OptionsNavigation.EnterMoveNextColumn = True
    Me.grvAnomalie.OptionsNavigation.UseTabKey = False
    Me.grvAnomalie.OptionsSelection.EnableAppearanceFocusedRow = False
    Me.grvAnomalie.OptionsView.ColumnAutoWidth = False
    Me.grvAnomalie.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
    Me.grvAnomalie.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
    Me.grvAnomalie.OptionsView.ShowGroupPanel = False
    Me.grvAnomalie.RowHeight = 14
    '
    'pr_oplav
    '
    Me.pr_oplav.AppearanceCell.Options.UseBackColor = True
    Me.pr_oplav.AppearanceCell.Options.UseTextOptions = True
    Me.pr_oplav.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.pr_oplav.AppearanceHeader.Options.UseTextOptions = True
    Me.pr_oplav.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.pr_oplav.Caption = "Lavorazione"
    Me.pr_oplav.Enabled = True
    Me.pr_oplav.FieldName = "pr_oplav"
    Me.pr_oplav.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.pr_oplav.Name = "pr_oplav"
    Me.pr_oplav.NTSRepositoryComboBox = Nothing
    Me.pr_oplav.NTSRepositoryItemCheck = Nothing
    Me.pr_oplav.NTSRepositoryItemMemo = Nothing
    Me.pr_oplav.NTSRepositoryItemText = Nothing
    Me.pr_oplav.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.pr_oplav.OptionsFilter.AllowFilter = False
    Me.pr_oplav.Visible = True
    Me.pr_oplav.VisibleIndex = 0
    Me.pr_oplav.Width = 82
    '
    'pr_idan
    '
    Me.pr_idan.AppearanceCell.Options.UseBackColor = True
    Me.pr_idan.AppearanceCell.Options.UseTextOptions = True
    Me.pr_idan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.pr_idan.AppearanceHeader.Options.UseTextOptions = True
    Me.pr_idan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.pr_idan.Caption = "Anomalia"
    Me.pr_idan.Enabled = True
    Me.pr_idan.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.pr_idan.Name = "pr_idan"
    Me.pr_idan.NTSRepositoryComboBox = Nothing
    Me.pr_idan.NTSRepositoryItemCheck = Nothing
    Me.pr_idan.NTSRepositoryItemMemo = Nothing
    Me.pr_idan.NTSRepositoryItemText = Nothing
    Me.pr_idan.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.pr_idan.OptionsFilter.AllowFilter = False
    Me.pr_idan.Visible = True
    Me.pr_idan.VisibleIndex = 1
    Me.pr_idan.Width = 69
    '
    'pr_note
    '
    Me.pr_note.AppearanceCell.Options.UseBackColor = True
    Me.pr_note.AppearanceCell.Options.UseTextOptions = True
    Me.pr_note.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.pr_note.Caption = "Note"
    Me.pr_note.Enabled = True
    Me.pr_note.FieldName = "pr_note"
    Me.pr_note.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.pr_note.Name = "pr_note"
    Me.pr_note.NTSRepositoryComboBox = Nothing
    Me.pr_note.NTSRepositoryItemCheck = Nothing
    Me.pr_note.NTSRepositoryItemMemo = Nothing
    Me.pr_note.NTSRepositoryItemText = Nothing
    Me.pr_note.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.pr_note.OptionsFilter.AllowFilter = False
    Me.pr_note.Visible = True
    Me.pr_note.VisibleIndex = 2
    Me.pr_note.Width = 166
    '
    'pr_terminale
    '
    Me.pr_terminale.AppearanceCell.Options.UseBackColor = True
    Me.pr_terminale.AppearanceCell.Options.UseTextOptions = True
    Me.pr_terminale.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.pr_terminale.Caption = "Terminale"
    Me.pr_terminale.Enabled = True
    Me.pr_terminale.FieldName = "pr_terminale"
    Me.pr_terminale.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.pr_terminale.Name = "pr_terminale"
    Me.pr_terminale.NTSRepositoryComboBox = Nothing
    Me.pr_terminale.NTSRepositoryItemCheck = Nothing
    Me.pr_terminale.NTSRepositoryItemMemo = Nothing
    Me.pr_terminale.NTSRepositoryItemText = Nothing
    Me.pr_terminale.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.pr_terminale.OptionsFilter.AllowFilter = False
    '
    'xx_descope
    '
    Me.xx_descope.AppearanceCell.Options.UseBackColor = True
    Me.xx_descope.AppearanceCell.Options.UseTextOptions = True
    Me.xx_descope.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.xx_descope.Caption = "Operatore"
    Me.xx_descope.Enabled = True
    Me.xx_descope.FieldName = "xx_descope"
    Me.xx_descope.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.xx_descope.Name = "xx_descope"
    Me.xx_descope.NTSRepositoryComboBox = Nothing
    Me.xx_descope.NTSRepositoryItemCheck = Nothing
    Me.xx_descope.NTSRepositoryItemMemo = Nothing
    Me.xx_descope.NTSRepositoryItemText = Nothing
    Me.xx_descope.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.xx_descope.OptionsFilter.AllowFilter = False
    Me.xx_descope.Visible = True
    Me.xx_descope.VisibleIndex = 3
    Me.xx_descope.Width = 180
    '
    'pr_dataanomalia
    '
    Me.pr_dataanomalia.AppearanceCell.Options.UseBackColor = True
    Me.pr_dataanomalia.AppearanceCell.Options.UseTextOptions = True
    Me.pr_dataanomalia.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.pr_dataanomalia.Caption = "Data Anomalia"
    Me.pr_dataanomalia.Enabled = True
    Me.pr_dataanomalia.FieldName = "pr_dataanomalia"
    Me.pr_dataanomalia.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.pr_dataanomalia.Name = "pr_dataanomalia"
    Me.pr_dataanomalia.NTSRepositoryComboBox = Nothing
    Me.pr_dataanomalia.NTSRepositoryItemCheck = Nothing
    Me.pr_dataanomalia.NTSRepositoryItemMemo = Nothing
    Me.pr_dataanomalia.NTSRepositoryItemText = Nothing
    Me.pr_dataanomalia.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.pr_dataanomalia.OptionsFilter.AllowFilter = False
    Me.pr_dataanomalia.Visible = True
    Me.pr_dataanomalia.VisibleIndex = 4
    Me.pr_dataanomalia.Width = 81
    '
    'pr_oraanomalia
    '
    Me.pr_oraanomalia.AppearanceCell.Options.UseBackColor = True
    Me.pr_oraanomalia.AppearanceCell.Options.UseTextOptions = True
    Me.pr_oraanomalia.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.pr_oraanomalia.Caption = "Ora Anomalia"
    Me.pr_oraanomalia.Enabled = True
    Me.pr_oraanomalia.FieldName = "pr_oraanomalia"
    Me.pr_oraanomalia.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.pr_oraanomalia.Name = "pr_oraanomalia"
    Me.pr_oraanomalia.NTSRepositoryComboBox = Nothing
    Me.pr_oraanomalia.NTSRepositoryItemCheck = Nothing
    Me.pr_oraanomalia.NTSRepositoryItemMemo = Nothing
    Me.pr_oraanomalia.NTSRepositoryItemText = Nothing
    Me.pr_oraanomalia.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.pr_oraanomalia.OptionsFilter.AllowFilter = False
    Me.pr_oraanomalia.Visible = True
    Me.pr_oraanomalia.VisibleIndex = 5
    Me.pr_oraanomalia.Width = 76
    '
    'pr_pezzi
    '
    Me.pr_pezzi.AppearanceCell.Options.UseBackColor = True
    Me.pr_pezzi.AppearanceCell.Options.UseTextOptions = True
    Me.pr_pezzi.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.pr_pezzi.AppearanceHeader.Options.UseTextOptions = True
    Me.pr_pezzi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.pr_pezzi.Caption = "Pezzi"
    Me.pr_pezzi.Enabled = True
    Me.pr_pezzi.FieldName = "pr_pezzi"
    Me.pr_pezzi.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.pr_pezzi.Name = "pr_pezzi"
    Me.pr_pezzi.NTSRepositoryComboBox = Nothing
    Me.pr_pezzi.NTSRepositoryItemCheck = Nothing
    Me.pr_pezzi.NTSRepositoryItemMemo = Nothing
    Me.pr_pezzi.NTSRepositoryItemText = Nothing
    Me.pr_pezzi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.pr_pezzi.OptionsFilter.AllowFilter = False
    Me.pr_pezzi.Visible = True
    Me.pr_pezzi.VisibleIndex = 6
    Me.pr_pezzi.Width = 49
    '
    'pr_kg
    '
    Me.pr_kg.AppearanceCell.Options.UseBackColor = True
    Me.pr_kg.AppearanceCell.Options.UseTextOptions = True
    Me.pr_kg.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.pr_kg.AppearanceHeader.Options.UseTextOptions = True
    Me.pr_kg.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.pr_kg.Caption = "Kg"
    Me.pr_kg.Enabled = True
    Me.pr_kg.FieldName = "pr_kg"
    Me.pr_kg.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.pr_kg.Name = "pr_kg"
    Me.pr_kg.NTSRepositoryComboBox = Nothing
    Me.pr_kg.NTSRepositoryItemCheck = Nothing
    Me.pr_kg.NTSRepositoryItemMemo = Nothing
    Me.pr_kg.NTSRepositoryItemText = Nothing
    Me.pr_kg.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.pr_kg.OptionsFilter.AllowFilter = False
    Me.pr_kg.Visible = True
    Me.pr_kg.VisibleIndex = 7
    '
    'FrmNote
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
    Me.ClientSize = New System.Drawing.Size(676, 200)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(676, 200)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(676, 200)
    Me.PnCPNEPnMain.Controls.Add(Me.grAnomalie)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FrmNote"
    Me.Text = "SEGNALAZIONI PRODUZIONE"
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grAnomalie, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grvAnomalie, System.ComponentModel.ISupportInitialize).EndInit()
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
  Public CPNEAnomalieProduzioneCommessa As String = ""


  Public Overridable Sub Bindcontrols()
    Try
      '-------------------------------------------------
      'se i controlli erano già  stati precedentemente collegati, li scollego
      NTSFormClearDataBinding(Me)

      grvAnomalie.NTSSetParam(oMenu, oApp.Tr(Me, 130622522437932789, "Anomalie Produzione"))
      pr_oplav.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130622522437942796, "Lavorazione"), "0", 9, 0, 999999999)
      pr_idan.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130622522437952803, "Anomalia"), "0", 9, 0, 999999999)
      pr_note.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130622522437962807, "Note"), 0, True)
      pr_terminale.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130622522437972818, "Terminale"), 0, True)
      xx_descope.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130622522437982822, "Operatore"), 0, True)
      pr_dataanomalia.NTSSetParamDATA(oMenu, oApp.Tr(Me, 130622522437992832, "Data Anomalia"), True)
      pr_oraanomalia.NTSSetParamSTR(oMenu, oApp.Tr(Me, 130622522438002836, "Ora Anomalia"), 0, True)
      pr_pezzi.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130622522438012840, "Pezzi"), "#,##0.00", 15)
      pr_kg.NTSSetParamNUM(oMenu, oApp.Tr(Me, 130622522438022847, "Kg"), "#,##0.00", 15)




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

  Private Sub FRMNote_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
TRY
    dsHh = oCleHh.dsShared
    dcHh = Nothing
    dcHh = New BindingSource()
    oCleHh.CPNEhhAnomalieProdCarica(CInt(CPNEAnomalieProduzioneCommessa))
    dcHh.DataSource = dsHh.Tables("CPNEAnomalieProd")
    AggGriglia()
    Bindcontrols()

    grvAnomalie.NTSAllowDelete = False
    grvAnomalie.NTSAllowInsert = False
    grvAnomalie.NTSAllowUpdate = False
    grvAnomalie.Enabled = False


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
    dcHhGr.DataSource = dsHh.Tables("CPNEAnomalieProd")
    grAnomalie.DataSource = dcHhGr
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
End Class
