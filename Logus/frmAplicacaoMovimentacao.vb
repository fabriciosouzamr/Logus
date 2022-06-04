Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmAplicacaoMovimentacao
    Const cnt_GridConsContratoPAF_DataMovimentacao As Integer = 0
    Const cnt_GridConsContratoPAF_DataAplicacao As Integer = 1
    Const cnt_GridConsContratoPAF_QuantidadeAplicado As Integer = 2
    Const cnt_GridConsContratoPAF_ValorAplicado As Integer = 3
    Const cnt_GridConsContratoPAF_NF As Integer = 4
    Const cnt_GridConsContratoPAF_SerieN As Integer = 5
    Const cnt_GridConsContratoPAF_ValorNF As Integer = 6
    Const cnt_GridConsContratoPAF_ValorICMS_NF As Integer = 7
    Const cnt_GridConsContratoPAF_ValorINSS_NF As Integer = 8
    Const cnt_GridConsContratoPAF_TipoMovimentacao As Integer = 9
    Const cnt_GridConsContratoPAF_QuantidadeNegociacao As Integer = 10
    Const cnt_GridConsContratoPAF_ValorNegociacao As Integer = 11
    Const cnt_GridConsContratoPAF_FilialMovimentacao As Integer = 12
    Const cnt_GridConsContratoPAF_LocalEntrega As Integer = 13
    Const cnt_GridConsContratoPAF_SQ_MOVIMENTACAO As Integer = 14
    Const cnt_GridConsContratoPAF_CD_CONTRATO_PAF As Integer = 15
    Const cnt_GridConsContratoPAF_SQ_CTR_PAF_MOVIMENTACAO As Integer = 16
    Const cnt_GridConsContratoPAF_SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer = 17
    Const cnt_GridConsContratoPAF_QT_KG_MOVIMENTACAO As Integer = 18
    Const cnt_GridConsContratoPAF_VL_MOVIMENTACAO As Integer = 19

    Const cnt_GridCadContratoPAF_Selecao As Integer = 0
    Const cnt_GridCadContratoPAF_QuantidadeAplicada As Integer = 1
    Const cnt_GridCadContratoPAF_ValorAplicado As Integer = 2
    Const cnt_GridCadContratoPAF_QuantidadeAplicar As Integer = 3
    Const cnt_GridCadContratoPAF_ValorAplicar As Integer = 4
    Const cnt_GridCadContratoPAF_DataMovimentacao As Integer = 5
    Const cnt_GridCadContratoPAF_TipoMovimentacao As Integer = 6
    Const cnt_GridCadContratoPAF_NF As Integer = 7
    Const cnt_GridCadContratoPAF_SerieNF As Integer = 8
    Const cnt_GridCadContratoPAF_QuantN As Integer = 9
    Const cnt_GridCadContratoPAF_QuantLiquidoNF As Integer = 10
    Const cnt_GridCadContratoPAF_ValorNF As Integer = 11
    Const cnt_GridCadContratoPAF_ValorICMS As Integer = 12
    Const cnt_GridCadContratoPAF_ValorINSS As Integer = 13
    Const cnt_GridCadContratoPAF_LocalEntrega As Integer = 14
    Const cnt_GridCadContratoPAF_SQ_MOVIMENTACAO As Integer = 15
    Const cnt_GridCadContratoPAF_SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer = 16

    Const cnt_GridConsNegociacao_DataMovimentacao As Integer = 0
    Const cnt_GridConsNegociacao_DataAplicacao As Integer = 1
    Const cnt_GridConsNegociacao_QuantidadeAplicada As Integer = 2
    Const cnt_GridConsNegociacao_ValorAplicado As Integer = 3
    Const cnt_GridConsNegociacao_NF As Integer = 4
    Const cnt_GridConsNegociacao_SerieNF As Integer = 5
    Const cnt_GridConsNegociacao_ValorNF As Integer = 6
    Const cnt_GridConsNegociacao_ValorNFICMS As Integer = 7
    Const cnt_GridConsNegociacao_ValorINSSNF As Integer = 8
    Const cnt_GridConsNegociacao_TipoMovimentacao As Integer = 9
    Const cnt_GridConsNegociacao_QuantidadeContratoFixo As Integer = 10
    Const cnt_GridConsNegociacao_ValorContratoFixo As Integer = 11
    Const cnt_GridConsNegociacao_FilialMovimentacao As Integer = 12
    Const cnt_GridConsNegociacao_SQ_MOVIMENTACAO As Integer = 13
    Const cnt_GridConsNegociacao_CD_CONTRATO_PAF As Integer = 14
    Const cnt_GridConsNegociacao_SQ_CTR_PAF_MOVIMENTACAO As Integer = 15
    Const cnt_GridConsNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer = 16
    Const cnt_GridConsNegociacao_QT_KG_MOVIMENTACAO As Integer = 17
    Const cnt_GridConsNegociacao_VL_MOVIMENTACAO As Integer = 18
    Const cnt_GridConsNegociacao_SQ_CTR_PAF_NEG_MOVIMENTACAO As Integer = 19
    Const cnt_GridConsNegociacao_SQ_NEGOCIACAO As Integer = 20

    Const cnt_GridCadNegociacao_Selecao As Integer = 0
    Const cnt_GridCadNegociacao_QuantidadeAplicada As Integer = 1
    Const cnt_GridCadNegociacao_ValorAplicado As Integer = 2
    Const cnt_GridCadNegociacao_QuantidadeAplicar As Integer = 3
    Const cnt_GridCadNegociacao_ValorAplicar As Integer = 4
    Const cnt_GridCadNegociacao_Posto As Integer = 5
    Const cnt_GridCadNegociacao_DataMovimentacao As Integer = 6
    Const cnt_GridCadNegociacao_TipoMovimentacao As Integer = 7
    Const cnt_GridCadNegociacao_NF As Integer = 8
    Const cnt_GridCadNegociacao_SerieNF As Integer = 9
    Const cnt_GridCadNegociacao_QtdeNF As Integer = 10
    Const cnt_GridCadNegociacao_QtdeLiquidoNF As Integer = 11
    Const cnt_GridCadNegociacao_ValorNF As Integer = 12
    Const cnt_GridCadNegociacao_ValorICMS As Integer = 13
    Const cnt_GridCadNegociacao_ValorINSS As Integer = 14
    Const cnt_GridCadNegociacao_SQ_MOVIMENTACAO As Integer = 15
    Const cnt_GridCadNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer = 16
    Const cnt_GridCadNegociacao_SQ_CTR_PAF_MOVIMENTACAO As Integer = 17

    Const cnt_GridCadContratoFixo_Selecao As Integer = 0
    Const cnt_GridCadContratoFixo_QuantidadeAplicado As Integer = 1
    Const cnt_GridCadContratoFixo_ValorAplicado As Integer = 2
    Const cnt_GridCadContratoFixo_QuantidadeAplicar As Integer = 3
    Const cnt_GridCadContratoFixo_ValorAplicar As Integer = 4
    Const cnt_GridCadContratoFixo_DataMovimentacao As Integer = 5
    Const cnt_GridCadContratoFixo_TipoMovimentacao As Integer = 6
    Const cnt_GridCadContratoFixo_NF As Integer = 7
    Const cnt_GridCadContratoFixo_SerieNF As Integer = 8
    Const cnt_GridCadContratoFixo_QuantNF As Integer = 9
    Const cnt_GridCadContratoFixo_QuantLiquidoNF As Integer = 10
    Const cnt_GridCadContratoFixo_ValorNF As Integer = 11
    Const cnt_GridCadContratoFixo_ValorICMS As Integer = 12
    Const cnt_GridCadContratoFixo_ValorINSS As Integer = 13
    Const cnt_GridCadContratoFixo_SQ_MOVIMENTACAO As Integer = 14
    Const cnt_GridCadContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer = 15
    Const cnt_GridCadContratoFixo_SQ_CTR_PAF_MOVIMENTACAO As Integer = 16
    Const cnt_GridCadContratoFixo_SQ_CTR_PAF_NEG_MOVIMENTACAO As Integer = 17
    Const cnt_GridCadContratoFixo_IC_ICMS_PAGO As Integer = 18

    Const cnt_GridConsContratoFixo_DataMovimentacao As Integer = 0
    Const cnt_GridConsContratoFixo_DataAplicacao As Integer = 1
    Const cnt_GridConsContratoFixo_QuantidadeAplicada As Integer = 2
    Const cnt_GridConsContratoFixo_ValorAplicado As Integer = 3
    Const cnt_GridConsContratoFixo_NF As Integer = 4
    Const cnt_GridConsContratoFixo_SerieNF As Integer = 5
    Const cnt_GridConsContratoFixo_ValorNF As Integer = 6
    Const cnt_GridConsContratoFixo_ValorICMS_NF As Integer = 7
    Const cnt_GridConsContratoFixo_ValorINSS_NF As Integer = 8
    Const cnt_GridConsContratoFixo_TipoMovimentacao As Integer = 9
    Const cnt_GridConsContratoFixo_FilialMovimentacao As Integer = 10
    Const cnt_GridConsContratoFixo_SQ_MOVIMENTACAO As Integer = 11
    Const cnt_GridConsContratoFixo_CD_FILIAL_ORIGEM As Integer = 12
    Const cnt_GridConsContratoFixo_CD_CONTRATO_PAF As Integer = 13
    Const cnt_GridConsContratoFixo_SQ_CTR_PAF_MOVIMENTACAO As Integer = 14
    Const cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer = 15
    Const cnt_GridConsContratoFixo_QT_KG_MOVIMENTACAO As Integer = 16
    Const cnt_GridConsContratoFixo_VL_MOVIMENTACAO As Integer = 17
    Const cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_MOVIMENTACAO As Integer = 18
    Const cnt_GridConsContratoFixo_SQ_NEGOCIACAO As Integer = 19
    Const cnt_GridConsContratoFixo_SQ_CONTRATO_FIXO As Integer = 20
    Const cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_CTR_FIX_MOV As Integer = 21

    Const cnt_SEC_Tela As String = "Transacao_Contratos_AplicacaoMovimentacao"

    Dim oDSConsContratoPAF As New UltraWinDataSource.UltraDataSource
    Dim oDSConsNegociacao As New UltraWinDataSource.UltraDataSource
    Dim oDSConsContratoFixo As New UltraWinDataSource.UltraDataSource
    Dim oDSCadContratoPAF As New UltraWinDataSource.UltraDataSource
    Dim oDSCadNegociacao As New UltraWinDataSource.UltraDataSource
    Dim oDSCadContratoFixo As New UltraWinDataSource.UltraDataSource

    Dim Cod_FilialOrigem As Integer
    Dim Cod_Fornecedor As Integer

    Dim Negociacao_ValidaSaldo As Boolean
    Dim Negociacao_SQ_CONTRATO_FIXO As Integer

    Dim ContratoFixo_Inclui_ICMS_Pag As Boolean = False

    Dim bProcInterno As Boolean = False
    Dim bTelaCarregada As Boolean = False
    Dim PcICMS As Double

    Private Sub frmAplicacaoMovimentacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_ContratoPAF.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_ContratoPAF

        objGrid_Inicializar(grdConsultaContratoPAF, , oDSConsContratoPAF, CellClickAction.CellSelect)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Data da Movimentação", 100)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Data da Aplicação", 100)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Quantidade Aplicada", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Valor Aplicado", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "NF", 100)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Série NF", 100)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Valor NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Valor ICMS NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Valor INSS NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Tipo de movimentação", 100)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Quantidade para negociação", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Valor para Negociação", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Filial de  Movimentação", 100)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Local de Entrega", 100)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "CD_CONTRATO_PAF", 0)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "SQ_CTR_PAF_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "SQ_MOVIMENTACAO_CESSAO_DIREITO", 0)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "QT_KG_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "VL_MOVIMENTACAO", 0)
        objGrid_ExibirTotal(grdConsultaContratoPAF, New Integer() {cnt_GridConsContratoPAF_QuantidadeAplicado, _
                                                                   cnt_GridConsContratoPAF_ValorAplicado})

        objGrid_Inicializar(grdCadastraContratoPAF, , oDSCadContratoPAF, UltraWinGrid.CellClickAction.RowSelect, , _
                                                                         DefaultableBoolean.False)
        objGrid_Coluna_Add(grdCadastraContratoPAF, " ", 30, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Quantidade", 100, , True, , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Valor", 100, , True, , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Saldo Quant", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Saldo Valor", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Data da Movimentação", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Tipo de Movimentação", 100)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "NF", 60)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Série da NF", 100)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Quant. NF", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Quant Liquido NF", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Valor da NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Valor do ICMS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Valor do INSS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Local de Entrega", 100)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "SQ_MOVIMENTACAO_CESSAO_DIREITO", 0)

        objGrid_Inicializar(grdConsultaNegociacao, , oDSConsNegociacao, UltraWinGrid.CellClickAction.RowSelect, , _
                                                                        DefaultableBoolean.False)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Data de Movimentação", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Data de Aplicação", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Quantidade Aplicada", 100)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Valor Aplicado", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaNegociacao, "NF", 100)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Série NF", 100)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Valor NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Valor NF ICMS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Valor INSS NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Tipo de Movimentação", 100)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Quantidade para Contrato Fixo", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Valor para Contrato Fixo", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Filial de Movimentação", 100)
        objGrid_Coluna_Add(grdConsultaNegociacao, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaNegociacao, "CD_CONTRATO_PAF", 0)
        objGrid_Coluna_Add(grdConsultaNegociacao, "SQ_CTR_PAF_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaNegociacao, "SQ_MOVIMENTACAO_CESSAO_DIREITO", 0)
        objGrid_Coluna_Add(grdConsultaNegociacao, "QT_KG_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaNegociacao, "VL_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaNegociacao, "SQ_CTR_PAF_NEG_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaNegociacao, "SQ_NEGOCIACAO", 0)
        objGrid_ExibirTotal(grdConsultaNegociacao, New Integer() {cnt_GridConsNegociacao_QuantidadeAplicada, _
                                                                  cnt_GridConsNegociacao_ValorAplicado})

        objGrid_Inicializar(grdCadastraNegociacao, , oDSCadNegociacao, UltraWinGrid.CellClickAction.RowSelect, , _
                                                                       DefaultableBoolean.False)
        objGrid_Coluna_Add(grdCadastraNegociacao, " ", 30, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Quantidade", 100, , True, , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Valor", 100, , True, , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Saldo Quant", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Saldo Valor", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Posto", 100)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Data da Movimentação", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Tipo da Movimentação", 100)
        objGrid_Coluna_Add(grdCadastraNegociacao, "NF", 50)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Série de NF", 50)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Qtde. de NF", 50, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Qtde. Líquido NF", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Valor da NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Valor de ICMS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Valor de INSS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraNegociacao, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdCadastraNegociacao, "SQ_MOVIMENTACAO_CESSAO_DIREITO", 0)
        objGrid_Coluna_Add(grdCadastraNegociacao, "SQ_CTR_PAF_MOVIMENTACAO", 0)

        objGrid_Inicializar(grdCadastraContratoFixo, , oDSCadContratoFixo, UltraWinGrid.CellClickAction.RowSelect, , _
                                                                           DefaultableBoolean.False)
        objGrid_Coluna_Add(grdCadastraContratoFixo, " ", 30, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Quantidade", 100, , True, , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Valor", 100, , True, , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Saldo Quant", 100)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Saldo Valor", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Data de Movimentação", 100)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Tipo de Movimentação", 100)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "NF", 100)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Série da NF", 100)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Quant. NF", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Quant. Líquido NF", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Valor NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Valor ICMS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Valor INSS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "SQ_MOVIMENTACAO_CESSAO_DIREITO", 0)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "SQ_CTR_PAF_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "SQ_CTR_PAF_NEG_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "IC_ICMS_PAGO", 0)

        objGrid_Inicializar(grdConsultaContratoFixo, , oDSConsContratoFixo, UltraWinGrid.CellClickAction.RowSelect, , _
                                                                            DefaultableBoolean.False)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Data de Movimentação", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Data da Aplicação", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Quantidade Aplicada", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Valor Aplicado", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "NF", 100)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Série da NF", 100)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Valor da NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Valor do ICMS da NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Valor do INSS da NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Tipo da Movimentação", 100)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Filial da Movimentação", 100)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "CD_FILIAL_ORIGEM", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "CD_CONTRATO_PAF", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "SQ_CTR_PAF_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "SQ_MOVIMENTACAO_CESSAO_DIREITO", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "QT_KG_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "VL_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "SQ_CTR_PAF_NEG_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "SQ_NEGOCIACAO", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "SQ_CONTRATO_FIXO", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "SQ_CTR_PAF_NEG_CTR_FIX_MOV", 0)

        objGrid_ExibirTotal(grdConsultaContratoFixo, New Integer() {cnt_GridConsContratoFixo_QuantidadeAplicada, _
                                                                    cnt_GridConsContratoFixo_ValorAplicado})

        SEC_ValidarBotao(cmdGravar_ContratoPAF, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdGravar_Negociacao, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdGravar_ContratoFixo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdQuebrar_ContratoPAF, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdQuebrar_Negociacao, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdQuebrar_ContratoFixo, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdExcluir_ContratoPAF, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao(cmdExcluir_Negociacao, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao(cmdExcluir_ContratoFixo, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)

        ContratoPAF_LimparTela()
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized
        bTelaCarregada = True
    End Sub

    Private Sub Pesquisar_ContratoPAF_Consulta()
        Dim SqlText As String

        txtSaldoQuantidadeContratoPAF.Value = 0

        If Pesq_ContratoPAF.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um Contrato PAF válido.")
            Exit Sub
        End If

        SqlText = "SELECT (CP.QT_KGS - CP.QT_KG_FIXO - CP.QT_CANCELADO) AS QT_SALDO" & _
                  " FROM SOF.CONTRATO_PAF CP " & _
                  " WHERE CP.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo
        txtSaldoQuantidadeContratoPAF.Value = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT M.DT_MOVIMENTACAO," & _
                         "CPM.DT_FIXACAO," & _
                         "CPM.QT_KG_FIXO," & _
                         "CPM.VL_FIXO," & _
                         "M.NU_NF," & _
                         "M.NU_SERIE_NF," & _
                         "M.VL_NF," & _
                         "M.VL_NF_ICMS," & _
                         "M.VL_NF_FUNRURAL," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "CPM.QT_KG_A_FIXAR," & _
                         "CPM.VL_A_FIXAR," & _
                         "FIL.NO_FILIAL," & _
                         "LE.NO_LOCAL_ENTREGA," & _
                         "CPM.SQ_MOVIMENTACAO," & _
                         "CPM.CD_CONTRATO_PAF," & _
                         "CPM.SQ_CTR_PAF_MOVIMENTACAO," & _
                         "CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                         "MCD.QT_KG_MOVIMENTACAO," & _
                         "MCD.VL_MOVIMENTACAO" & _
                  " FROM SOF.CTR_PAF_MOVIMENTACAO CPM," & _
                        "SOF.MOVIMENTACAO M," & _
                        "SOF.LOCAL_ENTREGA LE," & _
                        "SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.FILIAL FIL" & _
                  " WHERE M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                    " AND MCD.SQ_MOVIMENTACAO = CPM.SQ_MOVIMENTACAO" & _
                    " AND M.CD_FILIAL_MOVIMENTACAO=FIL.CD_FILIAL" & _
                    " AND MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO = CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                    " AND TM.CD_TIPO_MOVIMENTACAO = M.CD_TIPO_MOVIMENTACAO" & _
                    " AND M.CD_LOCAL_ENTREGA = LE.CD_LOCAL_ENTREGA (+)" & _
                    " AND CPM.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                  " ORDER BY M.DT_MOVIMENTACAO,CPM.DT_FIXACAO DESC"

        objGrid_Carregar(grdConsultaContratoPAF, SqlText, New Integer() {cnt_GridConsContratoPAF_DataMovimentacao, cnt_GridConsContratoPAF_DataAplicacao, _
                                                                         cnt_GridConsContratoPAF_QuantidadeAplicado, cnt_GridConsContratoPAF_ValorAplicado, _
                                                                         cnt_GridConsContratoPAF_NF, cnt_GridConsContratoPAF_SerieN, _
                                                                         cnt_GridConsContratoPAF_ValorNF, cnt_GridConsContratoPAF_ValorICMS_NF, _
                                                                         cnt_GridConsContratoPAF_ValorINSS_NF, cnt_GridConsContratoPAF_TipoMovimentacao, _
                                                                         cnt_GridConsContratoPAF_QuantidadeNegociacao, cnt_GridConsContratoPAF_ValorNegociacao, _
                                                                         cnt_GridConsContratoPAF_FilialMovimentacao, cnt_GridConsContratoPAF_LocalEntrega, _
                                                                         cnt_GridConsContratoPAF_SQ_MOVIMENTACAO, cnt_GridConsContratoPAF_CD_CONTRATO_PAF, _
                                                                         cnt_GridConsContratoPAF_SQ_CTR_PAF_MOVIMENTACAO, cnt_GridConsContratoPAF_SQ_MOVIMENTACAO_CESSAO_DIREITO, _
                                                                         cnt_GridConsContratoPAF_QT_KG_MOVIMENTACAO, cnt_GridConsContratoPAF_VL_MOVIMENTACAO}, False)
        objGrid_ExibirTotal(grdConsultaContratoPAF, New Integer() {cnt_GridConsContratoPAF_ValorAplicado, _
                                                                   cnt_GridConsContratoPAF_QuantidadeAplicado})
    End Sub

    Private Sub AjustarTela()
        Dim oTab As Infragistics.Win.UltraWinTabControl.UltraTabPageControl

        If tbsGeral.ActiveTab Is Nothing Then
            oTab = TabPagamento
        Else
            oTab = tbsGeral.ActiveTab.TabPage
        End If

        '>> TAB Geral
        tbsGeral.Height = Me.Height - tbsGeral.Top - 35
        tbsGeral.Width = Me.Width - tbsGeral.Left - 15

        '>TAB Aplicação de Contrato PAF
        'Botões Consulta
        cmdExcluir_ContratoPAF.Top = oTab.Height - cmdExcluir_ContratoPAF.Height - 2
        cmdQuebrar_ContratoPAF.Top = cmdExcluir_ContratoPAF.Top
        cmdUsuario_ContratoPAF.Top = cmdExcluir_ContratoPAF.Top
        'Grid Consulta
        grdConsultaContratoPAF.Top = oTab.Height / 2
        grdConsultaContratoPAF.Height = oTab.Height - grdConsultaContratoPAF.Top - cmdExcluir_ContratoPAF.Height - 10
        grdConsultaContratoPAF.Width = oTab.Width - (grdConsultaContratoPAF.Left * 2)
        'Campo Saldo
        txtSaldoQuantidadeContratoPAF.Left = grdConsultaContratoPAF.Left + grdConsultaContratoPAF.Width - txtSaldoQuantidadeContratoPAF.Width
        txtSaldoQuantidadeContratoPAF.Top = cmdExcluir_ContratoPAF.Top
        lblSaldoQuantidadeContratoPAF.Left = txtSaldoQuantidadeContratoPAF.Left - lblSaldoQuantidadeContratoPAF.Width - 5
        lblSaldoQuantidadeContratoPAF.Top = cmdExcluir_ContratoPAF.Top + ((cmdExcluir_ContratoPAF.Height - _
                                                                           lblSaldoQuantidadeContratoPAF.Height) / 2)
        'Botão Gravação
        cmdGravar_ContratoPAF.Top = grdConsultaContratoPAF.Top - cmdGravar_ContratoPAF.Height - 5
        cmdSelecionarTodos_ContratoPAF.Top = cmdGravar_ContratoPAF.Top
        'Campo Após Aplicação
        txtQuantidadeAposAplicacaoContratoPAF.Left = grdConsultaContratoPAF.Left + grdConsultaContratoPAF.Width - _
                                                      txtQuantidadeAposAplicacaoContratoPAF.Width
        txtQuantidadeAposAplicacaoContratoPAF.Top = cmdGravar_ContratoPAF.Top
        lblQuantidadeAposAplicacaoContratoPAF.Top = cmdGravar_ContratoPAF.Top + ((cmdGravar_ContratoPAF.Height - _
                                                                                   lblQuantidadeAposAplicacaoContratoPAF.Height) / 2)
        'Campo Total Aplicado
        txtValorTotalAplicadoContratoPAF.Top = txtQuantidadeAposAplicacaoContratoPAF.Top - txtValorTotalAplicadoContratoPAF.Height - 5
        txtValorTotalAplicadoContratoPAF.Left = txtQuantidadeAposAplicacaoContratoPAF.Left
        lblValorTotalAplicadoContratoPAF.Left = txtValorTotalAplicadoContratoPAF.Left - lblValorTotalAplicadoContratoPAF.Width - 5
        lblValorTotalAplicadoContratoPAF.Top = txtValorTotalAplicadoContratoPAF.Top + ((txtValorTotalAplicadoContratoPAF.Height - _
                                                                                          lblValorTotalAplicadoContratoPAF.Height) / 2)
        txtQuantidadeTotalAplicadoContratoPAF.Top = txtValorTotalAplicadoContratoPAF.Top
        txtQuantidadeTotalAplicadoContratoPAF.Left = lblValorTotalAplicadoContratoPAF.Left - txtQuantidadeTotalAplicadoContratoPAF.Width - 15
        lblQuantidadeTotalAplicadoContratoPAF.Left = txtQuantidadeTotalAplicadoContratoPAF.Left - lblQuantidadeTotalAplicadoContratoPAF.Width - 5
        lblQuantidadeTotalAplicadoContratoPAF.Top = lblValorTotalAplicadoContratoPAF.Top
        txtQuantidadeAposAplicacaoContratoPAF.Left = txtQuantidadeTotalAplicadoContratoPAF.Left
        lblQuantidadeAposAplicacaoContratoPAF.Left = txtQuantidadeAposAplicacaoContratoPAF.Left - lblQuantidadeAposAplicacaoContratoPAF.Width - 5
        'Grid Cadastro
        grdCadastraContratoPAF.Height = txtQuantidadeTotalAplicadoContratoPAF.Top - grdCadastraContratoPAF.Top - 5
        grdCadastraContratoPAF.Width = grdConsultaContratoPAF.Width

        '>TAB Aplicação de Contrato Negociacao
        'Botões Consulta
        cmdExcluir_Negociacao.Top = oTab.Height - cmdExcluir_Negociacao.Height - 2
        cmdQuebrar_Negociacao.Top = cmdExcluir_Negociacao.Top
        cmdUsuario_Negociacao.Top = cmdExcluir_Negociacao.Top
        'Grid Consulta
        grdConsultaNegociacao.Top = oTab.Height / 2
        grdConsultaNegociacao.Height = oTab.Height - grdConsultaNegociacao.Top - cmdExcluir_Negociacao.Height - 10
        grdConsultaNegociacao.Width = oTab.Width - (grdConsultaNegociacao.Left * 2)
        'Campo Saldo
        txtSaldoValorNegociacao.Left = grdConsultaNegociacao.Left + grdConsultaNegociacao.Width - txtSaldoValorNegociacao.Width
        txtSaldoValorNegociacao.Top = cmdExcluir_Negociacao.Top
        lblSaldoValorNegociacao.Left = txtSaldoValorNegociacao.Left - lblSaldoValorNegociacao.Width - 5
        lblSaldoValorNegociacao.Top = cmdExcluir_Negociacao.Top + ((cmdExcluir_Negociacao.Height - _
                                                                    lblSaldoValorNegociacao.Height) / 2)
        txtSaldoQuantidadeNegociacao.Top = txtSaldoValorNegociacao.Top
        txtSaldoQuantidadeNegociacao.Left = lblSaldoValorNegociacao.Left - txtSaldoQuantidadeNegociacao.Width - 15
        lblSaldoQuantidadeNegociacao.Top = lblSaldoValorNegociacao.Top
        lblSaldoQuantidadeNegociacao.Left = txtSaldoQuantidadeNegociacao.Left - _
                                            lblSaldoQuantidadeNegociacao.Width - 5
        lblPostoNegociacao.Top = lblSaldoValorNegociacao.Top
        'Botão Gravação
        cmdGravar_Negociacao.Top = grdConsultaNegociacao.Top - cmdGravar_Negociacao.Height - 5
        cmdSelecionarTodos_Negociacao.Top = cmdGravar_Negociacao.Top
        'Campo Após Aplicação
        txtValorAposAplicacaoNegociacao.Left = grdConsultaNegociacao.Left + grdConsultaNegociacao.Width - _
                                                txtValorAposAplicacaoNegociacao.Width
        txtValorAposAplicacaoNegociacao.Top = cmdGravar_Negociacao.Top
        lblValorAposAplicacaoNegociacao.Top = cmdGravar_Negociacao.Top + ((cmdGravar_Negociacao.Height - _
                                                                             lblValorAposAplicacaoNegociacao.Height) / 2)
        lblValorAposAplicacaoNegociacao.Left = txtValorAposAplicacaoNegociacao.Left - lblValorAposAplicacaoNegociacao.Width - 5
        txtQuantidadeAposAplicacaoNegociacao.Top = txtValorAposAplicacaoNegociacao.Top
        txtQuantidadeAposAplicacaoNegociacao.Left = lblValorAposAplicacaoNegociacao.Left - txtQuantidadeAposAplicacaoNegociacao.Width - 15
        lblQuantidadeAposAplicacaoNegociacao.Top = lblValorAposAplicacaoNegociacao.Top
        lblQuantidadeAposAplicacaoNegociacao.Left = txtQuantidadeAposAplicacaoNegociacao.Left - lblQuantidadeAposAplicacaoNegociacao.Width - 5
        'Campo Total Aplicado
        txtValorTotalAplicadoNegociacao.Top = txtValorAposAplicacaoNegociacao.Top - txtValorTotalAplicadoContratoPAF.Height - 5
        txtValorTotalAplicadoNegociacao.Left = txtValorAposAplicacaoNegociacao.Left
        lblValorTotalAplicadoNegociacao.Left = txtValorTotalAplicadoNegociacao.Left - lblValorTotalAplicadoNegociacao.Width - 5
        lblValorTotalAplicadoNegociacao.Top = txtValorTotalAplicadoNegociacao.Top + ((txtValorTotalAplicadoNegociacao.Height - _
                                                                                      lblValorTotalAplicadoNegociacao.Height) / 2)
        txtQuantidadeTotalAplicadoNegociacao.Top = txtValorTotalAplicadoNegociacao.Top
        txtQuantidadeTotalAplicadoNegociacao.Left = txtQuantidadeAposAplicacaoNegociacao.Left
        lblQuantidadeTotalAplicadoNegociacao.Left = txtQuantidadeTotalAplicadoNegociacao.Left - lblQuantidadeTotalAplicadoNegociacao.Width - 5
        lblQuantidadeTotalAplicadoNegociacao.Top = lblValorTotalAplicadoNegociacao.Top
        'Grid Cadastro
        grdCadastraNegociacao.Height = txtValorTotalAplicadoNegociacao.Top - grdCadastraNegociacao.Top - 5
        grdCadastraNegociacao.Width = grdConsultaNegociacao.Width

        '>TAB Aplicação de Contrato Fixo
        'Botões Consulta
        cmdExcluir_ContratoFixo.Top = oTab.Height - cmdExcluir_ContratoFixo.Height - 2
        cmdQuebrar_ContratoFixo.Top = cmdExcluir_ContratoFixo.Top
        cmdUsuario_ContratoFixo.Top = cmdExcluir_ContratoFixo.Top
        'Grid Consulta
        grdConsultaContratoFixo.Top = oTab.Height / 2
        grdConsultaContratoFixo.Height = oTab.Height - grdConsultaContratoFixo.Top - cmdExcluir_ContratoFixo.Height - 10
        grdConsultaContratoFixo.Width = oTab.Width - (grdConsultaContratoFixo.Left * 2)
        'Campo Saldo
        txtSaldoValorContratoFixo.Left = grdConsultaContratoFixo.Left + grdConsultaContratoFixo.Width - txtSaldoValorContratoFixo.Width
        txtSaldoValorContratoFixo.Top = cmdExcluir_ContratoFixo.Top
        lblSaldoValorContratoFixo.Left = txtSaldoValorContratoFixo.Left - lblSaldoValorContratoFixo.Width - 5
        lblSaldoValorContratoFixo.Top = cmdExcluir_ContratoFixo.Top + ((cmdExcluir_ContratoFixo.Height - _
                                                                    lblSaldoValorContratoFixo.Height) / 2)
        txtSaldoQuantidadeContratoFixo.Top = txtSaldoValorContratoFixo.Top
        txtSaldoQuantidadeContratoFixo.Left = lblSaldoValorContratoFixo.Left - txtSaldoQuantidadeContratoFixo.Width - 15
        lblSaldoQuantidadeContratoFixo.Top = lblSaldoValorContratoFixo.Top
        lblSaldoQuantidadeContratoFixo.Left = txtSaldoQuantidadeContratoFixo.Left - _
                                            lblSaldoQuantidadeContratoFixo.Width - 5
        'Botão Gravação
        cmdGravar_ContratoFixo.Top = grdConsultaContratoFixo.Top - cmdGravar_ContratoFixo.Height - 5
        cmdSelecionarTodos_ContratoFixo.Top = cmdGravar_ContratoFixo.Top
        'Campo Após Aplicação
        txtValorAposAplicacaoContratoFixo.Left = grdConsultaContratoFixo.Left + grdConsultaContratoFixo.Width - _
                                                txtValorAposAplicacaoContratoFixo.Width
        txtValorAposAplicacaoContratoFixo.Top = cmdGravar_ContratoFixo.Top
        lblValorAposAplicacaoContratoFixo.Top = cmdGravar_ContratoFixo.Top + ((cmdGravar_ContratoFixo.Height - _
                                                                             lblValorAposAplicacaoContratoFixo.Height) / 2)
        lblValorAposAplicacaoContratoFixo.Left = txtValorAposAplicacaoContratoFixo.Left - lblValorAposAplicacaoContratoFixo.Width - 5
        txtQuantidadeAposAplicacaoContratoFixo.Top = txtValorAposAplicacaoContratoFixo.Top
        txtQuantidadeAposAplicacaoContratoFixo.Left = lblValorAposAplicacaoContratoFixo.Left - txtQuantidadeAposAplicacaoContratoFixo.Width - 15
        lblQuantidadeAposAplicacaoContratoFixo.Top = lblValorAposAplicacaoContratoFixo.Top
        lblQuantidadeAposAplicacaoContratoFixo.Left = txtQuantidadeAposAplicacaoContratoFixo.Left - lblQuantidadeAposAplicacaoContratoFixo.Width - 5
        'Campo Total Aplicado
        txtValorTotalAplicadoContratoFixo.Top = txtValorAposAplicacaoContratoFixo.Top - txtValorTotalAplicadoContratoPAF.Height - 5
        txtValorTotalAplicadoContratoFixo.Left = txtValorAposAplicacaoContratoFixo.Left
        lblValorTotalAplicadoContratoFixo.Left = txtValorTotalAplicadoContratoFixo.Left - lblValorTotalAplicadoContratoFixo.Width - 5
        lblValorTotalAplicadoContratoFixo.Top = txtValorTotalAplicadoContratoFixo.Top + ((txtValorTotalAplicadoContratoFixo.Height - _
                                                                                      lblValorTotalAplicadoContratoFixo.Height) / 2)
        txtQuantidadeTotalAplicadoContratoFixo.Top = txtValorTotalAplicadoContratoFixo.Top
        txtQuantidadeTotalAplicadoContratoFixo.Left = txtQuantidadeAposAplicacaoContratoFixo.Left
        lblQuantidadeTotalAplicadoContratoFixo.Left = txtQuantidadeTotalAplicadoContratoFixo.Left - lblQuantidadeTotalAplicadoContratoFixo.Width - 5
        lblQuantidadeTotalAplicadoContratoFixo.Top = lblValorTotalAplicadoContratoFixo.Top
        'Grid Cadastro
        grdCadastraContratoFixo.Height = txtValorTotalAplicadoContratoFixo.Top - grdCadastraContratoFixo.Top - 5
        grdCadastraContratoFixo.Width = grdConsultaContratoFixo.Width
    End Sub

    Private Sub Pesquisar()
        Select Case tbsGeral.SelectedTab.Index
            Case 0
                Pesquisar_ContratoPAF()
            Case 1
                Pesquisar_Negociacao()
            Case 2
                Pesquisar_ContratoFixo()
        End Select
    End Sub

    Private Sub Pesquisar_ContratoPAF()
        Pesquisar_ContratoPAF_Cadastro()
        Pesquisar_ContratoPAF_Consulta()
    End Sub

    Private Sub Pesq_ContratoPAF_AlterouRegistro() Handles Pesq_ContratoPAF.AlterouRegistro
        If Pesq_ContratoPAF.Codigo = 0 Then
            ContratoPAF_LimparTela()
        Else
            Dim SqlText As String
            Dim oData As DataTable

            oDSConsContratoPAF.Rows.Clear()
            oDSConsNegociacao.Rows.Clear()
            oDSConsContratoFixo.Rows.Clear()
            oDSCadContratoPAF.Rows.Clear()
            oDSCadNegociacao.Rows.Clear()
            oDSCadContratoFixo.Rows.Clear()

            ContratoPAF_LimparTela()
            Negociacao_LimparTela()
            ContratoFixo_LimparTela()

            If Pesq_ContratoPAF.Codigo = 0 Then Exit Sub

            SqlText = "SELECT F.NO_RAZAO_SOCIAL," & _
                             "CP.CD_FORNECEDOR," & _
                             "F.CD_FILIAL_ORIGEM," & _
                             "CP.IC_CALCULA_JUROS," & _
                             "CP.IC_JUROS_NEG_REC," & _
                             "CP.IC_STATUS" & _
                      " FROM SOF.FORNECEDOR F," & _
                            "SOF.CONTRATO_PAF CP " & _
                      " WHERE CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                        " AND CP.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo
            oData = DBQuery(SqlText)

            If oData.Rows.Count = 0 Then
                Msg_Mensagem("Contrato não encontrado")
                GoTo Limpar
            Else
                If oData.Rows(0).Item("IC_STATUS") = "E" Then
                    Msg_Mensagem("Este contrato já está eliminado")
                    GoTo Limpar
                ElseIf oData.Rows(0).Item("IC_STATUS") = "C" Then
                    Msg_Mensagem("Este contrato está cancelado")
                    GoTo Limpar
                End If
            End If

            Cod_Fornecedor = oData.Rows(0).Item("CD_FORNECEDOR")

            SqlText = "SELECT COUNT(*) QT FROM SOF.CONFISSAO_DIVIDA_ATIVO_VENDA WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo

            If DBQuery_ValorUnico(SqlText) <> 0 Then
                Msg_Mensagem("Esse contrato é uma liquidação de uma recuperação de crédito.")
                GoTo Limpar
            End If

            SqlText = "SELECT NO_RAZAO_SOCIAL," & _
                             "CD_FILIAL_ORIGEM " & _
                      " FROM SOF.FORNECEDOR " & _
                      " WHERE CD_FORNECEDOR=" & oData.Rows(0).Item("CD_FORNECEDOR") & _
                        " AND CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            oData = DBQuery(SqlText)

            If objDataTable_Vazio(oData) Then
                Msg_Mensagem("Este fornecedor não pertence a nenhuma das filiais liberadas para o seu acesso")
                GoTo Limpar
            End If

            Cod_FilialOrigem = oData.Rows(0).Item("CD_FILIAL_ORIGEM")

            SqlText = "SELECT SQ_NEGOCIACAO," & _
                             "CAST(SQ_NEGOCIACAO AS VARCHAR2(15)) NO_NEGOCIACAO" & _
                      " FROM SOF.NEGOCIACAO" & _
                      " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                        " AND IC_STATUS NOT IN ('E')"
            DBCarregarComboBox(cboNegocicao, SqlText, True)

            cboNegocicao.Enabled = (cboNegocicao.Items.Count > 0)

            Pesquisar()
        End If

        Exit Sub

Limpar:
        Pesq_ContratoPAF.Codigo = 0
    End Sub

    Private Sub ContratoPAF_Eliminar_Aplicacao()
        If objGrid_LinhaSelecionada(grdConsultaContratoPAF) = -1 Then
            Msg_Mensagem("Selecione um contrato PAF")
            Exit Sub
        End If

        Dim SqlText As String

        If objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_ValorAplicado) <> _
           objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_ValorNegociacao) Or _
           objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_QuantidadeAplicado) <> _
           objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_QuantidadeNegociacao) Then
            Msg_Mensagem("Favor eliminar primeiro as aplicações feitas nas negociações.")
            Exit Sub
        End If

        If Not Msg_Perguntar("Elimina a aplicação?") Then Exit Sub

        On Error GoTo Erro

        SqlText = "DELETE FROM SOF.CTR_PAF_MOVIMENTACAO" & _
                  " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_SQ_MOVIMENTACAO) & _
                    " AND SQ_MOVIMENTACAO_CESSAO_DIREITO = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_SQ_MOVIMENTACAO_CESSAO_DIREITO) & _
                    " AND CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_CD_CONTRATO_PAF) & _
                    " AND SQ_CTR_PAF_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_SQ_CTR_PAF_MOVIMENTACAO)
        If Not DBExecutar(SqlText) Then GoTo Erro

        Pesquisar()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub ContratoPAF_Quebrar_Aplicacao()
        If objGrid_LinhaSelecionada(grdConsultaContratoPAF) = -1 Then
            Msg_Mensagem("Selecione um contrato PAF")
            Exit Sub
        End If

        Dim SqlText As String

        If objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_ValorNegociacao) = 0 And _
           objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_QuantidadeNegociacao) = 0 Then
            Msg_Mensagem("A aplicação nao possue saldo em aberto para realizar a operação.")
            Exit Sub
        End If

        Dim oForm As New frmAplicacao_QuebrarValor

        oForm.Tipo_Aplicacao_Contrato = frmAplicacao_QuebrarValor.enTipo_Aplicacao_Contrato.tacREC
        oForm.ValorMaximo = objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_ValorNegociacao)
        oForm.QuantidadeMaxima = objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_QuantidadeNegociacao)
        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            SqlText = "UPDATE SOF.CTR_PAF_MOVIMENTACAO " & _
                      " SET VL_FIXO = VL_FIXO - " & oForm.ValorSolicitado & "," & _
                           "VL_A_FIXAR = VL_A_FIXAR - " & oForm.ValorSolicitado & "," & _
                           "QT_KG_FIXO = QT_KG_FIXO - " & oForm.QuantidadeSolicitada & "," & _
                           "QT_KG_A_FIXAR = QT_KG_A_FIXAR - " & oForm.QuantidadeSolicitada & _
                      " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_SQ_MOVIMENTACAO) & _
                        " AND SQ_MOVIMENTACAO_CESSAO_DIREITO = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_SQ_MOVIMENTACAO_CESSAO_DIREITO) & _
                        " AND CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_CD_CONTRATO_PAF) & _
                        " AND SQ_CTR_PAF_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_SQ_CTR_PAF_MOVIMENTACAO)
            If Not DBExecutar(SqlText) Then GoTo Erro

            Pesquisar()
        End If

        oForm.Dispose()
        oForm = Nothing

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub frmAplicacaoMovimentacao_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        AjustarTela()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        Pesquisar()
    End Sub

    Private Sub cmdExcluir_ContratoPAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir_ContratoPAF.Click
        ContratoPAF_Eliminar_Aplicacao()
    End Sub

    Private Sub cmdUsuario_ContratoPAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario_ContratoPAF.Click
        If objGrid_LinhaSelecionada(grdConsultaContratoPAF) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "CTR_PAF_MOVIMENTACAO", "CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_CD_CONTRATO_PAF) _
                                                        & " AND SQ_CTR_PAF_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_SQ_CTR_PAF_MOVIMENTACAO) _
                                                        & " AND SQ_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_SQ_MOVIMENTACAO) _
                                                        & " AND SQ_MOVIMENTACAO_CESSAO_DIREITO = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridConsContratoPAF_SQ_MOVIMENTACAO_CESSAO_DIREITO))
    End Sub

    Private Sub cmdGravar_ContratoPAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_ContratoPAF.Click
        Dim iCont As Integer
        Dim ExiteSelecionado As Boolean
        Dim SqlText As String

        SqlText = "SELECT IC_STATUS FROM SOF.CONTRATO_PAF WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo

        If DBQuery_ValorUnico(SqlText) = "F" Then
            Msg_Mensagem("O contrato PAF ta fechado.")
            Exit Sub
        End If

        For iCont = 0 To grdCadastraContratoPAF.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraContratoPAF, cnt_GridCadContratoPAF_Selecao, iCont) Then
                ExiteSelecionado = True
            End If
        Next

        If Not ExiteSelecionado Then
            Msg_Mensagem("Favor selecionar uma movimentação antes.")
            Exit Sub
        End If

        Dim oAVI As frmAvi

        cmdGravar_ContratoPAF.Enabled = False
        oAVI = AVI_AbrirTela()

        DBUsarTransacao = True

        For iCont = 0 To grdCadastraContratoPAF.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraContratoPAF, cnt_GridCadContratoPAF_Selecao, iCont) Then
                SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", _
                                                                          ":SQMOV", _
                                                                          ":SQMOVCD", _
                                                                          ":VLFIXO", _
                                                                          ":QTFIXO", _
                                                                          ":SQCTRPAFMOV")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", Pesq_ContratoPAF.Codigo), _
                                           DBParametro_Montar("SQMOV", objGrid_Valor(grdCadastraContratoPAF, cnt_GridCadContratoPAF_SQ_MOVIMENTACAO, iCont)), _
                                           DBParametro_Montar("SQMOVCD", objGrid_Valor(grdCadastraContratoPAF, cnt_GridCadContratoPAF_SQ_MOVIMENTACAO_CESSAO_DIREITO, iCont)), _
                                           DBParametro_Montar("VLFIXO", objGrid_Valor(grdCadastraContratoPAF, cnt_GridCadContratoPAF_ValorAplicado, iCont)), _
                                           DBParametro_Montar("QTFIXO", objGrid_Valor(grdCadastraContratoPAF, cnt_GridCadContratoPAF_QuantidadeAplicada, iCont)), _
                                           DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro
            End If
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        Pesquisar()

        cmdGravar_ContratoPAF.Enabled = True
        AVI_FechaTela(oAVI)

        Exit Sub

