Public Class frmCadastroContratoPAF
    Dim CdFilialOrigem As Integer
    Dim PcJuros As Double
    Dim IcJurosCtrFix As String
    Dim IcJurosNeg As String
    Dim IcJurosNegRec As String

    Private Sub frmCadastroContratoPAF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_LimitarInclusaoCtrSomentoImportacao) Then
            Pesq_Fornecedor.BancoDados_Filtro_Adicionar("F.CD_TIPO_PESSOA = " & cnt_TipoPessoa_IMPORTADO)
        End If
        Pesq_Municipio.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Municipio

        ComboBox_Carregar_Filial(cboFilial, True)
        ComboBox_Carregar_Tipo_ContratoPAF(cboTipoContrato, False)

        Limpa_Tela()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim oData As DataTable

        If Pesq_Fornecedor.Codigo = 0 Then
            Msg_Mensagem("Favor informar um codigo de fornecedor valido.")
            Pesq_Fornecedor.Focus()
            Exit Sub
        End If

        SqlText = "SELECT DS_OBS FROM SOF.FORNECEDOR_OBS WHERE CD_FORNECEDOR=" & Pesq_Fornecedor.Codigo
        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            Msg_Mensagem(oData.Rows(0).Item("ds_obs"))
            If Not Msg_Perguntar("Continua a inclusão ?") Then Exit Sub
        End If

        If txtQuantidade.Value <= 0 Then
            Msg_Mensagem("Favor informar a quantidade em quilos do contrato maior do que 0.")
            txtQuantidade.Focus()
            Exit Sub
        End If

        If Not IsDate(txtDataEntrega.Text) Then
            Msg_Mensagem("Prazo de entrega invalido.")
            txtDataEntrega.Focus()
            Exit Sub
        End If

        If CDate(txtDataEntrega.Text) < DataSistema() Then
            Msg_Mensagem("Prazo de entrega menor que a data atual")
            txtDataEntrega.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboTipoContrato) Then
            Msg_Mensagem("Favor informar um tipo de contrato.")
            cboTipoContrato.Focus()
            Exit Sub
        End If

        'If txtValorAdiantamento.Enabled Then
        '    If txtValorAdiantamento.Value = 0 Then
        '        Msg_Mensagem("Favor informar o valor do adiantamento.")
        '        txtValorAdiantamento.Focus()
        '        Exit Sub
        '    End If
        'End If

        If chkCobraJuros.Checked = True Then
            If txtDiasCarencia.Value < 0 Then
                Msg_Mensagem("Favor informar a quantidade de dias valido de carencia do juros.")
                txtDiasCarencia.Focus()
                Exit Sub
            End If
            If txtTaxaJuros.Value = 0 Then
                Msg_Mensagem("Voce informou que sera cobrado juros, por isso, favor informar a taxa de juros a ser cobrada.")
                txtTaxaJuros.Focus()
                Exit Sub
            End If
        End If

        If Not ComboBox_LinhaSelecionada(cboFilial) Then
            Msg_Mensagem("Favor selecionar uma filial para entrega da mercadoria.")
            cboFilial.Focus()
            Exit Sub
        End If

        If txtDataFixacao.Enabled = True Then
            If Not IsDate(txtDataFixacao.Text) Then
                Msg_Mensagem("Prazo de fixação invalido.")
                txtDataFixacao.Focus()
                Exit Sub
            End If
            If CDate(txtDataFixacao.Text) <= DataSistema() Then
                Msg_Mensagem("Prazo de fixação inferior ou igual a hoje.")
                txtDataFixacao.Focus()
                Exit Sub
            End If
        End If

        If Pesq_Municipio.Codigo = 0 Then
            Msg_Mensagem("Favor informar o municipio de origem.")
            Pesq_Municipio.Focus()
            Exit Sub
        End If

        If cboContratoPAF.Enabled = True Then
            If Not ComboBox_LinhaSelecionada(cboContratoPAF) Then
                Msg_Mensagem("Favor selecionar um Contrato PAF que esta dando origem a esse.")
                cboContratoPAF.Focus()
                Exit Sub
            End If
        End If

        If FilialFechada(CdFilialOrigem) Then
            Msg_Mensagem("A Filial está fechada. No momento não é possivel incluir o contrato PAF.")
            Exit Sub
        End If

        DBUsarTransacao = True

        If Not Inclui_Contrato_PAF() Then
            DBUsarTransacao = False
            Exit Sub
        End If

        If cboContratoPAF.Enabled = True Then
            Aplica_Cacau_Contrato_PAF(cboContratoPAF.SelectedValue, _
                                      txtQuantidade.Value, _
                                      lblContrato.Text, False, , , _
                                      CdFilialOrigem)
        End If

        If Not DBExecutarTransacao() Then GoTo Erro

        cmdNovo.Visible = True
        cmdGravar.Enabled = False
        grpDados.Enabled = False

        If NVL(cboTipoContrato.SelectedItem(MOD_Declaracao_Local.ComboBox_ContratoPaf_Info.IC_ADIANTAMENTO), "N") = "N" Then
            cmdImprimir.Visible = (Documento_Relatorio_Versao_Documento(enDocumento_Relatorio.eContratoPAF_Master, Now.Date) <> enDocumento_Relatorio.eSemImpressao)
        Else
            cmdImprimir.Visible = True
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Function Inclui_Contrato_PAF() As Boolean
        Dim Parametro(31) As DBParamentro
        Dim CdRepassador As Integer
        Dim CdLocalConferenciaQualidade As String
        Dim CdLocalConferenciaPeso As String
        Dim CdFilialNF As Integer
        Dim SqlText As String
        Dim odata As DataTable
        Dim bOK As Boolean = False

        '==>campos default
        Const cnt_TipoQualidade As Integer = 4
        Const cnt_TipoAcondicionamento As Integer = 1
        Const cnt_TipoCondicaoPagamento As Integer = 1
        Const cnt_TipoModalidadeEntrega As Integer = 3
        Const cnt_TipoDespesaCarregamento As Integer = 1


        '==>pego o repassador
        SqlText = "SELECT NVL( CD_REPASSADOR,CD_FORNECEDOR) " & _
                    "FROM SOF.FORNECEDOR F " & _
                    "WHERE F.CD_FORNECEDOR=" & Pesq_Fornecedor.Codigo
        CdRepassador = DBQuery_ValorUnico(SqlText)

        '==>Pego dados do cadastro de filial
        SqlText = "SELECT cd_local_conferencia_peso, cd_local_conferencia_qualidade, "
        SqlText = SqlText & "       cd_filial_nf "
        SqlText = SqlText & "  FROM sof.filial "
        SqlText = SqlText & " WHERE (NOT cd_local_conferencia_peso IS NULL "
        SqlText = SqlText & "    OR NOT cd_local_conferencia_qualidade IS NULL "
        SqlText = SqlText & "    OR NOT cd_filial_nf IS NULL) "
        SqlText = SqlText & "    and cd_filial = " & cboFilial.SelectedValue
        odata = DBQuery(SqlText)

        If objDataTable_Vazio(odata) Then
            Msg_Mensagem("Favor atualizar o cadastro da filial com informações do local de conferência e filial para impressão da NF.")
            GoTo Sair
        Else
            CdLocalConferenciaQualidade = odata.Rows(0).Item("cd_local_conferencia_qualidade")
            CdLocalConferenciaPeso = odata.Rows(0).Item("cd_local_conferencia_peso")
            CdFilialNF = odata.Rows(0).Item("cd_filial_nf")
        End If

        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONTRATO_PAF", False, ":CDFORNECEDOR", _
                                                                    ":CDREPASSADOR", _
                                                                    ":CDTIPOCONTRATOPAF", _
                                                                    ":DTCONTRATOPAF", _
                                                                    ":QTKGS", _
                                                                    ":DTVENCIMENTO", _
                                                                    ":CDFILIALORIGEM", _
                                                                    ":VLADIANTAMENTO", _
                                                                    ":CDSAFRA", _
                                                                    ":CDSAFRACOMPETENCIA", _
                                                                    ":CDTIPOACONDICIONAMENTO", _
                                                                    ":CDTIPOMODALIDADEENTREGA", _
                                                                    ":CDLOCALCONFERENCIAPESO", _
                                                                    ":CDLOCALCONFERENCIAQUALIDADE", _
                                                                    ":CDTIPODESPESACARREGAMENTO", _
                                                                    ":ICCALCULAJUROS", _
                                                                    ":QTDIACARENCIAJUROS", _
                                                                    ":CDTIPOQUALIDADE", _
                                                                    ":CDFILIANF", _
                                                                    ":CDFILIALENTREGA", _
                                                                    ":CDTIPOCONDICAOPAGAMENTO", _
                                                                    ":CDMUNICIPIO", _
                                                                    ":PCTAXAJUROS", _
                                                                    ":ICJUROSAPOSCARENCIA", _
                                                                    ":DTPRAZOFIXACAO", _
                                                                    ":CDCTRPAFORIGEM", _
                                                                    ":ICJUROSNEG", _
                                                                    ":ICJUROSCTRFIX", _
                                                                    ":ICJUROSNEGREC", _
                                                                    ":NUMINI", _
                                                                    ":NUMFIM", _
                                                                    ":CDCONTRATOPAF")

        Parametro(0) = DBParametro_Montar("CDFORNECEDOR", Pesq_Fornecedor.Codigo)
        Parametro(1) = DBParametro_Montar("CDREPASSADOR", CdRepassador)
        Parametro(2) = DBParametro_Montar("CDTIPOCONTRATOPAF", cboTipoContrato.SelectedValue)
        Parametro(3) = DBParametro_Montar("DTCONTRATOPAF", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime)
        Parametro(4) = DBParametro_Montar("QTKGS", txtQuantidade.Value)
        Parametro(5) = DBParametro_Montar("DTVENCIMENTO", Date_to_Oracle(txtDataEntrega.Text), OracleClient.OracleType.DateTime)
        Parametro(6) = DBParametro_Montar("CDFILIALORIGEM", CdFilialOrigem)

        If txtValorAdiantamento.Enabled = True Then
            Parametro(7) = DBParametro_Montar("VLADIANTAMENTO", txtValorAdiantamento.Value)
        Else
            Parametro(7) = DBParametro_Montar("VLADIANTAMENTO", Nothing)
        End If

        Parametro(8) = DBParametro_Montar("CDSAFRA", Safra)
        Parametro(9) = DBParametro_Montar("CDSAFRACOMPETENCIA", Safra)
        Parametro(10) = DBParametro_Montar("CDTIPOACONDICIONAMENTO", cnt_TipoAcondicionamento)
        Parametro(11) = DBParametro_Montar("CDTIPOMODALIDADEENTREGA", cnt_TipoModalidadeEntrega)
        Parametro(12) = DBParametro_Montar("CDLOCALCONFERENCIAPESO", CdLocalConferenciaPeso)
        Parametro(13) = DBParametro_Montar("CDLOCALCONFERENCIAQUALIDADE", CdLocalConferenciaQualidade)
        Parametro(14) = DBParametro_Montar("CDTIPODESPESACARREGAMENTO", cnt_TipoDespesaCarregamento)

        If chkCobraJuros.Checked = True Then
            Parametro(15) = DBParametro_Montar("ICCALCULAJUROS", "S")
            Parametro(16) = DBParametro_Montar("QTDIACARENCIAJUROS", txtDiasCarencia.Value)
        Else
            Parametro(15) = DBParametro_Montar("ICCALCULAJUROS", "N")
            Parametro(16) = DBParametro_Montar("QTDIACARENCIAJUROS", Nothing)
        End If

        Parametro(17) = DBParametro_Montar("CDTIPOQUALIDADE", cnt_TipoQualidade)
        Parametro(18) = DBParametro_Montar("CDFILIANF", CdFilialNF)
        Parametro(19) = DBParametro_Montar("CDFILIALENTREGA", cboFilial.SelectedValue)
        Parametro(20) = DBParametro_Montar("CDTIPOCONDICAOPAGAMENTO", cnt_TipoCondicaoPagamento)
        Parametro(21) = DBParametro_Montar("CDMUNICIPIO", Pesq_Municipio.Codigo)

        If grpJuros.Enabled = True Then
            Parametro(22) = DBParametro_Montar("PCTAXAJUROS", txtTaxaJuros.Value)
            Parametro(23) = DBParametro_Montar("ICJUROSAPOSCARENCIA", IIf(chkJurosAposCarencia.Checked = True, "S", "N"))
        Else
            Parametro(22) = DBParametro_Montar("PCTAXAJUROS", Nothing)
            Parametro(23) = DBParametro_Montar("ICJUROSAPOSCARENCIA", Nothing)
        End If

        If txtDataFixacao.Enabled = True Then
            Parametro(24) = DBParametro_Montar("DTPRAZOFIXACAO", Date_to_Oracle(txtDataFixacao.Text), OracleClient.OracleType.DateTime)
        Else
            Parametro(24) = DBParametro_Montar("DTPRAZOFIXACAO", Nothing)
        End If

        If cboContratoPAF.Enabled = True Then
            Parametro(25) = DBParametro_Montar("CDCTRPAFORIGEM", cboContratoPAF.SelectedValue)
        Else
            Parametro(25) = DBParametro_Montar("CDCTRPAFORIGEM", Nothing)
        End If

        If chkCobraJuros.Checked = True Then
            Parametro(26) = DBParametro_Montar("ICJUROSNEG", IcJurosNeg)
            Parametro(27) = DBParametro_Montar("ICJUROSCTRFIX", IcJurosCtrFix)
            Parametro(28) = DBParametro_Montar("ICJUROSNEGREC", IcJurosNegRec)
        Else
            Parametro(26) = DBParametro_Montar("ICJUROSNEG", Nothing)
            Parametro(27) = DBParametro_Montar("ICJUROSCTRFIX", Nothing)
            Parametro(28) = DBParametro_Montar("ICJUROSNEGREC", Nothing)
        End If

        Parametro(29) = DBParametro_Montar("NUMINI", Val(CStr(CdFilialOrigem) & StrZero(CLng(Safra), 2) & "0000"))
        Parametro(30) = DBParametro_Montar("NUMFIM", Val(CStr(CdFilialOrigem) & StrZero(CLng(Safra), 2) & "9999"))
        Parametro(31) = DBParametro_Montar("CDCONTRATOPAF", Nothing, , ParameterDirection.Output)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        If DBTeveRetorno() Then
            lblContrato.Text = DBRetorno(1)
        End If

        bOK = True

