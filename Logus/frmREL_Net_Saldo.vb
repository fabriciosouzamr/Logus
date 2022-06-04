Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Net_Saldo
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Pega_Valores()
        Dim DT_COTACAO As Date
        Dim TX_DOLAR As Double
        Dim VL_BOLSA As Double
        Dim VL_ARROBA As Double

        Relatorio_PegaValor(DT_COTACAO, TX_DOLAR, VL_BOLSA, VL_ARROBA)

        txtDolar.Value = TX_DOLAR
        txtBolsa.Value = VL_BOLSA
        txtValorArroba.Value = VL_ARROBA
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Pega_Valores()
    End Sub

    Private Sub frmREL_Net_Saldo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Net_Saldo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pega_Valores()

        With SelecaoSafra
            .BancoDados_Tabela = "SOF.SAFRA"
            .BancoDados_Campo_Codigo = "CD_SAFRA"
            .BancoDados_Campo_Descricao = "DS_SAFRA"
            .BancoDados_Carregar()
        End With

        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        With SelecaoModalidadeCredito
            .BancoDados_Tabela = "SOF.CONFISSAO_DIVIDA_MODALIDADE"
            .BancoDados_Campo_Codigo = "CD_CONFISSAO_DIVIDA_MODALIDADE"
            .BancoDados_Campo_Descricao = "NO_CONFISSAO_DIVIDA_MODALIDADE"
            .BancoDados_Carregar()
        End With

        Pega_Valores()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        If Not txtDolar.Value > 0 Then
            Msg_Mensagem("Favor informar uma taxa de dolar.")
            Exit Sub
        End If
        If Not txtBolsa.Value > 0 Then
            Msg_Mensagem("Favor informar um valor da bolsa.")
            Exit Sub
        End If
        If Not txtValorArroba.Value > 0 Then
            Msg_Mensagem("Favor informar um valor médio do dia.")
            Exit Sub
        End If

        oRelatorio = Gera_Relatorio_NetSaldo(txtBolsa.Value, txtDolar.Value, txtValorArroba.Value, _
                                             SelecaoSafra.Lista_ID, _
                                             SelecaoFilial.Lista_ID, _
                                             SelecaoModalidadeCredito.Lista_ID, _
                                             chkSomenteNegativos.Checked, _
                                             optTipo.Value, _
                                             chkOrdemCrescente.Checked)

        crvMain.ReportSource = oRelatorio
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        If optTipo.Value = "SI" Then
            chkOrdemCrescente.Enabled = False
            chkSomenteNegativos.Checked = True
            chkSomenteNegativos.Enabled = False
        Else
            chkOrdemCrescente.Enabled = True
            chkSomenteNegativos.Enabled = True
        End If
    End Sub

    Private Sub frmREL_Net_Saldo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub
End Class