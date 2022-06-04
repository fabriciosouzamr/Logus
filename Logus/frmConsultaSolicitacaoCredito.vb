Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaSolicitacaoCredito
    Const cnt_GridGeral_Fornecedor As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_Tipo As Integer = 2
    Const cnt_GridGeral_Valor As Integer = 3
    Const cnt_GridGeral_Solicitante As Integer = 4
    Const cnt_GridGeral_Validade As Integer = 5
    Const cnt_GridGeral_Revisao As Integer = 6
    Const cnt_GridGeral_Status As Integer = 7
    Const cnt_GridGeral_TipoGarantia As Integer = 8
    Const cnt_GridGeral_ValorGarantia As Integer = 9
    Const cnt_GridGeral_ValidadeGarantia As Integer = 10
    Const cnt_GridGeral_Descricao As Integer = 11
    Const cnt_GridGeral_Codigo As Integer = 12
    Const cnt_GridGeral_CodigoStatus As Integer = 13

    Const cnt_SEC_Tela_Historico As String = "Transacao_SolicitacaoCredito_Historico"
    Const cnt_SEC_Tela As String = "Transacao_SolicitacaoCredito"
    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim WithEvents oFormCancelar As frmCadastroSolicitacaoCredito_Cancelamento

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmConsultaSolicitacaoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_CodigoNome.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        ComboBox_Carregar_Status_Credito(cboStatus, True)
        ComboBox_Carregar_Tipo_Garantia(cboTipoGarantia, True)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True, , , , True)

        objGrid_Coluna_Add(grdGeral, "Fornecedor", 180)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Tipo", 80)
        objGrid_Coluna_Add(grdGeral, "Valor", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Solicitante", 130)
        objGrid_Coluna_Add(grdGeral, "Validade", 80)
        objGrid_Coluna_Add(grdGeral, "Revisão", 80)
        objGrid_Coluna_Add(grdGeral, "Status", 80)
        objGrid_Coluna_Add(grdGeral, "Tipo Garantia", 150)
        objGrid_Coluna_Add(grdGeral, "Valor Garantia", 100)
        objGrid_Coluna_Add(grdGeral, "Validade Garantia", 100)
        objGrid_Coluna_Add(grdGeral, "Descrição", 300, , , , , , DefaultableBoolean.True)
        objGrid_Coluna_Add(grdGeral, "Codigo", 0)
        objGrid_Coluna_Add(grdGeral, "Codigo Status", 0)

        SEC_ValidarBotao(cmdHistorico, cnt_SEC_Tela_Historico, SEC_Validador.SEC_V_Consulta, True)
        SEC_ValidarBotao(cmdCancelar, cnt_SEC_Tela, SEC_Validador.SEC_V_Consulta, True)

    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        If Not Data_ValidarPeriodo("data de solicitação de crédito", txtDataInicial.Text, txtDataFinal.Text, False) Then Exit Sub


        If Not IsDate(txtDataInicial.Value) And _
            Not IsDate(txtDataFinal.Value) And _
            Pesq_CodigoNome.Codigo = 0 And _
            chkAprovacao.Checked = False And _
            Not ComboBox_LinhaSelecionada(cboStatus) And _
            Not ComboBox_LinhaSelecionada(cboTipoGarantia) Then
            Msg_Mensagem("É preciso informar pelo menos uma informação de filtro")
            Exit Sub
        End If

        SqlText = "SELECT f.no_razao_social, lc.dt_limite_credito, ps.no_status AS tipo, "
        SqlText = SqlText & "       lc.vl_credito, u.no_usuario, lc.dt_validade, lc.dt_revisao, "
        SqlText = SqlText & "       lcts.no_tipo_status, "
        SqlText = SqlText & "       DECODE (lc.ic_excecao, "
        SqlText = SqlText & "               'S', 'Exceção', "
        SqlText = SqlText & "               DECODE (lc.ic_pre_aprovado, "
        SqlText = SqlText & "                       'S', 'Limite Pre-Aprovado', "
        SqlText = SqlText & "                       tg.no_tipo_garantia "
        SqlText = SqlText & "                      ) "
        SqlText = SqlText & "              ) AS no_tipo_garantia, "
        SqlText = SqlText & "       decode (g.ic_moeda_garantia,1,'R$ ',2,'US$ ', 3, 'QT @ ','') || g.vl_garantia as vl_garantia, g.dt_garantia_validade, lc.ds_obs, "
        SqlText = SqlText & "       lc.sq_limite_credito, lc.cd_tipo_status "
        SqlText = SqlText & "  FROM sof.limite_credito lc, "
        SqlText = SqlText & "       sof.usuario u, "
        SqlText = SqlText & "       sof.limite_credito_tipo_status lcts, "
        SqlText = SqlText & "       sof.tipo_garantia tg, "
        SqlText = SqlText & "       sof.fornecedor f, "
        SqlText = SqlText & "       sof.filial fil, "
        SqlText = SqlText & "       sof.garantia g, "
        SqlText = SqlText & "       sof.processo_status ps "
        SqlText = SqlText & " WHERE lc.cd_tipo_status = lcts.cd_tipo_status "
        SqlText = SqlText & "   AND g.cd_tipo_garantia = tg.cd_tipo_garantia(+) "
        SqlText = SqlText & "   AND lc.no_user_criacao = u.cd_user "
        SqlText = SqlText & "   AND lc.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "   AND f.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "   AND lc.sq_garantia = g.sq_garantia(+) "
        SqlText = SqlText & "   AND ps.ic_status = lc.ic_moeda_credito "
        SqlText = SqlText & "   AND ps.cd_processo = " & enProcesso_Status.Moeda

        If Pesq_CodigoNome.Codigo > 0 Then
            SqlText = SqlText & " AND F.cd_fornecedor=" & Pesq_CodigoNome.Codigo
        End If

        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(lc.dt_limite_credito) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If

        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(lc.dt_limite_credito) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        If ComboBox_LinhaSelecionada(cboTipoGarantia) Then
            SqlText = SqlText & " AND g.cd_tipo_garantia=" & cboTipoGarantia.SelectedValue
        End If

        If ComboBox_LinhaSelecionada(cboStatus) Then
            SqlText = SqlText & " AND lc.cd_tipo_status=" & QuotedStr(cboStatus.SelectedValue)
        End If

        If chkAprovacao.checked = True Then
            SqlText = SqlText & " AND LC.CD_TIPO_STATUS in ('P', 'W')"
        End If

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Fornecedor, _
                                                            cnt_GridGeral_Data, _
                                                            cnt_GridGeral_Tipo, _
                                                            cnt_GridGeral_Valor, _
                                                            cnt_GridGeral_Solicitante, _
                                                            cnt_GridGeral_Validade, _
                                                            cnt_GridGeral_Revisao, _
                                                            cnt_GridGeral_Status, _
                                                            cnt_GridGeral_TipoGarantia, _
                                                            cnt_GridGeral_ValorGarantia, _
                                                            cnt_GridGeral_ValidadeGarantia, _
                                                            cnt_GridGeral_Descricao, _
                                                            cnt_GridGeral_Codigo, _
                                                            cnt_GridGeral_CodigoStatus})

        Dim iCont As Integer

        For iCont = 0 To grdGeral.Rows.Count - 1
            With grdGeral.Rows(iCont).Appearance
                Select Case grdGeral.Rows(iCont).Cells(cnt_GridGeral_CodigoStatus).Value
                    Case "A"
                        .ForeColor = Color.Green
                        .FontData.Bold = DefaultableBoolean.True
                    Case "I"
                        .ForeColor = Color.Gray
                        .FontData.Bold = DefaultableBoolean.True
                    Case "C"
                        .ForeColor = Color.Red
                        .FontData.Bold = DefaultableBoolean.True
                    Case "E"
                        .ForeColor = Color.Orange
                        .FontData.Bold = DefaultableBoolean.True
                End Select
            End With
        Next

        objGrid_ExibirTotal(grdGeral, New Integer() {cnt_GridGeral_Valor, cnt_GridGeral_ValorGarantia})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "limite_credito", "SQ_limite_credito = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))

    End Sub

    Private Sub frmConsultaSolicitacaoCredito_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdHistorico.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdCancelar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdAprovacao.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub

    Private Sub cmdAprovacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAprovacao.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Filtro = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
        Form_Carregar_Consulta_Geral(Me.MdiParent, frmConsultaGeral.eConsultaGeral.Aprovacoes_SolicitacaoCredito)
    End Sub

    Private Sub cmdHistorico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHistorico.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Filtro = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
        Form_Show(Me.MdiParent, frmHistoricoSolicitacaoCredito, True)
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        oFormCancelar = New frmCadastroSolicitacaoCredito_Cancelamento
        oFormCancelar.CdSolicitacaoCredito = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
        Form_Show(Me.MdiParent, oFormCancelar, True)
    End Sub

    Private Sub oFormCancelar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oFormCancelar.FormClosing
        ExecutaConsulta()
    End Sub
End Class