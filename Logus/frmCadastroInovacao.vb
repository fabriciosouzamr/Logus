Public Class frmCadastroInovacao
    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim SqInovacao As Integer = Nothing

    Private Sub frmCadastroInovacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SqInovacao = Filtro
        ControleEdicaoTelaLocal = ControleEdicaoTela

        ComboBox_Carregar_Filial(cboFilial, False)
        ComboBox_Carregar_Tipo_Inovacao(cboTipoInovacao, True)
        Limpa_Tela()
        CarregarDados(SqInovacao)
        ComboBox_Possicionar(cboFilial, FilialLogada)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Limpa_Tela()
        txtAssunto.Text = ""
        rctDescricao.Text = ""
        ComboBox_Possicionar(cboTipoInovacao, -1)
        ComboBox_Possicionar(cboFilial, FilialLogada)
        txtData.Value = DataSistema()
    End Sub

    Private Sub CarregarDados(ByVal iSQ_INOVACAO As Integer)
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * FROM SOF.INOVACAO WHERE SQ_INOVACAO = " & iSQ_INOVACAO

        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            rctDescricao.Text = oData.Rows(0).Item("DS_INOVACAO")
            ComboBox_Possicionar(cboFilial, oData.Rows(0).Item("CD_FILIAL"))
            ComboBox_Possicionar(cboTipoInovacao, oData.Rows(0).Item("CD_TIPO_INOVACAO"))
            txtAssunto.Text = oData.Rows(0).Item("DS_ASSUNTO")
            txtData.Value = oData.Rows(0).Item("DT_INOVACAO")
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim IcManutencao As String
        Dim sqNovoInovacao As Integer

        If Not IsDate(txtData.Text) Then
            Msg_Mensagem("Data invalida.")
            txtData.Focus()
            Exit Sub
        End If
        If CDate(txtData.Text) < CDate(DataSistema()) Then
            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AlterarInovacaoDataAnteriorAtual) Then
                Msg_Mensagem("Não é permitido incluir inovações com data anterior a data atual.")
                Exit Sub
            End If
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoInovacao) Then
            Msg_Mensagem("Favor selecionar um tipo de contato.")
            cboTipoInovacao.Focus()
            Exit Sub
        End If
        If txtAssunto.Text = "" Then
            Msg_Mensagem("Favor informar um assunto.")
            txtAssunto.Focus()
            Exit Sub
        End If
        If rctDescricao.Text = "" Then
            Msg_Mensagem("Favor descrever o contato.")
            rctDescricao.Focus()
            Exit Sub
        End If

        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            IcManutencao = "I"
        Else
            IcManutencao = "A"
        End If

        SqlText = DBMontar_SP("SOF.SP_INCLUI_INOVACAO", False, ":CDTPINOVA", _
                                                               ":DTINOVA", _
                                                               ":NOUSER", _
                                                               ":DSASSUNTO", _
                                                               ":DSINOVA", _
                                                               ":CDFILIAL", _
                                                               ":MANUT", _
                                                               ":COD")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDTPINOVA", cboTipoInovacao.SelectedValue), _
                                   DBParametro_Montar("DTINOVA", Date_to_Oracle(txtData.Text), OracleClient.OracleType.DateTime), _
                                   DBParametro_Montar("NOUSER", sAcesso_UsuarioLogado), _
                                   DBParametro_Montar("DSASSUNTO", txtAssunto.Text), _
                                   DBParametro_Montar("DSINOVA", rctDescricao.Text, OracleClient.OracleType.VarChar, , 4000), _
                                   DBParametro_Montar("CDFILIAL", cboFilial.SelectedValue), _
                                   DBParametro_Montar("MANUT", IcManutencao), _
                                   DBParametro_Montar("COD", SqInovacao, , ParameterDirection.InputOutput)) Then GoTo Erro

        If DBTeveRetorno() Then
            sqNovoInovacao = DBRetorno(1)
        End If

        Select Case ControleEdicaoTelaLocal
            Case eControleEdicaoTela.INCLUIR
                Msg_Mensagem("Inovação número: " & sqNovoInovacao)
                Limpa_Tela()
                cboTipoInovacao.Focus()
            Case eControleEdicaoTela.ALTERAR
                Msg_Mensagem("Alteração Efetuada")
                Close()
        End Select

        Exit Sub

Erro:
        TratarErro()
    End Sub
End Class