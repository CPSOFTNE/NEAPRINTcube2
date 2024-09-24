Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Imports System.Windows.Forms
Public Class FrmUsaCont
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
    Me.CmdOk = New NTSInformatica.NTSButton()
    Me.edhh_codartCliForSacc = New NTSInformatica.NTSTextBoxStr()
    Me.NtsLabel1 = New NTSInformatica.NTSLabel()
    Me.edhh_qtaSacc = New NTSInformatica.NTSTextBoxNum()
    Me.NtsLabel2 = New NTSInformatica.NTSLabel()
    Me.NtsLabel3 = New NTSInformatica.NTSLabel()
    Me.edhh_qtaCasse = New NTSInformatica.NTSTextBoxNum()
    Me.NtsLabel4 = New NTSInformatica.NTSLabel()
    Me.edhh_codartCliForCasse = New NTSInformatica.NTSTextBoxStr()
    Me.NtsLabel5 = New NTSInformatica.NTSLabel()
    Me.edhh_qtaCasso = New NTSInformatica.NTSTextBoxNum()
    Me.NtsLabel6 = New NTSInformatica.NTSLabel()
    Me.edhh_codartCliForCasso = New NTSInformatica.NTSTextBoxStr()
    Me.NtsLabel7 = New NTSInformatica.NTSLabel()
    Me.edhh_qtaPedane = New NTSInformatica.NTSTextBoxNum()
    Me.NtsLabel8 = New NTSInformatica.NTSLabel()
    Me.edhh_codartCliForPedane = New NTSInformatica.NTSTextBoxStr()
    Me.NtsLabel9 = New NTSInformatica.NTSLabel()
    Me.edhh_qtaCope = New NTSInformatica.NTSTextBoxNum()
    Me.NtsLabel10 = New NTSInformatica.NTSLabel()
    Me.edhh_codartCliForCope = New NTSInformatica.NTSTextBoxStr()
    Me.CmdAnnulla = New NTSInformatica.NTSButton()
    CType(Me.edhh_codartCliForSacc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edhh_qtaSacc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edhh_qtaCasse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edhh_codartCliForCasse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edhh_qtaCasso.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edhh_codartCliForCasso.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edhh_qtaPedane.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edhh_codartCliForPedane.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edhh_qtaCope.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edhh_codartCliForCope.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
    'CmdOk
    '
    Me.CmdOk.ImageText = ""
    Me.CmdOk.Location = New System.Drawing.Point(223, 175)
    Me.CmdOk.Name = "CmdOk"
    Me.CmdOk.Size = New System.Drawing.Size(100, 40)
    Me.CmdOk.TabIndex = 0
    Me.CmdOk.Text = "Conferma"
    '
    'edhh_codartCliForSacc
    '
    Me.edhh_codartCliForSacc.Cursor = System.Windows.Forms.Cursors.Default
    Me.edhh_codartCliForSacc.Location = New System.Drawing.Point(223, 15)
    Me.edhh_codartCliForSacc.Name = "edhh_codartCliForSacc"
    Me.edhh_codartCliForSacc.NTSDbField = ""
    Me.edhh_codartCliForSacc.NTSForzaVisZoom = False
    Me.edhh_codartCliForSacc.NTSOldValue = ""
    Me.edhh_codartCliForSacc.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edhh_codartCliForSacc.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edhh_codartCliForSacc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edhh_codartCliForSacc.Properties.MaxLength = 65536
    Me.edhh_codartCliForSacc.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edhh_codartCliForSacc.Size = New System.Drawing.Size(100, 20)
    Me.edhh_codartCliForSacc.TabIndex = 1
    '
    'NtsLabel1
    '
    Me.NtsLabel1.AutoSize = True
    Me.NtsLabel1.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel1.Location = New System.Drawing.Point(20, 18)
    Me.NtsLabel1.Name = "NtsLabel1"
    Me.NtsLabel1.NTSDbField = ""
    Me.NtsLabel1.Size = New System.Drawing.Size(72, 13)
    Me.NtsLabel1.TabIndex = 2
    Me.NtsLabel1.Text = "Qta Sacchetti"
    Me.NtsLabel1.Tooltip = ""
    Me.NtsLabel1.UseMnemonic = False
    '
    'edhh_qtaSacc
    '
    Me.edhh_qtaSacc.Cursor = System.Windows.Forms.Cursors.Default
    Me.edhh_qtaSacc.Location = New System.Drawing.Point(98, 15)
    Me.edhh_qtaSacc.Name = "edhh_qtaSacc"
    Me.edhh_qtaSacc.NTSDbField = ""
    Me.edhh_qtaSacc.NTSFormat = "0"
    Me.edhh_qtaSacc.NTSForzaVisZoom = False
    Me.edhh_qtaSacc.NTSOldValue = ""
    Me.edhh_qtaSacc.Properties.Appearance.Options.UseTextOptions = True
    Me.edhh_qtaSacc.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.edhh_qtaSacc.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edhh_qtaSacc.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edhh_qtaSacc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edhh_qtaSacc.Properties.MaxLength = 65536
    Me.edhh_qtaSacc.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edhh_qtaSacc.Size = New System.Drawing.Size(64, 20)
    Me.edhh_qtaSacc.TabIndex = 3
    '
    'NtsLabel2
    '
    Me.NtsLabel2.AutoSize = True
    Me.NtsLabel2.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel2.Location = New System.Drawing.Point(168, 18)
    Me.NtsLabel2.Name = "NtsLabel2"
    Me.NtsLabel2.NTSDbField = ""
    Me.NtsLabel2.Size = New System.Drawing.Size(49, 13)
    Me.NtsLabel2.TabIndex = 4
    Me.NtsLabel2.Text = "Tipologia"
    Me.NtsLabel2.Tooltip = ""
    Me.NtsLabel2.UseMnemonic = False
    '
    'NtsLabel3
    '
    Me.NtsLabel3.AutoSize = True
    Me.NtsLabel3.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel3.Location = New System.Drawing.Point(168, 44)
    Me.NtsLabel3.Name = "NtsLabel3"
    Me.NtsLabel3.NTSDbField = ""
    Me.NtsLabel3.Size = New System.Drawing.Size(49, 13)
    Me.NtsLabel3.TabIndex = 8
    Me.NtsLabel3.Text = "Tipologia"
    Me.NtsLabel3.Tooltip = ""
    Me.NtsLabel3.UseMnemonic = False
    '
    'edhh_qtaCasse
    '
    Me.edhh_qtaCasse.Cursor = System.Windows.Forms.Cursors.Default
    Me.edhh_qtaCasse.Location = New System.Drawing.Point(98, 41)
    Me.edhh_qtaCasse.Name = "edhh_qtaCasse"
    Me.edhh_qtaCasse.NTSDbField = ""
    Me.edhh_qtaCasse.NTSFormat = "0"
    Me.edhh_qtaCasse.NTSForzaVisZoom = False
    Me.edhh_qtaCasse.NTSOldValue = ""
    Me.edhh_qtaCasse.Properties.Appearance.Options.UseTextOptions = True
    Me.edhh_qtaCasse.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.edhh_qtaCasse.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edhh_qtaCasse.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edhh_qtaCasse.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edhh_qtaCasse.Properties.MaxLength = 65536
    Me.edhh_qtaCasse.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edhh_qtaCasse.Size = New System.Drawing.Size(64, 20)
    Me.edhh_qtaCasse.TabIndex = 7
    '
    'NtsLabel4
    '
    Me.NtsLabel4.AutoSize = True
    Me.NtsLabel4.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel4.Location = New System.Drawing.Point(20, 44)
    Me.NtsLabel4.Name = "NtsLabel4"
    Me.NtsLabel4.NTSDbField = ""
    Me.NtsLabel4.Size = New System.Drawing.Size(71, 13)
    Me.NtsLabel4.TabIndex = 6
    Me.NtsLabel4.Text = "Qta Cassette"
    Me.NtsLabel4.Tooltip = ""
    Me.NtsLabel4.UseMnemonic = False
    '
    'edhh_codartCliForCasse
    '
    Me.edhh_codartCliForCasse.Cursor = System.Windows.Forms.Cursors.Default
    Me.edhh_codartCliForCasse.Location = New System.Drawing.Point(223, 41)
    Me.edhh_codartCliForCasse.Name = "edhh_codartCliForCasse"
    Me.edhh_codartCliForCasse.NTSDbField = ""
    Me.edhh_codartCliForCasse.NTSForzaVisZoom = False
    Me.edhh_codartCliForCasse.NTSOldValue = ""
    Me.edhh_codartCliForCasse.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edhh_codartCliForCasse.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edhh_codartCliForCasse.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edhh_codartCliForCasse.Properties.MaxLength = 65536
    Me.edhh_codartCliForCasse.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edhh_codartCliForCasse.Size = New System.Drawing.Size(100, 20)
    Me.edhh_codartCliForCasse.TabIndex = 5
    '
    'NtsLabel5
    '
    Me.NtsLabel5.AutoSize = True
    Me.NtsLabel5.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel5.Location = New System.Drawing.Point(168, 70)
    Me.NtsLabel5.Name = "NtsLabel5"
    Me.NtsLabel5.NTSDbField = ""
    Me.NtsLabel5.Size = New System.Drawing.Size(49, 13)
    Me.NtsLabel5.TabIndex = 12
    Me.NtsLabel5.Text = "Tipologia"
    Me.NtsLabel5.Tooltip = ""
    Me.NtsLabel5.UseMnemonic = False
    '
    'edhh_qtaCasso
    '
    Me.edhh_qtaCasso.Cursor = System.Windows.Forms.Cursors.Default
    Me.edhh_qtaCasso.Location = New System.Drawing.Point(98, 67)
    Me.edhh_qtaCasso.Name = "edhh_qtaCasso"
    Me.edhh_qtaCasso.NTSDbField = ""
    Me.edhh_qtaCasso.NTSFormat = "0"
    Me.edhh_qtaCasso.NTSForzaVisZoom = False
    Me.edhh_qtaCasso.NTSOldValue = ""
    Me.edhh_qtaCasso.Properties.Appearance.Options.UseTextOptions = True
    Me.edhh_qtaCasso.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.edhh_qtaCasso.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edhh_qtaCasso.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edhh_qtaCasso.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edhh_qtaCasso.Properties.MaxLength = 65536
    Me.edhh_qtaCasso.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edhh_qtaCasso.Size = New System.Drawing.Size(64, 20)
    Me.edhh_qtaCasso.TabIndex = 11
    '
    'NtsLabel6
    '
    Me.NtsLabel6.AutoSize = True
    Me.NtsLabel6.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel6.Location = New System.Drawing.Point(20, 70)
    Me.NtsLabel6.Name = "NtsLabel6"
    Me.NtsLabel6.NTSDbField = ""
    Me.NtsLabel6.Size = New System.Drawing.Size(65, 13)
    Me.NtsLabel6.TabIndex = 10
    Me.NtsLabel6.Text = "Qta Cassoni"
    Me.NtsLabel6.Tooltip = ""
    Me.NtsLabel6.UseMnemonic = False
    '
    'edhh_codartCliForCasso
    '
    Me.edhh_codartCliForCasso.Cursor = System.Windows.Forms.Cursors.Default
    Me.edhh_codartCliForCasso.Location = New System.Drawing.Point(223, 67)
    Me.edhh_codartCliForCasso.Name = "edhh_codartCliForCasso"
    Me.edhh_codartCliForCasso.NTSDbField = ""
    Me.edhh_codartCliForCasso.NTSForzaVisZoom = False
    Me.edhh_codartCliForCasso.NTSOldValue = ""
    Me.edhh_codartCliForCasso.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edhh_codartCliForCasso.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edhh_codartCliForCasso.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edhh_codartCliForCasso.Properties.MaxLength = 65536
    Me.edhh_codartCliForCasso.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edhh_codartCliForCasso.Size = New System.Drawing.Size(100, 20)
    Me.edhh_codartCliForCasso.TabIndex = 9
    '
    'NtsLabel7
    '
    Me.NtsLabel7.AutoSize = True
    Me.NtsLabel7.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel7.Location = New System.Drawing.Point(168, 96)
    Me.NtsLabel7.Name = "NtsLabel7"
    Me.NtsLabel7.NTSDbField = ""
    Me.NtsLabel7.Size = New System.Drawing.Size(49, 13)
    Me.NtsLabel7.TabIndex = 16
    Me.NtsLabel7.Text = "Tipologia"
    Me.NtsLabel7.Tooltip = ""
    Me.NtsLabel7.UseMnemonic = False
    '
    'edhh_qtaPedane
    '
    Me.edhh_qtaPedane.Cursor = System.Windows.Forms.Cursors.Default
    Me.edhh_qtaPedane.Location = New System.Drawing.Point(98, 93)
    Me.edhh_qtaPedane.Name = "edhh_qtaPedane"
    Me.edhh_qtaPedane.NTSDbField = ""
    Me.edhh_qtaPedane.NTSFormat = "0"
    Me.edhh_qtaPedane.NTSForzaVisZoom = False
    Me.edhh_qtaPedane.NTSOldValue = ""
    Me.edhh_qtaPedane.Properties.Appearance.Options.UseTextOptions = True
    Me.edhh_qtaPedane.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.edhh_qtaPedane.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edhh_qtaPedane.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edhh_qtaPedane.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edhh_qtaPedane.Properties.MaxLength = 65536
    Me.edhh_qtaPedane.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edhh_qtaPedane.Size = New System.Drawing.Size(64, 20)
    Me.edhh_qtaPedane.TabIndex = 15
    '
    'NtsLabel8
    '
    Me.NtsLabel8.AutoSize = True
    Me.NtsLabel8.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel8.Location = New System.Drawing.Point(20, 96)
    Me.NtsLabel8.Name = "NtsLabel8"
    Me.NtsLabel8.NTSDbField = ""
    Me.NtsLabel8.Size = New System.Drawing.Size(64, 13)
    Me.NtsLabel8.TabIndex = 14
    Me.NtsLabel8.Text = "Qta Pedane"
    Me.NtsLabel8.Tooltip = ""
    Me.NtsLabel8.UseMnemonic = False
    '
    'edhh_codartCliForPedane
    '
    Me.edhh_codartCliForPedane.Cursor = System.Windows.Forms.Cursors.Default
    Me.edhh_codartCliForPedane.Location = New System.Drawing.Point(223, 93)
    Me.edhh_codartCliForPedane.Name = "edhh_codartCliForPedane"
    Me.edhh_codartCliForPedane.NTSDbField = ""
    Me.edhh_codartCliForPedane.NTSForzaVisZoom = False
    Me.edhh_codartCliForPedane.NTSOldValue = ""
    Me.edhh_codartCliForPedane.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edhh_codartCliForPedane.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edhh_codartCliForPedane.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edhh_codartCliForPedane.Properties.MaxLength = 65536
    Me.edhh_codartCliForPedane.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edhh_codartCliForPedane.Size = New System.Drawing.Size(100, 20)
    Me.edhh_codartCliForPedane.TabIndex = 13
    '
    'NtsLabel9
    '
    Me.NtsLabel9.AutoSize = True
    Me.NtsLabel9.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel9.Location = New System.Drawing.Point(168, 122)
    Me.NtsLabel9.Name = "NtsLabel9"
    Me.NtsLabel9.NTSDbField = ""
    Me.NtsLabel9.Size = New System.Drawing.Size(49, 13)
    Me.NtsLabel9.TabIndex = 20
    Me.NtsLabel9.Text = "Tipologia"
    Me.NtsLabel9.Tooltip = ""
    Me.NtsLabel9.UseMnemonic = False
    '
    'edhh_qtaCope
    '
    Me.edhh_qtaCope.Cursor = System.Windows.Forms.Cursors.Default
    Me.edhh_qtaCope.Location = New System.Drawing.Point(98, 119)
    Me.edhh_qtaCope.Name = "edhh_qtaCope"
    Me.edhh_qtaCope.NTSDbField = ""
    Me.edhh_qtaCope.NTSFormat = "0"
    Me.edhh_qtaCope.NTSForzaVisZoom = False
    Me.edhh_qtaCope.NTSOldValue = ""
    Me.edhh_qtaCope.Properties.Appearance.Options.UseTextOptions = True
    Me.edhh_qtaCope.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.edhh_qtaCope.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edhh_qtaCope.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edhh_qtaCope.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edhh_qtaCope.Properties.MaxLength = 65536
    Me.edhh_qtaCope.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edhh_qtaCope.Size = New System.Drawing.Size(64, 20)
    Me.edhh_qtaCope.TabIndex = 19
    '
    'NtsLabel10
    '
    Me.NtsLabel10.AutoSize = True
    Me.NtsLabel10.BackColor = System.Drawing.Color.Transparent
    Me.NtsLabel10.Location = New System.Drawing.Point(20, 122)
    Me.NtsLabel10.Name = "NtsLabel10"
    Me.NtsLabel10.NTSDbField = ""
    Me.NtsLabel10.Size = New System.Drawing.Size(70, 13)
    Me.NtsLabel10.TabIndex = 18
    Me.NtsLabel10.Text = "Qta Coperchi"
    Me.NtsLabel10.Tooltip = ""
    Me.NtsLabel10.UseMnemonic = False
    '
    'edhh_codartCliForCope
    '
    Me.edhh_codartCliForCope.Cursor = System.Windows.Forms.Cursors.Default
    Me.edhh_codartCliForCope.Location = New System.Drawing.Point(223, 119)
    Me.edhh_codartCliForCope.Name = "edhh_codartCliForCope"
    Me.edhh_codartCliForCope.NTSDbField = ""
    Me.edhh_codartCliForCope.NTSForzaVisZoom = False
    Me.edhh_codartCliForCope.NTSOldValue = ""
    Me.edhh_codartCliForCope.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edhh_codartCliForCope.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edhh_codartCliForCope.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edhh_codartCliForCope.Properties.MaxLength = 65536
    Me.edhh_codartCliForCope.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edhh_codartCliForCope.Size = New System.Drawing.Size(100, 20)
    Me.edhh_codartCliForCope.TabIndex = 17
    '
    'CmdAnnulla
    '
    Me.CmdAnnulla.ImageText = ""
    Me.CmdAnnulla.Location = New System.Drawing.Point(62, 175)
    Me.CmdAnnulla.Name = "CmdAnnulla"
    Me.CmdAnnulla.Size = New System.Drawing.Size(100, 40)
    Me.CmdAnnulla.TabIndex = 21
    Me.CmdAnnulla.Text = "Anulla"
    '
    'FrmUsaCont
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
    Me.ClientSize = New System.Drawing.Size(368, 250)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(368, 250)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(368, 250)
    Me.PnCPNEPnMain.Controls.Add(Me.CmdAnnulla)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsLabel9)
    Me.PnCPNEPnMain.Controls.Add(Me.edhh_qtaCope)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsLabel10)
    Me.PnCPNEPnMain.Controls.Add(Me.edhh_codartCliForCope)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsLabel7)
    Me.PnCPNEPnMain.Controls.Add(Me.edhh_qtaPedane)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsLabel8)
    Me.PnCPNEPnMain.Controls.Add(Me.edhh_codartCliForPedane)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsLabel5)
    Me.PnCPNEPnMain.Controls.Add(Me.edhh_qtaCasso)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsLabel6)
    Me.PnCPNEPnMain.Controls.Add(Me.edhh_codartCliForCasso)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsLabel3)
    Me.PnCPNEPnMain.Controls.Add(Me.edhh_qtaCasse)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsLabel4)
    Me.PnCPNEPnMain.Controls.Add(Me.edhh_codartCliForCasse)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsLabel2)
    Me.PnCPNEPnMain.Controls.Add(Me.edhh_qtaSacc)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsLabel1)
    Me.PnCPNEPnMain.Controls.Add(Me.edhh_codartCliForSacc)
    Me.PnCPNEPnMain.Controls.Add(Me.CmdOk)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FrmUsaCont"
    Me.Text = "DETTAGLIO CONTENITORI"
    CType(Me.edhh_codartCliForSacc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edhh_qtaSacc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edhh_qtaCasse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edhh_codartCliForCasse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edhh_qtaCasso.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edhh_codartCliForCasso.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edhh_qtaPedane.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edhh_codartCliForPedane.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edhh_qtaCope.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edhh_codartCliForCope.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).EndInit()
