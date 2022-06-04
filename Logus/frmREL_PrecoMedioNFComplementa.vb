Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_PrecoMedioNFComplementa
    Public Enum RGFP_TipoRelatorio
        PrecoMedio = 1
        NFComplementar = 2
        CashTrade = 3
        SaldoFinanceiro_CtrFixo = 4
    End Enum

    Public Enum CashTrade_Grupo
        SaldoAbertoEntComAdto = 1
        SaldoAbertoEntSemAdto = 2
        TotalNegAfixarSemAdto = 3
    End Enum

    Public oTipoRelatorio As RGFP_TipoRelatorio
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_PrecoMedioNFComplementa_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_PrecoMedioNFComplementa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        Select Case oTipoRelatorio
            Case RGFP_TipoRelatorio.PrecoMedio
                Me.Text = "Relatório de Preço Médio Contábil"
                optTipo.Items.Clear()
                optTipo.Items.Add(cnt_PrecoMedio_Cod_Sintetico, cnt_PrecoMedio_Desc_Sintetico)
                optTipo.Items.Add(cnt_PrecoMedio_Cod_Analitico, cnt_PrecoMedio_Desc_Analitico)
                optTipo.Items.Add(cnt_PrecoMedio_Cod_Resumido, cnt_PrecoMedio_Desc_Resumido)
                optTipo.CheckedIndex = 0
            Case RGFP_TipoRelatorio.NFComplementar
                Me.Text = "Relatório de NF Complementar Contabil"
                optTipo.Items.Clear()
                optTipo.Items.Add(cnt_NFComplementar_Cod_Todos, cnt_NFComplementar_Desc_Todos)
                optTipo.Items.Add(cnt_NFComplementar_Cod_Credito, cnt_NFComplementar_Desc_Credito)
                optTipo.Items.Add(cnt_NFComplementar_Cod_Debito, cnt_NFComplementar_Desc_Debito)
                optTipo.Items.Add("C", "Credito")
                optTipo.Items.Add("D", "Debito")
                optTipo.CheckedIndex = 0
            Case RGFP_TipoRelatorio.CashTrade
                Me.Text = "Relatório de Cash Trade"
                optTipo.Items.Clear()
                optTipo.Items.Add(cnt_PrecoMedio_Cod_Sintetico, cnt_PrecoMedio_Desc_Sintetico)
                optTipo.Items.Add(cnt_PrecoMedio_Cod_Analitico, cnt_PrecoMedio_Desc_Analitico)
                optTipo.Items.Add(cnt_PrecoMedio_Cod_Analitico_Mensal, cnt_PrecoMedio_Desc_Analitico_Mensal)
                optTipo.CheckedIndex = 0
                optTipo.Width = 250
                optTipo.SendToBack()
            Case RGFP_TipoRelatorio.SaldoFinanceiro_CtrFixo
                Me.Text = "Relatório de Saldo Financeiro de Contrato Fixo"
                optTipo.Items.Clear()
                optTipo.Items.Add(cnt_PrecoMedio_Cod_Analitico, cnt_PrecoMedio_Desc_Analitico)
                optTipo.CheckedIndex = 0
                optTipo.Visible = False
        End Select

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Imprimir()
        If txtTaxaDolar.Value = 0 Then
            Msg_Mensagem("Favor informar uma taxa de dolar")
            txtTaxaDolar.Focus()
            Exit Sub
        End If

        AVI_Carregar(Me)

        oRelatorio = Gera_Relatorio_PrecoMedioNRComplementa(oTipoRelatorio, _
                                                            txtTaxaDolar.Value, _
                                                            SelecaoFilial.Lista_ID, _
                                                            optTipo.Value)

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub frmREL_PrecoMedioNFComplementa_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub
End Class