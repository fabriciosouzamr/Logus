Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaMovimentacaoPorEstado
    Const cnt_GridGeral_AnoMes As Integer = 0
    Const cnt_GridGeral_CodigoUF As Integer = 1
    Const cnt_GridGeral_NomeUF As Integer = 2
    Const cnt_GridGeral_Quantidade As Integer = 3
    Const cnt_GridGeral_QuantidadeSacos As Integer = 4
    Const cnt_GridGeral_Ardosia As Integer = 5
    Const cnt_GridGeral_Sujidade As Integer = 6
    Const cnt_GridGeral_Umidade As Integer = 7
    Const cnt_GridGeral_Fumaca As Integer = 8
    Const cnt_GridGeral_Mofo As Integer = 9
    Const cnt_GridGeral_Achatada As Integer = 10
    Const cnt_GridGeral_PesoAmendoa As Integer = 11
    Const cnt_GridGeral_PercentualTipo1 As Integer = 12
    Const cnt_GridGeral_PercentualTipo2 As Integer = 13
    Const cnt_GridGeral_PercentualTipo3 As Integer = 14
    Const cnt_GridGeral_PercentualTipoRefugo As Integer = 15
    Const cnt_GridGeral_QuantidadeTipo1 As Integer = 16
    Const cnt_GridGeral_QuantidadeTipo2 As Integer = 17
    Const cnt_GridGeral_QuantidadeTipo3 As Integer = 18
    Const cnt_GridGeral_QuantidadeTipoRefugo As Integer = 19

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub frmConsultaMovimentacaoPorEstado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        SqlText = "(select distinct UF.cd_uf,TRIM (UF.cd_uf) no_uf" & _
                    " from sof.Movimentacao MOV, sof.Municipio MNC, sof.UF UF" & _
                    " where MNC.cd_Municipio = MOV.cd_Municipio_Origem" & _
                    " and UF.cd_UF = MNC.cd_UF)"

        SelecaoEstado.BancoDados_Tabela = SqlText
        SelecaoEstado.BancoDados_Campo_Codigo = "CD_UF"
        SelecaoEstado.BancoDados_Campo_Descricao = "NO_UF"
        SelecaoEstado.BancoDados_Carregar()

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, , , , , True)

        objGrid_Coluna_Add(grdGeral, "Ano Mês", 100)
        objGrid_Coluna_Add(grdGeral, "Código UF", 100)
        objGrid_Coluna_Add(grdGeral, "Estado", 100)
        objGrid_Coluna_Add(grdGeral, "Quantidade", 100)
        objGrid_Coluna_Add(grdGeral, "Sacos", 100)
        objGrid_Coluna_Add(grdGeral, "Ardosia", 100)
        objGrid_Coluna_Add(grdGeral, "Sujidade", 100)
        objGrid_Coluna_Add(grdGeral, "Umidade", 100)
        objGrid_Coluna_Add(grdGeral, "Fumaça", 100)
        objGrid_Coluna_Add(grdGeral, "Mofo", 100)
        objGrid_Coluna_Add(grdGeral, "Achatada", 100)
        objGrid_Coluna_Add(grdGeral, "Peso Amêndoa", 100)
        objGrid_Coluna_Add(grdGeral, "% Tipo I", 100)
        objGrid_Coluna_Add(grdGeral, "% Tipo II", 100)
        objGrid_Coluna_Add(grdGeral, "% Tipo III", 100)
        objGrid_Coluna_Add(grdGeral, "% Tipo R", 100)
        objGrid_Coluna_Add(grdGeral, "Qt Tipo I", 0)
        objGrid_Coluna_Add(grdGeral, "Qt Tipo II", 0)
        objGrid_Coluna_Add(grdGeral, "Qt Tipo III", 0)
        objGrid_Coluna_Add(grdGeral, "Qt Tipo R", 0)


        chkAgrupado_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String
        Dim SqlFiltro As String = ""

        If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub

        'FILTRO FILIAL
        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlFiltro = SqlFiltro & " AND F.cd_filial_origem in (" & SelecaoFilial.Lista_ID & ") "
        Else
            SqlFiltro = SqlFiltro & " AND F.cd_filial_origem in (" & ListarIDFiliaisLiberadaUsuario() & ") "
        End If

        If Not chkMes.Checked Then
            SqlText = "select '' ano_mes,uf.cd_uf, uf.no_uf, "
        Else
            SqlText = "select to_char(m.dt_movimentacao,'YYYY/MM') ano_mes, uf.cd_uf, uf.no_uf, "
        End If

        If chkAgrupado.Checked Then
            SqlText = SqlText & "       sum(m.qt_kg_liquido_nf) qt_entreque, "
            SqlText = SqlText & "       SUM(NVL(SF.QT_SACOS,0)) QT_SACOS, "
            SqlText = SqlText & "       round(sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.qt_ardosia) / sum(m.qt_kg_liquido_nf),2) ardosia, "
            SqlText = SqlText & "       round(sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.pc_sujidade) / sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf)),2) sujidade, "
            SqlText = SqlText & "       round(sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.qt_umidade) / sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf)),2) umidade, "
            SqlText = SqlText & "       round(sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.qt_fumaca) / sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf)),2) fumaca, "
            SqlText = SqlText & "       round(sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.QT_MOFO) / sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf)),2) mofo, "
            SqlText = SqlText & "       round(sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.QT_ACHATADA) / sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf)),2) achatada, "
            SqlText = SqlText & "       round(sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.QT_PESO_AMENDOA) / sum(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf)),2) peso_amendoa, "
            SqlText = SqlText & "       round((sum(decode(mq.ic_tipo_cacau,1,m.qt_kg_liquido_nf,0))/sum(m.qt_kg_liquido_nf))*100,2) pc_tipo_1, "
            SqlText = SqlText & "       round((sum(decode(mq.ic_tipo_cacau,2,m.qt_kg_liquido_nf,0))/sum(m.qt_kg_liquido_nf))*100,2) pc_tipo_2, "
            SqlText = SqlText & "       round((sum(decode(mq.ic_tipo_cacau,3,m.qt_kg_liquido_nf,0))/sum(m.qt_kg_liquido_nf))*100,2) pc_tipo_3, "
            SqlText = SqlText & "       round((sum(decode(mq.ic_tipo_cacau,4,m.qt_kg_liquido_nf,0))/sum(m.qt_kg_liquido_nf))*100,2) pc_tipo_refugo, "
            SqlText = SqlText & "       round((sum(decode(mq.ic_tipo_cacau,1,m.qt_kg_liquido_nf,0))),2) qt_tipo_1, "
            SqlText = SqlText & "       round((sum(decode(mq.ic_tipo_cacau,2,m.qt_kg_liquido_nf,0))),2) qt_tipo_2, "
            SqlText = SqlText & "       round((sum(decode(mq.ic_tipo_cacau,3,m.qt_kg_liquido_nf,0))),2) qt_tipo_3, "
            SqlText = SqlText & "       round((sum(decode(mq.ic_tipo_cacau,4,m.qt_kg_liquido_nf,0))),2) qt_tipo_refugo "
        Else
            SqlText = SqlText & "       cast(m.qt_kg_liquido_nf as number(20)) qt_entreque,"
            SqlText = SqlText & "       NVL(SF.QT_SACOS, 0) QT_SACOS, "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.qt_ardosia / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2) ardosia, "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.pc_sujidade / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2) sujidade, "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.qt_umidade / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2) umidade, "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.qt_fumaca / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2) fumaca, "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.QT_MOFO / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2) mofo, "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.QT_ACHATADA / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2) achatada, "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.QT_PESO_AMENDOA / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2) peso_amendoa, "
            SqlText = SqlText & "       round((decode(mq.ic_tipo_cacau,1,m.qt_kg_liquido_nf,0)/m.qt_kg_liquido_nf)*100, 2) pc_tipo_1, "
            SqlText = SqlText & "       round((decode(mq.ic_tipo_cacau,2,m.qt_kg_liquido_nf,0)/m.qt_kg_liquido_nf)*100, 2) pc_tipo_2, "
            SqlText = SqlText & "       round((decode(mq.ic_tipo_cacau,3,m.qt_kg_liquido_nf,0)/m.qt_kg_liquido_nf)*100, 2) pc_tipo_3, "
            SqlText = SqlText & "       round((decode(mq.ic_tipo_cacau,4,m.qt_kg_liquido_nf,0)/m.qt_kg_liquido_nf)*100, 2) pc_tipo_refugo, "
            SqlText = SqlText & "       round((sum(decode(mq.ic_tipo_cacau,1,m.qt_kg_liquido_nf,0))),2) qt_tipo_1, "
            SqlText = SqlText & "       round((sum(decode(mq.ic_tipo_cacau,2,m.qt_kg_liquido_nf,0))),2) qt_tipo_2, "
            SqlText = SqlText & "       round((sum(decode(mq.ic_tipo_cacau,3,m.qt_kg_liquido_nf,0))),2) qt_tipo_3, "
            SqlText = SqlText & "       round((sum(decode(mq.ic_tipo_cacau,4,m.qt_kg_liquido_nf,0))),2) qt_tipo_refugo "
        End If

        SqlText = SqlText & "from sof.movimentacao m, "
        SqlText = SqlText & "     sof.movimentacao_qualidade mq, "
        SqlText = SqlText & "     sof.fornecedor f, "
        SqlText = SqlText & "     sof.municipio munic, "
        SqlText = SqlText & "     sof.uf uf, "
        SqlText = SqlText & "     (SELECT SF.SQ_MOVIMENTACAO, "
        SqlText = SqlText & "             SUM(DECODE(SF.IC_ENTRADA_SAIDA,'E',SF.QT_SACOS,0-SF.QT_SACOS)) QT_SACOS "
        SqlText = SqlText & "      FROM SOF.SACARIA_FILIAL SF "
        SqlText = SqlText & "      WHERE SF.SQ_MOVIMENTACAO IS NOT NULL "
        SqlText = SqlText & "      GROUP BY SF.SQ_MOVIMENTACAO) SF "
        SqlText = SqlText & "where m.QT_KG_LIQUIDO_NF <> 0 and "
        SqlText = SqlText & "      m.sq_movimentacao = mq.sq_movimentacao (+) and "
        SqlText = SqlText & "      m.cd_fornecedor = f.cd_fornecedor and "
        SqlText = SqlText & "      M.SQ_MOVIMENTACAO = SF.SQ_MOVIMENTACAO (+) AND "
        SqlText = SqlText & "      nvl(m.cd_municipio_origem,f.cd_municipio) = munic.cd_municipio and "
        SqlText = SqlText & "      munic.cd_uf = uf.cd_uf and "
        SqlText = SqlText & "      m.cd_tipo_movimentacao in (select p.cd_tipo_movimentacao from sof.parametro_modalidade_tipo_mov p where p.cd_parametro_modalidade = 6) and "
        SqlText = SqlText & "      m.dt_movimentacao BETWEEN '" & Date_to_Oracle(txtDataInicial.Text) & "' AND '" & Date_to_Oracle(txtDataFinal.Text) & "' "

        'filtro filial
        SqlText = SqlText & SqlFiltro

        If SelecaoEstado.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND uf.cd_uf in (" & SelecaoEstado.Lista_ID & ") "
        End If

        If chkAgrupado.Checked Then
            If chkMes.Checked = False Then
                SqlText = SqlText & "group by uf.cd_uf, uf.no_uf "
            Else
                SqlText = SqlText & "group by to_char(m.dt_movimentacao,'YYYY/MM'), uf.cd_uf, uf.no_uf "
            End If

            grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridGeral_AnoMes).Hidden = (Not chkMes.Checked)
        Else
            SqlText = SqlText & "group by uf.cd_uf, uf.no_uf, "
            SqlText = SqlText & "       cast(m.qt_kg_liquido_nf as number(20)),"
            SqlText = SqlText & "       NVL(SF.QT_SACOS, 0), "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.qt_ardosia / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2), "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.pc_sujidade / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2), "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.qt_umidade / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2), "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.qt_fumaca / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2), "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.QT_MOFO / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2), "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.QT_ACHATADA / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2), "
            SqlText = SqlText & "       round(decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf) * mq.QT_PESO_AMENDOA / decode(mq.sq_movimentacao,null,0,m.qt_kg_liquido_nf), 2), "
            SqlText = SqlText & "       round((decode(mq.ic_tipo_cacau,1,m.qt_kg_liquido_nf,0)/m.qt_kg_liquido_nf)*100, 2), "
            SqlText = SqlText & "       round((decode(mq.ic_tipo_cacau,2,m.qt_kg_liquido_nf,0)/m.qt_kg_liquido_nf)*100, 2), "
            SqlText = SqlText & "       round((decode(mq.ic_tipo_cacau,3,m.qt_kg_liquido_nf,0)/m.qt_kg_liquido_nf)*100, 2), "
            SqlText = SqlText & "       round((decode(mq.ic_tipo_cacau,4,m.qt_kg_liquido_nf,0)/m.qt_kg_liquido_nf)*100, 2) "
        End If

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_AnoMes, _
                                                            cnt_GridGeral_CodigoUF, _
                                                            cnt_GridGeral_NomeUF, _
                                                            cnt_GridGeral_Quantidade, _
                                                            cnt_GridGeral_QuantidadeSacos, _
                                                            cnt_GridGeral_Ardosia, _
                                                            cnt_GridGeral_Sujidade, _
                                                            cnt_GridGeral_Umidade, _
                                                            cnt_GridGeral_Fumaca, _
                                                            cnt_GridGeral_Mofo, _
                                                            cnt_GridGeral_Achatada, _
                                                            cnt_GridGeral_PesoAmendoa, _
                                                            cnt_GridGeral_PercentualTipo1, _
                                                            cnt_GridGeral_PercentualTipo2, _
                                                            cnt_GridGeral_PercentualTipo3, _
                                                            cnt_GridGeral_PercentualTipoRefugo, _
                                                            cnt_GridGeral_QuantidadeTipo1, _
                                                            cnt_GridGeral_QuantidadeTipo2, _
                                                            cnt_GridGeral_QuantidadeTipo3, _
                                                            cnt_GridGeral_QuantidadeTipoRefugo})
        '==Adiciona Total
        CriarSumario()
    End Sub

    Private Sub CriarSumario()
        Dim QT_ENTREGUE As Double
        Dim VL_ARDOSIA As Double
        Dim VL_SUJIDADE As Double
        Dim VL_UMIDADE As Double
        Dim VL_FUMACA As Double
        Dim VL_MOFO As Double
        Dim VL_ACHATADA As Double
        Dim VL_PESO_AMENDOA As Double
        Dim qt_tipo_1 As Double
        Dim qt_tipo_2 As Double
        Dim qt_tipo_3 As Double
        Dim qt_tipo_refugo As Double
        Dim oRow As UltraWinDataSource.UltraDataRow
        Dim iCont As Integer

        Dim QT_SACOS As Double



        For iCont = 0 To grdGeral.Rows.Count - 1
            QT_ENTREGUE = QT_ENTREGUE + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Quantidade).Value)
            VL_ARDOSIA = VL_ARDOSIA + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Ardosia).Value) * Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_QuantidadeSacos).Value)
            VL_SUJIDADE = VL_SUJIDADE + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Sujidade).Value) * Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_QuantidadeSacos).Value)
            VL_UMIDADE = VL_UMIDADE + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Umidade).Value) * Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_QuantidadeSacos).Value)
            VL_FUMACA = VL_FUMACA + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Fumaca).Value) * Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_QuantidadeSacos).Value)
            VL_MOFO = VL_MOFO + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Mofo).Value) * Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_QuantidadeSacos).Value)
            VL_ACHATADA = VL_ACHATADA + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Achatada).Value) * Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_QuantidadeSacos).Value)
            VL_PESO_AMENDOA = VL_PESO_AMENDOA + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_PesoAmendoa).Value) * Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_QuantidadeSacos).Value)
            QT_SACOS = QT_SACOS + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_QuantidadeSacos).Value)
            qt_tipo_1 = qt_tipo_1 + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_QuantidadeTipo1).Value)
            qt_tipo_2 = qt_tipo_2 + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_QuantidadeTipo2).Value)
            qt_tipo_3 = qt_tipo_3 + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_QuantidadeTipo3).Value)
            qt_tipo_refugo = qt_tipo_refugo + Val("" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_QuantidadeTipoRefugo).Value)
        Next
   
        If QT_SACOS <> 0 Then
            oRow = oDS.Rows.Add

            oRow.Item(cnt_GridGeral_NomeUF) = "Totais"
            oRow.Item(cnt_GridGeral_Quantidade) = QT_ENTREGUE
            oRow.Item(cnt_GridGeral_Ardosia) = Math.Round(VL_ARDOSIA / QT_SACOS, 2)
            oRow.Item(cnt_GridGeral_Sujidade) = Math.Round(VL_SUJIDADE / QT_SACOS, 2)
            oRow.Item(cnt_GridGeral_Umidade) = Math.Round(VL_UMIDADE / QT_SACOS, 2)
            oRow.Item(cnt_GridGeral_Fumaca) = Math.Round(VL_FUMACA / QT_SACOS, 2)
            oRow.Item(cnt_GridGeral_Mofo) = Math.Round(VL_MOFO / QT_SACOS, 2)
            oRow.Item(cnt_GridGeral_Achatada) = Math.Round(VL_ACHATADA / QT_SACOS, 2)
            oRow.Item(cnt_GridGeral_PesoAmendoa) = Math.Round(VL_PESO_AMENDOA / QT_SACOS, 2)
            oRow.Item(cnt_GridGeral_PercentualTipo1) = Math.Round((qt_tipo_1 * 100) / QT_ENTREGUE, 2)
            oRow.Item(cnt_GridGeral_PercentualTipo2) = Math.Round((qt_tipo_2 * 100) / QT_ENTREGUE, 2)
            oRow.Item(cnt_GridGeral_PercentualTipo3) = Math.Round((qt_tipo_3 * 100) / QT_ENTREGUE, 2)
            oRow.Item(cnt_GridGeral_PercentualTipoRefugo) = Math.Round((qt_tipo_refugo * 100) / QT_ENTREGUE, 2)
            oRow.Item(cnt_GridGeral_QuantidadeSacos) = QT_SACOS
        End If
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub chkAgrupado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAgrupado.CheckedChanged
        If chkAgrupado.Checked = False Then
            chkMes.Checked = False
            chkMes.Enabled = False
        Else
            chkMes.Enabled = True
        End If
    End Sub

    Private Sub frmConsultaMovimentacaoPorEstado_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
End Class