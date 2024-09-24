Public Class FROORHLMO
  Inherits FRMORHLMO

  Public Overrides Sub FRMORHLMO_Load(ByVal sender As Object, ByVal e As System.EventArgs)
TRY
    MyBase.FRMORHLMO_Load(sender, e)
    If oMenu.GetSettingBus("BSVEBOLL", "PERS", ".", "CPNESelRigheOrdCommessa", "", " ", "") <> "" Then
      CType(NTSFindControlByName(Me, "ckCommeca"), NTSCheckBox).CheckState = CheckState.Checked
      CType(NTSFindControlByName(Me, "edCommeca"), NTSTextBoxNum).Text = oMenu.GetSettingBus("BSVEBOLL", "PERS", ".", "CPNESelRigheOrdCommessa", "", " ", "")
      CType(NTSFindControlByName(Me, "ckArticolo"), NTSCheckBox).CheckState = CheckState.Unchecked

    End If
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

End Class
