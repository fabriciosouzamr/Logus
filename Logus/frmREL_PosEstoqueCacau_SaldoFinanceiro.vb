Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_PosEstoqueCacau_SaldoFinanceiro
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        If Not IsDate(txtDataBase.Text) Then
            Msg_Mensagem("Informa uma Data Base válida")
            Exit Sub
        End If

        AVI_Carregar(Me)

        oRelatorio = Gera_Relatorio_PosEstoqueCacau_SaldoFinanceiro(txtDataBase.DateTime.Date, txtValorDividasIncobraveis.Value)

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub frmREL_PosEstoqueCacau_SaldoFinanceiro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_PosEstoqueCacau_SaldoFinanceiro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtValorDividasIncobraveis.Value = 0
    End Sub

    Private Sub frmREL_PosEstoqueCacau_SaldoFinanceiro_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub
End Class