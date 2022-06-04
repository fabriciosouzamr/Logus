Public Class frmEstornoDesagio
    Const cnt_GridMovimentacao_SQ_MOVIMENTACAO As Integer = 0
    Const cnt_GridMovimentacao_NU_NF As Integer = 1
    Const cnt_GridMovimentacao_NO_FORNECEDOR As Integer = 2
    Const cnt_GridMovimentacao_DT_MOVIMENTACAO As Integer = 3
    Const cnt_GridMovimentacao_QT_ANALISE As Integer = 4
    Const cnt_GridMovimentacao_QT_ANALISE_PADRAO As Integer = 5
    Const cnt_GridMovimentacao_QT_APLICADO As Integer = 6

    Dim oDS As New Infragistics.Win.UltraWinDataSource.UltraDataSource
    Dim SQ_PAGAMENTO As Integer

    Private Sub frmEstornoDesagio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_ContratoPAF.Tipo_Pesquisa = Pesq_CodigoNome.TPPesquisa.Pq_Logus_ContratoPAF

        objGrid_Inicializar(grdMovimentacao, , oDS)
        objGrid_Coluna_Add(grdMovimentacao, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdMovimentacao, "N.F.º", 80)
        objGrid_Coluna_Add(grdMovimentacao, "Fornecedor", 150)
        objGrid_Coluna_Add(grdMovimentacao, "Data", 80, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdMovimentacao, " ", 80, , , , , cnt_Formato_Fracao)
        objGrid_Coluna_Add(grdMovimentacao, "Padrão", 80, , , , , cnt_Formato_Fracao)
        objGrid_Coluna_Add(grdMovimentacao, "KG Fixo", 100, , , , , cnt_Formato_Kilos)
    End Sub

    Private Sub Pesq_ContratoPAF_AlterouRegistro() Handles Pesq_ContratoPAF.AlterouRegistro
        Dim SqlText As String
        Dim oData As DataTable

        If Pesq_ContratoPAF.Codigo <> 0 Then
            If Pesq_ContratoPAF.Codigo = 0 Then Exit Sub
            cboContratoFixo.DataSource = Nothing
            oDS.Rows.Clear()

            SqlText = "SELECT F.NO_RAZAO_SOCIAL," & _
                             "CP.CD_FORNECEDOR," & _
                             "F.CD_FILIAL_ORIGEM," & _
                             "CP.IC_CALCULA_JUROS," & _
                             "CP.IC_JUROS_NEG_REC," & _
                             "CP.IC_STATUS" & _
                      " FROM SOF.FORNECEDOR F," & _
                            "SOF.CONTRATO_PAF CP " & _
                      " WHERE CP.CD_FORNECEDOR = F.CD_FORNECEDOR" & _
                        " AND CP.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo
            oData = DBQuery(SqlText)

            If oData.Rows.Count = 0 Then
                Msg_Mensagem("Contrato não encontrado")
                GoTo Limpar
            Else
                If oData.Rows(0).Item("IC_STATUS") = "E" Then
                    Msg_Mensagem("Este contrato já está eliminado")
                    GoTo Limpar
                ElseIf oData.Rows(0).Item("IC_STATUS") = "C" Then
                    Msg_Mensagem("Este contrato está cancelado")
                    GoTo Limpar
                End If
            End If

            SqlText = "SELECT COUNT(*) QT FROM SOF.CONFISSAO_DIVIDA_ATIVO_VENDA WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo

            If DBQuery_ValorUnico(SqlText) <> 0 Then
                Msg_Mensagem("Esse contrato é uma liquidação de uma recuperação de crédito.")
                GoTo Limpar
            End If

            SqlText = "SELECT NO_RAZAO_SOCIAL," & _
                             "CD_FILIAL_ORIGEM " & _
                      " FROM SOF.FORNECEDOR " & _
                      " WHERE CD_FORNECEDOR = " & oData.Rows(0).Item("CD_FORNECEDOR") & _
                        " AND CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")"
            oData = DBQuery(SqlText)

            If objDataTable_Vazio(oData) Then
                Msg_Mensagem("Este fornecedor não pertence a nenhuma das filiais liberadas para o seu acesso")
                GoTo Limpar
            End If

            SqlText = "SELECT SQ_NEGOCIACAO," & _
                             "CAST(SQ_NEGOCIACAO AS VARCHAR2(15)) NO_NEGOCIACAO" & _
                      " FROM SOF.NEGOCIACAO" & _
                      " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                        " AND IC_STATUS NOT IN ('E')"
            DBCarregarComboBox(cboNegocicao, SqlText, True)

            cboNegocicao.Enabled = (cboNegocicao.Items.Count > 0)
            cboContratoFixo.Enabled = cboNegocicao.Enabled
        End If

        Exit Sub

