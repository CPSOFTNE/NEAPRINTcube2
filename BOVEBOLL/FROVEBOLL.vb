Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.IO
Public Class FROVEBOLL
  Inherits FRMVEBOLL


  Public Overrides Sub InitControls()
TRY
    MyBase.InitControls()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub GestisciEventiEntity(ByVal sender As Object, ByRef e As NTSEventArgs)
    Try
      If Mid(e.TipoEvento, 1, 4) = "CPNE" Then
        Select Case e.TipoEvento
          Case "CPNE.RecordRipristina"
            CType(oCleBoll, CLFVEBOLL).RecordRipristina(dcBollRighe.Position, dcBollRighe.Filter)
          Case "CPNE.SelezionaOrdini"
            Dim strTipo As String = Mid(e.Message, 1, 1)
            Dim intCommessa As Integer = CInt(Mid(e.Message, InStr(e.Message, "#") + 1))
            oMenu.SaveSettingBus("BSVEBOLL", "PERS", ".", "CPNESelRigheOrdCommessa", intCommessa.ToString, False, False, False, "")
            SelezionaOrdini(strTipo)
            oMenu.SaveSettingBus("BSVEBOLL", "PERS", ".", "CPNESelRigheOrdCommessa", False, False, False, "", "")
        End Select
      Else
        MyBase.GestisciEventiEntity(sender, e)
      End If

    Catch ex As Exception
      '-------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------
    End Try
  End Sub
End Class
