Public Class frmAplicacaoContratoFixo_AlterarAplicacao
    Public Cancelado As Boolean = False
    Public Quantidade_Maxima As Integer
    Public Valor_Maximo As Double
    Public Fornecedor As Integer

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Cancelado = True
        Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If txtValorSolicitacao.Value > txtValorMaximaSolicitacao.Value Then
            Msg_Mensagem("Valor solicitado maior que o valor máximo.")
            Exit Sub
        End If
        If txtValorSolicitacao.Value > txtSaldoValorContratoFixo.Value Then
            Msg_Mensagem("Valor solicitado maior do que o valor em aberto do contrato.")
            Exit Sub
        End If
        If txtQuantidadeSolicitacao.Value > txtQuantidadeMaximaSolicitacao.Value Then
            Msg_Mensagem("Quantidade solicitada maior do que a quantidade maxima.")
            Exit Sub
        End If
        If txtQuantidadeSolicitacao.Value > txtSaldoQuantidadeContratoFixo.Value Then
            Msg_Mensagem("Quantidade solicitada maior do que a quantidade em aberta do contrato.")
            Exit Sub
        End If
        If txtValorMaximaSolicitacao.Value < 0 Then
            Msg_Mensagem("Valor solicitado não pode ser negativo.")
            Exit Sub
        End If
        If txtQuantidadeSolicitacao.Value < 0 Then
            Msg_Mensagem("Quantidade solicitada não pode ser negativa.")
            Exit Sub
        End If

        Cancelado = False

        Close()
    End Sub

    Private Sub ContratoFixo_Limpar()
        cboContratoFixo.DataSource = Nothing
        txtSaldoValorContratoFixo.Value = 0
        txtSaldoQuantidadeContratoFixo.Value = 0
    End Sub

    Private Sub cboContratoFixo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContratoFixo.SelectedIndexChanged
        Dim oData As DataTable
        Dim SqlText As String

        txtSaldoQuantidadeContratoFixo.Value = 0
        txtSaldoValorContratoFixo.Value = 0

        If Not cboNegociacao.SelectedRow Is Nothing Then Exit Sub

        SqlText = "SELECT (SOF.FC_SALDO_CTR_FIX(CF.CD_CONTRATO_PAF, CF.SQ_NEGOCIACAO , CF.SQ_CONTRATO_FIXO) + CF.VL_ADENDO_INSS + CF.VL_INSS - CF.VL_NF_FIXO) AS VL_SALDO," & _
                          "(CF.QT_KGS - CF.QT_KG_FIXO - CF.QT_CANCELADO) AS QT_SALDO" & _
                  " FROM SOF.CONTRATO_FIXO CF" & _
                  " WHERE CF.CD_CONTRATO_PAF = " & cboContratoPAF.SelectedRow.Cells(0).Value & _
                    " AND CF.SQ_NEGOCIACAO = " & cboNegociacao.SelectedRow.Cells(0).Value & _
                    " AND CF.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            txtSaldoQuantidadeContratoFixo.Value = oData.Rows(0).Item("QT_SALDO")
            txtSaldoValorContratoFixo.Value = oData.Rows(0).Item("VL_SALDO")
        End If

        oData.Dispose()
        oData = Nothing
    End Sub

    Private Sub cboNegociacao_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNegociacao.ValueChanged
        Dim SqlText As String

        ContratoFixo_Limpar()

        If cboNegociacao.SelectedRow Is Nothing Then Exit Sub

        SqlText = "SELECT SQ_CONTRATO_FIXO," & _
                         "CAST(SQ_CONTRATO_FIXO AS VARCHAR2(10))" & _
                  " FROM SOF.CONTRATO_FIXO " & _
                  " WHERE CD_CONTRATO_PAF = " & cboContratoPAF.SelectedRow.Cells(0).Value & _
                    " AND SQ_NEGOCIACAO = " & cboNegociacao.SelectedRow.Cells(0).Value & _
                    " AND IC_STATUS = 'A'"
        DBCarregarComboBox(cboContratoFixo, SqlText)
    End Sub

    Private Sub frmAplicacaoContratoFixo_AlterarAplicacao_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SqlText As String

        txtQuantidadeMaximaSolicitacao.Value = Quantidade_Maxima
        txtValorMaximaSolicitacao.Value = Valor_Maximo

        SqlText = "SELECT CP.CD_CONTRATO_PAF," & _
                         "CP.QT_KGS," & _
                         "CP.VL_PAG_FIXO," & _
                         "TCP.IC_ADIANTAMENTO" & _
                  " FROM SOF.CONTRATO_PAF CP," & _
                        "SOF.TIPO_CONTRATO_PAF TCP" & _
                  " WHERE CP.CD_TIPO_CONTRATO_PAF = TCP.CD_TIPO_CONTRATO_PAF" & _
                    " AND CP.CD_FORNECEDOR = " & Fornecedor & _
                    " AND CP.IC_STATUS = 'A'" & _
                  " ORDER BY CP.CD_CONTRATO_PAF"
        objUltraComboBox_Carregar(cboContratoPAF, SqlText, _
                                                  New Combo_Informacao() {objUltraComboBox_Informacao("Contrato", True, 100, True, True, ""), _
                                                                          objUltraComboBox_Informacao("Kg.s", True, 100, False, False, cnt_Formato_Kilos), _
                                                                          objUltraComboBox_Informacao("Vl. Aplicado", True, 100, False, False, cnt_Formato_Valor), _
                                                                          objUltraComboBox_Informacao("Adiantamento", True, 100, False, False)})

    End Sub

    Public ReadOnly Property Valor_Solicitado() As Double
        Get
            Return txtValorSolicitacao.Value
        End Get
    End Property

    Public ReadOnly Property Quantidade_Solicitada() As Integer
        Get
            Return txtQuantidadeSolicitacao.Value
        End Get
    End Property

    Public ReadOnly Property ContratoPAF() As Integer
        Get
            Return cboContratoPAF.SelectedRow.Cells(0).Value
        End Get
    End Property

    Public ReadOnly Property Negociacao() As Integer
        Get
            Return cboNegociacao.SelectedRow.Cells(0).Value
        End Get
    End Property

    Public ReadOnly Property ContratoFixo() As Integer
        Get
            Return cboContratoFixo.SelectedValue
        End Get
    End Property

    Private Sub cboContratoPAF_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboContratoPAF.InitializeLayout
        Dim SqlText As String

        cboNegociacao.DataSource = Nothing
        ContratoFixo_Limpar()

        If Not cboContratoPAF.SelectedRow Is Nothing Then Exit Sub

        SqlText = "SELECT N.SQ_NEGOCIACAO," & _
                         "N.QT_KGS," & _
                         "N.VL_NEGOCIACAO," & _
                         "N.DT_NEGOCIACAO, " & _
                         "TN.NO_TIPO_NEGOCIACAO " & _
                  " FROM SOF.NEGOCIACAO N," & _
                        "SOF.TIPO_NEGOCIACAO TN" & _
                  " WHERE TN.CD_TIPO_NEGOCIACAO = N.CD_TIPO_NEGOCIACAO" & _
                    " AND N.CD_CONTRATO_PAF = " & cboContratoPAF.SelectedRow.Cells(0).Value & _
                    " AND N.IC_STATUS = 'A'"
        objUltraComboBox_Carregar(cboNegociacao, SqlText, _
                                                  New Combo_Informacao() {objUltraComboBox_Informacao("Negociação", True, 100, True, True, ""), _
                                                                          objUltraComboBox_Informacao("Kg.s", True, 100, False, False, cnt_Formato_Kilos), _
                                                                          objUltraComboBox_Informacao("Prc. Unitário", True, 100, False, False, cnt_Formato_Valor), _
                                                                          objUltraComboBox_Informacao("Dt. Negociação", True, 100, False, False, cnt_Formato_Data), _
                                                                          objUltraComboBox_Informacao("Tipo de Negociação", True, 100, False, False)})

        cboNegociacao.Enabled = (cboNegociacao.Rows.Count > 0)
    End Sub
End Class