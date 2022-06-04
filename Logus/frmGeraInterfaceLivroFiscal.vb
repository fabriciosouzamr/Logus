Public Class frmGeraInterfaceLivroFiscal

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdEnviaOW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnviaOW.Click
        Dim SqlText As String

        If Not IsDate(txtData.Text) Then
            Msg_Mensagem("Data invalida.")
            Exit Sub
        End If

        If Msg_Perguntar("Deseja realizar a Interface? ?") = False Then Exit Sub

        RefazInterface(False)

        SqlText = DBMontar_SP("SOF.SP_CLASS_INTERFACE_LIVROFISCAL", False, ":DATA")

        If Not DBExecutar(SqlText, DBParametro_Montar("DATA", Date_to_Oracle(txtData.Text))) Then GoTo Erro

        Msg_Mensagem("Interface gerada com sucesso.")
        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub cmdRefazInterface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefazInterface.Click
        RefazInterface()
    End Sub

    Private Sub RefazInterface(Optional ByVal bExibirMensagem As Boolean = True)
        Dim SqlText As String = ""

        If Not IsDate(txtData.Text) Then
            Msg_Mensagem("Data invalida.")
            Exit Sub
        End If

        SqlText = DBMontar_SP("SOF.SP_GERA_INTERFACE_LIVROFISCAL", False, ":DATA")
        If Not DBExecutar(SqlText, DBParametro_Montar("DATA", Date_to_Oracle(txtData.Text))) Then GoTo Erro

        If bExibirMensagem Then
            Msg_Mensagem("Interface refeita com sucesso.")
        End If

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub frmGeraInterfaceLivroFiscal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtData.Value = DataSistema()
    End Sub
End Class