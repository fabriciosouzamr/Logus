Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Adiantamento_Em_Aberto
    Private Enum Analitico
        Vencidos = 1
        Avencer = 2
    End Enum

    Private Enum Sintetico
        Vencidos = 1
        Avencer = 2
        Adto_30dd_com_cacau_aordem = 3
        Adto_30dd = 4
        Vencidos_Por_titular = 5
        Avencer_Por_titular = 6
        Todos_Por_titular = 7
    End Enum

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_Adiantamento_Em_Aberto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        optTipo_ValueChanged(Nothing, Nothing)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub frmREL_Adiantamento_Em_Aberto_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        Dim SqlText As String

        If optTipo.Value = "S" Then
            SqlText = "SELECT 1, 'Vencidos' "
            SqlText = SqlText & "  FROM DUAL "
            SqlText = SqlText & "UNION "
            SqlText = SqlText & "SELECT 2, 'A vencer' "
            SqlText = SqlText & "  FROM DUAL "
            SqlText = SqlText & "UNION "
            SqlText = SqlText & "SELECT 3, 'Adto +30dd com cacau a ordem' "
            SqlText = SqlText & "  FROM DUAL "
            SqlText = SqlText & "UNION "
            SqlText = SqlText & "SELECT 4, 'Adto +30dd' "
            SqlText = SqlText & "  FROM DUAL "
            SqlText = SqlText & "UNION "
            SqlText = SqlText & "SELECT 5, 'Vencidos - Por titular' "
            SqlText = SqlText & "  FROM DUAL "
            SqlText = SqlText & "UNION "
            SqlText = SqlText & "SELECT 6, 'A vencer - Por titular' "
            SqlText = SqlText & "  FROM DUAL "
            SqlText = SqlText & "UNION "
            SqlText = SqlText & "SELECT 7, 'Todos - Por titular' "
            SqlText = SqlText & "  FROM DUAL "
        Else
            SqlText = "SELECT 1, 'Vencidos' "
            SqlText = SqlText & "  FROM DUAL "
            SqlText = SqlText & "UNION "
            SqlText = SqlText & "SELECT 2, 'A vencer' "
            SqlText = SqlText & "  FROM DUAL "
        End If

        DBCarregarComboBox(cboOpcao, SqlText, True)
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""
        Dim VlPreco As Double
        Dim oRelatorio As New CrystalReportDocument

        AVI_Carregar(Me)

        SqlText = "SELECT PC.VL_PRECO " & _
                  "FROM SOF.PRECO_CACAU PC " & _
                  "WHERE PC.DT_COTACAO in (SELECT MAX(LCM.DT_COTACAO) " & _
                  "FROM SOF.LIMITE_CREDITO_MOEDA LCM " & _
                  "WHERE LCM.DT_COTACAO <= '" & Date_to_Oracle(DataSistema) & "')"
      
        VlPreco = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT /*+ ORDERED INDEX (f SYS_C004218) USE_NL (p) */ F.CD_FILIAL_ORIGEM, " & _
                  "FIL.NO_FILIAL, F.NO_RAZAO_SOCIAL, P.DT_PAGAMENTO, P.DS_DESCRICAO, " & _
                  "PCP.VL_A_FIXAR as vl_pagamento, " & _
                  "ROUND(DECODE(P.VL_TAXA_DOLAR,NULL,0,PCP.VL_A_FIXAR/P.VL_TAXA_DOLAR),2) VL_DOLAR, " & _
                  "NVL(P.VL_TAXA_DOLAR,0) VL_TAXA_DOLAR, FP.NO_FORMA_PAGAMENTO, " & _
                  "P.CD_TIPO_PAGAMENTO, TP.NO_TIPO_PAGAMENTO, P.IC_ICMS as ic_pagamento_icms, PCP.CD_CONTRATO_PAF, " & _
                  "-1 SQ_NEGOCIACAO, p.SQ_PAGAMENTO, CP.dt_vencimento, to_date('" & Date_to_Oracle(DataSistema) & "') as dt_hoje, " & _
                  "REP.CD_FORNECEDOR as cd_repassador, REP.NO_RAZAO_SOCIAL as no_repassador, TPE.NO_TIPO_PESSOA, F.CD_FORNECEDOR , " & _
                  "PARAM.ic_juros_automatico IC_CALCULA_JUROS_AUTOMATICO, CP.ic_calcula_juros IC_CALCULA_JUROS_CONTRATO, " & _
                  "TP.ic_calcula_juros IC_CALCULA_JUROS_PAGAMENTO, CP.pc_taxa_juros, CP.qt_dia_carencia_juros as qt_dia_carencia, " & _
                  "nvl(cm.qt_kg_a_fixar,0) qt_cacau_a_ordem, " & VlPreco & " as vl_preco_cacau, " & _
                  "cp.IC_JUROS_APOS_CARENCIA, -1 sq_contrato_fixo " & _
                  "FROM SOF.PAG_CTR_PAF PCP, SOF.PAGAMENTOS P, SOF.FORNECEDOR F, " & _
                  "SOF.CONTRATO_PAF CP, SOF.FORMA_PAGAMENTO FP, SOF.FILIAL FIL, " & _
                  "SOF.TIPO_PAGAMENTO TP, SOF.FORNECEDOR REP, SOF.TIPO_PESSOA TPE, SOF.PARAMETRO PARAM, " & _
                  "(select cp.cd_repassador, sum(cm.qt_kg_a_fixar) qt_kg_a_fixar " & _
                  "from sof.CTR_PAF_MOVIMENTACAO cm, sof.contrato_paf cp " & _
                  "Where cm.Cd_Contrato_PAF = cp.Cd_Contrato_PAF And cm.qt_kg_a_fixar <> 0 " & _
                  "group by cp.cd_repassador) cm "

        SqlText = SqlText & "WHERE P.CD_FORNECEDOR = F.CD_FORNECEDOR AND " & _
                  "F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL AND " & _
                  "P.CD_FORMA_PAGAMENTO = FP.CD_FORMA_PAGAMENTO AND " & _
                  "P.CD_TIPO_PAGAMENTO = TP.CD_TIPO_PAGAMENTO AND " & _
                  "P.SQ_PAGAMENTO = PCP.SQ_PAGAMENTO AND " & _
                  "PCP.cd_contrato_paf = CP.cd_contrato_paf AND " & _
                  "CP.CD_REPASSADOR = REP.CD_FORNECEDOR AND " & _
                  "REP.CD_TIPO_PESSOA = TPE.CD_TIPO_PESSOA AND " & _
                  "cp.cd_repassador = cm.cd_repassador (+) and " & _
                  "PCP.VL_A_FIXAR <> 0 "

        'Retiro as confições de dividas
        SqlText = SqlText & " and pcp.sq_confissao_divida is null "

        'Filtro Filial
        If SelecaoFilial.Lista_Quantidade <> 0 Then
            SqlText = SqlText & "and F.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
            Seleciona_Pag_Atrasado_Ctr_Fix(SelecaoFilial.Lista_ID)
        Else
            SqlText = SqlText & "and F.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            Seleciona_Pag_Atrasado_Ctr_Fix(ListarIDFiliaisLiberadaUsuario)
        End If

        Select Case cboOpcao.SelectedValue
            Case Sintetico.Vencidos, Sintetico.Vencidos_Por_titular
                SqlText = SqlText & " and CP.dt_vencimento < to_date('" & Date_to_Oracle(DataSistema) & "')"
            Case Sintetico.Avencer, Sintetico.Avencer_Por_titular
                SqlText = SqlText & " and CP.dt_vencimento >= to_date('" & Date_to_Oracle(DataSistema) & "')"
        End Select

        SqlText = SqlText & " UNION ALL "
        SqlText = SqlText & "SELECT f.cd_filial_origem, fil.no_filial, f.no_razao_social, p.dt_pagamento, "
        SqlText = SqlText & "       p.ds_descricao, pn.vl_a_fixar AS vl_pagamento, "
        SqlText = SqlText & "       ROUND(DECODE(p.vl_taxa_dolar, NULL, 0, pn.vl_a_fixar / p.vl_taxa_dolar), 2) vl_dolar, "
        SqlText = SqlText & "       NVL (p.vl_taxa_dolar, 0) vl_taxa_dolar, fp.no_forma_pagamento, "
        SqlText = SqlText & "       p.cd_tipo_pagamento, tp.no_tipo_pagamento, "
        SqlText = SqlText & "       p.ic_icms AS ic_pagamento_icms, pn.cd_contrato_paf, pn.sq_negociacao, "
        SqlText = SqlText & "       p.sq_pagamento, n.dt_vencimento, TO_DATE ('" & Date_to_Oracle(DataSistema) & "') AS dt_hoje, "
        SqlText = SqlText & "       rep.cd_fornecedor AS cd_repassador, "
        SqlText = SqlText & "       rep.no_razao_social AS no_repassador, tpe.no_tipo_pessoa, "
        SqlText = SqlText & "       f.cd_fornecedor, param.ic_juros_automatico ic_calcula_juros_automatico, "
        SqlText = SqlText & "       cp.ic_calcula_juros ic_calcula_juros_contrato, "
        SqlText = SqlText & "       tp.ic_calcula_juros ic_calcula_juros_pagamento, cp.pc_taxa_juros, "
        SqlText = SqlText & "       cp.qt_dia_carencia_juros AS qt_dia_carencia, "
        SqlText = SqlText & "       NVL(cm.qt_kg_a_fixar, 0) qt_cacau_a_ordem, " & VlPreco & " AS vl_preco_cacau, "
        SqlText = SqlText & "       cp.ic_juros_apos_carencia, -1 sq_contrato_fixo "
        SqlText = SqlText & "FROM   sof.pag_neg pn, "
        SqlText = SqlText & "       sof.pagamentos p, "
        SqlText = SqlText & "       sof.fornecedor f, "
        SqlText = SqlText & "       sof.negociacao n, "
        SqlText = SqlText & "       sof.contrato_paf cp, "
        SqlText = SqlText & "       sof.forma_pagamento fp, "
        SqlText = SqlText & "       sof.filial fil, "
        SqlText = SqlText & "       sof.tipo_pagamento tp, "
        SqlText = SqlText & "       sof.fornecedor rep, "
        SqlText = SqlText & "       sof.tipo_pessoa tpe, "
        SqlText = SqlText & "       sof.parametro param, "
        SqlText = SqlText & "       (SELECT   cp.cd_repassador, SUM (cm.qt_kg_a_fixar) qt_kg_a_fixar "
        SqlText = SqlText & "        FROM     sof.ctr_paf_movimentacao cm, sof.contrato_paf cp "
        SqlText = SqlText & "        WHERE    cm.cd_contrato_paf = cp.cd_contrato_paf "
        SqlText = SqlText & "        AND      cm.qt_kg_a_fixar <> 0 "
        SqlText = SqlText & "        GROUP BY cp.cd_repassador) cm "
        SqlText = SqlText & "WHERE  p.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "AND    f.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "AND    p.cd_forma_pagamento = fp.cd_forma_pagamento "
        SqlText = SqlText & "AND    p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
        SqlText = SqlText & "AND    p.sq_pagamento = pn.sq_pagamento "
        SqlText = SqlText & "AND    pn.cd_contrato_paf = n.cd_contrato_paf "
        SqlText = SqlText & "AND    PN.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO "
        SqlText = SqlText & "AND    N.CD_CONTRATO_PAF = CP.cd_contrato_paf "
        SqlText = SqlText & "AND    cp.cd_repassador = rep.cd_fornecedor "
        SqlText = SqlText & "AND    rep.cd_tipo_pessoa = tpe.cd_tipo_pessoa "
        SqlText = SqlText & "AND    cp.cd_repassador = cm.cd_repassador(+) "
        SqlText = SqlText & "AND    pN.vl_a_fixar <> 0 "

        'FILTRO FILIAL
        If SelecaoFilial.Lista_Quantidade <> 0 Then
            SqlText = SqlText & "and F.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            SqlText = SqlText & "and F.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        Select Case cboOpcao.SelectedValue
            Case Sintetico.Vencidos, Sintetico.Vencidos_Por_titular
                SqlText = SqlText & " and N.dt_vencimento < to_date('" & Date_to_Oracle(DataSistema) & "')"
            Case Sintetico.Avencer, Sintetico.Avencer_Por_titular
                SqlText = SqlText & " and N.dt_vencimento >= to_date('" & Date_to_Oracle(DataSistema) & "')"
        End Select

        SqlText = SqlText & " UNION ALL "
        SqlText = SqlText & "SELECT f.cd_filial_origem, fil.no_filial, f.no_razao_social, p.dt_pagamento, "
        SqlText = SqlText & "       p.ds_descricao, tmp.vl_aplicado vl_a_fixar, "
        SqlText = SqlText & "       ROUND(DECODE(p.vl_taxa_dolar, NULL, 0, tmp.vl_aplicado / p.vl_taxa_dolar), 2) vl_a_fixar_us, "
        SqlText = SqlText & "       NVL (p.vl_taxa_dolar, 0) vl_taxa_dolar, fp.no_forma_pagamento, "
        SqlText = SqlText & "       p.cd_tipo_pagamento, tp.no_tipo_pagamento, p.ic_icms, "
        SqlText = SqlText & "       tmp.cd_contrato_paf, tmp.sq_negociacao, p.sq_pagamento, "
        SqlText = SqlText & "       CF.dt_vencimento, TO_DATE ('" & Date_to_Oracle(DataSistema) & "'), rep.cd_fornecedor, "
        SqlText = SqlText & "       rep.no_razao_social, tpe.no_tipo_pessoa, f.cd_fornecedor, "
        SqlText = SqlText & "       param.ic_juros_automatico ic_calcula_juros_automatico, cp.ic_calcula_juros ic_calcula_juros_contrato, "
        SqlText = SqlText & "       tp.ic_calcula_juros ic_calcula_juros_pagamento, cp.pc_taxa_juros, "
        SqlText = SqlText & "       cp.qt_dia_carencia_juros AS qt_dia_carencia, NVL (cm.qt_kg_a_fixar, 0) qt_cacau_a_ordem, "
        SqlText = SqlText & "       " & VlPreco & " AS vl_preco_cacau, cp.ic_juros_apos_carencia, CF.sq_contrato_fixo "
        SqlText = SqlText & "FROM   sof.tmp_pagamento_aplicados tmp, "
        SqlText = SqlText & "       sof.pagamentos p, "
        SqlText = SqlText & "       sof.fornecedor f, "
        SqlText = SqlText & "       SOF.CONTRATO_FIXO CF, "
        SqlText = SqlText & "       sof.negociacao n, "
        SqlText = SqlText & "       sof.forma_pagamento fp, "
        SqlText = SqlText & "       sof.filial fil, "
        SqlText = SqlText & "       sof.tipo_pagamento tp, "
        SqlText = SqlText & "       sof.fornecedor rep, "
        SqlText = SqlText & "       sof.contrato_paf cp, "
        SqlText = SqlText & "       sof.tipo_pessoa tpe, "
        SqlText = SqlText & "       sof.parametro param, "
        SqlText = SqlText & "       (SELECT   cp.cd_repassador, SUM (cm.qt_kg_a_fixar) qt_kg_a_fixar "
        SqlText = SqlText & "        FROM     sof.ctr_paf_movimentacao cm, sof.contrato_paf cp "
        SqlText = SqlText & "        WHERE    cm.cd_contrato_paf = cp.cd_contrato_paf "
        SqlText = SqlText & "        AND      cm.qt_kg_a_fixar <> 0 "
        SqlText = SqlText & "        GROUP BY cp.cd_repassador) cm "
        SqlText = SqlText & "WHERE  p.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "AND    f.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "AND    p.cd_forma_pagamento = fp.cd_forma_pagamento "
        SqlText = SqlText & "AND    p.cd_tipo_pagamento = tp.cd_tipo_pagamento "
        SqlText = SqlText & "AND    p.sq_pagamento = tmp.sq_pagamento "
        SqlText = SqlText & "AND    tmp.cd_contrato_paf = CF.cd_contrato_paf "
        SqlText = SqlText & "AND    tmp.sq_negociacao = CF.sq_negociacao "
        SqlText = SqlText & "AND    TMP.SQ_CONTRATO_FIXO = CF.SQ_CONTRATO_FIXO "
        SqlText = SqlText & "AND    n.cd_contrato_paf = cp.cd_contrato_paf "
        SqlText = SqlText & "AND    N.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF "
        SqlText = SqlText & "AND    N.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO "
        SqlText = SqlText & "AND    cp.cd_repassador = rep.cd_fornecedor "
        SqlText = SqlText & "AND    cp.cd_repassador = cm.cd_repassador(+) "
        SqlText = SqlText & "AND    rep.cd_tipo_pessoa = tpe.cd_tipo_pessoa "

        'FILTRO FILIAL
        If SelecaoFilial.Lista_Quantidade <> 0 Then
            SqlText = SqlText & "and F.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            SqlText = SqlText & "and F.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        Select Case cboOpcao.SelectedValue
            Case Sintetico.Vencidos, Sintetico.Vencidos_Por_titular
                SqlText = SqlText & " and CF.dt_vencimento < to_date('" & Date_to_Oracle(DataSistema) & "')"
            Case Sintetico.Avencer, Sintetico.Avencer_Por_titular
                SqlText = SqlText & " and CF.dt_vencimento >= to_date('" & Date_to_Oracle(DataSistema) & "')"
        End Select


        oData = DBQuery(SqlText)

        oRelatorio.Load(Application.StartupPath & "\RPT_Adiantamento_Em_Aberto.rpt")
        oRelatorio.SetDataSource(oData)
       

        'constantes das sections
        Const secdetail As Integer = 8
        Const secfornfot1 As Integer = 10
        Const secfilfot1 As Integer = 13
        Const secTotGeralAnal As Integer = 16
        Const secRepassadorFooter As Integer = 11
        Const secRepassadorHeaders As Integer = 6
        Const secfilfot As Integer = 14
        Const secTotGeralSint1 As Integer = 18
        Const secFils1 As Integer = 4
        Const secRepassadorHeader As Integer = 5
        Const secfornfot As Integer = 9
        Const secTotGeralSint As Integer = 17
        Const secRepassadorFooterS As Integer = 12
        Const secFils As Integer = 3
        Const secFila As Integer = 2


        If optTipo.Value = "S" Then
            oRelatorio.ReportDefinition.Sections(secdetail).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secfornfot1).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secfilfot1).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secTotGeralAnal).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secRepassadorFooter).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secRepassadorHeaders).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secfilfot).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secTotGeralSint1).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secFils1).SectionFormat.EnableSuppress = True
            Select Case cboOpcao.SelectedValue
                Case Sintetico.Vencidos
                    oRelatorio.DataDefinition.FormulaFields("TITULO").Text = Chr(34) & "Relatorio de adiantamentos em aberto - Sintetico - Vencidos" & Chr(34)
                Case Sintetico.Avencer
                    oRelatorio.DataDefinition.FormulaFields("TITULO").Text = Chr(34) & "Relatorio de adiantamentos em aberto - Sintetico - A vencer" & Chr(34)
                Case Sintetico.Adto_30dd_com_cacau_aordem
                    oRelatorio.DataDefinition.FormulaFields("TITULO").Text = Chr(34) & "Relatorio de adiantamentos em aberto - Sintetico - Adto +30dd com cacau NPE" & Chr(34)
                    oRelatorio.RecordSelectionFormula = "(Date(" & Year(DataSistema) & "," & Month(DataSistema) & "," & _
                                                 Microsoft.VisualBasic.Day(DataSistema) & ") - {pagctrab_ttx.DT_PAGAMENTO}) > 30 and " & _
                                                 "{pagctrab_ttx.QT_CACAU_A_ORDEM} <> 0"

                    oRelatorio.ReportDefinition.Sections(secRepassadorHeaders).SectionFormat.EnableSuppress = False
                    oRelatorio.ReportDefinition.Sections(secfilfot).SectionFormat.EnableSuppress = False
                    oRelatorio.ReportDefinition.Sections(secTotGeralSint1).SectionFormat.EnableSuppress = False
                    oRelatorio.ReportDefinition.Sections(secFils1).SectionFormat.EnableSuppress = False

                    oRelatorio.ReportDefinition.Sections(secRepassadorHeader).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secfornfot).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secfilfot).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secTotGeralSint).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secRepassadorFooterS).SectionFormat.EnableSuppress = True
                    'Rpt.txtTitAtraso.SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secFils).SectionFormat.EnableSuppress = True
                Case Sintetico.Adto_30dd
                    oRelatorio.DataDefinition.FormulaFields("TITULO").Text = "'" & "Relatorio de adiantamentos em aberto - Sintetico - Adto +30dd" & "'"
                    oRelatorio.RecordSelectionFormula = "Date(" & Year(DataSistema) & "," & Month(DataSistema) & "," & Microsoft.VisualBasic.Day(DataSistema) & ") - {pagctrab_ttx.DT_PAGAMENTO} > 30"

                    oRelatorio.ReportDefinition.Sections(secRepassadorHeaders).SectionFormat.EnableSuppress = False
                    oRelatorio.ReportDefinition.Sections(secfilfot).SectionFormat.EnableSuppress = False
                    oRelatorio.ReportDefinition.Sections(secTotGeralSint1).SectionFormat.EnableSuppress = False
                    oRelatorio.ReportDefinition.Sections(secFils1).SectionFormat.EnableSuppress = False

                    oRelatorio.ReportDefinition.Sections(secRepassadorHeader).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secfornfot).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secfilfot).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secTotGeralSint).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secRepassadorFooterS).SectionFormat.EnableSuppress = True
                    'Rpt.txtTitAtraso.SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secFils).SectionFormat.EnableSuppress = True
                Case Sintetico.Avencer_Por_titular, Sintetico.Todos_Por_titular, Sintetico.Vencidos_Por_titular
                    Select Case Me.cboOpcao.SelectedValue
                        Case Sintetico.Vencidos_Por_titular
                            oRelatorio.DataDefinition.FormulaFields("TITULO").Text = Chr(34) & "Relatorio de adiantamentos em aberto - Sintetico - Vencidos - Por titular" & Chr(34)
                        Case Sintetico.Avencer_Por_titular
                            oRelatorio.DataDefinition.FormulaFields("TITULO").Text = Chr(34) & "Relatorio de adiantamentos em aberto - Sintetico - A vencer - Por titular" & Chr(34)
                        Case Sintetico.Todos_Por_titular
                            oRelatorio.DataDefinition.FormulaFields("TITULO").Text = Chr(34) & "Relatorio de adiantamentos em aberto - Sintetico - Todos - Por titular" & Chr(34)
                    End Select

                    oRelatorio.ReportDefinition.Sections(secRepassadorHeaders).SectionFormat.EnableSuppress = False
                    oRelatorio.ReportDefinition.Sections(secfilfot).SectionFormat.EnableSuppress = False
                    oRelatorio.ReportDefinition.Sections(secTotGeralSint1).SectionFormat.EnableSuppress = False
                    oRelatorio.ReportDefinition.Sections(secFils1).SectionFormat.EnableSuppress = False

                    oRelatorio.ReportDefinition.Sections(secRepassadorHeader).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secfornfot).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secfilfot).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secTotGeralSint).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secRepassadorFooterS).SectionFormat.EnableSuppress = True
                    oRelatorio.ReportDefinition.Sections(secFils).SectionFormat.EnableSuppress = True
                Case Else
                    oRelatorio.DataDefinition.FormulaFields("TITULO").Text = Chr(34) & "Relatorio de adiantamentos em aberto - Sintetico" & Chr(34)
            End Select
            oRelatorio.ReportDefinition.Sections(secFila).SectionFormat.EnableSuppress = True
        Else
            oRelatorio.ReportDefinition.Sections(secfornfot).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secfilfot).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secTotGeralSint).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secRepassadorFooterS).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secRepassadorHeaders).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secfilfot).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secTotGeralSint1).SectionFormat.EnableSuppress = True
            oRelatorio.ReportDefinition.Sections(secFils1).SectionFormat.EnableSuppress = True
            Select Case cboOpcao.SelectedValue
                Case Analitico.Vencidos
                    oRelatorio.DataDefinition.FormulaFields("TITULO").Text = Chr(34) & "Relatorio de adiantamentos em aberto - Analitico - Vencidos" & Chr(34)
                Case Analitico.Avencer
                    oRelatorio.DataDefinition.FormulaFields("TITULO").Text = Chr(34) & "Relatorio de adiantamentos em aberto - Analitico - A vencer" & Chr(34)
                Case Else
                    oRelatorio.DataDefinition.FormulaFields("TITULO").Text = Chr(34) & "Relatorio de adiantamentos em aberto - Analitico" & Chr(34)
            End Select

            oRelatorio.ReportDefinition.Sections(secFils).SectionFormat.EnableSuppress = True
        End If


        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        crvMain.ReportSource = oRelatorio


        AVI_Fechar(Me)
    End Sub

    Private Sub Seleciona_Pag_Atrasado_Ctr_Fix(ByVal CdFilial As String)
        Dim SqlText As String

        SqlText = "DECLARE "
        SqlText = SqlText & "    CDFILIALORIGEM      VARCHAR2(100); "
        SqlText = SqlText & "    QTKGS               NUMBER; "
        SqlText = SqlText & "    QTKGFIXO            NUMBER; "
        SqlText = SqlText & "    VLNEGOCIACAO        NUMBER; "
        SqlText = SqlText & "    CDTIPOUNIDADE       NUMBER; "
        SqlText = SqlText & "    VLPAGFIXO           NUMBER; "
        SqlText = SqlText & "    VLCFTOTAL           NUMBER; "
        SqlText = SqlText & "    CTRPAF              NUMBER; "
        SqlText = SqlText & "    SQNEG               NUMBER; "
        SqlText = SqlText & "    CTRFIX              NUMBER; "
        SqlText = SqlText & "    QTFATOR             NUMBER; "
        SqlText = SqlText & "    VLICMS              NUMBER; "
        SqlText = SqlText & "    PCALIQICMS          NUMBER; "
        SqlText = SqlText & "    SALDONEG            NUMBER; "
        SqlText = SqlText & "    DTHOJE              DATE; "
        SqlText = SqlText & "    MPOSI               NUMBER; "
        SqlText = SqlText & "    DTCOTACAO           DATE; "
        SqlText = SqlText & "    CDFORN              NUMBER; "
        SqlText = SqlText & "    VLFIXO              NUMBER; "
        SqlText = SqlText & "    CURSOR NEGAB IS "
        SqlText = SqlText & "        SELECT (cf.QT_KGS - cf.QT_CANCELADO) QT_KGS, cf.QT_KG_FIXO, "
        SqlText = SqlText & "               cf.VL_UNITARIO, cf.CD_TIPO_UNIDADE, cf.PC_ALIQ_ICMS, cf.VL_PAG_FIXO, "
        SqlText = SqlText & "               sof.FC_SALDO_CTR_FIX(cf.cd_contrato_paf,cf.sq_negociacao ,cf.sq_contrato_fixo ) VL_CF_TOTAL, "
        SqlText = SqlText & "               cf.CD_CONTRATO_PAF, cf.SQ_NEGOCIACAO, cf.sq_contrato_fixo "
        SqlText = SqlText & "        FROM SOF.CONTRATO_PAF CP, SOF.NEGOCIACAO N, "
        SqlText = SqlText & "             SOF.CONTRATO_FIXO CF "
        SqlText = SqlText & "        WHERE N.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "              N.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "              N.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO AND "
        SqlText = SqlText & "              cf.ic_status = 'A'; "
        SqlText = SqlText & "    CURSOR NEGABFIL IS "
        SqlText = SqlText & "        SELECT (cf.QT_KGS - cf.QT_CANCELADO) QT_KGS, cf.QT_KG_FIXO, "
        SqlText = SqlText & "               cf.VL_UNITARIO, cf.CD_TIPO_UNIDADE, cf.PC_ALIQ_ICMS, cf.VL_PAG_FIXO, "
        SqlText = SqlText & "               sof.FC_SALDO_CTR_FIX(cf.cd_contrato_paf,cf.sq_negociacao ,cf.sq_contrato_fixo ) VL_CF_TOTAL, "
        SqlText = SqlText & "               cf.CD_CONTRATO_PAF, cf.SQ_NEGOCIACAO, cf.sq_contrato_fixo "
        SqlText = SqlText & "        FROM SOF.CONTRATO_PAF CP, SOF.NEGOCIACAO N, "
        SqlText = SqlText & "             SOF.CONTRATO_FIXO CF, SOF.FORNECEDOR F "
        SqlText = SqlText & "        WHERE N.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "              N.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF AND "
        SqlText = SqlText & "              N.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO AND "
        SqlText = SqlText & "              CP.cd_fornecedor = F.cd_fornecedor AND "
        SqlText = SqlText & "              F.cd_filial_origem IN ( " & IIf(CdFilial = "", "0", CdFilial) & " ) AND "
        SqlText = SqlText & "              cf.ic_status = 'A'; "
        SqlText = SqlText & "    CURSOR PAGNEG(CDCTRPAF NUMBER, SEQNEG NUMBER, CDCTRFIX NUMBER) IS "
        SqlText = SqlText & "        SELECT PN.SQ_PAGAMENTO, PN.VL_FIXO "
        SqlText = SqlText & "        FROM SOF.PAG_NEG_CTR_FIX PN "
        SqlText = SqlText & "        WHERE PN.CD_CONTRATO_PAF = CDCTRPAF AND "
        SqlText = SqlText & "              PN.SQ_NEGOCIACAO = SEQNEG AND "
        SqlText = SqlText & "              PN.sq_contrato_fixo = CDCTRFIX  "
        SqlText = SqlText & "        ORDER BY PN.DT_FIXACAO DESC, PN.SQ_PAGAMENTO DESC; "
        SqlText = SqlText & "BEGIN "

        If CdFilial = "" Then
            SqlText = SqlText & "    CDFILIALORIGEM:=NULL; "
        Else
            SqlText = SqlText & "    CDFILIALORIGEM:='" & CdFilial & "'; "
        End If

        SqlText = SqlText & "     "
        SqlText = SqlText & "    DELETE FROM sof.tmp_pagamento_aplicados; "
        SqlText = SqlText & "     "
        SqlText = SqlText & "    COMMIT; "
        SqlText = SqlText & "     "
        SqlText = SqlText & "    IF CDFILIALORIGEM IS NULL THEN "
        SqlText = SqlText & "        OPEN NEGAB; "
        SqlText = SqlText & "    ELSE "
        SqlText = SqlText & "        OPEN NEGABFIL; "
        SqlText = SqlText & "    END IF; "
        SqlText = SqlText & "     "
        SqlText = SqlText & "    LOOP "
        SqlText = SqlText & "        IF CDFILIALORIGEM IS NULL THEN "
        SqlText = SqlText & "            FETCH NEGAB INTO QTKGS, QTKGFIXO, VLNEGOCIACAO, CDTIPOUNIDADE, "
        SqlText = SqlText & "                             PCALIQICMS, VLPAGFIXO, VLCFTOTAL, CTRPAF, SQNEG, CTRFIX; "
        SqlText = SqlText & "            EXIT WHEN NEGAB%NOTFOUND; "
        SqlText = SqlText & "        ELSE "
        SqlText = SqlText & "            FETCH NEGABFIL INTO QTKGS, QTKGFIXO, VLNEGOCIACAO, CDTIPOUNIDADE, "
        SqlText = SqlText & "                                PCALIQICMS, VLPAGFIXO, VLCFTOTAL, CTRPAF, SQNEG, CTRFIX; "
        SqlText = SqlText & "            EXIT WHEN NEGABFIL%NOTFOUND; "
        SqlText = SqlText & "        END IF; "
        SqlText = SqlText & "         "
        SqlText = SqlText & "        SELECT TU.QT_FATOR "
        SqlText = SqlText & "        INTO QTFATOR "
        SqlText = SqlText & "        FROM SOF.TIPO_UNIDADE TU "
        SqlText = SqlText & "        WHERE TU.CD_TIPO_UNIDADE = CDTIPOUNIDADE; "
        SqlText = SqlText & "         "
        SqlText = SqlText & "        PCALIQICMS := PCALIQICMS/100; "
        SqlText = SqlText & "         "
        SqlText = SqlText & "        IF QTKGS <> 0 THEN "
        SqlText = SqlText & "            VLNEGOCIACAO := VLCFTOTAL / QTKGS; "
        SqlText = SqlText & "        ELSE "
        SqlText = SqlText & "            VLNEGOCIACAO := 0; "
        SqlText = SqlText & "        END IF; "
        SqlText = SqlText & "         "
        SqlText = SqlText & "        SALDONEG := ROUND((QTKGFIXO * VLNEGOCIACAO),2) - VLPAGFIXO; "
        SqlText = SqlText & "         "
        SqlText = SqlText & "        IF SALDONEG < 0 THEN "
        SqlText = SqlText & "            SALDONEG := 0 - SALDONEG; "
        SqlText = SqlText & "             "
        SqlText = SqlText & "            FOR X IN PAGNEG(CTRPAF, SQNEG, CTRFIX) LOOP "
        SqlText = SqlText & "                IF SALDONEG <= X.VL_FIXO THEN "
        SqlText = SqlText & "                    VLFIXO:= SALDONEG; "
        SqlText = SqlText & "                ELSE "
        SqlText = SqlText & "                    VLFIXO:= X.VL_FIXO; "
        SqlText = SqlText & "                END IF; "
        SqlText = SqlText & "                 "
        SqlText = SqlText & "                INSERT INTO SOF.TMP_PAGAMENTO_APLICADOS "
        SqlText = SqlText & "                (CD_CONTRATO_PAF, SQ_NEGOCIACAO, SQ_CONTRATO_FIXO, VL_APLICADO, SQ_PAGAMENTO) "
        SqlText = SqlText & "                VALUES "
        SqlText = SqlText & "                (CTRPAF, SQNEG, CTRFIX, VLFIXO, X.SQ_PAGAMENTO); "
        SqlText = SqlText & "                 "
        SqlText = SqlText & "                COMMIT; "
        SqlText = SqlText & "                 "
        SqlText = SqlText & "                SALDONEG := SALDONEG - VLFIXO; "
        SqlText = SqlText & "                 "
        SqlText = SqlText & "                IF SALDONEG <=0 THEN "
        SqlText = SqlText & "                    EXIT; "
        SqlText = SqlText & "                END IF; "
        SqlText = SqlText & "            END LOOP; "
        SqlText = SqlText & "        END IF; "
        SqlText = SqlText & "    END LOOP; "
        SqlText = SqlText & "     "
        SqlText = SqlText & "    IF CDFILIALORIGEM IS NULL THEN "
        SqlText = SqlText & "        CLOSE NEGAB; "
        SqlText = SqlText & "    ELSE "
        SqlText = SqlText & "        CLOSE NEGABFIL; "
        SqlText = SqlText & "    END IF; "
        SqlText = SqlText & "     "
        SqlText = SqlText & "    EXCEPTION "
        SqlText = SqlText & "        WHEN OTHERS THEN "
        SqlText = SqlText & "            RAISE; "
        SqlText = SqlText & "END; "

        DBExecutar(SqlText)
    End Sub
End Class