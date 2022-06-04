Public Class frmAvi
    Private Sub frmAvi_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            acFilme.Close()
            acFilme.Dispose()
        Catch ex As Exception

        End Try

        Try
            Form_Close(Me)
        Catch ex As Exception

        End Try
    End Sub
End Class