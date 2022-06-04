Imports Infragistics.Win

Public Class frmMovimentacaoCacau_Devolucao
    Const cnt_GridMovimetDevolucao_SQ_MOVIMENTACAO As Integer = 0
    Const cnt_GridMovimetDevolucao_Filial As Integer = 1
    Const cnt_GridMovimetDevolucao_NF As Integer = 2
    Const cnt_GridMovimetDevolucao_SerieNF As Integer = 3
    Const cnt_GridMovimetDevolucao_ValorNF As Integer = 4
    Const cnt_GridMovimetDevolucao_ValorICMSNF As Integer = 5
    Const cnt_GridMovimetDevolucao_QtdeNF As Integer = 6
    Const cnt_GridMovimetDevolucao_QtdeLiquidoNF As Integer = 7
    Const cnt_GridMovimetDevolucao_QtdeBrutoNF As Integer = 8
    Const cnt_GridMovimetDevolucao_QtdeAFixar As Integer = 9
    Const cnt_GridMovimetDevolucao_TipoCacau As Integer = 10
    Const cnt_GridMovimetDevolucao_Umidade As Integer = 11
    Const cnt_GridMovimetDevolucao_Sujidade As Integer = 12
    Const cnt_GridMovimetDevolucao_PesoAmendoa As Integer = 13
    Const cnt_GridMovimetDevolucao_Mofo As Integer = 14
    Const cnt_GridMovimetDevolucao_Fumaca As Integer = 15
    Const cnt_GridMovimetDevolucao_Ardosia As Integer = 16
    Const cnt_GridMovimetDevolucao_Achatada As Integer = 17
    Const cnt_GridMovimetDevolucao_CD_MUNICIPIO_ORIGEM As Integer = 18
    Const cnt_GridMovimetDevolucao_CD_FILIAL_MOVIMENTACAO As Integer = 19
    Const cnt_GridMovimetDevolucao_VL_NF_FUNRURAL As Integer = 20
    Const cnt_GridMovimetDevolucao_QT_CESSAO As Integer = 21
    Const cnt_GridMovimetDevolucao_IC_FISICA_JURIDICA As Integer = 22
    Const cnt_GridMovimetDevolucao_CD_FILIAL As Integer = 23
    Const cnt_GridMovimetDevolucao_ValorAFixar As Integer = 24

    Const cnt_GridListaMovimentDisponiveis_KGATransferir As Integer = 0
    Const cnt_GridListaMovimentDisponiveis_Sacos As Integer = 1
    Const cnt_GridListaMovimentDisponiveis_NF As Integer = 2
    Const cnt_GridListaMovimentDisponiveis_Serie As Integer = 3
    Const cnt_GridListaMovimentDisponiveis_Fornecedor As Integer = 4
    Const cnt_GridListaMovimentDisponiveis_KGBrutos As Integer = 5
    Const cnt_GridListaMovimentDisponiveis_QTNF As Integer = 6
    Const cnt_GridListaMovimentDisponiveis_ValorNF As Integer = 7
    Const cnt_GridListaMovimentDisponiveis_TipoMovimentacao As Integer = 8
    Const cnt_GridListaMovimentDisponiveis_QT_KG_LIQUIDO As Integer = 9
    Const cnt_GridListaMovimentDisponiveis_VL_NF_ICMS As Integer = 10
    Const cnt_GridListaMovimentDisponiveis_NO_ARMAZEM As Integer = 11
    Const cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO As Integer = 12
    Const cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO_PILHA_ARMAZEM As Integer = 13
    Const cnt_GridListaMovimentDisponiveis_CD_ARMAZEM As Integer = 14
    Const cnt_GridListaMovimentDisponiveis_CD_PILHA_ARMAZEM As Integer = 15

    Const cnt_GridListaMovimentSelecionadas_KGTransferir As Integer = 0
    Const cnt_GridListaMovimentSelecionadas_Sacos As Integer = 1
    Const cnt_GridListaMovimentSelecionadas_NF As Integer = 2
    Const cnt_GridListaMovimentSelecionadas_Fornecedor As Integer = 3
    Const cnt_GridListaMovimentSelecionadas_Armazem As Integer = 4
    Const cnt_GridListaMovimentSelecionadas_Pilha As Integer = 5
    Const cnt_GridListaMovimentSelecionadas_KGBrutos As Integer = 6
    Const cnt_GridListaMovimentSelecionadas_QTNF As Integer = 7
    Const cnt_GridListaMovimentSelecionadas_Serie As Integer = 8
    Const cnt_GridListaMovimentSelecionadas_ValorNF As Integer = 9
    Const cnt_GridListaMovimentSelecionadas_TipoMovimentacao As Integer = 10
    Const cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO As Integer = 11
    Const cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO_PILHA_ARMAZEM As Integer = 12
    Const cnt_GridListaMovimentSelecionadas_CD_ARMAZEM As Integer = 13
    Const cnt_GridListaMovimentSelecionadas_KGATransferir As Integer = 14

    Const cnt_GridListagemSacariaMovimentacao_CD_TIPO_SACARIA As Integer = 0
    Const cnt_GridListagemSacariaMovimentacao_TipoSacaria As Integer = 1
    Const cnt_GridListagemSacariaMovimentacao_Quantidade As Integer = 2
    Const cnt_GridListagemSacariaMovimentacao_PesoSacaria As Integer = 3

    Dim oDS_MovimentacoesDisponiveisDevolucao As New UltraWinDataSource.UltraDataSource
    Dim oDS_ListagemMovimentacaoSelecionadas As New UltraWinDataSource.UltraDataSource
    Dim oDS_ListagemMovimentacaoDisponiveis As New UltraWinDataSource.UltraDataSource
    Dim oDS_ListagemSacariaMovimentacao As New UltraWinDataSource.UltraDataSource
    Dim oSacariaMovimentacao As DataTable

    Dim bProcInterno As Boolean

    Private Sub LimparTela()
        oDS_MovimentacoesDisponiveisDevolucao.Rows.Clear()
        tbcGeral.Enabled = False

        LimparTelaDevolucao()
    End Sub

    Private Sub LimparTelaDevolucao()
        lblKGSelecionadoDevolucao.Text = ""
        txtQtdeASerDevolvida.MinValue = 0
        txtQtdeASerDevolvida.MaxValue = 0
        txtQtdeASerDevolvida.Value = 0
        txtNotaFiscal_Numero.Text = ""
        txtNotaFiscal_Serie.Text = ""
        cboTipoDocumento.SelectedIndex = -1
        txtKGNotaFiscal.Value = 0
        txtKGLiquido.Value = 0
        txtKGBruto.Value = 0
        txtPesoSacaria.Value = 0
        cboArmazem.SelectedIndex = -1
        cboPilha.DataSource = Nothing
        cboPilha.Enabled = False
        txtQtdeATransferir.Value = 0
        txtQtdeASerTransferida.Value = 0
        tabMovimentacoesDisponiveisDevolucao.Select()

        oDS_ListagemSacariaMovimentacao.Rows.Clear()
        oDS_ListagemMovimentacaoSelecionadas.Rows.Clear()
        oDS_ListagemMovimentacaoDisponiveis.Rows.Clear()
    End Sub

    Private Sub frmMovimentacaoCacau_Devolucao_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        oDS_MovimentacoesDisponiveisDevolucao.Dispose()
        oDS_ListagemMovimentacaoDisponiveis.Dispose()
        oDS_ListagemMovimentacaoSelecionadas.Dispose()
        oDS_ListagemSacariaMovimentacao.Dispose()
    End Sub

    Private Sub frmMovimentacaoCacau_Devolucao_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oLista As New ValueList
        Dim SqlText As String

        Form_Container_IdentificarControles(tabMovimentacoesEstoque.Controls)

        ComboBox_Carregar_Tipo_Documento(cboTipoDocumento, True)
        ComboBox_Carregar_Armazem(cboArmazem, , True)
        ComboBox_Carregar_Tipo_Devolucao(cboTipoDevolucao, True)

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        objGrid_Inicializar(grdMovimentacoesDevolucao, , oDS_MovimentacoesDisponiveisDevolucao, _
                                                                    UltraWinGrid.CellClickAction.CellSelect)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Filial", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "NF", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Série NF", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Valor NF", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Valor ICMS NF", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Qt. NF", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Qt. Líquido NF", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Qt. Bruto NF", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Qt. a Fixar", 0)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Tipo de Cacau", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Umidade", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Sujidade", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Peso de Amêndoa", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Môfo", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Fumaça", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Ardosia", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Achatada", 100)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "CD_MUNICIPIO_ORIGEM", 0)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "CD_FILIAL_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "VL_NF_FUNRURAL", 0)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "QT_CESSAO", 0)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "IC_FISICA_JURIDICA", 0)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "CD_FILIAL", 0)
        objGrid_Coluna_Add(grdMovimentacoesDevolucao, "Valor a Fixar", 150)

        objGrid_Inicializar(grdListagemMovimentacaoDisponiveis, , oDS_ListagemMovimentacaoDisponiveis, _
                                                                  UltraWinGrid.CellClickAction.CellSelect)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "KG a Transferir", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "Sacos", 100)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "NF", 100)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "Serie", 30)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "Fornecedor", 100)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "KG Brutos", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "QT NF", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "Valor NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "Tipo Movimentação", 100)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "QT_KG_LIQUIDO", 0)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "VL_NF_ICMS", 0)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "NO_ARMAZEM", 0)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "SQ_MOVIMENTACAO_PILHA_ARMAZEM", 0)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "CD_ARMAZEM", 0)
        objGrid_Coluna_Add(grdListagemMovimentacaoDisponiveis, "CD_PILHA_ARMAZEM", 0)

        objGrid_Inicializar(grdListagemMovimentacaoSelecionadas, , oDS_ListagemMovimentacaoSelecionadas, _
                                                                   UltraWinGrid.CellClickAction.CellSelect)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "KG a transferir", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "Sacos", 100)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "NF", 100)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "Fornecedor", 100)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "Armazem", 100)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "Pilha", 100)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "KG Brutos", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "QT NF", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "Serie", 100)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "Valor NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "Tipo de Movimentação", 100)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "SQ_MOVIMENTACAO_PILHA_ARMAZEM", 0)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "CD_ARMAZEM", 0)
        objGrid_Coluna_Add(grdListagemMovimentacaoSelecionadas, "KG a Transferir", 0)

        SqlText = "SELECT CD_TIPO_SACARIA, NO_TIPO_SACARIA" & _
                  " FROM SOF.TIPO_SACARIA" & _
                  " ORDER BY NO_TIPO_SACARIA"
        oLista = ValueList_Carregar(SqlText)

        objGrid_Inicializar(grdListagemSacariaMovimentacao, , oDS_ListagemSacariaMovimentacao, _
                                                              UltraWinGrid.CellClickAction.CellSelect)
        objGrid_Coluna_Add(grdListagemSacariaMovimentacao, "CD_TIPO_SACARIA", 0)
        objGrid_Coluna_Add(grdListagemSacariaMovimentacao, "Tipo de Sacaria", 100)
        objGrid_Coluna_Add(grdListagemSacariaMovimentacao, "Quantidade", 100)
        objGrid_Coluna_Add(grdListagemSacariaMovimentacao, "Peso", 0)

        oSacariaMovimentacao = New DataTable

        With oSacariaMovimentacao
            .Columns.Add("CD_ARMAZEM").DataType = System.Type.GetType("System.Int32")
            .Columns.Add("CD_PILHA").DataType = System.Type.GetType("System.Int32")
            .Columns.Add("SQ_MOVIMENTACAO").DataType = System.Type.GetType("System.Int32")
            .Columns.Add("SQ_MOVIMENTACAO_PILHA_ARMAZEM").DataType = System.Type.GetType("System.Int32")
            .Columns.Add("SQ_MOV_PILHA_ARMAZEM_SACARIA").DataType = System.Type.GetType("System.Int32")
            .Columns.Add("CD_TIPO_SACARIA").DataType = System.Type.GetType("System.Int32")
            .Columns.Add("NO_TIPO_SACARIA")
            .Columns.Add("QT_SACO_DISPONIVEL").DataType = System.Type.GetType("System.Double")
            .Columns.Add("QT_SACO_SELECIONADO").DataType = System.Type.GetType("System.Double")
            .Columns.Add("QT_PESO_SACARIA").DataType = System.Type.GetType("System.Double")
        End With

        LimparTela()

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cboArmazem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboArmazem.SelectedIndexChanged
        If ComboBox_LinhaSelecionada(cboArmazem) Then
            ComboBox_Carregar_Pilha(cboPilha, cboArmazem.SelectedValue, True, True)
        Else
            cboPilha.DataSource = Nothing
        End If

        cboPilha.Enabled = (cboPilha.Items.Count > 1)
    End Sub

    Private Sub cmdPesquisar_Movimentacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar_Movimentacao.Click
        PesquisarMovimentacao()
    End Sub

    Private Sub PesquisarMovimentacao()
        Dim SqlText As String

        If Not ComboBox_LinhaSelecionada(cboArmazem) Then
            Msg_Mensagem("Favor selecionar um armazem.")
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboPilha) Then
            Msg_Mensagem("Favor selecionar uma pilha.")
            Exit Sub
        End If

        SqlText = "SELECT MPA.QT_VOLUME QT_KG_A_TRANSFERIR," & _
                         "NVL(SUM(SF.QT_SACOS), 0) AS QT_SACO," & _
                         "M.NU_NF," & _
                         "M.NU_SERIE_NF," & _
                         "F.NO_RAZAO_SOCIAL," & _
                         "M.QT_KG_BRUTO_NF," & _
                         "M.QT_KG_NF," & _
                         "M.VL_NF," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "M.QT_KG_LIQUIDO_NF," & _
                         "M.VL_NF_ICMS," & _
                         "A.NO_ARMAZEM," & _
                         "M.SQ_MOVIMENTACAO," & _
                         "MPA.SQ_MOVIMENTACAO_PILHA_ARMAZEM," & _
                         "MPA.CD_ARMAZEM," & _
                         "MPA.CD_PILHA_ARMAZEM" & _
                  " FROM SOF.MOVIMENTACAO M," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.MOV_PILHA_ARMAZEM_SACARIA SF," & _
                        "SOF.MOVIMENTACAO_PILHA_ARMAZEM MPA," & _
                        "SOF.ARMAZEM A" & _
                  " WHERE MPA.CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                    " AND MPA.CD_PILHA_ARMAZEM = " & cboPilha.SelectedValue & _
                    " AND MPA.SQ_ESTOQUE_SILO IS NULL" & _
                    " AND MPA.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                    " AND A.CD_ARMAZEM = MPA.CD_ARMAZEM" & _
                    " AND M.CD_TIPO_MOVIMENTACAO = TM.CD_TIPO_MOVIMENTACAO" & _
                    " AND MPA.CD_ARMAZEM = SF.CD_ARMAZEM (+)" & _
                    " AND MPA.CD_PILHA_ARMAZEM = SF.CD_PILHA_ARMAZEM (+)" & _
                    " AND MPA.SQ_MOVIMENTACAO = SF.SQ_MOVIMENTACAO (+)" & _
                    " AND MPA.SQ_MOVIMENTACAO_PILHA_ARMAZEM = SF.SQ_MOVIMENTACAO_PILHA_ARMAZEM (+)" & _
                    " AND M.CD_FORNECEDOR = F.CD_FORNECEDOR (+)" & _
                  " GROUP BY M.SQ_MOVIMENTACAO," & _
                            "M.NU_NF," & _
                            "M.QT_KG_NF," & _
                            "M.VL_NF," & _
                            "F.NO_RAZAO_SOCIAL," & _
                            "TM.NO_TIPO_MOVIMENTACAO," & _
                            "MPA.QT_VOLUME," & _
                            "M.QT_KG_BRUTO_NF," & _
                            "M.NU_SERIE_NF," & _
                            "M.QT_KG_LIQUIDO_NF," & _
                            "M.DT_MOVIMENTACAO," & _
                            "M.VL_NF_ICMS," & _
                            "MPA.SQ_MOVIMENTACAO_PILHA_ARMAZEM," & _
                            "A.NO_ARMAZEM," & _
                            "MPA.CD_ARMAZEM," & _
                            "MPA.CD_PILHA_ARMAZEM" & _
                  " ORDER BY M.DT_MOVIMENTACAO"

        CarregarMovimentacaoDisponivelDevolucao(SqlText)
    End Sub

    Private Sub CarregarMovimentacaoDisponivelDevolucao(ByVal SqlText As String)
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        oDS_ListagemMovimentacaoDisponiveis.Rows.Clear()

        objGrid_Carregar(grdListagemMovimentacaoDisponiveis, SqlText, New Integer() {cnt_GridListaMovimentDisponiveis_KGATransferir, _
                                                                                     cnt_GridListaMovimentDisponiveis_Sacos, _
                                                                                     cnt_GridListaMovimentDisponiveis_NF, _
                                                                                     cnt_GridListaMovimentDisponiveis_Serie, _
                                                                                     cnt_GridListaMovimentDisponiveis_Fornecedor, _
                                                                                     cnt_GridListaMovimentDisponiveis_KGBrutos, _
                                                                                     cnt_GridListaMovimentDisponiveis_QTNF, _
                                                                                     cnt_GridListaMovimentDisponiveis_ValorNF, _
                                                                                     cnt_GridListaMovimentDisponiveis_TipoMovimentacao, _
                                                                                     cnt_GridListaMovimentDisponiveis_QT_KG_LIQUIDO, _
                                                                                     cnt_GridListaMovimentDisponiveis_VL_NF_ICMS, _
                                                                                     cnt_GridListaMovimentDisponiveis_NO_ARMAZEM, _
                                                                                     cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO, _
                                                                                     cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO_PILHA_ARMAZEM, _
                                                                                     cnt_GridListaMovimentDisponiveis_CD_ARMAZEM, _
                                                                                     cnt_GridListaMovimentDisponiveis_CD_PILHA_ARMAZEM})

        For iCont_01 = 0 To grdListagemMovimentacaoSelecionadas.Rows.Count - 1
            For iCont_02 = 0 To grdListagemMovimentacaoDisponiveis.Rows.Count - 1
                If objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO, iCont_01) = _
                   objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO, iCont_02) And _
                   objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO_PILHA_ARMAZEM, iCont_01) = _
                   objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO_PILHA_ARMAZEM, iCont_02) And _
                   objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_Pilha, iCont_01) = _
                   objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_CD_PILHA_ARMAZEM, iCont_02) Then
                    With grdListagemMovimentacaoDisponiveis.Rows(iCont_02)
                        .Cells(cnt_GridListaMovimentDisponiveis_KGATransferir).Value = .Cells(cnt_GridListaMovimentDisponiveis_KGATransferir).Value - _
                                                                                              objGrid_Valor(grdListagemMovimentacaoSelecionadas, _
                                                                                                            cnt_GridListaMovimentSelecionadas_KGTransferir, _
                                                                                                            iCont_01)

                        If .Cells(cnt_GridListaMovimentDisponiveis_KGATransferir).Value = 0 Then
                            .Delete()
                            Exit For
                        End If
                    End With
                End If
            Next
        Next
    End Sub

    Private Sub CarregarMovimentacaoDevolucao()
        Dim SqlText As String

        SqlText = "SELECT M.SQ_MOVIMENTACAO," & _
                         "FIL.NO_FILIAL," & _
                         "M.NU_NF," & _
                         "M.NU_SERIE_NF," & _
                         "M.VL_NF," & _
                         "M.VL_NF_ICMS," & _
                         "M.QT_KG_NF," & _
                         "M.QT_KG_LIQUIDO_NF," & _
                         "M.QT_KG_BRUTO_NF," & _
                         "SUM(MCD.QT_KG_A_FIXAR) QT_A_FIXAR," & _
                         "MQ.IC_TIPO_CACAU," & _
                         "MQ.QT_UMIDADE," & _
                         "MQ.PC_SUJIDADE," & _
                         "MQ.QT_PESO_AMENDOA," & _
                         "MQ.QT_MOFO," & _
                         "MQ.QT_FUMACA," & _
                         "MQ.QT_ARDOSIA," & _
                         "MQ.QT_ACHATADA," & _
                         "M.CD_MUNICIPIO_ORIGEM," & _
                         "M.CD_FILIAL_MOVIMENTACAO," & _
                         "M.VL_NF_FUNRURAL," & _
                         "COUNT(MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO) QT_CESSAO," & _
                         "F.IC_FISICA_JURIDICA," & _
                         "FIL.CD_FILIAL,   SUM(MCD.vl_a_fixar ) vl_a_fixar " & _
                  " FROM SOF.FORNECEDOR F," & _
                        "SOF.MOVIMENTACAO_QUALIDADE MQ," & _
                        "SOF.MOVIMENTACAO M," & _
                        "SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                        "SOF.FILIAL FIL" & _
                  " WHERE M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                    " AND M.SQ_MOVIMENTACAO = MQ.SQ_MOVIMENTACAO (+)" & _
                    " AND M.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND M.CD_FILIAL_MOVIMENTACAO = FIL.CD_FILIAL" & _
                    " AND M.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & _
                    " AND M.QT_KG_LIQUIDO_NF > 0" & _
                  " GROUP BY M.SQ_MOVIMENTACAO," & _
                            "M.QT_KG_LIQUIDO_NF," & _
                            "F.CD_FORNECEDOR," & _
                            "F.NO_RAZAO_SOCIAL," & _
                            "M.NU_NF," & _
                            "M.NU_SERIE_NF," & _
                            "M.VL_NF," & _
                            "M.VL_NF_ICMS," & _
                            "M.VL_NF_FUNRURAL," & _
                            "M.QT_KG_NF," & _
                            "M.QT_KG_BRUTO_NF," & _
                            "MQ.IC_TIPO_CACAU," & _
                            "MQ.QT_UMIDADE," & _
                            "MQ.PC_SUJIDADE," & _
                            "MQ.QT_PESO_AMENDOA," & _
                            "MQ.QT_MOFO," & _
                            "MQ.QT_FUMACA," & _
                            "MQ.QT_ARDOSIA," & _
                            "MQ.QT_ACHATADA," & _
                            "M.CD_MUNICIPIO_ORIGEM," & _
                            "M.CD_FILIAL_MOVIMENTACAO," & _
                            "F.IC_FISICA_JURIDICA," & _
                            "FIL.NO_FILIAL," & _
                            "FIL.CD_FILIAL" & _
                  " HAVING SUM(MCD.QT_KG_A_FIXAR) <> 0"
        bProcInterno = True

        objGrid_Carregar(grdMovimentacoesDevolucao, SqlText, New Integer() {cnt_GridMovimetDevolucao_SQ_MOVIMENTACAO, _
                                                                            cnt_GridMovimetDevolucao_Filial, _
                                                                            cnt_GridMovimetDevolucao_NF, _
                                                                            cnt_GridMovimetDevolucao_SerieNF, _
                                                                            cnt_GridMovimetDevolucao_ValorNF, _
                                                                            cnt_GridMovimetDevolucao_ValorICMSNF, _
                                                                            cnt_GridMovimetDevolucao_QtdeNF, _
                                                                            cnt_GridMovimetDevolucao_QtdeLiquidoNF, _
                                                                            cnt_GridMovimetDevolucao_QtdeBrutoNF, _
                                                                            cnt_GridMovimetDevolucao_QtdeAFixar, _
                                                                            cnt_GridMovimetDevolucao_TipoCacau, _
                                                                            cnt_GridMovimetDevolucao_Umidade, _
                                                                            cnt_GridMovimetDevolucao_Sujidade, _
                                                                            cnt_GridMovimetDevolucao_PesoAmendoa, _
                                                                            cnt_GridMovimetDevolucao_Mofo, _
                                                                            cnt_GridMovimetDevolucao_Fumaca, _
                                                                            cnt_GridMovimetDevolucao_Ardosia, _
                                                                            cnt_GridMovimetDevolucao_Achatada, _
                                                                            cnt_GridMovimetDevolucao_CD_MUNICIPIO_ORIGEM, _
                                                                            cnt_GridMovimetDevolucao_CD_FILIAL_MOVIMENTACAO, _
                                                                            cnt_GridMovimetDevolucao_VL_NF_FUNRURAL, _
                                                                            cnt_GridMovimetDevolucao_QT_CESSAO, _
                                                                            cnt_GridMovimetDevolucao_IC_FISICA_JURIDICA, _
                                                                            cnt_GridMovimetDevolucao_CD_FILIAL, _
                                                                            cnt_GridMovimetDevolucao_ValorAFixar})

        tbcGeral.Enabled = (grdMovimentacoesDevolucao.Rows.Count > 0)

        bProcInterno = False
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub Pesq_Fornecedor_AlterouRegistro() Handles Pesq_Fornecedor.AlterouRegistro
        LimparTela()
        CarregarMovimentacaoDevolucao()
    End Sub

    Private Sub MontarGridSacaria()
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim bAchou As Boolean

        oDS_ListagemSacariaMovimentacao.Rows.Clear()

        If oSacariaMovimentacao Is Nothing Then Exit Sub

        'Refaz o grid de sacaria
        For iCont_01 = 0 To oSacariaMovimentacao.Rows.Count - 1
            bAchou = False

            'Verifica se a sacaria já está listada e somente atualiza a quantidade
            For iCont_02 = 0 To oDS_ListagemSacariaMovimentacao.Rows.Count - 1
                With oDS_ListagemSacariaMovimentacao.Rows(iCont_02)
                    If oSacariaMovimentacao.Rows(iCont_01).Item("CD_TIPO_SACARIA") = _
                       .Item(cnt_GridListagemSacariaMovimentacao_CD_TIPO_SACARIA) Then
                        .Item(cnt_GridListagemSacariaMovimentacao_Quantidade) = .Item(cnt_GridListagemSacariaMovimentacao_Quantidade) + _
                                                                                oSacariaMovimentacao.Rows(iCont_01).Item("QT_SACO_SELECIONADO")
                        bAchou = True
                    End If
                End With
            Next

            'Caso não existe é adicionada uma nova linha
            If Not bAchou Then
                oDS_ListagemSacariaMovimentacao.Rows.Add()

                With oDS_ListagemSacariaMovimentacao.Rows(oDS_ListagemSacariaMovimentacao.Rows.Count - 1)
                    .Item(cnt_GridListagemSacariaMovimentacao_CD_TIPO_SACARIA) = oSacariaMovimentacao.Rows(iCont_01).Item("CD_TIPO_SACARIA")
                    .Item(cnt_GridListagemSacariaMovimentacao_TipoSacaria) = oSacariaMovimentacao.Rows(iCont_01).Item("NO_TIPO_SACARIA")
                    .Item(cnt_GridListagemSacariaMovimentacao_Quantidade) = oSacariaMovimentacao.Rows(iCont_01).Item("QT_SACO_SELECIONADO")
                    .Item(cnt_GridListagemSacariaMovimentacao_PesoSacaria) = oSacariaMovimentacao.Rows(iCont_01).Item("QT_PESO_SACARIA")
                End With
            End If
        Next

        'Calcula o peso da sacaria
        For iCont_01 = 0 To grdListagemSacariaMovimentacao.Rows.Count - 1
            txtPesoSacaria.Value = txtPesoSacaria.Value + (objGrid_Valor(grdListagemSacariaMovimentacao, cnt_GridListagemSacariaMovimentacao_Quantidade, iCont_01) * _
                                                           objGrid_Valor(grdListagemSacariaMovimentacao, cnt_GridListagemSacariaMovimentacao_PesoSacaria, iCont_01))
        Next

        txtPesoSacaria.Value = Math.Round(txtPesoSacaria.Value, 0)
    End Sub

    Private Sub tbcGeral_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tbcGeral.SelectedTabChanged
        If tbcGeral.ActiveTab.TabPage Is tabMovimentacoesDisponiveisDevolucao Then
            MontarGridSacaria()
        ElseIf tbcGeral.ActiveTab.TabPage Is tabMovimentacoesEstoque Then
            If objGrid_LinhaSelecionada(grdMovimentacoesDevolucao) = -1 Then
                Msg_Mensagem("Selecione a movimentação que será devolvida")
                tabMovimentacoesDisponiveisDevolucao.Select()
            Else
                VerificaSeMovimentacaoDevolucaoExisteEmEstoque()
            End If
        End If
    End Sub

    Private Sub grdMovimentacoesDevolucao_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMovimentacoesDevolucao.AfterRowActivate
        Dim bDevolver As Boolean = False

        If objGrid_LinhaSelecionada(grdMovimentacoesDevolucao) > -1 Then
            If objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_CD_FILIAL) <> _
               FilialLogada Then
                bDevolver = Msg_Perguntar("Você só deve realizar uma devolução em uma filial diferente do recebimento" & _
                                          "se não for possível realizar na mesma." & vbCrLf & _
                                          "Deseja Continuar?")
            Else
                bDevolver = True
            End If
        End If

        If bDevolver Then
            LimparTelaDevolucao()
            txtQtdeASerDevolvida.MinValue = 1
            txtQtdeASerDevolvida.MaxValue = objGrid_Valor(grdMovimentacoesDevolucao, _
                                                          cnt_GridMovimetDevolucao_QtdeAFixar, , 0)
            If txtQtdeASerDevolvida.MinValue > txtQtdeASerDevolvida.MaxValue Then
                txtQtdeASerDevolvida.MinValue = txtQtdeASerDevolvida.MaxValue
            End If

            txtQtdeASerDevolvida.Value = objGrid_Valor(grdMovimentacoesDevolucao, _
                                                       cnt_GridMovimetDevolucao_QtdeAFixar, , 0)
            lblValorMaximoDevolucao.Text = Math.Round(objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_ValorNF) / _
                                      objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_QtdeLiquidoNF) * _
                                      txtKGNotaFiscal.Value, 2)
        End If
    End Sub

    Private Sub VerificaSeMovimentacaoDevolucaoExisteEmEstoque()
        Dim SqlText As String
        Dim iCont As Integer
        Dim iAux As Integer

        SqlText = "SELECT NVL(SUM(MPA.QT_VOLUME), 0) QT" & _
                  " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM MPA," & _
                        "SOF.PILHA_ARMAZEM PA," & _
                        "SOF.ARMAZEM A" & _
                 " WHERE MPA.SQ_MOVIMENTACAO = " & objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_SQ_MOVIMENTACAO) & _
                   " AND PA.CD_ARMAZEM = MPA.CD_ARMAZEM" & _
                   " AND PA.CD_PILHA_ARMAZEM = MPA.CD_PILHA_ARMAZEM" & _
                   " AND A.CD_ARMAZEM = PA.CD_ARMAZEM" & _
                   " AND A.CD_FILIAL_ORIGEM = " & FilialLogada

        If DBQuery_ValorUnico(SqlText) = txtQtdeASerDevolvida.Value Then
            SqlText = "SELECT MPA.QT_VOLUME QT_KG_A_TRANSFERIR," & _
                             "NVL(SUM (SF.QT_SACOS), 0) AS QT_SACO," & _
                             "M.NU_NF," & _
                             "M.NU_SERIE_NF," & _
                             "F.NO_RAZAO_SOCIAL," & _
                             "M.QT_KG_BRUTO_NF," & _
                             "M.QT_KG_NF," & _
                             "M.VL_NF," & _
                             "TM.NO_TIPO_MOVIMENTACAO," & _
                             "M.QT_KG_LIQUIDO_NF," & _
                             "M.VL_NF_ICMS," & _
                             "A.NO_ARMAZEM," & _
                             "M.SQ_MOVIMENTACAO," & _
                             "MPA.SQ_MOVIMENTACAO_PILHA_ARMAZEM," & _
                             "MPA.CD_ARMAZEM," & _
                             "MPA.CD_PILHA_ARMAZEM" & _
                      " FROM SOF.MOVIMENTACAO M," & _
                            "SOF.TIPO_MOVIMENTACAO TM," & _
                            "SOF.FORNECEDOR F," & _
                            "SOF.MOV_PILHA_ARMAZEM_SACARIA SF," & _
                            "SOF.MOVIMENTACAO_PILHA_ARMAZEM MPA," & _
                            "SOF.ARMAZEM A" & _
                      " WHERE MPA.SQ_ESTOQUE_SILO IS NULL" & _
                        " AND MPA.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                        " AND MPA.CD_ARMAZEM = A.CD_ARMAZEM" & _
                        " AND M.CD_TIPO_MOVIMENTACAO = TM.CD_TIPO_MOVIMENTACAO" & _
                        " AND MPA.CD_ARMAZEM = SF.CD_ARMAZEM (+)" & _
                        " AND MPA.CD_PILHA_ARMAZEM = SF.CD_PILHA_ARMAZEM(+)" & _
                        " AND MPA.SQ_MOVIMENTACAO = SF.SQ_MOVIMENTACAO (+)" & _
                        " AND MPA.SQ_MOVIMENTACAO_PILHA_ARMAZEM = SF.SQ_MOVIMENTACAO_PILHA_ARMAZEM(+)" & _
                        " AND M.CD_FORNECEDOR = F.CD_FORNECEDOR(+)" & _
                        " AND M.SQ_MOVIMENTACAO = " & objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_SQ_MOVIMENTACAO) & _
                        " AND A.CD_FILIAL_ORIGEM = " & FilialLogada & _
                      " GROUP BY M.SQ_MOVIMENTACAO," & _
                                "M.NU_NF," & _
                                "M.QT_KG_NF," & _
                                "M.VL_NF," & _
                                "F.NO_RAZAO_SOCIAL," & _
                                "TM.NO_TIPO_MOVIMENTACAO," & _
                                "MPA.QT_VOLUME," & _
                                "M.QT_KG_BRUTO_NF," & _
                                "M.NU_SERIE_NF," & _
                                "M.QT_KG_LIQUIDO_NF," & _
                                "M.DT_MOVIMENTACAO," & _
                                "M.VL_NF_ICMS," & _
                                "MPA.SQ_MOVIMENTACAO_PILHA_ARMAZEM," & _
                                "A.NO_ARMAZEM," & _
                                "MPA.CD_ARMAZEM," & _
                                "MPA.CD_PILHA_ARMAZEM"
            CarregarMovimentacaoDisponivelDevolucao(SqlText)

            'Seleciona automaticamente as movimentações necessárias
            iCont = 0

            Do While iCont < grdListagemMovimentacaoDisponiveis.Rows.Count
                If txtQtdeASerDevolvida.Value > Val(lblKGSelecionadoDevolucao.Text) Then
                    grdListagemMovimentacaoDisponiveis.Rows(iCont).Activate()

                    txtQtdeASerTransferida.Value = (txtQtdeASerDevolvida.Value - Val(lblKGSelecionadoDevolucao.Text))

                    If txtQtdeASerTransferida.Value > txtQtdeATransferir.Value Then
                        txtQtdeASerTransferida.Value = txtQtdeATransferir.Value
                    End If

                    iAux = grdListagemMovimentacaoDisponiveis.Rows.Count

                    AdicionarMovimentacao()

                    If iAux = grdListagemMovimentacaoDisponiveis.Rows.Count Then
                        iCont = iCont + 1
                    End If
                End If
            Loop
        End If
    End Sub

    Private Sub txtQtdeASerDevolvida_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtdeASerDevolvida.ValueChanged
        txtKGNotaFiscal.Value = txtQtdeASerDevolvida.Value
        txtKGLiquido.Value = txtQtdeASerDevolvida.Value
    End Sub

    Private Sub grdListagemMovimentacaoDisponiveis_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdListagemMovimentacaoDisponiveis.AfterRowActivate
        If objGrid_LinhaSelecionada(grdListagemMovimentacaoDisponiveis) > -1 Then
            txtQtdeATransferir.Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, _
                                                     cnt_GridListaMovimentDisponiveis_KGATransferir)
            txtQtdeASerTransferida.Value = txtQtdeATransferir.Value
        End If
    End Sub

    Private Sub AdicionarMovimentacao()
        Dim iCont As Integer
        Dim bAchou As Boolean = False
        Dim SqlText As String

        Dim oData As DataTable
        Dim oRow As DataRow

        Dim QT_SACOS As Integer
        Dim QT_SACOS_ADIC As Integer

        If objGrid_LinhaSelecionada(grdListagemMovimentacaoDisponiveis) = -1 Then
            Exit Sub
        End If

        'Verifica se ja existe alguma parte da movimentação selecionada, caso exista atualiza s quantidade
        For iCont = 0 To grdListagemMovimentacaoSelecionadas.Rows.Count - 1
            If objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO, iCont) = _
               objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO) And _
               objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO_PILHA_ARMAZEM, iCont) = _
               objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO_PILHA_ARMAZEM) And _
               objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_Pilha, iCont) = _
               objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_CD_PILHA_ARMAZEM) Then
                bAchou = True

                grdListagemMovimentacaoSelecionadas.Rows(iCont).Cells(cnt_GridListaMovimentSelecionadas_KGTransferir).Value = txtQtdeASerTransferida.Value

                QT_SACOS = Math.Round(objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_Sacos) / _
                                      objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_KGATransferir) * _
                                      objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_KGTransferir, iCont), 0)
            End If
        Next

        'Se não achou é adicionada uma nova linha com a quantidade
        If Not bAchou Then
            oDS_ListagemMovimentacaoSelecionadas.Rows.Add()

            With grdListagemMovimentacaoSelecionadas.Rows(grdListagemMovimentacaoSelecionadas.Rows.Count - 1)
                .Cells(cnt_GridListaMovimentSelecionadas_KGTransferir).Value = txtQtdeASerTransferida.Value
                .Cells(cnt_GridListaMovimentSelecionadas_Sacos).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_Sacos)
                .Cells(cnt_GridListaMovimentSelecionadas_NF).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_NF)
                .Cells(cnt_GridListaMovimentSelecionadas_Fornecedor).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_Fornecedor)
                .Cells(cnt_GridListaMovimentSelecionadas_Armazem).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_NO_ARMAZEM)
                .Cells(cnt_GridListaMovimentSelecionadas_Pilha).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_CD_PILHA_ARMAZEM)
                .Cells(cnt_GridListaMovimentSelecionadas_KGBrutos).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_KGBrutos)
                .Cells(cnt_GridListaMovimentSelecionadas_QTNF).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_QTNF)
                .Cells(cnt_GridListaMovimentSelecionadas_Serie).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_Serie)
                .Cells(cnt_GridListaMovimentSelecionadas_ValorNF).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_ValorNF)
                .Cells(cnt_GridListaMovimentSelecionadas_TipoMovimentacao).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_TipoMovimentacao)
                .Cells(cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO)
                .Cells(cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO_PILHA_ARMAZEM)
                .Cells(cnt_GridListaMovimentSelecionadas_CD_ARMAZEM).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_CD_ARMAZEM)
                .Cells(cnt_GridListaMovimentSelecionadas_KGATransferir).Value = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_KGATransferir)

                QT_SACOS = Math.Round(objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_Sacos, 0) / _
                                      objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_KGATransferir, 0) * _
                                      txtQtdeASerTransferida.Value, 0)
            End With
        End If

        'Verifica se existe uma lançamento de sacaria de elimina, isso é feito para que o volume fique proporcional
        iCont = 0

        With oSacariaMovimentacao
            Do While iCont < .Rows.Count
                If .Rows(iCont).Item("CD_ARMAZEM") = objGrid_Valor(grdListagemMovimentacaoDisponiveis, _
                                                                   cnt_GridListaMovimentDisponiveis_CD_ARMAZEM) And _
                   .Rows(iCont).Item("CD_PILHA") = objGrid_Valor(grdListagemMovimentacaoDisponiveis, _
                                                                   cnt_GridListaMovimentDisponiveis_CD_PILHA_ARMAZEM) And _
                   .Rows(iCont).Item("SQ_MOVIMENTACAO") = objGrid_Valor(grdListagemMovimentacaoDisponiveis, _
                                                                        cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO) And _
                   .Rows(iCont).Item("SQ_MOVIMENTACAO_PILHA_ARMAZEM") = objGrid_Valor(grdListagemMovimentacaoDisponiveis, _
                                                                                      cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO_PILHA_ARMAZEM) Then
                    .Rows(iCont).Delete()
                Else
                    iCont = iCont + 1
                End If
            Loop
        End With

        SqlText = "SELECT SAC.SQ_MOV_PILHA_ARMAZEM_SACARIA," & _
                         "SAC.QT_SACOS," & _
                         "SAC.CD_TIPO_SACARIA," & _
                         "TSC.NO_TIPO_SACARIA," & _
                         "TSC.VL_PESO" & _
                  " FROM SOF.MOV_PILHA_ARMAZEM_SACARIA SAC," & _
                        "SOF.TIPO_SACARIA TSC" & _
                  " WHERE SAC.CD_ARMAZEM = " & objGrid_Valor(grdListagemMovimentacaoDisponiveis, _
                                                             cnt_GridListaMovimentDisponiveis_CD_ARMAZEM) & _
                    " AND SAC.CD_PILHA_ARMAZEM = " & objGrid_Valor(grdListagemMovimentacaoDisponiveis, _
                                                                   cnt_GridListaMovimentDisponiveis_CD_PILHA_ARMAZEM) & _
                    " AND SAC.SQ_MOVIMENTACAO = " & objGrid_Valor(grdListagemMovimentacaoDisponiveis, _
                                                                  cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO) & _
                    " AND SAC.SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & objGrid_Valor(grdListagemMovimentacaoDisponiveis, _
                                                                                cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO_PILHA_ARMAZEM) & _
                    " AND TSC.CD_TIPO_SACARIA = SAC.CD_TIPO_SACARIA"
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            oRow = oSacariaMovimentacao.NewRow

            oRow.Item("CD_ARMAZEM") = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_CD_ARMAZEM)
            oRow.Item("CD_PILHA") = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_CD_PILHA_ARMAZEM)
            oRow.Item("SQ_MOVIMENTACAO") = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO)
            oRow.Item("SQ_MOVIMENTACAO_PILHA_ARMAZEM") = objGrid_Valor(grdListagemMovimentacaoDisponiveis, cnt_GridListaMovimentDisponiveis_SQ_MOVIMENTACAO_PILHA_ARMAZEM)
            oRow.Item("SQ_MOV_PILHA_ARMAZEM_SACARIA") = oData.Rows(iCont).Item("SQ_MOV_PILHA_ARMAZEM_SACARIA")
            oRow.Item("CD_TIPO_SACARIA") = oData.Rows(iCont).Item("CD_TIPO_SACARIA")
            oRow.Item("NO_TIPO_SACARIA") = oData.Rows(iCont).Item("NO_TIPO_SACARIA")
            oRow.Item("QT_SACO_DISPONIVEL") = oData.Rows(iCont).Item("QT_SACOS")
            oRow.Item("QT_PESO_SACARIA") = oData.Rows(iCont).Item("VL_PESO")

            If oData.Rows(iCont).Item("QT_SACOS") > (QT_SACOS - QT_SACOS_ADIC) Then
                oRow.Item("QT_SACO_SELECIONADO") = (QT_SACOS - QT_SACOS_ADIC)
            Else
                oRow.Item("QT_SACO_SELECIONADO") = oData.Rows(iCont).Item("QT_SACOS")
            End If

            QT_SACOS_ADIC = QT_SACOS_ADIC + oRow.Item("QT_SACO_SELECIONADO")

            oSacariaMovimentacao.Rows.Add(oRow)

            If QT_SACOS_ADIC = QT_SACOS Then Exit For
        Next

        oRow = Nothing
        oData.Dispose()
        oData = Nothing

        'Retira da posição disponível a quantidade a ser transferida e elimina a linha caso a quantidade disponível fique zerada
        With grdListagemMovimentacaoDisponiveis.DisplayLayout.ActiveRow
            .Cells(cnt_GridListaMovimentDisponiveis_KGATransferir).Value = .Cells(cnt_GridListaMovimentDisponiveis_KGATransferir).Value - _
                                                                           txtQtdeASerTransferida.Value

            txtQtdeATransferir.Value = .Cells(cnt_GridListaMovimentDisponiveis_KGATransferir).Value
            txtQtdeASerTransferida.Value = .Cells(cnt_GridListaMovimentDisponiveis_KGATransferir).Value

            If .Cells(cnt_GridListaMovimentDisponiveis_KGATransferir).Value = 0 Then
                .Delete()
            End If
        End With

        lblKGSelecionadoDevolucao.Text = objGrid_CalcularTotalColuna(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_KGTransferir)
    End Sub

    Private Sub cmdDesce_Movimentacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDesce_Movimentacao.Click
        If objGrid_LinhaSelecionada(grdListagemMovimentacaoDisponiveis) = -1 Then
            Msg_Mensagem("Selecione um registro")
            Exit Sub
        End If
        If Val(lblKGSelecionadoDevolucao.Text) + txtQtdeASerTransferida.Value > _
           txtQtdeASerDevolvida.Value Then
            Msg_Mensagem("A quantidade total a ser transferida é maior que a quantidade selecionada para a devolução")
            Exit Sub
        End If

        AdicionarMovimentacao()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If txtQtdeASerDevolvida.Value <= 0 Then
            Msg_Mensagem("A quantidade a ser devolvida tem que ser maior que zero.")
            Exit Sub
        End If
        If txtQtdeASerDevolvida.Value <> Val(lblKGSelecionadoDevolucao.Text) Then
            Msg_Mensagem("Favor selecionar uma quantidade igual a selecionada para devolução.")
            Exit Sub
        End If
        If Trim(txtNotaFiscal_Numero.Text) = "" Then
            Msg_Mensagem("Favor informar um número de Nota Fiscal válido.")
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoDocumento) Then
            Msg_Mensagem("Favor selecionar um tipo de documento.")
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoDevolucao) Then
            Msg_Mensagem("Favor selecionar um tipo de devolução.")
            Exit Sub
        End If

        If objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_ValorAFixar) < Math.Round(objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_ValorNF) / _
                                                                                                       objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_QtdeLiquidoNF) * _
                                                                             txtKGNotaFiscal.Value, 2) Then
            Msg_Mensagem("Valor de nota disponivel não suficiente para realizar a devolução. Favor realizar estorno de valor de nota que seja suficiente para realizar a devolução.")
            Exit Sub
        End If

        MontarGridSacaria()

        Dim SqlText As String
        Dim oParametro(24) As DBParamentro
        Dim iCont As Integer

        Dim SQ_REC As Integer
        Dim SQ_TRANSF As Integer
        Dim SQ_REC_E As Integer

        On Error GoTo Erro

        If FilialFechada(FilialLogada) Then Exit Sub

        AVI_Carregar(Me)

        DBUsarTransacao = True

        SqlText = DBMontar_SP("SOF.SP_INCLUI_TRANSFERENCIA", False, ":SQ_REC", ":SQ_TRANSF", ":CDMODTRANSF", _
                                                                    ":DATA", ":FILORIGEM", ":FILDESTINO", _
                                                                    ":FORN", ":TIPONF", ":PLACA", _
                                                                    ":NF", ":SERIENF", ":KGNF", _
                                                                    ":VLNF", ":VLICMS", ":KGBRUTO", _
                                                                    ":UMIDADE", ":TIPOCACAU", ":PESOAMENDOA", _
                                                                    ":MOFO", ":FUMACA", ":ARDOSIA", _
                                                                    ":ACHATADA", ":SUJO", ":DSAUTORIZACAO", _
                                                                    ":SQ_REC_E")

        oParametro(0) = DBParametro_Montar("SQ_REC", Nothing, , ParameterDirection.Output)
        oParametro(1) = DBParametro_Montar("SQ_TRANSF", Nothing, , ParameterDirection.Output)
        oParametro(2) = DBParametro_Montar("CDMODTRANSF", cboTipoDevolucao.SelectedValue)
        oParametro(3) = DBParametro_Montar("DATA", Date_to_Oracle(DataSistema))
        oParametro(4) = DBParametro_Montar("FILORIGEM", FilialLogada)
        oParametro(5) = DBParametro_Montar("FILDESTINO", FilialLogada)
        oParametro(6) = DBParametro_Montar("FORN", Pesq_Fornecedor.Codigo)
        oParametro(7) = DBParametro_Montar("TIPONF", cboTipoDocumento.SelectedValue)
        oParametro(8) = DBParametro_Montar("PLACA", Nothing)
        oParametro(9) = DBParametro_Montar("NF", txtNotaFiscal_Numero.Text)
        oParametro(10) = DBParametro_Montar("SERIENF", txtNotaFiscal_Serie.Text)
        oParametro(11) = DBParametro_Montar("KGNF", txtKGNotaFiscal.Value)

        If objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_QtdeLiquidoNF) = txtQtdeASerDevolvida.Value Then
            oParametro(12) = DBParametro_Montar("VLNF", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_ValorNF))
            oParametro(13) = DBParametro_Montar("VLICMS", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_ValorICMSNF))
        Else
            oParametro(12) = DBParametro_Montar("VLNF", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_ValorNF) / _
                                                        objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_QtdeLiquidoNF) * _
                                                        txtQtdeASerDevolvida.Value)
            oParametro(13) = DBParametro_Montar("VLICMS", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_ValorICMSNF) / _
                                                          objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_QtdeLiquidoNF) * _
                                                          txtQtdeASerDevolvida.Value)
        End If

        oParametro(14) = DBParametro_Montar("KGBRUTO", txtKGBruto.Value)
        oParametro(15) = DBParametro_Montar("UMIDADE", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_Umidade))
        oParametro(16) = DBParametro_Montar("TIPOCACAU", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_TipoCacau))
        oParametro(17) = DBParametro_Montar("PESOAMENDOA", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_PesoAmendoa))
        oParametro(18) = DBParametro_Montar("MOFO", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_Mofo))
        oParametro(19) = DBParametro_Montar("FUMACA", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_Fumaca))
        oParametro(20) = DBParametro_Montar("ARDOSIA", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_Ardosia))
        oParametro(21) = DBParametro_Montar("ACHATADA", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_Achatada))
        oParametro(22) = DBParametro_Montar("SUJO", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_Sujidade))
        oParametro(23) = DBParametro_Montar("DSAUTORIZACAO", "Devolução de produtos fora do padrão", , , 4000)
        oParametro(24) = DBParametro_Montar("SQ_REC_E", Nothing, , ParameterDirection.Output)

        If Not DBExecutar(SqlText, oParametro) Then GoTo Erro

        If DBTeveRetorno() Then
            SQ_REC = Val(DBRetorno(1))
            SQ_TRANSF = Val(DBRetorno(2))
            SQ_REC_E = Val(DBRetorno(3))
        End If

        If objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_IC_FISICA_JURIDICA) = "F" Then
            SqlText = "UPDATE SOF.MOVIMENTACAO " & _
                      "SET CD_MUNICIPIO_ORIGEM = " & objGrid_Valor(grdMovimentacoesDevolucao, _
                                                                   cnt_GridMovimetDevolucao_CD_MUNICIPIO_ORIGEM) & _
                      "WHERE SQ_MOVIMENTACAO = " & SQ_REC
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        If Not Inclui_Sacaria_Transf_Forn(SQ_REC) Then GoTo Erro

        If SQ_REC_E > 0 Then
            If Not Inclui_Sacaria_Transf_Forn(SQ_REC_E) Then GoTo Erro
        End If

        For iCont = 0 To grdListagemMovimentacaoSelecionadas.Rows.Count - 1
            Inclui_Item_Transferencia(iCont, SQ_TRANSF)
        Next

        Inclui_Conciliacao(SQ_REC)

        If Not DBExecutarTransacao() Then GoTo Erro

        Msg_Mensagem("Devolução Efetuada")

        LimparTela()
        Pesq_Fornecedor.Codigo = 0

        AVI_Fechar(Me)

        Exit Sub

