Public Class frmCadastroRecuperacaoParcelaRecebimento
    Public SqConfissaoDivida As Integer
    Public NuParcela As Integer
    Dim CdFornecedor As Integer
    Dim icCobraJuros As Boolean
    Dim DtCobraJuros As Date
    Dim Dt_Vencimento As Date
    Dim VlParcela As Double
    Dim QtParcela As Double

    Private Sub frmCadastroRecuperacaoParcelaRecebimento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        optForma_ValueChanged(Nothing, Nothing)
        CarregaDados()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
    Private Sub CarregaDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "select cd_fornecedor,nvl(ic_cobra_juros,'N') as ic_cobra_juros, dt_confissao_divida, dt_cobra_juros from sof.confissao_divida where sq_confissao_divida = " & SqConfissaoDivida
        odata = DBQuery(SqlText)

        CdFornecedor = oData.Rows(0).Item("cd_fornecedor")
        icCobraJuros = IIf(oData.Rows(0).Item("ic_cobra_juros") = "S", True, False)
        If Not objDataTable_CampoVazio(oData.Rows(0).Item("dt_cobra_juros")) Then
            DtCobraJuros = oData.Rows(0).Item("dt_cobra_juros")
        End If
        If icCobraJuros = False Then
            lblDataPagamento.Visible = False
            txtDataPagamento.Visible = False
        End If

        SqlText = "select * from sof.confissao_divida_parcela " & _
                  "where sq_confissao_divida = " & SqConfissaoDivida & _
                  " and nu_parcela=" & NuParcela
        oData = DBQuery(SqlText)

        VlParcela = oData.Rows(0).Item("vl_parcela")
        If IsDate(oData.Rows(0).Item("dt_vencimento")) Then
            Dt_Vencimento = oData.Rows(0).Item("dt_vencimento")
        End If
        QtParcela = oData.Rows(0).Item("qt_item_parcela")
    End Sub

    Private Sub optForma_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optForma.ValueChanged
        Select Case optForma.Value
            Case "D"
                Me.txtDescricaoOutros.Text = ""
                Me.txtDescricaoOutros.Enabled = False
                Me.txtQuantidadeParcela.Value = 1
                Me.txtQuantidadeParcela.Enabled = False
                Me.txtValorParcela.Enabled = True
                Me.cboContratoPAF.Enabled = False
                Me.cboNegociacao.Enabled = False
                Me.cboContratoFixo.Enabled = False
            Case "C"
                Me.txtDescricaoOutros.Text = ""
                Me.txtDescricaoOutros.Enabled = False
                Me.txtQuantidadeParcela.Value = 0
                Me.txtQuantidadeParcela.Enabled = True
                Me.txtValorParcela.Value = 0
                Me.txtValorParcela.Enabled = False
                Me.cboContratoPAF.Enabled = True
                Me.cboNegociacao.Enabled = True
                Me.cboContratoFixo.Enabled = True
            Case "O"
                Me.txtDescricaoOutros.Enabled = True
                Me.txtQuantidadeParcela.Value = 0
                Me.txtQuantidadeParcela.Enabled = True
                Me.txtValorParcela.Enabled = True
                Me.cboContratoPAF.Enabled = False
                Me.cboNegociacao.Enabled = False
                Me.cboContratoFixo.Enabled = False
            Case Else
                Me.txtDescricaoOutros.Text = ""
                Me.txtDescricaoOutros.Enabled = False
                Me.txtQuantidadeParcela.Value = 0
                Me.txtQuantidadeParcela.Enabled = True
                Me.txtValorParcela.Enabled = True
                Me.cboContratoPAF.Enabled = False
                Me.cboNegociacao.Enabled = False
                Me.cboContratoFixo.Enabled = False
        End Select

        Atualiza_Combo_CtrPaf()
    End Sub
    Private Sub Atualiza_Combo_CtrPaf()
        Dim SqlText As String

        Me.cboContratoPAF.DataSource = Nothing
        Me.cboNegociacao.DataSource = Nothing
        Me.cboContratoFixo.DataSource = Nothing

        If optForma.Value <> "C" Then Exit Sub

        If Me.txtQuantidadeParcela.Value <= 0 Then Exit Sub

        SqlText = "select cp.cd_contrato_paf , to_char(cp.cd_contrato_paf) no_contrato_paf " & _
                  "from sof.contrato_paf cp " & _
                  "where cp.cd_fornecedor = " & CdFornecedor & " and " & _
                  "cp.ic_status = 'A' and " & _
                  "cp.qt_kgs = " & Me.txtQuantidadeParcela.Value & " and " & _
                  "cp.qt_cancelado = 0 and " & _
                  "cp.vl_pag_fixo = 0"


        DBCarregarComboBox(cboContratoPAF, SqlText, True)
    End Sub

    Private Sub txtQuantidadeParcela_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantidadeParcela.ValueChanged
        Atualiza_Combo_CtrPaf()
    End Sub

    Private Sub cboContratoPAF_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContratoPAF.SelectedIndexChanged
        Dim SqlText As String

        Me.cboNegociacao.DataSource = Nothing
        Me.cboContratoFixo.DataSource = Nothing

        If Me.txtQuantidadeParcela.Value <= 0 Then
            Atualiza_Combo_CtrPaf()
            Exit Sub
        End If

        SqlText = "select count(*) qt " & _
                  "from sof.contrato_paf cp " & _
                  "where cp.cd_fornecedor = " & CdFornecedor & " and " & _
                  "cp.ic_status = 'A' and " & _
                  "cp.qt_kgs = " & Me.txtQuantidadeParcela.Value & " and " & _
                  "cp.qt_cancelado = 0 and " & _
                  "cp.vl_pag_fixo = 0 and " & _
                  "cp.cd_contrato_paf = " & cboContratoPAF.SelectedValue

        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Contrato PAF invalido.")
            Atualiza_Combo_CtrPaf()
            Exit Sub
        End If

        SqlText = "select n.sq_negociacao, to_char(n.sq_negociacao) as np_negociacao " & _
                  "from sof.negociacao n " & _
                  "where n.cd_contrato_paf = " & cboContratoPAF.SelectedValue & " and " & _
                  "n.ic_status = 'A' and " & _
                  "n.qt_kgs = " & Me.txtQuantidadeParcela.Value & " and " & _
                  "n.qt_cancelado = 0 and " & _
                  "n.vl_pag_fixo = 0"
        DBCarregarComboBox(cboNegociacao, SqlText, True)
    End Sub

    Private Sub cboNegociacao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNegociacao.SelectedIndexChanged
        Dim SqlText As String

        Me.cboContratoFixo.DataSource = Nothing

        If Me.txtQuantidadeParcela.Value <= 0 Then
            Atualiza_Combo_CtrPaf()
            Exit Sub
        End If

        SqlText = "select count(*) qt " & _
                  "from sof.negociacao n " & _
                  "where n.cd_contrato_paf = " & cboContratoPAF.SelectedValue & " and " & _
                  "n.ic_status = 'A' and " & _
                  "n.qt_kgs = " & Me.txtQuantidadeParcela.Value & " and " & _
                  "n.qt_cancelado = 0 and " & _
                  "n.vl_pag_fixo = 0 and " & _
                  "n.sq_negociacao = " & cboNegociacao.SelectedValue

        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Negociação invalida.")
            cboContratoPAF_SelectedIndexChanged(Nothing, Nothing)
            Exit Sub
        End If

        SqlText = "select cf.sq_contrato_fixo, to_char(cf.sq_contrato_fixo) as no_contrato_fixo " & _
                  "from sof.contrato_fixo cf " & _
                  "where cf.cd_contrato_paf = " & cboContratoPAF.SelectedValue & " and " & _
                  "cf.sq_negociacao = " & cboNegociacao.SelectedValue & " and " & _
                  "cf.ic_status = 'A' and " & _
                  "cf.qt_kgs = " & txtQuantidadeParcela.Value & " and " & _
                  "cf.qt_cancelado = 0 and " & _
                  "cf.vl_pag_fixo = 0"

        DBCarregarComboBox(cboContratoFixo, SqlText, True)
    End Sub

    Private Sub cboContratoFixo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContratoFixo.SelectedIndexChanged
        Dim SqlText As String
        Dim VlSaldo As Double

        If Me.txtQuantidadeParcela.Value <= 0 Then
            Atualiza_Combo_CtrPaf()
            Exit Sub
        End If

        SqlText = "select sof.FC_SALDO_CTR_FIX(cf.cd_contrato_paf,cf.sq_negociacao ,cf.sq_contrato_fixo ) vl_total " & _
                  "from sof.contrato_fixo cf " & _
                  "where cf.cd_contrato_paf = " & cboContratoPAF.SelectedValue & " and " & _
                  "cf.sq_negociacao = " & cboNegociacao.SelectedValue & " and " & _
                  "cf.ic_status = 'A' and " & _
                  "cf.qt_kgs = " & Me.txtQuantidadeParcela.Value & " and " & _
                  "cf.qt_cancelado = 0 and " & _
                  "cf.vl_pag_fixo = 0 and " & _
                  "cf.sq_contrato_fixo = " & cboContratoFixo.SelectedValue

        VlSaldo = DBQuery_ValorUnico(SqlText, 0)
        If VlSaldo = 0 Then
            Msg_Mensagem("Contrato Fixo invalido.")
            cboNegociacao_SelectedIndexChanged(Nothing, Nothing)
        Else
            Me.txtValorParcela.Value = VlSaldo
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqAtivo As Long
        Dim SqlText As String
        Dim mVlParcela As Double
        Dim mQtParcela As Double
        Dim SqNovaParcela As Integer
        Dim PcJuros As Integer
        Dim QtDias As Integer
        Dim oData As DataTable

        Select Case optForma.Value
            Case "C"
                If Me.txtQuantidadeParcela.Value <= 0 Then
                    Msg_Mensagem("Quantidade invalida.")
                    Me.txtQuantidadeParcela.Focus()
                    Exit Sub
                End If

                If Not ComboBox_LinhaSelecionada(cboContratoPAF) Then
                    Msg_Mensagem("Favor selecionar um contrato PAF.")
                    Me.cboContratoPAF.Focus()
                    Exit Sub
                End If

                If Not ComboBox_LinhaSelecionada(cboNegociacao) Then
                    Msg_Mensagem("Favor selecionar uma negociação.")
                    Me.cboNegociacao.Focus()
                    Exit Sub
                End If

                If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then
                    Msg_Mensagem("Favor selecionar um contrato fixo.")
                    Me.cboContratoFixo.Focus()
                    Exit Sub
                End If

            Case "D"
            Case "O"
                If Me.txtQuantidadeParcela.Value <= 0 Then
                    Msg_Mensagem("Quantidade invalida.")
                    Me.txtQuantidadeParcela.Focus()
                    Exit Sub
                End If

                If Me.txtDescricaoOutros.Text = "" Then
                    Msg_Mensagem("Favor informar uma descrição.")
                    Me.txtDescricaoOutros.Focus()
                    Exit Sub
                End If
            Case Else
                Msg_Mensagem("Favor selecionar uma forma.")
                Exit Sub
        End Select

        If Me.txtValorParcela.Value <= 0 Then
            Msg_Mensagem("Valor invalido.")
            Me.txtValorParcela.Focus()
            Exit Sub
        End If

        'se for juros retiro a parte do juros
        If icCobraJuros = True Then
            If Not IsDate(Me.txtDataPagamento.Text) Then
                Msg_Mensagem("Data de pagamento invalida.")
                Me.txtDataPagamento.Focus()
                Exit Sub
            End If
            SqlText = "select * from sof.confissao_divida where sq_confissao_divida=" & SqConfissaoDivida
            oData = DBQuery(SqlText)

            QtDias = DateDiff(DateInterval.Day, CDate(txtDataPagamento.Text), DtCobraJuros)

            mVlParcela = (txtValorParcela.Value * 100) / (100 + (QtDias * (NVL(oData.Rows(0).Item("PC_JUROS_AO_MES"), 0) / 30)))
            mQtParcela = txtQuantidadeParcela.Value
            PcJuros = NVL(oData.Rows(0).Item("PC_JUROS_AO_MES"), 0)
        Else
            mVlParcela = txtValorParcela.Value
            mQtParcela = txtQuantidadeParcela.Value
        End If

 

        SqlText = "select * from sof.confissao_divida_parcela where sq_confissao_divida=" & SqConfissaoDivida & " and " & _
       " nu_parcela = " & NuParcela
        oData = DBQuery(SqlText)

        DBUsarTransacao = True

        '=======Inclui parcela com juros
        If icCobraJuros = True Then
            SqlText = DBMontar_SP("SOF.SP_INCLUI_CONF_DIV_PARCELA", False, ":SQCONFISSAODIVIDA", _
                                           ":ICSITUACAO", _
                                           ":ICCACAU", _
                                           ":ICMOEDA", _
                                           ":ICOUTROS", _
                                           ":DSOUTROS", _
                                           ":DTVENCIMENTO", _
                                           ":VLPARCELA", _
                                           ":QTITEMPARCELA", _
                                           ":NUPARCELAANTERIOR", _
                                           ":NUPARCELA")

            If Not DBExecutar(SqlText, DBParametro_Montar("SQCONFISSAODIVIDA", SqConfissaoDivida), _
                                       DBParametro_Montar("ICSITUACAO", "A"), _
                                       DBParametro_Montar("ICCACAU", "N"), _
                                       DBParametro_Montar("ICMOEDA", "S"), _
                                       DBParametro_Montar("ICOUTROS", "N"), _
                                       DBParametro_Montar("DSOUTROS", "Juros " & PcJuros & "% ao mês."), _
                                       DBParametro_Montar("DTVENCIMENTO", Date_to_Oracle(Dt_Vencimento), OracleClient.OracleType.DateTime), _
                                       DBParametro_Montar("VLPARCELA", txtValorParcela.Value - mVlParcela), _
                                       DBParametro_Montar("QTITEMPARCELA", IIf(optForma.Value = "D", 1, IIf(txtQuantidadeParcela.Value - mQtParcela <= 0, 1, txtQuantidadeParcela.Value - mQtParcela))), _
                                       DBParametro_Montar("NUPARCELAANTERIOR", NuParcela), _
                                       DBParametro_Montar("NUPARCELA", Nothing, , ParameterDirection.Output)) Then GoTo Erro

  
            If DBTeveRetorno() Then
                SqNovaParcela = DBRetorno(1)
            End If

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CONF_DIV_ATIVO", False, ":SQCONFISSAODIVIDA", _
                               ":NUPARCELA", _
                               ":ICSITUACAO", _
                               ":ICCACAU", _
                               ":ICMOEDA", _
                               ":ICOUTROS", _
                               ":DSOUTROS", _
                               ":VLATIVO", _
                               ":QTATIVO", _
                               ":SQATIVO")

            If Not DBExecutar(SqlText, DBParametro_Montar("SQCONFISSAODIVIDA", SqConfissaoDivida), _
                                       DBParametro_Montar("NUPARCELA", SqNovaParcela), _
                                       DBParametro_Montar("ICSITUACAO", "A"), _
                                       DBParametro_Montar("ICCACAU", "N"), _
                                       DBParametro_Montar("ICMOEDA", "S"), _
                                       DBParametro_Montar("ICOUTROS", "N"), _
                                       DBParametro_Montar("DSOUTROS", "Juros " & PcJuros & "% ao mês."), _
                                       DBParametro_Montar("VLATIVO", txtValorParcela.Value - mVlParcela), _
                                       DBParametro_Montar("QTATIVO", 0), _
                                       DBParametro_Montar("SQATIVO", Nothing, , ParameterDirection.Output)) Then GoTo Erro

            If DBTeveRetorno() Then
                SqAtivo = DBRetorno(1)
            End If

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CONF_DIV_ATIVO_VENDA", False, ":SQATIVO", _
                   ":VLATIVO", _
                   ":QTATIVO", _
                   ":CDCTRPAF", _
                   ":SQNEG", _
                   ":SQCTRFIX")

            If Not DBExecutar(SqlText, DBParametro_Montar("SQATIVO", SqAtivo), _
                                       DBParametro_Montar("VLATIVO", txtValorParcela.Value - mVlParcela), _
                                       DBParametro_Montar("QTATIVO", 0), _
                                       DBParametro_Montar("CDCTRPAF", Nothing), _
                                       DBParametro_Montar("SQNEG", Nothing), _
                                       DBParametro_Montar("SQCTRFIX", Nothing)) Then GoTo Erro
        End If
        '===termina juros


        If Me.txtValorParcela.Value <> VlParcela And oData.Rows(0).Item("IC_CACAU") = "N" Then

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CONF_DIV_PARCELA", False, ":SQCONFISSAODIVIDA", _
                               ":ICSITUACAO", _
                               ":ICCACAU", _
                               ":ICMOEDA", _
                               ":ICOUTROS", _
                               ":DSOUTROS", _
                               ":DTVENCIMENTO", _
                               ":VLPARCELA", _
                               ":QTITEMPARCELA", _
                               ":NUPARCELAANTERIOR", _
                               ":NUPARCELA")

            If Not DBExecutar(SqlText, DBParametro_Montar("SQCONFISSAODIVIDA", SqConfissaoDivida), _
                                       DBParametro_Montar("ICSITUACAO", "A"), _
                                       DBParametro_Montar("ICCACAU", oData.Rows(0).Item("IC_CACAU")), _
                                       DBParametro_Montar("ICMOEDA", oData.Rows(0).Item("IC_MOEDA")), _
                                       DBParametro_Montar("ICOUTROS", oData.Rows(0).Item("IC_OUTROS")), _
                                       DBParametro_Montar("DSOUTROS", Nothing), _
                                       DBParametro_Montar("DTVENCIMENTO", Date_to_Oracle(Dt_Vencimento), OracleClient.OracleType.DateTime), _
                                       DBParametro_Montar("VLPARCELA", VlParcela - mVlParcela), _
                                       DBParametro_Montar("QTITEMPARCELA", IIf(optForma.Value = "D", 1, IIf(QtParcela - mQtParcela <= 0, 1, QtParcela - mQtParcela))), _
                                       DBParametro_Montar("NUPARCELAANTERIOR", NuParcela), _
                                       DBParametro_Montar("NUPARCELA", Nothing, , ParameterDirection.Output)) Then GoTo Erro



            Select Case optForma.Value
                Case "C", "O"
                    SqlText = "update sof.confissao_divida_parcela " & _
                              "set vl_parcela = " & mVlParcela & ", " & _
                              "qt_item_parcela = " & mQtParcela & " " & _
                              "where sq_confissao_divida = " & SqConfissaoDivida & " and " & _
                              "nu_parcela = " & NuParcela
                Case "D"
                    SqlText = "update sof.confissao_divida_parcela " & _
                              "set vl_parcela = " & mVlParcela & " " & _
                              "where sq_confissao_divida = " & SqConfissaoDivida & " and " & _
                              "nu_parcela = " & NuParcela
            End Select
            If Not DBExecutar(SqlText) Then GoTo erro
        End If

        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONF_DIV_ATIVO", False, ":SQCONFISSAODIVIDA", _
                   ":NUPARCELA", _
                   ":ICSITUACAO", _
                   ":ICCACAU", _
                   ":ICMOEDA", _
                   ":ICOUTROS", _
                   ":DSOUTROS", _
                   ":VLATIVO", _
                   ":QTATIVO", _
                   ":SQATIVO")

        If Not DBExecutar(SqlText, DBParametro_Montar("SQCONFISSAODIVIDA", SqConfissaoDivida), _
                                   DBParametro_Montar("NUPARCELA", NuParcela), _
                                   DBParametro_Montar("ICSITUACAO", "A"), _
                                   DBParametro_Montar("ICCACAU", IIf(optForma.Value = "C", "S", "N")), _
                                   DBParametro_Montar("ICMOEDA", IIf(optForma.Value = "D", "S", "N")), _
                                   DBParametro_Montar("ICOUTROS", IIf(optForma.Value = "O", "S", "N")), _
                                   DBParametro_Montar("DSOUTROS", IIf(optForma.Value = "O", Me.txtDescricaoOutros.Text, Nothing)), _
                                   DBParametro_Montar("VLATIVO", mVlParcela), _
                                   DBParametro_Montar("QTATIVO", mQtParcela), _
                                   DBParametro_Montar("SQATIVO", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        If DBTeveRetorno() Then
            SqAtivo = DBRetorno(1)
        End If


        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONF_DIV_ATIVO_VENDA", False, ":SQATIVO", _
                                                                ":VLATIVO", _
                                                                ":QTATIVO", _
                                                                ":CDCTRPAF", _
                                                                ":SQNEG", _
                                                                ":SQCTRFIX")

        If Not DBExecutar(SqlText, DBParametro_Montar("SQATIVO", SqAtivo), _
                                   DBParametro_Montar("VLATIVO", mVlParcela), _
                                   DBParametro_Montar("QTATIVO", mQtParcela), _
                                   DBParametro_Montar("CDCTRPAF", IIf(optForma.Value = "O", cboContratoPAF.SelectedValue, Nothing)), _
                                   DBParametro_Montar("SQNEG", IIf(optForma.Value = "O", cboNegociacao.SelectedValue, Nothing)), _
                                   DBParametro_Montar("SQCTRFIX", IIf(optForma.Value = "O", cboContratoFixo.SelectedValue, Nothing))) Then GoTo Erro


        If Not DBExecutarTransacao() Then GoTo Erro

        Me.Close()

        Exit Sub
Erro:
        TratarErro()
    End Sub
End Class