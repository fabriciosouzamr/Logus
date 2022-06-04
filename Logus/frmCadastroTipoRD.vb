Public Class frmCadastroTipoRD
    Const cnt_SEC_Tela As String = "Cadastro_Administrativo_TipoRD"

    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim CdTipoRD As Integer

    Private Sub frmCadastroTipoRD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_TipoMovimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TipoMovimentacao.BancoDados_Filtro_Limpar()
        Pesq_TipoMovimentacao.BancoDados_Filtro_Adicionar("IC_ATIVO = 'S'")

        ControleEdicaoTelaLocal = ControleEdicaoTela
        CdTipoRD = Filtro

        cmdGravar.Visible = SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao) Or _
                            SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao)

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            CarregarDados()
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * FROM SOF.TIPO_RD WHERE CD_TIPO_RD = " & CdTipoRD
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            lblCodigo.Text = oData.Rows(0).Item("CD_TIPO_RD")
            txtDescricao.Text = oData.Rows(0).Item("NO_TIPO_RD")
            Pesq_TipoMovimentacao.Codigo = oData.Rows(0).Item("CD_TP_MOV_SALDO_FINAL")
            chkAtivo.Checked = IIf(oData.Rows(0).Item("IC_ATIVO") = "S", True, False)
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(3) As DBParamentro

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar o nome do tipo de RD.")
            txtDescricao.Focus()
            Exit Sub
        End If
        If Pesq_TipoMovimentacao.Codigo = 0 Then
            Msg_Mensagem("Favor escolher um tipo de movimentação valida.")
            Pesq_TipoMovimentacao.Focus()
            Exit Sub
        End If


        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            CdTipoRD = DBNumeroMaisUm("SOF.TIPO_RD", "CD_TIPO_RD")

            SqlText = DBMontar_Insert("SOF.TIPO_RD", TipoCampoFixo.Todos, "IC_ATIVO", ":IC_ATIVO", _
                                                                           "NO_TIPO_RD", ":NO_TIPO_RD", _
                                                                           "CD_TP_MOV_SALDO_FINAL", ":CD_TP_MOV_SALDO_FINAL", _
                                                                           "CD_TIPO_RD", ":CD_TIPO_RD")
        Else
            SqlText = DBMontar_Update("SOF.TIPO_RD", GerarArray("IC_ATIVO", ":IC_ATIVO", _
                                                                 "NO_TIPO_RD", ":NO_TIPO_RD", _
                                                                 "CD_TP_MOV_SALDO_FINAL", ":CD_TP_MOV_SALDO_FINAL"), _
                                                      GerarArray("CD_TIPO_RD", ":CD_TIPO_RD"))
        End If

        Parametro(0) = DBParametro_Montar("IC_ATIVO", IIf(chkAtivo.Checked, "S", "N"))
        Parametro(1) = DBParametro_Montar("NO_TIPO_RD", txtDescricao.Text)
        Parametro(2) = DBParametro_Montar("CD_TP_MOV_SALDO_FINAL", Pesq_TipoMovimentacao.Codigo)
        Parametro(3) = DBParametro_Montar("CD_TIPO_RD", CdTipoRD)


        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        Close()

        Exit Sub
Erro:
        TratarErro()
    End Sub
End Class