Erro:
        AVI_Fechar(Me)
        TratarErro()
    End Sub

    Private Function Inclui_Sacaria_Transf_Forn(ByVal SQ_REC As Long) As Boolean
        Dim iCont As Integer
        Dim SqlText As String
        Dim bOk As Boolean = False

        For iCont = 0 To grdListagemSacariaMovimentacao.Rows.Count - 1
            SqlText = DBMontar_SP("SOF.INCLUI_SACARIA_DEV", False, ":TPSACO", ":FORN", ":REC", _
                                                                   ":DATA", ":QT", ":FIL", ":DOC")

            bOk = DBExecutar(SqlText, DBParametro_Montar("TPSACO", objGrid_Valor(grdListagemSacariaMovimentacao, _
                                                                                 cnt_GridListagemSacariaMovimentacao_CD_TIPO_SACARIA, iCont)), _
                                      DBParametro_Montar("FORN", Pesq_Fornecedor.Codigo), _
                                      DBParametro_Montar("REC", SQ_REC), _
                                      DBParametro_Montar("DATA", Date_to_Oracle(DataSistema)), _
                                      DBParametro_Montar("QT", objGrid_Valor(grdListagemSacariaMovimentacao, _
                                                                             cnt_GridListagemSacariaMovimentacao_Quantidade, iCont)), _
                                      DBParametro_Montar("FIL", FilialLogada), _
                                      DBParametro_Montar("DOC", txtNotaFiscal_Numero.Text))

            If Not bOk Then Exit For
        Next

        Return bOk
    End Function

    Private Function Inclui_Item_Transferencia(ByVal iLinha As Integer, ByVal SQ_TRANSF As Long) As Boolean
        Dim bOk As Boolean = False

        Dim SqlText As String
        Dim iCont As Integer

        Dim SQ_ITEM As Integer
        Dim SQ_MOV_PILHA_ARMAZEM_HIST As Integer

        SqlText = DBMontar_SP("SOF.INCLUI_ITEM_TRANSFERENCIA", False, ":SQREC", ":SQTRANSF", ":KG", ":SQITEM")

        If Not DBExecutar(SqlText, DBParametro_Montar("SQREC", objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO, iLinha)), _
                                   DBParametro_Montar("SQTRANSF", SQ_TRANSF), _
                                   DBParametro_Montar("KG", objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_KGTransferir, iLinha)), _
                                   DBParametro_Montar("SQITEM", Nothing, , ParameterDirection.Output)) Then GoTo Sair

        SQ_ITEM = DBRetorno(1)

        SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARM_HIST", False, ":CDARMAZEM", ":CDPILHAARMAZEM", ":SQMOVIMENTACAO", _
                                                                         ":DTTRANSACAO", ":QTVOLUME", ":SQESTOQUESILO", _
                                                                         ":ICSAIDA", ":SQTRANSF", ":SQITEMTRANSF", _
                                                                         ":SQMOVPILHAARMAZEMHIST")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_CD_ARMAZEM, iLinha)), _
                                   DBParametro_Montar("CDPILHAARMAZEM", objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_Pilha, iLinha)), _
                                   DBParametro_Montar("SQMOVIMENTACAO", objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO, iLinha)), _
                                   DBParametro_Montar("DTTRANSACAO", Date_to_Oracle(DataSistema)), _
                                   DBParametro_Montar("QTVOLUME", objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_KGTransferir, iLinha)), _
                                   DBParametro_Montar("SQESTOQUESILO", Nothing), _
                                   DBParametro_Montar("ICSAIDA", "S"), _
                                   DBParametro_Montar("SQTRANSF", SQ_TRANSF), _
                                   DBParametro_Montar("SQITEMTRANSF", SQ_ITEM), _
                                   DBParametro_Montar("SQMOVPILHAARMAZEMHIST", Nothing, , ParameterDirection.Output)) Then GoTo Sair

        SQ_MOV_PILHA_ARMAZEM_HIST = DBRetorno(1)

        For iCont = 0 To oSacariaMovimentacao.Rows.Count - 1
            With oSacariaMovimentacao.Rows(iCont)
                If .Item("CD_ARMAZEM") = objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_CD_ARMAZEM, iLinha) And _
                   .Item("CD_PILHA") = objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_Pilha, iLinha) And _
                   .Item("SQ_MOVIMENTACAO") = objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO, iLinha) And _
                   .Item("SQ_MOVIMENTACAO_PILHA_ARMAZEM") = objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO_PILHA_ARMAZEM, iLinha) Then
                    If .Item("QT_SACO_DISPONIVEL") = .Item("QT_SACO_SELECIONADO") Then
                        SqlText = "DELETE FROM SOF.MOV_PILHA_ARMAZEM_SACARIA" & _
                                  " WHERE CD_ARMAZEM = " & .Item("CD_ARMAZEM") & _
                                    " AND CD_PILHA_ARMAZEM = " & .Item("CD_PILHA") & _
                                    " AND SQ_MOVIMENTACAO = " & .Item("SQ_MOVIMENTACAO") & _
                                    " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & .Item("SQ_MOVIMENTACAO_PILHA_ARMAZEM") & _
                                    " AND CD_TIPO_SACARIA = " & .Item("CD_TIPO_SACARIA") & _
                                    " AND SQ_MOV_PILHA_ARMAZEM_SACARIA = " & .Item("SQ_MOV_PILHA_ARMAZEM_SACARIA")
                        If Not DBExecutar(SqlText) Then GoTo Sair
                    Else
                        SqlText = "UPDATE SOF.MOV_PILHA_ARMAZEM_SACARIA " & _
                                  " SET QT_SACOS = QT_SACOS - " & .Item("QT_SACO_SELECIONADO") & " " & _
                                  " WHERE CD_ARMAZEM = " & .Item("CD_ARMAZEM") & _
                                    " AND CD_PILHA_ARMAZEM = " & .Item("CD_PILHA") & _
                                    " AND SQ_MOVIMENTACAO = " & .Item("SQ_MOVIMENTACAO") & _
                                    " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & .Item("SQ_MOVIMENTACAO_PILHA_ARMAZEM") & _
                                    " AND CD_TIPO_SACARIA = " & .Item("CD_TIPO_SACARIA") & _
                                    " AND SQ_MOV_PILHA_ARMAZEM_SACARIA = " & .Item("SQ_MOV_PILHA_ARMAZEM_SACARIA")
                        If Not DBExecutar(SqlText) Then GoTo Sair
                    End If

                    SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARM_HI_SAC", False, ":CDARMAZEM", ":CDPILHAARMAZEM", _
                                                                                       ":SQMOVIMENTACAO", ":SQMOVPILHAARMAZEMHIST", _
                                                                                       ":CDTIPOSACARIA", ":QTSACOS")

                    If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", .Item("CD_ARMAZEM")), _
                                               DBParametro_Montar("CDPILHAARMAZEM", .Item("CD_PILHA")), _
                                               DBParametro_Montar("SQMOVIMENTACAO", .Item("SQ_MOVIMENTACAO")), _
                                               DBParametro_Montar("SQMOVPILHAARMAZEMHIST", SQ_MOV_PILHA_ARMAZEM_HIST), _
                                               DBParametro_Montar("CDTIPOSACARIA", .Item("CD_TIPO_SACARIA")), _
                                               DBParametro_Montar("QTSACOS", .Item("QT_SACO_SELECIONADO"))) Then GoTo Sair
                End If
            End With
        Next

        If objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_KGTransferir, iLinha) = _
           objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_KGATransferir, iLinha) Then
            SqlText = "DELETE FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM" & _
                      " WHERE CD_ARMAZEM = " & objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_CD_ARMAZEM, iLinha) & _
                        " AND CD_PILHA_ARMAZEM = " & objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_Pilha, iLinha) & _
                        " AND SQ_MOVIMENTACAO = " & objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO, iLinha) & _
                        " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO_PILHA_ARMAZEM, iLinha)
            If Not DBExecutar(SqlText) Then GoTo Sair
        Else
            SqlText = "UPDATE SOF.MOVIMENTACAO_PILHA_ARMAZEM " & _
                      " SET QT_VOLUME = QT_VOLUME - " & objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_KGTransferir, iLinha) & _
                      " WHERE CD_ARMAZEM = " & objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_CD_ARMAZEM, iLinha) & _
                        " AND CD_PILHA_ARMAZEM = " & objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_Pilha, iLinha) & _
                        " AND SQ_MOVIMENTACAO = " & objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO, iLinha) & _
                        " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO_PILHA_ARMAZEM, iLinha)
            If Not DBExecutar(SqlText) Then GoTo Sair
        End If

        bOk = True

