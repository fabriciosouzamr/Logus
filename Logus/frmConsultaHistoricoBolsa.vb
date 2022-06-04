Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaHistoricoBolsa
    Const cnt_GridHistorico_Papel As Integer = 0
    Const cnt_GridHistorico_Nome As Integer = 1
    Const cnt_GridHistorico_Data As Integer = 2
    Const cnt_GridHistorico_Valor As Integer = 3
    Const cnt_GridHistorico_Diferenca As Integer = 4
    Const cnt_GridHistorico_FechamentoAnterior As Integer = 5
    Const cnt_GridHistoricol_HoraCotacao As Integer = 6
    Const cnt_GridHistorico_ValorMinimo As Integer = 7
    Const cnt_GridHistorico_ValorMaximo As Integer = 8
    Const cnt_GridHistorico_SQ_BOLSA_PERIODO_MATRIZ As Integer = 9

    Dim oDSHistorico As New UltraWinDataSource.UltraDataSource
    Dim oDSOnLine As New UltraWinDataSource.UltraDataSource

    Private Sub frmConsultaHistoricoBolsa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        SqlText = "(SELECT DISTINCT SUBSTR (bpm.cd_papel, 1, 3) AS cod, "
        SqlText = SqlText & "                SUBSTR (bpm.cd_papel, 1, 3) AS nome "
        SqlText = SqlText & "           FROM sof.bolsa_periodo_matriz bpm "
        SqlText = SqlText & "       ORDER BY SUBSTR (bpm.cd_papel, 1, 3) )"

        With SelecaoPapel
            .BancoDados_Tabela = SqlText
            .BancoDados_Campo_Codigo = "cod"
            .BancoDados_Campo_Descricao = "nome"
            .BancoDados_Carregar()
        End With

        objGrid_Inicializar(grdHistorico, , oDSHistorico, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True)

        objGrid_Coluna_Add(grdHistorico, "Papel", 80)
        objGrid_Coluna_Add(grdHistorico, "Descrição", 100)
        objGrid_Coluna_Add(grdHistorico, "Data", 70, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdHistorico, "Cotação", 90, , True, , , cnt_Formato_Valor_US_4casas)
        objGrid_Coluna_Add(grdHistorico, "Diferença", 80)
        objGrid_Coluna_Add(grdHistorico, "Ult. fechamento", 100, , , , , cnt_Formato_Valor_US_4casas)
        objGrid_Coluna_Add(grdHistorico, "Horario", 80)
        objGrid_Coluna_Add(grdHistorico, "Valor Minimo", 100, , , , , cnt_Formato_Valor_US_4casas)
        objGrid_Coluna_Add(grdHistorico, "Valor Maximo", 100, , , , , cnt_Formato_Valor_US_4casas)
        objGrid_Coluna_Add(grdHistorico, "SQ_BOLSA_PERIODO_MATRIZ", 0)

        objGrid_Inicializar(grdOnLine, , oDSOnLine, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdOnLine, "Papel", 80)
        objGrid_Coluna_Add(grdOnLine, "Descrição", 100)
        objGrid_Coluna_Add(grdOnLine, "Data", 0, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdOnLine, "Cotação", 90, , , , , cnt_Formato_Valor_US_4casas)
        objGrid_Coluna_Add(grdOnLine, "Diferença", 80)
        objGrid_Coluna_Add(grdOnLine, "Ult. fechamento", 100, , , , , cnt_Formato_Valor_US_4casas)
        objGrid_Coluna_Add(grdOnLine, "Horario", 80)
        objGrid_Coluna_Add(grdOnLine, "Valor Minimo", 100, , , , , cnt_Formato_Valor_US_4casas)
        objGrid_Coluna_Add(grdOnLine, "Valor Maximo", 100, , , , , cnt_Formato_Valor_US_4casas)

        ExecutaConsultaOnLine()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdHistorico, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub ExecutaConsultaHistorico()
        Dim SqlText As String

        SqlText = "SELECT   bpm.cd_papel, bpm.no_papel, "
        SqlText = SqlText & "         bh.dt_bolsa_historico, bh.vl_cotacao, bh.vl_diferenca, "
        SqlText = SqlText & "         bh.vl_fechamento_anterior, bh.dh_hora_cotacao, bh.vl_cotacao_min, "
        SqlText = SqlText & "         bh.vl_cotacao_max, bh.SQ_BOLSA_PERIODO_MATRIZ "
        SqlText = SqlText & "    FROM sof.bolsa_historico bh, sof.bolsa_periodo_matriz bpm "
        SqlText = SqlText & "   WHERE bh.sq_bolsa_periodo_matriz = bpm.sq_bolsa_periodo_matriz "


        If SelecaoPapel.Lista_Quantidade <> 0 Then
            SqlText = SqlText & _
                    " AND  (BH.SQ_BOLSA_PERIODO_MATRIZ in (SELECT  sq_bolsa_periodo_matriz " & _
                                                            "FROM sof.bolsa_periodo_matriz  " & _
                                                            "where SUBSTR (cd_papel, 1, 3) in (" & SelecaoPapel.Lista_ID & ")) or BH.SQ_BOLSA_PERIODO_MATRIZ=1) "
        End If
        If IsDate(txtDataInicial.Value) Then
            SqlText = SqlText & _
                    " AND BH.DT_BOLSA_HISTORICO   >= " & Date_to_Oracle(txtDataInicial.Value, , DataFormato.eInicioDia, False)
        End If
        If IsDate(txtDataFinal.Value) Then
            SqlText = SqlText & _
                    " AND BH.DT_BOLSA_HISTORICO   <= " & Date_to_Oracle(txtDataFinal.Value, , DataFormato.eFimDia, False)
        End If

        SqlText = SqlText & "ORDER BY bh.dt_bolsa_historico, bpm.cd_papel "

        objGrid_Carregar(grdHistorico, SqlText, New Integer() {cnt_GridHistorico_Papel, _
                                                               cnt_GridHistorico_Nome, _
                                                               cnt_GridHistorico_Data, _
                                                               cnt_GridHistorico_Valor, _
                                                               cnt_GridHistorico_Diferenca, _
                                                               cnt_GridHistorico_FechamentoAnterior, _
                                                               cnt_GridHistoricol_HoraCotacao, _
                                                               cnt_GridHistorico_ValorMinimo, _
                                                               cnt_GridHistorico_ValorMaximo, _
                                                               cnt_GridHistorico_SQ_BOLSA_PERIODO_MATRIZ})


        Dim iCont As Integer
        Dim PapelDolar As String

        PapelDolar = DBQuery_ValorUnico("select cd_papel_dolar from sof.bolsa_parametro")

        For iCont = 0 To grdHistorico.Rows.Count - 1
            If grdHistorico.Rows(iCont).Cells(cnt_GridHistorico_Papel).Value = PapelDolar Then
                With grdHistorico.Rows(iCont).Appearance
                    .ForeColor = Color.Black
                    .BackColor = Color.LightGray
                    .FontData.Bold = DefaultableBoolean.True
                End With
            End If
        Next
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsultaHistorico()
    End Sub

    Private Sub ExecutaConsultaOnLine()
        Dim SqlText As String

        SqlText = "SELECT BP.CD_PAPEL, BP.NO_PAPEL, SYSDATE DT_COTACAO, BP.VL_COTACAO, BP.VL_DIFERENCA," & _
                         "BP.VL_FECHAMENTO_ANTERIOR, BP.DH_HORA_COTACAO, BP.VL_COTACAO_MIN, BP.VL_COTACAO_MAX" & _
                  " FROM SOF.BOLSA_PERIODO BP "

        If SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_VisualizarBolsaInvisiveisConsulta) Then
            SqlText = SqlText & "  WHERE (BP.IC_EXIBE='S' OR BP.IC_MOEDA ='S')"
        End If

        SqlText = SqlText & " ORDER BY BP.NU_SEQUENCIA ASC"

        objGrid_Carregar(grdOnLine, SqlText, New Integer() {cnt_GridHistorico_Papel, _
                                                            cnt_GridHistorico_Nome, _
                                                            cnt_GridHistorico_Data, _
                                                            cnt_GridHistorico_Valor, _
                                                            cnt_GridHistorico_Diferenca, _
                                                            cnt_GridHistorico_FechamentoAnterior, _
                                                            cnt_GridHistoricol_HoraCotacao, _
                                                            cnt_GridHistorico_ValorMinimo, _
                                                            cnt_GridHistorico_ValorMaximo})

        Dim iCont As Integer
        Dim PapelDolar As String

        PapelDolar = DBQuery_ValorUnico("SELECT CD_PAPEL_DOLAR FROM SOF.BOLSA_PARAMETRO")

        For iCont = 0 To grdOnLine.Rows.Count - 1
            If grdOnLine.Rows(iCont).Cells(cnt_GridHistorico_Papel).Value = PapelDolar Then
                With grdOnLine.Rows(iCont).Appearance
                    .ForeColor = Color.White
                    .BackColor = Color.LightBlue
                    .FontData.Bold = DefaultableBoolean.True
                End With
            Else
                With grdOnLine.Rows(iCont).Appearance
                    .ForeColor = Color.Black
                    .BackColor = Color.LightGray
                    .FontData.Bold = DefaultableBoolean.True
                End With
            End If

            With grdOnLine.Rows(iCont).Cells(cnt_GridHistorico_Papel).Appearance
                .ForeColor = Color.White
                .BackColor = Color.LightBlue
                .FontData.Bold = DefaultableBoolean.True
            End With
        Next
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ExecutaConsultaOnLine()
    End Sub

    Private Sub frmConsultaHistoricoBolsa_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grpHistorico.Height = Me.ClientSize.Height - grpHistorico.Top - 53
        grpOnline.Height = Me.ClientSize.Height - (grpHistorico.Height + grpOnline.Top) - 53
        grdHistorico.Height = Me.grpHistorico.Height - grdHistorico.Top - 15
        grdOnLine.Height = Me.grpOnline.Height - grdOnLine.Top - 15
        'Largura
        grpHistorico.Width = Me.ClientSize.Width - grpHistorico.Left - 15
        grpOnline.Width = Me.ClientSize.Width - grpOnline.Left - 15
        grdHistorico.Width = Me.grpHistorico.Width - grdHistorico.Left - 15
        grdOnLine.Width = Me.grpOnline.Width - grdOnLine.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        'Posição vertical
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub

    Private Sub grdHistorico_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdHistorico.AfterCellUpdate
        Dim SqlText As String

        Select Case e.Cell.Column.Index
            Case cnt_GridHistorico_Valor
                SqlText = DBMontar_Update("SOF.BOLSA_HISTORICO", GerarArray("VL_COTACAO", ":VL_COTACAO"), _
                                                                 GerarArray("DT_BOLSA_HISTORICO", ":DT_BOLSA_HISTORICO", "AND", _
                                                                            "SQ_BOLSA_PERIODO_MATRIZ", ":SQ_BOLSA_PERIODO_MATRIZ"))

                If Not DBExecutar(SqlText, DBParametro_Montar("VL_COTACAO", e.Cell.Value), _
                                           DBParametro_Montar("DT_BOLSA_HISTORICO", Date_to_Oracle(objGrid_Valor(grdHistorico, cnt_GridHistorico_Data))), _
                                           DBParametro_Montar("SQ_BOLSA_PERIODO_MATRIZ", objGrid_Valor(grdHistorico, cnt_GridHistorico_SQ_BOLSA_PERIODO_MATRIZ))) Then GoTo Erro

                ExecutaConsultaHistorico()
        End Select

        Exit Sub

Erro:
        TratarErro(, , "frmConsultaHistoricoBolsa")
    End Sub
End Class