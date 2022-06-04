Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Aplicacoes
    Dim oRelatorio As New CrystalReportDocument

    Private Sub frmREL_Aplicacoes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Aplicacoes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim SqlFiltro As String = ""
        Dim sFiltro As String = ""

        If Not IsDate(txtDataInicial.Text) Then
            Msg_Mensagem("Favor informar a data inicial.")
            txtDataInicial.Focus()
            Exit Sub
        End If

        AVI_Carregar(Me)

        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlFiltro = SqlFiltro & "     AND f.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
            sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
        Else
            SqlFiltro = SqlFiltro & "     AND f.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        If Pesq_Fornecedor.Codigo > 0 Then
            SqlFiltro = SqlFiltro & " AND f.cd_fornecedor=" & Pesq_Fornecedor.Codigo
            sFiltro = sFiltro & " - Fornecedor: " & Pesq_Fornecedor.Text
        End If

        If optPagRec.Value = "P" Then
            If IsDate(txtDataInicial.Text) Then
                SqlFiltro = SqlFiltro & " AND TRUNC( PC.dt_fixacao ) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
                sFiltro = sFiltro & " - Data Inicial: " & txtDataInicial.Text
            End If

            If IsDate(txtDataFinal.Text) Then
                SqlFiltro = SqlFiltro & " AND TRUNC( Pc.dt_fixacao ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
                sFiltro = sFiltro & " - Data Final: " & txtDataFinal.Text
            End If
        Else
            If IsDate(txtDataInicial.Text) Then
                SqlFiltro = SqlFiltro & " AND TRUNC( cm.dt_fixacao ) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
                sFiltro = sFiltro & " - Data Inicial: " & txtDataInicial.Text
            End If

            If IsDate(txtDataFinal.Text) Then
                SqlFiltro = SqlFiltro & " AND TRUNC( cm.dt_fixacao ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
                sFiltro = sFiltro & " - Data Final: " & txtDataFinal.Text
            End If
        End If

        If optPagRec.Value = "P" Then
            If chkSemContrato.Checked Then
                SqlText = "SELECT p.dt_pagamento, pc.dt_fixacao, f.no_razao_social, tp.no_tipo_pagamento, "
                SqlText = SqlText & "       fp.no_forma_pagamento, pc.vl_fixo, pc.cd_contrato_paf || ' ' AS cd_contrato, "
                SqlText = SqlText & "       'Contrato PAF' tipo "
                SqlText = SqlText & "  FROM sof.pag_ctr_paf pc, "
                SqlText = SqlText & "       sof.pagamentos p, "
                SqlText = SqlText & "       sof.tipo_pagamento tp, "
                SqlText = SqlText & "       sof.forma_pagamento fp, "
                SqlText = SqlText & "       sof.fornecedor f "
                SqlText = SqlText & " WHERE pc.sq_pagamento = p.sq_pagamento "
                SqlText = SqlText & "   AND p.cd_forma_pagamento = fp.cd_forma_pagamento "
                SqlText = SqlText & "   AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
                SqlText = SqlText & "   AND p.cd_fornecedor = f.cd_fornecedor "

                SqlText = SqlText & SqlFiltro
            End If

            If chkNegociacao.Checked Then
                If Trim(SqlText) <> "" Then SqlText = SqlText & "UNION ALL "

                SqlText = SqlText & "SELECT p.dt_pagamento, pc.dt_fixacao, f.no_razao_social, tp.no_tipo_pagamento, "
                SqlText = SqlText & "       fp.no_forma_pagamento, pc.vl_fixo, "
                SqlText = SqlText & "          pc.cd_contrato_paf "
                SqlText = SqlText & "       || '-' "
                SqlText = SqlText & "       || pc.sq_negociacao AS cd_contrato, "
                SqlText = SqlText & "       'Contrato Negociação' tipo "
                SqlText = SqlText & "  FROM sof.pag_neg pc, "
                SqlText = SqlText & "       sof.pagamentos p, "
                SqlText = SqlText & "       sof.tipo_pagamento tp, "
                SqlText = SqlText & "       sof.forma_pagamento fp, "
                SqlText = SqlText & "       sof.fornecedor f "
                SqlText = SqlText & " WHERE pc.sq_pagamento = p.sq_pagamento "
                SqlText = SqlText & "   AND p.cd_forma_pagamento = fp.cd_forma_pagamento "
                SqlText = SqlText & "   AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
                SqlText = SqlText & "   AND p.cd_fornecedor = f.cd_fornecedor "

                SqlText = SqlText & SqlFiltro
            End If

            If chkContratoFixo.Checked Then
                If Trim(SqlText) <> "" Then SqlText = SqlText & "UNION ALL "

                SqlText = SqlText & "SELECT p.dt_pagamento, pc.dt_fixacao, f.no_razao_social, tp.no_tipo_pagamento, "
                SqlText = SqlText & "       fp.no_forma_pagamento, pc.vl_fixo, "
                SqlText = SqlText & "          pc.cd_contrato_paf "
                SqlText = SqlText & "       || '-' "
                SqlText = SqlText & "       || pc.sq_negociacao "
                SqlText = SqlText & "       || '-' "
                SqlText = SqlText & "       || pc.sq_contrato_fixo AS cd_contrato, "
                SqlText = SqlText & "       'Contrato Fixo' tipo "
                SqlText = SqlText & "  FROM sof.pag_neg_ctr_fix pc, "
                SqlText = SqlText & "       sof.pagamentos p, "
                SqlText = SqlText & "       sof.tipo_pagamento tp, "
                SqlText = SqlText & "       sof.forma_pagamento fp, "
                SqlText = SqlText & "       sof.fornecedor f "
                SqlText = SqlText & " WHERE pc.sq_pagamento = p.sq_pagamento "
                SqlText = SqlText & "   AND p.cd_forma_pagamento = fp.cd_forma_pagamento "
                SqlText = SqlText & "   AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
                SqlText = SqlText & "   AND p.cd_fornecedor = f.cd_fornecedor "

                SqlText = SqlText & SqlFiltro
            End If

            oData = DBQuery(SqlText)

            oRelatorio.Load(Application.StartupPath & "\RPT_Aplicacao_Pagamento.rpt")
            oRelatorio.SetDataSource(oData)
        Else

            If chkSemContrato.Checked Then
                SqlText = "SELECT m.dt_movimentacao, cm.dt_fixacao, m.nu_nf, f.no_razao_social, "
                SqlText = SqlText & "       tm.no_tipo_movimentacao, cm.vl_fixo, cm.qt_kg_fixo, "
                SqlText = SqlText & "       cm.cd_contrato_paf || ' ' cd_contrato, 'Contrato Fixo' AS tipo "
                SqlText = SqlText & "  FROM sof.ctr_paf_movimentacao cm, "
                SqlText = SqlText & "       sof.movimentacao m, "
                SqlText = SqlText & "       sof.tipo_movimentacao tm, "
                SqlText = SqlText & "       sof.fornecedor f "
                SqlText = SqlText & " WHERE cm.sq_movimentacao = m.sq_movimentacao "
                SqlText = SqlText & "   AND m.cd_tipo_movimentacao = tm.cd_tipo_movimentacao "
                SqlText = SqlText & "   AND m.cd_fornecedor = f.cd_fornecedor "

                SqlText = SqlText & SqlFiltro
            End If

            If chkNegociacao.Checked Then
                If Trim(SqlText) <> "" Then SqlText = SqlText & "UNION ALL "

                SqlText = SqlText & "SELECT m.dt_movimentacao, cm.dt_fixacao, m.nu_nf, f.no_razao_social, "
                SqlText = SqlText & "       tm.no_tipo_movimentacao, cm.vl_fixo, cm.qt_kg_fixo, "
                SqlText = SqlText & "       cm.cd_contrato_paf || '-' || cm.sq_negociacao cd_contrato, "
                SqlText = SqlText & "       'Contrato Fixo' AS tipo "
                SqlText = SqlText & "  FROM sof.ctr_paf_neg_movimentacao cm, "
                SqlText = SqlText & "       sof.movimentacao m, "
                SqlText = SqlText & "       sof.tipo_movimentacao tm, "
                SqlText = SqlText & "       sof.fornecedor f "
                SqlText = SqlText & " WHERE cm.sq_movimentacao = m.sq_movimentacao "
                SqlText = SqlText & "   AND cm.QT_KG_FIXO <> 0 "
                SqlText = SqlText & "   AND cm.VL_FIXO <> 0 "
                SqlText = SqlText & "   AND m.cd_tipo_movimentacao = tm.cd_tipo_movimentacao "
                SqlText = SqlText & "   AND m.cd_fornecedor = f.cd_fornecedor "

                SqlText = SqlText & SqlFiltro
            End If

            If chkContratoFixo.Checked Then
                If Trim(SqlText) <> "" Then SqlText = SqlText & "UNION ALL "

                SqlText = SqlText & "SELECT m.dt_movimentacao, cm.dt_fixacao, m.nu_nf, f.no_razao_social, "
                SqlText = SqlText & "       tm.no_tipo_movimentacao, cm.vl_fixo, cm.qt_kg_fixo, "
                SqlText = SqlText & "          cm.cd_contrato_paf "
                SqlText = SqlText & "       || '-' "
                SqlText = SqlText & "       || cm.sq_negociacao "
                SqlText = SqlText & "       || '-' "
                SqlText = SqlText & "       || cm.sq_contrato_fixo cd_contrato, "
                SqlText = SqlText & "       'Contrato Fixo' AS tipo "
                SqlText = SqlText & "  FROM sof.ctr_paf_neg_ctr_fix_mov cm, "
                SqlText = SqlText & "       sof.movimentacao m, "
                SqlText = SqlText & "       sof.tipo_movimentacao tm, "
                SqlText = SqlText & "       sof.fornecedor f "
                SqlText = SqlText & " WHERE cm.sq_movimentacao = m.sq_movimentacao "
                SqlText = SqlText & "   AND m.cd_tipo_movimentacao = tm.cd_tipo_movimentacao "
                SqlText = SqlText & "   AND m.cd_fornecedor = f.cd_fornecedor "
                SqlText = SqlText & "   and (cm.qt_kg_fixo <> 0  or cm.vl_fixo <> 0) "
                SqlText = SqlText & SqlFiltro
            End If
            oData = DBQuery(SqlText)

            oRelatorio.Load(Application.StartupPath & "\RPT_Aplicacao_Recebimento.rpt")
            oRelatorio.SetDataSource(oData)
        End If



        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())


        crvMain.ReportSource = oRelatorio


        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub frmREL_Aplicacoes_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub
End Class