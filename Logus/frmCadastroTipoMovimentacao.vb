Public Class frmCadastroTipoMovimentacao
    Const cnt_SEC_Tela As String = "Cadastro_Administrativo_TipoMovimentacao"

    Dim ControleEdicaoTelaLocal As eControleEdicaoTela

    Private Sub frmCadastroTipoMovimentacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ControleEdicaoTelaLocal = ControleEdicaoTela

        ComboBox_Carregar_Tipo_RD(cboTipoRD, True)
        ComboBox_Carregar_Local_Entrega(cboLocalEntrega, True)
        ComboBox_Carregar_Tipo_Movimentacao(cboAplicacaoCacau, True, True)
        ComboBox_Carregar_Tipo_Movimentacao(cboSaidaAplicacaoCacau, True, True)

        chkLancaRD_CheckedChanged(Nothing, Nothing)
        chkContabilizacao_CheckedChanged(Nothing, Nothing)
        chkFilialFixa_CheckedChanged(Nothing, Nothing)

        cmdGravar.Visible = SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao) Or _
                            SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao)

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            txtCodigo.Value = Filtro
            txtCodigo.Enabled = False
            CarregarDados()
        End If

        Validar_SubLedgerCP()
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * FROM SOF.TIPO_MOVIMENTACAO" & _
                  " WHERE CD_TIPO_MOVIMENTACAO = " & txtCodigo.Value
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            txtDescricao.Text = oData.Rows(0).Item("NO_TIPO_MOVIMENTACAO")

            If oData.Rows(0).Item("IC_ENTRA_NO_RD") = "S" Then
                chkLancaRD.Checked = True
                chkLancaRD_CheckedChanged(Nothing, Nothing)
                ComboBox_Possicionar(cboTipoRD, oData.Rows(0).Item("CD_TIPO_RD"))
                optTipo.Value = oData.Rows(0).Item("IC_ENTRADA_SAIDA")
                chkImportacao.Checked = IIf(oData.Rows(0).Item("IC_IMPORTACAO") = "S", True, False)
            End If

            If oData.Rows(0).Item("IC_CONTABILIZA") = "S" Then
                chkContabilizacao.Checked = True
                chkContabilizacao_CheckedChanged(Nothing, Nothing)
                txtContaContabil.Text = "" & oData.Rows(0).Item("NU_CONTA_CONTABIL")
                txtContaContabilCP.Text = "" & oData.Rows(0).Item("NU_CONTA_CONTABIL_CP")
                chkMudaFilial_CC.Checked = IIf(oData.Rows(0).Item("IC_MUDA_CONTA_CONTABIL") = "S", True, False)
                chkMudaFilial_CP.Checked = IIf(oData.Rows(0).Item("IC_MUDA_CONTA_CONTABIL_CP") = "S", True, False)
                chkSubLedgerCP.Checked = (NVL(oData.Rows(0).Item("IC_SUB_LEDGER_CP"), "N") = "S")
                txtSubLedger.Text = "" & oData.Rows(0).Item("CD_SUB_LEDGER")
                txtSubLedgerCP.Text = "" & oData.Rows(0).Item("CD_SUB_LEDGER_CP")
                txtTipoSubLedger.Text = "" & oData.Rows(0).Item("CD_TIPO_SUB_LEDGER")
                txtTipoSubLedgerCP.Text = "" & oData.Rows(0).Item("CD_TIPO_SUB_LEDGER_CP")
            End If

            chkValidaQuilos.Checked = IIf(oData.Rows(0).Item("IC_VALIDA_KG") = "S", True, False)
            chkValidaQuatidade.Checked = IIf(oData.Rows(0).Item("IC_VALIDA_QUALIDADE") = "S", True, False)
            chkValidaValor.Checked = IIf(oData.Rows(0).Item("IC_VALIDA_VALOR") = "S", True, False)
            chkMovimentacaoFiscal.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_FISCAL"), "N")) = "S", True, False)
            chkAplicacaoSaidaAplicacao.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_APLICACAO"), "N")) = "S", True, False)
            chkAplicacaoSaidaAplicacao.Tag = chkAplicacaoSaidaAplicacao.Checked
            chkLocalEntregaFixa.Checked = IIf(oData.Rows(0).Item("IC_POSTO_FIXO") = "S", True, False)
            chkAtivo.Checked = IIf(oData.Rows(0).Item("IC_ATIVO") = "S", True, False)
            chkFilialFixa_CheckedChanged(Nothing, Nothing)

            If chkLocalEntregaFixa.Checked = True Then
                ComboBox_Possicionar(cboLocalEntrega, oData.Rows(0).Item("CD_LOCAL_ENTREGA"))
            End If

            txtCfopLocal_PJ.Text = "" & oData.Rows(0).Item("CD_CFOP_LOCAL_PJ_CLASS")
            txtCfopOutros_PJ.Text = "" & oData.Rows(0).Item("CD_CFOP_OUTROS_PJ_CLASS")
            txtCfopLocal.Text = "" & oData.Rows(0).Item("CD_CFOP_LOCAL_CLASS")
            txtSufixoLocal.Text = "" & oData.Rows(0).Item("CD_SUFIXO_LOCAL_CLASS")
            txtFormaTributacaoLocal.Text = "" & oData.Rows(0).Item("CD_FORMA_TRIBUT_LOCAL_CLASS")
            txtTributacaoIcmsLocal.Text = "" & oData.Rows(0).Item("CD_TRIBUT_ICMS_LOCAL_CLASS")
            txtSituacaoTributacaoLocal.Text = "" & oData.Rows(0).Item("CD_SITUACAO_TRIBUT_LOCAL_CLASS")
            txtCfopOutros.Text = "" & oData.Rows(0).Item("CD_CFOP_OUTROS_CLASS")
            txtSufixoOutros.Text = "" & oData.Rows(0).Item("CD_SUFIXO_OUTROS_CLASS")
            txtFormaTributacaoOutros.Text = "" & oData.Rows(0).Item("CD_FORMA_TRIBUT_OUTROS_CLASS")
            txtTributacaoIcmsOutros.Text = "" & oData.Rows(0).Item("CD_TRIBUT_ICMS_OUTROS_CLASS")
            txtSituacaoTributacaoOutros.Text = "" & oData.Rows(0).Item("CD_SITUACAO_TRIBU_OUTROS_CLASS")
            txtPrintMessageLocal.Text = "" & oData.Rows(0).Item("CD_PRINT_MESSAGE_LOCAL_CLASS")
            txtPrintMessageOutros.Text = "" & oData.Rows(0).Item("CD_PRINT_MESSAGE_OUTROS_CLASS")
            chkLivroFiscal.Checked = IIf(CStr(NVL(oData.Rows(0).Item("IC_ENVIA_LIVRO_FISCAL"), "N")) = "S", True, False)
            ComboBox_Possicionar(cboAplicacaoCacau, oData.Rows(0).Item("CD_TP_MOV_FIXACAO_ENTRADA"))
            ComboBox_Possicionar(cboSaidaAplicacaoCacau, oData.Rows(0).Item("CD_TP_MOV_FIXACAO_SAIDA"))
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub chkLancaRD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLancaRD.CheckedChanged
        If chkLancaRD.Checked = True Then
            cboTipoRD.Enabled = True
            optTipo.Enabled = True
            chkImportacao.Enabled = True
            chkContabilizacao.Enabled = True
        Else
            cboTipoRD.Enabled = False
            ComboBox_Possicionar(cboTipoRD, -1)
            optTipo.Enabled = False
            optTipo.Value = Nothing
            chkImportacao.Checked = False
            chkImportacao.Enabled = False
        End If
    End Sub

    Private Sub chkFilialFixa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLocalEntregaFixa.CheckedChanged
        If chkLocalEntregaFixa.Checked = True Then
            cboLocalEntrega.Enabled = True
        Else
            ComboBox_Possicionar(cboLocalEntrega, -1)
            cboLocalEntrega.Enabled = False
        End If
    End Sub

    Private Sub chkLivroFiscal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLivroFiscal.CheckedChanged
        If chkLivroFiscal.Checked = False Then
            TabClass.Enabled = False
        Else
            TabClass.Enabled = True
        End If
    End Sub

    Private Sub chkContabilizacao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkContabilizacao.CheckedChanged
        If chkContabilizacao.Checked = True Then
            grpContabiliza.Enabled = True
        Else
            grpContabiliza.Enabled = False
            txtContaContabil.Text = ""
            txtContaContabilCP.Text = ""
            chkMudaFilial_CC.Checked = False
            chkMudaFilial_CP.Checked = False
            txtSubLedger.Text = ""
            txtSubLedgerCP.Text = ""
            txtTipoSubLedger.Text = ""
            txtTipoSubLedgerCP.Text = ""
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(41) As DBParamentro

        If txtCodigo.Value = 0 Then
            Msg_Mensagem("Favor informar o codigo do tipo de movimentação.")
            txtCodigo.Focus()
            Exit Sub
        End If

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar o nome do tipo de movimentação.")
            txtDescricao.Focus()
            Exit Sub
        End If

        If chkLancaRD.Checked = True Then
            If Not ComboBox_LinhaSelecionada(cboTipoRD) Then
                Msg_Mensagem("Favor informar o tipo do RD.")
                cboTipoRD.Focus()
                Exit Sub
            End If
            If optTipo.Value = Nothing Then
                Msg_Mensagem("Favor informa se é movimentação de entrada ou saída.")
                optTipo.Focus()
                Exit Sub
            End If
        End If
        If chkContabilizacao.Checked = True Then
            If txtContaContabil.Text = "" Then
                Msg_Mensagem("Favor informar a conta contabil.")
                txtContaContabil.Focus()
                Exit Sub
            End If
            If txtContaContabilCP.Text = "" Then
                Msg_Mensagem("Favor informar a conta contabil de contra partida.")
                txtContaContabilCP.Focus()
                Exit Sub
            End If
            If txtSubLedger.Text <> "" Then
                If txtTipoSubLedger.Text = "" Then
                    Msg_Mensagem("Favor informar um tipo do Sub Ledger")
                    txtTipoSubLedger.Focus()
                    Exit Sub
                End If
            End If
            If txtSubLedgerCP.Text <> "" Then
                If txtTipoSubLedgerCP.Text = "" Then
                    Msg_Mensagem("Favor informar um tipo do Sub Ledger C/P")
                    txtTipoSubLedgerCP.Focus()
                    Exit Sub
                End If
            End If
        End If
        If chkLocalEntregaFixa.Checked = True Then
            If Not ComboBox_LinhaSelecionada(cboLocalEntrega) Then
                Msg_Mensagem("Favor selecionar um local de entrega.")
                cboLocalEntrega.Focus()
                Exit Sub
            End If
        End If

        If chkLivroFiscal.Checked = True Then
            If txtCfopLocal.Text = "" Then
                Msg_Mensagem("Favor informar o CFOP.")
                txtCfopLocal.Focus()
                Exit Sub
            End If
            If txtCfopLocal_PJ.Text = "" Then
                Msg_Mensagem("Favor informar o CFOP pessoa juridica.")
                txtCfopLocal_PJ.Focus()
                Exit Sub
            End If
            If txtSufixoLocal.Text = "" Then
                Msg_Mensagem("Favor informar o sufixo.")
                txtSufixoLocal.Focus()
                Exit Sub
            End If
            If txtFormaTributacaoLocal.Text = "" Then
                Msg_Mensagem("Favor informar a forma tributação.")
                txtFormaTributacaoLocal.Focus()
                Exit Sub
            End If
            If txtTributacaoIcmsLocal.Text = "" Then
                Msg_Mensagem("Favor informar a tributação icms.")
                txtTributacaoIcmsLocal.Focus()
                Exit Sub
            End If
            If txtSituacaoTributacaoLocal.Text = "" Then
                Msg_Mensagem("Favor a situação tributação icms.")
                txtSituacaoTributacaoLocal.Focus()
                Exit Sub
            End If
            If txtPrintMessageLocal.Text = "" Then
                Msg_Mensagem("Favor a finalidade.")
                txtPrintMessageLocal.Focus()
                Exit Sub
            End If
            If txtCfopOutros.Text = "" Then
                Msg_Mensagem("Favor informar o CFOP.")
                txtCfopOutros.Focus()
                Exit Sub
            End If
            If txtCfopOutros_PJ.Text = "" Then
                Msg_Mensagem("Favor informar o CFOP pessoal juridica.")
                txtCfopOutros_PJ.Focus()
                Exit Sub
            End If
            If txtSufixoOutros.Text = "" Then
                Msg_Mensagem("Favor informar o sufixo.")
                txtSufixoOutros.Focus()
                Exit Sub
            End If
            If txtFormaTributacaoOutros.Text = "" Then
                Msg_Mensagem("Favor informar a forma tributação.")
                txtFormaTributacaoOutros.Focus()
                Exit Sub
            End If
            If txtTributacaoIcmsOutros.Text = "" Then
                Msg_Mensagem("Favor informar a tributação icms.")
                txtTributacaoIcmsOutros.Focus()
                Exit Sub
            End If
            If txtSituacaoTributacaoOutros.Text = "" Then
                Msg_Mensagem("Favor a situação tributação icms.")
                txtSituacaoTributacaoOutros.Focus()
                Exit Sub
            End If
            If txtPrintMessageOutros.Text = "" Then
                Msg_Mensagem("Favor a finalidade.")
                txtPrintMessageOutros.Focus()
                Exit Sub
            End If
        End If
        If chkAplicacaoSaidaAplicacao.Tag <> chkAplicacaoSaidaAplicacao.Checked And _
           Not chkAplicacaoSaidaAplicacao.Checked Then
            SqlText = "SELECT COUNT(*) FROM " & cnt_SQL_TipoMovimentacao_Aplicacao & _
                      " WHERE CD_TIPO_MOVIMENTACAO = " & txtCodigo.Value
            If DBQuery_ValorUnico(SqlText) > 0 Then
                chkAplicacaoSaidaAplicacao.Checked = True
                Msg_Mensagem("Esse tipo de movimentação está associado ou a outro tipo de movimentação ou ao parâmetro geral como tipo de movimentação de aplicação")
                Exit Sub
            End If
        End If

        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            SqlText = DBMontar_Insert("SOF.TIPO_MOVIMENTACAO", TipoCampoFixo.Todos, "NO_TIPO_MOVIMENTACAO", ":NO_TIPO_MOVIMENTACAO", _
                                                                                    "IC_ENTRA_NO_RD", ":IC_ENTRA_NO_RD", _
                                                                                    "IC_TIPO_RD", ":IC_TIPO_RD", _
                                                                                    "IC_ENTRADA_SAIDA", ":IC_ENTRADA_SAIDA", _
                                                                                    "IC_IMPORTACAO", ":IC_IMPORTACAO", _
                                                                                    "CD_TIPO_RD", ":CD_TIPO_RD", _
                                                                                    "NU_CONTA_CONTABIL", ":NU_CONTA_CONTABIL", _
                                                                                    "NU_CONTA_CONTABIL_CP", ":NU_CONTA_CONTABIL_CP", _
                                                                                    "IC_MUDA_CONTA_CONTABIL", ":IC_MUDA_CONTA_CONTABIL", _
                                                                                    "IC_MUDA_CONTA_CONTABIL_CP", ":IC_MUDA_CONTA_CONTABIL_CP", _
                                                                                    "CD_SUB_LEDGER", ":CD_SUB_LEDGER", _
                                                                                    "CD_SUB_LEDGER_CP", ":CD_SUB_LEDGER_CP", _
                                                                                    "CD_TIPO_SUB_LEDGER", ":CD_TIPO_SUB_LEDGER", _
                                                                                    "CD_TIPO_SUB_LEDGER_CP", ":CD_TIPO_SUB_LEDGER_CP", _
                                                                                    "IC_CONTABILIZA", ":IC_CONTABILIZA", _
                                                                                    "IC_VALIDA_KG", ":IC_VALIDA_KG", _
                                                                                    "IC_VALIDA_QUALIDADE", ":IC_VALIDA_QUALIDADE", _
                                                                                    "IC_VALIDA_VALOR", ":IC_VALIDA_VALOR", _
                                                                                    "IC_FISCAL", ":IC_FISCAL", _
                                                                                    "IC_POSTO_FIXO", ":IC_POSTO_FIXO", _
                                                                                    "CD_LOCAL_ENTREGA", ":CD_LOCAL_ENTREGA", _
                                                                                    "CD_CFOP_LOCAL_PJ_CLASS", ":CD_CFOP_LOCAL_PJ_CLASS", _
                                                                                    "CD_CFOP_OUTROS_PJ_CLASS", ":CD_CFOP_OUTROS_PJ_CLASS", _
                                                                                    "CD_CFOP_LOCAL_CLASS", ":CD_CFOP_LOCAL_CLASS", _
                                                                                    "CD_SUFIXO_LOCAL_CLASS", ":CD_SUFIXO_LOCAL_CLASS", _
                                                                                    "CD_FORMA_TRIBUT_LOCAL_CLASS", ":CD_FORMA_TRIBUT_LOCAL_CLASS", _
                                                                                    "CD_TRIBUT_ICMS_LOCAL_CLASS", ":CD_TRIBUT_ICMS_LOCAL_CLASS", _
                                                                                    "CD_SITUACAO_TRIBUT_LOCAL_CLASS", ":CD_SITUACAO_TRIBUT_LOCAL_CLASS", _
                                                                                    "CD_CFOP_OUTROS_CLASS", ":CD_CFOP_OUTROS_CLASS", _
                                                                                    "CD_SUFIXO_OUTROS_CLASS", ":CD_SUFIXO_OUTROS_CLASS", _
                                                                                    "CD_FORMA_TRIBUT_OUTROS_CLASS", ":CD_FORMA_TRIBUT_OUTROS_CLASS", _
                                                                                    "CD_TRIBUT_ICMS_OUTROS_CLASS", ":CD_TRIBUT_ICMS_OUTROS_CLASS", _
                                                                                    "CD_SITUACAO_TRIBU_OUTROS_CLASS", ":CD_SITUACAO_TRIBU_OUTROS_CLASS", _
                                                                                    "CD_PRINT_MESSAGE_LOCAL_CLASS", ":CD_PRINT_MESSAGE_LOCAL_CLASS", _
                                                                                    "CD_PRINT_MESSAGE_OUTROS_CLASS", ":CD_PRINT_MESSAGE_OUTROS_CLASS", _
                                                                                    "IC_ENVIA_LIVRO_FISCAL", ":IC_ENVIA_LIVRO_FISCAL", _
                                                                                    "IC_ATIVO", ":IC_ATIVO", _
                                                                                    "IC_APLICACAO", ":IC_APLICACAO", _
                                                                                    "CD_TP_MOV_FIXACAO_ENTRADA", ":CD_TP_MOV_FIXACAO_ENTRADA", _
                                                                                    "CD_TP_MOV_FIXACAO_SAIDA", ":CD_TP_MOV_FIXACAO_SAIDA", _
                                                                                    "IC_SUB_LEDGER_CP", ":IC_SUB_LEDGER_CP", _
                                                                                    "CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO")
        Else
            SqlText = DBMontar_Update("SOF.TIPO_MOVIMENTACAO", GerarArray("NO_TIPO_MOVIMENTACAO", ":NO_TIPO_MOVIMENTACAO", _
                                                                          "IC_ENTRA_NO_RD", ":IC_ENTRA_NO_RD", _
                                                                          "IC_TIPO_RD", ":IC_TIPO_RD", _
                                                                          "IC_ENTRADA_SAIDA", ":IC_ENTRADA_SAIDA", _
                                                                          "IC_IMPORTACAO", ":IC_IMPORTACAO", _
                                                                          "CD_TIPO_RD", ":CD_TIPO_RD", _
                                                                          "NU_CONTA_CONTABIL", ":NU_CONTA_CONTABIL", _
                                                                          "NU_CONTA_CONTABIL_CP", ":NU_CONTA_CONTABIL_CP", _
                                                                          "IC_MUDA_CONTA_CONTABIL", ":IC_MUDA_CONTA_CONTABIL", _
                                                                          "IC_MUDA_CONTA_CONTABIL_CP", ":IC_MUDA_CONTA_CONTABIL_CP", _
                                                                          "CD_SUB_LEDGER", ":CD_SUB_LEDGER", _
                                                                          "CD_SUB_LEDGER_CP", ":CD_SUB_LEDGER_CP", _
                                                                          "CD_TIPO_SUB_LEDGER", ":CD_TIPO_SUB_LEDGER", _
                                                                          "CD_TIPO_SUB_LEDGER_CP", ":CD_TIPO_SUB_LEDGER_CP", _
                                                                          "IC_CONTABILIZA", ":IC_CONTABILIZA", _
                                                                          "IC_VALIDA_KG", ":IC_VALIDA_KG", _
                                                                          "IC_VALIDA_QUALIDADE", ":IC_VALIDA_QUALIDADE", _
                                                                          "IC_VALIDA_VALOR", ":IC_VALIDA_VALOR", _
                                                                          "IC_FISCAL", ":IC_FISCAL", _
                                                                          "IC_POSTO_FIXO", ":IC_POSTO_FIXO", _
                                                                          "CD_LOCAL_ENTREGA", ":CD_LOCAL_ENTREGA", _
                                                                          "CD_CFOP_LOCAL_PJ_CLASS", ":CD_CFOP_LOCAL_PJ_CLASS", _
                                                                          "CD_CFOP_OUTROS_PJ_CLASS", ":CD_CFOP_OUTROS_PJ_CLASS", _
                                                                          "CD_CFOP_LOCAL_CLASS", ":CD_CFOP_LOCAL_CLASS", _
                                                                          "CD_SUFIXO_LOCAL_CLASS", ":CD_SUFIXO_LOCAL_CLASS", _
                                                                          "CD_FORMA_TRIBUT_LOCAL_CLASS", ":CD_FORMA_TRIBUT_LOCAL_CLASS", _
                                                                          "CD_TRIBUT_ICMS_LOCAL_CLASS", ":CD_TRIBUT_ICMS_LOCAL_CLASS", _
                                                                          "CD_SITUACAO_TRIBUT_LOCAL_CLASS", ":CD_SITUACAO_TRIBUT_LOCAL_CLASS", _
                                                                          "CD_CFOP_OUTROS_CLASS", ":CD_CFOP_OUTROS_CLASS", _
                                                                          "CD_SUFIXO_OUTROS_CLASS", ":CD_SUFIXO_OUTROS_CLASS", _
                                                                          "CD_FORMA_TRIBUT_OUTROS_CLASS", ":CD_FORMA_TRIBUT_OUTROS_CLASS", _
                                                                          "CD_TRIBUT_ICMS_OUTROS_CLASS", ":CD_TRIBUT_ICMS_OUTROS_CLASS", _
                                                                          "CD_SITUACAO_TRIBU_OUTROS_CLASS", ":CD_SITUACAO_TRIBU_OUTROS_CLASS", _
                                                                          "CD_PRINT_MESSAGE_LOCAL_CLASS", ":CD_PRINT_MESSAGE_LOCAL_CLASS", _
                                                                          "CD_PRINT_MESSAGE_OUTROS_CLASS", ":CD_PRINT_MESSAGE_OUTROS_CLASS", _
                                                                          "IC_ENVIA_LIVRO_FISCAL", ":IC_ENVIA_LIVRO_FISCAL", _
                                                                          "IC_ATIVO", ":IC_ATIVO", _
                                                                          "IC_APLICACAO", ":IC_APLICACAO", _
                                                                          "CD_TP_MOV_FIXACAO_ENTRADA", ":CD_TP_MOV_FIXACAO_ENTRADA", _
                                                                          "CD_TP_MOV_FIXACAO_SAIDA", ":CD_TP_MOV_FIXACAO_SAIDA", _
                                                                          "IC_SUB_LEDGER_CP", ":IC_SUB_LEDGER_CP"), _
                                                               GerarArray("CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO"))
        End If

        Parametro(0) = DBParametro_Montar("NO_TIPO_MOVIMENTACAO", txtDescricao.Text)
        Parametro(1) = DBParametro_Montar("IC_ENTRA_NO_RD", IIf(chkLancaRD.Checked, "S", "N"))

        If chkLancaRD.Checked Then
            Parametro(2) = DBParametro_Montar("IC_TIPO_RD", cboTipoRD.SelectedValue)
            Parametro(3) = DBParametro_Montar("CD_TIPO_RD", cboTipoRD.SelectedValue)
            Parametro(4) = DBParametro_Montar("IC_ENTRADA_SAIDA", optTipo.Value)
            Parametro(5) = DBParametro_Montar("IC_IMPORTACAO", IIf(chkImportacao.Checked, "S", "N"))
        Else
            Parametro(2) = DBParametro_Montar("IC_TIPO_RD", Nothing)
            Parametro(3) = DBParametro_Montar("IC_ENTRADA_SAIDA", Nothing)
            Parametro(4) = DBParametro_Montar("IC_IMPORTACAO", Nothing)
            Parametro(5) = DBParametro_Montar("CD_TIPO_RD", Nothing)
        End If

        If chkContabilizacao.Checked Then
            Parametro(6) = DBParametro_Montar("NU_CONTA_CONTABIL", txtContaContabil.Text)
            Parametro(7) = DBParametro_Montar("NU_CONTA_CONTABIL_CP", txtContaContabilCP.Text)
            Parametro(8) = DBParametro_Montar("IC_MUDA_CONTA_CONTABIL", IIf(chkMudaFilial_CC.Checked, "S", "N"))
            Parametro(9) = DBParametro_Montar("IC_MUDA_CONTA_CONTABIL_CP", IIf(chkMudaFilial_CP.Checked, "S", "N"))
            Parametro(10) = DBParametro_Montar("CD_SUB_LEDGER", txtSubLedger.Text)
            Parametro(11) = DBParametro_Montar("CD_SUB_LEDGER_CP", txtSubLedgerCP.Text)
            Parametro(12) = DBParametro_Montar("CD_TIPO_SUB_LEDGER", txtTipoSubLedger.Text)
            Parametro(13) = DBParametro_Montar("CD_TIPO_SUB_LEDGER_CP", txtTipoSubLedgerCP.Text)
            Parametro(14) = DBParametro_Montar("IC_CONTABILIZA", "S")
        Else
            Parametro(6) = DBParametro_Montar("NU_CONTA_CONTABIL", Nothing)
            Parametro(7) = DBParametro_Montar("NU_CONTA_CONTABIL_CP", Nothing)
            Parametro(8) = DBParametro_Montar("IC_MUDA_CONTA_CONTABIL", Nothing)
            Parametro(9) = DBParametro_Montar("IC_MUDA_CONTA_CONTABIL_CP", Nothing)
            Parametro(10) = DBParametro_Montar("CD_SUB_LEDGER", Nothing)
            Parametro(11) = DBParametro_Montar("CD_SUB_LEDGER_CP", Nothing)
            Parametro(12) = DBParametro_Montar("CD_TIPO_SUB_LEDGER", Nothing)
            Parametro(13) = DBParametro_Montar("CD_TIPO_SUB_LEDGER_CP", Nothing)
            Parametro(14) = DBParametro_Montar("IC_CONTABILIZA", "N")
        End If

        Parametro(15) = DBParametro_Montar("IC_VALIDA_KG", IIf(chkValidaQuilos.Checked, "S", "N"))
        Parametro(16) = DBParametro_Montar("IC_VALIDA_QUALIDADE", IIf(chkValidaQuatidade.Checked, "S", "N"))
        Parametro(17) = DBParametro_Montar("IC_VALIDA_VALOR", IIf(chkValidaValor.Checked, "S", "N"))
        Parametro(18) = DBParametro_Montar("IC_FISCAL", IIf(chkMovimentacaoFiscal.Checked, "S", "N"))
        Parametro(19) = DBParametro_Montar("IC_POSTO_FIXO", IIf(chkLocalEntregaFixa.Checked, "S", "N"))

        If chkLocalEntregaFixa.Checked Then
            Parametro(20) = DBParametro_Montar("CD_LOCAL_ENTREGA", cboLocalEntrega.SelectedValue)
        Else
            Parametro(20) = DBParametro_Montar("CD_LOCAL_ENTREGA", Nothing)
        End If

        Parametro(21) = DBParametro_Montar("CD_CFOP_LOCAL_PJ_CLASS", NULLIf(txtCfopLocal_PJ.Text, ""))
        Parametro(22) = DBParametro_Montar("CD_CFOP_OUTROS_PJ_CLASS", NULLIf(txtCfopOutros_PJ.Text, ""))
        Parametro(23) = DBParametro_Montar("CD_CFOP_LOCAL_CLASS", NULLIf(txtCfopLocal.Text, ""))
        Parametro(24) = DBParametro_Montar("CD_SUFIXO_LOCAL_CLASS", NULLIf(txtSufixoLocal.Text, ""))
        Parametro(25) = DBParametro_Montar("CD_FORMA_TRIBUT_LOCAL_CLASS", NULLIf(txtFormaTributacaoLocal.Text, ""))
        Parametro(26) = DBParametro_Montar("CD_TRIBUT_ICMS_LOCAL_CLASS", NULLIf(txtTributacaoIcmsLocal.Text, ""))
        Parametro(27) = DBParametro_Montar("CD_SITUACAO_TRIBUT_LOCAL_CLASS", NULLIf(txtSituacaoTributacaoLocal.Text, ""))
        Parametro(28) = DBParametro_Montar("CD_CFOP_OUTROS_CLASS", NULLIf(txtCfopOutros.Text, ""))
        Parametro(29) = DBParametro_Montar("CD_SUFIXO_OUTROS_CLASS", NULLIf(txtSufixoOutros.Text, ""))
        Parametro(30) = DBParametro_Montar("CD_FORMA_TRIBUT_OUTROS_CLASS", NULLIf(txtFormaTributacaoOutros.Text, ""))
        Parametro(31) = DBParametro_Montar("CD_TRIBUT_ICMS_OUTROS_CLASS", NULLIf(txtTributacaoIcmsOutros.Text, ""))
        Parametro(32) = DBParametro_Montar("CD_SITUACAO_TRIBU_OUTROS_CLASS", NULLIf(txtSituacaoTributacaoOutros.Text, ""))
        Parametro(33) = DBParametro_Montar("CD_PRINT_MESSAGE_LOCAL_CLASS", NULLIf(txtPrintMessageLocal.Text, ""))
        Parametro(34) = DBParametro_Montar("CD_PRINT_MESSAGE_OUTROS_CLASS", NULLIf(txtPrintMessageOutros.Text, ""))
        Parametro(35) = DBParametro_Montar("IC_ENVIA_LIVRO_FISCAL", IIf(chkLivroFiscal.Checked, "S", "N"))
        Parametro(36) = DBParametro_Montar("IC_ATIVO", IIf(chkAtivo.Checked, "S", "N"))
        Parametro(37) = DBParametro_Montar("IC_APLICACAO", IIf(chkAplicacaoSaidaAplicacao.Checked, "S", "N"))
        Parametro(38) = DBParametro_Montar("CD_TP_MOV_FIXACAO_ENTRADA", NULLIf(cboAplicacaoCacau.SelectedValue, -1))
        Parametro(39) = DBParametro_Montar("CD_TP_MOV_FIXACAO_SAIDA", NULLIf(cboSaidaAplicacaoCacau.SelectedValue, -1))
        Parametro(40) = DBParametro_Montar("IC_SUB_LEDGER_CP", IIf(chkSubLedgerCP.Checked, "S", "N"))
        Parametro(41) = DBParametro_Montar("CD_TIPO_MOVIMENTACAO", txtCodigo.Value)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub chkAplicacaoSaidaAplicacao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAplicacaoSaidaAplicacao.CheckedChanged
        lblR_AplicacaoCacau.Enabled = (Not chkAplicacaoSaidaAplicacao.Checked)
        cboAplicacaoCacau.Enabled = (Not chkAplicacaoSaidaAplicacao.Checked)
        lblR_SaidaAplicacaoCacau.Enabled = (Not chkAplicacaoSaidaAplicacao.Checked)
        cboSaidaAplicacaoCacau.Enabled = (Not chkAplicacaoSaidaAplicacao.Checked)

        If Not cboAplicacaoCacau.Enabled Then
            cboAplicacaoCacau.SelectedIndex = -1
        End If
        If Not cboSaidaAplicacaoCacau.Enabled Then
            cboSaidaAplicacaoCacau.SelectedIndex = -1
        End If
    End Sub

    Private Sub chkSubLedgerCP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSubLedgerCP.CheckedChanged
        Validar_SubLedgerCP()
    End Sub

    Private Sub Validar_SubLedgerCP()
        lblR_SubLedgerCP.Enabled = chkSubLedgerCP.Checked
        txtSubLedgerCP.Enabled = chkSubLedgerCP.Checked
        lblR_TipoSubLedgerCP.Enabled = chkSubLedgerCP.Checked
        txtTipoSubLedgerCP.Enabled = chkSubLedgerCP.Checked

        If Not chkSubLedgerCP.Checked Then
            txtSubLedgerCP.Text = ""
            txtTipoSubLedgerCP.Text = ""
        End If
    End Sub
End Class