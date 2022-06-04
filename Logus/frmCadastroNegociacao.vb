Public Class frmCadastroNegociacao
    Private Enum eLocalEntrega
        Fazenda = 1
        Filial = 2
        Fabrica = 3
    End Enum

    Private Enum eTipoNegociacao
        FIXO_REAL = 1
        FIXO_DOLAR = 2
        DIFERENCIAL_BOLSA = 3
    End Enum

    Dim CdFornecedor As Integer
    Dim PcJurosPadrao As Double
    Dim CdNegPadrao As Integer
    Dim mVlFreteFilialFabrica_Padrao As Double
    Dim mVlFretePadrao As Double
    Dim PcJuros As Double
    Dim CdFilialOrigem As Integer
    Dim QtSaldoPreNegociacao As Double
    Dim TpMoedaCredito As String
    Dim VlDolar As Double
    Dim IcMaster As Boolean
    Dim SqPreNegociacao As Integer
    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim QtFator As Integer
    Dim IcTipoNeg As eTipoNegociacao
    Event EfetuouGravacao()

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cboFilialEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilialEntrega.SelectedIndexChanged
        mVlFreteFilialFabrica_Padrao = 0

        If Not ComboBox_LinhaSelecionada(cboFilialEntrega) Then Exit Sub
        If Not ComboBox_LinhaSelecionada(cboLocalEntrega) Then Exit Sub

        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT VL_FRETE_FILIAL_FAZENDA," & _
                         "VL_FRETE_FILIAL_FABRICA," & _
                         "VL_FRETE_FABRICA" & _
                  " FROM SOF.FILIAL" & _
                  " WHERE CD_FILIAL = " & cboFilialEntrega.SelectedValue
        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            Select Case cboLocalEntrega.SelectedValue
                Case eLocalEntrega.Fazenda
                    txtValorFrete.Value = (oData.Rows(0).Item("VL_FRETE_FILIAL_FABRICA") + _
                                           oData.Rows(0).Item("VL_FRETE_FILIAL_FAZENDA"))
                Case eLocalEntrega.Filial
                    txtValorFrete.Value = oData.Rows(0).Item("VL_FRETE_FILIAL_FABRICA")
                Case eLocalEntrega.Fabrica
                    txtValorFrete.Value = oData.Rows(0).Item("VL_FRETE_FABRICA")
            End Select

            'Pego valor original do frete para comparar se teve alteração
            mVlFretePadrao = txtValorFrete.Value
            mVlFreteFilialFabrica_Padrao = oData.Rows(0).Item("VL_FRETE_FILIAL_FABRICA")
        Else
            txtValorFrete.Value = 0
        End If

        Pega_ICMS()
    End Sub

    Private Sub cboLocalEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocalEntrega.SelectedIndexChanged
        If Not ComboBox_LinhaSelecionada(cboLocalEntrega) Then Exit Sub

        Select Case cboLocalEntrega.SelectedValue
            Case eLocalEntrega.Fazenda, eLocalEntrega.Filial
                cboFilialEntrega.Enabled = True
                ComboBox_Possicionar(cboFilialEntrega, -1)
            Case eLocalEntrega.Fabrica
                ComboBox_Possicionar(cboFilialEntrega, FilialLogada)
                cboFilialEntrega_SelectedIndexChanged(Nothing, Nothing)
                cboFilialEntrega.Enabled = False
        End Select
    End Sub

    Private Sub cboTipoNegociacao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoNegociacao.SelectedIndexChanged
        Dim SqlText As String
        Dim oData As DataTable

        cboBolsa.DataSource = Nothing

        If Not ComboBox_LinhaSelecionada(cboTipoNegociacao) Then Exit Sub

        SqlText = "SELECT * FROM SOF.TIPO_NEGOCIACAO WHERE CD_TIPO_NEGOCIACAO=" & cboTipoNegociacao.SelectedValue
        oData = DBQuery(SqlText)

        Select Case True
            Case oData.Rows(0).Item("IC_BOLSA") = "S"
                IcTipoNeg = eTipoNegociacao.DIFERENCIAL_BOLSA
                cboBolsa.Enabled = True

                txtDataParaFixacao.Enabled = True
            Case oData.Rows(0).Item("IC_DOLAR") = "S"
                IcTipoNeg = eTipoNegociacao.FIXO_DOLAR
                txtDataParaFixacao.Enabled = True
                cboBolsa.Enabled = True
            Case oData.Rows(0).Item("IC_TIPO_PRECO_FIXO") = "S"
                IcTipoNeg = eTipoNegociacao.FIXO_REAL
                txtDataParaFixacao.Enabled = False
                cboBolsa.Enabled = True
        End Select

        SqlText = "SELECT CD_PAPEL," & _
                         "NO_PAPEL," & _
                         "DT_LIMITE_ENTREGA," & _
                         "VL_COTACAO" & _
                  " FROM SOF.BOLSA_PERIODO" & _
                  " WHERE IC_MOEDA = 'N'" & _
                  " ORDER BY DT_LIMITE_ENTREGA"
        objUltraComboBox_Carregar(cboBolsa, SqlText, _
                                  New Combo_Informacao() {objUltraComboBox_Informacao("Papel", True, 40, True, True), _
                                                          objUltraComboBox_Informacao("Nome", True, 80, False, False, cnt_Formato_NumeroInteiro), _
                                                          objUltraComboBox_Informacao("Dt Limite", True, 120, False, False), _
                                                          objUltraComboBox_Informacao("Cotação", True, 80, False, False)}, , )

        Verifica_Dt_Venc_Padrao()
    End Sub

    Private Sub chkCobraJuros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCobraJuros.CheckedChanged
        ComboBox_CobraJuros_Validar()
    End Sub

    Private Sub ComboBox_CobraJuros_Validar()
        If chkCobraJuros.Checked = True Then
            txtDiasCarencia.Enabled = True
            txtDiasCarencia.Value = 0
            txtTaxaJuros.Enabled = True
            txtTaxaJuros.Value = PcJuros
            chkJurosAposCarencia.Checked = True
        Else
            txtDiasCarencia.Value = 0
            txtDiasCarencia.Enabled = False
            txtTaxaJuros.Value = 0
            txtTaxaJuros.Enabled = False
            chkJurosAposCarencia.Checked = True
        End If
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Limpa_Tela()
        Pesq_ContratoPAF.Focus()
    End Sub

    Private Sub Limpa_Tela()
        Pesq_ContratoPAF.Codigo = 0
        Limpa_Contrato()
        txtMotivoDataVencimento.Text = ""
        txtValorUnitarioNegociacao.Value = 0
        txtValorFrete.Value = 0
        txtQuantidadeNegociacao.Value = 0
        txtDataVencimento.Value = Nothing
        txtDataPagamento.Value = Nothing
        lblNegociacao.Text = "NOVO"
        txtDataNegociacao.Value = DataSistema()
        cmdGravar.Enabled = True
        grpDados.Enabled = True
        ComboBox_Possicionar(cboUnidade, 1)
        ComboBox_Possicionar(cboTipoPessoa, -1)
        ComboBox_Possicionar(cboLocalEntrega, -1)
        ComboBox_Possicionar(cboFilialEntrega, -1)
        ComboBox_Possicionar(cboTipoNegociacao, CdNegPadrao)
        cboTipoNegociacao_SelectedIndexChanged(Nothing, Nothing)

        txtMotivoDataVencimento.Enabled = False
        Pega_Juros_Padrao()
        chkCobraJuros.Checked = True
        ComboBox_CobraJuros_Validar()
        cmdNovo.Visible = False
        cmdImprimir.Visible = False
    End Sub

    Private Sub Pega_ICMS()
        Dim SqlText As String

        If Pesq_ContratoPAF.Codigo = 0 Then Exit Sub
        If Not ComboBox_LinhaSelecionada(cboFilialEntrega) Then Exit Sub

        SqlText = "SELECT DECODE (fil.cd_uf, NULL, u.pc_aliq_icms, 0) AS pc_aliq_icms "
        SqlText = SqlText & "  FROM sof.uf u, "
        SqlText = SqlText & "       sof.municipio m, "
        SqlText = SqlText & "       sof.fornecedor f, "
        SqlText = SqlText & "       (SELECT m1.cd_uf "
        SqlText = SqlText & "          FROM sof.filial f1, sof.municipio m1 "
        SqlText = SqlText & "         WHERE f1.cd_municipio = m1.cd_municipio AND f1.cd_filial = " & cboFilialEntrega.SelectedValue & ") fil "
        SqlText = SqlText & " WHERE f.cd_municipio = m.cd_municipio "
        SqlText = SqlText & "   AND m.cd_uf = u.cd_uf "
        SqlText = SqlText & "   AND m.cd_uf = fil.cd_uf(+) "
        SqlText = SqlText & "   AND f.cd_fornecedor = " & CdFornecedor

        txtAliquotaICMS.Value = DBQuery_ValorUnico(SqlText)
    End Sub

    Private Sub Pesq_ContratoPAF_AlterouRegistro() Handles Pesq_ContratoPAF.AlterouRegistro
        Dim SqlText As String
        Dim oData As DataTable
        Dim icont As Integer

        Limpa_Contrato()

        If Pesq_ContratoPAF.Codigo = 0 Then
            Exit Sub
        End If

        SqlText = "SELECT cp.qt_a_negociar, f.no_razao_social, cp.cd_fornecedor, cp.cd_repassador, " & _
                  "r.no_razao_social no_repassador, F.cd_filial_origem, U.pc_aliq_icms, cp.qt_cancelado, " & _
                  "f.cd_tipo_pessoa, r.cd_tipo_pessoa cd_tipo_pessoa_repassador, cp.cd_filial_entrega, " & _
                  "nvl(cp.pc_taxa_juros,0) pc_taxa_juros, cp.ic_calcula_juros, cp.ic_juros_apos_carencia, " & _
                  "cp.qt_dia_carencia_juros, tcp.ic_adiantamento " & _
                  "FROM SOF.UF U, SOF.MUNICIPIO M, sof.fornecedor f, sof.fornecedor r, sof.contrato_paf cp, " & _
                  "sof.tipo_contrato_paf tcp " & _
                  "WHERE cp.cd_fornecedor = f.cd_fornecedor AND " & _
                  "cp.cd_repassador = r.cd_fornecedor and " & _
                  "F.cd_municipio = M.cd_municipio AND " & _
                  "M.cd_uf = U.cd_uf AND " & _
                  "cp.cd_tipo_contrato_paf = tcp.cd_tipo_contrato_paf and " & _
                  "cp.ic_status = 'A' AND " & _
                  "cp.cd_contrato_paf = " & Pesq_ContratoPAF.Codigo
        oData = DBQuery(SqlText)

        If oData.Rows.Count = 0 Then
            Limpa_Contrato()
            Exit Sub
        End If

        If oData.Rows(0).Item("ic_adiantamento") = "N" Then
            IcMaster = True
            txtValorAdiantamento.Enabled = True
        Else
            IcMaster = False
            txtValorAdiantamento.Value = 0
            txtValorAdiantamento.Enabled = False
        End If

        CdFornecedor = oData.Rows(0).Item("CD_FORNECEDOR")

        SqlText = "SELECT count(*) " & _
                  " FROM SOF.FORNECEDOR " & _
                  " WHERE CD_FORNECEDOR = " & oData.Rows(0).Item("CD_FORNECEDOR") & _
                    " AND CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Este fornecedor não pertence a nenhuma das filiais liberadas para o seu acesso")
            Limpa_Contrato()
            Exit Sub
        End If

        SqlText = "select ic_lista_negra " & _
                         "from sof.fornecedor " & _
                         "where cd_fornecedor = " & oData.Rows(0).Item("CD_FORNECEDOR")

        If DBQuery_ValorUnico(SqlText) = "S" Then
            Msg_Mensagem("Este fornecedor está na Lista Negra !!")
            Limpa_Contrato()
            Exit Sub
        End If

        txtSaldo.Value = oData.Rows(0).Item("QT_A_NEGOCIAR")
        CdFilialOrigem = oData.Rows(0).Item("CD_FILIAL_ORIGEM")

        'Se for master não pega a condição do Contrato
        If IcMaster Then
            chkCobraJuros.Checked = True
            ComboBox_CobraJuros_Validar()
            txtTaxaJuros.Value = PcJurosPadrao
        Else
            If oData.Rows(0).Item("IC_CALCULA_JUROS") = "S" Then
                PcJuros = oData.Rows(0).Item("PC_TAXA_JUROS")
                chkCobraJuros.Checked = True
                ComboBox_CobraJuros_Validar()
                txtDiasCarencia.Value = oData.Rows(0).Item("QT_DIA_CARENCIA_JUROS")
                chkJurosAposCarencia.Checked = IIf(oData.Rows(0).Item("IC_JUROS_APOS_CARENCIA") = "S", True, False)
            Else
                PcJuros = PcJurosPadrao
                chkCobraJuros.Checked = False
                ComboBox_CobraJuros_Validar()
            End If
        End If

        SqlText = "select nvl(sum(pcp.vl_a_fixar),0) vl_a_fixar from sof.pag_ctr_paf pcp where pcp.cd_contrato_paf = " & Pesq_ContratoPAF.Codigo
        txtValorAdiantamentoAberto.Value = DBQuery_ValorUnico(SqlText)

        SqlText = "SELECT NVL(SUM(CPM.QT_KG_A_FIXAR),0) AS QT, nvl(M.CD_LOCAL_ENTREGA,3) CD_LOCAL_ENTREGA, " & _
                  "nvl(round(sum(cpm.qt_kg_a_fixar * frt.vl_unitario) / decode(sum(cpm.qt_kg_a_fixar),0,1,sum(cpm.qt_kg_a_fixar)),2),0) vl_frete " & _
                  "FROM SOF.CTR_PAF_MOVIMENTACAO CPM, SOF.CONTRATO_PAF CP, SOF.Movimentacao M, (select sq_movimentacao, sum(vl_unitario) vl_unitario from sof.frete group by sq_movimentacao) frt " & _
                  "WHERE CP.CD_CONTRATO_PAF = CPM.CD_CONTRATO_PAF AND " & _
                  "M.SQ_MOVIMENTACAO = CPM.SQ_MOVIMENTACAO AND " & _
                  "m.sq_movimentacao = frt.sq_movimentacao (+) and " & _
                  "CP.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & " AND " & _
                  "CPM.QT_KG_A_FIXAR <> 0 " & _
                  "GROUP BY nvl(M.CD_LOCAL_ENTREGA,3)"
        oData = DBQuery(SqlText)

        txtQuantidadeFazenda.Value = 0
        txtValorMedioFrete.Value = 0
        txtQuantidadeFilial.Value = 0
        txtQuantidadeFabrica.Value = 0

        For icont = 0 To oData.Rows.Count - 1
            Select Case oData.Rows(icont).Item("CD_LOCAL_ENTREGA")
                Case 1
                    txtQuantidadeFazenda.Value = oData.Rows(icont).Item("QT")
                    txtValorMedioFrete.Value = oData.Rows(icont).Item("VL_FRETE")
                Case 2
                    txtQuantidadeFilial.Value = oData.Rows(icont).Item("QT")
                Case 3
                    txtQuantidadeFabrica.Value = oData.Rows(icont).Item("QT")
            End Select
        Next
        Pega_ICMS()
    End Sub

    Private Sub txtDataVencimento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDataVencimento.LostFocus
        Verifica_Dt_Venc_Padrao()
    End Sub

    Private Sub txtQuantidadeNegociacao_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantidadeNegociacao.ValueChanged
        Calcula_Valor_Total()
    End Sub

    Private Sub txtAliquotaICMS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAliquotaICMS.ValueChanged
        Calcula_Valor_Total()
    End Sub

    Private Sub txtValorUnitarioNegociacao_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorUnitarioNegociacao.ValueChanged
        Calcula_Valor_Total()
    End Sub

    Private Sub Calcula_Valor_Total()
        txtValorTotal.Value = 0

        If Not ComboBox_LinhaSelecionada(cboUnidade) Then Exit Sub
        If Not ComboBox_LinhaSelecionada(cboTipoNegociacao) Then Exit Sub

        If eTipoNegociacao.DIFERENCIAL_BOLSA <> IcTipoNeg Then
            txtValorTotal.Value = (txtValorUnitarioNegociacao.Value / QtFator) * txtQuantidadeNegociacao.Value
        End If
    End Sub

    Private Sub Verifica_Dt_Venc_Padrao()
        If Not IsDate(txtDataVencimento.Text) Then Exit Sub
        If Not ComboBox_LinhaSelecionada(cboTipoNegociacao) Then Exit Sub

        Dim DtVencPadrao As Date

        DtVencPadrao = DateAdd(DateInterval.Day, DBQuery_ValorUnico("SELECT QT_DIA_VENC_PADRAO" & _
                                                                    " FROM SOF.TIPO_NEGOCIACAO" & _
                                                                    " WHERE CD_TIPO_NEGOCIACAO = " & cboTipoNegociacao.SelectedValue), _
                                                 CDate(DataSistema()))

        If DtVencPadrao < CDate(txtDataVencimento.Text) Then
            txtMotivoDataVencimento.Enabled = True
        Else
            txtMotivoDataVencimento.Text = ""
            txtMotivoDataVencimento.Enabled = False
        End If
    End Sub

    Private Sub Pega_Juros_Padrao()
        Dim SqlText As String

        SqlText = "select pc_juros_ao_mes from sof.parametro"
        PcJurosPadrao = DBQuery_ValorUnico(SqlText, 0)
    End Sub

    Private Sub Limpa_Contrato()
        txtSaldo.Value = 0
        txtAliquotaICMS.Value = 0
        txtQuantidadeFazenda.Value = 0
        txtValorMedioFrete.Value = 0
        txtQuantidadeFilial.Value = 0
        txtQuantidadeFabrica.Value = 0
        txtValorAdiantamentoAberto.Value = 0
    End Sub

    Private Sub frmCadastroNegociacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String
        Dim oData As DataTable

        With Pesq_ContratoPAF
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_ContratoPAF
            .BancoDados_Filtro_Limpar()
            .BancoDados_Filtro_Adicionar("IC_STATUS = 'A'")

            If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_LimitarInclusaoCtrSomentoImportacao) Then
                .BancoDados_Filtro_Adicionar("F.CD_TIPO_PESSOA = " & cnt_TipoPessoa_IMPORTADO)
            End If
        End With

        ComboBox_Carregar_Tipo_Pessoa(cboTipoPessoa, True, True)
        ComboBox_Carregar_Filial(cboFilialEntrega, True, True, True)
        ComboBox_Carregar_Local_Entrega(cboLocalEntrega, True)
        ComboBox_Carregar_Tipo_Cacau(cboTipoCacau, True)
        ComboBox_Carregar_Tipo_Negociacao(cboTipoNegociacao, True)
        ComboBox_Carregar_Tipo_Unidade(cboUnidade, True)

        SqlText = "SELECT CD_TIPO_NEGOCIACAO_PADRAO, IC_MOEDA_CREDITO FROM SOF.PARAMETRO"
        oData = DBQuery(SqlText)

        CdNegPadrao = NVL(oData.Rows(0).Item("CD_TIPO_NEGOCIACAO_PADRAO"), -1)
        TpMoedaCredito = oData.Rows(0).Item("IC_MOEDA_CREDITO")

        'Pega valor dolar
        SqlText = "SELECT NVL(B.VL_COTACAO,0) VL_COTACAO," & _
                         "NVL(B.VL_COTACAO_ALTERNATIVO,0) VL_COTACAO_ALTERNATIVO" & _
                  " FROM SOF.BOLSA_PARAMETRO A," & _
                        "SOF.BOLSA_PERIODO B " & _
                  " WHERE A.CD_PAPEL_DOLAR = B.CD_PAPEL"
        oData = DBQuery(SqlText)

        If oData.Rows(0).Item("VL_COTACAO_ALTERNATIVO") <> 0 Then
            VlDolar = oData.Rows(0).Item("VL_COTACAO_ALTERNATIVO")
        Else
            VlDolar = oData.Rows(0).Item("VL_COTACAO")
        End If

        ControleEdicaoTelaLocal = ControleEdicaoTela

        If ControleEdicaoTelaLocal = eControleEdicaoTela.PRE_NEGOCIACAO Then
            SqPreNegociacao = Filtro
            CarregaDadosPreNegocicao(SqPreNegociacao)
        Else
            Limpa_Tela()
        End If
    End Sub

    Private Sub CarregaDadosPreNegocicao(ByVal cd_pre_negociacao As Integer)
        Dim Sqltext As String
        Dim oData As DataTable

        Pega_Juros_Padrao()
        chkCobraJuros.Checked = True
        ComboBox_CobraJuros_Validar()

        Sqltext = "SELECT * " & _
                  "From SOF.NEGOCIACAO_PRE " & _
                  "WHERE SQ_NEGOCIACAO_PRE = " & cd_pre_negociacao

        oData = DBQuery(Sqltext)

        If objDataTable_Vazio(oData) Then
            Msg_Mensagem("Algum usuario do sistema eliminou a pre negociação")
            Exit Sub
        End If

        lblNegociacao.Text = "NOVO"
        txtDataNegociacao.Value = DataSistema()

        With oData.Rows(0)
            QtSaldoPreNegociacao = .Item("qt_saldo")

            txtQuantidadeNegociacao.Value = .Item("qt_saldo")
            ComboBox_Possicionar(cboUnidade, .Item("cd_tipo_unidade"))
            txtDataVencimento.Value = .Item("dt_vencimento")
            txtDataPagamento.Value = .Item("dt_pagamento")
            ComboBox_Possicionar(cboLocalEntrega, .Item("cd_local_entrega"))
            ComboBox_Possicionar(cboFilialEntrega, NVL(.Item("CD_FILIAL_ENTREGA"), FilialLogada))
            ComboBox_Possicionar(cboTipoNegociacao, NVL(.Item("cd_tipo_negociacao"), FilialLogada))
            cboTipoNegociacao_SelectedIndexChanged(Nothing, Nothing)

            If Not objDataTable_CampoVazio(.Item("cd_papel_competencia")) Then
                objUltraComboBox_Possicionar(cboBolsa, 0, oData.Rows(0).Item("CD_PAPEL_COMPETENCIA"))
            End If
            txtValorUnitarioNegociacao.Value = .Item("vl_NEGOCIACAO")

            CdFilialOrigem = .Item("cd_filial_origem")

            txtValorFrete.Value = .Item("vl_preco_frete")
            txtValorUnitarioNegociacao_ValueChanged(Nothing, Nothing)
            ComboBox_Possicionar(cboTipoCacau, NVL(.Item("CD_TIPO_CACAU"), FilialLogada))

            'Ativa e desativa campos
            cboUnidade.Enabled = False
            txtDataVencimento.Enabled = False
            cboLocalEntrega.Enabled = False
            cboFilialEntrega.Enabled = False
            cboTipoNegociacao.Enabled = False
            If Not objDataTable_CampoVazio(.Item("CD_PAPEL_COMPETENCIA")) Then
                If Not ObjUltraComboBox_LinhaSelecionada(cboBolsa) Then cboBolsa.Enabled = False
            End If
            txtValorUnitarioNegociacao.Enabled = False
            txtValorFrete.Enabled = False
            cboTipoCacau.Enabled = False
            cmdNovo.Visible = False
            cmdImprimir.Visible = False

            cboTipoPessoa.Visible = False

            chkCobraJuros.Checked = (NVL(.Item("IC_CALCULA_JUROS"), "N") = "S")
            chkJurosAposCarencia.Checked = (NVL(.Item("IC_JUROS_APOS_CARENCIA"), "N") = "S")
            txtTaxaJuros.Value = NVL(.Item("PC_TAXA_JUROS"), 0)
            txtDiasCarencia.Value = NVL(.Item("QT_DIA_CARENCIA_JUROS"), 0)
        End With
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim odata As DataTable
        Dim SqlText As String
        Dim mValor As Long
        Dim CtrPAFOld As Long

        If Pesq_ContratoPAF.Codigo = 0 Then
            Msg_Mensagem("Favor informar um contrato PAF valido.")
            Pesq_ContratoPAF.Focus()
            Exit Sub
        End If

        SqlText = "SELECT F.DS_OBS" & _
                  " FROM SOF.FORNECEDOR_OBS F," & _
                        "SOF.CONTRATO_PAF CP " & _
                  " WHERE F.CD_FORNECEDOR = CP.CD_FORNECEDOR" & _
                    " AND CP.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo
        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            Msg_Mensagem(oData.Rows(0).Item("ds_obs"))
            If Msg_Perguntar("Continua a inclusão ?") = False Then Exit Sub
        End If

        If txtQuantidadeNegociacao.Value <= 0 Then
            Msg_Mensagem("Favor informar a quantidade em quilos da negociação acima de 0.")
            txtQuantidadeNegociacao.Focus()
            Exit Sub
        End If

        If txtQuantidadeNegociacao.Value > txtSaldo.Value Then
            Msg_Mensagem("Favor informar uma quantidade menor do que " & Format(txtSaldo.Value, "#,##0"))
            txtQuantidadeNegociacao.Focus()
            Exit Sub
        End If

        If ControleEdicaoTelaLocal = eControleEdicaoTela.PRE_NEGOCIACAO Then
            If txtQuantidadeNegociacao.Value > QtSaldoPreNegociacao Then
                Msg_Mensagem("A quantidade da negociação não pode ser maior do que: " & Format(QtSaldoPreNegociacao, "#,##0"))
                txtQuantidadeNegociacao.Focus()
                Exit Sub
            End If
        End If
        If Not ComboBox_LinhaSelecionada(cboUnidade) Then
            Msg_Mensagem("Favor escolher uma unidade para a negociação.")
            cboUnidade.Focus()
            Exit Sub
        End If

        If Not IsDate(txtDataVencimento.Text) Then
            Msg_Mensagem("Data de vencimento invalida.")
            txtDataVencimento.Focus()
            Exit Sub
        End If

        If CDate(txtDataVencimento.Text) < DataSistema() Then
            Msg_Mensagem("Data de vencimento menor que a data atual")
            txtDataVencimento.Focus()
            Exit Sub
        End If

        If Not IsDate(txtDataPagamento.Text) Then
            Msg_Mensagem("Data de pagamento invalida.")
            txtDataPagamento.Focus()
            Exit Sub
        End If

        If CDate(txtDataPagamento.Text) < DataSistema() Then
            Msg_Mensagem("Data de pagamento menor que a data atual")
            txtDataPagamento.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboLocalEntrega) Then
            Msg_Mensagem("Favor escolher um local de entrega.")
            cboLocalEntrega.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboTipoNegociacao) Then
            Msg_Mensagem("Favor informar um tipo de negociação.")
            cboTipoNegociacao.Focus()
            Exit Sub
        End If

        If cboBolsa.Enabled = False Then
            If txtValorUnitarioNegociacao.Value = 0 Then
                Msg_Mensagem("Favor informar um valor unitario.")
                txtValorUnitarioNegociacao.Focus()
                Exit Sub
            End If
        Else
            If Not ObjUltraComboBox_LinhaSelecionada(cboBolsa) Then
                Msg_Mensagem("Favor selecionar uma bolsa.")
                cboBolsa.Focus()
                Exit Sub
            End If
        End If

        If Not ControleEdicaoTelaLocal = eControleEdicaoTela.PRE_NEGOCIACAO Then
            If Not ComboBox_LinhaSelecionada(cboTipoPessoa) Then
                Msg_Mensagem("Favor selecionar um tipo de pessoa.")
                cboTipoPessoa.Focus()
                Exit Sub
            End If
        End If

        If txtValorFrete.Value < mVlFretePadrao Then
            Msg_Mensagem("Favor informar um frete igual ou maior que o " & mVlFretePadrao & ".")
            txtValorFrete.Focus()
            Exit Sub
        End If

        Select Case cboLocalEntrega.SelectedValue
            Case eLocalEntrega.Fazenda
                mValor = txtQuantidadeFazenda.Value
                If txtValorMedioFrete.Value <> 0 And txtValorFrete.Value < (txtValorMedioFrete.Value + mVlFreteFilialFabrica_Padrao) Then
                    If Msg_Perguntar("O valor do frete do contrato esta menor que o preco medio do frete." & vbCrLf & _
                              "Deseja continuar mesmo assim ?") = False Then Exit Sub
                End If
            Case eLocalEntrega.Filial
                mValor = txtQuantidadeFilial.Value
            Case eLocalEntrega.Fabrica
                mValor = txtQuantidadeFabrica.Value
        End Select

        If txtQuantidadeNegociacao.Value > mValor Then
            If Msg_Perguntar("A quantidade liberada a ordem é de " & Format(mValor, "#,##0") & " Kgs" & vbCrLf & _
                      "Deseja continuar mesmo assim ?") = False Then Exit Sub
        End If

        If txtMotivoDataVencimento.Enabled Then
            If txtMotivoDataVencimento.Text = "" Then
                Msg_Mensagem("Favor informar o motivo da data de vencimento fora do padrão.")
                txtMotivoDataVencimento.Focus()
                Exit Sub
            End If
        End If

        If txtDataParaFixacao.Enabled = True Then
            If Not IsDate(txtDataParaFixacao.Text) Then
                Msg_Mensagem("Prazo de fixação invalido.")
                txtDataParaFixacao.Focus()
                Exit Sub
            End If
            If CDate(txtDataParaFixacao.Text) <= DataSistema() Then
                Msg_Mensagem("Prazo de fixação inferior ou igual a hoje.")
                txtDataParaFixacao.Focus()
                Exit Sub
            End If
        End If

        If Not ComboBox_LinhaSelecionada(cboFilialEntrega) Then
            Msg_Mensagem("Favor informar uma filial de entrega.")
            cboFilialEntrega.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboTipoCacau) Then
            Msg_Mensagem("Favor selecionar um tipo de cacau.")
            cboTipoCacau.Focus()
            Exit Sub
        End If

        'If txtPremioCRM.Visible = True And txtPremioCRM.Value = 0 Then
        '    Msg_Mensagem("Favor informar o premio CRM.")
        '    txtPremioCRM.Focus()
        '    Exit Sub
        'End If

        If chkCobraJuros.Checked = True Then
            If txtTaxaJuros.Value = 0 Then
                Msg_Mensagem("Favor informar a taxa de juros.")
                txtTaxaJuros.Focus()
                Exit Sub
            End If
        End If

        If txtValorAdiantamento.Enabled = True Then
            If txtValorAdiantamento.Value = 0 Then
                If Msg_Perguntar("Sera concedido algum adiantamento dentro desse contrato ?") = True Then
                    txtValorAdiantamento.Focus()
                    Exit Sub
                End If
            End If
        End If

        If FilialFechada(FilialLogada) Then
            Msg_Mensagem("A Filial está fechada. No momento não é possivel incluir a negociação.")
            Exit Sub
        End If

        If IcTipoNeg = eTipoNegociacao.DIFERENCIAL_BOLSA And IcMaster Then
            Msg_Mensagem("Para esse tipo de negociação não é possivel fazer a negociação diretamente do Master.Favor escolher um contrato PAF já existe ou criar um novo.")
            Pesq_ContratoPAF.Codigo = 0
            Pesq_ContratoPAF.Focus()
            Exit Sub
        End If

        'Desativado solicitado por carlos menezes
        'If Not Valida_Limite() Then Exit Sub

        cmdGravar.Enabled = False

        DBUsarTransacao = True

        If IcMaster Then
            CtrPAFOld = Pesq_ContratoPAF.Codigo

            Substitui_Master(CtrPAFOld)

            Aplica_Cacau_Contrato_PAF(CtrPAFOld, Me.txtQuantidadeNegociacao.Value, Pesq_ContratoPAF.Codigo, True, _
                                      cboLocalEntrega.SelectedValue, _
                                      cboFilialEntrega.SelectedValue)

            If Not Inclui_Negociacao(True) Then GoTo Erro
        Else
            If Not Inclui_Negociacao(False) Then GoTo Erro
        End If

        If Not DBExecutarTransacao() Then GoTo Erro

        ' Revisao_de_Contratos(False, Pesq_ContratoPAF.Codigo)

        Aplica_Cacau()
        Aplica_Pagamento()

        QtSaldoPreNegociacao = QtSaldoPreNegociacao - txtQuantidadeNegociacao.Value

        cmdNovo.Visible = True
        cmdImprimir.Visible = True
        grpDados.Enabled = False
        RaiseEvent EfetuouGravacao()
        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Function Valida_Limite() As Boolean
        Dim SqlText As String
        Dim VlSolicitado As Double
        Dim IcFixo As String
        Dim IcDolar As String
        Dim IcBolsa As String
        Dim IcBolsaOpe As String
        Dim VlSaldo As Double
        Dim PcINSS As Double
        Dim VlPreco As Double
        Dim VlICMS As Double
        Dim VlPrecoCacau As Double
        Dim VlResultado As Double
        Dim VlBolsa As Double
        Dim VlMoeda As Double
        Dim IcBolsaOperacao As String

        Valida_Limite = False

        IcFixo = "N"
        IcDolar = "N"
        IcBolsa = "N"
        IcBolsaOpe = ""

        IcBolsaOperacao = DBQuery_ValorUnico("select ic_bolsa_operacao from sof.tipo_negociacao where cd_tipo_negociacao  =" & cboTipoNegociacao.SelectedValue)

        Select Case IcTipoNeg
            Case eTipoNegociacao.FIXO_REAL
                VlSolicitado = (txtValorUnitarioNegociacao.Value / QtFator)
                IcFixo = "S"
            Case eTipoNegociacao.FIXO_DOLAR
                VlSolicitado = (txtValorUnitarioNegociacao.Value / QtFator)
                IcDolar = "S"
            Case eTipoNegociacao.DIFERENCIAL_BOLSA
                VlSolicitado = txtValorUnitarioNegociacao.Value
                IcBolsa = "S"
                IcBolsaOpe = IcBolsaOperacao
        End Select

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

        If Not DBExecutar(SqlText, DBParametro_Montar("CDFORN", CdFornecedor), _
                                   DBParametro_Montar("ICNEG", "S"), _
                                   DBParametro_Montar("VLUNITARIO", VlSolicitado), _
                                   DBParametro_Montar("ICFIXONEG", IcFixo), _
                                   DBParametro_Montar("ICDOLARNEG", IcDolar), _
                                   DBParametro_Montar("ICBOLSANEG", IcBolsa), _
                                   DBParametro_Montar("ICBOLSAOPERACAONEG", IcBolsaOpe), _
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
            VlSaldo = DBRetorno(2)
            PcINSS = DBRetorno(1)
            VlPreco = DBRetorno(8)
            VlBolsa = DBRetorno(4)
            VlMoeda = DBRetorno(3)
        End If

        VlICMS = (VlPreco / (1 - ((txtAliquotaICMS.Value / 100) + PcINSS))) * (txtAliquotaICMS.Value / 100)

        VlPrecoCacau = VlPreco + VlICMS

        Select Case IcTipoNeg
            Case eTipoNegociacao.FIXO_REAL
                VlSolicitado = (txtValorUnitarioNegociacao.Value / QtFator)
            Case eTipoNegociacao.FIXO_DOLAR
                VlSolicitado = ((txtValorUnitarioNegociacao.Value / QtFator) * VlMoeda)
            Case eTipoNegociacao.DIFERENCIAL_BOLSA
                Select Case IcBolsaOperacao
                    Case "+"
                        VlSolicitado = (((VlBolsa + txtValorUnitarioNegociacao.Value) * VlMoeda) / 1000)
                    Case "-"
                        VlSolicitado = (((VlBolsa - txtValorUnitarioNegociacao.Value) * VlMoeda) / 1000)
                    Case "*"
                        VlSolicitado = (((VlBolsa * txtValorUnitarioNegociacao.Value) * VlMoeda) / 1000)
                    Case "/"
                        VlSolicitado = (((VlBolsa / txtValorUnitarioNegociacao.Value) * VlMoeda) / 1000)
                End Select
        End Select

        VlICMS = (VlSolicitado / (1 - ((txtAliquotaICMS.Value / 100) + PcINSS))) * (txtAliquotaICMS.Value / 100)

        VlSolicitado = VlSolicitado + VlICMS

        VlResultado = (VlPrecoCacau - VlSolicitado) * txtQuantidadeNegociacao.Value

        'se saldo 0 nao valida
        If VlResultado > 0 And VlSaldo <> 0 Then
            If VlResultado > VlSaldo Then
                Select Case TpMoedaCredito
                    Case "S" 'sacos
                        Msg_Mensagem("Fornecedor não possue saldo para realizar essa negociação." & vbCrLf & _
                             "É necessario solicitar um credito de " & Format((VlResultado - VlSaldo) / VlPreco / 60, "#,##0") & " Sacos.")
                    Case "R" 'reais
                        Msg_Mensagem("Fornecedor não possue saldo para realizar essa negociação." & vbCrLf & _
                             "É necessario solicitar um credito de " & Format((VlResultado - VlSaldo), "#,##0.00") & " Reais.")
                    Case "D" 'reais
                        Msg_Mensagem("Fornecedor não possue saldo para realizar essa negociação." & vbCrLf & _
                             "É necessario solicitar um credito de " & Format((VlResultado - VlSaldo) / VlDolar, "#,##0.00") & " Dolar.")
                End Select
                Exit Function
            End If
        End If

        Valida_Limite = True

        Exit Function

Erro:
        TratarErro()
    End Function

    Private Sub Substitui_Master(ByVal CtrPAFOriginal As Long)
        Dim SqlText As String
        Dim oData As DataTable
        Dim Parametro(31) As DBParamentro
        Dim PC_ALIQ_ICMS As Double


        SqlText = "SELECT A.CD_CONTRATO_PAF," & _
                         "A.CD_FORNECEDOR," & _
                         "A.CD_REPASSADOR," & _
                         "A.CD_TIPO_CONTRATO_PAF," & _
                         "A.DT_CONTRATO_PAF," & _
                         "A.QT_KGS, A.IC_STATUS," & _
                         "A.DT_VENCIMENTO," & _
                         "A.CD_FILIAL_ORIGEM," & _
                         "A.VL_ADIANTAMENTO," & _
                         "A.CD_SAFRA," & _
                         "A.DT_CRIACAO," & _
                         "A.NO_USER_CRIACAO," & _
                         "A.DT_ALTERACAO," & _
                         "A.NO_USER_ALTERACAO," & _
                         "A.QT_KG_FIXO," & _
                         "A.VL_PAG_FIXO," & _
                         "A.VL_NF_FIXO," & _
                         "A.VL_NF_INSS_FIXO," & _
                         "A.VL_NF_ICMS_FIXO," & _
                         "A.CD_SAFRA_COMPETENCIA," & _
                         "A.CD_TIPO_ACONDICIONAMENTO," & _
                         "A.CD_TIPO_MODALIDADE_ENTREGA," & _
                         "A.CD_LOCAL_CONFERENCIA_PESO," & _
                         "A.CD_LOCAL_CONFERENCIA_QUALIDADE," & _
                         "A.CD_TIPO_DESPESA_CARREGAMENTO," & _
                         "A.IC_CALCULA_JUROS," & _
                         "A.QT_DIA_CARENCIA_JUROS," & _
                         "A.QT_A_NEGOCIAR," & _
                         "A.QT_CANCELADO," & _
                         "A.CD_TIPO_QUALIDADE," & _
                         "A.CD_FILIAL_NF," & _
                         "A.CD_FILIAL_ENTREGA," & _
                         "A.CD_TIPO_CONDICAO_PAGAMENTO," & _
                         "A.PC_TAXA_JUROS," & _
                         "A.DT_PRAZO_FIXACAO," & _
                         "A.CD_MUNICIPIO," & _
                         "A.CD_CONTRATO_PAF_ORIGEM," & _
                         "A.IC_JUROS_APOS_CARENCIA," & _
                         "A.DT_PRAZO_ENTREGA," & _
                         "B.IC_ADIANTAMENTO," & _
                         "P.CD_TP_CTR_PAF_NEG_MASTER," & _
                         "P.IC_JUROS_NEG_REC," & _
                         "P.IC_JUROS_NEG," & _
                         "P.IC_JUROS_CTR_FIX" & _
                  " FROM SOF.CONTRATO_PAF A," & _
                        "SOF.TIPO_CONTRATO_PAF B," & _
                        "SOF.PARAMETRO P" & _
                  " WHERE A.CD_TIPO_CONTRATO_PAF = B.CD_TIPO_CONTRATO_PAF" & _
                    " AND A.CD_CONTRATO_PAF = " & CtrPAFOriginal
        oData = DBQuery(SqlText)

        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONTRATO_PAF", False, _
                                                            ":CDFORNECEDOR", _
                                                            ":CDREPASSADOR", _
                                                            ":CDTIPOCONTRATOPAF", _
                                                            ":DTCONTRATOPAF", _
                                                            ":QTKGS", _
                                                            ":DTVENCIMENTO", _
                                                            ":CDFILIALORIGEM", _
                                                            ":VLADIANTAMENTO", _
                                                            ":CDSAFRA", _
                                                            ":CDSAFRACOMPETENCIA", _
                                                            ":CDTIPOACONDICIONAMENTO", _
                                                            ":CDTIPOMODALIDADEENTREGA", _
                                                            ":CDLOCALCONFERENCIAPESO", _
                                                            ":CDLOCALCONFERENCIAQUALIDADE", _
                                                            ":CDTIPODESPESACARREGAMENTO", _
                                                            ":ICCALCULAJUROS", _
                                                            ":QTDIACARENCIAJUROS", _
                                                            ":CDTIPOQUALIDADE", _
                                                            ":CDFILIANF", _
                                                            ":CDFILIALENTREGA", _
                                                            ":CDTIPOCONDICAOPAGAMENTO", _
                                                            ":CDMUNICIPIO", _
                                                            ":PCTAXAJUROS", _
                                                            ":ICJUROSAPOSCARENCIA", _
                                                            ":DTPRAZOFIXACAO", _
                                                            ":CDCTRPAFORIGEM", _
                                                            ":ICJUROSNEG", _
                                                            ":ICJUROSCTRFIX", _
                                                            ":ICJUROSNEGREC", _
                                                            ":NUMINI", _
                                                            ":NUMFIM", _
                                                            ":CDCONTRATOPAF")

        Parametro(0) = DBParametro_Montar("CDFORNECEDOR", CdFornecedor)
        Parametro(1) = DBParametro_Montar("CDREPASSADOR", oData.Rows(0).Item("cd_repassador"))
        Parametro(2) = DBParametro_Montar("CDTIPOCONTRATOPAF", oData.Rows(0).Item("cd_tp_ctr_paf_neg_master"))
        Parametro(3) = DBParametro_Montar("DTCONTRATOPAF", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime)
        Parametro(4) = DBParametro_Montar("QTKGS", txtQuantidadeNegociacao.Value)
        Parametro(5) = DBParametro_Montar("DTVENCIMENTO", Date_to_Oracle(txtDataVencimento.Text), OracleClient.OracleType.DateTime)
        Parametro(6) = DBParametro_Montar("CDFILIALORIGEM", CdFilialOrigem)
        Parametro(7) = DBParametro_Montar("VLADIANTAMENTO", txtValorAdiantamento.Value)
        Parametro(8) = DBParametro_Montar("CDSAFRA", Safra)
        Parametro(9) = DBParametro_Montar("CDSAFRACOMPETENCIA", Safra)
        Parametro(10) = DBParametro_Montar("CDTIPOACONDICIONAMENTO", oData.Rows(0).Item("cd_tipo_acondicionamento"))
        Parametro(11) = DBParametro_Montar("CDTIPOMODALIDADEENTREGA", oData.Rows(0).Item("cd_tipo_modalidade_entrega"))
        Parametro(12) = DBParametro_Montar("CDLOCALCONFERENCIAPESO", oData.Rows(0).Item("cd_local_conferencia_peso"))
        Parametro(13) = DBParametro_Montar("CDLOCALCONFERENCIAQUALIDADE", oData.Rows(0).Item("cd_local_conferencia_qualidade"))
        Parametro(14) = DBParametro_Montar("CDTIPODESPESACARREGAMENTO", oData.Rows(0).Item("cd_tipo_despesa_carregamento"))
        If chkCobraJuros.Checked = True Then
            Parametro(15) = DBParametro_Montar("ICCALCULAJUROS", "S")
            Parametro(16) = DBParametro_Montar("QTDIACARENCIAJUROS", txtDiasCarencia.Value)
        Else
            Parametro(15) = DBParametro_Montar("ICCALCULAJUROS", "N")
            Parametro(16) = DBParametro_Montar("QTDIACARENCIAJUROS", Nothing)
        End If
        Parametro(17) = DBParametro_Montar("CDTIPOQUALIDADE", oData.Rows(0).Item("cd_tipo_qualidade"))
        Parametro(18) = DBParametro_Montar("CDFILIANF", cboFilialEntrega.SelectedValue)
        Parametro(19) = DBParametro_Montar("CDFILIALENTREGA", cboFilialEntrega.SelectedValue)
        Parametro(20) = DBParametro_Montar("CDTIPOCONDICAOPAGAMENTO", oData.Rows(0).Item("cd_tipo_condicao_pagamento"))
        Parametro(21) = DBParametro_Montar("CDMUNICIPIO", oData.Rows(0).Item("cd_municipio"))
        If grpJuros.Enabled = True Then
            Parametro(22) = DBParametro_Montar("PCTAXAJUROS", txtTaxaJuros.Value)
            Parametro(23) = DBParametro_Montar("ICJUROSAPOSCARENCIA", IIf(chkJurosAposCarencia.Checked = True, "S", "N"))
        Else
            Parametro(22) = DBParametro_Montar("PCTAXAJUROS", Nothing)
            Parametro(23) = DBParametro_Montar("ICJUROSAPOSCARENCIA", Nothing)
        End If
        If txtDataParaFixacao.Enabled = True Then
            Parametro(24) = DBParametro_Montar("DTPRAZOFIXACAO", Date_to_Oracle(txtDataParaFixacao.Text), OracleClient.OracleType.DateTime)
        Else
            Parametro(24) = DBParametro_Montar("DTPRAZOFIXACAO", Nothing)
        End If
        Parametro(25) = DBParametro_Montar("CDCTRPAFORIGEM", CtrPAFOriginal)
        If chkCobraJuros.Checked = True Then
            Parametro(26) = DBParametro_Montar("ICJUROSNEG", oData.Rows(0).Item("IC_JUROS_NEG"))
            Parametro(27) = DBParametro_Montar("ICJUROSCTRFIX", oData.Rows(0).Item("Ic_Juros_Ctr_Fix"))
            Parametro(28) = DBParametro_Montar("ICJUROSNEGREC", oData.Rows(0).Item("IC_JUROS_NEG_REC"))
        Else
            Parametro(26) = DBParametro_Montar("ICJUROSNEG", Nothing)
            Parametro(27) = DBParametro_Montar("ICJUROSCTRFIX", Nothing)
            Parametro(28) = DBParametro_Montar("ICJUROSNEGREC", Nothing)
        End If
        Parametro(29) = DBParametro_Montar("NUMINI", Val(CStr(oData.Rows(0).Item("cd_filial_origem")) & StrZero(CLng(Safra), 2) & "0000"))
        Parametro(30) = DBParametro_Montar("NUMFIM", Val(CStr(oData.Rows(0).Item("cd_filial_origem")) & StrZero(CLng(Safra), 2) & "9999"))
        Parametro(31) = DBParametro_Montar("CDCONTRATOPAF", Nothing, , ParameterDirection.Output)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        If DBTeveRetorno() Then
            PC_ALIQ_ICMS = txtAliquotaICMS.Value
            Pesq_ContratoPAF.Codigo = DBRetorno(1)
            txtAliquotaICMS.Value = PC_ALIQ_ICMS
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Function Inclui_Negociacao(ByVal ImprimePAF As Boolean) As Boolean
        Dim Parametro(33) As DBParamentro
        Dim QtUmidadePadrao As Double
        Dim PcSujidadePadrao As Double
        Dim SqlText As String

        'busco valor desejavel da umidade no summus
        SqlText = "SELECT A.VL_ANALISE_DESEJADA" & _
                  " FROM SOF.ANALISE_CONFIGURACAO A" & _
                  " WHERE A.CD_PROCESSO =" & enProcesso_Status.Analise & _
                    " AND A.CD_ANALISE =SOF.FC_CODIGO_ANALISE_SUMMUS('UMIDADE') "
        QtUmidadePadrao = DBQuery_ValorUnico(SqlText, 8)

        'busco valor desejavel da umidade no summus
        SqlText = "SELECT A.VL_ANALISE_DESEJADA" & _
                  " FROM SOF.ANALISE_CONFIGURACAO A" & _
                  " WHERE A.CD_PROCESSO = " & enProcesso_Status.Analise & _
                    " AND A.CD_ANALISE = SOF.FC_CODIGO_ANALISE_SUMMUS('SUJIDADE') "
        PcSujidadePadrao = DBQuery_ValorUnico(SqlText, 0.5)

        SqlText = DBMontar_SP("SOF.SP_INCLUI_NEGOCIACAO", False, ":CDCONTRATOPAF", _
                                                                ":CDTIPONEGOCIACAO", _
                                                                ":CDTIPOUNIDADE", _
                                                                ":DTNEGOCIACAO", _
                                                                ":QTKGS", _
                                                                ":VLNEGOCIACAO", _
                                                                ":CDLOCALENTREGA", _
                                                                ":DTVENCIMENTO", _
                                                                ":DTPAGAMENTO", _
                                                                ":VLPRECOFRETE", _
                                                                ":PCALIQICMS", _
                                                                ":ICBONUS", _
                                                                ":CDPAPELCOMPETENCIA", _
                                                                ":SQBOLSAGRUPOPREMIO", _
                                                                ":CDTIPOPESSOA", _
                                                                ":SQNEGOCIACAOPRE", _
                                                                ":DSMOTIVODTVENC", _
                                                                ":DTPRAZOFIXACAO", _
                                                                ":PCTAXAJUROS", _
                                                                ":SQSOLICITACAO", _
                                                                ":SQNEGSOLCITACAO", _
                                                                ":QtUmidadePadrao", _
                                                                ":PCSUJIDADEPADRAO", _
                                                                ":VLFRETEFABRICA", _
                                                                ":CDTIPOCACAU", _
                                                                ":CDFILIALENTREGA", _
                                                                ":ICCALCULAJUROS", _
                                                                ":QTDIACARENCIAJUROS", _
                                                                ":ICJUROSAPOSCARENCIA", _
                                                                ":ICIMPRIMEPAF", _
                                                                ":ICGP", _
                                                                ":DTVENCIMENTOGP", _
                                                                ":TAXAUSGP", _
                                                                ":SQNEGOCIACAO")

        Parametro(0) = DBParametro_Montar("CDCONTRATOPAF", Pesq_ContratoPAF.Codigo)
        Parametro(1) = DBParametro_Montar("CDTIPONEGOCIACAO", cboTipoNegociacao.SelectedValue)
        Parametro(2) = DBParametro_Montar("CDTIPOUNIDADE", cboUnidade.SelectedValue)
        Parametro(3) = DBParametro_Montar("DTNEGOCIACAO", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime)
        Parametro(4) = DBParametro_Montar("QTKGS", txtQuantidadeNegociacao.Value)
        Parametro(5) = DBParametro_Montar("VLNEGOCIACAO", txtValorUnitarioNegociacao.Value)
        Parametro(6) = DBParametro_Montar("CDLOCALENTREGA", cboLocalEntrega.SelectedValue)
        Parametro(7) = DBParametro_Montar("DTVENCIMENTO", Date_to_Oracle(txtDataVencimento.Text), OracleClient.OracleType.DateTime)
        Parametro(8) = DBParametro_Montar("DTPAGAMENTO", Date_to_Oracle(txtDataPagamento.Text), OracleClient.OracleType.DateTime)
        Parametro(9) = DBParametro_Montar("VLPRECOFRETE", txtValorFrete.Value)
        Parametro(10) = DBParametro_Montar("PCALIQICMS", txtAliquotaICMS.Value)
        Parametro(11) = DBParametro_Montar("ICBONUS", "N")

        If Not ObjUltraComboBox_LinhaSelecionada(cboBolsa) Then
            Parametro(12) = DBParametro_Montar("CDPAPELCOMPETENCIA", Nothing)
        Else
            Parametro(12) = DBParametro_Montar("CDPAPELCOMPETENCIA", cboBolsa.SelectedRow.Cells(0).Value)
        End If

        If ControleEdicaoTelaLocal = eControleEdicaoTela.PRE_NEGOCIACAO Then
            Parametro(13) = DBParametro_Montar("SQBOLSAGRUPOPREMIO", Nothing)
            Parametro(14) = DBParametro_Montar("CDTIPOPESSOA", Nothing)
            Parametro(15) = DBParametro_Montar("SQNEGOCIACAOPRE", SqPreNegociacao)
        Else
            'o premio não esta sendo usado, existe um cadastro fixo q é usado para todos
            Parametro(13) = DBParametro_Montar("SQBOLSAGRUPOPREMIO", 1)
            Parametro(14) = DBParametro_Montar("CDTIPOPESSOA", cboTipoPessoa.SelectedValue)
            Parametro(15) = DBParametro_Montar("SQNEGOCIACAOPRE", Nothing)
        End If

        If txtMotivoDataVencimento.Text = "" Then
            Parametro(16) = DBParametro_Montar("DSMOTIVODTVENC", Nothing)
        Else
            Parametro(16) = DBParametro_Montar("DSMOTIVODTVENC", txtMotivoDataVencimento.Text, OracleClient.OracleType.VarChar, , 4000)
        End If

        If txtDataParaFixacao.Enabled = True Then
            Parametro(17) = DBParametro_Montar("DTPRAZOFIXACAO", Date_to_Oracle(txtDataParaFixacao.Text), OracleClient.OracleType.DateTime)
        Else
            Parametro(17) = DBParametro_Montar("DTPRAZOFIXACAO", Nothing)
        End If

        Parametro(18) = DBParametro_Montar("PCTAXAJUROS", Me.txtTaxaJuros.Value)
        Parametro(19) = DBParametro_Montar("SQSOLICITACAO", Nothing)
        Parametro(20) = DBParametro_Montar("SQNEGSOLCITACAO", Nothing)
        Parametro(21) = DBParametro_Montar("QTUMIDADEPADRAO", QtUmidadePadrao)
        Parametro(22) = DBParametro_Montar("PCSUJIDADEPADRAO", PcSujidadePadrao)
        Parametro(23) = DBParametro_Montar("VLFRETEFABRICA", mVlFreteFilialFabrica_Padrao)
        Parametro(24) = DBParametro_Montar("CDTIPOCACAU", cboTipoCacau.SelectedValue)
        Parametro(25) = DBParametro_Montar("CDFILIALENTREGA", cboFilialEntrega.SelectedValue)

        If Me.chkCobraJuros.Checked = True Then
            Parametro(26) = DBParametro_Montar("ICCALCULAJUROS", "S")
            Parametro(27) = DBParametro_Montar("QTDIACARENCIAJUROS", txtDiasCarencia.Value)
            Parametro(28) = DBParametro_Montar("ICJUROSAPOSCARENCIA", IIf(chkJurosAposCarencia.Checked = True, "S", "N"))
        Else
            Parametro(26) = DBParametro_Montar("ICCALCULAJUROS", "N")
            Parametro(27) = DBParametro_Montar("QTDIACARENCIAJUROS", Nothing)
            Parametro(28) = DBParametro_Montar("ICJUROSAPOSCARENCIA", Nothing)
        End If

        If ImprimePAF = False Then
            Parametro(29) = DBParametro_Montar("ICIMPRIMEPAF", "N")
        Else
            Parametro(29) = DBParametro_Montar("ICIMPRIMEPAF", "S")
        End If

        Parametro(30) = DBParametro_Montar("ICGP", "N")
        Parametro(31) = DBParametro_Montar("DTVENCIMENTOGP", Nothing)
        Parametro(32) = DBParametro_Montar("TAXAUSGP", Nothing)
        Parametro(33) = DBParametro_Montar("SQNEGOCIACAO", Nothing, , ParameterDirection.Output)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        If DBTeveRetorno() Then
            lblNegociacao.Text = DBRetorno(1)

            If lblNegociacao.Text <> "" Then
                SqlText = "UPDATE SOF.NEGOCIACAO" & _
                          " SET VL_PREMIO_CRM = " & NVL(txtPremioCRM.Value, 0) & _
                          " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                            " AND SQ_NEGOCIACAO = " & lblNegociacao.Text
                If Not DBExecutar(SqlText) Then GoTo Erro
            End If
        End If

        Try
            SqlText = DBMontar_SP("SOF.SP_CALCULO_DIFERENCIAL", False, ":CD_CONTRATO_PAF", _
                                                                       ":SQ_NEGOCIACAO", _
                                                                       ":SQ_CONTRATO_FIXO", _
                                                                       ":SQ_PRE_NEGOCIACAO")
            If Not DBExecutar(SqlText, DBParametro_Montar("CD_CONTRATO_PAF", Pesq_ContratoPAF.Codigo), _
                                       DBParametro_Montar("SQ_NEGOCIACAO", lblNegociacao.Text), _
                                       DBParametro_Montar("SQ_CONTRATO_FIXO", Nothing), _
                                       DBParametro_Montar("SQ_PRE_NEGOCIACAO", Nothing)) Then GoTo Erro
        Catch ex As Exception
        End Try

        Return True

        Exit Function

