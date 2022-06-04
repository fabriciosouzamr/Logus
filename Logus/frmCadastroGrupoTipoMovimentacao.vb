Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroGrupoTipoMovimentacao
    Dim ControleEdicaoTelaLocal As eControleEdicaoTela
    Dim CdGrupoTipoMovimentacao As Integer

    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_Nome As Integer = 1
    Const cnt_GridGeral_Ordem As Integer = 2

    Public Cd_Processo As Integer
    Public Cd_Status As Integer

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim iCont As Integer
        Dim SqlText As String
        Dim Parametro(4) As DBParamentro

        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar uma descição do grupo tipo movimentação.")
            txtDescricao.Focus()
            Exit Sub
        End If

        DBUsarTransacao = True

        If ControleEdicaoTelaLocal = eControleEdicaoTela.INCLUIR Then
            CdGrupoTipoMovimentacao = DBNumeroMaisUm("SOF.PARAMETRO_MODALIDADE", "CD_PARAMETRO_MODALIDADE")

            SqlText = DBMontar_Insert("SOF.PARAMETRO_MODALIDADE", TipoCampoFixo.Todos, _
                                                                  "NO_PARAMETRO_MODALIDADE", ":NO_PARAMETRO_MODALIDADE", _
                                                                  "NR_ORDENACAO", ":NR_ORDENACAO", _
                                                                  "CD_PROCESSO", ":CD_PROCESSO", _
                                                                  "CD_STATUS", ":CD_STATUS", _
                                                                  "CD_PARAMETRO_MODALIDADE", ":CD_PARAMETRO_MODALIDADE")
        Else
            SqlText = DBMontar_Update("SOF.PARAMETRO_MODALIDADE", GerarArray("NO_PARAMETRO_MODALIDADE", ":NO_PARAMETRO_MODALIDADE", _
                                                                             "NR_ORDENACAO", ":NR_ORDENACAO", _
                                                                             "CD_PROCESSO", ":CD_PROCESSO", _
                                                                             "CD_STATUS", ":CD_STATUS"), _
                                                                  GerarArray("CD_PARAMETRO_MODALIDADE", ":CD_PARAMETRO_MODALIDADE"))
        End If

        Parametro(0) = DBParametro_Montar("NO_PARAMETRO_MODALIDADE", txtDescricao.Text)
        Parametro(1) = DBParametro_Montar("NR_ORDENACAO", txtOrdem.Value)
        Parametro(2) = DBParametro_Montar("CD_PROCESSO", Cd_Processo)
        Parametro(3) = DBParametro_Montar("CD_STATUS", Cd_Status)
        Parametro(4) = DBParametro_Montar("CD_PARAMETRO_MODALIDADE", CdGrupoTipoMovimentacao)
        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        SqlText = "DELETE FROM SOF.PARAMETRO_MODALIDADE_TIPO_MOV WHERE CD_PARAMETRO_MODALIDADE = " & CdGrupoTipoMovimentacao
        If Not DBExecutar(SqlText) Then GoTo Erro

        For iCont = 0 To grdGeral.Rows.Count - 1
            SqlText = DBMontar_Insert("SOF.PARAMETRO_MODALIDADE_TIPO_MOV", TipoCampoFixo.DadoCriacao, _
                                                                           "CD_PARAMETRO_MODALIDADE", ":CD_PARAMETRO_MODALIDADE", _
                                                                           "NR_ORDENACAO", ":NR_ORDENACAO", _
                                                                           "CD_TIPO_MOVIMENTACAO", ":CD_TIPO_MOVIMENTACAO")

            If Not DBExecutar(SqlText, _
                              DBParametro_Montar("CD_PARAMETRO_MODALIDADE", CdGrupoTipoMovimentacao), _
                              DBParametro_Montar("NR_ORDENACAO", objGrid_Valor(grdGeral, cnt_GridGeral_Ordem, iCont)), _
                              DBParametro_Montar("CD_TIPO_MOVIMENTACAO", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo, iCont))) Then GoTo ERRO
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        Me.Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcuracao_Adicionar.Click
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

        AtualizaOrdem()
    End Sub

    Private Sub frmCadastroGrupoTipoMovimentacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_TipoMovimentacao.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_TipoMovimentacao
        Pesq_TipoMovimentacao.BancoDados_Filtro_Limpar()
        Pesq_TipoMovimentacao.BancoDados_Filtro_Adicionar("IC_ATIVO = 'S'")

        ControleEdicaoTelaLocal = ControleEdicaoTela
        CdGrupoTipoMovimentacao = Filtro

        objGrid_Inicializar(grdGeral, , oDS, CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdGeral, "Cód", 40)
        objGrid_Coluna_Add(grdGeral, "Tipo Movimentação", 200)
        objGrid_Coluna_Add(grdGeral, "Ord", 40)

        grdGeral.DisplayLayout.Bands(0).Override.AllowDelete = DefaultableBoolean.True
        If ControleEdicaoTelaLocal = eControleEdicaoTela.ALTERAR Then
            CarregarDados()
        End If
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * FROM SOF.PARAMETRO_MODALIDADE WHERE CD_PARAMETRO_MODALIDADE = " & CdGrupoTipoMovimentacao
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            lblCodigo.Text = oData.Rows(0).Item("CD_PARAMETRO_MODALIDADE")
            txtDescricao.Text = oData.Rows(0).Item("NO_PARAMETRO_MODALIDADE")

            '>> Grid 
            SqlText = "SELECT BITM.CD_TIPO_MOVIMENTACAO," & _
                             "TM.NO_TIPO_MOVIMENTACAO," & _
                             "BITM.NR_ORDENACAO" & _
                      " FROM SOF.TIPO_MOVIMENTACAO TM," & _
                            "SOF.PARAMETRO_MODALIDADE_TIPO_MOV BITM" & _
                      " WHERE BITM.CD_TIPO_MOVIMENTACAO = TM.CD_TIPO_MOVIMENTACAO" & _
                        " AND BITM.CD_PARAMETRO_MODALIDADE = " & CdGrupoTipoMovimentacao & _
                        " ORDER BY BITM.NR_ORDENACAO"
            objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, _
                                                               cnt_GridGeral_Nome, _
                                                               cnt_GridGeral_Ordem})
        End If
    End Sub

    Private Sub cmdSobe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSobe.Click
        Dim ValorAtual As Integer
        Dim icont As Integer

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Selecione um registro")
            Exit Sub
        End If
        If NVL(grdGeral.Rows(grdGeral.DisplayLayout.ActiveRow.Index).Cells(cnt_GridGeral_Ordem).Value, 0) = 1 Then
            Exit Sub
        End If
        ValorAtual = NVL(grdGeral.Rows(grdGeral.DisplayLayout.ActiveRow.Index).Cells(cnt_GridGeral_Ordem).Value, 0)

        For icont = 0 To grdGeral.Rows.Count - 1
            If NVL(grdGeral.Rows(icont).Cells(cnt_GridGeral_Ordem).Value, 0) = ValorAtual - 1 Then
                grdGeral.Rows(icont).Cells(cnt_GridGeral_Ordem).Value = ValorAtual
            End If
        Next

        grdGeral.Rows(grdGeral.DisplayLayout.ActiveRow.Index).Cells(cnt_GridGeral_Ordem).Value = ValorAtual - 1

        With grdGeral.DisplayLayout.Bands(0)
            .SortedColumns.Clear()
            .SortedColumns.Add(.Columns(cnt_GridGeral_Ordem), False)
        End With

        AtualizaOrdem()
    End Sub

    Private Sub AtualizaOrdem()
        Dim iCont As Integer

        'ajusta para não ter erro de sequncia
        For iCont = 0 To grdGeral.Rows.Count - 1
            grdGeral.Rows(iCont).Cells(cnt_GridGeral_Ordem).Value = iCont + 1
            grdGeral.Rows(iCont).Update()
        Next
    End Sub

    Private Sub cmdDesce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDesce.Click
        Dim ValorAtual As Integer
        Dim icont As Integer

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Selecione um registro")
            Exit Sub
        End If
        If NVL(grdGeral.Rows(grdGeral.DisplayLayout.ActiveRow.Index).Cells(cnt_GridGeral_Ordem).Value, 0) = grdGeral.Rows.Count Then
            Exit Sub
        End If
        ValorAtual = NVL(grdGeral.Rows(grdGeral.DisplayLayout.ActiveRow.Index).Cells(cnt_GridGeral_Ordem).Value, 0)

        For icont = 0 To grdGeral.Rows.Count - 1
            If NVL(grdGeral.Rows(icont).Cells(cnt_GridGeral_Ordem).Value, 0) = ValorAtual + 1 Then
                grdGeral.Rows(icont).Cells(cnt_GridGeral_Ordem).Value = ValorAtual
            End If
        Next

        grdGeral.Rows(grdGeral.DisplayLayout.ActiveRow.Index).Cells(cnt_GridGeral_Ordem).Value = ValorAtual + 1

        With grdGeral.DisplayLayout.Bands(0)
            .SortedColumns.Clear()
            .SortedColumns.Add(.Columns(cnt_GridGeral_Ordem), False)
        End With

        AtualizaOrdem()
    End Sub
End Class