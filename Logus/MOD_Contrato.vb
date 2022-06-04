Module MOD_Contrato
    Public Function AplicacaoPagamentoContratoPAF(ByVal CdContratoPAF As Integer, _
                                                  ByVal SqPagamento As Integer, _
                                                  ByVal VlAplicado As Double, _
                                                  ByRef SqPagamentoContratoPAF As Integer) As Boolean
        Dim SqlText As String
        Dim bOk As Boolean = False

        SqlText = DBMontar_SP("SOF.SP_INCLUI_PAG_CTR_PAF", False, ":CDCTRPAF", _
                                                                   ":SQPAG", _
                                                                   ":VLFIXO", _
                                                                   ":SQPAGCTRPAF")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", CdContratoPAF), _
                                   DBParametro_Montar("SQPAG", SqPagamento), _
                                   DBParametro_Montar("VLFIXO", VlAplicado), _
                                   DBParametro_Montar("SQPAGCTRPAF", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        If DBTeveRetorno() Then
            SqPagamentoContratoPAF = DBRetorno(1)
        End If

        bOk = True

        GoTo Sair

Erro:
        TratarErro()

Sair:
        Return bOk
    End Function

    Public Function AplicacaoPagamentoNegociacao(ByVal CdContratoPAF As Integer, _
                                                 ByVal SqNegociacao As Integer, _
                                                 ByVal SqPagamento As Integer, _
                                                 ByVal SqPagamentoContratoPAF As Integer, _
                                                 ByVal VlAplicado As Double, _
                                                 ByRef SqPagamentoNegociacao As Integer, _
                                                 Optional ByVal SqPagamentoJuros As Integer = -1, _
                                                 Optional ByVal SqPagamentoJurosCtrPAF As Integer = -1, _
                                                 Optional ByVal SqPagamentoJurosNeg As Integer = -1, _
                                                 Optional ByVal VlJuros As Double = 0, _
                                                 Optional ByVal VlFixoFinal As Double = 0) As Boolean
        Dim SqlText As String
        Dim bOk As Boolean = False

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

        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", CdContratoPAF), _
                                   DBParametro_Montar("SQNEG", SqNegociacao), _
                                   DBParametro_Montar("SQPAG", SqPagamento), _
                                   DBParametro_Montar("SQPAGCTRPAF", SqPagamentoContratoPAF), _
                                   DBParametro_Montar("VLFIXO", VlAplicado), _
                                   DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                                   DBParametro_Montar("DSCONCILIACAO", ""), _
                                   DBParametro_Montar("SQPAGNEG", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQPAGJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLFIXOFINAL", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQPAGCTRPAFJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQPAGNEGJUROS", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        If DBTeveRetorno() Then
            SqPagamentoNegociacao = DBRetorno(1)
            If DBRetorno(2) <> "" Then
                SqPagamentoJuros = DBRetorno(2)
            End If
            If DBRetorno(5) <> "" Then
                SqPagamentoJurosCtrPAF = DBRetorno(5)
            End If
            If DBRetorno(6) <> "" Then
                SqPagamentoJurosNeg = DBRetorno(6)
            End If
            If DBRetorno(3) <> "" Then
                VlJuros = DBRetorno(3)
            End If
            If DBRetorno(4) <> "" Then
                VlFixoFinal = DBRetorno(4)
            End If
        End If

        bOk = True

        GoTo Sair

Erro:
        TratarErro()

Sair:
        Return bOk
    End Function

    Public Function AplicacaoPagamentoContratoFixo(ByVal CdContratoPAF As Integer, _
                                                   ByVal SqNegociacao As Integer, _
                                                   ByVal SqContratoFixo As Integer, _
                                                   ByVal SqPagamento As Integer, _
                                                   ByVal SqPagamentoContratoPAF As Integer, _
                                                   ByVal SqPagamentoNegociacao As Integer, _
                                                   ByVal VlAplicado As Double, _
                                                   ByRef SqPagamentoNegociacaoContratoFixo As Integer, _
                                                   Optional ByVal VlJuros As Double = 0, _
                                                   Optional ByVal VlFixoFinal As Double = 0, _
                                                   Optional ByVal SqCtrFixPagJuros As Double = 0, _
                                                   Optional ByVal SqCtrFixPagJurosCtrPAF As Double = 0, _
                                                   Optional ByVal SqCtrFixPagJurosNeg As Double = 0, _
                                                   Optional ByVal SqCtrFixPagJurosCtrFix As Double = 0) As Boolean
        Dim SqlText As String
        Dim bOk As Boolean = False

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

        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", CdContratoPAF), _
                                   DBParametro_Montar("SQNEG", SqNegociacao), _
                                   DBParametro_Montar("SQCTRFIX", SqContratoFixo), _
                                   DBParametro_Montar("SQPAG", SqPagamento), _
                                   DBParametro_Montar("SQPAGCTRPAF", SqPagamentoContratoPAF), _
                                   DBParametro_Montar("SQPAGNEG", SqPagamentoNegociacao), _
                                   DBParametro_Montar("VLFIXO", VlAplicado), _
                                   DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                                   DBParametro_Montar("DSCONCILIACAO", Nothing), _
                                   DBParametro_Montar("SQPAGNEGCTRFIX", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQPAGJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("VLFIXOFINAL", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQPAGCTRPAFJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQPAGNEGJUROS", Nothing, , ParameterDirection.Output), _
                                   DBParametro_Montar("SQPAGNEGCTRFIXJUROS", Nothing, , ParameterDirection.Output)) Then GoTo Erro

        If DBTeveRetorno() Then
            SqPagamentoNegociacaoContratoFixo = Val(DBRetorno(1))
            VlJuros = Val(DBRetorno(3))
            VlFixoFinal = Val(DBRetorno(4))
            SqCtrFixPagJuros = Val(DBRetorno(3))
            SqCtrFixPagJurosCtrPAF = Val(DBRetorno(5))
            SqCtrFixPagJurosNeg = Val(DBRetorno(6))
            SqCtrFixPagJurosCtrFix = Val(DBRetorno(7))
        End If

        bOk = True

        GoTo Sair

Erro:
        TratarErro()

Sair:
        Return bOk
    End Function

    Public Function Cancela_Contrato_PAF(ByVal CdContratoPAF As Long, ByVal QtCancel As Double, _
                                        ByVal DsMotivo As String, Optional ByVal SqConfissaoDivida As Integer = Nothing) As Boolean
        Dim SqlText As String
        Cancela_Contrato_PAF = False

        SqlText = DBMontar_SP("SOF.SP_MUDA_CANCELAMENTO_CTR_PAF", False, ":NUMCTR", _
                                                                         ":DTCANCEL", _
                                                                         ":QTACANCEL", _
                                                                         ":DSMOTIVO", _
                                                                         ":SQCONFDIV")

        If Not DBExecutar(SqlText, DBParametro_Montar("NUMCTR", CdContratoPAF), _
                                   DBParametro_Montar("DTCANCEL", Date_to_Oracle(DataSistema)), _
                                   DBParametro_Montar("QTACANCEL", QtCancel), _
                                   DBParametro_Montar("DSMOTIVO", DsMotivo), _
                                   DBParametro_Montar("SQCONFDIV", NULLIf(SqConfissaoDivida, 0))) Then GoTo Erro

        Cancela_Contrato_PAF = True

        Exit Function

Erro:
        TratarErro()
    End Function

    Public Function Cancela_Negociacao(ByVal CdContratoPAF As Long, _
                                       ByVal SqNegociacao As Integer, _
                                       ByVal QtCancel As Double, _
                                       ByVal DsMotivo As String, _
                                       ByVal IcEstornoCancelamento As String, _
                                       Optional ByVal SqConfissaoDivida As Integer = Nothing) As Boolean
        Dim SqlText As String

        Cancela_Negociacao = False

        SqlText = DBMontar_SP("SOF.SP_MUDA_CANCELAMENTO_NEG", False, ":NUMCTR", _
                                                                     ":SQNEG", _
                                                                     ":DTCANCEL", _
                                                                     ":QTACANCEL", _
                                                                     ":DSMOTIVO", _
                                                                     ":SQCONFDIV", _
                                                                     ":ICESTORNOCANCELAMENTO")

        If Not DBExecutar(SqlText, DBParametro_Montar("NUMCTR", CdContratoPAF), _
                                   DBParametro_Montar("SQNEG", SqNegociacao), _
                                   DBParametro_Montar("DTCANCEL", Date_to_Oracle(DataSistema)), _
                                   DBParametro_Montar("QTACANCEL", QtCancel), _
                                   DBParametro_Montar("DSMOTIVO", DsMotivo), _
                                   DBParametro_Montar("SQCONFDIV", NULLIf(SqConfissaoDivida, 0)), _
                                   DBParametro_Montar("ICESTORNOCANCELAMENTO", IcEstornoCancelamento)) Then GoTo Erro

        Cancela_Negociacao = True

        Exit Function

Erro:
        TratarErro()
    End Function

    Public Function Cancela_Contrato_Fixo(ByVal CdContratoPAF As Long, ByVal SqNegociacao As Integer, ByVal SqCtrFixo As Integer, ByVal QtCancel As Double, _
                                            ByVal DsMotivo As String, Optional ByVal SqConfissaoDivida As Integer = Nothing) As Boolean
        Dim SqlText As String

        Cancela_Contrato_Fixo = False

        SqlText = DBMontar_SP("SOF.SP_MUDA_CANCELAMENTO_CTR_FIX", False, ":NUMCTR", _
                                                                         ":SQNEG", _
                                                                         ":SQCTRFIX", _
                                                                         ":DTCANCEL", _
                                                                         ":QTACANCEL", _
                                                                         ":DSMOTIVO", _
                                                                         ":SQCONFDIV")

        If Not DBExecutar(SqlText, DBParametro_Montar("NUMCTR", CdContratoPAF), _
                                   DBParametro_Montar("SQNEG", SqNegociacao), _
                                   DBParametro_Montar("SQCTRFIX", SqCtrFixo), _
                                   DBParametro_Montar("DTCANCEL", Date_to_Oracle(DataSistema)), _
                                   DBParametro_Montar("QTACANCEL", QtCancel), _
                                   DBParametro_Montar("DSMOTIVO", DsMotivo), _
                                   DBParametro_Montar("SQCONFDIV", NULLIf(SqConfissaoDivida, 0))) Then GoTo Erro

        Cancela_Contrato_Fixo = True

        Exit Function

Erro:
        TratarErro()
    End Function

    Public Function Verifica_Situacao_Contrato(ByVal CdCtrPAF As Long, ByVal SqNeg As Integer, ByVal SqCtrFix As Integer) As Boolean
        Dim SqlText As String
        Dim IcCtrPAF As String
        Dim IcNeg As String
        Dim IcCtrFix As String

        SqlText = "select ic_status from sof.contrato_paf " & _
                  "where cd_contrato_paf = " & CdCtrPAF
        IcCtrPAF = DBQuery_ValorUnico(SqlText)

        SqlText = "select ic_status from sof.negociacao " & _
                  "where cd_contrato_paf = " & CdCtrPAF & " and " & _
                  "sq_negociacao = " & SqNeg
        IcNeg = DBQuery_ValorUnico(SqlText)

        If SqCtrFix <> -1 Then 'se for de uma negociacao
            SqlText = "select ic_status from sof.contrato_fixo " & _
                             "where cd_contrato_paf = " & CdCtrPAF & " and " & _
                             "sq_negociacao = " & SqNeg & " and " & _
                             "sq_contrato_fixo = " & SqCtrFix
            IcCtrFix = DBQuery_ValorUnico(SqlText)
        Else
            IcCtrFix = "A"
        End If

        If IcCtrPAF = "F" Or IcNeg = "F" Or IcCtrFix = "F" Then
            If Msg_Perguntar("Contrato fechado, deseja abrir?") = False Then
                Verifica_Situacao_Contrato = False
                Exit Function
            End If
        End If

        If IcCtrPAF = "F" Then
            MUDA_SITUACAO_CONTRATO_PAF(CdCtrPAF, "A")
        End If
        If IcNeg = "F" Then
            MUDA_SITUACAO_NEGOCIACAO(CdCtrPAF, SqNeg, "A")
        End If
        If IcCtrFix = "F" Then
            MUDA_SITUACAO_CONTRATO_FIXO(CdCtrPAF, SqNeg, SqCtrFix, "A")
        End If

        Verifica_Situacao_Contrato = True
    End Function

    Public Sub MUDA_SITUACAO_NEGOCIACAO(ByVal CtrPaf As Long, ByVal SqNeg As Integer, ByVal Situacao As String)
        Dim SqlText As String
        Dim oData As DataTable
        Dim oDataAux As DataTable

        SqlText = "select * from sof.negociacao n where n.cd_contrato_paf =" & CtrPaf & _
                  " and n.sq_negociacao=" & SqNeg

        oData = DBQuery(SqlText)

        If Situacao = "F" Then
            If oData.Rows(0).Item("qt_a_fixar") <> 0 Then
                Msg_Mensagem("A negociação ainda não foi totalmente fixada/cancelada.")
                Exit Sub
            End If

            If oData.Rows(0).Item("qt_kgs") - oData.Rows(0).Item("qt_cancelado") <> oData.Rows(0).Item("qt_kg_fixo") Then
                Msg_Mensagem("A negociação ainda não foi totalmente entregue.")
                Exit Sub
            End If

            SqlText = "SELECT round(SUM(sof.FC_SALDO_CTR_FIX(cf.cd_contrato_paf,cf.sq_negociacao ,cf.sq_contrato_fixo )),2) VL_SALDO, " & _
                      "COUNT(CF.SQ_CONTRATO_FIXO) AS QT, MAX(CF.SQ_CONTRATO_FIXO) SQ_CONTRATO_FIXO " & _
                      "FROM SOF.contrato_fixo CF " & _
                      "WHERE CF.cd_contrato_paf = " & oData.Rows(0).Item("cd_contrato_paf") & " AND " & _
                      "CF.sq_negociacao = " & oData.Rows(0).Item("sq_negociacao") & " and cf.ic_status <> 'E'"
            oDataAux = DBQuery(SqlText)

            If oDataAux.Rows.Count = 0 Then
                Msg_Mensagem("Ainda existe saldo a pagar na negociação.")
                Exit Sub
            End If

            If oDataAux.Rows(0).Item("vl_saldo") - oData.Rows(0).Item("vl_pag_fixo") > 0 Then
                Msg_Mensagem("Esse contrato ainda existe saldo para pagamento.")
                Exit Sub
            End If
            If oDataAux.Rows(0).Item("vl_saldo") - oData.Rows(0).Item("vl_pag_fixo") < 0 Then
                Msg_Mensagem("Esse contrato esta com pagamentos a maior.")
                Exit Sub
            End If
        End If

        SqlText = DBMontar_SP("SOF.SP_MUDA_SITUACAO_NEGOCIACAO", False, ":NUMCTR", _
                                                                   ":SQNEG", _
                                                                   ":SITUACAO")

        If Not DBExecutar(SqlText, DBParametro_Montar("NUMCTR", oData.Rows(0).Item("cd_contrato_paf")), _
                                   DBParametro_Montar("SQNEG", oData.Rows(0).Item("sq_negociacao")), _
                                   DBParametro_Montar("SITUACAO", Situacao)) Then GoTo Erro


        Exit Sub
Erro:
        TratarErro()
    End Sub

    Public Sub MUDA_SITUACAO_CONTRATO_FIXO(ByVal CtrPaf As Long, ByVal SqNeg As Integer, ByVal SqCtrFix As Integer, ByVal Situacao As String)
        Dim Sqltext As String


        Sqltext = DBMontar_SP("SOF.SP_MUDA_SITUACAO_CONTRATO_FIXO", False, ":NUMCTR", _
                                                           ":SQNEG", _
                                                           ":CTRFIX", _
                                                           ":SITUACAO")

        If Not DBExecutar(Sqltext, DBParametro_Montar("NUMCTR", CtrPaf), _
                                   DBParametro_Montar("SQNEG", SqNeg), _
                                   DBParametro_Montar("CTRFIX", SqCtrFix), _
                                   DBParametro_Montar("SITUACAO", Situacao)) Then GoTo Erro

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Public Sub MUDA_SITUACAO_CONTRATO_PAF(ByVal CtrPaf As Long, ByVal Situacao As String)
        Dim SqlText As String
        Dim oData As DataTable
        Dim oDataAux As DataTable

        SqlText = "select * from sof.contrato_paf cp where cp.cd_contrato_paf =" & CtrPaf
        oData = DBQuery(SqlText)

        If Situacao = "F" Then
            SqlText = "SELECT NVL(SUM(PCP.VL_A_FIXAR),0) VL " & _
                      "FROM SOF.PAG_CTR_PAF PCP " & _
                      "WHERE PCP.CD_CONTRATO_PAF = " & oData.Rows(0).Item("cd_contrato_paf")

            If DBQuery_ValorUnico(SqlText) <> 0 Then
                Msg_Mensagem("Contrato Paf ainda existe pagamento em aberto.")
                Exit Sub
            End If
        Else
            SqlText = "SELECT f.cd_repassador  "
            SqlText = SqlText & "  FROM sof.contrato_paf cp, sof.fornecedor f "
            SqlText = SqlText & " WHERE cp.cd_fornecedor = f.cd_fornecedor "
            SqlText = SqlText & "   AND cp.cd_repassador <> f.cd_repassador "
            SqlText = SqlText & "   and cp.CD_CONTRATO_PAF = " & oData.Rows(0).Item("cd_contrato_paf")
            oDataAux = DBQuery(SqlText)

            If oDataAux.Rows.Count <> 0 Then
                SqlText = "update sof.contrato_paf cp "
                SqlText = SqlText & "set cp.cd_repassador= " & oDataAux.Rows(0).Item("cd_repassador")
                SqlText = SqlText & "where cp.CD_CONTRATO_PAF = " & oData.Rows(0).Item("cd_contrato_paf")

                DBExecutar(SqlText)
            End If

        End If

        SqlText = DBMontar_SP("SOF.sp_muda_situacao_contrato_paf", False, ":NUMCTR", _
                                                           ":SITUACAO")

        If Not DBExecutar(SqlText, DBParametro_Montar("NUMCTR", oData.Rows(0).Item("cd_contrato_paf")), _
                                   DBParametro_Montar("SITUACAO", Situacao)) Then GoTo Erro

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Public Function Elimina_Pag_Ctr_Fix(ByVal CdCtrPAF As Long, _
                                    ByVal SqNeg As Long, _
                                    ByVal SqCtrFix As Long, _
                                    ByVal SqPag As Long, _
                                    ByVal SqPagCtrPAF As Integer, _
                                    ByVal SqPagNeg As Integer, _
                                    ByVal SqPagNegCtrFix As Integer) As Boolean

        Dim SqlText As String
        Dim SqPagJuros As Long
        Dim oData As DataTable
        Dim iCont As Integer

        SqlText = "select sq_pagamento_juros " & _
                  "from sof.PAG_NEG_CTR_FIX_JUROS " & _
                  "WHERE CD_CONTRATO_PAF = " & CdCtrPAF & " AND " & _
                  "SQ_NEGOCIACAO = " & SqNeg & " AND " & _
                  "SQ_CONTRATO_FIXO = " & SqCtrFix & " AND " & _
                  "SQ_PAGAMENTO = " & SqPag & " AND " & _
                  "SQ_PAG_CTR_PAF = " & SqPagCtrPAF & " AND " & _
                  "SQ_PAG_NEG = " & SqPagNeg & " AND " & _
                  "SQ_PAG_NEG_CTR_FIX = " & SqPagNegCtrFix

        SqPagJuros = DBQuery_ValorUnico(SqlText, -1)


        If SqPagJuros <> -1 Then
            SqlText = "delete from sof.PAG_NEG_CTR_FIX_JUROS " & _
                      "WHERE CD_CONTRATO_PAF = " & CdCtrPAF & " AND " & _
                      "SQ_NEGOCIACAO = " & SqNeg & " AND " & _
                      "SQ_CONTRATO_FIXO = " & SqCtrFix & " AND " & _
                      "SQ_PAGAMENTO = " & SqPag & " AND " & _
                      "SQ_PAG_CTR_PAF = " & SqPagCtrPAF & " AND " & _
                      "SQ_PAG_NEG = " & SqPagNeg & " AND " & _
                      "SQ_PAG_NEG_CTR_FIX = " & SqPagNegCtrFix
            DBExecutar(SqlText)

            If Not Estorno_juros(CdCtrPAF, SqNeg, SqPagJuros) Then Return False
        End If

        SqlText = "select pnj.sq_pagamento_juros "
        SqlText = SqlText & "from sof.pag_neg_juros pnj "
        SqlText = SqlText & "where pnj.cd_contrato_paf = " & CdCtrPAF & " and "
        SqlText = SqlText & "      pnj.sq_negociacao = " & SqNeg & " and "
        SqlText = SqlText & "      pnj.sq_pagamento = " & SqPag & " and "
        SqlText = SqlText & "      pnj.sq_pag_neg = " & SqPagNeg & " and "
        SqlText = SqlText & "      pnj.sq_pag_ctr_paf = " & SqPagCtrPAF & " and "
        SqlText = SqlText & "      pnj.sq_contrato_fixo = " & SqCtrFix & " AND "
        SqlText = SqlText & "      PNJ.sq_pag_neg_ctr_fix = " & SqPagNegCtrFix & " "

        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            For iCont = 0 To oData.Rows.Count - 1
                SqPagJuros = oData.Rows(iCont).Item("sq_pagamento_juros")

                SqlText = "delete from sof.pag_neg_juros "
                SqlText = SqlText & "where cd_contrato_paf = " & CdCtrPAF & " and "
                SqlText = SqlText & "      sq_negociacao = " & SqNeg & " and "
                SqlText = SqlText & "      sq_pagamento = " & SqPag & " and "
                SqlText = SqlText & "      sq_pag_neg = " & SqPagNeg & " and "
                SqlText = SqlText & "      sq_pag_ctr_paf = " & SqPagCtrPAF & " and "
                SqlText = SqlText & "      sq_contrato_fixo = " & SqCtrFix & " AND "
                SqlText = SqlText & "      sq_pag_neg_ctr_fix = " & SqPagNegCtrFix & " "

                DBExecutar(SqlText)

                If Not Estorno_juros(CdCtrPAF, SqNeg, SqPagJuros) Then Return False



                SqlText = DBMontar_SP("SOF.SP_CALCULA_JUROS_NEG", False, ":CDCTRPAF", _
                                                          ":SQNEG", _
                                                          ":SQPAG", _
                                                          ":SQPAGCTRPAF", _
                                                          ":SQPAGNEG")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", CdCtrPAF), _
                                           DBParametro_Montar("SQNEG", SqNeg), _
                                           DBParametro_Montar("SQPAG", SqPag), _
                                           DBParametro_Montar("SQPAGCTRPAF", SqPagCtrPAF), _
                                           DBParametro_Montar("SQPAGNEG", SqPagNeg)) Then Return False
            Next
        End If

        SqlText = "DELETE FROM SOF.PAG_NEG_CTR_FIX " & _
                  "WHERE CD_CONTRATO_PAF = " & CdCtrPAF & " AND " & _
                  "SQ_NEGOCIACAO = " & SqNeg & " AND " & _
                  "SQ_CONTRATO_FIXO = " & SqCtrFix & " AND " & _
                  "SQ_PAGAMENTO = " & SqPag & " AND " & _
                  "SQ_PAG_CTR_PAF = " & SqPagCtrPAF & " AND " & _
                  "SQ_PAG_NEG = " & SqPagNeg & " AND " & _
                  "SQ_PAG_NEG_CTR_FIX = " & SqPagNegCtrFix
        DBExecutar(SqlText)

        Return True
    End Function

    Public Function Estorno_juros(ByVal CdCtrPAF As Long, ByVal SqNeg As Long, ByVal SqPag As Long) As Boolean
        Dim SqlText As String

        SqlText = DBMontar_SP("SOF.SP_ESTORNO_JUROS", False, ":CDCTRPAF", _
                                                             ":SQNEG", _
                                                             ":SQPAG")

        Return DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", CdCtrPAF), _
                                   DBParametro_Montar("SQNEG", SqNeg), _
                                   DBParametro_Montar("SQPAG", SqPag))
    End Function

    Public Function Elimina_Pag_neg(ByVal CdCtrPAF As Long, _
                                ByVal SqNeg As Long, _
                                ByVal SqPag As Long, _
                                ByVal SqPagCtrPAF As Integer, _
                                ByVal SqPagNeg As Integer) As Boolean
        Dim SqlText As String
        Dim SqPagJuros As Long
        Dim oData As DataTable
        Dim iCont As Integer

        SqlText = "select sq_pagamento_juros " & _
                  "from sof.pag_neg_juros " & _
                  "WHERE CD_CONTRATO_PAF = " & CdCtrPAF & " AND " & _
                  "SQ_NEGOCIACAO = " & SqNeg & " AND " & _
                  "SQ_PAGAMENTO = " & SqPag & " AND " & _
                  "SQ_PAG_CTR_PAF = " & SqPagCtrPAF & " AND " & _
                  "SQ_PAG_NEG = " & SqPagNeg
        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            SqlText = "delete from sof.pag_neg_juros " & _
                      "WHERE CD_CONTRATO_PAF = " & CdCtrPAF & " AND " & _
                      "SQ_NEGOCIACAO = " & SqNeg & " AND " & _
                      "SQ_PAGAMENTO = " & SqPag & " AND " & _
                      "SQ_PAG_CTR_PAF = " & SqPagCtrPAF & " AND " & _
                      "SQ_PAG_NEG = " & SqPagNeg
            If Not DBExecutar(SqlText) Then Return False
        End If

        SqlText = "delete from sof.pag_neg " & _
                  "WHERE CD_CONTRATO_PAF = " & CdCtrPAF & " AND " & _
                  "SQ_NEGOCIACAO = " & SqNeg & " AND " & _
                  "SQ_PAGAMENTO = " & SqPag & " AND " & _
                  "SQ_PAG_CTR_PAF = " & SqPagCtrPAF & " AND " & _
                  "SQ_PAG_NEG = " & SqPagNeg
        If Not DBExecutar(SqlText) Then Return False


        If oData.Rows.Count > 0 Then
            For iCont = 0 To oData.Rows.Count - 1
                SqPagJuros = oData.Rows(iCont).Item("sq_pagamento_juros")

                If Not Estorno_juros(CdCtrPAF, SqNeg, SqPagJuros) Then Return False
            Next
        End If
        Return True
    End Function

    Public Sub Aplica_Cacau_Contrato_PAF(ByVal CdCtrPAF As Long, _
                                         ByVal QtCtr As Long, _
                                         ByVal CdCtrPaFNovo As Long, _
                                         ByVal IcPosto As Boolean, _
                                         Optional ByVal cdPosto As Integer = -1, _
                                         Optional ByVal cdFilialPosto As Integer = -1, _
                                         Optional ByVal CdFilial As Integer = -1)
        Dim SqlText As String
        Dim VlFix As Double
        Dim VlFixado As Double
        Dim QtFix As Long
        Dim QtFixado As Long
        Dim AplicPostoDif As Boolean
        Dim VlFrete As Double
        Dim oData As DataTable
        Dim iCont As Integer

        If CdFilial = -1 Then
            CdFilial = FilialLogada
        End If

        SqlText = "SELECT IC_APLIC_POSTO_DIFERENTE FROM SOF.FILIAL WHERE CD_FILIAL = " & CdFilial
        AplicPostoDif = IIf(DBQuery_ValorUnico(SqlText) = "S", True, False)

        'pego o valor do frete
        SqlText = "SELECT DECODE(" & cdPosto & ", 1, FIL.VL_FRETE_FILIAL_FAZENDA," & _
                                                 "2, FIL.VL_FRETE_FILIAL_FABRICA," & _
                                                 "3, FIL.VL_FRETE_FABRICA, 0) AS VALOR_FRETE" & _
                  " FROM SOF.CONTRATO_PAF CP," & _
                        "SOF.FILIAL FIL" & _
                  " WHERE CP.CD_CONTRATO_PAF =  " & CdCtrPaFNovo & _
                    " AND CP.CD_FILIAL_ENTREGA = FIL.CD_FILIAL"
        VlFrete = DBQuery_ValorUnico(SqlText)

        If IcPosto = False Then
            SqlText = "SELECT CPM.QT_KG_A_FIXAR," & _
                             "CPM.VL_A_FIXAR," & _
                             "M.VL_NF," & _
                             "M.QT_KG_LIQUIDO_NF," & _
                             "CPM.SQ_CTR_PAF_MOVIMENTACAO," & _
                             "CPM.SQ_MOVIMENTACAO," & _
                             "CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                             "CPM.QT_KG_FIXO," & _
                             "CPM.VL_FIXO" & _
                      " FROM SOF.CTR_PAF_MOVIMENTACAO CPM," & _
                            "SOF.MOVIMENTACAO M " & _
                      " WHERE M.SQ_MOVIMENTACAO = CPM.SQ_MOVIMENTACAO" & _
                        " AND CPM.CD_CONTRATO_PAF = " & CdCtrPAF & _
                        " AND CPM.QT_KG_A_FIXAR <> 0" & _
                      " ORDER BY M.SQ_MOVIMENTACAO"
        Else
            SqlText = "SELECT CPM.QT_KG_A_FIXAR," & _
                             "CPM.VL_A_FIXAR," & _
                             "M.VL_NF," & _
                             "M.QT_KG_LIQUIDO_NF," & _
                             "CPM.SQ_CTR_PAF_MOVIMENTACAO," & _
                             "CPM.SQ_MOVIMENTACAO," & _
                             "CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                             "CPM.QT_KG_FIXO," & _
                             "CPM.VL_FIXO" & _
                      " FROM SOF.CTR_PAF_MOVIMENTACAO CPM," & _
                            "SOF.MOVIMENTACAO M," & _
                            "SOF.FILIAL FIL" & _
                      " WHERE M.SQ_MOVIMENTACAO = CPM.SQ_MOVIMENTACAO" & _
                        " AND M.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                        " AND CPM.CD_CONTRATO_PAF = " & CdCtrPAF & _
                        " AND CPM.QT_KG_A_FIXAR <> 0" & _
                        " AND NVL(DECODE(M.CD_LOCAL_ENTREGA, 1, FIL.VL_FRETE_FILIAL_FAZENDA, 2, FIL.VL_FRETE_FILIAL_FABRICA, 3, FIL.VL_FRETE_FABRICA, 0)," & ConvValorFormatoAmericano(VlFrete) & ") = " & ConvValorFormatoAmericano(VlFrete)

            If cdPosto <> 3 And Not AplicPostoDif Then
                SqlText = SqlText & _
                          " AND M.CD_FILIAL_MOVIMENTACAO = " & cdFilialPosto & " "
            End If

            SqlText = SqlText & _
                      " ORDER BY M.SQ_MOVIMENTACAO"
        End If

        oData = DBQuery(SqlText)

        VlFixado = 0
        QtFixado = 0

        For iCont = 0 To oData.Rows.Count - 1
            If QtFixado + oData.Rows(iCont).Item("QT_KG_A_FIXAR") > QtCtr Then
                QtFix = QtCtr - QtFixado
                VlFix = Math.Round(QtFix / oData.Rows(iCont).Item("QT_KG_A_FIXAR") * oData.Rows(iCont).Item("VL_A_FIXAR"), 2)

                SqlText = "UPDATE SOF.CTR_PAF_MOVIMENTACAO" & _
                          " SET VL_FIXO = VL_FIXO - " & VlFix & "," & _
                               "VL_A_FIXAR = VL_A_FIXAR - " & VlFix & "," & _
                               "QT_KG_FIXO = QT_KG_FIXO - " & QtFix & "," & _
                               "QT_KG_A_FIXAR = QT_KG_A_FIXAR - " & QtFix & _
                          " WHERE SQ_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO") & _
                            " AND SQ_MOVIMENTACAO_CESSAO_DIREITO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & _
                            " AND CD_CONTRATO_PAF = " & CdCtrPAF & _
                            " AND SQ_CTR_PAF_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_CTR_PAF_MOVIMENTACAO")
                If Not DBExecutar(SqlText) Then GoTo erro
            Else
                QtFix = oData.Rows(iCont).Item("QT_KG_A_FIXAR")
                VlFix = oData.Rows(iCont).Item("VL_A_FIXAR")

                If oData.Rows(iCont).Item("QT_KG_FIXO") = oData.Rows(iCont).Item("QT_KG_A_FIXAR") And _
                   oData.Rows(iCont).Item("VL_FIXO") = oData.Rows(iCont).Item("VL_A_FIXAR") Then
                    SqlText = "DELETE FROM SOF.CTR_PAF_MOVIMENTACAO " & _
                              " WHERE SQ_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO") & _
                                " AND SQ_MOVIMENTACAO_CESSAO_DIREITO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & _
                                " AND CD_CONTRATO_PAF = " & CdCtrPAF & _
                                " AND SQ_CTR_PAF_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_CTR_PAF_MOVIMENTACAO")
                Else
                    SqlText = "UPDATE SOF.CTR_PAF_MOVIMENTACAO " & _
                              " SET VL_FIXO = VL_FIXO - " & VlFix & "," & _
                                   "VL_A_FIXAR = VL_A_FIXAR - " & VlFix & "," & _
                                   "QT_KG_FIXO = QT_KG_FIXO - " & QtFix & "," & _
                                   "QT_KG_A_FIXAR = QT_KG_A_FIXAR - " & QtFix & _
                              " WHERE SQ_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO") & _
                                " AND SQ_MOVIMENTACAO_CESSAO_DIREITO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & _
                                " AND CD_CONTRATO_PAF = " & CdCtrPAF & _
                                " AND SQ_CTR_PAF_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_CTR_PAF_MOVIMENTACAO")
                End If

                If Not DBExecutar(SqlText) Then GoTo erro
            End If

            SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", ":SQMOV", ":SQMOVCD", ":VLFIXO", ":QTFIXO", ":SQCTRPAFMOV")

            If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", CdCtrPaFNovo), _
                                       DBParametro_Montar("SQMOV", oData.Rows(iCont).Item("SQ_MOVIMENTACAO")), _
                                       DBParametro_Montar("SQMOVCD", oData.Rows(iCont).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO")), _
                                       DBParametro_Montar("VLFIXO", VlFix), _
                                       DBParametro_Montar("QTFIXO", QtFix), _
                                       DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

            VlFixado = VlFixado + VlFix
            QtFixado = QtFixado + QtFix

            If QtFixado = QtCtr Then Exit For
        Next

        Exit Sub

Erro:
        TratarErro(, , "MOD_Contrato.Aplica_Cacau_Contrato_PAF", "Contrato PAF: " & CdCtrPAF & " - Mov. Nº:" & oData.Rows(iCont).Item("SQ_MOVIMENTACAO"))
    End Sub

    Public Function ContratoPAF_CapturaEnderecoEMail(ByVal CD_ContratoPAF As Long) As String
        Dim SqlText As String

        SqlText = "SELECT FRN.DS_EMAIL" & _
                  " FROM SOF.CONTRATO_PAF PAF," & _
                        "SOF.FORNECEDOR FRN" & _
                  " WHERE PAF.CD_CONTRATO_PAF = " & CD_ContratoPAF & _
                    " AND FRN.CD_FORNECEDOR = PAF.CD_FORNECEDOR"
        Return DBQuery_ValorUnico(SqlText, "")
    End Function

    Public Sub ContratoFixo_Impostos_Recalcular(ByVal CD_CONTRATO_PAF As Integer, _
                                                ByVal SQ_NEGOCIACAO As Integer, _
                                                ByVal SQ_CONTRATO_FIXO As Integer, _
                                                ByVal QT_FIXO As Double, _
                                                ByVal VL_UNITARIO As Double, _
                                                ByVal VL_ALIQUOTA_ICMS As Double, _
                                                ByRef VL_ADENDO_ICMS As Double, _
                                                ByRef VL_ADENDO_INSS As Double, _
                                                ByRef VLTOTAL As Double, _
                                                ByRef VLICMS As Double, _
                                                ByRef VLINSS As Double)
        Dim oData As DataTable
        Dim SqlText As String
        Dim QTKGS As Double
        Dim VLADENDO As Double
        Dim VLIMPOSTOS As Double
        Dim VLTOTALIMP As Double

        SqlText = "SELECT VL_ADENDO_CONTRATO" & _
                  " FROM SOF.CONTRATO_FIXO_ADENDO" & _
                  " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND SQ_NEGOCIACAO = " & SQ_NEGOCIACAO & _
                    " AND SQ_CONTRATO_FIXO = " & SQ_CONTRATO_FIXO
        VLADENDO = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT TU.QT_FATOR QTFATOR," & _
                         "CF.QT_KGS QTKGS," & _
                         "FUN.VL_TAXA PCALIQINSS," & _
                         "CF.QT_CANCELADO" & _
                  " FROM SOF.CONTRATO_FIXO CF," & _
                        "SOF.CONTRATO_PAF CT," & _
                        "SOF.TIPO_UNIDADE TU," & _
                        "SOF.FUNRURAL FUN," & _
                        "SOF.FORNECEDOR F" & _
                  " WHERE CF.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND CF.SQ_NEGOCIACAO = " & SQ_NEGOCIACAO & _
                    " AND CF.SQ_CONTRATO_FIXO = " & SQ_CONTRATO_FIXO & _
                    " AND CT.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                    " AND TU.CD_TIPO_UNIDADE = CF.CD_TIPO_UNIDADE" & _
                    " AND F.CD_FORNECEDOR = CT.CD_FORNECEDOR" & _
                    " AND FUN.CD_FUNRURAL = F.CD_FUNRURAL"
        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            With oData.Rows(0)
                QTKGS = (QT_FIXO - NVL(.Item("QT_CANCELADO"), 0))

                VLIMPOSTOS = ((VL_UNITARIO / .Item("QTFATOR")) * QTKGS) / (1 - ((VL_ALIQUOTA_ICMS + .Item("PCALIQINSS")) / 100))
                VLTOTAL = Math.Round((VL_UNITARIO / .Item("QTFATOR")) * QTKGS, 2)
                VLICMS = Math.Round(VLIMPOSTOS * (VL_ALIQUOTA_ICMS / 100), 2)
                VLINSS = Math.Round(VLIMPOSTOS * (.Item("PCALIQINSS") / 100), 2)

                VLTOTALIMP = VLADENDO / (1 - ((VL_ALIQUOTA_ICMS + .Item("PCALIQINSS")) / 100))
                VL_ADENDO_ICMS = VLTOTALIMP * (VL_ALIQUOTA_ICMS / 100)
                VL_ADENDO_INSS = VLTOTALIMP * (.Item("PCALIQINSS") / 100)
            End With
        End If

        objData_Finalizar(oData)
    End Sub

    Public Function Inclui_PreNegociacao(ByVal CD_ContratoPAF As Long, _
                                         ByVal SQ_Negociacao As Integer, _
                                         ByVal QT_Cancelamento As Double, _
                                         ByVal NO_Razao_Social As String) As Boolean
        Dim SqlText As String

        SqlText = "INSERT INTO SOF.NEGOCIACAO_PRE" & _
                  "(SQ_NEGOCIACAO_PRE," & _
                   "CD_TIPO_NEGOCIACAO," & _
                   "CD_TIPO_PRECO," & _
                   "CD_TIPO_UNIDADE," & _
                   "DT_NEGOCIACAO," & _
                   "QT_KGS," & _
                   "VL_NEGOCIACAO," & _
                   "CD_LOCAL_ENTREGA," & _
                   "DT_VENCIMENTO," & _
                   "DT_PAGAMENTO," & _
                   "VL_PRECO_FRETE," & _
                   "VL_BOLSA," & _
                   "VL_TAXA_DOLAR," & _
                   "VL_BOLSA_ALTERNATIVO," & _
                   "VL_TAXA_DOLAR_ALTERNATIVO," & _
                   "CD_PAPEL," & _
                   "VL_DIFERENCIAL," & _
                   "DT_CRIACAO," & _
                   "NO_USER_CRIACAO," & _
                   "CD_PAPEL_COMPETENCIA," & _
                   "VL_PREMIO_UNITARIO," & _
                   "DS_PREMIO_GRUPO," & _
                   "QT_SALDO," & _
                   "CD_FILIAL_ORIGEM," & _
                   "DS_FORNECEDOR," & _
                   "CD_TIPO_CACAU," & _
                   "CD_FILIAL_ENTREGA," & _
                   "IC_CALCULA_JUROS," & _
                   "QT_DIA_CARENCIA_JUROS," & _
                   "IC_JUROS_APOS_CARENCIA," & _
                   "PC_TAXA_JUROS)" & _
                   "SELECT SOF.SEQ_NEGOCIACAO_PRE.NEXTVAL," & _
                          "N.CD_TIPO_NEGOCIACAO," & _
                          "N.CD_TIPO_PRECO," & _
                          "N.CD_TIPO_UNIDADE," & _
                          QuotedStr(Date_to_Oracle(DataSistema)) & "," & _
                          QT_Cancelamento & "," & _
                          "N.VL_NEGOCIACAO," & _
                          "N.CD_LOCAL_ENTREGA," & _
                          "N.DT_VENCIMENTO," & _
                          "N.DT_PAGAMENTO," & _
                          "N.VL_PRECO_FRETE," & _
                          "N.VL_BOLSA," & _
                          "N.VL_TAXA_DOLAR," & _
                          "N.VL_BOLSA_ALTERNATIVO," & _
                          "N.VL_TAXA_DOLAR_ALTERNATIVO," & _
                          "N.CD_PAPEL," & _
                          "N.VL_DIFERENCIAL," & _
                          "SYSDATE," & _
                          QuotedStr(sAcesso_UsuarioLogado) & "," & _
                          "N.CD_PAPEL_COMPETENCIA," & _
                          "N.VL_PREMIO_UNITARIO," & _
                          "N.DS_PREMIO_GRUPO," & _
                          QT_Cancelamento & "," & _
                          FilialLogada & "," & _
                          QuotedStr("CANCELAMENTO " & NO_Razao_Social) & "," & _
                          "N.CD_TIPO_CACAU," & _
                          "N.CD_FILIAL_ENTREGA," & _
                          "N.IC_CALCULA_JUROS," & _
                          "N.QT_DIA_CARENCIA_JUROS," & _
                          "N.IC_JUROS_APOS_CARENCIA," & _
                          "N.PC_TAXA_JUROS" & _
                   " FROM SOF.NEGOCIACAO N" & _
                   " WHERE CD_CONTRATO_PAF = " & CD_ContratoPAF & _
                     " AND SQ_NEGOCIACAO = " & SQ_Negociacao

        Return DBExecutar(SqlText)
    End Function

    Public Sub Imprimir_ContratoPAF(ByVal CD_CONTRATO_PAF As String, _
                                    Optional ByVal ContratoPAF As Boolean = False, _
                                    Optional ByVal RelGeral_Tipo As frmRelatorioGeral.enRelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContratoPAF)
        Dim oForm As New frmRelatorioGeral
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT * " & _
                  " FROM SOF.CONTRATO" & _
                  " WHERE CD_CONTRATO = " & CD_CONTRATO_PAF
        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 And Not ContratoPAF Then
            oForm.Filtro01 = oData.Rows(0).Item("CD_CONTRATO")

            Select Case oData.Rows(0).Item("CD_TIPO_CONTRATO")
                Case cnt_TipoContrato_PadraoPara
                    oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContratoCarta
                Case cnt_TipoContrato_PadraoFiliais
                    oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContratoFilial
                Case cnt_TipoContrato_AFixar_Filiais
                    oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContratoAFixar
                Case cnt_TipoContrato_AFixar_Transporta
                    oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContratoPrecoAFixar_Transporte
                Case cnt_TipoContrato_AFixar_Preposto
                    oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContratoPrecoAFixar_Preposto
                Case cnt_TipoContrato_AFixar_Fax
                    oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContratoPrecoAFixar_Fax
                Case cnt_TipoContrato_AFixar_DtLimite
                    oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContratoPrecoAFixar_DtLimite
                Case cnt_TipoContrato_FixoSemADTO
                    oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContratoPrecoFixo_SemAdiantamento
                Case cnt_TipoContrato_FixoComADTO_5050
                    oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContratoPrecoFixo_ComAditamento_5050
                Case cnt_TipoContrato_FixoComADTOValor
                    oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContratoPrecoFixo_ComAditamento_Valor
                Case cnt_TipoContrato_FixoComADTOTotal
                    oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContratoPrecoFixo_ComAditamento_Total
                Case Else
                    oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eContrato_Outros
            End Select

            Form_Show(Nothing, oForm)
        Else
            oForm.Filtro01 = CD_CONTRATO_PAF
            oForm.RelGeral_Tipo = RelGeral_Tipo

            Form_Show(Nothing, oForm)
        End If
    End Sub

    Public Function Revisao_de_Contratos(ByVal Confirma As Boolean, Optional ByVal CdContratoPAF As Long = -1, Optional ByVal SegundaVez As Boolean = False) As Boolean
        Dim SqlText As String
        Dim VlFix As Double
        Dim VlFixado As Double
        Dim VlCtr As Double
        Dim SqPagNeg As Long
        Dim SqPagNegCtrFix As Long  'Novo
        Dim SqPagJuros As Long
        Dim SqPagJurosCtrPAF As Long
        Dim SqPagJurosNeg As Long
        Dim VlJuros As Double
        Dim QtCtr As Long
        Dim QtFix As Long
        Dim QtFixado As Long
        Dim QtNeg As Long
        Dim CdLocal As Long
        Dim VlLocal As Double
        Dim SqCtrPAFNegMov As Long
        Dim SqCtrPAFMov As Long
        Dim TextoErro As String
        Dim AplicPostoDif As Boolean
        Dim ExecutaNovamente As Boolean
        Dim oData As DataTable
        Dim iCont As Integer  'Novo
        Dim oDataAux As DataTable
        Dim oDataAux2 As DataTable
        Dim iContAux As Integer  'Novo
        Dim oForm As frmProgressBar
        Dim sErroAux As String = "" 'Novo

        Dim sErro_Complemento As String = ""

        Const ValorProgressBar As Double = 100 / 12

        Revisao_de_Contratos = False

        ExecutaNovamente = False
        TextoErro = ""

        If Confirma = True Then
            If Msg_Perguntar("Faz a revisão dos contratos ?") = False Then Exit Function
        End If


        oForm = New frmProgressBar
        oForm.lblTexto.Text = "Revisando Contratos"
        oForm.Show()
        oForm.Refresh()

        SqlText = "SELECT IC_APLIC_POSTO_DIFERENTE FROM SOF.FILIAL WHERE CD_FILIAL=" & FilialLogada
        AplicPostoDif = IIf(DBQuery_ValorUnico(SqlText) = "S", True, False)

        'APLICA CACAU EM ABERTO NA NEGOCIACAO NOS CONTRATOS FIX
        SqlText = "SELECT CF.CD_CONTRATO_PAF," & _
                         "CF.SQ_NEGOCIACAO," & _
                         "CF.SQ_CONTRATO_FIXO," & _
                         "ROUND((((((CF.QT_KGS - CF.QT_CANCELADO) / CF.QT_KGS) * (CF.VL_TOTAL + CF.VL_ICMS))"
        SqlText = SqlText & "              + CF.VL_ADENDO + CF.VL_ADENDO_ICMS) - CF.VL_NF_FIXO + CF.VL_NF_INSS_FIXO) "
        SqlText = SqlText & "              / (1 - (FUN.VL_TAXA / 100)), 2) AS VL_SALDO, "
        SqlText = SqlText & "       (CF.QT_KGS - CF.QT_CANCELADO - CF.QT_KG_FIXO) QT_SALDO, "
        SqlText = SqlText & "       (N.QT_KGS - N.QT_CANCELADO - N.QT_EM_RENEGOCIACAO - N.QT_KG_FIXO) QT_SALDO_NEG, "
        SqlText = SqlText & "       (CP.QT_KGS - CP.QT_CANCELADO - CP.QT_KG_FIXO) QT_SALDO_CP, "
        SqlText = SqlText & "       N.CD_LOCAL_ENTREGA, cf.pc_aliq_icms  "
        SqlText = SqlText & "FROM SOF.CONTRATO_FIXO CF, "
        SqlText = SqlText & "     SOF.NEGOCIACAO N, "
        SqlText = SqlText & "     SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & "     SOF.FORNECEDOR F, "
        SqlText = SqlText & "     SOF.FUNRURAL FUN "
        SqlText = SqlText & "WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      CF.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      CF.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO AND "
        SqlText = SqlText & "      CP.CD_FORNECEDOR = F.CD_FORNECEDOR AND "
        SqlText = SqlText & "      F.CD_FUNRURAL = FUN.CD_FUNRURAL AND "
        SqlText = SqlText & "      F.CD_FILIAL_ORIGEM = " & FilialLogada & " AND "
        SqlText = SqlText & "      CF.IC_STATUS = 'A' AND "
        SqlText = SqlText & "      (CF.QT_KGS - CF.QT_CANCELADO) <> CF.QT_KG_FIXO AND "
        SqlText = SqlText & "      (CF.CD_CONTRATO_PAF, CF.SQ_NEGOCIACAO) IN (SELECT DISTINCT CM.CD_CONTRATO_PAF, CM.SQ_NEGOCIACAO "
        SqlText = SqlText & "                                                 FROM SOF.CTR_PAF_NEG_MOVIMENTACAO CM "
        SqlText = SqlText & "                                                 WHERE CM.QT_KG_A_FIXAR <> 0) "

        If CdContratoPAF <> -1 Then
            SqlText = SqlText & " and cp.cd_contrato_paf=" & CdContratoPAF
        End If

        SqlText = SqlText & "ORDER BY decode(cf.vl_pag_fixo,0,1,0), " 'SE TIVER PAG VAI PRIMEIRO
        SqlText = SqlText & "         cf.dt_vencimento, "
        SqlText = SqlText & "         cf.cd_contrato_paf, "
        SqlText = SqlText & "         cf.sq_negociacao, "
        SqlText = SqlText & "         cf.sq_contrato_fixo "

        oData = DBQuery(SqlText)
        oForm.Inclementa_Valor_ProgressBar(ValorProgressBar)
        oForm.Refresh()

        For iCont = 0 To oData.Rows.Count - 1
            VlFixado = 0
            QtFixado = 0
            VlCtr = oData.Rows(iCont).Item("vl_saldo")
            QtCtr = oData.Rows(iCont).Item("qt_saldo")

            SqlText = "select cm.sq_movimentacao, cm.sq_ctr_paf_movimentacao, cm.sq_ctr_paf_neg_movimentacao, "
            SqlText = SqlText & "       cm.qt_kg_a_fixar, cm.vl_a_fixar, cm.sq_movimentacao_cessao_direito, M.qt_kg_NF "
            SqlText = SqlText & "from sof.ctr_paf_neg_movimentacao cm, sof.movimentacao m "
            SqlText = SqlText & "where cm.qt_kg_a_fixar <> 0 and "
            SqlText = SqlText & "      cm.sq_movimentacao=m.sq_movimentacao and"
            SqlText = SqlText & "      round(m.vl_nf_icms * 100 / m.VL_NF,3) = " & oData.Rows(iCont).Item("pc_aliq_icms") & " and "
            SqlText = SqlText & "      cm.cd_contrato_paf = " & oData.Rows(iCont).Item("cd_contrato_paf") & " and "
            SqlText = SqlText & "      cm.sq_negociacao = " & oData.Rows(iCont).Item("sq_negociacao")
            SqlText = SqlText & " order by cm.sq_movimentacao"
            oDataAux = DBQuery(SqlText)

            For iContAux = 0 To oDataAux.Rows.Count - 1

                If QtFixado + oDataAux.Rows(iContAux).Item("qt_kg_a_fixar") > QtCtr Then
                    QtFix = QtCtr - QtFixado
                    VlFix = FC_Round(QtFix / oDataAux.Rows(iContAux).Item("qt_kg_a_fixar") * oDataAux.Rows(iContAux).Item("vl_a_fixar"), 2)
                Else
                    QtFix = oDataAux.Rows(iContAux).Item("qt_kg_a_fixar")
                    VlFix = oDataAux.Rows(iContAux).Item("vl_a_fixar")
                End If

                If VlFixado + VlFix > VlCtr Then
                    VlFix = VlCtr - VlFixado
                    If oDataAux.Rows(iContAux).Item("qt_kg_NF") <> 0 Then
                        QtFix = Math.Truncate(VlFix / oDataAux.Rows(iContAux).Item("vl_a_fixar") * oDataAux.Rows(iContAux).Item("qt_kg_a_fixar"))
                        VlFix = FC_Round(QtFix / oDataAux.Rows(iContAux).Item("qt_kg_a_fixar") * oDataAux.Rows(iContAux).Item("vl_a_fixar"), 2)
                    End If
                End If

                If Not (VlFix = 0 And QtFix = 0) Then
                    SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, ":CDCTRPAF", _
                                                                       ":SQNEG", _
                                                                       ":SQCTRPAFMOV", _
                                                                       ":SQMOV", _
                                                                       ":SQMOVCD", _
                                                                        ":VLFIXO", _
                                                                       ":QTFIXO", _
                                                                       ":SQCTRPAFNEGMOV", _
                                                                       ":SQCTRFIX", _
                                                                       ":SQCTRPAFNEGCTRFIXMOV", _
                                                                       ":ICGERACONCILIACAO", _
                                                                       ":DSCONCILIACAO")

                    If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("cd_contrato_paf")), _
                                               DBParametro_Montar("SQNEG", oData.Rows(iCont).Item("sq_negociacao")), _
                        DBParametro_Montar("SQCTRPAFMOV", oDataAux.Rows(iContAux).Item("sq_ctr_paf_movimentacao")), _
                        DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("sq_movimentacao")), _
                        DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("Sq_Movimentacao_Cessao_Direito")), _
                        DBParametro_Montar("VLFIXO", VlFix), _
                        DBParametro_Montar("QTFIXO", QtFix), _
                        DBParametro_Montar("SQCTRPAFNEGMOV", oDataAux.Rows(iContAux).Item("sq_ctr_paf_neg_movimentacao")), _
                        DBParametro_Montar("SQCTRFIX", oData.Rows(iCont).Item("sq_contrato_fixo")), _
                        DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                        DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                        DBParametro_Montar("DSCONCILIACAO", Nothing)) Then


                        TextoErro = TextoErro & "Erro aplicação cacau contrato: " & oData.Rows(iCont).Item("cd_contrato_paf") & _
                                    "-" & oData.Rows(iCont).Item("sq_negociacao") & "-" & oData.Rows(iCont).Item("sq_contrato_fixo") & _
                                    vbCrLf & "Descrição: " & Err.Description & vbCrLf
                        GoTo Erro
                        Exit For
                    End If
                End If

                VlFixado = VlFixado + VlFix
                QtFixado = QtFixado + QtFix

                If QtFixado = QtCtr Then Exit For
            Next
        Next

        'APLICA CACAU EM ABERTO NOS CONTRATOS PAF NOS CONTRATOS FIXO
        SqlText = "SELECT cf.cd_contrato_paf, cf.sq_negociacao, cf.sq_contrato_fixo, "
        SqlText = SqlText & "       ROUND((sof.FC_SALDO_CTR_FIX(cf.cd_contrato_paf,cf.sq_negociacao ,cf.sq_contrato_fixo ) - cf.vl_nf_fixo + cf.vl_nf_inss_fixo) "
        SqlText = SqlText & "              / (1 - (fun.vl_taxa / 100)), 2) AS vl_saldo, "
        SqlText = SqlText & "       (cf.qt_kgs - cf.qt_cancelado - cf.qt_kg_fixo) qt_saldo, "
        SqlText = SqlText & "       (n.qt_kgs - n.qt_cancelado - n.qt_em_renegociacao - n.qt_kg_fixo) qt_saldo_neg, "
        SqlText = SqlText & "       (cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo) qt_saldo_cp, "
        SqlText = SqlText & "       n.cd_local_entrega, n.cd_filial_entrega "
        SqlText = SqlText & " , decode (n.cd_local_entrega,1,fil.vl_frete_filial_fazenda,2,fil.vl_frete_filial_fabrica,3,fil.vl_frete_fabrica,0) as valor_frete, cf.pc_aliq_icms "
        SqlText = SqlText & "FROM sof.contrato_fixo cf, "
        SqlText = SqlText & "     sof.negociacao n, "
        SqlText = SqlText & "     sof.contrato_paf cp, "
        SqlText = SqlText & "     sof.fornecedor f, "
        SqlText = SqlText & "     sof.funrural fun, "
        SqlText = SqlText & " sof.filial fil "
        SqlText = SqlText & "WHERE cp.cd_contrato_paf = n.cd_contrato_paf AND "
        SqlText = SqlText & "      cf.cd_contrato_paf = n.cd_contrato_paf AND "
        SqlText = SqlText & "      cf.sq_negociacao = n.sq_negociacao AND "
        SqlText = SqlText & "      cp.cd_fornecedor = f.cd_fornecedor AND "
        SqlText = SqlText & "      f.cd_funrural = fun.cd_funrural AND "
        SqlText = SqlText & "      n.cd_filial_entrega =fil.cd_filial and f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "      cf.ic_status = 'A' AND "
        SqlText = SqlText & "      (cf.qt_kgs - cf.qt_cancelado) <> cf.qt_kg_fixo and "
        SqlText = SqlText & "      (cf.cd_contrato_paf) in (select distinct cm.cd_contrato_paf "
        SqlText = SqlText & "                               from sof.ctr_paf_movimentacao cm "
        SqlText = SqlText & "                               where cm.qt_kg_a_fixar <> 0) "

        If CdContratoPAF <> -1 Then
            SqlText = SqlText & " and cp.cd_contrato_paf=" & CdContratoPAF
        End If

        SqlText = SqlText & "ORDER BY decode(cf.vl_pag_fixo,0,1,0), " 'SE TIVER PAG VAI PRIMEIRO
        SqlText = SqlText & "         cf.dt_vencimento, "
        SqlText = SqlText & "         cf.cd_contrato_paf, "
        SqlText = SqlText & "         cf.sq_negociacao, "
        SqlText = SqlText & "         cf.sq_contrato_fixo "
        oData = DBQuery(SqlText)
        oForm.Inclementa_Valor_ProgressBar(ValorProgressBar)
        oForm.Refresh()

        For iCont = 0 To oData.Rows.Count - 1
            VlFixado = 0
            QtFixado = 0
            VlCtr = oData.Rows(iCont).Item("vl_saldo")
            QtCtr = oData.Rows(iCont).Item("qt_saldo")
            QtNeg = oData.Rows(iCont).Item("qt_saldo_neg")
            CdLocal = oData.Rows(iCont).Item("cd_local_entrega")
            VlLocal = oData.Rows(iCont).Item("valor_frete")

            If QtCtr > QtNeg Then
                QtCtr = QtNeg
            End If

            If QtCtr > 0 Then
                'PARA RESOLVER PROBLEMA DE AMARRAÇÃO AVALIO O VALOR DO FRETE E NÃO MAIS O POSTO
                SqlText = "select cm.sq_movimentacao, cm.sq_ctr_paf_movimentacao, "
                SqlText = SqlText & "       cm.qt_kg_a_fixar, cm.vl_a_fixar, cm.sq_movimentacao_cessao_direito, m.qt_kg_NF "
                SqlText = SqlText & "from sof.ctr_paf_movimentacao cm, "
                SqlText = SqlText & "     sof.movimentacao m, sof.filial fil  "
                SqlText = SqlText & "where cm.sq_movimentacao = m.sq_movimentacao and m.cd_filial_origem  =fil.cd_filial and "
                SqlText = SqlText & "      nvl(decode (m.cd_local_entrega,1,fil.vl_frete_filial_fazenda,2,fil.vl_frete_filial_fabrica,3,fil.vl_frete_fabrica,0)," & ConvValorFormatoAmericano(VlLocal) & ") = " & ConvValorFormatoAmericano(VlLocal) & " and "
                If CdLocal <> 3 And Not AplicPostoDif Then
                    SqlText = SqlText & " m.cd_filial_movimentacao = " & oData.Rows(iCont).Item("cd_filial_entrega") & " AND "
                End If
                SqlText = SqlText & "      round(m.vl_nf_icms * 100 / m.VL_NF,3) = " & oData.Rows(iCont).Item("pc_aliq_icms") & " and "
                SqlText = SqlText & "      cm.qt_kg_a_fixar <> 0 and "
                SqlText = SqlText & "      cm.cd_contrato_paf = " & oData.Rows(iCont).Item("cd_contrato_paf") & " "
                SqlText = SqlText & "order by cm.sq_movimentacao "
                oDataAux = DBQuery(SqlText)

                For iContAux = 0 To oDataAux.Rows.Count - 1
                    If QtFixado + oDataAux.Rows(iContAux).Item("qt_kg_a_fixar") > QtCtr Then
                        QtFix = QtCtr - QtFixado
                        VlFix = FC_Round(QtFix / oDataAux.Rows(iContAux).Item("qt_kg_a_fixar") * oDataAux.Rows(iContAux).Item("vl_a_fixar"), 2)
                    Else
                        QtFix = oDataAux.Rows(iContAux).Item("qt_kg_a_fixar")
                        VlFix = oDataAux.Rows(iContAux).Item("vl_a_fixar")
                    End If

                    If VlFixado + VlFix > VlCtr Then
                        VlFix = VlCtr - VlFixado

                        If oDataAux.Rows(iContAux).Item("qt_kg_NF") <> 0 Then
                            QtFix = Math.Truncate(VlFix / oDataAux.Rows(iContAux).Item("vl_a_fixar") * oDataAux.Rows(iContAux).Item("qt_kg_a_fixar"))
                            VlFix = FC_Round(QtFix / oDataAux.Rows(iContAux).Item("qt_kg_a_fixar") * oDataAux.Rows(iContAux).Item("vl_a_fixar"), 2)
                        End If
                    End If

                    If Not (VlFix = 0 And QtFix = 0) Then
                        DBUsarTransacao = True

                        Verifica_Situacao_Contrato(oData.Rows(iCont).Item("cd_contrato_paf"), oData.Rows(iCont).Item("sq_negociacao"), -1)

                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", _
                                                               ":SQNEG", _
                                                               ":SQCTRPAFMOV", _
                                                               ":SQMOV", _
                                                               ":SQMOVCD", _
                                                                ":VLFIXO", _
                                                               ":QTFIXO", _
                                                               ":SQCTRPAFNEGMOV")

                        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("cd_contrato_paf")), _
                            DBParametro_Montar("SQNEG", oData.Rows(iCont).Item("sq_negociacao")), _
                            DBParametro_Montar("SQCTRPAFMOV", oDataAux.Rows(iContAux).Item("sq_ctr_paf_movimentacao")), _
                            DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("sq_movimentacao")), _
                            DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("Sq_Movimentacao_Cessao_Direito")), _
                            DBParametro_Montar("VLFIXO", VlFix), _
                            DBParametro_Montar("QTFIXO", QtFix), _
                            DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo ERRO


                        If DBTeveRetorno() Then
                            SqCtrPAFNegMov = DBRetorno(1)
                        End If

                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, ":CDCTRPAF", _
                                                                  ":SQNEG", _
                                                                  ":SQCTRPAFMOV", _
                                                                  ":SQMOV", _
                                                                  ":SQMOVCD", _
                                                                   ":VLFIXO", _
                                                                  ":QTFIXO", _
                                                                  ":SQCTRPAFNEGMOV", _
                                                                  ":SQCTRFIX", _
                                                                  ":SQCTRPAFNEGCTRFIXMOV", _
                                                                  ":ICGERACONCILIACAO", _
                                                                  ":DSCONCILIACAO")

                        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("cd_contrato_paf")), _
                            DBParametro_Montar("SQNEG", oData.Rows(iCont).Item("sq_negociacao")), _
                            DBParametro_Montar("SQCTRPAFMOV", oDataAux.Rows(iContAux).Item("sq_ctr_paf_movimentacao")), _
                            DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("sq_movimentacao")), _
                            DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("Sq_Movimentacao_Cessao_Direito")), _
                            DBParametro_Montar("VLFIXO", VlFix), _
                            DBParametro_Montar("QTFIXO", QtFix), _
                            DBParametro_Montar("SQCTRPAFNEGMOV", SqCtrPAFNegMov), _
                            DBParametro_Montar("SQCTRFIX", oData.Rows(iCont).Item("sq_contrato_fixo")), _
                            DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                            DBParametro_Montar("DSCONCILIACAO", Nothing)) Then

                            TextoErro = TextoErro & "Erro aplicação cacau contrato: " & oData.Rows(iCont).Item("cd_contrato_paf") & _
                                        "-" & oData.Rows(iCont).Item("sq_negociacao") & "-" & oData.Rows(iCont).Item("sq_contrato_fixo") & _
                                        vbCrLf & "Descrição: " & Err.Description & vbCrLf
                            GoTo Erro
                            Exit For
                        End If

                        If Not DBExecutarTransacao() Then GoTo eRRO
                    End If

                    VlFixado = VlFixado + VlFix
                    QtFixado = QtFixado + QtFix

                    If QtFixado = QtCtr Then Exit For

                Next
            End If
        Next

        'APLICA CACAU EM ABERTO NOS CONTRATOS PAF NAS NEGOCIAÇÕES
        SqlText = "SELECT   n.cd_contrato_paf, n.sq_negociacao, "
        SqlText = SqlText & "         (n.qt_kgs - n.qt_cancelado - n.qt_em_renegociacao - n.qt_kg_fixo) qt_saldo, "
        SqlText = SqlText & "         (cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo) qt_saldo_cp, "
        SqlText = SqlText & "         n.cd_local_entrega, n.cd_filial_entrega "
        SqlText = SqlText & " , decode (n.cd_local_entrega,1,fil.vl_frete_filial_fazenda,2,fil.vl_frete_filial_fabrica,3,fil.vl_frete_fabrica,0) as valor_frete, n.pc_aliq_icms "
        SqlText = SqlText & " FROM     sof.negociacao n, "
        SqlText = SqlText & "         sof.contrato_paf cp, "
        SqlText = SqlText & "         sof.fornecedor f, "
        SqlText = SqlText & "         sof.funrural fun, sof.filial fil "
        SqlText = SqlText & "WHERE    cp.cd_contrato_paf = n.cd_contrato_paf "
        SqlText = SqlText & "AND      cp.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "AND      f.cd_funrural = fun.cd_funrural and n.cd_filial_entrega =fil.cd_filial "
        SqlText = SqlText & "AND      f.cd_filial_origem = " & FilialLogada & " "
        SqlText = SqlText & "AND      n.ic_status = 'A' "
        SqlText = SqlText & "AND      (n.qt_kgs - n.qt_cancelado - n.qt_em_renegociacao) <> n.qt_kg_fixo "
        SqlText = SqlText & "AND      (n.cd_contrato_paf) in (select distinct cm.cd_contrato_paf "
        SqlText = SqlText & "                                 from sof.ctr_paf_movimentacao cm "
        SqlText = SqlText & "                                 where cm.qt_kg_a_fixar <> 0) "

        If CdContratoPAF <> -1 Then
            SqlText = SqlText & " and cp.cd_contrato_paf=" & CdContratoPAF
        End If

        SqlText = SqlText & " ORDER BY decode(n.vl_pag_fixo,0,1,0), " 'SE TIVER PAG VAI PRIMEIRO
        SqlText = SqlText & "         n.dt_vencimento, "
        SqlText = SqlText & "         n.cd_contrato_paf, "
        SqlText = SqlText & "         n.sq_negociacao "
        oData = DBQuery(SqlText)
        oForm.Inclementa_Valor_ProgressBar(ValorProgressBar)
        oForm.Refresh()

        For iCont = 0 To oData.Rows.Count - 1
            QtFixado = 0
            QtCtr = oData.Rows(iCont).Item("qt_saldo")
            CdLocal = oData.Rows(iCont).Item("cd_local_entrega")
            VlLocal = oData.Rows(iCont).Item("valor_frete")

            If QtCtr > 0 Then
                SqlText = "select cm.sq_movimentacao, cm.sq_ctr_paf_movimentacao, "
                SqlText = SqlText & "       cm.qt_kg_a_fixar, cm.vl_a_fixar, cm.sq_movimentacao_cessao_direito, m.qt_kg_NF "
                SqlText = SqlText & "from sof.ctr_paf_movimentacao cm, "
                SqlText = SqlText & "     sof.movimentacao m,sof.filial fil  "
                SqlText = SqlText & "where cm.sq_movimentacao = m.sq_movimentacao and m.cd_filial_origem  =fil.cd_filial and "
                SqlText = SqlText & "      nvl(decode (m.cd_local_entrega,1,fil.vl_frete_filial_fazenda,2,fil.vl_frete_filial_fabrica,3,fil.vl_frete_fabrica,0)," & ConvValorFormatoAmericano(VlLocal) & ") = " & ConvValorFormatoAmericano(VlLocal) & " and "
                If CdLocal <> 3 And FilialLogada <> Not AplicPostoDif Then
                    SqlText = SqlText & " m.cd_filial_movimentacao = " & oData.Rows(iCont).Item("cd_filial_entrega") & " AND "
                End If
                SqlText = SqlText & "      round(m.vl_nf_icms * 100 / m.VL_NF,3) = " & oData.Rows(iCont).Item("pc_aliq_icms") & " and "
                SqlText = SqlText & "      cm.qt_kg_a_fixar <> 0 and "
                SqlText = SqlText & "      cm.cd_contrato_paf = " & oData.Rows(iCont).Item("cd_contrato_paf") & " "
                SqlText = SqlText & "order by cm.sq_movimentacao "

                oDataAux = DBQuery(SqlText)

                For iContAux = 0 To oDataAux.Rows.Count - 1
                    If QtFixado + oDataAux.Rows(iContAux).Item("qt_kg_a_fixar") > QtCtr Then
                        QtFix = QtCtr - QtFixado
                        VlFix = FC_Round(QtFix / oDataAux.Rows(iContAux).Item("qt_kg_a_fixar") * oDataAux.Rows(iContAux).Item("vl_a_fixar"), 2)
                    Else
                        QtFix = oDataAux.Rows(iContAux).Item("qt_kg_a_fixar")
                        VlFix = oDataAux.Rows(iContAux).Item("vl_a_fixar")
                    End If

                    If VlFixado + VlFix > VlCtr Then
                        VlFix = VlCtr - VlFixado

                        If oDataAux.Rows(iContAux).Item("qt_kg_NF") <> 0 Then
                            QtFix = Math.Truncate(VlFix / oDataAux.Rows(iContAux).Item("vl_a_fixar") * oDataAux.Rows(iContAux).Item("qt_kg_a_fixar"))
                            VlFix = FC_Round(QtFix / oDataAux.Rows(iContAux).Item("qt_kg_a_fixar") * oDataAux.Rows(iContAux).Item("vl_a_fixar"), 2)
                        End If
                    End If

                    If Not (VlFix = 0 And QtFix = 0) Then

                        DBUsarTransacao = True

                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", _
                                           ":SQNEG", _
                                           ":SQCTRPAFMOV", _
                                           ":SQMOV", _
                                           ":SQMOVCD", _
                                            ":VLFIXO", _
                                           ":QTFIXO", _
                                           ":SQCTRPAFNEGMOV")

                        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("cd_contrato_paf")), _
                            DBParametro_Montar("SQNEG", oData.Rows(iCont).Item("sq_negociacao")), _
                            DBParametro_Montar("SQCTRPAFMOV", oDataAux.Rows(iContAux).Item("sq_ctr_paf_movimentacao")), _
                            DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("sq_movimentacao")), _
                            DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("Sq_Movimentacao_Cessao_Direito")), _
                            DBParametro_Montar("VLFIXO", VlFix), _
                            DBParametro_Montar("QTFIXO", QtFix), _
                            DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then


                            TextoErro = TextoErro & "Erro aplicação cacau contrato: " & oData.Rows(iCont).Item("cd_contrato_paf") & _
                                        "-" & oData.Rows(iCont).Item("sq_negociacao") & _
                                        vbCrLf & "Descrição: " & Err.Description & vbCrLf
                            GoTo Erro
                            Exit For
                        End If

                        If DBTeveRetorno() Then
                            SqCtrPAFNegMov = DBRetorno(1)
                        End If

                        If Not DBExecutarTransacao() Then GoTo ERRO
                    End If
                    QtFixado = QtFixado + QtFix

                    If QtFixado = QtCtr Then Exit For

                Next
            End If
        Next

        'APLICA PAGAMENTOS EM ABERTO NAS NEGOCIAÇÕES NOS CONTRATOS FIXOS
        SqlText = "SELECT cf.cd_contrato_paf, "
        SqlText = SqlText & "       cf.sq_negociacao, "
        SqlText = SqlText & "       cf.sq_contrato_fixo, "
        SqlText = SqlText & "       round(sof.FC_SALDO_CTR_FIX(cf.cd_contrato_paf,cf.sq_negociacao ,cf.sq_contrato_fixo ) - cf.vl_pag_fixo,2) vl_saldo "
        SqlText = SqlText & "FROM sof.contrato_fixo cf, "
        SqlText = SqlText & "     sof.contrato_paf cp, "
        SqlText = SqlText & "     sof.fornecedor f "
        SqlText = SqlText & "WHERE cf.cd_contrato_paf = cp.cd_contrato_paf and "
        SqlText = SqlText & "      cp.cd_fornecedor = f.cd_fornecedor and "
        SqlText = SqlText & "      f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "      cf.ic_status = 'A' and "
        SqlText = SqlText & "      (sof.FC_SALDO_CTR_FIX(cf.cd_contrato_paf,cf.sq_negociacao ,cf.sq_contrato_fixo )  - cf.vl_pag_fixo) <> 0 and "
        SqlText = SqlText & "      cf.qt_kgs - cf.qt_cancelado = cf.qt_kg_fixo and "
        SqlText = SqlText & "      (cf.cd_contrato_paf, cf.sq_negociacao) in (select distinct pn.cd_contrato_paf, "
        SqlText = SqlText & "                                                        pn.sq_negociacao "
        SqlText = SqlText & "                                                 from sof.pag_neg pn "
        SqlText = SqlText & "                                                 where pn.vl_a_fixar <> 0) "

        If CdContratoPAF <> -1 Then
            SqlText = SqlText & " and cp.cd_contrato_paf=" & CdContratoPAF
        End If

        SqlText = SqlText & "order by cf.dt_vencimento, cf.cd_contrato_paf, cf.sq_negociacao, cf.sq_contrato_fixo "
        oData = DBQuery(SqlText)
        oForm.Inclementa_Valor_ProgressBar(ValorProgressBar)
        oForm.Refresh()

        For iCont = 0 To oData.Rows.Count - 1
            VlCtr = oData.Rows(iCont).Item("vl_saldo")
            VlFixado = 0

            SqlText = "select pn.sq_pagamento, pn.sq_pag_neg, pn.vl_a_fixar, pn.sq_pag_ctr_paf "
            SqlText = SqlText & "from sof.pag_neg pn "
            SqlText = SqlText & "where pn.vl_a_fixar <> 0 and "
            SqlText = SqlText & "      pn.cd_contrato_paf = " & oData.Rows(iCont).Item("cd_contrato_paf") & " And "
            SqlText = SqlText & "      pn.sq_negociacao = " & oData.Rows(iCont).Item("sq_negociacao")
            SqlText = SqlText & " order by pn.sq_pagamento "
            oDataAux = DBQuery(SqlText)

            For iContAux = 0 To oDataAux.Rows.Count - 1
                If VlFixado + oDataAux.Rows(iContAux).Item("vl_a_fixar") > VlCtr Then
                    VlFix = VlCtr - VlFixado
                Else
                    VlFix = oDataAux.Rows(iContAux).Item("vl_a_fixar")
                End If

                DBUsarTransacao = True

                If Not AplicacaoPagamentoContratoFixo(oData.Rows(iCont).Item("cd_contrato_paf"), _
                                                oData.Rows(iCont).Item("sq_negociacao"), _
                                                oData.Rows(iCont).Item("sq_contrato_fixo"), _
                                                oDataAux.Rows(iContAux).Item("Sq_Pagamento"), _
                                                oDataAux.Rows(iContAux).Item("sq_pag_ctr_paf"), _
                                                oDataAux.Rows(iContAux).Item("sq_pag_neg"), _
                                                VlFix, SqPagNegCtrFix, VlJuros, VlFix) Then


                    TextoErro = TextoErro & "Erro aplicação pagamento contrato: " & oData.Rows(iCont).Item("cd_contrato_paf") & _
                                "-" & oData.Rows(iCont).Item("sq_negociacao") & oData.Rows(iCont).Item("SQ_CONTRATO_FIXO") & _
                                vbCrLf & "Descrição: " & Err.Description & vbCrLf
                    GoTo Erro
                    Exit For
                End If

                If Not DBExecutarTransacao() Then GoTo erro

                VlFixado = VlFixado + VlFix + VlJuros

                If VlFixado = VlCtr Then Exit For
            Next
        Next

        'APLICA PAGAMENTOS EM ABERTO NOS CONTRATOS PAF NOS CONTRATOS FIXO
        SqlText = "SELECT cf.cd_contrato_paf, "
        SqlText = SqlText & "       cf.sq_negociacao, "
        SqlText = SqlText & "       cf.sq_contrato_fixo, "
        SqlText = SqlText & "       (round(sof.FC_SALDO_CTR_FIX(cf.cd_contrato_paf,cf.sq_negociacao ,cf.sq_contrato_fixo ),2) - cf.vl_pag_fixo) vl_saldo "
        SqlText = SqlText & "FROM sof.contrato_fixo cf, "
        SqlText = SqlText & "     sof.contrato_paf cp, "
        SqlText = SqlText & "     sof.fornecedor f "
        SqlText = SqlText & "WHERE cf.cd_contrato_paf = cp.cd_contrato_paf and "
        SqlText = SqlText & "      cp.cd_fornecedor = f.cd_fornecedor and "
        SqlText = SqlText & "      f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "      cf.ic_status = 'A' and "
        SqlText = SqlText & "      (ROUND(sof.FC_SALDO_CTR_FIX(cf.cd_contrato_paf,cf.sq_negociacao ,cf.sq_contrato_fixo ), 2) - cf.vl_pag_fixo) <> 0 and "
        SqlText = SqlText & "      cf.qt_kgs - cf.qt_cancelado = cf.qt_kg_fixo and "
        SqlText = SqlText & "      (cf.cd_contrato_paf) in (select distinct pcp.cd_contrato_paf "
        SqlText = SqlText & "                               from sof.pag_ctr_paf pcp "
        SqlText = SqlText & "                               where pcp.vl_a_fixar <> 0 AND PCP.SQ_CONFISSAO_DIVIDA IS NULL) "

        If CdContratoPAF <> -1 Then
            SqlText = SqlText & " and cp.cd_contrato_paf=" & CdContratoPAF
        End If

        SqlText = SqlText & "order by cf.dt_vencimento, cf.cd_contrato_paf, cf.sq_negociacao, cf.sq_contrato_fixo "
        oData = DBQuery(SqlText)
        oForm.Inclementa_Valor_ProgressBar(ValorProgressBar)
        oForm.Refresh()

        For iCont = 0 To oData.Rows.Count - 1
            VlCtr = oData.Rows(iCont).Item("vl_saldo")
            VlFixado = 0

            'NÃO APLICO OS PAGAMENTOS QUE SÃO DE ICMS E ESTÃO NO PAF POIS SERÃO AMARRADOS
            SqlText = "SELECT pn.sq_pagamento, pn.vl_a_fixar, pn.sq_pag_ctr_paf "
            SqlText = SqlText & "  FROM sof.pag_ctr_paf pn, sof.pagamentos p, sof.tipo_pagamento tp "
            SqlText = SqlText & " WHERE pn.sq_pagamento = p.sq_pagamento "
            SqlText = SqlText & "   AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
            SqlText = SqlText & "   AND tp.ic_pagamento_icms = 'N' "
            SqlText = SqlText & "   AND pn.vl_a_fixar <> 0 "
            SqlText = SqlText & "   AND pn.sq_confissao_divida IS NULL "
            SqlText = SqlText & "   AND pn.cd_contrato_paf = " & oData.Rows(iCont).Item("cd_contrato_paf")

            oDataAux = DBQuery(SqlText)

            For iContAux = 0 To oDataAux.Rows.Count - 1
                If VlFixado + oDataAux.Rows(iContAux).Item("vl_a_fixar") > VlCtr Then
                    VlFix = VlCtr - VlFixado
                Else
                    VlFix = oDataAux.Rows(iContAux).Item("vl_a_fixar")
                End If

                DBUsarTransacao = True

                Verifica_Situacao_Contrato(oData.Rows(iCont).Item("cd_contrato_paf"), oData.Rows(iCont).Item("sq_negociacao"), -1)

                If Not AplicacaoPagamentoNegociacao(oData.Rows(iCont).Item("cd_contrato_paf"), _
                                               oData.Rows(iCont).Item("sq_negociacao"), _
                                               oDataAux.Rows(iContAux).Item("Sq_Pagamento"), _
                                               oDataAux.Rows(iContAux).Item("sq_pag_ctr_paf"), _
                                               VlFix, SqPagNeg, SqPagJuros, SqPagJurosCtrPAF, SqPagJurosNeg, _
                                                VlJuros, VlFix) Then

                    TextoErro = TextoErro & "Erro aplicação pagamento contrato: " & oData.Rows(iCont).Item("cd_contrato_paf") & _
                                "-" & oData.Rows(iCont).Item("sq_negociacao") & _
                                vbCrLf & "Descrição: " & Err.Description & vbCrLf
                    GoTo Erro
                    Exit For
                End If

                If Not AplicacaoPagamentoContratoFixo(oData.Rows(iCont).Item("cd_contrato_paf"), _
                                                oData.Rows(iCont).Item("sq_negociacao"), _
                                                oData.Rows(iCont).Item("sq_contrato_fixo"), _
                                                oDataAux.Rows(iContAux).Item("Sq_Pagamento"), _
                                                oDataAux.Rows(iContAux).Item("sq_pag_ctr_paf"), _
                                                SqPagNeg, _
                                                VlFix, SqPagNegCtrFix, VlJuros, VlFix) Then


                    TextoErro = TextoErro & "Erro aplicação pagamento contrato: " & oData.Rows(iCont).Item("cd_contrato_paf") & _
                                "-" & oData.Rows(iCont).Item("sq_negociacao") & oData.Rows(iCont).Item("SQ_CONTRATO_FIXO") & _
                                vbCrLf & "Descrição: " & Err.Description & vbCrLf
                    GoTo Erro
                    Exit For
                End If


                If SqPagJuros <> -1 Then
                    If Not AplicacaoPagamentoContratoFixo(oData.Rows(iCont).Item("cd_contrato_paf"), _
                                   oData.Rows(iCont).Item("sq_negociacao"), _
                                   oData.Rows(iCont).Item("sq_contrato_fixo"), _
                                   SqPagJuros, _
                                   SqPagJurosCtrPAF, _
                                   SqPagJurosNeg, _
                                   VlJuros, SqPagNegCtrFix) Then


                        TextoErro = TextoErro & "Erro aplicação pagamento contrato: " & oData.Rows(iCont).Item("cd_contrato_paf") & _
                                    "-" & oData.Rows(iCont).Item("sq_negociacao") & oData.Rows(iCont).Item("SQ_CONTRATO_FIXO") & _
                                    vbCrLf & "Descrição: " & Err.Description & vbCrLf
                        GoTo Erro
                        Exit For
                    End If
                End If

                If Not DBExecutarTransacao() Then GoTo Erro

                VlFixado = VlFixado + VlFix + VlJuros

                If VlFixado = VlCtr Then Exit For
            Next
        Next

        'RETIRA AS NF QUE TEM VALOR E NAO TEM QUILO QUE ESTAO APLICADAS NAS NEGOCIAÇÕES E COLOCA
        'NO CONTRATO PAF
        SqlText = "select pn.cd_contrato_paf, pn.sq_negociacao, pn.sq_pagamento, pn.sq_pag_ctr_paf, "
        SqlText = SqlText & "       pn.sq_pag_neg, pn.vl_fixo, pn.vl_a_fixar "
        SqlText = SqlText & "from sof.negociacao n, "
        SqlText = SqlText & "     sof.pag_neg pn, "
        SqlText = SqlText & "     sof.contrato_paf cp, "
        SqlText = SqlText & "     sof.fornecedor f "
        SqlText = SqlText & "where n.cd_contrato_paf = pn.cd_contrato_paf and "
        SqlText = SqlText & "      n.sq_negociacao = pn.sq_negociacao and "
        SqlText = SqlText & "      n.cd_contrato_paf = cp.cd_contrato_paf and "
        SqlText = SqlText & "      cp.cd_fornecedor = f.cd_fornecedor and "
        SqlText = SqlText & "      f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "      n.qt_a_fixar = 0 and "
        SqlText = SqlText & "      pn.vl_a_fixar <> 0 "

        If CdContratoPAF <> -1 Then
            SqlText = SqlText & " and cp.cd_contrato_paf=" & CdContratoPAF
        End If

        oData = DBQuery(SqlText)
        oForm.Inclementa_Valor_ProgressBar(ValorProgressBar)
        oForm.Refresh()

        For iCont = 0 To oData.Rows.Count - 1
            If oData.Rows(iCont).Item("vl_a_fixar") <> oData.Rows(iCont).Item("vl_fixo") Then
                SqlText = "UPDATE SOF.PAG_NEG " & _
                          "SET VL_FIXO = VL_FIXO - " & oData.Rows(iCont).Item("vl_a_fixar") & ", " & _
                          "VL_A_FIXAR = VL_A_FIXAR - " & oData.Rows(iCont).Item("vl_a_fixar") & " " & _
                          "WHERE CD_CONTRATO_PAF = " & oData.Rows(iCont).Item("CD_CONTRATO_PAF") & " AND " & _
                          "SQ_NEGOCIACAO = " & oData.Rows(iCont).Item("SQ_NEGOCIACAO") & " AND " & _
                          "SQ_PAGAMENTO = " & oData.Rows(iCont).Item("SQ_PAGAMENTO") & " AND " & _
                          "SQ_PAG_CTR_PAF = " & oData.Rows(iCont).Item("SQ_PAG_CTR_PAF") & " AND " & _
                          "SQ_PAG_NEG = " & oData.Rows(iCont).Item("SQ_PAG_NEG")
                If Not DBExecutar(SqlText) Then GoTo Erro
            Else
                Elimina_Pag_neg(oData.Rows(iCont).Item("CD_CONTRATO_PAF"), oData.Rows(iCont).Item("SQ_NEGOCIACAO"), _
                                oData.Rows(iCont).Item("SQ_PAGAMENTO"), oData.Rows(iCont).Item("SQ_PAG_CTR_PAF"), _
                                oData.Rows(iCont).Item("SQ_PAG_NEG"))
            End If
        Next

        'APLICAS AS NF QUE POSSUEM SALDO EM VALOR, NAO POSSUE SALDO EM QUILOS E QUE ESTÃO NAS NEGOCIAÇÕES
        'NOS CONTRATOS FIXOS QUE ESTAO PRECISANDO DE NF COMPLEMENTAR
        SqlText = "SELECT cf.cd_contrato_paf, cf.sq_negociacao, cf.sq_contrato_fixo, cp.cd_fornecedor, "
        SqlText = SqlText & "       round((((((CF.QT_KGS - CF.QT_CANCELADO) / CF.QT_KGS) * (CF.VL_TOTAL + CF.VL_ICMS)) "
        SqlText = SqlText & "              + CF.VL_ADENDO + CF.VL_ADENDO_ICMS) - CF.VL_NF_FIXO + CF.VL_NF_INSS_FIXO) "
        SqlText = SqlText & "              / (1 - (FUN.VL_TAXA / 100)),2) vl_saldo, cf.pc_aliq_icms "
        SqlText = SqlText & "FROM SOF.CONTRATO_FIXO CF, SOF.NEGOCIACAO N, SOF.CONTRATO_PAF CP, SOF.FORNECEDOR F, "
        SqlText = SqlText & "     SOF.FUNRURAL FUN "
        SqlText = SqlText & "WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      CF.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      CF.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO AND "
        SqlText = SqlText & "      CP.CD_FORNECEDOR = F.CD_FORNECEDOR AND "
        SqlText = SqlText & "      F.CD_FUNRURAL = FUN.CD_FUNRURAL AND "
        SqlText = SqlText & "      CF.IC_STATUS = 'A' AND "
        SqlText = SqlText & "      f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "      round((((((CF.QT_KGS - CF.QT_CANCELADO) / CF.QT_KGS) * (CF.VL_TOTAL + CF.VL_ICMS)) "
        SqlText = SqlText & "              + CF.VL_ADENDO + CF.VL_ADENDO_ICMS) - CF.VL_NF_FIXO + CF.VL_NF_INSS_FIXO) "
        SqlText = SqlText & "              / (1 - (FUN.VL_TAXA / 100)),2)<>0 and "
        SqlText = SqlText & "      (CF.QT_KGS - CF.QT_CANCELADO) = CF.QT_KG_FIXO and "
        SqlText = SqlText & "      (cf.cd_contrato_paf, cf.sq_negociacao) in (select distinct CM.cd_contrato_paf, CM.sq_negociacao "
        SqlText = SqlText & "                                                 from sof.ctr_paf_NEG_movimentacao cm, sof.movimentacao m, "
        SqlText = SqlText & "                                                      sof.contrato_paf cp, sof.fornecedor f "
        SqlText = SqlText & "                                                 where cm.sq_movimentacao = m.sq_movimentacao and "
        SqlText = SqlText & "                                                       cm.cd_contrato_paf = cp.cd_contrato_paf and "
        SqlText = SqlText & "                                                       cp.cd_fornecedor = f.cd_fornecedor and "
        SqlText = SqlText & "                                                       f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "                                                       cm.qt_kg_a_fixar = 0 and cm.vl_a_fixar <> 0) "

        If CdContratoPAF <> -1 Then
            SqlText = SqlText & " and cp.cd_contrato_paf=" & CdContratoPAF
        End If

        SqlText = SqlText & "order by cf.dt_vencimento "

        oData = DBQuery(SqlText)
        oForm.Inclementa_Valor_ProgressBar(ValorProgressBar)
        oForm.Refresh()

        For iCont = 0 To oData.Rows.Count - 1
            VlFixado = 0
            VlCtr = oData.Rows(iCont).Item("vl_saldo")

            SqlText = "select cm.sq_movimentacao, cm.sq_ctr_paf_movimentacao, cm.sq_ctr_paf_neg_movimentacao, "
            SqlText = SqlText & "       cm.qt_kg_a_fixar, cm.vl_a_fixar, cm.sq_movimentacao_cessao_direito "
            SqlText = SqlText & "from sof.ctr_paf_neg_movimentacao cm, sof.movimentacao m "
            SqlText = SqlText & "where cm.qt_kg_a_fixar = 0 and cm.vl_a_fixar <> 0 and "
            SqlText = SqlText & "      cm.sq_movimentacao = m.sq_movimentacao and "
            SqlText = SqlText & "      round(m.vl_nf_icms * 100 / m.VL_NF,3) = " & oData.Rows(iCont).Item("pc_aliq_icms") & " and "
            SqlText = SqlText & "      cm.cd_contrato_paf = " & oData.Rows(iCont).Item("cd_contrato_paf") & " and "
            SqlText = SqlText & "      cm.sq_negociacao = " & oData.Rows(iCont).Item("sq_negociacao")

            'COM ESSE RECURSO SÓ FAZ A APLICAÇÃO SE FOR NF COMPLEMENTAR
            SqlText = SqlText & "  and  m.qt_kg_NF = 0 "

            SqlText = SqlText & " order by cm.sq_movimentacao"
            oDataAux = DBQuery(SqlText)

            For iContAux = 0 To oDataAux.Rows.Count - 1
                QtFix = 0
                VlFix = oDataAux.Rows(iContAux).Item("vl_a_fixar")

                If VlFixado + VlFix > VlCtr Then
                    VlFix = VlCtr - VlFixado
                End If

                If Not (VlFix = 0 And QtFix = 0) Then
                    SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, ":CDCTRPAF", _
                                                                             ":SQNEG", _
                                                                             ":SQCTRPAFMOV", _
                                                                             ":SQMOV", _
                                                                             ":SQMOVCD", _
                                                                              ":VLFIXO", _
                                                                             ":QTFIXO", _
                                                                             ":SQCTRPAFNEGMOV", _
                                                                             ":SQCTRFIX", _
                                                                             ":SQCTRPAFNEGCTRFIXMOV", _
                                                                             ":ICGERACONCILIACAO", _
                                                                             ":DSCONCILIACAO")

                    If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("cd_contrato_paf")), _
                        DBParametro_Montar("SQNEG", oData.Rows(iCont).Item("sq_negociacao")), _
                        DBParametro_Montar("SQCTRPAFMOV", oDataAux.Rows(iContAux).Item("sq_ctr_paf_movimentacao")), _
                        DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("sq_movimentacao")), _
                        DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("Sq_Movimentacao_Cessao_Direito")), _
                        DBParametro_Montar("VLFIXO", VlFix), _
                        DBParametro_Montar("QTFIXO", QtFix), _
                        DBParametro_Montar("SQCTRPAFNEGMOV", oDataAux.Rows(iContAux).Item("sq_ctr_paf_neg_movimentacao")), _
                        DBParametro_Montar("SQCTRFIX", oData.Rows(iCont).Item("sq_contrato_fixo")), _
                        DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                        DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                        DBParametro_Montar("DSCONCILIACAO", Nothing)) Then


                        TextoErro = TextoErro & "Erro aplicação cacau contrato: " & oData.Rows(iCont).Item("cd_contrato_paf") & _
                                    "-" & oData.Rows(iCont).Item("sq_negociacao") & "-" & oData.Rows(iCont).Item("sq_contrato_fixo") & _
                                    vbCrLf & "Descrição: " & Err.Description & vbCrLf
                        GoTo Erro
                        Exit For
                    End If
                End If

                VlFixado = VlFixado + VlFix

                If VlFixado = VlCtr Then Exit For
            Next
        Next

        'RETIRA AS NF QUE POSSUEM SALDO DE VALOR E NAO POSSUEM SALDO DE QUILOS DOS CONTRATOS PAF QUE NAO
        'TEM MAIS NADA EM ABERTO NOS CONTRATOS FIXOS
        SqlText = "SELECT CM.SQ_MOVIMENTACAO, CM.SQ_CTR_PAF_MOVIMENTACAO, "
        SqlText = SqlText & "       CM.SQ_CTR_PAF_NEG_MOVIMENTACAO, CM.QT_KG_A_FIXAR, CM.VL_A_FIXAR, "
        SqlText = SqlText & "       CM.SQ_MOVIMENTACAO_CESSAO_DIREITO, CM.CD_CONTRATO_PAF, CM.SQ_NEGOCIACAO, "
        SqlText = SqlText & "       CM.QT_KG_FIXO, CM.VL_FIXO "
        SqlText = SqlText & "FROM SOF.CTR_PAF_NEG_MOVIMENTACAO CM, "
        SqlText = SqlText & "     SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & "     sof.fornecedor f "
        SqlText = SqlText & "WHERE CM.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      cp.cd_fornecedor = f.cd_fornecedor and "
        SqlText = SqlText & "      f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "      CM.QT_KG_A_FIXAR = 0 AND "
        SqlText = SqlText & "      CM.VL_A_FIXAR <> 0 "

        If CdContratoPAF <> -1 Then
            SqlText = SqlText & " and cp.cd_contrato_paf=" & CdContratoPAF
        End If

        oData = DBQuery(SqlText)
        oForm.Inclementa_Valor_ProgressBar(ValorProgressBar)
        oForm.Refresh()

        For iCont = 0 To oData.Rows.Count - 1
            If oData.Rows(iCont).Item("VL_A_FIXAR") = oData.Rows(iCont).Item("VL_FIXO") And oData.Rows(iCont).Item("QT_KG_A_FIXAR") = oData.Rows(iCont).Item("QT_KG_FIXO") Then
                SqlText = "DELETE FROM SOF.CTR_PAF_NEG_MOVIMENTACAO " & _
                          "WHERE SQ_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO") & " AND " & _
                          "SQ_MOVIMENTACAO_CESSAO_DIREITO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & " AND " & _
                          "CD_CONTRATO_PAF = " & oData.Rows(iCont).Item("CD_CONTRATO_PAF") & " AND " & _
                          "SQ_CTR_PAF_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_CTR_PAF_MOVIMENTACAO") & " AND " & _
                          "SQ_NEGOCIACAO = " & oData.Rows(iCont).Item("SQ_NEGOCIACAO") & " AND " & _
                          "SQ_CTR_PAF_NEG_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_CTR_PAF_NEG_MOVIMENTACAO")
                If Not DBExecutar(SqlText) Then GoTo Erro
            Else
                SqlText = "UPDATE SOF.CTR_PAF_NEG_MOVIMENTACAO " & _
                          "SET VL_FIXO = VL_FIXO - " & oData.Rows(iCont).Item("VL_A_FIXAR") & ", " & _
                          "VL_A_FIXAR = VL_A_FIXAR - " & oData.Rows(iCont).Item("VL_A_FIXAR") & ", " & _
                          "QT_KG_FIXO = QT_KG_FIXO - " & 0 & ", " & _
                          "QT_KG_A_FIXAR = QT_KG_A_FIXAR - " & 0 & " " & _
                          "WHERE SQ_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO") & " AND " & _
                          "SQ_MOVIMENTACAO_CESSAO_DIREITO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & " AND " & _
                          "CD_CONTRATO_PAF = " & oData.Rows(iCont).Item("CD_CONTRATO_PAF") & " AND " & _
                          "SQ_CTR_PAF_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_CTR_PAF_MOVIMENTACAO") & " AND " & _
                          "SQ_NEGOCIACAO = " & oData.Rows(iCont).Item("SQ_NEGOCIACAO") & " AND " & _
                          "SQ_CTR_PAF_NEG_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_CTR_PAF_NEG_MOVIMENTACAO")
                If Not DBExecutar(SqlText) Then GoTo Erro
            End If
        Next

        'APLICA AS NF QUE TEM SALDO EM VALOR E NAO TEM SALDO EM QUILOS NOS CONTRATOS FIXOS QUE PRECISAO
        'DE NF COMPLEMENTAR
        SqlText = "SELECT cf.cd_contrato_paf, cf.sq_negociacao, cf.sq_contrato_fixo, cp.cd_fornecedor, "
        SqlText = SqlText & "       round((((((CF.QT_KGS - CF.QT_CANCELADO) / CF.QT_KGS) * (CF.VL_TOTAL + CF.VL_ICMS)) "
        SqlText = SqlText & "              + CF.VL_ADENDO + CF.VL_ADENDO_ICMS) - CF.VL_NF_FIXO + CF.VL_NF_INSS_FIXO) "
        SqlText = SqlText & "              / (1 - (FUN.VL_TAXA / 100)),2) vl_saldo, cf.pc_aliq_icms "
        SqlText = SqlText & "FROM SOF.CONTRATO_FIXO CF, SOF.NEGOCIACAO N, SOF.CONTRATO_PAF CP, SOF.FORNECEDOR F, "
        SqlText = SqlText & "     SOF.FUNRURAL FUN "
        SqlText = SqlText & "WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      CF.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      CF.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO AND "
        SqlText = SqlText & "      CP.CD_FORNECEDOR = F.CD_FORNECEDOR AND "
        SqlText = SqlText & "      F.CD_FUNRURAL = FUN.CD_FUNRURAL AND "
        SqlText = SqlText & "      CF.IC_STATUS = 'A' AND "
        SqlText = SqlText & "      f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "      round((((((CF.QT_KGS - CF.QT_CANCELADO) / CF.QT_KGS) * (CF.VL_TOTAL + CF.VL_ICMS)) "
        SqlText = SqlText & "              + CF.VL_ADENDO + CF.VL_ADENDO_ICMS) - CF.VL_NF_FIXO + CF.VL_NF_INSS_FIXO) "
        SqlText = SqlText & "              / (1 - (FUN.VL_TAXA / 100)),2)<>0 and "
        SqlText = SqlText & "      (CF.QT_KGS - CF.QT_CANCELADO) = CF.QT_KG_FIXO and "
        SqlText = SqlText & "      cf.cd_contrato_paf in (select distinct CM.cd_contrato_paf "
        SqlText = SqlText & "                           from sof.ctr_paf_movimentacao cm, sof.movimentacao m, "
        SqlText = SqlText & "                                sof.contrato_paf cp, sof.fornecedor f "
        SqlText = SqlText & "                           where cm.sq_movimentacao = m.sq_movimentacao and "
        SqlText = SqlText & "                                 cm.cd_contrato_paf = cp.cd_contrato_paf and "
        SqlText = SqlText & "                                 cp.cd_fornecedor = f.cd_fornecedor and "
        SqlText = SqlText & "                                 f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "                                 cm.qt_kg_a_fixar = 0 and cm.vl_a_fixar <> 0) "

        If CdContratoPAF <> -1 Then
            SqlText = SqlText & " and cp.cd_contrato_paf=" & CdContratoPAF
        End If

        SqlText = SqlText & "order by cf.dt_vencimento "

        oData = DBQuery(SqlText)
        oForm.Inclementa_Valor_ProgressBar(ValorProgressBar)
        oForm.Refresh()

        For iCont = 0 To oData.Rows.Count - 1
            VlFixado = 0
            VlCtr = oData.Rows(iCont).Item("vl_saldo")

            If QtCtr > 0 Then
                SqlText = "select cm.sq_movimentacao, cm.sq_ctr_paf_movimentacao, "
                SqlText = SqlText & "       cm.qt_kg_a_fixar, cm.vl_a_fixar, cm.sq_movimentacao_cessao_direito "
                SqlText = SqlText & "from sof.ctr_paf_movimentacao cm, "
                SqlText = SqlText & "     sof.movimentacao m  "
                SqlText = SqlText & "where cm.sq_movimentacao = m.sq_movimentacao and "
                SqlText = SqlText & "      round(m.vl_nf_icms * 100 / m.VL_NF,3) = " & oData.Rows(iCont).Item("pc_aliq_icms") & " and "
                SqlText = SqlText & "      cm.qt_kg_a_fixar = 0 and cm.vl_a_fixar <> 0 and "
                SqlText = SqlText & "      cm.cd_contrato_paf = " & oData.Rows(iCont).Item("cd_contrato_paf") & " "

                'COM ESSE RECURSO SÓ FAZ A APLICAÇÃO SE FOR NF COMPLEMENTAR
                SqlText = SqlText & " and m.qt_kg_NF = 0 "

                SqlText = SqlText & "order by cm.sq_movimentacao "
                oDataAux = DBQuery(SqlText)


                For iContAux = 0 To oDataAux.Rows.Count - 1
                    QtFix = 0
                    VlFix = oDataAux.Rows(iContAux).Item("vl_a_fixar")

                    If VlFixado + VlFix > VlCtr Then
                        VlFix = VlCtr - VlFixado
                    End If

                    If Not (VlFix = 0 And QtFix = 0) Then

                        DBUsarTransacao = True

                        Verifica_Situacao_Contrato(oData.Rows(iCont).Item("cd_contrato_paf"), oData.Rows(iCont).Item("sq_negociacao"), -1)

                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", _
                                                             ":SQNEG", _
                                                             ":SQCTRPAFMOV", _
                                                             ":SQMOV", _
                                                             ":SQMOVCD", _
                                                              ":VLFIXO", _
                                                             ":QTFIXO", _
                                                             ":SQCTRPAFNEGMOV")

                        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("cd_contrato_paf")), _
                            DBParametro_Montar("SQNEG", oData.Rows(iCont).Item("sq_negociacao")), _
                            DBParametro_Montar("SQCTRPAFMOV", oDataAux.Rows(iContAux).Item("sq_ctr_paf_movimentacao")), _
                            DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("sq_movimentacao")), _
                            DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("Sq_Movimentacao_Cessao_Direito")), _
                            DBParametro_Montar("VLFIXO", VlFix), _
                            DBParametro_Montar("QTFIXO", QtFix), _
                            DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo ERRO


                        If DBTeveRetorno() Then
                            SqCtrPAFNegMov = DBRetorno(1)
                        End If

                        SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, ":CDCTRPAF", _
                                                                  ":SQNEG", _
                                                                  ":SQCTRPAFMOV", _
                                                                  ":SQMOV", _
                                                                  ":SQMOVCD", _
                                                                   ":VLFIXO", _
                                                                  ":QTFIXO", _
                                                                  ":SQCTRPAFNEGMOV", _
                                                                  ":SQCTRFIX", _
                                                                  ":SQCTRPAFNEGCTRFIXMOV", _
                                                                  ":ICGERACONCILIACAO", _
                                                                  ":DSCONCILIACAO")

                        If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("cd_contrato_paf")), _
                            DBParametro_Montar("SQNEG", oData.Rows(iCont).Item("sq_negociacao")), _
                            DBParametro_Montar("SQCTRPAFMOV", oDataAux.Rows(iContAux).Item("sq_ctr_paf_movimentacao")), _
                            DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("sq_movimentacao")), _
                            DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("Sq_Movimentacao_Cessao_Direito")), _
                            DBParametro_Montar("VLFIXO", VlFix), _
                            DBParametro_Montar("QTFIXO", QtFix), _
                            DBParametro_Montar("SQCTRPAFNEGMOV", SqCtrPAFNegMov), _
                            DBParametro_Montar("SQCTRFIX", oData.Rows(iCont).Item("sq_contrato_fixo")), _
                            DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                            DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                            DBParametro_Montar("DSCONCILIACAO", Nothing)) Then


                            TextoErro = TextoErro & "Erro aplicação cacau contrato: " & oData.Rows(iCont).Item("cd_contrato_paf") & _
                                        "-" & oData.Rows(iCont).Item("sq_negociacao") & "-" & oData.Rows(iCont).Item("sq_contrato_fixo") & _
                                        vbCrLf & "Descrição: " & Err.Description & vbCrLf
                            GoTo Erro
                            Exit For
                        End If

                        If Not DBExecutarTransacao() Then GoTo eRRO
                    End If
                    VlFixado = VlFixado + VlFix

                    If VlFixado = VlCtr Then Exit For

                Next
            End If
        Next

        SqlText = "SELECT cf.cd_contrato_paf, cf.sq_negociacao, cf.sq_contrato_fixo, cp.cd_fornecedor, "
        SqlText = SqlText & "       round((((((CF.QT_KGS - CF.QT_CANCELADO) / CF.QT_KGS) * (CF.VL_TOTAL + CF.VL_ICMS)) "
        SqlText = SqlText & "              + CF.VL_ADENDO + CF.VL_ADENDO_ICMS) - CF.VL_NF_FIXO + CF.VL_NF_INSS_FIXO) "
        SqlText = SqlText & "              / (1 - (FUN.VL_TAXA / 100)),2) vl_saldo, "
        SqlText = SqlText & "       CP.IC_STATUS IC_STATUS_PAF, N.IC_STATUS IC_STATUS_NEG, cf.pc_aliq_icms "
        SqlText = SqlText & "FROM SOF.CONTRATO_FIXO CF, SOF.NEGOCIACAO N, SOF.CONTRATO_PAF CP, SOF.FORNECEDOR F, "
        SqlText = SqlText & "     SOF.FUNRURAL FUN "
        SqlText = SqlText & "WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      CF.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      CF.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO AND "
        SqlText = SqlText & "      CP.CD_FORNECEDOR = F.CD_FORNECEDOR AND "
        SqlText = SqlText & "      F.CD_FUNRURAL = FUN.CD_FUNRURAL AND "
        SqlText = SqlText & "      CF.IC_STATUS = 'A' AND "
        SqlText = SqlText & "      f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "      not round((((((CF.QT_KGS - CF.QT_CANCELADO) / CF.QT_KGS) * (CF.VL_TOTAL + CF.VL_ICMS)) "
        SqlText = SqlText & "              + CF.VL_ADENDO + CF.VL_ADENDO_ICMS) - CF.VL_NF_FIXO + CF.VL_NF_INSS_FIXO) "
        SqlText = SqlText & "              / (1 - (FUN.VL_TAXA / 100)),2) between -0.01 and 0 and "
        SqlText = SqlText & "      (CF.QT_KGS - CF.QT_CANCELADO) = CF.QT_KG_FIXO and "
        SqlText = SqlText & "      cp.cd_fornecedor in (select distinct cp.cd_fornecedor "
        SqlText = SqlText & "                           from sof.ctr_paf_movimentacao cm, sof.movimentacao m, "
        SqlText = SqlText & "                                sof.contrato_paf cp, sof.fornecedor f "
        SqlText = SqlText & "                           where cm.sq_movimentacao = m.sq_movimentacao and "
        SqlText = SqlText & "                                 cm.cd_contrato_paf = cp.cd_contrato_paf and "
        SqlText = SqlText & "                                 cp.cd_fornecedor = f.cd_fornecedor and "
        SqlText = SqlText & "                                 f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "                                 cm.qt_kg_a_fixar = 0  and cm.vl_a_fixar <> 0) "

        If CdContratoPAF <> -1 Then
            SqlText = SqlText & " and cp.cd_contrato_paf=" & CdContratoPAF
        End If

        SqlText = SqlText & " order by decode(cf.vl_pag_fixo,0,1,0), cf.dt_vencimento "
        oData = DBQuery(SqlText)
        oForm.Inclementa_Valor_ProgressBar(ValorProgressBar)
        oForm.Refresh()

        For iCont = 0 To oData.Rows.Count - 1
            VlFixado = 0
            VlCtr = oData.Rows(iCont).Item("vl_saldo")

            SqlText = "SELECT CM.SQ_MOVIMENTACAO, CM.SQ_CTR_PAF_MOVIMENTACAO, "
            SqlText = SqlText & "       CM.QT_KG_A_FIXAR, CM.VL_A_FIXAR, "
            SqlText = SqlText & "       CM.SQ_MOVIMENTACAO_CESSAO_DIREITO, CM.CD_CONTRATO_PAF, "
            SqlText = SqlText & "       CM.QT_KG_FIXO, CM.VL_FIXO, M.qt_kg_NF "
            SqlText = SqlText & "FROM SOF.CTR_PAF_MOVIMENTACAO CM, "
            SqlText = SqlText & "     SOF.CONTRATO_PAF CP, sof.movimentacao m "
            SqlText = SqlText & "WHERE CM.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF AND "
            SqlText = SqlText & "      cm.sq_movimentacao=m.sq_movimentacao and "
            SqlText = SqlText & "      round(m.vl_nf_icms * 100 / m.VL_NF,3) = " & oData.Rows(iCont).Item("pc_aliq_icms") & " and "
            SqlText = SqlText & "      CP.CD_FORNECEDOR = " & oData.Rows(iCont).Item("cd_fornecedor") & " AND "
            SqlText = SqlText & "      CM.QT_KG_A_FIXAR = 0 AND "
            SqlText = SqlText & "      CM.VL_A_FIXAR > 0 "
            SqlText = SqlText & "ORDER BY CM.SQ_MOVIMENTACAO "
            oDataAux = DBQuery(SqlText)

            For iContAux = 0 To oDataAux.Rows.Count - 1
                QtFix = 0
                VlFix = oDataAux.Rows(iContAux).Item("vl_a_fixar")

                If VlFixado + VlFix > VlCtr Then
                    VlFix = VlCtr - VlFixado

                    If oDataAux.Rows(iContAux).Item("qt_kg_NF") <> 0 Then
                        QtFix = Math.Truncate(VlFix / oDataAux.Rows(iContAux).Item("vl_a_fixar") * oDataAux.Rows(iContAux).Item("qt_kg_a_fixar"))
                        If oDataAux.Rows(iContAux).Item("qt_kg_a_fixar") * oDataAux.Rows(iContAux).Item("vl_a_fixar") = 0 Then
                            VlFix = 0
                        Else
                            VlFix = FC_Round(QtFix / oDataAux.Rows(iContAux).Item("qt_kg_a_fixar") * oDataAux.Rows(iContAux).Item("vl_a_fixar"), 2)
                        End If
                    End If
                End If

                DBUsarTransacao = True

                If VlFix = oDataAux.Rows(iContAux).Item("VL_FIXO") And oDataAux.Rows(iContAux).Item("QT_KG_A_FIXAR") = oDataAux.Rows(iContAux).Item("QT_KG_FIXO") Then
                    SqlText = "select count(*) qt "
                    SqlText = SqlText & "from sof.ctr_paf_neg_movimentacao cm "
                    SqlText = SqlText & "where cm.sq_movimentacao = " & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO") & " and "
                    SqlText = SqlText & "      cm.sq_movimentacao_cessao_direito = " & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & " and "
                    SqlText = SqlText & "      cm.cd_contrato_paf = " & oDataAux.Rows(iContAux).Item("CD_CONTRATO_PAF") & " and "
                    SqlText = SqlText & "      cm.sq_ctr_paf_movimentacao = " & oDataAux.Rows(iContAux).Item("SQ_CTR_PAF_MOVIMENTACAO")

                    If DBQuery_ValorUnico(SqlText) = 0 Then
                        SqlText = "select cm.qt_kg_fixo, cm.qt_kg_a_fixar, cm.vl_fixo, cm.vl_a_fixar "
                        SqlText = SqlText & "from sof.ctr_paf_movimentacao cm "
                        SqlText = SqlText & "where cm.sq_movimentacao = " & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO") & " and "
                        SqlText = SqlText & "      cm.sq_movimentacao_cessao_direito = " & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & " and "
                        SqlText = SqlText & "      cm.cd_contrato_paf = " & oDataAux.Rows(iContAux).Item("CD_CONTRATO_PAF") & " and "
                        SqlText = SqlText & "      cm.sq_ctr_paf_movimentacao = " & oDataAux.Rows(iContAux).Item("SQ_CTR_PAF_MOVIMENTACAO")
                        oDataAux2 = DBQuery(SqlText)

                        If oDataAux2.Rows(0).Item("qt_kg_a_fixar") = oDataAux2.Rows(0).Item("qt_kg_fixo") And VlFix = oDataAux2.Rows(0).Item("vl_fixo") Then
                            SqlText = "DELETE FROM SOF.CTR_PAF_MOVIMENTACAO " & _
                                      "WHERE SQ_MOVIMENTACAO = " & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO") & " AND " & _
                                      "SQ_MOVIMENTACAO_CESSAO_DIREITO = " & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & " AND " & _
                                      "CD_CONTRATO_PAF = " & oDataAux.Rows(iContAux).Item("CD_CONTRATO_PAF") & " AND " & _
                                      "SQ_CTR_PAF_MOVIMENTACAO = " & oDataAux.Rows(iContAux).Item("SQ_CTR_PAF_MOVIMENTACAO")
                            If Not DBExecutar(SqlText) Then GoTo Erro
                        Else
                            SqlText = "UPDATE SOF.CTR_PAF_MOVIMENTACAO " & _
                                      "SET VL_FIXO = VL_FIXO - " & VlFix & ", " & _
                                      "VL_A_FIXAR = VL_A_FIXAR - " & VlFix & ", " & _
                                      "QT_KG_FIXO = QT_KG_FIXO - " & 0 & ", " & _
                                      "QT_KG_A_FIXAR = QT_KG_A_FIXAR - " & 0 & " " & _
                                      "WHERE SQ_MOVIMENTACAO = " & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO") & " AND " & _
                                      "SQ_MOVIMENTACAO_CESSAO_DIREITO = " & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & " AND " & _
                                      "CD_CONTRATO_PAF = " & oDataAux.Rows(iContAux).Item("CD_CONTRATO_PAF") & " AND " & _
                                      "SQ_CTR_PAF_MOVIMENTACAO = " & oDataAux.Rows(iContAux).Item("SQ_CTR_PAF_MOVIMENTACAO")
                            If Not DBExecutar(SqlText) Then GoTo Erro
                        End If
                    Else
                        SqlText = "UPDATE SOF.CTR_PAF_MOVIMENTACAO " & _
                                  "SET VL_FIXO = VL_FIXO - " & VlFix & ", " & _
                                  "VL_A_FIXAR = VL_A_FIXAR - " & VlFix & ", " & _
                                  "QT_KG_FIXO = QT_KG_FIXO - " & 0 & ", " & _
                                  "QT_KG_A_FIXAR = QT_KG_A_FIXAR - " & 0 & " " & _
                                  "WHERE SQ_MOVIMENTACAO = " & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO") & " AND " & _
                                  "SQ_MOVIMENTACAO_CESSAO_DIREITO = " & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & " AND " & _
                                  "CD_CONTRATO_PAF = " & oDataAux.Rows(iContAux).Item("CD_CONTRATO_PAF") & " AND " & _
                                  "SQ_CTR_PAF_MOVIMENTACAO = " & oDataAux.Rows(iContAux).Item("SQ_CTR_PAF_MOVIMENTACAO")
                        If Not DBExecutar(SqlText) Then GoTo Erro
                    End If
                Else
                    SqlText = "UPDATE SOF.CTR_PAF_MOVIMENTACAO " & _
                              "SET VL_FIXO = VL_FIXO - " & VlFix & ", " & _
                              "VL_A_FIXAR = VL_A_FIXAR - " & VlFix & ", " & _
                              "QT_KG_FIXO = QT_KG_FIXO - " & 0 & ", " & _
                              "QT_KG_A_FIXAR = QT_KG_A_FIXAR - " & 0 & " " & _
                              "WHERE SQ_MOVIMENTACAO = " & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO") & " AND " & _
                              "SQ_MOVIMENTACAO_CESSAO_DIREITO = " & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & " AND " & _
                              "CD_CONTRATO_PAF = " & oDataAux.Rows(iContAux).Item("CD_CONTRATO_PAF") & " AND " & _
                              "SQ_CTR_PAF_MOVIMENTACAO = " & oDataAux.Rows(iContAux).Item("SQ_CTR_PAF_MOVIMENTACAO")
                    If Not DBExecutar(SqlText) Then
                        TextoErro = TextoErro & "Erro aplicação cacau contrato: " & oData.Rows(iCont).Item("cd_contrato_paf") & _
                                    "-" & oData.Rows(iCont).Item("sq_negociacao") & "-" & oData.Rows(iCont).Item("sq_contrato_fixo") & _
                                    vbCrLf & "Descrição: " & Err.Description & vbCrLf

                        GoTo Erro
                        Exit For
                    End If
                End If

                Verifica_Situacao_Contrato(oData.Rows(iCont).Item("CD_CONTRATO_PAF"), -1, -1)

                sErro_Complemento = "Contrato PAF: " & oData.Rows(iCont).Item("CD_CONTRATO_PAF") & _
                                 " - Mov. Nº:" & oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO")

                SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", ":SQMOV", ":SQMOVCD", ":VLFIXO", ":QTFIXO", ":SQCTRPAFMOV")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("CD_CONTRATO_PAF")), _
                                           DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO")), _
                                           DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO")), _
                                           DBParametro_Montar("VLFIXO", VlFix), _
                                           DBParametro_Montar("QTFIXO", QtFix), _
                                           DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                If DBTeveRetorno() Then
                    SqCtrPAFMov = DBRetorno(1)
                End If

                sErro_Complemento = ""

                Verifica_Situacao_Contrato(oData.Rows(iCont).Item("cd_contrato_paf"), oData.Rows(iCont).Item("sq_negociacao"), -1)

                SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", _
                                                                              ":SQNEG", _
                                                                              ":SQCTRPAFMOV", _
                                                                              ":SQMOV", _
                                                                              ":SQMOVCD", _
                                                                              ":VLFIXO", _
                                                                              ":QTFIXO", _
                                                                              ":SQCTRPAFNEGMOV")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("CD_CONTRATO_PAF")), _
                                           DBParametro_Montar("SQNEG", oData.Rows(iCont).Item("SQ_NEGOCIACAO")), _
                                           DBParametro_Montar("SQCTRPAFMOV", SqCtrPAFMov), _
                                           DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO")), _
                                           DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO")), _
                                           DBParametro_Montar("VLFIXO", VlFix), _
                                           DBParametro_Montar("QTFIXO", QtFix), _
                                           DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo ERRO

                If DBTeveRetorno() Then
                    SqCtrPAFNegMov = DBRetorno(1)
                End If

                SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, ":CDCTRPAF", _
                                                                                   ":SQNEG", _
                                                                                   ":SQCTRPAFMOV", _
                                                                                   ":SQMOV", _
                                                                                   ":SQMOVCD", _
                                                                                   ":VLFIXO", _
                                                                                   ":QTFIXO", _
                                                                                   ":SQCTRPAFNEGMOV", _
                                                                                   ":SQCTRFIX", _
                                                                                   ":SQCTRPAFNEGCTRFIXMOV", _
                                                                                   ":ICGERACONCILIACAO", _
                                                                                   ":DSCONCILIACAO")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("CD_CONTRATO_PAF")), _
                                           DBParametro_Montar("SQNEG", oData.Rows(iCont).Item("SQ_NEGOCIACAO")), _
                                           DBParametro_Montar("SQCTRPAFMOV", SqCtrPAFMov), _
                                           DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO")), _
                                           DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO")), _
                                           DBParametro_Montar("VLFIXO", VlFix), _
                                           DBParametro_Montar("QTFIXO", QtFix), _
                                           DBParametro_Montar("SQCTRPAFNEGMOV", SqCtrPAFNegMov), _
                                           DBParametro_Montar("SQCTRFIX", oData.Rows(iCont).Item("SQ_CONTRATO_FIXO")), _
                                           DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                                           DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                                           DBParametro_Montar("DSCONCILIACAO", Nothing)) Then

                    TextoErro = TextoErro & "Erro aplicação cacau contrato: " & oData.Rows(iCont).Item("CD_CONTRATO_PAF") & "-" _
                                                                              & oData.Rows(iCont).Item("SQ_NEGOCIACAO") & "-" _
                                                                              & oData.Rows(iCont).Item("SQ_CONTRATO_FIXO") & vbCrLf & _
                                            "Descrição: " & Err.Description & vbCrLf

                    GoTo Erro

                    Exit For
                End If

                If Not DBExecutarTransacao() Then GoTo eRRO

                VlFixado = VlFixado + VlFix

                If VlFixado = VlCtr Then Exit For
            Next
        Next






        SqlText = "SELECT cf.cd_contrato_paf, cf.sq_negociacao, cf.sq_contrato_fixo, cp.cd_fornecedor, "
        SqlText = SqlText & "       round((((((CF.QT_KGS - CF.QT_CANCELADO) / CF.QT_KGS) * (CF.VL_TOTAL + CF.VL_ICMS)) "
        SqlText = SqlText & "              + CF.VL_ADENDO + CF.VL_ADENDO_ICMS) - CF.VL_NF_FIXO + CF.VL_NF_INSS_FIXO) "
        SqlText = SqlText & "              / (1 - (FUN.VL_TAXA / 100)),2) vl_saldo, cf.pc_aliq_icms "
        SqlText = SqlText & "FROM SOF.CONTRATO_FIXO CF, SOF.NEGOCIACAO N, SOF.CONTRATO_PAF CP, SOF.FORNECEDOR F, "
        SqlText = SqlText & "     SOF.FUNRURAL FUN "
        SqlText = SqlText & "WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      CF.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      CF.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO AND "
        SqlText = SqlText & "      CP.CD_FORNECEDOR = F.CD_FORNECEDOR AND "
        SqlText = SqlText & "      F.CD_FUNRURAL = FUN.CD_FUNRURAL AND "
        SqlText = SqlText & "      CF.IC_STATUS = 'A' AND "
        SqlText = SqlText & "      f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "      round((((((CF.QT_KGS - CF.QT_CANCELADO) / CF.QT_KGS) * (CF.VL_TOTAL + CF.VL_ICMS)) "
        SqlText = SqlText & "              + CF.VL_ADENDO + CF.VL_ADENDO_ICMS) - CF.VL_NF_FIXO + CF.VL_NF_INSS_FIXO) "
        SqlText = SqlText & "              / (1 - (FUN.VL_TAXA / 100)),2)<>0 and "
        SqlText = SqlText & "      (CF.QT_KGS - CF.QT_CANCELADO) = CF.QT_KG_FIXO and "
        SqlText = SqlText & "      cp.cd_fornecedor in (select distinct m.cd_fornecedor "
        SqlText = SqlText & "                           from sof.movimentacao_cessao_direito m, "
        SqlText = SqlText & "                                sof.fornecedor f "
        SqlText = SqlText & "                           where m.cd_fornecedor = f.cd_fornecedor and "
        SqlText = SqlText & "                                 f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "                                 m.qt_kg_a_fixar = 0 and m.vl_a_fixar <> 0) "

        If CdContratoPAF <> -1 Then
            SqlText = SqlText & " and cp.cd_contrato_paf=" & CdContratoPAF
        End If

        SqlText = SqlText & " order by decode(n.vl_pag_fixo,0,1,0), cf.dt_vencimento "
        oData = DBQuery(SqlText)
        oForm.Inclementa_Valor_ProgressBar(ValorProgressBar)
        oForm.Refresh()

        For iCont = 0 To oData.Rows.Count - 1
            VlFixado = 0
            VlCtr = oData.Rows(iCont).Item("vl_saldo")


            SqlText = "select m.sq_movimentacao, m.sq_movimentacao_cessao_direito, m.vl_a_fixar, MOV.qt_kg_NF "
            SqlText = SqlText & "from sof.movimentacao_cessao_direito m,sof.movimentacao mov, "
            SqlText = SqlText & "     sof.fornecedor f "
            SqlText = SqlText & "where m.cd_fornecedor = f.cd_fornecedor and "
            SqlText = SqlText & "      m.sq_movimentacao=mov.sq_movimentacao and "
            SqlText = SqlText & "      round(mov.vl_nf_icms * 100 / mov.VL_NF,3) = " & oData.Rows(iCont).Item("pc_aliq_icms") & " and "
            SqlText = SqlText & "      f.cd_fornecedor = " & oData.Rows(iCont).Item("cd_fornecedor") & " and "
            SqlText = SqlText & "      m.qt_kg_a_fixar = 0 and m.vl_a_fixar <> 0 "
            SqlText = SqlText & "ORDER BY m.SQ_MOVIMENTACAO "
            oDataAux = DBQuery(SqlText)

            For iContAux = 0 To oDataAux.Rows.Count - 1
                QtFix = 0
                VlFix = oDataAux.Rows(iContAux).Item("vl_a_fixar")

                If VlFixado + VlFix > VlCtr Then
                    VlFix = VlCtr - VlFixado

                    If oDataAux.Rows(iContAux).Item("qt_kg_NF") <> 0 Then
                        QtFix = Math.Truncate(VlFix / oDataAux.Rows(iContAux).Item("vl_a_fixar") * oDataAux.Rows(iContAux).Item("qt_kg_a_fixar"))
                        VlFix = FC_Round(QtFix / oDataAux.Rows(iContAux).Item("qt_kg_a_fixar") * oDataAux.Rows(iContAux).Item("vl_a_fixar"), 2)
                    End If
                End If
                If Not (VlFix = 0 And QtFix = 0) Then

                    DBUsarTransacao = True

                    Verifica_Situacao_Contrato(oData.Rows(iCont).Item("cd_contrato_paf"), oData.Rows(iCont).Item("sq_negociacao"), -1)

                    SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", _
                                 ":SQMOV", _
                                 ":SQMOVCD", _
                                 ":VLFIXO", _
                                 ":QTFIXO", _
                                 ":SQCTRPAFMOV")

                    If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("cd_contrato_paf")), _
                                               DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("sq_movimentacao")), _
                                               DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("Sq_Movimentacao_Cessao_Direito")), _
                                               DBParametro_Montar("VLFIXO", VlFix), _
                                               DBParametro_Montar("QTFIXO", QtFix), _
                                               DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                    If DBTeveRetorno() Then
                        SqCtrPAFMov = DBRetorno(1)
                    End If

                    SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_NEG_MOV", False, ":CDCTRPAF", _
                                                              ":SQNEG", _
                                                          ":SQCTRPAFMOV", _
                                                          ":SQMOV", _
                                                          ":SQMOVCD", _
                                                           ":VLFIXO", _
                                                          ":QTFIXO", _
                                                          ":SQCTRPAFNEGMOV")

                    If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("cd_contrato_paf")), _
                        DBParametro_Montar("SQNEG", oData.Rows(iCont).Item("sq_negociacao")), _
                        DBParametro_Montar("SQCTRPAFMOV", SqCtrPAFMov), _
                        DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("sq_movimentacao")), _
                        DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("Sq_Movimentacao_Cessao_Direito")), _
                        DBParametro_Montar("VLFIXO", VlFix), _
                        DBParametro_Montar("QTFIXO", QtFix), _
                        DBParametro_Montar("SQCTRPAFNEGMOV", Nothing, , ParameterDirection.Output)) Then GoTo ERRO


                    If DBTeveRetorno() Then
                        SqCtrPAFNegMov = DBRetorno(1)
                    End If

                    SqlText = DBMontar_SP("SOF.SP_INCLUI_CTRPAF_NEG_CTRFIXMOV", False, ":CDCTRPAF", _
                                                              ":SQNEG", _
                                                              ":SQCTRPAFMOV", _
                                                              ":SQMOV", _
                                                              ":SQMOVCD", _
                                                               ":VLFIXO", _
                                                              ":QTFIXO", _
                                                              ":SQCTRPAFNEGMOV", _
                                                              ":SQCTRFIX", _
                                                              ":SQCTRPAFNEGCTRFIXMOV", _
                                                              ":ICGERACONCILIACAO", _
                                                              ":DSCONCILIACAO")

                    If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("cd_contrato_paf")), _
                        DBParametro_Montar("SQNEG", oData.Rows(iCont).Item("sq_negociacao")), _
                        DBParametro_Montar("SQCTRPAFMOV", SqCtrPAFMov), _
                        DBParametro_Montar("SQMOV", oDataAux.Rows(iContAux).Item("sq_movimentacao")), _
                        DBParametro_Montar("SQMOVCD", oDataAux.Rows(iContAux).Item("Sq_Movimentacao_Cessao_Direito")), _
                        DBParametro_Montar("VLFIXO", VlFix), _
                        DBParametro_Montar("QTFIXO", QtFix), _
                        DBParametro_Montar("SQCTRPAFNEGMOV", SqCtrPAFNegMov), _
                        DBParametro_Montar("SQCTRFIX", oData.Rows(iCont).Item("sq_contrato_fixo")), _
                        DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", Nothing, , ParameterDirection.Output), _
                        DBParametro_Montar("ICGERACONCILIACAO", "N"), _
                        DBParametro_Montar("DSCONCILIACAO", Nothing)) Then


                        TextoErro = TextoErro & "Erro aplicação cacau contrato: " & oData.Rows(iCont).Item("cd_contrato_paf") & _
                                    "-" & oData.Rows(iCont).Item("sq_negociacao") & "-" & oData.Rows(iCont).Item("sq_contrato_fixo") & _
                                    vbCrLf & "Descrição: " & Err.Description & vbCrLf
                        GoTo Erro
                        Exit For
                    End If

                    If Not DBExecutarTransacao() Then GoTo Erro
                End If
                VlFixado = VlFixado + VlFix

                If VlFixado = VlCtr Then Exit For
            Next
        Next

        SqlText = "select distinct cm.sq_movimentacao, cm.sq_movimentacao_cessao_direito, "
        SqlText = SqlText & "       cm.cd_contrato_paf, cm.sq_ctr_paf_movimentacao, cp.cd_fornecedor, "
        SqlText = SqlText & "       cm.qt_kg_fixo, cm.qt_kg_a_fixar, cm.vl_fixo, cm.vl_a_fixar "
        SqlText = SqlText & "from sof.ctr_paf_movimentacao cm, "
        SqlText = SqlText & "     sof.contrato_paf cp, "
        SqlText = SqlText & "     sof.tipo_contrato_paf tcp, "
        SqlText = SqlText & "     sof.fornecedor f, "
        SqlText = SqlText & "     sof.negociacao n "
        SqlText = SqlText & "where cm.cd_contrato_paf = cp.cd_contrato_paf and "
        SqlText = SqlText & "      cp.cd_tipo_contrato_paf = tcp.cd_tipo_contrato_paf and "
        SqlText = SqlText & "      cp.cd_fornecedor = f.cd_fornecedor and "
        SqlText = SqlText & "      cp.cd_contrato_paf = n.cd_contrato_paf and "
        SqlText = SqlText & "      n.qt_a_fixar = 0 and "
        SqlText = SqlText & "      cp.qt_a_negociar = 0 and "
        SqlText = SqlText & "      f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "      tcp.ic_adiantamento = 'S' and "
        SqlText = SqlText & "      (cm.qt_kg_a_fixar = 0 and cm.vl_a_fixar > 0) and "
        SqlText = SqlText & "      cp.cd_fornecedor in (select distinct cp.cd_fornecedor "
        SqlText = SqlText & "                           from sof.contrato_paf cp, sof.tipo_contrato_paf tcp, "
        SqlText = SqlText & "                                sof.fornecedor f "
        SqlText = SqlText & "                           where cp.cd_tipo_contrato_paf = tcp.cd_tipo_contrato_paf and "
        SqlText = SqlText & "                                 cp.cd_fornecedor = f.cd_fornecedor and "
        SqlText = SqlText & "                                 f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "                                 tcp.ic_adiantamento = 'N' and cp.ic_status = 'A') "

        If CdContratoPAF <> -1 Then
            SqlText = SqlText & " and cp.cd_contrato_paf=" & CdContratoPAF
        End If

        oData = DBQuery(SqlText)
        oForm.Inclementa_Valor_ProgressBar(ValorProgressBar)
        oForm.Refresh()

        For iCont = 0 To oData.Rows.Count - 1
            SqlText = "select cp.dt_vencimento, cp.cd_contrato_paf, " & _
                      "(cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo) qt_saldo " & _
                      "from sof.contrato_paf cp, sof.tipo_contrato_paf tcp " & _
                      "where tcp.cd_tipo_contrato_paf = cp.cd_tipo_contrato_paf and " & _
                      "cp.cd_fornecedor = " & oData.Rows(iCont).Item("cd_fornecedor") & " and " & _
                      "cp.ic_status = 'A' and " & _
                      "tcp.ic_adiantamento = 'N' " & _
                      "ORDER BY cp.dt_contrato_paf desc, cp.cd_contrato_paf desc"
            oDataAux = DBQuery(SqlText)

            If oDataAux.Rows.Count > 0 Then
                If oData.Rows(iCont).Item("qt_kg_fixo") = oData.Rows(iCont).Item("qt_kg_a_fixar") And oData.Rows(iCont).Item("vl_fixo") = oData.Rows(iCont).Item("vl_a_fixar") Then
                    SqlText = "DELETE FROM SOF.CTR_PAF_MOVIMENTACAO " & _
                              "WHERE SQ_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO") & " AND " & _
                              "SQ_MOVIMENTACAO_CESSAO_DIREITO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & " AND " & _
                              "CD_CONTRATO_PAF = " & oData.Rows(iCont).Item("CD_CONTRATO_PAF") & " AND " & _
                              "SQ_CTR_PAF_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_CTR_PAF_MOVIMENTACAO")
                    If Not DBExecutar(SqlText) Then GoTo Erro
                Else
                    SqlText = "UPDATE SOF.CTR_PAF_MOVIMENTACAO " & _
                              "SET VL_FIXO = VL_FIXO - " & oData.Rows(iCont).Item("vl_a_fixar") & ", " & _
                              "VL_A_FIXAR = VL_A_FIXAR - " & oData.Rows(iCont).Item("vl_a_fixar") & " " & _
                              "WHERE SQ_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO") & " AND " & _
                              "SQ_MOVIMENTACAO_CESSAO_DIREITO = " & oData.Rows(iCont).Item("SQ_MOVIMENTACAO_CESSAO_DIREITO") & " AND " & _
                              "CD_CONTRATO_PAF = " & oData.Rows(iCont).Item("CD_CONTRATO_PAF") & " AND " & _
                              "SQ_CTR_PAF_MOVIMENTACAO = " & oData.Rows(iCont).Item("SQ_CTR_PAF_MOVIMENTACAO")
                    If Not DBExecutar(SqlText) Then GoTo Erro
                End If

                sErroAux = "SOF.SP_INCLUI_CTR_PAF_MOV(" & oData.Rows(iCont).Item("cd_contrato_paf") & _
                                                   ", " & oData.Rows(iCont).Item("sq_movimentacao") & _
                                                   ", " & oData.Rows(iCont).Item("sq_Movimentacao_Cessao_Direito") & _
                                                   ", " & oData.Rows(iCont).Item("vl_a_fixar") & ")"

                SqlText = DBMontar_SP("SOF.SP_INCLUI_CTR_PAF_MOV", False, ":CDCTRPAF", _
                                                                          ":SQMOV", _
                                                                          ":SQMOVCD", _
                                                                          ":VLFIXO", _
                                                                          ":QTFIXO", _
                                                                          ":SQCTRPAFMOV")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDCTRPAF", oData.Rows(iCont).Item("cd_contrato_paf")), _
                                           DBParametro_Montar("SQMOV", oData.Rows(iCont).Item("sq_movimentacao")), _
                                           DBParametro_Montar("SQMOVCD", oData.Rows(iCont).Item("Sq_Movimentacao_Cessao_Direito")), _
                                           DBParametro_Montar("VLFIXO", oData.Rows(iCont).Item("vl_a_fixar")), _
                                           DBParametro_Montar("QTFIXO", 0), _
                                           DBParametro_Montar("SQCTRPAFMOV", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                ExecutaNovamente = True
            End If
        Next

        Fecha_Contratos()

        oForm.ProgressBar.Value = 100
        oForm.Close()

        If Not DBExecutarTransacao() Then GoTo erro

        If TextoErro <> "" Then
            Msg_Mensagem(TextoErro)
            If Confirma = False Then
                If Msg_Perguntar("Continua o processo ?") = False Then
                    Exit Function
                Else
                    Revisao_de_Contratos = True
                End If
            End If
        Else
            'SE APLICOU NO MASTER NO PAF RODA NOVAMENTE PRA CHEGAR NA NEG
            If ExecutaNovamente = True And SegundaVez = False Then
                Revisao_de_Contratos(False, CdContratoPAF, True)
            End If

            If Confirma = True Then Msg_Mensagem("Revisão realizada com sucesso.")

            Revisao_de_Contratos = True
        End If

        Exit Function

Erro:
        oForm.Close()
        TratarErro(TextoErro, , "Revisão de Contrato" & IIf(Trim(sErroAux = ""), "", " - " & Trim(sErroAux)), sErro_Complemento)
    End Function

    Private Sub Fecha_Contratos()
        Dim SqlText As String

        'SÓ É FECHADO OS CONTRATOS QUE NÃO SÃO GP
        SqlText = "UPDATE SOF.CONTRATO_FIXO "
        SqlText = SqlText & "SET IC_STATUS = 'F' "
        SqlText = SqlText & "WHERE (cd_contrato_paf, sq_negociacao, sq_contrato_fixo) IN "
        SqlText = SqlText & "(SELECT cf.cd_contrato_paf, cf.sq_negociacao, cf.sq_contrato_fixo "
        SqlText = SqlText & "FROM SOF.CONTRATO_FIXO CF, SOF.NEGOCIACAO N, SOF.CONTRATO_PAF CP, SOF.FORNECEDOR F, "
        SqlText = SqlText & "     SOF.FUNRURAL FUN "
        SqlText = SqlText & "WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      CF.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      CF.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO AND "
        SqlText = SqlText & "      CP.CD_FORNECEDOR = F.CD_FORNECEDOR AND "
        SqlText = SqlText & "      F.CD_FUNRURAL = FUN.CD_FUNRURAL AND "
        SqlText = SqlText & "      CF.IC_STATUS = 'A' AND "
        SqlText = SqlText & "      f.cd_filial_origem = " & FilialLogada & " and "
        SqlText = SqlText & "      round((((((CF.QT_KGS - CF.QT_CANCELADO) / CF.QT_KGS) * (CF.VL_TOTAL + CF.VL_ICMS)) "
        SqlText = SqlText & "              + CF.VL_ADENDO + CF.VL_ADENDO_ICMS) - CF.VL_NF_FIXO + CF.VL_NF_INSS_FIXO) "
        SqlText = SqlText & "              / (1 - (FUN.VL_TAXA / 100)),2)=0 and "
        SqlText = SqlText & "      (CF.QT_KGS - CF.QT_CANCELADO) = CF.QT_KG_FIXO and "
        SqlText = SqlText & "      (ROUND((((cf.vl_total + decode(cf.ic_inclui_icms_pag,'S',cf.vl_icms,0)) / cf.qt_kgs) * (cf.qt_kgs - cf.qt_cancelado)), 2) "
        SqlText = SqlText & "       - cf.vl_pag_fixo + cf.vl_adendo + decode(cf.ic_inclui_icms_pag,'S',cf.vl_adendo_icms,0)) = 0 and cf.ic_gp ='N') "

        DBExecutar(SqlText)

        SqlText = "UPDATE SOF.NEGOCIACAO "
        SqlText = SqlText & "SET IC_STATUS = 'F' "
        SqlText = SqlText & "WHERE (cd_contrato_paf, sq_negociacao) IN ( "
        SqlText = SqlText & "SELECT cd_contrato_paf, "
        SqlText = SqlText & "       sq_negociacao "
        SqlText = SqlText & "FROM ( "
        SqlText = SqlText & "SELECT n.cd_contrato_paf, "
        SqlText = SqlText & "       n.sq_negociacao, "
        SqlText = SqlText & "       SUM(decode(cf.ic_status,null,0,DECODE(cf.ic_status, 'F', 0, 1))) qt_aberto "
        SqlText = SqlText & "FROM SOF.CONTRATO_FIXO CF, "
        SqlText = SqlText & "     SOF.NEGOCIACAO N, "
        SqlText = SqlText & "     SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & "     SOF.FORNECEDOR F, "
        SqlText = SqlText & "     (SELECT CM.cd_contrato_paf, "
        SqlText = SqlText & "             CM.sq_negociacao, "
        SqlText = SqlText & "             SUM(CM.qt_kg_a_fixar) qt_kg_a_fixar, "
        SqlText = SqlText & "             SUM(CM.vl_a_fixar) vl_a_fixar "
        SqlText = SqlText & "      FROM SOF.FORNECEDOR F, "
        SqlText = SqlText & "           SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & "           SOF.NEGOCIACAO N, "
        SqlText = SqlText & "           SOF.CTR_PAF_NEG_MOVIMENTACAO CM "
        SqlText = SqlText & "      WHERE F.cd_fornecedor = CP.cd_fornecedor AND "
        SqlText = SqlText & "            CP.cd_contrato_paf = N.cd_contrato_paf AND "
        SqlText = SqlText & "            N.cd_contrato_paf = CM.cd_contrato_paf AND "
        SqlText = SqlText & "            N.sq_negociacao = CM.sq_negociacao AND "
        SqlText = SqlText & "            N.ic_status = 'A' AND "
        SqlText = SqlText & "            N.qt_a_fixar = 0 AND "
        SqlText = SqlText & "            F.cd_filial_origem = " & FilialLogada & " "
        SqlText = SqlText & "      GROUP BY CM.cd_contrato_paf, "
        SqlText = SqlText & "               CM.sq_negociacao) CM, "
        SqlText = SqlText & "     (SELECT PN.cd_contrato_paf, "
        SqlText = SqlText & "             PN.sq_negociacao, "
        SqlText = SqlText & "             SUM(PN.vl_a_fixar) VL_A_FIXAR "
        SqlText = SqlText & "      FROM SOF.FORNECEDOR F, "
        SqlText = SqlText & "           SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & "           SOF.NEGOCIACAO N, "
        SqlText = SqlText & "           SOF.PAG_NEG PN "
        SqlText = SqlText & "      WHERE F.cd_fornecedor = CP.cd_fornecedor AND "
        SqlText = SqlText & "            CP.cd_contrato_paf = N.cd_contrato_paf AND "
        SqlText = SqlText & "            N.cd_contrato_paf = PN.cd_contrato_paf AND "
        SqlText = SqlText & "            N.sq_negociacao = PN.sq_negociacao AND "
        SqlText = SqlText & "            N.ic_status = 'A' AND "
        SqlText = SqlText & "            N.qt_a_fixar = 0 AND "
        SqlText = SqlText & "            F.cd_filial_origem = " & FilialLogada & " "
        SqlText = SqlText & "      GROUP BY PN.cd_contrato_paf, "
        SqlText = SqlText & "               PN.sq_negociacao) PN "
        SqlText = SqlText & "WHERE CF.CD_CONTRATO_PAF (+) = N.cd_contrato_paf AND "
        SqlText = SqlText & "      CF.SQ_NEGOCIACAO (+) = N.sq_negociacao AND "
        SqlText = SqlText & "      N.cd_contrato_paf = CP.cd_contrato_paf AND "
        SqlText = SqlText & "      CP.cd_fornecedor = F.cd_fornecedor AND "
        SqlText = SqlText & "      N.cd_contrato_paf = CM.cd_contrato_paf (+) AND "
        SqlText = SqlText & "      N.sq_negociacao = CM.sq_negociacao (+) AND "
        SqlText = SqlText & "      (nvl(CM.qt_kg_a_fixar(+),0) = 0 AND nvl(CM.vl_a_fixar(+),0) = 0) AND "
        SqlText = SqlText & "      N.cd_contrato_paf = PN.cd_contrato_paf (+) AND "
        SqlText = SqlText & "      N.sq_negociacao = PN.sq_negociacao (+) AND "
        SqlText = SqlText & "      nvl(PN.vl_a_fixar(+),0) = 0 AND "
        SqlText = SqlText & "      f.cd_filial_origem = " & FilialLogada & " AND "
        SqlText = SqlText & "      N.ic_status = 'A' AND "
        SqlText = SqlText & "      N.qt_a_fixar = 0 "
        SqlText = SqlText & "group by n.cd_contrato_paf, "
        SqlText = SqlText & "         n.sq_negociacao "
        SqlText = SqlText & "having SUM(decode(cf.ic_status,null,0,DECODE(cf.ic_status, 'F', 0, 1))) = 0 "
        SqlText = SqlText & ")) "
        DBExecutar(SqlText)

        SqlText = "UPDATE SOF.CONTRATO_PAF "
        SqlText = SqlText & "SET IC_STATUS = 'F' "
        SqlText = SqlText & "WHERE cd_contrato_paf IN ( "
        SqlText = SqlText & "SELECT cd_contrato_paf "
        SqlText = SqlText & "FROM ( "
        SqlText = SqlText & "SELECT CP.cd_contrato_paf, "
        SqlText = SqlText & "       SUM(decode(n.ic_status, null,0,DECODE(n.ic_status, 'F', 0, 1))) qt_aberto "
        SqlText = SqlText & "FROM SOF.NEGOCIACAO N, "
        SqlText = SqlText & "     SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & "     SOF.FORNECEDOR F, "
        SqlText = SqlText & "     (SELECT CM.cd_contrato_paf, "
        SqlText = SqlText & "             SUM(CM.qt_kg_a_fixar) qt_kg_a_fixar, "
        SqlText = SqlText & "             SUM(CM.vl_a_fixar) vl_a_fixar "
        SqlText = SqlText & "      FROM SOF.FORNECEDOR F, "
        SqlText = SqlText & "           SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & "           SOF.CTR_PAF_MOVIMENTACAO CM "
        SqlText = SqlText & "      WHERE F.cd_fornecedor = CP.cd_fornecedor AND "
        SqlText = SqlText & "            CP.cd_contrato_paf = CM.cd_contrato_paf AND "
        SqlText = SqlText & "            CP.ic_status = 'A' AND "
        SqlText = SqlText & "            CP.qt_a_negociar = 0 AND "
        SqlText = SqlText & "            F.cd_filial_origem = " & FilialLogada & " "
        SqlText = SqlText & "      GROUP BY CM.cd_contrato_paf) CM, "
        SqlText = SqlText & "     (SELECT PCP.cd_contrato_paf, "
        SqlText = SqlText & "             SUM(PCP.vl_a_fixar) VL_A_FIXAR "
        SqlText = SqlText & "      FROM SOF.FORNECEDOR F, "
        SqlText = SqlText & "           SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & "           SOF.PAG_CTR_PAF PCP "
        SqlText = SqlText & "      WHERE F.cd_fornecedor = CP.cd_fornecedor AND "
        SqlText = SqlText & "            CP.cd_contrato_paf = PCP.cd_contrato_paf AND "
        SqlText = SqlText & "            CP.ic_status = 'A' AND "
        SqlText = SqlText & "            CP.qt_a_negociar = 0 AND "
        SqlText = SqlText & "            F.cd_filial_origem = " & FilialLogada & " "
        SqlText = SqlText & "      GROUP BY PCP.cd_contrato_paf) PN "
        SqlText = SqlText & "WHERE N.cd_contrato_paf (+) = CP.cd_contrato_paf AND "
        SqlText = SqlText & "      CP.cd_fornecedor = F.cd_fornecedor AND "
        SqlText = SqlText & "      CP.cd_contrato_paf = CM.cd_contrato_paf (+) AND "
        SqlText = SqlText & "      (nvl(CM.qt_kg_a_fixar(+),0) = 0 AND nvl(CM.vl_a_fixar(+),0) = 0) AND "
        SqlText = SqlText & "      CP.cd_contrato_paf = PN.cd_contrato_paf (+) AND "
        SqlText = SqlText & "      nvl(PN.vl_a_fixar(+),0) = 0 AND "
        SqlText = SqlText & "      f.cd_filial_origem = " & FilialLogada & " AND "
        SqlText = SqlText & "      CP.ic_status = 'A' AND "
        SqlText = SqlText & "      CP.qt_a_negociar = 0 "
        SqlText = SqlText & "group by CP.cd_contrato_paf "
        SqlText = SqlText & "having SUM(decode(n.ic_status, null,0,DECODE(n.ic_status, 'F', 0, 1))) = 0 "
        SqlText = SqlText & ")) "
        DBExecutar(SqlText)

        SqlText = "UPDATE sof.negociacao "
        SqlText = SqlText & "   SET ic_status = 'A' "
        SqlText = SqlText & " WHERE ic_status <> 'A' "
        SqlText = SqlText & "AND    (cd_contrato_paf, sq_negociacao) IN ( "
        SqlText = SqlText & "          SELECT cf.cd_contrato_paf, cf.sq_negociacao "
        SqlText = SqlText & "          FROM   sof.contrato_fixo cf "
        SqlText = SqlText & "          WHERE  cf.ic_status = 'A' "
        SqlText = SqlText & "          UNION "
        SqlText = SqlText & "          SELECT cd_contrato_paf, sq_negociacao "
        SqlText = SqlText & "          FROM   sof.pag_neg "
        SqlText = SqlText & "          WHERE  vl_a_fixar <> 0 "
        SqlText = SqlText & "          UNION "
        SqlText = SqlText & "          SELECT cd_contrato_paf, sq_negociacao "
        SqlText = SqlText & "          FROM   sof.ctr_paf_neg_movimentacao "
        SqlText = SqlText & "          WHERE  vl_a_fixar <> 0 AND qt_kg_a_fixar <> 0) "
        DBExecutar(SqlText)

        SqlText = "UPDATE sof.contrato_paf "
        SqlText = SqlText & "   SET ic_status = 'A' "
        SqlText = SqlText & " WHERE ic_status <> 'A' "
        SqlText = SqlText & "AND    cd_contrato_paf IN ( "
        SqlText = SqlText & "          SELECT cf.cd_contrato_paf "
        SqlText = SqlText & "          FROM   sof.contrato_fixo cf "
        SqlText = SqlText & "          WHERE  cf.ic_status = 'A' "
        SqlText = SqlText & "          UNION "
        SqlText = SqlText & "          SELECT cd_contrato_paf "
        SqlText = SqlText & "          FROM   sof.negociacao "
        SqlText = SqlText & "          WHERE  ic_status = 'A' "
        SqlText = SqlText & "          UNION "
        SqlText = SqlText & "          SELECT DISTINCT pcp.cd_contrato_paf "
        SqlText = SqlText & "          FROM            sof.pag_ctr_paf pcp "
        SqlText = SqlText & "          WHERE           pcp.vl_a_fixar <> 0 "
        SqlText = SqlText & "          UNION "
        SqlText = SqlText & "          SELECT DISTINCT cm.cd_contrato_paf "
        SqlText = SqlText & "          FROM            sof.ctr_paf_movimentacao cm "
        SqlText = SqlText & "          WHERE           (cm.qt_kg_a_fixar <> 0 OR cm.vl_a_fixar <> 0)) "
        DBExecutar(SqlText)
    End Sub

    Public Function Amarracao_Automatica(ByVal Confirma As Boolean) As Boolean
        Dim SqlText As String
        Dim sqConciliacao As Long
        Dim oData As DataTable
        Dim oDataAux As DataTable
        Dim iCont As Integer
        Dim CdModalidadeConciliacao As Integer

        Dim Transacao As Boolean

        Amarracao_Automatica = False

        SqlText = "SELECT p.cd_conciliacao_icms FROM sof.parametro p "
        CdModalidadeConciliacao = DBQuery_ValorUnico(SqlText)

        Transacao = False

        If Confirma = True Then
            If Msg_Perguntar("Faz a amarração automatica ?") = False Then Exit Function
        End If

        'VERIFICA AS NF QUE AINDA NÃO FORAM AMARRADAS
        SqlText = "SELECT m.cd_fornecedor, m.nu_nf, m.vl_nf_icms, m.sq_movimentacao "
        SqlText = SqlText & "  FROM sof.movimentacao m, sof.fornecedor f "
        SqlText = SqlText & " WHERE m.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "   AND m.ic_icms_pago = 'N' "
        SqlText = SqlText & "   AND m.vl_nf_icms > 0 "
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            SqlText = "SELECT f.cd_fornecedor ,pc.vl_a_fixar , p.sq_pagamento, pc.cd_contrato_paf ,pc.sq_pag_ctr_paf   "
            SqlText = SqlText & "  FROM sof.pagamentos p, sof.fornecedor f, sof.pag_ctr_paf pc "
            SqlText = SqlText & " WHERE p.cd_fornecedor = f.cd_fornecedor "
            SqlText = SqlText & "   AND p.sq_pagamento = pc.sq_pagamento "
            SqlText = SqlText & "   AND p.ic_icms = 'S' "
            SqlText = SqlText & "   AND p.ic_icms_pago = 'N' "
            SqlText = SqlText & "   and pc.vl_a_fixar= " & ConvValorFormatoAmericano(oData.Rows(iCont).Item("vl_nf_icms"))
            SqlText = SqlText & "   and f.cd_fornecedor = " & oData.Rows(iCont).Item("cd_fornecedor")
            SqlText = SqlText & "   and p.nu_nf= '" & oData.Rows(iCont).Item("nu_nf") & "'"
            oDataAux = DBQuery(SqlText)

            If oDataAux.Rows.Count <> 0 Then
                'DESAPLICO O PAGAMENTO
                SqlText = "DELETE FROM SOF.PAG_CTR_PAF " & _
                          "WHERE CD_CONTRATO_PAF = " & oDataAux.Rows(0).Item("cd_contrato_paf") & " AND " & _
                          "SQ_PAGAMENTO = " & oDataAux.Rows(0).Item("sq_pagamento") & " AND " & _
                          "SQ_PAG_CTR_PAF = " & oDataAux.Rows(0).Item("sq_pag_ctr_paf")
                If Not DBExecutar(SqlText) Then GoTo Erro

                'ATUALIZO A MOVIMENTAÇÃO
                SqlText = "update sof.movimentacao m "
                SqlText = SqlText & "set m.ic_icms_pago='S' "
                SqlText = SqlText & "where m.sq_movimentacao= " & oData.Rows(iCont).Item("sq_movimentacao")
                If Not DBExecutar(SqlText) Then GoTo Erro

                'ATUALIZO O PAGAMENTO
                SqlText = "update sof.pagamentos p "
                SqlText = SqlText & " set p.ic_icms_pago='S' "
                SqlText = SqlText & " where p.sq_pagamento= " & oDataAux.Rows(0).Item("sq_pagamento")
                If Not DBExecutar(SqlText) Then GoTo Erro


                'CRIO A CONSILIAÇÃO

                SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO", False, ":CDCONCILMODAL", _
                                                                   ":CDFORN", _
                                                                   ":QTCONCIL", _
                                                                   ":VLCONCIL", _
                                                                   ":DSCONCIL", _
                                                                   ":SQCONCIL")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDCONCILMODAL", CdModalidadeConciliacao), _
                                           DBParametro_Montar("CDFORN", oData.Rows(iCont).Item("cd_fornecedor")), _
                                           DBParametro_Montar("QTCONCIL", 0), _
                                           DBParametro_Montar("VLCONCIL", oData.Rows(iCont).Item("vl_nf_icms")), _
                                           DBParametro_Montar("DSCONCIL", "Conciliação automatica pagamento ICMS"), _
                                           DBParametro_Montar("SQCONCIL", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                If DBTeveRetorno() Then
                    sqConciliacao = DBRetorno(1)
                End If


                'amarro a conciliação ao pagamento
                SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO_PAG", False, ":SQCONCIL", _
                                                              ":SQPAG", _
                                                              ":VLAPLICACAO")

                If Not DBExecutar(SqlText, DBParametro_Montar("SQCONCIL", sqConciliacao), _
                                               DBParametro_Montar("SQPAG", oDataAux.Rows(0).Item("sq_pagamento")), _
                                               DBParametro_Montar("VLAPLICACAO", oData.Rows(iCont).Item("vl_nf_icms"))) Then GoTo Erro



                'incluo referencia da amarração
                SqlText = "insert into sof.pag_amarracao_icms  (sq_pagamento, sq_movimentacao, vl_aplicacao, "
                SqlText = SqlText & "       sq_conciliacao, dt_criacao, no_user_criacao,dt_amarracao) values "
                SqlText = SqlText & " (" & oDataAux.Rows(0).Item("sq_pagamento") & "," & oData.Rows(iCont).Item("sq_movimentacao") & "," & oData.Rows(iCont).Item("vl_nf_icms") & ","
                SqlText = SqlText & sqConciliacao & ",sysdate,'" & sAcesso_UsuarioLogado & "','" & Date_to_Oracle(DataSistema) & "')"
                If Not DBExecutar(SqlText) Then GoTo Erro

            End If

        Next

        If Confirma = True Then Msg_Mensagem("Amarração realizada com sucesso.")

        Amarracao_Automatica = True

        Exit Function
