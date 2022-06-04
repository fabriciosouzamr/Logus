Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaComprasAcumuladas
    Const cnt_GridGeral_AnoMes As Integer = 0
    Const cnt_GridGeral_Filial As Integer = 1
    Const cnt_GridGeral_CodigoUF As Integer = 2
    Const cnt_GridGeral_NomeUF As Integer = 3
    Const cnt_GridGeral_TipoPessoa As Integer = 4
    Const cnt_GridGeral_TipoCacau As Integer = 5
    Const cnt_GridGeral_FisicaJuridica As Integer = 6
    Const cnt_GridGeral_TipoNegociacao As Integer = 7
    Const cnt_GridGeral_QuantidadeBruta As Integer = 8
    Const cnt_GridGeral_QuantidadeCancela As Integer = 9
    Const cnt_GridGeral_QuantidadeLiquida As Integer = 10
    Const cnt_GridGeral_ValorMedioArroba As Integer = 11
    Const cnt_GridGeral_DiferencialMedioBruto As Integer = 12
    Const cnt_GridGeral_DolarMedioBruto As Integer = 13
    Const cnt_GridGeral_Sacos As Integer = 14

    Dim IDColuna() As Integer
    Dim QtColunasCriadas As Integer
    Dim oDS As New UltraWinDataSource.UltraDataSource

    Enum Colunas
        QuantidadeBruta = 0
        QuantidadeCancela = 1
        QuantidadeLiquida = 2
        ValorMedioArroba = 3
        DiferencialMedioBruto = 4
        DolarMedioBruto = 5
        Sacos = 6
    End Enum


    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub frmConsultaComprasAcumuladas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()


        Me.WindowState = FormWindowState.Maximized
        ConfiguraGrid()
    End Sub

    Private Sub ConfiguraGrid()
        oDS = Nothing
        oDS = New UltraWinDataSource.UltraDataSource
        Dim iCont As Integer
        grdGeral.DataSource = Nothing

        objGrid_Inicializar(grdGeral, , oDS, Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect, , , True, , , , True)

        ReDim IDColuna(lstSelecao.Items.Count + 7)

        For iCont = 0 To lstSelecao.Items.Count - 1
            objGrid_Coluna_Add(grdGeral, lstSelecao.Items.Item(iCont), 200)
            IDColuna(iCont) = iCont
        Next
        QtColunasCriadas = iCont

        IDColuna(iCont) = iCont + Colunas.QuantidadeBruta
        IDColuna(iCont + 1) = iCont + Colunas.QuantidadeCancela
        IDColuna(iCont + 2) = iCont + Colunas.QuantidadeLiquida
        IDColuna(iCont + 3) = iCont + Colunas.ValorMedioArroba
        IDColuna(iCont + 4) = iCont + Colunas.DiferencialMedioBruto
        IDColuna(iCont + 5) = iCont + Colunas.DolarMedioBruto
        IDColuna(iCont + 6) = iCont + Colunas.Sacos

        objGrid_Coluna_Add(grdGeral, "Qt Bruta", 120, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Qt Cancelada", 120, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Qt Liquida", 120, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Vl Medio @", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Dif. Medio Bruto", 140, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdGeral, "US$ Medio Bruto", 130, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdGeral, "Sacos", 80, , , , , cnt_Formato_NumeroInteiro)
        objGrid_Coluna_Add(grdGeral, "Bolsa", 80, , , , , cnt_Formato_Fracao)

        objGrid_ExibirTotal(grdGeral, New Integer() {iCont + Colunas.QuantidadeBruta, _
                                                     iCont + Colunas.QuantidadeCancela, _
                                                     iCont + Colunas.QuantidadeLiquida, _
                                                     iCont + Colunas.ValorMedioArroba})


    End Sub

    Private Sub ExecutaConsulta()
        ConfiguraGrid()
        Dim SqlText As String
        Dim SqlFiltro As String = ""
        Dim SqlGroup As String = ""
        Dim iCont As Integer

        If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub

        If lstSelecao.Items.Count = 0 Then
            Msg_Mensagem("Informe pelo menos uma informação como agrupamento.")
            lstOriginal.Focus()
            Exit Sub
        End If

        'FILTRO FILIAL
        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlFiltro = SqlFiltro & " AND F.cd_filial_origem in (" & SelecaoFilial.Lista_ID & ") "
        Else
            SqlFiltro = SqlFiltro & " AND F.cd_filial_origem in (" & ListarIDFiliaisLiberadaUsuario() & ") "
        End If

        For iCont = 0 To lstSelecao.Items.Count - 1
            If lstSelecao.Items.Item(iCont) = "Mês a Mês" Then
                SqlGroup = SqlGroup & "     to_char(dt_negociacao,'YYYY/MM'), "
            End If
            If lstSelecao.Items.Item(iCont) = "Filial" Then
                SqlGroup = SqlGroup & "       no_filial, "
            End If
            If lstSelecao.Items.Item(iCont) = "Estado" Then
                SqlGroup = SqlGroup & "       cd_uf,"
            End If
            If lstSelecao.Items.Item(iCont) = "Tipo Pessoa" Then
                SqlGroup = SqlGroup & "       no_tipo_pessoa , "
            End If
            If lstSelecao.Items.Item(iCont) = "Tipo Cacau" Then
                SqlGroup = SqlGroup & "       no_tipo_cacau ,"
            End If
            If lstSelecao.Items.Item(iCont) = "Fisica ou Juridica" Then
                SqlGroup = SqlGroup & "       ic_fisica_juridica ,"
            End If
            If lstSelecao.Items.Item(iCont) = "Tipo Negociação" Then
                SqlGroup = SqlGroup & "       no_tipo_negociacao ,"
            End If
            If lstSelecao.Items.Item(iCont) = "Safra" Then
                SqlGroup = SqlGroup & "       ds_safra ,"
            End If
            If lstSelecao.Items.Item(iCont) = "Fornecedor" Then
                SqlGroup = SqlGroup & "       no_razao_social ,"
            End If
            If lstSelecao.Items.Item(iCont) = "Municipio" Then
                SqlGroup = SqlGroup & "       no_cidade ,"
            End If
        Next

        SqlText = "SELECT   " & SqlGroup
        SqlText = SqlText & "    TO_NUMBER (TO_CHAR (SUM (qt_bruta), '0000000000.0000')) qt_bruta, TO_NUMBER (TO_CHAR (SUM (qt_cancelada), '0000000000.0000')) qt_cancelada ,TO_NUMBER(TO_CHAR(SUM(qt_kgs), '0000000000.0000')) qt_compra, "
        SqlText = SqlText & "       DECODE(SUM(qt_kgs), 0,  "
        SqlText = SqlText & "              0,  "
        SqlText = SqlText & "              TO_NUMBER(TO_CHAR(SUM(vl_negociacao * qt_kgs) * 15 / SUM (qt_kgs), '000000000000.00'))) vl_unitario, "
        SqlText = SqlText & "       round(sum(vl_diferencial_real/1000 *qt_kgs )/ SUM (qt_kgs/1000),2) vl_diferencial, "
        SqlText = SqlText & "       DECODE(SUM(qt_kgs), 0, "
        SqlText = SqlText & "              0, "
        SqlText = SqlText & "              TO_NUMBER(TO_CHAR(SUM(vl_dolar_atual * qt_kgs) / SUM(qt_kgs), '000000000000.00'))) vl_taxa_us, "
        SqlText = SqlText & "    round(TO_NUMBER(TO_CHAR(SUM(qt_kgs), '0000000000.0000'))/60,0) qt_sacos "
        SqlText = SqlText & "FROM (SELECT n.qt_kgs qt_bruta, 0 qt_cancelada, n.qt_kgs, "
        SqlText = SqlText & "             DECODE(tn.ic_tipo_preco_fixo, 'S', "
        SqlText = SqlText & "                    ((n.vl_negociacao / tu.qt_fator) + (n.vl_preco_frete / 60)), "
        SqlText = SqlText & "                    DECODE(tn.ic_dolar, 'S', "
        SqlText = SqlText & "                           ((n.vl_negociacao / tu.qt_fator) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                     n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                     n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                           DECODE(tn.ic_bolsa, 'S', "
        SqlText = SqlText & "                                  DECODE(tn.ic_bolsa_operacao, '+', "
        SqlText = SqlText & "                                         (((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                   n.vl_bolsa, "
        SqlText = SqlText & "                                                   n.vl_bolsa_alternativo) + n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                               n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                               n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                         DECODE(tn.ic_bolsa_operacao, '-', "
        SqlText = SqlText & "                                                (((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                          n.vl_bolsa, "
        SqlText = SqlText & "                                                          n.vl_bolsa_alternativo) - n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                      n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                      n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                         DECODE(tn.ic_bolsa_operacao, '*', "
        SqlText = SqlText & "                                                (((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                          n.vl_bolsa, "
        SqlText = SqlText & "                                                          n.vl_bolsa_alternativo) * n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                      n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                      n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                                DECODE(tn.ic_bolsa_operacao, '/', "
        SqlText = SqlText & "                                                       (((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                 n.vl_bolsa, "
        SqlText = SqlText & "                                                                 n.vl_bolsa_alternativo) / n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                             n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                             n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                                       0))))))) vl_negociacao, "
        SqlText = SqlText & "             (((DECODE(tn.ic_tipo_preco_fixo, 'S', "
        SqlText = SqlText & "                       n.vl_negociacao / tu.qt_fator, "
        SqlText = SqlText & "                       DECODE(tn.ic_dolar, 'S', "
        SqlText = SqlText & "                              (n.vl_negociacao / tu.qt_fator) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                       n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                       n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                              DECODE(tn.ic_bolsa, 'S', "
        SqlText = SqlText & "                                     DECODE(tn.ic_bolsa_operacao, '+', "
        SqlText = SqlText & "                                            ((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                     n.vl_bolsa, "
        SqlText = SqlText & "                                                     n.vl_bolsa_alternativo) + n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                 n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                 n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                            DECODE(tn.ic_bolsa_operacao, '-', "
        SqlText = SqlText & "                                                   ((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                            n.vl_bolsa, "
        SqlText = SqlText & "                                                            n.vl_bolsa_alternativo) - n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                        n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                        n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                                   DECODE(tn.ic_bolsa_operacao, '*', "
        SqlText = SqlText & "                                                          ((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                   n.vl_bolsa, "
        SqlText = SqlText & "                                                                   n.vl_bolsa_alternativo) * n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                               n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                               n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                                   DECODE(tn.ic_bolsa_operacao, '/', "
        SqlText = SqlText & "                                                          ((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                   n.vl_bolsa, "
        SqlText = SqlText & "                                                                   n.vl_bolsa_alternativo) / n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                               n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                               n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                                          0)))))))) / (1 - ((fun.vl_taxa + n.pc_aliq_icms) / 100))) * (fun.vl_taxa / 100)) vl_inss, "
        SqlText = SqlText & "             DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                    n.vl_taxa_dolar, "
        SqlText = SqlText & "                    n.vl_taxa_dolar_alternativo) vl_dolar_atual, "
        SqlText = SqlText & "             DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                    n.vl_bolsa, "
        SqlText = SqlText & "                    n.vl_bolsa_alternativo) vl_bolsa_atual, "
        SqlText = SqlText & "             n.dt_negociacao, "
        SqlText = SqlText & "             SUBSTR(TO_CHAR (SYSDATE, 'YYYY'), 1, 3) || SUBSTR (NVL (n.cd_papel_competencia, n.cd_papel), 4, 1) || SUBSTR (NVL (n.cd_papel_competencia, n.cd_papel), 3, 1) cd_papel, "
        SqlText = SqlText & "             uf.cd_uf, saf.ds_safra, uf.no_uf, tc.cd_tipo_cacau, tc.no_tipo_cacau, f.ic_fisica_juridica, "
        SqlText = SqlText & "             tp.cd_tipo_pessoa, tp.no_tipo_pessoa, fil.cd_filial, fil.no_filial, tn.no_tipo_negociacao, f.no_razao_social, munic.no_cidade, n.vl_diferencial_real "
        SqlText = SqlText & "      FROM sof.negociacao n, "
        SqlText = SqlText & "           sof.contrato_paf cp, "
        SqlText = SqlText & "           sof.fornecedor f, "
        SqlText = SqlText & "           sof.tipo_unidade tu, "
        SqlText = SqlText & "           sof.funrural fun, "
        SqlText = SqlText & "           sof.tipo_negociacao tn, "
        SqlText = SqlText & "           sof.municipio munic, sof.safra saf, "
        SqlText = SqlText & "           sof.uf uf, sof.tipo_cacau tc, sof.tipo_pessoa tp, sof.filial fil "
        SqlText = SqlText & "      WHERE cp.cd_contrato_paf = n.cd_contrato_paf AND "
        SqlText = SqlText & "            cp.cd_fornecedor = f.cd_fornecedor AND "
        SqlText = SqlText & "            f.cd_funrural = fun.cd_funrural AND "
        SqlText = SqlText & "            n.cd_tipo_unidade = tu.cd_tipo_unidade AND "
        SqlText = SqlText & "            n.cd_tipo_negociacao = tn.cd_tipo_negociacao AND "
        SqlText = SqlText & "            n.cd_tipo_cacau = tc.cd_tipo_cacau and "
        SqlText = SqlText & "            n.cd_tipo_cacau = tc.cd_tipo_cacau and "
        SqlText = SqlText & "            n.cd_safra = saf.cd_safra (+) and "
        SqlText = SqlText & "            F.cd_filial_origem = Fil.cd_filial And "
        SqlText = SqlText & "            decode(F.cd_tipo_pessoa, 3, 5, F.cd_tipo_pessoa) = tp.cd_tipo_pessoa And "
        SqlText = SqlText & "            nvl(cp.cd_municipio,f.cd_municipio) = munic.cd_municipio AND "
        SqlText = SqlText & "            munic.cd_uf = uf.cd_uf AND "
        SqlText = SqlText & "            n.dt_negociacao BETWEEN '" & Date_to_Oracle(txtDataInicial.Text) & "' AND '" & Date_to_Oracle(txtDataFinal.Text) & "' AND "
        SqlText = SqlText & "            tn.ic_bolsa = 'N' AND "
        SqlText = SqlText & "            n.ic_status <> 'E' "

        SqlText = SqlText & SqlFiltro

        SqlText = SqlText & "      UNION ALL "
        SqlText = SqlText & "      SELECT 0 qt_bruta,(0 - nc.qt_cancelado) qt_cancelada , (0 - nc.qt_cancelado) qt_kgs, "
        SqlText = SqlText & "             DECODE(nc.ic_estorno_cancelamento, 'C', "
        SqlText = SqlText & "                    (((NVL(m.vl_bolsa, 0) + NVL (m.vl_diferencial, 0)) * NVL (m.vl_dolar_atual, 0)) / 1000), "
        SqlText = SqlText & "                    DECODE(tn.ic_tipo_preco_fixo, 'S', "
        SqlText = SqlText & "                           ((n.vl_negociacao / tu.qt_fator) + (n.vl_preco_frete / 60)), "
        SqlText = SqlText & "                           DECODE(tn.ic_dolar, 'S', "
        SqlText = SqlText & "                                  ((n.vl_negociacao / tu.qt_fator) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                            n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                            n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                  DECODE(tn.ic_bolsa, 'S', "
        SqlText = SqlText & "                                         DECODE(tn.ic_bolsa_operacao, '+', "
        SqlText = SqlText & "                                                (((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                          n.vl_bolsa, "
        SqlText = SqlText & "                                                          n.vl_bolsa_alternativo) + n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                      n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                      n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                                DECODE(tn.ic_bolsa_operacao, '-', "
        SqlText = SqlText & "                                                       (((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                 n.vl_bolsa, "
        SqlText = SqlText & "                                                                 n.vl_bolsa_alternativo) - n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                             n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                             n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                                       DECODE(tn.ic_bolsa_operacao, '*', "
        SqlText = SqlText & "                                                              (((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                        n.vl_bolsa, "
        SqlText = SqlText & "                                                                        n.vl_bolsa_alternativo) * n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                                    n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                                    n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                                              DECODE(tn.ic_bolsa_operacao, '/', "
        SqlText = SqlText & "                                                                     (((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                               n.vl_bolsa, "
        SqlText = SqlText & "                                                                               n.vl_bolsa_alternativo) / n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                                           n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                                           n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                                                     0)))))))) vl_negociacao, "
        SqlText = SqlText & "             (((DECODE(nc.ic_estorno_cancelamento, 'C', "
        SqlText = SqlText & "                    (((((NVL(m.vl_bolsa, 0) + NVL(m.vl_diferencial, 0)) * NVL (m.vl_dolar_atual, 0)) / 1000) / (1 - ((fun.vl_taxa + n.pc_aliq_icms) / 100))) * (fun.vl_taxa / 100)), "
        SqlText = SqlText & "                    DECODE(tn.ic_tipo_preco_fixo, 'S', "
        SqlText = SqlText & "                           n.vl_negociacao / tu.qt_fator, "
        SqlText = SqlText & "                           DECODE(tn.ic_dolar, 'S', "
        SqlText = SqlText & "                                  (n.vl_negociacao / tu.qt_fator) * DECODE (n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                            n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                            n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                  DECODE(tn.ic_bolsa, 'S', "
        SqlText = SqlText & "                                         DECODE(tn.ic_bolsa_operacao, '+', "
        SqlText = SqlText & "                                                ((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                         n.vl_bolsa, "
        SqlText = SqlText & "                                                         n.vl_bolsa_alternativo) + n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                     n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                     n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                                DECODE(tn.ic_bolsa_operacao, '-', "
        SqlText = SqlText & "                                                       ((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                n.vl_bolsa, "
        SqlText = SqlText & "                                                                n.vl_bolsa_alternativo) - n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                            n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                            n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                                       DECODE(tn.ic_bolsa_operacao, '*', "
        SqlText = SqlText & "                                                              ((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                       n.vl_bolsa, "
        SqlText = SqlText & "                                                                       n.vl_bolsa_alternativo) * n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                                   n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                                   n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                                              DECODE(tn.ic_bolsa_operacao, '/', "
        SqlText = SqlText & "                                                                     ((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                              n.vl_bolsa, "
        SqlText = SqlText & "                                                                              n.vl_bolsa_alternativo) / n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                                          n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                                          n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                                              0)))))))) / (1 - ((fun.vl_taxa + n.pc_aliq_icms) / 100))) * (fun.vl_taxa / 100))) vl_inss, "
        SqlText = SqlText & "             DECODE(nc.ic_estorno_cancelamento, 'C', "
        SqlText = SqlText & "                    NVL(m.vl_dolar_atual, 0), "
        SqlText = SqlText & "                    DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                           n.vl_taxa_dolar, "
        SqlText = SqlText & "                           n.vl_taxa_dolar_alternativo)) vl_dolar_atual, "
        SqlText = SqlText & "             DECODE(nc.ic_estorno_cancelamento, 'C', "
        SqlText = SqlText & "                    NVL(m.vl_bolsa, 0), "
        SqlText = SqlText & "                    DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                           n.vl_bolsa, "
        SqlText = SqlText & "                           n.vl_bolsa_alternativo)) vl_bolsa_atual, "
        SqlText = SqlText & "             nc.dt_cancelamento dt_negociacao, "
        SqlText = SqlText & "             DECODE(nc.ic_estorno_cancelamento, 'C', "
        SqlText = SqlText & "                    SUBSTR(TO_CHAR(SYSDATE, 'YYYY'), 1, 3) || SUBSTR(NVL(nc.cd_papel, b.cd_papel), 4, 1) || SUBSTR(NVL(nc.cd_papel, b.cd_papel), 3, 1), "
        SqlText = SqlText & "                    SUBSTR(TO_CHAR(SYSDATE, 'YYYY'), 1, 3) || SUBSTR(NVL(n.cd_papel_competencia, n.cd_papel), 4, 1) || SUBSTR(NVL(n.cd_papel_competencia, n.cd_papel), 3, 1)) cd_papel, "
        SqlText = SqlText & "             uf.cd_uf,saf.ds_safra , uf.no_uf, tc.cd_tipo_cacau, tc.no_tipo_cacau, f.ic_fisica_juridica, "
        SqlText = SqlText & "             tp.cd_tipo_pessoa, tp.no_tipo_pessoa, fil.cd_filial, fil.no_filial, tn.no_tipo_negociacao, f.no_razao_social, munic.no_cidade, n.vl_diferencial_real "
        SqlText = SqlText & "      FROM sof.negociacao n, "
        SqlText = SqlText & "           sof.negociacao_cancelado nc, sof.safra saf,"
        SqlText = SqlText & "           sof.contrato_paf cp, "
        SqlText = SqlText & "           sof.fornecedor f, "
        SqlText = SqlText & "           sof.funrural fun, "
        SqlText = SqlText & "           (SELECT dt_negociacao dt_contrato, "
        SqlText = SqlText & "                   DECODE(SUM(qt_kgs), 0, "
        SqlText = SqlText & "                          0, "
        SqlText = SqlText & "                          SUM(vl_bolsa_atual * qt_kgs) / SUM(qt_kgs)) vl_bolsa, "
        SqlText = SqlText & "                   DECODE(SUM(qt_kgs), 0, "
        SqlText = SqlText & "                          0, "
        SqlText = SqlText & "                          SUM(vl_dolar_atual * qt_kgs) / SUM(qt_kgs)) vl_dolar_atual, "
        SqlText = SqlText & "                   DECODE(SUM(qt_kgs), 0, "
        SqlText = SqlText & "                          0, "
        SqlText = SqlText & "                          DECODE(SUM(vl_dolar_atual * qt_kgs) - SUM(vl_bolsa_atual * qt_kgs), 0, "
        SqlText = SqlText & "                                 0, "
        SqlText = SqlText & "                                 (SUM(vl_negociacao * qt_kgs) + SUM(vl_inss * qt_kgs)) * 1000 / SUM(vl_dolar_atual * qt_kgs) - SUM(vl_bolsa_atual * qt_kgs) / SUM(qt_kgs))) vl_diferencial "
        SqlText = SqlText & "            FROM (SELECT n.qt_kgs, "
        SqlText = SqlText & "                         DECODE(tn.ic_tipo_preco_fixo, 'S', "
        SqlText = SqlText & "                                ((n.vl_negociacao / tu.qt_fator) + (n.vl_preco_frete / 60)), "
        SqlText = SqlText & "                                DECODE(tn.ic_dolar, 'S', "
        SqlText = SqlText & "                                       ((n.vl_negociacao / tu.qt_fator) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                 n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                 n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                       DECODE(tn.ic_bolsa, 'S', "
        SqlText = SqlText & "                                              DECODE(tn.ic_bolsa_operacao, '+', "
        SqlText = SqlText & "                                                     (((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                               n.vl_bolsa, "
        SqlText = SqlText & "                                                               n.vl_bolsa_alternativo) + n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                           n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                           n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                                     DECODE(tn.ic_bolsa_operacao, '-', "
        SqlText = SqlText & "                                                            (((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                      n.vl_bolsa, "
        SqlText = SqlText & "                                                                      n.vl_bolsa_alternativo) - n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                                  n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                                  n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                                            DECODE(tn.ic_bolsa_operacao, '*', "
        SqlText = SqlText & "                                                                   (((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                             n.vl_bolsa, "
        SqlText = SqlText & "                                                                             n.vl_bolsa_alternativo) * n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                                         n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                                         n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                                                   DECODE(tn.ic_bolsa_operacao, '/', "
        SqlText = SqlText & "                                                                          (((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                                    n.vl_bolsa, "
        SqlText = SqlText & "                                                                                    n.vl_bolsa_alternativo) / n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                                                n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                                                n.vl_taxa_dolar_alternativo)) + (n.vl_preco_frete / 60), "
        SqlText = SqlText & "                                                                          0))))))) vl_negociacao, "
        SqlText = SqlText & "                         (((DECODE(tn.ic_tipo_preco_fixo, 'S', "
        SqlText = SqlText & "                                   n.vl_negociacao / tu.qt_fator, "
        SqlText = SqlText & "                                   DECODE(tn.ic_dolar, 'S', "
        SqlText = SqlText & "                                          (n.vl_negociacao / tu.qt_fator) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                   n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                   n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                          DECODE(tn.ic_bolsa, 'S', "
        SqlText = SqlText & "                                                 DECODE(tn.ic_bolsa_operacao, '+', "
        SqlText = SqlText & "                                                        ((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                 n.vl_bolsa, "
        SqlText = SqlText & "                                                                 n.vl_bolsa_alternativo) + n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                             n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                             n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                                        DECODE(tn.ic_bolsa_operacao, '-', "
        SqlText = SqlText & "                                                               ((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                        n.vl_bolsa, "
        SqlText = SqlText & "                                                                        n.vl_bolsa_alternativo) - n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                                    n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                                    n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                                        DECODE(tn.ic_bolsa_operacao, '*', "
        SqlText = SqlText & "                                                               ((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                        n.vl_bolsa, "
        SqlText = SqlText & "                                                                        n.vl_bolsa_alternativo) * n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                                    n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                                    n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                                        DECODE(tn.ic_bolsa_operacao, '/', "
        SqlText = SqlText & "                                                               ((DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                                                        n.vl_bolsa, "
        SqlText = SqlText & "                                                                        n.vl_bolsa_alternativo) / n.vl_negociacao) / 1000) * DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                                                                                                                    n.vl_taxa_dolar, "
        SqlText = SqlText & "                                                                                                                                    n.vl_taxa_dolar_alternativo), "
        SqlText = SqlText & "                                                        0)))))))) / (1 - ((fun.vl_taxa + n.pc_aliq_icms) / 100))) * (fun.vl_taxa / 100)) vl_inss, "
        SqlText = SqlText & "                         DECODE(n.vl_taxa_dolar_alternativo, 0, "
        SqlText = SqlText & "                                n.vl_taxa_dolar, "
        SqlText = SqlText & "                                n.vl_taxa_dolar_alternativo) vl_dolar_atual, "
        SqlText = SqlText & "                         DECODE(n.vl_bolsa_alternativo, 0, "
        SqlText = SqlText & "                                n.vl_bolsa, "
        SqlText = SqlText & "                                n.vl_bolsa_alternativo) vl_bolsa_atual, "
        SqlText = SqlText & "                         n.dt_negociacao "
        SqlText = SqlText & "                  FROM sof.negociacao n, "
        SqlText = SqlText & "                       sof.contrato_paf cp, "
        SqlText = SqlText & "                       sof.fornecedor f, "
        SqlText = SqlText & "                       sof.tipo_unidade tu, "
        SqlText = SqlText & "                       sof.funrural fun, "
        SqlText = SqlText & "                       sof.tipo_negociacao tn "
        SqlText = SqlText & "                  WHERE cp.cd_contrato_paf = n.cd_contrato_paf AND "
        SqlText = SqlText & "                        cp.cd_fornecedor = f.cd_fornecedor AND "
        SqlText = SqlText & "                        f.cd_funrural = fun.cd_funrural AND "
        SqlText = SqlText & "                        n.cd_tipo_unidade = tu.cd_tipo_unidade AND "
        SqlText = SqlText & "                        n.cd_tipo_negociacao = tn.cd_tipo_negociacao AND "
        SqlText = SqlText & "                        n.dt_negociacao BETWEEN '" & Date_to_Oracle(txtDataInicial.Text) & "' AND '" & Date_to_Oracle(txtDataFinal.Text) & "' AND "
        SqlText = SqlText & "                        n.ic_status <> 'E' "

        SqlText = SqlText & SqlFiltro

        SqlText = SqlText & "    ) "

        SqlText = SqlText & "            GROUP BY dt_negociacao) m, "
        SqlText = SqlText & "           (SELECT bp.cd_papel "
        SqlText = SqlText & "            FROM sof.bolsa_periodo bp "
        SqlText = SqlText & "            WHERE bp.ic_moeda = 'N' AND "
        SqlText = SqlText & "                  bp.nu_sequencia IN (SELECT MIN (nu_sequencia) "
        SqlText = SqlText & "                                      FROM sof.bolsa_periodo "
        SqlText = SqlText & "                                      WHERE ic_moeda = 'N')) b, "
        SqlText = SqlText & "           sof.tipo_negociacao tn, "
        SqlText = SqlText & "           sof.tipo_unidade tu, "
        SqlText = SqlText & "           sof.municipio munic, "
        SqlText = SqlText & "           sof.uf uf, sof.tipo_cacau tc, sof.tipo_pessoa tp, sof.filial fil "
        SqlText = SqlText & "      WHERE cp.cd_contrato_paf = n.cd_contrato_paf AND "
        SqlText = SqlText & "            cp.cd_fornecedor = f.cd_fornecedor AND "
        SqlText = SqlText & "            f.cd_funrural = fun.cd_funrural AND "
        SqlText = SqlText & "            n.cd_contrato_paf = nc.cd_contrato_paf AND "
        SqlText = SqlText & "            n.sq_negociacao = nc.sq_negociacao AND "
        SqlText = SqlText & "            n.cd_tipo_negociacao = tn.cd_tipo_negociacao AND "
        SqlText = SqlText & "            n.cd_tipo_unidade = tu.cd_tipo_unidade AND "
        SqlText = SqlText & "            n.cd_tipo_cacau = tc.cd_tipo_cacau and "
        SqlText = SqlText & "            n.cd_safra = saf.cd_safra (+) and "
        SqlText = SqlText & "            F.cd_filial_origem = Fil.cd_filial And "
        SqlText = SqlText & "            decode(F.cd_tipo_pessoa, 3, 5, F.cd_tipo_pessoa) = tp.cd_tipo_pessoa And "
        SqlText = SqlText & "            nvl(cp.cd_municipio,f.cd_municipio) = munic.cd_municipio AND "
        SqlText = SqlText & "            munic.cd_uf = uf.cd_uf AND "
        SqlText = SqlText & "            nc.dt_cancelamento = m.dt_contrato(+) AND "
        SqlText = SqlText & "            tn.ic_bolsa = 'N' AND "
        SqlText = SqlText & "            nc.dt_cancelamento BETWEEN '" & Date_to_Oracle(txtDataInicial.Text) & "' AND '" & Date_to_Oracle(txtDataFinal.Text) & "' "

        SqlText = SqlText & SqlFiltro

        SqlText = SqlText & "      UNION ALL "
        SqlText = SqlText & "      SELECT cf.qt_kgs qt_bruta,0  qt_cancelada, cf.qt_kgs qt_kgs, "
        ' SqlText = SqlText & "             (cf.vl_unitario / tu.qt_fator) + (n.vl_preco_frete / 60) vl_contrato_fixo, "

        SqlText = SqlText & " round(((cf.vl_bolsa_fechado + n.VL_NEGOCIACAO)* "
        SqlText = SqlText & " cf.vl_taxa_dolar_fechado/1000) + (n.vl_preco_frete / 60),2) as vl_contrato_fixo, "


        SqlText = SqlText & "             (cf.vl_inss / cf.qt_kgs) vl_inss, "
        SqlText = SqlText & "             cf.vl_taxa_dolar_fechado vl_dolar_atual, "
        SqlText = SqlText & "             cf.vl_bolsa_fechado vl_bolsa_atual, cf.dt_contrato_fixo, "
        SqlText = SqlText & "             SUBSTR(TO_CHAR(SYSDATE, 'YYYY'), 1, 3) || SUBSTR(n.cd_papel_competencia, 4, 1) || SUBSTR(n.cd_papel_competencia, 3, 1) cd_papel, "
        SqlText = SqlText & "             uf.cd_uf, saf.ds_safra ,uf.no_uf, tc.cd_tipo_cacau, tc.no_tipo_cacau, "
        SqlText = SqlText & "             f.ic_fisica_juridica, tp.cd_tipo_pessoa, tp.no_tipo_pessoa, fil.cd_filial, fil.no_filial, tn.no_tipo_negociacao, f.no_razao_social, munic.no_cidade, cf.vl_diferencial_real "
        SqlText = SqlText & "      FROM sof.contrato_fixo cf, "
        SqlText = SqlText & "           sof.negociacao n, "
        SqlText = SqlText & "           sof.tipo_negociacao tn, "
        SqlText = SqlText & "           sof.tipo_unidade tu, "
        SqlText = SqlText & "           sof.contrato_paf cp, "
        SqlText = SqlText & "           sof.fornecedor f, "
        SqlText = SqlText & "           sof.municipio munic, sof.safra saf,"
        SqlText = SqlText & "           sof.uf uf, sof.tipo_cacau tc, sof.tipo_pessoa tp, sof.filial fil "
        SqlText = SqlText & "      WHERE n.cd_contrato_paf = cf.cd_contrato_paf AND "
        SqlText = SqlText & "            n.sq_negociacao = cf.sq_negociacao AND "
        SqlText = SqlText & "            tn.cd_tipo_negociacao = n.cd_tipo_negociacao AND "
        SqlText = SqlText & "            cf.cd_tipo_unidade = tu.cd_tipo_unidade AND "
        SqlText = SqlText & "            n.cd_contrato_paf = cp.cd_contrato_paf AND "
        SqlText = SqlText & "            cp.cd_fornecedor = f.cd_fornecedor AND "
        SqlText = SqlText & "            n.cd_tipo_cacau = tc.cd_tipo_cacau and "
        SqlText = SqlText & "            cf.cd_safra = saf.cd_safra (+) and "
        SqlText = SqlText & "            F.cd_filial_origem = Fil.cd_filial And "
        SqlText = SqlText & "            decode(F.cd_tipo_pessoa, 3, 5, F.cd_tipo_pessoa) = tp.cd_tipo_pessoa And "
        SqlText = SqlText & "            nvl(cp.cd_municipio,f.cd_municipio) = munic.cd_municipio AND "
        SqlText = SqlText & "            munic.cd_uf = uf.cd_uf AND "
        SqlText = SqlText & "            tn.ic_bolsa = 'S' AND "
        SqlText = SqlText & "            cf.ic_status <> 'E' AND "
        SqlText = SqlText & "            cf.dt_contrato_fixo BETWEEN '" & Date_to_Oracle(txtDataInicial.Text) & "' AND '" & Date_to_Oracle(txtDataFinal.Text) & "' "

        SqlText = SqlText & SqlFiltro

        SqlText = SqlText & "      UNION ALL "
        SqlText = SqlText & "      SELECT 0 qt_bruta,0 - cfc.qt_cancelado qt_cancelada,0 - cfc.qt_cancelado qt_kgs, "
        'SqlText = SqlText & "             (cf.vl_unitario / tu.qt_fator) + (n.vl_preco_frete / 60) vl_contrato_fixo, "

        SqlText = SqlText & " round(((cf.vl_bolsa_fechado + n.VL_NEGOCIACAO)* "
        SqlText = SqlText & "cf.vl_taxa_dolar_fechado/1000) + (n.vl_preco_frete / 60),2) as vl_contrato_fixo, "


        SqlText = SqlText & "             (cf.vl_inss / cf.qt_kgs) vl_inss, "
        SqlText = SqlText & "             cf.vl_taxa_dolar_fechado vl_dolar_atual, "
        SqlText = SqlText & "             cf.vl_bolsa_fechado vl_bolsa_atual, cfc.dt_cancelamento, "
        SqlText = SqlText & "             SUBSTR(TO_CHAR(SYSDATE, 'YYYY'), 1, 3) || SUBSTR(n.cd_papel_competencia, 4, 1) || SUBSTR(n.cd_papel_competencia, 3, 1) cd_papel, "
        SqlText = SqlText & "             uf.cd_uf, saf.ds_safra, uf.no_uf, tc.cd_tipo_cacau, tc.no_tipo_cacau, f.ic_fisica_juridica, "
        SqlText = SqlText & "             tp.cd_tipo_pessoa, tp.no_tipo_pessoa, fil.cd_filial, fil.no_filial, tn.no_tipo_negociacao, f.no_razao_social, munic.no_cidade, cf.vl_diferencial_real "
        SqlText = SqlText & "      FROM sof.contrato_fixo cf, "
        SqlText = SqlText & "           sof.negociacao n, "
        SqlText = SqlText & "           sof.tipo_negociacao tn, "
        SqlText = SqlText & "           sof.tipo_unidade tu, "
        SqlText = SqlText & "           sof.contrato_fixo_cancelado cfc, sof.safra saf,"
        SqlText = SqlText & "           sof.contrato_paf cp, "
        SqlText = SqlText & "           sof.fornecedor f, "
        SqlText = SqlText & "           sof.municipio munic, "
        SqlText = SqlText & "           sof.uf uf, sof.tipo_cacau tc, sof.tipo_pessoa tp, sof.filial fil "
        SqlText = SqlText & "      WHERE n.cd_contrato_paf = cf.cd_contrato_paf AND "
        SqlText = SqlText & "            n.sq_negociacao = cf.sq_negociacao AND "
        SqlText = SqlText & "            tn.cd_tipo_negociacao = n.cd_tipo_negociacao AND "
        SqlText = SqlText & "            cf.cd_tipo_unidade = tu.cd_tipo_unidade AND "
        SqlText = SqlText & "            cf.cd_contrato_paf = cfc.cd_contrato_paf AND "
        SqlText = SqlText & "            cf.sq_negociacao = cfc.sq_negociacao AND "
        SqlText = SqlText & "            cf.sq_contrato_fixo = cfc.sq_contrato_fixo AND "
        SqlText = SqlText & "            n.cd_contrato_paf = cp.cd_contrato_paf AND "
        SqlText = SqlText & "            cp.cd_fornecedor = f.cd_fornecedor AND "
        SqlText = SqlText & "            n.cd_tipo_cacau = tc.cd_tipo_cacau and "
        SqlText = SqlText & "            cf.cd_safra = saf.cd_safra (+) and "
        SqlText = SqlText & "            F.cd_filial_origem = Fil.cd_filial And "
        SqlText = SqlText & "            decode(F.cd_tipo_pessoa, 3, 5, F.cd_tipo_pessoa) = tp.cd_tipo_pessoa And "
        SqlText = SqlText & "            nvl(cp.cd_municipio,f.cd_municipio) = munic.cd_municipio AND "
        SqlText = SqlText & "            munic.cd_uf = uf.cd_uf AND "
        SqlText = SqlText & "            tn.ic_bolsa = 'S' AND "
        SqlText = SqlText & "            cfc.dt_cancelamento BETWEEN '" & Date_to_Oracle(txtDataInicial.Text) & "' AND '" & Date_to_Oracle(txtDataFinal.Text) & "'"

        SqlText = SqlText & SqlFiltro

        SqlText = SqlText & " ) "


        SqlGroup = Trim(SqlGroup)
        SqlText = SqlText & "   GROUP BY " & Mid(SqlGroup, 1, SqlGroup.Length - 1)

        objGrid_Carregar(grdGeral, SqlText, IDColuna)
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub frmConsultaComprasAcumuladas_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub

    Private Sub cmdSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionar.Click
        If lstOriginal.SelectedItem = Nothing Then
            Msg_Mensagem("Selecione um item.")
            Exit Sub
        End If

        lstSelecao.Items.Add(lstOriginal.SelectedItem)
        lstOriginal.Items.RemoveAt(lstOriginal.SelectedIndex)
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        If lstSelecao.SelectedItem = Nothing Then
            Msg_Mensagem("Selecione um item.")
            Exit Sub
        End If

        lstOriginal.Items.Add(lstSelecao.SelectedItem)
        lstSelecao.Items.RemoveAt(lstSelecao.SelectedIndex)
    End Sub
    Private Sub lstOriginal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstOriginal.DoubleClick
        cmdSelecionar_Click(Nothing, Nothing)
    End Sub

    Private Sub lstSelecao_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSelecao.DoubleClick
        cmdCancelar_Click(Nothing, Nothing)
    End Sub
End Class