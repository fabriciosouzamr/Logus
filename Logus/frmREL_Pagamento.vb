Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmREL_Pagamento
    Dim oRelatorio As New CrystalReportDocument
    Dim oData_Rel As New DataTable

    Private Sub frmREL_Pagamento_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Pagamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        SelecaoFormaPagamento.BancoDados_Tabela = "FORMA_PAGAMENTO"
        SelecaoFormaPagamento.BancoDados_Campo_Codigo = "CD_FORMA_PAGAMENTO"
        SelecaoFormaPagamento.BancoDados_Campo_Descricao = "NO_FORMA_PAGAMENTO"
        SelecaoFormaPagamento.BancoDados_Carregar()

        With Pesq_ContratoPAF
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_ContratoPAF
        End With

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        Me.WindowState = FormWindowState.Maximized
    End Sub

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

    Private Sub Imprimir()
        Dim SqlText As String
        Dim sFiltro As String = String.Empty

        If Not IsDate(txtDataInicial.Text) And Pesq_ContratoPAF.Codigo = 0 Then
            Msg_Mensagem("Favor informar a data inicial.")
            txtDataInicial.Focus()
            Exit Sub
        End If

        Try
            SqlText = "SELECT P.CD_FILIAL_ORIGEM," & _
                             "FIL.NO_FILIAL," & _
                             "F.NO_RAZAO_SOCIAL," & _
                             "P.DT_PAGAMENTO," & _
                             "P.DS_DESCRICAO," & _
                             "P.VL_PAGAMENTO," & _
                             "NVL(P.VL_DOLAR, 0) AS VL_DOLAR," & _
                             "NVL (P.VL_TAXA_DOLAR, 0) AS VL_TAXA_DOLAR," & _
                             "FP.NO_FORMA_PAGAMENTO" & _
                      " FROM SOF.PAGAMENTOS P," & _
                            "SOF.FORNECEDOR F," & _
                            "SOF.FILIAL FIL," & _
                            "SOF.FORMA_PAGAMENTO FP" & _
                      " WHERE P.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                        " AND P.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                        " AND P.CD_FORMA_PAGAMENTO = FP.CD_FORMA_PAGAMENTO"

            If IsDate(txtDataInicial.Text) Then
                SqlText = SqlText & " AND TRUNC(P.DT_PAGAMENTO) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
                sFiltro = sFiltro & " - Data Inicial: " & txtDataInicial.Text
            End If
            If IsDate(txtDataFinal.Text) Then
                SqlText = SqlText & " AND TRUNC(P.DT_PAGAMENTO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
                sFiltro = sFiltro & " - Data Final: " & txtDataFinal.Text
            End If
            If SelecaoFormaPagamento.Lista_Quantidade > 0 Then
                SqlText = SqlText & "  AND P.CD_FORMA_PAGAMENTO IN (" & SelecaoFormaPagamento.Lista_ID & ") "
                sFiltro = sFiltro & " - Forma de Pagamento: " & SelecaoFormaPagamento.Lista_Descricao
            End If
            If SelecaoFilial.Lista_Quantidade > 0 Then
                SqlText = SqlText & " AND P.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
                sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
            Else
                SqlText = SqlText & " AND P.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If
            If Pesq_Fornecedor.Codigo > 0 Then
                SqlText = SqlText & " AND P.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
                sFiltro = sFiltro & " - Fornecedor: " & Pesq_Fornecedor.Descricao
            End If
            If Pesq_ContratoPAF.Codigo > 0 Then
                SqlText = SqlText & " AND P.SQ_PAGAMENTO IN (SELECT DISTINCT SQ_PAGAMENTO" & _
                                                            " FROM (SELECT SQ_PAGAMENTO FROM SOF.CTRPAF_NEG_CTRFIX_MOV_DQ " & _
                                                                   " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                                                                   " UNION " & _
                                                                   "SELECT SQ_PAGAMENTO FROM SOF.PAGAMENTOS_JUROS_AUTO_CTR_FIX" & _
                                                                   " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                                                                   " UNION " & _
                                                                   "SELECT SQ_PAGAMENTO FROM SOF.PAGAMENTO_DESAGIO_AUTOMATICO" & _
                                                                   " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                                                                   " UNION " & _
                                                                   "SELECT SQ_PAGAMENTO FROM SOF.PAGAMENTO_JUROS_AUTOMATICO" & _
                                                                   " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                                                                   " UNION " & _
                                                                   "SELECT SQ_PAGAMENTO FROM SOF.PAG_CTR_PAF" & _
                                                                   " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & "))"
                sFiltro = sFiltro & " - Contrato: " & Pesq_ContratoPAF.Codigo
            End If

            If Trim(sFiltro) <> "" Then
                sFiltro = Trim(sFiltro)
                sFiltro = Microsoft.VisualBasic.Right(sFiltro, Len(sFiltro) - 1)
            End If

            If chkLiquidacao.Checked = False Then
                'FILTRO TUDO MENOS AS LIQUIDAÇOES QUE SÃO CODIGO 12
                SqlText = SqlText & " AND p.CD_FORMA_PAGAMENTO <> 12"
            End If

            oData_Rel = DBQuery(SqlText)

            oRelatorio.Load(Application.StartupPath & "\RPT_Pagamento.rpt")

            oRelatorio.SetDataSource(oData_Rel)
            oRelatorio.SetParameterValue("Filtro", sFiltro)
            oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

            crvMain.ReportSource = oRelatorio
        Catch ex As Exception
            Msg_Mensagem(ex.Message)
        End Try
    End Sub

    Private Sub frmREL_Pagamento_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub
End Class