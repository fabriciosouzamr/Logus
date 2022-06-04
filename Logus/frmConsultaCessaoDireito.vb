Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Logus.frmCadastroCessaoDireito

Public Class frmConsultaCessaoDireito
    Const cnt_GridGeral_DT_CESSAO_DIREITO As Integer = 0
    Const cnt_GridGeral_DT_MOVIMENTACAO As Integer = 1
    Const cnt_GridGeral_NO_TIPO_MOVIMENTACAO As Integer = 2
    Const cnt_GridGeral_NO_RAZAO_SOCIAL_FINAL As Integer = 3
    Const cnt_GridGeral_NO_RAZAO_SOCIAL As Integer = 4
    Const cnt_GridGeral_NU_SERIE_NF As Integer = 5
    Const cnt_GridGeral_NU_NF As Integer = 6
    Const cnt_GridGeral_KG_CEDIDO As Integer = 7
    Const cnt_GridGeral_QT_KG_NF As Integer = 8
    Const cnt_GridGeral_QT_KG_BRUTO_NF As Integer = 9
    Const cnt_GridGeral_QT_KG_LIQUIDO_NF As Integer = 10
    Const cnt_GridGeral_QT_KG_A_ORDEM As Integer = 11
    Const cnt_GridGeral_VL_NF As Integer = 12
    Const cnt_GridGeral_VL_NF_ICMS As Integer = 13
    Const cnt_GridGeral_VL_NF_FUNRURAL As Integer = 14
    Const cnt_GridGeral_QT_KG_SOBRA As Integer = 15
    Const cnt_GridGeral_NO_FILIAL_MOVIMENTACAO As Integer = 16
    Const cnt_GridGeral_NO_FILIAL_ORIGEM As Integer = 17
    Const cnt_GridGeral_NO_CIDADE As Integer = 18
    Const cnt_GridGeral_CD_TIPO_NF As Integer = 19
    Const cnt_GridGeral_SQ_ITEM_MOV_BANCARIO As Integer = 20
    Const cnt_GridGeral_SQ_MOVIMENTACAO As Integer = 21
    Const cnt_GridGeral_SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer = 22

    Const cnt_SEC_Tela As String = "Transacao_MovCacau_CessaoDireito"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmConsultaCessaoDireito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_Close(Me)
    End Sub

    Private Sub frmConsultaCessaoDireito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_CodigoNome.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True, , , , True)
        objGrid_Coluna_Add(grdGeral, "Data Cessão", 100)
        objGrid_Coluna_Add(grdGeral, "Data Movimentação", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo Movimentação", 150)
        objGrid_Coluna_Add(grdGeral, "Fornecedor Final", 180)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 180)
        objGrid_Coluna_Add(grdGeral, "Série", 60)
        objGrid_Coluna_Add(grdGeral, "NF", 50)
        objGrid_Coluna_Add(grdGeral, "KG Cedido", 90, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "KG NF", 70, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "KG Bruto", 90, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "KG Líquido", 90, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "KG a Ordem", 180, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Valor NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor ICMS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor Funrural", 130, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Quebra/Sobra", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Filial Movimentação", 150)
        objGrid_Coluna_Add(grdGeral, "Filial Origem", 120)
        objGrid_Coluna_Add(grdGeral, "Município", 110)
        objGrid_Coluna_Add(grdGeral, "Tipo Doc", 100)
        objGrid_Coluna_Add(grdGeral, "Mov. Bancário", 100)
        objGrid_Coluna_Add(grdGeral, "Código Movimentação", 100)
        objGrid_Coluna_Add(grdGeral, "Código Cessão", 100)

        Form_Carrega_Grid(Me)

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT /*+ ORDERED */ " & _
                         "MCD.DT_CESSAO_DIREITO," & _
                         "M.DT_MOVIMENTACAO," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "FMCD.NO_RAZAO_SOCIAL NO_FORNECEDOR_FINAL," & _
                         "F.NO_RAZAO_SOCIAL," & _
                         "M.NU_SERIE_NF," & _
                         "M.NU_NF," & _
                         "MCD.QT_KG_MOVIMENTACAO," & _
                         "M.QT_KG_NF," & _
                         "M.QT_KG_BRUTO_NF," & _
                         "M.QT_KG_LIQUIDO_NF," & _
                         "MCD.QT_KG_A_FIXAR," & _
                         "M.VL_NF," & _
                         "M.VL_NF_ICMS," & _
                         "M.VL_NF_FUNRURAL," & _
                         "M.QT_KG_SOBRA," & _
                         "FIL.NO_FILIAL," & _
                         "FILO.NO_FILIAL AS NO_FILIAL_ORIGEM," & _
                         "MUNIC.NO_CIDADE || ' - ' || MUNIC.CD_UF AS NO_MUNICIPIO," & _
                         "M.CD_TIPO_NF," & _
                         "M.SQ_ITEM_MOV_BANCARIO," & _
                         "M.SQ_MOVIMENTACAO," & _
                         "MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO " & _
                  " FROM SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                        "SOF.FORNECEDOR FMCD," & _
                        "SOF.MOVIMENTACAO M," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.MUNICIPIO MUNIC," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.FILIAL FILO," & _
                        "SOF.TIPO_MOVIMENTACAO TM" & _
                  " WHERE M.CD_TIPO_MOVIMENTACAO = TM.CD_TIPO_MOVIMENTACAO" & _
                    " AND M.CD_FILIAL_MOVIMENTACAO = FIL.CD_FILIAL" & _
                    " AND M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                    " AND M.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND M.CD_MUNICIPIO_ORIGEM = MUNIC.CD_MUNICIPIO(+)" & _
                    " AND F.CD_FILIAL_ORIGEM = FILO.CD_FILIAL" & _
                    " AND MCD.CD_FORNECEDOR = FMCD.CD_FORNECEDOR"

        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(MCD.DT_CESSAO_DIREITO) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If

        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(MCD.DT_CESSAO_DIREITO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        If Pesq_CodigoNome.Codigo > 0 Then
            SqlText = SqlText & " AND MCD.CD_FORNECEDOR = " & Pesq_CodigoNome.Codigo
        End If

        If chkSomenteTransferencia.Checked = True Then
            SqlText = SqlText & " AND MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO <> 1"
        End If

        Select Case optFiltro.Value
            Case "S"
                SqlText = SqlText & " AND (MCD.QT_KG_A_FIXAR <> 0)"
            Case "A"
                SqlText = SqlText & " AND (MCD.QT_KG_A_FIXAR = 0)"
        End Select

        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM  IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM  IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & "ORDER BY DT_CESSAO_DIREITO," & _
                                      "NO_FORNECEDOR_FINAL"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_DT_CESSAO_DIREITO, _
                                                           cnt_GridGeral_DT_MOVIMENTACAO, _
                                                           cnt_GridGeral_NO_TIPO_MOVIMENTACAO, _
                                                           cnt_GridGeral_NO_RAZAO_SOCIAL_FINAL, _
                                                           cnt_GridGeral_NO_RAZAO_SOCIAL, _
                                                           cnt_GridGeral_NU_SERIE_NF, _
                                                           cnt_GridGeral_NU_NF, _
                                                           cnt_GridGeral_KG_CEDIDO, _
                                                           cnt_GridGeral_QT_KG_NF, _
                                                           cnt_GridGeral_QT_KG_BRUTO_NF, _
                                                           cnt_GridGeral_QT_KG_LIQUIDO_NF, _
                                                           cnt_GridGeral_QT_KG_A_ORDEM, _
                                                           cnt_GridGeral_VL_NF, _
                                                           cnt_GridGeral_VL_NF_ICMS, _
                                                           cnt_GridGeral_VL_NF_FUNRURAL, _
                                                           cnt_GridGeral_QT_KG_SOBRA, _
                                                           cnt_GridGeral_NO_FILIAL_MOVIMENTACAO, _
                                                           cnt_GridGeral_NO_FILIAL_ORIGEM, _
                                                           cnt_GridGeral_NO_CIDADE, _
                                                           cnt_GridGeral_CD_TIPO_NF, _
                                                           cnt_GridGeral_SQ_ITEM_MOV_BANCARIO, _
                                                           cnt_GridGeral_SQ_MOVIMENTACAO, _
                                                           cnt_GridGeral_SQ_MOVIMENTACAO_CESSAO_DIREITO})

        objGrid_ExibirTotal(grdGeral, New Integer() {cnt_GridGeral_KG_CEDIDO, cnt_GridGeral_QT_KG_A_ORDEM})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "movimentacao_cessao_direito", "sq_movimentacao = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO) & " AND " & _
                                        "sq_movimentacao_cessao_direito = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO_CESSAO_DIREITO))

    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Dim CessaoValor As enCessaoValor = enCessaoValor.Quantidade

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdGeral, cnt_GridGeral_QT_KG_A_ORDEM) = 0 And _
           objGrid_Valor(grdGeral, cnt_GridGeral_VL_NF) = 0 Then
            Msg_Mensagem("A movimentação não possui valores em aberto.")
            Exit Sub
        End If
        If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_RealizarCessaoDireitoQuantidadeValor_NF) Then
            CessaoValor = enCessaoValor.Ambos
        Else
            If objGrid_Valor(grdGeral, cnt_GridGeral_QT_KG_A_ORDEM) = 0 Then
                If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_RealizarCessaoDireitoValor_NF) Then
                    CessaoValor = enCessaoValor.Valor
                Else
                    Msg_Mensagem("Não é posivel fazer sessão de direito só de valor.")
                    Exit Sub
                End If
            End If
        End If

        Dim oForm As New frmCadastroCessaoDireito

        oForm.SqMovimentacao = objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO)
        oForm.SqCessaoDireito = objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO_CESSAO_DIREITO)
        oForm.CessaoValor = CessaoValor

        Form_Show(Me.MdiParent, oForm)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO_CESSAO_DIREITO) = 1 Then
            Msg_Mensagem("Não é possível fazer a impressão da cessão de direito.")
            Exit Sub
        End If

        Dim oForm As New frmRelatorioGeral

        oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eCessaoDireito

        oForm.Filtro01 = objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO)
        oForm.Filtro02 = objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO_CESSAO_DIREITO)

        Form_Show(Me.MdiParent, oForm)
    End Sub

    Private Sub frmConsultaCessaoDireito_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
        cmdImprimir.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO_CESSAO_DIREITO) = 1 Then
            Msg_Mensagem("Não é possível fazer a impressão da cessão de direito.")
            Exit Sub
        End If

        Dim SqlText As String

        If Not Msg_Perguntar("Deseja eliminar a cessão de direito?") Then Exit Sub

        SqlText = DBMontar_SP("SOF.SP_ELIMINA_MOV_CESSAO_DIREITO", False, ":SQMOV", _
                                                                      ":SQMOVCD")

        If Not DBExecutar(SqlText, DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO)), _
                                   DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO_CESSAO_DIREITO))) Then GoTo Erro

        ExecutaConsulta()
        Exit Sub
Erro:
        TratarErro()

    End Sub
End Class