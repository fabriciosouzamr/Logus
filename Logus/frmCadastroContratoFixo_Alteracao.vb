Public Class frmCadastroContratoFixo_Alteracao
    Public Cancelado As Boolean = False
    Public CD_CONTRATO_PAF As Integer
    Public SQ_NEGOCIACAO As Integer
    Public SQ_CONTRATO_FIXO As Integer
    Dim DT_CONTRATO_PAF As Date
    Dim DT_ASSINATURA_CONTRATO As Date
    Dim SQ_ADITIVO As Integer

    Dim VL_ADENDO_ICMS As Double
    Dim VL_ADENDO_INSS As Double

    Private Sub cmdGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        On Error GoTo Erro

        Dim CD_PAPEL As String = ""
        Dim SqlText As String
        Dim Parametro_CTR(5) As DBParamentro
        Dim Parametro_Aditivo(17) As DBParamentro

        DBUsarTransacao = True

        If ObjUltraComboBox_LinhaSelecionada(cboBolsa) Then
            If cboBolsa.SelectedRow.Cells(0).Value <> NVL(cboBolsa.Tag, "") Then
                CD_PAPEL = cboBolsa.SelectedRow.Cells(0).Value
            End If
        End If

        '>> Alteração do cadastro
        SqlText = DBMontar_Update("SOF.CONTRATO_FIXO", GerarArray("CD_PAPEL", ":CD_PAPEL", _
                                                                  "QT_KGS", ":QT_KGS", _
                                                                  "VL_UNITARIO", ":VL_UNITARIO"), _
                                                       GerarArray("CD_CONTRATO_PAF", ":CD_CONTRATO_PAF", " AND ", _
                                                                  "SQ_NEGOCIACAO", ":SQ_NEGOCIACAO", " AND ", _
                                                                  "SQ_CONTRATO_FIXO", ":SQ_CONTRATO_FIXO"))

        Parametro_CTR(0) = DBParametro_Montar("CD_PAPEL", NULLIf(Trim(CD_PAPEL), ""))
        Parametro_CTR(1) = DBParametro_Montar("QT_KGS", txtQuantidade.Value)
        Parametro_CTR(2) = DBParametro_Montar("VL_UNITARIO", txtValorUnitario.Value)
        Parametro_CTR(3) = DBParametro_Montar("CD_CONTRATO_PAF", CD_CONTRATO_PAF)
        Parametro_CTR(4) = DBParametro_Montar("SQ_NEGOCIACAO", SQ_NEGOCIACAO)
        Parametro_CTR(5) = DBParametro_Montar("SQ_CONTRATO_FIXO", SQ_CONTRATO_FIXO)
        If Not DBExecutar(SqlText, Parametro_CTR) Then GoTo Erro

        If (NULLIf(Trim(CD_PAPEL), "") <> NULLIf(NVL(cboBolsa.Tag, ""), "") And cboBolsa.Visible) Or _
           txtQuantidade.Value <> NVL(txtQuantidade.Tag, 0) Or _
           txtValorUnitario.Value <> NVL(txtValorUnitario.Tag, 0) Then
            '>> Criação de aditivo
            SqlText = DBMontar_Insert("SOF.CONTRATO_ADITIVO", TipoCampoFixo.Todos, _
                                                              "CD_CONTRATO_PAF", ":CD_CONTRATO_PAF", _
                                                              "SQ_NEGOCIACAO", ":SQ_NEGOCIACAO", _
                                                              "SQ_CONTRATO_FIXO", ":SQ_CONTRATO_FIXO", _
                                                              "SQ_ADITIVO", ":SQ_ADITIVO", _
                                                              "CD_PAPEL", ":CD_PAPEL", _
                                                              "CD_PAPEL_OLD", ":CD_PAPEL_OLD", _
                                                              "QT_KGS", ":QT_KGS", _
                                                              "QT_KGS_OLD", ":QT_KGS_OLD", _
                                                              "VL_UNITARIO", ":VL_UNITARIO", _
                                                              "VL_UNITARIO_OLD", ":VL_UNITARIO_OLD", _
                                                              "PC_ALIQ_ICMS", ":PC_ALIQ_ICMS", _
                                                              "PC_ALIQ_ICMS_OLD", ":PC_ALIQ_ICMS_OLD", _
                                                              "VL_TOTAL", ":VL_TOTAL", _
                                                              "VL_TOTAL_OLD", ":VL_TOTAL_OLD", _
                                                              "VL_ICMS", ":VL_ICMS", _
                                                              "VL_ICMS_OLD", ":VL_ICMS_OLD", _
                                                              "VL_INSS", ":VL_INSS", _
                                                              "VL_INSS_OLD", ":VL_INSS_OLD")

            Parametro_Aditivo(0) = DBParametro_Montar("CD_CONTRATO_PAF", CD_CONTRATO_PAF)
            Parametro_Aditivo(1) = DBParametro_Montar("SQ_NEGOCIACAO", SQ_NEGOCIACAO)
            Parametro_Aditivo(2) = DBParametro_Montar("SQ_CONTRATO_FIXO", SQ_CONTRATO_FIXO)
            Parametro_Aditivo(3) = DBParametro_Montar("SQ_ADITIVO", SQ_ADITIVO + 1)
            Parametro_Aditivo(4) = DBParametro_Montar("CD_PAPEL", NULLIf(Trim(CD_PAPEL), ""))
            Parametro_Aditivo(5) = DBParametro_Montar("CD_PAPEL_OLD", NULLIf(NVL(cboBolsa.Tag, ""), ""))
            If txtQuantidade.Value <> NVL(txtQuantidade.Tag, 0) Then
                Parametro_Aditivo(6) = DBParametro_Montar("QT_KGS", txtQuantidade.Value)
                Parametro_Aditivo(7) = DBParametro_Montar("QT_KGS_OLD", txtQuantidade.Tag)
            Else
                Parametro_Aditivo(6) = DBParametro_Montar("QT_KGS", Nothing)
                Parametro_Aditivo(7) = DBParametro_Montar("QT_KGS_OLD", Nothing)
            End If
            If txtValorUnitario.Value <> NVL(txtValorUnitario.Tag, 0) Then
                Parametro_Aditivo(8) = DBParametro_Montar("VL_UNITARIO", txtValorUnitario.Value)
                Parametro_Aditivo(9) = DBParametro_Montar("VL_UNITARIO_OLD", txtValorUnitario.Tag)
            Else
                Parametro_Aditivo(8) = DBParametro_Montar("VL_UNITARIO", Nothing)
                Parametro_Aditivo(9) = DBParametro_Montar("VL_UNITARIO_OLD", Nothing)
            End If
            If txtAliquotaICMS.Value <> NVL(txtAliquotaICMS.Tag, 0) Then
                Parametro_Aditivo(10) = DBParametro_Montar("PC_ALIQ_ICMS", txtAliquotaICMS.Value)
                Parametro_Aditivo(11) = DBParametro_Montar("PC_ALIQ_ICMS_OLD", txtAliquotaICMS.Tag)
            Else
                Parametro_Aditivo(10) = DBParametro_Montar("PC_ALIQ_ICMS", Nothing)
                Parametro_Aditivo(11) = DBParametro_Montar("PC_ALIQ_ICMS_OLD", Nothing)
            End If
            If txtValorTotal.Value <> NVL(txtValorTotal.Tag, 0) Then
                Parametro_Aditivo(12) = DBParametro_Montar("VL_TOTAL", txtValorTotal.Value)
                Parametro_Aditivo(13) = DBParametro_Montar("VL_TOTAL_OLD", txtValorTotal.Tag)
            Else
                Parametro_Aditivo(12) = DBParametro_Montar("VL_TOTAL", Nothing)
                Parametro_Aditivo(13) = DBParametro_Montar("VL_TOTAL_OLD", Nothing)
            End If
            If txtValorICMS.Value <> NVL(txtValorICMS.Tag, 0) Then
                Parametro_Aditivo(14) = DBParametro_Montar("VL_ICMS", txtValorICMS.Value)
                Parametro_Aditivo(15) = DBParametro_Montar("VL_ICMS_OLD", txtValorICMS.Tag)
            Else
                Parametro_Aditivo(14) = DBParametro_Montar("VL_ICMS", Nothing)
                Parametro_Aditivo(15) = DBParametro_Montar("VL_ICMS_OLD", Nothing)
            End If
            If txtValorINSS.Value <> NVL(txtValorINSS.Tag, 0) Then
                Parametro_Aditivo(16) = DBParametro_Montar("VL_INSS", txtValorINSS.Value)
                Parametro_Aditivo(17) = DBParametro_Montar("VL_INSS_OLD", txtValorINSS.Tag)
            Else
                Parametro_Aditivo(16) = DBParametro_Montar("VL_INSS", Nothing)
                Parametro_Aditivo(17) = DBParametro_Montar("VL_INSS_OLD", Nothing)
            End If

            If Not DBExecutar(SqlText, Parametro_Aditivo) Then GoTo Erro
        End If

        '>> PC_ALIQ_ICMS - Início
        SqlText = DBMontar_Update("SOF.CONTRATO_FIXO", GerarArray("PC_ALIQ_ICMS", ":PC_ALIQ_ICMS", _
                                                                  "VL_ICMS", ":VL_ICMS", _
                                                                  "VL_INSS", ":VL_INSS", _
                                                                  "VL_ADENDO_ICMS", ":VL_ADENDO_ICMS", _
                                                                  "VL_ADENDO_INSS", ":VL_ADENDO_INSS"), _
                                                       GerarArray("CD_CONTRATO_PAF", ":CD_CONTRATO_PAF", " AND ", _
                                                                  "SQ_NEGOCIACAO", ":SQ_NEGOCIACAO", " AND ", _
                                                                  "SQ_CONTRATO_FIXO", ":SQ_CONTRATO_FIXO"))
        If Not DBExecutar(SqlText, DBParametro_Montar("PC_ALIQ_ICMS", txtAliquotaICMS.Value), _
                                   DBParametro_Montar("VL_ICMS", txtValorICMS.Value), _
                                   DBParametro_Montar("VL_INSS", txtValorINSS.Value), _
                                   DBParametro_Montar("VL_ADENDO_ICMS", VL_ADENDO_ICMS), _
                                   DBParametro_Montar("VL_ADENDO_INSS", VL_ADENDO_INSS), _
                                   DBParametro_Montar("CD_CONTRATO_PAF", CD_CONTRATO_PAF), _
                                   DBParametro_Montar("SQ_NEGOCIACAO", SQ_NEGOCIACAO), _
                                   DBParametro_Montar("SQ_CONTRATO_FIXO", SQ_CONTRATO_FIXO)) Then GoTo Erro

        SqlText = DBMontar_Update("SOF.CONTRATO_FIXO_ADENDO", GerarArray("VL_ICMS_ADENDO", ":VL_ICMS_ADENDO", _
                                                                         "VL_INSS_ADENDO", ":VL_INSS_ADENDO"), _
                                                              GerarArray("CD_CONTRATO_PAF", ":CD_CONTRATO_PAF", " AND ", _
                                                                         "SQ_NEGOCIACAO", ":SQ_NEGOCIACAO", " AND ", _
                                                                         "SQ_CONTRATO_FIXO", ":SQ_CONTRATO_FIXO"))
        If Not DBExecutar(SqlText, DBParametro_Montar("VL_ICMS_ADENDO", VL_ADENDO_ICMS), _
                                   DBParametro_Montar("VL_INSS_ADENDO", VL_ADENDO_INSS), _
                                   DBParametro_Montar("CD_CONTRATO_PAF", CD_CONTRATO_PAF), _
                                   DBParametro_Montar("SQ_NEGOCIACAO", SQ_NEGOCIACAO), _
                                   DBParametro_Montar("SQ_CONTRATO_FIXO", SQ_CONTRATO_FIXO)) Then GoTo Erro

        SqlText = DBMontar_SP("SOF.SP_CALCULO_DIFERENCIAL", False, ":CDCONTRATOPAF", _
                                                                   ":SQNEGOCIACAO", _
                                                                   ":SQCONTRATOFIXO", _
                                                                   ":SQPRENEGOCIACAO")
        If Not DBExecutar(SqlText, DBParametro_Montar("CDCONTRATOPAF", CD_CONTRATO_PAF), _
                                   DBParametro_Montar("SQNEGOCIACAO", Nothing), _
                                   DBParametro_Montar("SQCONTRATOFIXO", Nothing), _
                                   DBParametro_Montar("SQPRENEGOCIACAO", Nothing)) Then GoTo Erro

        SqlText = DBMontar_SP("SOF.SP_CALCULO_DIFERENCIAL", False, ":CDCONTRATOPAF", _
                                                                   ":SQNEGOCIACAO", _
                                                                   ":SQCONTRATOFIXO", _
                                                                   ":SQPRENEGOCIACAO")
        If Not DBExecutar(SqlText, DBParametro_Montar("CDCONTRATOPAF", CD_CONTRATO_PAF), _
                                   DBParametro_Montar("SQNEGOCIACAO", SQ_NEGOCIACAO), _
                                   DBParametro_Montar("SQCONTRATOFIXO", Nothing), _
                                   DBParametro_Montar("SQPRENEGOCIACAO", Nothing)) Then GoTo Erro
        '>> PC_ALIQ_ICMS - Fim

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

        Me.Text = Me.Text & " - Ctr. " & CD_CONTRATO_PAF & "." & SQ_NEGOCIACAO & "." & SQ_CONTRATO_FIXO

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
                    " AND SQ_NEGOCIACAO = " & SQ_NEGOCIACAO & _
                    " AND SQ_CONTRATO_FIXO = " & SQ_CONTRATO_FIXO
        SQ_ADITIVO = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT TNG.IC_BOLSA," & _
                         "TNG.IC_DOLAR," & _
                         "TNG.IC_TIPO_PRECO_FIXO," & _
                         "NVL(ADV.VL_UNITARIO, CFX.VL_UNITARIO) VL_UNITARIO," & _
                         "NVL(ADV.CD_PAPEL, CFX.CD_PAPEL) CD_PAPEL," & _
                         "NVL(ADV.QT_KGS, CFX.QT_KGS) QT_KGS," & _
                         "NVL(ADV.PC_ALIQ_ICMS, CFX.PC_ALIQ_ICMS) PC_ALIQ_ICMS," & _
                         "NVL(ADV.VL_TOTAL, CFX.VL_TOTAL) VL_TOTAL," & _
                         "NVL(ADV.VL_ICMS, CFX.VL_ICMS) VL_ICMS," & _
                         "NVL(ADV.VL_INSS, CFX.VL_INSS) VL_INSS" & _
                  " FROM SOF.CONTRATO_FIXO CFX," & _
                        "SOF.NEGOCIACAO NEG," & _
                        "SOF.TIPO_NEGOCIACAO TNG," & _
                        "(SELECT *" & _
                         " FROM SOF.CONTRATO_ADITIVO" & _
                         " WHERE SQ_ADITIVO = " & SQ_ADITIVO & _
                           " AND SQ_NEGOCIACAO IS NULL) ADV" & _
                  " WHERE CFX.CD_CONTRATO_PAF = " & CD_CONTRATO_PAF & _
                    " AND CFX.SQ_NEGOCIACAO = " & SQ_NEGOCIACAO & _
                    " AND CFX.SQ_CONTRATO_FIXO = " & SQ_CONTRATO_FIXO & _
                    " AND NEG.CD_CONTRATO_PAF = CFX.CD_CONTRATO_PAF" & _
                    " AND NEG.SQ_NEGOCIACAO = CFX.SQ_NEGOCIACAO" & _
                    " AND TNG.CD_TIPO_NEGOCIACAO = NEG.CD_TIPO_NEGOCIACAO" & _
                    " AND ADV.CD_CONTRATO_PAF (+) = CFX.CD_CONTRATO_PAF" & _
                    " AND ADV.SQ_NEGOCIACAO (+) = CFX.SQ_NEGOCIACAO" & _
                    " AND ADV.SQ_CONTRATO_FIXO (+) = CFX.SQ_CONTRATO_FIXO"
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            With oData.Rows(0)
                Select Case True
                    Case oData.Rows(0).Item("IC_BOLSA") = "S"
                        cboBolsa.Enabled = True
                    Case oData.Rows(0).Item("IC_DOLAR") = "S"
                        cboBolsa.Enabled = True
                    Case oData.Rows(0).Item("IC_TIPO_PRECO_FIXO") = "S"
                        cboBolsa.Enabled = True
                End Select

                txtQuantidade.Value = .Item("QT_KGS")
                txtQuantidade.Tag = .Item("QT_KGS")
                txtValorUnitario.Value = NVL(.Item("VL_UNITARIO"), 0)
                txtValorUnitario.Tag = NVL(.Item("VL_UNITARIO"), 0)
                txtAliquotaICMS.Value = NVL(.Item("PC_ALIQ_ICMS"), 0)
                txtAliquotaICMS.Tag = NVL(.Item("PC_ALIQ_ICMS"), 0)
                txtValorTotal.Value = NVL(.Item("VL_TOTAL"), 0)
                txtValorTotal.Tag = NVL(.Item("VL_TOTAL"), 0)
                txtValorICMS.Value = NVL(.Item("VL_ICMS"), 0)
                txtValorICMS.Tag = NVL(.Item("VL_ICMS"), 0)
                txtValorINSS.Value = NVL(.Item("VL_INSS"), 0)
                txtValorINSS.Tag = NVL(.Item("VL_INSS"), 0)

                objUltraComboBox_Possicionar(cboBolsa, 0, .Item("CD_PAPEL"))
                cboBolsa.Tag = .Item("CD_PAPEL")
            End With
        End If

        cmdFechar.Focus()
    End Sub

    Private Sub txtAliquotaICMS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAliquotaICMS.ValueChanged
        Impostos_Recalcular()
    End Sub

    Private Sub Impostos_Recalcular()
        Dim VLTOTAL As Double
        Dim VLICMS As Double
        Dim VLINSS As Double

        ContratoFixo_Impostos_Recalcular(CD_CONTRATO_PAF, _
                                         SQ_NEGOCIACAO, _
                                         SQ_CONTRATO_FIXO, _
                                         txtQuantidade.Value, _
                                         txtValorUnitario.Value, _
                                         txtAliquotaICMS.Value, _
                                         VL_ADENDO_ICMS, _
                                         VL_ADENDO_INSS, _
                                         VLTOTAL, _
                                         VLICMS, _
                                         VLINSS)

        txtValorICMS.Value = VLICMS
        txtValorINSS.Value = VLINSS
        txtValorTotal.Value = VLTOTAL
    End Sub

    Private Sub txtValorUnitario_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValorUnitario.ValueChanged
        Impostos_Recalcular()
    End Sub

    Private Sub txtQuantidade_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantidade.ValueChanged
        Impostos_Recalcular()
    End Sub
End Class