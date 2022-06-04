Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_NotaRemessa
    Dim oRelatorio As New CrystalReportDocument

    Private Sub frmREL_NotaRemessa_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_NotaRemessa_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""


        AVI_Carregar(Me)

        SqlText = "SELECT RN.SQ_NF_REMESSA," & _
                       "RN.DT_NF_REMESSA," & _
                       "RN.NU_NF NU_NF_REMESSA," & _
                       "RN.NU_SERIE_NF NU_SERIE_NF_REMESSA," & _
                       "RN.QT_KG_NF QT_KG_NF_REMESSA," & _
                       "NVL(FN.NO_RAZAO_SOCIAL, FI.NO_FILIAL) NO_FORNECEDOR_FILIAL," & _
                       "TN.CD_TIPO_NF NO_TIPO_NF," & _
                       "TM.NO_TIPO_MOVIMENTACAO," & _
                       "MV.DT_MOVIMENTACAO," & _
                       "MV.NU_NF," & _
                       "MV.QT_KG_NF," & _
                       "MV.VL_NF," & _
                       "MV.QT_KG_LIQUIDO_NF " & _
                " FROM SOF.NF_REMESSA RN," & _
                      "SOF.NF_REMESSA_MOVIMENTACAO RM," & _
                      "SOF.MOVIMENTACAO MV," & _
                      "SOF.TIPO_MOVIMENTACAO TM," & _
                      "SOF.TIPO_NF TN," & _
                      "SOF.FORNECEDOR FN," & _
                      "SOF.TRANSFERENCIA TF," & _
                      "SOF.FILIAL FI" & _
                " WHERE RM.SQ_NF_REMESSA = RN.SQ_NF_REMESSA" & _
                  " AND MV.SQ_MOVIMENTACAO = RM.SQ_MOVIMENTACAO"

        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(RN.DT_NF_REMESSA) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(RN.DT_NF_REMESSA) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        sFiltro = "Período: " & txtDataInicial.Text & " à " & txtDataFinal.Text

        If Trim(txtNFRemessa.Text) <> "" Then
            SqlText = SqlText & " AND RN.NU_NF = " & QuotedStr(txtNFRemessa.Text)
            sFiltro = sFiltro & " - Nº da N.F. de Remessa: " & txtNFRemessa.Text
        End If
        If Trim(txtNFMovimentacao.Text) <> "" Then
            SqlText = SqlText & " AND RN.SQ_NF_REMESSA IN (SELECT RM.SQ_NF_REMESSA" & _
                                                          " FROM SOF.MOVIMENTACAO MV," & _
                                                                "SOF.NF_REMESSA_MOVIMENTACAO RM" & _
                                                          " WHERE MV.NU_NF = " & QuotedStr(txtNFMovimentacao.Text) & _
                                                            " AND RM.SQ_MOVIMENTACAO = MV.SQ_MOVIMENTACAO)"
            sFiltro = sFiltro & " - Nº da N.F. da Movimentação: " & txtNFMovimentacao.Text
        End If

        SqlText = SqlText & _
                    " AND TM.CD_TIPO_MOVIMENTACAO (+) = MV.CD_TIPO_MOVIMENTACAO" & _
                    " AND TN.CD_TIPO_NF (+) = MV.CD_TIPO_NF" & _
                    " AND FN.CD_FORNECEDOR (+) = MV.CD_FORNECEDOR" & _
                    " AND TF.SQ_MOVIMENTACAO_SAIDA (+) = MV.SQ_MOVIMENTACAO" & _
                    " AND FI.CD_FILIAL (+) = TF.CD_FILIAL_ORIGEM"

        SqlText = SqlText & " order by RN.DT_NF_REMESSA "

        oData = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_NotaRemessa.rpt")
        oRelatorio.SetDataSource(oData)


        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

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


    Private Sub frmREL_NotaRemessa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class