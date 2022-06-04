Public Class frmCadastroContato
    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim SqAtendimento As Integer = Nothing

    Private Sub frmCadastroContato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_CodigoNome.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        SqAtendimento = Filtro
        ControleEdicaoTelaLocal = ControleEdicaoTela

        ComboBox_Carregar_Filial(cboFilial, False)
        ComboBox_Carregar_Tipo_Contato(cboTipoContato, True)
        Limpa_Tela()
        CarregarDados(SqAtendimento)
    End Sub


    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
    Private Sub CarregarDados(ByVal iSQ_ATENDIMENTO As Integer)
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "select * from sof.atendimento where sq_atendimento=" & iSQ_ATENDIMENTO

        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            Pesq_CodigoNome.Codigo = oData.Rows(0).Item("cd_fornecedor")
            rctDescricao.Text = oData.Rows(0).Item("ds_atendimento")
            ComboBox_Possicionar(cboFilial, oData.Rows(0).Item("CD_FILIAL"))
            ComboBox_Possicionar(cboTipoContato, oData.Rows(0).Item("cd_tipo_atendimento"))
            txtAssunto.Text = oData.Rows(0).Item("ds_assunto")
            txtData.Value = oData.Rows(0).Item("dt_atendimento")
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim IcManutencao As String
        Dim sqNovoAtendimento As Integer

        If Pesq_CodigoNome.Codigo <= 0 Then
            Msg_Mensagem("favor selecionar um fornecedor valido.")
            Pesq_CodigoNome.Focus()
            Exit Sub
        End If

        If Not IsDate(txtData.Text) Then
            Msg_Mensagem("Data invalida.")
            txtData.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoContato) Then
            Msg_Mensagem("Favor selecionar um tipo de contato.")
            cboTipoContato.Focus()
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

        SqlText = DBMontar_SP("SOF.INCLUI_ATENDIMENTO", False, ":CDFORN", _
                                                                           ":CDTPATENDE", _
                                                                           ":DTATENDE", _
                                                                           ":NOUSER", _
                                                                           ":DSASSUNTO", _
                                                                           ":DSATENDE", _
                                                                           ":CDFILIAL", _
                                                                           ":MANUT", _
                                                                           ":COD")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDFORN", Pesq_CodigoNome.Codigo), _
                                   DBParametro_Montar("CDTPATENDE", cboTipoContato.SelectedValue), _
                                   DBParametro_Montar("DTATENDE", Date_to_Oracle(txtData.Text), OracleClient.OracleType.DateTime), _
                                   DBParametro_Montar("NOUSER", sAcesso_UsuarioLogado), _
                                   DBParametro_Montar("DSASSUNTO", txtAssunto.Text), _
                                   DBParametro_Montar("DSATENDE", rctDescricao.Text, OracleClient.OracleType.VarChar, , 4000), _
                                   DBParametro_Montar("CDFILIAL", cboFilial.SelectedValue), _
                                   DBParametro_Montar("MANUT", IcManutencao), _
                                   DBParametro_Montar("COD", SqAtendimento, , ParameterDirection.InputOutput)) Then GoTo Erro

        If DBTeveRetorno() Then
            sqNovoAtendimento = DBRetorno(1)
        End If

        Select Case ControleEdicaoTelaLocal
            Case eControleEdicaoTela.INCLUIR
                Msg_Mensagem("Contato numero: " & sqNovoAtendimento)
                Limpa_Tela()
                Pesq_CodigoNome.Focus()
            Case eControleEdicaoTela.ALTERAR
                Exit Sub
        End Select

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub Pesq_CodigoNome_AlterouRegistro() Handles Pesq_CodigoNome.AlterouRegistro
        Dim SqlText As String

        SqlText = "select  cd_filial_origem " & _
          "from sof.fornecedor " & _
          "where cd_fornecedor = " & Pesq_CodigoNome.Codigo

        ComboBox_Possicionar(cboFilial, DBQuery_ValorUnico(SqlText, FilialLogada))
    End Sub

    Private Sub Limpa_Tela()
        Pesq_CodigoNome.Codigo = 0
        txtAssunto.Text = ""
        rctDescricao.Text = ""
        ComboBox_Possicionar(cboTipoContato, -1)
        ComboBox_Possicionar(cboFilial, FilialLogada)
        txtData.Value = DataSistema()
    End Sub
End Class