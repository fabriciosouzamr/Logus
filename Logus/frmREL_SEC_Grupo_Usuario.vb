Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmREL_SEC_Grupo_Usuario
    Dim oRelatorio As New CrystalReportDocument
    Dim oData_Rel As New DataTable

    Private Sub frmREL_SEC_Grupo_Usuario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_SEC_Grupo_Usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_SEC_GrupoAcesso(cboGrupoAcesso, True)
        ComboBox_Carregar_SEC_StatusAcesso(cboStatusAcesso)

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Imprimir()
        Dim SqlText As String
        Dim SqlText_Where As String = String.Empty
        Dim sFiltro As String = String.Empty

        Try
            SqlText = "SELECT DISTINCT UG.CD_USUARIO," & _
                                      "US.NO_USUARIO," & _
                                      "GA.NO_GRUPOACESSO," & _
                                      "TRUNC(DECODE(UG.DT_EXPIRACAO, NULL, GA.DT_EXPIRACAO_REAL," & _
                                                   "DECODE(GA.DT_EXPIRACAO_REAL, NULL, UG.DT_EXPIRACAO," & _
                                                          "DECODE(SIGN(GA.DT_EXPIRACAO_REAL - UG.DT_EXPIRACAO), 1," & _
                                                                 "UG.DT_EXPIRACAO, GA.DT_EXPIRACAO_REAL)))) DT_EXPIRACAO_REAL " & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_GRUPOACESSO UG," & _
                                 sBancoDados_OwnerCtrlAcesso & ".VW_SEC_GRUPOACESSO GA," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO US," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_SISTEMA SS" & _
                      " WHERE GA.SQ_GRUPOACESSO = UG.SQ_GRUPOACESSO" & _
                        " AND US.CD_USUARIO = UG.CD_USUARIO" & _
                        " AND SS.CD_USUARIO = US.CD_USUARIO" & _
                        " AND SS.CD_SISTEMA = " & cnt_Sistema_ControleAcesso

            If bBancoDados_CtrlAcesso_MultiSistema Then
                SqlText = SqlText & " AND UG.CD_SISTEMA = " & cnt_Sistema_ControleAcesso
            End If

            If Trim(txtCodigoUsuario.Text) <> "" Then
                SqlText_Where = SqlText_Where & "UG.CD_USUARIO = " & QuotedStr(Trim(txtCodigoUsuario.Text))

                sFiltro = "Código Usuário: " & Trim(Trim(txtCodigoUsuario.Text))
            End If
            If Trim(txtNomeUsuario.Text) <> "" Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " and "
                SqlText_Where = SqlText_Where & "US.NO_USUARIO = " & QuotedStr(Trim(txtNomeUsuario.Text))

                sFiltro = "Nome Usuário: " & Trim(Trim(txtNomeUsuario.Text))
            End If
            If ComboBox_LinhaSelecionada(cboGrupoAcesso) Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " and "
                SqlText_Where = SqlText_Where & " GA.SQ_GRUPOACESSO = " & cboGrupoAcesso.SelectedValue

                sFiltro = sFiltro & " - Grupo de Acesso: " & cboGrupoAcesso.SelectedItem(1)
            End If
            If cboStatusAcesso.SelectedIndex = 0 Or cboStatusAcesso.SelectedIndex = 1 Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " AND "
                SqlText_Where = SqlText_Where & " SS.IC_ATIVO = " & QuotedStr(cboStatusAcesso.SelectedValue)

                sFiltro = sFiltro & " - Ativo: " & IIf(cboStatusAcesso.SelectedValue = "S", "Sim", "Não")
            End If

            If Trim(sFiltro) <> "" Then
                sFiltro = Trim(sFiltro)
                sFiltro = Microsoft.VisualBasic.Right(sFiltro, Len(sFiltro) - 1)
            End If

            If Trim(SqlText_Where) <> "" Then
                SqlText = SqlText & " and " & SqlText_Where
            End If

            SqlText = SqlText & _
                      " ORDER BY US.NO_USUARIO," & _
                                "GA.NO_GRUPOACESSO"

            oData_Rel = DBQuery(SqlText)

            oRelatorio.Load(Application.StartupPath & "\RPT_SEC_Grupo_Usuario.rpt")

            oRelatorio.SetDataSource(oData_Rel)
            oRelatorio.SetParameterValue("Filtro", sFiltro)
            oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

            crvMain.ReportSource = oRelatorio
        Catch ex As Exception
            Msg_Mensagem(ex.Message)
        End Try
    End Sub

    Private Sub frmREL_SEC_Grupo_Usuario_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
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