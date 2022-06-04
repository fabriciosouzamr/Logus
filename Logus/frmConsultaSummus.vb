Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaSummus
    Const cnt_GridGeral_Data As Integer = 0
    Const cnt_GridGeral_FornecedorFilial As Integer = 1
    Const cnt_GridGeral_OrdemDescarga As Integer = 2
    Const cnt_GridGeral_NF As Integer = 3
    Const cnt_GridGeral_ValorNF As Integer = 4
    Const cnt_GridGeral_ValorICMSNF As Integer = 5
    Const cnt_GridGeral_QuantNF As Integer = 6
    Const cnt_GridGeral_QtSacos As Integer = 7
    Const cnt_GridGeral_Municipio As Integer = 8
    Const cnt_GridGeral_TipoCacau As Integer = 9
    Const cnt_GridGeral_Umidade As Integer = 10
    Const cnt_GridGeral_Sujidade As Integer = 11
    Const cnt_GridGeral_PesoAmendoa As Integer = 12
    Const cnt_GridGeral_Mofo As Integer = 13
    Const cnt_GridGeral_Fumaca As Integer = 14
    Const cnt_GridGeral_Ardosia As Integer = 15
    Const cnt_GridGeral_Achatada As Integer = 16
    Const cnt_GridGeral_NumeroFicha As Integer = 17
    Const cnt_GridGeral_PesoBrutoFicha As Integer = 18
    Const cnt_GridGeral_PesoTaraFicha As Integer = 19
    Const cnt_GridGeral_PesoTaraLiquido As Integer = 20
    Const cnt_GridGeral_PlacaVeiculo As Integer = 21
    Const cnt_GridGeral_MotoristaCaminhao As Integer = 22
    Const cnt_GridGeral_FilialFicha As Integer = 23

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String
        Dim SqlFiltro As String = ""

        'FILTRO FILIAL
        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlFiltro = SqlFiltro & " AND (FORN.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")" & _
                                     " OR FIL.CD_FILIAL IN (" & SelecaoFilial.Lista_ID & "))"
        Else
            SqlFiltro = SqlFiltro & " AND (FORN.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")" & _
                        " OR FIL.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & "))"
        End If
        If Pesq_CodigoNome.Codigo > 0 Then
            SqlFiltro = SqlFiltro & " AND FORN.CD_FORNECEDOR = " & Pesq_CodigoNome.Codigo
        End If

        SqlText = "SELECT   * "
        SqlText = SqlText & "    FROM (SELECT FC.DT_MOVIMENTO, "
        SqlText = SqlText & "                 NVL (FIL.NO_FILIAL, FORN.NO_RAZAO_SOCIAL) NO_FORNECEDOR, "
        SqlText = SqlText & "                 CAST (NF.NU_ORDEM_DESCARGA AS NUMBER) NU_ORDEM_DESCARGA, "
        SqlText = SqlText & "                 NF.NU_NF, NF.VL_NF, NF.VL_NF_ICMS, NF.QT_KG_NF, NF.QT_VOLUME, "
        SqlText = SqlText & "                 MUNIC.NO_CIDADE || ' - ' || MUNIC.CD_UF AS NO_MUNIC, "
        SqlText = SqlText & "                 NFO.IC_TIPO_CACAU, NFO.QT_UMIDADE, NFO.PC_SUJIDADE, "
        SqlText = SqlText & "                 NFO.QT_PESO_AMENDOA, NFO.QT_MOFO, NFO.QT_FUMACA, "
        SqlText = SqlText & "                 NFO.QT_ARDOSIA, NFO.QT_ACHATADA, NFO.SQ_FICHA_CIRCULACAO, "
        SqlText = SqlText & "                 FC.QT_KG_BRUTO, FC.QT_KG_TARA, FC.QT_KG_LIQUIDO, "
        SqlText = SqlText & "                 FC.NU_PLACA_VEICULO, FC.NO_MOTORISTA, "
        SqlText = SqlText & "                 FILFC.NO_FILIAL NO_FILIAL_FICHA "
        SqlText = SqlText & "            FROM SOF.NOTAS NF, "
        SqlText = SqlText & "                 SOF.NF_ORIGINACAO NFO, "
        SqlText = SqlText & "                 SOF.MUNICIPIO MUNIC, "
        SqlText = SqlText & "                 SOF.FILIAL FIL, "
        SqlText = SqlText & "                 SOF.FORNECEDOR FORN, "
        SqlText = SqlText & "                 SOF.FICHA_CIRCULACAO FC, "
        SqlText = SqlText & "                 SOF.FILIAL FILFC "
        SqlText = SqlText & "           WHERE NF.SQ_FICHA_CIRCULACAO = NFO.SQ_FICHA_CIRCULACAO "
        SqlText = SqlText & "             AND NF.CD_FILIAL_ORIGEM = NFO.CD_FILIAL_ORIGEM "
        SqlText = SqlText & "             AND NF.NU_NF = NFO.NU_NF "
        SqlText = SqlText & "             AND NFO.CD_MUNICIPIO = MUNIC.CD_MUNICIPIO "
        SqlText = SqlText & "             AND NFO.CD_FORNECEDOR = FORN.CD_FORNECEDOR(+) "
        SqlText = SqlText & "             AND NFO.CD_FILIAL_TRANSFERENCIA = FIL.CD_FILIAL(+) "
        SqlText = SqlText & "             AND NF.SQ_FICHA_CIRCULACAO = FC.SQ_FICHA_CIRCULACAO "
        SqlText = SqlText & "             AND NF.CD_FILIAL_ORIGEM = FC.CD_FILIAL_ORIGEM "
        SqlText = SqlText & "             AND FC.CD_FILIAL_ORIGEM = FILFC.CD_FILIAL "
        SqlText = SqlText & "             AND NFO.SQ_MOVIMENTACAO IS NULL "

        SqlText = SqlText & SqlFiltro

        SqlText = SqlText & "          UNION ALL "
        SqlText = SqlText & "          SELECT RC.DT_LANCAMENTO DT_MOVIMENTO, "
        SqlText = SqlText & "                 NVL (FIO.NO_FILIAL, FORN.NO_RAZAO_SOCIAL) NO_FORNECEDOR, "
        SqlText = SqlText & "                 RN.CD_ORDEM_DESCARGA NU_ORDEM_DESCARGA, RN.NU_NF, RN.VL_NF, "
        SqlText = SqlText & "                 RN.VL_NF_ICMS, RN.QT_KG_NF, RN.QT_VOLUME, "
        SqlText = SqlText & "                 MUNIC.NO_CIDADE || ' - ' || MUNIC.CD_UF AS NO_MUNIC, "
        SqlText = SqlText & "                 RN.CD_TIPO_QUALIDADE IC_TIPO_CACAU, QUALI.QT_UMIDADE, "
        SqlText = SqlText & "                 QUALI.PC_SUJIDADE, QUALI.QT_PESO_AMENDOA, QUALI.QT_MOFO, "
        SqlText = SqlText & "                 QUALI.QT_FUMACA, QUALI.QT_ARDOSIA, QUALI.QT_ACHATADA, "
        SqlText = SqlText & "                 RN.SQ_RECEPCAO_NOTAS SQ_FICHA_CIRCULACAO, "
        SqlText = SqlText & "                 RC.QT_BALANCA_KG_BRUTO QT_KG_BRUTO, "
        SqlText = SqlText & "                 RC.QT_BALANCA_KG_TARA QT_KG_TARA, "
        SqlText = SqlText & "                 RC.QT_BALANCA_KG_LIQUIDO QT_KG_LIQUIDO, RC.NU_PLACA_VEICULO, "
        SqlText = SqlText & "                 RC.NO_MOTORISTA, FIL.NO_FILIAL NO_FILIAL_FICHA "
        SqlText = SqlText & "            FROM SOF.RECEPCAO RC, "
        SqlText = SqlText & "                 SOF.RECEPCAO_NOTAS RN, "
        SqlText = SqlText & "                 (SELECT   RQ.SQ_RECEPCAO_NOTAS, "
        SqlText = SqlText & "                           SUM (DECODE (PS.CD_ANALISE_UMIDADE, "
        SqlText = SqlText & "                                        RQ.CD_ANALISE, RQ.QT_ANALISE, "
        SqlText = SqlText & "                                        0 "
        SqlText = SqlText & "                                       ) "
        SqlText = SqlText & "                               ) QT_UMIDADE, "
        SqlText = SqlText & "                           SUM "
        SqlText = SqlText & "                              (DECODE (PS.CD_ANALISE_PESOAMENDOA, "
        SqlText = SqlText & "                                       RQ.CD_ANALISE, RQ.QT_ANALISE, "
        SqlText = SqlText & "                                       0 "
        SqlText = SqlText & "                                      ) "
        SqlText = SqlText & "                              ) QT_PESO_AMENDOA, "
        SqlText = SqlText & "                           SUM (DECODE (PS.CD_ANALISE_MOFO, "
        SqlText = SqlText & "                                        RQ.CD_ANALISE, RQ.QT_ANALISE, "
        SqlText = SqlText & "                                        0 "
        SqlText = SqlText & "                                       ) "
        SqlText = SqlText & "                               ) QT_MOFO, "
        SqlText = SqlText & "                           SUM (DECODE (PS.CD_ANALISE_FUMACA, "
        SqlText = SqlText & "                                        RQ.CD_ANALISE, RQ.QT_ANALISE, "
        SqlText = SqlText & "                                        0 "
        SqlText = SqlText & "                                       ) "
        SqlText = SqlText & "                               ) QT_FUMACA, "
        SqlText = SqlText & "                           SUM (DECODE (PS.CD_ANALISE_ARDOSIA, "
        SqlText = SqlText & "                                        RQ.CD_ANALISE, RQ.QT_ANALISE, "
        SqlText = SqlText & "                                        0 "
        SqlText = SqlText & "                                       ) "
        SqlText = SqlText & "                               ) QT_ARDOSIA, "
        SqlText = SqlText & "                           SUM (DECODE (PS.CD_ANALISE_ACHATADA, "
        SqlText = SqlText & "                                        RQ.CD_ANALISE, RQ.QT_ANALISE, "
        SqlText = SqlText & "                                        0 "
        SqlText = SqlText & "                                       ) "
        SqlText = SqlText & "                               ) QT_ACHATADA, "
        SqlText = SqlText & "                           SUM (DECODE (PS.CD_ANALISE_SUJIDADE, "
        SqlText = SqlText & "                                        RQ.CD_ANALISE, RQ.QT_ANALISE, "
        SqlText = SqlText & "                                        0 "
        SqlText = SqlText & "                                       ) "
        SqlText = SqlText & "                               ) PC_SUJIDADE "
        SqlText = SqlText & "                      FROM SOF.RECEPCAO_QUALIDADE RQ, SOF.PARAMETRO_SUMMUS PS "
        SqlText = SqlText & "                     WHERE RQ.CD_ANALISE IN "
        SqlText = SqlText & "                              (PS.CD_ANALISE_UMIDADE, "
        SqlText = SqlText & "                               PS.CD_ANALISE_PESOAMENDOA, "
        SqlText = SqlText & "                               PS.CD_ANALISE_MOFO, "
        SqlText = SqlText & "                               PS.CD_ANALISE_FUMACA, "
        SqlText = SqlText & "                               PS.CD_ANALISE_ARDOSIA, "
        SqlText = SqlText & "                               PS.CD_ANALISE_ACHATADA, "
        SqlText = SqlText & "                               PS.CD_ANALISE_SUJIDADE "
        SqlText = SqlText & "                              ) "
        SqlText = SqlText & "                  GROUP BY RQ.SQ_RECEPCAO_NOTAS) QUALI, "
        SqlText = SqlText & "                 SOF.FILIAL FIO, "
        SqlText = SqlText & "                 SOF.FILIAL FIL, "
        SqlText = SqlText & "                 SOF.FORNECEDOR FORN, "
        SqlText = SqlText & "                 SOF.MUNICIPIO MUNIC "
        SqlText = SqlText & "           WHERE RN.SQ_RECEPCAO = RC.SQ_RECEPCAO "
        SqlText = SqlText & "             AND CD_FILIAL_TRANSFERENCIA IS NULL "
        SqlText = SqlText & "             AND FIL.CD_FILIAL = RC.CD_FILIAL "
        SqlText = SqlText & "             AND MUNIC.CD_MUNICIPIO = RN.CD_MUNICIPIO_ORIGEM "
        SqlText = SqlText & "             AND QUALI.SQ_RECEPCAO_NOTAS(+) = RN.SQ_RECEPCAO_NOTAS "
        SqlText = SqlText & "             AND FIO.CD_FILIAL(+) = RN.CD_FILIAL_TRANSFERENCIA "
        SqlText = SqlText & "             AND FORN.CD_FORNECEDOR(+) = RN.CD_FORNECEDOR "
        SqlText = SqlText & "             AND RN.SQ_MOVIMENTACAO IS NULL "
        SqlText = SqlText & "             AND RN.DT_EXCLUSAO IS NULL"

        SqlText = SqlText & SqlFiltro
        SqlText = SqlText & " ) ORDER BY DT_MOVIMENTO "

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Data, _
                                                           cnt_GridGeral_FornecedorFilial, _
                                                           cnt_GridGeral_OrdemDescarga, _
                                                           cnt_GridGeral_NF, _
                                                           cnt_GridGeral_ValorNF, _
                                                           cnt_GridGeral_ValorICMSNF, _
                                                           cnt_GridGeral_QuantNF, _
                                                           cnt_GridGeral_QtSacos, _
                                                           cnt_GridGeral_Municipio, _
                                                           cnt_GridGeral_TipoCacau, _
                                                           cnt_GridGeral_Umidade, _
                                                           cnt_GridGeral_Sujidade, _
                                                           cnt_GridGeral_PesoAmendoa, _
                                                           cnt_GridGeral_Mofo, _
                                                           cnt_GridGeral_Fumaca, _
                                                           cnt_GridGeral_Ardosia, _
                                                           cnt_GridGeral_Achatada, _
                                                           cnt_GridGeral_NumeroFicha, _
                                                           cnt_GridGeral_PesoBrutoFicha, _
                                                           cnt_GridGeral_PesoTaraFicha, _
                                                           cnt_GridGeral_PesoTaraLiquido, _
                                                           cnt_GridGeral_PlacaVeiculo, _
                                                           cnt_GridGeral_MotoristaCaminhao, _
                                                           cnt_GridGeral_FilialFicha})
    End Sub

    Private Sub frmConsultaSummus_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_Close(Me)
    End Sub

    Private Sub frmConsultaSummus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_CodigoNome.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, , , , , True)

        objGrid_Coluna_Add(grdGeral, "Data", 110, , , , , cnt_Formato_DataHora)
        objGrid_Coluna_Add(grdGeral, "Fornecedor/Filial", 160)
        objGrid_Coluna_Add(grdGeral, "Ordem Descarga", 100)
        objGrid_Coluna_Add(grdGeral, "NF", 60)
        objGrid_Coluna_Add(grdGeral, "Valor NF", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor ICMS NF", 110, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Quant NF", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Qt Sacos", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Municipio", 120)
        objGrid_Coluna_Add(grdGeral, "Tipo Cacau", 100)
        objGrid_Coluna_Add(grdGeral, "Umidade", 100)
        objGrid_Coluna_Add(grdGeral, "Sujidade", 100)
        objGrid_Coluna_Add(grdGeral, "Peso Amêndoa", 100)
        objGrid_Coluna_Add(grdGeral, "Mofo", 100)
        objGrid_Coluna_Add(grdGeral, "Fumaça", 100)
        objGrid_Coluna_Add(grdGeral, "Ardosia", 100)
        objGrid_Coluna_Add(grdGeral, "Achatada", 100)
        objGrid_Coluna_Add(grdGeral, "Número Ficha", 100)
        objGrid_Coluna_Add(grdGeral, "Peso Bruto Ficha", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Peso Tara Ficha", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Peso Tara Liquido", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Placa Veiculo", 100)
        objGrid_Coluna_Add(grdGeral, "Motorista Caminhão", 160)
        objGrid_Coluna_Add(grdGeral, "Filial Ficha", 120)

        Form_Carrega_Grid(Me)

        objGrid_ExibirTotal(grdGeral, New Integer() {cnt_GridGeral_ValorNF, cnt_GridGeral_ValorICMSNF, _
                                                     cnt_GridGeral_QuantNF, cnt_GridGeral_QtSacos})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub frmConsultaSummus_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdImprimir.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Me.UltraPrintPreviewDialog1.ShowDialog(Me)
    End Sub

    Private Sub UltraPrintPreviewDialog1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraPrintPreviewDialog1.Load
        Try
            Me.UltraPrintPreviewDialog1.PreviewSettings.Zoom = 100 * 0.01
            Me.UltraPrintPreviewDialog1.Document.DocumentName = "Consulta Summus"
            Me.UltraPrintPreviewDialog1.Text = "Consulta Summus"
        Catch
        End Try
    End Sub

    Private Sub grdGeral_InitializePrint(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs) Handles grdGeral.InitializePrint
        SetupPrint(e)
    End Sub

    Private Sub SetupPrint(ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs)

        Try
            e.DefaultLogicalPageLayoutInfo.FitWidthToPages = 1
            e.PrintDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.AllPages
        Catch
            e.PrintDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.AllPages
        End Try
        e.PrintDocument.DefaultPageSettings.Landscape = True
        e.DefaultLogicalPageLayoutInfo.PageHeader = "Consulta Sumus"
        e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = _
         Infragistics.Win.HAlign.Center
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 20

    End Sub
End Class