Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_RecuperacaoCredito
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_RecuperacaoCredito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_RecuperacaoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        SelecaoModalidade.BancoDados_Tabela = "SOF.CONFISSAO_DIVIDA_MODALIDADE"
        SelecaoModalidade.BancoDados_Campo_Codigo = "CD_CONFISSAO_DIVIDA_MODALIDADE"
        SelecaoModalidade.BancoDados_Campo_Descricao = "NO_CONFISSAO_DIVIDA_MODALIDADE"
        SelecaoModalidade.BancoDados_Carregar()

        optTipo_ValueChanged(Nothing, Nothing)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_RecuperacaoCredito_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        If optTipo.Value = "S" Then
            chkVencidas.Enabled = False
        Else
            chkVencidas.Enabled = True
            chkVencidas.Checked = False
        End If
    End Sub


    Private Sub Imprimir()
        Dim oRelatorio_Sub1 As New ReportDocument
        Dim oData As DataTable
        Dim oData_Sub1 As DataTable = Nothing
        Dim SqlText As String = ""
        Dim sFiltro As String = ""


        AVI_Carregar(Me)

        Select Case optTipo.Value
            Case "S"
                SqlText = "SELECT   CD.SQ_CONFISSAO_DIVIDA, CD.DT_CONFISSAO_DIVIDA, CD.CD_FORNECEDOR, "
                SqlText = SqlText & "         F.NO_RAZAO_SOCIAL, CD.VL_ORIGINAL, CD.QT_ORIGINAL, CD.VL_NEGOCIADO, "
                SqlText = SqlText & "         CD.CD_FILIAL_ORIGEM, FIL.NO_FILIAL, "
                SqlText = SqlText & "         decode(round(SUM (DECODE (CDP.IC_SITUACAO, "
                SqlText = SqlText & "                      'A', DECODE (CD.IC_COBRA_JUROS, "
                SqlText = SqlText & "                                   'S', CDP.VL_PARCELA "
                SqlText = SqlText & "                                    * (  1 "
                SqlText = SqlText & "                                       + (  (SYSDATE - CD.DT_COBRA_JUROS) "
                SqlText = SqlText & "                                          * (CD.PC_JUROS_AO_MES / 30) "
                SqlText = SqlText & "                                          / 100 "
                SqlText = SqlText & "                                         ) "
                SqlText = SqlText & "                                      ), "
                SqlText = SqlText & "                                   CDP.VL_PARCELA "
                SqlText = SqlText & "                                  ), "
                SqlText = SqlText & "                      0 "
                SqlText = SqlText & "                     ) "
                SqlText = SqlText & "             ),2), 0, CD.VL_ORIGINAL,"
                SqlText = SqlText & "         round(SUM (DECODE (CDP.IC_SITUACAO, "
                SqlText = SqlText & "                      'A', DECODE (CD.IC_COBRA_JUROS, "
                SqlText = SqlText & "                                   'S', CDP.VL_PARCELA "
                SqlText = SqlText & "                                    * (  1 "
                SqlText = SqlText & "                                       + (  (SYSDATE - CD.DT_COBRA_JUROS) "
                SqlText = SqlText & "                                          * (CD.PC_JUROS_AO_MES / 30) "
                SqlText = SqlText & "                                          / 100 "
                SqlText = SqlText & "                                         ) "
                SqlText = SqlText & "                                      ), "
                SqlText = SqlText & "                                   CDP.VL_PARCELA "
                SqlText = SqlText & "                                  ), "
                SqlText = SqlText & "                      0 "
                SqlText = SqlText & "                     ) "
                SqlText = SqlText & "             ),2)) VL_PARCELA_AB, "
                SqlText = SqlText & "         SUM (NVL (CDA.VL_ATIVO, 0)) VL_PARCELA_PAG, "
                SqlText = SqlText & "         SUM (DECODE (CDP.IC_SITUACAO, 'A', 1, 0)) QT_PARCELA_AB, "
                SqlText = SqlText & "         SUM (DECODE (CDP.IC_SITUACAO, 'A', 0, 1)) QT_PARCELA_FC, "
                SqlText = SqlText & "         CDM.NO_CONFISSAO_DIVIDA_MODALIDADE "
                SqlText = SqlText & "    FROM SOF.CONFISSAO_DIVIDA CD, "
                SqlText = SqlText & "         SOF.CONFISSAO_DIVIDA_PARCELA CDP, "
                SqlText = SqlText & "         SOF.CONFISSAO_DIVIDA_ATIVO CDA, "
                SqlText = SqlText & "         SOF.FORNECEDOR F, "
                SqlText = SqlText & "         SOF.FILIAL FIL, "
                SqlText = SqlText & "         SOF.CONFISSAO_DIVIDA_MODALIDADE CDM "
                SqlText = SqlText & "   WHERE F.CD_FORNECEDOR = CD.CD_FORNECEDOR "
                SqlText = SqlText & "     AND FIL.CD_FILIAL = CD.CD_FILIAL_ORIGEM "
                SqlText = SqlText & "     AND CD.CD_CONFISSAO_DIVIDA_MODALIDADE = "
                SqlText = SqlText & "                                            CDM.CD_CONFISSAO_DIVIDA_MODALIDADE "
                SqlText = SqlText & "     AND CD.SQ_CONFISSAO_DIVIDA = CDP.SQ_CONFISSAO_DIVIDA(+) "
                SqlText = SqlText & "     AND CDP.SQ_CONFISSAO_DIVIDA = CDA.SQ_CONFISSAO_DIVIDA(+) "
                SqlText = SqlText & "     AND CDP.NU_PARCELA = CDA.NU_PARCELA(+) "
                SqlText = SqlText & "     AND CD.IC_STATUS = 'A' "

                oRelatorio.Load(Application.StartupPath & "\RPT_RecCredito_Sintetico.rpt")
            Case "A"
                SqlText = "SELECT CD.SQ_CONFISSAO_DIVIDA, CD.DT_CONFISSAO_DIVIDA, CD.CD_FORNECEDOR, "
                SqlText = SqlText & "       F.NO_RAZAO_SOCIAL, CD.VL_ORIGINAL, CD.QT_ORIGINAL, CD.VL_NEGOCIADO, "
                SqlText = SqlText & "       CD.CD_FILIAL_ORIGEM, FIL.NO_FILIAL, CDP.NU_PARCELA, CDP.DT_VENCIMENTO, "
                SqlText = SqlText & "       CDP.IC_CACAU, CDP.IC_MOEDA, CDP.IC_OUTROS, CDP.DS_OUTROS, "
                SqlText = SqlText & "       round(DECODE (CDP.IC_SITUACAO, "
                SqlText = SqlText & "               'A', DECODE (CD.IC_COBRA_JUROS, "
                SqlText = SqlText & "                            'S', CDP.VL_PARCELA "
                SqlText = SqlText & "                             * (  1 "
                SqlText = SqlText & "                                + (  (SYSDATE - CD.DT_COBRA_JUROS) "
                SqlText = SqlText & "                                   * (CD.PC_JUROS_AO_MES / 30) "
                SqlText = SqlText & "                                   / 100 "
                SqlText = SqlText & "                                  ) "
                SqlText = SqlText & "                               ), "
                SqlText = SqlText & "                            CDP.VL_PARCELA "
                SqlText = SqlText & "                           ), "
                SqlText = SqlText & "               0 "
                SqlText = SqlText & "              ),2) VL_PARCELA, "
                SqlText = SqlText & "       CDP.QT_ITEM_PARCELA, CDP.IC_SITUACAO, CDA.DT_PAGAMENTO, "
                SqlText = SqlText & "       CDA.IC_CACAU IC_CACAU_PAG, CDA.IC_MOEDA IC_MOEDA_PAG, "
                SqlText = SqlText & "       CDA.IC_OUTROS IC_OUTROS_PAG, CDA.DS_OUTROS DS_OUTROS_PAG, CDA.VL_ATIVO, "
                SqlText = SqlText & "       CDA.QT_ITEM_ATIVO, "
                SqlText = SqlText & "          CDM.NO_CONFISSAO_DIVIDA_MODALIDADE "
                SqlText = SqlText & "       || DECODE (CD.IC_COBRA_JUROS, 'S', '-JUROS', '') "
                SqlText = SqlText & "                                            AS NO_CONFISSAO_DIVIDA_MODALIDADE "
                SqlText = SqlText & "  FROM SOF.CONFISSAO_DIVIDA CD, "
                SqlText = SqlText & "       SOF.CONFISSAO_DIVIDA_PARCELA CDP, "
                SqlText = SqlText & "       SOF.CONFISSAO_DIVIDA_ATIVO CDA, "
                SqlText = SqlText & "       SOF.FORNECEDOR F, "
                SqlText = SqlText & "       SOF.FILIAL FIL, "
                SqlText = SqlText & "       SOF.CONFISSAO_DIVIDA_MODALIDADE CDM "
                SqlText = SqlText & " WHERE F.CD_FORNECEDOR = CD.CD_FORNECEDOR "
                SqlText = SqlText & "   AND FIL.CD_FILIAL = CD.CD_FILIAL_ORIGEM "
                SqlText = SqlText & "   AND CD.SQ_CONFISSAO_DIVIDA = CDP.SQ_CONFISSAO_DIVIDA(+) "
                SqlText = SqlText & "   AND CDP.SQ_CONFISSAO_DIVIDA = CDA.SQ_CONFISSAO_DIVIDA(+) "
                SqlText = SqlText & "   AND CDP.NU_PARCELA = CDA.NU_PARCELA(+) "
                SqlText = SqlText & "   AND CD.CD_CONFISSAO_DIVIDA_MODALIDADE = CDM.CD_CONFISSAO_DIVIDA_MODALIDADE "
                SqlText = SqlText & "   AND CD.IC_STATUS = 'A' "

                oRelatorio.Load(Application.StartupPath & "\RPT_RecCredito_Analitico.rpt")

        End Select

        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & "     AND cd.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
            sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
        Else
            SqlText = SqlText & "     AND cd.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        If SelecaoModalidade.Lista_Quantidade > 0 Then
            SqlText = SqlText & "     AND cd.CD_CONFISSAO_DIVIDA_MODALIDADE IN (" & SelecaoModalidade.Lista_ID & ")"
            sFiltro = sFiltro & " - Modalidade: " & SelecaoModalidade.Lista_Descricao
        End If

        If chkVencidas.Checked = True Then
            SqlText = SqlText & " and cdp.dt_vencimento<sysdate and cdp.IC_SITUACAO ='A' "
            sFiltro = sFiltro & " - Apenas Parcelas Vencidas "
        End If

        If optTipo.Value = "S" Then
            SqlText = SqlText & " GROUP BY CD.SQ_CONFISSAO_DIVIDA, "
            SqlText = SqlText & "         CD.DT_CONFISSAO_DIVIDA, "
            SqlText = SqlText & "         CD.CD_FORNECEDOR, "
            SqlText = SqlText & "         F.NO_RAZAO_SOCIAL, "
            SqlText = SqlText & "         CD.VL_ORIGINAL, "
            SqlText = SqlText & "         CD.QT_ORIGINAL, "
            SqlText = SqlText & "         CD.VL_NEGOCIADO, "
            SqlText = SqlText & "         CD.CD_FILIAL_ORIGEM, "
            SqlText = SqlText & "         FIL.NO_FILIAL, "
            SqlText = SqlText & "         CDM.NO_CONFISSAO_DIVIDA_MODALIDADE "
        End If

        oData = DBQuery(SqlText)

        '==>sub relatorio contratos
        If optTipo.Value = "A" Then
            SqlText = "SELECT   cd_contrato_paf, sq_negociacao, sq_contrato_fixo, "
            SqlText = SqlText & "         sq_confissao_divida, SUM (vl_fixo) vl_fixo, "
            SqlText = SqlText & "         SUM (qt_cancelado) qt_cancelado "
            SqlText = SqlText & "    FROM (SELECT cpc.cd_contrato_paf, cfc.sq_negociacao, cfc.sq_contrato_fixo, "
            SqlText = SqlText & "                 0 vl_fixo, "
            SqlText = SqlText & "                 NVL (cfc.qt_cancelado, cpc.qt_cancelado) qt_cancelado, "
            SqlText = SqlText & "                 NVL (cfc.sq_confissao_divida, "
            SqlText = SqlText & "                      cpc.sq_confissao_divida "
            SqlText = SqlText & "                     ) sq_confissao_divida "
            SqlText = SqlText & "            FROM sof.contrato_paf_cancelado cpc, "
            SqlText = SqlText & "                 sof.contrato_fixo_cancelado cfc, "
            SqlText = SqlText & "                 sof.confissao_divida cd "
            SqlText = SqlText & "           WHERE cpc.cd_contrato_paf = cfc.cd_contrato_paf(+) "
            SqlText = SqlText & "             AND cpc.sq_confissao_divida = cd.sq_confissao_divida "
            SqlText = SqlText & "             AND cd.ic_status = 'A' "


            If SelecaoFilial.Lista_Quantidade > 0 Then
                SqlText = SqlText & "     AND cd.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
                sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
            End If

            If SelecaoModalidade.Lista_Quantidade > 0 Then
                SqlText = SqlText & "     AND cd.CD_CONFISSAO_DIVIDA_MODALIDADE IN (" & SelecaoModalidade.Lista_ID & ")"
                sFiltro = sFiltro & " - Modalidade: " & SelecaoModalidade.Lista_Descricao
            End If

            SqlText = SqlText & "          UNION ALL "
            SqlText = SqlText & "          SELECT pcp.cd_contrato_paf, pncf.sq_negociacao, "
            SqlText = SqlText & "                 pncf.sq_contrato_fixo, "
            SqlText = SqlText & "                 0 - NVL (pncf.vl_fixo, pcp.vl_fixo) vl_fixo, 0 qt_cancelado, "
            SqlText = SqlText & "                 NVL (pncf.sq_confissao_divida, "
            SqlText = SqlText & "                      pcp.sq_confissao_divida "
            SqlText = SqlText & "                     ) sq_confissao_divida "
            SqlText = SqlText & "            FROM sof.pag_ctr_paf pcp, "
            SqlText = SqlText & "                 sof.pag_neg_ctr_fix pncf, "
            SqlText = SqlText & "                 sof.pagamentos p, "
            SqlText = SqlText & "                 sof.confissao_divida cd "
            SqlText = SqlText & "           WHERE pcp.cd_contrato_paf = pncf.cd_contrato_paf(+) "
            SqlText = SqlText & "             AND pcp.sq_pagamento = pncf.sq_pagamento(+) "
            SqlText = SqlText & "             AND pcp.sq_pag_ctr_paf = pncf.sq_pag_ctr_paf(+) "
            SqlText = SqlText & "             AND pcp.sq_pagamento = p.sq_pagamento "
            SqlText = SqlText & "             AND p.sq_conf_div_ativo_venda IS NULL "
            SqlText = SqlText & "             AND pcp.ic_confissao_divida_estorno = 'S' "
            SqlText = SqlText & "             AND pcp.sq_confissao_divida = cd.sq_confissao_divida "
            SqlText = SqlText & "             AND cd.ic_status = 'A' "

            If SelecaoFilial.Lista_Quantidade > 0 Then
                SqlText = SqlText & "     AND cd.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
                sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
            End If

            If SelecaoModalidade.Lista_Quantidade > 0 Then
                SqlText = SqlText & "     AND cd.CD_CONFISSAO_DIVIDA_MODALIDADE IN (" & SelecaoModalidade.Lista_ID & ")"
                sFiltro = sFiltro & " - Modalidade: " & SelecaoModalidade.Lista_Descricao
            End If

            SqlText = SqlText & ") GROUP BY cd_contrato_paf, sq_negociacao, sq_contrato_fixo, "
            SqlText = SqlText & "         sq_confissao_divida "

            oData_Sub1 = DBQuery(SqlText)

            oRelatorio.SetDataSource(oData)
            oRelatorio_Sub1 = oRelatorio.Subreports("CRContrato")
            oRelatorio_Sub1.SetDataSource(oData_Sub1)
        Else
            oRelatorio.SetDataSource(oData)
        End If

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        crvMain.ReportSource = oRelatorio


        AVI_Fechar(Me)
    End Sub


    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Dim oForm As New frmAvi
        oForm.StartPosition = FormStartPosition.CenterScreen
        oForm.BackColor = System.Drawing.Color.FromArgb(CType(230, Byte), CType(238, Byte), CType(249, Byte))
        oForm.ShowInTaskbar = False
        oForm.Show()

        Imprimir()

        oForm.Close()
    End Sub
End Class