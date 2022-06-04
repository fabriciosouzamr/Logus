Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaSaldoSacaria
    Const cnt_GridFilial_TipoSacaria As Integer = 0
    Const cnt_GridFilial_Cheio As Integer = 1
    Const cnt_GridFilial_Vazio As Integer = 2
    Const cnt_GridFilial_Credito As Integer = 3
    Const cnt_GridFilial_Debito As Integer = 4
    Const cnt_GridFilial_Estoque As Integer = 5

    Const cnt_GridFornecedor_TipoSacaria As Integer = 0
    Const cnt_GridFornecedor_Saldo As Integer = 1

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        Select Case optTipo.Value
            Case "FI"
                lblR_Titulo.Text = "Filial"
                Pesq_Fornecedor.Visible = False
                cboFilial.Visible = True
                cboFilial.Top = Pesq_Fornecedor.Top + 2
                cboFilial.Left = Pesq_Fornecedor.Left
            Case "FO"
                lblR_Titulo.Text = "Fornecedor"
                Pesq_Fornecedor.Visible = True
                cboFilial.Visible = False
            Case "RE"
                lblR_Titulo.Text = "Repassador"
                Pesq_Fornecedor.Visible = True
                cboFilial.Visible = False
        End Select
        MontaGrid()
    End Sub

    Private Sub frmConsultaSaldoSacaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        ComboBox_Carregar_Filial(cboFilial, True)
        optTipo.CheckedIndex = 0
        optTipo_ValueChanged(Nothing, Nothing)
        grdGeral.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True

    End Sub

    Sub MontaGrid()
        oDS.Rows.Clear()
        Select Case optTipo.Value
            Case "FI"
                objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

                objGrid_Coluna_Add(grdGeral, "Tipo Sacaria", 120)
                objGrid_Coluna_Add(grdGeral, "Cheios", 80, , , , , cnt_Formato_NumeroInteiro)
                objGrid_Coluna_Add(grdGeral, "Vazios", 80, , , , , cnt_Formato_NumeroInteiro)
                objGrid_Coluna_Add(grdGeral, "Credito Fornecedor", 100, , , , , cnt_Formato_NumeroInteiro)
                objGrid_Coluna_Add(grdGeral, "Debito Fornecedor", 100, , , , , cnt_Formato_NumeroInteiro)
                objGrid_Coluna_Add(grdGeral, "Em Estoque", 80, , , , , cnt_Formato_NumeroInteiro)

            Case "FO", "RE"
                objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

                objGrid_Coluna_Add(grdGeral, "Tipo Sacaria", 250)
                objGrid_Coluna_Add(grdGeral, "Saldo", 100, , , , , cnt_Formato_NumeroInteiro)
        End Select
    End Sub


    Private Sub ExecutaConsulta()
        Dim SqlText As String
        Dim oData As DataTable
        Dim iCont As Integer
        Dim CampoGrid() As Integer

        Select Case optTipo.Value
            Case "FI"
                If Not ComboBox_LinhaSelecionada(cboFilial) Then
                    Msg_Mensagem("Informe a filial.")
                    cboFilial.Focus()
                    Exit Sub
                End If

                SqlText = "SELECT    ts.no_tipo_sacaria,"
                SqlText = SqlText & "         NVL (m.qt_sacos_c, 0) qt_sacos_c, "
                SqlText = SqlText & "         (NVL (s.qt_sacos_t, 0) - NVL (m.qt_sacos_c, 0)) qt_sacos_v, "
                SqlText = SqlText & "         "
                SqlText = SqlText & "         SUM (NVL (forn_cred.qt_sacos_forn_cred, 0)) qt_sacos_forn_cred, "
                SqlText = SqlText & "         SUM (NVL (forn_deb.qt_sacos_forn_deb, 0)) qt_sacos_forn_deb, NVL (s.qt_sacos_t, 0) "
                SqlText = SqlText & "         + SUM (NVL (forn_deb.qt_sacos_forn_deb, 0)) "
                SqlText = SqlText & "         + SUM (NVL (forn_cred.qt_sacos_forn_cred, 0)) qt_sacos_t "
                SqlText = SqlText & "    FROM (SELECT   SUM (DECODE (ic_entrada_saida, 'S', -qt_sacos, qt_sacos) "
                SqlText = SqlText & "                       ) AS qt_sacos_t, "
                SqlText = SqlText & "                   cd_tipo_sacaria "
                SqlText = SqlText & "              FROM sof.sacaria_filial sf "
                SqlText = SqlText & "             WHERE cd_filial_credito = " & cboFilial.SelectedValue
                SqlText = SqlText & "          GROUP BY cd_tipo_sacaria) s, "
                SqlText = SqlText & "         (SELECT     SUM (DECODE (ic_entrada_saida, "
                SqlText = SqlText & "                                  'E', sf.qt_sacos, "
                SqlText = SqlText & "                                  -1 * sf.qt_sacos "
                SqlText = SqlText & "                                 ) "
                SqlText = SqlText & "                         ) "
                SqlText = SqlText & "                   * -1 qt_sacos_forn_cred, "
                SqlText = SqlText & "                   sf.cd_tipo_sacaria, f.cd_fornecedor "
                SqlText = SqlText & "              FROM sof.sacaria_fornecedor sf, sof.fornecedor f "
                SqlText = SqlText & "             WHERE sf.cd_fornecedor = f.cd_fornecedor "
                SqlText = SqlText & "               AND f.cd_filial_origem = " & cboFilial.SelectedValue
                SqlText = SqlText & "          GROUP BY sf.cd_tipo_sacaria, f.cd_fornecedor "
                SqlText = SqlText & "            HAVING SUM (DECODE (ic_entrada_saida, "
                SqlText = SqlText & "                                'E', sf.qt_sacos, "
                SqlText = SqlText & "                                -1 * sf.qt_sacos "
                SqlText = SqlText & "                               ) "
                SqlText = SqlText & "                       ) > 0) forn_cred, "
                SqlText = SqlText & "         (SELECT     SUM (DECODE (ic_entrada_saida, "
                SqlText = SqlText & "                                  'E', sf.qt_sacos, "
                SqlText = SqlText & "                                  -1 * sf.qt_sacos "
                SqlText = SqlText & "                                 ) "
                SqlText = SqlText & "                         ) "
                SqlText = SqlText & "                   * -1 qt_sacos_forn_deb, "
                SqlText = SqlText & "                   sf.cd_tipo_sacaria, f.cd_fornecedor "
                SqlText = SqlText & "              FROM sof.sacaria_fornecedor sf, sof.fornecedor f "
                SqlText = SqlText & "             WHERE sf.cd_fornecedor = f.cd_fornecedor "
                SqlText = SqlText & "               AND f.cd_filial_origem = " & cboFilial.SelectedValue
                SqlText = SqlText & "          GROUP BY sf.cd_tipo_sacaria, f.cd_fornecedor "
                SqlText = SqlText & "            HAVING SUM (DECODE (ic_entrada_saida, "
                SqlText = SqlText & "                                'E', sf.qt_sacos, "
                SqlText = SqlText & "                                -1 * sf.qt_sacos "
                SqlText = SqlText & "                               ) "
                SqlText = SqlText & "                       ) < 0) forn_deb, "
                SqlText = SqlText & "         sof.tipo_sacaria ts, "
                SqlText = SqlText & "         (SELECT   sf.cd_tipo_sacaria, SUM (sf.qt_sacos) qt_sacos_c "
                SqlText = SqlText & "              FROM sof.movimentacao_pilha_armazem mpa, "
                SqlText = SqlText & "                   sof.pilha_armazem pa, "
                SqlText = SqlText & "                   sof.armazem a, "
                SqlText = SqlText & "                   (SELECT   cd_armazem, cd_pilha_armazem, sq_movimentacao, "
                SqlText = SqlText & "                             sq_movimentacao_pilha_armazem, "
                SqlText = SqlText & "                             SUM (qt_sacos) qt_sacos, cd_tipo_sacaria "
                SqlText = SqlText & "                        FROM sof.mov_pilha_armazem_sacaria "
                SqlText = SqlText & "                    GROUP BY cd_armazem, "
                SqlText = SqlText & "                             cd_pilha_armazem, "
                SqlText = SqlText & "                             sq_movimentacao, "
                SqlText = SqlText & "                             sq_movimentacao_pilha_armazem, "
                SqlText = SqlText & "                             cd_tipo_sacaria) sf "
                SqlText = SqlText & "             WHERE mpa.cd_armazem = pa.cd_armazem "
                SqlText = SqlText & "               AND mpa.cd_pilha_armazem = pa.cd_pilha_armazem "
                SqlText = SqlText & "               AND pa.cd_armazem = a.cd_armazem "
                SqlText = SqlText & "               AND mpa.cd_armazem = sf.cd_armazem(+) "
                SqlText = SqlText & "               AND mpa.cd_pilha_armazem = sf.cd_pilha_armazem(+) "
                SqlText = SqlText & "               AND mpa.sq_movimentacao = sf.sq_movimentacao(+) "
                SqlText = SqlText & "               AND mpa.sq_movimentacao_pilha_armazem = sf.sq_movimentacao_pilha_armazem(+) "
                SqlText = SqlText & "               AND a.cd_filial_origem = " & cboFilial.SelectedValue
                SqlText = SqlText & "          GROUP BY sf.cd_tipo_sacaria) m "
                SqlText = SqlText & "   WHERE s.cd_tipo_sacaria(+) = ts.cd_tipo_sacaria "
                SqlText = SqlText & "     AND m.cd_tipo_sacaria(+) = ts.cd_tipo_sacaria "
                SqlText = SqlText & "     AND forn_deb.cd_tipo_sacaria(+) = ts.cd_tipo_sacaria "
                SqlText = SqlText & "     AND forn_cred.cd_tipo_sacaria(+) = ts.cd_tipo_sacaria "
                SqlText = SqlText & "     AND ts.ic_contabiliza_fornecedor = 'S' "
                SqlText = SqlText & "GROUP BY NVL (s.qt_sacos_t, 0), NVL (m.qt_sacos_c, 0), ts.no_tipo_sacaria "

                objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridFilial_TipoSacaria, _
                                                                   cnt_GridFilial_Cheio, _
                                                                   cnt_GridFilial_Vazio, _
                                                                   cnt_GridFilial_Credito, _
                                                                   cnt_GridFilial_Debito, _
                                                                   cnt_GridFilial_Estoque})

                objGrid_ExibirTotal(grdGeral, New Integer() {cnt_GridFilial_Cheio, _
                                                             cnt_GridFilial_Vazio, _
                                                             cnt_GridFilial_Credito, _
                                                             cnt_GridFilial_Debito, _
                                                             cnt_GridFilial_Estoque})
            Case "FO"
                If Pesq_Fornecedor.Codigo <= 0 Then
                    Msg_Mensagem("Informe o fornecedor.")
                    Pesq_Fornecedor.Focus()
                    Exit Sub
                End If

                SqlText = "SELECT TS.NO_TIPO_SACARIA ,SUM(decode(SF.IC_ENTRADA_SAIDA,'S', -SF.QT_SACOS, SF.QT_SACOS)) AS SALDO_SACARIA " & _
                            "FROM SOF.SACARIA_FORNECEDOR SF, SOF.TIPO_SACARIA TS " & _
                            "WHERE SF.CD_FORNECEDOR=" & Pesq_Fornecedor.Codigo & " and " & _
                            "SF.CD_TIPO_SACARIA = TS.CD_TIPO_SACARIA " & _
                            "GROUP BY TS.NO_TIPO_SACARIA"

                objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridFornecedor_TipoSacaria, _
                                                                           cnt_GridFornecedor_Saldo})
            Case "RE"
                If Pesq_Fornecedor.Codigo <= 0 Then
                    Msg_Mensagem("Informe o repassador.")
                    Pesq_Fornecedor.Focus()
                    Exit Sub
                End If

                SqlText = "select f.cd_fornecedor, f.no_razao_social   from sof.fornecedor f " & _
                          "where NVL(f.cd_repassador, f.cd_fornecedor) = " & Pesq_Fornecedor.Codigo
                oData = DBQuery(SqlText)
                oDS.Rows.Clear()
                objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

                objGrid_Coluna_Add(grdGeral, "Tipo Sacaria", 250)
                For iCont = 0 To oData.Rows.Count - 1
                    objGrid_Coluna_Add(grdGeral, oData.Rows(iCont).Item("no_razao_social"), 140, , , , , cnt_Formato_NumeroInteiro)
                Next
                objGrid_Coluna_Add(grdGeral, "Saldo", 100, , , , , cnt_Formato_NumeroInteiro)

                SqlText = "SELECT TS.NO_TIPO_SACARIA,"
                For iCont = 0 To oData.Rows.Count - 1
                    SqlText = SqlText & "SUM(decode(sf.cd_fornecedor," & oData.Rows(iCont).Item("cd_fornecedor") & ", decode(SF.IC_ENTRADA_SAIDA,'S', -SF.QT_SACOS, SF.QT_SACOS),0)) AS REP, "
                Next
                SqlText = SqlText & "SUM(decode(SF.IC_ENTRADA_SAIDA,'S', -SF.QT_SACOS, SF.QT_SACOS)) AS SALDO_SACARIA " & _
                       "FROM SOF.SACARIA_FORNECEDOR SF, SOF.TIPO_SACARIA TS, SOF.FORNECEDOR F " & _
                       "WHERE SF.CD_FORNECEDOR=F.CD_FORNECEDOR   and SF.CD_FORNECEDOR IN (SELECT CD_FORNECEDOR FROM SOF.FORNECEDOR " & _
                       "WHERE CD_REPASSADOR = " & Pesq_Fornecedor.Codigo & " UNION SELECT CD_FORNECEDOR FROM SOF.FORNECEDOR " & _
                       "WHERE CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & ") and " & _
                       "SF.CD_TIPO_SACARIA = TS.CD_TIPO_SACARIA " & _
                       "GROUP BY TS.NO_TIPO_SACARIA"

                ReDim Preserve CampoGrid(oData.Rows.Count + 2)

                For iCont = 0 To oData.Rows.Count + 2
                    CampoGrid(iCont) = iCont
                Next

                objGrid_Carregar(grdGeral, SqlText, CampoGrid)
        End Select
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub frmConsultaSaldoSacaria_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
    End Sub
End Class