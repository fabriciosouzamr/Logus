Imports Infragistics.Win

Public Class frmConsultaAjuste_RDE
    Dim WithEvents oFormCadastroAjuste_RDE As frmCadastroAjuste_RDE

    Const cnt_Tela As String = "Transacao_ResumoDiarioEstoque_LancamentoAjuste"

    Const cnt_GridGeral_SQ_ACERTO As Integer = 0
    Const cnt_GridGeral_TipoAcerto As Integer = 1
    Const cnt_GridGeral_TipoMovimentacao As Integer = 2
    Const cnt_GridGeral_FilialOrigem As Integer = 3
    Const cnt_GridGeral_Fornecedor As Integer = 4
    Const cnt_GridGeral_DataAjuste As Integer = 5
    Const cnt_GridGeral_DataMovimento As Integer = 6
    Const cnt_GridGeral_Quantidade As Integer = 7
    Const cnt_GridGeral_Valor As Integer = 8
    Const cnt_GridGeral_ValorICMS As Integer = 9
    Const cnt_GridGeral_ValorINSS As Integer = 10
    Const cnt_GridGeral_Aprovador As Integer = 11
    Const cnt_GridGeral_Aprovado As Integer = 12
    Const cnt_GridGeral_DataAprovacao As Integer = 13
    Const cnt_GridGeral_TipoSacaria As Integer = 14
    Const cnt_GridGeral_TipoQualidade As Integer = 15

    Dim oDS As New Infragistics.Win.UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        Auditoria(TipoCampoFixo.Todos, "RESUMO_DIARIO_ESTOQUE_ACERTO", "SQ_ACERTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_ACERTO))
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Form_Show(Me.MdiParent, frmCadastroAjuste_RDE)
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If Not CampoNulo(objGrid_Valor(grdGeral, cnt_GridGeral_Aprovado)) Then
            Msg_Mensagem("Não é possível excluir um ajuste aprovado/reprovado")
            Exit Sub
        End If

        Dim SqlText As String

        SqlText = "DELETE FROM SOF.RESUMO_DIARIO_ESTOQUE_ACERTO WHERE SQ_ACERTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_ACERTO)
        If Not DBExecutar(SqlText) Then GoTo Erro

        Pesquisar()

        Msg_Mensagem("Exclusão Efetuada")

        Exit Sub

Erro:
        TratarErro(, , "frmConsultaAjuste_RDE.cmdExcluir_Click")
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If Not CampoNulo(objGrid_Valor(grdGeral, cnt_GridGeral_Aprovado)) Then
            Msg_Mensagem("Não é possível alterar um ajuste aprovado/reprovado")
            Exit Sub
        End If

        oFormCadastroAjuste_RDE = New frmCadastroAjuste_RDE
        oFormCadastroAjuste_RDE.AjusteRDE_AcaoTela = frmCadastroAjuste_RDE.enAjusteRDE_AcaoTela.Alteracao
        oFormCadastroAjuste_RDE.SQ_ACERTO = objGrid_Valor(grdGeral, cnt_GridGeral_SQ_ACERTO)

        Form_Show(Me.MdiParent, oFormCadastroAjuste_RDE)
    End Sub

    Private Sub oFormCadastroAjuste_RDE_EfetuouGravacao() Handles oFormCadastroAjuste_RDE.EfetuouGravacao
        Pesquisar()
    End Sub

    Private Sub Pesquisar()
        Dim SqlText As String

        SqlText = "SELECT AC.SQ_ACERTO," & _
                         "TA.NO_STATUS NO_TIPO_ACERTO," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "FI.NO_FILIAL NO_FILIAL_ORIGEM," & _
                         "FN.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "AC.DT_AJUSTE," & _
                         "AC.DT_MOVIMENTO," & _
                         "AC.QT_AJUSTE," & _
                         "AC.VL_AJUSTE," & _
                         "AC.VL_AJUSTE_ICMS," & _
                         "AC.VL_AJUSTE_INSS," & _
                         "UA.NO_USUARIO NO_USUARIO_APROVACAO," & _
                         "NVL2(AC.IC_APROVADO, DECODE(AC.IC_APROVADO, 'S', 'Sim', 'Não'), NULL) IC_APROVADO," & _
                         "AC.DT_APROVACAO," & _
                         "TS.NO_TIPO_SACARIA," & _
                         "TQ.NO_TIPO_QUALIDADE" & _
                  " FROM SOF.RESUMO_DIARIO_ESTOQUE_ACERTO AC," & _
                        "SOF.PROCESSO_STATUS TA," & _
                        "SOF.FILIAL FI," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.FORNECEDOR FN," & _
                        "SOF.TIPO_SACARIA TS," & _
                        "SOF.TIPO_QUALIDADE TQ," & _
                        "AGC.SEC_USUARIO UA" & _
                  " WHERE TA.CD_STATUS = AC.CD_TIPO_ACERTO" & _
                    " AND TA.CD_PROCESSO = " & cnt_Processo_TipoAjusteRD & _
                    " AND FI.CD_FILIAL = AC.CD_FILIAL_ORIGEM" & _
                    " AND TM.CD_TIPO_MOVIMENTACAO = AC.CD_TIPO_MOVIMENTACAO" & _
                    " AND FN.CD_FORNECEDOR (+) = AC.CD_FORNECEDOR" & _
                    " AND TS.CD_TIPO_SACARIA (+) = AC.CD_TIPO_SACARIA" & _
                    " AND TQ.CD_TIPO_QUALIDADE (+) = AC.CD_TIPO_QUALIDADE" & _
                    " AND UA.CD_USUARIO (+) = AC.CD_USUARIO_APROVACAO"

        If IsDate(txtDataInicial.Text) Then
            Str_Adicionar(SqlText, IIf(optDataSolicitacao.Checked, "TRUNC(AC.DT_AJUSTE)", "TRUNC(AC.DT_MOVIMENTO)") & " >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)), " AND ")
        End If
        If IsDate(txtDataFinal.Text) Then
            Str_Adicionar(SqlText, IIf(optDataSolicitacao.Checked, "TRUNC(AC.DT_AJUSTE)", "TRUNC(AC.DT_MOVIMENTO)") & " <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)), " AND ")
        End If
        If Pesq_UsuarioSolicitacao.Codigo <> "" Then
            Str_Adicionar(SqlText, "AC.NO_USER_CRIACAO = " & QuotedStr(Pesq_UsuarioSolicitacao.Codigo), " AND ")
        End If
        If Pesq_UsuarioAprovacao.Codigo <> "" Then
            Str_Adicionar(SqlText, "AC.CD_USUARIO_APROVACAO = " & QuotedStr(Pesq_UsuarioAprovacao.Codigo), " AND ")
        End If
        If ComboBox_LinhaSelecionada(cboFilial) Then
            Str_Adicionar(SqlText, "AC.CD_FILIAL_ORIGEM = " & cboFilial.SelectedValue, " AND ")
        End If
        If ComboBox_LinhaSelecionada(cboFilial) Then
            Str_Adicionar(SqlText, "AC.CD_TIPO_ACERTO = " & cboTipoAcerto.SelectedValue, " AND ")
        End If

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_SQ_ACERTO, _
                                                           cnt_GridGeral_TipoAcerto, _
                                                           cnt_GridGeral_TipoMovimentacao, _
                                                           cnt_GridGeral_FilialOrigem, _
                                                           cnt_GridGeral_Fornecedor, _
                                                           cnt_GridGeral_DataAjuste, _
                                                           cnt_GridGeral_DataMovimento, _
                                                           cnt_GridGeral_Quantidade, _
                                                           cnt_GridGeral_Valor, _
                                                           cnt_GridGeral_ValorICMS, _
                                                           cnt_GridGeral_ValorINSS, _
                                                           cnt_GridGeral_Aprovador, _
                                                           cnt_GridGeral_Aprovado, _
                                                           cnt_GridGeral_DataAprovacao, _
                                                           cnt_GridGeral_TipoSacaria, _
                                                           cnt_GridGeral_TipoQualidade})

        Dim iCont As Integer

        For iCont = 0 To grdGeral.Rows.Count - 1
            With grdGeral.Rows(iCont)
                Select Case .Cells(cnt_GridGeral_Aprovado).Text
                    Case "Sim"
                        .Appearance.ForeColor = Color.Green
                        .Appearance.FontData.Bold = DefaultableBoolean.True
                    Case "Não"
                        .Appearance.ForeColor = Color.Red
                        .Appearance.FontData.Bold = DefaultableBoolean.True
                    Case Else
                        .Appearance.ForeColor = Color.Black
                        .Appearance.FontData.Bold = DefaultableBoolean.False
                End Select
            End With
        Next
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        Pesquisar()
    End Sub

    Private Sub frmConsultaAjuste_RDE_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_Close(Me)
    End Sub

    Private Sub frmConsultaAjuste_RDE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_UsuarioAprovacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Seguranca_Usuario_ComAcesso
        Pesq_UsuarioSolicitacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Seguranca_Usuario_ComAcesso
        Pesq_TipoMovimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        ComboBox_Carregar_Filial(cboFilial, True)
        ComboBox_Carregar_Processo_Tipo(cboTipoAcerto, cnt_Processo_TipoAjusteRD, True)

        SEC_ValidarBotao(cmdNovo, cnt_Tela, SEC_Validador.SEC_V_Inclusao)
        SEC_ValidarBotao(cmdAlterar, cnt_Tela, SEC_Validador.SEC_V_Alteracao)
        SEC_ValidarBotao(cmdExcluir, cnt_Tela, SEC_Validador.SEC_V_Exclusao)

        objGrid_Inicializar(grdGeral, , oDS)
        objGrid_Coluna_Add(grdGeral, "SQ_ACERTO", 0)
        objGrid_Coluna_Add(grdGeral, "Tipo de Acerto", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo de Movimentação", 100)
        objGrid_Coluna_Add(grdGeral, "Filial de Origem", 100)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 100)
        objGrid_Coluna_Add(grdGeral, "Lançamento", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "Data de Movimento", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "Quantidade", 100, , , , , cnt_Formato_NumeroInteiro)
        objGrid_Coluna_Add(grdGeral, "Valor", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor ICMS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor INSS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Aprovador", 100)
        objGrid_Coluna_Add(grdGeral, "Aprovado?", 100)
        objGrid_Coluna_Add(grdGeral, "Data de Aprovação", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "Tipo de Sacaria", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo de Qualidade", 100)

        objGrid_ExibirTotal(grdGeral, cnt_GridGeral_Quantidade, _
                                      cnt_GridGeral_Valor, _
                                      cnt_GridGeral_ValorICMS, _
                                      cnt_GridGeral_ValorINSS)

        Form_Carrega_Grid(Me)
    End Sub
End Class