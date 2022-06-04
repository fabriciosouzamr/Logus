Public Class frmCadastroContratoFixo_Adendo
    Dim COD_CONTRATO_PAF As Double
    Dim SEQ_NEGOCIACAO As Double
    Dim SEQ_CONTRATO_FIXO As Double

    Public Cancelado As Boolean

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If txtValorAdendo.Value = 0 Then
            Msg_Mensagem("Favor informar um valor.")
            txtValorAdendo.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoAdendo) Then
            Msg_Mensagem("Favor selecionar um tipo de adendo.")
            cboTipoAdendo.Focus()
            Exit Sub
        End If

        On Error GoTo Erro

        Dim SqlText As String

        SqlText = DBMontar_SP("SOF.SP_INCLUI_ADENDO_CTR_FIXO", False, ":CDCTRPAF", _
                                                                      ":NUNEG", _
                                                                      ":NUCTRFIXO", _
                                                                      ":CDTIPOADENDO", _
                                                                      ":VLADENDO")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", COD_CONTRATO_PAF), _
                                   DBParametro_Montar("NUNEG", SEQ_NEGOCIACAO), _
                                   DBParametro_Montar("NUCTRFIXO", SEQ_CONTRATO_FIXO), _
                                   DBParametro_Montar("CDTIPOADENDO", cboTipoAdendo.SelectedValue), _
                                   DBParametro_Montar("VLADENDO", txtValorAdendo.Value)) Then GoTo Erro

        Cancelado = False
        Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Public Sub Carregar(ByVal CD_CONTRATO_PAF As Double, _
                        ByVal SQ_NEGOCIACAO As Double, _
                        ByVal SQ_CONTRATO_FIXO As Double)
        COD_CONTRATO_PAF = CD_CONTRATO_PAF
        SEQ_NEGOCIACAO = SQ_NEGOCIACAO
        SEQ_CONTRATO_FIXO = SQ_CONTRATO_FIXO
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Cancelado = True
        Close()
    End Sub

    Private Sub frmCadastroContratoFixo_Adendo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ComboBox_Carregar_Tipo_Adendo(cboTipoAdendo)
    End Sub
End Class