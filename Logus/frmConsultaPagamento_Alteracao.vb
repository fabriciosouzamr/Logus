Public Class frmConsultaPagamento_Alteracao
    Public SQ_PAGAMENTO As Integer
    Public AlterouInformacao As Boolean = False

    Private Sub frmConsultaPagamento_Alteracao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chkICMS_Pago.Enabled = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AlterarDisponibilizacaoPagamentoAmarracao)
        chkInterfaceEnviadaJDE.Enabled = SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AlterarIndicadorInterfaceEnviadaJDE_OW)

        Pesq_CodigoNome.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor

        objUltraComboBox_Inicializar(cboTipoPagamento)
        CarregarComboBoxTipoPagamento()
        CarregarDados()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        AlterouInformacao = False
        Close()
    End Sub

    Private Sub CarregarDados()
        Dim oData As DataTable
        Dim SqlText As String

        SqlText = "SELECT * FROM SOF.PAGAMENTOS WHERE SQ_PAGAMENTO = " & SQ_PAGAMENTO
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            With oData.Rows(0)
                Pesq_CodigoNome.Codigo = .Item("CD_FORNECEDOR")
                objUltraComboBox_Possicionar(cboTipoPagamento, 0, .Item("CD_TIPO_PAGAMENTO"))
                chkInterfaceEnviadaJDE.Checked = (objDataTable_LerCampo(.Item("IC_INTERFACE_ENVIADA"), "N") = "S")
                chkICMS_Pago.Checked = (objDataTable_LerCampo(.Item("IC_ICMS_PAGO"), "N") = "S")
            End With
        End If
    End Sub

    Private Sub CarregarComboBoxTipoPagamento()
        Dim SqlText As String

        SqlText = "SELECT CD_TIPO_PAGAMENTO, NO_TIPO_PAGAMENTO, IC_PAGAMENTO_ICMS" & _
                  " FROM SOF.TIPO_PAGAMENTO ORDER BY NO_TIPO_PAGAMENTO"

        objUltraComboBox_Carregar(cboTipoPagamento, SqlText, New Combo_Informacao() {objUltraComboBox_Informacao("Codigo", False, 0, , True), _
                                                                                     objUltraComboBox_Informacao("Descrição", True, 0, True, False), _
                                                                                     objUltraComboBox_Informacao("Paga I.C.M.S.", True, 50, False, False)})
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String

        On Error GoTo Erro

        SqlText = DBMontar_Update("SOF.PAGAMENTOS", GerarArray("CD_FORNECEDOR", ":CD_FORNECEDOR", _
                                                              "CD_TIPO_PAGAMENTO", ":CD_TIPO_PAGAMENTO", _
                                                              "IC_INTERFACE_ENVIADA", ":IC_INTERFACE_ENVIADA", _
                                                              "IC_ICMS_PAGO", ":IC_ICMS_PAGO", _
                                                              "IC_ICMS", ":IC_ICMS"), _
                                                   GerarArray("SQ_PAGAMENTO", ":SQ_PAGAMENTO"))

        If Not DBExecutar(SqlText, _
                          DBParametro_Montar("CD_FORNECEDOR", Pesq_CodigoNome.Codigo), _
                          DBParametro_Montar("CD_TIPO_PAGAMENTO", cboTipoPagamento.SelectedRow.Cells(0).Value), _
                          DBParametro_Montar("IC_INTERFACE_ENVIADA", IIf(chkInterfaceEnviadaJDE.Checked, "S", "N")), _
                          DBParametro_Montar("IC_ICMS_PAGO", IIf(chkICMS_Pago.Checked, "S", "N")), _
                          DBParametro_Montar("IC_ICMS", cboTipoPagamento.SelectedRow.Cells(2).Value), _
                          DBParametro_Montar("SQ_PAGAMENTO", SQ_PAGAMENTO)) Then GoTo Erro

        Msg_Mensagem("Alteração Efetuada")

        Close()

        AlterouInformacao = True

        Exit Sub

Erro:
        TratarErro()
    End Sub
End Class