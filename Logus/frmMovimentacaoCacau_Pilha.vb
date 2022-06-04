Imports Infragistics.Win

Public Class frmMovimentacaoCacau_Pilha
    Const cnt_GridEstoque_Seq As Integer = 0
    Const cnt_GridEstoque_Data As Integer = 1
    Const cnt_GridEstoque_Armazem As Integer = 2
    Const cnt_GridEstoque_Pilha As Integer = 3
    Const cnt_GridEstoque_Volume As Integer = 4
    Const cnt_GridEstoque_Movimentacao As Integer = 5
    Const cnt_GridEstoque_CD_Armazem As Integer = 6

    Const cnt_GridHistorico_Seq As Integer = 0
    Const cnt_GridHistorico_Data As Integer = 1
    Const cnt_GridHistorico_Armazem As Integer = 2
    Const cnt_GridHistorico_Pilha As Integer = 3
    Const cnt_GridHistorico_Volume As Integer = 4
    Const cnt_GirdHistorico_Movimentacao As Integer = 5

    Dim oDS_Estoque As New UltraWinDataSource.UltraDataSource
    Dim oDS_Historico As New UltraWinDataSource.UltraDataSource
    Dim SEQ_MOVIMENTACAO As Integer
    Dim oGridAtivo As Infragistics.Win.UltraWinGrid.UltraGrid
    Dim bAcessoMovimentarCacauEntrePilha As Boolean

    Private Sub pnlBotoes_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBotoes.Resize
        cmdFechar.Left = pnlBotoes.Width - cmdFechar.Width - 3
    End Sub

    Public Sub Carregar(ByVal SQ_MOVIMENTACAO As Integer)
        Dim SqlText As String

        SEQ_MOVIMENTACAO = SQ_MOVIMENTACAO

        objGrid_Inicializar(grdEstoque, , oDS_Estoque)
        grdEstoque.DisplayLayout.CaptionVisible = DefaultableBoolean.True
        grdEstoque.Text = "Consulta Movimentação Pilha"
        objGrid_Coluna_Add(grdEstoque, "Seq", 100)
        objGrid_Coluna_Add(grdEstoque, "Data", 130)
        objGrid_Coluna_Add(grdEstoque, "Armazem", 130)
        objGrid_Coluna_Add(grdEstoque, "Pilha", 80)
        objGrid_Coluna_Add(grdEstoque, "Volume", 100)
        objGrid_Coluna_Add(grdEstoque, "Movimentação", 130)
        objGrid_Coluna_Add(grdEstoque, "CD_Armazem", 0)

        objGrid_Inicializar(grdHistorico, , oDS_Historico, UltraWinGrid.CellClickAction.RowSelect)
        grdHistorico.DisplayLayout.CaptionVisible = DefaultableBoolean.True
        grdHistorico.Text = "Consulta Historico Movimentação Pilha"
        objGrid_Coluna_Add(grdHistorico, "Seq", 100)
        objGrid_Coluna_Add(grdHistorico, "Data", 130)
        objGrid_Coluna_Add(grdHistorico, "Armazem", 130)
        objGrid_Coluna_Add(grdHistorico, "Pilha", 80)
        objGrid_Coluna_Add(grdHistorico, "Volume", 100)
        objGrid_Coluna_Add(grdHistorico, "Movimentação", 130)

        SqlText = "SELECT C.SQ_MOVIMENTACAO_PILHA_ARMAZEM," & _
                         "C.DT_TRANSACAO," & _
                         "A.NO_ARMAZEM," & _
                         "C.CD_PILHA_ARMAZEM," & _
                         "C.QT_VOLUME," & _
                         "DECODE(C.SQ_ESTOQUE_SILO, NULL, 'ENTRADA', 'SILO') NO_MOVIMENTACAO," & _
                         "C.CD_ARMAZEM" & _
                  " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM C," & _
                        "SOF.PILHA_ARMAZEM B," & _
                        "SOF.ARMAZEM A" & _
                  " WHERE B.CD_ARMAZEM = C.CD_ARMAZEM" & _
                    " AND B.CD_PILHA_ARMAZEM = C.CD_PILHA_ARMAZEM" & _
                    " AND A.CD_ARMAZEM = B.CD_ARMAZEM" & _
                    " AND C.SQ_MOVIMENTACAO = " & SEQ_MOVIMENTACAO
        objGrid_Carregar(grdEstoque, SqlText, New Integer() {cnt_GridEstoque_Seq, cnt_GridEstoque_Data, _
                                                             cnt_GridEstoque_Armazem, cnt_GridEstoque_Pilha, _
                                                             cnt_GridEstoque_Volume, cnt_GridEstoque_Movimentacao, _
                                                             cnt_GridEstoque_CD_Armazem})

        SqlText = "SELECT C.SQ_MOV_PILHA_ARMAZEM_HISTORICO," & _
                         "C.DT_TRANSACAO," & _
                         "A.NO_ARMAZEM, " & _
                         "C.CD_PILHA_ARMAZEM," & _
                         "DECODE(C.IC_SAIDA, 'S', 0 - C.QT_VOLUME, C.QT_VOLUME) QT_VOLUME," & _
                         "DECODE(C.SQ_ITEM_TRANSFERENCIA, NULL," & _
                                "DECODE(C.SQ_ESTOQUE_SILO," & _
                                       "NULL," & _
                                       "DECODE(C.IC_SAIDA, 'S'," & _
                                              "'MOVIMENTAÇÃO ENTRE PILHAS'," & _
                                              "'ENTRADA')," & _
                                       "'SILO')," & _
                                "'TRANSFERENCIA') AS NO_MOVIMENTACAO" & _
                  " FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO C," & _
                        "SOF.PILHA_ARMAZEM B," & _
                        "SOF.ARMAZEM A" & _
                  " WHERE B.CD_ARMAZEM = C.CD_ARMAZEM" & _
                    " AND B.CD_PILHA_ARMAZEM = C.CD_PILHA_ARMAZEM" & _
                    " AND A.CD_ARMAZEM = B.CD_ARMAZEM" & _
                    " AND C.SQ_MOVIMENTACAO = " & SEQ_MOVIMENTACAO
        objGrid_Carregar(grdHistorico, SqlText, New Integer() {cnt_GridHistorico_Seq, cnt_GridHistorico_Data, _
                                                               cnt_GridHistorico_Armazem, cnt_GridHistorico_Pilha, _
                                                               cnt_GridHistorico_Volume, cnt_GirdHistorico_Movimentacao})
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Carregar(SEQ_MOVIMENTACAO)
    End Sub

    Private Sub grdEstoque_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdEstoque.Click
        grdHistorico.DisplayLayout.CaptionAppearance.FontData.Bold = DefaultableBoolean.False
        grdEstoque.DisplayLayout.CaptionAppearance.FontData.Bold = DefaultableBoolean.True
        oGridAtivo = grdEstoque
        cmdMovimentar.Visible = (bAcessoMovimentarCacauEntrePilha)
    End Sub

    Private Sub grdHistorico_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdHistorico.Click
        grdHistorico.DisplayLayout.CaptionAppearance.FontData.Bold = DefaultableBoolean.True
        grdEstoque.DisplayLayout.CaptionAppearance.FontData.Bold = DefaultableBoolean.False
        oGridAtivo = grdHistorico
        cmdMovimentar.Visible = False
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        If oGridAtivo Is Nothing Then
            Msg_Mensagem("Clique na planilha que você deseja exportar para excell e depois clique no botão novamente")
        Else
            objGrid_ExportarExcell(oGridAtivo, oGridAtivo.Text)
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub frmMovimentacaoCacau_Pilha_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmdMovimentar.Visible = False
        bAcessoMovimentarCacauEntrePilha = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AcessoMovimentarCacauEntrePilha)
    End Sub

    Private Sub cmdMovimentar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdMovimentar.Click
        If objGrid_LinhaSelecionada(grdEstoque) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmMovimentacaoCacau_Movimentar

        oForm.CD_ARMAZEM = objGrid_Valor(grdEstoque, cnt_GridEstoque_CD_Armazem)
        oForm.CD_PILHA = objGrid_Valor(grdEstoque, cnt_GridEstoque_Pilha)
        oForm.SQ_MOVIMENTACAO = SEQ_MOVIMENTACAO
        oForm.SQ_MOVIMENTACAO_PILHA_ARMAZEM = objGrid_Valor(grdEstoque, cnt_GridEstoque_Seq)
        oForm.Carregar()

        Form_Show(Nothing, oForm, True, True)

        Carregar(SEQ_MOVIMENTACAO)
    End Sub
End Class