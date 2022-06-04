Imports CrystalDecisions.CrystalReports.Engine
Imports Logus.enCalcDiferencial_Opcao
Imports VB = Microsoft.VisualBasic.Strings
Imports RELPMNC = Logus.frmREL_PrecoMedioNFComplementa

Module MOD_Relatorio_Local
    Const cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_PrecoAFixar As String = "PREÇO A FIXAR"
    Const cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_PrecoFixo As String = "PREÇO FIXO EM R$"
    Const cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Diferencial As String = "DIFERENCIAL"
    Const cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Importacao As String = "IMPORTAÇÃO"

    Public Enum PosForn_FiltroExposure
        feNenhum = 0
        feSoAdiantamentosContratosBase = 1
        feSoAdiantamentoSemContratosBase = 2
        feSintetico = 3
    End Enum

    Public Function Gera_Data_Armazem_Pilha(Optional ByVal Cdfilial As String = "", _
                                            Optional ByVal CdArmazem As Long = -1, _
                                            Optional ByVal CdPilha As Long = -1, _
                                            Optional ByVal IcData As Boolean = False, _
                                            Optional ByVal dtInicio As String = "", _
                                            Optional ByVal dtFinal As String = "", _
                                            Optional ByVal CdTipoCacau As Long = -1, _
                                            Optional ByVal IcResumo As Boolean = False, _
                                            Optional ByVal IcHistorico As Boolean = False, _
                                            Optional ByVal CdProcedencia As String = "") As DataTable
        Dim SqlText As String
        Dim SqlFiltro As String
        Dim SqlOrder As String
        Dim SqlGroup As String
        Dim oData As New DataTable
        Dim oRow As DataRow
        Dim oDataT As DataTable
        Dim oDataE As DataTable
        Dim Fornecedor As String

        SqlOrder = ""
        SqlFiltro = ""
        SqlText = ""

        If IcHistorico = True Then
            SqlText = "SELECT * FROM ( "
        End If

        SqlText = SqlText & "SELECT MOV.SQ_MOVIMENTACAO, MPA.CD_PILHA_ARMAZEM, MOV.DT_MOVIMENTACAO, "
        SqlText = SqlText & "       MOV.NU_NF, MOV.QT_KG_LIQUIDO_NF, MPA.QT_VOLUME QT_KG_A_TRANSFERIR, "
        SqlText = SqlText & "       A.CD_ARMAZEM, A.NO_ARMAZEM, MOVQ.QT_UMIDADE, FILTRAS.CD_FILIAL, "
        SqlText = SqlText & "       DECODE (F.NO_RAZAO_SOCIAL, "
        SqlText = SqlText & "               NULL, FILTRAS.NO_FILIAL, "
        SqlText = SqlText & "               F.NO_RAZAO_SOCIAL "
        SqlText = SqlText & "              ) NO_RAZAO_SOCIAL, "
        SqlText = SqlText & "       SF.QT_SACOS AS QT_SACO, MOVQ.PC_SUJIDADE, MOVQ.IC_TIPO_CACAU, "
        SqlText = SqlText & "       T.SQ_TRANSFERENCIA, MOVQ.QT_PESO_AMENDOA, MOVQ.QT_MOFO, MOVQ.QT_FUMACA, "
        SqlText = SqlText & "       MOVQ.QT_ARDOSIA, MOVQ.QT_ACHATADA, MOV.CD_PROCEDENCIA, "
        SqlText = SqlText & "       PA.CD_PROCEDENCIA CD_PROCEDENCIA_PILHA, P.CD_ORIGEM, O.NO_ORIGEM, "
        SqlText = SqlText & "       FFA.QT_FFA, NVL (A.QT_CAPACIDADE, 0) QT_CAPACIDADE "
        SqlText = SqlText & "  FROM SOF.MOVIMENTACAO MOV, "
        SqlText = SqlText & "       SOF.MOVIMENTACAO_PILHA_ARMAZEM MPA, "
        SqlText = SqlText & "       SOF.PILHA_ARMAZEM PA, "
        SqlText = SqlText & "       SOF.ARMAZEM A, "
        SqlText = SqlText & "       SOF.MOVIMENTACAO_QUALIDADE MOVQ, "
        SqlText = SqlText & "       SOF.FORNECEDOR F, "
        SqlText = SqlText & "       (SELECT   CD_ARMAZEM, CD_PILHA_ARMAZEM, SQ_MOVIMENTACAO, "
        SqlText = SqlText & "                 SQ_MOVIMENTACAO_PILHA_ARMAZEM, SUM (QT_SACOS) QT_SACOS "
        SqlText = SqlText & "            FROM SOF.MOV_PILHA_ARMAZEM_SACARIA "
        SqlText = SqlText & "        GROUP BY CD_ARMAZEM, "
        SqlText = SqlText & "                 CD_PILHA_ARMAZEM, "
        SqlText = SqlText & "                 SQ_MOVIMENTACAO, "
        SqlText = SqlText & "                 SQ_MOVIMENTACAO_PILHA_ARMAZEM) SF, "
        SqlText = SqlText & "       SOF.TRANSFERENCIA T, "
        SqlText = SqlText & "       SOF.FILIAL FILTRAS, "
        SqlText = SqlText & "       SOF.PROCEDENCIA P, "
        SqlText = SqlText & "       SOF.ORIGEM O, "
        SqlText = SqlText & "       (SELECT SQ_MOVIMENTACAO, QT_ANALISE QT_FFA FROM ( "
        SqlText = SqlText & "SELECT CFF.SQ_MOVIMENTACAO, "
        SqlText = SqlText & "       ANL.NO_ANALISE, "
        SqlText = SqlText & "       CLA.CD_ANALISE, "
        SqlText = SqlText & "       CLA.VL_ANALISE QT_ANALISE, "
        SqlText = SqlText & "       CLA.SQ_CLASSIFICACAO "
        SqlText = SqlText & " FROM SOF.CLASSIFICACAO_ANALISE CLA, "
        SqlText = SqlText & "      SOF.ANALISE ANL, "
        SqlText = SqlText & "      (SELECT CLA.CD_ANALISE, "
        SqlText = SqlText & "              MAX(CLF.SQ_CLASSIFICACAO) SQ_CLASSIFICACAO, "
        SqlText = SqlText & "              NVL(LTM.SQ_MOVIMENTACAO, APM.SQ_MOVIMENTACAO) SQ_MOVIMENTACAO "
        SqlText = SqlText & "        FROM SOF.CLASSIFICACAO CLF, "
        SqlText = SqlText & "             SOF.CLASSIFICACAO_ANALISE CLA, "
        SqlText = SqlText & "             SOF.AMOSTRA_PILHA_MOVIMENTACAO APM, "
        SqlText = SqlText & "             SOF.LOTE_MOVIMENTACAO LTM, "
        SqlText = SqlText & "             SOF.MOVIMENTACAO_PILHA_ARMAZEM MPA "
        SqlText = SqlText & "        WHERE CLA.SQ_CLASSIFICACAO = CLF.SQ_CLASSIFICACAO "
        SqlText = SqlText & "          AND APM.SQ_AMOSTRA (+) = CLF.SQ_AMOSTRA "
        SqlText = SqlText & "          AND LTM.CD_LOTE (+) = CLF.CD_LOTE "
        SqlText = SqlText & "          AND (APM.SQ_AMOSTRA IS NOT NULL OR "
        SqlText = SqlText & "               LTM.CD_LOTE IS NOT NULL) "
        SqlText = SqlText & "          AND MPA.SQ_MOVIMENTACAO = NVL (LTM.SQ_MOVIMENTACAO, APM.SQ_MOVIMENTACAO) "
        SqlText = SqlText & "        GROUP BY CLA.CD_ANALISE, NVL(LTM.SQ_MOVIMENTACAO, APM.SQ_MOVIMENTACAO)) CFF "
        SqlText = SqlText & " WHERE CLA.SQ_CLASSIFICACAO = CFF.SQ_CLASSIFICACAO "
        SqlText = SqlText & "   AND CLA.CD_ANALISE = CFF.CD_ANALISE "
        SqlText = SqlText & "   AND ANL.CD_ANALISE = CFF.CD_ANALISE "
        SqlText = SqlText & " UNION ALL "
        SqlText = SqlText & "SELECT MVQ.SQ_MOVIMENTACAO, "
        SqlText = SqlText & "       ANL.NO_ANALISE, "
        SqlText = SqlText & "       ANL.CD_ANALISE, "
        SqlText = SqlText & "       MVQ.QT_ANALISE VL_ANALISE, "
        SqlText = SqlText & "           -1 SQ_CLASSIFICACAO "
        SqlText = SqlText & " FROM SOF.VW_MOVIMENTACAO_QUALIDADE_SMS MVQ, "
        SqlText = SqlText & "      SOF.ANALISE ANL, "
        SqlText = SqlText & "      SOF.MOVIMENTACAO_PILHA_ARMAZEM MPA "
        SqlText = SqlText & " WHERE MVQ.SQ_MOVIMENTACAO = MPA.SQ_MOVIMENTACAO "
        SqlText = SqlText & "   AND ANL.CD_ANALISE = MVQ.CD_ANALISE)WHERE CD_ANALISE = 19 AND QT_ANALISE > 0) FFA "
        SqlText = SqlText & " WHERE MPA.CD_ARMAZEM = PA.CD_ARMAZEM "
        SqlText = SqlText & "   AND MPA.CD_PILHA_ARMAZEM = PA.CD_PILHA_ARMAZEM "
        SqlText = SqlText & "   AND PA.CD_ARMAZEM = A.CD_ARMAZEM "
        SqlText = SqlText & "   AND MPA.SQ_MOVIMENTACAO = MOV.SQ_MOVIMENTACAO "
        SqlText = SqlText & "   AND MOV.SQ_MOVIMENTACAO = MOVQ.SQ_MOVIMENTACAO(+) "
        SqlText = SqlText & "   AND MOV.CD_FORNECEDOR = F.CD_FORNECEDOR(+) "
        SqlText = SqlText & "   AND MPA.CD_ARMAZEM = SF.CD_ARMAZEM(+) "
        SqlText = SqlText & "   AND MPA.CD_PILHA_ARMAZEM = SF.CD_PILHA_ARMAZEM(+) "
        SqlText = SqlText & "   AND MPA.SQ_MOVIMENTACAO = SF.SQ_MOVIMENTACAO(+) "
        SqlText = SqlText & "   AND MPA.SQ_MOVIMENTACAO_PILHA_ARMAZEM = SF.SQ_MOVIMENTACAO_PILHA_ARMAZEM(+) "
        SqlText = SqlText & "   AND MOV.SQ_MOVIMENTACAO = T.SQ_MOVIMENTACAO_ENTRADA(+) "
        SqlText = SqlText & "   AND T.CD_FILIAL_ORIGEM = FILTRAS.CD_FILIAL(+) "
        SqlText = SqlText & "   AND MOV.CD_PROCEDENCIA = P.CD_PROCEDENCIA(+) "
        SqlText = SqlText & "   AND P.CD_ORIGEM = O.CD_ORIGEM(+) "
        SqlText = SqlText & "   AND FFA.SQ_MOVIMENTACAO(+) = MPA.SQ_MOVIMENTACAO "

        SqlOrder = ""
        SqlGroup = ""

        '==> Filtra Armazém
        If CdArmazem <> -1 Then
            SqlFiltro = SqlFiltro & " AND MPA.CD_ARMAZEM =" & CdArmazem

            If CdPilha <> -1 Then
                SqlFiltro = SqlFiltro & " AND MPA.CD_PILHA_ARMAZEM=" & CdPilha
            End If
        Else
            If Cdfilial <> "" Then
                SqlFiltro = SqlFiltro & " AND A.CD_FILIAL_ORIGEM IN (SELECT CD_FILIAL FROM SOF.FILIAL " & _
                            "WHERE CD_FILIAL IN (" & Cdfilial & _
                            ") OR CD_FILIAL_RESPONSAVEL IN (" & Cdfilial & "))"
            End If
        End If

        '==>FILTRA PROCEDENCIA DO LOTE
        If CdProcedencia <> "" Then
            SqlFiltro = SqlFiltro & " AND MOV.CD_PROCEDENCIA IN (" & CdProcedencia & ")"
        End If

        '==>FILTRA DATA
        If IcData = True Then
            If IsDate(dtInicio) Then
                SqlFiltro = SqlFiltro & " AND MOV.DT_MOVIMENTACAO  >= " & QuotedStr(Date_to_Oracle(dtInicio))
            End If

            If IsDate(dtFinal) Then
                SqlFiltro = SqlFiltro & " AND MOV.DT_MOVIMENTACAO  <= " & QuotedStr(Date_to_Oracle(dtFinal))
            End If
        End If

        '==>FILTRA TIPO CACAU
        If CdTipoCacau <> -1 Then
            SqlFiltro = SqlFiltro & " AND MOVQ.IC_TIPO_CACAU=" & CdTipoCacau
        End If

        If IcHistorico = True Then
            'SE FOR HISTORICO FAÇO SELECT PARA TRAZER A UMA POSIÇÃO ANTERIORES
            SqlGroup = "UNION ALL "
            SqlGroup = SqlGroup & "SELECT  MOV.SQ_MOVIMENTACAO, MPA.CD_PILHA_ARMAZEM, MOV.DT_MOVIMENTACAO, "
            SqlGroup = SqlGroup & "       MOV.NU_NF, MOV.QT_KG_LIQUIDO_NF, MPA.QT_VOLUME QT_KG_A_TRANSFERIR, "
            SqlGroup = SqlGroup & "       A.CD_ARMAZEM, A.NO_ARMAZEM, MOVQ.QT_UMIDADE, FILTRAS.CD_FILIAL, "
            SqlGroup = SqlGroup & "       DECODE (F.NO_RAZAO_SOCIAL, "
            SqlGroup = SqlGroup & "               NULL, FILTRAS.NO_FILIAL, "
            SqlGroup = SqlGroup & "               F.NO_RAZAO_SOCIAL "
            SqlGroup = SqlGroup & "              ) NO_RAZAO_SOCIAL, "
            SqlGroup = SqlGroup & "       SF.QT_SACOS AS QT_SACO, MOVQ.PC_SUJIDADE, MOVQ.IC_TIPO_CACAU, "
            SqlGroup = SqlGroup & "       T.SQ_TRANSFERENCIA, MOVQ.QT_PESO_AMENDOA, MOVQ.QT_MOFO, MOVQ.QT_FUMACA, "
            SqlGroup = SqlGroup & "       MOVQ.QT_ARDOSIA, MOVQ.QT_ACHATADA, MOV.CD_PROCEDENCIA, "
            SqlGroup = SqlGroup & "       PA.CD_PROCEDENCIA CD_PROCEDENCIA_PILHA, P.CD_ORIGEM, O.NO_ORIGEM "
            SqlGroup = SqlGroup & "  FROM SOF.MOVIMENTACAO MOV, "
            SqlGroup = SqlGroup & "       SOF.MOV_PILHA_ARMAZEM_HISTORICO MPA, "
            SqlGroup = SqlGroup & "       SOF.PILHA_ARMAZEM PA, "
            SqlGroup = SqlGroup & "       SOF.ARMAZEM A, "
            SqlGroup = SqlGroup & "       SOF.MOVIMENTACAO_QUALIDADE MOVQ, "
            SqlGroup = SqlGroup & "       SOF.FORNECEDOR F, "
            SqlGroup = SqlGroup & "       SOF.MOV_PILHA_ARMAZEM_HIST_SACARIA  SF, "
            SqlGroup = SqlGroup & "       SOF.TRANSFERENCIA T, "
            SqlGroup = SqlGroup & "       SOF.FILIAL FILTRAS, "
            SqlGroup = SqlGroup & "       SOF.PROCEDENCIA P, "
            SqlGroup = SqlGroup & "       SOF.ORIGEM O "
            SqlGroup = SqlGroup & " WHERE MPA.CD_ARMAZEM = PA.CD_ARMAZEM "
            SqlGroup = SqlGroup & "   AND MPA.CD_PILHA_ARMAZEM = PA.CD_PILHA_ARMAZEM "
            SqlGroup = SqlGroup & "   AND PA.CD_ARMAZEM = A.CD_ARMAZEM "
            SqlGroup = SqlGroup & "   AND MPA.SQ_MOVIMENTACAO = MOV.SQ_MOVIMENTACAO "
            SqlGroup = SqlGroup & "   AND MOV.SQ_MOVIMENTACAO = MOVQ.SQ_MOVIMENTACAO(+) "
            SqlGroup = SqlGroup & "   AND MOV.CD_FORNECEDOR = F.CD_FORNECEDOR(+) "
            SqlGroup = SqlGroup & "   AND MPA.CD_ARMAZEM = SF.CD_ARMAZEM(+) "
            SqlGroup = SqlGroup & "   AND MPA.CD_PILHA_ARMAZEM = SF.CD_PILHA_ARMAZEM(+) "
            SqlGroup = SqlGroup & "   AND MPA.SQ_MOVIMENTACAO = SF.SQ_MOVIMENTACAO(+) "
            SqlGroup = SqlGroup & "   AND MPA.SQ_MOV_PILHA_ARMAZEM_HISTORICO = SF.SQ_MOV_PILHA_ARMAZEM_HISTORICO(+) "
            SqlGroup = SqlGroup & "   AND MOV.SQ_MOVIMENTACAO = T.SQ_MOVIMENTACAO_ENTRADA(+) "
            SqlGroup = SqlGroup & "   AND T.CD_FILIAL_ORIGEM = FILTRAS.CD_FILIAL(+) "
            SqlGroup = SqlGroup & "   AND PA.CD_PROCEDENCIA = P.CD_PROCEDENCIA(+) "
            SqlGroup = SqlGroup & "   AND P.CD_ORIGEM = O.CD_ORIGEM(+) "
            SqlGroup = SqlGroup & "   AND MPA.DT_TRANSACAO >'" & Date_to_Oracle(dtInicio) & "' "
            SqlGroup = SqlGroup & "   AND MPA.IC_SAIDA='S' "
            'ADICIONO O FILTRO
            SqlGroup = SqlGroup & SqlFiltro
            SqlGroup = SqlGroup & "   ) GRP "
            SqlGroup = SqlGroup & "WHERE NOT GRP.SQ_MOVIMENTACAO IN (SELECT DISTINCT MH.SQ_MOVIMENTACAO  "
            SqlGroup = SqlGroup & "                                FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO MH "
            SqlGroup = SqlGroup & "                                WHERE MH.DT_TRANSACAO >'" & Date_to_Oracle(dtInicio) & "' "
            SqlGroup = SqlGroup & "                                AND MH.IC_SAIDA ='N') "
        End If

        oDataT = DBQuery(SqlText & SqlFiltro & SqlGroup & SqlOrder)

        With oData.Columns
            .Add("sq_movimentacao").DataType = System.Type.GetType("System.Int32")
            .Add("cd_pilha_armazem").DataType = System.Type.GetType("System.Int32")
            .Add("dt_movimentacao").DataType = System.Type.GetType("System.DateTime")
            .Add("nu_nf").DataType = System.Type.GetType("System.String")
            .Add("qt_kg_liquido_nf").DataType = System.Type.GetType("System.Int32")
            .Add("qt_kg_a_transferir").DataType = System.Type.GetType("System.Int32")
            .Add("cd_armazem").DataType = System.Type.GetType("System.Int32")
            .Add("no_armazem").DataType = System.Type.GetType("System.String")
            .Add("qt_umidade").DataType = System.Type.GetType("System.Double")
            .Add("no_razao_social").DataType = System.Type.GetType("System.String")
            .Add("qt_saco").DataType = System.Type.GetType("System.Int32")
            .Add("pc_sujidade").DataType = System.Type.GetType("System.Double")
            .Add("ic_tipo_cacau").DataType = System.Type.GetType("System.Int32")
            .Add("qt_peso_amendoa").DataType = System.Type.GetType("System.Double")
            .Add("qt_mofo").DataType = System.Type.GetType("System.Double")
            .Add("qt_fumaca").DataType = System.Type.GetType("System.Double")
            .Add("qt_ardosia").DataType = System.Type.GetType("System.Double")
            .Add("qt_achatada").DataType = System.Type.GetType("System.Double")
            .Add("cd_procedencia").DataType = System.Type.GetType("System.String")
            .Add("cd_procedencia_pilha").DataType = System.Type.GetType("System.String")
            .Add("cd_origem").DataType = System.Type.GetType("System.Int32")
            .Add("no_origem").DataType = System.Type.GetType("System.String")
            .Add("qt_ffa").DataType = System.Type.GetType("System.Double")
            .Add("qt_capacidade").DataType = System.Type.GetType("System.Double")
        End With

        Dim iCont As Integer

        For iCont = 0 To oDataT.Rows.Count - 1
            If IcResumo = False Then
                'se for uma transferencia pego o nome do fornecedor pois de outra forma o nome do fornecedor não aparece
                If Not objDataTable_CampoVazio(oDataT.Rows(iCont).Item("sq_transferencia")) Then
                    SqlText = "SELECT DECODE (F.NO_RAZAO_SOCIAL, "
                    SqlText = SqlText & "               NULL, FIL.NO_FILIAL, "
                    SqlText = SqlText & "               F.NO_RAZAO_SOCIAL "
                    SqlText = SqlText & "              ) NO_RAZAO_SOCIAL "
                    SqlText = SqlText & "  FROM SOF.MOVIMENTACAO M, "
                    SqlText = SqlText & "       SOF.ITEM_TRANSFERENCIA IT, "
                    SqlText = SqlText & "       SOF.TRANSFERENCIA T, "
                    SqlText = SqlText & "       SOF.FORNECEDOR F, "
                    SqlText = SqlText & "       SOF.FILIAL FIL "
                    SqlText = SqlText & " WHERE M.SQ_MOVIMENTACAO = IT.SQ_MOVIMENTACAO "
                    SqlText = SqlText & "   AND M.CD_FORNECEDOR = F.CD_FORNECEDOR(+) "
                    SqlText = SqlText & "   AND M.SQ_MOVIMENTACAO = T.SQ_MOVIMENTACAO_ENTRADA(+) "
                    SqlText = SqlText & "   AND T.CD_FILIAL_ORIGEM = FIL.CD_FILIAL(+) "
                    SqlText = SqlText & "   AND IT.SQ_TRANSFERENCIA =  " & oDataT.Rows(iCont).Item("SQ_TRANSFERENCIA")

                    oDataE = DBQuery(SqlText)

                    If oDataE.Rows.Count > 1 Then
                        Fornecedor = "Transf " & oDataT.Rows(iCont).Item("no_razao_social") & " - Varios fornecedores"
                    Else
                        If oDataT.Rows(iCont).Item("no_razao_social") <> CStr(NVL(oDataE.Rows(0).Item("no_razao_social"), oDataT.Rows(iCont).Item("no_razao_social"))) Then
                            If oDataT.Rows(iCont).Item("cd_filial") <> FilialLogada Then
                                Fornecedor = "Transf " & oDataT.Rows(iCont).Item("no_razao_social") & " - " & NVL(oDataE.Rows(0).Item("no_razao_social"), oDataT.Rows(iCont).Item("no_razao_social"))
                            Else
                                Fornecedor = "" & NVL(oDataE.Rows(0).Item("no_razao_social"), oDataT.Rows(iCont).Item("no_razao_social"))
                            End If
                        Else
                            Fornecedor = "" & NVL(oDataE.Rows(0).Item("no_razao_social"), oDataT.Rows(iCont).Item("no_razao_social"))
                        End If
                    End If
                Else
                    Fornecedor = "" & oDataT.Rows(iCont).Item("no_razao_social")
                End If
            Else
                Fornecedor = "" & oDataT.Rows(iCont).Item("no_razao_social")
            End If

            oRow = oData.NewRow
            oRow.Item("SQ_MOVIMENTACAO") = oDataT.Rows(iCont).Item("SQ_MOVIMENTACAO")
            oRow.Item("CD_PILHA_ARMAZEM") = oDataT.Rows(iCont).Item("CD_PILHA_ARMAZEM")
            oRow.Item("DT_MOVIMENTACAO") = oDataT.Rows(iCont).Item("DT_MOVIMENTACAO")
            oRow.Item("NU_NF") = oDataT.Rows(iCont).Item("NU_NF")
            oRow.Item("QT_KG_LIQUIDO_NF") = oDataT.Rows(iCont).Item("QT_KG_LIQUIDO_NF")
            oRow.Item("QT_KG_A_TRANSFERIR") = oDataT.Rows(iCont).Item("QT_KG_A_TRANSFERIR")
            oRow.Item("CD_ARMAZEM") = oDataT.Rows(iCont).Item("CD_ARMAZEM")
            oRow.Item("NO_ARMAZEM") = oDataT.Rows(iCont).Item("NO_ARMAZEM")
            oRow.Item("QT_UMIDADE") = oDataT.Rows(iCont).Item("QT_UMIDADE")
            oRow.Item("NO_RAZAO_SOCIAL") = Mid(Fornecedor, 1, 40)
            oRow.Item("QT_SACO") = oDataT.Rows(iCont).Item("QT_SACO")
            oRow.Item("PC_SUJIDADE") = oDataT.Rows(iCont).Item("PC_SUJIDADE")
            oRow.Item("IC_TIPO_CACAU") = oDataT.Rows(iCont).Item("IC_TIPO_CACAU")
            oRow.Item("QT_PESO_AMENDOA") = oDataT.Rows(iCont).Item("QT_PESO_AMENDOA")
            oRow.Item("QT_MOFO") = oDataT.Rows(iCont).Item("QT_MOFO")
            oRow.Item("QT_FUMACA") = oDataT.Rows(iCont).Item("QT_FUMACA")
            oRow.Item("QT_ARDOSIA") = oDataT.Rows(iCont).Item("QT_ARDOSIA")
            oRow.Item("QT_ACHATADA") = oDataT.Rows(iCont).Item("QT_ACHATADA")
            oRow.Item("CD_PROCEDENCIA") = oDataT.Rows(iCont).Item("CD_PROCEDENCIA")
            oRow.Item("CD_PROCEDENCIA_PILHA") = oDataT.Rows(iCont).Item("CD_PROCEDENCIA_PILHA")
            oRow.Item("CD_ORIGEM") = oDataT.Rows(iCont).Item("CD_ORIGEM")
            oRow.Item("NO_ORIGEM") = oDataT.Rows(iCont).Item("NO_ORIGEM")
            oRow.Item("QT_FFA") = Val("" & oDataT.Rows(iCont).Item("QT_FFA"))
            oRow.Item("QT_CAPACIDADE") = Val("" & oDataT.Rows(iCont).Item("QT_CAPACIDADE"))

            If Not oRow Is Nothing Then oData.Rows.Add(oRow)
        Next

        Gera_Data_Armazem_Pilha = oData
    End Function

    Public Function Gera_RS_Neg_A_Ordem(ByVal Cdfilial As String, Optional ByVal bComSomenteValor As Boolean = False) As DataTable
        Dim oData As DataTable
        Dim SqlText As String

        SqlText = "SELECT FIL.CD_FILIAL," & _
                         "FIL.NO_FILIAL," & _
                         "F.CD_FORNECEDOR," & _
                         "F.NO_RAZAO_SOCIAL," & _
                         "TM.CD_TIPO_MOVIMENTACAO," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "M.CD_FILIAL_MOVIMENTACAO," & _
                         "M.DT_MOVIMENTACAO," & _
                         "M.NU_NF," & _
                         "M.VL_NF," & _
                         "M.QT_KG_NF," & _
                         "M.QT_KG_LIQUIDO_NF," & _
                         "SUM(CPM.QT_KG_A_FIXAR) QT_KG_A_FIXAR," & _
                         "SUM(CPM.VL_A_FIXAR) VL_A_FIXAR," & _
                         "M.VL_NF_FUNRURAL," & _
                         "M.VL_NF_ICMS," & _
                         "TP.NO_TIPO_PESSOA," & _
                         "TD.VL_TAXA AS VL_TAXA_US," & _
                         "M.SQ_MOVIMENTACAO," & _
                         "MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                         "M.QT_DESCONTO_QUALIDADE," & _
                         "TO_CHAR(CPM.CD_CONTRATO_PAF) CD_CONTRATO_PAF," & _
                         "TCP.IC_ADIANTAMENTO," & _
                         "TO_DATE(" & QuotedStr(Date_to_Oracle(DataSistema)) & ") DT_HOJE," & _
                         "TO_DATE('1-JUN-2004') DT_VIGENCIA," & _
                         "NVL(F.NU_TEL, F.NU_CELULAR) NU_TELEFONE," & _
                         "SUM(FRE.VL_FRETE_ATUAL) VL_FRETE_ATUAL," & _
                         "NVL(N.VL_NEGOCIACAO, 0) VL_DIFERENCIAL," & _
                         "NVL(SOF.FC_INDICE_VALORES(TP.CD_TIPO_PESSOA, N.DT_NEGOCIACAO, " & cnt_Processo_Confis & "), 0) + " & _
                             "NVL(SOF.FC_INDICE_VALORES(TP.CD_TIPO_PESSOA, N.DT_NEGOCIACAO, " & cnt_Processo_PIS & "), 0) PC_PIS_COFINS," & _
                         "N.VL_BOLSA" & _
                  " FROM SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                        "SOF.MOVIMENTACAO M," & _
                        "SOF.CTR_PAF_NEG_MOVIMENTACAO CPM," & _
                        "SOF.TAXA_DOLAR TD," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.TIPO_PESSOA TP," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.NEGOCIACAO N," & _
                        "(SELECT F.CD_FILIAL," & _
                                "1 CD_LOCAL_ENTREGA, " & _
                                "F.VL_FRETE_FILIAL_FAZENDA + F.VL_FRETE_FILIAL_FABRICA + F.VL_FRETE_FABRICA VL_FRETE_ATUAL" & _
                         " FROM SOF.FILIAL F" & _
                        " UNION ALL " & _
                        " SELECT F.CD_FILIAL," & _
                                "2 CD_LOCAL_ENTREGA, " & _
                                "F.VL_FRETE_FILIAL_FABRICA + F.VL_FRETE_FABRICA VL_FRETE_ATUAL" & _
                         " FROM SOF.FILIAL F " & _
                        " UNION ALL " & _
                        " SELECT F.CD_FILIAL," & _
                                "3 CD_LOCAL_ENTREGA, " & _
                                "F.VL_FRETE_FABRICA VL_FRETE_ATUAL" & _
                         " FROM SOF.FILIAL F) FRE," & _
                        "SOF.TIPO_CONTRATO_PAF TCP" & _
                  " WHERE CPM.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO " & _
                    " AND CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO = MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO " & _
                    " AND M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO " & _
                    " AND MCD.CD_FORNECEDOR = F.CD_FORNECEDOR " & _
                    " AND M.CD_TIPO_MOVIMENTACAO = TM.CD_TIPO_MOVIMENTACAO " & _
                    " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL " & _
                    " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA " & _
                    " AND FRE.CD_FILIAL(+) = N.CD_FILIAL_ENTREGA " & _
                    " AND FRE.CD_LOCAL_ENTREGA(+) = N.CD_LOCAL_ENTREGA" & _
                    " AND CPM.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF " & _
                    " AND CPM.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF " & _
                    " AND CPM.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO  " & _
                    " AND CP.CD_TIPO_CONTRATO_PAF = TCP.CD_TIPO_CONTRATO_PAF " & _
                    " AND TD.DT_COTACAO(+) = M.DT_MOVIMENTACAO "
        If bComSomenteValor Then
            SqlText = SqlText & " AND cpm.vl_a_fixar<>0 "
        Else
            SqlText = SqlText & " AND (CPM.QT_KG_A_FIXAR <> 0 or (m.qt_kg_liquido_nf=0 and cpm.vl_a_fixar<>0)) "
        End If
        SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & Cdfilial & ") " & _
            " GROUP BY FIL.CD_FILIAL," & _
                      "FIL.NO_FILIAL," & _
                      "F.CD_FORNECEDOR, " & _
                      "F.NO_RAZAO_SOCIAL, " & _
                      "TM.CD_TIPO_MOVIMENTACAO, " & _
                      "TM.NO_TIPO_MOVIMENTACAO, " & _
                      "M.CD_FILIAL_MOVIMENTACAO, " & _
                      "M.DT_MOVIMENTACAO," & _
                      "M.NU_NF," & _
                      "M.VL_NF," & _
                      "M.QT_KG_NF," & _
                      "M.QT_KG_LIQUIDO_NF," & _
                      "M.VL_NF_FUNRURAL," & _
                      "M.VL_NF_ICMS," & _
                      "TP.NO_TIPO_PESSOA," & _
                      "TD.VL_TAXA," & _
                      "M.SQ_MOVIMENTACAO," & _
                      "MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                      "M.QT_DESCONTO_QUALIDADE," & _
                      "CPM.CD_CONTRATO_PAF," & _
                      "TCP.IC_ADIANTAMENTO," & _
                      "TO_DATE(" & QuotedStr(Date_to_Oracle(DataSistema)) & ")," & _
                      "NVL(F.NU_TEL, F.NU_CELULAR)," & _
                      "NVL(N.VL_NEGOCIACAO,0)," & _
                      "NVL(SOF.FC_INDICE_VALORES(TP.CD_TIPO_PESSOA, N.DT_NEGOCIACAO, " & cnt_Processo_Confis & "), 0) + " & _
                          "NVL(SOF.FC_INDICE_VALORES(TP.CD_TIPO_PESSOA, N.DT_NEGOCIACAO, " & cnt_Processo_PIS & "), 0)," & _
                      "N.VL_BOLSA"
        oData = DBQuery(SqlText)

        Gera_RS_Neg_A_Ordem = oData
    End Function

    Public Function Gera_Rs_Cacau_A_Ordem(ByVal Cdfilial As String, _
                                          ByVal Sem_PAF As Boolean, _
                                          ByVal Com_Atraso As Boolean, _
                                          ByVal Dt_Prazo_Final As Date, _
                                          ByVal IcVlAberto As Boolean, _
                                          ByVal AVencer As Boolean, _
                                          ByVal SemPrazo As Boolean, _
                                          ByVal SemMov As Boolean, _
                                          Optional ByVal Total_KG_A_Ordem_Filial As Boolean = False, _
                                          Optional ByVal FreteContrato As Boolean = False) As DataTable

        Dim oData As DataTable
        Dim SqlText As String
        Dim SqlText2 As String
        Dim DataVigencia As Date

        SqlText = "SELECT DT_VIGENCIA_DESAGIO FROM SOF.PARAMETRO"
        DataVigencia = DBQuery_ValorUnico(SqlText)

        If Com_Atraso = False And IcVlAberto = False And AVencer = False And SemPrazo = False Then
            SqlText = "SELECT FIL.CD_FILIAL," & _
                             "FIL.NO_FILIAL," & _
                             "F.CD_FORNECEDOR," & _
                             "F.NO_RAZAO_SOCIAL," & _
                             "TM.NO_TIPO_MOVIMENTACAO," & _
                             "M.CD_FILIAL_MOVIMENTACAO," & _
                             "M.DT_MOVIMENTACAO," & _
                             "M.NU_NF," & _
                             "M.VL_NF," & _
                             "M.QT_KG_NF," & _
                             "M.QT_KG_LIQUIDO_NF," & _
                             "MCD.QT_KG_A_FIXAR," & _
                             "MCD.VL_A_FIXAR," & _
                             "M.VL_NF_FUNRURAL," & _
                             "M.VL_NF_ICMS," & _
                             "TP.NO_TIPO_PESSOA," & _
                             "TD.VL_TAXA AS VL_TAXA_US," & _
                             "M.SQ_MOVIMENTACAO," & _
                             "MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                             "M.QT_DESCONTO_QUALIDADE," & _
                             "'' CD_CONTRATO_PAF," & _
                             "'S' IC_ADIANTAMENTO," & _
                             "TO_DATE(" & QuotedStr(Date_to_Oracle(DataSistema)) & ") DT_HOJE," & _
                             "TO_DATE(" & QuotedStr(Date_to_Oracle(DataSistema)) & ") DT_VIGENCIA," & _
                             "NVL(F.NU_TEL, F.NU_CELULAR) NU_TELEFONE," & _
                             "FRE.VL_FRETE_ATUAL," & _
                             "0 VL_DIFERENCIAL," & _
                             "NVL(SOF.FC_INDICE_VALORES(F.CD_TIPO_PESSOA, M.DT_MOVIMENTACAO, " & cnt_Processo_Confis & "), 0) + " & _
                                 "NVL(SOF.FC_INDICE_VALORES(F.CD_TIPO_PESSOA, M.DT_MOVIMENTACAO, " & cnt_Processo_PIS & "), 0) PC_PIS_COFINS," & _
                             "0 VL_BOLSA" & _
                      " FROM SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                            "SOF.MOVIMENTACAO M," & _
                            "SOF.TAXA_DOLAR TD," & _
                            "SOF.FORNECEDOR F," & _
                            "SOF.TIPO_MOVIMENTACAO TM," & _
                            "SOF.FILIAL FIL," & _
                            "(SELECT F.CD_FILIAL," & _
                                    "1 CD_LOCAL_ENTREGA," & _
                                    "F.VL_FRETE_FILIAL_FAZENDA + F.VL_FRETE_FILIAL_FABRICA + F.VL_FRETE_FABRICA VL_FRETE_ATUAL" & _
                             " FROM SOF.FILIAL F" & _
                            " UNION ALL " & _
                             "SELECT F.CD_FILIAL," & _
                                    "2 CD_LOCAL_ENTREGA," & _
                                    "F.VL_FRETE_FILIAL_FABRICA + F.VL_FRETE_FABRICA VL_FRETE_ATUAL" & _
                             " FROM SOF.FILIAL F" & _
                            " UNION ALL " & _
                            "SELECT F.CD_FILIAL," & _
                                   "3 CD_LOCAL_ENTREGA," & _
                                   "F.VL_FRETE_FABRICA VL_FRETE_ATUAL" & _
                            " FROM SOF.FILIAL F) FRE, " & _
                            "SOF.TIPO_PESSOA TP" & _
                      " WHERE M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                        " AND MCD.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                        " AND M.CD_TIPO_MOVIMENTACAO = TM.CD_TIPO_MOVIMENTACAO" & _
                        " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                        " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA" & _
                        " AND TD.DT_COTACAO (+) = M.DT_MOVIMENTACAO" & _
                        " AND FRE.CD_FILIAL (+) = M.CD_FILIAL_MOVIMENTACAO" & _
                        " AND M.CD_LOCAL_ENTREGA = FRE.CD_LOCAL_ENTREGA (+) " & _
                        " AND (MCD.QT_KG_A_FIXAR <> 0 OR MCD.VL_A_FIXAR <> 0)"

            'Filtro Filial
            If Cdfilial <> "" Then
                SqlText = SqlText & _
                        " AND F.CD_FILIAL_ORIGEM IN (" & Cdfilial & ")"
            End If

            'Uso esse filtra para lista apenas quem esta a mais de 6 meses sem movimentar
            If SemMov = True Then
                SqlText = SqlText & _
                        " AND  F.CD_FORNECEDOR NOT IN (SELECT FO.CD_FORNECEDOR" & _
                                                      " FROM SOF.MOVIMENTACAO M," & _
                                                            "SOF.FORNECEDOR FO" & _
                                                      " WHERE M.CD_FORNECEDOR = FO.CD_FORNECEDOR" & _
                                                        " AND M.DT_CRIACAO > ADD_MONTHS(" & QuotedStr(Date_to_Oracle(DataSistema)) & ", -6))" & _
                                                        " AND F.CD_FORNECEDOR NOT IN (SELECT FO2.CD_FORNECEDOR" & _
                                                                                     " FROM SOF.CONTRATO_PAF CP," & _
                                                                                           "SOF.CONTRATO_FIXO CF," & _
                                                                                           "SOF.FORNECEDOR FO2" & _
                                                                                     " WHERE CP.CD_FORNECEDOR = FO2.CD_FORNECEDOR" & _
                                                                                       " AND CP.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                                                                                       " AND CF.DT_CONTRATO_FIXO > ADD_MONTHS(" & QuotedStr(Date_to_Oracle(DataSistema)) & ", -6))"
            End If
        End If

        If Sem_PAF = False Then
            If Com_Atraso = False And IcVlAberto = False And AVencer = False And SemPrazo = False Then
                SqlText = SqlText & " UNION ALL "
            Else
                SqlText = ""
            End If

            SqlText2 = _
                     "SELECT FIL.CD_FILIAL," & _
                             "FIL.NO_FILIAL," & _
                             "F.CD_FORNECEDOR," & _
                             "F.NO_RAZAO_SOCIAL," & _
                             "TM.NO_TIPO_MOVIMENTACAO," & _
                             "M.CD_FILIAL_MOVIMENTACAO," & _
                             "M.DT_MOVIMENTACAO," & _
                             "M.NU_NF," & _
                             "M.VL_NF," & _
                             "M.QT_KG_NF," & _
                             "M.QT_KG_LIQUIDO_NF," & _
                             "SUM(CPM.QT_KG_A_FIXAR) QT_KG_A_FIXAR," & _
                             "SUM(CPM.VL_A_FIXAR) VL_A_FIXAR," & _
                             "M.VL_NF_FUNRURAL," & _
                             "M.VL_NF_ICMS," & _
                             "TP.NO_TIPO_PESSOA," & _
                             "TD.VL_TAXA AS VL_TAXA_US," & _
                             "M.SQ_MOVIMENTACAO," & _
                             "MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                             "M.QT_DESCONTO_QUALIDADE," & _
                             "TO_CHAR(CPM.CD_CONTRATO_PAF) CD_CONTRATO_PAF," & _
                             "TCP.IC_ADIANTAMENTO," & _
                             "TO_DATE(" & QuotedStr(Date_to_Oracle(DataSistema)) & ") DT_HOJE," & _
                             "TO_DATE(" & QuotedStr(Date_to_Oracle(DataVigencia)) & ") DT_VIGENCIA," & _
                             "NVL(F.NU_TEL, F.NU_CELULAR) NU_TELEFONE," & _
                             "0 VL_DIFERENCIAL," & _
                             "NVL(SOF.FC_INDICE_VALORES(F.CD_TIPO_PESSOA, M.DT_MOVIMENTACAO, " & cnt_Processo_Confis & "), 0) + " & _
                                 "NVL(SOF.FC_INDICE_VALORES(F.CD_TIPO_PESSOA, M.DT_MOVIMENTACAO, " & cnt_Processo_PIS & "), 0) PC_PIS_COFINS," & _
                             IIf(FreteContrato, "CP.CD_FILIAL_ENTREGA", "M.CD_FILIAL_MOVIMENTACAO") & " CD_FILIAL_ENTREGA," & _
                             "M.CD_LOCAL_ENTREGA" & _
                      " FROM SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                            "SOF.MOVIMENTACAO M," & _
                            "SOF.CTR_PAF_MOVIMENTACAO CPM," & _
                            "SOF.TAXA_DOLAR TD," & _
                            "SOF.FORNECEDOR F," & _
                            "SOF.TIPO_MOVIMENTACAO TM," & _
                            "SOF.FILIAL FIL," & _
                            "SOF.TIPO_PESSOA TP," & _
                            "SOF.CONTRATO_PAF CP, " & _
                            "SOF.TIPO_CONTRATO_PAF TCP" & _
                      " WHERE CPM.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                        " AND CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO = MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                        " AND M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                        " AND MCD.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                        " AND M.CD_TIPO_MOVIMENTACAO = TM.CD_TIPO_MOVIMENTACAO" & _
                        " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                        " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA" & _
                        " AND CPM.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                        " AND CP.CD_TIPO_CONTRATO_PAF = TCP.CD_TIPO_CONTRATO_PAF" & _
                        " AND TD.DT_COTACAO (+) = M.DT_MOVIMENTACAO"

            If IcVlAberto = False Then
                SqlText2 = SqlText2 & _
                          " AND (CPM.QT_KG_A_FIXAR <> 0 OR CPM.VL_A_FIXAR <> 0)"
            End If

            'Filtro Filial
            If Cdfilial <> "" Then
                SqlText2 = SqlText2 & _
                          " AND F.CD_FILIAL_ORIGEM IN (" & Cdfilial & ")"
            End If

            Select Case True
                Case Com_Atraso
                    SqlText2 = SqlText2 & _
                              " AND (M.DT_MOVIMENTACAO + 365) < " & QuotedStr(Date_to_Oracle(Dt_Prazo_Final)) & _
                              " AND TCP.IC_ADIANTAMENTO = 'N'" & _
                              " AND M.DT_MOVIMENTACAO >= " & QuotedStr(Date_to_Oracle(DataVigencia))
                Case AVencer
                    SqlText2 = SqlText2 & _
                              " AND (M.DT_MOVIMENTACAO + 365) >= " & QuotedStr(Date_to_Oracle(Dt_Prazo_Final)) & _
                              " AND TCP.IC_ADIANTAMENTO = 'N'" & _
                              " AND M.DT_MOVIMENTACAO >= " & QuotedStr(Date_to_Oracle(DataVigencia))
                Case SemPrazo
                    SqlText2 = SqlText2 & _
                              " AND TCP.IC_ADIANTAMENTO = 'N'" & _
                              " AND M.DT_MOVIMENTACAO < " & QuotedStr(Date_to_Oracle(DataVigencia))
            End Select

            'Uso esse filtra para lista apenas quem esta a mais de 6 meses sem movimentar
            If SemMov = True Then
                SqlText2 = SqlText2 & _
                          " AND  F.CD_FORNECEDOR NOT IN (SELECT FO.CD_FORNECEDOR" & _
                                                        " FROM SOF.MOVIMENTACAO M," & _
                                                              "SOF.FORNECEDOR FO" & _
                                                        " WHERE M.CD_FORNECEDOR = FO.CD_FORNECEDOR" & _
                                                          " AND M.DT_CRIACAO > add_months(" & QuotedStr(Date_to_Oracle(DataSistema)) & ", -6))" & _
                                                          " AND  F.CD_FORNECEDOR NOT IN (SELECT FO2.CD_FORNECEDOR" & _
                                                                                        " FROM SOF.CONTRATO_PAF CP," & _
                                                                                              "SOF.CONTRATO_FIXO CF," & _
                                                                                              "SOF.FORNECEDOR FO2" & _
                                                                                        " WHERE CP.CD_FORNECEDOR = FO2.CD_FORNECEDOR" & _
                                                                                          " AND CP.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                                                                                          " AND CF.DT_CONTRATO_FIXO > ADD_MONTHS(" & QuotedStr(Date_to_Oracle(DataSistema)) & ", -6))"
            End If

            SqlText2 = SqlText2 & _
                      " GROUP BY FIL.CD_FILIAL," & _
                                "FIL.NO_FILIAL," & _
                                "F.CD_FORNECEDOR," & _
                                "F.NO_RAZAO_SOCIAL," & _
                                "TM.NO_TIPO_MOVIMENTACAO," & _
                                "M.CD_FILIAL_MOVIMENTACAO," & _
                                "M.DT_MOVIMENTACAO," & _
                                "M.NU_NF," & _
                                "M.VL_NF," & _
                                "M.QT_KG_NF," & _
                                "M.QT_KG_LIQUIDO_NF," & _
                                "M.VL_NF_FUNRURAL," & _
                                "M.VL_NF_ICMS," & _
                                "TP.NO_TIPO_PESSOA," & _
                                "TD.VL_TAXA," & _
                                "M.SQ_MOVIMENTACAO," & _
                                "MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                                "M.QT_DESCONTO_QUALIDADE," & _
                                "CPM.CD_CONTRATO_PAF," & _
                                "TCP.IC_ADIANTAMENTO," & _
                                "TO_DATE(" & QuotedStr(Date_to_Oracle(DataSistema)) & ")," & _
                                "NVL(F.NU_TEL, F.NU_CELULAR)," & _
                                "NVL(SOF.FC_INDICE_VALORES(F.CD_TIPO_PESSOA, M.DT_MOVIMENTACAO, " & cnt_Processo_Confis & "), 0) + " & _
                                    "NVL(SOF.FC_INDICE_VALORES(F.CD_TIPO_PESSOA, M.DT_MOVIMENTACAO, " & cnt_Processo_PIS & "), 0)," & _
                                IIf(FreteContrato, "CP.CD_FILIAL_ENTREGA", "M.CD_FILIAL_MOVIMENTACAO") & "," & _
                                "M.CD_LOCAL_ENTREGA"

            If IcVlAberto = True Then
                SqlText2 = SqlText2 & _
                          " HAVING (SUM(CPM.QT_KG_A_FIXAR) = 0 AND " & _
                                   "SUM(CPM.VL_A_FIXAR) <> 0)"
            End If

            SqlText = SqlText & _
                      "SELECT CA.CD_FILIAL," & _
                             "CA.NO_FILIAL," & _
                             "CA.CD_FORNECEDOR," & _
                             "CA.NO_RAZAO_SOCIAL," & _
                             "CA.NO_TIPO_MOVIMENTACAO," & _
                             "CA.CD_FILIAL_MOVIMENTACAO," & _
                             "CA.DT_MOVIMENTACAO," & _
                             "CA.NU_NF," & _
                             "CA.VL_NF," & _
                             "CA.QT_KG_NF," & _
                             "CA.QT_KG_LIQUIDO_NF," & _
                             "CA.QT_KG_A_FIXAR," & _
                             "CA.VL_A_FIXAR," & _
                             "CA.VL_NF_FUNRURAL," & _
                             "CA.VL_NF_ICMS," & _
                             "CA.NO_TIPO_PESSOA," & _
                             "CA.VL_TAXA_US," & _
                             "CA.SQ_MOVIMENTACAO," & _
                             "CA.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                             "CA.QT_DESCONTO_QUALIDADE," & _
                             "CA.CD_CONTRATO_PAF," & _
                             "CA.IC_ADIANTAMENTO," & _
                             "CA.DT_HOJE," & _
                             "CA.DT_VIGENCIA," & _
                             "CA.NU_TELEFONE," & _
                             "FRE.VL_FRETE_ATUAL," & _
                             "CA.VL_DIFERENCIAL," & _
                             "CA.PC_PIS_COFINS," & _
                             "0 VL_BOLSA" & _
                      " FROM (" & SqlText2 & ") CA," & _
                            "(SELECT F.CD_FILIAL," & _
                                    "1 CD_LOCAL_ENTREGA," & _
                                    "F.VL_FRETE_FILIAL_FAZENDA + F.VL_FRETE_FILIAL_FABRICA + F.VL_FRETE_FABRICA VL_FRETE_ATUAL" & _
                             " FROM SOF.FILIAL F" & _
                            " UNION ALL " & _
                             "SELECT F.CD_FILIAL," & _
                                    "2 CD_LOCAL_ENTREGA," & _
                                    "F.VL_FRETE_FILIAL_FABRICA + F.VL_FRETE_FABRICA VL_FRETE_ATUAL" & _
                             " FROM SOF.FILIAL F" & _
                            " UNION ALL " & _
                            " SELECT F.CD_FILIAL," & _
                                    "3 CD_LOCAL_ENTREGA," & _
                                    "F.VL_FRETE_FABRICA VL_FRETE_ATUAL " & _
                             " FROM SOF.FILIAL F) FRE" & _
                      " WHERE FRE.CD_FILIAL (+) = CA.CD_FILIAL_ENTREGA" & _
                        " AND FRE.CD_LOCAL_ENTREGA (+) = CA.CD_LOCAL_ENTREGA"
        End If

        If Total_KG_A_Ordem_Filial Then
            SqlText = "SELECT NO_FILIAL," & _
                              "LAST_DAY(DT_MOVIMENTACAO) DT_MES_ANO," & _
                             "SUM(QT_KG_A_FIXAR) QT_QUILOS," & _
                             "SUM(QT_KG_A_FIXAR - DECODE(IC_ADIANTAMENTO, 'N', 0, DECODE(NVL(CD_CONTRATO_PAF, 0), 0, 0, DECODE(INSTR(CD_CONTRATO_PAF, '-'), 0, QT_KG_A_FIXAR)))) QT_PAF_S_ADTO" & _
                      " FROM (" & SqlText & ")" & _
                      " GROUP BY NO_FILIAL," & _
                                "LAST_DAY(DT_MOVIMENTACAO)" & _
                      " ORDER BY NO_FILIAL"
        End If

        oData = DBQuery(SqlText)

        Gera_Rs_Cacau_A_Ordem = oData
    End Function

    Public Function Gera_Rs_Cacau_A_Ordem_Negociacao(ByVal IcVlAberto As Boolean, _
                                                     Optional ByVal CdFilial As String = "", _
                                                     Optional ByVal CdTipoNegociacao As String = "", _
                                                     Optional ByVal DataInicial As String = "", _
                                                     Optional ByVal DataFinal As String = "") As DataTable
        Dim odata As DataTable
        Dim SqlText As String


        SqlText = "SELECT FIL.CD_FILIAL, FIL.NO_FILIAL, F.CD_FORNECEDOR, F.NO_RAZAO_SOCIAL, " & _
                  "TM.NO_TIPO_MOVIMENTACAO, M.CD_FILIAL_MOVIMENTACAO, M.DT_MOVIMENTACAO, M.NU_NF, " & _
                  "M.VL_NF, M.QT_KG_NF, M.QT_KG_LIQUIDO_NF, SUM(CPNM.QT_KG_A_FIXAR) QT_KG_A_FIXAR, " & _
                  "SUM(CPNM.VL_A_FIXAR) VL_A_FIXAR, M.VL_NF_FUNRURAL, M.VL_NF_ICMS, TP.NO_TIPO_PESSOA, " & _
                  "TD.VL_TAXA vl_taxa_us, m.Sq_Movimentacao, MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO, " & _
                  "m.QT_DESCONTO_QUALIDADE, cpnm.cd_contrato_paf || '-' || cpnm.sq_negociacao cd_contrato_paf, " & _
                  "'S' ic_adiantamento, to_date('" & Date_to_Oracle(DataSistema) & "') dt_hoje, to_date('" & _
                  Date_to_Oracle(DataSistema) & "') DT_VIGENCIA " & _
                  "FROM SOF.MOVIMENTACAO_CESSAO_DIREITO MCD," & _
                       "SOF.MOVIMENTACAO M, " & _
                       "SOF.CTR_PAF_NEG_MOVIMENTACAO CPNM," & _
                       "SOF.TAXA_DOLAR TD, SOF.FORNECEDOR F," & _
                       "SOF.TIPO_MOVIMENTACAO TM," & _
                       "SOF.FILIAL FIL," & _
                       "SOF.TIPO_PESSOA TP," & _
                       "SOF.NEGOCIACAO NG " & _
                  "WHERE CPNM.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                   " AND CPNM.SQ_MOVIMENTACAO_CESSAO_DIREITO = MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                   " AND M.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                   " AND MCD.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                   " AND M.CD_TIPO_MOVIMENTACAO = TM.CD_TIPO_MOVIMENTACAO" & _
                   " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                   " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA" & _
                   " AND M.DT_MOVIMENTACAO = TD.DT_COTACAO (+)" & _
                   " AND NG.CD_CONTRATO_PAF = cpnm.CD_CONTRATO_PAF" & _
                   " AND NG.SQ_NEGOCIACAO = cpnm.SQ_NEGOCIACAO AND "
        If IcVlAberto = False Then
            SqlText = SqlText & "(CPNM.QT_KG_A_FIXAR <> 0 OR CPNM.VL_A_FIXAR <> 0)"
        Else
            SqlText = SqlText & "(CPNM.QT_KG_A_FIXAR = 0 and CPNM.VL_A_FIXAR <> 0)"
        End If

        'filtro filial
        If CdFilial <> "" Then
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN  (" & CdFilial & ")"
        End If
        If CdTipoNegociacao <> "" Then
            SqlText = SqlText & " AND NG.CD_TIPO_NEGOCIACAO IN  (" & CdTipoNegociacao & ")"
        End If
        If IsDate(DataInicial) Then
            SqlText = SqlText & " AND M.DT_MOVIMENTACAO >= " & QuotedStr(Date_to_Oracle(DataInicial))
        End If
        If IsDate(DataFinal) Then
            SqlText = SqlText & " AND M.DT_MOVIMENTACAO <= " & QuotedStr(Date_to_Oracle(DataFinal))
        End If

        SqlText = SqlText & " GROUP BY FIL.CD_FILIAL, FIL.NO_FILIAL, F.CD_FORNECEDOR, F.NO_RAZAO_SOCIAL, " & _
                  "TM.NO_TIPO_MOVIMENTACAO, M.CD_FILIAL_MOVIMENTACAO, M.DT_MOVIMENTACAO, M.NU_NF, M.VL_NF, " & _
                  "M.QT_KG_NF, M.QT_KG_LIQUIDO_NF, M.VL_NF_FUNRURAL, M.VL_NF_ICMS, TP.NO_TIPO_PESSOA, " & _
                  "TD.VL_TAXA, m.Sq_Movimentacao, MCD.SQ_MOVIMENTACAO_CESSAO_DIREITO, " & _
                  "m.QT_DESCONTO_QUALIDADE, cpnm.cd_contrato_paf , cpnm.sq_negociacao, 'N', " & _
                  "to_date('" & Date_to_Oracle(DataSistema) & "'), to_date('" & Date_to_Oracle(DataSistema) & "')"

        odata = DBQuery(SqlText)

        Gera_Rs_Cacau_A_Ordem_Negociacao = odata
    End Function

    Public Function Gera_Rs_Posicao_Fornecedor(ByVal VlBolsa As Double, _
                                               ByVal VlDolar As Double, _
                                               ByVal VlCompra As Double, _
                                               ByVal IcTitular As Boolean, _
                                               ByRef RsCredito As DataTable, _
                                               ByRef RsBonus As DataTable, _
                                               ByVal IcAgruparTitular As Boolean, _
                                               ByVal IcSafra As Boolean, _
                                               ByVal CdSafra As String, _
                                               Optional ByVal CdForn As Long = -1, _
                                               Optional ByVal CdFilial As String = "", _
                                               Optional ByVal CdModalidadeRecuperacaoCredito As String = "", _
                                               Optional ByVal FiltroExposure As PosForn_FiltroExposure = PosForn_FiltroExposure.feNenhum) As DataTable
        Dim CdFormaPagJuros As Long
        Dim JurosCtrFix As Boolean
        Dim JurosNegRec As Boolean
        Dim SqlText As String
        Dim SqlText_Exposure As String = ""
        Dim oDataAux As New DataTable

        SqlText = "SELECT P.CD_TP_PAG_JUROS," & _
                         "P.IC_JUROS_CTR_FIX," & _
                         "P.IC_JUROS_NEG_REC" & _
                  " FROM SOF.PARAMETRO P "
        oDataAux = DBQuery(SqlText)

        Select Case FiltroExposure
            Case PosForn_FiltroExposure.feSoAdiantamentosContratosBase
                SqlText_Exposure = "(SELECT DISTINCT CD_CONTRATO_PAF" & _
                                    " FROM (" & Gera_Sql_Adiantamento_Exposure_Analitico(False) & ")" & _
                                    " WHERE NVL(Adiantamentos_Ctr_Base, 0) <> 0) FEX,"
            Case PosForn_FiltroExposure.feSoAdiantamentoSemContratosBase
                SqlText_Exposure = "(SELECT DISTINCT CD_CONTRATO_PAF" & _
                                    " FROM (" & Gera_Sql_Adiantamento_Exposure_Analitico(False) & ")" & _
                                    " WHERE NVL(Adiantamentos_S_Ctr_Base, 0) <> 0) FEX,"
        End Select

        If oDataAux.Rows.Count > 0 Then
            CdFormaPagJuros = CLng(NVL(oDataAux.Rows(0).Item("CD_TP_PAG_JUROS"), -1))
            JurosCtrFix = IIf(oDataAux.Rows(0).Item("IC_JUROS_CTR_FIX") = "S", True, False)
            JurosNegRec = IIf(oDataAux.Rows(0).Item("IC_JUROS_NEG_REC") = "S", True, False)
        Else
            CdFormaPagJuros = -1
            JurosCtrFix = False
            JurosNegRec = False
        End If

        SqlText = "SELECT 1 CD_TIPO, "
        SqlText = SqlText & "       'CONTRATO PAF ' NO_TIPO, "
        SqlText = SqlText & "       CP.CD_CONTRATO_PAF, "
        SqlText = SqlText & "       -1 SQ_NEGOCIACAO, "
        SqlText = SqlText & "       -1 SQ_CONTRATO_FIXO, "
        SqlText = SqlText & "       TCP.CD_TIPO_CONTRATO_PAF, "
        SqlText = SqlText & "       TCP.NO_TIPO_CONTRATO_PAF, "
        SqlText = SqlText & "       FIL.CD_FILIAL, "
        SqlText = SqlText & "       FIL.NO_FILIAL, "

        If IcTitular = True Then
            SqlText = SqlText & "       CP.CD_REPASSADOR, "
            SqlText = SqlText & "       REP.NO_RAZAO_SOCIAL NO_REPASSADOR, "
        Else
            SqlText = SqlText & "       F.CD_FORNECEDOR CD_REPASSADOR, "
            SqlText = SqlText & "       F.NO_RAZAO_SOCIAL NO_REPASSADOR, "
        End If

        If IcAgruparTitular = True Then
            SqlText = SqlText & "       CP.CD_REPASSADOR as CD_FORNECEDOR, "
            SqlText = SqlText & "       REP.NO_RAZAO_SOCIAL NO_FORNECEDOR, "
        Else
            SqlText = SqlText & "       F.CD_FORNECEDOR, "
            SqlText = SqlText & "       F.NO_RAZAO_SOCIAL NO_FORNECEDOR, "
        End If

        SqlText = SqlText & "       CP.DT_PRAZO_ENTREGA DT_VENCIMENTO, " 'PARA NÃO FAZER GRANDE ALTERAÇÃO TROQUEI AS DATAS
        SqlText = SqlText & "       CP.QT_KGS, "
        SqlText = SqlText & "       CP.QT_CANCELADO, "
        SqlText = SqlText & "       CP.QT_KG_FIXO, "
        SqlText = SqlText & "       CP.QT_A_NEGOCIAR, "
        SqlText = SqlText & "       CP.VL_PAG_FIXO, "
        SqlText = SqlText & "       NVL(P.VL_PAG_AB,0) VL_PAG_AB, "
        SqlText = SqlText & "       ROUND(NVL(P.VL_PAG_AB_JUROS,0),2) - NVL(P.VL_PAG_AB,0) VL_JUROS, "
        SqlText = SqlText & "       ROUND(NVL(P.VL_PAG_AB_JUROS,0),2) VL_PAG_AB_JUROS, "
        SqlText = SqlText & "       NVL(CM.QT_KG_A_FIXAR,0) QT_KG_A_FIXAR, "
        SqlText = SqlText & "       NVL(CM.VL_NF_A_FIXAR,0) VL_NF_A_FIXAR, "
        SqlText = SqlText & "       NVL(CM.vl_qt_a_fixar,0) VL_QT_A_FIXAR, "
        SqlText = SqlText & "       0 VL_CREDITO_GARANTIA, "
        SqlText = SqlText & "       0 VL_CREDITO_PROVISORIO, "
        SqlText = SqlText & "       0 VL_CREDITO_TOTAL, 0 VL_GARANTIA, "
        SqlText = SqlText & "       CP.DT_CONTRATO_PAF DT_CONTRATO, CP.DT_PRAZO_FIXACAO, 0 VL_CONTRATO, "
        SqlText = SqlText & "       DECODE(TCP.IC_ADIANTAMENTO,'S','N','S') IC_MASTER, 0 VL_ICMS_ABERTO, "
        SqlText = SqlText & "       0  vl_hipoteca, 0 vl_promissoria, 0 vl_cpr, 0 vl_ctr_fianca, "
        SqlText = SqlText & "       null dt_hipoteca, null dt_promissoria, null dt_cpr,null  dt_ctr_fianca,   "
        SqlText = SqlText & "       decode(cp.cd_safra,0,20,1,21,2,22,3,23,4,24,5,25,cp.cd_safra) as cd_safra "
        SqlText = SqlText & "FROM SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & "     SOF.TIPO_CONTRATO_PAF TCP, "
        SqlText = SqlText & "     SOF.FORNECEDOR F, "
        SqlText = SqlText & "     SOF.FORNECEDOR REP, "
        SqlText = SqlText & "     SOF.FILIAL FIL, "
        SqlText = SqlText & SqlText_Exposure            '>>> PARA O FILTRO EXPOSURE
        SqlText = SqlText & "     (SELECT SUM(DECODE(CP.IC_CALCULA_JUROS || TP.IC_CALCULA_JUROS, 'SS', "
        SqlText = SqlText & "                        ((DECODE(SIGN((TO_DATE('" & Date_to_Oracle(DataSistema) & "') - P.DT_PAGAMENTO) - NVL(CP.QT_DIA_CARENCIA_JUROS,0)), -1, "
        SqlText = SqlText & "                                 0, "
        SqlText = SqlText & "                                 ROUND(((TO_DATE('" & Date_to_Oracle(DataSistema) & "') - TO_DATE(P.DT_PAGAMENTO)) - DECODE(NVL(CP.IC_JUROS_APOS_CARENCIA,'N'), 'S', "
        SqlText = SqlText & "                                                                                              NVL(CP.QT_DIA_CARENCIA_JUROS,0), "
        SqlText = SqlText & "                                                                                              0)),0)) * ((NVL(CP.PC_TAXA_JUROS,0) / 100) / 30)) * PCP.VL_A_FIXAR) + PCP.VL_A_FIXAR, "
        SqlText = SqlText & "                        PCP.VL_A_FIXAR)) VL_PAG_AB_JUROS, "
        SqlText = SqlText & "             NVL(SUM(PCP.VL_A_FIXAR), 0) VL_PAG_AB, "
        SqlText = SqlText & "             CP.CD_CONTRATO_PAF "
        SqlText = SqlText & "      FROM SOF.PAG_CTR_PAF PCP, "
        SqlText = SqlText & "           SOF.PAGAMENTOS P, "
        SqlText = SqlText & "           SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & "           SOF.TIPO_PAGAMENTO TP "
        SqlText = SqlText & "      WHERE PCP.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "            PCP.SQ_PAGAMENTO = P.SQ_PAGAMENTO AND "
        SqlText = SqlText & "            PCP.VL_A_FIXAR <> 0 AND "
        SqlText = SqlText & "            P.CD_TIPO_PAGAMENTO = TP.CD_TIPO_PAGAMENTO "

        If CdForn <> -1 Then
            If IcTitular = True Then
                SqlText = SqlText & "       and      cp.CD_REPASSADOR = " & CdForn & " "
            Else
                SqlText = SqlText & "      and       cp.cd_fornecedor = " & CdForn & " "
            End If
        End If

        If IcSafra = True Then
            SqlText = SqlText & "      and       cp.cd_safra in (" & CdSafra & ") "
        End If

        SqlText = SqlText & "      GROUP BY CP.CD_CONTRATO_PAF) P, "
        SqlText = SqlText & "     (SELECT CM.CD_CONTRATO_PAF, "
        SqlText = SqlText & "             SUM(CM.QT_KG_A_FIXAR) QT_KG_A_FIXAR, "
        SqlText = SqlText & "             SUM(CM.VL_A_FIXAR) VL_NF_A_FIXAR, "
        SqlText = SqlText & "             sum(decode(m.vl_nf,0,0,round(((cm.qt_kg_a_fixar * " & VlCompra & " / 15) / (1 - ((m.vl_nf_icms / m.vl_nf) + (fun.vl_taxa / 100)))) * (1-(fun.vl_taxa/100)),2))) vl_qt_a_fixar "
        SqlText = SqlText & "      FROM SOF.CTR_PAF_MOVIMENTACAO CM, "
        SqlText = SqlText & "           sof.contrato_paf cp, sof.movimentacao m, sof.fornecedor f, sof.funrural fun "
        SqlText = SqlText & "      WHERE (CM.QT_KG_A_FIXAR <> 0 OR CM.VL_A_FIXAR <> 0) and "
        SqlText = SqlText & "            cm.cd_contrato_paf = cp.cd_contrato_paf and "
        SqlText = SqlText & "            cm.sq_movimentacao = m.sq_movimentacao and "
        SqlText = SqlText & "            cp.cd_fornecedor = f.cd_fornecedor and "
        SqlText = SqlText & "            f.cd_funrural = fun.cd_funrural "

        If CdForn <> -1 Then
            If IcTitular = True Then
                SqlText = SqlText & "       and      cp.CD_REPASSADOR = " & CdForn & " "
            Else
                SqlText = SqlText & "      and       cp.cd_fornecedor = " & CdForn & " "
            End If
        End If

        If IcSafra = True Then
            SqlText = SqlText & "      and       cp.cd_safra in (" & CdSafra & ") "
        End If

        If CdFilial <> "" Then
            SqlText = SqlText & "AND F.cd_filial_origem in (" & CdFilial & ")"
        End If

        SqlText = SqlText & "      GROUP BY CM.CD_CONTRATO_PAF) CM "
        SqlText = SqlText & "WHERE CP.CD_TIPO_CONTRATO_PAF = TCP.CD_TIPO_CONTRATO_PAF AND "

        If Trim(SqlText_Exposure) <> "" Then
            SqlText = SqlText & "      CP.CD_CONTRATO_PAF = FEX.CD_CONTRATO_PAF AND "
        End If

        SqlText = SqlText & "      CP.CD_FORNECEDOR = F.CD_FORNECEDOR AND "
        SqlText = SqlText & "      CP.CD_REPASSADOR = REP.CD_FORNECEDOR AND "
        SqlText = SqlText & "      REP.CD_FILIAL_ORIGEM = FIL.CD_FILIAL AND "
        SqlText = SqlText & "      CP.CD_CONTRATO_PAF = P.CD_CONTRATO_PAF (+) AND "
        SqlText = SqlText & "      CP.CD_CONTRATO_PAF = CM.CD_CONTRATO_PAF (+) AND "
        SqlText = SqlText & "      CP.IC_STATUS = 'A' "

        If CdForn <> -1 Then
            If IcTitular = True Then
                SqlText = SqlText & "     and        cp.CD_REPASSADOR = " & CdForn & " "
            Else
                SqlText = SqlText & "      and       cp.cd_fornecedor = " & CdForn & " "
            End If
        End If

        If IcSafra = True Then
            SqlText = SqlText & "      and       cp.cd_safra in (" & CdSafra & ") "
        End If

        If CdFilial <> "" Then
            SqlText = SqlText & "AND F.cd_filial_origem in (" & CdFilial & ")"
        End If

        SqlText = SqlText & "UNION ALL "
        SqlText = SqlText & "SELECT 2 CD_TIPO, "
        SqlText = SqlText & "       'NEGOCIAÇÃO   ' NO_TIPO, "
        SqlText = SqlText & "       N.CD_CONTRATO_PAF, "
        SqlText = SqlText & "       N.SQ_NEGOCIACAO, "
        SqlText = SqlText & "       -1 SQ_CONTRATO_FIXO, "
        SqlText = SqlText & "       TN.CD_TIPO_NEGOCIACAO, "
        SqlText = SqlText & "       TN.NO_TIPO_NEGOCIACAO, "
        SqlText = SqlText & "       FIL.CD_FILIAL, "
        SqlText = SqlText & "       FIL.NO_FILIAL, "

        If IcTitular = True Then
            SqlText = SqlText & "       CP.CD_REPASSADOR, "
            SqlText = SqlText & "       REP.NO_RAZAO_SOCIAL NO_REPASSADOR, "
        Else
            SqlText = SqlText & "       F.CD_FORNECEDOR CD_REPASSADOR, "
            SqlText = SqlText & "       F.NO_RAZAO_SOCIAL NO_REPASSADOR, "
        End If

        If IcAgruparTitular = True Then
            SqlText = SqlText & "       CP.CD_REPASSADOR as CD_FORNECEDOR, "
            SqlText = SqlText & "       REP.NO_RAZAO_SOCIAL NO_FORNECEDOR, "
        Else
            SqlText = SqlText & "       F.CD_FORNECEDOR, "
            SqlText = SqlText & "       F.NO_RAZAO_SOCIAL NO_FORNECEDOR, "
        End If

        SqlText = SqlText & "       N.DT_VENCIMENTO, "
        SqlText = SqlText & "       N.QT_KGS, "
        SqlText = SqlText & "       N.QT_CANCELADO, "
        SqlText = SqlText & "       N.QT_KG_FIXO, "
        SqlText = SqlText & "       N.QT_A_FIXAR, "
        SqlText = SqlText & "       N.VL_PAG_FIXO, "

        Select Case True
            Case JurosCtrFix
                SqlText = SqlText & "       NVL(P.VL_PAG_AB,0) VL_PAG_AB, "
                SqlText = SqlText & "       ROUND(NVL(P.VL_PAG_AB_JUROS,0),2) - NVL(P.VL_PAG_AB,0) VL_JUROS, "
                SqlText = SqlText & "       ROUND(NVL(P.VL_PAG_AB_JUROS,0),2) VL_PAG_AB_JUROS, "
            Case JurosNegRec
                SqlText = SqlText & "       NVL(P.VL_PAG_AB,0) VL_PAG_AB, "
                SqlText = SqlText & "       decode(p.ic_juros_neg,'N', ROUND (NVL (p.vl_pag_ab_juros, 0), 2) - NVL (p.vl_pag_ab, 0),NVL(P.VL_PAG_AB_JUROS, 0)) VL_JUROS, "
                SqlText = SqlText & "       decode(p.ic_juros_neg,'N', ROUND (NVL (p.vl_pag_ab_juros, 0), 2), NVL(P.VL_PAG_AB, 0) + NVL(P.VL_PAG_AB_JUROS, 0)) VL_PAG_AB_JUROS, "
            Case Else
                SqlText = SqlText & "       NVL(P.VL_PAG_AB,0) VL_PAG_AB, "
                SqlText = SqlText & "       NVL(P.VL_PAG_AB_JUROS, 0) VL_JUROS, "
                SqlText = SqlText & "       NVL(P.VL_PAG_AB, 0) + NVL(P.VL_PAG_AB_JUROS, 0) VL_PAG_AB_JUROS, "
        End Select

        SqlText = SqlText & "       NVL(CM.QT_KG_A_FIXAR,0) QT_KG_A_FIXAR, "
        SqlText = SqlText & "       NVL(CM.VL_NF_A_FIXAR,0) VL_NF_A_FIXAR, "
        SqlText = SqlText & "       ROUND((DECODE(TN.IC_TIPO_PRECO_FIXO, 'S', "
        SqlText = SqlText & "                     N.VL_NEGOCIACAO / TU.QT_FATOR, "
        SqlText = SqlText & "                     DECODE(TN.IC_DOLAR, 'S', "
        SqlText = SqlText & "                            N.VL_NEGOCIACAO / TU.QT_FATOR * " & VlDolar & ", "
        SqlText = SqlText & "                            DECODE(TN.IC_BOLSA, 'S', "
        SqlText = SqlText & "                                   DECODE(TN.IC_BOLSA_OPERACAO, '+', "
        SqlText = SqlText & "                                          (" & VlBolsa & " + N.VL_NEGOCIACAO) / 1000 * " & VlDolar & ", "
        SqlText = SqlText & "                                          DECODE(TN.IC_BOLSA_OPERACAO, '-', "
        SqlText = SqlText & "                                                 (" & VlBolsa & " - N.VL_NEGOCIACAO) / 1000 * " & VlDolar & ", "
        SqlText = SqlText & "                                                 DECODE(TN.IC_BOLSA_OPERACAO, '*', "
        SqlText = SqlText & "                                                        (" & VlBolsa & " * N.VL_NEGOCIACAO) / 1000 * " & VlDolar & ", "
        SqlText = SqlText & "                                                        DECODE(TN.IC_BOLSA_OPERACAO, '/', "
        SqlText = SqlText & "                                                               (" & VlBolsa & " / N.VL_NEGOCIACAO) / 1000 * " & VlDolar & ", "
        SqlText = SqlText & "                                                               0)))), "
        SqlText = SqlText & "                                   0))) / "
        SqlText = SqlText & "             (1 - ((N.PC_ALIQ_ICMS + FUN.VL_TAXA) / 100)) * (1 - (FUN.VL_TAXA / 100))) * NVL(CM.QT_KG_A_FIXAR,0), 2) VL_QT_A_FIXAR, "
        SqlText = SqlText & "       0 VL_CREDITO_GARANTIA, "
        SqlText = SqlText & "       0 VL_CREDITO_PROVISORIO, "
        SqlText = SqlText & "       0 VL_CREDITO_TOTAL, 0 VL_GARANTIA, "
        SqlText = SqlText & "       N.DT_NEGOCIACAO DT_CONTRATO, N.DT_PRAZO_FIXACAO, N.VL_NEGOCIACAO VL_CONTRATO, "
        SqlText = SqlText & "       'N' IC_MASTER, 0 VL_ICMS_ABERTO, "
        SqlText = SqlText & "       0  vl_hipoteca, 0 vl_promissoria, 0 vl_cpr, 0 vl_ctr_fianca, "
        SqlText = SqlText & "       null dt_hipoteca, null dt_promissoria, null dt_cpr,null  dt_ctr_fianca,  "
        SqlText = SqlText & "       decode(cp.cd_safra,0,20,1,21,2,22,3,23,4,24,5,25,cp.cd_safra) as cd_safra "
        SqlText = SqlText & "FROM SOF.TIPO_NEGOCIACAO TN, "
        SqlText = SqlText & "     SOF.FILIAL FIL, "
        SqlText = SqlText & "     SOF.FORNECEDOR F, "
        SqlText = SqlText & "     SOF.FUNRURAL FUN, "
        SqlText = SqlText & "     SOF.FORNECEDOR REP, "
        SqlText = SqlText & "     SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & SqlText_Exposure            '>>> PARA O FILTRO EXPOSURE
        SqlText = SqlText & "     SOF.NEGOCIACAO N, "
        SqlText = SqlText & "     SOF.TIPO_UNIDADE TU, "
        SqlText = SqlText & "     (SELECT CM.CD_CONTRATO_PAF, CM.SQ_NEGOCIACAO, "
        SqlText = SqlText & "             SUM(CM.QT_KG_A_FIXAR) QT_KG_A_FIXAR, "
        SqlText = SqlText & "             SUM(CM.VL_A_FIXAR) VL_NF_A_FIXAR "
        SqlText = SqlText & "      FROM SOF.CTR_PAF_NEG_MOVIMENTACAO CM, "
        SqlText = SqlText & "           sof.contrato_paf cp "
        SqlText = SqlText & "      WHERE (CM.QT_KG_A_FIXAR <> 0 OR CM.VL_A_FIXAR <> 0) and "
        SqlText = SqlText & "            cm.cd_contrato_paf = cp.cd_contrato_paf "

        If CdForn <> -1 Then
            If IcTitular = True Then
                SqlText = SqlText & "   and cp.CD_REPASSADOR = " & CdForn & " "
            Else
                SqlText = SqlText & "   and cp.cd_fornecedor = " & CdForn & " "
            End If
        End If

        If IcSafra = True Then
            SqlText = SqlText & "      and  cp.cd_safra in (" & CdSafra & ") "
        End If

        SqlText = SqlText & "      GROUP BY CM.CD_CONTRATO_PAF, CM.SQ_NEGOCIACAO) CM, "
        SqlText = SqlText & "     (SELECT PN.CD_CONTRATO_PAF, PN.SQ_NEGOCIACAO, "

        Select Case True
            Case JurosCtrFix
                SqlText = SqlText & "             SUM(DECODE(N.ic_calcula_juros || tp.ic_calcula_juros, 'SS', "
                SqlText = SqlText & "                        ((DECODE(SIGN((TO_DATE('" & Date_to_Oracle(DataSistema) & "') - pA.dt_pagamento) - NVL(N.qt_dia_carencia_juros,0)), -1, "
                SqlText = SqlText & "                                 0, "
                SqlText = SqlText & "                                 ROUND(((TO_DATE('" & Date_to_Oracle(DataSistema) & "') - TO_DATE(pA.dt_pagamento)) - DECODE(N.ic_juros_apos_carencia, 'S', "
                SqlText = SqlText & "                                                                                               NVL(N.qt_dia_carencia_juros, 0), "
                SqlText = SqlText & "                                                                                               0)), 0)) "
                SqlText = SqlText & "                          * ((N.pc_taxa_juros / 100) / 30)) "
                SqlText = SqlText & "                         * pN.vl_a_fixar) "
                SqlText = SqlText & "                        + pN.vl_a_fixar, "
                SqlText = SqlText & "                        pN.vl_a_fixar)) vl_pag_ab_juros, "
                SqlText = SqlText & "             NVL(SUM(pN.vl_a_fixar), 0) vl_pag_ab "
                SqlText = SqlText & "      FROM SOF.PAG_NEG PN, "
                SqlText = SqlText & "           sof.contrato_paf cp, "
                SqlText = SqlText & "           sof.pagamentos pa, "
                SqlText = SqlText & "           sof.negociacao n, "
                SqlText = SqlText & "           sof.tipo_pagamento tp "
                SqlText = SqlText & "      WHERE PN.VL_A_FIXAR <> 0 and "
                SqlText = SqlText & "            pn.cd_contrato_paf = cp.cd_contrato_paf and "
                SqlText = SqlText & "            pa.sq_pagamento = pn.sq_pagamento and "
                SqlText = SqlText & "            PN.cd_contrato_paf = N.cd_contrato_paf AND "
                SqlText = SqlText & "            PN.sq_negociacao = N.sq_negociacao AND "
                SqlText = SqlText & "            PA.cd_tipo_pagamento = TP.cd_tipo_pagamento "

                If CdForn <> -1 Then
                    If IcTitular = True Then
                        SqlText = SqlText & "   AND cp.CD_REPASSADOR = " & CdForn & " "
                    Else
                        SqlText = SqlText & "   AND cp.cd_fornecedor = " & CdForn & " "
                    End If
                End If

                If IcSafra = True Then
                    SqlText = SqlText & "      and       cp.cd_safra in (" & CdSafra & ") "
                End If

                SqlText = SqlText & "      GROUP BY PN.CD_CONTRATO_PAF, PN.SQ_NEGOCIACAO) P "
            Case JurosNegRec
                SqlText = SqlText & "             nvl(cp.ic_juros_neg,'N') ic_juros_neg, "
                SqlText = SqlText & "             SUM(decode(cp.ic_calcula_juros,'N',pn.vl_a_fixar, decode(cp.ic_juros_neg,'S',decode(pa.cd_tipo_pagamento," & CdFormaPagJuros & ",pn.vl_a_fixar,0), "
                SqlText = SqlText & "                 DECODE(cp.ic_calcula_juros || tp.ic_calcula_juros, 'SS', "
                SqlText = SqlText & "                        ((DECODE(SIGN((TO_DATE('" & Date_to_Oracle(DataSistema) & "') - pA.dt_pagamento) - NVL(cp.qt_dia_carencia_juros,0)), -1, "
                SqlText = SqlText & "                                 0, "
                SqlText = SqlText & "                                 ROUND(((TO_DATE('" & Date_to_Oracle(DataSistema) & "') - TO_DATE(pA.dt_pagamento)) - DECODE(cp.ic_juros_apos_carencia, 'S', "
                SqlText = SqlText & "                                                                                               NVL(cp.qt_dia_carencia_juros, 0), "
                SqlText = SqlText & "                                                                                               0)), 0)) "
                SqlText = SqlText & "                          * ((cp.pc_taxa_juros / 100) / 30)) "
                SqlText = SqlText & "                         * pN.vl_a_fixar) "
                SqlText = SqlText & "                        + pN.vl_a_fixar, "
                SqlText = SqlText & "                        pN.vl_a_fixar)))) vl_pag_ab_juros, "
                SqlText = SqlText & "             NVL(SUM(decode(cp.ic_calcula_juros,'N', pn.vl_a_fixar, decode(cp.ic_juros_neg,'S', decode(pa.cd_tipo_pagamento," & CdFormaPagJuros & ", 0, pn.vl_a_fixar),pn.vl_a_fixar))), 0) vl_pag_ab "
                SqlText = SqlText & "      FROM SOF.PAG_NEG PN, "
                SqlText = SqlText & "           sof.contrato_paf cp, "
                SqlText = SqlText & "           sof.pagamentos pa, "
                SqlText = SqlText & "           sof.negociacao n, "
                SqlText = SqlText & "           sof.tipo_pagamento tp "
                SqlText = SqlText & "      WHERE PN.VL_A_FIXAR <> 0 and "
                SqlText = SqlText & "            pn.cd_contrato_paf = cp.cd_contrato_paf and "
                SqlText = SqlText & "            pa.sq_pagamento = pn.sq_pagamento and "
                SqlText = SqlText & "            PN.cd_contrato_paf = N.cd_contrato_paf AND "
                SqlText = SqlText & "            PN.sq_negociacao = N.sq_negociacao AND "
                SqlText = SqlText & "            PA.cd_tipo_pagamento = TP.cd_tipo_pagamento "

                If CdForn <> -1 Then
                    If IcTitular = True Then
                        SqlText = SqlText & " AND cp.CD_REPASSADOR = " & CdForn & " "
                    Else
                        SqlText = SqlText & " AND cp.cd_fornecedor = " & CdForn & " "
                    End If
                End If

                If IcSafra = True Then
                    SqlText = SqlText & " and cp.cd_safra in (" & CdSafra & ") "
                End If

                SqlText = SqlText & "      GROUP BY PN.CD_CONTRATO_PAF, PN.SQ_NEGOCIACAO, nvl(cp.ic_juros_neg,'N')) P "
            Case Else
                SqlText = SqlText & "             SUM(decode(pa.cd_tipo_pagamento," & CdFormaPagJuros & ",0,pn.vl_a_fixar)) VL_PAG_AB, "
                SqlText = SqlText & "             SUM(decode(pa.cd_tipo_pagamento," & CdFormaPagJuros & ",pn.vl_a_fixar,0)) VL_PAG_AB_JUROS "
                SqlText = SqlText & "      FROM SOF.PAG_NEG PN, "
                SqlText = SqlText & "           sof.contrato_paf cp, "
                SqlText = SqlText & "           sof.pagamentos pa "
                SqlText = SqlText & "      WHERE PN.VL_A_FIXAR <> 0 and "
                SqlText = SqlText & "            pn.cd_contrato_paf = cp.cd_contrato_paf and "
                SqlText = SqlText & "            pa.sq_pagamento = pn.sq_pagamento "

                If CdForn <> -1 Then
                    If IcTitular = True Then
                        SqlText = SqlText & "      AND       cp.CD_REPASSADOR = " & CdForn & " "
                    Else
                        SqlText = SqlText & "       AND      cp.cd_fornecedor = " & CdForn & " "
                    End If
                End If
                If IcSafra = True Then
                    SqlText = SqlText & "      and       cp.cd_safra in (" & CdSafra & ") "
                End If

                SqlText = SqlText & "      GROUP BY PN.CD_CONTRATO_PAF, PN.SQ_NEGOCIACAO) P "
        End Select

        SqlText = SqlText & "WHERE N.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF AND "

        If Trim(SqlText_Exposure) <> "" Then
            SqlText = SqlText & "      CP.CD_CONTRATO_PAF = FEX.CD_CONTRATO_PAF AND "
        End If

        SqlText = SqlText & "      N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO AND "
        SqlText = SqlText & "      CP.CD_FORNECEDOR = F.CD_FORNECEDOR AND "
        SqlText = SqlText & "      CP.CD_REPASSADOR = REP.CD_FORNECEDOR AND "
        SqlText = SqlText & "      REP.CD_FILIAL_ORIGEM = FIL.CD_FILIAL AND "
        SqlText = SqlText & "      F.CD_FUNRURAL = FUN.CD_FUNRURAL AND "
        SqlText = SqlText & "      N.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE AND "
        SqlText = SqlText & "      N.CD_CONTRATO_PAF = CM.CD_CONTRATO_PAF (+) AND "
        SqlText = SqlText & "      N.SQ_NEGOCIACAO = CM.SQ_NEGOCIACAO (+) AND "
        SqlText = SqlText & "      N.CD_CONTRATO_PAF = P.CD_CONTRATO_PAF (+) AND "
        SqlText = SqlText & "      N.SQ_NEGOCIACAO = P.SQ_NEGOCIACAO (+) AND "
        SqlText = SqlText & "      N.IC_STATUS = 'A' "

        If CdForn <> -1 Then
            If IcTitular = True Then
                SqlText = SqlText & "      AND       cp.CD_REPASSADOR = " & CdForn & " "
            Else
                SqlText = SqlText & "      AND       cp.cd_fornecedor = " & CdForn & " "
            End If
        End If

        If IcSafra = True Then
            SqlText = SqlText & "      and       cp.cd_safra in (" & CdSafra & ") "
        End If

        If CdFilial <> "" Then
            SqlText = SqlText & "AND F.cd_filial_origem in (" & CdFilial & ")"
        End If

        SqlText = SqlText & "UNION ALL "
        SqlText = SqlText & "SELECT 3 CD_TIPO, "
        SqlText = SqlText & "       'CONTRATO FIXO' ||decode(ic_gp,'S','-GP ','') NO_TIPO, "
        SqlText = SqlText & "       CF.CD_CONTRATO_PAF, "
        SqlText = SqlText & "       CF.SQ_NEGOCIACAO, "
        SqlText = SqlText & "       CF.SQ_CONTRATO_FIXO, "
        SqlText = SqlText & "       1 CD_TIPO_CONTRATO_FIXO, "
        SqlText = SqlText & "       'CONTRATO FIXO' NO_TIPO_CONTRATO_FIXO, "
        SqlText = SqlText & "       FIL.CD_FILIAL, "
        SqlText = SqlText & "       FIL.NO_FILIAL, "

        If IcTitular = True Then
            SqlText = SqlText & "       CP.CD_REPASSADOR, "
            SqlText = SqlText & "       REP.NO_RAZAO_SOCIAL NO_REPASSADOR, "
        Else
            SqlText = SqlText & "       F.CD_FORNECEDOR CD_REPASSADOR, "
            SqlText = SqlText & "       F.NO_RAZAO_SOCIAL NO_REPASSADOR, "
        End If

        If IcAgruparTitular = True Then
            SqlText = SqlText & "       CP.CD_REPASSADOR as CD_FORNECEDOR, "
            SqlText = SqlText & "       REP.NO_RAZAO_SOCIAL NO_FORNECEDOR, "
        Else
            SqlText = SqlText & "       F.CD_FORNECEDOR, "
            SqlText = SqlText & "       F.NO_RAZAO_SOCIAL NO_FORNECEDOR, "
        End If

        SqlText = SqlText & "       CF.DT_VENCIMENTO, "
        SqlText = SqlText & "       CF.QT_KGS, "
        SqlText = SqlText & "       CF.QT_CANCELADO, "
        SqlText = SqlText & "       CF.QT_KG_FIXO, "
        SqlText = SqlText & "       0 QT_A_FIXAR, "
        SqlText = SqlText & "       CF.VL_PAG_FIXO, "
        SqlText = SqlText & "       CF.VL_PAG_FIXO VL_PAG_AB, "

        If JurosNegRec = True Then
            SqlText = SqlText & "       nvl(p.vl_juros,0) vl_juros, "
            SqlText = SqlText & "       nvl(p.vl_juros,0) + cf.vl_pag_fixo vl_pag_ab_juros, "
        Else
            SqlText = SqlText & "       0 VL_JUROS, "
            SqlText = SqlText & "       CF.VL_PAG_FIXO VL_PAG_AB_JUROS, "
        End If

        SqlText = SqlText & "       CF.QT_KG_FIXO QT_KG_A_FIXAR, "
        SqlText = SqlText & "       CF.VL_NF_FIXO VL_NF_A_FIXAR, "
        SqlText = SqlText & "       decode(cf.qt_kgs - cf.qt_cancelado,0,0,round(CF.QT_KG_FIXO * (sof.fc_saldo_ctr_fix(cf.cd_contrato_paf ,cf.sq_negociacao ,cf.sq_contrato_fixo ) / "
        SqlText = SqlText & "                        (cf.qt_kgs - cf.qt_cancelado)),2)) VL_QT_A_FIXAR, "
        SqlText = SqlText & "       0 VL_CREDITO_GARANTIA, "
        SqlText = SqlText & "       0 VL_CREDITO_PROVISORIO, "
        SqlText = SqlText & "       0 VL_CREDITO_TOTAL, 0 VL_GARANTIA, "
        SqlText = SqlText & "       CF.DT_CONTRATO_FIXO DT_CONTRATO, TO_DATE('" & Date_to_Oracle(DataSistema) & "') DT_PRAZO_FIXACAO, CF.VL_UNITARIO VL_CONTRATO, "
        SqlText = SqlText & "       'N' IC_MASTER, "

        SqlText = SqlText & "      DECODE(CF.ic_inclui_icms_pag,'N',0, DECODE(cf.pc_aliq_icms, 0, "
        SqlText = SqlText & "              0, "
        SqlText = SqlText & "              DECODE((cf.qt_kgs - cf.qt_cancelado), cf.qt_kg_fixo, "
        SqlText = SqlText & "                     DECODE((((((cf.qt_kgs - cf.qt_cancelado) / cf.qt_kgs) * "
        SqlText = SqlText & "                               (cf.vl_total + cf.vl_icms)) + cf.vl_adendo "
        SqlText = SqlText & "                               + cf.vl_adendo_icms) - cf.vl_nf_fixo "
        SqlText = SqlText & "                              + cf.vl_nf_inss_fixo) / (1 - (fun.vl_taxa / 100)), 0, "
        SqlText = SqlText & "                            0, "
        SqlText = SqlText & "                            ROUND((((((cf.qt_kgs - cf.qt_cancelado) / cf.qt_kgs) "
        SqlText = SqlText & "                                      * (cf.vl_total + cf.vl_icms)) + cf.vl_adendo "
        SqlText = SqlText & "                                     + cf.vl_adendo_icms) - cf.vl_nf_fixo "
        SqlText = SqlText & "                                    + cf.vl_nf_inss_fixo) / (1 - (fun.vl_taxa / 100)) "
        SqlText = SqlText & "                                   * (cf.pc_aliq_icms / 100), 2)), 0))) VL_ICMS_ABERTO, "
        SqlText = SqlText & "       0  vl_hipoteca, 0 vl_promissoria, 0 vl_cpr, 0 vl_ctr_fianca, "
        SqlText = SqlText & "       null dt_hipoteca, null dt_promissoria, null dt_cpr,null  dt_ctr_fianca, "
        SqlText = SqlText & "       decode(cp.cd_safra,0,20,1,21,2,22,3,23,4,24,5,25,cp.cd_safra) as cd_safra "

        SqlText = SqlText & " FROM SOF.FILIAL FIL, "
        SqlText = SqlText & "     SOF.FORNECEDOR F, "
        SqlText = SqlText & "     SOF.FORNECEDOR REP, "
        SqlText = SqlText & "     SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & SqlText_Exposure            '>>> PARA O FILTRO EXPOSURE
        SqlText = SqlText & "     SOF.CONTRATO_FIXO CF, "
        SqlText = SqlText & "     sof.funrural fun "

        If JurosNegRec = True Then
            SqlText = SqlText & ",(SELECT NVL(SUM(PN.VL_FIXO * ((CP.PC_TAXA_JUROS/100/30) * "
            SqlText = SqlText & "               (TO_DATE('" & Date_to_Oracle(DataSistema) & "') - (P.DT_PAGAMENTO + DECODE(CP.IC_JUROS_APOS_CARENCIA, 'S',CP.QT_DIA_CARENCIA_JUROS,0))))),0) vl_juros, "
            SqlText = SqlText & "       cf.cd_contrato_paf, "
            SqlText = SqlText & "       cf.sq_negociacao, "
            SqlText = SqlText & "       cf.sq_contrato_fixo "
            SqlText = SqlText & "FROM SOF.CONTRATO_PAF CP, "
            SqlText = SqlText & "     SOF.CONTRATO_FIXO CF, "
            SqlText = SqlText & "     SOF.PAG_NEG_CTR_FIX PN, "
            SqlText = SqlText & "     SOF.PAGAMENTOS P, "
            SqlText = SqlText & "     SOF.TIPO_PAGAMENTO TP "
            SqlText = SqlText & "WHERE CP.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF AND "
            SqlText = SqlText & "      CF.cd_contrato_paf = PN.cd_contrato_paf AND "
            SqlText = SqlText & "      CF.sq_negociacao = PN.sq_negociacao AND "
            SqlText = SqlText & "      CF.sq_contrato_fixo = PN.sq_contrato_fixo AND "
            SqlText = SqlText & "      PN.SQ_PAGAMENTO = P.SQ_PAGAMENTO AND "
            SqlText = SqlText & "      P.CD_TIPO_PAGAMENTO = TP.CD_TIPO_PAGAMENTO AND "
            SqlText = SqlText & "      CF.IC_STATUS = 'A' AND "
            SqlText = SqlText & "      CP.IC_CALCULA_JUROS = 'S' AND "
            SqlText = SqlText & "      CP.IC_JUROS_NEG = 'N' AND "
            SqlText = SqlText & "      TP.IC_CALCULA_JUROS = 'S' AND "
            SqlText = SqlText & "      CF.DT_FINAL_JUROS IS NULL AND "
            SqlText = SqlText & "      (P.DT_PAGAMENTO + CP.QT_DIA_CARENCIA_JUROS) < TO_DATE('" & Date_to_Oracle(DataSistema) & "') "

            If CdForn <> -1 Then
                If IcTitular = True Then
                    SqlText = SqlText & "      AND       cp.CD_REPASSADOR = " & CdForn & " "
                Else
                    SqlText = SqlText & "      AND       cp.cd_fornecedor = " & CdForn & " "
                End If
            End If

            If IcSafra = True Then
                SqlText = SqlText & "      and       cp.cd_safra in (" & CdSafra & ") "
            End If

            SqlText = SqlText & "group by cf.cd_contrato_paf, cf.sq_negociacao, cf.sq_contrato_fixo) p "
        End If

        SqlText = SqlText & "WHERE CF.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF AND "

        If Trim(SqlText_Exposure) <> "" Then
            SqlText = SqlText & "      CP.CD_CONTRATO_PAF = FEX.CD_CONTRATO_PAF AND "
        End If

        SqlText = SqlText & "      CP.CD_FORNECEDOR = F.CD_FORNECEDOR AND "
        SqlText = SqlText & "      CP.CD_REPASSADOR = REP.CD_FORNECEDOR AND "
        SqlText = SqlText & "      REP.CD_FILIAL_ORIGEM = FIL.CD_FILIAL AND "
        SqlText = SqlText & "      f.cd_funrural = fun.cd_funrural AND "
        SqlText = SqlText & "      CF.IC_STATUS = 'A' "

        If CdForn <> -1 Then
            If IcTitular = True Then
                SqlText = SqlText & "     AND        cp.CD_REPASSADOR = " & CdForn & " "
            Else
                SqlText = SqlText & "      AND       cp.cd_fornecedor = " & CdForn & " "
            End If
        End If

        If IcSafra = True Then
            SqlText = SqlText & "      and       cp.cd_safra in (" & CdSafra & ") "
        End If

        If CdFilial <> "" Then
            SqlText = SqlText & "AND F.cd_filial_origem in (" & CdFilial & ")"
        End If

        If JurosNegRec = True Then
            SqlText = SqlText & "AND cf.cd_contrato_paf = p.cd_contrato_paf (+) and "
            SqlText = SqlText & "       cf.sq_negociacao = p.sq_negociacao (+) and "
            SqlText = SqlText & "       cf.sq_contrato_fixo = p.sq_contrato_fixo (+) "
        End If

        SqlText = SqlText & "UNION ALL "
        SqlText = SqlText & "SELECT to_number(4 || CD.cd_confissao_divida_modalidade) cd_tipo, "
        SqlText = SqlText & "       'RECUPERAÇÃO CREDITO' no_tipo,  "
        SqlText = SqlText & "       CD.SQ_CONFISSAO_DIVIDA cd_contrato_paf, "
        SqlText = SqlText & "       decode(cdm.ic_provissoria,'S',1, CDP.nu_parcela) sq_negociacao, "
        SqlText = SqlText & "       -1 sq_contrato_fixo,  "
        SqlText = SqlText & "       CD.cd_confissao_divida_modalidade  cd_tipo_contrato_fixo, "
        SqlText = SqlText & "       CDM.NO_CONFISSAO_DIVIDA_MODALIDADE || decode(cdp.ic_cacau ,'S',' - Cacau')|| decode(cdp.ic_moeda  ,'S',' - Dinheiro')|| decode(cdp.ic_outros ,'S',' - Outros') as no_tipo_contrato_fixo,  "
        SqlText = SqlText & "       fil.cd_filial,  "
        SqlText = SqlText & "       fil.no_filial, "

        If IcTitular = True Then
            SqlText = SqlText & "       nvl(r.cd_fornecedor, f.cd_fornecedor) cd_repassador, "
            SqlText = SqlText & "       nvl(r.no_razao_social, f.no_razao_social) no_repassador, "
        Else
            SqlText = SqlText & "       F.CD_FORNECEDOR CD_REPASSADOR, "
            SqlText = SqlText & "       F.NO_RAZAO_SOCIAL NO_REPASSADOR, "
        End If

        If IcAgruparTitular = True Then
            SqlText = SqlText & "       R.CD_REPASSADOR as CD_FORNECEDOR, "
            SqlText = SqlText & "       F.NO_RAZAO_SOCIAL NO_FORNECEDOR, "
        Else
            SqlText = SqlText & "       F.CD_FORNECEDOR, "
            SqlText = SqlText & "       F.NO_RAZAO_SOCIAL NO_FORNECEDOR, "
        End If

        SqlText = SqlText & "       decode(cdp.dt_vencimento,null, sysdate-1,cdp.dt_vencimento) as dt_vencimento, "
        SqlText = SqlText & "       decode(cdm.ic_provissoria,'S',cd.qt_original,decode(cdp.ic_cacau ,'S',cdp.qt_item_parcela,0)) qt_kgs,  "
        SqlText = SqlText & "       0 qt_cancelado,  "
        SqlText = SqlText & "       0 qt_kg_fixo,  "
        SqlText = SqlText & "       0 qt_a_fixar, "
        SqlText = SqlText & "       round(decode(cdm.ic_provissoria,'S',cd.vl_original,nvl(DECODE(cdp.ic_cacau, 'S',cdp.qt_item_parcela * " & VlCompra & "/15,cdp.vl_parcela), 0)),2) vl_pag_fixo,  "
        SqlText = SqlText & "       round(decode(cdm.ic_provissoria,'S',cd.vl_original,nvl(DECODE (cdp.ic_cacau, 'S',cdp.qt_item_parcela * " & VlCompra & "/15 ,cdp.vl_parcela), 0)),2) vl_pag_ab,  "
        SqlText = SqlText & "       round(decode(nvl(cdp.ic_situacao,'A'),'A',   DECODE (cdm.ic_provissoria,'S', cd.vl_original,"
        SqlText = SqlText & "             nvl(DECODE (cdp.ic_cacau,"
        SqlText = SqlText & "                     'S', cdp.qt_item_parcela * " & VlCompra & " / 15,cdp.Vl_Parcela), 0) "
        SqlText = SqlText & "            )*(((sysdate- nvl(cd.dt_cobra_juros,sysdate))*(nvl(cd.PC_JUROS_AO_MES,0)/30)/100)),0),2) vl_juros, "
        SqlText = SqlText & "       round(decode(nvl(cdp.ic_situacao,'A'),'A',   DECODE (cdm.ic_provissoria,'S', cd.vl_original,"
        SqlText = SqlText & "             nvl(DECODE (cdp.ic_cacau,"
        SqlText = SqlText & "                     'S', cdp.qt_item_parcela * " & VlCompra & " / 15,cdp.Vl_Parcela), 0) "
        SqlText = SqlText & "            )*(1+((sysdate- nvl(cd.dt_cobra_juros,sysdate))*(nvl(cd.PC_JUROS_AO_MES,0)/30)/100)),0),2) vl_pag_ab_juros, "
        SqlText = SqlText & "       0 qt_kg_a_fixar, "
        SqlText = SqlText & "       0 vl_nf_a_fixar,  "
        SqlText = SqlText & "       0 vl_qt_a_fixar, "
        SqlText = SqlText & "       0 vl_credito_garantia,  "
        SqlText = SqlText & "       0 vl_credito_provisorio,  "
        SqlText = SqlText & "       0 vl_credito_total, "
        SqlText = SqlText & "       0 vl_garantia,  "
        SqlText = SqlText & "       decode(cdm.ic_provissoria,'S',cd.dt_confissao_divida ,CDP.dt_lancamento) dt_contrato, "
        SqlText = SqlText & "       TO_DATE ('" & Date_to_Oracle(DataSistema) & "') dt_prazo_fixacao,  "
        SqlText = SqlText & "       0 vl_contrato, "
        SqlText = SqlText & "       'N' IC_MASTER, 0 VL_ICMS_ABERTO, "
        SqlText = SqlText & "       0  vl_hipoteca, 0 vl_promissoria, 0 vl_cpr, 0 vl_ctr_fianca, "
        SqlText = SqlText & "       null dt_hipoteca, null dt_promissoria, null dt_cpr,null  dt_ctr_fianca, "
        SqlText = SqlText & "       decode(cp.cd_safra,0,20,1,21,2,22,3,23,4,24,5,25,cp.cd_safra) as cd_safra "
        SqlText = SqlText & "FROM SOF.CONFISSAO_DIVIDA_PARCELA CDP, "
        SqlText = SqlText & "     SOF.CONFISSAO_DIVIDA CD, "
        SqlText = SqlText & "     SOF.CONFISSAO_DIVIDA_MODALIDADE CDM, "
        SqlText = SqlText & "     SOF.FORNECEDOR F, "
        SqlText = SqlText & "     SOF.FORNECEDOR R, "
        SqlText = SqlText & "     SOF.FILIAL FIL, "
        'A SAFRA DA RECUPERAÇÃO É A SAFRA DO CONTRATO MAIS ANTIGO

        SqlText = SqlText & " (SELECT sq_confissao_divida , MIN(cd_safra) as cd_safra FROM "
        SqlText = SqlText & " (SELECT c_cpc.sq_confissao_divida , MIN(c_cp.cd_safra) as cd_safra "
        SqlText = SqlText & "  FROM sof.contrato_paf_cancelado c_cpc, sof.contrato_paf c_cp "
        SqlText = SqlText & " WHERE c_cpc.cd_contrato_paf =c_cp.cd_contrato_paf  "
        SqlText = SqlText & "    and c_cpc.sq_confissao_divida is not null "
        SqlText = SqlText & " group by c_cpc.sq_confissao_divida  "
        SqlText = SqlText & " union SELECT pcp.sq_confissao_divida , "
        SqlText = SqlText & "                 MIN (cp.cd_safra"
        SqlText = SqlText & "                     ) AS cd_safra "
        SqlText = SqlText & "  FROM sof.pag_ctr_paf pcp, sof.pag_neg_ctr_fix pncf, sof.pagamentos p, sof.contrato_paf cp "
        SqlText = SqlText & " WHERE pcp.cd_contrato_paf = pncf.cd_contrato_paf(+) "
        SqlText = SqlText & "   AND pcp.sq_pagamento = pncf.sq_pagamento(+) "
        SqlText = SqlText & "   AND pcp.sq_pag_ctr_paf = pncf.sq_pag_ctr_paf(+) "
        SqlText = SqlText & "   AND pcp.sq_pagamento = p.sq_pagamento "
        SqlText = SqlText & "   and pcp.cd_contrato_paf =cp.cd_contrato_paf  "
        SqlText = SqlText & "   AND p.sq_conf_div_ativo_venda IS NULL "
        SqlText = SqlText & "   AND pcp.ic_confissao_divida_estorno = 'S' "
        SqlText = SqlText & "GROUP BY  pcp.sq_confissao_divida ) GROUP BY sq_confissao_divida) cp "

        SqlText = SqlText & "WHERE CD.SQ_CONFISSAO_DIVIDA = CDP.SQ_CONFISSAO_DIVIDA (+) AND "
        SqlText = SqlText & "      CDM.CD_CONFISSAO_DIVIDA_MODALIDADE = CD.CD_CONFISSAO_DIVIDA_MODALIDADE AND "
        SqlText = SqlText & "      CD.cd_fornecedor = F.cd_fornecedor AND "
        SqlText = SqlText & "      F.cd_filial_origem = FIL.cd_filial AND "
        SqlText = SqlText & "      f.cd_repassador = r.cd_fornecedor (+) and cd.sq_confissao_divida=cp.sq_confissao_divida (+) AND "
        SqlText = SqlText & "      CDP.IC_SITUACAO (+) = 'A'  AND cd.ic_status = 'A' "

        If CdForn <> -1 Then
            If IcTitular = True Then
                SqlText = SqlText & "     AND        nvl(r.cd_fornecedor, f.cd_fornecedor) = " & CdForn & " "
            Else
                SqlText = SqlText & "      AND       CD.CD_FORNECEDOR = " & CdForn & " "
            End If
        End If

        If IcSafra = True Then
            SqlText = SqlText & "      and       cp.cd_safra in (" & CdSafra & ") "
        End If

        If CdModalidadeRecuperacaoCredito <> "" Then
            SqlText = SqlText & " and cd.CD_CONFISSAO_DIVIDA_MODALIDADE not in (" & CdModalidadeRecuperacaoCredito & ")"
        End If

        If CdFilial <> "" Then
            SqlText = SqlText & "AND F.cd_filial_origem in (" & CdFilial & ")"
        End If

        Gera_Rs_Posicao_Fornecedor = DBQuery(SqlText)

        If Gera_Rs_Posicao_Fornecedor.Rows.Count <> 0 And Not RsCredito Is Nothing Then
            SqlText = "SELECT lc.cd_fornecedor, tg.no_tipo_garantia, tg.ic_provisoria, "
            SqlText = SqlText & "       lc.dt_limite_credito, lc.dt_revisao, lc.dt_validade, "
            SqlText = SqlText & "       decode(LC.ic_moeda_credito,'S',lc.vl_credito * 4 * " & VlCompra & ",'D',lc.vl_credito * " & VlDolar & ",'R',lc.vl_credito) vl_limite_credito, "
            SqlText = SqlText & "       lc.vl_credito qt_limite_credito, "
            SqlText = SqlText & "       g.vl_garantia, g.ic_moeda_garantia, null dt_garantia_revisao, "
            SqlText = SqlText & "       g.dt_garantia_validade, " & VlDolar & " VL_TAXA_US, " & VlCompra & "  VL_ARROBA, "
            SqlText = SqlText & "  decode(lc.vl_credito,'S','Sacos','D','US$','R','R$') TIPO_CREDITO "
            SqlText = SqlText & "FROM   sof.limite_credito lc, sof.tipo_garantia tg, sof.fornecedor f, sof.garantia g "
            SqlText = SqlText & "WHERE  g.cd_tipo_garantia = tg.cd_tipo_garantia (+) "
            SqlText = SqlText & "AND    lc.cd_fornecedor = f.cd_fornecedor  and lc.sq_garantia =g.sq_garantia (+) "
            SqlText = SqlText & "AND    lc.cd_tipo_status = 'A' "

            If CdForn <> -1 Then
                If IcTitular = False Then
                    SqlText = SqlText & "         and lc.cd_fornecedor = " & CdForn & " "
                End If
            End If

            If CdFilial <> "" Then
                SqlText = SqlText & "AND F.cd_filial_origem in (" & CdFilial & ")"
            End If

            RsCredito = DBQuery(SqlText)
        End If

        If Gera_Rs_Posicao_Fornecedor.Rows.Count <> 0 And Not RsBonus Is Nothing Then
            SqlText = "SELECT f.cd_filial_origem, fil.no_filial, cp.cd_fornecedor, f.no_razao_social, "
            SqlText = SqlText & "       bcf.cd_contrato_paf, bcf.sq_negociacao, bcf.sq_contrato_fixo, "
            SqlText = SqlText & "       bcf.vl_unitario_bonus, bcf.qt_fator_bonus, bp.no_bonus_padrao, "
            SqlText = SqlText & "       bcf.qt_umidade_media, bcf.pc_sujidade_media, bcf.qt_peso_amendoa_media, "
            SqlText = SqlText & "       bcf.qt_mofo_media, bcf.qt_fumaca_media, bcf.qt_ardosia_media, "
            SqlText = SqlText & "       bcf.qt_achatada_media, bcf.ic_tipo_cacau_media, bcf.dt_concessao, "
            SqlText = SqlText & "       2.3 vl_taxa_us, m.nu_nf, m.dt_movimentacao, tm.no_tipo_movimentacao, "
            SqlText = SqlText & "       cm.qt_kg_fixo, m.sq_movimentacao, cm.sq_ctr_paf_movimentacao, "
            SqlText = SqlText & "       cm.sq_ctr_paf_neg_movimentacao, cm.sq_ctr_paf_neg_ctr_fix_mov, "
            SqlText = SqlText & "       cm.sq_movimentacao_cessao_direito "
            SqlText = SqlText & "FROM sof.bonus_contrato_fixo bcf, "
            SqlText = SqlText & "     sof.bonus_padrao bp, "
            SqlText = SqlText & "     sof.ctr_paf_neg_ctr_fix_mov cm, "
            SqlText = SqlText & "     sof.contrato_paf cp, "
            SqlText = SqlText & "     sof.filial fil, "
            SqlText = SqlText & "     sof.fornecedor f, "
            SqlText = SqlText & "     sof.movimentacao m, "
            SqlText = SqlText & "     sof.tipo_movimentacao tm, "
            SqlText = SqlText & "     sof.municipio munic "
            SqlText = SqlText & "WHERE bp.cd_bonus_padrao = bcf.cd_bonus_padrao AND "
            SqlText = SqlText & "      cm.sq_movimentacao = bcf.sq_movimentacao AND "
            SqlText = SqlText & "      cm.sq_movimentacao_cessao_direito = bcf.sq_movimentacao_cessao_direito AND "
            SqlText = SqlText & "      cm.cd_contrato_paf = bcf.cd_contrato_paf AND "
            SqlText = SqlText & "      cm.sq_ctr_paf_movimentacao = bcf.sq_ctr_paf_movimentacao AND "
            SqlText = SqlText & "      cm.sq_negociacao = bcf.sq_negociacao AND "
            SqlText = SqlText & "      cm.sq_ctr_paf_neg_movimentacao = bcf.sq_ctr_paf_neg_movimentacao AND "
            SqlText = SqlText & "      cm.sq_contrato_fixo = bcf.sq_contrato_fixo AND "
            SqlText = SqlText & "      cm.sq_ctr_paf_neg_ctr_fix_mov = bcf.sq_ctr_paf_neg_ctr_fix_mov AND "
            SqlText = SqlText & "      cp.cd_contrato_paf = cm.cd_contrato_paf AND "
            SqlText = SqlText & "      f.cd_fornecedor = cp.cd_fornecedor AND "
            SqlText = SqlText & "      fil.cd_filial = f.cd_filial_origem AND "
            SqlText = SqlText & "      m.sq_movimentacao = cm.sq_movimentacao AND "
            SqlText = SqlText & "      m.cd_tipo_movimentacao = tm.cd_tipo_movimentacao AND "
            SqlText = SqlText & "      f.cd_municipio = munic.cd_municipio AND "
            SqlText = SqlText & "      munic.cd_uf <> 'EX' AND "
            SqlText = SqlText & "      bcf.ic_pago = 'N' "

            If CdForn <> -1 Then
                If IcTitular = False Then
                    SqlText = SqlText & "         and f.cd_fornecedor = " & CdForn & " "
                End If
            End If

            If IcSafra = True Then
                SqlText = SqlText & "      and       cp.cd_safra in (" & CdSafra & ") "
            End If

            If CdFilial <> "" Then
                SqlText = SqlText & "AND F.cd_filial_origem in (" & CdFilial & ")"
            End If

            RsBonus = DBQuery(SqlText)
        End If
    End Function

    Public Function Gera_RS_Cc_Forn(ByVal CodForn As Long, _
                                    ByVal Dt1 As Date, _
                                    ByVal Dt2 As Date, _
                                    ByVal Sintetico As Boolean, _
                                    ByVal Rep As Boolean) As DataTable
        Dim oData As New DataTable
        Dim oDataC As New DataTable
        Dim RsParDes As New DataTable
        Dim RsDes As New DataTable
        Dim FilO As Integer
        Dim Cod_Conciliacao_ICMS As Integer
        Dim SqlText As String
        Dim mVla As Double
        Dim totkgc As Double
        Dim totvlc As Double
        Dim totkgtr As Double
        Dim totkgar As Double
        Dim totkgfr As Double
        Dim totvlcp As Double
        Dim totvlap As Double
        Dim totvlad As Double
        Dim TotVlNF As Double
        Dim TotVlNFFunrural As Double
        Dim TotVlCtrINSS As Double
        Dim vl As Double
        Dim VlINSS As Double
        Dim Valido As Boolean
        Dim iCont As Integer
        Dim oRow As DataRow

        Const Contrato As Integer = 1
        Const Pagamento As Integer = 2
        Const Movimentacao As Integer = 3

        With oData.Columns
            .Add("DATA").DataType = System.Type.GetType("System.DateTime")
            .Add("NOMETMOV").DataType = System.Type.GetType("System.String")
            .Add("NUMCTR").DataType = System.Type.GetType("System.Int32")
            .Add("KGS").DataType = System.Type.GetType("System.Int32")
            .Add("VLUNIT").DataType = System.Type.GetType("System.Double")
            .Add("VLTOTAL").DataType = System.Type.GetType("System.Double")
            .Add("CODFIL").DataType = System.Type.GetType("System.Int32")
            .Add("NF").DataType = System.Type.GetType("System.String")
            .Add("KGLNF").DataType = System.Type.GetType("System.Int32")
            .Add("UMIDADE").DataType = System.Type.GetType("System.Int32")
            .Add("TIPO").DataType = System.Type.GetType("System.Int32")
            .Add("KGLIQ").DataType = System.Type.GetType("System.Int32")
            .Add("KGFIX").DataType = System.Type.GetType("System.Int32")
            .Add("VLC").DataType = System.Type.GetType("System.Double")
            .Add("VLA").DataType = System.Type.GetType("System.Double")
            .Add("TPPRECO").DataType = System.Type.GetType("System.Int32")
            .Add("TP").DataType = System.Type.GetType("System.Int32")
            .Add("CD_FILIAL_ORIGEM").DataType = System.Type.GetType("System.Int32")
            .Add("cd_fornecedor").DataType = System.Type.GetType("System.Int32")
            .Add("no_fornecedor").DataType = System.Type.GetType("System.String")
            .Add("cd_repassador").DataType = System.Type.GetType("System.Int32")
            .Add("no_repassador").DataType = System.Type.GetType("System.String")
            .Add("SQ_NEGOCIACAO").DataType = System.Type.GetType("System.Int32")
            .Add("SQ_CONTRATO_FIXO").DataType = System.Type.GetType("System.Int32")
            .Add("VL_NF").DataType = System.Type.GetType("System.Double")
            .Add("VL_NF_FUNRURAL").DataType = System.Type.GetType("System.Double")
            .Add("VL_CTR_INSS").DataType = System.Type.GetType("System.Double")
            .Add("KGDES").DataType = System.Type.GetType("System.Int32")
        End With

        mVla = 0
        totkgc = 0
        totvlc = 0
        totkgtr = 0
        totkgar = 0
        totkgfr = 0
        totvlcp = 0
        totvlap = 0
        totvlad = 0
        TotVlNF = 0
        TotVlCtrINSS = 0
        TotVlNFFunrural = 0

        SqlText = "SELECT CD_FILIAL_ORIGEM FROM SOF.FORNECEDOR WHERE CD_FORNECEDOR = " & CodForn
        FilO = DBQuery_ValorUnico(SqlText)

        SqlText = "SELECT CD_CONCILIACAO_ICMS FROM SOF.PARAMETRO"
        Cod_Conciliacao_ICMS = DBQuery_ValorUnico(SqlText)

        'Contrato Fixo
        SqlText = "SELECT CF.QT_KGS," & _
                         "CF.VL_TOTAL," & _
                         "CF.DT_CONTRATO_FIXO," & _
                         "CF.CD_CONTRATO_PAF," & _
                         "CF.SQ_NEGOCIACAO," & _
                         "CF.SQ_CONTRATO_FIXO," & _
                         "CF.VL_UNITARIO," & _
                         "CP.CD_FORNECEDOR," & _
                         "F.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "F.CD_FILIAL_ORIGEM," & _
                         "NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) CD_REPASSADOR," & _
                         "NVL(REP.NO_RAZAO_SOCIAL, F.NO_RAZAO_SOCIAL) NO_REPASSADOR," & _
                         "CF.VL_ICMS," & _
                         "CF.VL_INSS" & _
                  " FROM SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR REP," & _
                        "SOF.CONTRATO_FIXO CF," & _
                        "SOF.CONTRATO_PAF CP" & _
                  " WHERE CP.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                    " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) = REP.CD_FORNECEDOR" & _
                    " AND CF.IC_STATUS <> 'E'"
        If Rep = True Then
            SqlText = SqlText & " AND NVL(REP.CD_FORNECEDOR, F.CD_FORNECEDOR)   = " & CodForn
        Else
            SqlText = SqlText & " AND CP.CD_FORNECEDOR = " & CodForn
        End If
        SqlText = SqlText & " AND CF.DT_CONTRATO_FIXO <= " & QuotedStr(Date_to_Oracle(Dt2))
        oDataC = DBQuery(SqlText)

        If oDataC.Rows.Count > 0 Then
            For iCont = 0 To oDataC.Rows.Count - 1
                If oDataC.Rows(iCont).Item("DT_CONTRATO_FIXO") < Dt1 Then
                    totkgc = totkgc + oDataC.Rows(iCont).Item("QT_KGS")
                    totvlc = totvlc + oDataC.Rows(iCont).Item("VL_TOTAL") + oDataC.Rows(iCont).Item("VL_ICMS")
                    TotVlCtrINSS = TotVlCtrINSS + oDataC.Rows(iCont).Item("VL_INSS")
                Else
                    oRow = oData.NewRow
                    oRow.Item("DATA") = oDataC.Rows(iCont).Item("DT_CONTRATO_FIXO")
                    oRow.Item("NOMETMOV") = "CONTRATO"
                    oRow.Item("NUMCTR") = oDataC.Rows(iCont).Item("CD_CONTRATO_PAF")
                    oRow.Item("KGS") = oDataC.Rows(iCont).Item("QT_KGS")
                    oRow.Item("VLUNIT") = oDataC.Rows(iCont).Item("VL_UNITARIO")
                    oRow.Item("VLTOTAL") = oDataC.Rows(iCont).Item("VL_TOTAL") + oDataC.Rows(iCont).Item("VL_ICMS")
                    oRow.Item("TPPRECO") = 1
                    oRow.Item("TP") = Contrato
                    oRow.Item("CD_FILIAL_ORIGEM") = oDataC.Rows(iCont).Item("CD_FILIAL_ORIGEM")
                    oRow.Item("CD_FORNECEDOR") = oDataC.Rows(iCont).Item("CD_FORNECEDOR")
                    oRow.Item("NO_FORNECEDOR") = oDataC.Rows(iCont).Item("NO_FORNECEDOR")
                    oRow.Item("CD_REPASSADOR") = oDataC.Rows(iCont).Item("CD_REPASSADOR")
                    oRow.Item("NO_REPASSADOR") = oDataC.Rows(iCont).Item("NO_REPASSADOR")
                    oRow.Item("SQ_NEGOCIACAO") = oDataC.Rows(iCont).Item("SQ_NEGOCIACAO")
                    oRow.Item("SQ_CONTRATO_FIXO") = oDataC.Rows(iCont).Item("SQ_CONTRATO_FIXO")
                    oRow.Item("VL_CTR_INSS") = oDataC.Rows(iCont).Item("VL_INSS")
                    If Not oRow Is Nothing Then oData.Rows.Add(oRow)
                End If
            Next
        End If

        'Pagamentos
        SqlText = "SELECT PAG.DT_PAGAMENTO," & _
                         "PAG.VL_PAGAMENTO," & _
                         "PAG.VL_DOLAR," & _
                         "PAG.CD_FORNECEDOR," & _
                         "F.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) CD_REPASSADOR," & _
                         "F.CD_FILIAL_ORIGEM," & _
                         "NVL(REP.NO_RAZAO_SOCIAL, F.NO_RAZAO_SOCIAL) NO_REPASSADOR," & _
                         "TP.NO_TIPO_PAGAMENTO," & _
                         "PAG.SQ_PAGAMENTO," & _
                         "TP.CD_TIPO_PAGAMENTO" & _
                  " FROM SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR REP," & _
                        "SOF.PAGAMENTOS PAG," & _
                        "SOF.TIPO_PAGAMENTO TP" & _
                  " WHERE PAG.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND PAG.CD_TIPO_PAGAMENTO = TP.CD_TIPO_PAGAMENTO" & _
                    " AND NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) = REP.CD_FORNECEDOR"
        If Rep = True Then
            SqlText = SqlText & " AND NVL(REP.CD_FORNECEDOR, F.CD_FORNECEDOR)  = " & CodForn
        Else
            SqlText = SqlText & " AND F.CD_FORNECEDOR = " & CodForn
        End If
        SqlText = SqlText & " AND PAG.DT_PAGAMENTO <= " & QuotedStr(Date_to_Oracle(Dt2))

        'EXCLUO AS LIQUIDAÇÕES
        SqlText = SqlText & " AND PAG.CD_FORMA_PAGAMENTO <> 12"
        oDataC = DBQuery(SqlText)

        SqlText = "SELECT P.CD_TP_PAG_DESAGIO_UMIDADE," & _
                         "P.CD_TP_PAG_DESAGIO_SUJIDADE" & _
                  " FROM SOF.PARAMETRO P "
        RsParDes = DBQuery(SqlText)

        If oDataC.Rows.Count > 0 Then
            For iCont = 0 To oDataC.Rows.Count - 1
                If oDataC.Rows(iCont).Item("DT_PAGAMENTO") < Dt1 Then
                    totvlap = totvlap + oDataC.Rows(iCont).Item("VL_PAGAMENTO")
                    totvlcp = totvlcp + oDataC.Rows(iCont).Item("VL_PAGAMENTO")
                Else
                    oRow = oData.NewRow
                    'SE FOR DESAGIO CALCULO O VALOR EM KILOS
                    If RsParDes.Rows(0).Item("CD_TP_PAG_DESAGIO_UMIDADE") = oDataC.Rows(iCont).Item("CD_TIPO_PAGAMENTO") Or _
                       RsParDes.Rows(0).Item("CD_TP_PAG_DESAGIO_SUJIDADE") = oDataC.Rows(iCont).Item("CD_TIPO_PAGAMENTO") Then
                        SqlText = "SELECT ROUND((CF.VL_TOTAL + CF.VL_ICMS) / CF.QT_KGS, 2) AS VALOR_KGS" & _
                                  " FROM SOF.CONTRATO_FIXO CF," & _
                                        "SOF.PAGAMENTO_DESAGIO_AUTOMATICO PDA" & _
                                  " WHERE CF.CD_CONTRATO_PAF = PDA.CD_CONTRATO_PAF" & _
                                    " AND CF.SQ_NEGOCIACAO =PDA.SQ_NEGOCIACAO" & _
                                    " AND CF.SQ_CONTRATO_FIXO =PDA.SQ_CONTRATO_FIXO" & _
                                    " AND PDA.SQ_PAGAMENTO =" & oDataC.Rows(iCont).Item("SQ_PAGAMENTO")
                        RsDes = DBQuery(SqlText)
                        If RsDes.Rows.Count <> 0 Then
                            oRow.Item("KGDES") = Math.Round(oDataC.Rows(iCont).Item("VL_PAGAMENTO") / RsDes.Rows(0).Item("VALOR_KGS"), 2)
                        End If
                    End If
                    oRow.Item("DATA") = oDataC.Rows(iCont).Item("DT_PAGAMENTO")
                    oRow.Item("NOMETMOV") = Mid(oDataC.Rows(iCont).Item("NO_TIPO_PAGAMENTO"), 1, 40)
                    oRow.Item("TP") = Pagamento
                    oRow.Item("NUMCTR") = 0
                    oRow.Item("VLA") = oDataC.Rows(iCont).Item("VL_PAGAMENTO")
                    oRow.Item("VLC") = oDataC.Rows(iCont).Item("VL_PAGAMENTO")
                    oRow.Item("TPPRECO") = 1
                    oRow.Item("CD_FILIAL_ORIGEM") = oDataC.Rows(iCont).Item("CD_FILIAL_ORIGEM")
                    oRow.Item("CD_FORNECEDOR") = oDataC.Rows(iCont).Item("CD_FORNECEDOR")
                    oRow.Item("NO_FORNECEDOR") = oDataC.Rows(iCont).Item("NO_FORNECEDOR")
                    oRow.Item("CD_REPASSADOR") = oDataC.Rows(iCont).Item("CD_REPASSADOR")
                    oRow.Item("NO_REPASSADOR") = oDataC.Rows(iCont).Item("NO_REPASSADOR")
                    If Not oRow Is Nothing Then oData.Rows.Add(oRow)
                End If
            Next
        End If

        'MOVIMENTAÇÃO CESSÃO DE DIREITO
        SqlText = "SELECT MCD.DT_CESSAO_DIREITO," & _
                         "MCD.QT_KG_A_FIXAR, " & _
                         "MCD.QT_RECEBIDO QT_KG_MOVIMENTACAO," & _
                         "TPMOV.NO_TIPO_MOVIMENTACAO," & _
                         "MOVQ.QT_UMIDADE," & _
                         "MOVQ.IC_TIPO_CACAU," & _
                         "MOV.NU_NF," & _
                         "MOV.CD_FILIAL_MOVIMENTACAO," & _
                         "F.CD_FILIAL_ORIGEM," & _
                         "MCD.CD_FORNECEDOR," & _
                         "F.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) CD_REPASSADOR," & _
                         "NVL(REP.NO_RAZAO_SOCIAL, F.NO_RAZAO_SOCIAL) NO_REPASSADOR," & _
                         "MCD.VL_MOVIMENTACAO," & _
                         "DECODE(MOV.VL_NF, 0, 0, ROUND((MCD.VL_MOVIMENTACAO / MOV.VL_NF) * MOV.VL_NF_FUNRURAL, 2)) VL_FUNRURAL" & _
                  " FROM SOF.TIPO_MOVIMENTACAO TPMOV," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR REP," & _
                        "SOF.MOVIMENTACAO_QUALIDADE MOVQ," & _
                        "SOF.MOVIMENTACAO MOV," & _
                        "SOF.MOVIMENTACAO_CESSAO_DIREITO MCD" & _
                  " WHERE MOV.CD_TIPO_MOVIMENTACAO = TPMOV.CD_TIPO_MOVIMENTACAO" & _
                    " AND MOV.SQ_MOVIMENTACAO = MCD.SQ_MOVIMENTACAO" & _
                    " AND MCD.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) = REP.CD_FORNECEDOR" & _
                    " AND MOV.SQ_MOVIMENTACAO = MOVQ.SQ_MOVIMENTACAO (+)"
        If Rep = True Then
            SqlText = SqlText & " AND NVL(REP.CD_FORNECEDOR, F.CD_FORNECEDOR)  = " & CodForn
        Else
            SqlText = SqlText & " AND F.CD_FORNECEDOR = " & CodForn
        End If
        SqlText = SqlText & " AND MCD.DT_CESSAO_DIREITO <= " & QuotedStr(Date_to_Oracle(Dt2))
        oDataC = DBQuery(SqlText)

        If oDataC.Rows.Count > 0 Then
            For iCont = 0 To oDataC.Rows.Count - 1
                If oDataC.Rows(iCont).Item("DT_CESSAO_DIREITO") < Dt1 Then
                    totkgtr = totkgtr + oDataC.Rows(iCont).Item("QT_KG_MOVIMENTACAO")
                    totkgar = totkgar + oDataC.Rows(iCont).Item("QT_KG_A_FIXAR")
                    totkgfr = totkgfr + (oDataC.Rows(iCont).Item("QT_KG_MOVIMENTACAO") - oDataC.Rows(iCont).Item("QT_KG_A_FIXAR"))
                    TotVlNF = TotVlNF + oDataC.Rows(iCont).Item("VL_MOVIMENTACAO")
                    TotVlNFFunrural = TotVlNFFunrural + oDataC.Rows(iCont).Item("VL_FUNRURAL")
                Else
                    If Sintetico = True Then
                        If Not (oDataC.Rows(iCont).Item("QT_KG_MOVIMENTACAO") = 0) Then 'PARA NAO PEGAR NF COMPLEMENTAR
                            Valido = True
                        Else
                            Valido = False
                        End If
                    Else
                        Valido = True
                    End If
                    If Valido = True Then
                        oRow = oData.NewRow

                        oRow.Item("DATA") = oDataC.Rows(iCont).Item("DT_CESSAO_DIREITO")
                        oRow.Item("NOMETMOV") = oDataC.Rows(iCont).Item("NO_TIPO_MOVIMENTACAO")
                        oRow.Item("KGLNF") = oDataC.Rows(iCont).Item("QT_KG_MOVIMENTACAO")
                        oRow.Item("KGLIQ") = oDataC.Rows(iCont).Item("QT_KG_A_FIXAR")
                        oRow.Item("UMIDADE") = NVL(oDataC.Rows(iCont).Item("QT_UMIDADE"), 0)
                        oRow.Item("TIPO") = NVL(oDataC.Rows(iCont).Item("IC_TIPO_CACAU"), 0)
                        oRow.Item("NF") = oDataC.Rows(iCont).Item("NU_NF")
                        oRow.Item("CODFIL") = oDataC.Rows(iCont).Item("CD_FILIAL_MOVIMENTACAO")
                        oRow.Item("KGFIX") = (oDataC.Rows(iCont).Item("QT_KG_MOVIMENTACAO") - oDataC.Rows(iCont).Item("QT_KG_A_FIXAR"))
                        oRow.Item("TP") = Movimentacao
                        oRow.Item("CD_FILIAL_ORIGEM") = oDataC.Rows(iCont).Item("CD_FILIAL_ORIGEM")
                        oRow.Item("CD_FORNECEDOR") = oDataC.Rows(iCont).Item("CD_FORNECEDOR")
                        oRow.Item("NO_FORNECEDOR") = oDataC.Rows(iCont).Item("NO_FORNECEDOR")
                        oRow.Item("CD_REPASSADOR") = oDataC.Rows(iCont).Item("CD_REPASSADOR")
                        oRow.Item("NO_REPASSADOR") = oDataC.Rows(iCont).Item("NO_REPASSADOR")
                        oRow.Item("VL_NF") = oDataC.Rows(iCont).Item("VL_MOVIMENTACAO")
                        oRow.Item("VL_NF_FUNRURAL") = oDataC.Rows(iCont).Item("VL_FUNRURAL")

                        If Not oRow Is Nothing Then oData.Rows.Add(oRow)
                    End If
                End If
            Next
        End If

        ' MOVIMENTAÇÃO CESSÃO DE DIREITO SAIDA
        SqlText = "SELECT MCDS.DT_CESSAO_DIREITO," & _
                         "MCDS.QT_KG_CEDIDO," & _
                         "0 QT_KG_A_FIXAR," & _
                         "TPMOV.NO_TIPO_MOVIMENTACAO," & _
                         "MOVQ.QT_UMIDADE," & _
                         "MOVQ.IC_TIPO_CACAU," & _
                         "MOV.NU_NF," & _
                         "MOV.CD_FILIAL_MOVIMENTACAO," & _
                         "F.CD_FILIAL_ORIGEM," & _
                         "MCDS.CD_FORNECEDOR," & _
                         "F.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) CD_REPASSADOR," & _
                         "NVL(REP.NO_RAZAO_SOCIAL, F.NO_RAZAO_SOCIAL) NO_REPASSADOR," & _
                         "MCDS.VL_CEDIDO," & _
                         "DECODE(MOV.VL_NF, 0, 0, ROUND((MCDS.VL_CEDIDO / MOV.VL_NF) * MOV.VL_NF_FUNRURAL, 2)) VL_FUNRURAL" & _
                  " FROM SOF.TIPO_MOVIMENTACAO TPMOV," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR REP," & _
                        "SOF.MOVIMENTACAO_QUALIDADE MOVQ," & _
                        "SOF.MOVIMENTACAO MOV," & _
                        "SOF.MOV_CESSAO_DIREITO_SAIDA MCDS" & _
                  " WHERE MOV.CD_TIPO_MOVIMENTACAO = TPMOV.CD_TIPO_MOVIMENTACAO" & _
                    " AND MOV.SQ_MOVIMENTACAO = MCDS.SQ_MOVIMENTACAO" & _
                    " AND MCDS.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) = REP.CD_FORNECEDOR" & _
                    " AND MOV.SQ_MOVIMENTACAO = MOVQ.SQ_MOVIMENTACAO (+)"

        If Rep = True Then
            SqlText = SqlText & " AND NVL(REP.CD_FORNECEDOR, F.CD_FORNECEDOR)  = " & CodForn
        Else
            SqlText = SqlText & " AND F.CD_FORNECEDOR = " & CodForn
        End If

        SqlText = SqlText & " AND MCDS.DT_CESSAO_DIREITO <= " & QuotedStr(Date_to_Oracle(Dt2))
        oDataC = DBQuery(SqlText)

        If oDataC.Rows.Count > 0 Then
            For iCont = 0 To oDataC.Rows.Count - 1
                If oDataC.Rows(iCont).Item("DT_CESSAO_DIREITO") < Dt1 Then
                    totkgtr = totkgtr - oDataC.Rows(iCont).Item("QT_KG_CEDIDO")
                    totkgar = totkgar - oDataC.Rows(iCont).Item("QT_KG_A_FIXAR")
                    totkgfr = totkgfr - (oDataC.Rows(iCont).Item("QT_KG_CEDIDO") - oDataC.Rows(iCont).Item("QT_KG_A_FIXAR"))
                    TotVlNF = TotVlNF + 0 - oDataC.Rows(iCont).Item("VL_CEDIDO")
                    TotVlNFFunrural = TotVlNFFunrural + oDataC.Rows(iCont).Item("VL_FUNRURAL")
                Else
                    If Sintetico = True Then
                        If Not (oDataC.Rows(iCont).Item("QT_KG_CEDIDO") = 0) Then 'PARA NAO PEGAR NF COMPLEMENTAR
                            Valido = True
                        Else
                            Valido = False
                        End If
                    Else
                        Valido = True
                    End If
                    If Valido = True Then
                        oRow = oData.NewRow
                        oRow.Item("DATA") = oDataC.Rows(iCont).Item("DT_CESSAO_DIREITO")
                        oRow.Item("NOMETMOV") = "PRODUTO CEDIDO"
                        oRow.Item("KGLNF") = 0 - oDataC.Rows(iCont).Item("QT_KG_CEDIDO")
                        oRow.Item("KGLIQ") = 0 - oDataC.Rows(iCont).Item("QT_KG_A_FIXAR")
                        oRow.Item("UMIDADE") = NVL(oDataC.Rows(iCont).Item("QT_UMIDADE"), 0)
                        oRow.Item("TIPO") = NVL(oDataC.Rows(iCont).Item("IC_TIPO_CACAU"), 0)
                        oRow.Item("NF") = oDataC.Rows(iCont).Item("NU_NF")
                        oRow.Item("CODFIL") = oDataC.Rows(iCont).Item("CD_FILIAL_MOVIMENTACAO")
                        oRow.Item("KGFIX") = 0 - (oDataC.Rows(iCont).Item("QT_KG_CEDIDO") - oDataC.Rows(iCont).Item("QT_KG_A_FIXAR"))
                        oRow.Item("TP") = Movimentacao
                        oRow.Item("CD_FILIAL_ORIGEM") = oDataC.Rows(iCont).Item("CD_FILIAL_ORIGEM")
                        oRow.Item("CD_FORNECEDOR") = oDataC.Rows(iCont).Item("CD_FORNECEDOR")
                        oRow.Item("NO_FORNECEDOR") = oDataC.Rows(iCont).Item("NO_FORNECEDOR")
                        oRow.Item("CD_REPASSADOR") = oDataC.Rows(iCont).Item("CD_REPASSADOR")
                        oRow.Item("NO_REPASSADOR") = oDataC.Rows(iCont).Item("NO_REPASSADOR")
                        oRow.Item("VL_NF") = 0 - oDataC.Rows(iCont).Item("VL_CEDIDO")
                        oRow.Item("VL_NF_FUNRURAL") = oDataC.Rows(iCont).Item("VL_FUNRURAL")
                        If Not oRow Is Nothing Then oData.Rows.Add(oRow)
                    End If
                End If
            Next
        End If

        'ADENDO DE CONTRATOS
        SqlText = "SELECT AC.CD_CONTRATO_PAF," & _
                         "AC.SQ_NEGOCIACAO," & _
                         "AC.SQ_CONTRATO_FIXO," & _
                         "AC.DT_ADENDO_CONTRATO," & _
                         "AC.VL_ADENDO_CONTRATO," & _
                         "CP.CD_FORNECEDOR," & _
                         "F.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) CD_REPASSADOR," & _
                         "AC.VL_ICMS_ADENDO," & _
                         "NVL(REP.NO_RAZAO_SOCIAL, F.NO_RAZAO_SOCIAL) NO_REPASSADOR," & _
                         "F.CD_FILIAL_ORIGEM," & _
                         "AC.VL_INSS_ADENDO" & _
                  " FROM SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR REP," & _
                        "SOF.CONTRATO_FIXO_ADENDO AC," & _
                        "SOF.CONTRATO_PAF CP" & _
                  " WHERE AC.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                    " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) = REP.CD_FORNECEDOR"

        If Rep = True Then
            SqlText = SqlText & " AND NVL(REP.CD_FORNECEDOR, F.CD_FORNECEDOR)  = " & CodForn
        Else
            SqlText = SqlText & " AND F.CD_FORNECEDOR = " & CodForn
        End If
        SqlText = SqlText & " AND AC.DT_ADENDO_CONTRATO <= " & QuotedStr(Date_to_Oracle(Dt2))
        oDataC = DBQuery(SqlText)

        If oDataC.Rows.Count > 0 Then
            For iCont = 0 To oDataC.Rows.Count - 1
                If oDataC.Rows(iCont).Item("DT_ADENDO_CONTRATO") < Dt1 Then
                    totvlad = totvlad + oDataC.Rows(iCont).Item("VL_ADENDO_CONTRATO") + oDataC.Rows(iCont).Item("VL_ICMS_ADENDO")
                    TotVlCtrINSS = TotVlCtrINSS + oDataC.Rows(iCont).Item("VL_INSS_ADENDO")
                Else
                    oRow = oData.NewRow
                    oRow.Item("DATA") = oDataC.Rows(iCont).Item("DT_ADENDO_CONTRATO")
                    oRow.Item("NOMETMOV") = "ADENDO CONTRATO"
                    oRow.Item("NUMCTR") = oDataC.Rows(iCont).Item("CD_CONTRATO_PAF")
                    oRow.Item("VLTOTAL") = oDataC.Rows(iCont).Item("VL_ADENDO_CONTRATO") + oDataC.Rows(iCont).Item("VL_ICMS_ADENDO")
                    oRow.Item("TP") = Contrato
                    oRow.Item("CD_FILIAL_ORIGEM") = oDataC.Rows(iCont).Item("CD_FILIAL_ORIGEM")
                    oRow.Item("SQ_NEGOCIACAO") = oDataC.Rows(iCont).Item("SQ_NEGOCIACAO")
                    oRow.Item("SQ_CONTRATO_FIXO") = oDataC.Rows(iCont).Item("SQ_CONTRATO_FIXO")
                    oRow.Item("VL_CTR_INSS") = oDataC.Rows(iCont).Item("VL_INSS_ADENDO")
                    If Not oRow Is Nothing Then oData.Rows.Add(oRow)
                End If
            Next
        End If

        'CANCELAMENTO DE CONTRATOS
        SqlText = "SELECT CFC.CD_CONTRATO_PAF," & _
                         "CFC.SQ_NEGOCIACAO," & _
                         "CFC.SQ_CONTRATO_FIXO," & _
                         "CFC.DT_CANCELAMENTO," & _
                         "CFC.QT_CANCELADO," & _
                         "CF.VL_ADENDO," & _
                         "CF.VL_ADENDO_ICMS," & _
                         "CF.VL_TOTAL," & _
                         "CF.VL_ICMS," & _
                         "CF.QT_KGS," & _
                         "F.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) CD_REPASSADOR," & _
                         "F.CD_FILIAL_ORIGEM," & _
                         "NVL(REP.NO_RAZAO_SOCIAL, F.NO_RAZAO_SOCIAL) NO_REPASSADOR," & _
                         "CP.CD_FORNECEDOR," & _
                         "CF.VL_INSS," & _
                         "CF.VL_ADENDO_INSS" & _
                  " FROM SOF.CONTRATO_FIXO_CANCELADO CFC," & _
                        "SOF.CONTRATO_FIXO CF," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR REP" & _
                  " WHERE CF.CD_CONTRATO_PAF = CFC.CD_CONTRATO_PAF" & _
                    " AND CF.SQ_NEGOCIACAO = CFC.SQ_NEGOCIACAO" & _
                    " AND CF.SQ_CONTRATO_FIXO = CFC.SQ_CONTRATO_FIXO" & _
                    " AND CP.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                    " AND F.CD_FORNECEDOR = CP.CD_FORNECEDOR" & _
                    " AND REP.CD_FORNECEDOR = NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR)"

        If Rep = True Then
            SqlText = SqlText & " AND NVL(REP.CD_FORNECEDOR, F.CD_FORNECEDOR)  = " & CodForn
        Else
            SqlText = SqlText & " AND F.CD_FORNECEDOR = " & CodForn
        End If
        SqlText = SqlText & " AND CF.DT_CONTRATO_FIXO <= " & QuotedStr(Date_to_Oracle(Dt2))
        oDataC = DBQuery(SqlText)

        If oDataC.Rows.Count > 0 Then
            For iCont = 0 To oDataC.Rows.Count - 1
                vl = (oDataC.Rows(iCont).Item("VL_TOTAL") + oDataC.Rows(iCont).Item("VL_ICMS")) * (oDataC.Rows(iCont).Item("QT_CANCELADO") / oDataC.Rows(iCont).Item("QT_KGS"))
                VlINSS = (oDataC.Rows(iCont).Item("VL_INSS")) * (oDataC.Rows(iCont).Item("QT_CANCELADO") / oDataC.Rows(iCont).Item("QT_KGS"))
                If oDataC.Rows(iCont).Item("DT_CANCELAMENTO") < Dt1 Then
                    totkgc = totkgc - (oDataC.Rows(iCont).Item("QT_CANCELADO"))
                    totvlc = totvlc - (vl)
                    TotVlCtrINSS = TotVlCtrINSS - VlINSS
                Else
                    oRow = oData.NewRow
                    oRow.Item("DATA") = oDataC.Rows(iCont).Item("DT_CANCELAMENTO")
                    If oDataC.Rows(iCont).Item("QT_CANCELADO") < 0 Then
                        oRow.Item("NOMETMOV") = "ESTORNO DE CANCELAMENTO DE CONTRATO"
                    Else
                        oRow.Item("NOMETMOV") = "CANCELAMENTO DE CONTRATO"
                    End If
                    oRow.Item("NUMCTR") = oDataC.Rows(iCont).Item("CD_CONTRATO_PAF")
                    oRow.Item("KGS") = 0 - oDataC.Rows(iCont).Item("QT_CANCELADO")
                    oRow.Item("VLTOTAL") = 0 - vl
                    oRow.Item("TPPRECO") = 1
                    oRow.Item("TP") = Contrato
                    oRow.Item("CD_FILIAL_ORIGEM") = oDataC.Rows(iCont).Item("CD_FILIAL_ORIGEM")
                    oRow.Item("CD_FORNECEDOR") = oDataC.Rows(iCont).Item("CD_FORNECEDOR")
                    oRow.Item("NO_FORNECEDOR") = oDataC.Rows(iCont).Item("NO_FORNECEDOR")
                    oRow.Item("CD_REPASSADOR") = oDataC.Rows(iCont).Item("CD_REPASSADOR")
                    oRow.Item("NO_REPASSADOR") = oDataC.Rows(iCont).Item("NO_REPASSADOR")
                    oRow.Item("SQ_NEGOCIACAO") = oDataC.Rows(iCont).Item("SQ_NEGOCIACAO")
                    oRow.Item("SQ_CONTRATO_FIXO") = oDataC.Rows(iCont).Item("SQ_CONTRATO_FIXO")
                    oRow.Item("VL_CTR_INSS") = VlINSS
                    If Not oRow Is Nothing Then oData.Rows.Add(oRow)
                End If
            Next
        End If

        'CONCILIACAO DE MOVIMENTAÇÃO
        SqlText = "SELECT 0 - NVL(SUM(CMOV.QT_APLICACAO),0) QT_APLICADO," & _
                         "CMOV.DT_APLICACAO," & _
                         "CM.NO_CONCILIACAO_MODALIDADE," & _
                         "C.CD_FILIAL_ORIGEM CD_FILIAL_MOVIMENTACAO," & _
                         "F.CD_FILIAL_ORIGEM," & _
                         "C.CD_FORNECEDOR," & _
                         "F.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) CD_REPASSADOR," & _
                         "NVL(REP.NO_RAZAO_SOCIAL, F.NO_RAZAO_SOCIAL) NO_REPASSADOR," & _
                         "0 - NVL(SUM(CMOV.VL_APLICACAO), 0) VL_APLICADO," & _
                         "0 - NVL(SUM(DECODE(M.VL_NF, 0, 0, ROUND((CMOV.VL_APLICACAO / M.VL_NF) * M.VL_NF_FUNRURAL,2))), 0) VL_FUNRURAL" & _
                  " FROM SOF.CONCILIACAO C," & _
                        "SOF.CONCILIACAO_MODALIDADE CM, " & _
                        "SOF.CONCILIACAO_MOVIMENTACAO CMOV," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR REP," & _
                        "SOF.MOVIMENTACAO M" & _
                  " WHERE C.CD_CONCILIACAO_MODALIDADE = CM.CD_CONCILIACAO_MODALIDADE" & _
                    " AND C.SQ_CONCILIACAO = CMOV.SQ_CONCILIACAO" & _
                    " AND C.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND CMOV.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                    " AND NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) = REP.CD_FORNECEDOR"

        If Rep = True Then
            SqlText = SqlText & " AND NVL(REP.CD_FORNECEDOR, F.CD_FORNECEDOR) = " & CodForn
        Else
            SqlText = SqlText & " AND F.CD_FORNECEDOR = " & CodForn
        End If

        SqlText = SqlText & " AND CMOV.DT_APLICACAO <= " & QuotedStr(Date_to_Oracle(Dt2)) & _
                  " GROUP BY CMOV.DT_APLICACAO," & _
                            "CM.NO_CONCILIACAO_MODALIDADE," & _
                            "C.CD_FILIAL_ORIGEM," & _
                            "F.CD_FILIAL_ORIGEM," & _
                            "C.CD_FORNECEDOR," & _
                            "F.NO_RAZAO_SOCIAL," & _
                            "NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR)," & _
                            "NVL(REP.NO_RAZAO_SOCIAL, F.NO_RAZAO_SOCIAL)"
        oDataC = DBQuery(SqlText)

        If oDataC.Rows.Count > 0 Then
            For iCont = 0 To oDataC.Rows.Count - 1
                If oDataC.Rows(iCont).Item("DT_APLICACAO") < Dt1 Then
                    totkgtr = totkgtr + oDataC.Rows(iCont).Item("QT_APLICADO")
                    totkgar = totkgar + oDataC.Rows(iCont).Item("QT_APLICADO")
                    totkgfr = totkgfr + (oDataC.Rows(iCont).Item("QT_APLICADO") - oDataC.Rows(iCont).Item("QT_APLICADO"))
                    TotVlNF = TotVlNF + oDataC.Rows(iCont).Item("VL_APLICADO")
                    TotVlNFFunrural = TotVlNFFunrural + oDataC.Rows(iCont).Item("VL_FUNRURAL")
                Else
                    If Sintetico = True Then
                        If Not (oDataC.Rows(iCont).Item("QT_APLICADO") = 0) Then 'PARA NAO PEGAR VALORES ZERADOS
                            Valido = True
                        Else
                            Valido = False
                        End If
                    Else
                        Valido = True
                    End If
                    If Valido = True Then
                        oRow = oData.NewRow
                        oRow.Item("DATA") = oDataC.Rows(iCont).Item("DT_APLICACAO")
                        oRow.Item("NOMETMOV") = Mid(oDataC.Rows(iCont).Item("NO_CONCILIACAO_MODALIDADE"), 1, 40)
                        oRow.Item("KGLNF") = oDataC.Rows(iCont).Item("QT_APLICADO")
                        oRow.Item("KGLIQ") = oDataC.Rows(iCont).Item("QT_APLICADO")
                        oRow.Item("UMIDADE") = 0
                        oRow.Item("TIPO") = 0
                        oRow.Item("NF") = ""
                        oRow.Item("CODFIL") = oDataC.Rows(iCont).Item("CD_FILIAL_MOVIMENTACAO")
                        oRow.Item("KGFIX") = (oDataC.Rows(iCont).Item("QT_APLICADO") - oDataC.Rows(iCont).Item("QT_APLICADO"))
                        oRow.Item("TP") = Movimentacao
                        oRow.Item("CD_FILIAL_ORIGEM") = oDataC.Rows(iCont).Item("CD_FILIAL_ORIGEM")
                        oRow.Item("CD_FORNECEDOR") = oDataC.Rows(iCont).Item("CD_FORNECEDOR")
                        oRow.Item("NO_FORNECEDOR") = oDataC.Rows(iCont).Item("NO_FORNECEDOR")
                        oRow.Item("CD_REPASSADOR") = oDataC.Rows(iCont).Item("CD_REPASSADOR")
                        oRow.Item("NO_REPASSADOR") = oDataC.Rows(iCont).Item("NO_REPASSADOR")
                        oRow.Item("VL_NF") = oDataC.Rows(iCont).Item("VL_APLICADO")
                        oRow.Item("VL_NF_FUNRURAL") = oDataC.Rows(iCont).Item("VL_FUNRURAL")
                        If Not oRow Is Nothing Then oData.Rows.Add(oRow)
                    End If
                End If
            Next
        End If

        'CONCILIACAO DE PAGAMENTO
        SqlText = "SELECT NVL(SUM(CP.VL_APLICACAO),0) VL_APLICADO," & _
                         "CP.DT_APLICACAO," & _
                         "CM.NO_CONCILIACAO_MODALIDADE," & _
                         "C.CD_FILIAL_ORIGEM CD_FILIAL_MOVIMENTACAO," & _
                         "F.CD_FILIAL_ORIGEM," & _
                         "C.CD_FORNECEDOR," & _
                         "F.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) CD_REPASSADOR," & _
                         "NVL(REP.NO_RAZAO_SOCIAL, F.NO_RAZAO_SOCIAL) NO_REPASSADOR" & _
                  " FROM SOF.CONCILIACAO C," & _
                        "SOF.CONCILIACAO_MODALIDADE CM," & _
                        "SOF.CONCILIACAO_PAGAMENTO CP," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR REP" & _
                  " WHERE C.CD_CONCILIACAO_MODALIDADE = CM.CD_CONCILIACAO_MODALIDADE" & _
                    " AND C.SQ_CONCILIACAO = CP.SQ_CONCILIACAO" & _
                    " AND C.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR) = REP.CD_FORNECEDOR" & _
                    " AND CP.VL_APLICACAO <> 0" & _
                    " AND CM.CD_CONCILIACAO_MODALIDADE NOT IN (" & Cod_Conciliacao_ICMS & ")"

        If Rep = True Then
            SqlText = SqlText & " AND NVL(REP.CD_FORNECEDOR, F.CD_FORNECEDOR)  = " & CodForn
        Else
            SqlText = SqlText & " AND F.CD_FORNECEDOR = " & CodForn
        End If

        SqlText = SqlText & " AND CP.DT_APLICACAO <= " & QuotedStr(Date_to_Oracle(Dt2)) & _
                  " GROUP BY CP.DT_APLICACAO," & _
                            "CM.NO_CONCILIACAO_MODALIDADE," & _
                            "C.CD_FILIAL_ORIGEM," & _
                            "F.CD_FILIAL_ORIGEM," & _
                            "C.CD_FORNECEDOR," & _
                            "F.NO_RAZAO_SOCIAL," & _
                            "NVL(F.CD_REPASSADOR, F.CD_FORNECEDOR)," & _
                            "NVL(REP.NO_RAZAO_SOCIAL, F.NO_RAZAO_SOCIAL)"
        oDataC = DBQuery(SqlText)

        If oDataC.Rows.Count > 0 Then
            For iCont = 0 To oDataC.Rows.Count - 1
                If oDataC.Rows(iCont).Item("DT_APLICACAO") < Dt1 Then
                    totvlap = totvlap - oDataC.Rows(iCont).Item("VL_APLICADO")
                    totvlcp = totvlcp - oDataC.Rows(iCont).Item("VL_APLICADO")
                Else
                    oRow = oData.NewRow
                    oRow.Item("DATA") = oDataC.Rows(iCont).Item("DT_APLICACAO")
                    oRow.Item("NOMETMOV") = Mid(oDataC.Rows(iCont).Item("NO_CONCILIACAO_MODALIDADE"), 1, 40)
                    oRow.Item("TP") = Pagamento
                    oRow.Item("NUMCTR") = 0
                    oRow.Item("VLA") = 0 - oDataC.Rows(iCont).Item("VL_APLICADO")
                    oRow.Item("VLC") = 0 - oDataC.Rows(iCont).Item("VL_APLICADO")
                    oRow.Item("TPPRECO") = 1
                    oRow.Item("CD_FILIAL_ORIGEM") = oDataC.Rows(iCont).Item("CD_FILIAL_ORIGEM")
                    oRow.Item("CD_FORNECEDOR") = oDataC.Rows(iCont).Item("CD_FORNECEDOR")
                    oRow.Item("NO_FORNECEDOR") = oDataC.Rows(iCont).Item("NO_FORNECEDOR")
                    oRow.Item("CD_REPASSADOR") = oDataC.Rows(iCont).Item("CD_REPASSADOR")
                    oRow.Item("NO_REPASSADOR") = oDataC.Rows(iCont).Item("NO_REPASSADOR")
                    If Not oRow Is Nothing Then oData.Rows.Add(oRow)
                End If
            Next
        End If

        'SALDO ANTERIOR
        If CodForn <> 0 Then
            oRow = oData.NewRow
            oRow.Item("DATA") = DateAdd(DateInterval.Day, -1, Dt1)
            oRow.Item("NOMETMOV") = "Saldo anterior de contratos"
            oRow.Item("KGS") = totkgc
            oRow.Item("VLTOTAL") = totvlc + totvlad
            oRow.Item("KGLIQ") = totkgar
            oRow.Item("KGFIX") = totkgfr
            oRow.Item("VLC") = totvlcp
            oRow.Item("TP") = 4
            oRow.Item("CD_FILIAL_ORIGEM") = FilO
            oRow.Item("VL_CTR_INSS") = TotVlCtrINSS
            If Not oRow Is Nothing Then oData.Rows.Add(oRow)

            oRow = oData.NewRow
            oRow.Item("DATA") = DateAdd(DateInterval.Day, -1, Dt1)
            oRow.Item("NOMETMOV") = "Saldo anterior de PAG/MOV"
            oRow.Item("KGLNF") = totkgtr
            oRow.Item("KGLIQ") = totkgar
            oRow.Item("KGFIX") = totkgfr
            oRow.Item("VLC") = totvlcp
            oRow.Item("VLA") = totvlap
            oRow.Item("TP") = 5
            oRow.Item("CD_FILIAL_ORIGEM") = FilO
            oRow.Item("VL_NF") = TotVlNF
            oRow.Item("VL_NF_FUNRURAL") = TotVlNFFunrural
            If Not oRow Is Nothing Then oData.Rows.Add(oRow)
        End If

        Gera_RS_Cc_Forn = oData
    End Function

    Public Function Gera_Rs_Estoque_Cacau(ByVal Data As Date) As DataTable
        Dim SqlText As String

        SqlText = "SELECT FIL.NO_FILIAL," & _
                         "SUM(QT_VOLUME) QT_QUILOS," & _
                         "SUM(QT_SACOS) QT_SACOS," & _
                         "FIL.CD_FILIAL" & _
                  " FROM SOF.FILIAL FIL," & _
                        "SOF.ARMAZEM ARM," & _
                        "(SELECT CD_ARMAZEM," & _
                                "SUM(QT_VOLUME) QT_VOLUME" & _
                          " FROM (SELECT MOV.CD_ARMAZEM," & _
                                        "MOV.CD_PILHA_ARMAZEM," & _
                                        "MOV.SQ_MOVIMENTACAO," & _
                                        "MOV.SQ_MOV_PILHA_ARMAZEM_HISTORICO," & _
                                        "MOV.DT_TRANSACAO," & _
                                        "NVL2(MOV.CM_LANCAMENTO, 'U', NVL(TD.IC_TIPO_UTILIZACAO, NVL(TM.IC_TIPO_UTILIZACAO, 'X'))) IC_TIPO_UTILIZACAO," & _
                                        "SUM(MOV.QT_VOLUME * DECODE (MOV.IC_SAIDA, 'S', -1, 1)) QT_VOLUME" & _
                                 " FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO MOV," & _
                                       "SOF.TRANSFERENCIA TR," & _
                                       "SOF.TRANSFERENCIA_MODALIDADE TD," & _
                                       "SOF.MOVIMENTACAO MV," & _
                                       "SOF.TIPO_MOVIMENTACAO TM" & _
                                 " WHERE TRUNC(MOV.DT_TRANSACAO) <= " & QuotedStr(Date_to_Oracle(Data)) & _
                                   " AND TR.SQ_TRANSFERENCIA(+) = MOV.SQ_TRANSFERENCIA" & _
                                   " AND TD.CD_TRANSFERENCIA_MODALIDADE(+) = TR.CD_TRANSFERENCIA_MODALIDADE" & _
                                   " AND MV.SQ_MOVIMENTACAO(+) = MOV.SQ_MOVIMENTACAO" & _
                                   " AND TM.CD_TIPO_MOVIMENTACAO(+) = MV.CD_TIPO_MOVIMENTACAO" & _
                                 " GROUP BY MOV.CD_ARMAZEM," & _
                                           "MOV.CD_PILHA_ARMAZEM," & _
                                           "MOV.SQ_MOVIMENTACAO," & _
                                           "MOV.SQ_MOV_PILHA_ARMAZEM_HISTORICO," & _
                                           "MOV.DT_TRANSACAO," & _
                                           "NVL2(MOV.CM_LANCAMENTO, 'U', NVL(TD.IC_TIPO_UTILIZACAO, NVL(TM.IC_TIPO_UTILIZACAO, 'X'))))" & _
                          " WHERE IC_TIPO_UTILIZACAO <> 'T'" & _
                          " GROUP BY CD_ARMAZEM" & _
                          " HAVING SUM(QT_VOLUME) <> 0) VOL," & _
                        "(SELECT CD_ARMAZEM," & _
                                "SUM(QT_SACOS) QT_SACOS" & _
                         " FROM (SELECT MOV.CD_ARMAZEM," & _
                                       "MOV.CD_PILHA_ARMAZEM," & _
                                       "MOV.SQ_MOVIMENTACAO," & _
                                       "MOV.SQ_MOV_PILHA_ARMAZEM_HISTORICO," & _
                                       "MOV.DT_TRANSACAO," & _
                                       "NVL2(MOV.CM_LANCAMENTO, 'U', NVL(TD.IC_TIPO_UTILIZACAO, NVL(TM.IC_TIPO_UTILIZACAO, 'X'))) IC_TIPO_UTILIZACAO," & _
                                       "SUM(SAC.QT_SACOS * DECODE (MOV.IC_SAIDA, 'S', -1, 1)) QT_SACOS" & _
                                " FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO MOV," & _
                                      "SOF.MOV_PILHA_ARMAZEM_HIST_SACARIA SAC," & _
                                      "SOF.TRANSFERENCIA TR," & _
                                      "SOF.TRANSFERENCIA_MODALIDADE TD," & _
                                      "SOF.MOVIMENTACAO MV," & _
                                      "SOF.TIPO_MOVIMENTACAO TM" & _
                                " WHERE TRUNC(MOV.DT_TRANSACAO) <= " & QuotedStr(Date_to_Oracle(Data)) & _
                                  " AND SAC.CD_ARMAZEM = MOV.CD_ARMAZEM" & _
                                  " AND SAC.CD_PILHA_ARMAZEM = MOV.CD_PILHA_ARMAZEM" & _
                                  " AND SAC.SQ_MOVIMENTACAO = MOV.SQ_MOVIMENTACAO" & _
                                  " AND SAC.SQ_MOV_PILHA_ARMAZEM_HISTORICO = MOV.SQ_MOV_PILHA_ARMAZEM_HISTORICO" & _
                                  " AND TR.SQ_TRANSFERENCIA(+) = MOV.SQ_TRANSFERENCIA" & _
                                  " AND TD.CD_TRANSFERENCIA_MODALIDADE (+) = TR.CD_TRANSFERENCIA_MODALIDADE" & _
                                  " AND MV.SQ_MOVIMENTACAO(+) = MOV.SQ_MOVIMENTACAO" & _
                                  " AND TM.CD_TIPO_MOVIMENTACAO(+) = MV.CD_TIPO_MOVIMENTACAO" & _
                                " GROUP BY MOV.CD_ARMAZEM," & _
                                          "MOV.CD_PILHA_ARMAZEM," & _
                                          "MOV.SQ_MOVIMENTACAO," & _
                                          "MOV.SQ_MOV_PILHA_ARMAZEM_HISTORICO," & _
                                          "MOV.DT_TRANSACAO," & _
                                          "NVL2(MOV.CM_LANCAMENTO, 'U', NVL(TD.IC_TIPO_UTILIZACAO, NVL(TM.IC_TIPO_UTILIZACAO, 'X'))))" & _
                         " GROUP BY CD_ARMAZEM" & _
                         " HAVING SUM(QT_SACOS) <> 0) SAC" & _
                  " WHERE ARM.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND VOL.CD_ARMAZEM (+) = ARM.CD_ARMAZEM" & _
                    " AND SAC.CD_ARMAZEM (+) = ARM.CD_ARMAZEM" & _
                  " GROUP BY FIL.CD_FILIAL, FIL.NO_FILIAL" & _
                  " HAVING SUM(QT_VOLUME) <> 0" & _
                       "OR SUM(QT_SACOS) <> 0"

        Return DBQuery(SqlText)
    End Function

    Public Function Gera_Rs_CalculoDiferencial(ByVal DataInicial As Date, _
                                                ByVal DataFinal As Date, _
                                                Optional ByVal Lista_Filiais As String = "", _
                                                Optional ByVal Lista_TipoCacau As String = "", _
                                                Optional ByVal Lista_TipoPessoa As String = "", _
                                                Optional ByVal Lista_UF As String = "", _
                                                Optional ByVal FilialEntregaContrato As Boolean = False, _
                                                Optional ByVal Cod_Fornecedor As Integer = 0, _
                                                Optional ByVal ExcluiCancelado As Boolean = False, _
                                                Optional ByVal Opcao As enCalcDiferencial_Opcao = NAO_INFORMADO) As DataTable
        Dim SqlText As String = ""

        'CONSULTA DE NEGOCIAÇÃO
        SqlText = "SELECT N.CD_CONTRATO_PAF CD_CONTRATO," & _
                         "F.NO_RAZAO_SOCIAL," & _
                         "TP.NO_TIPO_PESSOA," & _
                         "N.QT_KGS," & _
                         "N.CD_TIPO_UNIDADE," & _
                         "N.VL_NEGOCIACAO VL_UNITARIO," & _
                         "N.VL_PRECO_FRETE," & _
                         "N.QT_KG_FIXO," & _
                         "FIL.CD_FILIAL," & _
                         "FIL.NO_FILIAL," & _
                         "FUN.VL_TAXA," & _
                         "N.PC_ALIQ_ICMS," & _
                         "NVL(N.VL_TAXA_DOLAR, 0) VL_TAXA_DOLAR," & _
                         "NVL(N.VL_TAXA_DOLAR_ALTERNATIVO, 0) VL_TAXA_DOLAR_ALTERNATIVO," & _
                         "NVL(N.VL_BOLSA, 0) VL_BOLSA," & _
                         "NVL(N.VL_BOLSA_ALTERNATIVO, 0) VL_BOLSA_ALTERNATIVO," & _
                         "DECODE(TN.IC_BOLSA, 'S', N.CD_PAPEL_COMPETENCIA, N.CD_PAPEL) CD_PAPEL," & _
                         "N.VL_DIFERENCIAL," & _
                         "N.DT_CRIACAO," & _
                         "N.DT_NEGOCIACAO DT_CONTRATO," & _
                         "N.SQ_NEGOCIACAO," & _
                         "TU.QT_FATOR," & _
                         "TN.CD_TIPO_NEGOCIACAO," & _
                         "TN.NO_TIPO_NEGOCIACAO," & _
                         "TN.IC_BOLSA," & _
                         "TN.IC_BOLSA_OPERACAO," & _
                         "TN.IC_TIPO_PRECO_FIXO," & _
                         "TN.IC_DOLAR," & _
                         "0 SQ_CONTRATO_FIXO," & _
                         "'N' TP_CTR," & _
                         "0 VL_NEGOCIACAO_BOLSA," & _
                         "N.VL_PREMIO_UNITARIO," & _
                         "F.IC_FISICA_JURIDICA," & _
                         "TC.CD_TIPO_CACAU," & _
                         "TC.NO_TIPO_CACAU," & _
                         "'N' AS IC_GP, nvl(N.VL_PREMIO_CRM,0) VL_PREMIO_CRM " & _
                  " FROM SOF.FORNECEDOR F," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.TIPO_PESSOA TP," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.NEGOCIACAO N," & _
                        "SOF.FUNRURAL FUN," & _
                        "SOF.TIPO_NEGOCIACAO TN," & _
                        "SOF.TIPO_UNIDADE TU," & _
                        "SOF.MUNICIPIO MUNIC," & _
                        "SOF.TIPO_CACAU TC" & _
                  " WHERE CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA" & _
                    " AND CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                    " AND F.CD_FUNRURAL = FUN.CD_FUNRURAL" & _
                    " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                    " AND N.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                    " AND F.CD_MUNICIPIO = MUNIC.CD_MUNICIPIO" & _
                    " AND TC.CD_TIPO_CACAU (+) = N.CD_TIPO_CACAU" & _
                    " AND N.DT_NEGOCIACAO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                            " AND " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                    " AND N.IC_STATUS <> 'E'" & _
                    " AND N.CD_TIPO_NEGOCIACAO <> " & cnt_TIPO_NEGOCIACAO_FixoEmReal

        'Filtra filial
        If Trim(Lista_Filiais) <> "" Then
            If FilialEntregaContrato Then
                SqlText = SqlText & " AND CP.CD_FILIAL_ENTREGA IN (" & Lista_Filiais & ")"
            Else
                SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & Lista_Filiais & ")"
            End If
        Else
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If
        If Cod_Fornecedor <> 0 Then
            SqlText = SqlText & " AND CP.CD_FORNECEDOR = " & Cod_Fornecedor
        End If
        If Trim(Lista_TipoCacau) <> "" Then
            SqlText = SqlText & " AND TC.CD_TIPO_CACAU IN (" & Lista_TipoCacau & ")"
        End If
        If Trim(Lista_TipoPessoa) <> "" Then
            SqlText = SqlText & " AND TP.CD_TIPO_PESSOA IN (" & Lista_TipoPessoa & ")"
        End If
        If Trim(Lista_UF) <> "" Then
            SqlText = SqlText & " AND MUNIC.CD_UF IN (" & Lista_UF & ")"
        End If

        'Select Case cboOpcoes.SelectedValue
        Select Case Opcao
            Case SEM_IMPORT, NEG_SEM_IMPORT
                SqlText = SqlText & " AND MUNIC.CD_UF <> 'EX'"
            Case SOMENTE_IMPORT, NEG_SOMENTE_IMPORT
                SqlText = SqlText & " AND MUNIC.CD_UF = 'EX'"
        End Select

        If Not ExcluiCancelado Then
            'CONSULTA DE NEGOCIAÇÕES CANCELAMENTOS
            SqlText = SqlText & _
                      " UNION ALL " & _
                      "SELECT N.CD_CONTRATO_PAF," & _
                             "F.NO_RAZAO_SOCIAL," & _
                             "TP.NO_TIPO_PESSOA," & _
                             "(0 - NC.QT_CANCELADO) QT_KGS," & _
                             "N.CD_TIPO_UNIDADE," & _
                             "NC.VL_UNITARIO," & _
                             "0 VL_PRECO_FRETE," & _
                             "N.QT_KG_FIXO," & _
                             "FIL.CD_FILIAL," & _
                             "FIL.NO_FILIAL," & _
                             "0 VL_TAXA," & _
                             "0 PC_ALIQ_ICMS," & _
                             "0 VL_TAXA_DOLAR," & _
                             "NC.VL_TAXA_DOLAR VL_TAXA_DOLAR_ALTERNATIVO," & _
                             "0 VL_BOLSA," & _
                             "NC.VL_BOLSA VL_BOLSA_ALTERNATIVO," & _
                             "NC.CD_PAPEL," & _
                             "0 VL_DIFERENCIAL," & _
                             "NC.DT_CRIACAO," & _
                             "NC.DT_CANCELAMENTO," & _
                             "N.SQ_NEGOCIACAO," & _
                             "TU.QT_FATOR," & _
                             "TN.CD_TIPO_NEGOCIACAO," & _
                             "TN.NO_TIPO_NEGOCIACAO," & _
                             "'N' IC_BOLSA," & _
                             "NULL," & _
                             "'S' IC_TIPO_PRECO_FIXO," & _
                             "'N' IC_DOLAR," & _
                             "0 SQ_CONTRATO_FIXO," & _
                             "'N' TP_CTR," & _
                             "0 VL_NEGOCIACAO_BOLSA," & _
                             "N.VL_PREMIO_UNITARIO," & _
                             "F.IC_FISICA_JURIDICA," & _
                             "TC.CD_TIPO_CACAU," & _
                             "TC.NO_TIPO_CACAU," & _
                             "'N' AS IC_GP, nvl(N.VL_PREMIO_CRM,0) VL_PREMIO_CRM" & _
                      " FROM SOF.FORNECEDOR F," & _
                            "SOF.FILIAL FIL," & _
                            "SOF.TIPO_PESSOA TP," & _
                            "SOF.CONTRATO_PAF CP," & _
                            "SOF.NEGOCIACAO N," & _
                            "SOF.NEGOCIACAO_CANCELADO NC," & _
                            "SOF.TIPO_NEGOCIACAO TN," & _
                            "SOF.TIPO_UNIDADE TU," & _
                            "SOF.MUNICIPIO MUNIC," & _
                            "SOF.TIPO_CACAU TC" & _
                      " WHERE CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                        " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                        " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA" & _
                        " AND CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                        " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                        " AND N.CD_TIPO_UNIDADE=TU.CD_TIPO_UNIDADE" & _
                        " AND N.CD_CONTRATO_PAF = NC.CD_CONTRATO_PAF" & _
                        " AND N.SQ_NEGOCIACAO = NC.SQ_NEGOCIACAO" & _
                        " AND F.CD_MUNICIPIO = MUNIC.CD_MUNICIPIO" & _
                        " AND TC.CD_TIPO_CACAU (+) = N.CD_TIPO_CACAU" & _
                        " AND NC.DT_CANCELAMENTO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                   " AND " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                        " AND N.CD_TIPO_NEGOCIACAO <> " & cnt_TIPO_NEGOCIACAO_FixoEmReal

            'Filtra filial
            If Trim(Lista_Filiais) <> "" Then
                If FilialEntregaContrato Then
                    SqlText = SqlText & " AND CP.CD_FILIAL_ENTREGA IN (" & Lista_Filiais & ")"
                Else
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & Lista_Filiais & ")"
                End If
            Else
                SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If
            If Cod_Fornecedor <> 0 Then
                SqlText = SqlText & " AND CP.CD_FORNECEDOR = " & Cod_Fornecedor
            End If
            If Trim(Lista_TipoCacau) <> "" Then
                SqlText = SqlText & " AND TC.CD_TIPO_CACAU IN (" & Lista_TipoCacau & ")"
            End If
            If Trim(Lista_TipoPessoa) <> "" Then
                SqlText = SqlText & " AND TP.CD_TIPO_PESSOA IN (" & Lista_TipoPessoa & ")"
            End If
            If Trim(Lista_UF) <> "" Then
                SqlText = SqlText & " AND MUNIC.CD_UF IN (" & Lista_UF & ")"
            End If

            Select Case Opcao
                Case SEM_IMPORT, NEG_SEM_IMPORT
                    SqlText = SqlText & " AND MUNIC.CD_UF <> 'EX'"
                Case SOMENTE_IMPORT, NEG_SOMENTE_IMPORT
                    SqlText = SqlText & " AND MUNIC.CD_UF = 'EX'"
            End Select
        End If

        'PRE NEGOCIAÇÃO
        'SO APARECE PRE NEGOCIACAO SE NAO USAR FILTRO FORNECEDOR
        If Cod_Fornecedor = 0 And Not (Trim(Lista_UF) <> "" Or Trim(Lista_TipoPessoa) <> "") Then
            SqlText = SqlText & _
                      " UNION ALL " & _
                      "SELECT N.SQ_NEGOCIACAO_PRE CD_CONTRATO_PAF," & _
                             "'* ' || SUBSTR(N.DS_FORNECEDOR,1,38) NO_RAZAO_SOCIAL," & _
                             "'*' NO_TIPO_PESSOA," & _
                             "N.QT_SALDO QT_KGS," & _
                             "N.CD_TIPO_UNIDADE," & _
                             "N.VL_NEGOCIACAO," & _
                             "N.VL_PRECO_FRETE," & _
                             "0 QT_KG_FIXO," & _
                             "FIL.CD_FILIAL," & _
                             "FIL.NO_FILIAL," & _
                             "N.VL_TAXA," & _
                             "nvl(N.PC_ALIQ_ICMS,0) PC_ALIQ_ICMS," & _
                             "NVL(N.VL_TAXA_DOLAR, 0) VL_TAXA_DOLAR," & _
                             "NVL(N.VL_TAXA_DOLAR_ALTERNATIVO, 0) VL_TAXA_DOLAR_ALTERNATIVO," & _
                             "NVL(N.VL_BOLSA, 0) VL_BOLSA," & _
                             "NVL(N.VL_BOLSA_ALTERNATIVO, 0) VL_BOLSA_ALTERNATIVO," & _
                             "N.CD_PAPEL," & _
                             "N.VL_DIFERENCIAL," & _
                             "N.DT_CRIACAO," & _
                             "N.DT_NEGOCIACAO," & _
                             "0 SQ_NEGOCIACAO," & _
                             "TU.QT_FATOR," & _
                             "TN.CD_TIPO_NEGOCIACAO," & _
                             "TN.NO_TIPO_NEGOCIACAO," & _
                             "TN.IC_BOLSA," & _
                             "TN.IC_BOLSA_OPERACAO," & _
                             "TN.IC_TIPO_PRECO_FIXO," & _
                             "TN.IC_DOLAR," & _
                             "0 SQ_CONTRATO_FIXO," & _
                             "'F' TP_CTR," & _
                             "0 VL_NEGOCIACAO_BOLSA," & _
                             "N.VL_PREMIO_UNITARIO," & _
                             "'J' IC_FISICA_JURIDICA," & _
                             "TC.CD_TIPO_CACAU," & _
                             "TC.NO_TIPO_CACAU," & _
                             "'N' AS IC_GP, 0 VL_PREMIO_CRM" & _
                      " FROM SOF.FILIAL FIL," & _
                            "SOF.NEGOCIACAO_PRE N," & _
                            "SOF.TIPO_NEGOCIACAO TN," & _
                            "SOF.TIPO_UNIDADE TU," & _
                            "SOF.TIPO_CACAU TC" & _
                      " WHERE N.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                        " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                        " AND N.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                        " AND TC.CD_TIPO_CACAU (+) = N.CD_TIPO_CACAU" & _
                        " AND N.DT_NEGOCIACAO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                " AND " & QuotedStr(Date_to_Oracle(DataFinal)) & _
            " AND N.QT_SALDO <> 0"

            'Filtra filial
            If Trim(Lista_Filiais) <> "" Then
                SqlText = SqlText & " AND N.CD_FILIAL_ORIGEM IN (" & Lista_Filiais & ")"
            Else
                SqlText = SqlText & " AND N.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If
            If Trim(Lista_TipoCacau) <> "" Then
                SqlText = SqlText & " AND TC.CD_TIPO_CACAU IN (" & Lista_TipoCacau & ")"
            End If
        End If

        'se for apenas fixação de contratos reinicio o select
        If Opcao = TODOS Or Opcao = SEM_IMPORT Or Opcao = SOMENTE_IMPORT Then
            'consulta de fixaçõe
            SqlText = SqlText & _
                      " UNION ALL " & _
                      "SELECT N.CD_CONTRATO_PAF AS CD_CONTRATO," & _
                             "F.NO_RAZAO_SOCIAL," & _
                             "TP.NO_TIPO_PESSOA," & _
                             "CF.QT_KGS," & _
                             "CF.CD_TIPO_UNIDADE," & _
                             "CF.VL_UNITARIO," & _
                             "N.VL_PRECO_FRETE," & _
                             "CF.QT_KG_FIXO AS QT_FIX," & _
                             "FIL.CD_FILIAL," & _
                             "FIL.NO_FILIAL," & _
                             "FUN.VL_TAXA," & _
                             "CF.PC_ALIQ_ICMS," & _
                             "DECODE(TN.IC_DOLAR, 'S', CF.VL_TAXA_DOLAR_FECHADO, DECODE(TN.IC_BOLSA, 'S', CF.VL_TAXA_DOLAR_FECHADO, NVL(CF.VL_TAXA_DOLAR, 0))) VL_TAXA_DOLAR," & _
                             "DECODE(TN.IC_DOLAR, 'S', 0, DECODE(TN.IC_BOLSA, 'S', 0, NVL(CF.VL_TAXA_DOLAR_ALTERNATIVO, 0))) VL_TAXA_DOLAR_ALTERNATIVO," & _
                             "DECODE(TN.IC_BOLSA, 'S', CF.VL_BOLSA_FECHADO, NVL(CF.VL_BOLSA, 0)) VL_BOLSA," & _
                             "DECODE(TN.IC_BOLSA, 'S', 0, NVL(CF.VL_BOLSA_ALTERNATIVO, 0)) VL_BOLSA_ALTERNATIVO," & _
                             "DECODE(TN.IC_BOLSA, 'S', N.CD_PAPEL_COMPETENCIA, CF.CD_PAPEL) CD_PAPEL," & _
                             "CF.VL_DIFERENCIAL," & _
                             "CF.DT_CRIACAO," & _
                             "CF.DT_CONTRATO_FIXO AS DT_CONTRATO," & _
                             "N.SQ_NEGOCIACAO," & _
                             "TU.QT_FATOR," & _
                             "TN.CD_TIPO_NEGOCIACAO," & _
                             "TN.NO_TIPO_NEGOCIACAO," & _
                             "TN.IC_BOLSA, " & _
                             "TN.IC_BOLSA_OPERACAO," & _
                             "TN.IC_TIPO_PRECO_FIXO," & _
                             "TN.IC_DOLAR," & _
                             "CF.SQ_CONTRATO_FIXO," & _
                             "'F' TP_CTR," & _
                             "N.VL_NEGOCIACAO VL_NEGOCIACAO_BOLSA," & _
                             "N.VL_PREMIO_UNITARIO AS VL_PREMIO_UNITARIO_KG," & _
                             "F.IC_FISICA_JURIDICA," & _
                             "TC.CD_TIPO_CACAU," & _
                             "TC.NO_TIPO_CACAU," & _
                             "CF.IC_GP, nvl(N.VL_PREMIO_CRM,0) VL_PREMIO_CRM" & _
                      " FROM SOF.FORNECEDOR F," & _
                            "SOF.FILIAL FIL," & _
                            "SOF.TIPO_PESSOA TP," & _
                            "SOF.CONTRATO_PAF CP," & _
                            "SOF.NEGOCIACAO N," & _
                            "SOF.FUNRURAL FUN," & _
                            "SOF.TIPO_NEGOCIACAO TN," & _
                            "SOF.TIPO_UNIDADE TU," & _
                            "SOF.CONTRATO_FIXO CF," & _
                            "SOF.MUNICIPIO MUNIC," & _
                            "SOF.TIPO_CACAU TC" & _
                      " WHERE CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                        " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL " & _
                        " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA " & _
                        " AND CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF " & _
                        " AND N.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF " & _
                        " AND N.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO " & _
                        " AND F.CD_FUNRURAL = FUN.CD_FUNRURAL " & _
                        " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO " & _
                        " AND N.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE " & _
                        " AND F.CD_MUNICIPIO = MUNIC.CD_MUNICIPIO " & _
                        " AND TC.CD_TIPO_CACAU (+) = N.CD_TIPO_CACAU" & _
                        " AND CF.DT_CONTRATO_FIXO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                    " AND " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                        " AND CF.IC_STATUS <> 'E'"

            'FILTRA FILIAL
            If Trim(Lista_Filiais) <> "" Then
                If FilialEntregaContrato Then
                    SqlText = SqlText & " AND CP.CD_FILIAL_ENTREGA IN (" & Lista_Filiais & ")"
                Else
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & Lista_Filiais & ")"
                End If
            Else
                SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If
            If Cod_Fornecedor <> 0 Then
                SqlText = SqlText & " AND CP.CD_FORNECEDOR = " & Cod_Fornecedor
            End If
            If Trim(Lista_TipoCacau) <> "" Then
                SqlText = SqlText & " AND TC.CD_TIPO_CACAU IN (" & Lista_TipoCacau & ")"
            End If
            If Trim(Lista_TipoPessoa) <> "" Then
                SqlText = SqlText & " AND TP.CD_TIPO_PESSOA IN (" & Lista_TipoPessoa & ")"
            End If
            If Trim(Lista_UF) <> "" Then
                SqlText = SqlText & " AND MUNIC.CD_UF IN (" & Lista_UF & ")"
            End If

            Select Case Opcao
                Case SEM_IMPORT, NEG_SEM_IMPORT
                    SqlText = SqlText & " AND MUNIC.CD_UF <> 'EX'"
                Case SOMENTE_IMPORT, NEG_SOMENTE_IMPORT
                    SqlText = SqlText & " AND MUNIC.CD_UF = 'EX'"
            End Select

            If Not ExcluiCancelado Then
                'consulta de fixações cancelados
                SqlText = SqlText & _
                          " UNION ALL " & _
                          "SELECT N.CD_CONTRATO_PAF," & _
                                 "F.NO_RAZAO_SOCIAL," & _
                                 "TP.NO_TIPO_PESSOA," & _
                                 "(0 - CFC.QT_CANCELADO) QT_KGS," & _
                                 "CF.CD_TIPO_UNIDADE," & _
                                 "CFC.VL_UNITARIO," & _
                                 "0 VL_PRECO_FRETE," & _
                                 "CF.QT_KG_FIXO," & _
                                 "FIL.CD_FILIAL," & _
                                 "FIL.NO_FILIAL," & _
                                 "0 VL_TAXA," & _
                                 "0 PC_ALIQ_ICMS," & _
                                 "0 VL_TAXA_DOLAR," & _
                                 "CFC.VL_TAXA_DOLAR VL_TAXA_DOLAR_ALTERNATIVO," & _
                                 "0 VL_BOLSA," & _
                                 "CFC.VL_BOLSA VL_BOLSA_ALTERNATIVO," & _
                                 "CFC.CD_PAPEL," & _
                                 "0 VL_DIFERENCIAL," & _
                                 "CFC.DT_CRIACAO," & _
                                 "CFC.DT_CANCELAMENTO," & _
                                 "N.SQ_NEGOCIACAO," & _
                                 "TU.QT_FATOR," & _
                                 "TN.CD_TIPO_NEGOCIACAO," & _
                                 "TN.NO_TIPO_NEGOCIACAO," & _
                                 "'N' IC_BOLSA," & _
                                 "NULL IC_BOLSA_OPERACAO," & _
                                 "'S' IC_TIPO_PRECO_FIXO," & _
                                 "'N' IC_DOLAR," & _
                                 "CF.SQ_CONTRATO_FIXO," & _
                                 "'F' TP_CTR," & _
                                 "0 VL_NEGOCIACAO_BOLSA," & _
                                 "N.VL_PREMIO_UNITARIO," & _
                                 "F.IC_FISICA_JURIDICA," & _
                                 "TC.CD_TIPO_CACAU," & _
                                 "TC.NO_TIPO_CACAU," & _
                                 "CF.IC_GP, nvl(N.VL_PREMIO_CRM,0) VL_PREMIO_CRM" & _
                          " FROM SOF.FORNECEDOR F," & _
                                "SOF.FILIAL FIL," & _
                                "SOF.TIPO_PESSOA TP," & _
                                "SOF.CONTRATO_PAF CP," & _
                                "SOF.NEGOCIACAO N," & _
                                "SOF.TIPO_NEGOCIACAO TN," & _
                                "SOF.TIPO_UNIDADE TU," & _
                                "SOF.CONTRATO_FIXO CF," & _
                                "SOF.CONTRATO_FIXO_CANCELADO CFC," & _
                                "SOF.MUNICIPIO MUNIC," & _
                                "SOF.TIPO_CACAU TC" & _
                          " WHERE CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                            " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                            " AND F.CD_TIPO_PESSOA = TP.CD_TIPO_PESSOA" & _
                            " AND CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                            " AND N.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                            " AND N.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO" & _
                            " AND CF.CD_CONTRATO_PAF = CFC.CD_CONTRATO_PAF" & _
                            " AND CF.SQ_NEGOCIACAO = CFC.SQ_NEGOCIACAO" & _
                            " AND CF.SQ_CONTRATO_FIXO = CFC.SQ_CONTRATO_FIXO" & _
                            " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                            " AND N.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                            " AND F.CD_MUNICIPIO = MUNIC.CD_MUNICIPIO" & _
                            " AND TC.CD_TIPO_CACAU (+) = N.CD_TIPO_CACAU" & _
                            " AND CFC.DT_CANCELAMENTO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                        " AND " & QuotedStr(Date_to_Oracle(DataFinal))

                'Filtra filial
                If Trim(Lista_Filiais) <> "" Then
                    If FilialEntregaContrato Then
                        SqlText = SqlText & " AND CP.CD_FILIAL_ENTREGA IN (" & Lista_Filiais & ")"
                    Else
                        SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & Lista_Filiais & ")"
                    End If
                Else
                    SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If
                If Cod_Fornecedor <> 0 Then
                    SqlText = SqlText & " AND CP.CD_FORNECEDOR = " & Cod_Fornecedor
                End If
                If Trim(Lista_TipoCacau) <> "" Then
                    SqlText = SqlText & " AND TC.CD_TIPO_CACAU IN (" & Lista_TipoCacau & ")"
                End If
                If Trim(Lista_TipoPessoa) <> "" Then
                    SqlText = SqlText & " AND TP.CD_TIPO_PESSOA IN (" & Lista_TipoPessoa & ")"
                End If
                If Trim(Lista_UF) <> "" Then
                    SqlText = SqlText & " AND MUNIC.CD_UF IN (" & Lista_UF & ")"
                End If

                Select Case Opcao
                    Case SEM_IMPORT, NEG_SEM_IMPORT
                        SqlText = SqlText & " AND MUNIC.CD_UF <> 'EX'"
                    Case SOMENTE_IMPORT, NEG_SOMENTE_IMPORT
                        SqlText = SqlText & " AND MUNIC.CD_UF = 'EX'"
                End Select
            End If
        End If

        Return DBQuery(SqlText)
    End Function

    Public Function Gera_Rs_NegociacaoAbertaComFixacoes(ByVal DataLimite As String, _
                                                        ByVal DataBolsa As String, _
                                                        Optional ByVal Lista_Filiais As String = "", _
                                                        Optional ByVal Lista_TipoNegociacao As String = "", Optional ByVal bComSaldo As Boolean = False) As DataTable
        Dim SqlText As String
        Dim SqlNeg As String
        Dim SqlCtrFix As String

        If IsDate(DataLimite) Then
            SqlNeg = "(SELECT CD_CONTRATO_PAF," & _
                             "SQ_NEGOCIACAO," & _
                             "QT_KGS," & _
                             "QT_KG_FIXADO," & _
                             "QT_KG_FIXO," & _
                             "QT_CANCELADO," & _
                             "(QT_KGS - QT_CANCELADO - QT_KG_FIXADO) QT_A_FIXAR," & _
                             "DT_NEGOCIACAO," & _
                             "DT_VENCIMENTO," & _
                             "VL_NEGOCIACAO," & _
                             "CD_PAPEL_COMPETENCIA," & _
                             "CD_TIPO_NEGOCIACAO," & _
                             "CD_TIPO_UNIDADE," & _
                             "CD_LOCAL_ENTREGA," & _
                             "VL_PAG_FIXO" & _
                      " FROM (SELECT N.CD_CONTRATO_PAF," & _
                                    "N.SQ_NEGOCIACAO," & _
                                    "N.QT_KGS," & _
                                    "N.DT_NEGOCIACAO," & _
                                    "N.DT_VENCIMENTO," & _
                                    "N.VL_NEGOCIACAO," & _
                                    "N.CD_PAPEL_COMPETENCIA," & _
                                    "N.CD_LOCAL_ENTREGA," & _
                                    "N.CD_TIPO_NEGOCIACAO," & _
                                    "N.CD_TIPO_UNIDADE," & _
                                    "NVL(CFF.QT_KGS,0) QT_KG_FIXADO," & _
                                    "NVL(NM.QT_KG_FIXO,0) QT_KG_FIXO," & _
                                    "NVL(NC.QT_CANCELADO,0) QT_CANCELADO," & _
                                    "N.VL_PAG_FIXO" & _
                             " FROM SOF.NEGOCIACAO N," & _
                                   "(SELECT CF.CD_CONTRATO_PAF," & _
                                           "CF.SQ_NEGOCIACAO," & _
                                           "SUM(CF.QT_KGS-CF.QT_CANCELADO) QT_KGS" & _
                                    " FROM SOF.CONTRATO_FIXO CF" & _
                                    " WHERE CF.IC_STATUS <> 'E'" & _
                                      " AND CF.DT_CONTRATO_FIXO <= " & QuotedStr(Date_to_Oracle(DataLimite)) & _
                                    " GROUP BY CF.CD_CONTRATO_PAF," & _
                                              "CF.SQ_NEGOCIACAO) CFF," & _
                                   "(SELECT CPNM.CD_CONTRATO_PAF," & _
                                           "CPNM.SQ_NEGOCIACAO," & _
                                           "SUM(CPNM.QT_KG_FIXO) QT_KG_FIXO" & _
                                    " FROM SOF.CTR_PAF_NEG_MOVIMENTACAO CPNM" & _
                                    " WHERE CPNM.DT_FIXACAO <= " & QuotedStr(Date_to_Oracle(DataLimite)) & _
                                    " GROUP BY CPNM.CD_CONTRATO_PAF," & _
                                              "CPNM.SQ_NEGOCIACAO) NM," & _
                                   "(SELECT NC.CD_CONTRATO_PAF," & _
                                           "NC.SQ_NEGOCIACAO," & _
                                           "SUM(NC.QT_CANCELADO) QT_CANCELADO" & _
                                    " FROM SOF.NEGOCIACAO_CANCELADO NC" & _
                                    " WHERE NC.DT_CANCELAMENTO <= " & QuotedStr(Date_to_Oracle(DataLimite)) & _
                                    " GROUP BY NC.CD_CONTRATO_PAF," & _
                                              "NC.SQ_NEGOCIACAO) NC" & _
                             " WHERE N.CD_CONTRATO_PAF = CFF.CD_CONTRATO_PAF (+)" & _
                               " AND N.SQ_NEGOCIACAO = CFF.SQ_NEGOCIACAO (+)" & _
                               " AND N.CD_CONTRATO_PAF = NM.CD_CONTRATO_PAF (+)" & _
                               " AND N.SQ_NEGOCIACAO = NM.SQ_NEGOCIACAO (+)" & _
                               " AND N.CD_CONTRATO_PAF = NC.CD_CONTRATO_PAF (+)" & _
                               " AND N.SQ_NEGOCIACAO = NC.SQ_NEGOCIACAO (+)" & _
                               " AND N.DT_NEGOCIACAO <= " & QuotedStr(Date_to_Oracle(DataLimite)) & _
                               " AND N.IC_STATUS <> 'E')"
            SqlNeg = SqlNeg & "WHERE (QT_KGS - QT_CANCELADO - QT_KG_FIXADO) <> 0)"

            SqlCtrFix = "(SELECT CF.CD_CONTRATO_PAF," & _
                                "CF.SQ_NEGOCIACAO," & _
                                "CF.SQ_CONTRATO_FIXO," & _
                                "CF.QT_KGS," & _
                                "CF.DT_CONTRATO_FIXO," & _
                                "CF.VL_TAXA_DOLAR_FECHADO," & _
                                "CF.VL_BOLSA_FECHADO," & _
                                "CF.VL_UNITARIO," & _
                                "CF.VL_TOTAL," & _
                                "CF.VL_ICMS," & _
                                "CF.IC_STATUS," & _
                                "CF.DT_VENCIMENTO," & _
                                "NVL(CFM.QT_KG_FIXO,0) QT_KG_FIXO," & _
                                "NVL(CFC.QT_CANCELADO,0) QT_CANCELADO, " & _
                                "CF.VL_PAG_FIXO" & _
                         " FROM SOF.CONTRATO_FIXO CF," & _
                               "(SELECT A.CD_CONTRATO_PAF," & _
                                       "A.SQ_NEGOCIACAO," & _
                                       "A.SQ_CONTRATO_FIXO," & _
                                       "SUM(A.QT_KG_FIXO) QT_KG_FIXO" & _
                                " FROM SOF.CTR_PAF_NEG_CTR_FIX_MOV A" & _
                                " WHERE A.DT_FIXACAO <= " & QuotedStr(Date_to_Oracle(DataLimite)) & _
                                " GROUP BY A.CD_CONTRATO_PAF," & _
                                          "A.SQ_NEGOCIACAO," & _
                                          "A.SQ_CONTRATO_FIXO) CFM," & _
                               "(SELECT B.CD_CONTRATO_PAF," & _
                                       "B.SQ_NEGOCIACAO," & _
                                       "B.SQ_CONTRATO_FIXO," & _
                                       "SUM(B.QT_CANCELADO) QT_CANCELADO" & _
                                " FROM SOF.CONTRATO_FIXO_CANCELADO B" & _
                                " WHERE B.DT_CANCELAMENTO <= " & QuotedStr(Date_to_Oracle(DataLimite)) & _
                                " GROUP BY B.CD_CONTRATO_PAF," & _
                                          "B.SQ_NEGOCIACAO," & _
                                          "B.SQ_CONTRATO_FIXO) CFC" & _
                         " WHERE CF.CD_CONTRATO_PAF = CFM.CD_CONTRATO_PAF (+)" & _
                           " AND CF.SQ_NEGOCIACAO = CFM.SQ_NEGOCIACAO (+)" & _
                           " AND CF.SQ_CONTRATO_FIXO = CFM.SQ_CONTRATO_FIXO (+)" & _
                           " AND CF.CD_CONTRATO_PAF = CFC.CD_CONTRATO_PAF (+)" & _
                           " AND CF.SQ_NEGOCIACAO = CFC.SQ_NEGOCIACAO (+)" & _
                           " AND CF.SQ_CONTRATO_FIXO = CFC.SQ_CONTRATO_FIXO (+)" & _
                           " AND CF.DT_CONTRATO_FIXO <= " & QuotedStr(Date_to_Oracle(DataLimite)) & _
                           " AND CF.IC_STATUS <> 'E')"
        Else
            SqlNeg = "SOF.NEGOCIACAO"

            SqlCtrFix = "SOF.CONTRATO_FIXO"
        End If

        SqlText = "SELECT FIL.CD_FILIAL," & _
                         "FIL.NO_FILIAL," & _
                         "N.DT_NEGOCIACAO," & _
                         "N.CD_CONTRATO_PAF," & _
                         "N.SQ_NEGOCIACAO," & _
                         "F.NO_RAZAO_SOCIAL," & _
                         "N.DT_VENCIMENTO," & _
                         "N.QT_KGS," & _
                         "N.QT_CANCELADO," & _
                         "N.QT_KG_FIXO," & _
                         "N.QT_A_FIXAR," & _
                         "N.VL_NEGOCIACAO," & _
                         "BH.VL_COTACAO AS VL_BOLSA," & _
                         "LE.NO_LOCAL_ENTREGA," & _
                         "CF.SQ_CONTRATO_FIXO," & _
                         "CF.QT_KGS QT_KGS_FIXO," & _
                         "CF.VL_TAXA_DOLAR_FECHADO," & _
                         "CF.VL_BOLSA_FECHADO," & _
                         "CF.QT_CANCELADO QT_CANCELADO_FIXO," & _
                         "CF.DT_CONTRATO_FIXO," & _
                         "CF.VL_UNITARIO," & _
                         "CF.VL_TOTAL," & _
                         "CF.VL_ICMS," & _
                         "CF.IC_STATUS," & _
                         "CF.DT_VENCIMENTO DT_VENCIMENTO_FIXO," & _
                         "CF.QT_KG_FIXO QT_KG_FIXO_FIXO," & _
                         "TN.IC_BOLSA," & _
                         "TN.IC_BOLSA_OPERACAO," & _
                         "TN.IC_DOLAR," & _
                         "TN.IC_TIPO_PRECO_FIXO," & _
                         "TU.QT_FATOR," & _
                         "TN.NO_TIPO_NEGOCIACAO," & _
                         "N.CD_PAPEL_COMPETENCIA," & _
                         "N.VL_PAG_FIXO VL_PAG_FIXO_NEG," & _
                         "NVL(CF.VL_PAG_FIXO, 0) VL_PAG_FIXO_CF " & _
                  " FROM " & SqlNeg & " N," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.LOCAL_ENTREGA LE," & _
                        SqlCtrFix & " CF," & _
                        "SOF.TIPO_NEGOCIACAO TN," & _
                        "SOF.TIPO_UNIDADE TU," & _
                        "SOF.BOLSA_PERIODO_MATRIZ BPM,"

        If IsDate(DataBolsa) Then
            SqlText = SqlText & "(SELECT B.SQ_BOLSA_PERIODO_MATRIZ," & _
                                        "B.VL_COTACAO " & _
                                 " FROM SOF.BOLSA_HISTORICO B" & _
                                 " WHERE B.DT_BOLSA_HISTORICO = " & QuotedStr(Date_to_Oracle(DataBolsa)) & ") BH "
        Else
            If IsDate(DataLimite) Then
                SqlText = SqlText & "(SELECT B.SQ_BOLSA_PERIODO_MATRIZ," & _
                                            "B.VL_COTACAO" & _
                                     " FROM SOF.BOLSA_HISTORICO B" & _
                                     " WHERE B.DT_BOLSA_HISTORICO = (SELECT MAX(B2.DT_BOLSA_HISTORICO )" & _
                                                                    " FROM SOF.BOLSA_HISTORICO B2" & _
                                                                    " WHERE B2.VL_COTACAO <> 0" & _
                                                                      " AND B2.DT_BOLSA_HISTORICO <= " & QuotedStr(Date_to_Oracle(DataLimite)) & _
                                                                      " AND B.SQ_BOLSA_PERIODO_MATRIZ = B2.SQ_BOLSA_PERIODO_MATRIZ )) BH "
            Else
                SqlText = SqlText & "(SELECT B.SQ_BOLSA_PERIODO_MATRIZ," & _
                                            "B.VL_COTACAO " & _
                                     " FROM SOF.BOLSA_HISTORICO B" & _
                                    " WHERE B.DT_BOLSA_HISTORICO = (SELECT MAX(B2.DT_BOLSA_HISTORICO )" & _
                                                                   " FROM SOF.BOLSA_HISTORICO B2" & _
                                                                   " WHERE B2.VL_COTACAO <> 0 " & _
                                                                     " AND B.SQ_BOLSA_PERIODO_MATRIZ = B2.SQ_BOLSA_PERIODO_MATRIZ )) BH "
            End If
        End If


        SqlText = SqlText & "WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                             " AND F.CD_FORNECEDOR = CP.CD_FORNECEDOR" & _
                             " AND FIL.CD_FILIAL = F.CD_FILIAL_ORIGEM" & _
                             " AND LE.CD_LOCAL_ENTREGA = N.CD_LOCAL_ENTREGA" & _
                             " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                             " AND N.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                             " AND N.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF (+)" & _
                             " AND N.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO (+)" & _
                             " AND N.CD_PAPEL_COMPETENCIA = BPM.CD_PAPEL (+)" & _
                             " AND BPM.SQ_BOLSA_PERIODO_MATRIZ = BH.SQ_BOLSA_PERIODO_MATRIZ (+) "

        If Not IsDate(DataLimite) Then
            SqlText = SqlText & " AND N.IC_STATUS = 'A' "
            SqlText = SqlText & " AND CF.IC_STATUS(+) <> 'E'"
        End If

        'Filtro filial
        If Trim(Lista_Filiais) <> "" Then
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & Lista_Filiais & ")"
        Else
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        If Trim(Lista_TipoNegociacao) <> "" Then
            SqlText = SqlText & " AND N.CD_TIPO_NEGOCIACAO IN (" & Lista_TipoNegociacao & ")"
        End If

        If bComSaldo = True Then

            SqlText = SqlText & " and n.QT_A_FIXAR<>0 "
        End If

        Return DBQuery(SqlText)
    End Function

    Public Function Gera_Rs_NetSaldo(ByVal VL_BOLSA As Integer, _
                                     ByVal TX_DOLAR As Double, _
                                     ByVal VL_ARROBA As Double, _
                                     ByVal Sintetico As Boolean, _
                                     Optional ByVal Lista_Safra As String = "", _
                                     Optional ByVal Lista_Filial As String = "", _
                                     Optional ByVal Lista_ModalidadeRecuperacaoCredito As String = "", _
                                     Optional ByVal SomenteNegativos As Boolean = False) As DataTable
        Dim oData As DataTable
        Dim oData_Aux As New DataTable
        Dim SqlTextGarantias As String
        Dim cdSafraAtual As Integer

        oData = Gera_Rs_Posicao_Fornecedor(VL_BOLSA, TX_DOLAR, VL_ARROBA, True, Nothing, Nothing, False, _
                                      IIf(Trim(Lista_Safra) <> "", True, False), _
                                      Lista_Safra, _
                                      -1, _
                                      IIf(Trim(Lista_Filial) = "", ListarIDFiliaisLiberadaUsuario, Lista_Filial), _
                                      Lista_ModalidadeRecuperacaoCredito)

        'Verifico o crédito
        SqlTextGarantias = "SELECT   DECODE (f.cd_repassador, "
        SqlTextGarantias = SqlTextGarantias & "                 NULL, f.cd_fornecedor, "
        SqlTextGarantias = SqlTextGarantias & "                 f.cd_repassador "
        SqlTextGarantias = SqlTextGarantias & "                ) AS cd_repassador, "
        SqlTextGarantias = SqlTextGarantias & "         rep.no_razao_social no_repassador, f.cd_fornecedor, "
        SqlTextGarantias = SqlTextGarantias & "         f.no_razao_social no_fornecedor, "
        SqlTextGarantias = SqlTextGarantias & "         SUM (vl_credito_total) AS vl_credito_total, "
        SqlTextGarantias = SqlTextGarantias & "         SUM (vl_credito_provisorio) AS vl_credito_provisorio, fil.cd_filial, fil.no_filial "
        SqlTextGarantias = SqlTextGarantias & "    FROM (SELECT   lc.cd_fornecedor, "
        SqlTextGarantias = SqlTextGarantias & "                   DECODE (lc.cd_tipo_status, "
        SqlTextGarantias = SqlTextGarantias & "                           'A', SUM (DECODE (lc.ic_moeda_credito, "
        SqlTextGarantias = SqlTextGarantias & "                                             'S', lc.vl_credito * 4 * " & VL_ARROBA & ", "
        SqlTextGarantias = SqlTextGarantias & "                                             'D', lc.vl_credito * " & TX_DOLAR & ", "
        SqlTextGarantias = SqlTextGarantias & "                                             'R', lc.vl_credito "
        SqlTextGarantias = SqlTextGarantias & "                                            ) "
        SqlTextGarantias = SqlTextGarantias & "                                    ), "
        SqlTextGarantias = SqlTextGarantias & "                           'E', SUM (DECODE (lc.ic_moeda_credito, "
        SqlTextGarantias = SqlTextGarantias & "                                             'S', lc.vl_credito * 4 * " & VL_ARROBA & ", "
        SqlTextGarantias = SqlTextGarantias & "                                             'D', lc.vl_credito * " & TX_DOLAR & ", "
        SqlTextGarantias = SqlTextGarantias & "                                             'R', lc.vl_credito "
        SqlTextGarantias = SqlTextGarantias & "                                            ) "
        SqlTextGarantias = SqlTextGarantias & "                                    ), "
        SqlTextGarantias = SqlTextGarantias & "                           0 "
        SqlTextGarantias = SqlTextGarantias & "                          ) vl_credito_total, "
        SqlTextGarantias = SqlTextGarantias & "                   DECODE "
        SqlTextGarantias = SqlTextGarantias & "                      (lc.cd_tipo_status, "
        SqlTextGarantias = SqlTextGarantias & "                       'A', SUM (DECODE (lc.ic_excecao, "
        SqlTextGarantias = SqlTextGarantias & "                                         'S', DECODE (lc.ic_moeda_credito, "
        SqlTextGarantias = SqlTextGarantias & "                                                      'S', lc.vl_credito * 4 "
        SqlTextGarantias = SqlTextGarantias & "                                                       * " & VL_ARROBA & ", "
        SqlTextGarantias = SqlTextGarantias & "                                                      'D', lc.vl_credito "
        SqlTextGarantias = SqlTextGarantias & "                                                       * " & TX_DOLAR & ", "
        SqlTextGarantias = SqlTextGarantias & "                                                      'R', lc.vl_credito "
        SqlTextGarantias = SqlTextGarantias & "                                                     ), "
        SqlTextGarantias = SqlTextGarantias & "                                         0 "
        SqlTextGarantias = SqlTextGarantias & "                                        ) "
        SqlTextGarantias = SqlTextGarantias & "                                ), "
        SqlTextGarantias = SqlTextGarantias & "                       0 "
        SqlTextGarantias = SqlTextGarantias & "                      ) vl_credito_provisorio "
        SqlTextGarantias = SqlTextGarantias & "              FROM sof.limite_credito lc, sof.garantia g "
        SqlTextGarantias = SqlTextGarantias & "              where lc.cd_tipo_status = 'A' "
        SqlTextGarantias = SqlTextGarantias & "               AND lc.sq_garantia = g.sq_garantia(+) "
        SqlTextGarantias = SqlTextGarantias & "          GROUP BY lc.cd_fornecedor, lc.cd_tipo_status) cred, "
        SqlTextGarantias = SqlTextGarantias & "         sof.fornecedor f, "
        SqlTextGarantias = SqlTextGarantias & "         sof.fornecedor rep, "
        SqlTextGarantias = SqlTextGarantias & "         sof.filial fil "
        SqlTextGarantias = SqlTextGarantias & "   WHERE f.cd_fornecedor = cred.cd_fornecedor "
        SqlTextGarantias = SqlTextGarantias & "     AND DECODE (f.cd_repassador, NULL, f.cd_fornecedor, f.cd_repassador) = "
        SqlTextGarantias = SqlTextGarantias & "                                                             rep.cd_fornecedor "
        SqlTextGarantias = SqlTextGarantias & "     AND rep.cd_filial_origem = fil.cd_filial "

        'Filtro Filial
        If Trim(Lista_Filial) <> "" Then
            SqlTextGarantias = SqlTextGarantias & " AND Fil.cd_filial in (" & Lista_Filial & ")"
        Else
            SqlTextGarantias = SqlTextGarantias & " AND Fil.cd_filial in (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlTextGarantias = SqlTextGarantias & "     AND (vl_credito_total <> 0) "
        SqlTextGarantias = SqlTextGarantias & "GROUP BY f.cd_repassador, "
        SqlTextGarantias = SqlTextGarantias & "         rep.no_razao_social, "
        SqlTextGarantias = SqlTextGarantias & "         f.cd_fornecedor, "
        SqlTextGarantias = SqlTextGarantias & "         f.no_razao_social, "
        SqlTextGarantias = SqlTextGarantias & "         fil.cd_filial, "
        SqlTextGarantias = SqlTextGarantias & "         fil.no_filial "

        oData_Aux = DBQuery(SqlTextGarantias)

        Dim iCont As Integer
        Dim oRow As DataRow

        For iCont = 0 To oData_Aux.Rows.Count - 1
            oRow = oData.NewRow
            oRow.Item("CD_FILIAL") = oData_Aux.Rows(iCont).Item("CD_FILIAL")
            oRow.Item("NO_FILIAL") = oData_Aux.Rows(iCont).Item("NO_FILIAL")
            oRow.Item("CD_REPASSADOR") = oData_Aux.Rows(iCont).Item("CD_REPASSADOR")
            oRow.Item("NO_REPASSADOR") = oData_Aux.Rows(iCont).Item("NO_REPASSADOR")
            oRow.Item("CD_FORNECEDOR") = oData_Aux.Rows(iCont).Item("CD_FORNECEDOR")
            oRow.Item("NO_FORNECEDOR") = oData_Aux.Rows(iCont).Item("NO_FORNECEDOR")
            oRow.Item("VL_PAG_AB") = 0
            oRow.Item("VL_JUROS") = 0
            oRow.Item("VL_PAG_AB_JUROS") = 0
            oRow.Item("QT_KG_A_FIXAR") = 0
            oRow.Item("VL_QT_A_FIXAR") = 0
            oRow.Item("VL_CREDITO_GARANTIA") = NVL(oData_Aux.Rows(iCont).Item("VL_CREDITO_TOTAL"), 0) - NVL(oData_Aux.Rows(iCont).Item("VL_CREDITO_PROVISORIO"), 0)
            oRow.Item("VL_CREDITO_PROVISORIO") = NVL(oData_Aux.Rows(iCont).Item("VL_CREDITO_PROVISORIO"), 0)
            oRow.Item("VL_CREDITO_TOTAL") = NVL(oData_Aux.Rows(iCont).Item("VL_CREDITO_TOTAL"), 0)
            oRow.Item("VL_GARANTIA") = oRow.Item("VL_GARANTIA")
            oRow.Item("VL_ICMS_ABERTO") = 0
            oRow.Item("VL_HIPOTECA") = oRow.Item("VL_HIPOTECA")
            oRow.Item("VL_PROMISSORIA") = oRow.Item("VL_PROMISSORIA")
            oRow.Item("VL_CPR") = oRow.Item("VL_CPR")
            oRow.Item("VL_CTR_FIANCA") = oRow.Item("VL_CTR_FIANCA")
            oRow.Item("DT_HIPOTECA") = oRow.Item("DT_HIPOTECA")
            oRow.Item("DT_PROMISSORIA") = oRow.Item("DT_PROMISSORIA")
            oRow.Item("DT_CPR") = oRow.Item("DT_CPR")
            oRow.Item("DT_CTR_FIANCA") = oRow.Item("DT_CTR_FIANCA")
            oRow.Item("CD_SAFRA") = cdSafraAtual

            If Not oRow Is Nothing Then oData.Rows.Add(oRow)
        Next

        'SINTETICO NÃO USA ESSA CONSULTA
        If Not Sintetico Then
            'VERIFICO AS GARANTIAS POR REPASSADOR
            SqlTextGarantias = "SELECT   DECODE (f.cd_repassador, "
            SqlTextGarantias = SqlTextGarantias & "                 NULL, f.cd_fornecedor, "
            SqlTextGarantias = SqlTextGarantias & "                 f.cd_repassador "
            SqlTextGarantias = SqlTextGarantias & "                ) AS cd_repassador, "
            SqlTextGarantias = SqlTextGarantias & "         rep.no_razao_social no_repassador, f.cd_fornecedor, "
            SqlTextGarantias = SqlTextGarantias & "         f.no_razao_social no_fornecedor, "
            SqlTextGarantias = SqlTextGarantias & "         SUM (vl_garantia) AS vl_garantia, fil.cd_filial, fil.no_filial, "
            SqlTextGarantias = SqlTextGarantias & "         SUM (vl_hipoteca) AS vl_hipoteca, SUM (vl_cpr) AS vl_cpr, "
            SqlTextGarantias = SqlTextGarantias & "         SUM (vl_promissoria) AS vl_promissoria, "
            SqlTextGarantias = SqlTextGarantias & "         SUM (vl_ctr_fianca) AS vl_ctr_fianca, dt_hipoteca, dt_cpr, "
            SqlTextGarantias = SqlTextGarantias & "         dt_promissoria, dt_ctr_fianca "
            SqlTextGarantias = SqlTextGarantias & "    FROM (SELECT   g.cd_repassador as cd_fornecedor, "
            SqlTextGarantias = SqlTextGarantias & "                   SUM "
            SqlTextGarantias = SqlTextGarantias & "                      (DECODE (g.vl_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                               NULL, 0, "
            SqlTextGarantias = SqlTextGarantias & "                               DECODE (g.ic_moeda_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                       1, g.vl_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                       DECODE (g.ic_moeda_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                               2, g.vl_garantia * " & TX_DOLAR & ", "
            SqlTextGarantias = SqlTextGarantias & "                                               g.vl_garantia * " & VL_ARROBA & " "
            SqlTextGarantias = SqlTextGarantias & "                                              ) "
            SqlTextGarantias = SqlTextGarantias & "                                      ) "
            SqlTextGarantias = SqlTextGarantias & "                              ) "
            SqlTextGarantias = SqlTextGarantias & "                      ) vl_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                   SUM "
            SqlTextGarantias = SqlTextGarantias & "                      (DECODE (tg.cd_tipo_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                               3, DECODE (g.vl_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                          NULL, 0, "
            SqlTextGarantias = SqlTextGarantias & "                                          DECODE (g.ic_moeda_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                                  1, g.vl_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                                  DECODE (g.ic_moeda_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                                          2, g.vl_garantia "
            SqlTextGarantias = SqlTextGarantias & "                                                           * " & TX_DOLAR & ", "
            SqlTextGarantias = SqlTextGarantias & "                                                          g.vl_garantia "
            SqlTextGarantias = SqlTextGarantias & "                                                          * " & VL_ARROBA & " "
            SqlTextGarantias = SqlTextGarantias & "                                                         ) "
            SqlTextGarantias = SqlTextGarantias & "                                                 ) "
            SqlTextGarantias = SqlTextGarantias & "                                         ), "
            SqlTextGarantias = SqlTextGarantias & "                               0 "
            SqlTextGarantias = SqlTextGarantias & "                              ) "
            SqlTextGarantias = SqlTextGarantias & "                      ) vl_hipoteca, "
            SqlTextGarantias = SqlTextGarantias & "                   SUM "
            SqlTextGarantias = SqlTextGarantias & "                      (DECODE (tg.cd_tipo_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                               1, DECODE (g.vl_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                          NULL, 0, "
            SqlTextGarantias = SqlTextGarantias & "                                          DECODE (g.ic_moeda_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                                  1, g.vl_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                                  DECODE (g.ic_moeda_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                                          2, g.vl_garantia "
            SqlTextGarantias = SqlTextGarantias & "                                                           * " & TX_DOLAR & ", "
            SqlTextGarantias = SqlTextGarantias & "                                                          g.vl_garantia "
            SqlTextGarantias = SqlTextGarantias & "                                                          * " & VL_ARROBA & " "
            SqlTextGarantias = SqlTextGarantias & "                                                         ) "
            SqlTextGarantias = SqlTextGarantias & "                                                 ) "
            SqlTextGarantias = SqlTextGarantias & "                                         ), "
            SqlTextGarantias = SqlTextGarantias & "                               0 "
            SqlTextGarantias = SqlTextGarantias & "                              ) "
            SqlTextGarantias = SqlTextGarantias & "                      ) vl_promissoria, "
            SqlTextGarantias = SqlTextGarantias & "                   SUM "
            SqlTextGarantias = SqlTextGarantias & "                      (DECODE (tg.cd_tipo_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                               2, DECODE (g.vl_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                          NULL, 0, "
            SqlTextGarantias = SqlTextGarantias & "                                          DECODE (g.ic_moeda_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                                  1, g.vl_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                                  DECODE (g.ic_moeda_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                                          2, g.vl_garantia "
            SqlTextGarantias = SqlTextGarantias & "                                                           * " & TX_DOLAR & ", "
            SqlTextGarantias = SqlTextGarantias & "                                                          g.vl_garantia "
            SqlTextGarantias = SqlTextGarantias & "                                                          * " & VL_ARROBA & " "
            SqlTextGarantias = SqlTextGarantias & "                                                         ) "
            SqlTextGarantias = SqlTextGarantias & "                                                 ) "
            SqlTextGarantias = SqlTextGarantias & "                                         ), "
            SqlTextGarantias = SqlTextGarantias & "                               0 "
            SqlTextGarantias = SqlTextGarantias & "                              ) "
            SqlTextGarantias = SqlTextGarantias & "                      ) vl_cpr, "
            SqlTextGarantias = SqlTextGarantias & "                   SUM "
            SqlTextGarantias = SqlTextGarantias & "                      (DECODE (tg.cd_tipo_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                               6, DECODE (g.vl_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                          NULL, 0, "
            SqlTextGarantias = SqlTextGarantias & "                                          DECODE (g.ic_moeda_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                                  1, g.vl_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                                  DECODE (g.ic_moeda_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                                          2, g.vl_garantia "
            SqlTextGarantias = SqlTextGarantias & "                                                           * " & TX_DOLAR & ", "
            SqlTextGarantias = SqlTextGarantias & "                                                          g.vl_garantia "
            SqlTextGarantias = SqlTextGarantias & "                                                          * " & VL_ARROBA & " "
            SqlTextGarantias = SqlTextGarantias & "                                                         ) "
            SqlTextGarantias = SqlTextGarantias & "                                                 ) "
            SqlTextGarantias = SqlTextGarantias & "                                         ), "
            SqlTextGarantias = SqlTextGarantias & "                               0 "
            SqlTextGarantias = SqlTextGarantias & "                              ) "
            SqlTextGarantias = SqlTextGarantias & "                      ) vl_ctr_fianca, "
            SqlTextGarantias = SqlTextGarantias & "                   MIN (DECODE (tg.cd_tipo_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                2, g.dt_garantia_validade "
            SqlTextGarantias = SqlTextGarantias & "                               ) "
            SqlTextGarantias = SqlTextGarantias & "                       ) AS dt_cpr, "
            SqlTextGarantias = SqlTextGarantias & "                   MIN (DECODE (tg.cd_tipo_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                6, g.dt_garantia_validade "
            SqlTextGarantias = SqlTextGarantias & "                               ) "
            SqlTextGarantias = SqlTextGarantias & "                       ) AS dt_ctr_fianca, "
            SqlTextGarantias = SqlTextGarantias & "                   MIN (DECODE (tg.cd_tipo_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                1, g.dt_garantia_validade "
            SqlTextGarantias = SqlTextGarantias & "                               ) "
            SqlTextGarantias = SqlTextGarantias & "                       ) AS dt_promissoria, "
            SqlTextGarantias = SqlTextGarantias & "                   MIN (DECODE (tg.cd_tipo_garantia, "
            SqlTextGarantias = SqlTextGarantias & "                                3, g.dt_garantia_validade "
            SqlTextGarantias = SqlTextGarantias & "                               ) "
            SqlTextGarantias = SqlTextGarantias & "                       ) AS dt_hipoteca "
            SqlTextGarantias = SqlTextGarantias & "              FROM  sof.tipo_garantia tg, "
            SqlTextGarantias = SqlTextGarantias & "                   sof.garantia g "
            SqlTextGarantias = SqlTextGarantias & "             WHERE g.cd_tipo_garantia = tg.cd_tipo_garantia "
            SqlTextGarantias = SqlTextGarantias & "               AND tg.ic_garantido = 'S' "
            SqlTextGarantias = SqlTextGarantias & "               and g.cd_tipo_status  ='A' "
            SqlTextGarantias = SqlTextGarantias & "          GROUP BY g.cd_repassador ) cred, "
            SqlTextGarantias = SqlTextGarantias & "         sof.fornecedor f, "
            SqlTextGarantias = SqlTextGarantias & "         sof.fornecedor rep, "
            SqlTextGarantias = SqlTextGarantias & "         sof.filial fil "
            SqlTextGarantias = SqlTextGarantias & "   WHERE f.cd_fornecedor = cred.cd_fornecedor "
            SqlTextGarantias = SqlTextGarantias & "     AND DECODE (f.cd_repassador, NULL, f.cd_fornecedor, f.cd_repassador) = "
            SqlTextGarantias = SqlTextGarantias & "                                                             rep.cd_fornecedor "
            SqlTextGarantias = SqlTextGarantias & "     AND rep.cd_filial_origem = fil.cd_filial "

            'FILTRO FILIAL
            If Trim(Lista_Filial) <> "" Then
                SqlTextGarantias = SqlTextGarantias & " AND Fil.cd_filial in (" & Lista_Filial & ")"
            Else
                SqlTextGarantias = SqlTextGarantias & " AND Fil.cd_filial in (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If

            SqlTextGarantias = SqlTextGarantias & "     AND (cred.vl_garantia <> 0 "
            SqlTextGarantias = SqlTextGarantias & "         ) "
            SqlTextGarantias = SqlTextGarantias & "GROUP BY f.cd_repassador, "
            SqlTextGarantias = SqlTextGarantias & "         rep.no_razao_social, "
            SqlTextGarantias = SqlTextGarantias & "         f.cd_fornecedor, "
            SqlTextGarantias = SqlTextGarantias & "         f.no_razao_social, "
            SqlTextGarantias = SqlTextGarantias & "         fil.cd_filial, "
            SqlTextGarantias = SqlTextGarantias & "         fil.no_filial, "
            SqlTextGarantias = SqlTextGarantias & "         dt_hipoteca, "
            SqlTextGarantias = SqlTextGarantias & "         dt_cpr, "
            SqlTextGarantias = SqlTextGarantias & "         dt_promissoria, "
            SqlTextGarantias = SqlTextGarantias & "         dt_ctr_fianca "

            oData_Aux = DBQuery(SqlTextGarantias)

            For iCont = 0 To oData_Aux.Rows.Count - 1
                'oRow = oData.Rows.Find(New Object() {oData_Aux.Rows(iCont).Item("CD_FORNECEDOR")})
                oRow = Nothing
                If oRow Is Nothing Then oRow = oData.NewRow

                oRow.Item("CD_FILIAL") = oData_Aux.Rows(iCont).Item("CD_FILIAL")
                oRow.Item("NO_FILIAL") = oData_Aux.Rows(iCont).Item("NO_FILIAL")
                oRow.Item("CD_REPASSADOR") = oData_Aux.Rows(iCont).Item("CD_REPASSADOR")
                oRow.Item("NO_REPASSADOR") = oData_Aux.Rows(iCont).Item("NO_REPASSADOR")
                oRow.Item("CD_FORNECEDOR") = oData_Aux.Rows(iCont).Item("CD_FORNECEDOR")
                oRow.Item("NO_FORNECEDOR") = oData_Aux.Rows(iCont).Item("NO_FORNECEDOR")
                oRow.Item("VL_PAG_AB") = NVL(oRow.Item("VL_PAG_AB"), 0) + 0
                oRow.Item("VL_JUROS") = NVL(oRow.Item("VL_JUROS"), 0) + 0
                oRow.Item("VL_PAG_AB_JUROS") = NVL(oRow.Item("VL_PAG_AB_JUROS"), 0) + 0
                oRow.Item("QT_KG_A_FIXAR") = NVL(oRow.Item("QT_KG_A_FIXAR"), 0) + 0
                oRow.Item("VL_QT_A_FIXAR") = NVL(oRow.Item("VL_QT_A_FIXAR"), 0) + 0
                oRow.Item("VL_CREDITO_GARANTIA") = NVL(oRow.Item("VL_CREDITO_GARANTIA"), 0) + 0
                oRow.Item("VL_CREDITO_PROVISORIO") = NVL(oRow.Item("VL_CREDITO_PROVISORIO"), 0) + 0
                oRow.Item("VL_CREDITO_TOTAL") = NVL(oRow.Item("VL_CREDITO_TOTAL"), 0) + 0
                oRow.Item("VL_GARANTIA") = NVL(oData_Aux.Rows(iCont).Item("VL_GARANTIA"), 0)
                oRow.Item("VL_ICMS_ABERTO") = NVL(oRow.Item("VL_ICMS_ABERTO"), 0) + 0
                oRow.Item("VL_HIPOTECA") = NVL(oData_Aux.Rows(iCont).Item("VL_HIPOTECA"), 0)
                oRow.Item("VL_PROMISSORIA") = NVL(oData_Aux.Rows(iCont).Item("VL_PROMISSORIA"), 0)
                oRow.Item("VL_CPR") = NVL(oData_Aux.Rows(iCont).Item("VL_CPR"), 0)
                oRow.Item("VL_CTR_FIANCA") = NVL(oData_Aux.Rows(iCont).Item("VL_CTR_FIANCA"), 0)
                oRow.Item("DT_HIPOTECA") = oData_Aux.Rows(iCont).Item("DT_HIPOTECA")
                oRow.Item("DT_PROMISSORIA") = oData_Aux.Rows(iCont).Item("DT_PROMISSORIA")
                oRow.Item("DT_CPR") = oData_Aux.Rows(iCont).Item("DT_CPR")
                oRow.Item("DT_CTR_FIANCA") = oData_Aux.Rows(iCont).Item("DT_CTR_FIANCA")

                If Not oRow Is Nothing Then oData.Rows.Add(oRow)
            Next
        End If

        'Crio as colunas para distinção do tipo de operação
        oData.Columns.Add("NO_TIPO_OPERACAO").DataType = System.Type.GetType("System.String")
        oData.Columns.Add("CD_TIPO_OPERACAO").DataType = System.Type.GetType("System.String")

        'EXCLUO O POSITIVOS SE  SO NEGATIVO ESTIVER ATIVO E OS QUE ESTÃO ZERADOS
        Dim iCont1 As Integer
        Dim cRepassador As New Collection
        Dim dRetorno As Double

        iCont = 0

        oData_Aux = New DataTable
        oData_Aux = oData.Clone

        'Guarda os códigos dos repassadores
        For iCont = 0 To oData.Rows.Count - 1
            With oData.Rows(iCont)
                'Crio as colunas para distinção do tipo de operação - Inicio
                If NVL(.Item("DT_VENCIMENTO"), Now.Date) < Now.Date Then
                    If NVL(.Item("CD_TIPO"), 0) > 4 Then
                        If NVL(.Item("CD_TIPO"), 0) = 43 Then
                            .Item("CD_TIPO_OPERACAO") = cnt_NetSales_Operacao_Juridico_Cod
                            .Item("NO_TIPO_OPERACAO") = cnt_NetSales_Operacao_Juridico
                        Else
                            If NVL(.Item("CD_TIPO"), 0) = 44 Then
                                .Item("CD_TIPO_OPERACAO") = cnt_NetSales_Operacao_VencidoContrato_Cod
                                .Item("NO_TIPO_OPERACAO") = cnt_NetSales_Operacao_VencidoContrato
                            Else
                                .Item("CD_TIPO_OPERACAO") = cnt_NetSales_Operacao_VencidoRenegociado_Cod
                                .Item("NO_TIPO_OPERACAO") = cnt_NetSales_Operacao_VencidoRenegociado
                            End If
                        End If
                    Else
                        .Item("CD_TIPO_OPERACAO") = cnt_NetSales_Operacao_VencidoContrato_Cod
                        .Item("NO_TIPO_OPERACAO") = cnt_NetSales_Operacao_VencidoContrato
                    End If
                Else
                    If NVL(.Item("CD_TIPO"), 0) > 4 Then
                        If NVL(.Item("CD_TIPO"), 0) = 43 Then
                            .Item("CD_TIPO_OPERACAO") = cnt_NetSales_Operacao_Juridico_Cod
                            .Item("NO_TIPO_OPERACAO") = cnt_NetSales_Operacao_Juridico
                        Else
                            If NVL(.Item("CD_TIPO"), 0) = 44 Then
                                .Item("CD_TIPO_OPERACAO") = cnt_NetSales_Operacao_AVencerContrato_Cod
                                .Item("NO_TIPO_OPERACAO") = cnt_NetSales_Operacao_AVencerContrato
                            Else
                                .Item("CD_TIPO_OPERACAO") = cnt_NetSales_Operacao_AVencerRenegociado_Cod
                                .Item("NO_TIPO_OPERACAO") = cnt_NetSales_Operacao_AVencerRenegociado
                            End If
                        End If
                    Else
                        .Item("CD_TIPO_OPERACAO") = cnt_NetSales_Operacao_AVencerContrato_Cod
                        .Item("NO_TIPO_OPERACAO") = cnt_NetSales_Operacao_AVencerContrato
                    End If
                End If
            End With
            'Crio as colunas para distinção do tipo de operação - Fim

            If Not cRepassador.Contains("K" & oData.Rows(iCont).Item("CD_REPASSADOR")) Then
                cRepassador.Add(oData.Rows(iCont).Item("CD_REPASSADOR"), "K" & oData.Rows(iCont).Item("CD_REPASSADOR"))
            End If
        Next

        For iCont = 1 To cRepassador.Count
            dRetorno = oData.Compute("SUM(VL_QT_A_FIXAR) - SUM(VL_PAG_AB_JUROS)", _
                                     "CD_REPASSADOR = " & cRepassador.Item(iCont))

            If Not ((SomenteNegativos And dRetorno >= 0) Or (dRetorno = 0)) Then
                For iCont1 = 0 To oData.Rows.Count - 1
                    If oData.Rows(iCont1).Item("CD_REPASSADOR") = cRepassador.Item(iCont) Then
                        oData_Aux.Rows.Add(oData.Rows(iCont1).ItemArray)
                    End If
                Next
            End If
        Next

        oData.Dispose()
        oData = Nothing

        Return oData_Aux
    End Function

    Public Sub Relatorio_PegaValor(ByRef DT_COTACAO As Date, _
                                   ByRef TX_DOLAR As Double, _
                                   ByRef VL_BOLSA As Double, _
                                   ByRef VL_ARROBA As Double)
        Dim SqlText As String

        SqlText = "SELECT MAX(LCM.DT_COTACAO) DT_COTACAO " & _
                  " FROM SOF.LIMITE_CREDITO_MOEDA LCM " & _
                  " WHERE LCM.DT_COTACAO <= TO_DATE(" & QuotedStr(Date_to_Oracle(DataSistema)) & ")"
        DT_COTACAO = DBQuery_ValorUnico(SqlText)

        SqlText = "SELECT LCM.VL_TAXA " & _
                  " FROM SOF.LIMITE_CREDITO_MOEDA LCM" & _
                  " WHERE LCM.DT_COTACAO = TO_DATE(" & QuotedStr(Date_to_Oracle(DT_COTACAO)) & ")" & _
                    " AND LCM.CD_TIPO_MOEDA = " & cnt_LimiteCreditoTipoMoeda_Dolar
        TX_DOLAR = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT LCM.VL_TAXA" & _
                  " FROM SOF.LIMITE_CREDITO_MOEDA LCM" & _
                  " WHERE LCM.DT_COTACAO = TO_DATE(" & QuotedStr(Date_to_Oracle(DT_COTACAO)) & ")" & _
                    " AND LCM.CD_TIPO_MOEDA = " & cnt_LimiteCreditoTipoMoeda_Bolsa
        VL_BOLSA = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT PC.VL_PRECO" & _
                  " FROM SOF.PRECO_CACAU PC" & _
                  " WHERE PC.DT_COTACAO = TO_DATE(" & QuotedStr(Date_to_Oracle(DT_COTACAO)) & ")"
        VL_ARROBA = DBQuery_ValorUnico(SqlText, 0)
    End Sub

    Public Function Gera_Rs_ContratoEmAberto_CtrPAF(Optional ByVal CD_FORNECEDOR As Integer = 0, _
                                                    Optional ByVal ListaFilial As String = "", _
                                                    Optional ByVal ListaTipoContrato As String = "", _
                                                    Optional ByVal Opcao As String = "") As DataTable
        Dim SqlText As String
        Dim VlDolar As Double
        Dim VlPreco As Double

        SqlText = "SELECT LCM.VL_TAXA" & _
                  " FROM SOF.LIMITE_CREDITO_MOEDA LCM" & _
                  " WHERE LCM.DT_COTACAO IN (SELECT MAX(DT_COTACAO) From SOF.LIMITE_CREDITO_MOEDA WHERE CD_TIPO_MOEDA = 1)" & _
                    " AND LCM.CD_TIPO_MOEDA = 1"
        VlDolar = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT PC.VL_PRECO" & _
                  " FROM SOF.PRECO_CACAU PC" & _
                  " WHERE PC.DT_COTACAO IN (SELECT MAX(DT_COTACAO) FROM SOF.PRECO_CACAU)"
        VlPreco = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT * "
        SqlText = SqlText & "  FROM (SELECT cp.cd_contrato_paf, cp.dt_contrato_paf, cp.dt_prazo_entrega, "
        SqlText = SqlText & "               f.no_razao_social, cp.qt_kgs, cp.qt_kg_fixo, "
        SqlText = SqlText & "               NVL (rec.qt_fazenda, 0) qt_fazenda, "
        SqlText = SqlText & "               NVL (rec.qt_filial, 0) qt_filial, "
        SqlText = SqlText & "               NVL (rec.qt_fabrica, 0) qt_fabrica, cp.vl_pag_fixo, "
        SqlText = SqlText & "               NVL (pag.vl_pag_ab, 0) vl_pag_ab, cp.qt_a_negociar, "
        SqlText = SqlText & "               cp.qt_cancelado, "
        SqlText = SqlText & "               (cp.qt_kgs - cp.qt_cancelado - cp.qt_kg_fixo) qt_saldo, "
        SqlText = SqlText & "               tcp.no_tipo_contrato_paf, f.cd_filial_origem, fil.no_filial, "
        SqlText = SqlText & "               cp.cd_fornecedor, NVL (lc.limite_total, 0) vl_garantia, "
        SqlText = SqlText & "               NVL (pag.vl_pag_ab_juros, 0) vl_pag_ab_juros, "
        SqlText = SqlText & "               cp.dt_prazo_fixacao "
        SqlText = SqlText & "          FROM sof.tipo_contrato_paf tcp, "
        SqlText = SqlText & "               sof.filial fil, "
        SqlText = SqlText & "               sof.contrato_paf cp, "
        SqlText = SqlText & "               sof.fornecedor f, "
        SqlText = SqlText & "               (SELECT   NVL "
        SqlText = SqlText & "                            (SUM (DECODE (NVL (m.cd_local_entrega, 3), "
        SqlText = SqlText & "                                          1, cpm.qt_kg_a_fixar, "
        SqlText = SqlText & "                                          0 "
        SqlText = SqlText & "                                         ) "
        SqlText = SqlText & "                                 ), "
        SqlText = SqlText & "                             0 "
        SqlText = SqlText & "                            ) qt_fazenda, "
        SqlText = SqlText & "                         NVL "
        SqlText = SqlText & "                            (SUM (DECODE (NVL (m.cd_local_entrega, 3), "
        SqlText = SqlText & "                                          2, cpm.qt_kg_a_fixar, "
        SqlText = SqlText & "                                          0 "
        SqlText = SqlText & "                                         ) "
        SqlText = SqlText & "                                 ), "
        SqlText = SqlText & "                             0 "
        SqlText = SqlText & "                            ) qt_filial, "
        SqlText = SqlText & "                         NVL "
        SqlText = SqlText & "                            (SUM (DECODE (NVL (m.cd_local_entrega, 3), "
        SqlText = SqlText & "                                          3, cpm.qt_kg_a_fixar, "
        SqlText = SqlText & "                                          0 "
        SqlText = SqlText & "                                         ) "
        SqlText = SqlText & "                                 ), "
        SqlText = SqlText & "                             0 "
        SqlText = SqlText & "                            ) qt_fabrica, "
        SqlText = SqlText & "                         cp.cd_contrato_paf "
        SqlText = SqlText & "                    FROM sof.ctr_paf_movimentacao cpm, "
        SqlText = SqlText & "                         sof.contrato_paf cp, "
        SqlText = SqlText & "                         sof.movimentacao m "
        SqlText = SqlText & "                   WHERE m.sq_movimentacao = cpm.sq_movimentacao "
        SqlText = SqlText & "                     AND cpm.cd_contrato_paf = cp.cd_contrato_paf "
        SqlText = SqlText & "                     AND cpm.qt_kg_a_fixar <> 0 "
        SqlText = SqlText & "                GROUP BY cp.cd_contrato_paf) rec, "
        SqlText = SqlText & "               (SELECT   ROUND(SUM "
        SqlText = SqlText & "                            (DECODE "
        SqlText = SqlText & "                                (cp.ic_calcula_juros || tp.ic_calcula_juros, "
        SqlText = SqlText & "                                 'SS', (  (  DECODE "
        SqlText = SqlText & "                                                (SIGN "
        SqlText = SqlText & "                                                    (  (  SYSDATE "
        SqlText = SqlText & "                                                        - p.dt_pagamento "
        SqlText = SqlText & "                                                       ) "
        SqlText = SqlText & "                                                     - NVL "
        SqlText = SqlText & "                                                          (cp.qt_dia_carencia_juros, "
        SqlText = SqlText & "                                                           0 "
        SqlText = SqlText & "                                                          ) "
        SqlText = SqlText & "                                                    ), "
        SqlText = SqlText & "                                                 -1, 0, "
        SqlText = SqlText & "                                                 ROUND "
        SqlText = SqlText & "                                                    ((  (  TO_DATE (SYSDATE) "
        SqlText = SqlText & "                                                         - TO_DATE "
        SqlText = SqlText & "                                                               (p.dt_pagamento) "
        SqlText = SqlText & "                                                        ) "
        SqlText = SqlText & "                                                      - DECODE "
        SqlText = SqlText & "                                                           (NVL "
        SqlText = SqlText & "                                                               (cp.ic_juros_apos_carencia, "
        SqlText = SqlText & "                                                                'N' "
        SqlText = SqlText & "                                                               ), "
        SqlText = SqlText & "                                                            'S', NVL "
        SqlText = SqlText & "                                                               (cp.qt_dia_carencia_juros, "
        SqlText = SqlText & "                                                                0 "
        SqlText = SqlText & "                                                               ), "
        SqlText = SqlText & "                                                            0 "
        SqlText = SqlText & "                                                           ) "
        SqlText = SqlText & "                                                     ), "
        SqlText = SqlText & "                                                     0 "
        SqlText = SqlText & "                                                    ) "
        SqlText = SqlText & "                                                ) "
        SqlText = SqlText & "                                           * (  (  NVL (cp.pc_taxa_juros, 0) "
        SqlText = SqlText & "                                                 / 100 "
        SqlText = SqlText & "                                                ) "
        SqlText = SqlText & "                                              / 30 "
        SqlText = SqlText & "                                             ) "
        SqlText = SqlText & "                                          ) "
        SqlText = SqlText & "                                        * pcp.vl_a_fixar "
        SqlText = SqlText & "                                     ) "
        SqlText = SqlText & "                                  + pcp.vl_a_fixar, "
        SqlText = SqlText & "                                 pcp.vl_a_fixar "
        SqlText = SqlText & "                                ) "
        SqlText = SqlText & "                            ), 8) vl_pag_ab_juros, "
        SqlText = SqlText & "                         NVL (SUM (pcp.vl_a_fixar), 0) vl_pag_ab, "
        SqlText = SqlText & "                         cp.cd_contrato_paf "
        SqlText = SqlText & "                    FROM sof.pag_ctr_paf pcp, "
        SqlText = SqlText & "                         sof.pagamentos p, "
        SqlText = SqlText & "                         sof.contrato_paf cp, "
        SqlText = SqlText & "                         sof.tipo_pagamento tp "
        SqlText = SqlText & "                   WHERE pcp.cd_contrato_paf = cp.cd_contrato_paf "
        SqlText = SqlText & "                     AND pcp.sq_pagamento = p.sq_pagamento "
        SqlText = SqlText & "                     AND pcp.vl_a_fixar <> 0 "
        SqlText = SqlText & "                     AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
        SqlText = SqlText & "                GROUP BY cp.cd_contrato_paf) pag, "
        SqlText = SqlText & "               (SELECT   lc.cd_fornecedor, "
        SqlText = SqlText & "                         (SUM (DECODE (lc.ic_moeda_credito, "
        SqlText = SqlText & "                                       'S', lc.vl_credito * 4 * " & VlPreco & ", "
        SqlText = SqlText & "                                       'D', lc.vl_credito * " & VlDolar & ", "
        SqlText = SqlText & "                                       'R', lc.vl_credito "
        SqlText = SqlText & "                                      ) "
        SqlText = SqlText & "                              ) "
        SqlText = SqlText & "                         ) AS limite_total "
        SqlText = SqlText & "                    FROM sof.limite_credito lc "
        SqlText = SqlText & "                   WHERE lc.cd_tipo_status = 'A' "
        SqlText = SqlText & "                GROUP BY lc.cd_fornecedor) lc "
        SqlText = SqlText & "         WHERE f.cd_fornecedor = cp.cd_fornecedor "
        SqlText = SqlText & "           AND cp.cd_tipo_contrato_paf = tcp.cd_tipo_contrato_paf "
        SqlText = SqlText & "           AND f.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "           AND cp.cd_contrato_paf = rec.cd_contrato_paf(+) "
        SqlText = SqlText & "           AND cp.cd_contrato_paf = pag.cd_contrato_paf(+) "
        SqlText = SqlText & "           AND cp.cd_fornecedor = lc.cd_fornecedor(+) "

        If Trim(ListaFilial) <> "" Then
            SqlText = SqlText & "     AND F.cd_filial_origem IN (" & ListaFilial & ")"
        Else
            SqlText = SqlText & "     AND F.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If
        If Trim(ListaTipoContrato) <> "" Then
            SqlText = SqlText & "     AND CP.CD_TIPO_CONTRATO_PAF IN (" & ListaTipoContrato & ")"
        End If
        If CD_FORNECEDOR > 0 Then
            SqlText = SqlText & "     AND F.cd_fornecedor = " & CD_FORNECEDOR
        End If
        SqlText = SqlText & "           AND cp.ic_status = 'A') "

        Select Case Opcao
            Case cnt_ComboOpcao_Todos
                SqlText = SqlText & " WHERE (QT_SALDO <> 0 OR VL_PAG_AB <> 0 OR " & _
                            "(QT_FAZENDA + QT_FILIAL + QT_FABRICA) <> 0 OR QT_A_NEGOCIAR <> 0)"
            Case cnt_ComboOpcao_ANegociar
                SqlText = SqlText & " WHERE (QT_SALDO <> 0 OR VL_PAG_AB <> 0 OR " & _
                            "(QT_FAZENDA + QT_FILIAL + QT_FABRICA) <> 0) AND QT_A_NEGOCIAR <> 0"
            Case cnt_ComboOpcao_TotalmenteNegociados
                SqlText = SqlText & " WHERE (QT_SALDO <> 0 OR VL_PAG_AB <> 0 OR " & _
                            "(QT_FAZENDA + QT_FILIAL + QT_FABRICA) <> 0) AND QT_A_NEGOCIAR = 0"
            Case cnt_ComboOpcao_TotalmenteNegociados_ComPagamentoAberto
                SqlText = SqlText & " WHERE QT_SALDO = 0 and VL_PAG_AB <> 0 " & _
                            "AND QT_A_NEGOCIAR = 0"
            Case cnt_ComboOpcao_Vencidos
                SqlText = SqlText & " WHERE dt_prazo_entrega < to_date('" & Date_to_Oracle(DataSistema) & "')"
            Case cnt_ComboOpcao_AVencer
                SqlText = SqlText & " WHERE dt_prazo_entrega >= to_date('" & Date_to_Oracle(DataSistema) & "')"
            Case cnt_ComboOpcao_ApenasAdiantamentoAberto
                SqlText = SqlText & " WHERE (QT_SALDO <> 0 OR VL_PAG_AB <> 0 OR " & _
                            "(QT_FAZENDA + QT_FILIAL + QT_FABRICA) <> 0 OR QT_A_NEGOCIAR <> 0) AND VL_PAG_AB <> 0 "
            Case Else
                SqlText = SqlText & " WHERE (   QT_SALDO <> 0 "
                SqlText = SqlText & "        OR VL_PAG_AB <> 0 "
                SqlText = SqlText & "        OR (QT_FAZENDA + QT_FILIAL + QT_FABRICA) <> 0 "
                SqlText = SqlText & "        OR QT_A_NEGOCIAR <> 0 "
                SqlText = SqlText & "       ) "
        End Select

        Return DBQuery(SqlText)
    End Function

    Public Function Gera_Rs_ContratoEmAberto_Neg(Optional ByVal DataInicial As String = Nothing, _
                                                 Optional ByVal DataFinal As String = Nothing, _
                                                 Optional ByVal CD_FORNECEDOR As Integer = 0, _
                                                 Optional ByVal ListaFilial As String = "", _
                                                 Optional ByVal ListaTipoContrato As String = "") As DataTable
        Dim oData As DataTable
        Dim SqlText As String
        Dim CdFormaPagJuros As Long
        Dim JurosCtrFix As Boolean
        Dim JurosNegRec As Boolean

        SqlText = "SELECT P.CD_TP_PAG_JUROS," & _
                         "'N' IC_JUROS_CTR_FIX, " & _
                         "'S' IC_JUROS_NEG_REC" & _
                  " FROM SOF.PARAMETRO P "
        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            CdFormaPagJuros = CLng(NVL(oData.Rows(0).Item("CD_TP_PAG_JUROS"), -1))
            JurosCtrFix = IIf(oData.Rows(0).Item("IC_JUROS_CTR_FIX") = "S", True, False)
            JurosNegRec = IIf(oData.Rows(0).Item("IC_JUROS_NEG_REC") = "S", True, False)
        Else
            CdFormaPagJuros = -1
            JurosCtrFix = False
            JurosNegRec = False
        End If

        SqlText = "SELECT FIL.CD_FILIAL, FIL.NO_FILIAL, N.CD_CONTRATO_PAF, N.SQ_NEGOCIACAO, "
        SqlText = SqlText & "       F.CD_FORNECEDOR, F.NO_RAZAO_SOCIAL, N.QT_KGS, N.QT_CANCELADO, "
        SqlText = SqlText & "       N.QT_KG_FIXO, N.QT_A_FIXAR, N.VL_PAG_FIXO, LE.CD_LOCAL_ENTREGA, "
        SqlText = SqlText & "       LE.NO_LOCAL_ENTREGA, TN.CD_TIPO_NEGOCIACAO, TN.NO_TIPO_NEGOCIACAO, "
        SqlText = SqlText & "       N.DT_NEGOCIACAO, N.DT_VENCIMENTO, N.DT_PRAZO_FIXACAO, N.VL_NEGOCIACAO, "
        SqlText = SqlText & "       N.CD_PAPEL_COMPETENCIA, NVL(P.VL_A_FIXAR,0) VL_A_FIXAR, "
        SqlText = SqlText & "       NVL(M.QT_KG_A_FIXAR,0) QT_KG_A_FIXAR, "

        If JurosCtrFix = False And JurosNegRec = False Then
            SqlText = SqlText & "       NVL(P.vl_a_fixar_juros, 0) VL_JUROS, "
        Else
            SqlText = SqlText & "       ROUND(NVL(P.vl_a_fixar_juros,0),2) - NVL(P.vl_a_fixar_juros,0) VL_JUROS, "
        End If

        SqlText = SqlText & "SOF.FC_INDICE_VALORES(f.CD_TIPO_PESSOA, N.DT_NEGOCIACAO, 16) tx_pis, "
        SqlText = SqlText & "BH.VL_COTACAO AS VL_BOLSA "
        SqlText = SqlText & "FROM SOF.CONTRATO_PAF CP, "
        SqlText = SqlText & "     SOF.NEGOCIACAO N, "
        SqlText = SqlText & "     SOF.FORNECEDOR F, "
        SqlText = SqlText & "     SOF.FILIAL FIL, "
        SqlText = SqlText & "     SOF.LOCAL_ENTREGA LE, "
        SqlText = SqlText & "     SOF.BOLSA_PERIODO_MATRIZ BPM, "
        SqlText = SqlText & "(SELECT B.SQ_BOLSA_PERIODO_MATRIZ," & _
                            "B.VL_COTACAO " & _
                     " FROM SOF.BOLSA_HISTORICO B" & _
                    " WHERE B.DT_BOLSA_HISTORICO = (SELECT MAX(B2.DT_BOLSA_HISTORICO )" & _
                                                   " FROM SOF.BOLSA_HISTORICO B2" & _
                                                   " WHERE B2.VL_COTACAO <> 0 " & _
                                                     " AND B.SQ_BOLSA_PERIODO_MATRIZ = B2.SQ_BOLSA_PERIODO_MATRIZ )) BH, "
        SqlText = SqlText & "     SOF.TIPO_NEGOCIACAO TN, "
        SqlText = SqlText & "     (SELECT PN.CD_CONTRATO_PAF, PN.SQ_NEGOCIACAO, "

        Select Case True
            Case JurosCtrFix
                SqlText = SqlText & "             SUM(DECODE(N.ic_calcula_juros || tp.ic_calcula_juros, 'SS', "
                SqlText = SqlText & "                        ((DECODE(SIGN((SYSDATE - pA.dt_pagamento) - NVL(N.qt_dia_carencia_juros,0)), -1, "
                SqlText = SqlText & "                                 0, "
                SqlText = SqlText & "                                 ROUND(((TO_DATE(SYSDATE) - TO_DATE(pA.dt_pagamento)) - DECODE(N.ic_juros_apos_carencia, 'S', "
                SqlText = SqlText & "                                                                                               NVL(N.qt_dia_carencia_juros, 0), "
                SqlText = SqlText & "                                                                                               0)), 0)) "
                SqlText = SqlText & "                          * ((N.pc_taxa_juros / 100) / 30)) "
                SqlText = SqlText & "                         * pN.vl_a_fixar) "
                SqlText = SqlText & "                        + pN.vl_a_fixar, "
                SqlText = SqlText & "                        pN.vl_a_fixar)) VL_A_FIXAR_juros, "
                SqlText = SqlText & "             NVL(SUM(pN.vl_a_fixar), 0) VL_A_FIXAR "
                SqlText = SqlText & "      FROM SOF.PAG_NEG PN, "
                SqlText = SqlText & "           sof.pagamentos pa, "
                SqlText = SqlText & "           sof.negociacao n, "
                SqlText = SqlText & "           sof.tipo_pagamento tp "
                SqlText = SqlText & "      WHERE PN.VL_A_FIXAR <> 0 and "
                SqlText = SqlText & "            pa.sq_pagamento = pn.sq_pagamento and "
                SqlText = SqlText & "            PN.cd_contrato_paf = N.cd_contrato_paf AND "
                SqlText = SqlText & "            PN.sq_negociacao = N.sq_negociacao AND "
                SqlText = SqlText & "            PA.cd_tipo_pagamento = TP.cd_tipo_pagamento "
            Case JurosNegRec
                SqlText = SqlText & "       ROUND(SUM(DECODE(cp.ic_calcula_juros || tp.ic_calcula_juros, 'SS', "
                SqlText = SqlText & "                        ((DECODE(SIGN((SYSDATE - pA.dt_pagamento) - NVL(cp.qt_dia_carencia_juros,0)), -1, "
                SqlText = SqlText & "                                 0, "
                SqlText = SqlText & "                                 ROUND(((TO_DATE(SYSDATE) - TO_DATE(pA.dt_pagamento)) - DECODE(cp.ic_juros_apos_carencia, 'S', "
                SqlText = SqlText & "                                                                                               NVL(cp.qt_dia_carencia_juros, 0), "
                SqlText = SqlText & "                                                                                               0)), 0)) "
                SqlText = SqlText & "                          * ((cp.pc_taxa_juros / 100) / 30)) "
                SqlText = SqlText & "                         * pN.vl_a_fixar) "
                SqlText = SqlText & "                        + pN.vl_a_fixar, "
                SqlText = SqlText & "                        pN.vl_a_fixar)), 8) VL_A_FIXAR_juros, "
                SqlText = SqlText & "             NVL(SUM(pN.vl_a_fixar), 0) VL_A_FIXAR "
                SqlText = SqlText & "      FROM SOF.PAG_NEG PN, "
                SqlText = SqlText & "           sof.pagamentos pa, "
                SqlText = SqlText & "           sof.negociacao n, "
                SqlText = SqlText & "           sof.tipo_pagamento tp, "
                SqlText = SqlText & "           sof.contrato_paf cp "
                SqlText = SqlText & "      WHERE PN.VL_A_FIXAR <> 0 and "
                SqlText = SqlText & "            N.cd_contrato_paf = cp.cd_contrato_paf AND "
                SqlText = SqlText & "            pa.sq_pagamento = pn.sq_pagamento and "
                SqlText = SqlText & "            PN.cd_contrato_paf = N.cd_contrato_paf AND "
                SqlText = SqlText & "            PN.sq_negociacao = N.sq_negociacao AND "
                SqlText = SqlText & "            PA.cd_tipo_pagamento = TP.cd_tipo_pagamento "
            Case Else
                SqlText = SqlText & "             SUM(decode(pa.cd_tipo_pagamento," & CdFormaPagJuros & ",0,pn.vl_a_fixar)) VL_A_FIXAR, "
                SqlText = SqlText & "             SUM(decode(pa.cd_tipo_pagamento," & CdFormaPagJuros & ",pn.vl_a_fixar,0)) VL_A_FIXAR_JUROS "
                SqlText = SqlText & "      FROM SOF.PAG_NEG PN, "
                SqlText = SqlText & "           sof.pagamentos pa "
                SqlText = SqlText & "      WHERE PN.VL_A_FIXAR <> 0 and "
                SqlText = SqlText & "            pa.sq_pagamento = pn.sq_pagamento "
        End Select

        SqlText = SqlText & "      GROUP BY PN.CD_CONTRATO_PAF, PN.SQ_NEGOCIACAO) P, "
        SqlText = SqlText & "     (SELECT CM.CD_CONTRATO_PAF, CM.SQ_NEGOCIACAO, "
        SqlText = SqlText & "             SUM(CM.QT_KG_A_FIXAR) QT_KG_A_FIXAR "
        SqlText = SqlText & "      FROM SOF.CTR_PAF_NEG_MOVIMENTACAO CM "
        SqlText = SqlText & "      WHERE CM.QT_KG_A_FIXAR <> 0 "
        SqlText = SqlText & "      GROUP BY CM.CD_CONTRATO_PAF, CM.SQ_NEGOCIACAO) M "
        SqlText = SqlText & "WHERE CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "      F.CD_FORNECEDOR = CP.CD_FORNECEDOR AND "
        SqlText = SqlText & "      FIL.CD_FILIAL = F.CD_FILIAL_ORIGEM AND "
        SqlText = SqlText & "      LE.CD_LOCAL_ENTREGA = N.CD_LOCAL_ENTREGA AND "
        SqlText = SqlText & "      TN.CD_TIPO_NEGOCIACAO = N.CD_TIPO_NEGOCIACAO AND "
        SqlText = SqlText & "      N.CD_CONTRATO_PAF = P.CD_CONTRATO_PAF (+) AND "
        SqlText = SqlText & "      N.SQ_NEGOCIACAO = P.SQ_NEGOCIACAO (+) AND "
        SqlText = SqlText & "      N.CD_CONTRATO_PAF = M.CD_CONTRATO_PAF (+) AND "
        SqlText = SqlText & "      N.SQ_NEGOCIACAO = M.SQ_NEGOCIACAO (+) AND "
        SqlText = SqlText & "      N.CD_PAPEL_COMPETENCIA = BPM.CD_PAPEL (+) AND "
        SqlText = SqlText & "      BPM.SQ_BOLSA_PERIODO_MATRIZ = BH.SQ_BOLSA_PERIODO_MATRIZ (+)AND "
        SqlText = SqlText & "      N.IC_STATUS = 'A' "

        If IsDate(DataInicial) Then
            SqlText = SqlText & " AND TRUNC(N.DT_NEGOCIACAO) >= " & QuotedStr(Date_to_Oracle(DataInicial))
        End If
        If IsDate(DataFinal) Then
            SqlText = SqlText & " AND TRUNC(N.DT_NEGOCIACAO) <= " & QuotedStr(Date_to_Oracle(DataFinal))
        End If
        If Trim(ListaFilial) <> "" Then
            SqlText = SqlText & "     AND F.cd_filial_origem IN (" & ListaFilial & ")"
        Else
            SqlText = SqlText & "     AND F.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If
        If Trim(ListaTipoContrato) <> "" Then
            SqlText = SqlText & "     AND  N.CD_TIPO_NEGOCIACAO IN (" & ListaTipoContrato & ")"
        End If
        If CD_FORNECEDOR > 0 Then
            SqlText = SqlText & "     AND F.cd_fornecedor =" & CD_FORNECEDOR
        End If

        Return DBQuery(SqlText)
    End Function

    Public Function Gera_Rs_ContratoEmAberto_CtrFixo(ByVal DataInicial As String, _
                                                     ByVal DataFinal As String, _
                                                     Optional ByVal CD_FORNECEDOR As Integer = 0, _
                                                     Optional ByVal ListaFilial As String = "") As DataTable
        Dim SqlText As String

        SqlText = "SELECT /*+ USE_HASH (CP) USE_HASH (CF) */" & _
                         "FORN.NO_RAZAO_SOCIAL," & _
                         "CF.CD_CONTRATO_PAF CD_CONTRATO," & _
                         "CF.DT_CONTRATO_FIXO DT_CONTRATO," & _
                         "CF.DT_VENCIMENTO," & _
                         "CF.QT_KGS," & _
                         "CF.VL_UNITARIO," & _
                         "CF.PC_ALIQ_ICMS," & _
                         "CF.CD_TIPO_UNIDADE," & _
                         "FORN.CD_FILIAL_ORIGEM," & _
                         "REP.NO_RAZAO AS NO_REPRESENTANTE," & _
                         "DECODE (CP.CD_FORNECEDOR,  CP.CD_REPASSADOR, NULL, REPA.NO_RAZAO_SOCIAL) AS NO_REPASSADOR," & _
                         "FIL.NO_FILIAL," & _
                         "(CF.VL_TOTAL + DECODE(CF.IC_INCLUI_ICMS_PAG, 'S', CF.VL_ICMS, 0)) VL_TOTAL," & _
                         "FORN.CD_TIPO_PESSOA," & _
                         "CF.VL_PAG_FIXO VL_PAG," & _
                         "CF.QT_KG_FIXO QT_REC," & _
                         "PAR.DT_SISTEMA," & _
                         "(CF.VL_ADENDO + DECODE(CF.IC_INCLUI_ICMS_PAG, 'S', CF.VL_ADENDO_ICMS, 0)) VL_ADENDO_CONTRATO," & _
                         "CF.SQ_NEGOCIACAO," & _
                         "CF.SQ_CONTRATO_FIXO," & _
                         "CF.QT_CANCELADO," & _
                         "TN.CD_TIPO_NEGOCIACAO," & _
                         "TN.NO_TIPO_NEGOCIACAO," & _
                         "CF.ic_gp," & _
                         "CF.dt_vencimento_gp" & _
                  " FROM SOF.PARAMETRO PAR," & _
                        "SOF.REPRESENTANTE REP," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.FORNECEDOR FORN," & _
                        "SOF.FORNECEDOR REPA," & _
                        "SOF.CONTRATO_FIXO CF," & _
                        "SOF.NEGOCIACAO N," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "SOF.TIPO_NEGOCIACAO TN" & _
                  " WHERE FORN.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND CP.CD_REPASSADOR = REPA.CD_FORNECEDOR" & _
                    " AND CP.CD_FORNECEDOR = FORN.CD_FORNECEDOR" & _
                    " AND CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                    " AND N.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                    " AND N.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO" & _
                    " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                    " AND FORN.CD_REPRESENTANTE = REP.CD_REPRESENTANTE(+)" & _
                    " AND CF.IC_STATUS IN ('A', 'D')" & _
                    " AND (CF.QT_KGS <> CF.QT_KG_FIXO OR " & _
                           "SOF.FC_SALDO_CTR_FIX (CF.CD_CONTRATO_PAF," & _
                                                 "CF.SQ_NEGOCIACAO," & _
                                                 "CF.SQ_CONTRATO_FIXO) <> CF.VL_PAG_FIXO)"

        If IsDate(DataInicial) Then
            SqlText = SqlText & " AND TRUNC(CF.DT_CONTRATO_FIXO) >= " & QuotedStr(Date_to_Oracle(DataInicial))
        End If
        If IsDate(DataFinal) Then
            SqlText = SqlText & " AND TRUNC(CF.DT_CONTRATO_FIXO) <= " & QuotedStr(Date_to_Oracle(DataFinal))
        End If
        If Trim(ListaFilial) <> "" Then
            SqlText = SqlText & "     AND FORN.CD_FILIAL_ORIGEM IN (" & ListaFilial & ")"
        Else
            SqlText = SqlText & "     AND FORN.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If
        If CD_FORNECEDOR > 0 Then
            SqlText = SqlText & "     AND FORN.CD_FORNECEDOR = " & CD_FORNECEDOR
        End If

        Return DBQuery(SqlText)
    End Function

    Public Function Gera_Rs_ContratoEmAberto_Resumo(Optional ByVal CD_FORNECEDOR As Integer = 0, _
                                                    Optional ByVal ListaFilial As String = "") As DataTable
        Dim SqlText As String

        SqlText = "SELECT /*+ ORDERED USE_NL (cp) */ "
        SqlText = SqlText & "       forn.no_razao_social, cf.cd_contrato_paf AS cd_contrato, "
        SqlText = SqlText & "       cf.dt_contrato_fixo AS dt_contrato, cf.dt_vencimento, "
        SqlText = SqlText & "       (cf.qt_kgs -  cf.qt_cancelado "
        SqlText = SqlText & "       ) qt_kgs, "
        SqlText = SqlText & "       cf.vl_unitario, cf.cd_tipo_unidade, forn.cd_filial_origem, "
        SqlText = SqlText & "       DECODE (cp.cd_fornecedor, "
        SqlText = SqlText & "               cp.cd_repassador, DECODE (forn.cd_tipo_pessoa, "
        SqlText = SqlText & "                                         5, rep.no_razao_social, "
        SqlText = SqlText & "                                         NULL "
        SqlText = SqlText & "                                        ), "
        SqlText = SqlText & "               rep.no_razao_social "
        SqlText = SqlText & "              ) AS no_representante, "
        SqlText = SqlText & "       DECODE (cp.cd_fornecedor, "
        SqlText = SqlText & "               cp.cd_repassador, DECODE (forn.cd_tipo_pessoa, "
        SqlText = SqlText & "                                         5, cp.cd_repassador, "
        SqlText = SqlText & "                                         NULL "
        SqlText = SqlText & "                                        ), "
        SqlText = SqlText & "               cp.cd_repassador "
        SqlText = SqlText & "              ) AS cd_representante, "
        SqlText = SqlText & "       fil.no_filial, cf.qt_kg_fixo qt_fixo, cf.vl_pag_fixo + nvl(AMA.vl_aplicado,0) vl_pago_si, "
        SqlText = SqlText & "       par.dt_sistema, "
        SqlText = SqlText & "       (  cf.vl_adendo +  cf.vl_adendo_icms ) vl_adendo_contrato, "
        SqlText = SqlText & "       cf.vl_icms, cf.sq_negociacao, cf.sq_contrato_fixo, tu.qt_fator, "
        SqlText = SqlText & "       cf.ic_gp, cf.dt_vencimento_gp "
        SqlText = SqlText & "  FROM sof.contrato_fixo cf, "
        SqlText = SqlText & "       sof.contrato_paf cp, "
        SqlText = SqlText & "       sof.fornecedor forn, "
        SqlText = SqlText & "       sof.fornecedor rep, "
        SqlText = SqlText & "       sof.filial fil, "
        SqlText = SqlText & "       sof.parametro par, "
        SqlText = SqlText & "       sof.tipo_unidade tu, "
        SqlText = SqlText & cnt_SQL_Amarracao_Aplicacao & " AMA "
        SqlText = SqlText & " WHERE cp.cd_fornecedor = forn.cd_fornecedor "
        SqlText = SqlText & "   AND cp.cd_repassador = rep.cd_fornecedor "
        SqlText = SqlText & "   AND forn.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "   AND cp.cd_contrato_paf = cf.cd_contrato_paf "
        SqlText = SqlText & "   AND cf.cd_tipo_unidade = tu.cd_tipo_unidade "
        SqlText = SqlText & "   AND AMA.CD_CONTRATO_PAF (+) = cf.CD_CONTRATO_PAF"
        SqlText = SqlText & "   AND AMA.SQ_NEGOCIACAO (+) = cf.SQ_NEGOCIACAO"
        SqlText = SqlText & "   AND AMA.SQ_CONTRATO_FIXO (+) = cf.SQ_CONTRATO_FIXO"
        SqlText = SqlText & "   AND cf.ic_status IN ('A', 'D') "
        SqlText = SqlText & "   AND (cf.qt_kgs - cf.qt_cancelado) <> cf.qt_kg_fixo "

        If Trim(ListaFilial) <> "" Then
            SqlText = SqlText & "     AND FORN.cd_filial_origem IN (" & ListaFilial & ")"
        Else
            SqlText = SqlText & "     AND FORN.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If
        If CD_FORNECEDOR > 0 Then
            SqlText = SqlText & "     AND FORN.cd_fornecedor =" & CD_FORNECEDOR
        End If

        Return DBQuery(SqlText)
    End Function

    Public Function Gera_Rs_Transferencia(ByVal oTipoRelatorio As frmREL_Transferencia.RGFP_TipoRelatorio, _
                                          ByVal DataInicial As String, _
                                          ByVal DataFinal As String, _
                                          ByVal Exibir_EmTransito As Boolean, _
                                          ByVal UtilizarDataCriacaoTransferencia As Boolean, _
                                          ByVal UtilizarDataChegadaTransferencia As Boolean, _
                                          ByVal FilialOrigem As String, _
                                          ByVal FilialDestino As String, _
                                          Optional ByVal AgruparTransferencia As Boolean = False, _
                                          Optional ByVal AbaterTransbordo As Boolean = False) As DataTable
        Dim oData As DataTable
        Dim SqlText As String

        Select Case oTipoRelatorio
            Case frmREL_Transferencia.RGFP_TipoRelatorio.Transferencia
                SqlText = "SELECT TRANSF.CD_FILIAL_ORIGEM," & _
                                 "FIL.NO_FILIAL NO_FILIAL_ORIGEM," & _
                                 "FID.NO_FILIAL NO_FILIAL_DESTINO," & _
                                 "TRANSF.DT_TRANSFERENCIA," & _
                                 "TM.NO_TRANSFERENCIA_MODALIDADE," & _
                                 IIf(Exibir_EmTransito, "NULL", "TRANSF.DT_CHEGADA") & " DT_CHEGADA," & _
                                 "MOV.NU_NF," & _
                                 "MOVQ.IC_TIPO_CACAU," & _
                                 "MOV.VL_NF," & _
                                 "MOV.VL_NF_ICMS," & _
                                 "MOV.QT_KG_NF," & _
                                 "MOV.QT_KG_LIQUIDO_NF," & _
                                 "SCS.QT_SACOS," & _
                                 "MVE.QT_SACOS QT_SACOS_CH," & _
                                 "MOVQ.QT_UMIDADE," & _
                                 "MOVQ.QT_PESO_AMENDOA," & _
                                 "MOVQ.QT_MOFO," & _
                                 "MOVQ.QT_ARDOSIA," & _
                                 "MOVQ.QT_FUMACA," & _
                                 "MOVQ.QT_ACHATADA," & _
                                 "MOVQ.PC_SUJIDADE," & _
                                 "MOVCH.IC_TIPO_CACAU_CH," & _
                                 "MOVCH.VL_NF_CH," & _
                                 "MOVCH.VL_NF_ICMS_CH," & _
                                 "MOVCH.QT_KG_NF_CH," & _
                                 "MOVCH.QT_KG_LIQUIDO_NF_CH," & _
                                 "MOVCH.QT_UMIDADE_CH," & _
                                 "MOVCH.QT_PESO_AMENDOA_CH," & _
                                 "MOVCH.QT_MOFO_CH," & _
                                 "MOVCH.QT_ARDOSIA_CH," & _
                                 "MOVCH.QT_FUMACA_CH," & _
                                 "MOVCH.QT_ACHATADA_CH," & _
                                 "MOVCH.PC_SUJIDADE_CH," & _
                                 "TRANSF.SQ_TRANSFERENCIA" & _
                          " FROM SOF.TRANSFERENCIA TRANSF," & _
                                "SOF.MOVIMENTACAO MOV," & _
                                "SOF.MOVIMENTACAO_QUALIDADE MOVQ," & _
                                "(SELECT T.SQ_TRANSFERENCIA AS SQ_TRANSFERENCIA_CH," & _
                                        "MOV.QT_KG_LIQUIDO_NF AS QT_KG_LIQUIDO_NF_CH," & _
                                        "MOVQ.QT_UMIDADE AS QT_UMIDADE_CH," & _
                                        "MOVQ.QT_PESO_AMENDOA AS QT_PESO_AMENDOA_CH," & _
                                        "MOVQ.IC_TIPO_CACAU AS IC_TIPO_CACAU_CH," & _
                                        "MOVQ.QT_MOFO AS QT_MOFO_CH," & _
                                        "MOVQ.QT_ARDOSIA AS QT_ARDOSIA_CH," & _
                                        "MOVQ.QT_FUMACA AS QT_FUMACA_CH," & _
                                        "MOVQ.QT_ACHATADA AS QT_ACHATADA_CH," & _
                                        "MOVQ.PC_SUJIDADE AS PC_SUJIDADE_CH," & _
                                        "MOV.QT_KG_NF AS QT_KG_NF_CH," & _
                                        "MOV.VL_NF AS VL_NF_CH," & _
                                        "MOV.VL_NF_ICMS AS VL_NF_ICMS_CH" & _
                                 " FROM SOF.MOVIMENTACAO MOV," & _
                                       "SOF.MOVIMENTACAO_QUALIDADE MOVQ," & _
                                       "SOF.TRANSFERENCIA T," & _
                                       "SOF.TRANSFERENCIA_MODALIDADE TM" & _
                                 " WHERE T.SQ_MOVIMENTACAO_ENTRADA = MOV.SQ_MOVIMENTACAO" & _
                                   " AND MOV.SQ_MOVIMENTACAO = MOVQ.SQ_MOVIMENTACAO" & _
                                   " AND T.CD_TRANSFERENCIA_MODALIDADE = TM.CD_TRANSFERENCIA_MODALIDADE" & _
                                   " AND TM.IC_POSSUI_TRANSITO = 'S'" & _
                                   " AND TM.CD_TIPO_MOVIMENTACAO_ENTRADA = MOV.CD_TIPO_MOVIMENTACAO) MOVCH," & _
                                "SOF.FILIAL FIL," & _
                                "SOF.FILIAL FID," & _
                                "SOF.TRANSFERENCIA_MODALIDADE TM," & _
                                "(SELECT SF.SQ_MOVIMENTACAO," & _
                                        "MX.CD_FILIAL_MOVIMENTACAO," & _
                                        "SUM(SF.QT_SACOS * DECODE(NVL(SF.IC_ENTRADA_SAIDA, 'E'), 'E', 1, -1)) QT_SACOS " & _
                                 " FROM SOF.SACARIA_FILIAL SF," & _
                                       "SOF.MOVIMENTACAO MX" & _
                                 " WHERE MX.SQ_MOVIMENTACAO = SF.SQ_MOVIMENTACAO" & _
                                 " GROUP BY SF.SQ_MOVIMENTACAO," & _
                                           "MX.CD_FILIAL_MOVIMENTACAO) MVE," & _
                                "(SELECT M.SQ_TRANSFERENCIA," & _
                                        "SUM(QT_SACOS) QT_SACOS" & _
                                 " FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO M," & _
                                       "SOF.MOV_PILHA_ARMAZEM_HIST_SACARIA S" & _
                                 " WHERE M.IC_SAIDA = 'S'" & _
                                   " AND S.CD_ARMAZEM = M.CD_ARMAZEM" & _
                                   " AND S.CD_PILHA_ARMAZEM = M.CD_PILHA_ARMAZEM" & _
                                   " AND S.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                                   " AND S.SQ_MOV_PILHA_ARMAZEM_HISTORICO = M.SQ_MOV_PILHA_ARMAZEM_HISTORICO" & _
                                 " GROUP BY M.SQ_TRANSFERENCIA) SCS" & _
                          " WHERE FIL.CD_FILIAL = TRANSF.CD_FILIAL_ORIGEM" & _
                            " AND SCS.SQ_TRANSFERENCIA = TRANSF.SQ_TRANSFERENCIA" & _
                            " AND MVE.SQ_MOVIMENTACAO (+) = TRANSF.SQ_MOVIMENTACAO_ENTRADA" & _
                            " AND MOV.SQ_MOVIMENTACAO = TRANSF.SQ_MOVIMENTACAO_SAIDA" & _
                            " AND FID.CD_FILIAL = NVL(MVE.CD_FILIAL_MOVIMENTACAO, TRANSF.CD_FILIAL_DESTINO)" & _
                            " AND MOVQ.SQ_MOVIMENTACAO = MOV.SQ_MOVIMENTACAO" & _
                            " AND TM.CD_TRANSFERENCIA_MODALIDADE = TRANSF.CD_TRANSFERENCIA_MODALIDADE" & _
                            " AND TM.IC_TIPO_UTILIZACAO NOT IN ('T')" & _
                            " AND MOVCH.SQ_TRANSFERENCIA_CH (+) = TRANSF.SQ_TRANSFERENCIA" & _
                            " AND TM.IC_POSSUI_TRANSITO = 'S'"
            Case frmREL_Transferencia.RGFP_TipoRelatorio.Transferencia_ControleQuebraTransferencias
                SqlText = "SELECT FO.NO_FILIAL NO_FILIAL_ORIGEM," & _
                                 "NVL(FD.NO_FILIAL_RESUMIDO, FD.NO_FILIAL) NO_FILIAL_DESTINO," & _
                                 "TRANSF.DT_TRANSFERENCIA," & _
                                 "MOV.NU_NF," & _
                                 "MOV.QT_KG_NF," & _
                                 "SF.QT_SACOS," & _
                                 "ROUND(SF.QT_PESO_SACARIA, 0) VL_PESO_SACARIA," & _
                                 "MOV.QT_BALANCA_KG_BRUTO QT_PESOSAIDA_BRUTO," & _
                                 "MOV.QT_BALANCA_KG_TARA QT_PESOSAIDA_TARA," & _
                                 "MOV.QT_BALANCA_KG_LIQUIDO QT_PESOSAIDA_LIQUIDO," & _
                                 "MVE.QT_BALANCA_KG_BRUTO QT_PESOCHEGADA_BRUTO," & _
                                 "MVE.QT_BALANCA_KG_TARA QT_PESOCHEGADA_TARA," & _
                                 "MVE.QT_BALANCA_KG_LIQUIDO QT_PESOCHEGADA_LIQUIDO," & _
                                 "OD.NO_MOTORISTA," & _
                                 "NVL(OD.NU_PLACA_VEICULO, TRANSF.NU_PLACA_VEICULO) NU_PLACA_VEICULO," & _
                                 "MOV.VL_NF VL_TRANSFERENCIA," & _
                                 "TP.CD_PILHA NR_PILHA," & _
                                 "MVQ.QT_UMIDADE QT_UMIDADE_SAIDA," & _
                                 "MEQ.QT_UMIDADE QT_UMIDADE_CHEGADA," & _
                                 "SP.QT_PESO_MEDIO_SACO_SAIDA VL_PESO_MEDIO_SACO_SAIDA," & _
                                 "TRANSF.SQ_TRANSFERENCIA" & _
                          " FROM SOF.TRANSFERENCIA TRANSF," & _
                                "SOF.FILIAL FO," & _
                                "SOF.FILIAL FD," & _
                                "SOF.TRANSFERENCIA_SUMMUS TS," & _
                                "SOF.ORDEM_DESCARGA OD," & _
                                "SOF.MOVIMENTACAO MOV," & _
                                "SOF.MOVIMENTACAO MVE," & _
                                "SOF.MOVIMENTACAO_QUALIDADE MVQ," & _
                                "SOF.MOVIMENTACAO_QUALIDADE MEQ," & _
                                "(SELECT SQ_MOVIMENTACAO," & _
                                        "SUM(QT_SACOS) QT_SACOS," & _
                                        "SUM(QT_SACOS * TS.VL_PESO) QT_PESO_SACARIA" & _
                                 " FROM SOF.SACARIA_FILIAL SC," & _
                                       "SOF.TIPO_SACARIA TS" & _
                                 " WHERE TS.CD_TIPO_SACARIA = SC.CD_TIPO_SACARIA" & _
                                 " GROUP BY SQ_MOVIMENTACAO) SF," & _
                                "(SELECT DISTINCT SQ_TRANSFERENCIA," & _
                                                 "CD_PILHA" & _
                                 " FROM SOF.TRANSFERENCIA_SUMMUS_ITEM) TP," & _
                                "(SELECT SQ_MOVIMENTACAO," & _
                                        "NR_ITEM_CONFIGURACAO QT_PESO_MEDIO_SACO_SAIDA" & _
                                 " FROM SOF.MOVIMENTACAO_CONFIGURACAO" & _
                                 " WHERE CD_ITEM_CONFIGURACAO = " & cnt_Config_Item_PesoMedioSacoTransferencia & ") SP" & _
                          " WHERE FO.CD_FILIAL = TRANSF.CD_FILIAL_ORIGEM" & _
                            " AND FD.CD_FILIAL = TRANSF.CD_FILIAL_DESTINO" & _
                            " AND MOV.SQ_MOVIMENTACAO = TRANSF.SQ_MOVIMENTACAO_SAIDA" & _
                            " AND MVQ.SQ_MOVIMENTACAO (+) = MOV.SQ_MOVIMENTACAO" & _
                            " AND SP.SQ_MOVIMENTACAO (+) = MOV.SQ_MOVIMENTACAO" & _
                            " AND SF.SQ_MOVIMENTACAO = TRANSF.SQ_MOVIMENTACAO_SAIDA" & _
                            " AND MVE.SQ_MOVIMENTACAO (+) = TRANSF.SQ_MOVIMENTACAO_ENTRADA" & _
                            " AND MEQ.SQ_MOVIMENTACAO (+) = MVE.SQ_MOVIMENTACAO" & _
                            " AND TS.SQ_TRANSFERENCIA_LOGUS (+) = TRANSF.SQ_TRANSFERENCIA" & _
                            " AND TP.SQ_TRANSFERENCIA (+) = TS.SQ_TRANSFERENCIA" & _
                            " AND OD.CD_ORDEM_DESCARGA = TS.CD_ORDEM_DESCARGA"
        End Select

        If Exibir_EmTransito Then
            If IsDate(DataInicial) Then
                SqlText = SqlText & " AND TRANSF.DT_TRANSFERENCIA >= " & QuotedStr(Date_to_Oracle(DataInicial))
            End If
            If IsDate(DataFinal) Then
                SqlText = SqlText & " AND TRANSF.DT_TRANSFERENCIA <= " & QuotedStr(Date_to_Oracle(DataFinal))
                SqlText = SqlText & " AND NVL(TRANSF.DT_CHEGADA, SYSDATE + 1) > " & QuotedStr(Date_to_Oracle(DataFinal))
            Else
                SqlText = SqlText & " AND TRANSF.DT_CHEGADA IS NULL"
            End If
        Else
            If UtilizarDataCriacaoTransferencia Then
                SqlText = SqlText & " AND TRANSF.DT_TRANSFERENCIA BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                                    " AND " & QuotedStr(Date_to_Oracle(DataFinal))
            Else
                If UtilizarDataChegadaTransferencia Then
                    SqlText = SqlText & " AND TRANSF.DT_CHEGADA BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                                  " AND " & QuotedStr(Date_to_Oracle(DataFinal))
                End If
            End If
        End If

        If Trim(FilialOrigem) = "" And Trim(FilialDestino) = "" Then
            SqlText = SqlText & " AND (TRANSF.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            SqlText = SqlText & "   OR NVL(MVE.CD_FILIAL_MOVIMENTACAO, TRANSF.CD_FILIAL_DESTINO) IN (" & ListarIDFiliaisLiberadaUsuario() & "))"
        Else
            If Trim(FilialDestino) = "" Then
                SqlText = SqlText & " AND TRANSF.CD_FILIAL_ORIGEM IN (" & FilialOrigem & ")"
            Else
                If Trim(FilialOrigem) = "" Then
                    SqlText = SqlText & " AND NVL(MVE.CD_FILIAL_MOVIMENTACAO, TRANSF.CD_FILIAL_DESTINO) IN (" & FilialDestino & ")"
                Else
                    SqlText = SqlText & " AND TRANSF.CD_FILIAL_ORIGEM IN (" & FilialOrigem & ")"
                    SqlText = SqlText & " AND NVL(MVE.CD_FILIAL_MOVIMENTACAO, TRANSF.CD_FILIAL_DESTINO) IN (" & FilialDestino & ")"
                End If
            End If
        End If

        SqlText = SqlText & " ORDER BY TRANSF.DT_TRANSFERENCIA," & _
                                      "MOV.NU_NF"

        If AbaterTransbordo Then
            SqlText = "SELECT TRF.*" & _
                      " FROM (" & SqlText & ") TRF," & _
                            "(" & Gera_Sql_Transbordo(DataInicial, DataFinal, True) & ") TBD" & _
                      " WHERE TBD.SQ_TRANSFERENCIA (+) = TRF.SQ_TRANSFERENCIA" & _
                        " AND TBD.SQ_TRANSFERENCIA IS NULL"
        End If

        If oTipoRelatorio = frmREL_Transferencia.RGFP_TipoRelatorio.Transferencia And AgruparTransferencia Then
            SqlText = "SELECT CD_FILIAL_ORIGEM," & _
                             "NO_FILIAL_ORIGEM NO_ARMAZEM," & _
                             "SUM(QT_KG_NF) QT_KG_NF_SAIDA," & _
                             "NVL(ROUND(SUM(QT_UMIDADE * QT_KG_NF) / SUM(QT_KG_NF), 2), 0) VL_UMIDADE_SAIDA," & _
                             "NVL(ROUND(SUM(PC_SUJIDADE * QT_KG_NF) / SUM(QT_KG_NF), 2), 0) VL_SUJIDADE_SAIDA," & _
                             "SUM(QT_KG_LIQUIDO_NF_CH) QT_KG_NF_ENTRADA_FABRICA," & _
                             "NVL(ROUND(SUM(QT_UMIDADE_CH * QT_KG_NF) / SUM(QT_KG_LIQUIDO_NF_CH), 2), 0) VL_UMIDADE_ENTRADA_FABRICA," & _
                             "NVL(ROUND(SUM(PC_SUJIDADE_CH * QT_KG_NF) / SUM(QT_KG_LIQUIDO_NF_CH), 2), 0) VL_SUJIDADE_ENTRADA_FABRICA" & _
                      " FROM (" & SqlText & ")" & _
                      " GROUP BY CD_FILIAL_ORIGEM," & _
                                "NO_FILIAL_ORIGEM" & _
                      " ORDER BY NO_FILIAL_ORIGEM"
        End If

        oData = DBQuery(SqlText)

        Return oData
    End Function

    Public Function Gera_Sql_CC_Ctr_Fixo_CtrSaldoNFComplementar() As String
        Dim SqlText As String

        SqlText = "SELECT FIX.CD_CONTRATO_PAF," & _
                         "FIX.SQ_NEGOCIACAO," & _
                         "FIX.SQ_CONTRATO_FIXO," & _
                         "FIX.DT_CONTRATO_FIXO," & _
                         "(((FIX.QT_KGS - FIX.QT_CANCELADO) / FIX.QT_KGS) * (FIX.VL_TOTAL + FIX.VL_ICMS)) + FIX.VL_ADENDO + FIX.VL_ADENDO_ICMS QT_SALDO," & _
                         "ROUND(SUM(ROUND(VL_FIXO, 2) - (X1.VL_FIXO / DECODE(X1.VL_NF, 0, 1, X1.VL_NF) * X1.VL_NF_FUNRURAL) - NVL(FIX.VL_ICMS, 0)), 2) VL_TOTAL," & _
                         "SUM(NVL(FIX.VL_ICMS, 0)) VL_ICMS" & _
                  " FROM SOF.CONTRATO_FIXO FIX," & _
                        "(SELECT M.DT_MOVIMENTACAO," & _
                                "M.NU_NF," & _
                                "M.QT_KG_NF," & _
                                "M.VL_NF," & _
                                "M.QT_KG_LIQUIDO_NF," & _
                                "CM.DT_FIXACAO," & _
                                "CM.QT_KG_FIXO," & _
                                "CM.VL_FIXO," & _
                                "MQ.QT_UMIDADE," & _
                                "CM.CD_CONTRATO_PAF," & _
                                "M.VL_NF_ICMS," & _
                                "M.VL_NF_FUNRURAL," & _
                                "M.NU_NF_REFERENCIA," & _
                                "M.CD_FILIAL_MOVIMENTACAO," & _
                                "CM.SQ_NEGOCIACAO," & _
                                "CM.SQ_CONTRATO_FIXO," & _
                                "MQ.PC_SUJIDADE QT_SUJIDADE," & _
                                "M.SQ_MOVIMENTACAO," & _
                                "ICMS.VL_ICMS" & _
                         " FROM SOF.MOVIMENTACAO M," & _
                               "SOF.CTR_PAF_NEG_CTR_FIX_MOV CM," & _
                               "SOF.MOVIMENTACAO_QUALIDADE MQ," & _
                               "(SELECT P.SQ_MOVIMENTACAO," & _
                                       "CM.CD_CONTRATO_PAF," & _
                                       "CM.SQ_NEGOCIACAO," & _
                                       "CM.SQ_CONTRATO_FIXO," & _
                                       "DECODE(M.VL_NF,0,0, ROUND ((CM.VL_FIXO * P.VL_PAGAMENTO) / M.VL_NF, 2)) AS VL_ICMS" & _
                                " FROM SOF.PAGAMENTOS P, SOF.CTR_PAF_NEG_CTR_FIX_MOV CM, SOF.MOVIMENTACAO M" & _
                                " WHERE M.SQ_MOVIMENTACAO = CM.SQ_MOVIMENTACAO" & _
                                  " AND M.SQ_MOVIMENTACAO = P.SQ_MOVIMENTACAO) ICMS" & _
                         " WHERE M.SQ_MOVIMENTACAO = CM.SQ_MOVIMENTACAO" & _
                            " AND MQ.SQ_MOVIMENTACAO(+) = M.SQ_MOVIMENTACAO" & _
                            " AND ICMS.SQ_MOVIMENTACAO (+) = CM.SQ_MOVIMENTACAO" & _
                            " AND ICMS.CD_CONTRATO_PAF (+) = CM.CD_CONTRATO_PAF" & _
                            " AND ICMS.SQ_NEGOCIACAO (+) = CM.SQ_NEGOCIACAO" & _
                            " AND ICMS.SQ_CONTRATO_FIXO (+) = CM.SQ_CONTRATO_FIXO" & _
                         " ORDER BY CM.DT_CRIACAO) X1" & _
                  " WHERE FIX.CD_CONTRATO_PAF > 0" & _
                    " AND X1.CD_CONTRATO_PAF = FIX.CD_CONTRATO_PAF" & _
                    " AND X1.SQ_NEGOCIACAO = FIX.SQ_NEGOCIACAO" & _
                    " AND X1.SQ_CONTRATO_FIXO = FIX.SQ_CONTRATO_FIXO" & _
                  " GROUP BY FIX.CD_CONTRATO_PAF," & _
                            "FIX.SQ_NEGOCIACAO," & _
                            "FIX.SQ_CONTRATO_FIXO," & _
                            "FIX.DT_CONTRATO_FIXO," & _
                            "FIX.QT_KGS," & _
                            "FIX.QT_CANCELADO," & _
                            "FIX.VL_TOTAL," & _
                            "FIX.VL_ICMS," & _
                            "FIX.VL_ADENDO," & _
                            "FIX.VL_ADENDO_ICMS" & _
                  " HAVING ABS(ROUND((((FIX.QT_KGS - FIX.QT_CANCELADO) / FIX.QT_KGS) * (FIX.VL_TOTAL + FIX.VL_ICMS)) + FIX.VL_ADENDO + FIX.VL_ADENDO_ICMS, 2) -" & _
                              "ROUND(ROUND(SUM(ROUND(VL_FIXO, 2) - (X1.VL_FIXO / DECODE(X1.VL_NF, 0, 1, X1.VL_NF) * X1.VL_NF_FUNRURAL) - NVL(FIX.VL_ICMS, 0)), 2) + SUM(NVL(FIX.VL_ICMS, 0)), 2)) > 0.03"

        Return SqlText
    End Function

    Public Function Gera_Sql_Adiantamento_Exposure_Analitico(Optional ByVal Sintetico As Boolean = True) As String
        Dim SqlText As String

        SqlText = "SELECT CD_FILIAL_ORIGEM Codigo_Filial," & _
                         "NO_FILIAL Nome_Filial," & _
                         "SUM(DECODE(IC_ICMS, 'N', VL_A_FIXAR, 0)) Adiantamentos_S_Ctr_Base," & _
                         "SUM(DECODE (IC_ICMS, 'S', VL_A_FIXAR, 0)) ICMS_Base_RS," & _
                         "0 Adiantamentos_Ctr_Base," & _
                         "0 Ctr_Precos_Fixos_Sem_Adto," & _
                         "CD_CONTRATO_PAF," & _
                         "SQ_NEGOCIACAO," & _
                         "NO_RAZAO_SOCIAL NO_FORNECEDOR" & _
                  " FROM (SELECT /*+ INDEX(p SYS_C004419) INDEX(f SYS_C004218) */" & _
                                "F.CD_FILIAL_ORIGEM," & _
                                "FIL.NO_FILIAL," & _
                                "P.IC_ICMS," & _
                                "SUM(PN.VL_A_FIXAR) VL_A_FIXAR," & _
                                "PN.CD_CONTRATO_PAF," & _
                                "PN.SQ_NEGOCIACAO," & _
                                "F.NO_RAZAO_SOCIAL" & _
                         " FROM SOF.PAGAMENTOS P," & _
                               "SOF.PAG_NEG PN," & _
                               "SOF.FORNECEDOR F," & _
                               "SOF.FILIAL FIL" & _
                         " WHERE P.SQ_PAGAMENTO = PN.SQ_PAGAMENTO" & _
                           " AND F.CD_FORNECEDOR = P.CD_FORNECEDOR" & _
                           " AND FIL.CD_FILIAL = F.CD_FILIAL_ORIGEM" & _
                           " AND PN.VL_A_FIXAR <> 0" & _
                         " GROUP BY F.CD_FILIAL_ORIGEM," & _
                                   "FIL.NO_FILIAL," & _
                                   "P.IC_ICMS," & _
                                   "PN.CD_CONTRATO_PAF," & _
                                   "PN.SQ_NEGOCIACAO," & _
                                   "F.NO_RAZAO_SOCIAL" & _
                        " UNION ALL " & _
                         "SELECT /*+ INDEX(p SYS_C004419) INDEX(f SYS_C004218)*/" & _
                                "F.CD_FILIAL_ORIGEM," & _
                                "FIL.NO_FILIAL," & _
                                "P.IC_ICMS," & _
                                "SUM(PCP.VL_A_FIXAR) VL_A_FIXAR," & _
                                "PCP.CD_CONTRATO_PAF," & _
                                "NULL SQ_NEGOCIACAO," & _
                                "F.NO_RAZAO_SOCIAL" & _
                         " FROM SOF.PAGAMENTOS P," & _
                               "SOF.PAG_CTR_PAF PCP," & _
                               "SOF.FORNECEDOR F," & _
                               "SOF.FILIAL FIL" & _
                         " WHERE (P.SQ_PAGAMENTO = PCP.SQ_PAGAMENTO AND F.CD_FORNECEDOR = P.CD_FORNECEDOR)" & _
                           " AND FIL.CD_FILIAL = F.CD_FILIAL_ORIGEM" & _
                           " AND PCP.VL_A_FIXAR <> 0" & _
                         " GROUP BY F.CD_FILIAL_ORIGEM," & _
                                   "FIL.NO_FILIAL," & _
                                   "P.IC_ICMS," & _
                                   "PCP.CD_CONTRATO_PAF," & _
                                   "F.NO_RAZAO_SOCIAL" & _
                        " UNION ALL " & _
                         "SELECT F.CD_FILIAL_ORIGEM," & _
                                "FIL.NO_FILIAL," & _
                                "P.IC_ICMS," & _
                                "SUM(P.VL_A_FIXAR) VL_A_FIXAR," & _
                                "NULL CD_CONTRATO_PAF," & _
                                "NULL SQ_NEGOCIACAO," & _
                                "F.NO_RAZAO_SOCIAL" & _
                         " FROM SOF.PAGAMENTOS P," & _
                               "SOF.FORNECEDOR F," & _
                               "SOF.FILIAL FIL" & _
                         " WHERE F.CD_FORNECEDOR = P.CD_FORNECEDOR" & _
                           " AND FIL.CD_FILIAL = F.CD_FILIAL_ORIGEM" & _
                           " AND P.VL_A_FIXAR <> 0" & _
                         " GROUP BY F.CD_FILIAL_ORIGEM," & _
                                   "FIL.NO_FILIAL," & _
                                   "P.IC_ICMS," & _
                                   "F.NO_RAZAO_SOCIAL) A" & _
                  " GROUP BY CD_FILIAL_ORIGEM," & _
                            "NO_FILIAL," & _
                            "IC_ICMS," & _
                            "CD_CONTRATO_PAF," & _
                            "SQ_NEGOCIACAO," & _
                            "NO_RAZAO_SOCIAL" & _
                 " UNION ALL " & _
                 " SELECT CD_FILIAL_ORIGEM," & _
                         "NO_FILIAL," & _
                         "0 VL_ADT_SEM_CTR," & _
                         "0 VL_ICMS," & _
                         "DECODE(SIGN(QT_PAGO - QT_RECEBIDO), 1, (QT_PAGO - QT_RECEBIDO) * VL_UNITARIO, 0) VL_CTR_COM_ADT," & _
                         "(QT_KGS - QT_PAGO) * VL_UNITARIO VL_CTR_SEM_ADT," & _
                         "CD_CONTRATO_PAF," & _
                         "SQ_NEGOCIACAO," & _
                         "NO_RAZAO_SOCIAL" & _
                  " FROM (SELECT F.NO_FILIAL," & _
                                "FORN.CD_FILIAL_ORIGEM," & _
                                "TU.CD_TIPO_UNIDADE," & _
                                "CF.QT_KG_FIXO QT_RECEBIDO," & _
                                "(CF.QT_KGS - CF.QT_CANCELADO) QT_KGS," & _
                                "ROUND(((CF.VL_UNITARIO / TU.QT_FATOR) + (DECODE ((CF.QT_KGS - CF.QT_CANCELADO), 0, 0, (NVL(CFA.VL_ADENDO_CONTRATO, 0) / (CF.QT_KGS - CF.QT_CANCELADO))))), 10) VL_UNITARIO," & _
                                "ROUND((CF.VL_PAG_FIXO * (1 - (CF.PC_ALIQ_ICMS / 100))) / ((CF.VL_UNITARIO / TU.QT_FATOR) + DECODE((CF.QT_KGS - CF.QT_CANCELADO), 0, 0, ((NVL(CFA.VL_ADENDO_CONTRATO, 0) / (CF.QT_KGS - CF.QT_CANCELADO))))), 2) QT_PAGO," & _
                                "CF.CD_CONTRATO_PAF," & _
                                "CF.SQ_NEGOCIACAO," & _
                                "FORN.NO_RAZAO_SOCIAL" & _
                         " FROM SOF.CONTRATO_FIXO CF," & _
                               "SOF.CONTRATO_PAF CP," & _
                               "SOF.FILIAL F," & _
                               "SOF.TIPO_UNIDADE TU," & _
                               "(SELECT CD_CONTRATO_PAF," & _
                                       "SQ_NEGOCIACAO," & _
                                       "SQ_CONTRATO_FIXO," & _
                                       "SUM(VL_ADENDO_CONTRATO) VL_ADENDO_CONTRATO" & _
                                " FROM SOF.CONTRATO_FIXO_ADENDO" & _
                                " GROUP BY CD_CONTRATO_PAF," & _
                                          "SQ_NEGOCIACAO," & _
                                          "SQ_CONTRATO_FIXO) CFA," & _
                               "SOF.FORNECEDOR FORN" & _
                         " WHERE CP.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                           " AND FORN.CD_FILIAL_ORIGEM = F.CD_FILIAL" & _
                           " AND CF.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                           " AND CP.CD_FORNECEDOR = FORN.CD_FORNECEDOR" & _
                           " AND CF.CD_CONTRATO_PAF = CFA.CD_CONTRATO_PAF (+)" & _
                           " AND CF.SQ_NEGOCIACAO = CFA.SQ_NEGOCIACAO(+)" & _
                           " AND CF.SQ_CONTRATO_FIXO = CFA.SQ_CONTRATO_FIXO(+)" & _
                           " AND CF.IC_STATUS IN ('A', 'D')" & _
                           " AND CF.IC_TAXA_DOLAR_VARIAVEL = 'N')"

        If Sintetico Then
            SqlText = "SELECT Codigo_Filial CD_FILIAL," & _
                             "Nome_Filial NO_FILIAL," & _
                             "SUM(Adiantamentos_S_Ctr_Base) VL_ADT_SEM_CTR," & _
                             "SUM(ICMS_Base_RS) VL_ICMS," & _
                             "SUM(Adiantamentos_Ctr_Base) VL_CTR_COM_ADT," & _
                             "SUM(Ctr_Precos_Fixos_Sem_Adto) VL_CTR_SEM_ADT" & _
                      " FROM (" & SqlText & ")" & _
                      " GROUP BY Codigo_Filial," & _
                                "Nome_Filial"
        End If

        Return SqlText
    End Function

    Public Function Gera_Sql_Recebimento_Fabrica(ByVal DataInicial As String, _
                                                 ByVal DataFinal As String) As String
        Dim SqlText As String

        SqlText = "SELECT MV.DT_MOVIMENTACAO," & _
                         "MV.NU_NF," & _
                         "FN.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "MV.QT_KG_NF," & _
                         "MV.QT_KG_LIQUIDO_NF," & _
                         "MV.QT_KG_NF - MV.QT_KG_LIQUIDO_NF QT_QUEBRA_RD," & _
                         "TM.NO_TIPO_MOVIMENTACAO," & _
                         "MV.SQ_MOVIMENTACAO," & _
                         "MV.CD_PROCEDENCIA," & _
                         "MQ.QT_UMIDADE," & _
                         "MQ.PC_SUJIDADE" & _
                  " FROM SOF.MOVIMENTACAO MV," & _
                        "SOF.MOVIMENTACAO_QUALIDADE MQ," & _
                        "SOF.TRANSFERENCIA TR," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.FORNECEDOR FN" & _
                  " WHERE TRUNC(MV.DT_MOVIMENTACAO) >= " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                    " AND TRUNC(MV.DT_MOVIMENTACAO) <=  " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                    " AND MV.CD_FILIAL_MOVIMENTACAO = " & FilialMae & _
                    " AND TM.CD_TIPO_MOVIMENTACAO = MV.CD_TIPO_MOVIMENTACAO" & _
                    " AND TM.IC_ENTRADA_SAIDA = 'E'" & _
                    " AND TM.IC_VALIDA_KG = 'S'" & _
                    " AND FN.CD_FORNECEDOR (+) = MV.CD_FORNECEDOR" & _
                    " AND MV.SQ_MOVIMENTACAO NOT IN (SELECT IT.SQ_MOVIMENTACAO" & _
                                                    " FROM SOF.ITEM_TRANSFERENCIA IT," & _
                                                          "SOF.TRANSFERENCIA TR," & _
                                                          "SOF.TRANSFERENCIA_MODALIDADE TM" & _
                                                    " WHERE IT.SQ_TRANSFERENCIA = TR.SQ_TRANSFERENCIA" & _
                                                      " AND TM.CD_TRANSFERENCIA_MODALIDADE = TR.CD_TRANSFERENCIA_MODALIDADE" & _
                                                      " AND TM.IC_MOVIMENTACAO_SILO = 'N' AND TM.CD_TRANSFERENCIA_MODALIDADE IN (5, 6))" & _
                    " AND TR.SQ_MOVIMENTACAO_ENTRADA (+) = MV.SQ_MOVIMENTACAO" & _
                    " AND TR.SQ_TRANSFERENCIA IS NULL" & _
                    " AND MQ.SQ_MOVIMENTACAO = MV.SQ_MOVIMENTACAO"

        Return SqlText
    End Function

    Public Function Gera_Sql_Saida_Fabrica(ByVal DataInicial As String, _
                                           ByVal DataFinal As String, _
                                           Optional ByVal Sumarizar As Boolean = False, _
                                           Optional ByVal ExcluirDevolucaoCargaMes As Boolean = False) As String
        Dim SqlText As String

        SqlText = "SELECT TM.NO_TRANSFERENCIA_MODALIDADE," & _
                         "TO_CHAR(MU.DT_MOVIMENTACAO, 'MM-YYYY') MES_ANO," & _
                         "NVL2(MU.CD_FORNECEDOR, 'Fornecedor', FO.NO_FILIAL) NO_ORIGEM," & _
                         "FD.NO_FILIAL," & _
                         "SUM(IT.KG_TRANSFERIDO) QT_VOLUME" & _
                  " FROM SOF.TRANSFERENCIA TR," & _
                        "SOF.TRANSFERENCIA_MODALIDADE TM," & _
                        "SOF.ITEM_TRANSFERENCIA IT," & _
                        "SOF.MOVIMENTACAO MV," & _
                        "SOF.FILIAL FD," & _
                        "SOF.TRANSFERENCIA TE," & _
                        "SOF.FILIAL FO," & _
                        "SOF.MOVIMENTACAO MU" & _
                  " WHERE TR.CD_FILIAL_ORIGEM = " & FilialMae & _
                    " AND TR.DT_TRANSFERENCIA >= " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                    " AND TR.DT_TRANSFERENCIA <= " & QuotedStr(Date_to_Oracle(DataFinal))

        If ExcluirDevolucaoCargaMes Then
            SqlText = SqlText & _
                    " AND (TO_CHAR(TR.DT_TRANSFERENCIA, 'YYYY-MM') <> TO_CHAR(MU.DT_MOVIMENTACAO, 'YYYY-MM') OR TM.IC_DEVOLUCAO <> 'S')"
        End If

        SqlText = SqlText & _
                    " AND TR.SQ_MOVIMENTACAO_ENTRADA IS NULL " & _
                    " AND TM.CD_TRANSFERENCIA_MODALIDADE = TR.CD_TRANSFERENCIA_MODALIDADE" & _
                    " AND TM.IC_MOVIMENTACAO_SILO <> 'S'" & _
                    " AND MV.SQ_MOVIMENTACAO = TR.SQ_MOVIMENTACAO_SAIDA" & _
                    " AND FD.CD_FILIAL = TR.CD_FILIAL_DESTINO" & _
                    " AND IT.SQ_TRANSFERENCIA = TR.SQ_TRANSFERENCIA" & _
                    " AND MU.SQ_MOVIMENTACAO = IT.SQ_MOVIMENTACAO" & _
                    " AND TE.SQ_MOVIMENTACAO_ENTRADA (+) = IT.SQ_MOVIMENTACAO" & _
                    " AND FO.CD_FILIAL (+) = TE.CD_FILIAL_ORIGEM" & _
                  " GROUP BY TM.NO_TRANSFERENCIA_MODALIDADE," & _
                            "TO_CHAR(MU.DT_MOVIMENTACAO, 'MM-YYYY')," & _
                            "NVL2(MU.CD_FORNECEDOR, 'Fornecedor', FO.NO_FILIAL)," & _
                            "FO.NO_FILIAL," & _
                            "FD.NO_FILIAL"

        If Sumarizar Then
            SqlText = "SELECT NO_TRANSFERENCIA_MODALIDADE," & _
                             "SUM(QT_VOLUME) QT_VOLUME" & _
                      " FROM (" & SqlText & ")" & _
                      " GROUP BY NO_TRANSFERENCIA_MODALIDADE" & _
                      " ORDER BY NO_TRANSFERENCIA_MODALIDADE"
        End If

        Return SqlText
    End Function

    Public Function Gera_Sql_Transbordo(ByVal DataInicial As String, _
                                        ByVal DataFinal As String, _
                                        ByVal DataChegada As Boolean) As String
        Dim SqlText As String

        SqlText = "SELECT *" & _
                  " FROM (SELECT TR.SQ_TRANSFERENCIA," & _
                                "NVL(FO.NO_FILIAL, FN.NO_RAZAO_SOCIAL) NO_ORIGEM," & _
                                "FD.NO_FILIAL NO_FILIAL_DESTINO," & _
                                "MV.NU_NF," & _
                                "MV.VL_NF," & _
                                "MV.QT_KG_NF," & _
                                "MV.QT_KG_LIQUIDO_NF," & _
                                "TR.DT_TRANSFERENCIA," & _
                                "MV.DT_MOVIMENTACAO," & _
                                "MV.CD_PROCEDENCIA," & _
                                "MQ.QT_UMIDADE," & _
                                "MQ.QT_PESO_AMENDOA," & _
                                "MQ.QT_MOFO," & _
                                "MQ.QT_FUMACA," & _
                                "MQ.QT_ARDOSIA," & _
                                "MQ.QT_ACHATADA," & _
                                "MQ.PC_SUJIDADE," & _
                                "RN.IC_FAZER_TRANSFERENCIA," & _
                                "FO.CD_FILIAL CD_FILIAL_ORIGEM" & _
                         " FROM SOF.RECEPCAO_NOTAS RN," & _
                               "SOF.TRANSFERENCIA_SUMMUS TS," & _
                               "SOF.TRANSFERENCIA TR," & _
                               "SOF.FORNECEDOR FN," & _
                               "SOF.MOVIMENTACAO MS," & _
                               "SOF.MOVIMENTACAO MV," & _
                               "SOF.MOVIMENTACAO_QUALIDADE MQ," & _
                               "SOF.FILIAL FO," & _
                               "SOF.FILIAL FD," & _
                               "SOF.FILIAL FR" & _
                         " WHERE MV.CD_FILIAL_MOVIMENTACAO = " & FilialMae & _
                           " AND FR.CD_FILIAL = MV.CD_FILIAL_MOVIMENTACAO" & _
                           " AND RN.SQ_MOVIMENTACAO = MV.SQ_MOVIMENTACAO" & _
                           " AND RN.IC_FAZER_TRANSFERENCIA = 'S'" & _
                           " AND TRUNC (TR." & IIf(DataChegada, "DT_CHEGADA", "DT_TRANSFERENCIA") & ") >= " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                           " AND TRUNC (TR." & IIf(DataChegada, "DT_CHEGADA", "DT_TRANSFERENCIA") & ") <= " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                           " AND FN.CD_FORNECEDOR (+) = RN.CD_FORNECEDOR" & _
                           " AND TS.SQ_TRANSFERENCIA (+) = RN.SQ_TRANSFERENCIA" & _
                           " AND TR.SQ_TRANSFERENCIA (+) = TS.SQ_TRANSFERENCIA_LOGUS" & _
                           " AND MS.SQ_MOVIMENTACAO (+) = TR.SQ_MOVIMENTACAO_SAIDA" & _
                           " AND MQ.SQ_MOVIMENTACAO = MV.SQ_MOVIMENTACAO" & _
                           " AND FO.CD_FILIAL (+) = RN.CD_FILIAL_TRANSFERENCIA" & _
                           " AND FD.CD_FILIAL = RN.CD_FILIAL_DESTINO" & _
                        " UNION ALL " & _
                         "SELECT TR.SQ_TRANSFERENCIA," & _
                                "NVL(FO.NO_FILIAL, FN.NO_RAZAO_SOCIAL) NO_ORIGEM," & _
                                "FD.NO_FILIAL NO_FILIAL_DESTINO," & _
                                "MV.NU_NF," & _
                                "MV.VL_NF," & _
                                "MV.QT_KG_NF," & _
                                "MV.QT_KG_LIQUIDO_NF," & _
                                "TR.DT_TRANSFERENCIA," & _
                                "MV.DT_MOVIMENTACAO," & _
                                "MV.CD_PROCEDENCIA," & _
                                "MQ.QT_UMIDADE," & _
                                "MQ.QT_PESO_AMENDOA," & _
                                "MQ.QT_MOFO," & _
                                "MQ.QT_FUMACA," & _
                                "MQ.QT_ARDOSIA," & _
                                "MQ.QT_ACHATADA," & _
                                "MQ.PC_SUJIDADE," & _
                                "RN.IC_FAZER_TRANSFERENCIA," & _
                                "FO.CD_FILIAL CD_FILIAL_ORIGEM" & _
                         " FROM SOF.RECEPCAO_NOTAS RN," & _
                               "SOF.MOVIMENTACAO MV," & _
                               "SOF.MOVIMENTACAO_QUALIDADE MQ," & _
                               "SOF.ITEM_TRANSFERENCIA IT," & _
                               "SOF.TRANSFERENCIA TD," & _
                               "SOF.MOVIMENTACAO MT," & _
                               "SOF.FILIAL FD," & _
                               "SOF.FILIAL FO," & _
                               "SOF.TRANSFERENCIA TR," & _
                               "SOF.FORNECEDOR FN" & _
                         " WHERE RN.IC_FAZER_TRANSFERENCIA = 'N'" & _
                           " AND MV.SQ_MOVIMENTACAO = RN.SQ_MOVIMENTACAO" & _
                           " AND IT.SQ_MOVIMENTACAO = MV.SQ_MOVIMENTACAO" & _
                           " AND TD.SQ_TRANSFERENCIA = IT.SQ_TRANSFERENCIA" & _
                           " AND MT.SQ_MOVIMENTACAO = TD.SQ_MOVIMENTACAO_SAIDA" & _
                           " AND MT.NU_NF = MV.NU_NF" & _
                           " AND FD.CD_FILIAL = TD.CD_FILIAL_DESTINO" & _
                           " AND TRUNC(TR." & IIf(DataChegada, "DT_CHEGADA", "DT_TRANSFERENCIA") & ") >= " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                           " AND TRUNC(TR." & IIf(DataChegada, "DT_CHEGADA", "DT_TRANSFERENCIA") & ") <= " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                           " AND MQ.SQ_MOVIMENTACAO (+) = MV.SQ_MOVIMENTACAO" & _
                           " AND TR.SQ_MOVIMENTACAO_ENTRADA (+) = MV.SQ_MOVIMENTACAO" & _
                           " AND FO.CD_FILIAL (+) = TR.CD_FILIAL_ORIGEM" & _
                           " AND FN.CD_FORNECEDOR (+) = MV.CD_FORNECEDOR" & _
                         " GROUP BY TR.SQ_TRANSFERENCIA," & _
                                   "NVL(FO.NO_FILIAL, FN.NO_RAZAO_SOCIAL)," & _
                                   "FD.NO_FILIAL," & _
                                   "MV.NU_NF," & _
                                   "MV.VL_NF," & _
                                   "MV.QT_KG_NF," & _
                                   "MV.QT_KG_LIQUIDO_NF," & _
                                   "TR.DT_TRANSFERENCIA," & _
                                   "MV.DT_MOVIMENTACAO," & _
                                   "MV.CD_PROCEDENCIA," & _
                                   "MQ.QT_UMIDADE," & _
                                   "MQ.QT_PESO_AMENDOA," & _
                                   "MQ.QT_MOFO," & _
                                   "MQ.QT_FUMACA," & _
                                   "MQ.QT_ARDOSIA," & _
                                   "MQ.QT_ACHATADA," & _
                                   "MQ.PC_SUJIDADE," & _
                                   "RN.IC_FAZER_TRANSFERENCIA," & _
                                   "MT.QT_KG_LIQUIDO_NF," & _
                                   "FO.CD_FILIAL" & _
                         " HAVING SUM(MV.QT_KG_LIQUIDO_NF) = MT.QT_KG_LIQUIDO_NF)" & _
                         " ORDER BY DT_TRANSFERENCIA," & _
                                   "DT_MOVIMENTACAO"

        Return SqlText
    End Function

    Public Function Gera_Relatorio_AdiantamentoExposure(ByVal oTipo As PosForn_FiltroExposure, _
                                                        ByVal Bolsa As Double, _
                                                        ByVal Dolar As Double, _
                                                        ByVal ValorArroba As Double) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable
        Dim sFiltro As String

        Select Case oTipo
            Case PosForn_FiltroExposure.feSintetico
                oData = DBQuery(Gera_Sql_Adiantamento_Exposure_Analitico)

                oRelatorio.Load(Application.StartupPath & "\RPT_Adiantamento_Exposure.rpt")
                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Dolar", Dolar)
            Case PosForn_FiltroExposure.feSoAdiantamentosContratosBase, PosForn_FiltroExposure.feSoAdiantamentoSemContratosBase
                Dim oDataAux As DataTable = Nothing
                Dim oDataSub1 As DataTable = Nothing
                Dim oDataSub2 As DataTable = Nothing
                Dim oRow As DataRow
                Dim PK(0) As DataColumn
                Dim iCont As Integer

                sFiltro = "Bolsa US$: " & VB.Format(Bolsa, "#,##0") & " - " & _
                          "Dolar R$: " & VB.Format(Dolar, "#,##0.0000") & " - " & _
                          "Preço Medio @ R$: " & VB.Format(ValorArroba, "#,##0.00")
                Str_Adicionar(sFiltro, IIf(oTipo = PosForn_FiltroExposure.feSoAdiantamentosContratosBase, "Analítico - Adto c/ Ctr Base", _
                                                                                                          "Analítico - Adto s/ Ctr Base"), " - ")

                oData = New DataTable

                With oData.Columns
                    .Add("NO_FILIAL")
                    .Add("NO_TIPO_CONTRATO")
                    .Add("NO_FORNECEDOR")
                    .Add("CD_CONTRATO_PAF")
                    .Add("DT_EMISSAO").DataType = System.Type.GetType("System.DateTime")
                    .Add("DT_PRAZO_FIXACAO").DataType = System.Type.GetType("System.DateTime")
                    .Add("DT_PRAZO_ENTREGA").DataType = System.Type.GetType("System.DateTime")
                    .Add("VALOR_UNIT").DataType = System.Type.GetType("System.Double")
                    .Add("QT_KG_CONTRATO").DataType = System.Type.GetType("System.Double")
                    .Add("QT_KG_CANCELADOS").DataType = System.Type.GetType("System.Double")
                    .Add("QT_KG_APLICADOS").DataType = System.Type.GetType("System.Double")
                    .Add("QT_KG_NEGOCIAR").DataType = System.Type.GetType("System.Double")
                    .Add("VL_PAGO_ABERTO").DataType = System.Type.GetType("System.Double")
                    .Add("VL_JUROS").DataType = System.Type.GetType("System.Double")
                    .Add("QT_KG_RECEBIDO").DataType = System.Type.GetType("System.Double")
                    .Add("VL_KG_RECEBIDO").DataType = System.Type.GetType("System.Double")
                End With

                PK(0) = oData.Columns("CD_CONTRATO_PAF")
                oData.PrimaryKey = PK

                '>> Pega a posição do fornecedor - Início
                oDataAux = Gera_Rs_Posicao_Fornecedor(Bolsa, Dolar, ValorArroba, True, oDataSub1, oDataSub2, False, False, "", -1, , , oTipo)

                For iCont = 0 To oDataAux.Rows.Count - 1
                    With oDataAux.Rows(iCont)
                        If .Item("CD_CONTRATO_PAF") = 74310463 And .Item("QT_KGS") = 900000 Then
                            .Item("CD_CONTRATO_PAF") = .Item("CD_CONTRATO_PAF")
                        End If
                        If (NVL(.Item("CD_TIPO"), 0) <= 2 And oTipo = PosForn_FiltroExposure.feSoAdiantamentoSemContratosBase) Or _
                           (NVL(.Item("CD_TIPO"), 0) = 3 And oTipo = PosForn_FiltroExposure.feSoAdiantamentosContratosBase) Then
                            oRow = oData.Rows.Find(.Item("CD_CONTRATO_PAF"))

                            If oRow Is Nothing Then
                                oRow = oData.NewRow
                                oRow.Item("CD_CONTRATO_PAF") = .Item("CD_CONTRATO_PAF")
                                oRow.Item("QT_KG_RECEBIDO") = 0
                                oRow.Item("VL_KG_RECEBIDO") = 0
                                oData.Rows.Add(oRow)
                            End If

                            oRow.Item("NO_FILIAL") = NVL(.Item("NO_FILIAL"), "")
                            oRow.Item("NO_TIPO_CONTRATO") = NVL(.Item("NO_TIPO"), "")
                            oRow.Item("NO_FORNECEDOR") = NVL(.Item("NO_FORNECEDOR"), "")
                            oRow.Item("CD_CONTRATO_PAF") = .Item("CD_CONTRATO_PAF")
                            oRow.Item("DT_EMISSAO") = .Item("DT_CONTRATO")
                            oRow.Item("DT_PRAZO_FIXACAO") = .Item("DT_PRAZO_FIXACAO")
                            oRow.Item("DT_PRAZO_ENTREGA") = .Item("DT_VENCIMENTO")
                            oRow.Item("VALOR_UNIT") = .Item("VL_CONTRATO")
                            oRow.Item("QT_KG_CONTRATO") = NVL(oRow.Item("QT_KG_CONTRATO"), 0) + .Item("QT_KGS")
                            oRow.Item("QT_KG_CANCELADOS") = NVL(oRow.Item("QT_KG_CANCELADOS"), 0) + .Item("QT_CANCELADO")
                            oRow.Item("QT_KG_APLICADOS") = NVL(oRow.Item("QT_KG_APLICADOS"), 0) + .Item("QT_KG_FIXO")
                            oRow.Item("QT_KG_NEGOCIAR") = NVL(oRow.Item("QT_KG_NEGOCIAR"), 0) + .Item("QT_A_NEGOCIAR")
                            oRow.Item("VL_PAGO_ABERTO") = NVL(oRow.Item("VL_PAGO_ABERTO"), 0) + .Item("VL_PAG_AB")
                            oRow.Item("VL_JUROS") = NVL(oRow.Item("VL_JUROS"), 0) + .Item("VL_JUROS")

                            If ((NVL(.Item("CD_TIPO"), 0) = 1 And oTipo = PosForn_FiltroExposure.feSoAdiantamentoSemContratosBase) Or _
                                (NVL(.Item("CD_TIPO"), 0) = 3 And oTipo = PosForn_FiltroExposure.feSoAdiantamentosContratosBase) Or .Item("CD_TIPO") = 2) And _
                                Not objDataTable_CampoVazio(.Item("SQ_NEGOCIACAO")) Then
                                oRow.Item("QT_KG_RECEBIDO") = NVL(oRow.Item("QT_KG_RECEBIDO"), 0) + .Item("QT_KG_A_FIXAR")
                                oRow.Item("VL_KG_RECEBIDO") = NVL(oRow.Item("VL_KG_RECEBIDO"), 0) + .Item("VL_QT_A_FIXAR")
                            End If
                        End If
                    End With
                Next
                '>> Pega a posição do fornecedor - Fim

                oRelatorio.Load(Application.StartupPath & "\RPT_Adiantamento_Exposure_Analitico.rpt")
                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Filtro", sFiltro)
        End Select

        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_ContratoComSaldo(ByVal ComIncidenciaINSS As Boolean, _
                                                    ByVal Dolar As Double, _
                                                    ByVal ListagemFilial As String, _
                                                    ByVal TipoCacau As Integer, _
                                                    ByVal Fornecedor As Integer) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable
        Dim SqlText As String

        Dim sFiltro As String

        Dim VL_NF_INSS_FIXO As String
        Dim VL_NF_INSS_FIXO_CTR As String

        If ComIncidenciaINSS Then
            VL_NF_INSS_FIXO = "VL_NF_INSS_FIXO"
            VL_NF_INSS_FIXO_CTR = "CTR.VL_NF_INSS_FIXO"
        Else
            VL_NF_INSS_FIXO = "0"
            VL_NF_INSS_FIXO_CTR = "0"
        End If

        SqlText = "SELECT FORN.NO_RAZAO_SOCIAL," & _
                         "CTR.CD_CONTRATO_PAF AS CD_CONTRATO," & _
                         "CTR.DT_CONTRATO_FIXO," & _
                         "CTR.QT_KGS," & _
                         "CTR.CD_TIPO_UNIDADE," & _
                         "CTR.VL_TOTAL," & _
                         "1 CD_TIPO_PRECO," & _
                         "(CTR.VL_NF_FIXO - " & VL_NF_INSS_FIXO_CTR & ") AS VL_NF_SFUN," & _
                         "(CTR.VL_NF_FIXO - " & VL_NF_INSS_FIXO_CTR & " - CTR.VL_NF_ICMS_FIXO) AS VL_NF_SI," & _
                         "CTR.QT_KG_FIXO AS QT_FIX," & _
                         "CTR.VL_PAG_FIXO + nvl(AMA.vl_aplicado,0) AS VL_PG," & _
                         "ROUND(DECODE(NVL(PAG.TAXA_MEDIA, 0), 0, " & Dolar & ", PAG.TAXA_MEDIA), 4) AS TAXA_US," & _
                         "CTR.PC_ALIQ_ICMS," & _
                         "FORN.CD_FILIAL_ORIGEM," & _
                         "FIL.NO_FILIAL," & _
                         "CTR.VL_ADENDO AS VL_ADENDO_CONTRATO," & _
                         "ROUND(NVL(REC.TOT_FIXO_US_SFUN, 0), 2) AS VL_NF_US_SFUN," & _
                         "ROUND(NVL(PAG.VL_PAGO_US, 0), 2) AS VL_PG_US," & _
                         "CTR.IC_STATUS," & _
                         "CTR.QT_CANCELADO AS QT_CANCELAMENTO," & _
                         "CTR.SQ_NEGOCIACAO," & _
                         "CTR.SQ_CONTRATO_FIXO" & _
                  " FROM SOF.FILIAL FIL," & _
                        "SOF.FORNECEDOR FORN," & _
                        "SOF.CONTRATO_FIXO CTR," & _
                        "SOF.NEGOCIACAO NEG," & _
                        "SOF.CONTRATO_PAF CP," & _
                        "(SELECT PNCF.CD_CONTRATO_PAF," & _
                                "PNCF.SQ_NEGOCIACAO," & _
                                "PNCF.SQ_CONTRATO_FIXO," & _
                                "SUM(DECODE(NVL(P.VL_TAXA_DOLAR, 0), 0, PNCF.VL_FIXO / " & Dolar & ", DECODE(P.VL_PAGAMENTO, 0, 0, ((PNCF.VL_FIXO / P.VL_PAGAMENTO) * P.VL_DOLAR)))) VL_PAGO_US," & _
                                "SUM(PNCF.VL_FIXO) VL_PAGO," & _
                                "AVG(NVL(P.VL_TAXA_DOLAR, 0)) TAXA_MEDIA" & _
                         " FROM SOF.PAG_NEG_CTR_FIX PNCF," & _
                               "SOF.PAGAMENTOS P" & _
                         " WHERE P.SQ_PAGAMENTO = PNCF.SQ_PAGAMENTO" & _
                           " AND (PNCF.CD_CONTRATO_PAF," & _
                                 "PNCF.SQ_NEGOCIACAO," & _
                                 "PNCF.SQ_CONTRATO_FIXO) IN (SELECT CD_CONTRATO_PAF," & _
                                                                   "SQ_NEGOCIACAO," & _
                                                                   "SQ_CONTRATO_FIXO" & _
                                                            " FROM SOF.CONTRATO_FIXO" & _
                                                            " WHERE VL_PAG_FIXO <> (VL_NF_FIXO - " & VL_NF_INSS_FIXO & ")" & _
                                                              " AND (VL_PAG_FIXO - (VL_NF_FIXO - " & VL_NF_INSS_FIXO & ")) <> 0" & _
                                                              " AND ((VL_PAG_FIXO - (VL_NF_FIXO - " & VL_NF_INSS_FIXO & ")) > 0.01 OR " & _
                                                                    "(VL_PAG_FIXO - (VL_NF_FIXO - " & VL_NF_INSS_FIXO & ")) < -0.01) AND IC_STATUS <> 'E') " & _
                         " GROUP BY PNCF.CD_CONTRATO_PAF," & _
                                   "PNCF.SQ_NEGOCIACAO," & _
                                   "PNCF.SQ_CONTRATO_FIXO) PAG," & _
                        "(SELECT A.CD_CONTRATO_PAF," & _
                                "A.SQ_NEGOCIACAO," & _
                                "A.SQ_CONTRATO_FIXO," & _
                                "SUM(NVL(A.VL_FIXO, 0) - ROUND(NVL(A.VL_FIXO, 0) / DECODE(NVL(B.VL_NF, 1), 0, 1, NVL(B.VL_NF, 1)) * NVL(B.VL_NF_ICMS, 0), 2) - ROUND(NVL(A.VL_FIXO, 0) / DECODE(NVL(B.VL_NF, 1), 0, 1, NVL(B.VL_NF, 1)) * NVL(B.VL_NF_FUNRURAL, 0), 2)) AS TOT_FIXO_SI," & _
                                "SUM(NVL(A.QT_KG_FIXO, 0)) AS QT_FIXO," & _
                                "SUM(NVL(A.VL_FIXO, 0) - ROUND((NVL(A.VL_FIXO, 0) / DECODE(NVL(B.VL_NF, 1), 0, 1, NVL(B.VL_NF, 1))) * NVL(B.VL_NF_FUNRURAL, 1), 2)) AS TOT_FIXO_SFUN," & _
                                "SUM((NVL(A.VL_FIXO, 0) / NVL(C.VL_TAXA, 1)) - ROUND((((NVL(A.VL_FIXO, 0) / NVL(C.VL_TAXA, 1)) / DECODE(NVL(B.VL_NF, 0), 0, 1, NVL(B.VL_NF, 0) / NVL(C.VL_TAXA, 1))) * (NVL(B.VL_NF_FUNRURAL, 0) / NVL(C.VL_TAXA, 1))), 2)) AS TOT_FIXO_US_SFUN" & _
                         " FROM SOF.TAXA_DOLAR C," & _
                               "SOF.CTR_PAF_NEG_CTR_FIX_MOV A," & _
                               "SOF.MOVIMENTACAO B" & _
                         " WHERE B.DT_MOVIMENTACAO = C.DT_COTACAO (+)" & _
                           " AND A.SQ_MOVIMENTACAO = B.SQ_MOVIMENTACAO" & _
                           " AND (A.CD_CONTRATO_PAF," & _
                                 "A.SQ_NEGOCIACAO," & _
                                 "A.SQ_CONTRATO_FIXO) IN (SELECT CD_CONTRATO_PAF," & _
                                                                "SQ_NEGOCIACAO," & _
                                                                "SQ_CONTRATO_FIXO" & _
                                                         " FROM SOF.CONTRATO_FIXO" & _
                                                         " WHERE VL_PAG_FIXO <> (VL_NF_FIXO - " & VL_NF_INSS_FIXO & ")" & _
                                                           " AND (VL_PAG_FIXO - (VL_NF_FIXO - " & VL_NF_INSS_FIXO & ")) <> 0" & _
                                                           " AND ((VL_PAG_FIXO - (VL_NF_FIXO - " & VL_NF_INSS_FIXO & ")) > 0.01 OR " & _
                                                                 "(VL_PAG_FIXO - (VL_NF_FIXO - " & VL_NF_INSS_FIXO & ")) < -0.01) AND IC_STATUS <> 'E') " & _
                         " GROUP BY A.CD_CONTRATO_PAF," & _
                                   "A.SQ_NEGOCIACAO," & _
                                   "A.SQ_CONTRATO_FIXO) REC, " & _
                          cnt_SQL_Amarracao_Aplicacao & " AMA " & _
                  " WHERE FORN.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND FORN.CD_FORNECEDOR = CP.CD_FORNECEDOR" & _
                    " AND CTR.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                    " AND NEG.CD_CONTRATO_PAF = CTR.CD_CONTRATO_PAF" & _
                    " AND NEG.SQ_NEGOCIACAO = CTR.SQ_NEGOCIACAO" & _
                    " AND PAG.CD_CONTRATO_PAF (+) = CTR.CD_CONTRATO_PAF" & _
                    " AND PAG.SQ_NEGOCIACAO (+) = CTR.SQ_NEGOCIACAO" & _
                    " AND PAG.SQ_CONTRATO_FIXO (+) = CTR.SQ_CONTRATO_FIXO" & _
                    " AND AMA.CD_CONTRATO_PAF (+) = CTR.CD_CONTRATO_PAF" & _
                    " AND AMA.SQ_NEGOCIACAO (+) = CTR.SQ_NEGOCIACAO" & _
                    " AND AMA.SQ_CONTRATO_FIXO (+) = CTR.SQ_CONTRATO_FIXO" & _
                    " AND REC.CD_CONTRATO_PAF (+) = CTR.CD_CONTRATO_PAF" & _
                    " AND REC.SQ_NEGOCIACAO (+) = CTR.SQ_NEGOCIACAO" & _
                    " AND REC.SQ_CONTRATO_FIXO (+) = CTR.SQ_CONTRATO_FIXO" & _
                    " AND CTR.VL_PAG_FIXO+ nvl(AMA.vl_aplicado,0) <> (CTR.VL_NF_FIXO - " & VL_NF_INSS_FIXO_CTR & ")" & _
                    " AND (CTR.VL_PAG_FIXO+ nvl(AMA.vl_aplicado,0) - (CTR.VL_NF_FIXO - " & VL_NF_INSS_FIXO_CTR & ")) <> 0" & _
                    " AND ((CTR.VL_PAG_FIXO+ nvl(AMA.vl_aplicado,0) - (CTR.VL_NF_FIXO - " & VL_NF_INSS_FIXO_CTR & ")) > 0.01 OR " & _
                          "(CTR.VL_PAG_FIXO+ nvl(AMA.vl_aplicado,0) - (CTR.VL_NF_FIXO - " & VL_NF_INSS_FIXO_CTR & ")) < -0.01)" & _
                    " AND CTR.IC_STATUS <> 'E'"
        'FILTRO FILIAL

        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND FORN.CD_FILIAL_ORIGEM IN (" & ListagemFilial & ")"
            Str_Adicionar(sFiltro, "Filial do Fornecedor: " & DBQuery_ValorUnico_Lista("SELECT TRIM(NO_FILIAL) NO_FILIAL FROM SOF.FILIAL WHERE CD_FILIAL IN (" & ListagemFilial & ")"), " - ")
        End If
        If TipoCacau > 0 Then
            SqlText = SqlText & " AND NEG.CD_TIPO_CACAU = " & TipoCacau
            Str_Adicionar(sFiltro, "Tipo de Cacau: " & DBQuery_ValorUnico("SELECT TRIM(NO_TIPO_CACAU) FROM SOF.TIPO_CACAU WHERE CD_TIPO_CACAU = " & TipoCacau), " - ")
        End If
        If Fornecedor > 0 Then
            SqlText = SqlText & " AND CP.CD_FORNECEDOR = " & Fornecedor
            Str_Adicionar(sFiltro, "Fornecedor: " & MontaFiltro_Fornecedor(Fornecedor), " - ")
        End If

        Str_Adicionar(sFiltro, "Data Sistema: " & DataSistema(), " - ")
        Str_Adicionar(sFiltro, "Taxa US padrão: " & Dolar, " - ")

        If Not ComIncidenciaINSS Then
            Str_Adicionar(sFiltro, "Sem incidência de INSS", " - ")
        End If

        oData = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_Contrato_Com_Saldo.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("VLMIN", DBQuery_ValorUnico("SELECT P.VL_MINIMO_NF_COMPLEMENTAR FROM SOF.PARAMETRO P", 0))
        oRelatorio.SetParameterValue("TP_INCIDENCIA_INSS", IIf(ComIncidenciaINSS, "S", "N"))
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_ContratoEmAberto_PAF(ByVal ListagemFilial As String, _
                                                        ByVal ListagemTipoContrato As String, _
                                                        ByVal Fornecedor As Integer, _
                                                        ByVal Opcao As String) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable

        Dim sFiltro As String = ""

        If Trim(ListagemFilial) <> "" Then
            Str_Adicionar(sFiltro, "Filial: " & MontaFiltro_Filial(ListagemFilial), " - ")
        End If
        If Trim(ListagemTipoContrato) <> "" Then
            Str_Adicionar(sFiltro, "Tipo Contrato: " & MontaFiltro_Filial(ListagemTipoContrato), " - ")
        End If
        If Fornecedor > 0 Then
            Str_Adicionar(sFiltro, "Fornecedor: " & MontaFiltro_Fornecedor(Fornecedor), " - ")
        End If

        oData = Gera_Rs_ContratoEmAberto_CtrPAF(Fornecedor, ListagemFilial, ListagemTipoContrato, Opcao)
        oRelatorio.Load(Application.StartupPath & "\RPT_Contrato_PAF_Aberto.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_ContratoEmAberto_Negociacao(ByVal DataInicial As String, _
                                                               ByVal DataFinal As String, _
                                                               ByVal ListagemFilial As String, _
                                                               ByVal ListagemTipoContrato As String, _
                                                               ByVal Fornecedor As Integer) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable

        Dim sFiltro As String = ""

        If Trim(ListagemFilial) <> "" Then
            Str_Adicionar(sFiltro, "Filial: " & MontaFiltro_Filial(ListagemFilial), " - ")
        End If
        If Trim(ListagemTipoContrato) <> "" Then
            Str_Adicionar(sFiltro, "Tipo Contrato: " & MontaFiltro_TipoContratoPAF(ListagemTipoContrato), " - ")
        End If
        If Fornecedor > 0 Then
            Str_Adicionar(sFiltro, "Fornecedor: " & MontaFiltro_Fornecedor(Fornecedor), " - ")
        End If

        oData = Gera_Rs_ContratoEmAberto_Neg(DataInicial, _
                                             DataFinal, _
                                             Fornecedor, _
                                             ListagemFilial, _
                                             ListagemTipoContrato)
        oRelatorio.Load(Application.StartupPath & "\RPT_Negociacao_Aberto.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_ContratoEmAberto_ContratoFixo(ByVal DataInicial As String, _
                                                                 ByVal DataFinal As String, _
                                                                 ByVal ListagemFilial As String, _
                                                                 ByVal Fornecedor As Integer) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable
        Dim SqlText As String

        Dim sFiltro As String = ""

        If Trim(ListagemFilial) <> "" Then
            Str_Adicionar(sFiltro, "Filial: " & MontaFiltro_Filial(ListagemFilial), " - ")
        End If
        If Fornecedor > 0 Then
            Str_Adicionar(sFiltro, "Fornecedor: " & MontaFiltro_Fornecedor(Fornecedor), " - ")
        End If

        Str_Adicionar(sFiltro, "Data do Sistema: " & DataSistema(), " - ")

        oData = Gera_Rs_ContratoEmAberto_CtrFixo(DataInicial, DataFinal, Fornecedor, ListagemFilial)
        oRelatorio.Load(Application.StartupPath & "\RPT_Contrato_Fixo_Aberto.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("DataHoje", DataSistema)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_NetSaldo(ByVal Bolsa As Double, _
                                            ByVal Dolar As Double, _
                                            ByVal ValorArroba As Double, _
                                            ByVal ListagemSafra As String, _
                                            ByVal ListagemFilial As String, _
                                            ByVal ListagemModalidadeCredito As String, _
                                            ByVal SomenteNegativos As Boolean, _
                                            ByVal Tipo As String, _
                                            ByVal OrdemCrescente As Boolean) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable
        Dim SqlText As String

        Dim sFiltro As String = ""

        oData = Gera_Rs_NetSaldo(Bolsa, Dolar, ValorArroba, (Tipo = cnt_NetSaldo_TipoRelatorio_Sintetico), _
                                 ListagemSafra, ListagemFilial, ListagemModalidadeCredito, _
                                 SomenteNegativos)

        Select Case Tipo
            Case cnt_NetSaldo_TipoRelatorio_Sintetico
                oRelatorio.Load(Application.StartupPath & "\RPT_Net_Saldo_Sintetico.rpt")
                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Titulo", "Posição Net de Saldos")
            Case cnt_NetSaldo_TipoRelatorio_Filial
                oRelatorio.Load(Application.StartupPath & "\RPT_Net_Saldo_Filial.rpt")
                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Titulo", "Posição Net de Saldos - Resumido")
            Case cnt_NetSaldo_TipoRelatorio_Fornecedor
                oRelatorio.Load(Application.StartupPath & "\RPT_Net_Saldo_Fornecedor.rpt")
                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Titulo", "Posição Net de Saldos")
            Case cnt_NetSaldo_TipoRelatorio_Titular
                oRelatorio.Load(Application.StartupPath & "\RPT_Net_Saldo_Titular.rpt")
                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Titulo", "Posição Net de Saldos - Resumido por titular")
        End Select

        sFiltro = "Bolsa US$: " & VB.Format(Bolsa, "#,##0") & _
                  " - Dolar R$: " & VB.Format(Dolar, "#,##0.0000") & _
                  " - Preço Medio @ R$: " & VB.Format(ValorArroba, "#,##0.00")

        If Trim(ListagemSafra) <> "" Then
            SqlText = "SELECT NO_SAFRA FROM SOF.SAFRA WHERE CD_SAFRA IN (" & ListagemSafra & ")"

            Str_Adicionar(sFiltro, "Safras:" & DBQuery_ValorUnico_Lista(SqlText), " - ")
        End If

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        'FORMULA APENAS DO ANALITICO
        If Tipo = cnt_NetSaldo_TipoRelatorio_Titular Then
            If OrdemCrescente Then
                oRelatorio.SetParameterValue("IC_ORDENACAO", "S")
            Else
                oRelatorio.SetParameterValue("IC_ORDENACAO", "N")
            End If
        End If

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_FluxoCaixa(ByVal DataInicial As String, _
                                              ByVal DataFinal As String, _
                                              ByVal VL_Dolar As Double, _
                                              ByVal VL_Bolsa As Double, _
                                              ByVal VL_ValorArroba As Double, _
                                              ByVal ListagemFilial As String, _
                                              ByVal bSintetico As Boolean) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData_Master As DataTable
        Dim oData As DataTable
        Dim oRow01 As DataRow
        Dim oRow02 As DataRow

        Dim SqlText As String = ""
        Dim sFiltro As String = ""
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim bAdicionarRow As Boolean

        Dim blTitular As Boolean
        Dim DT_Cotacao As Date
        Dim Fornecedor As String = ""
        Dim DtInicialSafra As Date

        Dim Valorizacao As Double

        SqlText = "SELECT * FROM SOF.FORNECEDOR F, SOF.MUNICIPIO M WHERE F.CD_MUNICIPIO = M.CD_MUNICIPIO AND M.CD_UF ='EX'"
        oData = DBQuery(SqlText)

        DtInicialSafra = DataInicial

        If DtInicialSafra.Month < 6 Then
            DtInicialSafra = CDate("01/06/" & DtInicialSafra.Year - 1)
        Else
            DtInicialSafra = CDate("01/06/" & DtInicialSafra.Year)
        End If

        For iCont_01 = 0 To oData.Rows.Count - 1
            Str_Adicionar(Fornecedor, Trim(oData.Rows(iCont_01).Item("CD_FORNECEDOR")), ",")
        Next

        If DtInicialSafra.Month < 6 Then
            DtInicialSafra = CDate("01/06/" & DtInicialSafra.Year - 1)
        Else
            DtInicialSafra = CDate("01/06/" & DtInicialSafra.Year)
        End If

        '>> Carregar as valores usados na consulta de Cacau a Ordem - Início
        SqlText = "SELECT MAX(LCM.DT_COTACAO) DT_COTACAO" & _
                  " FROM SOF.LIMITE_CREDITO_MOEDA LCM " & _
                  " WHERE LCM.DT_COTACAO <= TO_DATE('" & Date_to_Oracle(DataSistema) & "')"
        DT_Cotacao = DBQuery_ValorUnico(SqlText)
        '>> Carregar as valores usados na consulta de Cacau a Ordem - Fim

        '>> Montagem dos grupo Pagamentos Realizados no Período e Reccebimentos de Cacau no Período Base
        SqlText = "SELECT FIL.CD_FILIAL," & _
                         "FIL.NO_FILIAL," & _
                         "Null AS VALOR1," & _
                         "Null AS VALOR2," & _
                         "SUM(PC.VL_FIXO) VALOR3," & _
                         "SUM(ROUND(PC.VL_FIXO  / NVL(P.VL_TAXA_DOLAR, " & VL_Dolar & "), 2)) AS VALOR4," & _
                         "1 CDGRUPO," & _
                         "'PAGAMENTOS REALIZADOS NO PERÍODO' GRUPO," & _
                         "1 CDSUBGRUPO," & _
                         "'Alocados em Contratos Preço Fixo' AS SUBGRUPO," & _
                         "'' TEXTO1," & _
                         "'' TEXTO2," & _
                         "'Valores R$' TEXTO3," & _
                         "'Valores U$' TEXTO4" & _
                  " FROM SOF.PAGAMENTOS P," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.PAG_NEG_CTR_FIX PC," & _
                        "SOF.FORNECEDOR F" & _
                  " WHERE F.CD_FILIAL_ORIGEM  = FIL.CD_FILIAL" & _
                    " AND P.CD_FORNECEDOR=F.CD_FORNECEDOR" & _
                    " AND P.SQ_PAGAMENTO = PC.SQ_PAGAMENTO" & _
                    " AND P.CD_FORMA_PAGAMENTO IN ( 2,1)" & _
                    " AND P.DT_PAGAMENTO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                           " AND " & QuotedStr(Date_to_Oracle(DataFinal))

        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListagemFilial & ")"
        Else
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & "GROUP BY FIL.CD_FILIAL," & _
                                     "FIL.NO_FILIAL" & _
                            " UNION ALL " & _
                            "SELECT FIL.CD_FILIAL," & _
                                   "FIL.NO_FILIAL," & _
                                   "Null VALOR1," & _
                                   "Null VALOR2," & _
                                   "SUM(PC.VL_A_FIXAR) VALOR3," & _
                                   "SUM(ROUND(pc.vl_a_fixar /  NVL(P.VL_TAXA_DOLAR, " & VL_Dolar & "), 2)) AS VALOR4," & _
                                   "1 CDGRUPO," & _
                                   "'PAGAMENTOS REALIZADOS NO PERÍODO' GRUPO," & _
                                   "2 CDSUBGRUPO," & _
                                   "'Alocados em Contratos com Dif. de Bolsa' AS SUBGRUPO," & _
                                   "'' TEXTO1," & _
                                   "'' TEXTO2," & _
                                   "'Valores R$' TEXTO3," & _
                                   "'Valores U$' TEXTO4" & _
                            " FROM SOF.PAGAMENTOS P," & _
                                  "SOF.FILIAL FIL," & _
                                  "SOF.PAG_NEG PC," & _
                                  "SOF.FORNECEDOR F" & _
                            " WHERE F.CD_FILIAL_ORIGEM =  FIL.CD_FILIAL" & _
                              " AND P.CD_FORNECEDOR=F.CD_FORNECEDOR" & _
                              " AND P.SQ_PAGAMENTO = PC.SQ_PAGAMENTO" & _
                              " AND P.CD_FORMA_PAGAMENTO IN (2, 1)" & _
                              " AND P.DT_PAGAMENTO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                     " AND " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                              " AND PC.VL_A_FIXAR <> 0 "

        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListagemFilial & ")"
        Else
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & "GROUP BY FIL.CD_FILIAL," & _
                                     "FIL.NO_FILIAL" & _
                            " UNION ALL " & _
                            "SELECT FIL.CD_FILIAL," & _
                                   "FIL.NO_FILIAL," & _
                                   "Null VALOR1," & _
                                   "Null VALOR2," & _
                                   "SUM(PC.VL_A_FIXAR) VALOR3," & _
                                   "SUM(ROUND(pc.vl_a_fixar /  NVL(P.VL_TAXA_DOLAR, " & VL_Dolar & "), 2)) AS VALOR4," & _
                                   "1 CDGRUPO," & _
                                   "'PAGAMENTOS REALIZADOS NO PERÍODO' GRUPO," & _
                                   "3 CDSUBGRUPO," & _
                                   "'Alocados em Contrato PAF com Adto' AS SUBGRUPO," & _
                                   "'' TEXTO1," & _
                                   "'' TEXTO2," & _
                                   "'Valores R$' TEXTO3," & _
                                   "'Valores U$' TEXTO4" & _
                            " FROM SOF.PAGAMENTOS P," & _
                                  "SOF.FILIAL FIL," & _
                                  "SOF.PAG_CTR_PAF PC," & _
                                  "SOF.CONTRATO_PAF CP," & _
                                  "SOF.FORNECEDOR F" & _
                            " WHERE F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                              " AND P.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                              " AND P.SQ_PAGAMENTO = PC.SQ_PAGAMENTO" & _
                              " AND P.CD_FORMA_PAGAMENTO IN (2, 1)" & _
                              " AND P.DT_PAGAMENTO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                     " AND " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                              " AND PC.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                              " AND PC.VL_A_FIXAR <> 0"

        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListagemFilial & ")"
        Else
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & "GROUP BY FIL.CD_FILIAL," & _
                                     "FIL.NO_FILIAL" & _
                                    " UNION ALL "
        SqlText = SqlText & "SELECT   fil.cd_filial, fil.no_filial, "
        SqlText = SqlText & "         Null VALOR1, "
        SqlText = SqlText & "         Null VALOR2, "
        SqlText = SqlText & "         SUM(PC.VL_APLICACAO) VALOR3, "
        SqlText = SqlText & "         SUM(ROUND(pc.vl_aplicacao /  NVL(P.VL_TAXA_DOLAR, " & VL_Dolar & "), 2)) AS VALOR4, "
        SqlText = SqlText & "         1 CDGRUPO, "
        SqlText = SqlText & "         'PAGAMENTOS REALIZADOS NO PERÍODO' grupo, "
        SqlText = SqlText & "         DECODE (c.cd_conciliacao_modalidade, 23, 4, 5) cdsubgrupo, "
        SqlText = SqlText & "         DECODE (c.cd_conciliacao_modalidade, "
        SqlText = SqlText & "                 23, 'ICMS Recuperado', "
        SqlText = SqlText & "                 'Pagamento Estornado' "
        SqlText = SqlText & "                ) AS subgrupo, "
        SqlText = SqlText & "         '' texto1, "
        SqlText = SqlText & "         '' texto2, "
        SqlText = SqlText & "         'Valores R$' texto3, "
        SqlText = SqlText & "         'Valores U$' texto4 "
        SqlText = SqlText & "    FROM sof.pagamentos p, "
        SqlText = SqlText & "         sof.filial fil, "
        SqlText = SqlText & "         sof.conciliacao_pagamento pc, "
        SqlText = SqlText & "         sof.conciliacao c, "
        SqlText = SqlText & "         sof.fornecedor f "
        SqlText = SqlText & "   WHERE f.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "     AND p.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "     AND p.sq_pagamento = pc.sq_pagamento "
        SqlText = SqlText & "     AND pc.sq_conciliacao = c.sq_conciliacao "
        SqlText = SqlText & "     AND p.cd_forma_pagamento IN (2, 1) "
        SqlText = SqlText & "     AND p.dt_pagamento BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                     " AND " & QuotedStr(Date_to_Oracle(DataFinal))
        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListagemFilial & ")"
        Else
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & "GROUP BY fil.cd_filial, fil.no_filial, c.cd_conciliacao_modalidade "

        SqlText = SqlText & " UNION ALL " & _
                            "SELECT FIL.CD_FILIAL," & _
                                   "FIL.NO_FILIAL," & _
                                   "SUM(MC.QT_KG_FIXO) VALOR1," & _
                                   "round(SUM(MC.QT_KG_FIXO)/60,0) AS VALOR2," & _
                                   "Null VALOR3," & _
                                   "Null VALOR4," & _
                                   "5 CDGRUPO," & _
                                   "'ENTRADAS DE CACAU NO PERÍODO BASE' GRUPO," & _
                                   "1 CDSUBGRUPO," & _
                                   "'Alocados em Contratos Preço Fixo' AS SUBGRUPO," & _
                                   "'Kgs Recebidos' TEXTO1," & _
                                   "'Sacos Recebidos' TEXTO2," & _
                                   "'' TEXTO3," & _
                                   "'' TEXTO4" & _
                            " FROM SOF.MOVIMENTACAO M," & _
                                  "SOF.FILIAL FIL," & _
                                  "SOF.CTR_PAF_NEG_CTR_FIX_MOV MC," & _
                                  "SOF.FORNECEDOR F, sof.municipio mun" & _
                            " WHERE F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                              " AND M.CD_FORNECEDOR=F.CD_FORNECEDOR" & _
                              " AND M.SQ_MOVIMENTACAO = MC.SQ_MOVIMENTACAO" & _
                               " AND f.cd_municipio = Mun.cd_municipio and mun.cd_uf <> 'EX' " & _
                              " AND M.DT_MOVIMENTACAO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                        " AND " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                              " AND M.CD_TIPO_MOVIMENTACAO = 100"

        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListagemFilial & ")"
        Else
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & "GROUP BY FIL.CD_FILIAL," & _
                                     "FIL.NO_FILIAL" & _
                            " UNION ALL " & _
                            "SELECT FIL.CD_FILIAL," & _
                                   "FIL.NO_FILIAL," & _
                                   "SUM(MC.QT_KG_A_FIXAR) VALOR1," & _
                                   "round(SUM(MC.QT_KG_FIXO)/60,0) AS VALOR2," & _
                                   "Null VALOR3," & _
                                   "Null VALOR4," & _
                                   "5 CDGRUPO," & _
                                   "'ENTRADAS DE CACAU NO PERÍODO BASE' GRUPO," & _
                                   "2 CDSUBGRUPO," & _
                                   "'Alocados em Contratos com Dif. de Bolsa' AS SUBGRUPO," & _
                                   "'Kgs Recebidos' TEXTO1," & _
                                   "'Sacos Recebidos' TEXTO2," & _
                                   "'' TEXTO3," & _
                                   "'' TEXTO4" & _
                            " FROM SOF.MOVIMENTACAO M," & _
                                  "SOF.FILIAL FIL," & _
                                  "SOF.CTR_PAF_NEG_MOVIMENTACAO MC," & _
                                  "SOF.FORNECEDOR F, sof.municipio mun " & _
                            " WHERE F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                              " AND M.CD_FORNECEDOR=F.CD_FORNECEDOR" & _
                              " AND M.SQ_MOVIMENTACAO = MC.SQ_MOVIMENTACAO" & _
                                " AND f.cd_municipio = Mun.cd_municipio and mun.cd_uf <> 'EX' " & _
                              " AND M.DT_MOVIMENTACAO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                        " AND " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                              " AND M.CD_TIPO_MOVIMENTACAO = 100" & _
                              " AND (MC.VL_A_FIXAR <> 0 OR MC.QT_KG_A_FIXAR <> 0)"

        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListagemFilial & ")"
        Else
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & "GROUP BY FIL.CD_FILIAL," & _
                                     "FIL.NO_FILIAL " & _
                            " UNION ALL " & _
                            "SELECT FIL.CD_FILIAL," & _
                                   "FIL.NO_FILIAL," & _
                                   "SUM(MC.QT_KG_A_FIXAR) VALOR1," & _
                                   "round(SUM(MC.QT_KG_FIXO)/60,0) AS VALOR2," & _
                                   "Null VALOR3," & _
                                   "Null VALOR4," & _
                                   "5 CDGRUPO," & _
                                   "'ENTRADAS DE CACAU NO PERÍODO BASE' GRUPO," & _
                                   "CP.CD_TIPO_CONTRATO_PAF + 2 CDSUBGRUPO," & _
                                   "DECODE(CP.CD_TIPO_CONTRATO_PAF + 2 ,3,'Alocados em Contrato PAF com Adto','Alocados a Ordem' ) AS SUBGRUPO," & _
                                   "'Kgs Recebidos' TEXTO1," & _
                                   "'Sacos Recebidos' TEXTO2," & _
                                   "'' TEXTO3," & _
                                   "'' TEXTO4" & _
                            " FROM SOF.MOVIMENTACAO M," & _
                                  "SOF.CONTRATO_PAF CP," & _
                                  "SOF.FILIAL FIL," & _
                                  "SOF.CTR_PAF_MOVIMENTACAO MC," & _
                                  "SOF.FORNECEDOR F, sof.municipio mun " & _
                            " WHERE F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                              " AND M.CD_FORNECEDOR=F.CD_FORNECEDOR" & _
                              " AND MC.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                              " AND M.SQ_MOVIMENTACAO = MC.SQ_MOVIMENTACAO" & _
                                " AND f.cd_municipio = Mun.cd_municipio and mun.cd_uf <> 'EX' " & _
                              " AND M.DT_MOVIMENTACAO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                        " AND " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                              " AND M.CD_TIPO_MOVIMENTACAO = 100" & _
                              " AND (MC.VL_A_FIXAR <> 0 OR MC.QT_KG_A_FIXAR <> 0)"

        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListagemFilial & ")"
        Else
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & "GROUP BY CP.CD_TIPO_CONTRATO_PAF," & _
                                     "FIL.CD_FILIAL," & _
                                     "FIL.NO_FILIAL " & _
                            "UNION ALL " & _
                            "SELECT fil.cd_filial, fil.no_filial, SUM (MOV.QT_KG_LIQUIDO_NF) valor1," & _
                                   "ROUND (SUM (MOV.QT_KG_LIQUIDO_NF) / 60, 0) AS valor2, NULL valor3," & _
                                   "NULL valor4, 5 cdgrupo, 'ENTRADAS DE CACAU NO PERÍODO BASE' grupo," & _
                                   "5 cdsubgrupo," & _
                                   "'Devoluções de Cacau a Fornecedor' AS subgrupo," & _
                                   "'Kgs Recebidos' texto1, 'Sacos Recebidos' texto2, '' texto3," & _
                                   "'' texto4" & _
                            " FROM SOF.MOVIMENTACAO MOV," & _
                                  "SOF.FILIAL FIL" & _
                            " WHERE MOV.DT_MOVIMENTACAO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                          " AND " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                              " AND MOV.CD_TIPO_MOVIMENTACAO IN (27, 103, 154, 134)" & _
                              " AND FIL.CD_FILIAL = MOV.CD_FILIAL_MOVIMENTACAO"

        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListagemFilial & ")"
        Else
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & _
                            " GROUP BY fil.CD_FILIAL, fil.NO_FILIAL" & _
                            " UNION ALL " & _
                            "SELECT FIL.CD_FILIAL," & _
                                   "FIL.NO_FILIAL," & _
                                   "SUM(CF.QT_KGS - CF.QT_CANCELADO) VALOR1," & _
                                   "ROUND(SUM(CF.QT_KGS - CF.QT_CANCELADO) / 60, 0) AS VALOR2," & _
                                   "Null VALOR3," & _
                                   "Null VALOR4," & _
                                   "4 CDGRUPO," & _
                                   "'COMPRAS' GRUPO," & _
                                   "1 CDSUBGRUPO," & _
                                   "'Contratos Periodo' AS SUBGRUPO," & _
                                   "'Quantidade Kg' TEXTO1," & _
                                   "'Quantidade Sacos' TEXTO2," & _
                                   "'' TEXTO3," & _
                                   "'' TEXTO4" & _
                            " FROM SOF.CONTRATO_FIXO CF," & _
                                  "SOF.CONTRATO_PAF CP," & _
                                  "SOF.FORNECEDOR F," & _
                                  "SOF.FILIAL FIL, sof.municipio mun  " & _
                            " WHERE CF.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                              " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                              " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL and cf.ic_status<>'E' " & _
                              " AND f.cd_municipio = Mun.cd_municipio and mun.cd_uf <> 'EX' " & _
                              " AND CF.DT_CONTRATO_FIXO BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                                                          " AND " & QuotedStr(Date_to_Oracle(DataFinal))

        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListagemFilial & ")"
        Else
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & "GROUP BY FIL.CD_FILIAL," & _
                                     "FIL.NO_FILIAL" & _
                            " UNION ALL " & _
                            "SELECT FIL.CD_FILIAL," & _
                                   "FIL.NO_FILIAL," & _
                                   "SUM(CF.QT_KGS - CF.QT_CANCELADO) VALOR1," & _
                                   "ROUND (SUM (CF.QT_KGS - CF.QT_CANCELADO) / 60, 0) AS VALOR2," & _
                                   "Null VALOR3," & _
                                   "Null VALOR4," & _
                                   "4 CDGRUPO," & _
                                   "'COMPRAS' GRUPO," & _
                                   "2 CDSUBGRUPO," & _
                                   "'Compras Acumuladas' AS SUBGRUPO," & _
                                   "'Quantidade Kg' TEXTO1," & _
                                   "'Quantidade Sacos' TEXTO2," & _
                                   "'' TEXTO3," & _
                                   "'' TEXTO4" & _
                            " FROM SOF.CONTRATO_FIXO CF," & _
                                  "SOF.CONTRATO_PAF CP," & _
                                  "SOF.FORNECEDOR F," & _
                                  "SOF.FILIAL FIL,  sof.municipio mun " & _
                            " WHERE CF.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                              " AND CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                              " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL and cf.ic_status<>'E' " & _
                              " AND f.cd_municipio = Mun.cd_municipio and mun.cd_uf <> 'EX' " & _
                              " AND CF.DT_CONTRATO_FIXO BETWEEN " & QuotedStr(Date_to_Oracle(DtInicialSafra)) & _
                                                         " AND " & QuotedStr(Date_to_Oracle(DataFinal))

        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListagemFilial & ")"
        Else
            SqlText = SqlText & " AND FIL.CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        SqlText = SqlText & "GROUP BY FIL.CD_FILIAL," & _
                                     "FIL.NO_FILIAL "
        oData_Master = DBQuery(SqlText)

        '>> Montagem dos grupos Pagamentos Futuros / CTRs em Aberto e Cacau A Ordem
        oData = Gera_Rs_Posicao_Fornecedor(VL_Bolsa, VL_Dolar, VL_ValorArroba, _
                                           blTitular, Nothing, Nothing, True, False, _
                                           "", -1, IIf(Trim(ListagemFilial) = "", ListarIDFiliaisLiberadaUsuario, ListagemFilial), "")

        For iCont_01 = 0 To oData.Rows.Count - 1
            bAdicionarRow = False
            oRow01 = Nothing
            oRow02 = Nothing

            If (oData.Rows(iCont_01).Item("CD_TIPO") = 1 Or _
                oData.Rows(iCont_01).Item("CD_TIPO") = 2 Or _
                oData.Rows(iCont_01).Item("CD_TIPO") = 3) And _
                InStr(Trim(Fornecedor) + ",", Trim(NVL(oData.Rows(iCont_01).Item("CD_FORNECEDOR"), -1)) + ",") = 0 Then
                For iCont_02 = 0 To oData_Master.Rows.Count - 1
                    'Pesquisa para verificar se o registro já existe
                    If oData_Master.Rows(iCont_02).Item("cd_filial") = oData.Rows(iCont_01).Item("CD_FILIAL") And _
                       ((oData.Rows(iCont_01).Item("CD_TIPO") = 1 And oData.Rows(iCont_01).Item("CD_TIPO_CONTRATO_PAF") = 2) Or _
                        oData.Rows(iCont_01).Item("CD_TIPO") = 2 Or _
                        oData.Rows(iCont_01).Item("CD_TIPO") = 3) Then
                        Select Case oData.Rows(iCont_01).Item("CD_TIPO")
                            Case 1 'Cacau a Ordem
                                If oData.Rows(iCont_01).Item("cd_tipo_contrato_paf") = 2 Then
                                    If oData_Master.Rows(iCont_02).Item("cdgrupo") = 3 And _
                                       oData_Master.Rows(iCont_02).Item("cdsubgrupo") = 1 Then
                                        oRow01 = oData_Master.Rows(iCont_02)

                                        Exit For
                                    End If
                                Else
                                    If oData_Master.Rows(iCont_02).Item("cdgrupo") = 3 And _
                                       oData_Master.Rows(iCont_02).Item("cdsubgrupo") = 2 Then
                                        oRow01 = oData_Master.Rows(iCont_02)

                                        Exit For
                                    End If
                                End If
                            Case 2
                                'Contratos com Diff. de Bolsa Fixado e Cacau Recebido
                                If oData_Master.Rows(iCont_02).Item("cdgrupo") = 2 And _
                                   oData_Master.Rows(iCont_02).Item("cdsubgrupo") = 2 And _
                                   oRow01 Is Nothing Then
                                    oRow01 = oData_Master.Rows(iCont_02)
                                End If
                                'Contratos com Diff. de Bolsa Fixado e Cacau a Receber
                                If oData_Master.Rows(iCont_02).Item("cdgrupo") = 2 And _
                                   oData_Master.Rows(iCont_02).Item("cdsubgrupo") = 4 And _
                                   oRow02 Is Nothing Then
                                    oRow02 = oData_Master.Rows(iCont_02)
                                End If

                                If Not oRow01 Is Nothing And Not oRow02 Is Nothing Then
                                    Exit For
                                End If
                            Case 3
                                'Contrato com Preço Fixo
                                If oData_Master.Rows(iCont_02).Item("cdgrupo") = 2 And _
                                   oData_Master.Rows(iCont_02).Item("cdsubgrupo") = 1 And _
                                   oRow01 Is Nothing Then
                                    oRow01 = oData_Master.Rows(iCont_02)
                                End If
                                'Contratos com Preço Fixo e Cacau a Receber
                                If oData_Master.Rows(iCont_02).Item("cdgrupo") = 2 And _
                                   oData_Master.Rows(iCont_02).Item("cdsubgrupo") = 3 And _
                                   oRow02 Is Nothing Then
                                    oRow02 = oData_Master.Rows(iCont_02)
                                End If

                                If Not oRow01 Is Nothing And Not oRow02 Is Nothing Then
                                    Exit For
                                End If
                        End Select
                    End If
                Next

                If oRow01 Is Nothing Then
                    oRow01 = oData_Master.NewRow
                    bAdicionarRow = True
                End If

                oRow01.Item("cd_filial") = oData.Rows(iCont_01).Item("CD_FILIAL")
                oRow01.Item("no_filial") = oData.Rows(iCont_01).Item("NO_FILIAL")

                Select Case oData.Rows(iCont_01).Item("CD_TIPO")
                    Case 1
                        If oData.Rows(iCont_01).Item("cd_tipo_contrato_paf") = 1 Then
                            oRow01.Item("cdgrupo") = 3
                            oRow01.Item("grupo") = "SALDO DE CACAU NPE"
                            oRow01.Item("cdsubgrupo") = 2
                            oRow01.Item("subgrupo") = "Cacau NPE - PAF C/ ADTO"
                        Else
                            oRow01.Item("cdgrupo") = 3
                            oRow01.Item("grupo") = "SALDO DE CACAU NPE"
                            oRow01.Item("cdsubgrupo") = 1
                            oRow01.Item("subgrupo") = "Cacau NPE"
                        End If

                        oRow01.Item("valor1") = NVL(oRow01.Item("valor1"), 0) + oData.Rows(iCont_01).Item("QT_KG_A_FIXAR")
                        oRow01.Item("valor2") = NVL(oRow01.Item("valor2"), 0) + (oData.Rows(iCont_01).Item("QT_KG_A_FIXAR") / 60)

                        If oData.Rows(iCont_01).Item("QT_KG_A_FIXAR") = 0 Then
                            oRow01.Item("valor3") = NVL(oRow01.Item("valor3"), 0) + oData.Rows(iCont_01).Item("VL_NF_A_FIXAR")
                            oRow01.Item("valor4") = NVL(oRow01.Item("valor4"), 0) + (oData.Rows(iCont_01).Item("VL_NF_A_FIXAR") / VL_Dolar)
                        Else
                            Valorizacao = Math.Round((((VL_Bolsa + oData.Rows(iCont_01).Item("VL_CONTRATO")) * VL_Bolsa) / 1000), 4)
                            oRow01.Item("valor3") = NVL(oRow01.Item("valor3"), 0) + (oData.Rows(iCont_01).Item("QT_KG_A_FIXAR") * Valorizacao)
                            oRow01.Item("valor4") = NVL(oRow01.Item("valor4"), 0) + ((oData.Rows(iCont_01).Item("QT_KG_A_FIXAR") * Valorizacao) / VL_Dolar)
                        End If

                        oRow01.Item("texto1") = "Quantidade Kg"
                        oRow01.Item("texto2") = "Quantidade Sacos"
                        oRow01.Item("texto3") = "Valores R$"
                        oRow01.Item("texto4") = "Valores U$"
                    Case 2
                        oRow01.Item("cdgrupo") = 2
                        oRow01.Item("grupo") = "PAGAMENTOS FUTUROS / CTRs EM ABERTO"
                        oRow01.Item("cdsubgrupo") = 2
                        oRow01.Item("subgrupo") = "Contratos com Dif. de Bolsa fixado e Cacau recebido"
                        If oData.Rows(iCont_01).Item("CD_TIPO_CONTRATO_PAF") = 3 And (oData.Rows(iCont_01).Item("QT_A_NEGOCIAR") <> 0 Or oData.Rows(iCont_01).Item("VL_PAG_AB") <> 0 Or oData.Rows(iCont_01).Item("QT_KG_A_FIXAR") <> 0) Then
                            oRow01.Item("valor3") = NVL(oRow01.Item("valor3"), 0) + ((oData.Rows(iCont_01).Item("QT_KG_FIXO") * ((VL_Bolsa + oData.Rows(iCont_01).Item("VL_CONTRATO")) * VL_Dolar / 1000))) - oData.Rows(iCont_01).Item("VL_PAG_AB_JUROS")
                            oRow01.Item("valor4") = NVL(oRow01.Item("valor4"), 0) + ((((oData.Rows(iCont_01).Item("QT_KG_FIXO") * ((VL_Bolsa + oData.Rows(iCont_01).Item("VL_CONTRATO")) * VL_Dolar / 1000))) - oData.Rows(iCont_01).Item("VL_PAG_AB_JUROS")) / VL_Dolar)
                        End If
                        oRow01.Item("texto1") = "Quantidade Kg"
                        oRow01.Item("texto2") = "Quantidade Sacos"
                        oRow01.Item("texto3") = "Valores R$"
                        oRow01.Item("texto4") = "Valores U$"
                    Case 3
                        oRow01.Item("cdgrupo") = 2
                        oRow01.Item("grupo") = "PAGAMENTOS FUTUROS / CTRs EM ABERTO"
                        oRow01.Item("cdsubgrupo") = 1
                        oRow01.Item("subgrupo") = "Contrato Preço Fixo e Cacau recebido"
                        If (oData.Rows(iCont_01).Item("QT_KGS") - _
                                oData.Rows(iCont_01).Item("QT_CANCELADO") - _
                                oData.Rows(iCont_01).Item("QT_KG_FIXO")) = 0 Then
                            oRow01.Item("valor3") = NVL(oRow01.Item("valor3"), 0) + oData.Rows(iCont_01).Item("VL_QT_A_FIXAR") - oData.Rows(iCont_01).Item("VL_PAG_AB_JUROS")
                            oRow01.Item("valor4") = NVL(oRow01.Item("valor4"), 0) + ((oData.Rows(iCont_01).Item("VL_QT_A_FIXAR") - oData.Rows(iCont_01).Item("VL_PAG_AB_JUROS")) / VL_Dolar)
                        End If
                        oRow01.Item("texto1") = "Quantidade Kg"
                        oRow01.Item("texto2") = "Quantidade Sacos"
                        oRow01.Item("texto3") = "Valores R$"
                        oRow01.Item("texto4") = "Valores U$"
                End Select

                If bAdicionarRow Then oData_Master.Rows.Add(oRow01)

                If oData.Rows(iCont_01).Item("CD_TIPO") = 2 Or oData.Rows(iCont_01).Item("CD_TIPO") = 3 Then
                    bAdicionarRow = False

                    If oRow02 Is Nothing Then
                        oRow02 = oData_Master.NewRow
                        bAdicionarRow = True
                    End If

                    oRow02.Item("cd_filial") = oData.Rows(iCont_01).Item("CD_FILIAL")
                    oRow02.Item("no_filial") = oData.Rows(iCont_01).Item("NO_FILIAL")

                    Select Case oData.Rows(iCont_01).Item("CD_TIPO")
                        Case 2
                            oRow02.Item("cdgrupo") = 2
                            oRow02.Item("grupo") = "PAGAMENTOS FUTUROS / CTRs EM ABERTO"
                            oRow02.Item("cdsubgrupo") = 4
                            oRow02.Item("subgrupo") = "Contratos com Dif. de Bolsa fixado e Cacau receber"
                            If oData.Rows(iCont_01).Item("CD_TIPO_CONTRATO_PAF") = 3 And (oData.Rows(iCont_01).Item("QT_A_NEGOCIAR") <> 0 Or oData.Rows(iCont_01).Item("VL_PAG_AB") <> 0 Or oData.Rows(iCont_01).Item("QT_KG_A_FIXAR") <> 0) Then
                                oRow02.Item("valor1") = NVL(oRow02.Item("valor1"), 0) + (oData.Rows(iCont_01).Item("QT_A_NEGOCIAR") - oData.Rows(iCont_01).Item("qt_kg_a_fixar"))
                                oRow02.Item("valor2") = NVL(oRow02.Item("valor2"), 0) + ((oData.Rows(iCont_01).Item("QT_A_NEGOCIAR") - oData.Rows(iCont_01).Item("qt_kg_a_fixar")) / 60)
                                oRow02.Item("valor3") = NVL(oRow02.Item("valor3"), 0) + ((oData.Rows(iCont_01).Item("QT_A_NEGOCIAR") - oData.Rows(iCont_01).Item("qt_kg_a_fixar")) * (((VL_Bolsa + oData.Rows(iCont_01).Item("VL_CONTRATO")) * VL_Dolar) / 1000)) - oData.Rows(iCont_01).Item("VL_PAG_AB_JUROS")
                                oRow02.Item("valor4") = NVL(oRow02.Item("valor4"), 0) + ((((oData.Rows(iCont_01).Item("QT_A_NEGOCIAR") - oData.Rows(iCont_01).Item("qt_kg_a_fixar")) * ((VL_Bolsa + oData.Rows(iCont_01).Item("VL_CONTRATO")) / 1000)))) - (oData.Rows(iCont_01).Item("VL_PAG_AB_JUROS") / VL_Dolar)
                            End If

                            oRow02.Item("texto1") = "Kgs Receber"
                            oRow01.Item("texto2") = "Quantidade Sacos"
                            oRow02.Item("texto3") = "Valores R$"
                            oRow02.Item("texto4") = "Valores U$"
                        Case 3
                            oRow02.Item("cdgrupo") = 2
                            oRow02.Item("grupo") = "PAGAMENTOS FUTUROS / CTRs EM ABERTO"
                            oRow02.Item("cdsubgrupo") = 3
                            oRow02.Item("subgrupo") = "Contrato Preço Fixo e Cacau receber"

                            If (oData.Rows(iCont_01).Item("QT_KGS") - _
                                oData.Rows(iCont_01).Item("QT_CANCELADO") - _
                                oData.Rows(iCont_01).Item("QT_KG_FIXO")) <> 0 Then
                                oRow02.Item("valor1") = NVL(oRow02.Item("valor1"), 0) + (oData.Rows(iCont_01).Item("QT_KGS") - _
                                                                                         oData.Rows(iCont_01).Item("QT_CANCELADO") - _
                                                                                         oData.Rows(iCont_01).Item("QT_KG_FIXO"))
                                oRow02.Item("valor2") = NVL(oRow02.Item("valor2"), 0) + ((oData.Rows(iCont_01).Item("QT_KGS") - _
                                                                                          oData.Rows(iCont_01).Item("QT_CANCELADO") - _
                                                                                          oData.Rows(iCont_01).Item("QT_KG_FIXO")) / 60)
                                oRow02.Item("valor3") = NVL(oRow02.Item("valor3"), 0) + (((oData.Rows(iCont_01).Item("QT_KGS") - oData.Rows(iCont_01).Item("QT_CANCELADO")) * ((oData.Rows(iCont_01).Item("VL_CONTRATO") / 15))) - oData.Rows(iCont_01).Item("VL_PAG_AB_JUROS"))
                                oRow02.Item("valor4") = NVL(oRow02.Item("valor4"), 0) + (((((oData.Rows(iCont_01).Item("QT_KGS") - oData.Rows(iCont_01).Item("QT_CANCELADO")) * ((oData.Rows(iCont_01).Item("VL_CONTRATO") / 15))) - oData.Rows(iCont_01).Item("VL_PAG_AB_JUROS"))) / VL_Dolar)
                            End If

                            oRow02.Item("texto1") = "Kgs Receber"
                            oRow01.Item("texto2") = "Quantidade Sacos"
                            oRow02.Item("texto3") = "Valores R$"
                            oRow02.Item("texto4") = "Valores U$"
                    End Select

                    If bAdicionarRow Then oData_Master.Rows.Add(oRow02)
                End If
            End If
        Next

        If bSintetico Then
            For iCont_01 = 0 To oData_Master.Rows.Count - 1
                oData_Master.Rows(iCont_01).Item("cd_filial") = 1
                oData_Master.Rows(iCont_01).Item("no_filial") = "TODAS"
            Next
        End If

        'Montar o filtro
        If Trim(ListagemFilial) <> "" Then
            SqlText = "SELECT NO_FILIAL FROM SOF.FILIAL WHERE CD_FILIAL IN (" & ListagemFilial & ")"
            Str_Adicionar(sFiltro, "Filiais: " & DBQuery_ValorUnico_Lista(SqlText) & vbCrLf, " - ")
        End If

        Str_Adicionar(sFiltro, "Período: " & DataInicial & " a " & DataFinal, " - ")
        Str_Adicionar(sFiltro, "Valor de Bolsa: " & VL_Bolsa, " - ")
        Str_Adicionar(sFiltro, "Taxa de Dolar: " & VL_Dolar, " - ")
        Str_Adicionar(sFiltro, "Valor de Arroba: " & VL_ValorArroba, " - ")

        oRelatorio.Load(Application.StartupPath & "\RPT_Fluxo_Caixa.rpt")
        oRelatorio.SetDataSource(oData_Master)

        oRelatorio.SetParameterValue("Filtro", Trim(sFiltro))
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        oRelatorio.SetParameterValue("DT_PERIODO_INI", DataInicial)
        oRelatorio.SetParameterValue("DT_PERIODO_FIM", DataFinal)

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_SaldoFornecedor(ByVal DataBase As String, _
                                                   ByVal TaxaDolar As Double, _
                                                   ByVal Bolsa As Double, _
                                                   ByVal ValorDif As Double) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As New DataTable
        Dim oDataAux As DataTable
        Dim oDataAux2 As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""
        Dim VlMin As Double
        Dim iCont As Integer
        Dim iCont2 As Integer
        Dim oRow As DataRow

        SqlText = "SELECT P.VL_MINIMO_NF_COMPLEMENTAR FROM SOF.PARAMETRO P"
        VlMin = DBQuery_ValorUnico(SqlText, 0)

        With oData.Columns
            .Add("CD_FILIAL").DataType = System.Type.GetType("System.Int32")
            .Add("NO_FILIAL").DataType = System.Type.GetType("System.String")
            .Add("VL_CACAU_ORDEM").DataType = System.Type.GetType("System.Double")
            .Add("VL_PRECO_MEDIO").DataType = System.Type.GetType("System.Double")
            .Add("VL_INSS").DataType = System.Type.GetType("System.Double")
            .Add("VL_ADTO_ICMS").DataType = System.Type.GetType("System.Double")
            .Add("VL_ADTO_CTR_PAF").DataType = System.Type.GetType("System.Double")
            .Add("VL_CONF_DIVIDA").DataType = System.Type.GetType("System.Double")
            .Add("VL_CACAU_ORDEM_US").DataType = System.Type.GetType("System.Double")
            .Add("VL_PRECO_MEDIO_US").DataType = System.Type.GetType("System.Double")
            .Add("VL_INSS_US").DataType = System.Type.GetType("System.Double")
            .Add("VL_ADTO_ICMS_US").DataType = System.Type.GetType("System.Double")
            .Add("VL_ADTO_CTR_PAF_US").DataType = System.Type.GetType("System.Double")
            .Add("VL_CONF_DIVIDA_US").DataType = System.Type.GetType("System.Double")
            .Add("VL_TAXA_US").DataType = System.Type.GetType("System.Double")
            .Add("DT_BASE").DataType = System.Type.GetType("System.String")
            .Add("QT_KGS").DataType = System.Type.GetType("System.Double")
            .Add("VL_TOTAL").DataType = System.Type.GetType("System.Double")
            .Add("VL_ADENDO").DataType = System.Type.GetType("System.Double")
            .Add("VL_ICMS").DataType = System.Type.GetType("System.Double")
            .Add("VL_ADENDO_ICMS").DataType = System.Type.GetType("System.Double")
            .Add("VL_PAG_FIXO").DataType = System.Type.GetType("System.Double")
            .Add("QT_KG_FIXO").DataType = System.Type.GetType("System.Double")
            .Add("ic_taxa_dolar_variavel").DataType = System.Type.GetType("System.String")
            .Add("vl_dolar_atual").DataType = System.Type.GetType("System.Double")
            .Add("ic_bolsa_operacao").DataType = System.Type.GetType("System.String")
            .Add("vl_bolsa_fechado").DataType = System.Type.GetType("System.Double")
            .Add("vl_negociacao").DataType = System.Type.GetType("System.Double")
            .Add("vl_nf_fixo").DataType = System.Type.GetType("System.Double")
            .Add("vl_nf_inss_fixo").DataType = System.Type.GetType("System.Double")
            .Add("VL_CONF_DIVIDA_JUROS").DataType = System.Type.GetType("System.Double")
            .Add("VL_CONF_DIVIDA_JUROS_US").DataType = System.Type.GetType("System.Double")
            .Add("VL_ADTO_NEG").DataType = System.Type.GetType("System.Double")
            .Add("VL_ADTO_NEG_US").DataType = System.Type.GetType("System.Double")
            .Add("VL_REV_CACAU_ORDEM").DataType = System.Type.GetType("System.Double")
            .Add("VL_REV_CACAU_ORDEM_US").DataType = System.Type.GetType("System.Double")
            .Add("VL_DIF_BOLSA_FIX").DataType = System.Type.GetType("System.Double")
            .Add("VL_DIF_BOLSA_FIX_US").DataType = System.Type.GetType("System.Double")
            .Add("VL_PROV_NF_COMPL").DataType = System.Type.GetType("System.Double")
            .Add("VL_PROV_NF_COMPL_US").DataType = System.Type.GetType("System.Double")
            .Add("VL_REV_DIF_BOLSA").DataType = System.Type.GetType("System.Double")
            .Add("VL_REV_DIF_BOLSA_US").DataType = System.Type.GetType("System.Double")
        End With

        'confissao de divida
        SqlText = "SELECT   fil.cd_filial, fil.no_filial, "
        SqlText = SqlText & "         0 VL_CACAU_ORDEM, 0 VL_PRECO_MEDIO, 0 VL_INSS, 0 VL_ADTO_ICMS, 0 VL_ADTO_CTR_PAF, SUM (cd.vl_original - NVL(vl_parcela_pag,0)) VL_CONF_DIVIDA, "
        SqlText = SqlText & "         0 VL_CACAU_ORDEM_US,0 VL_PRECO_MEDIO_US,0 VL_INSS_US, 0 VL_ADTO_ICMS_US, 0 VL_ADTO_CTR_PAF_US, round(SUM (cd.vl_original - NVL(vl_parcela_pag,0))/" & TaxaDolar & ", 4) VL_CONF_DIVIDA_US, "
        SqlText = SqlText & "         " & TaxaDolar & " VL_TAXA_US, " & QuotedStr(DataBase) & " DT_BASE, "
        SqlText = SqlText & "         0 QT_KGS, 0 VL_TOTAL, 0 VL_ADENDO, "
        SqlText = SqlText & "         0 VL_ICMS,0 VL_ADENDO_ICMS,0 VL_PAG_FIXO,0 QT_KG_FIXO, "
        SqlText = SqlText & "         'N' ic_taxa_dolar_variavel,0 vl_dolar_atual,'+' ic_bolsa_operacao, "
        SqlText = SqlText & "         0 vl_bolsa_fechado,0 vl_negociacao,0 vl_nf_fixo,0 vl_nf_inss_fixo, "
        SqlText = SqlText & "         (round(SUM (DECODE (CD.IC_COBRA_JUROS, "
        SqlText = SqlText & "                                   'S', nvl(vp.vl_parcela_abe, cd.vl_original) "
        SqlText = SqlText & "                                    * (  1 "
        SqlText = SqlText & "                                       + (  (SYSDATE - CD.DT_COBRA_JUROS) "
        SqlText = SqlText & "                                          * (CD.PC_JUROS_AO_MES / 30) "
        SqlText = SqlText & "                                          / 100 ) ), "
        SqlText = SqlText & "                                  nvl(vp.vl_parcela_abe, cd.vl_original) "
        SqlText = SqlText & "                                  )"
        SqlText = SqlText & "             ),2)) -SUM (cd.vl_original - NVL(vl_parcela_pag,0)) VL_CONF_DIVIDA_JUROS,"
        SqlText = SqlText & "         round(((round(SUM (DECODE (CD.IC_COBRA_JUROS, "
        SqlText = SqlText & "                                   'S', nvl(vp.vl_parcela_abe, cd.vl_original) "
        SqlText = SqlText & "                                    * (  1 "
        SqlText = SqlText & "                                       + (  (SYSDATE - CD.DT_COBRA_JUROS) "
        SqlText = SqlText & "                                          * (CD.PC_JUROS_AO_MES / 30) "
        SqlText = SqlText & "                                          / 100 ) ), "
        SqlText = SqlText & "                                   nvl(vp.vl_parcela_abe, cd.vl_original) "
        SqlText = SqlText & "                                  )"
        SqlText = SqlText & "             ),2)) -SUM (cd.vl_original - NVL(vl_parcela_pag,0)))/" & TaxaDolar & ",2) VL_CONF_DIVIDA_JUROS_US, "

        SqlText = SqlText & " 0 VL_ADTO_NEG, 0 VL_ADTO_NEG_US, 0 VL_REV_CACAU_ORDEM, "
        SqlText = SqlText & " 0 VL_REV_CACAU_ORDEM_US,  0 VL_DIF_BOLSA_FIX,  0 VL_DIF_BOLSA_FIX_US, "
        SqlText = SqlText & " 0 VL_PROV_NF_COMPL, 0 VL_PROV_NF_COMPL_US, 0 VL_REV_DIF_BOLSA, 0 VL_REV_DIF_BOLSA_US"

        SqlText = SqlText & "    FROM sof.confissao_divida cd, "
        SqlText = SqlText & "         sof.filial fil, "
        SqlText = SqlText & "         (SELECT   cdp.sq_confissao_divida, "
        SqlText = SqlText & "                   SUM (NVL (cda.vl_ativo, 0)) AS vl_parcela_pag, "
        SqlText = SqlText & "                   SUM (DECODE (CDP.IC_SITUACAO,'A', CDP.VL_PARCELA,0)) vl_parcela_abe"
        SqlText = SqlText & "              FROM sof.confissao_divida_parcela cdp, "
        SqlText = SqlText & "                   sof.confissao_divida_ativo cda "
        SqlText = SqlText & "             WHERE cdp.sq_confissao_divida = cda.sq_confissao_divida(+) "
        SqlText = SqlText & "                   AND cdp.nu_parcela = cda.nu_parcela(+) "
        SqlText = SqlText & "          GROUP BY cdp.sq_confissao_divida) vp "
        SqlText = SqlText & "   WHERE fil.cd_filial = cd.cd_filial_origem "
        SqlText = SqlText & "     AND cd.sq_confissao_divida = vp.sq_confissao_divida(+) "
        SqlText = SqlText & "     AND cd.ic_status = 'A' "
        SqlText = SqlText & "GROUP BY fil.cd_filial, fil.no_filial "

        oData = DBQuery(SqlText)

        ' oData.PrimaryKey = New DataColumn() {oData.Columns("CD_FILIAL")}

        'ICMS
        SqlText = "SELECT   fil.cd_filial, fil.no_filial,nvl(round(((nvl(ms.VL_A_FIXAR,0) + nvl(mns.VL_A_FIXAR,0)) *SUM (nvl(pa.vl_aplicacao,0))) /m.vl_nf,2) ,0) as valor "
        SqlText = SqlText & "  FROM sof.pagamentos p, "
        SqlText = SqlText & "       sof.movimentacao m, "
        SqlText = SqlText & "       sof.filial fil, sof.fornecedor f, "
        SqlText = SqlText & "       sof.conciliacao c, "
        SqlText = SqlText & "       sof.pag_amarracao_icms pa, "
        SqlText = SqlText & "        (SELECT   cm.sq_movimentacao, SUM (cm.vl_a_fixar) AS vl_a_fixar"
        SqlText = SqlText & "            FROM sof.ctr_paf_movimentacao cm"
        SqlText = SqlText & "           Where cm.vl_a_fixar <> 0"
        SqlText = SqlText & "        GROUP BY cm.sq_movimentacao) ms,"
        SqlText = SqlText & "        (SELECT   cm.sq_movimentacao, SUM (cm.vl_a_fixar) AS vl_a_fixar"
        SqlText = SqlText & "            FROM sof.ctr_paf_neg_movimentacao cm"
        SqlText = SqlText & "           Where cm.vl_a_fixar <> 0"
        SqlText = SqlText & "        GROUP BY cm.sq_movimentacao) mns,"
        SqlText = SqlText & "       (SELECT   p.sq_movimentacao, max(cm.vl_aplicacao) AS vl_conciliado"
        SqlText = SqlText & "         FROM (SELECT   sq_movimentacao, SUM (vl_aplicacao)"
        SqlText = SqlText & "                                                            AS vl_aplicacao"
        SqlText = SqlText & "                   FROM sof.conciliacao_movimentacao"
        SqlText = SqlText & "                GROUP BY sq_movimentacao) cm,"
        SqlText = SqlText & "         sof.pag_amarracao_icms p"
        SqlText = SqlText & "   WHERE  cm.sq_movimentacao = p.sq_movimentacao "
        SqlText = SqlText & " GROUP BY p.sq_movimentacao) mcs"
        SqlText = SqlText & " Where pa.Sq_Movimentacao = m.Sq_Movimentacao "
        SqlText = SqlText & "   and pa.sq_pagamento =p.sq_pagamento "
        SqlText = SqlText & "   and f.cd_filial_origem =fil.cd_filial "
        SqlText = SqlText & "   AND p.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "   AND pa.sq_conciliacao  = c.sq_conciliacao "
        SqlText = SqlText & "   and m.SQ_MOVIMENTACAO =ms.SQ_MOVIMENTACAO (+) "
        SqlText = SqlText & "   and m.SQ_MOVIMENTACAO =mns.SQ_MOVIMENTACAO (+) "
        SqlText = SqlText & "   and m.SQ_MOVIMENTACAO =mcs.SQ_MOVIMENTACAO (+) "
        SqlText = SqlText & " group by fil.cd_filial, fil.no_filial, m.vl_nf," & _
                           "ms.VL_A_FIXAR,mns.vl_a_fixar , mcs.vl_conciliado "
        oDataAux = DBQuery(SqlText)

        For iCont = 0 To oDataAux.Rows.Count - 1
            'oRow = oData.Rows.Find(New Object() {oDataAux.Rows(iCont).Item("CD_FILIAL")})
            oRow = oData.NewRow

            oRow.Item("CD_FILIAL") = oDataAux.Rows(iCont).Item("CD_FILIAL")
            oRow.Item("NO_FILIAL") = oDataAux.Rows(iCont).Item("NO_FILIAL")

            oRow.Item("VL_CACAU_ORDEM") = NVL(oRow.Item("VL_CACAU_ORDEM"), 0)
            oRow.Item("VL_PRECO_MEDIO") = NVL(oRow.Item("VL_PRECO_MEDIO"), 0)
            oRow.Item("VL_INSS") = NVL(oRow.Item("VL_INSS"), 0)
            oRow.Item("VL_ADTO_ICMS") = NVL(oRow.Item("VL_ADTO_ICMS"), 0) + oDataAux.Rows(iCont).Item("VALOR")
            oRow.Item("VL_ADTO_CTR_PAF") = NVL(oRow.Item("VL_ADTO_CTR_PAF"), 0)
            oRow.Item("VL_CONF_DIVIDA") = NVL(oRow.Item("VL_CONF_DIVIDA"), 0)
            oRow.Item("VL_CONF_DIVIDA_JUROS") = NVL(oRow.Item("VL_CONF_DIVIDA_JUROS"), 0)
            oRow.Item("VL_CACAU_ORDEM_US") = NVL(oRow.Item("VL_CACAU_ORDEM_US"), 0)
            oRow.Item("VL_PRECO_MEDIO_US") = NVL(oRow.Item("VL_PRECO_MEDIO_US"), 0)
            oRow.Item("VL_INSS_US") = NVL(oRow.Item("VL_INSS_US"), 0)
            oRow.Item("VL_ADTO_ICMS_US") = NVL(oRow.Item("VL_ADTO_ICMS_US"), 0) + (oDataAux.Rows(iCont).Item("valor") / TaxaDolar)
            oRow.Item("VL_ADTO_CTR_PAF_US") = NVL(oRow.Item("VL_ADTO_CTR_PAF_US"), 0)
            oRow.Item("VL_CONF_DIVIDA_US") = NVL(oRow.Item("VL_CONF_DIVIDA_US"), 0)
            oRow.Item("VL_CONF_DIVIDA_JUROS_US") = NVL(oRow.Item("VL_CONF_DIVIDA_JUROS_US"), 0)
            oRow.Item("VL_TAXA_US") = TaxaDolar

            oRow.Item("QT_KGS") = 0
            oRow.Item("VL_TOTAL") = 0
            oRow.Item("VL_ADENDO") = 0
            oRow.Item("VL_ICMS") = 0
            oRow.Item("VL_ADENDO_ICMS") = 0
            oRow.Item("VL_PAG_FIXO") = 0
            oRow.Item("QT_KG_FIXO") = 0
            oRow.Item("ic_taxa_dolar_variavel") = "N"
            oRow.Item("vl_dolar_atual") = 0
            oRow.Item("ic_bolsa_operacao") = "+"
            oRow.Item("vl_bolsa_fechado") = 0
            oRow.Item("vl_negociacao") = 0
            oRow.Item("vl_nf_fixo") = 0
            oRow.Item("vl_nf_inss_fixo") = 0
            oRow.Item("VL_ADTO_NEG") = 0
            oRow.Item("VL_ADTO_NEG_US") = 0
            oRow.Item("VL_REV_CACAU_ORDEM") = 0
            oRow.Item("VL_REV_CACAU_ORDEM_US") = 0
            oRow.Item("VL_DIF_BOLSA_FIX") = 0
            oRow.Item("VL_DIF_BOLSA_FIX_US") = 0
            oRow.Item("VL_PROV_NF_COMPL") = 0
            oRow.Item("VL_PROV_NF_COMPL_US") = 0
            oRow.Item("VL_REV_DIF_BOLSA") = 0
            oRow.Item("VL_REV_DIF_BOLSA_US") = 0

            oData.Rows.Add(oRow)
        Next


        'cacau a ordem
        Dim Cdfilial As String = ""
        Dim Vencido As Boolean
        Dim IcVlAberto As Boolean
        Dim AVencer As Boolean
        Dim SemPrazo As Boolean
        Dim SemMov As Boolean
        Dim Aux As Double
        Dim ValorAtual As Double
        Dim Vl_Liq_Atualizado As Double

        Vencido = False
        AVencer = False
        SemPrazo = False
        IcVlAberto = False
        SemMov = False
        Cdfilial = ListarIDFiliaisLiberadaUsuario()
        ValorAtual = Math.Round((((Bolsa + ValorDif) * TaxaDolar) / 1000), 4)

        'Cacau A ordem PAF
        oDataAux = Gera_Rs_Cacau_A_Ordem(Cdfilial, False, Vencido, Now.Date, IcVlAberto, AVencer, SemPrazo, SemMov, , True)


        For iCont = 0 To oDataAux.Rows.Count - 1
            oRow = oData.NewRow

            oRow.Item("CD_FILIAL") = oDataAux.Rows(iCont).Item("CD_FILIAL")
            oRow.Item("NO_FILIAL") = oDataAux.Rows(iCont).Item("NO_FILIAL")
            oRow.Item("VL_CACAU_ORDEM") = NVL(oRow.Item("VL_CACAU_ORDEM"), 0) + (oDataAux.Rows(iCont).Item("VL_A_FIXAR") * -1)
            oRow.Item("VL_PRECO_MEDIO") = NVL(oRow.Item("VL_PRECO_MEDIO"), 0)

            Aux = (oDataAux.Rows(iCont).Item("vl_a_fixar") / IIf(NVL(oDataAux.Rows(iCont).Item("vl_nf"), 0) = 0, 1, oDataAux.Rows(iCont).Item("vl_nf")) * oDataAux.Rows(iCont).Item("VL_NF_FUNRURAL"))
            oRow.Item("VL_INSS") = NVL(oRow.Item("VL_INSS"), 0) + Aux
            oRow.Item("VL_ADTO_ICMS") = NVL(oRow.Item("VL_ADTO_ICMS"), 0)
            oRow.Item("VL_ADTO_CTR_PAF") = NVL(oRow.Item("VL_ADTO_CTR_PAF"), 0)
            oRow.Item("VL_CONF_DIVIDA") = NVL(oRow.Item("VL_CONF_DIVIDA"), 0)
            oRow.Item("VL_CONF_DIVIDA_JUROS") = NVL(oRow.Item("VL_CONF_DIVIDA_JUROS"), 0)

            oRow.Item("VL_CACAU_ORDEM_US") = NVL(oRow.Item("VL_CACAU_ORDEM_US"), 0) + (NVL(oDataAux.Rows(iCont).Item("VL_A_FIXAR"), 0) / NVL(oDataAux.Rows(iCont).Item("VL_TAXA_US"), 1) * -1)
            oRow.Item("VL_PRECO_MEDIO_US") = NVL(oRow.Item("VL_PRECO_MEDIO_US"), 0)
            oRow.Item("VL_INSS_US") = NVL(oRow.Item("VL_INSS_US"), 0) + (Aux / NVL(oDataAux.Rows(iCont).Item("VL_TAXA_US"), 1))
            oRow.Item("VL_ADTO_ICMS_US") = NVL(oRow.Item("VL_ADTO_ICMS_US"), 0)
            oRow.Item("VL_ADTO_CTR_PAF_US") = NVL(oRow.Item("VL_ADTO_CTR_PAF_US"), 0)
            oRow.Item("VL_CONF_DIVIDA_US") = NVL(oRow.Item("VL_CONF_DIVIDA_US"), 0)
            oRow.Item("VL_CONF_DIVIDA_JUROS_US") = NVL(oRow.Item("VL_CONF_DIVIDA_JUROS_US"), 0)

            oRow.Item("VL_TAXA_US") = TaxaDolar
            oRow.Item("DT_BASE") = DataBase

            oRow.Item("QT_KGS") = 0
            oRow.Item("VL_TOTAL") = 0
            oRow.Item("VL_ADENDO") = 0
            oRow.Item("VL_ICMS") = 0
            oRow.Item("VL_ADENDO_ICMS") = 0
            oRow.Item("VL_PAG_FIXO") = 0
            oRow.Item("QT_KG_FIXO") = 0
            oRow.Item("ic_taxa_dolar_variavel") = "N"
            oRow.Item("vl_dolar_atual") = 0
            oRow.Item("ic_bolsa_operacao") = "+"
            oRow.Item("vl_bolsa_fechado") = 0
            oRow.Item("vl_negociacao") = 0
            oRow.Item("vl_nf_fixo") = 0
            oRow.Item("vl_nf_inss_fixo") = 0


            If oDataAux.Rows(iCont).Item("QT_KG_A_FIXAR") <> 0 Then
                If oDataAux.Rows(iCont).Item("QT_KG_A_FIXAR") = 0 Then
                    Vl_Liq_Atualizado = oDataAux.Rows(iCont).Item("VL_A_FIXAR")
                Else
                    Vl_Liq_Atualizado = ValorAtual * oDataAux.Rows(iCont).Item("QT_KG_A_FIXAR")
                End If
                oRow.Item("VL_REV_CACAU_ORDEM") = NVL(oRow.Item("VL_REV_CACAU_ORDEM"), 0) + ((Vl_Liq_Atualizado - oDataAux.Rows(iCont).Item("VL_A_FIXAR")) * -1)
                Vl_Liq_Atualizado = Vl_Liq_Atualizado / TaxaDolar
                oRow.Item("VL_REV_CACAU_ORDEM_US") = NVL(oRow.Item("VL_REV_CACAU_ORDEM_US"), 0) + ((Vl_Liq_Atualizado - (oDataAux.Rows(iCont).Item("VL_A_FIXAR") / NVL(oDataAux.Rows(iCont).Item("VL_TAXA_US"), 1))) * -1)
            Else
                oRow.Item("VL_REV_CACAU_ORDEM") = NVL(oRow.Item("VL_REV_CACAU_ORDEM"), 0)
                oRow.Item("VL_REV_CACAU_ORDEM_US") = NVL(oRow.Item("VL_REV_CACAU_ORDEM_US"), 0)
            End If

            oData.Rows.Add(oRow)
        Next


        'Cacau A ordem Neg
        oDataAux = Gera_RS_Neg_A_Ordem(Cdfilial, True)


        For iCont = 0 To oDataAux.Rows.Count - 1
            oRow = oData.NewRow

            oRow.Item("CD_FILIAL") = oDataAux.Rows(iCont).Item("CD_FILIAL")
            oRow.Item("NO_FILIAL") = oDataAux.Rows(iCont).Item("NO_FILIAL")
            oRow.Item("VL_DIF_BOLSA_FIX") = NVL(oRow.Item("VL_DIF_BOLSA_FIX"), 0) + (oDataAux.Rows(iCont).Item("VL_A_FIXAR") * -1)
            oRow.Item("VL_CACAU_ORDEM") = NVL(oRow.Item("VL_CACAU_ORDEM"), 0)
            oRow.Item("VL_PRECO_MEDIO") = NVL(oRow.Item("VL_PRECO_MEDIO"), 0)

            Aux = (oDataAux.Rows(iCont).Item("vl_a_fixar") / IIf(NVL(oDataAux.Rows(iCont).Item("vl_nf"), 0) = 0, 1, oDataAux.Rows(iCont).Item("vl_nf")) * oDataAux.Rows(iCont).Item("VL_NF_FUNRURAL"))
            oRow.Item("VL_INSS") = NVL(oRow.Item("VL_INSS"), 0) + Aux
            oRow.Item("VL_ADTO_ICMS") = NVL(oRow.Item("VL_ADTO_ICMS"), 0)
            oRow.Item("VL_ADTO_CTR_PAF") = NVL(oRow.Item("VL_ADTO_CTR_PAF"), 0)
            oRow.Item("VL_CONF_DIVIDA") = NVL(oRow.Item("VL_CONF_DIVIDA"), 0)
            oRow.Item("VL_CONF_DIVIDA_JUROS") = NVL(oRow.Item("VL_CONF_DIVIDA_JUROS"), 0)

            oRow.Item("VL_DIF_BOLSA_FIX_US") = NVL(oRow.Item("VL_DIF_BOLSA_FIX_US"), 0) + (NVL(oDataAux.Rows(iCont).Item("VL_A_FIXAR"), 0) / NVL(oDataAux.Rows(iCont).Item("VL_TAXA_US"), 1) * -1)
            oRow.Item("VL_CACAU_ORDEM_US") = NVL(oRow.Item("VL_CACAU_ORDEM_US"), 0)
            oRow.Item("VL_PRECO_MEDIO_US") = NVL(oRow.Item("VL_PRECO_MEDIO_US"), 0)
            oRow.Item("VL_INSS_US") = NVL(oRow.Item("VL_INSS_US"), 0) + (Aux / NVL(oDataAux.Rows(iCont).Item("VL_TAXA_US"), 1))
            oRow.Item("VL_ADTO_ICMS_US") = NVL(oRow.Item("VL_ADTO_ICMS_US"), 0)
            oRow.Item("VL_ADTO_CTR_PAF_US") = NVL(oRow.Item("VL_ADTO_CTR_PAF_US"), 0)
            oRow.Item("VL_CONF_DIVIDA_US") = NVL(oRow.Item("VL_CONF_DIVIDA_US"), 0)
            oRow.Item("VL_CONF_DIVIDA_JUROS_US") = NVL(oRow.Item("VL_CONF_DIVIDA_JUROS_US"), 0)

            oRow.Item("VL_TAXA_US") = TaxaDolar
            oRow.Item("DT_BASE") = DataBase

            oRow.Item("QT_KGS") = 0
            oRow.Item("VL_TOTAL") = 0
            oRow.Item("VL_ADENDO") = 0
            oRow.Item("VL_ICMS") = 0
            oRow.Item("VL_ADENDO_ICMS") = 0
            oRow.Item("VL_PAG_FIXO") = 0
            oRow.Item("QT_KG_FIXO") = 0
            oRow.Item("ic_taxa_dolar_variavel") = "N"
            oRow.Item("vl_dolar_atual") = 0
            oRow.Item("ic_bolsa_operacao") = "+"
            oRow.Item("vl_bolsa_fechado") = 0
            oRow.Item("vl_negociacao") = 0
            oRow.Item("vl_nf_fixo") = 0
            oRow.Item("vl_nf_inss_fixo") = 0

            If oDataAux.Rows(iCont).Item("QT_KG_A_FIXAR") <> 0 Then
                If oDataAux.Rows(iCont).Item("QT_KG_A_FIXAR") = 0 Then
                    Vl_Liq_Atualizado = oDataAux.Rows(iCont).Item("VL_A_FIXAR")
                Else
                    Vl_Liq_Atualizado = (Math.Round((((Bolsa + oDataAux.Rows(iCont).Item("VL_DIFERENCIAL")) * TaxaDolar) / 1000), 4)) * oDataAux.Rows(iCont).Item("QT_KG_A_FIXAR")
                End If
                oRow.Item("VL_REV_DIF_BOLSA") = NVL(oRow.Item("VL_REV_DIF_BOLSA"), 0) + ((Vl_Liq_Atualizado - oDataAux.Rows(iCont).Item("VL_A_FIXAR")) * -1)
                Vl_Liq_Atualizado = Vl_Liq_Atualizado / TaxaDolar
                oRow.Item("VL_REV_DIF_BOLSA_US") = NVL(oRow.Item("VL_REV_DIF_BOLSA_US"), 0) + ((Vl_Liq_Atualizado - (oDataAux.Rows(iCont).Item("VL_A_FIXAR") / NVL(oDataAux.Rows(iCont).Item("VL_TAXA_US"), 1))) * -1)
            Else
                oRow.Item("VL_REV_DIF_BOLSA") = NVL(oRow.Item("VL_REV_DIF_BOLSA"), 0)
                oRow.Item("VL_REV_DIF_BOLSA_US") = NVL(oRow.Item("VL_REV_DIF_BOLSA_US"), 0)
            End If

            oData.Rows.Add(oRow)
        Next

        '==NOVO
        SqlText = "SELECT  cf.cd_contrato_paf, cf.qt_kgs, cf.vl_total, cf.vl_icms, cf.qt_kg_fixo, ROUND (cf.vl_pag_fixo + NVL (ama.vl_aplicado, 0),2) AS vl_pag_fixo, "
        SqlText = SqlText & "       cf.vl_nf_inss_fixo, cf.vl_nf_fixo, cf.vl_adendo, cf.vl_unitario, "
        SqlText = SqlText & "       cf.vl_adendo_icms, "
        SqlText = SqlText & "nvl(DECODE (CF.vl_pag_fixo ,0, decode(DMM.VL_TAXA_DOLAR_MEDIO,0," & TaxaDolar & ",DMM.VL_TAXA_DOLAR_MEDIO) , DMP.VL_TAXA_MEDIA),(" & TaxaDolar & ")) vl_dolar_atual, "

        SqlText = SqlText & "       cf.qt_cancelado, cf.ic_status, cf.vl_inss, cf.ic_taxa_dolar_variavel, "
        SqlText = SqlText & "       cf.vl_bolsa_fechado, n.vl_negociacao, tn.ic_bolsa_operacao, "
        SqlText = SqlText & "       fil.cd_filial, fil.no_filial, cf.ic_inclui_icms_pag "
        SqlText = SqlText & "            FROM sof.contrato_fixo cf,"
        SqlText = SqlText & "                 sof.negociacao n,"
        SqlText = SqlText & "                 sof.contrato_paf cp,"
        SqlText = SqlText & "                 sof.fornecedor f,"
        SqlText = SqlText & "                 sof.municipio munic,"
        SqlText = SqlText & "                 sof.filial fil,"
        SqlText = SqlText & "                 sof.tipo_negociacao tn,"
        SqlText = SqlText & "                 sof.tipo_unidade tu,"
        SqlText = SqlText & "                 sof.safra s,"
        SqlText = SqlText & "                 (SELECT   ROUND (  SUM (  pncf.vl_fixo"
        SqlText = SqlText & "                                         * NVL (p.vl_taxa_dolar, (2))"
        SqlText = SqlText & "                                        )"
        SqlText = SqlText & "                                  / DECODE (SUM (pncf.vl_fixo),"
        SqlText = SqlText & "                                            0, 1,"
        SqlText = SqlText & "                                            SUM (pncf.vl_fixo)"
        SqlText = SqlText & "                                           ),"
        SqlText = SqlText & "                                  4"
        SqlText = SqlText & "                                 ) vl_taxa_media,"
        SqlText = SqlText & "                           pncf.cd_contrato_paf, pncf.sq_negociacao,"
        SqlText = SqlText & "                           pncf.sq_contrato_fixo"
        SqlText = SqlText & "                      FROM sof.pag_neg_ctr_fix pncf,"
        SqlText = SqlText & "                           sof.pagamentos p,"
        SqlText = SqlText & "                           sof.contrato_fixo cf,"
        SqlText = SqlText & "                           sof.contrato_paf cp,"
        SqlText = SqlText & "                           sof.fornecedor f"
        SqlText = SqlText & "                     WHERE pncf.sq_pagamento = p.sq_pagamento"
        SqlText = SqlText & "                       AND pncf.cd_contrato_paf = cf.cd_contrato_paf"
        SqlText = SqlText & "                       AND pncf.sq_negociacao = cf.sq_negociacao"
        SqlText = SqlText & "                       AND pncf.sq_contrato_fixo = cf.sq_contrato_fixo"
        SqlText = SqlText & "                       AND cp.cd_contrato_paf = cf.cd_contrato_paf"
        SqlText = SqlText & "                       AND cp.cd_fornecedor = f.cd_fornecedor"
        SqlText = SqlText & "                       AND (   (    cf.vl_pag_fixo <>"
        SqlText = SqlText & "                                         (cf.vl_nf_fixo - cf.vl_nf_inss_fixo"
        SqlText = SqlText & "                                         )"
        SqlText = SqlText & "                                AND (  cf.vl_pag_fixo"
        SqlText = SqlText & "                                     - (cf.vl_nf_fixo - cf.vl_nf_inss_fixo)"
        SqlText = SqlText & "                                    ) <> 0"
        SqlText = SqlText & "                                AND (   (  cf.vl_pag_fixo"
        SqlText = SqlText & "                                         - (cf.vl_nf_fixo - cf.vl_nf_inss_fixo"
        SqlText = SqlText & "                                           )"
        SqlText = SqlText & "                                        ) > 0.03"
        SqlText = SqlText & "                                     OR (  cf.vl_pag_fixo"
        SqlText = SqlText & "                                         - (cf.vl_nf_fixo - cf.vl_nf_inss_fixo"
        SqlText = SqlText & "                                           )"
        SqlText = SqlText & "                                        ) < -0.03"
        SqlText = SqlText & "                                    )"
        SqlText = SqlText & "                               )"
        SqlText = SqlText & "                            OR (cf.qt_kgs - cf.qt_cancelado) <> cf.qt_kg_fixo"
        SqlText = SqlText & "                           )"
        SqlText = SqlText & "                       AND cf.ic_status <> 'E'"
        SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ") "
        SqlText = SqlText & "                  GROUP BY pncf.cd_contrato_paf,"
        SqlText = SqlText & "                           pncf.sq_negociacao,"
        SqlText = SqlText & "                           pncf.sq_contrato_fixo) dmp,"
        SqlText = SqlText & "                 (SELECT   ROUND(DECODE(NVL(SUM(CPNCFM.VL_FIXO), 0), 0, 0, SUM(CPNCFM.VL_FIXO * NVL (TD.VL_TAXA, (2))) / DECODE(SUM(CPNCFM.VL_FIXO), 0, 1, SUM (CPNCFM.VL_FIXO))), 4) VL_TAXA_DOLAR_MEDIO,"
        SqlText = SqlText & "                           cpncfm.cd_contrato_paf, cpncfm.sq_negociacao,"
        SqlText = SqlText & "                           cpncfm.sq_contrato_fixo"
        SqlText = SqlText & "                      FROM sof.ctr_paf_neg_ctr_fix_mov cpncfm,"
        SqlText = SqlText & "                           sof.taxa_dolar td,"
        SqlText = SqlText & "                           sof.contrato_fixo cf,"
        SqlText = SqlText & "                           sof.contrato_paf cp,"
        SqlText = SqlText & "                           sof.fornecedor f"
        SqlText = SqlText & "                     WHERE cpncfm.dt_fixacao = td.dt_cotacao(+)"
        SqlText = SqlText & "                       AND cpncfm.cd_contrato_paf = cf.cd_contrato_paf"
        SqlText = SqlText & "                       AND cpncfm.sq_negociacao = cf.sq_negociacao"
        SqlText = SqlText & "                       AND cpncfm.sq_contrato_fixo = cf.sq_contrato_fixo"
        SqlText = SqlText & "                       AND cp.cd_contrato_paf = cf.cd_contrato_paf"
        SqlText = SqlText & "                       AND cp.cd_fornecedor = f.cd_fornecedor"
        SqlText = SqlText & "                       AND (   (    cf.vl_pag_fixo <>"
        SqlText = SqlText & "                                         (cf.vl_nf_fixo - cf.vl_nf_inss_fixo"
        SqlText = SqlText & "                                         )"
        SqlText = SqlText & "                                AND (  cf.vl_pag_fixo"
        SqlText = SqlText & "                                     - (cf.vl_nf_fixo - cf.vl_nf_inss_fixo)"
        SqlText = SqlText & "                                    ) <> 0"
        SqlText = SqlText & "                                AND (   (  cf.vl_pag_fixo"
        SqlText = SqlText & "                                         - (cf.vl_nf_fixo - cf.vl_nf_inss_fixo"
        SqlText = SqlText & "                                           )"
        SqlText = SqlText & "                                        ) > 0.03"
        SqlText = SqlText & "                                     OR (  cf.vl_pag_fixo"
        SqlText = SqlText & "                                         - (cf.vl_nf_fixo - cf.vl_nf_inss_fixo"
        SqlText = SqlText & "                                           )"
        SqlText = SqlText & "                                        ) < -0.03"
        SqlText = SqlText & "                                    )"
        SqlText = SqlText & "                               )"
        SqlText = SqlText & "                            OR (cf.qt_kgs - cf.qt_cancelado) <> cf.qt_kg_fixo"
        SqlText = SqlText & "                           )"
        SqlText = SqlText & "                       AND cf.ic_status <> 'E'"
        SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ") "
        SqlText = SqlText & "                  GROUP BY cpncfm.cd_contrato_paf,"
        SqlText = SqlText & "                           cpncfm.sq_negociacao,"
        SqlText = SqlText & "                           cpncfm.sq_contrato_fixo) dmm,"
        SqlText = SqlText & "                 (SELECT   cpncfm.cd_contrato_paf, cpncfm.sq_negociacao,"
        SqlText = SqlText & "                           cpncfm.sq_contrato_fixo,"
        SqlText = SqlText & "                           SUM (ROUND (  (  (pa.vl_aplicacao * cpncfm.vl_fixo"
        SqlText = SqlText & "                                            )"
        SqlText = SqlText & "                                          / DECODE (m.vl_nf, 0, 1, m.vl_nf)"
        SqlText = SqlText & "                                         )"
        SqlText = SqlText & "                                       * tmov.tx_ctr_antigo,"
        SqlText = SqlText & "                                       2"
        SqlText = SqlText & "                                      )"
        SqlText = SqlText & "                               ) vl_aplicado"
        SqlText = SqlText & "                      FROM sof.movimentacao m,"
        SqlText = SqlText & "                           (SELECT   SUM (vl_aplicacao) AS vl_aplicacao,"
        SqlText = SqlText & "                                     sq_movimentacao"
        SqlText = SqlText & "                                FROM sof.pag_amarracao_icms"
        SqlText = SqlText & "                            GROUP BY sq_movimentacao) pa,"
        SqlText = SqlText & "                           (SELECT   cp.sq_movimentacao,"
        SqlText = SqlText & "                                       1 + decode((SUM(cp.vl_fixo) - SUM(DECODE(cf.ic_inclui_icms_pag, 'S', cp.vl_fixo, 0))), 0, 0, SUM(DECODE(cf.ic_inclui_icms_pag, 'S', cp.vl_fixo, 0)) / (SUM(cp.vl_fixo) - SUM(DECODE(cf.ic_inclui_icms_pag, 'S', cp.vl_fixo, 0)))) tx_ctr_antigo"
        SqlText = SqlText & "                                FROM sof.ctr_paf_neg_ctr_fix_mov cp,"
        SqlText = SqlText & "                                     sof.contrato_fixo cf"
        SqlText = SqlText & "                               WHERE cp.sq_movimentacao IN ("
        SqlText = SqlText & "                                               SELECT DISTINCT sq_movimentacao"
        SqlText = SqlText & "                                                          FROM sof.pag_amarracao_icms)"
        SqlText = SqlText & "                                 AND cp.cd_contrato_paf = cf.cd_contrato_paf"
        SqlText = SqlText & "                                 AND cp.sq_negociacao = cf.sq_negociacao"
        SqlText = SqlText & "                                 AND cp.sq_contrato_fixo = cf.sq_contrato_fixo"
        SqlText = SqlText & "                            GROUP BY cp.sq_movimentacao) tmov,"
        SqlText = SqlText & "                           (SELECT   cp.cd_contrato_paf, cp.sq_negociacao,"
        SqlText = SqlText & "                                     cp.sq_contrato_fixo, cp.sq_movimentacao,"
        SqlText = SqlText & "                                     SUM (cp.vl_fixo) AS vl_fixo"
        SqlText = SqlText & "                                FROM sof.ctr_paf_neg_ctr_fix_mov cp,"
        SqlText = SqlText & "                                     sof.contrato_fixo cf"
        SqlText = SqlText & "                               WHERE cp.sq_movimentacao IN ("
        SqlText = SqlText & "                                               SELECT DISTINCT sq_movimentacao"
        SqlText = SqlText & "                                                          FROM sof.pag_amarracao_icms)"
        SqlText = SqlText & "                                 AND cp.cd_contrato_paf = cf.cd_contrato_paf"
        SqlText = SqlText & "                                 AND cp.sq_negociacao = cf.sq_negociacao"
        SqlText = SqlText & "                                 AND cp.sq_contrato_fixo = cf.sq_contrato_fixo"
        SqlText = SqlText & "                                 AND cf.ic_inclui_icms_pag = 'N'"
        SqlText = SqlText & "                            GROUP BY cp.cd_contrato_paf,"
        SqlText = SqlText & "                                     cp.sq_negociacao,"
        SqlText = SqlText & "                                     cp.sq_contrato_fixo,"
        SqlText = SqlText & "                                     cp.sq_movimentacao) cpncfm"
        SqlText = SqlText & "                     WHERE pa.sq_movimentacao = m.sq_movimentacao"
        SqlText = SqlText & "                       AND m.sq_movimentacao = cpncfm.sq_movimentacao"
        SqlText = SqlText & "                       AND m.sq_movimentacao = tmov.sq_movimentacao(+)"
        SqlText = SqlText & "                  GROUP BY cpncfm.cd_contrato_paf,"
        SqlText = SqlText & "                           cpncfm.sq_negociacao,"
        SqlText = SqlText & "                           cpncfm.sq_contrato_fixo) ama"
        SqlText = SqlText & "           WHERE cp.cd_contrato_paf = n.cd_contrato_paf"
        SqlText = SqlText & "             AND n.cd_contrato_paf = cf.cd_contrato_paf"
        SqlText = SqlText & "             AND n.sq_negociacao = cf.sq_negociacao"
        SqlText = SqlText & "             AND cp.cd_fornecedor = f.cd_fornecedor"
        SqlText = SqlText & "             AND f.cd_municipio = munic.cd_municipio"
        SqlText = SqlText & "             AND f.cd_filial_origem = fil.cd_filial"
        SqlText = SqlText & "             AND n.cd_tipo_negociacao = tn.cd_tipo_negociacao"
        SqlText = SqlText & "             AND cf.cd_safra = s.cd_safra"
        SqlText = SqlText & "             AND cf.cd_tipo_unidade = tu.cd_tipo_unidade"
        SqlText = SqlText & "             AND dmp.cd_contrato_paf(+) = cf.cd_contrato_paf"
        SqlText = SqlText & "             AND dmp.sq_negociacao(+) = cf.sq_negociacao"
        SqlText = SqlText & "             AND dmp.sq_contrato_fixo(+) = cf.sq_contrato_fixo"
        SqlText = SqlText & "             AND dmm.cd_contrato_paf(+) = cf.cd_contrato_paf"
        SqlText = SqlText & "             AND dmm.sq_negociacao(+) = cf.sq_negociacao"
        SqlText = SqlText & "             AND dmm.sq_contrato_fixo(+) = cf.sq_contrato_fixo"
        SqlText = SqlText & "             AND ama.cd_contrato_paf(+) = cf.cd_contrato_paf"
        SqlText = SqlText & "             AND ama.sq_negociacao(+) = cf.sq_negociacao"
        SqlText = SqlText & "             AND ama.sq_contrato_fixo(+) = cf.sq_contrato_fixo"
        SqlText = SqlText & "             AND (   (    ROUND (cf.vl_pag_fixo + NVL (ama.vl_aplicado, 0), 2) <>"
        SqlText = SqlText & "                                         (cf.vl_nf_fixo - cf.vl_nf_inss_fixo"
        SqlText = SqlText & "                                         )"
        SqlText = SqlText & "                      AND (  ROUND (cf.vl_pag_fixo + NVL (ama.vl_aplicado, 0),"
        SqlText = SqlText & "                                    2"
        SqlText = SqlText & "                                   )"
        SqlText = SqlText & "                           - (cf.vl_nf_fixo - cf.vl_nf_inss_fixo)"
        SqlText = SqlText & "                          ) <> 0"
        SqlText = SqlText & "                      AND (   (  ROUND (  cf.vl_pag_fixo"
        SqlText = SqlText & "                                        + NVL (ama.vl_aplicado, 0),"
        SqlText = SqlText & "                                        2"
        SqlText = SqlText & "                                       )"
        SqlText = SqlText & "                               - (cf.vl_nf_fixo - cf.vl_nf_inss_fixo)"
        SqlText = SqlText & "                              ) > 0.03"
        SqlText = SqlText & "                           OR (  ROUND (  cf.vl_pag_fixo"
        SqlText = SqlText & "                                        + NVL (ama.vl_aplicado, 0),"
        SqlText = SqlText & "                                        2"
        SqlText = SqlText & "                                       )"
        SqlText = SqlText & "                               - (cf.vl_nf_fixo - cf.vl_nf_inss_fixo)"
        SqlText = SqlText & "                              ) < -0.03"
        SqlText = SqlText & "                          )"
        SqlText = SqlText & "                     )"
        SqlText = SqlText & "                  OR (cf.qt_kgs - cf.qt_cancelado) <> cf.qt_kg_fixo"
        SqlText = SqlText & "                 )"
        SqlText = SqlText & "             AND cf.ic_status <> 'E'"
        SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        oDataAux = DBQuery(SqlText)

        For iCont = 0 To oDataAux.Rows.Count - 1
            oRow = oData.NewRow

            oRow.Item("CD_FILIAL") = oDataAux.Rows(iCont).Item("CD_FILIAL")
            oRow.Item("NO_FILIAL") = oDataAux.Rows(iCont).Item("NO_FILIAL")
            oRow.Item("VL_CACAU_ORDEM") = NVL(oRow.Item("VL_CACAU_ORDEM"), 0)
            oRow.Item("VL_PRECO_MEDIO") = NVL(oRow.Item("VL_PRECO_MEDIO"), 0)
            oRow.Item("VL_INSS") = NVL(oRow.Item("VL_INSS"), 0)
            oRow.Item("VL_ADTO_ICMS") = NVL(oRow.Item("VL_ADTO_ICMS"), 0)
            oRow.Item("VL_ADTO_CTR_PAF") = NVL(oRow.Item("VL_ADTO_CTR_PAF"), 0)
            oRow.Item("VL_CONF_DIVIDA") = NVL(oRow.Item("VL_CONF_DIVIDA"), 0)
            oRow.Item("VL_CONF_DIVIDA_JUROS") = NVL(oRow.Item("VL_CONF_DIVIDA_JUROS"), 0)
            oRow.Item("VL_CACAU_ORDEM_US") = NVL(oRow.Item("VL_CACAU_ORDEM_US"), 0)
            oRow.Item("VL_PRECO_MEDIO_US") = NVL(oRow.Item("VL_PRECO_MEDIO_US"), 0)
            oRow.Item("VL_INSS_US") = NVL(oRow.Item("VL_INSS_US"), 0)
            oRow.Item("VL_ADTO_ICMS_US") = NVL(oRow.Item("VL_ADTO_ICMS_US"), 0)
            oRow.Item("VL_ADTO_CTR_PAF_US") = NVL(oRow.Item("VL_ADTO_CTR_PAF_US"), 0)
            oRow.Item("VL_CONF_DIVIDA_US") = NVL(oRow.Item("VL_CONF_DIVIDA_US"), 0)
            oRow.Item("VL_CONF_DIVIDA_JUROS_US") = NVL(oRow.Item("VL_CONF_DIVIDA_JUROS_US"), 0)
            oRow.Item("VL_TAXA_US") = TaxaDolar
            'oRow.Item("DT_BASE") = Date_to_Oracle(txtdtbase.Text)
            oRow.Item("QT_KGS") = NVL(oDataAux.Rows(iCont).Item("QT_KGS"), 0)
            oRow.Item("VL_TOTAL") = NVL(oDataAux.Rows(iCont).Item("VL_TOTAL"), 0)
            oRow.Item("VL_ADENDO") = NVL(oDataAux.Rows(iCont).Item("VL_ADENDO"), 0)
            oRow.Item("VL_ICMS") = NVL(oDataAux.Rows(iCont).Item("VL_ICMS"), 0)
            oRow.Item("VL_ADENDO_ICMS") = NVL(oDataAux.Rows(iCont).Item("VL_ADENDO_ICMS"), 0)
            oRow.Item("VL_PAG_FIXO") = NVL(oDataAux.Rows(iCont).Item("VL_PAG_FIXO"), 0)
            oRow.Item("QT_KG_FIXO") = NVL(oDataAux.Rows(iCont).Item("QT_KG_FIXO"), 0)
            oRow.Item("IC_TAXA_DOLAR_VARIAVEL") = oDataAux.Rows(iCont).Item("IC_TAXA_DOLAR_VARIAVEL")
            oRow.Item("VL_DOLAR_ATUAL") = NVL(oDataAux.Rows(iCont).Item("VL_DOLAR_ATUAL"), 0)
            oRow.Item("IC_BOLSA_OPERACAO") = NVL(oDataAux.Rows(iCont).Item("IC_BOLSA_OPERACAO"), 0)
            oRow.Item("VL_BOLSA_FECHADO") = NVL(oDataAux.Rows(iCont).Item("VL_BOLSA_FECHADO"), 0)
            oRow.Item("VL_NEGOCIACAO") = NVL(oDataAux.Rows(iCont).Item("VL_NEGOCIACAO"), 0)
            oRow.Item("VL_NF_FIXO") = NVL(oDataAux.Rows(iCont).Item("VL_NF_FIXO"), 0)
            oRow.Item("VL_NF_INSS_FIXO") = NVL(oDataAux.Rows(iCont).Item("VL_NF_INSS_FIXO"), 0)
            oData.Rows.Add(oRow)
        Next

        'Prov NF complementar
        Dim SqlText_CtrAberto As String

        SqlText_CtrAberto = "SELECT CD_CONTRATO_PAF, SQ_NEGOCIACAO, SQ_CONTRATO_FIXO FROM SOF.CONTRATO_FIXO WHERE IC_STATUS = 'A'"

        SqlText = "SELECT FNC.NO_RAZAO_SOCIAL NO_FORNECEDOR,fil.CD_FILIAL, fil.NO_FILIAL, " & _
                         "FIX.DT_CONTRATO_FIXO," & _
                         "MOV.DT_MOVIMENTACAO," & _
                         "TRIM(PMF.CD_CONTRATO_PAF) || '-' || TRIM(PMF.SQ_NEGOCIACAO) || '-' || TRIM(PMF.SQ_CONTRATO_FIXO) CD_CONTRATO," & _
                         "FIX.VL_UNITARIO," & _
                         "TRIM(MOV.NU_NF) || NVL2(MOV.NU_SERIE_NF, '-' || TRIM(MOV.NU_SERIE_NF), '') NU_NF," & _
                         "SUM(PMF.QT_KG_FIXO) QT_KG_NF," & _
                         "SUM(PMF.VL_FIXO) VL_NF," & _
                         "ROUND(SUM(PMF.QT_KG_FIXO * ((ROUND((ROUND(((FIX.VL_TOTAL + NVL(FIX.VL_ICMS, 0)) / FIX.QT_KGS) * (FIX.QT_KGS - FIX.QT_CANCELADO), 2) + FIX.VL_ADENDO + NVL(FIX.VL_ADENDO_ICMS, 0)) / DECODE(NVL(FIX.VL_INSS, 0), 0, 1, 0.977), 2)) / (DECODE(FIX.QT_KGS - FIX.QT_CANCELADO, 0, 1, FIX.QT_KGS - FIX.QT_CANCELADO)))), 2) VL_CONTRATO," & _
                         "FIX.VL_TAXA_DOLAR TX_DOLAR," & _
                         "PMF.SQ_MOVIMENTACAO" & _
                  " FROM (" & SqlText_CtrAberto & ") CAB," & _
                        "SOF.CTR_PAF_NEG_CTR_FIX_MOV PMF," & _
                        "SOF.TIPO_UNIDADE TPU," & _
                        "sof.filial fil," & _
                        "SOF.CONTRATO_FIXO FIX," & _
                        "SOF.CONTRATO_PAF PAF," & _
                        "SOF.MOVIMENTACAO MOV," & _
                        "SOF.TAXA_DOLAR TD," & _
                        "SOF.FORNECEDOR FNC," & _
                        "SOF.PARAMETRO_MODALIDADE_TIPO_MOV PMT" & _
                  " WHERE PMF.CD_CONTRATO_PAF = CAB.CD_CONTRATO_PAF" & _
                    " AND PMF.SQ_NEGOCIACAO = CAB.SQ_NEGOCIACAO" & _
                    " AND PMF.SQ_CONTRATO_FIXO = CAB.SQ_CONTRATO_FIXO" & _
                    " and fil.cd_filial= fnc.CD_FILIAL_ORIGEM " & _
                    " AND FIX.CD_CONTRATO_PAF = PMF.CD_CONTRATO_PAF" & _
                    " AND FIX.SQ_NEGOCIACAO = PMF.SQ_NEGOCIACAO" & _
                    " AND FIX.SQ_CONTRATO_FIXO = PMF.SQ_CONTRATO_FIXO" & _
                    " AND PAF.CD_CONTRATO_PAF = PMF.CD_CONTRATO_PAF" & _
                    " AND FNC.CD_FORNECEDOR = PAF.CD_FORNECEDOR" & _
                    " AND FNC.CD_TIPO_PESSOA NOT IN (" & cnt_TipoPessoa_IMPORTADO & ")" & _
                    " AND TPU.CD_TIPO_UNIDADE = FIX.CD_TIPO_UNIDADE" & _
                    " AND MOV.SQ_MOVIMENTACAO = PMF.SQ_MOVIMENTACAO" & _
                    " AND PMT.CD_TIPO_MOVIMENTACAO = MOV.CD_TIPO_MOVIMENTACAO" & _
                    " AND PMT.CD_PARAMETRO_MODALIDADE = " & cnt_ParametroModalidade_BranchesRecebimento & _
                    " AND TD.DT_COTACAO (+) = MOV.DT_MOVIMENTACAO" & _
                 " GROUP BY FNC.NO_RAZAO_SOCIAL,fil.CD_FILIAL, fil.NO_FILIAL," & _
                           "FIX.DT_CONTRATO_FIXO," & _
                           "MOV.DT_MOVIMENTACAO," & _
                           "FIX.VL_UNITARIO," & _
                           "TRIM(MOV.NU_NF) || NVL2(MOV.NU_SERIE_NF, '-' || TRIM(MOV.NU_SERIE_NF), '')," & _
                           "TRIM(PMF.CD_CONTRATO_PAF) || '-' || TRIM(PMF.SQ_NEGOCIACAO) || '-' || TRIM(PMF.SQ_CONTRATO_FIXO)," & _
                           "PMF.SQ_MOVIMENTACAO," & _
                           "FIX.VL_TAXA_DOLAR " & _
                 " ORDER BY FNC.NO_RAZAO_SOCIAL," & _
                           "TRIM(PMF.CD_CONTRATO_PAF) || '-' || TRIM(PMF.SQ_NEGOCIACAO) || '-' || TRIM(PMF.SQ_CONTRATO_FIXO)," & _
                           "MOV.DT_MOVIMENTACAO"
        oDataAux = DBQuery(SqlText)


        'Carregar as NF Complementar
        SqlText = "SELECT TRIM(PMF.CD_CONTRATO_PAF) || '-' || TRIM(PMF.SQ_NEGOCIACAO) || '-' || TRIM(PMF.SQ_CONTRATO_FIXO) CD_CONTRATO," & _
                         "PMF.SQ_MOVIMENTACAO," & _
                         "SUM(PMF.VL_FIXO * PMT.NR_MULTIPLICADOR) VL_FIXO" & _
                  " FROM (" & SqlText_CtrAberto & ") CAB," & _
                        "SOF.CTR_PAF_NEG_CTR_FIX_MOV PMF," & _
                        "SOF.MOVIMENTACAO MOV," & _
                        "(SELECT CD_TIPO_MOVIMENTACAO," & _
                                "NR_ORDENACAO NR_MULTIPLICADOR" & _
                         " FROM SOF.PARAMETRO_MODALIDADE_TIPO_MOV" & _
                         " WHERE CD_PARAMETRO_MODALIDADE IN (" & cnt_ParametroModalidade_NFComplementar & "," & _
                                                                 cnt_ParametroModalidade_AjusteAplicacaoContratoFixo & ")) PMT" & _
                  " WHERE PMF.CD_CONTRATO_PAF = CAB.CD_CONTRATO_PAF" & _
                    " AND PMF.SQ_NEGOCIACAO = CAB.SQ_NEGOCIACAO" & _
                    " AND PMF.SQ_CONTRATO_FIXO = CAB.SQ_CONTRATO_FIXO" & _
                    " AND MOV.SQ_MOVIMENTACAO = PMF.SQ_MOVIMENTACAO" & _
                    " AND PMT.CD_TIPO_MOVIMENTACAO = MOV.CD_TIPO_MOVIMENTACAO" & _
                 " GROUP BY TRIM(PMF.CD_CONTRATO_PAF) || '-' || TRIM(PMF.SQ_NEGOCIACAO) || '-' || TRIM(PMF.SQ_CONTRATO_FIXO)," & _
                           "PMF.SQ_MOVIMENTACAO" & _
                 " HAVING SUM(PMF.VL_FIXO) <> 0"
        oDataAux2 = DBQuery(SqlText)

        iCont2 = 0
        Dim bAchou As Boolean
        Dim VL_FIXO As Double
        Dim dAUX As Double

        For iCont2 = 0 To oDataAux2.Rows.Count - 1
            VL_FIXO = oDataAux2.Rows(iCont2).Item("VL_FIXO")
            bAchou = False

            For iCont = 0 To oDataAux.Rows.Count - 1
                With oDataAux.Rows(iCont)
                    If oDataAux2.Rows(iCont2).Item("CD_CONTRATO") = .Item("CD_CONTRATO") Then
                        If VL_FIXO <> 0 And (.Item("VL_CONTRATO") - .Item("VL_NF")) > 0 Then
                            bAchou = True

                            dAUX = IIf(.Item("VL_CONTRATO") - .Item("VL_NF") < VL_FIXO, .Item("VL_CONTRATO") - .Item("VL_NF"), VL_FIXO)
                            .Item("VL_NF") = .Item("VL_NF") + dAUX
                            VL_FIXO = VL_FIXO - dAUX

                            If VL_FIXO = 0 Then
                                Exit For
                            End If
                        End If
                    End If
                End With
            Next
        Next

        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        objData_Finalizar(oDataAux2)
        iCont_01 = 0

        'Remove as NFs que não precisam de NF Complementar
        oDataAux2 = New DataTable
        oDataAux2 = oDataAux.Clone

        For iCont_01 = 0 To oDataAux.Rows.Count - 1
            If Math.Abs(oDataAux.Rows(iCont_01).Item("VL_CONTRATO") - oDataAux.Rows(iCont_01).Item("VL_NF")) > 0.03 Then
                With oDataAux2.Rows.Add()
                    For iCont_02 = 0 To oDataAux.Columns.Count - 1
                        .Item(iCont_02) = oDataAux.Rows(iCont_01).Item(iCont_02)
                    Next
                End With
            End If
        Next

        oDataAux = oDataAux2

        REL_ProvisaoNFComplementar_ExcluirValorBaixos(oDataAux)

        For iCont = 0 To oDataAux.Rows.Count - 1
            oRow = oData.NewRow

            oRow.Item("CD_FILIAL") = oDataAux.Rows(iCont).Item("CD_FILIAL")
            oRow.Item("NO_FILIAL") = oDataAux.Rows(iCont).Item("NO_FILIAL")

            oRow.Item("VL_CACAU_ORDEM") = NVL(oRow.Item("VL_CACAU_ORDEM"), 0)
            oRow.Item("VL_PRECO_MEDIO") = NVL(oRow.Item("VL_PRECO_MEDIO"), 0)
            oRow.Item("VL_INSS") = NVL(oRow.Item("VL_INSS"), 0)
            oRow.Item("VL_ADTO_ICMS") = NVL(oRow.Item("VL_ADTO_ICMS"), 0)
            oRow.Item("VL_ADTO_CTR_PAF") = NVL(oRow.Item("VL_ADTO_CTR_PAF"), 0)
            oRow.Item("VL_CONF_DIVIDA") = NVL(oRow.Item("VL_CONF_DIVIDA"), 0)
            oRow.Item("VL_CONF_DIVIDA_JUROS") = NVL(oRow.Item("VL_CONF_DIVIDA_JUROS"), 0)

            oRow.Item("VL_CACAU_ORDEM_US") = NVL(oRow.Item("VL_CACAU_ORDEM_US"), 0)
            oRow.Item("VL_PRECO_MEDIO_US") = NVL(oRow.Item("VL_PRECO_MEDIO_US"), 0)
            oRow.Item("VL_INSS_US") = NVL(oRow.Item("VL_INSS_US"), 0)
            oRow.Item("VL_ADTO_ICMS_US") = NVL(oRow.Item("VL_ADTO_ICMS_US"), 0)
            oRow.Item("VL_ADTO_CTR_PAF_US") = NVL(oRow.Item("VL_ADTO_CTR_PAF_US"), 0)
            oRow.Item("VL_CONF_DIVIDA_US") = NVL(oRow.Item("VL_CONF_DIVIDA_US"), 0)
            oRow.Item("VL_CONF_DIVIDA_JUROS_US") = NVL(oRow.Item("VL_CONF_DIVIDA_JUROS_US"), 0)

            oRow.Item("VL_TAXA_US") = TaxaDolar

            oRow.Item("VL_PROV_NF_COMPL") = NVL(oRow.Item("VL_PROV_NF_COMPL"), 0) + (oDataAux.Rows(iCont).Item("VL_CONTRATO") - oDataAux.Rows(iCont).Item("VL_NF"))
            If NVL(oDataAux.Rows(iCont).Item("TX_DOLAR"), 0) = 0 Then
                oRow.Item("VL_PROV_NF_COMPL_US") = NVL(oRow.Item("VL_PROV_NF_COMPL_US"), 0)
            Else
                oRow.Item("VL_PROV_NF_COMPL_US") = NVL(oRow.Item("VL_PROV_NF_COMPL_US"), 0) + ((oDataAux.Rows(iCont).Item("VL_CONTRATO") - oDataAux.Rows(iCont).Item("VL_NF")) / NVL(oDataAux.Rows(iCont).Item("TX_DOLAR"), 0))
            End If

            oData.Rows.Add(oRow)
        Next

        'adto em aberto
        SqlText = "SELECT fil.cd_filial, fil.no_filial, sum(pcp.vl_a_fixar) vl_pagamento , 'P' Tipo "
        SqlText = SqlText & "  FROM sof.pag_ctr_paf pcp, "
        SqlText = SqlText & "       sof.pagamentos p, "
        SqlText = SqlText & "       sof.fornecedor f, "
        SqlText = SqlText & "       sof.filial fil  "
        SqlText = SqlText & " WHERE p.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "   AND f.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "   AND p.sq_pagamento = pcp.sq_pagamento "
        SqlText = SqlText & "   AND pcp.vl_a_fixar <> 0 "
        SqlText = SqlText & "group by fil.cd_filial, fil.no_filial "
        SqlText = SqlText & "union "
        SqlText = SqlText & "SELECT fil.cd_filial, fil.no_filial, sum(pcp.vl_a_fixar) vl_pagamento, 'N' Tipo "
        SqlText = SqlText & "  FROM sof.pag_neg pcp, "
        SqlText = SqlText & "       sof.pagamentos p, "
        SqlText = SqlText & "       sof.fornecedor f, "
        SqlText = SqlText & "       sof.filial fil "
        SqlText = SqlText & " WHERE p.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "   AND f.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "   AND p.sq_pagamento = pcp.sq_pagamento "
        SqlText = SqlText & "   AND pcp.vl_a_fixar <> 0 "
        SqlText = SqlText & "group by fil.cd_filial, fil.no_filial "

        oDataAux = DBQuery(SqlText)

        For iCont = 0 To oDataAux.Rows.Count - 1
            ' oRow = oData.Rows.Find(New Object() {oDataAux.Rows(iCont).Item("CD_FILIAL")})
            oRow = oData.NewRow

            oRow.Item("CD_FILIAL") = oDataAux.Rows(iCont).Item("CD_FILIAL")
            oRow.Item("NO_FILIAL") = oDataAux.Rows(iCont).Item("NO_FILIAL")

            oRow.Item("VL_CACAU_ORDEM") = NVL(oRow.Item("VL_CACAU_ORDEM"), 0)
            oRow.Item("VL_PRECO_MEDIO") = NVL(oRow.Item("VL_PRECO_MEDIO"), 0)
            oRow.Item("VL_INSS") = NVL(oRow.Item("VL_INSS"), 0)
            oRow.Item("VL_ADTO_ICMS") = NVL(oRow.Item("VL_ADTO_ICMS"), 0)
            If oDataAux.Rows(iCont).Item("Tipo") = "P" Then
                oRow.Item("VL_ADTO_CTR_PAF") = NVL(oRow.Item("VL_ADTO_CTR_PAF"), 0) + oDataAux.Rows(iCont).Item("vl_pagamento")
                oRow.Item("VL_ADTO_NEG") = NVL(oRow.Item("VL_ADTO_NEG"), 0)
            Else
                oRow.Item("VL_ADTO_CTR_PAF") = NVL(oRow.Item("VL_ADTO_CTR_PAF"), 0)
                oRow.Item("VL_ADTO_NEG") = NVL(oRow.Item("VL_ADTO_NEG"), 0) + oDataAux.Rows(iCont).Item("vl_pagamento")
            End If
            oRow.Item("VL_CONF_DIVIDA") = NVL(oRow.Item("VL_CONF_DIVIDA"), 0)
            oRow.Item("VL_CONF_DIVIDA_JUROS") = NVL(oRow.Item("VL_CONF_DIVIDA_JUROS"), 0)

            oRow.Item("VL_CACAU_ORDEM_US") = NVL(oRow.Item("VL_CACAU_ORDEM_US"), 0)
            oRow.Item("VL_PRECO_MEDIO_US") = NVL(oRow.Item("VL_PRECO_MEDIO_US"), 0)
            oRow.Item("VL_INSS_US") = NVL(oRow.Item("VL_INSS_US"), 0)
            oRow.Item("VL_ADTO_ICMS_US") = NVL(oRow.Item("VL_ADTO_ICMS_US"), 0)
            oRow.Item("VL_ADTO_CTR_PAF_US") = NVL(oRow.Item("VL_ADTO_CTR_PAF_US"), 0) + (oDataAux.Rows(iCont).Item("vl_pagamento") / TaxaDolar)

            If oDataAux.Rows(iCont).Item("Tipo") = "P" Then
                oRow.Item("VL_ADTO_CTR_PAF_US") = NVL(oRow.Item("VL_ADTO_CTR_PAF_US"), 0) + (oDataAux.Rows(iCont).Item("vl_pagamento") / TaxaDolar)
                oRow.Item("VL_ADTO_NEG_US") = NVL(oRow.Item("VL_ADTO_NEG_US"), 0)
            Else
                oRow.Item("VL_ADTO_CTR_PAF_US") = NVL(oRow.Item("VL_ADTO_CTR_PAF_US"), 0)
                oRow.Item("VL_ADTO_NEG_US") = NVL(oRow.Item("VL_ADTO_NEG_US"), 0) + (oDataAux.Rows(iCont).Item("vl_pagamento") / TaxaDolar)
            End If

            oRow.Item("VL_CONF_DIVIDA_US") = NVL(oRow.Item("VL_CONF_DIVIDA_US"), 0)
            oRow.Item("VL_CONF_DIVIDA_JUROS_US") = NVL(oRow.Item("VL_CONF_DIVIDA_JUROS_US"), 0)

            oRow.Item("VL_TAXA_US") = TaxaDolar
            'oRow.Item("DT_BASE") = Date_to_Oracle(txtdtbase.Text)

            oRow.Item("QT_KGS") = 0
            oRow.Item("VL_TOTAL") = 0
            oRow.Item("VL_ADENDO") = 0
            oRow.Item("VL_ICMS") = 0
            oRow.Item("VL_ADENDO_ICMS") = 0
            oRow.Item("VL_PAG_FIXO") = 0
            oRow.Item("QT_KG_FIXO") = 0
            oRow.Item("IC_TAXA_DOLAR_VARIAVEL") = "N"
            oRow.Item("VL_DOLAR_ATUAL") = 0
            oRow.Item("IC_BOLSA_OPERACAO") = "+"
            oRow.Item("VL_BOLSA_FECHADO") = 0
            oRow.Item("VL_NEGOCIACAO") = 0
            oRow.Item("VL_NF_FIXO") = 0
            oRow.Item("VL_NF_INSS_FIXO") = 0

            oData.Rows.Add(oRow)
        Next

        If IsDate(DataBase) Then
            Str_Adicionar(sFiltro, "Data Base: " & DataBase, " - ")
        End If
        Str_Adicionar(sFiltro, "Bolsa: " & Bolsa, " - ")
        Str_Adicionar(sFiltro, "Dólar: " & TaxaDolar, " - ")
        Str_Adicionar(sFiltro, "Diff: " & ValorDif, " - ")

        oRelatorio.Load(Application.StartupPath & "\RPT_Saldo_Fornecedor.rpt")
        oRelatorio.SetDataSource(oData)

        oRelatorio.SetParameterValue("VlMin", VlMin)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        oRelatorio.SetParameterValue("Filtro", sFiltro)

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_NegociacaoAbertaComFixacoes(ByVal DataLimite As String, _
                                                               ByVal DataBolsa As String, _
                                                               ByVal ListagemFilial As String, _
                                                               ByVal ListagemTipoNegociacao As String, _
                                                               ByVal Saldo As Boolean, _
                                                               ByVal Sintetico As Boolean, _
                                                               ByVal chkDataLimite As Boolean, _
                                                               ByVal Fixacoes As Boolean, _
                                                               ByVal UsarBolsaCalcSaldo As Boolean) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""

        oData = Gera_Rs_NegociacaoAbertaComFixacoes(DataLimite, DataBolsa, ListagemFilial, ListagemTipoNegociacao, Saldo)

        oRelatorio.Load(Application.StartupPath & "\RPT_Negociacao_Aberta_Com_Fixacao.rpt")
        oRelatorio.SetDataSource(oData)

        'Filtro filial
        If Trim(ListagemFilial) <> "" Then
            Str_Adicionar(sFiltro, "Filial: " & MontaFiltro_Filial(ListagemFilial), " - ")
        End If
        If Trim(ListagemTipoNegociacao) <> "" Then
            SqlText = "SELECT TRIM(NO_TIPO_NEGOCIACAO) FROM SOF.TIPO_NEGOCIACAO WHERE CD_TIPO_NEGOCIACAO IN (" & ListagemTipoNegociacao & ")"
            Str_Adicionar(sFiltro, "Tipo Negociação: " & DBQuery_ValorUnico_Lista(SqlText), " - ")
        End If
        If Saldo Then
            Str_Adicionar(sFiltro, "Apenas com Saldo", " - ")
        End If

        'SE FOR SINTETICO ESCONDE OS DETALHES DA FIXAÇÃO
        If Sintetico Then
            Str_Adicionar(sFiltro, "Sintético", " - ")
        Else
            Str_Adicionar(sFiltro, "Analítico", " - ")
        End If
        If chkDataLimite Then
            Str_Adicionar(sFiltro, "Até a data: " & DataLimite, " - ")
        End If

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        oRelatorio.SetParameterValue("ExibeContratoFixo", IIf(Fixacoes, "S", "N"))
        oRelatorio.SetParameterValue("Tipo", IIf(Sintetico, "S", "A"))
        oRelatorio.SetParameterValue("UsarBolsaCalcSaldo", IIf(UsarBolsaCalcSaldo, "S", "N"))

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_RecuperacaoCredito(ByVal Sintetico As Boolean, _
                                                      ByVal ListagemFilial As String, _
                                                      ByVal ListagemModalidade As String, _
                                                      ByVal Vencidas As Boolean) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oRelatorio_Sub1 As New ReportDocument
        Dim oData As DataTable
        Dim oData_Sub1 As DataTable = Nothing
        Dim SqlText As String = ""
        Dim SqlText_Aux As String = ""
        Dim sFiltro As String = ""

        Select Case Sintetico
            Case True
                SqlText = "SELECT   CD.SQ_CONFISSAO_DIVIDA, CD.DT_CONFISSAO_DIVIDA, CD.CD_FORNECEDOR, "
                SqlText = SqlText & "         F.NO_RAZAO_SOCIAL, CD.VL_ORIGINAL, CD.QT_ORIGINAL, CD.VL_NEGOCIADO, "
                SqlText = SqlText & "         CD.CD_FILIAL_ORIGEM, FIL.NO_FILIAL, "
                SqlText = SqlText & "         decode(round(SUM (DECODE (CDP.IC_SITUACAO, "
                SqlText = SqlText & "                      'A', DECODE (CD.IC_COBRA_JUROS, "
                SqlText = SqlText & "                                   'S', CDP.VL_PARCELA "
                SqlText = SqlText & "                                    * (  1 "
                SqlText = SqlText & "                                       + (  (SYSDATE - CD.DT_COBRA_JUROS) "
                SqlText = SqlText & "                                          * (CD.PC_JUROS_AO_MES / 30) "
                SqlText = SqlText & "                                          / 100 "
                SqlText = SqlText & "                                         ) "
                SqlText = SqlText & "                                      ), "
                SqlText = SqlText & "                                   CDP.VL_PARCELA "
                SqlText = SqlText & "                                  ), "
                SqlText = SqlText & "                      0 "
                SqlText = SqlText & "                     ) "
                SqlText = SqlText & "             ),2), 0, CD.VL_ORIGINAL,"
                SqlText = SqlText & "         round(SUM (DECODE (CDP.IC_SITUACAO, "
                SqlText = SqlText & "                      'A', DECODE (CD.IC_COBRA_JUROS, "
                SqlText = SqlText & "                                   'S', CDP.VL_PARCELA "
                SqlText = SqlText & "                                    * (  1 "
                SqlText = SqlText & "                                       + (  (SYSDATE - CD.DT_COBRA_JUROS) "
                SqlText = SqlText & "                                          * (CD.PC_JUROS_AO_MES / 30) "
                SqlText = SqlText & "                                          / 100 "
                SqlText = SqlText & "                                         ) "
                SqlText = SqlText & "                                      ), "
                SqlText = SqlText & "                                   CDP.VL_PARCELA "
                SqlText = SqlText & "                                  ), "
                SqlText = SqlText & "                      0 "
                SqlText = SqlText & "                     ) "
                SqlText = SqlText & "             ),2)) VL_PARCELA_AB, "
                SqlText = SqlText & "         SUM (NVL (CDA.VL_ATIVO, 0)) VL_PARCELA_PAG, "
                SqlText = SqlText & "         SUM (DECODE (CDP.IC_SITUACAO, 'A', 1, 0)) QT_PARCELA_AB, "
                SqlText = SqlText & "         SUM (DECODE (CDP.IC_SITUACAO, 'A', 0, 1)) QT_PARCELA_FC, "
                SqlText = SqlText & "         CDM.NO_CONFISSAO_DIVIDA_MODALIDADE "
                SqlText = SqlText & "    FROM SOF.CONFISSAO_DIVIDA CD, "
                SqlText = SqlText & "         SOF.CONFISSAO_DIVIDA_PARCELA CDP, "
                SqlText = SqlText & "         SOF.CONFISSAO_DIVIDA_ATIVO CDA, "
                SqlText = SqlText & "         SOF.FORNECEDOR F, "
                SqlText = SqlText & "         SOF.FILIAL FIL, "
                SqlText = SqlText & "         SOF.CONFISSAO_DIVIDA_MODALIDADE CDM "
                SqlText = SqlText & "   WHERE F.CD_FORNECEDOR = CD.CD_FORNECEDOR "
                SqlText = SqlText & "     AND FIL.CD_FILIAL = CD.CD_FILIAL_ORIGEM "
                SqlText = SqlText & "     AND CD.CD_CONFISSAO_DIVIDA_MODALIDADE = CDM.CD_CONFISSAO_DIVIDA_MODALIDADE "
                SqlText = SqlText & "     AND CD.SQ_CONFISSAO_DIVIDA = CDP.SQ_CONFISSAO_DIVIDA(+) "
                SqlText = SqlText & "     AND CDP.SQ_CONFISSAO_DIVIDA = CDA.SQ_CONFISSAO_DIVIDA(+) "
                SqlText = SqlText & "     AND CDP.NU_PARCELA = CDA.NU_PARCELA(+) "
                SqlText = SqlText & "     AND CD.IC_STATUS = 'A' "

                SqlText = "SELECT   CD.SQ_CONFISSAO_DIVIDA, CD.DT_CONFISSAO_DIVIDA, CD.CD_FORNECEDOR, "
                SqlText = SqlText & "         F.NO_RAZAO_SOCIAL, CD.VL_ORIGINAL, CD.QT_ORIGINAL, CD.VL_NEGOCIADO, "
                SqlText = SqlText & "         CD.CD_FILIAL_ORIGEM, FIL.NO_FILIAL, "
                SqlText = SqlText & "         decode(round(SUM (DECODE (CDP.IC_SITUACAO, "
                SqlText = SqlText & "                      'A', DECODE (CD.IC_COBRA_JUROS, "
                SqlText = SqlText & "                                   'S', CDP.VL_PARCELA "
                SqlText = SqlText & "                                    * (  1 "
                SqlText = SqlText & "                                       + (  (SYSDATE - CD.DT_COBRA_JUROS) "
                SqlText = SqlText & "                                          * (CD.PC_JUROS_AO_MES / 30) "
                SqlText = SqlText & "                                          / 100 "
                SqlText = SqlText & "                                         ) "
                SqlText = SqlText & "                                      ), "
                SqlText = SqlText & "                                   CDP.VL_PARCELA "
                SqlText = SqlText & "                                  ), "
                SqlText = SqlText & "                      0 "
                SqlText = SqlText & "                     ) "
                SqlText = SqlText & "             ),2), 0, CD.VL_ORIGINAL,"
                SqlText = SqlText & "         round(SUM (DECODE (CDP.IC_SITUACAO, "
                SqlText = SqlText & "                      'A', DECODE (CD.IC_COBRA_JUROS, "
                SqlText = SqlText & "                                   'S', CDP.VL_PARCELA "
                SqlText = SqlText & "                                    * (  1 "
                SqlText = SqlText & "                                       + (  (SYSDATE - CD.DT_COBRA_JUROS) "
                SqlText = SqlText & "                                          * (CD.PC_JUROS_AO_MES / 30) "
                SqlText = SqlText & "                                          / 100 "
                SqlText = SqlText & "                                         ) "
                SqlText = SqlText & "                                      ), "
                SqlText = SqlText & "                                   CDP.VL_PARCELA "
                SqlText = SqlText & "                                  ), "
                SqlText = SqlText & "                      0 "
                SqlText = SqlText & "                     ) "
                SqlText = SqlText & "             ),2)) VL_PARCELA_AB, "
                SqlText = SqlText & "         SUM (NVL (CDA.VL_ATIVO, 0)) VL_PARCELA_PAG, "
                SqlText = SqlText & "         SUM (DECODE (CDP.IC_SITUACAO, 'A', 1, 0)) QT_PARCELA_AB, "
                SqlText = SqlText & "         SUM (DECODE (CDP.IC_SITUACAO, 'A', 0, 1)) QT_PARCELA_FC, "
                SqlText = SqlText & "         CDM.NO_CONFISSAO_DIVIDA_MODALIDADE "
                SqlText = SqlText & "    FROM SOF.CONFISSAO_DIVIDA CD, "
                SqlText = SqlText & "         SOF.CONFISSAO_DIVIDA_PARCELA CDP, "
                SqlText = SqlText & "         SOF.CONFISSAO_DIVIDA_ATIVO CDA, "
                SqlText = SqlText & "         SOF.FORNECEDOR F, "
                SqlText = SqlText & "         SOF.FILIAL FIL, "
                SqlText = SqlText & "         SOF.CONFISSAO_DIVIDA_MODALIDADE CDM "
                SqlText = SqlText & "   WHERE F.CD_FORNECEDOR = CD.CD_FORNECEDOR "
                SqlText = SqlText & "     AND FIL.CD_FILIAL = CD.CD_FILIAL_ORIGEM "
                SqlText = SqlText & "     AND CD.CD_CONFISSAO_DIVIDA_MODALIDADE = "
                SqlText = SqlText & "                                            CDM.CD_CONFISSAO_DIVIDA_MODALIDADE "
                SqlText = SqlText & "     AND CD.SQ_CONFISSAO_DIVIDA = CDP.SQ_CONFISSAO_DIVIDA(+) "
                SqlText = SqlText & "     AND CDP.SQ_CONFISSAO_DIVIDA = CDA.SQ_CONFISSAO_DIVIDA(+) "
                SqlText = SqlText & "     AND CDP.NU_PARCELA = CDA.NU_PARCELA(+) "
                SqlText = SqlText & "     AND CD.IC_STATUS = 'A' "

                oRelatorio.Load(Application.StartupPath & "\RPT_RecCredito_Sintetico.rpt")
            Case False
                SqlText = "SELECT CD.SQ_CONFISSAO_DIVIDA, CD.DT_CONFISSAO_DIVIDA, CD.CD_FORNECEDOR, "
                SqlText = SqlText & "       F.NO_RAZAO_SOCIAL, CD.VL_ORIGINAL, CD.QT_ORIGINAL, CD.VL_NEGOCIADO, "
                SqlText = SqlText & "       CD.CD_FILIAL_ORIGEM, FIL.NO_FILIAL, CDP.NU_PARCELA, CDP.DT_VENCIMENTO, "
                SqlText = SqlText & "       CDP.IC_CACAU, CDP.IC_MOEDA, CDP.IC_OUTROS, CDP.DS_OUTROS, "
                SqlText = SqlText & "       round(DECODE (CDP.IC_SITUACAO, "
                SqlText = SqlText & "               'A', DECODE (CD.IC_COBRA_JUROS, "
                SqlText = SqlText & "                            'S', CDP.VL_PARCELA "
                SqlText = SqlText & "                             * (  1 "
                SqlText = SqlText & "                                + (  (SYSDATE - CD.DT_COBRA_JUROS) "
                SqlText = SqlText & "                                   * (CD.PC_JUROS_AO_MES / 30) "
                SqlText = SqlText & "                                   / 100 "
                SqlText = SqlText & "                                  ) "
                SqlText = SqlText & "                               ), "
                SqlText = SqlText & "                            CDP.VL_PARCELA "
                SqlText = SqlText & "                           ), "
                SqlText = SqlText & "               0 "
                SqlText = SqlText & "              ),2) VL_PARCELA, "
                SqlText = SqlText & "       CDP.QT_ITEM_PARCELA, CDP.IC_SITUACAO, CDA.DT_PAGAMENTO, "
                SqlText = SqlText & "       CDA.IC_CACAU IC_CACAU_PAG, CDA.IC_MOEDA IC_MOEDA_PAG, "
                SqlText = SqlText & "       CDA.IC_OUTROS IC_OUTROS_PAG, CDA.DS_OUTROS DS_OUTROS_PAG, CDA.VL_ATIVO, "
                SqlText = SqlText & "       CDA.QT_ITEM_ATIVO, "
                SqlText = SqlText & "          CDM.NO_CONFISSAO_DIVIDA_MODALIDADE "
                SqlText = SqlText & "       || DECODE (CD.IC_COBRA_JUROS, 'S', '-JUROS', '') "
                SqlText = SqlText & "                                            AS NO_CONFISSAO_DIVIDA_MODALIDADE "
                SqlText = SqlText & "  FROM SOF.CONFISSAO_DIVIDA CD, "
                SqlText = SqlText & "       SOF.CONFISSAO_DIVIDA_PARCELA CDP, "
                SqlText = SqlText & "       SOF.CONFISSAO_DIVIDA_ATIVO CDA, "
                SqlText = SqlText & "       SOF.FORNECEDOR F, "
                SqlText = SqlText & "       SOF.FILIAL FIL, "
                SqlText = SqlText & "       SOF.CONFISSAO_DIVIDA_MODALIDADE CDM "
                SqlText = SqlText & " WHERE F.CD_FORNECEDOR = CD.CD_FORNECEDOR "
                SqlText = SqlText & "   AND FIL.CD_FILIAL = CD.CD_FILIAL_ORIGEM "
                SqlText = SqlText & "   AND CD.SQ_CONFISSAO_DIVIDA = CDP.SQ_CONFISSAO_DIVIDA(+) "
                SqlText = SqlText & "   AND CDP.SQ_CONFISSAO_DIVIDA = CDA.SQ_CONFISSAO_DIVIDA(+) "
                SqlText = SqlText & "   AND CDP.NU_PARCELA = CDA.NU_PARCELA(+) "
                SqlText = SqlText & "   AND CD.CD_CONFISSAO_DIVIDA_MODALIDADE = CDM.CD_CONFISSAO_DIVIDA_MODALIDADE "
                SqlText = SqlText & "   AND CD.IC_STATUS = 'A' "

                oRelatorio.Load(Application.StartupPath & "\RPT_RecCredito_Analitico.rpt")

        End Select

        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & "     AND cd.cd_filial_origem IN (" & ListagemFilial & ")"
            sFiltro = sFiltro & " - Filial: " & MontaFiltro_Filial(ListagemFilial)
        Else
            SqlText = SqlText & "     AND CD.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If
        If Trim(ListagemModalidade) <> "" Then
            SqlText = SqlText & "     AND CD.CD_CONFISSAO_DIVIDA_MODALIDADE IN (" & ListagemModalidade & ")"
            SqlText_Aux = "SELECT TRIM(NO_CONFISSAO_DIVIDA_MODALIDADE) FROM SOF.CONFISSAO_DIVIDA_MODALIDADE WHERE CD_CONFISSAO_DIVIDA_MODALIDADE IN (" & ListagemModalidade & ")"
            sFiltro = sFiltro & " - Modalidade: " & DBQuery_ValorUnico_Lista(SqlText_Aux)
        End If
        If Vencidas Then
            SqlText = SqlText & " AND CDP.DT_VENCIMENTO < SYSDATE AND CDP.IC_SITUACAO = 'A'"
            sFiltro = sFiltro & " - Apenas Parcelas Vencidas "
        End If

        If Sintetico Then
            SqlText = SqlText & " GROUP BY CD.SQ_CONFISSAO_DIVIDA, "
            SqlText = SqlText & "         CD.DT_CONFISSAO_DIVIDA, "
            SqlText = SqlText & "         CD.CD_FORNECEDOR, "
            SqlText = SqlText & "         F.NO_RAZAO_SOCIAL, "
            SqlText = SqlText & "         CD.VL_ORIGINAL, "
            SqlText = SqlText & "         CD.QT_ORIGINAL, "
            SqlText = SqlText & "         CD.VL_NEGOCIADO, "
            SqlText = SqlText & "         CD.CD_FILIAL_ORIGEM, "
            SqlText = SqlText & "         FIL.NO_FILIAL, "
            SqlText = SqlText & "         CDM.NO_CONFISSAO_DIVIDA_MODALIDADE "
        End If

        oData = DBQuery(SqlText)

        '==>sub relatorio contratos
        If Not Sintetico Then
            SqlText = "SELECT   cd_contrato_paf, sq_negociacao, sq_contrato_fixo, "
            SqlText = SqlText & "         sq_confissao_divida, SUM (vl_fixo) vl_fixo, "
            SqlText = SqlText & "         SUM (qt_cancelado) qt_cancelado "
            SqlText = SqlText & "    FROM (SELECT cpc.cd_contrato_paf, cfc.sq_negociacao, cfc.sq_contrato_fixo, "
            SqlText = SqlText & "                 0 vl_fixo, "
            SqlText = SqlText & "                 NVL (cfc.qt_cancelado, cpc.qt_cancelado) qt_cancelado, "
            SqlText = SqlText & "                 NVL (cfc.sq_confissao_divida, "
            SqlText = SqlText & "                      cpc.sq_confissao_divida "
            SqlText = SqlText & "                     ) sq_confissao_divida "
            SqlText = SqlText & "            FROM sof.contrato_paf_cancelado cpc, "
            SqlText = SqlText & "                 sof.contrato_fixo_cancelado cfc, "
            SqlText = SqlText & "                 sof.confissao_divida cd "
            SqlText = SqlText & "           WHERE cpc.cd_contrato_paf = cfc.cd_contrato_paf(+) "
            SqlText = SqlText & "             AND cpc.sq_confissao_divida = cd.sq_confissao_divida "
            SqlText = SqlText & "             AND cd.ic_status = 'A' "

            If Trim(ListagemFilial) <> "" Then
                SqlText = SqlText & "     AND CD.CD_FILIAL_ORIGEM IN (" & ListagemFilial & ")"
                sFiltro = sFiltro & " - Filial: " & MontaFiltro_Filial(ListagemFilial)
            End If
            If Trim(ListagemModalidade) <> "" Then
                SqlText = SqlText & "     AND cd.CD_CONFISSAO_DIVIDA_MODALIDADE IN (" & ListagemModalidade & ")"
                SqlText_Aux = "SELECT TRIM(NO_CONFISSAO_DIVIDA_MODALIDADE) FROM SOF.CONFISSAO_DIVIDA_MODALIDADE WHERE CD_CONFISSAO_DIVIDA_MODALIDADE IN (" & ListagemModalidade & ")"
                sFiltro = sFiltro & " - Modalidade: " & DBQuery_ValorUnico_Lista(SqlText)
            End If

            SqlText = SqlText & "          UNION ALL "
            SqlText = SqlText & "          SELECT pcp.cd_contrato_paf, pncf.sq_negociacao, "
            SqlText = SqlText & "                 pncf.sq_contrato_fixo, "
            SqlText = SqlText & "                 0 - NVL (pncf.vl_fixo, pcp.vl_fixo) vl_fixo, 0 qt_cancelado, "
            SqlText = SqlText & "                 NVL (pncf.sq_confissao_divida, "
            SqlText = SqlText & "                      pcp.sq_confissao_divida "
            SqlText = SqlText & "                     ) sq_confissao_divida "
            SqlText = SqlText & "            FROM sof.pag_ctr_paf pcp, "
            SqlText = SqlText & "                 sof.pag_neg_ctr_fix pncf, "
            SqlText = SqlText & "                 sof.pagamentos p, "
            SqlText = SqlText & "                 sof.confissao_divida cd "
            SqlText = SqlText & "           WHERE pcp.cd_contrato_paf = pncf.cd_contrato_paf(+) "
            SqlText = SqlText & "             AND pcp.sq_pagamento = pncf.sq_pagamento(+) "
            SqlText = SqlText & "             AND pcp.sq_pag_ctr_paf = pncf.sq_pag_ctr_paf(+) "
            SqlText = SqlText & "             AND pcp.sq_pagamento = p.sq_pagamento "
            SqlText = SqlText & "             AND p.sq_conf_div_ativo_venda IS NULL "
            SqlText = SqlText & "             AND pcp.ic_confissao_divida_estorno = 'S' "
            SqlText = SqlText & "             AND pcp.sq_confissao_divida = cd.sq_confissao_divida "
            SqlText = SqlText & "             AND cd.ic_status = 'A' "

            If Trim(ListagemFilial) <> "" Then
                SqlText = SqlText & "     AND cd.cd_filial_origem IN (" & ListagemFilial & ")"
                sFiltro = sFiltro & " - Filial: " & MontaFiltro_Filial(ListagemFilial)
            End If
            If Trim(ListagemModalidade) <> "" Then
                SqlText = SqlText & "     AND cd.CD_CONFISSAO_DIVIDA_MODALIDADE IN (" & ListagemModalidade & ")"
                SqlText_Aux = "SELECT TRIM(NO_CONFISSAO_DIVIDA_MODALIDADE) FROM SOF.CONFISSAO_DIVIDA_MODALIDADE WHERE CD_CONFISSAO_DIVIDA_MODALIDADE IN (" & ListagemModalidade & ")"
                sFiltro = sFiltro & " - Modalidade: " & DBQuery_ValorUnico_Lista(SqlText)
            End If

            SqlText = SqlText & ") GROUP BY cd_contrato_paf, sq_negociacao, sq_contrato_fixo, "
            SqlText = SqlText & "         sq_confissao_divida "

            oData_Sub1 = DBQuery(SqlText)

            oRelatorio.SetDataSource(oData)
            oRelatorio_Sub1 = oRelatorio.Subreports("CRContrato")
            oRelatorio_Sub1.SetDataSource(oData_Sub1)
        Else
            oRelatorio.SetDataSource(oData)
        End If

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_PrevisaoBonus(ByVal TaxaDolar As Double, _
                                                 ByVal DataInicial As String, _
                                                 ByVal DataFinal As String, _
                                                 ByVal Fornecedor As Integer, _
                                                 ByVal ListagemFilial As String, _
                                                 ByVal Tipo As String, _
                                                 ByVal Nivel As String) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim SqlText_Aux As String = ""
        Dim sFiltro As String = ""

        SqlText = "SELECT f.cd_filial_origem, fil.no_filial, cp.cd_fornecedor, f.no_razao_social, "
        SqlText = SqlText & "       bcf.cd_contrato_paf, bcf.sq_negociacao, bcf.sq_contrato_fixo, "
        SqlText = SqlText & "       bcf.vl_unitario_bonus, bcf.qt_fator_bonus, bp.no_bonus_padrao, "
        SqlText = SqlText & "       bcf.qt_umidade_media, bcf.pc_sujidade_media, bcf.qt_peso_amendoa_media, "
        SqlText = SqlText & "       bcf.qt_mofo_media, bcf.qt_fumaca_media, bcf.qt_ardosia_media, "
        SqlText = SqlText & "       bcf.qt_achatada_media, bcf.ic_tipo_cacau_media, bcf.dt_concessao, "
        SqlText = SqlText & "       " & TaxaDolar & " vl_taxa_us, m.nu_nf, m.dt_movimentacao, tm.no_tipo_movimentacao, "
        SqlText = SqlText & "       cm.qt_kg_fixo, m.sq_movimentacao, cm.sq_ctr_paf_movimentacao, "
        SqlText = SqlText & "       cm.sq_ctr_paf_neg_movimentacao, cm.sq_ctr_paf_neg_ctr_fix_mov, "
        SqlText = SqlText & "       cm.sq_movimentacao_cessao_direito "
        SqlText = SqlText & "  FROM sof.bonus_contrato_fixo bcf, "
        SqlText = SqlText & "       sof.bonus_padrao bp, "
        SqlText = SqlText & "       sof.ctr_paf_neg_ctr_fix_mov cm, "
        SqlText = SqlText & "       sof.contrato_paf cp, "
        SqlText = SqlText & "       sof.filial fil, "
        SqlText = SqlText & "       sof.fornecedor f, "
        SqlText = SqlText & "       sof.movimentacao m, "
        SqlText = SqlText & "       sof.tipo_movimentacao tm, "
        SqlText = SqlText & "       sof.municipio munic "
        SqlText = SqlText & " WHERE bp.cd_bonus_padrao = bcf.cd_bonus_padrao "
        SqlText = SqlText & "   AND cm.sq_movimentacao = bcf.sq_movimentacao "
        SqlText = SqlText & "   AND cm.sq_movimentacao_cessao_direito = bcf.sq_movimentacao_cessao_direito "
        SqlText = SqlText & "   AND cm.cd_contrato_paf = bcf.cd_contrato_paf "
        SqlText = SqlText & "   AND cm.sq_ctr_paf_movimentacao = bcf.sq_ctr_paf_movimentacao "
        SqlText = SqlText & "   AND cm.sq_negociacao = bcf.sq_negociacao "
        SqlText = SqlText & "   AND cm.sq_ctr_paf_neg_movimentacao = bcf.sq_ctr_paf_neg_movimentacao "
        SqlText = SqlText & "   AND cm.sq_contrato_fixo = bcf.sq_contrato_fixo "
        SqlText = SqlText & "   AND cm.sq_ctr_paf_neg_ctr_fix_mov = bcf.sq_ctr_paf_neg_ctr_fix_mov "
        SqlText = SqlText & "   AND cp.cd_contrato_paf = cm.cd_contrato_paf "
        SqlText = SqlText & "   AND f.cd_fornecedor = cp.cd_fornecedor "
        SqlText = SqlText & "   AND fil.cd_filial = f.cd_filial_origem "
        SqlText = SqlText & "   AND m.sq_movimentacao = cm.sq_movimentacao "
        SqlText = SqlText & "   AND m.cd_tipo_movimentacao = tm.cd_tipo_movimentacao "
        SqlText = SqlText & "   AND f.cd_municipio = munic.cd_municipio "
        SqlText = SqlText & "   AND munic.cd_uf <> 'EX' "
        SqlText = SqlText & "   AND bcf.dt_concessao BETWEEN " & QuotedStr(Date_to_Oracle(DataInicial)) & " AND " & QuotedStr(Date_to_Oracle(DataFinal))

        sFiltro = "Período: " & DataInicial & " à " & DataFinal

        If Fornecedor <> 0 Then
            SqlText = SqlText & " AND m.cd_fornecedor = " & Fornecedor
            sFiltro = "- Fornecedor: " & MontaFiltro_Fornecedor(Fornecedor)
        End If
        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & ListagemFilial & ")"
            sFiltro = "- Filial: " & MontaFiltro_Filial(ListagemFilial)
        Else
            SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        Select Case Tipo
            Case "A"
                SqlText = SqlText & " AND BCF.IC_PAGO= 'N'"
                sFiltro = "- A Provisionar "
            Case "P"
                SqlText = SqlText & " AND BCF.IC_PAGO= 'S'"
                sFiltro = "- Provisionado "
            Case "C"
                SqlText = SqlText & " AND BCF.IC_PAGO= 'C'"
                sFiltro = "- Cancelado "
        End Select

        oData = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_Bonus_Previsao.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        oRelatorio.SetParameterValue("Nivel", Nivel)

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_PagamentoEmAberto(ByVal ListagemFilial As String, _
                                                     ByVal Fornecedor As Integer, _
                                                     ByVal AbertoContratoPAF As Boolean, _
                                                     ByVal AbertoNegociacao As Boolean, _
                                                     ByVal AgrupaFornecedor As Boolean, _
                                                     ByVal SemContrato As Boolean, _
                                                     ByVal Sintetico As Boolean, _
                                                     Optional ByRef QtdeRegistro As Integer = 0 _
                                                     ) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim SqlText_Aux As String = ""
        Dim SqlFiltro As String = ""
        Dim sFiltro As String = ""

        If Trim(ListagemFilial) <> "" Then
            SqlFiltro = SqlFiltro & "     AND F.CD_FILIAL_ORIGEM IN (" & ListagemFilial & ")"
            sFiltro = sFiltro & " - Filial: " & MontaFiltro_Filial(ListagemFilial)
        Else
            SqlFiltro = SqlFiltro & "     AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If
        If Fornecedor > 0 Then
            SqlFiltro = SqlFiltro & " AND F.CD_FORNECEDOR = " & Fornecedor
            sFiltro = sFiltro & " - Fornecedor: " & MontaFiltro_Fornecedor(Fornecedor)
        End If

        If AbertoContratoPAF Then
            SqlText = "SELECT /*+ ORDERED INDEX (f SYS_C004218) USE_NL (p) */ "
            SqlText = SqlText & "       'Abertos no Contrato PAF' AS tipo, p.cd_filial_origem, fil.no_filial, "
            SqlText = SqlText & "       f.no_razao_social, p.dt_pagamento, p.ds_descricao, "
            SqlText = SqlText & "       sum(pcp.vl_a_fixar) vl_pagamento, "
            SqlText = SqlText & "       sum(ROUND (DECODE (p.vl_taxa_dolar, "
            SqlText = SqlText & "                      NULL, 0, "
            SqlText = SqlText & "                      pcp.vl_a_fixar / p.vl_taxa_dolar "
            SqlText = SqlText & "                     ), "
            SqlText = SqlText & "              2 "
            SqlText = SqlText & "             )) vl_dolar, "
            SqlText = SqlText & "       NVL (p.vl_taxa_dolar, 0) vl_taxa_dolar, fp.no_forma_pagamento, "
            SqlText = SqlText & "       p.cd_tipo_pagamento, tp.no_tipo_pagamento, "
            SqlText = SqlText & "       p.ic_icms AS ic_pagamento_icms, pcp.cd_contrato_paf, -1 sq_negociacao, "
            SqlText = SqlText & "       p.sq_pagamento, cp.DT_PRAZO_FIXACAO dt_vencimento, TO_DATE (" & QuotedStr(Date_to_Oracle(DataSistema)) & ") AS dt_hoje, "
            SqlText = SqlText & "       rep.cd_fornecedor AS cd_repassador, "
            SqlText = SqlText & "       rep.no_razao_social AS no_repassador, f.cd_fornecedor "

            If AgrupaFornecedor Then
                SqlText = SqlText & "  ,f.cd_fornecedor ||'-'|| f.no_razao_social grupo01 "
            Else
                SqlText = SqlText & "  ,'' grupo01 "
            End If

            SqlText = SqlText & "  FROM sof.pag_ctr_paf pcp, "
            SqlText = SqlText & "       sof.pagamentos p, "
            SqlText = SqlText & "       sof.fornecedor f, "
            SqlText = SqlText & "       sof.forma_pagamento fp, "
            SqlText = SqlText & "       sof.filial fil, "
            SqlText = SqlText & "       sof.tipo_pagamento tp, "
            SqlText = SqlText & "       sof.contrato_paf cp, "
            SqlText = SqlText & "       sof.fornecedor rep "
            SqlText = SqlText & " WHERE p.cd_fornecedor = f.cd_fornecedor "
            SqlText = SqlText & "   AND f.cd_filial_origem = fil.cd_filial "
            SqlText = SqlText & "   AND p.cd_forma_pagamento = fp.cd_forma_pagamento "
            SqlText = SqlText & "   AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
            SqlText = SqlText & "   AND p.sq_pagamento = pcp.sq_pagamento "
            SqlText = SqlText & "   AND pcp.cd_contrato_paf = cp.cd_contrato_paf "
            SqlText = SqlText & "   AND cp.cd_repassador = rep.cd_fornecedor "
            SqlText = SqlText & "   AND pcp.vl_a_fixar <> 0 "

            SqlText = SqlText & SqlFiltro

            SqlText = SqlText & " GROUP BY p.cd_filial_origem, "
            SqlText = SqlText & "         fil.no_filial, "
            SqlText = SqlText & "         f.no_razao_social, "
            SqlText = SqlText & "         p.dt_pagamento, "
            SqlText = SqlText & "         p.ds_descricao, "
            SqlText = SqlText & "         NVL (p.vl_taxa_dolar, 0), "
            SqlText = SqlText & "         fp.no_forma_pagamento, "
            SqlText = SqlText & "         p.cd_tipo_pagamento, "
            SqlText = SqlText & "         tp.no_tipo_pagamento, "
            SqlText = SqlText & "         p.ic_icms, "
            SqlText = SqlText & "         pcp.cd_contrato_paf, "
            SqlText = SqlText & "         p.sq_pagamento, "
            SqlText = SqlText & "         cp.DT_PRAZO_FIXACAO , "
            SqlText = SqlText & "         TO_DATE ('30-APR-2008'), "
            SqlText = SqlText & "         rep.cd_fornecedor, "
            SqlText = SqlText & "         rep.no_razao_social, "
            SqlText = SqlText & "         f.cd_fornecedor, "
            SqlText = SqlText & "         cp.ic_calcula_juros, "
            SqlText = SqlText & "         tp.ic_calcula_juros, "
            SqlText = SqlText & "         cp.pc_taxa_juros, "
            SqlText = SqlText & "         cp.qt_dia_carencia_juros, "
            SqlText = SqlText & "         cp.ic_juros_apos_carencia "
            SqlText = SqlText & "  HAVING SUM (pcp.vl_a_fixar) <> 0 "
        End If

        If AbertoNegociacao Then
            If Trim(SqlText) <> "" Then SqlText = SqlText & "UNION ALL "

            SqlText = SqlText & "SELECT /*+ ORDERED USE_NL (p) */ "
            SqlText = SqlText & "       'Abertos na Negociação' AS tipo, f.cd_filial_origem, fil.no_filial, "
            SqlText = SqlText & "       f.no_razao_social, p.dt_pagamento, p.ds_descricao, "
            SqlText = SqlText & "       pn.vl_a_fixar vl_pagamento, "
            SqlText = SqlText & "       ROUND (DECODE (p.vl_taxa_dolar, "
            SqlText = SqlText & "                      NULL, 0, "
            SqlText = SqlText & "                      pn.vl_a_fixar / p.vl_taxa_dolar "
            SqlText = SqlText & "                     ), "
            SqlText = SqlText & "              2 "
            SqlText = SqlText & "             ) vl_dolar, "
            SqlText = SqlText & "       NVL (p.vl_taxa_dolar, 0) vl_taxa_dolar, fp.no_forma_pagamento, "
            SqlText = SqlText & "       p.cd_tipo_pagamento, tp.no_tipo_pagamento, "
            SqlText = SqlText & "       p.ic_icms AS ic_pagamento_icms, pn.cd_contrato_paf, pn.sq_negociacao, "
            SqlText = SqlText & "       p.sq_pagamento, n.DT_PRAZO_FIXACAO dt_vencimento, TO_DATE (" & QuotedStr(Date_to_Oracle(DataSistema)) & ") AS dt_hoje, "
            SqlText = SqlText & "       rep.cd_fornecedor AS cd_repassador, "
            SqlText = SqlText & "       rep.no_razao_social AS no_repassador, f.cd_fornecedor "

            If AgrupaFornecedor Then
                SqlText = SqlText & "  ,f.cd_fornecedor ||'-'|| f.no_razao_social grupo01 "
            Else
                SqlText = SqlText & "  ,'' grupo01 "
            End If

            SqlText = SqlText & "  FROM sof.pag_neg pn, "
            SqlText = SqlText & "       sof.pagamentos p, "
            SqlText = SqlText & "       sof.fornecedor f, "
            SqlText = SqlText & "       sof.forma_pagamento fp, "
            SqlText = SqlText & "       sof.filial fil, "
            SqlText = SqlText & "       sof.tipo_pagamento tp, "
            SqlText = SqlText & "       sof.negociacao n, "
            SqlText = SqlText & "       sof.contrato_paf cp, "
            SqlText = SqlText & "       sof.fornecedor rep "
            SqlText = SqlText & " WHERE p.cd_fornecedor = f.cd_fornecedor "
            SqlText = SqlText & "   AND f.cd_filial_origem = fil.cd_filial "
            SqlText = SqlText & "   AND p.cd_forma_pagamento = fp.cd_forma_pagamento "
            SqlText = SqlText & "   AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
            SqlText = SqlText & "   AND p.sq_pagamento = pn.sq_pagamento "
            SqlText = SqlText & "   AND pn.cd_contrato_paf = n.cd_contrato_paf "
            SqlText = SqlText & "   AND pn.sq_negociacao = n.sq_negociacao "
            SqlText = SqlText & "   AND n.cd_contrato_paf = cp.cd_contrato_paf "
            SqlText = SqlText & "   AND cp.cd_repassador = rep.cd_fornecedor "
            SqlText = SqlText & "   AND pn.vl_a_fixar <> 0 "

            SqlText = SqlText & SqlFiltro
        End If

        If SemContrato Then
            If Trim(SqlText) <> "" Then SqlText = SqlText & "UNION ALL "

            SqlText = SqlText & "SELECT 'Sem Contrato' AS tipo, f.cd_filial_origem, fil.no_filial, "
            SqlText = SqlText & "       f.no_razao_social, p.dt_pagamento, p.ds_descricao, "
            SqlText = SqlText & "       p.vl_a_fixar AS vl_pagamento, "
            SqlText = SqlText & "       ROUND (DECODE (p.vl_taxa_dolar, "
            SqlText = SqlText & "                      NULL, 0, "
            SqlText = SqlText & "                      p.vl_a_fixar / p.vl_taxa_dolar "
            SqlText = SqlText & "                     ), "
            SqlText = SqlText & "              2 "
            SqlText = SqlText & "             ) vl_dolar, "
            SqlText = SqlText & "       NVL (p.vl_taxa_dolar, 0) vl_taxa_dolar, fp.no_forma_pagamento, "
            SqlText = SqlText & "       p.cd_tipo_pagamento, tp.no_tipo_pagamento, "
            SqlText = SqlText & "       p.ic_icms AS ic_pagamento_icms, -1 AS cd_contrato_paf, "
            SqlText = SqlText & "       -1 AS sq_negociacao, p.sq_pagamento, SYSDATE dt_vencimento, "
            SqlText = SqlText & "       TO_DATE (" & QuotedStr(Date_to_Oracle(DataSistema)) & ") AS dt_hoje, rep.cd_fornecedor AS cd_repassador, "
            SqlText = SqlText & "       rep.no_razao_social AS no_repassador, f.cd_fornecedor "

            If AgrupaFornecedor Then
                SqlText = SqlText & "  ,f.cd_fornecedor ||'-'|| f.no_razao_social grupo01 "
            Else
                SqlText = SqlText & "  ,'' grupo01 "
            End If

            SqlText = SqlText & "  FROM sof.pagamentos p, "
            SqlText = SqlText & "       sof.fornecedor f, "
            SqlText = SqlText & "       sof.filial fil, "
            SqlText = SqlText & "       sof.forma_pagamento fp, "
            SqlText = SqlText & "       sof.tipo_pagamento tp, "
            SqlText = SqlText & "       sof.fornecedor rep "
            SqlText = SqlText & " WHERE p.cd_fornecedor = f.cd_fornecedor "
            SqlText = SqlText & "   AND f.cd_filial_origem = fil.cd_filial "
            SqlText = SqlText & "   AND p.cd_forma_pagamento = fp.cd_forma_pagamento "
            SqlText = SqlText & "   AND p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
            SqlText = SqlText & "   AND p.vl_a_fixar <> 0 "
            SqlText = SqlText & "   AND f.cd_repassador = rep.cd_fornecedor(+) "

            SqlText = SqlText & SqlFiltro
        End If

        oData = DBQuery(SqlText)

        QtdeRegistro = oData.Rows.Count

        oRelatorio.Load(Application.StartupPath & "\RPT_Pagamento_Aberto.rpt")
        oRelatorio.SetDataSource(oData)

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        If AgrupaFornecedor Or Sintetico Then
            oRelatorio.SetParameterValue("AgrupadoFornecedor", "S")
        Else
            oRelatorio.SetParameterValue("AgrupadoFornecedor", "N")
        End If

        oRelatorio.SetParameterValue("Tipo", IIf(Sintetico, "S", "A"))

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_AmarracaoICMS(ByVal DataInicial As String, _
                                                 ByVal DataFinal As String, _
                                                 ByVal Fornecedor As Integer, _
                                                 ByVal ListagemFilial As String, _
                                                 ByVal CD_Opcao As String, _
                                                 ByVal DS_Opcao As String, _
                                                 ByVal Saldo As Boolean, _
                                                 ByVal Sintetico As Boolean) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable
        Dim SqlText As String
        Dim SqlText_Aux As String
        Dim sFiltro As String = ""

        'AMARRAÇÕES
        SqlText = "SELECT  f.no_razao_social, m.nu_nf, trunc(m.dt_movimentacao) dt_movimentacao, m.vl_nf, "
        SqlText = SqlText & "       nvl(sum(pa.vl_aplicacao ),0) AS vl_icms, trunc(max(p.dt_pagamento)) as dt_pagamento, 'A' cd_tp, "
        SqlText = SqlText & "       trunc(pa.dt_amarracao) dt_amarracao, "
        SqlText = SqlText & "       CAST (NULL AS VARCHAR2 (100)) ds_descricao, nvl(round(((nvl(ms.VL_A_FIXAR,0) + nvl(mns.VL_A_FIXAR,0)) *SUM (nvl(pa.vl_aplicacao,0))) /m.vl_nf,2) ,0) as Saldo_Aplicar "
        SqlText = SqlText & "  FROM sof.pagamentos p, "
        SqlText = SqlText & "       sof.movimentacao m, "
        SqlText = SqlText & "       sof.fornecedor f, "
        SqlText = SqlText & "       sof.conciliacao c, "
        SqlText = SqlText & "       sof.pag_amarracao_icms pa, "
        SqlText = SqlText & "        (SELECT   cm.sq_movimentacao, SUM (cm.vl_a_fixar) AS vl_a_fixar"
        SqlText = SqlText & "            FROM sof.ctr_paf_movimentacao cm"
        SqlText = SqlText & "           Where cm.vl_a_fixar <> 0"
        SqlText = SqlText & "        GROUP BY cm.sq_movimentacao) ms,"
        SqlText = SqlText & "        (SELECT   cm.sq_movimentacao, SUM (cm.vl_a_fixar) AS vl_a_fixar"
        SqlText = SqlText & "            FROM sof.ctr_paf_neg_movimentacao cm"
        SqlText = SqlText & "           Where cm.vl_a_fixar <> 0"
        SqlText = SqlText & "        GROUP BY cm.sq_movimentacao) mns,"
        SqlText = SqlText & "       (SELECT   p.sq_movimentacao, max(cm.vl_aplicacao) AS vl_conciliado"
        SqlText = SqlText & "         FROM (SELECT   sq_movimentacao, SUM (vl_aplicacao)"
        SqlText = SqlText & "                                                            AS vl_aplicacao"
        SqlText = SqlText & "                   FROM sof.conciliacao_movimentacao"
        SqlText = SqlText & "                GROUP BY sq_movimentacao) cm,"
        SqlText = SqlText & "         sof.pag_amarracao_icms p"
        SqlText = SqlText & "   WHERE  cm.sq_movimentacao = p.sq_movimentacao "
        SqlText = SqlText & " GROUP BY p.sq_movimentacao) mcs"
        SqlText = SqlText & " Where pa.Sq_Movimentacao = m.Sq_Movimentacao "
        SqlText = SqlText & "   and pa.sq_pagamento =p.sq_pagamento "
        SqlText = SqlText & "   AND p.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "   AND pa.sq_conciliacao  = c.sq_conciliacao "
        SqlText = SqlText & "   and m.SQ_MOVIMENTACAO =ms.SQ_MOVIMENTACAO (+) "
        SqlText = SqlText & "   and m.SQ_MOVIMENTACAO =mns.SQ_MOVIMENTACAO (+) "
        SqlText = SqlText & "   and m.SQ_MOVIMENTACAO =mcs.SQ_MOVIMENTACAO (+) "

        '==>Filtros Amarração
        If IsDate(DataInicial) Then
            SqlText = SqlText & " AND TRUNC( c.dt_conciliacao ) >= " & QuotedStr(Date_to_Oracle(DataInicial))
            sFiltro = "- Data Inicial : " & DataInicial
        End If
        If IsDate(DataFinal) Then
            SqlText = SqlText & " AND TRUNC( c.dt_conciliacao ) <= " & QuotedStr(Date_to_Oracle(DataFinal))
            sFiltro = "- Data Final : " & DataFinal
        End If
        If Fornecedor <> 0 Then
            SqlText = SqlText & " AND P.CD_FORNECEDOR = " & Fornecedor
            sFiltro = sFiltro & " - Fornecedor: " & MontaFiltro_Fornecedor(Fornecedor)
        End If
        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListagemFilial & ")"
            sFiltro = sFiltro & " - Filial: " & MontaFiltro_Filial(ListagemFilial)
        Else
            SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If


        '==>GROUP BY AMARRAÇÃO
        SqlText = SqlText & " group by f.no_razao_social, m.nu_nf, m.dt_movimentacao, m.vl_nf," & _
                "pa.dt_amarracao,ms.VL_A_FIXAR,mns.vl_a_fixar , mcs.vl_conciliado "

        '==>Se quiser só com saldo não puxa pagamentos em aberto
        If Saldo Then
            SqlText = SqlText & " having nvl(round(((nvl(ms.VL_A_FIXAR,0) + nvl(mns.VL_A_FIXAR,0)+ nvl(mcs.vl_conciliado,0)) *SUM (nvl(pa.vl_aplicacao,0))) /m.vl_nf,2) ,0) >0 "
            sFiltro = sFiltro & " - Apenas com Saldo "
        Else
            'PAGAMENTO SEM NF
            SqlText = SqlText & "UNION ALL "
            SqlText = SqlText & "SELECT f.no_razao_social, '' nu_nf, CAST (NULL AS DATE) dt_movimentacao, "
            SqlText = SqlText & "       CAST (0 AS NUMBER) vl_nf, pc.vl_a_fixar AS vl_icms, p.dt_pagamento, "
            SqlText = SqlText & "       'P' cd_tp,CAST (NULL AS DATE) dt_amarracao, p.ds_descricao,CAST (0 AS NUMBER) Saldo_Aplicar  "
            SqlText = SqlText & "  FROM sof.pagamentos p, sof.fornecedor f, sof.pag_ctr_paf pc "
            SqlText = SqlText & " WHERE p.cd_fornecedor = f.cd_fornecedor and p.sq_pagamento =pc.sq_pagamento "
            SqlText = SqlText & "   AND p.ic_icms = 'S' "
            SqlText = SqlText & "   AND p.ic_icms_pago = 'N' "

            '==>FILTROS PAGAMENTO SEM NF
            If IsDate(DataInicial) Then
                SqlText = SqlText & " AND TRUNC( p.dt_pagamento) >= " & QuotedStr(Date_to_Oracle(DataInicial))
            End If
            If IsDate(DataFinal) Then
                SqlText = SqlText & " AND TRUNC( p.dt_pagamento ) <= " & QuotedStr(Date_to_Oracle(DataFinal))
            End If
            If Fornecedor <> 0 Then
                SqlText = SqlText & " AND P.CD_FORNECEDOR = " & Fornecedor
            End If
            If Trim(ListagemFilial) <> "" Then
                SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & ListagemFilial & ")"
            Else
                SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If

            'NF SEM PAGAMENTO
            SqlText = SqlText & "UNION ALL "
            SqlText = SqlText & "SELECT f.no_razao_social, m.nu_nf, m.dt_movimentacao, m.vl_nf, "
            SqlText = SqlText & "       m.vl_nf_icms AS vl_icms, CAST (NULL AS DATE) dt_pagamento, 'M' cd_tp, CAST (NULL AS DATE) dt_amarracao, CAST (NULL AS varchar2(100)) ds_descricao,CAST (0 AS NUMBER) Saldo_Aplicar "
            SqlText = SqlText & "  FROM sof.movimentacao m, sof.fornecedor f "
            SqlText = SqlText & " WHERE m.cd_fornecedor = f.cd_fornecedor "
            SqlText = SqlText & "   AND m.ic_icms_pago = 'N' "
            SqlText = SqlText & "   AND m.vl_nf_icms > 0 "

            '==>FILTROS NF SEM PAGAMENTO
            If IsDate(DataInicial) Then
                SqlText = SqlText & " AND TRUNC( m.dt_movimentacao) >= " & QuotedStr(Date_to_Oracle(DataInicial))
            End If
            If IsDate(DataFinal) Then
                SqlText = SqlText & " AND TRUNC( m.dt_movimentacao ) <= " & QuotedStr(Date_to_Oracle(DataFinal))
            End If
            If Fornecedor <> 0 Then
                SqlText = SqlText & " AND m.cd_fornecedor = " & Fornecedor
            End If
            If Trim(ListagemFilial) <> "" Then
                SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & ListagemFilial & ")"
            Else
                SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If
        End If

        'Filtro opçoes
        If Trim(CD_Opcao) <> "" Then
            SqlText = "SELECT * FROM (" & SqlText & ") WHERE CD_TP IN (" & CD_Opcao & ")"
            sFiltro = "- Opções : " & DS_Opcao
        End If

        oData = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_Amarracao_ICMS.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        oRelatorio.SetParameterValue("Tipo", IIf(Sintetico, "S", "A"))

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_PosicaoFornecedor(ByVal Bolsa As Double, _
                                                     ByVal Dolar As Double, _
                                                     ByVal ValorArroba As Double, _
                                                     ByVal AgruparTitular As Boolean, _
                                                     ByVal PorSafra As Boolean, _
                                                     ByVal ListagemSafra As String, _
                                                     ByRef Fornecedor As Integer, _
                                                     ByVal TodosContratosAberto As Boolean, _
                                                     ByVal OpcaoTitular As Boolean) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim SqlText As String
        Dim oData As DataTable
        Dim oDataSub1 As DataTable
        Dim oDataSub2 As DataTable
        Dim oRelatorio_Sub1 As New ReportDocument
        Dim oRelatorio_Sub2 As New ReportDocument
        Dim sFiltro As String
        Dim blTitular As Boolean

        SqlText = "SELECT COUNT(*) QT" & _
                  " FROM SOF.FORNECEDOR" & _
                  " WHERE CD_REPASSADOR = " & Fornecedor

        If DBQuery_ValorUnico(SqlText) = 0 Then
            blTitular = False
        Else
            blTitular = True
        End If

        If blTitular = False Then
            SqlText = "SELECT CD_REPASSADOR" & _
                      " FROM SOF.FORNECEDOR" & _
                      " WHERE CD_FORNECEDOR = " & Fornecedor

            If DBQuery_ValorUnico(SqlText, -1) <> -1 Then
                Fornecedor = DBQuery_ValorUnico(SqlText)
                blTitular = True
            End If
        End If

        oData = Gera_Rs_Posicao_Fornecedor(Bolsa, _
                                           Dolar, _
                                           ValorArroba, _
                                           blTitular, _
                                           oDataSub1, _
                                           oDataSub2, _
                                           AgruparTitular, _
                                           PorSafra, _
                                           ListagemSafra, _
                                           Fornecedor)

        oRelatorio.Load(Application.StartupPath & "\RPT_Posicao_Fornecedor.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio_Sub1 = oRelatorio.Subreports("CRCredito")
        oRelatorio_Sub1.SetDataSource(oDataSub1)
        oRelatorio_Sub2 = oRelatorio.Subreports("CRBonus")
        oRelatorio_Sub2.SetDataSource(oDataSub2)

        sFiltro = "Bolsa US$: " & VB.Format(Bolsa, "#,##0") & " - " & _
                  "Dolar R$: " & VB.Format(Dolar, "#,##0.0000") & " - " & _
                  "Preço Medio @ R$: " & VB.Format(ValorArroba, "#,##0.00")

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        If blTitular Then
            oRelatorio.SetParameterValue("PorTitular", 1)
            oRelatorio.SetParameterValue("Titulo", "Posição do Titular")
        Else
            oRelatorio.SetParameterValue("PorTitular", 0)
            oRelatorio.SetParameterValue("Titulo", "Posição do Fornecedor")
        End If
        If OpcaoTitular And blTitular Then
            oRelatorio.SetParameterValue("EscodeFornecedor", 1)
        Else
            oRelatorio.SetParameterValue("EscodeFornecedor", 0)
        End If

        If TodosContratosAberto Then
            oRelatorio.RecordSelectionFormula = ""
        Else
            SqlText = "if {posicao_fornecedor.CD_TIPO}=1 then "
            SqlText = SqlText & "    {posicao_fornecedor.QT_A_NEGOCIAR} <> 0 or {posicao_fornecedor.VL_PAG_AB} <> 0 or {posicao_fornecedor.QT_KG_A_FIXAR} <> 0 "
            SqlText = SqlText & "else "
            SqlText = SqlText & "    if {posicao_fornecedor.CD_TIPO} = 2 then "
            SqlText = SqlText & "        {posicao_fornecedor.QT_A_NEGOCIAR} <> 0 or {posicao_fornecedor.VL_PAG_AB} <> 0 or {posicao_fornecedor.QT_KG_A_FIXAR} <> 0 "
            SqlText = SqlText & "    else "
            SqlText = SqlText & "        true "
            oRelatorio.RecordSelectionFormula = SqlText
        End If

        If objDataTable_Vazio(oDataSub1) Then
            oRelatorio.ReportDefinition.Sections(12).SectionFormat.EnableSuppress = True
        End If
        If objDataTable_Vazio(oDataSub2) Then
            oRelatorio.ReportDefinition.Sections(13).SectionFormat.EnableSuppress = True
        End If

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_CacauAOrdem(ByVal Prazo As String, _
                                               ByVal DataVencimento As String, _
                                               ByVal ValoresAberto As Boolean, _
                                               ByVal SemMovimentacao As Boolean, _
                                               ByVal ListagemFilial As String, _
                                               ByVal SemContrato As Boolean, _
                                               ByVal Sintetico As Boolean, _
                                               Optional ByRef QtdeRegistro As Integer = 0 _
                                               ) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim Cdfilial As String = ""
        Dim Vencido As Boolean
        Dim sFiltro As String
        Dim IcVlAberto As Boolean
        Dim AVencer As Boolean
        Dim SemPrazo As Boolean
        Dim SemMov As Boolean
        Dim oData As DataTable

        Vencido = False
        AVencer = False
        SemPrazo = False
        sFiltro = ""

        Select Case Prazo
            Case cnt_RelatorioCacauAOrdem_Cod_PRAZOVENCIDO
                Vencido = True
                sFiltro = cnt_RelatorioCacauAOrdem_Desc_PRAZOVENCIDO & " " & DataVencimento
            Case cnt_RelatorioCacauAOrdem_Cod_PRAZOAVENCER
                AVencer = True
                sFiltro = cnt_RelatorioCacauAOrdem_Desc_PRAZOAVENCER & " " & DataVencimento
            Case cnt_RelatorioCacauAOrdem_Cod_SEMPRAZO
                SemPrazo = True
                sFiltro = cnt_RelatorioCacauAOrdem_Desc_SEMPRAZO
        End Select

        If ValoresAberto Then
            IcVlAberto = True
            sFiltro = sFiltro & " - Com valores em aberto"
        Else
            IcVlAberto = False
        End If

        If SemMovimentacao Then
            SemMov = True
        Else
            SemMov = False
        End If

        If Trim(ListagemFilial) <> "" Then
            Cdfilial = ListagemFilial
        Else
            Cdfilial = ListarIDFiliaisLiberadaUsuario()
        End If

        oData = Gera_Rs_Cacau_A_Ordem(Cdfilial, SemContrato, Vencido, DataVencimento, IcVlAberto, AVencer, SemPrazo, SemMov)

        QtdeRegistro = oData.Rows.Count

        If Sintetico Then
            oRelatorio.Load(Application.StartupPath & "\RPT_Cacau_A_Ordem_Sintetico.rpt")
        Else
            oRelatorio.Load(Application.StartupPath & "\RPT_Cacau_A_Ordem.rpt")
        End If

        oRelatorio.SetDataSource(oData)

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_MovimentacaoAbertoNegociacao(ByVal ListagemFiliais As String, _
                                                                ByVal ListagemTipoNegociacao As String, _
                                                                ByVal DataInicial As String, _
                                                                ByVal DataFinal As String) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable
        Dim SqlText As String
        Dim sFiltro As String = ""

        If Trim(ListagemFiliais) <> "" Then
            Str_Adicionar(sFiltro, "Filias: " & MontaFiltro_Filial(ListagemFiliais), " - ")
        End If
        If Trim(ListagemTipoNegociacao) <> "" Then
            SqlText = "SELECT TRIM(NO_TIPO_NEGOCIACAO) FROM SOF.TIPO_NEGOCIACAO WHERE CD_TIPO_NEGOCIACAO IN (" & ListagemTipoNegociacao & ")"
            Str_Adicionar(sFiltro, "Tipo de Negociação: " & DBQuery_ValorUnico_Lista(SqlText), " - ")
        End If
        If IsDate(DataInicial) Then
            Str_Adicionar(sFiltro, "Data Inicial: " & DataInicial, " - ")
        End If
        If IsDate(DataFinal) Then
            Str_Adicionar(sFiltro, "Data Final: " & DataFinal, " - ")
        End If

        oData = Gera_Rs_Cacau_A_Ordem_Negociacao(False, _
                                                 IIf(Trim(ListagemFiliais) = "", ListarIDFiliaisLiberadaUsuario, ListagemFiliais), _
                                                 ListagemTipoNegociacao, _
                                                 DataInicial, DataFinal)

        oRelatorio.Load(Application.StartupPath & "\RPT_MovimentacaoAbertaNegociacao.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_EstoqueCacau(ByVal ListagemFiliais As String, _
                                                ByVal CD_ARMAZEM As Integer, _
                                                ByVal UnidadePorSaco As Boolean, _
                                                ByVal TipoProcedenciaPorPilha As Boolean) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oRelatorio_Sub1 As New ReportDocument
        Dim oData As DataTable
        Dim oData_Sub1 As DataTable
        Dim SqlText As String

        oData = Gera_Data_Armazem_Pilha(IIf(Trim(ListagemFiliais) <> "", ListagemFiliais, ListarIDFiliaisLiberadaUsuario), _
                                        IIf(CD_ARMAZEM > 0, CD_ARMAZEM, -1), , False, , , , True)

        'CRIA O SUB RELTORIO PARA CALCULA ESTOQUE VS CAPACIDADE
        SqlText = "SELECT 'Estoque Total'  as ds_descricao,a.no_armazem, "
        SqlText = SqlText & "         -1*SUM (DECODE ('Q', " & IIf(UnidadePorSaco, "'S'", "'Q'") & ", mpa.qt_volume, sf.qt_sacos)) AS qt_volume "
        SqlText = SqlText & "    FROM sof.movimentacao_pilha_armazem mpa, "
        SqlText = SqlText & "         sof.pilha_armazem pa, "
        SqlText = SqlText & "         sof.armazem a, "
        SqlText = SqlText & "         (SELECT   cd_armazem, cd_pilha_armazem, sq_movimentacao, "
        SqlText = SqlText & "                   sq_movimentacao_pilha_armazem, SUM (qt_sacos) qt_sacos "
        SqlText = SqlText & "              FROM sof.mov_pilha_armazem_sacaria "
        SqlText = SqlText & "          GROUP BY cd_armazem, "
        SqlText = SqlText & "                   cd_pilha_armazem, "
        SqlText = SqlText & "                   sq_movimentacao, "
        SqlText = SqlText & "                   sq_movimentacao_pilha_armazem) sf "
        SqlText = SqlText & "   WHERE mpa.cd_armazem = pa.cd_armazem "
        SqlText = SqlText & "     AND mpa.cd_pilha_armazem = pa.cd_pilha_armazem "
        SqlText = SqlText & "     AND pa.cd_armazem = a.cd_armazem "
        SqlText = SqlText & "     AND A.CD_FILIAL_ORIGEM IN (SELECT CD_FILIAL FROM SOF.FILIAL WHERE CD_FILIAL IN (" & IIf(Trim(ListagemFiliais) <> "", ListagemFiliais, ListarIDFiliaisLiberadaUsuario) & ") OR CD_FILIAL_RESPONSAVEL IN (" & IIf(Trim(ListagemFiliais) <> "", ListagemFiliais, ListarIDFiliaisLiberadaUsuario) & "))"
        SqlText = SqlText & "     AND mpa.cd_armazem = sf.cd_armazem(+) "
        SqlText = SqlText & "     AND mpa.cd_pilha_armazem = sf.cd_pilha_armazem(+) "
        SqlText = SqlText & "     AND mpa.sq_movimentacao = sf.sq_movimentacao(+) "
        SqlText = SqlText & "     AND mpa.sq_movimentacao_pilha_armazem = sf.sq_movimentacao_pilha_armazem(+) "
        SqlText = SqlText & "GROUP BY a.no_armazem "
        SqlText = SqlText & "union all "
        SqlText = SqlText & "select 'Capacidade Teorica'  as ds_descricao,a.no_armazem, "
        SqlText = SqlText & "         DECODE ('Q', " & IIf(UnidadePorSaco, "'S'", "'Q'") & ", a.qt_capacidade*1000, a.qt_capacidade*1000/60) AS qt_volume "
        SqlText = SqlText & "from sof.armazem a "
        SqlText = SqlText & "where a.ic_ativo ='S' "
        SqlText = SqlText & " and not a.qt_capacidade is null "
        SqlText = SqlText & " AND A.CD_FILIAL_ORIGEM IN (SELECT CD_FILIAL FROM SOF.FILIAL WHERE CD_FILIAL IN (" & IIf(Trim(ListagemFiliais) <> "", ListagemFiliais, ListarIDFiliaisLiberadaUsuario) & ") OR CD_FILIAL_RESPONSAVEL IN (" & IIf(Trim(ListagemFiliais) <> "", ListagemFiliais, ListarIDFiliaisLiberadaUsuario) & "))"

        oData_Sub1 = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_Estoque_Cacau.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio_Sub1 = oRelatorio.Subreports("SALDO")
        oRelatorio_Sub1.SetDataSource(oData_Sub1)
        oRelatorio.SetParameterValue("SubTitulo", IIf(UnidadePorSaco, "Saco", "Quilo"))
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        oRelatorio.SetParameterValue("TipoProcedencia", IIf(TipoProcedenciaPorPilha, "P", "L"))
        oRelatorio.SetParameterValue("UnidadeMedida", IIf(UnidadePorSaco, "S", "Q"))

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_EstoqueArmazem(ByVal ListagemFilial As String, _
                                                  ByVal ListagemProcedencia As String, _
                                                  ByVal Armazem As Integer, _
                                                  ByVal Pilha As Integer, _
                                                  ByVal DataInicial As String, _
                                                  ByVal DataFinal As String, _
                                                  ByVal TipoCacau As Integer) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable
        Dim SqlText As String
        Dim sFiltro As String = ""

        If Trim(ListagemFilial) <> "" Then
            Str_Adicionar(sFiltro, "Filial: " & MontaFiltro_Filial(ListagemFilial), " - ")
        End If
        If Trim(ListagemProcedencia) <> "" Then
            Str_Adicionar(sFiltro, "Tipo de Cacau: " & ListagemProcedencia, " - ")
        End If
        If Armazem > 0 Then
            SqlText = "SELECT TRIM(NO_ARMAZEM) FROM SOF.ARMAZEM WHERE CD_ARMAZEM = " & Armazem
            Str_Adicionar(sFiltro, "Armazém: " & DBQuery_ValorUnico(SqlText), " - ")
        End If
        If Pilha > 0 Then
            Str_Adicionar(sFiltro, "Pilha: " & Pilha, " - ")
        End If
        If IsDate(DataInicial) Then
            Str_Adicionar(sFiltro, "Data Inical: " & DataInicial, " - ")
        End If
        If IsDate(DataFinal) Then
            Str_Adicionar(sFiltro, "Data Final: " & DataFinal, " - ")
        End If
        If Armazem > 0 Then
            SqlText = "SELECT TRIM(NO_TIPO_QUALIDADE) FROM SOF.TIPO_QUALIDADE WHERE CD_TIPO_QUALIDADE = " & TipoCacau
            Str_Adicionar(sFiltro, "Tipo de Cacau: " & DBQuery_ValorUnico(SqlText), " - ")
        End If

        oData = Gera_Data_Armazem_Pilha(IIf(Trim(ListagemFilial) <> "", ListagemFilial, ListarIDFiliaisLiberadaUsuario), _
                                        Armazem, Pilha, True, DataInicial, DataFinal, TipoCacau, False, , _
                                        IIf(Trim(ListagemProcedencia) <> "", ListagemProcedencia, ""))

        oRelatorio.Load(Application.StartupPath & "\RPT_Estoque_Armazem.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_PosEstoqueCacau_SaldoFinanceiro(ByVal DataBase As Date, _
                                                                   ByVal ValorDividasIncobraveis As Double) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oRelatorio_CompraAmendoaCacau_Ant As New ReportDocument
        Dim oRelatorio_CompraAmendoaCacau_Atual As New ReportDocument
        Dim oRelatorio_EntradaAmendoaCacau As New ReportDocument
        Dim oRelatorio_PosicaoCacauAOrdem As New ReportDocument
        Dim oRelatorio_PosicaoEstoqueAmendoaCacau As New ReportDocument
        Dim oRelatorio_PosicaoFinanceira As New ReportDocument

        Dim oData_CompraAmendoaCacau_Ant As New DataTable
        Dim oData_CompraAmendoaCacau_Atual As New DataTable
        Dim oData_EntradaAmendoaCacau As New DataTable
        Dim oData_PosicaoCacauAOrdem As New DataTable
        Dim oData_PosicaoEstoqueAmendoaCacau As New DataTable
        Dim oData_PosicaoFinanceira As New DataTable

        Dim oRow_01 As DataRow
        Dim oRow_02 As DataRow
        Dim oData_Aux_01 As DataTable
        Dim oData_Aux_02 As DataTable
        Dim SqlText As String = ""
        Dim dAux As Double
        Dim FY_ANT As String
        Dim FY_ATUAL As String

        Dim dCompraAmendoaCacau_DiferencialBolsa_Ant As Double
        Dim dCompraAmendoaCacau_DiferencialBolsa_Atual As Double
        Dim dCompraAmendoaCacau_Importacao_Ant As Double
        Dim dCompraAmendoaCacau_Importacao_Atual As Double

        Dim oPosFinan_AdiantamentoCtrsAVencer As DataRow
        Dim oPosFinan_AdiantamentoCtrsVencido As DataRow
        Dim oPosFinan_DividaRenegociacaoAVencer As DataRow
        Dim oPosFinanCriticos_DividaCobrancaJuridical As DataRow
        Dim oPosFinanCriticos_DividaRenegociacaoVencidas As DataRow
        Dim oPosFinanCriticos_DividaIncobraveis As DataRow

        Dim FILTRO_Filial As String = ""
        Dim FILTRO_Filial_SemFabrica As String = ""
        Dim sFiltro As String = ""
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        Dim DT_COTACAO As Date
        Dim TX_DOLAR As Double
        Dim VL_BOLSA As Double
        Dim VL_ARROBA As Double

        Relatorio_PegaValor(DT_COTACAO, TX_DOLAR, VL_BOLSA, VL_ARROBA)

        FILTRO_Filial = ListarIDFiliaisLiberadaUsuario()
        FILTRO_Filial = Replace(FILTRO_Filial, " ", "")
        FILTRO_Filial_SemFabrica = Array_Para_Lista(Array_EliminaValor(Lista_Para_Array(FILTRO_Filial), New String() {FilialMae}))

        Str_Adicionar(sFiltro, "Data Base: " & DataBase, " - ")
        Str_Adicionar(sFiltro, "Filiais: " & MontaFiltro_Filial(FILTRO_Filial), " - ")
        Str_Adicionar(sFiltro, "Valor de Dívidas Incobráveis: " & Replace(ValorDividasIncobraveis, "_", ""), " - ")

        '>> Seção - Compras de Amêndoas de Cacau - Início
        With oData_CompraAmendoaCacau_Ant.Columns
            .Add("NR_ORDEM").DataType = System.Type.GetType("System.Int32")
            .Add("NO_TIPO_CONTRATO").DataType = System.Type.GetType("System.String")
            .Add("QT_KG_COMPRADO").DataType = System.Type.GetType("System.Int32")
            .Add("QT_SC_COMPRADO").DataType = System.Type.GetType("System.Double")
            .Add("QT_KG_SALDO").DataType = System.Type.GetType("System.Int32")
            .Add("QT_SC_SALDO").DataType = System.Type.GetType("System.Int32")
        End With
        With oData_CompraAmendoaCacau_Atual.Columns
            .Add("NR_ORDEM").DataType = System.Type.GetType("System.Int32")
            .Add("NO_TIPO_CONTRATO").DataType = System.Type.GetType("System.String")
            .Add("QT_KG_COMPRADO").DataType = System.Type.GetType("System.Int32")
            .Add("QT_SC_COMPRADO").DataType = System.Type.GetType("System.Double")
            .Add("QT_KG_SALDO").DataType = System.Type.GetType("System.Int32")
            .Add("QT_SC_SALDO").DataType = System.Type.GetType("System.Int32")
        End With

        'Preço Fixo em R$ - Início
        oRow_01 = REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Ant, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Diferencial)
        oRow_02 = REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Atual, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Diferencial)

        oData_Aux_01 = Gera_Rs_CalculoDiferencial(Data_Safra_Inicio(DataBase).AddYears(-1), DataBase, _
                                                  "", "", "", "", False, 0, False, enCalcDiferencial_Opcao.SEM_IMPORT)

        For iCont_01 = 0 To oData_Aux_01.Rows.Count - 1
            With oData_Aux_01.Rows(iCont_01)
                If oData_Aux_01.Rows(iCont_01).Item("TP_CTR") <> "N" Then
                    If Data_Safra_Inicio(DataBase) <= New Date(Year(.Item("DT_CONTRATO")), Month(.Item("DT_CONTRATO")), 1) Then
                        oRow_02.Item("QT_KG_COMPRADO") = NVL(oRow_02.Item("QT_KG_COMPRADO"), 0) + NVL(.Item("QT_KGS"), 0)
                        oRow_02.Item("QT_SC_COMPRADO") = Math.Round(NVL(oRow_02.Item("QT_KG_COMPRADO"), 0) / 60)
                    Else
                        oRow_01.Item("QT_KG_COMPRADO") = NVL(oRow_01.Item("QT_KG_COMPRADO"), 0) + NVL(.Item("QT_KGS"), 0)
                        oRow_01.Item("QT_SC_COMPRADO") = Math.Round(NVL(oRow_01.Item("QT_KG_COMPRADO"), 0) / 60)
                    End If
                End If
            End With
        Next
        'Preço Fixo em R$ - Fim

        'Importacao - Início
        oRow_01 = REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Ant, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Importacao)
        oRow_02 = REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Atual, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Importacao)

        oData_Aux_01 = Gera_Rs_CalculoDiferencial(Data_Safra_Inicio(DataBase).AddYears(-1), DataBase, _
                                                  "", "", "", "", False, 0, False, enCalcDiferencial_Opcao.SOMENTE_IMPORT)

        For iCont_01 = 0 To oData_Aux_01.Rows.Count - 1
            With oData_Aux_01.Rows(iCont_01)
                If oData_Aux_01.Rows(iCont_01).Item("TP_CTR") <> "N" Then
                    If Data_Safra_Inicio(DataBase) <= New Date(Year(.Item("DT_CONTRATO")), Month(.Item("DT_CONTRATO")), 1) Then
                        oRow_02.Item("QT_KG_COMPRADO") = NVL(oRow_02.Item("QT_KG_COMPRADO"), 0) + NVL(.Item("QT_KGS"), 0)
                        oRow_02.Item("QT_SC_COMPRADO") = Math.Round(NVL(oRow_02.Item("QT_KG_COMPRADO"), 0) / 60)
                    Else
                        oRow_01.Item("QT_KG_COMPRADO") = NVL(oRow_01.Item("QT_KG_COMPRADO"), 0) + NVL(.Item("QT_KGS"), 0)
                        oRow_01.Item("QT_SC_COMPRADO") = Math.Round(NVL(oRow_01.Item("QT_KG_COMPRADO"), 0) / 60)
                    End If
                End If
            End With
        Next
        'Importacao - Fim

        '> Diferencial Bolsa / Importação
        oData_Aux_01 = Gera_Rs_NegociacaoAbertaComFixacoes("", DataBase, FILTRO_Filial, cnt_TIPO_NEGOCIACAO_DiferencialBolsa.ToString)

        oData_Aux_02 = New DataTable

        With oData_Aux_02.Columns
            .Add("CD_PAF_NEG")
            .Add("IC_IMPORTADO")
            .Add("QTDE").DataType = System.Type.GetType("System.Double")
            .Add("IC_SAFRA_ATUAL")
        End With

        For iCont_01 = 0 To oData_Aux_01.Rows.Count - 1
            With oData_Aux_01.Rows(iCont_01)
                oRow_01 = Nothing

                FY_ATUAL = IIf(Data_Safra_Inicio(DataBase) <= New Date(Year(.Item("DT_NEGOCIACAO")), Month(.Item("DT_NEGOCIACAO")), 1), "S", "N")

                For iCont_02 = 0 To oData_Aux_02.Rows.Count - 1
                    If FY_ATUAL = oData_Aux_02.Rows(iCont_02).Item("IC_SAFRA_ATUAL") And _
                       IIf(.Item("CD_FILIAL") = FilialMae, "S", "N") = oData_Aux_02.Rows(iCont_02).Item("IC_IMPORTADO") And _
                       Trim(.Item("CD_CONTRATO_PAF")) & "-" & Trim(.Item("SQ_NEGOCIACAO")) = oData_Aux_02.Rows(iCont_02).Item("CD_PAF_NEG") Then
                        oRow_01 = oData_Aux_02.Rows(iCont_02)
                        Exit For
                    End If
                Next

                If oRow_01 Is Nothing Then
                    oRow_01 = oData_Aux_02.NewRow
                    oData_Aux_02.Rows.Add(oRow_01)

                    oRow_01.Item("CD_PAF_NEG") = Trim(.Item("CD_CONTRATO_PAF")) & "-" & Trim(.Item("SQ_NEGOCIACAO"))
                    oRow_01.Item("IC_SAFRA_ATUAL") = FY_ATUAL
                    oRow_01.Item("IC_IMPORTADO") = IIf(.Item("CD_FILIAL") = FilialMae, "S", "N")

                    If .Item("CD_FILIAL") = FilialMae Then
                        oRow_01.Item("QTDE") = NVL(.Item("QT_KGS"), 0)
                    Else
                        oRow_01.Item("QTDE") = NVL(.Item("QT_A_FIXAR"), 0)
                    End If
                End If
            End With
        Next

        For iCont_01 = 0 To oData_Aux_02.Rows.Count - 1
            With oData_Aux_02.Rows(iCont_01)
                If .Item("IC_SAFRA_ATUAL") = "S" Then
                    If .Item("IC_IMPORTADO") = "S" Then
                        dCompraAmendoaCacau_Importacao_Atual = dCompraAmendoaCacau_Importacao_Atual + .Item("QTDE")
                    Else
                        dCompraAmendoaCacau_DiferencialBolsa_Atual = dCompraAmendoaCacau_DiferencialBolsa_Atual + .Item("QTDE")
                    End If
                Else
                    If .Item("IC_IMPORTADO") = "S" Then
                        dCompraAmendoaCacau_Importacao_Ant = dCompraAmendoaCacau_Importacao_Ant + .Item("QTDE")
                    Else
                        dCompraAmendoaCacau_DiferencialBolsa_Ant = dCompraAmendoaCacau_DiferencialBolsa_Ant + .Item("QTDE")
                    End If
                End If
            End With
        Next

        'Diferencial Bolsa
        With REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Ant, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Diferencial)
            .Item("QT_KG_COMPRADO") = dCompraAmendoaCacau_DiferencialBolsa_Ant
            .Item("QT_SC_COMPRADO") = Math.Round(dCompraAmendoaCacau_DiferencialBolsa_Ant / 60)
        End With
        With REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Atual, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Diferencial)
            .Item("QT_KG_COMPRADO") = dCompraAmendoaCacau_DiferencialBolsa_Atual
            .Item("QT_SC_COMPRADO") = Math.Round(dCompraAmendoaCacau_DiferencialBolsa_Atual / 60)
        End With

        'Saldo Em Aberto - PAF - Início
        oRow_01 = REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Ant, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_PrecoAFixar)
        oRow_02 = REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Atual, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_PrecoAFixar)

        oData_Aux_01 = Gera_Rs_ContratoEmAberto_CtrPAF(, , cnt_TipoContratoPAF_ContratoPAFComADTO.ToString, cnt_ComboOpcao_ApenasAdiantamentoAberto)

        For iCont_01 = 0 To oData_Aux_01.Rows.Count - 1
            With oData_Aux_01.Rows(iCont_01)
                If Data_Safra_Inicio(DataBase) <= New Date(Year(.Item("DT_CONTRATO_PAF")), Month(.Item("DT_CONTRATO_PAF")), 1) Then
                    If Not oRow_02 Is Nothing Then
                        oRow_02.Item("QT_KG_SALDO") = NVL(oRow_02.Item("QT_KG_SALDO"), 0) + NVL(.Item("QT_SALDO"), 0)
                        oRow_02.Item("QT_SC_SALDO") = Math.Round(NVL(oRow_02.Item("QT_KG_SALDO"), 0) / 60, 0)
                    End If
                Else
                    If Not oRow_01 Is Nothing Then
                        oRow_01.Item("QT_KG_SALDO") = NVL(oRow_01.Item("QT_KG_SALDO"), 0) + NVL(.Item("QT_SALDO"), 0)
                        oRow_01.Item("QT_SC_SALDO") = Math.Round(NVL(oRow_01.Item("QT_KG_SALDO"), 0) / 60, 0)
                    End If
                End If
            End With
        Next
        'Saldo Em Aberto - PAF - Fim

        'Saldo Em Aberto - FIXO - Início
        oData_Aux_01 = Gera_Rs_ContratoEmAberto_CtrFixo(Data_Safra_Inicio(DataBase).AddYears(-1), DataBase, 0, "")

        For iCont_01 = 0 To oData_Aux_01.Rows.Count - 1
            With oData_Aux_01.Rows(iCont_01)
                dAux = NVL(.Item("QT_KGS"), 0) - NVL(.Item("QT_CANCELADO"), 0) - NVL(.Item("QT_REC"), 0)

                If .Item("CD_FILIAL_ORIGEM") = FilialMae Then
                    oRow_01 = REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Ant, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Importacao)
                    oRow_02 = REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Atual, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Importacao)
                Else
                    oRow_01 = REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Ant, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_PrecoFixo)
                    oRow_02 = REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Atual, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_PrecoFixo)
                End If

                If Data_Safra_Inicio(DataBase) <= New Date(Year(.Item("DT_CONTRATO")), Month(.Item("DT_CONTRATO")), 1) Then
                    If Not oRow_02 Is Nothing Then
                        oRow_02.Item("QT_KG_SALDO") = NVL(oRow_02.Item("QT_KG_SALDO"), 0) + dAux
                        oRow_02.Item("QT_SC_SALDO") = Math.Round(NVL(oRow_02.Item("QT_KG_SALDO"), 0) / 60, 0)
                    End If
                Else
                    If Not oRow_01 Is Nothing Then
                        oRow_01.Item("QT_KG_SALDO") = NVL(oRow_01.Item("QT_KG_SALDO"), 0) + dAux
                        oRow_01.Item("QT_SC_SALDO") = Math.Round(NVL(oRow_01.Item("QT_KG_SALDO"), 0) / 60, 0)
                    End If
                End If
            End With
        Next
        'Saldo Em Aberto - FIXO - Fim

        'Saldo Em Aberto - DIFERENCIAL - Início
        oRow_01 = REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Ant, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Diferencial)
        oRow_02 = REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(oData_CompraAmendoaCacau_Atual, cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Diferencial)

        oData_Aux_01 = Gera_Rs_ContratoEmAberto_Neg(Data_Safra_Inicio(DataBase).AddYears(-1), DataBase, 0, _
                                                    FILTRO_Filial_SemFabrica, cnt_TIPO_NEGOCIACAO_DiferencialBolsa.ToString)

        For iCont_01 = 0 To oData_Aux_01.Rows.Count - 1
            With oData_Aux_01.Rows(iCont_01)

                dAux = .Item("QT_A_FIXAR") - .Item("qt_kg_a_fixar")

                If Data_Safra_Inicio(DataBase) <= New Date(Year(.Item("DT_NEGOCIACAO")), Month(.Item("DT_NEGOCIACAO")), 1) Then
                    If Not oRow_02 Is Nothing Then
                        oRow_02.Item("QT_KG_SALDO") = NVL(oRow_02.Item("QT_KG_SALDO"), 0) + dAux
                        oRow_02.Item("QT_SC_SALDO") = Math.Round(NVL(oRow_02.Item("QT_KG_SALDO"), 0) / 60, 0)
                    End If
                Else
                    If Not oRow_01 Is Nothing Then
                        oRow_01.Item("QT_KG_SALDO") = NVL(oRow_01.Item("QT_KG_SALDO"), 0) + dAux
                        oRow_01.Item("QT_SC_SALDO") = Math.Round(NVL(oRow_01.Item("QT_KG_SALDO"), 0) / 60, 0)
                    End If
                End If
            End With
        Next
        'Saldo Em Aberto - DIFERENCIAL - Fim

        For iCont_01 = 0 To oData_CompraAmendoaCacau_Ant.Rows.Count - 1
            With oData_CompraAmendoaCacau_Ant.Rows(iCont_01)
                .Item("QT_KG_COMPRADO") = Math.Round(NVL(.Item("QT_KG_COMPRADO"), 0) / 1000, 2)
                .Item("QT_KG_SALDO") = Math.Round(NVL(.Item("QT_KG_SALDO"), 0) / 1000, 2)
            End With
        Next
        For iCont_01 = 0 To oData_CompraAmendoaCacau_Atual.Rows.Count - 1
            With oData_CompraAmendoaCacau_Atual.Rows(iCont_01)
                .Item("QT_KG_COMPRADO") = Math.Round(NVL(.Item("QT_KG_COMPRADO"), 0) / 1000, 2)
                .Item("QT_KG_SALDO") = Math.Round(NVL(.Item("QT_KG_SALDO"), 0) / 1000, 2)
            End With
        Next
        '>> Seção - Compras de Amêndoas de Cacau - Fim

        '>> Seção - Cacau A Ordem
        With oData_PosicaoCacauAOrdem.Columns
            .Add("NO_FILIAL")
            .Add("QT_KG_SAFRA_ANTES").DataType = System.Type.GetType("System.Int32")
            .Add("QT_SC_SAFRA_ANTES").DataType = System.Type.GetType("System.Int32")
            .Add("QT_KG_SAFRA_ATUAL").DataType = System.Type.GetType("System.Int32")
            .Add("QT_SC_SAFRA_ATUAL").DataType = System.Type.GetType("System.Int32")
        End With

        oData_Aux_01 = Gera_Rs_Cacau_A_Ordem(FILTRO_Filial, False, False, DataBase, False, False, False, False, True)

        For iCont_01 = 0 To oData_Aux_01.Rows.Count - 1
            oRow_01 = Nothing

            With oData_Aux_01.Rows(iCont_01)
                For iCont_02 = 0 To oData_PosicaoCacauAOrdem.Rows.Count - 1
                    If UCase(Trim(oData_PosicaoCacauAOrdem.Rows(iCont_02).Item("NO_FILIAL"))) = UCase(Trim(.Item("NO_FILIAL"))) Then
                        oRow_01 = oData_PosicaoCacauAOrdem.Rows(iCont_02)
                        Exit For
                    End If
                Next

                If oRow_01 Is Nothing Then
                    oRow_01 = oData_PosicaoCacauAOrdem.NewRow
                    oRow_01.Item("NO_FILIAL") = NVL(.Item("NO_FILIAL"), "")
                    oData_PosicaoCacauAOrdem.Rows.Add(oRow_01)
                End If

                If Data_Safra_Inicio(Now.Date) <= .Item("DT_MES_ANO") Then
                    oRow_01.Item("QT_KG_SAFRA_ATUAL") = NVL(oRow_01.Item("QT_KG_SAFRA_ATUAL"), 0) + NVL(.Item("QT_PAF_S_ADTO"), 0)
                    oRow_01.Item("QT_SC_SAFRA_ATUAL") = Math.Round(NVL(oRow_01.Item("QT_KG_SAFRA_ATUAL"), 0) / 60, 0)
                Else
                    oRow_01.Item("QT_KG_SAFRA_ANTES") = NVL(oRow_01.Item("QT_KG_SAFRA_ANTES"), 0) + NVL(.Item("QT_PAF_S_ADTO"), 0)
                    oRow_01.Item("QT_SC_SAFRA_ANTES") = Math.Round(NVL(oRow_01.Item("QT_KG_SAFRA_ANTES"), 0) / 60)
                End If
            End With
        Next

        '>> Seção - Posição de Estoque de Cacau
        oData_PosicaoEstoqueAmendoaCacau = Gera_Rs_Estoque_Cacau(DataBase)
        '>> Seção - Entrada de Amêndoas de Cacau
        SqlText = "SELECT FIL.NO_FILIAL," & _
                         "SUM(DECODE(TO_CHAR(MOV.DT_MOVIMENTACAO, 'YYYYMM'), TO_CHAR(TO_DATE(" & QuotedStr(Date_to_Oracle(DataBase)) & "), 'YYYYMM'), MOV.QT_KG_LIQUIDO_NF, 0)) QT_KG_MENSAL," & _
                         "SUM(DECODE(TO_CHAR(MOV.DT_MOVIMENTACAO, 'YYYYMM'), TO_CHAR(TO_DATE(" & QuotedStr(Date_to_Oracle(DataBase)) & "), 'YYYYMM'), SAC.QT_SACOS, 0)) QT_SC_MENSAL," & _
                         "SUM(MOV.QT_KG_LIQUIDO_NF) QT_KG_SAFRA," & _
                         "SUM(SAC.QT_SACOS) QT_SC_SAFRA" & _
                  " FROM SOF.MOVIMENTACAO MOV," & _
                        "SOF.TIPO_MOVIMENTACAO TMV," & _
                        "SOF.FORNECEDOR FNC," & _
                        "SOF.FILIAL FIL," & _
                        "(SELECT SQ_MOVIMENTACAO," & _
                                "SUM(QT_SACOS) QT_SACOS" & _
                         " FROM SOF.SACARIA_FILIAL SF" & _
                         " GROUP BY SQ_MOVIMENTACAO) SAC" & _
                  " WHERE MOV.DT_MOVIMENTACAO >= " & QuotedStr(Date_to_Oracle(Data_Safra_Inicio(DataBase))) & _
                    " AND MOV.DT_MOVIMENTACAO <= " & QuotedStr(Date_to_Oracle(DataBase)) & _
                    " AND TMV.CD_TIPO_MOVIMENTACAO = MOV.CD_TIPO_MOVIMENTACAO" & _
                    " AND NVL(TMV.IC_IMPORTACAO, 'N') IN ('N')" & _
                    " AND FNC.CD_FORNECEDOR = MOV.CD_FORNECEDOR" & _
                    " AND FIL.CD_FILIAL = FNC.CD_FILIAL_ORIGEM" & _
                    " AND SAC.SQ_MOVIMENTACAO (+) = MOV.SQ_MOVIMENTACAO" & _
                  " GROUP BY FIL.NO_FILIAL"
        oData_EntradaAmendoaCacau = DBQuery(SqlText)

        '>> Seção - Posição Financeira / Posição Financeira - Casos Críticos - Início
        With oData_PosicaoFinanceira.Columns
            .Add("IC_GRUPO")
            .Add("NO_ITEM")
            .Add("VL_POSICAO").DataType = System.Type.GetType("System.Double")
        End With
        'Cria as linhas da Posição Financeira
        oPosFinan_AdiantamentoCtrsAVencer = oData_PosicaoFinanceira.Rows.Add
        oPosFinan_AdiantamentoCtrsAVencer.Item("IC_GRUPO") = "PF"
        oPosFinan_AdiantamentoCtrsVencido = oData_PosicaoFinanceira.Rows.Add
        oPosFinan_AdiantamentoCtrsVencido.Item("IC_GRUPO") = "PF"
        oPosFinan_DividaRenegociacaoAVencer = oData_PosicaoFinanceira.Rows.Add
        oPosFinan_DividaRenegociacaoAVencer.Item("IC_GRUPO") = "PF"
        oPosFinan_AdiantamentoCtrsAVencer.Item("NO_ITEM") = "Adiantamentos em Ctr.s a Vencer"
        oPosFinan_AdiantamentoCtrsVencido.Item("NO_ITEM") = "Adiantamentos em Ctr.s Vencidos"
        oPosFinan_DividaRenegociacaoAVencer.Item("NO_ITEM") = "Dívidas Renegociadas a Vencer"
        'Cria as linhas da Posição Financeira - Casos Críticos
        oPosFinanCriticos_DividaCobrancaJuridical = oData_PosicaoFinanceira.Rows.Add
        oPosFinanCriticos_DividaCobrancaJuridical.Item("IC_GRUPO") = "PFC"
        oPosFinanCriticos_DividaRenegociacaoVencidas = oData_PosicaoFinanceira.Rows.Add
        oPosFinanCriticos_DividaRenegociacaoVencidas.Item("IC_GRUPO") = "PFC"
        oPosFinanCriticos_DividaIncobraveis = oData_PosicaoFinanceira.Rows.Add
        oPosFinanCriticos_DividaIncobraveis.Item("IC_GRUPO") = "PFC"
        oPosFinanCriticos_DividaCobrancaJuridical.Item("NO_ITEM") = "Dívidas em Cobrança Judicial"
        oPosFinanCriticos_DividaRenegociacaoVencidas.Item("NO_ITEM") = "Dívidas Renegociadas e Vencidas"
        oPosFinanCriticos_DividaIncobraveis.Item("NO_ITEM") = "Dívidas Incobrávies (*)"

        'Consulta para alimentação do data
        oData_Aux_01 = Gera_Rs_NetSaldo(VL_BOLSA, TX_DOLAR, VL_ARROBA, True, "", "", "", True)

        For iCont_01 = 0 To oData_Aux_01.Rows.Count - 1
            With oData_Aux_01.Rows(iCont_01)
                dAux = NVL(.Item("VL_QT_A_FIXAR"), 0) - NVL(.Item("VL_PAG_AB_JUROS"), 0)

                Select Case .Item("CD_TIPO_OPERACAO")
                    Case cnt_NetSales_Operacao_AVencerContrato_Cod
                        oPosFinan_AdiantamentoCtrsAVencer.Item("VL_POSICAO") = NVL(oPosFinan_AdiantamentoCtrsAVencer.Item("VL_POSICAO"), 0) + dAux
                    Case cnt_NetSales_Operacao_AVencerRenegociado_Cod
                        oPosFinan_DividaRenegociacaoAVencer.Item("VL_POSICAO") = NVL(oPosFinan_DividaRenegociacaoAVencer.Item("VL_POSICAO"), 0) + dAux
                    Case cnt_NetSales_Operacao_VencidoContrato_Cod
                        oPosFinan_AdiantamentoCtrsVencido.Item("VL_POSICAO") = NVL(oPosFinan_AdiantamentoCtrsVencido.Item("VL_POSICAO"), 0) + dAux
                    Case cnt_NetSales_Operacao_Juridico_Cod
                        oPosFinanCriticos_DividaCobrancaJuridical.Item("VL_POSICAO") = NVL(oPosFinanCriticos_DividaCobrancaJuridical.Item("VL_POSICAO"), 0) + dAux
                    Case cnt_NetSales_Operacao_VencidoRenegociado_Cod
                        oPosFinanCriticos_DividaRenegociacaoVencidas.Item("VL_POSICAO") = NVL(oPosFinanCriticos_DividaRenegociacaoVencidas.Item("VL_POSICAO"), 0) + dAux
                End Select
            End With
        Next

        FY_ANT = "FY " & Data_Safra_Inicio(DataBase.AddYears(-1)).Year.ToString.Substring(2) & _
                   "/" & Data_Safra_Fim(DataBase.AddYears(-1)).Year.ToString.Substring(2)
        FY_ATUAL = "FY " & Data_Safra_Inicio(DataBase).Year.ToString.Substring(2) & _
                     "/" & Data_Safra_Fim(DataBase).Year.ToString.Substring(2)

        'Entrada de Valor de Dívidas Incobráveis
        oPosFinan_AdiantamentoCtrsVencido.Item("VL_POSICAO") = NVL(oPosFinan_AdiantamentoCtrsVencido.Item("VL_POSICAO"), 0) + ValorDividasIncobraveis
        oPosFinanCriticos_DividaIncobraveis.Item("VL_POSICAO") = 0 - ValorDividasIncobraveis
        '>> Seção - Posição Financeira / Posição Financeira - Casos Críticos - Fim

        oRelatorio.Load(Application.StartupPath & "\RPT_PosEstoqueCacau_SaldoFinanceiro.rpt")
        oRelatorio_CompraAmendoaCacau_Ant = oRelatorio.Subreports("CompraAmendoasCacau_Ant")
        oRelatorio_CompraAmendoaCacau_Ant.DataDefinition.FormulaFields("FY_ATUAL").Text = Chr(34) & FY_ANT & Chr(34)
        oRelatorio_CompraAmendoaCacau_Atual = oRelatorio.Subreports("CompraAmendoasCacau_Atual")
        oRelatorio_CompraAmendoaCacau_Atual.DataDefinition.FormulaFields("FY_ATUAL").Text = Chr(34) & FY_ATUAL & Chr(34)
        oRelatorio_PosicaoCacauAOrdem = oRelatorio.Subreports("PosicaoCacauAOrdem")
        oRelatorio_EntradaAmendoaCacau = oRelatorio.Subreports("EntradaAmendoasCacauFilial")
        oRelatorio_EntradaAmendoaCacau.DataDefinition.FormulaFields("FY_ATUAL").Text = Chr(34) & FY_ATUAL & Chr(34)
        oRelatorio_PosicaoEstoqueAmendoaCacau = oRelatorio.Subreports("PosicaoEstoqueAmendoas")
        oRelatorio_PosicaoEstoqueAmendoaCacau.DataDefinition.FormulaFields("FY_ATUAL").Text = Chr(34) & FY_ATUAL & Chr(34)
        oRelatorio_PosicaoFinanceira = oRelatorio.Subreports("PoiscaoFinanceira")

        oRelatorio_CompraAmendoaCacau_Ant.SetDataSource(oData_CompraAmendoaCacau_Ant)
        oRelatorio_CompraAmendoaCacau_Atual.SetDataSource(oData_CompraAmendoaCacau_Atual)
        oRelatorio_PosicaoEstoqueAmendoaCacau.SetDataSource(oData_PosicaoEstoqueAmendoaCacau)
        oRelatorio_EntradaAmendoaCacau.SetDataSource(oData_EntradaAmendoaCacau)
        oRelatorio_PosicaoCacauAOrdem.SetDataSource(oData_PosicaoCacauAOrdem)
        oRelatorio_PosicaoFinanceira.SetDataSource(oData_PosicaoFinanceira)

        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        oRelatorio.SetParameterValue("Filtro", sFiltro)

        Return oRelatorio
    End Function

    Private Function REL_PosEstoqueCacau_SldFinanceiro_Data_CompraAmendoaCacau_Row(ByVal oData As DataTable, _
                                                                                   ByVal NO_TIPO_CONTRATO As String) As DataRow
        Dim oRow As DataRow = Nothing
        Dim iCont As Integer

        For iCont = 0 To oData.Rows.Count - 1
            If oData.Rows(iCont).Item("NO_TIPO_CONTRATO") = NO_TIPO_CONTRATO Then
                oRow = oData.Rows(iCont)
                Exit For
            End If
        Next

        If oRow Is Nothing Then
            oRow = oData.NewRow
            oData.Rows.Add(oRow)

            With oRow
                Select Case NO_TIPO_CONTRATO
                    Case cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_PrecoAFixar
                        .Item("NR_ORDEM") = 1
                    Case cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_PrecoFixo
                        .Item("NR_ORDEM") = 2
                    Case cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Diferencial
                        .Item("NR_ORDEM") = 3
                    Case cnt_Rel_PosEstCacau_SldFinan_CompraAmendoaCacau_Importacao
                        .Item("NR_ORDEM") = 4
                End Select

                .Item("NO_TIPO_CONTRATO") = NO_TIPO_CONTRATO
                .Item("QT_KG_COMPRADO") = 0
                .Item("QT_SC_COMPRADO") = 0
                .Item("QT_KG_SALDO") = 0
                .Item("QT_SC_SALDO") = 0
            End With
        End If

        Return oRow
    End Function

    Private Function REL_PrecoMedioNFComplementa_Data_Contrato_Row(ByVal oData As DataTable, _
                                                                   ByVal CD_Grupo As Integer, ByVal TX_PIS As Double) As DataRow
        Dim oRow As DataRow = Nothing
        Dim iCont As Integer

        For iCont = 0 To oData.Rows.Count - 1
            If oData.Rows(iCont).Item("CD_GRUPO") = CD_Grupo And oData.Rows(iCont).Item("TX_PIS") = TX_PIS Then
                oRow = oData.Rows(iCont)
                Exit For
            End If
        Next

        If oRow Is Nothing Then
            oRow = oData.NewRow
            oData.Rows.Add(oRow)

            With oRow
                .Item("NR_ORDEM") = 1
                .Item("TX_PIS") = TX_PIS
                Select Case TX_PIS
                    Case 9.25
                        .Item("NO_TAXA") = "Pessoa Juridica"
                    Case 3.2375
                        .Item("NO_TAXA") = "Pessoa Fisica"
                End Select

                .Item("CD_GRUPO") = CD_Grupo
                Select Case CD_Grupo
                    Case RELPMNC.CashTrade_Grupo.SaldoAbertoEntComAdto
                        .Item("NO_GRUPO") = "Saldo em aberto a entregar com Adto"
                    Case RELPMNC.CashTrade_Grupo.SaldoAbertoEntSemAdto
                        .Item("NO_GRUPO") = "Saldo em aberto a entregar sem Adto"
                    Case RELPMNC.CashTrade_Grupo.TotalNegAfixarSemAdto
                        .Item("NO_GRUPO") = "Total Negociação a fixar (Dif Bolsa) sem adto"
                End Select

                .Item("QT_KG_ANTERIOR") = 0
                .Item("VL_KG_ANTERIOR") = 0
                .Item("QT_KG") = 0
                .Item("VL_KG") = 0

            End With
        End If

        Return oRow
    End Function

    Public Function Gera_Relatorio_ResumoEstoque(ByVal ListagemFilial As String, _
                                                 ByVal ListagemProcedencia As String, _
                                                 ByVal CD_Armazem As Integer, _
                                                 ByVal AgrupaOrigem As Boolean, _
                                                 ByVal AgrupaArmazem As Boolean, _
                                                 ByVal AgrupaPilha As Boolean, _
                                                 ByVal AgrupaProcedencia As Boolean) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable
        Dim sFiltro As String = ""

        If Trim(ListagemFilial) <> "" Then
            Str_Adicionar(sFiltro, "Filial: " & MontaFiltro_Filial(ListagemFilial), " - ")
        End If
        If Trim(ListagemProcedencia) <> "" Then
            Str_Adicionar(sFiltro, "Procedência: " & ListagemProcedencia, " - ")
        End If
        If CD_Armazem > 0 Then
            Str_Adicionar(sFiltro, "Armazém: " & MontaFiltro_Armazem(CD_Armazem), " - ")
        End If

        oData = Gera_Data_Armazem_Pilha(IIf(Trim(ListagemFilial) <> "", ListagemFilial, ListarIDFiliaisLiberadaUsuario), _
                                        CD_Armazem, , , , , , True, , ListagemProcedencia)

        oRelatorio.Load(Application.StartupPath & "\RPT_Resumo_Estoque.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        If AgrupaOrigem Then
            oRelatorio.SetParameterValue("AgrupaOrigem", "S")
        Else
            oRelatorio.SetParameterValue("AgrupaOrigem", "N")
        End If
        If AgrupaArmazem Then
            oRelatorio.SetParameterValue("AgrupaArmazem", "S")
        Else
            oRelatorio.SetParameterValue("AgrupaArmazem", "N")
        End If
        If AgrupaPilha Then
            oRelatorio.SetParameterValue("AgrupaPilha", "S")
        Else
            oRelatorio.SetParameterValue("AgrupaPilha", "N")
        End If
        If AgrupaProcedencia Then
            oRelatorio.SetParameterValue("AgrupaProcedencia", "S")
        Else
            oRelatorio.SetParameterValue("AgrupaProcedencia", "N")
        End If

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_PrecoMedioNRComplementa(ByVal oTipoRelatorio As RELPMNC.RGFP_TipoRelatorio, _
                                                           ByVal TaxaDolar As Double, _
                                                           ByVal ListagemFilial As String, _
                                                           ByVal Tipo As String) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oRelatorio_Sub1 As New ReportDocument
        Dim oRelatorio_Sub2 As New ReportDocument
        Dim oRelatorio_Sub3 As New ReportDocument
        Dim oData As DataTable
        Dim SqlText As String
        Dim sFiltro As String = ""
        Dim sFiltro02 As String = ""
        Dim SqlFilter As String = ""
        Dim SqlFilter2 As String = ""
        Dim SqlUnion As String = ""
        Dim SqlText1 As String = ""
        Dim SqlText2 As String = ""
        Dim SqlAux As String = ""
        Dim VlMin As Double
        Dim oData_Contratos As New DataTable
        Dim oData_Importado As New DataTable
        Dim Vl_Importado As Double

        sFiltro = sFiltro & " - Taxa Dolar: " & TaxaDolar

        SqlText = "SELECT P.VL_MINIMO_NF_COMPLEMENTAR FROM SOF.PARAMETRO P"
        VlMin = DBQuery_ValorUnico(SqlText, 0)

        SqlUnion = ""

        'SELECT COM 2 SUB SELECTS QUE CALCULAM O VALOR DA MEDIA PONDERADA DO DOLAR UTILIZADO NO PAGAMENTOS E NA MOVIMENTAÇÃO
        'SE TIVER VALOR PAGO USA O DOLAR MEDIO DO PAGAMENTO SE NÃO USA O DA MOVIMENTAÇÃO
        SqlText = "SELECT decode(cf.ic_taxa_dolar_variavel,'S',cf.cd_safra*-10,cf.cd_safra) cd_safra, " & _
                  "decode(cf.ic_taxa_dolar_variavel,'S','FIX US ' || " & _
                  "DECODE(munic.cd_uf, 'EX', 'IMP ', 'DOM ') || s.ds_safra, " & _
                  "DECODE(munic.cd_uf, 'EX', 'FIX IMP ', '') || s.ds_safra) ds_safra, " & _
                  "cf.dt_contrato_fixo, " & _
                  "f.no_razao_social, " & _
                  "TO_CHAR (cf.Cd_Contrato_PAF)|| '-' || TO_CHAR (cf.sq_negociacao) || '-' || cf.sq_contrato_fixo cd_contrato, " & _
                  "cf.qt_kgs, cf.vl_total , cf.vl_icms, cf.qt_kg_fixo, round(cf.vl_pag_fixo + nvl(AMA.vl_aplicado,0),2) as vl_pag_fixo, " & _
                  "cf.vl_nf_inss_fixo , " & _
                  "cf.vl_nf_fixo , " & _
                  "cf.vl_adendo, " & _
                  "cf.vl_unitario, " & _
                  "cf.vl_adendo_icms, " & _
                  "nvl(DECODE (CF.vl_pag_fixo ,0, decode(DMM.VL_TAXA_DOLAR_MEDIO,0," & ConvValorFormatoAmericano(TaxaDolar) & ",DMM.VL_TAXA_DOLAR_MEDIO) , DMP.VL_TAXA_MEDIA),(" & ConvValorFormatoAmericano(TaxaDolar) & ")) vl_dolar_atual " & _
                  ", cf.qt_cancelado, " & _
                  "CF.ic_status, " & _
                  "cf.vl_inss, " & _
                  "cf.ic_taxa_dolar_variavel, " & _
                  "nvl(CF.VL_BOLSA_FECHADO, DECODE(NVL(cf.VL_BOLSA_ALTERNATIVO, 0), 0, NVL(cf.VL_BOLSA, 0), NVL(cf.VL_BOLSA_ALTERNATIVO, 0))) vl_bolsa_fechado, " & _
                  "n.vl_negociacao, " & _
                  "tn.ic_bolsa_operacao, " & _
                  "FIL.CD_FILIAL, " & _
                  "FIL.NO_FILIAL, " & _
                  "cf.IC_INCLUI_ICMS_PAG , " & _
                  "SOF.FC_INDICE_VALORES(f.CD_TIPO_PESSOA, cf.dt_contrato_fixo, 16)* cf.vl_total/100 vl_imposto, SOF.FC_INDICE_VALORES(f.CD_TIPO_PESSOA, cf.dt_contrato_fixo, 16) tx_pis,f.CD_TIPO_PESSOA,cf.CD_PAPEL,cf.DT_VENCIMENTO, " & _
                  "n.vl_premio_crm, cf.vl_taxa_dolar " & _
        "FROM sof.contrato_fixo cf, " & _
                "sof.negociacao n," & _
                "sof.contrato_paf cp, " & _
                "sof.fornecedor f, " & _
                "sof.municipio munic, " & _
                "sof.filial fil," & _
                "sof.tipo_negociacao tn," & _
                "sof.tipo_unidade tu, " & _
                "sof.safra s, " & _
             "(SELECT ROUND(SUM(PNCF.VL_FIXO * NVL(P.VL_TAXA_DOLAR, (" & ConvValorFormatoAmericano(TaxaDolar) & "))) / DECODE(SUM(PNCF.VL_FIXO), 0, 1, SUM(PNCF.VL_FIXO)), 4) VL_TAXA_MEDIA, " & _
                  "PNCF.Cd_Contrato_PAF , PNCF.Sq_Negociacao, PNCF.Sq_Contrato_Fixo " & _
                  "from sof.pag_neg_ctr_fix pncf, sof.pagamentos p, SOF.CONTRATO_FIXO CF, SOF.CONTRATO_PAF CP, sof.fornecedor f " & _
                  "Where PNCF.Sq_Pagamento = p.Sq_Pagamento and pncf.cd_contrato_paf = CF.cd_contrato_paf " & _
                  "and pncf.sq_negociacao =CF.sq_negociacao and pncf.sq_contrato_fixo = CF.sq_contrato_fixo " & _
                  "AND CP.cd_contrato_paf = CF.cd_contrato_paf and cp.cd_fornecedor = f.cd_fornecedor "

        SqlText1 = " GROUP BY PNCF.cd_contrato_paf, PNCF.sq_negociacao, PNCF.sq_contrato_fixo) DMP, " & _
                   "(SELECT round(DECODE(NVL(SUM(CPNCFM.vl_fixo ),0),0,0,SUM(CPNCFM.vl_fixo  * NVL(TD.vl_taxa,(" & ConvValorFormatoAmericano(TaxaDolar) & ")))/decode(SUM(CPNCFM.vl_fixo),0,1,SUM(CPNCFM.vl_fixo))),4) VL_TAXA_DOLAR_MEDIO, " & _
                   "CPNCFM.Cd_Contrato_PAF , CPNCFM.Sq_Negociacao, CPNCFM.Sq_Contrato_Fixo " & _
                   "FROM SOF.CTR_PAF_NEG_CTR_FIX_MOV CPNCFM,SOF.TAXA_DOLAR TD, SOF.CONTRATO_FIXO CF, SOF.CONTRATO_PAF CP, sof.fornecedor f " & _
                   "WHERE CPNCFM.dt_fixacao = TD.dt_cotacao (+) and CPNCFM.cd_contrato_paf = CF.cd_contrato_paf " & _
                   "and CPNCFM.sq_negociacao =CF.sq_negociacao and CPNCFM.sq_contrato_fixo = CF.sq_contrato_fixo " & _
                   "AND CP.cd_contrato_paf = CF.cd_contrato_paf and cp.cd_fornecedor = f.cd_fornecedor "

        SqlText2 = " GROUP BY CPNCFM.cd_contrato_paf, CPNCFM.sq_negociacao, CPNCFM.sq_contrato_fixo) DMM, "

        SqlText2 = SqlText2 & cnt_SQL_Amarracao_Aplicacao & " AMA "


        SqlText2 = SqlText2 & "Where cp.Cd_Contrato_PAF = n.Cd_Contrato_PAF AND n.cd_contrato_paf = cf.cd_contrato_paf " & _
                       "AND n.sq_negociacao = cf.sq_negociacao AND cp.cd_fornecedor = f.cd_fornecedor " & _
                       "and f.cd_municipio = munic.cd_municipio " & _
                       "AND F.cd_filial_origem = fil.cd_filial AND n.cd_tipo_negociacao = tn.cd_tipo_negociacao " & _
                       "AND cf.cd_safra = s.cd_safra AND cf.cd_tipo_unidade = tu.cd_tipo_unidade " & _
                       "and DMP.cd_contrato_paf(+) = cf.cd_contrato_paf  and DMP.sq_negociacao (+)=cf.sq_negociacao " & _
                       "and DMP.sq_contrato_fixo(+) = cf.sq_contrato_fixo  and DMM.cd_contrato_paf (+)= cf.cd_contrato_paf " & _
                       "and DMM.sq_negociacao (+)=cf.sq_negociacao  and DMM.sq_contrato_fixo (+)= cf.sq_contrato_fixo " & _
                       "and AMA.cd_contrato_paf (+)= cf.cd_contrato_paf " & _
                       "and AMA.sq_negociacao (+)=cf.sq_negociacao  and AMA.sq_contrato_fixo (+)= cf.sq_contrato_fixo "

        'FILTRO FILIAL
        If Trim(ListagemFilial) <> "" Then
            SqlFilter = SqlFilter & " AND f.CD_FILIAL_ORIGEM IN (" & ListagemFilial & ")"
            sFiltro = sFiltro & " - Filial: " & MontaFiltro_Filial(ListagemFilial)
        Else
            SqlFilter = SqlFilter & " AND f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        If Tipo = cnt_PrecoMedio_Cod_Sintetico And oTipoRelatorio = RELPMNC.RGFP_TipoRelatorio.PrecoMedio Then
            SqlFilter2 = SqlFilter & " and cf.ic_status in ('A','D') AND " & _
                     "(CF.qt_kgs - CF.qt_cancelado) <> CF.qt_kg_fixo"
            'INCLUE AS NEGOCIAÇÕES EM ABERTO FEITA EM DOLAR OU BOLSA
            SqlUnion = " union all "
            SqlUnion = SqlUnion & "SELECT (s.cd_safra * -100) cd_safra, " & _
                      "decode(munic.cd_uf,'EX','IMP ','DOM ') || S.ds_safra DS_SAFRA, " & _
                      "n.dt_negociacao, f.no_razao_social, " & _
                      "TO_CHAR(n.cd_contrato_paf) || '-' || TO_CHAR(n.sq_negociacao) CD_CONTRATO, " & _
                      "n.qt_kgs, round(((DECODE(TN.ic_bolsa,'S', DECODE(TN.ic_bolsa_operacao,'+', " & _
                      "bh.vl_cotacao+N.vl_negociacao, DECODE(TN.ic_bolsa_operacao,'-', " & _
                      "bh.vl_cotacao-N.vl_negociacao, DECODE(TN.ic_bolsa_operacao,'*', " & _
                      "bh.vl_cotacao*N.vl_negociacao, bh.vl_cotacao/N.vl_negociacao))), " & _
                      "(N.vl_negociacao/TU.qt_fator)*1000))/1000) * N.qt_kgs,2) VL_TOTAL, " & _
                      "round(((((DECODE(TN.ic_bolsa,'S', DECODE(TN.ic_bolsa_operacao,'+', " & _
                      "bh.vl_cotacao+N.vl_negociacao, DECODE(TN.ic_bolsa_operacao,'-', " & _
                      "bh.vl_cotacao-N.vl_negociacao, DECODE(TN.ic_bolsa_operacao,'*', " & _
                      "bh.vl_cotacao*N.vl_negociacao, bh.vl_cotacao/N.vl_negociacao))), " & _
                      "(N.vl_negociacao/TU.qt_fator)*1000))/1000) * N.qt_kgs)/ " & _
                      " (1-((N.PC_ALIQ_ICMS+FUN.VL_TAXA)/100)))*(N.PC_ALIQ_ICMS/100),2) VL_ICMS, " & _
                      "(N.qt_kgs - N.qt_cancelado - N.qt_a_fixar) QT_KGS_FIXO, " & _
                      "0 vl_pag_fixo, 0 VL_NF_FIXO_INSS, 0 VL_NF_FIXO, 0 VL_ADENDO, " & _
                      "round((DECODE(TN.ic_bolsa,'S', DECODE(TN.ic_bolsa_operacao,'+', " & _
                      "bh.vl_cotacao+N.vl_negociacao, DECODE(TN.ic_bolsa_operacao,'-', " & _
                      "bh.vl_cotacao-N.vl_negociacao, DECODE(TN.ic_bolsa_operacao,'*', " & _
                      "bh.vl_cotacao*N.vl_negociacao, bh.vl_cotacao/N.vl_negociacao))), " & _
                      "(N.vl_negociacao/TU.qt_fator)*1000)),2) VL_UNITARIO, 0 VL_ADENDO_ICMS, " & _
                      "1 VL_DOLAR_ATUAL, N.qt_cancelado, N.ic_status, round(((((DECODE(TN.ic_bolsa,'S', " & _
                      "DECODE(TN.ic_bolsa_operacao,'+', bh.vl_cotacao+N.vl_negociacao, " & _
                      "DECODE(TN.ic_bolsa_operacao,'-', bh.vl_cotacao-N.vl_negociacao, "

            SqlUnion = SqlUnion & "DECODE(TN.ic_bolsa_operacao,'*', bh.vl_cotacao*N.vl_negociacao, " & _
                      "bh.vl_cotacao/N.vl_negociacao))), (N.vl_negociacao/TU.qt_fator)*1000))/1000) * N.qt_kgs)/ " & _
                      "(1-((N.PC_ALIQ_ICMS+FUN.VL_TAXA)/100)))*(FUN.vl_taxa/100),2) VL_INSS, " & _
                      "'N' ic_taxa_dolar_variavel, 0 vl_bolsa_fechado, 0 vl_negociacao, '' ic_bolsa_operacao, FIL.CD_FILIAL, FIL.NO_FILIAL, 'N' ic_inclui_icms_pag, " & _
                      " 0 vl_imposto, 0 tx_pis, 0 cd_tipo_pessoa,n.CD_PAPEL,n.DT_VENCIMENTO, 0 vl_premio_crm, 0 vl_taxa_dolar " & _
                      "FROM sof.filial fil,sof.negociacao n, sof.contrato_paf cp, sof.fornecedor f, " & _
                      "sof.tipo_negociacao tn, sof.tipo_unidade tu, sof.safra s, sof.municipio munic, " & _
                      "SOF.FUNRURAL FUN, sof.bolsa_periodo_matriz bpm, " & _
                      "(SELECT b.sq_bolsa_periodo_matriz, b.vl_cotacao FROM sof.bolsa_historico b " & _
                      "WHERE b.dt_bolsa_historico = (SELECT MAX(b2.dt_bolsa_historico) " & _
                      "FROM sof.bolsa_historico b2 WHERE b2.vl_cotacao <> 0 AND " & _
                      "b.sq_bolsa_periodo_matriz = b2.sq_bolsa_periodo_matriz)) bh "

            SqlUnion = SqlUnion & "WHERE cp.cd_contrato_paf = n.cd_contrato_paf AND " & _
                      "f.cd_fornecedor = cp.cd_fornecedor AND " & _
                      "n.cd_tipo_negociacao = tn.cd_tipo_negociacao AND " & _
                      "n.cd_tipo_unidade = tu.cd_tipo_unidade AND " & _
                      "n.cd_papel_competencia = bpm.cd_papel(+) AND " & _
                      "bpm.sq_bolsa_periodo_matriz = bh.sq_bolsa_periodo_matriz(+) AND " & _
                      "n.cd_safra = s.cd_safra and " & _
                      "f.cd_municipio = munic.cd_municipio and " & _
                      "F.CD_FUNRURAL = FUN.CD_FUNRURAL AND F.cd_filial_origem = fil.cd_filial AND " & _
                      "n.ic_status = 'A' AND " & _
                      "N.qt_a_fixar <> 0 AND " & _
                      "(tn.ic_bolsa = 'S' or tn.ic_dolar = 'S')"
        Else
            SqlAux = SqlFilter
            SqlFilter = SqlAux & " AND ((Cf.VL_PAG_FIXO <> (Cf.VL_NF_FIXO - Cf.VL_NF_INSS_FIXO ) AND " & _
                      "(Cf.VL_PAG_FIXO - (Cf.VL_NF_FIXO - Cf.VL_NF_INSS_FIXO)) <> 0 AND " & _
                      "((Cf.VL_PAG_FIXO - (Cf.VL_NF_FIXO - Cf.VL_NF_INSS_FIXO)) > " & ConvValorFormatoAmericano(VlMin) & " OR " & _
                      "(Cf.VL_PAG_FIXO - (Cf.VL_NF_FIXO - Cf.VL_NF_INSS_FIXO)) < -" & ConvValorFormatoAmericano(VlMin) & ")) OR " & _
                      "(CF.qt_kgs - CF.qt_cancelado) <> CF.qt_kg_fixo) AND " & _
                      "Cf.IC_STATUS<>'E' "

            SqlFilter2 = SqlAux & " AND ((round(Cf.VL_PAG_FIXO+ nvl(AMA.vl_aplicado,0),2) <> (Cf.VL_NF_FIXO - Cf.VL_NF_INSS_FIXO ) AND " & _
                   "(round(Cf.VL_PAG_FIXO+ nvl(AMA.vl_aplicado,0),2) - (Cf.VL_NF_FIXO - Cf.VL_NF_INSS_FIXO)) <> 0 AND " & _
                   "((round(Cf.VL_PAG_FIXO+ nvl(AMA.vl_aplicado,0),2) - (Cf.VL_NF_FIXO - Cf.VL_NF_INSS_FIXO)) > " & ConvValorFormatoAmericano(VlMin) & " OR " & _
                   "(round(Cf.VL_PAG_FIXO+ nvl(AMA.vl_aplicado,0),2) - (Cf.VL_NF_FIXO - Cf.VL_NF_INSS_FIXO)) < -" & ConvValorFormatoAmericano(VlMin) & ")) OR " & _
                   "(CF.qt_kgs - CF.qt_cancelado) <> CF.qt_kg_fixo) AND " & _
                   "Cf.IC_STATUS<>'E' "
        End If

        If oTipoRelatorio = RELPMNC.RGFP_TipoRelatorio.CashTrade Then
            SqlText = SqlText & " and ((cf.qt_kgs-cf.qt_cancelado)<>cf.qt_kg_fixo)"
        End If

        SqlText = "SELECT * FROM (" & SqlText & SqlFilter & SqlText1 & SqlFilter & SqlText2 & SqlFilter2 & SqlUnion & ")"

        If oTipoRelatorio = RELPMNC.RGFP_TipoRelatorio.CashTrade And Tipo = cnt_PrecoMedio_Cod_Analitico_Mensal Then
            SqlText = SqlText & " WHERE ((QT_KGS- QT_CANCELADO) <> QT_KG_FIXO) AND IC_STATUS NOT IN ('F', 'D')"
        End If

        SqlText = SqlText & " ORDER BY DT_CONTRATO_FIXO"

        oData = DBQuery(SqlText)

        If oTipoRelatorio = RELPMNC.RGFP_TipoRelatorio.CashTrade And Tipo = cnt_PrecoMedio_Cod_Sintetico Then
            Dim iCont_01 As Integer
            Dim oRow_01 As DataRow
            Dim Qt_Aberto_ComAdto As Double
            Dim Vl_Aberto_ComAdto As Double
            Dim Qt_Aberto_SemAdto As Double
            Dim Vl_Aberto_SemAdto As Double
            Dim Vl_Unitario As Double
            Dim dAux As Double

            With oData_Contratos.Columns
                .Add("NR_ORDEM").DataType = System.Type.GetType("System.Int32")
                .Add("TX_PIS").DataType = System.Type.GetType("System.Double")
                .Add("NO_TAXA").DataType = System.Type.GetType("System.String")
                .Add("CD_GRUPO").DataType = System.Type.GetType("System.Int32")
                .Add("NO_GRUPO").DataType = System.Type.GetType("System.String")
                .Add("QT_KG_ANTERIOR").DataType = System.Type.GetType("System.Int32")
                .Add("VL_KG_ANTERIOR").DataType = System.Type.GetType("System.Double")
                .Add("QT_KG").DataType = System.Type.GetType("System.Int32")
                .Add("VL_KG").DataType = System.Type.GetType("System.Double")
                .Add("VL_IMPORTADO").DataType = System.Type.GetType("System.Double")
            End With
            With oData_Importado.Columns
                .Add("CD_CONTRATO").DataType = System.Type.GetType("System.String")
                .Add("FORNECEDOR").DataType = System.Type.GetType("System.String")
                .Add("QT_KG").DataType = System.Type.GetType("System.Int32")
                .Add("VL_KG").DataType = System.Type.GetType("System.Double")
            End With

            For iCont_01 = 0 To oData.Rows.Count - 1
                With oData.Rows(iCont_01)
                    'Calcula Preco Unitario
                    Vl_Aberto_ComAdto = 0
                    If .Item("qt_kgs") = 0 Then
                        Vl_Unitario = 0
                    Else
                        Vl_Unitario = ((.Item("vl_total") + .Item("vl_adendo") + .Item("vl_icms") + .Item("vl_adendo_icms")) / .Item("qt_kgs")) * 15
                    End If

                    'Qtd Aberto Com Adto
                    If ((.Item("vl_pag_fixo") / (Vl_Unitario / 15)) - .Item("qt_kg_fixo")) <> 0 Then
                        Qt_Aberto_ComAdto = (.Item("vl_pag_fixo") / (Vl_Unitario / 15)) - .Item("qt_kg_fixo")
                    Else
                        Qt_Aberto_ComAdto = 0
                    End If
                    'Vl aberto com adto
                    If .Item("ic_taxa_dolar_variavel") = "N" Then
                        Vl_Aberto_ComAdto = Vl_Unitario / 15 * Qt_Aberto_ComAdto / oData.Rows(iCont_01).Item("vl_dolar_atual")
                    ElseIf .Item("ic_bolsa_operacao") = "+" Then
                        Vl_Aberto_ComAdto = Qt_Aberto_ComAdto * ((.Item("vl_bolsa_fechado") + .Item("vl_negociacao")) / 1000)
                    ElseIf .Item("ic_bolsa_operacao") = "-" Then
                        Vl_Aberto_ComAdto = Qt_Aberto_ComAdto * ((.Item("vl_bolsa_fechado") - .Item("vl_negociacao")) / 1000)
                    ElseIf .Item("ic_bolsa_operacao") = "*" Then
                        Vl_Aberto_ComAdto = Qt_Aberto_ComAdto * ((.Item("vl_bolsa_fechado") * .Item("vl_negociacao")) / 1000)
                    Else
                        Vl_Aberto_ComAdto = Qt_Aberto_ComAdto * ((.Item("vl_bolsa_fechado") / .Item("vl_negociacao")) / 1000)
                    End If
                    'Qtd Aberto Sem Adto
                    Qt_Aberto_SemAdto = Math.Round((.Item("qt_kgs") - .Item("qt_cancelado")) - (.Item("vl_pag_fixo") / (Vl_Unitario / 15)), 4)
                    'Vl Aberto Sem Adto
                    If .Item("ic_taxa_dolar_variavel") = "N" Then
                        Vl_Aberto_SemAdto = (Vl_Unitario / 15 * Qt_Aberto_SemAdto) / .Item("vl_dolar_atual")
                    ElseIf .Item("ic_bolsa_operacao") = "+" Then
                        Vl_Aberto_SemAdto = Qt_Aberto_SemAdto * ((.Item("vl_bolsa_fechado") + .Item("vl_negociacao")) / 1000)
                    ElseIf .Item("ic_bolsa_operacao") = "-" Then
                        Vl_Aberto_SemAdto = Qt_Aberto_SemAdto * ((.Item("vl_bolsa_fechado") - .Item("vl_negociacao")) / 1000)
                    ElseIf .Item("ic_bolsa_operacao") = "*" Then
                        Vl_Aberto_SemAdto = Qt_Aberto_SemAdto * ((.Item("vl_bolsa_fechado") * .Item("vl_negociacao")) / 1000)
                    Else
                        Vl_Aberto_SemAdto = Qt_Aberto_SemAdto * ((.Item("vl_bolsa_fechado") / .Item("vl_negociacao")) / 1000)
                    End If

                    'Se for importado coloco o data table importados
                    If .Item("cd_tipo_pessoa") = 6 Then
                        oRow_01 = oData_Importado.NewRow
                        oData_Importado.Rows.Add(oRow_01)

                        With oRow_01
                            .Item("CD_CONTRATO") = oData.Rows(iCont_01).Item("CD_CONTRATO")
                            .Item("FORNECEDOR") = oData.Rows(iCont_01).Item("no_razao_social")
                            .Item("QT_KG") = Qt_Aberto_ComAdto + Qt_Aberto_SemAdto
                            .Item("VL_KG") = Vl_Aberto_ComAdto + Vl_Aberto_SemAdto
                        End With
                        Vl_Importado = Vl_Importado + Vl_Aberto_ComAdto + Vl_Aberto_SemAdto
                        Continue For
                    End If

                    'Valores com adto
                    oRow_01 = REL_PrecoMedioNFComplementa_Data_Contrato_Row(oData_Contratos, RELPMNC.CashTrade_Grupo.SaldoAbertoEntComAdto, .Item("tx_pis"))

                    If .Item("dt_contrato_fixo") <= New Date(2010, 5, 31) Then
                        oRow_01.Item("QT_KG_ANTERIOR") = oRow_01.Item("QT_KG_ANTERIOR") + Qt_Aberto_ComAdto
                        oRow_01.Item("VL_KG_ANTERIOR") = oRow_01.Item("VL_KG_ANTERIOR") + Vl_Aberto_ComAdto
                    Else
                        oRow_01.Item("QT_KG") = oRow_01.Item("QT_KG") + Qt_Aberto_ComAdto
                        oRow_01.Item("VL_KG") = oRow_01.Item("VL_KG") + Vl_Aberto_ComAdto
                    End If

                    'Valores sem adto
                    oRow_01 = REL_PrecoMedioNFComplementa_Data_Contrato_Row(oData_Contratos, RELPMNC.CashTrade_Grupo.SaldoAbertoEntSemAdto, .Item("tx_pis"))

                    If .Item("dt_contrato_fixo") <= New Date(2010, 5, 31) Then
                        oRow_01.Item("QT_KG_ANTERIOR") = oRow_01.Item("QT_KG_ANTERIOR") + Qt_Aberto_SemAdto
                        oRow_01.Item("VL_KG_ANTERIOR") = oRow_01.Item("VL_KG_ANTERIOR") + Vl_Aberto_SemAdto
                    Else
                        oRow_01.Item("QT_KG") = oRow_01.Item("QT_KG") + Qt_Aberto_SemAdto
                        oRow_01.Item("VL_KG") = oRow_01.Item("VL_KG") + Vl_Aberto_SemAdto
                    End If
                End With
            Next

            'Alimenta campo vl_importado para ser usado em sub reports. limitação crystal
            For iCont_01 = 0 To oData_Contratos.Rows.Count - 1
                oRow_01 = oData_Contratos.Rows(iCont_01)
                oRow_01.Item("VL_IMPORTADO") = Vl_Importado
            Next

            oData = Gera_Rs_ContratoEmAberto_Neg(Nothing, Nothing, 0, ListagemFilial, cnt_TIPO_NEGOCIACAO_DiferencialBolsa.ToString)

            For iCont_01 = 0 To oData.Rows.Count - 1
                With oData.Rows(iCont_01)
                    oRow_01 = REL_PrecoMedioNFComplementa_Data_Contrato_Row(oData_Contratos, RELPMNC.CashTrade_Grupo.TotalNegAfixarSemAdto, .Item("tx_pis"))
                    dAux = .Item("QT_A_FIXAR") - .Item("qt_kg_a_fixar")

                    If dAux <> 0 Then
                        dAux = dAux
                    End If
                    If .Item("DT_NEGOCIACAO") <= New Date(2010, 5, 31) Then
                        oRow_01.Item("QT_KG_ANTERIOR") = oRow_01.Item("QT_KG_ANTERIOR") + dAux
                        oRow_01.Item("VL_KG_ANTERIOR") = oRow_01.Item("VL_KG_ANTERIOR") + (dAux * ((.Item("VL_BOLSA") + .Item("VL_NEGOCIACAO")) / 1000))
                    Else
                        oRow_01.Item("QT_KG") = oRow_01.Item("QT_KG") + dAux
                        oRow_01.Item("VL_KG") = oRow_01.Item("VL_KG") + (dAux * ((.Item("VL_BOLSA") + .Item("VL_NEGOCIACAO")) / 1000))
                    End If
                End With
            Next
        End If

        Select Case oTipoRelatorio
            Case RELPMNC.RGFP_TipoRelatorio.PrecoMedio, RELPMNC.RGFP_TipoRelatorio.SaldoFinanceiro_CtrFixo
                If Tipo = cnt_PrecoMedio_Cod_Analitico Or Tipo = cnt_PrecoMedio_Cod_Resumido Or oTipoRelatorio = RELPMNC.RGFP_TipoRelatorio.SaldoFinanceiro_CtrFixo Then
                    If oTipoRelatorio = RELPMNC.RGFP_TipoRelatorio.SaldoFinanceiro_CtrFixo Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_SaldoFinanceiro_CtrFixo.rpt")
                    Else
                        oRelatorio.Load(Application.StartupPath & "\RPT_Preco_Medio_Analitico.rpt")
                    End If
                    oRelatorio.SetDataSource(oData)
                    oRelatorio.SetParameterValue("Filtro", sFiltro)
                    oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                    oRelatorio.SetParameterValue("ValorMinimo", VlMin)
                    oRelatorio.SetParameterValue("Tipo", Tipo)
                Else
                    oRelatorio.Load(Application.StartupPath & "\RPT_Preco_Medio_Sintetico.rpt")
                    oRelatorio.SetDataSource(oData)
                    oRelatorio.SetParameterValue("Filtro", sFiltro)
                    oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                End If
            Case RELPMNC.RGFP_TipoRelatorio.NFComplementar
                oRelatorio.Load(Application.StartupPath & "\RPT_NF_Comprementar_Contabil.rpt")
                oRelatorio.SetDataSource(oData)

                Select Case Tipo
                    Case cnt_NFComplementar_Cod_Todos
                        oRelatorio.RecordSelectionFormula = ""
                        sFiltro = sFiltro & " - " & cnt_NFComplementar_Desc_Todos
                    Case cnt_NFComplementar_Cod_Credito
                        oRelatorio.RecordSelectionFormula = "{@nf_complementar}<0"
                        sFiltro = sFiltro & " - " & cnt_NFComplementar_Desc_Credito
                    Case cnt_NFComplementar_Cod_Debito
                        oRelatorio.RecordSelectionFormula = "{@nf_complementar}>0"
                        sFiltro = sFiltro & " - " & cnt_NFComplementar_Desc_Debito
                End Select

                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                oRelatorio.SetParameterValue("ValorMinimo", VlMin)
            Case RELPMNC.RGFP_TipoRelatorio.CashTrade
                Select Case Tipo
                    Case cnt_PrecoMedio_Cod_Analitico
                        oRelatorio.Load(Application.StartupPath & "\RPT_Cash_Trade_Analitico.rpt")
                        oRelatorio.SetDataSource(oData)
                        oRelatorio.SetParameterValue("Filtro", sFiltro)
                        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                        oRelatorio.SetParameterValue("ValorMinimo", VlMin)
                        oRelatorio.SetParameterValue("Tipo", cnt_PrecoMedio_Cod_Analitico)
                    Case cnt_PrecoMedio_Cod_Analitico_Mensal
                        Dim DtMudancaCalculo As Date = Now

                        SqlText = "SELECT DT_ITEM_CONFIGURACAO" & _
                                  " FROM SOF.PROCESSO_CONFIGURACAO" & _
                                  " WHERE CD_PROCESSO = " & cnt_Processo_RelatorioCashTrade & _
                                    " AND CD_ITEM_CONFIGURACAO = " & cnt_Config_Item_RelatorioCashTrade_DtMudancaFormaCalculo
                        DtMudancaCalculo = DBQuery_ValorUnico(SqlText, DtMudancaCalculo)

                        oRelatorio.Load(Application.StartupPath & "\RPT_Cash_Trade_Analitico_Mensal.rpt")
                        oRelatorio.SetDataSource(oData)
                        oRelatorio.SetParameterValue("Filtro", sFiltro)
                        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                        oRelatorio.SetParameterValue("ValorMinimo", VlMin)
                        oRelatorio.SetParameterValue("Tipo", cnt_PrecoMedio_Cod_Analitico)
                        oRelatorio.SetParameterValue("DtMudancaCalculo", DtMudancaCalculo)
                    Case cnt_PrecoMedio_Cod_Sintetico
                        oRelatorio.Load(Application.StartupPath & "\RPT_Cash_Trade_Sintetico.rpt")
                        oRelatorio_Sub1 = oRelatorio.Subreports("Total")
                        oRelatorio_Sub1.SetDataSource(oData_Contratos)
                        oRelatorio_Sub2 = oRelatorio.Subreports("IMPORTADO")
                        oRelatorio_Sub2.SetDataSource(oData_Importado)
                        oRelatorio_Sub3 = oRelatorio.Subreports("PIS")
                        oRelatorio_Sub3.SetDataSource(oData_Contratos)
                        oRelatorio.SetDataSource(oData_Contratos)
                        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                        oRelatorio.SetParameterValue("Data", DataSistema)
                End Select
        End Select

        Return oRelatorio
    End Function

    Public Function Gera_Data_IndustrializacaoValorializacao(ByVal DataInicial As String, _
                                                             ByVal DataFinal As String) As DataTable
        Dim oDataRel As DataTable
        Dim oRow As DataRow

        Dim oData As DataTable
        Dim SqlText As String

        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        oDataRel = New DataTable

        With oDataRel.Columns
            .Add("DT_INDUSTRIALIZACAO").DataType = System.Type.GetType("System.DateTime")
            .Add("QT_LINHA_A").DataType = System.Type.GetType("System.Double")
            .Add("QT_LINHA_B").DataType = System.Type.GetType("System.Double")
            .Add("VL_LINHA_A").DataType = System.Type.GetType("System.Double")
            .Add("VL_LINHA_B").DataType = System.Type.GetType("System.Double")
        End With

        SqlText = "SELECT TRUNC(TR.DT_TRANSFERENCIA) DT_TRANSFERENCIA," & _
                         "LP.NO_LINHA_PRODUCAO," & _
                         "SUM(MV.QT_KG_LIQUIDO_NF) QT_KG_LIQUIDO_NF," & _
                         "SUM(MV.VL_NF) VL_NF" & _
                  " FROM SOF.TRANSFERENCIA TR," & _
                        "SOF.MOVIMENTACAO MV," & _
                        "SOF.TRANSFERENCIA_MODALIDADE TM," & _
                        "SOF.LINHA_PRODUCAO LP" & _
                  " WHERE TR.DT_TRANSFERENCIA >= " & QuotedStr(Date_to_Oracle(DataInicial)) & _
                    " AND TR.DT_TRANSFERENCIA <= " & QuotedStr(Date_to_Oracle(DataFinal)) & _
                    " AND MV.SQ_MOVIMENTACAO = TR.SQ_MOVIMENTACAO_SAIDA" & _
                    " AND TM.CD_TRANSFERENCIA_MODALIDADE = TR.CD_TRANSFERENCIA_MODALIDADE" & _
                    " AND LP.SQ_LINHA_PRODUCAO = TM.SQ_LINHA_PRODUCAO" & _
                  " GROUP BY TRUNC(TR.DT_TRANSFERENCIA)," & _
                            "LP.NO_LINHA_PRODUCAO"
        oData = DBQuery(SqlText)

        For iCont_01 = 0 To oData.Rows.Count - 1
            oRow = Nothing

            'Procurando reg. ref. a data
            For iCont_02 = 0 To oDataRel.Rows.Count - 1
                If oDataRel.Rows(iCont_02).Item("DT_INDUSTRIALIZACAO") = oData.Rows(iCont_01).Item("DT_TRANSFERENCIA") Then
                    oRow = oDataRel.Rows(iCont_02)
                    Exit For
                End If
            Next

            With oData.Rows(iCont_01)
                If oRow Is Nothing Then
                    oRow = oDataRel.NewRow
                    oDataRel.Rows.Add(oRow)

                    oDataRel.Rows(iCont_02).Item("DT_INDUSTRIALIZACAO") = .Item("DT_TRANSFERENCIA")
                    oDataRel.Rows(iCont_02).Item("QT_LINHA_A") = 0
                    oDataRel.Rows(iCont_02).Item("QT_LINHA_B") = 0
                    oDataRel.Rows(iCont_02).Item("VL_LINHA_A") = 0
                    oDataRel.Rows(iCont_02).Item("VL_LINHA_B") = 0
                End If

                If .Item("NO_LINHA_PRODUCAO") = "LINHA A" Then
                    oDataRel.Rows(iCont_02).Item("QT_LINHA_A") = NVL(oDataRel.Rows(iCont_02).Item("QT_LINHA_A"), 0) + .Item("QT_KG_LIQUIDO_NF")
                    oDataRel.Rows(iCont_02).Item("VL_LINHA_A") = NVL(oDataRel.Rows(iCont_02).Item("VL_LINHA_A"), 0) + NVL(.Item("VL_NF"), 0)
                Else
                    oDataRel.Rows(iCont_02).Item("QT_LINHA_B") = NVL(oDataRel.Rows(iCont_02).Item("QT_LINHA_B"), 0) + .Item("QT_KG_LIQUIDO_NF")
                    oDataRel.Rows(iCont_02).Item("VL_LINHA_B") = NVL(oDataRel.Rows(iCont_02).Item("VL_LINHA_B"), 0) + NVL(.Item("VL_NF"), 0)
                End If
            End With
        Next

        Return oDataRel
    End Function

    Public Function Gera_Relatorio_IndustrializacaoValorializacao(ByVal DataInicial As String, _
                                                                  ByVal DataFinal As String) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oDataRel As DataTable
        Dim sFiltro As String = ""

        sFiltro = "Período de " & DataInicial & " a " & DataFinal

        oDataRel = Gera_Data_IndustrializacaoValorializacao(DataInicial, DataFinal)

        oRelatorio.Load(Application.StartupPath & "\RPT_Industrializacao_Valorizacao.rpt")
        oRelatorio.SetDataSource(oDataRel)

        oRelatorio.SetParameterValue("VL_MEDIO_RD", PrecoMedioRD(DataFinal))
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        oRelatorio.SetParameterValue("Filtro", sFiltro)

        Return oRelatorio
    End Function

    Public Function Gera_Relatorio_Cacau_Aordem_Valorizacao(ByVal ListagemFilial As String, _
                                                            ByVal Bolsa As Double, _
                                                            ByVal ValorDif As Double, _
                                                            ByVal Dolar As Double, _
                                                            ByVal NegociacaoBolsa As Boolean) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim Cdfilial As String = ""
        Dim sFiltro As String
        Dim oData As DataTable

        sFiltro = ""

        If Trim(ListagemFilial) <> "" Then
            Cdfilial = ListagemFilial
        Else
            Cdfilial = ListarIDFiliaisLiberadaUsuario()
        End If

        If NegociacaoBolsa Then
            oData = Gera_RS_Neg_A_Ordem(Cdfilial)
        Else
            oData = Gera_Rs_Cacau_A_Ordem(Cdfilial, False, False, Now.Date, False, False, False, False, , True)
        End If

        sFiltro = "Bolsa U$ " & Bolsa & "  Diferencial U$" & ValorDif & "  Dolar U$ " & Dolar

        'oRelatorio.Load(Application.StartupPath & "\RPT_Cacau_A_Ordem_Variacao.rpt")
        oRelatorio.Load(Application.StartupPath & "\RPT_Cacau_A_Ordem_Revalorizacao.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("ValorAtual", Math.Round((((Bolsa + ValorDif) * Dolar) / 1000), 4))
        oRelatorio.SetParameterValue("ValorDolar", Dolar)
        'oRelatorio.SetParameterValue("ValorDif", ValorDif)
        oRelatorio.SetParameterValue("Tipo", IIf(NegociacaoBolsa, "B", "M"))
        oRelatorio.SetParameterValue("ValorBolsa", Bolsa)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        Return oRelatorio
    End Function

    Public Function Gera_Data_ProvisaoNFComplementar(ByVal Fornecedor As Integer, _
                                                     ByVal ListagemFilial As String) As DataTable
        Dim oData As DataTable
        Dim oDataAux As DataTable
        Dim SqlText As String
        Dim SqlText_CtrAberto As String
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim VL_FIXO As Double
        Dim dAUX As Double
        Dim bAchou As Boolean

        SqlText_CtrAberto = "SELECT CD_CONTRATO_PAF, SQ_NEGOCIACAO, SQ_CONTRATO_FIXO FROM SOF.CONTRATO_FIXO WHERE IC_STATUS = 'A'"

        'Carrega as movimentações que precisam de NF Complementar
        '"ROUND(SUM(PMF.QT_KG_FIXO * (FIX.VL_UNITARIO / TPU.QT_FATOR)), 2) VL_CONTRATO," & _

        SqlText = "SELECT FNC.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "FIX.DT_CONTRATO_FIXO," & _
                         "MOV.DT_MOVIMENTACAO," & _
                         "TRIM(PMF.CD_CONTRATO_PAF) || '-' || TRIM(PMF.SQ_NEGOCIACAO) || '-' || TRIM(PMF.SQ_CONTRATO_FIXO) CD_CONTRATO," & _
                         "FIX.VL_UNITARIO," & _
                         "TRIM(MOV.NU_NF) || NVL2(MOV.NU_SERIE_NF, '-' || TRIM(MOV.NU_SERIE_NF), '') NU_NF," & _
                         "SUM(PMF.QT_KG_FIXO) QT_KG_NF," & _
                         "SUM(PMF.VL_FIXO) VL_NF," & _
                         "ROUND(SUM(PMF.QT_KG_FIXO * ((ROUND((ROUND(((FIX.VL_TOTAL + NVL(FIX.VL_ICMS, 0)) / FIX.QT_KGS) * (FIX.QT_KGS - FIX.QT_CANCELADO), 2) + FIX.VL_ADENDO + NVL(FIX.VL_ADENDO_ICMS, 0)) / DECODE(NVL(FIX.VL_INSS, 0), 0, 1, 0.977), 2)) / (DECODE(FIX.QT_KGS - FIX.QT_CANCELADO, 0, 1, FIX.QT_KGS - FIX.QT_CANCELADO)))), 2) VL_CONTRATO," & _
                         "FIX.VL_TAXA_DOLAR TX_DOLAR," & _
                         "PMF.SQ_MOVIMENTACAO" & _
                  " FROM (" & SqlText_CtrAberto & ") CAB," & _
                        "SOF.CTR_PAF_NEG_CTR_FIX_MOV PMF," & _
                        "SOF.TIPO_UNIDADE TPU," & _
                        "SOF.CONTRATO_FIXO FIX," & _
                        "SOF.CONTRATO_PAF PAF," & _
                        "SOF.MOVIMENTACAO MOV," & _
                        "SOF.TAXA_DOLAR TD," & _
                        "SOF.FORNECEDOR FNC," & _
                        "SOF.PARAMETRO_MODALIDADE_TIPO_MOV PMT" & _
                  " WHERE PMF.CD_CONTRATO_PAF = CAB.CD_CONTRATO_PAF" & _
                    " AND PMF.SQ_NEGOCIACAO = CAB.SQ_NEGOCIACAO" & _
                    " AND PMF.SQ_CONTRATO_FIXO = CAB.SQ_CONTRATO_FIXO" & _
                    " AND FIX.CD_CONTRATO_PAF = PMF.CD_CONTRATO_PAF" & _
                    " AND FIX.SQ_NEGOCIACAO = PMF.SQ_NEGOCIACAO" & _
                    " AND FIX.SQ_CONTRATO_FIXO = PMF.SQ_CONTRATO_FIXO" & _
                    " AND PAF.CD_CONTRATO_PAF = PMF.CD_CONTRATO_PAF" & _
                    " AND FNC.CD_FORNECEDOR = PAF.CD_FORNECEDOR" & _
                    " AND FNC.CD_TIPO_PESSOA NOT IN (" & cnt_TipoPessoa_IMPORTADO & ")" & _
                    " AND TPU.CD_TIPO_UNIDADE = FIX.CD_TIPO_UNIDADE" & _
                    " AND MOV.SQ_MOVIMENTACAO = PMF.SQ_MOVIMENTACAO" & _
                    " AND PMT.CD_TIPO_MOVIMENTACAO = MOV.CD_TIPO_MOVIMENTACAO" & _
                    " AND PMT.CD_PARAMETRO_MODALIDADE = " & cnt_ParametroModalidade_BranchesRecebimento & _
                    " AND TD.DT_COTACAO (+) = MOV.DT_MOVIMENTACAO"

        If Fornecedor > 0 Then
            SqlText = SqlText & " AND FNC.CD_FORNECEDOR = " & Fornecedor
        End If
        If Trim(ListagemFilial) <> "" Then
            SqlText = SqlText & " AND FNC.CD_FILIAL_ORIGEM IN (" & ListagemFilial & ")"
        End If

        SqlText = SqlText & _
                 " GROUP BY FNC.NO_RAZAO_SOCIAL," & _
                           "FIX.DT_CONTRATO_FIXO," & _
                           "MOV.DT_MOVIMENTACAO," & _
                           "FIX.VL_UNITARIO," & _
                           "TRIM(MOV.NU_NF) || NVL2(MOV.NU_SERIE_NF, '-' || TRIM(MOV.NU_SERIE_NF), '')," & _
                           "TRIM(PMF.CD_CONTRATO_PAF) || '-' || TRIM(PMF.SQ_NEGOCIACAO) || '-' || TRIM(PMF.SQ_CONTRATO_FIXO)," & _
                           "PMF.SQ_MOVIMENTACAO," & _
                           "FIX.VL_TAXA_DOLAR " & _
                 " ORDER BY FNC.NO_RAZAO_SOCIAL," & _
                           "TRIM(PMF.CD_CONTRATO_PAF) || '-' || TRIM(PMF.SQ_NEGOCIACAO) || '-' || TRIM(PMF.SQ_CONTRATO_FIXO)," & _
                           "MOV.DT_MOVIMENTACAO"
        '" HAVING SUM(PMF.VL_FIXO) <> ROUND(SUM(PMF.QT_KG_FIXO * ((ROUND((ROUND(((FIX.VL_TOTAL + NVL(FIX.VL_ICMS, 0)) / FIX.QT_KGS) * (FIX.QT_KGS - FIX.QT_CANCELADO), 2) + FIX.VL_ADENDO + NVL(FIX.VL_ADENDO_ICMS, 0)) / DECODE(NVL(FIX.VL_INSS, 0), 0, 1, 0.977), 2)) / ((FIX.QT_KGS - FIX.QT_CANCELADO)))), 2)" & _
        '" HAVING SUM(PMF.VL_FIXO) <> ROUND(SUM(PMF.QT_KG_FIXO * (FIX.VL_UNITARIO / TPU.QT_FATOR)), 2)" & _
        oData = DBQuery(SqlText)

        'Carregar as NF Complementar
        SqlText = "SELECT TRIM(PMF.CD_CONTRATO_PAF) || '-' || TRIM(PMF.SQ_NEGOCIACAO) || '-' || TRIM(PMF.SQ_CONTRATO_FIXO) CD_CONTRATO," & _
                         "PMF.SQ_MOVIMENTACAO," & _
                         "SUM(PMF.VL_FIXO * PMT.NR_MULTIPLICADOR) VL_FIXO" & _
                  " FROM (" & SqlText_CtrAberto & ") CAB," & _
                        "SOF.CTR_PAF_NEG_CTR_FIX_MOV PMF," & _
                        "SOF.MOVIMENTACAO MOV," & _
                        "(SELECT CD_TIPO_MOVIMENTACAO," & _
                                "NR_ORDENACAO NR_MULTIPLICADOR" & _
                         " FROM SOF.PARAMETRO_MODALIDADE_TIPO_MOV" & _
                         " WHERE CD_PARAMETRO_MODALIDADE IN (" & cnt_ParametroModalidade_NFComplementar & "," & _
                                                                 cnt_ParametroModalidade_AjusteAplicacaoContratoFixo & ")) PMT" & _
                  " WHERE PMF.CD_CONTRATO_PAF = CAB.CD_CONTRATO_PAF" & _
                    " AND PMF.SQ_NEGOCIACAO = CAB.SQ_NEGOCIACAO" & _
                    " AND PMF.SQ_CONTRATO_FIXO = CAB.SQ_CONTRATO_FIXO" & _
                    " AND MOV.SQ_MOVIMENTACAO = PMF.SQ_MOVIMENTACAO" & _
                    " AND PMT.CD_TIPO_MOVIMENTACAO = MOV.CD_TIPO_MOVIMENTACAO" & _
                 " GROUP BY TRIM(PMF.CD_CONTRATO_PAF) || '-' || TRIM(PMF.SQ_NEGOCIACAO) || '-' || TRIM(PMF.SQ_CONTRATO_FIXO)," & _
                           "PMF.SQ_MOVIMENTACAO" & _
                 " HAVING SUM(PMF.VL_FIXO) <> 0"
        oDataAux = DBQuery(SqlText)

        iCont_02 = 0

        For iCont_02 = 0 To oDataAux.Rows.Count - 1
            VL_FIXO = oDataAux.Rows(iCont_02).Item("VL_FIXO")
            bAchou = False

            For iCont_01 = 0 To oData.Rows.Count - 1
                With oData.Rows(iCont_01)
                    If oDataAux.Rows(iCont_02).Item("CD_CONTRATO") = .Item("CD_CONTRATO") Then
                        If VL_FIXO <> 0 And (.Item("VL_CONTRATO") - .Item("VL_NF")) > 0 Then
                            bAchou = True

                            dAUX = IIf(.Item("VL_CONTRATO") - .Item("VL_NF") < VL_FIXO, .Item("VL_CONTRATO") - .Item("VL_NF"), VL_FIXO)
                            .Item("VL_NF") = .Item("VL_NF") + dAUX
                            VL_FIXO = VL_FIXO - dAUX

                            If VL_FIXO = 0 Then
                                Exit For
                            End If
                        End If
                    End If
                End With
            Next
        Next

        objData_Finalizar(oDataAux)
        iCont_01 = 0

        'Remove as NFs que não precisam de NF Complementar
        oDataAux = New DataTable
        oDataAux = oData.Clone

        For iCont_01 = 0 To oData.Rows.Count - 1
            If Math.Abs(oData.Rows(iCont_01).Item("VL_CONTRATO") - oData.Rows(iCont_01).Item("VL_NF")) > 0.03 Then
                With oDataAux.Rows.Add()
                    For iCont_02 = 0 To oData.Columns.Count - 1
                        .Item(iCont_02) = oData.Rows(iCont_01).Item(iCont_02)
                    Next
                End With
            End If
        Next

        oData = oDataAux

        REL_ProvisaoNFComplementar_ExcluirValorBaixos(oData)

        Return oData
    End Function

    Public Function Gera_Relatorio_ProvisaoNFComplementar(ByVal Fornecedor As Integer, _
                                                          ByVal ListagemFilial As String) As CrystalReportDocument
        Dim oRelatorio As New CrystalReportDocument
        Dim oData As DataTable
        Dim sFiltro As String = ""

        If Fornecedor > 0 Then
            Str_Adicionar(sFiltro, "Fornecedor: " & MontaFiltro_Fornecedor(Fornecedor), " - ")
        End If
        If Trim(ListagemFilial) <> "" Then
            Str_Adicionar(sFiltro, "Filial do Fornecedor: " & MontaFiltro_Filial(ListagemFilial), " - ")
        End If

        oData = Gera_Data_ProvisaoNFComplementar(Fornecedor, ListagemFilial)

        oRelatorio.Load(Application.StartupPath & "\RPT_ProvisaoNFComplementar.rpt")
        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        Return oRelatorio
    End Function

    Private Sub REL_ProvisaoNFComplementar_ExcluirValorBaixos(ByRef oData As DataTable)
        Dim dData_Contrato As New DataTable
        Dim oRow As DataRow
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim bAchou As Boolean
        Dim VL_COMPLEMENTO_NF As Double

        dData_Contrato.Columns.Add("CD_CONTRATO")
        dData_Contrato.Columns.Add("VL_COMPLEMENTO_NF").DataType = System.Type.GetType("System.Double")

        'Calcula a qtde do contrato
        For iCont_01 = 0 To oData.Rows.Count - 1
            bAchou = False

            With oData.Rows(iCont_01)
                VL_COMPLEMENTO_NF = NVL(.Item("VL_CONTRATO"), 0) - NVL(.Item("VL_NF"), 0)

                For iCont_02 = 0 To dData_Contrato.Rows.Count - 1
                    If dData_Contrato.Rows(iCont_02).Item("CD_CONTRATO") = .Item("CD_CONTRATO") Then
                        dData_Contrato.Rows(iCont_02).Item("VL_COMPLEMENTO_NF") = NVL(dData_Contrato.Rows(iCont_02).Item("VL_COMPLEMENTO_NF"), 0) + _
                                                                                  VL_COMPLEMENTO_NF
                        bAchou = True
                        Exit For
                    End If
                Next

                If Not bAchou Then
                    oRow = dData_Contrato.NewRow
                    dData_Contrato.Rows.Add(oRow)

                    oRow.Item("CD_CONTRATO") = .Item("CD_CONTRATO")
                    oRow.Item("VL_COMPLEMENTO_NF") = VL_COMPLEMENTO_NF
                End If
            End With
        Next

        'Retira os contratos com quantidades baixa
        For iCont_01 = 0 To dData_Contrato.Rows.Count - 1
            If Math.Abs(dData_Contrato.Rows(iCont_01).Item("VL_COMPLEMENTO_NF")) <= 0.1 Then
                iCont_02 = 0

                Do While iCont_02 < oData.Rows.Count
                    With oData.Rows(iCont_02)
                        If .Item("CD_CONTRATO") = dData_Contrato.Rows(iCont_01).Item("CD_CONTRATO") Then
                            oData.Rows.RemoveAt(iCont_02)
                        Else
                            iCont_02 = iCont_02 + 1
                        End If
                    End With
                Loop
            End If
        Next
    End Sub

    Private Function MontaFiltro_Filial(ByVal sFiliais As String) As String
        Return DBQuery_ValorUnico_Lista("SELECT TRIM(NO_FILIAL) FROM SOF.FILIAL WHERE CD_FILIAL IN (" & sFiliais & ") ORDER BY NO_FILIAL")
    End Function

    Private Function MontaFiltro_TipoContratoPAF(ByVal sTipoContratoPAF As String) As String
        Return DBQuery_ValorUnico_Lista("SELECT TRIM(NO_TIPO_CONTRATO_PAF) FROM SOF.TIPO_CONTRATO_PAF WHERE CD_TIPO_CONTRATO_PAF IN (" & sTipoContratoPAF & ")")
    End Function

    Private Function MontaFiltro_Fornecedor(ByVal Fornecedor As Integer) As String
        Return DBQuery_ValorUnico_Lista("SELECT TRIM(NO_RAZAO_SOCIAL) FROM SOF.FORNECEDOR WHERE CD_FORNECEDOR = " & Fornecedor)
    End Function

    Private Function MontaFiltro_Armazem(ByVal Armazem As Integer) As String
        Return DBQuery_ValorUnico_Lista("SELECT TRIM(NO_ARMAZEM) FROM SOF.ARMAZEM WHERE CD_ARMAZEM = " & Armazem)
    End Function
End Module