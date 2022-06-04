Public Class frmCadastroTipoPagamento
    Const cnt_SEC_Tela As String = "Cadastro_Administrativo_TipoPagamento"

    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim CdTipoPagamento As Integer

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmCadastroTipoPagamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_OperacaoBancaria.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_OperacaoBancaria
        ComboBox_Carregar_Forma_Pagamento(cboFormaPagamento, True)

        ControleEdicaoTelaLocal = ControleEdicaoTela
        CdTipoPagamento = Filtro
        chkFormaPagamento_CheckedChanged(Nothing, Nothing)

        cmdGravar.Visible = SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao) Or _
                            SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao)

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            CarregarDados()
        Else
            chkAtivo.Checked = True
        End If
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "select * from sof.tipo_pagamento where cd_tipo_pagamento=" & CdTipoPagamento
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            lblCodigo.Text = oData.Rows(0).Item("cd_tipo_pagamento")
            txtDescricao.Text = oData.Rows(0).Item("no_tipo_pagamento")
            Pesq_OperacaoBancaria.Codigo = oData.Rows(0).Item("cd_operacao_bancaria")
            chkAtivo.Checked = IIf(oData.Rows(0).Item("IC_ATIVO") = "S", True, False)
            chkICMS.Checked = IIf(oData.Rows(0).Item("ic_pagamento_icms") = "S", True, False)
            chkJuros.Checked = IIf(oData.Rows(0).Item("IC_CALCULA_JUROS") = "S", True, False)
            chkFormaPagamento.Checked = IIf(oData.Rows(0).Item("IC_FORMA_PAGAMENTO_FIXO") = "S", True, False)
            chkFormaPagamento_CheckedChanged(Nothing, Nothing)
            If chkFormaPagamento.Checked = True Then
                ComboBox_Possicionar(cboFormaPagamento, oData.Rows(0).Item("CD_FORMA_PAGAMENTO"))
            End If
        End If
    End Sub

    Private Sub chkFormaPagamento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFormaPagamento.CheckedChanged
        If chkFormaPagamento.Checked = True Then
            cboFormaPagamento.Enabled = True
        Else
            ComboBox_Possicionar(cboFormaPagamento, -1)
            cboFormaPagamento.Enabled = False
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(7) As DBParamentro

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar o nome do Tipo de pagamento.")
            txtDescricao.Focus()
            Exit Sub
        End If
        If Pesq_OperacaoBancaria.Codigo = 0 Then
            Msg_Mensagem("Favor escolher um tipo de operação bancaria valida.")
            Pesq_OperacaoBancaria.Focus()
            Exit Sub
        End If
        If chkFormaPagamento.Checked = True Then
            If Not ComboBox_LinhaSelecionada(cboFormaPagamento) Then
                Msg_Mensagem("Favor selecionar uma forma de pagamento.")
                cboFormaPagamento.Focus()
                Exit Sub
            End If
        End If
        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar o nome do tipo de RD.")
            txtDescricao.Focus()
            Exit Sub
        End If

        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            CdTipoPagamento = DBNumeroMaisUm("SOF.TIPO_PAGAMENTO", "CD_TIPO_PAGAMENTO")

            SqlText = DBMontar_Insert("SOF.TIPO_PAGAMENTO", TipoCampoFixo.Todos, "NO_TIPO_PAGAMENTO", ":NO_TIPO_PAGAMENTO", _
                                                                           "CD_OPERACAO_BANCARIA", ":CD_OPERACAO_BANCARIA", _
                                                                           "IC_PAGAMENTO_ICMS", ":IC_PAGAMENTO_ICMS", _
                                                                           "IC_CALCULA_JUROS", ":IC_CALCULA_JUROS", _
                                                                           "IC_FORMA_PAGAMENTO_FIXO", ":IC_FORMA_PAGAMENTO_FIXO", _
                                                                           "CD_FORMA_PAGAMENTO", ":CD_FORMA_PAGAMENTO", _
                                                                           "IC_ATIVO", ":IC_ATIVO", _
                                                                           "CD_TIPO_PAGAMENTO", ":CD_TIPO_PAGAMENTO")
        Else
            SqlText = DBMontar_Update("SOF.TIPO_PAGAMENTO", GerarArray("NO_TIPO_PAGAMENTO", ":NO_TIPO_PAGAMENTO", _
                                                                           "CD_OPERACAO_BANCARIA", ":CD_OPERACAO_BANCARIA", _
                                                                           "IC_PAGAMENTO_ICMS", ":IC_PAGAMENTO_ICMS", _
                                                                           "IC_CALCULA_JUROS", ":IC_CALCULA_JUROS", _
                                                                           "IC_FORMA_PAGAMENTO_FIXO", ":IC_FORMA_PAGAMENTO_FIXO", _
                                                                           "CD_FORMA_PAGAMENTO", ":CD_FORMA_PAGAMENTO", _
                                                                           "IC_ATIVO", ":IC_ATIVO"), _
                                                      GerarArray("CD_TIPO_PAGAMENTO", ":CD_TIPO_PAGAMENTO"))
        End If

        Parametro(0) = DBParametro_Montar("NO_TIPO_PAGAMENTO", txtDescricao.Text)
        Parametro(1) = DBParametro_Montar("CD_OPERACAO_BANCARIA", Pesq_OperacaoBancaria.Codigo)
        Parametro(2) = DBParametro_Montar("IC_PAGAMENTO_ICMS", IIf(chkICMS.Checked, "S", "N"))
        Parametro(3) = DBParametro_Montar("IC_CALCULA_JUROS", IIf(chkJuros.Checked, "S", "N"))
        Parametro(4) = DBParametro_Montar("IC_FORMA_PAGAMENTO_FIXO", IIf(chkFormaPagamento.Checked, "S", "N"))
        If chkFormaPagamento.Checked = True Then
            Parametro(5) = DBParametro_Montar("CD_FORMA_PAGAMENTO", cboFormaPagamento.SelectedValue)
        Else
            Parametro(5) = DBParametro_Montar("CD_FORMA_PAGAMENTO", Nothing)
        End If
        Parametro(6) = DBParametro_Montar("IC_ATIVO", IIf(chkAtivo.Checked, "S", "N"))
        Parametro(7) = DBParametro_Montar("CD_TIPO_PAGAMENTO", CdTipoPagamento)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        Close()

        Exit Sub
Erro:
        TratarErro()
    End Sub
End Class