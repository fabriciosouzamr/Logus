Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Contratos_Listagem
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_Contratos_Listagem_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Contratos_Listagem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        ComboBox_Carregar_Tipo_Cacau(cboTipoCacau, True)
        HabilitarTipoCacau(False)

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_Contratos_Listagem_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""

        If optTipo.Value = Nothing Then
            Msg_Mensagem("Favor selecionar o contrato.")
            Exit Sub
        End If

        AVI_Carregar(Me)

        Select Case optTipo.Value
            Case "P"
                SqlText = "SELECT CP.DT_CONTRATO_PAF," & _
                                 "CP.CD_CONTRATO_PAF," & _
                                 "F.NO_RAZAO_SOCIAL," & _
                                 "TP.NO_TIPO_PESSOA," & _
                                 "CP.QT_KGS," & _
                                 "CP.IC_STATUS," & _
                                 "CP.DT_PRAZO_ENTREGA," & _
                                 "F.CD_FILIAL_ORIGEM," & _
                                 "FIL.NO_FILIAL," & _
                                 "CP.QT_CANCELADO," & _
                                 "CP.DT_PRAZO_FIXACAO" & _
                          " FROM SOF.CONTRATO_PAF CP," & _
                                "SOF.FORNECEDOR F," & _
                                "SOF.TIPO_PESSOA TP," & _
                                "SOF.FILIAL FIL" & _
                          " WHERE CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                            " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA" & _
                            " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL"

                If IsDate(txtDataInicial.Text) Then
                    SqlText = SqlText & " AND TRUNC( CP.DT_CONTRATO_PAF ) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
                    sFiltro = sFiltro & " - Data Inicial: " & txtDataInicial.Text
                End If
                If IsDate(txtDataFinal.Text) Then
                    SqlText = SqlText & " AND TRUNC( CP.DT_CONTRATO_PAF ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
                    sFiltro = sFiltro & " - Data Final: " & txtDataFinal.Text
                End If
                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If
                If Pesq_Fornecedor.Codigo > 0 Then
                    SqlText = SqlText & " AND F.CD_FORNECEDOR =" & Pesq_Fornecedor.Codigo
                    sFiltro = sFiltro & " - Fornecedor: " & Pesq_Fornecedor.Descricao
                End If

                oData = DBQuery(SqlText)
                oRelatorio.Load(Application.StartupPath & "\RPT_Contratos_PAF.rpt")
                oRelatorio.SetDataSource(oData)
            Case "F"
                SqlText = "SELECT F.NO_RAZAO_SOCIAL," & _
                                 "CF.DT_CONTRATO_FIXO DT_CONTRATO," & _
                                 "CF.CD_CONTRATO_PAF CD_CONTRATO," & _
                                 "(CF.QT_KGS - CF.QT_CANCELADO) QT_KGS," & _
                                 "CF.QT_KG_FIXO QT_FIXO," & _
                                 "CF.VL_UNITARIO," & _
                                 "CF.CD_TIPO_UNIDADE," & _
                                 "ROUND(((CF.VL_TOTAL + DECODE(CF.IC_INCLUI_ICMS_PAG, 'S', CF.VL_ICMS, 0)) / CF.QT_KGS) * (CF.QT_KGS - CF.QT_CANCELADO), 2) VL_TOTAL," & _
                                 "CF.VL_PAG_FIXO VL_PAGO_SI," & _
                                 "CF.IC_STATUS," & _
                                 "F.CD_FILIAL_ORIGEM," & _
                                 "CF.VL_ADENDO VL_ADENDO_CONTRATO," & _
                                 "CF.SQ_NEGOCIACAO," & _
                                 "CF.SQ_CONTRATO_FIXO," & _
                                 "CF.IC_GP," & _
                                 "CF.DT_VENCIMENTO_GP," & _
                                 "ROUND(((CF.VL_TOTAL) / CF.QT_KGS) * (CF.QT_KGS - CF.QT_CANCELADO), 2) VL_LIQUIDO," & _
                                 "ROUND(((DECODE(CF.IC_INCLUI_ICMS_PAG, 'S', CF.VL_ICMS, 0)) / CF.QT_KGS) * (CF.QT_KGS - CF.QT_CANCELADO), 2) VL_ICMS," & _
                                 "DECODE(CF.IC_INCLUI_ICMS_PAG, 'S', CF.VL_ADENDO_ICMS, 0) AS VL_ADENDO_ICMS" & _
                          " FROM SOF.FORNECEDOR F," & _
                                "SOF.CONTRATO_PAF CP," & _
                                "SOF.CONTRATO_FIXO CF," & _
                                "SOF.NEGOCIACAO NG" & _
                          " WHERE CP.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                            " AND F.CD_FORNECEDOR = CP.CD_FORNECEDOR" & _
                            " AND CF.IC_STATUS <> 'E'" & _
                            " AND NG.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                            " AND NG.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO"

                If IsDate(txtDataInicial.Text) Then
                    SqlText = SqlText & " AND TRUNC(CF.DT_CONTRATO_FIXO) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
                    sFiltro = sFiltro & " - Data Inicial: " & txtDataInicial.Text
                End If
                If IsDate(txtDataFinal.Text) Then
                    SqlText = SqlText & " AND TRUNC(CF.DT_CONTRATO_FIXO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
                    sFiltro = sFiltro & " - Data Final: " & txtDataFinal.Text
                End If
                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If
                If Pesq_Fornecedor.Codigo > 0 Then
                    SqlText = SqlText & " AND F.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
                    sFiltro = sFiltro & " - Fornecedor: " & Pesq_Fornecedor.Descricao
                End If
                If ComboBox_LinhaSelecionada(cboTipoCacau) Then
                    SqlText = SqlText & " AND NG.CD_TIPO_CACAU = " & cboTipoCacau.SelectedValue
                    sFiltro = sFiltro & " - Tipo de Cacau: " & cboTipoCacau.Text
                End If

                oData = DBQuery(SqlText)

                oRelatorio.Load(Application.StartupPath & "\RPT_Contratos_Fixo.rpt")
                oRelatorio.SetDataSource(oData)
        End Select

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub HabilitarTipoCacau(ByVal bHabilitar As Boolean)
        lblR_TipoCacau.Visible = bHabilitar
        cboTipoCacau.Visible = bHabilitar
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        HabilitarTipoCacau(optTipo.Value = "F")
    End Sub
End Class