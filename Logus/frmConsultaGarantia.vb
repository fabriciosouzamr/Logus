Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaGarantia
    Const cnt_GridGeral_Fornecedor As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_Status As Integer = 2
    Const cnt_GridGeral_TipoGarantia As Integer = 3
    Const cnt_GridGeral_Valor As Integer = 4
    Const cnt_GridGeral_ValorCreditoMax As Integer = 5
    Const cnt_GridGeral_Validade As Integer = 6
    Const cnt_GridGeral_Descricao As Integer = 7
    Const cnt_GridGeral_Codigo As Integer = 8
    Const cnt_GridGeral_CodigoStatus As Integer = 9

    Const cnt_SEC_Tela As String = "Transacao_Garantia"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub frmConsultaGarantia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_CodigoNome.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        ComboBox_Carregar_Status_Garantia(cboStatus, True)
        ComboBox_Carregar_Tipo_Garantia(cboTipoGarantia, True)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True, , , , True)

        objGrid_Coluna_Add(grdGeral, "Fornecedor", 180)
        objGrid_Coluna_Add(grdGeral, "Data", 80, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "Status", 80)
        objGrid_Coluna_Add(grdGeral, "Tipo Garantia", 150)
        objGrid_Coluna_Add(grdGeral, "Valor", 80)
        objGrid_Coluna_Add(grdGeral, "Credito Maximo", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Validade", 80)
        objGrid_Coluna_Add(grdGeral, "Descrição", 300, , , , , , DefaultableBoolean.True)
        objGrid_Coluna_Add(grdGeral, "Codigo", 0)
        objGrid_Coluna_Add(grdGeral, "Codigo Status", 0)

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdAlterar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao(cmdCancelar, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT  f.no_razao_social,g.dt_criacao,lcts.no_tipo_status,tg.no_tipo_garantia,  "
        SqlText = SqlText & "       decode (g.ic_moeda_garantia,1,'R$ ',2,'US$ ', 3, 'QT @ ','') || g.vl_garantia, g.VL_CREDITO_MAXIMO, g.dt_garantia_validade,  "
        SqlText = SqlText & "       g.ds_descricao,   "
        SqlText = SqlText & "         g.sq_garantia,g.cd_tipo_status "
        SqlText = SqlText & "  FROM sof.garantia g, sof.fornecedor f, sof.tipo_garantia tg,sof.limite_credito_tipo_status lcts "
        SqlText = SqlText & " WHERE g.cd_repassador = f.cd_fornecedor "
        SqlText = SqlText & "   AND g.cd_tipo_garantia = tg.cd_tipo_garantia and g.cd_tipo_status = lcts.cd_tipo_status"


        If Pesq_CodigoNome.Codigo > 0 Then
            SqlText = SqlText & " AND F.cd_fornecedor=" & Pesq_CodigoNome.Codigo
        End If

        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(g.dt_criacao) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If

        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(g.dt_criacao) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        If ComboBox_LinhaSelecionada(cboTipoGarantia) Then
            SqlText = SqlText & " AND g.cd_tipo_garantia=" & cboTipoGarantia.SelectedValue
        End If

        If ComboBox_LinhaSelecionada(cboStatus) Then
            SqlText = SqlText & " AND g.cd_tipo_status=" & QuotedStr(cboStatus.SelectedValue)
        End If

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Fornecedor, _
                                                            cnt_GridGeral_Data, _
                                                            cnt_GridGeral_Status, _
                                                            cnt_GridGeral_TipoGarantia, _
                                                            cnt_GridGeral_Valor, _
                                                            cnt_GridGeral_ValorCreditoMax, _
                                                            cnt_GridGeral_Validade, _
                                                            cnt_GridGeral_Descricao, _
                                                            cnt_GridGeral_Codigo, _
                                                            cnt_GridGeral_CodigoStatus}, , True)

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

    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "GARANTIA", "SQ_GARANTIA = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim sMens As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If objGrid_Valor(grdGeral, cnt_GridGeral_CodigoStatus) = cnt_LimiteCredito_Status_Cancelado Or _
           objGrid_Valor(grdGeral, cnt_GridGeral_CodigoStatus) = cnt_LimiteCredito_Status_Aprovado Or _
           objGrid_Valor(grdGeral, cnt_GridGeral_CodigoStatus) = cnt_LimiteCredito_Status_Reprovado Or _
           objGrid_Valor(grdGeral, cnt_GridGeral_CodigoStatus) = cnt_LimiteCredito_Status_Inativo Then
            Msg_Mensagem("Não é permitido excluir garantia com o status de " & objGrid_Valor(grdGeral, cnt_GridGeral_Status))
            Exit Sub
        End If

        If Not ValidacaoExclusao("LIMITE_CREDITO", "SQ_GARANTIA=" & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo), "Exitem solicitações de credito criados com essa garantia.") Then GoTo Erro

        sMens = "Deseja excluir"
        sMens = sMens & " a garantia?"

        If Msg_Perguntar(sMens) Then
            If Not DBExecutar_Delete("SOF.GARANTIA_FORNECEDOR", "SQ_GARANTIA", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo ERRO
            If Not DBExecutar_Delete("SOF.GARANTIA", "SQ_GARANTIA", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro
        End If

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If Not Msg_Perguntar("Deseja Cancelar as Garantia?") Then Exit Sub

        SqlText = "UPDATE SOF.GARANTIA" & _
                  " SET CD_TIPO_STATUS = 'C'" & _
                  " WHERE SQ_GARANTIA = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
        DBExecutar(SqlText)

        ExecutaConsulta()
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Form_Show(Me.MdiParent, frmCadastroGarantia)
    End Sub

    Private Sub frmConsultaGarantia_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdNovo.Top = Me.ClientSize.Height - cmdNovo.Height - 6
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdAlterar.Top = Me.ClientSize.Height - cmdAlterar.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdUsuario.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcluir.Height - 6
        cmdCancelar.Top = Me.ClientSize.Height - cmdCancelar.Height - 6
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Selecione um registro")
            Exit Sub
        End If
        If objGrid_Valor(grdGeral, cnt_GridGeral_CodigoStatus) = "C" Then
            Msg_Mensagem("Garantia cancelada")
            Exit Sub
        End If

        Dim oForm As New frmCadastroGarantia

        oForm.SQ_GARANTIA = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

        Form_Show(Me.MdiParent, oForm)
    End Sub
End Class