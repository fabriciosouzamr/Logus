Public Class frmConsultaReNegociacao
    Const cnt_GridGeral_SIT As Integer = 0
    Const cnt_GridGeral_Seq As Integer = 1
    Const cnt_GridGeral_Data As Integer = 2
    Const cnt_GridGeral_Kgs As Integer = 3
    Const cnt_GridGeral_Valor As Integer = 4
    Const cnt_GridGeral_Papel_Bolsa As Integer = 5
    Const cnt_GridGeral_TipoPreco As Integer = 6
    Const cnt_GridGeral_TipoUnidade As Integer = 7
    Const cnt_GridGeral_AliqICMS As Integer = 8
    Const cnt_GridGeral_PreçoFrete As Integer = 9
    Const cnt_GridGeral_Taxa_Juros As Integer = 10
    Const cnt_GridGeral_CalculaJuros As Integer = 11
    Const cnt_GridGeral_DiasCarencia As Integer = 12
    Const cnt_GridGeral_JurosAposCarencia As Integer = 13
    Const cnt_GridGeral_PrazoFixacao As Integer = 14
    Const cnt_GridGeral_LocalEntrega As Integer = 15
    Const cnt_GridGeral_FilialEntrega As Integer = 16
    Const cnt_GridGeral_DataVencimento As Integer = 17
    Const cnt_GridGeral_DataPagamento As Integer = 18
    Const cnt_GridGeral_TipoNegociacao As Integer = 19
    Const cnt_GridGeral_Safra As Integer = 20
    Const cnt_GridGeral_Bonus As Integer = 21
    Const cnt_GridGeral_Papel As Integer = 22
    Const cnt_GridGeral_ValorBolsa As Integer = 23
    Const cnt_GridGeral_ValorBolsaAlternativo As Integer = 24
    Const cnt_GridGeral_TaxaUS As Integer = 25
    Const cnt_GridGeral_TaxaUSAlternativa As Integer = 26
    Const cnt_GridGeral_Diferencial As Integer = 27
    Const cnt_GridGeral_TipoCacau As Integer = 28
    Const cnt_GridGeral_NO_USER_CRIACAO As Integer = 29
    Const cnt_GridGeral_DS_MOTIVO_DT_VENC As Integer = 30
    Const cnt_GridGeral_DS_MOTIVO_RENEGOCIACAO As Integer = 31
    Const cnt_GridGeral_DS_MOTIVO_REPROVACAO As Integer = 32
    Const cnt_GridGeral_CD_CONTRATO_PAF As Integer = 33
    Const cnt_GridGeral_SQ_NEGOCIACAO_NOVA As Integer = 34

    Public CD_CONTRATO_PAF As Integer
    Public SQ_NEGOCIACAO As Integer

    Dim oDS As New Infragistics.Win.UltraWinDataSource.UltraDataSource

    Private Sub frmConsultaReNegociacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        objGrid_Inicializar(grdGeral, , oDS)
        objGrid_Coluna_Add(grdGeral, "SIT", 45)
        objGrid_Coluna_Add(grdGeral, "Seq", 50)
        objGrid_Coluna_Add(grdGeral, "Data", 70)
        objGrid_Coluna_Add(grdGeral, "Kgs", 70, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Valor", 100, , , , , cnt_Formato_Valor_US)
        objGrid_Coluna_Add(grdGeral, "Papel - Bolsa", 80)
        objGrid_Coluna_Add(grdGeral, "Tipo Preço", 100)
        objGrid_Coluna_Add(grdGeral, "Tipo Unidade", 87)
        objGrid_Coluna_Add(grdGeral, "Aliq ICMS", 105)
        objGrid_Coluna_Add(grdGeral, "Preço Frete", 80)
        objGrid_Coluna_Add(grdGeral, "Taxa de Juros", 95, , , , , cnt_Formato_Fracao)
        objGrid_Coluna_Add(grdGeral, "Calcula Juros ?", 100)
        objGrid_Coluna_Add(grdGeral, "Dias de Carência", 100)
        objGrid_Coluna_Add(grdGeral, "Juros Após Carência", 125)
        objGrid_Coluna_Add(grdGeral, "Prazo Fixação", 150)
        objGrid_Coluna_Add(grdGeral, "Local Entrega", 105)
        objGrid_Coluna_Add(grdGeral, "Filial Entrega", 125)
        objGrid_Coluna_Add(grdGeral, "Data Vencimento", 120)
        objGrid_Coluna_Add(grdGeral, "Data Pagamento", 125)
        objGrid_Coluna_Add(grdGeral, "Tipo Negociação", 110)
        objGrid_Coluna_Add(grdGeral, "Safra", 65)
        objGrid_Coluna_Add(grdGeral, "Bônus", 50)
        objGrid_Coluna_Add(grdGeral, "Papel", 90)
        objGrid_Coluna_Add(grdGeral, "Valor Bolsa", 170)
        objGrid_Coluna_Add(grdGeral, "Valor Bolsa Alternativo", 65)
        objGrid_Coluna_Add(grdGeral, "Taxa US", 140)
        objGrid_Coluna_Add(grdGeral, "Taxa US Alternativa", 80)
        objGrid_Coluna_Add(grdGeral, "Diferencial", 105)
        objGrid_Coluna_Add(grdGeral, "Tipo de Cacau", 120)
        objGrid_Coluna_Add(grdGeral, "Usuário Criação", 180)
        objGrid_Coluna_Add(grdGeral, "DS_MOTIVO_DT_VENC", 0)
        objGrid_Coluna_Add(grdGeral, "DS_MOTIVO_RENEGOCIACAO", 0)
        objGrid_Coluna_Add(grdGeral, "DS_MOTIVO_REPROVACAO", 0)
        objGrid_Coluna_Add(grdGeral, "CD_CONTRATO_PAF", 0)
        objGrid_Coluna_Add(grdGeral, "SQ_NEGOCIACAO_NOVA", 0)

        'Verifica se será possível fazer renegociacao - Início
        SqlText = "SELECT NVL(IC_STATUS, 'N') FROM SOF.NEGOCIACAO" & _
                  " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND SQ_NEGOCIACAO = " & SQ_NEGOCIACAO

        cmdNovo.Enabled = (DBQuery_ValorUnico(SqlText) = "A")

        SEC_ValidarBotao_Permissao(cmdNovo, SEC_Permissao.SEC_P_Acesso_CadastroRenegociacao_Solicitar, True)
        'Verifica se será possível fazer renegociacao - Fim

        Me.Text = Me.Text & " - Contrato Nº: " & Trim(CD_CONTRATO_PAF) & "-" & Trim(SQ_NEGOCIACAO)

        Pesquisar()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub Pesquisar()
        Dim SqlText As String

        SqlText = "SELECT SR.IC_STATUS_APROVACAO," & _
                         "SR.SQ_SOLICITACAO," & _
                         "SR.DT_SOLICITACAO," & _
                         "SR.QT_KGS," & _
                         "SR.VL_NEGOCIACAO," & _
                         "SR.CD_PAPEL_COMPETENCIA," & _
                         "TP.NO_TIPO_PRECO," & _
                         "TU.NO_TIPO_UNIDADE," & _
                         "SR.PC_ALIQ_ICMS," & _
                         "SR.VL_PRECO_FRETE," & _
                         "SR.PC_TAXA_JUROS," & _
                         "SR.IC_CALCULA_JUROS," & _
                         "SR.QT_DIA_CARENCIA_JUROS," & _
                         "SR.IC_JUROS_APOS_CARENCIA," & _
                         "SR.DT_PRAZO_FIXACAO," & _
                         "LE.NO_LOCAL_ENTREGA," & _
                         "FE.NO_FILIAL NO_FILIAL_ENTREGA," & _
                         "SR.DT_VENCIMENTO," & _
                         "SR.DT_PAGAMENTO," & _
                         "TN.NO_TIPO_NEGOCIACAO," & _
                         "S.DS_SAFRA," & _
                         "SR.IC_BONUS," & _
                         "SR.CD_PAPEL," & _
                         "SR.VL_BOLSA," & _
                         "SR.VL_BOLSA_ALTERNATIVO," & _
                         "SR.VL_TAXA_DOLAR," & _
                         "SR.VL_TAXA_DOLAR_ALTERNATIVO," & _
                         "SR.VL_DIFERENCIAL," & _
                         "TC.NO_TIPO_CACAU," & _
                         "SR.NO_USER_CRIACAO," & _
                         "SR.DS_MOTIVO_DT_VENC," & _
                         "SR.DS_MOTIVO_RENEGOCIACAO," & _
                         "SR.DS_MOTIVO_REPROVACAO," & _
                         "SR.CD_CONTRATO_PAF," & _
                         "SR.SQ_NEGOCIACAO_NOVA" & _
                  " FROM SOF.SOLICITACAO_RENEGOCIACAO SR," & _
                        "SOF.LOCAL_ENTREGA LE," & _
                        "SOF.TIPO_UNIDADE TU," & _
                        "SOF.TIPO_PRECO TP," & _
                        "SOF.SAFRA S," & _
                        "SOF.TIPO_NEGOCIACAO TN," & _
                        "SOF.FILIAL FE," & _
                        "SOF.TIPO_CACAU TC" & _
                  " WHERE SR.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND SR.SQ_NEGOCIACAO = " & SQ_NEGOCIACAO & _
                    " AND LE.CD_LOCAL_ENTREGA = SR.CD_LOCAL_ENTREGA" & _
                    " AND TU.CD_TIPO_UNIDADE = SR.CD_TIPO_UNIDADE" & _
                    " AND TP.CD_TIPO_PRECO = SR.CD_TIPO_PRECO" & _
                    " AND S.CD_SAFRA = SR.CD_SAFRA" & _
                    " AND TN.CD_TIPO_NEGOCIACAO = SR.CD_TIPO_NEGOCIACAO" & _
                    " AND FE.CD_FILIAL (+) = SR.CD_FILIAL_ENTREGA" & _
                    " AND TC.CD_TIPO_CACAU (+) = SR.CD_TIPO_CACAU" & _
                  " ORDER BY SR.SQ_SOLICITACAO"
        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_SIT, _
                                                           cnt_GridGeral_Seq, _
                                                           cnt_GridGeral_Data, _
                                                           cnt_GridGeral_Kgs, _
                                                           cnt_GridGeral_Valor, _
                                                           cnt_GridGeral_Papel_Bolsa, _
                                                           cnt_GridGeral_TipoPreco, _
                                                           cnt_GridGeral_TipoUnidade, _
                                                           cnt_GridGeral_AliqICMS, _
                                                           cnt_GridGeral_PreçoFrete, _
                                                           cnt_GridGeral_Taxa_Juros, _
                                                           cnt_GridGeral_CalculaJuros, _
                                                           cnt_GridGeral_DiasCarencia, _
                                                           cnt_GridGeral_JurosAposCarencia, _
                                                           cnt_GridGeral_PrazoFixacao, _
                                                           cnt_GridGeral_LocalEntrega, _
                                                           cnt_GridGeral_FilialEntrega, _
                                                           cnt_GridGeral_DataVencimento, _
                                                           cnt_GridGeral_DataPagamento, _
                                                           cnt_GridGeral_TipoNegociacao, _
                                                           cnt_GridGeral_Safra, _
                                                           cnt_GridGeral_Bonus, _
                                                           cnt_GridGeral_Papel, _
                                                           cnt_GridGeral_ValorBolsa, _
                                                           cnt_GridGeral_ValorBolsaAlternativo, _
                                                           cnt_GridGeral_TaxaUS, _
                                                           cnt_GridGeral_TaxaUSAlternativa, _
                                                           cnt_GridGeral_Diferencial, _
                                                           cnt_GridGeral_TipoCacau, _
                                                           cnt_GridGeral_NO_USER_CRIACAO, _
                                                           cnt_GridGeral_DS_MOTIVO_DT_VENC, _
                                                           cnt_GridGeral_DS_MOTIVO_RENEGOCIACAO, _
                                                           cnt_GridGeral_DS_MOTIVO_REPROVACAO, _
                                                           cnt_GridGeral_CD_CONTRATO_PAF, _
                                                           cnt_GridGeral_SQ_NEGOCIACAO_NOVA})
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If Not Msg_Perguntar("Cancela a solicitação ?") Then Exit Sub

        Dim SqlText As String
        Dim DS_Motivo As String

        Dim oForm As New frmObservacao

        oForm.Carregar("Motivo de Cancelamento de Solicitação de Renegociação", "", True)
        Form_Show(Nothing, oForm, True, True)

        If oForm.Cancelado Then
            oForm.Dispose()
            Exit Sub
        End If

        DS_Motivo = oForm.DS_Motivo
        oForm.Dispose()

        On Error GoTo Erro

        DBUsarTransacao = True

        SqlText = "SELECT IC_STATUS_APROVACAO FROM SOF.SOLICITACAO_RENEGOCIACAO" & _
                  " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND SQ_NEGOCIACAO = " & SQ_NEGOCIACAO & _
                    " AND SQ_SOLICITACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Seq)
        If DBQuery_ValorUnico(SqlText) <> "W" Then
            DBUsarTransacao = False
            Msg_Mensagem("Não foi possível cancelar essa solicitação")
            Pesquisar()
            Exit Sub
        End If

        SqlText = "UPDATE SOF.SOLICITACAO_RENEGOCIACAO" & _
                  " SET IC_STATUS_APROVACAO = 'C'," & _
                       "DS_MOTIVO_REPROVACAO = " & QuotedStr(DS_Motivo) & _
                  " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND SQ_NEGOCIACAO = " & SQ_NEGOCIACAO & _
                    " AND SQ_SOLICITACAO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Seq)
        If Not DBExecutar(SqlText) Then GoTo Erro

        If Not DBExecutarTransacao() Then GoTo Erro

        Pesquisar()

        Exit Sub

