Public Class frmMovimentacaoCacau_NFReferencia
    Const cnt_GridGeral_SQ_MOVIMENTACAO As Integer = 0
    Const cnt_GridGeral_NotaFiscal As Integer = 1
    Const cnt_GridGeral_Data As Integer = 2
    Const cnt_GridGeral_Fornecedor As Integer = 3
    Const cnt_GridGeral_ValorNF As Integer = 4
    Const cnt_GridGeral_KG_NF As Integer = 5

    Dim oDS As New Infragistics.Win.UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim iCont As Integer

        If Not IsDate(txtDataNotaFiscal.Value) Then
            Msg_Mensagem("Data invalida.")
            txtDataNotaFiscal.Focus()
            Exit Sub
        End If
        If txtNotaFiscal_Numero.Text = "" Then
            Msg_Mensagem("Favor informar o numero da NF.")
            txtNotaFiscal_Numero.Focus()
            Exit Sub
        End If

        DBUsarTransacao = True

        For iCont = 0 To grdGeral.Rows.Count - 1
            SqlText = "UPDATE SOF.MOVIMENTACAO" & _
                      " SET NU_NF_REFERENCIA = " & QuotedStr(txtNotaFiscal_Numero.Text) & _
                          ",DT_NF_REFERENCIA= " & QuotedStr(Date_to_Oracle(txtDataNotaFiscal.Value)) & _
                          ",DT_ALTERACAO = SYSDATE" & _
                          ",NO_USER_ALTERACAO=" & QuotedStr(sAcesso_UsuarioLogado) & _
                      " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_SQ_MOVIMENTACAO, iCont)
            If Not DBExecutar(SqlText) Then GoTo Erro
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Public Sub FormatarTela()
        objGrid_Inicializar(grdGeral, , oDS, Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdGeral, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdGeral, "Nota Fiscal", 90)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 300)
        objGrid_Coluna_Add(grdGeral, "Valor da N.F.", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "KG N.F.", 100, , , , , cnt_Formato_Kilos)
    End Sub

    Public Sub Movimentacao_Adicionar(ByVal SQ_MOVIMENTACAO As Integer, _
                                      ByVal NotaFiscal As String, _
                                      ByVal Data As String, _
                                      ByVal Fornecedor As String, _
                                      ByVal Valor As Double, _
                                      ByVal Quantidade As Integer)
        oDS.Rows.Add()

        With oDS.Rows(oDS.Rows.Count - 1)
            .Item(cnt_GridGeral_SQ_MOVIMENTACAO) = SQ_MOVIMENTACAO
            .Item(cnt_GridGeral_NotaFiscal) = NotaFiscal
            .Item(cnt_GridGeral_Data) = Data
            .Item(cnt_GridGeral_Fornecedor) = Fornecedor
            .Item(cnt_GridGeral_ValorNF) = Valor
            .Item(cnt_GridGeral_KG_NF) = Quantidade
        End With
    End Sub
End Class