Sair:
        Return bOK

        Exit Function

Erro:
        TratarErro()
        Return bOK
    End Function

    Private Sub Pega_Juros_Padrao()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "select pc_juros_ao_mes, IC_JUROS_NEG_REC, nu_dias_max_carencia_juros, " & _
                  "ic_juros_neg, ic_juros_ctr_fix " & _
                  "from sof.parametro"

        oData = DBQuery(SqlText)

        If oData.Rows.Count <> 0 Then
            PcJuros = oData.Rows(0).Item("pc_juros_ao_mes")

            IcJurosCtrFix = oData.Rows(0).Item("ic_juros_ctr_fix")
            IcJurosNeg = oData.Rows(0).Item("ic_juros_neg")
            IcJurosNegRec = oData.Rows(0).Item("IC_JUROS_NEG_REC")
        Else
            PcJuros = 0
            IcJurosCtrFix = "N"
            IcJurosNeg = "N"
            IcJurosNegRec = "N"
        End If

    End Sub

    Private Sub Pesq_Fornecedor_AlterouRegistro() Handles Pesq_Fornecedor.AlterouRegistro
        Dim Sqltext As String

        If Pesq_Fornecedor.Codigo <= 0 Then Exit Sub


        Sqltext = "select ic_lista_negra " & _
                         "from sof.fornecedor " & _
                         "where cd_fornecedor = " & Pesq_Fornecedor.Codigo


        If DBQuery_ValorUnico(Sqltext) = "S" Then
            Msg_Mensagem("Este fornecedor está na Lista Negra !!")
            Pesq_Fornecedor.Codigo = 0
            Exit Sub
        End If


        'verifica se fornecedor pertence as filiais do usuario
        Sqltext = "select count(*) "
        Sqltext = Sqltext & " from sof.filial f "
        Sqltext = Sqltext & " where f.cd_filial in (" & ListarIDFiliaisLiberadaUsuario() & ") "

        If DBQuery_ValorUnico(Sqltext) = 0 Then
            Msg_Mensagem("Este fornecedor não pertence a nenhuma das filiais liberadas para o seu acesso")
            Pesq_Fornecedor.Codigo = 0
            Exit Sub
        End If


        '==>pego o filial de origem
        Sqltext = "SELECT cd_filial_origem " & _
                    "FROM SOF.FORNECEDOR F " & _
                    "WHERE F.CD_FORNECEDOR=" & Pesq_Fornecedor.Codigo
        CdFilialOrigem = DBQuery_ValorUnico(Sqltext)

        Sqltext = "select CP.cd_contrato_paf, To_char(CP.cd_contrato_paf) as no_contrato_paf  " & _
                    "from sof.contrato_paf CP, SOF.TIPO_CONTRATO_PAF TCP " & _
                    "where CP.CD_TIPO_CONTRATO_PAF=TCP.CD_TIPO_CONTRATO_PAF AND " & _
                    "CP.cd_fornecedor = " & Pesq_Fornecedor.Codigo & " AND " & _
                    "CP.IC_STATUS = 'A'  AND " & _
                    "TCP.IC_ADIANTAMENTO = 'N' " & _
                    "order by CP.cd_contrato_paf"

        DBCarregarComboBox(cboContratoPAF, Sqltext, True)
    End Sub

    Private Sub Limpa_adiantamento()
        txtValorAdiantamento.Value = 0
        txtValorAdiantamento.Enabled = False
        txtDataFixacao.Value = Nothing
        txtDataFixacao.Enabled = False
        chkCobraJuros.Checked = False
        chkCobraJuros.Enabled = False
        chkCobraJuros_CheckedChanged(Nothing, Nothing)
        ComboBox_Possicionar(cboContratoPAF, -1)
        cboContratoPAF.Enabled = False
    End Sub

    Private Sub chkCobraJuros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCobraJuros.CheckedChanged
        If chkCobraJuros.Checked = True Then
            txtDiasCarencia.Enabled = True
            txtDiasCarencia.Value = 0
            txtTaxaJuros.Enabled = True
            txtTaxaJuros.Value = PcJuros
            chkJurosAposCarencia.Checked = True
        Else
            txtDiasCarencia.Value = 0
            txtDiasCarencia.Enabled = False
            txtTaxaJuros.Value = 0
            txtTaxaJuros.Enabled = False
            chkJurosAposCarencia.Checked = True
        End If
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Limpa_Tela()
        Pesq_Fornecedor.Focus()
    End Sub

    Private Sub Limpa_Tela()
        Pesq_Fornecedor.Codigo = 0
        Pesq_Municipio.Codigo = 0
        txtValorAdiantamento.Value = 0
        ComboBox_Possicionar(cboFilial, FilialLogada)
        ComboBox_Possicionar(cboTipoContrato, -1)
        ComboBox_Possicionar(cboContratoPAF, -1)
        txtQuantidade.Value = 0
        txtDataEntrega.Value = Nothing
        txtDataFixacao.Value = Nothing
        lblContrato.Text = "NOVO"
        txtDataContrato.Value = DataSistema()
        'cmdimprime.Visible = False
        cmdNovo.Visible = False
        cmdImprimir.Visible = False
        cmdGravar.Enabled = True
        grpDados.Enabled = True
        cboTipoContrato_SelectedIndexChanged(Nothing, Nothing)
        Pega_Juros_Padrao()
    End Sub

    Private Sub cboTipoContrato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoContrato.SelectedIndexChanged
        Dim SqlText As String

        If Not ComboBox_LinhaSelecionada(cboTipoContrato) Then
            Limpa_adiantamento()
            Exit Sub
        End If

        SqlText = "SELECT IC_ADIANTAMENTO  FROM SOF.TIPO_CONTRATO_PAF " & _
                   " WHERE CD_TIPO_CONTRATO_PAF = " & cboTipoContrato.SelectedValue

        If DBQuery_ValorUnico(SqlText) = "N" Then
            Limpa_adiantamento()
            txtDataFixacao.Enabled = True
            txtDataFixacao.DateTime = Now.AddMonths(cnt_Contrato_Master_TempoFixacao_Mes)
        Else
            txtValorAdiantamento.Enabled = True
            txtDataFixacao.Enabled = True
            chkCobraJuros.Enabled = True
            chkCobraJuros.Checked = True
            chkCobraJuros_CheckedChanged(Nothing, Nothing)
            cboContratoPAF.Enabled = True
            chkJurosAposCarencia.Checked = False
            chkJurosAposCarencia.Enabled = False
            txtDataFixacao.DateTime = Now.AddMonths(cnt_Contrato_Adto_TempoFixacao_Mes)
        End If
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Impressao_ContratoPAF(lblContrato.Text)
    End Sub
End Class