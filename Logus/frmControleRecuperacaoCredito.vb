Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Logus.eDbType

Public Class frmControleRecuperacaoCredito
    Const cnt_GridOcorrencia_Seq As Integer = 0
    Const cnt_GridOcorrencia_Data As Integer = 1
    Const cnt_GridOcorrencia_Assunto As Integer = 2
    Const cnt_GridOcorrencia_Descricao As Integer = 3

    Const cnt_GridItens_Contrato_PAF As Integer = 0
    Const cnt_GridItens_Negociação As Integer = 1
    Const cnt_GridItens_Contrato_Fixo As Integer = 2
    Const cnt_GridItens_Valor As Integer = 3
    Const cnt_GridItens_Quantidade As Integer = 4

    Const cnt_GridParcela_Numero As Integer = 0
    Const cnt_GridParcela_Data As Integer = 1
    Const cnt_GridParcela_Situacao As Integer = 2
    Const cnt_GridParcela_Forma As Integer = 3
    Const cnt_GridParcela_Quantidade As Integer = 4
    Const cnt_GridParcela_Valor As Integer = 5
    Const cnt_GridParcela_ValorComJuros As Integer = 6
    Const cnt_GridParcela_Vencimento As Integer = 7
    Const cnt_GridParcela_Descricao As Integer = 8
    Const cnt_GridParcela_ParcelaAnterior As Integer = 9

    Const cnt_GridParcela_1_DataPagamento As Integer = 0
    Const cnt_GridParcela_1_Situacao As Integer = 1
    Const cnt_GridParcela_1_Forma As Integer = 2
    Const cnt_GridParcela_1_Quantidade As Integer = 3
    Const cnt_GridParcela_1_ValorTotal As Integer = 4
    Const cnt_GridParcela_1_Descricao As Integer = 5
    Const cnt_GridParcela_1_NU_PARCELA As Integer = 6
    Const cnt_GridParcela_1_IC_CACAU As Integer = 7
    Const cnt_GridParcela_1_IC_MOEDA As Integer = 8
    Const cnt_GridParcela_1_SQ_CONFISSAO_DIVIDA_ATIVO As Integer = 9

    Const cnt_GridParcela_2_DataVenda As Integer = 0
    Const cnt_GridParcela_2_Quantidade As Integer = 1
    Const cnt_GridParcela_2_ValorTotal As Integer = 2
    Const cnt_GridParcela_2_Contrato As Integer = 3
    Const cnt_GridParcela_2_SQ_CONFISSAO_DIVIDA_ATIVO As Integer = 4
    Const cnt_GridParcela_2_SQ_CONF_DIV_ATIVO_VENDA As Integer = 5

    Const cnt_SEC_Tela As String = "Transacao_ControleRecuperacaoCredito"

    Dim SqConfissaoDivida As Integer
    Dim CdModalidadeAtual As Integer
    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim oDSParcela As New DataSet
    Dim WithEvents oForm As frmCadastroRecuperacaoParcela
    Dim WithEvents oFormRecebimento As frmCadastroRecuperacaoParcelaRecebimento

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String

        If txtAssunto.Text = "" Then
            Msg_Mensagem("Favor informar um assunto.")
            txtAssunto.Focus()
            Exit Sub
        End If

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar a descrição da ocorrencia.")
            txtDescricao.Focus()
            Exit Sub
        End If

        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONF_DIV_OCORRENCIA", False, ":SQCONFISSAODIVIDA", _
                                                                   ":DTOCORRENCIA", _
                                                                   ":DSASSUNTO", _
                                                                   ":DSOCORRENCIA")

        If Not DBExecutar(SqlText, DBParametro_Montar("SQCONFISSAODIVIDA", SqConfissaoDivida), _
                                   DBParametro_Montar("DTOCORRENCIA", Date_to_Oracle(DataSistema)), _
                                   DBParametro_Montar("DSASSUNTO", txtAssunto.Text, OracleClient.OracleType.VarChar, , 4000), _
                                   DBParametro_Montar("DSOCORRENCIA", txtDescricao.Text, OracleClient.OracleType.VarChar, , 4000)) Then GoTo Erro

        ExecutaConsultaOcorrencia()
        txtAssunto.Text = ""
        txtDescricao.Text = ""


        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub frmControleRecuperacaoCredito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT   count(*) "
        SqlText = SqlText & "    FROM sof.confissao_divida c, "
        SqlText = SqlText & "         sof.confissao_divida_parcela cp, "
        SqlText = SqlText & "         sof.confissao_divida_modalidade cm "
        SqlText = SqlText & "   WHERE cp.ic_situacao(+) = 'A' "
        SqlText = SqlText & "     AND c.sq_confissao_divida = cp.sq_confissao_divida(+) "
        SqlText = SqlText & "     AND c.ic_status = 'A' "
        SqlText = SqlText & "     AND c.cd_confissao_divida_modalidade = cm.cd_confissao_divida_modalidade "
        SqlText = SqlText & "     AND cm.ic_provissoria = 'N' "
        SqlText = SqlText & "    and c.DT_FECHAMENTO is null"
        SqlText = SqlText & "     AND c.SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida
        SqlText = SqlText & "GROUP BY c.sq_confissao_divida "
        SqlText = SqlText & "  HAVING SUM (DECODE (cp.ic_situacao, NULL, 0, 1)) = 0 "

        oData = DBQuery(SqlText)

        If DBQuery_ValorUnico(SqlText) > 0 Then
            SqlText = " UPDATE SOF.CONFISSAO_DIVIDA "
            SqlText = SqlText & "        SET DT_FECHAMENTO = '" & Date_to_Oracle(DataSistema) & "', "
            SqlText = SqlText & "            IC_STATUS = 'F' "
            SqlText = SqlText & "        WHERE SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida

            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub frmControleRecuperacaoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SqConfissaoDivida = Filtro

        ComboBox_Carregar_Modalidade_Recuperacao(cboModalidade)

        objGrid_Inicializar(grdParcelas, , oDSParcela, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, , ViewStyleBand.Vertical)
        objGrid_Coluna_Add(grdParcelas, "Parcela", 60, , , , , cnt_Formato_NumeroInteiro)
        objGrid_Coluna_Add(grdParcelas, "Data", 80, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdParcelas, "Situação", 80)
        objGrid_Coluna_Add(grdParcelas, "Forma", 80)
        objGrid_Coluna_Add(grdParcelas, "Quantidade", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdParcelas, "Valor", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdParcelas, "Valor Com Juros", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdParcelas, "Vencimento", 80, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdParcelas, "Descrição", 240)
        objGrid_Coluna_Add(grdParcelas, "Parcela Anterior", 80)

        DBData_Criar(oDSParcela, "Ativo", New String() {"Data Pagamento", "Situação", "Forma", "Quantidade", "Valor Total", "Descrição", _
                                                        "NU_PARCELA", "IC_CACAU", "IC_MOEDA", "SQ_CONFISSAO_DIVIDA_ATIVO"}, _
                                          New eDbType() {_Data, _Texto, _Texto, _Numero, _Numero, _Texto, _Decimal, _Texto, _Texto, _Decimal})
        DBData_Criar(oDSParcela, "Venda", New String() {"Data Venda", "Quantidade", "Valor Total", "Contrato", "SQ_CONFISSAO_DIVIDA_ATIVO", "SQ_CONF_DIV_ATIVO_VENDA"}, _
                                          New eDbType() {_Data, _Numero, _Numero, _Texto, _Decimal, _Decimal})

        DBData_Relationamento_Criar(oDSParcela, "FK_Ativo", oDSParcela.Tables(0), New String() {oDSParcela.Tables(0).Columns(cnt_GridParcela_Numero).ColumnName}, _
                                                            oDSParcela.Tables(1), New String() {"NU_PARCELA"})
        DBData_Relationamento_Criar(oDSParcela, "FK_Vendas", oDSParcela.Tables(1), New String() {"SQ_CONFISSAO_DIVIDA_ATIVO"}, _
                                                             oDSParcela.Tables(2), New String() {"SQ_CONFISSAO_DIVIDA_ATIVO"})

        objGrid_Band_Formatar(grdParcelas.DisplayLayout.Bands(1), UltraWinGrid.CellClickAction.RowSelect)

        With grdParcelas.DisplayLayout.Bands(1)
            objGrid_Coluna_Formatar(grdParcelas, .Columns(cnt_GridParcela_1_DataPagamento), "", 100, , , , cnt_Formato_Data)
            objGrid_Coluna_Formatar(grdParcelas, .Columns(cnt_GridParcela_1_Quantidade), "", 100, , , , cnt_Formato_Kilos)
            objGrid_Coluna_Formatar(grdParcelas, .Columns(cnt_GridParcela_1_ValorTotal), "", 100, , , , cnt_Formato_Valor)
            objGrid_Coluna_Formatar(grdParcelas, .Columns(cnt_GridParcela_1_NU_PARCELA), "", 0)
            objGrid_Coluna_Formatar(grdParcelas, .Columns(cnt_GridParcela_1_IC_CACAU), "", 0)
            objGrid_Coluna_Formatar(grdParcelas, .Columns(cnt_GridParcela_1_IC_MOEDA), "", 0)
            objGrid_Coluna_Formatar(grdParcelas, .Columns(cnt_GridParcela_1_SQ_CONFISSAO_DIVIDA_ATIVO), "", 0)
        End With

        objGrid_Band_Formatar(grdParcelas.DisplayLayout.Bands(2), UltraWinGrid.CellClickAction.RowSelect)

        With grdParcelas.DisplayLayout.Bands(2)
            objGrid_Coluna_Formatar(grdParcelas, .Columns(cnt_GridParcela_2_DataVenda), "", 100, , , , cnt_Formato_Data)
            objGrid_Coluna_Formatar(grdParcelas, .Columns(cnt_GridParcela_2_Quantidade), "", 100, , , , cnt_Formato_Kilos)
            objGrid_Coluna_Formatar(grdParcelas, .Columns(cnt_GridParcela_2_ValorTotal), "", 100, , , , cnt_Formato_Valor)
            objGrid_Coluna_Formatar(grdParcelas, .Columns(cnt_GridParcela_2_SQ_CONFISSAO_DIVIDA_ATIVO), "", 0)
            objGrid_Coluna_Formatar(grdParcelas, .Columns(cnt_GridParcela_2_SQ_CONF_DIV_ATIVO_VENDA), "", 0)
        End With

        objGrid_Inicializar(grdOcorrencia, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdOcorrencia, "Seq", 0)
        objGrid_Coluna_Add(grdOcorrencia, "Data", 80)
        objGrid_Coluna_Add(grdOcorrencia, "Assunto", 180, , , , , , DefaultableBoolean.True)
        objGrid_Coluna_Add(grdOcorrencia, "Descrição", 400, , , , , , DefaultableBoolean.True)

        ExecutaConsultaItens()

        objGrid_Inicializar(grdItens)
        objGrid_Coluna_Add(grdItens, "Contrato PAF", 100, cnt_GridItens_Contrato_PAF)
        objGrid_Coluna_Add(grdItens, "Negociação", 100, cnt_GridItens_Negociação)
        objGrid_Coluna_Add(grdItens, "Contrato Fixo", 100, cnt_GridItens_Contrato_Fixo)
        objGrid_Coluna_Add(grdItens, "Valor", 100, cnt_GridItens_Valor, , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdItens, "Quantidade", 140, cnt_GridItens_Quantidade, , , , cnt_Formato_Kilos)

        objGrid_ExibirTotal(grdItens, New Integer() {cnt_GridItens_Valor, cnt_GridItens_Quantidade})

        ExecutaConsultaParcela()
        ExecutaConsultaOcorrencia()
        grdOcorrencia.DisplayLayout.Bands(0).Override.AllowDelete = DefaultableBoolean.True

        SEC_ValidarBotao_Permissao(cmdRenegociar, SEC_Permissao.SEC_P_Acesso_RenegociarRecuperacaoCredito, True)
        SEC_ValidarBotao_Permissao(cmdPagar, SEC_Permissao.SEC_P_Acesso_PagarRecuperacaoCredito, True)
        SEC_ValidarBotao_Permissao(cmdQuebrar, SEC_Permissao.SEC_P_Acesso_QuebrarRecuperacaoCredito, True)
        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        CarregaDados()

    End Sub

    Private Sub ExecutaConsultaOcorrencia()
        Dim SqlText As String

        SqlText = "SELECT a.sq_ocorrencia, a.dt_ocorrencia, "
        SqlText = SqlText & "       a.ds_assunto, a.ds_ocorrencia "
        SqlText = SqlText & "FROM sof.confissao_divida_ocorrencia a "
        SqlText = SqlText & "where a.sq_confissao_divida = " & SqConfissaoDivida

        objGrid_Carregar(grdOcorrencia, SqlText, New Integer() {cnt_GridOcorrencia_Seq, _
                                                                cnt_GridOcorrencia_Data, _
                                                                cnt_GridOcorrencia_Assunto, _
                                                                cnt_GridOcorrencia_Descricao}, , True)
    End Sub

    Private Sub ExecutaConsultaParcela()
        Dim SqlText As String

        SqlText = "SELECT CDP.NU_PARCELA," & _
                         "CDP.DT_LANCAMENTO," & _
                         "DECODE(CDP.IC_SITUACAO,'A','EM ABERTO','C','CANCELADA','P','PAGA','') AS IC_SITUACAO,"
        SqlText = SqlText & "       DECODE (CDP.IC_CACAU, "
        SqlText = SqlText & "               'S', 'Cacau', "
        SqlText = SqlText & "               DECODE (CDP.IC_MOEDA, "
        SqlText = SqlText & "                       'S', 'Dinheiro', "
        SqlText = SqlText & "                       DECODE (CDP.IC_OUTROS, 'S', 'Sld CTR', '') "
        SqlText = SqlText & "                      ) "
        SqlText = SqlText & "              ) CD_FORMA, "
        SqlText = SqlText & "       CDP.QT_ITEM_PARCELA, CDP.VL_PARCELA, "
        SqlText = SqlText & "       round(DECODE (CDP.IC_SITUACAO, "
        SqlText = SqlText & "               'A', CDP.VL_PARCELA "
        SqlText = SqlText & "                * (  1 "
        SqlText = SqlText & "                   + (  (SYSDATE - CD.DT_COBRA_JUROS) "
        SqlText = SqlText & "                      * (CD.PC_JUROS_AO_MES / 30) "
        SqlText = SqlText & "                      / 100 "
        SqlText = SqlText & "                     ) "
        SqlText = SqlText & "                  ), "
        SqlText = SqlText & "               0 "
        SqlText = SqlText & "              ),2) VL_ATUAL, "
        SqlText = SqlText & "       CDP.DT_VENCIMENTO, CDP.DS_OUTROS, CDP.NU_PARCELA_ANTERIOR "
        SqlText = SqlText & "  FROM SOF.CONFISSAO_DIVIDA_PARCELA CDP, SOF.CONFISSAO_DIVIDA CD "
        SqlText = SqlText & " WHERE CDP.SQ_CONFISSAO_DIVIDA = CD.SQ_CONFISSAO_DIVIDA "
        SqlText = SqlText & "   AND CDP.SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida

        DBQuery_Append(oDSParcela.Tables(0), SqlText, True)

        ExecutaConsultaAtivo()
        ExecutaConsultaVenda()
    End Sub

    Private Sub ExecutaConsultaAtivo()
        Dim SqlText As String

        SqlText = "SELECT CDA.DT_PAGAMENTO," & _
                         "decode(CDA.IC_STATUS,'A','Em Aberto','V','Vendido','') as IC_STATUS," & _
                         "DECODE(CDA.IC_CACAU, 'S', 'Cacau', DECODE(CDA.IC_MOEDA,'S','Dinheiro',DECODE(CDA.IC_OUTROS,'S','Sld CTR',''))) CD_FORMA, " & _
                         "CDA.QT_ITEM_ATIVO," & _
                         "CDA.VL_ATIVO," & _
                         "CDA.DS_OUTROS," & _
                         "CDA.NU_PARCELA," & _
                         "CDA.IC_CACAU," & _
                         "CDA.IC_MOEDA," & _
                         "CDA.SQ_CONFISSAO_DIVIDA_ATIVO" & _
                  " FROM SOF.CONFISSAO_DIVIDA_ATIVO CDA " & _
                  " WHERE CDA.SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida

        DBQuery_Append(oDSParcela.Tables(1), SqlText)
    End Sub

    Private Sub ExecutaConsultaVenda()
        Dim SqlText As String

        SqlText = "SELECT CDAV.DT_VENDA," & _
                         "CDAV.QT_ITEM_VENDA," & _
                         "CDAV.VL_VENDA," & _
                         "DECODE(CDAV.CD_CONTRATO_PAF, NULL," & _
                                                      "NULL," & _
                                                      "TO_CHAR(CDAV.CD_CONTRATO_PAF) || '-' ||" & _
                                                        "TO_CHAR(CDAV.SQ_NEGOCIACAO) || '-' ||" & _
                                                        "TO_CHAR(CDAV.SQ_CONTRATO_FIXO)) CD_CONTRATO," & _
                         "CDAV.SQ_CONFISSAO_DIVIDA_ATIVO," & _
                         "CDAV.SQ_CONF_DIV_ATIVO_VENDA" & _
                  " FROM SOF.CONFISSAO_DIVIDA_ATIVO CDA," & _
                        "SOF.CONFISSAO_DIVIDA_ATIVO_VENDA CDAV" & _
                  " WHERE CDA.SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida & _
                    " AND CDAV.SQ_CONFISSAO_DIVIDA_ATIVO = CDA.SQ_CONFISSAO_DIVIDA_ATIVO"

        DBQuery_Append(oDSParcela.Tables(2), SqlText)
    End Sub

    Private Sub ExecutaConsultaItens()
        Dim SqlText As String

        sqltext = "SELECT   cd_contrato_paf, sq_negociacao, sq_contrato_fixo, "
        sqltext = sqltext & "         SUM (vl_fixo) vl_fixo, SUM (qt_cancelado) qt_cancelado "
        sqltext = sqltext & "    FROM (SELECT pcp.cd_contrato_paf, pncf.sq_negociacao, "
        sqltext = sqltext & "                 pncf.sq_contrato_fixo, "
        sqltext = sqltext & "                 0 - NVL (pncf.vl_fixo, pcp.vl_fixo) vl_fixo, 0 qt_cancelado "
        sqltext = sqltext & "            FROM sof.pag_ctr_paf pcp, "
        sqltext = sqltext & "                 sof.pag_neg_ctr_fix pncf, "
        sqltext = sqltext & "                 sof.pagamentos p "
        sqltext = sqltext & "           WHERE pcp.cd_contrato_paf = pncf.cd_contrato_paf(+) "
        sqltext = sqltext & "             AND pcp.sq_pagamento = pncf.sq_pagamento(+) "
        sqltext = sqltext & "             AND pcp.sq_pag_ctr_paf = pncf.sq_pag_ctr_paf(+) "
        sqltext = sqltext & "             AND pcp.sq_pagamento = p.sq_pagamento "
        sqltext = sqltext & "             AND p.sq_conf_div_ativo_venda IS NULL "
        SqlText = SqlText & "             AND pcp.sq_confissao_divida = " & SqConfissaoDivida
        sqltext = sqltext & "             AND pcp.ic_confissao_divida_estorno = 'S' "
        SqlText = SqlText & "             AND pncf.sq_confissao_divida(+) = " & SqConfissaoDivida
        sqltext = sqltext & "          UNION ALL "
        sqltext = sqltext & "          SELECT cpc.cd_contrato_paf, cfc.sq_negociacao, cfc.sq_contrato_fixo, "
        sqltext = sqltext & "                 0 vl_fixo, "
        sqltext = sqltext & "                 NVL (cfc.qt_cancelado, cpc.qt_cancelado) qt_cancelado "
        sqltext = sqltext & "            FROM sof.contrato_paf_cancelado cpc, "
        sqltext = sqltext & "                 sof.contrato_fixo_cancelado cfc "
        sqltext = sqltext & "           WHERE cpc.cd_contrato_paf = cfc.cd_contrato_paf(+) "
        SqlText = SqlText & "             AND cpc.sq_confissao_divida = " & SqConfissaoDivida
        SqlText = SqlText & "             AND cfc.sq_confissao_divida(+) = " & SqConfissaoDivida & ") "
        sqltext = sqltext & "GROUP BY cd_contrato_paf, sq_negociacao, sq_contrato_fixo "

        objGrid_Carregar(grdItens, SqlText)
    End Sub

    Private Sub grdOcorrencia_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdOcorrencia.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        If Msg_Perguntar("Deseja excluir a ocorrência?") Then
            If Not DBExecutar_Delete("SOF.confissao_divida_ocorrencia", "sq_confissao_divida", SqConfissaoDivida, _
                " AND ", "sq_ocorrencia", e.Rows(0).Cells(cnt_GridOcorrencia_Seq).Value) Then GoTo Erro

            ExecutaConsultaOcorrencia()
        Else
            e.Cancel = True
        End If
