Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaRD
    Const cnt_GridGeral_Grupo As Integer = 0
    Const cnt_GridGeral_KgDia As Integer = 1
    Const cnt_GridGeral_VlDia As Integer = 2
    Const cnt_GridGeral_KgMes As Integer = 3
    Const cnt_GridGeral_VlMes As Integer = 4
    Const cnt_GridGeral_KgSafra As Integer = 5
    Const cnt_GridGeral_VlSafra As Integer = 6
    Const cnt_GridGeral_Ordem As Integer = 7
    Const cnt_GridGeral_EntradaSaida As Integer = 8

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim DataPesquisa As String
    Dim TipoRD As Integer
    Dim CodFilial As Integer

    Private Sub frmConsultaRD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Filial(cboFilial, True, False)
        ComboBox_Carregar_Tipo_RD(cboTipoRD, True)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, , , , , True)

        objGrid_Coluna_Add(grdGeral, "Descrição", 200)
        objGrid_Coluna_Add(grdGeral, "Kg Dia", 90, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Valor Dia", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Kg Mês", 90, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Valor Mês", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Kg Safra", 90, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Valor Safra", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Ordem", 0)
        objGrid_Coluna_Add(grdGeral, "Entrada ou Saída", 0)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        If Not IsDate(txtData.Text) Then
            Msg_Mensagem("Data invalida.")
            txtData.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboFilial) Then
            Msg_Mensagem("Selecione a filial.")
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboTipoRD) Then
            Msg_Mensagem("Selecione o tipo de RD.")
            Exit Sub
        End If

        SqlText = "SELECT   'Saldo Inicial' AS grupo, "
        SqlText = SqlText & "         SUM (DECODE (rde.ic_entrada_saida, 'E', -1, 1) * rde.qt_kg_dia "
        SqlText = SqlText & "             ) qt_kg_dia, "
        SqlText = SqlText & "         SUM (DECODE (rde.ic_entrada_saida, 'E', -1, 1) * rde.vl_dia) vl_dia, "
        SqlText = SqlText & "         SUM (DECODE (rde.ic_entrada_saida, 'E', -1, 1) * rde.qt_kg_mensal "
        SqlText = SqlText & "             ) qt_kg_mensal, "
        SqlText = SqlText & "         SUM (DECODE (rde.ic_entrada_saida, 'E', -1, 1) * rde.vl_mensal "
        SqlText = SqlText & "             ) vl_mensal, "
        SqlText = SqlText & "         SUM (DECODE (rde.ic_entrada_saida, 'E', -1, 1) * rde.qt_kg_safra "
        SqlText = SqlText & "             ) qt_kg_safra, "
        SqlText = SqlText & "         SUM (DECODE (rde.ic_entrada_saida, 'E', -1, 1) "
        SqlText = SqlText & "              * rde.vl_safra) vl_safra, 1 AS ordem, NULL entrada_saida "
        SqlText = SqlText & "    FROM sof.resumo_diario_estoque rde, "
        SqlText = SqlText & "         sof.tipo_movimentacao tm, "
        SqlText = SqlText & "         sof.filial f, "
        SqlText = SqlText & "         sof.tipo_rd t "
        SqlText = SqlText & "   WHERE rde.cd_filial_origem = " & cboFilial.SelectedValue
        SqlText = SqlText & "     AND rde.dt_movimento = " & QuotedStr(Date_to_Oracle(txtData.Text))
        SqlText = SqlText & "     AND rde.ic_tipo_rd = " & cboTipoRD.SelectedValue
        SqlText = SqlText & "     AND rde.cd_filial_origem = f.cd_filial "
        SqlText = SqlText & "     AND rde.cd_tipo_movimentacao = tm.cd_tipo_movimentacao "
        SqlText = SqlText & "     AND rde.cd_tipo_rd = t.cd_tipo_rd "
        SqlText = SqlText & "GROUP BY 'Saldo Inicial' "
        SqlText = SqlText & "union all "
        SqlText = SqlText & "SELECT   DECODE (rde.ic_entrada_saida, "
        SqlText = SqlText & "                 NULL, 'Saldo Final', "
        SqlText = SqlText & "                 tm.no_tipo_movimentacao "
        SqlText = SqlText & "                ) AS grupo, "
        SqlText = SqlText & "         SUM (rde.qt_kg_dia) qt_kg_dia, SUM (rde.vl_dia) vl_dia, "
        SqlText = SqlText & "         SUM (rde.qt_kg_mensal) qt_kg_mensal, SUM (rde.vl_mensal) vl_mensal, "
        SqlText = SqlText & "         SUM (rde.qt_kg_safra) qt_kg_safra, SUM (rde.vl_safra) vl_safra, "
        SqlText = SqlText & "         DECODE (rde.ic_entrada_saida, 'E', 2, 'S', 3, 4) ordem, "
        SqlText = SqlText & "         DECODE (rde.ic_entrada_saida, 'E','Entrada','S','Saída',null) entrada_saida "
        SqlText = SqlText & "    FROM sof.resumo_diario_estoque rde, "
        SqlText = SqlText & "         sof.tipo_movimentacao tm, "
        SqlText = SqlText & "         sof.filial f, "
        SqlText = SqlText & "         sof.tipo_rd t "
        SqlText = SqlText & "   WHERE rde.cd_filial_origem = " & cboFilial.SelectedValue
        SqlText = SqlText & "     AND rde.dt_movimento =" & QuotedStr(Date_to_Oracle(txtData.Text))
        SqlText = SqlText & "     AND rde.ic_tipo_rd = " & cboTipoRD.SelectedValue
        SqlText = SqlText & "     AND rde.cd_filial_origem = f.cd_filial "
        SqlText = SqlText & "     AND rde.cd_tipo_movimentacao = tm.cd_tipo_movimentacao "
        SqlText = SqlText & "     AND rde.cd_tipo_rd = t.cd_tipo_rd "
        SqlText = SqlText & "GROUP BY DECODE (rde.ic_entrada_saida, "
        SqlText = SqlText & "                 NULL, 'Saldo Final', "
        SqlText = SqlText & "                 tm.no_tipo_movimentacao "
        SqlText = SqlText & "                ), "
        SqlText = SqlText & "         DECODE (rde.ic_entrada_saida, 'E', 2, 'S', 3, 4), "
        SqlText = SqlText & "         DECODE (rde.ic_entrada_saida, 'E','Entrada','S','Saída',null)  "

        If chkDiferenteZero.Checked = True Then
            SqlText = SqlText & "  HAVING SUM (rde.qt_kg_dia) <> 0 "
            SqlText = SqlText & "      OR SUM (rde.vl_dia) <> 0 "
            SqlText = SqlText & "      OR SUM (rde.qt_kg_mensal) <> 0 "
            SqlText = SqlText & "      OR SUM (rde.vl_mensal) <> 0 "
            SqlText = SqlText & "      OR SUM (rde.qt_kg_safra) <> 0 "
            SqlText = SqlText & "      OR SUM (rde.vl_safra) <> 0 "
        End If

        Dim oDS As UltraWinDataSource.UltraDataSource
        Dim iCont As Integer
        Dim oData As DataTable
        Dim sEntradaSaida As String

        SqlText = "select * from (" & SqlText & ") order by ordem "

        oData = DBQuery(SqlText)

        oDS = grdGeral.DataSource
        oDS.Rows.Clear()
        sEntradaSaida = ""

        grdGeral.DisplayLayout.Override.AllowColSizing = UltraWinGrid.AllowColSizing.Synchronized

        With oDS
            For iCont = 0 To oData.Rows.Count - 1
                If Not CampoNulo(oData.Rows(iCont).Item("entrada_saida")) Then
                    If Trim(sEntradaSaida) <> oData.Rows(iCont).Item("entrada_saida") Then
                        sEntradaSaida = oData.Rows(iCont).Item("entrada_saida")

                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Item(cnt_GridGeral_EntradaSaida) = "-1"
                        .Rows(.Rows.Count - 1).Item(cnt_GridGeral_Grupo) = oData.Rows(iCont).Item("entrada_saida")
                    End If
                End If

                .Rows.Add()

                .Rows(.Rows.Count - 1).Item(cnt_GridGeral_Grupo) = oData.Rows(iCont).Item("grupo")
                .Rows(.Rows.Count - 1).Item(cnt_GridGeral_KgDia) = oData.Rows(iCont).Item("qt_kg_dia")
                .Rows(.Rows.Count - 1).Item(cnt_GridGeral_VlDia) = oData.Rows(iCont).Item("vl_dia")
                .Rows(.Rows.Count - 1).Item(cnt_GridGeral_KgMes) = oData.Rows(iCont).Item("qt_kg_mensal")
                .Rows(.Rows.Count - 1).Item(cnt_GridGeral_VlMes) = oData.Rows(iCont).Item("vl_mensal")
                .Rows(.Rows.Count - 1).Item(cnt_GridGeral_KgSafra) = oData.Rows(iCont).Item("qt_kg_safra")
                .Rows(.Rows.Count - 1).Item(cnt_GridGeral_VlSafra) = oData.Rows(iCont).Item("vl_safra")
                .Rows(.Rows.Count - 1).Item(cnt_GridGeral_Ordem) = oData.Rows(iCont).Item("ordem")
                .Rows(.Rows.Count - 1).Item(cnt_GridGeral_EntradaSaida) = oData.Rows(iCont).Item("entrada_saida")
            Next
        End With
        For iCont = 0 To grdGeral.Rows.Count - 1
            If NVL(grdGeral.Rows(iCont).Cells(cnt_GridGeral_EntradaSaida).Value, " ") = "-1" Then
                With grdGeral.Rows(iCont)
                    .Appearance.BackColor = Color.RoyalBlue
                    .Appearance.FontData.Bold = DefaultableBoolean.True
                    .Appearance.ForeColor = Color.White
                End With
            Else
                If NVL(grdGeral.Rows(iCont).Cells(cnt_GridGeral_EntradaSaida).Value, " ") = " " Then
                    With grdGeral.Rows(iCont)
                        .Appearance.BackColor = Color.LightGray
                        .Appearance.FontData.Bold = DefaultableBoolean.True
                        .Appearance.ForeColor = Color.Black
                    End With
                End If
            End If
        Next

        SqlText = "SELECT NVL(SUM(M.VL_NF),0) VL_TRANSITO," & _
                         "NVL(SUM(M.VL_NF_ICMS),0) VL_TRANSITO_ICMS," & _
                         "NVL(SUM(M.QT_KG_LIQUIDO_NF),0) QT_TRANSITO" & _
                  " FROM SOF.TRANSFERENCIA T," & _
                        "SOF.FILIAL FORI," & _
                        "SOF.MOVIMENTACAO M," & _
                        "SOF.TRANSFERENCIA_MODALIDADE TM" & _
                  " WHERE T.SQ_MOVIMENTACAO_SAIDA = M.SQ_MOVIMENTACAO" & _
                    " AND T.CD_FILIAL_ORIGEM = FORI.CD_FILIAL" & _
                    " AND T.CD_TRANSFERENCIA_MODALIDADE = TM.CD_TRANSFERENCIA_MODALIDADE" & _
                    " AND TM.IC_POSSUI_TRANSITO = 'S'" & _
                    " AND NVL(TM.IC_TIPO_UTILIZACAO, 'X') NOT IN ('T')" & _
                    " AND TM.CD_TIPO_MOVIMENTACAO_SAIDA = M.CD_TIPO_MOVIMENTACAO" & _
                    " AND ((" & QuotedStr(Date_to_Oracle(txtData.Text)) & " BETWEEN T.DT_TRANSFERENCIA" & _
                                                                              " AND NVL(T.DT_CHEGADA, TO_DATE(" & QuotedStr(Date_to_Oracle(DateAdd("D", 1, txtData.Text))) & ")))" & _
                    " AND NVL(T.DT_CHEGADA, TO_DATE(" & QuotedStr(Date_to_Oracle(DateAdd("D", 1, txtData.Text))) & ")) <> " & QuotedStr(Date_to_Oracle(txtData.Text)) & ")" & _
                    " AND FORI.CD_FILIAL = " & cboFilial.SelectedValue
        oData = DBQuery(SqlText)

        txtQuantidadeTransito.Value = oData.Rows(0).Item("QT_TRANSITO")
        txtValorTransito.Value = oData.Rows(0).Item("VL_TRANSITO")
        txtValorICMSTransito.Value = oData.Rows(0).Item("VL_TRANSITO_ICMS")
        txtValorPrecoMedio.Value = 0

        If grdGeral.Rows.Count > 0 Then
            If Val(grdGeral.Rows(grdGeral.Rows.Count - 1).Cells(cnt_GridGeral_KgDia).Value) > 0 Then
                txtValorPrecoMedio.Value = (grdGeral.Rows(grdGeral.Rows.Count - 1).Cells(cnt_GridGeral_VlDia).Value / grdGeral.Rows(grdGeral.Rows.Count - 1).Cells(cnt_GridGeral_KgDia).Value) * 1000
            Else
                txtValorPrecoMedio.Value = 0
            End If
        End If

        If grdGeral.Rows.Count > 0 Then
            DataPesquisa = txtData.Text
            TipoRD = cboTipoRD.SelectedValue
            CodFilial = cboFilial.SelectedValue
        Else
            DataPesquisa = ""
            Msg_Mensagem("A consulta não retornou registros")
        End If
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub frmConsultaRD_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 100
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 8
        'Posição horizontal
        cmdPesquisar.Left = Me.ClientSize.Width - cmdPesquisar.Width - 8
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 8
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdImprimir.Top = Me.ClientSize.Height - cmdImprimir.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        grpPreco.Top = Me.ClientSize.Height - grpTransito.Height - 53
        grpTransito.Top = Me.ClientSize.Height - grpTransito.Height - 53
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        If Not IsDate(DataPesquisa) Then
            Msg_Mensagem("Pesquise as informações para essa pergunta primeiro e depois execute a impressão")
            Exit Sub
        End If

        Dim oForm As New frmREL_RD

        oForm.DataPesquisa = DataPesquisa
        oForm.TipoRD = cboTipoRD.SelectedValue
        oForm.CodFilial = cboFilial.SelectedValue
        Form_Show(Nothing, oForm)
    End Sub
End Class