Erro:
        cmdGravar_ContratoPAF.Enabled = True
        AVI_FechaTela(oAVI)
        TratarErro()
    End Sub

    Private Sub cmdQuebrar_ContratoPAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuebrar_ContratoPAF.Click
        ContratoPAF_Quebrar_Aplicacao()
    End Sub

    Private Sub Pesquisar_ContratoPAF_Cadastro()
        Dim SqlText As String

        If Pesq_ContratoPAF.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um Contrato PAF válido.")
            Exit Sub
        End If

        SqlText = "SELECT 0 SELECAO," & _
                         "0 QT_FIXA," & _
                         "0 VL_FIXA," & _
                         "MCD.QT_KG_A_FIXAR," & _
                         "MCD.VL_A_FIXAR," & _
                         "M.DT_MOVIMENTACAO," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "M.NU_NF," & _
                         "M.NU_SERIE_NF," & _
                         "M.QT_KG_NF," & _
                         "M.QT_KG_LIQUIDO_NF," & _
                         "M.VL_NF," & _
                         "M.VL_NF_ICMS," & _
                         "M.VL_NF_FUNRURAL," & _
                         "LE.NO_LOCAL_ENTREGA," & _
                         "MCD.SQ_MOVIMENTACAO," & _
                         "MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                  " FROM SOF.MOVIMENTACAO M," & _
                        "SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                        "SOF.TIPO_MOVIMENTACAO TM, " & _
                        "SOF.LOCAL_ENTREGA LE " & _
                  " WHERE M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                    " AND TM.CD_TIPO_MOVIMENTACAO = M.CD_TIPO_MOVIMENTACAO" & _
                    " AND M.CD_LOCAL_ENTREGA = LE.CD_LOCAL_ENTREGA (+)" & _
                    " AND MCD.CD_FORNECEDOR = " & Cod_Fornecedor & _
                    " AND (MCD.QT_KG_A_FIXAR <> 0 OR MCD.VL_A_FIXAR <> 0)"
        objGrid_Carregar(grdCadastraContratoPAF, SqlText, New Integer() {cnt_GridCadContratoPAF_Selecao, _
                                                                         cnt_GridCadContratoPAF_QuantidadeAplicada, _
                                                                         cnt_GridCadContratoPAF_ValorAplicado, _
                                                                         cnt_GridCadContratoPAF_QuantidadeAplicar, _
                                                                         cnt_GridCadContratoPAF_ValorAplicar, _
                                                                         cnt_GridCadContratoPAF_DataMovimentacao, _
                                                                         cnt_GridCadContratoPAF_TipoMovimentacao, _
                                                                         cnt_GridCadContratoPAF_NF, _
                                                                         cnt_GridCadContratoPAF_SerieNF, _
                                                                         cnt_GridCadContratoPAF_QuantN, _
                                                                         cnt_GridCadContratoPAF_QuantLiquidoNF, _
                                                                         cnt_GridCadContratoPAF_ValorNF, _
                                                                         cnt_GridCadContratoPAF_ValorICMS, _
                                                                         cnt_GridCadContratoPAF_ValorINSS, _
                                                                         cnt_GridCadContratoPAF_LocalEntrega, _
                                                                         cnt_GridCadContratoPAF_SQ_MOVIMENTACAO, _
                                                                         cnt_GridCadContratoPAF_SQ_MOVIMENTACAO_CESSAO_DIREITO}, False)

        Dim iCont As Integer
        If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ApricaCacauSemProporcionalidade) Then
            For iCont = 0 To grdCadastraContratoPAF.Rows.Count - 1
                If grdCadastraContratoPAF.Rows(iCont).Cells(cnt_GridCadContratoPAF_QuantLiquidoNF).Value <> 0 And _
                grdCadastraContratoPAF.Rows(iCont).Cells(cnt_GridCadContratoPAF_QuantidadeAplicar).Value = 0 Then
                    grdCadastraContratoPAF.Rows(iCont).Cells(cnt_GridCadContratoPAF_Selecao).Hidden = True
                End If
            Next
        End If
    End Sub

    Private Sub grdCadastraContratoPAF_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraContratoPAF.AfterCellUpdate
        If bProcInterno Then Exit Sub

        If e.Cell.Column.Index = cnt_GridCadContratoPAF_ValorAplicado Or _
           e.Cell.Column.Index = cnt_GridCadContratoPAF_QuantidadeAplicada Then
            bProcInterno = True

            With grdCadastraContratoPAF.Rows(e.Cell.Row.Index)
                'If NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) < 0 Or _
                '   (NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) > .Cells(cnt_GridCadContratoPAF_ValorAplicar).Value And _
                '    NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) <> 0) Then
                '    Msg_Mensagem("O Valor tem que estar entre 0 e " & Format(.Cells(cnt_GridCadContratoPAF_ValorAplicar).Value, "#,##0.00"))
                '    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = 0
                '    GoTo Sair
                'End If

                'If NVL(.Cells(cnt_GridCadContratoPAF_QuantidadeAplicada).Value, 0) < 0 Or _
                '   (NVL(.Cells(cnt_GridCadContratoPAF_QuantidadeAplicada).Value, 0) > .Cells(cnt_GridCadContratoPAF_QuantidadeAplicar).Value And _
                '    NVL(.Cells(cnt_GridCadContratoPAF_QuantidadeAplicada).Value, 0) <> 0) Then
                '    Msg_Mensagem("A quantidade tem que estar entre 0 e " & Format(.Cells(cnt_GridCadContratoPAF_QuantidadeAplicar).Value, "#,##0.00"))
                '    .Cells(cnt_GridCadContratoPAF_QuantidadeAplicada).Value = 0
                '    GoTo Sair
                'End If

                If NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) = 0 And _
                   NVL(.Cells(cnt_GridCadContratoPAF_QuantidadeAplicada).Value, 0) = 0 Then
                    .Cells(cnt_GridCadContratoPAF_Selecao).Value = 0
                Else
                    .Cells(cnt_GridCadContratoPAF_Selecao).Value = 1
                End If

                If e.Cell.Column.Index = cnt_GridCadContratoPAF_QuantidadeAplicada Then
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = Math.Round(NVL(.Cells(cnt_GridCadContratoPAF_QuantidadeAplicada).Value, 0) * _
                                                                                       (.Cells(cnt_GridCadContratoPAF_ValorAplicar).Value / _
                                                                                        .Cells(cnt_GridCadContratoPAF_QuantidadeAplicar).Value), 2)
                End If
            End With
        End If

        Calcula_Total_Aplicado_ContratoPAF()