Me.PnCPNEPnMain.ResumeLayout(False)
Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
#End Region
  Private components As System.ComponentModel.IContainer
  Public oCleHh As CLBVEBOLL
  Public dsHh As New DataSet
  Public oCallParams As CLE__CLDP
  Public dcHh As BindingSource = New BindingSource
  Public dcHhGr As BindingSource = New BindingSource

  Public Overridable Sub Bindcontrols()
    Try
      '-------------------------------------------------
      'se i controlli erano già  stati precedentemente collegati, li scollego
      NTSFormClearDataBinding(Me)

      edhh_qtaCope.NTSDbField = "hhusacont.hh_qtacope"
      edhh_codartCliForCope.NTSDbField = "hhusacont.hh_codartcliforcope"
      edhh_qtaPedane.NTSDbField = "hhusacont.hh_qtapedane"
      edhh_codartCliForPedane.NTSDbField = "hhusacont.hh_codartcliforpedane"
      edhh_qtaCasso.NTSDbField = "hhusacont.hh_qtacasso"
      edhh_codartCliForCasso.NTSDbField = "hhusacont.hh_codartcliforcasso"
      edhh_qtaCasse.NTSDbField = "hhusacont.hh_qtacasse"
      edhh_codartCliForCasse.NTSDbField = "hhusacont.hh_codartcliforcasse"
      edhh_qtaSacc.NTSDbField = "hhusacont.hh_qtasacc"
      edhh_codartCliForSacc.NTSDbField = "hhusacont.hh_codartcliforsacc"
      edhh_qtaCope.NTSSetParam(oMenu, oApp.Tr(Me, 131203227410310605, "Coperchi"), "0")
      edhh_codartCliForCope.NTSSetParam(oMenu, oApp.Tr(Me, 131203227410330619, "Coperchi"), 18, True)
      edhh_qtaPedane.NTSSetParam(oMenu, oApp.Tr(Me, 131203227410350634, "Pedane"), "0")
      edhh_codartCliForPedane.NTSSetParam(oMenu, oApp.Tr(Me, 131203227410370648, "Pedane"), 18, True)
      edhh_qtaCasso.NTSSetParam(oMenu, oApp.Tr(Me, 131203227410390803, "Cassoni"), "0")
      edhh_codartCliForCasso.NTSSetParam(oMenu, oApp.Tr(Me, 131203227410410769, "Cassoni"), 18, True)
      edhh_qtaCasse.NTSSetParam(oMenu, oApp.Tr(Me, 131203227410430787, "Casse"), "0")
      edhh_codartCliForCasse.NTSSetParam(oMenu, oApp.Tr(Me, 131203227410450798, "Casse"), 18, True)
      edhh_qtaSacc.NTSSetParam(oMenu, oApp.Tr(Me, 131203227410470812, "Sacchetti"), "0")
      edhh_codartCliForSacc.NTSSetParam(oMenu, oApp.Tr(Me, 131203227410490830, "Sacchetti"), 18, True)


      edhh_codartCliForCope.NTSForzaVisZoom = True
      edhh_codartCliForPedane.NTSForzaVisZoom = True
      edhh_codartCliForCasso.NTSForzaVisZoom = True
      edhh_codartCliForCasse.NTSForzaVisZoom = True
      edhh_codartCliForSacc.NTSForzaVisZoom = True



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

  Private Sub FrmUsaCont_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
