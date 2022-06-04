Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_ConferenciaContabil
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Imprimir()
        Dim SqlText As String
        Dim sFiltro As String = String.Empty
        Dim oData As DataTable
        Dim oDataAux As DataTable
        Dim oRelatorio_Sub1 As New ReportDocument

        If Not Data_ValidarPeriodo("da movimentação", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub

        If txtValorContabilidade.Value = 0 Then
            Msg_Mensagem("Favor informar o valor da contabilidade.")
            txtValorContabilidade.Focus()
            Exit Sub
        End If

        AVI_Carregar(Me)

        sFiltro = sFiltro & "Periodo de " & txtDataInicial.Text
        sFiltro = sFiltro & " a " & txtDataFinal.Text

        SqlText = "SELECT   'Saldo Rd''s Filiais' no_titulo, "
        SqlText = SqlText & "         fil.cd_filial || ' - ' || fil.no_filial as no_filial, SUM (rde.vl_dia) as vl_dia, "
        SqlText = SqlText & "         SUM (rde.qt_kg_dia) as qt_kg_dia,  fil.cd_filial, 1 nu_ordem "
        SqlText = SqlText & "    FROM sof.resumo_diario_estoque rde, sof.filial fil "
        SqlText = SqlText & "   WHERE decode(rde.cd_filial_origem,694,69,rde.cd_filial_origem) = fil.cd_filial "
        SqlText = SqlText & "     AND rde.dt_movimento = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "     AND rde.cd_tipo_movimentacao IN ( "
        SqlText = SqlText & "                                      SELECT p.cd_tipo_movimentacao "
        SqlText = SqlText & "                                        FROM sof.parametro_modalidade_tipo_mov p "
        SqlText = SqlText & "                                       WHERE p.cd_parametro_modalidade = 9) "
        SqlText = SqlText & "     AND (rde.vl_dia <> 0 OR rde.qt_kg_dia <> 0) "
        SqlText = SqlText & "GROUP BY fil.cd_filial , fil.no_filial "
        SqlText = SqlText & " union all "
        SqlText = SqlText & " SELECT   'Transferências Filiais para Fabrica \Ina' no_titulo, "
        SqlText = SqlText & "         fil.cd_filial || ' - ' || fil.no_filial as no_filial, SUM (rde.vl_dia)*-1  as vl_dia, "
        SqlText = SqlText & "         SUM (rde.qt_kg_dia)*-1 as qt_kg_dia,  fil.cd_filial, 2 nu_ordem "
        SqlText = SqlText & "    FROM sof.resumo_diario_estoque rde, sof.filial fil "
        SqlText = SqlText & "   WHERE rde.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "     AND rde.dt_movimento BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "     AND rde.cd_tipo_movimentacao IN ( "
        SqlText = SqlText & "                                      SELECT p.cd_tipo_movimentacao "
        SqlText = SqlText & "                                        FROM sof.parametro_modalidade_tipo_mov p "
        SqlText = SqlText & "                                       WHERE p.cd_parametro_modalidade = 3) "
        SqlText = SqlText & "     AND (rde.vl_dia <> 0 OR rde.qt_kg_dia <> 0) "
        SqlText = SqlText & "GROUP BY fil.cd_filial , fil.no_filial "
        SqlText = SqlText & " union all "
        SqlText = SqlText & " SELECT   'Transferências Filiais para Fabrica \Ina' no_titulo, "
        SqlText = SqlText & "         fil.cd_filial || ' - ' || fil.no_filial as no_filial, SUM (rde.vl_dia) as vl_dia, "
        SqlText = SqlText & "         SUM (rde.qt_kg_dia) as qt_kg_dia,  fil.cd_filial, 2 nu_ordem "
        SqlText = SqlText & "    FROM sof.resumo_diario_estoque rde, sof.filial fil "
        SqlText = SqlText & "   WHERE rde.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "     AND rde.dt_movimento BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "     AND rde.cd_tipo_movimentacao IN ( "
        SqlText = SqlText & "                                      SELECT p.cd_tipo_movimentacao "
        SqlText = SqlText & "                                        FROM sof.parametro_modalidade_tipo_mov p "
        SqlText = SqlText & "                                       WHERE p.cd_parametro_modalidade = 10) "
        SqlText = SqlText & "     AND (rde.vl_dia <> 0 OR rde.qt_kg_dia <> 0) and fil.ic_armazem ='N' and fil.cd_filial<> 69 "
        SqlText = SqlText & "GROUP BY fil.cd_filial , fil.no_filial "
        SqlText = SqlText & " union all "
        SqlText = SqlText & " SELECT   'Transferências Filiais para Fabrica \Ina' no_titulo, "
        SqlText = SqlText & "         'Transferência entre Armazém Fechado' as no_filial, SUM(rde.vl_dia * DECODE(tm.IC_ENTRADA_SAIDA, 'S', 1, -1)) as vl_dia, "
        SqlText = SqlText & "         SUM(rde.qt_kg_dia * DECODE(tm.IC_ENTRADA_SAIDA, 'S', 1, -1)) as qt_kg_dia, 0 cd_filial, 2 nu_ordem "
        SqlText = SqlText & "    FROM sof.resumo_diario_estoque rde, sof.filial fil, sof.tipo_movimentacao tm "
        SqlText = SqlText & "   WHERE rde.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "     AND rde.dt_movimento BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "     AND rde.cd_tipo_movimentacao IN (SELECT p.cd_tipo_movimentacao "
        SqlText = SqlText & "                                        FROM sof.parametro_modalidade_tipo_mov p "
        SqlText = SqlText & "                                       WHERE p.cd_parametro_modalidade = 11) "
        SqlText = SqlText & "     AND (rde.vl_dia <> 0 OR rde.qt_kg_dia <> 0)"
        SqlText = SqlText & "     AND tm.cd_tipo_movimentacao = rde.cd_tipo_movimentacao"
        SqlText = SqlText & " union all "
        SqlText = SqlText & " SELECT   'Transferências Filiais para Fabrica \Ina' no_titulo,  "
        SqlText = SqlText & "      'Trânsito mês anterior' as no_filial, SUM (m.vl_nf) as vl_dia,  "
        SqlText = SqlText & "        SUM (m.qt_kg_nf) as qt_kg_dia,  2000 cd_filial, 2 nu_ordem  "
        SqlText = SqlText & "  FROM sof.transferencia t, "
        SqlText = SqlText & "       sof.movimentacao m, "
        SqlText = SqlText & "       sof.transferencia_modalidade tm "
        SqlText = SqlText & " WHERE t.sq_movimentacao_saida = m.sq_movimentacao "
        SqlText = SqlText & "   AND t.cd_transferencia_modalidade = tm.cd_transferencia_modalidade "
        SqlText = SqlText & "   AND tm.ic_possui_transito = 'S' "
        SqlText = SqlText & "   AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "   AND tm.cd_tipo_movimentacao_saida = m.cd_tipo_movimentacao "
        SqlText = SqlText & "   AND ((" & QuotedStr(Date_to_Oracle(DateAdd(DateInterval.Day, -1, txtDataInicial.Value))) & " BETWEEN t.dt_transferencia AND NVL(t.dt_chegada, sysdate)) "
        SqlText = SqlText & "        AND NVL(t.dt_chegada, sysdate) <> " & QuotedStr(Date_to_Oracle(DateAdd(DateInterval.Day, -1, txtDataInicial.Value))) & ")"
        SqlText = SqlText & " union all "
        SqlText = SqlText & " SELECT   'Compras Filiais' no_titulo, "
        SqlText = SqlText & "         fil.cd_filial || ' - ' || fil.no_filial as no_filial, SUM (rde.vl_dia) as vl_dia, "
        SqlText = SqlText & "         SUM (rde.qt_kg_dia) as qt_kg_dia,  fil.cd_filial, 3 nu_ordem "
        SqlText = SqlText & "    FROM sof.resumo_diario_estoque rde, sof.filial fil "
        SqlText = SqlText & "   WHERE rde.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "     AND rde.dt_movimento BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "     AND rde.cd_tipo_movimentacao IN (SELECT p.cd_tipo_movimentacao  FROM sof.parametro_modalidade_tipo_mov p WHERE p.cd_parametro_modalidade = 8)"
        SqlText = SqlText & "     AND (rde.vl_dia <> 0 OR rde.qt_kg_dia <> 0) "
        SqlText = SqlText & "GROUP BY fil.cd_filial , fil.no_filial "
        oData = DBQuery(SqlText)

        SqlText = "SELECT    no_tipo_movimentacao,"
        SqlText = SqlText & "         SUM (valor_relatorio) valor_relatorio, SUM (valor_rd) valor_rd,"
        SqlText = SqlText & "         SUM (valor_cont) valor_cont, SUM (qt_relatorio) qt_relatorio,"
        SqlText = SqlText & "         SUM (qt_rd) qt_rd"
        SqlText = SqlText & "    FROM (SELECT   tm.cd_tipo_movimentacao, tm.no_tipo_movimentacao,"
        SqlText = SqlText & "                   SUM (m.vl_nf) valor_relatorio, 0 valor_rd, 0 valor_cont,"
        SqlText = SqlText & "                   DECODE(TM.CD_TIPO_MOVIMENTACAO, 136,SUM(M.QT_KG_NF), 106,SUM(M.QT_KG_NF), 107,SUM(M.QT_KG_NF), SUM(M.QT_KG_LIQUIDO_NF)) QT_RELATORIO,"
        SqlText = SqlText & "                   0 qt_rd"
        SqlText = SqlText & "              FROM sof.movimentacao m, sof.tipo_movimentacao tm"
        SqlText = SqlText & "             WHERE m.cd_tipo_movimentacao = tm.cd_tipo_movimentacao"
        SqlText = SqlText & "               and not m.cd_tipo_movimentacao in (901,902)"
        SqlText = SqlText & "               AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "               AND m.dt_movimentacao = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "          GROUP BY tm.cd_tipo_movimentacao, tm.no_tipo_movimentacao"
        SqlText = SqlText & "          UNION ALL"
        SqlText = SqlText & "          SELECT   ap.cd_tipo_movimentacao, tm1.no_tipo_movimentacao,"
        SqlText = SqlText & "                   SUM (ap.valor_relatorio) valor_relatorio,"
        SqlText = SqlText & "                   SUM (ap.valor_rd) valor_rd, SUM (ap.valor_cont) valor_cont,"
        SqlText = SqlText & "                   SUM (ap.qt_relatorio) qt_relatorio, SUM (ap.qt_rd) qt_rd"
        SqlText = SqlText & "              FROM (SELECT DECODE"
        SqlText = SqlText & "                              (tm.ic_importacao,"
        SqlText = SqlText & "                               'S', (SELECT p.cd_tp_mov_fix_saida_imp"
        SqlText = SqlText & "                                       FROM sof.parametro p),"
        SqlText = SqlText & "                               (SELECT p.cd_tp_mov_fixacao_saida"
        SqlText = SqlText & "                                  FROM sof.parametro p)"
        SqlText = SqlText & "                              ) AS cd_tipo_movimentacao,"
        SqlText = SqlText & "                             (  cm.vl_fixo"
        SqlText = SqlText & "                              - ROUND ((DECODE(m.vl_nf, 0, 0, cm.vl_fixo / m.vl_nf)) * m.vl_nf_icms,"
        SqlText = SqlText & "                                       2"
        SqlText = SqlText & "                                      )"
        SqlText = SqlText & "                             )"
        SqlText = SqlText & "                           * -1 valor_relatorio,"
        SqlText = SqlText & "                           0 valor_rd, 0 valor_cont,"
        SqlText = SqlText & "                           cm.qt_kg_fixo * -1 qt_relatorio, 0 qt_rd"
        SqlText = SqlText & "                      FROM sof.tipo_movimentacao tm,"
        SqlText = SqlText & "                           sof.movimentacao m,"
        SqlText = SqlText & "                           sof.movimentacao_cessao_direito mcd,"
        SqlText = SqlText & "                           sof.ctr_paf_neg_ctr_fix_mov cm"
        SqlText = SqlText & "                     WHERE tm.cd_tipo_movimentacao = m.cd_tipo_movimentacao"
        SqlText = SqlText & "                       AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "                       AND mcd.sq_movimentacao = cm.sq_movimentacao"
        SqlText = SqlText & "                       AND mcd.sq_movimentacao_cessao_direito = cm.sq_movimentacao_cessao_direito"
        SqlText = SqlText & "                       AND mcd.sq_movimentacao = m.sq_movimentacao"
        SqlText = SqlText & "                       AND cm.dt_fixacao = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)) & ") ap,"
        SqlText = SqlText & "                   sof.tipo_movimentacao tm1"
        SqlText = SqlText & "             WHERE ap.cd_tipo_movimentacao = tm1.cd_tipo_movimentacao"
        SqlText = SqlText & "               AND tm1.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "          GROUP BY ap.cd_tipo_movimentacao, tm1.no_tipo_movimentacao"
        SqlText = SqlText & "          UNION ALL"
        SqlText = SqlText & "          SELECT   ap.cd_tipo_movimentacao, tm1.no_tipo_movimentacao,"
        SqlText = SqlText & "                   SUM (ap.valor_relatorio) valor_relatorio, SUM (ap.valor_rd) valor_rd,"
        SqlText = SqlText & "                   SUM (ap.valor_cont) valor_cont, SUM (ap.qt_relatorio) qt_relatorio,"
        SqlText = SqlText & "                   SUM (ap.qt_rd) qt_rd"
        SqlText = SqlText & "              FROM (SELECT DECODE"
        SqlText = SqlText & "                              (tm.cd_tipo_movimentacao,"
        SqlText = SqlText & "                               136,137, 114"
        SqlText = SqlText & "                              ) AS cd_tipo_movimentacao,"
        SqlText = SqlText & "                           0 valor_relatorio, 0 valor_rd, 0 valor_cont,"
        SqlText = SqlText & "                          m.qt_kg_liquido_nf-m.qt_kg_nf   qt_relatorio, 0 qt_rd"
        SqlText = SqlText & "                      FROM sof.tipo_movimentacao tm, sof.movimentacao m"
        SqlText = SqlText & "                     WHERE tm.cd_tipo_movimentacao = m.cd_tipo_movimentacao"
        SqlText = SqlText & "                       AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "                       AND m.dt_movimentacao = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "                       and not tm.cd_tipo_movimentacao in (100, 101)) ap,"
        SqlText = SqlText & "                   sof.tipo_movimentacao tm1"
        SqlText = SqlText & "             WHERE ap.cd_tipo_movimentacao = tm1.cd_tipo_movimentacao"
        SqlText = SqlText & "               AND tm1.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "          GROUP BY ap.cd_tipo_movimentacao, tm1.no_tipo_movimentacao"
        SqlText = SqlText & "          UNION ALL"
        SqlText = SqlText & "          SELECT   ap.cd_tipo_movimentacao, tm1.no_tipo_movimentacao,"
        SqlText = SqlText & "                   SUM (ap.valor_relatorio) * SOF.FN_SENTIDO_TIPO_MOVIMENTACAO(ap.cd_tipo_movimentacao) valor_relatorio,"
        SqlText = SqlText & "                   SUM (ap.valor_rd) valor_rd, SUM (ap.valor_cont) valor_cont,"
        SqlText = SqlText & "                   SUM (ap.qt_relatorio) qt_relatorio, SUM (ap.qt_rd) qt_rd"
        SqlText = SqlText & "              FROM (SELECT DECODE"
        SqlText = SqlText & "                              (tm.cd_tipo_movimentacao,"
        SqlText = SqlText & "                               107, (SELECT p.cd_tp_mov_icms_transf"
        SqlText = SqlText & "                                       FROM sof.parametro p),"
        SqlText = SqlText & "                               (SELECT p.cd_tp_mov_icms"
        SqlText = SqlText & "                                  FROM sof.parametro p)"
        SqlText = SqlText & "                              ) AS cd_tipo_movimentacao,"
        SqlText = SqlText & "                           m.vl_nf_icms  valor_relatorio, 0 valor_rd,"
        SqlText = SqlText & "                           0 valor_cont, 0 qt_relatorio, 0 qt_rd"
        SqlText = SqlText & "                      FROM sof.tipo_movimentacao tm, sof.movimentacao m"
        SqlText = SqlText & "                     WHERE tm.cd_tipo_movimentacao = m.cd_tipo_movimentacao"
        SqlText = SqlText & "                       AND tm.ic_entra_no_rd = 'S' "
        SqlText = SqlText & "                       AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "                       and not m.cd_filial_origem  is null "
        SqlText = SqlText & "                       AND m.dt_movimentacao = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)) & ") ap, "
        SqlText = SqlText & "                   sof.tipo_movimentacao tm1"
        SqlText = SqlText & "             WHERE ap.cd_tipo_movimentacao = tm1.cd_tipo_movimentacao"
        SqlText = SqlText & "               AND tm1.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "          GROUP BY ap.cd_tipo_movimentacao, tm1.no_tipo_movimentacao"
        SqlText = SqlText & "          UNION ALL"
        SqlText = SqlText & "          SELECT   ap.cd_tipo_movimentacao, tm1.no_tipo_movimentacao,"
        SqlText = SqlText & "                   SUM (ap.valor_relatorio) valor_relatorio,"
        SqlText = SqlText & "                   SUM (ap.valor_rd) valor_rd, SUM (ap.valor_cont) valor_cont,"
        SqlText = SqlText & "                   SUM (ap.qt_relatorio) qt_relatorio, SUM (ap.qt_rd) qt_rd"
        SqlText = SqlText & "              FROM (SELECT (SELECT p.cd_tp_mov_icms_transf"
        SqlText = SqlText & "                              FROM sof.parametro p) AS cd_tipo_movimentacao,"
        SqlText = SqlText & "                           m.vl_nf_icms * -1 valor_relatorio, 0 valor_rd,"
        SqlText = SqlText & "                           0 valor_cont, 0 qt_relatorio, 0 qt_rd"
        SqlText = SqlText & "                      FROM sof.tipo_movimentacao tm, sof.movimentacao m"
        SqlText = SqlText & "                     WHERE tm.cd_tipo_movimentacao = m.cd_tipo_movimentacao"
        SqlText = SqlText & "                       AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "                       AND m.dt_movimentacao = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "                    UNION ALL"
        SqlText = SqlText & "                    SELECT (SELECT p.cd_tp_mov_icms_transf"
        SqlText = SqlText & "                              FROM sof.parametro p) AS cd_tipo_movimentacao,"
        SqlText = SqlText & "                           m.vl_nf_icms valor_relatorio, 0 valor_rd,"
        SqlText = SqlText & "                           0 valor_cont, 0 qt_relatorio, 0 qt_rd"
        SqlText = SqlText & "                      FROM sof.movimentacao m,"
        SqlText = SqlText & "                           sof.fornecedor f,"
        SqlText = SqlText & "                           sof.tipo_movimentacao tm"
        SqlText = SqlText & "                     WHERE m.cd_fornecedor = f.cd_fornecedor(+)"
        SqlText = SqlText & "                       AND m.cd_tipo_movimentacao = tm.cd_tipo_movimentacao"
        SqlText = SqlText & "                       AND m.dt_movimentacao = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "                       AND tm.ic_entra_no_rd = 'S'"
        SqlText = SqlText & "                       AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "                       AND NOT f.ic_fisica_juridica IS NULL) ap,"
        SqlText = SqlText & "                   sof.tipo_movimentacao tm1"
        SqlText = SqlText & "             WHERE ap.cd_tipo_movimentacao = tm1.cd_tipo_movimentacao"
        SqlText = SqlText & "               AND tm1.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "          GROUP BY ap.cd_tipo_movimentacao, tm1.no_tipo_movimentacao"
        SqlText = SqlText & "          UNION ALL"
        SqlText = SqlText & "          SELECT   ap.cd_tipo_movimentacao, tm1.no_tipo_movimentacao,"
        SqlText = SqlText & "                   SUM (ap.valor_relatorio) valor_relatorio,"
        SqlText = SqlText & "                   SUM (ap.valor_rd) valor_rd, SUM (ap.valor_cont) valor_cont,"
        SqlText = SqlText & "                   SUM (ap.qt_relatorio) qt_relatorio, SUM (ap.qt_rd) qt_rd"
        SqlText = SqlText & "              FROM (SELECT DECODE"
        SqlText = SqlText & "                              (tm.ic_importacao,"
        SqlText = SqlText & "                               'S', (SELECT p.cd_tp_mov_fix_entrada_imp"
        SqlText = SqlText & "                                       FROM sof.parametro p),"
        SqlText = SqlText & "                               (SELECT p.cd_tp_mov_fixacao_entrada"
        SqlText = SqlText & "                                  FROM sof.parametro p)"
        SqlText = SqlText & "                              ) AS cd_tipo_movimentacao,"
        SqlText = SqlText & "                             cm.vl_fixo"
        SqlText = SqlText & "                           - ROUND ((DECODE(m.vl_nf, 0, 0, cm.vl_fixo / m.vl_nf)) * m.vl_nf_icms, 2)"
        SqlText = SqlText & "                                                              valor_relatorio,"
        SqlText = SqlText & "                           0 valor_rd, 0 valor_cont,"
        SqlText = SqlText & "                           cm.qt_kg_fixo qt_relatorio, 0 qt_rd"
        SqlText = SqlText & "                      FROM sof.tipo_movimentacao tm,"
        SqlText = SqlText & "                           sof.movimentacao m,"
        SqlText = SqlText & "                           sof.movimentacao_cessao_direito mcd,"
        SqlText = SqlText & "                           sof.ctr_paf_neg_ctr_fix_mov cm"
        SqlText = SqlText & "                     WHERE tm.cd_tipo_movimentacao = m.cd_tipo_movimentacao"
        SqlText = SqlText & "                       AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "                       AND mcd.sq_movimentacao = cm.sq_movimentacao"
        SqlText = SqlText & "                       AND mcd.sq_movimentacao_cessao_direito = cm.sq_movimentacao_cessao_direito"
        SqlText = SqlText & "                       AND mcd.sq_movimentacao = m.sq_movimentacao"
        SqlText = SqlText & "                       AND cm.dt_fixacao = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)) & ") ap,"
        SqlText = SqlText & "                   sof.tipo_movimentacao tm1"
        SqlText = SqlText & "             WHERE ap.cd_tipo_movimentacao = tm1.cd_tipo_movimentacao"
        SqlText = SqlText & "               AND tm1.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "          GROUP BY ap.cd_tipo_movimentacao, tm1.no_tipo_movimentacao"
        SqlText = SqlText & "          UNION ALL"
        SqlText = SqlText & "          SELECT 102, 'FUNRURAL', SUM (m.vl_nf_funrural) valor_relatorio,"
        SqlText = SqlText & "                 0 valor_rd, 0 valor_cont, 0 qt_relatorio, 0 qt_rd"
        SqlText = SqlText & "            FROM sof.movimentacao m, sof.tipo_movimentacao tm"
        SqlText = SqlText & "           WHERE m.cd_tipo_movimentacao = tm.cd_tipo_movimentacao"
        SqlText = SqlText & "             AND m.dt_movimentacao = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "             AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "          UNION ALL"
        SqlText = SqlText & "          SELECT   tm.cd_tipo_movimentacao, tm.no_tipo_movimentacao,"
        SqlText = SqlText & "                   0 valor_relatorio, SUM (r.vl_dia) valor_rd, 0 valor_cont,"
        SqlText = SqlText & "                   0 qt_relatorio, SUM (r.qt_kg_dia) qt_rd"
        SqlText = SqlText & "              FROM sof.resumo_diario_estoque r, sof.tipo_movimentacao tm"
        SqlText = SqlText & "             WHERE r.cd_tipo_movimentacao = tm.cd_tipo_movimentacao"
        SqlText = SqlText & "               AND r.dt_movimento = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "               AND r.ic_tipo_rd = 3"
        SqlText = SqlText & "               AND not r.cd_tipo_movimentacao in (997)"
        SqlText = SqlText & "               AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "               AND (r.qt_kg_dia <> 0 OR r.vl_dia <> 0)"
        SqlText = SqlText & "          GROUP BY tm.no_tipo_movimentacao, tm.cd_tipo_movimentacao"
        SqlText = SqlText & "          UNION ALL"
        SqlText = SqlText & "          SELECT   tm.cd_tipo_movimentacao, 'ESTOQUE DE CACAU' as no_tipo_movimentacao,"
        SqlText = SqlText & "                   0 valor_relatorio, 0 valor_rd, 0 valor_cont,"
        SqlText = SqlText & "                   0 qt_relatorio, SUM ((r.qt_kg_dia * decode (r.ic_entrada_saida ,'S',1,'E',-1,1))) qt_rd"
        SqlText = SqlText & "              FROM sof.resumo_diario_estoque r, sof.tipo_movimentacao tm"
        SqlText = SqlText & "             WHERE r.cd_tipo_movimentacao = tm.cd_tipo_movimentacao"
        SqlText = SqlText & "               AND tm.cd_tipo_movimentacao = 997"
        SqlText = SqlText & "               AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "               AND r.dt_movimento = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "               AND r.ic_tipo_rd = 3"
        SqlText = SqlText & "               AND (r.qt_kg_dia <> 0 OR r.vl_dia <> 0)"
        SqlText = SqlText & "          GROUP BY tm.no_tipo_movimentacao, tm.cd_tipo_movimentacao"
        SqlText = SqlText & "          UNION ALL"
        SqlText = SqlText & "          SELECT 997 CD_TIPO_MOVIMENTACAO, 'ESTOQUE DE CACAU' NO_TIPO_MOVIMENTACAO, "
        SqlText = SqlText & "                   0 valor_relatorio, 0 valor_rd, 0 valor_cont,"
        SqlText = SqlText & "                SUM(MOV.QT_VOLUME * DECODE(MOV.IC_SAIDA, 'S', -1, 1)) qt_relatorio, 0 qt_rd"
        SqlText = SqlText & "           FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO MOV,"
        SqlText = SqlText & "                SOF.ARMAZEM ARM"
        SqlText = SqlText & "           WHERE TRUNC(MOV.DT_TRANSACAO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "             AND ARM.CD_ARMAZEM = MOV.CD_ARMAZEM"
        SqlText = SqlText & "          UNION ALL"
        SqlText = SqlText & "          SELECT   tm.cd_tipo_movimentacao, i.ds_movimento,"
        SqlText = SqlText & "                   0 valor_relatorio, 0 valor_rd,"
        SqlText = SqlText & "                   SUM (i.vl_movimento) valor_cont, 0 qt_relatorio, 0 qt_rd"
        SqlText = SqlText & "              FROM sof.interface_jde i,"
        SqlText = SqlText & "                   sof.movimentacao m,"
        SqlText = SqlText & "                   sof.tipo_movimentacao tm"
        SqlText = SqlText & "             WHERE i.dt_movimento = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "               AND i.sq_movimentacao = m.sq_movimentacao"
        SqlText = SqlText & "               AND m.cd_tipo_movimentacao = tm.cd_tipo_movimentacao"
        SqlText = SqlText & "               AND i.vl_movimento > 0"
        SqlText = SqlText & "               AND TM.CD_TIPO_MOVIMENTACAO IN (145, 146)"
        SqlText = SqlText & "               AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "          GROUP BY tm.cd_tipo_movimentacao, i.ds_movimento"
        SqlText = SqlText & "          UNION ALL"
        SqlText = SqlText & "          SELECT CD_TIPO_MOVIMENTACAO, DS_MOVIMENTO,"
        SqlText = SqlText & "                 0 valor_relatorio, 0 valor_rd,"
        SqlText = SqlText & "                 SUM (vl_movimento * decode(ds_movimento,'ICMS S/COMPRAS',-1,'SAIDAS PARA APLICACAO NACIONAL',-1,'SAIDAS PARA APLICACAO IMPORT',-1,1)) valor_cont, 0 qt_relatorio, 0 qt_rd"
        SqlText = SqlText & "           FROM (SELECT   I.NU_CONTA_CONTABIL, TM.NU_CONTA_CONTABIL, TM.NU_CONTA_CONTABIL_CP,"
        SqlText = SqlText & "                          tm.cd_tipo_movimentacao, i.ds_movimento,"
        SqlText = SqlText & "                          0 valor_relatorio, 0 valor_rd,"
        SqlText = SqlText & "                          SUM (i.vl_movimento) vl_movimento, 0 qt_relatorio, 0 qt_rd"
        SqlText = SqlText & "                  FROM sof.interface_jde i,"
        SqlText = SqlText & "                       sof.movimentacao m,"
        SqlText = SqlText & "                       sof.tipo_movimentacao tm"
        SqlText = SqlText & "                  WHERE i.dt_movimento  = " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        SqlText = SqlText & "                    AND i.sq_movimentacao = m.sq_movimentacao"
        SqlText = SqlText & "                    AND m.cd_tipo_movimentacao = tm.cd_tipo_movimentacao"
        SqlText = SqlText & "                    AND TM.CD_TIPO_MOVIMENTACAO NOT IN (145, 146)"
        SqlText = SqlText & "                    AND tm.ic_tipo_utilizacao not in ('T') "
        SqlText = SqlText & "                  GROUP BY I.NU_CONTA_CONTABIL, TM.NU_CONTA_CONTABIL, TM.NU_CONTA_CONTABIL_CP, tm.cd_tipo_movimentacao, i.ds_movimento )"
        SqlText = SqlText & "           WHERE vl_movimento > 0"
        SqlText = SqlText & "           GROUP BY cd_tipo_movimentacao, ds_movimento)"
        SqlText = SqlText & "GROUP BY  no_tipo_movimentacao"

        oDataAux = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_Conferencia_Contabil.rpt")

        oRelatorio.SetDataSource(oData)
        oRelatorio_Sub1 = oRelatorio.Subreports("Conferencia Contabil RD")
        oRelatorio_Sub1.SetDataSource(oDataAux)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        oRelatorio.SetParameterValue("ValorContabilidade", txtValorContabilidade.Value)

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub frmREL_ConferenciaContabil_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_ConferenciaContabil_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub frmREL_ConferenciaContabil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        txtDataInicial.ReadOnly = True
        txtDataFinal.DateTime = DateAdd(DateInterval.Day, -1, Now).Date
    End Sub

    Private Sub txtDataFinal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDataFinal.ValueChanged
        txtDataInicial.DateTime = New Date(txtDataFinal.DateTime.Year, txtDataFinal.DateTime.Month, 1)
    End Sub
End Class