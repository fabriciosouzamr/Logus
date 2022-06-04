Public Class frmChart_Texto
    Dim oChart_Ctrl As Infragistics.Win.UltraWinChart.UltraChart

    Public Sub Form_Carregar(ByVal oChart As Infragistics.Win.UltraWinChart.UltraChart)
        oChart_Ctrl = oChart

        txtTituloSuperior.Text = oChart.TitleTop.Text
        txtTituloInferior.Text = oChart.TitleBottom.Text
        txtTituloEsquerdo.Text = oChart.TitleLeft.Text
        txtTituloDireito.Text = oChart.TitleRight.Text
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub cmdRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRetornar.Click
        oChart_Ctrl.TitleTop.Text = txtTituloSuperior.Text
        oChart_Ctrl.TitleBottom.Text = txtTituloInferior.Text
        oChart_Ctrl.TitleLeft.Text = txtTituloEsquerdo.Text
        oChart_Ctrl.TitleRight.Text = txtTituloDireito.Text

        oChart_Ctrl.TitleLeft.Visible = (oChart_Ctrl.TitleLeft.Text.Length <> 0)
        oChart_Ctrl.TitleRight.Visible = (oChart_Ctrl.TitleRight.Text.Length <> 0)
        oChart_Ctrl.TitleBottom.Visible = (oChart_Ctrl.TitleBottom.Text.Length <> 0)
        oChart_Ctrl.TitleTop.Visible = (oChart_Ctrl.TitleTop.Text.Length <> 0)

        Close()
    End Sub
End Class