Public Class frmCadastroOperacaoBancaria
    Const cnt_SEC_Tela As String = "Cadastro_Contabil_OperacaoBancaria"

    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim CdOperacaoBancaria As Integer

    Private Sub frmCadastroOperacaoBancaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_TipoMovimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TipoMovimentacao.BancoDados_Filtro_Limpar()
        Pesq_TipoMovimentacao.BancoDados_Filtro_Adicionar("IC_ATIVO = 'S'")

        ComboBox_Carregar_Filial(cboFilial, True)

        ControleEdicaoTelaLocal = ControleEdicaoTela
        CdOperacaoBancaria = Filtro

        optTipo_ValueChanged(Nothing, Nothing)

        cmdGravar.Visible = SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao) Or _
                            SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao)

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            CarregarDados()
        End If
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "select * from sof.operacao_bancaria where cd_operacao_bancaria=" & CdOperacaoBancaria
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            lblCodigo.Text = oData.Rows(0).Item("cd_operacao_bancaria")
            txtDescricao.Text = oData.Rows(0).Item("no_operacao")
            txtContaContabil.Text = oData.Rows(0).Item("cd_conta_contabil")
            txtCentroCusto.Text = oData.Rows(0).Item("cd_centro_de_custo")
            txtValorMaxCheque.Value = oData.Rows(0).Item("vl_maximo_pagamento")
            If Not objDataTable_CampoVazio(oData.Rows(0).Item("cd_filial_debitada_default")) Then
                ComboBox_Possicionar(cboFilial, oData.Rows(0).Item("cd_filial_debitada_default"))
            End If
            optTipo.Value = oData.Rows(0).Item("ic_debito_credito")
            If optTipo.Value = "D" Then
                If oData.Rows(0).Item("ic_lanca_rd") = "S" Then
                    chkRD.Checked = True
                    Pesq_TipoMovimentacao.Codigo = oData.Rows(0).Item("cd_tipo_movimentacao")
                Else
                    chkRD.Checked = False
                End If
                If Not objDataTable_CampoVazio(oData.Rows(0).Item("vl_aliq_cheia_acrescentar")) Then
                    chkAliquota.Checked = True
                    txtValorAliquotaCheia.Value = oData.Rows(0).Item("vl_aliq_cheia_acrescentar")
                    txtAliquotaCheia.Text = "" & oData.Rows(0).Item("no_aliq_cheia_acrescentar")

                    If Not objDataTable_CampoVazio(oData.Rows(0).Item("vl_sub_aliq_1")) Then
                        txtValorSubAliquota1.Value = oData.Rows(0).Item("vl_sub_aliq_1")
                        txtSubAliquota1.Text = "" & oData.Rows(0).Item("no_sub_aliq_1")
                    End If

                    If Not objDataTable_CampoVazio(oData.Rows(0).Item("vl_sub_aliq_2")) Then
                        txtValorSubAliquota2.Value = oData.Rows(0).Item("vl_sub_aliq_2")
                        txtSubAliquota2.Text = "" & oData.Rows(0).Item("no_sub_aliq_2")
                    End If
                End If
                chkEmiteCheque.Checked = IIf(oData.Rows(0).Item("ic_emite_cheque") = "S", True, False)
                chkAtivo.Checked = IIf(oData.Rows(0).Item("ic_ativo") = "S", True, False)
            End If
        End If
        optTipo_ValueChanged(Nothing, Nothing)
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        If optTipo.Value = "D" Then
            chkRD.Enabled = True
            chkRD_CheckedChanged(Nothing, Nothing)
            chkAliquota.Enabled = True
            chkAliquota_CheckedChanged(Nothing, Nothing)
            chkEmiteCheque.Enabled = True
            grpDebito.Enabled = True
        Else
            chkRD.Checked = False
            chkRD_CheckedChanged(Nothing, Nothing)
            chkRD.Enabled = False
            chkAliquota.Checked = False
            chkAliquota_CheckedChanged(Nothing, Nothing)
            chkAliquota.Enabled = False
            chkEmiteCheque.Checked = False
            chkEmiteCheque.Enabled = False
            grpDebito.Enabled = False
        End If
    End Sub

    Private Sub chkRD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRD.CheckedChanged
        If chkRD.Checked = True Then
            Pesq_TipoMovimentacao.Enabled = True
        Else
            Pesq_TipoMovimentacao.Codigo = 0
            Pesq_TipoMovimentacao.Enabled = False
        End If
    End Sub

    Private Sub chkAliquota_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAliquota.CheckedChanged
        If chkAliquota.Checked = False Then
            txtValorAliquotaCheia.Value = 0
            txtValorAliquotaCheia.Enabled = False
            txtAliquotaCheia.Text = ""
            txtAliquotaCheia.Enabled = False
            txtValorSubAliquota1.Value = 0
            txtValorSubAliquota1.Enabled = False
            txtSubAliquota1.Text = ""
            txtSubAliquota1.Enabled = False
            txtValorSubAliquota2.Value = 0
            txtValorSubAliquota2.Enabled = False
            txtSubAliquota2.Text = ""
            txtSubAliquota2.Enabled = False
        Else
            txtValorAliquotaCheia.Enabled = True
            txtAliquotaCheia.Enabled = True
            txtValorSubAliquota1.Enabled = True
            txtSubAliquota1.Enabled = True
            txtValorSubAliquota2.Enabled = True
            txtSubAliquota2.Enabled = True
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(16) As DBParamentro

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar o nome da operação bancaria.")
            txtDescricao.Focus()
            Exit Sub
        End If
        If txtContaContabil.Text = "" Then
            Msg_Mensagem("Favor informar o numero da conta contabil.")
            txtContaContabil.Focus()
            Exit Sub
        End If
        If txtCentroCusto.Text = "" Then
            Msg_Mensagem("Favor informar o numero do centro de custo.")
            txtCentroCusto.Focus()
            Exit Sub
        End If
        If txtValorMaxCheque.Value = 0 Then
            Msg_Mensagem("Favor informar o valor maximo para a operação bancaria.")
            txtValorMaxCheque.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboFilial) Then
            Msg_Mensagem("Favor informar uma filial a ser debitada como padrão")
            cboFilial.Focus()
            Exit Sub
        End If
        If optTipo.Value = "D" Then
            If chkRD.Checked = True Then
                If Pesq_TipoMovimentacao.Codigo = 0 Then
                    Msg_Mensagem("Favor informar um tipo de movimentação valido.")
                    Pesq_TipoMovimentacao.Focus()
                    Exit Sub
                End If
            End If
            If chkAliquota.Checked = True Then
                If txtValorAliquotaCheia.Value = 0 Then
                    Msg_Mensagem("Favor informar o valor da aliquota cheia.")
                    txtValorAliquotaCheia.Focus()
                    Exit Sub
                End If
                If txtAliquotaCheia.Text = "" Then
                    Msg_Mensagem("Favor informar o titulo da aliquota cheia.")
                    txtAliquotaCheia.Focus()
                    Exit Sub
                End If
                If txtValorSubAliquota1.Value <> 0 Then
                    If txtSubAliquota1.Text = "" Then
                        Msg_Mensagem("Favor informar o titulo da 1º sub aliquota.")
                        txtSubAliquota1.Focus()
                        Exit Sub
                    End If
                End If
                If txtValorSubAliquota2.Value <> 0 Then
                    If txtSubAliquota2.Text = "" Then
                        Msg_Mensagem("Favor informar o titulo da 1º sub aliquota.")
                        txtSubAliquota2.Focus()
                        Exit Sub
                    End If
                End If
            End If
        End If

        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            CdOperacaoBancaria = DBNumeroMaisUm("SOF.OPERACAO_BANCARIA", "CD_OPERACAO_BANCARIA")

            SqlText = DBMontar_Insert("SOF.OPERACAO_BANCARIA", TipoCampoFixo.Todos, "NO_OPERACAO", ":NO_OPERACAO", _
                                                                                    "CD_CONTA_CONTABIL", ":CD_CONTA_CONTABIL", _
                                                                                    "CD_CENTRO_DE_CUSTO", ":CD_CENTRO_DE_CUSTO", _
                                                                                    "VL_MAXIMO_PAGAMENTO", ":VL_MAXIMO_PAGAMENTO", _
                                                                                    "CD_FILIAL_DEBITADA_DEFAULT", ":CD_FILIAL_DEBITADA_DEFAULT", _
                                                                                    "IC_DEBITO_CREDITO", ":IC_DEBITO_CREDITO", _
                                                                                    "IC_LANCA_RD", ":IC_LANCA_RD", _
                                                                                    "CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO", _
                                                                                    "VL_ALIQ_CHEIA_ACRESCENTAR", ":VL_ALIQ_CHEIA_ACRESCENTAR", _
                                                                                    "NO_ALIQ_CHEIA_ACRESCENTAR", ":NO_ALIQ_CHEIA_ACRESCENTAR", _
                                                                                    "VL_SUB_ALIQ_1", ":VL_SUB_ALIQ_1", _
                                                                                    "NO_SUB_ALIQ_1", ":NO_SUB_ALIQ_1", _
                                                                                    "VL_SUB_ALIQ_2", ":VL_SUB_ALIQ_2", _
                                                                                    "NO_SUB_ALIQ_2", ":NO_SUB_ALIQ_2", _
                                                                                    "IC_EMITE_CHEQUE", ":IC_EMITE_CHEQUE", _
                                                                                    "IC_ATIVO", ":IC_ATIVO", _
                                                                                    "CD_OPERACAO_BANCARIA", ":CD_OPERACAO_BANCARIA")
        Else
            SqlText = DBMontar_Update("SOF.OPERACAO_BANCARIA", GerarArray("NO_OPERACAO", ":NO_OPERACAO", _
                                                                           "CD_CONTA_CONTABIL", ":CD_CONTA_CONTABIL", _
                                                                           "CD_CENTRO_DE_CUSTO", ":CD_CENTRO_DE_CUSTO", _
                                                                           "VL_MAXIMO_PAGAMENTO", ":VL_MAXIMO_PAGAMENTO", _
                                                                           "CD_FILIAL_DEBITADA_DEFAULT", ":CD_FILIAL_DEBITADA_DEFAULT", _
                                                                           "IC_DEBITO_CREDITO", ":IC_DEBITO_CREDITO", _
                                                                           "IC_LANCA_RD", ":IC_LANCA_RD", _
                                                                           "CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO", _
                                                                           "VL_ALIQ_CHEIA_ACRESCENTAR", ":VL_ALIQ_CHEIA_ACRESCENTAR", _
                                                                           "NO_ALIQ_CHEIA_ACRESCENTAR", ":NO_ALIQ_CHEIA_ACRESCENTAR", _
                                                                           "VL_SUB_ALIQ_1", ":VL_SUB_ALIQ_1", _
                                                                           "NO_SUB_ALIQ_1", ":NO_SUB_ALIQ_1", _
                                                                           "VL_SUB_ALIQ_2", ":VL_SUB_ALIQ_2", _
                                                                           "NO_SUB_ALIQ_2", ":NO_SUB_ALIQ_2", _
                                                                           "IC_EMITE_CHEQUE", ":IC_EMITE_CHEQUE", _
                                                                           "IC_ATIVO", ":IC_ATIVO"), _
                                                               GerarArray("CD_OPERACAO_BANCARIA", ":CD_OPERACAO_BANCARIA"))
        End If

        Parametro(0) = DBParametro_Montar("NO_OPERACAO", txtDescricao.Text)
        Parametro(1) = DBParametro_Montar("CD_CONTA_CONTABIL", txtContaContabil.Text)
        Parametro(2) = DBParametro_Montar("CD_CENTRO_DE_CUSTO", txtCentroCusto.Text)
        Parametro(3) = DBParametro_Montar("VL_MAXIMO_PAGAMENTO", txtValorMaxCheque.Value)
        Parametro(4) = DBParametro_Montar("CD_FILIAL_DEBITADA_DEFAULT", cboFilial.SelectedValue)
        Parametro(5) = DBParametro_Montar("IC_DEBITO_CREDITO", optTipo.Value)
        Parametro(6) = DBParametro_Montar("IC_LANCA_RD", IIf(chkRD.Checked, "S", "N"))
        If Pesq_TipoMovimentacao.Codigo <> 0 Then
            Parametro(7) = DBParametro_Montar("CD_TIPO_MOVIMENTACAO", Pesq_TipoMovimentacao.Codigo)
        Else
            Parametro(7) = DBParametro_Montar("CD_TIPO_MOVIMENTACAO", Nothing)
        End If
        If chkAliquota.Checked = True Then
            Parametro(8) = DBParametro_Montar("VL_ALIQ_CHEIA_ACRESCENTAR", txtValorAliquotaCheia.Value)
            Parametro(9) = DBParametro_Montar("NO_ALIQ_CHEIA_ACRESCENTAR", txtAliquotaCheia.Text)
        Else
            Parametro(8) = DBParametro_Montar("VL_ALIQ_CHEIA_ACRESCENTAR", Nothing)
            Parametro(9) = DBParametro_Montar("NO_ALIQ_CHEIA_ACRESCENTAR", Nothing)
        End If
        If chkAliquota.Checked = True And txtValorSubAliquota1.Value <> 0 Then
            Parametro(10) = DBParametro_Montar("VL_SUB_ALIQ_1", txtValorSubAliquota1.Value)
            Parametro(11) = DBParametro_Montar("NO_SUB_ALIQ_1", txtSubAliquota1.Text)
        Else
            Parametro(10) = DBParametro_Montar("VL_SUB_ALIQ_1", 0)
            Parametro(11) = DBParametro_Montar("NO_SUB_ALIQ_1", 0)
        End If
        If chkAliquota.Checked = True And txtValorSubAliquota2.Value <> 0 Then
            Parametro(12) = DBParametro_Montar("VL_SUB_ALIQ_2", txtValorSubAliquota2.Value)
            Parametro(13) = DBParametro_Montar("NO_SUB_ALIQ_2", txtSubAliquota2.Text)
        Else
            Parametro(12) = DBParametro_Montar("VL_SUB_ALIQ_2", 0)
            Parametro(13) = DBParametro_Montar("NO_SUB_ALIQ_2", 0)
        End If
        Parametro(14) = DBParametro_Montar("IC_EMITE_CHEQUE", IIf(chkEmiteCheque.Checked, "S", "N"))
        Parametro(15) = DBParametro_Montar("IC_ATIVO", IIf(chkAtivo.Checked, "S", "N"))
        Parametro(16) = DBParametro_Montar("CD_OPERACAO_BANCARIA", CdOperacaoBancaria)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        Close()

        Exit Sub
Erro:
        TratarErro()

    End Sub
End Class