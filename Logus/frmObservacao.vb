Public Class frmObservacao
    Public DS_Motivo As String
    Public Cancelado As Boolean

    Dim bObrigatorio As Boolean

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        DS_Motivo = txtMotivo.Text
        Cancelado = True
        Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If bObrigatorio And Trim(txtMotivo.Text) = "" Then
            Msg_Mensagem("É obrigatório informar o motivo")
            Exit Sub
        End If

        DS_Motivo = txtMotivo.Text

        Cancelado = False
        Close()
    End Sub

    Public Sub Carregar(ByVal Titulo As String, _
                        ByVal Motivo As String, _
                        ByVal Obrigatorio As Boolean, _
                        Optional ByVal BloquearEdicao As Boolean = False, _
                        Optional ByVal SomenteVisualizacao As Boolean = False)
        Me.Text = IIf(Trim(Titulo) = "", "Motivo", Titulo)

        txtMotivo.ReadOnly = (BloquearEdicao Or SomenteVisualizacao)
        cmdGravar.Visible = (Not SomenteVisualizacao)

        bObrigatorio = Obrigatorio
        txtMotivo.Text = Motivo
    End Sub
End Class