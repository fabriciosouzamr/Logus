Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaConciliacao
    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_Fornecedor As Integer = 2
    Const cnt_GridGeral_Modalidade As Integer = 3
    Const cnt_GridGeral_Quantidade As Integer = 4
    Const cnt_GridGeral_Valor As Integer = 5
    Const cnt_GridGeral_Funrural As Integer = 6
    Const cnt_GridGeral_ICMS As Integer = 7
    Const cnt_GridGeral_Descrição As Integer = 8
    Const cnt_GridGeral_Filial As Integer = 9
    Const cnt_GridGeral_SqConfissaoDivida As Integer = 10

    Const cnt_SEC_Tela As String = "Transacao_Conciliacao"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmConsultaConciliacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_CodigoNome.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        ComboBox_Carregar_Modalidade_Conciliacao(cboModalidadeConciliacao, True)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True, , , , True)

        objGrid_Coluna_Add(grdGeral, "Código", 60)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 180)
        objGrid_Coluna_Add(grdGeral, "Modalidade", 160)
        objGrid_Coluna_Add(grdGeral, "Quantidade", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Valor", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Funrural", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "ICMS", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Descrição", 250)
        objGrid_Coluna_Add(grdGeral, "Filial", 120)
        objGrid_Coluna_Add(grdGeral, "Código Confissão de Divida", 0)

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdAlterar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "CONCILIACAO", "SQ_CONCILIACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        ControleEdicaoTela = eControleEdicaoTela.INCLUIR
        Form_Show(Me.MdiParent, frmCadastroConciliacao)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        If Not Data_ValidarPeriodo("da conciliação", txtDataInicial.Value, txtDataFinal.Value, False) Then Exit Sub

        SqlText = "SELECT C.SQ_CONCILIACAO, C.DT_CONCILIACAO, F.NO_RAZAO_SOCIAL, CM.NO_CONCILIACAO_MODALIDADE,  "
        SqlText = SqlText & "        C.QT_CONCILIACAO, C.VL_CONCILIACAO,fun.vl_fun, mcs.vl_saldo_icms, C.DS_CONCILIACAO, FIL.NO_FILIAL, c.sq_confissao_divida "
        SqlText = SqlText & "  FROM SOF.CONCILIACAO C, "
        SqlText = SqlText & "       SOF.CONCILIACAO_MODALIDADE CM, "
        SqlText = SqlText & "       SOF.FILIAL FIL, "
        SqlText = SqlText & " (SELECT   cm.sq_conciliacao,  round(SUM (m.vl_nf_funrural* cm.vl_aplicacao / DECODE (m.vl_nf, 0, 1, m.vl_nf) ),2) AS vl_fun"
        SqlText = SqlText & "              FROM sof.conciliacao_movimentacao cm, sof.movimentacao m"
        SqlText = SqlText & "              where cm.sq_movimentacao =m.sq_movimentacao "
        SqlText = SqlText & "        GROUP BY cm.sq_conciliacao) fun, "
        SqlText = SqlText & "       (SELECT  cm.sq_conciliacao, "
        SqlText = SqlText & "  SUM (ROUND (  (  (pa.vl_aplicacao * cm.vl_aplicacao) / DECODE (m.vl_nf, 0, 1, m.vl_nf)   ),     2   )      ) vl_saldo_icms "
        SqlText = SqlText & "     FROM (SELECT   sq_conciliacao, sq_movimentacao, SUM (vl_aplicacao) AS vl_aplicacao"
        SqlText = SqlText & "               FROM sof.conciliacao_movimentacao"
        SqlText = SqlText & "           GROUP BY sq_conciliacao,sq_movimentacao) cm,"
        SqlText = SqlText & "          (SELECT   SUM (vl_aplicacao) AS vl_aplicacao, sq_movimentacao"
        SqlText = SqlText & "                                 FROM sof.pag_amarracao_icms"
        SqlText = SqlText & "                             GROUP BY sq_movimentacao) pa,"
        SqlText = SqlText & "                     sof.movimentacao m"
        SqlText = SqlText & "    WHERE cm.sq_movimentacao = pa.sq_movimentacao"
        SqlText = SqlText & "    and m.sq_movimentacao = pa.sq_movimentacao"
        SqlText = SqlText & " GROUP BY cm.sq_conciliacao) mcs, "
        SqlText = SqlText & "       SOF.FORNECEDOR F "
        SqlText = SqlText & " WHERE C.CD_FILIAL_ORIGEM = FIL.CD_FILIAL "
        SqlText = SqlText & "   AND C.CD_CONCILIACAO_MODALIDADE = CM.CD_CONCILIACAO_MODALIDADE "
        SqlText = SqlText & "   and c.SQ_CONCILIACAO =mcs.SQ_CONCILIACAO (+) "
        SqlText = SqlText & "   and c.SQ_CONCILIACAO =fun.SQ_CONCILIACAO (+) "
        SqlText = SqlText & "   AND C.CD_FORNECEDOR = F.CD_FORNECEDOR "

        If ComboBox_LinhaSelecionada(cboModalidadeConciliacao) Then
            SqlText = SqlText & " AND c.cd_conciliacao_modalidade=" & cboModalidadeConciliacao.SelectedValue
        End If
        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC( c.dt_conciliacao ) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC( c.dt_conciliacao ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If
        If Pesq_CodigoNome.Codigo > 0 Then
            SqlText = SqlText & " AND c.cd_fornecedor=" & Pesq_CodigoNome.Codigo
        End If

        SqlText = SqlText & "ORDER BY C.SQ_CONCILIACAO DESC "

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, _
                                                           cnt_GridGeral_Data, _
                                                           cnt_GridGeral_Fornecedor, _
                                                           cnt_GridGeral_Modalidade, _
                                                           cnt_GridGeral_Quantidade, _
                                                           cnt_GridGeral_Valor, _
                                                           cnt_GridGeral_Funrural, _
                                                           cnt_GridGeral_ICMS, _
                                                           cnt_GridGeral_Descrição, _
                                                           cnt_GridGeral_Filial, _
                                                           cnt_GridGeral_SqConfissaoDivida})

        objGrid_ExibirTotal(grdGeral, New Integer() {cnt_GridGeral_Quantidade, cnt_GridGeral_Valor, cnt_GridGeral_Funrural, cnt_GridGeral_ICMS})
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        ControleEdicaoTela = eControleEdicaoTela.ALTERAR
        Filtro = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
        Form_Show(Me.MdiParent, frmCadastroConciliacao)
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim SqlText As String
        Dim bExistemItensAmarrados As Boolean = False

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If Not CampoNulo(objGrid_Valor(grdGeral, cnt_GridGeral_SqConfissaoDivida)) Then
            Msg_Mensagem("Essa conciliação pertence a uma recuperação de credito.")
            Exit Sub
        End If

        'Verifica se existe pagamentos ou movimentação associada a essa conciliação - Início
        SqlText = "SELECT COUNT(*) FROM SOF.CONCILIACAO_PAGAMENTO WHERE SQ_CONCILIACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
        bExistemItensAmarrados = (DBQuery_ValorUnico(SqlText) > 0)

        If Not bExistemItensAmarrados Then
            SqlText = "SELECT COUNT(*) FROM SOF.CONCILIACAO_MOVIMENTACAO WHERE SQ_CONCILIACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
            bExistemItensAmarrados = (DBQuery_ValorUnico(SqlText) > 0)
        End If

        If bExistemItensAmarrados Then
            If CDate(objGrid_Valor(grdGeral, cnt_GridGeral_Data)) < CDate(DataSistema()) Then
                Msg_Mensagem("Não é permitido excluir conciliação com data anterior a data atual.")
                Exit Sub
            End If
        End If
        'Verifica se existe pagamentos ou movimentação associada a essa conciliação - Fim

        If Msg_Perguntar("Deseja excluir a conciliação?") Then
            If Not DBExecutar_Delete("SOF.CONCILIACAO", "SQ_CONCILIACAO", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo ERRO
        End If

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub frmConsultaConciliacao_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdNovo.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdAlterar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub
End Class