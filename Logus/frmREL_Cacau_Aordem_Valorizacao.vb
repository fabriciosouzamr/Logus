Public Class frmREL_Cacau_Aordem_Valorizacao
    Dim oRelatorio As New CrystalReportDocument

    Private Sub frmREL_Cacau_Aordem_Valorizacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With
        Pega_Valores()
        Me.WindowState = FormWindowState.Maximized
        Me.Enabled =True 
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub
   
    Private Sub frmREL_Cacau_Aordem_Valorizacao_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub frmREL_Cacau_Aordem_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub Imprimir()
        If Not txtDolar.Value > 0 Then
            Msg_Mensagem("Favor informar uma taxa de dolar.")
            Exit Sub
        End If
        If Not txtBolsa.Value > 0 Then
            Msg_Mensagem("Favor informar um valor da bolsa.")
            Exit Sub
        End If

        AVI_Carregar(Me)

        oRelatorio = Gera_Relatorio_Cacau_Aordem_Valorizacao(SelecaoFilial.Lista_ID, _
                                                             txtBolsa.Value, _
                                                             txtValorDif.Value, _
                                                             txtDolar.Value, _
                                                             (optDadosRel.Value = "B"))

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Pega_Valores()
    End Sub

    Private Sub Pega_Valores()
        Dim SqlText As String
        Dim DtCotacao As Date

        SqlText = "SELECT MAX(LCM.DT_COTACAO) DT_COTACAO" & _
                  " FROM SOF.LIMITE_CREDITO_MOEDA LCM" & _
                  " WHERE LCM.DT_COTACAO <= TO_DATE('" & Date_to_Oracle(DataSistema) & "')"
        DtCotacao = DBQuery_ValorUnico(SqlText)

        SqlText = "SELECT LCM.VL_TAXA" & _
                  " FROM SOF.LIMITE_CREDITO_MOEDA LCM" & _
                  " WHERE LCM.DT_COTACAO = TO_DATE('" & Date_to_Oracle(DtCotacao) & "')" & _
                    " AND LCM.CD_TIPO_MOEDA = " & cnt_LimiteCreditoTipoMoeda_Dolar
        txtDolar.Value = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT LCM.VL_TAXA " & _
                    " FROM SOF.LIMITE_CREDITO_MOEDA LCM" & _
                    " WHERE LCM.DT_COTACAO = TO_DATE('" & Date_to_Oracle(DtCotacao) & "')" & _
                      " AND LCM.CD_TIPO_MOEDA = " & cnt_LimiteCreditoTipoMoeda_Bolsa
        txtBolsa.Value = DBQuery_ValorUnico(SqlText, 0)

        SqlText = " select * from (SELECT BP.vl_diferencial FROM SOF.BOLSA_PERIODO BP  " & _
                    "WHERE BP.ic_moeda = 'N' and BP.ic_exibe='S' " & _
                    "ORDER BY BP.SQ_BOLSA_PERIODO_MATRIZ ASC, NU_SEQUENCIA) where rownum=1 "
        txtValorDif.Value = DBQuery_ValorUnico(SqlText, 0)
    End Sub

    Private Sub optDadosRel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDadosRel.ValueChanged
        'If optDadosRel.Value = "B" Then
        '    txtValorDif.Enabled = False
        'Else
        '    txtValorDif.Enabled = True
        'End If
        txtValorDif.Enabled = True
    End Sub
End Class