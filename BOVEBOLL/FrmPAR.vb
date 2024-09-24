Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Imports System.Windows.Forms
Public Class FrmPAR
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
  Public Overridable Sub InitEntity(ByRef cleSt As CLEVEBOLL)
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

  Public WithEvents lbEt_numpar As NTSInformatica.NTSLabel
  Public WithEvents lbEt_datpar As NTSInformatica.NTSLabel
  Public WithEvents lbet_idpick As NTSInformatica.NTSLabel
  Public WithEvents lbEt_caustra As NTSInformatica.NTSLabel
  Public WithEvents lbEt_numpar1 As NTSInformatica.NTSLabel
  Public WithEvents lbet_Numord As NTSInformatica.NTSLabel

  Public Sub InitializeComponent()
    Me.lbet_idpick = New NTSInformatica.NTSLabel()
    Me.lbEt_datpar = New NTSInformatica.NTSLabel()
    Me.lbEt_numpar = New NTSInformatica.NTSLabel()
    Me.lbEt_caustra = New NTSInformatica.NTSLabel()
    Me.edEt_numpar = New NTSInformatica.NTSTextBoxNum()
    Me.edEt_datpar = New NTSInformatica.NTSTextBoxData()
    Me.edEt_idpick = New NTSInformatica.NTSTextBoxNum()
    Me.edEt_caustra = New NTSInformatica.NTSTextBoxNum()
    Me.lbXx_fornitore = New NTSInformatica.NTSLabel()
    Me.lbXx_caustra = New NTSInformatica.NTSLabel()
    Me.lbEt_numpar1 = New NTSInformatica.NTSLabel()
    Me.edEt_andescr1 = New NTSInformatica.NTSTextBoxStr()
    Me.lbet_Numord = New NTSInformatica.NTSLabel()
    Me.edEt_andescr2 = New NTSInformatica.NTSTextBoxStr()
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edEt_numpar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edEt_datpar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edEt_idpick.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edEt_caustra.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edEt_andescr1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edEt_andescr2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
    'lbet_idpick
    '
    Me.lbet_idpick.BackColor = System.Drawing.Color.Transparent
    Me.lbet_idpick.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbet_idpick.Location = New System.Drawing.Point(12, 87)
    Me.lbet_idpick.Name = "lbet_idpick"
    Me.lbet_idpick.NTSDbField = ""
    Me.lbet_idpick.Size = New System.Drawing.Size(185, 20)
    Me.lbet_idpick.TabIndex = 57
    Me.lbet_idpick.Text = "Fornitore"
    Me.lbet_idpick.Tooltip = ""
    Me.lbet_idpick.UseMnemonic = False
    '
    'lbEt_datpar
    '
    Me.lbEt_datpar.BackColor = System.Drawing.Color.Transparent
    Me.lbEt_datpar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbEt_datpar.Location = New System.Drawing.Point(12, 65)
    Me.lbEt_datpar.Name = "lbEt_datpar"
    Me.lbEt_datpar.NTSDbField = ""
    Me.lbEt_datpar.Size = New System.Drawing.Size(113, 22)
    Me.lbEt_datpar.TabIndex = 54
    Me.lbEt_datpar.Text = "Data Documento"
    Me.lbEt_datpar.Tooltip = ""
    Me.lbEt_datpar.UseMnemonic = False
    '
    'lbEt_numpar
    '
    Me.lbEt_numpar.BackColor = System.Drawing.Color.Transparent
    Me.lbEt_numpar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbEt_numpar.Location = New System.Drawing.Point(12, 43)
    Me.lbEt_numpar.Name = "lbEt_numpar"
    Me.lbEt_numpar.NTSDbField = ""
    Me.lbEt_numpar.Size = New System.Drawing.Size(135, 17)
    Me.lbEt_numpar.TabIndex = 53
    Me.lbEt_numpar.Text = "Numero Documento"
    Me.lbEt_numpar.Tooltip = ""
    Me.lbEt_numpar.UseMnemonic = False
    '
    'lbEt_caustra
    '
    Me.lbEt_caustra.BackColor = System.Drawing.Color.Transparent
    Me.lbEt_caustra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbEt_caustra.Location = New System.Drawing.Point(12, 109)
    Me.lbEt_caustra.Name = "lbEt_caustra"
    Me.lbEt_caustra.NTSDbField = ""
    Me.lbEt_caustra.Size = New System.Drawing.Size(185, 20)
    Me.lbEt_caustra.TabIndex = 58
    Me.lbEt_caustra.Text = "Causale Trasporto"
    Me.lbEt_caustra.Tooltip = ""
    Me.lbEt_caustra.UseMnemonic = False
    '
    'edEt_numpar
    '
    Me.edEt_numpar.Cursor = System.Windows.Forms.Cursors.Default
    Me.edEt_numpar.Location = New System.Drawing.Point(203, 43)
    Me.edEt_numpar.Name = "edEt_numpar"
    Me.edEt_numpar.NTSDbField = ""
    Me.edEt_numpar.NTSFormat = "0"
    Me.edEt_numpar.NTSForzaVisZoom = False
    Me.edEt_numpar.NTSOldValue = ""
    Me.edEt_numpar.Properties.Appearance.Options.UseTextOptions = True
    Me.edEt_numpar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.edEt_numpar.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edEt_numpar.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edEt_numpar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edEt_numpar.Properties.MaxLength = 65536
    Me.edEt_numpar.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edEt_numpar.Size = New System.Drawing.Size(100, 20)
    Me.edEt_numpar.TabIndex = 59
    '
    'edEt_datpar
    '
    Me.edEt_datpar.Cursor = System.Windows.Forms.Cursors.Default
    Me.edEt_datpar.Location = New System.Drawing.Point(203, 65)
    Me.edEt_datpar.Name = "edEt_datpar"
    Me.edEt_datpar.NTSDbField = ""
    Me.edEt_datpar.NTSForzaVisZoom = False
    Me.edEt_datpar.NTSOldValue = ""
    Me.edEt_datpar.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edEt_datpar.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edEt_datpar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edEt_datpar.Properties.MaxLength = 65536
    Me.edEt_datpar.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edEt_datpar.Size = New System.Drawing.Size(100, 20)
    Me.edEt_datpar.TabIndex = 60
    '
    'edEt_idpick
    '
    Me.edEt_idpick.Cursor = System.Windows.Forms.Cursors.Default
    Me.edEt_idpick.Location = New System.Drawing.Point(203, 87)
    Me.edEt_idpick.Name = "edEt_idpick"
    Me.edEt_idpick.NTSDbField = ""
    Me.edEt_idpick.NTSFormat = "0"
    Me.edEt_idpick.NTSForzaVisZoom = False
    Me.edEt_idpick.NTSOldValue = ""
    Me.edEt_idpick.Properties.Appearance.Options.UseTextOptions = True
    Me.edEt_idpick.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.edEt_idpick.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edEt_idpick.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edEt_idpick.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edEt_idpick.Properties.MaxLength = 65536
    Me.edEt_idpick.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edEt_idpick.Size = New System.Drawing.Size(100, 20)
    Me.edEt_idpick.TabIndex = 61
    '
    'edEt_caustra
    '
    Me.edEt_caustra.Cursor = System.Windows.Forms.Cursors.Default
    Me.edEt_caustra.Location = New System.Drawing.Point(203, 109)
    Me.edEt_caustra.Name = "edEt_caustra"
    Me.edEt_caustra.NTSDbField = ""
    Me.edEt_caustra.NTSFormat = "0"
    Me.edEt_caustra.NTSForzaVisZoom = False
    Me.edEt_caustra.NTSOldValue = ""
    Me.edEt_caustra.Properties.Appearance.Options.UseTextOptions = True
    Me.edEt_caustra.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    Me.edEt_caustra.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edEt_caustra.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edEt_caustra.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edEt_caustra.Properties.MaxLength = 65536
    Me.edEt_caustra.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edEt_caustra.Size = New System.Drawing.Size(100, 20)
    Me.edEt_caustra.TabIndex = 62
    '
    'lbXx_fornitore
    '
    Me.lbXx_fornitore.BackColor = System.Drawing.Color.Transparent
    Me.lbXx_fornitore.Location = New System.Drawing.Point(327, 93)
    Me.lbXx_fornitore.Name = "lbXx_fornitore"
    Me.lbXx_fornitore.NTSDbField = ""
    Me.lbXx_fornitore.Size = New System.Drawing.Size(258, 14)
    Me.lbXx_fornitore.TabIndex = 63
    Me.lbXx_fornitore.Tooltip = ""
    Me.lbXx_fornitore.UseMnemonic = False
    '
    'lbXx_caustra
    '
    Me.lbXx_caustra.BackColor = System.Drawing.Color.Transparent
    Me.lbXx_caustra.Location = New System.Drawing.Point(327, 115)
    Me.lbXx_caustra.Name = "lbXx_caustra"
    Me.lbXx_caustra.NTSDbField = ""
    Me.lbXx_caustra.Size = New System.Drawing.Size(258, 14)
    Me.lbXx_caustra.TabIndex = 64
    Me.lbXx_caustra.Tooltip = ""
    Me.lbXx_caustra.UseMnemonic = False
    '
    'lbEt_numpar1
    '
    Me.lbEt_numpar1.BackColor = System.Drawing.Color.Transparent
    Me.lbEt_numpar1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbEt_numpar1.Location = New System.Drawing.Point(12, 21)
    Me.lbEt_numpar1.Name = "lbEt_numpar1"
    Me.lbEt_numpar1.NTSDbField = ""
    Me.lbEt_numpar1.Size = New System.Drawing.Size(190, 22)
    Me.lbEt_numpar1.TabIndex = 65
    Me.lbEt_numpar1.Text = "Numero Documento(1ma Parte)"
    Me.lbEt_numpar1.Tooltip = ""
    Me.lbEt_numpar1.UseMnemonic = False
    '
    'edEt_andescr1
    '
    Me.edEt_andescr1.Cursor = System.Windows.Forms.Cursors.Default
    Me.edEt_andescr1.Location = New System.Drawing.Point(203, 21)
    Me.edEt_andescr1.Name = "edEt_andescr1"
    Me.edEt_andescr1.NTSDbField = ""
    Me.edEt_andescr1.NTSForzaVisZoom = False
    Me.edEt_andescr1.NTSOldValue = ""
    Me.edEt_andescr1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edEt_andescr1.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edEt_andescr1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edEt_andescr1.Properties.MaxLength = 65536
    Me.edEt_andescr1.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edEt_andescr1.Size = New System.Drawing.Size(100, 20)
    Me.edEt_andescr1.TabIndex = 66
    '
    'lbet_Numord
    '
    Me.lbet_Numord.BackColor = System.Drawing.Color.Transparent
    Me.lbet_Numord.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbet_Numord.Location = New System.Drawing.Point(327, 21)
    Me.lbet_Numord.Name = "lbet_Numord"
    Me.lbet_Numord.NTSDbField = ""
    Me.lbet_Numord.Size = New System.Drawing.Size(135, 17)
    Me.lbet_Numord.TabIndex = 67
    Me.lbet_Numord.Text = "Numero Ordine"
    Me.lbet_Numord.Tooltip = ""
    Me.lbet_Numord.UseMnemonic = False
    '
    'edEt_andescr2
    '
    Me.edEt_andescr2.Cursor = System.Windows.Forms.Cursors.Default
    Me.edEt_andescr2.Location = New System.Drawing.Point(457, 21)
    Me.edEt_andescr2.Name = "edEt_andescr2"
    Me.edEt_andescr2.NTSDbField = ""
    Me.edEt_andescr2.NTSForzaVisZoom = False
    Me.edEt_andescr2.NTSOldValue = ""
    Me.edEt_andescr2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edEt_andescr2.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edEt_andescr2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edEt_andescr2.Properties.MaxLength = 65536
    Me.edEt_andescr2.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edEt_andescr2.Size = New System.Drawing.Size(100, 20)
    Me.edEt_andescr2.TabIndex = 68
    '
    'FrmPAR
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
    Me.ClientSize = New System.Drawing.Size(607, 165)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(607, 165)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(607, 165)
    Me.PnCPNEPnMain.Controls.Add(Me.edEt_andescr2)
    Me.PnCPNEPnMain.Controls.Add(Me.lbet_Numord)
    Me.PnCPNEPnMain.Controls.Add(Me.edEt_andescr1)
    Me.PnCPNEPnMain.Controls.Add(Me.lbEt_numpar1)
    Me.PnCPNEPnMain.Controls.Add(Me.lbXx_caustra)
    Me.PnCPNEPnMain.Controls.Add(Me.lbXx_fornitore)
    Me.PnCPNEPnMain.Controls.Add(Me.edEt_caustra)
    Me.PnCPNEPnMain.Controls.Add(Me.edEt_idpick)
    Me.PnCPNEPnMain.Controls.Add(Me.edEt_datpar)
    Me.PnCPNEPnMain.Controls.Add(Me.edEt_numpar)
    Me.PnCPNEPnMain.Controls.Add(Me.lbEt_caustra)
    Me.PnCPNEPnMain.Controls.Add(Me.lbet_idpick)
    Me.PnCPNEPnMain.Controls.Add(Me.lbEt_datpar)
    Me.PnCPNEPnMain.Controls.Add(Me.lbEt_numpar)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FrmPAR"
    Me.Text = "PARTITA DDT RICEVUTO"
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edEt_numpar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edEt_datpar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edEt_idpick.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edEt_caustra.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edEt_andescr1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edEt_andescr2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).EndInit()
Me.PnCPNEPnMain.ResumeLayout(False)
Me.ResumeLayout(False)

  End Sub
