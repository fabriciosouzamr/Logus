Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Win.UltraWinEditors

Public Class frmREL_NegociacoesAbertoComFixacoes
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_NegociacoesAbertoComFixacoes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_NegociacoesAbertoComFixacoes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        With SelecaoTipoNegociacao
            .BancoDados_Tabela = "SOF.TIPO_NEGOCIACAO"
            .BancoDados_Campo_Codigo = "CD_TIPO_NEGOCIACAO"
            .BancoDados_Campo_Descricao = "NO_TIPO_NEGOCIACAO"
            .BancoDados_Carregar()
        End With

        chkDataBolsa_CheckedChanged(Nothing, Nothing)
        Me.WindowState = FormWindowState.Maximized

        ValidarTipoRelatorio()
    End Sub

    Private Sub frmREL_NegociacoesAbertoComFixacoes_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlVerifica As String

        If chkDataBolsa.Checked = True Then 'caso seja informado a data da bolsa
            If Not IsDate(txtDataBolsa.Value) Then
                Msg_Mensagem("Data da bolsa inválida.")
                txtDataBolsa.Focus()
                Exit Sub
            End If

            SqlVerifica = "SELECT SQ_BOLSA_PERIODO_MATRIZ," & _
                                 "VL_COTACAO " & _
                          " FROM SOF.BOLSA_HISTORICO" & _
                          " WHERE DT_BOLSA_HISTORICO = " & QuotedStr(Date_to_Oracle(txtDataBolsa.Value))
            oData = DBQuery(SqlVerifica)

            If oData.Rows.Count = 0 Then
                Msg_Mensagem("Não temos valor de bolsa para a data solicitada.")
                txtDataBolsa.Focus()
                Exit Sub
            End If
        End If

        If chkDataLimite.Checked = True Then
            If Not IsDate(txtDataLimite.Value) Then
                Msg_Mensagem("Data inválida.")
                txtDataLimite.Focus()
                Exit Sub
            End If
        End If

        AVI_Carregar(Me)

        oRelatorio = Gera_Relatorio_NegociacaoAbertaComFixacoes(txtDataLimite.Text, _
                                                                txtDataBolsa.Text, _
                                                                SelecaoFilial.Lista_ID, _
                                                                SelecaoTipoNegociacao.Lista_ID, _
                                                                chkSaldo.Checked, _
                                                                (optTipo.Value = "S"), _
                                                                chkDataLimite.Checked, _
                                                                chkFixacoes.Checked, _
                                                                chkUsarBolsaCalcSaldo.Checked)

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub chkDataBolsa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDataBolsa.CheckedChanged
        If chkDataBolsa.Checked = True Then
            txtDataBolsa.Enabled = True
        Else
            txtDataBolsa.Enabled = False
            txtDataBolsa.Value = Nothing
        End If
    End Sub

    Private Sub chkDataLimite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDataLimite.CheckedChanged
        If chkDataLimite.Checked = True Then
            txtDataLimite.Enabled = True
        Else
            txtDataLimite.Enabled = False
            txtDataLimite.Value = Nothing
        End If
    End Sub

    Private Sub chkFixacoes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFixacoes.CheckedChanged

    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        ValidarTipoRelatorio()
    End Sub

    Private Sub ValidarTipoRelatorio()
        chkUsarBolsaCalcSaldo.Checked = True
        chkUsarBolsaCalcSaldo.Visible = False

        If optTipo.Value = "S" Then
            chkUsarBolsaCalcSaldo.Checked = False
            chkUsarBolsaCalcSaldo.Visible = True
        End If
    End Sub
End Class