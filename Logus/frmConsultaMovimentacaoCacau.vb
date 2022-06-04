Imports Infragistics.Win
Imports Logus.eDbType

Public Class frmConsultaMovimentacaoCacau
    Const cnt_GridGeral_dt_Movimentacao As Integer = 0
    Const cnt_GridGeral_no_Tipo_Movimentacao As Integer = 1
    Const cnt_GridGeral_no_Razao_Social As Integer = 2
    Const cnt_GridGeral_nu_NF As Integer = 3
    Const cnt_GridGeral_nu_Serie_NF As Integer = 4
    Const cnt_GridGeral_nu_NF_Referencia As Integer = 5
    Const cnt_GridGeral_dt_NF_Referencia As Integer = 6
    Const cnt_GridGeral_qt_KG_NF As Integer = 7
    Const cnt_GridGeral_qt_KG_Bruto_NF As Integer = 8
    Const cnt_GridGeral_qt_KG_Liquido_NF As Integer = 9
    Const cnt_GridGeral_qt_Desconto_Qualidade As Integer = 10
    Const cnt_GridGeral_qt_KG_A_Transferir As Integer = 11
    Const cnt_GridGeral_vl_NF As Integer = 12
    Const cnt_GridGeral_vl_NF_ICMS As Integer = 13
    Const cnt_GridGeral_vl_NF_Funrural As Integer = 14
    Const cnt_GridGeral_qt_KG_Sobra As Integer = 15
    Const cnt_GridGeral_no_Filial As Integer = 16
    Const cnt_GridGeral_no_Filial_Origem As Integer = 17
    Const cnt_GridGeral_no_Filial_Fornecedor As Integer = 18
    Const cnt_GridGeral_no_Municipio As Integer = 19
    Const cnt_GridGeral_cd_Tipo_NF As Integer = 20
    Const cnt_GridGeral_no_Local_Entrega As Integer = 21
    Const cnt_GridGeral_cd_Procedencia As Integer = 22
    Const cnt_GridGeral_nu_Ordem_Descarga As Integer = 23
    Const cnt_GridGeral_sq_Item_Mov_Bancario As Integer = 24
    Const cnt_GridGeral_sq_Movimentacao As Integer = 25
    Const cnt_GridGeral_CD_Filial_Movimentacao As Integer = 26
    Const cnt_GridGeral_IC_VALIDA_VALOR As Integer = 27

    Const cnt_GridCessaoDireito_SQ_MOVIMENTACAO As Integer = 0
    Const cnt_GridCessaoDireito_Data As Integer = 1
    Const cnt_GridCessaoDireito_CessaoDireito As Integer = 2
    Const cnt_GridCessaoDireito_KgsAplicado As Integer = 3
    Const cnt_GridCessaoDireito_ValorAplicado As Integer = 4

    Const cnt_GridContratoPAF_DataFixacao As Integer = 0
    Const cnt_GridContratoPAF_ContratoPAF As Integer = 1
    Const cnt_GridContratoPAF_KgAplicado As Integer = 2
    Const cnt_GridContratoPAF_ValorAplicado As Integer = 3
    Const cnt_GridContratoPAF_SQ_MOVIMENTACAO As Integer = 4
    Const cnt_GridContratoPAF_SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer = 5

    Const cnt_GridNegociacao_DataAplicacao As Integer = 0
    Const cnt_GridNegociacao_Negociacao As Integer = 1
    Const cnt_GridNegociacao_KgAplicado As Integer = 2
    Const cnt_GridNegociacao_ValorAplicado As Integer = 3
    Const cnt_GridNegociacao_CD_CONTRATO_PAF As Integer = 4
    Const cnt_GridNegociacao_SQ_NEGOCIACAO As Integer = 5
    Const cnt_GridNegociacao_SQ_MOVIMENTACAO As Integer = 6
    Const cnt_GridNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer = 7

    Const cnt_GridContratoFixo_DataAplicacao As Integer = 0
    Const cnt_GridContratoFixo_ContradoFixo As Integer = 1
    Const cnt_GridContratoFixo_KgsAplicado As Integer = 2
    Const cnt_GridContratoFixo_ValorAplicado As Integer = 3
    Const cnt_GridContratoFixo_CD_CONTRATO_PAF As Integer = 4
    Const cnt_GridContratoFixo_SQ_NEGOCIACAO As Integer = 5
    Const cnt_GridContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer = 6
    Const cnt_GridContratoFixo_SQ_MOVIMENTACAO As Integer = 7

    Const cnt_Tela As String = "Transacao_MovCacau_ConsultaMovimentacaoCacau"
    Const cnt_Tela_AcertoRD As String = "Administracao_AcertoRD_Movimentacao"

    Dim bExcluir_Movimentacao As Boolean = False
    Dim bExcluir_AcertoRD As Boolean = False

    Dim oDS As New DataSet
    Dim WithEvents oForm_NfReferencia As frmMovimentacaoCacau_NFReferencia

    Private Sub frmConsultaMovimentacaoCacau_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form_Close(Me)
    End Sub

    Private Sub frmConsultaMovimentacaoCacau_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        objGrid_Inicializar(grdGeral, , oDS, Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect, , , True, UltraWinGrid.ViewStyleBand.Vertical, , _
                            UltraWinGrid.SelectType.Extended, True)
        objGrid_Coluna_Add(grdGeral, "Data", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "Tipo Movimentação", 200)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 200)
        objGrid_Coluna_Add(grdGeral, "NF", 80)
        objGrid_Coluna_Add(grdGeral, "Serie", 80)
        objGrid_Coluna_Add(grdGeral, "NF Ref", 80)
        objGrid_Coluna_Add(grdGeral, "Dt Ref", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "KG NF", 90, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "KG Bruto", 90, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "KG Liquido", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "KG Desconto Qualidade", 180, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "KG a Transferir", 120, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Valor NF", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor ICMS", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Valor Funrural", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Quebra/Sobra", 100, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Filial Movimentação", 100)
        objGrid_Coluna_Add(grdGeral, "Filial Origem", 100)
        objGrid_Coluna_Add(grdGeral, "Filial Fornecedor", 100)
        objGrid_Coluna_Add(grdGeral, "Municipio", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo Doc", 100)
        objGrid_Coluna_Add(grdGeral, "Local Entrega", 100)
        objGrid_Coluna_Add(grdGeral, "Procedencia", 100)
        objGrid_Coluna_Add(grdGeral, "Ordem Descarga", 100)
        objGrid_Coluna_Add(grdGeral, "Mov Bancario", 100)
        objGrid_Coluna_Add(grdGeral, "Código", 100, , , , , cnt_Formato_NumeroInteiro)
        objGrid_Coluna_Add(grdGeral, "Cd_Filial_Movimentacao", 0)
        objGrid_Coluna_Add(grdGeral, "IC_VALIDA_VALOR", 0)

        Form_Carrega_Grid(Me)

        SelecaoFilial.BancoDados_Tabela = SQL_Filial_FilialLiberaUsuario()
        SelecaoFilial.BancoDados_Campo_Codigo = "CD_FILIAL"
        SelecaoFilial.BancoDados_Campo_Descricao = "NO_FILIAL"
        SelecaoFilial.BancoDados_Carregar()

        SelecaoEstadoOrigem.BancoDados_Tabela = "SOF.UF"
        SelecaoEstadoOrigem.BancoDados_Campo_Codigo = "CD_UF"
        SelecaoEstadoOrigem.BancoDados_Campo_Descricao = "NO_UF"
        SelecaoEstadoOrigem.BancoDados_Carregar()

        cmdAlterar.Enabled = SEC_ValidarAcessoInterno(cnt_Tela, SEC_Validador.SEC_V_Alteracao)

        bExcluir_Movimentacao = SEC_ValidarAcessoInterno(cnt_Tela, SEC_Validador.SEC_V_Exclusao)
        bExcluir_AcertoRD = SEC_ValidarAcessoInterno(cnt_Tela_AcertoRD, SEC_Validador.SEC_V_Exclusao)
        cmdExcluir.Enabled = (bExcluir_Movimentacao Or bExcluir_AcertoRD)

        cmdNovo.Enabled = SEC_ValidarAcessoInterno(cnt_Tela, SEC_Validador.SEC_V_Inclusao)
        cmdNFReferencia.Enabled = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_LancarNotaFiscalReferenciaMovimentacao)
        cmdICMS.Enabled = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AlterarDisponibilizacaoPagamentoAmarracao)
        cmdLivroFiscal.Enabled = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_RemoverMovimentacaoInterfaceLivroFiscal)

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        SqlText = "(SELECT TM.CD_TIPO_MOVIMENTACAO," & _
                          "TM.CD_TIPO_MOVIMENTACAO || '-' || TM.NO_TIPO_MOVIMENTACAO AS NO_TIPO_MOVIMENTACAO" & _
                   " FROM SOF.TIPO_MOVIMENTACAO TM" & _
                   " WHERE NVL(TM.IC_ATIVO, 'S') = 'S'" & _
                     " AND NVL(TM.IC_TIPO_UTILIZACAO, 'N') NOT IN ('T'))"

        SelecaoTipoNovimentacao.BancoDados_Tabela = SqlText
        SelecaoTipoNovimentacao.BancoDados_Campo_Codigo = "CD_TIPO_MOVIMENTACAO"
        SelecaoTipoNovimentacao.BancoDados_Campo_Descricao = "NO_TIPO_MOVIMENTACAO"
        SelecaoTipoNovimentacao.BancoDados_Filtro_Limpar()
        SelecaoTipoNovimentacao.BancoDados_Carregar()

        Pesquisa_CriarDataSet()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim SqlText As String
        Dim oData As DataTable
        Dim iCont As Integer
        Dim bContratoFixo As Boolean = False
        Dim bNegociacao As Boolean = False
        Dim bContratoPAF As Boolean = False
        Dim iAux_Qtde As Integer

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        'Verifica se o usuário tem acesso a filial da movimentação
        SqlText = "SELECT COUNT(*)" & _
                  " FROM SOF.FILIAL" & _
                  " WHERE CD_FILIAL = " & objGrid_Valor(grdGeral, cnt_GridGeral_CD_Filial_Movimentacao) & _
                    " AND CD_FILIAL IN (" & ListarIDFiliaisLiberadaUsuario() & ")"

        If DBQuery_ValorUnico(SqlText, 0) = 0 Then
            Msg_Mensagem("Esta movimentação não pertence a esta filial.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) FROM SOF.LOTE_MOVIMENTACAO L" & _
                  " WHERE L.SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)

        If DBQuery_ValorUnico(SqlText, 0) <> 0 Then
            Msg_Mensagem("Esta movimentação deve ser excluida pelo Summus.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) FROM SOF.MOVIMENTACAO_ACERTO" & _
                  " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
        If DBQuery_ValorUnico(SqlText) > 0 Then
            If bExcluir_AcertoRD Then
                If objGrid_Valor(grdGeral, cnt_GridGeral_dt_Movimentacao) <> DataSistema() Then
                    Msg_Mensagem("Acerto realizado em outra data.")
                    Exit Sub
                End If
            Else
                Msg_Mensagem("Você não tem permissão para realizar exclusão.")
                Exit Sub
            End If
        Else
            If Not bExcluir_Movimentacao Then
                Msg_Mensagem("Você não tem permissão para realizar exclusão.")
                Exit Sub
            End If
        End If

        If Not Msg_Perguntar("Elimina a movimentação ?") Then Exit Sub

        AVI_Carregar(Me)

        bContratoFixo = False
        bNegociacao = False
        bContratoPAF = False

        If objGrid_Valor(grdGeral, cnt_GridGeral_dt_Movimentacao) = DataSistema() Then
            SqlText = "SELECT COUNT(*) FROM SOF.CTR_PAF_NEG_CTR_FIX_MOV " & _
                      " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
            iAux_Qtde = DBQuery_ValorUnico(SqlText)

            If iAux_Qtde = 0 Then
                SqlText = "SELECT COUNT(*) FROM SOF.CTR_PAF_NEG_MOVIMENTACAO " & _
                          " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
                iAux_Qtde = DBQuery_ValorUnico(SqlText)

                If iAux_Qtde = 0 Then
                    SqlText = "SELECT COUNT(*) FROM SOF.CTR_PAF_MOVIMENTACAO " & _
                              " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
                    iAux_Qtde = DBQuery_ValorUnico(SqlText)

                    If iAux_Qtde <> 0 Then
                        SqlText = "SELECT COUNT(*)" & _
                                  " FROM SOF.CTR_PAF_MOVIMENTACAO PCP," & _
                                        "SOF.CONTRATO_PAF CP " & _
                                  " WHERE PCP.CD_CONTRATO_PAF = CP.CD_CONTRATO_PAF" & _
                                    " AND CP.IC_STATUS = 'F'" & _
                                    " AND PCP.SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
                        iAux_Qtde = DBQuery_ValorUnico(SqlText)

                        If iAux_Qtde <> 0 Then
                            Msg_Mensagem("Essa movimentação ja foi aplicada em um contrato PAF que esta fechado.")
                            GoTo sair
                        End If

                        If Not Msg_Perguntar("Retira a aplicação do Contrato PAF ?") Then GoTo Sair

                        bContratoPAF = True
                    End If
                Else
                    SqlText = "SELECT COUNT(*)" & _
                              " FROM SOF.CTR_PAF_NEG_MOVIMENTACAO PN," & _
                                    "SOF.NEGOCIACAO N " & _
                              " WHERE PN.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                                " AND PN.SQ_NEGOCIACAO = N.SQ_NEGOCIACAO" & _
                                " AND N.IC_STATUS = 'F'" & _
                                " AND PN.SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
                    iAux_Qtde = DBQuery_ValorUnico(SqlText)

                    If iAux_Qtde <> 0 Then
                        Msg_Mensagem("Essa movimentação ja foi aplicada em uma negociação que esta fechada.")
                        GoTo Sair
                    End If

                    If Not Msg_Perguntar("Retira a aplicação da Negociação/Contrato PAF ?") Then GoTo Sair

                    bContratoPAF = True
                    bNegociacao = True
                End If
            Else
                SqlText = "SELECT COUNT(*)" & _
                          " FROM SOF.CTR_PAF_NEG_CTR_FIX_MOV PNCF," & _
                                "SOF.CONTRATO_FIXO CF " & _
                          " WHERE PNCF.CD_CONTRATO_PAF = CF.CD_CONTRATO_PAF" & _
                            " AND PNCF.SQ_NEGOCIACAO = CF.SQ_NEGOCIACAO" & _
                            " AND PNCF.SQ_CONTRATO_FIXO = CF.SQ_CONTRATO_FIXO" & _
                            " AND CF.IC_STATUS = 'F'" & _
                            " AND PNCF.SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
                iAux_Qtde = DBQuery_ValorUnico(SqlText)

                If iAux_Qtde <> 0 Then
                    Msg_Mensagem("Essa movimentação ja foi aplicada em um contrato fixo que esta fechado.")
                    GoTo Sair
                End If

                If Not Msg_Perguntar("Retira a aplicação do Contrato Fixo/Negociação/Contrato PAF ?") Then GoTo Sair

                bContratoFixo = True
                bNegociacao = True
                bContratoPAF = True
            End If
        End If

        On Error GoTo Erro

        If FilialFechada(FilialLogada) Then GoTo Sair

        DBUsarTransacao = True

        If bContratoFixo Then
            SqlText = "SELECT * FROM SOF.CTR_PAF_NEG_CTR_FIX_MOV" & _
                      " WHERE SQ_MOVIMENTACAO=" & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
            oData = DBQuery(SqlText)

            For iCont = 0 To oData.Rows.Count - 1
                With oData.Rows(iCont)
                    SqlText = DBMontar_SP("SOF.SP_ELIMINA_CTRPAF_NEG_CTRFIX_M", False, ":SQMOV", _
                                                                                       ":SQMOVCD", _
                                                                                       ":CDCTRPAF", _
                                                                                       ":SQCTRPAFMOV", _
                                                                                       ":SQNEG", _
                                                                                       ":SQCTRPAFNEGMOV", _
                                                                                       ":SQCTRFIX", _
                                                                                       ":SQCTRPAFNEGCTRFIXMOV")
                    If Not DBExecutar(SqlText, DBParametro_Montar("SQMOV", .Item("SQ_MOVIMENTACAO")), _
                                               DBParametro_Montar("SQMOVCD", .Item("SQ_MOVIMENTACAO_CESSAO_DIREITO")), _
                                               DBParametro_Montar("CDCTRPAF", .Item("CD_CONTRATO_PAF")), _
                                               DBParametro_Montar("SQCTRPAFMOV", .Item("SQ_CTR_PAF_MOVIMENTACAO")), _
                                               DBParametro_Montar("SQNEG", .Item("SQ_NEGOCIACAO")), _
                                               DBParametro_Montar("SQCTRPAFNEGMOV", .Item("SQ_CTR_PAF_NEG_MOVIMENTACAO")), _
                                               DBParametro_Montar("SQCTRFIX", .Item("SQ_CONTRATO_FIXO")), _
                                               DBParametro_Montar("SQCTRPAFNEGCTRFIXMOV", .Item("SQ_CTR_PAF_NEG_CTR_FIX_MOV"))) Then GoTo Erro
                End With
            Next

            oData.Dispose()
            oData = Nothing
        End If

        If bNegociacao Then
            SqlText = "DELETE FROM SOF.CTR_PAF_NEG_MOVIMENTACAO" & _
                      " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        If bContratoPAF Then
            SqlText = "DELETE FROM SOF.CTR_PAF_MOVIMENTACAO" & _
                      " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        SqlText = "DELETE FROM SOF.MOVIMENTACAO_ACERTO" & _
                  " WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
        If Not DBExecutar(SqlText) Then GoTo Erro

        SqlText = DBMontar_SP("SOF.ELIMINA_MOVIMENTACAO", False, ":REC", ":DTHOJE")

        If Not DBExecutar(SqlText, DBParametro_Montar("REC", objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)), _
                                   DBParametro_Montar("DTHOJE", Date_to_Oracle(DataSistema))) Then GoTo Erro

        If Not DBExecutarTransacao() Then GoTo Erro

        Pesquisar()

Sair:
        AVI_Fechar(Me)

        Exit Sub

Erro:
        AVI_Fechar(Me)
        TratarErro()
        Pesquisar()
    End Sub

    Private Sub cmdRastreabilidade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRastreabilidade.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmMovimentacaoCacau_Rastreabilidade

        oForm.Movimentacao(objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao))

        Form_Show(Me.MdiParent, oForm)
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdPilha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPilha.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmMovimentacaoCacau_Pilha

        oForm.Carregar(objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao))

        Form_Show(Nothing, oForm, True, True)

        oForm.Dispose()
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Form_Show(Me.Parent, New frmCadastroMovimentacao)
    End Sub

    Private Sub cmdInformacoes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInformacoes.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmMovimentacaoCacau_Info

        oForm.Carregar(objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao))

        Form_Show(Nothing, oForm, True, True)

        oForm.Dispose()
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        If Not Data_ValidarPeriodo("da movimentação", txtDataInicial.Value, txtDataFinal.Value, True, False) And _
          Pesq_Fornecedor.Codigo = 0 Then
            Msg_Mensagem("Informe um período válido ou um fornecedor")
            Exit Sub
        End If

        Pesquisar()
    End Sub

    Private Sub Pesquisa_CriarDataSet()
        'Montagem do DataSet - Início 
        DBData_Criar(oDS, "CessaoDireito", New String() {"SQ_MOVIMENTACAO", "Data", "Cessão de Direito", _
                                                         "Kg.s Aplicado", "Valor Aplicado"}, _
                                                     New eDbType() {_Decimal, _Data, _Decimal, _Numero, _Numero})
        DBData_Criar(oDS, "ContratoPAF", New String() {"Data de Aplicação", "Contrato PAF", "Kg.s Aplicado", "Valor Aplicado", _
                                                       "SQ_MOVIMENTACAO", "SQ_MOVIMENTACAO_CESSAO_DIREITO"}, _
                                                     New eDbType() {_Data, _Decimal, _Numero, _Decimal,_Decimal, _Decimal})
        DBData_Criar(oDS, "Negociacao", New String() {"Data de Aplicação", "Negociação", "Kg.s Aplicado", "Valor Aplicado", _
                                                      "CD_CONTRATO_PAF", "SQ_NEGOCIACAO", "SQ_MOVIMENTACAO", _
                                                      "SQ_MOVIMENTACAO_CESSAO_DIREITO"}, _
                                                     New eDbType() {_Data, _Numero, _Numero, _Decimal, _Decimal, _
                                                                    _Decimal, _Decimal, _Decimal})
        DBData_Criar(oDS, "ContratoFixo", New String() {"Data de Aplicação", "Contrado Fixo", "Kg.s Aplicado", "Valor Aplicado", _
                                                        "CD_CONTRATO_PAF", "SQ_NEGOCIACAO", "SQ_MOVIMENTACAO_CESSAO_DIREITO", _
                                                        "SQ_MOVIMENTACAO"}, _
                                                        New eDbType() {_Data, _Numero, _Numero, _Decimal, _Decimal, _
                                                                        _Decimal, _Decimal, _Decimal})

        'Montagem do DataSet - Fim
        DBData_Relationamento_Criar(oDS, "FK_CessaoDireito", _
                                         oDS.Tables(0), New String() {oDS.Tables(0).Columns(cnt_GridGeral_sq_Movimentacao).ColumnName}, _
                                         oDS.Tables(1), New String() {"SQ_MOVIMENTACAO"})
        DBData_Relationamento_Criar(oDS, "FK_ContratoPAF", _
                                         oDS.Tables(1), New String() {oDS.Tables(1).Columns(cnt_GridCessaoDireito_SQ_MOVIMENTACAO).ColumnName, _
                                                                      oDS.Tables(1).Columns(cnt_GridCessaoDireito_CessaoDireito).ColumnName}, _
                                         oDS.Tables(2), New String() {"SQ_MOVIMENTACAO", "SQ_MOVIMENTACAO_CESSAO_DIREITO"})
        DBData_Relationamento_Criar(oDS, "FK_Negociacao", _
                                         oDS.Tables(2), New String() {oDS.Tables(2).Columns(cnt_GridContratoPAF_SQ_MOVIMENTACAO).ColumnName, _
                                                                      oDS.Tables(2).Columns(cnt_GridContratoPAF_SQ_MOVIMENTACAO_CESSAO_DIREITO).ColumnName, _
                                                                      oDS.Tables(2).Columns(cnt_GridContratoPAF_ContratoPAF).ColumnName}, _
                                         oDS.Tables(3), New String() {"SQ_MOVIMENTACAO", "SQ_MOVIMENTACAO_CESSAO_DIREITO", _
                                                                      "CD_CONTRATO_PAF"})
        DBData_Relationamento_Criar(oDS, "FK_ContratoFixo", _
                                         oDS.Tables(3), New String() {oDS.Tables(3).Columns(cnt_GridNegociacao_SQ_MOVIMENTACAO).ColumnName, _
                                                                      oDS.Tables(3).Columns(cnt_GridNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO).ColumnName, _
                                                                      oDS.Tables(3).Columns(cnt_GridNegociacao_CD_CONTRATO_PAF).ColumnName, _
                                                                      oDS.Tables(3).Columns(cnt_GridNegociacao_SQ_NEGOCIACAO).ColumnName}, _
                                         oDS.Tables(4), New String() {"SQ_MOVIMENTACAO", "SQ_MOVIMENTACAO_CESSAO_DIREITO", _
                                                                      "CD_CONTRATO_PAF", "SQ_NEGOCIACAO"})

        objGrid_Band_Formatar(grdGeral.DisplayLayout.Bands(1), UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Band_Formatar(grdGeral.DisplayLayout.Bands(2), UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Band_Formatar(grdGeral.DisplayLayout.Bands(3), UltraWinGrid.CellClickAction.RowSelect)
        objGrid_Band_Formatar(grdGeral.DisplayLayout.Bands(4), UltraWinGrid.CellClickAction.RowSelect)

        With grdGeral.DisplayLayout.Bands(1)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridCessaoDireito_SQ_MOVIMENTACAO), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridCessaoDireito_Data), Nothing, 100, , , , cnt_Formato_Data)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridCessaoDireito_CessaoDireito), Nothing, 120)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridCessaoDireito_KgsAplicado), Nothing, 100)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridCessaoDireito_ValorAplicado), Nothing, 100, , , , cnt_Formato_Valor)
        End With
        With grdGeral.DisplayLayout.Bands(2)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoPAF_DataFixacao), Nothing, 100, , , , cnt_Formato_Data)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoPAF_ContratoPAF), Nothing, 100)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoPAF_KgAplicado), Nothing, 100)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoPAF_ValorAplicado), Nothing, 100, , , , cnt_Formato_Valor)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoPAF_SQ_MOVIMENTACAO), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoPAF_SQ_MOVIMENTACAO_CESSAO_DIREITO), Nothing, 0)
        End With
        With grdGeral.DisplayLayout.Bands(3)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridNegociacao_DataAplicacao), Nothing, 100, , , , cnt_Formato_Data)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridNegociacao_Negociacao), Nothing, 100)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridNegociacao_KgAplicado), Nothing, 100)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridNegociacao_ValorAplicado), Nothing, 100, , , , cnt_Formato_Valor)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridNegociacao_CD_CONTRATO_PAF), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridNegociacao_SQ_NEGOCIACAO), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridNegociacao_SQ_MOVIMENTACAO), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO), Nothing, 0)
        End With
        With grdGeral.DisplayLayout.Bands(4)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoFixo_DataAplicacao), Nothing, 100, , , , cnt_Formato_Data)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoFixo_ContradoFixo), Nothing, 100)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoFixo_KgsAplicado), Nothing, 100)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoFixo_ValorAplicado), Nothing, 100, , , , cnt_Formato_Valor)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoFixo_CD_CONTRATO_PAF), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoFixo_SQ_NEGOCIACAO), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoFixo_SQ_MOVIMENTACAO_CESSAO_DIREITO), Nothing, 0)
            objGrid_Coluna_Formatar(grdGeral, .Columns(cnt_GridContratoFixo_SQ_MOVIMENTACAO), Nothing, 0)
        End With
    End Sub

    Private Sub Pesq_Fornecedor_AlterouRegistro() Handles Pesq_Fornecedor.AlterouRegistro
        Dim SqlText As String

        If Pesq_Fornecedor.Codigo = 0 Then Exit Sub

        SqlText = "SELECT COUNT(*)" & _
                  " FROM SOF.FORNECEDOR " & _
                  " WHERE CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & _
                    " AND CD_FILIAL_ORIGEM in (" & ListarIDFiliaisLiberadaUsuario() & ")"

        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Este fornecedor não pertence a nenhuma das filiais liberadas para o seu acesso")
            Pesq_Fornecedor.Codigo = 0
        End If
    End Sub

    Private Sub Pesquisa_CessaoDireito(ByVal SQ_MOVIMENTACAO As Integer)
        Dim SqlText As String

        SqlText = "SELECT SQ_MOVIMENTACAO," & _
                         "DT_CESSAO_DIREITO," & _
                         "SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                         "QT_KG_MOVIMENTACAO," & _
                         "VL_MOVIMENTACAO" & _
                  " FROM SOF.MOVIMENTACAO_CESSAO_DIREITO" & _
                  " WHERE SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO
        DBQuery_Append(oDS.Tables(1), SqlText)
    End Sub

    Private Sub Pesquisa_ContratoPAF(ByVal SQ_MOVIMENTACAO As Integer, ByVal SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer)
        Dim SqlText As String

        SqlText = "SELECT CPM.DT_FIXACAO," & _
                         "CPM.CD_CONTRATO_PAF," & _
                         "SUM(CPM.QT_KG_FIXO) AS QT_KG_FIXO," & _
                         "SUM(CPM.VL_FIXO) AS VL_FIXO," & _
                         "CPM.SQ_MOVIMENTACAO," & _
                         "CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                  " FROM SOF.CTR_PAF_MOVIMENTACAO CPM" & _
                  " WHERE CPM.SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                    " AND CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO = " & SQ_MOVIMENTACAO_CESSAO_DIREITO & _
                  " GROUP BY CPM.DT_FIXACAO," & _
                            "CPM.CD_CONTRATO_PAF," & _
                            "CPM.SQ_MOVIMENTACAO," & _
                            "CPM.SQ_MOVIMENTACAO_CESSAO_DIREITO"
        DBQuery_Append(oDS.Tables(2), SqlText)
    End Sub

    Private Sub Pesquisa_Negociacao(ByVal SQ_MOVIMENTACAO As Integer, _
                                    ByVal SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer, _
                                    ByVal CD_CONTRATO_PAF As Integer)
        Dim SqlText As String

        SqlText = "SELECT CPNM.DT_FIXACAO," & _
                         "CPNM.SQ_NEGOCIACAO," & _
                         "CPNM.QT_KG_FIXO," & _
                         "CPNM.VL_FIXO," & _
                         "CPNM.CD_CONTRATO_PAF," & _
                         "CPNM.SQ_NEGOCIACAO," & _
                         "CPNM.SQ_MOVIMENTACAO," & _
                         "CPNM.SQ_MOVIMENTACAO_CESSAO_DIREITO" & _
                  " FROM SOF.CTR_PAF_NEG_MOVIMENTACAO CPNM" & _
                  " WHERE CPNM.SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                    " AND CPNM.SQ_MOVIMENTACAO_CESSAO_DIREITO = " & SQ_MOVIMENTACAO_CESSAO_DIREITO & _
                    " AND CPNM.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF
        DBQuery_Append(oDS.Tables(3), SqlText)
    End Sub

    Private Sub Pesquisa_ContratoFixo(ByVal SQ_MOVIMENTACAO As Integer, _
                                      ByVal SQ_MOVIMENTACAO_CESSAO_DIREITO As Integer, _
                                      ByVal CD_CONTRATO_PAF As Integer, _
                                      ByVal SQ_NEGOCIACAO As Integer)
        Dim SqlText As String

        SqlText = "SELECT CPNCFM.DT_FIXACAO," & _
                         "CPNCFM.SQ_CONTRATO_FIXO," & _
                         "CPNCFM.QT_KG_FIXO," & _
                         "CPNCFM.VL_FIXO," & _
                         "CPNCFM.CD_CONTRATO_PAF," & _
                         "CPNCFM.SQ_NEGOCIACAO," & _
                         "CPNCFM.SQ_MOVIMENTACAO_CESSAO_DIREITO," & _
                         "CPNCFM.SQ_MOVIMENTACAO" & _
                  " FROM SOF.CTR_PAF_NEG_CTR_FIX_MOV CPNCFM" & _
                  " WHERE CPNCFM.SQ_MOVIMENTACAO = " & SQ_MOVIMENTACAO & _
                    " AND CPNCFM.SQ_MOVIMENTACAO_CESSAO_DIREITO = " & SQ_MOVIMENTACAO_CESSAO_DIREITO & _
                    " AND CPNCFM.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND CPNCFM.SQ_NEGOCIACAO = " & SQ_NEGOCIACAO
        DBQuery_Append(oDS.Tables(4), SqlText)
    End Sub

    Private Sub grdGeral_AfterRowExpanded(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdGeral.AfterRowExpanded
        Select Case objGridBand_Index(e.Row)
            Case -1
                If e.Row.ChildBands.FirstRow Is Nothing Then
                    Pesquisa_CessaoDireito(e.Row.Cells(cnt_GridGeral_sq_Movimentacao).Value)
                End If
            Case 0
                If e.Row.ChildBands.FirstRow Is Nothing Then
                    Pesquisa_ContratoPAF(e.Row.Cells(cnt_GridCessaoDireito_SQ_MOVIMENTACAO).Value, _
                                         e.Row.Cells(cnt_GridCessaoDireito_CessaoDireito).Value)
                End If
            Case 1
                If e.Row.ChildBands.FirstRow Is Nothing Then
                    Pesquisa_Negociacao(e.Row.Cells(cnt_GridContratoPAF_SQ_MOVIMENTACAO).Value, _
                                        e.Row.Cells(cnt_GridContratoPAF_SQ_MOVIMENTACAO_CESSAO_DIREITO).Value, _
                                        e.Row.Cells(cnt_GridContratoPAF_ContratoPAF).Value)
                End If
            Case 2
                If e.Row.ChildBands.FirstRow Is Nothing Then
                    Pesquisa_ContratoFixo(e.Row.Cells(cnt_GridNegociacao_SQ_MOVIMENTACAO).Value, _
                                          e.Row.Cells(cnt_GridNegociacao_SQ_MOVIMENTACAO_CESSAO_DIREITO).Value, _
                                          e.Row.Cells(cnt_GridNegociacao_CD_CONTRATO_PAF).Value, _
                                          e.Row.Cells(cnt_GridNegociacao_SQ_NEGOCIACAO).Value)
                End If
        End Select
    End Sub

    Private Sub Pesquisar()
        Dim SqlText As String

        SqlText = "SELECT     M.DT_MOVIMENTACAO," & _
                            "TM.NO_TIPO_MOVIMENTACAO," & _
                             "F.NO_RAZAO_SOCIAL," & _
                             "M.NU_NF," & _
                             "M.NU_SERIE_NF," & _
                             "M.NU_NF_REFERENCIA," & _
                             "M.DT_NF_REFERENCIA," & _
                             "M.QT_KG_NF," & _
                             "M.QT_KG_BRUTO_NF," & _
                             "M.QT_KG_LIQUIDO_NF," & _
                             "M.QT_DESCONTO_QUALIDADE," & _
                             "M.QT_KG_A_TRANSFERIR," & _
                             "M.VL_NF," & _
                             "M.VL_NF_ICMS," & _
                             "M.VL_NF_FUNRURAL," & _
                             "M.QT_KG_SOBRA," & _
                           "FIL.NO_FILIAL," & _
                          "FILO.NO_FILIAL AS NO_FILIAL_ORIGEM," & _
                           "FFN.NO_FILIAL AS NO_FILIAL_FORNECEDOR," & _
                         "MUNIC.NO_CIDADE || ' - ' || MUNIC.CD_UF AS NO_MUNICIPIO," & _
                             "M.CD_TIPO_NF," & _
                            "LE.NO_LOCAL_ENTREGA," & _
                             "M.CD_PROCEDENCIA," & _
                             "M.NU_ORDEM_DESCARGA," & _
                             "M.SQ_ITEM_MOV_BANCARIO," & _
                             "M.SQ_MOVIMENTACAO," & _
                             "M.CD_FILIAL_MOVIMENTACAO," & _
                            "TM.IC_VALIDA_VALOR" & _
                  " FROM SOF.MOVIMENTACAO M," & _
                        "SOF.TIPO_MOVIMENTACAO TM," & _
                        "SOF.FILIAL FIL," & _
                        "SOF.FILIAL FILO," & _
                        "SOF.FILIAL FFN," & _
                        "SOF.MUNICIPIO MUNIC," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.LOCAL_ENTREGA LE" & _
                  " WHERE M.CD_TIPO_MOVIMENTACAO = TM.CD_TIPO_MOVIMENTACAO" & _
                    " AND NVL(TM.IC_TIPO_UTILIZACAO, 'X') NOT IN ('T')" & _
                    " AND M.CD_FILIAL_MOVIMENTACAO = FIL.CD_FILIAL " & _
                    " AND FILO.CD_FILIAL (+) = M.CD_FILIAL_ORIGEM" & _
                    " AND MUNIC.CD_MUNICIPIO (+) = M.CD_MUNICIPIO_ORIGEM" & _
                    " AND F.CD_FORNECEDOR (+) = M.CD_FORNECEDOR" & _
                    " AND LE.CD_LOCAL_ENTREGA (+) = M.CD_LOCAL_ENTREGA" & _
                    " AND FFN.CD_FILIAL (+) = F.CD_FILIAL_ORIGEM"

        If SelecaoTipoNovimentacao.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND M.CD_TIPO_MOVIMENTACAO IN (" & SelecaoTipoNovimentacao.Lista_ID & ")"
        End If
        If Pesq_Fornecedor.Codigo > 0 Then
            SqlText = SqlText & " AND M.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo
        End If
        If IsDate(txtDataInicial.Value) Then
            SqlText = SqlText & " AND M.DT_MOVIMENTACAO >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Value))
        End If
        If IsDate(txtDataFinal.Value) Then
            SqlText = SqlText & " AND M.DT_MOVIMENTACAO <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Value))
        End If

        If SelecaoEstadoOrigem.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND MUNIC.CD_UF IN (" & SelecaoEstadoOrigem.Lista_ID & ")"
        End If

        If SelecaoFilial.Lista_Quantidade > 0 Then
            SqlText = SqlText & " AND M.CD_FILIAL_MOVIMENTACAO IN (" & SelecaoFilial.Lista_ID & ")"
        Else
            If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_ListarMovimentacoesTodasFiliais) Then
                SqlText = SqlText & " AND (M.CD_FILIAL_MOVIMENTACAO IN (" & ListarIDFiliaisLiberadaUsuario() & ") OR F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")) "
            End If
        End If
        If Trim(txtOrdemDescarga.Text) <> "" Then
            SqlText = SqlText & " AND M.NU_ORDEM_DESCARGA = " & QuotedStr(Trim(txtOrdemDescarga.Text))
        End If
        If Trim(txtNotaFiscal.Text) <> "" Then
            SqlText = SqlText & " AND M.NU_NF = " & QuotedStr(Trim(txtNotaFiscal.Text))
        End If

        AVI_Carregar(Me)

        DBQuery_Append(oDS.Tables(0), SqlText, True)

        objGrid_ExibirTotal(grdGeral, New Integer() {cnt_GridGeral_qt_KG_NF, cnt_GridGeral_qt_KG_Bruto_NF, cnt_GridGeral_qt_KG_Liquido_NF, _
                                                     cnt_GridGeral_qt_Desconto_Qualidade, cnt_GridGeral_qt_KG_A_Transferir, _
                                                     cnt_GridGeral_vl_NF, cnt_GridGeral_vl_NF_ICMS, cnt_GridGeral_vl_NF_Funrural, _
                                                     cnt_GridGeral_qt_KG_Sobra})

        AVI_Fechar(Me)
    End Sub

    Private Sub frmConsultaMovimentacaoCacau_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdNovo.Top = Me.ClientSize.Height - cmdNovo.Height - 6
        cmdAlterar.Top = Me.ClientSize.Height - cmdAlterar.Height - 6
        cmdICMS.Top = Me.ClientSize.Height - cmdAlterar.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcluir.Height - 6
        cmdRastreabilidade.Top = Me.ClientSize.Height - cmdRastreabilidade.Height - 6
        cmdPilha.Top = Me.ClientSize.Height - cmdPilha.Height - 6
        cmdInformacoes.Top = Me.ClientSize.Height - cmdInformacoes.Height - 6
        cmdNFReferencia.Top = Me.ClientSize.Height - cmdNFReferencia.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdUsuario.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdObsAcerto.Top = Me.ClientSize.Height - cmdObsAcerto.Height - 6
        cmdLivroFiscal.Top = Me.ClientSize.Height - cmdLivroFiscal.Height - 6
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        Auditoria(TipoCampoFixo.Todos, "MOVIMENTACAO", "SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao))
    End Sub

    Private Sub cmdNFReferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNFReferencia.Click
        mnuNFReferencia.Show(cmdNFReferencia, Nothing)
    End Sub

    Private Sub mnuNFReferencia_Incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNFReferencia_Incluir.Click
        If grdGeral.Selected.Rows.Count = 0 Then
            Msg_Mensagem("Favor selecionar pelo menos uma linha.")
            Exit Sub
        End If

        Dim iCont As Integer
        Dim sMens As String = ""

        oForm_NfReferencia = New frmMovimentacaoCacau_NFReferencia

        oForm_NfReferencia.FormatarTela()

        For iCont = 0 To grdGeral.Selected.Rows.Count - 1
            With grdGeral.Selected.Rows(iCont)
                If NVL(.Cells(cnt_GridGeral_nu_NF).Value, "N") = "N" Then
                    sMens = "A movimentação " & Trim(.Cells(cnt_GridGeral_nu_NF).Value) & " de " & _
                                                Trim(.Cells(cnt_GridGeral_no_Razao_Social).Value) & _
                                                " não pode possuir NF de referência."

                    Msg_Mensagem(sMens)
                    GoTo Sair
                Else
                    oForm_NfReferencia.Movimentacao_Adicionar(.Cells(cnt_GridGeral_sq_Movimentacao).Value, _
                                                              .Cells(cnt_GridGeral_nu_NF).Value, _
                                                              .Cells(cnt_GridGeral_dt_Movimentacao).Value, _
                                                              .Cells(cnt_GridGeral_no_Razao_Social).Value, _
                                                              .Cells(cnt_GridGeral_vl_NF).Value, _
                                                              .Cells(cnt_GridGeral_qt_KG_NF).Value)
                End If
            End With
        Next

        Form_Show(Me.MdiParent, oForm_NfReferencia)

        Exit Sub

Sair:
        oForm_NfReferencia.Dispose()
        oForm_NfReferencia = Nothing
    End Sub

    Private Sub mnuNFReferencia_Apagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNFReferencia_Apagar.Click
        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If Msg_Perguntar("Retira a NF de referencia das movimentações ?") = False Then Exit Sub

        SqlText = "update sof.movimentacao set nu_nf_referencia=NULL" & _
                  ", dt_nf_referencia=NULL" & _
                  " where sq_movimentacao=" & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
        If Not DBExecutar(SqlText) Then GoTo erro

        Pesquisar()

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub oForm_NfReferencia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm_NfReferencia.FormClosing
        Pesquisar()
    End Sub

    Private Sub cmdObsAcerto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdObsAcerto.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If objDataTable_CampoVazio(objGrid_Valor(grdGeral, cnt_GridGeral_nu_NF)) Then
            Msg_Mensagem("Esta movimentação não é de acerto. (NULL)")
            Exit Sub
        End If
        If Mid(objGrid_Valor(grdGeral, cnt_GridGeral_nu_NF), 1, 1) <> "A" Then
            Msg_Mensagem("Esta movimentação não é de acerto. (NF)")
            Exit Sub
        End If

        Dim oForm As New frmMovimentacaoCacau_ObsAcerto
        oForm.SQ_MOVIMENTACAO = objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)

        Form_Show(Me.MdiParent, oForm)
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oForm As New frmConsultaMovimentacao_Alteracao

        oForm.SQ_Movimentacao = objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)

        Form_Show(Me.MdiParent, oForm)
    End Sub

    Private Sub cmdICMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdICMS.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Dim oData As DataTable
        Dim SqlText As String
        Dim CdConc As Integer

        SqlText = " select * from sof.pag_amarracao_icms p where p.sq_movimentacao=" & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)

        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            If Msg_Perguntar("Essa NF já foi amarrada a um pagamento.Deseja  desamarrar ?") = False Then Exit Sub

            DBUsarTransacao = True

            CdConc = oData.Rows(0).Item("sq_conciliacao")

            'elimino a amarração
            SqlText = "delete from sof.pag_amarracao_icms where sq_conciliacao=" & CdConc
            If Not DBExecutar(SqlText) Then GoTo Erro

            'desaplico o da conciliacao
            SqlText = "DELETE FROM SOF.CONCILIACAO_PAGAMENTO " & _
                  "WHERE SQ_CONCILIACAO = " & CdConc

            If Not DBExecutar(SqlText) Then GoTo Erro

            'elimino a conciliacao
            SqlText = "delete from sof.conciliacao where sq_conciliacao=" & CdConc
            If Not DBExecutar(SqlText) Then GoTo Erro

            'atualizo a movimentação
            SqlText = "update sof.movimentacao m "
            SqlText = SqlText & "set m.ic_icms_pago='N' "
            SqlText = SqlText & "where m.sq_movimentacao= " & oData.Rows(0).Item("sq_movimentacao")

            If Not DBExecutar(SqlText) Then GoTo Erro

            'atualizo o pagamento
            SqlText = "update sof.pagamentos p "
            SqlText = SqlText & " set p.ic_icms_pago='N', "
            SqlText = SqlText & " p.sq_movimentacao=null "
            SqlText = SqlText & " where p.sq_pagamento= " & oData.Rows(0).Item("sq_pagamento")

            If Not DBExecutar(SqlText) Then GoTo Erro

            If Not DBExecutarTransacao() Then GoTo Erro


            Msg_Mensagem("NF desamarrada.")
        Else
            SqlText = " select * from sof.movimentacao m where m.sq_movimentacao=" & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)

            oData = DBQuery(SqlText)


            If Msg_Perguntar("Esse movimentação esta " & IIf(oData.Rows(0).Item("ic_icms_pago") = "N", " disponivel ", " indisponivel ") & " para Amarração.Deseja Alterar?") = False Then Exit Sub


            'atualizo a movimentação
            SqlText = "update sof.movimentacao m "
            SqlText = SqlText & "set m.ic_icms_pago='" & IIf(oData.Rows(0).Item("ic_icms_pago") = "N", "S", "N") & "' "
            SqlText = SqlText & "where m.sq_movimentacao= " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)

            If Not DBExecutar(SqlText) Then GoTo Erro

            Msg_Mensagem("NF atualizada.")
        End If

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub cmdLivroFiscal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLivroFiscal.Click
        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        SqlText = "SELECT COUNT(*) FROM SOF.INTERFACE_LIVRO_FISCAL WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)

        If DBQuery_ValorUnico(SqlText) = 0 Then
            Msg_Mensagem("Não foi realizada interface dessa movimentação ainda")
        Else
            SqlText = "DELETE FROM SOF.INTERFACE_LIVRO_FISCAL WHERE SQ_MOVIMENTACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_sq_Movimentacao)
            If Not DBExecutar(SqlText) Then GoTo Erro

            Msg_Mensagem("Movimentação excluída do envio para interface de livro fiscal")
        End If

        Exit Sub

Erro:
        TratarErro(, , "frmConsultaMovimentacaoCacau.cmdLivroFiscal_Click")
    End Sub
End Class
