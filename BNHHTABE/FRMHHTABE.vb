Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Public Class FRMHHTABE
#Region "Standard"
  Private Moduli_P As Integer = bsModAll
  Private ModuliExt_P As Integer = bsModExtAll
  Private ModuliSup_P As Integer = 0
  Private ModuliSupExt_P As Integer = 0
  Private ModuliPtn_P As Integer = 0
  Private ModuliPtnExt_P As Integer = 0

  Dim IntTipoStampa As Integer = 0 ' 0 = video, 1 = carta

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

    '------------------------------------------------
    'creo e attivo l'entity e inizializzo la funzione che dovrÃ  rilevare gli eventi dall'ENTITY
    Dim strErr As String = ""
    Dim oTmp As Object = Nothing
    If CLN__STD.NTSIstanziaDll(oApp.ServerDir, oApp.NetDir, "BNHHTABE", "BEHHTABE", oTmp, strErr, False, "", "") = False Then
      oApp.MsgBoxErr(oApp.Tr(Me, 128271029889882656, "ERRORE in fase di creazione Entity:" & vbCrLf & "|" & strErr & "|"))
      Return False
    End If
    oCleHh = CType(oTmp, CLEHHTABE)
    oCleHh.AssociaDs(dsHh)
    oCleHh.OMenu = oMenu
    '------------------------------------------------
    
    AddHandler oCleHh.RemoteEvent, AddressOf GestisciEventiEntity
    If oCleHh.Init(oApp, NTSScript, oMenu.oCleComm, "", False, "", "") = False Then Return False

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

  Public Sub InitializeComponent()
    Me.NtsPanel1 = New NTSInformatica.NTSPanel()
    Me.cmdFirme = New NTSInformatica.NTSButton()
    Me.cmdPostille = New NTSInformatica.NTSButton()
    Me.cmdPreamboli = New NTSInformatica.NTSButton()
    Me.cmdUM = New NTSInformatica.NTSButton()
    CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.NtsPanel1.SuspendLayout()
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
    Me.NtsPanel1.Controls.Add(Me.cmdUM)
    Me.NtsPanel1.Controls.Add(Me.cmdPreamboli)
    Me.NtsPanel1.Controls.Add(Me.cmdPostille)
    Me.NtsPanel1.Controls.Add(Me.cmdFirme)
    Me.NtsPanel1.Cursor = System.Windows.Forms.Cursors.Default
    Me.NtsPanel1.Location = New System.Drawing.Point(3, 4)
    Me.NtsPanel1.Name = "NtsPanel1"
    Me.NtsPanel1.Size = New System.Drawing.Size(491, 161)
    Me.NtsPanel1.TabIndex = 0
    Me.NtsPanel1.Text = "NtsPanel1"
    '
    'cmdFirme
    '
    Me.cmdFirme.ImageText = ""
    Me.cmdFirme.Location = New System.Drawing.Point(21, 31)
    Me.cmdFirme.Name = "cmdFirme"
    Me.cmdFirme.Size = New System.Drawing.Size(131, 40)
    Me.cmdFirme.TabIndex = 0
    Me.cmdFirme.Text = "Firme"
    '
    'cmdPostille
    '
    Me.cmdPostille.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdPostille.ImageText = ""
    Me.cmdPostille.Location = New System.Drawing.Point(303, 31)
    Me.cmdPostille.Name = "cmdPostille"
    Me.cmdPostille.Size = New System.Drawing.Size(131, 40)
    Me.cmdPostille.TabIndex = 1
    Me.cmdPostille.Text = "Postille"
    '
    'cmdPreamboli
    '
    Me.cmdPreamboli.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdPreamboli.ImageText = ""
    Me.cmdPreamboli.Location = New System.Drawing.Point(21, 100)
    Me.cmdPreamboli.Name = "cmdPreamboli"
    Me.cmdPreamboli.Size = New System.Drawing.Size(131, 40)
    Me.cmdPreamboli.TabIndex = 2
    Me.cmdPreamboli.Text = "Preamboli"
    '
    'cmdUM
    '
    Me.cmdUM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdUM.ImageText = ""
    Me.cmdUM.Location = New System.Drawing.Point(303, 100)
    Me.cmdUM.Name = "cmdUM"
    Me.cmdUM.Size = New System.Drawing.Size(131, 40)
    Me.cmdUM.TabIndex = 3
    Me.cmdUM.Text = "Unità di Misura"
    '
    'FRMHHTABE
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
    Me.ClientSize = New System.Drawing.Size(498, 166)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(498, 166)
Me.PnCPNEPnMain.Size = New System.Drawing.Size(498, 166)
    Me.PnCPNEPnMain.Controls.Add(Me.NtsPanel1)
    Me.Controls.Add(Me.PnCPNEPnMain)
Me.Name = "FRMHHTABE"
    Me.Text = "GESTIONE TABELLE"
    CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dttSmartArt, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.NtsPanel1, System.ComponentModel.ISupportInitialize).EndInit()
Me.NtsPanel1.ResumeLayout(False)
    CType(Me.PnCPNEPnMain, System.ComponentModel.ISupportInitialize).EndInit()
Me.PnCPNEPnMain.ResumeLayout(False)
Me.ResumeLayout(False)

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
#End Region

  Private components As System.ComponentModel.IContainer
  Public oCleHh As CLEHHTABE
  Public dsHh As New DataSet
  Public oCallParams As CLE__CLDP
  Public dcHh As BindingSource = New BindingSource

  Public Overridable Sub Bindcontrols()
    Try
      '-------------------------------------------------
      'se i controlli erano già  stati precedentemente collegati, li scollego
      NTSFormClearDataBinding(Me)

      '-------------------------------------------------
      'collego il BindingSource ai vari controlli 


      NTSFormAddDataBinding(dcHh, Me)
      '-------------------------------------------------
      'per agganciare al dataset i vari controlli


    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------
    End Try
  End Sub

  Private Sub FRM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
TRY
    dsHh = oCleHh.dsShared
    dcHh = Nothing
    dcHh = New BindingSource()
    dcHh.DataSource = dsHh.Tables("XXX")
    Bindcontrols()
    GctlSetRoules()
    GctlApplicaDefaultValue()
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

  Private Sub cmdFirme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirme.Click
TRY
    oCleHh.strNomeTabella = "tabhhfir"
    ApriTabella("Firme")
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub cmdPostille_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostille.Click
TRY
    oCleHh.strNomeTabella = "tabhhpos"
    ApriTabella("Postille")
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub cmdPreamboli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreamboli.Click
TRY
    oCleHh.strNomeTabella = "tabhhpre"
    ApriTabella("Preamboli")
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub cmdUM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUM.Click
TRY
    oCleHh.strNomeTabella = "tabhhunmis"
    ApriTabella("UM")
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
  Private Sub ApriTabella(ByVal TipoTab As String)
TRY
    oCleHh.CPNEstrZoomTipoTab = TipoTab
    Dim formDaLanApriTab As New FRMHHZOOM
    formDaLanApriTab.Init(oMenu, Nothing, DittaCorrente)
    formDaLanApriTab.InitEntity(oCleHh)
    formDaLanApriTab.ShowDialog()
    formDaLanApriTab.Dispose()
    formDaLanApriTab = Nothing
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub
End Class
