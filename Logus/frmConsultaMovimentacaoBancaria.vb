Imports Infragistics.Win

Public Class frmConsultaMovimentacaoBancaria
    Const cnt_GridGeral_Data As Integer = 0
    Const cnt_GridGeral_Numero As Integer = 1
    Const cnt_GridGeral_DC As Integer = 2
    Const cnt_GridGeral_Valor As Integer = 3
    Const cnt_GridGeral_Favorecido As Integer = 4
    Const cnt_GridGeral_Banco As Integer = 5
    Const cnt_GridGeral_Lancamento As Integer = 6
    Const cnt_GridGeral_Filial As Integer = 7
    Const cnt_GridGeral_VL_BRUTO_REAL As Integer = 8
    Const cnt_GridGeral_VL_CREDITO As Integer = 9
    Const cnt_GridGeral_VL_DEBITO As Integer = 10
    Const cnt_GridGeral_IC_EXCLUIDO As Integer = 11

    Const cnt_SEC_Tela As String = "Transacao_MovimentacaoBancaria"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "MOV_BANCARIO", "SQ_MOV_BANCARIO= " & objGrid_Valor(grdGeral, cnt_GridGeral_Lancamento))
    End Sub

    Private Sub frmConsultaMovimentacaoBancaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Conta_Bancaria(cboBanco, True)
        ComboBox_Carregar_CreditoDebito(cboCreditoDebito, True)
        objUltraComboBox_Inicializar(cboFilial)
        objUltraComboBox_Carregar_Filial(cboFilial, True)

        objGrid_Inicializar(grdGeral, , oDS, Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Coluna_Add(grdGeral, "Data", 100)
        objGrid_Coluna_Add(grdGeral, "Número Chq", 100)
        objGrid_Coluna_Add(grdGeral, "D/C", 30)
        objGrid_Coluna_Add(grdGeral, "Valor", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Favorecido", 150)
        objGrid_Coluna_Add(grdGeral, "Banco", 150)
        objGrid_Coluna_Add(grdGeral, "Lançamento", 100)
        objGrid_Coluna_Add(grdGeral, "Filial", 150)
        objGrid_Coluna_Add(grdGeral, "VL_BRUTO_REAL", 0)
        objGrid_Coluna_Add(grdGeral, "VL_CREDITO", 0)
        objGrid_Coluna_Add(grdGeral, "VL_DEBITO", 0)
        objGrid_Coluna_Add(grdGeral, "IC_EXCLUIDO", 0)

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao_Permissao(cmdCheque, SEC_Permissao.SEC_P_Acesso_ImprimirCheque, True)
        SEC_ValidarBotao_Permissao(cmdVoucher, SEC_Permissao.SEC_P_Acesso_ImprimirVoucherPagamento, True)
        'Solicitação de Supervisão de Filial para desabilitar esse recusro 03/09/2009
        cmdCheque.Visible = False
    End Sub

    Private Sub Pesquisar()
        Dim SqlText As String
        Dim oData As DataTable = Nothing
        Dim VL_SALDO_ANTERIOR As Double

        If Not IsDate(txtDataInicial.Value) Then
            Msg_Mensagem("Favor informe a data inicial.")
            txtDataInicial.Focus()
            Exit Sub
        End If
        If Not IsDate(txtDataFinal.Value) Then
            Msg_Mensagem("Favor informe a data final.")
            txtDataFinal.Focus()
            Exit Sub
        End If
        If cboBanco.SelectedIndex < 1 And chkExibirSaldo.Checked Then
            Msg_Mensagem("Favor selecionar um banco.")
            cboBanco.Focus()
            Exit Sub
        End If

        If chkExibirSaldo.Checked Then
            SqlText = "SELECT VL_SALDO_ANTERIOR FROM SOF.BANCO WHERE CD_BANCO = " & cboBanco.SelectedValue
            VL_SALDO_ANTERIOR = DBQuery_ValorUnico(SqlText)

            With grdGeral.DisplayLayout.Bands(0)
                .SummaryFooterCaption = ""
                .Summaries.Clear()

                With .Summaries.Add(" = ", "")
                    .DisplayFormat = "Saldo Anterior = R$ " & FormatNumber(VL_SALDO_ANTERIOR.ToString, 2, , , TriState.True)
                    .SummaryDisplayArea = UltraWinGrid.SummaryDisplayAreas.TopFixed
                End With
            End With
        End If

        SqlText = "SELECT MB.DT_MOVIMENTACAO," & _
                         "MB.NU_CHEQUE," & _
                         "MB.IC_DEBITO_CREDITO," & _
                         "MB.VL_BRUTO," & _
                         "MB.NO_FAVORECIDO," & _
                         "B.NO_BANCO," & _
                         "MB.SQ_MOV_BANCARIO," & _
                         "FI.NO_FILIAL," & _
                         "DECODE(MB.IC_DEBITO_CREDITO, 'C', 1, 'D', -1) * MB.VL_BRUTO VL_BRUTO_REAL," & _
                         "DECODE(MB.IC_DEBITO_CREDITO, 'C', MB.VL_BRUTO, 0) VL_CREDITO," & _
                         "DECODE(MB.IC_DEBITO_CREDITO, 'D', MB.VL_BRUTO, 0) VL_DEBITO, MB.IC_EXCLUIDO" & _
                  " FROM SOF.MOV_BANCARIO MB," & _
                        "SOF.BANCO B," & _
                        "SOF.FILIAL FI" & _
                  " WHERE MB.CD_BANCO = B.CD_BANCO" & _
                    " AND TRUNC(MB.DT_MOVIMENTACAO) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & _
                    " AND TRUNC(MB.DT_MOVIMENTACAO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & _
                    " AND FI.CD_FILIAL = MB.CD_FILIAL"

        If cboBanco.SelectedIndex > 0 Then
            SqlText = SqlText & " AND MB.CD_BANCO = " & cboBanco.SelectedValue
        End If
        If cboCreditoDebito.SelectedIndex > 0 Then
            SqlText = SqlText & " AND MB.IC_DEBITO_CREDITO= " & QuotedStr(cboCreditoDebito.SelectedValue)
        End If
        If Trim(txtNrCheque.Text) <> "" Then
            SqlText = SqlText & " AND MB.NU_CHEQUE= " & QuotedStr(txtNrCheque.Text)
        End If
        If ObjUltraComboBox_LinhaSelecionada(cboFilial) Then
            SqlText = SqlText & " AND MB.CD_FILIAL IN (" & cboFilial.Value & ")"
        End If

        SqlText = SqlText & _
                  " ORDER BY MB.DT_MOVIMENTACAO," & _
                            "B.NO_BANCO," & _
                            "MB.NU_CHEQUE"

        AVI_Carregar(Me)

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Data, _
                                                           cnt_GridGeral_Numero, _
                                                           cnt_GridGeral_DC, _
                                                           cnt_GridGeral_Valor, _
                                                           cnt_GridGeral_Favorecido, _
                                                           cnt_GridGeral_Banco, _
                                                           cnt_GridGeral_Lancamento, _
                                                           cnt_GridGeral_Filial, _
                                                           cnt_GridGeral_VL_BRUTO_REAL, _
                                                           cnt_GridGeral_VL_CREDITO, _
                                                           cnt_GridGeral_VL_DEBITO, _
                                                           cnt_GridGeral_IC_EXCLUIDO})

        If chkExibirSaldo.Checked Then
            'Rodapé
            With grdGeral.DisplayLayout.Bands(0)
                .SummaryFooterCaption = ""

                With .Summaries.Add(UltraWinGrid.SummaryType.Sum, .Columns(cnt_GridGeral_VL_CREDITO), UltraWinGrid.SummaryPosition.Left)
                    .DisplayFormat = "Crédito (+) = {0: R$ ###,###,##0.00}"
                    .SummaryDisplayArea = UltraWinGrid.SummaryDisplayAreas.BottomFixed
                End With
                With .Summaries.Add(UltraWinGrid.SummaryType.Sum, .Columns(cnt_GridGeral_VL_DEBITO), UltraWinGrid.SummaryPosition.Left)
                    .DisplayFormat = "Débito (-) = {0: R$ ###,###,##0.00}"
                    .SummaryDisplayArea = UltraWinGrid.SummaryDisplayAreas.BottomFixed
                End With
                With .Summaries.Add("")
                    .DisplayFormat = "Saldo Atual = {0: R$ ###,###,##0.00}"
                    .SummaryDisplayArea = UltraWinGrid.SummaryDisplayAreas.BottomFixed
                    .SummaryType = UltraWinGrid.SummaryType.Formula
                    .Formula = "sum([" & oDS.Band.Columns(cnt_GridGeral_VL_BRUTO_REAL).Key & "]) + " & VL_SALDO_ANTERIOR
                End With
            End With
        End If

        Dim iCont As Integer

        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_Valor(grdGeral, cnt_GridGeral_DC, iCont) = "D" Then
                With grdGeral.Rows(iCont).Appearance
                    .ForeColor = Color.Red
                    .FontData.Bold = DefaultableBoolean.True
                End With
            Else
                With grdGeral.Rows(iCont).Appearance
                    .ForeColor = Color.Blue
                    .FontData.Bold = DefaultableBoolean.True
                End With
            End If
            If NVL(objGrid_Valor(grdGeral, cnt_GridGeral_IC_EXCLUIDO, iCont), "") <> "" Then
                With grdGeral.Rows(iCont).Appearance
                    .BackColor = Color.Yellow
                End With
            End If
        Next

        AVI_Fechar(Me)
    End Sub

    Private Sub chkExibirSaldo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExibirSaldo.CheckedChanged
        lblR_CreditoDebito.Enabled = (Not chkExibirSaldo.Checked)
        cboCreditoDebito.Enabled = (Not chkExibirSaldo.Checked)
        lblR_Numero.Enabled = (Not chkExibirSaldo.Checked)
        txtNrCheque.Enabled = (Not chkExibirSaldo.Checked)
        lblR_Filial.Enabled = (Not chkExibirSaldo.Checked)
        cboFilial.Enabled = (Not chkExibirSaldo.Checked)

        cboFilial.SelectedRow = Nothing
        cboCreditoDebito.SelectedIndex = -1
        txtNrCheque.Text = ""
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        Pesquisar()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text & " - " & IIf(chkExibirSaldo.Checked, "Saldo", "Consulta"))
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro")
            Exit Sub
        End If
        If NVL(objGrid_Valor(grdGeral, cnt_GridGeral_IC_EXCLUIDO), "") = "E" Then
            Msg_Mensagem("Lançamento já excluido")
            Exit Sub
        End If

        If NVL(objGrid_Valor(grdGeral, cnt_GridGeral_IC_EXCLUIDO), "") = "R" Then
            Msg_Mensagem("Registro proveniente de uma exclusão, não pode ser deletado.")
            Exit Sub
        End If

        On Error GoTo Erro

        Dim SqlText As String
        Dim SqMovBancario As Integer
        Dim SqItemMovBancario As Integer

        If Not Msg_Perguntar("Deseja realmente excluir esse pagamento de frete") Then Exit Sub

        If FilialFechada(FilialLogada) Then Exit Sub

        SqlText = DBMontar_Function("SOF.VERIFICA_MOV_BANCO_RD", ":CQ")

        If Not DBExecutar(SqlText, DBParametro_Montar(":CQ", objGrid_Valor(grdGeral, cnt_GridGeral_Lancamento)), _
                                   DBParametro_Montar("RET", Nothing, , ParameterDirection.ReturnValue)) Then GoTo Erro

        If DBTeveRetorno() Then
            If Val(DBRetorno(1)) = 1 Then
                If Not Msg_Perguntar("Essa ação ira alterar o RD. Deseja continua?") Then Exit Sub
            End If
        End If

        If objGrid_Valor(grdGeral, cnt_GridGeral_Data) <> DataSistema() Then
            If Not Msg_Perguntar("Esta movimentação não é de hoje. Deseja continuar") Then Exit Sub

            DBUsarTransacao = True

            'cria mov
            SqMovBancario = DBQuery_ValorUnico("SELECT NVL(MAX(SQ_MOV_BANCARIO)+1,1) FROM SOF.MOV_BANCARIO")

            SqlText = "INSERT INTO sof.mov_bancario"
            SqlText = SqlText & "            (sq_mov_bancario, cd_banco, nu_cheque, dt_movimentacao,"
            SqlText = SqlText & "                no_favorecido, vl_bruto, ic_debito_credito, cd_filial,"
            SqlText = SqlText & "                dt_criacao, no_user_criacao)"
            SqlText = SqlText & "      (SELECT " & SqMovBancario & ", a.cd_banco, a.nu_cheque, " & QuotedStr(Date_to_Oracle(DataSistema)) & ","
            SqlText = SqlText & "              a.no_favorecido, a.vl_bruto * -1, a.ic_debito_credito, a.cd_filial,"
            SqlText = SqlText & "              SYSDATE, " & QuotedStr(sAcesso_UsuarioLogado)
            SqlText = SqlText & "         FROM sof.mov_bancario a"
            SqlText = SqlText & "        WHERE a.sq_mov_bancario = " & objGrid_Valor(grdGeral, cnt_GridGeral_Lancamento) & ")"

            If Not DBExecutar(SqlText) Then GoTo Erro

            'cria itens
            SqItemMovBancario = DBQuery_ValorUnico("SELECT SOF.SEQ_ITEM_MOV_BANCARIO.NEXTVAL FROM DUAL")

            SqlText = " INSERT INTO sof.item_mov_bancario"
            SqlText = SqlText & "             (sq_item_mov_bancario, cd_operacao_bancaria, sq_mov_bancario,"
            SqlText = SqlText & "              dt_movimentacao, ds_descricao, no_favorecido, vl_pago,"
            SqlText = SqlText & "              ic_debito_credito, cd_filial_debitada, vl_liquido, vl_bruto,"
            SqlText = SqlText & "              cd_filial_pagadora, dt_criacao, no_user_criacao,"
            SqlText = SqlText & "              vl_provisao_total, cd_fretista)"
            SqlText = SqlText & "    (SELECT " & SqItemMovBancario & ", a.cd_operacao_bancaria, " & SqMovBancario & ","
            SqlText = SqlText & "            " & QuotedStr(Date_to_Oracle(DataSistema)) & ", a.ds_descricao, a.no_favorecido, a.vl_pago * -1,"
            SqlText = SqlText & "            a.ic_debito_credito, a.cd_filial_debitada, a.vl_liquido * -1,"
            SqlText = SqlText & "            a.vl_bruto * -1, a.cd_filial_pagadora, sysdate, "
            SqlText = SqlText & "           " & QuotedStr(sAcesso_UsuarioLogado) & ", a.vl_provisao_total * -1, a.cd_fretista"
            SqlText = SqlText & "       FROM sof.item_mov_bancario a"
            SqlText = SqlText & "       WHERE a.sq_item_mov_bancario IN (SELECT sq_item_mov_bancario"
            SqlText = SqlText & "                                  FROM sof.item_mov_bancario"
            SqlText = SqlText & "                                 WHERE a.sq_mov_bancario = " & objGrid_Valor(grdGeral, cnt_GridGeral_Lancamento) & "))"

            If Not DBExecutar(SqlText) Then GoTo Erro

            'cria provisao
            SqlText = "insert into  sof.item_mov_bancario_provisao (sq_item_mov_bancario, sq_item_mov_bancario_provisao,"
            SqlText = SqlText & "       cd_provisao, vl_provisao, dt_criacao, no_user_criacao)"
            SqlText = SqlText & "  (SELECT " & SqItemMovBancario & ", a.sq_item_mov_bancario_provisao,"
            SqlText = SqlText & "       a.cd_provisao, a.vl_provisao *-1, sysdate, " & QuotedStr(sAcesso_UsuarioLogado)
            SqlText = SqlText & "  FROM sof.item_mov_bancario_provisao a"
            SqlText = SqlText & "       WHERE a.sq_item_mov_bancario IN (SELECT sq_item_mov_bancario"
            SqlText = SqlText & "                                  FROM sof.item_mov_bancario"
            SqlText = SqlText & "                                 WHERE sq_mov_bancario = " & objGrid_Valor(grdGeral, cnt_GridGeral_Lancamento) & "))"

            If Not DBExecutar(SqlText) Then GoTo Erro

            'atualiza frete pagamento
            SqlText = "UPDATE sof.frete_pagamento"
            SqlText = SqlText & "   SET sq_item_mov_bancario = NULL"
            SqlText = SqlText & " WHERE sq_item_mov_bancario IN (SELECT sq_item_mov_bancario"
            SqlText = SqlText & "                                  FROM sof.item_mov_bancario"
            SqlText = SqlText & "                                 WHERE sq_mov_bancario = " & objGrid_Valor(grdGeral, cnt_GridGeral_Lancamento) & ")"

            If Not DBExecutar(SqlText) Then GoTo Erro

            'atualiza COMO EXCLUIDO
            SqlText = "UPDATE sof.mov_BANCARIO"
            SqlText = SqlText & "   SET ic_EXCLUIDO = 'E'"
            SqlText = SqlText & " WHERE sq_mov_bancario =  " & objGrid_Valor(grdGeral, cnt_GridGeral_Lancamento)
            If Not DBExecutar(SqlText) Then GoTo Erro

            'atualiza COMO reversao
            SqlText = "UPDATE sof.mov_BANCARIO"
            SqlText = SqlText & "   SET ic_EXCLUIDO = 'R'"
            SqlText = SqlText & " WHERE sq_mov_bancario =  " & SqMovBancario
            If Not DBExecutar(SqlText) Then GoTo Erro

            If Not DBExecutarTransacao() Then GoTo Erro

            'retira do RD
            SqlText = DBMontar_SP("SOF.mov_banco_rd", False, ":CQ", ":DATA")

            If Not DBExecutar(SqlText, DBParametro_Montar("CQ", SqMovBancario), _
                                       DBParametro_Montar("DATA", Date_to_Oracle(DataSistema))) Then GoTo Erro
        Else

            If Not Msg_Perguntar("Elimina o registro?") Then Exit Sub

            SqlText = DBMontar_SP("SOF.ELIMINA_MOV_BANCARIO", False, ":MOVB", ":DTHOJE")

            If Not DBExecutar(SqlText, DBParametro_Montar("MOVB", objGrid_Valor(grdGeral, cnt_GridGeral_Lancamento)), _
                                       DBParametro_Montar("DTHOJE", Date_to_Oracle(DataSistema))) Then GoTo Erro
        End If


        Pesquisar()

        Exit Sub

