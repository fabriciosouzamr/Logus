Public Class frmCadastroPDD
    Public SQ_PDD As Integer

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub frmCadastroPDD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        ComboBox_Carregar_Filial(cboFilialReferencia, True)
        ComboBox_Carregar_Tipo_Garantia(cboTipoGarantia, True)

        With Pesq_ContratoPAF
            .Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_ContratoPAF_Fornecedor
            ContratoPAF_Carregar()
        End With

        If SQ_PDD > 0 Then
            CarregarDados()
        End If
    End Sub

    Private Sub ContratoPAF_Carregar()
        With Pesq_ContratoPAF
            .Codigo = 0
            .BancoDados_Filtro_Limpar()
            .BancoDados_Filtro_Adicionar("F.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo)
            .BancoDados_Filtro_Adicionar("IC_STATUS = 'A'")
        End With
    End Sub

    Private Sub Pesq_ContratoPAF_AlterouRegistro() Handles Pesq_ContratoPAF.AlterouRegistro
        Dim SqlText As String

        cboNegociacao.DataSource = Nothing

        If Pesq_ContratoPAF.Codigo = 0 Then Exit Sub

        SqlText = "SELECT SQ_NEGOCIACAO," & _
                         "TO_CHAR(SQ_NEGOCIACAO) AS NO_NEGOCIACAO" & _
                  " FROM SOF.NEGOCIACAO" & _
                  " WHERE IC_STATUS <> 'E'" & _
                    " AND CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                  " ORDER BY SQ_NEGOCIACAO"
        DBCarregarComboBox(cboNegociacao, SqlText, True)
    End Sub

    Private Sub cboNegociacao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNegociacao.SelectedIndexChanged
        Dim SqlText As String

        cboContratoFixo.DataSource = Nothing

        If Not ComboBox_LinhaSelecionada(cboNegociacao) Then Exit Sub

        SqlText = "SELECT SQ_CONTRATO_FIXO," & _
                         "TO_CHAR(SQ_CONTRATO_FIXO) AS NO_CONTRATO_FIXO" & _
                   " FROM SOF.CONTRATO_FIXO" & _
                   " WHERE IC_STATUS <> 'E'" & _
                   " AND CD_CONTRATO_PAF=" & Pesq_ContratoPAF.Codigo & _
                   " AND SQ_NEGOCIACAO=" & cboNegociacao.SelectedValue & _
                  "ORDER BY SQ_CONTRATO_FIXO"
        DBCarregarComboBox(cboContratoFixo, SqlText, True)
    End Sub

    Private Sub cboFilialReferencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilialReferencia.SelectedIndexChanged
        RecuperacaoCredito_Carregar()
    End Sub

    Private Sub RecuperacaoCredito_Carregar()
        Dim SqlText As String

        cboRecuperacaoCredito.DataSource = Nothing

        If Not ComboBox_LinhaSelecionada(cboRecuperacaoCredito) And Pesq_Fornecedor.Codigo > 0 Then
            SqlText = "SELECT CDV.SQ_CONFISSAO_DIVIDA," & _
                             "TO_CHAR(CDV.SQ_CONFISSAO_DIVIDA) || ' - ' || TO_CHAR(CDV.DT_CONFISSAO_DIVIDA) DS_CONFISSAO_DIVIDA" & _
                      " FROM SOF.CONFISSAO_DIVIDA CDV" & _
                      " WHERE CDV.CD_FORNECEDOR = " & Pesq_Fornecedor.Codigo & _
                        " AND CDV.CD_FILIAL_ORIGEM = " & cboFilialReferencia.SelectedValue & _
                        " AND CDV.IC_STATUS = 'A'" & _
                      " ORDER BY TO_CHAR(CDV.SQ_CONFISSAO_DIVIDA) || ' - ' || TO_CHAR(CDV.DT_CONFISSAO_DIVIDA)"
            DBCarregarComboBox(cboRecuperacaoCredito, SqlText, True)
        End If
    End Sub

    Private Sub Pesq_Fornecedor_AlterouRegistro() Handles Pesq_Fornecedor.AlterouRegistro
        ContratoPAF_Carregar()
        RecuperacaoCredito_Carregar()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If Not ComboBox_LinhaSelecionada(cboFilialReferencia) Then
            Msg_Mensagem("Selecione a filial de referência")
            cboFilialReferencia.Focus()
            Exit Sub
        End If
        If Pesq_Fornecedor.Codigo = 0 Then
            Msg_Mensagem("Informe o fornecedor")
            Pesq_Fornecedor.Focus()
            Exit Sub
        End If
        If txtValor.Value = 0 Then
            Msg_Mensagem("Informe o valor ")
            txtValor.Focus()
            Exit Sub
        End If
        If Not optTipo_GAAP.Checked And _
           Not optTipo_PDD.Checked Then
            Msg_Mensagem("Selecione o Tipo do PDD")
            optTipo_GAAP.Focus()
            Exit Sub
        End If
        If Pesq_ContratoPAF.Codigo = 0 And _
           Not ComboBox_LinhaSelecionada(cboRecuperacaoCredito) And _
           Trim(txtDescricaoPDD.Text) = "" Then
            Msg_Mensagem("Informe um contrato ou uma receperação de crédito ou a descrição do que será cadastrado")
            Exit Sub
        End If
        If IIf(Pesq_ContratoPAF.Codigo = 0, 0, 1) + _
           IIf(ComboBox_LinhaSelecionada(cboRecuperacaoCredito), 1, 0) + _
           IIf(Trim(txtDescricaoPDD.Text) = "", 0, 1) > 1 Then
            Msg_Mensagem("Só é possível um contrato ou uma receperação de crédito ou a descrição do que será cadastrado")
            Exit Sub
        End If
        If Trim(txtStatus.Text) = "" Then
            Msg_Mensagem("Informe o status atual do PDD")
            txtStatus.Focus()
            Exit Sub
        End If
        If Not IsDate(txtDataVencimento.Value) Then
            Msg_Mensagem("Informe a data de vencimento")
            txtDataVencimento.Focus()
            Exit Sub
        End If

        Dim SqlText As String
        Dim SQ_PDD_Int As Integer
        Dim SQ_CONFISSAO_DIVIDA As Integer = 0
        Dim CD_CONTRATO_PAF As Integer = 0
        Dim SQ_NEGOCIACAO As Integer = 0
        Dim SQ_CONTRATO_FIXO As Integer = 0

        SQ_PDD_Int = SQ_PDD

        If ComboBox_LinhaSelecionada(cboRecuperacaoCredito) Then
            SQ_CONFISSAO_DIVIDA = cboRecuperacaoCredito.SelectedValue
        End If
        If Pesq_ContratoPAF.Codigo > 0 Then
            CD_CONTRATO_PAF = Pesq_ContratoPAF.Codigo
        End If
        If ComboBox_LinhaSelecionada(cboNegociacao) Then
            SQ_NEGOCIACAO = cboNegociacao.SelectedValue
        End If
        If ComboBox_LinhaSelecionada(cboContratoFixo) Then
            SQ_CONTRATO_FIXO = cboContratoFixo.SelectedValue
        End If

        If SQ_PDD_Int = 0 Then
            SqlText = DBMontar_Insert("SOF.PDD", TipoCampoFixo.Todos, "CD_TIPO_PDD", ":CD_TIPO_PDD", _
                                                                      "CD_FILIAL_REFERENCIA", ":CD_FILIAL_REFERENCIA", _
                                                                      "CD_FORNECEDOR", ":CD_FORNECEDOR", _
                                                                      "SQ_CONFISSAO_DIVIDA", ":SQ_CONFISSAO_DIVIDA", _
                                                                      "CD_CONTRATO_PAF", ":CD_CONTRATO_PAF", _
                                                                      "SQ_NEGOCIACAO", ":SQ_NEGOCIACAO", _
                                                                      "SQ_CONTRATO_FIXO", ":SQ_CONTRATO_FIXO", _
                                                                      "DS_PDD", ":DS_PDD", _
                                                                      "CD_TIPO_GARANTIA", ":CD_TIPO_GARANTIA", _
                                                                      "IC_BENS", ":IC_BENS", _
                                                                      "CM_STATUS", ":CM_STATUS", _
                                                                      "CM_OBSERVACAO", ":CM_OBSERVACAO", _
                                                                      "QT_KGS_DEVEDOR", ":QT_KGS_DEVEDOR", _
                                                                      "VL_DEVEDOR", ":VL_DEVEDOR", _
                                                                       "DT_VENCIMENTO", ":DT_VENCIMENTO", _
                                                                      "SQ_PDD", ":SQ_PDD")

            SQ_PDD_Int = DBNumeroMaisUm("SOF.PDD", "SQ_PDD")
        Else
            SqlText = DBMontar_Update("SOF.PDD", GerarArray("CD_TIPO_PDD", ":CD_TIPO_PDD", _
                                                            "CD_FILIAL_REFERENCIA", ":CD_FILIAL_REFERENCIA", _
                                                            "CD_FORNECEDOR", ":CD_FORNECEDOR", _
                                                            "SQ_CONFISSAO_DIVIDA", ":SQ_CONFISSAO_DIVIDA", _
                                                            "CD_CONTRATO_PAF", ":CD_CONTRATO_PAF", _
                                                            "SQ_NEGOCIACAO", ":SQ_NEGOCIACAO", _
                                                            "SQ_CONTRATO_FIXO", ":SQ_CONTRATO_FIXO", _
                                                            "DS_PDD", ":DS_PDD", _
                                                            "CD_TIPO_GARANTIA", ":CD_TIPO_GARANTIA", _
                                                            "IC_BENS", ":IC_BENS", _
                                                            "CM_STATUS", ":CM_STATUS", _
                                                            "CM_OBSERVACAO", ":CM_OBSERVACAO", _
                                                            "QT_KGS_DEVEDOR", ":QT_KGS_DEVEDOR", _
                                                            "VL_DEVEDOR", ":VL_DEVEDOR", _
                                                            "DT_VENCIMENTO", ":DT_VENCIMENTO"), _
                                                 GerarArray("SQ_PDD", ":SQ_PDD"))
        End If

        If Not DBExecutar(SqlText, DBParametro_Montar("CD_TIPO_PDD", IIf(optTipo_GAAP.Checked, optTipo_GAAP.Tag, optTipo_PDD.Tag)), _
                                   DBParametro_Montar("CD_FILIAL_REFERENCIA", cboFilialReferencia.SelectedValue), _
                                   DBParametro_Montar("CD_FORNECEDOR", Pesq_Fornecedor.Codigo), _
                                   DBParametro_Montar("SQ_CONFISSAO_DIVIDA", NULLIf(SQ_CONFISSAO_DIVIDA, 0)), _
                                   DBParametro_Montar("CD_CONTRATO_PAF", NULLIf(CD_CONTRATO_PAF, 0)), _
                                   DBParametro_Montar("SQ_NEGOCIACAO", NULLIf(SQ_NEGOCIACAO, 0)), _
                                   DBParametro_Montar("SQ_CONTRATO_FIXO", NULLIf(SQ_CONTRATO_FIXO, 0)), _
                                   DBParametro_Montar("DS_PDD", NULLIf(Trim(txtDescricaoPDD.Text), "")), _
                                   DBParametro_Montar("CD_TIPO_GARANTIA", NULLIf(cboTipoGarantia.SelectedValue, -1)), _
                                   DBParametro_Montar("IC_BENS", IIf(optBens_NaoDefinido.Checked, Nothing, IIf(optBens_Sim.Checked, "S", "N"))), _
                                   DBParametro_Montar("CM_STATUS", Trim(txtStatus.Text)), _
                                   DBParametro_Montar("CM_OBSERVACAO", NULLIf(Trim(txtObservacao.Text), ""), , , 4000), _
                                   DBParametro_Montar("QT_KGS_DEVEDOR", txtQuantidade.Value), _
                                   DBParametro_Montar("VL_DEVEDOR", txtValor.Value), _
                                   DBParametro_Montar("DT_VENCIMENTO", Date_to_Oracle(txtDataVencimento.Text), DbType.DateTime), _
                                   DBParametro_Montar("SQ_PDD", SQ_PDD_Int)) Then GoTo Erro

        SQ_PDD = SQ_PDD_Int

        Msg_Mensagem("Gravação Efetuada")
        Close()
        Exit Sub

Erro:
        TratarErro(, , "frmCadastroPDD.cmdGravar_Click")
    End Sub

    Private Sub CarregarDados()
        Dim oData As DataTable
        Dim SqlText As String

        SqlText = "SELECT * " & _
                  " FROM SOF.PDD" & _
                  " WHERE SQ_PDD = " & SQ_PDD
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            With oData.Rows(0)
                ComboBox_Possicionar(cboFilialReferencia, .Item("CD_FILIAL_REFERENCIA"))
                Pesq_Fornecedor.Codigo = .Item("CD_FORNECEDOR")
                txtQuantidade.Value = NVL(.Item("QT_KGS_DEVEDOR"), 0)
                txtValor.Value = NVL(.Item("VL_DEVEDOR"), 0)

                Select Case NVL(.Item("IC_BENS"), "X")
                    Case "X"
                        optBens_NaoDefinido.Checked = True
                    Case "S"
                        optBens_Sim.Checked = True
                    Case "N"
                        optBens_Nao.Checked = True
                End Select

                ComboBox_Possicionar(cboTipoGarantia, NVL(.Item("CD_TIPO_GARANTIA"), 0))
                Pesq_ContratoPAF.Codigo = NVL(.Item("CD_CONTRATO_PAF"), 0)
                ComboBox_Possicionar(cboNegociacao, NVL(.Item("SQ_NEGOCIACAO"), 0))
                ComboBox_Possicionar(cboContratoFixo, NVL(.Item("SQ_CONTRATO_FIXO"), 0))
                ComboBox_Possicionar(cboRecuperacaoCredito, NVL(.Item("SQ_CONFISSAO_DIVIDA"), 0))
                txtDescricaoPDD.Text = NVL(.Item("DS_PDD"), "")

                If NVL(.Item("CD_TIPO_PDD"), 0) = optTipo_GAAP.Tag Then
                    optTipo_GAAP.Checked = True
                Else
                    optTipo_PDD.Checked = True
                End If
                txtDataVencimento.Text = NVL(.Item("DT_VENCIMENTO"), Nothing)
                txtStatus.Text = NVL(.Item("CM_STATUS"), "")
                txtObservacao.Text = NVL(.Item("CM_OBSERVACAO"), "")
            End With
        End If

        objData_Finalizar(oData)
    End Sub

   
End Class