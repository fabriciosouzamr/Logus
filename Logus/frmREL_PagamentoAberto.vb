Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_PagamentoAberto
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Dim oForm As New frmAvi
        oForm.StartPosition = FormStartPosition.CenterScreen
        oForm.BackColor = System.Drawing.Color.FromArgb(CType(230, Byte), CType(238, Byte), CType(249, Byte))
        oForm.ShowInTaskbar = False
        oForm.Show()

        Imprimir()

        oForm.Close()
    End Sub

    Private Sub frmREL_PagamentoAberto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_PagamentoAberto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_PagamentoAberto_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Imprimir()
        AVI_Carregar(Me)

        oRelatorio = Gera_Relatorio_PagamentoEmAberto(SelecaoFilial.Lista_ID, Pesq_Fornecedor.Codigo, chkAbertoContratoPAF.Checked, chkAbertoNegociacao.Checked, _
                                                      chkAgrupaFornecedor.Checked, chkSemContrato.Checked, (optTipo.Value = "S"))

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        If optTipo.Value = "S" Then
            chkAgrupaFornecedor.Enabled = False
            chkAgrupaFornecedor.Checked = True
        Else
            chkAgrupaFornecedor.Enabled = True
            chkAgrupaFornecedor.Checked = False
        End If
    End Sub
End Class