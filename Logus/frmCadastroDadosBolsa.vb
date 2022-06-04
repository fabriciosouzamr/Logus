Public Class frmCadastroDadosBolsa
    Const cnt_PrecoUnitario As Integer = 100

    Private Sub frmCadastroDadosBolsa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        txtDataCotacao.Value = DataSistema()

        SqlText = "SELECT T.CD_TIPO_MOEDA, T.NO_TIPO_MOEDA" & _
                  " FROM SOF.LIMITE_CREDITO_TIPO_MOEDA T" & _
                  " UNION ALL " & _
                  "SELECT " & cnt_PrecoUnitario & ", 'Preço Unitario' FROM DUAL" & _
                  " UNION ALL " & _
                  "SELECT 0 - CD_STATUS, NO_STATUS" & _
                  " FROM SOF.PROCESSO_STATUS" & _
                  " WHERE CD_PROCESSO = " & cnt_Processo_DadosBolsa
        DBCarregarComboBox(cboTipoDado, SqlText, True)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String

        If txtValor.Value = 0 Then
            Msg_Mensagem("Favor informar um valor.")
            txtValor.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoDado, True) Then
            Msg_Mensagem("Favor selecionar um tipo.")
            cboTipoDado.Focus()
            Exit Sub
        End If

        If cboTipoDado.SelectedValue < 0 Then
            SqlText = DBMontar_Insert("SOF.INDICE_VALORES", TipoCampoFixo.DadoCriacao, _
                                                            "DT_INDICE_VALOR", ":DT_INDICE_VALOR", _
                                                            "VL_INDICE", ":VL_INDICE", _
                                                            "CD_PROCESSO", ":CD_PROCESSO", _
                                                            "CD_INDICE", ":CD_INDICE")
            If Not DBExecutar(SqlText, DBParametro_Montar("DT_INDICE_VALOR", Date_to_Oracle(txtDataCotacao.Text), OracleClient.OracleType.DateTime), _
                                       DBParametro_Montar("VL_INDICE", txtValor.Value), _
                                       DBParametro_Montar("CD_PROCESSO", cnt_Processo_DadosBolsa), _
                                       DBParametro_Montar("CD_INDICE", Math.Abs(cboTipoDado.SelectedValue))) Then GoTo Erro
        ElseIf cboTipoDado.SelectedValue = cnt_PrecoUnitario Then
            SqlText = DBMontar_Insert("SOF.PRECO_CACAU", TipoCampoFixo.DadoCriacao, _
                                                         "DT_COTACAO", ":DT_COTACAO", _
                                                         "VL_PRECO", ":VL_PRECO")
            If Not DBExecutar(SqlText, DBParametro_Montar("DT_COTACAO", Date_to_Oracle(txtDataCotacao.Text), OracleClient.OracleType.DateTime), _
                                       DBParametro_Montar("VL_PRECO", txtValor.Value)) Then GoTo Erro
        Else
            SqlText = DBMontar_Insert("SOF.LIMITE_CREDITO_MOEDA", TipoCampoFixo.DadoCriacao, _
                                                                  "DT_COTACAO", ":DT_COTACAO", _
                                                                  "VL_TAXA", ":VL_TAXA", _
                                                                  "CD_TIPO_MOEDA", ":CD_TIPO_MOEDA")
            If Not DBExecutar(SqlText, DBParametro_Montar("DT_COTACAO", Date_to_Oracle(txtDataCotacao.Text), OracleClient.OracleType.DateTime), _
                                       DBParametro_Montar("VL_TAXA", txtValor.Value), _
                                       DBParametro_Montar("CD_TIPO_MOEDA", cboTipoDado.SelectedValue)) Then GoTo Erro
        End If

        Me.Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub
End Class