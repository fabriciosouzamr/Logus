Public Class Pesq_CodigoNome
    Public Enum TPPesquisa
        Pq_Logus_Inicializar = 0
        Pq_Logus_Fornecedor = 1
        Pq_Logus_Filial = 2
        Pq_Logus_Movimentacao = 3
        Pq_Logus_OperacaoBancaria = 4
        Pq_Logus_TipoMovimentacao = 5
        Pq_Logus_Freista = 6
        Pq_Logus_ContratoPAF = 7
        Pq_Logus_ContratoPAF_Fornecedor = 8
        Pq_Logus_Municipio = 9
        Pq_Luminis_Usuario = 10
        Pq_Luminis_Cliente = 11
        Pq_Luminis_Produto = 12
        Pq_Luminis_Projeto_Branch_Plant = 13
        Pq_Luminis_Cliente_BranchPlant = 14
        Pq_Luminis_PDC = 15
        Pq_Luminis_Produto_BranchPlant = 16
        Pq_Luminis_Materia_Prima_BranchPlant = 17
        Pq_Luminis_Projeto = 18
        Pq_Luminis_Forma_Pagamento = 19
        Pq_Luminis_PDC_Grupo = 20
        Pq_Luminis_PDC_PDC_A_Definir = 21
        Pq_Luminis_Formulas = 22
        Pq_Custo_Produto = 23
        Pq_Custo_TipoProduto = 24
        Pq_Custo_ContaContabil_Ativo = 25
        Pq_Luminis_ReclamacaoCliente_Usuario = 26
        Pq_Luminis_DestinoFrete = 27
        Pq_Luminis_ProdutoEmbalagem = 29
        Pq_Luminis_DestinoFrete_BranchPlant = 30
        Pq_Luminis_ClienteTodos = 31
        Pq_Logus_TipoMovimentacao_Aplicacao = 32
        Pq_Luminis_Vendedor = 33
        Pq_Luminis_Materia_Prima_Commodity = 34
        Pq_Luminis_Materia_Prima_Commodity_Produto = 35
        Pq_Seguranca_Usuario_ComAcesso = 36
        Pq_Luminis_Area = 37
        Pq_Luminis_Mailing = 38
    End Enum

    Enum TipoCampoPesquisa
        SemDefinicao = 0
        Numero = 1
        Texto = 2
        Descricao = 3
    End Enum

    Event AlterouRegistro()
    Event LimpezaControle()
    Event ItemPesquisado()

    Dim WithEvents oMenu As System.Windows.Forms.ContextMenuStrip

    Const cnt_Left_Campo As Integer = 25
    Const cnt_EspacoDireito As Integer = 1

    Dim oTPPesquisa As TPPesquisa
    Dim sBancoDados_Tabela As String
    Dim sBancoDados_Campo_Codigo As String
    Dim sBancoDados_Campo_Codigo2 As String
    Dim sBancoDados_Campo_Descricao As String
    Dim sBancoDados_Campo_Pesquisa As String
    Dim oBancoDados_Campo_Codigo_Tipo As TipoCampoPesquisa
    Dim oBancoDados_Campo_TipoPesquisa As TipoCampoPesquisa
    Dim oBancoDados_Campo_Adicional As Collection
    Dim oBancoDados_Filtro As Collection
    Dim bExibirCodigo As Boolean = True

    Dim lCodigo_Ant As Object
    Dim lCodigo As Object
    Dim sDescricao As String
    Dim bProcInterno As Boolean
    Dim bTelaFiltro As Boolean
    Dim bValidado As Boolean
    Dim bLoad As Boolean

    Private Sub Pesq_CodigoNome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        ModoEdicao = True
    End Sub

    Private Sub Pesq_CodigoNome_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        ModoEdicao = True
    End Sub

    Private Sub Pesq_CodigoNome_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        ModoEdicao = True
    End Sub

    Private Sub Pesq_CodigoNome_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Tecla_ESC()
        End If
    End Sub

    Private Sub Pesq_CodigoNome_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMostrar.Focus()
        txtPesquisar.Visible = False
        cmdFiltro.Visible = False
        Controle_Ajustar()
        BancoDados_Filtro_Limpar()
        bExibirCodigo = True
        bLoad = True
    End Sub

    Public Sub BancoDados_Filtro_Limpar()
        oBancoDados_Filtro = New Collection
        Limpar()
    End Sub

    Public Sub BancoDados_Filtro_Adicionar(ByVal sFiltro As String)
        oBancoDados_Filtro.Add(sFiltro)
    End Sub

    Public Sub BancoDados_Campo_Adicional_Limpar()
        oBancoDados_Campo_Adicional = New Collection
    End Sub

    Public Sub BancoDados_Campo_Adicional_Adicionar(ByVal sCampo As String)
        oBancoDados_Campo_Adicional.Add(sCampo)
    End Sub

    Public Function BancoDados_Campo_Adicional_Valor(ByVal Campo As Object) As Object
        Dim iCont As Integer
        Dim Aux As Object = Nothing

        If lblMostrar.Tag Is Nothing Then
            Aux = Nothing
        Else
            If IsNumeric(Campo) Then
                Aux = lblMostrar.Tag(Campo)
            Else
                For iCont = 1 To oBancoDados_Campo_Adicional.Count
                    If oBancoDados_Campo_Adicional(iCont) = Campo Then
                        Aux = lblMostrar.Tag(iCont - 1)
                    End If
                Next
            End If
        End If

        Return Aux
    End Function

    Private Sub Pesq_CodigoNome_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Controle_Ajustar()
    End Sub

    Private Sub Controle_Ajustar(Optional ByVal BotaoFiltro As Boolean = False)
        If cmdFiltro.Visible Or BotaoFiltro Then
            txtPesquisar.Left = cnt_Left_Campo
            lblMostrar.Left = cnt_Left_Campo
        Else
            txtPesquisar.Left = cmdFiltro.Left
            lblMostrar.Left = cmdFiltro.Left
        End If

        txtPesquisar.Width = Me.Width - txtPesquisar.Left - cnt_EspacoDireito
        lblMostrar.Width = Me.Width - lblMostrar.Left - cnt_EspacoDireito
    End Sub

    Property Tipo_Pesquisa() As TPPesquisa
        Get
            Return oTPPesquisa
        End Get
        Set(ByVal Valor As TPPesquisa)
            Dim BotaoFiltro As Boolean = False

            oTPPesquisa = Valor

            Select Case Valor
                Case TPPesquisa.Pq_Logus_Fornecedor
                    sBancoDados_Tabela = "FORNECEDOR F"
                    sBancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
                    sBancoDados_Campo_Codigo = "CD_FORNECEDOR"
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Logus_Filial
                    sBancoDados_Tabela = "FILIAL"
                    sBancoDados_Campo_Descricao = "NO_FILIAL"
                    sBancoDados_Campo_Codigo = "CD_FILIAL"
                    BotaoFiltro = False
                Case TPPesquisa.Pq_Logus_Movimentacao
                    sBancoDados_Tabela = "(SELECT SQ_MOVIMENTACAO," & _
                                                 "TO_CHAR(MV.DT_MOVIMENTACAO, 'DD-MM-YYYY') || ' - ' || " & _
                                                    "TRIM(NVL(FN.NO_RAZAO_SOCIAL, FT.NO_FILIAL)) ||" & _
                                                    "' - Nº N.F.: ' || MV.NU_NF || " & _
                                                    "' - KG NF: ' || TO_CHAR(MV.QT_KG_NF, '999,990') || " & _
                                                    "' - VL NF: ' || TO_CHAR(MV.VL_NF, '999,990.00') DS_MOVIMENTACAO," & _
                                                 "MV.NU_NF" & _
                                          " FROM SOF.MOVIMENTACAO MV," & _
                                                "SOF.FORNECEDOR FN," & _
                                                "SOF.TRANSFERENCIA TR," & _
                                                "SOF.FILIAL FT" & _
                                          " WHERE FN.CD_FORNECEDOR (+) = MV.CD_FORNECEDOR" & _
                                            " AND TR.SQ_MOVIMENTACAO_SAIDA (+) = MV.SQ_MOVIMENTACAO" & _
                                            " AND FT.CD_FILIAL (+) = TR.CD_FILIAL_ORIGEM" & _
                                            " AND (FN.CD_FORNECEDOR IS NOT NULL OR TR.SQ_TRANSFERENCIA IS NOT NULL))"
                    sBancoDados_Tabela = "(SELECT SQ_MOVIMENTACAO," & _
                                                 "TO_CHAR(MV.DT_MOVIMENTACAO, 'DD-MM-YYYY') || ' - ' || " & _
                                                    "TRIM(NVL(FN.NO_RAZAO_SOCIAL, FT.NO_FILIAL)) ||" & _
                                                    "' - Nº N.F.: ' || MV.NU_NF || " & _
                                                    "' - KG NF: ' || TO_CHAR(MV.QT_KG_NF, '999,990') || " & _
                                                    "' - VL NF: ' || TO_CHAR(MV.VL_NF, '999,990.00') DS_MOVIMENTACAO," & _
                                                 "MV.NU_NF" & _
                                          " FROM SOF.MOVIMENTACAO MV," & _
                                                "SOF.FORNECEDOR FN," & _
                                                "SOF.TRANSFERENCIA TR," & _
                                                "SOF.FILIAL FT" & _
                                          " WHERE FN.CD_FORNECEDOR (+) = MV.CD_FORNECEDOR" & _
                                            " AND TR.SQ_MOVIMENTACAO_SAIDA (+) = MV.SQ_MOVIMENTACAO" & _
                                            " AND FT.CD_FILIAL (+) = TR.CD_FILIAL_ORIGEM)"
                    sBancoDados_Campo_Descricao = "DS_MOVIMENTACAO"
                    sBancoDados_Campo_Codigo = "SQ_MOVIMENTACAO"
                    oBancoDados_Campo_TipoPesquisa = TipoCampoPesquisa.Descricao
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Logus_OperacaoBancaria
                    sBancoDados_Tabela = "(SELECT * FROM SOF.OPERACAO_BANCARIA WHERE NVL(IC_ATIVO, 'N') = 'S')"
                    sBancoDados_Campo_Descricao = "NO_OPERACAO"
                    sBancoDados_Campo_Codigo = "CD_OPERACAO_BANCARIA"
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Logus_TipoMovimentacao, TPPesquisa.Pq_Logus_TipoMovimentacao_Aplicacao
                    sBancoDados_Tabela = "SELECT TM.CD_TIPO_MOVIMENTACAO," & _
                                                "TM.NO_TIPO_MOVIMENTACAO," & _
                                                "NVL(TM.IC_ATIVO, 'S') IC_ATIVO," & _
                                                "TM.IC_VALIDA_QUALIDADE," & _
                                                "IC_VALIDA_KG" & _
                                         " FROM SOF.TIPO_RD RD," & _
                                               "SOF.TIPO_MOVIMENTACAO TM" & _
                                         " WHERE RD.CD_TIPO_RD(+) = TM.CD_TIPO_RD"

                    If Valor = TPPesquisa.Pq_Logus_TipoMovimentacao_Aplicacao Then
                        sBancoDados_Tabela = sBancoDados_Tabela & " AND NVL(TM.IC_APLICACAO, 'N') = 'S'"
                    End If

                    sBancoDados_Tabela = "(" & sBancoDados_Tabela & ") RD"
                    sBancoDados_Campo_Descricao = "NO_TIPO_MOVIMENTACAO"
                    sBancoDados_Campo_Codigo = "CD_TIPO_MOVIMENTACAO"
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Logus_Freista
                    sBancoDados_Tabela = "FRETISTA"
                    sBancoDados_Campo_Descricao = "NO_FRETISTA"
                    sBancoDados_Campo_Codigo = "CD_FRETISTA"
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Logus_ContratoPAF
                    sBancoDados_Tabela = "(SELECT C.CD_CONTRATO_PAF," & _
                                                 "TRIM(F.NO_RAZAO_SOCIAL) || ' (' || CAST(F.CD_FORNECEDOR AS VARCHAR2(10)) || ')' AS NO_CONTRATO_PAF," & _
                                                 "C.IC_STATUS," & _
                                                 "F.CD_TIPO_PESSOA" & _
                                          " FROM SOF.CONTRATO_PAF C," & _
                                                "SOF.FORNECEDOR F" & _
                                          " WHERE C.CD_FORNECEDOR = F.CD_FORNECEDOR) F"
                    sBancoDados_Campo_Descricao = "NO_CONTRATO_PAF"
                    sBancoDados_Campo_Codigo = "CD_CONTRATO_PAF"
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Logus_ContratoPAF_Fornecedor
                    sBancoDados_Tabela = "(SELECT C.CD_CONTRATO_PAF," & _
                                                 "F.NO_RAZAO_SOCIAL AS NO_CONTRATO_PAF," & _
                                                 "C.IC_STATUS," & _
                                                 "F.CD_FORNECEDOR" & _
                                          " FROM SOF.CONTRATO_PAF C," & _
                                                "SOF.FORNECEDOR F" & _
                                          " WHERE C.CD_FORNECEDOR = F.CD_FORNECEDOR ) F"
                    sBancoDados_Campo_Descricao = "NO_CONTRATO_PAF"
                    sBancoDados_Campo_Codigo = "CD_CONTRATO_PAF"
                    BotaoFiltro = True
                    Pesquisa_AdicionarFiltro()
                Case TPPesquisa.Pq_Logus_Municipio
                    sBancoDados_Tabela = "(SELECT CD_MUNICIPIO," & _
                                                 "TRIM(MC.NO_CIDADE) || ' - ' || TRIM(UF.NO_UF) NO_CIDADE" & _
                                         " FROM SOF.MUNICIPIO MC," & _
                                               "SOF.UF UF" & _
                                         " WHERE UF.CD_UF = MC.CD_UF)"
                    sBancoDados_Campo_Descricao = "NO_CIDADE"
                    sBancoDados_Campo_Codigo = "CD_MUNICIPIO"
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Luminis_Usuario
                    sBancoDados_Tabela = "SEC_USUARIO"
                    sBancoDados_Campo_Descricao = "NO_USUARIO"
                    sBancoDados_Campo_Codigo = "CD_USUARIO"
                    'BancoDados_Filtro_Limpar()
                    'BancoDados_Filtro_Adicionar("IC_ATIVO ='S'")
                    oBancoDados_Campo_Codigo_Tipo = TipoCampoPesquisa.Texto
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Luminis_Vendedor
                    sBancoDados_Tabela = "VENDEDOR"
                    sBancoDados_Campo_Descricao = "NO_VENDEDOR"
                    sBancoDados_Campo_Codigo = "CD_VENDEDOR"
                    BancoDados_Filtro_Limpar()
                    BancoDados_Filtro_Adicionar("IC_ATIVO ='S'")
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Luminis_Produto
                    sBancoDados_Tabela = "(SELECT SQ_PRODUTO, TRIM(CD_PRODUTO) || ' - ' || NO_PRODUTO NO_PRODUTO" & _
                                          " FROM CRM.PRODUTO)"
                    sBancoDados_Campo_Descricao = "NO_PRODUTO"
                    sBancoDados_Campo_Codigo = "SQ_PRODUTO"
                    BotaoFiltro = True
                    bExibirCodigo = False
                Case TPPesquisa.Pq_Luminis_PDC
                    sBancoDados_Tabela = "(SELECT PD.SQ_PDC," & _
                                                "TRIM(PD.CD_PDC) || ' - ' || PG.DS_PDC NO_PDC," & _
                                                 "BP.CD_BRANCH_PLANT," & _
                                                 "BP.CD_UNIDADE_NEGOCIO" & _
                                          " FROM CRM.PDC PD," & _
                                                "CRM.PDC_GRUPO PG, " & _
                                                "CRM.BRANCH_PLANT BP" & _
                                          " WHERE PD.SQ_PDC_GRUPO = PG.SQ_PDC_GRUPO" & _
                                            IIf(SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AdministradorFormulacaoPDC), "", " AND PD.NO_USER_CRIACAO = " & QuotedStr(sAcesso_UsuarioLogado)) & _
                                            " AND BP.CD_BRANCH_PLANT = PG.CD_BRANCH_PLANT)"
                    sBancoDados_Campo_Descricao = "NO_PDC"
                    sBancoDados_Campo_Codigo = "SQ_PDC"
                    BancoDados_Filtro_Limpar()
                    BancoDados_Filtro_Adicionar("CD_BRANCH_PLANT = 0")
                    BotaoFiltro = True
                    bExibirCodigo = False
                Case TPPesquisa.Pq_Luminis_Formulas
                    sBancoDados_Tabela = "(SELECT PD.SQ_PDC," & _
                                                "TRIM(PD.CD_PDC) || ' - ' || PG.DS_PDC NO_PDC," & _
                                                 "BP.CD_BRANCH_PLANT," & _
                                                 "BP.CD_UNIDADE_NEGOCIO" & _
                                          " FROM CRM.PDC PD," & _
                                                "CRM.PDC_GRUPO PG, " & _
                                                "CRM.BRANCH_PLANT BP" & _
                                          " WHERE PD.SQ_PDC_GRUPO = PG.SQ_PDC_GRUPO" & _
                                          " AND BP.CD_BRANCH_PLANT = PG.CD_BRANCH_PLANT)"
                    sBancoDados_Campo_Descricao = "NO_PDC"
                    sBancoDados_Campo_Codigo = "SQ_PDC"
                    BancoDados_Filtro_Limpar()
                    BancoDados_Filtro_Adicionar("CD_BRANCH_PLANT = 0")
                    BotaoFiltro = True
                    bExibirCodigo = False
                Case TPPesquisa.Pq_Luminis_PDC_Grupo
                    sBancoDados_Tabela = "(SELECT PG.SQ_PDC_GRUPO," & _
                                                 "PG.DS_PDC NO_PDC," & _
                                                 "BP.CD_BRANCH_PLANT," & _
                                                 "BP.CD_UNIDADE_NEGOCIO" & _
                                          " FROM CRM.PDC_GRUPO PG, " & _
                                                "CRM.BRANCH_PLANT BP" & _
                                          " WHERE BP.CD_BRANCH_PLANT = PG.CD_BRANCH_PLANT)"
                    sBancoDados_Campo_Descricao = "NO_PDC"
                    sBancoDados_Campo_Codigo = "SQ_PDC_GRUPO"
                    BancoDados_Filtro_Limpar()
                    BancoDados_Filtro_Adicionar("CD_BRANCH_PLANT = 0")
                    BotaoFiltro = True
                    bExibirCodigo = False
                Case TPPesquisa.Pq_Luminis_Cliente
                    sBancoDados_Tabela = "(SELECT CLI.CD_CLIENTE," & _
                                                 "CLI.NO_CLIENTE " & _
                                          " FROM CRM.CLIENTE CLI, " & _
                                               "(SELECT E.CD_CLIENTE," & _
                                                       "COUNT(*)" & _
                                                " FROM CRM.ENDERECO_CLIENTE E " & _
                                                " WHERE E.IC_ATIVO = 'S'" & _
                                                " GROUP BY E.CD_CLIENTE" & _
                                                " HAVING COUNT(*) <> 0) EA " & _
                                          " WHERE CLI.CD_CLIENTE = EA.CD_CLIENTE)"
                    sBancoDados_Campo_Descricao = "NO_CLIENTE"
                    sBancoDados_Campo_Codigo = "CD_CLIENTE"
                    BancoDados_Filtro_Limpar()
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Luminis_ClienteTodos
                    sBancoDados_Tabela = "CLIENTE"
                    sBancoDados_Campo_Descricao = "NO_CLIENTE"
                    sBancoDados_Campo_Codigo = "CD_CLIENTE"
                    BancoDados_Filtro_Limpar()
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Luminis_Materia_Prima_BranchPlant, _
                     TPPesquisa.Pq_Luminis_Materia_Prima_Commodity, _
                     TPPesquisa.Pq_Luminis_Materia_Prima_Commodity_Produto
                    sBancoDados_Tabela = "(SELECT M.SQ_MATERIA_PRIMA," & _
                                                 "MB.CD_BRANCH_PLANT," & _
                                                 "M.CD_MATERIA_PRIMA_PDC || ' - ' || M.NO_MATERIA_PRIMA NO_MATERIA_PRIMA_PDC," & _
                                                 "M.NO_MATERIA_PRIMA," & _
                                                 "M.CD_MATERIA_PRIMA_PDC," & _
                                                 "NVL(M.IC_SOLVENTE, 'N') IC_SOLVENTE," & _
                                                 "NVL(M.IC_COMMODITY, 'N') IC_COMMODITY," & _
                                                 "NVL(PD.SQ_PRODUTO, 0) SQ_PRODUTO" & _
                                          " FROM CRM.MATERIA_PRIMA M," & _
                                                "CRM.MATERIA_PRIMA_BRANCH_PLANT MB," & _
                                                "CRM.PRODUTO PD" & _
                                          " WHERE MB.SQ_MATERIA_PRIMA = M.SQ_MATERIA_PRIMA" & _
                                            " AND TRIM(PD.CD_PRODUTO (+)) = TRIM(M.CD_MATERIA_PRIMA_PDC)" & _
                                          "UNION ALL " & _
                                          "SELECT 0 - PDC.SQ_PDC SQ_MATERIA_PRIMA," & _
                                                 "PDC.CD_BRANCH_PLANT," & _
                                                 "PDC.CD_PDC || ' - ' || PDG.DS_PDC," & _
                                                 "PDG.DS_PDC," & _
                                                 "PDC.CD_PDC," & _
                                                 "'N','N'," & _
                                                 "0 SQ_PRODUTO" & _
                                          " FROM CRM.PDC PDC," & _
                                                "CRM.PDC_GRUPO PDG" & _
                                          " WHERE PDG.SQ_PDC_GRUPO = PDC.SQ_PDC_GRUPO)"

                    If fIN(Valor, TPPesquisa.Pq_Luminis_Materia_Prima_Commodity, TPPesquisa.Pq_Luminis_Materia_Prima_Commodity_Produto) Then
                        sBancoDados_Tabela = "(SELECT * FROM (" & sBancoDados_Tabela & ") WHERE IC_COMMODITY = 'S')"
                    End If

                    sBancoDados_Campo_Descricao = "NO_MATERIA_PRIMA_PDC"

                    If Valor = TPPesquisa.Pq_Luminis_Materia_Prima_Commodity_Produto Then
                        sBancoDados_Campo_Codigo = "SQ_PRODUTO"
                    Else
                        sBancoDados_Campo_Codigo = "SQ_MATERIA_PRIMA"
                    End If

                    BancoDados_Filtro_Limpar()
                    BancoDados_Filtro_Adicionar("CD_BRANCH_PLANT = 0")
                    BotaoFiltro = True
                    bExibirCodigo = False
                Case TPPesquisa.Pq_Luminis_Cliente_BranchPlant
                    sBancoDados_Tabela = "(SELECT CLI.CD_CLIENTE, CLI.NO_CLIENTE, BPT.CD_BRANCH_PLANT, CBU.CD_UNIDADE_NEGOCIO " & _
                                          " FROM CRM.CLIENTE CLI," & _
                                                "CRM.CLIENTE_UNIDADE_NEGOCIO CBU," & _
                                                "CRM.BRANCH_PLANT BPT, " & _
                                                "(select e.cd_cliente , count(*) from crm.endereco_cliente e " & _
                                                "where e.ic_ativo ='S' " & _
                                                "group by e.cd_cliente " & _
                                                "having count(*)<>0) EA " & _
                                          " WHERE CBU.CD_CLIENTE = CLI.CD_CLIENTE" & _
                                            " AND BPT.CD_UNIDADE_NEGOCIO = CBU.CD_UNIDADE_NEGOCIO " & _
                                            " AND CLI.CD_CLIENTE = EA.cd_cliente)"
                    sBancoDados_Campo_Descricao = "NO_CLIENTE"
                    sBancoDados_Campo_Codigo = "CD_CLIENTE"
                    BancoDados_Filtro_Limpar()
                    BancoDados_Filtro_Adicionar("CD_BRANCH_PLANT = 0")
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Luminis_Projeto
                    sBancoDados_Tabela = "(SELECT P.CD_PROJETO," & _
                                                 "P.NU_PROJETO || ' - ' ||  P.NO_PROJETO AS NO_PROJETO" & _
                                          " FROM CRM.PROJETO P)"
                    sBancoDados_Campo_Descricao = "NO_PROJETO"
                    sBancoDados_Campo_Codigo = "CD_PROJETO"
                    BancoDados_Filtro_Limpar()
                    BotaoFiltro = True
                    bExibirCodigo = False
                Case TPPesquisa.Pq_Luminis_Projeto_Branch_Plant
                    sBancoDados_Tabela = "(SELECT P.CD_PROJETO," & _
                                                 "P.NU_PROJETO || ' - ' ||  P.NO_PROJETO AS NO_PROJETO," & _
                                                 "BP.CD_BRANCH_PLANT," & _
                                                 "BP.CD_UNIDADE_NEGOCIO" & _
                                        "    FROM CRM.PROJETO P," & _
                                                 "CRM.PROJETO_BRANCH_PLANT PBP," & _
                                                 "CRM.BRANCH_PLANT BP" & _
                                        "   WHERE P.CD_PROJETO =PBP.CD_PROJETO" & _
                                            " AND PBP.CD_BRANCH_PLANT =BP.CD_BRANCH_PLANT)"

                    sBancoDados_Campo_Descricao = "NO_PROJETO"
                    sBancoDados_Campo_Codigo = "CD_PROJETO"
                    BotaoFiltro = True
                    bExibirCodigo = False
                Case TPPesquisa.Pq_Luminis_Produto_BranchPlant
                    sBancoDados_Tabela = "(SELECT  P.SQ_PRODUTO," & _
                                                  "P.CD_PRODUTO  || ' - ' || trim(P.NO_PRODUTO) AS NO_PRODUTO," & _
                                                 "BP.CD_BRANCH_PLANT," & _
                                                 "BP.CD_UNIDADE_NEGOCIO " & _
                                          " FROM CRM.PRODUTO P," & _
                                                "CRM.PRODUTO_BRANCH_PLANT PBP," & _
                                                "CRM.BRANCH_PLANT BP" & _
                                          " WHERE P.SQ_PRODUTO = PBP.SQ_PRODUTO" & _
                                            " AND PBP.CD_BRANCH_PLANT = BP.CD_BRANCH_PLANT)"
                    sBancoDados_Campo_Descricao = "NO_PRODUTO"
                    sBancoDados_Campo_Codigo = "SQ_PRODUTO"
                    BancoDados_Filtro_Limpar()
                    BancoDados_Filtro_Adicionar("CD_BRANCH_PLANT = 0")
                    BotaoFiltro = True
                    bExibirCodigo = False
                Case TPPesquisa.Pq_Luminis_ProdutoEmbalagem
                    sBancoDados_Tabela = "(SELECT  P.SQ_PRODUTO," & _
                                                  "P.CD_PRODUTO  || ' - ' || trim(P.NO_PRODUTO) || DECODE(E.CD_EMBALAGEM, NULL,'',' - ') || E.NO_EMBALAGEM   AS NO_PRODUTO," & _
                                                 "BP.CD_BRANCH_PLANT," & _
                                                 "BP.CD_UNIDADE_NEGOCIO " & _
                                          " FROM CRM.PRODUTO P," & _
                                                "CRM.PRODUTO_BRANCH_PLANT PBP," & _
                                                "CRM.BRANCH_PLANT BP, CRM.EMBALAGEM E" & _
                                          " WHERE P.SQ_PRODUTO = PBP.SQ_PRODUTO" & _
                                            " AND P.CD_EMBALAGEM_PADRAO = E.CD_EMBALAGEM (+) " & _
                                            " AND PBP.CD_BRANCH_PLANT = BP.CD_BRANCH_PLANT)"
                    sBancoDados_Campo_Descricao = "NO_PRODUTO"
                    sBancoDados_Campo_Codigo = "SQ_PRODUTO"
                    BotaoFiltro = True
                    bExibirCodigo = False
                Case TPPesquisa.Pq_Luminis_Mailing
                    Dim SqlText As String
              
                    SqlText = "select SQ_MAILING, NO_MAILING from CRM.MAILING "
                    If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AdministradorMailing) Then
                        SqlText = SqlText & " where ( no_user_criacao  = " & QuotedStr(sAcesso_UsuarioLogado)
                        SqlText = SqlText & " or sq_mailing in (select sq_mailing from CRM.MAILING_USUARIO where cd_usuario  = " & QuotedStr(sAcesso_UsuarioLogado) & "))"
                    End If
                    sBancoDados_Tabela = "(" & SqlText & ")"
                    sBancoDados_Campo_Descricao = "NO_MAILING"
                    sBancoDados_Campo_Codigo = "SQ_MAILING"
                    BotaoFiltro = True
                    bExibirCodigo = True
                Case TPPesquisa.Pq_Luminis_Forma_Pagamento

                    sBancoDados_Tabela = "(SELECT CD_FORMA_PAGAMENTO, trim(CD_FORMA_PAGAMENTO_OW) || DECODE(CD_FORMA_PAGAMENTO_OW,NULL,'',' - ') || NO_FORMA_PAGAMENTO as NO_FORMA_PAGAMENTO" & _
                                         " FROM CRM.FORMA_PAGAMENTO)"

                    sBancoDados_Campo_Descricao = "NO_FORMA_PAGAMENTO"
                    sBancoDados_Campo_Codigo = "CD_FORMA_PAGAMENTO"
                    bExibirCodigo = False
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Luminis_PDC_PDC_A_Definir
                    sBancoDados_Tabela = "(SELECT PD.SQ_PDC," & _
                                                 "TRIM(PD.CD_PDC) || ' - ' || PG.DS_PDC NO_PDC," & _
                                                 "BP.CD_BRANCH_PLANT," & _
                                                 "BP.CD_UNIDADE_NEGOCIO" & _
                                          " FROM CRM.PDC PD," & _
                                                "CRM.PDC_GRUPO PG," & _
                                                "CRM.BRANCH_PLANT BP" & _
                                          " WHERE PD.SQ_PDC_GRUPO = PG.SQ_PDC_GRUPO" & _
                                            " AND BP.CD_BRANCH_PLANT = PD.CD_BRANCH_PLANT" & _
                                         " UNION ALL" & _
                                         " SELECT 0 - PD.SQ_PDC_GRUPO SQ_PDC," & _
                                                 "TRIM(PD.DS_PDC) || ' - A Desenvolver' NO_PDC," & _
                                                 "BP.CD_BRANCH_PLANT," & _
                                                 "BP.CD_UNIDADE_NEGOCIO" & _
                                          " FROM CRM.PDC_GRUPO PD," & _
                                                "CRM.BRANCH_PLANT BP" & _
                                          " WHERE BP.CD_BRANCH_PLANT = PD.CD_BRANCH_PLANT)"
                    sBancoDados_Campo_Descricao = "NO_PDC"
                    sBancoDados_Campo_Codigo = "SQ_PDC"
                    BancoDados_Filtro_Limpar()
                    BancoDados_Filtro_Adicionar("CD_BRANCH_PLANT = 0")
                    BotaoFiltro = True
                    bExibirCodigo = False
                Case TPPesquisa.Pq_Custo_Produto
                    sBancoDados_Tabela = "(SELECT SQ_PRODUTO," & _
                                                 "TRIM(CD_PRODUTO) || ' - ' || NO_PRODUTO DS_PRODUTO," & _
                                                 "CD_PRODUTO," & _
                                                 "NO_PRODUTO" & _
                                          " FROM QLT.PRODUTO)"
                    sBancoDados_Campo_Descricao = "DS_PRODUTO"
                    sBancoDados_Campo_Codigo = "SQ_PRODUTO"
                    BotaoFiltro = True
                    bExibirCodigo = False
                Case TPPesquisa.Pq_Custo_TipoProduto
                    sBancoDados_Tabela = "QLT.TIPO_PRODUTO"
                    sBancoDados_Campo_Descricao = "NO_TIPO_PRODUTO"
                    sBancoDados_Campo_Codigo = "CD_TIPO_PRODUTO"
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Custo_ContaContabil_Ativo
                    sBancoDados_Tabela = "(SELECT * FROM CTS.CONTA_CONTABIL WHERE NVL(IC_ATIVO, 'N') = 'S')"
                    sBancoDados_Campo_Descricao = "DS_CONTA_CONTABIL"
                    sBancoDados_Campo_Codigo = "CD_CONTA_CONTABIL"
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Luminis_ReclamacaoCliente_Usuario
                    sBancoDados_Tabela = "(SELECT RC.SQ_RECLAMACAO_CLIENTE," & _
                                                 "TRIM(RC.NU_RECLAMACAO) || ' - ' || TRIM(BP.NO_BRANCH_PLANT) || ' - ' || TRIM(CI.NO_CLIENTE) DS_RECLAMACAO_CLIENTE" & _
                                          " FROM CRM.RECLAMACAO_CLIENTE RC," & _
                                                "CRM.ENDERECO_CLIENTE EC," & _
                                                "CRM.CLIENTE CI," & _
                                                "CRM.BRANCH_PLANT BP," & _
                                                "(SELECT DISTINCT CD_BRANCH_PLANT" & _
                                                 " FROM CRM.VW_SEC_USUARIOACESSO" & _
                                                 " WHERE NO_AREAACESSO_INTERNO IN ('Consulta_Reclamacao', 'AdministradorReclamacaoCliente')" & _
                                                   " AND CD_USUARIO = " & QuotedStr(sAcesso_UsuarioLogado) & _
                                                   " AND CD_BRANCH_PLANT IS NOT NULL) AC" & _
                                          " WHERE RC.CD_BRANCH_PLANT = AC.CD_BRANCH_PLANT" & _
                                            " AND EC.SQ_ENDERECO_CLIENTE = RC.SQ_ENDERECO_CLIENTE" & _
                                            " AND CI.CD_CLIENTE = EC.CD_CLIENTE" & _
                                            " AND BP.CD_BRANCH_PLANT = RC.CD_BRANCH_PLANT and rc.ic_tipo='R' " & _
                                          " ORDER BY TRIM(RC.NU_RECLAMACAO) || ' - ' || TRIM(BP.NO_BRANCH_PLANT) || ' - ' || TRIM(CI.NO_CLIENTE))"
                    sBancoDados_Campo_Descricao = "DS_RECLAMACAO_CLIENTE"
                    sBancoDados_Campo_Codigo = "SQ_RECLAMACAO_CLIENTE"
                    BotaoFiltro = False
                    bExibirCodigo = False
                Case TPPesquisa.Pq_Luminis_DestinoFrete
                    sBancoDados_Tabela = "SELECT distinct a.sq_area , a.no_area FROM crm.area_utilizacao u, crm.area a where u.sq_area =a.sq_area "
                    sBancoDados_Campo_Descricao = "NO_DESTINO_FRETE"
                    sBancoDados_Campo_Codigo = "CD_DESTINO_FRETE"
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Luminis_Area
                    sBancoDados_Tabela = "AREA"
                    sBancoDados_Campo_Descricao = "NO_AREA"
                    sBancoDados_Campo_Codigo = "SQ_AREA"
                    BotaoFiltro = True
               
                Case TPPesquisa.Pq_Luminis_DestinoFrete_BranchPlant
                    sBancoDados_Tabela = "(SELECT DF.CD_DESTINO_FRETE," & _
                                                 "DF.NO_DESTINO_FRETE," & _
                                                 "PC.CD_BRANCH_PLANT " & _
                                          " FROM CRM.PERCURSO PC," & _
                                                "CRM.DESTINO_FRETE DF" & _
                                          " WHERE  DF.CD_DESTINO_FRETE = PC.CD_DESTINO_FRETE" & _
                                          " ORDER BY DF.NO_DESTINO_FRETE)"
                    sBancoDados_Campo_Descricao = "NO_DESTINO_FRETE"
                    sBancoDados_Campo_Codigo = "CD_DESTINO_FRETE"
                    BancoDados_Filtro_Limpar()
                    BancoDados_Filtro_Adicionar("CD_BRANCH_PLANT = 0")
                    BotaoFiltro = True
                Case TPPesquisa.Pq_Seguranca_Usuario_ComAcesso
                    sBancoDados_Tabela = "(SELECT DISTINCT US.CD_USUARIO," & _
                                                          "US.NO_USUARIO" & _
                                          " FROM " & sBancoDados_OwnerCtrlAcesso & ".VW_SEC_USUARIOACESSO_GERAL UA," & _
                                                     sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO US" & _
                                          " WHERE UA.CD_SISTEMA = " & cnt_Sistema_ControleAcesso & _
                                            " AND US.CD_USUARIO = UA.CD_USUARIO)"
                    sBancoDados_Campo_Descricao = "NO_USUARIO"
                    sBancoDados_Campo_Codigo = "CD_USUARIO"
                    BancoDados_Campo_Codigo_Tipo = TipoCampoPesquisa.Texto
                    BancoDados_Filtro_Limpar()
                    BotaoFiltro = True
            End Select

            cmdFiltro.Visible = BotaoFiltro

            Controle_Ajustar(BotaoFiltro)
        End Set
    End Property

    Property BancoDados_Tabela() As String
        Get
            Return sBancoDados_Tabela
        End Get
        Set(ByVal Valor As String)
            sBancoDados_Tabela = Valor
            Limpar()
        End Set
    End Property

    Property BancoDados_Campo_Codigo() As String
        Get
            Return sBancoDados_Campo_Codigo
        End Get
        Set(ByVal Valor As String)
            sBancoDados_Campo_Codigo = Valor
            Limpar()
        End Set
    End Property

    Property ExibirCodigo() As Boolean
        Get
            Return bExibirCodigo
        End Get
        Set(ByVal Valor As Boolean)
            bExibirCodigo = Valor
        End Set
    End Property

    Property BancoDados_Campo_Codigo2() As String
        Get
            Return sBancoDados_Campo_Codigo2
        End Get
        Set(ByVal Valor As String)
            sBancoDados_Campo_Codigo2 = Valor
            Pesquisa_AdicionarFiltro()
            Limpar()
        End Set
    End Property

    Property BancoDados_Campo_Descricao() As String
        Get
            Return sBancoDados_Campo_Descricao
        End Get
        Set(ByVal Valor As String)
            sBancoDados_Campo_Descricao = Valor
            Limpar()
        End Set
    End Property

    Property BancoDados_Campo_Pesquisa() As String
        Get
            Return sBancoDados_Campo_Pesquisa
        End Get
        Set(ByVal Valor As String)
            sBancoDados_Campo_Pesquisa = Valor
            Limpar()
        End Set
    End Property

    Property BancoDados_Campo_TipoPesquisa() As TipoCampoPesquisa
        Get
            Return oBancoDados_Campo_TipoPesquisa
        End Get
        Set(ByVal Valor As TipoCampoPesquisa)
            oBancoDados_Campo_TipoPesquisa = Valor
            Limpar()
        End Set
    End Property

    Property BancoDados_Campo_Codigo_Tipo() As TipoCampoPesquisa
        Get
            Return oBancoDados_Campo_Codigo_Tipo
        End Get
        Set(ByVal Valor As TipoCampoPesquisa)
            oBancoDados_Campo_Codigo_Tipo = Valor
            Limpar()
        End Set
    End Property

    Public WriteOnly Property ModoEdicao() As Boolean
        Set(ByVal Valor As Boolean)
            txtPesquisar.Visible = Valor

            If Valor Then
                bProcInterno = True

                txtPesquisar.Text = ""
                txtPesquisar.Focus()
                txtPesquisar.BringToFront()

                If Trim(lCodigo) <> "" Then
                    txtPesquisar.Text = lCodigo.ToString
                    txtPesquisar.SelectAll()
                End If

                bProcInterno = False
            Else
                txtPesquisar.Text = ""
            End If
        End Set
    End Property

    Property Codigo() As Object
        Set(ByVal Value As Object)
            Dim bItemPesquisado As Boolean = False

            If IsNumeric(Value) Then
                If Val(lCodigo) <> Value Then
                    lCodigo_Ant = lCodigo
                End If
            Else
                If UCase(Trim(lCodigo)) <> UCase(Trim(NVL(Value, ""))) Then
                    lCodigo_Ant = lCodigo
                End If
            End If

            lCodigo = Value

            bItemPesquisado = bTelaFiltro

            If Trim(lCodigo) <> "" And IIf(IsNumeric(lCodigo), Val(lCodigo) <> 0, True) Then
                CarregarDados(True, Trim(lCodigo))

                If bItemPesquisado Then
                    RaiseEvent ItemPesquisado()
                End If
            Else
                Limpar()
            End If
        End Set
        Get
            If oBancoDados_Campo_Codigo_Tipo = TipoCampoPesquisa.Texto Then
                Return Trim(lCodigo)
            Else
                Return Val(lCodigo)
            End If
        End Get
    End Property

    Property TelaFiltro() As Boolean
        Set(ByVal Value As Boolean)
            bTelaFiltro = Value
        End Set
        Get
            Return bTelaFiltro
        End Get
    End Property

    Property Descricao() As String
        Get
            Return sDescricao
        End Get
        Set(ByVal Valor As String)
            txtPesquisar.Text = Valor
            txtPesquisar_KeyDown_Enter()
        End Set
    End Property

    Private Sub txtPesquisar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPesquisar.GotFocus
        lCodigo_Ant = lCodigo
        bValidado = False
    End Sub

    Private Sub txtPesquisar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPesquisar.KeyDown
        Select Case e.KeyCode
            Case 188
                e.SuppressKeyPress = True
            Case Keys.Escape
                Tecla_ESC()
            Case Keys.Enter
                txtPesquisar_KeyDown_Enter()
        End Select
    End Sub

    Private Sub txtPesquisar_KeyDown_Enter()
        If Trim(txtPesquisar.Text) <> "" Then
            Validar_Editor(True)
        End If
    End Sub

    Private Sub txtPesquisar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPesquisar.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPesquisar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPesquisar.LostFocus
        If Not bProcInterno And Not bValidado And Trim(txtPesquisar.Text) <> Trim(lCodigo_Ant) Then
            Validar_Editor()
        Else
            ModoEdicao = False
        End If
    End Sub

    Private Sub Tecla_ESC()
        ModoEdicao = False
    End Sub

    Public Sub Validar_Editor(Optional ByVal bEventoAlteracaoFornecedor As Boolean = False)
        If Not txtPesquisar.Visible Then Exit Sub

        bValidado = True

        If Trim(txtPesquisar.Text) = "" Then
            Limpar()

            TratarAlteracaoRegistro()
        Else
            CarregarDados(False, txtPesquisar.Text)
        End If
    End Sub

    Private Sub Limpar()
        ModoEdicao = False
        lblMostrar.Text = ""
        lCodigo = ""
        sDescricao = ""
        RaiseEvent LimpezaControle()
    End Sub

    Private Sub CarregarDados(ByVal Codigo As Boolean, ByVal sValor As String)
        Dim oData As DataTable
        Dim SqlText As String
        Dim iCont As Integer
        Dim oPesquisa As TipoCampoPesquisa
        Dim oMenuItem As ToolStripItem

        If bProcInterno Then Exit Sub

        If Codigo Then
            If sValor = lCodigo_Ant Then
                ModoEdicao = False
                Exit Sub
            End If
        End If

        If Trim(sBancoDados_Campo_Codigo) = "" Or Trim(sBancoDados_Campo_Descricao) = "" Or _
           Trim(sValor) = "" Or (EhNumero(sValor) And Val(sValor) = 0) Then
            Exit Sub
        End If

        bProcInterno = True

        If Collection_Preenchido(oBancoDados_Campo_Adicional) Then
            SqlText = "SELECT DISTINCT " & sBancoDados_Campo_Codigo & ", " & sBancoDados_Campo_Descricao & _
                                     "," & Collection_Para_Lista(oBancoDados_Campo_Adicional) & _
                              " FROM " & DBObjeto_TratarNome(sBancoDados_Tabela)
        Else
            SqlText = "SELECT DISTINCT " & sBancoDados_Campo_Codigo & ", " & sBancoDados_Campo_Descricao & _
                              " FROM " & DBObjeto_TratarNome(sBancoDados_Tabela)
        End If

        sValor = Trim(sValor)

        If Trim(sBancoDados_Campo_Pesquisa) = "" Or bTelaFiltro Then
            If Codigo Then
                If EhNumero(sValor) And oBancoDados_Campo_Codigo_Tipo <> TipoCampoPesquisa.Texto Then
                    SqlText = SqlText & " WHERE " & sBancoDados_Campo_Codigo & " = " & sValor
                Else
                    SqlText = SqlText & " WHERE UPPER(" & sBancoDados_Campo_Codigo & ") = " & QuotedStr(sValor)
                End If
            Else
                SqlText = SqlText & " WHERE (UPPER(" & sBancoDados_Campo_Descricao & ") LIKE " & SQL_FormatarLike(sValor)

                If oBancoDados_Campo_Codigo_Tipo = TipoCampoPesquisa.Texto Then
                    SqlText = SqlText & " OR UPPER(" & sBancoDados_Campo_Codigo & ") LIKE " & SQL_FormatarLike(sValor)
                Else
                    If EhNumero(sValor) Then
                        SqlText = SqlText & " OR " & sBancoDados_Campo_Codigo & " = " & sValor
                    Else
                        SqlText = SqlText & " OR UPPER(" & sBancoDados_Campo_Codigo & ") LIKE " & SQL_FormatarLike(sValor)
                    End If
                End If

                SqlText = SqlText & ")"
            End If
        Else
            If oBancoDados_Campo_TipoPesquisa = TipoCampoPesquisa.SemDefinicao Then
                If EhNumero(sValor) Then
                    oPesquisa = TipoCampoPesquisa.Numero
                Else
                    oPesquisa = TipoCampoPesquisa.Texto
                End If
            Else
                oPesquisa = oBancoDados_Campo_TipoPesquisa
            End If

            Select Case oPesquisa
                Case TipoCampoPesquisa.Numero
                    SqlText = SqlText & " WHERE " & sBancoDados_Campo_Pesquisa & " = " & sValor
                Case TipoCampoPesquisa.Texto
                    SqlText = SqlText & " WHERE UPPER(TRIM(" & sBancoDados_Campo_Pesquisa & ")) = " & _
                                        QuotedStr(UCase(Trim(sValor)))
            End Select
        End If

        bTelaFiltro = False

        SqlText = SqlText & Montar_Filtro(oBancoDados_Filtro)

        SqlText = SqlText & " ORDER BY " & sBancoDados_Campo_Descricao & ", " & sBancoDados_Campo_Codigo

        oData = DBQuery(SqlText)

        bValidado = True

        If objDataTable_Vazio(oData) Then
            Msg_Mensagem("A pesquisa não retornou nenhum registro.")

            If Codigo Then
                lCodigo = ""
                sDescricao = ""
                lblMostrar.Tag = Nothing
                TratarAlteracaoRegistro()
            End If

            txtPesquisar.Text = ""
            txtPesquisar.Focus()
        Else
            ModoEdicao = False

            Select Case oData.Rows.Count
                Case Is = 1
                    lCodigo = oData.Rows(0).Item(sBancoDados_Campo_Codigo)
                    sDescricao = Trim(oData.Rows(0).Item(sBancoDados_Campo_Descricao))

                    If bExibirCodigo Then
                        lblMostrar.Text = Trim(lCodigo) & " - " & Trim(sDescricao)
                    Else
                        lblMostrar.Text = Trim(sDescricao)
                    End If

                    If Collection_Preenchido(oBancoDados_Campo_Adicional) Then
                        lblMostrar.Tag = objData_ParaArray(oData, 0, New Integer() {2})
                    End If

                    lblMostrar.Select(1, 0)
                    TratarAlteracaoRegistro()
                Case Is > 50
                    Msg_Mensagem("Sua consulta retornou mais de 50 registros. Altere o parâmetro de consulta e tente novamente!")
                Case Is > 1
                    oMenu = New System.Windows.Forms.ContextMenuStrip

                    For iCont = 0 To oData.Rows.Count - 1
                        With oData.Rows(iCont)
                            If bExibirCodigo Then
                                oMenuItem = oMenu.Items.Add(Trim(.Item(0)) & " - " & Trim(.Item(1)))
                            Else
                                oMenuItem = oMenu.Items.Add(Trim(.Item(1)))
                            End If

                            oMenuItem.Tag = Lista_Para_Array(.Item(0))
                        End With

                        If Collection_Preenchido(oBancoDados_Campo_Adicional) Then
                            ArrayO_Add(oMenuItem.Tag, objData_ParaArray(oData, iCont, New Integer() {2}))
                        End If
                    Next

                    oMenu.Show(Me.PointToScreen(New Point(lblMostrar.Location.X, lblMostrar.Location.Y)))
            End Select
        End If

        bProcInterno = False
    End Sub

    Private Sub oMenu_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles oMenu.ItemClicked
        Dim sAux As String

        sAux = Trim(e.ClickedItem.Text)

        lCodigo = ""
        sDescricao = ""
        lblMostrar.Text = ""

        lCodigo = e.ClickedItem.Tag(0)

        If UBound(e.ClickedItem.Tag) > 0 Then
            lblMostrar.Tag = e.ClickedItem.Tag(1)
        End If

        If InStr(sAux, "-") > 0 And bExibirCodigo Then
            sDescricao = Trim(Microsoft.VisualBasic.Mid(sAux, InStr(sAux, "-") + 1))
        Else
            sDescricao = sAux
        End If

        If Trim(lCodigo) <> "" And bExibirCodigo Then
            lblMostrar.Text = Trim(lCodigo) & " - "
        End If

        lblMostrar.Text = lblMostrar.Text + sDescricao
        lblMostrar.Select(1, 0)
        oMenu.Items.Clear()
        oMenu.Dispose()
        oMenu = Nothing

        TratarAlteracaoRegistro()
    End Sub

    Private Sub lblMostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblMostrar.Click
        ModoEdicao = True
    End Sub

    Private Sub cmdFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFiltro.Click
        Pesq_CodigNome_FormPesquisa(Me, oTPPesquisa, oBancoDados_Filtro, sBancoDados_Campo_Codigo2)
    End Sub

    Private Sub lblMostrar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblMostrar.TextChanged
        ToolTip.SetToolTip(lblMostrar, lblMostrar.Text)
        ToolTip.SetToolTip(txtPesquisar, lblMostrar.Text)
        ToolTip.SetToolTip(Me, lblMostrar.Text)
    End Sub

    Private Sub TratarAlteracaoRegistro()
        RaiseEvent AlterouRegistro()
    End Sub

    Private Sub Pesquisa_AdicionarFiltro()
        Select Case oTPPesquisa
            Case TPPesquisa.Pq_Logus_ContratoPAF_Fornecedor
                If Trim(sBancoDados_Campo_Codigo2) <> "" Then
                    BancoDados_Filtro_Adicionar("CD_FORNECEDOR = " & sBancoDados_Campo_Codigo2)
                End If
        End Select
    End Sub

    Public Property Ativo() As Boolean
        Get
            Return txtPesquisar.Enabled
        End Get
        Set(ByVal Valor As Boolean)
            txtPesquisar.Enabled = Valor
            cmdFiltro.Enabled = Valor
        End Set
    End Property
End Class