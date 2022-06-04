Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaRecuperacaoCredito
    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_Status As Integer = 1
    Const cnt_GridGeral_Modalidade As Integer = 2
    Const cnt_GridGeral_Data As Integer = 3
    Const cnt_GridGeral_DataFechamento As Integer = 4
    Const cnt_GridGeral_Fornecedor As Integer = 5
    Const cnt_GridGeral_ValorNegociado As Integer = 6
    Const cnt_GridGeral_ValorPago As Integer = 7
    Const cnt_GridGeral_Saldo As Integer = 8
    Const cnt_GridGeral_Valor_Original As Integer = 9
    Const cnt_GridGeral_Quantidade_Original As Integer = 10
    Const cnt_GridGeral_Filial As Integer = 11
    Const cnt_GridGeral_Fornecedor_Contrato As Integer = 12
    Const cnt_GridGeral_DataInicioJuros As Integer = 13
    Const cnt_GridGeral_CodFilial As Integer = 14

    Const cnt_SEC_Tela As String = "Transacao_RecuperacaoCredito"
    Const cnt_SEC_Tela_Controle As String = "Transacao_ControleRecuperacaoCredito"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Form_Show(Me.MdiParent, frmCadastroRecuperacaoCredito)
    End Sub

    Private Sub cmdControle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdControle.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        Filtro = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
        Form_Show(Me.MdiParent, frmControleRecuperacaoCredito)
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        If Msg_Perguntar("Elimina o registro ?") = False Then Exit Sub

        If FilialFechada(objGrid_Valor(grdGeral, cnt_GridGeral_CodFilial)) Then
            Msg_Mensagem("A Filial está fechada. No momento não é possivel realizar a exclusão.")
            Exit Sub
        End If

        If objGrid_Valor(grdGeral, cnt_GridGeral_Data) <> DataSistema() Then
            Msg_Mensagem("Data da contabilização ja fehcada.")
            Exit Sub
        End If

        SqlText = "select count(*) qt from sof.confissao_divida_ativo " & _
                  "where sq_confissao_divida = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Essa recuperação de credito ja possui ativos.")
            Exit Sub
        End If

        SqlText = DBMontar_SP("SOF.SP_ELIMINA_CONF_DIV", False, ":SQCONFDIV")
        If Not DBExecutar(SqlText, DBParametro_Montar("SQCONFDIV", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))) Then GoTo Erro

        ExecutaConsulta()

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub frmConsultaRecuperacaoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_CodigoNome.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True, , , , True)

        objGrid_Coluna_Add(grdGeral, "Código", 0)
        objGrid_Coluna_Add(grdGeral, "Status", 80)
        objGrid_Coluna_Add(grdGeral, "Modalidade", 140)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Fechamento", 80)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 180)
        objGrid_Coluna_Add(grdGeral, "Valor Negociado", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor Pago", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Saldo", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor Original", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Quantidade Original", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Filial", 120)
        objGrid_Coluna_Add(grdGeral, "Fornecedor Contrato", 180)
        objGrid_Coluna_Add(grdGeral, "Inicio Juros", 80)
        objGrid_Coluna_Add(grdGeral, "Código Filial", 0)

        objGrid_ExibirTotal(grdGeral, New Integer() {cnt_GridGeral_ValorNegociado, _
                                                     cnt_GridGeral_ValorPago, _
                                                     cnt_GridGeral_Saldo, _
                                                     cnt_GridGeral_Valor_Original, _
                                                     cnt_GridGeral_Quantidade_Original})

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao(cmdControle, cnt_SEC_Tela_Controle, SEC_Validador.SEC_V_QualquerAcesso, True)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        If Not Data_ValidarPeriodo("data de confissão", txtDataInicial.Text, txtDataFinal.Text, False) Then Exit Sub

        SqlText = "SELECT   cd.sq_confissao_divida, decode(cd.ic_status,'A','Em Aberto','F','Fechada','C','Cancelada','') as ic_status, "
        SqlText = SqlText & "         cdm.no_confissao_divida_modalidade, cd.dt_confissao_divida, "
        SqlText = SqlText & "         cd.dt_fechamento, f.no_razao_social, cd.vl_negociado, "
        SqlText = SqlText & "         SUM (DECODE (cdp.ic_situacao, 'P', cda.vl_ativo, 0)) AS vl_pago, "
        SqlText = SqlText & "         SUM (DECODE (cdp.ic_situacao, 'A', cdp.vl_parcela, 0)) AS vl_saldo, "
        SqlText = SqlText & "         cd.vl_original, cd.qt_original, fil.no_filial, "
        SqlText = SqlText & "         fc.no_razao_social no_fornecedor_contrato, cd.dt_cobra_juros, "
        SqlText = SqlText & "         f.cd_filial_origem "
        SqlText = SqlText & "    FROM sof.confissao_divida_parcela cdp, "
        SqlText = SqlText & "         sof.confissao_divida cd, "
        SqlText = SqlText & "         sof.filial fil, "
        SqlText = SqlText & "         sof.fornecedor f, "
        SqlText = SqlText & "         sof.fornecedor fc, "
        SqlText = SqlText & "         sof.confissao_divida_ativo cda, "
        SqlText = SqlText & "         sof.confissao_divida_modalidade cdm "
        SqlText = SqlText & "   WHERE cd.sq_confissao_divida = cdp.sq_confissao_divida(+) "
        SqlText = SqlText & "     AND cd.cd_confissao_divida_modalidade =cdm.cd_confissao_divida_modalidade "
        SqlText = SqlText & "     AND fil.cd_filial = f.cd_filial_origem "
        SqlText = SqlText & "     AND f.cd_fornecedor = cd.cd_fornecedor "
        SqlText = SqlText & "     AND fc.cd_fornecedor = cd.cd_fornecedor_contrato "
        SqlText = SqlText & "     AND cdp.sq_confissao_divida = cda.sq_confissao_divida(+) "
        SqlText = SqlText & "     AND cdp.nu_parcela = cda.nu_parcela(+) "

        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC( cd.dt_confissao_divida ) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If

        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC( cd.dt_confissao_divida ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        If Pesq_CodigoNome.Codigo > 0 Then
            SqlText = SqlText & " AND cd.cd_fornecedor=" & Pesq_CodigoNome.Codigo
        End If

        SqlText = SqlText & "GROUP BY cd.sq_confissao_divida, "
        SqlText = SqlText & "         cd.ic_status, "
        SqlText = SqlText & "         cdm.no_confissao_divida_modalidade, "
        SqlText = SqlText & "         cd.dt_confissao_divida, "
        SqlText = SqlText & "         cd.dt_fechamento, "
        SqlText = SqlText & "         f.no_razao_social, "
        SqlText = SqlText & "         cd.vl_negociado, "
        SqlText = SqlText & "         cd.vl_original, "
        SqlText = SqlText & "         cd.qt_original, "
        SqlText = SqlText & "         fil.no_filial, "
        SqlText = SqlText & "         fc.no_razao_social, "
        SqlText = SqlText & "         cd.dt_cobra_juros, "
        SqlText = SqlText & "         f.cd_filial_origem "

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, _
                                                            cnt_GridGeral_Status, _
                                                            cnt_GridGeral_Modalidade, _
                                                            cnt_GridGeral_Data, _
                                                            cnt_GridGeral_DataFechamento, _
                                                            cnt_GridGeral_Fornecedor, _
                                                            cnt_GridGeral_ValorNegociado, _
                                                            cnt_GridGeral_ValorPago, _
                                                            cnt_GridGeral_Saldo, _
                                                            cnt_GridGeral_Valor_Original, _
                                                            cnt_GridGeral_Quantidade_Original, _
                                                            cnt_GridGeral_Filial, _
                                                            cnt_GridGeral_Fornecedor_Contrato, _
                                                            cnt_GridGeral_DataInicioJuros, _
                                                            cnt_GridGeral_CodFilial})

    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub frmConsultaRecuperacaoCredito_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
        cmdControle.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "CONFISSAO_DIVIDA", "SQ_CONFISSAO_DIVIDA = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub
End Class