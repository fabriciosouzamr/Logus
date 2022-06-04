Public Class frmCadastroModalidadeConciliacao
    Const cnt_SEC_Tela As String = "Cadastro_Contabil_ModalidadeConciliacao"

    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim CdConciliacaoModalidade As Integer

    Private Sub frmCadastroModalidadeConciliacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_TipoMovimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TipoMovimentacao.BancoDados_Filtro_Limpar()
        Pesq_TipoMovimentacao.BancoDados_Filtro_Adicionar("IC_ATIVO = 'S'")

        ComboBox_Carregar_Filial(cboFilial, True)

        ControleEdicaoTelaLocal = ControleEdicaoTela
        CdConciliacaoModalidade = Filtro

        cmdGravar.Visible = SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao) Or _
                            SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao)

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            CarregarDados()
        Else
            chkMovimentacao_CheckedChanged(Nothing, Nothing)
            chkPagamento_CheckedChanged(Nothing, Nothing)
            chkLancaRD_CheckedChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "select * from sof.conciliacao_modalidade where cd_conciliacao_modalidade=" & CdConciliacaoModalidade
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            lblCodigo.Text = oData.Rows(0).Item("cd_conciliacao_modalidade")
            txtDescricao.Text = oData.Rows(0).Item("no_conciliacao_modalidade")
            chkPagamento.Checked = IIf(oData.Rows(0).Item("ic_contabiliza_aplicacao_pag") = "S", 1, 0)
            chkPagamentoCredito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDA_FILIAL_PAG_CREDITO"), "N")) = "S", 1, 0)
            chkPagamentoDebito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDA_FILIAL_PAG_DEBITO"), "N")) = "S", 1, 0)
            chkPagamento_CheckedChanged(Nothing, Nothing)
            txtPagamentoCredito.Text = "" & oData.Rows(0).Item("nu_cc_pagamento_credito")
            txtPagamentoDebito.Text = "" & oData.Rows(0).Item("nu_cc_pagamento_debito")
            chkMovimentacao.Checked = IIf(oData.Rows(0).Item("ic_contabiliza_aplicacao_mov") = "S", 1, 0)
            chkMovimentacaoCredito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDA_FILIAL_REC_CREDITO"), "N")) = "S", 1, 0)
            chkMovimentacaoDebito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDA_FILIAL_REC_DEBITO"), "N")) = "S", 1, 0)
            chkMovimentacao_CheckedChanged(Nothing, Nothing)
            txtMovimentacaoCredito.Text = "" & oData.Rows(0).Item("nu_cc_movimentacao_credito")
            txtMovimentacaoDebito.Text = "" & oData.Rows(0).Item("nu_cc_movimentacao_debito")
            chkLancaRD.Checked = IIf(oData.Rows(0).Item("ic_lanca_rd") = "S", 1, 0)
            chkAtivo.Checked = IIf(oData.Rows(0).Item("ic_ativo") = "S", 1, 0)

            chkValorBruto.Checked = IIf(oData.Rows(0).Item("IC_CONTABILIZA_BRUTO") = "S", 1, 0)
            If oData.Rows(0).Item("ic_filial_movimentacao") = "S" Then
                optTipoFilial.Value = "M"
            End If
            If oData.Rows(0).Item("ic_filial_fixa") = "S" Then
                optTipoFilial.Value = "F"
            End If
            If oData.Rows(0).Item("ic_filial_conciliacao") = "S" Then
                optTipoFilial.Value = "C"
            End If
            If Not objDataTable_CampoVazio(oData.Rows(0).Item("cd_filial_fixa")) Then
                ComboBox_Possicionar(cboFilial, oData.Rows(0).Item("cd_filial_fixa"))
            End If
            If Not objDataTable_CampoVazio(oData.Rows(0).Item("cd_tipo_movimentacao")) Then
                Pesq_TipoMovimentacao.Codigo = oData.Rows(0).Item("cd_tipo_movimentacao")
            End If
        End If
    End Sub


    Private Sub chkLancaRD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLancaRD.CheckedChanged
        If chkLancaRD.Checked = True Then
            grdLancaRD.Enabled = True
        Else
            grdLancaRD.Enabled = False
            Pesq_TipoMovimentacao.Codigo = 0
            optTipoFilial.Value = Nothing
            ComboBox_Possicionar(cboFilial, -1)
        End If
    End Sub

    Private Sub chkPagamento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPagamento.CheckedChanged
        If chkPagamento.Checked = True Then
            grpPagamento.Enabled = True
        Else
            grpPagamento.Enabled = False
            txtPagamentoCredito.Text = ""
            txtPagamentoDebito.Text = ""
            Me.chkPagamentoCredito.Checked = False
            Me.chkPagamentoDebito.Checked = False
        End If
    End Sub

    Private Sub chkMovimentacao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMovimentacao.CheckedChanged
        If chkMovimentacao.Checked = True Then
            grpMovimentacao.Enabled = True
            chkLancaRD.Enabled = True
            chkValorBruto.Enabled = True
        Else
            grpMovimentacao.Enabled = False
            txtMovimentacaoCredito.Text = ""
            txtMovimentacaoDebito.Text = ""
            chkLancaRD.Checked = False
            chkLancaRD_CheckedChanged(Nothing, Nothing)
            chkLancaRD.Enabled = False
            Me.chkMovimentacaoCredito.Checked = False
            Me.chkMovimentacaoDebito.Checked = False
            chkValorBruto.Enabled = False
            chkValorBruto.Checked = False
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(19) As DBParamentro

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar uma descrição.")
            txtDescricao.Focus()
            Exit Sub
        End If

        If chkPagamento.Checked = True Then
            If txtPagamentoCredito.Text = "" Then
                Msg_Mensagem("Favor informar a conta correte para o pagamento do credito.")
                txtPagamentoCredito.Focus()
                Exit Sub
            End If
            If txtPagamentoDebito.Text = "" Then
                Msg_Mensagem("Favor informar a conta correte para o debito do pagamento.")
                txtPagamentoDebito.Focus()
                Exit Sub
            End If
        End If
        If chkMovimentacao.Checked = True Then
            If txtMovimentacaoCredito.Text = "" Then
                Msg_Mensagem("Favor informar a conta correte para a movimentação do credito.")
                txtMovimentacaoCredito.Focus()
                Exit Sub
            End If
            If txtMovimentacaoDebito.Text = "" Then
                Msg_Mensagem("Favor informar a conta correte para o debito da movimentação.")
                txtMovimentacaoDebito.Focus()
                Exit Sub
            End If
        End If

        If chkLancaRD.Checked = True Then
            If Pesq_TipoMovimentacao.Codigo = 0 Then
                Msg_Mensagem("Favor escolher um tipo de movimentação valida.")
                Pesq_TipoMovimentacao.Focus()
                Exit Sub
            End If
            If optTipoFilial.Value = Nothing Then
                Msg_Mensagem("Favor selecionar o tipo filial.")
                Exit Sub
            Else
                If optTipoFilial.Value = "F" And Not ComboBox_LinhaSelecionada(cboFilial) Then
                    Msg_Mensagem("Favor informar a filial fixa.")
                    cboFilial.Focus()
                    Exit Sub
                End If
            End If
        End If


        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            CdConciliacaoModalidade = DBNumeroMaisUm("SOF.CONCILIACAO_MODALIDADE", "CD_CONCILIACAO_MODALIDADE")

            SqlText = DBMontar_Insert("SOF.CONCILIACAO_MODALIDADE", TipoCampoFixo.Todos, "NO_CONCILIACAO_MODALIDADE", ":NO_CONCILIACAO_MODALIDADE", _
                                                                           "IC_CONTABILIZA_APLICACAO_PAG", ":IC_CONTABILIZA_APLICACAO_PAG", _
                                                                           "NU_CC_PAGAMENTO_CREDITO", ":NU_CC_PAGAMENTO_CREDITO", _
                                                                           "NU_CC_PAGAMENTO_DEBITO", ":NU_CC_PAGAMENTO_DEBITO", _
                                                                           "IC_CONTABILIZA_APLICACAO_MOV", ":IC_CONTABILIZA_APLICACAO_MOV", _
                                                                           "NU_CC_MOVIMENTACAO_CREDITO", ":NU_CC_MOVIMENTACAO_CREDITO", _
                                                                           "NU_CC_MOVIMENTACAO_DEBITO", ":NU_CC_MOVIMENTACAO_DEBITO", _
                                                                           "IC_LANCA_RD", ":IC_LANCA_RD", _
                                                                           "IC_FILIAL_MOVIMENTACAO", ":IC_FILIAL_MOVIMENTACAO", _
                                                                           "IC_FILIAL_FIXA", ":IC_FILIAL_FIXA", _
                                                                           "CD_FILIAL_FIXA", ":CD_FILIAL_FIXA", _
                                                                           "IC_FILIAL_CONCILIACAO", ":IC_FILIAL_CONCILIACAO", _
                                                                           "CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO", _
                                                                           "IC_MUDA_FILIAL_PAG_CREDITO", ":IC_MUDA_FILIAL_PAG_CREDITO", _
                                                                           "IC_MUDA_FILIAL_PAG_DEBITO", ":IC_MUDA_FILIAL_PAG_DEBITO", _
                                                                           "IC_MUDA_FILIAL_REC_CREDITO", ":IC_MUDA_FILIAL_REC_CREDITO", _
                                                                           "IC_MUDA_FILIAL_REC_DEBITO", ":IC_MUDA_FILIAL_REC_DEBITO", _
                                                                           "IC_CONTABILIZA_BRUTO", ":IC_CONTABILIZA_BRUTO", _
                                                                           "IC_ATIVO", ":IC_ATIVO", _
                                                                           "CD_CONCILIACAO_MODALIDADE", ":CD_CONCILIACAO_MODALIDADE")
        Else
            SqlText = DBMontar_Update("SOF.CONCILIACAO_MODALIDADE", GerarArray("NO_CONCILIACAO_MODALIDADE", ":NO_CONCILIACAO_MODALIDADE", _
                                                                           "IC_CONTABILIZA_APLICACAO_PAG", ":IC_CONTABILIZA_APLICACAO_PAG", _
                                                                           "NU_CC_PAGAMENTO_CREDITO", ":NU_CC_PAGAMENTO_CREDITO", _
                                                                           "NU_CC_PAGAMENTO_DEBITO", ":NU_CC_PAGAMENTO_DEBITO", _
                                                                           "IC_CONTABILIZA_APLICACAO_MOV", ":IC_CONTABILIZA_APLICACAO_MOV", _
                                                                           "NU_CC_MOVIMENTACAO_CREDITO", ":NU_CC_MOVIMENTACAO_CREDITO", _
                                                                           "NU_CC_MOVIMENTACAO_DEBITO", ":NU_CC_MOVIMENTACAO_DEBITO", _
                                                                           "IC_LANCA_RD", ":IC_LANCA_RD", _
                                                                           "IC_FILIAL_MOVIMENTACAO", ":IC_FILIAL_MOVIMENTACAO", _
                                                                           "IC_FILIAL_FIXA", ":IC_FILIAL_FIXA", _
                                                                           "CD_FILIAL_FIXA", ":CD_FILIAL_FIXA", _
                                                                           "IC_FILIAL_CONCILIACAO", ":IC_FILIAL_CONCILIACAO", _
                                                                           "CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO", _
                                                                           "IC_MUDA_FILIAL_PAG_CREDITO", ":IC_MUDA_FILIAL_PAG_CREDITO", _
                                                                           "IC_MUDA_FILIAL_PAG_DEBITO", ":IC_MUDA_FILIAL_PAG_DEBITO", _
                                                                           "IC_MUDA_FILIAL_REC_CREDITO", ":IC_MUDA_FILIAL_REC_CREDITO", _
                                                                           "IC_MUDA_FILIAL_REC_DEBITO", ":IC_MUDA_FILIAL_REC_DEBITO", _
                                                                            "IC_CONTABILIZA_BRUTO", ":IC_CONTABILIZA_BRUTO", _
                                                                            "IC_ATIVO", ":IC_ATIVO"), _
                                                      GerarArray("CD_CONCILIACAO_MODALIDADE", ":CD_CONCILIACAO_MODALIDADE"))
        End If

        Parametro(0) = DBParametro_Montar("NO_CONCILIACAO_MODALIDADE", txtDescricao.Text)
        Parametro(1) = DBParametro_Montar("IC_CONTABILIZA_APLICACAO_PAG", IIf(chkPagamento.Checked, "S", "N"))
        Parametro(2) = DBParametro_Montar("NU_CC_PAGAMENTO_CREDITO", txtPagamentoCredito.Text)
        Parametro(3) = DBParametro_Montar("NU_CC_PAGAMENTO_DEBITO", txtPagamentoDebito.Text)
        Parametro(4) = DBParametro_Montar("IC_CONTABILIZA_APLICACAO_MOV", IIf(chkMovimentacao.Checked, "S", "N"))
        Parametro(5) = DBParametro_Montar("NU_CC_MOVIMENTACAO_CREDITO", txtMovimentacaoCredito.Text)
        Parametro(6) = DBParametro_Montar("NU_CC_MOVIMENTACAO_DEBITO", txtMovimentacaoDebito.Text)
        Parametro(7) = DBParametro_Montar("IC_LANCA_RD", IIf(chkLancaRD.Checked, "S", "N"))
        Parametro(8) = DBParametro_Montar("IC_FILIAL_MOVIMENTACAO", IIf(optTipoFilial.Value = "M", "S", "N"))
        Parametro(9) = DBParametro_Montar("IC_FILIAL_FIXA", IIf(optTipoFilial.Value = "F", "S", "N"))
        If optTipoFilial.Value = "F" Then
            Parametro(10) = DBParametro_Montar("CD_FILIAL_FIXA", cboFilial.SelectedValue)
        Else
            Parametro(10) = DBParametro_Montar("CD_FILIAL_FIXA", Nothing)
        End If
        Parametro(11) = DBParametro_Montar("IC_FILIAL_CONCILIACAO", IIf(optTipoFilial.Value = "C", "S", "N"))
        If chkLancaRD.Checked Then
            Parametro(12) = DBParametro_Montar("CD_TIPO_MOVIMENTACAO", Pesq_TipoMovimentacao.Codigo)
        Else
            Parametro(12) = DBParametro_Montar("CD_TIPO_MOVIMENTACAO", Nothing)
        End If
        Parametro(13) = DBParametro_Montar("IC_MUDA_FILIAL_PAG_CREDITO", IIf(chkPagamentoCredito.Checked, "S", "N"))
        Parametro(14) = DBParametro_Montar("IC_MUDA_FILIAL_PAG_DEBITO", IIf(chkPagamentoDebito.Checked, "S", "N"))
        Parametro(15) = DBParametro_Montar("IC_MUDA_FILIAL_REC_CREDITO", IIf(chkMovimentacaoCredito.Checked, "S", "N"))
        Parametro(16) = DBParametro_Montar("IC_MUDA_FILIAL_REC_DEBITO", IIf(chkMovimentacaoDebito.Checked, "S", "N"))
        Parametro(17) = DBParametro_Montar("IC_CONTABILIZA_BRUTO", IIf(chkValorBruto.Checked, "S", "N"))
        Parametro(18) = DBParametro_Montar("IC_ATIVO", IIf(chkAtivo.Checked, "S", "N"))
        Parametro(19) = DBParametro_Montar("CD_CONCILIACAO_MODALIDADE", CdConciliacaoModalidade)



        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        Close()

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
End Class