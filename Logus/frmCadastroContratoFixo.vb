Public Class frmCadastroContratoFixo
    Dim IcTipoPrecoFixo As String
    Dim IcDolar As String
    Dim IcBolsa As String
    Dim IcBolsaOperacao As String
    Dim QtFator As Integer
    Dim CdTipoUnidade As Integer
    Dim VlFrete As Double

    Private Sub frmCadastroContratoFixo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Pesq_ContratoPAF
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_ContratoPAF
            .BancoDados_Filtro_Limpar()
            .BancoDados_Filtro_Adicionar("IC_STATUS = 'A'")

            If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_LimitarInclusaoCtrSomentoImportacao) Then
                .BancoDados_Filtro_Adicionar("F.CD_TIPO_PESSOA = " & cnt_TipoPessoa_IMPORTADO)
            End If
        End With

        ComboBox_Carregar_Tipo_Pessoa(cboTipoPessoa, True, True)

        Dim SqlText As String

        SqlText = "SELECT cd_papel, no_papel, dt_limite_entrega, " & _
            "        vl_cotacao  " & _
            "  FROM sof.bolsa_periodo  " & _
            "  where ic_moeda ='N' " & _
            "  order by dt_limite_entrega "

        objUltraComboBox_Carregar(cboBolsa, SqlText, _
                                  New Combo_Informacao() {objUltraComboBox_Informacao("Papel", True, 40, True, True), _
                                                          objUltraComboBox_Informacao("Nome", True, 80, False, False, cnt_Formato_NumeroInteiro), _
                                                          objUltraComboBox_Informacao("Dt Limite", True, 120, False, False), _
                                                          objUltraComboBox_Informacao("Cotação", True, 80, False, False)}, , )

        Limpa_Tela()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Pega_Dolar()
        Dim oData As DataTable
        Dim SqlText As String

        SqlText = "SELECT NVL(A.VL_COTACAO, A.VL_COTACAO_ALTERNATIVO) VL_COTACAO" & _
                  " FROM SOF.BOLSA_PERIODO A" & _
                  " WHERE A.IC_MOEDA = 'S'" & _
                  " ORDER BY A.NU_SEQUENCIA"
        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            txtTaxaDolar.Value = NVL(oData.Rows(0).Item("VL_COTACAO"), 0)
        End If
    End Sub

    Private Sub Pega_Bolsa(ByVal CdPapel As String)
        Dim oData As DataTable

        Dim SqlText As String

        SqlText = "SELECT NVL(a.vl_cotacao, A.vl_cotacao_alternativo) vl_cotacao, A.cd_papel, A.nu_sequencia " & _
                  "FROM SOF.bolsa_periodo a " & _
                  "WHERE A.ic_moeda = 'N' " & _
                  " AND CD_PAPEL =" & QuotedStr(CdPapel) & _
                  " ORDER BY A.nu_sequencia"
        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            txtBolsa.Value = NVL(oData.Rows(0).Item("vl_cotacao"), 0)
        End If
    End Sub

    Private Sub cboNegociacao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNegociacao.SelectedIndexChanged
        Dim SqlText As String
        Dim oData As DataTable

        If Not ComboBox_LinhaSelecionada(cboNegociacao) Then
            Limpa_Negociacao()
            Exit Sub
        End If

        sqltext = "SELECT n.sq_negociacao, n.vl_negociacao, n.qt_a_fixar, n.qt_cancelado, "
        sqltext = sqltext & "       tu.qt_fator, n.pc_aliq_icms, tn.ic_bolsa, tn.ic_bolsa_operacao, "
        SqlText = SqlText & "       tn.ic_dolar, tn.ic_tipo_preco_fixo, n.cd_tipo_unidade, n.dt_vencimento, n.vl_preco_frete, "
        SqlText = SqlText & "       n.qt_kgs, n.vl_negociacao, n.dt_negociacao, tn.no_tipo_negociacao, n.cd_tipo_pessoa, n.CD_PAPEL_COMPETENCIA  "
        sqltext = sqltext & "  FROM sof.negociacao n, sof.tipo_negociacao tn, sof.tipo_unidade tu "
        sqltext = sqltext & " WHERE tn.cd_tipo_negociacao = n.cd_tipo_negociacao "
        sqltext = sqltext & "   AND tu.cd_tipo_unidade = n.cd_tipo_unidade "
        SqlText = SqlText & "   AND n.cd_contrato_paf =  " & Pesq_ContratoPAF.Codigo
        SqlText = SqlText & "   AND n.sq_negociacao =  " & cboNegociacao.SelectedValue

        oData = DBQuery(SqlText)

        txtSaldo.Value = oData.Rows(0).Item("QT_A_FIXAR")
        txtAliquotaICMS.Value = oData.Rows(0).Item("PC_ALIQ_ICMS")
        txtDataVencimento.Value = oData.Rows(0).Item("DT_VENCIMENTO")
        txtQuantidadeNegociacao.Value = oData.Rows(0).Item("QT_KGS")
        txtValorUnitarioNegocicao.Value = oData.Rows(0).Item("VL_NEGOCIACAO")
        txtDataNegociacao.Value = oData.Rows(0).Item("DT_NEGOCIACAO")
        lblTipoNegociacao.Text = oData.Rows(0).Item("NO_TIPO_NEGOCIACAO")

        If Not objDataTable_CampoVazio(oData.Rows(0).Item("CD_TIPO_PESSOA")) Then
            ComboBox_Possicionar(cboTipoPessoa, oData.Rows(0).Item("CD_TIPO_PESSOA"))
            cboTipoPessoa.Enabled = False
        Else
            cboTipoPessoa.Enabled = True
        End If

        IcTipoPrecoFixo = oData.Rows(0).Item("IC_TIPO_PRECO_FIXO")
        IcDolar = oData.Rows(0).Item("IC_DOLAR")
        IcBolsa = oData.Rows(0).Item("IC_BOLSA")
        IcBolsaOperacao = oData.Rows(0).Item("IC_BOLSA_OPERACAO")
        QtFator = oData.Rows(0).Item("QT_FATOR")
        CdTipoUnidade = oData.Rows(0).Item("CD_TIPO_UNIDADE")
        VlFrete = oData.Rows(0).Item("VL_PRECO_FRETE")
        txtBolsa.Enabled = False
        cmdAtualizar.Enabled = False
        txtBolsa.Value = 0

        chkDolar.Enabled = False
        chkDolar.Checked = True
        txtTaxaDolar.Enabled = False
        txtTaxaDolar.Value = 0

        Select Case True
            Case oData.Rows(0).Item("IC_BOLSA") = "S"
                txtBolsa.Enabled = True
                cmdAtualizar.Enabled = True
                chkDolar.Enabled = True
                chkDolar.Checked = True
                txtTaxaDolar.Enabled = True
                Pega_Dolar()
                Pega_Bolsa(oData.Rows(0).Item("CD_PAPEL_COMPETENCIA"))
                objUltraComboBox_Possicionar(cboBolsa, 0, oData.Rows(0).Item("CD_PAPEL_COMPETENCIA"))
            Case oData.Rows(0).Item("ic_dolar") = "S"
                chkDolar.Enabled = False
                chkDolar.Checked = True
                txtTaxaDolar.Enabled = True
                Pega_Dolar()
        End Select

        Calcula_Valor()
    End Sub

    Private Sub chkDolar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDolar.CheckedChanged
        If chkDolar.Checked = True Then
            txtTaxaDolar.Enabled = True
        Else
            Pega_Dolar()
            txtTaxaDolar.Enabled = False
        End If
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Limpa_Tela()
        Pesq_ContratoPAF.Focus()
    End Sub

    Private Sub Limpa_Tela()
        txtTaxaDolar.Value = 0
        txtBolsa.Value = 0
        txtQuantidadeContratoFixo.Value = 0
        txtDataVencimento.Value = Nothing
        txtDataPagamento.Value = Nothing
        Limpa_Contrato()
        lblContratoFixo.Text = "NOVO"
        txtDataContratoFixo.Value = DataSistema()
        chkDolar.Checked = True
        cmdImprimir.Visible = False
        cmdGravar.Enabled = True
        grpdados.Enabled = True
        Pesq_ContratoPAF.Enabled = True
        cboNegociacao.Enabled = True
        ComboBox_Possicionar(cboTipoPessoa, -1)
    End Sub

    Private Sub Limpa_Negociacao()
        txtValorUnitarioContratoFixo.Value = 0
        txtAliquotaICMS.Value = 0
        txtValorTotal.Value = 0
        txtValorICMS.Value = 0
        txtValorINSS.Value = 0
        txtSaldo.Value = 0
        txtQuantidadeNegociacao.Value = 0
        txtValorUnitarioNegocicao.Value = 0
        txtDataNegociacao.Value = Nothing
        lblTipoNegociacao.Text = ""
    End Sub

    Private Sub Limpa_Contrato()
        Pesq_ContratoPAF.Codigo = 0
        cboNegociacao.DataSource = Nothing
        Limpa_Negociacao()
    End Sub

    Private Sub Calcula_Valor()
        Dim mVlI As Double

        txtValorUnitarioContratoFixo.Value = 0

        If Not ComboBox_LinhaSelecionada(cboNegociacao) Then
            Exit Sub
        End If

        Select Case True
            Case IcTipoPrecoFixo = "S"
                txtValorUnitarioContratoFixo.Value = txtValorUnitarioNegocicao.Value
            Case IcDolar = "S"
                txtValorUnitarioContratoFixo.Value = Math.Round(txtValorUnitarioNegocicao.Value * txtTaxaDolar.Value, 2)
            Case IcBolsa = "S"
                Select Case IcBolsaOperacao
                    Case "+"
                        txtValorUnitarioContratoFixo.Value = Math.Round(((((txtBolsa.Value + txtValorUnitarioNegocicao.Value) * txtTaxaDolar.Value) / 1000) - VlFrete / 60) * QtFator, 2)
                    Case "-"
                        txtValorUnitarioContratoFixo.Value = Math.Round(((((txtBolsa.Value - txtValorUnitarioNegocicao.Value) * txtTaxaDolar.Value) / 1000) - VlFrete / 60) * QtFator, 2)
                    Case "*"
                        txtValorUnitarioContratoFixo.Value = Math.Round(((((txtBolsa.Value * txtValorUnitarioNegocicao.Value) * txtTaxaDolar.Value) / 1000) - VlFrete / 60) * QtFator, 2)
                    Case "/"
                        txtValorUnitarioContratoFixo.Value = Math.Round(((((txtBolsa.Value / txtValorUnitarioNegocicao.Value) * txtTaxaDolar.Value) / 1000) - VlFrete / 60) * QtFator, 2)
                End Select
        End Select

        txtValorTotal.Value = txtQuantidadeContratoFixo.Value * (txtValorUnitarioContratoFixo.Value / QtFator)

        mVlI = txtValorTotal.Value / (1 - (((txtAliquotaICMS.Value)) / 100))
        txtValorICMS.Value = mVlI * (txtAliquotaICMS.Value / 100)
        txtValorINSS.Value = mVlI
    End Sub

    Private Sub txtQuantidadeContratoFixo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantidadeContratoFixo.ValueChanged
        Calcula_Valor()
    End Sub

    Private Sub txtTaxaDolar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTaxaDolar.ValueChanged
        Calcula_Valor()
    End Sub

    Private Sub txtBolsa_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBolsa.ValueChanged
        Calcula_Valor()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim oData As DataTable
        Dim Parametro(21) As DBParamentro

        If Pesq_ContratoPAF.Codigo = 0 Then
            Msg_Mensagem("Favor informar um contrato PAF valido.")
            Pesq_ContratoPAF.Focus()
            Exit Sub
        End If

        SqlText = "SELECT f.ds_obs " & _
                    "FROM sof.fornecedor_obs f, sof.contrato_paf cp " & _
                    "WHERE f.cd_fornecedor = cp.cd_fornecedor AND cp.cd_contrato_paf = " & Pesq_ContratoPAF.Codigo
        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            Msg_Mensagem(oData.Rows(0).Item("ds_obs"))
            If Msg_Perguntar("Continua a inclusão ?") = False Then Exit Sub
        End If

        If txtQuantidadeContratoFixo.Value <= 0 Then
            Msg_Mensagem("Favor informar a quantidade em quilos do contrato fixo maior do 0.")
            txtQuantidadeContratoFixo.Focus()
            Exit Sub
        End If

        If txtQuantidadeContratoFixo.Value > txtSaldo.Value Then
            Msg_Mensagem("Favor informar uma quantidade menor do que " & Format(txtSaldo.Value, "#,##0"))
            txtQuantidadeContratoFixo.Focus()
            Exit Sub
        End If

        If Not IsDate(txtDataVencimento.Text) Then
            Msg_Mensagem("Data de vencimento invalida.")
            txtDataVencimento.Focus()
            Exit Sub
        End If

        If CDate(txtDataVencimento.Text) < DataSistema() Then
            Msg_Mensagem("Data de vencimento menor que a data atual")
            txtDataVencimento.Focus()
            Exit Sub
        End If

        If Not IsDate(txtDataPagamento.Text) Then
            Msg_Mensagem("Data de pagamento invalida.")
            txtDataPagamento.Focus()
            Exit Sub
        End If

        If CDate(txtDataPagamento.Text) < DataSistema() Then
            Msg_Mensagem("Data de pagamento menor que a data atual")
            txtDataPagamento.Focus()
            Exit Sub
        End If

        If txtValorUnitarioContratoFixo.Value = 0 Then
            Msg_Mensagem("Valor unitario não pode ser igual a zero.")
            txtValorUnitarioContratoFixo.Focus()
            Exit Sub
        End If

        If FilialFechada(FilialLogada) Then
            Msg_Mensagem("A Filial está fechada. No momento não é possivel incluir a negociação.")
            Exit Sub
        End If

        DBUsarTransacao = True

        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONTRATO_FIXO", False, ":CDCONTRATOPAF", _
                                                                    ":SQNEGOCIACAO", _
                                                                    ":CDTIPOUNIDADE", _
                                                                    ":DTCONTRATOFIXO", _
                                                                    ":QTKGS", _
                                                                    ":VLUNITARIO", _
                                                                    ":DTVENCIMENTO", _
                                                                    ":DTPAGAMENTO", _
                                                                    ":PCALIQICMS", _
                                                                    ":TAXAUSFECHADO", _
                                                                    ":BOLSAFECHADO", _
                                                                    ":SQBOLSAGRUPOPREMIO", _
                                                                    ":CDTIPOPESSOA", _
                                                                    ":SQNEGOCIACAOPRE", _
                                                                    ":ICDOLARVARIAVEL", _
                                                                    ":SQSOLICITACAO", _
                                                                    ":SQNEGSOLCITACAO", _
                                                                    ":ICGP", _
                                                                    ":DTVENCIMENTOGP", _
                                                                    ":TAXAUSGP", _
                                                                    ":SQCONTRATOFIXO", _
                                                                    ":CDPAPELPARAM")

        Parametro(0) = DBParametro_Montar("CDCONTRATOPAF", Pesq_ContratoPAF.Codigo)
        Parametro(1) = DBParametro_Montar("SQNEGOCIACAO", cboNegociacao.SelectedValue)
        Parametro(2) = DBParametro_Montar("CDTIPOUNIDADE", CdTipoUnidade)
        Parametro(3) = DBParametro_Montar("DTCONTRATOFIXO", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime)
        Parametro(4) = DBParametro_Montar("QTKGS", txtQuantidadeContratoFixo.Value)
        Parametro(5) = DBParametro_Montar("VLUNITARIO", txtValorUnitarioContratoFixo.Value)
        Parametro(6) = DBParametro_Montar("DTVENCIMENTO", Date_to_Oracle(txtDataVencimento.Text), OracleClient.OracleType.DateTime)
        Parametro(7) = DBParametro_Montar("DTPAGAMENTO", Date_to_Oracle(txtDataPagamento.Text), OracleClient.OracleType.DateTime)
        Parametro(8) = DBParametro_Montar("PCALIQICMS", txtAliquotaICMS.Value)
        Parametro(9) = DBParametro_Montar("TAXAUSFECHADO", txtTaxaDolar.Value)
        Parametro(10) = DBParametro_Montar("BOLSAFECHADO", txtBolsa.Value)
        'o premio não esta sendo usado, existe um cadastro fixo q é usado para todos
        Parametro(11) = DBParametro_Montar("SQBOLSAGRUPOPREMIO", 1)
        Parametro(12) = DBParametro_Montar("CDTIPOPESSOA", cboTipoPessoa.SelectedValue)
        Parametro(13) = DBParametro_Montar("SQNEGOCIACAOPRE", Nothing)
        Parametro(14) = DBParametro_Montar("ICDOLARVARIAVEL", IIf(chkDolar.Checked = True, "N", "S"))
        Parametro(15) = DBParametro_Montar("SQSOLICITACAO", Nothing)
        Parametro(16) = DBParametro_Montar("SQNEGSOLCITACAO", Nothing)
        Parametro(17) = DBParametro_Montar("ICGP", "N")
        Parametro(18) = DBParametro_Montar("DTVENCIMENTOGP", Nothing)
        Parametro(19) = DBParametro_Montar("TAXAUSGP", Nothing)
        Parametro(20) = DBParametro_Montar("SQCONTRATOFIXO", Nothing, , ParameterDirection.Output)
        Parametro(21) = DBParametro_Montar("CDPAPELPARAM", cboBolsa.SelectedRow.Cells(0).Value)
        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        If DBTeveRetorno() Then
            lblContratoFixo.Text = DBRetorno(1)
        End If

        If Not DBExecutarTransacao() Then GoTo Erro

        'Revisao_de_Contratos(False, Pesq_ContratoPAF.Codigo, True)

        Try
            SqlText = DBMontar_SP("SOF.SP_CALCULO_DIFERENCIAL", False, ":CD_CONTRATO_PAF", _
                                                                       ":SQ_NEGOCIACAO", _
                                                                       ":SQ_CONTRATO_FIXO", _
                                                                       ":SQ_PRE_NEGOCIACAO")
            If Not DBExecutar(SqlText, DBParametro_Montar("CD_CONTRATO_PAF", Pesq_ContratoPAF.Codigo), _
                                       DBParametro_Montar("SQ_NEGOCIACAO", cboNegociacao.SelectedValue), _
                                       DBParametro_Montar("SQ_CONTRATO_FIXO", lblContratoFixo.Text), _
                                       DBParametro_Montar("SQ_PRE_NEGOCIACAO", Nothing)) Then GoTo Erro
        Catch ex As Exception
        End Try

        cmdImprimir.Visible = True
        cmdGravar.Enabled = False
        grpdados.Enabled = False

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub Pesq_ContratoPAF_AlterouRegistro() Handles Pesq_ContratoPAF.AlterouRegistro
        Dim SqlText As String

        cboNegociacao.DataSource = Nothing

        If Pesq_ContratoPAF.Codigo = 0 Then Exit Sub

        SqlText = "SELECT N.SQ_NEGOCIACAO," & _
                         "TO_CHAR(N.SQ_NEGOCIACAO) NO_NEGOCIACAO" & _
                  " FROM SOF.NEGOCIACAO N," & _
                        "SOF.TIPO_NEGOCIACAO TN," & _
                        "SOF.TIPO_UNIDADE TU " & _
                  " WHERE TN.CD_TIPO_NEGOCIACAO = N.CD_TIPO_NEGOCIACAO" & _
                    " AND TU.CD_TIPO_UNIDADE = N.CD_TIPO_UNIDADE" & _
                    " AND N.IC_STATUS = 'A'" & _
                    " AND N.CD_CONTRATO_PAF =  " & Pesq_ContratoPAF.Codigo
        DBCarregarComboBox(cboNegociacao, SqlText, True)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Impressao_ContratoFixo(Pesq_ContratoPAF.Codigo, cboNegociacao.SelectedValue, lblContratoFixo.Text)
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Pega_Bolsa(cboBolsa.SelectedRow.Cells(0).Value)
        Pega_Dolar()
    End Sub

    Private Sub cboBolsa_AfterCloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBolsa.AfterCloseUp
        txtBolsa.Value = NVL(cboBolsa.SelectedRow.Cells(3).Value, 0)
    End Sub
End Class