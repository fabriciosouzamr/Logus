Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRelatorioGeral_FilialPeriodo
    Public Enum RGFP_TipoRelatorio
        ProvisaoImpostos = 1
        Conciliacao = 2
        DivergenciaFrete = 3
        InterfaceLivroFiscal = 4
        QuebraSobra = 5
        ContratosFixosCancelados = 6
        NotaFiscalComplementar = 7
        SaldoSacariaFornecedor = 8
        SaldoSacariaRepassador = 9
        MovimentacaoEmNegociacao = 10
        MovimentacaoPorMunicipio = 11
        AcertoRD = 12
    End Enum

    Public oTipoRelatorio As RGFP_TipoRelatorio
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub Imprimir()
        Select Case oTipoRelatorio
            Case RGFP_TipoRelatorio.ProvisaoImpostos
                If Not Data_ValidarPeriodo("da movimentação", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub
            Case RGFP_TipoRelatorio.Conciliacao
                If Not Data_ValidarPeriodo("da conciliação", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub
            Case RGFP_TipoRelatorio.DivergenciaFrete
                If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub
            Case RGFP_TipoRelatorio.InterfaceLivroFiscal
                If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub
            Case RGFP_TipoRelatorio.QuebraSobra
                If Not Data_ValidarPeriodo("da movimentação", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub
            Case RGFP_TipoRelatorio.ContratosFixosCancelados
                If Not Data_ValidarPeriodo("do cancelamento", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub
        End Select

        Dim oRelatorio_Sub1 As New ReportDocument
        Dim oRelatorio_Sub2 As New ReportDocument
        Dim oData As DataTable
        Dim oData_Sub1 As DataTable
        Dim oData_Sub2 As DataTable
        Dim SqlText As String
        Dim sFiltro As String = ""
        Dim sFiltro02 As String = ""
        Dim SqlFiltro As String = ""

        AVI_Carregar(Me)

        Select Case oTipoRelatorio
            Case RGFP_TipoRelatorio.AcertoRD
                SqlText = "SELECT FI.NO_FILIAL," & _
                                 "TM.NO_TIPO_MOVIMENTACAO," & _
                                 "NVL(TM.IC_IMPORTACAO,'N') IC_IMPORTACAO," & _
                                 "TM.IC_ENTRA_NO_RD," & _
                                 "TM.IC_ACERTO_ICMS," & _
                                 "MV.DT_MOVIMENTACAO," & _
                                 "MV.QT_KG_LIQUIDO_NF," & _
                                 "MV.VL_NF," & _
                                 "MV.VL_NF_ICMS," & _
                                 "MV.VL_NF_FUNRURAL," & _
                                 "MA.DS_ACERTO," & _
                                 "MA.NO_USER_CRIACAO," & _
                                 "MA.DT_CRIACAO" & _
                          " FROM SOF.MOVIMENTACAO_ACERTO MA," & _
                                "SOF.MOVIMENTACAO MV," & _
                                "SOF.TIPO_MOVIMENTACAO TM," & _
                                "SOF.FILIAL FI" & _
                          " WHERE MV.SQ_MOVIMENTACAO = MA.SQ_MOVIMENTACAO" & _
                            " AND TM.CD_TIPO_MOVIMENTACAO = MV.CD_TIPO_MOVIMENTACAO" & _
                            " AND FI.CD_FILIAL = MV.CD_FILIAL_MOVIMENTACAO"

                If EhData(txtDataInicial.Text) Then
                    Str_Adicionar(SqlText, "TRUNC(MA.DT_CRIACAO) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)), " AND ")
                End If
                If EhData(txtDataFinal.Text) Then
                    Str_Adicionar(SqlText, "TRUNC(MA.DT_CRIACAO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)), " AND ")
                End If
                If Selecao01.Lista_Quantidade > 0 Then
                    Str_Adicionar(SqlText, "TM.CD_TIPO_MOVIMENTACAO IN (" & Selecao01.Lista_ID & ")", " AND ")
                End If

                SqlText = SqlText & _
                          " GROUP BY MV.DT_MOVIMENTACAO," & _
                                    "FI.NO_FILIAL," & _
                                    "TM.NO_TIPO_MOVIMENTACAO"
            Case RGFP_TipoRelatorio.ProvisaoImpostos
                SqlText = "SELECT P.NO_PROVISAO," & _
                                 "IMBP.CD_PROVISAO," & _
                                 "MB.DT_MOVIMENTACAO," & _
                                 "NVL (IMB.NO_FAVORECIDO, MB.NO_FAVORECIDO) NO_FAVORECIDO," & _
                                 "FIL.NO_FILIAL," & _
                                 "IMB.VL_PAGO," & _
                                 "IMBP.VL_PROVISAO," & _
                                 "P.CONTA_CONTABIL," & _
                                 "OB.NO_OPERACAO," & _
                                 "P.IC_CALC_SUBALIQ," & _
                                 "NVL(OB.VL_SUB_ALIQ_1, 0) AS VL_SUB_ALIQ_1," & _
                                 "NVL (OB.VL_SUB_ALIQ_2, 0) AS VL_SUB_ALIQ_2," & _
                                 "OB.PC_BASE_CALCULO TX_BASE," & _
                                 "F.CD_ADDRESS_NUMBER," & _
                                 "F.NU_PIS_PASEP" & _
                          " FROM SOF.ITEM_MOV_BANCARIO IMB," & _
                                "SOF.ITEM_MOV_BANCARIO_PROVISAO IMBP," & _
                                "SOF.PROVISAO P," & _
                                "SOF.MOV_BANCARIO MB," & _
                                "SOF.FILIAL FIL," & _
                                "SOF.OPERACAO_BANCARIA OB," & _
                                "SOF.FRETISTA F" & _
                          " WHERE IMB.SQ_ITEM_MOV_BANCARIO = IMBP.SQ_ITEM_MOV_BANCARIO" & _
                            " AND P.CD_PROVISAO = IMBP.CD_PROVISAO" & _
                            " AND MB.SQ_MOV_BANCARIO = IMB.SQ_MOV_BANCARIO" & _
                            " AND MB.DT_MOVIMENTACAO BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & _
                                                       " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & _
                            " AND IMB.CD_FILIAL_PAGADORA = FIL.CD_FILIAL" & _
                            " AND IMB.CD_OPERACAO_BANCARIA = OB.CD_OPERACAO_BANCARIA"

                sFiltro = "Período de " & txtDataInicial.Value & " e " & txtDataFinal.Value

                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND IMB.CD_FILIAL_PAGADORA IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filiais: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & " AND IMB.CD_FILIAL_PAGADORA IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If
                If Selecao01.Lista_Quantidade > 0 Then
                    SqlText = SqlText & "   AND OB.CD_OPERACAO_BANCARIA NOT IN (" & Selecao01.Lista_ID & ")"
                End If

                SqlText = SqlText & "   AND IMB.CD_FRETISTA = F.CD_FRETISTA (+) "

                oData = DBQuery(SqlText)

                If Selecao01.Lista_Quantidade > 0 Then
                    sFiltro02 = "Operações não considereadas: " & Selecao01.Lista_Descricao
                End If

                oRelatorio.Load(Application.StartupPath & "\RPT_Prov.rpt")

                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Filtro01", sFiltro)
                oRelatorio.SetParameterValue("Filtro02", sFiltro02)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

                crvMain.ReportSource = oRelatorio
            Case RGFP_TipoRelatorio.Conciliacao
                '==>Filtros
                SqlFiltro = " and C.DT_CONCILIACAO between " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & " and " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & " "
                sFiltro = "Periodo de : " & txtDataInicial.Text & " a " & txtDataFinal.Text

                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlFiltro = SqlFiltro & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlFiltro = SqlFiltro & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If

                If Selecao01.Lista_Quantidade > 0 Then
                    SqlFiltro = SqlFiltro & " AND C.CD_CONCILIACAO_MODALIDADE IN (" & Selecao01.Lista_ID & ")"
                    sFiltro = sFiltro & " - Modalidade: " & Selecao01.Lista_Descricao
                End If

                '==>cabeçalho
                SqlText = "SELECT C.SQ_CONCILIACAO, C.CD_CONCILIACAO_MODALIDADE, "
                SqlText = SqlText & "       CM.NO_CONCILIACAO_MODALIDADE, C.DT_CONCILIACAO, C.CD_FORNECEDOR, "
                SqlText = SqlText & "       F.NO_RAZAO_SOCIAL, C.QT_CONCILIACAO, C.VL_CONCILIACAO, "
                SqlText = SqlText & "       C.DS_CONCILIACAO, F.CD_FILIAL_ORIGEM, FIL.NO_FILIAL "
                SqlText = SqlText & "  FROM SOF.CONCILIACAO C, "
                SqlText = SqlText & "       SOF.CONCILIACAO_MODALIDADE CM, "
                SqlText = SqlText & "       SOF.FILIAL FIL, "
                SqlText = SqlText & "       SOF.FORNECEDOR F "
                SqlText = SqlText & " WHERE CM.CD_CONCILIACAO_MODALIDADE = C.CD_CONCILIACAO_MODALIDADE "
                SqlText = SqlText & "   AND FIL.CD_FILIAL = F.CD_FILIAL_ORIGEM "
                SqlText = SqlText & "   AND F.CD_FORNECEDOR = C.CD_FORNECEDOR "
                oData = DBQuery(SqlText & SqlFiltro)

                '==>Movimentação
                SqlText = "SELECT CM.SQ_CONCILIACAO, CM.SQ_MOVIMENTACAO, CM.VL_APLICACAO, "
                SqlText = SqlText & "       CM.QT_APLICACAO, M.VL_NF, M.VL_NF_ICMS, M.VL_NF_FUNRURAL, M.NU_NF, "
                SqlText = SqlText & "       M.DT_MOVIMENTACAO, TM.NO_TIPO_MOVIMENTACAO "
                SqlText = SqlText & "  FROM SOF.CONCILIACAO_MOVIMENTACAO CM, "
                SqlText = SqlText & "       SOF.MOVIMENTACAO M, "
                SqlText = SqlText & "       SOF.TIPO_MOVIMENTACAO TM, "
                SqlText = SqlText & "       SOF.CONCILIACAO C, "
                SqlText = SqlText & "       SOF.FORNECEDOR F "
                SqlText = SqlText & " WHERE CM.SQ_CONCILIACAO = C.SQ_CONCILIACAO "
                SqlText = SqlText & "   AND C.CD_FORNECEDOR = F.CD_FORNECEDOR "
                SqlText = SqlText & "   AND TM.CD_TIPO_MOVIMENTACAO = M.CD_TIPO_MOVIMENTACAO "
                SqlText = SqlText & "   AND M.SQ_MOVIMENTACAO = CM.SQ_MOVIMENTACAO "
                oData_Sub1 = DBQuery(SqlText & SqlFiltro)

                '==>Pagamentos
                SqlText = "SELECT CP.SQ_CONCILIACAO, CP.SQ_PAGAMENTO, CP.VL_APLICACAO, P.DT_PAGAMENTO, "
                SqlText = SqlText & "       TP.NO_TIPO_PAGAMENTO "
                SqlText = SqlText & "  FROM SOF.CONCILIACAO_PAGAMENTO CP, "
                SqlText = SqlText & "       SOF.CONCILIACAO C, "
                SqlText = SqlText & "       SOF.PAGAMENTOS P, "
                SqlText = SqlText & "       SOF.TIPO_PAGAMENTO TP, "
                SqlText = SqlText & "       SOF.FORNECEDOR F "
                SqlText = SqlText & " WHERE C.SQ_CONCILIACAO = CP.SQ_CONCILIACAO "
                SqlText = SqlText & "   AND C.CD_FORNECEDOR = F.CD_FORNECEDOR "
                SqlText = SqlText & "   AND P.SQ_PAGAMENTO = CP.SQ_PAGAMENTO "
                SqlText = SqlText & "   AND TP.CD_TIPO_PAGAMENTO = P.CD_TIPO_PAGAMENTO "
                oData_Sub2 = DBQuery(SqlText & SqlFiltro)

                oRelatorio.Load(Application.StartupPath & "\RPT_Conciliacao.rpt")
                oRelatorio.SetDataSource(oData)
                oRelatorio_Sub1 = oRelatorio.Subreports("CRConcMov")
                oRelatorio_Sub1.SetDataSource(oData_Sub1)
                oRelatorio_Sub2 = oRelatorio.Subreports("CRConcPag")
                oRelatorio_Sub2.SetDataSource(oData_Sub2)

                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                crvMain.ReportSource = oRelatorio
            Case RGFP_TipoRelatorio.DivergenciaFrete
                SqlText = "SELECT   DECODE (f.ic_frete_carga, "
                SqlText = SqlText & "                 'S', ROUND (f.vl_unitario / m.qt_kg_nf * 60, 2), "
                SqlText = SqlText & "                 f.vl_unitario "
                SqlText = SqlText & "                ) AS vl_unitario_frete, "
                SqlText = SqlText & "         SUM (cpnm.qt_kg_fixo) qt_kg_aplicado, n.cd_contrato_paf, "
                SqlText = SqlText & "         n.sq_negociacao, n.vl_preco_frete AS vl_frete_negociacao, "
                SqlText = SqlText & "         forn.no_razao_social AS no_fornecedor, le.no_local_entrega, "
                SqlText = SqlText & "         NVL (n.vl_frete_filial_fabrica, 0) vl_frete_filial_fabrica, "
                SqlText = SqlText & "         n.dt_negociacao, f.dt_frete, m.nu_nf, fr.no_fretista, fil.cd_filial, "
                SqlText = SqlText & "         fil.no_filial, n.cd_local_entrega "
                SqlText = SqlText & "    FROM sof.frete f, "
                SqlText = SqlText & "         sof.ctr_paf_neg_movimentacao cpnm, "
                SqlText = SqlText & "         sof.contrato_paf cp, "
                SqlText = SqlText & "         sof.negociacao n, "
                SqlText = SqlText & "         sof.fornecedor forn, "
                SqlText = SqlText & "         sof.local_entrega le, "
                SqlText = SqlText & "         sof.movimentacao m, "
                SqlText = SqlText & "         sof.fretista fr, "
                SqlText = SqlText & "         sof.filial fil "
                SqlText = SqlText & "   WHERE f.dt_exclusao is null and f.sq_movimentacao = cpnm.sq_movimentacao "
                SqlText = SqlText & "     AND cp.cd_contrato_paf = n.cd_contrato_paf "
                SqlText = SqlText & "     AND n.cd_contrato_paf = cpnm.cd_contrato_paf "
                SqlText = SqlText & "     AND n.sq_negociacao = cpnm.sq_negociacao "
                SqlText = SqlText & "     AND forn.cd_fornecedor = cp.cd_fornecedor "
                SqlText = SqlText & "     AND le.cd_local_entrega = n.cd_local_entrega "
                SqlText = SqlText & "     AND f.sq_movimentacao = m.sq_movimentacao "
                SqlText = SqlText & "     AND f.cd_fretista = fr.cd_fretista "
                SqlText = SqlText & "     AND forn.cd_filial_origem = fil.cd_filial "
                SqlText = SqlText & "     AND f.vl_unitario <> "
                SqlText = SqlText & "            (  n.vl_preco_frete "
                SqlText = SqlText & "             - DECODE (n.cd_local_entrega, "
                SqlText = SqlText & "                       3, 0, "
                SqlText = SqlText & "                       NVL (n.vl_frete_filial_fabrica, 0) "
                SqlText = SqlText & "                      ) "
                SqlText = SqlText & "            ) "
                SqlText = SqlText & "     AND (   n.dt_negociacao BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Value))
                SqlText = SqlText & "          OR f.dt_frete BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Value))
                SqlText = SqlText & "         ) "

                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & "     AND forn.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & "     AND forn.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If

                SqlText = SqlText & "GROUP BY DECODE (f.ic_frete_carga, "
                SqlText = SqlText & "                 'S', ROUND (f.vl_unitario / m.qt_kg_nf * 60, 2), "
                SqlText = SqlText & "                 f.vl_unitario "
                SqlText = SqlText & "                ), "
                SqlText = SqlText & "         n.cd_contrato_paf, "
                SqlText = SqlText & "         n.sq_negociacao, "
                SqlText = SqlText & "         n.vl_preco_frete, "
                SqlText = SqlText & "         forn.no_razao_social, "
                SqlText = SqlText & "         le.no_local_entrega, "
                SqlText = SqlText & "         NVL (n.vl_frete_filial_fabrica, 0), "
                SqlText = SqlText & "         n.dt_negociacao, "
                SqlText = SqlText & "         f.dt_frete, "
                SqlText = SqlText & "         m.nu_nf, "
                SqlText = SqlText & "         fr.no_fretista, "
                SqlText = SqlText & "         fil.cd_filial, "
                SqlText = SqlText & "         fil.no_filial, "
                SqlText = SqlText & "         n.cd_local_entrega "

                sFiltro = "Periodo de : " & txtDataInicial.Text & " a " & txtDataFinal.Text

                oData = DBQuery(SqlText)

                oRelatorio.Load(Application.StartupPath & "\RPT_Frete_Divergencia.rpt")
                oRelatorio.SetDataSource(oData)

                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                crvMain.ReportSource = oRelatorio
            Case RGFP_TipoRelatorio.InterfaceLivroFiscal
                SqlText = "SELECT LF.SQ_MOVIMENTACAO, LF.DT_CRIACAO, LF.DT_INTERFACIADO, LF.NOTAFISCALNUMBER, "
                SqlText = SqlText & "       LF.NOTAFISCALSERIES, LF.COMPANYFROM, LF.IDENTIFIERSHORTITEM, "
                SqlText = SqlText & "       LF.UNITSTRANSACTIONQTY, LF.AMOUNTEXTENDEDPRICE, LF.ADDRESSNUMBERSHIPTO, "
                SqlText = SqlText & "       LF.ADDRESSNUMBER, LF.ADDNOVENDOR, LF.CODETRANSACTIONNATURE, "
                SqlText = SqlText & "       LF.SUFFIXTRANSACTIONNATURE, LF.CODEICMSIPITAXSUMMARY, "
                SqlText = SqlText & "       LF.CODEICMSTAXSTATUS, LF.AMOUNTICMSTAX, LF.AMOUNTICMSTAXABLEAMOUNT, "
                SqlText = SqlText & "       LF.CODEICMSREPORTINGCOLUMN, LF.PRINTMESSAGEFISCALPURPOS, LF.ISSUEDATE, "
                SqlText = SqlText & "       LF.IC_ENVIADO, FIL.NO_FILIAL, F.NO_RAZAO_SOCIAL, AB.CD_CNPJ "
                SqlText = SqlText & "  FROM SOF.INTERFACE_LIVRO_FISCAL LF, "
                SqlText = SqlText & "       SOF.MOVIMENTACAO M, "
                SqlText = SqlText & "       SOF.FORNECEDOR F, "
                SqlText = SqlText & "       SOF.FILIAL FIL, "
                SqlText = SqlText & "       RDS.ADDRESS_BOOK AB "
                SqlText = SqlText & " WHERE LF.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO "
                SqlText = SqlText & "   AND M.CD_FORNECEDOR = F.CD_FORNECEDOR "
                SqlText = SqlText & "   AND M.CD_FILIAL_MOVIMENTACAO = FIL.CD_FILIAL "
                SqlText = SqlText & "   AND LF.ADDNOVENDOR = AB.CD_ADDRESS_NUMBER(+) "

                '==>Filtros
                SqlText = SqlText & " and LF.DT_CRIACAO between " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & " and " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & " "
                sFiltro = "Periodo de : " & txtDataInicial.Text & " a " & txtDataFinal.Text

                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If

                oData = DBQuery(SqlText)

                oRelatorio.Load(Application.StartupPath & "\RPT_Interface_Livro_Fiscal.rpt")
                oRelatorio.SetDataSource(oData)

                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                crvMain.ReportSource = oRelatorio
            Case RGFP_TipoRelatorio.QuebraSobra
                SqlText = "SELECT fil.cd_filial, fil.no_filial, f.cd_fornecedor, f.no_razao_social, "
                SqlText = SqlText & "       m.cd_filial_movimentacao, m.dt_movimentacao, m.nu_nf, m.vl_nf, "
                SqlText = SqlText & "       NVL (m.qt_kg_nf, 0) AS qt_kg_nf, m.qt_kg_liquido_nf, mq.qt_umidade, "
                SqlText = SqlText & "       tm.no_tipo_movimentacao, tp.no_tipo_pessoa "
                SqlText = SqlText & "  FROM sof.movimentacao m, "
                SqlText = SqlText & "       sof.fornecedor f, "
                SqlText = SqlText & "       sof.tipo_movimentacao tm, "
                SqlText = SqlText & "       sof.filial fil, "
                SqlText = SqlText & "       sof.movimentacao_qualidade mq, "
                SqlText = SqlText & "       sof.tipo_pessoa tp "
                SqlText = SqlText & " WHERE m.cd_fornecedor = f.cd_fornecedor "
                SqlText = SqlText & "   AND m.cd_tipo_movimentacao = tm.cd_tipo_movimentacao "
                SqlText = SqlText & "   AND f.cd_filial_origem = fil.cd_filial "
                SqlText = SqlText & "   AND f.cd_tipo_pessoa = tp.cd_tipo_pessoa "
                SqlText = SqlText & "   AND m.sq_movimentacao = mq.sq_movimentacao(+) "
                SqlText = SqlText & "   AND ROUND ((NVL (m.qt_kg_nf, 0) - NVL (m.qt_kg_liquido_nf, 0)), 0) <> "
                SqlText = SqlText & "                                                                  ROUND (0, 0) "
                SqlText = SqlText & "   AND m.qt_kg_nf <> 0 "

                '==>Filtros
                SqlText = SqlText & " and m.dt_movimentacao between " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & " and " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & " "
                sFiltro = "Periodo de : " & txtDataInicial.Text & " a " & txtDataFinal.Text

                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If

                oData = DBQuery(SqlText)

                oRelatorio.Load(Application.StartupPath & "\RPT_Apuracao_Quebra_Sobra.rpt")
                oRelatorio.SetDataSource(oData)

                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                crvMain.ReportSource = oRelatorio
            Case RGFP_TipoRelatorio.ContratosFixosCancelados

                SqlText = "SELECT cf.dt_contrato_fixo AS dt_contrato, cf.cd_contrato_paf AS cd_contrato, "
                SqlText = SqlText & "       f.no_razao_social, tp.no_tipo_pessoa, cf.qt_kgs, cf.vl_unitario, "
                SqlText = SqlText & "       cf.cd_tipo_unidade, "
                SqlText = SqlText & "       (cf.vl_total + DECODE (cf.ic_inclui_icms_pag, 'S', cf.vl_icms, 0) "
                SqlText = SqlText & "       ) vl_total, "
                SqlText = SqlText & "       cf.ic_status, le.no_local_entrega, cf.dt_vencimento, cf.dt_pagamento, "
                SqlText = SqlText & "       f.cd_filial_origem, fil.no_filial, "
                SqlText = SqlText & "       (  cf.vl_adendo "
                SqlText = SqlText & "        + DECODE (cf.ic_inclui_icms_pag, 'S', cf.vl_adendo_icms, 0) "
                SqlText = SqlText & "       ) vl_adendo_contrato, "
                SqlText = SqlText & "       cf.sq_negociacao, cf.sq_contrato_fixo, cfc.qt_cancelado, "
                SqlText = SqlText & "       cfc.dt_cancelamento, cfc.ds_motivo "
                SqlText = SqlText & "  FROM sof.contrato_fixo cf, "
                SqlText = SqlText & "       sof.negociacao n, "
                SqlText = SqlText & "       sof.contrato_paf cp, "
                SqlText = SqlText & "       sof.contrato_fixo_cancelado cfc, "
                SqlText = SqlText & "       sof.fornecedor f, "
                SqlText = SqlText & "       sof.tipo_pessoa tp, "
                SqlText = SqlText & "       sof.local_entrega le, "
                SqlText = SqlText & "       sof.filial fil "
                SqlText = SqlText & " WHERE cp.cd_contrato_paf = n.cd_contrato_paf "
                SqlText = SqlText & "   AND n.cd_contrato_paf = cf.cd_contrato_paf "
                SqlText = SqlText & "   AND n.sq_negociacao = cf.sq_negociacao "
                SqlText = SqlText & "   AND cp.cd_fornecedor = f.cd_fornecedor "
                SqlText = SqlText & "   AND f.cd_tipo_pessoa = tp.cd_tipo_pessoa "
                SqlText = SqlText & "   AND n.cd_local_entrega = le.cd_local_entrega "
                SqlText = SqlText & "   AND f.cd_filial_origem = fil.cd_filial "
                SqlText = SqlText & "   AND cf.cd_contrato_paf = cfc.cd_contrato_paf "
                SqlText = SqlText & "   AND cf.sq_negociacao = cfc.sq_negociacao "
                SqlText = SqlText & "   AND cf.sq_contrato_fixo = cfc.sq_contrato_fixo "

                sFiltro = "Periodo de : " & txtDataInicial.Text & " a " & txtDataFinal.Text
                SqlText = SqlText & " and cfc.dt_cancelamento between " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & " and " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & " "

                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & "     AND f.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & "     AND f.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If

                oData = DBQuery(SqlText)

                oRelatorio.Load(Application.StartupPath & "\RPT_Contrato_Fixo_Cancelado.rpt")
                oRelatorio.SetDataSource(oData)

                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                crvMain.ReportSource = oRelatorio
            Case RGFP_TipoRelatorio.NotaFiscalComplementar
                SqlText = "SELECT forn.cd_fornecedor, forn.no_razao_social, cf.cd_contrato_paf AS cd_contrato, "
                SqlText = SqlText & "       cf.dt_contrato_fixo dt_contrato, (cf.qt_kgs - cf.qt_cancelado) qt_kgs, "
                SqlText = SqlText & "       cf.vl_unitario, cf.cd_tipo_unidade, "
                SqlText = SqlText & "       (cf.vl_total + cf.vl_icms) vl_total, "
                SqlText = SqlText & "       ROUND (cf.vl_nf_fixo - cf.vl_nf_inss_fixo, 2) AS vl_nf_si, "
                SqlText = SqlText & "       ROUND (cf.vl_pag_fixo + nvl(ama.vl_aplicado,0), 2) AS vl_pg_si, cf.pc_aliq_icms, fun.vl_taxa, "
                SqlText = SqlText & "       forn.cd_filial_origem, fil.no_filial || decode(cf.pc_aliq_icms,0,'',' - Aliq. ICMS' || cf.pc_aliq_icms || ' %') no_filial , "
                SqlText = SqlText & "       (cf.vl_adendo + cf.vl_adendo_icms) vl_adendo_contrato, "
                SqlText = SqlText & "       cf.sq_negociacao, cf.sq_contrato_fixo, cf.qt_kgs AS qt_kgs_contratado "
                SqlText = SqlText & "  FROM sof.funrural fun, "
                SqlText = SqlText & "       sof.filial fil, "
                SqlText = SqlText & "       sof.fornecedor forn, "
                SqlText = SqlText & "       sof.contrato_paf cp, "
                SqlText = SqlText & "       sof.contrato_fixo cf, "


                SqlText = SqlText & " (SELECT   cpncfm.cd_contrato_paf, cpncfm.sq_negociacao,"
                SqlText = SqlText & "                 cpncfm.sq_contrato_fixo,"
                SqlText = SqlText & "                 SUM (ROUND ((  (pa.vl_aplicacao * cpncfm.vl_fixo)"
                SqlText = SqlText & "                              / DECODE (m.vl_nf, 0, 1, m.vl_nf)"
                SqlText = SqlText & "                             ),"
                SqlText = SqlText & "                             2"
                SqlText = SqlText & "                            )"
                SqlText = SqlText & "                     ) vl_aplicado"
                SqlText = SqlText & "            FROM sof.movimentacao m,"
                SqlText = SqlText & "                 (SELECT   SUM (vl_aplicacao) AS vl_aplicacao,"
                SqlText = SqlText & "                           sq_movimentacao"
                SqlText = SqlText & "                      FROM sof.pag_amarracao_icms"
                SqlText = SqlText & "                  GROUP BY sq_movimentacao) pa,"
                SqlText = SqlText & "                 (SELECT   cp.cd_contrato_paf, cp.sq_negociacao,"
                SqlText = SqlText & "                           cp.sq_contrato_fixo, cp.sq_movimentacao,"
                SqlText = SqlText & "                           SUM (cp.vl_fixo) AS vl_fixo"
                SqlText = SqlText & "                      FROM sof.ctr_paf_neg_ctr_fix_mov cp"
                SqlText = SqlText & "                  GROUP BY cp.cd_contrato_paf,"
                SqlText = SqlText & "                           cp.sq_negociacao,"
                SqlText = SqlText & "                           cp.sq_contrato_fixo,"
                SqlText = SqlText & "                           cp.sq_movimentacao) cpncfm"
                SqlText = SqlText & "           WHERE pa.sq_movimentacao = m.sq_movimentacao"
                SqlText = SqlText & "             AND m.sq_movimentacao = cpncfm.sq_movimentacao"
                SqlText = SqlText & "        GROUP BY cpncfm.cd_contrato_paf,"
                SqlText = SqlText & "                 cpncfm.sq_negociacao,"
                SqlText = SqlText & "                 cpncfm.sq_contrato_fixo) AMA "

                SqlText = SqlText & " WHERE cp.cd_contrato_paf = cf.cd_contrato_paf "
                SqlText = SqlText & "   AND cp.cd_fornecedor = forn.cd_fornecedor "
                SqlText = SqlText & "   AND forn.cd_funrural = fun.cd_funrural "
                SqlText = SqlText & "   AND forn.cd_filial_origem = fil.cd_filial "
                SqlText = SqlText & "   and AMA.cd_contrato_paf (+)= cf.cd_contrato_paf "
                SqlText = SqlText & "   and AMA.sq_negociacao (+)=cf.sq_negociacao  and AMA.sq_contrato_fixo (+)= cf.sq_contrato_fixo "
                SqlText = SqlText & "   AND ROUND (cf.qt_kgs - cf.qt_cancelado, 0) = ROUND (cf.qt_kg_fixo, 0) "
                SqlText = SqlText & "   AND ROUND (cf.vl_pag_fixo, 2) <> 0 "
                SqlText = SqlText & "   AND CF.IC_STATUS='A' "

                If chkOpcao.Checked = False Then
                    SqlText = SqlText & "   AND ROUND (cf.vl_pag_fixo+ nvl(ama.vl_aplicado,0), 2) <> "
                    SqlText = SqlText & "                                 ROUND (cf.vl_nf_fixo - cf.vl_nf_inss_fixo, 2) "

                Else
                    SqlText = SqlText & "   AND ROUND ((cf.vl_adendo + cf.vl_adendo_icms + cf.vl_total + cf.vl_icms), 2) <> "
                    SqlText = SqlText & "                                 ROUND (cf.vl_nf_fixo, 2) "
                End If
                SqlText = SqlText & "   AND cf.qt_kgs <> cf.qt_cancelado "

                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & "     AND forn.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & "     AND forn.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If

                oData = DBQuery(SqlText)

                oRelatorio.Load(Application.StartupPath & "\RPT_Nota_Fiscal_Complementar.rpt")

                Dim vlMin As Double
                vlMin = DBQuery_ValorUnico("select p.vl_minimo_nf_complementar from sof.parametro p", 0)
                oRelatorio.RecordSelectionFormula = "round({@VL_NFC},2)>" & vlMin & " or round({@VL_NFC},2)<(-1 *" & vlMin & ")"

                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

                crvMain.ReportSource = oRelatorio

            Case RGFP_TipoRelatorio.SaldoSacariaFornecedor
                SqlText = "SELECT   f.no_razao_social, ts.no_tipo_sacaria, fil.no_filial, "
                SqlText = SqlText & "         SUM (DECODE (ic_entrada_saida, 'E', sf.qt_sacos, -1 * sf.qt_sacos) "
                SqlText = SqlText & "             ) qt_volume, "
                SqlText = SqlText & "         f.cd_fornecedor, fil.cd_filial, ts.cd_tipo_sacaria, "
                SqlText = SqlText & "         f.ic_sacaria_acordada "
                SqlText = SqlText & "    FROM sof.sacaria_fornecedor sf, "
                SqlText = SqlText & "         sof.tipo_sacaria ts, "
                SqlText = SqlText & "         sof.fornecedor f, "
                SqlText = SqlText & "         sof.filial fil "
                SqlText = SqlText & "   WHERE sf.cd_tipo_sacaria = ts.cd_tipo_sacaria "
                SqlText = SqlText & "     AND sf.cd_fornecedor = f.cd_fornecedor "
                SqlText = SqlText & "     AND f.cd_filial_origem = fil.cd_filial "
                SqlText = SqlText & "     AND ts.ic_contabiliza_fornecedor = 'S' "

                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & "     AND f.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & "     AND f.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If

                SqlText = SqlText & "GROUP BY f.no_razao_social, "
                SqlText = SqlText & "         ts.no_tipo_sacaria, "
                SqlText = SqlText & "         fil.no_filial, "
                SqlText = SqlText & "         f.cd_fornecedor, "
                SqlText = SqlText & "         fil.cd_filial, "
                SqlText = SqlText & "         ts.cd_tipo_sacaria, "
                SqlText = SqlText & "         f.ic_sacaria_acordada "
                SqlText = SqlText & "  HAVING SUM (DECODE (ic_entrada_saida, 'E', sf.qt_sacos, -1 * sf.qt_sacos)) <> 0 "

                oData = DBQuery(SqlText)

                oRelatorio.Load(Application.StartupPath & "\RPT_Saldo_Sacaria_Fornecedor.rpt")


                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                oRelatorio.SetParameterValue("Titulo", "Relação de Saldo de Sacarias por Fornecedor")


                crvMain.ReportSource = oRelatorio
            Case RGFP_TipoRelatorio.SaldoSacariaRepassador
                SqlText = "SELECT   rep.no_razao_social, ts.no_tipo_sacaria, fil.no_filial, "
                SqlText = SqlText & "         SUM (DECODE (sf.ic_entrada_saida, "
                SqlText = SqlText & "                      'E', sf.qt_sacos, "
                SqlText = SqlText & "                      - (1 * sf.qt_sacos) "
                SqlText = SqlText & "                     ) "
                SqlText = SqlText & "             ) AS qt_volume, "
                SqlText = SqlText & "         rep.cd_fornecedor, fil.cd_filial, ts.cd_tipo_sacaria, "
                SqlText = SqlText & "         f.ic_sacaria_acordada "
                SqlText = SqlText & "    FROM sof.sacaria_fornecedor sf, "
                SqlText = SqlText & "         sof.tipo_sacaria ts, "
                SqlText = SqlText & "         sof.fornecedor f, "
                SqlText = SqlText & "         sof.fornecedor rep, "
                SqlText = SqlText & "         sof.filial fil "
                SqlText = SqlText & "   WHERE sf.cd_tipo_sacaria = ts.cd_tipo_sacaria "
                SqlText = SqlText & "     AND sf.cd_fornecedor = f.cd_fornecedor "
                SqlText = SqlText & "     AND NVL (f.cd_repassador, f.cd_fornecedor) = rep.cd_fornecedor "
                SqlText = SqlText & "     AND rep.cd_filial_origem = fil.cd_filial "
                SqlText = SqlText & "     AND rep.cd_tipo_pessoa IN (3, 5) "
                SqlText = SqlText & "     AND ts.ic_contabiliza_fornecedor = 'S' "

                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & "     AND f.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & "     AND f.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If

                SqlText = SqlText & "GROUP BY rep.no_razao_social, "
                SqlText = SqlText & "         ts.no_tipo_sacaria, "
                SqlText = SqlText & "         fil.no_filial, "
                SqlText = SqlText & "         rep.cd_fornecedor, "
                SqlText = SqlText & "         fil.cd_filial, "
                SqlText = SqlText & "         ts.cd_tipo_sacaria, "
                SqlText = SqlText & "         f.ic_sacaria_acordada "
                SqlText = SqlText & "  HAVING (SUM (DECODE (sf.ic_entrada_saida, "
                SqlText = SqlText & "                       'E', sf.qt_sacos, "
                SqlText = SqlText & "                       - (1 * sf.qt_sacos) "
                SqlText = SqlText & "                      ) "
                SqlText = SqlText & "              ) <> 0 "
                SqlText = SqlText & "         ) "

                oData = DBQuery(SqlText)

                oRelatorio.Load(Application.StartupPath & "\RPT_Saldo_Sacaria_Fornecedor.rpt")


                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                oRelatorio.SetParameterValue("Titulo", "Relação de Saldo de Sacarias por Repassador")


                crvMain.ReportSource = oRelatorio
            Case RGFP_TipoRelatorio.MovimentacaoPorMunicipio
                sFiltro = "Periodo de : " & txtDataInicial.Text & " a " & txtDataFinal.Text

                'solicitado por aroaldo para que PJ que for da mesma UF ter o municipio da filial
                'não deve vim PJ de outros estados e PF da bahia deve ser normal
                SqlText = "SELECT fil.cd_filial, fil.no_filial, forn.no_razao_social, rec.cd_tipo_nf, "
                SqlText = SqlText & "       DECODE (forn.ic_fisica_juridica || municforn.cd_uf, "
                SqlText = SqlText & "               'J' || municfil.cd_uf, municfil.no_cidade, "
                SqlText = SqlText & "               DECODE (uf.ic_obrigacao_acessoria || tnf.ic_municipio_fiscal, "
                SqlText = SqlText & "                       'SS', municfil.no_cidade, "
                SqlText = SqlText & "                       munic.no_cidade "
                SqlText = SqlText & "                      ) "
                SqlText = SqlText & "              ) AS no_cidade, "
                SqlText = SqlText & "       rec.nu_nf, rec.qt_kg_nf, rec.qt_kg_liquido_nf, rec.vl_nf, "
                SqlText = SqlText & "       rec.vl_nf_icms, rec.vl_nf_funrural, rec.dt_movimentacao, "
                SqlText = SqlText & "       DECODE (forn.ic_fisica_juridica || municforn.cd_uf, "
                SqlText = SqlText & "               'J' || municfil.cd_uf, municfil.cd_municipio, "
                SqlText = SqlText & "               DECODE (uf.ic_obrigacao_acessoria || tnf.ic_municipio_fiscal, "
                SqlText = SqlText & "                       'SS', municfil.cd_municipio, "
                SqlText = SqlText & "                       munic.cd_municipio "
                SqlText = SqlText & "                      ) "
                SqlText = SqlText & "              ) AS cd_municipio, "
                SqlText = SqlText & "       forn.ic_fisica_juridica "
                SqlText = SqlText & "  FROM sof.filial fil, "
                SqlText = SqlText & "       sof.tipo_movimentacao tpmov, "
                SqlText = SqlText & "       sof.municipio munic, "
                SqlText = SqlText & "       sof.fornecedor forn, "
                SqlText = SqlText & "       sof.movimentacao rec, "
                SqlText = SqlText & "       sof.uf, "
                SqlText = SqlText & "       sof.tipo_nf tnf, "
                SqlText = SqlText & "       sof.municipio municfil, "
                SqlText = SqlText & "       sof.municipio municforn, "
                SqlText = SqlText & "       sof.parametro p, "
                SqlText = SqlText & "       sof.filial filpar, "
                SqlText = SqlText & "       sof.municipio municpar "
                SqlText = SqlText & " WHERE fil.cd_filial = rec.cd_filial_movimentacao "
                SqlText = SqlText & "   AND tpmov.cd_tipo_movimentacao = rec.cd_tipo_movimentacao "
                SqlText = SqlText & "   AND munic.cd_municipio = rec.cd_municipio_origem "
                SqlText = SqlText & "   AND munic.cd_uf = uf.cd_uf "
                SqlText = SqlText & "   AND rec.cd_tipo_nf = tnf.cd_tipo_nf "
                SqlText = SqlText & "   AND municfil.cd_municipio = fil.cd_municipio "
                SqlText = SqlText & "   AND municforn.cd_municipio = forn.cd_municipio "
                SqlText = SqlText & "   AND p.cd_filial_mae = filpar.cd_filial "
                SqlText = SqlText & "   AND municpar.cd_municipio = filpar.cd_municipio "
                SqlText = SqlText & "   AND forn.cd_fornecedor(+) = rec.cd_fornecedor "
                SqlText = SqlText & "   AND NVL (tpmov.ic_importacao, 'N') = 'N' "
                SqlText = SqlText & "   AND rec.cd_tipo_nf IS NOT NULL "
                SqlText = SqlText & "   AND NVL (rec.vl_nf_icms, 0) = 0 "
                SqlText = SqlText & "   AND rec.nu_nf NOT IN ('ACERTO', 'ACTPER', 'ACTFUN') "
                SqlText = SqlText & "   AND rec.cd_tipo_movimentacao <> " & DBQuery_ValorUnico(" SELECT CD_TP_MOV_DESAGIO FROM SOF.PARAMETRO") & " "
                SqlText = SqlText & "   AND tpmov.ic_fiscal = 'S' "
                SqlText = SqlText & "   AND rec.dt_movimentacao BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & ""
                SqlText = SqlText & "   AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & ""
                SqlText = SqlText & "   AND NOT (forn.ic_fisica_juridica = 'J' AND municforn.cd_uf <> 'BA') "

                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & "     AND REC.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & "     AND REC.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If

                oData = DBQuery(SqlText)

                oRelatorio.Load(Application.StartupPath & "\RPT_Movimentacao_Municipio.rpt")
                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

                crvMain.ReportSource = oRelatorio
            Case RGFP_TipoRelatorio.MovimentacaoEmNegociacao
                oRelatorio = Gera_Relatorio_MovimentacaoAbertoNegociacao(SelecaoFilial.Lista_ID, Selecao01.Lista_ID, txtDataInicial.Text, txtDataFinal.Text)

                crvMain.ReportSource = oRelatorio
        End Select

        AVI_Fechar(Me)
    End Sub

    Private Sub frmRelatorioGeral_FilialPeriodo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmRelatorioGeral_FilialPeriodo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chkOpcao.Visible = False
        Selecao01.Visible = False

        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        Select Case oTipoRelatorio
            Case RGFP_TipoRelatorio.ProvisaoImpostos
                Me.Text = "Provisão de Impostos"

                lblSelecao01.Text = "Operações Bancárias não Consideradas"

                With Selecao01
                    .BancoDados_Tabela = "SOF.OPERACAO_BANCARIA"
                    .BancoDados_Campo_Codigo = "CD_OPERACAO_BANCARIA"
                    .BancoDados_Campo_Descricao = "NO_OPERACAO"
                    .BancoDados_Carregar()
                    .Visible = True
                End With
            Case RGFP_TipoRelatorio.Conciliacao
                Me.Text = "Relatório de Conciliação"

                lblSelecao01.Text = "Modalidade"

                With Selecao01
                    .BancoDados_Tabela = "SOF.CONCILIACAO_MODALIDADE"
                    .BancoDados_Campo_Codigo = "CD_CONCILIACAO_MODALIDADE"
                    .BancoDados_Campo_Descricao = "NO_CONCILIACAO_MODALIDADE"
                    .BancoDados_Carregar()
                    .Visible = True
                End With
            Case RGFP_TipoRelatorio.DivergenciaFrete
                Me.Text = "Relatório de divergência entre o frete pago e o valor informado na Negociação"
            Case RGFP_TipoRelatorio.InterfaceLivroFiscal
                Me.Text = "Relatório Interface Livro Fiscal"
            Case RGFP_TipoRelatorio.QuebraSobra
                Me.Text = "Relatório Apuração Quebra e Sobra"
            Case RGFP_TipoRelatorio.ContratosFixosCancelados
                Me.Text = "Relatório Contratos Cancelados por Data"
            Case RGFP_TipoRelatorio.MovimentacaoPorMunicipio
                Me.Text = "Relatório Movimentação de Cacau Por Municipio"
            Case RGFP_TipoRelatorio.NotaFiscalComplementar
                Me.Text = "Relatório Nota Fiscal Complementar"

                chkOpcao.Text = "Mostrar complemento para bônus não pagos"
                chkOpcao.Visible = True
                chkOpcao.Left = Selecao01.Left

                grpPeriodo.Visible = False
            Case RGFP_TipoRelatorio.SaldoSacariaFornecedor
                Me.Text = "Relatório Saldo de Sacaria por Fornecedor"
                grpPeriodo.Visible = False
            Case RGFP_TipoRelatorio.SaldoSacariaRepassador
                Me.Text = "Relatório Saldo de Sacaria por Repassador"
                grpPeriodo.Visible = False
            Case RGFP_TipoRelatorio.MovimentacaoEmNegociacao
                Me.Text = "Relatório Movimentações em Aberto nas Negociações"
                grpPeriodo.Visible = True

                lblSelecao01.Text = "Tipo de Negociação"

                With Selecao01
                    .BancoDados_Tabela = "SOF.TIPO_NEGOCIACAO"
                    .BancoDados_Campo_Codigo = "CD_TIPO_NEGOCIACAO"
                    .BancoDados_Campo_Descricao = "NO_TIPO_NEGOCIACAO"
                    .BancoDados_Carregar()
                    .Visible = True
                End With
            Case RGFP_TipoRelatorio.AcertoRD
                Me.Text = "Relatório Acertos de R.D."
        End Select

        lblSelecao01.Visible = Selecao01.Visible
        Me.WindowState = FormWindowState.Maximized
        crvMain.Top = IIf(Selecao01.Visible Or chkOpcao.Visible, 89, 63)
    End Sub

    Private Sub frmRelatorioGeral_FilialPeriodo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

End Class