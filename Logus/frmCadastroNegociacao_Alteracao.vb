Public Class frmCadastroNegociacao_Alteracao
    Public Cancelado As Boolean = False
    Public CD_CONTRATO_PAF As Integer
    Public SQ_NEGOCIACAO As Integer
    Dim DT_CONTRATO_PAF As Date
    Dim DT_ASSINATURA_CONTRATO As Date
    Dim SQ_ADITIVO As Integer

    Private Sub cmdGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        On Error GoTo Erro

        Dim VLTOTAL As Double
        Dim VLICMS As Double
        Dim VLINSS As Double
        Dim VL_ADENDO_ICMS As Double
        Dim VL_ADENDO_INSS As Double
        Dim QT_A_FIXAR As Double

        Dim CD_PAPEL As String = ""
        Dim SqlText As String
        Dim Parametro_NEG(8) As DBParamentro
        Dim Parametro_FIX(11) As DBParamentro
        Dim Parametro_Aditivo(12) As DBParamentro
        Dim oData As DataTable

        If Not IsDate(txtDataEntrega.Text) Then
            Msg_Mensagem("Informe a data de entrega.")
            txtDataEntrega.Focus()
            Exit Sub
        End If
        If txtQuantidade.Value <= 0 Then
            Msg_Mensagem("Favor informar a quantidade em quilos da negociação acima de 0.")
            txtQuantidade.Focus()
            Exit Sub
        End If
        If cboBolsa.Enabled = False Then
            If txtValorUnitarioNegociacao.Value = 0 Then
                Msg_Mensagem("Favor informar um valor unitario.")
                txtValorUnitarioNegociacao.Focus()
                Exit Sub
            End If
        Else
            If Not ObjUltraComboBox_LinhaSelecionada(cboBolsa) Then
                Msg_Mensagem("Favor selecionar uma bolsa.")
                cboBolsa.Focus()
                Exit Sub
            End If
        End If

        SqlText = "SELECT QT_A_FIXAR FROM SOF.NEGOCIACAO" & _
                  " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND SQ_NEGOCIACAO = " & SQ_NEGOCIACAO
        QT_A_FIXAR = DBQuery_ValorUnico(SqlText, 0)

        If QT_A_FIXAR < Val(txtQuantidade.Tag) - txtQuantidade.Value Then
            Msg_Mensagem("Não existe quantidade a fixar suficiente para essa redução de quantidade")
            Exit Sub
        End If

        DBUsarTransacao = True

        If ObjUltraComboBox_LinhaSelecionada(cboBolsa) Then
            If cboBolsa.SelectedRow.Cells(0).Value <> NVL(cboBolsa.Tag, "") Then
                CD_PAPEL = cboBolsa.SelectedRow.Cells(0).Value
            End If
        End If

        '>> Alteração do cadastro
        SqlText = DBMontar_Update("SOF.NEGOCIACAO", GerarArray("CD_PAPEL", ":CD_PAPEL", _
                                                               "QT_KGS", ":QT_KGS", _
                                                               "VL_NEGOCIACAO", ":VL_NEGOCIACAO", _
                                                               "DT_VENCIMENTO", ":DT_VENCIMENTO", _
                                                               "DT_PRAZO_FIXACAO", ":DT_PRAZO_FIXACAO", _
                                                               "PC_ALIQ_ICMS", ":PC_ALIQ_ICMS", _
                                                               "QT_A_FIXAR", ":QT_A_FIXAR"), _
                                                    GerarArray("CD_CONTRATO_PAF", ":CD_CONTRATO_PAF", " AND ", _
                                                               "SQ_NEGOCIACAO", ":SQ_NEGOCIACAO"))

        Parametro_NEG(0) = DBParametro_Montar("CD_PAPEL", NULLIf(Trim(CD_PAPEL), ""))
        Parametro_NEG(1) = DBParametro_Montar("QT_KGS", txtQuantidade.Value)
        Parametro_NEG(2) = DBParametro_Montar("VL_NEGOCIACAO", txtValorUnitarioNegociacao.Value)
        If IsDate(txtDataEntrega.Text) Then
            Parametro_NEG(3) = DBParametro_Montar("DT_VENCIMENTO", Date_to_Oracle(txtDataEntrega.Text))
        Else
            Parametro_NEG(3) = DBParametro_Montar("DT_VENCIMENTO", Nothing)
        End If
        If IsDate(txtDataFixacao.Text) Then
            Parametro_NEG(4) = DBParametro_Montar("DT_PRAZO_FIXACAO", Date_to_Oracle(txtDataFixacao.Text))
        Else
            Parametro_NEG(4) = DBParametro_Montar("DT_PRAZO_FIXACAO", Nothing)
        End If
        Parametro_NEG(5) = DBParametro_Montar("PC_ALIQ_ICMS", txtAliquotaICMS.Value)
        Parametro_NEG(6) = DBParametro_Montar("QT_A_FIXAR", QT_A_FIXAR + txtQuantidade.Value - Val(txtQuantidade.Tag))
        Parametro_NEG(7) = DBParametro_Montar("CD_CONTRATO_PAF", CD_CONTRATO_PAF)
        Parametro_NEG(8) = DBParametro_Montar("SQ_NEGOCIACAO", SQ_NEGOCIACAO)

        If Not DBExecutar(SqlText, Parametro_NEG) Then GoTo Erro

        '>> Verifica se é um contrato do tipo preço fixo
        SqlText = "SELECT NG.CD_TIPO_NEGOCIACAO," & _
                         "TU.QT_FATOR," & _
                         "CF.QT_CANCELADO" & _
                  " FROM SOF.NEGOCIACAO NG," & _
                        "SOF.CONTRATO_FIXO CF," & _
                        "SOF.TIPO_UNIDADE TU" & _
                  " WHERE NG.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND NG.SQ_NEGOCIACAO = " & SQ_NEGOCIACAO & _
                    " AND NG.CD_TIPO_NEGOCIACAO = " & cnt_TIPO_NEGOCIACAO_FixoEmReal & _
                    " AND CF.CD_CONTRATO_PAF = NG.CD_CONTRATO_PAF" & _
                    " AND CF.SQ_NEGOCIACAO = NG.SQ_NEGOCIACAO" & _
                    " AND TU.CD_TIPO_UNIDADE  = CF.CD_TIPO_UNIDADE"
        oData = DBQuery(SqlText)

        If oData.Rows.Count > 0 Then
            With oData.Rows(0)
                ContratoFixo_Impostos_Recalcular(CD_CONTRATO_PAF, _
                                                 SQ_NEGOCIACAO, _
                                                 1, _
                                                 txtQuantidade.Value, _
                                                 txtValorUnitarioNegociacao.Value, _
                                                 txtAliquotaICMS.Value, _
                                                 VL_ADENDO_ICMS, _
                                                 VL_ADENDO_INSS, _
                                                 VLTOTAL, _
                                                 VLICMS, _
                                                 VLINSS)

                SqlText = DBMontar_Update("SOF.CONTRATO_FIXO", GerarArray("CD_PAPEL", ":CD_PAPEL", _
                                                                          "QT_KGS", ":QT_KGS", _
                                                                          "VL_UNITARIO", ":VL_UNITARIO", _
                                                                          "VL_TOTAL", ":VL_TOTAL", _
                                                                          "DT_VENCIMENTO", ":DT_VENCIMENTO", _
                                                                          "PC_ALIQ_ICMS", "PC_ALIQ_ICMS", _
                                                                          "VL_ICMS", "VL_ICMS", _
                                                                          "VL_INSS", "VL_INSS", _
                                                                          "VL_ADENDO_ICMS", "VL_ADENDO_ICMS", _
                                                                          "VL_ADENDO_INSS", "VL_ADENDO_INSS"), _
                                                               GerarArray("CD_CONTRATO_PAF", ":CD_CONTRATO_PAF", " AND ", _
                                                                          "SQ_NEGOCIACAO", ":SQ_NEGOCIACAO"))

                Parametro_FIX(0) = DBParametro_Montar("CD_PAPEL", NULLIf(Trim(CD_PAPEL), ""))
                Parametro_FIX(1) = DBParametro_Montar("QT_KGS", txtQuantidade.Value)
                Parametro_FIX(2) = DBParametro_Montar("VL_UNITARIO", txtValorUnitarioNegociacao.Value)
                Parametro_FIX(3) = DBParametro_Montar("VL_TOTAL", VLTOTAL)
                If IsDate(txtDataEntrega.Text) Then
                    Parametro_FIX(4) = DBParametro_Montar("DT_VENCIMENTO", Date_to_Oracle(txtDataEntrega.Text))
                Else
                    Parametro_FIX(4) = DBParametro_Montar("DT_VENCIMENTO", Nothing)
                End If
                Parametro_FIX(5) = DBParametro_Montar("PC_ALIQ_ICMS", txtAliquotaICMS.Value)
                Parametro_FIX(6) = DBParametro_Montar("VL_ICMS", VLICMS)
                Parametro_FIX(7) = DBParametro_Montar("VL_INSS", VLINSS)
                Parametro_FIX(8) = DBParametro_Montar("VL_ADENDO_ICMS", VL_ADENDO_ICMS)
                Parametro_FIX(9) = DBParametro_Montar("VL_ADENDO_INSS", VL_ADENDO_INSS)
                Parametro_FIX(10) = DBParametro_Montar("CD_CONTRATO_PAF", CD_CONTRATO_PAF)
                Parametro_FIX(11) = DBParametro_Montar("SQ_NEGOCIACAO", SQ_NEGOCIACAO)

                If Not DBExecutar(SqlText, Parametro_FIX) Then GoTo Erro
            End With
        End If

        If txtDataFixacao.Text <> NVL(txtDataFixacao.Tag, "") Or _
           txtDataEntrega.Text <> NVL(txtDataEntrega.Tag, "") Or _
           txtQuantidade.Value <> NVL(txtQuantidade.Tag, 0) Or _
           txtValorUnitarioNegociacao.Value <> NVL(txtValorUnitarioNegociacao.Tag, 0) Then
            '>> Criação de aditivo
            SqlText = DBMontar_Insert("SOF.CONTRATO_ADITIVO", TipoCampoFixo.Todos, _
                                                              "CD_CONTRATO_PAF", ":CD_CONTRATO_PAF", _
                                                              "SQ_NEGOCIACAO", ":SQ_NEGOCIACAO", _
                                                              "SQ_ADITIVO", ":SQ_ADITIVO", _
                                                              "CD_PAPEL", ":CD_PAPEL", _
                                                              "CD_PAPEL_OLD", ":CD_PAPEL_OLD", _
                                                              "DT_PRAZO_FIXACAO", ":DT_PRAZO_FIXACAO", _
                                                              "DT_PRAZO_FIXACAO_OLD", ":DT_PRAZO_FIXACAO_OLD", _
                                                              "DT_PRAZO_ENTREGA", ":DT_PRAZO_ENTREGA", _
                                                              "DT_PRAZO_ENTREGA_OLD", ":DT_PRAZO_ENTREGA_OLD", _
                                                              "QT_KGS", ":QT_KGS", _
                                                              "QT_KGS_OLD", ":QT_KGS_OLD", _
                                                              "VL_UNITARIO", ":VL_UNITARIO", _
                                                              "VL_UNITARIO_OLD", ":VL_UNITARIO_OLD")

            Parametro_Aditivo(0) = DBParametro_Montar("CD_CONTRATO_PAF", CD_CONTRATO_PAF)
            Parametro_Aditivo(1) = DBParametro_Montar("SQ_NEGOCIACAO", SQ_NEGOCIACAO)
            Parametro_Aditivo(2) = DBParametro_Montar("SQ_ADITIVO", SQ_ADITIVO + 1)
            Parametro_Aditivo(3) = DBParametro_Montar("CD_PAPEL", NULLIf(Trim(CD_PAPEL), ""))
            Parametro_Aditivo(4) = DBParametro_Montar("CD_PAPEL_OLD", NULLIf(cboBolsa.Tag, ""))
            If txtDataFixacao.Text <> NVL(txtDataFixacao.Tag, "") Then
                Parametro_Aditivo(5) = DBParametro_Montar("DT_PRAZO_FIXACAO", Date_to_Oracle(txtDataFixacao.Text))
                Parametro_Aditivo(6) = DBParametro_Montar("DT_PRAZO_FIXACAO_OLD", Date_to_Oracle(txtDataFixacao.Tag))
            Else
                Parametro_Aditivo(5) = DBParametro_Montar("DT_PRAZO_FIXACAO", Nothing)
                Parametro_Aditivo(6) = DBParametro_Montar("DT_PRAZO_FIXACAO_OLD", Nothing)
            End If
            If txtDataEntrega.Text <> NVL(txtDataEntrega.Tag, "") Then
                Parametro_Aditivo(7) = DBParametro_Montar("DT_PRAZO_ENTREGA", Date_to_Oracle(txtDataEntrega.Text))
                If IsDate(txtDataEntrega.Tag) Then
                    Parametro_Aditivo(8) = DBParametro_Montar("DT_PRAZO_ENTREGA_OLD", Date_to_Oracle(txtDataEntrega.Tag))
                Else
                    Parametro_Aditivo(8) = DBParametro_Montar("DT_PRAZO_ENTREGA_OLD", Date_to_Oracle(Nothing))
                End If
            Else
                Parametro_Aditivo(7) = DBParametro_Montar("DT_PRAZO_ENTREGA", Nothing)
                Parametro_Aditivo(8) = DBParametro_Montar("DT_PRAZO_ENTREGA_OLD", Nothing)
            End If
            If txtQuantidade.Value <> NVL(txtQuantidade.Tag, 0) Then
                Parametro_Aditivo(9) = DBParametro_Montar("QT_KGS", txtQuantidade.Value)
                Parametro_Aditivo(10) = DBParametro_Montar("QT_KGS_OLD", txtQuantidade.Tag)
            Else
                Parametro_Aditivo(9) = DBParametro_Montar("QT_KGS", Nothing)
                Parametro_Aditivo(10) = DBParametro_Montar("QT_KGS_OLD", Nothing)
            End If
            If txtValorUnitarioNegociacao.Value <> NVL(txtValorUnitarioNegociacao.Tag, 0) Then
                Parametro_Aditivo(11) = DBParametro_Montar("VL_UNITARIO", txtValorUnitarioNegociacao.Value)
                Parametro_Aditivo(12) = DBParametro_Montar("VL_UNITARIO_OLD", txtValorUnitarioNegociacao.Tag)
            Else
                Parametro_Aditivo(11) = DBParametro_Montar("VL_UNITARIO", Nothing)
                Parametro_Aditivo(12) = DBParametro_Montar("VL_UNITARIO_OLD", Nothing)
            End If

            If Not DBExecutar(SqlText, Parametro_Aditivo) Then GoTo Erro
        End If

        If Not DBExecutarTransacao() Then GoTo Erro

        Cancelado = False

        objData_Finalizar(oData)

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

        Me.Text = Me.Text & " - Ctr. " & CD_CONTRATO_PAF & "." & SQ_NEGOCIACAO

        cboBolsa.Enabled = False

        SqlText = "SELECT CD_PAPEL," & _
                         "NO_PAPEL," & _
                         "DT_LIMITE_ENTREGA," & _
                         "VL_COTACAO" & _
                  " FROM SOF.BOLSA_PERIODO" & _
                  " WHERE IC_MOEDA = 'N'" & _
                  " ORDER BY DT_LIMITE_ENTREGA"
        objUltraComboBox_Carregar(cboBolsa, SqlText, _
                                  New Combo_Informacao() {objUltraComboBox_Informacao("Papel", True, 40, True, True), _
                                                          objUltraComboBox_Informacao("Nome", True, 80, False, False, cnt_Formato_NumeroInteiro), _
                                                          objUltraComboBox_Informacao("Dt Limite", True, 120, False, False), _
                                                          objUltraComboBox_Informacao("Cotação", True, 80, False, False)}, , )

        'Pega o número do aditivo atual
        SqlText = "SELECT MAX(SQ_ADITIVO) FROM SOF.CONTRATO_ADITIVO" & _
                  " WHERE CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND SQ_NEGOCIACAO = " & SQ_NEGOCIACAO
        SQ_ADITIVO = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT TNG.IC_BOLSA," & _
                         "TNG.IC_DOLAR," & _
                         "TNG.IC_TIPO_PRECO_FIXO," & _
                         "NEG.PC_ALIQ_ICMS," & _
                         "NVL(ADV.VL_UNITARIO_OLD, NEG.VL_NEGOCIACAO) VL_UNITARIO," & _
                         "NVL(ADV.CD_PAPEL_OLD, NEG.CD_PAPEL) CD_PAPEL," & _
                         "NVL(ADV.QT_KGS_OLD, NEG.QT_KGS) QT_KGS," & _
                         "NVL(ADV.DT_PRAZO_ENTREGA_OLD, NEG.DT_VENCIMENTO) DT_PRAZO_ENTREGA," & _
                         "NVL(ADV.DT_PRAZO_FIXACAO_OLD, NEG.DT_PRAZO_FIXACAO) DT_PRAZO_FIXACAO" & _
                  " FROM SOF.NEGOCIACAO NEG," & _
                        "SOF.TIPO_NEGOCIACAO TNG," & _
                        "(SELECT *" & _
                         " FROM SOF.CONTRATO_ADITIVO" & _
                         " WHERE SQ_ADITIVO = " & SQ_ADITIVO & _
                           " AND SQ_NEGOCIACAO IS NULL) ADV" & _
                  " WHERE NEG.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND NEG.SQ_NEGOCIACAO = " & SQ_NEGOCIACAO & _
                    " AND TNG.CD_TIPO_NEGOCIACAO = NEG.CD_TIPO_NEGOCIACAO" & _
                    " AND ADV.CD_CONTRATO_PAF (+) = NEG.CD_CONTRATO_PAF" & _
                    " AND ADV.SQ_NEGOCIACAO (+) = NEG.SQ_NEGOCIACAO"
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            With oData.Rows(0)
                Select Case True
                    Case oData.Rows(0).Item("IC_TIPO_PRECO_FIXO") = "S"
                        txtDataFixacao.Enabled = False
                End Select

                txtQuantidade.Value = .Item("QT_KGS")
                txtQuantidade.Tag = .Item("QT_KGS")
                txtValorUnitarioNegociacao.Value = .Item("VL_UNITARIO")
                txtValorUnitarioNegociacao.Tag = .Item("VL_UNITARIO")
                txtAliquotaICMS.Value = .Item("PC_ALIQ_ICMS")

                If Not CampoNulo(.Item("DT_PRAZO_ENTREGA")) Then
                    txtDataEntrega.Text = .Item("DT_PRAZO_ENTREGA")
                    txtDataEntrega.Tag = .Item("DT_PRAZO_ENTREGA")
                End If
                If Not CampoNulo(.Item("DT_PRAZO_FIXACAO")) Then
                    txtDataFixacao.Text = .Item("DT_PRAZO_FIXACAO")
                    txtDataFixacao.Tag = .Item("DT_PRAZO_FIXACAO")
                End If

                objUltraComboBox_Possicionar(cboBolsa, 0, .Item("CD_PAPEL"))
                cboBolsa.Tag = .Item("CD_PAPEL")
            End With
        End If

        cmdFechar.Focus()
    End Sub
End Class