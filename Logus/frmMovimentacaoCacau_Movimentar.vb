Public Class frmMovimentacaoCacau_Movimentar
    Public CD_ARMAZEM As Integer
    Public CD_PILHA As Integer
    Public SQ_MOVIMENTACAO As Integer
    Public SQ_MOVIMENTACAO_PILHA_ARMAZEM As Integer

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cboArmazem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboArmazem.SelectedIndexChanged
        cboPilha.DataSource = Nothing

        If Not ComboBox_LinhaSelecionada(cboArmazem) Then Exit Sub

        Dim SqlText As String

        SqlText = "SELECT CD_PILHA," & _
                         "TO_CHAR(CD_PILHA) NO_PILHA_ARMAZEM" & _
                  " FROM " & View_ARMAZEM_PILHA_LASTRO() & _
                  " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                    " AND CD_PILHA_MAE IS NULL" & _
                  " ORDER BY CD_PILHA_ARMAZEM"

        DBCarregarComboBox(cboPilha, SqlText, True)
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim oData As DataTable
        Dim iCont As Integer
        Dim SqMovPilhaArmazem As Long
        Dim SqMovPilhaArmazemHist As Long
        Dim SqlText As String
        Dim ProcedenciPilha As String
        Dim ProcedenciLote As String
        Dim QtdeMovimentacaoPilha As Integer

        If Not ComboBox_LinhaSelecionada(cboArmazem) Then
            Msg_Mensagem("Favor selecionar um armazem.")
            cboArmazem.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboPilha) Then
            Msg_Mensagem("Favor selecionar uma pilha.")
            cboPilha.Focus()
            Exit Sub
        End If
        If Me.txtVolume.Value <= 0 Then
            Msg_Mensagem("Favor informar um valor valido.")
            txtVolume.Focus()
            Exit Sub
        End If
        If Me.txtVolume.Value > CDbl(lblOrigem_Volume.Text) Then
            Msg_Mensagem("O volume não pode ser maior do que " & lblOrigem_Volume.Text)
            txtVolume.Focus()
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*)" & _
                  " FROM SOF.ARMAZEM_PILHA_LASTRO" & _
                  " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                    " AND CD_PILHA = " & cboPilha.SelectedValue & _
                    " AND NVL(CD_STATUS_FORMACAO, 0) = " & cnt_StatusFormacaoPilha_Sendodesmanchada
        If DBQuery_ValorUnico(SqlText, 0) > 1 Then
            Msg_Mensagem("Esse pilha está em processo de desmanche e por isso não poderá ser atualizada.")
            Exit Sub
        End If

        SqlText = "SELECT M.QT_VOLUME" & _
                  " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM M" & _
                  " WHERE M.CD_ARMAZEM =  " & CD_ARMAZEM & _
                    " AND M.CD_PILHA_ARMAZEM =  " & CD_PILHA & _
                    " AND M.SQ_MOVIMENTACAO =  " & SQ_MOVIMENTACAO & _
                    " AND M.SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM

        If DBQuery_ValorUnico(SqlText) <> CLng(lblOrigem_Volume.Text) Then
            Msg_Mensagem("Favor fechar e tentar novamente pois o saldo da movimentação foi atualizado.")
            Exit Sub
        End If

        SqlText = "SELECT CD_PROCEDENCIA FROM SOF.MOVIMENTACAO M WHERE M.SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO
        ProcedenciLote = DBQuery_ValorUnico(SqlText, "")

        SqlText = "SELECT CD_PROCEDENCIA" & _
                  " FROM SOF.PILHA_ARMAZEM" & _
                  " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                    " AND CD_PILHA_ARMAZEM = " & cboPilha.SelectedValue
        ProcedenciPilha = DBQuery_ValorUnico(SqlText, "")

        SqlText = "SELECT COUNT(*) FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM" & _
                  " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                    " AND CD_PILHA_ARMAZEM = " & cboPilha.SelectedValue
        QtdeMovimentacaoPilha = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT COUNT(*) QUANT" & _
                  " FROM SOF.ARMAZEM_PILHA_CONFIGURACAO" & _
                  " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                    " AND CD_PILHA = " & Me.cboPilha.Text & _
                    " AND CD_ITEM_CONFIGURACAO = 10" & _
                    " AND IC_ITEM_CONFIGURACAO = 'S'"

        If DBQuery_ValorUnico(SqlText, 0) = 0 Then
            If Trim(ProcedenciPilha) <> "" And QtdeMovimentacaoPilha > 0 Then
                If ProcedenciPilha <> ProcedenciLote Then
                    Msg_Mensagem("A procedencia da Pilha é " & ProcedenciPilha & " e da Movimentação é " & ProcedenciLote & _
                                 ". Não será possivel realizar a operação.")
                    Exit Sub
                End If
            End If
        End If

        On Error GoTo Erro

        DBUsarTransacao = True
        AVI_Carregar(Me)

        SqlText = "INSERT INTO SOF.TMP_PROCESSO (SQ_MOVIMENTACAO_AJUSTE) VALUES (" & SQ_MOVIMENTACAO & ")"
        If Not DBExecutar(SqlText) Then GoTo Erro

        SqlText = "SELECT * " & _
                  " FROM SOF.MOV_PILHA_ARMAZEM_SACARIA" & _
                  " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                    " AND CD_PILHA_ARMAZEM = " & CD_PILHA & _
                    " AND SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                    " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM
        oData = DBQuery(SqlText)

        SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARM_HIST", False, ":CDARMAZEM", _
                                                                         ":CDPILHAARMAZEM", _
                                                                         ":SQMOVIMENTACAO", _
                                                                         ":DTTRANSACAO", _
                                                                         ":QTVOLUME", _
                                                                         ":SQESTOQUESILO", _
                                                                         ":ICSAIDA", _
                                                                         ":SQTRANSF", _
                                                                         ":SQITEMTRANSF", _
                                                                         ":SQMOVPILHAARMAZEMHIST")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", CD_ARMAZEM), _
                                   DBParametro_Montar("CDPILHAARMAZEM", CD_PILHA), _
                                   DBParametro_Montar("SQMOVIMENTACAO", SQ_MOVIMENTACAO), _
                                   DBParametro_Montar("DTTRANSACAO", Date_to_Oracle(DataSistema)), _
                                   DBParametro_Montar("QTVOLUME", txtVolume.Value), _
                                   DBParametro_Montar("SQESTOQUESILO", Nothing), _
                                   DBParametro_Montar("ICSAIDA", "S"), _
                                   DBParametro_Montar("SQTRANSF", Nothing), _
                                   DBParametro_Montar("SQITEMTRANSF", Nothing), _
                                   DBParametro_Montar("SQMOVPILHAARMAZEMHIST", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        If DBTeveRetorno() Then
            SqMovPilhaArmazemHist = DBRetorno(1)
        End If

        For iCont = 0 To oData.Rows.Count - 1
            SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARM_HI_SAC", False, ":CDARMAZEM", _
                                                                               ":CDPILHAARMAZEM", _
                                                                               ":SQMOVIMENTACAO", _
                                                                               ":SQMOVPILHAARMAZEMHIST", _
                                                                               ":CDTIPOSACARIA", _
                                                                               ":QTSACOS")

            If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", CD_ARMAZEM), _
                                       DBParametro_Montar("CDPILHAARMAZEM", CD_PILHA), _
                                       DBParametro_Montar("SQMOVIMENTACAO", SQ_MOVIMENTACAO), _
                                       DBParametro_Montar("SQMOVPILHAARMAZEMHIST", SqMovPilhaArmazemHist), _
                                       DBParametro_Montar("CDTIPOSACARIA", oData.Rows(iCont).Item("CD_TIPO_SACARIA")), _
                                       DBParametro_Montar("QTSACOS", Math.Round(oData.Rows(iCont).Item("QT_SACOS") * _
                                                                                (txtVolume.Value / _
                                                                                 CDbl(lblOrigem_Volume.Text)), 0))) Then GoTo Erro
        Next

        SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARMAZEM", False, ":CDARMAZEM", _
                                                                        ":CDPILHAARMAZEM", _
                                                                        ":SQMOVIMENTACAO", _
                                                                        ":DTTRANSACAO", _
                                                                        ":QTVOLUME", _
                                                                        ":SQESTOQUESILO", _
                                                                        ":SQMOVPILHAARMAZEM", _
                                                                        ":SQMOVPILHAARMAZEMHIST")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", cboArmazem.SelectedValue), _
                                   DBParametro_Montar("CDPILHAARMAZEM", cboPilha.SelectedValue), _
                                   DBParametro_Montar("SQMOVIMENTACAO", SQ_MOVIMENTACAO), _
                                   DBParametro_Montar("DTTRANSACAO", Date_to_Oracle(DataSistema)), _
                                   DBParametro_Montar("QTVOLUME", txtVolume.Value), _
                                   DBParametro_Montar("SQESTOQUESILO", Nothing), _
                                   DBParametro_Montar("SQMOVPILHAARMAZEM", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQMOVPILHAARMAZEMHIST", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        If DBTeveRetorno() Then
            SqMovPilhaArmazem = DBRetorno(1)
            SqMovPilhaArmazemHist = DBRetorno(2)
        End If

        For iCont = 0 To oData.Rows.Count - 1
            SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARMA_SACA", False, ":CDARMAZEM", _
                                                                              ":CDPILHAARMAZEM", _
                                                                              ":SQMOVIMENTACAO", _
                                                                              ":SQMOVPILHAARMAZEM", _
                                                                              ":SQMOVPILHAARMAZEMHIST", _
                                                                              ":CDTIPOSACARIA", _
                                                                              ":QTSACOS")

            If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", cboArmazem.SelectedValue), _
                                       DBParametro_Montar("CDPILHAARMAZEM", cboPilha.SelectedValue), _
                                       DBParametro_Montar("SQMOVIMENTACAO", SQ_MOVIMENTACAO), _
                                       DBParametro_Montar("SQMOVPILHAARMAZEM", SqMovPilhaArmazem), _
                                       DBParametro_Montar("SQMOVPILHAARMAZEMHIST", SqMovPilhaArmazemHist), _
                                       DBParametro_Montar("CDTIPOSACARIA", oData.Rows(iCont).Item("CD_TIPO_SACARIA")), _
                                       DBParametro_Montar("QTSACOS", Math.Round(oData.Rows(iCont).Item("QT_SACOS") * _
                                                                                (txtVolume.Value / _
                                                                                 CDbl(lblOrigem_Volume.Text)), 0))) Then GoTo Erro
        Next

        If Me.txtVolume.Value = CDbl(lblOrigem_Volume.Text) Then
            SqlText = "DELETE FROM SOF.MOV_PILHA_ARMAZEM_SACARIA" & _
                      " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                        " AND CD_PILHA_ARMAZEM = " & CD_PILHA & _
                        " AND SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                        " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM
            If Not DBExecutar(SqlText) Then GoTo Erro

            SqlText = "DELETE FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM" & _
                      " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                        " AND CD_PILHA_ARMAZEM = " & CD_PILHA & _
                        " AND SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                        " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM
            If Not DBExecutar(SqlText) Then GoTo Erro
        Else
            SqlText = "UPDATE SOF.MOVIMENTACAO_PILHA_ARMAZEM" & _
                      " SET QT_VOLUME = QT_VOLUME - " & txtVolume.Value & _
                      " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                        " AND CD_PILHA_ARMAZEM = " & CD_PILHA & _
                        " AND SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                        " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM
            If Not DBExecutar(SqlText) Then GoTo Erro

            SqlText = "UPDATE SOF.MOV_PILHA_ARMAZEM_SACARIA" & _
                      " SET QT_SACOS = QT_SACOS - (QT_SACOS * " & (txtVolume.Value / CDbl(lblOrigem_Volume.Text)) & ")" & _
                      " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                        " AND CD_PILHA_ARMAZEM = " & CD_PILHA & _
                        " AND SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                        " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        SqlText = "DELETE FROM SOF.TMP_PROCESSO WHERE SQ_MOVIMENTACAO_AJUSTE = " & SQ_MOVIMENTACAO
        If Not DBExecutar(SqlText) Then GoTo Erro

        If Not DBExecutarTransacao() Then GoTo Erro

        AVI_Fechar(Me)

        Msg_Mensagem("Movimentação Efetuada")

        Close()

        Exit Sub

