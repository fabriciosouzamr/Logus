Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmREL_PDD
    Dim oRelatorio As New CrystalReportDocument
    Dim oData_Rel As New DataTable

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_PDD_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_PDD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_PDD_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Imprimir()
        Dim SqlText As String
        Dim SqlFiltro As String
        Dim sFiltro As String = String.Empty
        Dim dDataInicial As Date
        Dim dDataFinal As Date

        If Not IsDate(txtMes.Text) Then
            Msg_Mensagem("Favor informar o mês.")
            txtMes.Focus()
            Exit Sub
        End If

        dDataInicial = txtMes.Text
        dDataInicial = CDate("01/" & dDataInicial.Month & "/" & dDataInicial.Year)
        dDataFinal = CDate(DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dDataInicial)))

        If Pesq_Fornecedor.Codigo <> 0 Then
            SqlFiltro = SqlFiltro & " and p.cd_fornecedor =" & Pesq_Fornecedor.Codigo & " "
        End If

        If optTipo_PDD.Checked Then
            SqlFiltro = SqlFiltro & " and p.cd_tipo_pdd =2 "
        End If

        If optTipo_GAAP.Checked Then
            SqlFiltro = SqlFiltro & " and p.cd_tipo_pdd =1 "
        End If

        If SelecaoFilial.Lista_Quantidade <> 0 Then
            SqlFiltro = SqlFiltro & " and p.cd_filial_referencia in (" & SelecaoFilial.Lista_ID & ") "
        End If

        Try
            SqlText = "SELECT    NVL (p.cd_contrato_paf, p.sq_confissao_divida)"
            SqlText = SqlText & "       || DECODE (p.sq_negociacao, NULL, '', '-' || p.sq_negociacao)"
            SqlText = SqlText & "         || DECODE (p.sq_contrato_fixo, NULL, '', '-' || p.sq_contrato_fixo)  cd_contrato,"
            SqlText = SqlText & "         f.no_razao_social , fil.no_filial,"
            SqlText = SqlText & "         DECODE (p.cd_tipo_pdd, 1, 'GAAP', 'PDD') tipo, tg.no_tipo_garantia,"
            SqlText = SqlText & "         p.qt_kgs_devedor AS qt_pdd, p.vl_devedor,"
            SqlText = SqlText & "         p.vl_devedor - NVL (pag.vl_pago, 0) AS vl_pdd,"
            SqlText = SqlText & "         DECODE (p.ic_bens, 'N', 'Não', 'S', 'Sim', 'Não Definido') bens,"
            SqlText = SqlText & "         p.cm_status, p.ds_pdd, p.dt_vencimento, NULL ds_grupo"
            SqlText = SqlText & "    FROM sof.pdd p,sof.fornecedor f,sof.filial fil,"
            SqlText = SqlText & "         sof.tipo_garantia tg,"
            SqlText = SqlText & "         (SELECT   a.sq_pdd, SUM (a.vl_pago) vl_pago"
            SqlText = SqlText & "              FROM sof.pdd_pagamento a"
            SqlText = SqlText & "             WHERE nvl(a.dt_exclusao,sysdate+1) <= " & QuotedStr(Date_to_Oracle(dDataFinal))
            SqlText = SqlText & "             and a.dt_criacao <= " & QuotedStr(Date_to_Oracle(dDataFinal))
            SqlText = SqlText & "          GROUP BY a.sq_pdd) pag"
            SqlText = SqlText & "   WHERE p.cd_fornecedor = f.cd_fornecedor(+)"
            SqlText = SqlText & "     AND p.cd_filial_referencia = fil.cd_filial(+)"
            SqlText = SqlText & "     AND p.cd_tipo_garantia = tg.cd_tipo_garantia(+)"
            SqlText = SqlText & "     AND p.sq_pdd = pag.sq_pdd(+)"
            SqlText = SqlText & "     AND nvl(p.dt_exclusao,sysdate+1) <= " & QuotedStr(Date_to_Oracle(dDataFinal))
            SqlText = SqlText & "    and p.dt_criacao <= " & QuotedStr(Date_to_Oracle(dDataFinal))
            SqlText = SqlText & "      and   (p.vl_devedor - NVL (pag.vl_pago, 0) ) <>0 "

            SqlText = SqlText & SqlFiltro

            SqlText = SqlText & " union all "
            SqlText = SqlText & "SELECT    NVL (p.cd_contrato_paf, p.sq_confissao_divida)"
            SqlText = SqlText & "       || DECODE (p.sq_negociacao, NULL, '', '-' || p.sq_negociacao)"
            SqlText = SqlText & "         || DECODE (p.sq_contrato_fixo, NULL, '', '-' || p.sq_contrato_fixo)  cd_contrato,"
            SqlText = SqlText & "         f.no_razao_social , fil.no_filial,"
            SqlText = SqlText & "         DECODE (p.cd_tipo_pdd, 1, 'GAAP', 'PDD') tipo, tg.no_tipo_garantia,"
            SqlText = SqlText & "         p.qt_kgs_devedor AS qt_pdd, p.vl_devedor,"
            SqlText = SqlText & "         p.vl_devedor  AS vl_pdd,"
            SqlText = SqlText & "         DECODE (p.ic_bens, 'N', 'Não', 'S', 'Sim', 'Não Definido') bens,"
            SqlText = SqlText & "         p.cm_status, p.ds_pdd, p.dt_vencimento, 'Incluido' ds_grupo"
            SqlText = SqlText & "    FROM sof.pdd p,sof.fornecedor f,sof.filial fil,"
            SqlText = SqlText & "         sof.tipo_garantia tg"
            SqlText = SqlText & "   WHERE p.cd_fornecedor = f.cd_fornecedor(+)"
            SqlText = SqlText & "     AND p.cd_filial_referencia = fil.cd_filial(+)"
            SqlText = SqlText & "     AND p.cd_tipo_garantia = tg.cd_tipo_garantia(+)"
            SqlText = SqlText & "     AND nvl(p.dt_exclusao,sysdate+1) <= " & QuotedStr(Date_to_Oracle(dDataFinal))
            SqlText = SqlText & "    and p.dt_criacao between " & QuotedStr(Date_to_Oracle(dDataInicial)) & " and " & QuotedStr(Date_to_Oracle(dDataFinal))

            SqlText = SqlText & SqlFiltro

            SqlText = SqlText & " union all "
            SqlText = SqlText & "SELECT    NVL (p.cd_contrato_paf, p.sq_confissao_divida)"
            SqlText = SqlText & "       || DECODE (p.sq_negociacao, NULL, '', '-' || p.sq_negociacao)"
            SqlText = SqlText & "         || DECODE (p.sq_contrato_fixo, NULL, '', '-' || p.sq_contrato_fixo)  cd_contrato,"
            SqlText = SqlText & "         f.no_razao_social , fil.no_filial,"
            SqlText = SqlText & "         DECODE (p.cd_tipo_pdd, 1, 'GAAP', 'PDD') tipo, tg.no_tipo_garantia,"
            SqlText = SqlText & "         p.qt_kgs_devedor AS qt_pdd, p.vl_devedor,"
            SqlText = SqlText & "         p.vl_devedor - NVL (pag.vl_pago, 0) AS vl_pdd,"
            SqlText = SqlText & "         DECODE (p.ic_bens, 'N', 'Não', 'S', 'Sim', 'Não Definido') bens,"
            SqlText = SqlText & "         p.cm_status, p.ds_pdd, p.dt_vencimento, 'Excluido' ds_grupo"
            SqlText = SqlText & "    FROM sof.pdd p,sof.fornecedor f,sof.filial fil,"
            SqlText = SqlText & "         sof.tipo_garantia tg,"
            SqlText = SqlText & "         (SELECT   a.sq_pdd, SUM (a.vl_pago) vl_pago"
            SqlText = SqlText & "              FROM sof.pdd_pagamento a"
            SqlText = SqlText & "             WHERE nvl(a.dt_exclusao,sysdate+1) <= " & QuotedStr(Date_to_Oracle(dDataFinal))
            SqlText = SqlText & "             and a.dt_criacao <= " & QuotedStr(Date_to_Oracle(dDataFinal))
            SqlText = SqlText & "          GROUP BY a.sq_pdd) pag"
            SqlText = SqlText & "   WHERE p.cd_fornecedor = f.cd_fornecedor(+)"
            SqlText = SqlText & "     AND p.cd_filial_referencia = fil.cd_filial(+)"
            SqlText = SqlText & "     AND p.cd_tipo_garantia = tg.cd_tipo_garantia(+)"
            SqlText = SqlText & "     AND p.sq_pdd = pag.sq_pdd(+)"
            SqlText = SqlText & "     AND p.dt_exclusao between " & QuotedStr(Date_to_Oracle(dDataInicial)) & " and " & QuotedStr(Date_to_Oracle(dDataFinal))
            SqlText = SqlText & "    and p.dt_criacao <= " & QuotedStr(Date_to_Oracle(dDataFinal))

            SqlText = SqlText & SqlFiltro

            SqlText = SqlText & " union all "
            SqlText = SqlText & "SELECT    NVL (p.cd_contrato_paf, p.sq_confissao_divida)"
            SqlText = SqlText & "       || DECODE (p.sq_negociacao, NULL, '', '-' || p.sq_negociacao)"
            SqlText = SqlText & "         || DECODE (p.sq_contrato_fixo, NULL, '', '-' || p.sq_contrato_fixo)  cd_contrato,"
            SqlText = SqlText & "         f.no_razao_social , fil.no_filial,"
            SqlText = SqlText & "         DECODE (p.cd_tipo_pdd, 1, 'GAAP', 'PDD') tipo, tg.no_tipo_garantia,"
            SqlText = SqlText & "         p.qt_kgs_devedor AS qt_pdd, p.vl_devedor,"
            SqlText = SqlText & "         NVL (pag.vl_pago, 0) AS vl_pdd,"
            SqlText = SqlText & "         DECODE (p.ic_bens, 'N', 'Não', 'S', 'Sim', 'Não Definido') bens,"
            SqlText = SqlText & "         p.cm_status, p.ds_pdd, p.dt_vencimento, decode(IC_TIPO_LANCAMENTO,'P','Pagamento','B','Baixa','T','Tranferência Provisão') ds_grupo"
            SqlText = SqlText & "    FROM sof.pdd p,sof.fornecedor f,sof.filial fil,"
            SqlText = SqlText & "         sof.tipo_garantia tg,"
            SqlText = SqlText & "         (SELECT   a.sq_pdd,IC_TIPO_LANCAMENTO, SUM (a.vl_pago) vl_pago"
            SqlText = SqlText & "              FROM sof.pdd_pagamento a"
            SqlText = SqlText & "             WHERE nvl(a.dt_exclusao,sysdate+1) <= " & QuotedStr(Date_to_Oracle(dDataFinal))
            SqlText = SqlText & "             and a.dt_criacao between " & QuotedStr(Date_to_Oracle(dDataInicial)) & " and " & QuotedStr(Date_to_Oracle(dDataFinal))
            SqlText = SqlText & "          GROUP BY a.sq_pdd, IC_TIPO_LANCAMENTO) pag"
            SqlText = SqlText & "   WHERE p.cd_fornecedor = f.cd_fornecedor(+)"
            SqlText = SqlText & "     AND p.cd_filial_referencia = fil.cd_filial(+)"
            SqlText = SqlText & "     AND p.cd_tipo_garantia = tg.cd_tipo_garantia(+)"
            SqlText = SqlText & "     AND p.sq_pdd = pag.sq_pdd"

            SqlText = SqlText & SqlFiltro

            oData_Rel = DBQuery(SqlText)

            oRelatorio.Load(Application.StartupPath & "\RPT_PDD.rpt")

            oRelatorio.SetDataSource(oData_Rel)
            'oRelatorio.SetParameterValue("Filtro", sFiltro)
            oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

            crvMain.ReportSource = oRelatorio
        Catch ex As Exception
            Msg_Mensagem(ex.Message)
        End Try
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub
End Class