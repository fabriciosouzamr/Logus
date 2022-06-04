Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaArmazemItem
    Const cnt_GridSacaria_CodigoArmazem As Integer = 0
    Const cnt_GridSacaria_Pilha As Integer = 1
    Const cnt_GridSacaria_SqMovimentcao As Integer = 2
    Const cnt_GridSacaria_SqMovimentacaoPilha As Integer = 3 '
    Const cnt_GridSacaria_SqMovimentacaoPilhaSacaria As Integer = 4
    Const cnt_GridSacaria_CodigoTipoSacaria As Integer = 5
    Const cnt_GridSacaria_TipoSacaria As Integer = 6
    Const cnt_GridSacaria_Quantidade As Integer = 7

    Const cnt_GridMovimentacao_CodigoArmazem As Integer = 0
    Const cnt_GridMovimentacao_Armazem As Integer = 1
    Const cnt_GridMovimentacao_Pilha As Integer = 2
    Const cnt_GridMovimentacao_Saldo As Integer = 3
    Const cnt_GridMovimentacao_Fornecedor As Integer = 4
    Const cnt_GridMovimentacao_NF As Integer = 5
    Const cnt_GridMovimentacao_KgNF As Integer = 6
    Const cnt_GridMovimentacao_KgLiquido As Integer = 7
    Const cnt_GridMovimentacao_Procedencia As Integer = 8
    Const cnt_GridMovimentacao_SqMovimentcao As Integer = 9
    Const cnt_GridMovimentacao_SqMovimentacaoPilha As Integer = 10
    Const cnt_GridMovimentacao_SqEstoqueSilo As Integer = 11

    Dim CdArmazem As Integer
    Dim CdPilha As Integer
    Dim oDS_Movimentacao As New UltraWinDataSource.UltraDataSource
    Dim oDS_Sacaria As New UltraWinDataSource.UltraDataSource

    Private Sub frmConsultaArmazemItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CdArmazem = Filtro
        CdPilha = Filtro1

        objGrid_Inicializar(grdSacaria, , oDS_Sacaria, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdSacaria, "Codigo Armazem", 0)
        objGrid_Coluna_Add(grdSacaria, "Pilha", 0)
        objGrid_Coluna_Add(grdSacaria, "SqMovimentcao", 0)
        objGrid_Coluna_Add(grdSacaria, "SqMovimentacaoPilha", 0)
        objGrid_Coluna_Add(grdSacaria, "SqMovimentacaoPilhaSacaria", 0)
        objGrid_Coluna_Add(grdSacaria, "Codigo Tipo Sacaria", 0)
        objGrid_Coluna_Add(grdSacaria, "Tipo Sacaria", 120)
        objGrid_Coluna_Add(grdSacaria, "Quantidade", 90, , , , , cnt_Formato_NumeroInteiro)

        objGrid_Inicializar(grdEstoque, , oDS_Movimentacao, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdEstoque, "CodigoArmazem", 0)
        objGrid_Coluna_Add(grdEstoque, "Armazem", 90)
        objGrid_Coluna_Add(grdEstoque, "Pilha", 60, , , , , cnt_Formato_NumeroInteiro)
        objGrid_Coluna_Add(grdEstoque, "Saldo", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdEstoque, "Fornecedor", 120)
        objGrid_Coluna_Add(grdEstoque, "NF", 60)
        objGrid_Coluna_Add(grdEstoque, "Kg NF", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdEstoque, "Kg Liquido", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdEstoque, "Proc", 50)
        objGrid_Coluna_Add(grdEstoque, "SqMovimentcao", 0)
        objGrid_Coluna_Add(grdEstoque, "SqMovimentacaoPilha", 0)
        objGrid_Coluna_Add(grdEstoque, "SqEstoqueSilo", 0)

        ExecutaConsultaMovimentacao()

        SEC_ValidarBotao_Permissao(cmdAjuste_Estoque, SEC_Permissao.SEC_P_Acesso_AjustarSaldoEstoqueSacariaMovimentacoes, True)
        SEC_ValidarBotao_Permissao(cmdAjuste_Sacaria, SEC_Permissao.SEC_P_Acesso_AjustarSaldoEstoqueSacariaMovimentacoes, True)
        SEC_ValidarBotao_Permissao(cmdMovimentar, SEC_Permissao.SEC_P_Acesso_AcessoMovimentarCacauEntrePilha, True)
    End Sub

    Private Sub ExecutaConsultaSacaria()
        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdEstoque) = -1 Then
            Exit Sub
        End If

        SqlText = "SELECT a.cd_armazem, a.cd_pilha_armazem, a.sq_movimentacao, a.sq_movimentacao_pilha_armazem, " & _
                   "A.sq_mov_pilha_armazem_sacaria ,a.cd_tipo_sacaria, b.no_tipo_sacaria, A.qt_sacos " & _
                   "FROM sof.mov_pilha_armazem_sacaria a, sof.tipo_sacaria b " & _
                   "WHERE b.cd_tipo_sacaria = a.cd_tipo_sacaria and " & _
                   "a.cd_armazem = " & objGrid_Valor(grdEstoque, cnt_GridMovimentacao_CodigoArmazem) & " and " & _
                   "a.cd_pilha_armazem = " & objGrid_Valor(grdEstoque, cnt_GridMovimentacao_Pilha) & " and " & _
                   "a.sq_movimentacao = " & objGrid_Valor(grdEstoque, cnt_GridMovimentacao_SqMovimentcao) & " and " & _
                   "a.sq_movimentacao_pilha_armazem = " & objGrid_Valor(grdEstoque, cnt_GridMovimentacao_SqMovimentacaoPilha)


        objGrid_Carregar(grdSacaria, SqlText, New Integer() {cnt_GridSacaria_CodigoArmazem, _
                                                                cnt_GridSacaria_Pilha, _
                                                                cnt_GridSacaria_SqMovimentcao, _
                                                                cnt_GridSacaria_SqMovimentacaoPilha, _
                                                                cnt_GridSacaria_SqMovimentacaoPilhaSacaria, _
                                                                cnt_GridSacaria_CodigoTipoSacaria, _
                                                                cnt_GridSacaria_TipoSacaria, _
                                                                cnt_GridSacaria_Quantidade})
    End Sub

    Private Sub ExecutaConsultaMovimentacao()
        Dim SqlText As String

        SqlText = "SELECT MPA.CD_ARMAZEM," & _
                         "A.NO_ARMAZEM," & _
                         "MPA.CD_PILHA_ARMAZEM," & _
                         "MPA.QT_VOLUME," & _
                         "DECODE(F.NO_RAZAO_SOCIAL, NULL, FIL.NO_FILIAL, F.NO_RAZAO_SOCIAL) NO_FORNECEDOR," & _
                         "M.NU_NF," & _
                         "M.QT_KG_NF," & _
                         "M.QT_KG_LIQUIDO_NF," & _
                         "M.CD_PROCEDENCIA," & _
                         "MPA.SQ_MOVIMENTACAO," & _
                         "MPA.SQ_MOVIMENTACAO_PILHA_ARMAZEM," & _
                         "MPA.SQ_ESTOQUE_SILO" & _
                  " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM MPA," & _
                        "SOF.MOVIMENTACAO M," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.TRANSFERENCIA T," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.ARMAZEM A" & _
                  " WHERE M.SQ_MOVIMENTACAO = MPA.SQ_MOVIMENTACAO" & _
                    " AND MPA.CD_ARMAZEM = A.CD_ARMAZEM" & _
                    " AND F.CD_FORNECEDOR (+) = M.CD_FORNECEDOR" & _
                    " AND T.SQ_MOVIMENTACAO_ENTRADA (+) = M.SQ_MOVIMENTACAO" & _
                    " AND T.CD_FILIAL_ORIGEM = FIL.CD_FILIAL (+)" & _
                    " AND MPA.CD_ARMAZEM = " & CdArmazem

        If CdPilha <> -1 Then
            SqlText = SqlText & " AND MPA.CD_PILHA_ARMAZEM = " & CdPilha
        End If

        objGrid_Carregar(grdEstoque, SqlText, New Integer() {cnt_GridMovimentacao_CodigoArmazem, _
                                                                cnt_GridMovimentacao_Armazem, _
                                                                cnt_GridMovimentacao_Pilha, _
                                                                cnt_GridMovimentacao_Saldo, _
                                                                cnt_GridMovimentacao_Fornecedor, _
                                                                cnt_GridMovimentacao_NF, _
                                                                cnt_GridMovimentacao_KgNF, _
                                                                cnt_GridMovimentacao_KgLiquido, _
                                                                cnt_GridMovimentacao_Procedencia, _
                                                                cnt_GridMovimentacao_SqMovimentcao, _
                                                                cnt_GridMovimentacao_SqMovimentacaoPilha, _
                                                                cnt_GridMovimentacao_SqEstoqueSilo})
    End Sub

    Private Sub grdMovimentacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdEstoque.Click
        ExecutaConsultaSacaria()
    End Sub


    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Movimentacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell_Movimentacao.Click
        objGrid_ExportarExcell(grdEstoque, Me.Text, cmdExcell_Movimentacao)
    End Sub

    Private Sub cmdExcell_Sacaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell_Sacaria.Click
        objGrid_ExportarExcell(grdSacaria, Me.Text, cmdExcell_Sacaria)
    End Sub

    Private Sub cmdMovimentar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMovimentar.Click
        If objGrid_LinhaSelecionada(grdEstoque) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmMovimentacaoCacau_Movimentar

        oForm.CD_ARMAZEM = objGrid_Valor(grdEstoque, cnt_GridMovimentacao_CodigoArmazem)
        oForm.CD_PILHA = objGrid_Valor(grdEstoque, cnt_GridMovimentacao_Pilha)
        oForm.SQ_MOVIMENTACAO = objGrid_Valor(grdEstoque, cnt_GridMovimentacao_SqMovimentcao)
        oForm.SQ_MOVIMENTACAO_PILHA_ARMAZEM = objGrid_Valor(grdEstoque, cnt_GridMovimentacao_SqMovimentacaoPilha)
        oForm.Carregar()

        Form_Show(Nothing, oForm, True, True)

        ExecutaConsultaMovimentacao()
    End Sub

    Private Sub cmdAjusta_Estoque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAjuste_Estoque.Click
        If objGrid_LinhaSelecionada(grdEstoque) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmMovimentacaoCacau_AjusteEstoque

        oForm.CD_ARMAZEM = objGrid_Valor(grdEstoque, cnt_GridMovimentacao_CodigoArmazem)
        oForm.CD_PILHA = objGrid_Valor(grdEstoque, cnt_GridMovimentacao_Pilha)
        oForm.SQ_MOVIMENTACAO = objGrid_Valor(grdEstoque, cnt_GridMovimentacao_SqMovimentcao)
        oForm.SQ_MOVIMENTACAO_PILHA_ARMAZEM = objGrid_Valor(grdEstoque, cnt_GridMovimentacao_SqMovimentacaoPilha)
        oForm.Carregar()

        Form_Show(Nothing, oForm, True, True)

        ExecutaConsultaMovimentacao()
    End Sub

    Private Sub cmdAjusta_Sacaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAjuste_Sacaria.Click
        If objGrid_LinhaSelecionada(grdEstoque) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmMovimentacaoCacau_AjusteSacaria

        oForm.CD_ARMAZEM = objGrid_Valor(grdSacaria, cnt_GridSacaria_CodigoArmazem)
        oForm.CD_PILHA = objGrid_Valor(grdSacaria, cnt_GridSacaria_Pilha)
        oForm.SQ_MOVIMENTACAO = objGrid_Valor(grdSacaria, cnt_GridSacaria_SqMovimentcao)
        oForm.SQ_MOVIMENTACAO_PILHA_ARMAZEM = objGrid_Valor(grdSacaria, cnt_GridSacaria_SqMovimentacaoPilha)
        oForm.SQ_MOVIMENTACAO_PILHA_ARMAZEM_SACARIA = objGrid_Valor(grdSacaria, cnt_GridSacaria_SqMovimentacaoPilhaSacaria)
        oForm.CD_TIPO_SACARIA = objGrid_Valor(grdSacaria, cnt_GridSacaria_CodigoTipoSacaria)
        oForm.Carregar()

        Form_Show(Nothing, oForm, True, True)

        ExecutaConsultaSacaria()
    End Sub
End Class