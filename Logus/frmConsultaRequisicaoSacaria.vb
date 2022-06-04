Imports Infragistics.Win

Public Class frmConsultaRequisicaoSacaria
    Const cnt_GridGeral_SQ_SACARIA_REQUISICAO As Integer = 0
    Const cnt_GridGeral_NO_RAZAO_SOCIAL As Integer = 1
    Const cnt_GridGeral_NO_STATUS As Integer = 2
    Const cnt_GridGeral_IC_ENTRADA_SAIDA As Integer = 3
    Const cnt_GridGeral_DT_REQUISICAO As Integer = 4
    Const cnt_GridGeral_QT_SACOS As Integer = 5
    Const cnt_GridGeral_NO_TIPO_SACARIA As Integer = 6
    Const cnt_GridGeral_QT_SACOS_ITEM As Integer = 7
    Const cnt_GridGeral_NO_TOMADOR As Integer = 8
    Const cnt_GridGeral_DT_ENTREGA As Integer = 9
    Const cnt_GridGeral_NO_USUARIO_SOLICITACAO As Integer = 10
    Const cnt_GridGeral_NO_USUARIO_ENTREGA As Integer = 11
    Const cnt_GridGeral_CD_STATUS As Integer = 12

    Enum enStatusRequisicao
        Cancelada = 1
        Aguardando_Entrega = 2
        Entregue = 3
    End Enum

    Const cnt_SEC_Tela As String = "Transacao_Sacaria_RequisicaoSacaria"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmConsultaRequisicaoSacaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        objGrid_Inicializar(grdGeral, , oDS, , , , True, , , , True)
        objGrid_Coluna_Add(grdGeral, "Número", 60)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 190)
        objGrid_Coluna_Add(grdGeral, "Status", 140)
        objGrid_Coluna_Add(grdGeral, "Tipo", 120)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Sacos", 80, , , , , cnt_Formato_NumeroInteiro)
        objGrid_Coluna_Add(grdGeral, "Tipo Sacaria", 120)
        objGrid_Coluna_Add(grdGeral, "Quantidade", 90, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Representante", 170)
        objGrid_Coluna_Add(grdGeral, "Dt Entrega", 100)
        objGrid_Coluna_Add(grdGeral, "Solicitado Por", 170)
        objGrid_Coluna_Add(grdGeral, "Entregue Por", 170)
        objGrid_Coluna_Add(grdGeral, "CD_STATUS", 0)

        ComboBox_Carregar_Tipo_Sacaria(cboTipoSacaria, True, True)
        ComboBox_Carregar_Processo_Tipo(cboStatus, cnt_Processo_RequisicaoSacaria, True)

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao_Permissao(cmdDevolucao, SEC_Permissao.SEC_P_Acesso_RecepcionarDevolucaoSacariaFornecedor, True)
        SEC_ValidarBotao_Permissao(cmdEntregar, SEC_Permissao.SEC_P_Acesso_EntregarSacariaRequisitadaFornecedor, True)

        If (Not SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao)) Then
            ComboBox_Possicionar(cboStatus, enProcesso_Status.ReqSaca_AguardandoEntrega)
            Pesquisar()
        End If
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim SqlText As String

        On Error GoTo Erro

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then Exit Sub

        If (Not SEC_ValidarAcessoInterno(cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao)) And objGrid_Valor(grdGeral, cnt_GridGeral_CD_STATUS) <> enProcesso_Status.ReqSaca_AguardandoEntrega Then
            Msg_Mensagem("Só é permitido excluir requisições em aberto.")
            Exit Sub
        End If

        If objGrid_Valor(grdGeral, cnt_GridGeral_CD_STATUS) = enProcesso_Status.ReqSaca_Entregue Then
            'SÓ EXCLUI FISICAMENTE SE FOR ADMINISTRADOR
            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_CancelarRequisicaoSacariaStatusEntregue) Then
                Msg_Mensagem("Esta requisição já foi entrege. Não pode ser cancelada.")
                Exit Sub
            Else
                Dim oData As DataTable
                Dim QtdeItem As Integer
                Dim iCont As Integer

                SqlText = "SELECT COUNT(*) FROM SOF.SACARIA_REQUISICAO_ITEM SRI" & _
                          " WHERE SRI.SQ_SACARIA_REQUISICAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_SACARIA_REQUISICAO)
                QtdeItem = DBQuery_ValorUnico(SqlText)

                SqlText = "SELECT SF.SQ_SACARIA_FORNECEDOR" & _
                          " FROM SOF.SACARIA_REQUISICAO_ITEM SRI," & _
                                "SOF.SACARIA_FORNECEDOR SF," & _
                                "SOF.SACARIA_REQUISICAO SR" & _
                          " WHERE SF.NU_DOCUMENTO = TO_CHAR(SRI.SQ_SACARIA_REQUISICAO)" & _
                            " AND SR.SQ_SACARIA_REQUISICAO =SRI.SQ_SACARIA_REQUISICAO" & _
                            " AND SR.CD_FORNECEDOR =SF.CD_FORNECEDOR" & _
                            " AND SF.CD_TIPO_SACARIA =SRI.CD_TIPO_SACARIA" & _
                            " AND SRI.SQ_SACARIA_REQUISICAO =  " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_SACARIA_REQUISICAO)
                oData = DBQuery(SqlText)

                If oData.Rows.Count = QtdeItem And oData.Rows.Count <> 0 Then
                    For iCont = 0 To oData.Rows.Count - 1
                        SqlText = "DELETE FROM SOF.SACARIA_FILIAL SF" & _
                                  " WHERE SF.SQ_SACARIA_FORNECEDOR = " & oData.Rows(iCont).Item("SQ_SACARIA_FORNECEDOR")
                        If Not DBExecutar(SqlText) Then GoTo Erro

                        SqlText = "DELETE FROM SOF.SACARIA_FORNECEDOR SF" & _
                                  " WHERE SF.SQ_SACARIA_FORNECEDOR = " & oData.Rows(iCont).Item("SQ_SACARIA_FORNECEDOR")
                        If Not DBExecutar(SqlText) Then GoTo Erro
                    Next

                    SqlText = "DELETE FROM SOF.SACARIA_REQUISICAO_ITEM SI" & _
                              " WHERE SI.SQ_SACARIA_REQUISICAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_SACARIA_REQUISICAO)
                    If Not DBExecutar(SqlText) Then GoTo Erro

                    SqlText = "DELETE FROM SOF.SACARIA_REQUISICAO SI" & _
                              " WHERE SI.SQ_SACARIA_REQUISICAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_SACARIA_REQUISICAO)
                    If Not DBExecutar(SqlText) Then GoTo Erro
                Else
                    Msg_Mensagem("Não foi possivel fazer a exclusão.")
                    Exit Sub
                End If
            End If
        Else
            If objGrid_Valor(grdGeral, cnt_GridGeral_CD_STATUS) = enProcesso_Status.ReqSaca_Cancelado Then
                Msg_Mensagem("Esta requisição já foi Cancelada.")
                Exit Sub
            End If

            If Not Msg_Perguntar("Cancela a Requisição?") Then Exit Sub

            SqlText = "UPDATE SOF.SACARIA_REQUISICAO" & _
                      " SET NO_USER_ALTERACAO = " & QuotedStr(sAcesso_UsuarioLogado) & "," & _
                           "DT_ALTERACAO = SYSDATE," & _
                           "CD_STATUS = " & enProcesso_Status.ReqSaca_Cancelado & _
                      " WHERE SQ_SACARIA_REQUISICAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_SACARIA_REQUISICAO)
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        Pesquisar()

        Msg_Mensagem("Exclusão feita com sucesso.")

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdDevolucao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDevolucao.Click
        Dim oForm As New frmRequisicaoSacaria

        oForm.Carregar(frmRequisicaoSacaria.TipoAcao.TA_Devolucao, 0)
        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            Pesquisar()
        End If

        oForm.Dispose()
        oForm = Nothing
    End Sub

    Private Sub cmdEntregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEntregar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Selecione um registro")
            Exit Sub
        End If
        If objGrid_Valor(grdGeral, cnt_GridGeral_CD_STATUS) = enProcesso_Status.ReqSaca_Entregue Then
            Msg_Mensagem("Esta requisição já foi entrege.")
            Exit Sub
        End If
        If objGrid_Valor(grdGeral, cnt_GridGeral_CD_STATUS) = enProcesso_Status.ReqSaca_Cancelado Then
            Msg_Mensagem("Esta requisição foi Cancelada. Não poderá ser entregue.")
            Exit Sub
        End If

        Dim oForm As New frmRequisicaoSacaria

        oForm.Carregar(frmRequisicaoSacaria.TipoAcao.TA_EntregaSacaria, _
                       objGrid_Valor(grdGeral, cnt_GridGeral_SQ_SACARIA_REQUISICAO))
        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            Pesquisar()
        End If

        oForm.Dispose()
        oForm = Nothing
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Selecione um registro")
            Exit Sub
        End If
        If objGrid_Valor(grdGeral, cnt_GridGeral_CD_STATUS) = enProcesso_Status.ReqSaca_Entregue And _
           Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ImprimirRequisicaoSacariaEntregue) Then
            Msg_Mensagem("Esta requisição já foi entrege.")
            Exit Sub
        ElseIf objGrid_Valor(grdGeral, cnt_GridGeral_CD_STATUS) = enProcesso_Status.ReqSaca_Cancelado Then
            Msg_Mensagem("Esta requisição já foi cancelado.")
            Exit Sub
        End If

        Dim oRelatorio As New frmRelatorioGeral

        oRelatorio.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eSacariaRequisicao
        oRelatorio.Filtro01 = objGrid_Valor(grdGeral, cnt_GridGeral_SQ_SACARIA_REQUISICAO)
        Form_Show(Nothing, oRelatorio)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Dim oForm As New frmRequisicaoSacaria

        oForm.Carregar(frmRequisicaoSacaria.TipoAcao.TA_Requisicao, 0)
        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            Pesquisar()
        End If

        oForm.Dispose()
        oForm = Nothing
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "SACARIA_REQUISICAO", "SQ_SACARIA_REQUISICAO = " & _
                                                             objGrid_Valor(grdGeral, cnt_GridGeral_SQ_SACARIA_REQUISICAO))
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        Pesquisar()
    End Sub

    Private Sub Pesquisar()
        Dim SqlText As String

        SqlText = "SELECT SR.SQ_SACARIA_REQUISICAO," & _
                         "FN.NO_RAZAO_SOCIAL," & _
                         "PS.NO_STATUS," & _
                         "decode(SR.IC_ENTRADA_SAIDA,'S','Requisição','Devolução')," & _
                         "SR.DT_REQUISICAO," & _
                         "SR.QT_SACOS," & _
                         "TS.NO_TIPO_SACARIA," & _
                         "SRI.QT_SACOS AS QT_SACOS_ITEM," & _
                         "SR.NO_TOMADOR," & _
                         "SR.DT_ENTREGA," & _
                         "US.NO_USUARIO NO_USUARIO_SOLICITACAO," & _
                         "UE.NO_USUARIO NO_USUARIO_ENTREGA," & _
                         "PS.CD_STATUS" & _
                  " FROM SOF.SACARIA_REQUISICAO SR," & _
                        "SOF.SACARIA_REQUISICAO_ITEM SRI," & _
                        "SOF.TIPO_SACARIA TS," & _
                        "SOF.FORNECEDOR FN," & _
                        "SOF.PROCESSO_STATUS PS," & _
                        "SOF.USUARIO US," & _
                        "SOF.USUARIO UE" & _
                  " WHERE FN.CD_FORNECEDOR = SR.CD_FORNECEDOR" & _
                    " AND PS.CD_STATUS = SR.CD_STATUS" & _
                    " AND PS.CD_PROCESSO = " & cnt_Processo_RequisicaoSacaria & _
                    " AND SRI.SQ_SACARIA_REQUISICAO (+) = SR.SQ_SACARIA_REQUISICAO" & _
                    " AND TS.CD_TIPO_SACARIA (+) = SRI.CD_TIPO_SACARIA" & _
                    " AND US.CD_USER (+) = SR.CD_USUARIO_SOLICITACAO" & _
                    " AND UE.CD_USER (+) = SR.CD_USUARIO_ENTREGA"

        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND FN.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_VisualizarRequisicaoSacariaOutraFilial) Then
                SqlText = SqlText & " AND FN.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If
        End If
        If ComboBox_LinhaSelecionada(cboTipoSacaria) Then
            SqlText = SqlText & " AND TS.CD_TIPO_SACARIA = " & cboTipoSacaria.SelectedValue
        End If
        If Pesq_Fornecedor.Codigo > 0 Then
            SqlText = SqlText & " AND FN.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
        End If
        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND SR.DT_REQUISICAO >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND SR.DT_REQUISICAO <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If
        If ComboBox_LinhaSelecionada(cboStatus) Then
            SqlText = SqlText & " AND PS.CD_STATUS = " & cboStatus.SelectedValue
        End If

        SqlText = SqlText & _
                  " ORDER BY SR.SQ_SACARIA_REQUISICAO DESC"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_SQ_SACARIA_REQUISICAO, cnt_GridGeral_NO_RAZAO_SOCIAL, _
                                                           cnt_GridGeral_NO_STATUS, cnt_GridGeral_IC_ENTRADA_SAIDA, _
                                                           cnt_GridGeral_DT_REQUISICAO, cnt_GridGeral_QT_SACOS, _
                                                           cnt_GridGeral_NO_TIPO_SACARIA, cnt_GridGeral_QT_SACOS_ITEM, _
                                                           cnt_GridGeral_NO_TOMADOR, cnt_GridGeral_DT_ENTREGA, _
                                                           cnt_GridGeral_NO_USUARIO_SOLICITACAO, cnt_GridGeral_NO_USUARIO_ENTREGA, _
                                                           cnt_GridGeral_CD_STATUS})

        GridIdentificar()
    End Sub

    Private Sub GridIdentificar()
        Dim iCont As Integer

        For iCont = 0 To grdGeral.Rows.Count - 1
            Select Case objGrid_Valor(grdGeral, cnt_GridGeral_CD_STATUS, iCont)
                Case enProcesso_Status.ReqSaca_Cancelado
                    With grdGeral.Rows(iCont).Appearance
                        .ForeColor = Color.White
                        .BackColor = Color.Red
                        .FontData.Bold = DefaultableBoolean.False
                    End With
                Case enProcesso_Status.ReqSaca_AguardandoEntrega
                    With grdGeral.Rows(iCont).Appearance
                        .ForeColor = Color.Black
                        .BackColor = Color.White
                        .FontData.Bold = DefaultableBoolean.True
                    End With
                Case enProcesso_Status.ReqSaca_Entregue
                    With grdGeral.Rows(iCont).Appearance
                        .ForeColor = Color.Black
                        .BackColor = Color.PaleTurquoise
                        .FontData.Bold = DefaultableBoolean.True
                    End With
            End Select
        Next
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub frmConsultaRequisicaoSacaria_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdEntregar.Top = Me.ClientSize.Height - cmdEntregar.Height - 6
        cmdDevolucao.Top = Me.ClientSize.Height - cmdDevolucao.Height - 6
        cmdNovo.Top = Me.ClientSize.Height - cmdNovo.Height - 6
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdImprimir.Top = Me.ClientSize.Height - cmdImprimir.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdUsuario.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcluir.Height - 6
    End Sub
End Class