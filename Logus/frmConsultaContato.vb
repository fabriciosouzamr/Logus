Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaContato
    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_Usuario As Integer = 2
    Const cnt_GridGeral_Fornecedor As Integer = 3
    Const cnt_GridGeral_Tipo As Integer = 4
    Const cnt_GridGeral_Assunto As Integer = 5
    Const cnt_GridGeral_Descricao As Integer = 6
    Const cnt_GridGeral_CD_User As Integer = 7

    Const cnt_SEC_Tela As String = "Transacao_Contato"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmConsultaContato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_CodigoNome.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True, , , , True)

        objGrid_Coluna_Add(grdGeral, "Código", 0)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Usuário", 160)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 180)
        objGrid_Coluna_Add(grdGeral, "Tipo", 120)
        objGrid_Coluna_Add(grdGeral, "Assunto", 180, , , , , , DefaultableBoolean.True)
        objGrid_Coluna_Add(grdGeral, "Descrição", 300, , , , , , DefaultableBoolean.True)
        objGrid_Coluna_Add(grdGeral, "CD_USER", 0)

        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao(cmdAlterar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        If Not Data_ValidarPeriodo("contato", txtDataInicial.Value, txtDataFinal.Value, False) Then Exit Sub

        SqlText = "SELECT A.SQ_ATENDIMENTO, A.DT_ATENDIMENTO, U.NO_USUARIO, F.NO_RAZAO_SOCIAL, "
        SqlText = SqlText & "       TA.NO_TIPO_ATENDIMENTO, A.DS_ASSUNTO, A.DS_ATENDIMENTO, U.CD_USER"
        SqlText = SqlText & "  FROM SOF.ATENDIMENTO A, "
        SqlText = SqlText & "       SOF.FILIAL FIL, "
        SqlText = SqlText & "       SOF.FORNECEDOR F, "
        SqlText = SqlText & "       SOF.TIPO_ATENDIMENTO TA, "
        SqlText = SqlText & "       SOF.USUARIO U "
        SqlText = SqlText & " WHERE A.CD_FILIAL = FIL.CD_FILIAL "
        SqlText = SqlText & "   AND A.CD_FORNECEDOR = F.CD_FORNECEDOR "
        SqlText = SqlText & "   AND A.CD_TIPO_ATENDIMENTO = TA.CD_TIPO_ATENDIMENTO "
        SqlText = SqlText & "   AND A.CD_USER = U.CD_USER "

        If Trim(txtAssunto.Text) <> "" Then
            SqlText = SqlText & " AND UPPER(A.DS_ASSUNTO) LIKE '%" & UCase(txtAssunto.Text) & "%'"
        End If
        If Trim(txtMensagem.Text) <> "" Then
            SqlText = SqlText & " AND UPPER(A.DS_ATENDIMENTO) LIKE '%" & UCase(txtMensagem.Text) & "%'"
        End If
        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC( A.DT_ATENDIMENTO ) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC( A.DT_ATENDIMENTO ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If
        If Pesq_CodigoNome.Codigo > 0 Then
            SqlText = SqlText & " AND A.CD_FORNECEDOR = " & Pesq_CodigoNome.Codigo
        End If
        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND A.CD_FILIAL IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            SqlText = SqlText & " AND A.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, _
                                                           cnt_GridGeral_Data, _
                                                           cnt_GridGeral_Usuario, _
                                                           cnt_GridGeral_Fornecedor, _
                                                           cnt_GridGeral_Tipo, _
                                                           cnt_GridGeral_Assunto, _
                                                           cnt_GridGeral_Descricao, _
                                                           cnt_GridGeral_CD_User}, False, True)
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "ATENDIMENTO", "SQ_ATENDIMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub frmConsultaContato_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        ControleEdicaoTela = eControleEdicaoTela.INCLUIR
        Filtro = Nothing
        Form_Show(Me.MdiParent, frmCadastroContato, , True)
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        If CDate(objGrid_Valor(grdGeral, cnt_GridGeral_Data)) < Now Then
            If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AlterarExcluirContatosDataAnteriorAtual) Then
                If Not Msg_Perguntar("Você está tentando alterar um contato de uma data anterior a data atual. Deseja prosseguir?") Then
                    If objGrid_Valor(grdGeral, cnt_GridGeral_CD_User) <> sAcesso_UsuarioLogado Then
                        Msg_Mensagem("Não é permitido alterar um contato criado por outro usuário")
                        Exit Sub
                    End If
                End If
            Else
                Msg_Mensagem("Não é permitido alterar um contato de uma data anterior a data atual")
                Exit Sub
            End If
        End If

        ControleEdicaoTela = eControleEdicaoTela.ALTERAR
        Filtro = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
        Form_Show(Me.MdiParent, frmCadastroContato)
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim bExcluir As Boolean

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If CDate(objGrid_Valor(grdGeral, cnt_GridGeral_Data)) < CDate(DataSistema()) Then
            If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AlterarExcluirContatosDataAnteriorAtual) Then
                bExcluir = Msg_Perguntar("Você está tentando excluir um contato de uma data anterior a data atual. Deseja prosseguir?")
            Else
                Msg_Mensagem("Não é permitido excluir um contato de uma data anterior a data atual")
                Exit Sub
            End If
        Else
            If objGrid_Valor(grdGeral, cnt_GridGeral_CD_User) <> sAcesso_UsuarioLogado Then
                Msg_Mensagem("Não é permitido excluir um contato criado por outro usuário")
                Exit Sub
            Else
                bExcluir = Msg_Perguntar("Deseja excluir o Contato?")
            End If
        End If

        If bExcluir Then
            If Not DBExecutar_Delete("SOF.ATENDIMENTO", "SQ_ATENDIMENTO", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro
        End If

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub
End Class