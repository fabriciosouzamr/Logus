Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmREL_SEC_Usuario_Acesso
    Dim oRelatorio As New CrystalReportDocument
    Dim oData_Rel As New DataTable

    Private Sub frmREL_SEC_Usuario_Acesso_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_SEC_Usuario_Acesso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_SEC_GrupoAcesso(cboGrupoAcesso, True)
        ComboBox_Carregar_SEC_TipoAcesso(cboTipoAcesso, True)
        ComboBox_Carregar_SEC_TipoAcao(cboTipoAcao)
        ComboBox_Carregar_SEC_GrupoMenu(cboGrupoMenu)
        ComboBox_Carregar_SEC_TipoOrigemAcesso(cboTipoOrigemAcesso)
        ComboBox_Carregar_SEC_StatusAcesso(cboStatusAcesso)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_SEC_Usuario_Acesso_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
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

    Private Sub cboGrupoMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGrupoMenu.SelectedIndexChanged
        cboAcesso.DataSource = Nothing

        If ComboBox_LinhaSelecionada(cboGrupoMenu) And cboGrupoMenu.SelectedItem(0) <> "-" Then
            Dim SqlText As String

            SqlText = "SELECT CD_AREAACESSO, NO_AREAACESSO" & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO" & _
                      " WHERE TP_GRUPO_ACESSO = " & QuotedStr(cboGrupoMenu.SelectedItem(0)) & _
                      " ORDER BY NO_AREAACESSO"

            DBCarregarComboBox(cboAcesso, SqlText, True)
        End If
    End Sub
    Private Sub Imprimir()
        Dim SqlText As String
        Dim SqlText_Where As String = String.Empty
        Dim sFiltro As String = String.Empty

        Try
            SqlText = "SELECT UA.CD_USUARIO," & _
                             "US.NO_USUARIO," & _
                             "UA.IC_ATIVO," & _
                             "UA.NO_AREAACESSO," & _
                             "UA.NO_TIPOACESSO," & _
                             "UA.NO_ORIGEM," & _
                             "UA.TP_AREAACESSO," & _
                             "UA.TIPO_ACESSO," & _
                             "NULL DT_EXPIRACAO," & _
                             SEC_GrupoMenu("", "UA.TP_GRUPO_ACESSO") & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".VW_SEC_USUARIOACESSO_GERAL UA," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO US," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_SISTEMA SS" & _
                      " WHERE US.CD_USUARIO = UA.CD_USUARIO" & _
                        " AND SS.CD_USUARIO = US.CD_USUARIO" & _
                        " AND SS.CD_SISTEMA = " & cnt_Sistema_ControleAcesso

            If bBancoDados_CtrlAcesso_MultiSistema Then
                SqlText = SqlText & " AND UA.CD_SISTEMA = " & cnt_Sistema_ControleAcesso
            End If

            If Trim(txtCodigoUsuario.Text) <> "" Then
                SqlText_Where = SqlText_Where & "US.CD_USUARIO = " & QuotedStr(Trim(txtCodigoUsuario.Text))

                sFiltro = "Código Usuário: " & Trim(Trim(txtCodigoUsuario.Text))
            End If

            If ComboBox_LinhaSelecionada(cboGrupoMenu) And cboGrupoMenu.SelectedItem(0) <> "-" Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " and "
                SqlText_Where = SqlText_Where & " UA.TP_GRUPO_ACESSO = " & QuotedStr(cboGrupoMenu.SelectedValue)

                sFiltro = sFiltro & " - Grupo de Menu: " & cboGrupoMenu.SelectedItem(1)
            End If
            If ComboBox_LinhaSelecionada(cboTipoAcesso) Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " and "
                SqlText_Where = SqlText_Where & "  UA.CD_TIPOACESSO = " & cboTipoAcesso.SelectedValue

                sFiltro = sFiltro & " - Tipo de Ação: " & cboTipoAcesso.SelectedItem(1)
            End If

            If ComboBox_LinhaSelecionada(cboTipoAcao) And cboTipoAcao.SelectedItem(0) <> "-" Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " and "
                SqlText_Where = SqlText_Where & " UA.TP_AREAACESSO = " & QuotedStr(cboTipoAcao.SelectedValue)

                sFiltro = sFiltro & " - Tipo de Acesso: " & cboTipoAcao.SelectedItem(1)
            End If

            If ComboBox_LinhaSelecionada(cboAcesso) Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " and "
                SqlText_Where = SqlText_Where & " UA.CD_AREAACESSO = " & cboAcesso.SelectedValue

                sFiltro = sFiltro & " - Acesso: " & cboAcesso.SelectedItem(1)
            End If

            If ComboBox_LinhaSelecionada(cboGrupoAcesso) Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " and "
                SqlText_Where = SqlText_Where & " UPPER(TRIM(UA.NO_ORIGEM)) = " & QuotedStr(UCase(Trim(cboGrupoAcesso.SelectedItem(1))))

                sFiltro = sFiltro & "- Grupo de Acesso: " & cboGrupoAcesso.SelectedItem(1)
            End If

            If ComboBox_LinhaSelecionada(cboTipoOrigemAcesso) And cboTipoOrigemAcesso.SelectedItem(0) <> "-" Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " and "
                SqlText_Where = SqlText_Where & " UA.TIPO_ACESSO = " & QuotedStr(cboTipoOrigemAcesso.SelectedValue)

                sFiltro = sFiltro & " - Tipo de Origem: " & cboTipoOrigemAcesso.SelectedItem(1)
            End If
      
            If cboStatusAcesso.SelectedIndex = 0 Or cboStatusAcesso.SelectedIndex = 1 Then
                If Trim(SqlText_Where) <> "" Then SqlText_Where = SqlText_Where & " and "
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
                                "UA.TP_GRUPO_ACESSO," & _
                                "UA.NO_AREAACESSO," & _
                                "UA.NO_ORIGEM," & _
                                "UA.NO_TIPOACESSO"
            oData_Rel = DBQuery(SqlText)

            oRelatorio.Load(Application.StartupPath & "\RPT_SEC_Usuario_Acesso.rpt")

            oRelatorio.SetDataSource(oData_Rel)
            oRelatorio.SetParameterValue("Filtro", sFiltro)
            oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

            crvMain.ReportSource = oRelatorio
        Catch ex As Exception
            Msg_Mensagem(ex.Message)
        End Try
    End Sub

    Private Sub txtCodigoUsuario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoUsuario.LostFocus
        Dim SqlText As String

        Dim oData As DataTable

        txtNomeUsuario.Text = ""
        txtCodigoUsuario.Text = UCase(txtCodigoUsuario.Text)

        SqlText = "SELECT NO_USUARIO FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO" & _
                  " WHERE CD_USUARIO = " & QuotedStr(txtCodigoUsuario.Text)
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            txtNomeUsuario.Text = oData.Rows(0).Item("NO_USUARIO")
        End If
    End Sub
End Class