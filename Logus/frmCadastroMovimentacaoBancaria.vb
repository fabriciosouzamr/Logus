Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmCadastroMovimentacaoBancaria
    Const cnt_GridGeral_Provisao As Integer = 0
    Const cnt_GridGeral_Valor As Integer = 1

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim vlTaxa As Double
    Dim vlMaximo As Double

    Private Sub frmCadastroMovimentacaoBancaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String
        Dim oLista As New ValueList

        optTipo_ValueChanged(Nothing, Nothing)
        ComboBox_Carregar_Conta_Bancaria(cboContaBancaria, True, True)
        ComboBox_Carregar_Filial(cboFilialDebito, True)
        ComboBox_Carregar_Filial(cboFilialPagadora, True)

        objGrid_Inicializar(grdGeral, AllowAddNew.FixedAddRowOnTop, oDS, CellClickAction.EditAndSelectText)

        SqlText = "SELECT CD_PROVISAO, NO_PROVISAO" & _
                  " FROM SOF.PROVISAO" & _
                  " ORDER BY NO_PROVISAO"
        oLista = ValueList_Carregar(SqlText)

        objGrid_Coluna_Add(grdGeral, "Provisão", 220, , True, UltraWinGrid.ColumnStyle.DropDownList, oLista)
        objGrid_Coluna_Add(grdGeral, "Valor", 80, , , ColumnStyle.CurrencyPositive, , cnt_Formato_Valor)
    End Sub

    Private Sub PesquisaMovimentacaoBancaria_Formatar()
        With Pesq_OperacaoBancaria
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_OperacaoBancaria
            .BancoDados_Filtro_Limpar()
            .BancoDados_Filtro_Adicionar("IC_DEBITO_CREDITO = " & QuotedStr(optTipo.Value))
        End With
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        PesquisaMovimentacaoBancaria_Formatar()

        LimpaTela

        Select Case optTipo.Value
            Case "D"
                txtValor.Enabled = True
                Pesq_OperacaoBancaria.Enabled = True
                txtDescricao.Enabled = True
                txtFavorecido.Enabled = True
                grpProvisaoImpostos.Enabled = True
                cboContaBancaria.Enabled = True
                cboFilialDebito.Enabled = True
                cboFilialPagadora.Enabled = True
            Case "C"
                txtValor.Enabled = True
                Pesq_OperacaoBancaria.Enabled = True
                txtDescricao.Enabled = True
                cboContaBancaria.Enabled = True
                cboFilialDebito.Enabled = True
                cboFilialPagadora.Enabled = True
        End Select
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim Parametro(13) As DBParamentro
        Dim SqlText As String
        Dim SqItemMovBancaria As Integer
        Dim iCont As Integer

        If Not ComboBox_LinhaSelecionada(cboFilialPagadora) Then
            Msg_Mensagem("Favor escolher uma filial pagadora.")
            cboFilialPagadora.Focus()
            Exit Sub
        End If
        If FilialFechada(cboFilialPagadora.SelectedValue) Then
            Msg_Mensagem("A Filial está fechada. No momento não é possivel realizar o pagamento.")
            Exit Sub
        End If
        If Pesq_OperacaoBancaria.Codigo <= 0 Then
            Msg_Mensagem("Favor escolher uma operacao bancaria valida.")
            Pesq_OperacaoBancaria.Focus()
            Exit Sub
        End If
        If txtDescricao.Text = "" Then
            Msg_Mensagem("Favor informar uma descrição.")
            txtDescricao.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboFilialDebito) Then
            Msg_Mensagem("Favor escolher uma filial a ser debitada.")
            cboFilialDebito.Focus()
            Exit Sub
        End If
    
        If txtValor.Value <= 0 Then
            Msg_Mensagem("Valor inválido.")
            txtValor.Focus()
            Exit Sub
        End If

        If cboContaBancaria.Enabled = True And Not ComboBox_LinhaSelecionada(cboContaBancaria) Then
            Msg_Mensagem("Favor selecionar uma conta bancaria.")
            cboContaBancaria.Focus()
            Exit Sub
        End If

        If txtValor.Value > VlMaximo Then
            Msg_Mensagem("Valor pago maior que o valor permitido.")
            txtValor.Focus()
            Exit Sub
        End If

        Calcula_Valor()

        DBUsarTransacao = True

        SqlText = DBMontar_SP("SOF.INCLUI_MOV_BANCARIO", False, ":OPE", _
                                                                ":DATA", _
                                                                ":DESCRICAO", _
                                                                ":FAVORECIDO", _
                                                                ":VALOR", _
                                                                ":DC", _
                                                                ":FILDEB", _
                                                                ":VLLIQ", _
                                                                ":VLPROVTOTAL", _
                                                                ":VLBRUTO", _
                                                                ":FILPAG", _
                                                                ":BANCO", _
                                                                ":CDFRETISTA", _
                                                                ":SEQ")

        Parametro(0) = DBParametro_Montar("OPE", Pesq_OperacaoBancaria.Codigo)
        Parametro(1) = DBParametro_Montar("DATA", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime)
        Parametro(2) = DBParametro_Montar("DESCRICAO", txtDescricao.Text)
        Parametro(3) = DBParametro_Montar("FAVORECIDO", txtFavorecido.Text)
        Parametro(4) = DBParametro_Montar("VALOR", txtValor.Value)
        Parametro(5) = DBParametro_Montar("DC", optTipo.Value)
        Parametro(6) = DBParametro_Montar("FILDEB", cboFilialDebito.SelectedValue)
        Parametro(7) = DBParametro_Montar("VLLIQ", txtValorLiquido.Value)
        Parametro(8) = DBParametro_Montar("VLPROVTOTAL", txtValorProvisao.Value)
        Parametro(9) = DBParametro_Montar("VLBRUTO", txtValorBruto.Value)
        Parametro(10) = DBParametro_Montar("FILPAG", cboFilialPagadora.SelectedValue)
        If cboContaBancaria.Enabled = True Then
            Parametro(11) = DBParametro_Montar("BANCO", cboContaBancaria.SelectedValue)
        Else
            Parametro(11) = DBParametro_Montar("BANCO", Nothing)
        End If
        Parametro(12) = DBParametro_Montar("CDFRETISTA", Nothing)
        Parametro(13) = DBParametro_Montar("SEQ", Nothing, , ParameterDirection.Output)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        If DBTeveRetorno() Then
            SqItemMovBancaria = DBRetorno(1)
        End If

        For iCont = 0 To grdGeral.Rows.Count - 1
            SqlText = DBMontar_Insert("ITEM_MOV_BANCARIO_PROVISAO", TipoCampoFixo.Todos, _
                                                                    "SQ_ITEM_MOV_BANCARIO", ":SQ_ITEM_MOV_BANCARIO", _
                                                                    "SQ_ITEM_MOV_BANCARIO_PROVISAO", ":SQ_ITEM_MOV_BANCARIO_PROVISAO", _
                                                                    "CD_PROVISAO", ":CD_PROVISAO", _
                                                                    "VL_PROVISAO", ":VL_PROVISAO")
            If Not DBExecutar(SqlText, DBParametro_Montar("SQ_ITEM_MOV_BANCARIO", SqItemMovBancaria), _
                                       DBParametro_Montar("SQ_ITEM_MOV_BANCARIO_PROVISAO", iCont + 1), _
                                       DBParametro_Montar("CD_PROVISAO", grdGeral.Rows(iCont).Cells(cnt_GridGeral_Provisao).Value), _
                                       DBParametro_Montar("VL_PROVISAO", grdGeral.Rows(iCont).Cells(cnt_GridGeral_Valor).Value)) Then GoTo Erro

        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        optTipo.Value = Nothing

        LimpaTela()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Sub LimpaTela()
        txtValor.Value = 0
        txtValor.Enabled = False
        txtValorBruto.Value = 0
        txtValorLiquido.Value = 0
        txtValorProvisao.Value = 0
        Pesq_OperacaoBancaria.Codigo = 0
        Pesq_OperacaoBancaria.Enabled = False
        txtDescricao.Text = ""
        txtDescricao.Enabled = False
        txtFavorecido.Text = ""
        txtFavorecido.Enabled = False
        oDS.Rows.Clear()
        grpProvisaoImpostos.Enabled = False
        cboContaBancaria.Enabled = False

        vlTaxa = 0
        vlMaximo = 0

        ComboBox_Possicionar(cboContaBancaria, -1)
        ComboBox_Possicionar(cboFilialDebito, FilialLogada)
        ComboBox_Possicionar(cboFilialPagadora, FilialLogada)
    End Sub

    Sub Calcula_Valor()
        Dim iCont As Integer

        txtValorProvisao.Value = 0

        For iCont = 0 To grdGeral.Rows.Count - 1
            If Not CampoNulo(grdGeral.Rows(iCont).Cells(cnt_GridGeral_Valor).Value) Then
                txtValorProvisao.Value = txtValorProvisao.Value + grdGeral.Rows(iCont).Cells(cnt_GridGeral_Valor).Value
            End If
        Next

        txtValorBruto.Value = (txtValor.Value * (vlTaxa / 100)) + txtValor.Value
        txtValorLiquido.Value = txtValor.Value - txtValorProvisao.Value
    End Sub

    Private Sub txtValor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValor.ValueChanged
        Calcula_Valor()
    End Sub

    Private Sub grdGeral_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdGeral.AfterRowInsert
        Calcula_Valor()
    End Sub

    Private Sub grdGeral_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGeral.AfterRowsDeleted
        Calcula_Valor()
    End Sub

    Private Sub grdGeral_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdGeral.AfterRowUpdate
        Calcula_Valor()
    End Sub

    Private Sub grdGeral_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdGeral.BeforeRowsDeleted
        e.DisplayPromptMsg = False

        If Not Msg_Perguntar("Deseja excluir a provisão?") Then
            e.Cancel = True
        End If
    End Sub

    Private Sub grdGeral_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles grdGeral.BeforeRowUpdate
        If Trim(NuloParaString(e.Row.Cells(cnt_GridGeral_Provisao).Value)) = "" Then
            Msg_Mensagem("Informe a provisão")
            e.Cancel = True
        End If
        If NuloParaValor(e.Row.Cells(cnt_GridGeral_Valor).Value) <= 0 Then
            Msg_Mensagem("Informe o valor")
            e.Cancel = True
        End If
    End Sub

    Private Sub Pesq_OperacaoBancaria_AlterouRegistro() Handles Pesq_OperacaoBancaria.AlterouRegistro
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "SELECT NO_OPERACAO," & _
                         "NVL(CD_FILIAL_DEBITADA_DEFAULT,-1) CD_FILIAL, " & _
                         "VL_ALIQ_CHEIA_ACRESCENTAR," & _
                         "IC_EMITE_CHEQUE," & _
                         "VL_MAXIMO_PAGAMENTO" & _
                  " FROM SOF.OPERACAO_BANCARIA " & _
                  " WHERE CD_OPERACAO_BANCARIA=" & Pesq_OperacaoBancaria.Codigo
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            ComboBox_Possicionar(cboFilialDebito, oData.Rows(0).Item("CD_FILIAL"))

            vlTaxa = CDbl(NVL(oData.Rows(0).Item("VL_ALIQ_CHEIA_ACRESCENTAR"), 0))
            vlMaximo = oData.Rows(0).Item("VL_MAXIMO_PAGAMENTO")

            If optTipo.Value = "D" Then
                If oData.Rows(0).Item("IC_EMITE_CHEQUE") = "S" Then
                    txtFavorecido.Enabled = True
                    ComboBox_Possicionar(cboContaBancaria, -1)
                    cboContaBancaria.Enabled = False
                    grpProvisaoImpostos.Enabled = True
                Else
                    txtFavorecido.Text = ""
                    txtFavorecido.Enabled = False
                    cboContaBancaria.Enabled = True
                    oDS.Rows.Clear()
                    grpProvisaoImpostos.Enabled = False
                End If
            End If

            Calcula_Valor()
        End If
    End Sub


End Class