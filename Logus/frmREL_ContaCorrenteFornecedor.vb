Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_ContaCorrenteFornecedor
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_ContaCorrenteFornecedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_ContaCorrenteFornecedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_ContaCorrenteFornecedor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""

        If Pesq_Fornecedor.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um fornecedor válido.")
            Exit Sub
        End If

        If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub

        AVI_Carregar(Me)

        optTipo.Value = "F"

        If optTipo.Value = "R" Then
            SqlText = "SELECT CD_REPASSADOR FROM SOF.FORNECEDOR WHERE CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
            oData = DBQuery(SqlText)

            If Not objDataTable_CampoVazio(oData.Rows(0).Item("CD_REPASSADOR")) Then
                Pesq_Fornecedor.Codigo = oData.Rows(0).Item("CD_REPASSADOR")
                optTipo.Value = "R"
            End If
        End If

        oData = Gera_RS_Cc_Forn(Pesq_Fornecedor.Codigo, _
                                txtDataInicial.Value, _
                                txtDataFinal.Value, _
                                True, _
                                IIf(optTipo.Value = "R", True, False))

        oRelatorio.Load(Application.StartupPath & "\RPT_Conta_Corrente_Fornecedor.rpt")
        oRelatorio.SetDataSource(oData)

        If optTipo.Value = "R" Then
            oRelatorio.SetParameterValue("Titulo", "Titular: " & Pesq_Fornecedor.Descricao)
        Else
            oRelatorio.SetParameterValue("Titulo", "Fornecedor: " & Pesq_Fornecedor.Descricao)
        End If

        sFiltro = "Período de " & txtDataInicial.Value & " e " & txtDataFinal.Value

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub
End Class