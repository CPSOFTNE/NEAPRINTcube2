Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Imports System.Windows.Forms
Public Class FrmNOTE
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

  Public WithEvents edxx_note As NTSInformatica.NTSTextBoxStr

  Public Sub InitializeComponent()
    Me.edxx_note = New NTSInformatica.NTSTextBoxStr()
    CType(Me.edxx_note.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
    'edxx_note
    '
    Me.edxx_note.Cursor = System.Windows.Forms.Cursors.Default
    Me.edxx_note.EditValue = ""
    Me.edxx_note.Location = New System.Drawing.Point(12, 12)
    Me.edxx_note.Name = "edxx_note"
    Me.edxx_note.NTSDbField = ""
    Me.edxx_note.NTSForzaVisZoom = False
    Me.edxx_note.NTSOldValue = ""
    Me.edxx_note.Properties.Appearance.BackColor = System.Drawing.Color.White
    Me.edxx_note.Properties.Appearance.Options.UseBackColor = True
    Me.edxx_note.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
    Me.edxx_note.Properties.AppearanceDisabled.Options.UseForeColor = True
    Me.edxx_note.Properties.AutoHeight = False
    Me.edxx_note.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
    Me.edxx_note.Properties.MaxLength = 65536
    Me.edxx_note.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.edxx_note.Size = New System.Drawing.Size(656, 439)
    Me.edxx_note.TabIndex = 58
    '
    'FrmNOTE
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
    Me.ClientSize = New System.Drawing.Size(680, 463)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(680, 463)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(680, 463)
    Me.PnCPNEPnMain.Controls.Add(Me.edxx_note)
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FrmNOTE"
    Me.Text = "NOTE"
    CType(Me.edxx_note.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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


      edxx_note.NTSSetParam(oMenu, oApp.Tr(Me, 130947463517944662, "Note"), 25)



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

  Private Sub FrmNOTE_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
TRY
    ValidaLastControl()
    CType(oCleHh, CLBORGSOR).strSalvaNote = Me.edxx_note.Text
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub FRMNOTE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
TRY

    oCleHh.bHasChangesET = True

    'dsHh = oCleHh.dsShared
    'dcHh = Nothing
    'dcHh = New BindingSource()
    'dcHh.DataSource = dsHh.Tables("TESTA")

    'AggGriglia()
    'Bindcontrols()

    'grv.....NTSAllowInsert = False
    'grv.....NTSAllowDelete = False 
    'grv.....Enabled = False 


    GctlSetRoules()
    Me.edxx_note.Text = CType(oCleHh, CLBORGSOR).strSalvaNote
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  'Private Sub AggGriglia()
  '  dcHhGr = Nothing
  '  dcHhGr = New BindingSource()
  '  dcHhGr.DataSource = dsHh.Tables("...")
  '  'gr......DataSource = dcHhGr
  'End Sub
End Class
