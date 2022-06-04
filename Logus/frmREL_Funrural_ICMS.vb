Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Funrural_ICMS
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim SqlFiltro As String = ""
        Dim SqlOrdem As String = ""
        Dim sFiltro As String = ""

        AVI_Carregar(Me)

        sFiltro = "Período: " & txtDataInicial.Text & " à " & txtDataFinal.Text

        SqlText = "SELECT FIL.CD_FILIAL," & _
                         "FIL.NO_FILIAL," & _
                         "DECODE (F.NO_RAZAO_SOCIAL, NULL, FILTRAS.NO_FILIAL,F.NO_RAZAO_SOCIAL) NO_RAZAO_SOCIAL," & _
                         "M.NU_NF," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "M.QT_KG_NF," & _
                         "M.VL_NF," & _
                         "M.VL_NF_ICMS," & _
                         "M.VL_NF_FUNRURAL," & _
                         "M.DT_MOVIMENTACAO," & _
                         "F.NU_CGC_CPF," & _
                         "NVL(F.IC_FISICA_JURIDICA, 'T') AS IC_FISICA_JURIDICA," & _
                         "F.CD_FUNRURAL," & _
                         "UF.PC_ALIQ_ICMS," & _
                         "TPT.NO_TIPO_PESSOA_TRIBUTACAO," & _
                         "NVL(PCF.PC_PIS_COFINS, SOF.FC_INDICE_VALORES(F.CD_TIPO_PESSOA, M.DT_MOVIMENTACAO, " & cnt_Processo_Confis & ") + SOF.FC_INDICE_VALORES(F.CD_TIPO_PESSOA, M.DT_MOVIMENTACAO, " & cnt_Processo_PIS & ")) PC_PIS_COFINS," & _
                         "ROUND((NVL(PCF.PC_PIS_COFINS, NVL(SOF.FC_INDICE_VALORES(F.CD_TIPO_PESSOA, M.DT_MOVIMENTACAO, " & cnt_Processo_Confis & "), 0) + NVL(SOF.FC_INDICE_VALORES(F.CD_TIPO_PESSOA, M.DT_MOVIMENTACAO, " & cnt_Processo_PIS & "), 0))) * NVL (M.VL_NF, 0) / 100, 2) VL_PIS_COFINS" & _
                  " FROM SOF.MOVIMENTACAO M," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.MUNICIPIO MUNIC," & _
                        "SOF.UF UF," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.TRANSFERENCIA T," & _
                        "SOF.FILIAL FILTRAS," & _
                        "SOF.TIPO_PESSOA_TRIBUTACAO TPT," & _
                        "(SELECT SQ_MOVIMENTACAO," & _
                                "CD_TIPO_PESSOA," & _
                                "NVL(SOF.FC_INDICE_VALORES(CD_TIPO_PESSOA, DT_NEGOCIACAO, " & cnt_Processo_Confis & "), 0) + " & _
                                    "NVL(SOF.FC_INDICE_VALORES(CD_TIPO_PESSOA, DT_NEGOCIACAO, " & cnt_Processo_PIS & "), 0) PC_PIS_COFINS" & _
                         " FROM (SELECT MOV.SQ_MOVIMENTACAO," & _
                                       "FNC.CD_TIPO_PESSOA," & _
                                       "MIN(NEG.DT_NEGOCIACAO) DT_NEGOCIACAO" & _
                                " FROM SOF.MOVIMENTACAO MOV," & _
                                      "SOF.CTR_PAF_NEG_MOVIMENTACAO PNM," & _
                                      "SOF.NEGOCIACAO NEG," & _
                                      "SOF.CONTRATO_PAF PAF," & _
                                      "SOF.FORNECEDOR FNC" & _
                                " WHERE PNM.SQ_MOVIMENTACAO = MOV.SQ_MOVIMENTACAO" & _
                                  " AND NEG.CD_CONTRATO_PAF = PNM.CD_CONTRATO_PAF" & _
                                  " AND NEG.SQ_NEGOCIACAO = PNM.SQ_NEGOCIACAO" & _
                                  " AND PAF.CD_CONTRATO_PAF = NEG.CD_CONTRATO_PAF" & _
                                  " AND FNC.CD_FORNECEDOR = PAF.CD_FORNECEDOR" & _
                                 " GROUP BY MOV.SQ_MOVIMENTACAO, FNC.CD_TIPO_PESSOA)) PCF" & _
                  " WHERE TM.CD_TIPO_MOVIMENTACAO = M.CD_TIPO_MOVIMENTACAO" & _
                    " AND F.CD_FORNECEDOR (+) = M.CD_FORNECEDOR" & _
                    " AND MUNIC.CD_MUNICIPIO (+) = F.CD_MUNICIPIO" & _
                    " AND TPT.CD_TIPO_PESSOA_TRIBUTACAO (+) = F.CD_TIPO_PESSOA_TRIBUTACAO" & _
                    " AND UF.CD_UF (+) = MUNIC.CD_UF" & _
                    " AND T.SQ_MOVIMENTACAO_SAIDA (+) = M.SQ_MOVIMENTACAO" & _
                    " AND FILTRAS.CD_FILIAL (+) = T.CD_FILIAL_ORIGEM" & _
                    " AND PCF.SQ_MOVIMENTACAO (+) = M.SQ_MOVIMENTACAO"

        Select Case optTipoFilial.Value
            Case "N" ' OPÇÃO ORIGEM NF
                SqlText = SqlText & " AND M.CD_FILIAL_ORIGEM = FIL.CD_FILIAL"
                'Filtro filial
                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND M.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial Origem NF: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & " AND M.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If
            Case "M" ' OPÇÃO MOVIMENTAÇÃO
                SqlText = SqlText & " AND M.CD_FILIAL_MOVIMENTACAO = FIL.CD_FILIAL"
                'Filtro filial
                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND M.CD_FILIAL_MOVIMENTACAO IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial Movimentação: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & " AND M.CD_FILIAL_MOVIMENTACAO IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If
            Case "F" 'OPÇÃO ORIGEM FORNECEDOR
                SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL"
                'Filtro filial
                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial Origem Fornecedor: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If
        End Select

        If ComboBox_LinhaSelecionada(cboTipoPessoaTributacao) Then
            SqlFiltro = SqlFiltro & " AND F.CD_TIPO_PESSOA_TRIBUTACAO = " & cboTipoPessoaTributacao.SelectedValue
        End If

        SqlText = SqlText & " AND M.DT_MOVIMENTACAO BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & _
                                                      " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)) & _
                            " AND TM.IC_ENTRA_NO_RD = 'S'"

        If chkSemImportacao.Checked = True Then
            SqlText = SqlText & " AND NVL(TM.IC_IMPORTACAO, 'N') = 'N'"
        End If

        If chkTransferencia.Checked = True Then
            SqlText = SqlText & " AND (M.VL_NF_FUNRURAL <> 0 OR M.VL_NF_ICMS <> 0)"
        Else
            SqlText = SqlText & " AND  NOT F.IC_FISICA_JURIDICA IS NULL"
        End If

        SqlOrdem = " ORDER BY F.CD_TIPO_PESSOA_TRIBUTACAO"

        oData = DBQuery(SqlText & SqlFiltro & SqlOrdem)

        oRelatorio.Load(Application.StartupPath & "\RPT_Funrural_ICMS.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub frmREL_Funrural_ICMS_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Funrural_ICMS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        ComboBox_Carregar_Tipo_Pessoa_Tributacao(cboTipoPessoaTributacao, True)

        Me.WindowState = 2
    End Sub

    Private Sub frmREL_Funrural_ICMS_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub
End Class