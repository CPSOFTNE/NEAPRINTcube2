Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Imports System.Windows.Forms
Public Class FRMHHZOOM
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
  Public Overridable Sub InitEntity(ByRef cleSt As CLEHHTABE)
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
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMHHZOOM))
    Me.NtsPanel1 = New NTSInformatica.NTSPanel()
    Me.grTabe = New NTSInformatica.NTSGrid()
    Me.grvTabe = New NTSInformatica.NTSGridView()
    Me.xx_codice = New NTSInformatica.NTSGridColumn()
    Me.xx_descr = New NTSInformatica.NTSGridColumn()
    Me.tb_deshhuff = New NTSInformatica.NTSGridColumn()
    Me.NtsBarManager1 = New NTSInformatica.NTSBarManager()
    Me.NtsBar1 = New NTSInformatica.NTSBar()
    Me.TlbNuovo = New NTSInformatica.NTSBarButtonItem()
    Me.TlbSalva = New NTSInformatica.NTSBarButtonItem()
    Me.TlbRipristina = New NTSInformatica.NTSBarButtonItem()
    Me.TlbCancella = New NTSInformatica.NTSBarButtonItem()
    Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
    Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
    Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
    Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
    CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.NtsPanel1.SuspendLayout()
    CType(Me.grTabe, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grvTabe, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NtsBarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.NtsPanel1.Controls.Add(Me.grTabe)
    Me.NtsPanel1.Cursor = System.Windows.Forms.Cursors.Default
    Me.NtsPanel1.Location = New System.Drawing.Point(4, 34)
    Me.NtsPanel1.Name = "NtsPanel1"
    Me.NtsPanel1.Size = New System.Drawing.Size(606, 278)
    Me.NtsPanel1.TabIndex = 0
    Me.NtsPanel1.Text = "NtsPanel1"
    '
    'grTabe
    '
    Me.grTabe.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    '
    '
    '
    Me.grTabe.EmbeddedNavigator.Name = ""
    Me.grTabe.Location = New System.Drawing.Point(3, 3)
    Me.grTabe.MainView = Me.grvTabe
    Me.grTabe.Name = "grTabe"
    Me.grTabe.Size = New System.Drawing.Size(595, 272)
    Me.grTabe.TabIndex = 0
    Me.grTabe.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvTabe})
    '
    'grvTabe
    '
    Me.grvTabe.ActiveFilterEnabled = False
    Me.grvTabe.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.xx_codice, Me.xx_descr, Me.tb_deshhuff})
    Me.grvTabe.Enabled = True
    Me.grvTabe.GridControl = Me.grTabe
    Me.grvTabe.Name = "grvTabe"
    Me.grvTabe.NTSAllowDelete = True
    Me.grvTabe.NTSAllowInsert = True
    Me.grvTabe.NTSAllowUpdate = True
    Me.grvTabe.NTSMenuContext = Nothing
    Me.grvTabe.OptionsCustomization.AllowRowSizing = True
    Me.grvTabe.OptionsFilter.AllowFilterEditor = False
    Me.grvTabe.OptionsNavigation.EnterMoveNextColumn = True
    Me.grvTabe.OptionsNavigation.UseTabKey = False
    Me.grvTabe.OptionsSelection.EnableAppearanceFocusedRow = False
    Me.grvTabe.OptionsView.ColumnAutoWidth = False
    Me.grvTabe.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
    Me.grvTabe.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
    Me.grvTabe.OptionsView.ShowGroupPanel = False
    Me.grvTabe.RowHeight = 14
    '
    'xx_codice
    '
    Me.xx_codice.AppearanceCell.Options.UseBackColor = True
    Me.xx_codice.AppearanceCell.Options.UseTextOptions = True
    Me.xx_codice.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.xx_codice.Caption = "Codice"
    Me.xx_codice.Enabled = True
    Me.xx_codice.FieldName = "xx_codice"
    Me.xx_codice.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.xx_codice.Name = "xx_codice"
    Me.xx_codice.NTSRepositoryComboBox = Nothing
    Me.xx_codice.NTSRepositoryItemCheck = Nothing
    Me.xx_codice.NTSRepositoryItemMemo = Nothing
    Me.xx_codice.NTSRepositoryItemText = Nothing
    Me.xx_codice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.xx_codice.OptionsFilter.AllowFilter = False
    Me.xx_codice.Visible = True
    Me.xx_codice.VisibleIndex = 0
    '
    'xx_descr
    '
    Me.xx_descr.AppearanceCell.Options.UseBackColor = True
    Me.xx_descr.AppearanceCell.Options.UseTextOptions = True
    Me.xx_descr.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.xx_descr.Caption = "Descrizione"
    Me.xx_descr.Enabled = True
    Me.xx_descr.FieldName = "xx_descr"
    Me.xx_descr.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.xx_descr.Name = "xx_descr"
    Me.xx_descr.NTSRepositoryComboBox = Nothing
    Me.xx_descr.NTSRepositoryItemCheck = Nothing
    Me.xx_descr.NTSRepositoryItemMemo = Nothing
    Me.xx_descr.NTSRepositoryItemText = Nothing
    Me.xx_descr.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.xx_descr.OptionsFilter.AllowFilter = False
    Me.xx_descr.Visible = True
    Me.xx_descr.VisibleIndex = 1
    Me.xx_descr.Width = 300
    '
    'tb_deshhuff
    '
    Me.tb_deshhuff.AppearanceCell.Options.UseBackColor = True
    Me.tb_deshhuff.AppearanceCell.Options.UseTextOptions = True
    Me.tb_deshhuff.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    Me.tb_deshhuff.Caption = "Ufficio"
    Me.tb_deshhuff.Enabled = True
    Me.tb_deshhuff.FieldName = "tb_deshhuff"
    Me.tb_deshhuff.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
    Me.tb_deshhuff.Name = "tb_deshhuff"
    Me.tb_deshhuff.NTSRepositoryComboBox = Nothing
    Me.tb_deshhuff.NTSRepositoryItemCheck = Nothing
    Me.tb_deshhuff.NTSRepositoryItemMemo = Nothing
    Me.tb_deshhuff.NTSRepositoryItemText = Nothing
    Me.tb_deshhuff.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
    Me.tb_deshhuff.OptionsFilter.AllowFilter = False
    Me.tb_deshhuff.Visible = True
    Me.tb_deshhuff.VisibleIndex = 2
    Me.tb_deshhuff.Width = 187
    '
    'NtsBarManager1
    '
    Me.NtsBarManager1.AllowCustomization = False
    Me.NtsBarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.NtsBar1})
    Me.NtsBarManager1.DockControls.Add(Me.barDockControlTop)
    Me.NtsBarManager1.DockControls.Add(Me.barDockControlBottom)
    Me.NtsBarManager1.DockControls.Add(Me.barDockControlLeft)
    Me.NtsBarManager1.DockControls.Add(Me.barDockControlRight)
    Me.NtsBarManager1.Form = Me
    Me.NtsBarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.TlbNuovo, Me.TlbSalva, Me.TlbRipristina, Me.TlbCancella})
    Me.NtsBarManager1.MaxItemId = 4
    '
    'NtsBar1
    '
    Me.NtsBar1.BarName = "tlbMain"
    Me.NtsBar1.DockCol = 0
    Me.NtsBar1.DockRow = 0
    Me.NtsBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
    Me.NtsBar1.FloatLocation = New System.Drawing.Point(56, 148)
    Me.NtsBar1.FloatSize = New System.Drawing.Size(111, 30)
    Me.NtsBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.TlbNuovo), New DevExpress.XtraBars.LinkPersistInfo(Me.TlbSalva), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, False, Me.TlbRipristina, False), New DevExpress.XtraBars.LinkPersistInfo(Me.TlbCancella)})
    Me.NtsBar1.OptionsBar.MultiLine = True
    Me.NtsBar1.OptionsBar.UseWholeRow = True
    Me.NtsBar1.Text = "tlbMain"
    '
    'TlbNuovo
    '
    Me.TlbNuovo.Caption = "Nuovo"
    Me.TlbNuovo.Glyph = CType(resources.GetObject("TlbNuovo.Glyph"), System.Drawing.Image)
    Me.TlbNuovo.Id = 0
    Me.TlbNuovo.Name = "TlbNuovo"
    Me.TlbNuovo.Visible = True
    '
    'TlbSalva
    '
    Me.TlbSalva.Caption = "Salva"
    Me.TlbSalva.Glyph = CType(resources.GetObject("TlbSalva.Glyph"), System.Drawing.Image)
    Me.TlbSalva.Id = 1
    Me.TlbSalva.Name = "TlbSalva"
    Me.TlbSalva.Visible = True
    '
    'TlbRipristina
    '
    Me.TlbRipristina.Caption = "Ripristina"
    Me.TlbRipristina.Glyph = CType(resources.GetObject("TlbRipristina.Glyph"), System.Drawing.Image)
    Me.TlbRipristina.Id = 2
    Me.TlbRipristina.Name = "TlbRipristina"
    Me.TlbRipristina.Visible = False
    '
    'TlbCancella
    '
    Me.TlbCancella.Caption = "Cancella"
    Me.TlbCancella.Glyph = CType(resources.GetObject("TlbCancella.Glyph"), System.Drawing.Image)
    Me.TlbCancella.Id = 3
    Me.TlbCancella.Name = "TlbCancella"
    Me.TlbCancella.Visible = True
    '
    'FRMHHZOOM
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
    Me.ClientSize = New System.Drawing.Size(610, 316)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(610, 316)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(610, 316)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsPanel1)
    Me.PnCPNEPnMain.Controls.Add(Me.barDockControlLeft)
    Me.PnCPNEPnMain.Controls.Add(Me.barDockControlRight)
    Me.PnCPNEPnMain.Controls.Add(Me.barDockControlBottom)
    Me.PnCPNEPnMain.Controls.Add(Me.barDockControlTop)
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FRMHHZOOM"
    CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).EndInit()
