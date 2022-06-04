Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_RD
    Public DataPesquisa As String
    Public TipoRD As Integer
    Public CodFilial As Integer
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_RD_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_RD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Tipo_RD(cboTipoRD, True)

        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        SelecaoFilial.Lista_Quantidade()

        ComboBox_Possicionar(cboTipoRD, TipoRD)
        SelecaoFilial.SelecionarFilial(CodFilial)

        If IsDate(DataPesquisa) Then
            txtData.Value = DataPesquisa
            Imprimir()
        Else
            txtData.Value = DataSistema()
        End If

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""

        If SelecaoFilial.Lista_Quantidade = 0 Then
            Msg_Mensagem("Favor selecionar uma filial.")
            SelecaoFilial.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoRD) Then
            Msg_Mensagem("Favor selecionar um tipo de RD.")
            cboTipoRD.Focus()
            Exit Sub
        End If
        If Not IsDate(txtData.Text) Then
            Msg_Mensagem("Informe a Data.")
            txtData.Focus()
            Exit Sub
        End If
        AVI_Carregar(Me)

            SqlText = "SELECT   SUM (rde.vl_dia) vl_dia, SUM (rde.qt_kg_dia) qt_kg_dia, "
            SqlText = SqlText & "         SUM (rde.vl_safra) vl_safra, SUM (rde.qt_kg_safra) qt_kg_safra, "
            SqlText = SqlText & "         TO_CHAR (rde.cd_tipo_rd) ic_tipo_rd, SUM (rde.vl_mensal) vl_mensal, "
            SqlText = SqlText & "         SUM (rde.qt_kg_mensal) qt_kg_mensal, "
            SqlText = SqlText & "         NVL (rde.ic_entrada_saida, 'Z') ic_entrada_saida, "
        SqlText = SqlText & "         tm.no_tipo_movimentacao, rde.cd_tipo_movimentacao, "

        If chkAgrupaFilial.Checked Then
            SqlText = SqlText & " 1 cd_filial, 'Todas' no_filial, "
        Else
            SqlText = SqlText & " f.cd_filial, f.no_filial, "
        End If

        SqlText = SqlText & "         t.no_tipo_rd, NVL (tr.vl_transito, 0) vl_transito, "
        SqlText = SqlText & "         NVL (tr.qt_transito, 0) qt_transito, "
        SqlText = SqlText & "         gru.no_parametro_modalidade , gru.nr_ordenacao_grupo, gru.cd_tipo_movimentacao , gru.nr_ordenacao "
        SqlText = SqlText & "    FROM sof.resumo_diario_estoque rde, "
        SqlText = SqlText & "         sof.tipo_movimentacao tm, "
        SqlText = SqlText & "         sof.filial f, "
        SqlText = SqlText & "         sof.tipo_rd t, "
        SqlText = SqlText & " (select p.no_parametro_modalidade , p.nr_ordenacao nr_ordenacao_grupo, t.cd_tipo_movimentacao , t.nr_ordenacao "
        SqlText = SqlText & "       from sof.parametro_modalidade p, sof.parametro_modalidade_tipo_mov t"
        SqlText = SqlText & "       where p.cd_parametro_modalidade = t.cd_parametro_modalidade "
        SqlText = SqlText & "       and p.cd_processo =22 and p.cd_status =2) gru, "
        SqlText = SqlText & "         (SELECT SUM (m.vl_nf) vl_transito, "
        SqlText = SqlText & "                 SUM (m.vl_nf_icms) vl_transito_icms, "
        SqlText = SqlText & "                 SUM (m.qt_kg_liquido_nf) qt_transito "
        SqlText = SqlText & "            FROM sof.transferencia t, "
        SqlText = SqlText & "                 sof.movimentacao m, "
        SqlText = SqlText & "                 sof.transferencia_modalidade tm "
        SqlText = SqlText & "           WHERE t.cd_filial_origem in (" & SelecaoFilial.Lista_ID & ")"
        SqlText = SqlText & "             AND t.sq_movimentacao_saida = m.sq_movimentacao "
        SqlText = SqlText & "             AND t.cd_transferencia_modalidade = tm.cd_transferencia_modalidade "
        SqlText = SqlText & "             AND tm.ic_possui_transito = 'S' "
        SqlText = SqlText & "             AND tm.ic_tipo_utilizacao NOT IN ('T')"
        SqlText = SqlText & "             AND tm.cd_tipo_movimentacao_saida = m.cd_tipo_movimentacao "
        SqlText = SqlText & "             AND ((" & QuotedStr(Date_to_Oracle(txtData.Text)) & " BETWEEN t.dt_transferencia "
        SqlText = SqlText & "             AND NVL(t.dt_chegada, TO_DATE (" & QuotedStr(Date_to_Oracle(DateAdd("d", 1, txtData.Value))) & ")))"
        SqlText = SqlText & "                  AND NVL (t.dt_chegada, TO_DATE (" & QuotedStr(Date_to_Oracle(DateAdd("d", 1, txtData.Value))) & ")) <> " & QuotedStr(Date_to_Oracle(txtData.Text))
        SqlText = SqlText & "                 )) tr "
        SqlText = SqlText & "   WHERE rde.cd_filial_origem = f.cd_filial "
        SqlText = SqlText & "     AND rde.cd_tipo_movimentacao = tm.cd_tipo_movimentacao "
        SqlText = SqlText & "     AND rde.cd_tipo_movimentacao = gru.cd_tipo_movimentacao (+) "
        SqlText = SqlText & "     AND rde.cd_tipo_rd = t.cd_tipo_rd "
        SqlText = SqlText & "     AND rde.dt_movimento = " & QuotedStr(Date_to_Oracle(txtData.Text))
        SqlText = SqlText & "     AND rde.ic_tipo_rd =  " & cboTipoRD.SelectedValue
        SqlText = SqlText & "     AND rde.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ") "
        SqlText = SqlText & "GROUP BY TO_CHAR (rde.cd_tipo_rd), "
        SqlText = SqlText & "         NVL (rde.ic_entrada_saida, 'Z'), "
        SqlText = SqlText & "         tm.no_tipo_movimentacao, "
        SqlText = SqlText & "         rde.cd_tipo_movimentacao, "
        SqlText = SqlText & "         t.no_tipo_rd, "
        SqlText = SqlText & "         NVL (tr.vl_transito, 0), "
        SqlText = SqlText & "         NVL (tr.qt_transito, 0), gru.no_parametro_modalidade , gru.nr_ordenacao_grupo, gru.cd_tipo_movimentacao , gru.nr_ordenacao  "

        If chkAgrupaFilial.Checked = False Then
            SqlText = SqlText & " ,f.cd_filial, f.no_filial "
        End If

        'exibe apenas os com valor
        SqlText = SqlText & "  HAVING SUM (rde.qt_kg_dia) <> 0 "
        SqlText = SqlText & "      OR SUM (rde.vl_dia) <> 0 "
        SqlText = SqlText & "      OR SUM (rde.qt_kg_mensal) <> 0 "
        SqlText = SqlText & "      OR SUM (rde.vl_mensal) <> 0 "
        SqlText = SqlText & "      OR SUM (rde.qt_kg_safra) <> 0 "
        SqlText = SqlText & "      OR SUM (rde.vl_safra) <> 0 "

        oRelatorio.Load(Application.StartupPath & "\RPT_RD_Geral.rpt")

        oData = DBQuery(SqlText)
        oRelatorio.SetDataSource(oData)

        sFiltro = "Data: " & txtData.Text & " - Filiais: " & SelecaoFilial.Lista_Descricao

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub frmREL_RD_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub
End Class