Public Class frmCadastroFilial
    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim CdFilial As Integer = Nothing

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmCadastroFilial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CdFilial = Filtro
        ControleEdicaoTelaLocal = ControleEdicaoTela

        Pesq_Municipio.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Municipio

        ComboBox_Carregar_Filial(cboFilial, True, True)
        ComboBox_Carregar_Filial(cboFilialNF, True, True)
        ComboBox_Carregar_Local_Conferencia(cboLocalConferenciaPeso, True)
        ComboBox_Carregar_Local_Conferencia(cboLocalConferenciaQualidade, True)

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            CarregarDados(CdFilial)
        End If
    End Sub

    Private Sub CarregarDados(ByVal iCD_FILIAL As Integer)
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * FROM SOF.FILIAL WHERE CD_FILIAL=" & iCD_FILIAL
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            chkVerificaPagAberto.Checked = IIf(oData.Rows(0).Item("IC_VERIFICA_PAGAMENTO_FECHAMEN") = "S", True, False)
            chkAplicacaoPostoDiferente.Checked = IIf(oData.Rows(0).Item("IC_APLIC_POSTO_DIFERENTE") = "S", True, False)

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("IC_FILIAL_COM_ARMAZEM")) Then
                chkFilialDeEntrega.Checked = IIf(oData.Rows(0).Item("IC_FILIAL_COM_ARMAZEM") = "S", True, False)
            End If

            txtCodigo.Value = oData.Rows(0).Item("CD_FILIAL")
            Pesq_Municipio.Codigo = oData.Rows(0).Item("CD_MUNICIPIO")
            txtEndereco.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_ENDERECO"), "")
            txtNomeFantasia.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_FILIAL"), "")
            txtRazaoSocial.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_RAZAO"), "")
            txtNomeResumido.Text = objDataTable_LerCampo(oData.Rows(0).Item("NO_FILIAL_RESUMIDO"), "")
            txtCNPJ.Value = objDataTable_LerCampo(oData.Rows(0).Item("NU_CGC"), )
            txtFreteFilFab.Value = objDataTable_LerCampo(oData.Rows(0).Item("VL_FRETE_FILIAL_FABRICA"), 0)
            txtFreteFazFil.Value = objDataTable_LerCampo(oData.Rows(0).Item("VL_FRETE_FILIAL_FAZENDA"), 0)
            txtFreteFab.Value = objDataTable_LerCampo(oData.Rows(0).Item("VL_FRETE_FABRICA"), 0)
            txtQuantidadeVencida.Value = objDataTable_LerCampo(oData.Rows(0).Item("QT_LIMITE_CREDITO_VENCIDOS"), 0)
            txtValorVencida.Value = objDataTable_LerCampo(oData.Rows(0).Item("VL_LIMITE_CREDITO_VENCIDOS"), 0)
            txtQuantidadeAberto.Value = objDataTable_LerCampo(oData.Rows(0).Item("QT_LIMITE_CREDITO_ABERTO"), 0)
            txtValorAberto.Value = objDataTable_LerCampo(oData.Rows(0).Item("VL_LIMITE_CREDITO_ABERTO"), 0)
            txtISS.Value = objDataTable_LerCampo(oData.Rows(0).Item("PC_ALIQ_ISS"), 0)
            chkAtiva.Checked = IIf(oData.Rows(0).Item("IC_ATIVA") = "S", True, False)
            txtBranchPlant.Text = objDataTable_LerCampo(oData.Rows(0).Item("CD_BUSINESS_UNIT"), )
            txtCompanhiaFiscal.Text = objDataTable_LerCampo(oData.Rows(0).Item("CD_COMPANHIA_FISCAL"), )
            txtAddressNumber.Text = objDataTable_LerCampo(oData.Rows(0).Item("CD_ADDRESS_NUMBER"), Nothing)
            txtEndServidorBalancaPlataforma.Text = objDataTable_LerCampo(oData.Rows(0).Item("NM_SERVIDOR_BALANCA_TOLEDO"), )

            txtCEP.Value = Formatar(SoNumero(objDataTable_LerCampo(oData.Rows(0).Item("NU_CEP"), "")), "@@@@@-@@@")
            txtEmailSolicitacaoNF.Text = objDataTable_LerCampo(oData.Rows(0).Item("DS_EMAIL_NF"), "")
            If oData.Rows(0).Item("IC_ARMAZEM") = "S" Then
                Me.chkArmazem.Checked = True
                ComboBox_Possicionar(cboFilial, oData.Rows(0).Item("CD_FILIAL_RESPONSAVEL"))
            Else
                Me.chkArmazem.Checked = False
            End If

            ComboBox_Possicionar(cboFilialNF, NVL(oData.Rows(0).Item("CD_FILIAL_NF"), -1))
            ComboBox_Possicionar(cboLocalConferenciaPeso, NVL(oData.Rows(0).Item("CD_LOCAL_CONFERENCIA_PESO"), -1))
            ComboBox_Possicionar(cboLocalConferenciaQualidade, NVL(oData.Rows(0).Item("CD_LOCAL_CONFERENCIA_QUALIDADE"), -1))

            chkArmazem_CheckedChanged(Nothing, Nothing)
            txtCodigo.Enabled = False
        End If
    End Sub

    Private Sub chkArmazem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkArmazem.CheckedChanged
        If Me.chkArmazem.Checked = True Then
            Me.cboFilial.Enabled = True
        Else
            Me.cboFilial.Enabled = False
            ComboBox_Possicionar(cboFilial, -1)
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim oParametro(30) As DBParamentro

        On Error GoTo Erro

        If txtCodigo.Value = Nothing Then
            Msg_Mensagem("Favor informar o codigo da filial.")
            txtCodigo.Focus()
            Exit Sub
        End If
        If txtEndereco.Text = "" Then
            Msg_Mensagem("Favor informar o endereço.")
            txtEndereco.Focus()
            Exit Sub
        End If
        If txtNomeFantasia.Text = "" Then
            Msg_Mensagem("Favor informar o nome da filial.")
            txtNomeFantasia.Focus()
            Exit Sub
        End If
        If txtRazaoSocial.Text = "" Then
            Msg_Mensagem("Favor informar a razão social.")
            txtRazaoSocial.Focus()
            Exit Sub
        End If
        If Not Valida_CNPJ(SoNumero(txtCNPJ.Value)) Then
            Msg_Mensagem("O número do C.N.P.J. informado para a filial está inválido.")
            txtCNPJ.Focus()
            Exit Sub
        End If
        If Pesq_Municipio.Codigo = 0 Then
            Msg_Mensagem("Municipio invalido.")
            Pesq_Municipio.Focus()
            Exit Sub
        End If
        If chkArmazem.Checked = True Then
            If Not ComboBox_LinhaSelecionada(cboFilial) Then
                Msg_Mensagem("Favor informar a filial responsavel pelo armazém.")
                cboFilial.Focus()
                Exit Sub
            End If
        End If
        If Trim(txtBranchPlant.Text) = "" Then
            Msg_Mensagem("Favor informar o código da unidade de negocio.")
            txtBranchPlant.Focus()
            Exit Sub
        End If
        If Trim(txtCompanhiaFiscal.Text) = "" Then
            Msg_Mensagem("Favor informar a companhia fiscal.")
            txtCompanhiaFiscal.Focus()
            Exit Sub
        End If
        If Trim(txtAddressNumber.Text) = "" Then
            Msg_Mensagem("Favor informar o address number da filial.")
            txtAddressNumber.Focus()
            Exit Sub
        End If

        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            SqlText = DBMontar_Insert("SOF.FILIAL", TipoCampoFixo.DadoCriacao, "IC_VERIFICA_PAGAMENTO_FECHAMEN", ":IC_VERIFICA_PAGAMENTO_FECHAMEN", _
                                                                               "IC_APLIC_POSTO_DIFERENTE", ":IC_APLIC_POSTO_DIFERENTE", _
                                                                               "IC_FILIAL_COM_ARMAZEM", ":IC_FILIAL_COM_ARMAZEM", _
                                                                               "CD_MUNICIPIO", ":CD_MUNICIPIO", _
                                                                               "DS_ENDERECO", ":DS_ENDERECO", _
                                                                               "NO_FILIAL", ":NO_FILIAL", _
                                                                               "NO_FILIAL_RESUMIDO", ":NO_FILIAL_RESUMIDO", _
                                                                               "NO_RAZAO", ":NO_RAZAO", _
                                                                               "NU_CGC", ":NU_CGC", _
                                                                               "VL_FRETE_FILIAL_FABRICA", ":VL_FRETE_FILIAL_FABRICA", _
                                                                               "VL_FRETE_FILIAL_FAZENDA", ":VL_FRETE_FILIAL_FAZENDA", _
                                                                               "VL_FRETE_FABRICA", ":VL_FRETE_FABRICA", _
                                                                               "IC_FECHADA", ":IC_FECHADA", _
                                                                               "IC_ATIVA", ":IC_ATIVA", _
                                                                               "QT_LIMITE_CREDITO_VENCIDOS", ":QT_LIMITE_CREDITO_VENCIDOS", _
                                                                               "VL_LIMITE_CREDITO_VENCIDOS", ":VL_LIMITE_CREDITO_VENCIDOS", _
                                                                               "QT_LIMITE_CREDITO_ABERTO", ":QT_LIMITE_CREDITO_ABERTO", _
                                                                               "VL_LIMITE_CREDITO_ABERTO", ":VL_LIMITE_CREDITO_ABERTO", _
                                                                               "NU_CEP", ":NU_CEP", _
                                                                               "PC_ALIQ_ISS", ":PC_ALIQ_ISS", _
                                                                               "DS_EMAIL_NF", ":DS_EMAIL_NF", _
                                                                               "IC_ARMAZEM", ":IC_ARMAZEM", _
                                                                               "CD_FILIAL_RESPONSAVEL", ":CD_FILIAL_RESPONSAVEL", _
                                                                               "CD_BUSINESS_UNIT", ":CD_BUSINESS_UNIT", _
                                                                               "CD_COMPANHIA_FISCAL", ":CD_COMPANHIA_FISCAL", _
                                                                               "CD_ADDRESS_NUMBER", ":CD_ADDRESS_NUMBER", _
                                                                               "CD_LOCAL_CONFERENCIA_PESO", ":CD_LOCAL_CONFERENCIA_PESO", _
                                                                               "CD_LOCAL_CONFERENCIA_QUALIDADE", ":CD_LOCAL_CONFERENCIA_QUALIDADE", _
                                                                               "CD_FILIAL_NF", ":CD_FILIAL_NF", _
                                                                               "NM_SERVIDOR_BALANCA_TOLEDO", ":NM_SERVIDOR_BALANCA_TOLEDO", _
                                                                               "CD_FILIAL", ":CD_FILIAL")
        Else
            SqlText = DBMontar_Update("SOF.FILIAL", GerarArray("IC_VERIFICA_PAGAMENTO_FECHAMEN", ":IC_VERIFICA_PAGAMENTO_FECHAMEN", _
                                                               "IC_APLIC_POSTO_DIFERENTE", ":IC_APLIC_POSTO_DIFERENTE", _
                                                               "IC_FILIAL_COM_ARMAZEM", ":IC_FILIAL_COM_ARMAZEM", _
                                                               "CD_MUNICIPIO", ":CD_MUNICIPIO", _
                                                               "DS_ENDERECO", ":DS_ENDERECO", _
                                                               "NO_FILIAL", ":NO_FILIAL", _
                                                               "NO_FILIAL_RESUMIDO", ":NO_FILIAL_RESUMIDO", _
                                                               "NO_RAZAO", ":NO_RAZAO", _
                                                               "NU_CGC", ":NU_CGC", _
                                                               "VL_FRETE_FILIAL_FABRICA", ":VL_FRETE_FILIAL_FABRICA", _
                                                               "VL_FRETE_FILIAL_FAZENDA", ":VL_FRETE_FILIAL_FAZENDA", _
                                                               "VL_FRETE_FABRICA", ":VL_FRETE_FABRICA", _
                                                               "IC_FECHADA", ":IC_FECHADA", _
                                                               "IC_ATIVA", ":IC_ATIVA", _
                                                               "QT_LIMITE_CREDITO_VENCIDOS", ":QT_LIMITE_CREDITO_VENCIDOS", _
                                                               "VL_LIMITE_CREDITO_VENCIDOS", ":VL_LIMITE_CREDITO_VENCIDOS", _
                                                               "QT_LIMITE_CREDITO_ABERTO", ":QT_LIMITE_CREDITO_ABERTO", _
                                                               "VL_LIMITE_CREDITO_ABERTO", ":VL_LIMITE_CREDITO_ABERTO", _
                                                               "NU_CEP", ":NU_CEP", _
                                                               "PC_ALIQ_ISS", ":PC_ALIQ_ISS", _
                                                               "DS_EMAIL_NF", ":DS_EMAIL_NF", _
                                                               "IC_ARMAZEM", ":IC_ARMAZEM", _
                                                               "CD_FILIAL_RESPONSAVEL", ":CD_FILIAL_RESPONSAVEL", _
                                                               "CD_BUSINESS_UNIT", ":CD_BUSINESS_UNIT", _
                                                               "CD_COMPANHIA_FISCAL", ":CD_COMPANHIA_FISCAL", _
                                                               "CD_ADDRESS_NUMBER", ":CD_ADDRESS_NUMBER", _
                                                               "CD_LOCAL_CONFERENCIA_PESO", ":CD_LOCAL_CONFERENCIA_PESO", _
                                                               "CD_LOCAL_CONFERENCIA_QUALIDADE", ":CD_LOCAL_CONFERENCIA_QUALIDADE", _
                                                               "CD_FILIAL_NF", ":CD_FILIAL_NF", _
                                                               "NM_SERVIDOR_BALANCA_TOLEDO", ":NM_SERVIDOR_BALANCA_TOLEDO"), _
                                                    GerarArray("CD_FILIAL", ":CD_FILIAL"))
        End If

        oParametro(0) = DBParametro_Montar("IC_VERIFICA_PAGAMENTO_FECHAMEN", IIf(chkVerificaPagAberto.Checked, "S", "N"))
        oParametro(1) = DBParametro_Montar("IC_APLIC_POSTO_DIFERENTE", IIf(chkAplicacaoPostoDiferente.Checked, "S", "N"))
        oParametro(2) = DBParametro_Montar("IC_FILIAL_COM_ARMAZEM", IIf(chkFilialDeEntrega.Checked, "S", "N"))
        oParametro(3) = DBParametro_Montar("CD_MUNICIPIO", Pesq_Municipio.Codigo)
        oParametro(4) = DBParametro_Montar("DS_ENDERECO", txtEndereco.Text)
        oParametro(5) = DBParametro_Montar("NO_FILIAL", txtNomeFantasia.Text)
        oParametro(6) = DBParametro_Montar("NO_FILIAL_RESUMIDO", txtNomeResumido.Text)
        oParametro(7) = DBParametro_Montar("NO_RAZAO", txtRazaoSocial.Text)
        oParametro(8) = DBParametro_Montar("NU_CGC", NULLIf(Trim(txtCNPJ.Text), ""))
        oParametro(9) = DBParametro_Montar("VL_FRETE_FILIAL_FABRICA", NVL(txtFreteFilFab.Value, 0))
        oParametro(10) = DBParametro_Montar("VL_FRETE_FILIAL_FAZENDA", NVL(txtFreteFazFil.Value, 0))
        oParametro(11) = DBParametro_Montar("VL_FRETE_FABRICA", NVL(txtFreteFab.Value, 0))
        oParametro(12) = DBParametro_Montar("IC_FECHADA", "N")
        oParametro(13) = DBParametro_Montar("IC_ATIVA", IIf(chkAtiva.Checked, "S", "N"))
        oParametro(14) = DBParametro_Montar("QT_LIMITE_CREDITO_VENCIDOS", NULLIf(txtQuantidadeVencida.Value, 0))
        oParametro(15) = DBParametro_Montar("VL_LIMITE_CREDITO_VENCIDOS", NULLIf(txtValorVencida.Value, 0))
        oParametro(16) = DBParametro_Montar("QT_LIMITE_CREDITO_ABERTO", NULLIf(txtQuantidadeAberto.Value, 0))
        oParametro(17) = DBParametro_Montar("VL_LIMITE_CREDITO_ABERTO", NULLIf(txtValorAberto.Value, 0))
        oParametro(18) = DBParametro_Montar("NU_CEP", NULLIf(Trim(txtCEP.Text), ""))
        oParametro(19) = DBParametro_Montar("PC_ALIQ_ISS", NVL(txtISS.Value, 0))
        oParametro(20) = DBParametro_Montar("DS_EMAIL_NF", NULLIf(Trim(txtEmailSolicitacaoNF.Text), ""), OracleClient.OracleType.VarChar, , 200)
        oParametro(21) = DBParametro_Montar("IC_ARMAZEM", IIf(chkArmazem.Checked, "S", "N"))
        If chkArmazem.Checked = True Then
            oParametro(22) = DBParametro_Montar("CD_FILIAL_RESPONSAVEL", cboFilial.SelectedValue)
        Else
            oParametro(22) = DBParametro_Montar("CD_FILIAL_RESPONSAVEL", Nothing)
        End If
        oParametro(23) = DBParametro_Montar("CD_BUSINESS_UNIT", txtBranchPlant.Text)
        oParametro(24) = DBParametro_Montar("CD_COMPANHIA_FISCAL", txtCompanhiaFiscal.Text)
        oParametro(25) = DBParametro_Montar("CD_ADDRESS_NUMBER", txtAddressNumber.Text)

        If ComboBox_LinhaSelecionada(cboLocalConferenciaPeso) Then
            oParametro(26) = DBParametro_Montar("CD_LOCAL_CONFERENCIA_PESO", cboLocalConferenciaPeso.SelectedValue)
        Else
            oParametro(26) = DBParametro_Montar("CD_LOCAL_CONFERENCIA_PESO", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboLocalConferenciaQualidade) Then
            oParametro(27) = DBParametro_Montar("CD_LOCAL_CONFERENCIA_QUALIDADE", cboLocalConferenciaQualidade.SelectedValue)
        Else
            oParametro(27) = DBParametro_Montar("CD_LOCAL_CONFERENCIA_QUALIDADE", Nothing)
        End If
        If ComboBox_LinhaSelecionada(cboFilialNF) Then
            oParametro(28) = DBParametro_Montar("CD_FILIAL_NF", cboFilialNF.SelectedValue)
        Else
            oParametro(28) = DBParametro_Montar("CD_FILIAL_NF", Nothing)
        End If
        oParametro(29) = DBParametro_Montar("NM_SERVIDOR_BALANCA_TOLEDO", NULLIf(txtEndServidorBalancaPlataforma.Text, ""))
        oParametro(30) = DBParametro_Montar("CD_FILIAL", txtCodigo.Value)

        If Not DBExecutar(SqlText, oParametro) Then GoTo Erro

        Me.Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub txtCodigo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.ValueChanged

    End Sub
End Class