Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmAplicacaoPagamento
    Const cnt_GridPagCons_DataPagamento As Integer = 0
    Const cnt_GridPagCons_DataAplicacao As Integer = 1
    Const cnt_GridPagCons_Descricao As Integer = 2
    Const cnt_GridPagCons_ValorAplicado As Integer = 3
    Const cnt_GridPagCons_TipoPagamento As Integer = 4
    Const cnt_GridPagCons_ValorAberto As Integer = 5
    Const cnt_GridPagCons_SqPagamento As Integer = 6
    Const cnt_GridPagCons_SqPagamentoCtrPAF As Integer = 7
    Const cnt_GridPagCons_SqPagamentoNeg As Integer = 8
    Const cnt_GridPagCons_SqPagamentoCtrFixo As Integer = 9
    Const cnt_GridPagCons_SqCtrPAF As Integer = 10
    Const cnt_GridPagCons_SqNeg As Integer = 11
    Const cnt_GridPagCons_SqCtrFixo As Integer = 12

    Const cnt_GridPagCad_Selecao As Integer = 0
    Const cnt_GridCadContratoPAF_ValorAplicado As Integer = 1
    Const cnt_GridPagCad_Valor_Pagamento As Integer = 2
    Const cnt_GridPagCad_DataPagamento As Integer = 3
    Const cnt_GridPagCad_TipoPagamento As Integer = 4
    Const cnt_GridPagCad_SqPagamento As Integer = 5
    Const cnt_GridPagCad_SqPagNeg As Integer = 6
    Const cnt_GridPagCad_SqPagCtrPAF As Integer = 7

    Const cnt_SEC_Tela As String = "Transacao_Contratos_AplicacaoPagamento"

    Dim oDSConsContratoPAF As New UltraWinDataSource.UltraDataSource
    Dim oDSConsNegociacao As New UltraWinDataSource.UltraDataSource
    Dim oDSConsContratoFixo As New UltraWinDataSource.UltraDataSource
    Dim oDSCadContratoPAF As New UltraWinDataSource.UltraDataSource
    Dim oDSCadNegociacao As New UltraWinDataSource.UltraDataSource
    Dim oDSCadContratoFixo As New UltraWinDataSource.UltraDataSource
    Dim mCdContratoPAF As Long
    Dim mSqNegociacao As Integer
    Dim mSqCtrFix As Integer
    Dim CdFilialOrigem As Integer
    Dim CdFornecedor As Integer
    Dim IcValida As Boolean

    Dim SQ_NEGOFICAO_CONTRATO_FIXO As Integer

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmAplicacaoPagamento_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        AjustarTela()
    End Sub

    Private Sub frmAplicacaoPagamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Pesq_ContratoPAF
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_ContratoPAF
        End With

        objGrid_Inicializar(grdConsultaContratoPAF, , oDSConsContratoPAF, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Data Pagamento", 100)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Data Aplicação", 100)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Descrição", 240)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Valor Aplicado", 120, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Tipo Pagamento", 240)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Saldo a Aplicar", 120, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Código Pagamento", 130)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Seq Pagamento Contrato PAF", 0)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Seq Pagamento Negociacao", 0)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Seq Pagamento Contrato Fixo", 0)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Seq Contrato PAF", 100)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Seq Negociacao", 0)
        objGrid_Coluna_Add(grdConsultaContratoPAF, "Seq Contrato Fixo", 0)
        objGrid_ExibirTotal(grdConsultaContratoPAF, New Integer() {cnt_GridPagCons_ValorAplicado, _
                                                                   cnt_GridPagCons_ValorAberto})

        objGrid_Inicializar(grdConsultaNegociacao, , oDSConsNegociacao, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Data Pagamento", 100)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Data Aplicação", 100)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Descrição", 240)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Valor Aplicado", 120, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Tipo Pagamento", 240)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Saldo a Aplicar", 120, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Código Pagamento", 130)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Seq Pagamento Contrato PAF", 0)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Seq Pagamento Negociacao", 0)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Seq Pagamento Contrato Fixo", 0)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Seq Contrato PAF", 0)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Seq Negociacao", 0)
        objGrid_Coluna_Add(grdConsultaNegociacao, "Seq Contrato Fixo", 0)
        objGrid_ExibirTotal(grdConsultaNegociacao, New Integer() {cnt_GridPagCons_ValorAplicado, _
                                                                  cnt_GridPagCons_ValorAberto})

        objGrid_Inicializar(grdConsultaContratoFixo, , oDSConsContratoFixo, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Data Pagamento", 100)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Data Aplicação", 100)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Descrição", 240)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Valor Aplicado", 120, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Tipo Pagamento", 240)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Saldo a Aplicar", 0, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Código Pagamento", 130)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Seq Pagamento Contrato PAF", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Seq Pagamento Negociacao", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Seq Pagamento Contrato Fixo", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Seq Contrato PAF", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Seq Negociacao", 0)
        objGrid_Coluna_Add(grdConsultaContratoFixo, "Seq Contrato Fixo", 0)
        objGrid_ExibirTotal(grdConsultaContratoFixo, New Integer() {cnt_GridPagCons_ValorAplicado, _
                                                                    cnt_GridPagCons_ValorAberto})

        objGrid_Inicializar(grdCadastraContratoPAF, , oDSCadContratoPAF, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdCadastraContratoPAF, " ", 30, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Valor Aplicado", 100, , True, , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Saldo", 120, , False, , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Data Pagamento", 120, , False)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Tipo Pagamento", 240, , False)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Código Pagamento", 0, , False)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Seq PagNeg", 0, , False)
        objGrid_Coluna_Add(grdCadastraContratoPAF, "Seq PagCtrPAF", 0, , False)

        objGrid_Inicializar(grdCadastraNegociacao, , oDSCadNegociacao, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdCadastraNegociacao, " ", 30, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Valor Aplicado", 100, , True, , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Saldo", 120, , False, , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Data Pagamento", 120, , False)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Tipo Pagamento", 240, , False)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Código Pagamento", 0, , False)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Seq PagNeg", 0, , False)
        objGrid_Coluna_Add(grdCadastraNegociacao, "Seq PagCtrPAF", 0, , False)

        objGrid_Inicializar(grdCadastraContratoFixo, , oDSCadContratoFixo, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdCadastraContratoFixo, " ", 30, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Valor Aplicado", 100, , True, , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Saldo", 120, , False, , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Data Pagamento", 120, , False)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Tipo Pagamento", 240, , False)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Código Pagamento", 0, , False)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Seq PagNeg", 0, , False)
        objGrid_Coluna_Add(grdCadastraContratoFixo, "Seq PagCtrPAF", 0, , False)

        SEC_ValidarBotao(cmdGravar_ContratoPAF, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdGravar_Negociacao, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdGravar_ContratoFixo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdQuebrar_ContratoPAF, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdQuebrar_Negociacao, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdExcluir_ContratoPAF, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao(cmdExcluir_Negociacao, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
        SEC_ValidarBotao(cmdExcluir_ContratoFixo, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)

        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cboNegocicao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNegocicao.SelectedIndexChanged
        ValidarNegociacao()
    End Sub

    Private Sub ValidarNegociacao()
        Dim SqlText As String
        Dim oData As DataTable
        Dim VlSaldo As Double
        Dim ComboContratoFixo As Integer = -1

        txtSaldoValorNegociacao.Value = 0

        chkAplicarContratoFixo.Checked = False
        chkAplicarContratoFixo.Enabled = False

        If Not ComboBox_LinhaSelecionada(cboNegocicao) Then Exit Sub

        If ComboBox_LinhaSelecionada(cboContratoFixo) Then
            ComboContratoFixo = cboContratoFixo.SelectedValue
        End If

        SqlText = "SELECT SQ_CONTRATO_FIXO," & _
                         "SQ_CONTRATO_FIXO AS NO_CONTRATO_FIXO" & _
                  " FROM SOF.CONTRATO_FIXO" & _
                  " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue & _
                    " AND IC_STATUS NOT IN ('E')"
        DBCarregarComboBox(cboContratoFixo, SqlText, False)

        ComboBox_Possicionar(cboContratoFixo, ComboContratoFixo)

        IcValida = False

        SqlText = "SELECT QT_A_FIXAR," & _
                         "VL_PAG_FIXO " & _
                  " FROM SOF.NEGOCIACAO " & _
                  " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue
        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            Msg_Mensagem("Negociação não encontrada na base de dados.")
            txtSaldoValorNegociacao.Value = 0
            Exit Sub
        End If

        If oData.Rows(0).Item("QT_A_FIXAR") = 0 Then
            IcValida = True
            VlSaldo = 0 - oData.Rows(0).Item("VL_PAG_FIXO")

            SqlText = "SELECT ROUND(SUM(SOF.FC_SALDO_CTR_FIX(CF.CD_CONTRATO_PAF,CF.SQ_NEGOCIACAO, CF.SQ_CONTRATO_FIXO)), 2) VL_SALDO," & _
                             "COUNT(CF.SQ_CONTRATO_FIXO) AS QT," & _
                             "MAX(CF.SQ_CONTRATO_FIXO) SQ_CONTRATO_FIXO" & _
                      " FROM SOF.CONTRATO_FIXO CF " & _
                      " WHERE CF.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                        " AND CF.SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue
            oData = DBQuery(SqlText)

            If objDataTable_Vazio(oData) Then
                txtSaldoValorNegociacao.Value = 0
            Else
                txtSaldoValorNegociacao.Value = VlSaldo + CDbl(NVL(oData.Rows(0).Item("VL_SALDO"), 0))

                If oData.Rows(0).Item("QT") = 1 Then
                    chkAplicarContratoFixo.Checked = True
                    chkAplicarContratoFixo.Enabled = True
                    SQ_NEGOFICAO_CONTRATO_FIXO = oData.Rows(0).Item("SQ_CONTRATO_FIXO")
                End If
            End If
        End If

        If IcValida Then
            lblValorTotalAplicadoNegociacao.Visible = True
            txtSaldoValorNegociacao.Visible = True
        Else
            lblValorTotalAplicadoNegociacao.Visible = False
            txtSaldoValorNegociacao.Visible = False
        End If

        ExecutaConsulta()
    End Sub

    Private Sub ExecutaConsulta()
        Select Case tbsGeral.SelectedTab.Index
            Case 0
                ExecutaConsultaContratoPAF()
                ExecutaConsultaAplicacaoContratoPAF()
            Case 1
                ExecutaConsultaNegocicao()
                ExecutaConsultaAplicacaoNegociacao()
            Case 2
                ExecutaConsultaContratoFixo()
                ExecutaConsultaAplicacaoContratoFixo()
        End Select
    End Sub

    Private Sub ExecutaConsultaContratoFixo()
        Dim SqlText As String
        Dim oData As DataTable

        oDSConsContratoFixo.Rows.Clear()
        txtSaldoValorContratoFixo.Value = 0

        If Pesq_ContratoPAF.Codigo = 0 Then
            Pesq_ContratoPAF.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboNegocicao) Then
            cboNegocicao.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then
            cboContratoFixo.Focus()
            Exit Sub
        End If

        SqlText = "SELECT P.DT_PAGAMENTO, PNCF.DT_FIXACAO, P.DS_DESCRICAO, PNCF.VL_FIXO, "
        SqlText = SqlText & "       TP.NO_TIPO_PAGAMENTO, 0 VL_A_FIXAR,PNCF.SQ_PAGAMENTO, PNCF.SQ_PAG_CTR_PAF, "
        SqlText = SqlText & "       PNCF.SQ_PAG_NEG, PNCF.SQ_PAG_NEG_CTR_FIX, PNCF.CD_CONTRATO_PAF, "
        SqlText = SqlText & "       PNCF.SQ_NEGOCIACAO, PNCF.SQ_CONTRATO_FIXO "
        SqlText = SqlText & "  FROM SOF.PAG_NEG_CTR_FIX PNCF, SOF.PAGAMENTOS P, SOF.TIPO_PAGAMENTO TP "
        SqlText = SqlText & " WHERE TP.CD_TIPO_PAGAMENTO = P.CD_TIPO_PAGAMENTO "
        SqlText = SqlText & "   AND P.SQ_PAGAMENTO = PNCF.SQ_PAGAMENTO "
        SqlText = SqlText & "   AND PNCF.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo
        SqlText = SqlText & "   AND PNCF.SQ_NEGOCIACAO =  " & cboNegocicao.SelectedValue
        SqlText = SqlText & "   AND PNCF.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue

        'ordenador por data de pagamento para que sejam aplicados primeiro os contratos mais antigos
        SqlText = SqlText & " order by p.dt_pagamento desc "

        objGrid_Carregar(grdConsultaContratoFixo, SqlText, New Integer() {cnt_GridPagCons_DataPagamento, _
                                                                        cnt_GridPagCons_DataAplicacao, _
                                                                        cnt_GridPagCons_Descricao, _
                                                                        cnt_GridPagCons_ValorAplicado, _
                                                                        cnt_GridPagCons_TipoPagamento, _
                                                                        cnt_GridPagCons_ValorAberto, _
                                                                        cnt_GridPagCons_SqPagamento, _
                                                                        cnt_GridPagCons_SqPagamentoCtrPAF, _
                                                                        cnt_GridPagCons_SqPagamentoNeg, _
                                                                        cnt_GridPagCons_SqPagamentoCtrFixo, _
                                                                        cnt_GridPagCons_SqCtrPAF, _
                                                                        cnt_GridPagCons_SqNeg, _
                                                                        cnt_GridPagCons_SqCtrFixo})

        SqlText = "SELECT (SOF.FC_SALDO_CTR_FIX(CF.CD_CONTRATO_PAF, CF.SQ_NEGOCIACAO, CF.SQ_CONTRATO_FIXO ) - CF.VL_PAG_FIXO) VL_SALDO " & _
                  " FROM SOF.CONTRATO_FIXO CF " & _
                  " WHERE CF.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND CF.SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue & _
                    " AND CF.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue
        oData = DBQuery(SqlText)

        If oData.Rows.Count = 0 Then
            txtSaldoValorContratoFixo.Value = 0
        Else
            txtSaldoValorContratoFixo.Value = oData.Rows(0).Item("VL_SALDO")
        End If
    End Sub

    Private Sub ExecutaConsultaAplicacaoContratoFixo()
        Dim SqlText As String

        oDSCadContratoFixo.Rows.Clear()
        txtValorTotalAplicadoContratoFixo.Value = 0
        txtValorAposAplicacaoContratoFixo.Value = 0

        If Pesq_ContratoPAF.Codigo = 0 Then
            Pesq_ContratoPAF.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboNegocicao) Then
            cboNegocicao.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then
            cboContratoFixo.Focus()
            Exit Sub
        End If

        mCdContratoPAF = Pesq_ContratoPAF.Codigo
        mSqNegociacao = cboNegocicao.SelectedValue
        mSqCtrFix = cboContratoFixo.SelectedValue

        SqlText = "SELECT   0 selecao, null vl_aplicado,PN.VL_A_FIXAR, P.DT_PAGAMENTO, TP.NO_TIPO_PAGAMENTO, PN.SQ_PAGAMENTO, "
        SqlText = SqlText & "         PN.SQ_PAG_NEG, PN.SQ_PAG_CTR_PAF "
        SqlText = SqlText & "    FROM SOF.PAG_NEG PN, SOF.PAGAMENTOS P, SOF.TIPO_PAGAMENTO TP "
        SqlText = SqlText & "   WHERE TP.CD_TIPO_PAGAMENTO = P.CD_TIPO_PAGAMENTO "
        SqlText = SqlText & "     AND P.SQ_PAGAMENTO = PN.SQ_PAGAMENTO "
        SqlText = SqlText & "     AND PN.VL_A_FIXAR <> 0 "
        SqlText = SqlText & "     AND PN.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo
        SqlText = SqlText & "     AND PN.SQ_NEGOCIACAO =  " & cboNegocicao.SelectedValue
        SqlText = SqlText & "ORDER BY PN.DT_CRIACAO "

        objGrid_Carregar(grdCadastraContratoFixo, SqlText, New Integer() {cnt_GridPagCad_Selecao, _
                                                                          cnt_GridCadContratoPAF_ValorAplicado, _
                                                                          cnt_GridPagCad_Valor_Pagamento, _
                                                                          cnt_GridPagCad_DataPagamento, _
                                                                          cnt_GridPagCad_TipoPagamento, _
                                                                          cnt_GridPagCad_SqPagamento, _
                                                                          cnt_GridPagCad_SqPagNeg, _
                                                                          cnt_GridPagCad_SqPagCtrPAF})

        txtValorTotalAplicadoContratoFixo.Value = objGrid_CalcularTotalColuna(grdConsultaContratoFixo, cnt_GridPagCons_ValorAplicado)
        txtValorAposAplicacaoContratoFixo.Value = txtValorTotalAplicadoContratoFixo.Value
    End Sub

    Private Sub ExecutaConsultaAplicacaoNegociacao()
        Dim SqlText As String

        oDSCadNegociacao.Rows.Clear()

        If Pesq_ContratoPAF.Codigo = 0 Then
            Pesq_ContratoPAF.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboNegocicao) Then
            cboNegocicao.Focus()
            Exit Sub
        End If

        mCdContratoPAF = Pesq_ContratoPAF.Codigo
        mSqNegociacao = cboNegocicao.SelectedValue

        SqlText = "SELECT 0 selecao, NULL vl_aplicado, pcp.vl_a_fixar, p.dt_pagamento, tp.no_tipo_pagamento, "
        SqlText = SqlText & "       pcp.sq_pagamento, -1 sq_pag_neg, pcp.sq_pag_ctr_paf "
        SqlText = SqlText & "  FROM sof.pag_ctr_paf pcp, sof.pagamentos p, sof.tipo_pagamento tp "
        SqlText = SqlText & " WHERE p.sq_pagamento = pcp.sq_pagamento "
        SqlText = SqlText & "   AND tp.cd_tipo_pagamento = p.cd_tipo_pagamento "
        SqlText = SqlText & "   AND pcp.vl_a_fixar <> 0 "
        SqlText = SqlText & "   AND pcp.sq_confissao_divida IS NULL "
        SqlText = SqlText & "   AND pcp.cd_contrato_paf = " & Pesq_ContratoPAF.Codigo

        objGrid_Carregar(grdCadastraNegociacao, SqlText, New Integer() {cnt_GridPagCad_Selecao, _
                                                                            cnt_GridCadContratoPAF_ValorAplicado, _
                                                                            cnt_GridPagCad_Valor_Pagamento, _
                                                                            cnt_GridPagCad_DataPagamento, _
                                                                            cnt_GridPagCad_TipoPagamento, _
                                                                            cnt_GridPagCad_SqPagamento, _
                                                                            cnt_GridPagCad_SqPagNeg, _
                                                                            cnt_GridPagCad_SqPagCtrPAF})
    End Sub

    Private Sub ExecutaConsultaAplicacaoContratoPAF()
        Dim SqlText As String

        oDSCadContratoPAF.Rows.Clear()

        If Pesq_ContratoPAF.Codigo = 0 Then
            Pesq_ContratoPAF.Focus()
            Exit Sub
        End If

        mCdContratoPAF = Pesq_ContratoPAF.Codigo

        SqlText = "SELECT 0 selecao, NULL vl_aplicado, p.vl_a_fixar, p.dt_pagamento, tp.no_tipo_pagamento, "
        SqlText = SqlText & "       p.sq_pagamento, -1 sq_pag_neg, -1 sq_pag_ctr_paf "
        SqlText = SqlText & "FROM SOF.pagamentos p, SOF.tipo_pagamento tp "
        SqlText = SqlText & "WHERE tp.cd_tipo_pagamento = p.cd_tipo_pagamento AND "
        SqlText = SqlText & "p.vl_a_fixar <> 0 AND "
        SqlText = SqlText & "p.cd_fornecedor = " & CdFornecedor

        objGrid_Carregar(grdCadastraContratoPAF, SqlText, New Integer() {cnt_GridPagCad_Selecao, _
                                                                         cnt_GridCadContratoPAF_ValorAplicado, _
                                                                         cnt_GridPagCad_Valor_Pagamento, _
                                                                         cnt_GridPagCad_DataPagamento, _
                                                                         cnt_GridPagCad_TipoPagamento, _
                                                                         cnt_GridPagCad_SqPagamento, _
                                                                         cnt_GridPagCad_SqPagNeg, _
                                                                         cnt_GridPagCad_SqPagCtrPAF})
    End Sub

    Private Sub ExecutaConsultaNegocicao()
        Dim SqlText As String

        oDSConsNegociacao.Rows.Clear()
        txtValorTotalAplicadoNegociacao.Value = 0
        txtValorAposAplicacaoNegociacao.Value = 0

        If Pesq_ContratoPAF.Codigo = 0 Then
            Pesq_ContratoPAF.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboNegocicao) Then
            cboNegocicao.Focus()
            Exit Sub
        End If

        SqlText = "SELECT P.DT_PAGAMENTO, PN.DT_FIXACAO, P.DS_DESCRICAO, PN.VL_FIXO, "
        SqlText = SqlText & "       TP.NO_TIPO_PAGAMENTO, PN.VL_A_FIXAR, PN.SQ_PAGAMENTO, "
        SqlText = SqlText & "       PN.SQ_PAG_CTR_PAF, PN.SQ_PAG_NEG, -1 SQ_PAG_NEG_CTR_FIX, "
        SqlText = SqlText & "       PN.CD_CONTRATO_PAF, PN.SQ_NEGOCIACAO, -1 SQ_CONTRATO_FIXO "
        SqlText = SqlText & "  FROM SOF.PAG_NEG PN, SOF.PAGAMENTOS P, SOF.TIPO_PAGAMENTO TP "
        SqlText = SqlText & " WHERE TP.CD_TIPO_PAGAMENTO = P.CD_TIPO_PAGAMENTO "
        SqlText = SqlText & "   AND P.SQ_PAGAMENTO = PN.SQ_PAGAMENTO "
        SqlText = SqlText & "   AND PN.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo
        SqlText = SqlText & "   AND PN.SQ_NEGOCIACAO =" & cboNegocicao.SelectedValue
        SqlText = SqlText & " ORDER BY P.DT_PAGAMENTO DESC "

        objGrid_Carregar(grdConsultaNegociacao, SqlText, New Integer() {cnt_GridPagCons_DataPagamento, _
                                                                        cnt_GridPagCons_DataAplicacao, _
                                                                        cnt_GridPagCons_Descricao, _
                                                                        cnt_GridPagCons_ValorAplicado, _
                                                                        cnt_GridPagCons_TipoPagamento, _
                                                                        cnt_GridPagCons_ValorAberto, _
                                                                        cnt_GridPagCons_SqPagamento, _
                                                                        cnt_GridPagCons_SqPagamentoCtrPAF, _
                                                                        cnt_GridPagCons_SqPagamentoNeg, _
                                                                        cnt_GridPagCons_SqPagamentoCtrFixo, _
                                                                        cnt_GridPagCons_SqCtrPAF, _
                                                                        cnt_GridPagCons_SqNeg, _
                                                                        cnt_GridPagCons_SqCtrFixo})

        txtValorTotalAplicadoNegociacao.Value = objGrid_CalcularTotalColuna(grdConsultaNegociacao, cnt_GridPagCons_ValorAplicado)
        txtValorAposAplicacaoNegociacao.Value = txtValorTotalAplicadoNegociacao.Value
    End Sub

    Private Sub ExecutaConsultaContratoPAF()
        Dim SqlText As String

        oDSConsContratoPAF.Rows.Clear()
        txtValorTotalAplicadoContratoPAF.Value = 0
        txtValorAposAplicacaoContratoPAF.Value = 0

        If Pesq_ContratoPAF.Codigo = 0 Then
            Pesq_ContratoPAF.Focus()
            Exit Sub
        End If

        SqlText = "SELECT P.DT_PAGAMENTO, PCP.DT_FIXACAO, P.DS_DESCRICAO, PCP.VL_FIXO, "
        SqlText = SqlText & "       TP.NO_TIPO_PAGAMENTO, PCP.VL_A_FIXAR, PCP.SQ_PAGAMENTO, "
        SqlText = SqlText & "       PCP.SQ_PAG_CTR_PAF, -1 SQ_PAG_NEG, -1 SQ_PAG_NEG_CTR_FIX, "
        SqlText = SqlText & "       PCP.CD_CONTRATO_PAF, -1 SQ_NEGOCIACAO, -1 SQ_CONTRATO_FIXO "
        SqlText = SqlText & "  FROM SOF.PAG_CTR_PAF PCP, "
        SqlText = SqlText & "       SOF.PAGAMENTOS P, "
        SqlText = SqlText & "       SOF.TIPO_PAGAMENTO TP, "
        SqlText = SqlText & "       SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & "       SOF.TIPO_CONTRATO_PAF TCP "
        SqlText = SqlText & " WHERE P.SQ_PAGAMENTO = PCP.SQ_PAGAMENTO "
        SqlText = SqlText & "   AND TP.CD_TIPO_PAGAMENTO = P.CD_TIPO_PAGAMENTO "
        SqlText = SqlText & "   AND PCP.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF "
        SqlText = SqlText & "   AND CP.CD_TIPO_CONTRATO_PAF = TCP.CD_TIPO_CONTRATO_PAF "
        SqlText = SqlText & "   AND PCP.CD_CONTRATO_PAF =  " & Pesq_ContratoPAF.Codigo
        SqlText = SqlText & " order by p.dt_pagamento desc "

        objGrid_Carregar(grdConsultaContratoPAF, SqlText, New Integer() {cnt_GridPagCons_DataPagamento, _
                                                                         cnt_GridPagCons_DataAplicacao, _
                                                                         cnt_GridPagCons_Descricao, _
                                                                         cnt_GridPagCons_ValorAplicado, _
                                                                         cnt_GridPagCons_TipoPagamento, _
                                                                         cnt_GridPagCons_ValorAberto, _
                                                                         cnt_GridPagCons_SqPagamento, _
                                                                         cnt_GridPagCons_SqPagamentoCtrPAF, _
                                                                         cnt_GridPagCons_SqPagamentoNeg, _
                                                                         cnt_GridPagCons_SqPagamentoCtrFixo, _
                                                                         cnt_GridPagCons_SqCtrPAF, _
                                                                         cnt_GridPagCons_SqNeg, _
                                                                         cnt_GridPagCons_SqCtrFixo})

        txtValorTotalAplicadoContratoPAF.Value = objGrid_CalcularTotalColuna(grdConsultaContratoPAF, cnt_GridPagCons_ValorAplicado)
        txtValorAposAplicacaoContratoPAF.Value = txtValorTotalAplicadoContratoPAF.Value
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cboContratoFixo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContratoFixo.SelectedIndexChanged
        ExecutaConsulta()
    End Sub

    Private Sub TabControl_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tbsGeral.SelectedTabChanged
        ExecutaConsulta()
        AjustarTela()
    End Sub

    Private Sub cmdExcluir_ContratoFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir_ContratoFixo.Click
        If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ExcluirQuebrarAplicacaoContratoFixoFechado) Then
            If Not Verifica_Situacao_Contrato(Pesq_ContratoPAF.Codigo, cboNegocicao.SelectedValue, cboContratoFixo.SelectedValue) Then Exit Sub
        End If

        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdConsultaContratoFixo) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        SqlText = "select count(*) as QT FROM SOF.CTRPAF_NEG_CTRFIX_MOV_DQ " & _
                  "WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqPagamento)

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Essa aplicação corresponde a um desagio financeiro.")
            Exit Sub
        End If

        SqlText = "select count(*) as QT FROM SOF.PAGAMENTOS_JUROS_AUTO_CTR_FIX " & _
                  "WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqPagamento)

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Essa aplicação corresponde a uma cobrança de juros.")
            Exit Sub
        End If

        SqlText = "SELECT pncf.sq_confissao_divida "
        SqlText = SqlText & "  FROM sof.pag_neg_ctr_fix pncf "
        SqlText = SqlText & " WHERE pncf.cd_contrato_paf =  " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqCtrPAF)
        SqlText = SqlText & "   AND pncf.sq_negociacao = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqNeg)
        SqlText = SqlText & "   AND pncf.sq_contrato_fixo =  " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqCtrFixo)

        If DBQuery_ValorUnico(SqlText, -1) <> -1 Then
            Msg_Mensagem("Essa aplicação pertence a uma recuperação de credito.")
            Exit Sub
        End If

        If Msg_Perguntar("Elimina a aplicação ?") = False Then Exit Sub

        DBUsarTransacao = True

        If Not Elimina_Pag_Ctr_Fix(objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqCtrPAF), _
                                   objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqNeg), _
                                   objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqCtrFixo), _
                                   objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqPagamento), _
                                   objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqPagamentoCtrPAF), _
                                   objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqPagamentoNeg), _
                                   objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqPagamentoCtrFixo)) Then GoTo Erro

        If Not DBExecutarTransacao() Then GoTo Erro

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdExcluir_ContratoPAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir_ContratoPAF.Click
        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdConsultaContratoPAF) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        If objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_ValorAberto) <> objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_ValorAplicado) Then
            Msg_Mensagem("Favor eliminar primeiro as aplicações feitas nas negociações.")
            Exit Sub
        End If

        SqlText = "SELECT TC.IC_ADIANTAMENTO" & _
                  " FROM SOF.CONTRATO_PAF C," & _
                        "SOF.TIPO_CONTRATO_PAF TC" & _
                  " WHERE C.CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_SqCtrPAF) & _
                    " AND C.CD_TIPO_CONTRATO_PAF = TC.CD_TIPO_CONTRATO_PAF "

        If DBQuery_ValorUnico(SqlText) = "S" And objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_DataPagamento) <> DataSistema() Then
            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_QuebrarAplicacaoAdiantamentDataAnteriorContratoPAF) Then
                Msg_Mensagem("Essa aplicação esta aplicada em um contrato PAF com adiantamento e foi feito numa data diferente da atual.")
                Exit Sub
            Else
                If Not Msg_Perguntar("Essa aplicação está aplicada em um contrato PAF com adiantamento e foi feito numa data diferente da atual." & _
                                     vbCrLf & "Deseja quebrar ?" & vbCrLf & _
                                     "Não se esqueça voce pode deixar de cobrar Juros e não vai haver histórico da quebra, para isso utilize o estorno.") Then Exit Sub
            End If
        End If

        SqlText = "SELECT PCP.SQ_CONFISSAO_DIVIDA" & _
                  " FROM SOF.PAG_CTR_PAF PCP" & _
                  " WHERE PCP.CD_CONTRATO_PAF =  " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_SqCtrPAF) & _
                    " AND SQ_CONFISSAO_DIVIDA IS NOT NULL"
        If DBQuery_ValorUnico(SqlText, -1) <> -1 Then
            Msg_Mensagem("Essa aplicação pertence a uma recuperação de credito.")
            Exit Sub
        End If

        If Msg_Perguntar("Elimina a aplicação ?") = False Then Exit Sub

        SqlText = "DELETE FROM SOF.PAG_CTR_PAF" & _
                  " WHERE CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_SqCtrPAF) & _
                    " AND SQ_PAGAMENTO = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_SqPagamento) & _
                    " AND SQ_PAG_CTR_PAF = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_SqPagamentoCtrPAF)
        If Not DBExecutar(SqlText) Then GoTo Erro

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdExcluir_Negociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir_Negociacao.Click
        If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ExcluirQuebrarAplicacaoNegociacaoFechada) Then
            If Not Verifica_Situacao_Contrato(Pesq_ContratoPAF.Codigo, cboNegocicao.SelectedValue, -1) Then Exit Sub
        End If

        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdConsultaNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        If objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_ValorAberto) = 0 Then
            Msg_Mensagem("Favor eliminar primeiro as aplicações feitas nos contratos fixo.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) AS QT FROM SOF.CTRPAF_NEG_CTRFIX_MOV_DQ" & _
                  " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamento)

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Essa aplicação corresponde a um desagio financeiro.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) AS QT FROM SOF.PAGAMENTO_DESAGIO_AUTOMATICO" & _
                  " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamento)

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Essa aplicação corresponde a um desagio financeiro.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) AS QT FROM SOF.PAGAMENTO_JUROS_AUTOMATICO" & _
                  " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamento)

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Essa aplicação corresponde a uma cobrança de juros.")
            Exit Sub
        End If

        SqlText = "SELECT PN.SQ_CONFISSAO_DIVIDA  "
        SqlText = SqlText & "  FROM SOF.PAG_NEG PN "
        SqlText = SqlText & " WHERE PN.CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqCtrPAF)
        SqlText = SqlText & "   AND PN.SQ_NEGOCIACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqNeg)

        If DBQuery_ValorUnico(SqlText, -1) <> -1 Then
            Msg_Mensagem("Essa aplicação pertence a uma recuperação de credito.")
            Exit Sub
        End If

        If Msg_Perguntar("Elimina a aplicação ?") = False Then Exit Sub

        DBUsarTransacao = True

        If Not Elimina_Pag_neg(objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqCtrPAF), _
                               objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqNeg), _
                               objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamento), _
                               objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamentoCtrPAF), _
                               objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamentoNeg)) Then GoTo Erro

        If Not DBExecutarTransacao() Then GoTo Erro

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdUsuario_Negociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario_Negociacao.Click
        If objGrid_LinhaSelecionada(grdConsultaNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "PAG_NEG", "CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqCtrPAF) & " AND " & _
                                                  "SQ_NEGOCIACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqNeg))
    End Sub

    Private Sub cmdUsuario_ContratoFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario_ContratoFixo.Click
        If objGrid_LinhaSelecionada(grdConsultaContratoFixo) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "PAG_NEG_CTR_FIX", "CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqCtrPAF) & " AND " & _
                                                    "SQ_NEGOCIACAO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqNeg) & " AND " & _
                                                    "SQ_CONTRATO_FIXO = " & objGrid_Valor(grdConsultaContratoFixo, cnt_GridPagCons_SqCtrFixo))
    End Sub

    Private Sub cmdUsuario_ContratoPAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario_ContratoPAF.Click
        If objGrid_LinhaSelecionada(grdConsultaContratoPAF) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "PAG_CTR_PAF", "CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_SqCtrPAF))
    End Sub

    Private Sub Pesq_ContratoPAF_AlterouRegistro() Handles Pesq_ContratoPAF.AlterouRegistro
        Dim SqlText As String
        Dim oData As DataTable

        oDSConsContratoPAF.Rows.Clear()
        oDSConsNegociacao.Rows.Clear()
        oDSConsContratoFixo.Rows.Clear()
        oDSCadContratoPAF.Rows.Clear()
        oDSCadNegociacao.Rows.Clear()
        oDSCadContratoFixo.Rows.Clear()

        txtSaldoValorContratoFixo.Value = 0
        txtSaldoValorNegociacao.Value = 0
        txtValorTotalAplicadoContratoFixo.Value = 0
        txtValorTotalAplicadoContratoPAF.Value = 0
        txtValorAposAplicacaoContratoPAF.Value = 0
        txtValorTotalAplicadoNegociacao.Value = 0
        txtValorAposAplicacaoNegociacao.Value = 0

        If Pesq_ContratoPAF.Codigo = 0 Then Exit Sub

        SqlText = "SELECT F.NO_RAZAO_SOCIAL," & _
                         "CP.CD_FORNECEDOR," & _
                         "F.CD_FILIAL_ORIGEM," & _
                         "CP.IC_CALCULA_JUROS," & _
                         "CP.IC_JUROS_NEG_REC," & _
                         "CP.IC_STATUS" & _
                  " FROM SOF.FORNECEDOR F," & _
                        "SOF.CONTRATO_PAF CP " & _
                  " WHERE CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND CP.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo
        oData = DBQuery(SqlText)

        If oData.Rows.Count = 0 Then
            Msg_Mensagem("Contrato não encontrado")
            GoTo Limpar
        Else
            If oData.Rows(0).Item("IC_STATUS") = "E" Then
                Msg_Mensagem("Este contrato já está eliminado")
                GoTo Limpar
            ElseIf oData.Rows(0).Item("IC_STATUS") = "C" Then
                Msg_Mensagem("Este contrato está cancelado")
                GoTo Limpar
            End If
        End If

        CdFornecedor = oData.Rows(0).Item("cd_fornecedor")

        SqlText = "SELECT COUNT(*) QT FROM SOF.CONFISSAO_DIVIDA_ATIVO_VENDA WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Esse contrato é uma liquidação de uma recuperação de credito.")
            GoTo Limpar
        End If

        SqlText = "SELECT NO_RAZAO_SOCIAL," & _
                         "CD_FILIAL_ORIGEM " & _
                  " FROM SOF.FORNECEDOR " & _
                  " WHERE CD_FORNECEDOR=" & oData.Rows(0).Item("CD_FORNECEDOR") & _
                    " AND CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            Msg_Mensagem("Este fornecedor não pertence a nenhuma das filiais liberadas para o seu acesso")
            GoTo Limpar
        End If

        CdFilialOrigem = oData.Rows(0).Item("CD_FILIAL_ORIGEM")

        SqlText = "SELECT SQ_NEGOCIACAO," & _
                         "SQ_NEGOCIACAO AS NO_NEGOCIACAO" & _
                  " FROM SOF.NEGOCIACAO" & _
                  " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND IC_STATUS NOT IN ('E')"
        DBCarregarComboBox(cboNegocicao, SqlText, False)

        ExecutaConsulta()

        Exit Sub

