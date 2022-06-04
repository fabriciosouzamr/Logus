Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmAmarracaoICMS
    Const cnt_GridMovimentacao_Codigo As Integer = 0
    Const cnt_GridMovimentacao_NF As Integer = 1
    Const cnt_GridMovimentacao_Serie As Integer = 2
    Const cnt_GridMovimentacao_Fornecedor As Integer = 3
    Const cnt_GridMovimentacao_ValorNF As Integer = 4
    Const cnt_GridMovimentacao_ValorICMS As Integer = 5
    Const cnt_GridMovimentacao_CdFornecedor As Integer = 6

    Const cnt_GridPagamento_Codigo As Integer = 0
    Const cnt_GridPagamento_Selecionado As Integer = 1
    Const cnt_GridPagamento_ValorAplicacao As Integer = 2
    Const cnt_GridPagamento_Saldo As Integer = 3
    Const cnt_GridPagamento_Data As Integer = 4
    Const cnt_GridPagamento_Observação As Integer = 5
    Const cnt_GridPagamento_ContratoPAF As Integer = 6
    Const cnt_GridPagamento_SqPagCtrPAF As Integer = 7

    Const cnt_SEC_Tela As String = "Transacao_Contratos_AmarracaoManualICMS"

    Dim oDSMovimentacao As New UltraWinDataSource.UltraDataSource
    Dim oDSPagamento As New UltraWinDataSource.UltraDataSource

    Private Sub frmAmarracaoICMS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        objGrid_Inicializar(grdMovimentcao, , oDSMovimentacao, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdMovimentcao, "Código", 0)
        objGrid_Coluna_Add(grdMovimentcao, "NF", 60)
        objGrid_Coluna_Add(grdMovimentcao, "Serie", 60)
        objGrid_Coluna_Add(grdMovimentcao, "Fornecedor", 160)
        objGrid_Coluna_Add(grdMovimentcao, "Valor NF", 100)
        objGrid_Coluna_Add(grdMovimentcao, "Valor ICMS", 100)
        objGrid_Coluna_Add(grdMovimentcao, "Codigo Fornecedor", 0)

        objGrid_Inicializar(grdPagamento, , oDSPagamento, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdPagamento, "Código", 0)
        objGrid_Coluna_Add(grdPagamento, "Selecionado", 60, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdPagamento, "Aplicação", 80, , True)
        objGrid_Coluna_Add(grdPagamento, "Saldo", 80)
        objGrid_Coluna_Add(grdPagamento, "Data", 80)
        objGrid_Coluna_Add(grdPagamento, "Observação", 200)
        objGrid_Coluna_Add(grdPagamento, "Contrato PAF", 0)
        objGrid_Coluna_Add(grdPagamento, "SqPagCtrPAF", 0)

        SEC_ValidarBotao(cmdGravar, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Sub ExecutaConsultaMovimentacao()
        Dim SqlText As String

        oDSPagamento.Rows.Clear()

        SqlText = "select m.sq_movimentacao , m.nu_nf ,m.nu_serie_nf , f.no_razao_social , m.vl_nf ,m.vl_nf_icms, m.cd_fornecedor "
        SqlText = SqlText & "from sof.movimentacao m, sof.fornecedor f "
        SqlText = SqlText & "where m.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "and m.vl_nf_icms <>0 "
        SqlText = SqlText & "and m.ic_icms_pago ='N' "


        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND  f.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            SqlText = SqlText & " AND  f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & " order by f.no_razao_social "

        objGrid_Carregar(grdMovimentcao, SqlText, New Integer() {cnt_GridMovimentacao_Codigo, _
                                                                cnt_GridMovimentacao_NF, _
                                                                cnt_GridMovimentacao_Serie, _
                                                                cnt_GridMovimentacao_Fornecedor, _
                                                                cnt_GridMovimentacao_ValorNF, _
                                                                cnt_GridMovimentacao_ValorICMS, _
                                                                cnt_GridMovimentacao_CdFornecedor})
    End Sub

    Sub ExecutaConsultaPagamento()
        Dim SqlText As String

        If grdMovimentcao.DisplayLayout.ActiveRow Is Nothing Then
            oDSPagamento.Rows.Clear()
            Exit Sub
        End If

        SqlText = "select p.sq_pagamento, 0 selecionado, null vl_aplicado,pcp.vl_fixo as vl_a_fixar,  p.dt_pagamento, p.ds_descricao, pcp.CD_CONTRATO_PAF , pcp.SQ_PAG_CTR_PAF "
        SqlText = SqlText & "from sof.pag_ctr_paf pcp, sof.pagamentos p, sof.tipo_pagamento tp, sof.fornecedor f "
        SqlText = SqlText & "where pcp.sq_pagamento =p.sq_pagamento  "
        SqlText = SqlText & "and p.cd_tipo_pagamento=tp.cd_tipo_pagamento  "
        SqlText = SqlText & " and p.cd_fornecedor=f.cd_fornecedor "
        SqlText = SqlText & " and pcp.sq_confissao_divida is null "
        SqlText = SqlText & " and p.sq_movimentacao is null "
        SqlText = SqlText & " and tp.ic_pagamento_icms ='S' "
        SqlText = SqlText & " and p.ic_icms_pago ='N' "
        SqlText = SqlText & " and p.cd_fornecedor = " & objGrid_Valor(grdMovimentcao, cnt_GridMovimentacao_CdFornecedor)
        SqlText = SqlText & " and pcp.vl_fixo =pcp.vl_a_fixar "

       


        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND  f.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            SqlText = SqlText & " AND  f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        'Consulta o que ta em aberto sem ctr
        SqlText = SqlText & " union all "
        SqlText = SqlText & " select p.sq_pagamento, 0 selecionado, null vl_aplicado,P.VL_A_FIXAR as vl_a_fixar,  p.dt_pagamento, p.ds_descricao, 0 CD_CONTRATO_PAF , 0 SQ_PAG_CTR_PAF "
        SqlText = SqlText & "  FROM SOF.PAGAMENTOS P, SOF.FORNECEDOR F "
        SqlText = SqlText & " WHERE p.CD_FORNECEDOR = F.CD_FORNECEDOR "
        SqlText = SqlText & "   AND P.VL_A_FIXAR <> 0 "
        SqlText = SqlText & "   AND P.CD_FORNECEDOR =  " & objGrid_Valor(grdMovimentcao, cnt_GridMovimentacao_CdFornecedor)
        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND  f.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            SqlText = SqlText & " AND  f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If
        ' SqlText = SqlText & " order by f.no_razao_social "

        objGrid_Carregar(grdPagamento, SqlText, New Integer() {cnt_GridPagamento_Codigo, _
                                                                    cnt_GridPagamento_Selecionado, _
                                                                    cnt_GridPagamento_ValorAplicacao, _
                                                                    cnt_GridPagamento_Saldo, _
                                                                    cnt_GridPagamento_Data, _
                                                                    cnt_GridPagamento_Observação, _
                                                                    cnt_GridPagamento_ContratoPAF, _
                                                                    cnt_GridPagamento_SqPagCtrPAF})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsultaMovimentacao()
    End Sub

    Private Sub grdMovimentcao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMovimentcao.Click
        ExecutaConsultaPagamento()
    End Sub

    Private Sub ExcluiMovimentacao()
        Dim SqlText As String

        If grdMovimentcao.DisplayLayout.ActiveRow Is Nothing Then
            Msg_Mensagem("Selecione a movimentação.")
            Exit Sub
        End If

        'ATUALIZO A MOVIMENTAÇÃO
        SqlText = "update sof.movimentacao m "
        SqlText = SqlText & "set m.ic_icms_pago='S' "
        SqlText = SqlText & "where m.sq_movimentacao= " & objGrid_Valor(grdMovimentcao, cnt_GridMovimentacao_Codigo)

        If Not DBExecutar(SqlText) Then GoTo Erro

        Msg_Mensagem("NF Retirada.")
        ExecutaConsultaMovimentacao()
        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub ExcluiPagamento()
        Dim SqlText As String

        If grdPagamento.DisplayLayout.ActiveRow Is Nothing Then
            Msg_Mensagem("Selecione o pagamento.")
            Exit Sub
        End If

        'ATUALIZO O PAGAMENTO
        SqlText = "update sof.pagamentos p "
        SqlText = SqlText & " set p.ic_icms_pago='S' "
        SqlText = SqlText & " where p.sq_pagamento= " & objGrid_Valor(grdPagamento, cnt_GridPagamento_Codigo)

        If Not DBExecutar(SqlText) Then GoTo Erro

        Msg_Mensagem("Pagamento Retirada.")
        ExecutaConsultaPagamento()
        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        mnuExclusao.Show(cmdExcluir, Nothing)
    End Sub

   
    Private Sub MovimentaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimentaçãoToolStripMenuItem.Click
        ExcluiMovimentacao()
    End Sub

    Private Sub PagamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagamentoToolStripMenuItem.Click
        ExcluiPagamento()
    End Sub

    Private Sub grdPagamento_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdPagamento.AfterCellUpdate
        If e.Cell.Column.Index = cnt_GridPagamento_ValorAplicacao Then
            With grdPagamento.Rows(e.Cell.Row.Index)
                If NVL(.Cells(cnt_GridPagamento_ValorAplicacao).Value, 0) < 0 Or _
                   NVL(.Cells(cnt_GridPagamento_ValorAplicacao).Value, 0) > .Cells(cnt_GridPagamento_Saldo).Value Then
                    Msg_Mensagem("O Valor tem que estar entre 0 e " & Format(.Cells(cnt_GridPagamento_Saldo).Value, "#,##0.00"))
                    .Cells(cnt_GridPagamento_ValorAplicacao).Value = e.Cell.OriginalValue
                    Exit Sub
                End If

                If NVL(.Cells(cnt_GridPagamento_ValorAplicacao).Value, 0) = 0 Then
                    .Cells(cnt_GridPagamento_Selecionado).Value = 0
                Else
                    .Cells(cnt_GridPagamento_Selecionado).Value = 1
                End If
            End With
        End If

        Calcula_Total_Aplicado()
    End Sub

    Private Sub grdPagamento_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdPagamento.CellChange
        If e.Cell.Column.Index = cnt_GridPagamento_Selecionado Then
            With grdPagamento.Rows(e.Cell.Row.Index)
                If .Cells(cnt_GridPagamento_Selecionado).Value = 1 Then
                    .Cells(cnt_GridPagamento_ValorAplicacao).Value = 0
                Else
                    .Cells(cnt_GridPagamento_ValorAplicacao).Value = .Cells(cnt_GridPagamento_Saldo).Value
                    .Cells(cnt_GridPagamento_ValorAplicacao).Activate()
                    grdPagamento.PerformAction(UltraGridAction.EnterEditMode)
                End If
            End With
        End If
    End Sub

    Private Sub grdPagamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdPagamento.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdPagamento.PerformAction(UltraGridAction.ExitEditMode)
        End If
    End Sub

    Private Sub Calcula_Total_Aplicado()
        Dim i As Long
        Dim Valor As Double = 0

        For i = 0 To grdPagamento.Rows.Count - 1
            Valor = Valor + CDbl(NVL(grdPagamento.Rows(i).Cells(cnt_GridPagamento_ValorAplicacao).Value, 0))
        Next

        txtTotalAplicado.Value = Valor
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim sqConciliacao As Integer
        Dim ExiteSelecionado As Boolean
        Dim iCont As Integer
        Dim CdModalidadeConciliacao As Integer
        Dim VL_CONCILIACAO As Double

        ExiteSelecionado = False

        If grdMovimentcao.DisplayLayout.ActiveRow Is Nothing Then
            Msg_Mensagem("Selecione a movimentação.")
            Exit Sub
        End If

        For iCont = 0 To grdPagamento.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdPagamento, cnt_GridPagamento_Selecionado, iCont) Then
                ExiteSelecionado = True
            End If
        Next

        If ExiteSelecionado = False Then
            Msg_Mensagem("Favor selecionar um pagamento antes.")
            Exit Sub
        End If

        SqlText = "SELECT p.cd_conciliacao_icms FROM sof.parametro p "
        CdModalidadeConciliacao = DBQuery_ValorUnico(SqlText)

        VL_CONCILIACAO = objGrid_Valor(grdMovimentcao, cnt_GridMovimentacao_ValorICMS)


        If VL_CONCILIACAO <> txtTotalAplicado.Value Then
            Msg_Mensagem("Valores de ICMS e Pagamento diferentes. Não é possivel fazer a amarração")
            Exit Sub
        Else
            SqlText = "select count(*) from sof.ctr_paf_neg_ctr_fix_mov cm, sof.contrato_fixo cf "
            SqlText = SqlText & "where cf.cd_contrato_paf =cm.cd_contrato_paf  "
            SqlText = SqlText & "and cf.sq_negociacao =cm.sq_negociacao  "
            SqlText = SqlText & "and cf.sq_contrato_fixo =cm.sq_ctr_paf_movimentacao  "
            SqlText = SqlText & "and cf.ic_inclui_icms_pag ='S' "
            SqlText = SqlText & "and cm.sq_movimentacao = " & objGrid_Valor(grdMovimentcao, cnt_GridMovimentacao_Codigo)


            If DBQuery_ValorUnico(SqlText) <> 0 Then
                Msg_Mensagem("Essa NF esta aplicada em pelo menos um contrato modalidade antiga. Entre em contato com o suporte.")
                Exit Sub
            End If
        End If

        DBUsarTransacao = True

        'ATUALIZO A MOVIMENTAÇÃO
        SqlText = "update sof.movimentacao m "
        SqlText = SqlText & "set m.ic_icms_pago='S' "
        SqlText = SqlText & "where m.sq_movimentacao= " & objGrid_Valor(grdMovimentcao, cnt_GridMovimentacao_Codigo)

        If Not DBExecutar(SqlText) Then GoTo Erro



        'CRIO A CONCILIAÇÃO
        SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO", False, ":CDCONCILMODAL", _
                                                                           ":CDFORN", _
                                                                           ":QTCONCIL", _
                                                                           ":VLCONCIL", _
                                                                           ":DSCONCIL", _
                                                                           ":SQCONCIL")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDCONCILMODAL", CdModalidadeConciliacao), _
                                   DBParametro_Montar("CDFORN", objGrid_Valor(grdMovimentcao, cnt_GridMovimentacao_CdFornecedor)), _
                                   DBParametro_Montar("QTCONCIL", 0), _
                                   DBParametro_Montar("VLCONCIL", VL_CONCILIACAO), _
                                   DBParametro_Montar("DSCONCIL", "Conciliação automatica pagamento ICMS", OracleClient.OracleType.VarChar, , 4000), _
                                   DBParametro_Montar("SQCONCIL", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        If DBTeveRetorno() Then
            sqConciliacao = DBRetorno(1)
        End If

        'AMARRO A CONCILIAÇÃO AO PAGAMENTO
        For iCont = 0 To grdPagamento.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdPagamento, cnt_GridPagamento_Selecionado, iCont) Then
                'DESAPLICO O PAGAMENTO
                If objGrid_Valor(grdPagamento, cnt_GridPagamento_ContratoPAF, iCont) <> 0 Then
                    If Math.Abs(CDbl(objGrid_Valor(grdPagamento, cnt_GridPagamento_ValorAplicacao, iCont))) = Math.Abs(CDbl(objGrid_Valor(grdPagamento, cnt_GridPagamento_Saldo, iCont))) Then
                        SqlText = "DELETE FROM SOF.PAG_CTR_PAF " & _
                            "WHERE CD_CONTRATO_PAF = " & objGrid_Valor(grdPagamento, cnt_GridPagamento_ContratoPAF, iCont) & " AND " & _
                            "SQ_PAGAMENTO = " & objGrid_Valor(grdPagamento, cnt_GridPagamento_Codigo, iCont) & " AND " & _
                            "SQ_PAG_CTR_PAF = " & objGrid_Valor(grdPagamento, cnt_GridPagamento_SqPagCtrPAF, iCont)

                        If Not DBExecutar(SqlText) Then GoTo Erro

                        'ATUALIZO O PAGAMENTO
                        SqlText = "update sof.pagamentos p "
                        SqlText = SqlText & " set p.ic_icms_pago='S' "
                        SqlText = SqlText & " where p.sq_pagamento= " & objGrid_Valor(grdPagamento, cnt_GridPagamento_Codigo, iCont)

                        If Not DBExecutar(SqlText) Then GoTo Erro
                    Else
                        SqlText = "UPDATE SOF.PAG_CTR_PAF " & _
                            "SET VL_FIXO = VL_FIXO - " & objGrid_Valor(grdPagamento, cnt_GridPagamento_ValorAplicacao, iCont) & ", " & _
                            "VL_A_FIXAR = VL_A_FIXAR - " & objGrid_Valor(grdPagamento, cnt_GridPagamento_ValorAplicacao, iCont) & " " & _
                            "WHERE CD_CONTRATO_PAF = " & objGrid_Valor(grdPagamento, cnt_GridPagamento_ContratoPAF, iCont) & " AND " & _
                            "SQ_PAGAMENTO = " & objGrid_Valor(grdPagamento, cnt_GridPagamento_Codigo, iCont) & " AND " & _
                            "SQ_PAG_CTR_PAF = " & objGrid_Valor(grdPagamento, cnt_GridPagamento_SqPagCtrPAF, iCont)

                        If Not DBExecutar(SqlText) Then GoTo Erro
                    End If
                End If

                SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO_PAG", False, ":SQCONCIL", _
                                                              ":SQPAG", _
                                                              ":VLAPLICACAO")

                If Not DBExecutar(SqlText, DBParametro_Montar("SQCONCIL", sqConciliacao), _
                                               DBParametro_Montar("SQPAG", objGrid_Valor(grdPagamento, cnt_GridPagamento_Codigo, iCont)), _
                                               DBParametro_Montar("VLAPLICACAO", objGrid_Valor(grdPagamento, cnt_GridPagamento_ValorAplicacao, iCont))) Then GoTo Erro


                'INCLUO REFERENCIA DA AMARRAÇÃO
                SqlText = "insert into sof.pag_amarracao_icms  (sq_pagamento, sq_movimentacao, vl_aplicacao, "
                SqlText = SqlText & "       sq_conciliacao, dt_criacao, no_user_criacao,dt_amarracao) values "
                SqlText = SqlText & " (" & objGrid_Valor(grdPagamento, cnt_GridPagamento_Codigo, iCont) & "," & objGrid_Valor(grdMovimentcao, cnt_GridMovimentacao_Codigo) & "," & ConvValorFormatoAmericano(objGrid_Valor(grdPagamento, cnt_GridPagamento_ValorAplicacao, iCont)) & ","
                SqlText = SqlText & sqConciliacao & ",sysdate,'" & sAcesso_UsuarioLogado & "','" & Date_to_Oracle(DataSistema) & "')"

                If Not DBExecutar(SqlText) Then GoTo Erro
            End If
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        ExecutaConsultaMovimentacao()
        Exit Sub
Erro:
        TratarErro()
    End Sub
End Class