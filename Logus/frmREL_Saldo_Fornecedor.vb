Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Saldo_Fornecedor
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_Saldo_Fornecedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Saldo_Fornecedor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Imprimir()
        If Trim(txtTaxaDolar.Value) = 0 Then
            Msg_Mensagem("Favor informar a taxa do dólar.")
            txtTaxaDolar.Focus()
            Exit Sub
        End If
        If Not IsDate(txtDataBase.Value) Then
            Msg_Mensagem("Favor informar a data base.")
            txtDataBase.Focus()
            Exit Sub
        End If

        AVI_Carregar(Me)

        oRelatorio = Gera_Relatorio_SaldoFornecedor(txtDataBase.Text, txtTaxaDolar.Value, txtBolsa.Value, txtValorDif.Value)
       
        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub frmREL_Saldo_Fornecedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pega_Valores()

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Pega_Valores()
    End Sub

    Private Sub Pega_Valores()
        Dim SqlText As String
        Dim DT_Cotacao As Date
        Dim VL_Bolsa As Double
        Dim VL_Dolar As Double
        Dim VL_ValorArroba As Double

        Relatorio_PegaValor(DT_Cotacao, VL_Dolar, VL_Bolsa, VL_ValorArroba)

        txtTaxaDolar.Value = VL_Dolar
        txtBolsa.Value = VL_Bolsa

        SqlText = "SELECT *" & _
                  " FROM (SELECT BP.VL_DIFERENCIAL FROM SOF.BOLSA_PERIODO BP" & _
                         " WHERE BP.IC_MOEDA = 'N'" & _
                         " AND BP.IC_EXIBE = 'S' " & _
                         " ORDER BY BP.SQ_BOLSA_PERIODO_MATRIZ ASC, NU_SEQUENCIA)" & _
                  " WHERE ROWNUM = 1"
        txtValorDif.Value = DBQuery_ValorUnico(SqlText, 0)
    End Sub
End Class