Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.UltraChart.Shared.Styles

Public Class frmFotografiaFornecedor
    Const cnt_GridRecebimentoMediaQualidade_Analise As Integer = 0
    Const cnt_GridRecebimentoMediaQualidade_Valor As Integer = 1

    Const cnt_GridRecebimentoUltimas_Data As Integer = 0
    Const cnt_GridRecebimentoUltimas_Fornecedor As Integer = 1
    Const cnt_GridRecebimentoUltimas_NF As Integer = 2
    Const cnt_GridRecebimentoUltimas_Quantidade As Integer = 3
    Const cnt_GridRecebimentoUltimas_Umidade As Integer = 4
    Const cnt_GridRecebimentoUltimas_Sujidade As Integer = 5
    Const cnt_GridRecebimentoUltimas_LocalEntrega As Integer = 6

    Const cnt_GridSacaria_TipoSacaria As Integer = 0
    Const cnt_GridSacaria_Qt_Sacos As Integer = 1

    Const cnt_GridBonus_Nome As Integer = 0
    Const cnt_GridBonus_Valor As Integer = 1

    Const cnt_GridContato_Data As Integer = 0
    Const cnt_GridContato_Usuario As Integer = 1
    Const cnt_GridContato_Tipo As Integer = 2

    Const cnt_GridRecuperacao_Data As Integer = 0
    Const cnt_GridRecuperacao_Tipo As Integer = 1
    Const cnt_GridRecuperacao_ValorNegociado As Integer = 2
    Const cnt_GridRecuperacao_ValorPago As Integer = 3
    Const cnt_GridRecuperacao_Saldo As Integer = 4

    Const cnt_GridPagamento_Data As Integer = 0
    Const cnt_GridPagamento_Fornecedor As Integer = 1
    Const cnt_GridPagamento_Valor As Integer = 2
    Const cnt_GridPagamento_FormaPagamento As Integer = 3
    Const cnt_GridPagamento_TipoPagamento As Integer = 4
    Const cnt_GridPagamento_descricao As Integer = 5

    Const cnt_GridContratoFixo_Contrato As Integer = 0
    Const cnt_GridContratoFixo_Data As Integer = 1
    Const cnt_GridContratoFixo_Vencimento As Integer = 2
    Const cnt_GridContratoFixo_ValorUnitario As Integer = 3
    Const cnt_GridContratoFixo_KilosContrato As Integer = 4
    Const cnt_GridContratoFixo_KilosAplicados As Integer = 5
    Const cnt_GridContratoFixo_KilosSaldo As Integer = 6
    Const cnt_GridContratoFixo_ValorPagoAberto As Integer = 7
    Const cnt_GridContratoFixo_Saldo As Integer = 8

    Const cnt_GridContratoPAF_Contrato As Integer = 0
    Const cnt_GridContratoPAF_Data As Integer = 1
    Const cnt_GridContratoPAF_DataFixacao As Integer = 2
    Const cnt_GridContratoPAF_KilosContrato As Integer = 3
    Const cnt_GridContratoPAF_KilosAplicados As Integer = 4
    Const cnt_GridContratoPAF_KilosSaldo As Integer = 5
    Const cnt_GridContratoPAF_ValorPagoAberto As Integer = 6
    Const cnt_GridContratoPAF_ValorJuros As Integer = 7
    Const cnt_GridContratoPAF_Saldo As Integer = 8

    Dim oDSRecebimentoMediaQualidade As New UltraWinDataSource.UltraDataSource
    Dim oDSRecebimentoUltimas As New UltraWinDataSource.UltraDataSource
    Dim oDSSacaria As New UltraWinDataSource.UltraDataSource
    Dim oDSContato As New UltraWinDataSource.UltraDataSource
    Dim oDSPagamentos As New UltraWinDataSource.UltraDataSource
    Dim oDSRecuperação As New UltraWinDataSource.UltraDataSource
    Dim oDSBonus As New UltraWinDataSource.UltraDataSource
    Dim oDSContratoFixo As New UltraWinDataSource.UltraDataSource
    Dim oDSContratoPAF As New UltraWinDataSource.UltraDataSource

    Private Sub frmFotografiaFornecedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        objChart_Formatar(grfRecebimentoQuantidade, ChartType.StackColumnChart, True)
        objChart_Formatar(grfRecuperacao, ChartType.BarChart, True)

        objGrid_Inicializar(grdRecebimentoQualidade, , oDSRecebimentoMediaQualidade, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdRecebimentoQualidade, "Análise", 120)
        objGrid_Coluna_Add(grdRecebimentoQualidade, "Valor", 80)

        objGrid_Inicializar(grdRecupercaoCredito, , oDSRecuperação)
        objGrid_Coluna_Add(grdRecupercaoCredito, "Data", 80)
        objGrid_Coluna_Add(grdRecupercaoCredito, "Modalidade", 150)
        objGrid_Coluna_Add(grdRecupercaoCredito, "Negociação", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdRecupercaoCredito, "Valor Pago", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdRecupercaoCredito, "Saldo", 80, , , , , cnt_Formato_Valor)

        objGrid_Inicializar(grdRecimentoUltimos, , oDSRecebimentoUltimas, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdRecimentoUltimos, "Data", 80)
        objGrid_Coluna_Add(grdRecimentoUltimos, "Fornecedor", 150)
        objGrid_Coluna_Add(grdRecimentoUltimos, "NF", 50)
        objGrid_Coluna_Add(grdRecimentoUltimos, "Quantidade", 90, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdRecimentoUltimos, "Umidade", 80)
        objGrid_Coluna_Add(grdRecimentoUltimos, "Sujidade", 90)
        objGrid_Coluna_Add(grdRecimentoUltimos, "Local Entrega", 100)

        objGrid_Inicializar(grdSacaria, , oDSSacaria)
        objGrid_Coluna_Add(grdSacaria, "Tipo de Sacaria", 140)
        objGrid_Coluna_Add(grdSacaria, "Qtde. de Sacos", 105)

        objGrid_Inicializar(grdBonus, , oDSBonus)
        objGrid_Coluna_Add(grdBonus, "Bônus", 140)
        objGrid_Coluna_Add(grdBonus, "Valor", 105, , , , , cnt_Formato_Valor)

        objGrid_Inicializar(grdContato, , oDSContato)
        objGrid_Coluna_Add(grdContato, "Data", 80)
        objGrid_Coluna_Add(grdContato, "Usuário", 140)
        objGrid_Coluna_Add(grdContato, "Tipo Contato", 140)

        objGrid_Inicializar(grdPagamentos, , oDSPagamentos)
        objGrid_Coluna_Add(grdPagamentos, "Data", 80)
        objGrid_Coluna_Add(grdPagamentos, "Fornecedor", 150)
        objGrid_Coluna_Add(grdPagamentos, "Valor", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdPagamentos, "Forma", 80)
        objGrid_Coluna_Add(grdPagamentos, "Tipo Pagamento", 120)
        objGrid_Coluna_Add(grdPagamentos, "Descrição", 300)

        objGrid_Inicializar(grdContratoFixo, , oDSContratoFixo)
        objGrid_Coluna_Add(grdContratoFixo, "Contrato", 100)
        objGrid_Coluna_Add(grdContratoFixo, "Emissão", 80, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdContratoFixo, "Vencimento", 90, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdContratoFixo, "Valor Unit", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoFixo, "Qt Contrato", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoFixo, "Qt Aplicado", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoFixo, "Qt Saldo", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoFixo, "Valor Pago", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoFixo, "Saldo", 80, , , , , cnt_Formato_Valor)

        objGrid_Inicializar(grdContratoPAF, , oDSContratoPAF)
        objGrid_Coluna_Add(grdContratoPAF, "Contrato", 100)
        objGrid_Coluna_Add(grdContratoPAF, "Emissão", 80, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdContratoPAF, "Prazo Fixação", 90, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdContratoPAF, "Qt Contrato", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoPAF, "Qt Aplicado", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoPAF, "Qt Saldo", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdContratoPAF, "Vl Pago Aberto", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoPAF, "Vl Juros", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdContratoPAF, "Saldo", 80, , , , , cnt_Formato_Valor)
    End Sub

    Private Sub ConsultaSaldoFornecedor()
        If Pesq_Fornecedor.Codigo <= 0 Then
            Msg_Mensagem("Favor selecionar um fornecedor valido.")
            Pesq_Fornecedor.Focus()
            Exit Sub
        End If

        Dim SqlText As String

        txtSaldo.Value = 0
        txtCacauAordem.Value = 0
        txtCreditoAprovado.Value = 0
        txtJuros.Value = 0
        txtAdiantamento.Value = 0
        txtRecuperacao.Value = 0

        SqlText = DBMontar_SP("SOF.SP_SALDO_FORNECEDOR", False, ":CDFORN", _
                                                                ":ICNEG", _
                                                                ":VLUNITARIO", _
                                                                ":ICFIXONEG", _
                                                                ":ICDOLARNEG", _
                                                                ":ICBOLSANEG", _
                                                                ":ICBOLSAOPERACAONEG", _
                                                                ":PCALIQINSS", _
                                                                ":VLSALDO", _
                                                                ":VLLCMOEDA", _
                                                                ":VLBOLSA", _
                                                                ":VLLIMITECREDITO", _
                                                                ":VLAORDEM", _
                                                                ":VLPAGAB", _
                                                                ":VLPRECOCACAU", _
                                                                ":QTAORDEM", _
                                                                ":VLJUROS", _
                                                                ":VLCONFDIV", _
                                                                ":VLICMSNFCOMP")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDFORN", Pesq_Fornecedor.Codigo), _
                                   DBParametro_Montar("ICNEG", "N"), _
                                   DBParametro_Montar("VLUNITARIO", 1), _
                                   DBParametro_Montar("ICFIXONEG", "N"), _
                                   DBParametro_Montar("ICDOLARNEG", "N"), _
                                   DBParametro_Montar("ICBOLSANEG", "N"), _
                                   DBParametro_Montar("ICBOLSAOPERACAONEG", ""), _
                                   DBParametro_Montar("PCALIQINSS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLSALDO", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLLCMOEDA", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLBOLSA", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLLIMITECREDITO", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLAORDEM", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLPAGAB", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLPRECOCACAU", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("QTAORDEM", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLCONFDIV", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLICMSNFCOMP", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        If DBTeveRetorno() Then
            txtSaldo.Value = CDbl(Val(DBRetorno(2)))
            txtCacauAordem.Value = DBRetorno(6)
            txtCreditoAprovado.Value = DBRetorno(5)
            txtJuros.Value = DBRetorno(10)
            txtAdiantamento.Value = CDbl(Val(DBRetorno(7))) + CDbl(Val(DBRetorno(12)))
            txtRecuperacao.Value = DBRetorno(11)
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub
    Private Sub RecebimentoMediaQualidade()
        Dim SqlText As String
        Dim oData As DataTable

        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT nvl( SUM (m.qt_kg_liquido_nf),0) quant, "
        SqlText = SqlText & "      nvl( SUM (m.qt_kg_liquido_nf * mq.qt_umidade),0) quantumidade, "
        SqlText = SqlText & "      nvl(  SUM (m.qt_kg_liquido_nf * mq.qt_fumaca),0) quantfumaca, "
        SqlText = SqlText & "      nvl(  SUM (m.qt_kg_liquido_nf * mq.pc_sujidade),0) quantsujidade "
        SqlText = SqlText & "  FROM sof.movimentacao m, sof.movimentacao_qualidade mq "
        SqlText = SqlText & " WHERE m.sq_movimentacao = mq.sq_movimentacao "
        SqlText = SqlText & " and m.cd_tipo_movimentacao in (select p.cd_tipo_movimentacao from sof.parametro_modalidade_tipo_mov p where p.cd_parametro_modalidade = 6)  "
        SqlText = SqlText & " AND m.cd_fornecedor=" & Pesq_Fornecedor.Codigo

        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(m.dt_movimentacao) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(m.dt_movimentacao) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        oData = DBQuery(SqlText)
        oDSRecebimentoMediaQualidade.Rows.Clear()

        If oData.Rows(0).Item("quant") <> 0 Then
            oDSRecebimentoMediaQualidade.Rows.Add()
            With oDSRecebimentoMediaQualidade.Rows(oDSRecebimentoMediaQualidade.Rows.Count - 1)
                .Item(cnt_GridRecebimentoMediaQualidade_Analise) = "Umidade"
                .Item(cnt_GridRecebimentoMediaQualidade_Valor) = Math.Round(oData.Rows(0).Item("quantumidade") / oData.Rows(0).Item("quant"), 2)
            End With
            oDSRecebimentoMediaQualidade.Rows.Add()
            With oDSRecebimentoMediaQualidade.Rows(oDSRecebimentoMediaQualidade.Rows.Count - 1)
                .Item(cnt_GridRecebimentoMediaQualidade_Analise) = "Sujidade"
                .Item(cnt_GridRecebimentoMediaQualidade_Valor) = Math.Round(oData.Rows(0).Item("quantsujidade") / oData.Rows(0).Item("quant"), 2)
            End With
            oDSRecebimentoMediaQualidade.Rows.Add()
            With oDSRecebimentoMediaQualidade.Rows(oDSRecebimentoMediaQualidade.Rows.Count - 1)
                .Item(cnt_GridRecebimentoMediaQualidade_Analise) = "Fumaça"
                .Item(cnt_GridRecebimentoMediaQualidade_Valor) = Math.Round(oData.Rows(0).Item("quantfumaca") / oData.Rows(0).Item("quant"), 2)
            End With
        End If
    End Sub

    Private Sub RecebimentoUltimos()
        Dim SqlText As String

        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT * "
        SqlText = SqlText & "  FROM (SELECT   m.dt_movimentacao, f.no_razao_social, m.nu_nf, "
        SqlText = SqlText & "                 m.qt_kg_liquido_nf, mq.qt_umidade, mq.pc_sujidade, "
        SqlText = SqlText & "                 le.no_local_entrega ||' - '|| fil.no_filial "
        SqlText = SqlText & "            FROM sof.movimentacao m, "
        SqlText = SqlText & "                 sof.movimentacao_qualidade mq, "
        SqlText = SqlText & "                 sof.tipo_cacau tc, "
        SqlText = SqlText & "                 sof.local_entrega le, "
        SqlText = SqlText & "                 sof.fornecedor f, "
        SqlText = SqlText & "                 sof.filial fil "
        SqlText = SqlText & "           WHERE m.sq_movimentacao = mq.sq_movimentacao "
        SqlText = SqlText & "             AND m.cd_local_entrega = le.cd_local_entrega "
        SqlText = SqlText & "             AND m.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "             AND m.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "             and m.cd_tipo_movimentacao in (select p.cd_tipo_movimentacao from sof.parametro_modalidade_tipo_mov p where p.cd_parametro_modalidade = 6) "
        SqlText = SqlText & "             AND m.cd_fornecedor=" & Pesq_Fornecedor.Codigo

        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(m.dt_movimentacao) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(m.dt_movimentacao) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        SqlText = SqlText & "        ORDER BY m.dt_movimentacao DESC) "
        SqlText = SqlText & " WHERE ROWNUM <= 5 "


        objGrid_Carregar(grdRecimentoUltimos, SqlText, New Integer() {cnt_GridRecebimentoUltimas_Data, _
                                                            cnt_GridRecebimentoUltimas_Fornecedor, _
                                                            cnt_GridRecebimentoUltimas_NF, _
                                                            cnt_GridRecebimentoUltimas_Quantidade, _
                                                            cnt_GridRecebimentoUltimas_Umidade, _
                                                            cnt_GridRecebimentoUltimas_Sujidade, _
                                                            cnt_GridRecebimentoUltimas_LocalEntrega})
    End Sub

    Private Sub RecebimentoQuantidade()
        Dim SqlText As String
        Dim oData As DataTable
        Dim iCont As Integer

        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT   DECODE (mq.ic_tipo_cacau, 1, 'I', 2, 'II', 3, 'III', 4, 'R', '') as tipo, "
        SqlText = SqlText & "    SUM (m.qt_kg_liquido_nf) quant     "
        SqlText = SqlText & "    FROM sof.movimentacao m, sof.movimentacao_qualidade mq "
        SqlText = SqlText & "   WHERE m.sq_movimentacao = mq.sq_movimentacao "
        SqlText = SqlText & " AND m.cd_fornecedor=" & Pesq_Fornecedor.Codigo
        SqlText = SqlText & "  and  m.cd_tipo_movimentacao in (select p.cd_tipo_movimentacao from sof.parametro_modalidade_tipo_mov p where p.cd_parametro_modalidade = 6) "


        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(m.dt_movimentacao) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(m.dt_movimentacao) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        SqlText = SqlText & "GROUP BY DECODE (mq.ic_tipo_cacau, 1, 'I', 2, 'II', 3, 'III', 4, 'R', '') "

        SqlText = "select * from (" & SqlText & ") order by tipo"

        oData = DBQuery(SqlText)

        txtQuantidadeRecebimento.Value = 0
        For icont = 0 To oData.Rows.Count - 1
            txtQuantidadeRecebimento.Value = txtQuantidadeRecebimento.Value + Math.Round(oData.Rows(iCont).Item("quant") / 60, 0)
        Next

        grfRecebimentoQuantidade.Hide()

        With grfRecebimentoQuantidade
            .DataSource = Nothing
            .DataSource = oData
            .ChartType = ChartType.PieChart
            .Data.SwapRowsAndColumns = False
        End With

        If Not objDataTable_Vazio(oData) Then
            grfRecebimentoQuantidade.Show()
        Else
            grfRecebimentoQuantidade.Hide()
        End If

    End Sub
    Private Sub GraficoRecuperacao()
        Dim SqlText As String
        Dim oData As DataTable
        Dim oDataChart As New DataTable

        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT  SUM (DECODE (cdp.ic_situacao, 'P', cda.vl_ativo, 0)) AS vl_pago, "
        SqlText = SqlText & "         SUM (DECODE (cdp.ic_situacao, 'A', cdp.vl_parcela, 0)) AS vl_saldo, "
        SqlText = SqlText & "         SUM (DECODE (SIGN (cdp.dt_vencimento - SYSDATE), "
        SqlText = SqlText & "                      -1, (DECODE (cdp.ic_situacao, 'A', cdp.vl_parcela, 0)), "
        SqlText = SqlText & "                      0 "
        SqlText = SqlText & "                     ) "
        SqlText = SqlText & "             ) AS vl_atrasado "
        SqlText = SqlText & "    FROM sof.confissao_divida_parcela cdp, "
        SqlText = SqlText & "         sof.confissao_divida cd, "
        SqlText = SqlText & "         sof.confissao_divida_ativo cda, "
        SqlText = SqlText & "         sof.confissao_divida_modalidade cdm "
        SqlText = SqlText & "   WHERE cd.sq_confissao_divida = cdp.sq_confissao_divida(+) "
        SqlText = SqlText & "     AND cd.cd_confissao_divida_modalidade = "
        SqlText = SqlText & "                                            cdm.cd_confissao_divida_modalidade "
        SqlText = SqlText & "     AND cdp.sq_confissao_divida = cda.sq_confissao_divida(+) "
        SqlText = SqlText & "     AND cdp.nu_parcela = cda.nu_parcela(+) "
        SqlText = SqlText & "     AND cd.ic_status = 'A' "
        SqlText = SqlText & "     AND cd.cd_fornecedor =" & Pesq_Fornecedor.Codigo
        SqlText = SqlText & "GROUP BY cd.dt_confissao_divida, "
        SqlText = SqlText & "         cdm.no_confissao_divida_modalidade, "
        SqlText = SqlText & "         cd.vl_negociado "

        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then Exit Sub

        Dim iCont As Integer
        Dim oRow As DataRow

        With oDataChart.Columns
            .Add("nome").DataType = System.Type.GetType("System.String")
            .Add("valor").DataType = System.Type.GetType("System.Int32")
        End With

        oRow = oDataChart.NewRow
        oRow.Item("nome") = "Pago"
        oRow.Item("valor") = oData.Rows(iCont).Item("vl_pago")
        If Not oRow Is Nothing Then oDataChart.Rows.Add(oRow)

        oRow = oDataChart.NewRow
        oRow.Item("nome") = "Aberto"
        oRow.Item("valor") = oData.Rows(iCont).Item("vl_saldo")
        If Not oRow Is Nothing Then oDataChart.Rows.Add(oRow)

        oRow = oDataChart.NewRow
        oRow.Item("nome") = "Atrasado"
        oRow.Item("valor") = oData.Rows(iCont).Item("vl_atrasado")
        If Not oRow Is Nothing Then oDataChart.Rows.Add(oRow)

        grfRecuperacao.Hide()

        With grfRecuperacao
            .DataSource = Nothing
            .DataSource = oDataChart
            '.ChartType = ChartType.PieChart
            .Data.SwapRowsAndColumns = True
        End With

        If objDataTable_Vazio(oDataChart) Then
            Msg_Mensagem("Essa consulta não retornou nenhum registro")
        Else
            grfRecuperacao.Show()
        End If

    End Sub

    Private Sub ConsultaSacaria()
        Dim SqlText As String

        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT TS.NO_TIPO_SACARIA," & _
                         "NVL(SUM(DECODE(SF.IC_ENTRADA_SAIDA, 'S', -SF.QT_SACOS, SF.QT_SACOS)),0) AS QT_SACOS" & _
                  " FROM SOF.SACARIA_FORNECEDOR SF," & _
                        "SOF.TIPO_SACARIA TS," & _
                        "SOF.FORNECEDOR FN" & _
                  " WHERE SF.CD_TIPO_SACARIA = TS.CD_TIPO_SACARIA" & _
                    " AND TS.IC_CONTABILIZA_FORNECEDOR = 'S'" & _
                    " AND FN.CD_FORNECEDOR = SF.CD_FORNECEDOR" & _
                    " AND FN.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & _
                  " GROUP BY TS.NO_TIPO_SACARIA"

        objGrid_Carregar(grdSacaria, SqlText, New Integer() {cnt_GridSacaria_TipoSacaria, _
                                                           cnt_GridSacaria_Qt_Sacos})

        objGrid_ExibirTotal(grdSacaria, cnt_GridSacaria_Qt_Sacos)
    End Sub


    Private Sub ConsultaContratoFixo()
        Dim SqlText As String

        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT    cf.cd_contrato_paf "
        SqlText = SqlText & "       || '-' "
        SqlText = SqlText & "       || cf.sq_negociacao "
        SqlText = SqlText & "       || '-' "
        SqlText = SqlText & "       || cf.sq_contrato_fixo AS contrato, "
        SqlText = SqlText & "        cf.dt_contrato_fixo , cf.dt_vencimento,  cf.vl_unitario ,cf.qt_kgs, "
        SqlText = SqlText & "       cf.qt_kg_fixo, "
        SqlText = SqlText & "       cf.qt_kgs - cf.QT_CANCELADO - cf.qt_kg_fixo AS qt_saldo, "
        SqlText = SqlText & "       cf.vl_pag_fixo vl_pag_ab,  "
        SqlText = SqlText & "         DECODE (cf.qt_kgs - cf.qt_cancelado, "
        SqlText = SqlText & "                 0, 0, "
        SqlText = SqlText & "                 ROUND (  cf.qt_kg_fixo "
        SqlText = SqlText & "                        * (  sof.fc_saldo_ctr_fix (cf.cd_contrato_paf, "
        SqlText = SqlText & "                                                   cf.sq_negociacao, "
        SqlText = SqlText & "                                                   cf.sq_contrato_fixo "
        SqlText = SqlText & "                                                  ) "
        SqlText = SqlText & "                           / (cf.qt_kgs - cf.qt_cancelado) "
        SqlText = SqlText & "                          ), "
        SqlText = SqlText & "                        2 "
        SqlText = SqlText & "                       ) "
        SqlText = SqlText & "                ) "
        SqlText = SqlText & "       - cf.vl_pag_fixo saldo "
        SqlText = SqlText & "  FROM sof.filial fil, "
        SqlText = SqlText & "       sof.fornecedor f, "
        SqlText = SqlText & "       sof.fornecedor rep, "
        SqlText = SqlText & "       sof.contrato_paf cp, "
        SqlText = SqlText & "       sof.contrato_fixo cf, "
        SqlText = SqlText & "       sof.funrural fun "
        SqlText = SqlText & " WHERE cf.cd_contrato_paf = cp.cd_contrato_paf "
        SqlText = SqlText & "   AND cp.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "   AND cp.cd_repassador = rep.cd_fornecedor "
        SqlText = SqlText & "   AND rep.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "   AND f.cd_funrural = fun.cd_funrural "
        SqlText = SqlText & "   AND cf.ic_status = 'A' "
        SqlText = SqlText & "   AND cp.cd_fornecedor =  " & Pesq_Fornecedor.Codigo
        SqlText = SqlText & "  order by cf.dt_contrato_fixo "

        objGrid_Carregar(grdContratoFixo, SqlText, New Integer() {cnt_GridContratoFixo_Contrato, _
                                                             cnt_GridContratoFixo_Data, _
                                                             cnt_GridContratoFixo_Vencimento, _
                                                             cnt_GridContratoFixo_ValorUnitario, _
                                                             cnt_GridContratoFixo_KilosContrato, _
                                                             cnt_GridContratoFixo_KilosAplicados, _
                                                             cnt_GridContratoFixo_KilosSaldo, _
                                                             cnt_GridContratoFixo_ValorPagoAberto, _
                                                             cnt_GridContratoFixo_Saldo})

        objGrid_ExibirTotal(grdContratoFixo, cnt_GridContratoFixo_KilosSaldo, _
                                        cnt_GridContratoFixo_ValorPagoAberto, _
                                        cnt_GridContratoFixo_Saldo)
    End Sub

    Private Sub ConsultaContratoPAF()
        Dim SqlText As String
        Dim VlCompra As Double
        Dim DtCotacao As Date

    
        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT MAX(LCM.DT_COTACAO) DT_COTACAO" & _
              " FROM SOF.LIMITE_CREDITO_MOEDA LCM " & _
              " WHERE LCM.DT_COTACAO <= TO_DATE('" & Date_to_Oracle(DataSistema) & "')"
        DtCotacao = DBQuery_ValorUnico(SqlText)

        SqlText = "SELECT PC.VL_PRECO" & _
             " FROM SOF.PRECO_CACAU PC" & _
             " WHERE PC.DT_COTACAO = TO_DATE('" & Date_to_Oracle(DtCotacao) & "')"
        VlCompra = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT cp.cd_contrato_paf, cp.dt_contrato_paf, cp.dt_prazo_fixacao, cp.qt_kgs, "
        SqlText = SqlText & "       cp.qt_kg_fixo, cp.qt_kgs - cp.qt_kg_fixo - cp.qt_cancelado qt_saldo, "
        SqlText = SqlText & "       NVL (p.vl_pag_ab, 0) vl_pag_ab, "
        SqlText = SqlText & "       ROUND (NVL (p.vl_pag_ab_juros, 0), 2) - NVL (p.vl_pag_ab, 0) vl_juros, "
        SqlText = SqlText & "         NVL (cm.vl_qt_a_fixar, 0) "
        SqlText = SqlText & "       - ROUND (NVL (p.vl_pag_ab_juros, 0), 2) AS saldo "
        SqlText = SqlText & "  FROM sof.contrato_paf cp, "
        SqlText = SqlText & "       sof.tipo_contrato_paf tcp, "
        SqlText = SqlText & "       sof.fornecedor f, "
        SqlText = SqlText & "       sof.fornecedor rep, "
        SqlText = SqlText & "       sof.filial fil, "
        SqlText = SqlText & "       (SELECT   SUM "
        SqlText = SqlText & "                    (DECODE "
        SqlText = SqlText & "                        (cp.ic_calcula_juros || tp.ic_calcula_juros, "
        SqlText = SqlText & "                         'SS', (  (  DECODE "
        SqlText = SqlText & "                                        (SIGN "
        SqlText = SqlText & "                                            (  (  TO_DATE "
        SqlText = SqlText & "                                                     ('" & Date_to_Oracle(DataSistema) & "' "
        SqlText = SqlText & "                                                     ) "
        SqlText = SqlText & "                                                - p.dt_pagamento "
        SqlText = SqlText & "                                               ) "
        SqlText = SqlText & "                                             - NVL (cp.qt_dia_carencia_juros, "
        SqlText = SqlText & "                                                    0 "
        SqlText = SqlText & "                                                   ) "
        SqlText = SqlText & "                                            ), "
        SqlText = SqlText & "                                         -1, 0, "
        SqlText = SqlText & "                                         ROUND "
        SqlText = SqlText & "                                            ((  (  TO_DATE "
        SqlText = SqlText & "                                                      ('" & Date_to_Oracle(DataSistema) & "' "
        SqlText = SqlText & "                                                      ) "
        SqlText = SqlText & "                                                 - TO_DATE (p.dt_pagamento) "
        SqlText = SqlText & "                                                ) "
        SqlText = SqlText & "                                              - DECODE "
        SqlText = SqlText & "                                                   (NVL "
        SqlText = SqlText & "                                                       (cp.ic_juros_apos_carencia, "
        SqlText = SqlText & "                                                        'N' "
        SqlText = SqlText & "                                                       ), "
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
        SqlText = SqlText & "                                   * ((NVL (cp.pc_taxa_juros, 0) / 100) / 30) "
        SqlText = SqlText & "                                  ) "
        SqlText = SqlText & "                                * pcp.vl_a_fixar "
        SqlText = SqlText & "                             ) "
        SqlText = SqlText & "                          + pcp.vl_a_fixar, "
        SqlText = SqlText & "                         pcp.vl_a_fixar "
        SqlText = SqlText & "                        ) "
        SqlText = SqlText & "                    ) vl_pag_ab_juros, "
        SqlText = SqlText & "                 NVL (SUM (pcp.vl_a_fixar), 0) vl_pag_ab, cp.cd_contrato_paf "
        SqlText = SqlText & "            FROM sof.pag_ctr_paf pcp, "
        SqlText = SqlText & "                 sof.pagamentos p, "
        SqlText = SqlText & "                 sof.contrato_paf cp, "
        SqlText = SqlText & "                 sof.tipo_pagamento tp "
        SqlText = SqlText & "           WHERE pcp.cd_contrato_paf = cp.cd_contrato_paf "
        SqlText = SqlText & "             AND pcp.sq_pagamento = p.sq_pagamento "
        SqlText = SqlText & "             AND pcp.vl_a_fixar <> 0 "
        SqlText = SqlText & "             AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
        SqlText = SqlText & "             AND cp.cd_fornecedor = " & Pesq_Fornecedor.Codigo
        SqlText = SqlText & "        GROUP BY cp.cd_contrato_paf) p, "
        SqlText = SqlText & "       (SELECT   cm.cd_contrato_paf, SUM (cm.qt_kg_a_fixar) qt_kg_a_fixar, "
        SqlText = SqlText & "                 SUM (cm.vl_a_fixar) vl_nf_a_fixar, "
        SqlText = SqlText & "                 SUM (DECODE (m.vl_nf, "
        SqlText = SqlText & "                              0, 0, "
        SqlText = SqlText & "                              ROUND (  (  (cm.qt_kg_a_fixar * " & ConvValorFormatoAmericano(VlCompra) & " / 15) "
        SqlText = SqlText & "                                        / (  1 "
        SqlText = SqlText & "                                           - (  (m.vl_nf_icms / m.vl_nf) "
        SqlText = SqlText & "                                              + (fun.vl_taxa / 100) "
        SqlText = SqlText & "                                             ) "
        SqlText = SqlText & "                                          ) "
        SqlText = SqlText & "                                       ) "
        SqlText = SqlText & "                                     * (1 - (fun.vl_taxa / 100)), "
        SqlText = SqlText & "                                     2 "
        SqlText = SqlText & "                                    ) "
        SqlText = SqlText & "                             ) "
        SqlText = SqlText & "                     ) vl_qt_a_fixar "
        SqlText = SqlText & "            FROM sof.ctr_paf_movimentacao cm, "
        SqlText = SqlText & "                 sof.contrato_paf cp, "
        SqlText = SqlText & "                 sof.movimentacao m, "
        SqlText = SqlText & "                 sof.fornecedor f, "
        SqlText = SqlText & "                 sof.funrural fun "
        SqlText = SqlText & "           WHERE (cm.qt_kg_a_fixar <> 0 OR cm.vl_a_fixar <> 0) "
        SqlText = SqlText & "             AND cm.cd_contrato_paf = cp.cd_contrato_paf "
        SqlText = SqlText & "             AND cm.sq_movimentacao = m.sq_movimentacao "
        SqlText = SqlText & "             AND cp.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "             AND f.cd_funrural = fun.cd_funrural "
        SqlText = SqlText & "             AND cp.cd_fornecedor = " & Pesq_Fornecedor.Codigo
        SqlText = SqlText & "        GROUP BY cm.cd_contrato_paf) cm "
        SqlText = SqlText & " WHERE cp.cd_tipo_contrato_paf = tcp.cd_tipo_contrato_paf "
        SqlText = SqlText & "   AND cp.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "   AND cp.cd_repassador = rep.cd_fornecedor "
        SqlText = SqlText & "   AND rep.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "   AND cp.cd_contrato_paf = p.cd_contrato_paf(+) "
        SqlText = SqlText & "   AND cp.cd_contrato_paf = cm.cd_contrato_paf(+) "
        SqlText = SqlText & "   AND cp.ic_status = 'A' "
        SqlText = SqlText & "   AND cp.cd_fornecedor = " & Pesq_Fornecedor.Codigo
        SqlText = SqlText & "   AND tcp.ic_adiantamento = 'S' "
        SqlText = SqlText & "  order by cp.dt_contrato_paf "


        objGrid_Carregar(grdContratoPAF, SqlText, New Integer() {cnt_GridContratoPAF_Contrato, _
                                                                    cnt_GridContratoPAF_Data, _
                                                                    cnt_GridContratoPAF_DataFixacao, _
                                                                    cnt_GridContratoPAF_KilosContrato, _
                                                                    cnt_GridContratoPAF_KilosAplicados, _
                                                                    cnt_GridContratoPAF_KilosSaldo, _
                                                                    cnt_GridContratoPAF_ValorPagoAberto, _
                                                                    cnt_GridContratoPAF_ValorJuros, _
                                                                    cnt_GridContratoPAF_Saldo})

        objGrid_ExibirTotal(grdContratoPAF, cnt_GridContratoPAF_KilosSaldo, _
                                        cnt_GridContratoPAF_ValorPagoAberto, _
                                        cnt_GridContratoPAF_ValorJuros, _
                                        cnt_GridContratoPAF_Saldo)
    End Sub

    Private Sub ConsultaContato()
        Dim SqlText As String

        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT * "
        SqlText = SqlText & "  FROM (SELECT   a.dt_atendimento, u.no_usuario, ta.no_tipo_atendimento "
        SqlText = SqlText & "            FROM sof.atendimento a, sof.tipo_atendimento ta, sof.usuario u "
        SqlText = SqlText & "           WHERE a.cd_tipo_atendimento = ta.cd_tipo_atendimento "
        SqlText = SqlText & "             AND a.cd_user = u.cd_user "
        SqlText = SqlText & "             and a.cd_fornecedor = " & Pesq_Fornecedor.Codigo
        SqlText = SqlText & "        ORDER BY a.dt_atendimento DESC) "
        SqlText = SqlText & " WHERE ROWNUM <= 5 "

        objGrid_Carregar(grdContato, SqlText, New Integer() {cnt_GridContato_Data, _
                                                           cnt_GridContato_Usuario, _
                                                           cnt_GridContato_Tipo})

    End Sub

    Private Sub ConsultaBonus()
        Dim SqlText As String

        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT bp.no_bonus_padrao, "
        SqlText = SqlText & "       sum(round(ABS (bcf.vl_unitario_bonus / bcf.qt_fator_bonus) * cm.qt_kg_fixo,2)) "
        SqlText = SqlText & "  FROM sof.bonus_contrato_fixo bcf, "
        SqlText = SqlText & "       sof.bonus_padrao bp, "
        SqlText = SqlText & "       sof.ctr_paf_neg_ctr_fix_mov cm, "
        SqlText = SqlText & "       sof.contrato_paf cp "
        SqlText = SqlText & " WHERE bp.cd_bonus_padrao = bcf.cd_bonus_padrao "
        SqlText = SqlText & "   AND cm.sq_movimentacao = bcf.sq_movimentacao "
        SqlText = SqlText & "   AND cm.sq_movimentacao_cessao_direito = bcf.sq_movimentacao_cessao_direito "
        SqlText = SqlText & "   AND cm.cd_contrato_paf = bcf.cd_contrato_paf "
        SqlText = SqlText & "   AND cm.sq_ctr_paf_movimentacao = bcf.sq_ctr_paf_movimentacao "
        SqlText = SqlText & "   AND cm.sq_negociacao = bcf.sq_negociacao "
        SqlText = SqlText & "   AND cm.sq_ctr_paf_neg_movimentacao = bcf.sq_ctr_paf_neg_movimentacao "
        SqlText = SqlText & "   AND cm.sq_contrato_fixo = bcf.sq_contrato_fixo "
        SqlText = SqlText & "   AND cm.sq_ctr_paf_neg_ctr_fix_mov = bcf.sq_ctr_paf_neg_ctr_fix_mov "
        SqlText = SqlText & "   AND cp.cd_contrato_paf = cm.cd_contrato_paf "
        SqlText = SqlText & "   AND bcf.ic_pago = 'N' "
        SqlText = SqlText & "   and cp.cd_fornecedor =" & Pesq_Fornecedor.Codigo
        SqlText = SqlText & "   group by bp.no_bonus_padrao "

        objGrid_Carregar(grdBonus, SqlText, New Integer() {cnt_GridBonus_Nome, _
                                                           cnt_GridBonus_Valor})

    End Sub

    Private Sub ConsultaRecuperacao()
        Dim SqlText As String

        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT   cd.dt_confissao_divida,  cdm.no_confissao_divida_modalidade,  "
        SqlText = SqlText & "         cd.vl_negociado,  "
        SqlText = SqlText & "         SUM (DECODE (cdp.ic_situacao, 'P', cda.vl_ativo, 0)) AS vl_pago, "
        SqlText = SqlText & "         SUM (DECODE (cdp.ic_situacao, 'A', cdp.vl_parcela, 0)) AS vl_saldo "
        SqlText = SqlText & "    FROM sof.confissao_divida_parcela cdp, "
        SqlText = SqlText & "         sof.confissao_divida cd, "
        SqlText = SqlText & "         sof.confissao_divida_ativo cda, "
        SqlText = SqlText & "         sof.confissao_divida_modalidade cdm "
        SqlText = SqlText & "   WHERE cd.sq_confissao_divida = cdp.sq_confissao_divida(+) "
        SqlText = SqlText & "     AND cd.cd_confissao_divida_modalidade = "
        SqlText = SqlText & "                                            cdm.cd_confissao_divida_modalidade "
        SqlText = SqlText & "     AND cdp.sq_confissao_divida = cda.sq_confissao_divida(+) "
        SqlText = SqlText & "     AND cdp.nu_parcela = cda.nu_parcela(+) "
        SqlText = SqlText & "     AND cd.ic_status = 'A' "
        SqlText = SqlText & "     and cd.cd_fornecedor  = " & Pesq_Fornecedor.Codigo
        SqlText = SqlText & "GROUP BY cd.dt_confissao_divida,  cdm.no_confissao_divida_modalidade,  "
        SqlText = SqlText & "         cd.vl_negociado "


        objGrid_Carregar(grdRecupercaoCredito, SqlText, New Integer() {cnt_GridRecuperacao_Data, _
                                                           cnt_GridRecuperacao_Tipo, _
                                                           cnt_GridRecuperacao_ValorNegociado, _
                                                           cnt_GridRecuperacao_ValorPago, _
                                                           cnt_GridRecuperacao_Saldo})

        objGrid_ExibirTotal(grdRecupercaoCredito, cnt_GridRecuperacao_ValorNegociado, _
                                        cnt_GridRecuperacao_ValorPago, _
                                        cnt_GridRecuperacao_Saldo)


    End Sub

    Private Sub ConsultaPagamentos()
        Dim SqlText As String

        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT * "
        SqlText = SqlText & "  FROM (SELECT   p.dt_pagamento, f.no_razao_social, p.vl_pagamento, "
        SqlText = SqlText & "                 fp.no_forma_pagamento, tp.no_tipo_pagamento, p.ds_descricao "
        SqlText = SqlText & "            FROM sof.pagamentos p, "
        SqlText = SqlText & "                 sof.tipo_pagamento tp, "
        SqlText = SqlText & "                 sof.forma_pagamento fp, "
        SqlText = SqlText & "                 sof.fornecedor f "
        SqlText = SqlText & "           WHERE p.cd_forma_pagamento = fp.cd_forma_pagamento "
        SqlText = SqlText & "             AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
        SqlText = SqlText & "             AND p.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "             and p.cd_fornecedor = " & Pesq_Fornecedor.Codigo
        SqlText = SqlText & "        ORDER BY p.dt_pagamento desc) "
        SqlText = SqlText & " WHERE ROWNUM <= 10 "


        objGrid_Carregar(grdPagamentos, SqlText, New Integer() {cnt_GridPagamento_Data, _
                                                           cnt_GridPagamento_Fornecedor, _
                                                           cnt_GridPagamento_Valor, _
                                                           cnt_GridPagamento_FormaPagamento, _
                                                           cnt_GridPagamento_TipoPagamento, _
                                                           cnt_GridPagamento_descricao})

    End Sub

    Private Sub ConsultaAOrdem()
        Dim SqlText As String
        Dim iCont As Integer
        Dim oData As DataTable
        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        txtPostoFazenda.Value = 0
        txtPostoFilial.Value = 0
        txtPostoFabrica.Value = 0

        SqlText = "SELECT NVL(SUM(CPM.QT_KG_A_FIXAR),0) AS QT, nvl(m.CD_LOCAL_ENTREGA,3) CD_LOCAL_ENTREGA " & _
                    "FROM SOF.CTR_PAF_MOVIMENTACAO CPM, SOF.CONTRATO_PAF CP, SOF.Movimentacao m " & _
                    "WHERE CP.CD_CONTRATO_PAF = CPM.CD_CONTRATO_PAF AND " & _
                    "M.SQ_MOVIMENTACAO = CPM.SQ_MOVIMENTACAO AND " & _
                    "CP.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & " AND " & _
                    "CPM.QT_KG_A_FIXAR <> 0 " & _
                    "GROUP BY NVL(m.cd_local_entrega, 3)"

        odata = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            Select Case oData.Rows(iCont).Item("CD_LOCAL_ENTREGA")
                Case 1
                    txtPostoFazenda.Value = oData.Rows(iCont).Item("QT")
                Case 2
                    txtPostoFilial.Value = oData.Rows(iCont).Item("QT")
                Case 3
                    txtPostoFabrica.Value = oData.Rows(iCont).Item("QT")
            End Select
        Next

        txtCtrPAFCacauAB.Value = txtPostoFazenda.Value + txtPostoFilial.Value + txtPostoFabrica.Value

    End Sub
    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click

        If Not IsDate(txtDataInicial.Value) Or Not IsDate(txtDataFinal.Value) Then
            txtDataInicial.Value = DateAdd(DateInterval.Month, -6, Today)
            txtDataFinal.Value = Today
        End If
        If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub

        If Pesq_Fornecedor.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um fornedor.")
            Exit Sub
        End If
        RecebimentoMediaQualidade()
        RecebimentoQuantidade()
        RecebimentoUltimos()
        ConsultaSacaria()
        ConsultaContato()
        ConsultaPagamentos()
        ConsultaRecuperacao()
        GraficoRecuperacao()
        ConsultaBonus()
        ConsultaSaldoFornecedor()
        ConsultaContratoFixo()
        ConsultaAOrdem()
        ConsultaContratoPAF()
        ConsultaResumo()
    End Sub

    Private Sub ConsultaResumo()
        Dim SqlText As String
        Dim oData As DataTable
        Dim strDtHoje As String

        strDtHoje = Date_to_Oracle(DataSistema)

        SqlText = "select nvl(sum(decode(greatest(cp.dt_vencimento,to_date('09-OCT-2002')),cp.dt_vencimento,cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo ,0)),0) qt_a_venc, " & _
          "nvl(sum(decode(greatest(cp.dt_vencimento,to_date('09-OCT-2002')),cp.dt_vencimento,0,cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo )),0) qt_venc, " & _
          "nvl(sum(cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo),0) qt_ab, " & _
          "nvl(Sum(cp.qt_a_negociar),0) qt_a_neg, " & _
          "nvl(sum(cp.qt_kgs - cp.qt_cancelado),0) qt_total " & _
          "from sof.contrato_paf cp " & _
          "where cp.cd_fornecedor = " & Pesq_Fornecedor.Codigo & " and " & _
          "cp.ic_status = 'A'"

        oData = DBQuery(SqlText)

        txtCtrPAFVenc.Value = oData.Rows(0).Item("qt_venc")
        txtCtrPAFAVenc.Value = oData.Rows(0).Item("qt_a_venc")
        txtCtrPAFAb.Value = oData.Rows(0).Item("qt_ab")
        txtCtrPAFANeg.Value = oData.Rows(0).Item("qt_a_neg")
        txtCtrPAFTotal.Value = oData.Rows(0).Item("qt_total")


        SqlText = "SELECT NVL(SUM(PCP.VL_A_FIXAR),0) VL_TOTAL " & _
                  "FROM SOF.PAG_CTR_PAF PCP, SOF.CONTRATO_PAF CP " & _
                  "WHERE CP.CD_CONTRATO_PAF = PCP.CD_CONTRATO_PAF AND " & _
                  "CP.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & " AND " & _
                  "PCP.vl_a_fixar <> 0"

        oData = DBQuery(SqlText)

        txtCtrPAFVlAb.Value = oData.Rows(0).Item("VL_TOTAL") * -1

        SqlText = "SELECT nvl(SUM(DECODE(GREATEST(N.DT_VENCIMENTO,TO_DATE('" & strDtHoje & "')),N.DT_VENCIMENTO,N.QT_KGS - N.QT_KG_FIXO - N.QT_CANCELADO ,0)),0) QT_A_VENC, " & _
                  "nvl(SUM(DECODE(GREATEST(N.DT_VENCIMENTO,TO_DATE('" & strDtHoje & "')),N.DT_VENCIMENTO,0,N.QT_KGS - N.QT_KG_FIXO - N.QT_CANCELADO )),0) QT_VENC, " & _
                  "nvl(SUM(N.QT_KGS - N.QT_KG_FIXO - N.QT_CANCELADO),0) QT_AB, nvl(SUM(N.QT_A_FIXAR),0) QT_A_FIX " & _
                  "FROM SOF.NEGOCIACAO N, SOF.CONTRATO_PAF CP " & _
                  "WHERE N.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF AND " & _
                  "CP.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & " AND " & _
                  "N.IC_STATUS = 'A'"

        oData = DBQuery(SqlText)

        txtNegVenc.Value = oData.Rows(0).Item("qt_venc")
        txtNegAVenc.Value = oData.Rows(0).Item("qt_a_venc")
        txtNegAb.Value = oData.Rows(0).Item("qt_ab")
        txtNegACtrFix.Value = oData.Rows(0).Item("qt_a_fix")

        SqlText = "SELECT nvl(SUM(PN.vl_a_fixar),0) VL_A_FIXAR " & _
                  "FROM SOF.PAG_NEG PN " & _
                  "WHERE PN.cd_contrato_paf IN (SELECT CD_CONTRATO_PAF FROM SOF.CONTRATO_PAF " & _
                  "WHERE CD_FORNECEDOR=" & Pesq_Fornecedor.Codigo & ") AND " & _
                  "PN.VL_A_FIXAR <> 0"

        oData = DBQuery(SqlText)

        txtNegVlAB.Value = oData.Rows(0).Item("vl_a_fixar") * -1

        SqlText = "SELECT nvl(SUM(cpnm.qt_kg_a_fixar),0) qt_kg_A_FIXAR " & _
                  "FROM SOF.CTR_PAF_NEG_MOVIMENTACAO cpnm " & _
                  "WHERE cpnm.cd_contrato_paf IN (SELECT CD_CONTRATO_PAF FROM SOF.CONTRATO_PAF " & _
                  "WHERE CD_FORNECEDOR=" & Pesq_Fornecedor.Codigo & ") AND " & _
                  "cpnm.qt_kg_a_fixar <> 0"

        oData = DBQuery(SqlText)

        txtNegCacauAB.Value = oData.Rows(0).Item("qt_kg_a_fixar")

        SqlText = "SELECT NVL(SUM(DECODE(GREATEST(CF.DT_VENCIMENTO,TO_DATE('" & strDtHoje & "')),CF.DT_VENCIMENTO,CF.QT_KGS - CF.QT_KG_FIXO - CF.QT_CANCELADO,0)),0) QT_A_VENC, " & _
                  "NVL(SUM(DECODE(GREATEST(CF.DT_VENCIMENTO,TO_DATE('" & strDtHoje & "')),CF.DT_VENCIMENTO,0,CF.QT_KGS - CF.QT_KG_FIXO - CF.QT_CANCELADO )),0) QT_VENC, " & _
                  "NVL(SUM(CF.QT_KGS - CF.QT_KG_FIXO - CF.QT_CANCELADO),0) QT_AB, " & _
                  "NVL(SUM(DECODE(GREATEST(CF.DT_VENCIMENTO,TO_DATE('" & strDtHoje & "')),CF.DT_VENCIMENTO, sof.fc_saldo_ctr_fix(cf.cd_contrato_paf ,cf.sq_negociacao ,cf.sq_contrato_fixo ) - CF.VL_PAG_FIXO ,0)),0) VL_A_VENC, " & _
                  "NVL(SUM(DECODE(GREATEST(CF.DT_VENCIMENTO,TO_DATE('" & strDtHoje & "')),CF.DT_VENCIMENTO,0, sof.fc_saldo_ctr_fix(cf.cd_contrato_paf ,cf.sq_negociacao ,cf.sq_contrato_fixo ) - CF.VL_PAG_FIXO )),0) VL_VENC, " & _
                  "round(NVL (SUM (  ((cf.qt_kg_fixo / tu.qt_fator) * (cf.vl_unitario  + (cf.vl_adendo  /((cf.qt_kgs-cf.qt_cancelado )/tu.qt_fator )))   ) " & _
                  "                 - cf.vl_pag_fixo ),0),2) vl_ab  " & _
                  "FROM SOF.CONTRATO_FIXO CF, SOF.CONTRATO_PAF CP, sof.tipo_unidade TU " & _
                  "WHERE CF.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF AND " & _
                  " cf.cd_tipo_unidade =tu.cd_tipo_unidade AND " & _
                  "CP.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & " AND " & _
                  "CF.IC_STATUS = 'A' "

        oData = DBQuery(SqlText)

        txtCtrFixQtVenc.Value = oData.Rows(0).Item("QT_VENC")
        txtCtrFixQtAVenc.Value = oData.Rows(0).Item("QT_A_VENC")
        txtCtrFixQtAb.Value = oData.Rows(0).Item("QT_AB")
        'txtCtrFixVlVenc.Value = oData.Rows(0).Item("VL_VENC")
        'txtCtrFixVlAVenc.Value = oData.Rows(0).Item("VL_A_VENC")
        txtCtrFixVlAb.Value = oData.Rows(0).Item("VL_AB")
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
End Class