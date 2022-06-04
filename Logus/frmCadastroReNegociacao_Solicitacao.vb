Imports Logus.MOD_Declaracao_Local

Public Class frmCadastroReNegociacao_Solicitacao
    Public CD_CONTRATO_PAF As Integer
    Public SQ_NEGOCIACAO As Integer

    Dim PC_JUROS As Double
    Dim Valor_Solicitado_Credito As Double
    Dim Valor_Saldo_Credito As Double
    Dim BONUS As Boolean

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cboLocalEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocalEntrega.SelectedIndexChanged
        ComboBox_LocalEntrega_Validar()
    End Sub

    Private Sub ComboBox_LocalEntrega_Validar()
        Dim iFilialEntrega As Long

        If Not ComboBox_LinhaSelecionada(cboLocalEntrega) Then Exit Sub

        iFilialEntrega = NVL(cboFilialEntrega.SelectedValue, 0)

        ComboBox_Possicionar(cboFilialEntrega, FilialLogada)

        If iFilialEntrega = FilialLogada Then ComboBox_FilialEntrega_Validar()

        Select Case cboLocalEntrega.SelectedValue
            Case cnt_LocalEntrega_Fazenda
                cboFilialEntrega.Enabled = True
            Case cnt_LocalEntrega_Filial
                cboFilialEntrega.Enabled = True
            Case cnt_LocalEntrega_Fabrica
                cboFilialEntrega.Enabled = False
        End Select
    End Sub

    Private Sub frmCadastroReNegociacao_Solicitacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oData As DataTable
        Dim SqlText As String
        Dim iCont As Integer

        Pegar_Juros_Padrao()

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        Pesq_Repassador.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        Pesq_Fornecedor.Enabled = False
        Pesq_Repassador.Enabled = False

        ComboBox_Carregar_Filial_Entrega(cboFilialEntrega)
        ComboBox_Carregar_Local_Entrega(cboLocalEntrega, True)
        ComboBox_Carregar_Tipo_Cacau(cboTipoCacau, True)
        ComboBox_Carregar_Tipo_Negociacao(cboTipoNegociacao, True)
        ComboBox_Carregar_Tipo_Pessoa(cboTipoPessoa, True, True)
        ComboBox_Carregar_Tipo_Unidade(cboUnidade, True)

        Pegar_Juros_Padrao()

        SqlText = "SELECT F.NO_RAZAO_SOCIAL," & _
                         "CP.CD_FORNECEDOR," & _
                         "CP.CD_REPASSADOR," & _
                         "R.NO_RAZAO_SOCIAL NO_REPASSADOR," & _
                         "F.CD_FILIAL_ORIGEM," & _
                         "F.CD_TIPO_PESSOA," & _
                         "R.CD_TIPO_PESSOA CD_TIPO_PESSOA_REPASSADOR," & _
                         "CP.CD_FILIAL_ENTREGA," & _
                         "N.CD_TIPO_NEGOCIACAO," & _
                         "N.CD_TIPO_PRECO," & _
                         "N.CD_TIPO_UNIDADE," & _
                         "N.QT_KGS," & _
                         "N.VL_NEGOCIACAO," & _
                         "N.CD_LOCAL_ENTREGA," & _
                         "N.DT_VENCIMENTO," & _
                         "N.DT_PAGAMENTO," & _
                         "N.VL_PRECO_FRETE," & _
                         "N.PC_ALIQ_ICMS," & _
                         "N.IC_BONUS," & _
                         "N.QT_KG_FIXO," & _
                         "N.QT_A_FIXAR," & _
                         "N.QT_CANCELADO," & _
                         "N.PC_TAXA_JUROS," & _
                         "N.DT_PRAZO_FIXACAO," & _
                         "TN.IC_TIPO_PRECO_FIXO," & _
                         "N.QT_EM_RENEGOCIACAO," & _
                         "N.CD_PAPEL_COMPETENCIA," & _
                         "N.QT_UMIDADE_PADRAO," & _
                         "N.PC_SUJIDADE_PADRAO," & _
                         "N.IC_CALCULA_JUROS," & _
                         "N.QT_DIA_CARENCIA_JUROS," & _
                         "N.IC_JUROS_APOS_CARENCIA," & _
                         "N.CD_TIPO_CACAU," & _
                         "N.CD_FILIAL_ENTREGA" & _
                  " FROM SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR R," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.NEGOCIACAO N," & _
                        "SOF.TIPO_NEGOCIACAO TN " & _
                  " WHERE CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND CP.CD_REPASSADOR = R.CD_FORNECEDOR" & _
                    " AND CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                    " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                    " AND N.IC_STATUS = 'A'" & _
                    " AND N.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND N.SQ_NEGOCIACAO = " & SQ_NEGOCIACAO
        oData = DBQuery(SqlText)

        If oData.Rows.Count = 0 Then
            Msg_Mensagem("Algum usuário do sistema eliminou a negociação")
            Exit Sub
        End If

        lblNrContrato.Text = Trim(CD_CONTRATO_PAF) & "-" & Trim(SQ_NEGOCIACAO)
        lblData.Text = DataSistema()

        With oData.Rows(0)
            lblSaldo.Text = .Item("QT_KGS") - .Item("QT_CANCELADO") - .Item("QT_EM_RENEGOCIACAO") - .Item("QT_KG_FIXO")

            If NVL(.Item("IC_TIPO_PRECO_FIXO"), "N") = "N" Then
                If Val(lblSaldo.Text) > NVL(.Item("QT_A_FIXAR"), 0) Then
                    lblSaldo.Text = NVL(.Item("QT_A_FIXAR"), 0)
                End If
            End If

            Pesq_Fornecedor.Codigo = .Item("CD_FORNECEDOR")
            Pesq_Repassador.Codigo = NVL(.Item("CD_REPASSADOR"), 0)
            txtAliquotaICMS.Value = NVL(.Item("PC_ALIQ_ICMS"), 0)
            txtTaxaJuros.Value = CDbl(NVL(.Item("PC_TAXA_JUROS"), 0))
            txtQuantidadeNegociacao.Value = Val(lblSaldo.Text)
            ComboBox_Possicionar(cboUnidade, .Item("CD_TIPO_UNIDADE"))
            txtDataVencimento.DateTime = .Item("DT_VENCIMENTO")
            txtDataPagamento.DateTime = .Item("DT_PAGAMENTO")

            ComboBox_Possicionar(cboLocalEntrega, .Item("CD_LOCAL_ENTREGA"))
            ComboBox_LocalEntrega_Validar()
            ComboBox_Possicionar(cboFilialEntrega, .Item("CD_FILIAL_ENTREGA"))
            ComboBox_FilialEntrega_Validar()
            ComboBox_Possicionar(cboTipoNegociacao, .Item("CD_TIPO_NEGOCIACAO"))
            ComboBox_TipoNegociacao_Validar()

            If NVL(.Item("IC_TIPO_PRECO_FIXO"), "N") = "N" Then
                cboBolsa.SelectedIndex = -1

                For iCont = 0 To cboBolsa.Items.Count - 1
                    'If Mid(cboBolsa.Items(iCont)(1), 1, InStr(1, cboBolsa.Items(iCont)(1), " | ") - 1) = .Item("CD_PAPEL_COMPETENCIA") Then
                    If cboBolsa.Items(iCont)(0) = .Item("CD_PAPEL_COMPETENCIA") Then
                        cboBolsa.SelectedIndex = iCont
                        Exit For
                    End If
                Next

                If Not CampoNulo(.Item("DT_PRAZO_FIXACAO")) Then
                    txtDataPrazoFixacao.DateTime = .Item("DT_PRAZO_FIXACAO")
                End If
            End If

            txtValorUnitarioNegociacao.Value = .Item("VL_NEGOCIACAO")
            txtValorFrete.Value = .Item("VL_PRECO_FRETE")
            Calcula_Valor_Total()

            BONUS = (NVL(.Item("IC_BONUS"), "N") = "S")

            txtUmidadePadrao.Value = CDbl(NVL(.Item("QT_UMIDADE_PADRAO"), 8))
            txtSujidadePadrao.Value = CDbl(NVL(.Item("PC_SUJIDADE_PADRAO"), 0.5))
            ComboBox_Possicionar(cboTipoCacau, .Item("CD_TIPO_CACAU"))

            If .Item("IC_CALCULA_JUROS") = "S" Then
                chkCobraJuros.Checked = True
                ComboBox_CobraJuros_Validar()
                txtDiasCarencia.Value = NVL(.Item("QT_DIA_CARENCIA_JUROS"), 0)
                chkJurosAposCarencia.Checked = (NVL(.Item("IC_JUROS_APOS_CARENCIA"), "N") = "S")
                txtTaxaJuros.Value = NVL(.Item("PC_TAXA_JUROS"), 0)
            Else
                chkCobraJuros.Checked = False
                ComboBox_CobraJuros_Validar()
            End If
        End With

        objData_Finalizar(oData)

        Me.Text = Me.Text & " - Contrato Nº: " & Trim(CD_CONTRATO_PAF) & "-" & Trim(SQ_NEGOCIACAO)
    End Sub

    Private Sub cboFilialEntrega_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFilialEntrega.SelectedIndexChanged
        ComboBox_FilialEntrega_Validar()
    End Sub

    Private Sub ComboBox_FilialEntrega_Validar()
        If Not ComboBox_LinhaSelecionada(cboFilialEntrega) Then Exit Sub
        If Not ComboBox_LinhaSelecionada(cboLocalEntrega) Then Exit Sub

        txtValorFrete.Value = 0

        With cboFilialEntrega
            Select Case cboLocalEntrega.SelectedValue
                Case cnt_LocalEntrega_Fazenda
                    txtValorFrete.Value = NVL(.SelectedItem(ComboBox_FilialEntrega_Info.VL_FRETE_FILIAL_FABRICA), 0) + NVL(.SelectedItem(ComboBox_FilialEntrega_Info.VL_FRETE_FILIAL_FAZENDA), 0)
                Case cnt_LocalEntrega_Filial
                    txtValorFrete.Value = NVL(.SelectedItem(ComboBox_FilialEntrega_Info.VL_FRETE_FILIAL_FABRICA), 0)
                Case cnt_LocalEntrega_Fabrica
                    txtValorFrete.Value = NVL(.SelectedItem(ComboBox_FilialEntrega_Info.VL_FRETE_FABRICA), 0)
            End Select
        End With
    End Sub

    Private Sub cboTipoNegociacao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoNegociacao.SelectedIndexChanged
        ComboBox_TipoNegociacao_Validar()
    End Sub

    Private Sub ComboBox_TipoNegociacao_Validar()
        Limpa_Bolsa()

        If Not ComboBox_LinhaSelecionada(cboTipoNegociacao) Then
            Exit Sub
        End If

        Select Case cboTipoNegociacao.SelectedValue
            Case cnt_TIPO_NEGOCIACAO_DiferencialBolsa
                lblR_Bolsa.Enabled = True
                cboBolsa.Enabled = True

                ComboBox_Carregar_PeriodoBolsa(cboBolsa, False, False)

                lblR_PrazoFixacao.Enabled = True
                txtDataPrazoFixacao.Enabled = True
            Case cnt_TIPO_NEGOCIACAO_FixoEmDolar
                lblR_PrazoFixacao.Enabled = True
                txtDataPrazoFixacao.Enabled = True
        End Select

        Verifica_Data_Vencimento_Padrao()
    End Sub

    Private Sub Limpa_Bolsa()
        cboBolsa.DataSource = Nothing
        lblR_Bolsa.Enabled = False
        cboBolsa.Enabled = False

        lblR_PrazoFixacao.Enabled = False
        txtDataPrazoFixacao.Enabled = False
    End Sub

    Private Sub Verifica_Data_Vencimento_Padrao()
        If Not IsDate(txtDataVencimento.Text) Then Exit Sub
        If Not ComboBox_LinhaSelecionada(cboTipoNegociacao) Then Exit Sub

        Dim DtVencPadrao As Date

        DtVencPadrao = CDate(DataSistema()).AddDays(NVL(cboTipoNegociacao.SelectedItem(ComboBox_TipoNegociacao_Info.QT_DIA_VENC_PADRAO), 0))

        If DtVencPadrao < txtDataVencimento.DateTime.Date Then
            lblR_MotivoDataVencimentoAvancada.Enabled = True
            txtMotivoDataVencimentoAvancada.Enabled = True
        Else
            lblR_MotivoDataVencimentoAvancada.Enabled = False
            txtMotivoDataVencimentoAvancada.Text = ""
            txtMotivoDataVencimentoAvancada.Enabled = False
        End If
    End Sub

    Private Sub chkCobraJuros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCobraJuros.CheckedChanged
        ComboBox_CobraJuros_Validar()
    End Sub

    Private Sub ComboBox_CobraJuros_Validar()
        If chkCobraJuros.Checked = True Then
            txtDiasCarencia.Enabled = True
            txtDiasCarencia.Value = 0
            txtTaxaJuros.Enabled = True
            txtTaxaJuros.Value = PC_JUROS
            chkJurosAposCarencia.Checked = True
        Else
            txtDiasCarencia.Value = 0
            txtDiasCarencia.Enabled = False
            txtTaxaJuros.Value = 0
            txtTaxaJuros.Enabled = False
            chkJurosAposCarencia.Checked = True
        End If
    End Sub

    Private Sub Pegar_Juros_Padrao()
        Dim SqlText As String

        SqlText = "SELECT PC_JUROS_AO_MES FROM SOF.PARAMETRO"

        With DBQuery(SqlText)
            If .Rows.Count <> 0 Then
                PC_JUROS = NVL(.Rows(0).Item("PC_JUROS_AO_MES"), 0)
            Else
                PC_JUROS = 0
            End If
        End With
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim oData As DataTable
        Dim SqlText As String
        Dim mValor As Long
        Dim dDataSistema As Date

        On Error GoTo Erro

        dDataSistema = CDate(DataSistema())

        If txtQuantidadeNegociacao.Value <= 0 Then
            Msg_Mensagem("Favor informar a quantidade em quilos da negociação acima de 0.")
            txtQuantidadeNegociacao.Focus()
            Exit Sub
        End If
        If txtQuantidadeNegociacao.Value > Val(lblSaldo.Text) Then
            Msg_Mensagem("Favor informar uma quantidade menor do que " & Format(Val(lblSaldo.Text), "#,##0"))
            txtQuantidadeNegociacao.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboUnidade) Then
            Msg_Mensagem("Favor escolher uma unidade para a negociação.")
            cboUnidade.Focus()
            Exit Sub
        End If
        If Not IsDate(txtDataVencimento.Text) Then
            Msg_Mensagem("Data de vencimento inválida.")
            txtDataVencimento.Focus()
            Exit Sub
        End If
        If txtDataVencimento.DateTime.Date < dDataSistema Then
            Msg_Mensagem("Data de vencimento menor que a data atual")
            txtDataVencimento.Focus()
            Exit Sub
        End If
        If Not IsDate(txtDataPagamento.Text) Then
            Msg_Mensagem("Data de pagamento inválida.")
            txtDataPagamento.Focus()
            Exit Sub
        End If
        If CDate(txtDataPagamento.Text) < dDataSistema Then
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
        If txtValorUnitarioNegociacao.Value = 0 Then
            Msg_Mensagem("Favor informar um valor unitário.")
            txtValorUnitarioNegociacao.Focus()
            Exit Sub
        End If
        If lblR_Bolsa.Enabled = True Then
            If cboBolsa.SelectedIndex = -1 Then
                Msg_Mensagem("Favor selecionar uma bolsa.")
                cboBolsa.Focus()
                Exit Sub
            End If
        End If
        If txtMotivoDataVencimentoAvancada.Enabled = True Then
            If txtMotivoDataVencimentoAvancada.Text = "" Then
                Msg_Mensagem("Favor informar o motivo da data de vencimento fora do padrão.")
                txtMotivoDataVencimentoAvancada.Focus()
                Exit Sub
            End If
        End If
        If txtDataPrazoFixacao.Enabled = True Then
            If Not IsDate(txtDataPrazoFixacao.Text) Then
                Msg_Mensagem("Prazo de fixação inválido.")
                txtDataPrazoFixacao.Focus()
                Exit Sub
            End If
            If CDate(txtDataPrazoFixacao.Text) <= dDataSistema Then
                Msg_Mensagem("Prazo de fixação inferior ou igual a hoje.")
                txtDataPrazoFixacao.Focus()
                Exit Sub
            End If
            If CDate(txtDataPrazoFixacao.Text) > CDate(txtDataVencimento.Text) Then
                Msg_Mensagem("Prazo de fixação superior a data de vencimento.")
                txtDataPrazoFixacao.Focus()
                Exit Sub
            End If
        End If
        If txtUmidadePadrao.Value < 0 Then
            Msg_Mensagem("Umidade inválida.")
            txtUmidadePadrao.Focus()
            Exit Sub
        End If
        If txtSujidadePadrao.Value < 0 Then
            Msg_Mensagem("Sujidade inválida.")
            txtSujidadePadrao.Focus()
            Exit Sub
        End If

        If Not Limite_Valido() Then
            Exit Sub
        End If

        DBUsarTransacao = True

        AVI_Carregar(Me)

        Inclui_ReNegociacao()

        If Not DBExecutarTransacao() Then GoTo Erro

        AVI_Fechar(Me)

        Close()

        Exit Sub

