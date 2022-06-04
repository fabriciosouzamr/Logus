Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmREL_SEC_Usuario
    Dim oRelatorio As New CrystalReportDocument
    Dim oRelatorioAreaAcesso As New ReportDocument

    Dim oData_Rel As New DataTable

    Private Sub frmREL_SEC_Usuario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_SEC_Usuario_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub frmREL_SEC_Usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Imprimir()
        Dim oData_FilialAcesso As New DataTable
        Dim oRow As DataRow
        Dim SqlText As String = ""
        Dim sFiltro As String = ""
        Dim bEsquerda As Boolean
        Dim Indice As Integer

        Try
            With oData_FilialAcesso.Columns
                .Add("CD_USUARIO")
                .Add("NO_FILIAL_01")
                .Add("NO_FILIAL_02")
            End With

            'Query filial acesso
            SqlText = "SELECT US.CD_USUARIO," & _
                             "FI.NO_FILIAL" & _
                      " FROM AGC.SEC_USUARIO US," & _
                            "AGC.SEC_USUARIO_SISTEMA SS," & _
                            "SOF.FILIAL_LIBERADA FL," & _
                            "SOF.FILIAL FI" & _
                      " WHERE SS.CD_USUARIO = US.CD_USUARIO" & _
                        " AND SS.CD_SISTEMA = " & cnt_Sistema_ControleAcesso & _
                        " AND FL.CD_USER = US.CD_USUARIO" & _
                        " AND FI.CD_FILIAL = FL.CD_FILIAL" & _
                      " ORDER BY US.CD_USUARIO, FI.NO_FILIAL"
            oData_Rel = DBQuery(SqlText)

            bEsquerda = True

            For Indice = 0 To oData_Rel.Rows.Count - 1
                If bEsquerda Then
                    oRow = oData_FilialAcesso.NewRow
                ElseIf objDataTable_LerCampo(oRow.Item(0), "") <> oData_Rel.Rows(Indice).Item("CD_USUARIO") Then
                    oData_FilialAcesso.Rows.Add(oRow)
                    oRow = oData_FilialAcesso.NewRow
                    bEsquerda = True
                End If

                oRow.Item(0) = oData_Rel.Rows(Indice).Item("CD_USUARIO")

                If bEsquerda Then
                    oRow.Item(1) = oData_Rel.Rows(Indice).Item("NO_FILIAL")
                Else
                    oRow.Item(2) = oData_Rel.Rows(Indice).Item("NO_FILIAL")
                End If

                bEsquerda = (Not bEsquerda)

                If bEsquerda Or (Indice = (oData_Rel.Rows.Count - 1)) Then
                    oData_FilialAcesso.Rows.Add(oRow)
                End If
            Next

            'Query usuário
            SqlText = "SELECT US.CD_USER CD_USUARIO," & _
                             "US.NO_USUARIO," & _
                             "US.DS_EMAIL," & _
                             "SS.DT_LIMITE_UTILIZACAO," & _
                             "US.IC_ATIVO," & _
                             "SU.IC_ATIVO IC_ATIVO_SMS" & _
                      " FROM SOF.USUARIO US," & _
                            "AGC.SEC_USUARIO SU," & _
                            "(SELECT *" & _
                             " FROM AGC.SEC_USUARIO_SISTEMA" & _
                             " WHERE CD_SISTEMA = " & cnt_Sistema_ControleAcesso & ") SS" & _
                      " WHERE SU.CD_USUARIO (+) = US.CD_USER" & _
                        " AND SU.CD_USUARIO (+) = SU.CD_USUARIO" & _
                      " ORDER BY US.NO_USUARIO"
            oData_Rel = DBQuery(SqlText)

            oRelatorio.Load(Application.StartupPath & "\RPT_SEC_Usuario.rpt")

            oRelatorio.SetDataSource(oData_Rel)
            oRelatorio.SetParameterValue("IC_EXIBIR_FILIALACESSO", IIf(chkListarSetoresLiberados.Checked, "S", "N"))
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