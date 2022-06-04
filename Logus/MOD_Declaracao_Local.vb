Module MOD_Declaracao_Local
    '>> Controle de Acesso
    Public Const cnt_Sistema_ControleAcesso As Integer = 2
    Public Const cnt_Sistema_UsuarioAcerto As String = "USR_SOF"

    Public Const cnt_EmailProcesso_Padrao As String = "EUS"
    Public Const cnt_EmailExportacaoRelatorio As String = "Logus@Cargill.com"

    '>> Ref. as imagens do botões
    Public Const cnt_ImagemIcone_Novo As Integer = 0
    Public Const cnt_ImagemIcone_Gravar As Integer = 1
    Public Const cnt_ImagemIcone_Fechar As Integer = 2
    Public Const cnt_ImagemIcone_Excluir As Integer = 3
    Public Const cnt_ImagemIcone_Excell As Integer = 5
    Public Const cnt_ImagemIcone_Imprimir As Integer = 6
    Public Const cnt_ImagemIcone_Alterar As Integer = 7
    Public Const cnt_ImagemIcone_Amarracao As Integer = 8
    Public Const cnt_ImagemIcone_Pesquisar As Integer = 9
    Public Const cnt_ImagemIcone_Usuario As Integer = 11
    Public Const cnt_ImagemIcone_Parametro As Integer = 12
    Public Const cnt_ImagemIcone_Copiar As Integer = 13
    Public Const cnt_ImagemIcone_Equipamento As Integer = 14
    Public Const cnt_ImagemIcone_Retornar As Integer = 15
    Public Const cnt_ImagemIcone_LerMensagem As Integer = 16
    Public Const cnt_ImagemIcone_Atualizar As Integer = 19
    Public Const cnt_ImagemIcone_Historico As Integer = 20
    Public Const cnt_ImagemIcone_Cancelar As Integer = 22
    Public Const cnt_ImagemIcone_Acesso As Integer = 23
    Public Const cnt_ImagemIcone_LinkarUsuario As Integer = 24
    Public Const cnt_ImagemIcone_GrupoUsuario As Integer = 25
    Public Const cnt_ImagemIcone_Sobe As Integer = 26
    Public Const cnt_ImagemIcone_Desce As Integer = 27
    Public Const cnt_ImagemIcone_Aprovacao As Integer = 28
    Public Const cnt_ImagemIcone_MotivoEliminacao As Integer = 29
    Public Const cnt_ImagemIcone_ApagarParcial As Integer = 30
    Public Const cnt_ImagemIcone_Escala As Integer = 31
    Public Const cnt_ImagemIcone_Digital As Integer = 32
    Public Const cnt_ImagemIcone_FixacaoDolar As Integer = 33
    Public Const cnt_ImagemIcone_Adendo As Integer = 34
    Public Const cnt_ImagemIcone_ObsAcerto As Integer = 35
    Public Const cnt_ImagemIcone_NFReferencia As Integer = 36
    Public Const cnt_ImagemIcone_Manutencao As Integer = 37
    Public Const cnt_ImagemIcone_Executada As Integer = 38
    Public Const cnt_ImagemIcone_Selecionar As Integer = 39
    Public Const cnt_ImagemIcone_EnviarEMail As Integer = 40
    Public Const cnt_ImagemIcone_Provisao As Integer = 41
    Public Const cnt_ImagemIcone_Ajuste As Integer = 42
    Public Const cnt_ImagemIcone_Agregados As Integer = 43
    Public Const cnt_ImagemIcone_Fornecedor As Integer = 44
    Public Const cnt_ImagemIcone_Bolsa As Integer = 45
    Public Const cnt_ImagemIcone_Conciliacao As Integer = 46
    Public Const cnt_ImagemIcone_Contatos As Integer = 47
    Public Const cnt_ImagemIcone_Contrato As Integer = 48
    Public Const cnt_ImagemIcone_Frete As Integer = 49
    Public Const cnt_ImagemIcone_Garantia As Integer = 50
    Public Const cnt_ImagemIcone_Inovacao As Integer = 51
    Public Const cnt_ImagemIcone_Jornal As Integer = 52
    Public Const cnt_ImagemIcone_MovimentacaoBancaria As Integer = 53
    Public Const cnt_ImagemIcone_MovimentacaoCacau As Integer = 54
    Public Const cnt_ImagemIcone_Pagamento As Integer = 55
    Public Const cnt_ImagemIcone_RecuperacaoCredito As Integer = 56
    Public Const cnt_ImagemIcone_RD As Integer = 10
    Public Const cnt_ImagemIcone_Sacaria As Integer = 4
    Public Const cnt_ImagemIcone_SolicitacaoCredito As Integer = 18
    Public Const cnt_ImagemIcone_Check As Integer = 17
    Public Const cnt_ImagemIcone_Cheque As Integer = 57
    Public Const cnt_ImagemIcone_Item As Integer = 58
    Public Const cnt_ImagemIcone_Limpa As Integer = 59
    Public Const cnt_ImagemIcone_PDF As Integer = 60
    Public Const cnt_ImagemIcone_Word As Integer = 61
    Public Const cnt_ImagemIcone_Pasta As Integer = 62
    Public Const cnt_ImagemIcone_HTML As Integer = 63
    Public Const cnt_ImagemIcone_ExportacaoEmail As Integer = 64
    Public Const cnt_ImagemIcone_ICMS As Integer = 65
    Public Const cnt_ImagemIcone_Reprovar As Integer = 66
    Public Const cnt_ImagemIcone_Aprovar As Integer = 67

    Public Const cnt_Config_Item_PesoMedioSacoTransferencia As Integer = 23
    Public Const cnt_Config_Item_RelatorioCashTrade_DtMudancaFormaCalculo As Integer = 27

    '>> Ref. aos tipo de bens de fornecedor
    Public Const cnt_TipoBem_CasaApartamento As Integer = 1
    Public Const cnt_TipoBem_Fazenda As Integer = 2
    Public Const cnt_TipoBem_Veiculo As Integer = 3
    Public Const cnt_TipoBem_Outros As Integer = 4

    '>> Ref. aos tipos de cobrança de frete
    Public Const cnt_TipoCobrancaFrete_ValorCarga As Integer = 1
    Public Const cnt_TipoCobrancaFrete_ValorQuilo As Integer = 2
    Public Const cnt_TipoCobrancaFrete_ImpostoInclusoValorCarga As Integer = 3
    Public Const cnt_TipoCobrancaFrete_ImpostoInclusoValorTonelada As Integer = 4

    Public Const cnt_TipoContratoPAF_ContratoPAFComADTO As Integer = 1
    Public Const cnt_TipoContratoPAF_ContratoMaster As Integer = 2

    '>> Ref. aos tipos de negociação
    Public Const cnt_TIPO_NEGOCIACAO_FixoEmReal As Integer = 1
    Public Const cnt_TIPO_NEGOCIACAO_FixoEmDolar As Integer = 2
    Public Const cnt_TIPO_NEGOCIACAO_DiferencialBolsa As Integer = 3

    '>> Ref. aos tipos de movimentação
    Public Const cnt_TIPO_MOVIMENTACAO_DevolucaoCacauFornecedor As Integer = 103
    Public Const cnt_TIPO_MOVIMENTACAO_AjusteCreditoCacauFixo As Integer = 163

    '>> Ref. aos processos internos
    Public Const cnt_Processo_Blend As Integer = 1
    Public Const cnt_Processo_RequisicaoSacaria As Integer = 2
    Public Const cnt_Processo_Recepcao As Integer = 3
    Public Const cnt_Processo_Recepcao_Qualidade As Integer = 4
    Public Const cnt_Processo_Interface_RDSSummus As Integer = 5
    Public Const cnt_Processo_Armazem As Integer = 6
    Public Const cnt_Processo_ArmazemPilhaAnalise As Integer = 7
    Public Const cnt_Processo_RelatorioIndustrializacao As Integer = 8
    Public Const cnt_Processo_TipoCobrancaFrete As Integer = 11
    Public Const cnt_Processo_RelatorioAnaliseSilo As Integer = 12
    Public Const cnt_Processo_CobrancaFreteMov As Integer = 14
    Public Const cnt_Processo_IndiceValores As Integer = 15
    Public Const cnt_Processo_Confis As Integer = 16
    Public Const cnt_Processo_Contratos As Integer = 19
    Public Const cnt_Processo_DadosBolsa As Integer = 21
    Public Const cnt_Processo_ParametrizacaoModalidade As Integer = 22
    Public Const cnt_Processo_TipoAjusteRD As Integer = 23
    Public Const cnt_Processo_TipoPDD As Integer = 25
    Public Const cnt_Processo_PIS As Integer = 26
    Public Const cnt_Processo_RelatorioCashTrade As Integer = 27

    Public Const cnt_TipoAjusteRD_Movimentacao As Integer = 1
    Public Const cnt_TipoAjusteRD_Valor As Integer = 2

    Public Const cnt_Processo_CobrancaFrete_Mov_ExigeMovimentacao As Integer = 1

    '>> Ref. ao local de entrega
    Public Const cnt_LocalEntrega_Fazenda As Integer = 1
    Public Const cnt_LocalEntrega_Filial As Integer = 2
    Public Const cnt_LocalEntrega_Fabrica As Integer = 3

    Public Const cnt_LimiteCreditoTipoMoeda_Dolar As Integer = 1
    Public Const cnt_LimiteCreditoTipoMoeda_Bolsa As Integer = 2

    '>> Tipo de Contrato
    Public Const cnt_TipoContrato_PadraoPara As Integer = 1
    Public Const cnt_TipoContrato_PadraoFiliais As Integer = 9
    Public Const cnt_TipoContrato_ContratoComum As Integer = 2
    Public Const cnt_TipoContrato_CacauRondonia As Integer = 3
    Public Const cnt_TipoContrato_CacauAOrdem As Integer = 4
    Public Const cnt_TipoContrato_CtrVinculoHipoteca As Integer = 5
    Public Const cnt_TipoContrato_ComAdto As Integer = 6
    Public Const cnt_TipoContrato_100Porcento As Integer = 7
    Public Const cnt_TipoContrato_50Porcento_AdtoImediato As Integer = 8
    Public Const cnt_TipoContrato_AFixar_Filiais As Integer = 10
    Public Const cnt_TipoContrato_AFixar_Transporta As Integer = 11
    Public Const cnt_TipoContrato_AFixar_Preposto As Integer = 12
    Public Const cnt_TipoContrato_AFixar_Fax As Integer = 13
    Public Const cnt_TipoContrato_AFixar_DtLimite As Integer = 14
    Public Const cnt_TipoContrato_FixoSemADTO As Integer = 15
    Public Const cnt_TipoContrato_FixoComADTO_5050 As Integer = 16
    Public Const cnt_TipoContrato_FixoComADTOValor As Integer = 17
    Public Const cnt_TipoContrato_FixoComADTOTotal As Integer = 18

    Public Const cnt_LimiteCredito_Status_Aprovado As String = "A"
    Public Const cnt_LimiteCredito_Status_Cancelado As String = "C"
    Public Const cnt_LimiteCredito_Status_EmRevisao As String = "E"
    Public Const cnt_LimiteCredito_Status_Inativo As String = "I"
    Public Const cnt_LimiteCredito_Status_PreAprovacaoComercial As String = "P"
    Public Const cnt_LimiteCredito_Status_Reprovado As String = "R"
    Public Const cnt_LimiteCredito_Status_EsperandoAprovacao As String = "W"

    Public Const cnt_RelatorioPrevisaoBonus_Tipo_AProvisionar As String = "A"
    Public Const cnt_RelatorioPrevisaoBonus_Tipo_Provisionado As String = "P"
    Public Const cnt_RelatorioPrevisaoBonus_Tipo_Cancelado As String = "C"

    Public Const cnt_RelatorioPrevisaoBonus_Nivel_Premio As String = "P"
    Public Const cnt_RelatorioPrevisaoBonus_Nivel_Movimentacao As String = "M"
    Public Const cnt_RelatorioPrevisaoBonus_Nivel_Fornecedor As String = "F"

    Public Const cnt_RelatorioArmarracao_Cod_Amarracoes As String = "A"
    Public Const cnt_RelatorioArmarracao_Cod_PagamentoSemNF As String = "P"
    Public Const cnt_RelatorioArmarracao_Cod_NFSemPagamento As String = "M"

    Public Const cnt_RelatorioArmarracao_Desc_Amarracoes As String = "Amarrações"
    Public Const cnt_RelatorioArmarracao_Desc_PagamentoSemNF As String = "Pagamento Sem NF"
    Public Const cnt_RelatorioArmarracao_Desc_NFSemPagamento As String = "NF Sem Pagamento"

    Public Const cnt_RelatorioCacauAOrdem_Cod_PRAZOVENCIDO As String = "PRAZOVENCIDO"
    Public Const cnt_RelatorioCacauAOrdem_Cod_PRAZOAVENCER As String = "PRAZOAVENCER"
    Public Const cnt_RelatorioCacauAOrdem_Cod_SEMPRAZO As String = "SEMPRAZO"

    Public Const cnt_RelatorioCacauAOrdem_Desc_PRAZOVENCIDO As String = "Com Prazo de Fixação Vencido ate"
    Public Const cnt_RelatorioCacauAOrdem_Desc_PRAZOAVENCER As String = "Com Prazo de Fixação a vencer apos"
    Public Const cnt_RelatorioCacauAOrdem_Desc_SEMPRAZO As String = "Sem Prazo de Fixação"

    Public Const cnt_PrecoMedio_Cod_Sintetico As String = "S"
    Public Const cnt_PrecoMedio_Cod_Analitico As String = "A"
    Public Const cnt_PrecoMedio_Cod_Analitico_Mensal As String = "M"
    Public Const cnt_PrecoMedio_Cod_Resumido As String = "R"

    Public Const cnt_PrecoMedio_Desc_Sintetico As String = "Sintético"
    Public Const cnt_PrecoMedio_Desc_Analitico As String = "Analítico"
    Public Const cnt_PrecoMedio_Desc_Analitico_Mensal As String = "Analítico Mensal"
    Public Const cnt_PrecoMedio_Desc_Resumido As String = "Resumido"

    Public Const cnt_NFComplementar_Cod_Todos As String = "T"
    Public Const cnt_NFComplementar_Cod_Credito As String = "C"
    Public Const cnt_NFComplementar_Cod_Debito As String = "D"

    Public Const cnt_NFComplementar_Desc_Todos As String = "Todos"
    Public Const cnt_NFComplementar_Desc_Credito As String = "Crédito"
    Public Const cnt_NFComplementar_Desc_Debito As String = "Débito"

    'Índice de valores
    Public Const cnt_TipoDesagio_Umidade As Integer = 1000
    Public Const cnt_TipoDesagio_Sujidade As Integer = 2000

    Public Const cnt_FormaPagamentoJDE As Integer = 2

    Public Const cnt_StatusFormacaoPilha_Sendodesmanchada = 1

    'Sql
    Public Const cnt_SQL_TipoMovimentacao_Aplicacao As String = "(SELECT TM.CD_TP_MOV_FIXACAO_ENTRADA CD_TIPO_MOVIMENTACAO FROM SOF.TIPO_MOVIMENTACAO TM" & _
                                                                 " WHERE TM.CD_TP_MOV_FIXACAO_ENTRADA IS NOT NULL " & _
                                                                 "UNION " & _
                                                                 "SELECT TM.CD_TP_MOV_FIXACAO_SAIDA FROM SOF.TIPO_MOVIMENTACAO TM" & _
                                                                 " WHERE TM.CD_TP_MOV_FIXACAO_SAIDA IS NOT NULL " & _
                                                                 "UNION " & _
                                                                 "SELECT PM.CD_TP_MOV_FIXACAO_SAIDA FROM SOF.PARAMETRO PM " & _
                                                                 "UNION " & _
                                                                 "SELECT PM.CD_TP_MOV_FIXACAO_ENTRADA FROM SOF.PARAMETRO PM " & _
                                                                 "UNION " & _
                                                                 "SELECT PM.CD_TP_MOV_FIX_SAIDA_IMP FROM SOF.PARAMETRO PM " & _
                                                                 "UNION " & _
                                                                 "SELECT PM.CD_TP_MOV_FIX_ENTRADA_IMP FROM SOF.PARAMETRO PM)"


    Public Const cnt_SQL_Amarracao_Aplicacao As String = " (SELECT   cpncfm.cd_contrato_paf, cpncfm.sq_negociacao," & _
                    "         cpncfm.sq_contrato_fixo," & _
                    "         SUM (ROUND (  (  (pa.vl_aplicacao * cpncfm.vl_fixo)" & _
                    "                        / DECODE (m.vl_nf, 0, 1, m.vl_nf)" & _
                    "                       )" & _
                    "                    * tmov.tx_ctr_antigo," & _
                    "                     2" & _
                    "                    )" & _
                    "             ) vl_aplicado" & _
                    "   FROM sof.movimentacao m," & _
                    "        (SELECT   SUM (vl_aplicacao) AS vl_aplicacao, sq_movimentacao" & _
                    "             FROM sof.pag_amarracao_icms" & _
                    "         GROUP BY sq_movimentacao) pa," & _
                    "         (SELECT   cp.sq_movimentacao," & _
                    "                    1 + DECODE((SUM(CP.VL_FIXO) - SUM(DECODE(CF.IC_INCLUI_ICMS_PAG, 'S', CP.VL_FIXO, 0))), 0, 0, SUM(DECODE(CF.IC_INCLUI_ICMS_PAG, 'S', CP.VL_FIXO, 0)) / (SUM(CP.VL_FIXO) - SUM(DECODE(CF.IC_INCLUI_ICMS_PAG, 'S', CP.VL_FIXO, 0)))) TX_CTR_ANTIGO" & _
                    "            FROM sof.ctr_paf_neg_ctr_fix_mov cp, sof.contrato_fixo cf" & _
                    "           WHERE cp.sq_movimentacao IN (SELECT DISTINCT sq_movimentacao" & _
                    "                                                   FROM sof.pag_amarracao_icms)" & _
                    "             AND cp.cd_contrato_paf = cf.cd_contrato_paf" & _
                    "             AND cp.sq_negociacao = cf.sq_negociacao" & _
                    "              AND cp.sq_contrato_fixo = cf.sq_contrato_fixo" & _
                    "        GROUP BY cp.sq_movimentacao) tmov," & _
                    "        (SELECT   cp.cd_contrato_paf, cp.sq_negociacao, cp.sq_contrato_fixo," & _
                    "                  cp.sq_movimentacao, SUM (cp.vl_fixo) AS vl_fixo" & _
                    "             FROM sof.ctr_paf_neg_ctr_fix_mov cp, sof.contrato_fixo cf" & _
                    "             WHERE cp.sq_movimentacao IN (SELECT DISTINCT sq_movimentacao" & _
                    "                                                    FROM sof.pag_amarracao_icms)" & _
                    "             AND cp.cd_contrato_paf = cf.cd_contrato_paf" & _
                    "             AND cp.sq_negociacao = cf.sq_negociacao" & _
                    "              AND cp.sq_contrato_fixo = cf.sq_contrato_fixo" & _
                    "              and cf.ic_inclui_icms_pag ='N' " & _
                    "         GROUP BY cp.cd_contrato_paf," & _
                    "                  cp.sq_negociacao," & _
                    "                  cp.sq_contrato_fixo," & _
                    "                  cp.sq_movimentacao) cpncfm" & _
                    "  WHERE pa.sq_movimentacao = m.sq_movimentacao" & _
                    "    AND m.sq_movimentacao = cpncfm.sq_movimentacao" & _
                    "    AND m.sq_movimentacao = tmov.sq_movimentacao(+)" & _
                    " GROUP BY cpncfm.cd_contrato_paf, cpncfm.sq_negociacao, " & _
                    "        cpncfm.sq_contrato_fixo)  "

    Public Const cnt_NetSales_Operacao_Juridico As String = "Juridico"
    Public Const cnt_NetSales_Operacao_VencidoContrato As String = "Vencido Contrato"
    Public Const cnt_NetSales_Operacao_VencidoRenegociado As String = "Vencido Renegociado"
    Public Const cnt_NetSales_Operacao_AVencerContrato As String = "A Vencer Contrato"
    Public Const cnt_NetSales_Operacao_AVencerRenegociado As String = "A Vencer Renegociado"

    Public Const cnt_NetSales_Operacao_Juridico_Cod As Integer = 1
    Public Const cnt_NetSales_Operacao_VencidoContrato_Cod As Integer = 2
    Public Const cnt_NetSales_Operacao_VencidoRenegociado_Cod As Integer = 3
    Public Const cnt_NetSales_Operacao_AVencerContrato_Cod As Integer = 4
    Public Const cnt_NetSales_Operacao_AVencerRenegociado_Cod As Integer = 5

    Public Const cnt_NetSaldo_TipoRelatorio_Fornecedor As String = "FO"
    Public Const cnt_NetSaldo_TipoRelatorio_Titular As String = "TI"
    Public Const cnt_NetSaldo_TipoRelatorio_Filial As String = "FI"
    Public Const cnt_NetSaldo_TipoRelatorio_Sintetico As String = "SI"

    'Constantes usadas no relatório de Contrato Com Saldo
    Public Const cnt_ComboOpcao_Todos As String = "TD"
    Public Const cnt_ComboOpcao_ANegociar As String = "AN"
    Public Const cnt_ComboOpcao_TotalmenteNegociados As String = "TN"
    Public Const cnt_ComboOpcao_TotalmenteNegociados_ComPagamentoAberto As String = "TNPA"
    Public Const cnt_ComboOpcao_Vencidos As String = "VC"
    Public Const cnt_ComboOpcao_AVencer As String = "AV"
    Public Const cnt_ComboOpcao_ApenasAdiantamentoAberto As String = "AA"

    Public Const cnt_ParametroModalidade_ExportacaoArmazemFichaCirculacao As Integer = 1
    Public Const cnt_ParametroModalidade_TransferenciaSaida As Integer = 2
    Public Const cnt_ParametroModalidade_TransferenciaEntrada As Integer = 3
    Public Const cnt_ParametroModalidade_SaidaIndustrializacao As Integer = 4
    Public Const cnt_ParametroModalidade_ConsultaMovimentacaoOrigem As Integer = 5
    Public Const cnt_ParametroModalidade_ConsultaMovimentacaoEstado As Integer = 6
    Public Const cnt_ParametroModalidade_NFComplementar As Integer = 7
    Public Const cnt_ParametroModalidade_ComprasFilial As Integer = 8
    Public Const cnt_ParametroModalidade_SaldoRDFiliais As Integer = 9
    Public Const cnt_ParametroModalidade_TransferenciasFiliaisFabricaIna As Integer = 10
    Public Const cnt_ParametroModalidade_TransfArmazFechado As Integer = 11
    Public Const cnt_ParametroModalidade_BranchesRecebimento As Integer = 12
    Public Const cnt_ParametroModalidade_SaidasParaValorizacaoCacau As Integer = 13
    Public Const cnt_ParametroModalidade_AjusteAplicacaoContratoFixo As Integer = 14

    Public Const cnt_Contrato_Status_Aberto = "A"
    Public Const cnt_Contrato_Status_Excluido = "E"
    Public Const cnt_Contrato_Status_Fechado = "F"

    'Constantes de contrato
    Public Const cnt_Contrato_Master_TempoFixacao_Mes As Integer = 36
    Public Const cnt_Contrato_Adto_TempoFixacao_Mes As Integer = 2
    Public FilialLogada_Fechada As Boolean
    Public FilialLogada As Integer
    Public FilialMae As Integer
    Public Safra As Integer

    Public Enum enProcesso_Status
        ReqSaca_Cancelado = 1
        ReqSaca_AguardandoEntrega = 2
        ReqSaca_Entregue = 3
        Analise = 3
        Moeda = 9
        TipoPagamentoFrete = 11
    End Enum

    Public Enum Tipo_Historico_Fornecedor
        HFConsulta = 4
        HFConsultaFazenda = 5
        HFConsultaCategoria = 6
        HFConsultaOBS = 7
        HFConsultaAgregados = 8
        HFInclusaoFazenda = 9
        HFInclusaoCategoria = 10
        HFAlteracaoFazenda = 11
        HFExclusaoFazenda = 12
        HFExclusaoCategoria = 13
    End Enum

    Public Enum SEC_Permissao
        SEC_P_Acesso_RenegociarRecuperacaoCredito = 1
        SEC_P_Acesso_QuebrarRecuperacaoCredito = 2
        SEC_P_Acesso_PagarRecuperacaoCredito = 3
        SEC_P_Acesso_ImprimirVoucherPagamento = 4
        SEC_P_Acesso_ImprimirCheque = 5
        SEC_P_Acesso_CancelarGarantia = 6
        SEC_P_Acesso_ApagarPagamentoParcialmente = 7
        SEC_P_Acesso_AlterarExcluirJornalDataAnteriorAtual = 8
        SEC_P_Acesso_AcessoBancosTodasFiliais = 9
        SEC_P_Acesso_PodeAlterarTodoCampoCadFornecedor = 10
        SEC_P_Acesso_IncluirSolicitacaoCreditoFornecedorOutraFilial = 11
        SEC_P_Acesso_ExcluirFreteLancadoDataAnteriorAtual = 12
        SEC_P_Acesso_ExcluirMovimentacaoBancariaDataAnterior = 13
        SEC_P_Acesso_IncluirInovacoesDataAnteriorAtual = 14
        SEC_P_Acesso_AlterarExcluirContatosDataAnteriorAtual = 15
        SEC_P_Acesso_TodosAlmoxarifados = 16
        SEC_P_Acesso_CancelarContratoPAF = 17
        SEC_P_Acesso_LancarJurosContratoPAF = 18
        SEC_P_Acesso_Abrir_FecharContratoPAF = 19
        SEC_P_Acesso_CancelarNegociacaoContrato = 20
        SEC_P_Acesso_EstornoNegociacaoContrato = 21
        SEC_P_Acesso_LancarJurosNegociacaoContrato = 22
        SEC_P_Acesso_LiberacaoSaldoPreNegociacao = 23
        SEC_P_Acesso_Abrir_FecharNegociacao = 24
        SEC_P_Acesso_IncluirAdendoContratoFixo = 25
        SEC_P_Acesso_FixarDolarContratoFixo = 26
        SEC_P_Acesso_CancelarContratoFixo = 27
        SEC_P_Acesso_EliminarAdendoContratoFixo = 28
        SEC_P_Acesso_AlterarInovacaoDataAnteriorAtual = 29
        SEC_P_Acesso_AjustarSaldoEstoqueSacariaMovimentacoes = 30
        SEC_P_Acesso_VisualizarRequisicaoSacariaOutraFilial = 31
        SEC_P_Acesso_RecepcionarDevolucaoSacariaFornecedor = 32
        SEC_P_Acesso_EntregarSacariaRequisitadaFornecedor = 33
        SEC_P_Acesso_CancelarRequisicaoSacariaStatusEntregue = 34
        SEC_P_Acesso_AcessoMovimentarCacauEntrePilha = 35
        SEC_P_Acesso_LancarNotaFiscalReferenciaMovimentacao = 36
        SEC_P_Acesso_QuebrarAplicacaoAdiantamentDataAnteriorContratoPAF = 37
        SEC_P_Acesso_ExcluirQuebrarAplicacaoNegociacaoFechada = 38
        SEC_P_Acesso_AcordarDesagioAplicacaoRecebimentos = 39
        SEC_P_Acesso_ExcluirQuebrarAplicacaoContratoFixoFechado = 40
        SEC_P_Acesso_VisualizarBolsaInvisiveisConsulta = 41
        SEC_P_Acesso_ExcluirTodaMovimentacaoPilhaManualmente = 42
        SEC_P_Acesso_AlterarDisponibilizacaoPagamentoAmarracao = 43
        SEC_P_Acesso_AlterarIndicadorInterfaceEnviadaJDE_OW = 44
        SEC_P_Acesso_AlterarFornecCtrRecuperacaoCredito = 45
        SEC_P_Acesso_IncluirRecuperacaoCreditoDataRetroativa = 46
        SEC_P_Acesso_CancelarRecuperacaoCredito = 48
        SEC_P_Acesso_RecepcionarTransferenciaSacariaAberto = 49
        SEC_P_Acesso_Abrir_FecharContratoFixo = 50
        SEC_P_Acesso_IncluirEliminarFornecedorListaNegra = 51
        SEC_P_Acesso_ListarMovimentacoesTodasFiliais = 52
        SEC_P_Acesso_ImprimirRequisicaoSacariaEntregue = 53
        SEC_P_Acesso_VisualizarCadastroFornecedorOutraFilial = 54
        SEC_P_Acesso_RealizarCessaoDireitoValor_NF = 55
        SEC_P_Acesso_AlterarProcedenciaPilha = 57
        SEC_P_Acesso_EmitirRelatorioContratoComSaldoINSS = 58
        SEC_P_Acesso_RealizarCessaoDireitoQuantidadeValor_NF = 59
        SEC_P_Acesso_RemoverMovimentacaoInterfaceLivroFiscal = 60
        SEC_P_Acesso_CadastroRenegociacao_Consultar = 61
        SEC_P_Acesso_CadastroRenegociacao_Solicitar = 62
        SEC_P_Acesso_Usuario_Desbloquear = 63
        SEC_P_Acesso_AprovarAjusteRDE = 64
        SEC_P_Acesso_AdministradorMailing = 65
        SEC_P_Acesso_ApricaCacauSemProporcionalidade = 66
        SEC_P_Acesso_LimitarInclusaoCtrSomentoImportacao = 67

        SEC_P_Acesso_AdministradorFormulacaoPDC = -1
    End Enum

    Public Enum SEC_Configuracao
        SEC_Config_LancaAnalisesLaboratorio = 1
        SEC_Config_CriarTransferenciaAtenderBlend = 2
        SEC_Config_AlterarDadosUsuarioMesmaTurma = -1
        SEC_Config_AlterarDadosUsuarioMesmaArea = -1
    End Enum

    Public Enum enCalcDiferencial_Opcao
        NAO_INFORMADO = 0
        SEM_IMPORT = 1
        NEG_SEM_IMPORT = 2
        SOMENTE_IMPORT = 3
        NEG_SOMENTE_IMPORT = 4
        TODOS = 5
    End Enum

    Public Enum enDocumento_Tipo
        eRelatorio = 1
    End Enum

    Public Enum enDocumento_Relatorio
        eSemImpressao = 1
        eContratoPAF = 2
        eContratoPAF_PAFComADTO = 3
        eContratoPAF_Master = 4
        eDeclaracaoFixacao = 5
        eDeclaracaoFixacao_DiferencialBolsa = 6
        eDeclaracaoFixacao_DolarFlutuante = 7
        eNegociacao_ContratoPAF_Master = 8
        eContratoPAF_PAFComADTO_2010 = 9
        eNegociacao = 10
        eContratoPAF_2011 = 11
        eCtrConfirmacaoCompraCacauAOrdem = 12
        eContratoPAF_PrecoFixo = 13
        eNegociacao_Aditamento = 14
    End Enum

    Public Enum ComboBox_FilialEntrega_Info
        NO_FILIAL = 0
        CD_FILIAL = 1
        VL_FRETE_FILIAL_FAZENDA = 2
        VL_FRETE_FILIAL_FABRICA = 3
        VL_FRETE_FABRICA = 4
    End Enum

    Public Enum ComboBox_TipoNegociacao_Info
        CD_TIPO_NEGOCIACAO = 0
        NO_TIPO_NEGOCIACAO = 1
        IC_BOLSA = 2
        IC_DOLAR = 3
        IC_TIPO_PRECO_FIXO = 4
        IC_BOLSA_OPERACAO = 5
        CD_TIPO_PRECO = 6
        QT_DIA_VENC_PADRAO = 7
        CD_TIPO = 8
    End Enum

    Public Enum ComboBox_TipoUnidade_Info
        CD_TIPO_UNIDADE = 0
        NO_TIPO_UNIDADE = 1
        QT_FATOR = 2
    End Enum

    Public Enum ComboBox_ContratoPaf_Info
        CD_TIPO_CONTRATO_PAF = 0
        NO_TIPO_CONTRATO_PAF = 1
        IC_ADIANTAMENTO = 2
    End Enum

    Public Enum enTipoCacau
        CACAU_COMUM = 1
        CACAU_ORGANICO = 2
        NIBS = 3
        CACAU_CRM = 4
        CACAU_FERTIL = 5
    End Enum
End Module