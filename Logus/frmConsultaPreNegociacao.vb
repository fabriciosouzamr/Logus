Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaPreNegociacao
    Const cnt_GridGeral_Data As Integer = 0
    Const cnt_GridGeral_Fornecedor As Integer = 1
    Const cnt_GridGeral_Quantidade As Integer = 2
    Const cnt_GridGeral_Saldo As Integer = 3
    Const cnt_GridGeral_TipoNegociacao As Integer = 4
    Const cnt_GridGeral_Unidade As Integer = 5
    Const cnt_GridGeral_Valor As Integer = 6
    Const cnt_GridGeral_DataVencimento As Integer = 7
    Const cnt_GridGeral_DataPagamento As Integer = 8
    Const cnt_GridGeral_LocalEntrega As Integer = 9
    Const cnt_GridGeral_ValorFrete As Integer = 10
    Const cnt_GridGeral_FilialOrigem As Integer = 11
    Const cnt_GridGeral_CotacaoDolar As Integer = 12
    Const cnt_GridGeral_CotacaoDolarAlternativa As Integer = 13
    Const cnt_GridGeral_CotacaoBolsa As Integer = 14
    Const cnt_GridGeral_CotacaoBolsaAlternativa As Integer = 15
    Const cnt_GridGeral_Diferencial As Integer = 16
    Const cnt_GridGeral_TipoCacau As Integer = 17
    Const cnt_GridGeral_FilialEntrega As Integer = 18
    Const cnt_GridGeral_Numero As Integer = 19

    Const cnt_SEC_Tela As String = "Transacao_Contratos_PreNegociacao"
    Const cnt_SEC_Tela_Negociacao As String = "Transacao_Contratos_Negociacao"

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim WithEvents FormNegociacao As New frmCadastroNegociacao

    Private Sub frmConsultaPreNegociacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, , , , , True)

        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 160)
        objGrid_Coluna_Add(grdGeral, "Quantidade", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Saldo", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Tipo Negociação", 120)
        objGrid_Coluna_Add(grdGeral, "Unidade", 80)
        objGrid_Coluna_Add(grdGeral, "Valor", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Data Vencimento", 120)
        objGrid_Coluna_Add(grdGeral, "Data Pagamento", 120)
        objGrid_Coluna_Add(grdGeral, "Local Entrega", 100)
        objGrid_Coluna_Add(grdGeral, "Valor Frete", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Filial Origem", 140)
        objGrid_Coluna_Add(grdGeral, "Dolar", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdGeral, "Dolar Alternativo", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdGeral, "Bolsa", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdGeral, "Bolsa Alternativo", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdGeral, "Diferencial", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdGeral, "Tipo Cacau", 100)
        objGrid_Coluna_Add(grdGeral, "Filial Entrega", 140)
        objGrid_Coluna_Add(grdGeral, "Número", 70)

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao(cmdTransformaNegociacao, cnt_SEC_Tela_Negociacao, SEC_Validador.SEC_V_Inclusao, True)

        ExecutaConsulta()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Form_Show(Me.MdiParent, frmCadastroPreNegociacao)
    End Sub

    Private Sub cmdTransformaNegociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransformaNegociacao.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If DBQuery_ValorUnico("select qt_saldo from sof.negociacao_pre  where sq_negociacao_pre =" & objGrid_Valor(grdGeral, cnt_GridGeral_Numero)) <= 0 Then
            Msg_Mensagem("Pre negociação já utilizada.")
            ExecutaConsulta()
            Exit Sub
        End If
        FormNegociacao = New frmCadastroNegociacao
        ControleEdicaoTela = eControleEdicaoTela.PRE_NEGOCIACAO
        Filtro = objGrid_Valor(grdGeral, cnt_GridGeral_Numero)
        Form_Show(Me.MdiParent, FormNegociacao)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT NP.DT_NEGOCIACAO, NP.DS_FORNECEDOR, NP.QT_KGS, NP.QT_SALDO, "
        SqlText = SqlText & "       TN.NO_TIPO_NEGOCIACAO, TU.NO_TIPO_UNIDADE, NP.VL_NEGOCIACAO, "
        SqlText = SqlText & "       NP.DT_VENCIMENTO, NP.DT_PAGAMENTO, LE.NO_LOCAL_ENTREGA, "
        SqlText = SqlText & "       NP.VL_PRECO_FRETE, FIL.NO_FILIAL , NP.VL_TAXA_DOLAR, "
        SqlText = SqlText & "       NP.VL_TAXA_DOLAR_ALTERNATIVO, NP.VL_BOLSA, NP.VL_BOLSA_ALTERNATIVO, "
        SqlText = SqlText & "       NP.VL_DIFERENCIAL, TC.NO_TIPO_CACAU, FE.NO_FILIAL NO_FILIAL_ENTREGA, "
        SqlText = SqlText & "       NP.SQ_NEGOCIACAO_PRE "
        SqlText = SqlText & "  FROM SOF.NEGOCIACAO_PRE NP, "
        SqlText = SqlText & "       SOF.TIPO_NEGOCIACAO TN, "
        SqlText = SqlText & "       SOF.TIPO_UNIDADE TU, "
        SqlText = SqlText & "       SOF.LOCAL_ENTREGA LE, "
        SqlText = SqlText & "       SOF.FILIAL FIL, "
        SqlText = SqlText & "       SOF.FILIAL FE, "
        SqlText = SqlText & "       SOF.TIPO_CACAU TC "
        SqlText = SqlText & " WHERE TN.CD_TIPO_NEGOCIACAO = NP.CD_TIPO_NEGOCIACAO "
        SqlText = SqlText & "   AND TU.CD_TIPO_UNIDADE = NP.CD_TIPO_UNIDADE "
        SqlText = SqlText & "   AND LE.CD_LOCAL_ENTREGA = NP.CD_LOCAL_ENTREGA "
        SqlText = SqlText & "   AND FIL.CD_FILIAL = NP.CD_FILIAL_ORIGEM "
        SqlText = SqlText & "   AND FE.CD_FILIAL(+) = NP.CD_FILIAL_ENTREGA "
        SqlText = SqlText & "   AND TC.CD_TIPO_CACAU(+) = NP.CD_TIPO_CACAU "

        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND NP.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            SqlText = SqlText & " AND NP.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        If Trim(txtFornecedor.Text) <> "" Then
            SqlText = SqlText & " AND UPPER(NP.DS_fornecedor) LIKE '%" & UCase(txtFornecedor.Text) & "%'"
        End If

        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(NP.dt_NEGOCIACAO) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If

        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(NP.dt_NEGOCIACAO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        Select Case optFiltro.Value
            Case "A"
                SqlText = SqlText & " and NP.qt_saldo>0"
            Case "F"
                SqlText = SqlText & " and NP.qt_saldo=0"
        End Select

        SqlText = SqlText & "ORDER by NP.SQ_NEGOCIACAO_PRE DESC "

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Data, _
                                                            cnt_GridGeral_Fornecedor, _
                                                            cnt_GridGeral_Quantidade, _
                                                            cnt_GridGeral_Saldo, _
                                                            cnt_GridGeral_TipoNegociacao, _
                                                            cnt_GridGeral_Unidade, _
                                                            cnt_GridGeral_Valor, _
                                                            cnt_GridGeral_DataVencimento, _
                                                            cnt_GridGeral_DataPagamento, _
                                                            cnt_GridGeral_LocalEntrega, _
                                                            cnt_GridGeral_ValorFrete, _
                                                            cnt_GridGeral_FilialOrigem, _
                                                            cnt_GridGeral_CotacaoDolar, _
                                                            cnt_GridGeral_CotacaoDolarAlternativa, _
                                                            cnt_GridGeral_CotacaoBolsa, _
                                                            cnt_GridGeral_CotacaoBolsaAlternativa, _
                                                            cnt_GridGeral_Diferencial, _
                                                            cnt_GridGeral_TipoCacau, _
                                                            cnt_GridGeral_FilialEntrega, _
                                                            cnt_GridGeral_Numero})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "NEGOCIACAO_PRE", "SQ_NEGOCIACAO_PRE = " & objGrid_Valor(grdGeral, cnt_GridGeral_Numero))

    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT count(*) " & _
              "FROM SOF.filial f, sof.NEGOCIACAO_PRE n  " & _
              "WHERE f.cd_filial=n.cd_filial_origem and SQ_NEGOCIACAO_PRE=" & objGrid_Valor(grdGeral, cnt_GridGeral_Numero) & " and f.cd_filial in (" & ListarIDFiliaisLiberadaUsuario() & ")"

        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Usuário não tem permissão para excluir essa pré-negociação.")
            Exit Sub
        End If

        If objGrid_Valor(grdGeral, cnt_GridGeral_Saldo) <> objGrid_Valor(grdGeral, cnt_GridGeral_Quantidade) Then
            Msg_Mensagem("Ja existe negociações geradas")
            Exit Sub
        End If
        If objGrid_Valor(grdGeral, cnt_GridGeral_Data) <> DataSistema() Then
            Msg_Mensagem("Impossivel eliminar." & vbCrLf & "Contrato feito em outro dia.")
            Exit Sub
        End If

        If Msg_Perguntar("Elimina a Pre-Negociação ?") = False Then Exit Sub

        DBUsarTransacao = True

        SqlText = "select qt_saldo, qt_kgs from sof.negociacao_pre " & _
                  "where sq_negociacao_pre = " & objGrid_Valor(grdGeral, cnt_GridGeral_Numero) & " for update"

        odata = DBQuery(SqlText)

        If oData.Rows.Count = 0 Then
            Msg_Mensagem("Pre negociação inexistente.")
            GoTo Erro
            Exit Sub
        End If

        If objGrid_Valor(grdGeral, cnt_GridGeral_Saldo) <> objGrid_Valor(grdGeral, cnt_GridGeral_Quantidade) Then
            Msg_Mensagem("Ja existe negociação gerada (u)")
            GoTo Erro
            Exit Sub
        End If

        SqlText = "update sof.negociacao set sq_negociacao_pre=null " & _
                  "where sq_negociacao_pre = " & objGrid_Valor(grdGeral, cnt_GridGeral_Numero)

        If Not DBExecutar(SqlText) Then GoTo erro

        SqlText = "delete from sof.negociacao_pre where sq_negociacao_pre=" & objGrid_Valor(grdGeral, cnt_GridGeral_Numero)

        If Not DBExecutar(SqlText) Then GoTo erro

        If Not DBExecutarTransacao() Then GoTo Erro

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub frmConsultaPreNegociacao_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
        cmdTransformaNegociacao.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub

    Private Sub FormNegociacao_EfetuouGravacao() Handles FormNegociacao.EfetuouGravacao
        ExecutaConsulta()
    End Sub
End Class