Sair:
        Return bOk
    End Function

    Private Function Inclui_Conciliacao(ByVal SQ_REC As Long) As Boolean
        Dim SqlText As String
        Dim bOk As Boolean = False
        Dim iCont As Integer

        Dim CD_CONC_MODAL_DEVOLUCAO As Integer
        Dim SQ_CONCILIACAO As Integer
        Dim oParametro(4) As DBParamentro
        Dim QT_SALDO_CESSAO As Double = 0
        Dim QT_BAIXAR_CESSAO As Double = 0
        Dim oData As DataTable

        SqlText = "SELECT CD_CONC_MODAL_DEVOLUCAO FROM SOF.PARAMETRO"

        CD_CONC_MODAL_DEVOLUCAO = DBQuery_ValorUnico(SqlText)

        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO", False, ":CDCONCILMODAL", ":CDFORN", _
                                                                  ":QTCONCIL", ":VLCONCIL", _
                                                                  ":DSCONCIL", ":SQCONCIL")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDCONCILMODAL", CD_CONC_MODAL_DEVOLUCAO), _
                                   DBParametro_Montar("CDFORN", Pesq_Fornecedor.Codigo), _
                                   DBParametro_Montar("QTCONCIL", 0), _
                                   DBParametro_Montar("VLCONCIL", 0), _
                                   DBParametro_Montar("DSCONCIL", "Devolução de cacau. NF " & _
                                                                  objGrid_Valor(grdMovimentacoesDevolucao, _
                                                                                cnt_GridMovimetDevolucao_NF), , , 4000), _
                                   DBParametro_Montar("SQCONCIL", Nothing, , ParameterDirection.Output)) Then GoTo Sair

        If DBTeveRetorno() Then
            SQ_CONCILIACAO = DBRetorno(1)
        End If

        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO_MOV", False, ":SQCONCIL", ":SQMOV", ":SQMOVCD", _
                                                                      ":VLAPLICACAO", ":QTAPLICACAO")

        oParametro(0) = DBParametro_Montar("SQCONCIL", SQ_CONCILIACAO)
        oParametro(1) = DBParametro_Montar("SQMOV", SQ_REC)
        oParametro(2) = DBParametro_Montar("SQMOVCD", 1)

        If objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_QtdeLiquidoNF) = txtQtdeASerDevolvida.Value Then
            oParametro(3) = DBParametro_Montar("VLAPLICACAO", 0 - objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_ValorNF))
        Else
            oParametro(3) = DBParametro_Montar("VLAPLICACAO", 0 - Math.Round(objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_ValorNF) / _
                                                                             objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_QtdeLiquidoNF) * _
                                                                             txtKGNotaFiscal.Value, 2))
        End If

        oParametro(4) = DBParametro_Montar("QTAPLICACAO", 0 - txtKGNotaFiscal.Value)

        If Not DBExecutar(SqlText, oParametro) Then GoTo Sair

        QT_SALDO_CESSAO = txtKGNotaFiscal.Value

        SqlText = "SELECT SQ_MOVIMENTACAO_CESSAO_DIREITO, QT_KG_A_FIXAR" & _
                  " FROM SOF.MOVIMENTACAO_CESSAO_DIREITO" & _
                  " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_SQ_MOVIMENTACAO) & _
                    " AND QT_KG_A_FIXAR > 0"
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            If oData.Rows(iCont).Item("QT_KG_A_FIXAR") > QT_SALDO_CESSAO Then
                QT_BAIXAR_CESSAO = QT_SALDO_CESSAO
            Else
                QT_BAIXAR_CESSAO = oData.Rows(iCont).Item("QT_KG_A_FIXAR")
            End If

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO_MOV", False, ":SQCONCIL", ":SQMOV", ":SQMOVCD", _
                                                                          ":VLAPLICACAO", ":QTAPLICACAO")

            oParametro(0) = DBParametro_Montar("SQCONCIL", SQ_CONCILIACAO)
            oParametro(1) = DBParametro_Montar("SQMOV", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_SQ_MOVIMENTACAO))
            oParametro(2) = DBParametro_Montar("SQMOVCD", oData.Rows(iCont).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO"))

            If objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_QtdeLiquidoNF) = txtQtdeASerDevolvida.Value Then
                oParametro(3) = DBParametro_Montar("VLAPLICACAO", objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_ValorNF))
            Else
                oParametro(3) = DBParametro_Montar("VLAPLICACAO", Math.Round(objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_ValorNF) / _
                                                                             objGrid_Valor(grdMovimentacoesDevolucao, cnt_GridMovimetDevolucao_QtdeLiquidoNF) * _
                                                                             QT_BAIXAR_CESSAO, 2))
            End If

            oParametro(4) = DBParametro_Montar("QTAPLICACAO", QT_BAIXAR_CESSAO)

            If Not DBExecutar(SqlText, oParametro) Then GoTo Sair

            QT_SALDO_CESSAO = QT_SALDO_CESSAO - QT_BAIXAR_CESSAO

            If QT_SALDO_CESSAO = 0 Then Exit For
        Next

        oData.Dispose()
        oData = Nothing

        bOk = True

