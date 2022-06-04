Imports Infragistics.Win

Public Class frmControle_AprovacaoPendente
    Const cnt_GridGeral_TP_APROVACAO As Integer = 0
    Const cnt_GridGeral_TipoAprovacao As Integer = 1
    Const cnt_GridGeral_Quantidade As Integer = 2

    Const cnt_GridListagem_TP_APROVACAO As Integer = 0
    Const cnt_GridListagem_Data As Integer = 1
    Const cnt_GridListagem_Numero As Integer = 2
    Const cnt_GridListagem_Status As Integer = 3
    Const cnt_GridListagem_Descricao As Integer = 4
    Const cnt_GridListagem_Codigo As Integer = 5
    Const cnt_GridListagem_SqPDc As Integer = 6
    Const cnt_GridListagem_SqProduto As Integer = 7

    Public SoExibirSeExistir As Boolean

    Dim WithEvents oFormCadastroAjuste_RDE As frmCadastroAjuste_RDE
    Dim oDS As New System.Data.DataSet

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub Pesquisa_CriarDataSet()
        'Montagem do DataSet - Início
        DBData_Criar(oDS, "Listagem", New String() {"TP_APROVACAO", "Data", "Código", " ", "Descrição", "Cod Interno", "Sq Pdc", "Sq Prod"}, _
                                      New eDbType() {eDbType._Texto, eDbType._Data, eDbType._Texto, eDbType._Texto, eDbType._Texto, eDbType._Numero, eDbType._Numero, eDbType._Numero})

        'Montagem do DataSet - Fim
        DBData_Relationamento_Criar(oDS, "FK_Listagem", _
                                         oDS.Tables(0), New String() {oDS.Tables(0).Columns(cnt_GridGeral_TP_APROVACAO).ColumnName}, _
                                         oDS.Tables(1), New String() {"TP_APROVACAO"})

        objGrid_Band_Formatar(grdGeral.DisplayLayout.Bands(1), UltraWinGrid.CellClickAction.RowSelect)

        With grdGeral.DisplayLayout.Bands(1)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridListagem_TP_APROVACAO), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridListagem_Data), Nothing, 90)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridListagem_Numero), Nothing, 80)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridListagem_Status), Nothing, 30)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridListagem_Descricao), Nothing, 450, , , , , DefaultableBoolean.True)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridListagem_Codigo), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridListagem_SqPDc), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridListagem_SqProduto), Nothing, 0)
        End With
    End Sub

    Private Sub grdGeral_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdGeral.DoubleClickRow
        If e.Row.Band.Index = 0 Then
            If e.Row.IsExpanded Then
                e.Row.CollapseAll()
            Else
                e.Row.ExpandAll()
            End If
        Else
            Select Case e.Row.Cells(cnt_GridListagem_TP_APROVACAO).Value
                Case "ARD"
                    oFormCadastroAjuste_RDE = New frmCadastroAjuste_RDE
                    oFormCadastroAjuste_RDE.SQ_ACERTO = objGrid_Valor(grdGeral, cnt_GridListagem_Codigo)
                    oFormCadastroAjuste_RDE.AjusteRDE_AcaoTela = frmCadastroAjuste_RDE.enAjusteRDE_AcaoTela.Aprovacao
                    Form_Show(Me.MdiParent, oFormCadastroAjuste_RDE, True, True)
            End Select
        End If
    End Sub

    Private Sub frmControle_AprovacaoPendente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Carregar()
    End Sub

    Private Sub Carregar()
        If SoExibirSeExistir Then Me.Hide()

        Dim oData As DataTable = Nothing
        Dim oRow As DataRow
        Dim SqlText As String
        Dim iCont As Integer

        oDS = New System.Data.DataSet

        objGrid_Inicializar(grdGeral, , oDS, Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect, , , False, UltraWinGrid.ViewStyleBand.Horizontal, UltraWinGrid.RowSelectorHeaderStyle.None, _
                            UltraWinGrid.SelectType.Extended)
        objGrid_Coluna_Add(grdGeral, "TP_APROVACAO", 0)
        objGrid_Coluna_Add(grdGeral, "Tipo da Aprovação", 150)
        objGrid_Coluna_Add(grdGeral, "Quantidade", 0)

        Pesquisa_CriarDataSet()

        If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_Abrir_FecharContratoFixo) Then
            'Aprovação de Ajuste de RD
            SqlText = "SELECT AC.DT_AJUSTE," & _
                             "AC.SQ_ACERTO," & _
                             "TRIM(PS.NO_STATUS) || ' - ' || TRIM(FO.NO_FILIAL) || ' - ' || TRIM(TM.NO_TIPO_MOVIMENTACAO) || NVL2(FN.CD_FORNECEDOR, ' - ' || TRIM(FN.NO_RAZAO_SOCIAL), '') NO_TITULO" & _
                      " FROM SOF.RESUMO_DIARIO_ESTOQUE_ACERTO AC," & _
                            "SOF.PROCESSO_STATUS PS," & _
                            "SOF.TIPO_MOVIMENTACAO TM," & _
                            "SOF.FILIAL FO," & _
                            "SOF.FORNECEDOR FN" & _
                      " WHERE AC.IC_APROVADO IS NULL" & _
                        " AND PS.CD_STATUS = AC.CD_TIPO_ACERTO" & _
                        " AND PS.CD_PROCESSO = " & cnt_Processo_TipoAjusteRD & _
                        " AND TM.CD_TIPO_MOVIMENTACAO = AC.CD_TIPO_MOVIMENTACAO" & _
                        " AND FO.CD_FILIAL = AC.CD_FILIAL_ORIGEM" & _
                        " AND FN.CD_FORNECEDOR (+) = AC.CD_FORNECEDOR" & _
                      " ORDER BY TRIM(PS.NO_STATUS) || ' - ' || TRIM(FO.NO_FILIAL) || ' - ' || TRIM(TM.NO_TIPO_MOVIMENTACAO) || NVL2(FN.CD_FORNECEDOR, ' - ' || TRIM(FN.NO_RAZAO_SOCIAL), '')"
            oData = DBQuery(SqlText)

            If oData.Rows.Count > 0 Then
                oRow = oDS.Tables(0).Rows.Add

                oRow.Item(cnt_GridGeral_TP_APROVACAO) = "ARD"
                oRow.Item(cnt_GridGeral_TipoAprovacao) = "Ajuste de RD"
                oRow.Item(cnt_GridGeral_Quantidade) = oData.Rows.Count

                For iCont = 0 To oData.Rows.Count - 1
                    oRow = oDS.Tables(1).Rows.Add

                    With oData.Rows(iCont)
                        oRow.Item(cnt_GridListagem_TP_APROVACAO) = "ARD"
                        oRow.Item(cnt_GridListagem_Data) = .Item("DT_AJUSTE")
                        oRow.Item(cnt_GridListagem_Numero) = .Item("SQ_ACERTO")
                        oRow.Item(cnt_GridListagem_Descricao) = .Item("NO_TITULO")
                        oRow.Item(cnt_GridListagem_Codigo) = .Item("SQ_ACERTO")
                    End With
                Next
            End If
        End If

        For iCont = 0 To grdGeral.Rows.Count - 1
            grdGeral.Rows(iCont).Expanded = True
        Next

        Dim gridRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        gridRow = grdGeral.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)

        Do Until gridRow Is Nothing
            ' look for child
            If gridRow.HasChild = True Then
                gridRow = gridRow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First)
                ' look for sibling
            ElseIf gridRow.HasNextSibling = True Then
                gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
                ' look for parent with siblings
            ElseIf gridRow.Band.Index > 0 Then
                Do Until gridRow.HasNextSibling = True
                    If gridRow.Band.Index > 0 Then
                        gridRow = gridRow.ParentRow
                    Else
                        gridRow = Nothing
                        Exit Do
                    End If
                Loop
                ' we get here get the next sibling row
                If Not gridRow Is Nothing Then
                    gridRow = gridRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
                End If
                ' last row of band zero
            Else
                gridRow = Nothing
            End If
        Loop

        Form_Ajustar_Tamanho(Me)

        If SoExibirSeExistir Then
            If oDS.Tables(0).Rows.Count = 0 Then
                Close()
            Else
                Me.Show()
            End If
        End If
    End Sub

    Private Sub oFormCadastroAjuste_RDE_EfetuouGravacao() Handles oFormCadastroAjuste_RDE.EfetuouGravacao
        Carregar()
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Carregar()
    End Sub
End Class