Sair:
        bProcInterno = False
    End Sub

    Private Sub Calcula_Total_Aplicado_ContratoPAF()
        txtValorTotalAplicadoContratoPAF.Value = objGrid_CalcularTotalColuna(grdCadastraContratoPAF, cnt_GridCadContratoPAF_ValorAplicado)
        txtQuantidadeTotalAplicadoContratoPAF.Value = objGrid_CalcularTotalColuna(grdCadastraContratoPAF, cnt_GridCadContratoPAF_QuantidadeAplicada)
        txtQuantidadeAposAplicacaoContratoPAF.Value = txtSaldoQuantidadeContratoPAF.Value - txtQuantidadeTotalAplicadoContratoPAF.Value

        txtQuantidadeAposAplicacaoContratoPAF.Appearance.ForeColor = IIf(txtQuantidadeAposAplicacaoContratoPAF.Value = 0, _
                                                                          Color.Black, _
                                                                          IIf(txtQuantidadeAposAplicacaoContratoPAF.Value > 0, _
                                                                              Color.Blue, _
                                                                              IIf(txtQuantidadeAposAplicacaoContratoPAF.Value < 0, _
                                                                                  Color.Red, 0)))
    End Sub

    Private Sub Calcula_Total_Aplicado_Negociacao()
        txtValorTotalAplicadoNegociacao.Value = objGrid_CalcularTotalColuna(grdCadastraNegociacao, cnt_GridCadNegociacao_ValorAplicado)
        txtQuantidadeTotalAplicadoNegociacao.Value = objGrid_CalcularTotalColuna(grdCadastraNegociacao, cnt_GridCadNegociacao_QuantidadeAplicada)
        txtValorAposAplicacaoNegociacao.Value = txtSaldoValorNegociacao.Value - txtValorTotalAplicadoNegociacao.Value
        txtQuantidadeAposAplicacaoNegociacao.Value = txtSaldoQuantidadeNegociacao.Value - txtValorAposAplicacaoNegociacao.Value
    End Sub

    Private Sub Calcula_Total_Aplicado_ContratoFixo()
        txtValorTotalAplicadoContratoFixo.Value = objGrid_CalcularTotalColuna(grdCadastraContratoFixo, cnt_GridCadContratoFixo_ValorAplicado)
        txtQuantidadeTotalAplicadoContratoFixo.Value = objGrid_CalcularTotalColuna(grdCadastraContratoFixo, cnt_GridCadContratoFixo_QuantidadeAplicado)
        txtValorAposAplicacaoContratoFixo.Value = txtSaldoValorContratoFixo.Value - txtValorTotalAplicadoContratoFixo.Value
        txtQuantidadeAposAplicacaoContratoFixo.Value = txtSaldoQuantidadeContratoFixo.Value - txtValorAposAplicacaoContratoFixo.Value
    End Sub

    Private Sub grdCadastraContratoPAF_BeforeCellActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles grdCadastraContratoPAF.BeforeCellActivate
        If e.Cell.Row.Cells(cnt_GridCadContratoPAF_QuantLiquidoNF).Value <> 0 And Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ApricaCacauSemProporcionalidade) Then
            e.Cancel = (e.Cell.Column.Index = cnt_GridCadContratoPAF_ValorAplicado)
        End If

        If e.Cancel Then Exit Sub
    End Sub

    Private Sub grdCadastraContratoPAF_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraContratoPAF.CellChange
        If e.Cell.Column.Index = cnt_GridCadContratoPAF_Selecao Then
            With grdCadastraContratoPAF.Rows(e.Cell.Row.Index)
                bProcInterno = True
                If NVL(.Cells(cnt_GridCadContratoPAF_Selecao).Value, 0) = 1 Then
                    .Cells(cnt_GridCadContratoPAF_QuantidadeAplicada).Value = 0
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = 0
                    grdCadastraContratoPAF.PerformAction(UltraGridAction.ExitEditMode)
                Else
                    .Cells(cnt_GridCadContratoPAF_QuantidadeAplicada).Value = .Cells(cnt_GridCadContratoPAF_QuantidadeAplicar).Value
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = .Cells(cnt_GridCadContratoPAF_ValorAplicar).Value

                    .Cells(cnt_GridCadContratoPAF_QuantidadeAplicada).Activate()
                    grdCadastraContratoPAF.PerformAction(UltraGridAction.EnterEditMode)
                End If
                bProcInterno = False
            End With

            Calcula_Total_Aplicado_ContratoPAF()
        End If
    End Sub

    Private Sub Pesquisar_Negociacao_Consulta()
        Dim SqlText As String

        lblSaldoValorNegociacao.Visible = False
        txtSaldoValorNegociacao.Visible = False

        On Error GoTo Erro

        If Pesq_ContratoPAF.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um Contrato PAF valido.")
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboNegocicao) Then Exit Sub

        SqlText = DBMontar_SP("SOF.SP_VERIFICA_VALIDA_MOV_NEG", False, ":CDCTRPAF", _
                                                                       ":SQNEG", _
                                                                       ":ICVALIDAMOV", _
                                                                       ":QTKG", _
                                                                       ":VLNF", _
                                                                       ":CDLOCALENTREGA", _
                                                                       ":NOLOCALENTREGA", _
                                                                       ":ICCTRAFIXUNICO", _
                                                                       ":SQCTRAFIX")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", Pesq_ContratoPAF.Codigo), _
                                   DBParametro_Montar("SQNEG", cboNegocicao.SelectedValue), _
                                   DBParametro_Montar("ICVALIDAMOV", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("QTKG", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLNF", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("CDLOCALENTREGA", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("NOLOCALENTREGA", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("ICCTRAFIXUNICO", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQCTRAFIX", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        If DBTeveRetorno() Then
            txtSaldoQuantidadeNegociacao.Value = DBRetorno(2)

            If DBRetorno(1) = "S" Then
                txtSaldoValorNegociacao.Value = Val(DBRetorno(3))
                lblSaldoValorNegociacao.Visible = True
                txtSaldoValorNegociacao.Visible = True
            End If
        End If

        SqlText = "SELECT M.DT_MOVIMENTACAO, " & _
                         "CPM.DT_FIXACAO," & _
                         "CPM.QT_KG_FIXO," & _
                         "CPM.VL_FIXO," & _
                         "M.NU_NF," & _
                         "M.NU_SERIE_NF," & _
                         "M.VL_NF," & _
                         "M.VL_NF_ICMS," & _
                         "M.VL_NF_FUNRURAL," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "CPM.QT_KG_A_FIXAR," & _
                         "CPM.VL_A_FIXAR," & _
                         "FIL.NO_FILIAL," & _
                         "CPM.SQ_MOVIMENTACAO," & _
                         "CPM.CD_CONTRATO_PAF," & _
                         "CPM.SQ_CTR_PAF_MOVIMENTACAO," & _
                         "CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                         "MCD.QT_KG_MOVIMENTACAO," & _
                         "MCD.VL_MOVIMENTACAO," & _
                         "CPM.SQ_CTR_PAF_NEG_MOVIMENTACAO," & _
                         "CPM.SQ_NEGOCIACAO" & _
                  " FROM SOF.CTR_PAF_NEG_MOVIMENTACAO CPM," & _
                        "SOF.MOVIMENTACAO M, " & _
                        "SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.FILIAL FIL" & _
                  " WHERE M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                    " AND MCD.SQ_MOVIMENTACAO = CPM.SQ_MOVIMENTACAO" & _
                    " AND MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO = CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                    " AND TM.CD_TIPO_MOVIMENTACAO = M.CD_TIPO_MOVIMENTACAO" & _
                    " AND M.CD_FILIAL_MOVIMENTACAO = FIL.CD_FILIAL" & _
                    " AND CPM.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND CPM.SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue & _
                  " ORDER BY M.DT_MOVIMENTACAO,CPM.DT_FIXACAO DESC"

        objGrid_Carregar(grdConsultaNegociacao, SqlText, New Integer() {cnt_GridConsNegociacao_DataMovimentacao, _
                                                                        cnt_GridConsNegociacao_DataAplicacao, _
                                                                        cnt_GridConsNegociacao_QuantidadeAplicada, _
                                                                        cnt_GridConsNegociacao_ValorAplicado, _
                                                                        cnt_GridConsNegociacao_NF, _
                                                                        cnt_GridConsNegociacao_SerieNF, _
                                                                        cnt_GridConsNegociacao_ValorNF, _
                                                                        cnt_GridConsNegociacao_ValorNFICMS, _
                                                                        cnt_GridConsNegociacao_ValorINSSNF, _
                                                                        cnt_GridConsNegociacao_TipoMovimentacao, _
                                                                        cnt_GridConsNegociacao_QuantidadeContratoFixo, _
                                                                        cnt_GridConsNegociacao_ValorContratoFixo, _
                                                                        cnt_GridConsNegociacao_FilialMovimentacao, _
                                                                        cnt_GridConsNegociacao_SQ_MOVIMENTACAO, _
                                                                        cnt_GridConsNegociacao_CD_CONTRATO_PAF, _
                                                                        cnt_GridConsNegociacao_SQ_CTR_PAF_MOVIMENTACAO, _
                                                                        cnt_GridConsNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO, _
                                                                        cnt_GridConsNegociacao_QT_KG_MOVIMENTACAO, _
                                                                        cnt_GridConsNegociacao_VL_MOVIMENTACAO, _
                                                                        cnt_GridConsNegociacao_SQ_CTR_PAF_NEG_MOVIMENTACAO, _
                                                                        cnt_GridConsNegociacao_SQ_NEGOCIACAO}, False)

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdExcluir_Negociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir_Negociacao.Click
        If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ExcluirQuebrarAplicacaoNegociacaoFechada) Then
            If Not Verifica_Situacao_Contrato(objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_CD_CONTRATO_PAF), _
                                              objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_NEGOCIACAO), -1) Then Exit Sub
        End If

        Negociacao_Eliminar_Aplicacao()
    End Sub

    Private Sub cmdQuebrar_Negociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuebrar_Negociacao.Click
        If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ExcluirQuebrarAplicacaoNegociacaoFechada) Then
            If Not Verifica_Situacao_Contrato(objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_CD_CONTRATO_PAF), _
                                              objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_NEGOCIACAO), -1) Then Exit Sub
        End If

        Negociacao_Quebrar_Aplicacao()
    End Sub

    Private Sub cmdUsuario_Negociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario_Negociacao.Click
        If objGrid_LinhaSelecionada(grdConsultaNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "CTR_PAF_NEG_MOVIMENTACAO", _
                                       "SQ_MOVIMENTACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_MOVIMENTACAO) & " AND " & _
                                       "CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_CD_CONTRATO_PAF) & " AND " & _
                                       "SQ_CTR_PAF_MOVIMENTACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_CTR_PAF_MOVIMENTACAO) & " AND " & _
                                       "SQ_NEGOCIACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_NEGOCIACAO) & " AND " & _
                                       "SQ_CTR_PAF_NEG_MOVIMENTACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_CTR_PAF_NEG_MOVIMENTACAO) & " AND " & _
                                       "SQ_MOVIMENTACAO_CESSAO_DIREITO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO))
    End Sub

    Private Sub Negociacao_Eliminar_Aplicacao()
        If objGrid_LinhaSelecionada(grdConsultaNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim SqlText As String

        If (objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_ValorContratoFixo) <> _
            objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_ValorAplicado)) Or _
           (objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_QuantidadeContratoFixo) <> _
            objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_QuantidadeAplicada)) Then
            Msg_Mensagem("Favor eliminar primeiro as aplicações feitas no contrato fixo.")
            Exit Sub
        End If

        If Not Msg_Perguntar("Elimina a aplicação?") Then Exit Sub

        On Error GoTo Erro

        SqlText = "DELETE FROM SOF.CTR_PAF_NEG_MOVIMENTACAO" & _
                  " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_MOVIMENTACAO) & _
                    " AND SQ_MOVIMENTACAO_CESSAO_DIREITO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO) & _
                    " AND CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_CD_CONTRATO_PAF) & _
                    " AND SQ_CTR_PAF_MOVIMENTACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_CTR_PAF_MOVIMENTACAO) & _
                    " AND SQ_NEGOCIACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_NEGOCIACAO) & _
                    " AND SQ_CTR_PAF_NEG_MOVIMENTACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_CTR_PAF_NEG_MOVIMENTACAO)
        If Not DBExecutar(SqlText) Then GoTo Erro

        Pesquisar()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub Negociacao_Quebrar_Aplicacao()
        If objGrid_LinhaSelecionada(grdConsultaNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim SqlText As String

        If objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_ValorContratoFixo) = 0 And _
           objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_QuantidadeContratoFixo) = 0 Then
            Msg_Mensagem("A aplicação nao possue saldo em aberto para realizar a operação.")
            Exit Sub
        End If

        On Error GoTo Erro

        Dim oForm As New frmAplicacao_QuebrarValor

        oForm.Tipo_Aplicacao_Contrato = frmAplicacao_QuebrarValor.enTipo_Aplicacao_Contrato.tacREC
        oForm.ValorMaximo = objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_ValorContratoFixo)
        oForm.QuantidadeMaxima = objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_QuantidadeContratoFixo)
        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            SqlText = "UPDATE SOF.CTR_PAF_NEG_MOVIMENTACAO " & _
                      " SET VL_FIXO = VL_FIXO - " & oForm.ValorSolicitado & "," & _
                           "VL_A_FIXAR = VL_A_FIXAR - " & oForm.ValorSolicitado & "," & _
                           "QT_KG_FIXO = QT_KG_FIXO - " & oForm.QuantidadeSolicitada & "," & _
                           "QT_KG_A_FIXAR = QT_KG_A_FIXAR - " & oForm.QuantidadeSolicitada & _
                      " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_MOVIMENTACAO) & _
                        " AND SQ_MOVIMENTACAO_CESSAO_DIREITO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO) & _
                        " AND CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_CD_CONTRATO_PAF) & _
                        " AND SQ_CTR_PAF_MOVIMENTACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_CTR_PAF_MOVIMENTACAO) & _
                        " AND SQ_NEGOCIACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_NEGOCIACAO) & _
                        " AND SQ_CTR_PAF_NEG_MOVIMENTACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridConsNegociacao_SQ_CTR_PAF_NEG_MOVIMENTACAO)
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        oForm.Dispose()
        oForm = Nothing

        Pesquisar()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cboNegocicao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNegocicao.SelectedIndexChanged
        Negociacao_LimparTela()

        lblSaldoValorNegociacao.Visible = False
        txtSaldoValorNegociacao.Visible = False

        Negociacao_ValidaSaldo = False

        If Not ComboBox_LinhaSelecionada(cboNegocicao) Then Exit Sub

        On Error GoTo Erro

        Dim SqlText As String

        SqlText = "SELECT N.PC_ALIQ_ICMS" & _
                  " FROM SOF.NEGOCIACAO N" & _
                  " WHERE N.CD_CONTRATO_PAF =" & Pesq_ContratoPAF.Codigo & _
                    " AND N.SQ_NEGOCIACAO =" & cboNegocicao.SelectedValue
        PcICMS = DBQuery_ValorUnico(SqlText, 0)

        SqlText = DBMontar_SP("SOF.SP_VERIFICA_VALIDA_MOV_NEG", False, ":CDCTRPAF", _
                                                                       ":SQNEG", _
                                                                       ":ICVALIDAMOV", _
                                                                       ":QTKG", _
                                                                       ":VLNF", _
                                                                       ":CDLOCALENTREGA", _
                                                                       ":NOLOCALENTREGA", _
                                                                       ":ICCTRAFIXUNICO", _
                                                                       ":SQCTRAFIX")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", Pesq_ContratoPAF.Codigo), _
                                   DBParametro_Montar("SQNEG", cboNegocicao.SelectedValue), _
                                   DBParametro_Montar("ICVALIDAMOV", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("QTKG", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLNF", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("CDLOCALENTREGA", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("NOLOCALENTREGA", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("ICCTRAFIXUNICO", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQCTRAFIX", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        txtSaldoQuantidadeNegociacao.Value = DBRetorno(2)
        lblPostoNegociacao.Text = "Posto: " & DBRetorno(5)
        lblPostoNegociacao.Tag = DBRetorno(4)

        If DBRetorno(1) = "S" Then
            Negociacao_ValidaSaldo = True
            txtSaldoValorNegociacao.Value = Math.Round(CDbl(Val(DBRetorno(3))), 2)
            lblSaldoValorNegociacao.Visible = True
            txtSaldoValorNegociacao.Visible = True
        End If

        If DBRetorno(6) = "S" Then
            chkAplicarContratoFixo.Checked = True
            chkAplicarContratoFixo.Enabled = True
            Negociacao_SQ_CONTRATO_FIXO = DBRetorno(7)
        End If

        Pesquisar_Negociacao()

        SqlText = "SELECT SQ_CONTRATO_FIXO, CAST(SQ_CONTRATO_FIXO AS VARCHAR2(10)) FROM SOF.CONTRATO_FIXO " & _
                  "WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                   " AND SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue & _
                   " AND IC_STATUS NOT IN ('E')"
        DBCarregarComboBox(cboContratoFixo, SqlText, True)

        cboContratoFixo.Enabled = (cboContratoFixo.Items.Count > 0)

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub Negociacao_LimparTela()
        oDSCadNegociacao.Rows.Clear()
        oDSConsNegociacao.Rows.Clear()

        txtValorTotalAplicadoNegociacao.Value = 0
        txtQuantidadeTotalAplicadoNegociacao.Value = 0
        txtSaldoValorNegociacao.Value = 0
        txtSaldoQuantidadeNegociacao.Value = 0

        ContratoFixo_LimparTela()
        cboContratoFixo.Enabled = False

        lblPostoNegociacao.Text = "Posto: "
        lblPostoNegociacao.Tag = -1

        Negociacao_ValidaSaldo = False
        Negociacao_SQ_CONTRATO_FIXO = 0

        chkAplicarContratoFixo.Checked = False
        chkAplicarContratoFixo.Enabled = False
    End Sub

    Private Sub Pesquisar_Negociacao()
        Pesquisar_Negociacao_Consulta()
        Pesquisar_Negociacao_Cadastro()
    End Sub

    Private Sub ContratoFixo_LimparTela()
        cboContratoFixo.DataSource = Nothing
        cboContratoFixo.Enabled = False
        oDSConsContratoFixo.Rows.Clear()
        oDSCadContratoFixo.Rows.Clear()

        txtValorTotalAplicadoContratoFixo.Value = 0
        txtQuantidadeTotalAplicadoContratoFixo.Value = 0
        txtSaldoQuantidadeContratoFixo.Value = 0
        txtSaldoValorContratoFixo.Value = 0
    End Sub

    Private Sub Pesquisar_Negociacao_Cadastro()
        Dim SqlText As String
        Dim CD_FILIAL_ENTREGA As Integer

        If Pesq_ContratoPAF.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um Contrato PAF valido.")
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboNegocicao) Then Exit Sub

        SqlText = "SELECT CD_FILIAL_ENTREGA" & _
                  " FROM SOF.NEGOCIACAO" & _
                  " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue
        CD_FILIAL_ENTREGA = DBQuery_ValorUnico(SqlText)

        SqlText = "SELECT 0 SELECAO, 0 qt_fixa, 0 vl_fixa," & _
                         "CPM.QT_KG_A_FIXAR," & _
                         "CPM.VL_A_FIXAR," & _
                         "LE.NO_LOCAL_ENTREGA," & _
                         "M.DT_MOVIMENTACAO," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "M.NU_NF," & _
                         "M.NU_SERIE_NF," & _
                         "M.QT_KG_NF," & _
                         "M.QT_KG_LIQUIDO_NF," & _
                         "M.VL_NF," & _
                         "M.VL_NF_ICMS," & _
                         "M.VL_NF_FUNRURAL," & _
                         "CPM.SQ_MOVIMENTACAO," & _
                         "CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                         "CPM.SQ_CTR_PAF_MOVIMENTACAO" & _
                  " FROM SOF.MOVIMENTACAO M," & _
                        "SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                        "SOF.CTR_PAF_MOVIMENTACAO CPM," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.LOCAL_ENTREGA LE" & _
                  " WHERE M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                    " AND TM.CD_TIPO_MOVIMENTACAO = M.CD_TIPO_MOVIMENTACAO" & _
                    " AND MCD.SQ_MOVIMENTACAO = CPM.SQ_MOVIMENTACAO" & _
                    " AND MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO = CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                    " AND M.CD_LOCAL_ENTREGA = LE.CD_LOCAL_ENTREGA (+)" & _
                    " AND CPM.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND (CPM.QT_KG_A_FIXAR <> 0 OR CPM.VL_A_FIXAR <> 0)"

        If Not chkQualquerPosto.Checked Then
            SqlText = SqlText & " AND NVL(M.CD_LOCAL_ENTREGA, " & lblPostoNegociacao.Tag & ") = " & lblPostoNegociacao.Tag

            If Not chkQualquerFilial.Checked Then
                If Val(lblPostoNegociacao.Tag) <> cnt_LocalEntrega_Fabrica Then
                    SqlText = SqlText & " AND M.CD_FILIAL_MOVIMENTACAO = " & CD_FILIAL_ENTREGA
                End If
            End If
        Else
            Select Case CD_FILIAL_ENTREGA
                Case cnt_LocalEntrega_Fazenda
                    SqlText = SqlText & _
                              " AND NVL(M.CD_LOCAL_ENTREGA, " & cnt_LocalEntrega_Fazenda & ") IN (" & cnt_LocalEntrega_Fazenda & _
                                                                                                "," & cnt_LocalEntrega_Filial & _
                                                                                                "," & cnt_LocalEntrega_Fabrica & ")"
                    If Not chkQualquerFilial.Checked Then
                        SqlText = SqlText & _
                                  " AND DECODE(NVL(M.CD_LOCAL_ENTREGA, " & cnt_LocalEntrega_Fabrica & ")," & cnt_LocalEntrega_Fabrica & "," & _
                                                                                                             CD_FILIAL_ENTREGA & "," & _
                                              "M.CD_FILIAL_MOVIMENTACAO) = " & CD_FILIAL_ENTREGA
                    End If
                Case cnt_LocalEntrega_Filial
                    If Not Msg_Perguntar("Libera Posto Fazenda") Then
                        SqlText = SqlText & " AND NVL(M.CD_LOCAL_ENTREGA, " & cnt_LocalEntrega_Filial & ") IN (" & cnt_LocalEntrega_Filial & _
                                                                                                             "," & cnt_LocalEntrega_Fabrica & ")"
                    Else
                        SqlText = SqlText & " AND NVL(M.CD_LOCAL_ENTREGA, " & cnt_LocalEntrega_Fazenda & ") IN (" & cnt_LocalEntrega_Fazenda & _
                                                                                                              "," & cnt_LocalEntrega_Filial & _
                                                                                                              "," & cnt_LocalEntrega_Fabrica & ")"
                    End If

                    If Not chkQualquerFilial.Checked Then
                        SqlText = SqlText & _
                                  " AND DECODE(NVL(M.CD_LOCAL_ENTREGA, " & cnt_LocalEntrega_Fabrica & "), " & cnt_LocalEntrega_Fabrica & _
                                                                                                        "," & CD_FILIAL_ENTREGA & _
                                                                                                        ", M.CD_FILIAL_MOVIMENTACAO) = " & _
                                               CD_FILIAL_ENTREGA
                    End If
                Case cnt_LocalEntrega_Fabrica
                    If Not Msg_Perguntar("Libera Posto Fazenda e Filial?") Then
                        SqlText = SqlText & " AND NVL(M.CD_LOCAL_ENTREGA, " & cnt_LocalEntrega_Fabrica & ") = " & cnt_LocalEntrega_Fabrica
                    Else
                        SqlText = SqlText & " AND NVL(M.CD_LOCAL_ENTREGA, " & cnt_LocalEntrega_Fazenda & ") IN (" & cnt_LocalEntrega_Fazenda & _
                                                                                                              "," & cnt_LocalEntrega_Filial & _
                                                                                                              "," & cnt_LocalEntrega_Fabrica & ")"
                    End If

                    If Not chkQualquerFilial.Checked Then
                        SqlText = SqlText & _
                                  " AND DECODE(NVL(M.CD_LOCAL_ENTREGA, " & cnt_LocalEntrega_Fabrica & "), " & cnt_LocalEntrega_Fabrica & _
                                                                                                        "," & CD_FILIAL_ENTREGA & _
                                                                                                        ", M.CD_FILIAL_MOVIMENTACAO) = " & _
                                               CD_FILIAL_ENTREGA
                    End If
            End Select
        End If

        objGrid_Carregar(grdCadastraNegociacao, SqlText, New Integer() {cnt_GridCadNegociacao_Selecao, _
                                                                        cnt_GridCadNegociacao_QuantidadeAplicada, _
                                                                        cnt_GridCadNegociacao_ValorAplicado, _
                                                                        cnt_GridCadNegociacao_QuantidadeAplicar, _
                                                                        cnt_GridCadNegociacao_ValorAplicar, _
                                                                        cnt_GridCadNegociacao_Posto, _
                                                                        cnt_GridCadNegociacao_DataMovimentacao, _
                                                                        cnt_GridCadNegociacao_TipoMovimentacao, _
                                                                        cnt_GridCadNegociacao_NF, _
                                                                        cnt_GridCadNegociacao_SerieNF, _
                                                                        cnt_GridCadNegociacao_QtdeNF, _
                                                                        cnt_GridCadNegociacao_QtdeLiquidoNF, _
                                                                        cnt_GridCadNegociacao_ValorNF, _
                                                                        cnt_GridCadNegociacao_ValorICMS, _
                                                                        cnt_GridCadNegociacao_ValorINSS, _
                                                                        cnt_GridCadNegociacao_SQ_MOVIMENTACAO, _
                                                                        cnt_GridCadNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO, _
                                                                        cnt_GridCadNegociacao_SQ_CTR_PAF_MOVIMENTACAO}, False)

        Dim iCont As Integer
        If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ApricaCacauSemProporcionalidade) Then
            For iCont = 0 To grdCadastraNegociacao.Rows.Count - 1
                If grdCadastraNegociacao.Rows(iCont).Cells(cnt_GridCadContratoPAF_QuantLiquidoNF).Value <> 0 And _
                grdCadastraNegociacao.Rows(iCont).Cells(cnt_GridCadNegociacao_QuantidadeAplicar).Value = 0 Then
                    grdCadastraNegociacao.Rows(iCont).Cells(cnt_GridCadNegociacao_Selecao).Hidden = True
                End If
            Next
        End If
    End Sub

    Private Sub ContratoPAF_LimparTela()
        oDSCadContratoPAF.Rows.Clear()
        oDSConsNegociacao.Rows.Clear()
        txtQuantidadeTotalAplicadoContratoPAF.Value = 0
        txtValorTotalAplicadoContratoPAF.Value = 0
        txtSaldoQuantidadeContratoPAF.Value = 0

        cboNegocicao.Enabled = False
        Negociacao_LimparTela()
    End Sub

    Private Sub chkDesagioAcordado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDesagioAcordadoNegociacao.CheckedChanged
        DesagioAcordado_Negociacao()
    End Sub

    Private Sub DesagioAcordado_Negociacao()
        If chkDesagioAcordadoNegociacao.Checked Then
            lblDescricaoDesagioNegociacao.Enabled = True
            txtDescricaoDesagioNegociacao.Enabled = True
        Else
            lblDescricaoDesagioNegociacao.Enabled = False
            txtDescricaoDesagioNegociacao.Text = ""
            txtDescricaoDesagioNegociacao.Enabled = False
        End If
    End Sub

    Private Sub chkListarQualquerTipoPosto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkQualquerPosto.CheckedChanged
        If chkQualquerPosto.Checked Then
            chkQualquerFilial.Enabled = True
        Else
            chkQualquerFilial.Checked = False
            chkQualquerFilial.Enabled = False
        End If
    End Sub

    Private Sub chkAplicarContratoFixo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAplicarContratoFixo.CheckedChanged
        Dim HabilitarDesagio As Boolean = False

        chkDesagioAcordadoNegociacao.Enabled = False

        DesagioAcordado_Negociacao()

        If chkAplicarContratoFixo.Checked Then
            HabilitarDesagio = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AcordarDesagioAplicacaoRecebimentos)
        End If

        lblDescricaoDesagioNegociacao.Enabled = HabilitarDesagio
        txtDescricaoDesagioNegociacao.Enabled = HabilitarDesagio
        If Not HabilitarDesagio Then txtDescricaoDesagioNegociacao.Text = ""
    End Sub

    Private Sub cmdGravar_Negociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_Negociacao.Click
        Dim bAchou As Boolean = False
        Dim SqlText As String
        Dim iCont As Integer
        Dim SQCTRPAFNEGMOV As Integer

        For iCont = 0 To grdCadastraNegociacao.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraNegociacao, cnt_GridCadNegociacao_Selecao, iCont) Then
                bAchou = True

                If Val(objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_ValorAplicado, iCont)) > _
                   Val(objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_ValorAplicar, iCont)) Then
                    Msg_Mensagem("NF " & objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_NF, iCont) & _
                                 " está com valor aplicado a maior.")
                    Exit Sub
                End If
                If Val(objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_QuantidadeAplicada, iCont)) > _
                   Val(objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_QuantidadeAplicar, iCont)) Then
                    Msg_Mensagem("NF " & objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_NF, iCont) & _
                                 " está com quantidade aplicada a maior.")
                    Exit Sub
                End If
                If objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_ValorICMS, iCont) <> 0 Or PcICMS <> 0 Then
                    If Math.Abs(Val(objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_ValorICMS, iCont)) - Math.Round(objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_ValorNF, iCont) * FC_Round(PcICMS, 3) / 100, 2)) > 0.03 Then
                        Msg_Mensagem("Aliquota de ICMS do contrato diferente do da NF.")
                        Exit Sub
                    End If
                End If
            End If
        Next

        If Not bAchou Then
            Msg_Mensagem("Favor selecionar uma movimentação antes.")
            Exit Sub
        End If

        If Math.Round(txtSaldoQuantidadeNegociacao.Value, 2) < Math.Round(txtQuantidadeTotalAplicadoNegociacao.Value, 2) Then
            Msg_Mensagem("Quantidade aplicada não pode ser maior do que " & _
                         Format(txtSaldoQuantidadeNegociacao.Value, "#,##0"))
            Exit Sub
        End If

        If Negociacao_ValidaSaldo Then
            'Para evitar problemas quando o saldo é negativo e será feita uma aplicação positiva para corrigir o saldo
            If Math.Round(txtValorTotalAplicadoNegociacao.Value, 2) > Math.Abs(Math.Round(txtSaldoValorNegociacao.Value, 2)) Then
                Msg_Mensagem("Valor aplicado não pode ser maior do que " & Format(txtSaldoValorNegociacao.Value, "#,##0.00"))
                Exit Sub
            End If
        End If

        If chkDesagioAcordadoNegociacao.Checked Then
            If Trim(txtDescricaoDesagioNegociacao.Text) = "" Then
                Msg_Mensagem("Favor informar uma descrição para o Desagio.")
                Exit Sub
            End If
        End If

        On Error GoTo Erro

        Dim oAVI As frmAvi

        cmdGravar_Negociacao.Enabled = False
        oAVI = AVI_AbrirTela()

        DBUsarTransacao = True

        For iCont = 0 To grdCadastraNegociacao.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraNegociacao, cnt_GridCadNegociacao_Selecao, iCont) Then
                SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", _
                                                                              ":SQNEG", _
                                                                              ":SQCTRPAFMOV", _
                                                                              ":SQMOV", _
                                                                              ":SQMOVCD", _
                                                                              ":VLFIXO", _
                                                                              ":QTFIXO", _
                                                                              ":SQCTRPAFNEGMOV")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", Pesq_ContratoPAF.Codigo), _
                                           DBParametro_Montar("SQNEG", cboNegocicao.SelectedValue), _
                                           DBParametro_Montar("SQCTRPAFMOV", objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_SQ_CTR_PAF_MOVIMENTACAO, iCont)), _
                                           DBParametro_Montar("SQMOV", objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_SQ_MOVIMENTACAO, iCont)), _
                                           DBParametro_Montar("SQMOVCD", objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO, iCont)), _
                                           DBParametro_Montar("VLFIXO", objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_ValorAplicado, iCont)), _
                                           DBParametro_Montar("QTFIXO", objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_QuantidadeAplicada, iCont)), _
                                           DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                If chkAplicarContratoFixo.Checked Then
                    SQCTRPAFNEGMOV = DBRetorno(1)

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
                                               DBParametro_Montar("SQNEG", cboNegocicao.SelectedValue), _
                                               DBParametro_Montar("SQCTRPAFMOV", objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_SQ_CTR_PAF_MOVIMENTACAO, iCont)), _
                                               DBParametro_Montar("SQMOV", objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_SQ_MOVIMENTACAO, iCont)), _
                                               DBParametro_Montar("SQMOVCD", objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO, iCont)), _
                                               DBParametro_Montar("VLFIXO", objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_ValorAplicado, iCont)), _
                                               DBParametro_Montar("QTFIXO", objGrid_Valor(grdCadastraNegociacao, cnt_GridCadNegociacao_QuantidadeAplicada, iCont)), _
                                               DBParametro_Montar("SQCTRPAFNEGMOV", SQCTRPAFNEGMOV), _
                                               DBParametro_Montar("SQCTRFIX", Negociacao_SQ_CONTRATO_FIXO), _
                                               DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                                               DBParametro_Montar("ICGERACONCILIACAO", IIf(chkDesagioAcordadoNegociacao.Checked, "S", "N")), _
                                               DBParametro_Montar("DSCONCILIACAO", IIf(chkDesagioAcordadoNegociacao.Checked, Trim(txtDescricaoDesagioNegociacao.Text), Nothing))) Then GoTo Erro
                End If
            End If
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        cmdGravar_Negociacao.Enabled = True
        AVI_FechaTela(oAVI)

        Pesquisar()

        Exit Sub

