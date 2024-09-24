Imports System.Data
Imports NTSInformatica.CLN__STD
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports NTSInformatica.CLE__APP
Public Class CLEHHAVCO
  Inherits CLE__BASE
  Public oCldhh As CLDHHAVCO
  Dim strErr As String = ""
  Dim oTmp As Object = Nothing
  Public OMenu As Object
  Dim drxxx As DataRow

  Public Sub AssociaDs(ByRef ds As DataSet)
TRY
    dsShared = ds
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub

  Public Overrides Function Init(ByRef App As CLE__APP, _
                           ByRef oScriptEngine As INT__SCRIPT, ByRef oCleLbmenu As Object, ByVal strTabella As String, _
                           ByVal bFiller1 As Boolean, ByVal strFiller1 As String, _
                           ByVal strFiller2 As String) As Boolean
    If MyBase.strNomeDal = "BD__BASE" Then MyBase.strNomeDal = "BDHHAVCO"

    MyBase.Init(App, oScriptEngine, oCleLbmenu, strTabella, False, "", "")
    oCldhh = CType(MyBase.ocldBase, CLDHHAVCO)
    oCldhh.Init(oApp)



    If CLN__STD.NTSIstanziaDll(oApp.ServerDir, oApp.NetDir, "BEHHAVCO", "BEHHAVCO", oTmp, strErr, False, "", "") = False Then
      Throw New NTSException(oApp.Tr(Me, 128607611686875000, "ERRORE in fase di creazione Entity:" & vbCrLf & "|" & strErr & "|"))
      Return False
    End If

    dsShared.Tables.Add("XXX")
    With dsShared.Tables("XXX")
      .Columns.Add("xx_conto", GetType(Integer))
      .Columns.Add("xx_desconto", GetType(String))
      .Columns.Add("xx_commessa", GetType(Integer))
      .Columns.Add("xx_data", GetType(Date))
      .Rows.Add()
      drxxx = .Rows(0)
      With .Rows(0)
        !xx_conto = 0
        !xx_desconto = "Tutti"
        !xx_commessa = 0
        !xx_data = #1/1/1900# 'DBNull.Value'
      End With
    End With
    AddHandler dsShared.Tables("XXX").ColumnChanging, AddressOf CPNEBeforeColUpdate_XXX
    AddHandler dsShared.Tables("XXX").ColumnChanged, AddressOf CPNEAfterColUpdate_XXX
    oCldhh.CPNELeggiCommesse(dsShared, strDittaCorrente, 0, 0, #1/1/1900#)
    Return True
  End Function


  Public Overridable Sub CPNEBeforeColUpdate_XXX(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
TRY
    Dim dtXTest As New DataTable
    Dim StrXTest As String = ""
    Select Case e.Column.ColumnName.ToLower
      Case "xx_conto"
        If oCldhh.ValCodiceDb(e.ProposedValue.ToString, strDittaCorrente, "ANAGRA", "N", StrXTest, dtXTest) Then
          If dtXTest.Rows.Count = 0 Then
            e.Row!xx_desconto = "Tutti"
          Else
            If dtXTest.Rows(0)!an_tipo.ToString = "C" Then
              e.Row!xx_desconto = dtXTest.Rows(0)!an_descr1
            Else
              ThrowRemoteEvent(New NTSEventArgs("", "Inserire un cliente"))
              e.ProposedValue = "0" ' oppure "" a seconda del tipo di campo
              e.Row!xx_desconto = "Tutti"
            End If
          End If
        Else
          ThrowRemoteEvent(New NTSEventArgs("", "Il campo non è valido"))
          e.ProposedValue = "0" ' oppure "" a seconda del tipo di campo
          e.Row!xx_desconto = "Tutti"
        End If

    End Select
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Overridable Sub CPNEAfterColUpdate_XXX(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)

    Try
      e.Row.EndEdit()
      e.Row.EndEdit()
      Select Case e.Column.ColumnName.ToLower
        Case ""
      End Select
    Catch ex As Exception
      '--------------------------------------------------------------
      
   CLN__STD.GestErr(ex, Me, "")

      '--------------------------------------------------------------
    End Try
  End Sub
  Public Function CPNERicerca() As Boolean
TRY

    ''If IsDBNull(drxxx!xx_data) Then
    ''  drxxx!xx_data = #1/1/1900#
    ''End If

    oCldhh.CPNELeggiCommesse(dsShared, strDittaCorrente, CInt(drxxx!xx_conto), CInt(drxxx!xx_commessa), CDate(drxxx!xx_data))

    'Se data da movord: Modificare per controllare riga se data diversa da 01/01/1900 e funzione di AcceptChange

    AddHandler dsShared.Tables("Commesse").ColumnChanging, AddressOf CPNEBeforeColUpdate_Commesse
    AddHandler dsShared.Tables("Commesse").ColumnChanged, AddressOf CPNEAfterColUpdate_Commesse
    Return True
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function

  Public Overridable Sub CPNEBeforeColUpdate_Commesse(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
TRY
    Dim dtXTest As New DataTable
    Dim StrXTest As String = ""
    'Dim drcomm As New DataRow

    Select Case e.Column.ColumnName.ToLower
      Case ""

    End Select

Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
End Try
  End Sub
  Public Overridable Sub CPNEAfterColUpdate_Commesse(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)

    Try
      e.Row.EndEdit()
      e.Row.EndEdit()
      Select Case e.Column.ColumnName.ToLower
        Case ""
      End Select
    Catch ex As Exception
      '--------------------------------------------------------------
      
   CLN__STD.GestErr(ex, Me, "")

      '--------------------------------------------------------------
    End Try

    'Fabio 08/03/2017
    'CPNESalvaRiga(e.Row)

  End Sub

  Public Function CPNESalvaRiga(dr As DataRow) As Boolean ' perché passiamo dr se non serve (vedi anche BN)?
TRY
    'If 1 = 2 Then
    '  ThrowRemoteEvent(New NTSEventArgs("", "riga non completa"))
    '  Return False
    '  Dim ev As New NTSEventArgs(ThMsg.MSG_NOYES, "Continaure?")
    '  ThrowRemoteEvent(ev)
    '  If ev.RetValue = ThMsg.RETVALUE_NO Then
    '    Return False
    '  End If
    'End If

    'Fabio 08/03/2017
    'dsShared.Tables("Commesse").Rows

    oCldhh.ScriviTabellaSemplice(strDittaCorrente, "commess", dsShared.Tables("Commesse"), "", "", "")
    Return True
Catch ex As Exception
'--------------------------------------------------------------

   CLN__STD.GestErr(ex, Me, "")

'--------------------------------------------------------------
Return Nothing
End Try
  End Function
End Class
