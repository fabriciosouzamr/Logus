Public Class frmParametroRecuperacaoCredito
    Const cnt_SEC_Tela As String = "Cadastro_Contabil_ModalidadeRecuperacaoCredito"

    Dim CdModalidadeRecuperacao As Integer

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmParametroRecuperacaoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CdModalidadeRecuperacao = Filtro
        ComboBox_Carregar_Modalidade_Conciliacao(cboModalidadeConciliacao, True)
        ComboBox_Carregar_Forma_Pagamento(cboFormaPagamento, True)
        ComboBox_Carregar_Tipo_Pagamento(cboTipoPagamento, True)

        Dim SqlText As String
        SqlText = "SELECT cdm.no_confissao_divida_modalidade "
        SqlText = SqlText & "  FROM sof.confissao_divida_modalidade cdm "
        SqlText = SqlText & " WHERE cdm.cd_confissao_divida_modalidade =  " & CdModalidadeRecuperacao

        txtModalidadeRecuperacao.Text = DBQuery_ValorUnico(SqlText)

        cmdGravar.Visible = SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao) Or _
                            SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao)

        CarregarDados()
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * FROM SOF.CONFISSAO_DIVIDA_PARAMETRO WHERE CD_CONFISSAO_DIVIDA_MODALIDADE=" & CdModalidadeRecuperacao

        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            ComboBox_Possicionar(cboTipoPagamento, CLng(NVL(oData.Rows(0).Item("CD_TIPO_PAGAMENTO"), -1)))
            ComboBox_Possicionar(cboFormaPagamento, CLng(NVL(oData.Rows(0).Item("CD_FORMA_PAGAMENTO"), -1)))
            ComboBox_Possicionar(cboModalidadeConciliacao, CLng(NVL(oData.Rows(0).Item("CD_CONCILIACAO_MODALIDADE_PAG"), -1)))

            txtVendaMoedaCredito.Text = "" & oData.Rows(0).Item("nu_cc_venda_moeda_credito")
            txtVendaMoedaDebito.Text = "" & oData.Rows(0).Item("nu_cc_venda_moeda_debito")
            txtVendaOutrosCredito.Text = "" & oData.Rows(0).Item("nu_cc_venda_outros_credito")
            txtVendaOutrosDebito.Text = "" & oData.Rows(0).Item("nu_cc_venda_outros_debito")
            txtRecebimentoOutrosCredito.Text = "" & oData.Rows(0).Item("NU_CC_RECEB_OUTROS_CREDITO")
            txtRecebimentoOutrosDebito.Text = "" & oData.Rows(0).Item("NU_CC_RECEB_OUTROS_DEBITO")
            txtRecebimentoMoedaCredito.Text = "" & oData.Rows(0).Item("NU_CC_RECEB_MOEDA_CREDITO")
            txtRecebimentoMoedaDebito.Text = "" & oData.Rows(0).Item("NU_CC_RECEB_MOEDA_DEBITO")
            txtFechamentoPerdasCredito.Text = "" & oData.Rows(0).Item("NU_CC_FECHAMENTO_CREDITO")
            txtFechamentoPerdasDebito.Text = "" & oData.Rows(0).Item("NU_CC_FECHAMENTO_DEBITO")
            txtFechamentoLucroCredito.Text = "" & oData.Rows(0).Item("NU_CC_FECHAMENTO_CREDITO_LUCRO")
            txtFechamentoLucroDebito.Text = "" & oData.Rows(0).Item("NU_CC_FECHAMENTO_DEBITO_LUCRO")
            txtJurosCredito.Text = "" & oData.Rows(0).Item("nu_cc_juros_credito")
            txtJurosDebito.Text = "" & oData.Rows(0).Item("nu_cc_juros_debito")


            chkVendasMoeda.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_CONTABILIZA_VENDA_MOEDA"), "N")) = "N", False, True)
            chkVendasMoeda_CheckedChanged(Nothing, Nothing)
            chkRecebimentoOutros.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_CONTABILIZA_RECEB_OUTROS"), "N")) = "N", False, True)
            chkRecebimentoOutros_CheckedChanged(Nothing, Nothing)
            chkRecebimentoMoeda.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_CONTABILIZA_RECEB_MOEDA"), "N")) = "N", False, True)
            chkRecebimentoMoeda_CheckedChanged(Nothing, Nothing)
            chkVendaOutros.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_CONTABILIZA_VENDA_OUTROS"), "N")) = "N", False, True)
            chkVendaOutros_CheckedChanged(Nothing, Nothing)

            chkVendaMoedaCredito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDAFIL_VENDA_MOEDA_CREDITO"), "N")) = "N", False, True)
            chkVendaMoedaDebito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDAFIL_VENDA_MOEDA_DEBITO"), "N")) = "N", False, True)
            chkVendaOutrosCredito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDAFIL_VENDA_OUTROS_CREDIT"), "N")) = "N", False, True)
            chkVendaOutrosDebito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDAFIL_VENDA_OUTROS_DEBITO"), "N")) = "N", False, True)
            chkRecebimentoMoedaCredito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDAFIL_RECEB_MOEDA_CREDITO"), "N")) = "N", False, True)
            chkRecebimentoMoedaDebito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDAFIL_RECEB_MOEDA_DEBITO"), "N")) = "N", False, True)
            chkRecebimentoOutrosCredito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDAFIL_RECEB_OUTROS_CREDIT"), "N")) = "N", False, True)
            chkRecebimentoOutrosDebito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDAFIL_RECEB_OUTROS_DEBITO"), "N")) = "N", False, True)
            chkFechamentoPerdasCredito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDAFIL_FECHAMENTO_CREDITO"), "N")) = "N", False, True)
            chkFechamentoPerdasDebito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDAFIL_FECHAMENTO_DEBITO"), "N")) = "N", False, True)
            chkFechamentoLucroCredito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDAFIL_FECHA_CREDITO_LUCRO"), "N")) = "N", False, True)
            chkFechamentoLucroDebito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_MUDAFIL_FECHA_DEBITO_LUCRO"), "N")) = "N", False, True)

            chkJurosCredito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("ic_mudafil_juros_credito"), "N")) = "N", False, True)
            chkJurosDebito.Checked = IIf(CStr(NVL(oData.Rows(0).Item("ic_mudafil_juros_debito"), "N")) = "N", False, True)
        End If
    End Sub

    Private Sub chkVendasMoeda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVendasMoeda.CheckedChanged
        If chkVendasMoeda.Checked = True Then
            grpVendaMoeda.Enabled = True
        Else
            grpVendaMoeda.Enabled = False
            txtVendaMoedaCredito.Text = ""
            txtVendaMoedaDebito.Text = ""
            chkVendaMoedaCredito.Checked = False
            chkVendaMoedaDebito.Checked = False
        End If
    End Sub

    Private Sub chkVendaOutros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVendaOutros.CheckedChanged
        If chkVendaOutros.Checked = True Then
            grpVendaOutros.Enabled = True
        Else
            grpVendaOutros.Enabled = False
            txtVendaOutrosCredito.Text = ""
            txtVendaOutrosDebito.Text = ""
            chkVendaOutrosCredito.Checked = False
            chkVendaOutrosDebito.Checked = False
        End If
    End Sub

    Private Sub chkRecebimentoOutros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecebimentoOutros.CheckedChanged
        If chkRecebimentoOutros.Checked = True Then
            grpRecebimentoOutros.Enabled = True
        Else
            grpRecebimentoOutros.Enabled = False
            txtRecebimentoOutrosCredito.Text = ""
            txtRecebimentoOutrosDebito.Text = ""
            chkRecebimentoOutrosCredito.Checked = False
            chkRecebimentoOutrosDebito.Checked = False
        End If
    End Sub

    Private Sub chkRecebimentoMoeda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecebimentoMoeda.CheckedChanged
        If chkRecebimentoMoeda.Checked = True Then
            grpRecebimentoMoeda.Enabled = True
        Else
            grpRecebimentoMoeda.Enabled = False
            txtRecebimentoMoedaCredito.Text = ""
            txtRecebimentoMoedaDebito.Text = ""
            chkRecebimentoMoedaCredito.Checked = False
            chkRecebimentoMoedaDebito.Checked = False
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(35) As DBParamentro

        If Not ComboBox_LinhaSelecionada(cboModalidadeConciliacao) Then
            Msg_Mensagem("Favor selecionar uma modalidade de conciliacção.")
            cboModalidadeConciliacao.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboTipoPagamento) Then
            Msg_Mensagem("Favor selecionar um tipo de pagamento.")
            cboTipoPagamento.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboFormaPagamento) Then
            Msg_Mensagem("Favor selecionar uma forma de pagamento.")
            cboFormaPagamento.Focus()
            Exit Sub
        End If

        If DBQuery_ValorUnico("SELECT COUNT (*) FROM SOF.CONFISSAO_DIVIDA_MODALIDADE WHERE CD_CONFISSAO_DIVIDA_MODALIDADE = " & CdModalidadeRecuperacao) = 0 Then
            SqlText = DBMontar_Insert("SOF.confissao_divida_parametro", TipoCampoFixo.Nenhum, "CD_CONCILIACAO_MODALIDADE_PAG", ":CD_CONCILIACAO_MODALIDADE_PAG", _
                                                "NU_CC_VENDA_MOEDA_CREDITO", ":NU_CC_VENDA_MOEDA_CREDITO", _
                                                "NU_CC_VENDA_MOEDA_DEBITO", ":NU_CC_VENDA_MOEDA_DEBITO", _
                                                "NU_CC_VENDA_OUTROS_CREDITO", ":NU_CC_VENDA_OUTROS_CREDITO", _
                                                "NU_CC_VENDA_OUTROS_DEBITO", ":NU_CC_VENDA_OUTROS_DEBITO", _
                                                "NU_CC_RECEB_OUTROS_CREDITO", ":NU_CC_RECEB_OUTROS_CREDITO", _
                                                "NU_CC_RECEB_OUTROS_DEBITO", ":NU_CC_RECEB_OUTROS_DEBITO", _
                                                "NU_CC_FECHAMENTO_CREDITO", ":NU_CC_FECHAMENTO_CREDITO", _
                                                "NU_CC_FECHAMENTO_DEBITO", ":NU_CC_FECHAMENTO_DEBITO", _
                                                "CD_TIPO_PAGAMENTO", ":CD_TIPO_PAGAMENTO", _
                                                "CD_FORMA_PAGAMENTO", ":CD_FORMA_PAGAMENTO", _
                                                "IC_CONTABILIZA_VENDA_MOEDA", ":IC_CONTABILIZA_VENDA_MOEDA", _
                                                "IC_MUDAFIL_VENDA_MOEDA_CREDITO", ":IC_MUDAFIL_VENDA_MOEDA_CREDITO", _
                                                "IC_MUDAFIL_VENDA_MOEDA_DEBITO", ":IC_MUDAFIL_VENDA_MOEDA_DEBITO", _
                                                "IC_MUDAFIL_VENDA_OUTROS_CREDIT", ":IC_MUDAFIL_VENDA_OUTROS_CREDIT", _
                                                "IC_MUDAFIL_VENDA_OUTROS_DEBITO", ":IC_MUDAFIL_VENDA_OUTROS_DEBITO", _
                                                "IC_MUDAFIL_RECEB_MOEDA_CREDITO", ":IC_MUDAFIL_RECEB_MOEDA_CREDITO", _
                                                "IC_MUDAFIL_RECEB_MOEDA_DEBITO", ":IC_MUDAFIL_RECEB_MOEDA_DEBITO", _
                                                "IC_MUDAFIL_RECEB_OUTROS_CREDIT", ":IC_MUDAFIL_RECEB_OUTROS_CREDIT", _
                                                "IC_MUDAFIL_RECEB_OUTROS_DEBITO", ":IC_MUDAFIL_RECEB_OUTROS_DEBITO", _
                                                "IC_CONTABILIZA_RECEB_OUTROS", ":IC_CONTABILIZA_RECEB_OUTROS", _
                                                "IC_CONTABILIZA_RECEB_MOEDA", ":IC_CONTABILIZA_RECEB_MOEDA", _
                                                "IC_CONTABILIZA_VENDA_OUTROS", ":IC_CONTABILIZA_VENDA_OUTROS", _
                                                "NU_CC_RECEB_MOEDA_CREDITO", ":NU_CC_RECEB_MOEDA_CREDITO", _
                                                "NU_CC_RECEB_MOEDA_DEBITO", ":NU_CC_RECEB_MOEDA_DEBITO", _
                                                "IC_MUDAFIL_FECHAMENTO_CREDITO", ":IC_MUDAFIL_FECHAMENTO_CREDITO", _
                                                "IC_MUDAFIL_FECHAMENTO_DEBITO", ":IC_MUDAFIL_FECHAMENTO_DEBITO", _
                                                "NU_CC_FECHAMENTO_CREDITO_LUCRO", ":NU_CC_FECHAMENTO_CREDITO_LUCRO", _
                                                "NU_CC_FECHAMENTO_DEBITO_LUCRO", ":NU_CC_FECHAMENTO_DEBITO_LUCRO", _
                                                "IC_MUDAFIL_FECHA_CREDITO_LUCRO", ":IC_MUDAFIL_FECHA_CREDITO_LUCRO", _
                                                "IC_MUDAFIL_FECHA_DEBITO_LUCRO", ":IC_MUDAFIL_FECHA_DEBITO_LUCRO", _
                                                "NU_CC_JUROS_CREDITO", ":NU_CC_JUROS_CREDITO", _
                                                "NU_CC_JUROS_DEBITO", ":NU_CC_JUROS_DEBITO", _
                                                "IC_MUDAFIL_JUROS_CREDITO", ":IC_MUDAFIL_JUROS_CREDITO", _
                                                "IC_MUDAFIL_JUROS_DEBITO", ":IC_MUDAFIL_JUROS_DEBITO", _
                                                "CD_CONFISSAO_DIVIDA_MODALIDADE", ":CD_CONFISSAO_DIVIDA_MODALIDADE")
        Else
            SqlText = DBMontar_Update("SOF.confissao_divida_parametro", GerarArray("CD_CONCILIACAO_MODALIDADE_PAG", ":CD_CONCILIACAO_MODALIDADE_PAG", _
                                                "NU_CC_VENDA_MOEDA_CREDITO", ":NU_CC_VENDA_MOEDA_CREDITO", _
                                                "NU_CC_VENDA_MOEDA_DEBITO", ":NU_CC_VENDA_MOEDA_DEBITO", _
                                                "NU_CC_VENDA_OUTROS_CREDITO", ":NU_CC_VENDA_OUTROS_CREDITO", _
                                                "NU_CC_VENDA_OUTROS_DEBITO", ":NU_CC_VENDA_OUTROS_DEBITO", _
                                                "NU_CC_RECEB_OUTROS_CREDITO", ":NU_CC_RECEB_OUTROS_CREDITO", _
                                                "NU_CC_RECEB_OUTROS_DEBITO", ":NU_CC_RECEB_OUTROS_DEBITO", _
                                                "NU_CC_FECHAMENTO_CREDITO", ":NU_CC_FECHAMENTO_CREDITO", _
                                                "NU_CC_FECHAMENTO_DEBITO", ":NU_CC_FECHAMENTO_DEBITO", _
                                                "CD_TIPO_PAGAMENTO", ":CD_TIPO_PAGAMENTO", _
                                                "CD_FORMA_PAGAMENTO", ":CD_FORMA_PAGAMENTO", _
                                                "IC_CONTABILIZA_VENDA_MOEDA", ":IC_CONTABILIZA_VENDA_MOEDA", _
                                                "IC_MUDAFIL_VENDA_MOEDA_CREDITO", ":IC_MUDAFIL_VENDA_MOEDA_CREDITO", _
                                                "IC_MUDAFIL_VENDA_MOEDA_DEBITO", ":IC_MUDAFIL_VENDA_MOEDA_DEBITO", _
                                                "IC_MUDAFIL_VENDA_OUTROS_CREDIT", ":IC_MUDAFIL_VENDA_OUTROS_CREDIT", _
                                                "IC_MUDAFIL_VENDA_OUTROS_DEBITO", ":IC_MUDAFIL_VENDA_OUTROS_DEBITO", _
                                                "IC_MUDAFIL_RECEB_MOEDA_CREDITO", ":IC_MUDAFIL_RECEB_MOEDA_CREDITO", _
                                                "IC_MUDAFIL_RECEB_MOEDA_DEBITO", ":IC_MUDAFIL_RECEB_MOEDA_DEBITO", _
                                                "IC_MUDAFIL_RECEB_OUTROS_CREDIT", ":IC_MUDAFIL_RECEB_OUTROS_CREDIT", _
                                                "IC_MUDAFIL_RECEB_OUTROS_DEBITO", ":IC_MUDAFIL_RECEB_OUTROS_DEBITO", _
                                                "IC_CONTABILIZA_RECEB_OUTROS", ":IC_CONTABILIZA_RECEB_OUTROS", _
                                                "IC_CONTABILIZA_RECEB_MOEDA", ":IC_CONTABILIZA_RECEB_MOEDA", _
                                                "IC_CONTABILIZA_VENDA_OUTROS", ":IC_CONTABILIZA_VENDA_OUTROS", _
                                                "NU_CC_RECEB_MOEDA_CREDITO", ":NU_CC_RECEB_MOEDA_CREDITO", _
                                                "NU_CC_RECEB_MOEDA_DEBITO", ":NU_CC_RECEB_MOEDA_DEBITO", _
                                                "IC_MUDAFIL_FECHAMENTO_CREDITO", ":IC_MUDAFIL_FECHAMENTO_CREDITO", _
                                                "IC_MUDAFIL_FECHAMENTO_DEBITO", ":IC_MUDAFIL_FECHAMENTO_DEBITO", _
                                                "NU_CC_FECHAMENTO_CREDITO_LUCRO", ":NU_CC_FECHAMENTO_CREDITO_LUCRO", _
                                                "NU_CC_FECHAMENTO_DEBITO_LUCRO", ":NU_CC_FECHAMENTO_DEBITO_LUCRO", _
                                                "IC_MUDAFIL_FECHA_CREDITO_LUCRO", ":IC_MUDAFIL_FECHA_CREDITO_LUCRO", _
                                                "IC_MUDAFIL_FECHA_DEBITO_LUCRO", ":IC_MUDAFIL_FECHA_DEBITO_LUCRO", _
                                                "NU_CC_JUROS_CREDITO", ":NU_CC_JUROS_CREDITO", _
                                                "NU_CC_JUROS_DEBITO", ":NU_CC_JUROS_DEBITO", _
                                                "IC_MUDAFIL_JUROS_CREDITO", ":IC_MUDAFIL_JUROS_CREDITO", _
                                                "IC_MUDAFIL_JUROS_DEBITO", ":IC_MUDAFIL_JUROS_DEBITO"), _
                                        GerarArray("CD_CONFISSAO_DIVIDA_MODALIDADE", ":CD_CONFISSAO_DIVIDA_MODALIDADE"), False)
        End If

        Parametro(0) = DBParametro_Montar("CD_CONCILIACAO_MODALIDADE_PAG", cboModalidadeConciliacao.SelectedValue)
        Parametro(1) = DBParametro_Montar("NU_CC_VENDA_MOEDA_CREDITO", txtVendaMoedaCredito.Text)
        Parametro(2) = DBParametro_Montar("NU_CC_VENDA_MOEDA_DEBITO", txtVendaMoedaDebito.Text)
        Parametro(3) = DBParametro_Montar("NU_CC_VENDA_OUTROS_CREDITO", txtVendaOutrosCredito.Text)
        Parametro(4) = DBParametro_Montar("NU_CC_VENDA_OUTROS_DEBITO", txtVendaOutrosDebito.Text)
        Parametro(5) = DBParametro_Montar("NU_CC_RECEB_OUTROS_CREDITO", txtRecebimentoOutrosCredito.Text)
        Parametro(6) = DBParametro_Montar("NU_CC_RECEB_OUTROS_DEBITO", txtRecebimentoOutrosDebito.Text)
        Parametro(7) = DBParametro_Montar("NU_CC_FECHAMENTO_CREDITO", txtFechamentoPerdasCredito.Text)
        Parametro(8) = DBParametro_Montar("NU_CC_FECHAMENTO_DEBITO", txtFechamentoPerdasDebito.Text)
        Parametro(9) = DBParametro_Montar("CD_TIPO_PAGAMENTO", cboTipoPagamento.SelectedValue)
        Parametro(10) = DBParametro_Montar("CD_FORMA_PAGAMENTO", cboFormaPagamento.SelectedValue)
        Parametro(11) = DBParametro_Montar("IC_CONTABILIZA_VENDA_MOEDA", IIf(chkVendasMoeda.Checked, "S", "N"))
        Parametro(12) = DBParametro_Montar("IC_MUDAFIL_VENDA_MOEDA_CREDITO", IIf(chkVendaMoedaCredito.Checked, "S", "N"))
        Parametro(13) = DBParametro_Montar("IC_MUDAFIL_VENDA_MOEDA_DEBITO", IIf(chkVendaMoedaDebito.Checked, "S", "N"))
        Parametro(14) = DBParametro_Montar("IC_MUDAFIL_VENDA_OUTROS_CREDIT", IIf(chkVendaOutrosCredito.Checked, "S", "N"))
        Parametro(15) = DBParametro_Montar("IC_MUDAFIL_VENDA_OUTROS_DEBITO", IIf(chkVendaOutrosDebito.Checked, "S", "N"))
        Parametro(16) = DBParametro_Montar("IC_MUDAFIL_RECEB_MOEDA_CREDITO", IIf(chkRecebimentoMoedaCredito.Checked, "S", "N"))
        Parametro(17) = DBParametro_Montar("IC_MUDAFIL_RECEB_MOEDA_DEBITO", IIf(chkRecebimentoMoedaDebito.Checked, "S", "N"))
        Parametro(18) = DBParametro_Montar("IC_MUDAFIL_RECEB_OUTROS_CREDIT", IIf(chkRecebimentoOutrosCredito.Checked, "S", "N"))
        Parametro(19) = DBParametro_Montar("IC_MUDAFIL_RECEB_OUTROS_DEBITO", IIf(chkRecebimentoOutrosDebito.Checked, "S", "N"))
        Parametro(20) = DBParametro_Montar("IC_CONTABILIZA_RECEB_OUTROS", IIf(chkRecebimentoOutros.Checked, "S", "N"))
        Parametro(21) = DBParametro_Montar("IC_CONTABILIZA_RECEB_MOEDA", IIf(chkRecebimentoMoeda.Checked, "S", "N"))
        Parametro(22) = DBParametro_Montar("IC_CONTABILIZA_VENDA_OUTROS", IIf(chkVendaOutros.Checked, "S", "N"))
        Parametro(23) = DBParametro_Montar("NU_CC_RECEB_MOEDA_CREDITO", txtRecebimentoMoedaCredito.Text)
        Parametro(24) = DBParametro_Montar("NU_CC_RECEB_MOEDA_DEBITO", txtRecebimentoMoedaDebito.Text)
        Parametro(25) = DBParametro_Montar("IC_MUDAFIL_FECHAMENTO_CREDITO", IIf(chkFechamentoPerdasCredito.Checked, "S", "N"))
        Parametro(26) = DBParametro_Montar("IC_MUDAFIL_FECHAMENTO_DEBITO", IIf(chkFechamentoPerdasDebito.Checked, "S", "N"))
        Parametro(27) = DBParametro_Montar("NU_CC_FECHAMENTO_CREDITO_LUCRO", txtFechamentoLucroCredito.Text)
        Parametro(28) = DBParametro_Montar("NU_CC_FECHAMENTO_DEBITO_LUCRO", txtFechamentoLucroDebito.Text)
        Parametro(29) = DBParametro_Montar("IC_MUDAFIL_FECHA_CREDITO_LUCRO", IIf(chkFechamentoLucroCredito.Checked, "S", "N"))
        Parametro(30) = DBParametro_Montar("IC_MUDAFIL_FECHA_DEBITO_LUCRO", IIf(chkFechamentoLucroDebito.Checked, "S", "N"))
        Parametro(31) = DBParametro_Montar("NU_CC_JUROS_CREDITO", txtJurosCredito.Text)
        Parametro(32) = DBParametro_Montar("NU_CC_JUROS_DEBITO", txtJurosDebito.Text)
        Parametro(33) = DBParametro_Montar("IC_MUDAFIL_JUROS_CREDITO", IIf(chkJurosCredito.Checked, "S", "N"))
        Parametro(34) = DBParametro_Montar("IC_MUDAFIL_JUROS_DEBITO", IIf(chkJurosDebito.Checked, "S", "N"))
        Parametro(35) = DBParametro_Montar("CD_CONFISSAO_DIVIDA_MODALIDADE", CdModalidadeRecuperacao)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        Close()

        Exit Sub
Erro:
        TratarErro()
    End Sub
End Class