Erro:
        cmdGravar_Negociacao.Enabled = True
        AVI_FechaTela(oAVI)

        TratarErro()
    End Sub

    Private Sub cboContratoFixo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContratoFixo.SelectedIndexChanged
        Dim oData As DataTable
        Dim SqlText As String

        txtSaldoValorContratoFixo.Value = 0
        txtSaldoQuantidadeContratoFixo.Value = 0

        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then
            Exit Sub
            ContratoFixo_LimparTela()
        End If

        SqlText = "SELECT ROUND((SOF.FC_SALDO_CTR_FIX(CF.CD_CONTRATO_PAF,CF.SQ_NEGOCIACAO, CF.SQ_CONTRATO_FIXO) - " & _
                           "CF.VL_NF_FIXO + DECODE(CF.IC_INCLUI_ICMS_PAG, 'N', CF.VL_NF_ICMS_FIXO,0) + CF.VL_NF_INSS_FIXO)" & _
                           "/ (1 - ((FUN.VL_TAXA + DECODE(CF.IC_INCLUI_ICMS_PAG,'N',CF.PC_ALIQ_ICMS,0))/100)), 2) AS VL_SALDO," & _
                         "(CF.QT_KGS - CF.QT_KG_FIXO - CF.QT_CANCELADO) AS QT_SALDO," & _
                         "CF.IC_INCLUI_ICMS_PAG " & _
                  " FROM SOF.CONTRATO_FIXO CF," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FUNRURAL FUN" & _
                  " WHERE CF.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                    " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND F.CD_FUNRURAL = FUN.CD_FUNRURAL" & _
                    " AND CF.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND CF.SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue & _
                    " AND CF.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            txtSaldoValorContratoFixo.Value = oData.Rows(0).Item("VL_SALDO")
            txtSaldoQuantidadeContratoFixo.Value = oData.Rows(0).Item("QT_SALDO")
            ContratoFixo_Inclui_ICMS_Pag = (oData.Rows(0).Item("IC_INCLUI_ICMS_PAG") = "S")

            oData.Dispose()
            oData = Nothing
        End If

        Pesquisar_ContratoFixo()
    End Sub

    Private Sub Pesquisar_ContratoFixo()
        Pesquisar_ContratoFixo_Cadastro()
        Pesquisar_ContratoFixo_Consulta()
    End Sub

    Private Sub Pesquisar_ContratoFixo_Cadastro()
        Dim SqlText As String

        If Pesq_ContratoPAF.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um Contrato PAF.")
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboNegocicao) Then Exit Sub
        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then Exit Sub

        SqlText = "SELECT 0 SELECAO, 0 QT_Fixar, 0 Vl_Fixar, " & _
                         "CPM.QT_KG_A_FIXAR," & _
                         "CPM.VL_A_FIXAR," & _
                         "M.DT_MOVIMENTACAO," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "M.NU_NF," & _
                         "M.NU_SERIE_NF," & _
                         "M.QT_KG_NF," & _
                         "M.QT_KG_LIQUIDO_NF," & _
                         "M.VL_NF," & _
                         "M.VL_NF_ICMS," & _
                         "M.VL_NF_FUNRURAL," & _
                         "CPM.SQ_MOVIMENTACAO," & _
                         "CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                         "CPM.SQ_CTR_PAF_MOVIMENTACAO," & _
                         "CPM.SQ_CTR_PAF_NEG_MOVIMENTACAO," & _
                         "M.IC_ICMS_PAGO" & _
                  " FROM SOF.MOVIMENTACAO M," & _
                        "SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                        "SOF.CTR_PAF_NEG_MOVIMENTACAO CPM," & _
                        "SOF.TIPO_MOVIMENTACAO TM" & _
                  " WHERE M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                    " AND TM.CD_TIPO_MOVIMENTACAO = M.CD_TIPO_MOVIMENTACAO" & _
                    " AND MCD.SQ_MOVIMENTACAO = CPM.SQ_MOVIMENTACAO" & _
                    " AND MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO = CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                    " AND CPM.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND CPM.SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue & _
                    " AND (CPM.QT_KG_A_FIXAR <> 0 OR CPM.VL_A_FIXAR <> 0)"

        objGrid_Carregar(grdCadastraContratoFixo, SqlText, New Integer() {cnt_GridCadContratoFixo_Selecao, _
                                                                          cnt_GridCadContratoFixo_QuantidadeAplicado, _
                                                                          cnt_GridCadContratoFixo_ValorAplicado, _
                                                                          cnt_GridCadContratoFixo_QuantidadeAplicar, _
                                                                          cnt_GridCadContratoFixo_ValorAplicar, _
                                                                          cnt_GridCadContratoFixo_DataMovimentacao, _
                                                                          cnt_GridCadContratoFixo_TipoMovimentacao, _
                                                                          cnt_GridCadContratoFixo_NF, _
                                                                          cnt_GridCadContratoFixo_SerieNF, _
                                                                          cnt_GridCadContratoFixo_QuantNF, _
                                                                          cnt_GridCadContratoFixo_QuantLiquidoNF, _
                                                                          cnt_GridCadContratoFixo_ValorNF, _
                                                                          cnt_GridCadContratoFixo_ValorICMS, _
                                                                          cnt_GridCadContratoFixo_ValorINSS, _
                                                                          cnt_GridCadContratoFixo_SQ_MOVIMENTACAO, _
                                                                          cnt_GridCadContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO, _
                                                                          cnt_GridCadContratoFixo_SQ_CTR_PAF_MOVIMENTACAO, _
                                                                          cnt_GridCadContratoFixo_SQ_CTR_PAF_NEG_MOVIMENTACAO, _
                                                                          cnt_GridCadContratoFixo_IC_ICMS_PAGO}, False)


        Dim iCont As Integer
        If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ApricaCacauSemProporcionalidade) Then
            For iCont = 0 To grdCadastraContratoPAF.Rows.Count - 1
                If grdCadastraContratoFixo.Rows(iCont).Cells(cnt_GridCadContratoFixo_QuantLiquidoNF).Value <> 0 And _
                grdCadastraContratoFixo.Rows(iCont).Cells(cnt_GridCadContratoFixo_QuantidadeAplicar).Value = 0 Then
                    grdCadastraContratoFixo.Rows(iCont).Cells(cnt_GridCadContratoFixo_Selecao).Hidden = True
                End If
            Next
        End If

        chkDesagioAcordadoContratoFixo.Checked = False
        DesagioAcordado_ContratoFixo()
    End Sub

    Private Sub chkDesagioAcordadoContratoFixo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDesagioAcordadoContratoFixo.CheckedChanged
        DesagioAcordado_ContratoFixo()
    End Sub

    Private Sub DesagioAcordado_ContratoFixo()
        If chkDesagioAcordadoContratoFixo.Checked Then
            lblDescricaoDesagioContratoFixo.Enabled = True
            txtDescricaoDesagioContratoFixo.Enabled = True
        Else
            lblDescricaoDesagioContratoFixo.Enabled = False
            txtDescricaoDesagioContratoFixo.Text = ""
            txtDescricaoDesagioContratoFixo.Enabled = False
        End If
    End Sub

    Private Sub cmdGravar_ContratoFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_ContratoFixo.Click
        Dim SqlText As String
        Dim bAchou As Boolean
        Dim iCont As Integer

        bAchou = False

        For iCont = 0 To grdCadastraContratoFixo.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraContratoFixo, cnt_GridCadContratoFixo_Selecao, iCont) Then
                bAchou = True

                If CDbl(objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoFixo_ValorAplicado, iCont)) > _
                   CDbl(objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoFixo_ValorAplicar, iCont)) Then
                    Msg_Mensagem("NF " & objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoFixo_NF, iCont) & _
                                 " está com valor aplicado a maior.")
                    Exit Sub
                End If
                If CDbl(objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoFixo_QuantidadeAplicado, iCont)) > _
                   CDbl(objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoFixo_QuantidadeAplicar, iCont)) Then
                    Msg_Mensagem("NF " & objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoFixo_NF, iCont) & _
                                 " está com quantidade aplicada a maior.")
                    Exit Sub
                End If
            End If
        Next

        If bAchou = False Then
            Msg_Mensagem("Favor selecionar uma movimentação antes.")
            Exit Sub
        End If

        If txtSaldoQuantidadeContratoFixo.Value < txtQuantidadeTotalAplicadoContratoFixo.Value Then
            Msg_Mensagem("Quantidade aplicada não pode ser maior do que " & Format(txtSaldoQuantidadeContratoFixo.Value, "#,##0"))
            Exit Sub
        End If
        If txtValorTotalAplicadoContratoFixo.Value > txtSaldoValorContratoFixo.Value Then
            Msg_Mensagem("Valor aplicado não pode ser maior do que " & Format(txtSaldoValorContratoFixo.Value, "#,##0.00"))
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then
            Msg_Mensagem("Favor selecionar um contrato fixo.")
            Exit Sub
        End If

        If chkDesagioAcordadoContratoFixo.Checked Then
            If Trim(txtDescricaoDesagioContratoFixo.Text) = "" Then
                Msg_Mensagem("Favor informar uma descrição.")
                Exit Sub
            End If
        End If

        On Error GoTo Erro

        Dim oAVI As frmAvi

        cmdGravar_ContratoFixo.Enabled = False
        oAVI = AVI_AbrirTela()

        DBUsarTransacao = True

        For iCont = 0 To grdCadastraContratoFixo.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraContratoFixo, cnt_GridCadContratoFixo_Selecao, iCont) Then
                SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", _
                                                                                   ":SQMOV", ":SQMOVCD", ":VLFIXO", _
                                                                                   ":QTFIXO", ":SQCTRPAFNEGMOV", _
                                                                                   ":SQCTRFIX", ":SQCTRPAFNEGCTRFIXMOV", _
                                                                                   ":ICGERACONCILIACAO", ":DSCONCILIACAO")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", Pesq_ContratoPAF.Codigo), _
                                           DBParametro_Montar("SQNEG", cboNegocicao.SelectedValue), _
                                           DBParametro_Montar("SQCTRPAFMOV", objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoFixo_SQ_CTR_PAF_MOVIMENTACAO, iCont)), _
                                           DBParametro_Montar("SQMOV", objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoFixo_SQ_MOVIMENTACAO, iCont)), _
                                           DBParametro_Montar("SQMOVCD", objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO, iCont)), _
                                           DBParametro_Montar("VLFIXO", CDbl(objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoFixo_ValorAplicado, iCont))), _
                                           DBParametro_Montar("QTFIXO", CDbl(objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoFixo_QuantidadeAplicado, iCont))), _
                                           DBParametro_Montar("SQCTRPAFNEGMOV", objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoFixo_SQ_CTR_PAF_NEG_MOVIMENTACAO, iCont)), _
                                           DBParametro_Montar("SQCTRFIX", cboContratoFixo.SelectedValue), _
                                           DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                                           DBParametro_Montar("ICGERACONCILIACAO", IIf(chkDesagioAcordadoContratoFixo.Checked, "S", "N")), _
                                           DBParametro_Montar("DSCONCILIACAO", Trim(txtDescricaoDesagioContratoFixo.Text))) Then GoTo Erro
            End If
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        cmdGravar_ContratoFixo.Enabled = True
        AVI_FechaTela(oAVI)

        Pesquisar()

        Exit Sub

