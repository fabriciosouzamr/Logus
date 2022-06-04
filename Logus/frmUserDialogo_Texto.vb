Public Class frmUserDialogo_Texto

    Public Cancelado As Boolean
    Public Texto As String

    Public Sub Carregar(ByVal Titulo As String, ByVal Mensagem As String)
        Me.Text = Titulo
        lblTitulo.Text = Mensagem

        Form_Show(Nothing, Me, True, True)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Cancelado = True
        Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If Trim(txtTexto.Text) = "" Then
            Msg_Mensagem("Informe o texto")
            Exit Sub
        End If

        Texto = Replace(txtTexto.Text, "/", "-")
        Cancelado = False
        Close()
    End Sub
End Class