Public Class frmCadastroEstoqueSilo
    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmCadastroEstoqueSilo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Transferencia_Modalidade_Silo(cboModalidade, True)
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim CdFilialMae As Integer

        If Not ComboBox_LinhaSelecionada(cboModalidade) Then
            Msg_Mensagem("Favor selecionar uma modalidade de transferencia")
            cboModalidade.Focus()
            Exit Sub
        End If
        If txtQuantidade.Value <= 0 Then
            Msg_Mensagem("Volume Invalido.")
            txtQuantidade.Focus()
            Exit Sub
        End If
        If Not IsDate(txtDataIndustrializacao.Text) Then
            Msg_Mensagem("É obrigatório informar a data de referência dessa industrialização")
            Exit Sub
        Else
            SqlText = "SELECT COUNT(*) FROM SOF.RESUMO_DIARIO_ESTOQUE WHERE DT_MOVIMENTO = " & QuotedStr(Date_to_Oracle(txtDataIndustrializacao.Text))

            If DBQuery_ValorUnico(SqlText) = 0 Then
                Msg_Mensagem("Não existe valor de RD para a data informada")
                Exit Sub
            End If
        End If

        SqlText = "SELECT CD_FILIAL_MAE FROM SOF.PARAMETRO"
        CdFilialMae = DBQuery_ValorUnico(SqlText)

        SqlText = DBMontar_SP("SOF.SP_INCLUI_ESTOQUE_SILO", False, ":CDFILIAL", _
                                                                   ":QTVOLUME", _
                                                                   ":CDTRANSFERENCIAMODALIDADE", _
                                                                   ":DT_VALOR_ESTOQUE")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDFILIAL", CdFilialMae), _
                                   DBParametro_Montar("QTVOLUME", txtQuantidade.Value), _
                                   DBParametro_Montar("CDTRANSFERENCIAMODALIDADE", cboModalidade.SelectedValue), _
                                   DBParametro_Montar("DT_VALOR_ESTOQUE", Date_to_Oracle(txtDataIndustrializacao.Text))) Then GoTo Erro


        ComboBox_Possicionar(cboModalidade, -1)
        txtQuantidade.Value = 0

        Exit Sub

Erro:
        TratarErro()
    End Sub
End Class