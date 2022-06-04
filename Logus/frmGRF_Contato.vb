Imports Infragistics.UltraChart.Shared.Styles

Public Class frmGRF_Contato
    Private Sub frmGRF_Contato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Filial(cboFilial, True)
        ComboBox_Carregar_Tipo_Contato(cboTipoContato, True)
        ComboBox_Carregar_Usuario(cboUsuario, , True)

        Me.WindowState = FormWindowState.Maximized

        objChart_Formatar(grfGeral, ChartType.StackColumnChart, False)

        Dim oForm As frmChart_Propriedade

        oForm = Me.MdiParent
        oForm.Carregar(grfGeral)

        optGrupamento.CheckedIndex = 0
    End Sub

    Private Sub cmdFechar_Grafico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar_Grafico.Click
        Dim oForm As frmChart_Propriedade

        oForm = Me.MdiParent
        oForm.Close()
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        If Not Data_ValidarPeriodo("data do contato", txtdt_escala_ini.Value, txtdt_escala_fim.Value, False) Then
            Msg_Mensagem("Informe um período válido")
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

    Private Sub frmGRF_Contato_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Chart_AjustarDimensao(grfGeral, Me.ClientSize)
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

        Select Case optGrupamento.Value
            Case "F"
                SqlText = "SELECT DISTINCT FIL.CD_FILIAL AS COD, FIL.NO_FILIAL AS NOME "
            Case "T"
                SqlText = "SELECT DISTINCT TA.CD_TIPO_ATENDIMENTO AS COD, TA.NO_TIPO_ATENDIMENTO AS NOME "
            Case "U"
                SqlText = "SELECT DISTINCT U.CD_USER AS COD, U.NO_USUARIO AS NOME "
        End Select

        SqlText = SqlText & _
                  "  FROM SOF.ATENDIMENTO A, " & _
                         "SOF.USUARIO U, " & _
                         "SOF.FORNECEDOR F, " & _
                         "SOF.TIPO_ATENDIMENTO TA," & _
                         "SOF.FILIAL FIL" & _
                  " WHERE A.CD_FILIAL = FIL.CD_FILIAL" & _
                    " AND A.CD_USER = U.CD_USER" & _
                    " AND A.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND A.CD_TIPO_ATENDIMENTO = TA.CD_TIPO_ATENDIMENTO"

        If ComboBox_LinhaSelecionada(cboUsuario) Then
            SqlText = SqlText & _
                    " AND U.CD_USER= " & QuotedStr(cboUsuario.SelectedValue)
        End If
        If ComboBox_LinhaSelecionada(cboTipoContato) Then
            SqlText = SqlText & _
                    " AND TA.CD_TIPO_ATENDIMENTO = " & cboTipoContato.SelectedValue
        End If
        If ComboBox_LinhaSelecionada(cboFilial) Then
            SqlText = SqlText & _
                    " AND FIL.CD_FILIAL = " & cboFilial.SelectedValue
        End If
        If IsDate(txtdt_escala_ini.Value) Then
            SqlText = SqlText & _
                    " AND A.DT_ATENDIMENTO  >= " & Date_to_Oracle(txtdt_escala_ini.Value, , DataFormato.eInicioDia, False)
        End If
        If IsDate(txtdt_escala_fim.Value) Then
            SqlText = SqlText & _
                    " AND A.DT_ATENDIMENTO  <= " & Date_to_Oracle(txtdt_escala_fim.Value, , DataFormato.eFimDia, False)
        End If

        oData = DBQuery(SqlText)

        For iCont_01 = 0 To oData.Rows.Count - 1
            oColuna = New System.Data.DataColumn

            oColuna.ColumnName = objDataTable_LerCampo(oData.Rows(iCont_01).Item("nome"), "-")
            oColuna.Caption = objDataTable_LerCampo(oData.Rows(iCont_01).Item("cod"), "0")
            oColuna.DataType = System.Type.GetType("System.Double")

            oData_Chart.Columns.Add(oColuna)
        Next

        Select Case optGrupamento.Value
            Case "F"
                SqlText = "SELECT DISTINCT FIL.CD_FILIAL AS COD, COUNT(*) AS QUANT "
            Case "T"
                SqlText = "SELECT DISTINCT TA.CD_TIPO_ATENDIMENTO AS COD, COUNT(*) AS QUANT  "
            Case "U"
                SqlText = "SELECT DISTINCT U.CD_USER AS COD, COUNT(*) AS QUANT  "
        End Select

        SqlText = SqlText & _
                            " FROM SOF.ATENDIMENTO A," & _
                                  "SOF.USUARIO U," & _
                                  "SOF.FORNECEDOR F," & _
                                  "SOF.TIPO_ATENDIMENTO TA," & _
                                  "SOF.FILIAL FIL" & _
                            " WHERE A.CD_FILIAL = FIL.CD_FILIAL" & _
                              " AND A.CD_USER = U.CD_USER" & _
                              " AND A.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                              " AND A.CD_TIPO_ATENDIMENTO = TA.CD_TIPO_ATENDIMENTO"

        If ComboBox_LinhaSelecionada(cboUsuario) Then
            SqlText = SqlText & _
                    " AND U.CD_USER = " & QuotedStr(cboUsuario.SelectedValue)
        End If
        If ComboBox_LinhaSelecionada(cboTipoContato) Then
            SqlText = SqlText & _
                    " AND TA.CD_TIPO_ATENDIMENTO = " & cboTipoContato.SelectedValue
        End If
        If ComboBox_LinhaSelecionada(cboFilial) Then
            SqlText = SqlText & _
                    " AND FIL.CD_FILIAL = " & cboFilial.SelectedValue
        End If

        If IsDate(txtdt_escala_ini.Value) Then
            SqlText = SqlText & _
                    " AND A.DT_ATENDIMENTO  >= " & Date_to_Oracle(txtdt_escala_ini.Value, , DataFormato.eInicioDia, False)
        End If
        If IsDate(txtdt_escala_fim.Value) Then
            SqlText = SqlText & _
                    " AND A.DT_ATENDIMENTO  <= " & Date_to_Oracle(txtdt_escala_fim.Value, , DataFormato.eFimDia, False)
        End If

        Select Case optGrupamento.Value
            Case "F"
                SqlText = SqlText & " GROUP BY FIL.CD_FILIAL "
            Case "T"
                SqlText = SqlText & " GROUP BY TA.CD_TIPO_ATENDIMENTO"
            Case "U"
                SqlText = SqlText & " GROUP BY U.CD_USER"
        End Select

        oData = DBQuery(SqlText)

        iCont_01 = 0
        iCont_02 = 0
        iCont_03 = 0

        For iCont_01 = 0 To oData.Rows.Count - 1
            bAchou = False

            For iCont_02 = 0 To oData_Chart.Rows.Count - 1
                If oData_Chart.Rows(iCont_02).Item(0) = oData.Rows(iCont_01).Item("cod") Then
                    bAchou = True
                    Exit For
                End If
            Next

            If Not bAchou Then
                oData_Chart.Rows.Add()
                iCont_02 = oData_Chart.Rows.Count - 1
                oData_Chart.Rows(iCont_02).Item(0) = oData.Rows(iCont_01).Item("cod")
            End If

            For iCont_03 = 1 To oData_Chart.Columns.Count - 1
                If oData_Chart.Columns(iCont_03).Caption = objDataTable_LerCampo(oData.Rows(iCont_01).Item("cod"), 0) Then
                    oData_Chart.Rows(iCont_02).Item(iCont_03) = oData.Rows(iCont_01).Item("quant")
                    Exit For
                End If
            Next
        Next

        grfGeral.Hide()

        With grfGeral
            .DataSource = Nothing
            .DataSource = oData_Chart
            .Data.SwapRowsAndColumns = True
        End With

        If objDataTable_Vazio(oData_Chart) Then
            Msg_Mensagem("Essa consulta não retornou nenhum registro")
        Else
            grfGeral.Show()
        End If
    End Sub
End Class