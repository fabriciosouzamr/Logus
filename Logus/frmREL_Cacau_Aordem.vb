Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Cacau_Aordem
    Dim oRelatorio As New CrystalReportDocument

    Private Sub frmREL_Cacau_Aordem_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Cacau_Aordem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        Me.WindowState = FormWindowState.Maximized

        SqlText = "SELECT " & QuotedStr(cnt_RelatorioCacauAOrdem_Cod_PRAZOVENCIDO) & "," & _
                              QuotedStr(cnt_RelatorioCacauAOrdem_Desc_PRAZOVENCIDO) & _
                  " FROM DUAL " & _
                  "UNION " & _
                  "SELECT " & QuotedStr(cnt_RelatorioCacauAOrdem_Cod_PRAZOAVENCER) & "," & _
                              QuotedStr(cnt_RelatorioCacauAOrdem_Desc_PRAZOAVENCER) & _
                  " FROM DUAL " & _
                  "UNION " & _
                  "SELECT " & QuotedStr(cnt_RelatorioCacauAOrdem_Cod_SEMPRAZO) & "," & _
                              QuotedStr(cnt_RelatorioCacauAOrdem_Desc_SEMPRAZO) & _
                  " FROM DUAL"
        DBCarregarComboBox(cboPrazo, SqlText, True)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cboPrazo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrazo.SelectedIndexChanged
        Select Case cboPrazo.SelectedValue
            Case "PRAZOVENCIDO", "PRAZOAVENCER"
                txtDataVencimento.Enabled = True
            Case Else
                txtDataVencimento.Enabled = False
                txtDataVencimento.Value = DataSistema()
        End Select
    End Sub

    Private Sub Imprimir()
        AVI_Carregar(Me)

        oRelatorio = Gera_Relatorio_CacauAOrdem(NVL(cboPrazo.SelectedValue, ""), _
                                                txtDataVencimento.Text, _
                                                chkValoresAberto.Checked, _
                                                chkSemMovimentacao.Checked, _
                                                SelecaoFilial.Lista_ID, _
                                                (optDadosRel.Value = "SC"), _
                                                (optTipo.Value = "S"))
        
        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub frmREL_Cacau_Aordem_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub optDadosRel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDadosRel.ValueChanged
        If optDadosRel.Value = "SC" Then
            chkSemMovimentacao.Checked = False
            chkSemMovimentacao.Enabled = False
            chkValoresAberto.Checked = False
            chkValoresAberto.Enabled = False
            cboPrazo.Enabled = False
            ComboBox_Possicionar(cboPrazo, -1)
            txtDataVencimento.Enabled = False
        Else
            chkSemMovimentacao.Enabled = True
            chkValoresAberto.Enabled = True
            cboPrazo.Enabled = True
            txtDataVencimento.Enabled = True
        End If
    End Sub
End Class