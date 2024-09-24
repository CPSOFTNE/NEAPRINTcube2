Partial Class FRMHHTABE
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
  Friend WithEvents NtsPanel1 As NTSInformatica.NTSPanel
  Friend WithEvents cmdUM As NTSInformatica.NTSButton
  Friend WithEvents cmdPreamboli As NTSInformatica.NTSButton
  Friend WithEvents cmdPostille As NTSInformatica.NTSButton
  Friend WithEvents cmdFirme As NTSInformatica.NTSButton


public WithEvents PnCPNEPnMain As NTSInformatica.NTSPanel
End Class
