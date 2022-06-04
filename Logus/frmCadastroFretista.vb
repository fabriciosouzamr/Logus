Public Class frmCadastroFretista
    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim CdFretista As Integer

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmCadastroFretista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Tipo_Fretista(cboTipoFretista, True)
        ComboBox_Carregar_Tipo_Cobranca_Frete(cboTipoCobranca, True)

        ControleEdicaoTelaLocal = ControleEdicaoTela
        CdFretista = Filtro

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            CarregarDados()
        Else
            Validar_TipoPessoa()
        End If

        HabilitarControleValorFrete()
    End Sub

    Private Sub HabilitarControleValorFrete()
        Dim bHabilitar As Boolean

        bHabilitar = ComboBox_LinhaSelecionada(cboTipoCobranca)

        lblR_PercentualDespesa.Enabled = bHabilitar
        lblR_ValorDespesa.Enabled = bHabilitar
        lblR_ValorFrete.Enabled = bHabilitar
        txtPercentualDespesa.Enabled = bHabilitar
        txtValorDespesa.Enabled = bHabilitar
        txtValorFrete.Enabled = bHabilitar

        If Not bHabilitar Then
            txtPercentualDespesa.Value = 0
            txtValorDespesa.Value = 0
            txtValorFrete.Value = 0
        End If
    End Sub

    Private Sub cboTipoCobranca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoCobranca.SelectedIndexChanged
        Dim iAux As Integer

        HabilitarControleValorFrete()

        If Not ComboBox_LinhaSelecionada(cboTipoCobranca) Then
            iAux = -1
        Else
            iAux = cboTipoCobranca.SelectedValue
        End If

        If iAux = cnt_TipoCobrancaFrete_ImpostoInclusoValorCarga Or iAux = cnt_TipoCobrancaFrete_ImpostoInclusoValorTonelada Then
            txtValorDespesa.Value = 0
        End If

        lblR_ValorDespesa.Enabled = (iAux = cnt_TipoCobrancaFrete_ValorCarga Or iAux = cnt_TipoCobrancaFrete_ValorQuilo)
        txtValorDespesa.Enabled = (iAux = cnt_TipoCobrancaFrete_ValorCarga Or iAux = cnt_TipoCobrancaFrete_ValorQuilo)
    End Sub

    Private Sub optTipoPessoa_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipoPessoa.ValueChanged
        Validar_TipoPessoa()
    End Sub

    Private Sub Validar_TipoPessoa()
        If optTipoPessoa.Value = "J" Then
            txtCPF_CNPJ.Text = ""
            txtCPF_CNPJ.InputMask = "##.###.###/####-##"
            txtINSS.Text = ""
            lblR_INSS.Enabled = False
            txtINSS.Enabled = False
            txtPIS.Text = ""
            lblR_PIS.Enabled = False
            txtPIS.Enabled = False
        Else
            txtCPF_CNPJ.Text = ""
            txtCPF_CNPJ.InputMask = "###.###.###-##"
            lblR_INSS.Enabled = True
            txtINSS.Enabled = True
            lblR_PIS.Enabled = True
            txtPIS.Enabled = True
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(14) As DBParamentro

        If Not ComboBox_LinhaSelecionada(cboTipoFretista) Then
            Msg_Mensagem("Favor selecionar um tipo de fretista.")
            cboTipoFretista.Focus()
            Exit Sub
        End If

        If txtNome.Text = "" Then
            Msg_Mensagem("Favor informar o nome do fretista.")
            txtNome.Focus()
            Exit Sub
        End If

        If optTipoPessoa.Value = Nothing Then
            Msg_Mensagem("Favor informar se é pessoa fisica ou juridica.")
            optTipoPessoa.Focus()
            Exit Sub
        End If

        If optTipoPessoa.Value = "J" Then
            If Not Valida_CNPJ(SoNumero(txtCPF_CNPJ.Text)) Then
                Msg_Mensagem("CNPJ invalido.")
                txtCPF_CNPJ.Focus()
                Exit Sub
            End If
        Else
            If Not Valida_CPF(SoNumero(txtCPF_CNPJ.Text)) Then
                Msg_Mensagem("CPF invalido.")
                txtCPF_CNPJ.Focus()
                Exit Sub
            End If
            If txtINSS.Text = "" And txtPIS.Text = "" Then
                Msg_Mensagem("É necessario tem pelo menos a inscrição do INSS ou o numero do PIS/PASEP.")
                txtINSS.Focus()
                Exit Sub
            End If
        End If

        'If Existe_address_number Then
        '    Msg_Mensagem("Address Number ja cadastrado.")
        '    txtAddressNumber.Focus()
        '    Exit Sub
        'End If

        If ComboBox_LinhaSelecionada(cboTipoCobranca) Then
            If txtValorFrete.Value <= 0 Then
                Msg_Mensagem("Informe o valor do frete.")
                txtValorFrete.Focus()
                Exit Sub
            End If
        End If

        SqlText = DBMontar_SP("SOF.SP_MANUTENCAO_FRETISTA", False, ":NOFRETISTA", _
                                                                    ":ICFJ", _
                                                                    ":CPFCGC", _
                                                                    ":INSS", _
                                                                    ":PIS", _
                                                                    ":AN", _
                                                                    ":FAVORECIDO", _
                                                                    ":TPFRETISTA", _
                                                                    ":QTDEPENDENTE", _
                                                                    ":MANUT", _
                                                                    ":COD", _
                                                                    ":CDCALCULO_CARGA", _
                                                                    ":VLCALCULO_CARGA", _
                                                                    ":VLDESPESA", _
                                                                    ":PCDESPESA")

        Parametro(0) = DBParametro_Montar("NOFRETISTA", txtNome.Text)
        Parametro(1) = DBParametro_Montar("ICFJ", optTipoPessoa.Value)
        Parametro(2) = DBParametro_Montar("CPFCGC", txtCPF_CNPJ.Text)
        Parametro(3) = DBParametro_Montar("INSS", txtINSS.Text)
        Parametro(4) = DBParametro_Montar("PIS", txtPIS.Text)
        Parametro(5) = DBParametro_Montar("AN", txtAddressNumber.Value)
        Parametro(6) = DBParametro_Montar("FAVORECIDO", txtFavorecido.Text)
        Parametro(7) = DBParametro_Montar("TPFRETISTA", cboTipoFretista.SelectedValue)
        Parametro(8) = DBParametro_Montar("QTDEPENDENTE", txtDependentes.Value)
        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            Parametro(9) = DBParametro_Montar("MANUT", "I")
            Parametro(10) = DBParametro_Montar("COD", Nothing, , ParameterDirection.InputOutput)
        Else
            Parametro(9) = DBParametro_Montar("MANUT", "A")
            Parametro(10) = DBParametro_Montar("COD", CdFretista, , ParameterDirection.InputOutput)
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoCobranca) Then
            Parametro(11) = DBParametro_Montar("CDCALCULO_CARGA", Nothing)
        Else
            Parametro(11) = DBParametro_Montar("CDCALCULO_CARGA", cboTipoCobranca.SelectedValue)
        End If
        Parametro(12) = DBParametro_Montar("VLCALCULO_CARGA", NVL(txtValorFrete.Value, 0))
        Parametro(13) = DBParametro_Montar("VLDESPESA", NVL(txtValorDespesa.Value, 0))
        Parametro(14) = DBParametro_Montar("PCDESPESA", NVL(txtPercentualDespesa.Value, 0))

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        Select Case ControleEdicaoTelaLocal
            Case eControleEdicaoTela.INCLUIR
                Limpa_Tela()
                cboTipoFretista.Focus()
            Case eControleEdicaoTela.ALTERAR
                Me.Close()
        End Select

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub Limpa_Tela()
        ComboBox_Possicionar(cboTipoCobranca, -1)
        ComboBox_Possicionar(cboTipoFretista, -1)
        optTipoPessoa.Value = Nothing
        txtNome.Text = ""
        txtINSS.Text = ""
        txtPIS.Text = ""
        txtCPF_CNPJ.Value = Nothing
        txtAddressNumber.Value = Nothing
        txtDependentes.Value = 0
        txtFavorecido.Text = ""
        txtPercentualDespesa.Value = Nothing
        txtValorDespesa.Value = Nothing
        txtValorFrete.Value = Nothing
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * FROM SOF.FRETISTA WHERE CD_FRETISTA = " & CdFretista
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            ComboBox_Possicionar(cboTipoFretista, oData.Rows(0).Item("CD_TIPO_FRETISTA"))
            txtNome.Text = oData.Rows(0).Item("NO_FRETISTA")
            optTipoPessoa.Value = oData.Rows(0).Item("IC_FISICA_JURIDICA")
            optTipoPessoa_ValueChanged(Nothing, Nothing)
            Validar_TipoPessoa()
            txtCPF_CNPJ.Text = oData.Rows(0).Item("NU_CGC_CPF")
            txtINSS.Text = "" & oData.Rows(0).Item("NU_INSCRICAO_INSS")
            txtPIS.Text = "" & oData.Rows(0).Item("NU_PIS_PASEP")
            txtAddressNumber.Value = oData.Rows(0).Item("CD_ADDRESS_NUMBER")
            txtFavorecido.Text = "" & oData.Rows(0).Item("NO_FAVORECIDO")
            txtDependentes.Value = oData.Rows(0).Item("QT_DEPENDETES")

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("CD_CALCULO_CARGA")) Then
                If Not CampoNulo(oData.Rows(0).Item("CD_CALCULO_CARGA")) Then
                    ComboBox_Possicionar(cboTipoCobranca, oData.Rows(0).Item("CD_CALCULO_CARGA"))
                End If
                txtValorFrete.Value = NVL(oData.Rows(0).Item("VL_CALCULO_CARGA"), 0)
                txtValorDespesa.Value = NVL(oData.Rows(0).Item("VL_DESPESA"), 0)
                txtPercentualDespesa.Value = NVL(oData.Rows(0).Item("PC_DESPESA"), 0)
            End If
        End If
    End Sub

End Class