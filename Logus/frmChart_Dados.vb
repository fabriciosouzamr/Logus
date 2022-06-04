Public Class frmChart_Dados
    Dim oChart_Ctrl As Infragistics.Win.UltraWinChart.UltraChart

    Public Sub Form_Carregar(ByVal oChart As Infragistics.Win.UltraWinChart.UltraChart)
        Dim oData As DataTable
        Dim iCont As Integer
        Dim iAux As Integer

        oChart_Ctrl = oChart
        oData = oChart.DataSource

        chkColunas.Items.Clear()

        If Not oData Is Nothing Then
            For iCont = 0 To oData.Columns.Count - 1
                iAux = chkColunas.Items.Add(oData.Columns(iCont).ColumnName)

                If Not oChart.Data.IsColumnExcluded(iCont) Then
                    chkColunas.SetItemChecked(iAux, True)
                End If
            Next
        End If
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub cmdRetornar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRetornar.Click
        Dim iCont As Integer

        For iCont = 0 To chkColunas.Items.Count - 1
            oChart_Ctrl.Data.IncludeColumn(iCont, chkColunas.GetItemChecked(iCont))
        Next

        oChart_Ctrl.Refresh()

        Close()
    End Sub
End Class