Erro:
        cmdGravar_ContratoFixo.Enabled = True
        AVI_FechaTela(oAVI)
        TratarErro()
    End Sub

    Private Sub grdCadastraNegociacao_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraNegociacao.AfterCellUpdate
        If bProcInterno Then Exit Sub

        If e.Cell.Column.Index = cnt_GridCadNegociacao_ValorAplicado Or _
           e.Cell.Column.Index = cnt_GridCadNegociacao_QuantidadeAplicada Then
            bProcInterno = True

            With grdCadastraNegociacao.Rows(e.Cell.Row.Index)
                If NVL(.Cells(cnt_GridCadNegociacao_ValorAplicado).Value, 0) < 0 Or _
                   (NVL(.Cells(cnt_GridCadNegociacao_ValorAplicado).Value, 0) > .Cells(cnt_GridCadNegociacao_ValorAplicar).Value And _
                    NVL(.Cells(cnt_GridCadNegociacao_ValorAplicado).Value, 0) <> 0) Then
                    Msg_Mensagem("O Valor tem que estar entre 0 e " & Format(.Cells(cnt_GridCadNegociacao_ValorAplicar).Value, "#,##0.00"))
                    .Cells(cnt_GridCadNegociacao_ValorAplicado).Value = e.Cell.OriginalValue
                    GoTo Sair
                End If

                If NVL(.Cells(cnt_GridCadNegociacao_QuantidadeAplicada).Value, 0) < 0 Or _
                   (NVL(.Cells(cnt_GridCadNegociacao_QuantidadeAplicada).Value, 0) > .Cells(cnt_GridCadNegociacao_QuantidadeAplicar).Value And _
                    NVL(.Cells(cnt_GridCadNegociacao_QuantidadeAplicada).Value, 0) <> 0) Then
                    Msg_Mensagem("A quantidade tem que estar entre 0 e " & Format(.Cells(cnt_GridCadNegociacao_QuantidadeAplicar).Value, "#,##0.00"))
                    .Cells(cnt_GridCadNegociacao_QuantidadeAplicar).Value = e.Cell.OriginalValue
                    GoTo Sair
                End If

                If NVL(.Cells(cnt_GridCadNegociacao_ValorAplicado).Value, 0) = 0 And _
                   NVL(.Cells(cnt_GridCadNegociacao_QuantidadeAplicada).Value, 0) = 0 Then
                    .Cells(cnt_GridCadContratoPAF_Selecao).Value = 0
                Else
                    .Cells(cnt_GridCadContratoPAF_Selecao).Value = 1
                End If

                If e.Cell.Column.Index = cnt_GridCadNegociacao_QuantidadeAplicada Then
                    If NVL(.Cells(cnt_GridCadNegociacao_QtdeLiquidoNF).Value, 0) > 0 Then
                        .Cells(cnt_GridCadNegociacao_ValorAplicado).Value = Math.Round(NVL(.Cells(cnt_GridCadNegociacao_QuantidadeAplicada).Value, 0) * _
                                                                                          (.Cells(cnt_GridCadNegociacao_ValorAplicar).Value / _
                                                                                           .Cells(cnt_GridCadNegociacao_QuantidadeAplicar).Value), 2)
                    End If
                End If
            End With
        End If

        Calcula_Total_Aplicado_Negociacao()

