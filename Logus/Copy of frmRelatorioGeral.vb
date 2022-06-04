Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports VB = Microsoft.VisualBasic

Public Class frmRelatorioGeral
    Public RelGeral_Tipo As enRelGeral_Tipo
    Public Filtro01 As Integer
    Public Filtro02 As Integer
    Public Filtro03 As Integer

    Dim iBotao As Integer
    Dim sEMail As String
    Dim iCont As Integer

    Dim oRelatorio As New CrystalReportDocument
    Dim oRelatorioSub01 As New ReportDocument
    Dim oData_01 As New DataTable
    Dim oData_02 As New DataTable
    Dim oRow As DataRow
    Dim bHouveImpressao As Boolean

    Public Enum enRelGeral_Tipo
        eSemDefinicao = 0
        eVoucher = 1
        eFichaCadastral_Fisica = 2
        eFichaCadastral_Juridica = 3
        eCessaoDireito = 4
        eContratoAFixar = 5
        eContratoCarta = 6
        eContratoFilial = 7
        eContratoPrecoAFixar_Transporte = 8
        eContratoPrecoAFixar_Preposto = 9
        eContratoPrecoAFixar_Fax = 10
        eContratoPrecoAFixar_DtLimite = 11
        eContratoPrecoFixo_SemAdiantamento = 12
        eContratoPrecoFixo_ComAditamento_5050 = 13
        eContratoPrecoFixo_ComAditamento_Valor = 14
        eContratoPrecoFixo_ComAditamento_Total = 15
        eContratoPAF = 16
        eContratoPAF_Beneficiario = 17
        eContrato_Outros = 18
        eNegociacao = 19
        eNegociacao_Beneficiario = 20
        eDeclaracaoFixacaoPreco = 21
        eSaldoSacariaFilial = 22
        eSacariaRequisicao = 23
        eUtilizacaoSistema = 24
        eDeclaracaoFixacaoPreco_DiferencialBolsa = 25
        eDeclaracaoFixacaoPreco_DolarFlutuante = 26
        eContratoPAF_Master_2010 = 27
        eNegociacao_ContratoPAF_Master = 28
        eNegociacao_Aditamento = 29
        eContratoPAF_2011 = 30
        eContratoPAF_ConfCompra_CacauAOrdem = 31
        eContrato_Aditivo = 32
    End Enum

    Public Enum enBotao_Tipo
        EnviarEMail_Contrato = 1
        ContratoBeneficiado_PAF = 2
        ContratoBeneficiado_Negociacao = 3
    End Enum

    Public Enum enBotao_Icone
        EnviarEMail = 0
        Contrato = 1
    End Enum

    Public ReadOnly Property HouveImpressao() As Boolean
        Get
            Return bHouveImpressao
        End Get
    End Property

    Private Sub Imprimir()
        Dim SqlText As String
        Dim sCidade As String = ""
        Dim iAux As Integer = 0

        oRelatorio = New CrystalReportDocument
        bHouveImpressao = True

        Try
            Select Case RelGeral_Tipo
                Case enRelGeral_Tipo.eVoucher
                    SqlText = "SELECT M.NO_CIDADE," & _
                                     "M.CD_UF " & _
                              " FROM SOF.FILIAL F," & _
                                    "SOF.MUNICIPIO M" & _
                              " WHERE F.CD_MUNICIPIO = M.CD_MUNICIPIO" & _
                                " AND F.CD_FILIAL IN (SELECT B.CD_FILIAL_ORIGEM" & _
                                                     " FROM SOF.BANCO B," & _
                                                           "SOF.MOV_BANCARIO MB" & _
                                                     " WHERE MB.CD_BANCO = B.CD_BANCO" & _
                                                       " AND MB.SQ_MOV_BANCARIO = " & Filtro01 & " )"
                    oData_01 = DBQuery(SqlText)

                    If Not objDataTable_Vazio(oData_01) Then
                        sCidade = Chr(34) & oData_01.Rows(0).Item("NO_CIDADE") & " - " & oData_01.Rows(0).Item("CD_UF") & Chr(34)
                    End If

                    SqlText = "SELECT B.NO_BANCO," & _
                                     "MB.SQ_MOV_BANCARIO," & _
                                     "MB.NU_CHEQUE," & _
                                     "MB.DT_MOVIMENTACAO," & _
                                     "MB.NO_FAVORECIDO NO_FAVORECIDO_ITEM," & _
                                     "MB.VL_BRUTO," & _
                                     "IMB.VL_PAGO," & _
                                     "IMB.DS_DESCRICAO," & _
                                     "F.NO_RAZAO_SOCIAL," & _
                                     "MB.CD_BANCO," & _
                                     "OB.NO_OPERACAO," & _
                                     "IMB.NO_FAVORECIDO," & _
                                     "IMB.SQ_ITEM_MOV_BANCARIO," & _
                                     "(0 - IMBP.VL_PROVISAO) VL_PROVISAO," & _
                                     "PROV.NO_PROVISAO" & _
                              " FROM SOF.MOV_BANCARIO MB," & _
                                    "SOF.ITEM_MOV_BANCARIO IMB," & _
                                    "SOF.ITEM_MOV_BANCARIO_PROVISAO IMBP," & _
                                    "SOF.PROVISAO PROV," & _
                                    "SOF.BANCO B," & _
                                    "SOF.OPERACAO_BANCARIA OB," & _
                                    "SOF.FORNECEDOR F," & _
                                    "SOF.PAGAMENTOS P" & _
                              " WHERE MB.SQ_MOV_BANCARIO = " & Filtro01 & _
                                " AND MB.SQ_MOV_BANCARIO = IMB.SQ_MOV_BANCARIO" & _
                                " AND MB.CD_BANCO = B.CD_BANCO" & _
                                " AND IMB.CD_OPERACAO_BANCARIA = OB.CD_OPERACAO_BANCARIA" & _
                                " AND IMB.SQ_ITEM_MOV_BANCARIO = P.SQ_ITEM_MOV_BANCARIO (+)" & _
                                " AND F.CD_FORNECEDOR (+) = P.CD_FORNECEDOR" & _
                                " AND IMB.SQ_ITEM_MOV_BANCARIO = IMBP.SQ_ITEM_MOV_BANCARIO (+)" & _
                                " AND IMBP.CD_PROVISAO = PROV.CD_PROVISAO (+)"
                    oData_01 = DBQuery(SqlText)

                    Me.Text = "Voucher Nº " & Filtro01
                    oRelatorio.Load(Application.StartupPath & "\RPT_Voucher.rpt")
                    oRelatorio.SetDataSource(oData_01)
                    oRelatorio.SetParameterValue("Cidade", sCidade)

                    'oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                Case enRelGeral_Tipo.eFichaCadastral_Fisica, enRelGeral_Tipo.eFichaCadastral_Juridica
                    Select Case RelGeral_Tipo
                        Case enRelGeral_Tipo.eFichaCadastral_Fisica
                            oRelatorio.Load(Application.StartupPath & "\RPT_FichaCadastral_PF.rpt")
                        Case enRelGeral_Tipo.eFichaCadastral_Juridica
                            oRelatorio.Load(Application.StartupPath & "\RPT_FichaCadastral_PJ.rpt")
                    End Select

                    Dim oData_Procurador As New DataTable
                    Dim oData_Agregado As New DataTable
                    Dim oData_Fazenda As New DataTable
                    Dim oData_Bem As New DataTable
                    Dim iLinha As Integer
                    Dim iColuna As Integer
                    Dim SubRpt_Procurador As New ReportDocument
                    Dim SubRpt_Agregado As New ReportDocument
                    Dim SubRpt_Bens As New ReportDocument
                    Dim SubRpt_Fazenda As New ReportDocument

                    'Procurador
                    SqlText = "SELECT PCR.NO_RAZAO_SOCIAL NO_PROCURADOR" & _
                              " FROM SOF.FORNECEDOR_PROCURACAO FPR," & _
                                    "SOF.FORNECEDOR PCR" & _
                              " WHERE FPR.CD_FORNECEDOR = " & Filtro01 & _
                                " AND PCR.CD_FORNECEDOR = FPR.CD_FORNECEDOR_PROCURADOR" & _
                              " ORDER BY PCR.NO_RAZAO_SOCIAL"
                    oData_01 = DBQuery(SqlText)

                    With oData_Procurador.Columns
                        .Add("NO_PROCURADOR_1")
                        .Add("NO_PROCURADOR_2")
                        .Add("NO_PROCURADOR_3")
                        .Add("NO_PROCURADOR_4")
                    End With

                    If Not objDataTable_Vazio(oData_01) Then
                        iColuna = 0
                        iLinha = -1

                        For iAux = 0 To oData_01.Rows.Count - 1
                            If iColuna = 0 Then
                                oData_Procurador.Rows.Add()
                                iLinha = iLinha + 1
                            End If

                            oData_Procurador.Rows(iLinha).Item(iColuna) = oData_01.Rows(iAux).Item("no_Procurador")

                            If (oData_01.Rows.Count / 4) <= iLinha Then
                                iColuna = iColuna + 1
                                iLinha = 0
                            ElseIf iColuna > 0 Then
                                iLinha = iLinha + 1
                            End If
                        Next
                    End If

                    'Agregado
                    SqlText = "SELECT AGG.NO_RAZAO_SOCIAL NO_AGREGADO" & _
                              " FROM SOF.FORNECEDOR FNC," & _
                                    "SOF.FORNECEDOR AGG" & _
                              " WHERE FNC.CD_FORNECEDOR = " & Filtro01 & _
                                " AND AGG.CD_REPASSADOR = FNC.CD_FORNECEDOR" & _
                              " ORDER BY AGG.NO_RAZAO_SOCIAL"
                    oData_01 = DBQuery(SqlText)

                    With oData_Agregado.Columns
                        .Add("NO_AGREGADO_1")
                        .Add("NO_AGREGADO_2")
                        .Add("NO_AGREGADO_3")
                        .Add("NO_AGREGADO_4")
                    End With

                    If Not objDataTable_Vazio(oData_01) Then
                        iColuna = 0
                        iLinha = -1

                        For iAux = 0 To oData_01.Rows.Count - 1
                            If iColuna = 0 Then
                                oData_Agregado.Rows.Add()
                                iLinha = iLinha + 1
                            End If

                            oData_Agregado.Rows(iLinha).Item(iColuna) = oData_01.Rows(iAux).Item("no_Agregado")

                            If (oData_01.Rows.Count / 4) <= iLinha Then
                                iColuna = iColuna + 1
                                iLinha = 0
                            ElseIf iColuna > 0 Then
                                iLinha = iLinha + 1
                            End If
                        Next
                    End If

                    'Fazenda
                    SqlText = "SELECT NO_FAZENDA," & _
                                     "QT_PRODUCAO," & _
                                     "TRIM (MNC.NO_CIDADE) || DECODE(TRIM(NVL(FAZ.DS_ENDERECO, '')), ''," & _
                                     "''," & _
                                     "DECODE(TRIM(NVL(MNC.NO_CIDADE, ''))," & _
                                     "''," & _
                                     "''," & _
                                     "' - ')) || TRIM (FAZ.DS_ENDERECO) DS_ENDERECO" & _
                                "  FROM SOF.FAZENDA FAZ," & _
                                       "SOF.MUNICIPIO MNC" & _
                                "  WHERE FAZ.CD_FORNECEDOR = " & Filtro01 & _
                                   " AND MNC.CD_MUNICIPIO (+) = FAZ.CD_MUNICIPIO" & _
                                "  ORDER BY FAZ.NO_FAZENDA"
                    oData_01 = DBQuery(SqlText)

                    With oData_Fazenda.Columns
                        .Add("NO_FAZENDA_1")
                        .Add("QT_PRODUCAO_1")
                        .Add("DS_ENDERECO_1")
                        .Add("NO_FAZENDA_2")
                        .Add("QT_PRODUCAO_2")
                        .Add("DS_ENDERECO_2")
                    End With

                    If Not objDataTable_Vazio(oData_01) Then
                        iColuna = 0
                        iLinha = -1

                        For iAux = 0 To oData_01.Rows.Count - 1
                            If iColuna = 0 Then
                                oData_Fazenda.Rows.Add()
                                iLinha = iLinha + 1
                            End If

                            With oData_Fazenda.Rows(iLinha)
                                .Item(iColuna) = oData_01.Rows(iAux).Item("no_Fazenda")
                                .Item(iColuna + 1) = objDataTable_LerCampo(oData_01.Rows(iAux).Item("qt_Producao"), "")
                                .Item(iColuna + 2) = objDataTable_LerCampo(oData_01.Rows(iAux).Item("ds_Endereco"), "")
                            End With

                            If (oData_01.Rows.Count / 2) <= iLinha Then
                                iColuna = iColuna + 3
                                iLinha = 0
                            ElseIf iColuna > 0 Then
                                iLinha = iLinha + 1
                            End If
                        Next
                    End If

                    'Bens
                    SqlText = "SELECT BTP.CD_BENS_TIPO," & _
                                     "BTP.NO_BENS_TIPO," & _
                                     "BEM.DS_BEM," & _
                                     "BEM.VL_BEM," & _
                                     "BEM.DS_ENDERECO," & _
                                     "BEM.DS_IDENTIFICACAO," & _
                                     "BEM.QT_AREA_TOTAL," & _
                                     "BEM.QT_AREA_CULTIVADA," & _
                                     "BEM.QT_PRODUCAO," & _
                                     "UF.NO_UF," & _
                                     "MCP.NO_CIDADE" & _
                              " FROM SOF.FORNECEDOR_BENS FNB," & _
                                    "SOF.BENS BEM," & _
                                    "SOF.BENS_TIPO BTP," & _
                                    "SOF.MUNICIPIO MCP," & _
                                    "SOF.UF UF" & _
                              " WHERE FNB.CD_FORNECEDOR = " & Filtro01 & _
                                " AND BEM.SQ_BENS = FNB.SQ_BENS" & _
                                " AND BTP.CD_BENS_TIPO = BEM.CD_BENS_TIPO" & _
                                " AND MCP.CD_MUNICIPIO (+) = BEM.CD_MUNICIPIO_LOCALIZACAO" & _
                                " AND UF.CD_UF (+) = BEM.CD_UF_LOCALIZACAO"
                    oData_Bem = DBQuery(SqlText)

                    Select Case RelGeral_Tipo
                        Case enRelGeral_Tipo.eFichaCadastral_Fisica
                            SqlText = "select f.no_razao_social, f.nu_fax , f.nu_tel ,f.nu_cep , f.no_bairro ,f.nu_cgc_cpf ,f.ic_fisica_juridica, "
                            SqlText = SqlText & "f.no_pai ,f.no_mae , f.ds_email ,f.ds_endereco ,f.nu_celular , f.ds_endereco_complemento , "
                            SqlText = SqlText & "m.no_cidade ,m.cd_uf  ,f.no_conjuge , f.dt_nascimento_conjuge ,f.ds_naturalidade , f.ds_nacionalidade ,f.ic_tipo_rg ,  "
                            SqlText = SqlText & "f.ic_sexo ,f.dt_nascimento, f.nu_rg, f.ds_orgao_emissor_rg ,f.dt_emissao_rg,   "
                            SqlText = SqlText & "e.no_estado_civil , tp.no_tipo_pessoa ,fr.sq_forn_ref_banco , fr.no_banco, fr.nu_banco ,fr.cd_agencia ,fr.nu_conta_corrente ,fr.no_gerente ,fr.nu_telefone,"
                            SqlText = SqlText & "REP.no_Razao_Social no_Repassador, f.no_Profissao, f.ds_Outra_Atividade, f.dt_Criacao, f.cd_address_number, f.DS_OBS_FICHA  "
                            SqlText = SqlText & "FROM SOF.FORNECEDOR F, SOF.MUNICIPIO M, SOF.ESTADO_CIVIL E,"
                            SqlText = SqlText & "SOF.TIPO_PESSOA TP, SOF.FORNECEDOR_REFERENCIA_BANCO FR, SOF.FORNECEDOR REP "
                            SqlText = SqlText & "WHERE F.CD_ESTADO_CIVIL=E.CD_ESTADO_CIVIL (+)"
                            SqlText = SqlText & " AND TP.CD_TIPO_PESSOA (+) = F.CD_TIPO_PESSOA"
                            SqlText = SqlText & " AND FR.CD_FORNECEDOR (+) = F.CD_FORNECEDOR"
                            SqlText = SqlText & " AND M.CD_MUNICIPIO (+) = F.CD_MUNICIPIO"
                            SqlText = SqlText & " AND F.CD_FORNECEDOR = " & Filtro01
                            SqlText = SqlText & " AND REP.CD_FORNECEDOR (+) = F.CD_REPASSADOR"
                            oData_01 = DBQuery(SqlText)
                        Case enRelGeral_Tipo.eFichaCadastral_Juridica
                            Dim SubRpt_Socio As New ReportDocument
                            Dim SubRpt_Coligada As New ReportDocument
                            Dim oData_Socio As New DataTable
                            Dim oData_Coligada As New DataTable

                            'Sócio
                            SqlText = "SELECT FPS.NO_FORNECEDOR_PESSOA NO_SOCIO," & _
                                             "TFP.NO_TIPO_FORNECEDOR_PESSOA TIPO_PESSOA," & _
                                             "FPS.DS_ENDERECO DS_ENDERECO," & _
                                             "FPS.DS_EMAIL," & _
                                             "FPS.NU_CGC_CPF" & _
                                      " FROM SOF.FORNECEDOR_PESSOA FPS," & _
                                            "SOF.TIPO_FORNECEDOR_PESSOA TFP," & _
                                            "SOF.UF UF," & _
                                            "SOF.MUNICIPIO MNC" & _
                                      " WHERE FPS.CD_FORNECEDOR = " & Filtro01 & _
                                        " AND TFP.CD_TIPO_FORNECEDOR_PESSOA = FPS.CD_TIPO_FORNECEDOR_PESSOA" & _
                                        " AND  UF.CD_UF (+) = FPS.CD_UF" & _
                                        " AND MNC.CD_MUNICIPIO (+) = FPS.CD_MUNICIPIO" & _
                                      " ORDER BY FPS.NO_FORNECEDOR_PESSOA"
                            oData_Socio = DBQuery(SqlText)

                            'Coligada
                            SqlText = "SELECT NO_EMPRESA," & _
                                             "DS_RAMO_ATIVIDADE," & _
                                             "NU_CGC" & _
                                      " FROM SOF.FORNECEDOR_COLIGADAS" & _
                                      " WHERE CD_FORNECEDOR = " & Filtro01
                            oData_Coligada = DBQuery(SqlText)

                            SqlText = "select f.no_razao_social, f.nu_fax , f.nu_tel ,f.nu_cep , f.no_bairro ,f.nu_cgc_cpf ,f.ic_fisica_juridica,  "
                            SqlText = SqlText & "f.ds_endereco ,f.nu_celular , f.ds_endereco_complemento , "
                            SqlText = SqlText & "m.no_cidade ,m.cd_uf,f.ic_tipo_rg,tp.no_tipo_pessoa,fr.sq_forn_ref_banco,fr.no_banco,fr.nu_banco,fr.cd_agencia,"
                            SqlText = SqlText & "fr.nu_conta_corrente ,fr.no_gerente ,fr.nu_telefone,REP.no_Razao_Social no_Repassador,f.ds_Outra_Atividade,f.dt_Criacao,"
                            SqlText = SqlText & "f.no_Fantasia,f.nu_Insc_Estadual,f.nu_Registro_Junta_Comercial,f.dt_Constituicao_Junta,FRR.no_Funrural,FTC.no_Tipo_Capital,F.ds_email, f.cd_address_number, f.DS_OBS_FICHA "
                            SqlText = SqlText & "FROM SOF.FORNECEDOR F, SOF.MUNICIPIO M, SOF.ESTADO_CIVIL E,SOF.FUNRURAL FRR,SOF.FORNECEDOR_TIPO_CAPITAL FTC,"
                            SqlText = SqlText & "SOF.TIPO_PESSOA TP, SOF.FORNECEDOR_REFERENCIA_BANCO FR, SOF.FORNECEDOR REP "
                            SqlText = SqlText & "WHERE F.CD_ESTADO_CIVIL=E.CD_ESTADO_CIVIL (+)"
                            SqlText = SqlText & " AND TP.CD_TIPO_PESSOA (+) = F.CD_TIPO_PESSOA"
                            SqlText = SqlText & " AND FR.CD_FORNECEDOR (+) = F.CD_FORNECEDOR"
                            SqlText = SqlText & " AND M.CD_MUNICIPIO (+) = F.CD_MUNICIPIO"
                            SqlText = SqlText & " AND F.CD_FORNECEDOR = " & Filtro01
                            SqlText = SqlText & " AND REP.CD_FORNECEDOR (+) = F.CD_REPASSADOR"
                            SqlText = SqlText & " AND FRR.CD_FUNRURAL (+) = F.CD_FUNRURAL"
                            SqlText = SqlText & " AND FTC.CD_TIPO_CAPITAL (+) = F.CD_TIPO_CAPITAL"
                            oData_01 = DBQuery(SqlText)

                            SubRpt_Socio = oRelatorio.OpenSubreport("Socio")
                            SubRpt_Socio.SetDataSource(oData_Socio)
                            SubRpt_Coligada = oRelatorio.OpenSubreport("Coligadas")
                            SubRpt_Coligada.SetDataSource(oData_Coligada)
                    End Select

                    Me.Text = "Ficha Cadastral nº " & Filtro01

                    SubRpt_Procurador = oRelatorio.OpenSubreport("Procurador")
                    SubRpt_Procurador.SetDataSource(oData_Procurador)
                    SubRpt_Agregado = oRelatorio.OpenSubreport("Agregados")
                    SubRpt_Agregado.SetDataSource(oData_Agregado)
                    SubRpt_Bens = oRelatorio.OpenSubreport("Bens")
                    SubRpt_Bens.SetDataSource(oData_Bem)
                    SubRpt_Fazenda = oRelatorio.OpenSubreport("Fazenda")
                    SubRpt_Fazenda.SetDataSource(oData_Fazenda)
                    oRelatorio.SetDataSource(oData_01)
                    oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                Case enRelGeral_Tipo.eCessaoDireito
                    SqlText = "SELECT fv.no_razao_social no_razao_social_vendedor, "
                    SqlText = SqlText & "       fv.nu_cgc_cpf nu_cpf_vendedor, fv.ds_endereco ds_endereco_vendedor, "
                    SqlText = SqlText & "       fv.no_bairro no_bairro_vendedor, fv.ic_fisica_juridica ic_fj_vendedor, "
                    SqlText = SqlText & "       mv.no_cidade no_cidade_vendedor, mv.cd_uf cd_uf_vendedor, "
                    SqlText = SqlText & "       fc.no_razao_social no_razao_social_cessionario, "
                    SqlText = SqlText & "       fc.nu_cgc_cpf nu_cpf_cessionario, "
                    SqlText = SqlText & "       fc.ds_endereco ds_endereco_cessionario, "
                    SqlText = SqlText & "       fc.no_bairro no_bairro_cessionario, "
                    SqlText = SqlText & "       fc.ic_fisica_juridica ic_fj_cessionario, "
                    SqlText = SqlText & "       mc.no_cidade no_cidade_cessionario, mc.cd_uf cd_uf_cessionario, "
                    SqlText = SqlText & "       fil.no_razao no_razao_social_filial, fil.nu_cgc nu_cgc_filial, "
                    SqlText = SqlText & "       fil.ds_endereco ds_endereco_filial, mfil.no_cidade no_cidade_filial, "
                    SqlText = SqlText & "       mfil.cd_uf cd_uf_filial, tnf.no_tipo_nf, mcd.qt_recebido, mov.qt_kg_nf, "
                    SqlText = SqlText & "       mov.vl_nf, mov.dt_movimentacao, mov.nu_nf, to_number (mov.nu_nf_referencia) as nu_nf_referencia , "
                    SqlText = SqlText & "       mov.dt_nf_referencia, mcd.dt_cessao_direito, '' VL_EXTENSO "
                    SqlText = SqlText & "  FROM sof.movimentacao mov, "
                    SqlText = SqlText & "       sof.movimentacao_cessao_direito mcd, "
                    SqlText = SqlText & "       sof.fornecedor fv, "
                    SqlText = SqlText & "       sof.fornecedor fc, "
                    SqlText = SqlText & "       sof.municipio mv, "
                    SqlText = SqlText & "       sof.municipio mc, "
                    SqlText = SqlText & "       sof.filial fil, "
                    SqlText = SqlText & "       sof.municipio mfil, "
                    SqlText = SqlText & "       sof.tipo_nf tnf "
                    SqlText = SqlText & " WHERE mov.sq_movimentacao = mcd.sq_movimentacao "
                    SqlText = SqlText & "   AND mov.cd_fornecedor = fv.cd_fornecedor "
                    SqlText = SqlText & "   AND mcd.cd_fornecedor = fc.cd_fornecedor "
                    SqlText = SqlText & "   AND fv.cd_municipio = mv.cd_municipio "
                    SqlText = SqlText & "   AND fc.cd_municipio = mc.cd_municipio "
                    SqlText = SqlText & "   AND fil.cd_filial = fv.cd_filial_origem "
                    SqlText = SqlText & "   AND fil.cd_municipio = mfil.cd_municipio "
                    SqlText = SqlText & "   AND mov.cd_tipo_nf = tnf.cd_tipo_nf(+) "
                    SqlText = SqlText & "   AND mcd.sq_movimentacao = " & Filtro01
                    SqlText = SqlText & "   AND mcd.sq_movimentacao_cessao_direito =  " & Filtro02

                    oData_01 = DBQuery(SqlText)

                    oRelatorio.Load(Application.StartupPath & "\RPT_Cessao_Direito.rpt")
                    oRelatorio.SetDataSource(oData_01)
                Case enRelGeral_Tipo.eContratoAFixar
                    SqlText = "SELECT FRN.NO_RAZAO_SOCIAL," & _
                                     "FRN.IC_FISICA_JURIDICA," & _
                                     "FRN.NU_CGC_CPF," & _
                                     "FRN.DS_ENDERECO," & _
                                     "FRN.NO_BAIRRO," & _
                                     "MNC.NO_CIDADE," & _
                                     "MNC.CD_UF," & _
                                     "CTR.NO_FAZENDA," & _
                                     "CTR.QT_KGS," & _
                                     "CTR.CD_TIPO_UNIDADE," & _
                                         "TO_CHAR(CTR.CD_CONTRATO) AS NUMCTR," & _
                                     "CTR.VL_UNITARIO," & _
                                     "CTR.CD_LOCAL_ENTREGA," & _
                                     "CTR.VL_INSS," & _
                                     "CTR.VL_TOTAL," & _
                                     "CTR.DT_PAGAMENTO," & _
                                     "CTR.DT_VENCIMENTO," & _
                                     "CTR.DT_CONTRATO," & _
                                     "MNF.NO_CIDADE AS FILCIDADE," & _
                                     "MNF.CD_UF AS FILUF," & _
                                     "FIL.NO_RAZAO," & _
                                     "FIL.NU_CGC," & _
                                     "FIL.DS_ENDERECO AS FILEND," & _
                                     "FNR.VL_TAXA " & _
                              " FROM SOF.CONTRATO CTR," & _
                                    "SOF.FORNECEDOR FRN," & _
                                    "SOF.FUNRURAL FNR," & _
                                    "SOF.MUNICIPIO MNC," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.MUNICIPIO MNF" & _
                              " WHERE CTR.CD_FORNECEDOR = FRN.CD_FORNECEDOR" & _
                                " AND FRN.CD_FUNRURAL = FNR.CD_FUNRURAL" & _
                                " AND FRN.CD_MUNICIPIO = MNC.CD_MUNICIPIO" & _
                                " AND CTR.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                                " AND FIL.CD_MUNICIPIO = MNF.CD_MUNICIPIO" & _
                                " AND CTR.CD_CONTRATO = " & Filtro01
                    oData_01 = DBQuery(SqlText)

                    Me.Text = "Contrato Nº " & Filtro01

                    oRelatorio.Load(Application.StartupPath & "\RPT_ContratoAFixar.rpt")
                    oRelatorio.SetDataSource(oData_01)
                Case enRelGeral_Tipo.eContratoCarta
                    SqlText = "SELECT     TO_CHAR(CTR.CD_CONTRATO) AS NUMCTR, " & _
                                     "CTR.DT_CONTRATO," & _
                                     "FRN.CD_TIPO_PESSOA," & _
                                     "FRN.IC_FISICA_JURIDICA," & _
                                     "FRN.NO_RAZAO_SOCIAL," & _
                                     "FRN.DS_ENDERECO," & _
                                     "FRN.NO_BAIRRO," & _
                                     "FRN.NU_INSC_ESTADUAL," & _
                                     "MNC.NO_CIDADE," & _
                                     "MNC.CD_UF," & _
                                     "FRN.NU_CGC_CPF," & _
                                     "CTR.QT_KGS," & _
                                     "CTR.CD_TIPO_PRECO," & _
                                     "CTR.VL_UNITARIO," & _
                                     "FRN.NU_FAX" & _
                              " FROM SOF.CONTRATO CTR," & _
                                    "SOF.FORNECEDOR FRN," & _
                                    "SOF.MUNICIPIO MNC" & _
                              " WHERE CTR.CD_FORNECEDOR = FRN.CD_FORNECEDOR" & _
                                " AND FRN.CD_MUNICIPIO = MNC.CD_MUNICIPIO" & _
                                " AND CTR.CD_CONTRATO = " & Filtro01
                    oData_01 = DBQuery(SqlText)

                    Me.Text = "Contrato Nº " & Filtro01

                    oRelatorio.Load(Application.StartupPath & "\RPT_ContratoCarta.rpt")
                    oRelatorio.SetDataSource(oData_01)
                Case enRelGeral_Tipo.eContratoFilial
                    SqlText = "SELECT FRN.NO_RAZAO_SOCIAL," & _
                                     "FRN.IC_FISICA_JURIDICA, " & _
                                     "FRN.NU_CGC_CPF," & _
                                     "FRN.DS_ENDERECO," & _
                                     "FRN.NO_BAIRRO," & _
                                     "MNC.NO_CIDADE," & _
                                     "MNC.CD_UF," & _
                                     "CTR.NO_FAZENDA," & _
                                     "CTR.QT_KGS," & _
                                     "CTR.CD_TIPO_UNIDADE," & _
                                         "TO_CHAR(CTR.CD_CONTRATO) AS NUMCTR," & _
                                     "CTR.VL_UNITARIO," & _
                                     "CTR.CD_LOCAL_ENTREGA," & _
                                     "CTR.VL_INSS," & _
                                     "CTR.VL_TOTAL," & _
                                     "CTR.DT_PAGAMENTO," & _
                                     "CTR.DT_VENCIMENTO," & _
                                     "CTR.DT_CONTRATO," & _
                                     "MCF.NO_CIDADE AS FILCIDADE," & _
                                     "MCF.CD_UF AS FILUF," & _
                                     "FIL.NO_RAZAO," & _
                                     "FIL.NU_CGC," & _
                                     "FIL.DS_ENDERECO AS FILEND," & _
                                     "FUR.VL_TAXA " & _
                              " FROM SOF.CONTRATO CTR," & _
                                    "SOF.FORNECEDOR FRN," & _
                                    "SOF.FUNRURAL FUR," & _
                                    "SOF.MUNICIPIO MNC," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.MUNICIPIO MCF" & _
                              " WHERE CTR.CD_FORNECEDOR = FRN.CD_FORNECEDOR" & _
                                " AND FRN.CD_FUNRURAL = FUR.CD_FUNRURAL" & _
                                " AND FRN.CD_MUNICIPIO = MNC.CD_MUNICIPIO" & _
                                " AND CTR.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                                " AND FIL.CD_MUNICIPIO = MCF.CD_MUNICIPIO" & _
                                " AND CTR.CD_CONTRATO = " & Filtro01
                    oData_01 = DBQuery(SqlText)

                    Me.Text = "Contrato Nº " & Filtro01

                    oRelatorio.Load(Application.StartupPath & "\RPT_ContratoFilial.rpt")
                    oRelatorio.SetDataSource(oData_01)
                Case enRelGeral_Tipo.eContratoPrecoAFixar_Transporte, enRelGeral_Tipo.eContratoPrecoAFixar_Preposto, _
                     enRelGeral_Tipo.eContratoPrecoAFixar_Fax, enRelGeral_Tipo.eContratoPrecoAFixar_DtLimite
                    SqlText = "SELECT FRN.NO_RAZAO_SOCIAL," & _
                                     "FRN.IC_FISICA_JURIDICA," & _
                                     "FRN.NU_CGC_CPF," & _
                                     "FRN.DS_ENDERECO," & _
                                     "FRN.NO_BAIRRO," & _
                                     "MNC.NO_CIDADE," & _
                                     "MNC.CD_UF," & _
                                     "CTR.NO_FAZENDA," & _
                                     "CTR.QT_KGS," & _
                                     "CTR.CD_TIPO_UNIDADE," & _
                                     "CTR.CD_CONTRATO," & _
                                     "CTR.VL_UNITARIO," & _
                                     "CTR.CD_LOCAL_ENTREGA," & _
                                     "CTR.VL_INSS," & _
                                     "CTR.VL_TOTAL," & _
                                     "CTR.DT_PAGAMENTO," & _
                                     "CTR.DT_VENCIMENTO," & _
                                     "CTR.DT_CONTRATO," & _
                                     "MCF.NO_CIDADE AS FILCIDADE," & _
                                     "MCF.CD_UF AS FILUF," & _
                                     "FIL.NO_RAZAO," & _
                                     "FIL.NU_CGC," & _
                                     "FIL.DS_ENDERECO AS FILEND," & _
                                     "FNR.VL_TAXA," & _
                                     "CTR.VL_ADIANTAMENTO," & _
                                     "FRN.NU_INSC_ESTADUAL " & _
                              " FROM SOF.CONTRATO CTR," & _
                                    "SOF.FORNECEDOR FRN," & _
                                    "SOF.FUNRURAL FNR," & _
                                    "SOF.MUNICIPIO MNC," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.MUNICIPIO MCF" & _
                              " WHERE CTR.CD_FORNECEDOR = FRN.CD_FORNECEDOR" & _
                                " AND FRN.CD_FUNRURAL = FNR.CD_FUNRURAL" & _
                                " AND FRN.CD_MUNICIPIO = MNC.CD_MUNICIPIO" & _
                                " AND CTR.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                                " AND FIL.CD_MUNICIPIO = MCF.CD_MUNICIPIO" & _
                                " AND CTR.CD_CONTRATO = " & Filtro01
                    oData_01 = DBQuery(SqlText)

                    Me.Text = "Contrato Nº " & Filtro01

                    oRelatorio.Load(Application.StartupPath & "\RPT_ContratoPrecoAFixar.rpt")
                    oRelatorio.SetDataSource(oData_01)

                    'Select Case RelGeral_Tipo
                    '    Case enRelGeral_Tipo.eContratoPrecoAFixar_Transporte
                    '        oRelatorio.sectransp.Suppress = False
                    '        oRelatorio.secpreposto.Suppress = True
                    '        oRelatorio.secfax.Suppress = True
                    '        oRelatorio.secdtlimite.Suppress = True
                    '    Case enRelGeral_Tipo.eContratoPrecoAFixar_Preposto
                    '        oRelatorio.sectransp.Suppress = True
                    '        oRelatorio.secpreposto.Suppress = False
                    '        oRelatorio.secfax.Suppress = True
                    '        oRelatorio.secdtlimite.Suppress = True
                    '    Case enRelGeral_Tipo.eContratoPrecoAFixar_Fax
                    '        oRelatorio.sectransp.Suppress = True
                    '        oRelatorio.secpreposto.Suppress = True
                    '        oRelatorio.secfax.Suppress = False
                    '        oRelatorio.secdtlimite.Suppress = True
                    '    Case enRelGeral_Tipo.eContratoPrecoAFixar_DtLimite
                    '        oRelatorio.sectransp.Suppress = True
                    '        oRelatorio.secpreposto.Suppress = True
                    '        oRelatorio.secfax.Suppress = True
                    '        oRelatorio.secdtlimite.Suppress = False
                    'End Select
                Case enRelGeral_Tipo.eContratoPrecoFixo_SemAdiantamento
                    SqlText = "SELECT FRN.NO_RAZAO_SOCIAL," & _
                                     "FRN.IC_FISICA_JURIDICA," & _
                                     "FRN.NU_CGC_CPF," & _
                                     "FRN.DS_ENDERECO," & _
                                     "FRN.NO_BAIRRO," & _
                                     "MNC.NO_CIDADE," & _
                                     "MNC.CD_UF," & _
                                     "CTR.NO_FAZENDA," & _
                                     "CTR.QT_KGS," & _
                                     "CTR.CD_TIPO_UNIDADE," & _
                                     "CTR.CD_CONTRATO," & _
                                     "CTR.VL_UNITARIO," & _
                                     "CTR.CD_LOCAL_ENTREGA," & _
                                     "CTR.VL_INSS," & _
                                     "CTR.VL_TOTAL," & _
                                     "CTR.DT_PAGAMENTO," & _
                                     "CTR.DT_VENCIMENTO," & _
                                     "CTR.DT_CONTRATO," & _
                                     "MCF.NO_CIDADE AS FILCIDADE," & _
                                     "MCF.CD_UF AS FILUF," & _
                                     "FIL.NO_RAZAO," & _
                                     "FIL.NU_CGC," & _
                                     "FIL.DS_ENDERECO AS FILEND," & _
                                     "FNR.VL_TAXA," & _
                                     "CTR.VL_ADIANTAMENTO," & _
                                     "FRN.NU_INSC_ESTADUAL" & _
                              " FROM SOF.CONTRATO CTR," & _
                                    "SOF.FORNECEDOR FRN," & _
                                    "SOF.FUNRURAL FNR," & _
                                    "SOF.MUNICIPIO MNC," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.MUNICIPIO MCF" & _
                              " WHERE CTR.CD_FORNECEDOR = FRN.CD_FORNECEDOR" & _
                                " AND FRN.CD_FUNRURAL = FRN.CD_FUNRURAL" & _
                                " AND FRN.CD_MUNICIPIO = MNC.CD_MUNICIPIO" & _
                                " AND CTR.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                                " AND FIL.CD_MUNICIPIO = MCF.CD_MUNICIPIO" & _
                                " AND CTR.CD_CONTRATO = " & Filtro01
                    oData_01 = DBQuery(SqlText)

                    Me.Text = "Contrato Nº " & Filtro01

                    oRelatorio.Load(Application.StartupPath & "\RPT_ContratoFixo_SemAdiatamento.rpt")
                    oRelatorio.SetDataSource(oData_01)
                Case enRelGeral_Tipo.eContratoPrecoFixo_ComAditamento_5050, _
                     enRelGeral_Tipo.eContratoPrecoFixo_ComAditamento_Valor, _
                     enRelGeral_Tipo.eContratoPrecoFixo_ComAditamento_Total
                    SqlText = "SELECT FRN.NO_RAZAO_SOCIAL," & _
                                     "FRN.IC_FISICA_JURIDICA, " & _
                                     "FRN.NU_CGC_CPF," & _
                                     "FRN.DS_ENDERECO," & _
                                     "FRN.NO_BAIRRO," & _
                                     "MNC.NO_CIDADE," & _
                                     "MNC.CD_UF," & _
                                     "CTR.NO_FAZENDA," & _
                                     "CTR.QT_KGS," & _
                                     "CTR.CD_TIPO_UNIDADE," & _
                                     "CTR.CD_CONTRATO," & _
                                     "CTR.VL_UNITARIO," & _
                                     "CTR.CD_LOCAL_ENTREGA," & _
                                     "CTR.VL_INSS," & _
                                     "CTR.VL_TOTAL," & _
                                     "CTR.DT_PAGAMENTO," & _
                                     "CTR.DT_VENCIMENTO," & _
                                     "CTR.DT_CONTRATO," & _
                                     "MCF.NO_CIDADE AS FILCIDADE," & _
                                     "MCF.CD_UF AS FILUF," & _
                                     "FIL.NO_RAZAO," & _
                                     "FIL.NU_CGC," & _
                                     "FIL.DS_ENDERECO AS FILEND," & _
                                     "fnr.VL_TAXA," & _
                                     "CTR.VL_ADIANTAMENTO," & _
                                     "FRN.NU_INSC_ESTADUAL" & _
                              " FROM SOF.CONTRATO CTR," & _
                                    "SOF.FORNECEDOR FRN," & _
                                    "SOF.FUNRURAL FNR," & _
                                    "SOF.MUNICIPIO MNC," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.MUNICIPIO MCF" & _
                              " WHERE CTR.CD_FORNECEDOR = FRN.CD_FORNECEDOR" & _
                                " AND FRN.CD_FUNRURAL = FNR.CD_FUNRURAL" & _
                                " AND FRN.CD_MUNICIPIO = MNC.CD_MUNICIPIO" & _
                                " AND CTR.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                                " AND FIL.CD_MUNICIPIO = MCF.CD_MUNICIPIO" & _
                                " AND CTR.CD_CONTRATO = " & Filtro01
                    oData_01 = DBQuery(SqlText)

                    Me.Text = "Contrato Nº " & Filtro01

                    oRelatorio.Load(Application.StartupPath & "\RPT_ContratoFixo_ComAdiatamento.rpt")
                    oRelatorio.SetDataSource(oData_01)

                    Const sec5050 As Integer = 1
                    Const secValor As Integer = 1
                    Const secTotal As Integer = 1

                    Select Case RelGeral_Tipo
                        Case enRelGeral_Tipo.eContratoPrecoFixo_ComAditamento_5050
                            oRelatorio.ReportDefinition.Sections(sec5050).SectionFormat.EnableSuppress = False
                            oRelatorio.ReportDefinition.Sections(secValor).SectionFormat.EnableSuppress = True
                            oRelatorio.ReportDefinition.Sections(secTotal).SectionFormat.EnableSuppress = True
                        Case enRelGeral_Tipo.eContratoPrecoFixo_ComAditamento_Valor
                            oRelatorio.ReportDefinition.Sections(sec5050).SectionFormat.EnableSuppress = True
                            oRelatorio.ReportDefinition.Sections(secValor).SectionFormat.EnableSuppress = False
                            oRelatorio.ReportDefinition.Sections(secTotal).SectionFormat.EnableSuppress = True
                        Case enRelGeral_Tipo.eContratoPrecoFixo_ComAditamento_Total
                            oRelatorio.ReportDefinition.Sections(sec5050).SectionFormat.EnableSuppress = True
                            oRelatorio.ReportDefinition.Sections(secValor).SectionFormat.EnableSuppress = True
                            oRelatorio.ReportDefinition.Sections(secTotal).SectionFormat.EnableSuppress = False
                    End Select
                Case enRelGeral_Tipo.eContratoPAF, enRelGeral_Tipo.eContratoPAF_Master_2010
                    Dim IC_Adiantamento As String = ""

                    Me.Text = "Contrato Nº " & Filtro01

                    SqlText = "SELECT COUNT(*)" & _
                              " FROM SOF.CONTRATO_PAF" & _
                              " WHERE CD_FORNECEDOR_BENEFICIADO IS NOT NULL " & _
                                " AND CD_CONTRATO_PAF = " & Filtro01

                    If DBQuery_ValorUnico(SqlText) <> 0 Then
                        Botao_Exibir(enBotao_Tipo.ContratoBeneficiado_PAF)
                    End If

                    oData_01 = Gera_Rs_Impressao_Contrato_PAF(Filtro01, IC_Adiantamento, False)

                    If IC_Adiantamento = "S" Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_ContratoPAF_ComAdiatamento.rpt")
                    Else
                        If RelGeral_Tipo = enRelGeral_Tipo.eContratoPAF Then
                            oRelatorio.Load(Application.StartupPath & "\RPT_ContratoPAF_SemAdiatamento.rpt")
                        ElseIf RelGeral_Tipo = enRelGeral_Tipo.eContratoPAF_Master_2010 Then
                            oRelatorio.Load(Application.StartupPath & "\RPT_ContratoPAF_SemAdiatamento_2011.rpt")
                        End If
                    End If

                    oRelatorio.SetDataSource(oData_01)

                    sEMail = ContratoPAF_CapturaEnderecoEMail(Filtro01)

                    If Trim(sEMail) <> "" Then
                        Botao_Exibir(enBotao_Tipo.EnviarEMail_Contrato)
                    End If
                Case enRelGeral_Tipo.eContratoPAF_2011
                    Me.Text = "Contrato Nº " & Filtro01

                    SqlText = "SELECT COUNT(*)" & _
                              " FROM SOF.CONTRATO_PAF" & _
                              " WHERE CD_FORNECEDOR_BENEFICIADO IS NOT NULL " & _
                                " AND CD_CONTRATO_PAF = " & Filtro01

                    If DBQuery_ValorUnico(SqlText) <> 0 Then
                        Botao_Exibir(enBotao_Tipo.ContratoBeneficiado_PAF)
                    End If

                    SqlText = "SELECT PAF.CD_CONTRATO_PAF," & _
                                     "FIL.NO_RAZAO NO_FILIAL," & _
                                     "FIL.NU_CGC CNPJ_FILIAL," & _
                                     "FIL.DS_ENDERECO END_FILIAL," & _
                                     "MFIL.NO_CIDADE NO_CIDADE_FILIAL_EMISSAO," & _
                                     "MFIL.CD_UF CD_UF_FILIAL_EMISSOR," & _
                                     "PAF.DT_CONTRATO_PAF," & _
                                     "F.NO_RAZAO_SOCIAL," & _
                                     "F.NU_CGC_CPF," & _
                                     "F.IC_FISICA_JURIDICA IC_FISICO_JURIDICO," & _
                                     "F.DS_ENDERECO DS_ENDERECO_FORNECEDOR," & _
                                     "F.NO_BAIRRO NO_BAIRRO_FORNECEDOR," & _
                                     "MFORN.NO_CIDADE NO_CIDADE_FORNECEDOR," & _
                                     "MFORN.CD_UF CD_UF_FORNECEDOR," & _
                                     "PAF.QT_KGS," & _
                                     "PAF.DT_PRAZO_FIXACAO," & _
                                     "PAF.DT_PRAZO_ENTREGA," & _
                                     "FET.NO_FILIAL NO_LOCAL_ENTREGA," & _
                                     "PAF.CD_TIPO_CONTRATO_PAF" & _
                              " FROM SOF.CONTRATO_PAF PAF," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.FILIAL FET," & _
                                    "SOF.MUNICIPIO MFIL," & _
                                    "SOF.FORNECEDOR F," & _
                                    "SOF.MUNICIPIO MFORN" & _
                              " WHERE PAF.CD_CONTRATO_PAF = " & Filtro01 & _
                                " AND FIL.CD_FILIAL = PAF.CD_FILIAL_ORIGEM" & _
                                " AND FET.CD_FILIAL = PAF.CD_FILIAL_ENTREGA" & _
                                " AND MFIL.CD_MUNICIPIO = FIL.CD_MUNICIPIO" & _
                                " AND F.CD_FORNECEDOR = PAF.CD_FORNECEDOR" & _
                                " AND MFORN.CD_MUNICIPIO (+) = F.CD_MUNICIPIO"
                    oData_02 = DBQuery(SqlText)

                    oData_01 = New DataTable

                    With oData_01.Columns
                        .Add("CD_CONTRATO")
                        .Add("DS_LOCAL_DATA")
                        .Add("NO_FILIAL")
                        .Add("CNPJ_FILIAL")
                        .Add("END_FILIAL")
                        .Add("IC_JURIDICA")
                        .Add("NO_CLIENTE")
                        .Add("CNPJ_CPF_CLIENTE")
                        .Add("END_CLIENTE")
                        .Add("QUANTIDADE").DataType = System.Type.GetType("System.Double")
                        .Add("DT_PRAZO_ENTREGA")
                        .Add("DT_PRAZO_FIXACAO")
                        .Add("NO_LOCAL_ENTREGA")
                    End With

                    For iCont = 0 To oData_02.Rows.Count - 1
                        oRow = oData_01.NewRow
                        oData_01.Rows.Add(oRow)

                        With oData_02.Rows(iCont)
                            oRow.Item("CD_CONTRATO") = Trim(.Item("CD_CONTRATO_PAF"))
                            oRow.Item("DS_LOCAL_DATA") = "Local e Data: " & Trim(.Item("NO_CIDADE_FILIAL_EMISSAO")) & ", " & _
                                                                            DatePart(DateInterval.Day, .Item("DT_CONTRATO_PAF")) & " de " & VerMes(.Item("DT_CONTRATO_PAF")) & " de " & DatePart(DateInterval.Year, .Item("DT_CONTRATO_PAF"))
                            oRow.Item("NO_FILIAL") = .Item("NO_FILIAL")
                            oRow.Item("CNPJ_FILIAL") = .Item("CNPJ_FILIAL")
                            oRow.Item("END_FILIAL") = Trim(.Item("END_FILIAL")) & " - " & Trim(.Item("NO_CIDADE_FILIAL_EMISSAO")) & " - " & Trim(.Item("CD_UF_FILIAL_EMISSOR"))
                            oRow.Item("IC_JURIDICA") = .Item("IC_FISICO_JURIDICO")
                            oRow.Item("NO_CLIENTE") = .Item("NO_RAZAO_SOCIAL")
                            oRow.Item("CNPJ_CPF_CLIENTE") = .Item("NU_CGC_CPF")
                            oRow.Item("END_CLIENTE") = Trim(.Item("DS_ENDERECO_FORNECEDOR")) & " - " & Trim(.Item("NO_BAIRRO_FORNECEDOR")) & " - " & Trim(.Item("NO_CIDADE_FORNECEDOR")) & " - " & Trim(.Item("CD_UF_FORNECEDOR"))
                            oRow.Item("QUANTIDADE") = NVL(.Item("QT_KGS"), 0)
                            oRow.Item("DT_PRAZO_ENTREGA") = VB.Left(NVL(.Item("DT_PRAZO_ENTREGA"), ""), 10)
                            Select Case .Item("CD_TIPO_CONTRATO_PAF")
                                Case cnt_TipoContratoPAF_ContratoPAFComADTO
                                    oRow.Item("DT_PRAZO_ENTREGA") = "de " & .Item("DT_CONTRATO_PAF") & " a " & .Item("DT_PRAZO_ENTREGA")
                                Case Else
                                    oRow.Item("DT_PRAZO_ENTREGA") = "de " & Data_Safra_Inicio(.Item("DT_CONTRATO_PAF")) & " a " & Data_Safra_Fim(.Item("DT_CONTRATO_PAF"))
                            End Select
                            oRow.Item("DT_PRAZO_FIXACAO") = VB.Left(NVL(.Item("DT_PRAZO_FIXACAO"), ""), 10)
                            oRow.Item("NO_LOCAL_ENTREGA") = .Item("NO_LOCAL_ENTREGA")
                        End With
                    Next

                    SqlText = "SELECT " & Filtro01 & " CD_CONTRATO," & _
                                     "NO_SIGLA NO_ANALISE," & _
                                     "VL_ANALISE_DESEJADA PC_DESEJADA," & _
                                     "VL_ANALISE_MAXIMA PC_MAXIMO" & _
                              " FROM SOF.ANALISE_CONFIGURACAO" & _
                              " WHERE CD_PROCESSO = " & cnt_Processo_Recepcao & _
                                " AND (VL_ANALISE_DESEJADA IS NOT NULL OR VL_ANALISE_MAXIMA IS NOT NULL)" & _
                              " ORDER BY NO_SIGLA"
                    oData_02 = DBQuery(SqlText)

                    oRelatorio.Load(Application.StartupPath & "\RPT_ContratoPAF_2010.rpt")
                    oRelatorioSub01 = oRelatorio.OpenSubreport("RPT_ContratoPAF_2010_Qualidade")
                    oRelatorio.SetDataSource(oData_01)
                    oRelatorioSub01.SetDataSource(oData_02)

                    sEMail = ContratoPAF_CapturaEnderecoEMail(Filtro01)

                    If Trim(sEMail) <> "" Then
                        Botao_Exibir(enBotao_Tipo.EnviarEMail_Contrato)
                    End If
                Case enRelGeral_Tipo.eNegociacao_ContratoPAF_Master
                    Me.Text = "Contrato Nº " & Filtro01

                    SqlText = "SELECT COUNT(*)" & _
                              " FROM SOF.CONTRATO_PAF" & _
                              " WHERE CD_FORNECEDOR_BENEFICIADO IS NOT NULL " & _
                                " AND CD_CONTRATO_PAF = " & Filtro01

                    If DBQuery_ValorUnico(SqlText) <> 0 Then
                        Botao_Exibir(enBotao_Tipo.ContratoBeneficiado_PAF)
                    End If

                    SqlText = "SELECT PAF.CD_CONTRATO_PAF," & _
                                     "NEG.SQ_NEGOCIACAO," & _
                                     "FIL.NO_RAZAO NO_FILIAL," & _
                                     "FIL.NU_CGC CNPJ_FILIAL," & _
                                     "FIL.DS_ENDERECO END_FILIAL," & _
                                     "MFIL.NO_CIDADE NO_CIDADE_FILIAL_EMISSAO," & _
                                     "MFIL.CD_UF CD_UF_FILIAL_EMISSOR," & _
                                     "PAF.DT_CONTRATO_PAF," & _
                                     "F.NO_RAZAO_SOCIAL," & _
                                     "F.NU_CGC_CPF," & _
                                     "F.IC_FISICA_JURIDICA IC_FISICO_JURIDICO," & _
                                     "F.DS_ENDERECO DS_ENDERECO_FORNECEDOR," & _
                                     "F.NO_BAIRRO NO_BAIRRO_FORNECEDOR," & _
                                     "MFORN.NO_CIDADE NO_CIDADE_FORNECEDOR," & _
                                     "MFORN.CD_UF CD_UF_FORNECEDOR," & _
                                     "PAF.QT_KGS," & _
                                     "PAF.DT_PRAZO_ENTREGA," & _
                                     "NEG.VL_NEGOCIACAO," & _
                                     "LCE.NO_LOCAL_ENTREGA," & _
                                     "LCC.NO_LOCAL_CONFERENCIA," & _
                                     "MFET.NO_CIDADE NO_CIDADE_FILIAL_ENT_EMISSAO," & _
                                     "MFET.CD_UF CD_UF_FILIAL_ENT_EMISSOR" & _
                              " FROM SOF.NEGOCIACAO NEG," & _
                                    "SOF.CONTRATO_PAF PAF," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.FILIAL FET," & _
                                    "SOF.MUNICIPIO MFIL," & _
                                    "SOF.MUNICIPIO MFET," & _
                                    "SOF.FORNECEDOR F," & _
                                    "SOF.MUNICIPIO MFORN," & _
                                    "SOF.LOCAL_ENTREGA LCE," & _
                                    "SOF.LOCAL_CONFERENCIA LCC" & _
                              " WHERE NEG.CD_CONTRATO_PAF = " & Filtro01 & _
                                " AND NEG.SQ_NEGOCIACAO = " & Filtro02 & _
                                " AND PAF.CD_CONTRATO_PAF = NEG.CD_CONTRATO_PAF" & _
                                " AND FIL.CD_FILIAL = PAF.CD_FILIAL_ORIGEM" & _
                                " AND MFIL.CD_MUNICIPIO = FIL.CD_MUNICIPIO" & _
                                " AND F.CD_FORNECEDOR = PAF.CD_FORNECEDOR" & _
                                " AND MFORN.CD_MUNICIPIO (+) = F.CD_MUNICIPIO" & _
                                " AND LCE.CD_LOCAL_ENTREGA (+) = NEG.CD_LOCAL_ENTREGA" & _
                                " AND FET.CD_FILIAL (+) = NEG.CD_FILIAL_ENTREGA" & _
                                " AND MFET.CD_MUNICIPIO = FET.CD_MUNICIPIO" & _
                                " AND LCC.CD_LOCAL_CONFERENCIA (+) = FET.CD_LOCAL_CONFERENCIA_PESO"
                    oData_02 = DBQuery(SqlText)

                    oData_01 = New DataTable

                    With oData_01.Columns
                        .Add("CD_CONTRATO")
                        .Add("DS_LOCAL_DATA")
                        .Add("NO_FILIAL")
                        .Add("CNPJ_FILIAL")
                        .Add("END_FILIAL")
                        .Add("IC_JURIDICA")
                        .Add("NO_CLIENTE")
                        .Add("CNPJ_CPF_CLIENTE")
                        .Add("END_CLIENTE")
                        .Add("QUANTIDADE").DataType = System.Type.GetType("System.Double")
                        .Add("VL_PRECO_UNITARIO").DataType = System.Type.GetType("System.Double")
                        .Add("DT_PRAZO_ENTREGA_INI")
                        .Add("DT_PRAZO_ENTREGA_FIM")
                        .Add("NO_LOCAL_ENTREGA")
                    End With

                    For iCont = 0 To oData_02.Rows.Count - 1
                        oRow = oData_01.NewRow
                        oData_01.Rows.Add(oRow)

                        With oData_02.Rows(iCont)
                            oRow.Item("CD_CONTRATO") = Trim(.Item("CD_CONTRATO_PAF")) & "-" & Trim(.Item("SQ_NEGOCIACAO"))
                            oRow.Item("DS_LOCAL_DATA") = "Local e Data: " & Trim(.Item("NO_CIDADE_FILIAL_EMISSAO")) & ", " & _
                                                                            DatePart(DateInterval.Day, .Item("DT_CONTRATO_PAF")) & " de " & VerMes(.Item("DT_CONTRATO_PAF")) & " de " & DatePart(DateInterval.Year, .Item("DT_CONTRATO_PAF"))
                            oRow.Item("NO_FILIAL") = .Item("NO_FILIAL")
                            oRow.Item("CNPJ_FILIAL") = .Item("CNPJ_FILIAL")
                            oRow.Item("END_FILIAL") = Trim(.Item("END_FILIAL")) & " - " & Trim(.Item("NO_CIDADE_FILIAL_EMISSAO")) & "-" & Trim(.Item("CD_UF_FILIAL_EMISSOR"))
                            oRow.Item("IC_JURIDICA") = .Item("IC_FISICO_JURIDICO")
                            oRow.Item("NO_CLIENTE") = .Item("NO_RAZAO_SOCIAL")
                            oRow.Item("CNPJ_CPF_CLIENTE") = .Item("NU_CGC_CPF")
                            oRow.Item("END_CLIENTE") = Trim(.Item("DS_ENDERECO_FORNECEDOR")) & IIf(objDataTable_CampoVazio(.Item("NO_BAIRRO_FORNECEDOR")), "", " - " & Trim(NVL(.Item("NO_BAIRRO_FORNECEDOR"), ""))) & " - " & Trim(.Item("NO_CIDADE_FORNECEDOR")) & " - " & Trim(.Item("CD_UF_FORNECEDOR"))
                            oRow.Item("QUANTIDADE") = NVL(.Item("QT_KGS"), 0)
                            oRow.Item("VL_PRECO_UNITARIO") = NVL(.Item("VL_NEGOCIACAO"), 0)
                            oRow.Item("DT_PRAZO_ENTREGA_INI") = VB.Left(NVL(.Item("DT_CONTRATO_PAF"), ""), 10)
                            oRow.Item("DT_PRAZO_ENTREGA_FIM") = VB.Left(NVL(.Item("DT_PRAZO_ENTREGA"), ""), 10)
                            oRow.Item("NO_LOCAL_ENTREGA") = Trim(.Item("NO_LOCAL_CONFERENCIA")) & " - " & Trim(.Item("NO_CIDADE_FILIAL_ENT_EMISSAO")) & "-" & Trim(.Item("CD_UF_FILIAL_ENT_EMISSOR"))
                        End With
                    Next

                    SqlText = "SELECT " & Filtro01 & " CD_CONTRATO," & _
                                     "NO_SIGLA NO_ANALISE," & _
                                     "VL_ANALISE_DESEJADA PC_DESEJADA," & _
                                     "VL_ANALISE_MAXIMA PC_MAXIMO" & _
                              " FROM SOF.ANALISE_CONFIGURACAO" & _
                              " WHERE CD_PROCESSO = " & cnt_Processo_Recepcao & _
                                " AND (VL_ANALISE_DESEJADA IS NOT NULL OR VL_ANALISE_MAXIMA IS NOT NULL)" & _
                              " ORDER BY NO_SIGLA"
                    oData_02 = DBQuery(SqlText)

                    oRelatorio.Load(Application.StartupPath & "\RPT_ContratoPAF_Master.rpt")
                    oRelatorioSub01 = oRelatorio.OpenSubreport("RPT_ContratoPAF_Master_Qualidade")
                    oRelatorio.SetDataSource(oData_01)
                    oRelatorioSub01.SetDataSource(oData_02)

                    sEMail = ContratoPAF_CapturaEnderecoEMail(Filtro01)

                    If Trim(sEMail) <> "" Then
                        Botao_Exibir(enBotao_Tipo.EnviarEMail_Contrato)
                    End If
                Case enRelGeral_Tipo.eContratoPAF_Beneficiario
                    Dim IC_Adiantamento As String = ""

                    Me.Text = "Contrato Nº " & Filtro01 & " Beneficiado"

                    oData_01 = Gera_Rs_Impressao_Contrato_PAF(Filtro01, IC_Adiantamento, True)

                    If IC_Adiantamento = "S" Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_ContratoPAF_ComAdiatamento.rpt")
                    Else
                        oRelatorio.Load(Application.StartupPath & "\RPT_ContratoPAF_SemAdiatamento.rpt")
                    End If

                    oRelatorio.SetDataSource(oData_01)

                    sEMail = ContratoPAF_CapturaEnderecoEMail(Filtro01)

                    If Trim(sEMail) <> "" Then
                        Botao_Exibir(enBotao_Tipo.EnviarEMail_Contrato)
                    End If
                Case enRelGeral_Tipo.eContrato_Outros
                    SqlText = "SELECT     TO_CHAR(CTR.CD_CONTRATO) AS NUMCTR," & _
                                     "CTR.DT_CONTRATO," & _
                                     "FRN.CD_TIPO_PESSOA," & _
                                     "FRN.IC_FISICA_JURIDICA," & _
                                     "FRN.NO_RAZAO_SOCIAL," & _
                                     "FRN.DS_ENDERECO," & _
                                     "FRN.NO_BAIRRO," & _
                                     "FRN.NU_INSC_ESTADUAL," & _
                                     "MNC.NO_CIDADE," & _
                                     "MNC.CD_UF," & _
                                     "FRN.NU_CGC_CPF," & _
                                     "CTR.QT_KGS," & _
                                     "CTR.CD_TIPO_PRECO," & _
                                     "CTR.VL_UNITARIO," & _
                                     "FRN.NU_FAX," & _
                                     "TPC.DS_CONDICAO," & _
                                     "TPC.DS_LOCAL_ENTREGA," & _
                                     "TPC.DS_OBS " & _
                              " FROM SOF.CONTRATO CTR," & _
                                    "SOF.FORNECEDOR FRN," & _
                                    "SOF.MUNICIPIO MNC," & _
                                    "SOF.TIPO_CONTRATO TPC" & _
                              " WHERE CTR.CD_FORNECEDOR = CTR.CD_FORNECEDOR" & _
                                " AND FRN.CD_MUNICIPIO = MNC.CD_MUNICIPIO" & _
                                " AND CTR.CD_TIPO_CONTRATO = TPC.CD_TIPO_CONTRATO" & _
                                " AND CTR.CD_CONTRATO = " & Filtro01
                    oData_01 = DBQuery(SqlText)

                    Me.Text = "Contrato Nº " & Filtro01

                    oRelatorio.Load(Application.StartupPath & "\RPT_Contrato_Outros.rpt")
                    oRelatorio.SetDataSource(oData_01)
                Case enRelGeral_Tipo.eNegociacao
                    Dim IC_PrecoFixo As String = ""
                    Dim IC_Bolsa As String = ""
                    Dim IC_Dolar As String = ""
                    Dim IC_Adiatamento As String = ""

                    Me.Text = "Negociação Nº " & Filtro01 & " - " & Filtro02

                    SqlText = "SELECT COUNT(*)" & _
                              " FROM SOF.CONTRATO_PAF F" & _
                              " WHERE NOT F.CD_FORNECEDOR_BENEFICIADO IS NULL" & _
                                " AND F.CD_CONTRATO_PAF =" & Filtro01
                    If DBQuery_ValorUnico(SqlText) <> 0 Then
                        Botao_Exibir(enBotao_Tipo.ContratoBeneficiado_Negociacao)
                    End If

                    oData_01 = Gera_Rs_Impressao_Negociacao(Filtro01, Filtro02, IC_PrecoFixo, IC_Bolsa, IC_Dolar, False)

                    If IC_PrecoFixo = "S" Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_Negociacao.rpt")
                    ElseIf IC_Bolsa = "S" Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_Negociacao_Bolsa.rpt")
                    ElseIf IC_Dolar = "S" Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_Negociacao_US.rpt")
                    End If

                    sEMail = ContratoPAF_CapturaEnderecoEMail(Filtro01)

                    If Trim(sEMail) <> "" Then
                        Botao_Exibir(enBotao_Tipo.EnviarEMail_Contrato)
                    End If

                    oRelatorio.SetDataSource(oData_01)

                    oData_02 = Gera_Rs_Impressao_Contrato_PAF(Filtro01, IC_Adiatamento, False)

                    oRelatorioSub01 = oRelatorio.OpenSubreport("RPT_ContratoPAF_ComAdiatamento.rpt")
                    oRelatorioSub01.SetDataSource(oData_02)
                Case enRelGeral_Tipo.eNegociacao_Beneficiario
                    Dim IC_PrecoFixo As String = ""
                    Dim IC_Bolsa As String = ""
                    Dim IC_Dolar As String = ""
                    Dim IC_Adiatamento As String = ""

                    Me.Text = "Negociação Nº " & Filtro01 & " - " & Filtro02 & " Beneficiado"

                    oData_01 = Gera_Rs_Impressao_Negociacao(Filtro01, Filtro02, IC_PrecoFixo, IC_Bolsa, IC_Dolar, True)

                    If IC_PrecoFixo = "S" Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_Negociacao.rpt")
                    ElseIf IC_Bolsa = "S" Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_Negociacao_Bolsa.rpt")
                    ElseIf IC_Dolar = "S" Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_Negociacao_US.rpt")
                    End If

                    sEMail = ContratoPAF_CapturaEnderecoEMail(Filtro01)

                    If Trim(sEMail) <> "" Then
                        Botao_Exibir(enBotao_Tipo.EnviarEMail_Contrato)
                    End If

                    oRelatorio.SetDataSource(oData_01)

                    oData_02 = Gera_Rs_Impressao_Contrato_PAF(Filtro01, IC_Adiatamento, False)

                    oRelatorioSub01 = oRelatorio.OpenSubreport("RPT_ContratoPAF_ComAdiatamento.rpt")
                    oRelatorioSub01.SetDataSource(oData_02)
                Case enRelGeral_Tipo.eDeclaracaoFixacaoPreco
                    Me.Text = "Declaração de Fixação de Preço"

                    SqlText = "SELECT CF.CD_CONTRATO_PAF," & _
                                     "CF.SQ_NEGOCIACAO," & _
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
                                     "CF.QT_KGS," & _
                                     "CF.VL_UNITARIO," & _
                                     "TU.QT_FATOR," & _
                                     "N.DT_NEGOCIACAO," & _
                                     "CF.DT_CONTRATO_FIXO," & _
                                     "F.IC_FISICA_JURIDICA IC_FISICO_JURIDICO," & _
                                     "0 VL_EXTENSO," & _
                                     "CF.SQ_CONTRATO_FIXO," & _
                                     "CF.VL_TOTAL" & _
                              " FROM SOF.CONTRATO_PAF CP," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.FORNECEDOR F," & _
                                    "SOF.MUNICIPIO MFIL," & _
                                    "SOF.MUNICIPIO MFORN," & _
                                    "SOF.CONTRATO_FIXO CF," & _
                                    "SOF.TIPO_UNIDADE TU," & _
                                    "SOF.NEGOCIACAO N " & _
                              " WHERE FIL.CD_FILIAL = CP.CD_FILIAL_ORIGEM" & _
                                " AND F.CD_FORNECEDOR = CP.CD_FORNECEDOR" & _
                                " AND FIL.CD_MUNICIPIO = MFIL.CD_MUNICIPIO" & _
                                " AND F.CD_MUNICIPIO = MFORN.CD_MUNICIPIO" & _
                                " AND CP.CD_CONTRATO_PAF=CF.CD_CONTRATO_PAF" & _
                                " AND CF.CD_CONTRATO_PAF =N.CD_CONTRATO_PAF" & _
                                " AND CF.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO" & _
                                " AND CF.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                                " AND CF.CD_CONTRATO_PAF=" & Filtro01 & _
                                " AND CF.SQ_NEGOCIACAO=" & Filtro02 & _
                                " AND CF.SQ_CONTRATO_FIXO=" & Filtro03
                    oData_01 = DBQuery(SqlText)

                    oRelatorio.Load(Application.StartupPath & "\RPT_DeclaracaoFixacaoPreco.rpt")

                    sEMail = ContratoPAF_CapturaEnderecoEMail(Filtro01)

                    If Trim(sEMail) <> "" Then
                        Botao_Exibir(enBotao_Tipo.EnviarEMail_Contrato)
                    End If

                    oRelatorio.SetDataSource(oData_01)
                Case enRelGeral_Tipo.eDeclaracaoFixacaoPreco_DiferencialBolsa, _
                     enRelGeral_Tipo.eDeclaracaoFixacaoPreco_DolarFlutuante
                    Me.Text = "Declaração de Fixação de Preço"

                    SqlText = "SELECT CF.CD_CONTRATO_PAF," & _
                                     "CF.SQ_NEGOCIACAO," & _
                                     "CF.SQ_CONTRATO_FIXO," & _
                                     "MFIL.NO_CIDADE NO_CIDADE_FILIAL_EMISSAO," & _
                                     "FIL.NO_RAZAO NO_FILIAL," & _
                                     "FIL.NU_CGC CNPJ_FILIAL," & _
                                     "FIL.DS_ENDERECO END_FILIAL," & _
                                     "MFIL.CD_UF CD_UF_FILIAL_EMISSOR," & _
                                     "F.NO_RAZAO_SOCIAL," & _
                                     "F.NU_CGC_CPF," & _
                                     "F.DS_ENDERECO DS_ENDERECO_FORNECEDOR," & _
                                     "F.NO_BAIRRO NO_BAIRRO_FORNECEDOR," & _
                                     "MFORN.NO_CIDADE NO_CIDADE_FORNECEDOR," & _
                                     "MFORN.CD_UF CD_UF_FORNECEDOR," & _
                                     "CF.QT_KGS," & _
                                     "CF.VL_UNITARIO," & _
                                     "TU.QT_FATOR," & _
                                     "N.DT_NEGOCIACAO," & _
                                     "CF.DT_CONTRATO_FIXO," & _
                                     "F.IC_FISICA_JURIDICA IC_FISICO_JURIDICO," & _
                                     "0 VL_EXTENSO," & _
                                     "CF.VL_TOTAL," & _
                                     "CF.VL_TAXA_DOLAR" & _
                              " FROM SOF.CONTRATO_PAF CP," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.FORNECEDOR F," & _
                                    "SOF.MUNICIPIO MFIL," & _
                                    "SOF.MUNICIPIO MFORN," & _
                                    "SOF.CONTRATO_FIXO CF," & _
                                    "SOF.TIPO_UNIDADE TU," & _
                                    "SOF.NEGOCIACAO N " & _
                              " WHERE FIL.CD_FILIAL = CP.CD_FILIAL_ORIGEM" & _
                                " AND F.CD_FORNECEDOR = CP.CD_FORNECEDOR" & _
                                " AND FIL.CD_MUNICIPIO = MFIL.CD_MUNICIPIO" & _
                                " AND F.CD_MUNICIPIO = MFORN.CD_MUNICIPIO" & _
                                " AND CP.CD_CONTRATO_PAF=CF.CD_CONTRATO_PAF" & _
                                " AND CF.CD_CONTRATO_PAF =N.CD_CONTRATO_PAF" & _
                                " AND CF.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO" & _
                                " AND CF.CD_TIPO_UNIDADE = TU.CD_TIPO_UNIDADE" & _
                                " AND CF.CD_CONTRATO_PAF = " & Filtro01 & _
                                " AND CF.SQ_NEGOCIACAO = " & Filtro02 & _
                                " AND CF.SQ_CONTRATO_FIXO = " & Filtro03
                    oData_02 = DBQuery(SqlText)

                    With oData_01.Columns
                        .Add("CD_CONTRATO_FIXO")
                        .Add("DS_LOCAL_DATA")
                        .Add("NO_FILIAL")
                        .Add("CNPJ_FILIAL")
                        .Add("END_FILIAL")
                        .Add("IC_JURIDICA")
                        .Add("NO_CLIENTE")
                        .Add("CNPJ_CPF_CLIENTE")
                        .Add("END_CLIENTE")
                        .Add("TX_DOLAR").DataType = System.Type.GetType("System.Double")
                        .Add("KG_EXT")
                        .Add("VL_UNIT_EXT")
                        .Add("VL_TOTAL_EXT")
                    End With

                    For iCont = 0 To oData_02.Rows.Count - 1
                        oRow = oData_01.NewRow
                        oData_01.Rows.Add(oRow)

                        With oData_02.Rows(iCont)
                            oRow.Item("CD_CONTRATO_FIXO") = Trim(.Item("CD_CONTRATO_PAF")) & "-" & Trim(.Item("SQ_NEGOCIACAO")) & "-" & Trim(.Item("SQ_CONTRATO_FIXO"))
                            oRow.Item("DS_LOCAL_DATA") = "Local e Data: " & Trim(.Item("NO_CIDADE_FILIAL_EMISSAO")) & ", " & _
                                                                            DatePart(DateInterval.Day, .Item("DT_CONTRATO_FIXO")) & " de " & VerMes(.Item("DT_CONTRATO_FIXO")) & " de " & DatePart(DateInterval.Year, .Item("DT_CONTRATO_FIXO"))
                            oRow.Item("NO_FILIAL") = .Item("NO_FILIAL")
                            oRow.Item("CNPJ_FILIAL") = .Item("CNPJ_FILIAL")
                            oRow.Item("END_FILIAL") = Trim(.Item("END_FILIAL")) & " - " & Trim(.Item("NO_CIDADE_FILIAL_EMISSAO")) & " - " & Trim(.Item("CD_UF_FILIAL_EMISSOR"))
                            oRow.Item("IC_JURIDICA") = .Item("IC_FISICO_JURIDICO")
                            oRow.Item("NO_CLIENTE") = .Item("NO_RAZAO_SOCIAL")
                            oRow.Item("CNPJ_CPF_CLIENTE") = .Item("NU_CGC_CPF")
                            oRow.Item("END_CLIENTE") = Trim(.Item("DS_ENDERECO_FORNECEDOR")) & " - " & Trim(.Item("NO_BAIRRO_FORNECEDOR")) & " - " & Trim(.Item("NO_CIDADE_FORNECEDOR")) & " - " & Trim(.Item("CD_UF_FORNECEDOR"))
                            oRow.Item("TX_DOLAR") = NVL(.Item("VL_TAXA_DOLAR"), 0)
                            oRow.Item("KG_EXT") = FormatNumber(.Item("QT_KGS"), 0) & " Kg (" & Trim(Extenso(.Item("QT_KGS"), " quilos", " quilo") & ")")
                            oRow.Item("VL_UNIT_EXT") = FormatNumber(.Item("VL_UNITARIO")) & " (" & Trim(Extenso(.Item("VL_UNITARIO")) & ")")
                            oRow.Item("VL_TOTAL_EXT") = FormatNumber(.Item("VL_TOTAL")) & " (" & Trim(Extenso(.Item("VL_TOTAL")) & ")")
                        End With
                    Next

                    If RelGeral_Tipo = enRelGeral_Tipo.eDeclaracaoFixacaoPreco_DiferencialBolsa Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_DeclaracaoFixacaoPreco_DiferencialBolsa.rpt")
                    ElseIf RelGeral_Tipo = enRelGeral_Tipo.eDeclaracaoFixacaoPreco_DolarFlutuante Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_DeclaracaoFixacaoPreco_DolarFlutuante.rpt")
                    End If

                    sEMail = ContratoPAF_CapturaEnderecoEMail(Filtro01)

                    If Trim(sEMail) <> "" Then
                        Botao_Exibir(enBotao_Tipo.EnviarEMail_Contrato)
                    End If

                    oRelatorio.SetDataSource(oData_01)
                Case enRelGeral_Tipo.eSaldoSacariaFilial
                    SqlText = "SELECT   f.cd_filial, f.no_filial, ts.no_tipo_sacaria, ts.cd_tipo_sacaria, "
                    SqlText = SqlText & "         SUM (DECODE (sf.ic_entrada_saida, 'E', sf.qt_sacos, -1 * sf.qt_sacos) "
                    SqlText = SqlText & "             ) AS qt_volume "
                    SqlText = SqlText & "    FROM sof.sacaria_filial sf, sof.tipo_sacaria ts, sof.filial f "
                    SqlText = SqlText & "   WHERE sf.cd_tipo_sacaria = ts.cd_tipo_sacaria "
                    SqlText = SqlText & "     AND sf.cd_filial_credito = f.cd_filial "
                    SqlText = SqlText & "     AND f.ic_ativa = 'S' "
                    SqlText = SqlText & "GROUP BY f.cd_filial, f.no_filial, ts.no_tipo_sacaria, ts.cd_tipo_sacaria "
                    SqlText = SqlText & "  HAVING SUM (DECODE (sf.ic_entrada_saida, 'E', sf.qt_sacos, -1 * sf.qt_sacos)) <> 0 "

                    oData_01 = DBQuery(SqlText)

                    oRelatorio.Load(Application.StartupPath & "\RPT_Saldo_Sacaria_Filial.rpt")
                    oRelatorio.SetDataSource(oData_01)
                    oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                    Me.Text = "Relatório Saldo Filial"
                Case enRelGeral_Tipo.eSacariaRequisicao
                    SqlText = "SELECT SR.SQ_SACARIA_REQUISICAO," & _
                                     "FI.NO_FILIAL," & _
                                     "SR.DT_REQUISICAO," & _
                                     "FN.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                                     "SR.IC_ENTRADA_SAIDA," & _
                                     "TS.NO_TIPO_SACARIA," & _
                                     "SRI.QT_SACOS," & _
                                     "UG.NO_USUARIO NO_GERENTE," & _
                                     "UF.NO_USUARIO NO_FIEL," & _
                                     "SR.NO_TOMADOR," & _
                                     "SR.NO_RG " & _
                              " FROM SOF.SACARIA_REQUISICAO SR," & _
                                    "SOF.SACARIA_REQUISICAO_ITEM SRI," & _
                                    "SOF.TIPO_SACARIA TS," & _
                                    "SOF.FORNECEDOR FN," & _
                                    "SOF.FILIAL FI," & _
                                    "AGC.SEC_USUARIO UF," & _
                                    "AGC.SEC_USUARIO UG" & _
                              " WHERE SR.SQ_SACARIA_REQUISICAO = " & Filtro01 & _
                                " AND SRI.SQ_SACARIA_REQUISICAO = SR.SQ_SACARIA_REQUISICAO" & _
                                " AND TS.CD_TIPO_SACARIA = SRI.CD_TIPO_SACARIA" & _
                                " AND FN.CD_FORNECEDOR = SR.CD_FORNECEDOR" & _
                                " AND UG.CD_USUARIO (+) = SR.CD_USUARIO_SOLICITACAO" & _
                                " AND UF.CD_USUARIO (+) =  DECODE(SRI.NO_USER_ALTERACAO ,NULL,SRI.NO_USER_CRIACAO,SRI.NO_USER_ALTERACAO)" & _
                                " AND FI.CD_FILIAL (+) = SR.CD_FILIAL"

                    Me.Text = "Recibo de Entrega de Sacaria Nº " & Filtro01

                    oData_01 = DBQuery(SqlText)

                    oRelatorio.Load(Application.StartupPath & "\RPT_Sacaria_ComprovaEntregaRecebimento.rpt")
                    oRelatorio.SetDataSource(oData_01)
                    oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                Case enRelGeral_Tipo.eUtilizacaoSistema
                    SqlText = "SELECT R.CD_RELATORIO," & _
                                     "R.NO_RELATORIO," & _
                                     "R.DS_DESCRICAO," & _
                                     "R.DS_RESPONSAVEIS," & _
                                     "U.NO_USUARIO," & _
                                     "RU.QT_ACESSO," & _
                                     "RU.DT_ULTIMO_ACESSO" & _
                              " FROM SOF.RELATORIO R," & _
                                    "SOF.RELATORIO_UTILIZACAO RU," & _
                                    "SOF.USUARIO U" & _
                              " WHERE R.CD_RELATORIO =" & Filtro01 & _
                                " AND R.CD_TIPO = " & Filtro02 & _
                                " AND RU.CD_RELATORIO = R.CD_RELATORIO" & _
                                " AND RU.CD_TIPO = R.CD_TIPO" & _
                                " AND U.CD_USER = RU.NO_USUARIO"
                    oData_01 = DBQuery(SqlText)

                    oRelatorio.Load(Application.StartupPath & "\RPT_Utilizacao_Sistema.rpt")
                    oRelatorio.SetDataSource(oData_01)
                    oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                    Me.Text = "Relatório Utilização Sistema"
                Case enRelGeral_Tipo.eNegociacao_Aditamento
                    Dim bImprimir As Boolean = False

                    SqlText = "SELECT PAF.CD_CONTRATO_PAF," & _
                                     "NEG.SQ_NEGOCIACAO," & _
                                     "NEG.CD_TIPO_NEGOCIACAO," & _
                                     "NEG.DT_NEGOCIACAO," & _
                                     "FIX.SQ_CONTRATO_FIXO," & _
                                     "FIL.NO_RAZAO NO_FILIAL," & _
                                     "FIL.NU_CGC CNPJ_FILIAL," & _
                                     "FIL.DS_ENDERECO END_FILIAL," & _
                                     "MFIL.NO_CIDADE NO_CIDADE_FILIAL_EMISSAO," & _
                                     "MFIL.CD_UF CD_UF_FILIAL_EMISSOR," & _
                                     "PAF.DT_CONTRATO_PAF," & _
                                     "F.NO_RAZAO_SOCIAL," & _
                                     "F.NU_CGC_CPF," & _
                                     "F.IC_FISICA_JURIDICA IC_FISICO_JURIDICO," & _
                                     "F.DS_ENDERECO DS_ENDERECO_FORNECEDOR," & _
                                     "F.NO_BAIRRO NO_BAIRRO_FORNECEDOR," & _
                                     "MFORN.NO_CIDADE NO_CIDADE_FORNECEDOR," & _
                                     "MFORN.CD_UF CD_UF_FORNECEDOR," & _
                                     "PAF.QT_KGS QT_KGS_PAF," & _
                                     "NEG.QT_KGS," & _
                                     "PAF.DT_PRAZO_ENTREGA," & _
                                     "FIX.VL_UNITARIO," & _
                                     "FIX.VL_TOTAL," & _
                                     "PAF.DT_PRAZO_FIXACAO DT_PRAZO_FIXACAO_PAF," & _
                                     "NEG.DT_PRAZO_FIXACAO DT_PRAZO_FIXACAO_NEG," & _
                                     "NEG.VL_DIFERENCIAL," & _
                                     "NEG.VL_BOLSA," & _
                                     "SRN.SQ_SOLICITACAO," & _
                                     "SRN.DT_SOLICITACAO," & _
                                     "NGN.DT_NEGOCIACAO DT_NEGOCIACAO_ANT," & _
                                     "NGN.VL_NEGOCIACAO VL_NEGOCIACAO_ANT," & _
                                     "NGN.CD_PAPEL_COMPETENCIA CD_PAPEL_COMPETENCIA_ANT," & _
                                     "NEG.VL_NEGOCIACAO VL_NEGOCIACAO_ATUAL," & _
                                     "NEG.CD_PAPEL_COMPETENCIA CD_PAPEL_COMPETENCIA_ATUAL," & _
                                     "TRIM(FEP.DS_ENDERECO) || ' - ' || TRIM(MFEP.NO_CIDADE) || '-' || TRIM(MFEP.CD_UF) DS_END_FILIAL_ENTREGA_PAF," & _
                                     "TRIM(FEN.DS_ENDERECO) || ' - ' || TRIM(MFEN.NO_CIDADE) || '-' || TRIM(MFEN.CD_UF) DS_END_FILIAL_ENTREGA_NEG," & _
                                     "BPR.CD_PAPEL," & _
                                     "BPR.NO_PAPEL" & _
                              " FROM SOF.NEGOCIACAO NEG," & _
                                    "SOF.CONTRATO_PAF PAF," & _
                                    "(SELECT FX.*" & _
                                      " FROM SOF.NEGOCIACAO NG," & _
                                            "SOF.CONTRATO_FIXO FX" & _
                                    " WHERE NG.CD_TIPO_NEGOCIACAO = " & cnt_TIPO_NEGOCIACAO_FixoEmReal & _
                                      " AND FX.CD_CONTRATO_PAF = NG.CD_CONTRATO_PAF" & _
                                      " AND FX.SQ_NEGOCIACAO = NG.SQ_NEGOCIACAO) FIX," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.MUNICIPIO MFIL," & _
                                    "SOF.FORNECEDOR F," & _
                                    "SOF.MUNICIPIO MFORN," & _
                                    "SOF.FILIAL FEP," & _
                                    "SOF.MUNICIPIO MFEP," & _
                                    "SOF.FILIAL FEN," & _
                                    "SOF.MUNICIPIO MFEN," & _
                                    "SOF.SOLICITACAO_RENEGOCIACAO SRN," & _
                                    "SOF.NEGOCIACAO NGN," & _
                                    "SOF.BOLSA_PERIODO BPR" & _
                              " WHERE NEG.CD_CONTRATO_PAF = " & Filtro01 & _
                                " AND NEG.SQ_NEGOCIACAO = " & Filtro02 & _
                                " AND PAF.CD_CONTRATO_PAF = NEG.CD_CONTRATO_PAF" & _
                                " AND FIX.CD_CONTRATO_PAF(+)  = NEG.CD_CONTRATO_PAF" & _
                                " AND FIX.SQ_NEGOCIACAO (+) = NEG.SQ_NEGOCIACAO" & _
                                " AND SRN.CD_CONTRATO_PAF (+) = NEG.CD_CONTRATO_PAF" & _
                                " AND SRN.SQ_NEGOCIACAO_NOVA (+) = NEG.SQ_NEGOCIACAO" & _
                                " AND NGN.CD_CONTRATO_PAF (+) = SRN.CD_CONTRATO_PAF" & _
                                " AND NGN.SQ_NEGOCIACAO (+) = SRN.SQ_NEGOCIACAO" & _
                                " AND FIL.CD_FILIAL = PAF.CD_FILIAL_ORIGEM" & _
                                " AND MFIL.CD_MUNICIPIO = FIL.CD_MUNICIPIO" & _
                                " AND F.CD_FORNECEDOR = PAF.CD_FORNECEDOR" & _
                                " AND MFORN.CD_MUNICIPIO (+) = F.CD_MUNICIPIO" & _
                                " AND FEN.CD_FILIAL (+) = NEG.CD_FILIAL_ENTREGA" & _
                                " AND MFEN.CD_MUNICIPIO = FEN.CD_MUNICIPIO" & _
                                " AND FEP.CD_FILIAL (+) = PAF.CD_FILIAL_ENTREGA" & _
                                " AND MFEP.CD_MUNICIPIO (+) = FEP.CD_MUNICIPIO" & _
                                " AND BPR.CD_PAPEL (+) = NEG.CD_PAPEL"
                    oData_02 = DBQuery(SqlText)

                    oData_01 = New DataTable

                    With oData_01.Columns
                        .Add("CD_CONTRATO_PAF")
                        .Add("CD_CONTRATO_NEG")
                        .Add("DS_LOCAL_DATA")
                        .Add("NO_FILIAL")
                        .Add("CNPJ_FILIAL")
                        .Add("END_FILIAL")
                        .Add("IC_JURIDICA")
                        .Add("NO_CLIENTE")
                        .Add("CNPJ_CPF_CLIENTE")
                        .Add("END_CLIENTE")
                        .Add("KG_NOVO").DataType = System.Type.GetType("System.Double")
                        .Add("PER_ENTREGA_NOVO")
                        .Add("DS_MODALIDADE_NOVO")
                        .Add("VL_FIXADO_NOVO")
                        .Add("DS_TOTAL_NOVO_EXTENSO")
                        .Add("DT_MAX_FIXACAO_NOVO")
                        .Add("DS_DIFF_NOVO_EXTENSO")
                        .Add("DS_VLNEG_VELHO_EXTENSO")
                        .Add("DS_PER_BOLSA_VELHO_EXTENSO")
                        .Add("DS_VLNEG_NOVO_EXTENSO")
                        .Add("DS_PER_BOLSA_NOVO_EXTENSO")
                        .Add("DS_LOCAL_ENTREGA_NOVO")
                        .Add("NR_SECNUM_KG")
                        .Add("NR_SECNUM_PER_ENTREGA")
                        .Add("NR_SECNUM_MODALIDADE")
                        .Add("NR_SECNUM_PRECO")
                        .Add("NR_SECNUM_MAX_FIXACAOPRECO")
                        .Add("NR_SECNUM_CONDICAO_FIXACAOPRECO")
                        .Add("NR_SECNUM_LOCAL_ENTREGA")
                        .Add("NR_SECNUM_ROLAGEM")
                    End With

                    For iCont = 0 To oData_02.Rows.Count - 1
                        iAux = 0

                        Me.Text = "Contrato Nº " & Filtro01 & "-" & Filtro02

                        oRow = oData_01.NewRow
                        oData_01.Rows.Add(oRow)

                        With oData_02.Rows(iCont)
                            oRow.Item("CD_CONTRATO_PAF") = Trim(.Item("CD_CONTRATO_PAF"))
                            If objDataTable_CampoVazio(.Item("SQ_CONTRATO_FIXO")) Then
                                oRow.Item("CD_CONTRATO_NEG") = Trim(.Item("CD_CONTRATO_PAF")) & "-" & Trim(.Item("SQ_NEGOCIACAO"))
                            Else
                                oRow.Item("CD_CONTRATO_NEG") = Trim(.Item("CD_CONTRATO_PAF")) & "-" & Trim(.Item("SQ_NEGOCIACAO")) & "-" & Trim(.Item("SQ_CONTRATO_FIXO"))
                            End If
                            oRow.Item("DS_LOCAL_DATA") = "Local e Data: " & Trim(.Item("NO_CIDADE_FILIAL_EMISSAO")) & ", " & _
                                                                            DatePart(DateInterval.Day, .Item("DT_NEGOCIACAO")) & " de " & VerMes(.Item("DT_NEGOCIACAO")) & " de " & DatePart(DateInterval.Year, .Item("DT_NEGOCIACAO"))
                            oRow.Item("NO_FILIAL") = .Item("NO_FILIAL")
                            oRow.Item("CNPJ_FILIAL") = .Item("CNPJ_FILIAL")
                            oRow.Item("END_FILIAL") = Trim(.Item("END_FILIAL")) & " - " & Trim(.Item("NO_CIDADE_FILIAL_EMISSAO")) & " - " & Trim(.Item("CD_UF_FILIAL_EMISSOR"))
                            oRow.Item("IC_JURIDICA") = .Item("IC_FISICO_JURIDICO")
                            oRow.Item("NO_CLIENTE") = .Item("NO_RAZAO_SOCIAL")
                            oRow.Item("CNPJ_CPF_CLIENTE") = .Item("NU_CGC_CPF")
                            oRow.Item("END_CLIENTE") = Trim(.Item("DS_ENDERECO_FORNECEDOR")) & " - " & Trim(.Item("NO_BAIRRO_FORNECEDOR")) & " - " & Trim(.Item("NO_CIDADE_FORNECEDOR")) & " - " & Trim(.Item("CD_UF_FORNECEDOR"))

                            'Alteração de quantidade
                            If NVL(.Item("QT_KGS"), 0) <> NVL(.Item("QT_KGS_PAF"), 0) Then
                                bImprimir = True
                                oRow.Item("KG_NOVO") = NVL(.Item("QT_KGS"), 0)
                                oRow.Item("NR_SECNUM_KG") = Numero_Adicionar(iAux)
                            End If

                            'oRow.Item("PER_ENTREGA_NOVO") = ""
                            'oRow.Item("NR_SECNUM_PER_ENTREGA") = ""

                            If objDataTable_CampoVazio(.Item("SQ_SOLICITACAO")) Then
                                Select Case .Item("CD_TIPO_NEGOCIACAO")
                                    Case cnt_TIPO_NEGOCIACAO_FixoEmReal
                                        oRow.Item("DS_MODALIDADE_NOVO") = "Compra e venda a preço fixo em moeda corrente nacional"
                                        oRow.Item("NR_SECNUM_MODALIDADE") = Numero_Adicionar(iAux)

                                        oRow.Item("VL_FIXADO_NOVO") = Formatar_ValorPadraoBrasileiro(.Item("VL_UNITARIO"), "R$")
                                        oRow.Item("DS_TOTAL_NOVO_EXTENSO") = Formatar_ValorPadraoBrasileiro(.Item("VL_TOTAL"), "R$") & " (" & Extenso(.Item("VL_TOTAL")) & ")"
                                        oRow.Item("NR_SECNUM_PRECO") = Numero_Adicionar(iAux)
                                    Case cnt_TIPO_NEGOCIACAO_FixoEmDolar, cnt_TIPO_NEGOCIACAO_DiferencialBolsa
                                        oRow.Item("DS_DIFF_NOVO_EXTENSO") = .Item("VL_NEGOCIACAO_ATUAL") & " US$/Mton (" & IIf(.Item("VL_NEGOCIACAO_ATUAL") < 0, "menos ", "mais ") & LCase(Extenso(.Item("VL_NEGOCIACAO_ATUAL"), "", "")) & " dólares por tonelada métrica) da Bolsa NY-ICE cacau " + _
                                                                            .Item("CD_PAPEL") & " de " & .Item("NO_PAPEL")
                                        bImprimir = True
                                        'oRow.Item("DS_BOLSA_NOVO_EXTENSO") = Formatar_NumeroPadraoBrasileiro(.Item("VL_BOLSA"), 0) & " US$/Mton (" & LCase(Extenso(.Item("VL_BOLSA"), "", "")) & " dólares por tonelada métrica)"
                                        oRow.Item("NR_SECNUM_CONDICAO_FIXACAOPRECO") = Numero_Adicionar(iAux)
                                End Select
                            Else
                                oRow.Item("DS_VLNEG_VELHO_EXTENSO") = FormatNumber(.Item("VL_NEGOCIACAO_ANT"), 2) & " US$/Mton (" & Extenso(.Item("VL_NEGOCIACAO_ANT"), "", "") & " a dólares por tonelada métrica)"
                                oRow.Item("DS_PER_BOLSA_VELHO_EXTENSO") = Bolsa_Extenso(.Item("CD_PAPEL_COMPETENCIA_ANT"), .Item("DT_NEGOCIACAO_ANT"))
                                oRow.Item("DS_VLNEG_NOVO_EXTENSO") = FormatNumber(.Item("VL_NEGOCIACAO_ATUAL"), 2) & " US$/Mton (" & Extenso(.Item("VL_NEGOCIACAO_ATUAL"), "", "") & " a dólares por tonelada métrica)"
                                oRow.Item("DS_PER_BOLSA_NOVO_EXTENSO") = Bolsa_Extenso(.Item("CD_PAPEL_COMPETENCIA_ATUAL"), .Item("DT_SOLICITACAO"))
                                oRow.Item("NR_SECNUM_ROLAGEM") = Numero_Adicionar(iAux)
                            End If

                            'Alteração da data máxima de fixação de preço
                            If Not objDataTable_CampoVazio(.Item("DT_PRAZO_FIXACAO_NEG")) Then
                                If NVL(.Item("DT_PRAZO_FIXACAO_PAF"), Now.Date) <> NVL(.Item("DT_PRAZO_FIXACAO_NEG"), Now.Date) Then
                                    bImprimir = True
                                    oRow.Item("DT_MAX_FIXACAO_NOVO") = Format(.Item("DT_PRAZO_FIXACAO_NEG"), "dd/MM/yyyy")
                                    oRow.Item("NR_SECNUM_MAX_FIXACAOPRECO") = Numero_Adicionar(iAux)
                                End If
                            End If
                            If NVL(.Item("DS_END_FILIAL_ENTREGA_PAF"), "") <> NVL(.Item("DS_END_FILIAL_ENTREGA_NEG"), "") Then
                                bImprimir = True
                                oRow.Item("DS_LOCAL_ENTREGA_NOVO") = .Item("DS_END_FILIAL_ENTREGA_NEG")
                                oRow.Item("NR_SECNUM_LOCAL_ENTREGA") = Numero_Adicionar(iAux)
                            End If
                        End With
                    Next

                    If bImprimir Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_Negociacao_Aditamento.rpt")
                        oRelatorio.SetDataSource(oData_01)
                    Else
                        bHouveImpressao = False
                        Close()
                    End If
                Case enRelGeral_Tipo.eContrato_Aditivo
                    Dim bImprimir As Boolean = False

                    SqlText = "SELECT ADV.*," & _
                                     "NVL(CFX.DT_CONTRATO_FIXO, NVL(NEG.DT_NEGOCIACAO, PAF.DT_CONTRATO_PAF)) DT_CONTRATO," & _
                                     "FIL.NO_RAZAO NO_FILIAL," & _
                                     "FIL.NO_FILIAL," & _
                                     "MFIL.NO_CIDADE NO_CIDADE_FILIAL_EMISSAO," & _
                                     "F.NO_RAZAO_SOCIAL," & _
                                     "F.IC_FISICA_JURIDICA IC_FISICO_JURIDICO" & _
                              " FROM SOF.CONTRATO_ADITIVO ADV," & _
                                    "SOF.CONTRATO_PAF PAF," & _
                                    "SOF.NEGOCIACAO NEG," & _
                                    "SOF.CONTRATO_FIXO CFX," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.MUNICIPIO MFIL," & _
                                    "SOF.FORNECEDOR F" & _
                              " WHERE ADV.SQ_ADITIVO = " & Filtro01 & _
                                " AND PAF.CD_CONTRATO_PAF = ADV.CD_CONTRATO_PAF" & _
                                " AND NEG.CD_CONTRATO_PAF (+) = ADV.CD_CONTRATO_PAF" & _
                                " AND NEG.SQ_NEGOCIACAO (+) = ADV.SQ_NEGOCIACAO" & _
                                " AND CFX.CD_CONTRATO_PAF (+) = ADV.CD_CONTRATO_PAF" & _
                                " AND CFX.SQ_NEGOCIACAO (+) = ADV.SQ_NEGOCIACAO" & _
                                " AND CFX.SQ_CONTRATO_FIXO (+) = ADV.SQ_CONTRATO_FIXO" & _
                                " AND FIL.CD_FILIAL = PAF.CD_FILIAL_ORIGEM" & _
                                " AND MFIL.CD_MUNICIPIO = FIL.CD_MUNICIPIO" & _
                                " AND F.CD_FORNECEDOR = PAF.CD_FORNECEDOR"
                    oData_02 = DBQuery(SqlText)

                    oData_01 = New DataTable

                    With oData_01.Columns
                        .Add("CD_ADITIVO")
                        .Add("CD_CONTRATO_PAF")
                        .Add("DS_LOCAL_DATA")
                        .Add("DS_DATA_CONTRATO")
                        .Add("NO_FILIAL")
                        .Add("IC_JURIDICA")
                        .Add("NO_CLIENTE")
                        .Add("KG_VELHO").DataType = System.Type.GetType("System.Double")
                        .Add("KG_NOVO").DataType = System.Type.GetType("System.Double")
                        .Add("PER_ENTREGA_VELHO")
                        .Add("PER_ENTREGA_NOVO")
                        .Add("DS_MODALIDADE_NOVO")
                        .Add("VL_FIXADO_NOVO")
                        .Add("DS_TOTAL_NOVO_EXTENSO")
                        .Add("DT_MAX_FIXACAO_VELHO")
                        .Add("DT_MAX_FIXACAO_NOVO")
                        .Add("DS_DIFF_NOVO_EXTENSO")
                        .Add("DS_VLNEG_VELHO_EXTENSO")
                        .Add("DS_PER_BOLSA_VELHO_EXTENSO")
                        .Add("DS_VLNEG_NOVO_EXTENSO")
                        .Add("DS_PER_BOLSA_NOVO_EXTENSO")
                        .Add("DS_JUROS_NOVO_EXTENSO")
                        .Add("DS_LOCAL_ENTREGA_NOVO")
                        .Add("NR_SECNUM_KG")
                        .Add("NR_SECNUM_PER_ENTREGA")
                        .Add("NR_SECNUM_MODALIDADE")
                        .Add("NR_SECNUM_PRECO")
                        .Add("NR_SECNUM_MAX_FIXACAOPRECO")
                        .Add("NR_SECNUM_CONDICAO_FIXACAOPRECO")
                        .Add("NR_SECNUM_LOCAL_ENTREGA")
                        .Add("NR_SECNUM_ROLAGEM")
                        .Add("NR_SECNUM_JUROS")
                    End With

                    For iCont = 0 To oData_02.Rows.Count - 1
                        iAux = 0

                        Me.Text = "Contrato Nº " & Filtro01 & If(Filtro02 = 0, "", "-" & Filtro02) & If(Filtro03 = 0, "", "-" & Filtro03)

                        oRow = oData_01.NewRow
                        oData_01.Rows.Add(oRow)

                        With oData_02.Rows(iCont)
                            oRow.Item("CD_ADITIVO") = .Item("CD_CONTRATO_PAF") & _
                                                      If(NVL(.Item("SQ_NEGOCIACAO"), 0) = 0, "", "-" & .Item("SQ_NEGOCIACAO")) & _
                                                      If(NVL(.Item("SQ_CONTRATO_FIXO"), 0) = 0, "", "-" & .Item("SQ_CONTRATO_FIXO")) & _
                                                      If(NVL(.Item("SQ_ADITIVO"), 0) = 0, "", "-" & .Item("SQ_ADITIVO"))

                            oRow.Item("CD_CONTRATO_PAF") = Trim(.Item("CD_CONTRATO_PAF"))
                            oRow.Item("DS_LOCAL_DATA") = "Local e Data: " & Trim(.Item("NO_CIDADE_FILIAL_EMISSAO")) & ", " & _
                                                                            DatePart(DateInterval.Day, .Item("DT_CONTRATO")) & " de " & VerMes(.Item("DT_CONTRATO")) & " de " & DatePart(DateInterval.Year, .Item("DT_CONTRATO"))
                            oRow.Item("NO_FILIAL") = .Item("NO_FILIAL")
                            oRow.Item("IC_JURIDICA") = .Item("IC_FISICO_JURIDICO")
                            oRow.Item("NO_CLIENTE") = .Item("NO_RAZAO_SOCIAL")

                            'Alteração de quantidade
                            If Not CampoNulo(.Item("QT_KGS")) Then
                                bImprimir = True
                                oRow.Item("KG_VELHO") = NVL(.Item("QT_KGS_OLD"), 0)
                                oRow.Item("KG_NOVO") = NVL(.Item("QT_KGS"), 0)
                                oRow.Item("NR_SECNUM_KG") = Numero_Adicionar(iAux)
                            End If
                            If Not CampoNulo(.Item("DT_PRAZO_ENTREGA")) Then
                                bImprimir = True
                                oRow.Item("PER_ENTREGA_VELHO") = Mid(NVL(.Item("DT_PRAZO_ENTREGA_OLD"), ""), 1, 10)
                                oRow.Item("PER_ENTREGA_NOVO") = Mid(NVL(.Item("DT_PRAZO_ENTREGA"), ""), 1, 10)
                                oRow.Item("NR_SECNUM_PER_ENTREGA") = Numero_Adicionar(iAux)
                            End If
                            If Not CampoNulo(.Item("VL_UNITARIO")) Then
                                bImprimir = True
                                oRow.Item("VL_FIXADO_NOVO") = .Item("VL_UNITARIO")
                                oRow.Item("DS_TOTAL_NOVO_EXTENSO") = Extenso(.Item("VL_UNITARIO"))
                                oRow.Item("NR_SECNUM_PRECO") = Numero_Adicionar(iAux)
                            End If
                            If Not CampoNulo(.Item("DT_PRAZO_FIXACAO")) Then
                                bImprimir = True
                                oRow.Item("DT_MAX_FIXACAO_VELHO") = Mid(NVL(.Item("DT_PRAZO_FIXACAO_OLD"), ""), 1, 10)
                                oRow.Item("DT_MAX_FIXACAO_NOVO") = Mid(NVL(.Item("DT_PRAZO_FIXACAO"), ""), 1, 10)
                                oRow.Item("NR_SECNUM_MAX_FIXACAOPRECO") = Numero_Adicionar(iAux)
                            End If
                            If Not CampoNulo(.Item("PC_TAXA_JUROS")) Then
                                bImprimir = True
                                oRow.Item("VL_FIXADO_NOVO") = .Item("VL_UNITARIO")
                                oRow.Item("DS_JUROS_NOVO_EXTENSO") = .Item("PC_TAXA_JUROS") & "% (" & Extenso(.Item("PC_TAXA_JUROS")) & " por cento)"
                                oRow.Item("NR_SECNUM_JUROS") = Numero_Adicionar(iAux)
                            End If
                        End With
                    Next

                    If bImprimir Then
                        oRelatorio.Load(Application.StartupPath & "\RPT_CTR_Aditivo.rpt")
                        oRelatorio.SetDataSource(oData_01)
                    Else
                        bHouveImpressao = False
                        Close()
                    End If
                Case enRelGeral_Tipo.eContratoPAF_ConfCompra_CacauAOrdem
                    SqlText = "SELECT PAF.CD_CONTRATO_PAF," & _
                                     "FIL.NO_RAZAO NO_FILIAL," & _
                                     "FIL.NU_CGC CNPJ_FILIAL," & _
                                     "FIL.DS_ENDERECO END_FILIAL," & _
                                     "MFIL.NO_CIDADE NO_CIDADE_FILIAL_EMISSAO," & _
                                     "MFIL.CD_UF CD_UF_FILIAL_EMISSOR," & _
                                     "PAF.DT_CONTRATO_PAF," & _
                                     "F.NO_RAZAO_SOCIAL," & _
                                     "F.NU_CGC_CPF," & _
                                     "F.IC_FISICA_JURIDICA IC_FISICO_JURIDICO," & _
                                     "F.DS_ENDERECO DS_ENDERECO_FORNECEDOR," & _
                                     "F.NO_BAIRRO NO_BAIRRO_FORNECEDOR," & _
                                     "MFORN.NO_CIDADE NO_CIDADE_FORNECEDOR," & _
                                     "MFORN.CD_UF CD_UF_FORNECEDOR," & _
                                     "PAF.QT_KGS," & _
                                     "TRIM(MFEP.NO_CIDADE) || '-' || TRIM(MFEP.CD_UF) NO_LOCAL_ENTREGA" & _
                              " FROM SOF.CONTRATO_PAF PAF," & _
                                    "SOF.FILIAL FIL," & _
                                    "SOF.MUNICIPIO MFIL," & _
                                    "SOF.FORNECEDOR F," & _
                                    "SOF.MUNICIPIO MFORN," & _
                                    "SOF.FILIAL FEP," & _
                                    "SOF.MUNICIPIO MFEP" & _
                              " WHERE PAF.CD_CONTRATO_PAF = " & Filtro01 & _
                                " AND FIL.CD_FILIAL = PAF.CD_FILIAL_ORIGEM" & _
                                " AND MFIL.CD_MUNICIPIO = FIL.CD_MUNICIPIO" & _
                                " AND F.CD_FORNECEDOR = PAF.CD_FORNECEDOR" & _
                                " AND MFORN.CD_MUNICIPIO (+) = F.CD_MUNICIPIO" & _
                                " AND FEP.CD_FILIAL (+) = PAF.CD_FILIAL_ENTREGA" & _
                                " AND MFEP.CD_MUNICIPIO (+) = FEP.CD_MUNICIPIO"
                    oData_02 = DBQuery(SqlText)

                    oData_01 = New DataTable

                    With oData_01.Columns
                        .Add("CD_CONTRATO")
                        .Add("DS_LOCAL_DATA")
                        .Add("NO_FILIAL")
                        .Add("CNPJ_FILIAL")
                        .Add("END_FILIAL")
                        .Add("IC_JURIDICA")
                        .Add("NO_CLIENTE")
                        .Add("CNPJ_CPF_CLIENTE")
                        .Add("END_CLIENTE")
                        .Add("QUANTIDADE")
                        .Add("DS_LOCAL_ENTREGA")
                    End With

                    For iCont = 0 To oData_02.Rows.Count - 1
                        iAux = 0

                        Me.Text = "Contrato Nº " & Filtro01 & "-" & Filtro02

                        oRow = oData_01.NewRow
                        oData_01.Rows.Add(oRow)

                        With oData_02.Rows(iCont)
                            oRow.Item("CD_CONTRATO") = Trim(.Item("CD_CONTRATO_PAF"))
                            oRow.Item("DS_LOCAL_DATA") = "Local e Data: " & Trim(.Item("NO_CIDADE_FILIAL_EMISSAO")) & ", " & _
                                                                            DatePart(DateInterval.Day, .Item("DT_CONTRATO_PAF")) & " de " & VerMes(.Item("DT_CONTRATO_PAF")) & " de " & DatePart(DateInterval.Year, .Item("DT_CONTRATO_PAF"))
                            oRow.Item("NO_FILIAL") = .Item("NO_FILIAL")
                            oRow.Item("CNPJ_FILIAL") = .Item("CNPJ_FILIAL")
                            oRow.Item("END_FILIAL") = Trim(.Item("END_FILIAL")) & " - " & Trim(.Item("NO_CIDADE_FILIAL_EMISSAO")) & " - " & Trim(.Item("CD_UF_FILIAL_EMISSOR"))
                            oRow.Item("IC_JURIDICA") = .Item("IC_FISICO_JURIDICO")
                            oRow.Item("NO_CLIENTE") = .Item("NO_RAZAO_SOCIAL")
                            oRow.Item("CNPJ_CPF_CLIENTE") = .Item("NU_CGC_CPF")
                            oRow.Item("END_CLIENTE") = Trim(NVL(.Item("DS_ENDERECO_FORNECEDOR"), "")) & " - " & Trim(NVL(.Item("NO_BAIRRO_FORNECEDOR"), "")) & " - " & Trim(NVL(.Item("NO_CIDADE_FORNECEDOR"), "")) & " - " & Trim(NVL(.Item("CD_UF_FORNECEDOR"), ""))
                            oRow.Item("QUANTIDADE") = NVL(.Item("QT_KGS"), 0)
                            oRow.Item("DS_LOCAL_ENTREGA") = NVL(.Item("NO_LOCAL_ENTREGA"), "")
                        End With
                    Next

                    oRelatorio.Load(Application.StartupPath & "\RPT_ContratoPAF_ConfCompra_CacauAOrdem.rpt")
                    oRelatorio.SetDataSource(oData_01)
            End Select

            If bHouveImpressao Then
                Const sectransp = 3
                Const secpreposto = 4
                Const secfax = 5
                Const secdtlimite = 6

                Select Case RelGeral_Tipo
                    Case enRelGeral_Tipo.eContratoPrecoAFixar_Transporte
                        oRelatorio.ReportDefinition.Sections(sectransp).SectionFormat.EnableSuppress = False
                        oRelatorio.ReportDefinition.Sections(secpreposto).SectionFormat.EnableSuppress = True
                        oRelatorio.ReportDefinition.Sections(secfax).SectionFormat.EnableSuppress = True
                        oRelatorio.ReportDefinition.Sections(secdtlimite).SectionFormat.EnableSuppress = True
                    Case enRelGeral_Tipo.eContratoPrecoAFixar_Preposto
                        oRelatorio.ReportDefinition.Sections(sectransp).SectionFormat.EnableSuppress = True
                        oRelatorio.ReportDefinition.Sections(secpreposto).SectionFormat.EnableSuppress = False
                        oRelatorio.ReportDefinition.Sections(secfax).SectionFormat.EnableSuppress = True
                        oRelatorio.ReportDefinition.Sections(secdtlimite).SectionFormat.EnableSuppress = True
                    Case enRelGeral_Tipo.eContratoPrecoAFixar_Fax
                        oRelatorio.ReportDefinition.Sections(sectransp).SectionFormat.EnableSuppress = True
                        oRelatorio.ReportDefinition.Sections(secpreposto).SectionFormat.EnableSuppress = True
                        oRelatorio.ReportDefinition.Sections(secfax).SectionFormat.EnableSuppress = False
                        oRelatorio.ReportDefinition.Sections(secdtlimite).SectionFormat.EnableSuppress = True
                    Case enRelGeral_Tipo.eContratoPrecoAFixar_DtLimite
                        oRelatorio.ReportDefinition.Sections(sectransp).SectionFormat.EnableSuppress = True
                        oRelatorio.ReportDefinition.Sections(secpreposto).SectionFormat.EnableSuppress = True
                        oRelatorio.ReportDefinition.Sections(secfax).SectionFormat.EnableSuppress = True
                        oRelatorio.ReportDefinition.Sections(secdtlimite).SectionFormat.EnableSuppress = False
                End Select

                crvMain.ReportSource = oRelatorio
            End If
        Catch ex As Exception
            Msg_Mensagem(ex.Message)
        End Try
    End Sub

    Private Sub frmRelatorioGeral_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmRelatorioGeral_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        crvMain.Dispose()
        Me.Dispose()
    End Sub

    Private Sub frmRelatorioGeral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmdBotao01.Visible = False
        cmdBotao02.Visible = False
        cmdBotao03.Visible = False
        cmdBotao04.Visible = False
        iBotao = 1
        Me.WindowState = FormWindowState.Maximized

        If Trim(Filtro01) <> "0" Then
            Imprimir()
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Imprimir()
    End Sub

    Private Sub Botao_Exibir(ByVal oTipoBotao As enBotao_Tipo)
        Dim oBotao As Infragistics.Win.Misc.UltraButton = Nothing
        Dim Icone As Integer

        If oTipoBotao = enBotao_Tipo.EnviarEMail_Contrato Then
            Exit Sub
        End If

        Select Case iBotao
            Case 1
                oBotao = cmdBotao01
            Case 2
                oBotao = cmdBotao02
            Case 3
                oBotao = cmdBotao03
            Case 4
                oBotao = cmdBotao04
        End Select

        iBotao = iBotao + 1

        Select Case oTipoBotao
            Case enBotao_Tipo.EnviarEMail_Contrato
                Icone = enBotao_Icone.EnviarEMail
            Case enBotao_Tipo.ContratoBeneficiado_Negociacao, enBotao_Tipo.ContratoBeneficiado_PAF
                Icone = enBotao_Icone.Contrato
        End Select

        oBotao.Tag = oTipoBotao
        oBotao.Appearance.Image = imlIcone.Images(Icone)
        oBotao.Visible = True
        oBotao.Text = ""
    End Sub

    Private Sub Botao_Clique(ByVal oBotao As Infragistics.Win.Misc.UltraButton)
        Select Case oBotao.Tag
            Case enBotao_Tipo.ContratoBeneficiado_Negociacao
                Dim oForm As New frmRelatorioGeral

                oForm.Filtro01 = Filtro01
                oForm.Filtro02 = Filtro02
                oForm.RelGeral_Tipo = enRelGeral_Tipo.eNegociacao_Beneficiario
                Form_Show(Me.Parent, oForm)
            Case enBotao_Tipo.ContratoBeneficiado_PAF
                Dim oForm As New frmRelatorioGeral

                oForm.Filtro01 = Filtro01
                oForm.RelGeral_Tipo = enRelGeral_Tipo.eContratoPAF_Beneficiario

                Form_Show(Me.Parent, oForm)
            Case enBotao_Tipo.EnviarEMail_Contrato
                'Dim olap As Object
                'Dim oitem As Object
                'Dim Arquivo As String
                'Dim V As New Scripting.FileSystemObject

                'On Error GoTo Erro_Email

                'Arquivo = V.GetSpecialFolder(TemporaryFolder).Path

                'If Right(Arquivo, 1) <> "\" Then
                '    Arquivo = Arquivo & "\contrato.pdf"
                'Else
                '    Arquivo = Arquivo & "contrato.pdf"
                'End If

                'If Dir$(Arquivo) > "" Then Kill(Arquivo)

                'Rpt.ExportOptions.DestinationType = crEDTDiskFile
                'Rpt.ExportOptions.FormatType = crEFTPortableDocFormat
                'Rpt.ExportOptions.PDFExportAllPages = True
                'Rpt.ExportOptions.DiskFileName = Arquivo
                'Rpt.Export(False)

                'olap = CreateObject("Outlook.Application")
                'oitem = olap.CreateItem(0)

                'With oitem
                '    .Subject = "Contrato de compra e venda de cacau efetuado com a Cargill Agricola S.A."
                '    .To = mDsEmail
                '    .Body = "Segue em anexo contrato para vossa assinatura. " & _
                '            "Favor assiná-lo em 02 (vias),com rubrica nas primeiras vias, e remetê-lo ao endereço: " & _
                '             vbCrLf & vbCrLf & "Cargill Agrícola SA. - Km 08, Rodovia Ilhéus-Uruçuca, S/N, Cx Postal 102, Ilhéus -BA; CEP: 45.650-000. " & _
                '             vbCrLf & vbCrLf & "A sua via será enviada de volta pelo correio,devidamente assinada. " & _
                '            "Caso haja alterações em seu endereço para correspondência, fineza informar. " & _
                '             vbCrLf & vbCrLf & "A informação contida nesta " & _
                '            "mensagem é confidencial, poderá ser um comunicado privilegiado, poderá conter " & _
                '            "informações confidenciais e destina-se exclusivamente a pessoa a quem está endereçada. " & _
                '            "Se o leitor desta mensagem não é o destinatário pretendido, por favor a elimine " & _
                '            "imediatamente de seus arquivos e nos informe do recebimento indevido. Qualquer acesso, " & _
                '            "uso, disseminação ou cópia não autorizada é estritamente proibida." & vbCrLf
                '    .Attachments.Add(Arquivo)
                '    .Send()
                'End With
        End Select
    End Sub

    Private Sub cmdBotao01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBotao01.Click
        Botao_Clique(sender)
    End Sub

    Private Sub cmdBotao02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBotao02.Click
        Botao_Clique(sender)
    End Sub

    Private Sub cmdBotao03_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBotao03.Click
        Botao_Clique(sender)
    End Sub

    Private Sub cmdBotao04_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBotao04.Click
        Botao_Clique(sender)
    End Sub

    Public Sub ImpressaoAutomatica(ByVal Indice As Integer)
        Dim crExportOptions As CrystalDecisions.Shared.ExportOptions
        Dim crDiskFileDestinationOptions As CrystalDecisions.Shared.DiskFileDestinationOptions

        Imprimir()

        crExportOptions = oRelatorio.ExportOptions

        crDiskFileDestinationOptions = New CrystalDecisions.Shared.DiskFileDestinationOptions()
        crDiskFileDestinationOptions.DiskFileName = "C:\Relatorio\" & Dir(oRelatorio.FilePath) & Indice & ".pdf"

        With crExportOptions
            .DestinationOptions = crDiskFileDestinationOptions
            .ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
            .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
        End With

        oRelatorio.Export()
    End Sub

    Private Sub frmRelatorioGeral_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub
End Class