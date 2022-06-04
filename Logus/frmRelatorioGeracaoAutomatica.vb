Imports VB = Microsoft.VisualBasic.Strings
Imports Infragistics.Win.UltraWinDataSource
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRelatorioGeracaoAutomatica
    Const cnt_grdGeral_Codigo As Integer = 0
    Const cnt_grdGeral_Gerar As Integer = 1
    Const cnt_grdGeral_Nome As Integer = 2
    Const cnt_grdGeral_Tipo As Integer = 3
    Const cnt_grdGeral_PDF As Integer = 4
    Const cnt_grdGeral_Excel As Integer = 5
    Const cnt_grdGeral_Status As Integer = 6
    Const cnt_grdGeral_PorFilial As Integer = 7

    Const cnt_TipoRelatorio_Adt_Exposure_Adto_C_CtrBase_Analitico As String = "Adt_Exposure_Adto_C_CtrBase_Analitico"
    Const cnt_TipoRelatorio_Adt_Exposure_Adto_S_CtrBase_Analitico As String = "Adt_Exposure_Adto_S_CtrBase_Analitico"
    Const cnt_TipoRelatorio_Adt_Exposure_Sintetico As String = "Adt_Exposure_Sintetico"
    Const cnt_TipoRelatorio_Ctr_Com_Saldo_Com_Incidencia_De_Imposto_Projeto As String = "Ctr_Com_Saldo_(Com_Incidencia_De_Imposto_-_Projeto)"
    Const cnt_TipoRelatorio_Ctr_Com_Saldo_Sem_Incidencia_De_Imposto_Projeto As String = "Ctr_Com_Saldo_(Sem_Incidencia_De_Imposto_-_Projeto)"
    Const cnt_TipoRelatorio_Ctr_Paf_Aberto_Analitico As String = "Ctr_Paf_Aberto_Analitico"
    Const cnt_TipoRelatorio_Ctr_Neg_Dif_Aberto As String = "Ctr_Neg_Dif_Aberto"
    Const cnt_TipoRelatorio_Ctr_Fixo_Aberto As String = "Ctr_Fixo_Aberto"
    Const cnt_TipoRelatorio_Net_Saldos_Titular As String = "Net_Saldos_Titular"
    Const cnt_TipoRelatorio_Net_Saldos_Filial As String = "Net_Saldos_Filial"
    Const cnt_TipoRelatorio_Net_Saldos_Sintetico As String = "Net_Saldos_Sinteitco"
    Const cnt_TipoRelatorio_Fluxo_Caixa As String = "Fluxo_Caixa"
    Const cnt_TipoRelatorio_Composicao_Estoque_Cacau_E_Saldo_Financeiro As String = "Composicao_Estoque_Cacau_E_Saldo_Financeiro"
    Const cnt_TipoRelatorio_Negociacao_Em_Aberto_Com_Sua_Fixacao_Diferencial_De_Bolsa_Analitico As String = "Negociacao_Em_Aberto_Com_Sua_Fixacao_(Diferencial_De_Bolsa)_Analitico"
    Const cnt_TipoRelatorio_Negociacao_Em_Aberto_Com_Sua_Fixacao_Diferencial_De_Bolsa_Sintetico As String = "Negociacao_Em_Aberto_Com_Sua_Fixacao_(Diferencial_De_Bolsa)_Sintetico"
    Const cnt_TipoRelatorio_Confissao_Divida_Analitico As String = "Confissao_Divida_Analitico"
    Const cnt_TipoRelatorio_Confissao_Divida_Sintetico As String = "Confissao_Divida_Sintetico"
    Const cnt_TipoRelatorio_PrevisaoBonusQualidade As String = "Previsao_Bonus_Qualidade"
    Const cnt_TipoRelatorio_ResumoPagto_Em_Aberto_No_Ctr_Paf_Analitico As String = "ResumoPagto_Em_Aberto_No_Ctr_Paf_Analitico"
    Const cnt_TipoRelatorio_ResumoPagto_Em_Aberto_No_Ctr_Paf_Sintetico As String = "ResumoPagto_Em_Aberto_No_Ctr_Paf_Sintetico"
    Const cnt_TipoRelatorio_Resumopagto_Em_Aberto_Negociacoes_Analitico As String = "Resumopagto_Em_Aberto_Negociacoes_Analitico"
    Const cnt_TipoRelatorio_Resumopagto_Em_Aberto_Negociacoes_Sintetico As String = "Resumopagto_Em_Aberto_Negociacoes_Sintetico"
    Const cnt_TipoRelatorio_Pagto_Sem_Ctr_Paf As String = "Pagto_Sem_Ctr_Paf"
    Const cnt_TipoRelatorio_Amarracao_ICMS As String = "Amarracao_ICMS"
    Const cnt_TipoRelatorio_Posicao_Fornecedor_Gerkens As String = "Posicao_Fornecedor_Gerkens"
    Const cnt_TipoRelatorio_Cacau_A_Ordem_Filial_Analitico As String = "Cacau_A_Ordem_Filial_Analitico"
    Const cnt_TipoRelatorio_Cacau_A_Ordem_Filial_Sintetico As String = "Cacau_A_Ordem_Filial_Sintetico"
    Const cnt_TipoRelatorio_Cacau_A_Ordem_Geral_Analitico As String = "Cacau_A_Ordem_Geral_Analitico"
    Const cnt_TipoRelatorio_Cacau_A_Ordem_Geral_Sintetico As String = "Cacau_A_Ordem_Geral_Sintetico"
    Const cnt_TipoRelatorio_Cacau_A_Ordem_Geral_ValorAberto_Analitico As String = "Cacau_A_Ordem_Geral_ValorAberto_Analitico"
    Const cnt_TipoRelatorio_Cacau_A_Ordem_Geral_ValorAberto_Sintetico As String = "Cacau_A_Ordem_Geral_ValorAberto_Sintetico"
    Const cnt_TipoRelatorio_Cacau_A_Ordem_Sem_Ctr_Paf_Analitico As String = "Cacau_A_Ordem_Sem_Ctr_Paf_Analitico"
    Const cnt_TipoRelatorio_Cacau_A_Ordem_Sem_Ctr_Paf_Sintetico As String = "Cacau_A_Ordem_Sem_Ctr_Paf_Sintetico"
    Const cnt_TipoRelatorio_Movimentacao_Aberto_Negociacoes As String = "Movimentacao_Aberto_Negociacoes"
    Const cnt_TipoRelatorio_Estoque_Cacau_KG As String = "Estoque_Cacau_KG"
    Const cnt_TipoRelatorio_Estoque_Cacau_SC As String = "Estoque_Cacau_SC"
    Const cnt_TipoRelatorio_Estoque_Armazem As String = "Estoque_Armazem"
    Const cnt_TipoRelatorio_Resumo_Estoques As String = "Resumo_Estoques"
    Const cnt_TipoRelatorio_Preco_Medio_Contabil_Geral_Analitico As String = "Preco_Medio_Contabil_Geral_Analitico"
    Const cnt_TipoRelatorio_Preco_Medio_Contabil_Geral_Sintetico As String = "Preco_Medio_Contabil_Geral_Sintetico"
    Const cnt_TipoRelatorio_Preco_Medio_Contabil_Filial_Analitico As String = "Preco_Medio_Contabil_Filial_Analitico"
    Const cnt_TipoRelatorio_ComposicaoSaldoContaFornecedores As String = "ComposicaoSaldoContaFornecedores"
    Const cnt_TipoRelatorio_Valorizacao_Industrializacao As String = "Valorizacao_Industrializacao"
    Const cnt_TipoRelatorio_Revalorizacao_Cacau_Ordem As String = "Revalorizacao_Cacau_Ordem"
    Const cnt_TipoRelatorio_Revalorizacao_Cacau_Ordem_Filial As String = "Revalorizacao_Cacau_Ordem_Filial"
    Const cnt_TipoRelatorio_Revalorizacao_Cacau_Dif_Bolsa As String = "Revalorizacao_Cacau_Dif_Bolsa"
    Const cnt_TipoRelatorio_Revalorizacao_Cacau_Dif_Bolsa_Filial As String = "Revalorizacao_Cacau_Dif_Bolsa_Filial"
    Const cnt_TipoRelatorio_Provisao_NF_Complementar As String = "Provisao_NF_Complementar"
    Const cnt_TipoRelatorio_Provisao_NF_Complementar_Filial As String = "Provisao_NF_Complementar_Filial"
    Const cnt_TipoRelatorio_Planilha_Ctrl_Zeramento_Pilha_Sintetico As String = "Planilha_Ctrl_Zeramento_Pilha_Sintetico"
    Const cnt_TipoRelatorio_Suporte_Recon_Contabil_Sintetico As String = "Suporte_Recon_Contabil_Sintetico"

    Const cnt_Opcao_Sim As Integer = 10
    Const cnt_Opcao_Nao As Integer = 20

    Dim oDS As New UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Dim oInicioProcessamento As Date = Now
        Dim oFimProcessamento As Date
        Dim sMensagem As String

        cmdFechar.Enabled = False
        Imprmir()
        cmdFechar.Enabled = True

        oFimProcessamento = Now

        sMensagem = "Exportação Concluída." & _
                    "Início geração: " & oInicioProcessamento.ToString & "." & _
                    "Fim geração: " & oFimProcessamento.ToString & "." & _
                    "Tempo geração: " & Mid((oFimProcessamento - oInicioProcessamento).ToString, 1, 8) & " minutos."

        lblStatus.Text = sMensagem
    End Sub

    Private Sub Imprmir()
        Dim oSistema As System.IO.Directory
        Dim oRelatorio As New CrystalReportDocument
        Dim DataInicioMes As Date
        Dim Data_Sistema As Date
        Dim DataInicial_Safra As Date

        Dim sFiltro As String = ""

        Dim sDiretorioDestino As String
        Dim sArquivoDestino As String

        Dim iCont_GridGeral As Integer
        Dim iCont_Filial As Integer
        Dim bGerouRelatorio As Boolean
        Dim Status As String = ""
        Dim iAux As Integer

        Dim sFiliais As String
        Dim aFiliais As Object
        Dim CD_Filial As String = ""
        Dim NO_Filial As String = ""

        Data_Sistema = DataSistema()
        sFiliais = ListarIDFiliaisLiberadaUsuario()

        AVI_Carregar(Me)

        '>> Validação do diretorio de destino - Início
        sDiretorioDestino = Trim(txtDiretorioExportacao.Text)
        If VB.Right(sDiretorioDestino, 1) <> "\" Then sDiretorioDestino = sDiretorioDestino & "\"
        sDiretorioDestino = sDiretorioDestino & Data_Sistema.Year & "-" & Format(Data_Sistema.Month, "00") & "-" & Format(Data_Sistema.Day, "00")

        If Not oSistema.Exists(sDiretorioDestino) Then
            oSistema.CreateDirectory(sDiretorioDestino)
        End If

        DataInicioMes = Data_1DiaMes(Data_Sistema)
        DataInicial_Safra = Data_Safra_Inicio(DataSistema)

        sDiretorioDestino = sDiretorioDestino & "\"
        '>> Validação do diretorio de destino - Fim

        For iCont_GridGeral = 0 To grdGeral.Rows.Count - 1
            NO_Filial = ""
            CD_Filial = ""
            Status = ""

            'If objGrid_CheckBox_Selecionado(grdGeral, cnt_grdGeral_Gerar, iCont_GridGeral) Then
            If 1 = 1 Then
                If NVL(grdGeral.Rows(iCont_GridGeral).Cells(cnt_grdGeral_PorFilial).Value, "N") = "S" Then
                    aFiliais = Lista_Para_Array(sFiliais)
                Else
                    aFiliais = Lista_Para_Array("0")
                End If

                For iCont_Filial = 0 To UBound(aFiliais)
                    objCRView2_Finalizar(oRelatorio)
                    oRelatorio = New CrystalReportDocument
                    bGerouRelatorio = False

                    With grdGeral.Rows(iCont_GridGeral).Cells(cnt_grdGeral_Codigo)
                        Try
                            '>> Geração de relatório
                            If aFiliais(iCont_Filial) = "0" Then
                                CD_Filial = ""
                                NO_Filial = ""
                            Else
                                CD_Filial = aFiliais(iCont_Filial)
                                NO_Filial = DBQuery_ValorUnico("SELECT TRIM(NO_FILIAL) FROM SOF.FILIAL WHERE CD_FILIAL = " & CD_Filial)
                            End If

                            Select Case .Value
                                Case cnt_TipoRelatorio_Adt_Exposure_Adto_C_CtrBase_Analitico, _
                                     cnt_TipoRelatorio_Adt_Exposure_Adto_S_CtrBase_Analitico, _
                                     cnt_TipoRelatorio_Adt_Exposure_Sintetico
                                    oRelatorio = Gera_Relatorio_AdiantamentoExposure(IIf(.Value = cnt_TipoRelatorio_Adt_Exposure_Sintetico, PosForn_FiltroExposure.feSintetico, _
                                                                                         IIf(.Value = cnt_TipoRelatorio_Adt_Exposure_Adto_C_CtrBase_Analitico, _
                                                                                                      PosForn_FiltroExposure.feSoAdiantamentosContratosBase, _
                                                                                                      PosForn_FiltroExposure.feSoAdiantamentoSemContratosBase)), _
                                                                                     txtBolsa.Value, txtDolar.Value, txtValorArroba.Value)
                                Case cnt_TipoRelatorio_Ctr_Com_Saldo_Com_Incidencia_De_Imposto_Projeto, _
                                     cnt_TipoRelatorio_Ctr_Com_Saldo_Sem_Incidencia_De_Imposto_Projeto
                                    oRelatorio = Gera_Relatorio_ContratoComSaldo(.Value = cnt_TipoRelatorio_Ctr_Com_Saldo_Com_Incidencia_De_Imposto_Projeto, _
                                                                                 txtDolar.Value, sFiliais, enTipoCacau.CACAU_FERTIL, 0)
                                Case cnt_TipoRelatorio_Ctr_Paf_Aberto_Analitico
                                    oRelatorio = Gera_Relatorio_ContratoEmAberto_PAF(sFiliais, cnt_TipoContratoPAF_ContratoPAFComADTO, 0, cnt_ComboOpcao_ApenasAdiantamentoAberto)
                                Case cnt_TipoRelatorio_Ctr_Neg_Dif_Aberto
                                    oRelatorio = Gera_Relatorio_ContratoEmAberto_Negociacao("", "", sFiliais, cnt_TIPO_NEGOCIACAO_DiferencialBolsa, 0)
                                Case cnt_TipoRelatorio_Ctr_Fixo_Aberto
                                    oRelatorio = Gera_Relatorio_ContratoEmAberto_ContratoFixo("", "", sFiliais, 0)
                                Case cnt_TipoRelatorio_Net_Saldos_Sintetico, _
                                     cnt_TipoRelatorio_Net_Saldos_Titular, _
                                     cnt_TipoRelatorio_Net_Saldos_Filial
                                    oRelatorio = Gera_Relatorio_NetSaldo(txtBolsa.Value, txtDolar.Value, txtValorArroba.Value, _
                                                                         "", sFiliais, "", True, IIf(.Value = cnt_TipoRelatorio_Net_Saldos_Filial, cnt_NetSaldo_TipoRelatorio_Filial, _
                                                                                                     IIf(.Value = cnt_TipoRelatorio_Net_Saldos_Sintetico, cnt_NetSaldo_TipoRelatorio_Sintetico, _
                                                                                                                                                          cnt_NetSaldo_TipoRelatorio_Titular)), _
                                                                         True)
                                Case cnt_TipoRelatorio_Fluxo_Caixa
                                    oRelatorio = Gera_Relatorio_FluxoCaixa(DataInicioMes, Data_Sistema, txtDolar.Value, txtBolsa.Value, txtValorArroba.Value, sFiliais, True)
                                Case cnt_TipoRelatorio_Composicao_Estoque_Cacau_E_Saldo_Financeiro
                                    oRelatorio = Gera_Relatorio_PosEstoqueCacau_SaldoFinanceiro(DataSistema, txtValorDividasIncobraveis.Value)
                                Case cnt_TipoRelatorio_Negociacao_Em_Aberto_Com_Sua_Fixacao_Diferencial_De_Bolsa_Analitico, _
                                     cnt_TipoRelatorio_Negociacao_Em_Aberto_Com_Sua_Fixacao_Diferencial_De_Bolsa_Sintetico
                                    oRelatorio = Gera_Relatorio_NegociacaoAbertaComFixacoes("", "", sFiliais, cnt_TIPO_NEGOCIACAO_DiferencialBolsa, True, _
                                                                                            (.Value = cnt_TipoRelatorio_Negociacao_Em_Aberto_Com_Sua_Fixacao_Diferencial_De_Bolsa_Sintetico), _
                                                                                             False, True, True)
                                Case cnt_TipoRelatorio_Confissao_Divida_Analitico, _
                                     cnt_TipoRelatorio_Confissao_Divida_Sintetico
                                    oRelatorio = Gera_Relatorio_RecuperacaoCredito((.Value = cnt_TipoRelatorio_Confissao_Divida_Sintetico), sFiliais, "", False)
                                Case cnt_TipoRelatorio_PrevisaoBonusQualidade
                                    oRelatorio = Gera_Relatorio_PrevisaoBonus(txtDolar.Value, DataInicial_Safra, DataSistema, 0, sFiliais, _
                                                                              cnt_RelatorioPrevisaoBonus_Tipo_AProvisionar, cnt_RelatorioPrevisaoBonus_Nivel_Fornecedor)
                                Case cnt_TipoRelatorio_ResumoPagto_Em_Aberto_No_Ctr_Paf_Analitico, _
                                     cnt_TipoRelatorio_ResumoPagto_Em_Aberto_No_Ctr_Paf_Sintetico
                                    oRelatorio = Gera_Relatorio_PagamentoEmAberto(sFiliais, 0, True, False, True, False, _
                                                                                  (.Value = cnt_TipoRelatorio_ResumoPagto_Em_Aberto_No_Ctr_Paf_Sintetico))
                                Case cnt_TipoRelatorio_Resumopagto_Em_Aberto_Negociacoes_Analitico, _
                                     cnt_TipoRelatorio_Resumopagto_Em_Aberto_Negociacoes_Sintetico
                                    oRelatorio = Gera_Relatorio_PagamentoEmAberto(sFiliais, 0, False, True, True, False, _
                                                                                  (.Value = cnt_TipoRelatorio_Resumopagto_Em_Aberto_Negociacoes_Sintetico))
                                Case cnt_TipoRelatorio_Pagto_Sem_Ctr_Paf
                                    oRelatorio = Gera_Relatorio_PagamentoEmAberto(sFiliais, 0, False, False, False, True, True, iAux)
                                    If iAux > 0 Then grdGeral.Rows(iCont_GridGeral).Cells(cnt_grdGeral_Nome).Appearance.BackColor = Color.Red
                                Case cnt_TipoRelatorio_Amarracao_ICMS
                                    oRelatorio = Gera_Relatorio_AmarracaoICMS("01/01/2006", DataSistema, 0, sFiliais, _
                                                                              QuotedStr(cnt_RelatorioArmarracao_Cod_Amarracoes), _
                                                                              cnt_RelatorioArmarracao_Desc_Amarracoes, _
                                                                              True, False)
                                Case cnt_TipoRelatorio_Posicao_Fornecedor_Gerkens
                                    oRelatorio = Gera_Relatorio_PosicaoFornecedor(txtBolsa.Value, txtDolar.Value, txtValorArroba.Value, _
                                                                                  False, False, "", 2086, False, False)
                                Case cnt_TipoRelatorio_Cacau_A_Ordem_Filial_Analitico, _
                                     cnt_TipoRelatorio_Cacau_A_Ordem_Filial_Sintetico
                                    oRelatorio = Gera_Relatorio_CacauAOrdem("", DataSistema, False, False, CD_Filial, False, (.Value = cnt_TipoRelatorio_Cacau_A_Ordem_Filial_Sintetico))
                                Case cnt_TipoRelatorio_Cacau_A_Ordem_Geral_Analitico, _
                                     cnt_TipoRelatorio_Cacau_A_Ordem_Geral_Sintetico
                                    oRelatorio = Gera_Relatorio_CacauAOrdem("", DataSistema, False, False, sFiliais, False, (.Value = cnt_TipoRelatorio_Cacau_A_Ordem_Geral_Sintetico))
                                Case cnt_TipoRelatorio_Cacau_A_Ordem_Geral_ValorAberto_Analitico, _
                                     cnt_TipoRelatorio_Cacau_A_Ordem_Geral_ValorAberto_Sintetico
                                    oRelatorio = Gera_Relatorio_CacauAOrdem("", DataSistema, True, False, sFiliais, False, (.Value = cnt_TipoRelatorio_Cacau_A_Ordem_Geral_ValorAberto_Sintetico))
                                Case cnt_TipoRelatorio_Cacau_A_Ordem_Sem_Ctr_Paf_Analitico, _
                                     cnt_TipoRelatorio_Cacau_A_Ordem_Sem_Ctr_Paf_Sintetico
                                    oRelatorio = Gera_Relatorio_CacauAOrdem("", DataSistema, False, False, sFiliais, True, _
                                                                            (.Value = cnt_TipoRelatorio_Cacau_A_Ordem_Sem_Ctr_Paf_Analitico), iAux)
                                    If iAux > 0 Then grdGeral.Rows(iCont_GridGeral).Cells(cnt_grdGeral_Nome).Appearance.BackColor = Color.Red
                                Case cnt_TipoRelatorio_Movimentacao_Aberto_Negociacoes
                                    oRelatorio = Gera_Relatorio_MovimentacaoAbertoNegociacao(sFiliais, cnt_TIPO_NEGOCIACAO_DiferencialBolsa, "", "")
                                Case cnt_TipoRelatorio_Estoque_Cacau_KG, _
                                     cnt_TipoRelatorio_Estoque_Cacau_SC
                                    oRelatorio = Gera_Relatorio_EstoqueCacau(sFiliais, 0, (.Value = cnt_TipoRelatorio_Estoque_Cacau_SC), False)
                                Case cnt_TipoRelatorio_Estoque_Armazem
                                    oRelatorio = Gera_Relatorio_EstoqueArmazem(sFiliais, "", -1, -1, "", "", -1)
                                Case cnt_TipoRelatorio_Resumo_Estoques
                                    oRelatorio = Gera_Relatorio_ResumoEstoque(sFiliais, "", -1, True, True, True, True)
                                Case cnt_TipoRelatorio_Preco_Medio_Contabil_Geral_Analitico, _
                                     cnt_TipoRelatorio_Preco_Medio_Contabil_Geral_Sintetico
                                    oRelatorio = Gera_Relatorio_PrecoMedioNRComplementa(frmREL_PrecoMedioNFComplementa.RGFP_TipoRelatorio.PrecoMedio, _
                                                                                        txtDolar.Value, sFiliais, _
                                                                                        IIf(.Value = cnt_TipoRelatorio_Preco_Medio_Contabil_Geral_Analitico, _
                                                                                            cnt_PrecoMedio_Cod_Analitico, _
                                                                                            cnt_PrecoMedio_Cod_Sintetico))
                                Case cnt_TipoRelatorio_Preco_Medio_Contabil_Filial_Analitico
                                    oRelatorio = Gera_Relatorio_PrecoMedioNRComplementa(frmREL_PrecoMedioNFComplementa.RGFP_TipoRelatorio.PrecoMedio, _
                                                                                        txtDolar.Value, CD_Filial, cnt_PrecoMedio_Cod_Analitico)
                                Case cnt_TipoRelatorio_ComposicaoSaldoContaFornecedores
                                    oRelatorio = Gera_Relatorio_SaldoFornecedor(DataSistema, txtDolar.Value, txtBolsa.Value, txtValorDif.Value)
                                Case cnt_TipoRelatorio_Valorizacao_Industrializacao
                                    oRelatorio = Gera_Relatorio_IndustrializacaoValorializacao(DataInicioMes, DataSistema)
                                Case cnt_TipoRelatorio_Revalorizacao_Cacau_Ordem
                                    oRelatorio = Gera_Relatorio_Cacau_Aordem_Valorizacao(sFiliais, txtBolsa.Value, txtValorDif.Value, txtDolar.Value, False)
                                Case cnt_TipoRelatorio_Revalorizacao_Cacau_Ordem_Filial
                                    oRelatorio = Gera_Relatorio_Cacau_Aordem_Valorizacao(CD_Filial, txtBolsa.Value, txtValorDif.Value, txtDolar.Value, False)
                                Case cnt_TipoRelatorio_Revalorizacao_Cacau_Dif_Bolsa
                                    oRelatorio = Gera_Relatorio_Cacau_Aordem_Valorizacao(sFiliais, txtBolsa.Value, txtValorDif.Value, txtDolar.Value, True)
                                Case cnt_TipoRelatorio_Revalorizacao_Cacau_Dif_Bolsa_Filial
                                    oRelatorio = Gera_Relatorio_Cacau_Aordem_Valorizacao(CD_Filial, txtBolsa.Value, txtValorDif.Value, txtDolar.Value, True)
                                Case cnt_TipoRelatorio_Provisao_NF_Complementar
                                    oRelatorio = Gera_Relatorio_ProvisaoNFComplementar(0, sFiliais)
                                Case cnt_TipoRelatorio_Provisao_NF_Complementar_Filial
                                    oRelatorio = Gera_Relatorio_ProvisaoNFComplementar(0, CD_Filial)
                                Case Else
                                    Status = "RELATÓRIO DESCONHECIDO"
                            End Select

                            If Status <> "RELATÓRIO DESCONHECIDO" Then
                                Try
                                    oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape() & " - {Geração Auto.}")
                                Catch ex As Exception
                                End Try

                                bGerouRelatorio = True
                                Str_Adicionar(Status, " Relatório gerado" & IIf(Trim(NO_Filial) = "", "", " (" & NO_Filial & ")") & ".", "")
                            End If
                        Catch ex As Exception
                            Str_Adicionar(Status, " [ERROR GERAR" & IIf(Trim(NO_Filial) = "", "", " (" & NO_Filial & ")") & "] - " & ex.Message & ".", "")
                        End Try
                    End With

                    '>> Atualização do rodapé
                    With grdGeral.Rows(iCont_GridGeral)
                        If bGerouRelatorio Then
                            '>> Validação do arquivo de destino
                            sArquivoDestino = sDiretorioDestino & Format(iCont_GridGeral + 1, "00") & " - " & .Cells(cnt_grdGeral_Codigo).Value

                            If Trim(CD_Filial) <> "" Then
                                sArquivoDestino = sArquivoDestino & " (" & NO_Filial & ")"
                            End If

                            '>> Exportação PDF
                            If .Cells(cnt_grdGeral_PDF).Tag = cnt_Opcao_Sim Then
                                If Dir(sArquivoDestino & ".pdf") <> "" Then Kill(sArquivoDestino & ".pdf")

                                Try
                                    oRelatorio.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sArquivoDestino & ".pdf")
                                    .Cells(cnt_grdGeral_PDF).Value = "Sim"
                                    Str_Adicionar(Status, " Exportado para PDF.", "")
                                Catch ex As Exception
                                    .Cells(cnt_grdGeral_PDF).Value = "Não"
                                    Str_Adicionar(Status, " [ERROR EXPORT PDF] - " & ex.Message & ".", "")
                                End Try
                            End If

                            '>> Exportação Excel
                            If .Cells(cnt_grdGeral_Excel).Tag = cnt_Opcao_Sim Then
                                If Dir(sArquivoDestino & ".xlsx") <> "" Then Kill(sArquivoDestino & ".xlsx")

                                Try
                                    oRelatorio.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, sArquivoDestino & ".xls")
                                    .Cells(cnt_grdGeral_Excel).Value = "Sim"
                                    Str_Adicionar(Status, " Exportado para Excel.", "")
                                Catch ex As Exception
                                    .Cells(cnt_grdGeral_Excel).Value = "Não"
                                    Str_Adicionar(Status, " [ERROR EXPORT EXCEL] - " & ex.Message & ".", "")
                                End Try
                            End If
                        Else
                            Str_Adicionar(Status, " Relatório não gerado" & IIf(Trim(NO_Filial) = "", "", " (" & NO_Filial & ")") & ".", "")
                        End If

                        .Cells(cnt_grdGeral_Status).Value = Trim(Status)
                    End With
                Next iCont_Filial
            End If
        Next

        If Dir(sDiretorioDestino & "Resultado.xlsx") <> "" Then Kill(sDiretorioDestino & "Resultado.xlsx")
        objGrid_ExportarExcell(grdGeral, Me.Text, , , sDiretorioDestino & "Resultado.xlsx")

        AVI_Fechar(Me)
    End Sub

    Private Sub frmRelatorioGeracaoAutomatica_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim iCont As Integer

        lblStatus.Text = ""
        PegarValores()

        objGrid_Inicializar(grdGeral, , oDS)
        objGrid_Coluna_Add(grdGeral, "Codigo", 0)
        objGrid_Coluna_Add(grdGeral, "Gerar", 50, , True, Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdGeral, "Nome", 350)
        objGrid_Coluna_Add(grdGeral, "Tipo", 60)
        objGrid_Coluna_Add(grdGeral, "PDF", 40, , , , , , , , , , , Infragistics.Win.HAlign.Center)
        objGrid_Coluna_Add(grdGeral, "Excel", 50, , , , , , , , , , , Infragistics.Win.HAlign.Center)
        objGrid_Coluna_Add(grdGeral, "Status", 200)
        objGrid_Coluna_Add(grdGeral, "PorFilial", 0)

        '>> Adt Exposure - Analítico - Adto c/ Ctr Base
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Adt_Exposure_Adto_C_CtrBase_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Adt Exposure - Adto c/ Ctr Base"
            .Cells(cnt_grdGeral_Tipo).Value = "Analítico"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Adt Exposure - Analítico - Adto s/ Ctr Base
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Adt_Exposure_Adto_S_CtrBase_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Adt Exposure - Adto s/ Ctr Base"
            .Cells(cnt_grdGeral_Tipo).Value = "Analítico"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Adt Exposure - Sintético
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Adt_Exposure_Sintetico
            .Cells(cnt_grdGeral_Nome).Value = "Adt Exposure"
            .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Ctr Com Saldo (Com Incidência De Imposto - Projeto)
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Ctr_Com_Saldo_Com_Incidencia_De_Imposto_Projeto
            .Cells(cnt_grdGeral_Nome).Value = "Ctr Com Saldo (Com Incidência De Imposto - Projeto)"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Ctr Com Saldo (Sem Incidência De Imposto - Projeto)
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Ctr_Com_Saldo_Sem_Incidencia_De_Imposto_Projeto
            .Cells(cnt_grdGeral_Nome).Value = "Ctr Com Saldo (Sem Incidência De Imposto - Projeto)"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Ctr Paf Aberto - Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Ctr_Paf_Aberto_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Ctr Paf Aberto Analitico"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Ctr Neg Dif Aberto
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Ctr_Neg_Dif_Aberto
            .Cells(cnt_grdGeral_Nome).Value = "Ctr Neg Dif Aberto"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Ctr Fixo Aberto
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Ctr_Fixo_Aberto
            .Cells(cnt_grdGeral_Nome).Value = "Ctr Fixo Aberto"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Net Saldos (Filial)
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Net_Saldos_Filial
            .Cells(cnt_grdGeral_Nome).Value = "Net Saldos"
            .Cells(cnt_grdGeral_Tipo).Value = "Filial"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Net Saldos (Sintético)
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Net_Saldos_Sintetico
            .Cells(cnt_grdGeral_Nome).Value = "Net Saldos"
            .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Net Saldos (Titular)
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Net_Saldos_Titular
            .Cells(cnt_grdGeral_Nome).Value = "Net Saldos"
            .Cells(cnt_grdGeral_Tipo).Value = "Titular"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Fluxo Caixa
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Fluxo_Caixa
            .Cells(cnt_grdGeral_Nome).Value = "Fluxo Caixa"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Composição Estoque Cacau E Saldo Financeiro
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Composicao_Estoque_Cacau_E_Saldo_Financeiro
            .Cells(cnt_grdGeral_Nome).Value = "Composição Estoque Cacau E Saldo Financeiro"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Negociação Em Aberto Com Sua Fixação (Diferencial De Bolsa) - Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Negociacao_Em_Aberto_Com_Sua_Fixacao_Diferencial_De_Bolsa_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Negociação Em Aberto Com Sua Fixação (Diferencial De Bolsa)"
            .Cells(cnt_grdGeral_Tipo).Value = "Analitico"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Negociação Em Aberto Com Sua Fixação (Diferencial De Bolsa) - Sintético
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Negociacao_Em_Aberto_Com_Sua_Fixacao_Diferencial_De_Bolsa_Sintetico
            .Cells(cnt_grdGeral_Nome).Value = "Negociação Em Aberto Com Sua Fixação (Diferencial De Bolsa)"
            .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Confissão Dívida - Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Confissao_Divida_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Confissão Dívida"
            .Cells(cnt_grdGeral_Tipo).Value = "Analítico"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Confissão Dívida - Sintético
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Confissao_Divida_Sintetico
            .Cells(cnt_grdGeral_Nome).Value = "Confissão Dívida"
            .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Premiação (A Provisionar - Acumulado Desde 01/06/10/Por Fornecedor)
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_PrevisaoBonusQualidade
            .Cells(cnt_grdGeral_Nome).Value = "Previsão de Bônus de Qualidade"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Resumo Pagto Em Aberto No Ctr Paf - Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_ResumoPagto_Em_Aberto_No_Ctr_Paf_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Resumo Pagto Em Aberto No Ctr Paf"
            .Cells(cnt_grdGeral_Tipo).Value = "Analítico"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Resumo Pagto Em Aberto No Ctr Paf - Sintético
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_ResumoPagto_Em_Aberto_No_Ctr_Paf_Sintetico
            .Cells(cnt_grdGeral_Nome).Value = "Resumo Pagto Em Aberto No Ctr Paf"
            .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Resumo Pagto Em Aberto Negociações - Analitico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Resumopagto_Em_Aberto_Negociacoes_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Resumo Pagto Em Aberto Negociações"
            .Cells(cnt_grdGeral_Tipo).Value = "Analítico"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Resumo Pagto Em Aberto Negociações - Sintético
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Resumopagto_Em_Aberto_Negociacoes_Sintetico
            .Cells(cnt_grdGeral_Nome).Value = "Resumo Pagto Em Aberto Negociações"
            .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Pagto Sem Ctr Paf - Zerado
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Pagto_Sem_Ctr_Paf
            .Cells(cnt_grdGeral_Nome).Value = "Pagto Sem Ctr Paf"
            .Cells(cnt_grdGeral_Tipo).Value = ""
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Amarração Icms (Desde 01.01.06)
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Amarracao_ICMS
            .Cells(cnt_grdGeral_Nome).Value = "Amarração ICMS (Desde 01.01.06)"
            .Cells(cnt_grdGeral_Tipo).Value = ""
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Posição Fornecedor Gerkens
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Posicao_Fornecedor_Gerkens
            .Cells(cnt_grdGeral_Nome).Value = "Posição Fornecedor - Gerkens"
            .Cells(cnt_grdGeral_Tipo).Value = ""
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Cacau A Ordem (Filial Por Filial) - Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Cacau_A_Ordem_Filial_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Cacau A Ordem (Filial)"
            .Cells(cnt_grdGeral_Tipo).Value = "Analítico"
            .Cells(cnt_grdGeral_PorFilial).Value = "S"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Cacau A Ordem (Filial Por Filial) - Sintético
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Cacau_A_Ordem_Filial_Sintetico
            .Cells(cnt_grdGeral_Nome).Value = "Cacau A Ordem (Filial)"
            .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
            .Cells(cnt_grdGeral_PorFilial).Value = "S"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Cacau A Ordem (Geral) - Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Cacau_A_Ordem_Geral_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Cacau A Ordem (Geral)"
            .Cells(cnt_grdGeral_Tipo).Value = "Analítico"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Cacau A Ordem (Geral) - Sintético
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Cacau_A_Ordem_Geral_Sintetico
            .Cells(cnt_grdGeral_Nome).Value = "Cacau A Ordem (Geral)"
            .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Cacau A Ordem (Geral) - Valor Em Aberto - Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Cacau_A_Ordem_Geral_ValorAberto_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Cacau A Ordem - Valor em Aberto - (Geral)"
            .Cells(cnt_grdGeral_Tipo).Value = "Analítico"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Cacau A Ordem (Geral) - Valor Em Aberto - Sintético
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Cacau_A_Ordem_Geral_ValorAberto_Sintetico
            .Cells(cnt_grdGeral_Nome).Value = "Cacau A Ordem - Valor em Aberto - (Geral)"
            .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Cacau A Ordem Sem Ctr Paf - Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Cacau_A_Ordem_Sem_Ctr_Paf_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Cacau A Ordem Sem Ctr Paf"
            .Cells(cnt_grdGeral_Tipo).Value = "Analítico"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Cacau A Ordem Sem Ctr Paf - Sintético
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Cacau_A_Ordem_Sem_Ctr_Paf_Sintetico
            .Cells(cnt_grdGeral_Nome).Value = "Cacau A Ordem Sem Ctr Paf"
            .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Movimentação Aberto Negociações	- Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Movimentacao_Aberto_Negociacoes
            .Cells(cnt_grdGeral_Nome).Value = "Movimentação Aberto Negociações"
            .Cells(cnt_grdGeral_Tipo).Value = ""
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Estoque Cacau (Kg E Sc) - #
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Estoque_Cacau_KG
            .Cells(cnt_grdGeral_Nome).Value = "Estoque Cacau (Kg)"
            .Cells(cnt_grdGeral_Tipo).Value = ""
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Estoque Cacau (Kg E Sc) - #
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Estoque_Cacau_SC
            .Cells(cnt_grdGeral_Nome).Value = "Estoque Cacau (Sc)"
            .Cells(cnt_grdGeral_Tipo).Value = ""
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Estoque Armazem
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Estoque_Armazem
            .Cells(cnt_grdGeral_Nome).Value = "Estoque Armazem"
            .Cells(cnt_grdGeral_Tipo).Value = ""
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Resumo Estoques
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Resumo_Estoques
            .Cells(cnt_grdGeral_Nome).Value = "Resumo Estoques"
            .Cells(cnt_grdGeral_Tipo).Value = ""
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Preço Médio Contábil (Geral) - Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Preco_Medio_Contabil_Geral_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Preço Médio Contábil (Geral)"
            .Cells(cnt_grdGeral_Tipo).Value = "Analítico"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Preço Médio Contábil (Geral) - Sintético
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Preco_Medio_Contabil_Geral_Sintetico
            .Cells(cnt_grdGeral_Nome).Value = "Preço Médio Contábil (Geral)"
            .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Preço Médio Contábil (Filial) - Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Preco_Medio_Contabil_Filial_Analitico
            .Cells(cnt_grdGeral_Nome).Value = "Preço Médio Contábil (Filial)"
            .Cells(cnt_grdGeral_Tipo).Value = "Analítico"
            .Cells(cnt_grdGeral_PorFilial).Value = "S"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Saldos Fornecedores (Contabilidade) 
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_ComposicaoSaldoContaFornecedores
            .Cells(cnt_grdGeral_Nome).Value = "Composição Saldo Conta Fornecedores"
            .Cells(cnt_grdGeral_Tipo).Value = ""
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Valorização Industrialização - Sintético
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Valorizacao_Industrializacao
            .Cells(cnt_grdGeral_Nome).Value = "Valorização Industrialização"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Revalorização Cacau Ordem
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Revalorizacao_Cacau_Ordem
            .Cells(cnt_grdGeral_Nome).Value = "Revalorização Cacau Ordem"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Revalorização Cacau Ordem (Filial)
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Revalorizacao_Cacau_Ordem_Filial
            .Cells(cnt_grdGeral_Nome).Value = "Revalorização Cacau Ordem (Filial)"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            .Cells(cnt_grdGeral_PorFilial).Value = "S"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Revalorização Cacau Dif Bolsa
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Revalorizacao_Cacau_Dif_Bolsa
            .Cells(cnt_grdGeral_Nome).Value = "Revalorização Cacau Dif Bolsa"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Revalorização Cacau Dif Bolsa (Filial) - Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Revalorizacao_Cacau_Dif_Bolsa_Filial
            .Cells(cnt_grdGeral_Nome).Value = "Revalorização Cacau Dif Bolsa (Filial)"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            .Cells(cnt_grdGeral_PorFilial).Value = "S"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        '>> Provisão Nf Complementar
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Provisao_NF_Complementar
            .Cells(cnt_grdGeral_Nome).Value = "Provisão NF Complementar"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        End With
        '>> Provisão Nf Complementar (Filial) - Analítico
        With grdGeral.Rows(oDS.Rows.Add.Index)
            .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Provisao_NF_Complementar_Filial
            .Cells(cnt_grdGeral_Nome).Value = "Provisão Nf Complementar (Filial)"
            .Cells(cnt_grdGeral_Tipo).Value = "Geral"
            .Cells(cnt_grdGeral_PorFilial).Value = "S"
            Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), True)
            Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), False)
        End With
        ''>> Provisão Nf Complementar (Filial A Filial) - Sintético
        'With grdGeral.Rows(oDS.Rows.Add.Index)
        '    .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Planilha_Ctrl_Zeramento_Pilha_Sintetico
        '    .Cells(cnt_grdGeral_Nome).Value = "Planilha Ctrl Zeramento Pilha"
        '    .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
        '    Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), False)
        '    Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        'End With
        ''>> Suporte Recon Contábil - Sintético
        'With grdGeral.Rows(oDS.Rows.Add.Index)
        '    .Cells(cnt_grdGeral_Codigo).Value = cnt_TipoRelatorio_Suporte_Recon_Contabil_Sintetico
        '    .Cells(cnt_grdGeral_Nome).Value = "Suporte Recon Contábil"
        '    .Cells(cnt_grdGeral_Tipo).Value = "Sintético"
        '    Grid_TipoArquivo(.Cells(cnt_grdGeral_PDF), False)
        '    Grid_TipoArquivo(.Cells(cnt_grdGeral_Excel), True)
        'End With

        For iCont = 0 To grdGeral.Rows.Count - 1
            grdGeral.Rows(iCont).Update()
        Next
    End Sub

    Private Sub Grid_TipoArquivo(ByVal oCelula As Infragistics.Win.UltraWinGrid.UltraGridCell, _
                                 ByVal Exportar As Boolean)
        oCelula.Tag = IIf(Exportar, cnt_Opcao_Sim, cnt_Opcao_Nao)
        If Not Exportar Then oCelula.Appearance.BackColor = Color.Gainsboro
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        PegarValores()
    End Sub

    Private Sub PegarValores()
        Dim SqlText As String
        Dim DT_COTACAO As Date
        Dim TX_DOLAR As Double
        Dim VL_BOLSA As Double
        Dim VL_ARROBA As Double

        Relatorio_PegaValor(DT_COTACAO, TX_DOLAR, VL_BOLSA, VL_ARROBA)

        txtDolar.Value = TX_DOLAR
        txtBolsa.Value = VL_BOLSA
        txtValorArroba.Value = VL_ARROBA

        SqlText = "SELECT *" & _
                  " FROM (SELECT BP.VL_DIFERENCIAL FROM SOF.BOLSA_PERIODO BP" & _
                         " WHERE BP.IC_MOEDA = 'N'" & _
                         " AND BP.IC_EXIBE = 'S' " & _
                         " ORDER BY BP.SQ_BOLSA_PERIODO_MATRIZ ASC, NU_SEQUENCIA)" & _
                  " WHERE ROWNUM = 1"
        txtValorDif.Value = DBQuery_ValorUnico(SqlText, 0)
    End Sub
End Class