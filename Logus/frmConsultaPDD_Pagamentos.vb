Imports Infragistics.Win

Public Class frmConsultaPDD_Pagamentos
    Event ExclusaoEfetuada()

    Const cnt_GridGeral_Tipo As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_Valor As Integer = 2
    Const cnt_GridGeral_Descricao As Integer = 3
    Const cnt_GridGeral_Codigo As Integer = 4

    Public SQ_PDD As Integer

    Dim WithEvents oFormCadastroPDD_Pagamentos As frmCadastroPDD_Pagamentos
    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "PDD_PAGAMENTO", "SQ_PDD_PAGAMENTO=" & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        oFormCadastroPDD_Pagamentos = New frmCadastroPDD_Pagamentos
        oFormCadastroPDD_Pagamentos.SQ_PDD = SQ_PDD
        oFormCadastroPDD_Pagamentos.SQ_PDD_PAGAMENTO = 0

        Form_Show(Me.MdiParent, oFormCadastroPDD_Pagamentos)
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        oFormCadastroPDD_Pagamentos = New frmCadastroPDD_Pagamentos
        oFormCadastroPDD_Pagamentos.SQ_PDD = SQ_PDD
        oFormCadastroPDD_Pagamentos.SQ_PDD_PAGAMENTO = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

        Form_Show(Me.MdiParent, oFormCadastroPDD_Pagamentos)
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If Msg_Perguntar("Deseja realmente excluir esse lançamento pagamento do PDD?") Then
            If Not DBExecutar_Delete("SOF.PDD_PAGAMENTO", "SQ_PDD_PAGAMENTO", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro

            Pesquisa()

            RaiseEvent ExclusaoEfetuada()

            Msg_Mensagem("Pagamento excluído com sucesso")
        End If

        Exit Sub

Erro:
        TratarErro(, , "frmConsultaPDD.cmdExcluir_Click")
    End Sub

    Private Sub Pesquisa()
        Dim SqlText As String

        SqlText = "SELECT decode(IC_TIPO_LANCAMENTO,'P','Pagamento','B','Baixa','T','Tranferência Provisão')," & _
                         "DT_PAGAMENTO," & _
                         "VL_PAGO," & _
                         "DS_PAGAMENTO, SQ_PDD_PAGAMENTO " & _
                  " FROM SOF.PDD_PAGAMENTO" & _
                  " WHERE SQ_PDD = " & SQ_PDD & _
                  " ORDER BY DT_PAGAMENTO"
        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Tipo, _
                                                           cnt_GridGeral_Data, _
                                                           cnt_GridGeral_Valor, _
                                                           cnt_GridGeral_Descricao, cnt_GridGeral_Codigo})
    End Sub

    Private Sub frmConsultaPDD_Pagamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, , , , , True)

        objGrid_Coluna_Add(grdGeral, "Tipo", 120)
        objGrid_Coluna_Add(grdGeral, "Data", 80, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "Valor", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Descrição do Pagamento", 350)
        objGrid_Coluna_Add(grdGeral, "Código", 0)

        Pesquisa()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "PDD", "SQ_PDD=" & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub oFormCadastroPDD_Pagamentos_GravacaoEfetuada() Handles oFormCadastroPDD_Pagamentos.GravacaoEfetuada
        Pesquisa()
    End Sub
End Class