Erro:
        AVI_Fechar(Me)
        TratarErro()
    End Sub

    Public Sub Carregar()
        Dim oData As DataTable
        Dim SqlText As String

        SqlText = "SELECT M.CD_PILHA_ARMAZEM," & _
                         "M.QT_VOLUME," & _
                         "A.NO_ARMAZEM " & _
                  " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM M, " & _
                        "SOF.ARMAZEM A " & _
                  "WHERE M.CD_ARMAZEM = A.CD_ARMAZEM" & _
                   " AND M.CD_ARMAZEM = " & CD_ARMAZEM & _
                   " AND M.CD_PILHA_ARMAZEM = " & CD_PILHA & _
                   " AND M.SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                   " AND M.SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & SQ_MOVIMENTACAO_PILHA_ARMAZEM
        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            lblOrigem_Armazem.Text = "Não Encontrado"
            lblOrigem_Pilha.Text = "Não Encontrado"
            lblOrigem_Volume.Text = 0
        Else
            lblOrigem_Armazem.Text = oData.Rows(0).Item("NO_ARMAZEM")
            lblOrigem_Pilha.Text = oData.Rows(0).Item("CD_PILHA_ARMAZEM")
            lblOrigem_Volume.Text = Format(oData.Rows(0).Item("QT_VOLUME"), "#,##0")
        End If

        ComboBox_Carregar_Armazem(cboArmazem, , True)
    End Sub
End Class