Public Class frmCadastroContratoFixo_FixarDolar
    Public Cancelado As Boolean

    Dim oData As DataTable
    Dim COD_CONTRATO_PAF As Double
    Dim SEQ_NEGOCIACAO As Double
    Dim SEQ_CONTRATO_FIXO As Double

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If txtTaxaDolar.Value <= 0 Then
            Msg_Mensagem("Favor informar uma taxa de dolar valido.")
            Fechar(True)
        End If

        Dim VL_Aux As Double
        Dim VL_Unitario As Double
        Dim VL_Total As Double
        Dim VL_ICMS As Double
        Dim VL_INSS As Double
        Dim SqlText As String

        On Error GoTo Erro

        With oData.Rows(0)
            VL_Unitario = Math.Round(.Item("VL_UNITARIO_US") * txtTaxaDolar.Value, 2)

            VL_Total = (.Item("QT_KGS") - .Item("QT_CANCELADO")) * _
                       (VL_Unitario / .Item("QT_FATOR"))

            VL_Aux = VL_Total / (1 - ((.Item("PC_ALIQ_ICMS") + .Item("VL_TAXA")) / 100))
            VL_ICMS = VL_Aux * (.Item("PC_ALIQ_ICMS") / 100)
            VL_INSS = VL_Aux * (.Item("VL_TAXA") / 100)

            If Not Msg_Perguntar("Novos valores do contrato:" & _
                                 vbCrLf & "Valor Total: " & Format(VL_Total, "#,##0.00") & _
                                 vbCrLf & "Valor ICMS: " & Format(VL_ICMS, "#,##0.00") & _
                                 vbCrLf & "Valor INSS: " & Format(VL_INSS, "#,##0.00") & vbCrLf & _
                                 "Continua ?") Then Exit Sub

            If FilialFechada(FilialLogada) Then Exit Sub

            SqlText = "UPDATE SOF.CONTRATO_FIXO" & _
                      " SET VL_TOTAL = " & VL_Total & _
                          ",VL_ICMS = " & VL_ICMS & _
                          ",VL_UNITARIO = " & VL_Unitario & _
                          ",VL_INSS = " & VL_INSS & _
                          ",IC_TAXA_DOLAR_VARIAVEL = 'N'" & _
                          ",VL_TAXA_DOLAR_FECHAMENTO = " & txtTaxaDolar.Value & _
                          ",VL_TAXA_DOLAR_FECHADO = " & txtTaxaDolar.Value & _
                          ",DT_FECHAMENTO_TAXA_DOLAR = " & QuotedStr(Date_to_Oracle(DataSistema)) & _
                      " WHERE CD_CONTRATO_PAF = " & COD_CONTRATO_PAF & _
                        " AND SQ_NEGOCIACAO = " & SEQ_NEGOCIACAO & _
                        " AND SQ_CONTRATO_FIXO = " & SEQ_CONTRATO_FIXO
            If Not DBExecutar(SqlText) Then GoTo Erro
        End With

        Fechar(False)

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub Fechar(ByVal Cancelar As Boolean)
        oData.Dispose()
        Cancelado = Cancelar
        Close()
    End Sub

    Public Sub Carregar(ByVal CD_CONTRATO_PAF As Double, _
                        ByVal SQ_NEGOCIACAO As Double, _
                        ByVal SQ_CONTRATO_FIXO As Double)
        Dim SqlText As String

        COD_CONTRATO_PAF = CD_CONTRATO_PAF
        SEQ_NEGOCIACAO = SQ_NEGOCIACAO
        SEQ_CONTRATO_FIXO = SQ_CONTRATO_FIXO

        SqlText = "SELECT CF.*," & _
                         "TU.QT_FATOR," & _
                         "FUN.VL_TAXA" & _
                  " FROM SOF.CONTRATO_FIXO CF," & _
                        "SOF.TIPO_UNIDADE TU," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FUNRURAL FUN" & _
                  " WHERE TU.CD_TIPO_UNIDADE = CF.CD_TIPO_UNIDADE" & _
                    " AND CF.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                    " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND F.CD_FUNRURAL = FUN.CD_FUNRURAL" & _
                    " AND CF.CD_CONTRATO_PAF = " & COD_CONTRATO_PAF & _
                    " AND CF.SQ_NEGOCIACAO = " & SEQ_NEGOCIACAO & _
                    " AND CF.SQ_CONTRATO_FIXO = " & SEQ_CONTRATO_FIXO
        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            Msg_Mensagem("O Contrato fixo não se encontra na base de dados.")
            Fechar(True)
        End If

        If oData.Rows(0).Item("IC_STATUS") = "E" Then
            Msg_Mensagem("O contrato fixo foi eliminado.")
            Fechar(True)
        End If

        If oData.Rows(0).Item("IC_TAXA_DOLAR_VARIAVEL") = "N" Then
            Msg_Mensagem("Esse contrato fixo não apresenta dolar variável.")
            Fechar(True)
        End If
    End Sub

    Private Sub txtValorContrato_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValorContrato.ValueChanged
        If objDataTable_Vazio(oData) Then Exit Sub

        Dim VL_UnitarioFechado As Double
        Dim VL_Unitario As Double
        Dim VL_Total As Double

        VL_UnitarioFechado = (txtValorContrato.Value / (oData.Rows(0).Item("QT_KGS") - _
                                                        oData.Rows(0).Item("QT_CANCELADO"))) * _
                              oData.Rows(0).Item("QT_FATOR")
        txtTaxaDolar.Value = Math.Round(VL_UnitarioFechado / oData.Rows(0).Item("vl_unitario_us"), 4)

        VL_Unitario = oData.Rows(0).Item("VL_UNITARIO_US") * txtTaxaDolar.Value
        VL_Total = (oData.Rows(0).Item("QT_KGS") - _
                    oData.Rows(0).Item("QT_CANCELADO")) * (VL_Unitario / _
                                                           oData.Rows(0).Item("QT_FATOR"))

        If VL_Total > txtValorContrato.Value Then
            txtTaxaDolar.Value = txtTaxaDolar.Value - 0.0001
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Fechar(True)
    End Sub
End Class