Erro:
        TratarErro()
        Pesquisar()
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Form_Show(Me.MdiParent, New frmCadastroMovimentacaoBancaria)
    End Sub

    Private Sub cmdItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItem.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Filtro = objGrid_Valor(grdGeral, cnt_GridGeral_Lancamento)
        Form_Carregar_Consulta_Geral(Me.MdiParent, frmConsultaGeral.eConsultaGeral.MovimentacaoBancaria_Item)
    End Sub

    Private Sub cmdVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVoucher.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmRelatorioGeral

        oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eVoucher
        oForm.Filtro01 = objGrid_Valor(grdGeral, cnt_GridGeral_Lancamento)
        Form_Show(Nothing, oForm)
    End Sub

    Private Sub cmdCheque_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCheque.Click
        Dim sNomeImpressora As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If CampoNulo(objGrid_Valor(grdGeral, cnt_GridGeral_Numero)) Or _
           objGrid_Valor(grdGeral, cnt_GridGeral_DC) = "C" Then
            Msg_Mensagem("Esta movimentação não emiti cheque.")
            Exit Sub
        End If

        sNomeImpressora = Registro_Read_String("IMPRESSORA_CHEQUE")

        If Not Msg_Perguntar("Imprime o cheque? " & IIf(sNomeImpressora <> "", "O cheque será impresso em: " & sNomeImpressora, "")) Then Exit Sub

        Cheque_Imprimir(objGrid_Valor(grdGeral, cnt_GridGeral_Lancamento))
    End Sub

    Private Sub frmConsultaMovimentacaoBancaria_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdItem.Top = Me.ClientSize.Height - cmdItem.Height - 6
        cmdCheque.Top = Me.ClientSize.Height - cmdCheque.Height - 6
        cmdVoucher.Top = Me.ClientSize.Height - cmdVoucher.Height - 6
        cmdNovo.Top = Me.ClientSize.Height - cmdNovo.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcluir.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdUsuario.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
    End Sub
End Class