Public Class frmCadastroNegociacao_AlteracaoJuros
    Dim COD_CONTRATO_PAF As Double
    Dim SEQ_NEGOCIACAO As Double

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String

        If chkCobraJuros.Checked Then
            If txtQuantidadeDiasCarenciaCobrancaJuros.Value < 0 Then
                Msg_Mensagem("Favor informar a quantidade de dias valido de carencia do juros.")
                txtQuantidadeDiasCarenciaCobrancaJuros.Focus()
                Exit Sub
            End If
            If txtTaxaJuros.Value = 0 Then
                Msg_Mensagem("Voce informou que sera cobrado juros, por isso, favor informar a taxa de juros a ser cobrada.")
                txtTaxaJuros.Focus()
                Exit Sub
            End If
        End If

        On Error GoTo Erro

        If chkCobraJuros.Checked Then
            SqlText = DBMontar_Update("SOF.NEGOCIACAO", GerarArray("IC_CALCULA_JUROS", ":IC_CALCULA_JUROS", _
                                                                   "QT_DIA_CARENCIA_JUROS", ":QT_DIA_CARENCIA_JUROS", _
                                                                   "PC_TAXA_JUROS", ":PC_TAXA_JUROS", _
                                                                   "IC_JUROS_APOS_CARENCIA", ":IC_JUROS_APOS_CARENCIA"), _
                                                        GerarArray("CD_CONTRATO_PAF", ":CD_CONTRATO_PAF", "AND", _
                                                                   "SQ_NEGOCIACAO", ":SQ_NEGOCIACAO"))

            If Not DBExecutar(SqlText, DBParametro_Montar("IC_CALCULA_JUROS", "S"), _
                                       DBParametro_Montar("QT_DIA_CARENCIA_JUROS", txtQuantidadeDiasCarenciaCobrancaJuros.Value), _
                                       DBParametro_Montar("PC_TAXA_JUROS", txtTaxaJuros.Value), _
                                       DBParametro_Montar("IC_JUROS_APOS_CARENCIA", IIf(chkConsideraDdiasQuarenciaCobrancaJuros.Checked, "S", "N")), _
                                       DBParametro_Montar("CD_CONTRATO_PAF", COD_CONTRATO_PAF), _
                                       DBParametro_Montar("SQ_NEGOCIACAO", SEQ_NEGOCIACAO)) Then GoTo Erro
        Else
            SqlText = DBMontar_Update("NEGOCIACAO", GerarArray("IC_CALCULA_JUROS", ":IC_CALCULA_JUROS", _
                                                               "QT_DIA_CARENCIA_JUROS", ":QT_DIA_CARENCIA_JUROS", _
                                                               "PC_TAXA_JUROS", ":PC_TAXA_JUROS", _
                                                               "IC_JUROS_APOS_CARENCIA", ":IC_JUROS_APOS_CARENCIA"), _
                                                    GerarArray("CD_CONTRATO_PAF", ":CD_CONTRATO_PAF", "AND", _
                                                               "SQ_NEGOCIACAO", ":SQ_NEGOCIACAO"))

            If Not DBExecutar(SqlText, DBParametro_Montar("IC_CALCULA_JUROS", "N"), _
                                       DBParametro_Montar("QT_DIA_CARENCIA_JUROS", Nothing), _
                                       DBParametro_Montar("PC_TAXA_JUROS", Nothing), _
                                       DBParametro_Montar("IC_JUROS_APOS_CARENCIA", Nothing), _
                                       DBParametro_Montar("CD_CONTRATO_PAF", COD_CONTRATO_PAF), _
                                       DBParametro_Montar("SQ_NEGOCIACAO", SEQ_NEGOCIACAO)) Then GoTo Erro
        End If

        Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Public Sub Carregar(ByVal CD_CONTRATO_PAF As Double, ByVal SQ_NEGOCIACAO As Double)
        Dim oData As New DataTable
        Dim SqlText As String

        COD_CONTRATO_PAF = CD_CONTRATO_PAF
        SEQ_NEGOCIACAO = SQ_NEGOCIACAO

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        SqlText = "SELECT F.NO_RAZAO_SOCIAL," & _
                         "N.CD_CONTRATO_PAF," & _
                         "N.IC_CALCULA_JUROS," & _
                         "N.QT_DIA_CARENCIA_JUROS," & _
                         "N.PC_TAXA_JUROS," & _
                         "C.CD_FORNECEDOR," & _
                         "N.IC_JUROS_APOS_CARENCIA," & _
                         "N.SQ_NEGOCIACAO" & _
                  " FROM SOF.CONTRATO_PAF C," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.NEGOCIACAO N" & _
                  " WHERE F.CD_FORNECEDOR = C.CD_FORNECEDOR" & _
                    " AND C.CD_CONTRATO_PAF = N.CD_CONTRATO_PAF" & _
                    " AND N.CD_CONTRATO_PAF = " & COD_CONTRATO_PAF & _
                    " AND N.SQ_NEGOCIACAO = " & SEQ_NEGOCIACAO
        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            txtContratoPAF.Text = ""
            txtNegociacao.Value = 0
            Pesq_Fornecedor.Codigo = 0
            txtQuantidadeDiasCarenciaCobrancaJuros.Value = 0
            chkCobraJuros.Checked = False
            txtTaxaJuros.Value = 0
            chkConsideraDdiasQuarenciaCobrancaJuros.Checked = False
        Else
            txtContratoPAF.Text = oData.Rows(0).Item("CD_CONTRATO_PAF")
            txtNegociacao.Value = oData.Rows(0).Item("SQ_NEGOCIACAO")
            Pesq_Fornecedor.Codigo = oData.Rows(0).Item("CD_FORNECEDOR")
            txtQuantidadeDiasCarenciaCobrancaJuros.Value = oData.Rows(0).Item("QT_DIA_CARENCIA_JUROS")
            chkCobraJuros.Checked = (oData.Rows(0).Item("IC_CALCULA_JUROS") = "S")
            txtTaxaJuros.Value = oData.Rows(0).Item("PC_TAXA_JUROS")
            chkConsideraDdiasQuarenciaCobrancaJuros.Checked = (NVL(oData.Rows(0).Item("IC_JUROS_APOS_CARENCIA"), "N") = "S")
        End If

        chkCobraJuros_Click(Nothing, Nothing)
    End Sub

    Private Sub chkCobraJuros_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCobraJuros.Click
        If chkCobraJuros.Checked Then
            txtQuantidadeDiasCarenciaCobrancaJuros.Enabled = True
            lblQuantidadeDiasCarenciaCobrancaJuros.Enabled = True
            txtTaxaJuros.Enabled = True
            lblTaxaJuros.Enabled = True
            chkConsideraDdiasQuarenciaCobrancaJuros.Enabled = True
        Else
            txtQuantidadeDiasCarenciaCobrancaJuros.Value = 0
            txtQuantidadeDiasCarenciaCobrancaJuros.Enabled = False
            lblQuantidadeDiasCarenciaCobrancaJuros.Enabled = False
            txtTaxaJuros.Value = 0
            txtTaxaJuros.Enabled = False
            lblTaxaJuros.Enabled = False
            chkConsideraDdiasQuarenciaCobrancaJuros.Checked = False
            chkConsideraDdiasQuarenciaCobrancaJuros.Enabled = False
        End If
    End Sub
End Class