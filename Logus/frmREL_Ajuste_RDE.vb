Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Ajuste_RDE
    Dim oRelatorio As New CrystalReportDocument

    Private Sub frmREL_Ajuste_RDE_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Ajuste_RDE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_TipoMovimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        optTipoRelatorio_AcertoRD.Checked = True
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        If Not optTipoRelatorio_AcertoEstoqueFisico.Checked And Not optTipoRelatorio_AcertoRD.Checked Then
            Msg_Mensagem("É preciso selecionar o tipo de relatório")
            Exit Sub
        End If
        If Not Data_ValidarPeriodo("de acerto", txtDataInicial.Text, txtDataFinal.Text, True, True) Then
            Exit Sub
        End If

        AVI_Carregar(Me)

        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""

        Str_Adicionar(sFiltro, "Tipo de Relatório: " & IIf(optTipoRelatorio_AcertoRD.Checked, "Acerto de RD", "Acerto de Estoque"), " - ")
        Str_Adicionar(sFiltro, "Período: " & txtDataInicial.Text & " a " & txtDataFinal.Text, " - ")
        Str_Adicionar(sFiltro, "Status: " & IIf(optStatus_AguardandoAprovacao.Checked, "Aguardando Aprovação", _
                                                                                       IIf(optStatus_Aprovado.Checked, "Aprovado", _
                                                                                                                       IIf(optStatus_Reprovado.Checked, "Reprovado", "Todos"))), " - ")
        Str_Adicionar(sFiltro, "Exibir Justificativas: " & IIf(chkExibirJustificativas.Checked, "Sim", "Não"), " - ")
        If Pesq_Fornecedor.Codigo > 0 Then Str_Adicionar(sFiltro, "Fornecedor: " & Pesq_Fornecedor.Descricao, " - ")
        If Pesq_TipoMovimentacao.Codigo > 0 Then Str_Adicionar(sFiltro, "Tipo de Movimentação: " & Pesq_TipoMovimentacao.Descricao, " - ")

        Select Case True
            Case optTipoRelatorio_AcertoEstoqueFisico.Checked
                SqlText = "SELECT ARM.NO_ARMAZEM," & _
                                 "RDA.DT_AJUSTE DT_LANCAMENTO," & _
                                 "RDA.DT_APROVACAO," & _
                                 "RDA.CD_PILHA," & _
                                 "TPS.NO_TIPO_SACARIA," & _
                                 "AMZ.QT_MOVIMENTACAO_NOVO QT_VOLUME," & _
                                 "AMZ.QT_SACOS_NOVO QT_SACOS," & _
                                 "RDA.CM_JUSTIFICATIVA," & _
                                 "APV.NO_USUARIO NO_APROVADOR," & _
                                 "RDA.CM_APROVACAO CM_JUSTIFICATIVA_APROVACAO," & _
                                 "DECODE(NVL(RDA.IC_APROVADO, 'X'), 'X', 'Aguardando Aprovação', 'S', 'Aprovado', 'N', 'Reprovado') NO_STATUS" & _
                          " FROM SOF.RESUMO_DIARIO_ESTOQUE_ACERTO RDA," & _
                                "SOF.RESUMO_DIARIO_ESTOQUE_ACT_AMZ AMZ," & _
                                "SOF.ARMAZEM ARM," & _
                                "SOF.TIPO_SACARIA TPS," & _
                                "AGC.SEC_USUARIO APV" & _
                          " WHERE RDA.DT_AJUSTE BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)) & _
                            " AND AMZ.SQ_ACERTO = RDA.SQ_ACERTO" & _
                            " AND ARM.CD_ARMAZEM = AMZ.CD_ARMAZEM" & _
                            " AND TPS.CD_TIPO_SACARIA = AMZ.CD_TIPO_SACARIA" & _
                            " AND APV.CD_USUARIO (+) = RDA.CD_USUARIO_APROVACAO"

                If Not optStatus_Todos.Checked Then
                    SqlText = SqlText & " AND NVL(RDA.IC_APROVADO, 'X') = " & IIf(optStatus_AguardandoAprovacao.Checked, "'X'", IIf(optStatus_Aprovado.Checked, "'S'", "'N'"))
                End If
            Case optTipoRelatorio_AcertoRD.Checked
                SqlText = "SELECT FIL.NO_FILIAL," & _
                                 "DECODE(NVL(RDA.IC_APROVADO, 'X'), 'X', 'Aguardando Aprovação', 'S', 'Aprovado', 'N', 'Reprovado') NO_STATUS," & _
                                 "RDA.DT_AJUSTE DT_LANCAMENTO," & _
                                 "RDA.DT_APROVACAO," & _
                                 "FNC.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                                 "RDA.QT_AJUSTE," & _
                                 "RDA.QT_AJUSTE_NF," & _
                                 "RDA.VL_AJUSTE," & _
                                 "RDA.VL_AJUSTE_ICMS," & _
                                 "RDA.VL_AJUSTE_INSS," & _
                                 "TPM.NO_TIPO_MOVIMENTACAO," & _
                                 "RDA.CM_JUSTIFICATIVA," & _
                                 "APV.NO_USUARIO NO_APROVADOR," & _
                                 "RDA.CM_APROVACAO CM_JUSTIFICATIVA_APROVACAO" & _
                          " FROM SOF.RESUMO_DIARIO_ESTOQUE_ACERTO RDA," & _
                                "SOF.FILIAL FIL," & _
                                "SOF.FORNECEDOR FNC," & _
                                "SOF.TIPO_MOVIMENTACAO TPM," & _
                                "AGC.SEC_USUARIO APV" & _
                          " WHERE TRUNC(RDA.DT_AJUSTE) BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)) & _
                            " AND FIL.CD_FILIAL = RDA.CD_FILIAL_ORIGEM" & _
                            " AND FNC.CD_FORNECEDOR (+) = RDA.CD_FORNECEDOR" & _
                            " AND TPM.CD_TIPO_MOVIMENTACAO = RDA.CD_TIPO_MOVIMENTACAO" & _
                            " AND APV.CD_USUARIO (+) = RDA.CD_USUARIO_APROVACAO"

                If Not optStatus_Todos.Checked Then
                    SqlText = SqlText & " AND NVL(RDA.IC_APROVADO, 'X') = " & IIf(optStatus_AguardandoAprovacao.Checked, "'X'", IIf(optStatus_Aprovado.Checked, "'S'", "'N'"))
                End If
                If Pesq_Fornecedor.Codigo > 0 Then
                    SqlText = SqlText & " AND FNC.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
                End If
                If Pesq_TipoMovimentacao.Codigo > 0 Then
                    SqlText = SqlText & " AND RDA.CD_TIPO_MOVIMENTACAO = " & Pesq_TipoMovimentacao.Codigo
                End If
        End Select

        oData = DBQuery(SqlText)

        Select Case True
            Case optTipoRelatorio_AcertoEstoqueFisico.Checked
                oRelatorio.Load(Application.StartupPath & "\RPT_AprovacaoAcertoEstoque.rpt")
            Case optTipoRelatorio_AcertoRD.Checked
                oRelatorio.Load(Application.StartupPath & "\RPT_AprovacaoAcertoRD.rpt")
        End Select

        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        oRelatorio.SetParameterValue("IC_EXIBIR_JUSTIFICATIVAS", IIf(chkExibirJustificativas.Checked, "S", "N"))

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub optTipoRelatorio_AcertoEstoqueFisico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipoRelatorio_AcertoEstoqueFisico.CheckedChanged
        grpFornecedor.Enabled = optTipoRelatorio_AcertoEstoqueFisico.Checked
        grpTipoMovimentacao.Enabled = optTipoRelatorio_AcertoEstoqueFisico.Checked

        If Not grpFornecedor.Enabled Then
            Pesq_Fornecedor.Codigo = 0
        End If
        If Not grpTipoMovimentacao.Enabled Then
            Pesq_TipoMovimentacao.Codigo = 0
        End If
    End Sub

    Private Sub frmREL_Ajuste_RDE_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub
End Class