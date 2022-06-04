Public Class frmCadastroBonusPadrao
    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim CdBonusPadrao As Integer

    Private Sub frmCadastroBonusPadrao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        SqlText = "SELECT 'I', 'Inferior' "
        SqlText = SqlText & "  FROM DUAL "
        SqlText = SqlText & "UNION "
        SqlText = SqlText & "SELECT 'S', 'Superior' "
        SqlText = SqlText & "  FROM DUAL "

        DBCarregarComboBox(cboOperacao, SqlText, True)

        ListBox_Carregar_Origem(lstOrigem)

        ControleEdicaoTelaLocal = ControleEdicaoTela
        CdBonusPadrao = Filtro

        chkAchatada_CheckedChanged(Nothing, Nothing)
        chkArdosia_CheckedChanged(Nothing, Nothing)
        chkFumaca_CheckedChanged(Nothing, Nothing)
        chkMofo_CheckedChanged(Nothing, Nothing)
        chkPesoAmendoa_CheckedChanged(Nothing, Nothing)
        chkSujidade_CheckedChanged(Nothing, Nothing)
        chkUmidade_CheckedChanged(Nothing, Nothing)
        ComboBox_Carregar_Tipo_Adendo(cboTipoAdendo, True)

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            CarregarDados()
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub chkPesoAmendoa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPesoAmendoa.CheckedChanged
        If chkPesoAmendoa.Checked = True Then
            txtPesoAmendoaMin.Enabled = True
            txtPesoAmendoaMax.Enabled = True
        Else
            txtPesoAmendoaMin.Value = 0
            txtPesoAmendoaMin.Enabled = False
            txtPesoAmendoaMax.Value = 0
            txtPesoAmendoaMax.Enabled = False
        End If
    End Sub

    Private Sub chkMofo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMofo.CheckedChanged
        If chkMofo.Checked = True Then
            txtMofoMax.Enabled = True
            txtMofoMin.Enabled = True
        Else
            txtMofoMin.Value = 0
            txtMofoMin.Enabled = False
            txtMofoMax.Value = 0
            txtMofoMax.Enabled = False
        End If
    End Sub

    Private Sub chkFumaca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFumaca.CheckedChanged
        If chkFumaca.Checked = True Then
            txtFumacaMax.Enabled = True
            txtFumacaMin.Enabled = True
        Else
            txtFumacaMin.Value = 0
            txtFumacaMin.Enabled = False
            txtFumacaMax.Value = 0
            txtFumacaMax.Enabled = False
        End If
    End Sub

    Private Sub chkArdosia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkArdosia.CheckedChanged
        If chkArdosia.Checked = True Then
            txtArdosiaMax.Enabled = True
            txtArdosiaMin.Enabled = True
        Else
            txtArdosiaMax.Value = 0
            txtArdosiaMax.Enabled = False
            txtArdosiaMin.Value = 0
            txtArdosiaMin.Enabled = False
        End If
    End Sub

    Private Sub chkAchatada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAchatada.CheckedChanged
        If chkAchatada.Checked = True Then
            txtAchatadaMax.Enabled = True
            txtAchatadaMin.Enabled = True
        Else
            txtAchatadaMax.Value = 0
            txtAchatadaMax.Enabled = False
            txtAchatadaMin.Value = 0
            txtAchatadaMin.Enabled = False
        End If
    End Sub

    Private Sub chkSujidade_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSujidade.CheckedChanged
        If chkSujidade.Checked = True Then
            txtSujidadeMax.Enabled = True
            txtSujidadeMin.Enabled = True
        Else
            txtSujidadeMax.Value = 0
            txtSujidadeMax.Enabled = False
            txtSujidadeMin.Value = 0
            txtSujidadeMin.Enabled = False
        End If
    End Sub

    Private Sub chkUmidade_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUmidade.CheckedChanged
        If chkUmidade.Checked = True Then
            txtUmidadeMax.Enabled = True
            txtUmidadeMin.Enabled = True
        Else
            txtUmidadeMax.Value = 0
            txtUmidadeMax.Enabled = False
            txtUmidadeMin.Value = 0
            txtUmidadeMin.Enabled = False
        End If
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        txtValor.Value = 0
        txtFator.Value = 0
        ComboBox_Possicionar(cboOperacao, True)
        txtValor.Enabled = False
        txtFator.Enabled = False
        cboOperacao.Enabled = False

        Select Case optTipo.Value
            Case "P"
                txtValor.Enabled = True
            Case "V"
                txtValor.Enabled = True
                txtFator.Enabled = True
            Case "U", "S"
                txtValor.Enabled = True
                cboOperacao.Enabled = True
        End Select
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim iCont As Integer
        Dim oData As DataTable

        SqlText = "select * from sof.bonus_padrao where cd_bonus_padrao=" & CdBonusPadrao
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            lblCodigo.Text = oData.Rows(0).Item("cd_bonus_padrao")
            txtDescricao.Text = oData.Rows(0).Item("no_bonus_padrao")
            chkTipoI.Checked = IIf(oData.Rows(0).Item("ic_tipo_cacau_1") = "S", True, False)
            chkTipoII.Checked = IIf(oData.Rows(0).Item("ic_tipo_cacau_2") = "S", True, False)
            chkTipoIII.Checked = IIf(oData.Rows(0).Item("ic_tipo_cacau_3") = "S", True, False)
            chkTipoR.Checked = IIf(oData.Rows(0).Item("ic_tipo_cacau_4") = "S", True, False)

            If oData.Rows(0).Item("ic_calcula_peso_amendoa") = "S" Then
                chkPesoAmendoa.Checked = True
                chkPesoAmendoa_CheckedChanged(Nothing, Nothing)
                txtPesoAmendoaMin.Value = oData.Rows(0).Item("qt_peso_amendoa_min")
                txtPesoAmendoaMax.Value = oData.Rows(0).Item("qt_peso_amendoa_max")
            End If

            If oData.Rows(0).Item("ic_calcula_mofo") = "S" Then
                chkMofo.Checked = True
                chkMofo_CheckedChanged(Nothing, Nothing)
                txtMofoMin.Value = oData.Rows(0).Item("qt_Mofo_min")
                txtMofoMax.Value = oData.Rows(0).Item("qt_Mofo_max")
            End If

            If oData.Rows(0).Item("ic_calcula_fumaca") = "S" Then
                chkFumaca.Checked = True
                chkFumaca_CheckedChanged(Nothing, Nothing)
                txtFumacaMin.Value = oData.Rows(0).Item("qt_Fumaca_min")
                txtFumacaMax.Value = oData.Rows(0).Item("qt_Fumaca_max")
            End If

            If oData.Rows(0).Item("ic_calcula_ardosia") = "S" Then
                chkArdosia.Checked = True
                chkArdosia_CheckedChanged(Nothing, Nothing)
                txtArdosiaMin.Value = oData.Rows(0).Item("qt_ardosia_min")
                txtArdosiaMax.Value = oData.Rows(0).Item("qt_ardosia_max")
            End If

            If oData.Rows(0).Item("ic_calcula_achatada") = "S" Then
                chkAchatada.Checked = True
                chkAchatada_CheckedChanged(Nothing, Nothing)
                txtAchatadaMin.Value = oData.Rows(0).Item("qt_achatada_min")
                txtAchatadaMax.Value = oData.Rows(0).Item("qt_achatada_max")
            End If

            If oData.Rows(0).Item("ic_calcula_sujidade") = "S" Then
                chkSujidade.Checked = True
                chkSujidade_CheckedChanged(Nothing, Nothing)
                txtSujidadeMin.Value = oData.Rows(0).Item("pc_sujidade_min")
                txtSujidadeMax.Value = oData.Rows(0).Item("pc_sujidade_max")
            End If

            If oData.Rows(0).Item("ic_calcula_umidade") = "S" Then
                chkUmidade.Checked = True
                chkUmidade_CheckedChanged(Nothing, Nothing)
                txtUmidadeMin.Value = oData.Rows(0).Item("qt_umidade_min")
                txtUmidadeMax.Value = oData.Rows(0).Item("qt_umidade_max")
            End If

            If oData.Rows(0).Item("ic_premio_fixo") = "S" Then
                optTipo.Value = "V"
                txtValor.Value = oData.Rows(0).Item("vl_premio_fixo")
                txtFator.Value = oData.Rows(0).Item("qt_fator_premio_fixo")
            End If

            If oData.Rows(0).Item("ic_premio_variavel_umidade") = "S" Then
                optTipo.Value = "U"
                txtValor.Value = oData.Rows(0).Item("qt_umidade_padrao")
                ComboBox_Possicionar(cboOperacao, oData.Rows(0).Item("ic_operacao_variavel_umidade"))
            End If

            If oData.Rows(0).Item("ic_premio_variavel_sujidade") = "S" Then
                optTipo.Value = "S"
                txtValor.Value = oData.Rows(0).Item("pc_sujidade_padrao")
                ComboBox_Possicionar(cboOperacao, oData.Rows(0).Item("ic_operacao_variavel_sujidade"))
            End If

            If oData.Rows(0).Item("ic_premio_percentual_fixo") = "S" Then
                optTipo.Value = "P"
                txtValor.Value = oData.Rows(0).Item("pc_premio_fixo")
            End If

            If Not CampoNulo(oData.Rows(0).Item("cd_tipo_adendo")) Then
                ComboBox_Possicionar(cboTipoAdendo, oData.Rows(0).Item("cd_tipo_adendo"))
            End If


            chkAtivo.Checked = IIf(oData.Rows(0).Item("ic_ativo") = "S", True, False)
            chkGeraAuto.Checked = IIf(NVL(oData.Rows(0).Item("ic_geracao_automatica"), "N") = "S", True, False)

            txtDataContratoInicial.Value = oData.Rows(0).Item("DT_INICIO_VIGENCIA_CTR")

            If objDataTable_CampoVazio(oData.Rows(0).Item("DT_FINAL_VIGENCIA_CTR")) Then
                txtDataContratoFinal.Value = Nothing
            Else
                txtDataContratoFinal.Value = oData.Rows(0).Item("DT_FINAL_VIGENCIA_CTR")
            End If

            txtDataMovimentacaoInicial.Value = oData.Rows(0).Item("DT_INICIO_VIGENCIA_MOV")

            If objDataTable_CampoVazio(oData.Rows(0).Item("DT_FINAL_VIGENCIA_MOV")) Then
                txtDataMovimentacaoFinal.Value = Nothing
            Else
                txtDataMovimentacaoFinal.Value = oData.Rows(0).Item("DT_FINAL_VIGENCIA_MOV")
            End If

            SqlText = "select cd_uf from sof.bonus_padrao_uf where cd_bonus_padrao=" & CdBonusPadrao

            oData = DBQuery(SqlText)

            For iCont = 0 To oData.Rows.Count - 1
                CheckListBox_Possicionar(lstOrigem, oData.Rows(iCont).Item("cd_uf"))
            Next

        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(44) As DBParamentro
        Dim iCont As Integer

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar uma descrição.")
            txtDescricao.Focus()
            Exit Sub
        End If

        If chkTipoI.Checked = False And chkTipoII.Checked = False And chkTipoIII.Checked = False And chkTipoR.Checked = False Then
            Msg_Mensagem("Favor selecionar um tipo de cacau.")
            chkTipoI.Focus()
            Exit Sub
        End If

        If chkAchatada.Checked = True Then
            If txtAchatadaMin.Value > txtAchatadaMax.Value Then
                Msg_Mensagem("O valor minimo de achatada não pode ser superior ao valor maximo.")
                txtAchatadaMin.Focus()
                Exit Sub
            End If
        End If
        If chkArdosia.Checked = True Then
            If txtArdosiaMin.Value > txtArdosiaMax.Value Then
                Msg_Mensagem("O valor minimo de Ardosia não pode ser superior ao valor maximo.")
                txtArdosiaMin.Focus()
                Exit Sub
            End If
        End If
        If chkFumaca.Checked = True Then
            If txtFumacaMin.Value > txtFumacaMax.Value Then
                Msg_Mensagem("O valor minimo de Fumaca não pode ser superior ao valor maximo.")
                txtFumacaMin.Focus()
                Exit Sub
            End If
        End If
        If chkMofo.Checked = True Then
            If txtMofoMin.Value > txtMofoMax.Value Then
                Msg_Mensagem("O valor minimo de Mofo não pode ser superior ao valor maximo.")
                txtMofoMin.Focus()
                Exit Sub
            End If
        End If
        If chkPesoAmendoa.Checked = True Then
            If txtPesoAmendoaMin.Value > txtPesoAmendoaMax.Value Then
                Msg_Mensagem("O valor minimo de Peso Amendoa não pode ser superior ao valor maximo.")
                txtPesoAmendoaMin.Focus()
                Exit Sub
            End If
        End If
        If chkSujidade.Checked = True Then
            If txtSujidadeMin.Value > txtSujidadeMax.Value Then
                Msg_Mensagem("O valor minimo de Sujidade não pode ser superior ao valor maximo.")
                txtSujidadeMin.Focus()
                Exit Sub
            End If
        End If
        If chkUmidade.Checked = True Then
            If txtUmidadeMin.Value > txtUmidadeMax.Value Then
                Msg_Mensagem("O valor minimo de Umidade não pode ser superior ao valor maximo.")
                txtUmidadeMin.Focus()
                Exit Sub
            End If
        End If

        If optTipo.Value = Nothing Then
            Msg_Mensagem("Favor selecione uma forma de valorizar a bonificação.")
            optTipo.Focus()
            Exit Sub
        End If

        If optTipo.Value = "V" Then
            If txtValor.Value <= 0 Then
                Msg_Mensagem("Favor informar um valor.")
                txtValor.Focus()
                Exit Sub
            End If

            If txtFator.Value <= 0 Then
                Msg_Mensagem("Favor informar um fator.")
                txtFator.Focus()
                Exit Sub
            End If
        End If

        If optTipo.Value = "S" Or optTipo.Value = "U" Then
            If Not ComboBox_LinhaSelecionada(cboOperacao) Then
                Msg_Mensagem("Favor selecionar a operação.")
                cboOperacao.Focus()
                Exit Sub
            End If
        End If


        If optTipo.Value = "P" Then
            If txtValor.Value <= 0 Then
                Msg_Mensagem("Favor informar um percentual valido.")
                txtValor.Focus()
                Exit Sub
            End If
        End If

        If Not IsDate(txtDataContratoInicial.Value) Then
            Msg_Mensagem("Favor informar a data de inicio da vigencia dos contratos.")
            txtDataContratoInicial.Focus()
            Exit Sub
        End If

        If txtDataContratoFinal.Value <> Nothing And Not IsDate(txtDataContratoFinal.Value) Then
            Msg_Mensagem("Favor informar a data final da vigencia dos contratos.")
            txtDataContratoFinal.Focus()
            Exit Sub
        End If

        If Not IsDate(txtDataMovimentacaoInicial.Value) Then
            Msg_Mensagem("Favor informar a data de inicio da vigencia das movimentações.")
            txtDataMovimentacaoInicial.Focus()
            Exit Sub
        End If

        If txtDataMovimentacaoFinal.Value <> Nothing And Not IsDate(txtDataMovimentacaoFinal.Value) Then
            Msg_Mensagem("Favor informar a data final da vigencia das movimentações.")
            txtDataMovimentacaoFinal.Focus()
            Exit Sub
        End If

        If lstOrigem.CheckedItems.Count = 0 Then
            Msg_Mensagem("Favor selecionar uma origem.")
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboTipoAdendo) Then
            Msg_Mensagem("Favor selecionar o tipo de adendo.")
            cboTipoAdendo.Focus()
            Exit Sub
        End If



        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            CdBonusPadrao = DBNumeroMaisUm("SOF.BONUS_PADRAO", "CD_BONUS_PADRAO")

            SqlText = DBMontar_Insert("SOF.BONUS_PADRAO", TipoCampoFixo.Todos, "NO_BONUS_PADRAO", ":NO_BONUS_PADRAO", _
                                                                            "IC_TIPO_CACAU_1", ":IC_TIPO_CACAU_1", _
                                                                            "IC_TIPO_CACAU_2", ":IC_TIPO_CACAU_2", _
                                                                            "IC_TIPO_CACAU_3", ":IC_TIPO_CACAU_3", _
                                                                            "IC_TIPO_CACAU_4", ":IC_TIPO_CACAU_4", _
                                                                            "IC_CALCULA_PESO_AMENDOA", ":IC_CALCULA_PESO_AMENDOA", _
                                                                            "QT_PESO_AMENDOA_MIN", ":QT_PESO_AMENDOA_MIN", _
                                                                            "QT_PESO_AMENDOA_MAX", ":QT_PESO_AMENDOA_MAX", _
                                                                            "IC_CALCULA_MOFO", ":IC_CALCULA_MOFO", _
                                                                            "QT_MOFO_MIN", ":QT_MOFO_MIN", _
                                                                            "QT_MOFO_MAX", ":QT_MOFO_MAX", _
                                                                            "IC_CALCULA_FUMACA", ":IC_CALCULA_FUMACA", _
                                                                            "QT_FUMACA_MIN", ":QT_FUMACA_MIN", _
                                                                            "QT_FUMACA_MAX", ":QT_FUMACA_MAX", _
                                                                            "IC_CALCULA_ARDOSIA", ":IC_CALCULA_ARDOSIA", _
                                                                            "QT_ARDOSIA_MIN", ":QT_ARDOSIA_MIN", _
                                                                            "QT_ARDOSIA_MAX", ":QT_ARDOSIA_MAX", _
                                                                            "IC_CALCULA_ACHATADA", ":IC_CALCULA_ACHATADA", _
                                                                            "QT_ACHATADA_MIN", ":QT_ACHATADA_MIN", _
                                                                            "QT_ACHATADA_MAX", ":QT_ACHATADA_MAX", _
                                                                            "IC_CALCULA_SUJIDADE", ":IC_CALCULA_SUJIDADE", _
                                                                            "PC_SUJIDADE_MIN", ":PC_SUJIDADE_MIN", _
                                                                            "PC_SUJIDADE_MAX", ":PC_SUJIDADE_MAX", _
                                                                            "IC_CALCULA_UMIDADE", ":IC_CALCULA_UMIDADE", _
                                                                            "QT_UMIDADE_MIN", ":QT_UMIDADE_MIN", _
                                                                            "QT_UMIDADE_MAX", ":QT_UMIDADE_MAX", _
                                                                            "IC_PREMIO_FIXO", ":IC_PREMIO_FIXO", _
                                                                            "VL_PREMIO_FIXO", ":VL_PREMIO_FIXO", _
                                                                            "QT_FATOR_PREMIO_FIXO", ":QT_FATOR_PREMIO_FIXO", _
                                                                            "IC_PREMIO_VARIAVEL_UMIDADE", ":IC_PREMIO_VARIAVEL_UMIDADE", _
                                                                            "QT_UMIDADE_PADRAO", ":QT_UMIDADE_PADRAO", _
                                                                            "IC_OPERACAO_VARIAVEL_UMIDADE", ":IC_OPERACAO_VARIAVEL_UMIDADE", _
                                                                            "IC_PREMIO_VARIAVEL_SUJIDADE", ":IC_PREMIO_VARIAVEL_SUJIDADE", _
                                                                            "PC_SUJIDADE_PADRAO", ":PC_SUJIDADE_PADRAO", _
                                                                            "IC_OPERACAO_VARIAVEL_SUJIDADE", ":IC_OPERACAO_VARIAVEL_SUJIDADE", _
                                                                            "IC_PREMIO_PERCENTUAL_FIXO", ":IC_PREMIO_PERCENTUAL_FIXO", _
                                                                            "PC_PREMIO_FIXO", ":PC_PREMIO_FIXO", _
                                                                            "IC_ATIVO", ":IC_ATIVO", _
                                                                            "DT_INICIO_VIGENCIA_CTR", ":DT_INICIO_VIGENCIA_CTR", _
                                                                            "DT_FINAL_VIGENCIA_CTR", ":DT_FINAL_VIGENCIA_CTR", _
                                                                            "DT_INICIO_VIGENCIA_MOV", ":DT_INICIO_VIGENCIA_MOV", _
                                                                            "DT_FINAL_VIGENCIA_MOV", ":DT_FINAL_VIGENCIA_MOV", _
                                                                            "IC_GERACAO_AUTOMATICA", ":IC_GERACAO_AUTOMATICA", _
                                                                            "CD_TIPO_ADENDO", ":CD_TIPO_ADENDO", _
                                                                            "CD_BONUS_PADRAO", ":CD_BONUS_PADRAO")
        Else
            SqlText = DBMontar_Update("SOF.BONUS_PADRAO", GerarArray("NO_BONUS_PADRAO", ":NO_BONUS_PADRAO", _
                                                                            "IC_TIPO_CACAU_1", ":IC_TIPO_CACAU_1", _
                                                                            "IC_TIPO_CACAU_2", ":IC_TIPO_CACAU_2", _
                                                                            "IC_TIPO_CACAU_3", ":IC_TIPO_CACAU_3", _
                                                                            "IC_TIPO_CACAU_4", ":IC_TIPO_CACAU_4", _
                                                                            "IC_CALCULA_PESO_AMENDOA", ":IC_CALCULA_PESO_AMENDOA", _
                                                                            "QT_PESO_AMENDOA_MIN", ":QT_PESO_AMENDOA_MIN", _
                                                                            "QT_PESO_AMENDOA_MAX", ":QT_PESO_AMENDOA_MAX", _
                                                                            "IC_CALCULA_MOFO", ":IC_CALCULA_MOFO", _
                                                                            "QT_MOFO_MIN", ":QT_MOFO_MIN", _
                                                                            "QT_MOFO_MAX", ":QT_MOFO_MAX", _
                                                                            "IC_CALCULA_FUMACA", ":IC_CALCULA_FUMACA", _
                                                                            "QT_FUMACA_MIN", ":QT_FUMACA_MIN", _
                                                                            "QT_FUMACA_MAX", ":QT_FUMACA_MAX", _
                                                                            "IC_CALCULA_ARDOSIA", ":IC_CALCULA_ARDOSIA", _
                                                                            "QT_ARDOSIA_MIN", ":QT_ARDOSIA_MIN", _
                                                                            "QT_ARDOSIA_MAX", ":QT_ARDOSIA_MAX", _
                                                                            "IC_CALCULA_ACHATADA", ":IC_CALCULA_ACHATADA", _
                                                                            "QT_ACHATADA_MIN", ":QT_ACHATADA_MIN", _
                                                                            "QT_ACHATADA_MAX", ":QT_ACHATADA_MAX", _
                                                                            "IC_CALCULA_SUJIDADE", ":IC_CALCULA_SUJIDADE", _
                                                                            "PC_SUJIDADE_MIN", ":PC_SUJIDADE_MIN", _
                                                                            "PC_SUJIDADE_MAX", ":PC_SUJIDADE_MAX", _
                                                                            "IC_CALCULA_UMIDADE", ":IC_CALCULA_UMIDADE", _
                                                                            "QT_UMIDADE_MIN", ":QT_UMIDADE_MIN", _
                                                                            "QT_UMIDADE_MAX", ":QT_UMIDADE_MAX", _
                                                                            "IC_PREMIO_FIXO", ":IC_PREMIO_FIXO", _
                                                                            "VL_PREMIO_FIXO", ":VL_PREMIO_FIXO", _
                                                                            "QT_FATOR_PREMIO_FIXO", ":QT_FATOR_PREMIO_FIXO", _
                                                                            "IC_PREMIO_VARIAVEL_UMIDADE", ":IC_PREMIO_VARIAVEL_UMIDADE", _
                                                                            "QT_UMIDADE_PADRAO", ":QT_UMIDADE_PADRAO", _
                                                                            "IC_OPERACAO_VARIAVEL_UMIDADE", ":IC_OPERACAO_VARIAVEL_UMIDADE", _
                                                                            "IC_PREMIO_VARIAVEL_SUJIDADE", ":IC_PREMIO_VARIAVEL_SUJIDADE", _
                                                                            "PC_SUJIDADE_PADRAO", ":PC_SUJIDADE_PADRAO", _
                                                                            "IC_OPERACAO_VARIAVEL_SUJIDADE", ":IC_OPERACAO_VARIAVEL_SUJIDADE", _
                                                                            "IC_PREMIO_PERCENTUAL_FIXO", ":IC_PREMIO_PERCENTUAL_FIXO", _
                                                                            "PC_PREMIO_FIXO", ":PC_PREMIO_FIXO", _
                                                                            "IC_ATIVO", ":IC_ATIVO", _
                                                                            "DT_INICIO_VIGENCIA_CTR", ":DT_INICIO_VIGENCIA_CTR", _
                                                                            "DT_FINAL_VIGENCIA_CTR", ":DT_FINAL_VIGENCIA_CTR", _
                                                                            "DT_INICIO_VIGENCIA_MOV", ":DT_INICIO_VIGENCIA_MOV", _
                                                                            "DT_FINAL_VIGENCIA_MOV", ":DT_FINAL_VIGENCIA_MOV", _
                                                                            "IC_GERACAO_AUTOMATICA", ":IC_GERACAO_AUTOMATICA", _
                                                                            "CD_TIPO_ADENDO", ":CD_TIPO_ADENDO"), _
                                                      GerarArray("CD_BONUS_PADRAO", ":CD_BONUS_PADRAO"))
        End If


        Parametro(0) = DBParametro_Montar("no_bonus_padrao", txtDescricao.Text)
        Parametro(1) = DBParametro_Montar("ic_tipo_cacau_1", IIf(chkTipoI.Checked, "S", "N"))
        Parametro(2) = DBParametro_Montar("ic_tipo_cacau_2", IIf(chkTipoII.Checked, "S", "N"))
        Parametro(3) = DBParametro_Montar("ic_tipo_cacau_3", IIf(chkTipoIII.Checked, "S", "N"))
        Parametro(4) = DBParametro_Montar("ic_tipo_cacau_4", IIf(chkTipoR.Checked, "S", "N"))

        If chkPesoAmendoa.Checked = True Then
            Parametro(5) = DBParametro_Montar("ic_calcula_peso_amendoa", "S")
            Parametro(6) = DBParametro_Montar("qt_peso_amendoa_min", txtPesoAmendoaMin.Value)
            Parametro(7) = DBParametro_Montar("qt_peso_amendoa_max", txtPesoAmendoaMax.Value)
        Else
            Parametro(5) = DBParametro_Montar("ic_calcula_peso_amendoa", "N")
            Parametro(6) = DBParametro_Montar("qt_peso_amendoa_min", Nothing)
            Parametro(7) = DBParametro_Montar("qt_peso_amendoa_max", Nothing)
        End If

        If Me.chkMofo.Checked = True Then
            Parametro(8) = DBParametro_Montar("ic_calcula_mofo", "S")
            Parametro(9) = DBParametro_Montar("qt_mofo_min", txtMofoMin.Value)
            Parametro(10) = DBParametro_Montar("qt_mofo_max", txtMofoMax.Value)
        Else
            Parametro(8) = DBParametro_Montar("ic_calcula_mofo", "N")
            Parametro(9) = DBParametro_Montar("qt_mofo_min", Nothing)
            Parametro(10) = DBParametro_Montar("qt_mofo_max", Nothing)
        End If

        If Me.chkFumaca.Checked = True Then
            Parametro(11) = DBParametro_Montar("ic_calcula_fumaca", "S")
            Parametro(12) = DBParametro_Montar("qt_fumaca_min", txtFumacaMin.Value)
            Parametro(13) = DBParametro_Montar("qt_fumaca_max", txtFumacaMax.Value)
        Else
            Parametro(11) = DBParametro_Montar("ic_calcula_fumaca", "N")
            Parametro(12) = DBParametro_Montar("qt_fumaca_min", Nothing)
            Parametro(13) = DBParametro_Montar("qt_fumaca_max", Nothing)
        End If

        If Me.chkArdosia.Checked = True Then
            Parametro(14) = DBParametro_Montar("ic_calcula_ardosia", "S")
            Parametro(15) = DBParametro_Montar("qt_ardosia_min", txtArdosiaMin.Value)
            Parametro(16) = DBParametro_Montar("qt_ardosia_max", txtArdosiaMax.Value)
        Else
            Parametro(14) = DBParametro_Montar("ic_calcula_ardosia", "N")
            Parametro(15) = DBParametro_Montar("qt_ardosia_min", Nothing)
            Parametro(16) = DBParametro_Montar("qt_ardosia_max", Nothing)
        End If

        If Me.chkAchatada.Checked = True Then
            Parametro(17) = DBParametro_Montar("ic_calcula_achatada", "S")
            Parametro(18) = DBParametro_Montar("qt_achatada_min", txtAchatadaMin.Value)
            Parametro(19) = DBParametro_Montar("qt_achatada_max", txtAchatadaMax.Value)
        Else
            Parametro(17) = DBParametro_Montar("ic_calcula_achatada", "N")
            Parametro(18) = DBParametro_Montar("qt_achatada_min", Nothing)
            Parametro(19) = DBParametro_Montar("qt_achatada_max", Nothing)
        End If

        If Me.chkSujidade.Checked = True Then
            Parametro(20) = DBParametro_Montar("ic_calcula_sujidade", "S")
            Parametro(21) = DBParametro_Montar("pc_sujidade_min", txtSujidadeMin.Value)
            Parametro(22) = DBParametro_Montar("pc_sujidade_max", txtSujidadeMax.Value)
        Else
            Parametro(20) = DBParametro_Montar("ic_calcula_sujidade", "N")
            Parametro(21) = DBParametro_Montar("pc_sujidade_min", Nothing)
            Parametro(22) = DBParametro_Montar("pc_sujidade_max", Nothing)
        End If

        If Me.chkUmidade.Checked = True Then
            Parametro(23) = DBParametro_Montar("ic_calcula_umidade", "S")
            Parametro(24) = DBParametro_Montar("qt_umidade_min", txtUmidadeMin.Value)
            Parametro(25) = DBParametro_Montar("qt_umidade_max", txtUmidadeMax.Value)
        Else
            Parametro(23) = DBParametro_Montar("ic_calcula_umidade", "N")
            Parametro(24) = DBParametro_Montar("qt_umidade_min", Nothing)
            Parametro(25) = DBParametro_Montar("qt_umidade_max", Nothing)
        End If

        If optTipo.Value = "V" Then
            Parametro(26) = DBParametro_Montar("ic_premio_fixo", "S")
            Parametro(27) = DBParametro_Montar("vl_premio_fixo", txtValor.Value)
            Parametro(28) = DBParametro_Montar("qt_fator_premio_fixo", txtFator.Value)
        Else
            Parametro(26) = DBParametro_Montar("ic_premio_fixo", "N")
            Parametro(27) = DBParametro_Montar("vl_premio_fixo", Nothing)
            Parametro(28) = DBParametro_Montar("qt_fator_premio_fixo", Nothing)
        End If

        If optTipo.Value = "U" Then
            Parametro(29) = DBParametro_Montar("ic_premio_variavel_umidade", "S")
            Parametro(30) = DBParametro_Montar("qt_umidade_padrao", txtValor.Value)
            Parametro(31) = DBParametro_Montar("ic_operacao_variavel_umidade", cboOperacao.SelectedValue)
        Else
            Parametro(29) = DBParametro_Montar("ic_premio_variavel_umidade", "N")
            Parametro(30) = DBParametro_Montar("qt_umidade_padrao", Nothing)
            Parametro(31) = DBParametro_Montar("ic_operacao_variavel_umidade", Nothing)
        End If

        If optTipo.Value = "S" Then
            Parametro(32) = DBParametro_Montar("ic_premio_variavel_sujidade", "S")
            Parametro(33) = DBParametro_Montar("pc_sujidade_padrao", txtValor.Value)
            Parametro(34) = DBParametro_Montar("ic_operacao_variavel_sujidade", cboOperacao.SelectedValue)
        Else
            Parametro(32) = DBParametro_Montar("ic_premio_variavel_sujidade", "N")
            Parametro(33) = DBParametro_Montar("pc_sujidade_padrao", Nothing)
            Parametro(34) = DBParametro_Montar("ic_operacao_variavel_sujidade", Nothing)
        End If

        If optTipo.Value = "P" Then
            Parametro(35) = DBParametro_Montar("ic_premio_percentual_fixo", "S")
            Parametro(36) = DBParametro_Montar("pc_premio_fixo", txtValor.Value)
        Else
            Parametro(35) = DBParametro_Montar("ic_premio_percentual_fixo", "N")
            Parametro(36) = DBParametro_Montar("pc_premio_fixo", Nothing)
        End If

        Parametro(37) = DBParametro_Montar("ic_ativo", IIf(Me.chkAtivo.Checked, "S", "N"))
        Parametro(38) = DBParametro_Montar("DT_INICIO_VIGENCIA_CTR", Date_to_Oracle(txtDataContratoInicial.Value), OracleClient.OracleType.DateTime)

        If txtDataContratoFinal.Value <> Nothing Then
            Parametro(39) = DBParametro_Montar("DT_FINAL_VIGENCIA_CTR", Date_to_Oracle(txtDataContratoFinal.Value), OracleClient.OracleType.DateTime)
        Else
            Parametro(39) = DBParametro_Montar("DT_FINAL_VIGENCIA_CTR", Nothing)
        End If

        Parametro(40) = DBParametro_Montar("DT_INICIO_VIGENCIA_MOV", Date_to_Oracle(txtDataMovimentacaoInicial.Value), OracleClient.OracleType.DateTime)
        If txtDataMovimentacaoFinal.Value <> Nothing Then
            Parametro(41) = DBParametro_Montar("DT_FINAL_VIGENCIA_MOV", Date_to_Oracle(txtDataMovimentacaoFinal.Value), OracleClient.OracleType.DateTime)
        Else
            Parametro(41) = DBParametro_Montar("DT_FINAL_VIGENCIA_MOV", Nothing)
        End If
        Parametro(42) = DBParametro_Montar("IC_GERACAO_AUTOMATICA", IIf(Me.chkGeraAuto.Checked, "S", "N"))

        If ComboBox_LinhaSelecionada(cboTipoAdendo) Then
            Parametro(43) = DBParametro_Montar("cd_tipo_adendo", cboTipoAdendo.SelectedValue)
        Else
            Parametro(43) = DBParametro_Montar("cd_tipo_adendo", Nothing)
        End If

        Parametro(44) = DBParametro_Montar("cd_bonus_padrao", CdBonusPadrao)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro


        SqlText = "delete from sof.bonus_padrao_uf where cd_bonus_padrao=" & CdBonusPadrao
        If Not DBExecutar(SqlText) Then GoTo Erro


        For iCont = 0 To lstOrigem.CheckedItems.Count - 1
            SqlText = "insert into sof.bonus_padrao_uf " & _
                      "(cd_bonus_padrao, cd_uf, dt_criacao, no_user_criacao) values " & _
                      "(" & CdBonusPadrao & ", '" & lstOrigem.CheckedItems(iCont)(0) & "', sysdate, '" & sAcesso_UsuarioLogado & "')"

            If Not DBExecutar(SqlText) Then GoTo Erro
        Next

        Close()

        Exit Sub
Erro:
        TratarErro()
    End Sub
End Class