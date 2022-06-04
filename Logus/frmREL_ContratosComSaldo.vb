Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_ContratosComSaldo
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_ContratosComSaldo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_ContratosComSaldo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        ComboBox_Carregar_Tipo_Cacau(cboTipoCacau, True)

        If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_EmitirRelatorioContratoComSaldoINSS) Then
            chkComIncidenciaINSS.Visible = False
            chkComIncidenciaINSS.Checked = True
        End If

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_ContratosComSaldo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub Imprimir()
        If txtTaxaDolar.Value = 0 Then
            Msg_Mensagem("Favor informar a taxa do dolar")
            txtTaxaDolar.Focus()
            Exit Sub
        End If

        AVI_Carregar(Me)

        crvMain.ReportSource = Gera_Relatorio_ContratoComSaldo(chkComIncidenciaINSS.Checked, _
                                                               txtTaxaDolar.Value, _
                                                               SelecaoFilial.Lista_ID, _
                                                               NVL(cboTipoCacau.SelectedValue, 0), _
                                                               Pesq_Fornecedor.Codigo)

        AVI_Fechar(Me)
    End Sub
End Class