Me.NtsPanel1.ResumeLayout(False)
    CType(Me.grTabe, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grvTabe, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NtsBarManager1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).EndInit()
Me.PnCPNEPnMain.ResumeLayout(False)
Me.ResumeLayout(False)

  End Sub
#End Region
  Private components As System.ComponentModel.IContainer
  Public oCleHh As CLEHHTABE
  Public dsHh As New DataSet
  Public oCallParams As CLE__CLDP
  Public dcHh As BindingSource = New BindingSource
  Public dcHhGr As BindingSource = New BindingSource

  Public Overridable Sub Bindcontrols()
    Try
      '-------------------------------------------------
      'se i controlli erano già  stati precedentemente collegati, li scollego
      NTSFormClearDataBinding(Me)

      grvTabe.NTSSetParam(oMenu, oApp.Tr(Me, 131165183203776892, "Tabelle"))
      xx_codice.NTSSetParamNUM(oMenu, oApp.Tr(Me, 131165183203933145, "Codice Firma"), "0", 4, 0, 9999)
      xx_descr.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131165183204089390, "Descrizione"), 0, True)
      tb_deshhuff.NTSSetParamSTR(oMenu, oApp.Tr(Me, 131165183204245646, "Ufficio"), 0, True)


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

  Private Sub FRMHHZOOM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
