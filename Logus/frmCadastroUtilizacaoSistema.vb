Public Class frmCadastroUtilizacaoSistema
    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim CdRelatorio As Integer

    Private Sub frmCadastroUtilizacaoSistema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ControleEdicaoTelaLocal = ControleEdicaoTela
        CdRelatorio = Filtro

        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            optTipo.Value = Filtro1
            optTipo.Enabled = False
            CarregarDados()
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT *" & _
                  " FROM SOF.RELATORIO" & _
                  " WHERE CD_RELATORIO = " & CdRelatorio & _
                    " AND CD_TIPO = " & optTipo.Value
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            lblCodigo.Text = oData.Rows(0).Item("CD_RELATORIO")
            txtNome.Text = oData.Rows(0).Item("NO_RELATORIO")
            rctDescricao.Text = "" & oData.Rows(0).Item("DS_DESCRICAO")
            rctAprovadores.Text = "" & oData.Rows(0).Item("DS_RESPONSAVEIS")
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(4) As DBParamentro

        If txtNome.Text = "" Then
            Msg_Mensagem("Favor informar o nome.")
            txtNome.Focus()
            Exit Sub
        End If

        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            CdRelatorio = DBNumeroMaisUm("SOF.RELATORIO WHERE CD_TIPO = " & optTipo.Value, "CD_RELATORIO")

            SqlText = DBMontar_Insert("SOF.RELATORIO", TipoCampoFixo.Todos, "NO_RELATORIO", ":NO_RELATORIO", _
                                                                            "DS_DESCRICAO", ":DS_DESCRICAO", _
                                                                            "DS_RESPONSAVEIS", ":DS_RESPONSAVEIS", _
                                                                            "CD_RELATORIO", ":CD_RELATORIO", _
                                                                            "CD_TIPO", ":CD_TIPO")
        Else
            SqlText = DBMontar_Update("SOF.RELATORIO", GerarArray("NO_RELATORIO", ":NO_RELATORIO", _
                                                                  "DS_DESCRICAO", ":DS_DESCRICAO", _
                                                                  "DS_RESPONSAVEIS", ":DS_RESPONSAVEIS"), _
                                                       GerarArray("CD_RELATORIO", ":CD_RELATORIO", " AND ", _
                                                                  "CD_TIPO", ":CD_TIPO"))
        End If

        Parametro(0) = DBParametro_Montar("NO_RELATORIO", txtNome.Text)
        Parametro(1) = DBParametro_Montar("DS_DESCRICAO", rctDescricao.Text, OracleClient.OracleType.VarChar, , 1000)
        Parametro(2) = DBParametro_Montar("DS_RESPONSAVEIS", rctAprovadores.Text, OracleClient.OracleType.VarChar, , 200)
        Parametro(3) = DBParametro_Montar("CD_RELATORIO", CdRelatorio)
        Parametro(4) = DBParametro_Montar("CD_TIPO", optTipo.Value)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        Close()

        Exit Sub
Erro:
        TratarErro()
    End Sub
End Class