Limpar:
        Pesq_ContratoPAF.Codigo = 0
    End Sub

    Private Sub cmdGravar_ContratoPAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_ContratoPAF.Click
        Dim iCont As Integer
        Dim SqlText As String
        Dim ExiteSelecionado As Boolean

        ExiteSelecionado = False

        For iCont = 0 To grdCadastraContratoPAF.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraContratoPAF, cnt_GridPagCad_Selecao, iCont) Then
                ExiteSelecionado = True
            End If
        Next

        If ExiteSelecionado = False Then
            Msg_Mensagem("Favor selecionar um pagamento antes.")
            Exit Sub
        End If

        DBUsarTransacao = True

        For iCont = 0 To grdCadastraContratoPAF.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraContratoPAF, cnt_GridPagCad_Selecao, iCont) Then

                SqlText = DBMontar_SP("SOF.SP_INCLUI_PAG_CTR_PAF", False, ":CDCTRPAF", _
                                                                          ":SQPAG", _
                                                                          ":VLFIXO", _
                                                                          ":SQPAGCTRPAF")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", mCdContratoPAF), _
                                           DBParametro_Montar("SQPAG", objGrid_Valor(grdCadastraContratoPAF, cnt_GridPagCad_SqPagamento, iCont)), _
                                           DBParametro_Montar("VLFIXO", objGrid_Valor(grdCadastraContratoPAF, cnt_GridCadContratoPAF_ValorAplicado, iCont)), _
                                           DBParametro_Montar("SQPAGCTRPAF", Nothing, , ParameterDirection.Output)) Then GoTo Erro
            End If
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdGravar_Negociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_Negociacao.Click
        Dim iCont As Integer
        Dim SqlText As String
        Dim ExiteSelecionado As Boolean

        ExiteSelecionado = False

        For iCont = 0 To grdCadastraNegociacao.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraNegociacao, cnt_GridPagCad_Selecao, iCont) Then
                ExiteSelecionado = True
            End If
        Next

        If ExiteSelecionado = False Then
            Msg_Mensagem("Favor selecionar um pagamento antes.")
            Exit Sub
        End If

        If IcValida = True Then
            If txtValorAposAplicacaoNegociacao.Value > Math.Round(txtValorTotalAplicadoNegociacao.Value + txtSaldoValorNegociacao.Value, 2) Then
                Msg_Mensagem("O total aplicado não pode ser maior que o saldo da Negociação.")
                Exit Sub
            End If
        End If

        DBUsarTransacao = True

        For iCont = 0 To grdCadastraNegociacao.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraNegociacao, cnt_GridPagCad_Selecao, iCont) Then
                SqlText = DBMontar_SP("SOF.SP_INCLUI_PAG_NEG", False, ":CDCTRPAF", _
                                                                      ":SQNEG", _
                                                                      ":SQPAG", _
                                                                      ":SQPAGCTRPAF", _
                                                                      ":VLFIXO", _
                                                                      ":ICGERACONCILIACAO", _
                                                                      ":DSCONCILIACAO", _
                                                                      ":SQPAGNEG", _
                                                                      ":SQPAGJUROS", _
                                                                      ":VLJUROS", _
                                                                      ":VLFIXOFINAL", _
                                                                      ":SQPAGCTRPAFJUROS", _
                                                                      ":SQPAGNEGJUROS")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", mCdContratoPAF), _
                                           DBParametro_Montar("SQNEG", mSqNegociacao), _
                                           DBParametro_Montar("SQPAG", objGrid_Valor(grdCadastraNegociacao, cnt_GridPagCad_SqPagamento, iCont)), _
                                           DBParametro_Montar("SQPAGCTRPAF", objGrid_Valor(grdCadastraNegociacao, cnt_GridPagCad_SqPagCtrPAF, iCont)), _
                                           DBParametro_Montar("VLFIXO", objGrid_Valor(grdCadastraNegociacao, cnt_GridCadContratoPAF_ValorAplicado, iCont)), _
                                           DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                                           DBParametro_Montar("DSCONCILIACAO", Nothing), _
                                           DBParametro_Montar("SQPAGNEG", Nothing, , ParameterDirection.Output), _
                                           DBParametro_Montar("SQPAGJUROS", Nothing, , ParameterDirection.Output), _
                                           DBParametro_Montar("VLJUROS", Nothing, , ParameterDirection.Output), _
                                           DBParametro_Montar("VLFIXOFINAL", Nothing, , ParameterDirection.Output), _
                                           DBParametro_Montar("SQPAGCTRPAFJUROS", Nothing, , ParameterDirection.Output), _
                                           DBParametro_Montar("SQPAGNEGJUROS", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                If chkAplicarContratoFixo.Checked Then
                    If Not Gravar_ContraFixo(mCdContratoPAF, mSqNegociacao, SQ_NEGOFICAO_CONTRATO_FIXO, _
                                             objGrid_Valor(grdCadastraNegociacao, cnt_GridPagCad_SqPagamento, iCont), _
                                             objGrid_Valor(grdCadastraNegociacao, cnt_GridPagCad_SqPagCtrPAF, iCont), _
                                             Val(DBRetorno(1)), Val(DBRetorno(4))) Then
                    End If
                End If
            End If
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        ValidarNegociacao()

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdGravar_ContratoFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar_ContratoFixo.Click
        Dim iCont As Integer
        Dim ExiteSelecionado As Boolean

        ExiteSelecionado = False

        For iCont = 0 To grdCadastraContratoFixo.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraContratoFixo, cnt_GridPagCad_Selecao, iCont) Then
                ExiteSelecionado = True
            End If
        Next

        If ExiteSelecionado = False Then
            Msg_Mensagem("Favor selecionar um pagamento antes.")
            Exit Sub
        End If

        If txtValorAposAplicacaoContratoFixo.Value > Math.Round(txtValorTotalAplicadoContratoFixo.Value + txtSaldoValorContratoFixo.Value, 2) Then
            Msg_Mensagem("O total aplicado não pode ser maior que o saldo do contrato fixo.")
            Exit Sub
        End If

        DBUsarTransacao = True

        For iCont = 0 To grdCadastraContratoFixo.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdCadastraContratoFixo, cnt_GridPagCad_Selecao, iCont) Then
                If Not Gravar_ContraFixo(mCdContratoPAF, mSqNegociacao, mSqCtrFix, _
                                         objGrid_Valor(grdCadastraContratoFixo, cnt_GridPagCad_SqPagamento, iCont), _
                                         objGrid_Valor(grdCadastraContratoFixo, cnt_GridPagCad_SqPagCtrPAF, iCont), _
                                         objGrid_Valor(grdCadastraContratoFixo, cnt_GridPagCad_SqPagNeg, iCont), _
                                         objGrid_Valor(grdCadastraContratoFixo, cnt_GridCadContratoPAF_ValorAplicado, iCont)) Then GoTo Erro
            End If
        Next

        If Not DBExecutarTransacao() Then GoTo erro

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Function Gravar_ContraFixo(ByVal CD_CONTRATOPAF As Integer, ByVal SQ_NEGOCIACAO As Integer, _
                                       ByVal SQ_CONTRATO_FIXO As Integer, ByVal SQPAG As Integer, _
                                       ByVal SQPAGCTRPAF As Integer, ByVal SQPAGNEG As Integer, _
                                       ByVal VLFIXO As Double) As Boolean
        Dim SqlText As String

        SqlText = DBMontar_SP("SOF.SP_INCLUI_PAG_NEG_CTR_FIX", False, ":CDCTRPAF", _
                                                                      ":SQNEG", _
                                                                      ":SQCTRFIX", _
                                                                      ":SQPAG", _
                                                                      ":SQPAGCTRPAF", _
                                                                      ":SQPAGNEG", _
                                                                      ":VLFIXO", _
                                                                      ":ICGERACONCILIACAO", _
                                                                      ":DSCONCILIACAO", _
                                                                      ":SQPAGNEGCTRFIX", _
                                                                      ":SQPAGJUROS", _
                                                                      ":VLJUROS", _
                                                                      ":VLFIXOFINAL", _
                                                                      ":SQPAGCTRPAFJUROS", _
                                                                      ":SQPAGNEGJUROS", _
                                                                      ":SQPAGNEGCTRFIXJUROS")

        Return DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", CD_CONTRATOPAF), _
                                   DBParametro_Montar("SQNEG", SQ_NEGOCIACAO), _
                                   DBParametro_Montar("SQCTRFIX", SQ_CONTRATO_FIXO), _
                                   DBParametro_Montar("SQPAG", SQPAG), _
                                   DBParametro_Montar("SQPAGCTRPAF", SQPAGCTRPAF), _
                                   DBParametro_Montar("SQPAGNEG", SQPAGNEG), _
                                   DBParametro_Montar("VLFIXO", VLFIXO), _
                                   DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                                   DBParametro_Montar("DSCONCILIACAO", Nothing), _
                                   DBParametro_Montar("SQPAGNEGCTRFIX", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQPAGJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLFIXOFINAL", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQPAGCTRPAFJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQPAGNEGJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQPAGNEGCTRFIXJUROS", Nothing, , ParameterDirection.Output))
    End Function

    Private Sub AjustarTela()
        Dim oTab As Infragistics.Win.UltraWinTabControl.UltraTabPageControl

        If tbsGeral.ActiveTab Is Nothing Then
            oTab = TabPagamento
        Else
            oTab = tbsGeral.ActiveTab.TabPage
        End If

        '>> TAB Geral
        tbsGeral.Height = Me.Height - tbsGeral.Top - 35
        tbsGeral.Width = Me.Width - tbsGeral.Left - 15

        '>TAB Aplicação de Contrato PAF
        'Botões Consulta
        cmdExcluir_ContratoPAF.Top = oTab.Height - cmdExcluir_ContratoPAF.Height - 2
        cmdQuebrar_ContratoPAF.Top = cmdExcluir_ContratoPAF.Top
        cmdUsuario_ContratoPAF.Top = cmdExcluir_ContratoPAF.Top
        cmdExportarExcell_ContratoPAF.Top = cmdExcluir_ContratoPAF.Top
        'Grid Consulta
        grdConsultaContratoPAF.Top = oTab.Height / 2
        grdConsultaContratoPAF.Height = oTab.Height - grdConsultaContratoPAF.Top - cmdExcluir_ContratoPAF.Height - 10
        grdConsultaContratoPAF.Width = oTab.Width - (grdConsultaContratoPAF.Left * 2)
        'Campo Saldo
        txtValorTotalAplicadoContratoPAF.Left = grdConsultaContratoPAF.Left + grdConsultaContratoPAF.Width - txtValorTotalAplicadoContratoPAF.Width
        txtValorTotalAplicadoContratoPAF.Top = cmdExcluir_ContratoPAF.Top
        lblValorTotalAplicadoContratoPAF.Left = txtValorTotalAplicadoContratoPAF.Left - lblValorTotalAplicadoContratoPAF.Width - 5
        lblValorTotalAplicadoContratoPAF.Top = cmdExcluir_ContratoPAF.Top + ((cmdExcluir_ContratoPAF.Height - _
                                                                            lblValorTotalAplicadoContratoPAF.Height) / 2)
        'Botão Gravação
        cmdGravar_ContratoPAF.Top = grdConsultaContratoPAF.Top - cmdGravar_ContratoPAF.Height - 5
        cmdSelecionarTodos_ContratoPAF.Top = cmdGravar_ContratoPAF.Top
        'Campo Após Aplicação
        txtValorAposAplicacaoContratoPAF.Left = grdConsultaContratoPAF.Left + grdConsultaContratoPAF.Width - _
                                                txtValorAposAplicacaoContratoPAF.Width
        txtValorAposAplicacaoContratoPAF.Top = cmdGravar_ContratoPAF.Top
        lblValorAposAplicacaoContratoPAF.Top = cmdGravar_ContratoPAF.Top + ((cmdGravar_ContratoPAF.Height - _
                                                                             lblValorAposAplicacaoContratoPAF.Height) / 2)
        lblValorAposAplicacaoContratoPAF.Left = txtValorAposAplicacaoContratoPAF.Left - lblValorAposAplicacaoContratoPAF.Width - 5
        'Grid Cadastro
        grdCadastraContratoPAF.Height = txtValorAposAplicacaoContratoPAF.Top - grdCadastraContratoPAF.Top - 5
        grdCadastraContratoPAF.Width = grdConsultaContratoPAF.Width

        '>TAB Aplicação de Negociação
        'Botões Consulta
        cmdExcluir_Negociacao.Top = oTab.Height - cmdExcluir_Negociacao.Height - 2
        cmdQuebrar_Negociacao.Top = cmdExcluir_Negociacao.Top
        cmdUsuario_Negociacao.Top = cmdExcluir_Negociacao.Top
        cmdExportarExcell_Negociacao.Top = cmdExcluir_Negociacao.Top
        'Grid Consulta
        grdConsultaNegociacao.Top = oTab.Height / 2
        grdConsultaNegociacao.Height = oTab.Height - grdConsultaNegociacao.Top - cmdExcluir_Negociacao.Height - 10
        grdConsultaNegociacao.Width = oTab.Width - (grdConsultaNegociacao.Left * 2)
        'Campo Saldo
        txtSaldoValorNegociacao.Left = grdConsultaNegociacao.Left + grdConsultaNegociacao.Width - txtSaldoValorNegociacao.Width
        txtSaldoValorNegociacao.Top = cmdExcluir_Negociacao.Top
        lblSaldoValorNegociacao.Left = txtSaldoValorNegociacao.Left - lblSaldoValorNegociacao.Width - 5
        lblSaldoValorNegociacao.Top = cmdExcluir_Negociacao.Top + ((cmdExcluir_Negociacao.Height - _
                                                                      lblSaldoValorNegociacao.Height) / 2)
        txtValorTotalAplicadoNegociacao.Top = txtSaldoValorNegociacao.Top
        txtValorTotalAplicadoNegociacao.Left = lblSaldoValorNegociacao.Left - txtValorTotalAplicadoNegociacao.Width - 15
        lblValorTotalAplicadoNegociacao.Left = txtValorTotalAplicadoNegociacao.Left - lblValorTotalAplicadoNegociacao.Width - 5
        lblValorTotalAplicadoNegociacao.Top = lblSaldoValorNegociacao.Top
        'Botão Gravação
        cmdGravar_Negociacao.Top = grdConsultaNegociacao.Top - cmdGravar_Negociacao.Height - 5
        cmdSelecionarTodos_Negociacao.Top = cmdGravar_Negociacao.Top
        'Campo Após Aplicação
        txtValorAposAplicacaoNegociacao.Left = grdConsultaNegociacao.Left + grdConsultaNegociacao.Width - _
                                                txtValorAposAplicacaoNegociacao.Width
        txtValorAposAplicacaoNegociacao.Top = cmdGravar_Negociacao.Top
        lblValorAposAplicacaoNegociacao.Top = cmdGravar_Negociacao.Top + ((cmdGravar_Negociacao.Height - _
                                                                             lblValorAposAplicacaoNegociacao.Height) / 2)
        lblValorAposAplicacaoNegociacao.Left = txtValorAposAplicacaoNegociacao.Left - lblValorAposAplicacaoNegociacao.Width - 5
        'Grid Cadastro
        grdCadastraNegociacao.Height = txtValorAposAplicacaoNegociacao.Top - grdCadastraNegociacao.Top - 10 - chkAplicarContratoFixo.Height
        grdCadastraNegociacao.Width = grdConsultaNegociacao.Width

        '>TAB Aplicação de Contrato Fixo
        'Botões Consulta
        cmdExcluir_ContratoFixo.Top = oTab.Height - cmdExcluir_ContratoFixo.Height - 2
        cmdUsuario_ContratoFixo.Top = cmdExcluir_ContratoFixo.Top
        cmdExportarExcell_ContratoFixo.Top = cmdExcluir_ContratoFixo.Top
        'Grid Consulta
        grdConsultaContratoFixo.Top = oTab.Height / 2
        grdConsultaContratoFixo.Height = oTab.Height - grdConsultaContratoFixo.Top - cmdExcluir_ContratoFixo.Height - 10
        grdConsultaContratoFixo.Width = oTab.Width - (grdConsultaContratoFixo.Left * 2)
        'Campo Saldo
        txtSaldoValorContratoFixo.Left = grdConsultaContratoFixo.Left + grdConsultaContratoFixo.Width - txtSaldoValorContratoFixo.Width
        txtSaldoValorContratoFixo.Top = cmdExcluir_ContratoFixo.Top
        lblSaldoValorContratoFixo.Left = txtSaldoValorContratoFixo.Left - lblSaldoValorContratoFixo.Width - 5
        lblSaldoValorContratoFixo.Top = cmdExcluir_ContratoFixo.Top + ((cmdExcluir_ContratoFixo.Height - _
                                                                      lblSaldoValorContratoFixo.Height) / 2)
        txtValorTotalAplicadoContratoFixo.Top = txtSaldoValorContratoFixo.Top
        txtValorTotalAplicadoContratoFixo.Left = lblSaldoValorContratoFixo.Left - txtValorTotalAplicadoContratoFixo.Width - 15
        lblValorTotalAplicadoContratoFixo.Left = txtValorTotalAplicadoContratoFixo.Left - lblValorTotalAplicadoContratoFixo.Width - 5
        lblValorTotalAplicadoContratoFixo.Top = lblSaldoValorContratoFixo.Top
        'Botão Gravação
        cmdGravar_ContratoFixo.Top = grdConsultaContratoFixo.Top - cmdGravar_ContratoFixo.Height - 5
        cmdSelecionarTodos_ContratoFixo.Top = cmdGravar_ContratoFixo.Top
        'Campo Após Aplicação
        txtValorAposAplicacaoContratoFixo.Left = grdConsultaContratoFixo.Left + grdConsultaContratoFixo.Width - _
                                                txtValorAposAplicacaoContratoFixo.Width
        txtValorAposAplicacaoContratoFixo.Top = cmdGravar_ContratoFixo.Top
        lblValorAposAplicacaoContratoFixo.Top = cmdGravar_ContratoFixo.Top + ((cmdGravar_ContratoFixo.Height - _
                                                                             lblValorAposAplicacaoContratoFixo.Height) / 2)
        lblValorAposAplicacaoContratoFixo.Left = txtValorAposAplicacaoContratoFixo.Left - lblValorAposAplicacaoContratoFixo.Width - 5
        'Grid Cadastro
        grdCadastraContratoFixo.Height = txtValorAposAplicacaoContratoFixo.Top - grdCadastraContratoFixo.Top - 5
        grdCadastraContratoFixo.Width = grdConsultaContratoFixo.Width
    End Sub

    Private Sub frmAplicacaoPagamento_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        AjustarTela()
    End Sub

    Private Sub grdCadastraContratoPAF_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraContratoPAF.AfterCellUpdate
        If e.Cell.Column.Index = cnt_GridCadContratoPAF_ValorAplicado Then
            With grdCadastraContratoPAF.Rows(e.Cell.Row.Index)
                If NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) < 0 Or _
                   (NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) > .Cells(cnt_GridPagCad_Valor_Pagamento).Value And _
                    NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) <> 0) Then
                    Msg_Mensagem("O Valor tem que estar entre 0 e " & Format(.Cells(cnt_GridPagCad_Valor_Pagamento).Value, "#,##0.00"))
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = 0
                    Exit Sub
                End If

                If NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) = 0 Then
                    .Cells(cnt_GridPagCad_Selecao).Value = 0
                Else
                    .Cells(cnt_GridPagCad_Selecao).Value = 1
                End If
            End With
        End If

        txtValorAposAplicacaoContratoPAF.Value = txtValorTotalAplicadoContratoPAF.Value + _
                                                 objGrid_CalcularTotalColuna(grdCadastraContratoPAF, cnt_GridCadContratoPAF_ValorAplicado)
    End Sub

    Private Sub grdCadastraContratoPAF_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraContratoPAF.CellChange
        If e.Cell.Column.Index = cnt_GridPagCad_Selecao Then
            With grdCadastraContratoPAF.Rows(e.Cell.Row.Index)
                If .Cells(cnt_GridPagCad_Selecao).Value = 1 Then
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = 0
                Else
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = .Cells(cnt_GridPagCad_Valor_Pagamento).Value
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Activate()
                    grdCadastraContratoPAF.PerformAction(UltraGridAction.EnterEditMode)
                End If
            End With
        End If
    End Sub

    Private Sub grdCadastraContratoPAF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdCadastraContratoPAF.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdCadastraContratoPAF.PerformAction(UltraGridAction.ExitEditMode)
        End If
    End Sub

    Private Sub grdCadastraNegociacao_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraNegociacao.AfterCellUpdate
        If e.Cell.Column.Index = cnt_GridCadContratoPAF_ValorAplicado Then
            With grdCadastraNegociacao.Rows(e.Cell.Row.Index)
                If NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) < 0 Or _
                  (NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) > .Cells(cnt_GridPagCad_Valor_Pagamento).Value And _
                   NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) <> 0) Then
                    Msg_Mensagem("O Valor tem que estar entre 0 e " & Format(.Cells(cnt_GridPagCad_Valor_Pagamento).Value, "#,##0.00"))
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = 0
                    Exit Sub
                End If

                If NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) = 0 Then
                    .Cells(cnt_GridPagCad_Selecao).Value = 0
                Else
                    .Cells(cnt_GridPagCad_Selecao).Value = 1
                End If
            End With
        End If

        txtValorAposAplicacaoNegociacao.Value = txtValorTotalAplicadoNegociacao.Value + _
                                                objGrid_CalcularTotalColuna(grdCadastraNegociacao, cnt_GridCadContratoPAF_ValorAplicado)
    End Sub

    Private Sub grdCadastraNegociacao_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraNegociacao.CellChange
        'PREENCHO O  VALOR APLICADO COM O A APLICAR
        If e.Cell.Column.Index = cnt_GridPagCad_Selecao Then
            With grdCadastraNegociacao.Rows(e.Cell.Row.Index)
                If .Cells(cnt_GridPagCad_Selecao).Value = 1 Then
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = 0
                Else
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = .Cells(cnt_GridPagCad_Valor_Pagamento).Value
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Activate()
                    grdCadastraNegociacao.PerformAction(UltraGridAction.EnterEditMode)
                End If
            End With
        End If
    End Sub

    Private Sub grdCadastraNegociacao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdCadastraNegociacao.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdCadastraNegociacao.PerformAction(UltraGridAction.ExitEditMode)
        End If
    End Sub

    Private Sub grdCadastraContratoFixo_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraContratoFixo.AfterCellUpdate
        If e.Cell.Column.Index = cnt_GridCadContratoPAF_ValorAplicado Then
            With grdCadastraContratoFixo.Rows(e.Cell.Row.Index)
                If NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) < 0 Or _
                   (NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) > .Cells(cnt_GridPagCad_Valor_Pagamento).Value And _
                    NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) <> 0) Then
                    Msg_Mensagem("O Valor tem que estar entre 0 e " & Format(.Cells(cnt_GridPagCad_Valor_Pagamento).Value, "#,##0.00"))
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = 0
                    Exit Sub
                End If

                If NVL(.Cells(cnt_GridCadContratoPAF_ValorAplicado).Value, 0) = 0 Then
                    .Cells(cnt_GridPagCad_Selecao).Value = 0
                Else
                    .Cells(cnt_GridPagCad_Selecao).Value = 1
                End If
            End With
        End If

        txtValorAposAplicacaoContratoFixo.Value = txtValorTotalAplicadoContratoFixo.Value + _
                                                  objGrid_CalcularTotalColuna(grdCadastraContratoFixo, cnt_GridCadContratoPAF_ValorAplicado)
    End Sub

    Private Sub grdCadastraContratoFixo_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCadastraContratoFixo.CellChange
        'PREENCHO O  VALOR APLICADO COM O A APLICAR
        If e.Cell.Column.Index = cnt_GridPagCad_Selecao Then
            With grdCadastraContratoFixo.Rows(e.Cell.Row.Index)
                If .Cells(cnt_GridPagCad_Selecao).Value = 1 Then
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = 0
                Else
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Value = .Cells(cnt_GridPagCad_Valor_Pagamento).Value
                    .Cells(cnt_GridCadContratoPAF_ValorAplicado).Activate()
                    grdCadastraContratoFixo.PerformAction(UltraGridAction.EnterEditMode)
                End If
            End With
        End If
    End Sub

    Private Sub grdCadastraContratoFixo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdCadastraContratoFixo.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdCadastraContratoFixo.PerformAction(UltraGridAction.ExitEditMode)
        End If
    End Sub

    Private Sub cmdQuebrar_ContratoPAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuebrar_ContratoPAF.Click
        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdConsultaContratoPAF) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        On Error GoTo Erro

        If objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_ValorAberto) = 0 Then
            Msg_Mensagem("A aplicação não possue saldo em aberto para realizar a operação.")
            Exit Sub
        End If

        SqlText = "SELECT PCP.SQ_CONFISSAO_DIVIDA  "
        SqlText = SqlText & "  FROM SOF.PAG_CTR_PAF PCP "
        SqlText = SqlText & " WHERE PCP.CD_CONTRATO_PAF =  " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_SqCtrPAF)

        If DBQuery_ValorUnico(SqlText, -1) <> -1 Then
            Msg_Mensagem("Essa aplicação pertence a uma recuperação de credito.")
            Exit Sub
        End If

        SqlText = "SELECT TC.IC_ADIANTAMENTO "
        SqlText = SqlText & "  FROM SOF.CONTRATO_PAF C, SOF.TIPO_CONTRATO_PAF TC "
        SqlText = SqlText & " WHERE C.CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_SqCtrPAF)
        SqlText = SqlText & "   AND C.CD_TIPO_CONTRATO_PAF = TC.CD_TIPO_CONTRATO_PAF "

        If DBQuery_ValorUnico(SqlText) = "S" And objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_DataPagamento) <> DataSistema() Then
            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_QuebrarAplicacaoAdiantamentDataAnteriorContratoPAF) Then
                Msg_Mensagem("Essa aplicação esta aplicada em um contrato PAF com adiantamento e foi feito numa data diferente da atual.")
                Exit Sub
            Else
                If Not Msg_Perguntar("Essa aplicação esta aplicada em um contrato PAF com adiantamento e foi feito numa data diferente da atual." & _
                                     vbCrLf & "Deseja realmente continuar com a quebra?" & vbCrLf & _
                                     "Não se esqueça voce pode deixar de cobrar Juros e não vai haver historico da quebra," & _
                                     "para isso utilize o estorno.") Then Exit Sub
            End If
        End If

        Dim oForm As New frmAplicacao_QuebrarValor

        oForm.Tipo_Aplicacao_Contrato = frmAplicacao_QuebrarValor.enTipo_Aplicacao_Contrato.tacPAG
        oForm.ValorMaximo = objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_ValorAberto)

        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            SqlText = "UPDATE SOF.PAG_CTR_PAF " & _
                      " SET VL_FIXO = VL_FIXO - " & oForm.ValorSolicitado & ", " & _
                           "VL_A_FIXAR = VL_A_FIXAR - " & oForm.ValorSolicitado & " " & _
                      " WHERE CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_SqCtrPAF) & _
                        " AND SQ_PAGAMENTO = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_SqPagamento) & _
                        " AND SQ_PAG_CTR_PAF = " & objGrid_Valor(grdConsultaContratoPAF, cnt_GridPagCons_SqPagamentoCtrPAF)
            If Not DBExecutar(SqlText) Then GoTo Erro

            ExecutaConsulta()
        End If

        oForm.Dispose()
        oForm = Nothing

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdQuebrar_Negociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuebrar_Negociacao.Click
        If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ExcluirQuebrarAplicacaoNegociacaoFechada) Then
            If Not Verifica_Situacao_Contrato(objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqCtrPAF), _
                                              objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqNeg), -1) Then Exit Sub
        End If

        If objGrid_LinhaSelecionada(grdConsultaNegociacao) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        Dim SqlText As String

        If objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_ValorAberto) = 0 Then
            Msg_Mensagem("A aplicação não possue saldo em aberto para realizar a operação.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) AS QT" & _
                  " FROM SOF.CTRPAF_NEG_CTRFIX_MOV_DQ " & _
                  " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamento)
        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Essa aplicação corresponde a um desagio financeiro.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) AS QT" & _
                   " FROM SOF.PAGAMENTO_DESAGIO_AUTOMATICO " & _
                  " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamento)
        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Essa aplicação corresponde a um desagio financeiro.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) AS QT" & _
                  " FROM SOF.PAGAMENTO_JUROS_AUTOMATICO " & _
                  " WHERE SQ_PAGAMENTO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamento)
        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Essa aplicação corresponde a uma cobrança de juros.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) AS QT" & _
                  " FROM SOF.PAG_NEG_JUROS PNJ" & _
                  " WHERE PNJ.CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqCtrPAF) & _
                    " AND PNJ.SQ_NEGOCIACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqNeg) & _
                    " AND PNJ.SQ_PAGAMENTO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamento) & _
                    " AND PNJ.SQ_PAG_NEG = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamentoNeg) & _
                    " AND PNJ.SQ_PAG_CTR_PAF = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamentoCtrPAF)
        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Essa aplicação possue uma cobrança de juros e não podera ser quebrada.")
            Exit Sub
        End If

        SqlText = "SELECT PCP.SQ_CONFISSAO_DIVIDA  "
        SqlText = SqlText & "  FROM SOF.PAG_CTR_PAF PCP "
        SqlText = SqlText & " WHERE PCP.CD_CONTRATO_PAF =  " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqCtrPAF)

        If DBQuery_ValorUnico(SqlText, -1) <> -1 Then
            Msg_Mensagem("Essa aplicação pertence a uma recuperação de credito.")
            Exit Sub
        End If

        Dim oForm As New frmAplicacao_QuebrarValor

        oForm.Tipo_Aplicacao_Contrato = frmAplicacao_QuebrarValor.enTipo_Aplicacao_Contrato.tacPAG
        oForm.ValorMaximo = objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_ValorAberto)
        Form_Show(Nothing, oForm, True, True)

        If Not oForm.Cancelado Then
            SqlText = "UPDATE SOF.PAG_NEG" & _
                      " SET VL_FIXO = VL_FIXO - " & oForm.ValorSolicitado & "," & _
                           "VL_A_FIXAR = VL_A_FIXAR - " & oForm.ValorSolicitado & _
                      " WHERE CD_CONTRATO_PAF = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqCtrPAF) & _
                        " AND SQ_NEGOCIACAO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqNeg) & _
                        " AND SQ_PAGAMENTO = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamento) & _
                        " AND SQ_PAG_CTR_PAF = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamentoCtrPAF) & _
                        " AND SQ_PAG_NEG = " & objGrid_Valor(grdConsultaNegociacao, cnt_GridPagCons_SqPagamentoNeg)
            If Not DBExecutar(SqlText) Then GoTo Erro

            ExecutaConsulta()
        End If

        oForm.Dispose()
        oForm = Nothing

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdExportarExcell_Negociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcell_Negociacao.Click
        objGrid_ExportarExcell(grdConsultaNegociacao, Me.Text & " - " & TabMovimentacao.Tab.Text)
    End Sub

    Private Sub cmdExportarExcell_ContratoFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcell_ContratoFixo.Click
        objGrid_ExportarExcell(grdConsultaContratoFixo, Me.Text & " - " & TabContratoFixo.Tab.Text)
    End Sub

    Private Sub cmdExportarExcell_ContratoPAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcell_ContratoPAF.Click
        objGrid_ExportarExcell(grdConsultaContratoPAF, Me.Text & " - " & TabPagamento.Tab.Text)
    End Sub

    Private Sub cmdSelecionarTodos_ContratoPAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarTodos_ContratoPAF.Click
        Dim iCont As Integer

        For iCont = 0 To grdCadastraContratoPAF.Rows.Count - 1
            grdCadastraContratoPAF.Rows(iCont).Cells(cnt_GridPagCad_Selecao).Value = True
        Next
    End Sub

    Private Sub cmdSelecionarTodos_Negociacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarTodos_Negociacao.Click
        Dim iCont As Integer

        For iCont = 0 To grdCadastraNegociacao.Rows.Count - 1
            grdCadastraNegociacao.Rows(iCont).Cells(cnt_GridPagCad_Selecao).Value = True
        Next
    End Sub

    Private Sub cmdSelecionarTodos_ContratoFixo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionarTodos_ContratoFixo.Click
        Dim iCont As Integer

        For iCont = 0 To grdCadastraContratoFixo.Rows.Count - 1
            grdCadastraContratoFixo.Rows(iCont).Cells(cnt_GridPagCad_Selecao).Value = True
        Next
    End Sub
End Class