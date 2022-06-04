Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaInovacao
    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_Usuario As Integer = 2
    Const cnt_GridGeral_Tipo As Integer = 3
    Const cnt_GridGeral_Assunto As Integer = 4
    Const cnt_GridGeral_Descricao As Integer = 5
    Const cnt_GridGeral_CD_USER As Integer = 6

    Const cnt_SEC_Tela As String = "Transacao_Inovacao"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmConsultaInovacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Tipo_Inovacao(cboTipoInovacao, True)
        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True, , , , True)

        objGrid_Coluna_Add(grdGeral, "Código", 0)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Nome Usuário", 130)
        objGrid_Coluna_Add(grdGeral, "Tipo", 100)
        objGrid_Coluna_Add(grdGeral, "Assunto", 180, , , , , , DefaultableBoolean.True)
        objGrid_Coluna_Add(grdGeral, "Descrição", 300, , , , , , DefaultableBoolean.True)
        objGrid_Coluna_Add(grdGeral, "USER", 0)

        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdAlterar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        If Not Data_ValidarPeriodo("data de inovação", txtDataInicial.Text, txtDataFinal.Text, False) Then Exit Sub

        SqlText = "SELECT A.SQ_INOVACAO, A.DT_INOVACAO, U.NO_USUARIO, TA.NO_TIPO_INOVACAO, "
        SqlText = SqlText & "       A.DS_ASSUNTO, A.DS_INOVACAO, A.CD_USER "
        SqlText = SqlText & "  FROM SOF.INOVACAO A, SOF.FILIAL FIL, SOF.TIPO_INOVACAO TA, SOF.USUARIO U "
        SqlText = SqlText & " WHERE A.CD_FILIAL = FIL.CD_FILIAL "
        SqlText = SqlText & "   AND A.CD_TIPO_INOVACAO = TA.CD_TIPO_INOVACAO "
        SqlText = SqlText & "   AND A.CD_USER = U.CD_USER "

        If Trim(txtAssunto.Text) <> "" Then
            SqlText = SqlText & " AND UPPER(A.DS_ASSUNTO) LIKE '%" & UCase(txtAssunto.Text) & "%'"
        End If
        If Trim(txtMensagem.Text) <> "" Then
            SqlText = SqlText & " AND UPPER(A.DS_INOVACAO) LIKE '%" & UCase(txtMensagem.Text) & "%'"
        End If
        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(A.DT_INOVACAO) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(A.DT_INOVACAO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If
        If ComboBox_LinhaSelecionada(cboTipoInovacao) Then
            SqlText = SqlText & " AND A.CD_TIPO_INOVACAO = " & cboTipoInovacao.SelectedValue
        End If
        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND A.CD_FILIAL IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            SqlText = SqlText & " AND A.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & " ORDER BY A.SQ_INOVACAO DESC "

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, cnt_GridGeral_Data, cnt_GridGeral_Usuario, _
                                                           cnt_GridGeral_Tipo, cnt_GridGeral_Assunto, cnt_GridGeral_Descricao, _
                                                           cnt_GridGeral_CD_USER}, , True)
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim sMens As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If CDate(objGrid_Valor(grdGeral, cnt_GridGeral_Data)) < CDate(DataSistema()) Then
            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AlterarInovacaoDataAnteriorAtual) Then
                Msg_Mensagem("Não é permitido excluir inovação com a data menor que a data atual")
                Exit Sub
            End If
        Else
            If objGrid_Valor(grdGeral, cnt_GridGeral_CD_USER) <> sAcesso_UsuarioLogado Then
                Msg_Mensagem("Não é permitido excluir inovação criada por outro usuário")
                Exit Sub
            End If
        End If

        sMens = "Deseja excluir esta inovação?"

        If Msg_Perguntar(sMens) Then
            If Not DBExecutar_Delete("SOF.INOVACAO", "SQ_INOVACAO", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo ERRO
        End If

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "INOVACAO", "SQ_INOVACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If
        If CDate(objGrid_Valor(grdGeral, cnt_GridGeral_Data)) < CDate(DataSistema()) Then
            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AlterarInovacaoDataAnteriorAtual) Then
                Msg_Mensagem("Não é permitido alterar inovação com a data menor que a data atual")
                Exit Sub
            End If
        Else
            If objGrid_Valor(grdGeral, cnt_GridGeral_CD_USER) <> sAcesso_UsuarioLogado Then
                Msg_Mensagem("Não é permitido alterar inovação criada por outro usuário")
                Exit Sub
            End If
        End If

        ControleEdicaoTela = eControleEdicaoTela.ALTERAR
        Filtro = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
        Form_Show(Me.MdiParent, frmCadastroInovacao)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        ControleEdicaoTela = eControleEdicaoTela.INCLUIR
        Filtro = Nothing
        Form_Show(Me.MdiParent, frmCadastroInovacao)
    End Sub

    Private Sub frmConsultaInovacao_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
End Class