Sair:
        bProcInterno = False
    End Sub

    Private Sub grdCadastraNegociacao_BeforeCellActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles grdCadastraNegociacao.BeforeCellActivate
        If e.Cell.Row.Cells(cnt_GridCadNegociacao_QtdeLiquidoNF).Value <> 0 And Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ApricaCacauSemProporcionalidade) Then
            e.Cancel = (e.Cell.Column.Index = cnt_GridCadNegociacao_ValorAplicado)
        End If

        If e.Cancel Then Exit Sub
    End Sub

    Private Sub grdCadastraNegociacao_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraNegociacao.CellChange
        If e.Cell.Column.Index = cnt_GridCadNegociacao_Selecao Then
            With grdCadastraNegociacao.Rows(e.Cell.Row.Index)
                bProcInterno = True
                If NVL(.Cells(cnt_GridCadNegociacao_Selecao).Value, 0) = 1 Then
                    .Cells(cnt_GridCadNegociacao_QuantidadeAplicada).Value = 0
                    .Cells(cnt_GridCadNegociacao_ValorAplicado).Value = 0
                    grdCadastraNegociacao.PerformAction(UltraGridAction.ExitEditMode)
                Else
                    .Cells(cnt_GridCadNegociacao_QuantidadeAplicada).Value = .Cells(cnt_GridCadNegociacao_QuantidadeAplicar).Value
                    .Cells(cnt_GridCadNegociacao_ValorAplicado).Value = .Cells(cnt_GridCadNegociacao_ValorAplicar).Value

                    .Cells(cnt_GridCadNegociacao_QuantidadeAplicada).Activate()
                    grdCadastraNegociacao.PerformAction(UltraGridAction.EnterEditMode)
                End If
                bProcInterno = False
            End With

            Calcula_Total_Aplicado_Negociacao()
        End If
    End Sub

    Private Sub grdCadastraContratoPAF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdCadastraContratoPAF.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdCadastraContratoPAF.PerformAction(UltraGridAction.ExitEditMode)
        End If
    End Sub

    Private Sub grdCadastraNegociacao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdCadastraNegociacao.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdCadastraNegociacao.PerformAction(UltraGridAction.ExitEditMode)
        End If
    End Sub

    Private Sub grdCadastraContratoFixo_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraContratoFixo.AfterCellUpdate
        If bProcInterno Then Exit Sub

        If e.Cell.Column.Index = cnt_GridCadContratoFixo_ValorAplicado Or _
           e.Cell.Column.Index = cnt_GridCadContratoFixo_QuantidadeAplicado Then
            bProcInterno = True

            With grdCadastraContratoFixo.Rows(e.Cell.Row.Index)
                If NVL(.Cells(cnt_GridCadContratoFixo_ValorAplicado).Value, 0) < 0 Or _
                   (NVL(.Cells(cnt_GridCadContratoFixo_ValorAplicado).Value, 0) > .Cells(cnt_GridCadContratoFixo_ValorAplicar).Value And _
                    NVL(.Cells(cnt_GridCadContratoFixo_ValorAplicado).Value, 0) <> 0) Then
                    Msg_Mensagem("O Valor tem que estar entre 0 e " & Format(.Cells(cnt_GridCadContratoFixo_ValorAplicar).Value, "#,##0.00"))
                    .Cells(cnt_GridCadNegociacao_ValorAplicado).Value = 0
                    GoTo Sair
                End If

                If NVL(.Cells(cnt_GridCadContratoFixo_QuantidadeAplicado).Value, 0) < 0 Or _
                   (NVL(.Cells(cnt_GridCadContratoFixo_QuantidadeAplicado).Value, 0) > .Cells(cnt_GridCadContratoFixo_QuantidadeAplicar).Value And _
                    NVL(.Cells(cnt_GridCadContratoFixo_QuantidadeAplicado).Value, 0) <> 0) Then
                    Msg_Mensagem("A quantidade tem que estar entre 0 e " & Format(.Cells(cnt_GridCadContratoFixo_QuantidadeAplicar).Value, "#,##0.00"))
                    .Cells(cnt_GridCadContratoFixo_QuantidadeAplicar).Value = 0
                    GoTo Sair
                End If

                If NVL(.Cells(cnt_GridCadContratoFixo_ValorAplicado).Value, 0) = 0 And _
                   NVL(.Cells(cnt_GridCadContratoFixo_QuantidadeAplicado).Value, 0) = 0 Then
                    .Cells(cnt_GridCadContratoFixo_Selecao).Value = 0
                Else
                    .Cells(cnt_GridCadContratoFixo_Selecao).Value = 1
                End If

                If e.Cell.Column.Index = cnt_GridCadContratoFixo_QuantidadeAplicado Then
                    .Cells(cnt_GridCadContratoFixo_ValorAplicado).Value = Math.Round(NVL(.Cells(cnt_GridCadContratoFixo_QuantidadeAplicado).Value, 0) * _
                                                                                        (.Cells(cnt_GridCadContratoFixo_ValorAplicar).Value / _
                                                                                         .Cells(cnt_GridCadContratoFixo_QuantidadeAplicar).Value), 2)
                End If
            End With
        End If

        Calcula_Total_Aplicado_ContratoFixo()

