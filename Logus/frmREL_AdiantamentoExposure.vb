Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_AdiantamentoExposure
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Imprimir()

        Select Case optTipo.Value
            Case "ACC", "ASC"
                If Not txtDolar.Value > 0 Then
                    Msg_Mensagem("Favor informar uma taxa de dolar.")
                    txtDolar.Focus()
                    Exit Sub
                End If
                If Not txtBolsa.Value > 0 Then
                    Msg_Mensagem("Favor informar um valor da bolsa.")
                    txtBolsa.Focus()
                    Exit Sub
                End If
                If Not txtValorArroba.Value > 0 Then
                    Msg_Mensagem("Favor informar um valor medio do dia.")
                    txtValorArroba.Focus()
                    Exit Sub
                End If
            Case "S"
                If txtDolar.Value = 0 Then
                    Msg_Mensagem("Favor informar uma taxa de dolar.")
                    txtDolar.Focus()
                    Exit Sub
                End If
        End Select

        AVI_Carregar(Me)

        oRelatorio = Gera_Relatorio_AdiantamentoExposure(IIf(optTipo.Value = "S", PosForn_FiltroExposure.feSintetico, _
                                                                                  IIf(optTipo.Value = "ACC", PosForn_FiltroExposure.feSoAdiantamentosContratosBase, _
                                                                                                             PosForn_FiltroExposure.feSoAdiantamentoSemContratosBase)), _
                                                         txtBolsa.Value, txtDolar.Value, txtValorArroba.Value)

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub frmREL_AdiantamentoExposure_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_AdiantamentoExposure_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub frmREL_AdiantamentoExposure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Tipo_Validar()
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        PegarValores()
    End Sub

    Private Sub PegarValores()
        Dim DT_COTACAO As Date
        Dim TX_DOLAR As Double
        Dim VL_BOLSA As Double
        Dim VL_ARROBA As Double

        Relatorio_PegaValor(DT_COTACAO, TX_DOLAR, VL_BOLSA, VL_ARROBA)

        txtDolar.Value = TX_DOLAR
        txtBolsa.Value = VL_BOLSA
        txtValorArroba.Value = VL_ARROBA
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        Tipo_Validar()
    End Sub

    Private Sub Tipo_Validar()
        If optTipo.Value = "S" Then
            txtBolsa.Value = 0
            txtValorArroba.Value = 0
        Else
            PegarValores()
        End If

        lblR_Bolsa.Enabled = (optTipo.Value <> "S")
        txtBolsa.Enabled = (optTipo.Value <> "S")
        lblR_ValorArroba.Enabled = (optTipo.Value <> "S")
        txtValorArroba.Enabled = (optTipo.Value <> "S")
    End Sub
End Class