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
  Friend WithEvents hh_RigaSS As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_Descr As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_Note2 As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_Misura1 As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_Misura2 As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_Misura3 As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_Colli As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_Quant As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_Riga As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_Tipork As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_anno As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_serie As NTSInformatica.NTSGridColumn
  Friend WithEvents hh_numdoc As NTSInformatica.NTSGridColumn
  Friend WithEvents codditt As NTSInformatica.NTSGridColumn


public WithEvents PnCPNEPnMain As NTSInformatica.NTSPanel
End Class