Limpar:
        Pesq_ContratoPAF.Codigo = 0
    End Sub

    Private Sub cboNegocicao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNegocicao.SelectedIndexChanged
        If Not ComboBox_LinhaSelecionada(cboNegocicao) Then Exit Sub

        On Error GoTo Erro

        Dim SqlText As String

        SqlText = "SELECT SQ_CONTRATO_FIXO," & _
                         "CAST(SQ_CONTRATO_FIXO AS VARCHAR2(10))" & _
                  " FROM SOF.CONTRATO_FIXO" & _
                  " WHERE CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                   " AND SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue & _
                   " AND IC_STATUS NOT IN ('E')"
        DBCarregarComboBox(cboContratoFixo, SqlText, True)

        cboContratoFixo.Enabled = (cboContratoFixo.Items.Count > 0)

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub CarregarDados()
        SQ_PAGAMENTO = 0
        txtValorAjuste.Value = 0
        txtValorAjuste.Tag = 0

        If optTipo.Value = Nothing Then Exit Sub
        If Not ComboBox_LinhaSelecionada(cboContratoFixo) Then Exit Sub

        Dim oData As DataTable
        Dim SqlText As String
        Dim Indice As Double
        Dim iCont_01 As Integer
        Dim AcumulaQuantidade As Double
        Dim AcumulaQualidade As Double
        Dim iCont_02 As Double
        Dim bCalcula As Boolean
        Dim Soma As Double
        Dim VL_UNITARIO As Double
        Dim QT_FATOR_CTR As Double

        SqlText = "SELECT CP.VL_FIXO," & _
                         "P.SQ_PAGAMENTO," & _
                         "DECODE(NVL(P.VL_TAXA_DOLAR, 0), 0, 1, P.VL_TAXA_DOLAR) VL_TAXA_DOLAR" & _
                  " FROM SOF.PAG_NEG_CTR_FIX CP," & _
                        "(SELECT PG.*" & _
                         " FROM SOF.PAGAMENTOS PG," & _
                               "(SELECT " & IIf(optTipo.Value = "U", "CD_TP_PAG_DESAGIO_UMIDADE", _
                                                                     "CD_TP_PAG_DESAGIO_SUJIDADE") & " CD_TP_PAG " & _
                                " FROM SOF.PARAMETRO) PR" & _
                         " WHERE PG.CD_TIPO_PAGAMENTO = PR.CD_TP_PAG) P" & _
                  " WHERE CP.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND CP.SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue & _
                    " AND CP.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue & _
                    " AND  P.SQ_PAGAMENTO = CP.SQ_PAGAMENTO"
        If optTipo.Value = "U" Then
            Indice = cnt_TipoDesagio_Umidade
            grdMovimentacao.DisplayLayout.Bands(0).Columns(cnt_GridMovimentacao_QT_ANALISE).Header.Caption = "Umidade"
        Else
            Indice = cnt_TipoDesagio_Sujidade
            grdMovimentacao.DisplayLayout.Bands(0).Columns(cnt_GridMovimentacao_QT_ANALISE).Header.Caption = "Sujidade"
        End If

        oData = DBQuery(SqlText)

        If objDataTable_Vazio(oData) Then
            txtValorDescontado.Value = 0
            txtPC_Contrato.Value = 0
        Else
            With oData.Rows(0)
                txtValorDescontado.Value = objDataTable_LerCampo(.Item("VL_FIXO"), 0)
                txtPC_Contrato.Value = objDataTable_LerCampo(.Item("VL_TAXA_DOLAR"), 0)
                SQ_PAGAMENTO = objDataTable_LerCampo(.Item("SQ_PAGAMENTO"), 0)
            End With
        End If

        SqlText = "SELECT CF.VL_UNITARIO," & _
                         "TU.QT_FATOR" & _
                  " FROM SOF.CONTRATO_FIXO CF," & _
                        "SOF.TIPO_UNIDADE TU" & _
                  " WHERE CF.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND CF.SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue & _
                    " AND CF.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue & _
                    " AND TU.CD_TIPO_UNIDADE = CF.CD_TIPO_UNIDADE"
        oData = DBQuery(SqlText)

        With oData.Rows(0)
            VL_UNITARIO = objDataTable_LerCampo(.Item("VL_UNITARIO"), 0)
            QT_FATOR_CTR = objDataTable_LerCampo(.Item("QT_FATOR"), 0)
        End With

        objData_Finalizar(oData)

        If optTipo.Value = "U" Then
            SqlText = "SELECT N.QT_UMIDADE_PADRAO" & _
                      " FROM SOF.NEGOCIACAO N" & _
                      " WHERE N.CD_CONTRATO_PAF =" & Pesq_ContratoPAF.Codigo & _
                        " AND N.SQ_NEGOCIACAO =" & cboNegocicao.SelectedValue
        Else
            SqlText = "SELECT N.PC_SUJIDADE_PADRAO" & _
                      " FROM SOF.NEGOCIACAO N" & _
                      " WHERE N.CD_CONTRATO_PAF =" & Pesq_ContratoPAF.Codigo & _
                        " AND N.SQ_NEGOCIACAO =" & cboNegocicao.SelectedValue
        End If

        txtValorDesagio.Value = DBQuery_ValorUnico(SqlText, 0)

        SqlText = "SELECT MOV.SQ_MOVIMENTACAO," & _
                         "TRIM(MOV.NU_NF) || NVL2(MOV.NU_SERIE_NF, ' - ' || TRIM(MOV.NU_SERIE_NF), '') NU_NF," & _
                         "FRN.NO_RAZAO_SOCIAL NO_FORNECEDOR," & _
                         "MOV.DT_MOVIMENTACAO," & _
                         IIf(optTipo.Value = "U", "MQ.QT_UMIDADE,", "MQ.PC_SUJIDADE,") & _
                         "CFM.QT_KG_FIXO" & _
                  " FROM SOF.CTR_PAF_NEG_CTR_FIX_MOV CFM," & _
                        "SOF.MOVIMENTACAO MOV," & _
                        "SOF.FORNECEDOR FRN," & _
                        "SOF.MOVIMENTACAO_QUALIDADE MQ" & _
                  " WHERE CFM.CD_CONTRATO_PAF = " & Pesq_ContratoPAF.Codigo & _
                    " AND CFM.SQ_NEGOCIACAO = " & cboNegocicao.SelectedValue & _
                    " AND CFM.SQ_CONTRATO_FIXO = " & cboContratoFixo.SelectedValue & _
                    " AND MOV.SQ_MOVIMENTACAO = CFM.SQ_MOVIMENTACAO" & _
                    " AND FRN.CD_FORNECEDOR = MOV.CD_FORNECEDOR" & _
                    " AND MQ.SQ_MOVIMENTACAO (+) = MOV.SQ_MOVIMENTACAO"
        objGrid_Carregar(grdMovimentacao, SqlText, New Integer() {cnt_GridMovimentacao_SQ_MOVIMENTACAO, _
                                                                  cnt_GridMovimentacao_NU_NF, _
                                                                  cnt_GridMovimentacao_NO_FORNECEDOR, _
                                                                  cnt_GridMovimentacao_DT_MOVIMENTACAO, _
                                                                  cnt_GridMovimentacao_QT_ANALISE, _
                                                                  cnt_GridMovimentacao_QT_APLICADO})

        For iCont_01 = 0 To grdMovimentacao.Rows.Count - 1
            With grdMovimentacao.Rows(iCont_01)
                .Cells(cnt_GridMovimentacao_QT_ANALISE_PADRAO).Value = IndiceValor(cnt_Processo_IndiceValores, Indice, .Cells(cnt_GridMovimentacao_DT_MOVIMENTACAO).Value)
                .Update()
            End With
        Next

        With grdMovimentacao.DisplayLayout.Bands(0)
            .SortedColumns.Add(.Columns(cnt_GridMovimentacao_QT_ANALISE_PADRAO), False)
        End With

        iCont_02 = 0

        For iCont_01 = 0 To grdMovimentacao.Rows.Count - 1
            With grdMovimentacao.Rows(iCont_01)
                bCalcula = False
                Indice = .Cells(cnt_GridMovimentacao_QT_ANALISE_PADRAO).Value
                AcumulaQuantidade = AcumulaQuantidade + .Cells(cnt_GridMovimentacao_QT_APLICADO).Value
                AcumulaQualidade = AcumulaQualidade + (NVL(.Cells(cnt_GridMovimentacao_QT_ANALISE).Value, 0) * .Cells(cnt_GridMovimentacao_QT_APLICADO).Value)
                iCont_02 = iCont_02 + 1

                If iCont_01 = grdMovimentacao.Rows.Count - 1 Then
                    bCalcula = True
                ElseIf grdMovimentacao.Rows(iCont_01 + 1).Cells(cnt_GridMovimentacao_QT_ANALISE_PADRAO).Value <> Indice Then
                    bCalcula = True
                End If

                If bCalcula Then
                    AcumulaQualidade = (Math.Round(AcumulaQualidade / AcumulaQuantidade, 2))
                    If AcumulaQualidade > Indice Then
                        AcumulaQualidade = AcumulaQualidade - Indice
                    Else
                        AcumulaQualidade = 0
                    End If
                    If AcumulaQualidade > 0 And QT_FATOR_CTR > 0 Then
                        Soma = Soma + ((AcumulaQualidade / 100) * AcumulaQuantidade) * (VL_UNITARIO / QT_FATOR_CTR)
                    End If

                    AcumulaQuantidade = 0
                    AcumulaQualidade = 0
                    iCont_02 = 0
                End If
            End With
        Next

        If txtValorDescontado.Value > 0 Then
            txtValorAjuste.Value = txtValorDescontado.Value - Math.Round(Soma, 2)
            txtValorAjuste.Tag = txtValorAjuste.Value
        End If
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        CarregarDados()
    End Sub

    Private Sub cboContratoFixo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContratoFixo.SelectedIndexChanged
        CarregarDados()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Function IndiceValor(ByVal CD_PROCESSO As Integer, _
                                 ByVal CD_INDICE As Integer, _
                                 ByVal DT_INDICE_VALOR As Date) As Double
        Dim SqlText As String

        SqlText = "SELECT MAX(DT_INDICE_VALOR)" & _
                  " FROM SOF.INDICE_VALORES" & _
                  " WHERE CD_PROCESSO = " & CD_PROCESSO & _
                    " AND CD_INDICE = " & CD_INDICE & _
                    " AND DT_INDICE_VALOR <= " & QuotedStr(Date_to_Oracle(DT_INDICE_VALOR))

        SqlText = "SELECT MAX(NVL(VL_INDICE, 0))" & _
                  " FROM SOF.INDICE_VALORES" & _
                  " WHERE CD_PROCESSO = " & CD_PROCESSO & _
                    " AND CD_INDICE = " & CD_INDICE & _
                    " AND DT_INDICE_VALOR = " & QuotedStr(Date_to_Oracle(DBQuery_ValorUnico(SqlText, Now.Date)))

        Return DBQuery_ValorUnico(SqlText, -1)
    End Function

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If Not fIN(optTipo.Value, "U", "S") Then
            Msg_Mensagem("Selecione o tipo de qualidade")
            Exit Sub
        End If
        If txtValorAjuste.Value = 0 Then
            Msg_Mensagem("Informe o valor de ajuste")
            Exit Sub
        End If
        If txtValorDescontado.Value = 0 Then
            Msg_Mensagem("Não foi realizado descontado de " & IIf(optTipo.Value = "U", "umidade", "sujidade") & " para esse contrato fixo.")
            Exit Sub
        End If
        If txtValorAjuste.Value < 0 Or txtValorAjuste.Value > txtValorDescontado.Value Then
            Msg_Mensagem("O valor do ajuste não pode ser menor que zero nem maior que o valor descontado")
            Exit Sub
        End If
        If Trim(txtMotivo.Text) = "" Then
            Msg_Mensagem("Informe o motivo desse estorno")
            Exit Sub
        End If

        Dim SqlText As String
        Dim NR_SOLICITACAO As Integer

        SqlText = "SELECT COUNT(*)" & _
                  " FROM SOF.SOLICITACAO_ESTORNO_DESAGIO" & _
                  " WHERE SQ_PAGAMENTO = " & SQ_PAGAMENTO & _
                    " AND IC_APROVADO = 'A' OR IC_APROVADO IS NULL"
        If DBQuery_ValorUnico(SqlText) > 0 Then
            Msg_Mensagem("Já foi feita uma solicitação de estorno de desagio de " & _
                         IIf(optTipo.Value = "U", "umidade", "sujidade") & " para esse contrato fixo.")
            Exit Sub
        End If

        If txtValorAjuste.Tag <> txtValorAjuste.Value Then
            txtMotivo.Text = "Valor solicitado diferente do valor, " & FormatCurrency(txtValorAjuste.Tag, 2) & " , sugirido pelo sistema." & vbCrLf & _
                             txtMotivo.Text
        End If

        SqlText = "SELECT MAX(NR_SOLICITACAO)" & _
                  " FROM SOF.SOLICITACAO_ESTORNO_DESAGIO" & _
                  " WHERE SQ_PAGAMENTO = " & SQ_PAGAMENTO
        NR_SOLICITACAO = (DBQuery_ValorUnico(SqlText, 0) + 1)

        SqlText = DBMontar_Insert("SOF.SOLICITACAO_ESTORNO_DESAGIO", TipoCampoFixo.Todos, "SQ_PAGAMENTO", ":SQ_PAGAMENTO", _
                                                                                          "NR_SOLICITACAO", ":NR_SOLICITACAO", _
                                                                                          "CD_USUARIO_SOLICITACAO", ":CD_USUARIO_SOLICITACAO", _
                                                                                          "DT_SOLICITACAO", "SYSDATE", _
                                                                                          "CM_MOTIVO_SOLICITACAO", ":CM_MOTIVO_SOLICITACAO", _
                                                                                          "VL_DESCONTO", ":VL_DESCONTO")

        If Not DBExecutar(SqlText, DBParametro_Montar("SQ_PAGAMENTO", SQ_PAGAMENTO), _
                                   DBParametro_Montar("NR_SOLICITACAO", NR_SOLICITACAO), _
                                   DBParametro_Montar("CD_USUARIO_SOLICITACAO", sAcesso_UsuarioLogado), _
                                   DBParametro_Montar("CM_MOTIVO_SOLICITACAO", txtMotivo.Text), _
                                   DBParametro_Montar("VL_DESCONTO", txtValorAjuste.Value)) Then GoTo Erro

        Pesq_ContratoPAF.Codigo = 0
        cboNegocicao.DataSource = Nothing
        cboContratoFixo.DataSource = Nothing
        txtPC_Contrato.Value = 0
        txtValorAjuste.Value = 0
        txtValorDesagio.Value = 0
        txtValorDescontado.Value = 0
        txtMotivo.Text = ""
        oDS.Rows.Clear()

        Msg_Mensagem("Solicitação cadastrada")

        Exit Sub

Erro:
        TratarErro(, , "frmEstornoDesagio.cmdGravar_Click")
    End Sub
End Class