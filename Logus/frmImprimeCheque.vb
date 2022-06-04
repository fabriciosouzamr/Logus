Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmImprimeCheque
    Const cnt_GridGeral_Marca As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_Valor As Integer = 2
    Const cnt_GridGeral_Favorecido As Integer = 3
    Const cnt_GridGeral_OperacaoBancaria As Integer = 4
    Const cnt_GridGeral_Descrição As Integer = 5
    Const cnt_GridGeral_ValorProvisao As Integer = 6
    Const cnt_GridGeral_ValorBruto As Integer = 7
    Const cnt_GridGeral_ValorLiquido As Integer = 8
    Const cnt_GridGeral_FilialDebitada As Integer = 9
    Const cnt_GridGeral_FilialPagadora As Integer = 10
    Const cnt_GridGeral_Sequencia As Integer = 11

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmImprimeCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdGeral, "Marca", 50, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Valor", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Favorecido", 160)
        objGrid_Coluna_Add(grdGeral, "Operação Bancaria", 140)
        objGrid_Coluna_Add(grdGeral, "Descrição", 180)
        objGrid_Coluna_Add(grdGeral, "Valor Provisão", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor Bruto", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor Liquido", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Filial Debitada", 120)
        objGrid_Coluna_Add(grdGeral, "Filial pagadora", 120)
        objGrid_Coluna_Add(grdGeral, "Sequência", 80)

        ComboBox_Carregar_Filial(cboFilial)
        ComboBox_Possicionar(cboFilial, FilialLogada)
        ComboBox_Carregar_Conta_Bancaria(cboContaBancaria)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT 0 MARCA," & _
                         "IMB.DT_MOVIMENTACAO," & _
                         "IMB.VL_PAGO," & _
                         "IMB.NO_FAVORECIDO," & _
                         "OB.NO_OPERACAO," & _
                         "IMB.DS_DESCRICAO," & _
                         "IMB.VL_PROVISAO_TOTAL," & _
                         "IMB.VL_BRUTO," & _
                         "IMB.VL_LIQUIDO," & _
                         "FILDEB.NO_FILIAL AS NO_FILDEB," & _
                         "FILPAG.NO_FILIAL AS NO_FILPAG," & _
                         "IMB.SQ_ITEM_MOV_BANCARIO" & _
                  " FROM SOF.ITEM_MOV_BANCARIO IMB," & _
                        "SOF.OPERACAO_BANCARIA OB," & _
                        "SOF.FILIAL FILDEB," & _
                        "SOF.FILIAL FILPAG," & _
                        "SOF.PAGAMENTOS PG," & _
                        "SOF.CONCILIACAO_PAGAMENTO CP" & _
                  " WHERE IMB.CD_FILIAL_PAGADORA = " & cboFilial.SelectedValue & _
                    " AND IMB.SQ_MOV_BANCARIO IS NULL" & _
                    " AND IMB.CD_OPERACAO_BANCARIA = OB.CD_OPERACAO_BANCARIA" & _
                    " AND IMB.CD_FILIAL_DEBITADA = FILDEB.CD_FILIAL" & _
                    " AND IMB.CD_FILIAL_PAGADORA = FILPAG.CD_FILIAL" & _
                    " AND PG.SQ_ITEM_MOV_BANCARIO (+) = IMB.SQ_ITEM_MOV_BANCARIO" & _
                    " AND CP.SQ_PAGAMENTO (+) = PG.SQ_PAGAMENTO" & _
                    " AND CP.SQ_CONCILIACAO IS NULL"
        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Marca, _
                                                           cnt_GridGeral_Data, _
                                                           cnt_GridGeral_Valor, _
                                                           cnt_GridGeral_Favorecido, _
                                                           cnt_GridGeral_OperacaoBancaria, _
                                                           cnt_GridGeral_Descrição, _
                                                           cnt_GridGeral_ValorProvisao, _
                                                           cnt_GridGeral_ValorBruto, _
                                                           cnt_GridGeral_ValorLiquido, _
                                                           cnt_GridGeral_FilialDebitada, _
                                                           cnt_GridGeral_FilialPagadora, _
                                                           cnt_GridGeral_Sequencia})
    End Sub

    Private Sub cboFilial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilial.SelectedIndexChanged
        ValidaFilial()
    End Sub

    Private Sub ValidaFilial()
        If Not ComboBox_LinhaSelecionada(cboFilial) Then
            Exit Sub
        End If

        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT FI.NO_RAZAO," & _
                         "FI.NU_CGC," & _
                         "FI.DS_ENDERECO," & _
                         "MC.NO_CIDADE," & _
                         "MC.CD_UF " & _
                  " FROM SOF.FILIAL FI," & _
                        "SOF.MUNICIPIO MC " & _
                  " WHERE FI.CD_FILIAL=" & cboFilial.SelectedValue & _
                    " AND MC.CD_MUNICIPIO = FI.CD_MUNICIPIO"
        oData = DBQuery(SqlText)

        txtData.Text = oData.Rows(0).Item("NO_CIDADE") & " - " & oData.Rows(0).Item("CD_UF") & ", " & _
                       CDate(DataSistema()).Day & " de " & VerMes(DataSistema) & " de " & CDate(DataSistema()).Year

        ExecutaConsulta()
    End Sub

    Private Sub txtValor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValor.ValueChanged
        If txtValor.Value = 0 Then
            txtValorExtenso.Text = ""
        Else
            txtValorExtenso.Text = Extenso(txtValor.Value, "Reais", "Real")
        End If
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub Calcula_Valor()
        Dim iCont As Integer

        txtValor.Value = 0

        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_Marca, iCont) Then
                txtValor.Value = txtValor.Value + grdGeral.Rows(iCont).Cells(cnt_GridGeral_ValorLiquido).Value
                txtFavorecido.Text = "" & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Favorecido).Value
            End If
        Next
    End Sub

    Private Sub grdGeral_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdGeral.AfterCellUpdate
        Calcula_Valor()
    End Sub

    Private Sub grdGeral_AfterPerformAction(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs) Handles grdGeral.AfterPerformAction
        Me.Text = Now.ToString
        Calcula_Valor()
    End Sub

    Private Sub grdGeral_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdGeral.CellChange
        e.Cell.Row.Update()
        Calcula_Valor()
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro")
            Exit Sub
        End If

        If Not Msg_Perguntar("Elimina o registro?") Then Exit Sub

        On Error GoTo Erro

        Dim SqlText As String

        SqlText = DBMontar_SP("SOF.ELIMINA_ITEM_MOV_BANCO", False, ":SQ_ITEM_MOV_BANCARIO")

        If Not DBExecutar(SqlText, _
                          DBParametro_Montar("SQ_ITEM_MOV_BANCARIO", objGrid_Valor(grdGeral, cnt_GridGeral_Sequencia))) Then GoTo Erro

        ExecutaConsulta()

        Exit Sub

