Public Class frmAcertoRD_Valor

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmAcertoRD_Valor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_TipoMovimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TipoMovimentacao.BancoDados_Filtro_Limpar()
        Pesq_TipoMovimentacao.BancoDados_Filtro_Adicionar("IC_ATIVO = 'S'")
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(3) As DBParamentro

        If Pesq_TipoMovimentacao.Codigo = 0 Then
            Msg_Mensagem("Favor escolher um tipo de movimentação valida.")
            Pesq_TipoMovimentacao.Focus()
            Exit Sub
        End If
        If txtValor.Value = 0 And txtQuantidade.Value = 0 Then
            Msg_Mensagem("Os valores estão zerados.")
            txtValor.Focus()
            Exit Sub
        End If
        If FilialFechada(FilialLogada) Then
            Msg_Mensagem("A Filial está fechada. No momento não é possivel realizar a operação.")
            Exit Sub
        End If

        If Msg_Perguntar("Muda o saldo do RD da filial " & FilialLogada & " ?") = False Then Exit Sub

        SqlText = DBMontar_SP("SOF.INCLUI_RD", False, ":TPMOV", _
                                                       ":DATA", _
                                                       ":FILIAL", _
                                                       ":VALOR", _
                                                       ":QUANT")

        If Not DBExecutar(SqlText, DBParametro_Montar("TPMOV", Pesq_TipoMovimentacao.Codigo), _
                                   DBParametro_Montar("DATA", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime), _
                                   DBParametro_Montar("FILIAL", FilialLogada), _
                                   DBParametro_Montar("VALOR", txtValor.Value), _
                                   DBParametro_Montar("QUANT", txtQuantidade.Value)) Then GoTo Erro

        Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub
End Class