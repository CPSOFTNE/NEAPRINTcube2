Partial Class FrmDdtNoEva
  Inherits FRM__CHIL

  <System.Diagnostics.DebuggerNonUserCode()> _
  Public Sub New()
    MyBase.New()
  End Sub

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing AndAlso components IsNot Nothing Then
      components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub
  Friend WithEvents grDdtNoEv As NTSInformatica.NTSGrid
  Friend WithEvents grvDdtNoEv As NTSInformatica.NTSGridView
  Friend WithEvents NtsGroupBox1 As NTSInformatica.NTSGroupBox
  Friend WithEvents CmdConferma As NTSInformatica.NTSButton
  Friend WithEvents CmdEsci As NTSInformatica.NTSButton
  Friend WithEvents CmdCerca As NTSInformatica.NTSButton
  Friend WithEvents edxx_Distinta As NTSInformatica.NTSTextBoxStr
  Friend WithEvents edxx_Riferim As NTSInformatica.NTSTextBoxStr
  Friend WithEvents edxx_codart As NTSInformatica.NTSTextBoxStr
  Friend WithEvents NtsLabel4 As NTSInformatica.NTSLabel
  Friend WithEvents NtsLabel3 As NTSInformatica.NTSLabel
  Friend WithEvents NtsLabel2 As NTSInformatica.NTSLabel
  Friend WithEvents NtsLabel1 As NTSInformatica.NTSLabel
  Friend WithEvents edxx_DataRif As NTSInformatica.NTSTextBoxData
  Friend WithEvents tm_datdoc As NTSInformatica.NTSGridColumn
  Friend WithEvents an_conto As NTSInformatica.NTSGridColumn
  Friend WithEvents an_descr1 As NTSInformatica.NTSGridColumn
  Friend WithEvents tm_anno As NTSInformatica.NTSGridColumn
  Friend WithEvents tm_serie As NTSInformatica.NTSGridColumn
  Friend WithEvents tm_numdoc As NTSInformatica.NTSGridColumn
  Friend WithEvents mm_riga As NTSInformatica.NTSGridColumn
  Friend WithEvents mm_commeca As NTSInformatica.NTSGridColumn
  Friend WithEvents tm_tipobf As NTSInformatica.NTSGridColumn
  Friend WithEvents tm_riferim As NTSInformatica.NTSGridColumn
  Friend WithEvents mm_magaz As NTSInformatica.NTSGridColumn
  Friend WithEvents xx_colliresidui As NTSInformatica.NTSGridColumn
  Friend WithEvents mm_codartCliFor As NTSInformatica.NTSGridColumn
  Friend WithEvents mm_descr As NTSInformatica.NTSGridColumn
  Friend WithEvents mm_desint As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_pos1 As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_pos2 As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_pos3 As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_pos4 As NTSInformatica.NTSGridColumn
  Friend WithEvents xx_codart As NTSInformatica.NTSGridColumn
  Friend WithEvents xx_codartclifor As NTSInformatica.NTSGridColumn
  Friend WithEvents xx_pzsel As NTSInformatica.NTSGridColumn
  Friend WithEvents xx_seltut As NTSInformatica.NTSGridColumn
  Friend WithEvents xx_kgres As NTSInformatica.NTSGridColumn


public WithEvents PnCPNEPnMain As NTSInformatica.NTSPanel
End Class
