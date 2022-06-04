Public Class frmParametroGeral
    Const cnt_SEC_Tela As String = "Administracao_ParametrosGerais"

    Private Sub frmParametroGeral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Filial(cboFilialMae, True)
        ComboBox_Carregar_Tipo_Negociacao(cboTipoNegociacaoPadrao, True)
        ComboBox_Carregar_Modalidade_Conciliacao(cboModalidadeConciliacaoAcordo, True)
        ComboBox_Carregar_Modalidade_Conciliacao(cboModalidadeConciliacaoAcordoJuros, True)
        ComboBox_Carregar_Modalidade_Conciliacao(cboModalidadeConciliacaoDevolucao, True)
        ComboBox_Carregar_Modalidade_Conciliacao(cboModalidadeConciliacaoEstorno, True)
        ComboBox_Carregar_Modalidade_Conciliacao(cboModalidadeConciliacaoEstornoJuros, True)
        ComboBox_Carregar_Modalidade_Conciliacao(cboModalidadeConciliacaoICMS, True)
        ComboBox_Carregar_Tipo_Aprovacao(cboTipoAprovacaoInterna, True)
        ComboBox_Carregar_Tipo_ContratoPAF(cboTipoCtrPAFNegociaMaster, True)
        ComboBox_Carregar_Tipo_Frete(cboTipoFreteRecebimentoCacau, True)
        ComboBox_Carregar_Tipo_Frete(cboTipoFreteTransferencia, True)
        ComboBox_Carregar_Tipo_Pagamento(cboTipoPagamentoDescontoJuros, True)
        ComboBox_Carregar_Tipo_Pagamento(cboTipoPagamentoGP, True)
        ComboBox_Carregar_Tipo_Pagamento(cboTipoPagamentoICMS, True)
        ComboBox_Carregar_Tipo_Pagamento(cboTipoPagamentoJuros, True)
        ComboBox_Carregar_Tipo_Pagamento(cboTipoPagamentoSujidade, True)
        ComboBox_Carregar_Tipo_Pagamento(cboTipoPagamentoUmidade, True)
        ComboBox_Carregar_Moeda_Credito(cboMoedaCredito, True)

        Pesq_Desagio.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_DesagioSujidade.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_EntradaFixoImportado.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao_Aplicacao
        Pesq_EntradaFixoRD.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao_Aplicacao
        Pesq_Funrural.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_ICMS.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_ICMSImpotacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_ICMSTransferencia.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_RecebimentoCacau.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_recebimentoCacauImportado.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_SaidaAordem.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao_Aplicacao
        Pesq_SaidaAordemImportado.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao_Aplicacao

        Pesq_TP_MOV_EST_PROV_NF.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TP_MOV_EST_REV_AFIXAR.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TP_MOV_EST_REV_DIF.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TP_MOV_PROV_NF.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TP_MOV_REV_AFIXAR.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TP_MOV_REV_DIF.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao

        SEC_ValidarBotao(cmdGravar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)

        CarregarDados()
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * FROM SOF.PARAMETRO"

        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            txtSafra.Value = oData.Rows(0).Item("cd_safra")
            txtDataSistema.Value = oData.Rows(0).Item("dt_sistema")
            txtDataSafra.Value = oData.Rows(0).Item("dt_safra")
            Pesq_SaidaAordem.Codigo = NVL(oData.Rows(0).Item("cd_tp_mov_fixacao_saida"), 0)
            Pesq_EntradaFixoRD.Codigo = NVL(oData.Rows(0).Item("cd_tp_mov_fixacao_entrada"), 0)
            txtEmpresa.Value = oData.Rows(0).Item("cd_empresa")
            ComboBox_Possicionar(cboFilialMae, oData.Rows(0).Item("cd_filial_mae"))
            txtValorMinimoNFComplementar.Value = oData.Rows(0).Item("vl_minimo_nf_complementar")
            Pesq_ICMS.Codigo = NVL(oData.Rows(0).Item("cd_tp_mov_icms"), 0)
            Pesq_ICMSTransferencia.Codigo = NVL(oData.Rows(0).Item("cd_tp_mov_icms_transf"), 0)
            Pesq_ICMSImpotacao.Codigo = NVL(oData.Rows(0).Item("cd_tp_mov_icms_imp"), 0)
            Pesq_Desagio.Codigo = NVL(oData.Rows(0).Item("cd_tp_mov_desagio"), 0)
            Pesq_DesagioSujidade.Codigo = NVL(oData.Rows(0).Item("cd_tp_mov_desagio_suji"), 0)
            Pesq_Funrural.Codigo = NVL(oData.Rows(0).Item("cd_tp_mov_funrural"), 0)
            Pesq_RecebimentoCacau.Codigo = NVL(oData.Rows(0).Item("cd_tp_mov_recebimento"), 0)
            Pesq_recebimentoCacauImportado.Codigo = NVL(oData.Rows(0).Item("cd_tp_mov_importacao"), 0)
            Pesq_SaidaAordemImportado.Codigo = NVL(oData.Rows(0).Item("cd_tp_mov_fix_saida_imp"), 0)
            Pesq_EntradaFixoImportado.Codigo = NVL(oData.Rows(0).Item("cd_tp_mov_fix_entrada_imp"), 0)

            Pesq_TP_MOV_EST_PROV_NF.Codigo = NVL(oData.Rows(0).Item("CD_TP_MOV_ESAJ_PROV_NF_CPL_RDE"), 0)
            Pesq_TP_MOV_EST_REV_AFIXAR.Codigo = NVL(oData.Rows(0).Item("CD_TP_MOV_ESAJ_REV_EST_BLS_RDE"), 0)
            Pesq_TP_MOV_EST_REV_DIF.Codigo = NVL(oData.Rows(0).Item("CD_TP_MOV_ESAJ_REV_EST_FXO_RDE"), 0)
            Pesq_TP_MOV_PROV_NF.Codigo = NVL(oData.Rows(0).Item("CD_TP_MOV_AJST_PROV_NF_CPL_RDE"), 0)
            Pesq_TP_MOV_REV_AFIXAR.Codigo = NVL(oData.Rows(0).Item("CD_TP_MOV_AJST_REV_EST_BLS_RDE"), 0)
            Pesq_TP_MOV_REV_DIF.Codigo = NVL(oData.Rows(0).Item("CD_TP_MOV_AJST_REV_EST_FXO_RDE"), 0)

            txtContaContabilINSS.Text = "" & oData.Rows(0).Item("nu_conta_contabil_inss")
            txtCia.Value = oData.Rows(0).Item("cd_companhia")
            txtMoeda.Text = "" & oData.Rows(0).Item("cd_moeda_jde")
            txtTipoDocumentoJDE.Text = "" & oData.Rows(0).Item("cd_tipo_documento_jde")
            txtDiretorio.Text = "" & oData.Rows(0).Item("ds_diretorio_interface_jde")
            txtMaximoCarenciaJuros.Value = oData.Rows(0).Item("nu_dias_max_carencia_juros")
            txtDiasMaximoFixacao.Value = oData.Rows(0).Item("nu_dias_max_fixacao_ctr")
            txtEmailInterfaceJDE.Text = "" & oData.Rows(0).Item("ds_email_jde_pag")

            chkHabilitaPagamentoJDE.Checked = IIf(oData.Rows(0).Item("ic_habilita_pagto") = "S", True, False)
            chkHabilitaBranche.Checked = IIf(oData.Rows(0).Item("ic_habilita_branche") = "S", True, False)
            chkSacariaFornecedor.Checked = IIf(oData.Rows(0).Item("ic_sacaria_fornecedor") = "S", True, False)
            chkDesagioNF.Checked = IIf(oData.Rows(0).Item("IC_DESAGIO_AUTOMATICO") = "S", True, False)
            chkDesagioContrato.Checked = IIf(oData.Rows(0).Item("IC_DESAGIO_CONTRATO") = "S", True, False)
            chkJurosAutomatico.Checked = IIf(oData.Rows(0).Item("IC_JUROS_AUTOMATICO") = "S", True, False)
            chkEnviaEmailCredito.Checked = IIf(oData.Rows(0).Item("IC_ENVIA_EMAIL_CREDITO") = "S", True, False)
            chkCacauAordemMaster.Checked = IIf(oData.Rows(0).Item("IC_AORDEM_MASTER") = "S", True, False)

            txtEmailContato.Text = "" & oData.Rows(0).Item("ds_email_atendimento")
            txtEmailInovacao.Text = "" & oData.Rows(0).Item("ds_email_inovacao")
            txtEmailQualidade.Text = "" & oData.Rows(0).Item("ds_email_qualidade")
            txtEmailAlteracaoJuros.Text = "" & oData.Rows(0).Item("ds_email_juros")
            txtEmailEstornoJuros.Text = "" & oData.Rows(0).Item("ds_email_estorno_juros_neg")
            txtEmailVencimentoForaPadrao.Text = "" & oData.Rows(0).Item("ds_email_neg_dt_venc")

            ComboBox_Possicionar(cboTipoFreteRecebimentoCacau, CInt(NVL(oData.Rows(0).Item("CD_TIPO_FRETE_MOV"), -1)))
            ComboBox_Possicionar(cboTipoFreteTransferencia, CInt(NVL(oData.Rows(0).Item("CD_TIPO_FRETE_TRANSF"), -1)))
            ComboBox_Possicionar(cboTipoNegociacaoPadrao, CInt(NVL(oData.Rows(0).Item("CD_TIPO_negociacao_padrao"), -1)))
            ComboBox_Possicionar(cboTipoAprovacaoInterna, CInt(NVL(oData.Rows(0).Item("CD_TIPO_APROVACAO_INTERNO"), -1)))
            ComboBox_Possicionar(cboTipoPagamentoICMS, CInt(NVL(oData.Rows(0).Item("cd_tipo_pag_icms"), -1)))
            ComboBox_Possicionar(cboTipoPagamentoUmidade, CInt(NVL(oData.Rows(0).Item("cd_tp_pag_desagio_umidade"), -1)))
            ComboBox_Possicionar(cboTipoPagamentoSujidade, CInt(NVL(oData.Rows(0).Item("cd_tp_pag_desagio_sujidade"), -1)))
            ComboBox_Possicionar(cboModalidadeConciliacaoAcordo, CInt(NVL(oData.Rows(0).Item("cd_conc_modal_desagio_acordo"), -1)))
            ComboBox_Possicionar(cboModalidadeConciliacaoEstorno, CInt(NVL(oData.Rows(0).Item("cd_conc_modal_desagio_estorno"), -1)))
            ComboBox_Possicionar(cboTipoPagamentoJuros, CInt(NVL(oData.Rows(0).Item("cd_tp_pag_juros"), -1)))
            ComboBox_Possicionar(cboTipoPagamentoDescontoJuros, CInt(NVL(oData.Rows(0).Item("CD_TP_PAG_DESCONTO_JUROS"), -1)))
            ComboBox_Possicionar(cboModalidadeConciliacaoAcordoJuros, CInt(NVL(oData.Rows(0).Item("cd_conc_modal_juros_acordo"), -1)))
            ComboBox_Possicionar(cboModalidadeConciliacaoEstornoJuros, CInt(NVL(oData.Rows(0).Item("cd_conc_modal_juros_estorno"), -1)))
            ComboBox_Possicionar(cboModalidadeConciliacaoDevolucao, CInt(NVL(oData.Rows(0).Item("CD_CONC_MODAL_DEVOLUCAO"), -1)))

            txtJurosAoMes.Value = oData.Rows(0).Item("pc_juros_ao_mes")

            txtDataVigencia.Value = CDate(NVL(oData.Rows(0).Item("DT_VIGENCIA_DESAGIO"), DataSistema))

            txtAplicacaoNegociacaoMaxima.Value = CDbl(NVL(oData.Rows(0).Item("PC_PAG_APLICA_NEG"), 0))
            txtAplicacaoContratoFixoMaximo.Value = CDbl(NVL(oData.Rows(0).Item("PC_PAG_APLICA_CTR_FIX"), 0))

            If NVL(oData.Rows(0).Item("IC_JUROS_CTR_FIX"), "N") = "S" Then
                optCobraJuros.Value = "CF"
            Else
                If NVL(oData.Rows(0).Item("IC_JUROS_NEG"), "N") = "S" Then
                    optCobraJuros.Value = "NE"
                Else
                    optCobraJuros.Value = "NR"
                End If
            End If

            ComboBox_Possicionar(cboTipoCtrPAFNegociaMaster, CLng(NVL(oData.Rows(0).Item("CD_TP_CTR_PAF_NEG_MASTER"), -1)))
            ComboBox_Possicionar(cboModalidadeConciliacaoICMS, CDbl(NVL(oData.Rows(0).Item("CD_CONCILIACAO_ICMS"), 0)))
            ComboBox_Possicionar(cboTipoPagamentoGP, CInt(NVL(oData.Rows(0).Item("CD_TIPO_PAG_GP"), -1)))

            'Parametros do class
            txtCodigoCompra.Text = "" & oData.Rows(0).Item("CD_COMPRA_CLASS")
            txtTipoDocumento.Text = "" & oData.Rows(0).Item("CD_TIPO_DOC_CLASS")
            txtTipoPedido.Text = "" & oData.Rows(0).Item("CD_TIPO_PEDIDO_CLASS")
            txtNivelAprovacaoPagamento.Text = NVL(oData.Rows(0).Item("QT_NIVEL_APROVACAO_PAGAMENTO"), 0)

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("IC_MOEDA_CREDITO")) Then
                SqlText = "SELECT A.CD_STATUS" & _
                          " FROM SOF.PROCESSO_STATUS A" & _
                          " WHERE A.CD_PROCESSO = " & enProcesso_Status.Moeda & _
                           " AND A.IC_STATUS = " & QuotedStr(oData.Rows(0).Item("IC_MOEDA_CREDITO"))
                ComboBox_Possicionar(cboMoedaCredito, DBQuery_ValorUnico(SqlText))
            End If
        End If

        txtEmailSeguraca.Text = DBQuery_ValorUnico("SELECT DS_EMAIL_FISCAL FROM SOF.PARAMETRO_FISCAL", "")
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim oParametro(71) As DBParamentro
        Dim SqlTextAux As String

        If Not ComboBox_LinhaSelecionada(cboFilialMae) Then
            Msg_Mensagem("Favor selecionar uma filial valida.")
            cboFilialMae.Focus()
            Exit Sub
        End If
        If Trim(txtTipoDocumento.Text) = "" Then
            Msg_Mensagem("Favor informar o tipo de documento da interface do livro fiscal. Sem essa informação a interface não funcionara")
            txtTipoDocumento.Focus()
            Exit Sub
        End If

        SqlText = DBMontar_Update("SOF.PARAMETRO", GerarArray("CD_TP_MOV_FIXACAO_SAIDA", ":CD_TP_MOV_FIXACAO_SAIDA", _
                                                              "CD_TP_MOV_FIXACAO_ENTRADA", ":CD_TP_MOV_FIXACAO_ENTRADA", _
                                                              "CD_EMPRESA", ":CD_EMPRESA", _
                                                              "CD_FILIAL_MAE", ":CD_FILIAL_MAE", _
                                                              "VL_MINIMO_NF_COMPLEMENTAR", ":VL_MINIMO_NF_COMPLEMENTAR", _
                                                              "CD_TP_MOV_ICMS", ":CD_TP_MOV_ICMS", _
                                                              "CD_TP_MOV_ICMS_TRANSF", ":CD_TP_MOV_ICMS_TRANSF", _
                                                              "CD_TP_MOV_ICMS_IMP", ":CD_TP_MOV_ICMS_IMP", _
                                                              "CD_TP_MOV_DESAGIO", ":CD_TP_MOV_DESAGIO", _
                                                              "CD_TP_MOV_DESAGIO_SUJI", ":CD_TP_MOV_DESAGIO_SUJI", _
                                                              "CD_TP_MOV_FUNRURAL", ":CD_TP_MOV_FUNRURAL", _
                                                              "CD_TP_MOV_RECEBIMENTO", ":CD_TP_MOV_RECEBIMENTO", _
                                                              "CD_TP_MOV_IMPORTACAO", ":CD_TP_MOV_IMPORTACAO", _
                                                              "CD_TP_MOV_FIX_SAIDA_IMP", ":CD_TP_MOV_FIX_SAIDA_IMP", _
                                                              "CD_TP_MOV_FIX_ENTRADA_IMP", ":CD_TP_MOV_FIX_ENTRADA_IMP", _
                                                              "NU_CONTA_CONTABIL_INSS", ":NU_CONTA_CONTABIL_INSS", _
                                                              "CD_COMPANHIA", ":CD_COMPANHIA", _
                                                              "CD_MOEDA_JDE", ":CD_MOEDA_JDE", _
                                                              "CD_TIPO_DOCUMENTO_JDE", ":CD_TIPO_DOCUMENTO_JDE", _
                                                              "DS_DIRETORIO_INTERFACE_JDE", ":DS_DIRETORIO_INTERFACE_JDE", _
                                                              "DS_EMAIL_JDE_PAG", ":DS_EMAIL_JDE_PAG", _
                                                              "IC_HABILITA_PAGTO", ":IC_HABILITA_PAGTO", _
                                                              "IC_HABILITA_BRANCHE", ":IC_HABILITA_BRANCHE", _
                                                              "IC_SACARIA_FORNECEDOR", ":IC_SACARIA_FORNECEDOR", _
                                                              "IC_DESAGIO_AUTOMATICO", ":IC_DESAGIO_AUTOMATICO", _
                                                              "IC_DESAGIO_CONTRATO", ":IC_DESAGIO_CONTRATO", _
                                                              "DS_EMAIL_ATENDIMENTO", ":DS_EMAIL_ATENDIMENTO", _
                                                              "DS_EMAIL_INOVACAO", ":DS_EMAIL_INOVACAO", _
                                                              "DS_EMAIL_QUALIDADE", ":DS_EMAIL_QUALIDADE", _
                                                              "DS_EMAIL_JUROS", ":DS_EMAIL_JUROS", _
                                                              "DS_EMAIL_ESTORNO_JUROS_NEG", ":DS_EMAIL_ESTORNO_JUROS_NEG", _
                                                              "DS_EMAIL_NEG_DT_VENC", ":DS_EMAIL_NEG_DT_VENC", _
                                                              "NU_DIAS_MAX_CARENCIA_JUROS", ":NU_DIAS_MAX_CARENCIA_JUROS", _
                                                              "NU_DIAS_MAX_FIXACAO_CTR", ":NU_DIAS_MAX_FIXACAO_CTR", _
                                                              "CD_TIPO_FRETE_MOV", ":CD_TIPO_FRETE_MOV", _
                                                              "CD_TIPO_FRETE_TRANSF", ":CD_TIPO_FRETE_TRANSF", _
                                                              "CD_TIPO_NEGOCIACAO_PADRAO", ":CD_TIPO_NEGOCIACAO_PADRAO", _
                                                              "CD_TIPO_APROVACAO_INTERNO", ":CD_TIPO_APROVACAO_INTERNO", _
                                                              "CD_TP_PAG_DESAGIO_UMIDADE", ":CD_TP_PAG_DESAGIO_UMIDADE", _
                                                              "CD_TIPO_PAG_ICMS", ":CD_TIPO_PAG_ICMS", _
                                                              "CD_TP_PAG_DESAGIO_SUJIDADE", ":CD_TP_PAG_DESAGIO_SUJIDADE", _
                                                              "CD_CONC_MODAL_DESAGIO_ACORDO", ":CD_CONC_MODAL_DESAGIO_ACORDO", _
                                                              "CD_CONC_MODAL_DESAGIO_ESTORNO", ":CD_CONC_MODAL_DESAGIO_ESTORNO", _
                                                              "CD_TP_PAG_JUROS", ":CD_TP_PAG_JUROS", _
                                                              "CD_TP_PAG_DESCONTO_JUROS", ":CD_TP_PAG_DESCONTO_JUROS", _
                                                              "CD_CONC_MODAL_JUROS_ACORDO", ":CD_CONC_MODAL_JUROS_ACORDO", _
                                                              "CD_CONC_MODAL_JUROS_ESTORNO", ":CD_CONC_MODAL_JUROS_ESTORNO", _
                                                              "IC_JUROS_AUTOMATICO", ":IC_JUROS_AUTOMATICO", _
                                                              "PC_JUROS_AO_MES", ":PC_JUROS_AO_MES", _
                                                              "DT_VIGENCIA_DESAGIO", ":DT_VIGENCIA_DESAGIO", _
                                                              "IC_ENVIA_EMAIL_CREDITO", ":IC_ENVIA_EMAIL_CREDITO", _
                                                              "IC_AORDEM_MASTER", ":IC_AORDEM_MASTER", _
                                                              "CD_CONC_MODAL_DEVOLUCAO", ":CD_CONC_MODAL_DEVOLUCAO", _
                                                              "PC_PAG_APLICA_NEG", ":PC_PAG_APLICA_NEG", _
                                                              "PC_PAG_APLICA_CTR_FIX", ":PC_PAG_APLICA_CTR_FIX", _
                                                              "IC_JUROS_NEG", ":IC_JUROS_NEG", _
                                                              "IC_JUROS_CTR_FIX", ":IC_JUROS_CTR_FIX", _
                                                              "IC_JUROS_NEG_REC", ":IC_JUROS_NEG_REC", _
                                                              "CD_TP_CTR_PAF_NEG_MASTER", ":CD_TP_CTR_PAF_NEG_MASTER", _
                                                              "CD_CONCILIACAO_ICMS", ":CD_CONCILIACAO_ICMS", _
                                                              "CD_TIPO_PAG_GP", ":CD_TIPO_PAG_GP", _
                                                              "CD_COMPRA_CLASS", ":CD_COMPRA_CLASS", _
                                                              "CD_TIPO_DOC_CLASS", ":CD_TIPO_DOC_CLASS", _
                                                              "CD_TIPO_PEDIDO_CLASS", ":CD_TIPO_PEDIDO_CLASS", _
                                                              "CD_TP_MOV_ESAJ_PROV_NF_CPL_RDE", ":CD_TP_MOV_ESAJ_PROV_NF_CPL_RDE", _
                                                              "CD_TP_MOV_ESAJ_REV_EST_BLS_RDE", ":CD_TP_MOV_ESAJ_REV_EST_BLS_RDE", _
                                                              "CD_TP_MOV_ESAJ_REV_EST_FXO_RDE", ":CD_TP_MOV_ESAJ_REV_EST_FXO_RDE", _
                                                              "CD_TP_MOV_AJST_PROV_NF_CPL_RDE", ":CD_TP_MOV_AJST_PROV_NF_CPL_RDE", _
                                                              "CD_TP_MOV_AJST_REV_EST_BLS_RDE", ":CD_TP_MOV_AJST_REV_EST_BLS_RDE", _
                                                              "CD_TP_MOV_AJST_REV_EST_FXO_RDE", ":CD_TP_MOV_AJST_REV_EST_FXO_RDE", _
                                                              "IC_MOEDA_CREDITO", ":IC_MOEDA_CREDITO", _
                                                              "QT_NIVEL_APROVACAO_PAGAMENTO", ":QT_NIVEL_APROVACAO_PAGAMENTO"), _
                                                  Nothing, False)

        oParametro(0) = DBParametro_Montar("cd_tp_mov_fixacao_saida", NULLIf(Pesq_SaidaAordem.Codigo, 0))
        oParametro(1) = DBParametro_Montar("cd_tp_mov_fixacao_entrada", NULLIf(Pesq_EntradaFixoRD.Codigo, 0))
        oParametro(2) = DBParametro_Montar("cd_empresa", NULLIf(txtEmpresa.Value, 0))
        oParametro(3) = DBParametro_Montar("cd_filial_mae", cboFilialMae.SelectedValue)
        oParametro(4) = DBParametro_Montar("vl_minimo_nf_complementar", txtValorMinimoNFComplementar.Value)
        oParametro(5) = DBParametro_Montar("cd_tp_mov_icms", NULLIf(Pesq_ICMS.Codigo, 0))
        oParametro(6) = DBParametro_Montar("cd_tp_mov_icms_transf", NULLIf(Pesq_ICMSTransferencia.Codigo, 0))
        oParametro(7) = DBParametro_Montar("cd_tp_mov_icms_imp", NULLIf(Pesq_ICMSImpotacao.Codigo, 0))
        oParametro(8) = DBParametro_Montar("cd_tp_mov_desagio", NULLIf(Pesq_Desagio.Codigo, 0))
        oParametro(9) = DBParametro_Montar("cd_tp_mov_desagio_suji", NULLIf(Pesq_DesagioSujidade.Codigo, 0))
        oParametro(10) = DBParametro_Montar("cd_tp_mov_funrural", NULLIf(Pesq_Funrural.Codigo, 0))
        oParametro(11) = DBParametro_Montar("cd_tp_mov_recebimento", NULLIf(Pesq_RecebimentoCacau.Codigo, 0))
        oParametro(12) = DBParametro_Montar("cd_tp_mov_importacao", NULLIf(Pesq_recebimentoCacauImportado.Codigo, 0))
        oParametro(13) = DBParametro_Montar("cd_tp_mov_fix_saida_imp", NULLIf(Pesq_SaidaAordemImportado.Codigo, 0))
        oParametro(14) = DBParametro_Montar("cd_tp_mov_fix_entrada_imp", NULLIf(Pesq_EntradaFixoImportado.Codigo, 0))
        oParametro(15) = DBParametro_Montar("nu_conta_contabil_inss", NULLIf(txtContaContabilINSS.Text, ""))
        oParametro(16) = DBParametro_Montar("cd_companhia", txtCia.Value)
        oParametro(17) = DBParametro_Montar("cd_moeda_jde", txtMoeda.Text)
        oParametro(18) = DBParametro_Montar("cd_tipo_documento_jde", txtTipoDocumentoJDE.Text)
        oParametro(19) = DBParametro_Montar("ds_diretorio_interface_jde", txtDiretorio.Text)
        oParametro(20) = DBParametro_Montar("ds_email_jde_pag", NULLIf(txtEmailInterfaceJDE.Text, ""), OracleClient.OracleType.VarChar, , 2000)
        oParametro(21) = DBParametro_Montar("ic_habilita_pagto", IIf(chkHabilitaPagamentoJDE.Checked, "S", "N"))
        oParametro(22) = DBParametro_Montar("ic_habilita_branche", IIf(chkHabilitaBranche.Checked, "S", "N"))
        oParametro(23) = DBParametro_Montar("ic_sacaria_fornecedor", IIf(chkSacariaFornecedor.Checked, "S", "N"))
        oParametro(24) = DBParametro_Montar("IC_DESAGIO_AUTOMATICO", IIf(chkDesagioNF.Checked, "S", "N"))
        oParametro(25) = DBParametro_Montar("IC_DESAGIO_CONTRATO", IIf(chkDesagioContrato.Checked, "S", "N"))
        oParametro(26) = DBParametro_Montar("ds_email_atendimento", NULLIf(txtEmailContato.Text, ""), , , 200)
        oParametro(27) = DBParametro_Montar("ds_email_inovacao", NULLIf(txtEmailInovacao.Text, ""), , , 200)
        oParametro(28) = DBParametro_Montar("ds_email_qualidade", NULLIf(txtEmailQualidade.Text, ""), , , 200)
        oParametro(29) = DBParametro_Montar("ds_email_juros", NULLIf(txtEmailAlteracaoJuros.Text, ""), , , 200)
        oParametro(30) = DBParametro_Montar("ds_email_estorno_juros_neg", NULLIf(txtEmailEstornoJuros.Text, ""), , , 200)
        oParametro(31) = DBParametro_Montar("ds_email_neg_dt_venc", NULLIf(txtEmailVencimentoForaPadrao.Text, ""), , , 200)
        oParametro(32) = DBParametro_Montar("nu_dias_max_carencia_juros", txtMaximoCarenciaJuros.Value)
        oParametro(33) = DBParametro_Montar("nu_dias_max_fixacao_ctr", txtDiasMaximoFixacao.Value)

        If ComboBox_LinhaSelecionada(cboTipoFreteRecebimentoCacau) Then
            oParametro(34) = DBParametro_Montar("CD_TIPO_FRETE_MOV", cboTipoFreteRecebimentoCacau.SelectedValue)
        Else
            oParametro(34) = DBParametro_Montar("CD_TIPO_FRETE_MOV", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboTipoFreteTransferencia) Then
            oParametro(35) = DBParametro_Montar("CD_TIPO_FRETE_TRANSF", cboTipoFreteTransferencia.SelectedValue)
        Else
            oParametro(35) = DBParametro_Montar("CD_TIPO_FRETE_TRANSF", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboTipoNegociacaoPadrao) Then
            oParametro(36) = DBParametro_Montar("CD_TIPO_negociacao_padrao", cboTipoNegociacaoPadrao.SelectedValue)
        Else
            oParametro(36) = DBParametro_Montar("CD_TIPO_negociacao_padrao", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboTipoAprovacaoInterna) Then
            oParametro(37) = DBParametro_Montar("CD_TIPO_APROVACAO_INTERNO", cboTipoAprovacaoInterna.SelectedValue)
        Else
            oParametro(37) = DBParametro_Montar("CD_TIPO_APROVACAO_INTERNO", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboTipoPagamentoUmidade) Then
            oParametro(38) = DBParametro_Montar("cd_tp_pag_desagio_umidade", cboTipoPagamentoUmidade.SelectedValue)
        Else
            oParametro(38) = DBParametro_Montar("cd_tp_pag_desagio_umidade", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboTipoPagamentoICMS) Then
            oParametro(39) = DBParametro_Montar("cd_tipo_pag_icms", cboTipoPagamentoICMS.SelectedValue)
        Else
            oParametro(39) = DBParametro_Montar("cd_tipo_pag_icms", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboTipoPagamentoSujidade) Then
            oParametro(40) = DBParametro_Montar("cd_tp_pag_desagio_sujidade", cboTipoPagamentoSujidade.SelectedValue)
        Else
            oParametro(40) = DBParametro_Montar("cd_tp_pag_desagio_sujidade", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboModalidadeConciliacaoAcordo) Then
            oParametro(41) = DBParametro_Montar("cd_conc_modal_desagio_acordo", cboModalidadeConciliacaoAcordo.SelectedValue)
        Else
            oParametro(41) = DBParametro_Montar("cd_conc_modal_desagio_acordo", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboModalidadeConciliacaoEstorno) Then
            oParametro(42) = DBParametro_Montar("cd_conc_modal_desagio_estorno", cboModalidadeConciliacaoEstorno.SelectedValue)
        Else
            oParametro(42) = DBParametro_Montar("cd_conc_modal_desagio_estorno", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboTipoPagamentoJuros) Then
            oParametro(43) = DBParametro_Montar("cd_tp_pag_juros", cboTipoPagamentoJuros.SelectedValue)
        Else
            oParametro(43) = DBParametro_Montar("cd_tp_pag_juros", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboTipoPagamentoDescontoJuros) Then
            oParametro(44) = DBParametro_Montar("CD_TP_PAG_DESCONTO_JUROS", cboTipoPagamentoDescontoJuros.SelectedValue)
        Else
            oParametro(44) = DBParametro_Montar("CD_TP_PAG_DESCONTO_JUROS", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboModalidadeConciliacaoAcordoJuros) Then
            oParametro(45) = DBParametro_Montar("cd_conc_modal_juros_acordo", cboModalidadeConciliacaoAcordoJuros.SelectedValue)
        Else
            oParametro(45) = DBParametro_Montar("cd_conc_modal_juros_acordo", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboModalidadeConciliacaoEstornoJuros) Then
            oParametro(46) = DBParametro_Montar("cd_conc_modal_juros_estorno", cboModalidadeConciliacaoEstornoJuros.SelectedValue)
        Else
            oParametro(46) = DBParametro_Montar("cd_conc_modal_juros_estorno", Nothing)
        End If

        oParametro(47) = DBParametro_Montar("IC_JUROS_AUTOMATICO", IIf(chkJurosAutomatico.Checked = False, "N", "S"))
        oParametro(48) = DBParametro_Montar("pc_juros_ao_mes", txtJurosAoMes.Value)
        oParametro(49) = DBParametro_Montar("DT_VIGENCIA_DESAGIO", Date_to_Oracle(txtDataVigencia.Text), DbType.DateTime)
        oParametro(50) = DBParametro_Montar("IC_ENVIA_EMAIL_CREDITO", IIf(chkEnviaEmailCredito.Checked = False, "N", "S"))
        oParametro(51) = DBParametro_Montar("IC_AORDEM_MASTER", IIf(chkCacauAordemMaster.Checked = False, "N", "S"))

        If ComboBox_LinhaSelecionada(cboModalidadeConciliacaoDevolucao) Then
            oParametro(52) = DBParametro_Montar("CD_CONC_MODAL_DEVOLUCAO", cboModalidadeConciliacaoDevolucao.SelectedValue)
        Else
            oParametro(52) = DBParametro_Montar("CD_CONC_MODAL_DEVOLUCAO", Nothing)
        End If

        oParametro(53) = DBParametro_Montar("PC_PAG_APLICA_NEG", txtAplicacaoNegociacaoMaxima.Value)
        oParametro(54) = DBParametro_Montar("PC_PAG_APLICA_CTR_FIX", txtAplicacaoContratoFixoMaximo.Value)
        oParametro(55) = DBParametro_Montar("IC_JUROS_NEG", IIf(optCobraJuros.Value = "NE", "S", "N"))
        oParametro(56) = DBParametro_Montar("IC_JUROS_CTR_FIX", IIf(optCobraJuros.Value = "CF", "S", "N"))
        oParametro(57) = DBParametro_Montar("IC_JUROS_NEG_REC", IIf(optCobraJuros.Value = "NR", "S", "N"))

        If ComboBox_LinhaSelecionada(cboTipoCtrPAFNegociaMaster) Then
            oParametro(58) = DBParametro_Montar("cd_tp_ctr_paf_neg_master", cboTipoCtrPAFNegociaMaster.SelectedValue)
        Else
            oParametro(58) = DBParametro_Montar("cd_tp_ctr_paf_neg_master", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboModalidadeConciliacaoICMS) Then
            oParametro(59) = DBParametro_Montar("cd_conciliacao_icms", cboModalidadeConciliacaoICMS.SelectedValue)
        Else
            oParametro(59) = DBParametro_Montar("cd_conciliacao_icms", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboTipoPagamentoGP) Then
            oParametro(60) = DBParametro_Montar("cd_tipo_pag_gp", cboTipoPagamentoGP.SelectedValue)
        Else
            oParametro(60) = DBParametro_Montar("cd_tipo_pag_gp", Nothing)
        End If

        'parametros CLASS
        oParametro(61) = DBParametro_Montar("cd_compra_class", NULLIf(txtCodigoCompra.Text, ""))
        oParametro(62) = DBParametro_Montar("cd_tipo_doc_class", NULLIf(txtTipoDocumento.Text, ""))
        oParametro(63) = DBParametro_Montar("cd_tipo_pedido_class", NULLIf(txtTipoPedido.Text, ""))

        oParametro(64) = DBParametro_Montar("CD_TP_MOV_ESAJ_PROV_NF_CPL_RDE", NULLIf(Pesq_TP_MOV_EST_PROV_NF.Codigo, 0))
        oParametro(65) = DBParametro_Montar("CD_TP_MOV_ESAJ_REV_EST_BLS_RDE", NULLIf(Pesq_TP_MOV_EST_REV_AFIXAR.Codigo, 0))
        oParametro(66) = DBParametro_Montar("CD_TP_MOV_ESAJ_REV_EST_FXO_RDE", NULLIf(Pesq_TP_MOV_EST_REV_DIF.Codigo, 0))
        oParametro(67) = DBParametro_Montar("CD_TP_MOV_AJST_PROV_NF_CPL_RDE", NULLIf(Pesq_TP_MOV_PROV_NF.Codigo, 0))
        oParametro(68) = DBParametro_Montar("CD_TP_MOV_AJST_REV_EST_BLS_RDE", NULLIf(Pesq_TP_MOV_REV_AFIXAR.Codigo, 0))
        oParametro(69) = DBParametro_Montar("CD_TP_MOV_AJST_REV_EST_FXO_RDE", NULLIf(Pesq_TP_MOV_REV_DIF.Codigo, 0))
        If ComboBox_LinhaSelecionada(cboMoedaCredito) Then
            SqlTextAux = "  SELECT a.ic_status "
            SqlTextAux = SqlTextAux & "  FROM sof.processo_status a "
            SqlTextAux = SqlTextAux & "  where a.cd_processo = " & enProcesso_Status.Moeda
            SqlTextAux = SqlTextAux & "  and a.cd_status = " & cboMoedaCredito.SelectedValue

            oParametro(70) = DBParametro_Montar("IC_MOEDA_CREDITO", DBQuery_ValorUnico(SqlTextAux))
        Else
            oParametro(70) = DBParametro_Montar("IC_MOEDA_CREDITO", Nothing)
        End If
        oParametro(71) = DBParametro_Montar("QT_NIVEL_APROVACAO_PAGAMENTO", txtNivelAprovacaoPagamento.Value)
        If Not DBExecutar(SqlText, oParametro) Then GoTo Erro

        SqlText = DBMontar_Update("SOF.PARAMETRO_FISCAL", GerarArray("DS_EMAIL_FISCAL", ":DS_EMAIL_FISCAL"), Nothing, False)
        If Not DBExecutar(SqlText, DBParametro_Montar("DS_EMAIL_FISCAL", txtEmailSeguraca.Text)) Then GoTo Erro

        Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub
End Class