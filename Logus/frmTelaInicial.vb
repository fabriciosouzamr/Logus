Public Class frmTelaInicial
    Private Sub frmTelaInicial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox_Carregar_Filial(lstListagemFilial, , , True)
        lstListagemFilial.SelectedIndex = -1
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        End
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        ValidarInformacao()
    End Sub

    Private Sub ValidarInformacao()
        If lstListagemFilial.SelectedItems.Count = 0 Then
            Msg_Mensagem("É necessário que seja selecionada um filial para prosseguir com a utlização do sistema")
            Exit Sub
        End If

        FilialLogada = lstListagemFilial.SelectedItems(0)(0)
        PovoaFiliaisLiberadaUsuario()
        Close()
    End Sub

    Private Sub lstListagemFilial_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstListagemFilial.DoubleClick
        ValidarInformacao()
    End Sub
End Class