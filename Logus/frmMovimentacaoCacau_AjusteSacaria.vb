Public Class frmMovimentacaoCacau_AjusteSacaria
    Public CD_ARMAZEM As Integer
    Public CD_PILHA As Integer
    Public SQ_MOVIMENTACAO As Integer
    Public CD_TIPO_SACARIA As Integer
    Public SQ_MOVIMENTACAO_PILHA_ARMAZEM As Integer
    Public SQ_MOVIMENTACAO_PILHA_ARMAZEM_SACARIA As Integer

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim SQ_MOV_PILHA_ARMAZEM_HISTORICO As Integer

        If Me.txtAjuste.Value = 0 Then
            Msg_Mensagem("O ajuste não pode ser igual a Zero")
            txtAjuste.Focus()
            Exit Sub
        End If
        If CLng(Me.lblSaldoFinal.Text) = 0 Then
            Msg_Mensagem("O saldo final não pode ser igual a Zero")
            txtAjuste.Focus()
            Exit Sub
        End If
        If Trim(txtJustificativa.Text) = "" Then
            Msg_Mensagem("Informe uma justifica do ajuste")
            txtJustificativa.Focus()
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
                                   DBParametro_Montar("QTVOLUME", 0), _
                                   DBParametro_Montar("SQESTOQUESILO", Nothing), _
                                   DBParametro_Montar("ICSAIDA", IIf(txtAjuste.Value > 0, "S", "N")), _
                                   DBParametro_Montar("SQTRANSF", Nothing), _
                                   DBParametro_Montar("SQITEMTRANSF", Nothing), _
                                   DBParametro_Montar("SQMOVPILHAARMAZEMHIST", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("CMLANCAMENTO", Trim(txtJustificativa.Text), OracleClient.OracleType.VarChar, , 4000)) Then GoTo Erro

        If DBTeveRetorno() Then
            SQ_MOV_PILHA_ARMAZEM_HISTORICO = DBRetorno(1)
        End If

        SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARM_HI_SAC", False, ":CDARMAZEM", _
                                                                           ":CDPILHAARMAZEM", _
                                                                           ":SQMOVIMENTACAO", _
                                                                           ":SQMOVPILHAARMAZEMHIST", _
                                                                           ":CDTIPOSACARIA", _
                                                                           ":QTSACOS", _
                                                                           ":CMLANCAMENTO")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", CD_ARMAZEM), _
                                   DBParametro_Montar("CDPILHAARMAZEM", CD_PILHA), _
                                   DBParametro_Montar("SQMOVIMENTACAO", SQ_MOVIMENTACAO), _
                                   DBParametro_Montar("SQMOVPILHAARMAZEMHIST", SQ_MOV_PILHA_ARMAZEM_HISTORICO), _
                                   DBParametro_Montar("CDTIPOSACARIA", CD_TIPO_SACARIA), _
                                   DBParametro_Montar("QTSACOS", Math.Abs(Val(Me.txtAjuste.Value))), _
                                    DBParametro_Montar("CMLANCAMENTO", Trim(txtJustificativa.Text), OracleClient.OracleType.VarChar, , 4000)) Then GoTo Erro


        SqlText = "update SOF.mov_pilha_armazem_sacaria " & _
                  "Set qt_sacos = qt_sacos - " & Me.txtAjuste.Value & " " & _
                  "where cd_armazem = " & CD_ARMAZEM & " and " & _
                  "cd_pilha_armazem = " & CD_PILHA & " and " & _
                  "sq_movimentacao = " & SQ_MOVIMENTACAO & " and " & _
                  "sq_movimentacao_pilha_armazem = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM & " AND " & _
                  "cd_tipo_sacaria = " & CD_TIPO_SACARIA & " AND " & _
                  "sq_mov_pilha_armazem_sacaria = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM_SACARIA
        If Not DBExecutar(SqlText) Then GoTo Erro

        SqlText = "delete from sof.tmp_processo where sq_movimentacao_ajuste = " & SQ_MOVIMENTACAO
        If Not DBExecutar(SqlText) Then GoTo Erro

        If Not DBExecutarTransacao() Then GoTo Erro

        Me.Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Public Sub Carregar()
        Dim oData As DataTable
        Dim SqlText As String
        SqlText = "SELECT mp.qt_volume, a.no_armazem, ts.no_tipo_sacaria, mps.cd_pilha_armazem, "
        SqlText = SqlText & "       mps.qt_sacos, m.nu_nf "
        SqlText = SqlText & "  FROM sof.mov_pilha_armazem_sacaria mps, "
        SqlText = SqlText & "       sof.movimentacao_pilha_armazem mp, "
        SqlText = SqlText & "       sof.movimentacao m, "
        SqlText = SqlText & "       sof.tipo_sacaria ts, "
        SqlText = SqlText & "       sof.armazem a "
        SqlText = SqlText & " WHERE mp.cd_armazem = mps.cd_armazem "
        SqlText = SqlText & "   AND mp.cd_pilha_armazem = mps.cd_pilha_armazem "
        SqlText = SqlText & "   AND mp.sq_movimentacao = mps.sq_movimentacao "
        SqlText = SqlText & "   AND mp.sq_movimentacao_pilha_armazem = mps.sq_movimentacao_pilha_armazem "
        SqlText = SqlText & "   AND m.sq_movimentacao = mp.sq_movimentacao "
        SqlText = SqlText & "   AND ts.cd_tipo_sacaria = mps.cd_tipo_sacaria "
        SqlText = SqlText & "   AND a.cd_armazem = mp.cd_armazem "
        SqlText = SqlText & "   AND mps.cd_armazem =  " & CD_ARMAZEM
        SqlText = SqlText & "   AND mps.cd_pilha_armazem =  " & CD_PILHA
        SqlText = SqlText & "   AND mps.sq_movimentacao =  " & SQ_MOVIMENTACAO
        SqlText = SqlText & "   AND mps.sq_movimentacao_pilha_armazem =  " & SQ_MOVIMENTACAO_PILHA_ARMAZEM
        SqlText = SqlText & "   AND mps.cd_tipo_sacaria =  " & CD_TIPO_SACARIA
        SqlText = SqlText & "   AND mps.sq_mov_pilha_armazem_sacaria =  " & SQ_MOVIMENTACAO_PILHA_ARMAZEM_SACARIA

        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            lblOrigem_Armazem.Text = "Não Encontrado"
            lblOrigem_Pilha.Text = "Não Encontrado"
            lblSaldo.Text = 0
            lblNF.Text = ""
            lblTipoSacaria.Text = "Não Encontrado"
            lblSacos.Text = 0
        Else
            lblOrigem_Armazem.Text = oData.Rows(0).Item("NO_ARMAZEM")
            lblOrigem_Pilha.Text = oData.Rows(0).Item("CD_PILHA_ARMAZEM")
            lblSaldo.Text = Format(oData.Rows(0).Item("qt_volume"), "#,##0")
            lblNF.Text = "" & oData.Rows(0).Item("nu_nf")
            lblTipoSacaria.Text = oData.Rows(0).Item("no_tipo_sacaria")
            lblSacos.Text = oData.Rows(0).Item("qt_sacos")
        End If
    End Sub

    Private Sub frmMovimentacaoCacau_AjusteSacaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtAjuste_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAjuste.ValueChanged
        lblSaldoFinal.Text = Format(CLng(lblSacos.Text) - Me.txtAjuste.Value, "#,##0")
    End Sub
End Class