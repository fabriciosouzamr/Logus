Public Class frmCadastroOperBancariaTpMovimentacao
    Const cnt_SEC_Tela As String = "Cadastro_Contabil_OperacaoBancariaTipoMovimentacao"

    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim CdParametroOperTpMov As Integer

    Private Sub frmCadastroOperBancariaTpMovimentacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_TipoMovimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TipoMovimentacao.BancoDados_Filtro_Limpar()
        Pesq_TipoMovimentacao.BancoDados_Filtro_Adicionar("IC_ATIVO = 'S'")
        Pesq_OperacaoBancaria.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_OperacaoBancaria

        ControleEdicaoTelaLocal = ControleEdicaoTela
        CdParametroOperTpMov = Filtro

        cmdGravar.Visible = SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao) Or _
                            SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao)

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            CarregarDados()
        End If
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * FROM SOF.PARAMETRO_OPERACAO_TP_MOV WHERE CD_PARAMETRO_OPERACAO_TP_MOV=" & CdParametroOperTpMov
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            lblCodigo.Text = oData.Rows(0).Item("CD_PARAMETRO_OPERACAO_TP_MOV")
            txtDescricao.Text = oData.Rows(0).Item("NO_PARAMETRO_OPERACAO_TP_MOV")
            Pesq_TipoMovimentacao.Codigo = oData.Rows(0).Item("CD_TIPO_MOVIMENTACAO")
            Pesq_OperacaoBancaria.Codigo = oData.Rows(0).Item("CD_OPERACAO_BANCARIA")
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(3) As DBParamentro

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar uma descrição.")
            txtDescricao.Focus()
            Exit Sub
        End If
        If Pesq_OperacaoBancaria.Codigo < 1 Then
            Msg_Mensagem("Favor informar uma operação bancaria valida.")
            Pesq_OperacaoBancaria.Focus()
            Exit Sub
        End If
        If Pesq_TipoMovimentacao.Codigo < 1 Then
            Msg_Mensagem("Favor informar um tipo de movimentação valido.")
            Pesq_TipoMovimentacao.Focus()
            Exit Sub
        End If

        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            CdParametroOperTpMov = DBNumeroMaisUm("SOF.PARAMETRO_OPERACAO_TP_MOV", "CD_PARAMETRO_OPERACAO_TP_MOV")

            SqlText = DBMontar_Insert("SOF.PARAMETRO_OPERACAO_TP_MOV", TipoCampoFixo.Todos, "NO_PARAMETRO_OPERACAO_TP_MOV", ":NO_PARAMETRO_OPERACAO_TP_MOV", _
                                                                           "CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO", _
                                                                           "CD_OPERACAO_BANCARIA", ":CD_OPERACAO_BANCARIA", _
                                                                           "CD_PARAMETRO_OPERACAO_TP_MOV", ":CD_PARAMETRO_OPERACAO_TP_MOV")
        Else
            SqlText = DBMontar_Update("SOF.PARAMETRO_OPERACAO_TP_MOV", GerarArray("NO_PARAMETRO_OPERACAO_TP_MOV", ":NO_PARAMETRO_OPERACAO_TP_MOV", _
                                                                 "CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO", _
                                                                 "CD_OPERACAO_BANCARIA", ":CD_OPERACAO_BANCARIA"), _
                                                      GerarArray("CD_PARAMETRO_OPERACAO_TP_MOV", ":CD_PARAMETRO_OPERACAO_TP_MOV"))
        End If

        Parametro(0) = DBParametro_Montar("NO_PARAMETRO_OPERACAO_TP_MOV", txtDescricao.Text)
        Parametro(1) = DBParametro_Montar("CD_TIPO_MOVIMENTACAO", Pesq_TipoMovimentacao.Codigo)
        Parametro(2) = DBParametro_Montar("CD_OPERACAO_BANCARIA", Pesq_OperacaoBancaria.Codigo)
        Parametro(3) = DBParametro_Montar("CD_PARAMETRO_OPERACAO_TP_MOV", CdParametroOperTpMov)


        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        Close()

        Exit Sub
Erro:
        TratarErro()
    End Sub
End Class