Imports Infragistics.Win
Imports System.IO
Imports System.Security.Cryptography
Imports Logus.eDbType

Public Class frmConsultaPagamento
    Const cnt_GridGeral_DataPagamento As Integer = 0
    Const cnt_GridGeral_Fornecedor As Integer = 1
    Const cnt_GridGeral_ValorPagamento As Integer = 2
    Const cnt_GridGeral_ValorConciliacao As Integer = 3
    Const cnt_GridGeral_Retencao As Integer = 4
    Const cnt_GridGeral_ValorRecebido As Integer = 5
    Const cnt_GridGeral_TaxaUS As Integer = 6
    Const cnt_GridGeral_TxtSist As Integer = 7
    Const cnt_GridGeral_ValorUS As Integer = 8
    Const cnt_GridGeral_Descricao As Integer = 9
    Const cnt_GridGeral_TipoPagamento As Integer = 10
    Const cnt_GridGeral_ICMS As Integer = 11
    Const cnt_GridGeral_FormaPagamento As Integer = 12
    Const cnt_GridGeral_FilialOrigem As Integer = 13
    Const cnt_GridGeral_FilialPagadora As Integer = 14
    Const cnt_GridGeral_Favorecido As Integer = 15
    Const cnt_GridGeral_ContaCorrenteFavorecido As Integer = 16
    Const cnt_GridGeral_SQ_PAGAMENTO As Integer = 17
    Const cnt_GridGeral_Aprovado As Integer = 18
    Const cnt_GridGeral_Aprovador As Integer = 19
    Const cnt_GridGeral_Interfaciado As Integer = 20
    Const cnt_GridGeral_SQ_ITEM_MOV_BANCARIO As Integer = 21
    Const cnt_GridGeral_VL_A_FIXAR As Integer = 22

    Const cnt_GridGeral_1_SQ_PAGAMENTO As Integer = 0
    Const cnt_GridGeral_1_DataFixacao As Integer = 1
    Const cnt_GridGeral_1_Descricao As Integer = 2
    Const cnt_GridGeral_1_VlFixo As Integer = 3
    Const cnt_GridGeral_1_CtrPAF As Integer = 4

    Const cnt_GridGeral_2_SQ_PAGAMENTO As Integer = 0
    Const cnt_GridGeral_2_DataFixacao As Integer = 1
    Const cnt_GridGeral_2_Neg As Integer = 2
    Const cnt_GridGeral_2_VlFixo As Integer = 3
    Const cnt_GridGeral_2_CtrPAF As Integer = 4

    Const cnt_GridGeral_3_SQ_PAGAMENTO As Integer = 0
    Const cnt_GridGeral_3_DataFixacao As Integer = 1
    Const cnt_GridGeral_3_CtrFixo As Integer = 2
    Const cnt_GridGeral_3_VlFixo As Integer = 3
    Const cnt_GridGeral_3_CtrPAF As Integer = 4
    Const cnt_GridGeral_3_SQ_NEGOCIACAO As Integer = 5

    Const cnt_SEC_Tela As String = "Transacao_Pagamento"

    Dim oDS As New DataSet

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Pesquisar()
        Dim SqlText As String
        Dim Cod_Conciliacao_ICMS As Long

        If Not Data_ValidarPeriodo("data do pagamento", txtDataInicial.Value, txtDataFinal.Value, False) Then Exit Sub

        If Not IsDate(txtDataInicial.Value) And _
           Not IsDate(txtDataFinal.Value) And _
           Pesq_CodigoNome.Codigo = 0 Then
            Msg_Mensagem("É preciso informar pelo menos uma informação de filtro")
            Exit Sub
        End If

        SqlText = "SELECT CD_CONCILIACAO_ICMS FROM SOF.PARAMETRO"
        Cod_Conciliacao_ICMS = DBQuery_ValorUnico(SqlText)

        'Montagem da Query
        SqlText = "SELECT P.DT_PAGAMENTO," & _
                         "F.NO_RAZAO_SOCIAL," & _
                         "P.VL_PAGAMENTO," & _
                         "NVL(SUM(CP.VL_APLICACAO),0) VL_CONCILIADO," & _
                         "P.VL_TOTAL_IMPOSTOS," & _
                         "P.VL_LIQUIDO," & _
                         "P.VL_TAXA_DOLAR," & _
                         "P.IC_TAXA_SISTEMA," & _
                         "P.VL_DOLAR," & _
                         "P.DS_DESCRICAO," & _
                         "TP.NO_TIPO_PAGAMENTO," & _
                         "P.IC_ICMS," & _
                         "FP.NO_FORMA_PAGAMENTO," & _
                         "FIL.NO_FILIAL," & _
                         "FILPAG.NO_FILIAL AS NO_FILPAG," & _
                         "DECODE(P.CD_FORMA_PAGAMENTO," & _
                                "2, DECODE(P.CD_FORNECEDOR_FAVORECIDO, NULL, P.NO_FAVORECIDO, FV.NO_RAZAO_SOCIAL), " & _
                                          "P.NO_FAVORECIDO) NO_FAVORECIDO," & _
                         "P.CD_CONTA_CORRENTE," & _
                         "P.SQ_PAGAMENTO," & _
                         "P.IC_STATUS_APROVACAO," & _
                         "SOF.FC_LISTA_VALORES(3, P.SQ_PAGAMENTO) NO_USER_APROVACAO," & _
                         "P.IC_INTERFACE_ENVIADA," & _
                         "P.SQ_ITEM_MOV_BANCARIO," & _
                         "P.VL_A_FIXAR" & _
                  " FROM SOF.PAGAMENTOS P," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR FV," & _
                        "SOF.TIPO_PAGAMENTO TP," & _
                        "SOF.FORMA_PAGAMENTO FP," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.FILIAL FILPAG," & _
                        "(SELECT CP.SQ_PAGAMENTO," & _
                                "SUM(CP.VL_APLICACAO) VL_APLICACAO" & _
                         " FROM SOF.CONCILIACAO_PAGAMENTO CP," & _
                               "SOF.CONCILIACAO C" & _
                         " WHERE CP.SQ_CONCILIACAO = C.SQ_CONCILIACAO" & _
                           " AND C.CD_CONCILIACAO_MODALIDADE <> " & Cod_Conciliacao_ICMS & _
                          " GROUP BY CP.SQ_PAGAMENTO) CP" & _
                  " WHERE P.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND P.CD_FORNECEDOR_FAVORECIDO = FV.CD_FORNECEDOR(+)" & _
                    " AND P.CD_TIPO_PAGAMENTO = TP.CD_TIPO_PAGAMENTO" & _
                    " AND P.CD_FORMA_PAGAMENTO = FP.CD_FORMA_PAGAMENTO" & _
                    " AND P.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND P.SQ_PAGAMENTO = CP.SQ_PAGAMENTO(+)" & _
                    " AND P.CD_FILIAL_PAGADORA = FILPAG.CD_FILIAL"

        'Filtro da Query
        If Pesq_CodigoNome.Codigo > 0 Then
            SqlText = SqlText & " AND P.CD_FORNECEDOR = " & Pesq_CodigoNome.Codigo
            'SqlText = SqlText & " AND (P.CD_FORNECEDOR IN (SELECT CD_FORNECEDOR FROM SOF.FORNECEDOR WHERE CD_REPASSADOR = " & Pesq_CodigoNome.Codigo & ") OR P.CD_FORNECEDOR = " & Pesq_CodigoNome.Codigo & ")"
        End If
        If IsDate(txtDataInicial.Value) Then
            SqlText = SqlText & " AND TRUNC(P.DT_PAGAMENTO) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Value))
        End If
        If IsDate(txtDataFinal.Value) Then
            SqlText = SqlText & " AND TRUNC(P.DT_PAGAMENTO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Value))
        End If
        If ComboBox_LinhaSelecionada(cboTipoPagamento) Then
            SqlText = SqlText & " AND P.CD_TIPO_PAGAMENTO = " & cboTipoPagamento.SelectedValue
        End If
        If SelecaoFormaPagamento.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND P.CD_FORMA_PAGAMENTO IN (" & SelecaoFormaPagamento.Lista_ID & ")"
        End If
        If SelecaoFilialPagadora.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND P.CD_FILIAL_PAGADORA IN (" & SelecaoFilialPagadora.Lista_ID & ")"
        End If
        If SelecaoFilialOrigem.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND P.CD_FILIAL_ORIGEM IN (" & SelecaoFilialOrigem.Lista_ID & ")"
        Else
            SqlText = SqlText & " AND P.CD_FILIAL_ORIGEM  IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        'Agrupamento da Query
        SqlText = SqlText & _
                  " GROUP BY P.DT_PAGAMENTO," & _
                            "F.NO_RAZAO_SOCIAL," & _
                            "P.VL_PAGAMENTO," & _
                            "P.VL_TAXA_DOLAR," & _
                            "P.IC_TAXA_SISTEMA," & _
                            "P.VL_DOLAR," & _
                            "P.DS_DESCRICAO," & _
                            "TP.NO_TIPO_PAGAMENTO," & _
                            "P.IC_ICMS," & _
                            "FP.NO_FORMA_PAGAMENTO," & _
                            "FIL.NO_FILIAL," & _
                            "DECODE(P.CD_FORMA_PAGAMENTO," & _
                                   "2, DECODE(P.CD_FORNECEDOR_FAVORECIDO," & _
                                             "NULL, P.NO_FAVORECIDO," & _
                                                   "FV.NO_RAZAO_SOCIAL)," & _
                                       "P.NO_FAVORECIDO)," & _
                            "P.VL_A_FIXAR," & _
                            "P.SQ_ITEM_MOV_BANCARIO," & _
                            "P.SQ_PAGAMENTO," & _
                            "P.CD_CONTA_CORRENTE," & _
                            "FILPAG.NO_FILIAL," & _
                            "P.CD_TIPO_PAGAMENTO," & _
                            "P.NO_USER_CRIACAO," & _
                            "P.DT_CRIACAO," & _
                            "P.NO_USER_ALTERACAO," & _
                            "P.DT_ALTERACAO," & _
                            "P.IC_INTERFACE_ENVIADA," & _
                            "P.IC_STATUS_APROVACAO," & _
                            "SOF.FC_LISTA_VALORES(3, P.SQ_PAGAMENTO)," & _
                            "P.CD_FORNECEDOR," & _
                            "P.VL_LIQUIDO," & _
                            "P.VL_TOTAL_IMPOSTOS"

        SqlText = "SELECT * FROM (" & SqlText & ") ORDER BY DT_PAGAMENTO, NO_RAZAO_SOCIAL "

        AVI_Carregar(Me)

        DBQuery_Append(oDS.Tables(0), SqlText, True)

        AVI_Fechar(Me)
    End Sub

    Private Sub Pesquisa_CriarDataSet()
        'Montagem do DataSet - Início
        DBData_Criar(oDS, "Aplicacao_ContratoPAF", New String() {"SQ_PAGAMENTO", "Data da Aplicação", "Ctr. PAF", "Valor Aplicado", "CD_CtrPAF"}, _
                                                   New eDbType() {_Decimal, _Data, _Texto, _Numero, _Numero})
        DBData_Criar(oDS, "Aplicacao_Negociacao", New String() {"SQ_PAGAMENTO", "Data da Aplicação", "Neg", "Valor Aplicado", "CD_CtrPAF"}, _
                                                  New eDbType() {_Decimal, _Data, _Decimal, _Numero, _Numero})
        DBData_Criar(oDS, "Aplicacao_ContratoFixo", New String() {"SQ_PAGAMENTO", "Data da Aplicação", "Ctr. Fixo", "Valor Aplicado", "CD_CtrPAF", "SQ_NEGOCIACAO"}, _
                                                    New eDbType() {_Decimal, _Data, _Decimal, _Numero, _Numero, _Decimal})
        'Montagem do DataSet - Fim

        DBData_Relationamento_Criar(oDS, "FK_Aplicacao_ContratoPAF", oDS.Tables(0), New String() {oDS.Tables(0).Columns(cnt_GridGeral_SQ_PAGAMENTO).ColumnName}, _
                                                                     oDS.Tables(1), New String() {"SQ_PAGAMENTO"})
        DBData_Relationamento_Criar(oDS, "FK_Aplicacao_Negociacao", oDS.Tables(1), New String() {"SQ_PAGAMENTO", "CD_CtrPAF"}, _
                                                                    oDS.Tables(2), New String() {"SQ_PAGAMENTO", "CD_CtrPAF"})
        DBData_Relationamento_Criar(oDS, "FK_Aplicacao_ContratoFixo", oDS.Tables(2), New String() {"SQ_PAGAMENTO", "CD_CtrPAF", "Neg"}, _
                                                                      oDS.Tables(3), New String() {"SQ_PAGAMENTO", "CD_CtrPAF", "SQ_NEGOCIACAO"})

        objGrid_ExibirTotal(grdGeral, New Integer() {cnt_GridGeral_ValorPagamento, cnt_GridGeral_ValorConciliacao, cnt_GridGeral_ValorRecebido})

        objGrid_Band_Formatar(grdGeral.DisplayLayout.Bands(1), UltraWinGrid.CellClickAction.RowSelect)

        With grdGeral.DisplayLayout.Bands(1)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_1_SQ_PAGAMENTO), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_1_DataFixacao), Nothing, 100, , , , cnt_Formato_Data)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_1_VlFixo), Nothing, 100, , , , cnt_Formato_Valor)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_1_CtrPAF), Nothing, 0)
        End With

        objGrid_Band_Formatar(grdGeral.DisplayLayout.Bands(2), UltraWinGrid.CellClickAction.RowSelect)

        With grdGeral.DisplayLayout.Bands(2)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_2_SQ_PAGAMENTO), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_2_DataFixacao), Nothing, 100, , , , cnt_Formato_Data)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_2_VlFixo), Nothing, 100, , , , cnt_Formato_Valor)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_2_CtrPAF), Nothing, 0)
        End With

        objGrid_Band_Formatar(grdGeral.DisplayLayout.Bands(3), UltraWinGrid.CellClickAction.RowSelect)

        With grdGeral.DisplayLayout.Bands(3)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_3_SQ_PAGAMENTO), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_3_DataFixacao), Nothing, 100, , , , cnt_Formato_Data)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_3_VlFixo), Nothing, 100, , , , cnt_Formato_Valor)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_3_CtrPAF), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridGeral_3_SQ_NEGOCIACAO), Nothing, 0)
        End With
    End Sub

    Private Sub Pesquisa_Aplicacao_ContratoPAF(ByVal SQ_PAGAMENTO As Integer)
        Dim SqlText As String

        SqlText = "SELECT PCP.SQ_PAGAMENTO," & _
                         "PCP.DT_FIXACAO," & _
                         "TO_CHAR(PCP.CD_CONTRATO_PAF) AS DS_DESCRICAO," & _
                         "SUM (PCP.VL_FIXO) AS VL_FIXO," & _
                         "PCP.CD_CONTRATO_PAF" & _
                  " FROM SOF.PAG_CTR_PAF PCP" & _
                  " WHERE PCP.SQ_PAGAMENTO = " & SQ_PAGAMENTO & _
                  " GROUP BY PCP.SQ_PAGAMENTO," & _
                            "PCP.DT_FIXACAO," & _
                            "PCP.CD_CONTRATO_PAF," & _
                            "PCP.CD_CONTRATO_PAF" & _
                  " UNION ALL " & _
                  " SELECT CP.SQ_PAGAMENTO," & _
                          "CP.DT_APLICACAO," & _
                          "DECODE(C.CD_CONCILIACAO_MODALIDADE ,23,'AMARRADO NF ' || M.NU_NF , 'CONCILIACAO ' || CP.SQ_CONCILIACAO) DS_DESCRICAO," & _
                          "CP.VL_APLICACAO, NULL" & _
                   " FROM SOF.CONCILIACAO_PAGAMENTO CP," & _
                         "SOF.CONCILIACAO C," & _
                         "SOF.PAG_AMARRACAO_ICMS PA," & _
                         "SOF.MOVIMENTACAO M" & _
                   " WHERE CP.SQ_CONCILIACAO =C.SQ_CONCILIACAO" & _
                     " AND CP.SQ_CONCILIACAO = PA.SQ_CONCILIACAO (+)" & _
                     " AND CP.SQ_PAGAMENTO  = PA.SQ_PAGAMENTO (+)" & _
                     " AND PA.SQ_MOVIMENTACAO =M.SQ_MOVIMENTACAO (+)" & _
                     " AND CP.SQ_PAGAMENTO = " & SQ_PAGAMENTO
        DBQuery_Append(oDS.Tables(1), SqlText)
    End Sub

    Private Sub Pesquisa_Aplicacao_Negociacao(ByVal SQ_PAGAMENTO As Integer, ByVal CD_CONTRATO_PAF As Integer)
        Dim SqlText As String

        SqlText = "SELECT PN.SQ_PAGAMENTO," & _
                         "PN.DT_FIXACAO," & _
                         "PN.SQ_NEGOCIACAO," & _
                         "PN.VL_FIXO, " & _
                         "PN.CD_CONTRATO_PAF" & _
                  " FROM SOF.PAG_NEG PN" & _
                  " WHERE PN.SQ_PAGAMENTO = " & SQ_PAGAMENTO & _
                    " AND PN.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF
        DBQuery_Append(oDS.Tables(2), SqlText)
    End Sub

    Private Sub Pesquisa_Aplicacao_ContratoFixo(ByVal SQ_PAGAMENTO As Integer, _
                                                ByVal CD_CONTRATO_PAF As Integer, _
                                                ByVal SQ_NEGOCIACAO As Integer)
        Dim SqlText As String

        SqlText = "SELECT PNCF.SQ_PAGAMENTO," & _
                         "PNCF.DT_FIXACAO, " & _
                         "PNCF.SQ_CONTRATO_FIXO," & _
                         "PNCF.VL_FIXO," & _
                         "PNCF.CD_CONTRATO_PAF," & _
                         "PNCF.SQ_NEGOCIACAO" & _
                  " FROM SOF.PAG_NEG_CTR_FIX PNCF" & _
                  " WHERE PNCF.SQ_PAGAMENTO = " & SQ_PAGAMENTO & _
                    " AND PNCF.CD_CONTRATO_PAF= " & CD_CONTRATO_PAF & _
                    " AND PNCF.SQ_NEGOCIACAO = " & SQ_NEGOCIACAO
        DBQuery_Append(oDS.Tables(3), SqlText)
    End Sub

    Private Sub frmConsultaPagamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_CodigoNome.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        SelecaoFilialOrigem.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilialOrigem.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilialOrigem.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilialOrigem.BancoDados_Carregar()

        SelecaoFilialPagadora.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilialPagadora.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilialPagadora.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilialPagadora.BancoDados_Carregar()

        SelecaoFormaPagamento.BancoDados_Tabela = "FORMA_PAGAMENTO"
        SelecaoFormaPagamento.BancoDados_Campo_Codigo = "CD_FORMA_PAGAMENTO"
        SelecaoFormaPagamento.BancoDados_Campo_Descricao = "NO_FORMA_PAGAMENTO"
        SelecaoFormaPagamento.BancoDados_Carregar()

        ComboBox_Carregar_Tipo_Pagamento(cboTipoPagamento, True)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , _
                                              DefaultableBoolean.False, True, _
                                              UltraWinGrid.ViewStyleBand.Vertical, , , True)
        objGrid_Coluna_Add(grdGeral, "Data", 60, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 200)
        objGrid_Coluna_Add(grdGeral, "Valor em R$", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor Conciliação", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Retenção", 100)
        objGrid_Coluna_Add(grdGeral, "Valor Recebido", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Taxa US$", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Txt Sist", 100)
        objGrid_Coluna_Add(grdGeral, "Valor US$", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Descrição", 200)
        objGrid_Coluna_Add(grdGeral, "Tipo de Pagamento", 160)
        objGrid_Coluna_Add(grdGeral, "ICMS", 100)
        objGrid_Coluna_Add(grdGeral, "Forma de Pagamento", 120)
        objGrid_Coluna_Add(grdGeral, "Filial Origem", 120)
        objGrid_Coluna_Add(grdGeral, "Filial Pagadora", 120)
        objGrid_Coluna_Add(grdGeral, "Favorecido", 170)
        objGrid_Coluna_Add(grdGeral, "Conta Corrente Favorecido", 100)
        objGrid_Coluna_Add(grdGeral, "Código Pagamento", 100, , , , , cnt_Formato_NumeroInteiro)
        objGrid_Coluna_Add(grdGeral, "Aprovado", 100)
        objGrid_Coluna_Add(grdGeral, "Aprovador", 120)
        objGrid_Coluna_Add(grdGeral, "Interfaciado", 100)
        objGrid_Coluna_Add(grdGeral, "SQ_ITEM_MOV_BANCARIO", 0, , , , , cnt_Formato_NumeroInteiro)
        objGrid_Coluna_Add(grdGeral, "VL_A_FIXAR", 0, , , , , cnt_Formato_Valor)

        Pesquisa_CriarDataSet()

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdAlterar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao_Permissao(cmdApagarParcial, SEC_Permissao.SEC_P_Acesso_ApagarPagamentoParcialmente, True)
        SEC_ValidarBotao_Permissao(cmdInterfaceJDE, SEC_Permissao.SEC_P_Acesso_AlterarIndicadorInterfaceEnviadaJDE_OW, True)
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        Pesquisar()
    End Sub

    Private Sub grdGeral_AfterRowExpanded(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdGeral.AfterRowExpanded
        Select Case objGridBand_Index(e.Row)
            Case -1
                If e.Row.ChildBands.FirstRow Is Nothing Then
                    Pesquisa_Aplicacao_ContratoPAF(e.Row.Cells(cnt_GridGeral_SQ_PAGAMENTO).Value)
                End If
            Case 0
                If e.Row.ChildBands.FirstRow Is Nothing Then
                    Pesquisa_Aplicacao_Negociacao(e.Row.Cells(cnt_GridGeral_1_SQ_PAGAMENTO).Value, _
                                                  NVL(e.Row.Cells(cnt_GridGeral_1_CtrPAF).Value, 0))
                End If
            Case 1
                If e.Row.ChildBands.FirstRow Is Nothing Then
                    Pesquisa_Aplicacao_ContratoFixo(e.Row.Cells(cnt_GridGeral_2_SQ_PAGAMENTO).Value, _
                                                    NVL(e.Row.Cells(cnt_GridGeral_2_CtrPAF).Value, 0), _
                                                    e.Row.Cells(cnt_GridGeral_2_Neg).Value)
                End If
        End Select
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Form_Show(Me.MdiParent, New frmCadastroPagamento, , True)
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdGeral, cnt_GridGeral_ValorPagamento, , 0) <> _
           objGrid_Valor(grdGeral, cnt_GridGeral_VL_A_FIXAR, , 0) Then
            Msg_Mensagem("Este pagamento já foi fixado.")
            Exit Sub
        End If

        Dim oForm As New frmConsultaPagamento_Alteracao

        oForm.SQ_PAGAMENTO = objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)

        Form_Show(Nothing, oForm, True)

        If oForm.AlterouInformacao Then
            Pesquisar()
        End If
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oData As DataTable
        Dim SqlText As String
        Dim Transacao As Boolean
        Dim Qt As Integer
        Dim ApagarContratoFixo As Boolean
        Dim IcNeg As Boolean
        Dim IcCtrPAF As Boolean

        If objGrid_Valor(grdGeral, cnt_GridGeral_Interfaciado, , "N") = "S" Then
            Msg_Mensagem("A interface do pagamento ja foi enviada.")
            Exit Sub
        End If

        If objGrid_Valor(grdGeral, cnt_GridGeral_DataPagamento) <> CDate(DataSistema()) Then
            Msg_Mensagem("Este pagamento é de uma dia anterior ao dia atual.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) FROM SOF.CTRPAF_NEG_CTRFIX_MOV_DQ" & _
                  " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Esse pagamento corresponde a um deságio financeiro.")
            Exit Sub
        End If

        If Not Msg_Perguntar("Deseja eliminar o pagamento?") Then Exit Sub

        ApagarContratoFixo = False
        IcNeg = False
        IcCtrPAF = False

        If objGrid_Valor(grdGeral, cnt_GridGeral_DataPagamento) = CDate(DataSistema()) Then
            SqlText = "SELECT COUNT(*) FROM SOF.PAG_NEG_CTR_FIX" & _
                      " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)
            Qt = DBQuery_ValorUnico(SqlText)

            If Qt = 0 Then
                SqlText = "SELECT COUNT(*) FROM SOF.PAG_NEG" & _
                          " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)
                Qt = DBQuery_ValorUnico(SqlText)

                If Qt = 0 Then
                    SqlText = "SELECT COUNT(*) AS QT FROM SOF.PAG_CTR_PAF" & _
                              " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)
                    Qt = DBQuery_ValorUnico(SqlText)

                    If Qt <> 0 Then
                        SqlText = "SELECT COUNT(*) AS QT " & _
                                  " FROM SOF.PAG_CTR_PAF PCP," & _
                                        "SOF.CONTRATO_PAF CP" & _
                                  " WHERE PCP.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                                    " AND CP.IC_STATUS = 'F'" & _
                                    " AND PCP.SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)
                        Qt = DBQuery_ValorUnico(SqlText)

                        If Qt <> 0 Then
                            Msg_Mensagem("Esse pagamento já foi aplicado em um contrato PAF que esta fechado.")
                            Exit Sub
                        End If

                        If Not Msg_Perguntar("Deseja retirar a aplicação do Contrato PAF?") Then Exit Sub

                        IcCtrPAF = True
                    End If
                Else
                    SqlText = "SELECT COUNT(*)" & _
                              " FROM SOF.PAG_NEG PN," & _
                                    "SOF.NEGOCIACAO N" & _
                              " WHERE PN.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                                " AND PN.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO" & _
                                " AND N.IC_STATUS = 'F'" & _
                                " AND PN.SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)
                    Qt = DBQuery_ValorUnico(SqlText)

                    If Qt <> 0 Then
                        Msg_Mensagem("Esse pagamento já foi aplicado em uma negociação que esta fechada.")
                        Exit Sub
                    End If

                    If Not Msg_Perguntar("Deseja retirar a aplicação da Negociação/Contrato PAF?") Then Exit Sub
                    IcCtrPAF = True
                    IcNeg = True
                End If
            Else
                SqlText = "SELECT COUNT(*) AS QT " & _
                          " FROM SOF.PAG_NEG_CTR_FIX PNCF," & _
                                "SOF.CONTRATO_FIXO CF" & _
                          " WHERE PNCF.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                            " AND PNCF.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO" & _
                            " AND PNCF.SQ_CONTRATO_FIXO = CF.SQ_CONTRATO_FIXO" & _
                            " AND CF.IC_STATUS = 'F'" & _
                            " AND PNCF.SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)
                Qt = DBQuery_ValorUnico(SqlText)

                If Qt <> 0 Then
                    Msg_Mensagem("Esse pagamento já foi aplicado em um contrato fixo que esta fechado.")
                    Exit Sub
                End If

                If Not Msg_Perguntar("Deseja retirar a aplicação do Contrato Fixo/Negociação/Contrato PAF?") Then Exit Sub

                ApagarContratoFixo = True
                IcNeg = True
                IcCtrPAF = True
            End If
        End If

        On Error GoTo Erro

        If FilialFechada(FilialLogada) Then Exit Sub

        'Verifica novamente o status da interface para verificar se ela não foi atualizada
        SqlText = "SELECT NVL(IC_INTERFACE_ENVIADA, 'N') IC_INTERFACE_ENVIADA FROM SOF.PAGAMENTOS" & _
                  " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)
        oData = DBQuery(SqlText)

        If oData.Rows.Count = 0 Then
            Msg_Mensagem("Registro já foi eliminado.")
            Exit Sub
        End If

        If oData.Rows(0).Item("IC_INTERFACE_ENVIADA") = "S" Then
            Msg_Mensagem("A interface do pagamento já foi enviada.")
            Exit Sub
        End If

        oData.Dispose()
        oData = Nothing

        DBUsarTransacao = True

        SqlText = "DELETE FROM SOF.INTERFACE_PAG_X_PAG" & _
                  " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)
        DBExecutar(SqlText)

        If ApagarContratoFixo = True Then
            SqlText = "DELETE FROM SOF.PAG_NEG_CTR_FIX" & _
                      " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)
            DBExecutar(SqlText)
        End If

        If IcNeg = True Then
            SqlText = "DELETE FROM SOF.PAG_NEG" & _
                      " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)
            DBExecutar(SqlText)
        End If

        If IcCtrPAF = True Then
            SqlText = "DELETE FROM SOF.PAG_CTR_PAF" & _
                      " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)
            DBExecutar(SqlText)
        End If

        SqlText = DBMontar_SP("SOF.ELIMINA_PAGAMENTO", False, ":PAG")

        If Not DBExecutar(SqlText, DBParametro_Montar("PAG", objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO))) Then GoTo Erro
        If Not DBExecutarTransacao(SqlText) Then GoTo Erro

        Pesquisar()

        Exit Sub

