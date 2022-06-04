Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_MovBancaria_ExtratoBancario
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub frmREL_MovBancaria_ExtratoBancario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_MovBancaria_ExtratoBancario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Conta_Bancaria(cboContaBancaria)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Dim oData As DataTable
        Dim SqlText As String
        Dim VL_SALDO As Double
        Dim sFiltro As String

        If Not ComboBox_LinhaSelecionada(cboContaBancaria) Then
            Msg_Mensagem("Favor informa uma conta corrente.")
            Exit Sub
        End If

        If Not Data_ValidarPeriodo("de movimentação", txtDataInicial.Value, txtDataFinal.Value, True) Then
            Exit Sub
        End If

        SqlText = "SELECT MB.DT_MOVIMENTACAO," & _
                         "MB.NU_CHEQUE," & _
                         "OB.NO_OPERACAO," & _
                         "IMB.DS_DESCRICAO," & _
                         "IMB.VL_PAGO," & _
                         "MB.IC_DEBITO_CREDITO," & _
                         "MB.SQ_MOV_BANCARIO," & _
                         "MB.CD_BANCO," & _
                         "B.NO_BANCO," & _
                         "P.CD_FILIAL_PAGADORA," & _
                         "IMB.SQ_ITEM_MOV_BANCARIO," & _
                         "IMBP.VL_PROVISAO," & _
                         "PROV.NO_PROVISAO," & _
                         "MB.VL_BRUTO VL_CHEQUE," & _
                         "IMB.VL_LIQUIDO VL_ITEM_CHEQUE" & _
                  " FROM SOF.PAGAMENTOS P," & _
                        "SOF.OPERACAO_BANCARIA OB," & _
                        "SOF.BANCO B," & _
                        "SOF.ITEM_MOV_BANCARIO_PROVISAO IMBP," & _
                        "SOF.PROVISAO PROV," & _
                        "SOF.MOV_BANCARIO MB," & _
                        "SOF.ITEM_MOV_BANCARIO IMB" & _
                  " WHERE IMB.SQ_MOV_BANCARIO = MB.SQ_MOV_BANCARIO" & _
                    " AND IMB.CD_OPERACAO_BANCARIA = OB.CD_OPERACAO_BANCARIA" & _
                    " AND MB.CD_BANCO = B.CD_BANCO" & _
                    " AND P.SQ_ITEM_MOV_BANCARIO(+) = IMB.SQ_ITEM_MOV_BANCARIO" & _
                    " AND IMBP.SQ_ITEM_MOV_BANCARIO(+) = IMB.SQ_ITEM_MOV_BANCARIO" & _
                    " AND IMBP.CD_PROVISAO = PROV.CD_PROVISAO(+)" & _
                    " AND MB.DT_MOVIMENTACAO BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & _
                                               " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & _
                    " AND MB.CD_BANCO = " & cboContaBancaria.SelectedValue

        AVI_Carregar(Me)
        oData = DBQuery(SqlText)
        AVI_Fechar(Me)

        If objDataTable_Vazio(oData) Then
            oData.Dispose()
            Msg_Mensagem("Não existe movimentação nesta conta bancaria neste periodo.")
            Exit Sub
        End If

        SqlText = "SELECT NVL(SUM(DECODE(IC_DEBITO_CREDITO, 'C', VL_BRUTO, -1 * VL_BRUTO)), 0) VL_SALDO" & _
          " FROM SOF.MOV_BANCARIO" & _
          " WHERE CD_BANCO = " & oData.Rows(0).Item("CD_BANCO") & _
            " AND DT_MOVIMENTACAO <= " & QuotedStr(Date_to_Oracle(DateAdd("D", -1, txtDataInicial.Value)))
        VL_SALDO = DBQuery_ValorUnico(SqlText)

        sFiltro = "Período de " & txtDataInicial.Value & " até " & txtDataFinal.Value

        oRelatorio.Load(Application.StartupPath & "\RPT_Movb_Extrato.rpt")
        oRelatorio.SetDataSource(oData)

        oRelatorio.SetParameterValue("Saldo_Inicial", VL_SALDO)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        crvMain.ReportSource = oRelatorio
    End Sub

    Private Sub frmREL_MovBancaria_ExtratoBancario_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub
End Class