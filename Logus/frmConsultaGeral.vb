Imports Infragistics.Win.UltraWinGrid

Public Class frmConsultaGeral
    Inherits System.Windows.Forms.Form

    Enum eConsultaGeral
        AgregadosFornecedor = 1
        MovimentacaoBancaria_Item = 2
        MovimentacaoBancaria_Provisao = 3
        Aprovacoes_SolicitacaoCredito = 4
        Fretista = 5
        Filial = 6
        Cancelamento_ContratoPAF = 7
        Cancelamento_Negociacao = 8
        Cancelamento_ContratoFixo = 9
        ContratoFixo_Adendo = 10
        Aniversariantes = 11
        Tipo_Rd = 12
        UtilizacaoSistema = 13
        GrupoTipoMovimentacao = 14
        OperacaoBancariaTipoMovimentacao = 15
        PremioQualidadeInativo = 16
        TipoPagamento = 17
        OperaracaoBancaria = 18
        ItensBranch = 19
        TipoFretistaTributacao = 20
        ModalidadeConciliacao = 21
        TipoMovimentacao = 22
        BonusPadrao = 23
        MovimentacaoPosto = 24
        Armazem = 25
    End Enum

    Const cnt_GridAgregadosFornecedor_Codigo As Integer = 0
    Const cnt_GridAgregadosFornecedor_Nome As Integer = 1

    Const cnt_GridGrupoTipoProduto_Codigo As Integer = 0
    Const cnt_GridGrupoTipoProduto_Nome As Integer = 1
    Const cnt_GridGrupoTipoProduto_Ordem As Integer = 2

    Const cnt_GridMovimentacaoPosto_Filial As Integer = 0
    Const cnt_GridMovimentacaoPosto_Quantidade As Integer = 1

    Const cnt_GridItensBranch_Codigo As Integer = 0
    Const cnt_GridItensBranch_Nome As Integer = 1

    Const cnt_GridOperacaoBancaria_Codigo As Integer = 0
    Const cnt_GridOperacaoBancaria_Nome As Integer = 1
    Const cnt_GridOperacaoBancaria_ValorMaxCheque As Integer = 2
    Const cnt_GridOperacaoBancaria_CentroCusto As Integer = 3
    Const cnt_GridOperacaoBancaria_ContaContabil As Integer = 4
    Const cnt_GridOperacaoBancaria_DebitoCredito As Integer = 5
    Const cnt_GridOperacaoBancaria_EmiteCheque As Integer = 6
    Const cnt_GridOperacaoBancaria_LancaRD As Integer = 7
    Const cnt_GridOperacaoBancaria_TipoMovimentacao As Integer = 8
    Const cnt_GridOperacaoBancaria_ValorAliqCheia As Integer = 9
    Const cnt_GridOperacaoBancaria_AliqCheia As Integer = 10
    Const cnt_GridOperacaoBancaria_ValorSubAliq1 As Integer = 11
    Const cnt_GridOperacaoBancaria_SubAliq1 As Integer = 12
    Const cnt_GridOperacaoBancaria_ValorSubAliq2 As Integer = 13
    Const cnt_GridOperacaoBancaria_SubAliq2 As Integer = 14
    Const cnt_GridOperacaoBancaria_Filial As Integer = 15
    Const cnt_GridOperacaoBancaria_Ativo As Integer = 16

    Const cnt_GridOperBancariaTpMovimentacao_Codigo As Integer = 0
    Const cnt_GridOperBancariaTpMovimentacao_Nome As Integer = 1
    Const cnt_GridOperBancariaTpMovimentacao_CodigoOperBancaria As Integer = 2
    Const cnt_GridOperBancariaTpMovimentacao_OperBancaria As Integer = 3
    Const cnt_GridOperBancariaTpMovimentacao_CodigoTpMovimentacao As Integer = 4
    Const cnt_GridOperBancariaTpMovimentacao_TpMovimentacao As Integer = 5

    Const cnt_GridItemMovBanco_Fornecedor As Integer = 0
    Const cnt_GridItemMovBanco_Operação As Integer = 1
    Const cnt_GridItemMovBanco_Descricao As Integer = 2
    Const cnt_GridItemMovBanco_Valor As Integer = 3
    Const cnt_GridItemMovBanco_ValorProvisaoTotal As Integer = 4
    Const cnt_GridItemMovBanco_ValorLiquido As Integer = 5
    Const cnt_GridItemMovBanco_ValorBruto As Integer = 6
    Const cnt_GridItemMovBanco_Favorecido As Integer = 7
    Const cnt_GridItemMovBanco_FilialDebitada As Integer = 8
    Const cnt_GridItemMovBanco_SQ_ITEM_MOV_BANCARIO As Integer = 9

    Const cnt_GridProvisaoMovBanco_Provisao As Integer = 0
    Const cnt_GridProvisaoMovBanco_Valor As Integer = 1

    Const cnt_GridBonusQualidadeInativo_Nome As Integer = 0
    Const cnt_GridBonusQualidadeInativo_Contrato As Integer = 1
    Const cnt_GridBonusQualidadeInativo_Valor As Integer = 2

    Const cnt_GridTipoRD_Codigo As Integer = 0
    Const cnt_GridTipoRD_Descricao As Integer = 1
    Const cnt_GridTipoRD_TipoMovimentcaoSaldoFinal As Integer = 2
    Const cnt_GridTipoRD_Ativo As Integer = 3

    Const cnt_GridUtilizacaoSistema_CodigoTipo As Integer = 0
    Const cnt_GridUtilizacaoSistema_Tipo As Integer = 1
    Const cnt_GridUtilizacaoSistema_Codigo As Integer = 2
    Const cnt_GridUtilizacaoSistema_Nome As Integer = 3
    Const cnt_GridUtilizacaoSistema_PrimeiroAcesso As Integer = 4
    Const cnt_GridUtilizacaoSistema_UltimoAcesso As Integer = 5
    Const cnt_GridUtilizacaoSistema_QuantidadeAceso As Integer = 6

    Const cnt_GridAprovadores_Codigo As Integer = 0
    Const cnt_GridAprovadores_Data As Integer = 1
    Const cnt_GridAprovadores_TipoAprovacao As Integer = 2
    Const cnt_GridAprovadores_Usuario As Integer = 3
    Const cnt_GridAprovadores_Status As Integer = 4
    Const cnt_GridAprovadores_Descricao As Integer = 5

    Const cnt_GridAniversariante_Codigo As Integer = 0
    Const cnt_GridAniversariante_Filial As Integer = 1
    Const cnt_GridAniversariante_Data As Integer = 2
    Const cnt_GridAniversariante_Fornecedor As Integer = 3
    Const cnt_GridAniversariante_Telefone As Integer = 4
    Const cnt_GridAniversariante_Email As Integer = 5

    Const cnt_GridFretista_Codigo As Integer = 0
    Const cnt_GridFretista_Nome As Integer = 1
    Const cnt_GridFretista_TipoFretista As Integer = 2
    Const cnt_GridFretista_TipoPessoa As Integer = 3
    Const cnt_GridFretista_CNPJ As Integer = 4
    Const cnt_GridFretista_InscricaoINSS As Integer = 5
    Const cnt_GridFretista_PIS As Integer = 6
    Const cnt_GridFretista_Address As Integer = 7
    Const cnt_GridFretista_Favorecido As Integer = 8
    Const cnt_GridFretista_Dependetes As Integer = 9

    Const cnt_GridFilial_Codigo As Integer = 0
    Const cnt_GridFilial_Nome As Integer = 1
    Const cnt_GridFilial_RazaoSocial As Integer = 2
    Const cnt_GridFilial_CNPJ As Integer = 3
    Const cnt_GridFilial_Endereco As Integer = 4
    Const cnt_GridFilial_Municipio As Integer = 5
    Const cnt_GridFilial_FreteFazFil As Integer = 6
    Const cnt_GridFilial_FreteFilFab As Integer = 7
    Const cnt_GridFilial_FreteFab As Integer = 8
    Const cnt_GridFilial_VerificaPag As Integer = 9
    Const cnt_GridFilial_Ativa As Integer = 10
    Const cnt_GridFilial_LimiteVencidoKg As Integer = 11
    Const cnt_GridFilial_LimiteVencidoUS As Integer = 12
    Const cnt_GridFilial_LimiteAbertoKG As Integer = 13
    Const cnt_GridFilial_LimiteAbertoUS As Integer = 14
    Const cnt_GridFilial_ISS As Integer = 15
    Const cnt_GridFilial_Armazem As Integer = 16
    Const cnt_GridFilial_FilialResponsavel As Integer = 17
    Const cnt_GridFilial_CodigoFilialRDS As Integer = 18

    Const cnt_GridCancelamento_Seq As Integer = 0
    Const cnt_GridCancelamento_Data As Integer = 1
    Const cnt_GridCancelamento_Quantidade As Integer = 2
    Const cnt_GridCancelamento_Motivo As Integer = 3
    Const cnt_GridCancelamento_SQ_CONFISSAO_DIVIDA As Integer = 4
    Const cnt_GridCancelamento_IC_ESTORNO_CANCELAMENTO As Integer = 5

    Const cnt_GridTipoPagamento_Codigo As Integer = 0
    Const cnt_GridTipoPagamento_Nome As Integer = 1
    Const cnt_GridTipoPagamento_OperacaoBancaria As Integer = 2
    Const cnt_GridTipoPagamento_ICMS As Integer = 3
    Const cnt_GridTipoPagamento_FormaPagamento As Integer = 4
    Const cnt_GridTipoPagamento_Juros As Integer = 5
    Const cnt_GridTipoPagamento_Ativo As Integer = 6

    Const cnt_GridCtrFixAdendo_Data As Integer = 0
    Const cnt_GridCtrFixAdendo_Tipo As Integer = 1
    Const cnt_GridCtrFixAdendo_Valor As Integer = 2
    Const cnt_GridCtrFixAdendo_ValorICMS As Integer = 3
    Const cnt_GridCtrFixAdendo_ValorINSS As Integer = 4
    Const cnt_GridCtrFixAdendo_ContratoPAF As Integer = 5
    Const cnt_GridCtrFixAdendo_Negociacao As Integer = 6
    Const cnt_GridCtrFixAdendo_ContratoFixo As Integer = 7
    Const cnt_GridCtrFixAdendo_Seq As Integer = 8

    Const cnt_GridTipoFretistaTributacao_Codigo As Integer = 0
    Const cnt_GridTipoFretistaTributacao_Nome As Integer = 1
    Const cnt_GridTipoFretistaTributacao_BaseCalculo As Integer = 2
    Const cnt_GridTipoFretistaTributacao_DeducaoDependente As Integer = 3
    Const cnt_GridTipoFretistaTributacao_ValorMaximo As Integer = 4
    Const cnt_GridTipoFretistaTributacao_Provisao As Integer = 5
    Const cnt_GridTipoFretistaTributacao_NomeTributoDeducao As Integer = 6
    Const cnt_GridTipoFretistaTributacao_Sequencia As Integer = 7
    Const cnt_GridTipoFretistaTributacao_ValorMinimo As Integer = 8
    Const cnt_GridTipoFretistaTributacao_ISS As Integer = 9

    Const cnt_GridModalidadeConciliacao_Codigo As Integer = 0
    Const cnt_GridModalidadeConciliacao_Nome As Integer = 1
    Const cnt_GridModalidadeConciliacao_ContaPagamentoCredito As Integer = 2
    Const cnt_GridModalidadeConciliacao_ContaPagamentoDebito As Integer = 3
    Const cnt_GridModalidadeConciliacao_ContaMovimentacaoCredito As Integer = 4
    Const cnt_GridModalidadeConciliacao_ContaMovimentacaoDebito As Integer = 5
    Const cnt_GridModalidadeConciliacao_LancaRD As Integer = 6
    Const cnt_GridModalidadeConciliacao_Tipo As Integer = 7
    Const cnt_GridModalidadeConciliacao_FilialFixa As Integer = 8
    Const cnt_GridModalidadeConciliacao_TipoMovimentacao As Integer = 9
    Const cnt_GridModalidadeConciliacao_Ativo As Integer = 10

    Const cnt_GridTipoMovimentacao_Codigo As Integer = 0
    Const cnt_GridTipoMovimentacao_Descricao As Integer = 1
    Const cnt_GridTipoMovimentacao_TipoRD As Integer = 2
    Const cnt_GridTipoMovimentacao_EntradaSaida As Integer = 3
    Const cnt_GridTipoMovimentacao_ContaContabil As Integer = 4
    Const cnt_GridTipoMovimentacao_MudaFilialCC As Integer = 5
    Const cnt_GridTipoMovimentacao_ContaContabilContraPartida As Integer = 6
    Const cnt_GridTipoMovimentacao_MudaFilialCC_ContraPartida As Integer = 7
    Const cnt_GridTipoMovimentacao_SubLedger As Integer = 8
    Const cnt_GridTipoMovimentacao_TipoSubLedger As Integer = 9
    Const cnt_GridTipoMovimentacao_SubLedgerContraPartida As Integer = 10
    Const cnt_GridTipoMovimentacao_TipoSubLedgerContraPartida As Integer = 11
    Const cnt_GridTipoMovimentacao_ValidaQuilos As Integer = 12
    Const cnt_GridTipoMovimentacao_ValidaQualidade As Integer = 13
    Const cnt_GridTipoMovimentacao_ValidaValor As Integer = 14
    Const cnt_GridTipoMovimentacao_Importado As Integer = 15
    Const cnt_GridTipoMovimentacao_Fiscal As Integer = 16
    Const cnt_GridTipoMovimentacao_LocalEntrega As Integer = 17
    Const cnt_GridTipoMovimentacao_Ativo As Integer = 18

    Const cnt_GridBonusPadrao_Codigo As Integer = 0
    Const cnt_GridBonusPadrao_Nome As Integer = 1
    Const cnt_GridBonusPadrao_Ativo As Integer = 2

    Const cnt_GridArmazem_Codigo As Integer = 0
    Const cnt_GridArmazem_Nome As Integer = 1
    Const cnt_GridArmazem_Ativo As Integer = 2

    Dim iTipoTela As eConsultaGeral

    Public FiltroLocal_01 As Integer
    Public FiltroLocal_02 As Integer
    Public FiltroLocal_03 As Integer
    Public GerouAlteracaoInformacao As Boolean = False

    Dim WithEvents oForm_Fretista As frmCadastroFretista
    Dim WithEvents oForm_Filial As frmCadastroFilial
    Dim WithEvents oForm_TipoRd As frmCadastroTipoRD
    Dim WithEvents oForm_OperTpMov As frmCadastroOperBancariaTpMovimentacao
    Dim WithEvents oForm_UtilizacaoSistema As frmCadastroUtilizacaoSistema
    Dim WithEvents oForm_grpTipoMovimentacao As frmCadastroGrupoTipoMovimentacao
    Dim WithEvents oForm_TipoPagamento As frmCadastroTipoPagamento
    Dim WithEvents oForm_OperacaoBancaria As frmCadastroOperacaoBancaria
    Dim WithEvents oForm_ItemBranch As frmCadastroItensBranch
    Dim WithEvents oForm_TipoFretistaTributacao As frmCadastroTipoFretistaTributacao
    Dim WithEvents oForm_ModalidadeConciliacao As frmCadastroModalidadeConciliacao
    Dim WithEvents oForm_TipoMovimentacao As frmCadastroTipoMovimentacao
    Dim WithEvents oForm_BonusPadrao As frmCadastroBonusPadrao
    Dim WithEvents oForm_Armazem As frmCadastroArmazem

    Public Sub FormatarTela(ByVal TipoTela As eConsultaGeral)
        Dim sTituloListagem As String = String.Empty
        Dim sTituloTela As String = String.Empty
        Dim cnt_SEC_Tela As String = ""
        Dim iCont As Integer

        iTipoTela = TipoTela

        If FiltroLocal_01 = 0 Then
            FiltroLocal_01 = Filtro
        End If

        CarregarDados()

        Select Case iTipoTela
            Case eConsultaGeral.Fretista
                cnt_SEC_Tela = "Cadastro_Fretista"
            Case eConsultaGeral.Filial
                cnt_SEC_Tela = "Cadastro_Administrativo_Filial"
            Case eConsultaGeral.Tipo_Rd
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoRD"
            Case eConsultaGeral.UtilizacaoSistema
                cnt_SEC_Tela = "Cadastro_Administrativo_UtilizacaoSistema"
            Case eConsultaGeral.GrupoTipoMovimentacao
                cnt_SEC_Tela = "Cadastro_Movimentacao_GrupoTipoMovimentacao"
            Case eConsultaGeral.OperacaoBancariaTipoMovimentacao
                cnt_SEC_Tela = "Cadastro_Contabil_OperacaoBancariaTipoMovimentacao"
            Case eConsultaGeral.PremioQualidadeInativo
                cnt_SEC_Tela = "Transacao_Contratos_PremioQualidadeInativo"
            Case eConsultaGeral.TipoPagamento
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoPagamento"
            Case eConsultaGeral.OperaracaoBancaria
                cnt_SEC_Tela = "Cadastro_Contabil_OperacaoBancaria"
            Case eConsultaGeral.ItensBranch
                cnt_SEC_Tela = "Cadastro_Contabil_ItensBranch"
            Case eConsultaGeral.TipoFretistaTributacao
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoFretistaTributacao"
            Case eConsultaGeral.ModalidadeConciliacao
                cnt_SEC_Tela = "Cadastro_Contabil_ModalidadeConciliacao"
            Case eConsultaGeral.TipoMovimentacao
                cnt_SEC_Tela = "Cadastro_Administrativo_TipoMovimentacao"
            Case eConsultaGeral.BonusPadrao
                cnt_SEC_Tela = "Cadastro_Administrativo_BonusPadrao"
            Case eConsultaGeral.Armazem
                cnt_SEC_Tela = "Cadastro_Movimentacao_Armazem"
            Case Else
                cnt_SEC_Tela = ""
        End Select

        '>>> Formatação do título da tela e título da listagem - Início
        cmdAlterar.Visible = False
        cmdExcluir.Visible = False
        cmdNovo.Visible = False
        cmdUsuario.Visible = False
        cmdEspecial_01.Visible = False
        cmdEspecial_02.Visible = False

        objGrid_Inicializar(grdGeral, AllowAddNew.No, , CellClickAction.CellSelect, , _
                                      Infragistics.Win.DefaultableBoolean.False, True, , , , True)

        Select Case iTipoTela
            Case eConsultaGeral.AgregadosFornecedor
                sTituloListagem = "Listagem dos Agregados"
                sTituloTela = "Consulta de Agregados"

                objGrid_Coluna_Add(grdGeral, "Código do Fornecedor", 130, cnt_GridAgregadosFornecedor_Codigo, False)
                objGrid_Coluna_Add(grdGeral, "Nome do Fornecedor", 300, cnt_GridAgregadosFornecedor_Nome, False)
            Case eConsultaGeral.ItensBranch
                sTituloListagem = "Listagem dos Itens Branch"
                sTituloTela = "Consulta de Itens Branch"

                objGrid_Coluna_Add(grdGeral, "Código", 130, cnt_GridItensBranch_Codigo, False)
                objGrid_Coluna_Add(grdGeral, "Descrição", 300, cnt_GridItensBranch_Nome, False)

                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
            Case eConsultaGeral.GrupoTipoMovimentacao
                sTituloListagem = "Listagem dos Grupos Tipo de Movimentação"
                sTituloTela = "Consulta de Grupos Tipo de Movimentação"

                objGrid_Coluna_Add(grdGeral, "Código", 0, cnt_GridGrupoTipoProduto_Codigo, False)
                objGrid_Coluna_Add(grdGeral, "Nome do Grupo", 300, cnt_GridGrupoTipoProduto_Nome, False)
                objGrid_Coluna_Add(grdGeral, "Ordem", 100, cnt_GridGrupoTipoProduto_Ordem, False)

                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
            Case eConsultaGeral.MovimentacaoPosto
                If FiltroLocal_01 = 1 Then
                    sTituloListagem = "Listagem Posto Fazenda"
                    sTituloTela = "Posto Fazenda"
                Else
                    sTituloListagem = "Listagem Posto Filial"
                    sTituloTela = "Posto Filial"
                End If

                objGrid_Coluna_Add(grdGeral, "Filial", 180, cnt_GridMovimentacaoPosto_Filial, False)
                objGrid_Coluna_Add(grdGeral, "Quantidade", 120, cnt_GridMovimentacaoPosto_Quantidade, False, , , cnt_Formato_Kilos)

                cmdAlterar.Visible = False
                cmdExcluir.Visible = False
                cmdNovo.Visible = False
                cmdUsuario.Visible = False
                cmdUsuario.Visible = False
                Me.Width = 350
                Me.Height = 250
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            Case eConsultaGeral.PremioQualidadeInativo
                sTituloListagem = "Listagem dos Premios de Qualidade Inativos"
                sTituloTela = "Consulta de Premios de Qualidade Inativos"

                objGrid_Coluna_Add(grdGeral, "Descrição", 230, cnt_GridBonusQualidadeInativo_Nome, False)
                objGrid_Coluna_Add(grdGeral, "Contrato", 150, cnt_GridBonusQualidadeInativo_Contrato, False)
                objGrid_Coluna_Add(grdGeral, "Valor", 100, cnt_GridBonusQualidadeInativo_Valor, False)

                cmdExcluir.Visible = True
            Case eConsultaGeral.OperacaoBancariaTipoMovimentacao
                sTituloListagem = "Listagem das Operações Bancarias X Tipo Movimentação"
                sTituloTela = "Consulta de Operações Bancarias X Tipo Movimentação"

                objGrid_Coluna_Add(grdGeral, "Código", 80, cnt_GridOperBancariaTpMovimentacao_Codigo, False)
                objGrid_Coluna_Add(grdGeral, "Descrição", 200, cnt_GridOperBancariaTpMovimentacao_Nome, False)
                objGrid_Coluna_Add(grdGeral, "Código", 80, cnt_GridOperBancariaTpMovimentacao_CodigoOperBancaria, False)
                objGrid_Coluna_Add(grdGeral, "Operação Bancaria", 200, cnt_GridOperBancariaTpMovimentacao_OperBancaria, False)
                objGrid_Coluna_Add(grdGeral, "Código", 80, cnt_GridOperBancariaTpMovimentacao_CodigoTpMovimentacao, False)
                objGrid_Coluna_Add(grdGeral, "Tipo Movimentação", 200, cnt_GridOperBancariaTpMovimentacao_TpMovimentacao, False)

                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
            Case eConsultaGeral.Fretista
                sTituloListagem = "Listagem dos Fretistas"
                sTituloTela = "Consulta de Fretistas"

                objGrid_Coluna_Add(grdGeral, "Código", 80, cnt_GridFretista_Codigo, False)
                objGrid_Coluna_Add(grdGeral, "Nome do Fretista", 180, cnt_GridFretista_Nome, False)
                objGrid_Coluna_Add(grdGeral, "Tipo Fretista", 120, cnt_GridFretista_TipoFretista, False)
                objGrid_Coluna_Add(grdGeral, "Tipo Pessoa", 100, cnt_GridFretista_TipoPessoa, False)
                objGrid_Coluna_Add(grdGeral, "CNPJ/CPF", 100, cnt_GridFretista_CNPJ, False)
                objGrid_Coluna_Add(grdGeral, "Inscrição INSS", 100, cnt_GridFretista_InscricaoINSS, False)
                objGrid_Coluna_Add(grdGeral, "PIS/PASEP", 100, cnt_GridFretista_PIS, False)
                objGrid_Coluna_Add(grdGeral, "Address", 80, cnt_GridFretista_Address, False)
                objGrid_Coluna_Add(grdGeral, "Favorecido", 180, cnt_GridFretista_Favorecido, False)
                objGrid_Coluna_Add(grdGeral, "Dependentes", 80, cnt_GridFretista_Dependetes, False)


                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
            Case eConsultaGeral.Aprovacoes_SolicitacaoCredito
                sTituloListagem = "Listagem dos Aprovações"
                sTituloTela = "Consulta de Aprovações"

                objGrid_Coluna_Add(grdGeral, "Código", 0, cnt_GridAprovadores_Codigo, False)
                objGrid_Coluna_Add(grdGeral, "Data", 80, cnt_GridAprovadores_Data, False)
                objGrid_Coluna_Add(grdGeral, "Tipo Aprovação", 140, cnt_GridAprovadores_TipoAprovacao, False)
                objGrid_Coluna_Add(grdGeral, "Usuário", 130, cnt_GridAprovadores_Usuario, False)
                objGrid_Coluna_Add(grdGeral, "Status", 80, cnt_GridAprovadores_Status, False)
                objGrid_Coluna_Add(grdGeral, "Descrição", 200, cnt_GridAprovadores_Descricao, False, , , , Infragistics.Win.DefaultableBoolean.True)

                For iCont = 0 To grdGeral.Rows.Count - 1
                    grdGeral.Rows(iCont).PerformAutoSize()
                Next
            Case eConsultaGeral.MovimentacaoBancaria_Item
                sTituloListagem = "Listagem dos Itens da Movimentação Bancária"
                sTituloTela = "Consulta de Itens da Movimentação Bancária"

                objGrid_Coluna_Add(grdGeral, "Fornecedor", 150, cnt_GridItemMovBanco_Fornecedor)
                objGrid_Coluna_Add(grdGeral, "Operação", 150, cnt_GridItemMovBanco_Operação)
                objGrid_Coluna_Add(grdGeral, "Descrição", 150, cnt_GridItemMovBanco_Descricao)
                objGrid_Coluna_Add(grdGeral, "Valor", 100, cnt_GridItemMovBanco_Valor, , , , cnt_Formato_Valor)
                objGrid_Coluna_Add(grdGeral, "Valor Provisao Total", 100, cnt_GridItemMovBanco_ValorProvisaoTotal, , , , cnt_Formato_Valor)
                objGrid_Coluna_Add(grdGeral, "Valor Liquido", 100, cnt_GridItemMovBanco_ValorLiquido, , , , cnt_Formato_Valor)
                objGrid_Coluna_Add(grdGeral, "Valor Bruto", 100, cnt_GridItemMovBanco_ValorBruto, , , , cnt_Formato_Valor)
                objGrid_Coluna_Add(grdGeral, "Favorecido", 150, cnt_GridItemMovBanco_Favorecido)
                objGrid_Coluna_Add(grdGeral, "Filial Debitada", 110, cnt_GridItemMovBanco_FilialDebitada)
                objGrid_Coluna_Add(grdGeral, "SQ_ITEM_MOV_BANCARIO", 0, cnt_GridItemMovBanco_SQ_ITEM_MOV_BANCARIO)

                cmdEspecial_01.Visible = True

                Form_Botao_Formatar(cmdEspecial_01, "cmdProvisao")
            Case eConsultaGeral.MovimentacaoBancaria_Provisao
                sTituloListagem = "Listagem dos Itens Provisionados"
                sTituloTela = "Consulta de Provisão da Movimentação Bancária"

                objGrid_Coluna_Add(grdGeral, "Provisão", 300, cnt_GridProvisaoMovBanco_Provisao)
                objGrid_Coluna_Add(grdGeral, "Valor", 200, cnt_GridProvisaoMovBanco_Valor, , , , cnt_Formato_Valor)
            Case eConsultaGeral.Filial
                sTituloListagem = "Listagem das Filiais"
                sTituloTela = "Consulta Filiais"

                objGrid_Coluna_Add(grdGeral, "Codigo", 70, cnt_GridFilial_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome Fantasia", 150, cnt_GridFilial_Nome)
                objGrid_Coluna_Add(grdGeral, "Razão Social", 160, cnt_GridFilial_RazaoSocial)
                objGrid_Coluna_Add(grdGeral, "CNPJ", 120, cnt_GridFilial_CNPJ)
                objGrid_Coluna_Add(grdGeral, "Endereço", 200, cnt_GridFilial_Endereco)
                objGrid_Coluna_Add(grdGeral, "Municipio", 120, cnt_GridFilial_Municipio)
                objGrid_Coluna_Add(grdGeral, "Frete Fazenda->Filial", 120, cnt_GridFilial_FreteFazFil, , , , cnt_Formato_Valor)
                objGrid_Coluna_Add(grdGeral, "Frete Filial->Fabrica", 120, cnt_GridFilial_FreteFilFab, , , , cnt_Formato_Valor)
                objGrid_Coluna_Add(grdGeral, "Frete Fabrica", 120, cnt_GridFilial_FreteFab, , , , cnt_Formato_Valor)
                objGrid_Coluna_Add(grdGeral, "Verif Pag Fecha", 120, cnt_GridFilial_VerificaPag)
                objGrid_Coluna_Add(grdGeral, "Ativa", 70, cnt_GridFilial_Ativa)
                objGrid_Coluna_Add(grdGeral, "Lim.Venc.(KGS)", 120, cnt_GridFilial_LimiteVencidoKg, , , , cnt_Formato_Kilos)
                objGrid_Coluna_Add(grdGeral, "Lim.Venc.(USS)", 120, cnt_GridFilial_LimiteVencidoUS, , , , cnt_Formato_Valor_US)
                objGrid_Coluna_Add(grdGeral, "Lim.Abert.(KGS)", 120, cnt_GridFilial_LimiteAbertoKG, , , , cnt_Formato_Kilos)
                objGrid_Coluna_Add(grdGeral, "Lim.Abert.(USS)", 120, cnt_GridFilial_LimiteAbertoUS, , , , cnt_Formato_Valor_US)
                objGrid_Coluna_Add(grdGeral, "Aliq ISS", 100, cnt_GridFilial_ISS, , , , cnt_Formato_Porcentagem)
                objGrid_Coluna_Add(grdGeral, "Armazem", 80, cnt_GridFilial_Armazem)
                objGrid_Coluna_Add(grdGeral, "Filial Responsavel", 160, cnt_GridFilial_FilialResponsavel)
                objGrid_Coluna_Add(grdGeral, "Código Filial no RDS", 160, cnt_GridFilial_CodigoFilialRDS)

                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
            Case eConsultaGeral.Cancelamento_ContratoPAF
                sTituloTela = "Consulta contrato PAF cancelado. Nº PAF: " & FiltroLocal_01
                sTituloListagem = "Listagem de Cancelamentos de Contratos PAF"

                objGrid_Coluna_Add(grdGeral, "Seq", 50, cnt_GridCancelamento_Seq)
                objGrid_Coluna_Add(grdGeral, "Data", 130, cnt_GridCancelamento_Data, , , , cnt_Formato_Data)
                objGrid_Coluna_Add(grdGeral, "Quantidade", 150, cnt_GridCancelamento_Quantidade)
                objGrid_Coluna_Add(grdGeral, "Motivo", 300, cnt_GridCancelamento_Motivo)
                objGrid_Coluna_Add(grdGeral, "SQ_CONFISSAO_DIVIDA", 0, cnt_GridCancelamento_SQ_CONFISSAO_DIVIDA)

                SEC_ValidarBotao_Permissao(cmdExcluir, SEC_Permissao.SEC_P_Acesso_CancelarContratoPAF, True)
            Case eConsultaGeral.Cancelamento_Negociacao
                sTituloTela = "Consulta negociação cancelada. Nº PAF: " & FiltroLocal_01 & _
                                                            " Nº Negociação: " & FiltroLocal_02
                sTituloListagem = "Listagem de Cancelamentos de Negociação"

                objGrid_Coluna_Add(grdGeral, "Seq", 50, cnt_GridCancelamento_Seq)
                objGrid_Coluna_Add(grdGeral, "Data", 130, cnt_GridCancelamento_Data, , , , cnt_Formato_Data)
                objGrid_Coluna_Add(grdGeral, "Quantidade", 150, cnt_GridCancelamento_Quantidade)
                objGrid_Coluna_Add(grdGeral, "Motivo", 300, cnt_GridCancelamento_Motivo)
                objGrid_Coluna_Add(grdGeral, "SQ_CONFISSAO_DIVIDA", 0, cnt_GridCancelamento_SQ_CONFISSAO_DIVIDA)
                objGrid_Coluna_Add(grdGeral, "IC_ESTORNO_CANCELAMENTO", 0, cnt_GridCancelamento_IC_ESTORNO_CANCELAMENTO)

                SEC_ValidarBotao_Permissao(cmdExcluir, SEC_Permissao.SEC_P_Acesso_CancelarNegociacaoContrato, True)
            Case eConsultaGeral.Cancelamento_ContratoFixo
                sTituloTela = "Consulta negociação cancelada. Nº PAF: " & FiltroLocal_01 & _
                                                            " Nº Negociação: " & FiltroLocal_02 & _
                                                            " Nº Contrato Fixo: " & FiltroLocal_03
                sTituloListagem = "Listagem de Cancelamentos de Contrato Fixo"

                objGrid_Coluna_Add(grdGeral, "Seq", 50, cnt_GridCancelamento_Seq)
                objGrid_Coluna_Add(grdGeral, "Data", 130, cnt_GridCancelamento_Data, , , , cnt_Formato_Data)
                objGrid_Coluna_Add(grdGeral, "Quantidade", 150, cnt_GridCancelamento_Quantidade)
                objGrid_Coluna_Add(grdGeral, "Motivo", 300, cnt_GridCancelamento_Motivo)
                objGrid_Coluna_Add(grdGeral, "SQ_CONFISSAO_DIVIDA", 0, cnt_GridCancelamento_SQ_CONFISSAO_DIVIDA)

                SEC_ValidarBotao_Permissao(cmdExcluir, SEC_Permissao.SEC_P_Acesso_CancelarContratoFixo, True)
            Case eConsultaGeral.ContratoFixo_Adendo
                sTituloTela = "Contrato Fixo - Adendos"
                sTituloListagem = "Listagem de Contrato Fixo - Adendos"

                objGrid_Coluna_Add(grdGeral, "Data", 100, cnt_GridCtrFixAdendo_Data, , , , cnt_Formato_Data)
                objGrid_Coluna_Add(grdGeral, "Tipo", 100, cnt_GridCtrFixAdendo_Tipo)
                objGrid_Coluna_Add(grdGeral, "Valor", 100, cnt_GridCtrFixAdendo_Valor)
                objGrid_Coluna_Add(grdGeral, "Valor ICMS", 100, cnt_GridCtrFixAdendo_ValorICMS)
                objGrid_Coluna_Add(grdGeral, "Valor INSS", 100, cnt_GridCtrFixAdendo_ValorINSS)
                objGrid_Coluna_Add(grdGeral, "Contrato PAF", 100, cnt_GridCtrFixAdendo_ContratoPAF)
                objGrid_Coluna_Add(grdGeral, "Negociação", 100, cnt_GridCtrFixAdendo_Negociacao)
                objGrid_Coluna_Add(grdGeral, "Contrato Fixo", 100, cnt_GridCtrFixAdendo_ContratoFixo)
                objGrid_Coluna_Add(grdGeral, "Seq", 100, cnt_GridCtrFixAdendo_Seq)

                SEC_ValidarBotao_Permissao(cmdExcluir, SEC_Permissao.SEC_P_Acesso_EliminarAdendoContratoFixo, True)
            Case eConsultaGeral.Aniversariantes
                sTituloTela = "Consulta Aniversariantes"
                sTituloListagem = "Listagem de Fornecedores que Fazem Aniversario"

                objGrid_Coluna_Add(grdGeral, "Código", 0, cnt_GridAniversariante_Codigo)
                objGrid_Coluna_Add(grdGeral, "Filial", 130, cnt_GridAniversariante_Filial)
                objGrid_Coluna_Add(grdGeral, "Aniversario", 90, cnt_GridAniversariante_Data, , , , cnt_Formato_Data)
                objGrid_Coluna_Add(grdGeral, "Fornecedor", 200, cnt_GridAniversariante_Fornecedor)
                objGrid_Coluna_Add(grdGeral, "Telefone", 100, cnt_GridAniversariante_Telefone)
                objGrid_Coluna_Add(grdGeral, "E-mail", 200, cnt_GridAniversariante_Email)
            Case eConsultaGeral.Tipo_Rd
                sTituloTela = "Consulta Tipo RD"
                sTituloListagem = "Listagem de Tipos de RD"

                objGrid_Coluna_Add(grdGeral, "Código", 80, cnt_GridTipoRD_Codigo)
                objGrid_Coluna_Add(grdGeral, "Descrição", 150, cnt_GridTipoRD_Descricao)
                objGrid_Coluna_Add(grdGeral, "Tipo Movimentação Saldo Final", 250, cnt_GridTipoRD_TipoMovimentcaoSaldoFinal)
                objGrid_Coluna_Add(grdGeral, "Ativo", 60, cnt_GridTipoRD_Ativo, , ColumnStyle.CheckBox)

                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
            Case eConsultaGeral.UtilizacaoSistema
                sTituloTela = "Consulta Utilização Sistema"
                sTituloListagem = "Listagem de Utilização Sistema"

                objGrid_Coluna_Add(grdGeral, "Código Tipo", 0, cnt_GridUtilizacaoSistema_CodigoTipo)
                objGrid_Coluna_Add(grdGeral, "Tipo", 150, cnt_GridUtilizacaoSistema_Tipo)
                objGrid_Coluna_Add(grdGeral, "Código", 80, cnt_GridUtilizacaoSistema_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 250, cnt_GridUtilizacaoSistema_Nome)
                objGrid_Coluna_Add(grdGeral, "Primeiro Acesso", 150, cnt_GridUtilizacaoSistema_PrimeiroAcesso)
                objGrid_Coluna_Add(grdGeral, "Ultimo Acesso", 150, cnt_GridUtilizacaoSistema_UltimoAcesso)
                objGrid_Coluna_Add(grdGeral, "Acessos", 100, cnt_GridUtilizacaoSistema_QuantidadeAceso)

                cmdAlterar.Visible = True
                cmdUsuario.Visible = True
                cmdEspecial_01.Visible = True

                Form_Botao_Formatar(cmdEspecial_01, "CMDIMPRIMIR")
            Case eConsultaGeral.TipoPagamento
                sTituloTela = "Consulta de Pagamento"
                sTituloListagem = "Listagem de Pagamento"

                objGrid_Coluna_Add(grdGeral, "Código", 60, cnt_GridTipoPagamento_Codigo)
                objGrid_Coluna_Add(grdGeral, "Tipo", 180, cnt_GridTipoPagamento_Nome)
                objGrid_Coluna_Add(grdGeral, "Operação Bancaria", 180, cnt_GridTipoPagamento_OperacaoBancaria)
                objGrid_Coluna_Add(grdGeral, "ICMS", 80, cnt_GridTipoPagamento_ICMS, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Forma Pagamento", 120, cnt_GridTipoPagamento_FormaPagamento)
                objGrid_Coluna_Add(grdGeral, "Juros", 80, cnt_GridTipoPagamento_Juros, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Ativo", 80, cnt_GridTipoPagamento_Ativo, , ColumnStyle.CheckBox)

                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
            Case eConsultaGeral.OperaracaoBancaria
                sTituloTela = "Consulta Operação Bancaria"
                sTituloListagem = "Listagem de Operação Bancaria"

                objGrid_Coluna_Add(grdGeral, "Código", 60, cnt_GridOperacaoBancaria_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 180, cnt_GridOperacaoBancaria_Nome)
                objGrid_Coluna_Add(grdGeral, "Valor Max Cheque", 120, cnt_GridOperacaoBancaria_ValorMaxCheque)
                objGrid_Coluna_Add(grdGeral, "Centro de Custo", 120, cnt_GridOperacaoBancaria_CentroCusto)
                objGrid_Coluna_Add(grdGeral, "Conta Contabil", 120, cnt_GridOperacaoBancaria_ContaContabil)
                objGrid_Coluna_Add(grdGeral, "Tipo", 80, cnt_GridOperacaoBancaria_DebitoCredito)
                objGrid_Coluna_Add(grdGeral, "Emite Cheque", 100, cnt_GridOperacaoBancaria_EmiteCheque, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Lança RD", 90, cnt_GridOperacaoBancaria_LancaRD, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Tipo Movimentação", 150, cnt_GridOperacaoBancaria_TipoMovimentacao)
                objGrid_Coluna_Add(grdGeral, "Valor Aliq Cheia", 120, cnt_GridOperacaoBancaria_ValorAliqCheia)
                objGrid_Coluna_Add(grdGeral, "Aliquota Cheia", 120, cnt_GridOperacaoBancaria_AliqCheia)
                objGrid_Coluna_Add(grdGeral, "Valor Sub Aliq 1", 120, cnt_GridOperacaoBancaria_ValorSubAliq1)
                objGrid_Coluna_Add(grdGeral, "Sub Aliq 1", 100, cnt_GridOperacaoBancaria_SubAliq1)
                objGrid_Coluna_Add(grdGeral, "Valor Sub Aliq 1", 120, cnt_GridOperacaoBancaria_ValorSubAliq2)
                objGrid_Coluna_Add(grdGeral, "Sub Aliq 1", 100, cnt_GridOperacaoBancaria_SubAliq2)
                objGrid_Coluna_Add(grdGeral, "Filial Default", 150, cnt_GridOperacaoBancaria_Filial)
                objGrid_Coluna_Add(grdGeral, "Ativo", 150, cnt_GridOperacaoBancaria_Ativo, , ColumnStyle.CheckBox)

                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
            Case eConsultaGeral.TipoFretistaTributacao
                sTituloTela = "Consulta Tipo Fretista Tributação"
                sTituloListagem = "Listagem de Tipo Fretista Tributação"

                objGrid_Coluna_Add(grdGeral, "Código", 50, cnt_GridTipoFretistaTributacao_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 100, cnt_GridTipoFretistaTributacao_Nome)
                objGrid_Coluna_Add(grdGeral, "Base Cálculo", 110, cnt_GridTipoFretistaTributacao_BaseCalculo)
                objGrid_Coluna_Add(grdGeral, "Dedução por Dependente", 120, cnt_GridTipoFretistaTributacao_DeducaoDependente, , , , cnt_Formato_Valor)
                objGrid_Coluna_Add(grdGeral, "Valor Maximo", 120, cnt_GridTipoFretistaTributacao_ValorMaximo, , , , cnt_Formato_Valor)
                objGrid_Coluna_Add(grdGeral, "Provisão", 180, cnt_GridTipoFretistaTributacao_Provisao)
                objGrid_Coluna_Add(grdGeral, "Tributo Dedução", 180, cnt_GridTipoFretistaTributacao_NomeTributoDeducao)
                objGrid_Coluna_Add(grdGeral, "Sequência", 80, cnt_GridTipoFretistaTributacao_Sequencia)
                objGrid_Coluna_Add(grdGeral, "Valor Minimo", 120, cnt_GridTipoFretistaTributacao_ValorMinimo, , , , cnt_Formato_Valor)
                objGrid_Coluna_Add(grdGeral, "ISS", 60, cnt_GridTipoFretistaTributacao_ISS, , ColumnStyle.CheckBox)

                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
            Case eConsultaGeral.ModalidadeConciliacao
                sTituloTela = "Consulta Modalidade Conciliação"
                sTituloListagem = "Listagem de Modalidade Conciliação"

                objGrid_Coluna_Add(grdGeral, "Código", 40, cnt_GridModalidadeConciliacao_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 200, cnt_GridModalidadeConciliacao_Nome)
                objGrid_Coluna_Add(grdGeral, "CC Pag Crédito", 130, cnt_GridModalidadeConciliacao_ContaPagamentoCredito)
                objGrid_Coluna_Add(grdGeral, "CC Pag Débito", 130, cnt_GridModalidadeConciliacao_ContaPagamentoDebito)
                objGrid_Coluna_Add(grdGeral, "CC Mov Crédito", 130, cnt_GridModalidadeConciliacao_ContaMovimentacaoCredito)
                objGrid_Coluna_Add(grdGeral, "CC Mov Débito", 130, cnt_GridModalidadeConciliacao_ContaMovimentacaoDebito)
                objGrid_Coluna_Add(grdGeral, "Lança RD", 60, cnt_GridModalidadeConciliacao_LancaRD, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Tipo", 120, cnt_GridModalidadeConciliacao_Tipo)
                objGrid_Coluna_Add(grdGeral, "Filial Fixa", 160, cnt_GridModalidadeConciliacao_FilialFixa)
                objGrid_Coluna_Add(grdGeral, "Tipo Movimentação", 200, cnt_GridModalidadeConciliacao_TipoMovimentacao)
                objGrid_Coluna_Add(grdGeral, "Ativo", 70, cnt_GridModalidadeConciliacao_Ativo, , ColumnStyle.CheckBox)

                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
            Case eConsultaGeral.TipoMovimentacao
                sTituloTela = "Consulta de Tipo de Movimentação"
                sTituloListagem = "Listagem de Tipo de Movimentação"

                objGrid_Coluna_Add(grdGeral, "Código", 40, cnt_GridTipoMovimentacao_Codigo)
                objGrid_Coluna_Add(grdGeral, "Descrição", 200, cnt_GridTipoMovimentacao_Descricao)
                objGrid_Coluna_Add(grdGeral, "Tipo RD", 80, cnt_GridTipoMovimentacao_TipoRD)
                objGrid_Coluna_Add(grdGeral, "Ent/Sai", 80, cnt_GridTipoMovimentacao_EntradaSaida)
                objGrid_Coluna_Add(grdGeral, "Conta Contabil", 130, cnt_GridTipoMovimentacao_ContaContabil)
                objGrid_Coluna_Add(grdGeral, "Muda Fil", 70, cnt_GridTipoMovimentacao_MudaFilialCC, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Contra Partida", 130, cnt_GridTipoMovimentacao_ContaContabilContraPartida)
                objGrid_Coluna_Add(grdGeral, "Muda Fil", 70, cnt_GridTipoMovimentacao_MudaFilialCC_ContraPartida, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "SubLedger", 100, cnt_GridTipoMovimentacao_SubLedger)
                objGrid_Coluna_Add(grdGeral, "Tipo SubLedger", 120, cnt_GridTipoMovimentacao_TipoSubLedger)
                objGrid_Coluna_Add(grdGeral, "SubLedger CP", 100, cnt_GridTipoMovimentacao_SubLedgerContraPartida)
                objGrid_Coluna_Add(grdGeral, "Tipo SubLedger CP", 120, cnt_GridTipoMovimentacao_TipoSubLedgerContraPartida)
                objGrid_Coluna_Add(grdGeral, "Valida Quilos", 120, cnt_GridTipoMovimentacao_ValidaQuilos, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Valda Qualidade", 130, cnt_GridTipoMovimentacao_ValidaQualidade, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Valida Valor", 120, cnt_GridTipoMovimentacao_ValidaValor, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Importado", 80, cnt_GridTipoMovimentacao_Importado, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Fiscal", 70, cnt_GridTipoMovimentacao_Fiscal, , ColumnStyle.CheckBox)
                objGrid_Coluna_Add(grdGeral, "Local Entrega", 120, cnt_GridTipoMovimentacao_LocalEntrega)
                objGrid_Coluna_Add(grdGeral, "Ativo", 70, cnt_GridTipoMovimentacao_Ativo, , ColumnStyle.CheckBox)

                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
            Case eConsultaGeral.BonusPadrao
                sTituloTela = "Consulta Bônus Padrão"
                sTituloListagem = "Listagem de Bônus Padrão"

                objGrid_Coluna_Add(grdGeral, "Código", 60, cnt_GridBonusPadrao_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 200, cnt_GridBonusPadrao_Nome)
                objGrid_Coluna_Add(grdGeral, "Ativo", 80, cnt_GridBonusPadrao_Ativo, , ColumnStyle.CheckBox)

                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
            Case eConsultaGeral.Armazem
                sTituloTela = "Consulta Armazém"
                sTituloListagem = "Listagem de Armazém"

                objGrid_Coluna_Add(grdGeral, "Código", 0, cnt_GridArmazem_Codigo)
                objGrid_Coluna_Add(grdGeral, "Nome", 200, cnt_GridArmazem_Nome)
                objGrid_Coluna_Add(grdGeral, "Ativo", 80, cnt_GridArmazem_Ativo, , ColumnStyle.CheckBox)

                cmdAlterar.Visible = True
                cmdExcluir.Visible = True
                cmdNovo.Visible = True
                cmdUsuario.Visible = True
        End Select

        If cnt_SEC_Tela <> "" Then
            SEC_ValidarBotao(cmdAlterar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
            SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
            SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        End If

        Me.Text = sTituloTela
        lblTituloPesquisa.Text = sTituloListagem
        '>>> Formatação do título da tela e título da listagem - Fim
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String = String.Empty

        Select Case iTipoTela
            Case eConsultaGeral.AgregadosFornecedor
                SqlText = "SELECT CD_FORNECEDOR, NO_RAZAO_SOCIAL" & _
                          " FROM SOF.FORNECEDOR" & _
                          " WHERE CD_REPASSADOR = " & FiltroLocal_01 & _
                          " ORDER BY NO_RAZAO_SOCIAL"
            Case eConsultaGeral.Fretista
                SqlText = "SELECT f.cd_fretista ,  f.no_fretista, tf.no_tipo_fretista, "
                SqlText = SqlText & "         DECODE (f.ic_fisica_juridica, "
                SqlText = SqlText & "                 'F', 'Física', "
                SqlText = SqlText & "                 'Jurídica' "
                SqlText = SqlText & "                ) AS tipopessoa, "
                SqlText = SqlText & "         f.nu_cgc_cpf, f.nu_inscricao_inss, f.nu_pis_pasep, "
                SqlText = SqlText & "         f.cd_address_number, f.no_favorecido, f.qt_dependetes "
                SqlText = SqlText & "    FROM sof.fretista f, sof.tipo_fretista tf "
                SqlText = SqlText & "   WHERE f.cd_tipo_fretista = tf.cd_tipo_fretista "
                SqlText = SqlText & "ORDER BY f.no_fretista "
            Case eConsultaGeral.MovimentacaoPosto
                SqlText = "SELECT    fil.no_filial, "
                SqlText = SqlText & "         SUM (cm.qt_kg_a_fixar) qt_kg_a_fixar "
                SqlText = SqlText & "    FROM sof.filial fil, sof.movimentacao m, sof.ctr_paf_movimentacao cm "
                SqlText = SqlText & "   WHERE m.sq_movimentacao = cm.sq_movimentacao "
                SqlText = SqlText & "     AND m.cd_filial_movimentacao = fil.cd_filial "
                SqlText = SqlText & "     AND m.cd_local_entrega =  " & FiltroLocal_01
                SqlText = SqlText & "     AND cm.cd_contrato_paf = " & FiltroLocal_02
                SqlText = SqlText & "     AND cm.qt_kg_a_fixar <> 0 "
                SqlText = SqlText & "GROUP BY  fil.no_filial "
            Case eConsultaGeral.MovimentacaoBancaria_Item
                SqlText = "SELECT DISTINCT   F.NO_RAZAO_SOCIAL," & _
                                           "OB.NO_OPERACAO," & _
                                          "IMB.DS_DESCRICAO," & _
                                          "IMB.VL_PAGO," & _
                                          "IMB.VL_PROVISAO_TOTAL," & _
                                          "IMB.VL_LIQUIDO," & _
                                          "IMB.VL_BRUTO," & _
                                          "IMB.NO_FAVORECIDO," & _
                                          "FIL.NO_FILIAL," & _
                                          "IMB.SQ_ITEM_MOV_BANCARIO" & _
                          " FROM SOF.ITEM_MOV_BANCARIO IMB," & _
                                "SOF.OPERACAO_BANCARIA OB," & _
                                "SOF.FILIAL FIL," & _
                                "SOF.FORNECEDOR F," & _
                                "SOF.PAGAMENTOS P " & _
                          "WHERE IMB.SQ_MOV_BANCARIO = " & FiltroLocal_01 & _
                           " AND IMB.CD_OPERACAO_BANCARIA = OB.CD_OPERACAO_BANCARIA" & _
                           " AND IMB.CD_FILIAL_DEBITADA = FIL.CD_FILIAL" & _
                           " AND IMB.SQ_ITEM_MOV_BANCARIO = P.SQ_ITEM_MOV_BANCARIO (+)" & _
                           " AND P.CD_FORNECEDOR = F.CD_FORNECEDOR (+)"
            Case eConsultaGeral.MovimentacaoBancaria_Provisao
                SqlText = "SELECT P.NO_PROVISAO," & _
                                 "IMBP.VL_PROVISAO" & _
                          " FROM SOF.PROVISAO P," & _
                                "SOF.ITEM_MOV_BANCARIO_PROVISAO IMBP" & _
                          " WHERE IMBP.CD_PROVISAO = P.CD_PROVISAO" & _
                            " AND IMBP.SQ_ITEM_MOV_BANCARIO = " & FiltroLocal_01
            Case eConsultaGeral.Aprovacoes_SolicitacaoCredito
                SqlText = "SELECT   lca.sq_limite_credito_aprovacao, lca.dt_aprovacao, "
                SqlText = SqlText & "         ta.no_tipo_aprovacao, u.no_usuario, lcts.no_tipo_status, lca.ds_obs "
                SqlText = SqlText & "    FROM sof.tipo_aprovacao ta, "
                SqlText = SqlText & "         sof.usuario u, "
                SqlText = SqlText & "         sof.limite_credito_tipo_status lcts, "
                SqlText = SqlText & "         sof.limite_credito_aprovacao lca "
                SqlText = SqlText & "   WHERE lca.cd_user = u.cd_user "
                SqlText = SqlText & "     AND lca.cd_tipo_aprovacao = ta.cd_tipo_aprovacao "
                SqlText = SqlText & "     AND lca.cd_tipo_status = lcts.cd_tipo_status "
                SqlText = SqlText & "     AND lca.sq_limite_credito =  " & FiltroLocal_01
                SqlText = SqlText & "ORDER BY lca.sq_limite_credito_aprovacao ASC "
            Case eConsultaGeral.Filial
                SqlText = "SELECT f.cd_filial, f.no_filial, f.no_razao, f.nu_cgc, f.ds_endereco, "
                SqlText = SqlText & "       m.no_cidade, f.vl_frete_filial_fazenda, f.vl_frete_filial_fabrica, "
                SqlText = SqlText & "       f.vl_frete_fabrica, f.ic_verifica_pagamento_fechamen, f.ic_ativa, "
                SqlText = SqlText & "       f.qt_limite_credito_vencidos, f.vl_limite_credito_vencidos, "
                SqlText = SqlText & "       f.qt_limite_credito_aberto, f.vl_limite_credito_aberto, f.pc_aliq_iss/100, "
                SqlText = SqlText & "       f.ic_armazem, r.no_filial no_filial_responsavel, f.CD_FILIAL_RDS "
                SqlText = SqlText & "  FROM sof.filial f, sof.municipio m, sof.filial r "
                SqlText = SqlText & " WHERE f.cd_municipio = m.cd_municipio AND f.cd_filial_responsavel = r.cd_filial(+) "
            Case eConsultaGeral.Cancelamento_ContratoPAF
                SqlText = "SELECT SQ_CONTRATO_PAF_CANCELADO," & _
                                 "DT_CANCELAMENTO," & _
                                 "QT_CANCELADO," & _
                                 "DS_MOTIVO, " & _
                                 "SQ_CONFISSAO_DIVIDA " & _
                          " FROM SOF.CONTRATO_PAF_CANCELADO " & _
                          " WHERE CD_CONTRATO_PAF = " & FiltroLocal_01 & " " & _
                          " ORDER BY SQ_CONTRATO_PAF_CANCELADO"
            Case eConsultaGeral.Cancelamento_Negociacao
                SqlText = "SELECT SQ_NEGOCIACAO_CANCELADO," & _
                                 "DT_CANCELAMENTO," & _
                                 "QT_CANCELADO," & _
                                 "DS_MOTIVO," & _
                                 "SQ_CONFISSAO_DIVIDA," & _
                                 "IC_ESTORNO_CANCELAMENTO" & _
                          " FROM SOF.NEGOCIACAO_CANCELADO " & _
                          " WHERE CD_CONTRATO_PAF = " & FiltroLocal_01 & _
                            " AND SQ_NEGOCIACAO = " & FiltroLocal_02 & _
                          " ORDER BY SQ_NEGOCIACAO_CANCELADO"
            Case eConsultaGeral.Cancelamento_ContratoFixo
                SqlText = "SELECT SQ_CONTRATO_FIXO_CANCELADO," & _
                                 "DT_CANCELAMENTO," & _
                                 "QT_CANCELADO," & _
                                 "DS_MOTIVO," & _
                                 "SQ_CONFISSAO_DIVIDA" & _
                          " FROM SOF.CONTRATO_FIXO_CANCELADO " & _
                          "WHERE CD_CONTRATO_PAF = " & FiltroLocal_01 & _
                           " AND SQ_NEGOCIACAO = " & FiltroLocal_02 & _
                           " AND SQ_CONTRATO_FIXO = " & FiltroLocal_03
            Case eConsultaGeral.ContratoFixo_Adendo
                SqlText = "SELECT CFA.DT_ADENDO_CONTRATO," & _
                                 "TA.DS_TIPO_ADENDO," & _
                                 "CFA.VL_ADENDO_CONTRATO," & _
                                 "CFA.VL_ICMS_ADENDO," & _
                                 "CFA.VL_INSS_ADENDO," & _
                                 "CFA.CD_CONTRATO_PAF," & _
                                 "CFA.SQ_NEGOCIACAO," & _
                                 "CFA.SQ_CONTRATO_FIXO," & _
                                 "CFA.SQ_CONTRATO_FIXO_ADENDO" & _
                          " FROM SOF.CONTRATO_FIXO_ADENDO CFA," & _
                                "SOF.TIPO_ADENDO TA" & _
                          " WHERE TA.CD_TIPO_ADENDO = CFA.CD_TIPO_ADENDO" & _
                            " AND CFA.CD_CONTRATO_PAF = " & FiltroLocal_01 & _
                            " AND CFA.SQ_NEGOCIACAO = " & FiltroLocal_02 & _
                            " AND CFA.SQ_CONTRATO_FIXO = " & FiltroLocal_03
            Case eConsultaGeral.Aniversariantes
                SqlText = "SELECT f.cd_fornecedor, fil.no_filial, "
                SqlText = SqlText & "       TO_DATE (   TO_CHAR (f.dt_nascimento, 'dd-mon') "
                SqlText = SqlText & "                || '-' "
                SqlText = SqlText & "                || TO_CHAR (SYSDATE, 'yyyy') "
                SqlText = SqlText & "               ) aniversario, f.no_razao_social, f.nu_tel, f.ds_email "
                SqlText = SqlText & "  FROM sof.fornecedor f, sof.filial fil "
                SqlText = SqlText & " WHERE DECODE (f.dt_nascimento, "
                SqlText = SqlText & "               NULL, -1, "
                SqlText = SqlText & "               TO_CHAR (TO_DATE (   DECODE (UPPER (TO_CHAR (f.dt_nascimento, "
                SqlText = SqlText & "                                                            'dd-mon' "
                SqlText = SqlText & "                                                           ) "
                SqlText = SqlText & "                                                  ), "
                SqlText = SqlText & "                                            '29-FEB', '01-MAR', "
                SqlText = SqlText & "                                            TO_CHAR (f.dt_nascimento, "
                SqlText = SqlText & "                                                     'dd-mon') "
                SqlText = SqlText & "                                           ) "
                SqlText = SqlText & "                                 || '-' "
                SqlText = SqlText & "                                 || TO_CHAR (SYSDATE, 'yyyy') "
                SqlText = SqlText & "                                ), "
                SqlText = SqlText & "                        'IW' "
                SqlText = SqlText & "                       ) "
                SqlText = SqlText & "              ) = TO_CHAR (SYSDATE, 'IW') "
                SqlText = SqlText & "   AND f.dt_nascimento IS NOT NULL "
                SqlText = SqlText & "   AND f.ic_ativo = 'S' "
                SqlText = SqlText & "   AND f.cd_filial_origem = fil.cd_filial "
                SqlText = SqlText & "   and f.cd_filial_origem in  (" & ListarIDFiliaisLiberadaUsuario() & " ) "
                SqlText = SqlText & " order by TO_DATE (   TO_CHAR (f.dt_nascimento, 'dd-mon') "
                SqlText = SqlText & "                || '-' "
                SqlText = SqlText & "                || TO_CHAR (SYSDATE, 'yyyy') "
                SqlText = SqlText & "               ) "
            Case eConsultaGeral.Tipo_Rd
                SqlText = "select t.cd_tipo_rd, t.no_tipo_rd, m.no_tipo_movimentacao, decode(t.ic_ativo,'S',1,0) " & _
                            "from sof.tipo_rd t, sof.tipo_movimentacao m " & _
                            "where t.cd_tp_mov_saldo_final = m.cd_tipo_movimentacao (+)"
            Case eConsultaGeral.UtilizacaoSistema
                SqlText = "SELECT   * "
                SqlText = SqlText & "    FROM (SELECT   r.cd_tipo, "
                SqlText = SqlText & "                   DECODE (r.cd_tipo, 1, 'Relatório', 'Consulta') tipo, "
                SqlText = SqlText & "                   r.cd_relatorio, r.no_relatorio, MIN (u.dt_ultimo_acesso), "
                SqlText = SqlText & "                   MAX (u.dt_ultimo_acesso), SUM (u.qt_acesso) "
                SqlText = SqlText & "              FROM sof.relatorio r, sof.relatorio_utilizacao u "
                SqlText = SqlText & "             WHERE r.cd_relatorio = u.cd_relatorio AND r.cd_tipo = u.cd_tipo "
                SqlText = SqlText & "          GROUP BY r.cd_tipo, r.cd_relatorio, r.no_relatorio) "
                SqlText = SqlText & "ORDER BY cd_tipo, cd_relatorio "
            Case eConsultaGeral.GrupoTipoMovimentacao
                SqlText = "SELECT pm.cd_parametro_modalidade, pm.no_parametro_modalidade, pm.nr_ordenacao " & _
                      "FROM SOF.parametro_modalidade pm " & _
                      "where pm.cd_processo=" & FiltroLocal_01 & _
                      " and pm.cd_status=" & FiltroLocal_02 & _
                      " ORDER BY pm.nr_ordenacao "
            Case eConsultaGeral.OperacaoBancariaTipoMovimentacao
                SqlText = "SELECT POTM.CD_PARAMETRO_OPERACAO_TP_MOV, POTM.NO_PARAMETRO_OPERACAO_TP_MOV, " & _
                     "POTM.CD_OPERACAO_BANCARIA, OB.NO_OPERACAO, POTM.CD_TIPO_MOVIMENTACAO, " & _
                     "TM.NO_TIPO_MOVIMENTACAO " & _
                     "FROM SOF.PARAMETRO_OPERACAO_TP_MOV POTM, SOF.OPERACAO_BANCARIA OB, " & _
                     "SOF.TIPO_MOVIMENTACAO TM " & _
                     "WHERE OB.CD_OPERACAO_BANCARIA = POTM.CD_OPERACAO_BANCARIA AND " & _
                     "TM.CD_TIPO_MOVIMENTACAO = POTM.CD_TIPO_MOVIMENTACAO " & _
                     "ORDER BY POTM.CD_PARAMETRO_OPERACAO_TP_MOV"
            Case eConsultaGeral.PremioQualidadeInativo
                SqlText = "SELECT bp.no_bonus_padrao, "
                SqlText = SqlText & "          bcf.cd_contrato_paf "
                SqlText = SqlText & "       || '-' "
                SqlText = SqlText & "       || bcf.sq_negociacao "
                SqlText = SqlText & "       || '-' "
                SqlText = SqlText & "       || bcf.sq_contrato_fixo AS contrato, "
                SqlText = SqlText & "       bcf.vl_unitario_bonus "
                SqlText = SqlText & "  FROM sof.bonus_contrato_fixo bcf, sof.bonus_padrao bp "
                SqlText = SqlText & " WHERE bp.cd_bonus_padrao = bcf.cd_bonus_padrao "
                SqlText = SqlText & "   AND bp.ic_ativo = 'N' "
                SqlText = SqlText & "   AND bcf.ic_pago = 'N' "
            Case eConsultaGeral.TipoPagamento
                SqlText = "SELECT   tp.cd_tipo_pagamento, tp.no_tipo_pagamento, ob.no_operacao, "
                SqlText = SqlText & "         decode(tp.ic_pagamento_icms,'S',1,0),  "
                SqlText = SqlText & "         fp.no_forma_pagamento, decode(tp.ic_calcula_juros,'S',1,0), decode(tp.ic_ativo,'S',1,0) "
                SqlText = SqlText & "    FROM sof.tipo_pagamento tp, "
                SqlText = SqlText & "         sof.operacao_bancaria ob, "
                SqlText = SqlText & "         sof.forma_pagamento fp "
                SqlText = SqlText & "   WHERE tp.cd_operacao_bancaria = ob.cd_operacao_bancaria "
                SqlText = SqlText & "     AND tp.cd_forma_pagamento = fp.cd_forma_pagamento(+) "
                SqlText = SqlText & "ORDER BY tp.cd_tipo_pagamento "
            Case eConsultaGeral.OperaracaoBancaria
                SqlText = "SELECT OB.CD_OPERACAO_BANCARIA, OB.NO_OPERACAO, " & _
                             "OB.VL_MAXIMO_PAGAMENTO, OB.CD_CENTRO_DE_CUSTO, " & _
                             "OB.CD_CONTA_CONTABIL, decode(OB.IC_DEBITO_CREDITO,'C','Crédito','Débito'), decode(OB.IC_EMITE_CHEQUE,'S',1,0) , " & _
                             " decode(OB.IC_LANCA_RD,'S',1,0), TM.NO_TIPO_MOVIMENTACAO, " & _
                             "OB.VL_ALIQ_CHEIA_ACRESCENTAR, OB.NO_ALIQ_CHEIA_ACRESCENTAR, " & _
                             "OB.VL_SUB_ALIQ_1, OB.NO_SUB_ALIQ_1, OB.VL_SUB_ALIQ_2, " & _
                             "OB.NO_SUB_ALIQ_2, F.NO_FILIAL, decode(OB.IC_ATIVO,'S',1,0) " & _
                             "FROM SOF.OPERACAO_BANCARIA OB,SOF.TIPO_MOVIMENTACAO TM, SOF.FILIAL F " & _
                             "WHERE OB.CD_FILIAL_DEBITADA_DEFAULT = F.CD_FILIAL (+) AND " & _
                             "OB.CD_TIPO_MOVIMENTACAO = TM.CD_TIPO_MOVIMENTACAO (+)"
                SqlText = SqlText & " order by OB.CD_OPERACAO_BANCARIA"
            Case eConsultaGeral.ItensBranch
                SqlText = "SELECT   cd_branche_item, no_branche_item "
                SqlText = SqlText & "    FROM sof.branche_item "
                SqlText = SqlText & "ORDER BY cd_branche_item "
            Case eConsultaGeral.TipoFretistaTributacao
                SqlText = "SELECT   tft.cd_tipo_fretista_tributacao, tft.no_tipo_fretista_tributacao, "
                SqlText = SqlText & "         tft.pc_base_calculo, tft.vl_deducao_dependente, "
                SqlText = SqlText & "         tft.vl_teto_tributacao, p.no_provisao, "
                SqlText = SqlText & "         NVL (tftd.no_tipo_fretista_tributacao, "
                SqlText = SqlText & "              'Sem dedução via tributo' "
                SqlText = SqlText & "             ) no_tributo_deducao, "
                SqlText = SqlText & "         tft.nu_sequencia, tft.vl_minimo_tributacao, decode(tft.ic_iss,'S',1,0) "
                SqlText = SqlText & "    FROM sof.tipo_fretista_tributacao tft, "
                SqlText = SqlText & "         sof.provisao p, "
                SqlText = SqlText & "         sof.tipo_fretista_tributacao tftd "
                SqlText = SqlText & "   WHERE tft.cd_provisao = p.cd_provisao AND tft.cd_tributo_deducao = tftd.cd_tipo_fretista_tributacao(+) "
                SqlText = SqlText & "ORDER BY tft.nu_sequencia "
            Case eConsultaGeral.ModalidadeConciliacao
                SqlText = "SELECT   a.cd_conciliacao_modalidade, a.no_conciliacao_modalidade, "
                SqlText = SqlText & "         a.nu_cc_pagamento_credito, a.nu_cc_pagamento_debito, "
                SqlText = SqlText & "         a.nu_cc_movimentacao_credito, a.nu_cc_movimentacao_debito, "
                SqlText = SqlText & "         DECODE (a.ic_lanca_rd, 'S', 1, 0), "
                SqlText = SqlText & "         DECODE (a.ic_filial_conciliacao,'S', 'Conciliação', decode(a.ic_filial_fixa,'S','Fixa', 'Movimentação')), "
                SqlText = SqlText & "         f.no_filial, "
                SqlText = SqlText & "         tm.no_tipo_movimentacao, DECODE (a.ic_ativo, 'S', 1, 0) "
                SqlText = SqlText & "    FROM sof.conciliacao_modalidade a, sof.filial f, sof.tipo_movimentacao tm "
                SqlText = SqlText & "   WHERE a.cd_filial_fixa = f.cd_filial(+) AND a.cd_tipo_movimentacao = tm.cd_tipo_movimentacao(+) "
                SqlText = SqlText & "ORDER BY a.cd_conciliacao_modalidade "
            Case eConsultaGeral.TipoMovimentacao
                SqlText = "SELECT   m.cd_tipo_movimentacao, m.no_tipo_movimentacao, t.no_tipo_rd, "
                SqlText = SqlText & "         DECODE (m.ic_entrada_saida, 'E', 'Entrada', 'Saida'), "
                SqlText = SqlText & "         m.nu_conta_contabil, DECODE (m.ic_muda_conta_contabil, 'S', 1, 0), "
                SqlText = SqlText & "         m.nu_conta_contabil_cp, "
                SqlText = SqlText & "         DECODE (m.ic_muda_conta_contabil_cp, 'S', 1, 0), m.cd_sub_ledger, "
                SqlText = SqlText & "         m.cd_tipo_sub_ledger, m.cd_sub_ledger_cp, m.cd_tipo_sub_ledger_cp, "
                SqlText = SqlText & "         DECODE (m.ic_valida_kg, 'S', 1, 0), "
                SqlText = SqlText & "         DECODE (m.ic_valida_qualidade, 'S', 1, 0), "
                SqlText = SqlText & "         DECODE (m.ic_valida_valor, 'S', 1, 0), "
                SqlText = SqlText & "         DECODE (m.ic_importacao, 'S', 1, 0), DECODE (m.ic_fiscal, 'S', 1, 0), "
                SqlText = SqlText & "         l.no_local_entrega, DECODE (m.ic_ativo, 'S', 1, 0) "
                SqlText = SqlText & "    FROM sof.tipo_rd t, sof.local_entrega l, sof.tipo_movimentacao m "
                SqlText = SqlText & "   WHERE t.cd_tipo_rd(+) = m.cd_tipo_rd AND l.cd_local_entrega(+) = "
                SqlText = SqlText & "                                                            m.cd_local_entrega "
                SqlText = SqlText & "ORDER BY m.cd_tipo_movimentacao "
            Case eConsultaGeral.BonusPadrao
                SqlText = "SELECT   bp.cd_bonus_padrao, bp.no_bonus_padrao, decode(bp.ic_ativo,'S',1,0) "
                SqlText = SqlText & "    FROM sof.bonus_padrao bp "
                SqlText = SqlText & "ORDER BY bp.cd_bonus_padrao "
            Case eConsultaGeral.Armazem
                SqlText = "SELECT CD_ARMAZEM, NO_ARMAZEM, DECODE(IC_ATIVO, 'S', 1, 0)" & _
                          " FROM SOF.ARMAZEM" & _
                          " ORDER BY NO_ARMAZEM"
        End Select

        objGrid_Carregar(grdGeral, SqlText)
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmConsultaGeral_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        CarregarDados()
    End Sub

    Private Sub frmConsultaGeral_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            CarregarDados()
        End If
    End Sub

    Private Sub frmConsultaGeral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AlinharBotoes()
    End Sub

    Private Sub frmCosultaGeral_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 59
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 8
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 8
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 59
        'Posição vertical
        cmdAlterar.Top = Me.ClientSize.Height - cmdAlterar.Height - 3
        cmdEspecial_01.Top = Me.ClientSize.Height - cmdAlterar.Height - 3
        cmdEspecial_02.Top = Me.ClientSize.Height - cmdAlterar.Height - 3
        cmdNovo.Top = Me.ClientSize.Height - cmdAlterar.Height - 3
        cmdExcluir.Top = Me.ClientSize.Height - cmdAlterar.Height - 3
        cmdExcell.Top = Me.ClientSize.Height - cmdAlterar.Height - 3
        cmdFechar.Top = Me.ClientSize.Height - cmdAlterar.Height - 3
        cmdAtualizar.Top = Me.ClientSize.Height - cmdAlterar.Height - 3
        cmdUsuario.Top = Me.ClientSize.Height - cmdAlterar.Height - 3
    End Sub

    Private Sub AlinharBotoes()
        Const cnt_Tamanho As Integer = 45
        Const cnt_Espacamento As Integer = 8
        Const cnt_1Posicao As Integer = 5

        Dim iCont As Integer = 0

        If cmdExcell.Visible Then cmdExcell.Left = cnt_1Posicao + ((iCont) * (cnt_Tamanho + cnt_Espacamento))
        If cmdAtualizar.Visible Then iCont = iCont + 1 : cmdAtualizar.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdNovo.Visible Then iCont = iCont + 1 : cmdNovo.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdAlterar.Visible Then iCont = iCont + 1 : cmdAlterar.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdExcluir.Visible Then iCont = iCont + 1 : cmdExcluir.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdEspecial_01.Visible Then iCont = iCont + 1 : cmdEspecial_01.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
        If cmdEspecial_02.Visible Then iCont = iCont + 1 : cmdEspecial_02.Left = cnt_1Posicao + (iCont * (cnt_Tamanho + cnt_Espacamento))
    End Sub

    Private Sub cmdEspecial_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEspecial_01.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Select Case iTipoTela
            Case eConsultaGeral.MovimentacaoBancaria_Item
                Filtro = objGrid_Valor(grdGeral, cnt_GridItemMovBanco_SQ_ITEM_MOV_BANCARIO)
                Form_Carregar_Consulta_Geral(Me.MdiParent, eConsultaGeral.MovimentacaoBancaria_Provisao)
            Case eConsultaGeral.UtilizacaoSistema
                Dim oForm As New frmRelatorioGeral

                oForm.Filtro01 = objGrid_Valor(grdGeral, cnt_GridUtilizacaoSistema_Codigo)
                oForm.Filtro02 = objGrid_Valor(grdGeral, cnt_GridUtilizacaoSistema_CodigoTipo)
                oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eUtilizacaoSistema
                oForm.Show()
        End Select
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        ControleEdicaoTela = Declaracao.eControleEdicaoTela.INCLUIR

        Select Case iTipoTela
            Case eConsultaGeral.Fretista
                oForm_Fretista = New frmCadastroFretista
                Form_Show(Me.MdiParent, oForm_Fretista)
            Case eConsultaGeral.Filial
                oForm_Filial = New frmCadastroFilial
                Form_Show(Me.MdiParent, oForm_Filial)
            Case eConsultaGeral.Tipo_Rd
                oForm_TipoRd = New frmCadastroTipoRD
                Form_Show(Me.MdiParent, oForm_TipoRd)
            Case eConsultaGeral.GrupoTipoMovimentacao
                oForm_grpTipoMovimentacao = New frmCadastroGrupoTipoMovimentacao
                oForm_grpTipoMovimentacao.Cd_Processo = FiltroLocal_01
                oForm_grpTipoMovimentacao.Cd_Status = FiltroLocal_02
                Form_Show(Me.MdiParent, oForm_grpTipoMovimentacao)
            Case eConsultaGeral.OperacaoBancariaTipoMovimentacao
                oForm_OperTpMov = New frmCadastroOperBancariaTpMovimentacao
                Form_Show(Me.MdiParent, oForm_OperTpMov)
            Case eConsultaGeral.TipoPagamento
                oForm_TipoPagamento = New frmCadastroTipoPagamento
                Form_Show(Me.MdiParent, oForm_TipoPagamento)
            Case eConsultaGeral.OperaracaoBancaria
                oForm_OperacaoBancaria = New frmCadastroOperacaoBancaria
                Form_Show(Me.MdiParent, oForm_OperacaoBancaria)
            Case eConsultaGeral.ItensBranch
                oForm_ItemBranch = New frmCadastroItensBranch
                Form_Show(Me.MdiParent, oForm_ItemBranch)
            Case eConsultaGeral.TipoFretistaTributacao
                oForm_TipoFretistaTributacao = New frmCadastroTipoFretistaTributacao
                Form_Show(Me.MdiParent, oForm_TipoFretistaTributacao)
            Case eConsultaGeral.ModalidadeConciliacao
                oForm_ModalidadeConciliacao = New frmCadastroModalidadeConciliacao
                Form_Show(Me.MdiParent, oForm_ModalidadeConciliacao)
            Case eConsultaGeral.TipoMovimentacao
                oForm_TipoMovimentacao = New frmCadastroTipoMovimentacao
                Form_Show(Me.MdiParent, oForm_TipoMovimentacao)
            Case eConsultaGeral.BonusPadrao
                oForm_BonusPadrao = New frmCadastroBonusPadrao
                Form_Show(Me.MdiParent, oForm_BonusPadrao)
            Case eConsultaGeral.Armazem
                oForm_Armazem = New frmCadastroArmazem
                Form_Show(Me.MdiParent, oForm_Armazem)
        End Select
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        ControleEdicaoTela = Declaracao.eControleEdicaoTela.ALTERAR

        Select Case iTipoTela
            Case eConsultaGeral.Fretista
                Filtro = objGrid_Valor(grdGeral, cnt_GridFretista_Codigo)
                oForm_Fretista = New frmCadastroFretista
                Form_Show(Me.MdiParent, oForm_Fretista)
            Case eConsultaGeral.Filial
                Filtro = objGrid_Valor(grdGeral, cnt_GridFilial_Codigo)
                oForm_Filial = New frmCadastroFilial
                Form_Show(Me.MdiParent, oForm_Filial)
            Case eConsultaGeral.Tipo_Rd
                Filtro = objGrid_Valor(grdGeral, cnt_GridTipoRD_Codigo)
                oForm_TipoRd = New frmCadastroTipoRD
                Form_Show(Me.MdiParent, oForm_TipoRd)
            Case eConsultaGeral.UtilizacaoSistema
                Filtro = objGrid_Valor(grdGeral, cnt_GridUtilizacaoSistema_Codigo)
                Filtro1 = objGrid_Valor(grdGeral, cnt_GridUtilizacaoSistema_CodigoTipo)
                oForm_UtilizacaoSistema = New frmCadastroUtilizacaoSistema
                Form_Show(Me.MdiParent, oForm_UtilizacaoSistema)
            Case eConsultaGeral.GrupoTipoMovimentacao
                Filtro = objGrid_Valor(grdGeral, cnt_GridGrupoTipoProduto_Codigo)
                oForm_grpTipoMovimentacao = New frmCadastroGrupoTipoMovimentacao
                oForm_grpTipoMovimentacao.Cd_Processo = FiltroLocal_01
                oForm_grpTipoMovimentacao.Cd_Status = FiltroLocal_02
                Form_Show(Me.MdiParent, oForm_grpTipoMovimentacao)
            Case eConsultaGeral.OperacaoBancariaTipoMovimentacao
                Filtro = objGrid_Valor(grdGeral, cnt_GridOperBancariaTpMovimentacao_Codigo)
                oForm_OperTpMov = New frmCadastroOperBancariaTpMovimentacao
                Form_Show(Me.MdiParent, oForm_OperTpMov)
            Case eConsultaGeral.TipoPagamento
                Filtro = objGrid_Valor(grdGeral, cnt_GridTipoPagamento_Codigo)
                oForm_TipoPagamento = New frmCadastroTipoPagamento
                Form_Show(Me.MdiParent, oForm_TipoPagamento)
            Case eConsultaGeral.OperaracaoBancaria
                Filtro = objGrid_Valor(grdGeral, cnt_GridOperacaoBancaria_Codigo)
                oForm_OperacaoBancaria = New frmCadastroOperacaoBancaria
                Form_Show(Me.MdiParent, oForm_OperacaoBancaria)
            Case eConsultaGeral.ItensBranch
                Filtro = objGrid_Valor(grdGeral, cnt_GridItensBranch_Codigo)
                oForm_ItemBranch = New frmCadastroItensBranch
                Form_Show(Me.MdiParent, oForm_ItemBranch)
            Case eConsultaGeral.TipoFretistaTributacao
                Filtro = objGrid_Valor(grdGeral, cnt_GridTipoFretistaTributacao_Codigo)
                oForm_TipoFretistaTributacao = New frmCadastroTipoFretistaTributacao
                Form_Show(Me.MdiParent, oForm_TipoFretistaTributacao)
            Case eConsultaGeral.ModalidadeConciliacao
                Filtro = objGrid_Valor(grdGeral, cnt_GridModalidadeConciliacao_Codigo)
                oForm_ModalidadeConciliacao = New frmCadastroModalidadeConciliacao
                Form_Show(Me.MdiParent, oForm_ModalidadeConciliacao)
            Case eConsultaGeral.TipoMovimentacao
                Filtro = objGrid_Valor(grdGeral, cnt_GridTipoMovimentacao_Codigo)
                oForm_TipoMovimentacao = New frmCadastroTipoMovimentacao
                Form_Show(Me.MdiParent, oForm_TipoMovimentacao)
            Case eConsultaGeral.BonusPadrao
                Filtro = objGrid_Valor(grdGeral, cnt_GridBonusPadrao_Codigo)
                oForm_BonusPadrao = New frmCadastroBonusPadrao
                Form_Show(Me.MdiParent, oForm_BonusPadrao)
            Case eConsultaGeral.Armazem
                Filtro = objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo)
                oForm_Armazem = New frmCadastroArmazem
                Form_Show(Me.MdiParent, oForm_Armazem)
        End Select
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim sMens As String
        Dim SqlText As String

        If grdGeral.DisplayLayout.ActiveRow Is Nothing Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        sMens = "Deseja excluir"

        On Error GoTo Erro

        Select Case iTipoTela
            Case eConsultaGeral.Fretista
                sMens = sMens & " o fretista " & objGrid_Valor(grdGeral, cnt_GridFretista_Nome) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not ValidacaoExclusao("FRETE", "CD_FRETISTA = " & objGrid_Valor(grdGeral, cnt_GridFretista_Codigo), _
                                             "Existem Frete cadastrado para esse Fretista") Then Exit Sub

                    If Not DBExecutar_Delete("SOF.FRETISTA", "CD_FRETISTA", objGrid_Valor(grdGeral, cnt_GridFretista_Codigo)) Then GoTo Erro
                End If
            Case eConsultaGeral.Filial
                sMens = sMens & " a filial " & objGrid_Valor(grdGeral, cnt_GridFilial_Nome) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not DBExecutar_Delete("SOF.FILIAL", "CD_FILIAL", objGrid_Valor(grdGeral, cnt_GridGrupoTipoProduto_Codigo)) Then GoTo Erro
                End If
            Case eConsultaGeral.GrupoTipoMovimentacao
                sMens = sMens & " o grupo tipo movimentação " & objGrid_Valor(grdGeral, cnt_GridFilial_Nome) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not DBExecutar_Delete("SOF.PARAMETRO_MODALIDADE_TIPO_MOV", "CD_PARAMETRO_MODALIDADE", objGrid_Valor(grdGeral, cnt_GridGrupoTipoProduto_Codigo)) Then GoTo Erro
                    If Not DBExecutar_Delete("SOF.PARAMETRO_MODALIDADE", "CD_PARAMETRO_MODALIDADE", objGrid_Valor(grdGeral, cnt_GridGrupoTipoProduto_Codigo)) Then GoTo Erro
                End If
            Case eConsultaGeral.ContratoFixo_Adendo
                sMens = sMens & " realmente esse Adendo?"

                If Msg_Perguntar(sMens) Then
                    If Not DBExecutar_Delete("SOF.CONTRATO_FIXO_ADENDO", _
                                               "CD_CONTRATO_PAF", objGrid_Valor(grdGeral, cnt_GridCtrFixAdendo_ContratoPAF), "AND", _
                                               "SQ_NEGOCIACAO", objGrid_Valor(grdGeral, cnt_GridCtrFixAdendo_Negociacao), "AND", _
                                               "SQ_CONTRATO_FIXO", objGrid_Valor(grdGeral, cnt_GridCtrFixAdendo_ContratoFixo), "AND", _
                                               "SQ_CONTRATO_FIXO_ADENDO", objGrid_Valor(grdGeral, cnt_GridCtrFixAdendo_Seq)) Then GoTo Erro
                End If
            Case eConsultaGeral.Cancelamento_ContratoFixo, _
                 eConsultaGeral.Cancelamento_ContratoPAF, _
                 eConsultaGeral.Cancelamento_Negociacao
                If objGrid_LinhaSelecionada(grdGeral) = -1 Then
                    Msg_Mensagem("Favor selecionar uma linha.")
                    Exit Sub
                End If
                If objGrid_Valor(grdGeral, cnt_GridCancelamento_Quantidade) < 0 Then
                    Msg_Mensagem("Voce não pode cancelar um estorno.")
                    Exit Sub
                End If
                If Not objDataTable_CampoVazio(objGrid_Valor(grdGeral, cnt_GridCancelamento_SQ_CONFISSAO_DIVIDA)) Then
                    Msg_Mensagem("Esse cancelamento pertence a uma recuperação de credito.")
                    Exit Sub
                End If

                Dim oForm As New frmCancelamento_SolicitarQuantidade

                oForm.txtQuantidade.Value = 0 - CDbl(objGrid_Valor(grdGeral, cnt_GridCancelamento_Quantidade))
                oForm.txtQuantidade.ReadOnly = True

                Form_Show(Nothing, oForm, True, True)

                If Not oForm.Cancelado Then
                    Select Case iTipoTela
                        Case eConsultaGeral.Cancelamento_ContratoPAF
                            Cancela_Contrato_PAF(FiltroLocal_01, oForm.txtQuantidade.Value, Trim(oForm.txtMotivo.Text))
                        Case eConsultaGeral.Cancelamento_Negociacao
                            Cancela_Negociacao(FiltroLocal_01, FiltroLocal_02, oForm.txtQuantidade.Value, _
                                                                               Trim(oForm.txtMotivo.Text), _
                                                                               objGrid_Valor(grdGeral, cnt_GridCancelamento_IC_ESTORNO_CANCELAMENTO))
                        Case eConsultaGeral.Cancelamento_ContratoFixo
                            Cancela_Contrato_Fixo(FiltroLocal_01, FiltroLocal_02, FiltroLocal_03, oForm.txtQuantidade.Value, _
                                                                                                  Trim(oForm.txtMotivo.Text))
                    End Select

                    CarregarDados()
                End If

                oForm.Dispose()

                GerouAlteracaoInformacao = True

                Exit Sub
            Case eConsultaGeral.Tipo_Rd
                sMens = sMens & " o Tipo de RD " & objGrid_Valor(grdGeral, cnt_GridTipoRD_Descricao) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not DBExecutar_Delete("SOF.TIPO_RD", "CD_TIPO_RD", objGrid_Valor(grdGeral, cnt_GridTipoRD_Codigo)) Then GoTo Erro
                End If
            Case eConsultaGeral.OperacaoBancariaTipoMovimentacao
                sMens = sMens & " a Operação Bancaria X Tipo Movimentação " & objGrid_Valor(grdGeral, cnt_GridTipoRD_Descricao) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not DBExecutar_Delete("SOF.PARAMETRO_OPERACAO_TP_MOV", "CD_PARAMETRO_OPERACAO_TP_MOV", objGrid_Valor(grdGeral, cnt_GridOperBancariaTpMovimentacao_Codigo)) Then GoTo Erro
                End If
            Case eConsultaGeral.PremioQualidadeInativo
                sMens = sMens & " os " & grdGeral.Rows.Count & " bonus provisionados de padrão inativo " & objGrid_Valor(grdGeral, cnt_GridTipoRD_Descricao) & "?"

                SqlText = "UPDATE SOF.BONUS_CONTRATO_FIXO "
                SqlText = SqlText & "SET ic_pago= 'C' "
                SqlText = SqlText & "WHERE (sq_movimentacao, sq_movimentacao_cessao_direito, "
                SqlText = SqlText & "       cd_contrato_paf, sq_ctr_paf_movimentacao, "
                SqlText = SqlText & "       sq_negociacao, sq_ctr_paf_neg_movimentacao, "
                SqlText = SqlText & "       sq_contrato_fixo, sq_ctr_paf_neg_ctr_fix_mov, cd_bonus_padrao) IN "
                SqlText = SqlText & "      (SELECT BCF.sq_movimentacao, BCF.sq_movimentacao_cessao_direito, "
                SqlText = SqlText & "              BCF.cd_contrato_paf, BCF.sq_ctr_paf_movimentacao, "
                SqlText = SqlText & "              BCF.sq_negociacao, BCF.sq_ctr_paf_neg_movimentacao, "
                SqlText = SqlText & "              BCF.sq_contrato_fixo, BCF.sq_ctr_paf_neg_ctr_fix_mov, "
                SqlText = SqlText & "              BCF.cd_bonus_padrao "
                SqlText = SqlText & "       FROM SOF.bonus_contrato_fixo bcf, SOF.bonus_padrao bp "
                SqlText = SqlText & "       WHERE bp.cd_bonus_padrao = bcf.cd_bonus_padrao AND "
                SqlText = SqlText & "             bp.ic_ativo = 'N' AND "
                SqlText = SqlText & "             BCF.ic_pago = 'N') "

                If Msg_Perguntar(sMens) Then
                    If Not DBExecutar(SqlText) Then GoTo Erro
                End If
            Case eConsultaGeral.TipoPagamento
                sMens = sMens & " o tipo de pagamento " & objGrid_Valor(grdGeral, cnt_GridTipoPagamento_Nome) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not ValidacaoExclusao("PAGAMENTOS", "CD_TIPO_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridTipoPagamento_Codigo), _
                                             "Existem Frete cadastrado para esse Fretista") Then Exit Sub

                    If Not DBExecutar_Delete("SOF.TIPO_PAGAMENTO", "CD_TIPO_PAGAMENTO", objGrid_Valor(grdGeral, cnt_GridTipoPagamento_Codigo)) Then GoTo Erro
                End If
            Case eConsultaGeral.OperaracaoBancaria
                sMens = sMens & " a operação bancaria " & objGrid_Valor(grdGeral, cnt_GridOperacaoBancaria_Nome) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not ValidacaoExclusao("ITEM_MOV_BANCARIO", "CD_OPERACAO_BANCARIA = " & objGrid_Valor(grdGeral, cnt_GridOperacaoBancaria_Codigo), _
                                             "Existem movimentações bancarias feitas com essa operação.") Then Exit Sub

                    If Not DBExecutar_Delete("SOF.OPERACAO_BANCARIA", "CD_OPERACAO_BANCARIA", objGrid_Valor(grdGeral, cnt_GridOperacaoBancaria_Codigo)) Then GoTo Erro
                End If
            Case eConsultaGeral.ItensBranch
                sMens = sMens & " o item de branch  " & objGrid_Valor(grdGeral, cnt_GridItensBranch_Nome) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not DBExecutar_Delete("SOF.BRANCHE_ITEM_TIPO_MOVIMENTACAO", "CD_BRANCHE_ITEM", objGrid_Valor(grdGeral, cnt_GridItensBranch_Codigo)) Then GoTo Erro
                    If Not DBExecutar_Delete("SOF.BRANCHE_ITEM", "CD_BRANCHE_ITEM", objGrid_Valor(grdGeral, cnt_GridItensBranch_Codigo)) Then GoTo Erro
                End If
            Case eConsultaGeral.TipoFretistaTributacao
                sMens = sMens & " o tipo fretista tributação  " & objGrid_Valor(grdGeral, cnt_GridTipoFretistaTributacao_Nome) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not DBExecutar_Delete("SOF.TIPO_FRETISTA_TRIBUTACAO_TBL", "CD_TIPO_FRETISTA_TRIBUTACAO", objGrid_Valor(grdGeral, cnt_GridTipoFretistaTributacao_Codigo)) Then GoTo Erro
                    If Not DBExecutar_Delete("SOF.TIPO_FRETISTA_TRIBUTOS", "CD_TIPO_FRETISTA_TRIBUTACAO", objGrid_Valor(grdGeral, cnt_GridTipoFretistaTributacao_Codigo)) Then GoTo Erro
                    If Not DBExecutar_Delete("SOF.TIPO_FRETISTA_TRIBUTACAO", "CD_TIPO_FRETISTA_TRIBUTACAO", objGrid_Valor(grdGeral, cnt_GridTipoFretistaTributacao_Codigo)) Then GoTo Erro
                End If
            Case eConsultaGeral.ModalidadeConciliacao
                sMens = sMens & " a modalidade de conciliação  " & objGrid_Valor(grdGeral, cnt_GridModalidadeConciliacao_Nome) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not DBExecutar_Delete("SOF.conciliacao_modalidade", "cd_conciliacao_modalidade", objGrid_Valor(grdGeral, cnt_GridModalidadeConciliacao_Codigo)) Then GoTo Erro
                End If
            Case eConsultaGeral.TipoMovimentacao
                sMens = sMens & " o tipo movimentação  " & objGrid_Valor(grdGeral, cnt_GridTipoMovimentacao_Descricao) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not DBExecutar_Delete("SOF.tipo_movimentacao", "cd_tipo_movimentacao", objGrid_Valor(grdGeral, cnt_GridTipoMovimentacao_Codigo)) Then GoTo Erro
                End If
            Case eConsultaGeral.BonusPadrao
                sMens = sMens & " o bônus padrão " & objGrid_Valor(grdGeral, cnt_GridBonusPadrao_Nome) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not DBExecutar_Delete("SOF.bonus_padrao_uf", "cd_bonus_padrao", objGrid_Valor(grdGeral, cnt_GridBonusPadrao_Codigo)) Then GoTo Erro
                    If Not DBExecutar_Delete("SOF.bonus_padrao", "cd_bonus_padrao", objGrid_Valor(grdGeral, cnt_GridBonusPadrao_Codigo)) Then GoTo Erro
                End If
            Case eConsultaGeral.Armazem
                sMens = sMens & " o armazém " & objGrid_Valor(grdGeral, cnt_GridArmazem_Nome) & "?"

                If Msg_Perguntar(sMens) Then
                    If Not ValidacaoExclusao("SOF.CLASSIFICACAO", "CD_ARMAZEM = " & objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo), "Existem Classificações de Análise relacionadas a esse Armazém") Then GoTo Erro
                    If Not ValidacaoExclusao("SOF.FICHA_CIRCULACAO", "CD_ARMAZEM = " & objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo), "Existem Fichas de Circulação relacionadas a esse Armazém") Then GoTo Erro
                    If Not ValidacaoExclusao("SOF.FUMIGACAO_ARMAZEM", "CD_ARMAZEM = " & objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo), "Existem Lançamentos de Furmigação relacionados a esse Armazém") Then GoTo Erro
                    If Not ValidacaoExclusao("SOF.MOVIMENTACAO_DIVERSAS", "CD_ARMAZEM = " & objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo), "Existem Movimentações de Entradas/Saídas Diversas relacionadas a esse Armazém") Then GoTo Erro
                    If Not ValidacaoExclusao("SOF.NOTA_SERVICO", "CD_ARMAZEM = " & objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo), "Existem Notas de Sindicatos relacionadas a esse Armazém") Then GoTo Erro
                    If Not ValidacaoExclusao("SOF.ORDEM_DESCARGA", "CD_ARMAZEM_DESCARGA = " & objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo), "Existem Ordem de Descargas relacionadas a esse Armazém") Then GoTo Erro
                    If Not ValidacaoExclusao("SOF.ORDEM_DESCARGA", "CD_ARMAZEM_CARREGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo), "Existem Ordem de Descargas relacionadas a esse Armazém") Then GoTo Erro
                    If Not ValidacaoExclusao("SOF.PILHA_ARMAZEM", "CD_ARMAZEM = " & objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo), "Existem Pilhas cadastradas para esse Armazém") Then GoTo Erro
                    If Not ValidacaoExclusao("SOF.RECEPCAO_ARMAZEM", "CD_ARMAZEM = " & objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo), "Existem Recepções de Amêndoas relacionadas a esse Armazém") Then GoTo Erro
                    If Not ValidacaoExclusao("SOF.TRANSFERENCIA_SUMMUS", "CD_TRANSBORDO_ARMAZEM = " & objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo), "Existem Transferências relacionadas a esse Armazém") Then GoTo Erro

                    If Not DBExecutar_Delete("SOF.TRANSF_MODALIDADE_ARMAZEM", "CD_ARMAZEM", objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo)) Then GoTo Erro
                    If Not DBExecutar_Delete("SOF.ARMAZEM_CONFIGURACAO", "CD_ARMAZEM", objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo)) Then GoTo Erro
                    If Not DBExecutar_Delete("SOF.ARMAZEM", "CD_ARMAZEM", objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo)) Then GoTo Erro
                End If
        End Select

        CarregarDados()

        GerouAlteracaoInformacao = True

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If grdGeral.DisplayLayout.ActiveRow Is Nothing Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Select Case iTipoTela
            Case eConsultaGeral.Fretista
                Auditoria(TipoCampoFixo.Todos, "FRETISTA", "CD_FRETISTA=" & objGrid_Valor(grdGeral, cnt_GridFretista_Codigo))
            Case eConsultaGeral.Filial
                Auditoria(TipoCampoFixo.Todos, "FILIAL", "CD_FILIAL=" & objGrid_Valor(grdGeral, cnt_GridFilial_Codigo))
            Case eConsultaGeral.Tipo_Rd
                Auditoria(TipoCampoFixo.Todos, "TIPO_RD", "CD_TIPO_RD=" & objGrid_Valor(grdGeral, cnt_GridTipoRD_Codigo))
            Case eConsultaGeral.UtilizacaoSistema
                Auditoria(TipoCampoFixo.Todos, "RELATORIO", "CD_RELATORIO=" & objGrid_Valor(grdGeral, cnt_GridUtilizacaoSistema_Codigo) & " AND " & _
                                              "CD_TIPO=" & objGrid_Valor(grdGeral, cnt_GridUtilizacaoSistema_CodigoTipo))
            Case eConsultaGeral.GrupoTipoMovimentacao
                Auditoria(TipoCampoFixo.Todos, "PARAMETRO_MODALIDADE", "CD_PARAMETRO_MODALIDADE=" & objGrid_Valor(grdGeral, cnt_GridGrupoTipoProduto_Codigo))
            Case eConsultaGeral.OperacaoBancariaTipoMovimentacao
                Auditoria(TipoCampoFixo.Todos, "PARAMETRO_OPERACAO_TP_MOV", "CD_PARAMETRO_OPERACAO_TP_MOV=" & objGrid_Valor(grdGeral, cnt_GridOperBancariaTpMovimentacao_Codigo))
            Case eConsultaGeral.TipoPagamento
                Auditoria(TipoCampoFixo.Todos, "TIPO_PAGAMENTO", "CD_TIPO_PAGAMENTO=" & objGrid_Valor(grdGeral, cnt_GridTipoPagamento_Codigo))
            Case eConsultaGeral.OperaracaoBancaria
                Auditoria(TipoCampoFixo.Todos, "OPERACAO_BANCARIA", "CD_OPERACAO_BANCARIA=" & objGrid_Valor(grdGeral, cnt_GridOperacaoBancaria_Codigo))
            Case eConsultaGeral.ItensBranch
                Auditoria(TipoCampoFixo.Todos, "BRANCHE_ITEM", "CD_BRANCHE_ITEM=" & objGrid_Valor(grdGeral, cnt_GridItensBranch_Codigo))
            Case eConsultaGeral.TipoFretistaTributacao
                Auditoria(TipoCampoFixo.Todos, "TIPO_FRETISTA_TRIBUTACAO", "CD_TIPO_FRETISTA_TRIBUTACAO=" & objGrid_Valor(grdGeral, cnt_GridTipoFretistaTributacao_Codigo))
            Case eConsultaGeral.ModalidadeConciliacao
                Auditoria(TipoCampoFixo.Todos, "conciliacao_modalidade", "cd_conciliacao_modalidade=" & objGrid_Valor(grdGeral, cnt_GridModalidadeConciliacao_Codigo))
            Case eConsultaGeral.TipoMovimentacao
                Auditoria(TipoCampoFixo.Todos, "tipo_movimentacao", "cd_tipo_movimentacao=" & objGrid_Valor(grdGeral, cnt_GridTipoMovimentacao_Codigo))
            Case eConsultaGeral.BonusPadrao
                Auditoria(TipoCampoFixo.Todos, "bonus_padrao", "cd_bonus_padrao=" & objGrid_Valor(grdGeral, cnt_GridBonusPadrao_Codigo))
            Case eConsultaGeral.Armazem
                Auditoria(TipoCampoFixo.Todos, "armazem", "cd_armazem=" & objGrid_Valor(grdGeral, cnt_GridArmazem_Codigo))
        End Select
    End Sub

    Private Sub oForm_Fretista_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_Fretista.FormClosing
        CarregarDados()
    End Sub

    Private Sub oForm_Filial_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_Filial.FormClosing
        CarregarDados()
    End Sub

    Private Sub oForm_TipoRd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_TipoRd.FormClosing
        CarregarDados()
    End Sub

    Private Sub oForm_UtilizacaoRelatorio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_UtilizacaoSistema.FormClosing
        CarregarDados()
    End Sub

    Private Sub oForm_grpTipoMovimentacao_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_grpTipoMovimentacao.FormClosing
        CarregarDados()
    End Sub

    Private Sub oForm_OperTpMov_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_OperTpMov.FormClosing
        CarregarDados()
    End Sub

    Private Sub oForm_TipoPagamento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_TipoPagamento.FormClosing
        CarregarDados()
    End Sub

    Private Sub oForm_OperacaoBancaria_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_OperacaoBancaria.FormClosing
        CarregarDados()
    End Sub

    Private Sub oForm_ItemBranch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_ItemBranch.FormClosing
        CarregarDados()
    End Sub

    Private Sub oForm_TipoFretistaTributacao_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_TipoFretistaTributacao.FormClosing
        CarregarDados()
    End Sub

    Private Sub oForm_ModalidadeConciliacao_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_ModalidadeConciliacao.FormClosing
        CarregarDados()
    End Sub

    Private Sub oForm_TipoMovimentacao_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_TipoMovimentacao.FormClosing
        CarregarDados()
    End Sub

    Private Sub oForm_BonusPadrao_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_BonusPadrao.FormClosing
        CarregarDados()
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        CarregarDados()
    End Sub

    Private Sub oForm_Armazem_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_Armazem.FormClosing
        CarregarDados()
    End Sub
End Class