#End Region
  Private components As System.ComponentModel.IContainer
  Public oCleHh As CLEVEBOLL
  Public dsHh As New DataSet
  Public oCallParams As CLE__CLDP
  Public dcHh As BindingSource = New BindingSource
  Public dcHhGr As BindingSource = New BindingSource

  Public Overridable Sub Bindcontrols()
    Try
      '-------------------------------------------------
      'se i controlli erano già  stati precedentemente collegati, li scollego
      NTSFormClearDataBinding(Me)

      edEt_numpar.NTSDbField = "TESTA.et_numpar"
      edEt_datpar.NTSDbField = "TESTA.et_datpar"
      edEt_idpick.NTSDbField = "TESTA.et_idpick"
      edEt_caustra.NTSDbField = "TESTA.et_caustra"
      lbXx_caustra.NTSDbField = "TESTA.Xx_caustra"
      lbXx_fornitore.NTSDbField = "TESTA.Xx_fornitore"
      edEt_andescr2.NTSDbField = "TESTA.et_andescr2"
      edEt_andescr1.NTSDbField = "TESTA.et_andescr1"

      edEt_andescr2.NTSSetParam(oMenu, oApp.Tr(Me, 131299014592975620, "Ordine"), 15)
      edEt_andescr1.NTSSetParam(oMenu, oApp.Tr(Me, 131299014592995634, "NumDoc1"), 10)

      edEt_caustra.NTSSetParamTabe(oMenu, oApp.Tr(Me, 131285944189294183, "Causale trasporto"), tabcaum)
      'edEt_idpick.NTSSetParamTabe(oMenu, oApp.Tr(Me, 131285944189434286, "Fornitore"), tabanagraf)
      edEt_idpick.NTSSetParam(oMenu, oApp.Tr(Me, 131285944189434286, "Fornitore"))
      edEt_idpick.NTSForzaVisZoom = True
      edEt_datpar.NTSSetParam(oMenu, oApp.Tr(Me, 131285944189444293, "Data Partita"), True)
      edEt_numpar.NTSSetParam(oMenu, oApp.Tr(Me, 131285944189454300, "Numero Partita"))


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

  Private Sub FrmCUP_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