Sair:
        Return bOk
    End Function

    Private Sub cmdSobe_Movimentacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSobe_Movimentacao.Click
        Dim bRecarregar As Boolean = False
        Dim iCont As Integer

        If objGrid_LinhaSelecionada(grdListagemMovimentacaoSelecionadas) = -1 Then
            Msg_Mensagem("Selecione a linha a ser excluída")
            Exit Sub
        End If

        If Not Msg_Perguntar("Deseja realmente excluir esse registro?") Then Exit Sub

        bRecarregar = ((objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_CD_ARMAZEM) = _
                        cboArmazem.SelectedValue) And _
                       (objGrid_Valor(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_Pilha) = _
                        cboPilha.SelectedValue))

        'Verifica se existe uma lançamento de sacaria de elimina, isso é feito para que o volume fique proporcional
        iCont = 0

        With oSacariaMovimentacao
            Do While iCont = .Rows.Count
                If .Rows(iCont).Item("CD_ARMAZEM") = objGrid_Valor(grdListagemMovimentacaoSelecionadas, _
                                                                   cnt_GridListaMovimentSelecionadas_CD_ARMAZEM) And _
                   .Rows(iCont).Item("CD_PILHA") = objGrid_Valor(grdListagemMovimentacaoSelecionadas, _
                                                                   cnt_GridListaMovimentSelecionadas_Pilha) And _
                   .Rows(iCont).Item("SQ_MOVIMENTACAO") = objGrid_Valor(grdListagemMovimentacaoSelecionadas, _
                                                                        cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO) And _
                   .Rows(iCont).Item("SQ_MOVIMENTACAO_PILHA_ARMAZEM") = objGrid_Valor(grdListagemMovimentacaoSelecionadas, _
                                                                                      cnt_GridListaMovimentSelecionadas_SQ_MOVIMENTACAO_PILHA_ARMAZEM) Then
                    .Rows(iCont).Delete()
                Else
                    iCont = iCont + 1
                End If
            Loop
        End With

        grdListagemMovimentacaoSelecionadas.DisplayLayout.ActiveRow.Delete()

        If bRecarregar Then
            PesquisarMovimentacao()
        End If

        lblKGSelecionadoDevolucao.Text = objGrid_CalcularTotalColuna(grdListagemMovimentacaoSelecionadas, cnt_GridListaMovimentSelecionadas_KGTransferir)
    End Sub

    Private Sub grdListagemMovimentacaoSelecionadas_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdListagemMovimentacaoSelecionadas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdListagemMovimentacaoDisponiveis_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdListagemMovimentacaoDisponiveis.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub CalculaPesoBruto()
        txtKGBruto.Value = txtKGLiquido.Value + txtPesoSacaria.Value
    End Sub

    Private Sub txtKGLiquido_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKGLiquido.ValueChanged
        CalculaPesoBruto()
    End Sub

    Private Sub txtPesoSacaria_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPesoSacaria.ValueChanged
        CalculaPesoBruto()
    End Sub


    Private Sub frmMovimentacaoCacau_Devolucao_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim oTab As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        If tbcGeral.ActiveTab Is Nothing Then
            oTab = tabMovimentacoesDisponiveisDevolucao
        Else
            oTab = tbcGeral.ActiveTab.TabPage
        End If

        tbcGeral.Height = Me.ClientSize.Height - tbcGeral.Top - 53
        'Largura
        tbcGeral.Width = Me.ClientSize.Width - tbcGeral.Left - 6
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 6
        'Posição vertical
        cmdGravar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
    
        
        'tabMovimentacoesDisponiveisDevolucao

        grpDados.Top = oTab.Height - 160
        grdMovimentacoesDevolucao.Height = oTab.Height - grdMovimentacoesDevolucao.Top - 165
        grdMovimentacoesDevolucao.Width = oTab.Width - 15
        ''tabMovimentacoesEstoque
        grdListagemMovimentacaoDisponiveis.Width = oTab.Width - 60
        grdListagemMovimentacaoSelecionadas.Width = oTab.Width - 60
        cmdDesce_Movimentacao.Left = oTab.Width - cmdDesce_Movimentacao.Width - 6
        cmdSobe_Movimentacao.Left = oTab.Width - cmdSobe_Movimentacao.Width - 6
        grdListagemMovimentacaoDisponiveis.Height = ((oTab.Height - grdListagemMovimentacaoDisponiveis.Top) / 2) - 10
        grdListagemMovimentacaoSelecionadas.Height = ((oTab.Height - grdListagemMovimentacaoDisponiveis.Top) / 2) - 10
        grdListagemMovimentacaoSelecionadas.Top = oTab.Height - ((oTab.Height - grdListagemMovimentacaoDisponiveis.Top) / 2) + 10
        lbl_MovimentcaoSelecionada.Top = oTab.Height - ((oTab.Height - grdListagemMovimentacaoDisponiveis.Top) / 2) - 8

        cmdDesce_Movimentacao.Top = grdListagemMovimentacaoDisponiveis.Top
        cmdSobe_Movimentacao.Top = grdListagemMovimentacaoSelecionadas.Top
    End Sub
End Class