Imports CrystalDecisions.CrystalReports.Engine

Public Class frmREL_MovBancaria_PorOperacao
    Const cnt_TipoFilial_Pagadora As Integer = 0
    Const cnt_TipoFilial_Debitada As Integer = 1
    Dim oRelatorio As New CrystalReportDocument

    Private Sub frmREL_MovBancaria_PorOperacao_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        objCRView_Finalizar(oRelatorio)
    End Sub

    Private Sub frmREL_MovBancaria_PorOperacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '>> Carregamento do combo de Tipo de Filial
        With cboTipoFilial
            .Items.Add("Pagadora")
            .Items.Add("Debitada")
        End With

        With SelecaoOperacaoBancaria
            .BancoDados_Tabela = "(SELECT * FROM SOF.OPERACAO_BANCARIA WHERE IC_ATIVO = 'S')"
            .BancoDados_Campo_Codigo = "CD_OPERACAO_BANCARIA"
            .BancoDados_Campo_Descricao = "NO_OPERACAO"
            .BancoDados_Carregar()
        End With
        With SelecaoFilial
            .BancoDados_Tabela = "SOF.FILIAL"
            .BancoDados_Campo_Codigo = "CD_FILIAL"
            .BancoDados_Campo_Descricao = "NO_FILIAL"
            .BancoDados_Carregar()
        End With
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmREL_MovBancaria_PorOperacao_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Form_CrystalReport_AjustarView(Me, crvMain)
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub Imprimir()
        Dim oData As DataTable
        Dim SqlText As String
        Dim sFiltro As String = ""

        If Not Data_ValidarPeriodo("de Movimentação", txtDataInicial.Value, txtDataFinal.Value, True) Then
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboTipoFilial) Then
            Msg_Mensagem("Favor escolher o tipo de filial.")
            Exit Sub
        End If

        If SelecaoOperacaoBancaria.Lista_Quantidade <= 0 Then
            Msg_Mensagem("Favor informar uma operação bancaria.")
            Exit Sub
        End If


        AVI_Carregar(Me)

        SqlText = "SELECT MOV_BANCARIO.SQ_MOV_BANCARIO," & _
                         "MOV_BANCARIO.DT_MOVIMENTACAO, " & _
                         "MOV_BANCARIO.CD_BANCO," & _
                         "MOV_BANCARIO.NU_CHEQUE, " & _
                         "ITEM_MOV_BANCARIO.NO_FAVORECIDO," & _
                         "ITEM_MOV_BANCARIO.VL_PAGO," & _
                         "ITEM_MOV_BANCARIO.VL_BRUTO," & _
                         "OPERACAO_BANCARIA.CD_OPERACAO_BANCARIA," & _
                         "OPERACAO_BANCARIA.NO_OPERACAO," & _
                         "OPERACAO_BANCARIA.VL_SUB_ALIQ_1," & _
                         "OPERACAO_BANCARIA.NO_SUB_ALIQ_1," & _
                         "OPERACAO_BANCARIA.VL_SUB_ALIQ_2," & _
                         "OPERACAO_BANCARIA.NO_SUB_ALIQ_2," & _
                         "FILIAL.CD_FILIAL," & _
                         "FILIAL.NO_FILIAL" & _
                  " FROM SOF.ITEM_MOV_BANCARIO," & _
                        "SOF.MOV_BANCARIO," & _
                        "SOF.OPERACAO_BANCARIA," & _
                        "SOF.FILIAL" & _
                  " WHERE ITEM_MOV_BANCARIO.SQ_MOV_BANCARIO = MOV_BANCARIO.SQ_MOV_BANCARIO" & _
                    " AND ITEM_MOV_BANCARIO.CD_OPERACAO_BANCARIA = SOF.OPERACAO_BANCARIA.CD_OPERACAO_BANCARIA" & _
                    " AND MOV_BANCARIO.DT_MOVIMENTACAO BETWEEN " & QuotedStr(Date_to_Oracle(txtDataInicial.Value)) & _
                                                         " AND " & QuotedStr(Date_to_Oracle(txtDataFinal.Value)) & _
                    " AND OPERACAO_BANCARIA.CD_OPERACAO_BANCARIA IN (" & SelecaoOperacaoBancaria.Lista_ID & ")"


        If cboTipoFilial.SelectedIndex = cnt_TipoFilial_Pagadora Then
            SqlText = SqlText & " AND ITEM_MOV_BANCARIO.CD_FILIAL_PAGADORA = FILIAL.CD_FILIAL"
        Else
            SqlText = SqlText & " AND ITEM_MOV_BANCARIO.CD_FILIAL_DEBITADA = FILIAL.CD_FILIAL"
        End If


        If cboTipoFilial.SelectedIndex = cnt_TipoFilial_Pagadora Then
            If SelecaoFilial.Lista_Quantidade > 0 Then
                SqlText = SqlText & " AND ITEM_MOV_BANCARIO.CD_FILIAL_PAGADORA IN (" & SelecaoFilial.Lista_ID & ")"
            Else
                SqlText = SqlText & " AND ITEM_MOV_BANCARIO.CD_FILIAL_PAGADORA IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If
        Else
            If SelecaoFilial.Lista_Quantidade > 0 Then
                SqlText = SqlText & " AND ITEM_MOV_BANCARIO.CD_FILIAL_DEBITADA IN (" & SelecaoFilial.Lista_ID & ")"
            Else
                SqlText = SqlText & " AND ITEM_MOV_BANCARIO.CD_FILIAL_DEBITADA IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            End If
        End If

        oData = DBQuery(SqlText)

        sFiltro = "Periodo: De " & txtDataInicial.Value & " ate " & txtDataFinal.Value & " - Data do Sistema: " & DataSistema()

        oRelatorio.Load(Application.StartupPath & "\RPT_Movb_Ope.rpt")

        oRelatorio.SetDataSource(oData)
        oRelatorio.SetParameterValue("Filtro01", sFiltro)
        oRelatorio.SetParameterValue("Rodape", objCRView_MontarRodape())

        crvMain.ReportSource = oRelatorio

        AVI_Fechar(Me)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        Imprimir()
    End Sub
End Class