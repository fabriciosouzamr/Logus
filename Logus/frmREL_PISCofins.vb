Public Class frmREL_PISCofins
    Dim oRelatorio As New CrystalReportDocument
    Dim oData_Rel As New DataTable

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_PISCofins_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_PISCofins_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        SelecaoFornecedor.BancoDados_Tabela = "FORNECEDOR"
        SelecaoFornecedor.BancoDados_Campo_Codigo = "CD_FORNECEDOR"
        SelecaoFornecedor.BancoDados_Campo_Descricao = "NO_RAZAO_SOCIAL"
        SelecaoFornecedor.MultiplaSelecao = True

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_PISCofins_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub Imprimir()
        Dim oData_Rel As DataTable
        Dim SqlText As String
        Dim SqlText_Aplic As String = ""

        If Not Data_ValidarPeriodo("de fixação", txtDataInicial.Text, txtDataFinal.Text, True) Then Exit Sub

        If IsDate(txtDataInicial.Text) Then
            Str_Adicionar(SqlText_Aplic, " DT_FIXACAO >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)), " AND ")
        End If
        If IsDate(txtDataFinal.Text) Then
            Str_Adicionar(SqlText_Aplic, " DT_FIXACAO <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)), " AND ")
        End If

        SqlText = "SELECT MV.SQ_MOVIMENTACAO," & _
                         "FL.NO_FILIAL," & _
                         "FN.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "FN.IC_FISICA_JURIDICA TP_PESSOA," & _
                         "MV.NU_NF NF," & _
                         "MV.QT_KG_LIQUIDO_NF QUANTIDADE," & _
                         "MV.VL_NF VALOR," & _
                         "CM.DT_FIXACAO DT_APLICACAO," & _
                         "TO_CHAR(CM.CD_CONTRATO_PAF) || '-' || TO_CHAR(CM.SQ_NEGOCIACAO) || '-' || TO_CHAR(CM.SQ_CONTRATO_FIXO) CD_CTR_APLICACAO," & _
                         "CM.QT_KG_FIXO QT_KG_APLICACAO," & _
                         "CM.VL_FIXO VL_APLICACAO," & _
                         "NVL(SOF.FC_INDICE_VALORES(FN.CD_TIPO_PESSOA, CM.DT_FIXACAO, " & cnt_Processo_PIS & "), 0) PC_ALIQ_PIS," & _
                         "NVL(SOF.FC_INDICE_VALORES(FN.CD_TIPO_PESSOA, CM.DT_FIXACAO, " & cnt_Processo_Confis & "), 0) PC_ALIQ_COFINS" & _
                  " FROM (SELECT MV.SQ_MOVIMENTACAO" & _
                         " FROM (SELECT DISTINCT SQ_MOVIMENTACAO " & _
                                " FROM SOF.CTR_PAF_NEG_CTR_FIX_MOV" & _
                                " WHERE " & SqlText_Aplic & ") AP," & _
                               "SOF.MOVIMENTACAO MV," & _
                               "SOF.CTR_PAF_NEG_CTR_FIX_MOV CF" & _
                         " WHERE MV.SQ_MOVIMENTACAO = AP.SQ_MOVIMENTACAO" & _
                           " AND CF.SQ_MOVIMENTACAO = AP.SQ_MOVIMENTACAO" & _
                         " GROUP BY MV.SQ_MOVIMENTACAO, MV.VL_A_FIXAR, MV.QT_KG_A_FIXAR" & _
                         " HAVING MV.VL_A_FIXAR <> SUM(CF.VL_FIXO)" & _
                            " AND MV.QT_KG_A_FIXAR = SUM(CF.QT_KG_FIXO)) ANL," & _
                        "SOF.MOVIMENTACAO MV," & _
                        "SOF.FILIAL FL," & _
                        "SOF.FORNECEDOR FN," & _
                        "SOF.CTR_PAF_NEG_CTR_FIX_MOV CM" & _
                  " WHERE MV.SQ_MOVIMENTACAO = ANL.SQ_MOVIMENTACAO" & _
                    " AND FL.CD_FILIAL = MV.CD_FILIAL_ORIGEM" & _
                    " AND FN.CD_FORNECEDOR = MV.CD_FORNECEDOR" & _
                    " AND CM.SQ_MOVIMENTACAO = MV.SQ_MOVIMENTACAO"

        If SelecaoFornecedor.Lista_Quantidade > 0 Then
            SqlText = SqlText & _
                    " AND MV.CD_FORNECEDOR IN (" & SelecaoFornecedor.Lista_ID & ")"
        End If
        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & _
                    " AND CM.CD_FILIAL IN (" & SelecaoFilial.Lista_ID & ")"
        End If

        Try
            oData_Rel = DBQuery(SqlText)

            oRelatorio.Load(Application.StartupPath & "\RPT_PISCofins.rpt")
            oRelatorio.SetDataSource(oData_Rel)
            oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

            crvMain.ReportSource = oRelatorio
        Catch ex As Exception
            Msg_Mensagem(ex.Message)
        End Try
    End Sub
End Class