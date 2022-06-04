Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaFrete
    Const cnt_GridGeral_Data As Integer = 0
    Const cnt_GridGeral_Fretista As Integer = 1
    Const cnt_GridGeral_ValorUnitario As Integer = 2
    Const cnt_GridGeral_Volume As Integer = 3
    Const cnt_GridGeral_Total As Integer = 4
    Const cnt_GridGeral_TipoFrete As Integer = 5
    Const cnt_GridGeral_Filial As Integer = 6
    Const cnt_GridGeral_Fornecedor As Integer = 7
    Const cnt_GridGeral_NF As Integer = 8
    Const cnt_GridGeral_PagoManual As Integer = 9
    Const cnt_GridGeral_Codigo As Integer = 10
    Const cnt_GridGeral_DataExclusao As Integer = 11
    Const cnt_GridGeral_UserExclusao As Integer = 12

    Const cnt_SEC_Tela As String = "Transacao_Frete"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmConsultaFrete_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_Close(Me)
    End Sub

    Private Sub frmConsultaFrete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PesquisaFretista_Formatar()
        ComboBox_Carregar_Tipo_Frete(cboTipoFrete, True)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True, , , , True)

        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Fretista", 170)
        objGrid_Coluna_Add(grdGeral, "Valor Unitario", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Volumes", 80)
        objGrid_Coluna_Add(grdGeral, "Total", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Tipo Frete", 120)
        objGrid_Coluna_Add(grdGeral, "Filial", 120)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 180)
        objGrid_Coluna_Add(grdGeral, "NF", 70)
        objGrid_Coluna_Add(grdGeral, "Pago Manual", 80)
        objGrid_Coluna_Add(grdGeral, "Código", 0)
        objGrid_Coluna_Add(grdGeral, "Dt. Exclusão", 90)
        objGrid_Coluna_Add(grdGeral, "User Exclusão", 90)

        Form_Carrega_Grid(Me)

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub PesquisaFretista_Formatar()
        With Pesq_Fretista
            .Codigo = 0
            .BancoDados_Tabela = "FRETISTA"
            .BancoDados_Campo_Codigo = "CD_FRETISTA"
            .BancoDados_Campo_Descricao = "NO_FRETISTA"
        End With
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT f.dt_frete, frt.no_fretista, f.vl_unitario, f.qt_volume, f.vl_total, "
        SqlText = SqlText & "       tf.no_tipo_frete, fil.no_filial, forn.no_razao_social, m.nu_nf, "
        SqlText = SqlText & "       NVL (f.ic_pago_manual, 'N') ic_pago_manual, f.sq_frete, f.dt_exclusao, f.no_user_exclusao "
        SqlText = SqlText & "  FROM sof.fornecedor forn, "
        SqlText = SqlText & "       sof.tipo_frete tf, "
        SqlText = SqlText & "       sof.filial fil, "
        SqlText = SqlText & "       sof.movimentacao m, "
        SqlText = SqlText & "       sof.fretista frt, "
        SqlText = SqlText & "       sof.frete f "
        SqlText = SqlText & " WHERE f.cd_fretista = frt.cd_fretista "
        SqlText = SqlText & "   AND f.cd_tipo_frete = tf.cd_tipo_frete "
        SqlText = SqlText & "   AND f.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "   AND f.sq_movimentacao = m.sq_movimentacao(+) "
        SqlText = SqlText & "   AND m.cd_fornecedor = forn.cd_fornecedor(+) "

        If Pesq_Fretista.Codigo > 0 Then
            SqlText = SqlText & " AND f.cd_fretista=" & Pesq_Fretista.Codigo
        End If

        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(F.DT_FRETE) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If

        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(F.DT_FRETE) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        If ComboBox_LinhaSelecionada(cboTipoFrete) Then
            SqlText = SqlText & " AND f.cd_tipo_frete=" & cboTipoFrete.SelectedValue
        End If

        Select Case optStatus.Value
            Case "P"
                SqlText = SqlText & " and f.sq_frete_pagamento is not null"
            Case "A"
                SqlText = SqlText & " and f.sq_frete_pagamento is null"
            Case "E"
                SqlText = SqlText & " and not f.dt_exclusao is null"
        End Select

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Data, _
                                                            cnt_GridGeral_Fretista, _
                                                            cnt_GridGeral_ValorUnitario, _
                                                            cnt_GridGeral_Volume, _
                                                            cnt_GridGeral_Total, _
                                                            cnt_GridGeral_TipoFrete, _
                                                            cnt_GridGeral_Filial, _
                                                            cnt_GridGeral_Fornecedor, _
                                                            cnt_GridGeral_NF, _
                                                            cnt_GridGeral_PagoManual, _
                                                            cnt_GridGeral_Codigo, _
                                                            cnt_GridGeral_DataExclusao, _
                                                            cnt_GridGeral_UserExclusao})

        Dim iCont As Integer

        For iCont = 0 To grdGeral.Rows.Count - 1
            If IsDate(objGrid_Valor(grdGeral, cnt_GridGeral_DataExclusao, iCont)) Then
                With grdGeral.Rows(iCont).Appearance
                    .ForeColor = Color.Red
                    .FontData.Bold = DefaultableBoolean.True
                End With
            End If
        Next
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "FRETE", "SQ_FRETE = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If IsDate(objGrid_Valor(grdGeral, cnt_GridGeral_DataExclusao)) Then
            Msg_Mensagem("REgistro já excluido.")
            Exit Sub
        End If

        SqlText = "SELECT SQ_FRETE_PAGAMENTO FROM SOF.FRETE WHERE SQ_FRETE= " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

        If DBQuery_ValorUnico(SqlText, 0) <> 0 Then
            Msg_Mensagem("Esse frete ja foi pago.")
            Exit Sub
        End If

        If Msg_Perguntar("Elimina o frete ?") = False Then Exit Sub

        SqlText = "SELECT SQ_MOVIMENTACAO FROM SOF.FRETE WHERE SQ_FRETE= " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

        If DBQuery_ValorUnico(SqlText, 0) <> 0 Then
            If Msg_Perguntar("Este frete é proviniente de uma movimentação de cacau. Continua a eliminação ?") = False Then Exit Sub
        End If

        If objGrid_Valor(grdGeral, cnt_GridGeral_Data) = DataSistema() Then
            If Not DBExecutar_Delete("SOF.FRETE", "SQ_FRETE", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo ERRO
        Else
            SqlText = "update sof.FRETE f "
            SqlText = SqlText & "set f.dt_exclusao= " & QuotedStr(Date_to_Oracle(DataSistema))
            SqlText = SqlText & " ,  f.no_user_exclusao =" & QuotedStr(sAcesso_UsuarioLogado)
            SqlText = SqlText & "where f.SQ_FRETE= " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

            If Not DBExecutar(SqlText) Then GoTo Erro
        End If
        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub frmConsultaFrete_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdNovo.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Form_Show(Me.MdiParent, frmCadastroFrete)
    End Sub

    Private Sub optStatus_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optStatus.ValueChanged

    End Sub
End Class