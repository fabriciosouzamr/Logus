Public Class frmSacaria_InclusaoFilial
    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub chkTransferencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTransferencia.CheckedChanged
        Validar_CheckTransferencia()
    End Sub

    Private Sub Validar_CheckTransferencia()
        If chkTransferencia.Checked Then
            cboFilialDebito.Enabled = True
        Else
            ComboBox_Possicionar(cboFilialDebito, FilialLogada)
            cboFilialDebito.Enabled = False
        End If
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        On Error GoTo Erro

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
        If Trim(txtDocumento.Text) = "" Then
            Msg_Mensagem("Favor informar o documento.")
            txtDocumento.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboEntradaSaida) Then
            Msg_Mensagem("Favor informar se a movimentação é de entrada ou saida.")
            cboEntradaSaida.Focus()
            Exit Sub
        Else
            If cboEntradaSaida.SelectedValue = "S" Then
                If Not ComboBox_LinhaSelecionada(cboTipoMovimentacao) = -1 And Not chkTransferencia.Checked Then
                    Msg_Mensagem("Informe o Tipo de Movimentação de Sacaria")
                    cboTipoMovimentacao.Focus()
                    Exit Sub
                End If
            End If
        End If
        If chkTransferencia.Checked Then
            If Not ComboBox_LinhaSelecionada(cboFilialDebito) Then
                Msg_Mensagem("Favor selecionar uma filial.")
                cboFilialDebito.Focus()
                Exit Sub
            End If
            If cboFilialDebito.SelectedValue = FilialLogada Then
                Msg_Mensagem("Favor mudar a filial destino.")
                cboFilialDebito.Focus()
                Exit Sub
            End If
        End If

        If FilialFechada(FilialLogada) Then Exit Sub

        DBUsarTransacao = True
        If Not Incluir_Sacaria_Filial() Then GoTo Erro
        If Not DBExecutarTransacao() Then GoTo Erro

        Limpa_Tela()

        cboTipoSacaria.Focus()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub frmSacaria_InclusaoFilial_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ComboBox_Carregar_Tipo_Sacaria(cboTipoSacaria)
        ComboBox_Carregar_Filial(cboFilialDebito, True)
        ComboBox_Carregar_Tipo_Movimentacao_Sacaria(cboTipoMovimentacao, True)
        ComboBox_Carregar_EntradaSaida(cboEntradaSaida)

        Limpa_Tela()

        Call ValidaEntradaSaida()
    End Sub

    Private Sub Limpa_Tela()
        cboTipoSacaria.SelectedIndex = -1
        txtQuantidade.Value = 0
        txtDocumento.Text = ""
        cboEntradaSaida.SelectedIndex = -1
        chkTransferencia.Checked = False
        chkTransferencia.Enabled = False
        cboFilialDebito.SelectedIndex = -1
        cboTipoMovimentacao.SelectedIndex = -1
    End Sub

    Function Incluir_Sacaria_Filial() As Boolean
        Dim SqlText As String
        Dim TIPO_MOVIMENTACAO As Boolean

        If cboTipoMovimentacao.SelectedIndex = -1 Or chkTransferencia.Checked Or Not cboTipoMovimentacao.Enabled Then
            TIPO_MOVIMENTACAO = False
        Else
            TIPO_MOVIMENTACAO = True
        End If

        SqlText = DBMontar_SP("SOF.INCLUI_SACARIA_FILIAL", False, ":TPSACO", _
                                                                  ":DATA", _
                                                                  ":QT", _
                                                                  ":FILCRE", _
                                                                  ":FILDEB", _
                                                                  ":ES", _
                                                                  ":DOC", _
                                                                  ":TIPO_MOVIMENTACAO")

        Return DBExecutar(SqlText, DBParametro_Montar("TPSACO", cboTipoSacaria.SelectedValue), _
                                   DBParametro_Montar("DATA", Date_to_Oracle(DataSistema)), _
                                   DBParametro_Montar("QT", txtQuantidade.Value), _
                                   DBParametro_Montar("FILCRE", FilialLogada), _
                                   DBParametro_Montar("FILDEB", cboFilialDebito.SelectedValue), _
                                   DBParametro_Montar("ES", cboEntradaSaida.SelectedValue), _
                                   DBParametro_Montar("DOC", Trim(txtDocumento.Text)), _
                                   DBParametro_Montar("TIPO_MOVIMENTACAO", IIf(TIPO_MOVIMENTACAO, _
                                                                               cboTipoMovimentacao.SelectedValue, _
                                                                               Nothing)))
    End Function

    Private Sub ValidaEntradaSaida()
        cboTipoMovimentacao.Enabled = (cboEntradaSaida.SelectedIndex = 1)

        If Not cboTipoMovimentacao.Enabled Then
            cboTipoMovimentacao.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboEntradaSaida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEntradaSaida.SelectedIndexChanged
        Select Case cboEntradaSaida.SelectedIndex
            Case 0
                chkTransferencia.Checked = False
                Validar_CheckTransferencia()
                chkTransferencia.Enabled = False
            Case 1
                chkTransferencia.Enabled = True

                If FilialLogada <> FilialMae Then
                    chkTransferencia.Checked = True
                    Validar_CheckTransferencia()
                    chkTransferencia.Enabled = False
                Else
                    If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_Abrir_FecharContratoPAF) Then
                        chkTransferencia.Checked = True
                        Validar_CheckTransferencia()
                        chkTransferencia.Enabled = False
                    End If
                End If
        End Select

        ValidaEntradaSaida()
    End Sub
End Class