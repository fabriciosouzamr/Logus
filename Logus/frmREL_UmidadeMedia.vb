Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_UmidadeMedia
    Dim oRelatorio As New CrystalReportDocument

    Private Sub frmREL_UmidadeMedia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_UmidadeMedia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_UmidadeMedia_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim oData_Itens As DataTable
        Dim oData_QuebraRetornoArmazem As DataTable
        Dim oData_TotalQuebraTransfFilial As DataTable

        Dim oRelatorio_Itens As New ReportDocument
        Dim oRelatorio_QuebraRetornoArmazem As New ReportDocument
        Dim oRelatorio_TotalQuebraTransfFilial As New ReportDocument

        Dim dDataIni As Date
        Dim dDataFim As Date
        Dim dEntradaFabrica As Double = 0

        Dim sFiltro As String = ""

        Dim SqlText As String
        Dim oDataAux As DataTable
        Dim Indice As Integer = 0
        Dim Acumula As Double = 0
        Dim Aux_01 As Double
        Dim Aux_02 As Double
        Dim iCont As Integer

        dDataIni = New Date(txtData.DateTime.Year, txtData.DateTime.Month, 1)
        dDataFim = dDataIni.AddMonths(1).AddDays(-1).Date

        '>> Ciração dos datatable - Início
        oData_Itens = New DataTable
        oData_QuebraRetornoArmazem = New DataTable
        oData_TotalQuebraTransfFilial = New DataTable

        With oData_Itens.Columns
            .Add("NO_ITEM")
            .Add("VL_ITEM").DataType = System.Type.GetType("System.Double")
            .Add("NR_ITEM").DataType = System.Type.GetType("System.Double")
            .Add("QT_UMIDADE").DataType = System.Type.GetType("System.Double")
            .Add("IC_DESTACAR")
        End With
        With oData_QuebraRetornoArmazem.Columns
            .Add("NO_FILIAL")
            .Add("QT_QUEBRA").DataType = System.Type.GetType("System.Double")
        End With
        With oData_TotalQuebraTransfFilial.Columns
            .Add("NO_FILIAL")
            .Add("QT_QUEBRA").DataType = System.Type.GetType("System.Double")
        End With
        '>> Ciração dos datatable - Fim

        '>> ENTRADA NA FÁBRICA - Início
        oData = Gera_Rs_Transferencia(frmREL_Transferencia.RGFP_TipoRelatorio.Transferencia, _
                                      dDataIni, dDataFim, _
                                      False, False, True, "", FilialMae, True, True)

        For iCont = 0 To oData.Rows.Count - 1
            With oData.Rows(iCont)
                dEntradaFabrica = dEntradaFabrica + NVL(.Item("QT_KG_NF_ENTRADA_FABRICA"), 0)

                SqlText = "SELECT NVL(IC_ARMAZEM, 'N') FROM SOF.FILIAL WHERE CD_FILIAL = " & .Item("CD_FILIAL_ORIGEM")
                If DBQuery_ValorUnico(SqlText) = "N" Then
                    Quebra(oData_TotalQuebraTransfFilial, .Item("NO_ARMAZEM"), 0 - (NVL(.Item("QT_KG_NF_SAIDA"), 0) - NVL(.Item("QT_KG_NF_ENTRADA_FABRICA"), 0)))
                Else
                    Quebra(oData_QuebraRetornoArmazem, .Item("NO_ARMAZEM"), 0 - (NVL(.Item("QT_KG_NF_SAIDA"), 0) - NVL(.Item("QT_KG_NF_ENTRADA_FABRICA"), 0)))
                End If
            End With
        Next
        '>> ENTRADA NA FÁBRICA - Fim

        '>> QUEBRA DE TRANSBORDO - Início
        oDataAux = DBQuery(Gera_Sql_Transbordo(dDataIni, dDataFim, True))

        For iCont = 0 To oDataAux.Rows.Count - 1
            With oDataAux.Rows(iCont)
                SqlText = "SELECT NVL(IC_ARMAZEM, 'N') FROM SOF.FILIAL WHERE CD_FILIAL = " & .Item("CD_FILIAL_ORIGEM")
                If DBQuery_ValorUnico(SqlText) = "N" Then
                    Quebra(oData_TotalQuebraTransfFilial, "TRANSBORDO " & .Item("NO_ORIGEM"), 0 - (NVL(.Item("QT_KG_NF"), 0) - NVL(.Item("QT_KG_LIQUIDO_NF"), 0)))
                Else
                    Quebra(oData_QuebraRetornoArmazem, "TRANSBORDO " & .Item("NO_ORIGEM"), 0 - (NVL(.Item("QT_KG_NF"), 0) - NVL(.Item("QT_KG_LIQUIDO_NF"), 0)))
                End If
            End With
        Next
        '>> QUEBRA DE TRANSBORDO - Fim

        '>> ITENS - Início
        Acumula = 0
        'Entrada na fábrica para
        Acumula = Acumula + dEntradaFabrica
        Item_Adicionar(oData_Itens, "Entrada na fábrica para " & Date_Mes(txtData.DateTime), dEntradaFabrica, Numero_Adicionar(Indice))
        'Cacau recebido direto na fábrica - Início
        Aux_01 = 0
        Aux_02 = 0
        oDataAux = DBQuery(Gera_Sql_Recebimento_Fabrica(dDataIni, dDataFim))

        For iCont = 0 To oDataAux.Rows.Count - 1
            With oDataAux.Rows(iCont)
                Aux_01 = Aux_01 + .Item("QT_KG_LIQUIDO_NF")
                Aux_02 = Aux_02 + (.Item("QT_KG_LIQUIDO_NF") * .Item("QT_UMIDADE"))
            End With
        Next

        Acumula = Acumula + Aux_01
        Item_Adicionar(oData_Itens, "Cacau recebido direto na fábrica", Aux_01, Numero_Adicionar(Indice), , Math.Round(Aux_02 / Aux_01, 2))
        'Cacau recebido direto na fábrica - Fim
        'Marinado mês
        Aux_01 = (0 - Marinado(dDataFim))
        Acumula = Acumula + Aux_01
        Item_Adicionar(oData_Itens, "Marinado de " & LCase(Date_Mes(dDataFim)), Aux_01, Numero_Adicionar(Indice))
        'Saídas no mês - Início
        oDataAux = DBQuery(Gera_Sql_Saida_Fabrica(dDataIni, dDataFim, True, True))

        For iCont = 0 To oDataAux.Rows.Count - 1
            With oDataAux.Rows(iCont)
                Acumula = Acumula + (0 - .Item("QT_VOLUME"))
                Item_Adicionar(oData_Itens, .Item("NO_TRANSFERENCIA_MODALIDADE"), 0 - .Item("QT_VOLUME"), Numero_Adicionar(Indice))
            End With
        Next
        'Saídas no mês - Fim

        'Marinado mês anterior
        Aux_01 = Marinado(dDataIni.AddDays(-1))
        Acumula = Acumula + Aux_01
        Item_Adicionar(oData_Itens, "Marinado de " & LCase(Date_Mes(dDataIni.AddDays(-1))), Aux_01, Numero_Adicionar(Indice))
        'Industrialização mês
        Item_Adicionar(oData_Itens, "Industrializado no mês - Movimentação (A)", Acumula, Numero_Adicionar(Indice), True)

        'Industrilização RD - Início
        Aux_01 = 0
        SqlText = "SELECT TM.NO_TRANSFERENCIA_MODALIDADE," & _
                         "SUM(QT_KG_DIA) QT_KG_DIA" & _
                  " FROM SOF.RESUMO_DIARIO_ESTOQUE RDE," & _
                        "SOF.TRANSFERENCIA_MODALIDADE TM" & _
                  " WHERE RDE.DT_MOVIMENTO BETWEEN " & QuotedStr(Date_to_Oracle(dDataIni)) & " AND " & QuotedStr(Date_to_Oracle(dDataFim)) & _
                    " AND TM.CD_TIPO_MOVIMENTACAO_SAIDA = RDE.CD_TIPO_MOVIMENTACAO" & _
                    " AND TM.IC_MOVIMENTACAO_SILO = 'S'" & _
                  " GROUP BY TM.NO_TRANSFERENCIA_MODALIDADE" & _
                  " ORDER BY TM.NO_TRANSFERENCIA_MODALIDADE"
        oDataAux = DBQuery(SqlText)

        For iCont = 0 To oDataAux.Rows.Count - 1
            With oDataAux.Rows(iCont)
                Acumula = Acumula - .Item("QT_KG_DIA")
                Aux_01 = Aux_01 + .Item("QT_KG_DIA")
                Item_Adicionar(oData_Itens, .Item("NO_TRANSFERENCIA_MODALIDADE"), .Item("QT_KG_DIA"), Numero_Adicionar(Indice))
            End With
        Next

        Item_Adicionar(oData_Itens, "Industrializado no mês - RD (B)", Aux_01, Numero_Adicionar(Indice), True)
        Item_Adicionar(oData_Itens, "(A) - (B)", Acumula, Numero_Adicionar(Indice), True)
        'Industrilização RD - Fim
        '>> ITENS - Fim

        oRelatorio.Load(Application.StartupPath & "\RPT_UmidadeMedia.rpt")
        oRelatorio.SetDataSource(oData)

        oRelatorio_Itens = oRelatorio.OpenSubreport("RPT_UmidadeMedia_Itens")
        oRelatorio_TotalQuebraTransfFilial = oRelatorio.OpenSubreport("RPT_UmidadeMedia_TotalQuebraTransfFilial")
        oRelatorio_QuebraRetornoArmazem = oRelatorio.OpenSubreport("RPT_UmidadeMedia_QuebraRetornoArmazem")
        oRelatorio_Itens.SetDataSource(oData_Itens)
        oRelatorio_QuebraRetornoArmazem.SetDataSource(oData_QuebraRetornoArmazem)
        oRelatorio_TotalQuebraTransfFilial.SetDataSource(oData_TotalQuebraTransfFilial)

        oRelatorio.SetParameterValue("Filtro", UCase(Date_Mes(dDataFim)) & " " & dDataFim.Year.ToString)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        crvMain.ReportSource = oRelatorio

        objData_Finalizar(oDataAux)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Function Marinado(ByVal dData As Date) As Double
        Dim iCont As Integer

        With Gera_Rs_Estoque_Cacau(dData)
            For iCont = 0 To .Rows.Count - 1
                If .Rows(iCont).Item("CD_FILIAL") = FilialMae Then
                    Return .Rows(iCont).Item("QT_QUILOS")
                    Exit For
                End If
            Next
        End With
    End Function

    Private Sub Quebra(ByVal oData As DataTable, ByVal Filial As String, ByVal Quebra As Double)
        Dim oRow As DataRow = Nothing
        Dim iCont As Integer

        For iCont = 0 To oData.Rows.Count - 1
            If Trim(oData.Rows(iCont).Item("NO_FILIAL")) = Trim(Filial) Then
                oRow = oData.Rows(iCont)
                Exit For
            End If
        Next

        If oRow Is Nothing Then
            oRow = oData.NewRow
            oData.Rows.Add(oRow)
        End If

        With oRow
            .Item("NO_FILIAL") = Filial
            .Item("QT_QUEBRA") = NVL(.Item("QT_QUEBRA"), 0) + Quebra
        End With
    End Sub

    Private Sub Item_Adicionar(ByRef oData As DataTable, _
                               ByVal Descricao As String, _
                               ByVal Valor As Double, _
                               ByVal Nr_Item As Integer, _
                               Optional ByVal Destacar As Boolean = False, _
                               Optional ByVal QT_UMIDADE As Double = 0)
        With oData.Rows.Add
            .Item("NO_ITEM") = Descricao
            .Item("VL_ITEM") = Valor
            .Item("NR_ITEM") = Nr_Item
            .Item("IC_DESTACAR") = IIf(Destacar, "S", "N")

            If QT_UMIDADE <> 0 Then
                .Item("QT_UMIDADE") = QT_UMIDADE
            End If
        End With
    End Sub
End Class