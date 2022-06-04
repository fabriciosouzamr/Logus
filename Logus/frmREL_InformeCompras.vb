Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_InformeCompras
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_InformeCompras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_InformeCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        SqlText = "SELECT DISTINCT TO_CHAR (dt_contrato_fixo, 'yyyy') cd_ano, "
        SqlText = SqlText & "                TO_CHAR (dt_contrato_fixo, 'yyyy') no_ano "
        SqlText = SqlText & "           FROM sof.contrato_fixo  "
        SqlText = SqlText & "       ORDER BY TO_CHAR (dt_contrato_fixo, 'yyyy') DESC "

        DBCarregarComboBox(cboAno, SqlText, True)

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_InformeCompras_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""
        Dim mData As String

        If Not ComboBox_LinhaSelecionada(cboAno) Then
            Msg_Mensagem("Ano base invalido.")
            cboAno.Focus()
            Exit Sub
        End If

        If Pesq_Fornecedor.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um fornecedor valido.")
            Exit Sub
        End If

        SqlText = "SELECT m.no_cidade, m.cd_uf "
        SqlText = SqlText & "  FROM sof.filial fil, sof.municipio m, sof.fornecedor f "
        SqlText = SqlText & " WHERE fil.cd_filial IN (" & ListarIDFiliaisLiberadaUsuario() & ") "
        SqlText = SqlText & "   AND fil.cd_municipio = m.cd_municipio "
        SqlText = SqlText & "   AND fil.cd_filial = f.cd_filial_origem "
        SqlText = SqlText & "   AND F.cd_fornecedor = " & Pesq_Fornecedor.Codigo

        oData = DBQuery(SqlText)

        If oData.Rows.Count = 0 Then
            Msg_Mensagem("Houve algum problema com sua filial." & vbCrLf & _
                     "Favor contactar o administrador do sistema.")
            Exit Sub
        End If

        mData = oData.Rows(0).Item("no_cidade") & ", " & CDate(DataSistema()).Day & " de " & VerMes(DataSistema) & _
        " de " & Year(DataSistema)

        AVI_Carregar(Me)

        SqlText = "SELECT   forn.cd_fornecedor, forn.no_razao_social, forn.nu_cgc_cpf, "
        SqlText = SqlText & "         forn.mesano, NVL (SUM (ctr.qt_kgs - ctr.qt_cancelado), 0) AS tot_kg, "
        SqlText = SqlText & "         NVL (SUM (ctr.vl_total + ctr.vl_icms), 0) AS tot_vl, "
        SqlText = SqlText & "         NVL (SUM (ctr.vl_adendo + ctr.vl_adendo_icms), 0) AS tot_vl_adendo, "
        SqlText = SqlText & "         NVL (SUM (ctr.vl_adendo_inss), 0) AS tot_inss_adendo, "
        SqlText = SqlText & "         NVL (SUM (ctr.vl_inss), 0) AS tot_inss, forn.cd_filial_origem "
        SqlText = SqlText & "    FROM (SELECT f.cd_fornecedor, f.no_razao_social, f.nu_cgc_cpf, mes.mesano, "
        SqlText = SqlText & "                 f.cd_filial_origem "
        SqlText = SqlText & "            FROM sof.fornecedor f, "
        SqlText = SqlText & "                 (SELECT '01' mesano "
        SqlText = SqlText & "                    FROM DUAL "
        SqlText = SqlText & "                  UNION "
        SqlText = SqlText & "                  SELECT '02' mesano "
        SqlText = SqlText & "                    FROM DUAL "
        SqlText = SqlText & "                  UNION "
        SqlText = SqlText & "                  SELECT '03' mesano "
        SqlText = SqlText & "                    FROM DUAL "
        SqlText = SqlText & "                  UNION "
        SqlText = SqlText & "                  SELECT '04' mesano "
        SqlText = SqlText & "                    FROM DUAL "
        SqlText = SqlText & "                  UNION "
        SqlText = SqlText & "                  SELECT '05' mesano "
        SqlText = SqlText & "                    FROM DUAL "
        SqlText = SqlText & "                  UNION "
        SqlText = SqlText & "                  SELECT '06' mesano "
        SqlText = SqlText & "                    FROM DUAL "
        SqlText = SqlText & "                  UNION "
        SqlText = SqlText & "                  SELECT '07' mesano "
        SqlText = SqlText & "                    FROM DUAL "
        SqlText = SqlText & "                  UNION "
        SqlText = SqlText & "                  SELECT '08' mesano "
        SqlText = SqlText & "                    FROM DUAL "
        SqlText = SqlText & "                  UNION "
        SqlText = SqlText & "                  SELECT '09' mesano "
        SqlText = SqlText & "                    FROM DUAL "
        SqlText = SqlText & "                  UNION "
        SqlText = SqlText & "                  SELECT '10' mesano "
        SqlText = SqlText & "                    FROM DUAL "
        SqlText = SqlText & "                  UNION "
        SqlText = SqlText & "                  SELECT '11' mesano "
        SqlText = SqlText & "                    FROM DUAL "
        SqlText = SqlText & "                  UNION "
        SqlText = SqlText & "                  SELECT '12' mesano "
        SqlText = SqlText & "                    FROM DUAL) mes "
        SqlText = SqlText & "           WHERE f.cd_fornecedor = " & Pesq_Fornecedor.Codigo & ") forn, "
        SqlText = SqlText & "         (SELECT cp.cd_fornecedor, cf.dt_contrato_fixo, cf.ic_status, "
        SqlText = SqlText & "                 cf.qt_kgs, cf.qt_cancelado, cf.vl_total, cf.vl_icms, "
        SqlText = SqlText & "                 cf.vl_inss, cf.vl_adendo, cf.vl_adendo_icms, "
        SqlText = SqlText & "                 cf.vl_adendo_inss "
        SqlText = SqlText & "            FROM sof.contrato_fixo cf, sof.contrato_paf cp "
        SqlText = SqlText & "           WHERE cf.cd_contrato_paf = cp.cd_contrato_paf "
        SqlText = SqlText & "             AND cp.cd_fornecedor = " & Pesq_Fornecedor.Codigo
        SqlText = SqlText & "             AND cf.dt_contrato_fixo BETWEEN '01-JAN-" & cboAno.SelectedValue & "' AND '31-DEC-" & cboAno.SelectedValue & "' "
        SqlText = SqlText & "             AND cf.ic_status <> 'E') ctr "
        SqlText = SqlText & "   WHERE forn.cd_fornecedor = ctr.cd_fornecedor(+) "
        SqlText = SqlText & "         AND forn.mesano = TO_CHAR (ctr.dt_contrato_fixo(+), 'MM') "
        SqlText = SqlText & "GROUP BY forn.cd_fornecedor, "
        SqlText = SqlText & "         forn.no_razao_social, "
        SqlText = SqlText & "         forn.nu_cgc_cpf, "
        SqlText = SqlText & "         forn.mesano, "
        SqlText = SqlText & "         forn.cd_filial_origem "
        SqlText = SqlText & "ORDER BY forn.mesano "

        oData = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_Informe_Compras.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Data", mData)
        oRelatorio.SetParameterValue("Titulo", "Ano base: " & cboAno.SelectedValue)
        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub
End Class