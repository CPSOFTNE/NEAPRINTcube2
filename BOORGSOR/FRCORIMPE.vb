Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports NTSInformatica.CLN__STD
Imports NTSInformatica
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Public Class FRCORIMPE
  Inherits FRMORIMPE

  Private Sub GeneraECollegaOggettiARuntime()
TRY
    CType(grvRighe.Columns("ec_codartclifor"), NTSGridColumn).NTSForzaVisZoom = True
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub FRMORIMPE_ActivatedFirst(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ActivatedFirst
TRY
    GeneraECollegaOggettiARuntime()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub tlbZoom_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
    Try
      Dim oParam As New CLE__CLDP
      Select Case grvRighe.FocusedColumn.Name
        Case "ec_codartclifor"
          ValidaLastControl()
          NTSZOOM.strIn = ""
          oParam.lContoCF = CInt(oCleGsor.dttET.Rows(0)!et_conto)
          NTSZOOM.ZoomStrIn("ZOOMARTICO", DittaCorrente, oParam)
          If NTSZOOM.strIn <> "" Then
            If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
              grvRighe.FocusedColumn = grvRighe.Columns("ec_codart")
              grvRighe.SetFocusedValue(NTSZOOM.strIn)
              grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
            Else
              grvRighe.NTSGetCurrentDataRow!ec_codart = NTSZOOM.strIn
              Dim strCodartclifor As String = CType(oCleGsor, CLBORGSOR).CPNETrovaCodartCliFor(NTSZOOM.strIn)
              grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
              grvRighe.SetFocusedValue(strCodartclifor)
            End If
            ValidaLastControl()
          End If
          '========= 15 04 2019 riccardo
        Case Else
          MyBase.tlbZoom_ItemClick(sender, e)

      End Select
    Catch ex As Exception
      '-------------------------------------------------								
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------								
    End Try
  End Sub
End Class
