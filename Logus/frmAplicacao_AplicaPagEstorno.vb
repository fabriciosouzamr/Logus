Public Class frmAplicacao_AplicaPagEstorno
    Public Cancelado As Boolean
    Public CD_FORNECEDOR As Integer
    Public VL_MAXIMO As Double

    Const cnt_ComboCtrPAF_CD_CONTRATO_PAF As Integer = 0
    Const cnt_ComboCtrPAF_QT_KGS As Integer = 1
    Const cnt_ComboCtrPAF_VL_PAG_FIXO As Integer = 2
    Const cnt_ComboCtrPAF_IC_ADIANTAMENTO As Integer = 3

    Const cnt_ComboNEG_SQ_NEGOCIACAO As Integer = 0
    Const cnt_ComboNEG_QT_KGS As Integer = 1
    Const cnt_ComboNEG_VL_NEGOCIACAO As Integer = 2
    Const cnt_ComboNEG_DT_NEGOCIACAO As Integer = 3
    Const cnt_ComboNEG_NO_TIPO_NEGOCIACAO As Integer = 4

    Private Sub frmAprovacaoPagamento_AplicaPagEstorno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SqlText As String

        SqlText = "SELECT CP.CD_CONTRATO_PAF," & _
                         "CP.QT_KGS," & _
                         "CP.VL_PAG_FIXO," & _
                         "TCP.IC_ADIANTAMENTO" & _
                  " FROM SOF.CONTRATO_PAF CP," & _
                        "SOF.TIPO_CONTRATO_PAF TCP" & _
                  " WHERE CP.CD_TIPO_CONTRATO_PAF = TCP.CD_TIPO_CONTRATO_PAF" & _
                    " AND CP.CD_FORNECEDOR = " & CD_FORNECEDOR & _
                    " AND CP.IC_STATUS = 'A'" & _
                  " ORDER BY CP.CD_CONTRATO_PAF"
        objUltraComboBox_Carregar(cboContratoPAF, SqlText, _
                                                  New Combo_Informacao() {objUltraComboBox_Informacao("Contrato", True, 100, True, True, ""), _
                                                                          objUltraComboBox_Informacao("Kg.s", True, 100, False, False, cnt_Formato_Kilos), _
                                                                          objUltraComboBox_Informacao("Vl. Aplicado", True, 100, False, False, cnt_Formato_Valor), _
                                                                          objUltraComboBox_Informacao("Adiantamento", True, 100, False, False)})

        txtSaldoPagamento.Value = VL_MAXIMO
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Cancelado = True
        Close()
    End Sub

    Private Sub cboContratoFixo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboContratoFixo.SelectedIndexChanged
        Dim SqlText As String

        If ComboBox_LinhaSelecionada(cboContratoFixo) Then
            'Identifica o saldo do contrato
            SqlText = "SELECT SOF.FC_SALDO_CTR_FIX(CF.CD_CONTRATO_PAF," & _
                                                  "CF.SQ_NEGOCIACAO," & _
                                                  "CF.SQ_CONTRATO_FIXO) VL_SALDO" & _
                      " FROM SOF.CONTRATO_FIXO CF" & _
                      " WHERE CF.CD_CONTRATO_PAF = " & cboContratoPAF.SelectedRow.Cells(cnt_ComboCtrPAF_CD_CONTRATO_PAF).Value & _
                        " AND CF.SQ_NEGOCIACAO = " & cboNegocicao.SelectedRow.Cells(cnt_ComboNEG_SQ_NEGOCIACAO).Value & _
                        " AND CF.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue
            txtSaldoContrato.Value = DBQuery_ValorUnico(SqlText, 0)
        Else
            txtSaldoContrato.Value = 0
        End If
    End Sub

    Private Sub cboNegocicao_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNegocicao.ValueChanged
        Dim SqlText As String

        txtSaldoContrato.Value = 0

        If Not cboNegocicao.SelectedRow Is Nothing Then
            SqlText = "SELECT SQ_CONTRATO_FIXO" & _
                      " FROM SOF.CONTRATO_FIXO " & _
                      " WHERE CD_CONTRATO_PAF = " & cboContratoPAF.SelectedRow.Cells(cnt_ComboCtrPAF_CD_CONTRATO_PAF).Value & _
                        " AND SQ_NEGOCIACAO = " & cboNegocicao.SelectedRow.Cells(cnt_ComboNEG_SQ_NEGOCIACAO).Value & _
                        " AND IC_STATUS = 'A'"
            DBCarregarComboBox(cboContratoFixo, SqlText, True)

            cboContratoFixo.Enabled = (cboContratoFixo.Items.Count > 0)
        Else
            cboContratoFixo.DataSource = Nothing
            cboContratoFixo.Enabled = False
        End If
    End Sub

    Private Sub cboContratoPAF_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboContratoPAF.ValueChanged
        Dim SqlText As String

        If Not cboContratoPAF.SelectedRow Is Nothing Then
            cboNegocicao.DataSource = Nothing
            cboNegocicao.Enabled = False
            cboContratoFixo.DataSource = Nothing
            cboContratoFixo.Enabled = False
        Else
            SqlText = "SELECT N.SQ_NEGOCIACAO," & _
                             "N.QT_KGS," & _
                             "N.VL_NEGOCIACAO," & _
                             "N.DT_NEGOCIACAO, " & _
                             "TN.NO_TIPO_NEGOCIACAO" & _
                      " FROM SOF.NEGOCIACAO N," & _
                            "SOF.TIPO_NEGOCIACAO TN " & _
                      " WHERE TN.CD_TIPO_NEGOCIACAO = N.CD_TIPO_NEGOCIACAO" & _
                        " AND N.CD_CONTRATO_PAF = " & cboContratoPAF.SelectedRow.Cells(cnt_ComboCtrPAF_CD_CONTRATO_PAF).Value & _
                        " AND N.IC_STATUS = 'A'"
            objUltraComboBox_Carregar(cboNegocicao, SqlText, _
                                                    New Combo_Informacao() {objUltraComboBox_Informacao("Negociação", True, 100, True, True, ""), _
                                                                            objUltraComboBox_Informacao("Kg.s", True, 100, False, False, cnt_Formato_Kilos), _
                                                                            objUltraComboBox_Informacao("Prc. Unitário", True, 100, False, False, cnt_Formato_Valor), _
                                                                            objUltraComboBox_Informacao("Dt. Negociação", True, 100, False, False, cnt_Formato_Data), _
                                                                            objUltraComboBox_Informacao("Tipo de Negociação", True, 100, False, False)})

            cboNegocicao.Enabled = (cboNegocicao.Rows.Count > 0)
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        'Dim SqlText As String

        If Not cboContratoPAF.SelectedRow Is Nothing Then
            Msg_Mensagem("Favor selecionar um Contrato PAF.")
            Exit Sub
        End If

        If Not cboNegocicao.SelectedRow Is Nothing Then
            'XSEC
            'If Libera_Controle("03;05") Then
            '    SqlText = "SELECT TCP.IC_ADIANTAMENTO" & _
            '              " FROM SOF.CONTRATO_PAF CP," & _
            '                    "SOF.TIPO_CONTRATO_PAF TCP " & _
            '              " WHERE CP.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
            '                " AND CP.IC_STATUS = 'A'" & _
            '                " AND TCP.CD_TIPO_CONTRATO_PAF = CP.CD_TIPO_CONTRATO_PAF" & _
            '              " ORDER BY CP.CD_CONTRATO_PAF"

            '    If DBQuery_ValorUnico(SqlText, "N") = "N" Then
            '        Msg_Mensagem("Não é possivel deixar adiantamento em aberto dentro de contrato Master")
            '        Exit Sub
            '    End If
            'Else
            Msg_Mensagem("Favor selecionar uma negociação.")
            'End If
        End If

        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then
            'XSEC
            'If Not Libera_Controle("03;05") Then
            Msg_Mensagem("Favor selecionar um contrato fixo.")
            Exit Sub
        End If

        If txtValorEstornar.Value = 0 Then
            Msg_Mensagem("Favor informar um valor para transferencia.")
            Exit Sub
        End If

        If ComboBox_LinhaSelecionada(cboContratoFixo) Then
            If txtValorEstornar.Value > txtSaldoContrato.Value Then
                Msg_Mensagem("Valor a aplicar no contrato fixo maior do que o saldo do mesmo.")
                Exit Sub
            End If
        End If

        If txtValorEstornar.Value > txtSaldoPagamento.Value Then
            Msg_Mensagem("O máximo que pode ser transferido é de " & txtSaldoPagamento.Text)
            Exit Sub
        End If

        If Trim(txtMotivo.Text) = "" Then
            Msg_Mensagem("Favor informar um motivo.")
            Exit Sub
        End If

        Cancelado = False

        Close()
    End Sub

    Public ReadOnly Property ContratoPAF() As Integer
        Get
            If cboContratoPAF.SelectedRow Is Nothing Then
                Return 0
            Else
                Return cboContratoPAF.SelectedRow.Cells(cnt_ComboCtrPAF_CD_CONTRATO_PAF).Value
            End If
        End Get
    End Property

    Public ReadOnly Property Valor_Estornar() As Double
        Get
            Return txtValorEstornar.Value
        End Get
    End Property

    Public ReadOnly Property Motivo() As Double
        Get
            Return Trim(txtMotivo.Text)
        End Get
    End Property

    Public ReadOnly Property SQ_NEGOCIACAO() As Integer
        Get
            If cboNegocicao.SelectedRow Is Nothing Then
                Return 0
            Else
                Return cboNegocicao.SelectedRow.Cells(cnt_ComboNEG_SQ_NEGOCIACAO).Value
            End If
        End Get
    End Property

    Public ReadOnly Property SQ_CONTRATO_FIXO() As Integer
        Get
            If ComboBox_LinhaSelecionada(cboContratoFixo) Then
                Return cboContratoFixo.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property
End Class