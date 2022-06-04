Public Class frmREL_ProvisaoNFComplementar
    Dim oRelatorio As New CrystalReportDocument
    Dim oDS As New Infragistics.Win.UltraWinDataSource.UltraDataSource

    Private Sub frmREL_ProvisaoNFComplementar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_ProvisaoNFComplementar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()
    End Sub

    Private Sub frmREL_ProvisaoNFComplementar_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub Imprimir()

        AVI_Carregar(Me)

        oRelatorio = Gera_Relatorio_ProvisaoNFComplementar(Pesq_Fornecedor.Codigo, SelecaoFilial.Lista_ID)

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub
End Class