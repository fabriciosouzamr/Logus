Public Class frmProgressBar
    Public Sub Inclementa_Valor_ProgressBar(ByVal valor As Double)
        If ProgressBar.Value + valor > 100 Then
            ProgressBar.Value = 100
        Else
            ProgressBar.Value = Math.Round(ProgressBar.Value + valor, 2)
        End If
    End Sub
End Class