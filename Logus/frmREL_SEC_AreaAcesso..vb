Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmREL_SEC_AreaAcesso
    Dim oRelatorio As New CrystalReportDocument
    Dim oData_Rel As New DataTable

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_SEC_AreaAcesso_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_SEC_AreaAcesso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_SEC_TipoAcesso(cboTipoAcesso, True)
        ComboBox_Carregar_SEC_TipoAcao(cboTipoAcao)
        ComboBox_Carregar_SEC_GrupoMenu(cboGrupoMenu)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_SEC_AreaAcesso_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Imprimir()
        Dim SqlText As String
        Dim SqlText_Where As String = String.Empty
        Dim sFiltro As String = String.Empty

        Try
            SqlText = "SELECT AAC.NO_AREAACESSO," & _
                             "AAC.TP_AREAACESSO," & _
                             SEC_GrupoMenu("", "AAC.TP_GRUPO_ACESSO") & "," & _
                             "AAC.DS_AREAACESSO," & _
                             "TAC.NO_TIPOACESSO " & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO AAC," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO_TIPOACESSO ATA," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_TIPOACESSO TAC" & _
                      " WHERE ATA.CD_AREAACESSO (+) = AAC.CD_AREAACESSO" & _
                        " AND TAC.CD_TIPOACESSO (+) = ATA.CD_TIPOACESSO"

            If bBancoDados_CtrlAcesso_MultiSistema Then
                SqlText = SqlText & " AND AAC.CD_SISTEMA = " & cnt_Sistema_ControleAcesso
            End If

            If ComboBox_LinhaSelecionada(cboGrupoMenu) And cboGrupoMenu.SelectedItem(0) <> "-" Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " and "
                SqlText_Where = SqlText_Where & " AAC.TP_GRUPO_ACESSO = " & QuotedStr(cboGrupoMenu.SelectedValue)

                sFiltro = sFiltro & " - Grupo de Menu: " & cboGrupoMenu.SelectedItem(1)
            End If
            If ComboBox_LinhaSelecionada(cboTipoAcesso) Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " and "
                SqlText_Where = SqlText_Where & " TAC.CD_TIPOACESSO = " & cboTipoAcesso.SelectedValue

                sFiltro = sFiltro & " - Tipo de Ação: " & cboTipoAcesso.SelectedItem(1)
            End If
            If ComboBox_LinhaSelecionada(cboTipoAcao) And cboTipoAcao.SelectedItem(0) <> "-" Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " and "
                SqlText_Where = SqlText_Where & " AAC.TP_AREAACESSO = " & QuotedStr(cboTipoAcao.SelectedValue)

                sFiltro = sFiltro & " - Tipo de Acesso: " & cboTipoAcao.SelectedItem(1)
            End If

            If Trim(sFiltro) <> "" Then
                sFiltro = Trim(sFiltro)
                sFiltro = Microsoft.VisualBasic.Right(sFiltro, Len(sFiltro) - 1)
            End If

            If Trim(SqlText_Where) <> "" Then
                SqlText = SqlText & " and " & SqlText_Where
            End If

            SqlText = SqlText & _
                      " ORDER BY AAC.TP_GRUPO_ACESSO," & _
                                "AAC.NO_AREAACESSO," & _
                                "TAC.NO_TIPOACESSO"
            oData_Rel = DBQuery(SqlText)

            oRelatorio.Load(Application.StartupPath & "\RPT_SEC_AreaAcesso.rpt")

            oRelatorio.SetDataSource(oData_Rel)
            oRelatorio.SetParameterValue("Filtro", sFiltro)
            oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

            crvMain.ReportSource = oRelatorio
        Catch ex As Exception
            Msg_Mensagem(ex.Message)
        End Try
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
End Class