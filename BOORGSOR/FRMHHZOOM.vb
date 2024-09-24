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
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMHHZOOM))
    Me.NtsPanel1 = New NTSInformatica.NTSPanel()
    Me.grTabe = New NTSInformatica.NTSGrid()
    Me.grvTabe = New NTSInformatica.NTSGridView()
    Me.xx_codice = New NTSInformatica.NTSGridColumn()
    Me.xx_descr = New NTSInformatica.NTSGridColumn()
    Me.tb_deshhuff = New NTSInformatica.NTSGridColumn()
    Me.NtsBarManager1 = New NTSInformatica.NTSBarManager()
    Me.TlbNuovo = New NTSInformatica.NTSBarButtonItem()
    Me.TlbSalva = New NTSInformatica.NTSBarButtonItem()
    Me.TlbRipristina = New NTSInformatica.NTSBarButtonItem()
    Me.TlbCancella = New NTSInformatica.NTSBarButtonItem()
    Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
    Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
    Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
    Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
    Me.NtsPanel2 = New NTSInformatica.NTSPanel()
    Me.cmdAnnulla = New NTSInformatica.NTSButton()
    Me.cmdSeleziona = New NTSInformatica.NTSButton()
    CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.NtsPanel1.SuspendLayout()
    CType(Me.grTabe, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grvTabe, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NtsBarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NtsPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.NtsPanel2.SuspendLayout()
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
    Me.NtsPanel1.Location = New System.Drawing.Point(4, 42)
    Me.NtsPanel1.Name = "NtsPanel1"
    Me.NtsPanel1.Size = New System.Drawing.Size(606, 270)
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
    Me.grTabe.Size = New System.Drawing.Size(595, 264)
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
    Me.NtsBarManager1.DockControls.Add(Me.barDockControlTop)
    Me.NtsBarManager1.DockControls.Add(Me.barDockControlBottom)
    Me.NtsBarManager1.DockControls.Add(Me.barDockControlLeft)
    Me.NtsBarManager1.DockControls.Add(Me.barDockControlRight)
    Me.NtsBarManager1.Form = Me
    Me.NtsBarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.TlbNuovo, Me.TlbSalva, Me.TlbRipristina, Me.TlbCancella})
    Me.NtsBarManager1.MaxItemId = 4
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
    Me.TlbRipristina.Visible = True
    '
    'TlbCancella
    '
    Me.TlbCancella.Caption = "Cancella"
    Me.TlbCancella.Glyph = CType(resources.GetObject("TlbCancella.Glyph"), System.Drawing.Image)
    Me.TlbCancella.Id = 3
    Me.TlbCancella.Name = "TlbCancella"
    Me.TlbCancella.Visible = True
    '
    'NtsPanel2
    '
    Me.NtsPanel2.AllowDrop = True
    Me.NtsPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.NtsPanel2.Appearance.BackColor = System.Drawing.Color.Transparent
    Me.NtsPanel2.Appearance.Options.UseBackColor = True
    Me.NtsPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
    Me.NtsPanel2.Controls.Add(Me.cmdSeleziona)
    Me.NtsPanel2.Controls.Add(Me.cmdAnnulla)
    Me.NtsPanel2.Cursor = System.Windows.Forms.Cursors.Default
    Me.NtsPanel2.Location = New System.Drawing.Point(7, 0)
    Me.NtsPanel2.Name = "NtsPanel2"
    Me.NtsPanel2.Size = New System.Drawing.Size(600, 46)
    Me.NtsPanel2.TabIndex = 4
    Me.NtsPanel2.Text = "NtsPanel2"
    '
    'cmdAnnulla
    '
    Me.cmdAnnulla.ImageText = ""
    Me.cmdAnnulla.Location = New System.Drawing.Point(3, 3)
    Me.cmdAnnulla.Name = "cmdAnnulla"
    Me.cmdAnnulla.Size = New System.Drawing.Size(75, 33)
    Me.cmdAnnulla.TabIndex = 0
    Me.cmdAnnulla.Text = "Annulla"
    '
    'cmdSeleziona
    '
    Me.cmdSeleziona.ImageText = ""
    Me.cmdSeleziona.Location = New System.Drawing.Point(520, 3)
    Me.cmdSeleziona.Name = "cmdSeleziona"
    Me.cmdSeleziona.Size = New System.Drawing.Size(75, 33)
    Me.cmdSeleziona.TabIndex = 1
    Me.cmdSeleziona.Text = "Seleziona"
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
    Me.PnCPNEPnMain.Controls.Add(Me.NtsPanel2)
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
    CType(Me.NtsPanel2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.NtsPanel2.ResumeLayout(False)
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

    'dsHh = oCleHh.dsShared

    dsHh = oCleHh.DsZoomCPNE

    Select Case CType(oCleHh, CLFORGSOR).CPNEstrZoomTipoTab
      Case "Firme"
        Me.Text = "Firme"
        xx_codice.Caption = "Codice Firma"
        CType(oCleHh, CLFORGSOR).CPNECaricaTabFirme()

      Case "Postille"
        Me.Text = "Postille"
        xx_codice.Caption = "Codice Postilla"
        CType(oCleHh, CLFORGSOR).CPNECaricaTabPostille()

      Case "Preamboli"
        Me.Text = "Preamboli"
        xx_codice.Caption = "Codice Preambolo"
        CType(oCleHh, CLFORGSOR).CPNECaricaTabPreamboli()

      Case "TipiIva"
        Me.Text = "Tipi Iva"
        xx_codice.Caption = "Codice Tipo Iva"
        CType(oCleHh, CLFORGSOR).CPNECaricaTabTipiIva()
    End Select

    dsHh = CType(oCleHh, CLFORGSOR).DsZoomCPNE
    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = dsHh.Tables("YYY")
    AggGriglia()
    Bindcontrols()

    grvTabe.NTSAllowInsert = False
    grvTabe.NTSAllowDelete = False
    'grv.....Enabled = False 


    GctlSetRoules()

    Select Case CType(oCleHh, CLFORGSOR).CPNEstrZoomTipoTab
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
    dcHhGr.DataSource = dsHh.Tables("YYY")
    grTabe.DataSource = dcHhGr
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub


  Private Sub cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnulla.Click
TRY
    Me.Close()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub cmdSeleziona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeleziona.Click
TRY
    CType(oCleHh, CLFORGSOR).CPNEstrZoomCodice = dsHh.Tables("YYY").Rows(dcHhGr.Position)!xx_codice
    If CType(oCleHh, CLFORGSOR).CPNEstrZoomCodice <> "" Then
      CType(oCleHh, CLFORGSOR).CPNEAggiornaCampoZoom()
    End If
    Me.Close()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
End Class