Sair:
        bProcInterno = False
    End Sub

    Private Sub grdCadastraContratoFixo_BeforeCellActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles grdCadastraContratoFixo.BeforeCellActivate
        If e.Cell.Row.Cells(cnt_GridCadContratoFixo_QuantLiquidoNF).Value <> 0 And Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ApricaCacauSemProporcionalidade) Then
            e.Cancel = (e.Cell.Column.Index = cnt_GridCadContratoPAF_ValorAplicado)
        End If

        If e.Cancel Then Exit Sub
    End Sub

    Private Sub grdCadastraContratoFixo_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraContratoFixo.CellChange
        If e.Cell.Column.Index = cnt_GridCadContratoFixo_Selecao Then
            With grdCadastraContratoFixo.Rows(e.Cell.Row.Index)
                bProcInterno = True
                If NVL(.Cells(cnt_GridCadContratoFixo_Selecao).Value, 0) = 1 Then
                    .Cells(cnt_GridCadContratoFixo_QuantidadeAplicado).Value = 0
                    .Cells(cnt_GridCadContratoFixo_ValorAplicado).Value = 0
                    grdCadastraContratoFixo.PerformAction(UltraGridAction.ExitEditMode)
                Else
                    .Cells(cnt_GridCadContratoFixo_QuantidadeAplicado).Value = .Cells(cnt_GridCadContratoFixo_QuantidadeAplicar).Value
                    .Cells(cnt_GridCadContratoFixo_ValorAplicado).Value = .Cells(cnt_GridCadContratoFixo_ValorAplicar).Value

                    .Cells(cnt_GridCadContratoFixo_QuantidadeAplicado).Activate()
                    grdCadastraContratoFixo.PerformAction(UltraGridAction.EnterEditMode)
                End If
                bProcInterno = False
            End With

            Calcula_Total_Aplicado_ContratoFixo()
        End If
    End Sub

    Private Sub grdCadastraContratoFixo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdCadastraContratoFixo.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdCadastraContratoFixo.PerformAction(UltraGridAction.ExitEditMode)
        End If
    End Sub

    Private Sub Pesquisar_ContratoFixo_Consulta()
        Dim oData As DataTable
        Dim SqlText As String

        txtSaldoValorContratoFixo.Value = 0
        txtSaldoQuantidadeContratoFixo.Value = 0

        If Pesq_ContratoPAF.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um Contrato PAF valido.")
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboNegocicao) Then Exit Sub
        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then Exit Sub

        SqlText = "SELECT (CF.QT_KGS - CF.QT_KG_FIXO - CF.QT_CANCELADO) AS QT_SALDO," & _
                         "ROUND((SOF.FC_SALDO_CTR_FIX(CF.CD_CONTRATO_PAF,CF.SQ_NEGOCIACAO ,CF.SQ_CONTRATO_FIXO )" & _
                                "- CF.VL_NF_FIXO + DECODE(CF.IC_INCLUI_ICMS_PAG,'N',CF.VL_NF_ICMS_FIXO,0) + CF.VL_NF_INSS_FIXO)" & _
                                "/ (1 - ((FUN.VL_TAXA + DECODE(CF.IC_INCLUI_ICMS_PAG,'N',CF.PC_ALIQ_ICMS,0))/100)), 2) AS VL_SALDO" & _
                  " FROM SOF.CONTRATO_FIXO CF," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FUNRURAL FUN" & _
                  " WHERE CF.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                    " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND F.CD_FUNRURAL = FUN.CD_FUNRURAL" & _
                    " AND CF.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND CF.SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue & _
                    " AND CF.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            txtSaldoQuantidadeContratoFixo.Value = oData.Rows(0).Item("QT_SALDO")
            txtSaldoValorContratoFixo.Value = oData.Rows(0).Item("VL_SALDO")

            oData.Dispose()
            oData = Nothing
        End If

        SqlText = "SELECT M.DT_MOVIMENTACAO," & _
                         "CPM.DT_FIXACAO," & _
                         "CPM.QT_KG_FIXO," & _
                         "CPM.VL_FIXO," & _
                         "M.NU_NF," & _
                         "M.NU_SERIE_NF," & _
                         "M.VL_NF," & _
                         "M.VL_NF_ICMS," & _
                         "M.VL_NF_FUNRURAL," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "FIL.NO_FILIAL," & _
                         "CPM.SQ_MOVIMENTACAO," & _
                         "CPM.CD_FILIAL_ORIGEM," & _
                         "CPM.CD_CONTRATO_PAF," & _
                         "CPM.SQ_CTR_PAF_MOVIMENTACAO," & _
                         "CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                         "MCD.QT_KG_MOVIMENTACAO," & _
                         "MCD.VL_MOVIMENTACAO," & _
                         "CPM.SQ_CTR_PAF_NEG_MOVIMENTACAO," & _
                         "CPM.SQ_NEGOCIACAO," & _
                         "CPM.SQ_CONTRATO_FIXO," & _
                         "CPM.SQ_CTR_PAF_NEG_CTR_FIX_MOV" & _
                  " FROM SOF.CTR_PAF_NEG_CTR_FIX_MOV CPM," & _
                        "SOF.MOVIMENTACAO M, " & _
                        "SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.FILIAL FIL" & _
                  " WHERE M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                    " AND MCD.SQ_MOVIMENTACAO = CPM.SQ_MOVIMENTACAO" & _
                    " AND MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO = CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                    " AND TM.CD_TIPO_MOVIMENTACAO = M.CD_TIPO_MOVIMENTACAO" & _
                    " AND M.CD_FILIAL_MOVIMENTACAO=FIL.CD_FILIAL" & _
                    " AND CPM.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND CPM.SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue & _
                    " AND CPM.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue & _
                  " ORDER BY M.DT_MOVIMENTACAO,CPM.DT_FIXACAO DESC"

        objGrid_Carregar(grdConsultaContratoFixo, SqlText, New Integer() {cnt_GridConsContratoFixo_DataMovimentacao, _
                                                                          cnt_GridConsContratoFixo_DataAplicacao, _
                                                                          cnt_GridConsContratoFixo_QuantidadeAplicada, _
                                                                          cnt_GridConsContratoFixo_ValorAplicado, _
                                                                          cnt_GridConsContratoFixo_NF, _
                                                                          cnt_GridConsContratoFixo_SerieNF, _
                                                                          cnt_GridConsContratoFixo_ValorNF, _
                                                                          cnt_GridConsContratoFixo_ValorICMS_NF, _
                                                                          cnt_GridConsContratoFixo_ValorINSS_NF, _
                                                                          cnt_GridConsContratoFixo_TipoMovimentacao, _
                                                                          cnt_GridConsContratoFixo_FilialMovimentacao, _
                                                                          cnt_GridConsContratoFixo_SQ_MOVIMENTACAO, _
                                                                          cnt_GridConsContratoFixo_CD_FILIAL_ORIGEM, _
                                                                          cnt_GridConsContratoFixo_CD_CONTRATO_PAF, _
                                                                          cnt_GridConsContratoFixo_SQ_CTR_PAF_MOVIMENTACAO, _
                                                                          cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO, _
                                                                          cnt_GridConsContratoFixo_QT_KG_MOVIMENTACAO, _
                                                                          cnt_GridConsContratoFixo_VL_MOVIMENTACAO, _
                                                                          cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_MOVIMENTACAO, _
                                                                          cnt_GridConsContratoFixo_SQ_NEGOCIACAO, _
                                                                          cnt_GridConsContratoFixo_SQ_CONTRATO_FIXO, _
                                                                          cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_CTR_FIX_MOV}, False)
    End Sub

    Private Sub cmdExcluir_ContratoFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir_ContratoFixo.Click
        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then Exit Sub

        If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ExcluirQuebrarAplicacaoContratoFixoFechado) Then
            If Not Verifica_Situacao_Contrato(Pesq_ContratoPAF.Codigo, cboNegocicao.SelectedValue, cboContratoFixo.SelectedValue) Then Exit Sub
        End If

        ContratoFixo_Eliminar_Aplicacao()
    End Sub

    Private Sub cmdQuebrar_ContratoFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuebrar_ContratoFixo.Click
        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then Exit Sub

        If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ExcluirQuebrarAplicacaoContratoFixoFechado) Then
            If Not Verifica_Situacao_Contrato(Pesq_ContratoPAF.Codigo, cboNegocicao.SelectedValue, cboContratoFixo.SelectedValue) Then Exit Sub
        End If

        ContratoFixo_Quebrar_Aplicacao()
    End Sub

    Private Sub ContratoFixo_Eliminar_Aplicacao()
        If objGrid_LinhaSelecionada(grdConsultaContratoFixo) = -1 Then
            Msg_Mensagem("Selecione um registro")
            Exit Sub
        End If

        Dim SqlText As String

        If CDate(objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_DataAplicacao)) <> CDate(DataSistema()) Then
            If Msg_Perguntar("Esta aplicação foi realizada em um dia anterior ao dia atual," & _
                             "por isso não é possível realizar a eliminação da mesma. " & _
                             "Deseja fazer o estorno dessa aplicação?") Then

                If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ExcluirQuebrarAplicacaoContratoFixoFechado) Then
                    If Not Verifica_Situacao_Contrato(Pesq_ContratoPAF.Codigo, cboNegocicao.SelectedValue, cboContratoFixo.SelectedValue) Then Exit Sub
                End If

                ContratoFixo_Estorno_Fixacao()
            End If

            Exit Sub
        End If

        If Val(objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_QuantidadeAplicada)) < 0 Or _
           Val(objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_ValorAplicado)) < 0 Then
            Msg_Mensagem("Não é possivel desaplicar um estorno.")
            Exit Sub
        End If

        If Not Msg_Perguntar("Elimina a aplicação?") Then Exit Sub

        On Error GoTo Erro

        SqlText = DBMontar_SP("SOF.SP_ELIMINA_CTRPAF_NEG_CTRFIX_M", False, ":SQMOV", _
                                                                           ":SQMOVCD", _
                                                                           ":CDCTRPAF", _
                                                                           ":SQCTRPAFMOV", _
                                                                           ":SQNEG", _
                                                                           ":SQCTRPAFNEGMOV", _
                                                                           ":SQCTRFIX", _
                                                                           ":SQCTRPAFNEGCTRFIXMOV")

        If Not DBExecutar(SqlText, _
                          DBParametro_Montar("SQMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO)), _
                          DBParametro_Montar("SQMOVCD", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO)), _
                          DBParametro_Montar("CDCTRPAF", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_CD_CONTRATO_PAF)), _
                          DBParametro_Montar("SQCTRPAFMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_MOVIMENTACAO)), _
                          DBParametro_Montar("SQNEG", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_NEGOCIACAO)), _
                          DBParametro_Montar("SQCTRPAFNEGMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_MOVIMENTACAO)), _
                          DBParametro_Montar("SQCTRFIX", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CONTRATO_FIXO)), _
                          DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_CTR_FIX_MOV))) Then GoTo Erro

        Pesquisar_ContratoFixo()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub ContratoFixo_Quebrar_Aplicacao()
        If objGrid_LinhaSelecionada(grdConsultaContratoFixo) = -1 Then
            Msg_Mensagem("Selecione um registro")
            Exit Sub
        End If

        Dim SqlText As String
        Dim SQ_CONTRATOPAF_MOVIMENTACAO As Long
        Dim SQ_NEGOCIACAO_MOVIMENTACAO As Long

        If Val(objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_QuantidadeAplicada)) < 0 Or _
           Val(objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_ValorAplicado)) < 0 Then
            Msg_Mensagem("Não é possível quebra aplicação com saldo negativo.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) AS QT" & _
                  " FROM SOF.CTRPAF_NEG_CTRFIX_MOV_DQ" & _
                  " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO) & _
                    " AND SQ_MOVIMENTACAO_CESSAO_DIREITO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO) & _
                    " AND CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_CD_CONTRATO_PAF) & _
                    " AND SQ_CTR_PAF_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_MOVIMENTACAO) & _
                    " AND SQ_NEGOCIACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_NEGOCIACAO) & _
                    " AND SQ_CTR_PAF_NEG_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_MOVIMENTACAO) & _
                    " AND SQ_CONTRATO_FIXO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CONTRATO_FIXO) & _
                    " AND SQ_CTR_PAF_NEG_CTR_FIX_MOV = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_CTR_FIX_MOV)

        If DBQuery_ValorUnico(SqlText) > 0 Then
            Msg_Mensagem("Essa aplicação gerou desagio automático e não poderá realizar essa operação.")
            Exit Sub
        End If

        Dim oForm As New frmAplicacaoContratoFixo_AlterarAplicacao

        oForm.Quantidade_Maxima = Val(objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_QuantidadeAplicada))
        oForm.Valor_Maximo = Val(objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_ValorAplicado))
        oForm.Fornecedor = Cod_Fornecedor

        Form_Show(Nothing, oForm, True)

        If Not oForm.Cancelado Then
            DBUsarTransacao = True

            SqlText = DBMontar_SP("SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", ":SQMOV", ":SQMOVCD", _
                                                                  ":VLFIXO", ":QTFIXO", ":SQCTRPAFMOV")

            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", Pesq_ContratoPAF.Codigo), _
                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO)), _
                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO)), _
                                       DBParametro_Montar("VLFIXO", 0 - oForm.Valor_Solicitado), _
                                       DBParametro_Montar("QTFIXO", 0 - oForm.Quantidade_Solicitada), _
                                       DBParametro_Montar("QTFIXO", Nothing, , ParameterDirection.Output)) Then GoTo Erro

            SQ_CONTRATOPAF_MOVIMENTACAO = Val(DBRetorno(1))

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", _
                                                                          ":SQMOV", ":SQMOVCD", ":VLFIXO", ":QTFIXO", _
                                                                          ":SQCTRPAFNEGMOV")

            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", Pesq_ContratoPAF.Codigo), _
                                       DBParametro_Montar("SQNEG", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_NEGOCIACAO)), _
                                       DBParametro_Montar("SQCTRPAFMOV", SQ_CONTRATOPAF_MOVIMENTACAO), _
                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO)), _
                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO)), _
                                       DBParametro_Montar("VLFIXO", 0 - oForm.Valor_Solicitado), _
                                       DBParametro_Montar("QTFIXO", 0 - oForm.Quantidade_Solicitada), _
                                       DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

            SQ_NEGOCIACAO_MOVIMENTACAO = Val(DBRetorno(1))

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", _
                                                                               ":SQMOV", ":SQMOVCD", ":VLFIXO", _
                                                                               ":QTFIXO", ":SQCTRPAFNEGMOV", ":SQCTRFIX", _
                                                                               ":SQCTRPAFNEGCTRFIXMOV", ":SQCTRPAFNEGCTRFIXMOV", _
                                                                               ":ICGERACONCILIACAO", ":DSCONCILIACAO")

            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", Pesq_ContratoPAF.Codigo), _
                                       DBParametro_Montar("SQNEG", cboNegocicao.SelectedValue), _
                                       DBParametro_Montar("SQCTRPAFMOV", SQ_CONTRATOPAF_MOVIMENTACAO), _
                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO)), _
                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO)), _
                                       DBParametro_Montar("VLFIXO", 0 - oForm.Valor_Solicitado), _
                                       DBParametro_Montar("QTFIXO", 0 - oForm.Quantidade_Solicitada), _
                                       DBParametro_Montar("SQCTRPAFNEGMOV", SQ_NEGOCIACAO_MOVIMENTACAO), _
                                       DBParametro_Montar("SQCTRFIX", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CONTRATO_FIXO)), _
                                       DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_CTR_FIX_MOV)), _
                                       DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                                       DBParametro_Montar("DSCONCILIACAO", Nothing)) Then GoTo Erro

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", ":SQMOV", ":SQMOVCD", _
                                                                      ":VLFIXO", ":QTFIXO", ":SQCTRPAFMOV")

            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oForm.ContratoPAF), _
                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO)), _
                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO)), _
                                       DBParametro_Montar("VLFIXO", oForm.Valor_Solicitado), _
                                       DBParametro_Montar("QTFIXO", oForm.Quantidade_Solicitada), _
                                       DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

            SQ_CONTRATOPAF_MOVIMENTACAO = DBRetorno(1)

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", ":SQMOV", _
                                                                          ":SQMOVCD", ":VLFIXO", ":QTFIXO", ":SQCTRPAFNEGMOV")

            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oForm.ContratoPAF), _
                                       DBParametro_Montar("SQNEG", oForm.Negociacao), _
                                       DBParametro_Montar("SQCTRPAFMOV", SQ_CONTRATOPAF_MOVIMENTACAO), _
                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO)), _
                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO)), _
                                       DBParametro_Montar("VLFIXO", oForm.Valor_Solicitado), _
                                       DBParametro_Montar("QTFIXO", oForm.Quantidade_Solicitada), _
                                       DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

            SQ_NEGOCIACAO_MOVIMENTACAO = Val(DBRetorno(1))

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", ":SQMOV", _
                                                                               ":SQMOVCD", ":VLFIXO", ":QTFIXO", ":SQCTRPAFNEGMOV", _
                                                                               ":SQCTRFIX", ":SQCTRPAFNEGCTRFIXMOV", _
                                                                               ":ICGERACONCILIACAO", ":DSCONCILIACAO")

            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oForm.ContratoPAF), _
                                       DBParametro_Montar("SQNEG", oForm.Negociacao), _
                                       DBParametro_Montar("SQCTRPAFMOV", SQ_CONTRATOPAF_MOVIMENTACAO), _
                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO)), _
                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO)), _
                                       DBParametro_Montar("VLFIXO", oForm.Valor_Solicitado), _
                                       DBParametro_Montar("QTFIXO", oForm.Quantidade_Solicitada), _
                                       DBParametro_Montar("SQCTRPAFNEGMOV", SQ_NEGOCIACAO_MOVIMENTACAO), _
                                       DBParametro_Montar("SQCTRFIX", oForm.ContratoFixo), _
                                       DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                                       DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                                       DBParametro_Montar("DSCONCILIACAO", Nothing)) Then GoTo Erro
        End If

        oForm.Dispose()
        oForm = Nothing

        If Not DBExecutarTransacao() Then GoTo Erro

        Pesquisar_ContratoFixo()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub ContratoFixo_Estorno_Fixacao()
        If objGrid_LinhaSelecionada(grdConsultaContratoFixo) = -1 Then
            Msg_Mensagem("Selecione um contrato fixo")
            Exit Sub
        End If

        Dim SqlText As String
        Dim SQ_CONTRATOPAF_MOVIMENTACAO As Long
        Dim SQ_NEGOCIACAO_MOVIMENTACAO As Long

        If Val(objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_QuantidadeAplicada)) < 0 Or _
           Val(objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_ValorAplicado)) < 0 Then
            Msg_Mensagem("Não é possivel estornar aplicação com saldo negativo.")
            Exit Sub
        End If

        If CDate(objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_DataAplicacao)) = CDate(DataSistema()) Then
            Msg_Mensagem("Aplicaçao realizado hoje, em vez de estorno deve ser feita a desaplicação.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) AS QT" & _
                  " FROM SOF.CTRPAF_NEG_CTRFIX_MOV_DQ" & _
                  " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO) & _
                    " AND SQ_MOVIMENTACAO_CESSAO_DIREITO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO) & _
                    " AND CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_CD_CONTRATO_PAF) & _
                    " AND SQ_CTR_PAF_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_MOVIMENTACAO) & _
                    " AND SQ_NEGOCIACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_NEGOCIACAO) & _
                    " AND SQ_CTR_PAF_NEG_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_MOVIMENTACAO) & _
                    " AND SQ_CONTRATO_FIXO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CONTRATO_FIXO) & _
                    " AND SQ_CTR_PAF_NEG_CTR_FIX_MOV = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_CTR_FIX_MOV)
        If DBQuery_ValorUnico(SqlText) > 0 Then
            Msg_Mensagem("Essa aplicação gerou desagio automatico e não podera realizar essa operação.")
            Exit Sub
        End If

        SqlText = "SELECT sum(vl_fixo) AS vl, sum(qt_KG_fixo) AS QT" & _
          " FROM SOF.ctr_paf_neg_ctr_fix_mov " & _
          " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO) & _
            " AND CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_CD_CONTRATO_PAF) & _
            " AND SQ_NEGOCIACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_NEGOCIACAO) & _
            " AND SQ_CONTRATO_FIXO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CONTRATO_FIXO)

        Dim oData As DataTable
        odata = DBQuery(SqlText)
        Dim oForm As New frmAplicacao_QuebrarValor
        oForm.QuantidadeMaxima = oData.Rows(0).Item("QT")
        oForm.ValorMaximo = oData.Rows(0).Item("vl")

        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            DBUsarTransacao = True

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", ":SQMOV", ":SQMOVCD", _
                                                                      ":VLFIXO", ":QTFIXO", ":SQCTRPAFMOV")

            If Not DBExecutar(SqlText, _
                              DBParametro_Montar("CDCTRPAF", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_CD_CONTRATO_PAF)), _
                              DBParametro_Montar("SQMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO)), _
                              DBParametro_Montar("SQMOVCD", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO)), _
                              DBParametro_Montar("VLFIXO", 0 - oForm.ValorSolicitado), _
                              DBParametro_Montar("QTFIXO", 0 - oForm.QuantidadeSolicitada), _
                              DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

            SQ_CONTRATOPAF_MOVIMENTACAO = DBRetorno(1)

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", _
                                                                          ":SQMOV", ":SQMOVCD", ":VLFIXO", _
                                                                          ":QTFIXO", ":SQCTRPAFNEGMOV")

            If Not DBExecutar(SqlText, _
                              DBParametro_Montar("CDCTRPAF", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_CD_CONTRATO_PAF)), _
                              DBParametro_Montar("SQNEG", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_NEGOCIACAO)), _
                              DBParametro_Montar("SQCTRPAFMOV", SQ_CONTRATOPAF_MOVIMENTACAO), _
                              DBParametro_Montar("SQMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO)), _
                              DBParametro_Montar("SQMOVCD", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO)), _
                              DBParametro_Montar("VLFIXO", 0 - oForm.ValorSolicitado), _
                              DBParametro_Montar("QTFIXO", 0 - oForm.QuantidadeSolicitada), _
                              DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

            SQ_NEGOCIACAO_MOVIMENTACAO = DBRetorno(1)

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", ":SQMOV", _
                                                                               ":SQMOVCD", ":VLFIXO", ":QTFIXO", ":SQCTRPAFNEGMOV", _
                                                                               ":SQCTRFIX", ":SQCTRPAFNEGCTRFIXMOV", _
                                                                               ":ICGERACONCILIACAO", ":DSCONCILIACAO")

            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", Pesq_ContratoPAF.Codigo), _
                                       DBParametro_Montar("SQNEG", cboNegocicao.SelectedValue), _
                                       DBParametro_Montar("SQCTRPAFMOV", SQ_CONTRATOPAF_MOVIMENTACAO), _
                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO)), _
                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO)), _
                                       DBParametro_Montar("VLFIXO", 0 - oForm.ValorSolicitado), _
                                       DBParametro_Montar("QTFIXO", 0 - oForm.QuantidadeSolicitada), _
                                       DBParametro_Montar("SQCTRPAFNEGMOV", SQ_NEGOCIACAO_MOVIMENTACAO), _
                                       DBParametro_Montar("SQCTRFIX", objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CONTRATO_FIXO)), _
                                       DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                                       DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                                       DBParametro_Montar("DSCONCILIACAO", Nothing, , ParameterDirection.Output)) Then GoTo Erro

            If Not DBExecutarTransacao() Then GoTo Erro
        End If

        oForm.Dispose()
        oForm = Nothing

        Pesquisar_ContratoFixo()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub tbsGeral_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tbsGeral.SelectedTabChanged
        If bTelaCarregada Then Pesquisar()
    End Sub

    Private Sub cmdUsuario_ContratoFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario_ContratoFixo.Click
        If objGrid_LinhaSelecionada(grdConsultaContratoPAF) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "CTR_PAF_NEG_CTR_FIX_MOV", "SQ_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO) _
                                                           & " AND CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_CD_CONTRATO_PAF) _
                                                           & " AND SQ_CTR_PAF_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_MOVIMENTACAO) _
                                                           & " AND SQ_NEGOCIACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_NEGOCIACAO) _
                                                           & " AND SQ_CTR_PAF_NEG_MOVIMENTACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_MOVIMENTACAO) _
                                                           & " AND SQ_CONTRATO_FIXO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CONTRATO_FIXO) _
                                                           & " AND SQ_CTR_PAF_NEG_CTR_FIX_MOV = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_CTR_PAF_NEG_CTR_FIX_MOV) _
                                                           & " AND SQ_MOVIMENTACAO_CESSAO_DIREITO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridConsContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO))
    End Sub

    Private Sub cmdSelecionarTodos_ContratoPAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarTodos_ContratoPAF.Click
        Dim iCont As Integer

        For iCont = 0 To grdCadastraContratoPAF.Rows.Count - 1
            grdCadastraContratoPAF.Rows(iCont).Cells(cnt_GridCadContratoPAF_Selecao).Value = True
        Next
    End Sub

    Private Sub cmdSelecionarTodos_Negociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarTodos_Negociacao.Click
        Dim iCont As Integer

        For iCont = 0 To grdCadastraNegociacao.Rows.Count - 1
            grdCadastraNegociacao.Rows(iCont).Cells(cnt_GridCadNegociacao_Selecao).Value = True
        Next
    End Sub

    Private Sub cmdSelecionarTodos_ContratoFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarTodos_ContratoFixo.Click
        Dim iCont As Integer

        For iCont = 0 To grdCadastraContratoFixo.Rows.Count - 1
            grdCadastraContratoFixo.Rows(iCont).Cells(cnt_GridCadContratoFixo_Selecao).Value = True
        Next
    End Sub
End Class