Erro:
        e.Cancel = True
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdOcorrencia, Me.Text, cmdExcell)
    End Sub

    Private Sub CarregaDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT CD.CD_FORNECEDOR," & _
                         "F.NO_RAZAO_SOCIAL," & _
                         "CD.VL_NEGOCIADO," & _
                         "CD.VL_ORIGINAL," & _
                         "CD.QT_ORIGINAL," & _
                         "DT_FECHAMENTO," & _
                         "CDM.NO_CONFISSAO_DIVIDA_MODALIDADE," & _
                         "CDM.CD_CONFISSAO_DIVIDA_MODALIDADE," & _
                         "FC.NO_RAZAO_SOCIAL NO_FORNECEDOR_CONTRATO," & _
                         "CD.CD_FORNECEDOR_CONTRATO," & _
                         "CDM.IC_PROVISSORIA," & _
                         "NVL(CD.IC_COBRA_JUROS,'N') IC_COBRA_JUROS," & _
                         "CD.DT_COBRA_JUROS," & _
                         "CD.PC_JUROS_AO_MES" & _
                  " FROM SOF.CONFISSAO_DIVIDA CD," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.CONFISSAO_DIVIDA_MODALIDADE CDM," & _
                        "SOF.FORNECEDOR FC" & _
                  " WHERE CD.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND CD.CD_CONFISSAO_DIVIDA_MODALIDADE = CDM.CD_CONFISSAO_DIVIDA_MODALIDADE" & _
                    " AND CD.CD_FORNECEDOR_CONTRATO = FC.CD_FORNECEDOR" & _
                    " AND CD.SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            Pesq_FornecedorRecuperacao.Codigo = oData.Rows(0).Item("CD_FORNECEDOR")
            txtValorNegociado.Value = oData.Rows(0).Item("VL_NEGOCIADO")
            txtValorEnvolvido.Value = oData.Rows(0).Item("VL_ORIGINAL")
            txtQuantidadeEnvolvida.Value = oData.Rows(0).Item("QT_ORIGINAL")

            If CampoNulo(oData.Rows(0).Item("DT_FECHAMENTO")) Then
                'ICFECHADA = FALSE
            Else
                'ICFECHADA = TRUE
                cmdAlterar.Visible = False
                cmdNovo.Visible = False
                cmdExcluir.Visible = False
                cmdQuebrar.Visible = False
                cmdRenegociar.Visible = False
                cmdPagar.Visible = False
            End If

            ComboBox_Possicionar(cboModalidade, oData.Rows(0).Item("CD_CONFISSAO_DIVIDA_MODALIDADE"))
            CdModalidadeAtual = oData.Rows(0).Item("CD_CONFISSAO_DIVIDA_MODALIDADE")
            Pesq_FornecedorContrato.Codigo = oData.Rows(0).Item("CD_FORNECEDOR_CONTRATO")

            If oData.Rows(0).Item("IC_COBRA_JUROS") = "S" Then
                txtDataInicioCobraJuros.Value = oData.Rows(0).Item("DT_COBRA_JUROS")
                txtJurosAoMes.Value = NVL(oData.Rows(0).Item("PC_JUROS_AO_MES"), 0)
                chkJuros.Checked = True
            End If

            If oData.Rows(0).Item("IC_PROVISSORIA") = "S" Then
                tabParcelas.Enabled = False
            End If
            If oData.Rows(0).Item("IC_COBRA_JUROS") = "N" Then
                grdParcelas.DisplayLayout.Bands(0).Columns(cnt_GridParcela_ValorComJuros).Hidden = True
            End If
        End If
    End Sub

    Private Sub chkJuros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkJuros.CheckedChanged
        If chkJuros.Checked = True Then
            txtJurosAoMes.Enabled = True
            txtDataInicioCobraJuros.Enabled = True
        Else
            txtJurosAoMes.Enabled = False
            txtDataInicioCobraJuros.Enabled = False
            txtDataInicioCobraJuros.Value = Nothing
        End If

        If chkJuros.Enabled = False Then
            txtJurosAoMes.Enabled = False
            txtDataInicioCobraJuros.Enabled = False
        End If
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        cboModalidade.Enabled = True
        chkJuros.Enabled = True
        chkJuros_CheckedChanged(Nothing, Nothing)
        cmdAlterar.Visible = True
        cmdGravar_Alteracao.Visible = True
        cmdGravar_Alteracao.Top = cmdAlterar.Top
        cmdGravar_Alteracao.Left = cmdAlterar.Left
    End Sub

    Private Sub cmdGravar_Alteracao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_Alteracao.Click
        Dim SqlText As String
        Dim IcCont As String

        If Not ComboBox_LinhaSelecionada(cboModalidade) Then
            Msg_Mensagem("Favor selecionar a nova modalidade.")
            Exit Sub
        End If

        If CdModalidadeAtual <> cboModalidade.SelectedValue Then
            SqlText = "SELECT COUNT (*)" & _
                      " FROM SOF.CONFISSAO_DIVIDA_MODALIDADE" & _
                      " WHERE IC_PROVISSORIA = 'S'" & _
                        " AND CD_CONFISSAO_DIVIDA_MODALIDADE = 1 "

            If DBQuery_ValorUnico(SqlText) <> 0 Then
                Msg_Mensagem("A alteração de modalidade não é possível pois a nova modalidade é provisória.")
                Exit Sub
            End If

            SqlText = "SELECT count(*) "
            SqlText = SqlText & "  FROM SOF.CONFISSAO_DIVIDA CD, SOF.CONFISSAO_DIVIDA_MODALIDADE CDM, SOF.confissao_divida_parametro CDP, SOF.confissao_divida_parametro CDPNEW "
            SqlText = SqlText & "  WHERE CD.cd_confissao_divida_modalidade =CDM.cd_confissao_divida_modalidade  "
            SqlText = SqlText & "  AND CDM.cd_confissao_divida_modalidade =CDP.cd_confissao_divida_modalidade  "
            SqlText = SqlText & "  AND CDP.cd_conciliacao_modalidade_pag =CDPNEW.cd_conciliacao_modalidade_pag  "
            SqlText = SqlText & "  AND CDPNEW.cd_confissao_divida_modalidade = " & cboModalidade.SelectedValue
            SqlText = SqlText & "  AND CD.sq_confissao_divida = " & SqConfissaoDivida

            'caso seja diferente verifico se tem parcela paga se tiver nao pode alterar
            If DBQuery_ValorUnico(SqlText) = 0 Then
                IcCont = "S"

                SqlText = "select count(*) "
                SqlText = SqlText & "from sof.confissao_divida_parcela p "
                SqlText = SqlText & "where p.sq_confissao_divida = " & SqConfissaoDivida
                SqlText = SqlText & "and p.ic_situacao ='P' "

                If DBQuery_ValorUnico(SqlText) <> 0 Then
                    Msg_Mensagem("A alteração de modalidade não é possível pois a nova modalidade contabiliza em contas diferentes e já tem parcelas pagas.")
                    Exit Sub
                End If
            Else
                IcCont = "N"
            End If

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CONF_DIV_ALTERACAO", False, ":sqconfmodant", _
                                                                               ":sqconfmodnova", _
                                                                               ":iccontabiliza", _
                                                                               ":sqconfdiv")

            If Not DBExecutar(SqlText, DBParametro_Montar("sqconfmodant", CdModalidadeAtual), _
                                       DBParametro_Montar("sqconfmodnova", cboModalidade.SelectedValue), _
                                       DBParametro_Montar("iccontabiliza", IcCont), _
                                       DBParametro_Montar("sqconfdiv", SqConfissaoDivida)) Then GoTo Erro
            tabParcelas.Enabled = True

        End If

        SqlText = "update sof.confissao_divida set   "
        SqlText = SqlText & "   ic_cobra_juros= '" & IIf(chkJuros.Checked, "S", "N") & "', "
        If chkJuros.Checked = True Then
            SqlText = SqlText & "   dt_cobra_juros = '" & Date_to_Oracle(txtDataInicioCobraJuros.Text) & "', "
            SqlText = SqlText & "   pc_juros_ao_mes =" & txtJurosAoMes.Value & ", "
        Else
            SqlText = SqlText & "   dt_cobra_juros=null, "
            SqlText = SqlText & "   pc_juros_ao_mes=null , "
        End If
        SqlText = SqlText & "   dt_alteracao = sysdate, "
        SqlText = SqlText & "   no_user_alteracao ='" & sAcesso_UsuarioLogado & "'"
        SqlText = SqlText & "where sq_confissao_divida = " & SqConfissaoDivida

        If Not DBExecutar(SqlText) Then GoTo Erro

        cboModalidade.Enabled = False
        chkJuros.Enabled = False
        txtDataInicioCobraJuros.Enabled = False
        txtJurosAoMes.Enabled = False
        cmdGravar_Alteracao.Visible = False
        cmdAlterar.Visible = True
        cmdAlterar.Enabled = False

        Msg_Mensagem("Alteração feita com sucesso.")

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub frmControleRecuperacaoCredito_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'TAB Parcela
        grdParcelas.Height = tabParcelas.Height - 60
        grdParcelas.Width = tabParcelas.Width - 20
        cmdPagar.Top = Me.tabParcelas.Height - cmdExcell_Parcela.Height - 3
        cmdExcell_Parcela.Top = Me.tabParcelas.Height - cmdExcell_Parcela.Height - 3
        cmdQuebrar.Top = Me.tabParcelas.Height - cmdExcell_Parcela.Height - 3
        cmdRenegociar.Top = Me.tabParcelas.Height - cmdExcell_Parcela.Height - 3
        cmdExcluir.Top = Me.tabParcelas.Height - cmdExcell_Parcela.Height - 3
        cmdNovo.Top = Me.tabParcelas.Height - cmdExcell_Parcela.Height - 3
        'TAB Historico
        txtAssunto.Width = tabHistorico.Width - txtAssunto.Left - 10
        txtDescricao.Width = tabHistorico.Width - 20
        grdOcorrencia.Height = tabHistorico.Height - grdOcorrencia.Top - 10
        grdOcorrencia.Width = tabHistorico.Width - 20
        'TAB Itens
        grdItens.Height = tabItens.Height - 35
        grdItens.Width = tabItens.Width - 20
    End Sub

    Private Sub cmdExcell_Parcela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell_Parcela.Click
        objGrid_ExportarExcell(grdParcelas, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        oForm = New frmCadastroRecuperacaoParcela
        oForm.SqConfissaoDivida = SqConfissaoDivida
        oForm.NuParcelaAnterior = Nothing
        oForm.oTipoRecuperacaoParcela = frmCadastroRecuperacaoParcela.eTipoRecuperacaoParcela.CadastroNovaParcela

        Form_Show(Me.MdiParent, oForm, True)
    End Sub

    Private Sub cmdRenegociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRenegociar.Click
        If objGrid_LinhaSelecionada(grdParcelas) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If
        If objGrid_Valor(grdParcelas, cnt_GridParcela_1_Situacao, , , , 1) = "CANCELADA" Or _
           objGrid_Valor(grdParcelas, cnt_GridParcela_1_Situacao, , , , 1) = "PAGA" Then
            Msg_Mensagem("Não é possível renegociar uma parcela que está cancelada ou já foi paga.")
            Exit Sub
        End If

        oForm = New frmCadastroRecuperacaoParcela
        oForm.SqConfissaoDivida = SqConfissaoDivida
        oForm.NuParcelaAnterior = objGrid_Valor(grdParcelas, cnt_GridParcela_Numero)
        oForm.oTipoRecuperacaoParcela = frmCadastroRecuperacaoParcela.eTipoRecuperacaoParcela.Renegociar

        Form_Show(Me.MdiParent, oForm, True)
    End Sub

    Private Sub cmdQuebrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuebrar.Click
        If objGrid_LinhaSelecionada(grdParcelas) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If
        If objGrid_Valor(grdParcelas, cnt_GridParcela_1_Situacao, , , , 1) = "CANCELADA" Or _
           objGrid_Valor(grdParcelas, cnt_GridParcela_1_Situacao, , , , 1) = "PAGA" Then
            Msg_Mensagem("Não é possível quebrar uma parcela que está cancelada ou já foi paga.")
            Exit Sub
        End If

        oForm = New frmCadastroRecuperacaoParcela
        oForm.SqConfissaoDivida = SqConfissaoDivida
        oForm.NuParcelaAnterior = objGrid_Valor(grdParcelas, cnt_GridParcela_Numero)
        oForm.oTipoRecuperacaoParcela = frmCadastroRecuperacaoParcela.eTipoRecuperacaoParcela.QuebrarParcela

        Form_Show(Me.MdiParent, oForm, True)
    End Sub

  
    Private Sub oForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm.FormClosing
        ExecutaConsultaParcela()
        CarregaDados()
    End Sub

    Private Sub cmdPagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPagar.Click
        If objGrid_LinhaSelecionada(grdParcelas) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If
        If objGrid_Valor(grdParcelas, cnt_GridParcela_Situacao) = "CANCELADA" Or _
           objGrid_Valor(grdParcelas, cnt_GridParcela_Situacao) = "PAGA" Then
            Msg_Mensagem("Não é possível pagar uma parcela que está cancelada ou já foi paga.")
            Exit Sub
        End If

        oFormRecebimento = New frmCadastroRecuperacaoParcelaRecebimento
        oFormRecebimento.SqConfissaoDivida = SqConfissaoDivida
        oFormRecebimento.NuParcela = objGrid_Valor(grdParcelas, cnt_GridParcela_Numero)
        Form_Show(Me.MdiParent, oFormRecebimento, True)
    End Sub

    Private Sub VendaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendaToolStripMenuItem.Click
        If objGrid_LinhaSelecionada(grdParcelas, 2) = -1 Then
            Msg_Mensagem("Favor selecionar a venda.")
            Exit Sub
        End If

        If CampoNulo(objGrid_Valor(grdParcelas, cnt_GridParcela_2_SQ_CONF_DIV_ATIVO_VENDA, , , , 2)) Then
            Msg_Mensagem("Não existe venda para essa parcela.")
            Exit Sub
        End If

        If objGrid_Valor(grdParcelas, cnt_GridParcela_2_DataVenda, , , , 2) <> DataSistema() Then
            Msg_Mensagem("Data da contabilização ja fehcada.")
            Exit Sub
        End If

        If Not CampoNulo(objGrid_Valor(grdParcelas, cnt_GridParcela_2_Contrato, , , , 2)) Then
            Msg_Mensagem("Essa venda foi um contrato, favor eliminar o ativo.")
            Exit Sub
        End If

        Dim SqlText As String
        SqlText = "select ic_moeda from sof.confissao_divida_ativo where sq_confissao_divida_ativo=" & objGrid_Valor(grdParcelas, cnt_GridParcela_2_SQ_CONFISSAO_DIVIDA_ATIVO, , , , 2)

        If DBQuery_ValorUnico(SqlText) = "S" Then
            Msg_Mensagem("Essa venda foi em moeda corrente, favor eliminar o ativo.")
            Exit Sub
        End If

        If Msg_Perguntar("Cancela a venda do ativo ?") = False Then Exit Sub

        SqlText = "delete from sof.confissao_divida_ativo_venda where SQ_CONF_DIV_ATIVO_VENDA = " & objGrid_Valor(grdParcelas, cnt_GridParcela_2_SQ_CONF_DIV_ATIVO_VENDA, , , , 2)
        If Not DBExecutar(SqlText) Then GoTo Erro

        SqlText = "update sof.confissao_divida_ativo set ic_status = 'A' " & _
                  "where SQ_CONFISSAO_DIVIDA_ATIVO = " & objGrid_Valor(grdParcelas, cnt_GridParcela_2_SQ_CONFISSAO_DIVIDA_ATIVO, , , , 2)
        If Not DBExecutar(SqlText) Then GoTo Erro

        ExecutaConsultaParcela()
        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub AtivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtivoToolStripMenuItem.Click
        If objGrid_LinhaSelecionada(grdParcelas, 1) = -1 Then
            Msg_Mensagem("Favor selecionar o ativo.")
            Exit Sub
        End If

        If CampoNulo(objGrid_Valor(grdParcelas, cnt_GridParcela_1_SQ_CONFISSAO_DIVIDA_ATIVO, , , , 1)) Then
            Msg_Mensagem("Não existe ativo para essa parcela.")
            Exit Sub
        End If

        If objGrid_Valor(grdParcelas, cnt_GridParcela_1_DataPagamento, , , , 1) <> DataSistema() Then
            Msg_Mensagem("Data da contabilização ja fehcada.")
            Exit Sub
        End If

        If objGrid_Valor(grdParcelas, cnt_GridParcela_1_Situacao, , , , 1) <> "Em Aberto" And objGrid_Valor(grdParcelas, cnt_GridParcela_1_IC_CACAU, , , , 1) = "N" And objGrid_Valor(grdParcelas, cnt_GridParcela_1_IC_MOEDA, , , , 1) = "N" Then
            Msg_Mensagem("Esse ativo ja foi vendido.")
            Exit Sub
        End If

        If Msg_Perguntar("Cancela o ativo ?") = False Then Exit Sub

        Dim SqlText As String
        Dim oData As DataTable
        Dim icont As Integer

        DBUsarTransacao = True

        If objGrid_Valor(grdParcelas, cnt_GridParcela_1_IC_CACAU, , , , 1) = "S" Then
            SqlText = "SELECT cdav.cd_contrato_paf, cdav.sq_negociacao, cdav.sq_contrato_fixo, " & _
                      "cf.ic_status ic_status_contrato, p.sq_pagamento " & _
                      "FROM sof.confissao_divida_ativo_venda cdav, sof.contrato_fixo cf, sof.pagamentos p " & _
                      "where cdav.cd_contrato_paf = cf.cd_contrato_paf and " & _
                      "cdav.sq_negociacao = cf.sq_negociacao and " & _
                      "cdav.sq_contrato_fixo = cf.sq_contrato_fixo and " & _
                      "cdav.sq_conf_div_ativo_venda = p.sq_conf_div_ativo_venda and " & _
                      "cdav.sq_confissao_divida_ativo = " & objGrid_Valor(grdParcelas, cnt_GridParcela_1_SQ_CONFISSAO_DIVIDA_ATIVO, , , , 1)

            oData = DBQuery(SqlText)

            For icont = 0 To oData.Rows.Count - 1
                If oData.Rows(icont).Item("ic_status_contrato") <> "A" Then
                    Err.Raise(vbObjectError + 514, "Parcela Recuperação de Credito", "O Contrato não esta aberto.")
                    Exit Sub
                End If

                SqlText = "delete from sof.PAG_NEG_CTR_FIX where sq_pagamento=" & oData.Rows(icont).Item("sq_pagamento")
                If Not DBExecutar(SqlText) Then GoTo Erro

                SqlText = "delete from sof.PAG_NEG where sq_pagamento=" & oData.Rows(icont).Item("sq_pagamento")
                If Not DBExecutar(SqlText) Then GoTo Erro

                SqlText = "delete from sof.PAG_CTR_PAF where sq_pagamento=" & oData.Rows(icont).Item("sq_pagamento")
                If Not DBExecutar(SqlText) Then GoTo Erro

                SqlText = DBMontar_SP("SOF.ELIMINA_PAGAMENTO", False, ":PAG")
                If Not DBExecutar(SqlText, DBParametro_Montar("PAG", oData.Rows(icont).Item("sq_pagamento"))) Then GoTo Erro
            Next

            SqlText = "delete from sof.confissao_divida_ativo_venda where sq_confissao_divida_ativo = " & objGrid_Valor(grdParcelas, cnt_GridParcela_1_SQ_CONFISSAO_DIVIDA_ATIVO, , , , 1)
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        If objGrid_Valor(grdParcelas, cnt_GridParcela_1_IC_MOEDA) = "S" Then
            SqlText = "delete from sof.confissao_divida_ativo_venda where sq_confissao_divida_ativo = " & objGrid_Valor(grdParcelas, cnt_GridParcela_1_SQ_CONFISSAO_DIVIDA_ATIVO, , , , 1)
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        SqlText = "delete from sof.confissao_divida_ativo where sq_confissao_divida_ativo = " & objGrid_Valor(grdParcelas, cnt_GridParcela_1_SQ_CONFISSAO_DIVIDA_ATIVO, , , , 1)
        If Not DBExecutar(SqlText) Then GoTo Erro


        SqlText = "update sof.confissao_divida_parcela set IC_SITUACAO = 'A' " & _
                  "where sq_confissao_divida = " & SqConfissaoDivida & " and " & _
                  "nu_parcela = " & objGrid_Valor(grdParcelas, cnt_GridParcela_1_NU_PARCELA, , , , 1)
        If Not DBExecutar(SqlText) Then GoTo Erro


        SqlText = "update sof.confissao_divida set dt_fechamento = null, IC_STATUS = 'A' " & _
                  "where sq_confissao_divida = " & SqConfissaoDivida
        If Not DBExecutar(SqlText) Then GoTo Erro


        'SE FOI QUEBRADA RETORNA OS VALORES
        SqlText = "SELECT CDP.vl_parcela ,CDP.qt_item_parcela  FROM sof.confissao_divida_parcela CDP " & _
        "Where cdp.IC_SITUACAO='A' and CDP.Nu_Parcela_Anterior = " & objGrid_Valor(grdParcelas, cnt_GridParcela_1_NU_PARCELA, , , , 1) & _
        " AND CDP.sq_confissao_divida =" & SqConfissaoDivida

        oData = DBQuery(SqlText)

        If oData.Rows.Count <> 0 Then
            Select Case objGrid_Valor(grdParcelas, cnt_GridParcela_1_IC_MOEDA)
                Case "N" 'cacau e outros
                    SqlText = "update sof.confissao_divida_parcela " & _
                              "set vl_parcela = vl_parcela + " & oData.Rows(0).Item("vl_parcela") & ", " & _
                              "qt_item_parcela = qt_item_parcela + " & oData.Rows(0).Item("qt_item_parcela") & " " & _
                              "where sq_confissao_divida = " & SqConfissaoDivida & " and " & _
                              "nu_parcela = " & objGrid_Valor(grdParcelas, cnt_GridParcela_1_NU_PARCELA, , , , 1)
                Case "S" 'dinheiro
                    SqlText = "update sof.confissao_divida_parcela " & _
                              "set vl_parcela = vl_parcela + " & oData.Rows(0).Item("vl_parcela") & " " & _
                              "where sq_confissao_divida = " & SqConfissaoDivida & " and " & _
                              "nu_parcela = " & objGrid_Valor(grdParcelas, cnt_GridParcela_1_NU_PARCELA, , , , 1)
            End Select
            If Not DBExecutar(SqlText) Then GoTo Erro

            SqlText = "delete FROM sof.confissao_divida_parcela CDP " & _
            "Where cdp.IC_SITUACAO='A' and CDP.Nu_Parcela_Anterior = " & objGrid_Valor(grdParcelas, cnt_GridParcela_1_NU_PARCELA, , , , 1) & " AND CDP.sq_confissao_divida =" & SqConfissaoDivida

            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        If Not DBExecutarTransacao() Then GoTo Erro

        ExecutaConsultaParcela()
        CarregaDados()
        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub ParcelaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParcelaToolStripMenuItem.Click
        If objGrid_LinhaSelecionada(grdParcelas) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        If UCase(objGrid_Valor(grdParcelas, cnt_GridParcela_Situacao)) <> UCase("Em Aberto") Then
            Msg_Mensagem("Essa parcela não esta aberta.")
            Exit Sub
        End If

        If Msg_Perguntar("Cancela a parcela ?") = False Then Exit Sub

        Dim SqlText As String

        SqlText = "update sof.confissao_divida_parcela set IC_SITUACAO = 'C' " & _
                  "where sq_confissao_divida = " & SqConfissaoDivida & " and " & _
                  "nu_parcela = " & objGrid_Valor(grdParcelas, cnt_GridParcela_Numero)
        If Not DBExecutar(SqlText) Then GoTo Erro

        SqlText = "UPDATE SOF.CONFISSAO_DIVIDA" & _
                  " SET VL_NEGOCIADO = VL_NEGOCIADO - " & objGrid_Valor(grdParcelas, cnt_GridParcela_Valor) & " " & _
                  " WHERE SQ_CONFISSAO_DIVIDA = " & SqConfissaoDivida
        If Not DBExecutar(SqlText) Then GoTo Erro


        ExecutaConsultaParcela()
        CarregaDados()
        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub oFormRecebimento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oFormRecebimento.FormClosing
        ExecutaConsultaParcela()
        CarregaDados()
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        mnuExclusao.Show(cmdExcluir, Nothing)
    End Sub
End Class