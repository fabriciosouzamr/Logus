Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_ContaCorrenteContratoFixo
    Dim oRelatorio As New CrystalReportDocument

    Private Sub frmREL_ContaCorrenteContratoFixo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_ContaCorrenteContratoFixo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Pesq_ContratoPAF
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_ContratoPAF
            .BancoDados_Filtro_Limpar()
            '.BancoDados_Filtro_Adicionar("IC_STATUS = 'A'")
        End With

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Imprimir()
        Dim oRelatorio_Sub1 As New ReportDocument
        Dim oRelatorio_Sub2 As New ReportDocument
        Dim oData As DataTable
        Dim oDataAux1 As DataTable
        Dim oDataAux2 As DataTable
        Dim SqlText As String = ""
        Dim Texto As String
        Dim mPerc As Double
        Dim mTotRec As Double
        Dim mTotCtr As Double
        Dim mVlFun As Double
        Dim mTotQtRec As Long
        Dim mVlUnit As Double
        Dim mVlTotalCtr As Double
        Dim QtFinal As Double
        Dim mVlTotalCtrComICMS As Double
        Dim mTotICMS As Double
        Dim mVlICMSMov As Double
        Dim iContAux1 As Integer

        AVI_Carregar(Me)

        If Pesq_ContratoPAF.Codigo = 0 Then
            Msg_Mensagem("Favor informa um contrato PAF.")
            Pesq_ContratoPAF.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboNegociacao) Then
            Msg_Mensagem("Favor selecionar uma negociação.")
            cboNegociacao.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then
            Msg_Mensagem("Favor selecionar um contrato fixo.")
            cboContratoFixo.Focus()
            Exit Sub
        End If

        'Verifica se o fornecedor é de alguma filial do usuário
        SqlText = "SELECT COUNT(*)" & _
                  " FROM SOF.FORNECEDOR F," & _
                        "SOF.CONTRATO_PAF CP " & _
                  " WHERE  CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND CP.CD_CONTRATO_PAF=" & Pesq_ContratoPAF.Codigo & _
                    " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"

        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Este fornecedor não pertence a nenhuma das filiais liberadas para o seu acesso.")
            Pesq_ContratoPAF.Focus()
            Exit Sub
        End If

        SqlText = "SELECT CF.CD_CONTRATO_PAF CD_CONTRATO," & _
                         "CF.QT_KGS," & _
                         "NVL(CF.VL_ICMS, 0) VL_ICMS," & _
                         "CF.VL_TOTAL," & _
                         "CF.VL_INSS," & _
                         "F.NO_RAZAO_SOCIAL," & _
                         "F.NO_CONTATO," & _
                         "F.NU_FAX," & _
                         "CF.DT_CONTRATO_FIXO DT_CONTRATO," & _
                         "FU.VL_TAXA," & _
                         "F.CD_FILIAL_ORIGEM," & _
                         "CF.VL_ADENDO VL_ADENDO_CONTRATO," & _
                         "CF.VL_ADENDO_ICMS VL_ICMS_ADENDO," & _
                         "CF.VL_ADENDO_INSS VL_INSS_ADENDO," & _
                         "CF.SQ_NEGOCIACAO," & _
                         "CF.SQ_CONTRATO_FIXO," & _
                         "CF.QT_CANCELADO," & _
                         "TU.NO_TIPO_UNIDADE," & _
                         "CF.VL_UNITARIO," & _
                         "SOF.FC_SALDO_CTR_FIX (CF.CD_CONTRATO_PAF, CF.SQ_NEGOCIACAO, CF.SQ_CONTRATO_FIXO) AS SALDO" & _
                  " FROM SOF.CONTRATO_PAF CP," & _
                        "SOF.NEGOCIACAO N," & _
                        "SOF.CONTRATO_FIXO CF," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FUNRURAL FU," & _
                        "SOF.TIPO_UNIDADE TU" & _
                  " WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                    " AND N.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                    " AND N.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO" & _
                    " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND F.CD_FUNRURAL = FU.CD_FUNRURAL" & _
                    " AND CF.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                    " AND CF.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND CF.SQ_NEGOCIACAO = " & cboNegociacao.SelectedValue & _
                    " AND CF.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue
        oData = DBQuery(SqlText)

        If oData.Rows.Count = 0 Then
            Msg_Mensagem("Contrato inexistente.")
            Pesq_ContratoPAF.Focus()
            AVI_Fechar(Me)
            Exit Sub
        End If

        mTotCtr = oData.Rows(0).Item("VL_TOTAL") + _
                  oData.Rows(0).Item("VL_ICMS") + _
                  oData.Rows(0).Item("VL_ADENDO_CONTRATO") + _
                  oData.Rows(0).Item("VL_ICMS_ADENDO")

        SqlText = "SELECT   M.DT_MOVIMENTACAO, M.NU_NF, M.QT_KG_NF, M.VL_NF, M.QT_KG_LIQUIDO_NF, "
        SqlText = SqlText & "         CM.DT_FIXACAO, CM.QT_KG_FIXO, CM.VL_FIXO, MQ.QT_UMIDADE, "
        SqlText = SqlText & "         CM.CD_CONTRATO_PAF CD_CONTRATO, M.VL_NF_ICMS, M.VL_NF_FUNRURAL, "
        SqlText = SqlText & "         M.NU_NF_REFERENCIA, M.CD_FILIAL_MOVIMENTACAO, CM.SQ_NEGOCIACAO, "
        SqlText = SqlText & "         CM.SQ_CONTRATO_FIXO, MQ.PC_SUJIDADE QT_SUJIDADE, M.SQ_MOVIMENTACAO, "
        SqlText = SqlText & "         CM.CD_CONTRATO_PAF "
        SqlText = SqlText & "    FROM SOF.MOVIMENTACAO M, "
        SqlText = SqlText & "         SOF.CTR_PAF_NEG_CTR_FIX_MOV CM, "
        SqlText = SqlText & "         SOF.MOVIMENTACAO_QUALIDADE MQ "
        SqlText = SqlText & "   WHERE M.SQ_MOVIMENTACAO = CM.SQ_MOVIMENTACAO "
        SqlText = SqlText & "     AND M.SQ_MOVIMENTACAO = MQ.SQ_MOVIMENTACAO(+) "
        SqlText = SqlText & "     AND CM.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo
        SqlText = SqlText & "     AND CM.SQ_NEGOCIACAO = " & cboNegociacao.SelectedValue
        SqlText = SqlText & "     AND CM.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue
        SqlText = SqlText & "ORDER BY CM.DT_CRIACAO "

        oDataAux1 = DBQuery(SqlText)

        mTotRec = 0
        mTotQtRec = 0

        If oDataAux1.Rows.Count > 0 Then
            For iContAux1 = 0 To oDataAux1.Rows.Count - 1
                'VERIFICO O QUE JÁ TEM DE ICMS AMARRADO PARA RETIRAR DO VL DE NF FIXO
                If oData.Rows(0).Item("VL_ICMS") <> 0 Then
                    SqlText = "SELECT decode(m.vl_nf,0,0, ROUND ((cm.vl_fixo * p.vl_pagamento) / m.vl_nf, 2)) AS vl_icms "
                    SqlText = SqlText & "  FROM sof.pagamentos p, sof.ctr_paf_neg_ctr_fix_mov cm, sof.movimentacao m "
                    SqlText = SqlText & " WHERE p.sq_movimentacao = " & oDataAux1.Rows(iContAux1).Item("sq_movimentacao")
                    SqlText = SqlText & "   AND m.sq_movimentacao = cm.sq_movimentacao "
                    SqlText = SqlText & "   AND m.sq_movimentacao = p.sq_movimentacao "
                    SqlText = SqlText & "  and cm.cd_contrato_paf = " & oDataAux1.Rows(iContAux1).Item("cd_contrato_paf")
                    SqlText = SqlText & "   and cm.sq_negociacao = " & oDataAux1.Rows(iContAux1).Item("sq_negociacao")
                    SqlText = SqlText & "   and cm.sq_contrato_fixo = " & oDataAux1.Rows(iContAux1).Item("sq_contrato_fixo")

                    mVlICMSMov = DBQuery_ValorUnico(SqlText, 0)
                Else
                    mVlICMSMov = 0
                End If

                mVlFun = (oDataAux1.Rows(iContAux1).Item("VL_FIXO") / IIf(oDataAux1.Rows(iContAux1).Item("VL_NF") = 0, 1, oDataAux1.Rows(iContAux1).Item("VL_NF"))) * oDataAux1.Rows(iContAux1).Item("VL_NF_FUNRURAL")
                mTotRec = mTotRec + Math.Round(oDataAux1.Rows(iContAux1).Item("VL_FIXO"), 2) - mVlFun - mVlICMSMov
                mTotICMS = mTotICMS + mVlICMSMov
                mTotQtRec = mTotQtRec + oDataAux1.Rows(iContAux1).Item("qt_kg_fixo")
            Next
        End If

        SqlText = "SELECT   p.dt_pagamento, p.ds_descricao, cp.vl_fixo vl_pagamento, "
        SqlText = SqlText & "         p.vl_taxa_dolar, "
        SqlText = SqlText & "         ROUND ((  cp.vl_fixo "
        SqlText = SqlText & "                 / DECODE (NVL (p.vl_taxa_dolar, 0), 0, 1, p.vl_taxa_dolar) "
        SqlText = SqlText & "                ), "
        SqlText = SqlText & "                2 "
        SqlText = SqlText & "               ) vl_dolar, "
        SqlText = SqlText & "         p.ic_icms, cp.cd_contrato_paf cd_contrato, cp.sq_negociacao, "
        SqlText = SqlText & "         cp.sq_contrato_fixo, cp.dt_fixacao "
        SqlText = SqlText & "    FROM sof.pagamentos p, sof.pag_neg_ctr_fix cp "
        SqlText = SqlText & "   WHERE p.sq_pagamento = cp.sq_pagamento "
        SqlText = SqlText & "     AND cp.cd_contrato_paf = " & Pesq_ContratoPAF.Codigo
        SqlText = SqlText & "     AND cp.sq_negociacao = " & cboNegociacao.SelectedValue
        SqlText = SqlText & "     AND cp.sq_contrato_fixo = " & cboContratoFixo.SelectedValue
        SqlText = SqlText & "UNION ALL "
        SqlText = SqlText & "SELECT   p.dt_pagamento, p.ds_descricao,"
        SqlText = SqlText & "         SUM (ROUND ((  (pa.vl_aplicacao * cpncfm.vl_fixo)"
        SqlText = SqlText & "                      / DECODE (m.vl_nf, 0, 1, m.vl_nf)"
        SqlText = SqlText & "                     ) * tmov.tx_ctr_antigo,"
        SqlText = SqlText & "                     2"
        SqlText = SqlText & "                    )"
        SqlText = SqlText & "             ) vl_pagamento,"
        SqlText = SqlText & "         p.vl_taxa_dolar,"
        SqlText = SqlText & "         ROUND ((  SUM (ROUND ((  (pa.vl_aplicacao * cpncfm.vl_fixo)"
        SqlText = SqlText & "                                / DECODE (m.vl_nf, 0, 1, m.vl_nf)"
        SqlText = SqlText & "                               ),"
        SqlText = SqlText & "                               2"
        SqlText = SqlText & "                              )"
        SqlText = SqlText & "                       )"
        SqlText = SqlText & "                 / DECODE (NVL (p.vl_taxa_dolar, 0), 0, 1, p.vl_taxa_dolar)"
        SqlText = SqlText & "                ) * tmov.tx_ctr_antigo,"
        SqlText = SqlText & "                2"
        SqlText = SqlText & "               ) vl_dolar,"
        SqlText = SqlText & "         p.ic_icms, cpncfm.cd_contrato_paf cd_contrato, cpncfm.sq_negociacao,"
        SqlText = SqlText & "         cpncfm.sq_contrato_fixo,pa.dt_amarracao dt_fixacao"
        SqlText = SqlText & "    FROM sof.movimentacao m,"
        SqlText = SqlText & "         sof.pagamentos p,"
        SqlText = SqlText & "         sof.pag_amarracao_icms pa,"
        SqlText = SqlText & "         (SELECT   cp.sq_movimentacao,"
        SqlText = SqlText & "                    1 + DECODE((SUM(CP.VL_FIXO) - SUM(DECODE(CF.IC_INCLUI_ICMS_PAG, 'S', CP.VL_FIXO, 0))), 0, 0, SUM(DECODE(CF.IC_INCLUI_ICMS_PAG, 'S', CP.VL_FIXO, 0)) / (SUM(CP.VL_FIXO) - SUM(DECODE(CF.IC_INCLUI_ICMS_PAG, 'S', CP.VL_FIXO, 0)))) TX_CTR_ANTIGO"
        SqlText = SqlText & "            FROM sof.ctr_paf_neg_ctr_fix_mov cp, sof.contrato_fixo cf"
        SqlText = SqlText & "           WHERE cp.sq_movimentacao IN (SELECT DISTINCT sq_movimentacao"
        SqlText = SqlText & "                                                   FROM sof.pag_amarracao_icms)"
        SqlText = SqlText & "             AND cp.cd_contrato_paf = cf.cd_contrato_paf"
        SqlText = SqlText & "             AND cp.sq_negociacao = cf.sq_negociacao"
        SqlText = SqlText & "              AND cp.sq_contrato_fixo = cf.sq_contrato_fixo"
        SqlText = SqlText & "        GROUP BY cp.sq_movimentacao) tmov,"
        SqlText = SqlText & "        (SELECT   cp.cd_contrato_paf, cp.sq_negociacao, cp.sq_contrato_fixo,"
        SqlText = SqlText & "                  cp.sq_movimentacao, SUM (cp.vl_fixo) AS vl_fixo"
        SqlText = SqlText & "             FROM sof.ctr_paf_neg_ctr_fix_mov cp, sof.contrato_fixo cf"
        SqlText = SqlText & "             WHERE cp.sq_movimentacao IN (SELECT DISTINCT sq_movimentacao"
        SqlText = SqlText & "                                                    FROM sof.pag_amarracao_icms)"
        SqlText = SqlText & "             AND cp.cd_contrato_paf = cf.cd_contrato_paf"
        SqlText = SqlText & "             AND cp.sq_negociacao = cf.sq_negociacao"
        SqlText = SqlText & "              AND cp.sq_contrato_fixo = cf.sq_contrato_fixo"
        SqlText = SqlText & "              and cf.ic_inclui_icms_pag ='N' "
        SqlText = SqlText & "         GROUP BY cp.cd_contrato_paf,"
        SqlText = SqlText & "                  cp.sq_negociacao,"
        SqlText = SqlText & "                  cp.sq_contrato_fixo,"
        SqlText = SqlText & "                  cp.sq_movimentacao) cpncfm"
        SqlText = SqlText & "   WHERE pa.sq_movimentacao = m.sq_movimentacao"
        SqlText = SqlText & "     AND pa.sq_pagamento = p.sq_pagamento"
        SqlText = SqlText & "     AND m.sq_movimentacao = cpncfm.sq_movimentacao"
        SqlText = SqlText & "    AND m.sq_movimentacao = tmov.sq_movimentacao(+)"
        SqlText = SqlText & "     AND cpncfm.cd_contrato_paf = " & Pesq_ContratoPAF.Codigo
        SqlText = SqlText & "     AND cpncfm.sq_negociacao = " & cboNegociacao.SelectedValue
        SqlText = SqlText & "     AND cpncfm.sq_contrato_fixo = " & cboContratoFixo.SelectedValue
        SqlText = SqlText & "GROUP BY p.dt_pagamento,"
        SqlText = SqlText & "         p.ds_descricao,"
        SqlText = SqlText & "         p.vl_taxa_dolar,"
        SqlText = SqlText & "         p.ic_icms,"
        SqlText = SqlText & "         cpncfm.cd_contrato_paf,"
        SqlText = SqlText & "         cpncfm.sq_negociacao,"
        SqlText = SqlText & "         cpncfm.sq_contrato_fixo,"
        SqlText = SqlText & "         pa.dt_amarracao, tmov.tx_ctr_antigo "
        oDataAux2 = DBQuery(SqlText)

        mPerc = 1 - (oData.Rows(0).Item("VL_TAXA") / 100)
        mVlTotalCtrComICMS = (((oData.Rows(0).Item("QT_KGS") - oData.Rows(0).Item("QT_CANCELADO")) / oData.Rows(0).Item("QT_KGS")) * (oData.Rows(0).Item("VL_TOTAL") + oData.Rows(0).Item("VL_ICMS"))) + oData.Rows(0).Item("VL_ADENDO_CONTRATO") + oData.Rows(0).Item("VL_ICMS_ADENDO")
        mVlTotalCtr = oData.Rows(0).Item("SALDO")
        QtFinal = (oData.Rows(0).Item("QT_KGS") - oData.Rows(0).Item("QT_CANCELADO"))

        If QtFinal = 0 Then
            mVlUnit = 0
        Else
            mVlUnit = mVlTotalCtr / QtFinal
        End If

        If (oData.Rows(0).Item("QT_KGS") - oData.Rows(0).Item("QT_CANCELADO")) <= mTotQtRec Then
            Select Case True
                Case Math.Round(mVlTotalCtrComICMS, 2) > Math.Round(mTotRec + mTotICMS, 2)
                    Texto = "Favor enviar nota fiscal complementar no valor de R$ " & _
                             Format((mVlTotalCtrComICMS - (mTotRec + mTotICMS)) / mPerc, "#,##0.00")
                Case Math.Round(mVlTotalCtrComICMS, 2) < Math.Round(mTotRec, 2)
                    Texto = "O fornecedor possue um credito de R$ " & _
                            Format((mTotRec - mVlTotalCtrComICMS) / mPerc, "#,##0.00")
                Case Else
                    Texto = ""
            End Select
        Else
            Texto = "Contrato ainda não foi totalmente entregue. Saldo: " & Format(((oData.Rows(0).Item("qt_kgs") - oData.Rows(0).Item("QT_CANCELADO")) - mTotQtRec), "#,##0") & " Kg"
        End If

        iContAux1 = 0

        'Exclui aplicações zeradas
        If oDataAux1.Rows.Count > 0 Then
            Do While True
                With oDataAux1.Rows(iContAux1)
                    If .Item("QT_KG_FIXO") = 0 And .Item("VL_FIXO") = 0 Then
                        oDataAux1.Rows.RemoveAt(iContAux1)
                    Else
                        iContAux1 = iContAux1 + 1
                    End If
                End With

                If iContAux1 = oDataAux1.Rows.Count Then Exit Do
            Loop
        End If

        oRelatorio.Load(Application.StartupPath & "\RPT_Conta_Corrente_Contrato_Fixo.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio_Sub1 = oRelatorio.Subreports("CRCCRec")
        oRelatorio_Sub1.SetDataSource(oDataAux1)
        oRelatorio_Sub2 = oRelatorio.Subreports("CRCCPag")
        oRelatorio_Sub2.SetDataSource(oDataAux2)

        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        oRelatorio.SetParameterValue("ComMovimentacao", IIf(objDataTable_Vazio(oDataAux1), "N", "S"))
        oRelatorio.SetParameterValue("ComPagamento", IIf(objDataTable_Vazio(oDataAux2), "N", "S"))
        oRelatorio.SetParameterValue("Texto", Texto)

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_ContaCorrenteContratoFixo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Pesq_ContratoPAF_AlterouRegistro() Handles Pesq_ContratoPAF.AlterouRegistro
        Dim SqlText As String

        cboNegociacao.DataSource = Nothing

        If Pesq_ContratoPAF.Codigo = 0 Then Exit Sub

        SqlText = "select sq_negociacao, to_char(sq_negociacao) as no_negociacao " & _
          "from sof.negociacao " & _
          "where IC_STATUS<>'E' AND CD_CONTRATO_PAF=" & Pesq_ContratoPAF.Codigo & " " & _
          "ORDER BY SQ_NEGOCIACAO"

        DBCarregarComboBox(cboNegociacao, SqlText, True)
    End Sub

    Private Sub cboNegociacao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNegociacao.SelectedIndexChanged
        Dim SqlText As String

        cboContratoFixo.DataSource = Nothing

        If Not ComboBox_LinhaSelecionada(cboNegociacao) Then Exit Sub

        SqlText = "select sq_CONTRATO_FIXO,to_char(sq_CONTRATO_FIXO) as no_CONTRATO_FIXO " & _
                  "from sof.CONTRATO_FIXO " & _
                  "where IC_STATUS<>'E' AND " & _
                  "CD_CONTRATO_PAF=" & Pesq_ContratoPAF.Codigo & " AND " & _
                  "SQ_NEGOCIACAO=" & cboNegociacao.SelectedValue & " " & _
                  "ORDER BY sq_CONTRATO_FIXO"

        DBCarregarComboBox(cboContratoFixo, SqlText, True)
    End Sub

    Private Sub cboContratoFixo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContratoFixo.SelectedIndexChanged
        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then Exit Sub
        Imprimir()
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub
End Class