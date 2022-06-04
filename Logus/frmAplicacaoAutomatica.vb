Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmAplicacaoAutomatica
    Const cnt_GridGeral_Selecionado As Integer = 0
    Const cnt_GridGeral_Informacao As Integer = 1
    Const cnt_GridGeral_Fornecedor As Integer = 2
    Const cnt_GridGeral_LocalEntrega As Integer = 3
    Const cnt_GridGeral_NF As Integer = 4
    Const cnt_GridGeral_ValorNF As Integer = 5
    Const cnt_GridGeral_ValorICMS As Integer = 6
    Const cnt_GridGeral_ValorINSS As Integer = 7
    Const cnt_GridGeral_Quantidade As Integer = 8
    Const cnt_GridGeral_QunatidadeLiquida As Integer = 9
    Const cnt_GridGeral_Municipio As Integer = 10
    Const cnt_GridGeral_Filial As Integer = 11
    Const cnt_GridGeral_CodigoLocalEntrega As Integer = 12
    Const cnt_GridGeral_SqMovimentacao As Integer = 13
    Const cnt_GridGeral_SqCessaoDireito As Integer = 14
    Const cnt_GridGeral_CdFilialMovimentacao As Integer = 15
    Const cnt_GridGeral_ValorFrete As Integer = 16
    Const cnt_GridGeral_AplicaAutomatico As Integer = 17
    Const cnt_GridGeral_ValorAfixar As Integer = 18
    Const cnt_GridGeral_QunatidadeAfixar As Integer = 19
    Const cnt_GridGeral_CodigoFornecedor As Integer = 20

    Const cnt_Tela As String = "Transacao_Contratos_Recursos_AplicacaoAutomatica"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridGeral_Informacao).Hidden = True

        SqlText = "SELECT   DECODE (ic_aplica_automatico, 'N', 0, 1) selecionado, '' informacao, "
        SqlText = SqlText & "         f.no_razao_social, le.no_local_entrega, m.nu_nf, "
        SqlText = SqlText & "         m.vl_nf, m.vl_nf_icms, m.vl_nf_funrural, m.qt_kg_nf, "
        SqlText = SqlText & "         m.qt_kg_liquido_nf, munic.no_cidade, "
        SqlText = SqlText & "         fil.no_filial no_filial_movimentacao, "
        SqlText = SqlText & "         NVL (m.cd_local_entrega, 3) cd_local_entrega, mcd.sq_movimentacao, "
        SqlText = SqlText & "         mcd.sq_movimentacao_cessao_direito, m.cd_filial_movimentacao, "
        SqlText = SqlText & "         DECODE (m.cd_local_entrega, "
        SqlText = SqlText & "                 1, fil.vl_frete_filial_fazenda, "
        SqlText = SqlText & "                 2, fil.vl_frete_filial_fabrica, "
        SqlText = SqlText & "                 3, fil.vl_frete_fabrica, "
        SqlText = SqlText & "                 0 "
        SqlText = SqlText & "                ) AS valor_frete, "
        SqlText = SqlText & "         f.ic_aplica_automatico,mcd.vl_a_fixar,mcd.qt_kg_a_fixar,mcd.cd_fornecedor "
        SqlText = SqlText & "    FROM sof.movimentacao m, "
        SqlText = SqlText & "         sof.movimentacao_cessao_direito mcd, "
        SqlText = SqlText & "         sof.fornecedor f, "
        SqlText = SqlText & "         sof.movimentacao_qualidade mq, "
        SqlText = SqlText & "         sof.municipio munic, "
        SqlText = SqlText & "         sof.local_entrega le, "
        SqlText = SqlText & "         sof.filial fil "
        SqlText = SqlText & "   WHERE m.sq_movimentacao = mcd.sq_movimentacao "
        SqlText = SqlText & "     AND m.sq_movimentacao = mq.sq_movimentacao(+) "
        SqlText = SqlText & "     AND m.cd_municipio_origem = munic.cd_municipio(+) "
        SqlText = SqlText & "     AND m.cd_local_entrega = le.cd_local_entrega(+) "
        SqlText = SqlText & "     AND m.cd_filial_movimentacao = fil.cd_filial "
        SqlText = SqlText & "     AND mcd.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "     AND f.cd_filial_origem = " & FilialLogada
        SqlText = SqlText & "     AND mcd.qt_kg_a_fixar <> 0 "
        SqlText = SqlText & "ORDER BY mcd.sq_movimentacao, mcd.sq_movimentacao_cessao_direito "


        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Selecionado, _
                                                            cnt_GridGeral_Informacao, _
                                                            cnt_GridGeral_Fornecedor, _
                                                            cnt_GridGeral_LocalEntrega, _
                                                            cnt_GridGeral_NF, _
                                                            cnt_GridGeral_ValorNF, _
                                                            cnt_GridGeral_ValorICMS, _
                                                            cnt_GridGeral_ValorINSS, _
                                                            cnt_GridGeral_Quantidade, _
                                                            cnt_GridGeral_QunatidadeLiquida, _
                                                            cnt_GridGeral_Municipio, _
                                                            cnt_GridGeral_Filial, _
                                                            cnt_GridGeral_CodigoLocalEntrega, _
                                                            cnt_GridGeral_SqMovimentacao, _
                                                            cnt_GridGeral_SqCessaoDireito, _
                                                            cnt_GridGeral_CdFilialMovimentacao, _
                                                            cnt_GridGeral_ValorFrete, _
                                                            cnt_GridGeral_AplicaAutomatico, _
                                                            cnt_GridGeral_ValorAfixar, _
                                                            cnt_GridGeral_QunatidadeAfixar, _
                                                            cnt_GridGeral_CodigoFornecedor})

       



    End Sub

    Private Sub frmAplicacaoAutomatica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdGeral, "", 40, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdGeral, "Informação", 180)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 200)
        objGrid_Coluna_Add(grdGeral, "Local Entrega", 110)
        objGrid_Coluna_Add(grdGeral, "NF", 60)
        objGrid_Coluna_Add(grdGeral, "Valor NF", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor ICMS", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor INSS", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Quantidade", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Quantidade Liq.", 110, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Municipio", 130)
        objGrid_Coluna_Add(grdGeral, "Filial", 150)
        objGrid_Coluna_Add(grdGeral, "CodigoLocalEntrega", 0)
        objGrid_Coluna_Add(grdGeral, "SqMovimentacao", 0)
        objGrid_Coluna_Add(grdGeral, "SqCessaoDireito", 0)
        objGrid_Coluna_Add(grdGeral, "CdFilialMovimentacao", 0)
        objGrid_Coluna_Add(grdGeral, "ValorFrete", 0)
        objGrid_Coluna_Add(grdGeral, "AplicaAutomatico", 0)
        objGrid_Coluna_Add(grdGeral, "Valor a Fixar", 0)
        objGrid_Coluna_Add(grdGeral, "Quantidade a Fixar", 0)
        objGrid_Coluna_Add(grdGeral, "CodigoFornecedor", 0)

        ExecutaConsulta()

        SEC_ValidarBotao(cmdGravar, cnt_Tela, SEC_Validador.SEC_V_Inclusao, True)
    End Sub

    Private Sub grdGeral_BeforeCellActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles grdGeral.BeforeCellActivate
        If Trim(NuloParaString(e.Cell.Row.Cells(cnt_GridGeral_AplicaAutomatico).Value)) = "N" Then
            e.Cancel = (e.Cell.Column.Index = cnt_GridGeral_Selecionado)
        End If

        If e.Cancel Then Exit Sub
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim ExiteSelecionado As Boolean
        Dim SqlText As String
        Dim VlCtr As Double
        Dim QtCtr As Long
        Dim VlFix As Double
        Dim VlAFixar As Double
        Dim QtFix As Long
        Dim QtAFixar As Long
        Dim SqCtrPAFMov As Long
        Dim SqCtrPAFNegMov As Long
        Dim AplicPostoDif As Boolean
        Dim iCont As Integer
        Dim iCont2 As Integer
        Dim Fator As Double
        Dim oDataAux As DataTable
        Dim oForm As frmProgressBar

        Fator = 0
        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_Selecionado, iCont) Then
                ExiteSelecionado = True
                Fator = Fator + 1
            End If
        Next
        Fator = 100 / (Fator + 1)

        If ExiteSelecionado = False Then
            Msg_Mensagem("Favor selecionar um item antes.")
            Exit Sub
        End If


        If Msg_Perguntar("Aplicar os recebimentos ?") = False Then
            Exit Sub
        End If

        SqlText = "select ic_aplic_posto_diferente from sof.filial where cd_filial=" & FilialLogada
       
        AplicPostoDif = IIf(DBQuery_ValorUnico(SqlText) = "S", True, False)


        oForm = New frmProgressBar
        oForm.lblTexto.Text = "Aplicando o Cacau"
        oForm.Show()


        For iCont = 0 To grdGeral.Rows.Count - 1
            VlAFixar = grdGeral.Rows(iCont).Cells(cnt_GridGeral_ValorAfixar).Value
            QtAFixar = grdGeral.Rows(iCont).Cells(cnt_GridGeral_QunatidadeAfixar).Value


            DBUsarTransacao = True

            If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_Selecionado, iCont) Then

                oForm.Inclementa_Valor_ProgressBar(Fator)
                oForm.Refresh()

                SqlText = "SELECT CF.CD_CONTRATO_PAF, CF.SQ_NEGOCIACAO, CF.SQ_CONTRATO_FIXO, "
                SqlText = SqlText & "       ROUND(( sof.FC_SALDO_CTR_FIX(cf.cd_contrato_paf,cf.sq_negociacao ,cf.sq_contrato_fixo ) - CF.VL_NF_FIXO + CF.VL_NF_INSS_FIXO) "
                SqlText = SqlText & "              / (1 - (FUN.VL_TAXA / 100)),2) AS VL_SALDO, "
                SqlText = SqlText & "       (CF.QT_KGS - CF.QT_CANCELADO - CF.QT_KG_FIXO) QT_SALDO, "
                SqlText = SqlText & "       (N.QT_KGS - N.QT_CANCELADO - N.QT_EM_RENEGOCIACAO - N.QT_KG_FIXO) QT_SALDO_NEG, "
                SqlText = SqlText & "       (CP.QT_KGS - CP.QT_CANCELADO - CP.QT_KG_FIXO) QT_SALDO_CP "
                SqlText = SqlText & "FROM SOF.CONTRATO_FIXO CF, SOF.NEGOCIACAO N, SOF.CONTRATO_PAF CP, SOF.FORNECEDOR F, "
                SqlText = SqlText & "     SOF.FUNRURAL FUN, sof.filial fil "
                SqlText = SqlText & "WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
                SqlText = SqlText & "      CF.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
                SqlText = SqlText & "      CF.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO AND "
                SqlText = SqlText & "      CP.CD_FORNECEDOR = F.CD_FORNECEDOR AND "
                SqlText = SqlText & "      n.cd_filial_entrega =fil.cd_filial and F.CD_FUNRURAL = FUN.CD_FUNRURAL AND "
                SqlText = SqlText & "      CP.CD_FORNECEDOR = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_CodigoFornecedor).Value & " AND "
                SqlText = SqlText & "      CF.IC_STATUS = 'A' AND "
                SqlText = SqlText & "      nvl(decode (n.cd_local_entrega,1,fil.vl_frete_filial_fazenda,2,fil.vl_frete_filial_fabrica,3,fil.vl_frete_fabrica,0)," & grdGeral.Rows(iCont).Cells(cnt_GridGeral_ValorFrete).Value & ") = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_ValorFrete).Value & " and "

                If grdGeral.Rows(iCont).Cells(cnt_GridGeral_CodigoLocalEntrega).Value <> 3 And Not AplicPostoDif Then
                    SqlText = SqlText & "      N.CD_filial_ENTREGA = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_CdFilialMovimentacao).Value & " AND "
                End If
                SqlText = SqlText & "      CF.VL_PAG_FIXO <> 0 AND "
                SqlText = SqlText & "      (CF.QT_KGS - CF.QT_CANCELADO) <> CF.QT_KG_FIXO "
                SqlText = SqlText & "ORDER BY CF.Dt_Vencimento , "
                SqlText = SqlText & "         CF.CD_CONTRATO_PAF, "
                SqlText = SqlText & "         CF.SQ_NEGOCIACAO, "
                SqlText = SqlText & "         CF.SQ_CONTRATO_FIXO "

                oDataAux = DBQuery(SqlText)

                For iCont2 = 0 To oDataAux.Rows.Count - 1
                    QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo")

                    If QtCtr > oDataAux.Rows(iCont2).Item("qt_saldo_neg") Then
                        QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo_neg")
                    End If

                    If QtCtr > oDataAux.Rows(iCont2).Item("qt_saldo_cp") Then
                        QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo_cp")
                    End If

                    VlCtr = oDataAux.Rows(iCont2).Item("vl_saldo")

                    If QtAFixar > QtCtr Then
                        QtFix = QtCtr
                        VlFix = Math.Round(QtFix / QtAFixar * VlAFixar, 2)
                    Else
                        QtFix = QtAFixar
                        VlFix = VlAFixar
                    End If

                    If VlFix > VlCtr Then
                        VlFix = VlCtr
                        If QtCtr <> 0 Then
                            QtFix = Math.Truncate(VlFix / VlAFixar * QtAFixar)
                            VlFix = FC_Round(QtFix / QtAFixar * VlAFixar, 2)
                        End If
                    End If


                    If QtFix <> 0 Then
                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", ":SQMOV", ":SQMOVCD", _
                                                                   ":VLFIXO", ":QTFIXO", ":SQCTRPAFMOV")

                        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("cd_contrato_paf")), _
                                                   DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                   DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                   DBParametro_Montar("VLFIXO", VlFix), _
                                                   DBParametro_Montar("QTFIXO", QtFix), _
                                                   DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                        SqCtrPAFMov = DBRetorno(1)

                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", ":SQMOV", _
                                                                                      ":SQMOVCD", ":VLFIXO", ":QTFIXO", ":SQCTRPAFNEGMOV")


                        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("cd_contrato_paf")), _
                                                   DBParametro_Montar("SQNEG", oDataAux.Rows(iCont2).Item("sq_negociacao")), _
                                                   DBParametro_Montar("SQCTRPAFMOV", SqCtrPAFMov), _
                                                   DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                   DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                   DBParametro_Montar("VLFIXO", VlFix), _
                                                   DBParametro_Montar("QTFIXO", QtFix), _
                                                   DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                        SqCtrPAFNegMov = Val(DBRetorno(1))

                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", ":SQMOV", _
                                                                                           ":SQMOVCD", ":VLFIXO", ":QTFIXO", ":SQCTRPAFNEGMOV", _
                                                                                           ":SQCTRFIX", ":SQCTRPAFNEGCTRFIXMOV", _
                                                                                           ":ICGERACONCILIACAO", ":DSCONCILIACAO")

                        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("cd_contrato_paf")), _
                                                   DBParametro_Montar("SQNEG", oDataAux.Rows(iCont2).Item("sq_negociacao")), _
                                                   DBParametro_Montar("SQCTRPAFMOV", SqCtrPAFMov), _
                                                   DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                   DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                   DBParametro_Montar("VLFIXO", VlFix), _
                                                   DBParametro_Montar("QTFIXO", QtFix), _
                                                   DBParametro_Montar("SQCTRPAFNEGMOV", SqCtrPAFNegMov), _
                                                   DBParametro_Montar("SQCTRFIX", oDataAux.Rows(iCont2).Item("sq_contrato_fixo")), _
                                                   DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                                                   DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                                                   DBParametro_Montar("DSCONCILIACAO", Nothing)) Then GoTo Erro

                    End If

                    VlAFixar = VlAFixar - VlFix
                    QtAFixar = QtAFixar - QtFix

                    If QtAFixar <= 0 Then Exit For
                Next


                If QtAFixar > 0 Then
                    SqlText = "SELECT distinct n.dt_vencimento, n.cd_contrato_paf, n.sq_negociacao, " & _
                              "(n.qt_kgs - n.qt_cancelado - n.qt_kg_fixo) qt_saldo, " & _
                              "(cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo) qt_saldo_cp " & _
                              "from sof.pag_neg pn, sof.negociacao n, sof.contrato_paf cp, sof.filial fil " & _
                              "where pn.cd_contrato_paf = n.cd_contrato_paf and " & _
                              "n.cd_filial_entrega =fil.cd_filial and pn.sq_negociacao = n.sq_negociacao and " & _
                              "n.cd_contrato_paf = cp.cd_contrato_paf and " & _
                              "cp.cd_fornecedor = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_CodigoFornecedor).Value & " and " & _
                              "nvl(decode (n.cd_local_entrega,1,fil.vl_frete_filial_fazenda,2,fil.vl_frete_filial_fabrica,3,fil.vl_frete_fabrica,0)," & grdGeral.Rows(iCont).Cells(cnt_GridGeral_ValorFrete).Value & ") = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_ValorFrete).Value & " and "



                    If grdGeral.Rows(iCont).Cells(cnt_GridGeral_CodigoLocalEntrega).Value <> 3 And Not AplicPostoDif Then
                        SqlText = SqlText & "      N.CD_filial_ENTREGA = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_CdFilialMovimentacao).Value & " AND "
                    End If

                    SqlText = SqlText & "n.ic_status = 'A' and " & _
                              "pn.vl_a_fixar <> 0 and " & _
                              "(n.qt_kgs - n.qt_cancelado) <> n.qt_kg_fixo " & _
                              "order by n.dt_vencimento, n.cd_contrato_paf, n.sq_negociacao"
                    oDataAux = DBQuery(SqlText)

                    For iCont2 = 0 To oDataAux.Rows.Count - 1
                        QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo")

                        If QtCtr > oDataAux.Rows(iCont2).Item("qt_saldo_cp") Then
                            QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo_cp")
                        End If

                        If QtAFixar > QtCtr Then
                            QtFix = QtCtr
                            VlFix = Math.Round(QtFix / QtAFixar * VlAFixar, 2)
                        Else
                            QtFix = QtAFixar
                            VlFix = VlAFixar
                        End If

                        If QtFix <> 0 Then
                            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", ":SQMOV", ":SQMOVCD", _
                                                          ":VLFIXO", ":QTFIXO", ":SQCTRPAFMOV")

                            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("cd_contrato_paf")), _
                                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                       DBParametro_Montar("VLFIXO", VlFix), _
                                                       DBParametro_Montar("QTFIXO", QtFix), _
                                                       DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                            SqCtrPAFMov = DBRetorno(1)

                            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", ":SQMOV", _
                                                                                          ":SQMOVCD", ":VLFIXO", ":QTFIXO", ":SQCTRPAFNEGMOV")


                            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("cd_contrato_paf")), _
                                                       DBParametro_Montar("SQNEG", oDataAux.Rows(iCont2).Item("sq_negociacao")), _
                                                       DBParametro_Montar("SQCTRPAFMOV", SqCtrPAFMov), _
                                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                       DBParametro_Montar("VLFIXO", VlFix), _
                                                       DBParametro_Montar("QTFIXO", QtFix), _
                                                       DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                        End If

                        VlAFixar = VlAFixar - VlFix
                        QtAFixar = QtAFixar - QtFix

                        If QtAFixar <= 0 Then Exit For
                    Next
                End If

                If QtAFixar > 0 Then
                    SqlText = "select distinct cp.dt_vencimento, cp.cd_contrato_paf, " & _
                              "(cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo) qt_saldo " & _
                              "" & _
                              "from sof.contrato_paf cp, sof.pag_ctr_paf pcp " & _
                              "where pcp.cd_contrato_paf = cp.cd_contrato_paf and " & _
                              "cp.cd_fornecedor = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_CodigoFornecedor).Value & " and " & _
                              "cp.ic_status = 'A' and " & _
                              "pcp.vl_a_fixar <> 0 and " & _
                              "(cp.qt_kgs - cp.qt_cancelado) <> cp.qt_kg_fixo " & _
                              "order by cp.dt_vencimento, cp.cd_contrato_paf" & _
                              "" & _
                              ""
                    oDataAux = DBQuery(SqlText)

                    For iCont2 = 0 To oDataAux.Rows.Count - 1
                        QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo")

                        If QtAFixar > QtCtr Then
                            QtFix = QtCtr
                            VlFix = Math.Round(QtFix / QtAFixar * VlAFixar, 2)
                        Else
                            QtFix = QtAFixar
                            VlFix = VlAFixar
                        End If

                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", ":SQMOV", ":SQMOVCD", _
                              ":VLFIXO", ":QTFIXO", ":SQCTRPAFMOV")

                        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("cd_contrato_paf")), _
                                                   DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                   DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                   DBParametro_Montar("VLFIXO", VlFix), _
                                                   DBParametro_Montar("QTFIXO", QtFix), _
                                                   DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro


                        VlAFixar = VlAFixar - VlFix
                        QtAFixar = QtAFixar - QtFix

                        If QtAFixar <= 0 Then Exit For

                    Next
                End If

                If QtAFixar > 0 Then
                    SqlText = "SELECT CF.CD_CONTRATO_PAF, CF.SQ_NEGOCIACAO, CF.SQ_CONTRATO_FIXO, "
                    SqlText = SqlText & "       ROUND((sof.FC_SALDO_CTR_FIX(cf.cd_contrato_paf,cf.sq_negociacao ,cf.sq_contrato_fixo ) - CF.VL_NF_FIXO + CF.VL_NF_INSS_FIXO) "
                    SqlText = SqlText & "              / (1 - (FUN.VL_TAXA / 100)),2) AS VL_SALDO, "
                    SqlText = SqlText & "       (CF.QT_KGS - CF.QT_CANCELADO - CF.QT_KG_FIXO) QT_SALDO, "
                    SqlText = SqlText & "       (N.QT_KGS - N.QT_CANCELADO - N.QT_EM_RENEGOCIACAO - N.QT_KG_FIXO) QT_SALDO_NEG, "
                    SqlText = SqlText & "       (CP.QT_KGS - CP.QT_CANCELADO - CP.QT_KG_FIXO) QT_SALDO_CP "
                    SqlText = SqlText & "FROM SOF.CONTRATO_FIXO CF, SOF.NEGOCIACAO N, SOF.CONTRATO_PAF CP, SOF.FORNECEDOR F, "
                    SqlText = SqlText & "     SOF.FUNRURAL FUN, sof.filial fil "
                    SqlText = SqlText & "WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
                    SqlText = SqlText & "      CF.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
                    SqlText = SqlText & "      CF.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO AND "
                    SqlText = SqlText & "      CP.CD_FORNECEDOR = F.CD_FORNECEDOR AND "
                    SqlText = SqlText & "      n.cd_filial_entrega =fil.cd_filial and F.CD_FUNRURAL = FUN.CD_FUNRURAL AND "
                    SqlText = SqlText & "      CP.CD_FORNECEDOR = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_CodigoFornecedor).Value & " AND "
                    SqlText = SqlText & "      CF.IC_STATUS = 'A' AND "
                    SqlText = SqlText & "      nvl(decode (n.cd_local_entrega,1,fil.vl_frete_filial_fazenda,2,fil.vl_frete_filial_fabrica,3,fil.vl_frete_fabrica,0)," & grdGeral.Rows(iCont).Cells(cnt_GridGeral_ValorFrete).Value & ") = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_ValorFrete).Value & " and "

                    If grdGeral.Rows(iCont).Cells(cnt_GridGeral_CodigoLocalEntrega).Value <> 3 And Not AplicPostoDif Then
                        SqlText = SqlText & "      N.CD_filial_ENTREGA = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_CdFilialMovimentacao).Value & " AND "
                    End If

                    SqlText = SqlText & "      (CF.QT_KGS - CF.QT_CANCELADO) <> CF.QT_KG_FIXO "
                    SqlText = SqlText & "ORDER BY CF.DT_VENCIMENTO, "
                    SqlText = SqlText & "         CF.CD_CONTRATO_PAF, "
                    SqlText = SqlText & "         CF.SQ_NEGOCIACAO, "
                    SqlText = SqlText & "         CF.SQ_CONTRATO_FIXO "
                    oDataAux = DBQuery(SqlText)

                    For iCont2 = 0 To oDataAux.Rows.Count - 1
                        QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo")
                        VlCtr = oDataAux.Rows(iCont2).Item("vl_saldo")

                        If QtCtr > oDataAux.Rows(iCont2).Item("qt_saldo_neg") Then
                            QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo_neg")
                        End If

                        If QtCtr > oDataAux.Rows(iCont2).Item("qt_saldo_cp") Then
                            QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo_cp")
                        End If

                        If QtAFixar > QtCtr Then
                            QtFix = QtCtr
                            VlFix = Math.Round(QtFix / QtAFixar * VlAFixar, 2)
                        Else
                            QtFix = QtAFixar
                            VlFix = VlAFixar
                        End If

                        If VlFix > VlCtr Then
                            VlFix = VlCtr
                        End If

                        If QtFix <> 0 Then
                            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", ":SQMOV", ":SQMOVCD", _
                                                           ":VLFIXO", ":QTFIXO", ":SQCTRPAFMOV")

                            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("cd_contrato_paf")), _
                                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                       DBParametro_Montar("VLFIXO", VlFix), _
                                                       DBParametro_Montar("QTFIXO", QtFix), _
                                                       DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                            SqCtrPAFMov = DBRetorno(1)

                            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", ":SQMOV", _
                                                                                          ":SQMOVCD", ":VLFIXO", ":QTFIXO", ":SQCTRPAFNEGMOV")


                            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("cd_contrato_paf")), _
                                                       DBParametro_Montar("SQNEG", oDataAux.Rows(iCont2).Item("sq_negociacao")), _
                                                       DBParametro_Montar("SQCTRPAFMOV", SqCtrPAFMov), _
                                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                       DBParametro_Montar("VLFIXO", VlFix), _
                                                       DBParametro_Montar("QTFIXO", QtFix), _
                                                       DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                            SqCtrPAFNegMov = Val(DBRetorno(1))

                            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", ":SQMOV", _
                                                                                               ":SQMOVCD", ":VLFIXO", ":QTFIXO", ":SQCTRPAFNEGMOV", _
                                                                                               ":SQCTRFIX", ":SQCTRPAFNEGCTRFIXMOV", _
                                                                                               ":ICGERACONCILIACAO", ":DSCONCILIACAO")

                            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("CD_CONTRATO_PAF")), _
                                                       DBParametro_Montar("SQNEG", oDataAux.Rows(iCont2).Item("SQ_NEGOCIACAO")), _
                                                       DBParametro_Montar("SQCTRPAFMOV", SqCtrPAFMov), _
                                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                       DBParametro_Montar("VLFIXO", VlFix), _
                                                       DBParametro_Montar("QTFIXO", QtFix), _
                                                       DBParametro_Montar("SQCTRPAFNEGMOV", SqCtrPAFNegMov), _
                                                       DBParametro_Montar("SQCTRFIX", oDataAux.Rows(iCont2).Item("SQ_CONTRATO_FIXO")), _
                                                       DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                                                       DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                                                       DBParametro_Montar("DSCONCILIACAO", Nothing)) Then GoTo Erro
                        End If

                        VlAFixar = VlAFixar - VlFix
                        QtAFixar = QtAFixar - QtFix

                        If QtAFixar <= 0 Then Exit For
                    Next
                End If

                If QtAFixar > 0 Then
                    SqlText = "select n.cd_contrato_paf, n.sq_negociacao, " & _
                              "(n.qt_kgs - n.qt_cancelado - n.qt_kg_fixo) qt_saldo, (cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo) qt_saldo_cp " & _
                              "from sof.negociacao n, sof.contrato_paf cp, sof.filial fil " & _
                              "where n.cd_contrato_paf = cp.cd_contrato_paf and " & _
                              "n.cd_filial_entrega =fil.cd_filial and cp.cd_fornecedor = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_CodigoFornecedor).Value & " and " & _
                              "nvl(decode (n.cd_local_entrega,1,fil.vl_frete_filial_fazenda,2,fil.vl_frete_filial_fabrica,3,fil.vl_frete_fabrica,0)," & grdGeral.Rows(iCont).Cells(cnt_GridGeral_ValorFrete).Value & ") = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_ValorFrete).Value & " and "


                    If grdGeral.Rows(iCont).Cells(cnt_GridGeral_CodigoLocalEntrega).Value <> 3 <> 3 And Not AplicPostoDif Then
                        SqlText = SqlText & "      N.CD_filial_ENTREGA = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_CdFilialMovimentacao).Value & " AND "
                    End If

                    SqlText = SqlText & "n.ic_status = 'A' and " & _
                              "(n.qt_kgs - n.qt_cancelado) <> n.qt_kg_fixo " & _
                              "order by n.dt_vencimento, n.cd_contrato_paf, n.sq_negociacao"
                    oDataAux = DBQuery(SqlText)

                    For iCont2 = 0 To oDataAux.Rows.Count - 1
                        QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo")

                        If QtCtr > oDataAux.Rows(iCont2).Item("qt_saldo_cp") Then
                            QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo_cp")
                        End If

                        If QtAFixar > QtCtr Then
                            QtFix = QtCtr
                            VlFix = Math.Round(QtFix / QtAFixar * VlAFixar, 2)
                        Else
                            QtFix = QtAFixar
                            VlFix = VlAFixar
                        End If

                        If QtFix <> 0 Then
                            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", ":SQMOV", ":SQMOVCD", _
                                                          ":VLFIXO", ":QTFIXO", ":SQCTRPAFMOV")

                            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("cd_contrato_paf")), _
                                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                       DBParametro_Montar("VLFIXO", VlFix), _
                                                       DBParametro_Montar("QTFIXO", QtFix), _
                                                       DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                            SqCtrPAFMov = DBRetorno(1)

                            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", ":SQNEG", ":SQCTRPAFMOV", ":SQMOV", _
                                                                                          ":SQMOVCD", ":VLFIXO", ":QTFIXO", ":SQCTRPAFNEGMOV")


                            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("cd_contrato_paf")), _
                                                       DBParametro_Montar("SQNEG", oDataAux.Rows(iCont2).Item("sq_negociacao")), _
                                                       DBParametro_Montar("SQCTRPAFMOV", SqCtrPAFMov), _
                                                       DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                       DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                       DBParametro_Montar("VLFIXO", VlFix), _
                                                       DBParametro_Montar("QTFIXO", QtFix), _
                                                       DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro
                        End If

                        VlAFixar = VlAFixar - VlFix
                        QtAFixar = QtAFixar - QtFix

                        If QtAFixar <= 0 Then Exit For
                    Next
                End If

                If QtAFixar > 0 Then
                    SqlText = "select cp.dt_vencimento, cp.cd_contrato_paf, " & _
                              "(cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo) qt_saldo " & _
                              "from sof.contrato_paf cp, sof.tipo_contrato_paf tcp " & _
                              "where tcp.cd_tipo_contrato_paf = cp.cd_tipo_contrato_paf and " & _
                              "cp.cd_fornecedor = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_CodigoFornecedor).Value & " and " & _
                              "cp.ic_status = 'A' and " & _
                              "tcp.ic_adiantamento = 'S' and " & _
                              "(cp.qt_kgs - cp.qt_cancelado) <> cp.qt_kg_fixo " & _
                              "ORDER BY CP.dt_vencimento, CP.cd_contrato_paf"
                    oDataAux = DBQuery(SqlText)

                    For iCont2 = 0 To oDataAux.Rows.Count - 1
                        QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo")

                        If QtAFixar > QtCtr Then
                            QtFix = QtCtr
                            VlFix = Math.Round(QtFix / QtAFixar * VlAFixar, 2)
                        Else
                            QtFix = QtAFixar
                            VlFix = VlAFixar
                        End If

                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", ":SQMOV", ":SQMOVCD", _
                                                            ":VLFIXO", ":QTFIXO", ":SQCTRPAFMOV")

                        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("cd_contrato_paf")), _
                                                   DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                   DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                   DBParametro_Montar("VLFIXO", VlFix), _
                                                   DBParametro_Montar("QTFIXO", QtFix), _
                                                   DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                        VlAFixar = VlAFixar - VlFix
                        QtAFixar = QtAFixar - QtFix

                        If QtAFixar <= 0 Then Exit For

                    Next
                End If

                If QtAFixar > 0 Then
                    SqlText = "select cp.dt_vencimento, cp.cd_contrato_paf, " & _
                              "(cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo) qt_saldo " & _
                              "from sof.contrato_paf cp, sof.tipo_contrato_paf tcp " & _
                              "where tcp.cd_tipo_contrato_paf = cp.cd_tipo_contrato_paf and " & _
                              "cp.cd_fornecedor = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_CodigoFornecedor).Value & " and " & _
                              "cp.ic_status = 'A' and " & _
                              "tcp.ic_adiantamento = 'N' " & _
                              "ORDER BY cp.dt_contrato_paf desc, cp.cd_contrato_paf desc"
                    oDataAux = DBQuery(SqlText)

                    For iCont2 = 0 To oDataAux.Rows.Count - 1
                        QtCtr = oDataAux.Rows(iCont2).Item("qt_saldo")

                        If QtAFixar > QtCtr Then
                            QtFix = QtAFixar - QtCtr

                            SqlText = "UPDATE SOF.contrato_paf "
                            SqlText = SqlText & "SET qt_kgs = qt_kgs + " & QtFix & ", "
                            SqlText = SqlText & "qt_a_negociar = qt_a_negociar + " & QtFix & " "
                            SqlText = SqlText & "WHERE cd_contrato_paf = " & oDataAux.Rows(iCont2).Item("CD_CONTRATO_PAF")
                            If Not DBExecutar(SqlText) Then GoTo erro
                        End If

                        QtFix = QtAFixar
                        VlFix = VlAFixar

                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", ":SQMOV", ":SQMOVCD", _
                                                         ":VLFIXO", ":QTFIXO", ":SQCTRPAFMOV")

                        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oDataAux.Rows(iCont2).Item("cd_contrato_paf")), _
                                                   DBParametro_Montar("SQMOV", objGrid_Valor(grdGeral, cnt_GridGeral_SqMovimentacao, iCont)), _
                                                   DBParametro_Montar("SQMOVCD", objGrid_Valor(grdGeral, cnt_GridGeral_SqCessaoDireito, iCont)), _
                                                   DBParametro_Montar("VLFIXO", VlFix), _
                                                   DBParametro_Montar("QTFIXO", QtFix), _
                                                   DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                        VlAFixar = VlAFixar - VlFix
                        QtAFixar = QtAFixar - QtFix

                        If QtAFixar <= 0 Then Exit For

                    Next

                End If
                If QtAFixar > 0 Then
                    grdGeral.Rows(iCont).Cells(cnt_GridGeral_Informacao).Value = "Não ha espaço nos contratos para essa aplicação"
                Else
                    grdGeral.Rows(iCont).Cells(cnt_GridGeral_Informacao).Value = "Totalmente aplicado"
                End If
            Else
                grdGeral.Rows(iCont).Cells(cnt_GridGeral_Informacao).Value = "Usuario não solicitou"
            End If

            If Not DBExecutarTransacao() Then GoTo Erro

        Next

        grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridGeral_Informacao).Hidden = False
        oForm.ProgressBar.Value = 100
        grdGeral.Refresh()
        oForm.Close()

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub frmAplicacaoAutomatica_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        'Posição vertical
        cmdAtualizar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdGravar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        ExecutaConsulta()
    End Sub
End Class