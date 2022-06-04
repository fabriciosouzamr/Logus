Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmGeraPremioQualidade
    Const cnt_GridGeral_Selecao As Integer = 0
    Const cnt_GridGeral_ContratoPaf As Integer = 1
    Const cnt_GridGeral_Negociacao As Integer = 2
    Const cnt_GridGeral_ContratoFixo As Integer = 3
    Const cnt_GridGeral_Fornecedor As Integer = 4
    Const cnt_GridGeral_Quantidade As Integer = 5
    Const cnt_GridGeral_ValorBonus As Integer = 6
    Const cnt_GridGeral_IcStatus As Integer = 7
    Const cnt_GridGeral_IcStatusNegociacao As Integer = 8
    Const cnt_GridGeral_IcStatusContratoPaf As Integer = 9
    Const cnt_GridGeral_CdTipAdendo As Integer = 10
    Const cnt_GridGeral_NoTipAdendo As Integer = 11

    Const cnt_SEC_Tela As String = "Transacao_Contratos_GerarPremioQualidade"

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim SqlFiltro As String

    Private Sub frmGeraPremioQualidade_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_CodigoNome.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        ComboBox_Carregar_Tipo_Bonus(cboTipoBonus, True)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdGeral, "Seleciona", 70, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdGeral, "Contrato PAF", 80)
        objGrid_Coluna_Add(grdGeral, "Negociação", 100)
        objGrid_Coluna_Add(grdGeral, "Contrato Fixo", 120)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 150)
        objGrid_Coluna_Add(grdGeral, "Quantidade", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Valor Bônus", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Status", 80)
        objGrid_Coluna_Add(grdGeral, "Status Negociação", 150)
        objGrid_Coluna_Add(grdGeral, "Status PAF", 100)
        objGrid_Coluna_Add(grdGeral, "Cd Tp Adendo", 0)
        objGrid_Coluna_Add(grdGeral, "Tipo Adendo", 140)

        objGrid_ExibirTotal(grdGeral, New Integer() {cnt_GridGeral_ValorBonus})

        SEC_ValidarBotao(cmdGravar, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT   0 seleciona, bcf.cd_contrato_paf, bcf.sq_negociacao, "
        SqlText = SqlText & "   bcf.sq_contrato_fixo,f.no_razao_social,SUM (cm.qt_kg_fixo) AS qt_kg_fixo, "
        SqlText = SqlText & "   sum(ROUND ((ABS (bcf.vl_unitario_bonus / bcf.qt_fator_bonus)* cm.qt_kg_fixo),2)) AS vl_bonus, "
        SqlText = SqlText & "   cf.ic_status, n.ic_status ic_status_negociacao,cp.ic_status ic_status_contrato_paf, "
        SqlText = SqlText & "   ta.cd_tipo_adendo, ta.DS_TIPO_ADENDO "
        SqlText = SqlText & "FROM sof.bonus_contrato_fixo bcf, sof.bonus_padrao bp, "
        SqlText = SqlText & "     sof.ctr_paf_neg_ctr_fix_mov cm, "
        SqlText = SqlText & "     sof.contrato_paf cp, "
        SqlText = SqlText & "     sof.filial fil, "
        SqlText = SqlText & "     sof.fornecedor f, "
        SqlText = SqlText & "     sof.municipio munic, "
        SqlText = SqlText & "     sof.contrato_fixo cf, "
        SqlText = SqlText & "     sof.negociacao n, sof.tipo_adendo ta "
        SqlText = SqlText & "WHERE cm.sq_movimentacao = bcf.sq_movimentacao AND "
        SqlText = SqlText & "      cm.sq_movimentacao_cessao_direito = bcf.sq_movimentacao_cessao_direito AND "
        SqlText = SqlText & "      cm.cd_contrato_paf = bcf.cd_contrato_paf AND "
        SqlText = SqlText & "      cm.sq_ctr_paf_movimentacao = bcf.sq_ctr_paf_movimentacao AND "
        SqlText = SqlText & "      cm.sq_negociacao = bcf.sq_negociacao AND "
        SqlText = SqlText & "      cm.sq_ctr_paf_neg_movimentacao = bcf.sq_ctr_paf_neg_movimentacao AND "
        SqlText = SqlText & "      cm.sq_contrato_fixo = bcf.sq_contrato_fixo AND "
        SqlText = SqlText & "      cm.sq_ctr_paf_neg_ctr_fix_mov = bcf.sq_ctr_paf_neg_ctr_fix_mov AND "
        SqlText = SqlText & "      cp.cd_contrato_paf = cm.cd_contrato_paf AND "
        SqlText = SqlText & "      n.cd_contrato_paf = cm.cd_contrato_paf AND "
        SqlText = SqlText & "      n.sq_negociacao = cm.sq_negociacao AND "
        SqlText = SqlText & "      f.cd_fornecedor = cp.cd_fornecedor AND "
        SqlText = SqlText & "      fil.cd_filial = f.cd_filial_origem AND "
        SqlText = SqlText & "      f.cd_municipio = munic.cd_municipio AND "
        SqlText = SqlText & "      bcf.cd_bonus_padrao = bp.cd_bonus_padrao  AND "
        SqlText = SqlText & "      bp.cd_tipo_adendo = ta.cd_tipo_adendo (+) AND "
        SqlText = SqlText & "      bcf.cd_contrato_paf = cf.cd_contrato_paf AND "
        SqlText = SqlText & "      bcf.sq_negociacao = cf.sq_negociacao AND "
        SqlText = SqlText & "      bcf.sq_contrato_fixo = cf.sq_contrato_fixo AND "
        SqlText = SqlText & "      munic.cd_uf <> 'EX' AND "
        SqlText = SqlText & "      bcf.ic_pago = 'N' "

        If IsDate(txtDataInicial.Text) Then
            SqlFiltro = SqlFiltro & " AND TRUNC(bcf.dt_concessao ) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlFiltro = SqlFiltro & " AND TRUNC(bcf.dt_concessao ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If
        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        If chkTotalmenteEntregue.Checked = True Then
            SqlText = SqlText & " and (cf.qt_kgs - cf.qt_cancelado - cf.qt_kg_fixo)=0"
        End If

        If ComboBox_LinhaSelecionada(cboTipoBonus) Then
            SqlFiltro = SqlFiltro & "  AND BCF.cd_bonus_padrao = " & cboTipoBonus.SelectedValue & " AND "
            SqlFiltro = SqlFiltro & "      CP.cd_fornecedor IN (SELECT CD_FORNECEDOR "
            SqlFiltro = SqlFiltro & "                           FROM (SELECT SUM((bcf.vl_unitario_bonus / bcf.qt_fator_bonus * cm.qt_kg_fixo)) VL_bonus, "
            SqlFiltro = SqlFiltro & "                                        cp.cd_fornecedor "
            SqlFiltro = SqlFiltro & "                                 FROM SOF.bonus_contrato_fixo bcf, "
            SqlFiltro = SqlFiltro & "                                      SOF.contrato_paf cp, "
            SqlFiltro = SqlFiltro & "                                      SOF.ctr_paf_neg_ctr_fix_mov cm "
            SqlFiltro = SqlFiltro & "                                 WHERE cp.cd_contrato_paf = bcf.cd_contrato_paf AND "
            SqlFiltro = SqlFiltro & "                                       cm.sq_movimentacao = bcf.sq_movimentacao AND "
            SqlFiltro = SqlFiltro & "                                       cm.sq_movimentacao_cessao_direito = bcf.sq_movimentacao_cessao_direito AND "
            SqlFiltro = SqlFiltro & "                                       cm.cd_contrato_paf = bcf.cd_contrato_paf AND "
            SqlFiltro = SqlFiltro & "                                       cm.sq_ctr_paf_movimentacao = bcf.sq_ctr_paf_movimentacao AND "
            SqlFiltro = SqlFiltro & "                                       cm.sq_negociacao = bcf.sq_negociacao AND "
            SqlFiltro = SqlFiltro & "                                       cm.sq_ctr_paf_neg_movimentacao = bcf.sq_ctr_paf_neg_movimentacao AND "
            SqlFiltro = SqlFiltro & "                                       cm.sq_contrato_fixo = bcf.sq_contrato_fixo AND "
            SqlFiltro = SqlFiltro & "                                       cm.sq_ctr_paf_neg_ctr_fix_mov = bcf.sq_ctr_paf_neg_ctr_fix_mov AND "
            SqlFiltro = SqlFiltro & "                                       BCF.ic_pago = 'N' AND "
            SqlFiltro = SqlFiltro & "                                       BCF.cd_bonus_padrao = " & cboTipoBonus.SelectedValue & " "
            SqlFiltro = SqlFiltro & "                                       GROUP BY cp.cd_fornecedor )) "
        End If

        If Pesq_CodigoNome.Codigo <> 0 Then
            SqlText = SqlText & " and cp.cd_fornecedor=" & Pesq_CodigoNome.Codigo
        End If

        SqlText = SqlText & SqlFiltro & " group by fil.no_filial, f.no_razao_social, bcf.cd_contrato_paf,bcf.sq_negociacao, "
        SqlText = SqlText & " bcf.sq_contrato_fixo, cf.ic_status, n.ic_status, cp.ic_status,ta.cd_tipo_adendo, ta.DS_TIPO_ADENDO "

        SqlText = "select * from (" & SqlText & ") order by cd_contrato_paf,sq_negociacao,sq_contrato_fixo"

        oData = DBQuery(SqlText)

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Selecao, _
                                                            cnt_GridGeral_ContratoPaf, _
                                                            cnt_GridGeral_Negociacao, _
                                                            cnt_GridGeral_ContratoFixo, _
                                                            cnt_GridGeral_Fornecedor, _
                                                            cnt_GridGeral_Quantidade, _
                                                            cnt_GridGeral_ValorBonus, _
                                                            cnt_GridGeral_IcStatus, _
                                                            cnt_GridGeral_IcStatusNegociacao, _
                                                            cnt_GridGeral_IcStatusContratoPaf, _
                                                            cnt_GridGeral_CdTipAdendo, _
                                                            cnt_GridGeral_NoTipAdendo})
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim Registros As Long = 0
        Dim Fator As Double
        Dim iCont As Long
        Dim oForm As frmProgressBar


        If Msg_Perguntar("Inclui o adendo nos contratos selecionados ?") = False Then Exit Sub


        DBUsarTransacao = True

        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_Selecao, iCont) Then
                Registros = Registros + 1
                If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_Selecao, iCont) = Nothing Then
                    Msg_Mensagem("Favor parametrizar o tipo de adendo do bonus.")
                    Exit Sub
                End If
            End If

        Next

        Fator = 100 / Registros

        oForm = New frmProgressBar
        oForm.lblTexto.Text = "Gerando Bônus"
        oForm.Show()

        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_Selecao, iCont) Then
                GeraPremioQualidade(objGrid_Valor(grdGeral, cnt_GridGeral_IcStatusContratoPaf, iCont), _
                                    objGrid_Valor(grdGeral, cnt_GridGeral_IcStatusNegociacao, iCont), _
                                    objGrid_Valor(grdGeral, cnt_GridGeral_IcStatus, iCont), _
                                    objGrid_Valor(grdGeral, cnt_GridGeral_ContratoPaf, iCont), _
                                    objGrid_Valor(grdGeral, cnt_GridGeral_Negociacao, iCont), _
                                    objGrid_Valor(grdGeral, cnt_GridGeral_ContratoFixo, iCont), _
                                    objGrid_Valor(grdGeral, cnt_GridGeral_CdTipAdendo, iCont, 0), _
                                    objGrid_Valor(grdGeral, cnt_GridGeral_ValorBonus, iCont))

                oForm.Inclementa_Valor_ProgressBar(Fator)
                oForm.Refresh()
            End If
        Next

        oForm.Close()

        If Not DBExecutarTransacao() Then GoTo Erro

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

   

    Private Sub cmdSelecionaTudo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionaTudo.Click
        Dim iCont As Integer
        For iCont = 0 To grdGeral.Rows.Count - 1
            grdGeral.Rows(iCont).Cells(cnt_GridGeral_Selecao).Value = 1
        Next
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim SqlText As String
        Dim Registros As Long = 0
        Dim Fator As Double
        Dim iCont As Long
        Dim oForm As frmProgressBar

        If Msg_Perguntar("Cancela os bonus selecionados?") = False Then Exit Sub

        DBUsarTransacao = True

        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_Selecao, iCont) Then
                Registros = Registros + 1
            End If
        Next
        Fator = 100 / Registros

        oForm = New frmProgressBar
        oForm.lblTexto.Text = "Excluindo Bônus"
        oForm.Show()

        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_Selecao, iCont) Then
                SqlText = "UPDATE sof.bonus_contrato_fixo "
                SqlText = SqlText & "   SET ic_pago = 'C', "
                SqlText = SqlText & "       dt_alteracao = '" & Date_to_Oracle(DataSistema) & "', "
                SqlText = SqlText & "       no_user_alteracao = '" & sAcesso_UsuarioLogado & "'"
                SqlText = SqlText & " WHERE (sq_movimentacao, "
                SqlText = SqlText & "        cd_contrato_paf, "
                SqlText = SqlText & "        sq_ctr_paf_movimentacao, "
                SqlText = SqlText & "        sq_negociacao, "
                SqlText = SqlText & "        sq_ctr_paf_neg_movimentacao, "
                SqlText = SqlText & "        sq_contrato_fixo, "
                SqlText = SqlText & "        sq_ctr_paf_neg_ctr_fix_mov, "
                SqlText = SqlText & "        sq_movimentacao_cessao_direito "
                SqlText = SqlText & "       ) IN ( "
                SqlText = SqlText & "          SELECT bcf.sq_movimentacao, bcf.cd_contrato_paf, "
                SqlText = SqlText & "                 bcf.sq_ctr_paf_movimentacao, bcf.sq_negociacao, "
                SqlText = SqlText & "                 bcf.sq_ctr_paf_neg_movimentacao, bcf.sq_contrato_fixo, "
                SqlText = SqlText & "                 bcf.sq_ctr_paf_neg_ctr_fix_mov, "
                SqlText = SqlText & "                 bcf.sq_movimentacao_cessao_direito "
                SqlText = SqlText & "            FROM sof.bonus_contrato_fixo bcf, "
                SqlText = SqlText & "                 sof.ctr_paf_neg_ctr_fix_mov cm, "
                SqlText = SqlText & "                 sof.contrato_paf cp, "
                SqlText = SqlText & "                 sof.contrato_fixo cf, "
                SqlText = SqlText & "                 sof.negociacao n "
                SqlText = SqlText & "           WHERE cm.sq_movimentacao = bcf.sq_movimentacao "
                SqlText = SqlText & "             AND cm.sq_movimentacao_cessao_direito = "
                SqlText = SqlText & "                                            bcf.sq_movimentacao_cessao_direito "
                SqlText = SqlText & "             AND cm.cd_contrato_paf = bcf.cd_contrato_paf "
                SqlText = SqlText & "             AND cm.sq_ctr_paf_movimentacao = bcf.sq_ctr_paf_movimentacao "
                SqlText = SqlText & "             AND cm.sq_negociacao = bcf.sq_negociacao "
                SqlText = SqlText & "             AND cm.sq_ctr_paf_neg_movimentacao = "
                SqlText = SqlText & "                                               bcf.sq_ctr_paf_neg_movimentacao "
                SqlText = SqlText & "             AND cm.sq_contrato_fixo = bcf.sq_contrato_fixo "
                SqlText = SqlText & "             AND cm.sq_ctr_paf_neg_ctr_fix_mov = "
                SqlText = SqlText & "                                                bcf.sq_ctr_paf_neg_ctr_fix_mov "
                SqlText = SqlText & "             AND cp.cd_contrato_paf = cm.cd_contrato_paf "
                SqlText = SqlText & "             AND n.cd_contrato_paf = cm.cd_contrato_paf "
                SqlText = SqlText & "             AND n.sq_negociacao = cm.sq_negociacao "
                SqlText = SqlText & "             AND bcf.cd_contrato_paf = cf.cd_contrato_paf "
                SqlText = SqlText & "             AND bcf.sq_negociacao = cf.sq_negociacao "
                SqlText = SqlText & "             AND bcf.sq_contrato_fixo = cf.sq_contrato_fixo "
                SqlText = SqlText & "             AND bcf.ic_pago = 'N' "
                SqlText = SqlText & "             AND cf.cd_contrato_paf= " & objGrid_Valor(grdGeral, cnt_GridGeral_ContratoPaf, iCont)
                SqlText = SqlText & "             AND cf.sq_negociacao= " & objGrid_Valor(grdGeral, cnt_GridGeral_Negociacao, iCont)
                SqlText = SqlText & "             AND cf.sq_contrato_fixo= " & objGrid_Valor(grdGeral, cnt_GridGeral_ContratoFixo, iCont)
                SqlText = SqlText & SqlFiltro

                If Not DBExecutar(SqlText) Then GoTo Erro

                oForm.Inclementa_Valor_ProgressBar(Fator)
                oForm.Refresh()
            End If
        Next

        oForm.Close()

        If Not DBExecutarTransacao() Then GoTo Erro

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub frmGeraPremioQualidade_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 8
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 8
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdGravar.Top = Me.ClientSize.Height - cmdGravar.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub
End Class