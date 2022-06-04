Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaFornecedor
    Const cnt_GridGeral_RazaoSocial As Integer = 0
    Const cnt_GridGeral_TipoPessoa As Integer = 1
    Const cnt_GridGeral_NomeFantasia As Integer = 2
    Const cnt_GridGeral_Repassador As Integer = 3
    Const cnt_GridGeral_Endereco As Integer = 4
    Const cnt_GridGeral_Bairro As Integer = 5
    Const cnt_GridGeral_Cidade As Integer = 6
    Const cnt_GridGeral_CEP As Integer = 7
    Const cnt_GridGeral_Contato As Integer = 8
    Const cnt_GridGeral_Telefone As Integer = 9
    Const cnt_GridGeral_Fax As Integer = 10
    Const cnt_GridGeral_Celular As Integer = 11
    Const cnt_GridGeral_Pessoa As Integer = 12
    Const cnt_GridGeral_ListaNegra As Integer = 13
    Const cnt_GridGeral_SacariaAcordo As Integer = 14
    Const cnt_GridGeral_CNPJ_CPF As Integer = 15
    Const cnt_GridGeral_InscricaoEstadual As Integer = 16
    Const cnt_GridGeral_Funrural As Integer = 17
    Const cnt_GridGeral_Favorecido As Integer = 18
    Const cnt_GridGeral_ContaCorrente As Integer = 19
    Const cnt_GridGeral_Agencia As Integer = 20
    Const cnt_GridGeral_Banco As Integer = 21
    Const cnt_GridGeral_FilialOrigem As Integer = 22
    Const cnt_GridGeral_Codigo As Integer = 23
    Const cnt_GridGeral_AddressNumber As Integer = 24
    Const cnt_GridGeral_Profissao As Integer = 25
    Const cnt_GridGeral_Conjuge As Integer = 26
    Const cnt_GridGeral_Email As Integer = 27
    Const cnt_GridGeral_DataNascimento As Integer = 28
    Const cnt_GridGeral_CaixaPostal As Integer = 29
    Const cnt_GridGeral_EstabelecidoDesde As Integer = 30
    Const cnt_GridGeral_OutrasAtividades As Integer = 31
    Const cnt_GridGeral_NivelLiquidez As Integer = 32
    Const cnt_GridGeral_TipoPessoaTributacao As Integer = 33
    Const cnt_GridGeral_Ativo As Integer = 34
    Const cnt_GridGeral_IC_FISICA_JURIDICA As Integer = 35
    Const cnt_GridGeral_DataCriacao As Integer = 36
    Const cnt_GridGeral_UsuarioCriacao As Integer = 37
    Const cnt_GridGeral_DataAlteracao As Integer = 38
    Const cnt_GridGeral_UsuarioAlteracao As Integer = 39
    Const cnt_GridGeral_CD_FILIAL_ORIGEM As Integer = 40

    Const cnt_SEC_Tela As String = "Cadastro_Fornecedor"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmConsultaFornecedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_Close(Me)
    End Sub

    Private Sub frmConsultaFornecedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.CellSelect, False, False, True, , , , True)
        objGrid_Coluna_Add(grdGeral, "Razao Social", 180)
        objGrid_Coluna_Add(grdGeral, "Tipo Pessoa", 120)
        objGrid_Coluna_Add(grdGeral, "Nome Fantasia", 150)
        objGrid_Coluna_Add(grdGeral, "Repassador", 180)
        objGrid_Coluna_Add(grdGeral, "Endereço", 180)
        objGrid_Coluna_Add(grdGeral, "Bairro", 100)
        objGrid_Coluna_Add(grdGeral, "Cidade", 100)
        objGrid_Coluna_Add(grdGeral, "CEP", 80)
        objGrid_Coluna_Add(grdGeral, "Contato", 150)
        objGrid_Coluna_Add(grdGeral, "Telefone", 100)
        objGrid_Coluna_Add(grdGeral, "Fax", 100)
        objGrid_Coluna_Add(grdGeral, "Celular", 100)
        objGrid_Coluna_Add(grdGeral, "Pessoa", 100)
        objGrid_Coluna_Add(grdGeral, "Lista Negra", 100)
        objGrid_Coluna_Add(grdGeral, "Sacaria Acordo", 100)
        objGrid_Coluna_Add(grdGeral, "CNPJ\CPF", 100)
        objGrid_Coluna_Add(grdGeral, "Inscrição Estadual", 100)
        objGrid_Coluna_Add(grdGeral, "Funrural", 100)
        objGrid_Coluna_Add(grdGeral, "Favorecido", 150)
        objGrid_Coluna_Add(grdGeral, "Conta Corrente", 100)
        objGrid_Coluna_Add(grdGeral, "Agência", 100)
        objGrid_Coluna_Add(grdGeral, "Banco", 100)
        objGrid_Coluna_Add(grdGeral, "Filial Origem", 100)
        objGrid_Coluna_Add(grdGeral, "Código", 80)
        objGrid_Coluna_Add(grdGeral, "Address Number", 100)
        objGrid_Coluna_Add(grdGeral, "Profissão", 100)
        objGrid_Coluna_Add(grdGeral, "Cônjuge", 140)
        objGrid_Coluna_Add(grdGeral, "E-mail", 120)
        objGrid_Coluna_Add(grdGeral, "Data Nascimento", 100)
        objGrid_Coluna_Add(grdGeral, "Caixa Postal", 100)
        objGrid_Coluna_Add(grdGeral, "Estabelecido Desde", 100)
        objGrid_Coluna_Add(grdGeral, "Outras Atividades", 120)
        objGrid_Coluna_Add(grdGeral, "Nível Liquidez", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo Pessoa Tributacao", 100)
        objGrid_Coluna_Add(grdGeral, "Ativo", 80)
        objGrid_Coluna_Add(grdGeral, "IC_FISICA_JURIDICA", 0)
        objGrid_Coluna_Add(grdGeral, "Data Criação", 120, , , , , cnt_Formato_DataHora)
        objGrid_Coluna_Add(grdGeral, "Usuário Criação", 130)
        objGrid_Coluna_Add(grdGeral, "Data Alteração", 120, , , , , cnt_Formato_DataHora)
        objGrid_Coluna_Add(grdGeral, "Usuário Alteração", 130)
        objGrid_Coluna_Add(grdGeral, "CD_FILIAL_ORIGEM", 0)

        Form_Carrega_Grid(Me)

        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdAlterar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao(cmdListaNegra, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        If Not CampoNulo(txtCNPJ.Value) Then
            If Not Valida_CNPJ(SoNumero(txtCNPJ.Text)) Then
                Msg_Mensagem("Informe o número de C.N.P.J. válido")
                Exit Sub
            End If
        End If
        If Not CampoNulo(txtCPF.Value) Then
            If Not Valida_CPF(SoNumero(txtCPF.Value)) Then
                Msg_Mensagem("Informe o número de C.P.F. válido")
                Exit Sub
            End If
        End If

        SqlText = "SELECT F.NO_RAZAO_SOCIAL," & _
                         "TP.NO_TIPO_PESSOA," & _
                         "F.NO_FANTASIA," & _
                         "REP.NO_RAZAO_SOCIAL NO_REPASSADOR," & _
                         "F.DS_ENDERECO," & _
                         "F.NO_BAIRRO," & _
                         "TRIM(M.NO_CIDADE) || ' - ' || M.CD_UF AS CIDADE," & _
                         "F.NU_CEP," & _
                         "F.NO_CONTATO," & _
                         "F.NU_TEL," & _
                         "F.NU_FAX," & _
                         "F.NU_CELULAR," & _
                         "DECODE(F.IC_FISICA_JURIDICA, 'F', 'Física', 'J', 'Jurídica') DS_FISICA_JURIDICA," & _
                         "DECODE(F.IC_LISTA_NEGRA, 'S', 'Sim', 'Não') IC_LISTA_NEGRA," & _
                         "DECODE(F.IC_SACARIA_ACORDADA, 'S', 'Sim', 'Não') IC_SACARIA_ACORDADA," & _
                         "F.NU_CGC_CPF," & _
                         "F.NU_INSC_ESTADUAL," & _
                         "FUN.NO_FUNRURAL," & _
                         "F.NO_FAVORECIDO_CHEQUE," & _
                         "F.NU_CONTA_CORRENTE," & _
                         "F.NU_AGENCIA," & _
                         "F.NO_BANCO," & _
                         "FIL.NO_FILIAL," & _
                         "F.CD_FORNECEDOR," & _
                         "F.CD_ADDRESS_NUMBER," & _
                         "F.NO_PROFISSAO," & _
                         "F.NO_CONJUGE," & _
                         "F.DS_EMAIL," & _
                         "F.DT_NASCIMENTO," & _
                         "F.NU_CAIXA_POSTAL," & _
                         "F.QT_TEMPO_ESTABELECIDO," & _
                         "F.DS_OUTRA_ATIVIDADE," & _
                         "F.DS_NIVEL_LIQUIDEZ," & _
                         "TPT.NO_TIPO_PESSOA_TRIBUTACAO," & _
                         "DECODE(F.IC_ATIVO, 'S', 'Sim', 'N', 'Não') IC_SACARIA_ACORDADA," & _
                         "F.IC_FISICA_JURIDICA," & _
                         "F.DT_CRIACAO," & _
                         "F.NO_USER_CRIACAO," & _
                         "F.DT_ALTERACAO," & _
                         "F.NO_USER_ALTERACAO," & _
                         "F.CD_FILIAL_ORIGEM" & _
                  " FROM SOF.FORNECEDOR F," & _
                        "SOF.TIPO_PESSOA TP," & _
                        "SOF.MUNICIPIO M," & _
                        "SOF.UF U," & _
                        "SOF.FUNRURAL FUN," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.FORNECEDOR REP," & _
                        "SOF.TIPO_PESSOA_TRIBUTACAO TPT" & _
                  " WHERE F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA" & _
                    " AND F.CD_MUNICIPIO = M.CD_MUNICIPIO" & _
                    " AND U.CD_UF = M.CD_UF" & _
                    " AND F.CD_REPASSADOR = REP.CD_FORNECEDOR(+)" & _
                    " AND F.CD_FUNRURAL = FUN.CD_FUNRURAL" & _
                    " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND TPT.CD_TIPO_PESSOA_TRIBUTACAO (+) = F.CD_TIPO_PESSOA_TRIBUTACAO"

        If Trim(txtRazaoSocial.Text) <> "" Then
            SqlText = SqlText & " AND UPPER(F.NO_RAZAO_SOCIAL) LIKE " & SQL_FormatarLike(txtRazaoSocial.Text)
        End If
        If Trim(txtNomeFantasia.Text) <> "" Then
            SqlText = SqlText & " AND UPPER(F.NO_FANTASIA) LIKE " & SQL_FormatarLike(txtNomeFantasia.Text)
        End If
        If Not CampoNulo(txtCNPJ.Value) Then
            SqlText = SqlText & " AND F.NU_CGC_CPF = " & QuotedStr(txtCNPJ.Value)
        End If
        If Not CampoNulo(txtCPF.Value) Then
            SqlText = SqlText & " AND F.NU_CGC_CPF = " & QuotedStr(txtCPF.Value)
        End If
        If NVL(txtAddressNumber.Value, 0) > 0 Then
            SqlText = SqlText & " AND F.CD_ADDRESS_NUMBER = " & txtAddressNumber.Value
        End If
        If NVL(txtCodigo.Value, 0) > 0 Then
            SqlText = SqlText & " AND F.CD_FORNECEDOR = " & txtCodigo.Value
        End If
        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_VisualizarCadastroFornecedorOutraFilial) Then
                SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If
        End If

        SqlText = SqlText & " ORDER BY F.NO_RAZAO_SOCIAL"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_RazaoSocial, _
                                                           cnt_GridGeral_TipoPessoa, _
                                                           cnt_GridGeral_NomeFantasia, _
                                                           cnt_GridGeral_Repassador, _
                                                           cnt_GridGeral_Endereco, _
                                                           cnt_GridGeral_Bairro, _
                                                           cnt_GridGeral_Cidade, _
                                                           cnt_GridGeral_CEP, _
                                                           cnt_GridGeral_Contato, _
                                                           cnt_GridGeral_Telefone, _
                                                           cnt_GridGeral_Fax, _
                                                           cnt_GridGeral_Celular, _
                                                           cnt_GridGeral_Pessoa, _
                                                           cnt_GridGeral_ListaNegra, _
                                                           cnt_GridGeral_SacariaAcordo, _
                                                           cnt_GridGeral_CNPJ_CPF, _
                                                           cnt_GridGeral_InscricaoEstadual, _
                                                           cnt_GridGeral_Funrural, _
                                                           cnt_GridGeral_Favorecido, _
                                                           cnt_GridGeral_ContaCorrente, _
                                                           cnt_GridGeral_Agencia, _
                                                           cnt_GridGeral_Banco, _
                                                           cnt_GridGeral_FilialOrigem, _
                                                           cnt_GridGeral_Codigo, _
                                                           cnt_GridGeral_AddressNumber, _
                                                           cnt_GridGeral_Profissao, _
                                                           cnt_GridGeral_Conjuge, _
                                                           cnt_GridGeral_Email, _
                                                           cnt_GridGeral_DataNascimento, _
                                                           cnt_GridGeral_CaixaPostal, _
                                                           cnt_GridGeral_EstabelecidoDesde, _
                                                           cnt_GridGeral_OutrasAtividades, _
                                                           cnt_GridGeral_NivelLiquidez, _
                                                           cnt_GridGeral_TipoPessoaTributacao, _
                                                           cnt_GridGeral_Ativo, _
                                                           cnt_GridGeral_IC_FISICA_JURIDICA, _
                                                           cnt_GridGeral_DataCriacao, _
                                                           cnt_GridGeral_UsuarioCriacao, _
                                                           cnt_GridGeral_DataAlteracao, _
                                                           cnt_GridGeral_UsuarioAlteracao, _
                                                           cnt_GridGeral_CD_FILIAL_ORIGEM})

        Fornecedor_GridIdentificar(grdGeral, cnt_GridGeral_Ativo, cnt_GridGeral_ListaNegra)
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub frmConsultaFornecedor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdNovo.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdAlterar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdListaNegra.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdAgregados.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFicha_Cadastral.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "FORNECEDOR", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim sMens As String

        If grdGeral.DisplayLayout.ActiveRow Is Nothing Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If InStr(ListarIDFiliaisLiberadaUsuario(), objGrid_Valor(grdGeral, cnt_GridGeral_CD_FILIAL_ORIGEM)) = 0 Then
            Msg_Mensagem("Esse fornecedor é de uma filial que o seu usuário não tem acesso," & _
                         " por esse motivo você não poderá fazer proceder com a exclusão do mesmo")
            Exit Sub
        End If

        sMens = "Deseja excluir o fornecedor " & objGrid_Valor(grdGeral, cnt_GridGeral_RazaoSocial) & "?"

        If Msg_Perguntar(sMens) Then
            DBUsarTransacao = True

            If Not ValidacaoExclusao("CONTRATO_PAF", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Contrato PAF cadastrado para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("CONFISSAO_DIVIDA", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Confissão de Dívida cadastrada para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("MOVIMENTACAO", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Movimentação cadastrada para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("LIMITE_CREDITO", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Limite de Crédito cadastrado para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("CONCILIACAO", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Conciliação cadastrada para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("GARANTIA_FORNECEDOR", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Garantia cadastrado para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("PAGAMENTOS", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Pagamento cadastrado para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("ORDEM_DESCARGA", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Ordem de Descarga cadastrado para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("SACARIA_FORNECEDOR", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Posição de Sacaria cadastrada para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("RECEPCAO_NOTAS", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Notas Recepcionadas para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("ATENDIMENTO", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Atendimento cadastrado para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("CATEGORIA_FORNECEDOR", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Categoria cadastrada para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("CONTRATO", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Contrato cadastrado para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("LAUDO_TECNICO", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Laudo Técnico cadastrado para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("NOTA_REMESSA", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Nota de Remessa cadastrada para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("SACARIA_FORNECEDOR_ACORDO", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Acordo de Sacaria cadastrado para esse Fornecedor") Then Exit Sub
            If Not ValidacaoExclusao("SACARIA_REQUISICAO", "CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                                     "Existe Requisição de Sacaria cadastrada para esse Fornecedor") Then Exit Sub

            If Not DBExecutar_Delete("SOF.FORNECEDOR_PROCURACAO", "CD_FORNECEDOR", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro
            If Not DBExecutar_Delete("SOF.FORNECEDOR_REFERENCIA_BANCO", "CD_FORNECEDOR", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro
            If Not DBExecutar_Delete("SOF.FORNECEDOR_CONTROLADOR", "CD_FORNECEDOR", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro
            If Not DBExecutar_Delete("SOF.FORNECEDOR_COLIGADAS", "CD_FORNECEDOR", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro
            If Not DBExecutar_Delete("SOF.FORNECEDOR_OBS", "CD_FORNECEDOR", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro
            If Not DBExecutar_Delete("SOF.FAZENDA", "CD_FORNECEDOR", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro
            If Not DBExecutar_Delete("SOF.FORNECEDOR", "CD_FORNECEDOR", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro

            If Not DBExecutarTransacao() Then GoTo Erro
        End If

        ExecutaConsulta()

Erro:
        TratarErro()
    End Sub

    Private Sub cmdListaNegra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListaNegra.Click
        If grdGeral.DisplayLayout.ActiveRow Is Nothing Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If InStr(ListarIDFiliaisLiberadaUsuario(), objGrid_Valor(grdGeral, cnt_GridGeral_CD_FILIAL_ORIGEM)) = 0 Then
            Msg_Mensagem("Esse fornecedor é de uma filial que o seu usuário não tem acesso," & _
                         " por esse motivo você não poderá fazer atualizações das informações cadastrais do mesmo")
            Exit Sub
        End If
        If objGrid_Valor_SN(grdGeral, cnt_GridGeral_ListaNegra) Then
            If Msg_Perguntar("Deseja retirar este fornecedor da Lista Negra ?") = False Then Exit Sub

            DBExecutar("UPDATE SOF.FORNECEDOR SET IC_LISTA_NEGRA = 'N' " & _
                       " WHERE CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
        Else
            If Msg_Perguntar("Deseja colocar este fornecedor na Lista Negra?") = False Then Exit Sub

            DBExecutar("UPDATE SOF.FORNECEDOR SET IC_LISTA_NEGRA = 'S' " & _
                       " WHERE CD_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
        End If

        ExecutaConsulta()
    End Sub

    Private Sub cmdAgregados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregados.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Historico_Fornecedor(Tipo_Historico_Fornecedor.HFConsultaAgregados, _
                             objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), _
                             objGrid_Valor(grdGeral, cnt_GridGeral_RazaoSocial))

        Filtro = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
        Form_Carregar_Consulta_Geral(Me.MdiParent, frmConsultaGeral.eConsultaGeral.AgregadosFornecedor)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Form_Show(Me.MdiParent, frmCadastroFornecedor)
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Selecione um registro")
            Exit Sub
        End If

        Dim oForm As New frmCadastroFornecedor

        oForm.CD_FORNECEDOR = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

        Form_Show(Me.MdiParent, oForm)
    End Sub

    Private Sub cmdFichaCadastral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFicha_Cadastral.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmRelatorioGeral

        oForm.Filtro01 = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

        If objGrid_Valor(grdGeral, cnt_GridGeral_IC_FISICA_JURIDICA) = "F" Then
            oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eFichaCadastral_Fisica
        Else
            oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eFichaCadastral_Juridica
        End If

        Form_Show(Me.MdiParent, oForm)
    End Sub
End Class