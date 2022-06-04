Public Class frmCadastroPreNegociacao
    Dim CdNegPadrao As Integer
    Dim mVlFretePadrao As Double
    Dim QtFator As Integer
    Dim VlTaxa_Funrural As Double

    Private Enum eLocalEntrega
        Fazenda = 1
        Filial = 2
        Fabrica = 3
    End Enum
    Private Enum eTipoNegociacao
        FIXO_REAL = 1
        FIXO_DOLAR = 2
        DIFERENCIAL_BOLSA = 3
    End Enum

    Private Sub frmCadastroPreNegociacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String
        Dim oData As DataTable

        ComboBox_Carregar_Tipo_Pessoa(cboTipoPessoa, True, True)
        ComboBox_Carregar_Filial(cboFilialEntrega, True, True, True)
        ComboBox_Carregar_Local_Entrega(cboLocalEntrega, True)
        ComboBox_Carregar_Tipo_Cacau(cboTipoCacau, True)
        ComboBox_Carregar_Tipo_Negociacao(cboTipoNegociacao, True)
        ComboBox_Carregar_Tipo_Unidade(cboUnidade, True)
        ComboBox_Carregar_UF(cboUF, True)

        SqlText = "SELECT CD_TIPO_NEGOCIACAO_PADRAO," & _
                         "IC_MOEDA_CREDITO," & _
                         "IC_JUROS_AUTOMATICO," & _
                         "PC_JUROS_AO_MES," & _
                         "NU_DIAS_MAX_CARENCIA_JUROS" & _
                  " FROM SOF.PARAMETRO"
        oData = DBQuery(SqlText)

        With oData.Rows(0)
            CdNegPadrao = NVL(.Item("CD_TIPO_NEGOCIACAO_PADRAO"), -1)

            chkCobraJuros.Checked = (NVL(.Item("IC_JUROS_AUTOMATICO"), "N") = "S")
            txtTaxaJuros.Value = NVL(.Item("PC_JUROS_AO_MES"), 0)
            txtDiasCarencia.Value = NVL(.Item("NU_DIAS_MAX_CARENCIA_JUROS"), 0)
        End With

        Limpa_Tela()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cboFilialEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilialEntrega.SelectedIndexChanged
        mVlFretePadrao = 0

        If Not ComboBox_LinhaSelecionada(cboFilialEntrega) Then Exit Sub
        If Not ComboBox_LinhaSelecionada(cboLocalEntrega) Then Exit Sub

        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "select vl_frete_filial_fazenda,vl_frete_filial_fabrica, VL_FRETE_FABRICA " & _
                  "from sof.filial where cd_filial=" & cboFilialEntrega.SelectedValue
        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            Select Case cboLocalEntrega.SelectedValue
                Case eLocalEntrega.Fazenda
                    txtValorFrete.Value = (oData.Rows(0).Item("vl_frete_filial_fabrica") + oData.Rows(0).Item("vl_frete_filial_fazenda"))
                Case eLocalEntrega.Filial
                    txtValorFrete.Value = oData.Rows(0).Item("vl_frete_filial_fabrica")
                Case eLocalEntrega.Fabrica
                    txtValorFrete.Value = oData.Rows(0).Item("VL_FRETE_FABRICA")
            End Select

            'pego valor original do frete para comparar se teve alteração
            mVlFretePadrao = txtValorFrete.Value

        Else
            txtValorFrete.Value = 0
        End If

    End Sub

    Private Sub cboLocalEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocalEntrega.SelectedIndexChanged
        If Not ComboBox_LinhaSelecionada(cboLocalEntrega) Then Exit Sub

        Select Case cboLocalEntrega.SelectedValue
            Case eLocalEntrega.Fazenda, eLocalEntrega.Filial
                cboFilialEntrega.Enabled = True
                ComboBox_Possicionar(cboFilialEntrega, -1)
            Case eLocalEntrega.Fabrica
                ComboBox_Possicionar(cboFilialEntrega, FilialLogada)
                cboFilialEntrega_SelectedIndexChanged(Nothing, Nothing)
                cboFilialEntrega.Enabled = False
        End Select

        ValidaNecessidadeEstado()
    End Sub

    Private Sub cboTipoNegociacao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoNegociacao.SelectedIndexChanged
        Dim SqlText As String

        cboBolsa.DataSource = Nothing

        If Not ComboBox_LinhaSelecionada(cboTipoNegociacao) Then Exit Sub

        If cboTipoNegociacao.SelectedValue = eTipoNegociacao.DIFERENCIAL_BOLSA Then
            cboBolsa.Enabled = True

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
        Else
            cboBolsa.Enabled = False
        End If
    End Sub

    Private Sub Limpa_Tela()

        txtFornecedor.Text = ""
        txtValorUnitarioPreNegociacao.Value = 0
        txtValorFrete.Value = 0
        txtQuantidadePreNegociacao.Value = 0
        txtDataVencimento.DateTime = Now.Date
        txtDataPagamento.DateTime = Now.Date
        lblPreNegociacao.Text = "NOVO"
        txtDataNegociacao.Value = DataSistema()
        cmdGravar.Enabled = True
        grpDados.Enabled = True
        ComboBox_Possicionar(cboUnidade, 1)
        ComboBox_Possicionar(cboTipoCacau, 1)
        ComboBox_Possicionar(cboTipoPessoa, -1)
        ComboBox_Possicionar(cboLocalEntrega, -1)
        ComboBox_Possicionar(cboFilialEntrega, -1)
        ComboBox_Possicionar(cboTipoNegociacao, CdNegPadrao)
        cboTipoNegociacao_SelectedIndexChanged(Nothing, Nothing)
        cboTipoPessoa_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim Parametro(21) As DBParamentro
        Dim SqlText As String
        Dim PC_ALIQ_ICMS As Double

        ValidaNecessidadeEstado()

        If txtFornecedor.Text = "" Then
            Msg_Mensagem("Favor descrever um fornecedor.")
            txtFornecedor.Focus()
            Exit Sub
        End If

        If txtQuantidadePreNegociacao.Value <= 0 Then
            Msg_Mensagem("Favor informar a quantidade em quilos da pre-negociação acima de 0.")
            txtQuantidadePreNegociacao.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboUnidade) Then
            Msg_Mensagem("Favor escolher uma unidade para a negociação.")
            cboUnidade.Focus()
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

        If Not ComboBox_LinhaSelecionada(cboLocalEntrega) Then
            Msg_Mensagem("Favor escolher um local de entrega.")
            cboLocalEntrega.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboTipoNegociacao) Then
            Msg_Mensagem("Favor informar um tipo de negociação.")
            cboTipoNegociacao.Focus()
            Exit Sub
        End If

        If txtValorUnitarioPreNegociacao.Value = 0 Then
            Msg_Mensagem("Favor informar um valor unitario.")
            txtValorUnitarioPreNegociacao.Focus()
            Exit Sub
        End If

        If cboBolsa.Enabled = True Then
            If Not ObjUltraComboBox_LinhaSelecionada(cboBolsa) Then
                Msg_Mensagem("Favor selecionar uma bolsa.")
                cboBolsa.Focus()
                Exit Sub
            End If
        End If

        If cboUF.Visible = True Then
            If Not ComboBox_LinhaSelecionada(cboUF) Then
                Msg_Mensagem("Favor informar o estado.")
                cboTipoPessoa.Focus()
                Exit Sub
            End If
        End If

        If Not ComboBox_LinhaSelecionada(cboTipoPessoa) Then
            Msg_Mensagem("Favor selecionar um tipo de pessoa.")
            cboTipoPessoa.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboFilialEntrega) Then
            Msg_Mensagem("Favor informar uma filial de entrega.")
            cboFilialEntrega.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboTipoCacau) Then
            Msg_Mensagem("Favor selecionar um tipo de cacau.")
            cboTipoCacau.Focus()
            Exit Sub
        End If

        If Me.txtValorFrete.Value < mVlFretePadrao Then
            Msg_Mensagem("Favor informar um frete igual ou maior que o " & mVlFretePadrao & ".")
            txtValorFrete.Focus()
            Exit Sub
        End If

        If VlTaxa_Funrural <> 0 And cboUF.Visible Then

            SqlText = "SELECT  count(*) " & _
            "FROM SOF.Filial f, SOF.MUNICIPIO M " & _
            "WHERE f.cd_municipio = M.cd_municipio AND " & _
            " M.cd_uf  = " & QuotedStr(cboUF.SelectedValue) & " AND " & _
            " f.cd_filial=" & cboFilialEntrega.SelectedValue

            If DBQuery_ValorUnico(SqlText, 0) = 0 Then

                SqlText = "SELECT  U.pc_aliq_icms " & _
                "FROM SOF.UF U " & _
                "WHERE u.cd_uf  = " & QuotedStr(cboUF.SelectedValue)

                PC_ALIQ_ICMS = DBQuery_ValorUnico(SqlText, 0)
            End If
        End If

        DBUsarTransacao = True

        SqlText = DBMontar_SP("SOF.SP_INCLUI_NEGOCIACAO_PRE", False, ":CDTIPONEGOCIACAO", _
                                                              ":CDTIPOUNIDADE", _
                                                              ":DTNEGOCIACAO", _
                                                              ":QTKGS", _
                                                              ":VLNEGOCIACAO", _
                                                              ":CDLOCALENTREGA", _
                                                              ":DTVENCIMENTO", _
                                                              ":DTPAGAMENTO", _
                                                              ":VLPRECOFRETE", _
                                                              ":CDPAPELCOMPETENCIA", _
                                                              ":SQBOLSAGRUPOPREMIO", _
                                                              ":CDTIPOPESSOA", _
                                                              ":DSFORNECEDOR", _
                                                              ":CDFILIALORIGEM", _
                                                              ":CDTIPOCACAU", _
                                                              ":CDFILIALENTREGA", _
                                                              ":ICCALCULAJUROS", _
                                                              ":QTDIACARENCIAJUROS", _
                                                              ":ICJUROSAPOSCARENCIA", _
                                                              ":PCTAXAJUROS", _
                                                              ":VLTAXA", _
                                                              ":SQNEGOCIACAOPRE")

        Parametro(0) = DBParametro_Montar("CDTIPONEGOCIACAO", cboTipoNegociacao.SelectedValue)
        Parametro(1) = DBParametro_Montar("CDTIPOUNIDADE", cboUnidade.SelectedValue)
        Parametro(2) = DBParametro_Montar("DTNEGOCIACAO", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime)
        Parametro(3) = DBParametro_Montar("QTKGS", txtQuantidadePreNegociacao.Value)
        Parametro(4) = DBParametro_Montar("VLNEGOCIACAO", txtValorUnitarioPreNegociacao.Value)
        Parametro(5) = DBParametro_Montar("CDLOCALENTREGA", cboLocalEntrega.SelectedValue)
        Parametro(6) = DBParametro_Montar("DTVENCIMENTO", Date_to_Oracle(txtDataVencimento.Text), OracleClient.OracleType.DateTime)
        Parametro(7) = DBParametro_Montar("DTPAGAMENTO", Date_to_Oracle(txtDataPagamento.Text), OracleClient.OracleType.DateTime)
        Parametro(8) = DBParametro_Montar("VLPRECOFRETE", txtValorFrete.Value)
        If Not ObjUltraComboBox_LinhaSelecionada(cboBolsa) Then
            Parametro(9) = DBParametro_Montar("CDPAPELCOMPETENCIA", Nothing)
        Else
            Parametro(9) = DBParametro_Montar("CDPAPELCOMPETENCIA", cboBolsa.SelectedRow.Cells(0).Value)
        End If
        Parametro(10) = DBParametro_Montar("SQBOLSAGRUPOPREMIO", 1)
        Parametro(11) = DBParametro_Montar("CDTIPOPESSOA", cboTipoPessoa.SelectedValue)
        Parametro(12) = DBParametro_Montar("DSFORNECEDOR", txtFornecedor.Text, OracleClient.OracleType.VarChar, , 200)
        Parametro(13) = DBParametro_Montar("CDFILIALORIGEM", FilialLogada)
        Parametro(14) = DBParametro_Montar("CDTIPOCACAU", cboTipoCacau.SelectedValue)
        Parametro(15) = DBParametro_Montar("CDFILIALENTREGA", cboFilialEntrega.SelectedValue)
        Parametro(16) = DBParametro_Montar("ICCALCULAJUROS", IIf(chkCobraJuros.Checked, "S", "N"))
        Parametro(17) = DBParametro_Montar("QTDIACARENCIAJUROS", NULLIf(txtDiasCarencia.Value, 0))
        Parametro(18) = DBParametro_Montar("ICJUROSAPOSCARENCIA", IIf(chkJurosAposCarencia.Checked, "S", Nothing))
        Parametro(19) = DBParametro_Montar("PCTAXAJUROS", NULLIf(txtTaxaJuros.Value, 0))
        Parametro(20) = DBParametro_Montar("VLTAXA", VlTaxa_Funrural)
        Parametro(21) = DBParametro_Montar("SQNEGOCIACAOPRE", Nothing, , ParameterDirection.Output)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        If DBTeveRetorno() Then
            lblPreNegociacao.Text = DBRetorno(1)

            SqlText = "update sof.negociacao_pre set pc_aliq_icms=" & PC_ALIQ_ICMS & _
            " where SQ_NEGOCIACAO_PRE=" & DBRetorno(1)

            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        Try
            SqlText = DBMontar_SP("SOF.SP_CALCULO_DIFERENCIAL", False, ":CD_CONTRATO_PAF", _
                                                                       ":SQ_NEGOCIACAO", _
                                                                       ":SQ_CONTRATO_FIXO", _
                                                                       ":SQ_PRE_NEGOCIACAO")
            If Not DBExecutar(SqlText, DBParametro_Montar("CD_CONTRATO_PAF", Nothing), _
                                       DBParametro_Montar("SQ_NEGOCIACAO", Nothing), _
                                       DBParametro_Montar("SQ_CONTRATO_FIXO", Nothing), _
                                       DBParametro_Montar("SQ_PRE_NEGOCIACAO", lblPreNegociacao.Text)) Then GoTo Erro
        Catch ex As Exception
        End Try

        If Not DBExecutarTransacao() Then GoTo Erro

        Limpa_Tela()
        txtFornecedor.Focus()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub txtValorUnitarioNegociacao_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorUnitarioPreNegociacao.ValueChanged
        txtValorTotal.Value = 0

        If Not ComboBox_LinhaSelecionada(cboUnidade) Then Exit Sub
        If Not ComboBox_LinhaSelecionada(cboTipoNegociacao) Then Exit Sub

        If eTipoNegociacao.DIFERENCIAL_BOLSA <> cboTipoNegociacao.SelectedValue Then
            txtValorTotal.Value = (txtValorUnitarioPreNegociacao.Value / QtFator) * txtQuantidadePreNegociacao.Value
        End If
    End Sub

    Private Sub cboUnidade_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnidade.SelectedIndexChanged
        QtFator = 0

        If Not ComboBox_LinhaSelecionada(cboUnidade) Then Exit Sub

        QtFator = DBQuery_ValorUnico("select qt_fator  from sof.tipo_unidade where cd_tipo_unidade =" & cboUnidade.SelectedValue)
    End Sub

    Private Sub cboTipoPessoa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPessoa.SelectedIndexChanged
        VlTaxa_Funrural = DBQuery_ValorUnico("SELECT 100 - T.VL_PERCENTUAL_PRECO_BOLSA FROM SOF.TIPO_PESSOA T WHERE T.CD_TIPO_PESSOA = " & cboTipoPessoa.SelectedValue, 0)

       ValidaNecessidadeEstado
    End Sub


    Private Sub ValidaNecessidadeEstado()
        If VlTaxa_Funrural <> 0 And cboLocalEntrega.SelectedValue = eLocalEntrega.Fabrica Then
            cboUF.Visible = True
            lblR_UF.Visible = True
        Else
            cboUF.Visible = False
            lblR_UF.Visible = False
        End If
    End Sub

End Class