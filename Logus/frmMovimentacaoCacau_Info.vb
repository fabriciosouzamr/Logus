Imports Infragistics.Win

Public Class frmMovimentacaoCacau_Info
    Const cnt_GridQualidade_NomeAnalise As Integer = 0
    Const cnt_GridQualidade_ValorAnalise As Integer = 1

    Const cnt_GridSacaria_TipoSacaria As Integer = 0
    Const cnt_GridSacaria_QuantidadeSacos As Integer = 1

    Dim oDS_Qualidade As New UltraWinDataSource.UltraDataSource
    Dim oDS_Sacaria As New UltraWinDataSource.UltraDataSource

    Dim SEQ_MOVIMENTACAO As Integer
    Dim oGridAtivo As Infragistics.Win.UltraWinGrid.UltraGrid

    Public Sub Carregar(ByVal SQ_MOVIMENTACAO As Integer)
        SEQ_MOVIMENTACAO = SQ_MOVIMENTACAO

        objGrid_Inicializar(grdQualidade, , oDS_Qualidade, UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdQualidade, "Nome da Análise", 150)
        objGrid_Coluna_Add(grdQualidade, "Valor da Análise", 130)

        objGrid_Inicializar(grdSacaria, , oDS_Sacaria, UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdSacaria, "Nome do Tipo de Sacaria", 180)
        objGrid_Coluna_Add(grdSacaria, "Quantidade de Sacos", 150)

        CarregarGrid(SEQ_MOVIMENTACAO)
    End Sub

    Private Sub CarregarGrid(ByVal SQ_MOVIMENTACAO As Integer)
        Dim SqlText As String

        SqlText = "SELECT AN.NO_ANALISE," & _
                         "MQ.QT_ANALISE" & _
                  " FROM SOF.VW_MOVIMENTACAO_QUALIDADE_SMS MQ," & _
                        "SOF.ANALISE AN" & _
                  " WHERE MQ.SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                    " AND AN.CD_ANALISE = MQ.CD_ANALISE" & _
                  " ORDER BY NO_ANALISE"
        objGrid_Carregar(grdQualidade, SqlText, New Integer() {cnt_GridQualidade_NomeAnalise, _
                                                               cnt_GridQualidade_ValorAnalise})

        SqlText = "SELECT TS.NO_TIPO_SACARIA," & _
                         "SUM(SF.QT_SACOS) QT_SACOS" & _
                  " FROM SOF.SACARIA_FILIAL SF," & _
                        "SOF.TIPO_SACARIA TS" & _
                  " WHERE SF.CD_TIPO_SACARIA = TS.CD_TIPO_SACARIA" & _
                    " AND SF.SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                  " GROUP BY TS.NO_TIPO_SACARIA, TS.CD_TIPO_SACARIA"
        objGrid_Carregar(grdSacaria, SqlText, New Integer() {cnt_GridSacaria_TipoSacaria, _
                                                             cnt_GridSacaria_QuantidadeSacos})
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        CarregarGrid(SEQ_MOVIMENTACAO)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        If oGridAtivo Is Nothing Then
            Msg_Mensagem("Clique na planilha que você deseja exportar para excell e depois clique no botão novamente")
        Else
            objGrid_ExportarExcell(oGridAtivo, oGridAtivo.Text)
        End If
    End Sub

    Private Sub grdQualidade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdQualidade.Click
        lblListagemAnalise.ForeColor = Color.Red
        lblListagemAnalise.ForeColor = System.Drawing.SystemColors.ControlText
        oGridAtivo = grdQualidade
    End Sub

    Private Sub grdSacaria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSacaria.Click
        lblListagemAnalise.ForeColor = System.Drawing.SystemColors.ControlText
        lblListagemAnalise.ForeColor = Color.Red
        oGridAtivo = grdSacaria
    End Sub
End Class