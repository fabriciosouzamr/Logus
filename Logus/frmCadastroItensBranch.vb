Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroItensBranch
    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim CdItemBranch As Integer

    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_Nome As Integer = 1
    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdicionar.Click
        Dim iCont As Integer
        Dim bAchou As Boolean = False

        If Pesq_TipoMovimentacao.Codigo < 1 Then
            Msg_Mensagem("Informe o tipo de movimentação")
            Exit Sub
        End If


        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_Valor(grdGeral, cnt_GridGeral_Codigo, iCont) = _
               Pesq_TipoMovimentacao.Codigo Then
                bAchou = True
                Exit For
            End If
        Next

        If bAchou Then
            Msg_Mensagem("Já foi adicionada esse tipo de movimentação")
            Exit Sub
        End If

        oDS.Rows.Add()

        With oDS.Rows(oDS.Rows.Count - 1)
            .Item(cnt_GridGeral_Codigo) = Pesq_TipoMovimentacao.Codigo
            .Item(cnt_GridGeral_Nome) = Pesq_TipoMovimentacao.Descricao
        End With

        Pesq_TipoMovimentacao.Codigo = 0
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim iCont As Integer
        Dim SqlText As String
        Dim Parametro(1) As DBParamentro

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar uma descrição para o item de branch.")
            txtDescricao.Focus()
            Exit Sub
        End If

        DBUsarTransacao = True

        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            CdItemBranch = DBNumeroMaisUm("SOF.BRANCHE_ITEM", "CD_BRANCHE_ITEM")

            SqlText = DBMontar_Insert("SOF.BRANCHE_ITEM", TipoCampoFixo.Todos, "NO_BRANCHE_ITEM", ":NO_BRANCHE_ITEM", _
                                                                           "CD_BRANCHE_ITEM", ":CD_BRANCHE_ITEM")
        Else
            SqlText = DBMontar_Update("SOF.BRANCHE_ITEM", GerarArray("NO_BRANCHE_ITEM", ":NO_BRANCHE_ITEM"), _
                                                      GerarArray("CD_BRANCHE_ITEM", ":CD_BRANCHE_ITEM"))
        End If

        Parametro(0) = DBParametro_Montar("NO_BRANCHE_ITEM", txtDescricao.Text)
        Parametro(1) = DBParametro_Montar("CD_BRANCHE_ITEM", CdItemBranch)


        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro


        SqlText = "delete from sof.branche_item_tipo_movimentacao where CD_BRANCHE_ITEM=" & CdItemBranch
        If Not DBExecutar(SqlText) Then GoTo Erro

        For iCont = 0 To grdGeral.Rows.Count - 1
            SqlText = DBMontar_Insert("SOF.branche_item_tipo_movimentacao", TipoCampoFixo.DadoCriacao, _
                                                                   "CD_BRANCHE_ITEM", ":CD_BRANCHE_ITEM", _
                                                                   "CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO")


            If Not DBExecutar(SqlText, _
                              DBParametro_Montar("CD_BRANCHE_ITEM", CdItemBranch), _
                              DBParametro_Montar("CD_TIPO_MOVIMENTACAO", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo, iCont))) Then GoTo ERRO
        Next

        If Not DBExecutarTransacao() Then GoTo Erro
        Me.Close()
        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub frmCadastroItensBranch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_TipoMovimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TipoMovimentacao.BancoDados_Filtro_Limpar()
        Pesq_TipoMovimentacao.BancoDados_Filtro_Adicionar("IC_ATIVO = 'S'")

        ControleEdicaoTelaLocal = ControleEdicaoTela
        CdItemBranch = Filtro

        objGrid_Inicializar(grdGeral, , oDS, CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdGeral, "Código", 0)
        objGrid_Coluna_Add(grdGeral, "Tipo Movimentação", 200)

        grdGeral.DisplayLayout.Bands(0).Override.AllowDelete = DefaultableBoolean.True
        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            CarregarDados()
        End If
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * FROM SOF.BRANCHE_ITEM WHERE CD_BRANCHE_ITEM=" & CdItemBranch
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            lblCodigo.Text = oData.Rows(0).Item("CD_BRANCHE_ITEM")
            txtDescricao.Text = oData.Rows(0).Item("NO_BRANCHE_ITEM")

            '>> Grid 
            SqlText = "SELECT BITM.CD_TIPO_MOVIMENTACAO, TM.NO_TIPO_MOVIMENTACAO " & _
                      "FROM SOF.TIPO_MOVIMENTACAO TM, SOF.BRANCHE_ITEM_TIPO_MOVIMENTACAO BITM " & _
                      "WHERE BITM.CD_TIPO_MOVIMENTACAO = TM.CD_TIPO_MOVIMENTACAO AND " & _
                      "BITM.CD_BRANCHE_ITEM = " & CdItemBranch
            objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, _
                                                                    cnt_GridGeral_Nome})
        End If
    End Sub
End Class