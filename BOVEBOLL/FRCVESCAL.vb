Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports NTSInformatica.CLN__STD
Imports NTSInformatica
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Public Class FRCVESCAL
  Inherits FRMVESCAL
  Private Sub GeneraECollegaOggettiARuntime()
TRY
    CType(grvRighe.Columns("ec_codartclifor"), NTSGridColumn).NTSForzaVisZoom = True
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Private Sub FRMVESCAL_ActivatedFirst(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ActivatedFirst
TRY
    GeneraECollegaOggettiARuntime()
Catch ex As Exception
'-------------------------------------------------
CLN__STD.GestErr(ex, Me, "")
'-------------------------------------------------
End Try
  End Sub

  Public Overrides Sub tlbZoom_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
    'MyBase.tlbZoom_ItemClick(sender, e)
    Try
      Dim oParam As New CLE__CLDP
      If grvRighe.Focused Then
        Select Case grvRighe.FocusedColumn.Name
          Case "ec_codartclifor"
            ValidaLastControl()
            NTSZOOM.strIn = ""

            oParam.nMagaz = CInt(oMenu.GetSettingBusDitt(oCleBoll.strDittaCorrente, "CPNE", "BNMGARTI", "OPZIONI", "CPSmembraArticolo", "0", " ", "0"))


            oParam.nListino = NTSCInt(oCleBoll.dttET.Rows(0)!Et_listino)
            oParam.lContoCF = oCleBoll.lContoCF

            NTSZOOM.ZoomStrIn("ZOOMARTICO", DittaCorrente, oParam)
            If NTSZOOM.strIn <> "" Then
              If IsNothing(grvRighe.NTSGetCurrentDataRow) Then
                'oCleBoll.AggiungiRigaCorpo(False, NTSZOOM.strIn, 0, 0)
                Dim strCodartclifor As String = CType(oCleBoll, CLBVEBOLL).TrovaCodartCliFor(NTSZOOM.strIn)
                grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
                grvRighe.SetFocusedValue(strCodartclifor)
              Else
                grvRighe.NTSGetCurrentDataRow!ec_codart = NTSZOOM.strIn
                Dim strCodartclifor As String = CType(oCleBoll, CLBVEBOLL).TrovaCodartCliFor(NTSZOOM.strIn)
                grvRighe.FocusedColumn = grvRighe.Columns("ec_codartclifor")
                grvRighe.SetFocusedValue(strCodartclifor)
              End If
              ValidaLastControl()
            End If
          Case Else
            MyBase.tlbZoom_ItemClick(sender, e)
        End Select
      End If
    Catch ex As Exception
      '-------------------------------------------------								
      CLN__STD.GestErr(ex, Me, "")
      '-------------------------------------------------								
    End Try
  End Sub
End Class
