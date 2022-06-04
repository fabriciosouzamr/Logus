Module MOD_Impressao
    Public Function Gera_Rs_Impressao_Contrato_PAF(ByVal CD_Contrato_PAF As Long, _
                                                   ByRef IC_Adiantamento As String, _
                                                   ByRef bFornecedorBeneficiado As Boolean) As DataTable
        Dim SqlText As String
        Dim oData As New DataTable
        Dim oData_C As New DataTable
        Dim oData_Q As New DataTable
        Dim oData_E As New DataTable
        Dim oRow As DataRow

        Dim mDsQualidade As String
        Dim mDsTipoQualidade As String
        Dim mDsQualidade_Min As String
        Dim mDsQualidade_Max As String

        Dim IC_TipoJuros As String

        IC_Adiantamento = "N"

        oData = New DataTable

        With oData.Columns
            .Add("CD_CONTRATO_PAF").DataType = System.Type.GetType("System.Int32")
            .Add("DT_CONTRATO_PAF").DataType = System.Type.GetType("System.DateTime")
            .Add("NO_RAZAO_FILIAL_EMISSOR")
            .Add("NU_CGC_FILIAL_EMISSOR")
            .Add("DS_ENDERECO_FILIAL_EMISSAO")
            .Add("NO_CIDADE_FILIAL_EMISSAO")
            .Add("CD_UF_FILIAL_EMISSOR")
            .Add("NO_RAZAO_SOCIAL")
            .Add("NU_CGC_CPF")
            .Add("DS_ENDERECO_FORNECEDOR")
            .Add("NO_BAIRRO_FORNECEDOR")
            .Add("NO_CIDADE_FORNECEDOR")
            .Add("CD_UF_FORNECEDOR")
            .Add("QT_KGS").DataType = System.Type.GetType("System.Double")
            .Add("NO_UF_ORIGEM")
            .Add("NO_TIPO_ACONDICIONAMENTO")
            .Add("NO_TIPO_QUALIDADE")
            .Add("DS_TIPO_QUALIDADE")
            .Add("VL_TIPO_QUALIDADE_MIN")
            .Add("VL_TIPO_QUALIDADE_MAX")
            .Add("NO_TIPO_CONTRATO_PAF")
            .Add("NO_TIPO_CONDICAO_PAGAMENTO")
            .Add("DT_VENCIMENTO")
            .Add("NO_TIPO_MODALIDADE_ENTREGA")
            .Add("NO_LOCAL_CONFERENCIA_PESO")
            .Add("NO_LOCAL_CONFERENCIA_QUALIDADE")
            .Add("NO_RAZAO_FILIAL_NF")
            .Add("NU_CGC_FILIAL_NF")
            .Add("DS_ENDERECO_FILIAL_NF")
            .Add("NO_CIDADE_FILIAL_NF")
            .Add("CD_UF_FILIAL_NF")
            .Add("IC_FISICA_JURIDICA")
            .Add("PC_TAXA_JUROS").DataType = System.Type.GetType("System.Double")
            .Add("DT_PRAZO_FIXACAO")
            .Add("VL_ADIANTAMENTO").DataType = System.Type.GetType("System.Double")
            .Add("IC_TIPO_JUROS")
            .Add("DS_PERIODO_ENTREGA")
        End With

        SqlText = "SELECT CP.CD_CONTRATO_PAF," & _
                         "CP.DT_CONTRATO_PAF," & _
                         "FIL.NO_RAZAO NO_RAZAO_FILIAL_EMISSOR," & _
                         "FIL.NU_CGC NU_CGC_FILIAL_EMISSOR," & _
                         "FIL.DS_ENDERECO DS_ENDERECO_FILIAL_EMISSAO," & _
                         "MFIL.NO_CIDADE NO_CIDADE_FILIAL_EMISSAO," & _
                         "MFIL.CD_UF CD_UF_FILIAL_EMISSOR," & _
                         "F.NO_RAZAO_SOCIAL," & _
                         "F.NU_CGC_CPF," & _
                         "F.DS_ENDERECO DS_ENDERECO_FORNECEDOR," & _
                         "F.NO_BAIRRO NO_BAIRRO_FORNECEDOR," & _
                         "MFORN.NO_CIDADE NO_CIDADE_FORNECEDOR," & _
                         "MFORN.CD_UF CD_UF_FORNECEDOR," & _
                         "NVL(CA.QT_KGS_OLD, CP.QT_KGS) QT_KGS," & _
                         "MUNIC.NO_CIDADE || ' - ' || MUNIC.CD_UF AS NO_UF_ORIGEM," & _
                         "TA.DS_TEXTO_CONTRATO NO_TIPO_ACONDICIONAMENTO," & _
                         "TQ.NO_TIPO_QUALIDADE," & _
                         "TCP.DS_TEXTO_CONTRATO NO_TIPO_CONTRATO_PAF," & _
                         "TCPAG.NO_TIPO_CONDICAO_PAGAMENTO," & _
                         "CP.DT_VENCIMENTO," & _
                         "TME.NO_TIPO_MODALIDADE_ENTREGA," & _
                         "LCP.NO_LOCAL_CONFERENCIA NO_LOCAL_CONFERENCIA_PESO," & _
                         "LCQ.NO_LOCAL_CONFERENCIA NO_LOCAL_CONFERENCIA_QUALIDADE," & _
                         "FILENT.NO_RAZAO NO_RAZAO_FILIAL_NF," & _
                         "FILENT.NU_CGC NU_CGC_FILIAL_NF," & _
                         "FILENT.DS_ENDERECO DS_ENDERECO_FILIAL_NF," & _
                         "MFILE.NO_CIDADE NO_CIDADE_FILIAL_NF," & _
                         "MFILE.CD_UF CD_UF_FILIAL_NF," & _
                         "F.IC_FISICA_JURIDICA," & _
                         "CP.CD_TIPO_QUALIDADE," & _
                         "TCP.IC_ADIANTAMENTO," & _
                         "CP.PC_TAXA_JUROS," & _
                         "NVL(CA.DT_PRAZO_FIXACAO_OLD, CP.DT_PRAZO_FIXACAO) DT_PRAZO_FIXACAO," & _
                         "CP.VL_ADIANTAMENTO," & _
                         "NVL(CA.DT_PRAZO_ENTREGA_OLD, CP.DT_PRAZO_ENTREGA) DT_PRAZO_ENTREGA," & _
                         "PR.IC_JUROS_AUTOMATICO," & _
                         "'N' IC_JUROS_NEG," & _
                         "'N' IC_JUROS_CTR_FIX," & _
                         "'S' IC_JUROS_NEG_REC," & _
                         "CP.IC_CALCULA_JUROS," & _
                         "CP.IC_JUROS_NEG IC_JUROS_NEG_CP," & _
                         "CP.IC_JUROS_CTR_FIX IC_JUROS_CTR_FIX_CP," & _
                         "CP.IC_JUROS_NEG_REC IC_JUROS_NEG_REC_CP," & _
                         "CP.CD_FORNECEDOR_BENEFICIADO" & _
                  " FROM SOF.CONTRATO_PAF CP," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.MUNICIPIO MUNIC," & _
                        "SOF.TIPO_ACONDICIONAMENTO TA," & _
                        "SOF.TIPO_QUALIDADE TQ," & _
                        "SOF.TIPO_CONTRATO_PAF TCP," & _
                        "SOF.TIPO_MODALIDADE_ENTREGA TME," & _
                        "SOF.LOCAL_CONFERENCIA LCQ," & _
                        "SOF.LOCAL_CONFERENCIA LCP," & _
                        "SOF.FILIAL FILENT," & _
                        "SOF.MUNICIPIO MFIL," & _
                        "SOF.MUNICIPIO MFILE," & _
                        "SOF.MUNICIPIO MFORN," & _
                        "SOF.TIPO_CONDICAO_PAGAMENTO TCPAG," & _
                        "SOF.PARAMETRO PR," & _
                        "(SELECT * " & _
                         " FROM SOF.CONTRATO_ADITIVO" & _
                         " WHERE SQ_NEGOCIACAO IS NULL" & _
                           " AND SQ_ADITIVO = 1) CA" & _
                  " WHERE FIL.CD_FILIAL = CP.CD_FILIAL_ORIGEM" & _
                    " AND CA.CD_CONTRATO_PAF (+) = CP.CD_CONTRATO_PAF" & _
                    " AND F.CD_FORNECEDOR = CP.CD_FORNECEDOR" & _
                    " AND MUNIC.CD_MUNICIPIO (+) = CP.CD_MUNICIPIO" & _
                    " AND TA.CD_TIPO_ACONDICIONAMENTO = CP.CD_TIPO_ACONDICIONAMENTO" & _
                    " AND TQ.CD_TIPO_QUALIDADE = CP.CD_TIPO_QUALIDADE" & _
                    " AND TCP.CD_TIPO_CONTRATO_PAF = CP.CD_TIPO_CONTRATO_PAF" & _
                    " AND TME.CD_TIPO_MODALIDADE_ENTREGA = CP.CD_TIPO_MODALIDADE_ENTREGA" & _
                    " AND LCQ.CD_LOCAL_CONFERENCIA = CP.CD_LOCAL_CONFERENCIA_QUALIDADE" & _
                    " AND LCP.CD_LOCAL_CONFERENCIA = CP.CD_LOCAL_CONFERENCIA_PESO" & _
                    " AND FILENT.CD_FILIAL = CP.CD_FILIAL_NF" & _
                    " AND FIL.CD_MUNICIPIO = MFIL.CD_MUNICIPIO" & _
                    " AND F.CD_MUNICIPIO = MFORN.CD_MUNICIPIO" & _
                    " AND FILENT.CD_MUNICIPIO = MFILE.CD_MUNICIPIO" & _
                    " AND CP.CD_TIPO_CONDICAO_PAGAMENTO = TCPAG.CD_TIPO_CONDICAO_PAGAMENTO" & _
                    " AND CP.Cd_Contrato_PAF = " & CD_Contrato_PAF
        oData_C = DBQuery(SqlText)

        If oData_C.Rows.Count > 0 Then
            IC_Adiantamento = oData_C.Rows(0).Item("IC_ADIANTAMENTO")

            'SqlText = "SELECT DISTINCT NVL(ACF.NO_SIGLA, ANL.NO_ANALISE) NO_ANALISE," & _
            '                          "SOF.FC_ANALISE_CONFIGURACAO_VALOR(ACF.CD_PROCESSO, ACF.CD_ANALISE, 'D', " & QuotedStr(Date_to_Oracle(oData_C.Rows(0).Item("DT_CONTRATO_PAF"))) & ") VL_ANALISE_DESEJADA," & _
            '                          "SOF.FC_ANALISE_CONFIGURACAO_VALOR(ACF.CD_PROCESSO, ACF.CD_ANALISE, 'M', " & QuotedStr(Date_to_Oracle(oData_C.Rows(0).Item("DT_CONTRATO_PAF"))) & ") VL_ANALISE_MAXIMA" & _
            '          " FROM SOF.ANALISE_CONFIGURACAO ACF," & _
            '                "SOF.ANALISE ANL" & _
            '          " WHERE ACF.CD_PROCESSO = " & cnt_Processo_Contratos & _
            '            " AND ANL.CD_ANALISE = ACF.CD_ANALISE" & _
            '            " AND SOF.FC_ANALISE_CONFIGURACAO_VALOR(ACF.CD_PROCESSO, ACF.CD_ANALISE, 'D', SYSDATE) IS NOT NULL OR" & _
            '            " AND SOF.FC_ANALISE_CONFIGURACAO_VALOR(ACF.CD_PROCESSO, ACF.CD_ANALISE, 'M', SYSDATE) IS NOT NULL)" & _
            '          " ORDER BY NVL(ACF.NO_SIGLA, ANL.NO_ANALISE)"
            'oData_Q = DBQuery(SqlText)

            If oData_C.Rows(0).Item("DT_CONTRATO_PAF") <= New Date(2009, 9, 30) Then
                mDsTipoQualidade = oData_C.Rows(0).Item("NO_TIPO_QUALIDADE")

                mDsQualidade = PadR("Qualidades", 30, " ")
                mDsQualidade_Min = "Mínimo"
                mDsQualidade_Max = "Máximo"

                Str_Adicionar(mDsQualidade, PadR("ACHATADA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "10.10 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("ARDOSIA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "10.10 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("DANOS POR INSETOS", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "8.1 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("FUMACA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "6.10 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("GERMINADAS", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "8.1 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("MOFO", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "10.10 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "", vbCrLf)
            ElseIf oData_C.Rows(0).Item("DT_CONTRATO_PAF") <= New Date(2010, 5, 31) Then
                mDsTipoQualidade = " "

                mDsQualidade = PadR("Qualidades", 30, " ")
                mDsQualidade_Min = "Mínimo"
                mDsQualidade_Max = "Máximo"

                Str_Adicionar(mDsQualidade, PadR("ACHATADA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "10 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("ARDOSIA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "10 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("FUMACA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "6 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("MOFO", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "10 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("SUJIDADE", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "0.83 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("UMIDADE", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "9 %", vbCrLf)
            Else
                mDsTipoQualidade = " "

                mDsQualidade = PadR("Item", 20, " ")
                mDsQualidade_Min = "Padrão (% por tonelada métrica)"
                mDsQualidade_Max = "Máximo aceitável"

                Str_Adicionar(mDsQualidade, PadR("ACHATADA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "0.00 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "7.00 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("ARDOSIA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "0.00 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "10.00 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("FUMACA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "0.00 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "6.00 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("MOFO", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "0.00 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "10.00 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("SUJIDADE", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "0.83 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "2.00 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("UMIDADE", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "9.00 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "10.50 %", vbCrLf)
            End If

            IC_TipoJuros = "?"

            If oData_C.Rows(0).Item("IC_JUROS_AUTOMATICO") = "S" Then
                If oData_C.Rows(0).Item("IC_JUROS_NEG") = "S" Then
                    IC_TipoJuros = "N"
                End If
                If oData_C.Rows(0).Item("IC_JUROS_CTR_FIX") = "S" Then
                    IC_TipoJuros = "C"
                End If
                If oData_C.Rows(0).Item("IC_JUROS_NEG_REC") = "S" Then
                    IC_TipoJuros = "R"
                    If oData_C.Rows(0).Item("IC_CALCULA_JUROS") = "S" Then
                        If oData_C.Rows(0).Item("IC_JUROS_NEG_CP") = "S" Then
                            IC_TipoJuros = "N"
                        End If
                        If oData_C.Rows(0).Item("IC_JUROS_CTR_FIX_CP") = "S" Then
                            IC_TipoJuros = "C"
                        End If
                    End If
                End If
            End If

            oRow = oData.NewRow

            oRow.Item("CD_CONTRATO_PAF") = oData_C.Rows(0).Item("CD_CONTRATO_PAF")
            oRow.Item("DT_CONTRATO_PAF") = oData_C.Rows(0).Item("DT_CONTRATO_PAF")

            'gera o contrato do beneficiario
            If bFornecedorBeneficiado = False Then
                oRow.Item("NO_RAZAO_FILIAL_EMISSOR") = oData_C.Rows(0).Item("NO_RAZAO_FILIAL_EMISSOR")
                oRow.Item("NU_CGC_FILIAL_EMISSOR") = oData_C.Rows(0).Item("NU_CGC_FILIAL_EMISSOR")
                oRow.Item("DS_ENDERECO_FILIAL_EMISSAO") = oData_C.Rows(0).Item("DS_ENDERECO_FILIAL_EMISSAO")
                oRow.Item("NO_CIDADE_FILIAL_EMISSAO") = oData_C.Rows(0).Item("NO_CIDADE_FILIAL_EMISSAO")
                oRow.Item("CD_UF_FILIAL_EMISSOR") = oData_C.Rows(0).Item("CD_UF_FILIAL_EMISSOR")
                oRow.Item("NO_RAZAO_SOCIAL") = oData_C.Rows(0).Item("NO_RAZAO_SOCIAL")
                oRow.Item("NU_CGC_CPF") = oData_C.Rows(0).Item("NU_CGC_CPF")
                oRow.Item("DS_ENDERECO_FORNECEDOR") = oData_C.Rows(0).Item("DS_ENDERECO_FORNECEDOR")
                oRow.Item("NO_BAIRRO_FORNECEDOR") = oData_C.Rows(0).Item("NO_BAIRRO_FORNECEDOR")
                oRow.Item("NO_CIDADE_FORNECEDOR") = oData_C.Rows(0).Item("NO_CIDADE_FORNECEDOR")
                oRow.Item("CD_UF_FORNECEDOR") = oData_C.Rows(0).Item("CD_UF_FORNECEDOR")
            Else
                SqlText = "SELECT FRN.NO_RAZAO_SOCIAL," & _
                                 "FRN.NU_CGC_CPF," & _
                                 "FRN.DS_ENDERECO DS_ENDERECO_FORNECEDOR," & _
                                 "FRN.NO_BAIRRO NO_BAIRRO_FORNECEDOR," & _
                                 "MNC.NO_CIDADE NO_CIDADE_FORNECEDOR," & _
                                 "MNC.CD_UF CD_UF_FORNECEDOR" & _
                          " FROM SOF.FORNECEDOR FRN," & _
                                "SOF.MUNICIPIO MNC" & _
                          " WHERE FRN.CD_MUNICIPIO = MNC.CD_MUNICIPIO" & _
                            " AND FRN.CD_FORNECEDOR = " & oData_C.Rows(0).Item("CD_FORNECEDOR_BENEFICIADO")
                oData_E = DBQuery(SqlText)

                oRow.Item("NO_RAZAO_FILIAL_EMISSOR") = oData_C.Rows(0).Item("NO_RAZAO_SOCIAL")
                oRow.Item("NU_CGC_FILIAL_EMISSOR") = oData_C.Rows(0).Item("NU_CGC_CPF")
                oRow.Item("DS_ENDERECO_FILIAL_EMISSAO") = oData_C.Rows(0).Item("DS_ENDERECO_FORNECEDOR")
                oRow.Item("NO_CIDADE_FILIAL_EMISSAO") = oData_C.Rows(0).Item("NO_CIDADE_FORNECEDOR")
                oRow.Item("CD_UF_FILIAL_EMISSOR") = oData_C.Rows(0).Item("CD_UF_FORNECEDOR")
                oRow.Item("NO_RAZAO_SOCIAL") = oData_E.Rows(0).Item("NO_RAZAO_SOCIAL")
                oRow.Item("NU_CGC_CPF") = oData_E.Rows(0).Item("NU_CGC_CPF")
                oRow.Item("DS_ENDERECO_FORNECEDOR") = oData_E.Rows(0).Item("DS_ENDERECO_FORNECEDOR")
                oRow.Item("NO_BAIRRO_FORNECEDOR") = oData_E.Rows(0).Item("NO_BAIRRO_FORNECEDOR")
                oRow.Item("NO_CIDADE_FORNECEDOR") = oData_E.Rows(0).Item("NO_CIDADE_FORNECEDOR")
                oRow.Item("CD_UF_FORNECEDOR") = oData_E.Rows(0).Item("CD_UF_FORNECEDOR")

                oData_E.Dispose()
            End If

            oRow.Item("QT_KGS") = oData_C.Rows(0).Item("QT_KGS")
            oRow.Item("NO_UF_ORIGEM") = oData_C.Rows(0).Item("NO_UF_ORIGEM")
            oRow.Item("NO_TIPO_ACONDICIONAMENTO") = oData_C.Rows(0).Item("NO_TIPO_ACONDICIONAMENTO")
            oRow.Item("NO_TIPO_QUALIDADE") = mDsTipoQualidade
            oRow.Item("DS_TIPO_QUALIDADE") = mDsQualidade
            oRow.Item("VL_TIPO_QUALIDADE_MIN") = mDsQualidade_Min
            oRow.Item("VL_TIPO_QUALIDADE_MAX") = mDsQualidade_Max
            oRow.Item("NO_TIPO_CONTRATO_PAF") = oData_C.Rows(0).Item("NO_TIPO_CONTRATO_PAF")
            oRow.Item("NO_TIPO_CONDICAO_PAGAMENTO") = oData_C.Rows(0).Item("NO_TIPO_CONDICAO_PAGAMENTO")
            oRow.Item("DT_VENCIMENTO") = oData_C.Rows(0).Item("DT_PRAZO_ENTREGA")
            oRow.Item("NO_TIPO_MODALIDADE_ENTREGA") = oData_C.Rows(0).Item("NO_TIPO_MODALIDADE_ENTREGA")
            oRow.Item("NO_LOCAL_CONFERENCIA_PESO") = oData_C.Rows(0).Item("NO_LOCAL_CONFERENCIA_PESO")
            oRow.Item("NO_LOCAL_CONFERENCIA_QUALIDADE") = oData_C.Rows(0).Item("NO_LOCAL_CONFERENCIA_QUALIDADE")
            oRow.Item("NO_RAZAO_FILIAL_NF") = oData_C.Rows(0).Item("NO_RAZAO_FILIAL_NF")
            oRow.Item("NU_CGC_FILIAL_NF") = oData_C.Rows(0).Item("NU_CGC_FILIAL_NF")
            oRow.Item("DS_ENDERECO_FILIAL_NF") = oData_C.Rows(0).Item("DS_ENDERECO_FILIAL_NF")
            oRow.Item("NO_CIDADE_FILIAL_NF") = oData_C.Rows(0).Item("NO_CIDADE_FILIAL_NF")
            oRow.Item("CD_UF_FILIAL_NF") = oData_C.Rows(0).Item("CD_UF_FILIAL_NF")
            oRow.Item("IC_FISICA_JURIDICA") = oData_C.Rows(0).Item("IC_FISICA_JURIDICA")
            oRow.Item("PC_TAXA_JUROS") = oData_C.Rows(0).Item("PC_TAXA_JUROS")
            oRow.Item("DT_PRAZO_FIXACAO") = oData_C.Rows(0).Item("DT_PRAZO_FIXACAO")
            oRow.Item("VL_ADIANTAMENTO") = oData_C.Rows(0).Item("VL_ADIANTAMENTO")
            oRow.Item("IC_TIPO_JUROS") = IC_TipoJuros
            oRow.Item("DS_PERIODO_ENTREGA") = "de " & Data_Safra_Inicio(oData_C.Rows(0).Item("DT_CONTRATO_PAF")) & _
                                            " até " & Data_Safra_Fim(oData_C.Rows(0).Item("DT_CONTRATO_PAF"))

            oData.Rows.Add(oRow)
        End If

        oData_C.Dispose()

        Return oData
    End Function

    Public Function Gera_Rs_Impressao_Negociacao(ByVal CD_ContratoPAF As Long, _
                                                 ByVal SQ_Negociacao As Long, _
                                                 ByRef IC_PrecoFixo As String, _
                                                 ByRef IC_Bolsa As String, _
                                                 ByRef IC_Dolar As String, _
                                                 ByVal bFornecedorBeneficiado As Boolean) As DataTable
        Dim SqlText As String
        Dim oData As New DataTable
        Dim oData_C As DataTable
        Dim oData_Q As DataTable
        Dim oData_Fab As DataTable
        Dim oRow As DataRow
        Dim mDsTipoQualidade As String
        Dim mDsQualidade As String
        Dim mDsQualidade_Min As String = ""
        Dim mDsQualidade_Max As String = ""

        With oData.Columns
            .Add("CD_CONTRATO_PAF").DataType = System.Type.GetType("System.Int32")
            .Add("DT_CONTRATO_PAF").DataType = System.Type.GetType("System.DateTime")
            .Add("NO_RAZAO_FILIAL_EMISSOR")
            .Add("NU_CGC_FILIAL_EMISSOR")
            .Add("DS_ENDERECO_FILIAL_EMISSAO")
            .Add("NO_CIDADE_FILIAL_EMISSAO")
            .Add("CD_UF_FILIAL_EMISSOR")
            .Add("NO_RAZAO_SOCIAL")
            .Add("NU_CGC_CPF")
            .Add("DS_ENDERECO_FORNECEDOR")
            .Add("NO_BAIRRO_FORNECEDOR")
            .Add("NO_CIDADE_FORNECEDOR")
            .Add("CD_UF_FORNECEDOR")
            .Add("QT_KGS").DataType = System.Type.GetType("System.Double")
            .Add("NO_UF_ORIGEM")
            .Add("NO_TIPO_ACONDICIONAMENTO")
            .Add("NO_TIPO_QUALIDADE")
            .Add("DS_TIPO_QUALIDADE").DataType = System.Type.GetType("System.String")
            .Add("VL_TIPO_QUALIDADE_MIN").DataType = System.Type.GetType("System.String")
            .Add("VL_TIPO_QUALIDADE_MAX").DataType = System.Type.GetType("System.String")
            .Add("NO_TIPO_CONTRATO_PAF")
            .Add("NO_TIPO_CONDICAO_PAGAMENTO")
            .Add("DT_VENCIMENTO").DataType = System.Type.GetType("System.DateTime")
            .Add("NO_TIPO_MODALIDADE_ENTREGA")
            .Add("NO_LOCAL_CONFERENCIA_PESO")
            .Add("NO_LOCAL_CONFERENCIA_QUALIDADE")
            .Add("NO_RAZAO_FILIAL_NF")
            .Add("NU_CGC_FILIAL_NF")
            .Add("DS_ENDERECO_FILIAL_NF")
            .Add("NO_CIDADE_FILIAL_NF")
            .Add("CD_UF_FILIAL_NF")
            .Add("IC_FISICA_JURIDICA")
            .Add("SQ_NEGOCIACAO").DataType = System.Type.GetType("System.Int32")
            .Add("IC_FACTOR").DataType = System.Type.GetType("System.Double")
            .Add("VL_PRECO_UNITARIO").DataType = System.Type.GetType("System.Double")
            .Add("IC_BOLSA")
            .Add("IC_BOLSA_OPERACAO")
            .Add("IC_DOLAR")
            .Add("IC_TIPO_PRECO_FIXO")
            .Add("NO_PAPEL")
            .Add("PC_TAXA_JUROS").DataType = System.Type.GetType("System.Double")
            .Add("DT_PRAZO_FIXACAO").DataType = System.Type.GetType("System.DateTime")
            .Add("IC_IMPRIME_CTR_PAF")
        End With

        SqlText = "SELECT FIL.NO_RAZAO," & _
                         "FIL.NU_CGC," & _
                         "FIL.DS_ENDERECO," & _
                         "MUNIC.NO_CIDADE," & _
                         "MUNIC.CD_UF" & _
                  " FROM SOF.FILIAL FIL," & _
                        "SOF.MUNICIPIO MUNIC " & _
                  " WHERE FIL.CD_MUNICIPIO = MUNIC.CD_MUNICIPIO" & _
                    " AND FIL.CD_FILIAL IN (SELECT P.CD_FILIAL_MAE FROM SOF.PARAMETRO P)"
        oData_Fab = DBQuery(SqlText)

        SqlText = "SELECT CP.CD_CONTRATO_PAF," & _
                         "N.DT_NEGOCIACAO," & _
                         "FIL.NO_RAZAO NO_RAZAO_FILIAL_EMISSOR," & _
                         "FIL.NU_CGC NU_CGC_FILIAL_EMISSOR," & _
                         "FIL.DS_ENDERECO DS_ENDERECO_FILIAL_EMISSAO," & _
                         "MFIL.NO_CIDADE NO_CIDADE_FILIAL_EMISSAO," & _
                         "MFIL.CD_UF CD_UF_FILIAL_EMISSOR," & _
                         "F.NO_RAZAO_SOCIAL," & _
                         "F.NU_CGC_CPF, F.DS_ENDERECO DS_ENDERECO_FORNECEDOR," & _
                         "F.NO_BAIRRO NO_BAIRRO_FORNECEDOR," & _
                         "MFORN.NO_CIDADE NO_CIDADE_FORNECEDOR," & _
                         "MFORN.CD_UF CD_UF_FORNECEDOR," & _
                         "NVL(CAN.QT_KGS_OLD, N.QT_KGS) QT_KGS," & _
                         "MUNIC.NO_CIDADE || ' - ' || MUNIC.CD_UF NO_UF_ORIGEM," & _
                         "TA.DS_TEXTO_CONTRATO NO_TIPO_ACONDICIONAMENTO," & _
                         "TQ.NO_TIPO_QUALIDADE," & _
                         "TCPAG.NO_TIPO_CONDICAO_PAGAMENTO," & _
                         "N.DT_VENCIMENTO," & _
                         "LE.NO_LOCAL_ENTREGA," & _
                         "LCP.NO_LOCAL_CONFERENCIA NO_LOCAL_CONFERENCIA_PESO," & _
                         "LCQ.NO_LOCAL_CONFERENCIA NO_LOCAL_CONFERENCIA_QUALIDADE," & _
                         "FILENT.NO_RAZAO NO_RAZAO_FILIAL_NF," & _
                         "FILENT.NU_CGC NU_CGC_FILIAL_NF," & _
                         "FILENT.DS_ENDERECO DS_ENDERECO_FILIAL_NF," & _
                         "MFILE.NO_CIDADE NO_CIDADE_FILIAL_NF," & _
                         "MFILE.CD_UF CD_UF_FILIAL_NF," & _
                         "F.IC_FISICA_JURIDICA," & _
                         "CP.CD_TIPO_QUALIDADE," & _
                         "N.SQ_NEGOCIACAO," & _
                         "TU.QT_FATOR," & _
                         "NVL(CAN.VL_UNITARIO_OLD, N.VL_NEGOCIACAO) VL_NEGOCIACAO," & _
                         "TN.DS_TEXTO_CONTRATO NO_TIPO_NEGOCIACAO," & _
                         "TN.IC_BOLSA," & _
                         "TN.IC_BOLSA_OPERACAO," & _
                         "TN.IC_DOLAR," & _
                         "TN.IC_TIPO_PRECO_FIXO," & _
                         "BPM.NO_PAPEL," & _
                         "NVL(CAN.DT_PRAZO_FIXACAO_OLD, N.DT_PRAZO_FIXACAO) DT_PRAZO_FIXACAO," & _
                         "N.PC_TAXA_JUROS," & _
                         "N.CD_LOCAL_ENTREGA," & _
                         "N.IC_IMPRIME_CTR_PAF," & _
                         "CP.CD_FORNECEDOR_BENEFICIADO" & _
                  " FROM SOF.CONTRATO_PAF CP," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.MUNICIPIO MUNIC," & _
                        "SOF.TIPO_ACONDICIONAMENTO TA," & _
                        "SOF.TIPO_QUALIDADE TQ," & _
                        "SOF.LOCAL_ENTREGA LE," & _
                        "SOF.LOCAL_CONFERENCIA LCQ," & _
                        "SOF.LOCAL_CONFERENCIA LCP," & _
                        "SOF.FILIAL FILENT," & _
                        "SOF.MUNICIPIO MFIL," & _
                        "SOF.MUNICIPIO MFILE," & _
                        "SOF.MUNICIPIO MFORN," & _
                        "SOF.TIPO_CONDICAO_PAGAMENTO TCPAG," & _
                        "SOF.NEGOCIACAO N," & _
                        "SOF.TIPO_UNIDADE TU," & _
                        "SOF.TIPO_NEGOCIACAO TN," & _
                        "SOF.BOLSA_PERIODO_MATRIZ BPM," & _
                        "(SELECT *" & _
                         " FROM SOF.CONTRATO_ADITIVO" & _
                         " WHERE SQ_NEGOCIACAO IS NOT NULL" & _
                           " AND SQ_CONTRATO_FIXO IS NULL" & _
                           " AND SQ_ADITIVO = 1) CAN" & _
                  " WHERE FIL.CD_FILIAL = CP.CD_FILIAL_ORIGEM" & _
                    " AND F.CD_FORNECEDOR = CP.CD_FORNECEDOR" & _
                    " AND MUNIC.CD_MUNICIPIO (+) = CP.CD_MUNICIPIO" & _
                    " AND TA.CD_TIPO_ACONDICIONAMENTO = CP.CD_TIPO_ACONDICIONAMENTO" & _
                    " AND TQ.CD_TIPO_QUALIDADE = CP.CD_TIPO_QUALIDADE" & _
                    " AND N.CD_LOCAL_ENTREGA = LE.CD_LOCAL_ENTREGA" & _
                    " AND LCQ.CD_LOCAL_CONFERENCIA = CP.CD_LOCAL_CONFERENCIA_QUALIDADE" & _
                    " AND LCP.CD_LOCAL_CONFERENCIA = CP.CD_LOCAL_CONFERENCIA_PESO" & _
                    " AND FILENT.CD_FILIAL = CP.CD_FILIAL_NF" & _
                    " AND FIL.CD_MUNICIPIO = MFIL.CD_MUNICIPIO" & _
                    " AND F.CD_MUNICIPIO = MFORN.CD_MUNICIPIO" & _
                    " AND FILENT.CD_MUNICIPIO = MFILE.CD_MUNICIPIO" & _
                    " AND CP.CD_TIPO_CONDICAO_PAGAMENTO = TCPAG.CD_TIPO_CONDICAO_PAGAMENTO" & _
                    " AND CP.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                    " AND N.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                    " AND N.CD_TIPO_NEGOCIACAO = TN.CD_TIPO_NEGOCIACAO" & _
                    " AND N.CD_PAPEL_COMPETENCIA=BPM.CD_PAPEL (+)" & _
                    " AND N.CD_CONTRATO_PAF = " & CD_ContratoPAF & _
                    " AND N.SQ_NEGOCIACAO = " & SQ_Negociacao & _
                    " AND CAN.CD_CONTRATO_PAF (+) = N.CD_CONTRATO_PAF" & _
                    " AND CAN.SQ_NEGOCIACAO (+) = N.SQ_NEGOCIACAO"
        oData_C = DBQuery(SqlText)

        If oData_C.Rows.Count > 0 Then
            If oData_C.Rows(0).Item("DT_NEGOCIACAO") <= New Date(2009, 9, 30) Then
                mDsTipoQualidade = oData_C.Rows(0).Item("NO_TIPO_QUALIDADE")

                mDsQualidade = PadR("Qualidades", 30, " ")
                mDsQualidade_Min = "Mínimo"
                mDsQualidade_Max = "Máximo"

                Str_Adicionar(mDsQualidade, PadR("ACHATADA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "10.10", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("ARDOSIA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "10.10", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("DANOS POR INSETOS", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "8.1", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("FUMACA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "6.10", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("GERMINADAS", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "8.1", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("MOFO", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "10.10", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "", vbCrLf)
            ElseIf oData_C.Rows(0).Item("DT_NEGOCIACAO") <= New Date(2010, 11, 11) Then
                mDsTipoQualidade = " "

                mDsQualidade = PadR("Qualidades", 30, " ")
                mDsQualidade_Min = "Mínimo"
                mDsQualidade_Max = "Máximo"

                Str_Adicionar(mDsQualidade, PadR("ACHATADA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "10", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("ARDOSIA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "10", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("FUMACA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "6", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("MOFO", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "10", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("SUJIDADE", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "0.83", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("UMIDADE", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "9", vbCrLf)
            Else
                mDsTipoQualidade = " "

                mDsQualidade = PadR("Item", 20, " ")
                mDsQualidade_Min = "Padrão (% por tonelada métrica)"
                mDsQualidade_Max = "Máximo aceitável"

                Str_Adicionar(mDsQualidade, PadR("ACHATADA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "0.00 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "7.00 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("ARDOSIA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "0.00 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "10.00 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("FUMACA", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "0.00 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "6.00 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("MOFO", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "0.00 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "10.00 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("SUJIDADE", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "0.83 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "2.00 %", vbCrLf)
                Str_Adicionar(mDsQualidade, PadR("UMIDADE", 30, " "), vbCrLf) : Str_Adicionar(mDsQualidade_Min, "9.00 %", vbCrLf) : Str_Adicionar(mDsQualidade_Max, "10.50 %", vbCrLf)
            End If

            oRow = oData.NewRow
            oRow.Item("CD_CONTRATO_PAF") = oData_C.Rows(0).Item("CD_CONTRATO_PAF")
            oRow.Item("DT_CONTRATO_PAF") = oData_C.Rows(0).Item("DT_NEGOCIACAO")
            oRow.Item("QT_KGS") = oData_C.Rows(0).Item("QT_KGS")
            oRow.Item("NO_UF_ORIGEM") = oData_C.Rows(0).Item("NO_UF_ORIGEM")
            oRow.Item("NO_TIPO_ACONDICIONAMENTO") = oData_C.Rows(0).Item("NO_TIPO_ACONDICIONAMENTO")
            oRow.Item("NO_TIPO_QUALIDADE") = mDsTipoQualidade
            oRow.Item("DS_TIPO_QUALIDADE") = mDsQualidade
            oRow.Item("VL_TIPO_QUALIDADE_MIN") = mDsQualidade_Min
            oRow.Item("VL_TIPO_QUALIDADE_MAX") = mDsQualidade_Max
            oRow.Item("NO_TIPO_CONTRATO_PAF") = oData_C.Rows(0).Item("NO_TIPO_NEGOCIACAO")
            oRow.Item("NO_TIPO_CONDICAO_PAGAMENTO") = oData_C.Rows(0).Item("NO_TIPO_CONDICAO_PAGAMENTO")
            oRow.Item("DT_VENCIMENTO") = oData_C.Rows(0).Item("DT_VENCIMENTO")
            oRow.Item("NO_TIPO_MODALIDADE_ENTREGA") = oData_C.Rows(0).Item("NO_LOCAL_ENTREGA")
            oRow.Item("NO_LOCAL_CONFERENCIA_PESO") = oData_C.Rows(0).Item("NO_LOCAL_CONFERENCIA_PESO")
            oRow.Item("NO_LOCAL_CONFERENCIA_QUALIDADE") = oData_C.Rows(0).Item("NO_LOCAL_CONFERENCIA_QUALIDADE")

            'Gera o Contrato do Beneficiário
            If bFornecedorBeneficiado = False Then
                oRow.Item("NO_RAZAO_FILIAL_EMISSOR") = oData_C.Rows(0).Item("NO_RAZAO_FILIAL_EMISSOR")
                oRow.Item("NU_CGC_FILIAL_EMISSOR") = oData_C.Rows(0).Item("NU_CGC_FILIAL_EMISSOR")
                oRow.Item("DS_ENDERECO_FILIAL_EMISSAO") = oData_C.Rows(0).Item("DS_ENDERECO_FILIAL_EMISSAO")
                oRow.Item("NO_CIDADE_FILIAL_EMISSAO") = oData_C.Rows(0).Item("NO_CIDADE_FILIAL_EMISSAO")
                oRow.Item("CD_UF_FILIAL_EMISSOR") = oData_C.Rows(0).Item("CD_UF_FILIAL_EMISSOR")
                oRow.Item("NO_RAZAO_SOCIAL") = oData_C.Rows(0).Item("NO_RAZAO_SOCIAL")
                oRow.Item("NU_CGC_CPF") = oData_C.Rows(0).Item("NU_CGC_CPF")
                oRow.Item("DS_ENDERECO_FORNECEDOR") = oData_C.Rows(0).Item("DS_ENDERECO_FORNECEDOR")
                oRow.Item("NO_BAIRRO_FORNECEDOR") = oData_C.Rows(0).Item("NO_BAIRRO_FORNECEDOR")
                oRow.Item("NO_CIDADE_FORNECEDOR") = oData_C.Rows(0).Item("NO_CIDADE_FORNECEDOR")
                oRow.Item("CD_UF_FORNECEDOR") = oData_C.Rows(0).Item("CD_UF_FORNECEDOR")
            Else
                SqlText = "SELECT F.NO_RAZAO_SOCIAL, F.NU_CGC_CPF, F.DS_ENDERECO DS_ENDERECO_FORNECEDOR, "
                SqlText = SqlText & "       F.NO_BAIRRO NO_BAIRRO_FORNECEDOR, MFORN.NO_CIDADE NO_CIDADE_FORNECEDOR, "
                SqlText = SqlText & "       MFORN.CD_UF CD_UF_FORNECEDOR "
                SqlText = SqlText & "  FROM SOF.FORNECEDOR F, SOF.MUNICIPIO MFORN "
                SqlText = SqlText & " WHERE F.CD_MUNICIPIO = MFORN.CD_MUNICIPIO AND F.CD_FORNECEDOR = " & oData_C.Rows(0).Item("CD_FORNECEDOR_BENEFICIADO")

                oData_Q = DBQuery(SqlText)

                oRow.Item("NO_RAZAO_FILIAL_EMISSOR") = oData_C.Rows(0).Item("NO_RAZAO_SOCIAL")
                oRow.Item("NU_CGC_FILIAL_EMISSOR") = oData_C.Rows(0).Item("NU_CGC_CPF")
                oRow.Item("DS_ENDERECO_FILIAL_EMISSAO") = oData_C.Rows(0).Item("DS_ENDERECO_FORNECEDOR")
                oRow.Item("NO_CIDADE_FILIAL_EMISSAO") = oData_C.Rows(0).Item("NO_CIDADE_FORNECEDOR")
                oRow.Item("CD_UF_FILIAL_EMISSOR") = oData_C.Rows(0).Item("CD_UF_FORNECEDOR")
                oRow.Item("NO_RAZAO_SOCIAL") = oData_Q.Rows(0).Item("NO_RAZAO_SOCIAL")
                oRow.Item("NU_CGC_CPF") = oData_Q.Rows(0).Item("NU_CGC_CPF")
                oRow.Item("DS_ENDERECO_FORNECEDOR") = oData_Q.Rows(0).Item("DS_ENDERECO_FORNECEDOR")
                oRow.Item("NO_BAIRRO_FORNECEDOR") = oData_Q.Rows(0).Item("NO_BAIRRO_FORNECEDOR")
                oRow.Item("NO_CIDADE_FORNECEDOR") = oData_Q.Rows(0).Item("NO_CIDADE_FORNECEDOR")
                oRow.Item("CD_UF_FORNECEDOR") = oData_Q.Rows(0).Item("CD_UF_FORNECEDOR")

                oData_Q.Dispose()
            End If

            If oData_C.Rows(0).Item("CD_LOCAL_ENTREGA") = cnt_LocalEntrega_Fabrica Then
                oRow.Item("NO_RAZAO_FILIAL_NF") = oData_Fab.Rows(0).Item("NO_RAZAO")
                oRow.Item("NU_CGC_FILIAL_NF") = oData_Fab.Rows(0).Item("NU_CGC")
                oRow.Item("DS_ENDERECO_FILIAL_NF") = oData_Fab.Rows(0).Item("DS_ENDERECO")
                oRow.Item("NO_CIDADE_FILIAL_NF") = oData_Fab.Rows(0).Item("NO_CIDADE")
                oRow.Item("CD_UF_FILIAL_NF") = oData_Fab.Rows(0).Item("CD_UF")
            Else
                oRow.Item("NO_RAZAO_FILIAL_NF") = oData_C.Rows(0).Item("NO_RAZAO_FILIAL_NF")
                oRow.Item("NU_CGC_FILIAL_NF") = oData_C.Rows(0).Item("NU_CGC_FILIAL_NF")
                oRow.Item("DS_ENDERECO_FILIAL_NF") = oData_C.Rows(0).Item("DS_ENDERECO_FILIAL_NF")
                oRow.Item("NO_CIDADE_FILIAL_NF") = oData_C.Rows(0).Item("NO_CIDADE_FILIAL_NF")
                oRow.Item("CD_UF_FILIAL_NF") = oData_C.Rows(0).Item("CD_UF_FILIAL_NF")
            End If

            oRow.Item("IC_FISICA_JURIDICA") = oData_C.Rows(0).Item("IC_FISICA_JURIDICA")
            oRow.Item("SQ_NEGOCIACAO") = oData_C.Rows(0).Item("SQ_NEGOCIACAO")
            oRow.Item("IC_FACTOR") = oData_C.Rows(0).Item("QT_FATOR")
            oRow.Item("VL_PRECO_UNITARIO") = oData_C.Rows(0).Item("VL_NEGOCIACAO")
            oRow.Item("IC_BOLSA") = oData_C.Rows(0).Item("IC_BOLSA")
            oRow.Item("IC_BOLSA_OPERACAO") = oData_C.Rows(0).Item("IC_BOLSA_OPERACAO")
            oRow.Item("IC_DOLAR") = oData_C.Rows(0).Item("IC_DOLAR")
            oRow.Item("IC_TIPO_PRECO_FIXO") = oData_C.Rows(0).Item("IC_TIPO_PRECO_FIXO")
            oRow.Item("NO_PAPEL") = oData_C.Rows(0).Item("NO_PAPEL")
            oRow.Item("PC_TAXA_JUROS") = oData_C.Rows(0).Item("PC_TAXA_JUROS")
            oRow.Item("DT_PRAZO_FIXACAO") = oData_C.Rows(0).Item("DT_PRAZO_FIXACAO")
            oRow.Item("IC_IMPRIME_CTR_PAF") = oData_C.Rows(0).Item("IC_IMPRIME_CTR_PAF")
            oData.Rows.Add(oRow)

            IC_PrecoFixo = oData_C.Rows(0).Item("IC_TIPO_PRECO_FIXO")
            IC_Bolsa = oData_C.Rows(0).Item("IC_BOLSA")
            IC_Dolar = oData_C.Rows(0).Item("IC_DOLAR")
        End If

        oData_Fab.Dispose()
        oData_C.Dispose()

        Return oData
    End Function

    Public Function Impressao_ContratoPAF(ByVal CD_CONTRATO_PAF As Integer)
        Dim oData As DataTable
        Dim SqlText As String
        Dim bContrato_PAF_PrecoFixo As Boolean
        Dim CD_VERSAO_RELATORIO As enDocumento_Relatorio
        Dim bOk As Boolean = True

        SqlText = "SELECT PAF.DT_CONTRATO_PAF," & _
                         "PAF.IC_STATUS," & _
                         "PAF.CD_VERSAO_CONTRATO," & _
                         "TPC.IC_ADIANTAMENTO," & _
                         "PAF.CD_CONTRATO_PAF_ORIGEM" & _
                  " FROM SOF.CONTRATO_PAF PAF," & _
                        "SOF.TIPO_CONTRATO_PAF TPC" & _
                  " WHERE PAF.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND TPC.CD_TIPO_CONTRATO_PAF = PAF.CD_TIPO_CONTRATO_PAF"
        oData = DBQuery(SqlText)

        With oData.Rows(0)
            If .Item("IC_STATUS") = cnt_Contrato_Status_Excluido Then
                Msg_Mensagem("Contrato eliminado.")
                GoTo NaoImpresso
            End If

            CD_VERSAO_RELATORIO = NVL(.Item("CD_VERSAO_CONTRATO"), enDocumento_Relatorio.eSemImpressao)

            If CD_VERSAO_RELATORIO = enDocumento_Relatorio.eSemImpressao Then
                If NVL(.Item("IC_ADIANTAMENTO"), "N") = "N" Then
                    If Documento_Relatorio_Versao_Documento(enDocumento_Relatorio.eContratoPAF_Master, .Item("DT_CONTRATO_PAF")) = enDocumento_Relatorio.eSemImpressao Then
                        Msg_Mensagem("Não é permitido impressão de contrato para esse tipo de contrato. Favor imprimir a negociação.")
                        GoTo NaoImpresso
                    End If
                End If
            End If

            SqlText = "SELECT COUNT(*) QT" & _
                      " FROM SOF.CONFISSAO_DIVIDA_ATIVO_VENDA" & _
                      " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF
            If DBQuery_ValorUnico(SqlText) <> 0 Then
                Msg_Mensagem("Esse contrato é uma liquidação de uma recuperação de credito.")
                GoTo NaoImpresso
            End If

            bContrato_PAF_PrecoFixo = Contrato_PAF_PrecoFixo(CD_CONTRATO_PAF)

            If CD_VERSAO_RELATORIO = enDocumento_Relatorio.eCtrConfirmacaoCompraCacauAOrdem Then
                Imprimir_ContratoPAF(CD_CONTRATO_PAF, , frmRelatorioGeral.enRelGeral_Tipo.eContratoPAF_ConfCompra_CacauAOrdem)
            Else
                If CD_VERSAO_RELATORIO = enDocumento_Relatorio.eSemImpressao Then
                    If bContrato_PAF_PrecoFixo Then
                        CD_VERSAO_RELATORIO = Documento_Relatorio_Versao_Documento(enDocumento_Relatorio.eContratoPAF_PrecoFixo, .Item("DT_CONTRATO_PAF"))
                    Else
                        If objDataTable_CampoVazio(.Item("CD_CONTRATO_PAF_ORIGEM")) Then
                            CD_VERSAO_RELATORIO = Documento_Relatorio_Versao_Documento(enDocumento_Relatorio.eContratoPAF_Master, .Item("DT_CONTRATO_PAF"))
                        Else
                            CD_VERSAO_RELATORIO = Documento_Relatorio_Versao_Documento(enDocumento_Relatorio.eContratoPAF, .Item("DT_CONTRATO_PAF"))
                        End If
                    End If
                End If

                Select Case CD_VERSAO_RELATORIO
                    Case enDocumento_Relatorio.eContratoPAF_2011
                        Imprimir_ContratoPAF(CD_CONTRATO_PAF, , frmRelatorioGeral.enRelGeral_Tipo.eContratoPAF_2011)
                    Case enDocumento_Relatorio.eContratoPAF
                        Imprimir_ContratoPAF(CD_CONTRATO_PAF)
                    Case enDocumento_Relatorio.eContratoPAF_Master
                        Imprimir_ContratoPAF(CD_CONTRATO_PAF, , frmRelatorioGeral.enRelGeral_Tipo.eContratoPAF_Master_2010)
                    Case Else
                        If bContrato_PAF_PrecoFixo Then
                            Msg_Mensagem("Não é permitido fazer impressão desse contrato. Somente na negociação.")
                        End If
                End Select
            End If
        End With

        GoTo Sair

NaoImpresso:
        bOk = False
        GoTo Sair

Sair:
        objData_Finalizar(oData)
        Return bOk
    End Function

    Public Function Impressao_Negociacao(ByVal CD_CONTRATO_PAF As Integer, _
                                         ByVal SQ_NEGOCIACAO As Integer) As Boolean
        Dim oData As DataTable
        Dim oForm As frmRelatorioGeral
        Dim SqlText As String
        Dim iTipoRelatorio As enDocumento_Relatorio = enDocumento_Relatorio.eNegociacao
        Dim bOrigemMaster As Boolean = False
        Dim DT_NEGOCIACAO As Date
        Dim bOk As Boolean = True

        SqlText = "SELECT NEG.DT_NEGOCIACAO," & _
                         "NEG.IC_STATUS" & _
                  " FROM SOF.NEGOCIACAO NEG" & _
                  " WHERE NEG.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND NEG.SQ_NEGOCIACAO = " & SQ_NEGOCIACAO
        oData = DBQuery(SqlText)

        With oData.Rows(0)
            If .Item("IC_STATUS") = cnt_Contrato_Status_Excluido Then
                Msg_Mensagem("Essa negociação não foi eliminada.")
                GoTo NaoImpresso
            End If

            SqlText = "SELECT COUNT(*) QT" & _
                      " FROM SOF.CONFISSAO_DIVIDA_ATIVO_VENDA" & _
                      " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF
            If DBQuery_ValorUnico(SqlText) <> 0 Then
                Msg_Mensagem("Esse contrato é uma liquidação de uma recuperação de credito.")
                GoTo NaoImpresso
            End If

            '09/08/2004 foi a data de migração do SOF para o Logus
            If .Item("DT_NEGOCIACAO") < CDate("09/08/2004") Then
                Msg_Mensagem("Negociação proviniente de um contrato antigo. Favor emitir pelo contrato PAF.")
                GoTo NaoImpresso
            End If

            DT_NEGOCIACAO = .Item("DT_NEGOCIACAO")
        End With

        '>> Impressão do Contrato - Início
        oForm = New frmRelatorioGeral

        If Negociacao_Rolagem(CD_CONTRATO_PAF, SQ_NEGOCIACAO) Then
            iTipoRelatorio = enDocumento_Relatorio.eNegociacao_Aditamento
        Else
            SqlText = "SELECT NVL(MST.DT_CONTRATO_PAF, PAF.DT_CONTRATO_PAF) DT_CONTRATO_PAF_MST," & _
                             "PAF.DT_CONTRATO_PAF," & _
                             "PAF.CD_CONTRATO_PAF_ORIGEM," & _
                             "NEG.DT_NEGOCIACAO" & _
                      " FROM SOF.NEGOCIACAO NEG," & _
                            "SOF.CONTRATO_PAF PAF," & _
                            "SOF.CONTRATO_PAF MST" & _
                      " WHERE NEG.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                        " AND NEG.SQ_NEGOCIACAO = " & SQ_NEGOCIACAO & _
                        " AND PAF.CD_CONTRATO_PAF = NEG.CD_CONTRATO_PAF" & _
                        " AND MST.CD_CONTRATO_PAF (+) = PAF.CD_CONTRATO_PAF_ORIGEM"
            oData = DBQuery(SqlText)

            With oData.Rows(0)
                If Not CampoNulo(.Item("CD_CONTRATO_PAF_ORIGEM")) And _
                   .Item("DT_CONTRATO_PAF") <> .Item("DT_CONTRATO_PAF_MST") Then
                    bOrigemMaster = True
                End If
            End With

            If Contrato_PAF_PrecoFixo(CD_CONTRATO_PAF) Then
                iTipoRelatorio = enDocumento_Relatorio.eNegociacao_ContratoPAF_Master
            Else
                iTipoRelatorio = enDocumento_Relatorio.eNegociacao
            End If
        End If

        Select Case Documento_Relatorio_Versao_Documento(iTipoRelatorio, DT_NEGOCIACAO)
            Case enDocumento_Relatorio.eNegociacao
                oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eNegociacao
            Case enDocumento_Relatorio.eNegociacao_ContratoPAF_Master
                oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eNegociacao_ContratoPAF_Master
            Case enDocumento_Relatorio.eNegociacao_Aditamento
                oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eNegociacao_Aditamento
        End Select

        If iTipoRelatorio <> enDocumento_Relatorio.eSemImpressao And _
           oForm.RelGeral_Tipo <> frmRelatorioGeral.enRelGeral_Tipo.eSemDefinicao Then
            oForm.Filtro01 = CD_CONTRATO_PAF
            oForm.Filtro02 = SQ_NEGOCIACAO
            Form_Show(Nothing, oForm)
            '>> Impressão do Contrato - Fim
        End If

        If Not fIN(iTipoRelatorio, enDocumento_Relatorio.eNegociacao_ContratoPAF_Master, _
                                   enDocumento_Relatorio.eNegociacao_Aditamento) Then
            '>> Impressão do Aditamento - Início
            If Documento_Relatorio_Versao_Documento(enDocumento_Relatorio.eNegociacao_Aditamento, DT_NEGOCIACAO) = enDocumento_Relatorio.eNegociacao_Aditamento Then
                oForm = New frmRelatorioGeral
                oForm.Visible = False

                oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eNegociacao_Aditamento
                oForm.Filtro01 = CD_CONTRATO_PAF
                oForm.Filtro02 = SQ_NEGOCIACAO
                Form_Show(Nothing, oForm)

                If oForm.HouveImpressao Then
                    oForm.Visible = True
                Else
                    SqlText = "SELECT MAX(SQ_CONTRATO_FIXO) FROM SOF.CONTRATO_FIXO" & _
                              " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                                " AND SQ_NEGOCIACAO = " & SQ_NEGOCIACAO

                    oForm = New frmRelatorioGeral

                    If Documento_Relatorio_Versao_Documento(enDocumento_Relatorio.eDeclaracaoFixacao_DiferencialBolsa, DT_NEGOCIACAO) = enDocumento_Relatorio.eDeclaracaoFixacao_DiferencialBolsa Then
                        oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eDeclaracaoFixacaoPreco_DiferencialBolsa
                    Else
                        oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eDeclaracaoFixacaoPreco
                    End If

                    oForm.Filtro01 = CD_CONTRATO_PAF
                    oForm.Filtro02 = SQ_NEGOCIACAO
                    oForm.Filtro03 = DBQuery_ValorUnico(SqlText, 0)
                    Form_Show(Nothing, oForm)
                End If
            End If
            '>> Impressão do Aditamento - Fim
        End If

        GoTo Sair

NaoImpresso:
        bOk = False
        GoTo Sair

Sair:
        objData_Finalizar(oData)
        Return bOk
    End Function

    Public Function Impressao_ContratoFixo(ByVal CD_CONTRATO_PAF As Integer, _
                                           ByVal SQ_NEGOCIACAO As Integer, _
                                           ByVal SQ_CONTRATO_FIXO As Integer) As Boolean
        Dim oData As DataTable
        Dim SqlText As String
        Dim bOk As Boolean = True

        SqlText = "SELECT TNG.IC_TIPO_PRECO_FIXO," & _
                         "FIX.VL_TAXA_DOLAR_FIXACAO," & _
                         "FIX.IC_STATUS," & _
                         "FIX.DT_CONTRATO_FIXO" & _
                  " FROM SOF.CONTRATO_FIXO FIX," & _
                        "SOF.NEGOCIACAO NEG," & _
                        "SOF.TIPO_NEGOCIACAO TNG" & _
                  " WHERE FIX.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND FIX.SQ_NEGOCIACAO = " & SQ_NEGOCIACAO & _
                    " AND FIX.SQ_CONTRATO_FIXO = " & SQ_CONTRATO_FIXO & _
                    " AND NEG.CD_CONTRATO_PAF = FIX.CD_CONTRATO_PAF" & _
                    " AND NEG.SQ_NEGOCIACAO = FIX.SQ_NEGOCIACAO" & _
                    " AND TNG.CD_TIPO_NEGOCIACAO = NEG.CD_TIPO_NEGOCIACAO"
        oData = DBQuery(SqlText)

        With oData.Rows(0)
            If .Item("IC_STATUS") = cnt_Contrato_Status_Excluido Then
                Msg_Mensagem("Contrato eliminado.")
                Exit Function
            End If
            If .Item("IC_TIPO_PRECO_FIXO") = "S" Then
                Msg_Mensagem("Esse tipo de contrato fixo não pode ser impresso." & vbCrLf & _
                             "Favor imprimir a negociação.")
                GoTo NaoImpresso
            End If

            SqlText = "SELECT COUNT(*) QT FROM SOF.CONFISSAO_DIVIDA_ATIVO_VENDA" & _
                      " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF

            If DBQuery_ValorUnico(SqlText) <> 0 Then
                Msg_Mensagem("Esse contrato é uma liquidação de uma recuperação de credito.")
                GoTo NaoImpresso
            End If

            If Contrato_PAF_PrecoFixo(CD_CONTRATO_PAF) Then
                Msg_Mensagem("Não é permitido fazer impressão desse contrato. Somente na negociação.")
            Else
                Dim oForm As New frmRelatorioGeral
                oForm.Filtro01 = CD_CONTRATO_PAF
                oForm.Filtro02 = SQ_NEGOCIACAO
                oForm.Filtro03 = SQ_CONTRATO_FIXO

                If NVL(.Item("VL_TAXA_DOLAR_FIXACAO"), 0) > 0 Then
                    Select Case Documento_Relatorio_Versao_Documento(enDocumento_Relatorio.eDeclaracaoFixacao_DolarFlutuante, .Item("DT_CONTRATO_FIXO"))
                        Case enDocumento_Relatorio.eDeclaracaoFixacao
                            oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eDeclaracaoFixacaoPreco
                        Case enDocumento_Relatorio.eDeclaracaoFixacao_DolarFlutuante
                            oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eDeclaracaoFixacaoPreco_DolarFlutuante
                    End Select
                Else
                    Select Case Documento_Relatorio_Versao_Documento(enDocumento_Relatorio.eDeclaracaoFixacao_DiferencialBolsa, .Item("DT_CONTRATO_FIXO"))
                        Case enDocumento_Relatorio.eDeclaracaoFixacao
                            oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eDeclaracaoFixacaoPreco
                        Case enDocumento_Relatorio.eDeclaracaoFixacao_DiferencialBolsa
                            oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eDeclaracaoFixacaoPreco_DiferencialBolsa
                    End Select
                End If

                Form_Show(Nothing, oForm)
            End If
        End With

        GoTo Sair

NaoImpresso:
        bOk = False
        GoTo Sair

Sair:
        objData_Finalizar(oData)
        Return bOk
    End Function
End Module
