Imports VB = Microsoft.VisualBasic

Public Class frmCadastroJornal
    Public Enum enTipoUtilizacaoTela
        eCriacaoJornal = 1
        eAlteracaoJornal = 2
        eVisualizacaoJornal = 3
    End Enum

    Public oTipoUtilizacaoTela As enTipoUtilizacaoTela
    Dim SQ_JORNAL As Integer = Nothing
    Dim CD_TIPOJORNAL As Integer

    Private Sub frmCadastroJornal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Filial(cboFilial, True)
        ComboBox_Possicionar(cboFilial, FilialLogada)

        CarregarDados(SQ_JORNAL)

        If SQ_JORNAL = 0 Then
            txtData.Value = CDate(DataSistema())
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim IcManutencao As String
        Dim SqlText As String

        If Not IsDate(txtData.Text) Then
            Msg_Mensagem("Data invalida.")
            txtData.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboFilial) Then
            Msg_Mensagem("Favor selecionar uma filial.")
            Exit Sub
        End If
        If txtAssunto.Text = "" Then
            Msg_Mensagem("Favor informar um assunto.")
            txtAssunto.Focus()
            Exit Sub
        End If
        If Trim(rctJornal.Texto) = "" Then
            Msg_Mensagem("Favor descrever o contato.")
            rctJornal.Focus()
            Exit Sub
        End If

        If oTipoUtilizacaoTela = enTipoUtilizacaoTela.eCriacaoJornal Then
            IcManutencao = "I"
        Else
            IcManutencao = "A"
        End If

        SqlText = DBMontar_SP("SOF.SP_INCLUI_JORNAL", False, ":DTATENDE", _
                                                             ":NOUSER", _
                                                             ":DSASSUNTO", _
                                                             ":DSATENDE", _
                                                             ":CDFILIAL", _
                                                             ":CDTIPOJORNAL", _
                                                             ":MANUT", _
                                                             ":COD")
        If Not DBExecutar(SqlText, DBParametro_Montar("DTATENDE", Date_to_Oracle(txtData.Text), DbType.Date), _
                                   DBParametro_Montar("NOUSER", sAcesso_UsuarioLogado), _
                                   DBParametro_Montar("DSASSUNTO", txtAssunto.Text, OracleClient.OracleType.VarChar, , 4000), _
                                   DBParametro_Montar("DSATENDE", VB.Left(rctJornal.Texto, 4000), OracleClient.OracleType.VarChar, , 4000), _
                                   DBParametro_Montar("CDFILIAL", cboFilial.SelectedValue), _
                                   DBParametro_Montar("CDTIPOJORNAL", CD_TIPOJORNAL), _
                                   DBParametro_Montar("MANUT", IcManutencao), _
                                   DBParametro_Montar("COD", SQ_JORNAL, , ParameterDirection.InputOutput)) Then GoTo Erro

        SqlText = DBMontar_Update("SOF.JORNAL", GerarArray("DS_JORNAL_FORMATADO", ":DS_JORNAL_FORMATADO"), _
                                                GerarArray("SQ_JORNAL", ":SQ_JORNAL"))
        If Not DBExecutar(SqlText, DBParametro_Montar("DS_JORNAL_FORMATADO", Replace(rctJornal.Texto_HTML, "&edsp;", ""), , , -1), _
                                   DBParametro_Montar("SQ_JORNAL", DBRetorno(1))) Then GoTo Erro

        If oTipoUtilizacaoTela = enTipoUtilizacaoTela.eCriacaoJornal Then
            Msg_Mensagem("Inclusão realizada com sucesso.")
        Else
            Msg_Mensagem("Alteração realizada com sucesso.")
        End If

        Me.Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Public Sub Carregar(ByVal TipoUtilizacaoTela As enTipoUtilizacaoTela, _
                     ByVal SQ_JORNAL As Integer, ByVal CD_TIPO_TELA As Integer)
        Edicao_Habilitar(True)

        SQ_JORNAL = SQ_JORNAL
        CD_TIPOJORNAL = CD_TIPO_TELA
        oTipoUtilizacaoTela = TipoUtilizacaoTela

        Select Case TipoUtilizacaoTela
            Case enTipoUtilizacaoTela.eAlteracaoJornal
                CarregarDados(SQ_JORNAL)
            Case enTipoUtilizacaoTela.eVisualizacaoJornal
                CarregarDados(SQ_JORNAL)
                Edicao_Habilitar(False)
        End Select
    End Sub

    Private Sub Edicao_Habilitar(ByVal bHabilitar As Boolean)
        txtAssunto.ReadOnly = Not (bHabilitar)
        cboFilial.Enabled = bHabilitar
        rctJornal.Leitura = Not (bHabilitar)
        cmdGravar.Visible = bHabilitar
        txtData.Enabled = bHabilitar
    End Sub

    Private Sub CarregarDados(ByVal iSQ_JORNAL As Integer)
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "select * from sof.JORNAL where sq_JORNAL=" & iSQ_JORNAL

        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            If objDataTable_CampoVazio(oData.Rows(0).Item("DS_JORNAL_FORMATADO")) Then
                rctJornal.Texto = oData.Rows(0).Item("DS_JORNAL")
            Else
                rctJornal.Texto_HTML = oData.Rows(0).Item("DS_JORNAL_FORMATADO")
            End If
            ComboBox_Possicionar(cboFilial, oData.Rows(0).Item("CD_FILIAL"))
            txtAssunto.Text = oData.Rows(0).Item("ds_assunto")
            txtData.Value = oData.Rows(0).Item("dt_JORNAL")
        End If
    End Sub

    Private Sub frmCadastroJornal_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        cmdFechar.Left = pnlRodape.Width - cmdFechar.Width - 5
    End Sub
End Class