TRY
    Select Case e.KeyCode
      Case Keys.F5
        Dim StrControllo As String = NTSFindControlFocused(Me).Name
        If StrControllo = "edhh_codartCliForCasse" Or StrControllo = "edhh_codartCliForCasso" Or StrControllo = "edhh_codartCliForCope" Or StrControllo = "edhh_codartCliForPedane" Or StrControllo = "edhh_codartCliForSacc" Then
          StrControllo = Mid(StrControllo, 18)
          Dim oParam As New CLE__CLDP
          NTSZOOM.strIn = ""
          oParam.nMagaz = 0
          oParam.nListino = 0
          oParam.lContoCF = CInt(oCleHh.dttET.Rows(0)!et_conto)
          oParam.strBanc1 = oMenu.GetSettingBusDitt(oCleHh.strDittaCorrente, "CPNE", "BNVEBOLL", "OPZIONI", "Marca" & StrControllo, "1", " ", "1")
          NTSZOOM.ZoomStrIn("ZOOMARTICO", DittaCorrente, oParam)
          If NTSZOOM.strIn <> "" Then
            oCleHh.dtUsaCont1Riga.Rows(0).Item("hh_codart" & StrControllo) = NTSZOOM.strIn
          End If

        End If
    End Select

Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub FRMYYHHHH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
TRY
    dsHh = oCleHh.dsShared
    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = oCleHh.dtUsaCont1Riga
    Bindcontrols()
    GctlSetRoules()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub


  Private Sub CmdAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles CmdAnnulla.Click
TRY
    Me.Close()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub CmdOk_Click(sender As System.Object, e As System.EventArgs) Handles CmdOk.Click
TRY
    If oCleHh.CPNEOkCont Then
      CmdOk.Enabled = False
      Me.Close()
    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
End Class