Erro:
        Pesquisar()
    End Sub

    Private Sub ApagarParcial()
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim SqlText As String

        On Error GoTo Erro

        If CampoNulo(objGrid_Valor(grdGeral, cnt_GridGeral_SQ_ITEM_MOV_BANCARIO)) Then
            Msg_Mensagem("Este pagamento não é de cheque.")
            Exit Sub
        End If
        If objGrid_Valor(grdGeral, cnt_GridGeral_ValorPagamento, , 0) <> _
           objGrid_Valor(grdGeral, cnt_GridGeral_VL_A_FIXAR, , 0) Then
            Msg_Mensagem("Este pagamento já foi fixado.")
            Exit Sub
        End If

        If Not Msg_Perguntar("Apagar o pagamento e deixa o item de cheque ?") Then Exit Sub

        SqlText = "DELETE FROM SOF.PAGAMENTOS WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO)
        If Not DBExecutar(SqlText) Then GoTo Erro

        Pesquisar()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "PAGAMENTOS", "SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO))
    End Sub

    Private Sub cmdApagarParcial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApagarParcial.Click
        ApagarParcial()
    End Sub

    Private Sub frmConsultaPagamento_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdNovo.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdInterfaceJDE.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdAlterar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdApagarParcial.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
    End Sub

    Private Sub cmdInterfaceJDE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInterfaceJDE.Click
        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdGeral, cnt_GridGeral_Interfaciado, , "X") = "X" Then
            Msg_Mensagem("O lançamento não gera interface.")
            Exit Sub
        End If

        On Error GoTo Erro

        If objGrid_Valor(grdGeral, cnt_GridGeral_Interfaciado, , "N") = "S" Then
            If Not Msg_Perguntar("Desmarca o lançamento como interface enviada ?") Then Exit Sub

            SqlText = "UPDATE SOF.PAGAMENTOS" & _
                      " SET IC_INTERFACE_ENVIADA = 'N'" & _
                      " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO, , 0)
        Else
            If Not Msg_Perguntar("Marca o lançamento como interface enviada ?") Then Exit Sub

            SqlText = "UPDATE SOF.PAGAMENTOS" & _
                      " SET IC_INTERFACE_ENVIADA = 'S'" & _
                      " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_PAGAMENTO, , 0)
        End If

        If Not DBExecutar(SqlText) Then GoTo Erro

        Pesquisar()

        Exit Sub

Erro:
        TratarErro(, , "frmConsultaPagamento.cmdInterfaceJDE_Click")
    End Sub
End Class