Erro:
        DBUsarTransacao = False
        AVI_Fechar(Me)

        TratarErro(, , "frmCadastroReNegociacao_Solicitacao.cmdGravar_Click")
    End Sub

    Private Function Limite_Valido() As Boolean
        Const cnt_DBParametro_PCALIQINSS As Integer = 1
        Const cnt_DBParametro_VLSALDO As Integer = 2
        Const cnt_DBParametro_VLLCMOEDA As Integer = 3
        Const cnt_DBParametro_VLBOLSA As Integer = 4
        Const cnt_DBParametro_VLPRECOCACAU As Integer = 8

        Dim SqlText As String

        Dim Valor_Solicitado As Double
        Dim Valor_ICMS As Double
        Dim Valor_PrecoCacau As Double

        Dim bOk As Boolean = False

        Select Case cboTipoNegociacao.SelectedItem(ComboBox_TipoNegociacao_Info.CD_TIPO)
            Case cnt_TIPO_NEGOCIACAO_FixoEmReal
                Valor_Solicitado = (txtValorUnitarioNegociacao.Value / cboUnidade.SelectedItem(ComboBox_TipoUnidade_Info.QT_FATOR))
            Case cnt_TIPO_NEGOCIACAO_FixoEmDolar
                Valor_Solicitado = (txtValorUnitarioNegociacao.Value / cboUnidade.SelectedItem(ComboBox_TipoUnidade_Info.QT_FATOR))
            Case cnt_TIPO_NEGOCIACAO_DiferencialBolsa
                Valor_Solicitado = txtValorUnitarioNegociacao.Value
        End Select

        SqlText = DBMontar_SP("SOF.SP_SALDO_FORNECEDOR", False, ":CDFORN", _
                                                                ":ICNEG", _
                                                                ":VLUNITARIO", _
                                                                ":ICFIXONEG", _
                                                                ":ICDOLARNEG", _
                                                                ":ICBOLSANEG", _
                                                                ":ICBOLSAOPERACAONEG", _
                                                                ":PCALIQINSS", _
                                                                ":VLSALDO", _
                                                                ":VLLCMOEDA", _
                                                                ":VLBOLSA", _
                                                                ":VLLIMITECREDITO", _
                                                                ":VLAORDEM", _
                                                                ":VLPAGAB", _
                                                                ":Valor_PrecoCacau", _
                                                                ":QTAORDEM", _
                                                                ":VLJUROS", _
                                                                ":VLCONFDIV", _
                                                                ":VLICMSNFCOMP")

        DBExecutar(SqlText, DBParametro_Montar("CDFORN", Pesq_Fornecedor.Codigo), _
                            DBParametro_Montar("ICNEG", "S"), _
                            DBParametro_Montar("VLUNITARIO", Valor_Solicitado), _
                            DBParametro_Montar("ICFIXONEG", NVL(cboTipoNegociacao.SelectedItem(ComboBox_TipoNegociacao_Info.IC_TIPO_PRECO_FIXO), "N")), _
                            DBParametro_Montar("ICDOLARNEG", NVL(cboTipoNegociacao.SelectedItem(ComboBox_TipoNegociacao_Info.IC_DOLAR), "N")), _
                            DBParametro_Montar("ICBOLSANEG", NVL(cboTipoNegociacao.SelectedItem(ComboBox_TipoNegociacao_Info.IC_BOLSA), "N")), _
                            DBParametro_Montar("ICBOLSAOPERACAONEG", NVL(cboTipoNegociacao.SelectedItem(ComboBox_TipoNegociacao_Info.IC_BOLSA_OPERACAO), "")), _
                            DBParametro_Montar("PCALIQINSS", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("VLSALDO", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("VLLCMOEDA", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("VLBOLSA", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("VLLIMITECREDITO", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("VLAORDEM", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("VLPAGAB", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("Valor_PrecoCacau", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("QTAORDEM", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("VLJUROS", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("VLCONFDIV", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("VLICMSNFCOMP", Nothing, , ParameterDirection.Output))

        Valor_ICMS = (DBRetorno(cnt_DBParametro_VLPRECOCACAU) / (1 - ((txtAliquotaICMS.Value / 100) + DBRetorno(cnt_DBParametro_PCALIQINSS)))) * (txtAliquotaICMS.Value / 100)
        Valor_PrecoCacau = DBRetorno(cnt_DBParametro_VLPRECOCACAU) + Valor_ICMS

        Select Case cboTipoNegociacao.SelectedItem(ComboBox_TipoNegociacao_Info.CD_TIPO)
            Case cnt_TIPO_NEGOCIACAO_FixoEmReal
                Valor_Solicitado = (txtValorUnitarioNegociacao.Value / cboUnidade.SelectedItem(ComboBox_TipoUnidade_Info.QT_FATOR))
            Case cnt_TIPO_NEGOCIACAO_FixoEmDolar
                Valor_Solicitado = ((txtValorUnitarioNegociacao.Value / cboUnidade.SelectedItem(ComboBox_TipoUnidade_Info.QT_FATOR)) * DBRetorno(cnt_DBParametro_VLLCMOEDA))
            Case cnt_TIPO_NEGOCIACAO_DiferencialBolsa
                Select Case cboTipoNegociacao.SelectedItem(ComboBox_TipoNegociacao_Info.IC_BOLSA_OPERACAO)
                    Case "+"
                        Valor_Solicitado = (((DBRetorno(cnt_DBParametro_VLBOLSA) + txtValorUnitarioNegociacao.Value) * DBRetorno(cnt_DBParametro_VLLCMOEDA)) / 1000)
                    Case "-"
                        Valor_Solicitado = (((DBRetorno(cnt_DBParametro_VLBOLSA) - txtValorUnitarioNegociacao.Value) * DBRetorno(cnt_DBParametro_VLLCMOEDA)) / 1000)
                    Case "*"
                        Valor_Solicitado = (((DBRetorno(cnt_DBParametro_VLBOLSA) * txtValorUnitarioNegociacao.Value) * DBRetorno(cnt_DBParametro_VLLCMOEDA)) / 1000)
                    Case "/"
                        Valor_Solicitado = (((DBRetorno(cnt_DBParametro_VLBOLSA) / txtValorUnitarioNegociacao.Value) * DBRetorno(cnt_DBParametro_VLLCMOEDA)) / 1000)
                End Select
        End Select

        Valor_ICMS = (Valor_Solicitado / (1 - ((txtAliquotaICMS.Value / 100) + DBRetorno(cnt_DBParametro_PCALIQINSS)))) * (txtAliquotaICMS.Value / 100)
        Valor_Solicitado = Valor_Solicitado + Valor_ICMS
        Valor_Solicitado_Credito = (Valor_PrecoCacau - Valor_Solicitado) * txtQuantidadeNegociacao.Value
        Valor_Saldo_Credito = DBRetorno(cnt_DBParametro_VLSALDO)

        If Valor_Solicitado_Credito > 0 Then
            If Valor_Solicitado_Credito > Valor_Saldo_Credito Then
                If Not Msg_Perguntar("O fornecedor esta com o limite estourado." & vbCrLf & " Continua a solicitação ?") Then
                    GoTo Sair
                End If
            End If
        End If

        bOk = True

Sair:
        Return bOk
    End Function

    Private Function Inclui_ReNegociacao() As Boolean
        Dim SqlText As String
        Dim bOk As Boolean = False
        Dim oParamentro(30) As DBParamentro

        On Error GoTo Erro

        SqlText = DBMontar_SP("SOF.SP_INCLUI_RENEGOCIACAO", False, ":CDCONTRATOPAF", _
                                                                   ":SQNEGOCIACAO", _
                                                                   ":CDTIPONEGOCIACAO", _
                                                                   ":CDTIPOUNIDADE", _
                                                                   ":DTNEGOCIACAO", _
                                                                   ":QTKGS", _
                                                                   ":VLNEGOCIACAO", _
                                                                   ":CDLOCALENTREGA", _
                                                                   ":DTVENCIMENTO", _
                                                                   ":DTPAGAMENTO", _
                                                                   ":VLPRECOFRETE", _
                                                                   ":PCALIQICMS", _
                                                                   ":ICBONUS", _
                                                                   ":CDPAPELCOMPETENCIA", _
                                                                   ":SQBOLSAGRUPOPREMIO", _
                                                                   ":CDTIPOPESSOA", _
                                                                   ":DSMOTIVODTVENC", _
                                                                   ":DSMOTIVORENEGOCIACAO", _
                                                                   ":DTPRAZOFIXACAO", _
                                                                   ":PCTAXAJUROS", _
                                                                   ":VLLIMITECREDITO", _
                                                                   ":VLCREDITOSOLICITADO", _
                                                                   ":QTUMIDADEPADRAO", _
                                                                   ":PCSUJIDADEPADRAO", _
                                                                   ":VLFRETEFABRICA", _
                                                                   ":CDTIPOCACAU", _
                                                                   ":CDFILIALENTREGA", _
                                                                   ":ICCALCULAJUROS", _
                                                                   ":QTDIACARENCIAJUROS", _
                                                                   ":ICJUROSAPOSCARENCIA", _
                                                                   ":SQSOLICITACAO")

        oParamentro(0) = DBParametro_Montar("CDCONTRATOPAF", CD_CONTRATO_PAF)
        oParamentro(1) = DBParametro_Montar("SQNEGOCIACAO", SQ_NEGOCIACAO)
        oParamentro(2) = DBParametro_Montar("CDTIPONEGOCIACAO", cboTipoNegociacao.SelectedItem(ComboBox_TipoNegociacao_Info.CD_TIPO_NEGOCIACAO))
        oParamentro(3) = DBParametro_Montar("CDTIPOUNIDADE", cboUnidade.SelectedItem(ComboBox_TipoUnidade_Info.CD_TIPO_UNIDADE))
        oParamentro(4) = DBParametro_Montar("DTNEGOCIACAO", Date_to_Oracle(DataSistema))
        oParamentro(5) = DBParametro_Montar("QTKGS", txtQuantidadeNegociacao.Value)
        oParamentro(6) = DBParametro_Montar("VLNEGOCIACAO", txtValorUnitarioNegociacao.Value)
        oParamentro(7) = DBParametro_Montar("CDLOCALENTREGA", cboLocalEntrega.SelectedValue)
        oParamentro(8) = DBParametro_Montar("DTVENCIMENTO", Date_to_Oracle(txtDataVencimento.Text))
        oParamentro(9) = DBParametro_Montar("DTPAGAMENTO", Date_to_Oracle(txtDataPagamento.Text))
        oParamentro(10) = DBParametro_Montar("VLPRECOFRETE", txtValorFrete.Value)
        oParamentro(11) = DBParametro_Montar("PCALIQICMS", txtAliquotaICMS.Value)
        oParamentro(12) = DBParametro_Montar("ICBONUS", IIf(BONUS, "S", "N"))
        oParamentro(13) = DBParametro_Montar("CDPAPELCOMPETENCIA", cboBolsa.SelectedValue)
        oParamentro(14) = DBParametro_Montar("SQBOLSAGRUPOPREMIO", 1)
        oParamentro(15) = DBParametro_Montar("CDTIPOPESSOA", cboTipoPessoa.SelectedValue)
        oParamentro(16) = DBParametro_Montar("DSMOTIVODTVENC", NULLIf(Trim(txtMotivoDataVencimentoAvancada.Text), ""))
        oParamentro(17) = DBParametro_Montar("DSMOTIVORENEGOCIACAO", NULLIf(Trim(txtRazoesRenegociacao.Text), ""))
        If IsDate(txtDataPrazoFixacao.Text) Then
            oParamentro(18) = DBParametro_Montar("DTPRAZOFIXACAO", Date_to_Oracle(txtDataPrazoFixacao.Text))
        Else
            oParamentro(18) = DBParametro_Montar("DTPRAZOFIXACAO", Nothing)
        End If
        oParamentro(19) = DBParametro_Montar("PCTAXAJUROS", txtTaxaJuros.Value)
        oParamentro(20) = DBParametro_Montar("VLLIMITECREDITO", Valor_Saldo_Credito)
        oParamentro(21) = DBParametro_Montar("VLCREDITOSOLICITADO", Valor_Solicitado_Credito)
        oParamentro(22) = DBParametro_Montar("QTUMIDADEPADRAO", txtUmidadePadrao.Value)
        oParamentro(23) = DBParametro_Montar("PCSUJIDADEPADRAO", txtSujidadePadrao.Value)
        oParamentro(24) = DBParametro_Montar("VLFRETEFABRICA", NVL(cboFilialEntrega.SelectedItem(ComboBox_FilialEntrega_Info.VL_FRETE_FILIAL_FABRICA), 0))
        oParamentro(25) = DBParametro_Montar("CDTIPOCACAU", cboTipoCacau.SelectedValue)
        oParamentro(26) = DBParametro_Montar("CDFILIALENTREGA", cboFilialEntrega.SelectedValue)
        oParamentro(27) = DBParametro_Montar("ICCALCULAJUROS", IIf(chkCobraJuros.Checked, "S", "N"))
        oParamentro(28) = DBParametro_Montar("QTDIACARENCIAJUROS", IIf(chkCobraJuros.Checked, txtDiasCarencia.Value, Nothing))
        oParamentro(29) = DBParametro_Montar("ICJUROSAPOSCARENCIA", IIf(chkCobraJuros.Checked, IIf(chkJurosAposCarencia.Checked, "S", "N"), Nothing))
        oParamentro(30) = DBParametro_Montar("SQSOLICITACAO", Nothing, ParameterDirection.Output)

        If Not DBExecutar(SqlText, oParamentro) Then GoTo Erro

        SQ_NEGOCIACAO = DBRetorno(1)
        lblNrContrato.Text = Trim(CD_CONTRATO_PAF) & "-" & Trim(SQ_NEGOCIACAO)

        bOk = True

        Exit Function

Erro:
        TratarErro(, , "frmCadastroReNegociacao_Solicitacao.Inclui_ReNegociacao")
    End Function

    Private Sub txtValorUnitarioNegociacao_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorUnitarioNegociacao.ValueChanged
        Calcula_Valor_Total()
    End Sub

    Private Sub Calcula_Valor_Total()
        txtValorTotal.Value = 0

        If Not ComboBox_LinhaSelecionada(cboUnidade) Then Exit Sub
        If Not ComboBox_LinhaSelecionada(cboTipoNegociacao) Then Exit Sub

        If cboTipoNegociacao.SelectedItem(ComboBox_TipoNegociacao_Info.CD_TIPO) <> 3 Then
            txtValorTotal.Value = (txtValorUnitarioNegociacao.Value / cboUnidade.SelectedItem(ComboBox_TipoUnidade_Info.QT_FATOR)) * txtQuantidadeNegociacao.Value
        End If
    End Sub

    Private Sub txtDataVencimento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDataVencimento.ValueChanged
        Verifica_Data_Vencimento_Padrao()
    End Sub

    Private Sub txtAliquotaICMS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAliquotaICMS.ValueChanged
        Calcula_Valor_Total()
    End Sub

    Private Sub txtQuantidadeNegociacao_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantidadeNegociacao.ValueChanged
        Calcula_Valor_Total()
    End Sub
End Class