Public Class frmSacaria_InclusaoFornecedor
    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click

        On Error GoTo Erro

        If Pesq_Fornecedor.Codigo = 0 Then
            Msg_Mensagem("Favor informar um codigo de fornecedor valido.")
            Pesq_Fornecedor.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboTipoSacaria) Then
            Msg_Mensagem("Favor selecionar um tipo de sacaria.")
            cboTipoSacaria.Focus()
            Exit Sub
        End If
        If txtQuantidade.Value = 0 Then
            Msg_Mensagem("Quantidade de sacos invalida.")
            txtQuantidade.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboEntradaSaida) Then
            Msg_Mensagem("Favor informar se a movimentação é de entrada ou saida.")
            cboEntradaSaida.Focus()
            Exit Sub
        End If
        If Trim(txtDocumento.Text) = "" Then
            Msg_Mensagem("Favor informar o documento.")
            txtDocumento.Focus()
            Exit Sub
        End If

        If FilialFechada(FilialLogada) Then GoTo Erro
        Incluir_Sacaria_Fornecedor()
        Limpa_Tela()

        Pesq_Fornecedor.Focus()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub frmSacaria_InclusaoFornecedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        ComboBox_Carregar_Tipo_Sacaria(cboTipoSacaria, True, True)
        ComboBox_Carregar_EntradaSaida(cboEntradaSaida, True)
    End Sub

    Function Incluir_Sacaria_Fornecedor() As Boolean
        Dim SqlText As String

        SqlText = DBMontar_SP("SOF.INCLUI_SACARIA_FORNECEDOR", False, ":TPSACO", _
                                                                      ":FORN", _
                                                                      ":DATA", _
                                                                      ":QT", _
                                                                      ":FIL", _
                                                                      ":ES", _
                                                                      ":DOC", _
                                                                      ":SQACORDO")

        Return DBExecutar(SqlText, DBParametro_Montar("TPSACO", cboTipoSacaria.SelectedValue), _
                                   DBParametro_Montar("FORN", Pesq_Fornecedor.Codigo), _
                                   DBParametro_Montar("DATA", Date_to_Oracle(DataSistema)), _
                                   DBParametro_Montar("QT", txtQuantidade.Value), _
                                   DBParametro_Montar("FIL", FilialLogada), _
                                   DBParametro_Montar("ES", cboEntradaSaida.SelectedValue), _
                                   DBParametro_Montar("DOC", txtDocumento.Text), _
                                   DBParametro_Montar("SQACORDO", Nothing))
    End Function

    Private Sub Limpa_Tela()
        cboTipoSacaria.SelectedIndex = -1
        txtQuantidade.Value = 0
        cboEntradaSaida.SelectedIndex = -1
        Pesq_Fornecedor.Codigo = 0
        txtDocumento.Text = ""
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub
End Class