TRY
    dsHh = oCleHh.dsShared

    Select Case oCleHh.CPNEstrZoomTipoTab
      Case "Firme"
        Me.Text = "Firme"
        xx_codice.Caption = "Codice Firma"
        oCleHh.CPNECaricaTabFirme()

      Case "Postille"
        Me.Text = "Postille"
        xx_codice.Caption = "Codice Postilla"
        oCleHh.CPNECaricaTabPostille()

      Case "Preamboli"
        Me.Text = "Preamboli"
        xx_codice.Caption = "Codice Preambolo"
        oCleHh.CPNECaricaTabPreamboli()

      Case "UM"
        Me.Text = "Unità di Misura"
        xx_codice.Caption = "Unità di misura"
        oCleHh.CPNECaricaTabUM()
    End Select

    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = dsHh.Tables("XXX")
    AggGriglia()
    Bindcontrols()

    'grv.....NTSAllowInsert = False
    'grv.....NTSAllowDelete = False 
    'grv.....Enabled = False 


    GctlSetRoules()

    Select oCleHh.CPNEstrZoomTipoTab
      Case "Firme"
        grvTabe.Columns("tb_deshhuff").Visible = True
      Case Else
        grvTabe.Columns("tb_deshhuff").Visible = False
    End Select
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
    dcHhGr.DataSource = dsHh.Tables("XXX")
    grTabe.DataSource = dcHhGr
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overridable Sub FRMHHZOOM_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
TRY
    ValidaLastControl()
    If Not oCleHh.CPNESalva() Then e.Cancel = True
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Public Overridable Sub tlbNuovo_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles TlbNuovo.ItemClick
    Try
      grvTabe.NTSNuovo()

    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------
    End Try
  End Sub

  'Public Overridable Sub tlbSalva_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles TlbSalva.ItemClick
  '  Try
  '    Salva()
  '  Catch ex As Exception
  '    '-------------------------------------------------
  '    CLN__STD.GestErr(ex, Me, "")
  '    '-------------------------------------------------
  '  End Try
  'End Sub

  Public Overridable Sub tlbCancella_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles TlbCancella.ItemClick
    Try
      'If Not grvTabe.NTSDeleteRigaCorrente(dcHhGr, True) Then Return
      'oCleHh.Salva(True)
      If oApp.MsgBoxInfoYesNo_DefNo("Cancello la riga?") = System.Windows.Forms.DialogResult.No Then
        Return
      End If

      dsHh.Tables("XXX").Rows(dcHhGr.Position).Delete()
      dsHh.Tables("XXX").AcceptChanges()


    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------
    End Try
  End Sub


  'Public Overridable Sub tlbRipristina_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles TlbRipristina.ItemClick
  '  Try
  '    If Not grvTabe.NTSRipristinaRigaCorrenteBefore(dcHh, True) Then Return
  '    oCleHh.Ripristina(dcHh.Position, dcHh.Filter)
  '    grvTabe.NTSRipristinaRigaCorrenteAfter()
  '  Catch ex As Exception
  '    '-------------------------------------------------
  '    CLN__STD.GestErr(ex, Me, "")
  '    '-------------------------------------------------
  '  End Try
  'End Sub
  'Public Overridable Function Salva() As Boolean
  '  Try
  '    Me.ValidaLastControl()      'valido l'ultimo controllo che ha il focus

  '    Dim dRes As DialogResult
  '    dRes = grvTabe.NTSSalvaRigaCorrente(dcHh, oCleHh.RecordIsChanged, False)
  '    oCleHh.bHasChanges = False
  '    Select Case dRes
  '      Case System.Windows.Forms.DialogResult.Yes
  '        'salvo
  '        '-------------------------------------------------
  '        'controllo che i campi abbiano un valore diverso da quello impostato in GCTL.OutNotEqual
  '        If GctlControllaOutNotEqual() = False Then Return False

  '        If Not oCleHh.Salva(False) Then
  '          Return False
  '        End If
  '      Case System.Windows.Forms.DialogResult.No
  '        'ripristino
  '        oCleHh.Ripristina(dcHh.Position, dcHh.Filter)
  '      Case System.Windows.Forms.DialogResult.Cancel
  '        'non posso fare nulla
  '        Return False
  '      Case System.Windows.Forms.DialogResult.Abort
  '        'la riga non ha subito modifiche
  '    End Select
  '    Return True
  '  Catch ex As Exception
  '    '-------------------------------------------------
  '    CLN__STD.GestErr(ex, Me, "")
  '    '-------------------------------------------------
  '  End Try
  'End Function
  'Public Overridable Sub grvTabe_NTSBeforeRowUpdate(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles grvTabe.NTSBeforeRowUpdate
  '  Try
  '    If Not Salva() Then
  '      'rimango sulla riga su cui sono
  '      e.Allow = False
  '    End If

  '  Catch ex As Exception
  '    '-------------------------------------------------
  '    CLN__STD.GestErr(ex, Me, "")
  '    '-------------------------------------------------
  '  End Try
  'End Sub

  Private Sub grvTabe_NTSNewRow(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvTabe.NTSNewRow
TRY
    oCleHh.CPNEintRigaCorrente = dcHhGr.Position
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub grvTabe_NTSBeforeRowUpdate(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles grvTabe.NTSBeforeRowUpdate
TRY
    If oCleHh.ValidaRigaGriglia(dcHhGr.Position) Then
      dsHh.Tables("XXX").AcceptChanges()
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
