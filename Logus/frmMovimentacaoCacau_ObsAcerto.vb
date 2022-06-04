Public Class frmMovimentacaoCacau_ObsAcerto
    Public SQ_MOVIMENTACAO As Integer = 0
    Public DS_MOTIVO As String = ""

    Const cnt_Tela_AcertoRD As String = "Administracao_AcertoRD_Movimentacao"

    Private Sub frmMovimentacaoCacau_ObsAcerto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If SQ_MOVIMENTACAO = 0 Then
            Me.Text = "Informação de Motivo"
            txtMotivo.Text = DS_MOTIVO
        Else
            Dim SqlText As String
            Dim oData As DataTable

            cmdGravar.Visible = False
            txtMotivo.ReadOnly = True

            SqlText = "SELECT * FROM SOF.MOVIMENTACAO_ACERTO WHERE SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO
            oData = DBQuery(SqlText)

            If oData.Rows.Count = 0 Then
                If SEC_ValidarAcessoInterno(cnt_Tela_AcertoRD, SEC_Validador.SEC_V_Inclusao) Then
                    cmdGravar.Visible = True
                    txtMotivo.ReadOnly = False
                End If
            Else
                txtMotivo.Text = oData.Rows(0).Item("DS_ACERTO")
            End If
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim oParametro(1) As DBParamentro

        If Me.txtMotivo.Text = "" Then
            Msg_Mensagem("Favor informar um motivo.")
            txtMotivo.Focus()
            Exit Sub
        End If

        DS_MOTIVO = txtMotivo.Text

        If SQ_MOVIMENTACAO > 0 Then
            SqlText = DBMontar_Insert("SOF.MOVIMENTACAO_ACERTO", TipoCampoFixo.Todos, "DS_ACERTO", ":DS_ACERTO", _
                                                                                      "SQ_MOVIMENTACAO", ":SQ_MOVIMENTACAO")
            oParametro(0) = DBParametro_Montar("DS_ACERTO", txtMotivo.Text)
            oParametro(1) = DBParametro_Montar("SQ_MOVIMENTACAO", SQ_MOVIMENTACAO)

            If Not DBExecutar(SqlText, oParametro) Then GoTo Erro
        End If

        Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub
End Class