Erro:
        TratarErro(, , "frmConsultaReNegociacao.cmdCancelar_Click")
    End Sub

    Private Sub grdGeral_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGeral.AfterRowActivate
        txtMotivoDataVencimentoAvancada.Text = ""
        txtRazoesRenegociacao.Text = ""
        txtRazoesReprovacao.Text = ""

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then Exit Sub

        txtMotivoDataVencimentoAvancada.Text = NVL(objGrid_Valor(grdGeral, cnt_GridGeral_DS_MOTIVO_DT_VENC), "")
        txtRazoesRenegociacao.Text = NVL(objGrid_Valor(grdGeral, cnt_GridGeral_DS_MOTIVO_RENEGOCIACAO), "")
        txtRazoesReprovacao.Text = NVL(objGrid_Valor(grdGeral, cnt_GridGeral_DS_MOTIVO_REPROVACAO), "")

        If objGrid_Valor(grdGeral, cnt_GridGeral_NO_USER_CRIACAO) = sAcesso_UsuarioLogado And _
           objGrid_Valor(grdGeral, cnt_GridGeral_SIT, , "N") = "W" Then
            cmdCancelar.Enabled = True
        Else
            cmdCancelar.Enabled = False
        End If
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        Dim oForm As New frmCadastroReNegociacao_Solicitacao

        oForm.CD_CONTRATO_PAF = CD_CONTRATO_PAF
        oForm.SQ_NEGOCIACAO = SQ_NEGOCIACAO
        Form_Show(Me, oForm, True, , True)
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If
        If objGrid_Valor(grdGeral, cnt_GridGeral_SIT) <> "A" Then
            Msg_Mensagem("Essa solicitação de renegociação não está aprovada.")
            Exit Sub
        End If

        Dim oForm As New frmRelatorioGeral

        oForm.Filtro01 = objGrid_Valor(grdGeral, cnt_GridGeral_CD_CONTRATO_PAF)
        oForm.Filtro02 = objGrid_Valor(grdGeral, cnt_GridGeral_SQ_NEGOCIACAO_NOVA)
        oForm.RelGeral_Tipo = frmRelatorioGeral.enRelGeral_Tipo.eNegociacao_Aditamento

        Form_Show(Nothing, oForm)
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        Pesquisar()
    End Sub
End Class