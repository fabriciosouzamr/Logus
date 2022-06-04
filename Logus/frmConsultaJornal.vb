Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaJornal
    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_Filial As Integer = 2
    Const cnt_GridGeral_Usuario As Integer = 3
    Const cnt_GridGeral_Assunto As Integer = 4
    Const cnt_GridGeral_CD_USER As Integer = 5

    Const cnt_SEC_Tela As String = "Transacao_Jornal"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Dim CD_TIPO_JORNAL As Integer

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub frmConsultaJornal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CD_TIPO_JORNAL = Filtro

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, , , , , True)

        objGrid_Coluna_Add(grdGeral, "Código", 0)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Filial", 100)
        objGrid_Coluna_Add(grdGeral, "Nome Usuário", 130)
        objGrid_Coluna_Add(grdGeral, "Assunto", 350)
        objGrid_Coluna_Add(grdGeral, "CD_USER", 0)

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdAlterar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT   J.SQ_JORNAL, J.DT_JORNAL, FIL.NO_FILIAL, U.NO_USUARIO, J.DS_ASSUNTO, J.CD_USER "
        SqlText = SqlText & "    FROM SOF.JORNAL J, SOF.FILIAL FIL, SOF.USUARIO U "
        SqlText = SqlText & "   WHERE J.CD_FILIAL = FIL.CD_FILIAL "
        SqlText = SqlText & "     AND J.CD_USER = U.CD_USER "
        SqlText = SqlText & "     AND J.CD_TIPO_JORNAL = " & CD_TIPO_JORNAL

        If Trim(txtAssunto.Text) <> "" Then
            SqlText = SqlText & " AND UPPER(J.DS_ASSUNTO) LIKE '%" & UCase(txtAssunto.Text) & "%'"
        End If
        If Trim(txtMensagem.Text) <> "" Then
            SqlText = SqlText & " AND UPPER(J.DS_JORNAL) LIKE '%" & UCase(txtMensagem.Text) & "%'"
        End If
        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(J.DT_JORNAL) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(J.DT_JORNAL) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        SqlText = SqlText & " ORDER BY J.DT_JORNAL DESC "

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, _
                                                            cnt_GridGeral_Data, _
                                                            cnt_GridGeral_Filial, _
                                                            cnt_GridGeral_Usuario, _
                                                            cnt_GridGeral_Assunto, _
                                                            cnt_GridGeral_CD_USER})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "JORNAL", "SQ_JORNAL = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If CDate(objGrid_Valor(grdGeral, cnt_GridGeral_Data)) < CDate(DataSistema()) Then
            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AlterarExcluirJornalDataAnteriorAtual) Then
                Msg_Mensagem("Não é permitido excluir um jornal com a data menor que a data atual")
                Exit Sub
            End If
        Else
            If objGrid_Valor(grdGeral, cnt_GridGeral_CD_USER) <> sAcesso_UsuarioLogado Then
                Msg_Mensagem("Não é permitido excluir um jornal criado por outro usuário")
                Exit Sub
            End If
        End If

        If Not DBExecutar_Delete("SOF.JORNAL", "SQ_JORNAL", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        If CDate(objGrid_Valor(grdGeral, cnt_GridGeral_Data)) < CDate(DataSistema()) Then
            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AlterarExcluirJornalDataAnteriorAtual) Then
                Msg_Mensagem("Não é permitido alterar um jornal com a data menor que a data atual")
                Exit Sub
            End If
        Else
            If objGrid_Valor(grdGeral, cnt_GridGeral_CD_USER) <> sAcesso_UsuarioLogado Then
                Msg_Mensagem("Não é permitido alterar um jornal criado por outro usuário")
                Exit Sub
            End If
        End If

        Dim oForm As New frmCadastroJornal

        oForm.Carregar(frmCadastroJornal.enTipoUtilizacaoTela.eAlteracaoJornal, objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), CD_TIPO_JORNAL)
        Form_Show(Me.MdiParent, oForm)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Dim oForm As New frmCadastroJornal

        oForm.Carregar(frmCadastroJornal.enTipoUtilizacaoTela.eCriacaoJornal, Nothing, CD_TIPO_JORNAL)
        Form_Show(Me.MdiParent, oForm, , True)
    End Sub

    Private Sub cmdVisualizaJornal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizaJornal.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        Dim oForm As New frmCadastroJornal

        oForm.Carregar(frmCadastroJornal.enTipoUtilizacaoTela.eVisualizacaoJornal, objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), CD_TIPO_JORNAL)
        Form_Show(Me.MdiParent, oForm)
    End Sub

    Private Sub frmConsultaJornal_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdNovo.Top = Me.ClientSize.Height - cmdNovo.Height - 6
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdUsuario.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcluir.Height - 6
        cmdAlterar.Top = Me.ClientSize.Height - cmdAlterar.Height - 6
        cmdVisualizaJornal.Top = Me.ClientSize.Height - cmdVisualizaJornal.Height - 6
    End Sub
End Class