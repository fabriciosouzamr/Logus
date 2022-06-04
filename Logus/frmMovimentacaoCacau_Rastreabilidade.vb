Public Class frmMovimentacaoCacau_Rastreabilidade
    Dim SEQ_MOVIMENTACAO As Integer
    Dim oDS_Historico As New Infragistics.Win.UltraWinDataSource.UltraDataSource
    Dim oDS_TransferenciaItem As New Infragistics.Win.UltraWinDataSource.UltraDataSource

    Const cnt_ImgTvw_Industrializacao As Integer = 0
    Const cnt_ImgTvw_Movimentacao As Integer = 1
    Const cnt_ImgTvw_MovimentacaoInicial As Integer = 2
    Const cnt_ImgTvw_Propriedade As Integer = 3
    Const cnt_ImgTvw_Transferencia As Integer = 4

    Const cnt_GridHistorico_Seq As Integer = 0
    Const cnt_GridHistorico_DataTransacao As Integer = 1
    Const cnt_GridHistorico_Armazem As Integer = 2
    Const cnt_GridHistorico_Pilha As Integer = 3
    Const cnt_GridHistorico_Volume As Integer = 4
    Const cnt_GridHistorico_Movimentacao As Integer = 5

    Const cnt_GridTransferenciaItem_KgTransferido As Integer = 0
    Const cnt_GridTransferenciaItem_FornecedorFilial As Integer = 1
    Const cnt_GridTransferenciaItem_TipoMovimentacao As Integer = 2
    Const cnt_GridTransferenciaItem_KgLiqNF As Integer = 3
    Const cnt_GridTransferenciaItem_NF As Integer = 4
    Const cnt_GridTransferenciaItem_SerieNF As Integer = 5
    Const cnt_GridTransferenciaItem_KgBrutoNF As Integer = 6
    Const cnt_GridTransferenciaItem_KgNF As Integer = 7
    Const cnt_GridTransferenciaItem_ValorNF As Integer = 8
    Const cnt_GridTransferenciaItem_Seq As Integer = 9
    Const cnt_GridTransferenciaItem_Umidade As Integer = 10
    Const cnt_GridTransferenciaItem_Sujidade As Integer = 11
    Const cnt_GridTransferenciaItem_Tipo As Integer = 12
    Const cnt_GridTransferenciaItem_DataMovimentacao As Integer = 13
    Const cnt_GridTransferenciaItem_MunicipioOrigem As Integer = 14
    Const cnt_GridTransferenciaItem_UF As Integer = 15

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub pnlBotoes_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBotoes.Resize
        cmdFechar.Left = pnlBotoes.Width - cmdFechar.Width - 3
    End Sub

    Public Sub Movimentacao(ByVal SQ_MOVIMENTACAO As Integer)
        SEQ_MOVIMENTACAO = SQ_MOVIMENTACAO

        tvwMovimentacao.Nodes.Clear()

        TreeView_CarregarDadosMovimentacao(Nothing, SQ_MOVIMENTACAO, True)
    End Sub

    Private Sub TreeView_CarregarDadosMovimentacao(ByVal oNode As System.Windows.Forms.TreeNode, _
                                                   ByVal SQ_MOVIMENTACAO As Integer, _
                                                   Optional ByVal ListaSubItens As Boolean = False, _
                                                   Optional ByVal SQ_MOVIMENTACAO_SUPERIOR As Integer = 0)
        Dim oData As DataTable
        Dim oNodeAux As System.Windows.Forms.TreeNode
        Dim SqlText As String
        Dim sAux As String
        Dim IconeIndex As Integer

        SqlText = "SELECT MV.SQ_MOVIMENTACAO," & _
                         "MV.NU_NF," & _
                         "MV.NU_SERIE_NF," & _
                         "MV.DT_MOVIMENTACAO," & _
                         "FN.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "FI.NO_FILIAL NO_FILIAL_MOVIMENTACAO," & _
                         "MQ.QT_UMIDADE," & _
                         "FD.NO_FILIAL NO_FILIAL_DESTINO," & _
                         "TR.DT_TRANSFERENCIA," & _
                         "TR.DT_CHEGADA," & _
                         "TRD.NO_TRANSFERENCIA_MODALIDADE," & _
                         "FD.NO_FILIAL NO_FILIAL_DESTINO," & _
                         "FO.NO_FILIAL NO_FILIAL_ORIGEM," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "TRD.IC_MOVIMENTACAO_SILO" & _
                  " FROM SOF.MOVIMENTACAO MV," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.FORNECEDOR FN," & _
                        "SOF.MOVIMENTACAO_QUALIDADE MQ," & _
                        "SOF.FILIAL FI," & _
                        "SOF.TRANSFERENCIA TE," & _
                        "SOF.FILIAL FO," & _
                        "SOF.TRANSFERENCIA TR," & _
                        "SOF.TRANSFERENCIA_MODALIDADE TRD," & _
                        "SOF.FILIAL FD" & _
                  " WHERE MV.SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                    " AND MQ.SQ_MOVIMENTACAO = MV.SQ_MOVIMENTACAO" & _
                    " AND TM.CD_TIPO_MOVIMENTACAO = MV.CD_TIPO_MOVIMENTACAO" & _
                    " AND FI.CD_FILIAL = MV.CD_FILIAL_MOVIMENTACAO" & _
                    " AND TE.SQ_MOVIMENTACAO_ENTRADA (+) = MV.SQ_MOVIMENTACAO" & _
                    " AND FO.CD_FILIAL (+) = TE.CD_FILIAL_ORIGEM" & _
                    " AND FN.CD_FORNECEDOR (+) = MV.CD_FORNECEDOR" & _
                    " AND TR.SQ_MOVIMENTACAO_SAIDA (+) = MV.SQ_MOVIMENTACAO" & _
                    " AND TRD.CD_TRANSFERENCIA_MODALIDADE (+) = TR.CD_TRANSFERENCIA_MODALIDADE" & _
                    " AND (NVL(TRD.IC_TIPO_UTILIZACAO, 'X') NOT IN ('T') OR TRD.CD_TRANSFERENCIA_MODALIDADE IS NULL)" & _
                    " AND FD.CD_FILIAL (+) = TR.CD_FILIAL_DESTINO"
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            With oData.Rows(0)
                If oNode Is Nothing Then
                    oNodeAux = tvwMovimentacao.Nodes.Add(.Item("SQ_MOVIMENTACAO"), "")
                Else
                    oNodeAux = oNode.Nodes.Add(.Item("SQ_MOVIMENTACAO"), "")
                End If

                'Verifica o ícone a ser utilizado
                If oNode Is Nothing Then
                    IconeIndex = cnt_ImgTvw_MovimentacaoInicial
                ElseIf objDataTable_LerCampo(.Item("IC_MOVIMENTACAO_SILO"), "N") = "S" Then
                    IconeIndex = cnt_ImgTvw_Industrializacao
                ElseIf Not objDataTable_CampoVazio(.Item("NO_TRANSFERENCIA_MODALIDADE")) Then
                    IconeIndex = cnt_ImgTvw_Transferencia
                Else
                    IconeIndex = cnt_ImgTvw_Movimentacao
                End If

                oNodeAux.Tag = .Item("SQ_MOVIMENTACAO")

                If SQ_MOVIMENTACAO_SUPERIOR = .Item("SQ_MOVIMENTACAO") Then
                    IconeIndex = cnt_ImgTvw_MovimentacaoInicial
                End If

                oNodeAux.ImageIndex = IconeIndex
                oNodeAux.SelectedImageIndex = IconeIndex

                sAux = "NF "

                If Not objDataTable_CampoVazio(.Item("NU_NF")) Then
                    sAux = sAux & Trim(.Item("NU_NF"))

                    If Not objDataTable_CampoVazio(.Item("NU_SERIE_NF")) Then
                        sAux = sAux & "-" & Trim(.Item("NU_SERIE_NF"))
                    End If
                End If

                If Not objDataTable_CampoVazio(.Item("NO_TRANSFERENCIA_MODALIDADE")) Then
                    sAux = sAux & " - " & Trim(.Item("NO_TRANSFERENCIA_MODALIDADE"))
                ElseIf Not objDataTable_CampoVazio(.Item("NO_FORNECEDOR")) Then
                    sAux = sAux & " - " & Trim(.Item("NO_FORNECEDOR"))
                ElseIf Not objDataTable_CampoVazio(.Item("NO_TIPO_MOVIMENTACAO")) Then
                    sAux = sAux & " - " & Trim(.Item("NO_TIPO_MOVIMENTACAO"))
                End If

                oNodeAux.Text = sAux

                If Not objDataTable_CampoVazio(.Item("NO_TRANSFERENCIA_MODALIDADE")) Then
                    TvwNode_Add(oNodeAux, "Filial de Destino: " & .Item("NO_FILIAL_DESTINO"), cnt_ImgTvw_Propriedade)
                    TvwNode_Add(oNodeAux, "Data de Envio: " & Format(.Item("DT_TRANSFERENCIA"), "dd/MM/yyyy"), cnt_ImgTvw_Propriedade)

                    If objDataTable_CampoVazio(.Item("DT_CHEGADA")) Then
                        TvwNode_Add(oNodeAux, "Data de Chegada: ", cnt_ImgTvw_Propriedade)
                    Else
                        TvwNode_Add(oNodeAux, "Data de Chegada: " & Format(.Item("DT_CHEGADA"), "dd/MM/yyyy"), cnt_ImgTvw_Propriedade)
                    End If
                ElseIf Not objDataTable_CampoVazio(.Item("NO_FORNECEDOR")) Then
                    TvwNode_Add(oNodeAux, "Data: " & Format(.Item("DT_MOVIMENTACAO"), "dd/MM/yyyy"), cnt_ImgTvw_Propriedade)
                    TvwNode_Add(oNodeAux, "Filial de Movimentação: " & .Item("NO_FILIAL_MOVIMENTACAO"), cnt_ImgTvw_Propriedade)
                End If

                If Not objDataTable_CampoVazio(.Item("NO_FILIAL_ORIGEM")) Then
                    TvwNode_Add(oNodeAux, "Filial de Origem: " & .Item("NO_FILIAL_ORIGEM"), cnt_ImgTvw_Propriedade)
                End If

                TvwNode_Add(oNodeAux, "Umidade: " & Format(.Item("QT_UMIDADE"), "##0.00") & " %", cnt_ImgTvw_Propriedade)
            End With

            If ListaSubItens Then
                TreeView_IdentificaMovimentacao(oNodeAux, oData.Rows(0).Item("SQ_MOVIMENTACAO"))
            End If
        End If

        oData.Dispose()
        oData = Nothing
    End Sub

    Private Sub TvwNode_Add(ByVal oNode As System.Windows.Forms.TreeNode, _
                            ByVal Titulo As String, _
                            ByVal Icone As Integer)
        Dim oNodeAux As System.Windows.Forms.TreeNode

        oNodeAux = oNode.Nodes.Add(Titulo)
        oNodeAux.ImageIndex = Icone
    End Sub

    Private Sub TreeView_IdentificaMovimentacao(ByVal oNode As System.Windows.Forms.TreeNode, _
                                                ByVal SQ_MOVIMENTACAO As Integer)
        Dim oData As DataTable
        Dim SqlText As String
        Dim iCont As Integer
        Dim SQ_MOVIMENTACAO_SUPERIOR As Long = 0

        AVI_Carregar(Me)

        If Not oNode.Parent Is Nothing Then
            SQ_MOVIMENTACAO_SUPERIOR = Math.Abs(oNode.Parent.Tag)
        End If

        oNode.Tag = 0 - oNode.Tag

        SqlText = "SELECT DISTINCT TR.SQ_MOVIMENTACAO_SAIDA SQ_MOVIMENTACAO" & _
                  " FROM SOF.TRANSFERENCIA TR" & _
                  " WHERE TR.SQ_MOVIMENTACAO_ENTRADA = " & SQ_MOVIMENTACAO
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            TreeView_CarregarDadosMovimentacao(oNode, oData.Rows(iCont).Item("SQ_MOVIMENTACAO"), , SQ_MOVIMENTACAO_SUPERIOR)
        Next

        SqlText = "SELECT DISTINCT IT.SQ_MOVIMENTACAO" & _
                  " FROM SOF.TRANSFERENCIA TR," & _
                        "SOF.ITEM_TRANSFERENCIA IT" & _
                  " WHERE TR.SQ_MOVIMENTACAO_SAIDA = " & SQ_MOVIMENTACAO & _
                    " AND IT.SQ_TRANSFERENCIA = TR.SQ_TRANSFERENCIA"
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            TreeView_CarregarDadosMovimentacao(oNode, oData.Rows(iCont).Item("SQ_MOVIMENTACAO"), , SQ_MOVIMENTACAO_SUPERIOR)
        Next

        SqlText = "SELECT DISTINCT TR.SQ_MOVIMENTACAO_SAIDA SQ_MOVIMENTACAO" & _
                  " FROM SOF.ITEM_TRANSFERENCIA IT," & _
                        "SOF.TRANSFERENCIA TR" & _
                  " WHERE IT.SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                    " AND TR.SQ_TRANSFERENCIA = IT.SQ_TRANSFERENCIA"
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            If SQ_MOVIMENTACAO_SUPERIOR <> oData.Rows(iCont).Item("SQ_MOVIMENTACAO") Then
                TreeView_CarregarDadosMovimentacao(oNode, oData.Rows(iCont).Item("SQ_MOVIMENTACAO"), , SQ_MOVIMENTACAO_SUPERIOR)
            End If
        Next

        AVI_Fechar(Me)
    End Sub

    Private Sub tvwMovimentacao_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvwMovimentacao.BeforeExpand
        oDS_Historico.Rows.Clear()
        oDS_TransferenciaItem.Rows.Clear()

        If e.Node.Tag > 0 Then
            TreeView_IdentificaMovimentacao(e.Node, e.Node.Tag)
        End If
    End Sub

    Private Sub CarregarMovimentacaoHistorico(ByVal SQ_MOVIMENTACAO As Integer)
        Dim SqlText As String

        SqlText = "SELECT C.SQ_MOV_PILHA_ARMAZEM_HISTORICO," & _
                         "C.DT_TRANSACAO," & _
                         "A.NO_ARMAZEM," & _
                         "C.CD_PILHA_ARMAZEM," & _
                         "DECODE(C.IC_SAIDA, 'S', 0 - C.QT_VOLUME, C.QT_VOLUME) QT_VOLUME," & _
                         "DECODE(C.SQ_ITEM_TRANSFERENCIA," & _
                                "NULL," & _
                                "DECODE(C.SQ_ESTOQUE_SILO," & _
                                       "NULL," & _
                                       "DECODE(C.IC_SAIDA," & _
                                              "'S'," & _
                                              "'MOVIMENTAÇÃO ENTRE PILHAS'," & _
                                              "'ENTRADA')," & _
                                       "'SILO')," & _
                                "'TRANSFERENCIA') AS NO_MOVIMENTACAO" & _
                  " FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO C," & _
                        "SOF.PILHA_ARMAZEM B," & _
                        "SOF.ARMAZEM A" & _
                  " WHERE B.CD_ARMAZEM = C.CD_ARMAZEM" & _
                    " AND B.CD_PILHA_ARMAZEM = C.CD_PILHA_ARMAZEM" & _
                    " AND A.CD_ARMAZEM = B.CD_ARMAZEM" & _
                    " AND C.SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO

        objGrid_Carregar(grdHistorico, SqlText, New Integer() {cnt_GridHistorico_Seq, cnt_GridHistorico_DataTransacao, _
                                                               cnt_GridHistorico_Armazem, cnt_GridHistorico_Pilha, _
                                                               cnt_GridHistorico_Volume, cnt_GridHistorico_Movimentacao})
    End Sub

    Private Sub CarregarTransferenciaItem(ByVal SQ_TRANSFERENCIA As Integer, ByVal SQ_MOVIMENTACAO_SUPERIOR As Integer)
        Dim SqlText As String
        Dim iCont As Integer

        SqlText = "SELECT IT.KG_TRANSFERIDO," & _
                         "DECODE(F.NO_RAZAO_SOCIAL, NULL, FIL.NO_FILIAL, F.NO_RAZAO_SOCIAL) NO_PESSOA," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "M.QT_KG_LIQUIDO_NF," & _
                         "M.NU_NF," & _
                         "M.NU_SERIE_NF," & _
                         "M.QT_KG_BRUTO_NF," & _
                         "M.QT_KG_NF," & _
                         "M.VL_NF," & _
                         "M.SQ_MOVIMENTACAO," & _
                         "MQUALI.QT_UMIDADE," & _
                         "MQUALI.PC_SUJIDADE," & _
                         "DECODE(MQUALI.IC_TIPO_CACAU, 4, 'R', TO_CHAR(MQUALI.IC_TIPO_CACAU)) AS TIPO," & _
                         "M.DT_MOVIMENTACAO," & _
                         "MUNIC.NO_CIDADE," & _
                         "MUNIC.CD_UF" & _
                  " FROM SOF.MOVIMENTACAO M," & _
                        "SOF.ITEM_TRANSFERENCIA IT," & _
                        "SOF.TRANSFERENCIA T," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.MOVIMENTACAO_QUALIDADE MQUALI," & _
                        "SOF.MUNICIPIO MUNIC" & _
                  " WHERE IT.SQ_TRANSFERENCIA = " & SQ_TRANSFERENCIA & _
                    " AND M.SQ_MOVIMENTACAO = IT.SQ_MOVIMENTACAO" & _
                    " AND MQUALI.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                    " AND TM.CD_TIPO_MOVIMENTACAO = M.CD_TIPO_MOVIMENTACAO" & _
                    " AND MUNIC.CD_MUNICIPIO (+) = M.CD_MUNICIPIO_ORIGEM" & _
                    " AND F.CD_FORNECEDOR (+) = M.CD_FORNECEDOR" & _
                    " AND T.SQ_MOVIMENTACAO_ENTRADA (+) = M.SQ_MOVIMENTACAO" & _
                    " AND FIL.CD_FILIAL(+) = T.CD_FILIAL_ORIGEM"
        objGrid_Carregar(grdTransferenciaItem, SqlText, New Integer() {cnt_GridTransferenciaItem_KgTransferido, _
                                                                       cnt_GridTransferenciaItem_FornecedorFilial, _
                                                                       cnt_GridTransferenciaItem_TipoMovimentacao, _
                                                                       cnt_GridTransferenciaItem_KgLiqNF, _
                                                                       cnt_GridTransferenciaItem_NF, _
                                                                       cnt_GridTransferenciaItem_SerieNF, _
                                                                       cnt_GridTransferenciaItem_KgBrutoNF, _
                                                                       cnt_GridTransferenciaItem_KgNF, _
                                                                       cnt_GridTransferenciaItem_ValorNF, _
                                                                       cnt_GridTransferenciaItem_Seq, _
                                                                       cnt_GridTransferenciaItem_Umidade, _
                                                                       cnt_GridTransferenciaItem_Sujidade, _
                                                                       cnt_GridTransferenciaItem_Tipo, _
                                                                       cnt_GridTransferenciaItem_DataMovimentacao, _
                                                                       cnt_GridTransferenciaItem_MunicipioOrigem, _
                                                                       cnt_GridTransferenciaItem_UF})

        For iCont = 0 To grdTransferenciaItem.Rows.Count - 1
            If grdTransferenciaItem.Rows(iCont).Cells(cnt_GridTransferenciaItem_Seq).Value = SQ_MOVIMENTACAO_SUPERIOR Then
                grdTransferenciaItem.Rows(iCont).Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            End If
        Next

        If grdTransferenciaItem.Rows.Count = 0 Then
            SplitContainer2.Panel2Collapsed = False
        End If
    End Sub

    Private Sub frmMovimentacaoCacauRastreabilidade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objGrid_Inicializar(grdHistorico, , oDS_Historico, Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect)
        grdHistorico.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True
        grdHistorico.Text = "Consulta Historico Movimentação Pilha"
        objGrid_Coluna_Add(grdHistorico, "Seq", 100)
        objGrid_Coluna_Add(grdHistorico, "Data da Transação", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdHistorico, "Armazem", 100)
        objGrid_Coluna_Add(grdHistorico, "Pilha", 100)
        objGrid_Coluna_Add(grdHistorico, "Volume", 100)
        objGrid_Coluna_Add(grdHistorico, "Movimentação", 150)

        objGrid_Inicializar(grdTransferenciaItem, , oDS_TransferenciaItem, Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect)
        grdTransferenciaItem.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True
        grdTransferenciaItem.Text = "Itens da Transferência"
        objGrid_Coluna_Add(grdTransferenciaItem, "Kg Transferido", 100)
        objGrid_Coluna_Add(grdTransferenciaItem, "Fornecedor/Filial", 150)
        objGrid_Coluna_Add(grdTransferenciaItem, "Tipo Movimentação", 150)
        objGrid_Coluna_Add(grdTransferenciaItem, "Kg Liq NF", 100)
        objGrid_Coluna_Add(grdTransferenciaItem, "NF", 100)
        objGrid_Coluna_Add(grdTransferenciaItem, "Serie NF", 100)
        objGrid_Coluna_Add(grdTransferenciaItem, "Kg Bruto NF", 100)
        objGrid_Coluna_Add(grdTransferenciaItem, "Kg NF", 100)
        objGrid_Coluna_Add(grdTransferenciaItem, "Valor NF", 100)
        objGrid_Coluna_Add(grdTransferenciaItem, "Seq", 100)
        objGrid_Coluna_Add(grdTransferenciaItem, "Umidade", 100)
        objGrid_Coluna_Add(grdTransferenciaItem, "Sujidade", 100)
        objGrid_Coluna_Add(grdTransferenciaItem, "Tipo", 100)
        objGrid_Coluna_Add(grdTransferenciaItem, "Data Movimentação", 150, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdTransferenciaItem, "Municipio Origem", 150)
        objGrid_Coluna_Add(grdTransferenciaItem, "UF", 80)

        GridTransferenciaItem_Limpar()
    End Sub

    Private Sub tvwMovimentacao_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvwMovimentacao.BeforeSelect
        Dim SqlText As String
        Dim SQ_TRANSFERENCIA As Integer = 0
        Dim SQ_MOVIMENTACAO_SUPERIOR As Integer = 0

        If e.Node.Tag Is Nothing Then Exit Sub

        oDS_Historico.Rows.Clear()
        GridTransferenciaItem_Limpar()

        If Not e.Node.Parent Is Nothing Then
            SQ_MOVIMENTACAO_SUPERIOR = Math.Abs(e.Node.Parent.Tag)
        End If

        CarregarMovimentacaoHistorico(Math.Abs(e.Node.Tag))

        'SqlText = "SELECT NVL(SQ_TRANSFERENCIA, 0) FROM SOF.TRANSFERENCIA" & _
        '          " WHERE SQ_MOVIMENTACAO_SAIDA = " & Math.Abs(e.Node.Tag)
        'SQ_TRANSFERENCIA = DBQuery_ValorUnico(SqlText)

        'If SQ_TRANSFERENCIA > 0 Then
        '    CarregarTransferenciaItem(SQ_TRANSFERENCIA, SQ_MOVIMENTACAO_SUPERIOR)
        'End If
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Movimentacao(SEQ_MOVIMENTACAO)
    End Sub

    Private Sub GridTransferenciaItem_Limpar()
        oDS_TransferenciaItem.Rows.Clear()
        SplitContainer2.Panel2Collapsed = True
    End Sub
End Class