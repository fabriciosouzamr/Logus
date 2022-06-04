Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaFornecedorHistorico
    Const cnt_GridGeral_Data As Integer = 0
    Const cnt_GridGeral_CodigoFornecedor As Integer = 1
    Const cnt_GridGeral_Fornecedor As Integer = 2
    Const cnt_GridGeral_TipoPessoa As Integer = 3
    Const cnt_GridGeral_Ação As Integer = 4
    Const cnt_GridGeral_NomeUsuario As Integer = 5
    Const cnt_GridGeral_CodigoUsuario As Integer = 6

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub frmConsultaFornecedorHistorico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox_Carregar_Tipo_Acao(lstTipoAcao, True)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdGeral, "Data", 100)
        objGrid_Coluna_Add(grdGeral, "Código Fornecedor", 100)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 180)
        objGrid_Coluna_Add(grdGeral, "Tipo pessoa", 120)
        objGrid_Coluna_Add(grdGeral, "Ação", 150)
        objGrid_Coluna_Add(grdGeral, "Nome Usuário", 140)
        objGrid_Coluna_Add(grdGeral, "Código Usuário", 100)

        Pesq_CodigoNome.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT FH.DT_ACAO," & _
                         "FH.CD_FORNECEDOR," & _
                         "FH.NO_FORNECEDOR," & _
                         "TP.NO_TIPO_PESSOA," & _
                         "TA.NO_TIPO_ACAO," & _
                         "U.NO_USUARIO," & _
                         "FH.CD_USER" & _
                  " FROM SOF.TIPO_ACAO TA," & _
                        "SOF.FORNECEDOR_HISTORICO FH," & _
                        "SOF.USUARIO U," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.TIPO_PESSOA TP" & _
                  " WHERE FH.CD_TIPO_ACAO = TA.CD_TIPO_ACAO" & _
                    " AND FH.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA" & _
                    " AND FH.CD_USER = U.CD_USER"

        If Trim(txtRazaoSocial.Text) <> "" Then
            SqlText = SqlText & " AND UPPER(FH.NO_FORNECEDOR) LIKE " & SQL_FormatarLike(txtRazaoSocial.Text)
        End If
        If Pesq_CodigoNome.Codigo > 0 Then
            SqlText = SqlText & " AND FH.CD_FORNECEDOR = " & Pesq_CodigoNome.Codigo
        End If
        If lstTipoAcao.CheckedItems.Count > 0 Then
            SqlText = SqlText & " AND TA.CD_TIPO_ACAO " & objCheckList_SQL_In_Montar(lstTipoAcao)
        End If
        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(FH.DT_ACAO) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(FH.DT_ACAO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Data, _
                                                           cnt_GridGeral_CodigoFornecedor, _
                                                           cnt_GridGeral_Fornecedor, _
                                                           cnt_GridGeral_TipoPessoa, _
                                                           cnt_GridGeral_Ação, _
                                                           cnt_GridGeral_NomeUsuario, _
                                                           cnt_GridGeral_CodigoUsuario})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub frmConsultaFornecedorHistorico_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub
End Class