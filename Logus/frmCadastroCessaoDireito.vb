Public Class frmCadastroCessaoDireito
    Public Enum enCessaoValor
        Quantidade = 1
        Valor = 2
        Ambos = 3
    End Enum

    Public SqMovimentacao As Long
    Public SqCessaoDireito As Long
    Public CessaoValor As enCessaoValor

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmCadastroCessaoDireito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        lblValor.Visible = (CessaoValor <> enCessaoValor.Quantidade)
        txtValor.Visible = (CessaoValor <> enCessaoValor.Quantidade)
        txtQuantidade.Enabled = (CessaoValor <> enCessaoValor.Valor)
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim SqNovaCessaoDireito As Integer
        Dim CdFornecedorOriginal As Integer

        If Pesq_Fornecedor.Codigo = 0 Then
            Msg_Mensagem("Favor informar um fornecedor valido.")
            Exit Sub
        End If
        If CessaoValor = enCessaoValor.Valor Then
            If txtValor.Value <= 0 Then
                Msg_Mensagem("Favor informar um valor cedido maior do que zero.")
                Exit Sub
            End If
        End If
        If CessaoValor = enCessaoValor.Quantidade Then
            If txtQuantidade.Value <= 0 Then
                Msg_Mensagem("Favor informar uma quantidade cedida maior do que zero.")
                Exit Sub
            End If
        End If

        SqlText = "SELECT M.CD_FORNECEDOR" & _
                  " FROM SOF.MOVIMENTACAO_CESSAO_DIREITO M" & _
                  " WHERE M.SQ_MOVIMENTACAO = " & SqMovimentacao & _
                    " AND M.SQ_MOVIMENTACAO_CESSAO_DIREITO = " & SqCessaoDireito
        CdFornecedorOriginal = DBQuery_ValorUnico(SqlText)

        If Pesq_Fornecedor.Codigo = CdFornecedorOriginal Then
            Msg_Mensagem("Favor selecionar um fornecedor diferente da cessão de direito anterior.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*)" & _
                  " FROM SOF.FORNECEDOR F1," & _
                        "SOF.FORNECEDOR F2" & _
                  " WHERE F1.IC_FISICA_JURIDICA = F2.IC_FISICA_JURIDICA" & _
                    " AND F1.CD_FORNECEDOR =  " & CdFornecedorOriginal & _
                    " AND F2.CD_FORNECEDOR =  " & Pesq_Fornecedor.Codigo
        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Os fornecedores tem que ser do mesmo tipo de pessoa (Fisica ou Juridica), pois existe incidência de INSS.")
            Exit Sub
        End If

        SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_CESSAO_DIREITO", False, ":SQMOV", _
                                                                         ":SQMOVCD", _
                                                                         ":CDFORN", _
                                                                         ":QTCD", _
                                                                         ":VL", _
                                                                         ":SQMOVCDN")

        If Not DBExecutar(SqlText, DBParametro_Montar("SQMOV", SqMovimentacao), _
                                   DBParametro_Montar("SQMOVCD", SqCessaoDireito), _
                                   DBParametro_Montar("CDFORN", Pesq_Fornecedor.Codigo), _
                                   DBParametro_Montar("QTCD", IIf(CessaoValor <> enCessaoValor.Valor, txtQuantidade.Value, Nothing)), _
                                   DBParametro_Montar("VL", IIf(CessaoValor <> enCessaoValor.Quantidade, txtValor.Value, Nothing)), _
                                   DBParametro_Montar("SQMOVCDN", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        If DBTeveRetorno() Then
            SqNovaCessaoDireito = DBRetorno(1)
        End If

        Dim oForm As New frmRelatorioGeral

        oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eCessaoDireito
        oForm.Filtro01 = SqMovimentacao
        oForm.Filtro02 = SqNovaCessaoDireito

        Form_Show(Me.MdiParent, oForm)

        Me.Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub
End Class