Erro:
        TratarErro()
    End Function

    Public Sub Fecha_Dia()
        Dim oData As DataTable
        Dim SqlText As String
        Dim iCont As Integer

        If Msg_Perguntar("Realiza o fechamento do sistema ?") = False Then Exit Sub

        SqlText = "SELECT CD_FILIAL_MAE FROM SOF.PARAMETRO"

        If DBQuery_ValorUnico(SqlText) = FilialLogada Then
            Msg_Mensagem("Não ha necessidade de fechar o dia nesta filial.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(SQ_NEGOCIACAO_PRE) AS QUANT" & _
                  " FROM SOF.NEGOCIACAO_PRE" & _
                  " WHERE QT_SALDO <> 0" & _
                    " AND CD_FILIAL_ORIGEM = " & FilialLogada

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Ainda existe pre-negociação em aberto.")
            Exit Sub
        End If

        'Verifico se tem cheque sem imprimir
        SqlText = "SELECT COUNT(*) AS QUANT" & _
                  " FROM SOF.ITEM_MOV_BANCARIO IMB," & _
                        "SOF.PAGAMENTOS PG," & _
                        "SOF.CONCILIACAO_PAGAMENTO CP" & _
                  " WHERE IMB.SQ_MOV_BANCARIO IS NULL" & _
                    " AND IMB.CD_FILIAL_PAGADORA = " & FilialLogada & _
                    " AND PG.SQ_ITEM_MOV_BANCARIO (+) = IMB.SQ_ITEM_MOV_BANCARIO" & _
                    " AND CP.SQ_PAGAMENTO (+) = PG.SQ_PAGAMENTO" & _
                    " AND CP.SQ_CONCILIACAO IS NULL"
        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Ainda existe cheque que não foi impresso.")
            Exit Sub
        End If

        'verifico se tem pagamento sem aprovação
        SqlText = "SELECT COUNT(*) AS QUANT  "
        SqlText = SqlText & "  FROM sof.pagamentos p, SOF.FORNECEDOR F  "
        SqlText = SqlText & " WHERE P.CD_FORNECEDOR = F.CD_FORNECEDOR  "
        SqlText = SqlText & "   AND p.ic_status_aprovacao = 'N' and F.CD_FILIAL_ORIGEM = " & FilialLogada

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Ainda existe pagamento sem aprovação.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) AS QUANT " & _
                  "FROM SOF.PAGAMENTOS P, SOF.FORNECEDOR F " & _
                  "WHERE P.CD_FORNECEDOR = F.CD_FORNECEDOR AND " & _
                  "P.VL_A_FIXAR <> 0 AND " & _
                  "F.CD_FILIAL_ORIGEM = " & FilialLogada

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Ainda existe pagamentos sem contrato PAF.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) AS QUANT " & _
                  "FROM SOF.MOVIMENTACAO_CESSAO_DIREITO MCD, SOF.FORNECEDOR F " & _
                  "WHERE MCD.CD_FORNECEDOR = F.CD_FORNECEDOR AND " & _
                  "MCD.QT_KG_A_FIXAR <> 0 AND " & _
                  "F.CD_FILIAL_ORIGEM = " & FilialLogada

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Ainda existe movimentacao com cacau sem contrato PAF.")
            Exit Sub
        End If

        SqlText = "SELECT   cf.cd_contrato_paf, cf.sq_negociacao, cf.sq_contrato_fixo, "
        SqlText = SqlText & "         cp.cd_fornecedor, "
        SqlText = SqlText & "         ROUND (  (  (  (  ((cf.qt_kgs - cf.qt_cancelado) / cf.qt_kgs) "
        SqlText = SqlText & "                         * (cf.vl_total + cf.vl_icms) "
        SqlText = SqlText & "                        ) "
        SqlText = SqlText & "                      + cf.vl_adendo "
        SqlText = SqlText & "                      + cf.vl_adendo_icms "
        SqlText = SqlText & "                     ) "
        SqlText = SqlText & "                   - cf.vl_nf_fixo "
        SqlText = SqlText & "                   + cf.vl_nf_inss_fixo "
        SqlText = SqlText & "                  ) "
        SqlText = SqlText & "                / (1 - (fun.vl_taxa / 100)), "
        SqlText = SqlText & "                2 "
        SqlText = SqlText & "               ) vl_saldo, "
        SqlText = SqlText & "         cp.ic_status ic_status_paf, n.ic_status ic_status_neg "
        SqlText = SqlText & "    FROM sof.contrato_fixo cf, "
        SqlText = SqlText & "         sof.negociacao n, "
        SqlText = SqlText & "         sof.contrato_paf cp, "
        SqlText = SqlText & "         sof.fornecedor f, "
        SqlText = SqlText & "         sof.funrural fun "
        SqlText = SqlText & "   WHERE cp.cd_contrato_paf = n.cd_contrato_paf "
        SqlText = SqlText & "     AND cf.cd_contrato_paf = n.cd_contrato_paf "
        SqlText = SqlText & "     AND cf.sq_negociacao = n.sq_negociacao "
        SqlText = SqlText & "     AND cp.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "     AND f.cd_funrural = fun.cd_funrural "
        SqlText = SqlText & "     AND cf.ic_status = 'A' "
        SqlText = SqlText & "     AND f.cd_filial_origem =" & FilialLogada
        SqlText = SqlText & "     AND ROUND (  (  (  (  ((cf.qt_kgs - cf.qt_cancelado) / cf.qt_kgs) "
        SqlText = SqlText & "                             * (cf.vl_total + cf.vl_icms) "
        SqlText = SqlText & "                            ) "
        SqlText = SqlText & "                          + cf.vl_adendo "
        SqlText = SqlText & "                          + cf.vl_adendo_icms "
        SqlText = SqlText & "                         ) "
        SqlText = SqlText & "                       - cf.vl_nf_fixo "
        SqlText = SqlText & "                       + cf.vl_nf_inss_fixo "
        SqlText = SqlText & "                      ) "
        SqlText = SqlText & "                    / (1 - (fun.vl_taxa / 100)), "
        SqlText = SqlText & "                    2 "
        SqlText = SqlText & "                   ) < -0.01  "
        SqlText = SqlText & "     AND (cf.qt_kgs - cf.qt_cancelado) = cf.qt_kg_fixo "

        oData = DBQuery(SqlText)

        If oData.Rows.Count <> 0 Then
            Dim Texto As String
            Texto = "Saldo negativo de NF nos seguintes contratos:"
            For iCont = 0 To oData.Rows.Count - 1
                Texto = Texto & oData.Rows(iCont).Item("cd_contrato_paf") & "-" & oData.Rows(iCont).Item("sq_negociacao") & "-" & oData.Rows(iCont).Item("sq_contrato_fixo")
            Next
            Texto = Texto & "."
            Msg_Mensagem(Texto)
            Exit Sub
        End If

        If Revisao_de_Contratos(False) = False Then Exit Sub

        SqlText = "SELECT COUNT(*) AS QUANT " & _
                  " FROM SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                        "SOF.FORNECEDOR F " & _
                  " WHERE MCD.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND (MCD.VL_A_FIXAR <> 0 OR MCD.QT_KG_A_FIXAR <> 0)" & _
                    " AND F.CD_FILIAL_ORIGEM = " & FilialLogada
        If DBQuery_ValorUnico(SqlText) <> 0 Then
            Msg_Mensagem("Ainda existe movimentacao sem contrato PAF.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) AS QUANT" & _
                  " FROM SOF.TRANSFERENCIA T," & _
                        "SOF.MOVIMENTACAO M," & _
                        "SOF.TRANSFERENCIA_MODALIDADE TM" & _
                  " WHERE T.SQ_MOVIMENTACAO_SAIDA = M.SQ_MOVIMENTACAO" & _
                    " AND T.CD_TRANSFERENCIA_MODALIDADE = TM.CD_TRANSFERENCIA_MODALIDADE" & _
                    " AND T.CD_FILIAL_ORIGEM = " & FilialLogada & _
                    " AND T.DT_TRANSFERENCIA = " & QuotedStr(Date_to_Oracle(DataSistema)) & _
                    " AND TM.IC_DADOS_FISCAL = 'S'" & _
                    " AND M.NU_NF IS NULL"

        If DBQuery_ValorUnico(SqlText) <> 0 Then
            If Not Msg_Perguntar("Ainda existem transferências sem o número da nota fiscal." & _
                                 " Deseja prosseguir o fechamento do dia com essa pendência?") Then
                Exit Sub
            End If
        End If

        If Verifica_Pagamento() = True Then
            Msg_Mensagem("Problemas com os Pagamentos. Filiais não fechadas automaticamente.")
            Exit Sub
        End If

        If Verifica_Adiantamento() = True Then
            Msg_Mensagem("Problemas com os Recebimentos. Filiais não fechadas automaticamente.")
            Exit Sub
        End If

        'Faz a amarração a automática
        Amarracao_Automatica(False)

        SqlText = "UPDATE SOF.FILIAL SET IC_FECHADA= 'S'" & _
                  " WHERE CD_FILIAL = " & FilialLogada
        If Not DBExecutar(SqlText) Then GoTo Erro

        oMDI.Libera_Filial()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Function Verifica_Pagamento() As Boolean
        Dim oData As DataTable
        Dim SqlText As String
        Dim mErro As String
        Dim iCont As Integer
        mErro = ""

        Verifica_Pagamento = False

        SqlText = "SELECT distinct CP.CD_CONTRATO_PAF, F.NO_RAZAO_SOCIAL " & _
                  "FROM SOF.PAG_CTR_PAF PCP, SOF.CONTRATO_PAF CP, SOF.TIPO_CONTRATO_PAF TCP, " & _
                  "SOF.FORNECEDOR F, sof.pagamentos p, sof.tipo_pagamento tp " & _
                  "WHERE CP.CD_CONTRATO_PAF = PCP.CD_CONTRATO_PAF AND " & _
                  "TCP.CD_TIPO_CONTRATO_PAF = CP.CD_TIPO_CONTRATO_PAF AND " & _
                  "F.CD_FORNECEDOR = CP.CD_FORNECEDOR AND " & _
                  "pcp.sq_pagamento = p.sq_pagamento and " & _
                  "p.cd_tipo_pagamento=tp.cd_tipo_pagamento and " & _
                  "PCP.VL_A_FIXAR <> 0 AND " & _
                  "TCP.IC_ADIANTAMENTO = 'N' AND " & _
                  "tp.ic_pagamento_icms='N' and " & _
                  "F.CD_FILIAL_ORIGEM = " & FilialLogada
        oData = DBQuery(SqlText)
        If oData.Rows.Count > 0 Then
            For iCont = 0 To oData.Rows.Count - 1
                mErro = mErro & "Contrato PAF: " & oData.Rows(iCont).Item("cd_contrato_paf") & " - " & oData.Rows(iCont).Item("no_razao_social") & vbCrLf
            Next
        End If

        If mErro <> "" Then
            Verifica_Pagamento = True
            Msg_Mensagem("A filial possui Contratos PAF sem obrigatoriedade de entrega com adiantamento:" & vbCrLf & _
                   mErro)
        End If
    End Function

    Private Function Verifica_Adiantamento() As Boolean
        Dim oData As DataTable
        Dim SqlText As String
        Dim mErro As String
        Dim iCont As Integer
        mErro = ""

        Verifica_Adiantamento = False

        SqlText = "SELECT f.no_razao_social, P.vl_pagamento "
        SqlText = SqlText & "FROM SOF.PAGAMENTOS P, SOF.FORNECEDOR F, "
        SqlText = SqlText & "     (SELECT DISTINCT CP.CD_FORNECEDOR "
        SqlText = SqlText & "      FROM SOF.CONTRATO_PAF CP, SOF.NEGOCIACAO N "
        SqlText = SqlText & "      WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "            N.DT_VENCIMENTO < '" & Date_to_Oracle(DataSistema) & "' AND "
        SqlText = SqlText & "            N.IC_STATUS = 'A' AND "
        SqlText = SqlText & "            (N.QT_KGS - N.QT_CANCELADO - N.QT_KG_FIXO) <> 0 AND "
        SqlText = SqlText & "            (N.cd_contrato_paf, N.sq_negociacao) NOT IN "
        SqlText = SqlText & "            (SELECT CM.cd_contrato_paf, CM.sq_negociacao "
        SqlText = SqlText & "             FROM SOF.CTR_PAF_NEG_MOVIMENTACAO CM "
        SqlText = SqlText & "             WHERE CM.dt_fixacao = '" & Date_to_Oracle(DataSistema) & "' AND "
        SqlText = SqlText & "                   CM.qt_kg_fixo<>0) "
        SqlText = SqlText & "      Union "
        SqlText = SqlText & "      SELECT DISTINCT CP.CD_FORNECEDOR "
        SqlText = SqlText & "      FROM SOF.CONTRATO_PAF CP "
        SqlText = SqlText & "      WHERE CP.DT_VENCIMENTO < '" & Date_to_Oracle(DataSistema) & "' AND "
        SqlText = SqlText & "            CP.IC_STATUS = 'A' AND "
        SqlText = SqlText & "            (CP.QT_KGS - CP.QT_CANCELADO - CP.QT_KG_FIXO) <> 0 AND "
        SqlText = SqlText & "            (CP.cd_contrato_paf) NOT IN "
        SqlText = SqlText & "            (SELECT CM.cd_contrato_paf "
        SqlText = SqlText & "             FROM SOF.CTR_PAF_MOVIMENTACAO CM "
        SqlText = SqlText & "             WHERE CM.dt_fixacao = '" & Date_to_Oracle(DataSistema) & "' AND "
        SqlText = SqlText & "                   CM.qt_kg_fixo<>0) "
        SqlText = SqlText & "      Union "
        SqlText = SqlText & "      SELECT DISTINCT CP.CD_FORNECEDOR "
        SqlText = SqlText & "      FROM SOF.CONTRATO_PAF CP, SOF.NEGOCIACAO N, SOF.CONTRATO_FIXO CF "
        SqlText = SqlText & "      WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "            N.cd_contrato_paf = CF.cd_contrato_paf AND "
        SqlText = SqlText & "            N.sq_negociacao = CF.sq_negociacao AND "
        SqlText = SqlText & "            CF.DT_VENCIMENTO < '" & Date_to_Oracle(DataSistema) & "' AND "
        SqlText = SqlText & "            CF.IC_STATUS = 'A' AND "
        SqlText = SqlText & "            (CF.QT_KGS - CF.QT_CANCELADO - CF.QT_KG_FIXO) <> 0 AND "
        SqlText = SqlText & "            (CF.cd_contrato_paf, CF.sq_negociacao, CF.sq_contrato_fixo) NOT IN "
        SqlText = SqlText & "            (SELECT CM.cd_contrato_paf, CM.sq_negociacao, CM.sq_contrato_fixo "
        SqlText = SqlText & "             FROM SOF.CTR_PAF_NEG_CTR_FIX_MOV CM "
        SqlText = SqlText & "             WHERE CM.dt_fixacao = '" & Date_to_Oracle(DataSistema) & "' AND "
        SqlText = SqlText & "                   CM.qt_kg_fixo<>0)) C "
        SqlText = SqlText & "WHERE P.CD_FORNECEDOR = F.CD_FORNECEDOR AND "
        SqlText = SqlText & "      P.CD_FORNECEDOR = C.CD_FORNECEDOR AND "
        SqlText = SqlText & "      P.DT_PAGAMENTO = '" & Date_to_Oracle(DataSistema) & "' AND "
        SqlText = SqlText & "      P.SQ_CONF_DIV_ATIVO_VENDA IS NULL AND "
        SqlText = SqlText & "      F.CD_FILIAL_ORIGEM = " & FilialLogada & " and "
        SqlText = SqlText & "      P.CD_FORMA_PAGAMENTO <> 3 AND "
        SqlText = SqlText & "      P.SQ_PAGAMENTO NOT IN (SELECT DISTINCT PJA.SQ_PAGAMENTO "
        SqlText = SqlText & "                             FROM SOF.PAGAMENTO_JUROS_AUTOMATICO PJA "
        SqlText = SqlText & "                             Union "
        SqlText = SqlText & "                             SELECT DISTINCT PDA.SQ_PAGAMENTO "
        SqlText = SqlText & "                             FROM SOF.PAGAMENTO_DESAGIO_AUTOMATICO PDA "
        SqlText = SqlText & "                             Union "
        SqlText = SqlText & "                             SELECT DISTINCT SQ_PAGAMENTO "
        SqlText = SqlText & "                             From SOF.CTRPAF_NEG_CTRFIX_MOV_DQ "
        SqlText = SqlText & "                             Union "
        SqlText = SqlText & "                             SELECT DISTINCT SQ_PAGAMENTO "
        SqlText = SqlText & "                             FROM SOF.PAGAMENTOS_JUROS_AUTO_CTR_FIX) "

        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            For iCont = 0 To oData.Rows.Count - 1
                mErro = mErro & "Fornecedor: " & oData.Rows(iCont).Item("no_razao_social") & " - Vl Pag: " & _
                        Format(oData.Rows(iCont).Item("vl_pagamento"), "#,##0.00") & vbCrLf
            Next
        End If

        If mErro <> "" Then
            Verifica_Adiantamento = True
            Msg_Mensagem("A filial realizou pagamentos a fornecedores com contratos vencidos:" & vbCrLf & _
                   mErro)
        End If
    End Function

    Public Function Contrato_PAF_PrecoFixo(ByVal CD_CONTRATO As Integer) As Boolean
        Dim SqlText As String

        SqlText = "SELECT COUNT(*)" & _
                  " FROM SOF.CONTRATO_PAF PAF," & _
                        "SOF.NEGOCIACAO NEG" & _
                  " WHERE PAF.CD_CONTRATO_PAF = " & CD_CONTRATO & _
                    " AND NEG.CD_CONTRATO_PAF = PAF.CD_CONTRATO_PAF" & _
                    " AND NEG.CD_TIPO_NEGOCIACAO = " & cnt_TIPO_NEGOCIACAO_FixoEmReal & _
                    " AND NEG.DT_NEGOCIACAO = PAF.DT_CONTRATO_PAF" & _
                    " AND NEG.DT_CRIACAO BETWEEN PAF.DT_CRIACAO - ((1 / 24 / 60) * 2) AND PAF.DT_CRIACAO + ((1 / 24 / 60) * 2) "
        Return (DBQuery_ValorUnico(SqlText) > 0)
    End Function

    Public Function Negociacao_Rolagem(ByVal CD_CONTRATO_PAF As Integer, _
                                       ByVal SQ_NEGOCIACAO As Integer) As Boolean
        Dim SqlText As String

        SqlText = "SELECT COUNT(*) FROM SOF.SOLICITACAO_RENEGOCIACAO" & _
                  " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND SQ_NEGOCIACAO_NOVA = " & SQ_NEGOCIACAO & _
                    " AND IC_STATUS_APROVACAO = 'A'"
        Return (DBQuery_ValorUnico(SqlText) > 0)
    End Function
End Module