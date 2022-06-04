Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Branches
    Private Enum eItemBranches
        COMPRAS = 1
        CANCELAMENTOS = 2
        RECEBIMENTOS = 3
        FIXAÇÃO = 4
        DESAGIO = 5
        TRANSFERENCIA_TRANSITO = 6
        CACAU_AORDEM = 7
        CONTRATO_ABERTO = 8
        CONTRATOS_VENCIDOS_30 = 9
        CONTRATOS_VENCIDOS_60 = 10
        CONTRATOS_VENCIDOS_90 = 11
        CONTRATOS_VENCIDOS_ACIMA_90 = 12
        CONTRATOS_AVENCER = 13
        DEVOLUCOES = 14
        MOVIMENTACAO_ABERTO_NEGOCIAÇÕES = 15
        NEGOCIAÇÕES_IFERENCIAL_BOLSA = 16
        FIXAÇÃO_NEGOCIAÇÕES_DIFERENCIAL_BOLSA = 17
        CANCEL_NEGOCIAÇÕES_DIFERENCIAL_BOLSA = 18
        CONTRATOS_PAF_VENCIDOS_30 = 19
        CONTRATOS_PAF_VENCIDOS_60 = 20
        CONTRATOS_PAF_VENCIDOS_90 = 21
        CONTRATOS_PAF_VENCIDOS_ACIMA_90 = 22
        CONTRATOS_PAF_AVENCER = 23
        CANCEL_FIXA_NEGOCIAÇÕES_DIFERENCIAL = 24
    End Enum

    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub
    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub


    Private Sub Imprimir()
        Dim oRelatorioSub1 As New ReportDocument
        Dim oRelatorioSub2 As New ReportDocument
        Dim oRelatorioSub3 As New ReportDocument
        Dim oRelatorioSub4 As New ReportDocument
        Dim oData As DataTable
        Dim oDataRel1 As New DataTable
        Dim oDataRel2 As New DataTable
        Dim oDataRel3 As New DataTable
        Dim oDataRel4 As New DataTable
        Dim oDataRel5 As New DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""
        Dim icont As Integer

        If Not IsDate(txtData.Text) Then
            Msg_Mensagem("Favor informar uma data valida.")
            txtData.Focus()
            Exit Sub
        End If

        AVI_Carregar(Me)


        With oDataRel1.Columns
            .Add("NO_FILIAL").DataType = System.Type.GetType("System.String")
            .Add("QT_COMPRA").DataType = System.Type.GetType("System.Int32")
            .Add("QT_CANCELAMENTO").DataType = System.Type.GetType("System.Int32")
            .Add("QT_RECEBIMENTO").DataType = System.Type.GetType("System.Int32")
            .Add("QT_FIXACAO").DataType = System.Type.GetType("System.Int32")
            .Add("QT_DESAGIO").DataType = System.Type.GetType("System.Int32")
            .Add("QT_TRANSFERENCIA_TRANSITO").DataType = System.Type.GetType("System.Int32")
            .Add("QT_A_ORDEM").DataType = System.Type.GetType("System.Int32")
            .Add("QT_ESTOQUE").DataType = System.Type.GetType("System.Int32")
            .Add("QT_DEVOLUCAO").DataType = System.Type.GetType("System.Int32")
            .Add("QT_A_ORDEM_NEG").DataType = System.Type.GetType("System.Int32")
            .Add("QT_NEG_BOLSA").DataType = System.Type.GetType("System.Int32")
            .Add("QT_NEG_BOLSA_FIXACAO").DataType = System.Type.GetType("System.Int32")
            .Add("QT_NEG_BOLSA_CANCEL").DataType = System.Type.GetType("System.Int32")
            .Add("QT_NEG_BOLSA_FIXACAO_CANCEL").DataType = System.Type.GetType("System.Int32")
            .Add("CD_FILIAL").DataType = System.Type.GetType("System.Int32")
        End With

        With oDataRel2.Columns
            .Add("NO_FILIAL").DataType = System.Type.GetType("System.String")
            .Add("CD_SAFRA").DataType = System.Type.GetType("System.Int32")
            .Add("QT_POSICAO").DataType = System.Type.GetType("System.Int32")
            .Add("VL_POSICAO").DataType = System.Type.GetType("System.Int32")
            .Add("QT_LIMITE").DataType = System.Type.GetType("System.Int32")
            .Add("VL_LIMITE").DataType = System.Type.GetType("System.Int32")
        End With

        With oDataRel3.Columns
            .Add("NO_FILIAL").DataType = System.Type.GetType("System.String")
            .Add("QT_30D").DataType = System.Type.GetType("System.Int32")
            .Add("QT_31D_60D").DataType = System.Type.GetType("System.Int32")
            .Add("QT_61D_90D").DataType = System.Type.GetType("System.Int32")
            .Add("QT_91D").DataType = System.Type.GetType("System.Int32")
            .Add("QT_LIMITE").DataType = System.Type.GetType("System.Int32")
            .Add("A_VENCER").DataType = System.Type.GetType("System.Int32")
            .Add("CD_FILIAL").DataType = System.Type.GetType("System.Int32")
        End With

        With oDataRel4.Columns
            .Add("NO_FILIAL").DataType = System.Type.GetType("System.String")
            .Add("QT_30D").DataType = System.Type.GetType("System.Int32")
            .Add("QT_31D_60D").DataType = System.Type.GetType("System.Int32")
            .Add("QT_61D_90D").DataType = System.Type.GetType("System.Int32")
            .Add("QT_91D").DataType = System.Type.GetType("System.Int32")
            .Add("QT_LIMITE").DataType = System.Type.GetType("System.Int32")
            .Add("A_VENCER").DataType = System.Type.GetType("System.Int32")
            .Add("VL_30D").DataType = System.Type.GetType("System.Int32")
            .Add("VL_31D_60D").DataType = System.Type.GetType("System.Int32")
            .Add("VL_61D_90D").DataType = System.Type.GetType("System.Int32")
            .Add("VL_91D").DataType = System.Type.GetType("System.Int32")
            .Add("VL_A_VENCER").DataType = System.Type.GetType("System.Int32")
            .Add("CD_FILIAL").DataType = System.Type.GetType("System.Int32")
        End With

        With oDataRel5.Columns
            .Add("NO_FILIAL").DataType = System.Type.GetType("System.String")
            .Add("QT_30D").DataType = System.Type.GetType("System.Int32")
            .Add("QT_31D_60D").DataType = System.Type.GetType("System.Int32")
            .Add("QT_61D_90D").DataType = System.Type.GetType("System.Int32")
            .Add("QT_91D").DataType = System.Type.GetType("System.Int32")
            .Add("QT_LIMITE").DataType = System.Type.GetType("System.Int32")
            .Add("A_VENCER").DataType = System.Type.GetType("System.Int32")
            .Add("CD_FILIAL").DataType = System.Type.GetType("System.Int32")
        End With

        SqlText = "SELECT   b.cd_branche_item, b.cd_filial, b.cd_safra, "
        SqlText = SqlText & "         SUM (NVL (b.qt_saldo, 0)) AS qt_saldo, "
        SqlText = SqlText & "         SUM (NVL (b.vl_saldo, 0)) AS vl_saldo, f.no_filial, "
        SqlText = SqlText & "         f.vl_limite_credito_aberto, f.qt_limite_credito_aberto, "
        SqlText = SqlText & "         f.qt_limite_credito_vencidos, "
        SqlText = SqlText & "         SUM (NVL (b.vl_saldo_us, 0)) AS vl_saldo_us "
        SqlText = SqlText & "    FROM sof.branche b, sof.filial f "
        SqlText = SqlText & "   WHERE b.cd_filial = f.cd_filial AND b.dt_branche = " & QuotedStr(Date_to_Oracle(txtData.Text))
        SqlText = SqlText & "GROUP BY b.cd_branche_item, "
        SqlText = SqlText & "         b.cd_filial, "
        SqlText = SqlText & "         b.cd_safra, "
        SqlText = SqlText & "         f.no_filial, "
        SqlText = SqlText & "         f.vl_limite_credito_aberto, "
        SqlText = SqlText & "         f.qt_limite_credito_aberto, "
        SqlText = SqlText & "         f.qt_limite_credito_vencidos "

        SqlText = "select * from (" & SqlText & ") order by  cd_filial "
        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            Msg_Mensagem("Não existe branche neste periodo.")
            AVI_Fechar(Me)
            Exit Sub
        End If

        Dim ItemBranche As eItemBranches
        Dim iAux As Integer
        Dim bNovo As Boolean


        For icont = 0 To oData.Rows.Count - 1

            ItemBranche = oData.Rows(icont).Item("CD_BRANCHE_ITEM")

            Select Case ItemBranche
                Case eItemBranches.COMPRAS, eItemBranches.CANCELAMENTOS, eItemBranches.RECEBIMENTOS, _
                        eItemBranches.FIXAÇÃO, eItemBranches.DESAGIO, eItemBranches.TRANSFERENCIA_TRANSITO, eItemBranches.CACAU_AORDEM, _
                        eItemBranches.DEVOLUCOES, eItemBranches.MOVIMENTACAO_ABERTO_NEGOCIAÇÕES, eItemBranches.NEGOCIAÇÕES_IFERENCIAL_BOLSA, _
                        eItemBranches.FIXAÇÃO_NEGOCIAÇÕES_DIFERENCIAL_BOLSA, eItemBranches.CANCEL_NEGOCIAÇÕES_DIFERENCIAL_BOLSA, eItemBranches.CANCEL_FIXA_NEGOCIAÇÕES_DIFERENCIAL

                    bNovo = True
                    For iAux = 0 To oDataRel1.Rows.Count - 1
                        If oData.Rows(icont).Item("CD_FILIAL") = oDataRel1.Rows(iAux).Item("CD_FILIAL") Then
                            bNovo = False
                            Select Case ItemBranche
                                Case eItemBranches.COMPRAS
                                    oDataRel1.Rows(iAux).Item("qt_compra") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.CANCELAMENTOS
                                    oDataRel1.Rows(iAux).Item("qt_cancelamento") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.RECEBIMENTOS
                                    oDataRel1.Rows(iAux).Item("qt_recebimento") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.FIXAÇÃO
                                    oDataRel1.Rows(iAux).Item("qt_fixacao") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.DESAGIO
                                    oDataRel1.Rows(iAux).Item("qt_desagio") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.TRANSFERENCIA_TRANSITO
                                    oDataRel1.Rows(iAux).Item("qt_transferencia_transito") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.CACAU_AORDEM
                                    oDataRel1.Rows(iAux).Item("qt_a_ordem") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.DEVOLUCOES
                                    oDataRel1.Rows(iAux).Item("qt_devolucao") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.MOVIMENTACAO_ABERTO_NEGOCIAÇÕES
                                    oDataRel1.Rows(iAux).Item("qt_a_ordem_neg") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.NEGOCIAÇÕES_IFERENCIAL_BOLSA
                                    oDataRel1.Rows(iAux).Item("QT_NEG_BOLSA") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.FIXAÇÃO_NEGOCIAÇÕES_DIFERENCIAL_BOLSA
                                    oDataRel1.Rows(iAux).Item("QT_NEG_BOLSA_FIXACAO") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.CANCEL_NEGOCIAÇÕES_DIFERENCIAL_BOLSA
                                    oDataRel1.Rows(iAux).Item("QT_NEG_BOLSA_CANCEL") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.CANCEL_FIXA_NEGOCIAÇÕES_DIFERENCIAL
                                    oDataRel1.Rows(iAux).Item("QT_NEG_BOLSA_FIXACAO_CANCEL") = oData.Rows(icont).Item("qt_saldo")
                            End Select
                            Exit For
                        End If
                    Next

                    If bNovo = True Then
                        oDataRel1.Rows.Add()
                        With oDataRel1.Rows(oDataRel1.Rows.Count - 1)
                            .Item("NO_FILIAL") = oData.Rows(icont).Item("NO_FILIAL")
                            .Item("CD_FILIAL") = oData.Rows(icont).Item("CD_FILIAL")
                            .Item("qt_compra") = 0
                            .Item("qt_cancelamento") = 0
                            .Item("qt_recebimento") = 0
                            .Item("qt_fixacao") = 0
                            .Item("qt_desagio") = 0
                            .Item("qt_transferencia_transito") = 0
                            .Item("qt_a_ordem") = 0
                            .Item("qt_estoque") = 0
                            .Item("qt_devolucao") = 0
                            .Item("qt_a_ordem_neg") = 0
                            .Item("QT_NEG_BOLSA") = 0
                            .Item("QT_NEG_BOLSA_FIXACAO") = 0
                            .Item("QT_NEG_BOLSA_CANCEL") = 0
                            .Item("QT_NEG_BOLSA_FIXACAO_CANCEL") = 0
                        End With
                    End If

                Case eItemBranches.CONTRATO_ABERTO
                    oDataRel2.Rows.Add()
                    With oDataRel2.Rows(oDataRel2.Rows.Count - 1)
                        .Item("NO_FILIAL") = oData.Rows(icont).Item("NO_FILIAL")
                        .Item("CD_SAFRA") = oData.Rows(icont).Item("CD_SAFRA")
                        .Item("QT_POSICAO") = oData.Rows(icont).Item("QT_SALDO")
                        .Item("VL_POSICAO") = oData.Rows(icont).Item("VL_SALDO")
                        .Item("QT_LIMITE") = oData.Rows(icont).Item("QT_LIMITE_CREDITO_ABERTO")
                        .Item("VL_LIMITE") = oData.Rows(icont).Item("VL_LIMITE_CREDITO_ABERTO")
                    End With
                Case eItemBranches.CONTRATOS_VENCIDOS_30, eItemBranches.CONTRATOS_VENCIDOS_60, _
                    eItemBranches.CONTRATOS_VENCIDOS_90, eItemBranches.CONTRATOS_VENCIDOS_ACIMA_90, eItemBranches.CONTRATOS_AVENCER

                    bNovo = True
                    For iAux = 0 To oDataRel3.Rows.Count - 1
                        If oData.Rows(icont).Item("CD_FILIAL") = oDataRel3.Rows(iAux).Item("CD_FILIAL") Then
                            bNovo = False
                            Select Case ItemBranche
                                Case eItemBranches.CONTRATOS_VENCIDOS_30
                                    oDataRel3.Rows(iAux).Item("qt_30d") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.CONTRATOS_VENCIDOS_60
                                    oDataRel3.Rows(iAux).Item("qt_31d_60d") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.CONTRATOS_VENCIDOS_90
                                    oDataRel3.Rows(iAux).Item("qt_61d_90d") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.CONTRATOS_VENCIDOS_ACIMA_90
                                    oDataRel3.Rows(iAux).Item("qt_91d") = oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.CONTRATOS_AVENCER
                                    oDataRel3.Rows(iAux).Item("a_vencer") = oData.Rows(icont).Item("qt_saldo")
                            End Select
                            Exit For
                        End If
                    Next

                    If bNovo = True Then
                        oDataRel3.Rows.Add()
                        With oDataRel3.Rows(oDataRel3.Rows.Count - 1)
                            .Item("NO_FILIAL") = oData.Rows(icont).Item("NO_FILIAL")
                            .Item("CD_FILIAL") = oData.Rows(icont).Item("CD_FILIAL")
                            .Item("QT_LIMITE") = oData.Rows(icont).Item("QT_LIMITE_CREDITO_VENCIDOS")
                            .Item("qt_30d") = 0
                            .Item("qt_31d_60d") = 0
                            .Item("qt_61d_90d") = 0
                            .Item("qt_91d") = 0
                            .Item("a_vencer") = 0
                        End With
                    End If

                Case eItemBranches.CONTRATOS_PAF_VENCIDOS_30, eItemBranches.CONTRATOS_PAF_VENCIDOS_60, _
                        eItemBranches.CONTRATOS_PAF_VENCIDOS_90, eItemBranches.CONTRATOS_PAF_VENCIDOS_ACIMA_90, eItemBranches.CONTRATOS_PAF_AVENCER

                    bNovo = True
                    For iAux = 0 To oDataRel4.Rows.Count - 1
                        If oData.Rows(icont).Item("CD_FILIAL") = oDataRel4.Rows(iAux).Item("CD_FILIAL") Then
                            bNovo = False
                            Select Case ItemBranche
                                Case eItemBranches.CONTRATOS_PAF_VENCIDOS_30
                                    oDataRel4.Rows(iAux).Item("qt_30d") = oData.Rows(icont).Item("qt_saldo")
                                    oDataRel4.Rows(iAux).Item("VL_30d") = oData.Rows(icont).Item("VL_saldo_US")
                                Case eItemBranches.CONTRATOS_PAF_VENCIDOS_60
                                    oDataRel4.Rows(iAux).Item("qt_31d_60d") = oData.Rows(icont).Item("qt_saldo")
                                    oDataRel4.Rows(iAux).Item("VL_31d_60d") = oData.Rows(icont).Item("VL_saldo_US")
                                Case eItemBranches.CONTRATOS_PAF_VENCIDOS_90
                                    oDataRel4.Rows(iAux).Item("qt_61d_90d") = oData.Rows(icont).Item("qt_saldo")
                                    oDataRel4.Rows(iAux).Item("VL_61d_90d") = oData.Rows(icont).Item("VL_saldo_US")
                                Case eItemBranches.CONTRATOS_PAF_VENCIDOS_ACIMA_90
                                    oDataRel4.Rows(iAux).Item("qt_91d") = oData.Rows(icont).Item("qt_saldo")
                                    oDataRel4.Rows(iAux).Item("VL_91d") = oData.Rows(icont).Item("VL_saldo_US")
                                Case eItemBranches.CONTRATOS_PAF_AVENCER
                                    oDataRel4.Rows(iAux).Item("a_vencer") = oData.Rows(icont).Item("qt_saldo")
                                    oDataRel4.Rows(iAux).Item("VL_a_vencer") = oData.Rows(icont).Item("VL_saldo_US")
                            End Select
                            Exit For
                        End If
                    Next

                    If bNovo = True Then
                        oDataRel4.Rows.Add()
                        With oDataRel4.Rows(oDataRel4.Rows.Count - 1)
                            .Item("NO_FILIAL") = oData.Rows(icont).Item("NO_FILIAL")
                            .Item("CD_FILIAL") = oData.Rows(icont).Item("CD_FILIAL")
                            .Item("QT_LIMITE") = oData.Rows(icont).Item("QT_LIMITE_CREDITO_VENCIDOS")
                            .Item("qt_30d") = 0
                            .Item("qt_31d_60d") = 0
                            .Item("qt_61d_90d") = 0
                            .Item("qt_91d") = 0
                            .Item("a_vencer") = 0
                            .Item("VL_30d") = 0
                            .Item("VL_31d_60d") = 0
                            .Item("VL_61d_90d") = 0
                            .Item("VL_91d") = 0
                            .Item("VL_a_vencer") = 0
                        End With
                    End If
            End Select

            Select Case ItemBranche
                Case eItemBranches.CONTRATOS_PAF_VENCIDOS_30, eItemBranches.CONTRATOS_PAF_VENCIDOS_60, _
                    eItemBranches.CONTRATOS_PAF_VENCIDOS_90, eItemBranches.CONTRATOS_PAF_VENCIDOS_ACIMA_90, _
                     eItemBranches.CONTRATOS_PAF_AVENCER, eItemBranches.CONTRATOS_VENCIDOS_30, eItemBranches.CONTRATOS_VENCIDOS_60, _
                      eItemBranches.CONTRATOS_VENCIDOS_90, eItemBranches.CONTRATOS_VENCIDOS_ACIMA_90, eItemBranches.CONTRATOS_AVENCER


                    bNovo = True
                    For iAux = 0 To oDataRel5.Rows.Count - 1
                        If oData.Rows(icont).Item("CD_FILIAL") = oDataRel5.Rows(iAux).Item("CD_FILIAL") Then
                            bNovo = False
                            Select Case ItemBranche
                                Case eItemBranches.CONTRATOS_VENCIDOS_30, eItemBranches.CONTRATOS_PAF_VENCIDOS_30
                                    oDataRel5.Rows(iAux).Item("qt_30d") = oDataRel5.Rows(iAux).Item("qt_30d") + oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.CONTRATOS_VENCIDOS_60, eItemBranches.CONTRATOS_PAF_VENCIDOS_60
                                    oDataRel5.Rows(iAux).Item("qt_31d_60d") = oDataRel5.Rows(iAux).Item("qt_31d_60d") + oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.CONTRATOS_VENCIDOS_90, eItemBranches.CONTRATOS_PAF_VENCIDOS_90
                                    oDataRel5.Rows(iAux).Item("qt_61d_90d") = oDataRel5.Rows(iAux).Item("qt_61d_90d") + oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.CONTRATOS_VENCIDOS_ACIMA_90, eItemBranches.CONTRATOS_PAF_VENCIDOS_ACIMA_90
                                    oDataRel5.Rows(iAux).Item("qt_91d") = oDataRel5.Rows(iAux).Item("qt_91d") + oData.Rows(icont).Item("qt_saldo")
                                Case eItemBranches.CONTRATOS_AVENCER, eItemBranches.CONTRATOS_PAF_AVENCER
                                    oDataRel5.Rows(iAux).Item("a_vencer") = oDataRel5.Rows(iAux).Item("a_vencer") + oData.Rows(icont).Item("qt_saldo")
                            End Select
                            Exit For
                        End If
                    Next

                    If bNovo = True Then
                        oDataRel5.Rows.Add()
                        With oDataRel5.Rows(oDataRel5.Rows.Count - 1)
                            .Item("NO_FILIAL") = oData.Rows(icont).Item("NO_FILIAL")
                            .Item("CD_FILIAL") = oData.Rows(icont).Item("CD_FILIAL")
                            .Item("QT_LIMITE") = oData.Rows(icont).Item("QT_LIMITE_CREDITO_VENCIDOS")
                            .Item("qt_30d") = 0
                            .Item("qt_31d_60d") = 0
                            .Item("qt_61d_90d") = 0
                            .Item("qt_91d") = 0
                            .Item("a_vencer") = 0
                        End With
                    End If
            End Select
        Next



        SqlText = "select sum(rd.qt_kg_dia) as qt_saldo, rd.cd_filial_origem, f.no_filial " & _
                  "From SOF.resumo_diario_estoque rd, sof.filial f " & _
                  "where rd.cd_filial_origem = f.cd_filial and " & _
                  "rd.cd_tipo_movimentacao in (select cd_tp_mov_saldo_final from sof.tipo_rd) and " & _
                  "rd.dt_movimento='" & Date_to_Oracle(txtData.Text) & "' " & _
                  "group by rd.cd_filial_origem, f.no_filial"

        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            For icont = 0 To oData.Rows.Count - 1
                bNovo = True
                For iAux = 0 To oDataRel1.Rows.Count - 1
                    If oData.Rows(icont).Item("CD_FILIAL_ORIGEM") = oDataRel1.Rows(iAux).Item("CD_FILIAL") Then
                        bNovo = False
                        oDataRel1.Rows(iAux).Item("qt_estoque") = oData.Rows(icont).Item("qt_saldo")
                        Exit For
                    End If
                Next

                If bNovo = True Then
                    oDataRel1.Rows.Add()
                    With oDataRel1.Rows(oDataRel1.Rows.Count - 1)
                        .Item("NO_FILIAL") = oData.Rows(icont).Item("NO_FILIAL")
                        .Item("CD_FILIAL") = oData.Rows(icont).Item("CD_FILIAL_ORIGEM")
                        .Item("qt_compra") = 0
                        .Item("qt_cancelamento") = 0
                        .Item("qt_recebimento") = 0
                        .Item("qt_fixacao") = 0
                        .Item("qt_desagio") = 0
                        .Item("qt_transferencia_transito") = 0
                        .Item("qt_a_ordem") = 0
                        .Item("qt_estoque") = 0
                        .Item("qt_a_ordem_neg") = 0
                        .Item("QT_NEG_BOLSA") = 0
                        .Item("QT_NEG_BOLSA_FIXACAO") = 0
                        .Item("QT_NEG_BOLSA_CANCEL") = 0
                        .Item("QT_NEG_BOLSA_FIXACAO_CANCEL") = 0
                    End With
                End If
            Next
        End If

        icont = 0

        Do While icont <= oDataRel1.Rows.Count - 1
            If oDataRel1.Rows(icont).Item("qt_compra") = 0 And oDataRel1.Rows(icont).Item("qt_cancelamento") = 0 And _
                               oDataRel1.Rows(icont).Item("qt_recebimento") = 0 And oDataRel1.Rows(icont).Item("qt_fixacao") = 0 And _
                               oDataRel1.Rows(icont).Item("qt_desagio") = 0 And oDataRel1.Rows(icont).Item("qt_transferencia_transito") = 0 And _
                               oDataRel1.Rows(icont).Item("qt_a_ordem") = 0 And oDataRel1.Rows(icont).Item("qt_estoque") = 0 And _
                               oDataRel1.Rows(icont).Item("qt_a_ordem_neg") = 0 And oDataRel1.Rows(icont).Item("QT_NEG_BOLSA") = 0 And _
                               oDataRel1.Rows(icont).Item("QT_NEG_BOLSA_FIXACAO") = 0 And oDataRel1.Rows(icont).Item("QT_NEG_BOLSA_CANCEL") = 0 And _
                               oDataRel1.Rows(icont).Item("QT_NEG_BOLSA_FIXACAO_CANCEL") = 0 Then
                oDataRel1.Rows(icont).Delete()
            Else
                icont = icont + 1
            End If
        Loop

        icont = 0

        Do While icont <= oDataRel2.Rows.Count - 1
            If oDataRel2.Rows(icont).Item("qt_posicao") = 0 And oDataRel2.Rows(icont).Item("vl_posicao") = 0 Then
                oDataRel2.Rows(icont).Delete()
            Else
                icont = icont + 1
            End If
        Loop

        icont = 0

        Do While icont <= oDataRel3.Rows.Count - 1
            If oDataRel3.Rows(icont).Item("qt_30d") = 0 And oDataRel3.Rows(icont).Item("qt_31d_60d") = 0 And _
                    oDataRel3.Rows(icont).Item("qt_61d_90d") = 0 And oDataRel3.Rows(icont).Item("qt_91d") = 0 And oDataRel3.Rows(icont).Item("a_vencer") = 0 Then
                oDataRel3.Rows(icont).Delete()
            Else
                icont = icont + 1
            End If
        Loop

        oDataRel5.Columns.Remove(oDataRel5.Columns.Item("CD_FILIAL"))
        oDataRel1.Columns.Remove(oDataRel1.Columns.Item("CD_FILIAL"))
        oDataRel3.Columns.Remove(oDataRel3.Columns.Item("CD_FILIAL"))
        oDataRel4.Columns.Remove(oDataRel4.Columns.Item("CD_FILIAL"))



       
        oRelatorio.Load(Application.StartupPath & "\RPT_Branche.rpt")
        oRelatorio.SetDataSource(oDataRel1)
        oRelatorioSub1 = oRelatorio.Subreports("CRBCA")
        oRelatorioSub1.SetDataSource(oDataRel2)
        oRelatorioSub2 = oRelatorio.Subreports("CRBCV")
        oRelatorioSub2.SetDataSource(oDataRel3)
        oRelatorioSub3 = oRelatorio.Subreports("CRBCtrPAFAV")
        oRelatorioSub3.SetDataSource(oDataRel4)
        oRelatorioSub4 = oRelatorio.Subreports("TotalPAF")
        oRelatorioSub4.SetDataSource(oDataRel5)

        oRelatorio.SetParameterValue("Filtro", txtData.Text)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        crvMain.ReportSource = oRelatorio
        AVI_Fechar(Me)
    End Sub

    Private Sub frmREL_Branches_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub



    Private Sub frmREL_Branches_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub frmREL_Branches_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class