Public Class frmCancelamento_SolicitarQuantidade
    Public Cancelado As Boolean = True

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Cancelado = True
        Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If txtQuantidade.Value = 0 Then
            Msg_Mensagem("Favor informar uma quantidade.")
            txtQuantidade.Focus()
            Exit Sub
        End If
        If txtQuantidade.ReadOnly = False Then
            If txtQuantidade.Value < 0 Then
                Msg_Mensagem("Favor informar uma quantidade maior que zero.")
                txtQuantidade.Focus()
                Exit Sub
            End If
        End If
        If Trim(txtMotivo.Text) = "" Then
            Msg_Mensagem("Favor informar um motivo.")
            txtMotivo.Focus()
            Exit Sub
        End If

        Cancelado = False

        Close()
    End Sub
End Class