Erro:
        Return False
    End Function

    Private Sub cboUnidade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnidade.SelectedIndexChanged
        QtFator = 0

        If Not ComboBox_LinhaSelecionada(cboUnidade) Then Exit Sub

        QtFator = DBQuery_ValorUnico("select qt_fator  from sof.tipo_unidade where cd_tipo_unidade =" & cboUnidade.SelectedValue)

    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Impressao_Negociacao(Pesq_ContratoPAF.Codigo, lblNegociacao.Text)
    End Sub

    Private Sub cmdPostoFazenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostoFazenda.Click
        Dim oForm As New frmConsultaGeral

        If Pesq_ContratoPAF.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar o contrato antes.")
            Exit Sub
        End If

        oForm.FiltroLocal_01 = 1
        oForm.FiltroLocal_02 = Pesq_ContratoPAF.Codigo
        oForm.FormatarTela(frmConsultaGeral.eConsultaGeral.MovimentacaoPosto)

        Form_Show(Nothing, oForm, True, True)
    End Sub

    Private Sub cmdPostoFabrica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostoFabrica.Click
        Dim oForm As New frmConsultaGeral

        If Pesq_ContratoPAF.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar o contrato antes.")
            Exit Sub
        End If

        oForm.FiltroLocal_01 = 2
        oForm.FiltroLocal_02 = Pesq_ContratoPAF.Codigo
        oForm.FormatarTela(frmConsultaGeral.eConsultaGeral.MovimentacaoPosto)

        Form_Show(Nothing, oForm, True, True)
    End Sub

    Private Sub Aplica_Cacau()
        Dim SqlText As String
        Dim SqCtrPAFNegMov As Long
        Dim SqCtrAFix As Long
        Dim VlCtr As Double
        Dim VlFix As Double
        Dim QtFix As Long
        Dim AplicPostoDif As Boolean
        Dim oData As DataTable
        Dim iCont As Integer
        Dim VlFixado As Double
        Dim QtFixado As Long

        AplicPostoDif = IIf(DBQuery_ValorUnico("select ic_aplic_posto_diferente from sof.filial where cd_filial=" & FilialLogada) = "S", True, False)

        If cboTipoNegociacao.SelectedValue = eTipoNegociacao.FIXO_REAL Then
            SqlText = "SELECT cf.vl_total, cf.vl_icms, cf.vl_inss, cf.sq_contrato_fixo, "
            SqlText = SqlText & "       DECODE (n.cd_local_entrega, "
            SqlText = SqlText & "               1, fil.vl_frete_filial_fazenda, "
            SqlText = SqlText & "               2, fil.vl_frete_filial_fabrica, "
            SqlText = SqlText & "               3, fil.vl_frete_fabrica, "
            SqlText = SqlText & "               0 "
            SqlText = SqlText & "              ) AS valor_frete "
            SqlText = SqlText & "  FROM sof.contrato_fixo cf, sof.negociacao n, sof.filial fil "
            SqlText = SqlText & " WHERE cf.cd_contrato_paf = n.cd_contrato_paf "
            SqlText = SqlText & "   AND cf.sq_negociacao = n.sq_negociacao "
            SqlText = SqlText & "   AND n.cd_filial_entrega = fil.cd_filial "
            SqlText = SqlText & "   and cf.cd_contrato_paf =  " & Pesq_ContratoPAF.Codigo
            SqlText = SqlText & "   and cf.sq_negociacao =  " & lblNegociacao.Text

            oData = DBQuery(SqlText)
            If Not objDataTable_Vazio(oData) Then
                SqCtrAFix = oData.Rows(0).Item("sq_contrato_fixo")
                VlCtr = oData.Rows(0).Item("vl_total") + oData.Rows(0).Item("vl_icms") + oData.Rows(0).Item("vl_inss")
            Else
                SqCtrAFix = -1
                Exit Sub
            End If
        Else
            SqCtrAFix = -1
            Exit Sub
        End If

        SqlText = "SELECT cpm.qt_kg_a_fixar, cpm.vl_a_fixar, m.vl_nf, m.qt_kg_liquido_nf, " & _
                  "cpm.sq_ctr_paf_movimentacao, cpm.sq_movimentacao, cpm.Sq_Movimentacao_Cessao_Direito " & _
                  "FROM sof.ctr_paf_movimentacao cpm, sof.Movimentacao m, sof.filial fil " & _
                  "WHERE m.sq_movimentacao = cpm.sq_movimentacao AND m.cd_filial_origem  =fil.cd_filial and " & _
                  "cpm.cd_contrato_paf = " & Pesq_ContratoPAF.Codigo & " AND " & _
                  "cpm.qt_kg_a_fixar <> 0 and " & _
                  "nvl(decode (m.cd_local_entrega,1,fil.vl_frete_filial_fazenda,2,fil.vl_frete_filial_fabrica,3,fil.vl_frete_fabrica,0)," & oData.Rows(0).Item("valor_frete") & ") = " & oData.Rows(0).Item("valor_frete")

        If cboLocalEntrega.SelectedValue <> 3 And Not AplicPostoDif Then
            SqlText = SqlText & " and M.CD_FILIAL_MOVIMENTACAO = " & cboFilialEntrega.SelectedValue & " "
        End If
        SqlText = SqlText & "order by m.sq_movimentacao"

        oData = DBQuery(SqlText)

        VlFixado = 0
        QtFixado = 0

        For iCont = 0 To oData.Rows.Count - 1
            If QtFixado + oData.Rows(iCont).Item("qt_kg_a_fixar") > Me.txtQuantidadeNegociacao.Value Then
                QtFix = Me.txtQuantidadeNegociacao.Value - QtFixado
                VlFix = Math.Round(QtFix / oData.Rows(iCont).Item("qt_kg_a_fixar") * oData.Rows(iCont).Item("vl_a_fixar"), 2) - 0.03
            Else
                QtFix = oData.Rows(iCont).Item("qt_kg_a_fixar")
                VlFix = Math.Round(oData.Rows(iCont).Item("vl_a_fixar"), 2)
            End If

            If SqCtrAFix <> -1 Then
                If VlFixado + VlFix > VlCtr Then
                    VlFix = Math.Round(VlCtr - VlFixado, 2)
                End If
            End If

            DBUsarTransacao = True


            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", _
                                                                            ":SQNEG", _
                                                                            ":SQCTRPAFMOV", _
                                                                            ":SQMOV", _
                                                                            ":SQMOVCD", _
                                                                            ":VLFIXO", _
                                                                            ":QTFIXO", _
                                                                            ":SQCTRPAFNEGMOV")

            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", Pesq_ContratoPAF.Codigo), _
                                       DBParametro_Montar("SQNEG", lblNegociacao.Text), _
                                       DBParametro_Montar("SQCTRPAFMOV", oData.Rows(iCont).Item("sq_ctr_paf_movimentacao")), _
                                       DBParametro_Montar("SQMOV", oData.Rows(iCont).Item("sq_movimentacao")), _
                                       DBParametro_Montar("SQMOVCD", oData.Rows(iCont).Item("Sq_Movimentacao_Cessao_Direito")), _
                                       DBParametro_Montar("VLFIXO", VlFix), _
                                       DBParametro_Montar("QTFIXO", QtFix), _
                                       DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro


            If SqCtrAFix <> -1 Then


                SqCtrPAFNegMov = DBRetorno(1)
                SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, _
                                                                               ":CDCTRPAF", _
                                                                               ":SQNEG", _
                                                                               ":SQCTRPAFMOV", _
                                                                               ":SQMOV", _
                                                                               ":SQMOVCD", _
                                                                               ":VLFIXO", _
                                                                               ":QTFIXO", _
                                                                               ":SQCTRPAFNEGMOV", _
                                                                               ":SQCTRFIX", _
                                                                               ":SQCTRPAFNEGCTRFIXMOV", _
                                                                               ":ICGERACONCILIACAO", _
                                                                               ":DSCONCILIACAO")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", Pesq_ContratoPAF.Codigo), _
                                           DBParametro_Montar("SQNEG", lblNegociacao.Text), _
                                           DBParametro_Montar("SQCTRPAFMOV", oData.Rows(iCont).Item("sq_ctr_paf_movimentacao")), _
                                           DBParametro_Montar("SQMOV", oData.Rows(iCont).Item("sq_movimentacao")), _
                                           DBParametro_Montar("SQMOVCD", oData.Rows(iCont).Item("Sq_Movimentacao_Cessao_Direito")), _
                                           DBParametro_Montar("VLFIXO", VlFix), _
                                           DBParametro_Montar("QTFIXO", QtFix), _
                                           DBParametro_Montar("SQCTRPAFNEGMOV", SqCtrPAFNegMov), _
                                           DBParametro_Montar("SQCTRFIX", SqCtrAFix), _
                                           DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                                           DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                                           DBParametro_Montar("DSCONCILIACAO", Nothing)) Then GoTo Erro
            End If

            If Not DBExecutarTransacao() Then GoTo Erro

            VlFixado = VlFixado + VlFix
            QtFixado = QtFixado + QtFix

            If QtFixado = Me.txtQuantidadeNegociacao.Value Then Exit Sub
        Next

        Exit Sub
