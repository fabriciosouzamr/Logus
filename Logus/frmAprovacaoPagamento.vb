Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinEditors

Public Class frmAprovacaoPagamento
    Const cnt_GridGeral_Status As Integer = 0
    Const cnt_GridGeral_Fornecedor As Integer = 1
    Const cnt_GridGeral_Favorecido As Integer = 2
    Const cnt_GridGeral_Valor As Integer = 3
    Const cnt_GridGeral_Descricao As Integer = 4
    Const cnt_GridGeral_ICMS As Integer = 5
    Const cnt_GridGeral_TipoPagamento As Integer = 6
    Const cnt_GridGeral_Data As Integer = 7
    Const cnt_GridGeral_AddressNumber As Integer = 8
    Const cnt_GridGeral_Codigo As Integer = 9

    Const cnt_SEC_Tela As String = "Transacao_Pagamento_Aprovacao"

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim NR_NIVEL_APROVACAO_PAGAMENTO As Integer
    Dim QT_NIVEL_APROVACAO_PAGAMENTO As Integer

    Private Sub frmAprocacaoPagamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdGeral, "Status", 160, , True, , , True)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 180)
        objGrid_Coluna_Add(grdGeral, "Favorecido", 180)
        objGrid_Coluna_Add(grdGeral, "Valor", 90, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Descrição", 180)
        objGrid_Coluna_Add(grdGeral, "ICMS", 40)
        objGrid_Coluna_Add(grdGeral, "Tipo Pagamento", 140)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Address Number", 120)
        objGrid_Coluna_Add(grdGeral, "Código", 0)

        'SEC_ValidarBotao(cmdGravar, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao)

        QT_NIVEL_APROVACAO_PAGAMENTO = DBQuery_ValorUnico("SELECT NVL(QT_NIVEL_APROVACAO_PAGAMENTO, 0) FROM SOF.PARAMETRO")

        ExecutaConsulta()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "SELECT NR_NIVEL_APROVACAO_PAGAMENTO FROM SOF.USUARIO_COMPLEMENTO WHERE CD_USER = " & QuotedStr(sAcesso_UsuarioLogado)
        NR_NIVEL_APROVACAO_PAGAMENTO = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT NULL STATUS," & _
                         "F.NO_RAZAO_SOCIAL," & _
                         "FF.NO_RAZAO_SOCIAL AS NO_FAVORECIDO," & _
                         "P.VL_PAGAMENTO," & _
                         "P.DS_DESCRICAO," & _
                         "TP.IC_PAGAMENTO_ICMS," & _
                         "TP.NO_TIPO_PAGAMENTO," & _
                         "P.DT_PAGAMENTO," & _
                         "FF.CD_ADDRESS_NUMBER," & _
                         "P.SQ_PAGAMENTO" & _
                  " FROM SOF.PAGAMENTOS P," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.FORNECEDOR FF," & _
                        "SOF.TIPO_PAGAMENTO TP," & _
                        "(SELECT CD_FILIAL" & _
                         " FROM SOF.APROVADOR_FILIAL" & _
                         " WHERE CD_USER = " & QuotedStr(sAcesso_UsuarioLogado) & ") AF," & _
                        "(SELECT VL_MINIMO, VL_MAXIMO FROM SOF.USUARIO" & _
                         " WHERE CD_USER =" & QuotedStr(sAcesso_UsuarioLogado) & ") LIM," & _
                         "(SELECT SQ_PAGAMENTO," & _
                                 "MAX(NR_NIVEL_APROVACAO) NR_NIVEL_APROVACAO" & _
                          " FROM SOF.PAGAMENTOS_APROVACAO" & _
                          " GROUP BY SQ_PAGAMENTO) APV" & _
                  " WHERE P.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                    " AND P.CD_FORNECEDOR_FAVORECIDO = FF.CD_FORNECEDOR" & _
                    " AND P.CD_TIPO_PAGAMENTO = TP.CD_TIPO_PAGAMENTO" & _
                    " AND P.IC_STATUS_APROVACAO = 'N'" & _
                    " AND UPPER(TRIM(P.NO_USER_CRIACAO)) <> " & QuotedStr(Trim(UCase(sAcesso_UsuarioLogado))) & _
                    " AND P.CD_FILIAL_ORIGEM = AF.CD_FILIAL" & _
                    " AND P.VL_PAGAMENTO >= LIM.VL_MINIMO" & _
                    " AND P.VL_PAGAMENTO <= LIM.VL_MAXIMO" & _
                    " AND APV.SQ_PAGAMENTO (+) = P.SQ_PAGAMENTO" & _
                    " AND NVL(NR_NIVEL_APROVACAO, 0) = " & NR_NIVEL_APROVACAO_PAGAMENTO - 1
        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Status, _
                                                           cnt_GridGeral_Fornecedor, _
                                                           cnt_GridGeral_Favorecido, _
                                                           cnt_GridGeral_Valor, _
                                                           cnt_GridGeral_Descricao, _
                                                           cnt_GridGeral_ICMS, _
                                                           cnt_GridGeral_TipoPagamento, _
                                                           cnt_GridGeral_Data, _
                                                           cnt_GridGeral_AddressNumber, _
                                                           cnt_GridGeral_Codigo})

        objGrid_Coluna_AddOption(grdGeral, oDS, cnt_GridGeral_Status, New Object() {"Aprovado", True, "Reprovado", False})
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim iCont As Integer
        Dim SqItemMovBancaria As Integer
        Dim sStatusAprovacao As String
        Dim SqlText As String
        Dim Parametro(13) As DBParamentro
        Dim oData As DataTable

        If Not SEC_ValidarUsuario(TipoValidacaoUsuario._UsuarioLogado) Then
            Msg_Mensagem("É necessário fazer a validação do usuário para poder continuar com o processo")
            Exit Sub
        End If

        For iCont = 0 To grdGeral.Rows.Count - 1
            If Not CampoNulo(grdGeral.Rows(iCont).Cells(cnt_GridGeral_Status).Value) Then
                SqlText = "SELECT COUNT(*) FROM SOF.PAGAMENTOS" & _
                           " WHERE SQ_PAGAMENTO = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Codigo).Value & _
                             " AND IC_STATUS_APROVACAO IN ('A', 'R')"
                If DBQuery_ValorUnico(SqlText) > 0 Then
                    Msg_Mensagem("A aprovação/reprovação do pagamento " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Descricao).Value & " de " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Favorecido).Value)
                    Exit Sub
                End If

                If grdGeral.Rows(iCont).Cells(cnt_GridGeral_Status).Value Then
                    sStatusAprovacao = "A"
                Else
                    sStatusAprovacao = "R"
                End If

                DBUsarTransacao = True

                SqlText = DBMontar_Insert("SOF.PAGAMENTOS_APROVACAO", TipoCampoFixo.Nenhum, _
                                                                      "SQ_PAGAMENTO", ":SQ_PAGAMENTO", _
                                                                      "NO_USER_APROVACAO", ":NO_USER_APROVACAO", _
                                                                      "NR_NIVEL_APROVACAO", ":NR_NIVEL_APROVACAO", _
                                                                      "DT_APROVACAO", "SYSDATE", _
                                                                      "IC_STATUS_APROVACAO", ":IC_STATUS_APROVACAO")

                If Not DBExecutar(SqlText, DBParametro_Montar("SQ_PAGAMENTO", grdGeral.Rows(iCont).Cells(cnt_GridGeral_Codigo).Value), _
                                           DBParametro_Montar("NO_USER_APROVACAO", sAcesso_UsuarioLogado), _
                                           DBParametro_Montar("NR_NIVEL_APROVACAO", NR_NIVEL_APROVACAO_PAGAMENTO), _
                                           DBParametro_Montar("IC_STATUS_APROVACAO", sStatusAprovacao)) Then GoTo Erro

                If QT_NIVEL_APROVACAO_PAGAMENTO = NR_NIVEL_APROVACAO_PAGAMENTO Or sStatusAprovacao = "R" Then
                    If Not DBExecutar("UPDATE SOF.PAGAMENTOS" & _
                                      " SET IC_STATUS_APROVACAO = " & QuotedStr(sStatusAprovacao) & "," & _
                                           "NO_USER_APROVACAO = " & QuotedStr(sAcesso_UsuarioLogado) & "," & _
                                           "NO_USER_ALTERACAO = " & QuotedStr(sAcesso_UsuarioLogado) & "," & _
                                           "DT_ALTERACAO = SYSDATE" & _
                                      " WHERE SQ_PAGAMENTO = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Codigo).Value) Then GoTo Erro

                    SqlText = "SELECT P.*," & _
                                     "T.CD_FORMA_PAGAMENTO," & _
                                     "T.IC_PAGAMENTO_ICMS," & _
                                     "T.CD_OPERACAO_BANCARIA" & _
                              " FROM SOF.PAGAMENTOS P," & _
                                    "SOF.TIPO_PAGAMENTO T" & _
                              " WHERE T.CD_TIPO_PAGAMENTO = P.CD_TIPO_PAGAMENTO" & _
                                " AND P.SQ_PAGAMENTO = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Codigo).Value
                    oData = DBQuery(SqlText)

                    If oData.Rows(0).Item("CD_FORMA_PAGAMENTO") = 1 And sStatusAprovacao = "A" Then
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

                        Parametro(0) = DBParametro_Montar("OPE", oData.Rows(0).Item("CD_OPERACAO_BANCARIA"))
                        Parametro(1) = DBParametro_Montar("DATA", Date_to_Oracle(DataSistema), OracleClient.OracleType.DateTime)
                        Parametro(2) = DBParametro_Montar("DESCRICAO", oData.Rows(0).Item("DS_DESCRICAO"))
                        Parametro(3) = DBParametro_Montar("FAVORECIDO", oData.Rows(0).Item("NO_FAVORECIDO"))
                        Parametro(4) = DBParametro_Montar("VALOR", oData.Rows(0).Item("VL_PAGAMENTO"))
                        Parametro(5) = DBParametro_Montar("DC", "D")
                        Parametro(6) = DBParametro_Montar("FILDEB", oData.Rows(0).Item("CD_FILIAL_ORIGEM"))
                        Parametro(7) = DBParametro_Montar("VLLIQ", oData.Rows(0).Item("VL_PAGAMENTO"))
                        Parametro(8) = DBParametro_Montar("VLPROVTOTAL", 0)
                        Parametro(9) = DBParametro_Montar("VLBRUTO", oData.Rows(0).Item("VL_PAGAMENTO"))
                        Parametro(10) = DBParametro_Montar("FILPAG", oData.Rows(0).Item("CD_FILIAL_PAGADORA"))
                        Parametro(11) = DBParametro_Montar("BANCO", Nothing)
                        Parametro(12) = DBParametro_Montar("CDFRETISTA", Nothing)
                        Parametro(13) = DBParametro_Montar("SEQ", Nothing, , ParameterDirection.Output)

                        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

                        If DBTeveRetorno() Then
                            SqItemMovBancaria = DBRetorno(1)
                        End If

                        SqlText = "UPDATE SOF.PAGAMENTOS" & _
                                  " SET SQ_ITEM_MOV_BANCARIO = " & SqItemMovBancaria & "," & _
                                       "DT_PAGAMENTO = " & QuotedStr(Date_to_Oracle(DataSistema)) & _
                                  " WHERE SQ_PAGAMENTO = " & grdGeral.Rows(iCont).Cells(cnt_GridGeral_Codigo).Value
                        If Not DBExecutar(SqlText) Then GoTo Erro
                    End If
                End If
            End If

            If Not DBExecutarTransacao() Then GoTo Erro
        Next

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub grdGeral_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdGeral.AfterCellUpdate
        With grdGeral.Rows(e.Cell.Row.Index)
            If e.Cell.Column.Index <> cnt_GridGeral_Status Then Exit Sub

            Select Case .Cells(cnt_GridGeral_Status).Editor.Value
                Case True
                    .Appearance.ForeColor = Color.Green
                    .Appearance.FontData.Bold = DefaultableBoolean.True
                Case False
                    .Appearance.ForeColor = Color.Red
                    .Appearance.FontData.Bold = DefaultableBoolean.True
                Case Else
                    .Appearance.ForeColor = Color.Black
                    .Appearance.FontData.Bold = DefaultableBoolean.False
            End Select
        End With
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmAprovacaoPagamento_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        'Posição vertical
        cmdAtualizar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdGravar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
    End Sub

    Private Sub grdGeral_AfterPerformAction(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs) Handles grdGeral.AfterPerformAction
        Me.Text = Now.ToString
    End Sub
End Class