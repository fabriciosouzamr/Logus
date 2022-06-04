Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Resumo_Estoque
    Public Enum RGFP_TipoRelatorio
        ResumoEstoque = 1
        EstoqueArmazem = 2
        EstoqueCacau = 3
    End Enum

    Public oTipoRelatorio As RGFP_TipoRelatorio
    Dim oRelatorio As New CrystalReportDocument

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

    Private Sub frmREL_Resumo_Estoque_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Resumo_Estoque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        ComboBox_Carregar_Armazem(cboArmazem, , True, True, , , True)

        SqlText = "(select CD_PROCEDENCIA, CD_PROCEDENCIA as NO_PROCEDENCIA from SOF.PROCEDENCIA)"

        SelecaoProcedencia.BancoDados_Tabela = SqlText
        SelecaoProcedencia.BancoDados_Campo_Codigo = "CD_PROCEDENCIA"
        SelecaoProcedencia.BancoDados_Campo_Descricao = "NO_PROCEDENCIA"
        SelecaoProcedencia.BancoDados_Carregar()

        ComboBox_Carregar_Qualidade(cboTipoCacau, True)

        Select Case oTipoRelatorio
            Case RGFP_TipoRelatorio.ResumoEstoque
                grpPeriodo.Visible = False
                cboPilha.Visible = False
                lblPilha.Visible = False
                cboTipoCacau.Visible = False
                lblTipoCacau.Visible = False
                grpOpcoes.Visible = False
            Case RGFP_TipoRelatorio.EstoqueArmazem
                grpGrupo.Visible = False
                lblTipoCacau.Left = grpGrupo.Left
                cboTipoCacau.Left = grpGrupo.Left
                grpOpcoes.Visible = False
            Case RGFP_TipoRelatorio.EstoqueCacau
                grpPeriodo.Visible = False
                cboPilha.Visible = False
                lblPilha.Visible = False
                cboTipoCacau.Visible = False
                lblTipoCacau.Visible = False
                grpGrupo.Visible = False
                grpOpcoes.Visible = True
                grpOpcoes.Left = grpGrupo.Left
                grpOpcoes.Top = grpGrupo.Top
                crvMain.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        End Select

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Imprimir()
        Dim oRelatorio_Sub1 As New ReportDocument

        AVI_Carregar(Me)

        Select Case oTipoRelatorio
            Case RGFP_TipoRelatorio.ResumoEstoque
                oRelatorio = Gera_Relatorio_ResumoEstoque(SelecaoFilial.Lista_ID, _
                                                          SelecaoProcedencia.Lista_ID, _
                                                          NVL(cboArmazem.SelectedValue, -1), _
                                                          chkAgupaOrigem.Checked, _
                                                          chkAgrupaArmazem.Checked, _
                                                          chkAgrupaPilha.Checked, _
                                                          chkAgrupaProcedencia.Checked)
            Case RGFP_TipoRelatorio.EstoqueArmazem
                oRelatorio = Gera_Relatorio_EstoqueArmazem(SelecaoFilial.Lista_ID, _
                                                           SelecaoProcedencia.Lista_ID, _
                                                           NVL(cboArmazem.SelectedValue, -1), _
                                                           NVL(cboPilha.SelectedValue, -1), _
                                                           txtDataInicial.Text, _
                                                           txtDataFinal.Text, _
                                                           NVL(cboTipoCacau.SelectedValue, -1))
            Case RGFP_TipoRelatorio.EstoqueCacau
                oRelatorio = Gera_Relatorio_EstoqueCacau(SelecaoFilial.Lista_ID, _
                                                         NVL(cboArmazem.SelectedValue, 0), _
                                                         (optUnidade.Value = "S"), _
                                                         (optProcedencia.Value = "P"))
        End Select

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub frmREL_Resumo_Estoque_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub cboArmazem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboArmazem.SelectedIndexChanged
        Dim SqlText As String

        If Not ComboBox_LinhaSelecionada(cboArmazem) Then Exit Sub

        Select Case oTipoRelatorio
            Case RGFP_TipoRelatorio.EstoqueArmazem, RGFP_TipoRelatorio.ResumoEstoque
                SqlText = "SELECT DISTINCT CD_PILHA_ARMAZEM," & _
                                          "TO_CHAR(CD_PILHA_ARMAZEM) AS NO_PILHA_ARMAZEM" & _
                          " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM" & _
                          " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                          " ORDER BY CD_PILHA_ARMAZEM"
            Case Else
                SqlText = "SELECT CD_PILHA_ARMAZEM," & _
                                 "TO_CHAR(CD_PILHA_ARMAZEM) AS NO_PILHA_ARMAZEM" & _
                          " FROM SOF.PILHA_ARMAZEM" & _
                          " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                          " ORDER BY CD_PILHA_ARMAZEM"
        End Select

        DBCarregarComboBox(cboPilha, SqlText, True)
    End Sub
End Class