TRY
    ValidaLastControl()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub FrmPAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
TRY
    Dim oParam As New CLE__CLDP
    If Me.edEt_idpick.Focused Then
      If e.KeyCode = Keys.F5 Then

        oMenu.SaveSettingBus("BSVEBOLL", "PERS", ".", "CPNEFiltraFornXCliente", dsHh.Tables("testa").Rows(0)!et_conto.ToString, False, False, False, "")

        Me.SetFastZoom(Me.edEt_idpick.Text, oParam)    'abilito la gestione dello zoom veloce
        Me.NTSZOOM.strIn = Me.edEt_idpick.Text
        oParam.bVisGriglia = True
        oParam.bTipoProposto = True
        oParam.nMastro = 0
        oParam.strTipo = "F"

        Me.NTSZOOM.ZoomStrIn("ZOOMANAGRA", Me.DittaCorrente, oParam)
        If Me.NTSZOOM.strIn <> Me.edEt_idpick.Text Then Me.edEt_idpick.NTSTextDB = Me.NTSZOOM.strIn



        oMenu.SaveSettingBus("BSVEBOLL", "PERS", ".", "CPNEFiltraFornXCliente", "0", False, False, False, "")
        'Return
      End If
    Else

    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub



  Private Sub FRMCUP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
TRY

    oCleHh.bHasChangesET = True

    dsHh = oCleHh.dsShared
    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = dsHh.Tables("TESTA")

    AggGriglia()
    Bindcontrols()

    'grv.....NTSAllowInsert = False
    'grv.....NTSAllowDelete = False 
    'grv.....Enabled = False 


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
    dcHhGr.DataSource = dsHh.Tables("...")
    'gr......DataSource = dcHhGr
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
End Class
