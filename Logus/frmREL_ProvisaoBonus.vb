Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_ProvisaoBonus
    Dim oRelatorio As New CrystalReportDocument

    Private Sub frmREL_ProvisaoBonus_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub
    Private Sub frmREL_ProvisaoBonus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Imprimir()
        If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub

        If txtTaxaDolar.Value = 0 Then
            Msg_Mensagem("Favor informar uma taxa de dolar")
            txtTaxaDolar.Focus()
            Exit Sub
        End If

        AVI_Carregar(Me)

        oRelatorio = Gera_Relatorio_PrevisaoBonus(txtTaxaDolar.Value, txtDataInicial.Text, txtDataFinal.Text, Pesq_Fornecedor.Codigo, _
                                                  SelecaoFilial.Lista_ID, optTipo.Value, optNivel.Value)

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub frmREL_ProvisaoBonus_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub
End Class