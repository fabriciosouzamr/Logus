Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_ResumoOperacoes
    Dim oRelatorio As New CrystalReportDocument

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""

        If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub

        AVI_Carregar(Me)

        Select Case optPagRec.Value
            Case "R"
                SqlText = "SELECT nu_conta_contabil, vl_movimento, ds_movimento, cd_filial, cd_operacao, "
                SqlText = SqlText & "       cd_sub_ledger, cd_tipo_sub_ledger, dt_movimento, m.nu_nf "
                SqlText = SqlText & "  FROM sof.interface_jde i, sof.movimentacao m "
                SqlText = SqlText & " WHERE cd_tipo_interface_jde = 1 AND i.sq_movimentacao = m.sq_movimentacao (+) AND "
                SqlText = SqlText & " dt_movimento between '" & Date_to_Oracle(txtDataInicial.Text) & _
                                    "' and '" & Date_to_Oracle(txtDataFinal.Text) & "'"

                If Trim(txtContaContabil.Text) <> "" Then
                    SqlText = SqlText & " and nu_conta_contabil like '%" & txtContaContabil.Text & "%'"
                End If

                If Trim(txtNotaFiscal.Text) <> "" Then
                    SqlText = SqlText & " and m.nu_nf = '" & txtNotaFiscal.Text & "'"
                End If
            Case "P"

                SqlText = "select nu_conta_contabil, vl_movimento, ds_movimento," & _
                          "cd_filial, CD_OPERACAO, null as cd_sub_ledger, null as cd_tipo_sub_ledger,DT_MOVIMENTO, null nu_nf " & _
                          "From SOF.interface_jde " & _
                          "where cd_tipo_interface_jde=2 and "
                SqlText = SqlText & " dt_movimento between '" & Date_to_Oracle(txtDataInicial.Text) & _
                                                 "' and '" & Date_to_Oracle(txtDataFinal.Text) & "'"

                If txtContaContabil.Text <> "" Then
                    SqlText = SqlText & " and nu_conta_contabil like '%" & txtContaContabil.Text & "%'"
                End If
        End Select

        oData = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_Resumo_Operacoes.rpt")
        oRelatorio.SetDataSource(oData)

        sFiltro = "Período de " & txtDataInicial.Value & " e " & txtDataFinal.Value

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        oRelatorio.SetParameterValue("Pag/Rec", optPagRec.Value)
        oRelatorio.SetParameterValue("Ana/Sit", optTipo.Value)
        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub frmREL_ResumoOperacoes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_ResumoOperacoes_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

 
    Private Sub frmREL_ResumoOperacoes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub optPagRec_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPagRec.ValueChanged
        If optPagRec.Value = "R" Then
            txtNotaFiscal.Visible = False
            lblR_NF.Visible = False
        Else
            txtNotaFiscal.Visible = True
            lblR_NF.Visible = True
        End If
    End Sub
End Class