Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Movimentacao_Sacaria
    Dim oRelatorio As New CrystalReportDocument

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        Select Case optTipo.Value
            Case "FI"
                lblR_Titulo.Text = "Filial"
                Pesq_Fornecedor.Visible = False
                cboFilial.Visible = True
                cboFilial.Top = Pesq_Fornecedor.Top
                cboFilial.Left = Pesq_Fornecedor.Left
            Case "FO"
                lblR_Titulo.Text = "Fornecedor"
                Pesq_Fornecedor.Visible = True
                cboFilial.Visible = False
        End Select
    End Sub

    Private Sub frmREL_Movimentacao_Sacaria_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Movimentacao_Sacaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        ComboBox_Carregar_Filial(cboFilial, True)
        optTipo.CheckedIndex = 0
        optTipo_ValueChanged(Nothing, Nothing)

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Imprimir()
        Dim oRelatorio_Sub1 As New ReportDocument
        Dim oRelatorio_Sub2 As New ReportDocument
        Dim oData As DataTable
        Dim oData_Sub1 As DataTable
        Dim oData_Sub2 As DataTable
        Dim SqlText As String = ""
        Dim sFiltro As String = ""

        If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, True) Then Exit Sub
        sFiltro = "Período de " & txtDataInicial.Value & " e " & txtDataFinal.Value

        AVI_Carregar(Me)

        If optTipo.Value = "FI" Then

            SqlText = "SELECT FIL.CD_FILIAL," & _
                     "FIL.NO_FILIAL," & _
                     "SFIL.DT_MOVIMENTACAO," & _
                     "SFIL.IC_ENTRADA_SAIDA," & _
                     "SFIL.NU_DOCUMENTO," & _
                     "DECODE(F.NO_RAZAO_SOCIAL,NULL,FM.NO_RAZAO_SOCIAL,F.NO_RAZAO_SOCIAL) NO_FORN," & _
                     "DECODE(FILOT.NO_FILIAL,NULL,FILOTM.NO_FILIAL,FILOT.NO_FILIAL) NO_FILIAL_OT," & _
                     "DECODE(FILDT.NO_FILIAL,NULL,FILDTM.NO_FILIAL,FILDT.NO_FILIAL) NO_FILIAL_DT," & _
                     "TS.NO_TIPO_SACARIA," & _
                     "DECODE(SFIL.IC_ENTRADA_SAIDA,'E',SFIL.QT_SACOS,-1*SFIL.QT_SACOS) QT_SACOS," & _
                     "DECODE(F.NO_RAZAO_SOCIAL,NULL,FM.CD_FILIAL_ORIGEM,F.CD_FILIAL_ORIGEM) CD_FILIAL_O," & _
                     "TM.NO_TIPO_MOVIMENTACAO" & _
              " FROM SOF.FILIAL FIL," & _
                    "SOF.SACARIA_FILIAL SFIL," & _
                    "SOF.SACARIA_TRANSFERENCIA STO," & _
                    "SOF.FILIAL FILOT," & _
                    "SOF.SACARIA_FORNECEDOR SF," & _
                    "SOF.FORNECEDOR F," & _
                    "SOF.SACARIA_TRANSFERENCIA STD," & _
                    "SOF.FILIAL FILDT," & _
                    "SOF.TIPO_SACARIA TS," & _
                    "SOF.MOVIMENTACAO M," & _
                    "SOF.FORNECEDOR FM," & _
                    "SOF.TRANSFERENCIA T," & _
                    "SOF.FILIAL FILDTM," & _
                    "SOF.FILIAL FILOTM," & _
                    "SOF.SACARIA_TIPO_MOVIMENTACAO TM" & _
                      " WHERE FIL.CD_FILIAL = SFIL.CD_FILIAL_CREDITO" & _
                        " AND SFIL.CD_TIPO_SACARIA = TS.CD_TIPO_SACARIA" & _
                        " AND STO.SQ_SACARIA_FILIAL_REC (+) = SFIL.SQ_SACARIA_FILIAL" & _
                        " AND FILOT.CD_FILIAL (+) = STO.CD_FILIAL_ORIGEM" & _
                        " AND SF.SQ_SACARIA_FORNECEDOR (+) = SFIL.SQ_SACARIA_FORNECEDOR" & _
                        " AND F.CD_FORNECEDOR (+) = SF.CD_FORNECEDOR" & _
                        " AND STD.SQ_SACARIA_FILIAL_ENVIO (+) = SFIL.SQ_SACARIA_FILIAL" & _
                        " AND FILDT.CD_FILIAL (+) = STD.CD_FILIAL_DESTINO" & _
                        " AND M.SQ_MOVIMENTACAO (+) = SFIL.SQ_MOVIMENTACAO" & _
                        " AND FM.CD_FORNECEDOR (+) = M.CD_FORNECEDOR" & _
                        " AND T.SQ_MOVIMENTACAO_entrada (+) = M.SQ_MOVIMENTACAO" & _
                        " AND FILOTM.CD_FILIAL (+) = T.CD_FILIAL_ORIGEM" & _
                        " AND FILDTM.CD_FILIAL (+) = T.CD_FILIAL_DESTINO" & _
                        " AND TM.CD_TIPO_MOVIMENTACAO (+) = SFIL.CD_TIPO_MOVIMENTACAO" & _
                        " AND SFIL.CD_FILIAL_CREDITO =" & cboFilial.SelectedValue & _
                        " AND SFIL.DT_MOVIMENTACAO Between " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & _
                        " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))

            oData = DBQuery(SqlText)

            'SALDO INICIAL
            SqlText = "SELECT SF.CD_FILIAL_CREDITO as CD_FILIAL," & _
                        "TS.NO_TIPO_SACARIA as no_tipo_saco," & _
                        "SUM(DECODE(SF.IC_ENTRADA_SAIDA,'E',SF.QT_SACOS,-1*SF.QT_SACOS)) AS QT_SACOS" & _
                        " FROM SOF.SACARIA_FILIAL SF," & _
                        "SOF.TIPO_SACARIA TS " & _
                        " WHERE SF.CD_TIPO_SACARIA = TS.CD_TIPO_SACARIA" & _
                        " AND SF.DT_MOVIMENTACAO < " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)) & _
                        " AND SF.CD_FILIAL_CREDITO =" & cboFilial.SelectedValue & " " & _
                        " GROUP BY SF.CD_FILIAL_CREDITO, TS.NO_TIPO_SACARIA"

            oData_Sub1 = DBQuery(SqlText)

            SqlText = "SELECT SF.CD_FILIAL_CREDITO as CD_FILIAL," & _
                        "TS.NO_TIPO_SACARIA as no_tipo_saco, " & _
                        "SUM(DECODE(SF.IC_ENTRADA_SAIDA,'E',SF.QT_SACOS,-1*SF.QT_SACOS)) AS QT_SACOS " & _
                        " FROM SOF.SACARIA_FILIAL SF," & _
                        "SOF.TIPO_SACARIA TS " & _
                        " WHERE SF.CD_TIPO_SACARIA = TS.CD_TIPO_SACARIA" & _
                        " AND SF.CD_FILIAL_CREDITO = " & cboFilial.SelectedValue & _
                        " AND SF.DT_MOVIMENTACAO <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)) & _
                        " GROUP BY SF.CD_FILIAL_CREDITO, TS.NO_TIPO_SACARIA"

            oData_Sub2 = DBQuery(SqlText)

            oRelatorio.Load(Application.StartupPath & "\RPT_Movimentacao_Sacaria_Filial.rpt")
            oRelatorio.SetDataSource(oData)
            oRelatorio_Sub1 = oRelatorio.Subreports("CRSacFilSI")
            oRelatorio_Sub1.SetDataSource(oData_Sub1)
            oRelatorio_Sub2 = oRelatorio.Subreports("CRSacFilSF")
            oRelatorio_Sub2.SetDataSource(oData_Sub2)

        Else
            SqlText = "SELECT SF.DT_MOVIMENTACAO, FIL.NO_FILIAL, SF.NU_DOCUMENTO, TS.NO_TIPO_SACARIA, " & _
                        "DECODE(SF.IC_ENTRADA_SAIDA,'E',SF.QT_SACOS,-1*SF.QT_SACOS) QT_SACOS, " & _
                        "F.NO_RAZAO_SOCIAL, F.CD_FORNECEDOR, F.CD_FILIAL_ORIGEM " & _
                        "FROM SOF.SACARIA_FORNECEDOR SF, SOF.TIPO_SACARIA TS, SOF.FORNECEDOR F, " & _
                        "SOF.FILIAL Fil " & _
                        "WHERE SF.CD_TIPO_SACARIA = TS.CD_TIPO_SACARIA AND " & _
                        "SF.CD_FORNECEDOR = F.CD_FORNECEDOR AND " & _
                        "SF.CD_FILIAL_CREDITO = FIL.CD_FILIAL AND " & _
                        "SF.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & " AND " & _
                        "SF.DT_MOVIMENTACAO Between '" & Date_to_Oracle(txtDataInicial.Text) & "' and '" & _
                        Date_to_Oracle(txtDataFinal.Text) & "'"
      
            oData = DBQuery(SqlText)

            If objDataTable_Vazio(oData) Then
                AVI_Fechar(Me)
                Msg_Mensagem("Não existe movimentação neste periodo.")
                Exit Sub
            End If


            SqlText = "SELECT SF.CD_FORNECEDOR, TS.NO_TIPO_SACARIA as NO_TIPO_SACO, " & _
                      "SUM(DECODE(SF.IC_ENTRADA_SAIDA,'E',SF.QT_SACOS,-1*SF.QT_SACOS)) QT_SACOS " & _
                      "FROM SOF.SACARIA_FORNECEDOR SF, SOF.TIPO_SACARIA TS " & _
                      "WHERE SF.CD_TIPO_SACARIA = TS.CD_TIPO_SACARIA AND " & _
                      "SF.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & " AND " & _
                      "SF.DT_MOVIMENTACAO < '" & Date_to_Oracle(txtDataInicial.Text) & "' " & _
                      "GROUP BY SF.CD_FORNECEDOR, TS.NO_TIPO_SACARIA"

            oData_Sub1 = DBQuery(SqlText)

            SqlText = "SELECT SF.CD_FORNECEDOR, TS.NO_TIPO_SACARIA  as NO_TIPO_SACO, " & _
                      "SUM(DECODE(SF.IC_ENTRADA_SAIDA,'E',SF.QT_SACOS,-1*SF.QT_SACOS)) QT_SACOS " & _
                      "FROM SOF.SACARIA_FORNECEDOR SF, SOF.TIPO_SACARIA TS " & _
                      "WHERE SF.CD_TIPO_SACARIA = TS.CD_TIPO_SACARIA AND " & _
                      " SF.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & _
                      " AND SF.DT_MOVIMENTACAO <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)) & _
                      " GROUP BY SF.CD_FORNECEDOR, TS.NO_TIPO_SACARIA"

            oData_Sub2 = DBQuery(SqlText)

            oRelatorio.Load(Application.StartupPath & "\RPT_Movimentacao_Sacaria_Fornecedor.rpt")
            oRelatorio.SetDataSource(oData)
            oRelatorio_Sub1 = oRelatorio.Subreports("CRSacFornSI")
            oRelatorio_Sub1.SetDataSource(oData_Sub1)
            oRelatorio_Sub2 = oRelatorio.Subreports("CRSacFornSF")
            oRelatorio_Sub2.SetDataSource(oData_Sub2)
        End If

        oRelatorio.SetParameterValue("Filtro", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())
        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub frmREL_Movimentacao_Sacaria_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub
End Class