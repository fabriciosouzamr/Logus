Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroConciliacao
    Const cnt_GridPagCons_DataPagamento As Integer = 0
    Const cnt_GridPagCons_DataAplicacao As Integer = 1
    Const cnt_GridPagCons_Descricao As Integer = 2
    Const cnt_GridPagCons_ValorAplicado As Integer = 3
    Const cnt_GridPagCons_TipoPagamento As Integer = 4
    Const cnt_GridPagCons_SqConciliacao As Integer = 5
    Const cnt_GridPagCons_SqPagamento As Integer = 6
    Const cnt_GridPagCons_SqPagamentoConciliacao As Integer = 7
    Const cnt_GridPagCons_SqConfissaoDivida As Integer = 8

    Const cnt_GridPagCad_Selecao As Integer = 0
    Const cnt_GridPagCad_ValorAplicado As Integer = 1
    Const cnt_GridPagCad_Valor_A_Aplicar As Integer = 2
    Const cnt_GridPagCad_DataPagamento As Integer = 3
    Const cnt_GridPagCad_TipoPagamento As Integer = 4
    Const cnt_GridPagCad_SqPagamento As Integer = 5

    Const cnt_GridMovCons_DataMovimentacao As Integer = 0
    Const cnt_GridMovCons_DataAplicacao As Integer = 1
    Const cnt_GridMovCons_QuantidadeAplicado As Integer = 2
    Const cnt_GridMovCons_ValorAplicado As Integer = 3
    Const cnt_GridMovCons_NF As Integer = 4
    Const cnt_GridMovCons_SerieNF As Integer = 5
    Const cnt_GridMovCons_ValorNF As Integer = 6
    Const cnt_GridMovCons_ValorICMSNF As Integer = 7
    Const cnt_GridMovCons_ValorINSSNF As Integer = 8
    Const cnt_GridMovCons_TipoMovimentacao As Integer = 9
    Const cnt_GridMovCons_FilialMovimentacao As Integer = 10
    Const cnt_GridMovCons_SqConciliacao As Integer = 11
    Const cnt_GridMovCons_SqMovimentacao As Integer = 12
    Const cnt_GridMovCons_SqMovimentacaoConciliacao As Integer = 13
    Const cnt_GridMovCons_SqMovimentacaoCessaoDireito As Integer = 14

    Const cnt_GridMovCad_Selecao As Integer = 0
    Const cnt_GridMovCad_QuantidadeAplicado As Integer = 1
    Const cnt_GridMovCad_ValorAplicado As Integer = 2
    Const cnt_GridMovCad_Quantidade_A_Aplicar As Integer = 3
    Const cnt_GridMovCad_Valor_A_Aplicar As Integer = 4
    Const cnt_GridMovCad_DataMovimentacao As Integer = 5
    Const cnt_GridMovCad_TipoMovimentacao As Integer = 6
    Const cnt_GridMovCad_NF As Integer = 7
    Const cnt_GridMovCad_SerieNF As Integer = 8
    Const cnt_GridMovCad_QuantNF As Integer = 9
    Const cnt_GridMovCad_QuantLiqNF As Integer = 10
    Const cnt_GridMovCad_ValorNF As Integer = 11
    Const cnt_GridMovCad_ICMSNF As Integer = 12
    Const cnt_GridMovCad_INSSNF As Integer = 13
    Const cnt_GridMovCad_SqMovimentacao As Integer = 14
    Const cnt_GridMovCad_SqMovimentacaoCessaoDireito As Integer = 15

    Dim oDSPagCons As New UltraWinDataSource.UltraDataSource
    Dim oDSPagCad As New UltraWinDataSource.UltraDataSource
    Dim oDSMovCons As New UltraWinDataSource.UltraDataSource
    Dim oDSMovCad As New UltraWinDataSource.UltraDataSource
    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim SqConciliacao As Integer
    Dim bProcInterno As Boolean = False

    Private Sub frmCadastroConciliacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SqConciliacao = Filtro
        ControleEdicaoTelaLocal = ControleEdicaoTela
        ComboBox_Carregar_Modalidade_Conciliacao(cboModalidadeConciliacao, True)
        Pesq_CodigoNome.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        objGrid_Inicializar(grdConsultaPagamento, , oDSPagCons, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdConsultaPagamento, "Data Pagamento", 100)
        objGrid_Coluna_Add(grdConsultaPagamento, "Data Aplicação", 100)
        objGrid_Coluna_Add(grdConsultaPagamento, "Descrição", 240)
        objGrid_Coluna_Add(grdConsultaPagamento, "Valor Aplicado", 120, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaPagamento, "Tipo Pagamento", 240)
        objGrid_Coluna_Add(grdConsultaPagamento, "Seq Conciliação", 0)
        objGrid_Coluna_Add(grdConsultaPagamento, "Seq Pagamento", 0)
        objGrid_Coluna_Add(grdConsultaPagamento, "Seq Pagamento Conciliação", 0)
        objGrid_Coluna_Add(grdConsultaPagamento, "Código Confissão de Divida", 0)

        objGrid_Inicializar(grdCadastraPagamento, , oDSPagCad, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdCadastraPagamento, "", 40, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdCadastraPagamento, "Valor Aplicado", 100, , True)
        objGrid_Coluna_Add(grdCadastraPagamento, "Valor a Aplicar", 120, , False, , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraPagamento, "Data Pagamento", 120, , False)
        objGrid_Coluna_Add(grdCadastraPagamento, "Tipo Pagamento", 240, , False)
        objGrid_Coluna_Add(grdCadastraPagamento, "Código Pagamento", 100, , False)

        objGrid_Inicializar(grdConsultaMovimentacao, , oDSMovCons, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "Data Movimentação", 100)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "Data Aplicação", 100)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "Quantidade Aplicada", 120, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "Valor Aplicado", 120, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "NF", 80)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "Serie NF", 80)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "Valor NF", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "ICMS NF", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "INSS NF", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "Tipo Movimentação", 240)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "Filial Movimentação", 140)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "Seq Conciliação", 0)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "Seq Movimentação", 0)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "Seq Movimentação Conciliação", 0)
        objGrid_Coluna_Add(grdConsultaMovimentacao, "Seq Movimentação cessão de Direito", 0)

        objGrid_Inicializar(grdCadastraMovimentacao, , oDSMovCad, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "", 40, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "Quantidade Aplicado", 100, , True)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "Valor Aplicado", 100, , True)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "Qunatidade a Aplicar", 120, , False, , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "Valor a Aplicar", 120, , False, , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "Data Movimentação", 120, , False)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "Tipo Movimentação", 240, , False)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "NF", 80)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "Serie NF", 80)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "Quant NF", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "Quant Liq NF", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "Valor NF", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "ICMS NF", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "INSS NF", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "Seq Movimentação", 0, , False)
        objGrid_Coluna_Add(grdCadastraMovimentacao, "Seq Movimentação cessão de Direito", 0)

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            CarregarDados()
            cmdGravar.Visible = False
            ExecutaConsultaPagamento()
            ExecutaAplicacaoPagamento()
            ExecutaConsultaMovimentacao()
            ExecutaAplicacaoMovimentacao()

            AtualizaSaldo()
            txtDescricao.ReadOnly = True
            Pesq_CodigoNome.Enabled = False
            txtQuantidade.Enabled = False
            txtValor.Enabled = False
            cboModalidadeConciliacao.Enabled = False
        Else
            TabControl.Enabled = False
        End If
    End Sub

    Private Sub ExecutaConsultaPagamento()
        Dim SqlText As String

        SqlText = "SELECT P.DT_PAGAMENTO, CP.DT_APLICACAO, P.DS_DESCRICAO, CP.VL_APLICACAO, "
        SqlText = SqlText & "       TP.NO_TIPO_PAGAMENTO, CP.SQ_CONCILIACAO, "
        SqlText = SqlText & "       CP.SQ_PAGAMENTO, CP.SQ_CONCILIACAO_PAGAMENTO, c.sq_confissao_divida  "
        SqlText = SqlText & "  FROM SOF.CONCILIACAO_PAGAMENTO CP, "
        SqlText = SqlText & "       SOF.PAGAMENTOS P, "
        SqlText = SqlText & "       SOF.TIPO_PAGAMENTO TP, "
        SqlText = SqlText & "       SOF.CONCILIACAO C "
        SqlText = SqlText & " WHERE TP.CD_TIPO_PAGAMENTO = P.CD_TIPO_PAGAMENTO "
        SqlText = SqlText & "   AND P.SQ_PAGAMENTO = CP.SQ_PAGAMENTO "
        SqlText = SqlText & "   AND C.SQ_CONCILIACAO = CP.SQ_CONCILIACAO "
        SqlText = SqlText & "   AND CP.SQ_CONCILIACAO =" & SqConciliacao

        objGrid_Carregar(grdConsultaPagamento, SqlText, New Integer() {cnt_GridPagCons_DataPagamento, _
                                                                        cnt_GridPagCons_DataAplicacao, _
                                                                        cnt_GridPagCons_Descricao, _
                                                                        cnt_GridPagCons_ValorAplicado, _
                                                                        cnt_GridPagCons_TipoPagamento, _
                                                                        cnt_GridPagCons_SqConciliacao, _
                                                                        cnt_GridPagCons_SqPagamento, _
                                                                        cnt_GridPagCons_SqPagamentoConciliacao, _
                                                                        cnt_GridPagCons_SqConfissaoDivida})
    End Sub

    Private Sub ExecutaAplicacaoPagamento()
        Dim SqlText As String

        SqlText = "SELECT 0 SELECAO, NULL VL_APLICADO, P.VL_A_FIXAR, P.DT_PAGAMENTO, TP.NO_TIPO_PAGAMENTO, "
        SqlText = SqlText & "       P.SQ_PAGAMENTO "
        SqlText = SqlText & "  FROM SOF.PAGAMENTOS P, SOF.TIPO_PAGAMENTO TP "
        SqlText = SqlText & " WHERE TP.CD_TIPO_PAGAMENTO = P.CD_TIPO_PAGAMENTO "
        SqlText = SqlText & "   AND P.VL_A_FIXAR <> 0 "
        SqlText = SqlText & "   AND P.CD_FORNECEDOR =  " & Pesq_CodigoNome.Codigo

        objGrid_Carregar(grdCadastraPagamento, SqlText, New Integer() {cnt_GridPagCad_Selecao, _
                                                                        cnt_GridPagCad_ValorAplicado, _
                                                                        cnt_GridPagCad_Valor_A_Aplicar, _
                                                                        cnt_GridPagCad_DataPagamento, _
                                                                        cnt_GridPagCad_TipoPagamento, _
                                                                        cnt_GridPagCad_SqPagamento})
    End Sub

    Private Sub ExecutaConsultaMovimentacao()
        Dim SqlText As String

        SqlText = "SELECT M.DT_MOVIMENTACAO, CM.DT_APLICACAO, CM.QT_APLICACAO, CM.VL_APLICACAO, "
        SqlText = SqlText & "       M.NU_NF, M.NU_SERIE_NF, M.VL_NF, M.VL_NF_ICMS, M.VL_NF_FUNRURAL, "
        SqlText = SqlText & "       TM.NO_TIPO_MOVIMENTACAO, FIL.NO_FILIAL, CM.SQ_CONCILIACAO, "
        SqlText = SqlText & "       CM.SQ_MOVIMENTACAO, CM.SQ_CONCILIACAO_MOVIMENTACAO, "
        SqlText = SqlText & "       CM.SQ_MOVIMENTACAO_CESSAO_DIREITO "
        SqlText = SqlText & "  FROM SOF.CONCILIACAO_MOVIMENTACAO CM, "
        SqlText = SqlText & "       SOF.MOVIMENTACAO M, "
        SqlText = SqlText & "       SOF.MOVIMENTACAO_CESSAO_DIREITO MCD, "
        SqlText = SqlText & "       SOF.TIPO_MOVIMENTACAO TM, "
        SqlText = SqlText & "       SOF.FILIAL FIL "
        SqlText = SqlText & " WHERE M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO "
        SqlText = SqlText & "   AND MCD.SQ_MOVIMENTACAO = CM.SQ_MOVIMENTACAO "
        SqlText = SqlText & "   AND M.CD_FILIAL_MOVIMENTACAO = FIL.CD_FILIAL "
        SqlText = SqlText & "   AND MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO = CM.SQ_MOVIMENTACAO_CESSAO_DIREITO "
        SqlText = SqlText & "   AND TM.CD_TIPO_MOVIMENTACAO = M.CD_TIPO_MOVIMENTACAO "
        SqlText = SqlText & "   AND CM.SQ_CONCILIACAO =" & SqConciliacao

        objGrid_Carregar(grdConsultaMovimentacao, SqlText, New Integer() {cnt_GridMovCons_DataMovimentacao, _
                                                                            cnt_GridMovCons_DataAplicacao, _
                                                                            cnt_GridMovCons_QuantidadeAplicado, _
                                                                            cnt_GridMovCons_ValorAplicado, _
                                                                            cnt_GridMovCons_NF, _
                                                                            cnt_GridMovCons_SerieNF, _
                                                                            cnt_GridMovCons_ValorNF, _
                                                                            cnt_GridMovCons_ValorICMSNF, _
                                                                            cnt_GridMovCons_ValorINSSNF, _
                                                                            cnt_GridMovCons_TipoMovimentacao, _
                                                                            cnt_GridMovCons_FilialMovimentacao, _
                                                                            cnt_GridMovCons_SqConciliacao, _
                                                                            cnt_GridMovCons_SqMovimentacao, _
                                                                            cnt_GridMovCons_SqMovimentacaoConciliacao, _
                                                                            cnt_GridMovCons_SqMovimentacaoCessaoDireito})
    End Sub

    Private Sub ExecutaAplicacaoMovimentacao()
        Dim SqlText As String

        SqlText = "SELECT 0 selecao, NULL QT_APLICADO,NULL VL_APLICADO ,MCD.QT_KG_A_FIXAR, MCD.VL_A_FIXAR, M.DT_MOVIMENTACAO, "
        SqlText = SqlText & "       TM.NO_TIPO_MOVIMENTACAO, M.NU_NF, M.NU_SERIE_NF,M.QT_KG_NF, M.QT_KG_LIQUIDO_NF, M.VL_NF, "
        SqlText = SqlText & "       M.VL_NF_ICMS, M.VL_NF_FUNRURAL,  "
        SqlText = SqlText & "       MCD.SQ_MOVIMENTACAO, MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO "
        SqlText = SqlText & "  FROM SOF.MOVIMENTACAO M, "
        SqlText = SqlText & "       SOF.MOVIMENTACAO_CESSAO_DIREITO MCD, "
        SqlText = SqlText & "       SOF.TIPO_MOVIMENTACAO TM "
        SqlText = SqlText & " WHERE M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO "
        SqlText = SqlText & "   AND TM.CD_TIPO_MOVIMENTACAO = M.CD_TIPO_MOVIMENTACAO "
        SqlText = SqlText & "   AND MCD.CD_FORNECEDOR =  " & Pesq_CodigoNome.Codigo
        SqlText = SqlText & "   AND (MCD.QT_KG_A_FIXAR <> 0 OR MCD.VL_A_FIXAR <> 0) "

        objGrid_Carregar(grdCadastraMovimentacao, SqlText, New Integer() {cnt_GridMovCad_Selecao, _
                                                                        cnt_GridMovCad_QuantidadeAplicado, _
                                                                        cnt_GridMovCad_ValorAplicado, _
                                                                        cnt_GridMovCad_Quantidade_A_Aplicar, _
                                                                        cnt_GridMovCad_Valor_A_Aplicar, _
                                                                        cnt_GridMovCad_DataMovimentacao, _
                                                                        cnt_GridMovCad_TipoMovimentacao, _
                                                                        cnt_GridMovCad_NF, _
                                                                        cnt_GridMovCad_SerieNF, _
                                                                        cnt_GridMovCad_QuantNF, _
                                                                        cnt_GridMovCad_QuantLiqNF, _
                                                                        cnt_GridMovCad_ValorNF, _
                                                                        cnt_GridMovCad_ICMSNF, _
                                                                        cnt_GridMovCad_INSSNF, _
                                                                        cnt_GridMovCad_SqMovimentacao, _
                                                                        cnt_GridMovCad_SqMovimentacaoCessaoDireito})
    End Sub

    Private Sub cmdExcluir_Pagamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir_Pagamento.Click
        Dim sMens As String

        If objGrid_LinhaSelecionada(grdConsultaPagamento) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If Not CampoNulo(objGrid_Valor(grdConsultaPagamento, cnt_GridPagCons_SqConfissaoDivida)) Then
            Msg_Mensagem("Essa conciliação pertence a uma recuperação de credito.")
            Exit Sub
        End If

        If objGrid_Valor(grdConsultaPagamento, cnt_GridPagCons_DataAplicacao) <> DataSistema() Then
            Msg_Mensagem("Aplicação feita em outra data.")
            Exit Sub
        End If

        sMens = "Deseja excluir"
        sMens = sMens & " a pagamento conciliação?"

        If Msg_Perguntar(sMens) Then
            If Not DBExecutar_Delete("SOF.CONCILIACAO_PAGAMENTO", "SQ_CONCILIACAO", objGrid_Valor(grdConsultaPagamento, cnt_GridPagCons_SqConciliacao), " AND ", _
                                                                  "SQ_PAGAMENTO", objGrid_Valor(grdConsultaPagamento, cnt_GridPagCons_SqPagamento), " AND ", _
                                                                  "SQ_CONCILIACAO_PAGAMENTO", objGrid_Valor(grdConsultaPagamento, cnt_GridPagCons_SqPagamentoConciliacao)) Then GoTo Erro
        End If

        ExecutaConsultaPagamento()
        ExecutaAplicacaoPagamento()
        AtualizaSaldo()

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT F.NO_RAZAO_SOCIAL, C.CD_FORNECEDOR, "
        SqlText = SqlText & "       C.CD_CONCILIACAO_MODALIDADE, C.DS_CONCILIACAO, C.QT_CONCILIACAO, "
        SqlText = SqlText & "       C.VL_CONCILIACAO "
        SqlText = SqlText & "  FROM SOF.CONCILIACAO C, "
        SqlText = SqlText & "       SOF.FORNECEDOR F "
        SqlText = SqlText & " WHERE C.CD_FORNECEDOR = F.CD_FORNECEDOR "
        SqlText = SqlText & "   AND C.SQ_CONCILIACAO = " & SqConciliacao

        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then

            txtDescricao.Text = oData.Rows(0).Item("DS_CONCILIACAO")
            ComboBox_Possicionar(cboModalidadeConciliacao, oData.Rows(0).Item("CD_CONCILIACAO_MODALIDADE"))
            txtQuantidade.Value = oData.Rows(0).Item("QT_CONCILIACAO")
            txtValor.Value = oData.Rows(0).Item("VL_CONCILIACAO")
            Pesq_CodigoNome.Codigo = oData.Rows(0).Item("CD_FORNECEDOR")


            If DBQuery_ValorUnico("select count(*) FROM sof.conciliacao_movimentacao where sq_conciliacao =" & SqConciliacao) <> 0 Then
                TabPagamento.Enabled = False
                TabMovimentacao.Enabled = True
                Me.TabControl.SelectedTab = TabControl.Tabs(1)
                Me.TabControl.Focus()
            Else
                If DBQuery_ValorUnico("select count(*) FROM sof.conciliacao_pagamento where sq_conciliacao =" & SqConciliacao) <> 0 Then
                    TabPagamento.Enabled = True
                    TabMovimentacao.Enabled = False
                    Me.TabControl.SelectedTab = TabControl.Tabs(0)
                    Me.TabControl.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String

        If Pesq_CodigoNome.Codigo <= 0 Then
            Msg_Mensagem("Favor informar o Fornecedor.")
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboModalidadeConciliacao) Then
            Msg_Mensagem("Favor selecionar uma Modalidade de Conciliação.")
            cboModalidadeConciliacao.Focus()
            Exit Sub
        End If

        If cboModalidadeConciliacao.SelectedValue = DBQuery_ValorUnico("select p.cd_conciliacao_icms  from sof.parametro p") Then
            Msg_Mensagem("Essa Modalidade de Conciliação só pode ser utilizada para amarração.")
            cboModalidadeConciliacao.Focus()
            Exit Sub
        End If
        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar a descrição.")
            txtDescricao.Focus()
            Exit Sub
        End If

        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO", False, ":CDCONCILMODAL", _
                                                                  ":CDFORN", _
                                                                  ":QTCONCIL", _
                                                                  ":VLCONCIL", _
                                                                  ":DSCONCIL", _
                                                                  ":SQCONCIL")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDCONCILMODAL", cboModalidadeConciliacao.SelectedValue), _
                                   DBParametro_Montar("CDFORN", Pesq_CodigoNome.Codigo), _
                                   DBParametro_Montar("QTCONCIL", txtQuantidade.Value), _
                                   DBParametro_Montar("VLCONCIL", txtValor.Value), _
                                   DBParametro_Montar("DSCONCIL", txtDescricao.Text, OracleClient.OracleType.VarChar, , 4000), _
                                   DBParametro_Montar("SQCONCIL", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        If DBTeveRetorno() Then
            SqConciliacao = DBRetorno(1)
        End If

        cmdGravar.Visible = False
        txtDescricao.ReadOnly = True
        Pesq_CodigoNome.Enabled = False
        txtQuantidade.Enabled = False
        txtValor.Enabled = False
        cboModalidadeConciliacao.Enabled = False
        TabControl.Enabled = True

        ExecutaConsultaMovimentacao()
        ExecutaAplicacaoMovimentacao()
        ExecutaConsultaPagamento()
        ExecutaAplicacaoPagamento()
        AtualizaSaldo()

        Exit Sub

Erro:
        TratarErro()
    End Sub

   
    Sub AtualizaSaldo()
        Dim ValorMov As Double
        Dim ValorPag As Double
        Dim QuantidadeMov As Double

        Dim iCont As Integer


        For iCont = 0 To grdConsultaMovimentacao.Rows.Count - 1
            QuantidadeMov = QuantidadeMov + grdConsultaMovimentacao.Rows(iCont).Cells(cnt_GridMovCons_QuantidadeAplicado).Value
            ValorMov = ValorMov + grdConsultaMovimentacao.Rows(iCont).Cells(cnt_GridMovCons_ValorAplicado).Value
        Next

        For iCont = 0 To grdConsultaPagamento.Rows.Count - 1
            ValorPag = ValorPag + grdConsultaPagamento.Rows(iCont).Cells(cnt_GridPagCons_ValorAplicado).Value
        Next

        txtSaldoQuantidadeMov.Value = txtQuantidade.Value - QuantidadeMov
        txtSaldoValorMov.Value = txtValor.Value - ValorMov
        txtSaldoValorPag.Value = txtValor.Value - ValorPag

   
        If txtSaldoQuantidadeMov.Value >= 0 Then
            txtSaldoQuantidadeMov.Appearance.ForeColor = Color.Blue
        Else
            txtSaldoQuantidadeMov.Appearance.ForeColor = Color.Red
        End If
        If txtSaldoValorMov.Value >= 0 Then
            txtSaldoValorMov.Appearance.ForeColor = Color.Blue
        Else
            txtSaldoValorMov.Appearance.ForeColor = Color.Red
        End If
        If txtSaldoValorPag.Value >= 0 Then
            txtSaldoValorPag.Appearance.ForeColor = Color.Blue
        Else
            txtSaldoValorPag.Appearance.ForeColor = Color.Red
        End If
    End Sub

    Private Sub cmdUsuario_Pagamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario_Pagamento.Click
        If objGrid_LinhaSelecionada(grdConsultaPagamento) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "CONCILIACAO_PAGAMENTO", "SQ_CONCILIACAO=" & objGrid_Valor(grdConsultaPagamento, cnt_GridPagCons_SqConciliacao) & _
                                                                " AND SQ_PAGAMENTO =" & objGrid_Valor(grdConsultaPagamento, cnt_GridPagCons_SqPagamento) & _
                                                                " AND SQ_CONCILIACAO_PAGAMENTO=" & objGrid_Valor(grdConsultaPagamento, cnt_GridPagCons_SqPagamentoConciliacao))
    End Sub

    Private Sub cmdExcluir_Movimentacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir_Movimentacao.Click
        If objGrid_LinhaSelecionada(grdConsultaMovimentacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdConsultaMovimentacao, cnt_GridMovCons_DataAplicacao) <> DataSistema() Then
            Msg_Mensagem("Aplicação feita em outra data.")
            Exit Sub
        End If

        Dim sMens As String
        Dim sqlText As String

        sMens = "Deseja excluir a movimentação da conciliação?"

        If Msg_Perguntar(sMens) Then
            sqlText = DBMontar_SP("SOF.SP_ELIMINA_CONCILIACAO_MOV", False, ":SQCONCIL", ":SQMOV", ":SQMOVCD", ":SQCONCILMOV")
            If Not DBExecutar(sqlText, DBParametro_Montar("SQCONCIL", SqConciliacao), _
                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdConsultaMovimentacao, cnt_GridMovCons_SqMovimentacao)), _
                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdConsultaMovimentacao, cnt_GridMovCons_SqMovimentacaoCessaoDireito)), _
                                       DBParametro_Montar("SQCONCILMOV", objGrid_Valor(grdConsultaMovimentacao, cnt_GridMovCons_SqMovimentacaoConciliacao))) Then GoTo Erro
        End If

        ExecutaConsultaMovimentacao()
        ExecutaAplicacaoMovimentacao()
        AtualizaSaldo()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub grdCadastraMovimentacao_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraMovimentacao.AfterCellUpdate
        If bProcInterno Then Exit Sub

        If e.Cell.Column.Index = cnt_GridMovCad_ValorAplicado Or _
           e.Cell.Column.Index = cnt_GridMovCad_QuantidadeAplicado Then
            bProcInterno = True

            With grdCadastraMovimentacao.Rows(e.Cell.Row.Index)
                If NVL(.Cells(cnt_GridMovCad_ValorAplicado).Value, 0) < 0 Or _
                   NVL(.Cells(cnt_GridMovCad_ValorAplicado).Value, 0) > .Cells(cnt_GridMovCad_Valor_A_Aplicar).Value Then
                    Msg_Mensagem("O Valor tem que estar entre 0 e " & Format(.Cells(cnt_GridMovCad_Valor_A_Aplicar).Value, "#,##0.00"))
                    .Cells(cnt_GridMovCad_ValorAplicado).Value = e.Cell.OriginalValue
                    GoTo Sair
                End If
                If NVL(.Cells(cnt_GridMovCad_QuantidadeAplicado).Value, 0) < 0 Or _
                   NVL(.Cells(cnt_GridMovCad_QuantidadeAplicado).Value, 0) > .Cells(cnt_GridMovCad_Quantidade_A_Aplicar).Value Then
                    Msg_Mensagem("A quantidade tem que estar entre 0 e " & Format(.Cells(cnt_GridMovCad_Quantidade_A_Aplicar).Value, "#,##0.00"))
                    .Cells(cnt_GridMovCad_QuantidadeAplicado).Value = e.Cell.OriginalValue
                    GoTo Sair
                End If

                If NVL(.Cells(cnt_GridMovCad_ValorAplicado).Value, 0) = 0 And _
                   NVL(.Cells(cnt_GridMovCad_QuantidadeAplicado).Value, 0) = 0 Then
                    .Cells(cnt_GridMovCad_Selecao).Value = 0
                Else
                    .Cells(cnt_GridMovCad_Selecao).Value = 1
                End If

                If e.Cell.Column.Index = cnt_GridMovCad_QuantidadeAplicado Then
                    .Cells(cnt_GridMovCad_ValorAplicado).Value = NVL(.Cells(cnt_GridMovCad_QuantidadeAplicado).Value, 0) * _
                                                                         (.Cells(cnt_GridMovCad_ValorNF).Value / _
                                                                          .Cells(cnt_GridMovCad_QuantLiqNF).Value)
                End If
            End With
        End If

        AtualizaSaldo()

