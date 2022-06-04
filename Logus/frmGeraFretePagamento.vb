Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmGeraFretePagamento

    Const cnt_GridGeral_Marca As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_ValorUnitario As Integer = 2
    Const cnt_GridGeral_Volume As Integer = 3
    Const cnt_GridGeral_OD As Integer = 4
    Const cnt_GridGeral_Total As Integer = 5
    Const cnt_GridGeral_TipoFrete As Integer = 6
    Const cnt_GridGeral_FilialPagadora As Integer = 7
    Const cnt_GridGeral_FilialMovimentacao As Integer = 8
    Const cnt_GridGeral_Fornecedor As Integer = 9
    Const cnt_GridGeral_Municipio As Integer = 10
    Const cnt_GridGeral_NF As Integer = 11
    Const cnt_GridGeral_Codigo As Integer = 12

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmGeraFretePagamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PesquisaMovimentacaoBancaria_Formatar()
        PesquisaFretista_Formatar()
        ComboBox_Carregar_Filial(cboFilialPagadora, True)

        ComboBox_Possicionar(cboFilialPagadora, FilialLogada)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdGeral, "Marca", 50, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Valor Unitario", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Volumes", 80)
        objGrid_Coluna_Add(grdGeral, "O.D.", 50)
        objGrid_Coluna_Add(grdGeral, "Total", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Tipo Frete", 120)
        objGrid_Coluna_Add(grdGeral, "Filial Pagadora", 120)
        objGrid_Coluna_Add(grdGeral, "Filial Movintação", 120)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 180)
        objGrid_Coluna_Add(grdGeral, "Município", 100)
        objGrid_Coluna_Add(grdGeral, "NF", 70)
        objGrid_Coluna_Add(grdGeral, "Código", 0)
    End Sub

    Private Sub PesquisaMovimentacaoBancaria_Formatar()
        With Pesq_OperacaoBancaria
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_OperacaoBancaria
            .BancoDados_Filtro_Limpar()
            .BancoDados_Filtro_Adicionar("IC_DEBITO_CREDITO = 'D'")
        End With
    End Sub
    Private Sub PesquisaFretista_Formatar()
        With Pesq_Fretista
            .Codigo = 0
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Freista
        End With
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        If Pesq_Fretista.Codigo <= 0 Then
            Msg_Mensagem("Favor informar um fretista.")
            Pesq_Fretista.Focus()
            Exit Sub
        End If

        txtValor.Value = 0

        SqlText = "SELECT 0 as MARCA, " & _
                         "F.DT_FRETE," & _
                         "F.VL_UNITARIO," & _
                         "F.QT_VOLUME," & _
                         "OD.CD_ORDEM_DESCARGA," & _
                         "F.VL_TOTAL," & _
                         "TF.NO_TIPO_FRETE," & _
                         "FIL.NO_FILIAL," & _
                         "FM.NO_FILIAL NO_FILIAL_MOVIMENTACAO," & _
                         "FORN.NO_RAZAO_SOCIAL," & _
                         "MUNIC.NO_CIDADE || ' - ' || MUNIC.CD_UF AS NO_CIDADE," & _
                         "M.NU_NF," & _
                         " F.SQ_FRETE" & _
                  " FROM SOF.MUNICIPIO MUNIC," & _
                        "SOF.FRETE F," & _
                        "SOF.FRETISTA FRT," & _
                        "SOF.TIPO_FRETE TF," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.MOVIMENTACAO M," & _
                        "SOF.FORNECEDOR FORN," & _
                        "SOF.FRETE_PERCURSO FP," & _
                        "SOF.ORDEM_DESCARGA OD," & _
                        "SOF.TRANSFERENCIA_SUMMUS TS," & _
                        "SOF.FILIAL FM" & _
                  " WHERE f.dt_exclusao is null and F.CD_FRETISTA = FRT.CD_FRETISTA" & _
                    " AND F.CD_TIPO_FRETE = TF.CD_TIPO_FRETE" & _
                    " AND F.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND F.CD_FILIAL_ORIGEM=" & FilialLogada & _
                    " AND F.CD_FRETISTA=" & Pesq_Fretista.Codigo & _
                    " AND F.SQ_FRETE_PAGAMENTO IS NULL" & _
                    " AND NVL(F.IC_PAGO_MANUAL,'N') ='N' " & _
                    " AND M.SQ_MOVIMENTACAO (+) = F.SQ_MOVIMENTACAO" & _
                    " AND FORN.CD_FORNECEDOR (+) = M.CD_FORNECEDOR" & _
                    " AND MUNIC.CD_MUNICIPIO (+) = M.CD_MUNICIPIO_ORIGEM" & _
                    " AND FP.SQ_FRETE_PERCURSO (+) = F.SQ_FRETE_PERCURSO" & _
                    " AND OD.CD_ORDEM_DESCARGA (+) = FP.CD_ORDEM_DESCARGA" & _
                    " AND TS.CD_ORDEM_DESCARGA (+) = OD.CD_ORDEM_DESCARGA" & _
                    " AND FM.CD_FILIAL (+) = TS.CD_FILIAL"
        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Marca, _
                                                           cnt_GridGeral_Data, _
                                                           cnt_GridGeral_ValorUnitario, _
                                                           cnt_GridGeral_Volume, _
                                                           cnt_GridGeral_OD, _
                                                           cnt_GridGeral_Total, _
                                                           cnt_GridGeral_TipoFrete, _
                                                           cnt_GridGeral_FilialPagadora, _
                                                           cnt_GridGeral_FilialMovimentacao, _
                                                           cnt_GridGeral_Fornecedor, _
                                                           cnt_GridGeral_Municipio, _
                                                           cnt_GridGeral_NF, _
                                                           cnt_GridGeral_Codigo})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim IcTipoPessoa As String
        Dim Parametro(10) As DBParamentro
        Dim FilialDebitada As Integer
        Dim iCont As Integer
        Dim SqFretePagamento As Integer

        DBUsarTransacao = True

        If txtValor.Value = 0 Then
            Msg_Mensagem("Favor selecionar um item.")
            Exit Sub
        End If

        If txtFavorecido.Text = "" Then
            Msg_Mensagem("Favor informar um favorecido.")
            txtFavorecido.Focus()
            Exit Sub
        End If

        If Not ComboBox_LinhaSelecionada(cboFilialPagadora) Then
            Msg_Mensagem("Favor selecionar uma filial pagadora.")
            cboFilialPagadora.Focus()
            Exit Sub
        End If
        If Pesq_OperacaoBancaria.Codigo <= 0 Then
            Msg_Mensagem("Favor selecionar uma operação bancaria valida.")
            Pesq_OperacaoBancaria.Focus()
            Exit Sub
        Else
            SqlText = "select f.ic_fisica_juridica  "
            SqlText = SqlText & "from sof.fretista f "
            SqlText = SqlText & "where f.cd_fretista = " & Pesq_Fretista.Codigo

            IcTipoPessoa = DBQuery_ValorUnico(SqlText)

            'verifica se a operacao bancaria é pessoal juridica
            If Pesq_OperacaoBancaria.Codigo <> 38 And IcTipoPessoa = "J" Then
                If Pesq_OperacaoBancaria.Codigo <> 39 And IcTipoPessoa = "J" Then
                    If Pesq_OperacaoBancaria.Codigo <> 69 And IcTipoPessoa = "J" Then
                        Msg_Mensagem("Favor selecionar uma operação bancaria valida para pessoa Juridica.")
                        Pesq_OperacaoBancaria.Focus()
                        Exit Sub
                    End If
                End If
            End If
            'verifica se a operacao bancaria é pessoal fisica
            If Pesq_OperacaoBancaria.Codigo <> 4 And IcTipoPessoa = "F" Then
                If Pesq_OperacaoBancaria.Codigo <> 3 And IcTipoPessoa = "F" Then
                    If Pesq_OperacaoBancaria.Codigo <> 27 And IcTipoPessoa = "F" Then
                        Msg_Mensagem("Favor selecionar uma operação bancaria valida para pessoa Fisica.")
                        Pesq_OperacaoBancaria.Focus()
                        Exit Sub
                    End If
                End If
            End If
        End If

        If FilialFechada(cboFilialPagadora.SelectedValue) Then
            Msg_Mensagem("A Filial está fechada. No momento não é possivel realizar o pagamento.")
            Exit Sub
        End If

        SqlText = "SELECT OB.CD_FILIAL_DEBITADA_DEFAULT " & _
            "FROM SOF.OPERACAO_BANCARIA OB " & _
            "WHERE OB.CD_OPERACAO_BANCARIA = " & Pesq_OperacaoBancaria.Codigo

        FilialDebitada = DBQuery_ValorUnico(SqlText, FilialLogada)
        Calcula_Valor()

        SqlText = DBMontar_SP("SOF.SP_INCLUI_FRETE_PAGAMENTO", False, ":CDFRETISTA", _
                                                                ":DTLANC", _
                                                                ":VLBRUTO", _
                                                                ":FILORIGEM", _
                                                                ":FILPAG", _
                                                                ":ICFORMAPAG", _
                                                                ":NOFAVORECIDO", _
                                                                ":CDOPERACAO", _
                                                                ":ICISS", _
                                                                ":FILDEB", _
                                                                ":SEQFRETEPAG")

        Parametro(0) = DBParametro_Montar("CDFRETISTA", Pesq_Fretista.Codigo)
        Parametro(1) = DBParametro_Montar("DTLANC", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime)
        Parametro(2) = DBParametro_Montar("VLBRUTO", txtValor.Value)
        Parametro(3) = DBParametro_Montar("FILORIGEM", FilialLogada)
        If ComboBox_LinhaSelecionada(cboFilialPagadora) Then
            Parametro(4) = DBParametro_Montar("FILPAG", cboFilialPagadora.SelectedValue)
        Else
            Parametro(4) = DBParametro_Montar("FILPAG", FilialLogada)
        End If
        Parametro(5) = DBParametro_Montar("ICFORMAPAG", 0) 'travado na forma de pagamento cheque
        Parametro(6) = DBParametro_Montar("NOFAVORECIDO", txtFavorecido.Text)
        Parametro(7) = DBParametro_Montar("CDOPERACAO", Pesq_OperacaoBancaria.Codigo)
        Parametro(8) = DBParametro_Montar("ICISS", IIf(chkISS.Checked = True, "S", "N"))
        Parametro(9) = DBParametro_Montar("FILDEB", FilialDebitada)
        Parametro(10) = DBParametro_Montar("SEQFRETEPAG", Nothing, , ParameterDirection.Output)

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        If DBTeveRetorno() Then
            SqFretePagamento = DBRetorno(1)
        End If

        'Atualiza os fretes
        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_Marca, iCont) Then

                SqlText = DBMontar_Update("SOF.FRETE", GerarArray("SQ_FRETE_PAGAMENTO", ":SQ_FRETE_PAGAMENTO"), _
                                                     GerarArray("SQ_FRETE", ":SQ_FRETE"))

                If Not DBExecutar(SqlText, DBParametro_Montar("SQ_FRETE_PAGAMENTO", SqFretePagamento), _
                                               DBParametro_Montar("SQ_FRETE", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo, iCont))) Then GoTo Erro
            End If
        Next


        If Not DBExecutarTransacao() Then GoTo Erro
        ExecutaConsulta()
        Calcula_Valor()

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub grdGeral_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdGeral.AfterCellUpdate
        With grdGeral.Rows(e.Cell.Row.Index)
            If e.Cell.Column.Index <> cnt_GridGeral_Marca Then Exit Sub

            Select Case .Cells(cnt_GridGeral_Marca).Value
                Case 1
                    .Appearance.ForeColor = Color.Red
                    .Appearance.FontData.Bold = DefaultableBoolean.True
                Case 0
                    .Appearance.ForeColor = Color.Black
                    .Appearance.FontData.Bold = DefaultableBoolean.False
                Case Else
                    .Appearance.ForeColor = Color.Black
                    .Appearance.FontData.Bold = DefaultableBoolean.False
            End Select
        End With
        Calcula_Valor()
    End Sub

    Private Sub Calcula_Valor()
        Dim iCont As Integer

        txtValor.Value = 0

        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(grdGeral, cnt_GridGeral_Marca, iCont) Then
                txtValor.Value = txtValor.Value + grdGeral.Rows(iCont).Cells(cnt_GridGeral_Total).Value
            End If
        Next
    End Sub

    Private Sub Pesq_Fretista_AlterouRegistro() Handles Pesq_Fretista.AlterouRegistro
        If Pesq_Fretista.Codigo = 0 Then
            txtFavorecido.Text = ""
            oDS.Rows.Clear()
        Else
            txtFavorecido.Text = DBQuery_ValorUnico("SELECT F.NO_FAVORECIDO FROM SOF.FRETISTA F WHERE F.CD_FRETISTA = " & Pesq_Fretista.Codigo, "")
            ExecutaConsulta()
        End If
    End Sub

    Private Sub frmGeraFretePagamento_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 8
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 8
        'Posição vertical
        cmdGravar.Top = Me.ClientSize.Height - cmdGravar.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
    End Sub
End Class