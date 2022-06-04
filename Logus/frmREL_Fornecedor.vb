Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmREL_Fornecedor
    Dim oRelatorio As New CrystalReportDocument
    Dim oData_Rel As New DataTable
    Dim oRelatorio_SubFazenda As New ReportDocument
    Dim oRelatorio_SubAgregado As New ReportDocument
    Dim oRelatorio_SubProcurador As New ReportDocument
    Dim oData_SubFazenda As New DataTable
    Dim oData_SubAgregado As New DataTable
    Dim oData_SubProcurador As New DataTable

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmREL_Fornecedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Fornecedor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Dim oForm As New frmAvi
        oForm.StartPosition = FormStartPosition.CenterScreen
        oForm.BackColor = System.Drawing.Color.FromArgb(CType(230, Byte), CType(238, Byte), CType(249, Byte))
        oForm.ShowInTaskbar = False
        oForm.Show()

        Imprimir()

        oForm.Close()
    End Sub

    Private Sub frmREL_Fornecedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Imprimir()
        Dim SqlText As String
        Dim sFiltro As String = String.Empty

        Try
            SqlText = "SELECT F.CD_FORNECEDOR," & _
                             "F.NO_RAZAO_SOCIAL," & _
                             "F.DS_ENDERECO," & _
                             "F.NO_BAIRRO," & _
                             "M.NO_CIDADE," & _
                             "F.NU_CGC_CPF," & _
                             "F.NU_INSC_ESTADUAL," & _
                             "F.IC_FISICA_JURIDICA," & _
                             "FIL.NO_FILIAL," & _
                             "M.CD_UF," & _
                             "F.CD_ADDRESS_NUMBER," & _
                             "F.CD_REPASSADOR," & _
                             "FO.DS_OBS, F.NU_TEL" & _
                      " FROM SOF.FORNECEDOR F," & _
                            "SOF.FILIAL FIL," & _
                            "SOF.MUNICIPIO M," & _
                            "SOF.FORNECEDOR_OBS FO" & _
                        " WHERE F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                          " AND F.CD_MUNICIPIO = M.CD_MUNICIPIO " & _
                          " AND F.CD_FORNECEDOR = FO.CD_FORNECEDOR (+)"

            Select Case optSelecao.Value
                Case "T"
                    Str_Adicionar(sFiltro, "Seleção: Todos", " - ")
                Case "A"
                    SqlText = SqlText & " AND F.IC_ATIVO = 'S'"

                    Str_Adicionar(sFiltro, "Seleção: Somente Ativos", " - ")
                Case "I"
                    SqlText = SqlText & " AND F.IC_ATIVO = 'N'"

                    Str_Adicionar(sFiltro, "Seleção: Somente Inativos", " - ")
                Case "L"
                    SqlText = SqlText & " AND F.IC_LISTA_NEGRA = 'S'"

                    Str_Adicionar(sFiltro, "Seleção: Na Lista Negra", " - ")
                Case "O"
                    SqlText = SqlText & " AND FO.DS_OBS IS NOT NULL "

                    Str_Adicionar(sFiltro, "Seleção: Com Observação", " - ")
                Case "EA"
                    SqlText = SqlText & " AND F.CD_FORNECEDOR IN (SELECT CD_REPASSADOR" & _
                                                                 " FROM SOF.FORNECEDOR" & _
                                                                 " WHERE CD_REPASSADOR IS NOT NULL)"

                    Str_Adicionar(sFiltro, "Exibir Agregados", " - ")
                Case "EP"
                    Str_Adicionar(sFiltro, "Exibir Procuradores", " - ")
                Case "EF"
                    Str_Adicionar(sFiltro, "Exibir Fazendas", " - ")
            End Select

            If SelecaoFilial.Lista_Quantidade > 0 Then
                SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"

                Str_Adicionar(sFiltro, "Filial: " & SelecaoFilial.Lista_Descricao, " - ")
            Else
                SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"

                ' Str_Adicionar(sFiltro, "Filial: " & ListarIDFiliaisLiberadaUsuario(True), " - ")
            End If

            oData_Rel = DBQuery(SqlText)

            'Sub Relatório Demostrando as Fazendas
            SqlText = "SELECT F.CD_FORNECEDOR," & _
                                 "F.NO_FAZENDA," & _
                                 "F.DS_ENDERECO," & _
                                 "DECODE(M.CD_UF, NULL, NULL, M.NO_CIDADE || ' - ' || M.CD_UF) AS NO_MUNICIPIO" & _
                          " FROM SOF.FAZENDA F, SOF.MUNICIPIO M , SOF.FORNECEDOR FORN" & _
                          " WHERE F.CD_MUNICIPIO = M.CD_MUNICIPIO (+)" & _
                            " AND F.CD_FORNECEDOR = FORN.CD_FORNECEDOR"

            'Filtro Filial
            If SelecaoFilial.Lista_Quantidade > 0 Then
                SqlText = SqlText & " AND FORN.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
            Else
                SqlText = SqlText & " AND FORN.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If
            If optSelecao.Value <> "EF" Then
                SqlText = SqlText & " AND F.CD_FORNECEDOR = -1"
            End If
            oData_SubFazenda = DBQuery(SqlText)

            'Sub Relatório Agregados
            SqlText = "SELECT F.CD_FORNECEDOR," & _
                                 "F.NO_RAZAO_SOCIAL," & _
                                 "F.CD_REPASSADOR" & _
                          " FROM SOF.FORNECEDOR F" & _
                          " WHERE NOT F.CD_REPASSADOR IS NULL"

            If SelecaoFilial.Lista_Quantidade > 0 Then
                SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & SelecaoFilial.Lista_ID & ")"
            Else
                SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If
            If optSelecao.Value <> "EA" Then
                SqlText = SqlText & " AND F.CD_FORNECEDOR = -1"
            End If
            oData_SubAgregado = DBQuery(SqlText)

            'Sub Relatório Procurador
            SqlText = "SELECT FP.CD_FORNECEDOR," & _
                                 "P.NO_RAZAO_SOCIAL," & _
                                 "FP.DT_VALIDADE," & _
                                 "P.CD_FORNECEDOR CD_PROCURADOR" & _
                          " FROM SOF.FORNECEDOR_PROCURACAO FP," & _
                                "SOF.FORNECEDOR P" & _
                         " WHERE FP.CD_FORNECEDOR_PROCURADOR = P.CD_FORNECEDOR"
            If optSelecao.Value <> "EP" Then
                SqlText = SqlText & " AND P.CD_FORNECEDOR = -1"
            End If
            oData_SubProcurador = DBQuery(SqlText)

            oRelatorio.Load(Application.StartupPath & "\RPT_Fornecedor.rpt")

            oRelatorio.SetDataSource(oData_Rel)
            oRelatorio_SubFazenda = oRelatorio.Subreports("Fazenda")
            oRelatorio_SubFazenda.SetDataSource(oData_SubFazenda)
            oRelatorio_SubAgregado = oRelatorio.Subreports("Agregado")
            oRelatorio_SubAgregado.SetDataSource(oData_SubAgregado)
            oRelatorio_SubProcurador = oRelatorio.Subreports("Procurador")
            oRelatorio_SubProcurador.SetDataSource(oData_SubProcurador)

            oRelatorio.SetParameterValue("Exibir_Agregado", IIf(optSelecao.Value = "EA", "S", "N"))
            oRelatorio.SetParameterValue("Exibir_Fazenda", IIf(optSelecao.Value = "EF", "S", "N"))
            oRelatorio.SetParameterValue("Exibir_Procurador", IIf(optSelecao.Value = "EP", "S", "N"))
            oRelatorio.SetParameterValue("Exibir_Observacao", IIf(optSelecao.Value = "O", "S", "N"))
            oRelatorio.SetParameterValue("Filtro", sFiltro)
            oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

            crvMain.ReportSource = oRelatorio
        Catch ex As Exception
            Msg_Mensagem(ex.Message)
        End Try
    End Sub
End Class