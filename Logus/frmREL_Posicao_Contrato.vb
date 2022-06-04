Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Posicao_Contrato
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_Posicao_Contrato_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Posicao_Contrato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        Pega_Valores()
        txtDiasVencer.Value = 10

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        SqlText = "(SELECT 1 as Cod, 'Prazo de Entrega Vencida - Contrato Paf' as Nome "
        SqlText = SqlText & "  FROM DUAL "
        SqlText = SqlText & "UNION ALL "
        SqlText = SqlText & "SELECT 2 as Cod, 'Prazo de Entrega Vencida - Contrato Fixo' as Nome "
        SqlText = SqlText & "  FROM DUAL "
        SqlText = SqlText & "UNION ALL "
        SqlText = SqlText & "SELECT 3 as Cod, 'Prazo de Fixação Vencido ou a Vencer' as Nome "
        SqlText = SqlText & "  FROM DUAL "
        SqlText = SqlText & "UNION ALL "
        SqlText = SqlText & "SELECT 4 as Cod, 'Cacau Recebido X Adiatamento' as Nome "
        SqlText = SqlText & "  FROM DUAL)"

        With SelecaoOpcao
            .BancoDados_Tabela = SqlText
            .BancoDados_Campo_Codigo = "Cod"
            .BancoDados_Campo_Descricao = "Nome"
            .BancoDados_Carregar()
        End With

        With SelecaoSafra
            .BancoDados_Tabela = "SOF.SAFRA"
            .BancoDados_Campo_Codigo = "CD_SAFRA"
            .BancoDados_Campo_Descricao = "DS_SAFRA"
            .BancoDados_Carregar()
        End With

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Pega_Valores()
        Dim SqlText As String
        Dim VlCotacao As Double
        Dim VlDolar As Double
        Dim oData As DataTable

        SqlText = "SELECT VL_COTACAO, IC_BOLSA_SEM_SINAL, IC_ALTERNATIVO, VL_COTACAO_ALTERNATIVO, " & _
                  "VL_DIFERENCIAL, VL_DIFERENCA " & _
                  "From SOF.BOLSA_PERIODO " & _
                  "Where IC_MOEDA ='N'  " & _
                  "ORDER BY NU_SEQUENCIA"

        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then Exit Sub

        If oData.Rows(0).Item("IC_BOLSA_SEM_SINAL") = "S" Or oData.Rows(0).Item("IC_ALTERNATIVO") = "S" Then
            If objDataTable_CampoVazio(oData.Rows(0).Item("VL_COTACAO_ALTERNATIVO")) Then
                VlCotacao = 0
            Else
                VlCotacao = oData.Rows(0).Item("vl_cotacao_alternativo") + oData.Rows(0).Item("VL_DIFERENCIAL")
            End If
        Else
            If objDataTable_CampoVazio(oData.Rows(0).Item("vl_cotacao")) Then
                VlCotacao = 0
            Else
                VlCotacao = oData.Rows(0).Item("vl_cotacao") + oData.Rows(0).Item("VL_DIFERENCIAL")
            End If
        End If

        SqlText = "SELECT b.VL_COTACAO, b.IC_BOLSA_SEM_SINAL, b.IC_ALTERNATIVO, b.VL_COTACAO_ALTERNATIVO, " & _
                  "NVL(a.VL_JUROS_DIA,0) VL_JUROS_DIA " & _
                  "From SOF.BOLSA_PARAMETRO a, SOF.BOLSA_PERIODO B " & _
                  "Where A.CD_PAPEL_DOLAR = B.CD_PAPEL"

        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then Exit Sub

        If oData.Rows(0).Item("IC_BOLSA_SEM_SINAL") = "S" Or oData.Rows(0).Item("IC_ALTERNATIVO") = "S" Then
            If objDataTable_CampoVazio(oData.Rows(0).Item("VL_COTACAO_ALTERNATIVO")) Then
                VlDolar = 0
            Else
                VlDolar = oData.Rows(0).Item("vl_cotacao_alternativo")
            End If
        Else
            If objDataTable_CampoVazio(oData.Rows(0).Item("vl_cotacao")) Then
                VlDolar = 0
            Else
                VlDolar = oData.Rows(0).Item("vl_cotacao")
            End If
        End If

        txtValorArroba.Value = ((VlCotacao * VlDolar) / 1000) * 15

    End Sub

    Private Sub frmREL_Posicao_Contrato_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""
        Dim SqlSafra As String
        Dim DescSafra As String

        If txtValorArroba.Value = 0 Then
            Msg_Mensagem("Favor informa o preço.")
            txtValorArroba.Focus()
            Exit Sub
        End If

        AVI_Carregar(Me)

        If SelecaoSafra.Lista_Quantidade <> 0 Then
            SqlSafra = " and cp.cd_safra in (" & SelecaoSafra.Lista_ID & ") "
            DescSafra = " - " & SelecaoSafra.Lista_Descricao
        Else
            DescSafra = ""
            SqlSafra = ""
        End If

        'todos ou Prazo de Entrega Vencida - Contrato Paf
        If InStr(SelecaoOpcao.Lista_ID, "1") > 0 Or SelecaoOpcao.Lista_Quantidade = 0 Then
            SqlText = "SELECT forn.cd_fornecedor, forn.no_razao_social, "
            SqlText = SqlText & "       rep.cd_fornecedor AS cd_repassador, "
            SqlText = SqlText & "       rep.no_razao_social AS no_repassador, to_char(cp.cd_contrato_paf) AS contrato, "
            SqlText = SqlText & "       fil.no_filial, cp.dt_contrato_paf as dt_contrato, cp.dt_prazo_fixacao, "
            SqlText = SqlText & "       cp.dt_prazo_entrega, cp.qt_kgs - cp.qt_cancelado AS qt_kgs, "
            SqlText = SqlText & "       cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo as qt_kg_a_fixar, cp.qt_a_negociar, 'Contrato Paf' AS tipo_ctr, "
            SqlText = SqlText & "       'Prazo de Entrega Vencida - Contrato Paf' AS tipo, "
            SqlText = SqlText & "       NVL (pag.vl_pag_ab, 0) vl_pag_ab, NVL (pag.vl_pag_ab_juros, 0) vl_pag_ab_juros, cast(null as number) risco,   round((cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo) * (" & txtValorArroba.Value & " / 15), 10) vl_kg_a_negociar "
            SqlText = SqlText & "  FROM sof.contrato_paf cp, "
            SqlText = SqlText & "       sof.fornecedor forn, "
            SqlText = SqlText & "       sof.fornecedor rep, "
            SqlText = SqlText & "       sof.filial fil, "
            SqlText = SqlText & "       (SELECT  round( SUM "
            SqlText = SqlText & "                            (DECODE "
            SqlText = SqlText & "                                (cp.ic_calcula_juros || tp.ic_calcula_juros, "
            SqlText = SqlText & "                                 'SS', (  (  DECODE "
            SqlText = SqlText & "                                                (SIGN "
            SqlText = SqlText & "                                                    (  (  SYSDATE "
            SqlText = SqlText & "                                                        - p.dt_pagamento "
            SqlText = SqlText & "                                                       ) "
            SqlText = SqlText & "                                                     - NVL "
            SqlText = SqlText & "                                                          (cp.qt_dia_carencia_juros, "
            SqlText = SqlText & "                                                           0 "
            SqlText = SqlText & "                                                          ) "
            SqlText = SqlText & "                                                    ), "
            SqlText = SqlText & "                                                 -1, 0, "
            SqlText = SqlText & "                                                 ROUND "
            SqlText = SqlText & "                                                    ((  (  TO_DATE (SYSDATE) "
            SqlText = SqlText & "                                                         - TO_DATE "
            SqlText = SqlText & "                                                               (p.dt_pagamento) "
            SqlText = SqlText & "                                                        ) "
            SqlText = SqlText & "                                                      - DECODE "
            SqlText = SqlText & "                                                           (cp.ic_juros_apos_carencia, "
            SqlText = SqlText & "                                                            'S', NVL "
            SqlText = SqlText & "                                                               (cp.qt_dia_carencia_juros, "
            SqlText = SqlText & "                                                                0 "
            SqlText = SqlText & "                                                               ), "
            SqlText = SqlText & "                                                            0 "
            SqlText = SqlText & "                                                           ) "
            SqlText = SqlText & "                                                     ), "
            SqlText = SqlText & "                                                     0 "
            SqlText = SqlText & "                                                    ) "
            SqlText = SqlText & "                                                ) "
            SqlText = SqlText & "                                           * ((cp.pc_taxa_juros / 100) / 30) "
            SqlText = SqlText & "                                          ) "
            SqlText = SqlText & "                                        * pcp.vl_a_fixar "
            SqlText = SqlText & "                                     ) "
            SqlText = SqlText & "                                  + pcp.vl_a_fixar, "
            SqlText = SqlText & "                                 pcp.vl_a_fixar "
            SqlText = SqlText & "                                ) "
            SqlText = SqlText & "                            ),2) vl_pag_ab_juros, "
            SqlText = SqlText & "                         NVL (SUM (pcp.vl_a_fixar), 0) vl_pag_ab, "
            SqlText = SqlText & "                         cp.cd_contrato_paf "
            SqlText = SqlText & "                    FROM sof.pag_ctr_paf pcp, "
            SqlText = SqlText & "                         sof.pagamentos p, "
            SqlText = SqlText & "                         sof.contrato_paf cp, "
            SqlText = SqlText & "                         sof.tipo_pagamento tp "
            SqlText = SqlText & "                   WHERE pcp.cd_contrato_paf = cp.cd_contrato_paf "
            SqlText = SqlText & "                     AND pcp.sq_pagamento = p.sq_pagamento "
            SqlText = SqlText & "                     AND pcp.vl_a_fixar <> 0 "
            SqlText = SqlText & "                     AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
            SqlText = SqlText & "                GROUP BY cp.cd_contrato_paf) pag "
            SqlText = SqlText & " WHERE TRUNC (cp.dt_prazo_entrega) < TRUNC (SYSDATE) "
            SqlText = SqlText & "   AND cp.cd_fornecedor = forn.cd_fornecedor "
            SqlText = SqlText & "   AND cp.cd_repassador = rep.cd_fornecedor "
            SqlText = SqlText & "   AND cp.cd_filial_origem = fil.cd_filial "
            SqlText = SqlText & "   AND cp.cd_contrato_paf = pag.cd_contrato_paf(+) "
            SqlText = SqlText & "   AND cp.ic_status = 'A' and cp.qt_a_negociar<>0 "
            SqlText = SqlText & "   AND cp.qt_kgs - cp.qt_cancelado <> cp.qt_kg_fixo "

            'FILTRO FILIAL
            If SelecaoFilial.Lista_Quantidade > 0 Then
                SqlText = SqlText & " AND cp.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
            Else
                SqlText = SqlText & " AND cp.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If

            If Pesq_Fornecedor.Codigo <> 0 Then
                SqlText = SqlText & " and cp.cd_fornecedor = " & Pesq_Fornecedor.Codigo
            End If

            SqlText = SqlText & SqlSafra

        End If

        'todos ou Prazo de Entrega Vencida - Contrato Fixo
        If InStr(SelecaoOpcao.Lista_ID, "2") > 0 Or SelecaoOpcao.Lista_Quantidade = 0 Then
            If SqlText <> "" Then
                SqlText = SqlText & " UNION ALL "
            End If
            SqlText = SqlText & "SELECT forn.cd_fornecedor, forn.no_razao_social, "
            SqlText = SqlText & "       rep.cd_fornecedor AS cd_repassador, "
            SqlText = SqlText & "       rep.no_razao_social AS no_repassador, cf.cd_contrato_paf ||'-'|| cf.sq_negociacao ||'-'|| cf.sq_contrato_fixo   AS contrato, "
            SqlText = SqlText & "       fil.no_filial, cf.dt_contrato_fixo as dt_contrato, CAST (NULL AS date) dt_prazo_fixacao, "
            SqlText = SqlText & "       cf.dt_vencimento AS dt_prazo_entrega, "
            SqlText = SqlText & "       cf.qt_kgs - cf.qt_cancelado AS qt_kgs, cf.qt_kgs - cf.qt_cancelado - cf.qt_kg_fixo qt_kg_a_fixar, "
            SqlText = SqlText & "       CAST (NULL AS number) AS qt_a_negociar, 'Contrato Fixo' AS tipo_ctr, "
            SqlText = SqlText & "       'Prazo de Entrega Vencida - Contrato Fixo' AS tipo,  CAST (NULL AS number) as vl_pag_ab, CAST (NULL AS number) as vl_pag_ab_juros, cast(null as number) risco,   CAST (NULL AS number) AS vl_kg_a_negociar "
            SqlText = SqlText & "  FROM sof.contrato_fixo cf, "
            SqlText = SqlText & "       sof.contrato_paf cp, "
            SqlText = SqlText & "       sof.fornecedor forn, "
            SqlText = SqlText & "       sof.fornecedor rep, "
            SqlText = SqlText & "       sof.filial fil "
            SqlText = SqlText & " WHERE TRUNC (cf.dt_vencimento) < TRUNC (SYSDATE) "
            SqlText = SqlText & "   AND cp.cd_contrato_paf = cf.cd_contrato_paf "
            SqlText = SqlText & "   AND cp.cd_fornecedor = forn.cd_fornecedor "
            SqlText = SqlText & "   AND cp.cd_repassador = rep.cd_fornecedor "
            SqlText = SqlText & "   AND cp.cd_filial_origem = fil.cd_filial "
            SqlText = SqlText & "   AND cf.ic_status = 'A' "
            SqlText = SqlText & "   AND cf.qt_kgs - cf.qt_cancelado <> cf.qt_kg_fixo "

            'FILTRO FILIAL
            If SelecaoFilial.Lista_Quantidade > 0 Then
                SqlText = SqlText & " AND cp.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
            Else
                SqlText = SqlText & " AND cp.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If

            If Pesq_Fornecedor.Codigo <> 0 Then
                SqlText = SqlText & " and cp.cd_fornecedor = " & Pesq_Fornecedor.Codigo
            End If

            SqlText = SqlText & SqlSafra
        End If

        'todos ou Prazo de Fixação Vencido ou a Vencer
        If InStr(SelecaoOpcao.Lista_ID, "3") > 0 Or SelecaoOpcao.Lista_Quantidade = 0 Then
            If SqlText <> "" Then
                SqlText = SqlText & " UNION ALL "
            End If
            SqlText = SqlText & "SELECT forn.cd_fornecedor, forn.no_razao_social, "
            SqlText = SqlText & "       rep.cd_fornecedor AS cd_repassador, "
            SqlText = SqlText & "       rep.no_razao_social AS no_repassador, to_char(cp.cd_contrato_paf) as contrato, "
            SqlText = SqlText & "       fil.no_filial, cp.dt_contrato_paf as dt_contrato, cp.dt_prazo_fixacao, "
            SqlText = SqlText & "       cp.dt_prazo_entrega, cp.qt_kgs -cp.qt_cancelado  as qt_kgs, cp.qt_kg_fixo as qt_kg_a_fixar , cp.qt_a_negociar , "
            SqlText = SqlText & "       'Contrato Paf' AS tipo_ctr, "
            SqlText = SqlText & "       'Prazo de Fixação Vencido ou a Vencer' AS tipo, "
            SqlText = SqlText & "       NVL (pag.vl_pag_ab, 0) vl_pag_ab, NVL (pag.vl_pag_ab_juros, 0) vl_pag_ab_juros, cast(null as number) risco,   round((cp.qt_kg_fixo)  * (" & txtValorArroba.Value & " / 15), 10) vl_kg_a_negociar "
            SqlText = SqlText & "  FROM sof.contrato_paf cp, "
            SqlText = SqlText & "       sof.fornecedor forn, "
            SqlText = SqlText & "       sof.fornecedor rep, "
            SqlText = SqlText & "       sof.filial fil, "
            SqlText = SqlText & "           (SELECT  round( SUM "
            SqlText = SqlText & "                            (DECODE "
            SqlText = SqlText & "                                (cp.ic_calcula_juros || tp.ic_calcula_juros, "
            SqlText = SqlText & "                                 'SS', (  (  DECODE "
            SqlText = SqlText & "                                                (SIGN "
            SqlText = SqlText & "                                                    (  (  SYSDATE "
            SqlText = SqlText & "                                                        - p.dt_pagamento "
            SqlText = SqlText & "                                                       ) "
            SqlText = SqlText & "                                                     - NVL "
            SqlText = SqlText & "                                                          (cp.qt_dia_carencia_juros, "
            SqlText = SqlText & "                                                           0 "
            SqlText = SqlText & "                                                          ) "
            SqlText = SqlText & "                                                    ), "
            SqlText = SqlText & "                                                 -1, 0, "
            SqlText = SqlText & "                                                 ROUND "
            SqlText = SqlText & "                                                    ((  (  TO_DATE (SYSDATE) "
            SqlText = SqlText & "                                                         - TO_DATE "
            SqlText = SqlText & "                                                               (p.dt_pagamento) "
            SqlText = SqlText & "                                                        ) "
            SqlText = SqlText & "                                                      - DECODE "
            SqlText = SqlText & "                                                           (cp.ic_juros_apos_carencia, "
            SqlText = SqlText & "                                                            'S', NVL "
            SqlText = SqlText & "                                                               (cp.qt_dia_carencia_juros, "
            SqlText = SqlText & "                                                                0 "
            SqlText = SqlText & "                                                               ), "
            SqlText = SqlText & "                                                            0 "
            SqlText = SqlText & "                                                           ) "
            SqlText = SqlText & "                                                     ), "
            SqlText = SqlText & "                                                     0 "
            SqlText = SqlText & "                                                    ) "
            SqlText = SqlText & "                                                ) "
            SqlText = SqlText & "                                           * ((cp.pc_taxa_juros / 100) / 30) "
            SqlText = SqlText & "                                          ) "
            SqlText = SqlText & "                                        * pcp.vl_a_fixar "
            SqlText = SqlText & "                                     ) "
            SqlText = SqlText & "                                  + pcp.vl_a_fixar, "
            SqlText = SqlText & "                                 pcp.vl_a_fixar "
            SqlText = SqlText & "                                ) "
            SqlText = SqlText & "                            ),2) vl_pag_ab_juros, "
            SqlText = SqlText & "                         NVL (SUM (pcp.vl_a_fixar), 0) vl_pag_ab, "
            SqlText = SqlText & "                         cp.cd_contrato_paf "
            SqlText = SqlText & "                    FROM sof.pag_ctr_paf pcp, "
            SqlText = SqlText & "                         sof.pagamentos p, "
            SqlText = SqlText & "                         sof.contrato_paf cp, "
            SqlText = SqlText & "                         sof.tipo_pagamento tp "
            SqlText = SqlText & "                   WHERE pcp.cd_contrato_paf = cp.cd_contrato_paf "
            SqlText = SqlText & "                     AND pcp.sq_pagamento = p.sq_pagamento "
            SqlText = SqlText & "                     AND pcp.vl_a_fixar <> 0 "
            SqlText = SqlText & "                     AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
            SqlText = SqlText & "                GROUP BY cp.cd_contrato_paf) pag "
            SqlText = SqlText & " WHERE TRUNC (cp.dt_prazo_fixacao ) < TRUNC (SYSDATE+" & txtDiasVencer.Value & ") "
            SqlText = SqlText & "   AND cp.cd_fornecedor = forn.cd_fornecedor "
            SqlText = SqlText & "   AND cp.cd_repassador = rep.cd_fornecedor "
            SqlText = SqlText & "   AND cp.cd_filial_origem = fil.cd_filial "
            SqlText = SqlText & "   AND cp.cd_contrato_paf = pag.cd_contrato_paf(+) "
            SqlText = SqlText & "   AND cp.ic_status = 'A' "
            SqlText = SqlText & "   AND cp.qt_a_negociar <>0 "

            'FILTRO FILIAL
            If SelecaoFilial.Lista_Quantidade > 0 Then
                SqlText = SqlText & " AND cp.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
            Else
                SqlText = SqlText & " AND cp.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If

            If Pesq_Fornecedor.Codigo <> 0 Then
                SqlText = SqlText & " and cp.cd_fornecedor = " & Pesq_Fornecedor.Codigo
            End If

            SqlText = SqlText & SqlSafra
        End If

        'todos ou Cacau Recebido X Adiatamento
        If InStr(SelecaoOpcao.Lista_ID, "4") > 0 Or SelecaoOpcao.Lista_Quantidade = 0 Then
            If SqlText <> "" Then
                SqlText = SqlText & " UNION ALL "
            End If
            SqlText = SqlText & "   SELECT forn.cd_fornecedor, forn.no_razao_social, "
            SqlText = SqlText & "       rep.cd_fornecedor AS cd_repassador, "
            SqlText = SqlText & "       rep.no_razao_social AS no_repassador, "
            SqlText = SqlText & "       TO_CHAR (cp.cd_contrato_paf) AS contrato, fil.no_filial, "
            SqlText = SqlText & "       cp.dt_contrato_paf AS dt_contrato, cp.dt_prazo_fixacao, "
            SqlText = SqlText & "       cp.dt_prazo_entrega, cp.qt_kgs - cp.qt_cancelado  AS qt_kgs, "
            SqlText = SqlText & "       rec.qt_kg_a_fixar, cp.qt_a_negociar, 'Contrato Paf' AS tipo_ctr, "
            SqlText = SqlText & "       'Cacau Recebido X Adiatamento' AS tipo, NVL (pag.vl_pag_ab, 0) vl_pag_ab, "
            SqlText = SqlText & "       NVL (pag.vl_pag_ab_juros, 0) vl_pag_ab_juros, "
            SqlText = SqlText & "       round(rec.qt_kg_a_fixar * (" & txtValorArroba.Value & "/15) *100 /decode(NVL (pag.vl_pag_ab_juros, 1),0,1,NVL (pag.vl_pag_ab_juros, 1)),2) as risco,    round(rec.qt_kg_a_fixar * (" & txtValorArroba.Value & " / 15), 10) vl_kg_a_negociar "
            SqlText = SqlText & "  FROM sof.contrato_paf cp, "
            SqlText = SqlText & "       sof.fornecedor forn, "
            SqlText = SqlText & "       sof.fornecedor rep, "
            SqlText = SqlText & "       sof.filial fil, "
            SqlText = SqlText & "       (SELECT   round(SUM "
            SqlText = SqlText & "                    (DECODE "
            SqlText = SqlText & "                        (cp.ic_calcula_juros || tp.ic_calcula_juros, "
            SqlText = SqlText & "                         'SS', (  (  DECODE "
            SqlText = SqlText & "                                        (SIGN (  (SYSDATE - p.dt_pagamento) "
            SqlText = SqlText & "                                               - NVL "
            SqlText = SqlText & "                                                    (cp.qt_dia_carencia_juros, "
            SqlText = SqlText & "                                                     0 "
            SqlText = SqlText & "                                                    ) "
            SqlText = SqlText & "                                              ), "
            SqlText = SqlText & "                                         -1, 0, "
            SqlText = SqlText & "                                         ROUND "
            SqlText = SqlText & "                                            ((  (  TO_DATE (SYSDATE) "
            SqlText = SqlText & "                                                 - TO_DATE (p.dt_pagamento) "
            SqlText = SqlText & "                                                ) "
            SqlText = SqlText & "                                              - DECODE "
            SqlText = SqlText & "                                                   (cp.ic_juros_apos_carencia, "
            SqlText = SqlText & "                                                    'S', NVL "
            SqlText = SqlText & "                                                       (cp.qt_dia_carencia_juros, "
            SqlText = SqlText & "                                                        0 "
            SqlText = SqlText & "                                                       ), "
            SqlText = SqlText & "                                                    0 "
            SqlText = SqlText & "                                                   ) "
            SqlText = SqlText & "                                             ), "
            SqlText = SqlText & "                                             0 "
            SqlText = SqlText & "                                            ) "
            SqlText = SqlText & "                                        ) "
            SqlText = SqlText & "                                   * ((cp.pc_taxa_juros / 100) / 30) "
            SqlText = SqlText & "                                  ) "
            SqlText = SqlText & "                                * pcp.vl_a_fixar "
            SqlText = SqlText & "                             ) "
            SqlText = SqlText & "                          + pcp.vl_a_fixar, "
            SqlText = SqlText & "                         pcp.vl_a_fixar "
            SqlText = SqlText & "                        ) "
            SqlText = SqlText & "                    ),2) vl_pag_ab_juros, "
            SqlText = SqlText & "                 NVL (SUM (pcp.vl_a_fixar), 0) vl_pag_ab, cp.cd_contrato_paf "
            SqlText = SqlText & "            FROM sof.pag_ctr_paf pcp, "
            SqlText = SqlText & "                 sof.pagamentos p, "
            SqlText = SqlText & "                 sof.contrato_paf cp, "
            SqlText = SqlText & "                 sof.tipo_pagamento tp "
            SqlText = SqlText & "           WHERE pcp.cd_contrato_paf = cp.cd_contrato_paf "
            SqlText = SqlText & "             AND pcp.sq_pagamento = p.sq_pagamento "
            SqlText = SqlText & "             AND pcp.vl_a_fixar <> 0 "
            SqlText = SqlText & "             AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
            SqlText = SqlText & "        GROUP BY cp.cd_contrato_paf) pag, "
            SqlText = SqlText & "         (SELECT  sum(cpm.qt_kg_a_fixar ) as qt_kg_a_fixar   , "
            SqlText = SqlText & "                         cp.cd_contrato_paf "
            SqlText = SqlText & "                    FROM sof.ctr_paf_movimentacao cpm, "
            SqlText = SqlText & "                         sof.contrato_paf cp, "
            SqlText = SqlText & "                         sof.movimentacao m "
            SqlText = SqlText & "                   WHERE m.sq_movimentacao = cpm.sq_movimentacao "
            SqlText = SqlText & "                     AND cpm.cd_contrato_paf = cp.cd_contrato_paf "
            SqlText = SqlText & "                     AND cpm.qt_kg_a_fixar <> 0 "
            SqlText = SqlText & "                GROUP BY cp.cd_contrato_paf) rec "
            SqlText = SqlText & " WHERE TRUNC (cp.dt_prazo_entrega) < TRUNC (SYSDATE) "
            SqlText = SqlText & "   AND cp.cd_fornecedor = forn.cd_fornecedor "
            SqlText = SqlText & "   AND cp.cd_repassador = rep.cd_fornecedor "
            SqlText = SqlText & "   AND cp.cd_filial_origem = fil.cd_filial "
            SqlText = SqlText & "   AND cp.cd_contrato_paf = pag.cd_contrato_paf(+) "
            SqlText = SqlText & "   AND cp.cd_contrato_paf = rec.cd_contrato_paf(+) "
            SqlText = SqlText & "   AND cp.ic_status = 'A' "
            'SqlText = SqlText & "   AND cp.qt_kgs - cp.qt_cancelado <> cp.qt_kg_fixo "
            SqlText = SqlText & "   and (rec.qt_kg_a_fixar  * (" & txtValorArroba.Value & "/15) *100 /decode(NVL (pag.vl_pag_ab_juros, 1),0,1,NVL (pag.vl_pag_ab_juros, 1)))<=105 "
            SqlText = SqlText & "   and rec.qt_kg_a_fixar <>0 "

            'FILTRO FILIAL
            If SelecaoFilial.Lista_Quantidade > 0 Then
                SqlText = SqlText & " AND cp.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
            Else
                SqlText = SqlText & " AND cp.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If
            If Pesq_Fornecedor.Codigo <> 0 Then
                SqlText = SqlText & " and CP.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
            End If

            SqlText = SqlText & SqlSafra
        End If

        oData = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_Posicao_Contrato.rpt")
        oRelatorio.SetDataSource(oData)

        sFiltro = "Dias a Vencer: " & txtDiasVencer.Value & " - " & _
                  "Preço Medio @ R$: " & Format(txtValorArroba.Value, "#,##0.00") & DescSafra


        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        crvMain.ReportSource = oRelatorio


        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Pega_Valores()
    End Sub
End Class