Imports NTSInformatica.CLN__STD
Imports System.Data.Common
Imports NTSInformatica
Imports System.IO
Imports System
Imports NTSInformatica.CLE__APP
Public Class CLHORGSOR
  Inherits CLDORGSOR

  Public Sub CPNEPulisciDs(ByRef ds As DataSet, ByVal StrNomeTab As String)
    Dim str As String = StrNomeTab
    Try
      If ds.Tables.Contains(StrNomeTab) Then
        ds.Tables(StrNomeTab).Clear()
        ds.Tables.Remove(StrNomeTab)
      End If
    Catch ex As Exception
      '--------------------------------------------------------------
      Throw (New NTSException(GestError(ex, Me, str, oApp.InfoError, "", False)))
      '--------------------------------------------------------------
    End Try
  End Sub
    Public Sub CPNEdtApriOrdiniPrev(ByRef ds As DataSet, ByVal drRigaXXX As DataRow, ByVal Strdescr As String)
        Dim strSql As String = ""
        Try

            strSql = "SELECT td_tipork,td_anno, td_serie, td_numord, td_datord, an_descr1, an_conto,mo_commeca, td_codagen, tabcage.tb_descage AS xx_agente, td_codagen2, tabcage_1.tb_descage AS xx_agenzia, mo_note, mo_descr, 'N' as xx_sel, td_tipobf"
            strSql += " FROM (((testord INNER JOIN movord ON (testord.codditt = movord.codditt) AND (testord.td_tipork = movord.mo_tipork) AND (testord.td_serie = movord.mo_serie) AND (testord.td_anno = movord.mo_anno) AND (testord.td_numord = movord.mo_numord)) INNER JOIN anagra ON (testord.td_conto = anagra.an_conto) AND (testord.codditt = anagra.codditt)) LEFT JOIN tabcage ON (testord.codditt = tabcage.codditt) AND (testord.td_codagen = tabcage.tb_codcage)) LEFT JOIN tabcage AS tabcage_1 ON (testord.codditt = tabcage_1.codditt) AND (testord.td_codagen2 = tabcage_1.tb_codcage)"
            strSql += " where td_anno >=" & CInt(drRigaXXX!xx_annoda) & " and td_anno <=" & CInt(drRigaXXX!xx_annoa)
            strSql += " and td_serie >=" & CStrSQL(drRigaXXX!xx_serieda.ToString) & " and td_serie <=" & CStrSQL(drRigaXXX!xx_seriea.ToString)
            strSql += " and td_numord >=" & CInt(drRigaXXX!xx_numdocda) & " and td_numord <=" & CInt(drRigaXXX!xx_numdoca)
            strSql += " and mo_commeca >=" & CInt(drRigaXXX!xx_commessada) & " and mo_commeca <=" & CInt(drRigaXXX!xx_commessaa)
            strSql += " and td_conto >=" & CInt(drRigaXXX!xx_contoda) & " and td_conto <=" & CInt(drRigaXXX!xx_contoa)
            strSql += " and td_codagen >=" & CInt(drRigaXXX!xx_codagenda) & " and td_codagen <=" & CInt(drRigaXXX!xx_codagena)
            strSql += " and td_codagen2 >=" & CInt(drRigaXXX!xx_agenziada) & " and td_codagen2 <=" & CInt(drRigaXXX!xx_agenziaa)
            strSql += " and td_tipork =" & CStrSQL(drRigaXXX!xx_tipo)
            If Strdescr <> "" Then
                strSql += " and mo_descr like '%" & Strdescr & "%'"
            End If

            OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI, "RIGHEPREVORD", ds)
        Catch ex As Exception
            '--------------------------------------------------------------
            CLN__STD.GestErr(ex, Me, "")
            '--------------------------------------------------------------
        End Try
    End Sub
    Public Sub CPNECaricaTabFirme(ByRef ds As DataSet, ByVal strDittaCorrente As String)
    Dim strSql As String = ""
    Try

      strSql = "SELECT codditt, tb_codhhFir as xx_codice, tb_deshhFir as xx_descr, tb_deshhUff"
      strSql += " FROM tabhhFir"
      strSql += " where codditt = " & CStrSQL(strDittaCorrente)
      strSql += " ORDER BY tb_codhhFir"
      OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI, "YYY", ds)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
  Public Sub CPNECaricaTabPostille(ByRef ds As DataSet, ByVal strDittaCorrente As String)
    Dim strSql As String = ""
    Try

      strSql = "SELECT codditt, tb_codhhPos as xx_codice, tb_deshhPos as xx_descr"
      strSql += " FROM tabhhPos"
      strSql += " where codditt = " & CStrSQL(strDittaCorrente)
      strSql += " ORDER BY tb_codhhPos"
      OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI, "YYY", ds)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
  Public Sub CPNECaricaTabPreamboli(ByRef ds As DataSet, ByVal strDittaCorrente As String)
    Dim strSql As String = ""
    Try

      strSql = "SELECT codditt, tb_codhhpre as xx_codice, tb_deshhPre as xx_descr"
      strSql += " FROM tabhhpre"
      strSql += " where codditt = " & CStrSQL(strDittaCorrente)
      strSql += " ORDER BY tb_codhhpre"
      OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI, "YYY", ds)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
  Public Sub CPNECaricaTabTipiIva(ByRef ds As DataSet, ByVal strDittaCorrente As String)
    Dim strSql As String = ""
    Try

      strSql = "SELECT codditt, tb_codhhTip as xx_codice, tb_deshhTip as xx_descr"
      strSql += " FROM TabHHTip"
      strSql += " where codditt = " & CStrSQL(strDittaCorrente)
      strSql += " ORDER BY tb_codhhTip"
      OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI, "YYY", ds)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
 
  Public Function CPNEAggiornaStoricoCaricaRigheOrdine(ByVal strDittaCorrente As String, ByVal dr As DataRow) As DataTable
    Dim strSql As String = ""
    Try

      strSql = "SELECT *"
      strSql += " FROM movord"
      strSql += " WHERE codditt = " & CStrSQL(strDittaCorrente)
      strSql += " AND mo_tipork =" & CStrSQL(dr!et_tipork.ToString) & " AND mo_anno = " & CInt(dr!et_anno) & " AND mo_serie = " & CStrSQL(dr!et_serie.ToString) & " AND mo_numord = " & CInt(dr!et_numdoc)
      strSql += " ORDER BY mo_riga"
      Return OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Function
  Public Sub CPNEAggiornaStoricoRiga(ByVal dtData As Date, ByVal OraMin As Decimal, ByVal strOperat As String, ByVal StrTipoMod As String, ByVal strTipork As String, ByVal intAnno As Integer, ByVal strSerie As String, ByVal intNumdoc As Integer, ByVal intRiga As Integer)
    Dim strSql As String = ""
    Try

      strSql = "INSERT INTO hhmovordStor ( codditt, mo_tipork, mo_anno, mo_serie, mo_numord, mo_riga, mo_codart, mo_datcons, mo_magaz, mo_magaz2, mo_unmis, mo_descr, mo_colli, mo_coleva, mo_quant, mo_quaeva, mo_flevas, mo_colpre, mo_quapre, mo_flevapre, mo_prezzo, mo_scont1, mo_scont2, mo_scont3, mo_provv, mo_codiva, mo_preziva, mo_prezvalc, mo_commen, mo_note, mo_controp, mo_stasino, mo_provv2, mo_tiporkor, mo_annoor, mo_serieor, mo_numordor, mo_rigaor, mo_prelist, mo_codcfam, mo_commeca, mo_subcommeca, mo_valore, mo_contocontr, mo_codcena, mo_desint, mo_codvuo, mo_vprovv, mo_vprovv2, mo_ump, mo_confermato, mo_lotto, mo_rilasciato, mo_aperto, mo_ricimp, mo_datconsor, mo_codclie, mo_misura1, mo_misura2, mo_misura3, mo_ultagg, mo_perqta, mo_flkit, mo_ktriga, mo_prezivav, mo_valorev, mo_valoremm, mo_scont4, mo_scont5, mo_scont6, mo_oatipo, mo_oaanno, mo_oaserie, mo_oanum, mo_oariga, mo_oaqtadis, mo_oacoldis, mo_oavaldis, mo_oasalcon, mo_flelab, mo_flcom, mo_flprznet, mo_flforf, mo_matric, "
      strSql += " mo_verdb , mo_umprz, mo_qtap, mo_qtapeva, mo_qtappre, mo_przp, mo_przpval, mo_przpiva, mo_oaqtapdis, mo_fase, mo_codlavo, mo_pmtaskid, mo_pmsalcon, mo_pmqtadis, mo_pmvaldis, mo_oqtipo, mo_oqanno, mo_oqserie, mo_oqnum, mo_oqriga, mo_oqsalcon, mo_ubicaz, mo_codpf, mo_dtvaldb, hh_DtaUltAgg, hh_ORUltAgg, hh_Operat, hh_TipoMod ) SELECT codditt, mo_tipork, mo_anno, mo_serie, mo_numord, mo_riga, mo_codart, mo_datcons, mo_magaz, mo_magaz2, mo_unmis, mo_descr, mo_colli, mo_coleva, mo_quant, mo_quaeva, mo_flevas, mo_colpre, mo_quapre, mo_flevapre, mo_prezzo, mo_scont1, mo_scont2, mo_scont3, mo_provv, mo_codiva, mo_preziva, mo_prezvalc, mo_commen, mo_note, mo_controp, mo_stasino, mo_provv2, mo_tiporkor, mo_annoor, mo_serieor, mo_numordor, mo_rigaor, mo_prelist, mo_codcfam, mo_commeca, mo_subcommeca, mo_valore, mo_contocontr, mo_codcena, mo_desint, mo_codvuo, mo_vprovv, mo_vprovv2, mo_ump, mo_confermato, mo_lotto, mo_rilasciato, mo_aperto, mo_ricimp, mo_datconsor,"
      strSql += " mo_codclie , mo_misura1, mo_misura2, mo_misura3, mo_ultagg, mo_perqta, mo_flkit, mo_ktriga, mo_prezivav, mo_valorev, mo_valoremm, mo_scont4, mo_scont5, mo_scont6, mo_oatipo, mo_oaanno, mo_oaserie, mo_oanum, mo_oariga, mo_oaqtadis, mo_oacoldis, mo_oavaldis, mo_oasalcon, mo_flelab, mo_flcom, mo_flprznet, mo_flforf, mo_matric, mo_verdb, mo_umprz, mo_qtap, mo_qtapeva, mo_qtappre, mo_przp, mo_przpval, mo_przpiva, mo_oaqtapdis, mo_fase, mo_codlavo, mo_pmtaskid, mo_pmsalcon, mo_pmqtadis, mo_pmvaldis, mo_oqtipo, mo_oqanno, mo_oqserie, mo_oqnum, mo_oqriga, mo_oqsalcon, mo_ubicaz, mo_codpf, mo_dtvaldb, " & CDataSQL(dtData) & ", " & CDblSQL(OraMin) & " , " & CStrSQL(strOperat) & " , " & CStrSQL(StrTipoMod) & " FROM movord where mo_tipork =" & CStrSQL(strTipork) & " AND mo_anno = " & intAnno & " AND mo_serie = " & CStrSQL(strSerie) & " AND mo_numord = " & intNumdoc & " and mo_riga = " & intRiga
      Execute(strSql, CLE__APP.DBTIPO.DBAZI)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
  Public Sub CPNEAggiornaPreventivo(ByVal strDittaCorrente As String, ByVal dr As DataRow)
    Dim strSql As String = ""
    Try

      strSql = "UPDATE movord SET mo_codart = " & CStrSQL(dr!ec_codart.ToString) & ", mo_descr = " & CStrSQL(dr!ec_descr.ToString)
      strSql += ", mo_colli = " & CDblSQL(dr!ec_colli.ToString) & ", mo_quant = " & CDblSQL(dr!ec_quant.ToString) & ", mo_codiva = " & CInt(dr!ec_codiva)
      strSql += ", mo_note = " & CStrSQL(dr!ec_note.ToString) & ", mo_controp = " & CInt(dr!ec_controp) & ", movord.mo_desint = " & CStrSQL(dr!ec_desint.ToString)
      strSql += ", mo_przp = " & CDblSQL(dr!ec_przp.ToString) & ", mo_prezzo = " & CDblSQL(dr!ec_prezzo.ToString)
      strSql += " WHERE codditt = " & CStrSQL(strDittaCorrente)
      strSql += " AND mo_tipork =" & CStrSQL(dr!ec_tiporkor.ToString) & " AND mo_anno = " & CInt(dr!ec_annoor) & " AND mo_serie = " & CStrSQL(dr!ec_serieor.ToString) & " AND mo_numord = " & CInt(dr!ec_numordor) & " AND mo_riga = " & CInt(dr!ec_rigaor)
      Execute(strSql, CLE__APP.DBTIPO.DBAZI)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
  Public Sub CPNECreaPreventivo(ByVal intNuovoNumOrd As Integer, ByVal intAnnoPadre As Integer, ByVal strSeriePadre As String, ByVal intNumordPadre As Integer)
    Dim strSql As String = ""
    Try

      strSql = "INSERT INTO testord ( codditt, td_conto, td_tipork, td_anno, td_serie, td_numord, td_datord, td_riferim, td_tipobf, td_datcons, td_codpaga, td_datapag, td_codagen, td_listino, td_controp, td_scont1, td_scont2, td_scopag, td_magaz, td_magaz2, td_bolli, td_speinc, td_speacc, td_speaccv, td_valuta, td_cambio, td_scorpo, td_acuradi, td_vettor, td_totcoll, td_caustra, td_note, td_flevas, td_flstam, td_porto, td_coddest, td_coddest2, td_codese, td_codagen2, td_peso, td_pesonetto, td_codaspe, td_aspetto, td_annpar, td_alfpar, td_numpar, td_datpar, td_flspinc, td_flboll, td_impprov, td_totprov, td_totprov2, td_pagato, td_abbuono, td_totomag, td_totdoc, td_totdocv, td_totmerce, td_totmercev, td_totlordo, td_totlordov, td_commeca, td_subcommeca, td_codcena, td_abi, td_cab, td_blocco, td_confermato, td_rilasciato, td_aperto, td_magimp, td_banc1, td_banc2, td_sospeso, td_soloasa, td_ultagg, td_vettor2, td_bolliv, td_speincv, td_pagatov,"
      strSql += " td_abbuonov , td_totomagv, td_ccambiati, td_speimb, td_speimbv, td_codbanc, td_opnome, td_annotco, td_codstag, td_codcfam, hh_tiporkPadre, hh_annoPadre, hh_seriePadre, hh_NumPadre, hh_PerAgen, hh_PerAgen2, hh_PerUsg, hh_DataInv, hh_DatAgg, hh_CodPreambolo, hh_CodPostilla, hh_codFirma, hh_codtipiva ) select "
      strSql += " codditt, td_conto, td_tipork, td_anno, td_serie, " & intNuovoNumOrd & ", td_datord, td_riferim, td_tipobf, td_datcons, td_codpaga, td_datapag, td_codagen, td_listino, td_controp, td_scont1, td_scont2, td_scopag, td_magaz, td_magaz2, td_bolli, td_speinc, td_speacc, td_speaccv, td_valuta, td_cambio, td_scorpo, td_acuradi, td_vettor, td_totcoll, td_caustra, td_note, td_flevas, td_flstam, td_porto, td_coddest, td_coddest2, td_codese, td_codagen2, td_peso, td_pesonetto, td_codaspe, td_aspetto, td_annpar, td_alfpar, td_numpar, td_datpar, td_flspinc, td_flboll, td_impprov, td_totprov, td_totprov2, td_pagato, td_abbuono, td_totomag, td_totdoc, td_totdocv, td_totmerce, td_totmercev, td_totlordo, td_totlordov, td_commeca, td_subcommeca, td_codcena, td_abi, td_cab, td_blocco, td_confermato, td_rilasciato, td_aperto, td_magimp, td_banc1, td_banc2, td_sospeso, td_soloasa, td_ultagg, td_vettor2, td_bolliv, td_speincv, td_pagatov,"
      strSql += " td_abbuonov , td_totomagv, td_ccambiati, td_speimb, td_speimbv, td_codbanc, td_opnome, td_annotco, td_codstag, td_codcfam, hh_tiporkPadre, hh_annoPadre, hh_seriePadre, hh_NumPadre, hh_PerAgen, hh_PerAgen2, hh_PerUsg, hh_DataInv, hh_DatAgg, hh_CodPreambolo, hh_CodPostilla, hh_codFirma, hh_codtipiva from testord where td_tipork = 'Q' and td_anno = " & intAnnoPadre & " and td_serie = " & CStrSQL(strSeriePadre) & " and td_numord = " & intNumordPadre
      Execute(strSql, CLE__APP.DBTIPO.DBAZI)

      strSql = "INSERT INTO movord ( codditt, mo_tipork, mo_anno, mo_serie, mo_numord, mo_riga, mo_codart, mo_datcons, mo_magaz, mo_magaz2, mo_unmis, mo_descr, mo_colli, mo_coleva, mo_quant, mo_quaeva, mo_flevas, mo_colpre, mo_quapre, mo_flevapre, mo_prezzo, mo_scont1, mo_scont2, mo_scont3, mo_provv, mo_codiva, mo_preziva, mo_prezvalc, mo_commen, mo_note, mo_controp, mo_stasino, mo_provv2, mo_tiporkor, mo_annoor, mo_serieor, mo_numordor, mo_rigaor, mo_prelist, mo_codcfam, mo_commeca, mo_subcommeca, mo_valore, mo_contocontr, mo_codcena, mo_desint, mo_codvuo, mo_vprovv, mo_vprovv2, mo_ump, mo_confermato, mo_lotto, mo_rilasciato, mo_aperto, mo_ricimp, mo_datconsor, mo_codclie, mo_misura1, mo_misura2, mo_misura3, mo_ultagg, mo_perqta, mo_flkit, mo_ktriga, mo_prezivav, mo_valorev, mo_valoremm, mo_scont4, mo_scont5, mo_scont6, mo_oatipo, mo_oaanno, mo_oaserie, mo_oanum, mo_oariga, mo_oaqtadis, mo_oacoldis, mo_oavaldis, mo_oasalcon, mo_flelab, mo_flcom, mo_flprznet,"
      strSql += " mo_flforf , mo_matric, mo_verdb, mo_umprz, mo_qtap, mo_qtapeva, mo_qtappre, mo_przp, mo_przpval, mo_przpiva, mo_oaqtapdis, mo_fase, mo_codlavo, mo_pmtaskid, mo_pmsalcon, mo_pmqtadis, mo_pmvaldis, mo_oqtipo, mo_oqanno, mo_oqserie, mo_oqnum, mo_oqriga, mo_oqsalcon, mo_ubicaz, mo_codpf, mo_dtvaldb ) select"
      strSql += " codditt, mo_tipork, mo_anno, mo_serie, " & intNuovoNumOrd & ", mo_riga, mo_codart, mo_datcons, mo_magaz, mo_magaz2, mo_unmis, mo_descr, mo_colli, mo_coleva, mo_quant, mo_quaeva, mo_flevas, mo_colpre, mo_quapre, mo_flevapre, mo_prezzo, mo_scont1, mo_scont2, mo_scont3, mo_provv, mo_codiva, mo_preziva, mo_prezvalc, mo_commen, mo_note, mo_controp, mo_stasino, mo_provv2, mo_tiporkor, mo_annoor, mo_serieor, mo_numordor, mo_rigaor, mo_prelist, mo_codcfam, mo_commeca, mo_subcommeca, mo_valore, mo_contocontr, mo_codcena, mo_desint, mo_codvuo, mo_vprovv, mo_vprovv2, mo_ump, mo_confermato, mo_lotto, mo_rilasciato, mo_aperto, mo_ricimp, mo_datconsor, mo_codclie, mo_misura1, mo_misura2, mo_misura3, mo_ultagg, mo_perqta, mo_flkit, mo_ktriga, mo_prezivav, mo_valorev, mo_valoremm, mo_scont4, mo_scont5, mo_scont6, mo_oatipo, mo_oaanno, mo_oaserie, mo_oanum, mo_oariga, mo_oaqtadis, mo_oacoldis, mo_oavaldis, mo_oasalcon, mo_flelab, mo_flcom, mo_flprznet,"
      strSql += " mo_flforf , mo_matric, mo_verdb, mo_umprz, mo_qtap, mo_qtapeva, mo_qtappre, mo_przp, mo_przpval, mo_przpiva, mo_oaqtapdis, mo_fase, mo_codlavo, mo_pmtaskid, mo_pmsalcon, mo_pmqtadis, mo_pmvaldis, mo_oqtipo, mo_oqanno, mo_oqserie, mo_oqnum, mo_oqriga, mo_oqsalcon, mo_ubicaz, mo_codpf, mo_dtvaldb  from movord where mo_tipork = 'Q' and mo_anno = " & intAnnoPadre & " and mo_serie = " & CStrSQL(strSeriePadre) & " and mo_numord = " & intNumordPadre

      Execute(strSql, CLE__APP.DBTIPO.DBAZI)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub
  Public Sub CPNECaricaStorico(ByRef ds As DataSet, ByVal strDittaCorrente As String, ByVal dr As DataRow)
    Dim strSql As String = ""
    Try

      strSql = "select *"
      strSql += " from hhMovordStor"
      strSql += " where codditt = " & CStrSQL(strDittaCorrente)
      strSql += " AND mo_tipork = " & CStrSQL(dr!et_tipork.ToString) & " and mo_anno = " & CInt(dr!et_anno) & " and mo_serie = " & CStrSQL(dr!et_serie.ToString) & " and mo_numord = " & CInt(dr!et_numdoc)
      OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI, "CPNE.STORICO", ds)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Sub

  Public Function CPNELeggiHHTabNuma(ByVal IntAnno As Integer, ByVal IntMese As Integer) As DataTable
    Dim strSql As String = ""
    Try
      strSql = "select * from hhTabnuma"
      strSql += " where hh_anno = " & IntAnno & " and hh_Mese = " & IntMese
      Return OpenRecordset(strSql, CLE__APP.DBTIPO.DBAZI)
    Catch ex As Exception
      '--------------------------------------------------------------
      CLN__STD.GestErr(ex, Me, "")
      '--------------------------------------------------------------
    End Try
  End Function
End Class
