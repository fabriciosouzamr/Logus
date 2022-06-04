Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_ListagemFrete_Recepcao
    Dim oRelatorio As New CrystalReportDocument
    Dim oDS As New Infragistics.Win.UltraWinDataSource.UltraDataSource

    Const cnt_TipoCacau_Outros_CacauFixo As String = "FX"
    Const cnt_TipoCacau_Outros_AOrdem_Negociacao As String = "ON"
    Const cnt_TipoCacau_Outros_AOrdem_Master As String = "OM"
    Const cnt_TipoCacau_Outros_AOrdem As String = "OD"

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub frmREL_ListagemFrete_Recepcao_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_ListagemFrete_Recepcao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TipoCacauOutros_Validar()

        SelecaoOutrosTipos.MultiplaSelecao_Codigo_Tipo = Selecao.enMultiplaSelecao_Codigo_Tipo.Texto
        SelecaoOutrosTipos.Lista_Adicionar(New String() {cnt_TipoCacau_Outros_AOrdem, _
                                                         cnt_TipoCacau_Outros_AOrdem_Master, _
                                                         cnt_TipoCacau_Outros_AOrdem_Negociacao, _
                                                         cnt_TipoCacau_Outros_CacauFixo}, _
                                           New String() {"Cacau NPE sem Contrato", _
                                                         "Cacau NPE em Master", _
                                                         "Cacau NPE em Negociação", _
                                                         "Cacau Fixo"})
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Dim oRelatorio_TabelaFrete As New ReportDocument
        Dim oData As DataTable
        Dim oData_TabelaFrete As DataTable
        Dim SqlText As String = ""
        Dim SqlText_TabelaFrete As String = ""
        Dim sFiltro As String = ""
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim oRow As DataRow

        If optTipoCacau_Todos.Checked Or SelecaoOutrosTipos.Lista_Existe(cnt_TipoCacau_Outros_CacauFixo) Then
            If Not Data_ValidarPeriodo("de movimetação", txtDataFinal.Text, txtDataFinal.Text, True) Then Exit Sub
        End If

        Str_Adicionar(sFiltro, "Período de Movimentação: " & txtDataInicial.Text & " a " & txtDataFinal.Text, " - ")
        Str_Adicionar(sFiltro, "Tipo de Pessoa: " & optTipoPessoa.CheckedItem.DisplayText, " - ")
        Str_Adicionar(sFiltro, "Tipo de Cacau: " & IIf(optTipoCacau_SomenteCacauNPE.Checked, optTipoCacau_SomenteCacauNPE.Text, _
                                                       IIf(optTipoCacau_Todos.Checked, optTipoCacau_Todos.Text, _
                                                           IIf(optTipoCacau_Outros.Checked, SelecaoOutrosTipos.Lista_Descricao, ""))), " - ")
        If SelecaoFornecedor.Lista_Quantidade <> 0 Then
            Str_Adicionar(sFiltro, "Fornecedor: " & SelecaoFornecedor.Lista_Descricao, " - ")
        End If
        If SelecaoFilialMovimentacao.Lista_Quantidade <> 0 Then
            Str_Adicionar(sFiltro, "Filial de Movimentação: " & SelecaoFilialMovimentacao.Lista_Descricao, " - ")
        End If
        If SelecaoFilialFrete.Lista_Quantidade <> 0 Then
            Str_Adicionar(sFiltro, "Filial de Frete: " & SelecaoFilialFrete.Lista_Descricao, " - ")
        End If
        Str_Adicionar(sFiltro, "Agrupar por: " & optAgruparFilial.CheckedItem.DisplayText, " - ")
        Str_Adicionar(sFiltro, Trim(chkSoValorFrete.Text) & ": " & IIf(chkSoValorFrete.Checked, "Sim", "Não"), " - ")

        '###### INÍCIO FRETE ######
        oData_TabelaFrete = New DataTable

        With oData_TabelaFrete.Columns
            .Add("NO_FILIAL")
            .Add("VL_POSTO_FABRICA").DataType = System.Type.GetType("System.Double")
            .Add("VL_POSTO_FILIAL").DataType = System.Type.GetType("System.Double")
            .Add("VL_POSTO_FAZENDA").DataType = System.Type.GetType("System.Double")
        End With

        SqlText_TabelaFrete = "SELECT PRE.CD_FILIAL," & _
                                     "PRE.CD_LOCAL_ENTREGA," & _
                                     "PRE.VL_FRETE," & _
                                     "PRE.VL_FRETE_ATUAL," & _
                                     "TRIM(FIL.NO_FILIAL) NO_FILIAL" & _
                              " FROM (SELECT F.CD_FILIAL, 1 CD_LOCAL_ENTREGA, F.VL_FRETE_FILIAL_FAZENDA VL_FRETE, F.VL_FRETE_FILIAL_FAZENDA + F.VL_FRETE_FILIAL_FABRICA + F.VL_FRETE_FABRICA VL_FRETE_ATUAL FROM SOF.FILIAL F" & _
                                    " UNION ALL " & _
                                     "SELECT F.CD_FILIAL, 2 CD_LOCAL_ENTREGA, F.VL_FRETE_FILIAL_FABRICA VL_FRETE, F.VL_FRETE_FILIAL_FABRICA + F.VL_FRETE_FABRICA VL_FRETE_ATUAL FROM SOF.FILIAL F" & _
                                    " UNION ALL " & _
                                     "SELECT F.CD_FILIAL, 3 CD_LOCAL_ENTREGA,  F.VL_FRETE_FABRICA VL_FRETE, F.VL_FRETE_FABRICA VL_FRETE_ATUAL FROM SOF.FILIAL F) PRE," & _
                                    "SOF.FILIAL FIL" & _
                              " WHERE FIL.CD_FILIAL = PRE.CD_FILIAL"
        oData = DBQuery(SqlText_TabelaFrete)

        For iCont_01 = 0 To oData.Rows.Count - 1
            oRow = Nothing

            With oData.Rows(iCont_01)
                For iCont_02 = 0 To oData_TabelaFrete.Rows.Count - 1
                    If .Item("NO_FILIAL") = oData_TabelaFrete.Rows(iCont_02).Item("NO_FILIAL") Then
                        oRow = oData_TabelaFrete.Rows(iCont_02)
                        Exit For
                    End If
                Next

                If oRow Is Nothing Then
                    oRow = oData_TabelaFrete.NewRow
                    oData_TabelaFrete.Rows.Add(oRow)
                End If

                oRow.Item("NO_FILIAL") = .Item("NO_FILIAL")

                Select Case .Item("CD_LOCAL_ENTREGA")
                    Case cnt_LocalEntrega_Fabrica
                        oRow.Item("VL_POSTO_FABRICA") = .Item("VL_FRETE_ATUAL")
                    Case cnt_LocalEntrega_Fazenda
                        oRow.Item("VL_POSTO_FAZENDA") = .Item("VL_FRETE_ATUAL")
                    Case cnt_LocalEntrega_Filial
                        oRow.Item("VL_POSTO_FILIAL") = .Item("VL_FRETE_ATUAL")
                End Select
            End With
        Next
        '###### FIM FRETE ######

        SqlText = "SELECT FNC.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "MOV.DT_MOVIMENTACAO," & _
                         "MOV.NU_NF || NVL2(MOV.NU_SERIE_NF, '-' || MOV.NU_SERIE_NF, '') NU_NF," & _
                         "NVL2(CSD.CD_CONTRATO_PAF, TO_CHAR(CSD.CD_CONTRATO_PAF), '') || NVL2(CSD.SQ_NEGOCIACAO, '-' || TO_CHAR(CSD.SQ_NEGOCIACAO), '')  || NVL2(CSD.SQ_CONTRATO_FIXO, '-' || TO_CHAR(CSD.SQ_CONTRATO_FIXO), '') CD_CONTRATO_PAF," & _
                         "LCE.NO_LOCAL_ENTREGA," & _
                         "FIL.NO_FILIAL," & _
                         "FFT.NO_FILIAL NO_FILIAL_FRETE," & _
                         "TNG.NO_TIPO_NEGOCIACAO," & _
                         "CSD.QT_KG_A_FIXAR + CSD.QT_KG_FIXO QT_MOVIMENTACAO," & _
                         "CSD.VL_A_FIXAR + CSD.VL_FIXO VL_MOVIMENTACAO," & _
                         "PFT.VL_FRETE_ATUAL VL_FRETE," & _
                         "ROUND((PFT.VL_FRETE_ATUAL / 60) * (CSD.QT_KG_A_FIXAR + CSD.QT_KG_FIXO), 2) VL_FRETE_MOVIMENTACAO" & _
                  " FROM (SELECT MCD.SQ_MOVIMENTACAO," & _
                                "CPF.CD_CONTRATO_PAF," & _
                                "CPF.SQ_NEGOCIACAO," & _
                                "CPF.SQ_CONTRATO_FIXO," & _
                                "0 QT_KG_A_FIXAR," & _
                                "CPF.QT_KG_FIXO," & _
                                "0 VL_A_FIXAR," & _
                                "CPF.VL_FIXO," & _
                                "NEG.CD_FILIAL_ENTREGA," & _
                                "NEG.CD_LOCAL_ENTREGA," & _
                                "NEG.CD_TIPO_NEGOCIACAO," & _
                                "'FX' IC_TIPO" & _
                         " FROM SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                               "SOF.CTR_PAF_MOVIMENTACAO CPM," & _
                               "SOF.CTR_PAF_NEG_MOVIMENTACAO CPN," & _
                               "SOF.CTR_PAF_NEG_CTR_FIX_MOV CPF," & _
                               "SOF.NEGOCIACAO NEG," & _
                               "SOF.CONTRATO_FIXO FIX" & _
                         " WHERE CPM.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                           " AND CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO = MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                           " AND CPN.SQ_MOVIMENTACAO = CPM.SQ_MOVIMENTACAO" & _
                           " AND CPN.SQ_MOVIMENTACAO_CESSAO_DIREITO = CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                           " AND CPN.CD_CONTRATO_PAF = CPM.CD_CONTRATO_PAF" & _
                           " AND CPF.SQ_MOVIMENTACAO = CPN.SQ_MOVIMENTACAO" & _
                           " AND CPF.SQ_MOVIMENTACAO_CESSAO_DIREITO = CPN.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                           " AND CPF.CD_CONTRATO_PAF = CPN.CD_CONTRATO_PAF" & _
                           " AND CPF.SQ_CTR_PAF_MOVIMENTACAO = CPN.SQ_CTR_PAF_MOVIMENTACAO" & _
                           " AND CPF.SQ_NEGOCIACAO = CPN.SQ_NEGOCIACAO" & _
                           " AND CPF.SQ_CTR_PAF_NEG_CTR_FIX_MOV = CPN.SQ_CTR_PAF_NEG_MOVIMENTACAO" & _
                           " AND NEG.CD_CONTRATO_PAF = CPN.CD_CONTRATO_PAF" & _
                           " AND NEG.SQ_NEGOCIACAO = CPN.SQ_NEGOCIACAO" & _
                           " AND FIX.CD_CONTRATO_PAF = CPF.CD_CONTRATO_PAF" & _
                           " AND FIX.SQ_NEGOCIACAO = CPF.SQ_NEGOCIACAO" & _
                           " AND FIX.SQ_CONTRATO_FIXO = CPF.SQ_CONTRATO_FIXO" & _
                        " UNION" & _
                        " SELECT MCD.SQ_MOVIMENTACAO," & _
                                "CPN.CD_CONTRATO_PAF," & _
                                "CPN.SQ_NEGOCIACAO," & _
                                "NULL SQ_CONTRATO_FIXO," & _
                                "CPN.QT_KG_A_FIXAR," & _
                                "0 QT_KG_FIXO," & _
                                "CPN.VL_A_FIXAR," & _
                                "0 VL_FIXO," & _
                                "NEG.CD_FILIAL_ENTREGA," & _
                                "NEG.CD_LOCAL_ENTREGA," & _
                                "NEG.CD_TIPO_NEGOCIACAO," & _
                                "'ON' IC_TIPO" & _
                         " FROM SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                               "SOF.CTR_PAF_MOVIMENTACAO CPM," & _
                               "SOF.CTR_PAF_NEG_MOVIMENTACAO CPN," & _
                               "SOF.NEGOCIACAO NEG" & _
                         " WHERE CPM.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                           " AND CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO = MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                           " AND CPN.SQ_MOVIMENTACAO = CPM.SQ_MOVIMENTACAO" & _
                           " AND CPN.SQ_MOVIMENTACAO_CESSAO_DIREITO = CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                           " AND CPN.CD_CONTRATO_PAF = CPM.CD_CONTRATO_PAF" & _
                           " AND NEG.CD_CONTRATO_PAF = CPN.CD_CONTRATO_PAF" & _
                           " AND NEG.SQ_NEGOCIACAO = CPN.SQ_NEGOCIACAO" & _
                           " AND CPN.QT_KG_A_FIXAR <> 0" & _
                        " UNION" & _
                        " SELECT MCD.SQ_MOVIMENTACAO," & _
                                "PAF.CD_CONTRATO_PAF," & _
                                "NULL SQ_NEGOCIACAO," & _
                                "NULL SQ_CONTRATO_FIXO," & _
                                "CPM.QT_KG_A_FIXAR," & _
                                "0 QT_KG_FIXO," & _
                                "CPM.VL_A_FIXAR," & _
                                "0 VL_FIXO," & _
                                "PAF.CD_FILIAL_ENTREGA," & _
                                "MOV.CD_LOCAL_ENTREGA," & _
                                "NULL CD_TIPO_NEGOCIACAO," & _
                                "'OM' IC_TIPO" & _
                         " FROM SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                               "SOF.MOVIMENTACAO MOV," & _
                               "SOF.CTR_PAF_MOVIMENTACAO CPM," & _
                               "SOF.CONTRATO_PAF PAF" & _
                         " WHERE CPM.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                           " AND CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO = MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                           " AND MOV.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                           " AND PAF.CD_CONTRATO_PAF = CPM.CD_CONTRATO_PAF" & _
                           " AND CPM.QT_KG_A_FIXAR <> 0" & _
                        " UNION" & _
                        " SELECT MCD.SQ_MOVIMENTACAO," & _
                                "NULL CD_CONTRATO_PAF," & _
                                "NULL SQ_NEGOCIACAO," & _
                                "NULL SQ_CONTRATO_FIXO," & _
                                "MCD.QT_KG_A_FIXAR," & _
                                "0 QT_KG_FIXO," & _
                                "MCD.VL_A_FIXAR," & _
                                "0 VL_FIXO," & _
                                "MOV.CD_FILIAL_MOVIMENTACAO CD_FILIAL_ENTREGA," & _
                                "MOV.CD_LOCAL_ENTREGA CD_LOCAL_ENTREGA," & _
                                "NULL CD_TIPO_NEGOCIACAO," & _
                                "'OD' IC_TIPO" & _
                         " FROM SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                               "SOF.MOVIMENTACAO MOV" & _
                         " WHERE MCD.QT_KG_A_FIXAR <> 0" & _
                           " AND MOV.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO) CSD," & _
                        "SOF.MOVIMENTACAO MOV," & _
                        "SOF.FORNECEDOR FNC," & _
                        "SOF.LOCAL_ENTREGA LCE," & _
                        "SOF.FILIAL FFT," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.TIPO_NEGOCIACAO TNG," & _
                        "(" & SqlText_TabelaFrete & ") PFT" & _
                  " WHERE MOV.SQ_MOVIMENTACAO = CSD.SQ_MOVIMENTACAO" & _
                    " AND FNC.CD_FORNECEDOR = MOV.CD_FORNECEDOR" & _
                    " AND FFT.CD_FILIAL (+) = CSD.CD_FILIAL_ENTREGA" & _
                    " AND LCE.CD_LOCAL_ENTREGA (+) = CSD.CD_LOCAL_ENTREGA" & _
                    " AND TNG.CD_TIPO_NEGOCIACAO (+) = CSD.CD_TIPO_NEGOCIACAO" & _
                    " AND PFT.CD_FILIAL (+) = CSD.CD_FILIAL_ENTREGA" & _
                    " AND PFT.CD_LOCAL_ENTREGA (+) = CSD.CD_LOCAL_ENTREGA" & _
                    " AND FNC.CD_TIPO_PESSOA NOT IN (" & cnt_TipoPessoa_IMPORTADO & ")"

        'Filtro de fornecedor
        If SelecaoFornecedor.Lista_Quantidade <> 0 Then
            SqlText = SqlText & _
                    " AND FNC.CD_FORNECEDOR IN (" & SelecaoFornecedor.Lista_ID & ")"
        End If
        'Agrupamento Filial
        Select Case optAgruparFilial.Value
            Case "F"
                SqlText = SqlText & _
                    " AND FIL.CD_FILIAL = FNC.CD_FILIAL_ORIGEM"
            Case "M"
                SqlText = SqlText & _
                    " AND FIL.CD_FILIAL = MOV.CD_FILIAL_MOVIMENTACAO"
        End Select
        'Filtro Somente com valor de frete
        If chkSoValorFrete.Checked Then
            SqlText = SqlText & _
                    " AND PFT.VL_FRETE_ATUAL <> 0"
        End If
        'Filtro Tipo de Pessoa
        If optTipoPessoa.Value <> "T" Then
            SqlText = SqlText & _
                    " AND FNC.IC_FISICA_JURIDICA = " & QuotedStr(optTipoPessoa.Value)
        End If
        'Filtro Filial de Movimentação
        If SelecaoFilialMovimentacao.Lista_Quantidade <> 0 Then
            SqlText = SqlText & _
                    " AND MOV.CD_FILIAL_MOVIMENTACAO IN (" & SelecaoFilialFrete.Lista_ID & ")"
        End If
        'Filtro Filial de Frete
        If SelecaoFilialFrete.Lista_Quantidade <> 0 Then
            SqlText = SqlText & _
                    " AND CSD.CD_FILIAL_ENTREGA IN (" & SelecaoFilialFrete.Lista_ID & ")"
        End If
        Select Case True
            Case optTipoCacau_SomenteCacauNPE.Checked
                SqlText = SqlText & _
                    " AND CSD.IC_TIPO IN (" & QuotedStr(cnt_TipoCacau_Outros_AOrdem) & "," & _
                                              QuotedStr(cnt_TipoCacau_Outros_AOrdem_Master) & "," & _
                                              QuotedStr(cnt_TipoCacau_Outros_AOrdem_Negociacao) & ")"
            Case optTipoCacau_Outros.Checked
                If SelecaoOutrosTipos.Lista_Quantidade = 0 Then
                    Msg_Mensagem("Selecione as opções de outros tipo de cacau")
                    Exit Sub
                Else
                    SqlText = SqlText & _
                    " AND CSD.IC_TIPO IN ( " & SelecaoOutrosTipos.Lista_ID & ")"
                End If
        End Select

        AVI_Carregar(Me)

        oData = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_ListagemFrete_Recepcao.rpt")
        oRelatorio_TabelaFrete = oRelatorio.Subreports("RPT_ListagemFrete_Recepcao_Tabela")
        oRelatorio.SetDataSource(oData)
        oRelatorio_TabelaFrete.SetDataSource(oData_TabelaFrete)

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub frmREL_ListagemFrete_Recepcao_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub TipoCacauOutros_Validar()
        lblR_OutrosTipos.Enabled = optTipoCacau_Outros.Checked
        SelecaoOutrosTipos.Enabled = optTipoCacau_Outros.Checked
    End Sub

    Private Sub optTipoCacau_Outros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipoCacau_Outros.CheckedChanged
        TipoCacauOutros_Validar()
    End Sub
End Class