Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmREL_Transferencia
    Const cnt_SelecaoOpcao_EmTransito As Integer = 1
    Const cnt_SelecaoOpcao_QuebrarPorModalidade As Integer = 2
    Const cnt_SelecaoOpcao_ExibirMovTransferencia As Integer = 3
    Const cnt_SelecaoOpcao_ExibirMovRecepcao As Integer = 4
    Const cnt_SelecaoOpcao_QuebraMotorista As Integer = 5

    Public Enum RGFP_TipoRelatorio
        Transferencia = 1
        Transferencia_ControleQuebraTransferencias = 2
    End Enum

    Public oTipoRelatorio As RGFP_TipoRelatorio = RGFP_TipoRelatorio.Transferencia
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Dim oData_Rel As DataTable
        Dim sFiltro_01 As String = ""
        Dim sFiltro_02 As String = ""

        Try
            If Not SelecaoOpcao.Lista_Selecionado(cnt_SelecaoOpcao_EmTransito) Then
                If Not Data_ValidarPeriodo("data da transferência", txtDataInicial.Text, txtDataFinal.Text, True) Then
                    Exit Sub
                End If
            End If

            Select Case oTipoRelatorio
                Case RGFP_TipoRelatorio.Transferencia
                    If SelecaoFilialOrigem.Lista_Quantidade > 0 Then
                        sFiltro_02 = "Filial de Origem: " & SelecaoFilialOrigem.Lista_Descricao
                    End If
                    If SelecaoFilialDestino.Lista_Quantidade > 0 Then
                        Str_Adicionar(sFiltro_02, "Filial de Destino: " & SelecaoFilialDestino.Lista_Descricao, " - ")
                    End If
            End Select

            If SelecaoOpcao.Lista_Selecionado(cnt_SelecaoOpcao_EmTransito) Then
                sFiltro_01 = "Em Trânsito na Data " & txtDataInicial.Text
            Else
                If optUtilizarDataCriacaoTransferencia.Checked Then
                    sFiltro_01 = "Utilizar data de criação da Transferência"
                Else
                    sFiltro_01 = "Utilizar data de chegada da Transferência"
                End If

                Str_Adicionar(sFiltro_01, "Período da Transferência: " & txtDataInicial.Text & " à " & txtDataFinal.Text, " - ")
            End If

            oData_Rel = Gera_Rs_Transferencia(oTipoRelatorio, _
                                              txtDataInicial.Text, txtDataFinal.Text, _
                                              SelecaoOpcao.Lista_Selecionado(cnt_SelecaoOpcao_EmTransito), _
                                              optUtilizarDataCriacaoTransferencia.Checked, _
                                              optUtilizarDataChegadaTransferencia.Checked, _
                                              SelecaoFilialOrigem.Lista_ID, _
                                              SelecaoFilialDestino.Lista_ID)

            Select Case oTipoRelatorio
                Case RGFP_TipoRelatorio.Transferencia
                    oRelatorio.Load(Application.StartupPath & "\RPT_Transferencia_Data.rpt")
                    oRelatorio.SetDataSource(oData_Rel)
                    oRelatorio.SetParameterValue("IC_QUEBRA_MODALIDADE", IIf(SelecaoOpcao.Lista_Selecionado(cnt_SelecaoOpcao_QuebrarPorModalidade), "S", "N"))
                    oRelatorio.SetParameterValue("Filtro_01", sFiltro_01)
                    oRelatorio.SetParameterValue("Filtro_02", sFiltro_02)
                    oRelatorio.SetParameterValue("IC_EXIBIR_MOV_TRANSFERENCIA", IIf(SelecaoOpcao.Lista_Selecionado(cnt_SelecaoOpcao_ExibirMovTransferencia), "S", "N"))
                    oRelatorio.SetParameterValue("IC_EXIBIR_MOV_RECEBIMENTO", IIf(SelecaoOpcao.Lista_Selecionado(cnt_SelecaoOpcao_ExibirMovRecepcao), "S", "N"))
                Case RGFP_TipoRelatorio.Transferencia_ControleQuebraTransferencias
                    Str_Adicionar(sFiltro_01, sFiltro_02, " - ")

                    oRelatorio.Load(Application.StartupPath & "\RPT_Transferencia_Peso.rpt")
                    oRelatorio.SetDataSource(oData_Rel)
                    oRelatorio.SetParameterValue("Filtro", sFiltro_01)
                    oRelatorio.SetParameterValue("IC_QUEBRA_MOTORISTA", IIf(SelecaoOpcao.Lista_Selecionado(cnt_SelecaoOpcao_QuebrarPorModalidade), "S", "N"))
            End Select

            oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

            crvMain.ReportSource = oRelatorio
        Catch ex As Exception
            Msg_Mensagem(ex.Message)
        End Try
    End Sub

    Private Sub frmREL_Transferencia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Transferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelecaoFilialOrigem.BancoDados_Tabela = "SOF.FILIAL"
        SelecaoFilialOrigem.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilialOrigem.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilialOrigem.BancoDados_Carregar()
        SelecaoFilialDestino.BancoDados_Tabela = "SOF.FILIAL"
        SelecaoFilialDestino.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilialDestino.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilialDestino.BancoDados_Carregar()
        Me.WindowState = FormWindowState.Maximized

        Select Case oTipoRelatorio
            Case RGFP_TipoRelatorio.Transferencia
                SelecaoOpcao.Lista_Adicionar(New Object() {cnt_SelecaoOpcao_EmTransito, _
                                                           cnt_SelecaoOpcao_ExibirMovRecepcao, _
                                                           cnt_SelecaoOpcao_ExibirMovTransferencia, _
                                                           cnt_SelecaoOpcao_QuebrarPorModalidade}, _
                                             New Object() {"Em Trânsito", _
                                                           "Exibir Mov. de Recepção", _
                                                           "Exibir Mov. de Transferência", _
                                                           "Quebrar Por Modalidade"}, False)
                SelecaoOpcao.Lista_Selecionar(cnt_SelecaoOpcao_ExibirMovRecepcao, True)
                SelecaoOpcao.Lista_Selecionar(cnt_SelecaoOpcao_ExibirMovTransferencia, True)
            Case RGFP_TipoRelatorio.Transferencia_ControleQuebraTransferencias
                Me.Text = "Relatório de Controle de Quebra em Transferências"

                SelecaoOpcao.Lista_Adicionar(New Object() {cnt_SelecaoOpcao_EmTransito, _
                                                           cnt_SelecaoOpcao_QuebraMotorista}, _
                                             New Object() {"Em Trânsito", _
                                                           "Quebrar por Motorista"}, False)
        End Select
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub frmREL_Transferencia_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub chkEmTransito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtDataFinal.Visible = (Not SelecaoOpcao.Lista_Selecionado(cnt_SelecaoOpcao_EmTransito))
        grdData.Visible = (Not SelecaoOpcao.Lista_Selecionado(cnt_SelecaoOpcao_EmTransito))
    End Sub
End Class