Erro:

        TratarErro()
    End Sub
    Private Sub Aplica_Pagamento()
        Dim SqlText As String
        Dim VlCtr As Double
        Dim VlFix As Double
        Dim PcAdtoCtrFix As Double
        Dim PcAdtoNeg As Double
        Dim SqCtrAFix As Long
        Dim SqPagNeg As Long
        Dim SqNegPagJuros As Long
        Dim SqNegPagJurosCtrPAF As Long
        Dim SqNegPagJurosNeg As Long
        Dim VlNegJuros As Double
        Dim SqCtrFixPagJuros As Long
        Dim SqCtrFixPagJurosCtrPAF As Long
        Dim SqCtrFixPagJurosNeg As Long
        Dim SqCtrFixPagJurosCtrFix As Long
        Dim SqPagNegCtrFix As Long
        Dim VlCtrFixJuros As Double
        Dim iCont As Integer
        Dim oData As DataTable
        Dim VlFixado As Double

        SqlText = "select PC_PAG_APLICA_CTR_FIX, PC_PAG_APLICA_NEG from sof.parametro"
        oData = DBQuery(SqlText)

        PcAdtoCtrFix = oData.Rows(0).Item("PC_PAG_APLICA_CTR_FIX") / 100
        PcAdtoNeg = oData.Rows(0).Item("PC_PAG_APLICA_NEG") / 100

        If IcTipoNeg = 1 Then
            SqlText = "select cf.vl_total, decode(cf.ic_inclui_icms_pag,'S',cf.vl_icms,0) as vl_icms, cf.vl_inss, cf.sq_contrato_fixo, cf.vl_pag_fixo, " & _
                      "cf.qt_kg_fixo " & _
                      "from sof.contrato_fixo cf " & _
                      "where cf.cd_contrato_paf = " & Pesq_ContratoPAF.Codigo & " and " & _
                      "cf.sq_negociacao = " & lblNegociacao.Text
            oData = DBQuery(SqlText)

            If Not objDataTable_Vazio(oData) Then
                SqCtrAFix = oData.Rows(0).Item("sq_contrato_fixo")

                If SqCtrAFix = oData.Rows(0).Item("qt_kg_fixo") = txtQuantidadeNegociacao.Value Then
                    VlCtr = SqCtrAFix = oData.Rows(0).Item("vl_total") + SqCtrAFix = oData.Rows(0).Item("vl_icms")
                Else
                    VlCtr = (SqCtrAFix = oData.Rows(0).Item("vl_total") + SqCtrAFix = oData.Rows(0).Item("vl_icms")) * PcAdtoCtrFix
                End If

                VlCtr = VlCtr - SqCtrAFix = oData.Rows(0).Item("vl_pag_fixo")
            End If
        Else
            SqlText = SqlText & "      n.sq_negociacao = " & Me.lblNegociacao.Text

            SqlText = "select nvl(sum(pcp.vl_a_fixar),0) vl_a_fixar "
            SqlText = SqlText & "from sof.pag_ctr_paf pcp "
            SqlText = SqlText & "where pcp.cd_contrato_paf = " & Pesq_ContratoPAF.Codigo & " and "
            SqlText = SqlText & "      pcp.vl_a_fixar <> 0 AND PCP.SQ_CONFISSAO_DIVIDA IS NULL "
            SqlText = SqlText & "order by pcp.sq_pagamento"

            oData = DBQuery(SqlText)

            If oData.Rows.Count = 0 Then Exit Sub

            VlCtr = (Me.txtQuantidadeNegociacao.Value / Me.txtSaldo.Value) * SqCtrAFix = oData.Rows(0).Item("vl_a_fixar")

            SqCtrAFix = -1
        End If

        SqlText = "select nvl(pcp.vl_a_fixar,0) as vl_a_fixar, pcp.sq_pagamento, pcp.sq_pag_ctr_paf "
        SqlText = SqlText & "from sof.pag_ctr_paf pcp "
        SqlText = SqlText & "where pcp.cd_contrato_paf = " & Pesq_ContratoPAF.Codigo & " and "
        SqlText = SqlText & "      pcp.vl_a_fixar <> 0 AND PCP.SQ_CONFISSAO_DIVIDA IS NULL "
        SqlText = SqlText & "order by pcp.sq_pagamento"

        oData = DBQuery(SqlText)

        VlFixado = 0

        For iCont = 0 To oData.Rows.Count - 1
            If VlFixado + SqCtrAFix = oData.Rows(iCont).Item("vl_a_fixar") > VlCtr Then
                VlFix = VlCtr - VlFixado
            Else
                VlFix = oData.Rows(iCont).Item("vl_a_fixar")
            End If

            DBUsarTransacao = True

            If Not AplicacaoPagamentoNegociacao(Pesq_ContratoPAF.Codigo, _
                                lblNegociacao.Text, _
                                oData.Rows(iCont).Item("Sq_Pagamento"), _
                                oData.Rows(iCont).Item("sq_pag_ctr_paf"), _
                                VlFix, SqPagNeg, SqNegPagJuros, SqNegPagJurosCtrPAF, SqNegPagJurosNeg, _
                                 VlNegJuros, VlFix) Then GoTo Erro

            If SqCtrAFix <> -1 Then
                If Not AplicacaoPagamentoContratoFixo(Pesq_ContratoPAF.Codigo, _
                                                       lblNegociacao.Text, _
                                                       SqCtrAFix, _
                                                       oData.Rows(iCont).Item("Sq_Pagamento"), _
                                                       oData.Rows(iCont).Item("sq_pag_ctr_paf"), _
                                                       SqPagNeg, _
                                                       VlFix, SqPagNegCtrFix, VlCtrFixJuros, VlFix, _
                                                        SqCtrFixPagJuros, SqCtrFixPagJurosCtrPAF, SqCtrFixPagJurosNeg, _
                                                       SqCtrFixPagJurosCtrFix) Then GoTo Erro


                If SqNegPagJuros <> 0 Then
                    If Not AplicacaoPagamentoContratoFixo(Pesq_ContratoPAF.Codigo, _
                                         lblNegociacao.Text, _
                                         SqCtrAFix, _
                                         SqNegPagJuros, _
                                         SqNegPagJurosCtrPAF, _
                                         SqNegPagJurosNeg, _
                                         VlNegJuros, SqPagNegCtrFix) Then GoTo Erro
                End If
            End If

            If Not DBExecutarTransacao() Then GoTo Erro

            VlFixado = VlFixado + VlFix + VlNegJuros + VlCtrFixJuros

            If VlFixado >= VlCtr Then Exit For
        Next

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cboTipoCacau_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoCacau.SelectedIndexChanged
        If cboTipoCacau.SelectedValue = enTipoCacau.CACAU_CRM Then
            txtPremioCRM.Visible = True
            lbl_CRM.Visible = True
            lbl_CRM.Left = lbl_ValorTotal.Left
            txtPremioCRM.Left = txtValorTotal.Left
            lbl_ValorTotal.Visible = False
            txtValorTotal.Visible = False
        Else
            txtPremioCRM.Visible = False
            lbl_CRM.Visible = False
            lbl_ValorTotal.Visible = True
            txtValorTotal.Visible = True
            txtPremioCRM.Value = 0
        End If
    End Sub
End Class