Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Fluxo_Caixa
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub frmREL_Fluxo_Caixa_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Fluxo_Caixa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Imprimir()
        Dim DT_Cotacao As Date
        Dim VL_Bolsa As Double
        Dim VL_Dolar As Double
        Dim VL_ValorArroba As Double

        If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub

        AVI_Carregar(Me)

        '>> Carregar as valores usados na consulta de Cacau a Ordem - Início
        Relatorio_PegaValor(DT_Cotacao, VL_Dolar, VL_Bolsa, VL_ValorArroba)

        oRelatorio = Gera_Relatorio_FluxoCaixa(txtDataInicial.Text, txtDataFinal.Text, VL_Dolar, VL_Bolsa, VL_ValorArroba, SelecaoFilial.Lista_ID, (optTipo.Value = "S"))

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub frmREL_Fluxo_Caixa_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub
End Class