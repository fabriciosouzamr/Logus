Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroListagemGeral
    Inherits System.Windows.Forms.Form

    Const cnt_GridUF_Codigo As Integer = 0
    Const cnt_GridUF_Nome As Integer = 1
    Const cnt_GridUF_Aliq_ICMS As Integer = 2
    Const cnt_GridUF_Aliq_Obrigacao_Acessorio As Integer = 3

    Const cnt_GridFunrural_Codigo As Integer = 0
    Const cnt_GridFunrural_Nome As Integer = 1
    Const cnt_GridFunrural_Taxa As Integer = 2

    Const cnt_GridMunicipio_Codigo As Integer = 0
    Const cnt_GridMunicipio_Nome As Integer = 1
    Const cnt_GridMunicipio_UF As Integer = 2

    Const cnt_GridTipoPessoa_Codigo As Integer = 0
    Const cnt_GridTipoPessoa_Nome As Integer = 1
    Const cnt_GridTipoPessoa_MostraPrecoBolsa As Integer = 2
    Const cnt_GridTipoPessoa_percentualPrecoBolsa As Integer = 3

    Const cnt_GridTipoPessoaTributacao_Codigo As Integer = 0
    Const cnt_GridTipoPessoaTributacao_Nome As Integer = 1

    Const cnt_GridEstadoCivil_Codigo As Integer = 0
    Const cnt_GridEstadoCivil_Nome As Integer = 1

    Const cnt_GridTipoCapital_Codigo As Integer = 0
    Const cnt_GridTipoCapital_Nome As Integer = 1

    Const cnt_GridTipoNF_Codigo As Integer = 0
    Const cnt_GridTipoNF_Nome As Integer = 1
    Const cnt_GridTipoNF_MunicipioFiscal As Integer = 2

    Const cnt_GridAnalise_Codigo As Integer = 0
    Const cnt_GridAnalise_Nome As Integer = 1

    Const cnt_GridLocalEntrega_Codigo As Integer = 0
    Const cnt_GridLocalEntrega_Nome As Integer = 1
    Const cnt_GridLocalEntrega_Ativo As Integer = 2

    Const cnt_GridOrigem_Codigo As Integer = 0
    Const cnt_GridOrigem_Nome As Integer = 1

    Const cnt_GridTipoFrete_Codigo As Integer = 0
    Const cnt_GridTipoFrete_Nome As Integer = 1

    Const cnt_GridTipoFretista_Codigo As Integer = 0
    Const cnt_GridTipoFretista_Nome As Integer = 1

    Const cnt_GridTipoAdendo_Codigo As Integer = 0
    Const cnt_GridTipoAdendo_Nome As Integer = 1

    Const cnt_GridTipoCacau_Codigo As Integer = 0
    Const cnt_GridTipoCacau_Nome As Integer = 1

    Const cnt_GridTipoGarantia_Codigo As Integer = 0
    Const cnt_GridTipoGarantia_Descricao As Integer = 1
    Const cnt_GridTipoGarantia_ValorLimite As Integer = 2
    Const cnt_GridTipoGarantia_IcDescricao As Integer = 3
    Const cnt_GridTipoGarantia_IcProvisoria As Integer = 4
    Const cnt_GridTipoGarantia_IcGarantido As Integer = 5
    Const cnt_GridTipoGarantia_IcPrazo As Integer = 6
    Const cnt_GridTipoGarantia_QtDias As Integer = 7

    Const cnt_GridProcedencia_Codigo As Integer = 0
    Const cnt_GridProcedencia_Nome As Integer = 1
    Const cnt_GridProcedencia_Origem As Integer = 2

    Const cnt_GridTipoInovacao_Codigo As Integer = 0
    Const cnt_GridTipoInovacao_Nome As Integer = 1

    Const cnt_GridTipoAprovador_Codigo As Integer = 0
    Const cnt_GridTipoAprovador_Nome As Integer = 1
    Const cnt_GridTipoAprovador_PossuiLimite As Integer = 2
    Const cnt_GridTipoAprovador_Obrigatorio As Integer = 3
    Const cnt_GridTipoAprovador_LiberaNegociacao As Integer = 4

    Const cnt_GridTipoDescontoQualidade_Codigo As Integer = 0
    Const cnt_GridTipoDescontoQualidade_Nome As Integer = 1
    Const cnt_GridTipoDescontoQualidade_CampoQualidade As Integer = 2
    Const cnt_GridTipoDescontoQualidade_MaximoPermitido As Integer = 3
    Const cnt_GridTipoDescontoQualidade_TipoPagamento As Integer = 4
    Const cnt_GridTipoDescontoQualidade_Ativo As Integer = 5

    Const cnt_GridTipoAcondicionamento_Codigo As Integer = 0
    Const cnt_GridTipoAcondicionamento_Nome As Integer = 1
    Const cnt_GridTipoAcondicionamento_TextoContrato As Integer = 2

    Const cnt_GridSafra_Codigo As Integer = 0
    Const cnt_GridSafra_Nome As Integer = 1
    Const cnt_GridSafra_Valido As Integer = 2

    Const cnt_GridTipoSacaria_Codigo As Integer = 0
    Const cnt_GridTipoSacaria_Nome As Integer = 1
    Const cnt_GridTipoSacaria_Peso As Integer = 2
    Const cnt_GridTipoSacaria_Preco As Integer = 3
    Const cnt_GridTipoSacaria_ContabilizaFornecedor As Integer = 4
    Const cnt_GridTipoSacaria_Ativo As Integer = 5
 
    Const cnt_GridProvisao_Codigo As Integer = 0
    Const cnt_GridProvisao_Nome As Integer = 1
    Const cnt_GridProvisao_ContaContabil As Integer = 2
    Const cnt_GridProvisao_CalculaSubAliquota As Integer = 3

    Const cnt_GridArmazem_Codigo As Integer = 0
    Const cnt_GridArmazem_Nome As Integer = 1
    Const cnt_GridArmazem_Filial As Integer = 2
    Const cnt_GridArmazem_Ativo As Integer = 3

    Const cnt_GridModalidadeRecuperacaoCredito_Codigo As Integer = 0
    Const cnt_GridModalidadeRecuperacaoCredito_Nome As Integer = 1
    Const cnt_GridModalidadeRecuperacaoCredito_FormaPagamento As Integer = 2
    Const cnt_GridModalidadeRecuperacaoCredito_TipoPagamento As Integer = 3
    Const cnt_GridModalidadeRecuperacaoCredito_ModalidadeConciliacao As Integer = 4

    Const cnt_GridTipoContratoPAF_Codigo As Integer = 0
    Const cnt_GridTipoContratoPAF_Nome As Integer = 1
    Const cnt_GridTipoContratoPAF_Adiantamento As Integer = 2
    Const cnt_GridTipoContratoPAF_TextoContrato As Integer = 3

    Const cnt_GridTipoContato_Codigo As Integer = 0
    Const cnt_GridTipoContato_Nome As Integer = 1

    Const cnt_GridFormaPagamento_Codigo As Integer = 0
    Const cnt_GridFormaPagamento_Nome As Integer = 1
    Const cnt_GridFormaPagamento_ContaDebito As Integer = 2
    Const cnt_GridFormaPagamento_ContaCredito As Integer = 3
    Const cnt_GridFormaPagamento_MudaFilial As Integer = 4
    Const cnt_GridFormaPagamento_Ativa As Integer = 5
    Const cnt_GridFormaPagamento_ValidaCredito As Integer = 6
    Const cnt_GridFormaPagamento_Aprovacao As Integer = 7

    Const cnt_GridTipoMovimentacaoSacaria_Codigo As Integer = 0
    Const cnt_GridTipoMovimentacaoSacaria_Nome As Integer = 1

    Const cnt_GridTipoNegociacao_Codigo As Integer = 0
    Const cnt_GridTipoNegociacao_Descricao As Integer = 1
    Const cnt_GridTipoNegociacao_Tipo As Integer = 2
    Const cnt_GridTipoNegociacao_Operacao As Integer = 3
    Const cnt_GridTipoNegociacao_Texto As Integer = 4
    Const cnt_GridTipoNegociacao_Qt_Dia_Venc_Padrao As Integer = 5

    Const cnt_GridContaCorrente_Codigo As Integer = 0
    Const cnt_GridContaCorrente_Nome As Integer = 1
    Const cnt_GridContaCorrente_UltimoCheque As Integer = 2
    Const cnt_GridContaCorrente_NumeroBanco As Integer = 3
    Const cnt_GridContaCorrente_Agencia As Integer = 4
    Const cnt_GridContaCorrente_ContaCorrente As Integer = 5
    Const cnt_GridContaCorrente_ContaContabil As Integer = 6
    Const cnt_GridContaCorrente_Filial As Integer = 7
    Const cnt_GridContaCorrente_Ativo As Integer = 8

    Const cnt_GridTipoPessoaImposto_IndiceValor As Integer = 0
    Const cnt_GridTipoPessoaImposto_Imposto As Integer = 1
    Const cnt_GridTipoPessoaImposto_Data As Integer = 2
    Const cnt_GridTipoPessoaImposto_Valor As Integer = 3

    Enum eCadastroListagemGeral
        Funrural = 1
        Municipios = 2
        Tipo_Pessoa_Tributacao = 3
        UF = 4
        Tipo_Capital = 5
        Tipo_Pessoa = 6
        Estado_Civil = 7
        Forma_Pagamento = 8
        Tipo_NF = 9
        Analise = 10
        LocalEntrega = 11
        Origem = 12
        Tipo_Frete = 13
        Tipo_Frestista = 14
        Tipo_Adendo = 15
        Tipo_Cacau = 16
        Tipo_ContratoPAF = 17
        Tipo_Contato = 18
        Tipo_Movimentacao_Sacaria = 19
        Provisoes = 20
        Tipo_Aprovacao = 21
        Armazem = 22
        Modalidade_Recuperacao_Credito = 23
        Procedencia = 24
        Safra = 25
        Tipo_Acondicionamento = 26
        Tipo_Sacaria = 27
        Tipo_Inovacao = 28
        ContaCorrente = 29
        Tipo_Negociacao = 30
        Tipo_Garantia = 31
        Tipo_Desconto_Qualidade = 32
        Tipo_Pessoa_Imposto = 33
    End Enum

    Dim iTipoTela As eCadastroListagemGeral
    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim cnt_SEC_Tela As String
    Dim WithEvents oForm_Parametro As frmParametroRecuperacaoCredito
    Public Filtro_01 As Object
    Public Filtro_02 As Object

    Public Sub FormatarTela(ByVal TipoTela As eCadastroListagemGeral)
        Dim sTituloListagem As String = String.Empty
        Dim sTituloTela As String = String.Empty
        Dim oLista As New ValueList
        Dim oLista2 As New ValueList
        Dim SqlText As String
        Dim oToolTip As New System.Windows.Forms.ToolTip

        iTipoTela = TipoTela

        cmdEspecial_01.Visible = False
        cmdEspecial_02.Visible = False
        cmdEspecial_03.Visible = False

        Select Case iTipoTela
            Case eCadastroListagemGeral.Municipios, eCadastroListagemGeral.Procedencia, eCadastroListagemGeral.Armazem, _
                 eCadastroListagemGeral.ContaCorrente, eCadastroListagemGeral.Tipo_Negociacao, eCadastroListagemGeral.Tipo_Desconto_Qualidade
                objGrid_Inicializar(grdGeral, AllowAddNew.FixedAddRowOnTop, oDS, CellClickAction.EditAndSelectText)
            Case eCadastroListagemGeral.Tipo_Pessoa_Imposto
                objGrid_Inicializar(grdGeral, AllowAddNew.FixedAddRowOnTop, , CellClickAction.EditAndSelectText, , DefaultableBoolean.False)
                CarregarDados()
            Case Else
                objGrid_Inicializar(grdGeral, AllowAddNew.FixedAddRowOnTop, , CellClickAction.EditAndSelectText)
                CarregarDados()
        End Select

        '>>> Formatação do título da tela e título da listagem - Início
        grdGeral.DisplayLayout.Bands(0).Override.FilterUIType = FilterUIType.FilterRow

        Select Case iTipoTela
            Case eCadastroListagemGeral.Estado_Civil
                sTituloListagem = "Listagem de Estado Civil"
                sTituloTela = "Cadastro de Estado Civil"
                cnt_SEC_Tela = "Cadastro_Administrativo_EstadoCivil"

                objGrid_Coluna_Add(grdGeral, "Código do Estado Civil", 0, cnt_GridEstadoCivil_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome do Estado Civil", 500, cnt_GridEstadoCivil_Nome)
            Case eCadastroListagemGeral.Tipo_Pessoa_Tributacao
                sTituloListagem = "Listagem de Tipo Pessoa Tributação"
                sTituloTela = "Cadastro de Tipo Pessoa Tributação"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoPessoaTributacao"

                objGrid_Coluna_Add(grdGeral, "Código da Tipo Pessoa Tributação", 0, cnt_GridTipoPessoaTributacao_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome da Tipo Pessoa Tributação", 500, cnt_GridTipoPessoaTributacao_Nome)
            Case eCadastroListagemGeral.Funrural
                sTituloListagem = "Listagem de Tipos de Funrural"
                sTituloTela = "Cadastro de Tipos de Funrural"
                cnt_SEC_Tela = "Cadastro_Contabil_Funrural"

                objGrid_Coluna_Add(grdGeral, "Código do Tipo de Funrural", 0, cnt_GridFunrural_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome do Tipo de Funrural", 300, cnt_GridFunrural_Nome)
                objGrid_Coluna_Add(grdGeral, "Taxa do Funrural", 200, cnt_GridFunrural_Taxa)
            Case eCadastroListagemGeral.UF
                sTituloListagem = "Listagem de Unidade Federativas Cadastradas"
                sTituloTela = "Cadastro de Unidade Federativa"
                cnt_SEC_Tela = "Cadastro_Administrativo_UF"

                objGrid_Coluna_Add(grdGeral, "Código da UF", 120, cnt_GridUF_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome da UF", 200, cnt_GridUF_Nome)
                objGrid_Coluna_Add(grdGeral, "Alíquota de ICMS", 150, cnt_GridUF_Aliq_ICMS, , , , cnt_Formato_Procentagem_4casas)
                objGrid_Coluna_Add(grdGeral, "Obrigação Acessoria", 150, cnt_GridUF_Aliq_Obrigacao_Acessorio, , ColumnStyle.CheckBox)
            Case eCadastroListagemGeral.Tipo_Capital
                sTituloListagem = "Listagem de Tipo Capital"
                sTituloTela = "Cadastro de Tipo Capital"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoCapital"

                objGrid_Coluna_Add(grdGeral, "Código do Tipo Capital", 0, cnt_GridTipoCapital_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome do Tipo Capital", 200, cnt_GridTipoCapital_Nome)
            Case eCadastroListagemGeral.Tipo_Pessoa
                sTituloListagem = "Listagem de Tipo de Pessoa"
                sTituloTela = "Cadastro de Tipo de Pessoa"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoPessoa"

                objGrid_Coluna_Add(grdGeral, "Código do Tipo de Pessoa", 0, cnt_GridTipoPessoa_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome do Tipo de Pessoa", 200, cnt_GridTipoPessoa_Nome)
                objGrid_Coluna_Add(grdGeral, "Mostra Preço na Bolsa", 200, cnt_GridTipoPessoa_MostraPrecoBolsa, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Percentual Preço Bolsa", 200, cnt_GridTipoPessoa_percentualPrecoBolsa)

                cmdEspecial_01.Visible = True
            Case eCadastroListagemGeral.Municipios
                sTituloListagem = "Listagem de Município"
                sTituloTela = "Cadastro de Município"
                cnt_SEC_Tela = "Cadastro_Administrativo_Município"

                SqlText = "SELECT CD_UF, NO_UF" & _
                          " FROM SOF.UF" & _
                          " ORDER BY NO_UF"
                oLista = ValueList_Carregar(SqlText)

                objGrid_Coluna_Add(grdGeral, "Código Município", 0)
                objGrid_Coluna_Add(grdGeral, "Nome Município", 300)
                objGrid_Coluna_Add(grdGeral, "UF", 190, , True, UltraWinGrid.ColumnStyle.DropDownList, oLista)

                CarregarDados()
            Case eCadastroListagemGeral.Forma_Pagamento
                sTituloListagem = "Listagem de Formas de Pagamento"
                sTituloTela = "Cadastro de Formas de Pagamento"
                cnt_SEC_Tela = "Cadastro_Contabil_FormaPagamento"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridFormaPagamento_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 120, cnt_GridFormaPagamento_Nome)
                objGrid_Coluna_Add(grdGeral, "Conta Contábil Débito", 150, cnt_GridFormaPagamento_ContaDebito)
                objGrid_Coluna_Add(grdGeral, "Conta Contábil Crédito", 150, cnt_GridFormaPagamento_ContaCredito)
                objGrid_Coluna_Add(grdGeral, "Muda Filial Conta", 80, cnt_GridFormaPagamento_MudaFilial, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Ativa", 80, cnt_GridFormaPagamento_Ativa, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Valida Crédito", 80, cnt_GridFormaPagamento_ValidaCredito, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Aprovação?", 80, cnt_GridFormaPagamento_Aprovacao, , ColumnStyle.CheckBox)
            Case eCadastroListagemGeral.Analise
                sTituloListagem = "Listagem de Analises"
                sTituloTela = "Cadastro de Analises"
                cnt_SEC_Tela = "Cadastro_Movimentacao_Analise"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridAnalise_Codigo, False)
                objGrid_Coluna_Add(grdGeral, "Nome", 300, cnt_GridAnalise_Nome)
            Case eCadastroListagemGeral.LocalEntrega
                sTituloListagem = "Listagem de Local de Entrega"
                sTituloTela = "Cadastro de Local de Entrega"
                cnt_SEC_Tela = "Cadastro_Administrativo_LocalEntrega"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridLocalEntrega_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 300, cnt_GridLocalEntrega_Nome)
                objGrid_Coluna_Add(grdGeral, "Ativa?", 100, cnt_GridLocalEntrega_Ativo, , ColumnStyle.CheckBox)
            Case eCadastroListagemGeral.Origem
                sTituloListagem = "Listagem de Origem"
                sTituloTela = "Cadastro de Origem"
                cnt_SEC_Tela = "Cadastro_Movimentacao_Origem"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridOrigem_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 300, cnt_GridOrigem_Nome)
            Case eCadastroListagemGeral.Tipo_NF
                sTituloListagem = "Listagem de Tipo NF"
                sTituloTela = "Cadastro de Tipo NF"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoNF"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoNF_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 200, cnt_GridTipoNF_Nome)
                objGrid_Coluna_Add(grdGeral, "Municipio Fiscal?", 100, cnt_GridTipoNF_MunicipioFiscal, , ColumnStyle.CheckBox)
            Case eCadastroListagemGeral.Tipo_Adendo
                sTituloListagem = "Listagem de Tipo Adendo"
                sTituloTela = "Cadastro de Tipo Adendo"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoAdendo"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoAdendo_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 300, cnt_GridTipoAdendo_Nome)
            Case eCadastroListagemGeral.Tipo_Cacau
                sTituloListagem = "Listagem de Tipo de Cacau"
                sTituloTela = "Cadastro de Tipo de Cacau"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoCacau"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoCacau_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 300, cnt_GridTipoCacau_Nome)
            Case eCadastroListagemGeral.Tipo_ContratoPAF
                sTituloListagem = "Listagem de Tipo Contrato PAF"
                sTituloTela = "Cadastro de Tipo Contrato PAF"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoContratoPAF"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoContratoPAF_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 130, cnt_GridTipoContratoPAF_Nome)
                objGrid_Coluna_Add(grdGeral, "Com Adiantamento?", 100, cnt_GridTipoContratoPAF_Adiantamento, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Texto Contrato", 300, cnt_GridTipoContratoPAF_TextoContrato)
            Case eCadastroListagemGeral.Tipo_Frestista
                sTituloListagem = "Listagem de Tipo Fretista"
                sTituloTela = "Cadastro de Tipo Fretista"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoFretista"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoFretista_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 300, cnt_GridTipoFretista_Nome)
            Case eCadastroListagemGeral.Tipo_Frete
                sTituloListagem = "Listagem de Tipo Frete"
                sTituloTela = "Cadastro de Tipo Frete"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoFrete"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoFrete_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 300, cnt_GridTipoFrete_Nome)
            Case eCadastroListagemGeral.Tipo_Contato
                sTituloListagem = "Listagem de Tipo Contato"
                sTituloTela = "Cadastro de Tipo Contato"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoContrato"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoContato_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 300, cnt_GridTipoContato_Nome)
            Case eCadastroListagemGeral.Tipo_Movimentacao_Sacaria
                sTituloListagem = "Listagem de Tipo de Movimentação de Sacaria"
                sTituloTela = "Cadastro de Tipo de Movimentação de Sacaria"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoMovimentacaoSacaria"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoMovimentacaoSacaria_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 300, cnt_GridTipoMovimentacaoSacaria_Nome)
            Case eCadastroListagemGeral.Provisoes
                sTituloListagem = "Listagem de Provisões"
                sTituloTela = "Cadastro de Provisão"
                cnt_SEC_Tela = "Cadastro_Contabil_Provisao"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridProvisao_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 150, cnt_GridProvisao_Nome)
                objGrid_Coluna_Add(grdGeral, "Conta Contabil", 140, cnt_GridProvisao_ContaContabil)
                objGrid_Coluna_Add(grdGeral, "Calcula Sub Aliquota", 130, cnt_GridProvisao_CalculaSubAliquota, True, ColumnStyle.CheckBox)
            Case eCadastroListagemGeral.Tipo_Aprovacao
                sTituloListagem = "Listagem de Tipo Aprovação"
                sTituloTela = "Cadastro de Tipo Aprovação"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoAprovacao"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoAprovador_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 150, cnt_GridTipoAprovador_Nome)
                objGrid_Coluna_Add(grdGeral, "Possui Limite", 120, cnt_GridTipoAprovador_PossuiLimite, True, ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Obrigatoria", 100, cnt_GridTipoAprovador_Obrigatorio, True, ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Libera Negociação", 130, cnt_GridTipoAprovador_LiberaNegociacao, True, ColumnStyle.CheckBox)
            Case eCadastroListagemGeral.Armazem
                sTituloListagem = "Listagem de Armazéns"
                sTituloTela = "Cadastro de Armazém"
                cnt_SEC_Tela = "Cadastro_Movimentacao_Armazem"

                SqlText = "SELECT CD_FILIAL, NO_FILIAL" & _
                         " FROM SOF.FILIAL WHERE IC_ATIVA='S' " & _
                         " ORDER BY NO_FILIAL"
                oLista = ValueList_Carregar(SqlText)

                objGrid_Coluna_Add(grdGeral, "Código ", 60)
                objGrid_Coluna_Add(grdGeral, "Nome", 150)
                objGrid_Coluna_Add(grdGeral, "Filial", 150, , True, UltraWinGrid.ColumnStyle.DropDownList, oLista)
                objGrid_Coluna_Add(grdGeral, "Ativo", 80, , True, ColumnStyle.CheckBox)
                CarregarDados()
            Case eCadastroListagemGeral.Modalidade_Recuperacao_Credito
                sTituloListagem = "Listagem de Modalidade Recuperação de Crédito - Parâmetro"
                sTituloTela = "Cadastro de Modalidade Recuperação de Crédito - Parâmetro"
                cnt_SEC_Tela = "Cadastro_Contabil_ModalidadeRecuperacaoCredito"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridModalidadeRecuperacaoCredito_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 150, cnt_GridModalidadeRecuperacaoCredito_Nome)
                objGrid_Coluna_Add(grdGeral, "Forma de Pagamento", 100, cnt_GridModalidadeRecuperacaoCredito_FormaPagamento)
                objGrid_Coluna_Add(grdGeral, "Tipo Pagamento", 220, cnt_GridModalidadeRecuperacaoCredito_TipoPagamento)
                objGrid_Coluna_Add(grdGeral, "Modalidade Conciliação", 300, cnt_GridModalidadeRecuperacaoCredito_ModalidadeConciliacao)

                cmdEspecial_01.Visible = True
                Form_Botao_Formatar(cmdEspecial_01, "CMDPARAMETRO")
            Case eCadastroListagemGeral.Procedencia
                sTituloListagem = "Listagem de Procedências"
                sTituloTela = "Cadastro de Procedência"
                cnt_SEC_Tela = "Cadastro_Movimentacao_Procedencia"

                SqlText = "SELECT CD_ORIGEM, NO_ORIGEM" & _
                          " FROM SOF.ORIGEM" & _
                          " ORDER BY NO_ORIGEM"
                oLista = ValueList_Carregar(SqlText)

                objGrid_Coluna_Add(grdGeral, "Código ", 60)
                objGrid_Coluna_Add(grdGeral, "Nome", 200)
                objGrid_Coluna_Add(grdGeral, "Origem", 200, , True, UltraWinGrid.ColumnStyle.DropDownList, oLista)
                CarregarDados()
            Case eCadastroListagemGeral.Safra
                sTituloListagem = "Listagem de Safras"
                sTituloTela = "Cadastro de Safra"
                cnt_SEC_Tela = "Cadastro_Administrativo_Safra"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridSafra_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 200, cnt_GridSafra_Nome)
                objGrid_Coluna_Add(grdGeral, "Valido", 100, cnt_GridSafra_Valido, True, ColumnStyle.CheckBox)
            Case eCadastroListagemGeral.Tipo_Acondicionamento
                sTituloListagem = "Listagem de Tipo Acondicionamento"
                sTituloTela = "Cadastro de Tipo Acondicionamento"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoAcondicionamento"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoAcondicionamento_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 200, cnt_GridTipoAcondicionamento_Nome)
                objGrid_Coluna_Add(grdGeral, "Texto Contrato", 300, cnt_GridTipoAcondicionamento_TextoContrato)
            Case eCadastroListagemGeral.Tipo_Sacaria
                sTituloListagem = "Listagem de Tipo Sacaria"
                sTituloTela = "Cadastro de Tipo Sacaria"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoSacaria"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoSacaria_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 150, cnt_GridTipoSacaria_Nome)
                objGrid_Coluna_Add(grdGeral, "Peso ", 70, cnt_GridTipoSacaria_Peso)
                objGrid_Coluna_Add(grdGeral, "Preço", 70, cnt_GridTipoSacaria_Preco)
                objGrid_Coluna_Add(grdGeral, "Contabiliza no Fornecedor", 140, cnt_GridTipoSacaria_ContabilizaFornecedor, True, ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Ativo", 80, cnt_GridTipoSacaria_Ativo, True, ColumnStyle.CheckBox)
            Case eCadastroListagemGeral.Tipo_Inovacao
                sTituloListagem = "Listagem de Tipo Inovação"
                sTituloTela = "Cadastro de Tipo Inovação"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoInovacao"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoInovacao_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 300, cnt_GridTipoInovacao_Nome)
            Case eCadastroListagemGeral.ContaCorrente
                sTituloListagem = "Listagem de Conta Corrente"
                sTituloTela = "Cadastro de Conta Corrente"
                cnt_SEC_Tela = "Cadastro_Contabil_ContaCorrente"

                SqlText = "SELECT CD_FILIAL, NO_FILIAL" & _
                         " FROM SOF.FILIAL WHERE IC_ATIVA='S' " & _
                         " ORDER BY NO_FILIAL"
                oLista = ValueList_Carregar(SqlText)

                objGrid_Coluna_Add(grdGeral, "Código ", 60)
                objGrid_Coluna_Add(grdGeral, "Nome", 150)
                objGrid_Coluna_Add(grdGeral, "Ultimo Cheque ", 100)
                objGrid_Coluna_Add(grdGeral, "Número Banco", 100)
                objGrid_Coluna_Add(grdGeral, "Agência ", 80)
                objGrid_Coluna_Add(grdGeral, "Conta Corrente", 120)
                objGrid_Coluna_Add(grdGeral, "Conta Contabil", 120)
                objGrid_Coluna_Add(grdGeral, "Filial", 120, , True, UltraWinGrid.ColumnStyle.DropDownList, oLista)
                objGrid_Coluna_Add(grdGeral, "Ativo", 80, , True, ColumnStyle.CheckBox)
                CarregarDados()
            Case eCadastroListagemGeral.Tipo_Negociacao
                sTituloListagem = "Listagem de Tipo Negociação"
                sTituloTela = "Cadastro de Tipo Negociação"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoNegociacao"

                SqlText = "SELECT '+' cod, 'Adição' nome "
                SqlText = SqlText & "  FROM DUAL "
                SqlText = SqlText & "UNION "
                SqlText = SqlText & "SELECT '-', 'Subtração' nome "
                SqlText = SqlText & "  FROM DUAL "
                SqlText = SqlText & "UNION "
                SqlText = SqlText & "SELECT '*', 'Multiplicação' nome "
                SqlText = SqlText & "  FROM DUAL "
                SqlText = SqlText & "UNION "
                SqlText = SqlText & "SELECT '/', 'Divisão' nome "
                SqlText = SqlText & "  FROM DUAL "
                oLista = ValueList_Carregar(SqlText)

                SqlText = "SELECT 'P' cod, 'Preço Fixo' nome "
                SqlText = SqlText & "  FROM DUAL "
                SqlText = SqlText & "UNION "
                SqlText = SqlText & "SELECT 'B', 'Bolsa de Cacau' nome "
                SqlText = SqlText & "  FROM DUAL "
                SqlText = SqlText & "UNION "
                SqlText = SqlText & "SELECT 'D', 'Dolar' nome "
                SqlText = SqlText & "  FROM DUAL "
                oLista2 = ValueList_Carregar(SqlText)

                objGrid_Coluna_Add(grdGeral, "Código ", 60)
                objGrid_Coluna_Add(grdGeral, "Descrição", 150)
                objGrid_Coluna_Add(grdGeral, "Tipo", 100, , True, UltraWinGrid.ColumnStyle.DropDownList, oLista2)
                objGrid_Coluna_Add(grdGeral, "Operação", 100, , True, UltraWinGrid.ColumnStyle.DropDownList, oLista)
                objGrid_Coluna_Add(grdGeral, "Texto ", 300)
                objGrid_Coluna_Add(grdGeral, "Dia Venc. Padrão", 125)

                CarregarDados()
            Case eCadastroListagemGeral.Tipo_Garantia
                sTituloListagem = "Listagem de Tipo Garantia"
                sTituloTela = "Cadastro de Tipo Garantia"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoGarantia"

                objGrid_Coluna_Add(grdGeral, "Código ", 60, cnt_GridTipoGarantia_Codigo)
                objGrid_Coluna_Add(grdGeral, "Descrição", 150, cnt_GridTipoGarantia_Descricao)
                objGrid_Coluna_Add(grdGeral, "Limite", 80, cnt_GridTipoGarantia_ValorLimite, , , , cnt_Formato_Valor)
                objGrid_Coluna_Add(grdGeral, "Possui Descrição?", 100, cnt_GridTipoGarantia_IcDescricao, True, ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Exite Garantia?", 90, cnt_GridTipoGarantia_IcProvisoria, True, ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Provisoria?", 70, cnt_GridTipoGarantia_IcGarantido, True, ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Prazo Maximo", 80, cnt_GridTipoGarantia_IcPrazo, True, ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Prazo Validade", 90, cnt_GridTipoGarantia_QtDias)
            Case eCadastroListagemGeral.Tipo_Desconto_Qualidade
                sTituloListagem = "Listagem de Tipo Desconto Qualidade"
                sTituloTela = "Cadastro de Tipo Desconto Qualidade"
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoDescontoQualidade"

                SqlText = "SELECT CD_TIPO_PAGAMENTO, NO_TIPO_PAGAMENTO" & _
                        " FROM SOF.TIPO_PAGAMENTO WHERE IC_ATIVO='S' " & _
                        " ORDER BY NO_TIPO_PAGAMENTO"
                oLista = ValueList_Carregar(SqlText)

                SqlText = "SELECT A.COLUMN_NAME, A.COMMENTS " & _
                            "FROM SYS.ALL_COL_COMMENTS A " & _
                            "WHERE A.OWNER='SOF' AND A.TABLE_NAME='MOVIMENTACAO_QUALIDADE' AND A.COMMENTS IS NOT NULL"
                oLista2 = ValueList_Carregar(SqlText)

                objGrid_Coluna_Add(grdGeral, "Código ", 60)
                objGrid_Coluna_Add(grdGeral, "Nome", 150)
                objGrid_Coluna_Add(grdGeral, "Campo", 120, , True, UltraWinGrid.ColumnStyle.DropDownList, oLista2)
                objGrid_Coluna_Add(grdGeral, "Maximo Permitido", 110)
                objGrid_Coluna_Add(grdGeral, "Tipo Pagamento", 220, , True, UltraWinGrid.ColumnStyle.DropDownList, oLista)
                objGrid_Coluna_Add(grdGeral, "Ativo", 80, , , ColumnStyle.CheckBox)

                CarregarDados()
            Case eCadastroListagemGeral.Tipo_Pessoa_Imposto
                sTituloListagem = "Listagem de Imposto de Tipo de Pessoa"
                sTituloTela = "Cadastro de Imposto de Tipo de Pessoa"

                SqlText = "SELECT CD_PROCESSO, NO_PROCESSO FROM SOF.PROCESSO" & _
                          " WHERE CD_PROCESSO IN (" & cnt_Processo_Confis & ", " & cnt_Processo_PIS & ")"

                objGrid_Coluna_Add(grdGeral, "IndiceValor", 0, cnt_GridTipoPessoaImposto_IndiceValor)
                objGrid_Coluna_Add(grdGeral, "Impostos", 250, cnt_GridTipoPessoaImposto_Imposto, , , ValueList_Carregar(SqlText))
                objGrid_Coluna_Add(grdGeral, "Data de Vigência", 150, cnt_GridTipoPessoaImposto_Data, , , , cnt_Formato_Data)
                objGrid_Coluna_Add(grdGeral, "Valor", 100, cnt_GridTipoPessoaImposto_Valor, , , , cnt_Formato_Procentagem_4casas)
        End Select

        If Not SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao) Then
            grdGeral.DisplayLayout.Bands(0).Override.AllowUpdate = DefaultableBoolean.False
        End If
        If Not SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao) Then
            grdGeral.DisplayLayout.Bands(0).Override.AllowDelete = DefaultableBoolean.False
        End If
        If Not SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao) Then
            grdGeral.DisplayLayout.Bands(0).Override.AllowAddNew = DefaultableBoolean.False
        End If

        Me.Text = sTituloTela
        lblTituloPesquisa.Text = sTituloListagem
        '>>> Formatação do título da tela e título da listagem - Fim
    End Sub

    Private Sub grdGeral_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdGeral.AfterRowUpdate
        Dim SqlText As String

        Select Case iTipoTela
            Case eCadastroListagemGeral.Tipo_Pessoa
                Dim Cd_Tipo_Pessoa As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoCapital_Codigo).Value) Then
                    Cd_Tipo_Pessoa = DBNumeroMaisUm("SOF.TIPO_PESSOA", "CD_TIPO_PESSOA")

                    SqlText = DBMontar_Insert("TIPO_PESSOA", TipoCampoFixo.Todos, "VL_PERCENTUAL_PRECO_BOLSA", ":VL_PERCENTUAL_PRECO_BOLSA", _
                                                                                  "IC_MOSTRA_PRECO_BOLSA", ":IC_MOSTRA_PRECO_BOLSA", _
                                                                                  "NO_TIPO_PESSOA", ":NO_TIPO_PESSOA", _
                                                                                  "CD_TIPO_PESSOA", ":CD_TIPO_PESSOA")
                Else
                    Cd_Tipo_Pessoa = e.Row.Cells(cnt_GridTipoPessoa_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_PESSOA", GerarArray("VL_PERCENTUAL_PRECO_BOLSA", ":VL_PERCENTUAL_PRECO_BOLSA", _
                                                                        "IC_MOSTRA_PRECO_BOLSA", ":IC_MOSTRA_PRECO_BOLSA", _
                                                                        "NO_TIPO_PESSOA", ":NO_TIPO_PESSOA"), _
                                                             GerarArray("CD_TIPO_PESSOA", ":CD_TIPO_PESSOA"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("VL_PERCENTUAL_PRECO_BOLSA", NVL(e.Row.Cells(cnt_GridTipoPessoa_percentualPrecoBolsa).Value, 0)), _
                                           DBParametro_Montar("IC_MOSTRA_PRECO_BOLSA", objGrid_CheckCol_Valor(grdGeral, cnt_GridTipoPessoa_MostraPrecoBolsa, e.Row.Index)), _
                                           DBParametro_Montar("NO_TIPO_PESSOA", e.Row.Cells(cnt_GridTipoPessoa_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_PESSOA", Cd_Tipo_Pessoa)) Then GoTo Erro
            Case eCadastroListagemGeral.Estado_Civil
                Dim Cd_Estado_Civil As Integer

                If CampoNulo(e.Row.Cells(cnt_GridEstadoCivil_Codigo).Value) Then
                    Cd_Estado_Civil = DBNumeroMaisUm("SOF.ESTADO_CIVIL", "CD_ESTADO_CIVIL")
                    SqlText = DBMontar_Insert("ESTADO_CIVIL", TipoCampoFixo.Todos, "NO_ESTADO_CIVIL", ":NO_ESTADO_CIVIL", _
                                                                                   "CD_ESTADO_CIVIL", ":CD_ESTADO_CIVIL")
                Else
                    Cd_Estado_Civil = e.Row.Cells(cnt_GridEstadoCivil_Codigo).Value

                    SqlText = DBMontar_Update("ESTADO_CIVIL", GerarArray("NO_ESTADO_CIVIL", ":NO_ESTADO_CIVIL"), _
                                                              GerarArray("CD_ESTADO_CIVIL", ":CD_ESTADO_CIVIL"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_ESTADO_CIVIL", e.Row.Cells(cnt_GridEstadoCivil_Nome).Value), _
                                           DBParametro_Montar("CD_ESTADO_CIVIL", Cd_Estado_Civil)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Capital
                Dim Cd_Tipo_Capital As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoCapital_Codigo).Value) Then
                    Cd_Tipo_Capital = DBNumeroMaisUm("SOF.FORNECEDOR_TIPO_CAPITAL", "CD_TIPO_CAPITAL")
                    SqlText = DBMontar_Insert("FORNECEDOR_TIPO_CAPITAL", TipoCampoFixo.Todos, "NO_TIPO_CAPITAL", ":NO_TIPO_CAPITAL", _
                                                                                              "CD_TIPO_CAPITAL", ":CD_TIPO_CAPITAL")
                Else
                    Cd_Tipo_Capital = e.Row.Cells(cnt_GridTipoCapital_Codigo).Value

                    SqlText = DBMontar_Update("FORNECEDOR_TIPO_CAPITAL", GerarArray("NO_TIPO_CAPITAL", ":NO_TIPO_CAPITAL"), _
                                                                         GerarArray("CD_TIPO_CAPITAL", ":CD_TIPO_CAPITAL"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_TIPO_CAPITAL", e.Row.Cells(cnt_GridTipoCapital_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_CAPITAL", Cd_Tipo_Capital)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Pessoa_Tributacao
                Dim CD_Tipo_Pessoa_Tributacao As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoPessoaTributacao_Codigo).Value) Then
                    CD_Tipo_Pessoa_Tributacao = DBNumeroMaisUm("SOF.TIPO_PESSOA_TRIBUTACAO", "CD_TIPO_PESSOA_TRIBUTACAO")

                    SqlText = DBMontar_Insert("TIPO_PESSOA_TRIBUTACAO", TipoCampoFixo.Todos, "NO_TIPO_PESSOA_TRIBUTACAO", ":NO_TIPO_PESSOA_TRIBUTACAO", _
                                                                                             "CD_TIPO_PESSOA_TRIBUTACAO", ":CD_TIPO_PESSOA_TRIBUTACAO")
                Else
                    CD_Tipo_Pessoa_Tributacao = e.Row.Cells(cnt_GridTipoPessoaTributacao_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_PESSOA_TRIBUTACAO", GerarArray("NO_TIPO_PESSOA_TRIBUTACAO", ":NO_TIPO_PESSOA_TRIBUTACAO"), _
                                                                        GerarArray("CD_TIPO_PESSOA_TRIBUTACAO", ":CD_TIPO_PESSOA_TRIBUTACAO"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_TIPO_PESSOA_TRIBUTACAO", e.Row.Cells(cnt_GridTipoPessoaTributacao_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_PESSOA_TRIBUTACAO", CD_Tipo_Pessoa_Tributacao)) Then GoTo Erro
            Case eCadastroListagemGeral.Funrural
                Dim CD_Funrural As Integer

                If CampoNulo(e.Row.Cells(cnt_GridFunrural_Codigo).Value) Then
                    CD_Funrural = DBNumeroMaisUm("SOF.FUNRURAL", "CD_FUNRURAL")

                    SqlText = DBMontar_Insert("FUNRURAL", TipoCampoFixo.Todos, "NO_FUNRURAL", ":NO_FUNRURAL", _
                                                                               "VL_TAXA", ":VL_TAXA", _
                                                                               "CD_FUNRURAL", ":CD_FUNRURAL")
                Else
                    CD_Funrural = e.Row.Cells(cnt_GridFunrural_Codigo).Value

                    SqlText = DBMontar_Update("FUNRURAL", GerarArray("NO_FUNRURAL", ":NO_FUNRURAL", _
                                                                     "VL_TAXA", ":VL_TAXA"), _
                                                          GerarArray("CD_FUNRURAL", ":CD_FUNRURAL"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_FUNRURAL", e.Row.Cells(cnt_GridFunrural_Nome).Value), _
                                           DBParametro_Montar("VL_TAXA", e.Row.Cells(cnt_GridFunrural_Taxa).Value), _
                                           DBParametro_Montar("CD_FUNRURAL", CD_Funrural)) Then GoTo Erro
            Case eCadastroListagemGeral.Municipios
                Dim CD_Municipio As Integer

                If CampoNulo(e.Row.Cells(cnt_GridMunicipio_Codigo).Value) Then
                    CD_Municipio = DBNumeroMaisUm("SOF.MUNICIPIO", "CD_MUNICIPIO")

                    SqlText = DBMontar_Insert("MUNICIPIO", TipoCampoFixo.Todos, "NO_CIDADE", ":NO_CIDADE", _
                                                                                "CD_UF", ":CD_UF", _
                                                                                "CD_MUNICIPIO", ":CD_MUNICIPIO")
                Else
                    CD_Municipio = e.Row.Cells(cnt_GridMunicipio_Codigo).Value

                    SqlText = DBMontar_Update("MUNICIPIO", GerarArray("NO_CIDADE", ":NO_CIDADE", _
                                                                      "CD_UF", ":CD_UF"), _
                                                           GerarArray("CD_MUNICIPIO", ":CD_MUNICIPIO"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_CIDADE", e.Row.Cells(cnt_GridMunicipio_Nome).Value), _
                                           DBParametro_Montar("CD_UF", e.Row.Cells(cnt_GridMunicipio_UF).Value), _
                                           DBParametro_Montar("CD_MUNICIPIO", CD_Municipio)) Then GoTo Erro
            Case eCadastroListagemGeral.UF
                If DBQuery_ValorUnico("SELECT COUNT(*) FROM SOF.UF WHERE CD_UF='" & e.Row.Cells(cnt_GridUF_Codigo).Value & "'") = 0 Then
                    SqlText = DBMontar_Insert("UF", TipoCampoFixo.Todos, "NO_UF", ":NO_UF", _
                                                                         "IC_OBRIGACAO_ACESSORIA", ":IC_OBRIGACAO_ACESSORIA", _
                                                                         "PC_ALIQ_ICMS", ":PC_ALIQ_ICMS", _
                                                                         "CD_UF", ":CD_UF")
                Else
                    SqlText = DBMontar_Update("UF", GerarArray("NO_UF", ":NO_UF", _
                                                               "IC_OBRIGACAO_ACESSORIA", ":IC_OBRIGACAO_ACESSORIA", _
                                                               "PC_ALIQ_ICMS", ":PC_ALIQ_ICMS"), _
                                                    GerarArray("CD_UF", ":CD_UF"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_UF", e.Row.Cells(cnt_GridUF_Nome).Value), _
                                           DBParametro_Montar("IC_OBRIGACAO_ACESSORIA", objGrid_CheckCol_Valor(grdGeral, cnt_GridUF_Aliq_Obrigacao_Acessorio, e.Row.Index)), _
                                           DBParametro_Montar("PC_ALIQ_ICMS", e.Row.Cells(cnt_GridUF_Aliq_ICMS).Value), _
                                           DBParametro_Montar("CD_UF", e.Row.Cells(cnt_GridUF_Codigo).Value)) Then GoTo Erro
            Case eCadastroListagemGeral.Forma_Pagamento
                If DBQuery_ValorUnico("SELECT COUNT(*) FROM SOF.FORMA_PAGAMENTO" & _
                                      " WHERE CD_FORMA_PAGAMENTO=" & NVL(e.Row.Cells(cnt_GridFormaPagamento_Codigo).Value, 0)) = 0 Then
                    e.Row.Cells(cnt_GridFormaPagamento_Codigo).Value = DBNumeroMaisUm("SOF.FORMA_PAGAMENTO", _
                                                                                      "CD_FORMA_PAGAMENTO")

                    SqlText = DBMontar_Insert("FORMA_PAGAMENTO", TipoCampoFixo.Todos, "IC_VALIDA_CREDITO", ":IC_VALIDA_CREDITO", _
                                                                                      "IC_ATIVO", ":IC_ATIVO", _
                                                                                      "IC_APROVACAO", ":IC_APROVACAO", _
                                                                                      "IC_MUDA_FILIAL_CONTA_CREDITO", ":IC_MUDA_FILIAL_CONTA_CREDITO", _
                                                                                      "NU_CONTA_CONTABIL_CREDITO", ":NU_CONTA_CONTABIL_CREDITO", _
                                                                                      "NU_CONTA_CONTABIL_DEBITO", ":NU_CONTA_CONTABIL_DEBITO", _
                                                                                      "NO_FORMA_PAGAMENTO", ":NO_FORMA_PAGAMENTO", _
                                                                                      "CD_FORMA_PAGAMENTO", ":CD_FORMA_PAGAMENTO")
                Else
                    SqlText = DBMontar_Update("FORMA_PAGAMENTO", GerarArray("IC_VALIDA_CREDITO", ":IC_VALIDA_CREDITO", _
                                                                            "IC_ATIVO", ":IC_ATIVO", _
                                                                            "IC_APROVACAO", ":IC_APROVACAO", _
                                                                            "IC_MUDA_FILIAL_CONTA_CREDITO", ":IC_MUDA_FILIAL_CONTA_CREDITO", _
                                                                            "NU_CONTA_CONTABIL_CREDITO", ":NU_CONTA_CONTABIL_CREDITO", _
                                                                            "NU_CONTA_CONTABIL_DEBITO", ":NU_CONTA_CONTABIL_DEBITO", _
                                                                            "NO_FORMA_PAGAMENTO", ":NO_FORMA_PAGAMENTO"), _
                                                                 GerarArray("CD_FORMA_PAGAMENTO", ":CD_FORMA_PAGAMENTO"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("IC_VALIDA_CREDITO", objGrid_CheckCol_Valor(grdGeral, cnt_GridFormaPagamento_ValidaCredito, e.Row.Index)), _
                                           DBParametro_Montar("IC_ATIVO", objGrid_CheckCol_Valor(grdGeral, cnt_GridFormaPagamento_Ativa, e.Row.Index)), _
                                            DBParametro_Montar("IC_APROVACAO", objGrid_CheckCol_Valor(grdGeral, cnt_GridFormaPagamento_Aprovacao, e.Row.Index)), _
                                           DBParametro_Montar("IC_MUDA_FILIAL_CONTA_CREDITO", objGrid_CheckCol_Valor(grdGeral, cnt_GridFormaPagamento_MudaFilial, e.Row.Index)), _
                                           DBParametro_Montar("NU_CONTA_CONTABIL_CREDITO", e.Row.Cells(cnt_GridFormaPagamento_ContaCredito).Value), _
                                           DBParametro_Montar("NU_CONTA_CONTABIL_DEBITO", e.Row.Cells(cnt_GridFormaPagamento_ContaDebito).Value), _
                                           DBParametro_Montar("NO_FORMA_PAGAMENTO", e.Row.Cells(cnt_GridFormaPagamento_Nome).Value), _
                                           DBParametro_Montar("CD_FORMA_PAGAMENTO", e.Row.Cells(cnt_GridFormaPagamento_Codigo).Value)) Then GoTo Erro
            Case eCadastroListagemGeral.Analise
                Dim CdAnalise As Integer

                If CampoNulo(e.Row.Cells(cnt_GridAnalise_Codigo).Value) Then
                    CdAnalise = DBNumeroMaisUm("SOF.ANALISE", "CD_ANALISE")
                    SqlText = DBMontar_Insert("ANALISE", TipoCampoFixo.Todos, "NO_ANALISE", ":NO_ANALISE", _
                                                                                   "CD_ANALISE", ":CD_ANALISE")
                Else
                    CdAnalise = e.Row.Cells(cnt_GridAnalise_Codigo).Value

                    SqlText = DBMontar_Update("ANALISE", GerarArray("NO_ANALISE", ":NO_ANALISE"), _
                                                              GerarArray("CD_ANALISE", ":CD_ANALISE"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_ANALISE", e.Row.Cells(cnt_GridAnalise_Nome).Value), _
                                           DBParametro_Montar("CD_ANALISE", CdAnalise)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_NF

                If DBQuery_ValorUnico("SELECT COUNT(*) FROM SOF.TIPO_NF WHERE CD_TIPO_NF='" & e.Row.Cells(cnt_GridTipoNF_Codigo).Value & "'") = 0 Then
                    SqlText = DBMontar_Insert("TIPO_NF", TipoCampoFixo.Todos, "IC_MUNICIPIO_FISCAL", ":IC_MUNICIPIO_FISCAL", _
                                                                                "NO_TIPO_NF", ":NO_TIPO_NF", _
                                                                                "CD_TIPO_NF", ":CD_TIPO_NF")
                Else
                    SqlText = DBMontar_Update("TIPO_NF", GerarArray("IC_MUNICIPIO_FISCAL", ":IC_MUNICIPIO_FISCAL", _
                                                                    "NO_TIPO_NF", ":NO_TIPO_NF"), _
                                                              GerarArray("CD_TIPO_NF", ":CD_TIPO_NF"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("IC_MUNICIPIO_FISCAL", objGrid_CheckCol_Valor(grdGeral, cnt_GridTipoNF_MunicipioFiscal, e.Row.Index)), _
                                           DBParametro_Montar("NO_TIPO_NF", e.Row.Cells(cnt_GridTipoCapital_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_NF", e.Row.Cells(cnt_GridTipoNF_Codigo).Value)) Then GoTo Erro
            Case eCadastroListagemGeral.Origem
                Dim CdOrigem As Integer

                If CampoNulo(e.Row.Cells(cnt_GridOrigem_Codigo).Value) Then
                    CdOrigem = DBNumeroMaisUm("SOF.ORIGEM", "CD_ORIGEM")
                    SqlText = DBMontar_Insert("ORIGEM", TipoCampoFixo.Todos, "NO_ORIGEM", ":NO_ORIGEM", _
                                                                                   "CD_ORIGEM", ":CD_ORIGEM")
                Else
                    CdOrigem = e.Row.Cells(cnt_GridOrigem_Codigo).Value

                    SqlText = DBMontar_Update("ORIGEM", GerarArray("NO_ORIGEM", ":NO_ORIGEM"), _
                                                              GerarArray("CD_ORIGEM", ":CD_ORIGEM"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_ORIGEM", e.Row.Cells(cnt_GridOrigem_Nome).Value), _
                                           DBParametro_Montar("CD_ORIGEM", CdOrigem)) Then GoTo Erro
            Case eCadastroListagemGeral.LocalEntrega
                Dim CdLocalEntrega As Integer

                If CampoNulo(e.Row.Cells(cnt_GridLocalEntrega_Codigo).Value) Then
                    CdLocalEntrega = DBNumeroMaisUm("SOF.LOCAL_ENTREGA", "CD_LOCAL_ENTREGA")

                    SqlText = DBMontar_Insert("LOCAL_ENTREGA", TipoCampoFixo.Todos, "IC_ATIVO", ":IC_ATIVO", _
                                                                                    "NO_LOCAL_ENTREGA", ":NO_LOCAL_ENTREGA", _
                                                                                   "CD_LOCAL_ENTREGA", ":CD_LOCAL_ENTREGA")
                Else
                    CdLocalEntrega = e.Row.Cells(cnt_GridLocalEntrega_Codigo).Value

                    SqlText = DBMontar_Update("LOCAL_ENTREGA", GerarArray("IC_ATIVO", ":IC_ATIVO", _
                                                                          "NO_LOCAL_ENTREGA", ":NO_LOCAL_ENTREGA"), _
                                                              GerarArray("CD_LOCAL_ENTREGA", ":CD_LOCAL_ENTREGA"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("IC_ATIVO", objGrid_CheckCol_Valor(grdGeral, cnt_GridLocalEntrega_Ativo, e.Row.Index)), _
                                           DBParametro_Montar("NO_LOCAL_ENTREGA", e.Row.Cells(cnt_GridLocalEntrega_Nome).Value), _
                                           DBParametro_Montar("CD_LOCAL_ENTREGA", CdLocalEntrega)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Adendo
                Dim CdTipoAdendo As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoAdendo_Codigo).Value) Then
                    CdTipoAdendo = DBNumeroMaisUm("SOF.TIPO_ADENDO ", "CD_TIPO_ADENDO")
                    SqlText = DBMontar_Insert("TIPO_ADENDO", TipoCampoFixo.Todos, "DS_TIPO_ADENDO", ":DS_TIPO_ADENDO", _
                                                                                   "CD_TIPO_ADENDO", ":CD_TIPO_ADENDO")
                Else
                    CdTipoAdendo = e.Row.Cells(cnt_GridTipoAdendo_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_ADENDO", GerarArray("DS_TIPO_ADENDO", ":DS_TIPO_ADENDO"), _
                                                              GerarArray("CD_TIPO_ADENDO", ":CD_TIPO_ADENDO"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("DS_TIPO_ADENDO", e.Row.Cells(cnt_GridTipoAdendo_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_ADENDO", CdTipoAdendo)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Cacau
                Dim CdTipoCacau As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoCacau_Codigo).Value) Then
                    CdTipoCacau = DBNumeroMaisUm("SOF.TIPO_CACAU", "CD_TIPO_CACAU")
                    SqlText = DBMontar_Insert("TIPO_CACAU", TipoCampoFixo.Todos, "NO_TIPO_CACAU", ":NO_TIPO_CACAU", _
                                                                                   "CD_TIPO_CACAU", ":CD_TIPO_CACAU")
                Else
                    CdTipoCacau = e.Row.Cells(cnt_GridTipoCacau_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_CACAU", GerarArray("NO_TIPO_CACAU", ":NO_TIPO_CACAU"), _
                                                              GerarArray("CD_TIPO_CACAU", ":CD_TIPO_CACAU"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_TIPO_CACAU", e.Row.Cells(cnt_GridTipoCacau_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_CACAU", CdTipoCacau)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Contato
                Dim CdContato As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoContato_Codigo).Value) Then
                    CdContato = DBNumeroMaisUm("SOF.TIPO_ATENDIMENTO", "CD_TIPO_ATENDIMENTO")
                    SqlText = DBMontar_Insert("TIPO_ATENDIMENTO", TipoCampoFixo.Todos, "NO_TIPO_ATENDIMENTO", ":NO_TIPO_ATENDIMENTO", _
                                                                                   "CD_TIPO_ATENDIMENTO", ":CD_TIPO_ATENDIMENTO")
                Else
                    CdContato = e.Row.Cells(cnt_GridTipoContato_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_ATENDIMENTO", GerarArray("NO_TIPO_ATENDIMENTO", ":NO_TIPO_ATENDIMENTO"), _
                                                              GerarArray("CD_TIPO_ATENDIMENTO", ":CD_TIPO_ATENDIMENTO"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_TIPO_ATENDIMENTO", e.Row.Cells(cnt_GridTipoContato_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_ATENDIMENTO", CdContato)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_ContratoPAF
                Dim CdTipoContratoPAF As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoContratoPAF_Codigo).Value) Then
                    CdTipoContratoPAF = DBNumeroMaisUm("SOF.TIPO_CONTRATO_PAF", "CD_TIPO_CONTRATO_PAF")
                    SqlText = DBMontar_Insert("TIPO_CONTRATO_PAF", TipoCampoFixo.Todos, "NO_TIPO_CONTRATO_PAF", ":NO_TIPO_CONTRATO_PAF", _
                                                                                        "IC_ADIANTAMENTO", ":IC_ADIANTAMENTO", _
                                                                                        "DS_TEXTO_CONTRATO", ":DS_TEXTO_CONTRATO", _
                                                                                   "CD_TIPO_CONTRATO_PAF", ":CD_TIPO_CONTRATO_PAF")
                Else
                    CdTipoContratoPAF = e.Row.Cells(cnt_GridTipoContratoPAF_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_CONTRATO_PAF", GerarArray("NO_TIPO_CONTRATO_PAF", ":NO_TIPO_CONTRATO_PAF", _
                                                                                "IC_ADIANTAMENTO", ":IC_ADIANTAMENTO", _
                                                                                "DS_TEXTO_CONTRATO", ":DS_TEXTO_CONTRATO"), _
                                                              GerarArray("CD_TIPO_CONTRATO_PAF", ":CD_TIPO_CONTRATO_PAF"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_TIPO_CONTRATO_PAF", e.Row.Cells(cnt_GridTipoContratoPAF_Nome).Value), _
                                           DBParametro_Montar("IC_ADIANTAMENTO", objGrid_CheckCol_Valor(grdGeral, cnt_GridTipoContratoPAF_Adiantamento, e.Row.Index)), _
                                           DBParametro_Montar("DS_TEXTO_CONTRATO", e.Row.Cells(cnt_GridTipoContratoPAF_TextoContrato).Value, OracleClient.OracleType.VarChar, , 4000), _
                                           DBParametro_Montar("CD_TIPO_CONTRATO_PAF", CdTipoContratoPAF)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Frete
                Dim CdTipoFrete As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoFrete_Codigo).Value) Then
                    CdTipoFrete = DBNumeroMaisUm("SOF.TIPO_FRETE", "CD_TIPO_FRETE")
                    SqlText = DBMontar_Insert("TIPO_FRETE", TipoCampoFixo.Todos, "NO_TIPO_FRETE", ":NO_TIPO_FRETE", _
                                                                                   "CD_TIPO_FRETE", ":CD_TIPO_FRETE")
                Else
                    CdTipoFrete = e.Row.Cells(cnt_GridTipoFrete_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_FRETE", GerarArray("NO_TIPO_FRETE", ":NO_TIPO_FRETE"), _
                                                              GerarArray("CD_TIPO_FRETE", ":CD_TIPO_FRETE"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_TIPO_FRETE", e.Row.Cells(cnt_GridTipoFrete_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_FRETE", CdTipoFrete)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Frestista
                Dim CdTipoFretista As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoFretista_Codigo).Value) Then
                    CdTipoFretista = DBNumeroMaisUm("SOF.TIPO_FRETISTA", "CD_TIPO_FRETISTA")
                    SqlText = DBMontar_Insert("TIPO_FRETISTA", TipoCampoFixo.Todos, "NO_TIPO_FRETISTA", ":NO_TIPO_FRETISTA", _
                                                                                   "CD_TIPO_FRETISTA", ":CD_TIPO_FRETISTA")
                Else
                    CdTipoFretista = e.Row.Cells(cnt_GridTipoFretista_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_FRETISTA", GerarArray("NO_TIPO_FRETISTA", ":NO_TIPO_FRETISTA"), _
                                                              GerarArray("CD_TIPO_FRETISTA", ":CD_TIPO_FRETISTA"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_TIPO_FRETISTA", e.Row.Cells(cnt_GridTipoFretista_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_FRETISTA", CdTipoFretista)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Movimentacao_Sacaria
                Dim CD_TIPO_MOVIMENTACAO As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoFretista_Codigo).Value) Then
                    CD_TIPO_MOVIMENTACAO = DBNumeroMaisUm("SOF.SACARIA_TIPO_MOVIMENTACAO", "CD_TIPO_MOVIMENTACAO")

                    SqlText = DBMontar_Insert("SACARIA_TIPO_MOVIMENTACAO", TipoCampoFixo.Todos, _
                                                                           "NO_TIPO_MOVIMENTACAO", ":NO_TIPO_MOVIMENTACAO", _
                                                                           "CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO")
                Else
                    CD_TIPO_MOVIMENTACAO = e.Row.Cells(cnt_GridTipoMovimentacaoSacaria_Codigo).Value

                    SqlText = DBMontar_Update("SACARIA_TIPO_MOVIMENTACAO", GerarArray("NO_TIPO_MOVIMENTACAO", ":NO_TIPO_MOVIMENTACAO"), _
                                                                           GerarArray("CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_TIPO_MOVIMENTACAO", e.Row.Cells(cnt_GridTipoMovimentacaoSacaria_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_MOVIMENTACAO", CD_TIPO_MOVIMENTACAO)) Then GoTo Erro
            Case eCadastroListagemGeral.Provisoes
                Dim CdProvisao As Integer

                If CampoNulo(e.Row.Cells(cnt_GridProvisao_Codigo).Value) Then
                    CdProvisao = DBNumeroMaisUm("SOF.PROVISAO", "CD_PROVISAO")

                    SqlText = DBMontar_Insert("PROVISAO", TipoCampoFixo.Todos, "IC_CALC_SUBALIQ", ":IC_CALC_SUBALIQ", _
                                                                               "CONTA_CONTABIL", ":CONTA_CONTABIL", _
                                                                               "NO_PROVISAO", ":NO_PROVISAO", _
                                                                               "CD_PROVISAO", ":CD_PROVISAO")
                Else
                    CdProvisao = e.Row.Cells(cnt_GridProvisao_Codigo).Value

                    SqlText = DBMontar_Update("PROVISAO", GerarArray("IC_CALC_SUBALIQ", ":IC_CALC_SUBALIQ", _
                                                                     "CONTA_CONTABIL", ":CONTA_CONTABIL", _
                                                                     "NO_PROVISAO", ":NO_PROVISAO"), _
                                                          GerarArray("CD_PROVISAO", ":CD_PROVISAO"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("IC_CALC_SUBALIQ", objGrid_CheckCol_Valor(grdGeral, cnt_GridProvisao_CalculaSubAliquota, e.Row.Index)), _
                                           DBParametro_Montar("CONTA_CONTABIL", e.Row.Cells(cnt_GridProvisao_ContaContabil).Value), _
                                           DBParametro_Montar("NO_PROVISAO", e.Row.Cells(cnt_GridProvisao_Nome).Value), _
                                           DBParametro_Montar("CD_PROVISAO", CdProvisao)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Aprovacao
                Dim CdTipoAprovacao As Integer


                If CampoNulo(e.Row.Cells(cnt_GridTipoAprovador_Codigo).Value) Then
                    CdTipoAprovacao = DBNumeroMaisUm("SOF.TIPO_APROVACAO", "CD_TIPO_APROVACAO")

                    SqlText = DBMontar_Insert("TIPO_APROVACAO", TipoCampoFixo.Todos, _
                                                                            "IC_LIBERA_NEGOCIACAO", ":IC_LIBERA_NEGOCIACAO", _
                                                                            "IC_OBRIGATORIO", ":IC_OBRIGATORIO", _
                                                                            "IC_POSSUI_LIMITE", ":IC_POSSUI_LIMITE", _
                                                                           "NO_TIPO_APROVACAO", ":NO_TIPO_APROVACAO", _
                                                                           "CD_TIPO_APROVACAO", ":CD_TIPO_APROVACAO")
                Else
                    CdTipoAprovacao = e.Row.Cells(cnt_GridTipoAprovador_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_APROVACAO", GerarArray("IC_LIBERA_NEGOCIACAO", ":IC_LIBERA_NEGOCIACAO", _
                                                                        "IC_OBRIGATORIO", ":IC_OBRIGATORIO", _
                                                                            "IC_POSSUI_LIMITE", ":IC_POSSUI_LIMITE", _
                                                                            "NO_TIPO_APROVACAO", ":NO_TIPO_APROVACAO"), _
                                                                           GerarArray("CD_TIPO_APROVACAO", ":CD_TIPO_APROVACAO"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("IC_LIBERA_NEGOCIACAO", objGrid_CheckCol_Valor(grdGeral, cnt_GridTipoAprovador_LiberaNegociacao, e.Row.Index)), _
                                           DBParametro_Montar("IC_OBRIGATORIO", objGrid_CheckCol_Valor(grdGeral, cnt_GridTipoAprovador_Obrigatorio, e.Row.Index)), _
                                           DBParametro_Montar("IC_POSSUI_LIMITE", objGrid_CheckCol_Valor(grdGeral, cnt_GridTipoAprovador_PossuiLimite, e.Row.Index)), _
                                           DBParametro_Montar("NO_TIPO_APROVACAO", e.Row.Cells(cnt_GridTipoAprovador_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_APROVACAO", CdTipoAprovacao)) Then GoTo Erro
            Case eCadastroListagemGeral.Armazem
                Dim CdArmazem As Integer


                If CampoNulo(e.Row.Cells(cnt_GridArmazem_Codigo).Value) Then
                    CdArmazem = DBNumeroMaisUm("SOF.ARMAZEM", "CD_ARMAZEM")

                    SqlText = DBMontar_Insert("ARMAZEM", TipoCampoFixo.Todos, _
                                                                            "IC_ATIVO", ":IC_ATIVO", _
                                                                            "CD_FILIAL_ORIGEM", ":CD_FILIAL_ORIGEM", _
                                                                           "NO_ARMAZEM", ":NO_ARMAZEM", _
                                                                           "CD_ARMAZEM", ":CD_ARMAZEM")
                Else
                    CdArmazem = e.Row.Cells(cnt_GridArmazem_Codigo).Value

                    SqlText = DBMontar_Update("ARMAZEM", GerarArray("IC_ATIVO", ":IC_ATIVO", _
                                                                            "CD_FILIAL_ORIGEM", ":CD_FILIAL_ORIGEM", _
                                                                            "NO_ARMAZEM", ":NO_ARMAZEM"), _
                                                                           GerarArray("CD_ARMAZEM", ":CD_ARMAZEM"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("IC_ATIVO", objGrid_CheckCol_Valor(grdGeral, cnt_GridArmazem_Ativo, e.Row.Index)), _
                                           DBParametro_Montar("CD_FILIAL_ORIGEM", e.Row.Cells(cnt_GridArmazem_Filial).Value), _
                                           DBParametro_Montar("NO_ARMAZEM", e.Row.Cells(cnt_GridArmazem_Nome).Value), _
                                           DBParametro_Montar("CD_ARMAZEM", CdArmazem)) Then GoTo Erro
            Case eCadastroListagemGeral.Modalidade_Recuperacao_Credito
                Dim CdModalidadeRecuperacao As Integer

                If CampoNulo(e.Row.Cells(cnt_GridModalidadeRecuperacaoCredito_Codigo).Value) Then
                    CdModalidadeRecuperacao = DBNumeroMaisUm("SOF.CONFISSAO_DIVIDA_MODALIDADE", "CD_CONFISSAO_DIVIDA_MODALIDADE")

                    SqlText = DBMontar_Insert("CONFISSAO_DIVIDA_MODALIDADE", TipoCampoFixo.Todos, _
                                                                           "NO_CONFISSAO_DIVIDA_MODALIDADE", ":NO_CONFISSAO_DIVIDA_MODALIDADE", _
                                                                           "CD_CONFISSAO_DIVIDA_MODALIDADE", ":CD_CONFISSAO_DIVIDA_MODALIDADE")
                Else
                    CdModalidadeRecuperacao = e.Row.Cells(cnt_GridModalidadeRecuperacaoCredito_Codigo).Value

                    SqlText = DBMontar_Update("CONFISSAO_DIVIDA_MODALIDADE", GerarArray("NO_CONFISSAO_DIVIDA_MODALIDADE", ":NO_CONFISSAO_DIVIDA_MODALIDADE"), _
                                                                           GerarArray("CD_CONFISSAO_DIVIDA_MODALIDADE", ":CD_CONFISSAO_DIVIDA_MODALIDADE"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_CONFISSAO_DIVIDA_MODALIDADE", e.Row.Cells(cnt_GridModalidadeRecuperacaoCredito_Nome).Value), _
                                           DBParametro_Montar("CD_CONFISSAO_DIVIDA_MODALIDADE", CdModalidadeRecuperacao)) Then GoTo Erro
            Case eCadastroListagemGeral.Procedencia
                If DBQuery_ValorUnico("SELECT COUNT(*) FROM SOF.PROCEDENCIA WHERE CD_PROCEDENCIA='" & e.Row.Cells(cnt_GridProcedencia_Codigo).Value & "'") = 0 Then
                    SqlText = DBMontar_Insert("PROCEDENCIA", TipoCampoFixo.Todos, _
                                                                            "CD_ORIGEM", ":CD_ORIGEM", _
                                                                           "NO_PROCEDENCIA", ":NO_PROCEDENCIA", _
                                                                           "CD_PROCEDENCIA", ":CD_PROCEDENCIA")
                Else
                    SqlText = DBMontar_Update("PROCEDENCIA", GerarArray("CD_ORIGEM", ":CD_ORIGEM", _
                                                                            "NO_PROCEDENCIA", ":NO_PROCEDENCIA"), _
                                                                           GerarArray("CD_PROCEDENCIA", ":CD_PROCEDENCIA"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("CD_ORIGEM", e.Row.Cells(cnt_GridProcedencia_Origem).Value), _
                                           DBParametro_Montar("NO_PROCEDENCIA", e.Row.Cells(cnt_GridProcedencia_Nome).Value), _
                                           DBParametro_Montar("CD_PROCEDENCIA", e.Row.Cells(cnt_GridProcedencia_Codigo).Value)) Then GoTo Erro
            Case eCadastroListagemGeral.Safra
                Dim CdSafra As Integer

                If CampoNulo(e.Row.Cells(cnt_GridSafra_Codigo).Value) Then
                    CdSafra = DBNumeroMaisUm("SOF.SAFRA", "CD_SAFRA")

                    SqlText = DBMontar_Insert("SAFRA", TipoCampoFixo.Todos, _
                                                                            "IC_VALIDO", ":IC_VALIDO", _
                                                                           "DS_SAFRA", ":DS_SAFRA", _
                                                                           "CD_SAFRA", ":CD_SAFRA")
                Else
                    CdSafra = e.Row.Cells(cnt_GridSafra_Codigo).Value

                    SqlText = DBMontar_Update("SAFRA", GerarArray("IC_VALIDO", ":IC_VALIDO", _
                                                                            "DS_SAFRA", ":DS_SAFRA"), _
                                                                           GerarArray("CD_SAFRA", ":CD_SAFRA"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("IC_VALIDO", objGrid_CheckCol_Valor(grdGeral, cnt_GridSafra_Valido, e.Row.Index)), _
                                           DBParametro_Montar("DS_SAFRA", e.Row.Cells(cnt_GridSafra_Nome).Value), _
                                           DBParametro_Montar("CD_SAFRA", CdSafra)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Acondicionamento
                Dim CDTIPOACONDICIONAMENTO As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoAcondicionamento_Codigo).Value) Then
                    CDTIPOACONDICIONAMENTO = DBNumeroMaisUm("SOF.TIPO_ACONDICIONAMENTO", "CD_TIPO_ACONDICIONAMENTO")

                    SqlText = DBMontar_Insert("TIPO_ACONDICIONAMENTO", TipoCampoFixo.Todos, _
                                                                            "DS_TEXTO_CONTRATO", ":DS_TEXTO_CONTRATO", _
                                                                           "NO_TIPO_ACONDICIONAMENTO", ":NO_TIPO_ACONDICIONAMENTO", _
                                                                           "CD_TIPO_ACONDICIONAMENTO", ":CD_TIPO_ACONDICIONAMENTO")
                Else
                    CDTIPOACONDICIONAMENTO = e.Row.Cells(cnt_GridTipoAcondicionamento_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_ACONDICIONAMENTO", GerarArray("DS_TEXTO_CONTRATO", ":DS_TEXTO_CONTRATO", _
                                                                            "NO_TIPO_ACONDICIONAMENTO", ":NO_TIPO_ACONDICIONAMENTO"), _
                                                                           GerarArray("CD_TIPO_ACONDICIONAMENTO", ":CD_TIPO_ACONDICIONAMENTO"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("DS_TEXTO_CONTRATO", e.Row.Cells(cnt_GridTipoAcondicionamento_TextoContrato).Value, OracleClient.OracleType.VarChar, , 1000), _
                                           DBParametro_Montar("NO_TIPO_ACONDICIONAMENTO", e.Row.Cells(cnt_GridTipoAcondicionamento_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_ACONDICIONAMENTO", CDTIPOACONDICIONAMENTO)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Sacaria
                Dim CdTipoSacaria As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoSacaria_Codigo).Value) Then
                    CdTipoSacaria = DBNumeroMaisUm("SOF.TIPO_SACARIA", "CD_TIPO_SACARIA")

                    SqlText = DBMontar_Insert("TIPO_SACARIA", TipoCampoFixo.Todos, _
                                                                            "IC_ATIVO", ":IC_ATIVO", _
                                                                            "IC_CONTABILIZA_FORNECEDOR", ":IC_CONTABILIZA_FORNECEDOR", _
                                                                            "VL_PRECO", ":VL_PRECO", _
                                                                            "VL_PESO", ":VL_PESO", _
                                                                           "NO_TIPO_SACARIA", ":NO_TIPO_SACARIA", _
                                                                           "CD_TIPO_SACARIA", ":CD_TIPO_SACARIA")
                Else
                    CdTipoSacaria = e.Row.Cells(cnt_GridTipoSacaria_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_SACARIA", GerarArray("IC_ATIVO", ":IC_ATIVO", _
                                                                            "IC_CONTABILIZA_FORNECEDOR", ":IC_CONTABILIZA_FORNECEDOR", _
                                                                            "VL_PRECO", ":VL_PRECO", _
                                                                            "VL_PESO", ":VL_PESO", _
                                                                            "NO_TIPO_SACARIA", ":NO_TIPO_SACARIA"), _
                                                                           GerarArray("CD_TIPO_SACARIA", ":CD_TIPO_SACARIA"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("IC_ATIVO", objGrid_CheckCol_Valor(grdGeral, cnt_GridTipoSacaria_Ativo, e.Row.Index)), _
                                           DBParametro_Montar("IC_CONTABILIZA_FORNECEDOR", objGrid_CheckCol_Valor(grdGeral, cnt_GridTipoSacaria_ContabilizaFornecedor, e.Row.Index)), _
                                           DBParametro_Montar("VL_PRECO", e.Row.Cells(cnt_GridTipoSacaria_Preco).Value), _
                                           DBParametro_Montar("VL_PESO", e.Row.Cells(cnt_GridTipoSacaria_Peso).Value), _
                                           DBParametro_Montar("NO_TIPO_SACARIA", e.Row.Cells(cnt_GridTipoSacaria_Nome).Value), _
                                           DBParametro_Montar("CD_TIPO_SACARIA", CdTipoSacaria)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Inovacao
                Dim CDTIPOINOVACAO As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoInovacao_Codigo).Value) Then
                    CDTIPOINOVACAO = DBNumeroMaisUm("SOF.TIPO_INOVACAO", "CD_TIPO_INOVACAO")

                    SqlText = DBMontar_Insert("TIPO_INOVACAO", TipoCampoFixo.Todos, _
                                                                           "NO_TIPO_INOVACAO", ":NO_TIPO_INOVACAO", _
                                                                           "CD_TIPO_INOVACAO", ":CD_TIPO_INOVACAO")
                Else
                    CDTIPOINOVACAO = e.Row.Cells(cnt_GridTipoInovacao_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_INOVACAO", GerarArray("NO_TIPO_INOVACAO", ":NO_TIPO_INOVACAO"), _
                                                                           GerarArray("CD_TIPO_INOVACAO", ":CD_TIPO_INOVACAO"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_TIPO_INOVACAO", e.Row.Cells(cnt_GridTipoInovacao_Nome).Value), _
                                                    DBParametro_Montar("CD_TIPO_INOVACAO", CDTIPOINOVACAO)) Then GoTo Erro
            Case eCadastroListagemGeral.ContaCorrente
                SqlText = "SELECT COUNT(*) FROM SOF.BANCO WHERE CD_BANCO = " & e.Row.Cells(cnt_GridContaCorrente_Codigo).Value

                If DBQuery_ValorUnico(SqlText) = 0 Then
                    SqlText = DBMontar_Insert("BANCO", TipoCampoFixo.Todos, "CD_FILIAL_ORIGEM", ":CD_FILIAL_ORIGEM", _
                                                                            "NU_CONTA_CONTABIL", ":NU_CONTA_CONTABIL", _
                                                                            "NU_CONTA_CORRENTE", ":NU_CONTA_CORRENTE", _
                                                                            "NU_AGENCIA", ":NU_AGENCIA", _
                                                                            "NU_BANCO", ":NU_BANCO", _
                                                                            "NU_ULTIMO_CHEQUE", ":NU_ULTIMO_CHEQUE", _
                                                                            "NO_BANCO", ":NO_BANCO", _
                                                                            "IC_ATIVO", ":IC_ATIVO", _
                                                                            "CD_BANCO", ":CD_BANCO")
                Else
                    SqlText = DBMontar_Update("BANCO", GerarArray("CD_FILIAL_ORIGEM", ":CD_FILIAL_ORIGEM", _
                                                                  "NU_CONTA_CONTABIL", ":NU_CONTA_CONTABIL", _
                                                                  "NU_CONTA_CORRENTE", ":NU_CONTA_CORRENTE", _
                                                                  "NU_AGENCIA", ":NU_AGENCIA", _
                                                                  "NU_BANCO", ":NU_BANCO", _
                                                                  "NU_ULTIMO_CHEQUE", ":NU_ULTIMO_CHEQUE", _
                                                                  "NO_BANCO", ":NO_BANCO", _
                                                                  "IC_ATIVO", ":IC_ATIVO"), _
                                                       GerarArray("CD_BANCO", ":CD_BANCO"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("CD_FILIAL_ORIGEM", e.Row.Cells(cnt_GridContaCorrente_Filial).Value), _
                                           DBParametro_Montar("NU_CONTA_CONTABIL", e.Row.Cells(cnt_GridContaCorrente_ContaContabil).Value), _
                                           DBParametro_Montar("NU_CONTA_CORRENTE", e.Row.Cells(cnt_GridContaCorrente_ContaCorrente).Value), _
                                           DBParametro_Montar("NU_AGENCIA", e.Row.Cells(cnt_GridContaCorrente_Agencia).Value), _
                                           DBParametro_Montar("NU_BANCO", e.Row.Cells(cnt_GridContaCorrente_NumeroBanco).Value), _
                                           DBParametro_Montar("NU_ULTIMO_CHEQUE", e.Row.Cells(cnt_GridContaCorrente_UltimoCheque).Value), _
                                           DBParametro_Montar("NO_BANCO", e.Row.Cells(cnt_GridContaCorrente_Nome).Value), _
                                           DBParametro_Montar("IC_ATIVO", objGrid_CheckCol_Valor(grdGeral, cnt_GridContaCorrente_Ativo, e.Row.Index)), _
                                           DBParametro_Montar("CD_BANCO", e.Row.Cells(cnt_GridContaCorrente_Codigo).Value)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Negociacao
                Dim CdTipoNegociacao As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoInovacao_Codigo).Value) Then
                    CdTipoNegociacao = DBNumeroMaisUm("SOF.TIPO_NEGOCIACAO", "CD_TIPO_NEGOCIACAO")
                    SqlText = DBMontar_Insert("TIPO_NEGOCIACAO", TipoCampoFixo.Todos, _
                                                                                "no_tipo_negociacao", ":no_tipo_negociacao", _
                                                                                "ic_tipo_preco_fixo", ":ic_tipo_preco_fixo", _
                                                                                "ic_bolsa", ":ic_bolsa", _
                                                                                "ic_dolar", ":ic_dolar", _
                                                                                "ic_bolsa_operacao", ":ic_bolsa_operacao", _
                                                                                "cd_tipo_preco", ":cd_tipo_preco", _
                                                                                "ds_texto_contrato", ":ds_texto_contrato", _
                                                                                "qt_dia_venc_padrao", ":qt_dia_venc_padrao", _
                                                                                "cd_tipo_negociacao", ":cd_tipo_negociacao")
                Else
                    CdTipoNegociacao = e.Row.Cells(cnt_GridTipoNegociacao_Codigo).Value
                    SqlText = DBMontar_Update("TIPO_NEGOCIACAO", GerarArray("no_tipo_negociacao", ":no_tipo_negociacao", _
                                                                            "ic_tipo_preco_fixo", ":ic_tipo_preco_fixo", _
                                                                            "ic_bolsa", ":ic_bolsa", _
                                                                            "ic_dolar", ":ic_dolar", _
                                                                            "ic_bolsa_operacao", ":ic_bolsa_operacao", _
                                                                            "cd_tipo_preco", ":cd_tipo_preco", _
                                                                            "ds_texto_contrato", ":ds_texto_contrato", _
                                                                            "qt_dia_venc_padrao", ":qt_dia_venc_padrao"), _
                                                                           GerarArray("cd_tipo_negociacao", ":cd_tipo_negociacao"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("no_tipo_negociacao", e.Row.Cells(cnt_GridTipoNegociacao_Descricao).Value), _
                                           DBParametro_Montar("ic_tipo_preco_fixo", IIf(e.Row.Cells(cnt_GridTipoNegociacao_Tipo).Value = "P", "S", "N")), _
                                           DBParametro_Montar("ic_bolsa", IIf(e.Row.Cells(cnt_GridTipoNegociacao_Tipo).Value = "B", "S", "N")), _
                                           DBParametro_Montar("ic_dolar", IIf(e.Row.Cells(cnt_GridTipoNegociacao_Tipo).Value = "D", "S", "N")), _
                                           DBParametro_Montar("ic_bolsa_operacao", e.Row.Cells(cnt_GridTipoNegociacao_Operacao).Value), _
                                           DBParametro_Montar("cd_tipo_preco", IIf(e.Row.Cells(cnt_GridTipoNegociacao_Tipo).Value = "P", 1, 2)), _
                                           DBParametro_Montar("ds_texto_contrato", e.Row.Cells(cnt_GridTipoNegociacao_Texto).Value, OracleClient.OracleType.VarChar, , 1000), _
                                           DBParametro_Montar("qt_dia_venc_padrao", e.Row.Cells(cnt_GridTipoNegociacao_Qt_Dia_Venc_Padrao).Value), _
                                           DBParametro_Montar("cd_tipo_negociacao", CdTipoNegociacao)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Garantia
                Dim CdTipoGarantia As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoContratoPAF_Codigo).Value) Then
                    CdTipoGarantia = DBNumeroMaisUm("SOF.TIPO_GARANTIA", "CD_TIPO_GARANTIA")

                    SqlText = DBMontar_Insert("TIPO_GARANTIA", TipoCampoFixo.Todos, "NO_TIPO_GARANTIA", ":NO_TIPO_GARANTIA", _
                                                                                        "VL_LIMITE_GARANTIA", ":VL_LIMITE_GARANTIA", _
                                                                                        "IC_DESCRICAO", ":IC_DESCRICAO", _
                                                                                        "IC_PROVISORIA", ":IC_PROVISORIA", _
                                                                                        "IC_GARANTIDO", ":IC_GARANTIDO", _
                                                                                        "QT_DIAS_PRAZO_MAX", ":QT_DIAS_PRAZO_MAX", _
                                                                                   "CD_TIPO_GARANTIA", ":CD_TIPO_GARANTIA")
                Else
                    CdTipoGarantia = e.Row.Cells(cnt_GridTipoGarantia_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_GARANTIA", GerarArray("NO_TIPO_GARANTIA", ":NO_TIPO_GARANTIA", _
                                                                          "VL_LIMITE_GARANTIA", ":VL_LIMITE_GARANTIA", _
                                                                          "IC_DESCRICAO", ":IC_DESCRICAO", _
                                                                          "IC_PROVISORIA", ":IC_PROVISORIA", _
                                                                          "IC_GARANTIDO", ":IC_GARANTIDO", _
                                                                          "QT_DIAS_PRAZO_MAX", ":QT_DIAS_PRAZO_MAX"), _
                                                              GerarArray("CD_TIPO_GARANTIA", ":CD_TIPO_GARANTIA"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_TIPO_GARANTIA", e.Row.Cells(cnt_GridTipoGarantia_Descricao).Value), _
                                           DBParametro_Montar("VL_LIMITE_GARANTIA", e.Row.Cells(cnt_GridTipoGarantia_ValorLimite).Value), _
                                           DBParametro_Montar("IC_DESCRICAO", objGrid_CheckCol_Valor(grdGeral, cnt_GridTipoGarantia_IcDescricao, e.Row.Index)), _
                                           DBParametro_Montar("IC_PROVISORIA", objGrid_CheckCol_Valor(grdGeral, cnt_GridTipoGarantia_IcProvisoria, e.Row.Index)), _
                                           DBParametro_Montar("IC_GARANTIDO", objGrid_CheckCol_Valor(grdGeral, cnt_GridTipoGarantia_IcGarantido, e.Row.Index)), _
                                           DBParametro_Montar("QT_DIAS_PRAZO_MAX", IIf(NVL(e.Row.Cells(cnt_GridTipoGarantia_IcPrazo).Value, 0) = 1, Val(NVL(e.Row.Cells(cnt_GridTipoGarantia_QtDias).Value, 0)), Nothing)), _
                                           DBParametro_Montar("CD_TIPO_GARANTIA", CdTipoGarantia)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Desconto_Qualidade
                Dim CdTipoDescontoQualidade As Integer

                If CampoNulo(e.Row.Cells(cnt_GridTipoContratoPAF_Codigo).Value) Then
                    CdTipoDescontoQualidade = DBNumeroMaisUm("SOF.TIPO_DESCONTO_QUALIDADE", "CD_TIPO_DESCONTO_QUALIDADE")

                    SqlText = DBMontar_Insert("TIPO_DESCONTO_QUALIDADE", TipoCampoFixo.Todos, "NO_TIPO_DESCONTO_QUALIDADE", ":NO_TIPO_DESCONTO_QUALIDADE", _
                                                                                        "IC_ATIVO", ":IC_ATIVO", _
                                                                                        "VL_MAXIMO_PERMITIDO", ":VL_MAXIMO_PERMITIDO", _
                                                                                        "DS_CAMPO_QUALIDADE", ":DS_CAMPO_QUALIDADE", _
                                                                                        "NO_CAMPO_QUALIDADE", ":NO_CAMPO_QUALIDADE", _
                                                                                        "CD_TIPO_PAGAMENTO", ":CD_TIPO_PAGAMENTO", _
                                                                                   "CD_TIPO_DESCONTO_QUALIDADE", ":CD_TIPO_DESCONTO_QUALIDADE")
                Else
                    CdTipoDescontoQualidade = e.Row.Cells(cnt_GridTipoGarantia_Codigo).Value

                    SqlText = DBMontar_Update("TIPO_DESCONTO_QUALIDADE", GerarArray("NO_TIPO_DESCONTO_QUALIDADE", ":NO_TIPO_DESCONTO_QUALIDADE", _
                                                                            "IC_ATIVO", ":IC_ATIVO", _
                                                                            "VL_MAXIMO_PERMITIDO", ":VL_MAXIMO_PERMITIDO", _
                                                                            "DS_CAMPO_QUALIDADE", ":DS_CAMPO_QUALIDADE", _
                                                                            "NO_CAMPO_QUALIDADE", ":NO_CAMPO_QUALIDADE", _
                                                                            "CD_TIPO_PAGAMENTO", ":CD_TIPO_PAGAMENTO"), _
                                                              GerarArray("CD_TIPO_DESCONTO_QUALIDADE", ":CD_TIPO_DESCONTO_QUALIDADE"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("NO_TIPO_DESCONTO_QUALIDADE", e.Row.Cells(cnt_GridTipoDescontoQualidade_Nome).Value), _
                                           DBParametro_Montar("IC_ATIVO", objGrid_CheckCol_Valor(grdGeral, cnt_GridTipoDescontoQualidade_Ativo, e.Row.Index)), _
                                           DBParametro_Montar("VL_MAXIMO_PERMITIDO", e.Row.Cells(cnt_GridTipoDescontoQualidade_MaximoPermitido).Value), _
                                           DBParametro_Montar("DS_CAMPO_QUALIDADE", e.Row.Cells(cnt_GridTipoDescontoQualidade_CampoQualidade).Text), _
                                           DBParametro_Montar("NO_CAMPO_QUALIDADE", e.Row.Cells(cnt_GridTipoDescontoQualidade_CampoQualidade).Value), _
                                           DBParametro_Montar("CD_TIPO_PAGAMENTO", e.Row.Cells(cnt_GridTipoDescontoQualidade_TipoPagamento).Value), _
                                           DBParametro_Montar("CD_TIPO_DESCONTO_QUALIDADE", CdTipoDescontoQualidade)) Then GoTo Erro
            Case eCadastroListagemGeral.Tipo_Pessoa_Imposto
                'Verifica se o imposto selecionado já está adicionado ao tipo de pessoa
                SqlText = "SELECT COUNT(*) FROM SOF.PROCESSO_STATUS" & _
                          " WHERE CD_PROCESSO = " & e.Row.Cells(cnt_GridTipoPessoaImposto_Imposto).Value & _
                            " AND CD_STATUS = " & Filtro_01

                If DBQuery_ValorUnico(SqlText) = 0 Then
                    SqlText = DBMontar_Insert("SOF.PROCESSO_STATUS", TipoCampoFixo.DadoCriacao, _
                                                                     "CD_PROCESSO", ":CD_PROCESSO", _
                                                                     "CD_STATUS", ":CD_STATUS", _
                                                                     "IC_STATUS", ":IC_STATUS", _
                                                                     "NO_STATUS", ":NO_STATUS")
                    If Not DBExecutar(SqlText, DBParametro_Montar("CD_PROCESSO", e.Row.Cells(cnt_GridTipoPessoaImposto_Imposto).Value), _
                                               DBParametro_Montar("CD_STATUS", Filtro_01), _
                                               DBParametro_Montar("IC_STATUS", "X"), _
                                               DBParametro_Montar("NO_STATUS", DBQuery_ValorUnico("SELECT NO_TIPO_PESSOA FROM SOF.TIPO_PESSOA WHERE CD_TIPO_PESSOA = " & Filtro_01))) Then GoTo Erro
                End If

                'Cadastra o índice de valor
                SqlText = "SELECT COUNT(*)" & _
                          " FROM SOF.INDICE_VALORES" & _
                          " WHERE CD_PROCESSO = " & e.Row.Cells(cnt_GridTipoPessoaImposto_Imposto).Value & _
                            " AND CD_INDICE = " & Filtro_01 & _
                            " AND TRUNC(DT_INDICE_VALOR) = " & QuotedStr(Date_to_Oracle(e.Row.Cells(cnt_GridTipoPessoaImposto_Data).Value))

                If DBQuery_ValorUnico(SqlText) = 0 Then
                    SqlText = DBMontar_Insert("SOF.INDICE_VALORES", TipoCampoFixo.Todos, _
                                                                    "DT_INDICE_VALOR", ":DT_INDICE_VALOR", _
                                                                    "VL_INDICE", ":VL_INDICE", _
                                                                    "CD_PROCESSO", ":CD_PROCESSO", _
                                                                    "CD_INDICE", ":CD_INDICE")
                Else
                    SqlText = DBMontar_Update("SOF.INDICE_VALORES", GerarArray("DT_INDICE_VALOR", ":DT_INDICE_VALOR", _
                                                                               "VL_INDICE", ":VL_INDICE"), _
                                                                    GerarArray("CD_PROCESSO", ":CD_PROCESSO", "AND", _
                                                                               "CD_INDICE", ":CD_INDICE"))
                End If

                If Not DBExecutar(SqlText, DBParametro_Montar("DT_INDICE_VALOR", e.Row.Cells(cnt_GridTipoPessoaImposto_Data).Value), _
                                           DBParametro_Montar("VL_INDICE", e.Row.Cells(cnt_GridTipoPessoaImposto_Valor).Value), _
                                           DBParametro_Montar("CD_PROCESSO", e.Row.Cells(cnt_GridTipoPessoaImposto_Imposto).Value), _
                                           DBParametro_Montar("CD_INDICE", Filtro_01)) Then GoTo Erro
        End Select

        CarregarDados()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub grdGeral_BeforeCellActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles grdGeral.BeforeCellActivate
        Select Case iTipoTela
            Case eCadastroListagemGeral.Forma_Pagamento
                e.Cancel = (e.Cell.Column.Index = cnt_GridFormaPagamento_Codigo)
            Case eCadastroListagemGeral.Analise
                e.Cancel = (e.Cell.Column.Index = cnt_GridAnalise_Codigo)
            Case eCadastroListagemGeral.Origem
                e.Cancel = (e.Cell.Column.Index = cnt_GridOrigem_Codigo)
            Case eCadastroListagemGeral.LocalEntrega
                e.Cancel = (e.Cell.Column.Index = cnt_GridLocalEntrega_Codigo)
            Case eCadastroListagemGeral.Tipo_Adendo
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoAdendo_Codigo)
            Case eCadastroListagemGeral.Tipo_Cacau
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoCacau_Codigo)
            Case eCadastroListagemGeral.Tipo_Contato
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoContato_Codigo)
            Case eCadastroListagemGeral.Tipo_ContratoPAF
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoContratoPAF_Codigo)
            Case eCadastroListagemGeral.Tipo_Frestista
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoFretista_Codigo)
            Case eCadastroListagemGeral.Tipo_Frete
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoFrete_Codigo)
            Case eCadastroListagemGeral.Tipo_Movimentacao_Sacaria
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoMovimentacaoSacaria_Codigo)
            Case eCadastroListagemGeral.Provisoes
                e.Cancel = (e.Cell.Column.Index = cnt_GridProvisao_Codigo)
            Case eCadastroListagemGeral.Tipo_Aprovacao
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoAprovador_Codigo)
            Case eCadastroListagemGeral.Armazem
                e.Cancel = (e.Cell.Column.Index = cnt_GridArmazem_Codigo)
            Case eCadastroListagemGeral.Modalidade_Recuperacao_Credito
                e.Cancel = (e.Cell.Column.Index = cnt_GridModalidadeRecuperacaoCredito_Codigo Or _
                            e.Cell.Column.Index = cnt_GridModalidadeRecuperacaoCredito_FormaPagamento Or _
                            e.Cell.Column.Index = cnt_GridModalidadeRecuperacaoCredito_TipoPagamento Or _
                            e.Cell.Column.Index = cnt_GridModalidadeRecuperacaoCredito_ModalidadeConciliacao)
            Case eCadastroListagemGeral.Safra
                e.Cancel = (e.Cell.Column.Index = cnt_GridSafra_Codigo)
            Case eCadastroListagemGeral.Tipo_Acondicionamento
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoAcondicionamento_Codigo)
            Case eCadastroListagemGeral.Tipo_Sacaria
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoSacaria_Codigo)
            Case eCadastroListagemGeral.Tipo_Inovacao
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoInovacao_Codigo)
            Case eCadastroListagemGeral.Tipo_Negociacao
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoNegociacao_Codigo)

                If e.Cell.Column.Index = cnt_GridTipoNegociacao_Operacao Then
                    If Trim(NuloParaString(e.Cell.Row.Cells(cnt_GridTipoNegociacao_Tipo).Value)) <> "B" Then
                        e.Cancel = True
                    End If
                End If
            Case eCadastroListagemGeral.Tipo_Garantia
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoInovacao_Codigo)

                If e.Cell.Column.Index = cnt_GridTipoGarantia_QtDias Then
                    If NVL(e.Cell.Row.Cells(cnt_GridTipoGarantia_IcPrazo).Value, 0) <> 1 Then
                        e.Cancel = True
                    End If
                End If
            Case eCadastroListagemGeral.Tipo_Desconto_Qualidade
                e.Cancel = (e.Cell.Column.Index = cnt_GridTipoDescontoQualidade_Codigo)
            Case eCadastroListagemGeral.Tipo_Pessoa_Imposto
                If Not CampoNulo(e.Cell.Row.Cells(cnt_GridTipoPessoaImposto_IndiceValor).Value) Then
                    e.Cancel = True

                    If e.Cell.Row.Cells(cnt_GridTipoPessoaImposto_Data).Value = Now.Date Then
                        If e.Cell.Column.Index = cnt_GridTipoPessoaImposto_Valor Then
                            e.Cancel = False
                        End If
                    End If
                End If
        End Select

        If e.Cancel Then Exit Sub
    End Sub

    Private Sub grdGeral_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdGeral.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        e.Cancel = (Not Excluir(e.Rows(0)))
    End Sub

    Private Function Excluir(ByVal oRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As Boolean
        Dim sMens As String

        Try
            sMens = "Deseja excluir"

            Select Case iTipoTela
                Case eCadastroListagemGeral.Estado_Civil
                    sMens = sMens & " o Estado Civil " & oRow.Cells(cnt_GridEstadoCivil_Nome).Value & "?"
                Case eCadastroListagemGeral.Funrural
                    sMens = sMens & " o Tipo de Funrural " & oRow.Cells(cnt_GridFunrural_Nome).Value & "?"
                Case eCadastroListagemGeral.Municipios
                    sMens = sMens & " o Município " & oRow.Cells(cnt_GridMunicipio_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Capital
                    sMens = sMens & " o Tipo de Capital " & oRow.Cells(cnt_GridTipoCapital_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Pessoa
                    sMens = sMens & " o Tipo de Pessoa " & oRow.Cells(cnt_GridTipoPessoa_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Pessoa_Tributacao
                    sMens = sMens & " o Tipo Pessoa Tributação " & oRow.Cells(cnt_GridTipoPessoaTributacao_Nome).Value & "?"
                Case eCadastroListagemGeral.UF
                    sMens = sMens & " a UF " & oRow.Cells(cnt_GridUF_Nome).Value & "?"
                Case eCadastroListagemGeral.Forma_Pagamento
                    sMens = sMens & " a Forma de Pagamento " & oRow.Cells(cnt_GridFormaPagamento_Nome).Value & "?"
                Case eCadastroListagemGeral.Analise
                    sMens = sMens & " a Analise " & oRow.Cells(cnt_GridAnalise_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_NF
                    sMens = sMens & " o Tipo NF " & oRow.Cells(cnt_GridTipoNF_Nome).Value & "?"
                Case eCadastroListagemGeral.Origem
                    sMens = sMens & " a Origem " & oRow.Cells(cnt_GridOrigem_Nome).Value & "?"
                Case eCadastroListagemGeral.LocalEntrega
                    sMens = sMens & " o Local de Entrega " & oRow.Cells(cnt_GridLocalEntrega_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Adendo
                    sMens = sMens & " o Tipo de Adendo " & oRow.Cells(cnt_GridTipoAdendo_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Cacau
                    sMens = sMens & " o Tipo de Cacau " & oRow.Cells(cnt_GridTipoCacau_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Contato
                    sMens = sMens & " o Tipo de Contato " & oRow.Cells(cnt_GridTipoContato_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_ContratoPAF
                    sMens = sMens & " o Tipo Contrato PAF " & oRow.Cells(cnt_GridTipoContratoPAF_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Frestista
                    sMens = sMens & " o Tipo Fretista " & oRow.Cells(cnt_GridTipoFretista_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Frete
                    sMens = sMens & " o Tipo Frete " & oRow.Cells(cnt_GridTipoFrete_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Movimentacao_Sacaria
                    sMens = sMens & " o Tipo de Movimentação de Sacaria " & oRow.Cells(cnt_GridTipoSacaria_Nome).Value & "?"
                Case eCadastroListagemGeral.Provisoes
                    sMens = sMens & " a Provisão " & oRow.Cells(cnt_GridProvisao_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Aprovacao
                    sMens = sMens & " o Tipo Aprovação " & oRow.Cells(cnt_GridTipoAprovador_Nome).Value & "?"
                Case eCadastroListagemGeral.Armazem
                    sMens = sMens & " o Armazem " & oRow.Cells(cnt_GridArmazem_Nome).Value & "?"
                Case eCadastroListagemGeral.Modalidade_Recuperacao_Credito
                    sMens = sMens & " a Modalidade Recuperação de Crédito " & oRow.Cells(cnt_GridModalidadeRecuperacaoCredito_Nome).Value & "?"
                Case eCadastroListagemGeral.Procedencia
                    sMens = sMens & " a procedência " & oRow.Cells(cnt_GridProcedencia_Nome).Value & "?"
                Case eCadastroListagemGeral.Safra
                    sMens = sMens & " a Safra " & oRow.Cells(cnt_GridSafra_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Acondicionamento
                    sMens = sMens & " o Tipo Acondicionamento " & oRow.Cells(cnt_GridTipoAcondicionamento_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Sacaria
                    sMens = sMens & " o Tipo de Sacaria " & oRow.Cells(cnt_GridTipoSacaria_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Inovacao
                    sMens = sMens & " o Tipo de Inovação " & oRow.Cells(cnt_GridTipoInovacao_Nome).Value & "?"
                Case eCadastroListagemGeral.ContaCorrente
                    sMens = sMens & " a conta corrente " & oRow.Cells(cnt_GridContaCorrente_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Negociacao
                    sMens = sMens & " o tipo negociação " & oRow.Cells(cnt_GridTipoNegociacao_Descricao).Value & "?"
                Case eCadastroListagemGeral.Tipo_Garantia
                    sMens = sMens & " o tipo garantia " & oRow.Cells(cnt_GridTipoGarantia_Descricao).Value & "?"
                Case eCadastroListagemGeral.Tipo_Desconto_Qualidade
                    sMens = sMens & " o tipo desconto qualidade " & oRow.Cells(cnt_GridTipoDescontoQualidade_Nome).Value & "?"
                Case eCadastroListagemGeral.Tipo_Desconto_Qualidade
                    sMens = sMens & " o valor do imposto " & oRow.Cells(cnt_GridTipoPessoaImposto_Imposto).Text  & "?"
            End Select

            If Msg_Perguntar(sMens) Then
                Select Case iTipoTela
                    Case eCadastroListagemGeral.Estado_Civil
                        If Not CampoNulo(oRow.Cells(cnt_GridEstadoCivil_Codigo).Value) Then
                            If Not ValidacaoExclusao("FORNECEDOR", "CD_ESTADO_CIVIL=" & oRow.Cells(cnt_GridEstadoCivil_Codigo).Value, "Exitem fornecedores associados a ele.") Then GoTo Erro

                            If Not DBExecutar_Delete("ESTADO_CIVIL", "CD_ESTADO_CIVIL", oRow.Cells(cnt_GridEstadoCivil_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Funrural
                        If Not CampoNulo(oRow.Cells(cnt_GridFunrural_Codigo).Value) Then
                            If Not ValidacaoExclusao("FORNECEDOR", "CD_FUNRURAL=" & oRow.Cells(cnt_GridFunrural_Codigo).Value, "Exitem fornecedores associados a ele.") Then GoTo Erro

                            If Not DBExecutar_Delete("FUNRURAL", "CD_FUNRURAL", oRow.Cells(cnt_GridFunrural_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Municipios
                        If Not CampoNulo(oRow.Cells(cnt_GridMunicipio_Codigo).Value) Then
                            If Not ValidacaoExclusao("FORNECEDOR", "CD_MUNICIPIO=" & oRow.Cells(cnt_GridMunicipio_Codigo).Value, "Exitem fornecedores associados a ele.") Then GoTo Erro

                            If Not DBExecutar_Delete("MUNICIPIO", "CD_MUNICIPIO", oRow.Cells(cnt_GridMunicipio_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Capital
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoCapital_Codigo).Value) Then
                            If Not ValidacaoExclusao("FORNECEDOR", "CD_TIPO_CAPITAL=" & oRow.Cells(cnt_GridTipoCapital_Codigo).Value, "Exitem fornecedores associados a ele.") Then GoTo Erro

                            If Not DBExecutar_Delete("FORNECEDOR_TIPO_CAPITAL", "CD_TIPO_CAPITAL", oRow.Cells(cnt_GridTipoCapital_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Pessoa
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoPessoa_Codigo).Value) Then
                            If Not ValidacaoExclusao("FORNECEDOR", "CD_TIPO_PESSOA=" & oRow.Cells(cnt_GridTipoPessoa_Codigo).Value, "Exitem fornecedores associados a ele.") Then GoTo Erro

                            If Not DBExecutar_Delete("TIPO_PESSOA", "CD_TIPO_PESSOA", oRow.Cells(cnt_GridTipoPessoa_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Pessoa_Tributacao
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoPessoaTributacao_Codigo).Value) Then
                            If Not ValidacaoExclusao("FORNECEDOR", "CD_TIPO_PESSOA_TRIBUTACAO=" & oRow.Cells(cnt_GridTipoPessoaTributacao_Codigo).Value, "Exitem fornecedores associados a ele.") Then GoTo Erro

                            If Not DBExecutar_Delete("TIPO_PESSOA_TRIBUTACAO", "CD_TIPO_PESSOA_TRIBUTACAO", oRow.Cells(cnt_GridTipoPessoaTributacao_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.UF
                        If Not CampoNulo(oRow.Cells(cnt_GridUF_Codigo).Value) Then
                            If Not ValidacaoExclusao("MUNICIPIO", "CD_UF='" & oRow.Cells(cnt_GridUF_Codigo).Value & "'", "Exitem municípios associados a essa UF.") Then GoTo Erro

                            If Not DBExecutar_Delete("UF", "CD_UF", "'" & oRow.Cells(cnt_GridUF_Codigo).Value & "'") Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Forma_Pagamento
                        If Not CampoNulo(oRow.Cells(cnt_GridFormaPagamento_Codigo).Value) Then
                            If Not ValidacaoExclusao("PAGAMENTOS", "CD_FORMA_PAGAMENTO=" & oRow.Cells(cnt_GridFormaPagamento_Codigo).Value, "Exitem Pagamentos associados a essa Forma de Pagamento.") Then GoTo Erro

                            If Not DBExecutar_Delete("FORMA_PAGAMENTO", "CD_FORMA_PAGAMENTO", oRow.Cells(cnt_GridFormaPagamento_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Origem
                        If Not CampoNulo(oRow.Cells(cnt_GridOrigem_Codigo).Value) Then
                            If Not ValidacaoExclusao("PROCEDENCIA", "CD_ORIGEM=" & oRow.Cells(cnt_GridOrigem_Codigo).Value, "Exitem procedencias associados a essa origem.") Then GoTo Erro

                            If Not DBExecutar_Delete("ORIGEM", "CD_ORIGEM", oRow.Cells(cnt_GridOrigem_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_NF
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoNF_Codigo).Value) Then
                            If Not ValidacaoExclusao("MOVIMENTACAO", "CD_TIPO_NF='" & oRow.Cells(cnt_GridTipoNF_Codigo).Value & "'", "Exitem movimentações associados a esse tipo de NF.") Then GoTo Erro

                            If Not DBExecutar_Delete("TIPO_NF", "CD_TIPO_NF", "'" & oRow.Cells(cnt_GridTipoNF_Codigo).Value & "'") Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Analise
                        If Not CampoNulo(oRow.Cells(cnt_GridAnalise_Codigo).Value) Then
                            If Not DBExecutar_Delete("ANALISE", "CD_ANALISE", oRow.Cells(cnt_GridAnalise_Codigo).Value) Then GoTo Erro
                        End If

                    Case eCadastroListagemGeral.LocalEntrega
                        If Not CampoNulo(oRow.Cells(cnt_GridLocalEntrega_Codigo).Value) Then
                            If Not ValidacaoExclusao("MOVIMENTACAO", "CD_LOCAL_ENTREGA=" & oRow.Cells(cnt_GridLocalEntrega_Codigo).Value, "Exitem movimentações associados a esse Local de Entrega.") Then GoTo Erro

                            If Not DBExecutar_Delete("LOCAL_ENTREGA", "CD_LOCAL_ENTREGA", oRow.Cells(cnt_GridLocalEntrega_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Adendo
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoAdendo_Codigo).Value) Then

                            If Not DBExecutar_Delete("TIPO_ADENDO", "CD_TIPO_ADENDO", oRow.Cells(cnt_GridTipoAdendo_Codigo).Value) Then GoTo ERRO
                        End If
                    Case eCadastroListagemGeral.Tipo_Cacau
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoCacau_Codigo).Value) Then
                            If Not ValidacaoExclusao("MOVIMENTACAO", "CD_TIPO_CACAU=" & oRow.Cells(cnt_GridTipoCacau_Codigo).Value, "EXITEM MOVIMENTAÇÕES ASSOCIADOS A ESSE TIPO DE CACAU.") Then GoTo ERRO

                            If Not DBExecutar_Delete("TIPO_CACAU", "CD_TIPO_CACAU", oRow.Cells(cnt_GridTipoCacau_Codigo).Value) Then GoTo ERRO
                        End If
                    Case eCadastroListagemGeral.Tipo_Contato
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoContato_Codigo).Value) Then
                            If Not ValidacaoExclusao("ATENDIMENTO", "CD_TIPO_ATENDIMENTO=" & oRow.Cells(cnt_GridTipoContato_Codigo).Value, "EXITEM CONTATOS ASSOCIADOS A ESSE TIPO.") Then GoTo ERRO

                            If Not DBExecutar_Delete("TIPO_ATENDIMENTO", "CD_TIPO_ATENDIMENTO", oRow.Cells(cnt_GridTipoContato_Codigo).Value) Then GoTo ERRO
                        End If
                    Case eCadastroListagemGeral.Tipo_ContratoPAF
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoContratoPAF_Codigo).Value) Then
                            If Not ValidacaoExclusao("CONTRATO_PAF", "CD_TIPO_CONTRATO_PAF=" & oRow.Cells(cnt_GridTipoContratoPAF_Codigo).Value, "EXITEM CONTRATO PAF ASSOCIADOS A ESSE TIPO.") Then GoTo ERRO

                            If Not DBExecutar_Delete("TIPO_CONTRATO_PAF", "CD_TIPO_CONTRATO_PAF", oRow.Cells(cnt_GridTipoContratoPAF_Codigo).Value) Then GoTo ERRO
                        End If
                    Case eCadastroListagemGeral.Tipo_Frete
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoFrete_Codigo).Value) Then
                            If Not ValidacaoExclusao("FRETE", "CD_TIPO_FRETE=" & oRow.Cells(cnt_GridTipoFrete_Codigo).Value, "Exitem fretes associados a esse tipo.") Then GoTo Erro

                            If Not DBExecutar_Delete("TIPO_FRETE", "CD_TIPO_FRETE", oRow.Cells(cnt_GridTipoFrete_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Frestista
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoFretista_Codigo).Value) Then
                            If Not ValidacaoExclusao("FRETISTA", "CD_TIPO_FRETISTA=" & oRow.Cells(cnt_GridTipoFretista_Codigo).Value, "Exitem fretistas associados a esse tipo.") Then GoTo Erro

                            If Not DBExecutar_Delete("TIPO_FRETISTA", "CD_TIPO_FRETISTA", oRow.Cells(cnt_GridTipoFretista_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Movimentacao_Sacaria
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoFretista_Codigo).Value) Then
                            If Not ValidacaoExclusao("SACARIA_FILIAL", "CD_TIPO_MOVIMENTACAO = " & oRow.Cells(cnt_GridTipoFretista_Codigo).Value, "Exitem lançamentos de sacaria associados a esse tipo.") Then GoTo Erro

                            If Not DBExecutar_Delete("SACARIA_TIPO_MOVIMENTACAO", "CD_TIPO_MOVIMENTACAO", oRow.Cells(cnt_GridTipoFretista_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Provisoes
                        If Not CampoNulo(oRow.Cells(cnt_GridProvisao_Codigo).Value) Then
                            If Not DBExecutar_Delete("PROVISAO", "CD_PROVISAO", oRow.Cells(cnt_GridProvisao_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Aprovacao
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoAprovador_Codigo).Value) Then
                            If Not ValidacaoExclusao("LIMITE_CREDITO_APROVACAO", "CD_TIPO_APROVACAO = " & oRow.Cells(cnt_GridTipoAprovador_Codigo).Value, "Exitem aprovações associados a esse tipo.") Then GoTo Erro

                            If Not DBExecutar_Delete("TIPO_APROVACAO", "CD_TIPO_APROVACAO", oRow.Cells(cnt_GridTipoAprovador_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Armazem
                        If Not CampoNulo(oRow.Cells(cnt_GridArmazem_Codigo).Value) Then
                            If Not ValidacaoExclusao("PILHA_ARMAZEM", "CD_ARMAZEM = " & oRow.Cells(cnt_GridArmazem_Codigo).Value, "Exitem pilhas associados a esse armazém.") Then GoTo Erro

                            If Not DBExecutar_Delete("ARMAZEM", "CD_ARMAZEM", oRow.Cells(cnt_GridArmazem_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Modalidade_Recuperacao_Credito
                        If Not CampoNulo(oRow.Cells(cnt_GridModalidadeRecuperacaoCredito_Codigo).Value) Then
                            If Not ValidacaoExclusao("CONFISSAO_DIVIDA", "CD_CONFISSAO_DIVIDA_MODALIDADE = " & oRow.Cells(cnt_GridModalidadeRecuperacaoCredito_Codigo).Value, "Exitem recuperações de credito dessa modalidade lançados.") Then GoTo Erro

                            If Not DBExecutar_Delete("CONFISSAO_DIVIDA_MODALIDADE", "CD_CONFISSAO_DIVIDA_MODALIDADE", oRow.Cells(cnt_GridModalidadeRecuperacaoCredito_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Procedencia
                        If Not CampoNulo(oRow.Cells(cnt_GridProcedencia_Codigo).Value) Then
                            If Not ValidacaoExclusao("MOVIMENTACAO", "CD_PROCEDENCIA = " & QuotedStr(oRow.Cells(cnt_GridProcedencia_Codigo).Value), "Exitem movimentações associados a essa procedência.") Then GoTo Erro

                            If Not DBExecutar_Delete("PROCEDENCIA", "CD_PROCEDENCIA", QuotedStr(oRow.Cells(cnt_GridProcedencia_Codigo).Value)) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Safra
                        If Not CampoNulo(oRow.Cells(cnt_GridSafra_Codigo).Value) Then
                            If Not ValidacaoExclusao("CONTRATO_PAF", "CD_SAFRA = " & oRow.Cells(cnt_GridSafra_Codigo).Value, "Exitem contratos associados a essa safra.") Then GoTo Erro

                            If Not DBExecutar_Delete("SAFRA", "CD_SAFRA", oRow.Cells(cnt_GridSafra_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Acondicionamento
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoAcondicionamento_Codigo).Value) Then
                            If Not DBExecutar_Delete("TIPO_ACONDICIONAMENTO", "CD_TIPO_ACONDICIONAMENTO", oRow.Cells(cnt_GridTipoAcondicionamento_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Sacaria
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoSacaria_Codigo).Value) Then
                            If Not ValidacaoExclusao("SACARIA_FILIAL", "CD_TIPO_SACARIA = " & oRow.Cells(cnt_GridTipoSacaria_Codigo).Value, "Exitem lançamentos de sacaria associados a esse tipo.") Then GoTo Erro

                            If Not DBExecutar_Delete("TIPO_SACARIA", "CD_TIPO_SACARIA", oRow.Cells(cnt_GridTipoSacaria_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Inovacao
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoInovacao_Codigo).Value) Then
                            If Not ValidacaoExclusao("INOVACAO", "CD_TIPO_INOVACAO = " & oRow.Cells(cnt_GridTipoInovacao_Codigo).Value, "Exitem inovações associados a esse tipo.") Then GoTo Erro

                            If Not DBExecutar_Delete("TIPO_INOVACAO", "CD_TIPO_INOVACAO", oRow.Cells(cnt_GridTipoInovacao_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.ContaCorrente
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoInovacao_Codigo).Value) Then
                            If Not DBExecutar_Delete("BANCO", "CD_BANCO", oRow.Cells(cnt_GridContaCorrente_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Negociacao
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoNegociacao_Codigo).Value) Then
                            If Not ValidacaoExclusao("NEGOCIACAO", "CD_TIPO_NEGOCIACAO = " & oRow.Cells(cnt_GridTipoNegociacao_Codigo).Value, "Exitem negociações associados a esse tipo.") Then GoTo Erro

                            If Not DBExecutar_Delete("TIPO_NEGOCIACAO", "CD_TIPO_NEGOCIACAO", oRow.Cells(cnt_GridTipoNegociacao_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Garantia
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoGarantia_Codigo).Value) Then
                            If Not ValidacaoExclusao("GARANTIA", "CD_TIPO_GARANTIA = " & oRow.Cells(cnt_GridTipoGarantia_Codigo).Value, "Exitem garantias associados a esse tipo.") Then GoTo Erro

                            If Not DBExecutar_Delete("TIPO_GARANTIA", "CD_TIPO_GARANTIA", oRow.Cells(cnt_GridTipoGarantia_Codigo).Value) Then GoTo Erro
                        End If
                    Case eCadastroListagemGeral.Tipo_Desconto_Qualidade
                        If Not CampoNulo(oRow.Cells(cnt_GridTipoDescontoQualidade_Codigo).Value) Then
                            If Not DBExecutar_Delete("TIPO_DESCONTO_QUALIDADE", "CD_TIPO_DESCONTO_QUALIDADE", oRow.Cells(cnt_GridTipoDescontoQualidade_Codigo).Value) Then GoTo ERRO
                        End If
                End Select
            Else
                GoTo Erro
            End If
        Catch ex As Exception
            Msg_Mensagem(ex.Message)

            GoTo Erro
        End Try

        Return True

        Exit Function

Erro:
        Return False
    End Function

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String

        Select Case iTipoTela
            Case eCadastroListagemGeral.UF
                SqlText = "SELECT CD_UF, NO_UF, PC_ALIQ_ICMS, DECODE(IC_OBRIGACAO_ACESSORIA, 'S', 1, 0) IC_OBRIGACAO_ACESSORIA" & _
                          " FROM SOF.UF ORDER BY NO_UF"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Funrural
                SqlText = "SELECT CD_FUNRURAL, NO_FUNRURAL, VL_TAXA" & _
                          " FROM SOF.FUNRURAL ORDER BY NO_FUNRURAL"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Municipios
                SqlText = "SELECT CD_MUNICIPIO, NO_CIDADE, CD_UF " & _
                          "FROM SOF.MUNICIPIO ORDER BY NO_CIDADE"

                objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridMunicipio_Codigo, cnt_GridMunicipio_Nome, cnt_GridMunicipio_UF})

            Case eCadastroListagemGeral.Tipo_Pessoa
                SqlText = "SELECT CD_TIPO_PESSOA, NO_TIPO_PESSOA," & _
                          "DECODE(IC_MOSTRA_PRECO_BOLSA, 'S', 1, 0) IC_MOSTRA_PRECO_BOLSA, VL_PERCENTUAL_PRECO_BOLSA " & _
                          "FROM SOF.TIPO_PESSOA ORDER BY NO_TIPO_PESSOA"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Pessoa_Tributacao
                SqlText = "SELECT CD_TIPO_PESSOA_TRIBUTACAO, NO_TIPO_PESSOA_TRIBUTACAO " & _
                          "FROM SOF.TIPO_PESSOA_TRIBUTACAO ORDER BY CD_TIPO_PESSOA_TRIBUTACAO"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Estado_Civil
                SqlText = "SELECT EC.CD_ESTADO_CIVIL, EC.NO_ESTADO_CIVIL "
                SqlText = SqlText & "FROM SOF.ESTADO_CIVIL EC "
                SqlText = SqlText & "ORDER BY EC.CD_ESTADO_CIVIL "

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Capital
                SqlText = "SELECT TP.CD_TIPO_CAPITAL, TP.NO_TIPO_CAPITAL "
                SqlText = SqlText & "FROM SOF.FORNECEDOR_TIPO_CAPITAL TP "
                SqlText = SqlText & "ORDER BY TP.CD_TIPO_CAPITAL "

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Forma_Pagamento
                SqlText = "SELECT CD_FORMA_PAGAMENTO, NO_FORMA_PAGAMENTO, NU_CONTA_CONTABIL_DEBITO, "
                SqlText = SqlText & "       NU_CONTA_CONTABIL_CREDITO, DECODE(IC_MUDA_FILIAL_CONTA_CREDITO, 'S', 1, 0) IC_MUDA_FILIAL_CONTA_CREDITO, DECODE(IC_ATIVO, 'S', 1, 0) IC_ATIVO, "
                SqlText = SqlText & "       DECODE(IC_VALIDA_CREDITO, 'S', 1, 0) IC_VALIDA_CREDITO, DECODE(IC_APROVACAO, 'S', 1, 0) IC_APROVACAO "
                SqlText = SqlText & "  FROM SOF.FORMA_PAGAMENTO "

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_NF
                SqlText = "SELECT CD_TIPO_NF,NO_TIPO_NF, DECODE(IC_MUNICIPIO_FISCAL, 'S', 1, 0) IC_MUNICIPIO_FISCAL " & _
                            "FROM SOF.TIPO_NF ORDER BY NO_TIPO_NF"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Analise
                SqlText = "select cd_analise, no_analise " & _
                            "from sof.analise " & _
                            "order by cd_analise"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.LocalEntrega
                SqlText = "select cd_local_entrega,no_local_entrega, DECODE(ic_ativo, 'S', 1, 0) ic_ativo " & _
                            "from sof.local_entrega order by cd_local_entrega"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Origem
                SqlText = "SELECT O.CD_ORIGEM, O.NO_ORIGEM " & _
                     "FROM SOF.ORIGEM O " & _
                     "ORDER BY O.CD_ORIGEM"
                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Cacau
                SqlText = "select tc.cd_tipo_cacau, tc.no_tipo_cacau "
                SqlText = SqlText & "from sof.tipo_cacau tc "
                SqlText = SqlText & "order by tc.cd_tipo_cacau "

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Frestista
                SqlText = "SELECT CD_TIPO_FRETISTA, NO_TIPO_FRETISTA " & _
                          "From SOF.TIPO_FRETISTA " & _
                          "ORDER BY CD_TIPO_FRETISTA"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_ContratoPAF
                SqlText = "SELECT CD_TIPO_CONTRATO_PAF, NO_TIPO_CONTRATO_PAF, DECODE(IC_ADIANTAMENTO, 'S', 1, 0) IC_ADIANTAMENTO, DS_TEXTO_CONTRATO " & _
                          "FROM SOF.TIPO_CONTRATO_PAF " & _
                          "order by CD_TIPO_CONTRATO_PAF"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Frete
                SqlText = "select cd_tipo_frete, no_tipo_frete " & _
                          "from sof.tipo_frete " & _
                          "order by cd_tipo_frete"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Contato
                SqlText = "select cd_tipo_atendimento, no_tipo_atendimento " & _
                          "from sof.tipo_atendimento " & _
                          "order by cd_tipo_atendimento"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Adendo
                SqlText = "select cd_tipo_adendo,ds_tipo_adendo " & _
                          "from sof.tipo_adendo order by ds_tipo_adendo"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Movimentacao_Sacaria
                SqlText = "SELECT CD_TIPO_MOVIMENTACAO, NO_TIPO_MOVIMENTACAO" & _
                          " FROM SOF.SACARIA_TIPO_MOVIMENTACAO" & _
                          " ORDER BY NO_TIPO_MOVIMENTACAO"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Provisoes
                SqlText = "select cd_provisao,no_provisao, " & _
                    "conta_contabil, ic_calc_subaliq " & _
                    "from sof.provisao order by cd_provisao"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Aprovacao
                SqlText = "SELECT CD_TIPO_APROVACAO, NO_TIPO_APROVACAO, DECODE(IC_POSSUI_LIMITE,'S',1,0) , " & _
                      "DECODE(IC_OBRIGATORIO,'S',1,0), DECODE(IC_LIBERA_NEGOCIACAO,'S',1,0) " & _
                      "From SOF.TIPO_APROVACAO " & _
                      "ORDER BY CD_TIPO_APROVACAO"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Armazem
                SqlText = "SELECT A.CD_ARMAZEM, A.NO_ARMAZEM, " & _
                   "A.CD_FILIAL_ORIGEM ,A.ic_ativo  From SOF.ARMAZEM A " & _
                  " order by A.CD_ARMAZEM"

                objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridArmazem_Codigo, _
                                                                    cnt_GridArmazem_Nome, _
                                                                    cnt_GridArmazem_Filial, _
                                                                    cnt_GridArmazem_Ativo})
            Case eCadastroListagemGeral.Modalidade_Recuperacao_Credito
                SqlText = "SELECT   cdm.cd_confissao_divida_modalidade, "
                SqlText = SqlText & "         cdm.no_confissao_divida_modalidade, fp.no_forma_pagamento, "
                SqlText = SqlText & "         tp.no_tipo_pagamento, cm.no_conciliacao_modalidade "
                SqlText = SqlText & "    FROM sof.confissao_divida_modalidade cdm, "
                SqlText = SqlText & "         sof.confissao_divida_parametro p, "
                SqlText = SqlText & "         sof.forma_pagamento fp, "
                SqlText = SqlText & "         sof.tipo_pagamento tp, "
                SqlText = SqlText & "         sof.conciliacao_modalidade cm "
                SqlText = SqlText & "   WHERE cdm.cd_confissao_divida_modalidade = p.cd_confissao_divida_modalidade(+) "
                SqlText = SqlText & "     AND p.cd_forma_pagamento = fp.cd_forma_pagamento(+) "
                SqlText = SqlText & "     AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento(+) "
                SqlText = SqlText & "     AND p.cd_conciliacao_modalidade_pag = cm.cd_conciliacao_modalidade(+) "
                SqlText = SqlText & "ORDER BY cdm.cd_confissao_divida_modalidade "


                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Procedencia
                SqlText = "SELECT P.CD_PROCEDENCIA, P.NO_PROCEDENCIA, p.CD_ORIGEM " & _
                            "FROM SOF.PROCEDENCIA P " & _
                            "ORDER BY P.CD_PROCEDENCIA"

                objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridProcedencia_Codigo, _
                                                                    cnt_GridProcedencia_Nome, _
                                                                    cnt_GridProcedencia_Origem})
            Case eCadastroListagemGeral.Safra
                SqlText = "select cd_safra, ds_safra, DECODE(ic_valido,'S',1,0) " & _
                            "from sof.safra " & _
                            "order by cd_safra"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Acondicionamento
                SqlText = "select cd_tipo_acondicionamento, no_tipo_acondicionamento, DS_TEXTO_CONTRATO " & _
                            "from sof.tipo_acondicionamento " & _
                            "order by cd_tipo_acondicionamento"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Sacaria
                SqlText = "select cd_tipo_sacaria, no_tipo_sacaria, " & _
                            "vl_peso, vl_preco, DECODE(ic_contabiliza_fornecedor,'S',1,0) , DECODE(ic_ativo,'S',1,0) " & _
                            "from sof.tipo_sacaria order by cd_tipo_sacaria"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Inovacao
                SqlText = "select cd_tipo_inovacao, no_tipo_inovacao " & _
                            "from sof.tipo_inovacao " & _
                            "order by cd_tipo_inovacao"

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.ContaCorrente
                SqlText = "SELECT cd_banco, no_banco, nu_ultimo_cheque, nu_banco, nu_agencia, "
                SqlText = SqlText & "       nu_conta_corrente, nu_conta_contabil, cd_filial_origem, DECODE(ic_ativo,'S',1,0) "
                SqlText = SqlText & "  FROM sof.banco "

                objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridContaCorrente_Codigo, _
                                                                    cnt_GridContaCorrente_Nome, _
                                                                    cnt_GridContaCorrente_UltimoCheque, _
                                                                    cnt_GridContaCorrente_NumeroBanco, _
                                                                    cnt_GridContaCorrente_Agencia, _
                                                                    cnt_GridContaCorrente_ContaCorrente, _
                                                                    cnt_GridContaCorrente_ContaContabil, _
                                                                    cnt_GridContaCorrente_Filial, _
                                                                    cnt_GridContaCorrente_Ativo})
            Case eCadastroListagemGeral.Tipo_Negociacao
                SqlText = "SELECT   cd_tipo_negociacao, no_tipo_negociacao, decode (ic_bolsa, 'S','B',decode( "
                SqlText = SqlText & "         ic_dolar,'S','D','P')) as Tipo, ic_bolsa_operacao, ds_texto_contrato, qt_dia_venc_padrao "
                SqlText = SqlText & "    FROM sof.tipo_negociacao "
                SqlText = SqlText & "ORDER BY cd_tipo_negociacao "

                objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridTipoNegociacao_Codigo, _
                                                                    cnt_GridTipoNegociacao_Descricao, _
                                                                    cnt_GridTipoNegociacao_Tipo, _
                                                                    cnt_GridTipoNegociacao_Operacao, _
                                                                    cnt_GridTipoNegociacao_Texto, _
                                                                    cnt_GridTipoNegociacao_Qt_Dia_Venc_Padrao})
            Case eCadastroListagemGeral.Tipo_Garantia
                SqlText = "SELECT   cd_tipo_garantia, no_tipo_garantia, vl_limite_garantia, DECODE (ic_descricao,'S',1,0), "
                SqlText = SqlText & "         DECODE (ic_provisoria,'S',1,0), DECODE (ic_garantido,'S',1,0), "
                SqlText = SqlText & "         DECODE (qt_dias_prazo_max, NULL, 0, 1) ic_prazo_maximo, "
                SqlText = SqlText & "         qt_dias_prazo_max "
                SqlText = SqlText & "    FROM sof.tipo_garantia "
                SqlText = SqlText & "ORDER BY cd_tipo_garantia "

                objGrid_Carregar(grdGeral, SqlText)
            Case eCadastroListagemGeral.Tipo_Desconto_Qualidade
                SqlText = "SELECT   tdq.cd_tipo_desconto_qualidade, tdq.no_tipo_desconto_qualidade, "
                SqlText = SqlText & "         tdq.no_campo_qualidade, "
                SqlText = SqlText & "         tdq.vl_maximo_permitido, tdq.cd_tipo_pagamento, decode(tdq.ic_ativo,'S',1,0) "
                SqlText = SqlText & "    FROM sof.tipo_desconto_qualidade tdq "
                SqlText = SqlText & "ORDER BY tdq.cd_tipo_desconto_qualidade "

                objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridTipoDescontoQualidade_Codigo, _
                                                                   cnt_GridTipoDescontoQualidade_Nome, _
                                                                   cnt_GridTipoDescontoQualidade_CampoQualidade, _
                                                                   cnt_GridTipoDescontoQualidade_MaximoPermitido, _
                                                                   cnt_GridTipoDescontoQualidade_TipoPagamento, _
                                                                   cnt_GridTipoDescontoQualidade_Ativo})
            Case eCadastroListagemGeral.Tipo_Pessoa_Imposto
                SqlText = "SELECT IV.CD_INDICE," & _
                                 "IV.CD_PROCESSO," & _
                                 "IV.DT_INDICE_VALOR," & _
                                 "IV.VL_INDICE" & _
                          " FROM SOF.PROCESSO_STATUS PS," & _
                                "SOF.PROCESSO PC," & _
                                "SOF.INDICE_VALORES IV" & _
                          " WHERE PS.CD_STATUS = " & Filtro_01 & _
                            " AND PC.CD_PROCESSO =  PS.CD_PROCESSO" & _
                            " AND IV.CD_PROCESSO =  PS.CD_PROCESSO" & _
                            " AND IV.CD_INDICE = PS.CD_STATUS" & _
                          " ORDER BY IV.DT_INDICE_VALOR," & _
                                    "PC.NO_PROCESSO"
                objGrid_Carregar(grdGeral, SqlText)
        End Select

        grdGeral.DisplayLayout.Override.FilterUIType = FilterUIType.HeaderIcons
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If grdGeral.DisplayLayout.ActiveRow Is Nothing Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Select Case iTipoTela
            Case eCadastroListagemGeral.Estado_Civil
                Auditoria(TipoCampoFixo.Todos, "ESTADO_CIVIL", "CD_ESTADO_CIVIL=" & objGrid_Valor(grdGeral, cnt_GridEstadoCivil_Codigo))
            Case eCadastroListagemGeral.Funrural
                Auditoria(TipoCampoFixo.Todos, "FUNRURAL", "CD_FUNRURAL=" & objGrid_Valor(grdGeral, cnt_GridFunrural_Codigo))
            Case eCadastroListagemGeral.Municipios
                Auditoria(TipoCampoFixo.Todos, "MUNICIPIO", "CD_MUNICIPIO=" & objGrid_Valor(grdGeral, cnt_GridMunicipio_Codigo))
            Case eCadastroListagemGeral.Tipo_Capital
                Auditoria(TipoCampoFixo.Todos, "FORNECEDOR_TIPO_CAPITAL", "CD_TIPO_CAPITAL=" & objGrid_Valor(grdGeral, cnt_GridTipoCapital_Codigo))
            Case eCadastroListagemGeral.Tipo_Pessoa
                Auditoria(TipoCampoFixo.Todos, "TIPO_PESSOA", "CD_TIPO_PESSOA=" & objGrid_Valor(grdGeral, cnt_GridTipoPessoa_Codigo))
            Case eCadastroListagemGeral.Tipo_Pessoa_Tributacao
                Auditoria(TipoCampoFixo.Todos, "TIPO_PESSOA_TRIBUTACAO", "CD_TIPO_PESSOA_TRIBUTACAO=" & objGrid_Valor(grdGeral, cnt_GridTipoPessoaTributacao_Codigo))
            Case eCadastroListagemGeral.UF
                Auditoria(TipoCampoFixo.Todos, "UF", "CD_UF=" & QuotedStr(objGrid_Valor(grdGeral, cnt_GridUF_Codigo)))
            Case eCadastroListagemGeral.Forma_Pagamento
                Auditoria(TipoCampoFixo.Todos, "FORMA_PAGAMENTO", "CD_FORMA_PAGAMENTO=" & objGrid_Valor(grdGeral, cnt_GridFormaPagamento_Codigo))
            Case eCadastroListagemGeral.Analise
                Auditoria(TipoCampoFixo.Todos, "ANALISE", "CD_ANALISE=" & objGrid_Valor(grdGeral, cnt_GridAnalise_Codigo))
            Case eCadastroListagemGeral.Origem
                Auditoria(TipoCampoFixo.Todos, "ORIGEM", "CD_ORIGEM=" & objGrid_Valor(grdGeral, cnt_GridOrigem_Codigo))
            Case eCadastroListagemGeral.LocalEntrega
                Auditoria(TipoCampoFixo.Todos, "LOCAL_ENTREGA", "CD_LOCAL_ENTREGA=" & objGrid_Valor(grdGeral, cnt_GridLocalEntrega_Codigo))
            Case eCadastroListagemGeral.Tipo_NF
                Auditoria(TipoCampoFixo.Todos, "TIPO_NF", "CD_TIPO_NF=" & QuotedStr(objGrid_Valor(grdGeral, cnt_GridTipoNF_Codigo)))
            Case eCadastroListagemGeral.Tipo_Adendo
                Auditoria(TipoCampoFixo.Todos, "TIPO_ADENDO", "CD_TIPO_ADENDO=" & objGrid_Valor(grdGeral, cnt_GridTipoAdendo_Codigo))
            Case eCadastroListagemGeral.Tipo_Cacau
                Auditoria(TipoCampoFixo.Todos, "TIPO_CACAU", "CD_TIPO_CACAU=" & objGrid_Valor(grdGeral, cnt_GridTipoCacau_Codigo))
            Case eCadastroListagemGeral.Tipo_Contato
                Auditoria(TipoCampoFixo.Todos, "TIPO_ATENDIMENTO", "CD_TIPO_ATENDIMENTO=" & objGrid_Valor(grdGeral, cnt_GridTipoContato_Codigo))
            Case eCadastroListagemGeral.Tipo_ContratoPAF
                Auditoria(TipoCampoFixo.Todos, "TIPO_CONTRATO_PAF", "CD_TIPO_CONTRATO_PAF=" & objGrid_Valor(grdGeral, cnt_GridTipoContratoPAF_Codigo))
            Case eCadastroListagemGeral.Tipo_Frestista
                Auditoria(TipoCampoFixo.Todos, "TIPO_FRETISTA", "CD_TIPO_FRETISTA=" & objGrid_Valor(grdGeral, cnt_GridTipoFretista_Codigo))
            Case eCadastroListagemGeral.Tipo_Frete
                Auditoria(TipoCampoFixo.Todos, "TIPO_FRETE", "CD_TIPO_FRETE=" & objGrid_Valor(grdGeral, cnt_GridTipoFrete_Codigo))
            Case eCadastroListagemGeral.Tipo_Movimentacao_Sacaria
                Auditoria(TipoCampoFixo.Todos, "TIPO_MOVIMENTACAO_SACARIA", "CD_TIPO_MOVIMENTACAO=" & objGrid_Valor(grdGeral, cnt_GridTipoFrete_Codigo))
            Case eCadastroListagemGeral.Provisoes
                Auditoria(TipoCampoFixo.Todos, "PROVISAO", "CD_PROVISAO=" & objGrid_Valor(grdGeral, cnt_GridProvisao_Codigo))
            Case eCadastroListagemGeral.Tipo_Aprovacao
                Auditoria(TipoCampoFixo.Todos, "TIPO_APROVACAO", "CD_TIPO_APROVACAO=" & objGrid_Valor(grdGeral, cnt_GridTipoAprovador_Codigo))
            Case eCadastroListagemGeral.Armazem
                Auditoria(TipoCampoFixo.Todos, "ARMAZEM", "CD_ARMAZEM=" & objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo))
            Case eCadastroListagemGeral.Modalidade_Recuperacao_Credito
                Auditoria(TipoCampoFixo.Todos, "CONFISSAO_DIVIDA_MODALIDADE", "CD_CONFISSAO_DIVIDA_MODALIDADE=" & objGrid_Valor(grdGeral, cnt_GridModalidadeRecuperacaoCredito_Codigo))
            Case eCadastroListagemGeral.Procedencia
                Auditoria(TipoCampoFixo.Todos, "PROCEDENCIA", "CD_PROCEDENCIA=" & QuotedStr(objGrid_Valor(grdGeral, cnt_GridProcedencia_Codigo)))
            Case eCadastroListagemGeral.Safra
                Auditoria(TipoCampoFixo.Todos, "SAFRA", "CD_SAFRA=" & objGrid_Valor(grdGeral, cnt_GridSafra_Codigo))
            Case eCadastroListagemGeral.Tipo_Acondicionamento
                Auditoria(TipoCampoFixo.Todos, "TIPO_ACONDICIONAMENTO", "CD_TIPO_ACONDICIONAMENTO=" & objGrid_Valor(grdGeral, cnt_GridTipoAcondicionamento_Codigo))
            Case eCadastroListagemGeral.Tipo_Sacaria
                Auditoria(TipoCampoFixo.Todos, "TIPO_SACARIA", "CD_TIPO_SACARIA=" & objGrid_Valor(grdGeral, cnt_GridTipoSacaria_Codigo))
            Case eCadastroListagemGeral.Tipo_Inovacao
                Auditoria(TipoCampoFixo.Todos, "TIPO_INOVACAO", "CD_TIPO_INOVACAO=" & objGrid_Valor(grdGeral, cnt_GridTipoInovacao_Codigo))
            Case eCadastroListagemGeral.ContaCorrente
                Auditoria(TipoCampoFixo.Todos, "BANCO", "CD_BANCO=" & objGrid_Valor(grdGeral, cnt_GridContaCorrente_Codigo))
            Case eCadastroListagemGeral.Tipo_Negociacao
                Auditoria(TipoCampoFixo.Todos, "TIPO_NEGOCIACAO", "CD_TIPO_NEGOCIACAO=" & objGrid_Valor(grdGeral, cnt_GridTipoNegociacao_Codigo))
            Case eCadastroListagemGeral.Tipo_Garantia
                Auditoria(TipoCampoFixo.Todos, "TIPO_GARANTIA", "CD_TIPO_GARANTIA=" & objGrid_Valor(grdGeral, cnt_GridTipoGarantia_Codigo))
            Case eCadastroListagemGeral.Tipo_Desconto_Qualidade
                Auditoria(TipoCampoFixo.Todos, "TIPO_DESCONTO_QUALIDADE", "CD_TIPO_DESCONTO_QUALIDADE=" & objGrid_Valor(grdGeral, cnt_GridTipoDescontoQualidade_Codigo))
            Case eCadastroListagemGeral.Tipo_Pessoa_Imposto
                Auditoria(TipoCampoFixo.Todos, "INDICE_VALORES", "CD_PROCESSO = " & objGrid_Valor(grdGeral, cnt_GridTipoPessoaImposto_Imposto) & _
                                                            " AND CD_INDICE = " & Filtro_01 & _
                                                            " AND TRUNC(DT_INDICE_VALOR) = " & QuotedStr(Date_to_Oracle(objGrid_Valor(grdGeral, cnt_GridTipoPessoaImposto_Data))))
        End Select
    End Sub

    Private Sub frmCadastroListagemGeral_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcluir.Height - 6
        cmdEspecial_01.Top = Me.ClientSize.Height - cmdEspecial_01.Height - 6
        cmdEspecial_02.Top = Me.ClientSize.Height - cmdEspecial_02.Height - 6
        cmdEspecial_03.Top = Me.ClientSize.Height - cmdEspecial_03.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdUsuario.Height - 6
    End Sub

    Private Sub grdGeral_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles grdGeral.BeforeRowUpdate
        Dim SqlText As String

        Select Case iTipoTela
            Case eCadastroListagemGeral.Municipios
                If Trim(NuloParaString(e.Row.Cells(cnt_GridMunicipio_Nome).Value)) = "" Then
                    Msg_Mensagem("Informe o nome do município")
                    e.Cancel = True
                End If
            Case eCadastroListagemGeral.Tipo_Movimentacao_Sacaria
                If Trim(NuloParaString(e.Row.Cells(cnt_GridTipoMovimentacaoSacaria_Nome).Value)) = "" Then
                    Msg_Mensagem("Informe o nome do tipo de movimentação de sacaria")
                    e.Cancel = True
                End If
            Case eCadastroListagemGeral.ContaCorrente
                If Trim(NuloParaString(e.Row.Cells(cnt_GridContaCorrente_Codigo).Value)) = "" Then
                    Msg_Mensagem("Favor informar o codigo da conta corrente.")
                    e.Cancel = True
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridContaCorrente_Nome).Value)) = "" Then
                    Msg_Mensagem("Favor informar o nome da conta corrente.")
                    e.Cancel = True
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridContaCorrente_UltimoCheque).Value)) = "" Then
                    Msg_Mensagem("Favor informar o numero do ultimo cheque feito.")
                    e.Cancel = True
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridContaCorrente_NumeroBanco).Value)) = "" Then
                    Msg_Mensagem("Favor informar o número do banco.")
                    e.Cancel = True
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridContaCorrente_Agencia).Value)) = "" Then
                    Msg_Mensagem("Favor informar o número da agencia.")
                    e.Cancel = True
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridContaCorrente_ContaCorrente).Value)) = "" Then
                    Msg_Mensagem("Favor informar o numero da conta corrente.")
                    e.Cancel = True
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridContaCorrente_ContaContabil).Value)) = "" Then
                    Msg_Mensagem("Favor informar a conta contabil da conta corrente.")
                    e.Cancel = True
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridContaCorrente_Filial).Value)) = "" Then
                    Msg_Mensagem("Favor informar uma filial.")
                    e.Cancel = True
                End If
            Case eCadastroListagemGeral.Tipo_Negociacao
                If Trim(NuloParaString(e.Row.Cells(cnt_GridTipoNegociacao_Descricao).Value)) = "" Then
                    Msg_Mensagem("Favor informar a descrição.")
                    e.Cancel = True
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridTipoNegociacao_Tipo).Value)) = "B" Then
                    If Trim(NuloParaString(e.Row.Cells(cnt_GridTipoNegociacao_Operacao).Value)) = "" Then
                        Msg_Mensagem("Favor selecionar uma operacao.")
                        e.Cancel = True
                    End If
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridTipoNegociacao_Texto).Value)) = "" Then
                    Msg_Mensagem("Favor informar o texto para o contrato.")
                    e.Cancel = True
                End If
            Case eCadastroListagemGeral.Tipo_Garantia
                If Trim(NuloParaString(e.Row.Cells(cnt_GridTipoGarantia_Descricao).Value)) = "" Then
                    Msg_Mensagem("Favor informar a descrição.")
                    e.Cancel = True
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridTipoGarantia_ValorLimite).Value)) = "" Then
                    Msg_Mensagem("Favor informar o valor do limite.")
                    e.Cancel = True
                End If
                If NVL(e.Row.Cells(cnt_GridTipoGarantia_IcPrazo).Value, 0) = 1 And e.Row.Cells(cnt_GridTipoGarantia_ValorLimite).Value = 0 Then
                    Msg_Mensagem("Favor informar a quantidade maxima de dias para o prazo.")
                    e.Cancel = True
                End If
            Case eCadastroListagemGeral.Tipo_Desconto_Qualidade
                If Trim(NuloParaString(e.Row.Cells(cnt_GridTipoDescontoQualidade_Nome).Value)) = "" Then
                    Msg_Mensagem("Favor informar a descrição.")
                    e.Cancel = True
                End If
                If e.Row.Cells(cnt_GridTipoDescontoQualidade_MaximoPermitido).Value <= 0 Then
                    Msg_Mensagem("Valor invalido.")
                    e.Cancel = True
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridTipoDescontoQualidade_CampoQualidade).Value)) = "" Then
                    Msg_Mensagem("Favor selecionar um campo.")
                    e.Cancel = True
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridTipoDescontoQualidade_CampoQualidade).Value)) = "" Then
                    Msg_Mensagem("Favor informar o campo.")
                    e.Cancel = True
                End If
                If Trim(NuloParaString(e.Row.Cells(cnt_GridTipoDescontoQualidade_TipoPagamento).Value)) = "" Then
                    Msg_Mensagem("Favor selecionar um tipo de pagamento.")
                    e.Cancel = True
                End If
            Case eCadastroListagemGeral.Tipo_Pessoa_Imposto
                If CampoNulo(e.Row.Cells(cnt_GridTipoPessoaImposto_Imposto).Value) Then
                    Msg_Mensagem("Selecione o imposto")
                    e.Cancel = True
                End If
                If Not IsDate(e.Row.Cells(cnt_GridTipoPessoaImposto_Data).Value) Then
                    Msg_Mensagem("Informe uma data válida")
                    e.Cancel = True
                End If
                If CampoNulo(e.Row.Cells(cnt_GridTipoPessoaImposto_Valor).Value) Then
                    Msg_Mensagem("Informe o valor")
                    e.Cancel = True
                End If

                SqlText = "SELECT COUNT(*) FROM SOF.INDICE_VALORES" & _
                          " WHERE CD_PROCESSO = " & e.Row.Cells(cnt_GridTipoPessoaImposto_Imposto).Value & _
                            " AND CD_INDICE = " & Filtro_01 & _
                            " AND TRUNC(DT_INDICE_VALOR) = " & QuotedStr(Date_to_Oracle(e.Row.Cells(cnt_GridTipoPessoaImposto_Data).Value))
                If DBQuery_ValorUnico(SqlText) > 0 Then
                    Msg_Mensagem("Imposto já lançado para essa data")
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub cmdEspecial_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEspecial_01.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Select Case iTipoTela
            Case eCadastroListagemGeral.Modalidade_Recuperacao_Credito
                Dim oForm_Parametro As New frmParametroRecuperacaoCredito
                Filtro = objGrid_Valor(grdGeral, cnt_GridModalidadeRecuperacaoCredito_Codigo)
                oForm_Parametro = New frmParametroRecuperacaoCredito
                Form_Show(Me.MdiParent, oForm_Parametro, , , , True)
            Case eCadastroListagemGeral.Tipo_Pessoa
                Dim oForm As New frmCadastroListagemGeral

                oForm.Filtro_01 = objGrid_Valor(grdGeral, cnt_GridTipoPessoa_Codigo)
                oForm.FormatarTela(eCadastroListagemGeral.Tipo_Pessoa_Imposto)

                Form_Show(Me.Parent, oForm, , , True)
        End Select
    End Sub

    Private Sub oForm_Parametro_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_Parametro.FormClosing
        CarregarDados()
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If Not grdGeral.ActiveRow Is Nothing Then
            grdGeral.ActiveRow.Delete()

            CarregarDados()
        End If
    End Sub
End Class