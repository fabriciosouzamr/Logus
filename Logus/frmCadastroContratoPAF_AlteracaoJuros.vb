Public Class frmCadastroContratoPAF_AlteracaoJuros
    Public CD_Contrato_PAF As Long

    Private Sub chkCobraJuros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCobraJuros.CheckedChanged
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

    Private Sub cmdFechar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
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
            SqlText = "UPDATE SOF.CONTRATO_PAF" & _
                      " SET IC_CALCULA_JUROS = 'S'," & _
                           "QT_DIA_CARENCIA_JUROS = " & txtQuantidadeDiasCarenciaCobrancaJuros.Value & "," & _
                           "PC_TAXA_JUROS = " & txtTaxaJuros.Value & ", " & _
                           "IC_JUROS_APOS_CARENCIA = " & QuotedStr(IIf(chkConsideraDdiasQuarenciaCobrancaJuros.Checked, "S", "N")) & ","

            If fraCobrarJurosAte.Enabled Then
                SqlText = SqlText & _
                           "IC_JUROS_NEG = " & QuotedStr(IIf(optCobrarJurosAte_Negociacao.Checked, "S", "N")) & "," & _
                           "IC_JUROS_CTR_FIX = " & QuotedStr(IIf(optCobrarJurosAte_ContratoFixo.Checked, "S", "N")) & "," & _
                           "IC_JUROS_NEG_REC = " & QuotedStr(IIf(optCobrarJurosAte_NegociacaoRecebimento.Checked, "S", "N")) & ","
            Else
                SqlText = SqlText & _
                           "IC_JUROS_NEG = NULL," & _
                           "IC_JUROS_CTR_FIX = NULL," & _
                           "IC_JUROS_NEG_REC = NULL,"
            End If

            SqlText = SqlText & _
                           "DT_ALTERACAO = SYSDATE," & _
                           "NO_USER_ALTERACAO = " & QuotedStr(sAcesso_UsuarioLogado) & _
                      " WHERE CD_CONTRATO_PAF = " & CD_Contrato_PAF
            If Not DBExecutar(SqlText) Then GoTo Erro
        Else
            SqlText = "UPDATE SOF.CONTRATO_PAF" & _
                      " SET QT_DIA_CARENCIA_JUROS = NULL," & _
                           "PC_TAXA_JUROS = NULL," & _
                           "IC_CALCULA_JUROS = 'N'," & _
                           "IC_JUROS_APOS_CARENCIA = NULL," & _
                           "IC_JUROS_NEG = NULL," & _
                           "IC_JUROS_CTR_FIX = NULL," & _
                           "IC_JUROS_NEG_REC = NULL," & _
                           "DT_ALTERACAO = SYSDATE," & _
                           "NO_USER_ALTERACAO = " & QuotedStr(sAcesso_UsuarioLogado) & _
                      "WHERE CD_CONTRATO_PAF = " & CD_Contrato_PAF
            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        Close()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub frmCadastroContratoPAF_AlteracaoJuros_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oData As DataTable
        Dim SqlText As String

        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        SqlText = "SELECT F.NO_RAZAO_SOCIAL," & _
                         "C.CD_CONTRATO_PAF," & _
                         "C.IC_CALCULA_JUROS," & _
                         "C.QT_DIA_CARENCIA_JUROS," & _
                         "C.PC_TAXA_JUROS," & _
                         "C.CD_FORNECEDOR," & _
                         "C.IC_JUROS_APOS_CARENCIA," & _
                         "'S' IC_JUROS_NEG_REC_P," & _
                         "C.IC_JUROS_NEG," & _
                         "C.IC_JUROS_CTR_FIX," & _
                         "C.IC_JUROS_NEG_REC" & _
                  " FROM SOF.CONTRATO_PAF C," & _
                        "SOF.FORNECEDOR F," & _
                        "SOF.PARAMETRO P" & _
                  " WHERE F.CD_FORNECEDOR = C.CD_FORNECEDOR" & _
                    " AND C.CD_CONTRATO_PAF = " & CD_Contrato_PAF
        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            txtContratoPAF.Text = ""
            Pesq_Fornecedor.Codigo = 0
            txtQuantidadeDiasCarenciaCobrancaJuros.Value = 0
            chkCobraJuros.Checked = False
            txtTaxaJuros.Value = 0
            chkConsideraDdiasQuarenciaCobrancaJuros.Checked = False
            fraCobrarJurosAte.Enabled = False
            optCobrarJurosAte_ContratoFixo.Enabled = False
            optCobrarJurosAte_Negociacao.Enabled = False
            optCobrarJurosAte_NegociacaoRecebimento.Enabled = False
        Else
            txtContratoPAF.Text = oData.Rows(0).Item("CD_CONTRATO_PAF")
            Pesq_Fornecedor.Codigo = oData.Rows(0).Item("CD_FORNECEDOR")
            txtQuantidadeDiasCarenciaCobrancaJuros.Value = objDataTable_LerCampo(oData.Rows(0).Item("QT_DIA_CARENCIA_JUROS"), 0)
            chkCobraJuros.Checked = (oData.Rows(0).Item("IC_CALCULA_JUROS") = "S")
            txtTaxaJuros.Value = objDataTable_LerCampo(oData.Rows(0).Item("PC_TAXA_JUROS"), 0)
            chkConsideraDdiasQuarenciaCobrancaJuros.Checked = (NVL(oData.Rows(0).Item("IC_JUROS_APOS_CARENCIA"), "N") = "S")

            If objDataTable_LerCampo(oData.Rows(0).Item("IC_JUROS_NEG"), "N") = "S" Then
                optCobrarJurosAte_Negociacao.Checked = True
            ElseIf objDataTable_LerCampo(oData.Rows(0).Item("IC_JUROS_CTR_FIX"), "N") = "S" Then
                optCobrarJurosAte_ContratoFixo.Checked = True
            ElseIf objDataTable_LerCampo(oData.Rows(0).Item("IC_JUROS_NEG_REC"), "N") = "S" Then
                optCobrarJurosAte_NegociacaoRecebimento.Checked = True
            End If
        End If

        chkCobraJuros_CheckedChanged(Nothing, Nothing)
    End Sub
End Class