Sair:
        bProcInterno = False
    End Sub


    Private Sub cmdUsuario_Movimentacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario_Movimentacao.Click
        Auditoria(TipoCampoFixo.Todos, "CONCILIACAO_MOVIMENTACAO", "SQ_CONCILIACAO=" & objGrid_Valor(grdConsultaPagamento, cnt_GridMovCons_SqConciliacao) & _
                                " AND SQ_MOVIMENTACAO =" & objGrid_Valor(grdConsultaPagamento, cnt_GridMovCons_SqMovimentacao) & _
                                " AND SQ_MOVIMENTACAO_CESSAO_DIREITO =" & objGrid_Valor(grdConsultaPagamento, cnt_GridMovCons_SqMovimentacaoCessaoDireito) & _
                                " AND SQ_CONCILIACAO_MOVIMENTACAO=" & objGrid_Valor(grdConsultaPagamento, cnt_GridMovCons_SqMovimentacaoConciliacao))

    End Sub

    Private Sub grdCadastraMovimentacao_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraMovimentacao.CellChange
        If e.Cell.Column.Index = cnt_GridMovCad_Selecao Then
            With grdCadastraMovimentacao.Rows(e.Cell.Row.Index)
                bProcInterno = True
                If NVL(.Cells(cnt_GridMovCad_Selecao).Value, 0) = 1 Then
                    .Cells(cnt_GridMovCad_ValorAplicado).Value = 0
                Else
                    .Cells(cnt_GridMovCad_QuantidadeAplicado).Value = .Cells(cnt_GridMovCad_Quantidade_A_Aplicar).Value
                    .Cells(cnt_GridMovCad_ValorAplicado).Value = .Cells(cnt_GridMovCad_Valor_A_Aplicar).Value

                    .Cells(cnt_GridMovCad_QuantidadeAplicado).Activate()
                    grdCadastraMovimentacao.PerformAction(UltraGridAction.EnterEditMode)
                End If
                bProcInterno = False
            End With
        End If
    End Sub

    Private Sub cmdGravar_Pagamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_Pagamento.Click
        Dim SqlText As String
        Dim iCont As Integer

        For iCont = 0 To grdCadastraPagamento.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraPagamento, cnt_GridPagCad_Selecao, iCont) Then
                With grdCadastraPagamento.Rows(iCont)

                    If .Cells(cnt_GridPagCad_ValorAplicado).Value <= 0 Then
                        Msg_Mensagem("O valor informado tem que ser maior que 0.")
                        Exit Sub
                    End If

                    If .Cells(cnt_GridPagCad_ValorAplicado).Value > .Cells(cnt_GridPagCad_Valor_A_Aplicar).Value Then
                        Msg_Mensagem("O valor informado é maior que o saldo a aplicar.")
                        Exit Sub
                    End If
                    If .Cells(cnt_GridPagCad_ValorAplicado).Value > txtSaldoValorPag.Value Then
                        Msg_Mensagem("Valor aplicado não pode ser maior do que " & Format(txtSaldoValorPag.Value, "#,##0.00"))
                        Exit Sub
                    End If


                    SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO_PAG", False, ":SQCONCIL", _
                                                                                  ":SQPAG", _
                                                                                  ":VLAPLICACAO")

                    If Not DBExecutar(SqlText, DBParametro_Montar("SQCONCIL", SqConciliacao), _
                                               DBParametro_Montar("SQPAG", .Cells(cnt_GridPagCad_SqPagamento).Value), _
                                               DBParametro_Montar("VLAPLICACAO", .Cells(cnt_GridPagCad_ValorAplicado).Value)) Then GoTo Erro

                End With
            End If
        Next

        ExecutaConsultaPagamento()
        ExecutaAplicacaoPagamento()
        AtualizaSaldo()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdGravar_Movimentacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_Movimentacao.Click
        Dim SqlText As String
        Dim iCont As Integer

        For iCont = 0 To grdCadastraMovimentacao.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraMovimentacao, cnt_GridPagCad_Selecao, iCont) Then
                With grdCadastraMovimentacao.Rows(iCont)
                    If CampoNulo(.Cells(cnt_GridMovCad_ValorAplicado).Value) Or CampoNulo(.Cells(cnt_GridMovCad_QuantidadeAplicado).Value) Then
                        Exit Sub
                    End If
                    If .Cells(cnt_GridMovCad_ValorAplicado).Value < 0 Then
                        Msg_Mensagem("O valor informado tem que ser maior ou igual a 0.")
                        Exit Sub
                    End If
                    If .Cells(cnt_GridMovCad_QuantidadeAplicado).Value < 0 Then
                        Msg_Mensagem("A quantidade informada tem que ser maior ou igual a 0.")
                        Exit Sub
                    End If
                    If .Cells(cnt_GridMovCad_ValorAplicado).Value > .Cells(cnt_GridMovCad_Valor_A_Aplicar).Value Then
                        Msg_Mensagem("O valor informado é maior que o saldo a aplicar.")
                        Exit Sub
                    End If
                    If .Cells(cnt_GridMovCad_QuantidadeAplicado).Value > .Cells(cnt_GridMovCad_Quantidade_A_Aplicar).Value Then
                        Msg_Mensagem("A quantidade informada é maior que o saldo a aplicar.")
                        Exit Sub
                    End If
                    If .Cells(cnt_GridMovCad_QuantidadeAplicado).Value > txtSaldoQuantidadeMov.Value Then
                        Msg_Mensagem("Quantidade aplicada não pode ser maior do que " & Format(txtSaldoQuantidadeMov.Value, "#,##0"))
                        Exit Sub
                    End If
                    If .Cells(cnt_GridMovCad_ValorAplicado).Value > txtSaldoValorMov.Value Then
                        Msg_Mensagem("Valor aplicado não pode ser maior do que " & Format(txtSaldoValorMov.Value, "#,##0.00"))
                        Exit Sub
                    End If

                    SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO_MOV", False, ":SQCONCIL", ":SQMOV", ":SQMOVCD", ":VLAPLICACAO", ":QTAPLICACAO")
                    If Not DBExecutar(SqlText, DBParametro_Montar("SQCONCIL", SqConciliacao), _
                                               DBParametro_Montar("SQMOV", .Cells(cnt_GridMovCad_SqMovimentacao).Value), _
                                               DBParametro_Montar("SQMOVCD", .Cells(cnt_GridMovCad_SqMovimentacaoCessaoDireito).Value), _
                                               DBParametro_Montar("VLAPLICACAO", .Cells(cnt_GridMovCad_ValorAplicado).Value), _
                                               DBParametro_Montar("QTAPLICACAO", .Cells(cnt_GridMovCad_QuantidadeAplicado).Value)) Then GoTo Erro
                End With
            End If
        Next

        ExecutaConsultaMovimentacao()
        ExecutaAplicacaoMovimentacao()
        AtualizaSaldo()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub grdCadastraMovimentacao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdCadastraMovimentacao.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdCadastraMovimentacao.PerformAction(UltraGridAction.ExitEditMode)
        End If
    End Sub

    Private Sub grdCadastraPagamento_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraPagamento.AfterCellUpdate
        If e.Cell.Column.Index = cnt_GridPagCad_ValorAplicado Then
            With grdCadastraPagamento.Rows(e.Cell.Row.Index)
                If NVL(.Cells(cnt_GridPagCad_ValorAplicado).Value, 0) < 0 Or _
                   NVL(.Cells(cnt_GridPagCad_ValorAplicado).Value, 0) > .Cells(cnt_GridPagCad_Valor_A_Aplicar).Value Then
                    cmdFechar.Focus()
                    Msg_Mensagem("O Valor tem que estar entre 0 e " & Format(.Cells(cnt_GridPagCad_Valor_A_Aplicar).Value, "#,##0.00"))
                    .Cells(cnt_GridPagCad_ValorAplicado).Value = e.Cell.OriginalValue
                    Exit Sub
                End If

                If NVL(.Cells(cnt_GridPagCad_ValorAplicado).Value, 0) = 0 Then
                    .Cells(cnt_GridPagCad_Selecao).Value = 0
                Else
                    .Cells(cnt_GridPagCad_Selecao).Value = 1
                End If
            End With
        End If

        AtualizaSaldo()
    End Sub

    Private Sub grdCadastraPagamento_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraPagamento.CellChange
        If e.Cell.Column.Index = cnt_GridPagCad_Selecao Then
            With grdCadastraPagamento.Rows(e.Cell.Row.Index)
                If .Cells(cnt_GridPagCad_Selecao).Value = 1 Then
                    .Cells(cnt_GridPagCad_ValorAplicado).Value = 0
                Else
                    .Cells(cnt_GridPagCad_ValorAplicado).Value = .Cells(cnt_GridPagCad_Valor_A_Aplicar).Value
                    .Cells(cnt_GridPagCad_ValorAplicado).Activate()
                    grdCadastraPagamento.PerformAction(UltraGridAction.EnterEditMode)
                End If
            End With
        End If
    End Sub

    Private Sub grdCadastraPagamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdCadastraPagamento.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdCadastraPagamento.PerformAction(UltraGridAction.ExitEditMode)
        End If
    End Sub

    Private Sub cmdExcell_Pagamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell_Pagamento.Click
        objGrid_ExportarExcell(grdConsultaPagamento, Trim(Me.Text) & " - " & TabPagamento.Tab.Text, cmdExcell_Pagamento)
    End Sub

    Private Sub cmdExcell_Movimentacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell_Movimentacao.Click
        objGrid_ExportarExcell(grdConsultaMovimentacao, Trim(Me.Text) & " - " & TabMovimentacao.Tab.Text, cmdExcell_Movimentacao)
    End Sub
End Class