Public Class frmCadastroPDD_Pagamentos
    Event GravacaoEfetuada()

    Public SQ_PDD As Integer
    Public SQ_PDD_PAGAMENTO As Integer

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If Not IsDate(txtData.Text) Then
            Msg_Mensagem("Informe a data de pagamento")
            Exit Sub
        End If
        If txtValor.Value = 0 Then
            Msg_Mensagem("Informe o valor de pagamento")
            Exit Sub
        End If
        If Trim(txtDescricaoPagamento.Text) = "" Then
            Msg_Mensagem("Informe a descrição do pagamento")
            Exit Sub
        End If


        Dim SqlText As String
        Dim SQ_PDD_PAGAMENTO_Int As Integer

        SQ_PDD_PAGAMENTO_Int = SQ_PDD_PAGAMENTO

        If SQ_PDD_PAGAMENTO_Int = 0 Then
            SQ_PDD_PAGAMENTO_Int = DBNumeroMaisUm("SOF.PDD_PAGAMENTO", "SQ_PDD_PAGAMENTO")

            SqlText = DBMontar_Insert("SOF.PDD_PAGAMENTO", TipoCampoFixo.Todos, "SQ_PDD", ":SQ_PDD", _
                                                                                "DT_PAGAMENTO", ":DT_PAGAMENTO", _
                                                                                "VL_PAGO", ":VL_PAGO", _
                                                                                "DS_PAGAMENTO", ":DS_PAGAMENTO", _
                                                                                "IC_TIPO_LANCAMENTO", ":IC_TIPO_LANCAMENTO", _
                                                                                "CM_OBSERVACAO", ":CM_OBSERVACAO", _
                                                                                "SQ_PDD_PAGAMENTO", ":SQ_PDD_PAGAMENTO")
        Else
            SqlText = DBMontar_Update("SOF.PDD_PAGAMENTO", GerarArray("SQ_PDD", ":SQ_PDD", _
                                                                      "DT_PAGAMENTO", ":DT_PAGAMENTO", _
                                                                      "VL_PAGO", ":VL_PAGO", _
                                                                      "DS_PAGAMENTO", ":DS_PAGAMENTO", _
                                                                      "IC_TIPO_LANCAMENTO", ":IC_TIPO_LANCAMENTO", _
                                                                      "CM_OBSERVACAO", ":CM_OBSERVACAO"), _
                                                           GerarArray("SQ_PDD_PAGAMENTO", ":SQ_PDD_PAGAMENTO"))
        End If

        If Not DBExecutar(SqlText, DBParametro_Montar("SQ_PDD", SQ_PDD), _
                                   DBParametro_Montar("DT_PAGAMENTO", Date_to_Oracle(txtData.Text)), _
                                   DBParametro_Montar("VL_PAGO", txtValor.Value), _
                                   DBParametro_Montar("DS_PAGAMENTO", Trim(txtDescricaoPagamento.Text)), _
                                   DBParametro_Montar("IC_TIPO_LANCAMENTO", optTipo.Value), _
                                   DBParametro_Montar("CM_OBSERVACAO", NULLIf(Trim(txtObservacao.Text), ""), , , 4000), _
                                   DBParametro_Montar("SQ_PDD_PAGAMENTO", SQ_PDD_PAGAMENTO_Int)) Then GoTo Erro

        SQ_PDD_PAGAMENTO = SQ_PDD_PAGAMENTO_Int

        RaiseEvent GravacaoEfetuada()

        Msg_Mensagem("Gravação Efetuada")

        Close()

        Exit Sub

Erro:
        TratarErro(, , "frmCadastroPDD_Pagamentos.cmdGravar_Click")
    End Sub

    Private Sub frmCadastroPDD_Pagamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oData As DataTable
        Dim SqlText As String

        SqlText = "SELECT FNC.NO_RAZAO_SOCIAL" & _
                  " FROM SOF.PDD PDD," & _
                        "SOF.FORNECEDOR FNC" & _
                  " WHERE PDD.SQ_PDD = " & SQ_PDD & _
                    " AND FNC.CD_FORNECEDOR = PDD.CD_FORNECEDOR"
        oData = DBQuery(SqlText)

        lblNrPDD.Text = SQ_PDD
        lblFornecedor.Text = oData.Rows(0).Item("NO_RAZAO_SOCIAL")

        If SQ_PDD_PAGAMENTO > 0 Then
            SqlText = "SELECT *" & _
                      " FROM SOF.PDD_PAGAMENTO" & _
                      " WHERE SQ_PDD_PAGAMENTO = " & SQ_PDD_PAGAMENTO
            oData = DBQuery(SqlText)

            With oData.Rows(0)
                txtData.Text = .Item("DT_PAGAMENTO")
                txtValor.Text = .Item("VL_PAGO")
                txtDescricaoPagamento.Text = .Item("DS_PAGAMENTO")
                txtObservacao.Text = NVL(.Item("CM_OBSERVACAO"), "")
            End With
        End If
    End Sub
End Class