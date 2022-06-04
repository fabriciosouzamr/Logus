Imports Infragistics.Win

Public Class frmConsultaPDD
    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_NO_TIPO_PDD As Integer = 1
    Const cnt_GridGeral_NO_FILIAL_REFERENCIA As Integer = 2
    Const cnt_GridGeral_NO_FORNECEDOR As Integer = 3
    Const cnt_GridGeral_CONTRATO As Integer = 4
    Const cnt_GridGeral_DS_CONFISSAO_DIVIDA As Integer = 5
    Const cnt_GridGeral_DS_PDD As Integer = 6
    Const cnt_GridGeral_IC_BENS As Integer = 7
    Const cnt_GridGeral_QT_KGS_SALDO_DEVEDOR As Integer = 8
    Const cnt_GridGeral_VL_SALDO_DEVEDOR As Integer = 9
    Const cnt_GridGeral_VL_PAGAMENTOS As Integer = 10

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim WithEvents oFormConsultaPDD_Pagamentos As frmConsultaPDD_Pagamentos

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Form_Show(Me.MdiParent, frmCadastroPDD)
    End Sub

    Private Sub frmConsultaPDD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, , , , , True)
        objGrid_Coluna_Add(grdGeral, "Código", 0)
        objGrid_Coluna_Add(grdGeral, "Tipo de PDD", 80)
        objGrid_Coluna_Add(grdGeral, "Filial", 100)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 130)
        objGrid_Coluna_Add(grdGeral, "Contrato", 100)
        objGrid_Coluna_Add(grdGeral, "Recuperação de Crédito", 100)
        objGrid_Coluna_Add(grdGeral, "Descriação do PDD", 200)
        objGrid_Coluna_Add(grdGeral, "Possui Bens", 50)
        objGrid_Coluna_Add(grdGeral, "Kgs Devedor", 150, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Valor Devedor", 150, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor Pagamentos", 150, , , , , cnt_Formato_Valor)
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "PDD", "SQ_PDD= " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        Pesquisa()
    End Sub

    Private Sub Pesquisa()
        Dim SqlText As String

        SqlText = "SELECT PDD.SQ_PDD," & _
                         "TPD.NO_STATUS NO_TIPO_PDD," & _
                         "FIL.NO_FILIAL NO_FILIAL_REFERENCIA," & _
                         "FRN.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "NVL2(PDD.CD_CONTRATO_PAF, TO_CHAR(PDD.CD_CONTRATO_PAF), '') || " & _
                              "NVL2(PDD.SQ_NEGOCIACAO, '-' || TRIM(TO_CHAR(PDD.SQ_NEGOCIACAO)), '') || " & _
                                   "NVL2(PDD.SQ_CONTRATO_FIXO, '-' || TRIM(TO_CHAR(PDD.SQ_CONTRATO_FIXO)), '') CONTRATO," & _
                         "NVL2(CDV.SQ_CONFISSAO_DIVIDA, TO_CHAR(CDV.SQ_CONFISSAO_DIVIDA) || ' - ' || TO_CHAR(CDV.DT_CONFISSAO_DIVIDA), '') DS_CONFISSAO_DIVIDA," & _
                         "PDD.DS_PDD," & _
                         "DECODE(NVL(PDD.IC_BENS, 'X'), 'X', 'Não Definido', 'S', 'Sim', 'N', 'Não') IC_BENS," & _
                         "PDD.QT_KGS_DEVEDOR," & _
                         "PDD.VL_DEVEDOR," & _
                         "PGT.VL_PAGO" & _
                  " FROM SOF.PDD PDD," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.FORNECEDOR FRN," & _
                        "SOF.CONFISSAO_DIVIDA CDV," & _
                        "SOF.TIPO_GARANTIA TGT," & _
                        "(SELECT * FROM SOF.PROCESSO_STATUS" & _
                         " WHERE CD_PROCESSO = " & cnt_Processo_TipoPDD & ")  TPD," & _
                        "(SELECT SQ_PDD," & _
                                "SUM(VL_PAGO) VL_PAGO" & _
                         " FROM SOF.PDD_PAGAMENTO" & _
                         " GROUP BY SQ_PDD) PGT" & _
                  " WHERE TPD.CD_STATUS = PDD.CD_TIPO_PDD" & _
                    " AND FIL.CD_FILIAL (+) = PDD.CD_FILIAL_REFERENCIA" & _
                    " AND FRN.CD_FORNECEDOR (+) = PDD.CD_FORNECEDOR" & _
                    " AND CDV.SQ_CONFISSAO_DIVIDA (+) = PDD.SQ_CONFISSAO_DIVIDA" & _
                    " AND TGT.CD_TIPO_GARANTIA (+) = PDD.CD_TIPO_GARANTIA" & _
                    " AND PGT.SQ_PDD (+)= PDD.SQ_PDD"

        If IsDate(txtDataInicial.Text) Then
            Str_Adicionar(SqlText, "TRUNC(PDD.DT_CRIACAO) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)), " AND ")
        End If
        If IsDate(txtDataFinal.Text) Then
            Str_Adicionar(SqlText, "TRUNC(PDD.DT_CRIACAO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)), " AND ")
        End If
        If Pesq_Fornecedor.Codigo > 0 Then
            Str_Adicionar(SqlText, "PDD.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo, " AND ")
        End If

        SqlText = SqlText & _
                  " ORDER BY PDD.SQ_PDD"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, _
                                                           cnt_GridGeral_NO_TIPO_PDD, _
                                                           cnt_GridGeral_NO_FILIAL_REFERENCIA, _
                                                           cnt_GridGeral_NO_FORNECEDOR, _
                                                           cnt_GridGeral_CONTRATO, _
                                                           cnt_GridGeral_DS_CONFISSAO_DIVIDA, _
                                                           cnt_GridGeral_DS_PDD, _
                                                           cnt_GridGeral_IC_BENS, _
                                                           cnt_GridGeral_QT_KGS_SALDO_DEVEDOR, _
                                                           cnt_GridGeral_VL_SALDO_DEVEDOR, _
                                                           cnt_GridGeral_VL_PAGAMENTOS})
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oFormConsultaPDD_Pagamentos As New frmCadastroPDD

        oFormConsultaPDD_Pagamentos.SQ_PDD = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

        Form_Show(Me.MdiParent, oFormConsultaPDD_Pagamentos)
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If Msg_Perguntar("Deseja realmente excluir esse lançamento do PDD?") Then
            Dim SqlText As String

            SqlText = "SELECT COUNT(*) FROM SOF.PDD_PAGAMENTO" & _
                      " WHERE SQ_PDD = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo) & _
                        " AND DT_EXCLUSAO IS NULL"

            If DBQuery_ValorUnico(SqlText) > 0 Then
                Msg_Mensagem("Existem pagamentos associados a esse PDD")
                Exit Sub
            Else
                DBUsarTransacao = True

                SqlText = DBMontar_Update("SOF.PDD_PAGAMENTO", GerarArray("NO_USER_EXCLUSAO", ":NO_USER_EXCLUSAO", _
                                                                          "DT_EXCLUSAO", "SYSDATE"), _
                                                               GerarArray("SQ_PDD", ":SQ_PDD"), False)
                If Not DBExecutar(SqlText, DBParametro_Montar("NO_USER_EXCLUSAO", sAcesso_UsuarioLogado), _
                                           DBParametro_Montar("SQ_PDD", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))) Then GoTo Erro

                SqlText = DBMontar_Update("SOF.PDD", GerarArray("NO_USER_EXCLUSAO", ":NO_USER_EXCLUSAO", _
                                                                "DT_EXCLUSAO", "SYSDATE"), _
                                                     GerarArray("SQ_PDD", ":SQ_PDD"), False)
                If Not DBExecutar(SqlText, DBParametro_Montar("NO_USER_EXCLUSAO", sAcesso_UsuarioLogado), _
                                           DBParametro_Montar("SQ_PDD", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))) Then GoTo Erro

                If Not DBExecutarTransacao() Then GoTo Erro

                Pesquisa()

                Msg_Mensagem("PDD excluído com sucesso")
            End If
        End If

        Exit Sub

Erro:
        TratarErro(, , "frmConsultaPDD.cmdExcluir_Click")
    End Sub

    Private Sub cmdPagamentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPagamentos.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmConsultaPDD_Pagamentos

        oForm.SQ_PDD = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

        Form_Show(Me.MdiParent, oForm)
    End Sub

    Private Sub oFormConsultaPDD_Pagamentos_ExclusaoEfetuada() Handles oFormConsultaPDD_Pagamentos.ExclusaoEfetuada

    End Sub
End Class