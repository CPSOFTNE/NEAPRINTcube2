Partial Class FrmDetRiga
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
  Friend WithEvents grDetRiga As NTSInformatica.NTSGrid
  Friend WithEvents grvDetRiga As NTSInformatica.NTSGridView
  Friend WithEvents hh_rigass As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_descr As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_note2 As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_misura1 As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_misura2 As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_misura3 As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_colli As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_quant As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_riga As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_tipork As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_anno As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_serie As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_numdoc As NTSInformatica.NTSGridColumn
  Friend WithEvents codditt As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_codartclifor As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_tipoart As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_intest As NTSInformatica.NTSGridColumn


public WithEvents PnCPNEPnMain As NTSInformatica.NTSPanel
End Class
