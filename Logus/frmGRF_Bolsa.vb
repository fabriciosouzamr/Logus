Imports Infragistics.UltraChart.Shared.Styles

Public Class frmGRF_Bolsa

    Private Sub cmdFechar_Grafico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar_Grafico.Click
        Me.Close()
    End Sub

    Private Sub frmGRF_Bolsa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Me.WindowState = FormWindowState.Maximized

        objChart_Formatar(grfGeral, ChartType.StackColumnChart, False)

        Dim oForm As frmChart_Propriedade

        oForm = Me.MdiParent
        oForm.Carregar(grfGeral)
    End Sub

    Private Sub CarregaDados()
        Dim SqlText As String = ""
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim iCont_03 As Integer
        Dim bAchou As Boolean
        Dim oColuna As System.Data.DataColumn
        Dim oData As New DataTable
        Dim oData_Chart As New DataTable

        oData_Chart.Columns.Add("Data")
        oColuna = New System.Data.DataColumn


        SqlText = "SELECT distinct  bh.sq_bolsa_periodo_matriz as cod, bpm.cd_papel as nome"
        SqlText = SqlText & "    FROM sof.bolsa_historico bh, sof.bolsa_periodo_matriz bpm "
        SqlText = SqlText & "   WHERE bh.sq_bolsa_periodo_matriz = bpm.sq_bolsa_periodo_matriz "

        If SelecaoPapel.Lista_Quantidade <> 0 Then
            SqlText = SqlText & _
                    " AND  BH.SQ_BOLSA_PERIODO_MATRIZ in (SELECT  sq_bolsa_periodo_matriz " & _
                                                            "FROM sof.bolsa_periodo_matriz  " & _
                                                            "where SUBSTR (cd_papel, 1, 3) in (" & SelecaoPapel.Lista_ID & ")) "
        End If
        If IsDate(txtDataInicial.Value) Then
            SqlText = SqlText & _
                    " AND BH.DT_BOLSA_HISTORICO   >= " & Date_to_Oracle(txtDataInicial.Value, , DataFormato.eInicioDia, False)
        End If
        If IsDate(txtDataFinal.Value) Then
            SqlText = SqlText & _
                    " AND BH.DT_BOLSA_HISTORICO   <= " & Date_to_Oracle(txtDataFinal.Value, , DataFormato.eFimDia, False)
        End If

        SqlText = SqlText & "ORDER BY bh.sq_bolsa_periodo_matriz "



        oData = DBQuery(SqlText)

        For iCont_01 = 0 To oData.Rows.Count - 1
            oColuna = New System.Data.DataColumn

            oColuna.ColumnName = objDataTable_LerCampo(oData.Rows(iCont_01).Item("nome"), "-")
            oColuna.Caption = objDataTable_LerCampo(oData.Rows(iCont_01).Item("cod"), "0")
            oColuna.DataType = System.Type.GetType("System.Double")

            oData_Chart.Columns.Add(oColuna)
        Next


        SqlText = "SELECT  bh.sq_bolsa_periodo_matriz as cod, bpm.cd_papel, TRUNC(bh.dt_bolsa_historico)  AS dt_bolsa_historico, bh.vl_cotacao "
        SqlText = SqlText & "    FROM sof.bolsa_historico bh, sof.bolsa_periodo_matriz bpm "
        SqlText = SqlText & "   WHERE bh.sq_bolsa_periodo_matriz = bpm.sq_bolsa_periodo_matriz "

        If SelecaoPapel.Lista_Quantidade <> 0 Then
            SqlText = SqlText & _
                    " AND  BH.SQ_BOLSA_PERIODO_MATRIZ in (SELECT  sq_bolsa_periodo_matriz " & _
                                                            "FROM sof.bolsa_periodo_matriz  " & _
                                                            "where SUBSTR (cd_papel, 1, 3) in (" & SelecaoPapel.Lista_ID & ")) "
        End If
        If IsDate(txtDataInicial.Value) Then
            SqlText = SqlText & _
                    " AND BH.DT_BOLSA_HISTORICO   >= " & Date_to_Oracle(txtDataInicial.Value, , DataFormato.eInicioDia, False)
        End If
        If IsDate(txtDataFinal.Value) Then
            SqlText = SqlText & _
                    " AND BH.DT_BOLSA_HISTORICO   <= " & Date_to_Oracle(txtDataFinal.Value, , DataFormato.eFimDia, False)
        End If

        SqlText = SqlText & "ORDER BY bh.dt_bolsa_historico "

        oData = DBQuery(SqlText)

        iCont_01 = 0
        iCont_02 = 0
        iCont_03 = 0

        For iCont_01 = 0 To oData.Rows.Count - 1
            bAchou = False

            For iCont_02 = 0 To oData_Chart.Rows.Count - 1
                If oData_Chart.Rows(iCont_02).Item(0) = oData.Rows(iCont_01).Item("dt_bolsa_historico") Then
                    bAchou = True
                    Exit For
                End If
            Next

            If Not bAchou Then
                oData_Chart.Rows.Add()
                iCont_02 = oData_Chart.Rows.Count - 1
                oData_Chart.Rows(iCont_02).Item(0) = oData.Rows(iCont_01).Item("dt_bolsa_historico")
            End If

            For iCont_03 = 1 To oData_Chart.Columns.Count - 1
                If oData_Chart.Columns(iCont_03).Caption = objDataTable_LerCampo(oData.Rows(iCont_01).Item("cod"), 0) Then
                    oData_Chart.Rows(iCont_02).Item(iCont_03) = oData.Rows(iCont_01).Item("vl_cotacao")
                    Exit For
                End If
            Next
        Next

        grfGeral.Hide()

        With grfGeral
            .DataSource = Nothing
            .DataSource = oData_Chart
            .Data.SwapRowsAndColumns = False
        End With

        If objDataTable_Vazio(oData_Chart) Then
            Msg_Mensagem("Essa consulta não retornou nenhum registro")
        Else
            grfGeral.Show()
        End If
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        If Not Data_ValidarPeriodo("data de bolsa", txtDataInicial.Value, txtDataFinal.Value, False) Then
            Msg_Mensagem("Informe um período válido")
            Exit Sub
        End If

        If SelecaoPapel.Lista_Quantidade = 0 Then
            Msg_Mensagem("Informe pelo menos um papel.")
            Exit Sub
        End If

        Dim oForm As New frmAvi

        oForm.StartPosition = FormStartPosition.CenterScreen
        oForm.BackColor = System.Drawing.Color.FromArgb(CType(230, Byte), CType(238, Byte), CType(249, Byte))
        oForm.ShowInTaskbar = False
        oForm.Show()

        CarregaDados()

        oForm.Close()
    End Sub

    Private Sub frmGRF_Bolsa_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Chart_AjustarDimensao(grfGeral, Me.ClientSize)
    End Sub
End Class