Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Imports System.Windows.Forms
Public Class FrmCUP
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

  Public WithEvents lbEt_cup As NTSInformatica.NTSLabel
  Public WithEvents lbEt_cig As NTSInformatica.NTSLabel
  Public WithEvents edEt_cup As NTSInformatica.NTSTextBoxStr
  Public WithEvents edEt_cig As NTSInformatica.NTSTextBoxStr
  Public WithEvents lbEt_riferimpa As NTSInformatica.NTSLabel
  Public WithEvents edEt_riferimpa As NTSInformatica.NTSTextBoxStr

  Public Sub InitializeComponent()
    Me.edEt_riferimpa = New NTSInformatica.NTSTextBoxStr()
    Me.lbEt_riferimpa = New NTSInformatica.NTSLabel()
    Me.edEt_cig = New NTSInformatica.NTSTextBoxStr()
    Me.edEt_cup = New NTSInformatica.NTSTextBoxStr()
    Me.lbEt_cig = New NTSInformatica.NTSLabel()
    Me.lbEt_cup = New NTSInformatica.NTSLabel()
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edEt_riferimpa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edEt_cig.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.edEt_cup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
    'edEt_riferimpa
    '
    Me.edEt_riferimpa.Cursor = System.Windows.Forms.Cursors.Default
    Me.edEt_riferimpa.EditValue = ""
    Me.edEt_riferimpa.Location = New System.Drawing.Point(159, 66)
    Me.edEt_riferimpa.Name = "edEt_riferimpa"
    Me.edEt_riferimpa.NTSDbField = ""
    Me.edEt_riferimpa.NTSForzaVisZoom = False
    Me.edEt_riferimpa.NTSOldValue = ""
    Me.edEt_riferimpa.Properties.Appearance.BackColor = System.Drawing.Color.White
    Me.edEt_riferimpa.Properties.Appearance.Options.UseBackColor = True
    Me.edEt_riferimpa.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edEt_riferimpa.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edEt_riferimpa.Properties.AutoHeight = False
    Me.edEt_riferimpa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edEt_riferimpa.Properties.MaxLength = 65536
    Me.edEt_riferimpa.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edEt_riferimpa.Size = New System.Drawing.Size(159, 20)
    Me.edEt_riferimpa.TabIndex = 58
    '
    'lbEt_riferimpa
    '
    Me.lbEt_riferimpa.BackColor = System.Drawing.Color.Transparent
    Me.lbEt_riferimpa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbEt_riferimpa.Location = New System.Drawing.Point(38, 69)
    Me.lbEt_riferimpa.Name = "lbEt_riferimpa"
    Me.lbEt_riferimpa.NTSDbField = ""
    Me.lbEt_riferimpa.Size = New System.Drawing.Size(113, 13)
    Me.lbEt_riferimpa.TabIndex = 57
    Me.lbEt_riferimpa.Text = "Riferimento ordine"
    Me.lbEt_riferimpa.Tooltip = ""
    Me.lbEt_riferimpa.UseMnemonic = False
    '
    'edEt_cig
    '
    Me.edEt_cig.Cursor = System.Windows.Forms.Cursors.Default
    Me.edEt_cig.EditValue = ""
    Me.edEt_cig.Location = New System.Drawing.Point(159, 44)
    Me.edEt_cig.Name = "edEt_cig"
    Me.edEt_cig.NTSDbField = ""
    Me.edEt_cig.NTSForzaVisZoom = False
    Me.edEt_cig.NTSOldValue = ""
    Me.edEt_cig.Properties.Appearance.BackColor = System.Drawing.Color.White
    Me.edEt_cig.Properties.Appearance.Options.UseBackColor = True
    Me.edEt_cig.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edEt_cig.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edEt_cig.Properties.AutoHeight = False
    Me.edEt_cig.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edEt_cig.Properties.MaxLength = 65536
    Me.edEt_cig.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edEt_cig.Size = New System.Drawing.Size(159, 20)
    Me.edEt_cig.TabIndex = 56
    '
    'edEt_cup
    '
    Me.edEt_cup.Cursor = System.Windows.Forms.Cursors.Default
    Me.edEt_cup.EditValue = ""
    Me.edEt_cup.Location = New System.Drawing.Point(159, 22)
    Me.edEt_cup.Name = "edEt_cup"
    Me.edEt_cup.NTSDbField = ""
    Me.edEt_cup.NTSForzaVisZoom = False
    Me.edEt_cup.NTSOldValue = ""
    Me.edEt_cup.Properties.Appearance.BackColor = System.Drawing.Color.White
    Me.edEt_cup.Properties.Appearance.Options.UseBackColor = True
    Me.edEt_cup.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edEt_cup.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edEt_cup.Properties.AutoHeight = False
    Me.edEt_cup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edEt_cup.Properties.MaxLength = 65536
    Me.edEt_cup.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edEt_cup.Size = New System.Drawing.Size(159, 20)
    Me.edEt_cup.TabIndex = 55
    '
    'lbEt_cig
    '
    Me.lbEt_cig.BackColor = System.Drawing.Color.Transparent
    Me.lbEt_cig.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbEt_cig.Location = New System.Drawing.Point(38, 47)
    Me.lbEt_cig.Name = "lbEt_cig"
    Me.lbEt_cig.NTSDbField = ""
    Me.lbEt_cig.Size = New System.Drawing.Size(37, 13)
    Me.lbEt_cig.TabIndex = 54
    Me.lbEt_cig.Text = "Cig"
    Me.lbEt_cig.Tooltip = ""
    Me.lbEt_cig.UseMnemonic = False
    '
    'lbEt_cup
    '
    Me.lbEt_cup.BackColor = System.Drawing.Color.Transparent
    Me.lbEt_cup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbEt_cup.Location = New System.Drawing.Point(38, 25)
    Me.lbEt_cup.Name = "lbEt_cup"
    Me.lbEt_cup.NTSDbField = ""
    Me.lbEt_cup.Size = New System.Drawing.Size(47, 13)
    Me.lbEt_cup.TabIndex = 53
    Me.lbEt_cup.Text = "Cup"
    Me.lbEt_cup.Tooltip = ""
    Me.lbEt_cup.UseMnemonic = False
    '
    'FrmCUP
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
    Me.ClientSize = New System.Drawing.Size(359, 117)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(359, 117)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(359, 117)
    Me.PnCPNEPnMain.Controls.Add(Me.edEt_riferimpa)
    Me.PnCPNEPnMain.Controls.Add(Me.lbEt_riferimpa)
    Me.PnCPNEPnMain.Controls.Add(Me.edEt_cig)
    Me.PnCPNEPnMain.Controls.Add(Me.edEt_cup)
    Me.PnCPNEPnMain.Controls.Add(Me.lbEt_cig)
    Me.PnCPNEPnMain.Controls.Add(Me.lbEt_cup)
    Me.Cursor = System.Windows.Forms.Cursors.Default
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FrmCUP"
    Me.Text = "PUBBLICA AMMINISTRAZIONE"
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edEt_riferimpa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edEt_cig.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.edEt_cup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).EndInit()
Me.PnCPNEPnMain.ResumeLayout(False)
Me.ResumeLayout(False)

  End Sub
#End Region
  Private components As System.ComponentModel.IContainer
  Public oCleHh As CLEORGSOR
  Public dsHh As New DataSet
  Public oCallParams As CLE__CLDP
  Public dcHh As BindingSource = New BindingSource
  Public dcHhGr As BindingSource = New BindingSource

  Public Overridable Sub Bindcontrols()
    Try
      '-------------------------------------------------
      'se i controlli erano già  stati precedentemente collegati, li scollego
      NTSFormClearDataBinding(Me)

      edEt_riferimpa.NTSDbField = "TESTA.et_riferimpa"
      edEt_cig.NTSDbField = "TESTA.et_cig"
      edEt_cup.NTSDbField = "TESTA.et_cup"
      edEt_riferimpa.NTSSetParam(oMenu, oApp.Tr(Me, 130947463517944662, "Riferimento ordine"), 100)
      edEt_cig.NTSSetParam(oMenu, oApp.Tr(Me, 130947463518257160, "Cig"), 10)
      edEt_cup.NTSSetParam(oMenu, oApp.Tr(Me, 130947463518413412, "Cup"), 15)


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

  Private Sub FrmCUP_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
TRY
    ValidaLastControl()
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
