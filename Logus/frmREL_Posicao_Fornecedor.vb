Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_Posicao_Fornecedor
    Dim oRelatorio As New CrystalReportDocument

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Dim SqlText As String
        Dim CD_FORNECEDOR As Integer

        On Error GoTo Erro

        If Pesq_Fornecedor.Codigo = 0 Then
            Msg_Mensagem("Favor selecionar um fornecedor válido.")
            Exit Sub
        End If

        CD_FORNECEDOR = Pesq_Fornecedor.Codigo

        'Válida se o usuário é de alguma das filiais do usuário
        SqlText = "SELECT COUNT(*) QT" & _
                  " FROM SOF.FORNECEDOR" & _
                  " WHERE CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")" & _
                    " AND CD_FORNECEDOR =" & CD_FORNECEDOR

        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Este fornecedor não pertence a nenhuma de suas filiais.")
            Exit Sub
        End If

        If Not txtDolar.Value > 0 Then
            Msg_Mensagem("Favor informar uma taxa de dolar.")
            Exit Sub
        End If
        If Not txtBolsa.Value > 0 Then
            Msg_Mensagem("Favor informar um valor da bolsa.")
            Exit Sub
        End If
        If Not txtValorArroba.Value > 0 Then
            Msg_Mensagem("Favor informar um valor medio do dia.")
            Exit Sub
        End If

        AVI_Carregar(Me)

        oRelatorio = Gera_Relatorio_PosicaoFornecedor(txtBolsa.Value, _
                                                      txtDolar.Value, _
                                                      txtValorArroba.Value, _
                                                      IIf(optTipo.Value = "TI", True, False), _
                                                      (SelecaoSafra.Lista_Quantidade <> 0), _
                                                      SelecaoSafra.Lista_ID, _
                                                      CD_FORNECEDOR, _
                                                      chkTodosContratosAberto.Checked, _
                                                      (optTipo.Value = "TI"))

        Pesq_Fornecedor.Codigo = CD_FORNECEDOR

        AVI_Fechar(Me)

        crvMain.ReportSource = oRelatorio

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub frmREL_Posicao_Fornecedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_Posicao_Fornecedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        With SelecaoSafra
            .BancoDados_Tabela = "SOF.SAFRA"
            .BancoDados_Campo_Codigo = "CD_SAFRA"
            .BancoDados_Campo_Descricao = "DS_SAFRA"
            .BancoDados_Carregar()
        End With

        Me.WindowState = FormWindowState.Maximized
        Pega_Valores()
    End Sub

    Private Sub frmREL_Posicao_Fornecedor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Pega_Valores()
    End Sub

    Private Sub Pega_Valores()
        Dim DT_COTACAO As Date
        Dim TX_DOLAR As Double
        Dim VL_BOLSA As Double
        Dim VL_ARROBA As Double

        Relatorio_PegaValor(DT_COTACAO, TX_DOLAR, VL_BOLSA, VL_ARROBA)

        txtDolar.Value = TX_DOLAR
        txtBolsa.Value = VL_BOLSA
        txtValorArroba.Value = VL_ARROBA
    End Sub
End Class