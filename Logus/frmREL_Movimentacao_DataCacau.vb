Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Movimentacao_DataCacau
    Const cnt_TipoIntervalo_Dia As Integer = 1
    Const cnt_TipoIntervalo_Semana As Integer = 2
    Const cnt_TipoIntervalo_Mes As Integer = 3
    Const cnt_TipoIntervalo_Avulso As Integer = 4

    Dim oRelatorio As New CrystalReportDocument

    Dim TipoIntervalo01 As String = ""
    Dim TipoIntervalo02 As String = ""
    Dim TipoIntervalo03 As String = ""
    Dim TipoIntervalo04 As String = ""
    Dim TipoIntervalo05 As String = ""
    Dim TipoIntervalo06 As String = ""
    Dim TipoIntervalo07 As String = ""
    Dim TipoIntervalo08 As String = ""
    Dim TipoIntervalo09 As String = ""
    Dim TipoIntervalo_Dia_01 As String = ""
    Dim TipoIntervalo_Dia_02 As String = ""
    Dim TipoIntervalo_Dia_03 As String = ""
    Dim TipoIntervalo_Dia_04 As String = ""
    Dim TipoIntervalo_Dia_05 As String = ""
    Dim TipoIntervalo_Dia_06 As String = ""
    Dim TipoIntervalo_Dia_07 As String = ""
    Dim TipoIntervalo_Dia_08 As String = ""
    Dim TipoIntervalo_Dia_09 As String = ""

    Private Sub frmREL_Movimentacao_DataCacau_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Movimentacao_DataCacau_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ValidarOrigem()

        With SelecaoFilialMovimentacao
            .BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With
        With SelecaoFilialRecebimento
            .BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        'Formatação do Controles de Intervalo - Início
        ComboBox_Carregar(cboTipoIntervalo, New String() {"Dia", "Semana", "Mês", "Avulso"}, _
                                            New Object() {cnt_TipoIntervalo_Dia, cnt_TipoIntervalo_Semana, cnt_TipoIntervalo_Mes, cnt_TipoIntervalo_Avulso})
        ComboBox_Possicionar(cboTipoIntervalo, cnt_TipoIntervalo_Mes)
        txtIntervalo.Value = 1

        CarregarIntervalo(cboTipoIntervalo_01)
        CarregarIntervalo(cboTipoIntervalo_02)
        CarregarIntervalo(cboTipoIntervalo_03)
        CarregarIntervalo(cboTipoIntervalo_04)
        CarregarIntervalo(cboTipoIntervalo_05)
        CarregarIntervalo(cboTipoIntervalo_06)
        CarregarIntervalo(cboTipoIntervalo_07)
        CarregarIntervalo(cboTipoIntervalo_08)

        ComboBox_Possicionar(cboTipoIntervalo_01, cnt_TipoIntervalo_Mes)
        ComboBox_Possicionar(cboTipoIntervalo_02, cnt_TipoIntervalo_Mes)
        ComboBox_Possicionar(cboTipoIntervalo_03, cnt_TipoIntervalo_Mes)
        ComboBox_Possicionar(cboTipoIntervalo_04, cnt_TipoIntervalo_Mes)
        ComboBox_Possicionar(cboTipoIntervalo_05, cnt_TipoIntervalo_Mes)
        ComboBox_Possicionar(cboTipoIntervalo_06, cnt_TipoIntervalo_Mes)
        ComboBox_Possicionar(cboTipoIntervalo_07, cnt_TipoIntervalo_Mes)
        ComboBox_Possicionar(cboTipoIntervalo_08, cnt_TipoIntervalo_Mes)

        txtIntervalo_01.Value = 1
        txtIntervalo_02.Value = 2
        txtIntervalo_03.Value = 3
        txtIntervalo_04.Value = 4
        txtIntervalo_05.Value = 5
        txtIntervalo_06.Value = 6
        txtIntervalo_07.Value = 7
        txtIntervalo_08.Value = 8

        ComboBox_Possicionar(cboTipoIntervalo, cnt_TipoIntervalo_Mes)
        'Formatação do Controles de Intervalo - Fim
    End Sub

    Private Sub frmREL_Movimentacao_DataCacau_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub optOrigem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optOrigem_EstoqueAtual.CheckedChanged, _
                                                                                                             optOrigem_Industrializacao.CheckedChanged
        ValidarOrigem()
    End Sub

    Private Sub ValidarOrigem()
        txtDataFinal.Enabled = True
        grpPeriodo.Enabled = (optOrigem_Industrializacao.Checked) 'optOrigem_EstoquePassado.Checked Or)
        grpVisualizarPor.Visible = optOrigem_EstoqueAtual.Checked

        SelecaoFilialMovimentacao.Lista_Selecao_MarcarTodos(False)
        SelecaoFilialMovimentacao.Enabled = True

        If optOrigem_Industrializacao.Checked Then
            chkVisualizarPor_Armazem.Checked = False
            chkVisualizarPor_Pilha.Checked = False
            chkVisualizarPor_Tipo.Checked = True
            SelecaoFilialMovimentacao.Lista_Selecionar(FilialMae, True)
            SelecaoFilialMovimentacao.Enabled = False
        End If

        If Not grpPeriodo.Enabled Then
            txtDataInicial.DateTime = Now.Date
            txtDataFinal.DateTime = Now.Date
            'ElseIf optOrigem_EstoquePassado.Checked Then
            '    txtDataInicial.DateTime = Now.Date
            '    txtDataFinal.Enabled = False
        End If
    End Sub

    Private Sub CarregarIntervalo(ByVal oCombo As System.Windows.Forms.ComboBox)
        ComboBox_Carregar(oCombo, New String() {"Dia", "Semana", "Mês"}, _
                                  New Object() {cnt_TipoIntervalo_Dia, cnt_TipoIntervalo_Semana, cnt_TipoIntervalo_Mes})
    End Sub

    Private Function Imprimir_GerarDados() As DataTable
        Dim oData As New DataTable
        Dim oData_Aux_01 As DataTable
        Dim oData_Aux_02 As DataTable
        Dim oRow As DataRow
        Dim SqlText As String = ""
        Dim SqlText_Transf As String
        Dim SQ_MOVIMENTACAO As Integer
        Dim iCont As Integer
        Dim sTipoIntervalo_Identificar As String = ""

        With oData.Columns
            .Add("SQ_MOVIMENTACAO").DataType = System.Type.GetType("System.Int32")
            .Add("CD_ORDEM_DESCARGA").DataType = System.Type.GetType("System.String")
            .Add("NU_NF").DataType = System.Type.GetType("System.String")
            .Add("CD_PROCEDENCIA").DataType = System.Type.GetType("System.String")
            .Add("NO_FILIAL_MOVIMENTACAO").DataType = System.Type.GetType("System.String")
            .Add("NO_FILIAL_CACAU").DataType = System.Type.GetType("System.String")
            .Add("NO_ARMAZEM").DataType = System.Type.GetType("System.String")
            .Add("CD_PILHA").DataType = System.Type.GetType("System.Int32")
            .Add("NO_FORNECEDOR").DataType = System.Type.GetType("System.String")
            .Add("DT_ENTRADA").DataType = System.Type.GetType("System.DateTime")
            .Add("DT_CACAU").DataType = System.Type.GetType("System.DateTime")
            .Add("QT_ENTRADA").DataType = System.Type.GetType("System.Int32")
            .Add("DS_INTERVALO").DataType = System.Type.GetType("System.String")
        End With

        SqlText_Transf = "(SELECT T1.SQ_TRANSFERENCIA," & _
                                 "T1.SQ_MOVIMENTACAO_ENTRADA," & _
                                 "T2.SQ_MOVIMENTACAO," & _
                                 "T2.KG_TRANSFERIDO," & _
                                 "M1.CD_FORNECEDOR," & _
                                 "M1.DT_MOVIMENTACAO," & _
                                 "DECODE(NVL(MT.QT_KG_LIQUIDO_NF, 0), 0, T2.KG_TRANSFERIDO, T2.KG_TRANSFERIDO / MT.QT_KG_LIQUIDO_NF) PERC" & _
                          " FROM SOF.TRANSFERENCIA T1," & _
                                "SOF.ITEM_TRANSFERENCIA T2," & _
                                "SOF.TRANSFERENCIA_SUMMUS T3," & _
                                "SOF.MOVIMENTACAO M1," & _
                                "SOF.MOVIMENTACAO MT" & _
                          " WHERE T2.SQ_TRANSFERENCIA = T1.SQ_TRANSFERENCIA" & _
                            " AND MT.SQ_MOVIMENTACAO = T1.SQ_MOVIMENTACAO_SAIDA" & _
                            " AND M1.SQ_MOVIMENTACAO = T2.SQ_MOVIMENTACAO" & _
                            " AND T3.SQ_TRANSFERENCIA_LOGUS (+) = T1.SQ_TRANSFERENCIA" & _
                            " AND T3.DT_EXCLUSAO IS NULL)"

        Select Case True
            Case optOrigem_Industrializacao.Checked
                SqlText = "SELECT MV.CD_PROCEDENCIA," & _
                                 "MV.NU_ORDEM_DESCARGA," & _
                                 "NVL2(MV.NU_SERIE_NF, TRIM(MV.NU_NF) || '-' || TRIM(MV.NU_SERIE_NF), TRIM(MV.NU_NF)) NU_NF," & _
                                 "FN.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                                 "FM.NO_FILIAL NO_FILIAL_MOVIMENTACAO," & _
                                 "FO.NO_FILIAL NO_FILIAL_ORIGEM," & _
                                 "FO.CD_FILIAL CD_FILIAL_ORIGEM," & _
                                 "NVL2(MV.CD_FORNECEDOR, 'S', NVL2(OT.CD_FORNECEDOR, 'S', 'N')) IC_FORNECEDOR," & _
                                 "TR.DT_TRANSFERENCIA DT_MOVIMENTACAO," & _
                                 "NVL(OT.SQ_MOVIMENTACAO, MV.SQ_MOVIMENTACAO) SQ_MOVIMENTACAO," & _
                                 "OT.SQ_TRANSFERENCIA," & _
                                 "ROUND(SUM(IT.KG_TRANSFERIDO * NVL(OT.PERC, 1)), 0) QT_KG_A_TRANSFERIR," & _
                                 "NULL NO_ARMAZEM," & _
                                 "NULL CD_PILHA" & _
                          " FROM SOF.TRANSFERENCIA TR," & _
                                "SOF.TRANSFERENCIA_MODALIDADE TM," & _
                                "SOF.ITEM_TRANSFERENCIA IT," & _
                                "SOF.FILIAL FM," & _
                                "SOF.MOVIMENTACAO MV," & _
                                "SOF.FORNECEDOR FN," & _
                                "SOF.FILIAL FO," & _
                                SqlText_Transf & " OT" & _
                          " WHERE TR.DT_TRANSFERENCIA >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & _
                            " AND TR.DT_TRANSFERENCIA <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)) & _
                            " AND TM.CD_TRANSFERENCIA_MODALIDADE = TR.CD_TRANSFERENCIA_MODALIDADE" & _
                            " AND TM.IC_MOVIMENTACAO_SILO = 'S'" & _
                            " AND IT.SQ_TRANSFERENCIA = TR.SQ_TRANSFERENCIA" & _
                            " AND FM.CD_FILIAL = TR.CD_FILIAL_ORIGEM" & _
                            " AND MV.SQ_MOVIMENTACAO = IT.SQ_MOVIMENTACAO" & _
                            " AND FN.CD_FORNECEDOR (+) = MV.CD_FORNECEDOR" & _
                            " AND FO.CD_FILIAL (+) = MV.CD_FILIAL_MOVIMENTACAO" & _
                            " AND OT.SQ_MOVIMENTACAO_ENTRADA (+) = IT.SQ_MOVIMENTACAO" & _
                          " GROUP BY MV.CD_PROCEDENCIA," & _
                                    "MV.NU_ORDEM_DESCARGA," & _
                                    "NVL2(MV.NU_SERIE_NF, TRIM(MV.NU_NF) || '-' || TRIM(MV.NU_SERIE_NF), TRIM(MV.NU_NF))," & _
                                    "FN.NO_RAZAO_SOCIAL," & _
                                    "FM.NO_FILIAL," & _
                                    "FO.NO_FILIAL," & _
                                    "FO.CD_FILIAL," & _
                                    "NVL2(MV.CD_FORNECEDOR, 'S', NVL2(OT.CD_FORNECEDOR, 'S', 'N'))," & _
                                    "TR.DT_TRANSFERENCIA," & _
                                    "NVL(OT.SQ_MOVIMENTACAO, MV.SQ_MOVIMENTACAO)," & _
                                    "OT.SQ_TRANSFERENCIA"
            Case optOrigem_EstoqueAtual.Checked
                SqlText = "SELECT MV.CD_PROCEDENCIA," & _
                                 "MV.NU_ORDEM_DESCARGA," & _
                                 "NVL2(MV.NU_SERIE_NF, TRIM(MV.NU_NF) || '-' || TRIM(MV.NU_SERIE_NF), TRIM(MV.NU_NF)) NU_NF," & _
                                 "FN.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                                 "FM.NO_FILIAL NO_FILIAL_MOVIMENTACAO," & _
                                 "FO.NO_FILIAL NO_FILIAL_ORIGEM," & _
                                 "FO.CD_FILIAL CD_FILIAL_ORIGEM," & _
                                 "NVL2(MV.CD_FORNECEDOR, 'S', NVL2(OT.CD_FORNECEDOR, 'S', 'N')) IC_FORNECEDOR," & _
                                 "MV.DT_MOVIMENTACAO DT_MOVIMENTACAO," & _
                                 "NVL(OT.SQ_MOVIMENTACAO, MV.SQ_MOVIMENTACAO) SQ_MOVIMENTACAO," & _
                                 "OT.SQ_TRANSFERENCIA," & _
                                 "ROUND(SUM(MP.QT_VOLUME * NVL(OT.PERC, 1)), 0) QT_KG_A_TRANSFERIR," & _
                                 "AM.NO_ARMAZEM," & _
                                 "MP.CD_PILHA_ARMAZEM CD_PILHA" & _
                          " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM MP," & _
                                "SOF.ARMAZEM AM," & _
                                "SOF.FILIAL FM," & _
                                "SOF.MOVIMENTACAO MV," & _
                                "SOF.MOVIMENTACAO MF," & _
                                "SOF.FORNECEDOR FN," & _
                                "SOF.FILIAL FO," & _
                                SqlText_Transf & " OT" & _
                          " WHERE MV.SQ_MOVIMENTACAO = MP.SQ_MOVIMENTACAO" & _
                            " AND AM.CD_ARMAZEM = MP.CD_ARMAZEM" & _
                            " AND FM.CD_FILIAL = AM.CD_FILIAL_ORIGEM"

                If SelecaoFilialMovimentacao.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND AM.CD_FILIAL_ORIGEM IN (" & SelecaoFilialMovimentacao.Lista_ID & ")"
                End If

                SqlText = SqlText & _
                            " AND MF.SQ_MOVIMENTACAO = NVL(OT.SQ_MOVIMENTACAO, MV.SQ_MOVIMENTACAO)" & _
                            " AND FN.CD_FORNECEDOR (+) = MF.CD_FORNECEDOR" & _
                            " AND FO.CD_FILIAL (+) = MV.CD_FILIAL_MOVIMENTACAO" & _
                            " AND OT.SQ_MOVIMENTACAO_ENTRADA (+) = MP.SQ_MOVIMENTACAO" & _
                          " GROUP BY MV.CD_PROCEDENCIA," & _
                                    "MV.NU_ORDEM_DESCARGA," & _
                                    "NVL2(MV.NU_SERIE_NF, TRIM(MV.NU_NF) || '-' || TRIM(MV.NU_SERIE_NF), TRIM(MV.NU_NF))," & _
                                    "FN.NO_RAZAO_SOCIAL," & _
                                    "FM.NO_FILIAL," & _
                                    "FO.NO_FILIAL," & _
                                    "FO.CD_FILIAL," & _
                                    "NVL2(MV.CD_FORNECEDOR, 'S', NVL2(OT.CD_FORNECEDOR, 'S', 'N'))," & _
                                    "MV.DT_MOVIMENTACAO," & _
                                    "NVL(OT.SQ_MOVIMENTACAO, MV.SQ_MOVIMENTACAO)," & _
                                    "OT.SQ_TRANSFERENCIA," & _
                                    "AM.NO_ARMAZEM," & _
                                    "MP.CD_PILHA_ARMAZEM"
                'Case optOrigem_EstoquePassado.Checked
                '    SqlText = "SELECT MV.CD_PROCEDENCIA," & _
                '                     "MV.NU_ORDEM_DESCARGA," & _
                '                     "NVL2(MV.NU_SERIE_NF, TRIM(MV.NU_NF) || '-' || TRIM(MV.NU_SERIE_NF), TRIM(MV.NU_NF)) NU_NF," & _
                '                     "FN.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                '                     "FM.NO_FILIAL NO_FILIAL_MOVIMENTACAO," & _
                '                     "NVL2(MV.CD_FORNECEDOR, 'S', NVL2(OT.CD_FORNECEDOR, 'S', 'N')) IC_FORNECEDOR," & _
                '                     "MV.DT_MOVIMENTACAO DT_MOVIMENTACAO," & _
                '                     "NVL(OT.SQ_MOVIMENTACAO, MV.SQ_MOVIMENTACAO) SQ_MOVIMENTACAO," & _
                '                     "OT.SQ_TRANSFERENCIA," & _
                '                     "ROUND(SUM(MP.QT_VOLUME * NVL(OT.PERC, 1)), 0) QT_KG_A_TRANSFERIR" & _
                '              " FROM (SELECT CD_ARMAZEM," & _
                '                            "CD_PILHA_ARMAZEM," & _
                '                            "SQ_MOVIMENTACAO," & _
                '                            "SUM(QT_VOLUME) QT_VOLUME" & _
                '                     " FROM (SELECT MOV.CD_ARMAZEM," & _
                '                                   "MOV.CD_PILHA_ARMAZEM," & _
                '                                   "MOV.SQ_MOVIMENTACAO," & _
                '                                   "MOV.SQ_MOV_PILHA_ARMAZEM_HISTORICO," & _
                '                                   "MOV.DT_TRANSACAO," & _
                '                                   "NVL(TD.IC_TIPO_UTILIZACAO, NVL(TM.IC_TIPO_UTILIZACAO, 'X')) IC_TIPO_UTILIZACAO," & _
                '                                   "SUM(MOV.QT_VOLUME * DECODE(MOV.IC_SAIDA, 'S', -1, 1)) QT_VOLUME" & _
                '                            " FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO MOV," & _
                '                                  "SOF.ARMAZEM ARM," & _
                '                                  "SOF.TRANSFERENCIA TR," & _
                '                                  "SOF.TRANSFERENCIA_MODALIDADE TD," & _
                '                                  "SOF.MOVIMENTACAO MV," & _
                '                                  "SOF.TIPO_MOVIMENTACAO TM" & _
                '                            " WHERE ARM.CD_ARMAZEM = MOV.CD_ARMAZEM" & _
                '                              " AND TR.SQ_TRANSFERENCIA (+) = MOV.SQ_TRANSFERENCIA" & _
                '                              " AND TD.CD_TRANSFERENCIA_MODALIDADE (+) = TR.CD_TRANSFERENCIA_MODALIDADE" & _
                '                              " AND MV.SQ_MOVIMENTACAO (+) = MOV.SQ_MOVIMENTACAO" & _
                '                              " AND TM.CD_TIPO_MOVIMENTACAO (+) = MV.CD_TIPO_MOVIMENTACAO" & _
                '                            " GROUP BY MOV.CD_ARMAZEM," & _
                '                                      "MOV.CD_PILHA_ARMAZEM," & _
                '                                      "MOV.SQ_MOVIMENTACAO," & _
                '                                      "MOV.SQ_MOV_PILHA_ARMAZEM_HISTORICO," & _
                '                                      "MOV.DT_TRANSACAO," & _
                '                                      "NVL(TD.IC_TIPO_UTILIZACAO, NVL(TM.IC_TIPO_UTILIZACAO, 'X')))" & _
                '                     " WHERE DT_TRANSACAO <= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & _
                '                       " AND IC_TIPO_UTILIZACAO <> 'T'" & _
                '                     " GROUP BY CD_ARMAZEM," & _
                '                               "CD_PILHA_ARMAZEM," & _
                '                               "SQ_MOVIMENTACAO" & _
                '                     " HAVING SUM(QT_VOLUME) <> 0) MP," & _
                '                    "SOF.MOVIMENTACAO MV," & _
                '                    "SOF.FORNECEDOR FN," & _
                '                    "SOF.FILIAL FM," & _
                '                    SqlText_Transf & " OT" & _
                '              " WHERE MV.SQ_MOVIMENTACAO = MP.SQ_MOVIMENTACAO" & _
                '                " AND FN.CD_FORNECEDOR (+) = MV.CD_FORNECEDOR" & _
                '                " AND FM.CD_FILIAL (+) = MV.CD_FILIAL_MOVIMENTACAO" & _
                '                " AND OT.SQ_MOVIMENTACAO_ENTRADA (+) = MP.SQ_MOVIMENTACAO" & _
                '              " GROUP BY MV.CD_PROCEDENCIA," & _
                '                        "MV.NU_ORDEM_DESCARGA," & _
                '                        "NVL2(MV.NU_SERIE_NF, TRIM(MV.NU_NF) || '-' || TRIM(MV.NU_SERIE_NF), TRIM(MV.NU_NF))," & _
                '                        "FN.NO_RAZAO_SOCIAL," & _
                '                        "FM.NO_FILIAL," & _
                '                        "NVL2(MV.CD_FORNECEDOR, 'S', NVL2(OT.CD_FORNECEDOR, 'S', 'N'))," & _
                '                        "MV.DT_MOVIMENTACAO," & _
                '                        "NVL(OT.SQ_MOVIMENTACAO, MV.SQ_MOVIMENTACAO)," & _
                '                        "OT.SQ_TRANSFERENCIA"
            Case False
                Return Nothing
                Exit Function
        End Select

        oData_Aux_01 = DBQuery(SqlText)

        For iCont = 0 To oData_Aux_01.Rows.Count - 1
            With oData_Aux_01.Rows(iCont)
                oRow = oData.NewRow
                oRow.Item("SQ_MOVIMENTACAO") = .Item("SQ_MOVIMENTACAO")
                oRow.Item("CD_ORDEM_DESCARGA") = .Item("NU_ORDEM_DESCARGA")
                oRow.Item("NU_NF") = .Item("NU_NF")
                oRow.Item("CD_PROCEDENCIA") = .Item("CD_PROCEDENCIA")
                oRow.Item("QT_ENTRADA") = .Item("QT_KG_A_TRANSFERIR")
                oRow.Item("DT_ENTRADA") = .Item("DT_MOVIMENTACAO")
                oRow.Item("NO_ARMAZEM") = .Item("NO_ARMAZEM")
                oRow.Item("CD_PILHA") = .Item("CD_PILHA")
                oRow.Item("NO_FILIAL_MOVIMENTACAO") = .Item("NO_FILIAL_MOVIMENTACAO")

                If .Item("IC_FORNECEDOR") = "S" Then
                    oRow.Item("NO_FILIAL_CACAU") = .Item("NO_FILIAL_ORIGEM")
                    oRow.Item("NO_FORNECEDOR") = .Item("NO_FORNECEDOR")
                    oRow.Item("DT_CACAU") = .Item("DT_MOVIMENTACAO")
                Else
                    SQ_MOVIMENTACAO = Movimentacao_Transf_IdentificarOrigem(.Item("SQ_MOVIMENTACAO"), NVL(.Item("SQ_TRANSFERENCIA"), 0))

                    If SQ_MOVIMENTACAO > 0 Then
                        SqlText = "SELECT FI.CD_FILIAL," & _
                                         "FN.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                                         "FI.NO_FILIAL NO_FILIAL_MOVIMENTACAO," & _
                                         "MV.DT_MOVIMENTACAO" & _
                                  " FROM SOF.MOVIMENTACAO MV," & _
                                        "SOF.FORNECEDOR FN," & _
                                        "SOF.FILIAL FI" & _
                                  " WHERE MV.SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                                    " AND FN.CD_FORNECEDOR = MV.CD_FORNECEDOR" & _
                                    " AND FI.CD_FILIAL = MV.CD_FILIAL_MOVIMENTACAO"
                        oData_Aux_02 = DBQuery(SqlText)

                        With oData_Aux_02.Rows(0)
                            oRow.Item("NO_FILIAL_CACAU") = .Item("NO_FILIAL_MOVIMENTACAO")
                            oRow.Item("NO_FORNECEDOR") = .Item("NO_FORNECEDOR")
                            oRow.Item("DT_CACAU") = .Item("DT_MOVIMENTACAO")
                        End With
                    End If
                End If

                If optOrigem_Industrializacao.Checked Then
                    TipoIntervalo_Identificar(NVL(oRow.Item("DT_CACAU"), oRow.Item("DT_ENTRADA")), _
                                              oRow.Item("DT_ENTRADA"), _
                                              sTipoIntervalo_Identificar)
                ElseIf optOrigem_EstoqueAtual.Checked Then
                    TipoIntervalo_Identificar(NVL(oRow.Item("DT_CACAU"), Now.Date), _
                                              oRow.Item("DT_ENTRADA"), _
                                              sTipoIntervalo_Identificar)
                End If

                oRow.Item("DS_INTERVALO") = sTipoIntervalo_Identificar

                If SelecaoFilialRecebimento.Lista_Quantidade = 0 Then
                    oData.Rows.Add(oRow)
                Else
                    If .Item("IC_FORNECEDOR") = "S" Then
                        If SelecaoFilialRecebimento.Lista_Selecionado(Trim(.Item("CD_FILIAL_ORIGEM"))) Then
                            oData.Rows.Add(oRow)
                        End If
                    Else
                        If SelecaoFilialRecebimento.Lista_Selecionado(Trim(oData_Aux_02.Rows(0).Item("CD_FILIAL"))) Then
                            oData.Rows.Add(oRow)
                        End If
                    End If
                End If
            End With
        Next

        Return oData
    End Function

    Private Sub TipoIntervaloValidar()
        Dim bAvulso As Boolean

        If ComboBox_LinhaSelecionada(cboTipoIntervalo) Then
            bAvulso = (cboTipoIntervalo.SelectedValue = cnt_TipoIntervalo_Avulso)
        End If

        txtIntervalo_01.Enabled = bAvulso
        txtIntervalo_02.Enabled = bAvulso
        txtIntervalo_03.Enabled = bAvulso
        txtIntervalo_04.Enabled = bAvulso
        txtIntervalo_05.Enabled = bAvulso
        txtIntervalo_06.Enabled = bAvulso
        txtIntervalo_07.Enabled = bAvulso
        txtIntervalo_08.Enabled = bAvulso
        cboTipoIntervalo_01.Enabled = bAvulso
        cboTipoIntervalo_02.Enabled = bAvulso
        cboTipoIntervalo_03.Enabled = bAvulso
        cboTipoIntervalo_04.Enabled = bAvulso
        cboTipoIntervalo_05.Enabled = bAvulso
        cboTipoIntervalo_06.Enabled = bAvulso
        cboTipoIntervalo_07.Enabled = bAvulso
        cboTipoIntervalo_08.Enabled = bAvulso

        txtIntervalo.Enabled = Not (bAvulso)
        If Not txtIntervalo.Enabled Then
            txtIntervalo.Value = 1
        End If

        TipoIntervalo_Calcular()
    End Sub

    Private Sub TipoIntervalo_Calcular()
        Dim bAvulso As Boolean

        If ComboBox_LinhaSelecionada(cboTipoIntervalo) Then
            bAvulso = (cboTipoIntervalo.SelectedValue = cnt_TipoIntervalo_Avulso)
        End If

        If Not bAvulso Then
            ComboBox_Possicionar(cboTipoIntervalo_01, cboTipoIntervalo.SelectedValue)
            ComboBox_Possicionar(cboTipoIntervalo_02, cboTipoIntervalo.SelectedValue)
            ComboBox_Possicionar(cboTipoIntervalo_03, cboTipoIntervalo.SelectedValue)
            ComboBox_Possicionar(cboTipoIntervalo_04, cboTipoIntervalo.SelectedValue)
            ComboBox_Possicionar(cboTipoIntervalo_05, cboTipoIntervalo.SelectedValue)
            ComboBox_Possicionar(cboTipoIntervalo_06, cboTipoIntervalo.SelectedValue)
            ComboBox_Possicionar(cboTipoIntervalo_07, cboTipoIntervalo.SelectedValue)
            ComboBox_Possicionar(cboTipoIntervalo_08, cboTipoIntervalo.SelectedValue)

            txtIntervalo_01.Value = 1
            txtIntervalo_02.Value = txtIntervalo_01.Value + txtIntervalo.Value
            txtIntervalo_03.Value = txtIntervalo_02.Value + txtIntervalo.Value
            txtIntervalo_04.Value = txtIntervalo_03.Value + txtIntervalo.Value
            txtIntervalo_05.Value = txtIntervalo_04.Value + txtIntervalo.Value
            txtIntervalo_06.Value = txtIntervalo_05.Value + txtIntervalo.Value
            txtIntervalo_07.Value = txtIntervalo_06.Value + txtIntervalo.Value
            txtIntervalo_08.Value = txtIntervalo_07.Value + txtIntervalo.Value
        End If

        If EhData(txtDataInicial.Text) Then
            txtIntervalo_01.Tag = TipoIntervalo_TransformaDias(NVL(cboTipoIntervalo_01.SelectedValue, 0), txtIntervalo_01.Value)
            txtIntervalo_02.Tag = TipoIntervalo_TransformaDias(NVL(cboTipoIntervalo_02.SelectedValue, 0), txtIntervalo_02.Value)
            txtIntervalo_03.Tag = TipoIntervalo_TransformaDias(NVL(cboTipoIntervalo_03.SelectedValue, 0), txtIntervalo_03.Value)
            txtIntervalo_04.Tag = TipoIntervalo_TransformaDias(NVL(cboTipoIntervalo_04.SelectedValue, 0), txtIntervalo_04.Value)
            txtIntervalo_05.Tag = TipoIntervalo_TransformaDias(NVL(cboTipoIntervalo_05.SelectedValue, 0), txtIntervalo_05.Value)
            txtIntervalo_06.Tag = TipoIntervalo_TransformaDias(NVL(cboTipoIntervalo_06.SelectedValue, 0), txtIntervalo_06.Value)
            txtIntervalo_07.Tag = TipoIntervalo_TransformaDias(NVL(cboTipoIntervalo_07.SelectedValue, 0), txtIntervalo_07.Value)
            txtIntervalo_08.Tag = TipoIntervalo_TransformaDias(NVL(cboTipoIntervalo_08.SelectedValue, 0), txtIntervalo_08.Value)
        End If

        TipoIntervalo_TextoIntervalo()
    End Sub

    Private Function TipoIntervalo_TransformaDias(ByVal TipoIntervalo As Integer, ByVal ValorIntervalo As Double) As Integer
        Select Case TipoIntervalo
            Case cnt_TipoIntervalo_Dia
                Return DateDiff(DateInterval.Day, txtDataInicial.DateTime.AddDays(ValorIntervalo * -1).Date, txtDataInicial.DateTime.Date)
            Case cnt_TipoIntervalo_Semana
                Return DateDiff(DateInterval.Day, txtDataInicial.DateTime.AddDays(ValorIntervalo * 7 * -1).Date, txtDataInicial.DateTime.Date)
            Case cnt_TipoIntervalo_Mes
                Return DateDiff(DateInterval.Day, txtDataInicial.DateTime.AddMonths(ValorIntervalo * -1).Date, txtDataInicial.DateTime.Date)
        End Select
    End Function

    Private Function TipoIntervalo_Texto(ByVal TipoIntervalo As Integer, ByVal bSingular As Boolean) As String
        Select Case TipoIntervalo
            Case cnt_TipoIntervalo_Dia
                Return IIf(bSingular, "Dia", "Dias")
            Case cnt_TipoIntervalo_Semana
                Return IIf(bSingular, "Semana", "Semanas")
            Case cnt_TipoIntervalo_Mes
                Return IIf(bSingular, "Mês", "Meses")
            Case Else
                Return ""
        End Select
    End Function

    Private Sub TipoIntervalo_TextoIntervalo()
        TipoIntervalo01 = Trim(txtIntervalo_01.Value) & " " & TipoIntervalo_Texto(cboTipoIntervalo_01.SelectedValue, txtIntervalo_01.Value = 1)
        TipoIntervalo02 = Trim(txtIntervalo_02.Value) & " " & TipoIntervalo_Texto(cboTipoIntervalo_02.SelectedValue, txtIntervalo_02.Value = 1)
        TipoIntervalo03 = Trim(txtIntervalo_03.Value) & " " & TipoIntervalo_Texto(cboTipoIntervalo_03.SelectedValue, txtIntervalo_03.Value = 1)
        TipoIntervalo04 = Trim(txtIntervalo_04.Value) & " " & TipoIntervalo_Texto(cboTipoIntervalo_04.SelectedValue, txtIntervalo_04.Value = 1)
        TipoIntervalo05 = Trim(txtIntervalo_05.Value) & " " & TipoIntervalo_Texto(cboTipoIntervalo_05.SelectedValue, txtIntervalo_05.Value = 1)
        TipoIntervalo06 = Trim(txtIntervalo_06.Value) & " " & TipoIntervalo_Texto(cboTipoIntervalo_06.SelectedValue, txtIntervalo_06.Value = 1)
        TipoIntervalo07 = Trim(txtIntervalo_07.Value) & " " & TipoIntervalo_Texto(cboTipoIntervalo_07.SelectedValue, txtIntervalo_07.Value = 1)
        TipoIntervalo08 = Trim(txtIntervalo_08.Value) & " " & TipoIntervalo_Texto(cboTipoIntervalo_08.SelectedValue, txtIntervalo_08.Value = 1)
        TipoIntervalo09 = " > " & Trim(txtIntervalo_08.Value) & " " & TipoIntervalo_Texto(cboTipoIntervalo_08.SelectedValue, txtIntervalo_08.Value = 1)
        TipoIntervalo_Dia_01 = Trim(txtIntervalo_01.Tag) + " dia(s)"
        TipoIntervalo_Dia_02 = Trim(txtIntervalo_02.Tag) + " dia(s)"
        TipoIntervalo_Dia_03 = Trim(txtIntervalo_03.Tag) + " dia(s)"
        TipoIntervalo_Dia_04 = Trim(txtIntervalo_04.Tag) + " dia(s)"
        TipoIntervalo_Dia_05 = Trim(txtIntervalo_05.Tag) + " dia(s)"
        TipoIntervalo_Dia_06 = Trim(txtIntervalo_06.Tag) + " dia(s)"
        TipoIntervalo_Dia_07 = Trim(txtIntervalo_07.Tag) + " dia(s)"
        TipoIntervalo_Dia_08 = Trim(txtIntervalo_08.Tag) + " dia(s)"
        TipoIntervalo_Dia_09 = "> " + Trim(txtIntervalo_08.Tag) + " dia(s)"
    End Sub

    Private Function TipoIntervalo_Identificar(ByVal Data_Entrada As Date, _
                                               ByVal Data_Verificacao As Date, _
                                               Optional ByRef sTexto As String = "") As Integer
        Dim iDias As Integer

        iDias = DateDiff(DateInterval.Day, Data_Entrada, Data_Verificacao)

        If iDias <= txtIntervalo_01.Tag Then
            sTexto = TipoIntervalo01
            Return 1
        ElseIf iDias <= txtIntervalo_02.Tag Then
            sTexto =TipoIntervalo02
            Return 2
        ElseIf iDias <= txtIntervalo_03.Tag Then
            sTexto = TipoIntervalo03
            Return 3
        ElseIf iDias <= txtIntervalo_04.Tag Then
            sTexto =TipoIntervalo04
            Return 4
        ElseIf iDias <= txtIntervalo_05.Tag Then
            sTexto =TipoIntervalo05
            Return 5
        ElseIf iDias <= txtIntervalo_06.Tag Then
            sTexto = TipoIntervalo06
            Return 6
        ElseIf iDias <= txtIntervalo_07.Tag Then
            sTexto = TipoIntervalo07
            Return 7
        ElseIf iDias <= txtIntervalo_08.Tag Then
            sTexto = TipoIntervalo08
            Return 8
        Else
            sTexto = TipoIntervalo09
            Return 9
        End If
    End Function

    Private Function Movimentacao_Transf_IdentificarOrigem(ByVal SQ_MOVIMENTACAO As Integer, _
                                                           ByVal SQ_TRANSFERENCIA As Integer, _
                                                           Optional ByVal NR_NIVEL_MAXIMO As Integer = 0) As Integer
        Dim oData As DataTable
        Dim SqlText As String
        Dim dDataRealizouMovimentacao As Date
        Dim iQuantidadeMovimentacao As Double
        Dim CD_ARMAZEM As Integer
        Dim CD_PILHA As Integer
        Dim iAux As Integer
        Dim iCont As Integer

        If NR_NIVEL_MAXIMO > 50 Then
            Return -1
            Exit Function
        End If

        'Identifica o horário da movimentação
        If SQ_TRANSFERENCIA > 0 Then
            SqlText = "SELECT CD_ARMAZEM," & _
                             "CD_PILHA_ARMAZEM," & _
                             "QT_VOLUME," & _
                             "DT_CRIACAO" & _
                      " FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO" & _
                      " WHERE SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                        " AND SQ_TRANSFERENCIA = " & SQ_TRANSFERENCIA
            oData = DBQuery(SqlText)

            If Not objDataTable_Vazio(oData) Then
                With oData.Rows(0)
                    CD_ARMAZEM = .Item("CD_ARMAZEM")
                    CD_PILHA = .Item("CD_PILHA_ARMAZEM")
                    dDataRealizouMovimentacao = .Item("DT_CRIACAO")
                    iQuantidadeMovimentacao = .Item("QT_VOLUME")
                End With

                'Identifica a quantidade anteriormente movimentada
                SqlText = "SELECT SUM(QT_VOLUME)" & _
                          " FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO" & _
                          " WHERE CD_ARMAZEM = " & CD_ARMAZEM & _
                            " AND CD_PILHA_ARMAZEM = " & CD_PILHA & _
                            " AND SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                            " AND IC_SAIDA = 'S'" & _
                            " AND DT_CRIACAO < " & Date_to_Oracle(dDataRealizouMovimentacao)
                iAux = DBQuery_ValorUnico(SqlText, 0)
            End If
        End If

        'Identifica a movimentação
        SqlText = "SELECT MV.DT_MOVIMENTACAO," & _
                         "NVL2(CD_FORNECEDOR, 'S', 'N') IC_FORNECEDOR," & _
                         "IT.*" & _
                  " FROM SOF.TRANSFERENCIA TR," & _
                        "SOF.ITEM_TRANSFERENCIA IT," & _
                        "SOF.MOVIMENTACAO MV" & _
                  " WHERE TR.SQ_MOVIMENTACAO_ENTRADA = " & SQ_MOVIMENTACAO & _
                    " AND IT.SQ_TRANSFERENCIA = TR.SQ_TRANSFERENCIA" & _
                    " AND MV.SQ_MOVIMENTACAO = IT.SQ_MOVIMENTACAO" & _
                  " ORDER BY MV.DT_MOVIMENTACAO, MV.DT_CRIACAO"
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            With oData.Rows(iCont)
                If iAux - NVL(.Item("KG_TRANSFERIDO"), 0) <= 0 Then
                    SqlText = "SELECT NVL(CD_FORNECEDOR, 0)" & _
                              " FROM SOF.MOVIMENTACAO" & _
                              " WHERE SQ_MOVIMENTACAO = " & .Item("SQ_MOVIMENTACAO")

                    If .Item("IC_FORNECEDOR") = "S" Then
                        Return .Item("SQ_MOVIMENTACAO")
                    Else
                        Return Movimentacao_Transf_IdentificarOrigem(.Item("SQ_MOVIMENTACAO"), 0, NR_NIVEL_MAXIMO + 1)
                    End If
                Else
                    iAux = iAux - NVL(.Item("KG_TRANSFERIDO"), 0)
                End If
            End With
        Next
    End Function

    Private Sub cboTipoIntervalo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoIntervalo.SelectedIndexChanged
        TipoIntervaloValidar()
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Dim oData_Analitico As DataTable
        Dim oData_Sintetico As DataTable
        Dim sFiltro As String = ""
        Dim sAux As String = ""
        Dim sTIPO_RELATORIO As String = ""

        TipoIntervalo_Calcular()

        If txtIntervalo_01.Tag >= txtIntervalo_02.Tag Or _
           txtIntervalo_02.Tag >= txtIntervalo_03.Tag Or _
           txtIntervalo_03.Tag >= txtIntervalo_04.Tag Or _
           txtIntervalo_04.Tag >= txtIntervalo_05.Tag Or _
           txtIntervalo_05.Tag >= txtIntervalo_06.Tag Or _
           txtIntervalo_06.Tag >= txtIntervalo_07.Tag Or _
           txtIntervalo_07.Tag >= txtIntervalo_08.Tag Then
            Msg_Mensagem("Existe divergência na sequencia de intervalo")
            Exit Sub
        End If

        oData_Analitico = Imprimir_GerarDados()

        If objDataTable_Vazio(oData_Analitico) Then
            Msg_Mensagem("Sem informações para gerar o relatório")
            Exit Sub
        End If

        If optTipo_Sintetico.Checked Then
            Dim oDataVisualizar As DataTable
            Dim oRow As DataRow = Nothing
            Dim iCont_01 As Integer
            Dim iCont_02 As Integer
            Dim iCont_03 As Integer
            Dim bAchou As Boolean
            Dim dVolumeTotal As Double
            Dim CD_ORIGEM As String
            Dim DS_GRUPO As String = ""
            Dim dData As Date

            oData_Sintetico = New DataTable

            With oData_Sintetico.Columns
                .Add("IC_ORIGEM").DataType = System.Type.GetType("System.String")
                .Add("CD_ORIGEM").DataType = System.Type.GetType("System.String")
                .Add("PC_ORIGEM").DataType = System.Type.GetType("System.Double")
                .Add("DS_GRUPO").DataType = System.Type.GetType("System.String")
                .Add("QT_INTERVALO_01").DataType = System.Type.GetType("System.Int32")
                .Add("QT_INTERVALO_02").DataType = System.Type.GetType("System.Int32")
                .Add("QT_INTERVALO_03").DataType = System.Type.GetType("System.Int32")
                .Add("QT_INTERVALO_04").DataType = System.Type.GetType("System.Int32")
                .Add("QT_INTERVALO_05").DataType = System.Type.GetType("System.Int32")
                .Add("QT_INTERVALO_06").DataType = System.Type.GetType("System.Int32")
                .Add("QT_INTERVALO_07").DataType = System.Type.GetType("System.Int32")
                .Add("QT_INTERVALO_08").DataType = System.Type.GetType("System.Int32")
                .Add("QT_INTERVALO_09").DataType = System.Type.GetType("System.Int32")
            End With

            If Not chkVisualizarPor_Armazem.Checked And _
               Not chkVisualizarPor_Pilha.Checked And _
               Not chkVisualizarPor_Tipo.Checked Then
                chkVisualizarPor_Tipo.Checked = True
            End If

            'Criar o data do os tipos de agrupamentos - Início
            oDataVisualizar = New DataTable

            oDataVisualizar.Columns.Add("IC_ORIGEM", System.Type.GetType("System.String"))

            If chkVisualizarPor_Armazem.Checked Then oDataVisualizar.Rows.Add(New Object() {"AM"})
            If chkVisualizarPor_Pilha.Checked Then oDataVisualizar.Rows.Add(New Object() {"PL"})
            If chkVisualizarPor_Tipo.Checked Then oDataVisualizar.Rows.Add(New Object() {"TP"})
            'Criar o data do os tipos de agrupamentos - Fim

            'Monta o Data Sintético
            For iCont_01 = 0 To oDataVisualizar.Rows.Count - 1
                dVolumeTotal = 0

                For iCont_02 = 0 To oData_Analitico.Rows.Count - 1
                    bAchou = False
                    DS_GRUPO = ""

                    With oData_Analitico.Rows(iCont_02)
                        Select Case oDataVisualizar.Rows(iCont_01).Item("IC_ORIGEM")
                            Case "AM"
                                CD_ORIGEM = .Item("NO_ARMAZEM")
                            Case "PL"
                                CD_ORIGEM = .Item("CD_PILHA")
                                DS_GRUPO = .Item("NO_ARMAZEM")
                            Case "TP"
                                CD_ORIGEM = .Item("CD_PROCEDENCIA")
                            Case Else
                                CD_ORIGEM = ""
                        End Select

                        For iCont_03 = 0 To oData_Sintetico.Rows.Count - 1
                            If NVL(oData_Sintetico.Rows(iCont_03).Item("CD_ORIGEM"), "") = NVL(CD_ORIGEM, "") And _
                              NVL(oData_Sintetico.Rows(iCont_03).Item("DS_GRUPO"), "") = DS_GRUPO Then
                                bAchou = True
                                oRow = oData_Sintetico.Rows(iCont_03)
                                Exit For
                            End If
                        Next

                        If Not bAchou Then
                            oRow = oData_Sintetico.NewRow
                            oRow.Item("IC_ORIGEM") = oDataVisualizar.Rows(iCont_01).Item(0)
                            oRow.Item("CD_ORIGEM") = CD_ORIGEM
                            oRow.Item("DS_GRUPO") = DS_GRUPO
                            oRow.Item("QT_INTERVALO_01") = 0
                            oRow.Item("QT_INTERVALO_02") = 0
                            oRow.Item("QT_INTERVALO_03") = 0
                            oRow.Item("QT_INTERVALO_04") = 0
                            oRow.Item("QT_INTERVALO_05") = 0
                            oRow.Item("QT_INTERVALO_06") = 0
                            oRow.Item("QT_INTERVALO_07") = 0
                            oRow.Item("QT_INTERVALO_08") = 0
                            oRow.Item("QT_INTERVALO_09") = 0
                        End If

                        If optOrigem_EstoqueAtual.Checked Then
                            dData = Now.Date
                        ElseIf optOrigem_Industrializacao.Checked Then
                            dData = Now.Date
                        End If

                        Select Case TipoIntervalo_Identificar(NVL(.Item("DT_CACAU"), .Item("DT_ENTRADA")), dData, "")
                            Case 1
                                oRow.Item("QT_INTERVALO_01") = NVL(oRow.Item("QT_INTERVALO_01"), 0) + NVL(.Item("QT_ENTRADA"), 0)
                            Case 2
                                oRow.Item("QT_INTERVALO_02") = NVL(oRow.Item("QT_INTERVALO_02"), 0) + NVL(.Item("QT_ENTRADA"), 0)
                            Case 3
                                oRow.Item("QT_INTERVALO_03") = NVL(oRow.Item("QT_INTERVALO_03"), 0) + NVL(.Item("QT_ENTRADA"), 0)
                            Case 4
                                oRow.Item("QT_INTERVALO_04") = NVL(oRow.Item("QT_INTERVALO_04"), 0) + NVL(.Item("QT_ENTRADA"), 0)
                            Case 5
                                oRow.Item("QT_INTERVALO_05") = NVL(oRow.Item("QT_INTERVALO_05"), 0) + NVL(.Item("QT_ENTRADA"), 0)
                            Case 6
                                oRow.Item("QT_INTERVALO_06") = NVL(oRow.Item("QT_INTERVALO_06"), 0) + NVL(.Item("QT_ENTRADA"), 0)
                            Case 7
                                oRow.Item("QT_INTERVALO_07") = NVL(oRow.Item("QT_INTERVALO_07"), 0) + NVL(.Item("QT_ENTRADA"), 0)
                            Case 8
                                oRow.Item("QT_INTERVALO_08") = NVL(oRow.Item("QT_INTERVALO_08"), 0) + NVL(.Item("QT_ENTRADA"), 0)
                            Case 9
                                oRow.Item("QT_INTERVALO_09") = NVL(oRow.Item("QT_INTERVALO_09"), 0) + NVL(.Item("QT_ENTRADA"), 0)
                        End Select

                        dVolumeTotal = dVolumeTotal + NVL(.Item("QT_ENTRADA"), 0)

                        If Not bAchou Then
                            oData_Sintetico.Rows.Add(oRow)
                        End If
                    End With
                Next

                'Calcula a porcentagem por origem
                For iCont_02 = 0 To oData_Sintetico.Rows.Count - 1
                    With oData_Sintetico.Rows(iCont_02)
                        .Item("PC_ORIGEM") = ((NVL(.Item("QT_INTERVALO_01"), 0) + NVL(.Item("QT_INTERVALO_02"), 0) + _
                                               NVL(.Item("QT_INTERVALO_03"), 0) + NVL(.Item("QT_INTERVALO_04"), 0) + _
                                               NVL(.Item("QT_INTERVALO_05"), 0) + NVL(.Item("QT_INTERVALO_06"), 0) + _
                                               NVL(.Item("QT_INTERVALO_07"), 0) + NVL(.Item("QT_INTERVALO_08"), 0) + _
                                               NVL(.Item("QT_INTERVALO_09"), 0)) / dVolumeTotal) * 100
                    End With
                Next
            Next
        End If

        If optTipo_Analitico.Checked Then
            Str_Adicionar(sFiltro, "Analítico", " - ")
        Else
            Str_Adicionar(sFiltro, "Sintético", " - ")

            sAux = Trim(IIf(chkVisualizarPor_Armazem.Checked, "por Armazém, ", "") & _
                        IIf(chkVisualizarPor_Pilha.Checked, "por Pilha, ", "") & _
                        IIf(chkVisualizarPor_Tipo.Checked, "por Tipo, ", ""))
            sAux = Mid(sAux, 1, Len(sAux) - 1)

            Str_Adicionar(sFiltro, "Visualizar: " & sAux, " - ")
        End If

        Select Case True
            Case optOrigem_Industrializacao.Checked
                Str_Adicionar(sFiltro, "Período: " & txtDataInicial.Text & " à " & txtDataFinal.Text, " - ")
                'Case optOrigem_EstoquePassado.Checked
                '    Str_Adicionar(sFiltro, "Data: " & txtDataInicial.Text, " - ")
        End Select

        If optTipo_Sintetico.Checked Then
            oRelatorio.Load(Application.StartupPath & "\RPT_MovEsotqueCacau_DataCacau_Sintetico.rpt")
            oRelatorio.SetDataSource(oData_Sintetico)
            oRelatorio.SetParameterValue("DS_INTERVALO_01", TipoIntervalo01)
            oRelatorio.SetParameterValue("DS_INTERVALO_02", TipoIntervalo02)
            oRelatorio.SetParameterValue("DS_INTERVALO_03", TipoIntervalo03)
            oRelatorio.SetParameterValue("DS_INTERVALO_04", TipoIntervalo04)
            oRelatorio.SetParameterValue("DS_INTERVALO_05", TipoIntervalo05)
            oRelatorio.SetParameterValue("DS_INTERVALO_06", TipoIntervalo06)
            oRelatorio.SetParameterValue("DS_INTERVALO_07", TipoIntervalo07)
            oRelatorio.SetParameterValue("DS_INTERVALO_08", TipoIntervalo08)
            oRelatorio.SetParameterValue("DS_INTERVALO_09", TipoIntervalo09)
            oRelatorio.SetParameterValue("DS_INTERVALO_DIA_01", TipoIntervalo_Dia_01)
            oRelatorio.SetParameterValue("DS_INTERVALO_DIA_02", TipoIntervalo_Dia_02)
            oRelatorio.SetParameterValue("DS_INTERVALO_DIA_03", TipoIntervalo_Dia_03)
            oRelatorio.SetParameterValue("DS_INTERVALO_DIA_04", TipoIntervalo_Dia_04)
            oRelatorio.SetParameterValue("DS_INTERVALO_DIA_05", TipoIntervalo_Dia_05)
            oRelatorio.SetParameterValue("DS_INTERVALO_DIA_06", TipoIntervalo_Dia_06)
            oRelatorio.SetParameterValue("DS_INTERVALO_DIA_07", TipoIntervalo_Dia_07)
            oRelatorio.SetParameterValue("DS_INTERVALO_DIA_08", TipoIntervalo_Dia_08)
            oRelatorio.SetParameterValue("DS_INTERVALO_DIA_09", TipoIntervalo_Dia_09)
        ElseIf optTipo_Analitico.Checked Then
            oRelatorio.Load(Application.StartupPath & "\RPT_MovEsotqueCacau_DataCacau_Analitico.rpt")
            oRelatorio.SetDataSource(oData_Analitico)
        End If

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        Select Case True
            Case optOrigem_EstoqueAtual.Checked
                sTIPO_RELATORIO = "Relatório de Estoque Atual por Origem"
                'Case optOrigem_EstoquePassado.Checked
                '    sTIPO_RELATORIO = "Relatório de Estoque Anterior por Origem"
            Case optOrigem_Industrializacao.Checked
                sTIPO_RELATORIO = "Relatório de Industrialização por Origem"
        End Select

        oRelatorio.SetParameterValue("TIPO_RELATORIO", sTIPO_RELATORIO)

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub txtIntervalo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIntervalo.ValueChanged
        TipoIntervalo_Calcular()
    End Sub

    Private Sub optTipo_Analitico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo_Analitico.CheckedChanged
        grpVisualizarPor.Visible = optTipo_Sintetico.Checked
    End Sub
End Class