Public Class frmMovimentacaoCacau_AjusteEstoque
    Public CD_ARMAZEM As Integer
    Public CD_PILHA As Integer
    Public SQ_MOVIMENTACAO As Integer
    Public SQ_MOVIMENTACAO_PILHA_ARMAZEM As Integer
    
    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub txtAjuste_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAjuste.ValueChanged
        lblSaldoFinal.Text = Format(CLng(Me.lblSaldo.Text) - Me.txtAjuste.Value, "#,##0")
    End Sub

    Public Sub Carregar()
        Dim oData As DataTable
        Dim SqlText As String

        SqlText = "SELECT m.cd_pilha_armazem, m.qt_volume, a.no_armazem, mov.nu_nf "
        SqlText = SqlText & "  FROM sof.movimentacao_pilha_armazem m, sof.armazem a, sof.movimentacao mov "
        SqlText = SqlText & " WHERE m.cd_armazem = a.cd_armazem "
        SqlText = SqlText & "   AND m.sq_movimentacao = mov.sq_movimentacao "
        SqlText = SqlText & "   AND m.cd_armazem =  " & CD_ARMAZEM
        SqlText = SqlText & "   AND m.cd_pilha_armazem =  " & CD_PILHA
        SqlText = SqlText & "   AND m.sq_movimentacao =  " & SQ_MOVIMENTACAO
        SqlText = SqlText & "   AND m.sq_movimentacao_pilha_armazem = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM

        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            lblOrigem_Armazem.Text = "Não Encontrado"
            lblOrigem_Pilha.Text = "Não Encontrado"
            lblSaldo.Text = 0
            lblNF.Text = ""
        Else
            lblOrigem_Armazem.Text = oData.Rows(0).Item("NO_ARMAZEM")
            lblOrigem_Pilha.Text = oData.Rows(0).Item("CD_PILHA_ARMAZEM")
            lblSaldo.Text = Format(oData.Rows(0).Item("qt_volume"), "#,##0")
            lblNF.Text = "" & oData.Rows(0).Item("nu_nf")
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String

        If txtAjuste.Value = 0 Then
            Msg_Mensagem("O ajuste não pode ser igual a Zero")
            txtAjuste.Focus()
            Exit Sub
        End If
        If Trim(txtJustificativa.Text) = "" Then
            Msg_Mensagem("Informe uma justifica do ajuste")
            txtJustificativa.Focus()
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*)" & _
                  " FROM SOF.ARMAZEM_PILHA_LASTRO" & _
                  " WHERE CD_ARMAZEM =  " & CD_ARMAZEM & _
                    " AND CD_PILHA =  " & CD_PILHA & _
                    " AND NVL(CD_STATUS_FORMACAO, 0) = " & cnt_StatusFormacaoPilha_Sendodesmanchada
        If DBQuery_ValorUnico(SqlText, 0) > 0 Then
            Msg_Mensagem("Esse pilha está em processo de desmanche e por isso não poderá ser atualizada.")
            Exit Sub
        End If

        SqlText = "SELECT M.QT_VOLUME" & _
                  " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM M" & _
                  " WHERE M.CD_ARMAZEM =  " & CD_ARMAZEM & _
                    " AND M.CD_PILHA_ARMAZEM =  " & CD_PILHA & _
                    " AND M.SQ_MOVIMENTACAO =  " & SQ_MOVIMENTACAO & _
                    " AND M.SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM

        If DBQuery_ValorUnico(SqlText) <> CLng(Me.lblSaldo.Text) Then
            Msg_Mensagem("Favor fechar e tentar novamente pois o saldo da movimentação foi atualizado.")
            Exit Sub
        End If

        DBUsarTransacao = True

        SqlText = "INSERT INTO SOF.TMP_PROCESSO (SQ_MOVIMENTACAO_AJUSTE) VALUES (" & SQ_MOVIMENTACAO & ")"
        If Not DBExecutar(SqlText) Then GoTo Erro

        SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARM_HIST", False, ":CDARMAZEM", _
                                                                         ":CDPILHAARMAZEM", _
                                                                         ":SQMOVIMENTACAO", _
                                                                         ":DTTRANSACAO", _
                                                                         ":QTVOLUME", _
                                                                         ":SQESTOQUESILO", _
                                                                         ":ICSAIDA", _
                                                                         ":SQTRANSF", _
                                                                         ":SQITEMTRANSF", _
                                                                         ":SQMOVPILHAARMAZEMHIST", _
                                                                         ":CMLANCAMENTO")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", CD_ARMAZEM), _
                                   DBParametro_Montar("CDPILHAARMAZEM", CD_PILHA), _
                                   DBParametro_Montar("SQMOVIMENTACAO", SQ_MOVIMENTACAO), _
                                   DBParametro_Montar("DTTRANSACAO", Date_to_Oracle(DataSistema)), _
                                   DBParametro_Montar("QTVOLUME", Math.Abs(txtAjuste.Value)), _
                                   DBParametro_Montar("SQESTOQUESILO", Nothing), _
                                   DBParametro_Montar("ICSAIDA", IIf(txtAjuste.Value > 0, "S", "N")), _
                                   DBParametro_Montar("SQTRANSF", Nothing), _
                                   DBParametro_Montar("SQITEMTRANSF", Nothing), _
                                   DBParametro_Montar("SQMOVPILHAARMAZEMHIST", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("CMLANCAMENTO", Trim(txtJustificativa.Text), OracleClient.OracleType.VarChar, , 4000)) Then GoTo Erro

        If CLng(Me.lblSaldoFinal.Text) <> 0 Then
            SqlText = "UPDATE sof.movimentacao_pilha_armazem " & _
                  "SET QT_VOLUME = QT_VOLUME - (" & Me.txtAjuste.Value & ") " & _
                  "where cd_armazem = " & CD_ARMAZEM & " and " & _
                  "cd_pilha_armazem = " & CD_PILHA & " and " & _
                  "sq_movimentacao = " & SQ_MOVIMENTACAO & " and " & _
                  "sq_movimentacao_pilha_armazem = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM

            If Not DBExecutar(SqlText) Then GoTo Erro
        Else
            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ExcluirTodaMovimentacaoPilhaManualmente) Then
                Msg_Mensagem("Você não tem acesso para excluir totalmente a movimentação dessa pilha.")
                Exit Sub
            End If

            SqlText = "DELETE FROM SOF.mov_pilha_armazem_sacaria " & _
                      "WHERE cd_armazem = " & CD_ARMAZEM & " AND " & _
                      "cd_pilha_armazem = " & CD_PILHA & " AND " & _
                      "sq_movimentacao = " & SQ_MOVIMENTACAO & " AND " & _
                      "sq_movimentacao_pilha_armazem = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM

            If Not DBExecutar(SqlText) Then GoTo Erro

            SqlText = "DELETE FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM " & _
                      "WHERE cd_armazem = " & CD_ARMAZEM & " AND " & _
                      "cd_pilha_armazem = " & CD_PILHA & " AND " & _
                      "sq_movimentacao = " & SQ_MOVIMENTACAO & " AND " & _
                      "sq_movimentacao_pilha_armazem = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM

            If Not DBExecutar(SqlText) Then GoTo Erro
            End If

            SqlText = "update sof.movimentacao " & _
                      "set qt_kg_a_transferir = qt_kg_a_transferir - (" & Me.txtAjuste.Value & ") " & _
                      "where sq_movimentacao = " & SQ_MOVIMENTACAO
            If Not DBExecutar(SqlText) Then GoTo Erro

            SqlText = "delete from sof.tmp_processo where sq_movimentacao_ajuste = " & SQ_MOVIMENTACAO
            If Not DBExecutar(SqlText) Then GoTo Erro

            If Not DBExecutarTransacao() Then GoTo Erro

            Me.Close()

            Exit Sub
Erro:
            TratarErro()
    End Sub
End Class