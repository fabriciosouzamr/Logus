Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Logus.eDbType

Public Class frmConsultaFretePagamento
    Const cnt_GridGeral_Data As Integer = 0
    Const cnt_GridGeral_Fretista As Integer = 1
    Const cnt_GridGeral_ValorPago As Integer = 2
    Const cnt_GridGeral_ValorBruto As Integer = 3
    Const cnt_GridGeral_ValorImpostos As Integer = 4
    Const cnt_GridGeral_Volumes As Integer = 5
    Const cnt_GridGeral_PrecoMedio As Integer = 6
    Const cnt_GridGeral_FilialOrigem As Integer = 7
    Const cnt_GridGeral_FilialPagadora As Integer = 8
    Const cnt_GridGeral_FormaPagamento As Integer = 9
    Const cnt_GridGeral_Favorecido As Integer = 10
    Const cnt_GridGeral_Codigo As Integer = 11

    Const cnt_GridProvisao_Nome As Integer = 0
    Const cnt_GridProvisao_Valor As Integer = 1

    Const cnt_GridFrete_Data As Integer = 0
    Const cnt_GridFrete_Fretista As Integer = 1
    Const cnt_GridFrete_ValorUnitario As Integer = 2
    Const cnt_GridFrete_Volume As Integer = 3
    Const cnt_GridFrete_Total As Integer = 4
    Const cnt_GridFrete_TipoFrete As Integer = 5
    Const cnt_GridFrete_Filial As Integer = 6
    Const cnt_GridFrete_Fornecedor As Integer = 7
    Const cnt_GridFrete_NF As Integer = 8
    Const cnt_GridFrete_PagoManual As Integer = 9
    Const cnt_GridFrete_Codigo As Integer = 10

    Const cnt_SEC_Tela As String = "Transacao_Frete_GerarPagamento"

    Dim oDS As New DataSet
    Dim oDSProvisao As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub frmConsultaFretePagamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PesquisaFretista_Formatar()

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , _
                                             DefaultableBoolean.False, True, _
                                             UltraWinGrid.ViewStyleBand.Vertical, , , True)

        objGrid_Coluna_Add(grdGeral, "Data", 70, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "Fretista", 170)
        objGrid_Coluna_Add(grdGeral, "Valor Pago", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor Bruto", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor Impostos", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Volumes", 100)
        objGrid_Coluna_Add(grdGeral, "Preço Medio", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Filial Origem", 120)
        objGrid_Coluna_Add(grdGeral, "Filial Pagadora", 120)
        objGrid_Coluna_Add(grdGeral, "Forma Pagamento", 100)
        objGrid_Coluna_Add(grdGeral, "Favorecido", 160)
        objGrid_Coluna_Add(grdGeral, "Código", 0, , , , , cnt_Formato_NumeroInteiro)

        objGrid_Inicializar(grdProvisao, , oDSProvisao, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdProvisao, "Imposto", 160)
        objGrid_Coluna_Add(grdProvisao, "Valor", 100, , , , , cnt_Formato_Valor)

        'Montagem do DataSet - Início
        DBData_Criar(oDS, "Item", New String() {"Data", "Fretista", "Valor Unitario", "Volumes", "Total", "Tipo Frete", "Filial", _
                                                "Fornecedor", "NF", "Pago Manual", "SQ_FRETE_PAGAMENTO"}, _
                                                New eDbType() {_Data, _Texto, _Numero, _Decimal, _Numero, _Texto, _Texto, _
                                                                _Texto, _Texto, _Texto, _Decimal})
        'Montagem do DataSet - Fim
        DBData_Relationamento_Criar(oDS, "FK_Item", oDS.Tables(0), New String() {oDS.Tables(0).Columns(cnt_GridGeral_Codigo).ColumnName}, _
                                                    oDS.Tables(1), New String() {"SQ_FRETE_PAGAMENTO"})

        objGrid_Band_Formatar(grdGeral.DisplayLayout.Bands(1), UltraWinGrid.CellClickAction.RowSelect)

        With grdGeral.DisplayLayout.Bands(1)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridFrete_Data), "", 80, , , , cnt_Formato_Data)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridFrete_Fretista), "", 170)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridFrete_ValorUnitario), "", 80, , , , cnt_Formato_Valor)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridFrete_Volume), "", 80)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridFrete_Total), "", 80, , , , cnt_Formato_Valor)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridFrete_TipoFrete), "", 120)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridFrete_Filial), "", 120)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridFrete_Fornecedor), "", 180)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridFrete_NF), "", 70)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridFrete_PagoManual), "", 80)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridFrete_Codigo), "", 0)
        End With

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub PesquisaFretista_Formatar()
        With Pesq_Fretista
            .Codigo = 0
            .BancoDados_Tabela = "FRETISTA"
            .BancoDados_Campo_Codigo = "CD_FRETISTA"
            .BancoDados_Campo_Descricao = "NO_FRETISTA"
        End With
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT   fp.dt_frete_pagamento, f.no_fretista, fp.vl_frete_pagamento, "
        SqlText = SqlText & "         fp.vl_bruto, fp.vl_total_impostos, SUM (fre.qt_volume) AS qt_sacos, "
        SqlText = SqlText & "         round(fp.vl_bruto / SUM (fre.qt_volume),2) AS vl_preco_medio, "
        SqlText = SqlText & "         filo.no_filial no_filial_origem, filp.no_filial no_filial_pagadora, "
        SqlText = SqlText & "         decode(fp.ic_forma_pagamento,0,'Cheque','JDE') ic_forma_pagamento, fp.no_favorecido, fp.sq_frete_pagamento "
        SqlText = SqlText & "    FROM sof.frete_pagamento fp, "
        SqlText = SqlText & "         sof.filial filo, "
        SqlText = SqlText & "         sof.fretista f, "
        SqlText = SqlText & "         sof.filial filp, "
        SqlText = SqlText & "         sof.frete fre "
        SqlText = SqlText & "   WHERE fp.cd_fretista = f.cd_fretista "
        SqlText = SqlText & "     AND fp.cd_filial_origem = filo.cd_filial "
        SqlText = SqlText & "     AND fp.cd_filial_pagamento = filp.cd_filial "
        SqlText = SqlText & "     AND fp.sq_frete_pagamento = fre.sq_frete_pagamento(+) "

        If Pesq_Fretista.Codigo > 0 Then
            SqlText = SqlText & " AND fp.cd_fretista=" & Pesq_Fretista.Codigo
        End If
        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(FP.DT_FRETE_PAGAMENTO) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(FP.DT_FRETE_PAGAMENTO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        SqlText = SqlText & " GROUP BY fp.dt_frete_pagamento, "
        SqlText = SqlText & "          f.no_fretista, "
        SqlText = SqlText & "          fp.vl_frete_pagamento, "
        SqlText = SqlText & "          fp.vl_bruto, "
        SqlText = SqlText & "          fp.vl_total_impostos, "
        SqlText = SqlText & "          filo.no_filial, "
        SqlText = SqlText & "          filp.no_filial, "
        SqlText = SqlText & "          decode(fp.ic_forma_pagamento,0,'Cheque','JDE'), "
        SqlText = SqlText & "          fp.no_favorecido, "
        SqlText = SqlText & "          fp.sq_frete_pagamento "

        DBQuery_Append(oDS.Tables(0), SqlText, True)

    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "FRETE_PAGAMENTO", "SQ_FRETE_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub grdGeral_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGeral.AfterRowActivate
        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Exit Sub
        End If

        SqlText = "SELECT TFT.NO_TIPO_FRETISTA_TRIBUTACAO, FPT.VL_TRIBUTO " & _
                    "FROM SOF.TIPO_FRETISTA_TRIBUTACAO TFT, SOF.FRETE_PAGAMENTO_TRIBUTO FPT " & _
                    "WHERE FPT.CD_TIPO_FRETISTA_TRIBUTACAO = TFT.CD_TIPO_FRETISTA_TRIBUTACAO AND " & _
                    "FPT.SQ_FRETE_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

        objGrid_Carregar(grdProvisao, SqlText, New Integer() {cnt_GridProvisao_Nome, _
                                                            cnt_GridProvisao_Valor}, False)


    End Sub

    Private Sub grdGeral_AfterRowExpanded(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdGeral.AfterRowExpanded
        ExecutaConsulta_Frete(e.Row.Cells(cnt_GridGeral_Codigo).Value)
    End Sub

    Private Sub ExecutaConsulta_Frete(ByVal SQ_FRETE_PAGAMENTO As Integer)
        Dim SqlText As String

        SqlText = "SELECT f.dt_frete, frt.no_fretista, f.vl_unitario, f.qt_volume, f.vl_total, "
        SqlText = SqlText & "       tf.no_tipo_frete, fil.no_filial, forn.no_razao_social, m.nu_nf, "
        SqlText = SqlText & "       NVL (f.ic_pago_manual, 'N') ic_pago_manual, f.sq_frete_pagamento "
        SqlText = SqlText & "  FROM sof.fornecedor forn, "
        SqlText = SqlText & "       sof.tipo_frete tf, "
        SqlText = SqlText & "       sof.filial fil, "
        SqlText = SqlText & "       sof.movimentacao m, "
        SqlText = SqlText & "       sof.fretista frt, "
        SqlText = SqlText & "       sof.frete f "
        SqlText = SqlText & " WHERE f.cd_fretista = frt.cd_fretista "
        SqlText = SqlText & "   AND f.cd_tipo_frete = tf.cd_tipo_frete "
        SqlText = SqlText & "   AND f.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "   AND f.sq_movimentacao = m.sq_movimentacao(+) "
        SqlText = SqlText & "   AND m.cd_fornecedor = forn.cd_fornecedor(+) "
        SqlText = SqlText & "   AND f.sq_frete_pagamento= " & SQ_FRETE_PAGAMENTO


        DBQuery_Append(oDS.Tables(1), SqlText)
    End Sub

    Private Sub frmConsultaFretePagamento_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 103
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 6
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 315
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 365
        grdProvisao.Left = Me.ClientSize.Width - grdProvisao.Width - 6
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdNovo.Top = Me.ClientSize.Height - cmdNovo.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        grdProvisao.Top = Me.ClientSize.Height - grdProvisao.Height - 6
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim SqlText As String
        Dim CdFretista As Integer

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ExcluirFreteLancadoDataAnteriorAtual) Then
            If Not Msg_Perguntar("Você está tentando excluir um frete de um dia anterior ao atual que pode já ter sido contabilizado. Deseja continuar?") Then Exit Sub
        Else
            If CDate(objGrid_Valor(grdGeral, cnt_GridGeral_Data)) <> CDate(DataSistema()) Then
                Msg_Mensagem("Esta movimentação não é de hoje.")
                Exit Sub
            End If
        End If

        CdFretista = DBQuery_ValorUnico("SELECT CD_FRETISTA FROM SOF.FRETE_PAGAMENTO WHERE SQ_FRETE_PAGAMENTO =" & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))

        SqlText = "SELECT COUNT(*) " & _
                  " FROM SOF.FRETE_PAGAMENTO " & _
                  " WHERE CD_FRETISTA = " & CdFretista & _
                    " AND SQ_FRETE_PAGAMENTO > " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

        If DBQuery_ValorUnico(SqlText) > 0 Then
            Msg_Mensagem("Houve pagamento de frete a esse fretista posterior a esse.Para excluir esse lançamento você precisa primeiramente excluir os porteriores.")
            Exit Sub
        End If

        If Msg_Perguntar("Elimina o pagamento ?") = False Then Exit Sub


        SqlText = DBMontar_SP("SOF.SP_ELIMINA_FRETE_PAGAMENTO", False, ":SEQ")

        If Not DBExecutar(SqlText, DBParametro_Montar("SEQ", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))) Then GoTo Erro

        ExecutaConsulta()

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Form_Show(Me.MdiParent, frmGeraFretePagamento)
    End Sub
End Class