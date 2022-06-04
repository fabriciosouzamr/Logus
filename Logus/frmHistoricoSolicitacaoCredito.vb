Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmHistoricoSolicitacaoCredito
    Const cnt_GridGeral_Data As Integer = 0
    Const cnt_GridGeral_Usuario As Integer = 1
    Const cnt_GridGeral_Assunto As Integer = 2
    Const cnt_GridGeral_Descricao As Integer = 3

    Const cnt_SEC_Tela As String = "Transacao_SolicitacaoCredito_Historico"

    Dim SqLimiteCredito As Integer
    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String

        If txtAssunto.Text = "" Then
            Msg_Mensagem("Favor infromar um assunto.")
            txtAssunto.Focus()
            Exit Sub
        End If

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar o comentario.")
            txtDescricao.Focus()
            Exit Sub
        End If

        SqlText = DBMontar_SP("SOF.SP_CREDITO_AVISO", False, ":SQLIMITE", _
                                                                   ":AVISO", _
                                                                   ":COMENTARIO")

        If Not DBExecutar(SqlText, DBParametro_Montar("SQLIMITE", SqLimiteCredito), _
                                   DBParametro_Montar("AVISO", txtAssunto.Text, OracleClient.OracleType.VarChar, , 4000), _
                                   DBParametro_Montar("COMENTARIO", txtDescricao.Text, OracleClient.OracleType.VarChar, , 4000)) Then GoTo Erro


        ExecutaConsulta()
        txtAssunto.Text = ""
        txtDescricao.Text = ""
        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub frmHistoricoSolicitacaoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SqLimiteCredito = Filtro

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdGeral, "Data", 100, , , , , cnt_Formato_DataHoraCurta)
        objGrid_Coluna_Add(grdGeral, "Usuário", 120)
        objGrid_Coluna_Add(grdGeral, "Assunto", 180, , , , , , DefaultableBoolean.True)
        objGrid_Coluna_Add(grdGeral, "Descrição", 250, , , , , , DefaultableBoolean.True)

        SEC_ValidarBotao(cmdGravar, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)

        ExecutaConsulta()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT   lc.dt_historico, u.no_usuario, lc.ds_historico, lc.ds_obs "
        SqlText = SqlText & "    FROM sof.usuario u, sof.limite_credito_historico lc "
        SqlText = SqlText & "   WHERE lc.cd_user = u.cd_user AND lc.sq_limite_credito = " & SqLimiteCredito
        SqlText = SqlText & "ORDER BY lc.dt_historico ASC "


        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Data, _
                                                            cnt_GridGeral_Usuario, _
                                                            cnt_GridGeral_Assunto, _
                                                            cnt_GridGeral_Descricao}, , True)
    End Sub

    Private Sub frmHistoricoSolicitacaoCredito_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
    End Sub
End Class