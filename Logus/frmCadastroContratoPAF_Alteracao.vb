Public Class frmCadastroContratoPAF_Alteracao
    Const cnt_Campo_Nulo As Integer = 10000

    Public Cancelado As Boolean = False
    Public CD_CONTRATO_PAF As Integer
    Dim DT_CONTRATO_PAF As Date
    Dim DT_ASSINATURA_CONTRATO As Date
    Dim SQ_ADITIVO As Integer

    Private Sub cmdGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If Pesq_Repassador.Codigo = 0 Then
            Msg_Mensagem("Favor informar um repassador")
            Exit Sub
        End If
        If Not IsDate(txtDataEntrega.Text) Then
            Msg_Mensagem("Prazo de entrega invalido.")
            txtDataEntrega.Focus()
            Exit Sub
        End If
        If Trim(txtSubLedgerCP.Text) <> "" Then
            If txtTipoSubLedgerCP.Text = "" Then
                Msg_Mensagem("Favor informar um tipo do Sub Ledger C/P")
                txtTipoSubLedgerCP.Focus()
                Exit Sub
            End If
        End If

        On Error GoTo Erro

        Dim SqlText As String
        Dim Parametro_CTR(9) As DBParamentro
        Dim Parametro_Aditivo(7) As DBParamentro
        Dim QT_A_NEGOCIAR As Double

        SqlText = "SELECT QT_A_NEGOCIAR FROM SOF.CONTRATO_PAF" & _
                  " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF
        QT_A_NEGOCIAR = Val(DBQuery_ValorUnico(SqlText, 0))

        If QT_A_NEGOCIAR < Val(txtQuantidade.Tag) - txtQuantidade.Value Then
            Msg_Mensagem("Não existe quantidade a negociar suficiente para essa redução de quantidade")
            Exit Sub
        End If

        DBUsarTransacao = True

        '>> Alteração do cadastro
        SqlText = DBMontar_Update("SOF.CONTRATO_PAF", GerarArray("CD_REPASSADOR", ":CD_REPASSADOR", _
                                                                 "CD_FORNECEDOR_BENEFICIADO", ":CD_FORNECEDOR_BENEFICIADO", _
                                                                 "DT_ASSINATURA_CONTRATO", ":DT_ASSINATURA_CONTRATO", _
                                                                 "DT_PRAZO_FIXACAO", ":DT_PRAZO_FIXACAO", _
                                                                 "DT_PRAZO_ENTREGA", ":DT_PRAZO_ENTREGA", _
                                                                 "QT_KGS", ":QT_KGS", _
                                                                 "QT_A_NEGOCIAR", ":QT_A_NEGOCIAR", _
                                                                 "CD_SUB_LEDGER_CP", ":CD_SUB_LEDGER_CP", _
                                                                 "CD_TIPO_SUB_LEDGER_CP", ":CD_TIPO_SUB_LEDGER_CP"), _
                                                      GerarArray("CD_CONTRATO_PAF", ":CD_CONTRATO_PAF"))

        Parametro_CTR(0) = DBParametro_Montar("CD_REPASSADOR", Pesq_Repassador.Codigo)
        If Pesq_FornecedorBeneficiario.Codigo = 0 Then
            Parametro_CTR(1) = DBParametro_Montar("CD_FORNECEDOR_BENEFICIADO", Nothing)
        Else
            Parametro_CTR(1) = DBParametro_Montar("CD_FORNECEDOR_BENEFICIADO", Pesq_FornecedorBeneficiario.Codigo)
        End If
        If IsDate(txtDataAssinaturaContrato.Text) Then
            Parametro_CTR(2) = DBParametro_Montar("DT_ASSINATURA_CONTRATO", Date_to_Oracle(txtDataAssinaturaContrato.Text))
        Else
            Parametro_CTR(2) = DBParametro_Montar("DT_ASSINATURA_CONTRATO", Nothing)
        End If
        If IsDate(txtDataFixacao.Text) Then
            Parametro_CTR(3) = DBParametro_Montar("DT_PRAZO_FIXACAO", Date_to_Oracle(txtDataFixacao.Text))
        Else
            Parametro_CTR(3) = DBParametro_Montar("DT_PRAZO_FIXACAO", Nothing)
        End If
        If IsDate(txtDataEntrega.Text) Then
            Parametro_CTR(4) = DBParametro_Montar("DT_PRAZO_ENTREGA", Date_to_Oracle(txtDataEntrega.Text))
        Else
            Parametro_CTR(4) = DBParametro_Montar("DT_PRAZO_ENTREGA", Nothing)
        End If
        Parametro_CTR(5) = DBParametro_Montar("QT_KGS", txtQuantidade.Value)
        Parametro_CTR(6) = DBParametro_Montar("QT_A_NEGOCIAR", QT_A_NEGOCIAR + txtQuantidade.Value - Val(txtQuantidade.Tag))
        Parametro_CTR(7) = DBParametro_Montar("CD_SUB_LEDGER_CP", NULLIf(Trim(txtSubLedgerCP.Text), ""))
        Parametro_CTR(8) = DBParametro_Montar("CD_TIPO_SUB_LEDGER_CP", NULLIf(Trim(txtTipoSubLedgerCP.Text), ""))
        Parametro_CTR(9) = DBParametro_Montar("CD_CONTRATO_PAF", CD_CONTRATO_PAF)

        If Not DBExecutar(SqlText, Parametro_CTR) Then GoTo Erro

        If NVL(txtDataFixacao.Text, "") <> NVL(txtDataFixacao.Tag, "") Or _
           NVL(txtDataEntrega.Text, "") <> NVL(txtDataEntrega.Tag, "") Or _
           txtQuantidade.Value <> txtQuantidade.Tag Then
            '>> Criação de aditivo
            SqlText = DBMontar_Insert("SOF.CONTRATO_ADITIVO", TipoCampoFixo.Todos, _
                                                              "CD_CONTRATO_PAF", ":CD_CONTRATO_PAF", _
                                                              "SQ_ADITIVO", ":SQ_ADITIVO", _
                                                              "DT_PRAZO_FIXACAO", ":DT_PRAZO_FIXACAO", _
                                                              "DT_PRAZO_FIXACAO_OLD", ":DT_PRAZO_FIXACAO_OLD", _
                                                              "DT_PRAZO_ENTREGA", ":DT_PRAZO_ENTREGA", _
                                                              "DT_PRAZO_ENTREGA_OLD", ":DT_PRAZO_ENTREGA_OLD", _
                                                              "QT_KGS", ":QT_KGS", _
                                                              "QT_KGS_OLD", ":QT_KGS_OLD")

            Parametro_Aditivo(0) = DBParametro_Montar("CD_CONTRATO_PAF", CD_CONTRATO_PAF)
            Parametro_Aditivo(1) = DBParametro_Montar("SQ_ADITIVO", SQ_ADITIVO + 1)
            If NVL(txtDataFixacao.Text, "") <> NVL(txtDataFixacao.Tag, "") Then
                Parametro_Aditivo(2) = DBParametro_Montar("DT_PRAZO_FIXACAO", Date_to_Oracle(txtDataFixacao.Text))
                If IsDate(txtDataFixacao.Tag) Then
                    Parametro_Aditivo(3) = DBParametro_Montar("DT_PRAZO_FIXACAO_OLD", Date_to_Oracle(txtDataFixacao.Tag))
                Else
                    Parametro_Aditivo(3) = DBParametro_Montar("DT_PRAZO_FIXACAO_OLD", Nothing)
                End If
            Else
                Parametro_Aditivo(2) = DBParametro_Montar("DT_PRAZO_FIXACAO", Nothing)
                Parametro_Aditivo(3) = DBParametro_Montar("DT_PRAZO_FIXACAO_OLD", Nothing)
            End If
            If NVL(txtDataEntrega.Text, "") <> NVL(txtDataEntrega.Tag, "") Then
                Parametro_Aditivo(4) = DBParametro_Montar("DT_PRAZO_ENTREGA", Date_to_Oracle(txtDataEntrega.Text))
                If IsDate(txtDataEntrega.Tag) Then
                    Parametro_Aditivo(5) = DBParametro_Montar("DT_PRAZO_ENTREGA_OLD", Date_to_Oracle(txtDataEntrega.Tag))
                Else
                    Parametro_Aditivo(5) = DBParametro_Montar("DT_PRAZO_ENTREGA_OLD", Nothing)
                End If
            Else
                Parametro_Aditivo(4) = DBParametro_Montar("DT_PRAZO_ENTREGA", Nothing)
                Parametro_Aditivo(5) = DBParametro_Montar("DT_PRAZO_ENTREGA_OLD", Nothing)
            End If
            If txtQuantidade.Value <> txtQuantidade.Tag Then
                Parametro_Aditivo(6) = DBParametro_Montar("QT_KGS", txtQuantidade.Value)
                Parametro_Aditivo(7) = DBParametro_Montar("QT_KGS_OLD", NVL(txtQuantidade.Tag, 0))
            Else
                Parametro_Aditivo(6) = DBParametro_Montar("QT_KGS", Nothing)
                Parametro_Aditivo(7) = DBParametro_Montar("QT_KGS_OLD", Nothing)
            End If

            If Not DBExecutar(SqlText, Parametro_Aditivo) Then GoTo Erro
        End If

        If Not DBExecutarTransacao() Then GoTo Erro

        Cancelado = False

        Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Cancelado = True
        Close()
    End Sub

    Private Sub frmCadastroContratoPAF_Alteracao_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SqlText As String
        Dim oData As DataTable

        Me.Text = Me.Text & " - Ctr. " & CD_CONTRATO_PAF

        Pesq_Repassador.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        Pesq_Repassador.BancoDados_Filtro_Limpar()
        Pesq_Repassador.BancoDados_Filtro_Adicionar("F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")")
        Pesq_Repassador.ModoEdicao = False

        Pesq_FornecedorBeneficiario.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        Pesq_FornecedorBeneficiario.BancoDados_Filtro_Limpar()
        Pesq_FornecedorBeneficiario.BancoDados_Filtro_Adicionar("F.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")")

        'Pega o número do aditivo atual
        SqlText = "SELECT MAX(SQ_ADITIVO) FROM SOF.CONTRATO_ADITIVO" & _
                  " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND SQ_NEGOCIACAO IS NULL"
        SQ_ADITIVO = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT PAF.CD_TIPO_CONTRATO_PAF," & _
                         "PAF.DT_CONTRATO_PAF," & _
                         "PAF.CD_REPASSADOR," & _
                         "PAF.CD_FORNECEDOR_BENEFICIADO," & _
                         "PAF.CD_SUB_LEDGER_CP," & _
                         "PAF.CD_TIPO_SUB_LEDGER_CP," & _
                         "NVL(ADV.QT_KGS, PAF.QT_KGS) QT_KGS," & _
                         "NVL(ADV.DT_PRAZO_ENTREGA, PAF.DT_PRAZO_ENTREGA) DT_PRAZO_ENTREGA," & _
                         "NVL(ADV.DT_PRAZO_FIXACAO, PAF.DT_PRAZO_FIXACAO) DT_PRAZO_FIXACAO," & _
                         "PAF.DT_ASSINATURA_CONTRATO," & _
                         "PAF.CD_CONTRATO_PAF_ORIGEM" & _
                  " FROM SOF.CONTRATO_PAF PAF," & _
                        "(SELECT *" & _
                         " FROM SOF.CONTRATO_ADITIVO" & _
                         " WHERE SQ_ADITIVO = " & SQ_ADITIVO & _
                           " AND SQ_NEGOCIACAO IS NULL) ADV" & _
                  " WHERE PAF.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND ADV.CD_CONTRATO_PAF (+) = PAF.CD_CONTRATO_PAF"
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            With oData.Rows(0)
                Pesq_Repassador.Codigo = objDataTable_LerCampo(.Item("CD_REPASSADOR"), 0)
                Pesq_FornecedorBeneficiario.Codigo = objDataTable_LerCampo(.Item("CD_FORNECEDOR_BENEFICIADO"), 0)
                txtQuantidade.Value = .Item("QT_KGS")
                txtQuantidade.Tag = .Item("QT_KGS")
                txtDataEntrega.Text = .Item("DT_PRAZO_ENTREGA")
                txtDataEntrega.Tag = .Item("DT_PRAZO_ENTREGA")
                DT_CONTRATO_PAF = .Item("DT_CONTRATO_PAF")

                If Not CampoNulo(.Item("DT_PRAZO_FIXACAO")) Then
                    txtDataFixacao.Text = .Item("DT_PRAZO_FIXACAO")
                    txtDataFixacao.Tag = .Item("DT_PRAZO_FIXACAO")
                End If
                If CampoNulo(.Item("DT_ASSINATURA_CONTRATO")) Then
                    txtDataAssinaturaContrato.Tag = cnt_Campo_Nulo
                Else
                    txtDataAssinaturaContrato.Text = .Item("DT_ASSINATURA_CONTRATO")
                    txtDataAssinaturaContrato.Tag = .Item("DT_ASSINATURA_CONTRATO")
                End If

                txtSubLedgerCP.Text = NVL(.Item("CD_SUB_LEDGER_CP"), "")
                txtTipoSubLedgerCP.Text = NVL(.Item("CD_TIPO_SUB_LEDGER_CP"), "")
            End With
        End If

        cmdFechar.Focus()
    End Sub

    Private Sub txtDataAssinaturaContrato_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDataAssinaturaContrato.LostFocus
        If IsDate(txtDataAssinaturaContrato.Text) Then
            If txtDataAssinaturaContrato.DateTime.Date < DT_CONTRATO_PAF Then
                Msg_Mensagem("A data de assinatura do contrato não pode ser menor que a data do contrato")

                If Not IsDate(txtDataAssinaturaContrato.Tag) Then
                    txtDataAssinaturaContrato.Text = ""
                Else
                    txtDataAssinaturaContrato.DateTime = txtDataAssinaturaContrato.Tag
                End If
            Else
                If IsDate(txtDataAssinaturaContrato.Text) Then
                    If txtDataAssinaturaContrato.DateTime.AddMonths(cnt_Contrato_Master_TempoFixacao_Mes).Date > txtDataFixacao.DateTime.Date Then
                        txtDataFixacao.Text = txtDataAssinaturaContrato.DateTime.AddMonths(cnt_Contrato_Master_TempoFixacao_Mes).ToString.Substring(0, 10)
                    End If
                End If
            End If
        End If
    End Sub
End Class