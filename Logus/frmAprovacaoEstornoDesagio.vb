Public Class frmAprovacaoEstornoDesagio
    Const cnt_GridGeral_Status As Integer = 0
    Const cnt_GridGeral_SQ_PAGAMENTO As Integer = 1
    Const cnt_GridGeral_NR_PAGAMENTO As Integer = 2
    Const cnt_GridGeral_NO_RAZAO_SOCIAL As Integer = 3
    Const cnt_GridGeral_CD_CONTRATO As Integer = 4
    Const cnt_GridGeral_DT_SOLICITACAO As Integer = 5
    Const cnt_GridGeral_VL_DESCONTO As Integer = 6
    Const cnt_GridGeral_CM_MOTIVO_SOLICITACAO As Integer = 7
    Const cnt_GridGeral_NO_USUARIO_SOLICITACAO As Integer = 8
    Const cnt_GridGeral_DS_MOTIVO As Integer = 9
    Const cnt_GridGeral_CD_FORNECEDOR As Integer = 10
    Const cnt_GridGeral_CD_CONTRATO_PAF As Integer = 11
    Const cnt_GridGeral_SQ_NEGOCIACAO As Integer = 12
    Const cnt_GridGeral_SQ_CONTRATO_FIXO As Integer = 13

    Dim oDS As New Infragistics.Win.UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Pesquisar()
    End Sub

    Private Sub Pesquisar()
        Dim SqlText As String

        SqlText = "SELECT 'X'," & _
                         "SED.SQ_PAGAMENTO," & _
                         "SED.NR_SOLICITACAO," & _
                         "FNC.NO_RAZAO_SOCIAL," & _
                         "TRIM(TO_CHAR(CPF.CD_CONTRATO_PAF)) || '-' || TRIM(TO_CHAR(CFX.SQ_NEGOCIACAO)) || '-' || TRIM(TO_CHAR(CFX.SQ_CONTRATO_FIXO)) CD_CONTRATO," & _
                         "SED.DT_SOLICITACAO," & _
                         "SED.VL_DESCONTO," & _
                         "SED.CM_MOTIVO_SOLICITACAO," & _
                         "USR.NO_USUARIO, PAG.CD_FORNECEDOR, " & _
                         "CPF.CD_CONTRATO_PAF, CFX.SQ_NEGOCIACAO, CFX.SQ_CONTRATO_FIXO " & _
                  " FROM SOF.SOLICITACAO_ESTORNO_DESAGIO SED," & _
                        "SOF.PAGAMENTOS PAG," & _
                        "SOF.PAG_NEG_CTR_FIX CFX," & _
                        "SOF.CONTRATO_PAF CPF," & _
                        "SOF.FORNECEDOR FNC," & _
                        "SOF.USUARIO USR" & _
                  " WHERE SED.IC_APROVADO IS NULL" & _
                    " AND PAG.SQ_PAGAMENTO = SED.SQ_PAGAMENTO" & _
                    " AND CFX.SQ_PAGAMENTO = PAG.SQ_PAGAMENTO" & _
                    " AND CPF.CD_CONTRATO_PAF = CFX.CD_CONTRATO_PAF" & _
                    " AND FNC.CD_FORNECEDOR = CPF.CD_FORNECEDOR" & _
                    " AND USR.CD_USER = SED.CD_USUARIO_SOLICITACAO" & _
                  " ORDER BY FNC.NO_RAZAO_SOCIAL," & _
                            "TRIM(TO_CHAR(CPF.CD_CONTRATO_PAF)) || '-' || TRIM(TO_CHAR(CFX.SQ_NEGOCIACAO)) || '-' || TRIM(TO_CHAR(CFX.SQ_CONTRATO_FIXO))"
        objGrid_Carregar(grdEstornoAprovacao, SqlText, New Integer() {cnt_GridGeral_Status, _
                                                                      cnt_GridGeral_SQ_PAGAMENTO, _
                                                                      cnt_GridGeral_NR_PAGAMENTO, _
                                                                      cnt_GridGeral_NO_RAZAO_SOCIAL, _
                                                                      cnt_GridGeral_CD_CONTRATO, _
                                                                      cnt_GridGeral_DT_SOLICITACAO, _
                                                                      cnt_GridGeral_VL_DESCONTO, _
                                                                      cnt_GridGeral_CM_MOTIVO_SOLICITACAO, _
                                                                      cnt_GridGeral_NO_USUARIO_SOLICITACAO, _
                                                                      cnt_GridGeral_CD_FORNECEDOR, _
                                                                      cnt_GridGeral_CD_CONTRATO_PAF, _
                                                                      cnt_GridGeral_SQ_NEGOCIACAO, _
                                                                      cnt_GridGeral_SQ_CONTRATO_FIXO})

        objGrid_Coluna_AddOption(grdEstornoAprovacao, oDS, cnt_GridGeral_Status, New Object() {"Pendente", "X", _
                                                                                               "Aprovado", "A", _
                                                                                               "Reprovado", "R"})
    End Sub

    Private Sub frmAprovacaoEstornoDesagio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_Close(Me)
    End Sub

    Private Sub frmAprovacaoEstornoDesagio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objGrid_Inicializar(grdEstornoAprovacao, , oDS)
        objGrid_Coluna_Add(grdEstornoAprovacao, "Status", 220, , True, , , True)
        objGrid_Coluna_Add(grdEstornoAprovacao, "SQ_PAGAMENTO", 0)
        objGrid_Coluna_Add(grdEstornoAprovacao, "NR_PAGAMENTO", 0)
        objGrid_Coluna_Add(grdEstornoAprovacao, "Fornecedor", 200)
        objGrid_Coluna_Add(grdEstornoAprovacao, "Contrato", 100)
        objGrid_Coluna_Add(grdEstornoAprovacao, "Data da Solicitação", 150, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdEstornoAprovacao, "Vl. Desconto", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdEstornoAprovacao, "Motivo Solicitação", 200)
        objGrid_Coluna_Add(grdEstornoAprovacao, "Usuário Solicitação", 150)
        objGrid_Coluna_Add(grdEstornoAprovacao, "Motivo", 300, , True)
        objGrid_Coluna_Add(grdEstornoAprovacao, "Cod Fornecedor", 0)
        objGrid_Coluna_Add(grdEstornoAprovacao, "CONTRATO PAF", 0)
        objGrid_Coluna_Add(grdEstornoAprovacao, "NEGOCIACAO", 0)
        objGrid_Coluna_Add(grdEstornoAprovacao, "CONTRATO FIXO", 0)
        Form_Carrega_Grid(Me)

        Pesquisar()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim iCont As Integer
        Dim SqlText As String
        Dim CdModalidadeConciliacao As Integer
        Dim sqConciliacao As Integer
        Dim odata As DataTable

        For iCont = 0 To grdEstornoAprovacao.Rows.Count - 1
            If grdEstornoAprovacao.Rows(iCont).Cells(cnt_GridGeral_Status).Value = "R" And _
               NVL(grdEstornoAprovacao.Rows(iCont).Cells(cnt_GridGeral_DS_MOTIVO).Value, "") = "" Then
                Msg_Mensagem("É preciso informar o motivo para todas as reprovações")
                Exit Sub
            End If
        Next

        CdModalidadeConciliacao = 7
        DBUsarTransacao = True

        For iCont = 0 To grdEstornoAprovacao.Rows.Count - 1
            If grdEstornoAprovacao.Rows(iCont).Cells(cnt_GridGeral_Status).Value <> "X" Then
                SqlText = DBMontar_Update("SOF.SOLICITACAO_ESTORNO_DESAGIO", GerarArray("CD_USUARIO_APROVACAO", ":CD_USUARIO_APROVACAO", _
                                                                                        "DT_APROVACAO", "SYSDATE", _
                                                                                        "IC_APROVADO", ":IC_APROVADO", _
                                                                                        "CM_MOTIVO_APROVACAO", ":CM_MOTIVO_APROVACAO"), _
                                                                             GerarArray("SQ_PAGAMENTO", ":SQ_PAGAMENTO", " AND ", _
                                                                                        "NR_SOLICITACAO", ":NR_SOLICITACAO"))

                With grdEstornoAprovacao.Rows(iCont)
                    If Not DBExecutar(SqlText, DBParametro_Montar("CD_USUARIO_APROVACAO", sAcesso_UsuarioLogado), _
                                               DBParametro_Montar("IC_APROVADO", .Cells(cnt_GridGeral_Status).Value), _
                                               DBParametro_Montar("CM_MOTIVO_APROVACAO", .Cells(cnt_GridGeral_DS_MOTIVO).Value), _
                                               DBParametro_Montar("SQ_PAGAMENTO", .Cells(cnt_GridGeral_SQ_PAGAMENTO).Value), _
                                               DBParametro_Montar("NR_SOLICITACAO", .Cells(cnt_GridGeral_NR_PAGAMENTO).Value)) Then GoTo Erro
                End With



                SqlText = "select * from sof.pag_neg_ctr_fix where cd_contrato_paf=" & objGrid_Valor(grdEstornoAprovacao, cnt_GridGeral_CD_FORNECEDOR) & _
                " and sq_negociacao=" & objGrid_Valor(grdEstornoAprovacao, cnt_GridGeral_CD_FORNECEDOR) & _
                " and sq_contrato_fixo=" & objGrid_Valor(grdEstornoAprovacao, cnt_GridGeral_CD_FORNECEDOR)

                odata = DBQuery(SqlText)

                If objDataTable_Vazio(odata) Then
                    Msg_Mensagem("O Desagio não está mais aplicado no contrato.")
                    Exit Sub
                End If
                'FAÇO A CONCILIACAO AUTOMATICA
                If grdEstornoAprovacao.Rows(iCont).Cells(cnt_GridGeral_Status).Value = "A" Then
                    'CRIO A CONCILIAÇÃO
                    SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO", False, ":CDCONCILMODAL", _
                                                                                       ":CDFORN", _
                                                                                       ":QTCONCIL", _
                                                                                       ":VLCONCIL", _
                                                                                       ":DSCONCIL", _
                                                                                       ":SQCONCIL")

                    If Not DBExecutar(SqlText, DBParametro_Montar("CDCONCILMODAL", CdModalidadeConciliacao), _
                                               DBParametro_Montar("CDFORN", objGrid_Valor(grdEstornoAprovacao, cnt_GridGeral_CD_FORNECEDOR)), _
                                               DBParametro_Montar("QTCONCIL", 0), _
                                               DBParametro_Montar("VLCONCIL", objGrid_Valor(grdEstornoAprovacao, cnt_GridGeral_VL_DESCONTO)), _
                                               DBParametro_Montar("DSCONCIL", "Conciliação automatica reversão de Desagio", OracleClient.OracleType.VarChar, , 4000), _
                                               DBParametro_Montar("SQCONCIL", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                    If DBTeveRetorno() Then
                        sqConciliacao = DBRetorno(1)
                    End If

                    'AMARRO A CONCILIAÇÃO AO PAGAMENTO
                    'DESAPLICO O PAGAMENTO
                    If Math.Abs(CDbl(odata.Rows(0).Item("vl_fixo"))) = Math.Abs(CDbl(objGrid_Valor(grdEstornoAprovacao, cnt_GridGeral_VL_DESCONTO, iCont))) Then
                        SqlText = "DELETE FROM SOF.pag_neg_ctr_fix " & _
                                           "WHERE CD_CONTRATO_PAF = " & odata.Rows(0).Item("CD_CONTRATO_PAF") & " AND " & _
                                           "sq_negociacao = " & odata.Rows(0).Item("sq_negociacao") & " AND " & _
                                           "SQ_PAGAMENTO = " & odata.Rows(0).Item("SQ_PAGAMENTO") & " AND " & _
                                           "sq_pag_neg = " & odata.Rows(0).Item("sq_pag_neg") & " AND " & _
                                           "sq_contrato_fixo = " & odata.Rows(0).Item("sq_contrato_fixo") & " AND " & _
                                           "sq_pag_neg_ctr_fix = " & odata.Rows(0).Item("sq_pag_neg_ctr_fix") & " AND " & _
                                           "SQ_PAG_CTR_PAF = " & odata.Rows(0).Item("SQ_PAG_CTR_PAF")

                        If Not DBExecutar(SqlText) Then GoTo Erro

                        SqlText = "DELETE FROM SOF.pag_neg " & _
                                      "WHERE CD_CONTRATO_PAF = " & odata.Rows(0).Item("CD_CONTRATO_PAF") & " AND " & _
                                      "sq_negociacao = " & odata.Rows(0).Item("sq_negociacao") & " AND " & _
                                      "SQ_PAGAMENTO = " & odata.Rows(0).Item("SQ_PAGAMENTO") & " AND " & _
                                      "sq_pag_neg = " & odata.Rows(0).Item("sq_pag_neg") & " AND " & _
                                      "SQ_PAG_CTR_PAF = " & odata.Rows(0).Item("SQ_PAG_CTR_PAF")

                        If Not DBExecutar(SqlText) Then GoTo Erro

                        SqlText = "DELETE FROM SOF.PAG_CTR_PAF " & _
                            "WHERE CD_CONTRATO_PAF = " & odata.Rows(0).Item("CD_CONTRATO_PAF") & " AND " & _
                            "SQ_PAGAMENTO = " & odata.Rows(0).Item("SQ_PAGAMENTO") & " AND " & _
                            "SQ_PAG_CTR_PAF = " & odata.Rows(0).Item("SQ_PAG_CTR_PAF")

                        If Not DBExecutar(SqlText) Then GoTo Erro

                    Else
                        SqlText = "UPDATE SOF.pag_neg_ctr_fix " & _
                              "SET VL_FIXO = VL_FIXO - " & odata.Rows(0).Item("VL_FIXO") & ", " & _
                              "VL_A_FIXAR = VL_A_FIXAR - " & odata.Rows(0).Item("VL_A_FIXAR") & " " & _
                                "WHERE CD_CONTRATO_PAF = " & odata.Rows(0).Item("CD_CONTRATO_PAF") & " AND " & _
                                "sq_negociacao = " & odata.Rows(0).Item("sq_negociacao") & " AND " & _
                                "SQ_PAGAMENTO = " & odata.Rows(0).Item("SQ_PAGAMENTO") & " AND " & _
                                "sq_pag_neg = " & odata.Rows(0).Item("sq_pag_neg") & " AND " & _
                                "sq_contrato_fixo = " & odata.Rows(0).Item("sq_contrato_fixo") & " AND " & _
                                "sq_pag_neg_ctr_fix = " & odata.Rows(0).Item("sq_pag_neg_ctr_fix") & " AND " & _
                                "SQ_PAG_CTR_PAF = " & odata.Rows(0).Item("SQ_PAG_CTR_PAF")

                        If Not DBExecutar(SqlText) Then GoTo Erro

                        SqlText = "UPDATE SOF.pag_neg " & _
                                 "SET VL_FIXO = VL_FIXO - " & odata.Rows(0).Item("VL_FIXO") & ", " & _
                                 "VL_A_FIXAR = VL_A_FIXAR - " & odata.Rows(0).Item("VL_A_FIXAR") & " " & _
                                   "WHERE CD_CONTRATO_PAF = " & odata.Rows(0).Item("CD_CONTRATO_PAF") & " AND " & _
                                   "sq_negociacao = " & odata.Rows(0).Item("sq_negociacao") & " AND " & _
                                   "SQ_PAGAMENTO = " & odata.Rows(0).Item("SQ_PAGAMENTO") & " AND " & _
                                   "sq_pag_neg = " & odata.Rows(0).Item("sq_pag_neg") & " AND " & _
                                   "SQ_PAG_CTR_PAF = " & odata.Rows(0).Item("SQ_PAG_CTR_PAF")

                        If Not DBExecutar(SqlText) Then GoTo Erro

                        SqlText = "UPDATE SOF.PAG_CTR_PAF " & _
                            "SET VL_FIXO = VL_FIXO - " & odata.Rows(0).Item("VL_FIXO") & ", " & _
                            "VL_A_FIXAR = VL_A_FIXAR - " & odata.Rows(0).Item("VL_A_FIXAR") & " " & _
                            "WHERE CD_CONTRATO_PAF = " & odata.Rows(0).Item("CD_CONTRATO_PAF") & " AND " & _
                            "SQ_PAGAMENTO = " & odata.Rows(0).Item("SQ_PAGAMENTO") & " AND " & _
                            "SQ_PAG_CTR_PAF = " & odata.Rows(0).Item("SQ_PAG_CTR_PAF")

                        If Not DBExecutar(SqlText) Then GoTo Erro
                    End If

                    SqlText = DBMontar_SP("SOF.SP_INCLUI_CONCILIACAO_PAG", False, ":SQCONCIL", _
                                                                  ":SQPAG", _
                                                                  ":VLAPLICACAO")

                    If Not DBExecutar(SqlText, DBParametro_Montar("SQCONCIL", sqConciliacao), _
                                                   DBParametro_Montar("SQPAG", objGrid_Valor(grdEstornoAprovacao, cnt_GridGeral_SQ_PAGAMENTO, iCont)), _
                                                   DBParametro_Montar("VLAPLICACAO", objGrid_Valor(grdEstornoAprovacao, cnt_GridGeral_VL_DESCONTO, iCont))) Then GoTo Erro


                End If
            End If
        Next


        If Not DBExecutarTransacao() Then GoTo Erro

        Pesquisar()

        Exit Sub

Erro:
        TratarErro(, , "frmAprovacaoEstornoDesagio.cmdGravar_Click")
    End Sub
End Class