Erro:
        ExecutaConsulta()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If Not ComboBox_LinhaSelecionada(cboContaBancaria) Then
            Msg_Mensagem("Favor selecionar um conta bancaria.")
            cboContaBancaria.Focus()
            Exit Sub
        End If
        If txtNumeroCheque.Value = 0 Then
            Msg_Mensagem("Favor informar um numero de cheque.")
            txtNumeroCheque.Focus()
            Exit Sub
        End If
        If Trim(txtFavorecido.Text) = "" Then
            Msg_Mensagem("Favor informar o nome do favorecido.")
            txtFavorecido.Focus()
            Exit Sub
        End If

        Incluir_Cheque()

        ExecutaConsulta()

        txtValor.Value = 0
        txtNumeroCheque.Value = 0
        txtValorExtenso.Text = ""
        cboContaBancaria.SelectedIndex = -1
        cboContaBancaria_SelectedIndexChanged(Nothing, Nothing)
        txtFavorecido.Text = ""
    End Sub

    Private Function Incluir_Cheque() As Boolean
        Dim bOk As Boolean = False
        Dim iCont As Integer
        Dim SqlText As String
        Dim iRet As Integer
        Dim sMensagem As String = ""
        Dim SQ_MOV_BANCARIO As Long
        Dim sNomeImpressora As String

        On Error GoTo Erro

        If FilialFechada(cboFilial.SelectedValue) Then GoTo Sair
        sNomeImpressora = Registro_Read_String("IMPRESSORA_CHEQUE")

        DBUsarTransacao = True

        SqlText = DBMontar_Function("SOF.INCLUI_CHEQUE", ":CDBANCO", ":CHEQUE", ":DATA", _
                                                         ":FAVORECIDO", ":VALOR", _
                                                         ":DC", ":FILPAG")

        If Not DBExecutar(SqlText, DBParametro_Montar("CDBANCO", cboContaBancaria.SelectedValue), _
                                   DBParametro_Montar("CHEQUE", txtNumeroCheque.Value), _
                                   DBParametro_Montar("DATA", Date_to_Oracle(DataSistema)), _
                                   DBParametro_Montar("FAVORECIDO", Trim(txtFavorecido.Text)), _
                                   DBParametro_Montar("VALOR", txtValor.Value), _
                                   DBParametro_Montar("DC", "D"), _
                                   DBParametro_Montar("FILPAG", cboFilial.SelectedValue), _
                                   DBParametro_Montar("RET", Nothing, , ParameterDirection.ReturnValue)) Then GoTo Erro

        If DBTeveRetorno() Then
            SQ_MOV_BANCARIO = DBRetorno(1)
        End If

        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_Marca, iCont) Then
                SqlText = "UPDATE SOF.ITEM_MOV_BANCARIO" & _
                          " SET SQ_MOV_BANCARIO = " & SQ_MOV_BANCARIO & _
                          " WHERE SQ_ITEM_MOV_BANCARIO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Sequencia, iCont)
                If Not DBExecutar_LinhaAfetadas(SqlText, iRet) Then GoTo Erro

                If iRet = 0 Then
                    sMensagem = sMensagem & vbCrLf & _
                                Trim(objGrid_Valor(grdGeral, cnt_GridGeral_Data)) & " " & _
                                Trim(objGrid_Valor(grdGeral, cnt_GridGeral_Favorecido)) & " - " & _
                                Trim(objGrid_Valor(grdGeral, cnt_GridGeral_Descrição)) & " - " & _
                                Trim(objGrid_Valor(grdGeral, cnt_GridGeral_Valor))
                End If
            End If
        Next

        If Trim(sMensagem) <> "" Then
            DBUsarTransacao = False

            sMensagem = "Os itens do cheque, listados abaixo foram excluídos do banco. Essa operação será cancelada" & _
                        vbCrLf & sMensagem

            Msg_Perguntar(sMensagem)
        End If

        SqlText = DBMontar_SP("SOF.MOV_BANCO_RD", False, ":CQ", ":DATA")

        If Not DBExecutar(SqlText, DBParametro_Montar("CQ", SQ_MOV_BANCARIO), _
                                   DBParametro_Montar("DATA", Date_to_Oracle(DataSistema))) Then GoTo ERRO

        If Not DBExecutarTransacao() Then GoTo Erro

        If Msg_Perguntar("Emite o cheque? " & IIf(sNomeImpressora <> "", "O cheque será impresso em: " & sNomeImpressora, "")) Then
            Cheque_Imprimir(SQ_MOV_BANCARIO)
        End If

        If Msg_Perguntar("Emite o Voucher") Then
            Dim oRel As New frmRelatorioGeral

            oRel.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eVoucher
            oRel.Filtro01 = SQ_MOV_BANCARIO
            Form_Show(Nothing, oRel)
        End If

Sair:
        Return bOk

        Exit Function

Erro:
        TratarErro()
    End Function

    Private Sub cboContaBancaria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContaBancaria.SelectedIndexChanged
        Dim SqlText As String

        If Not ComboBox_LinhaSelecionada(cboContaBancaria) Then
            txtNumeroCheque.Value = 0
            Exit Sub
        End If

        SqlText = "SELECT NVL(NU_ULTIMO_CHEQUE,0) + 1 AS CHEQUE" & _
                  " FROM SOF.BANCO" & _
                  " WHERE CD_BANCO=" & cboContaBancaria.SelectedValue

        txtNumeroCheque.Value = DBQuery_ValorUnico(SqlText, 0)
    End Sub

    Private Sub grdGeral_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdGeral.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdGeral.PerformAction(UltraGridAction.ExitEditMode)
        End If
    End Sub

    Private Sub cmdLimpaImpressora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpaImpressora.Click
        If Registro_Write_String("IMPRESSORA_CHEQUE", "") Then
            Msg_Mensagem("Impressora de cheque limpa. Na proxima impressão será solicitada a nova impressora")
        Else
            Msg_Mensagem("Não havia impressora selecionada.")
        End If
    End Sub
End Class