Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRelatorioGeral_FilialPeriodoFornecedor
    Public Enum RGFP_TipoRelatorio
        AmarracaoICMS = 1
        AplicacaoContratoFixo = 2
    End Enum

    Public oTipoRelatorio As RGFP_TipoRelatorio
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmRelatorioGeral_FilialPeriodoFornecedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmRelatorioGeral_FilialPeriodoFornecedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        Dim bPesq01 As Boolean = False
        Dim SqlText As String

        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With

        Select Case oTipoRelatorio
            Case RGFP_TipoRelatorio.AmarracaoICMS
                Me.Text = "Amarração ICMS"

                lblSelecao01.Text = "Opções de Filtro"

                sqltext = "(SELECT 'A' cd_opcao, 'Amarrações' no_opcao "
                sqltext = sqltext & "  FROM DUAL "
                sqltext = sqltext & "UNION "
                sqltext = sqltext & "SELECT 'P' cd_opcao, 'Pagamento sem NF' no_opcao "
                sqltext = sqltext & "  FROM DUAL "
                sqltext = sqltext & "UNION "
                sqltext = sqltext & "SELECT 'M' cd_opcao, 'NF sem Pagamento' no_opcao "
                sqltext = sqltext & "  FROM DUAL) "

                With Selecao01
                    .BancoDados_Tabela = sqltext
                    .BancoDados_Campo_Codigo = "CD_OPCAO"
                    .BancoDados_Campo_Descricao = "NO_OPCAO"
                    .BancoDados_Carregar()
                End With

                bPesq01 = True
                lblR_NF.Visible = False
                txtNF.Visible = False
                chkSaldo.Visible = True
                optTipo.Visible = True
            Case RGFP_TipoRelatorio.AplicacaoContratoFixo
                Me.Text = "Aplicações em Contratos Fixos"
                bPesq01 = False
        End Select

        lblSelecao01.Visible = bPesq01
        Selecao01.Visible = bPesq01
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub

    Private Sub Imprimir()
        'Select Case oTipoRelatorio
        '    Case RGFP_TipoRelatorio.ProvisaoImpostos
        '        If Not Data_ValidarPeriodo("da movimentação", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub
        'End Select


        Dim oRelatorio_Sub1 As New ReportDocument
        Dim oRelatorio_Sub2 As New ReportDocument
        Dim oData As DataTable
   
        Dim SqlText As String
        Dim sFiltro As String = ""
        Dim sFiltro02 As String = ""
        Dim SqlFiltro As String = ""

        AVI_Carregar(Me)

        Select Case oTipoRelatorio
            Case RGFP_TipoRelatorio.AmarracaoICMS
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
                If IsDate(txtDataInicial.Text) Then
                    SqlText = SqlText & " AND TRUNC( c.dt_conciliacao ) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
                    sFiltro = "- Data Inicial : " & txtDataInicial.Text
                End If

                If IsDate(txtDataFinal.Text) Then
                    SqlText = SqlText & " AND TRUNC( c.dt_conciliacao ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
                    sFiltro = "- Data Final : " & txtDataFinal.Text
                End If

                If Pesq_Fornecedor.Codigo <> 0 Then
                    SqlText = SqlText & " AND p.cd_fornecedor = " & Pesq_Fornecedor.Codigo
                    sFiltro = sFiltro & " - Fornecedor: " & Pesq_Fornecedor.Text
                End If

                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
                    sFiltro = sFiltro & " - Filial: " & SelecaoFilial.Lista_Descricao
                Else
                    SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If


                '==>GROUP BY AMARRAÇÃO
                SqlText = SqlText & " group by f.no_razao_social, m.nu_nf, m.dt_movimentacao, m.vl_nf," & _
                        "pa.dt_amarracao,ms.VL_A_FIXAR,mns.vl_a_fixar , mcs.vl_conciliado "

                '==>Se quiser só com saldo não puxa pagamentos em aberto
                If chkSaldo.Checked Then
                    SqlText = SqlText & " having nvl(round(((nvl(ms.VL_A_FIXAR,0) + nvl(mns.VL_A_FIXAR,0)) *SUM (nvl(pa.vl_aplicacao,0))) /m.vl_nf,2) ,0) >0 "
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
                    If IsDate(txtDataInicial.Text) Then
                        SqlText = SqlText & " AND TRUNC( p.dt_pagamento) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
                    End If

                    If IsDate(txtDataFinal.Text) Then
                        SqlText = SqlText & " AND TRUNC( p.dt_pagamento ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
                    End If

                    If Pesq_Fornecedor.Codigo <> 0 Then
                        SqlText = SqlText & " AND p.cd_fornecedor = " & Pesq_Fornecedor.Codigo
                    End If

                    If SelecaoFilial.Lista_Quantidade > 0 Then
                        SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
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
                    If IsDate(txtDataInicial.Text) Then
                        SqlText = SqlText & " AND TRUNC( m.dt_movimentacao) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
                    End If

                    If IsDate(txtDataFinal.Text) Then
                        SqlText = SqlText & " AND TRUNC( m.dt_movimentacao ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
                    End If

                    If Pesq_Fornecedor.Codigo <> 0 Then
                        SqlText = SqlText & " AND m.cd_fornecedor = " & Pesq_Fornecedor.Codigo
                    End If

                    If SelecaoFilial.Lista_Quantidade > 0 Then
                        SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
                    Else
                        SqlText = SqlText & " AND f.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                    End If
                End If

                'filtro opçoes
                If Selecao01.Lista_Quantidade > 0 Then
                    SqlText = "select * from (" & SqlText & ") where cd_tp in (" & Selecao01.Lista_ID & ")"
                    sFiltro = "- Opções : " & Selecao01.Lista_Descricao
                End If

                oData = DBQuery(SqlText)

                oRelatorio.Load(Application.StartupPath & "\RPT_Amarracao_ICMS.rpt")
                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                oRelatorio.SetParameterValue("Tipo", optTipo.Value)
                crvMain.ReportSource = oRelatorio
            Case RGFP_TipoRelatorio.AplicacaoContratoFixo
                SqlText = "SELECT fil.cd_filial, fil.no_filial, f.no_razao_social, "
                SqlText = SqlText & "       cm.cd_contrato_paf AS cd_contrato, tm.no_tipo_movimentacao, "
                SqlText = SqlText & "       cm.sq_movimentacao, m.nu_nf, cm.qt_kg_fixo, cm.vl_fixo, cm.dt_fixacao, "
                SqlText = SqlText & "       m.vl_nf, m.vl_nf_icms, m.vl_nf_funrural, tm.ic_entra_no_rd, "
                SqlText = SqlText & "       cm.sq_negociacao, cm.sq_contrato_fixo, "
                SqlText = SqlText & "       cm.sq_movimentacao_cessao_direito, nvl(cf.VL_TAXA_DOLAR,tx.vl_taxa) vl_taxa "
                SqlText = SqlText & "  FROM sof.tipo_movimentacao tm, "
                SqlText = SqlText & "       sof.filial fil, "
                SqlText = SqlText & "       sof.fornecedor f, "
                SqlText = SqlText & "       sof.movimentacao m, "
                SqlText = SqlText & "       sof.movimentacao_cessao_direito mcd, "
                SqlText = SqlText & "       sof.ctr_paf_neg_ctr_fix_mov cm, "
                SqlText = SqlText & "       sof.taxa_dolar tx,sof.contrato_fixo cf "
                SqlText = SqlText & " WHERE tm.cd_tipo_movimentacao = m.cd_tipo_movimentacao "
                SqlText = SqlText & "   AND fil.cd_filial = cm.cd_filial_origem "
                SqlText = SqlText & "   AND f.cd_fornecedor = mcd.cd_fornecedor "
                SqlText = SqlText & "   AND cm.cd_contrato_paf = cf.cd_contrato_paf "
                SqlText = SqlText & "   AND cm.sq_negociacao = cf.sq_negociacao "
                SqlText = SqlText & "   AND cm.sq_contrato_fixo = cf.sq_contrato_fixo "
                SqlText = SqlText & "   AND mcd.sq_movimentacao = cm.sq_movimentacao "
                SqlText = SqlText & "   AND mcd.sq_movimentacao_cessao_direito = cm.sq_movimentacao_cessao_direito "
                SqlText = SqlText & "   AND mcd.sq_movimentacao = m.sq_movimentacao "
                SqlText = SqlText & "   AND cm.dt_fixacao = tx.dt_cotacao(+) "

                '==>FILTROS NF SEM PAGAMENTO
                If IsDate(txtDataInicial.Text) Then
                    SqlText = SqlText & " AND TRUNC( cm.dt_fixacao) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
                End If
                If IsDate(txtDataFinal.Text) Then
                    SqlText = SqlText & " AND TRUNC( cm.dt_fixacao ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
                End If
                If Pesq_Fornecedor.Codigo <> 0 Then
                    SqlText = SqlText & " AND f.cd_fornecedor = " & Pesq_Fornecedor.Codigo
                End If
                If SelecaoFilial.Lista_Quantidade > 0 Then
                    SqlText = SqlText & " AND cm.cd_filial_origem IN (" & SelecaoFilial.Lista_ID & ")"
                Else
                    SqlText = SqlText & " AND cm.cd_filial_origem IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
                End If
                If Trim(txtNF.Text) <> "" Then
                    SqlText = SqlText & " AND M.NU_NF = " & QuotedStr(Trim(txtNF.Text))
                End If

                SqlText = SqlText & " ORDER BY f.no_razao_social, cm.cd_contrato_paf, cm.sq_negociacao, cm.sq_contrato_fixo, cm.dt_fixacao"

                oData = DBQuery(SqlText)

                oRelatorio.Load(Application.StartupPath & "\RPT_Aplic_Contrato_Fixo.rpt")
                oRelatorio.SetDataSource(oData)
                oRelatorio.SetParameterValue("Filtro", sFiltro)
                oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
                crvMain.ReportSource = oRelatorio
        End Select

        AVI_Fechar(Me)
    End Sub

    Private Sub frmRelatorioGeral_FilialPeriodoFornecedor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub
End Class