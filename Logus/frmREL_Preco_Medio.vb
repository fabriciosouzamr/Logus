Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Preco_Medio
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_Preco_Medio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Preco_Medio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_Preco_Medio_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Imprimir()
        Dim oRelatorio_Sub As New ReportDocument
        Dim oData As DataTable
        Dim oDataSub As DataTable
        Dim SqlText As String = ""
        Dim SqlFilial As String = ""
        Dim sFiltro As String = ""

        If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub

        If txtTaxaDolar.Value = 0 Then
            Msg_Mensagem("Favor informar uma taxa de dolar")
            txtTaxaDolar.Focus()
            Exit Sub
        End If
        If txtBolsa.Value = 0 Then
            Msg_Mensagem("Favor informar um valor da bolsa.")
            txtBolsa.Focus()
            Exit Sub
        End If

        AVI_Carregar(Me)

        sFiltro = "Período de " & txtDataInicial.Value & " e " & txtDataFinal.Value

        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlFilial = " and F.cd_filial_origem in (" & SelecaoFilial.Lista_ID & ")"
            sFiltro = sFiltro & " - Filiais: " & SelecaoFilial.Lista_Descricao
        Else
            SqlFilial = " and F.cd_filial_origem in (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        'Na consulta se o cd_tipo_pessoa do fornecedor for 5(Repassador) é alterado para 3 (Agregado)
        SqlText = "SELECT F.NO_RAZAO_SOCIAL," & _
                          "DECODE(F.CD_TIPO_PESSOA, 5, 3, F.CD_TIPO_PESSOA) CD_TIPO_PESSOA," & _
                          "N.QT_KGS," & _
                          "N.VL_NEGOCIACAO AS VL_UNITARIO," & _
                          "N.VL_PRECO_FRETE," & _
                          "FIL.CD_FILIAL," & _
                          "FIL.NO_FILIAL," & _
                          "DECODE(N.VL_TAXA_DOLAR, NULL, " & txtTaxaDolar.Value & ", DECODE(N.VL_TAXA_DOLAR_ALTERNATIVO, 0, N.VL_TAXA_DOLAR, N.VL_TAXA_DOLAR_ALTERNATIVO)) VL_DOLAR_ATUAL," & _
                          "DECODE(N.VL_BOLSA, NULL, " & txtBolsa.Value & ", DECODE(N.VL_BOLSA_ALTERNATIVO, 0, N.VL_BOLSA, N.VL_BOLSA_ALTERNATIVO)) VL_BOLSA_ATUAL," & _
                          "FUN.VL_TAXA," & _
                          "N.PC_ALIQ_ICMS," & _
                          "TN.IC_DOLAR," & _
                          "TU.QT_FATOR," & _
                          "TN.CD_TIPO_NEGOCIACAO," & _
                          "TN.NO_TIPO_NEGOCIACAO," & _
                          "TN.IC_BOLSA," & _
                          "TN.IC_BOLSA_OPERACAO," & _
                          "TN.IC_TIPO_PRECO_FIXO" & _
                  " FROM SOF.NEGOCIACAO N," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.TIPO_NEGOCIACAO TN," & _
                        "SOF.TIPO_UNIDADE TU," & _
                        "SOF.FUNRURAL FUN" & _
                  " WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                    " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND F.CD_FUNRURAL = FUN.CD_FUNRURAL" & _
                    " AND CP.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                    " AND N.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                    " AND N.DT_NEGOCIACAO BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & _
                                            " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & _
                    " AND N.IC_STATUS <> 'E'" & _
                    SqlFilial & _
                  " UNION ALL " & _
                  "SELECT F.NO_RAZAO_SOCIAL," & _
                         "DECODE(F.CD_TIPO_PESSOA, 5, 3, F.CD_TIPO_PESSOA) TP_PESSOA," & _
                         "(0 - NC.QT_CANCELADO) QT_KGS," & _
                         "DECODE(NC.IC_ESTORNO_CANCELAMENTO, 'C', NC.VL_UNITARIO, N.VL_NEGOCIACAO) VL_UNITARIO," & _
                         "DECODE(NC.IC_ESTORNO_CANCELAMENTO, 'C', 0, N.VL_PRECO_FRETE) VL_PRECO_FRETE," & _
                         "FIL.CD_FILIAL," & _
                         "FIL.NO_FILIAL," & _
                         "DECODE(NC.IC_ESTORNO_CANCELAMENTO,'C', NC.VL_TAXA_DOLAR, DECODE(N.VL_TAXA_DOLAR, NULL, " & txtTaxaDolar.Value & ", DECODE(N.VL_TAXA_DOLAR_ALTERNATIVO, 0, N.VL_TAXA_DOLAR, N.VL_TAXA_DOLAR_ALTERNATIVO))) VL_DOLAR_ATUAL, DECODE(NC.IC_ESTORNO_CANCELAMENTO,'C', NC.VL_BOLSA, DECODE(N.VL_BOLSA, NULL, " & txtBolsa.Value & ", DECODE(N.VL_BOLSA_ALTERNATIVO, 0, N.VL_BOLSA, N.VL_BOLSA_ALTERNATIVO))) VL_BOLSA_ATUAL," & _
                         "DECODE(NC.IC_ESTORNO_CANCELAMENTO,'C', 0, FUN.VL_TAXA) VL_TAXA," & _
                         "DECODE(NC.IC_ESTORNO_CANCELAMENTO,'C', 0, N.PC_ALIQ_ICMS) PC_ALIQ_ICMS," & _
                         "DECODE(NC.IC_ESTORNO_CANCELAMENTO,'C','N',TN.IC_DOLAR) IC_DOLAR," & _
                         "TU.QT_FATOR," & _
                         "TN.CD_TIPO_NEGOCIACAO," & _
                         "TN.NO_TIPO_NEGOCIACAO," & _
                         "DECODE(NC.IC_ESTORNO_CANCELAMENTO, 'C', 'N', TN.IC_BOLSA) IC_BOLSA," & _
                         "TN.IC_BOLSA_OPERACAO," & _
                         "DECODE(NC.IC_ESTORNO_CANCELAMENTO, 'C', 'S', TN.IC_TIPO_PRECO_FIXO) IC_TIPO_PRECO_FIXO" & _
                  " FROM SOF.NEGOCIACAO N," & _
                        "SOF.NEGOCIACAO_CANCELADO NC," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.TIPO_NEGOCIACAO TN," & _
                        "SOF.TIPO_UNIDADE TU," & _
                        "SOF.FUNRURAL FUN" & _
                  " WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                    " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND F.CD_FUNRURAL = FUN.CD_FUNRURAL" & _
                    " AND CP.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                    " AND N.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                    " AND N.CD_CONTRATO_PAF = NC.CD_CONTRATO_PAF" & _
                    " AND N.SQ_NEGOCIACAO = NC.SQ_NEGOCIACAO" & _
                    " AND NC.DT_CANCELAMENTO BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & _
                                               " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & _
                    SqlFilial
        oData = DBQuery(SqlText)

        SqlText = "SELECT F.NO_RAZAO_SOCIAL," & _
                         "CF.QT_KGS QT_KGS," & _
                         "N.VL_NEGOCIACAO," & _
                         "CF.VL_BOLSA_FECHADO AS VL_BOLSA_FECHADA," & _
                         "CF.VL_UNITARIO," & _
                         "CF.VL_TAXA_DOLAR_FECHADO," & _
                         "TO_CHAR (CF.CD_CONTRATO_PAF) || '-' || TO_CHAR (CF.SQ_NEGOCIACAO) || '-' || CF.SQ_CONTRATO_FIXO CD_CONTRATO," & _
                         "CP.CD_FILIAL_ORIGEM" & _
                  " FROM SOF.NEGOCIACAO N," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.TIPO_NEGOCIACAO TN," & _
                        "SOF.CONTRATO_FIXO CF," & _
                        "SOF.FILIAL FIL" & _
                  " WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                    " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                    " AND N.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                    " AND N.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO" & _
                    " AND CP.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND CF.DT_CONTRATO_FIXO BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & _
                                                " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & _
                    " AND CF.IC_STATUS <> 'E'" & _
                    " AND TN.IC_BOLSA = 'S' " & _
                    SqlFilial & _
                  " UNION ALL " & _
                  "SELECT F.NO_RAZAO_SOCIAL," & _
                         "0 - CFC.QT_CANCELADO QT_KGS," & _
                         "N.VL_NEGOCIACAO," & _
                         "CF.VL_BOLSA_FECHADO AS VL_BOLSA_FECHADA," & _
                         "CF.VL_UNITARIO," & _
                         "CF.VL_TAXA_DOLAR_FECHADO," & _
                         "TO_CHAR (CF.CD_CONTRATO_PAF) || '-' || TO_CHAR (CF.SQ_NEGOCIACAO) || '-' || CF.SQ_CONTRATO_FIXO CD_CONTRATO," & _
                         "CP.CD_FILIAL_ORIGEM" & _
                  " FROM SOF.NEGOCIACAO N," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.TIPO_NEGOCIACAO TN," & _
                        "SOF.CONTRATO_FIXO CF," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.CONTRATO_FIXO_CANCELADO CFC" & _
                  " WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                    " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                    " AND N.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                    " AND N.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO" & _
                    " AND CP.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND CF.CD_CONTRATO_PAF = CFC.CD_CONTRATO_PAF" & _
                    " AND CF.SQ_NEGOCIACAO = CFC.SQ_NEGOCIACAO" & _
                    " AND CF.SQ_CONTRATO_FIXO = CFC.SQ_CONTRATO_FIXO" & _
                    " AND CFC.DT_CANCELAMENTO BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & _
                                                " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & _
                    " AND TN.IC_BOLSA = 'S'" & _
                    SqlFilial
        oDataSub = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_Preco_Medio.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio_Sub = oRelatorio.Subreports("CRNegBolsaFix")
        oRelatorio_Sub.SetDataSource(oDataSub)

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub
End Class