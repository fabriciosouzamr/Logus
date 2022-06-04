Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Contratos_Em_Aberto
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_Contratos_Em_Aberto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Contratos_Em_Aberto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        Selecao01.Enabled = False
        lblR_Opcoes.Enabled = False
        cboOpcao.Enabled = False

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        ComboBox_Carregar(cboOpcao, New String() {"Todos", "À Negociar", "Totalmente Negociados", _
                                                  "Totalmente Negociados - Com Pagamento em Aberto", _
                                                  "Vencidos", "A vencer", "Apenas com Adiantamento em Aberto"}, _
                                    New String() {cnt_ComboOpcao_Todos, cnt_ComboOpcao_ANegociar, cnt_ComboOpcao_TotalmenteNegociados, _
                                                  cnt_ComboOpcao_TotalmenteNegociados_ComPagamentoAberto, cnt_ComboOpcao_Vencidos, _
                                                  cnt_ComboOpcao_AVencer, cnt_ComboOpcao_ApenasAdiantamentoAberto})
        Me.WindowState = FormWindowState.Maximized

        grpPeriodo.Visible = False
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        Selecao01.Enabled = True
        cboOpcao.Enabled = False
        lblR_Opcoes.Enabled = False
        grpPeriodo.Visible = False

        Select Case optTipo.Value
            Case "P"
                With Selecao01
                    .BancoDados_Tabela = "SOF.TIPO_CONTRATO_PAF"
                    .BancoDados_Campo_Codigo = "CD_TIPO_CONTRATO_PAF"
                    .BancoDados_Campo_Descricao = "NO_TIPO_CONTRATO_PAF"
                    .BancoDados_Carregar()
                End With

                cboOpcao.Enabled = True
                lblR_Opcoes.Enabled = True
            Case "N"
                With Selecao01
                    .BancoDados_Tabela = "SOF.TIPO_NEGOCIACAO"
                    .BancoDados_Campo_Codigo = "CD_TIPO_NEGOCIACAO"
                    .BancoDados_Campo_Descricao = "NO_TIPO_NEGOCIACAO"
                    .BancoDados_Carregar()
                End With
            Case "F", "R"
                Selecao01.Lista_Selecao_MarcarTodos(False)
                Selecao01.Enabled = False
        End Select

        grpPeriodo.Visible = (optTipo.Value = "N" Or optTipo.Value = "F")
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim sFiltro As String = ""

        If optTipo.Value = Nothing Then
            Msg_Mensagem("Favor selecionar o contrato.")
            Exit Sub
        End If

        AVI_Carregar(Me)

        Select Case optTipo.Value
            Case "P"
                oRelatorio = Gera_Relatorio_ContratoEmAberto_PAF(SelecaoFilial.Lista_ID, Selecao01.Lista_ID, Pesq_Fornecedor.Codigo, NVL(cboOpcao.SelectedValue, ""))
            Case "N"
                oRelatorio = Gera_Relatorio_ContratoEmAberto_Negociacao(txtDataInicial.Text, txtDataFinal.Text, SelecaoFilial.Lista_ID, Selecao01.Lista_ID, Pesq_Fornecedor.Codigo)
            Case "F"
                oRelatorio = Gera_Relatorio_ContratoEmAberto_ContratoFixo(txtDataInicial.Text, txtDataFinal.Text, SelecaoFilial.Lista_ID, Pesq_Fornecedor.Codigo)
            Case "R"
                If SelecaoFilial.Lista_Quantidade > 0 Then
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                End If
                If Pesq_Fornecedor.Codigo > 0 Then
                    sFiltro = sFiltro & " - Fornecedor: " & Pesq_Fornecedor.Descricao
                End If

                oData = Gera_Rs_ContratoEmAberto_Resumo(Pesq_Fornecedor.Codigo, _
                                                        SelecaoFilial.Lista_ID)
                oRelatorio.Load(Application.StartupPath & "\RPT_Contratos_Aberto_Resumo.rpt")
                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("DataHoje", DataSistema)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        End Select

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub frmREL_Contratos_Em_Aberto_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub
End Class