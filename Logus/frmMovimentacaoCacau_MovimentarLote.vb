Public Class frmMovimentacaoCacau_MovimentarLote
    Const cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO As Integer = 0
    Const cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO_PILHA_ARMAZEM As Integer = 1
    Const cnt_GridMovimentacaoEstoque_CD_TIPO_SACARIA As Integer = 2
    Const cnt_GridMovimentacaoEstoque_FornecedorFilial As Integer = 3
    Const cnt_GridMovimentacaoEstoque_DtMovimentacao As Integer = 4
    Const cnt_GridMovimentacaoEstoque_NF As Integer = 5
    Const cnt_GridMovimentacaoEstoque_TipoSacaria As Integer = 6
    Const cnt_GridMovimentacaoEstoque_Volume As Integer = 7
    Const cnt_GridMovimentacaoEstoque_SacosEstoque As Integer = 8
    Const cnt_GridMovimentacaoEstoque_SacosMovimentar As Integer = 9
    Const cnt_GridMovimentacaoEstoque_Procedencia As Integer = 10

    Const cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO As Integer = 0
    Const cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO_PILHA_ARMAZEM As Integer = 1
    Const cnt_GridMovimentarPilhaDestino_CD_TIPO_SACARIA As Integer = 2
    Const cnt_GridMovimentarPilhaDestino_FornecedorFilial As Integer = 3
    Const cnt_GridMovimentarPilhaDestino_DtMovimentacao As Integer = 4
    Const cnt_GridMovimentarPilhaDestino_NF As Integer = 5
    Const cnt_GridMovimentarPilhaDestino_TipoSacaria As Integer = 6
    Const cnt_GridMovimentarPilhaDestino_Volume As Integer = 7
    Const cnt_GridMovimentarPilhaDestinoSacosMovimentar As Integer = 8

    Dim CD_ARMAZEM As Integer
    Dim CD_PILHA As Integer
    Dim CD_PROCEDENCIA_PILHA_DESTINO As String
    Dim bProcInterno As Boolean

    Dim oDS_MovimentacaoEstoque As New Infragistics.Win.UltraWinDataSource.UltraDataSource
    Dim oDS_MovimentarPilhaDestino As New Infragistics.Win.UltraWinDataSource.UltraDataSource

    Private Sub frmMovimentacaoCacau_MovimentarLote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Armazem(cboArmazem, , True)

        objGrid_Inicializar(grdMovimentacaoEstoque, , oDS_MovimentacaoEstoque)
        objGrid_Coluna_Add(grdMovimentacaoEstoque, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdMovimentacaoEstoque, "SQ_MOVIMENTACAO_PILHA_ARMAZEM", 0)
        objGrid_Coluna_Add(grdMovimentacaoEstoque, "CD_TIPO_SACARIA", 0)
        objGrid_Coluna_Add(grdMovimentacaoEstoque, "Fornecedor/Filial", 200)
        objGrid_Coluna_Add(grdMovimentacaoEstoque, "Dt. Movimentação", 120, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdMovimentacaoEstoque, "N.F.", 50)
        objGrid_Coluna_Add(grdMovimentacaoEstoque, "Tipo de Sacaria", 90)
        objGrid_Coluna_Add(grdMovimentacaoEstoque, "Volume", 80)
        objGrid_Coluna_Add(grdMovimentacaoEstoque, "Sacos em Estoque", 150)
        objGrid_Coluna_Add(grdMovimentacaoEstoque, "Sacos a Movimentar", 150)
        objGrid_Coluna_Add(grdMovimentacaoEstoque, "Tipo de Cacau", 110)

        objGrid_Inicializar(grdMovimentarPilhaDestino, , oDS_MovimentarPilhaDestino)
        objGrid_Coluna_Add(grdMovimentarPilhaDestino, "SQ_MOVIMENTACAO", 0)
        objGrid_Coluna_Add(grdMovimentarPilhaDestino, "SQ_MOVIMENTACAO_PILHA_ARMAZEM", 0)
        objGrid_Coluna_Add(grdMovimentarPilhaDestino, "CD_TIPO_SACARIA", 0)
        objGrid_Coluna_Add(grdMovimentarPilhaDestino, "Fornecedor/Filial", 200)
        objGrid_Coluna_Add(grdMovimentarPilhaDestino, "Dt. Movimentação", 120, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdMovimentarPilhaDestino, "N.F.", 50)
        objGrid_Coluna_Add(grdMovimentarPilhaDestino, "Tipo de Sacaria", 90)
        objGrid_Coluna_Add(grdMovimentarPilhaDestino, "Volume", 80)
        objGrid_Coluna_Add(grdMovimentarPilhaDestino, "Sacos a Movimentar", 150)

        Edicao_Habilitar(False)
    End Sub

    Private Sub CarregarMovimentacaoEstoque()
        Dim SqlText As String

        If ComboBox_LinhaSelecionada(cboArmazem) And ComboBox_LinhaSelecionada(cboPilha) Then
            'Carrega as movimentações da pilha de origem
            SqlText = "SELECT MSC.SQ_MOVIMENTACAO," & _
                             "MSC.SQ_MOVIMENTACAO_PILHA_ARMAZEM," & _
                             "TSC.CD_TIPO_SACARIA," & _
                             "NVL(FNC.NO_RAZAO_SOCIAL, FIL.NO_FILIAL) NO_FORNECEDOR_FILIAL," & _
                             "MOV.DT_MOVIMENTACAO," & _
                             "MOV.NU_NF," & _
                             "TSC.NO_TIPO_SACARIA," & _
                             "ROUND(ROUND(MOV.QT_KG_LIQUIDO_NF / FSC.QT_SACOS, 7) * MSC.QT_SACOS, 0) QT_VOLUME," & _
                             "MSC.QT_SACOS," & _
                             "0 QT_SACOS_MOVIMENTAR," & _
                             "MOV.CD_PROCEDENCIA" & _
                      " FROM SOF.MOV_PILHA_ARMAZEM_SACARIA MSC," & _
                            "SOF.MOVIMENTACAO_PILHA_ARMAZEM MVL," & _
                            "SOF.MOVIMENTACAO MOV," & _
                            "(SELECT SQ_MOVIMENTACAO," & _
                                    "SUM(QT_SACOS) QT_SACOS" & _
                             " FROM SOF.SACARIA_FILIAL" & _
                             " GROUP BY SQ_MOVIMENTACAO) FSC," & _
                            "SOF.TIPO_SACARIA TSC," & _
                            "SOF.FORNECEDOR FNC," & _
                            "SOF.TRANSFERENCIA TRF," & _
                            "SOF.FILIAL FIL" & _
                      " WHERE MSC.CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                        " AND MSC.CD_PILHA_ARMAZEM = " & cboPilha.SelectedValue & _
                        " AND MVL.CD_ARMAZEM = MSC.CD_ARMAZEM" & _
                        " AND MVL.CD_PILHA_ARMAZEM = MSC.CD_PILHA_ARMAZEM" & _
                        " AND MVL.SQ_MOVIMENTACAO = MSC.SQ_MOVIMENTACAO" & _
                        " AND MVL.SQ_MOVIMENTACAO_PILHA_ARMAZEM = MSC.SQ_MOVIMENTACAO_PILHA_ARMAZEM" & _
                        " AND MOV.SQ_MOVIMENTACAO = MVL.SQ_MOVIMENTACAO" & _
                        " AND FSC.SQ_MOVIMENTACAO (+) = MOV.SQ_MOVIMENTACAO" & _
                        " AND TSC.CD_TIPO_SACARIA = MSC.CD_TIPO_SACARIA" & _
                        " AND FNC.CD_FORNECEDOR (+) = MOV.CD_FORNECEDOR" & _
                        " AND TRF.SQ_MOVIMENTACAO_ENTRADA (+) = MOV.SQ_MOVIMENTACAO" & _
                        " AND FIL.CD_FILIAL (+) = TRF.CD_FILIAL_ORIGEM" & _
                      " ORDER BY MOV.DT_MOVIMENTACAO ASC," & _
                                "MSC.SQ_MOVIMENTACAO," & _
                                "NVL(FNC.NO_RAZAO_SOCIAL, FIL.NO_FILIAL)," & _
                                "MOV.NU_NF," & _
                                "TSC.NO_TIPO_SACARIA"
            objGrid_Carregar(grdMovimentacaoEstoque, SqlText, New Integer() {cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO, _
                                                                             cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO_PILHA_ARMAZEM, _
                                                                             cnt_GridMovimentacaoEstoque_CD_TIPO_SACARIA, _
                                                                             cnt_GridMovimentacaoEstoque_FornecedorFilial, _
                                                                             cnt_GridMovimentacaoEstoque_DtMovimentacao, _
                                                                             cnt_GridMovimentacaoEstoque_NF, _
                                                                             cnt_GridMovimentacaoEstoque_TipoSacaria, _
                                                                             cnt_GridMovimentacaoEstoque_Volume, _
                                                                             cnt_GridMovimentacaoEstoque_SacosEstoque, _
                                                                             cnt_GridMovimentacaoEstoque_SacosMovimentar, _
                                                                             cnt_GridMovimentacaoEstoque_Procedencia})

            lblVolume.Text = objGrid_CalcularTotalColuna(grdMovimentacaoEstoque, cnt_GridMovimentacaoEstoque_Volume)
            lblSacos.Text = objGrid_CalcularTotalColuna(grdMovimentacaoEstoque, cnt_GridMovimentacaoEstoque_SacosEstoque)
            lblSacosSaldo.Text = lblSacos.Text
            txtSacosMovimentar.MinValue = 1
            txtSacosMovimentar.MaxValue = Val(lblSacos.Text)
        Else
            oDS_MovimentacaoEstoque.Rows.Clear()
            oDS_MovimentarPilhaDestino.Rows.Clear()

            lblVolume.Text = ""
            lblSacos.Text = ""
            lblSacosSaldo.Text = ""
            txtSacosMovimentar.MinValue = 1
            txtSacosMovimentar.MaxValue = 1
        End If
    End Sub

    Private Sub cboPilhaDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPilhaDestino.SelectedIndexChanged
        If bProcInterno Then Exit Sub

        oDS_MovimentarPilhaDestino.Rows.Clear()
        CarregarMovimentacaoEstoque()

        If Not ComboPilhaDestino_ValidaProcedencia() Then Exit Sub

        Edicao_Habilitar(ComboBox_LinhaSelecionada(cboPilhaDestino))
    End Sub

    Private Function ComboPilhaDestino_ValidaProcedencia() As Boolean
        Dim SqlText As String
        Dim iCont As Integer
        Dim bOk As Boolean = True

        If ComboBox_LinhaSelecionada(cboPilhaDestino) Then
            SqlText = "SELECT COUNT(*) FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM" & _
                      " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                        " AND CD_PILHA_ARMAZEM = " & cboPilhaDestino.SelectedValue
            If DBQuery_ValorUnico(SqlText) = 0 Then
                CD_PROCEDENCIA_PILHA_DESTINO = ""
            Else
                SqlText = "SELECT CD_PROCEDENCIA" & _
                          " FROM SOF.PILHA_ARMAZEM" & _
                          " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                            " AND CD_PILHA_ARMAZEM = " & cboPilhaDestino.SelectedValue
                CD_PROCEDENCIA_PILHA_DESTINO = DBQuery_ValorUnico(SqlText, "")
            End If
        Else
            CD_PROCEDENCIA_PILHA_DESTINO = ""
        End If

        If Trim(CD_PROCEDENCIA_PILHA_DESTINO) <> "" Then
            For iCont = 0 To grdMovimentacaoEstoque.Rows.Count - 1
                If grdMovimentacaoEstoque.Rows(iCont).Cells(cnt_GridMovimentacaoEstoque_Procedencia).Value <> CD_PROCEDENCIA_PILHA_DESTINO Then
                    bProcInterno = True
                    cboPilhaDestino.SelectedIndex = -1
                    bProcInterno = False

                    bOk = False

                    Msg_Mensagem("Existe movimentação na pilha de origem com tipo de cacau diferente do tipo de cacau da pilha de destino")
                    Exit For
                End If
            Next
        End If

        Return bOk
    End Function

    Private Sub cmdMovimentarSacos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMovimentarSacos.Click
        If txtSacosMovimentar.Value < 1 Or txtSacosMovimentar.Value > Val(lblSacosSaldo.Text) Then
            Msg_Mensagem("Quantidade de sacos tem que ser maior que 1 ou menor ot igual o saldo disponível para movimentação. Saldo Disponível: " & lblSacosSaldo.Text)
            Exit Sub
        End If

        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim iLinhaMov As Integer
        Dim QtdeFalta As Integer
        Dim QtdeMovimentar As Integer

        QtdeFalta = txtSacosMovimentar.Value

        For iCont_01 = 0 To grdMovimentacaoEstoque.Rows.Count - 1
            iLinhaMov = -1

            With grdMovimentacaoEstoque.Rows(iCont_01)
                If .Cells(cnt_GridMovimentacaoEstoque_SacosEstoque).Value > .Cells(cnt_GridMovimentacaoEstoque_SacosMovimentar).Value Then
                    For iCont_02 = 0 To grdMovimentarPilhaDestino.Rows.Count - 1
                        If grdMovimentarPilhaDestino.Rows(iCont_02).Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value = .Cells(cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO).Value And _
                           grdMovimentarPilhaDestino.Rows(iCont_02).Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value = .Cells(cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value And _
                           grdMovimentarPilhaDestino.Rows(iCont_02).Cells(cnt_GridMovimentarPilhaDestino_CD_TIPO_SACARIA).Value = .Cells(cnt_GridMovimentacaoEstoque_CD_TIPO_SACARIA).Value Then
                            iLinhaMov = iCont_02
                            Exit For
                        End If
                    Next

                    If iLinhaMov = -1 Then
                        iLinhaMov = oDS_MovimentarPilhaDestino.Rows.Add().Index

                        grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value = .Cells(cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO).Value
                        grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value = .Cells(cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value
                        grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_CD_TIPO_SACARIA).Value = .Cells(cnt_GridMovimentacaoEstoque_CD_TIPO_SACARIA).Value
                        grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_DtMovimentacao).Value = .Cells(cnt_GridMovimentacaoEstoque_DtMovimentacao).Value
                        grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_FornecedorFilial).Value = .Cells(cnt_GridMovimentacaoEstoque_FornecedorFilial).Value
                        grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_NF).Value = .Cells(cnt_GridMovimentacaoEstoque_NF).Value
                        grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_TipoSacaria).Value = .Cells(cnt_GridMovimentacaoEstoque_TipoSacaria).Value
                    End If

                    If .Cells(cnt_GridMovimentacaoEstoque_SacosEstoque).Value - .Cells(cnt_GridMovimentacaoEstoque_SacosMovimentar).Value > QtdeFalta Then
                        QtdeMovimentar = QtdeFalta
                    Else
                        QtdeMovimentar = .Cells(cnt_GridMovimentacaoEstoque_SacosEstoque).Value - .Cells(cnt_GridMovimentacaoEstoque_SacosMovimentar).Value
                    End If

                    grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_Volume).Value = Math.Round(NVL(grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_Volume).Value, 0) + _
                                                                                                                                  ((.Cells(cnt_GridMovimentacaoEstoque_Volume).Value / .Cells(cnt_GridMovimentacaoEstoque_SacosEstoque).Value) * QtdeMovimentar), 0)
                    grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestinoSacosMovimentar).Value = NVL(grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestinoSacosMovimentar).Value, 0) + _
                                                                                                                                      QtdeMovimentar

                    .Cells(cnt_GridMovimentacaoEstoque_SacosMovimentar).Value = NVL(.Cells(cnt_GridMovimentacaoEstoque_SacosMovimentar).Value, 0) + QtdeMovimentar

                    QtdeFalta = QtdeFalta - QtdeMovimentar

                    If QtdeFalta = 0 Then
                        Exit For
                    End If
                End If
            End With
        Next

        CalcularSaldoSacos()

        txtSacosMovimentar.Value = Nothing
    End Sub

    Private Sub cmdDesce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDesce.Click
        If grdMovimentacaoEstoque.DisplayLayout.ActiveRow Is Nothing Then
            Msg_Mensagem("Selecione a linha de Movimentação em Estoque que queira movimentar")
            Exit Sub
        End If

        Dim iCont As Integer
        Dim iLinhaMov As Integer = -1
        Dim QtdeMovimentar As Double

        With grdMovimentacaoEstoque.DisplayLayout.ActiveRow
            If .Cells(cnt_GridMovimentacaoEstoque_SacosEstoque).Value - .Cells(cnt_GridMovimentacaoEstoque_SacosMovimentar).Value = 0 Then
                Msg_Mensagem("Não existe saldo para essa movimentação")
                Exit Sub
            End If

            For iCont = 0 To grdMovimentarPilhaDestino.Rows.Count - 1
                If .Cells(cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO).Value = grdMovimentarPilhaDestino.Rows(iCont).Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value And _
                   .Cells(cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value = grdMovimentarPilhaDestino.Rows(iCont).Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value And _
                   .Cells(cnt_GridMovimentacaoEstoque_CD_TIPO_SACARIA).Value = grdMovimentarPilhaDestino.Rows(iCont).Cells(cnt_GridMovimentarPilhaDestino_CD_TIPO_SACARIA).Value Then
                    iLinhaMov = iCont
                    Exit For
                End If
            Next

            If iLinhaMov = -1 Then
                iLinhaMov = oDS_MovimentarPilhaDestino.Rows.Add().Index

                grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value = .Cells(cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO).Value
                grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value = .Cells(cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value
                grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_CD_TIPO_SACARIA).Value = .Cells(cnt_GridMovimentacaoEstoque_CD_TIPO_SACARIA).Value
                grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_DtMovimentacao).Value = .Cells(cnt_GridMovimentacaoEstoque_DtMovimentacao).Value
                grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_FornecedorFilial).Value = .Cells(cnt_GridMovimentacaoEstoque_FornecedorFilial).Value
                grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_NF).Value = .Cells(cnt_GridMovimentacaoEstoque_NF).Value
                grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_TipoSacaria).Value = .Cells(cnt_GridMovimentacaoEstoque_TipoSacaria).Value
            End If

            QtdeMovimentar = .Cells(cnt_GridMovimentacaoEstoque_SacosEstoque).Value - .Cells(cnt_GridMovimentacaoEstoque_SacosMovimentar).Value
            .Cells(cnt_GridMovimentacaoEstoque_SacosMovimentar).Value = .Cells(cnt_GridMovimentacaoEstoque_SacosEstoque).Value

            grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_Volume).Value = NVL(grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestino_Volume).Value, 0) + _
                                                                                                                      ((.Cells(cnt_GridMovimentacaoEstoque_Volume).Value / .Cells(cnt_GridMovimentacaoEstoque_SacosEstoque).Value) * QtdeMovimentar)
            grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestinoSacosMovimentar).Value = NVL(grdMovimentarPilhaDestino.Rows(iLinhaMov).Cells(cnt_GridMovimentarPilhaDestinoSacosMovimentar).Value, 0) + _
                                                                                                                              QtdeMovimentar

            CalcularSaldoSacos()
        End With
    End Sub

    Private Sub CalcularSaldoSacos()
        lblSacosSaldo.Text = (objGrid_CalcularTotalColuna(grdMovimentacaoEstoque, cnt_GridMovimentacaoEstoque_SacosEstoque) - _
                              objGrid_CalcularTotalColuna(grdMovimentacaoEstoque, cnt_GridMovimentacaoEstoque_SacosMovimentar)).ToString
        txtSacosMovimentar.MaxValue = Val(lblSacosSaldo.Text)
    End Sub

    Private Sub cmdSobe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSobe.Click
        If grdMovimentarPilhaDestino.DisplayLayout.ActiveRow Is Nothing Then
            Msg_Mensagem("Selecione a linha de Movimentar para a Pilha de Destino que queira movimentar")
            Exit Sub
        End If

        Dim iCont As Integer
        Dim iLinhaGridMovimentar As Integer = -1

        With grdMovimentarPilhaDestino.DisplayLayout.ActiveRow
            For iCont = 0 To grdMovimentacaoEstoque.Rows.Count - 1
                If .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value = grdMovimentacaoEstoque.Rows(iCont).Cells(cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO).Value And _
                   .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value = grdMovimentacaoEstoque.Rows(iCont).Cells(cnt_GridMovimentacaoEstoque_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value And _
                   .Cells(cnt_GridMovimentarPilhaDestino_CD_TIPO_SACARIA).Value = grdMovimentacaoEstoque.Rows(iCont).Cells(cnt_GridMovimentacaoEstoque_CD_TIPO_SACARIA).Value Then
                    iLinhaGridMovimentar = iCont
                    Exit For
                End If
            Next

            grdMovimentacaoEstoque.Rows(iCont).Cells(cnt_GridMovimentacaoEstoque_SacosMovimentar).Value = grdMovimentacaoEstoque.Rows(iCont).Cells(cnt_GridMovimentacaoEstoque_SacosMovimentar).Value - _
                                                                                                          .Cells(cnt_GridMovimentarPilhaDestinoSacosMovimentar).Value
            .Delete(False)

            CalcularSaldoSacos()
        End With
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Close()
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        If Not ComboBox_LinhaSelecionada(cboArmazem) Or Not ComboBox_LinhaSelecionada(cboPilha) Then
            Msg_Mensagem("Selecione o armazém/pilha de origem")
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboPilhaDestino) Then
            Msg_Mensagem("Selecione a pilha destino")
            Exit Sub
        End If
        If grdMovimentarPilhaDestino.Rows.Count = 0 Then
            Msg_Mensagem("Selecione as movimentações a serem movimentadas")
            Exit Sub
        End If

        If Not ComboPilhaDestino_ValidaProcedencia() Then Exit Sub

        Dim SqlText As String
        Dim DS_MOTIVO As String = ""

        SqlText = "SELECT COUNT(*)" & _
                  " FROM SOF.ARMAZEM_PILHA_LASTRO" & _
                  " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                    " AND CD_PILHA IN (" & cboPilha.SelectedValue & "," & cboPilhaDestino.SelectedValue & ")" & _
                    " AND NVL(CD_STATUS_FORMACAO, 0) = " & cnt_StatusFormacaoPilha_Sendodesmanchada
        If DBQuery_ValorUnico(SqlText, 0) > 0 Then
            Msg_Mensagem("A pilha origem ou a pilha de destino está em processo de desmanche e por isso não poderá ser atualizada.")
            Exit Sub
        End If

        'Solicitação de Motivo para a movimentação - Início
        Dim oFormMovimentacaoCacau_ObsAcerto As frmMovimentacaoCacau_ObsAcerto

        oFormMovimentacaoCacau_ObsAcerto = New frmMovimentacaoCacau_ObsAcerto
        Form_Show(oMDI, oFormMovimentacaoCacau_ObsAcerto, True, True)

        DS_MOTIVO = oFormMovimentacaoCacau_ObsAcerto.DS_MOTIVO
        oFormMovimentacaoCacau_ObsAcerto.Dispose()
        oFormMovimentacaoCacau_ObsAcerto = Nothing

        If Trim(DS_MOTIVO) = "" Then
            Msg_Mensagem("É preciso que seja informado um motivo para essa movimentação")
            Exit Sub
        End If
        'Solicitação de Motivo para a movimentação - Fim

        Dim iCont_01 As Integer
        Dim SqMovPilhaArmazem As Integer
        Dim SqMovPilhaArmazemHist As Integer
        Dim QT_VOLUME As Double
        Dim QT_SACOS As Double
        Dim bSubPilha As Boolean

        SqlText = "SELECT COUNT(*) FROM " & View_ARMAZEM_PILHA_LASTRO() & _
                  " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                    " AND CD_PILHA = " & cboPilha.SelectedValue & _
                    " AND CD_PILHA_MAE IS NOT NULL"
        bSubPilha = (DBQuery_ValorUnico(SqlText, 0) > 0)

        DBUsarTransacao = True

        For iCont_01 = 0 To grdMovimentarPilhaDestino.Rows.Count - 1
            With grdMovimentarPilhaDestino.Rows(iCont_01)
                SqlText = "SELECT SUM(QT_SACOS) QT_SACOS" & _
                          " FROM SOF.MOV_PILHA_ARMAZEM_SACARIA" & _
                          " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                            " AND CD_PILHA_ARMAZEM = " & cboPilha.SelectedValue & _
                            " AND SQ_MOVIMENTACAO = " & .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value & _
                            " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value
                QT_SACOS = DBQuery_ValorUnico(SqlText)

                SqlText = "SELECT SUM(QT_VOLUME) " & _
                          " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM" & _
                          " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                            " AND CD_PILHA_ARMAZEM = " & cboPilha.SelectedValue & _
                            " AND SQ_MOVIMENTACAO = " & .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value & _
                            " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value
                QT_VOLUME = DBQuery_ValorUnico(SqlText)

                If QT_SACOS <> .Cells(cnt_GridMovimentarPilhaDestinoSacosMovimentar).Value Then
                    QT_VOLUME = Math.Round(QT_VOLUME / QT_SACOS * .Cells(cnt_GridMovimentarPilhaDestinoSacosMovimentar).Value, 0)
                End If

                'Lançamento de Histórico de Retirada da Movimentação - Início
                SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARM_HIST", False, ":CDARMAZEM", _
                                                                                 ":CDPILHAARMAZEM", _
                                                                                 ":SQMOVIMENTACAO", _
                                                                                 ":DTTRANSACAO", _
                                                                                 ":QTVOLUME", _
                                                                                 ":SQESTOQUESILO", _
                                                                                 ":ICSAIDA", _
                                                                                 ":SQTRANSF", _
                                                                                 ":SQITEMTRANSF", _
                                                                                 ":SQMOVPILHAARMAZEMHIST", _
                                                                                 ":CMLANCAMENTO")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", cboArmazem.SelectedValue), _
                                           DBParametro_Montar("CDPILHAARMAZEM", cboPilha.SelectedValue), _
                                           DBParametro_Montar("SQMOVIMENTACAO", .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value), _
                                           DBParametro_Montar("DTTRANSACAO", Date_to_Oracle(DataSistema)), _
                                           DBParametro_Montar("QTVOLUME", QT_VOLUME), _
                                           DBParametro_Montar("SQESTOQUESILO", Nothing), _
                                           DBParametro_Montar("ICSAIDA", "S"), _
                                           DBParametro_Montar("SQTRANSF", Nothing), _
                                           DBParametro_Montar("SQITEMTRANSF", Nothing), _
                                           DBParametro_Montar("SQMOVPILHAARMAZEMHIST", Nothing, , ParameterDirection.Output), _
                                           DBParametro_Montar("CMLANCAMENTO", DS_MOTIVO)) Then GoTo Erro

                If DBTeveRetorno() Then
                    SqMovPilhaArmazemHist = DBRetorno(1)
                End If

                SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARM_HI_SAC", False, ":CDARMAZEM", _
                                                                                   ":CDPILHAARMAZEM", _
                                                                                   ":SQMOVIMENTACAO", _
                                                                                   ":SQMOVPILHAARMAZEMHIST", _
                                                                                   ":CDTIPOSACARIA", _
                                                                                   ":QTSACOS", _
                                                                                   ":CMLANCAMENTO")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", cboArmazem.SelectedValue), _
                                           DBParametro_Montar("CDPILHAARMAZEM", cboPilha.SelectedValue), _
                                           DBParametro_Montar("SQMOVIMENTACAO", .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value), _
                                           DBParametro_Montar("SQMOVPILHAARMAZEMHIST", SqMovPilhaArmazemHist), _
                                           DBParametro_Montar("CDTIPOSACARIA", .Cells(cnt_GridMovimentarPilhaDestino_CD_TIPO_SACARIA).Value), _
                                           DBParametro_Montar("QTSACOS", .Cells(cnt_GridMovimentarPilhaDestinoSacosMovimentar).Value), _
                                           DBParametro_Montar("CMLANCAMENTO", DS_MOTIVO)) Then GoTo Erro
                'Lançamento de Histórico de Retirada da Movimentação - Fim

                'Lançamento de Baixa/Histórico de Entrada da Movimentação no Destino - Início
                SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARMAZEM", False, ":CDARMAZEM", _
                                                                                ":CDPILHAARMAZEM", _
                                                                                ":SQMOVIMENTACAO", _
                                                                                ":DTTRANSACAO", _
                                                                                ":QTVOLUME", _
                                                                                ":SQESTOQUESILO", _
                                                                                ":SQMOVPILHAARMAZEM", _
                                                                                ":SQMOVPILHAARMAZEMHIST")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", cboArmazem.SelectedValue), _
                                           DBParametro_Montar("CDPILHAARMAZEM", cboPilhaDestino.SelectedValue), _
                                           DBParametro_Montar("SQMOVIMENTACAO", .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value), _
                                           DBParametro_Montar("DTTRANSACAO", Date_to_Oracle(DataSistema)), _
                                           DBParametro_Montar("QTVOLUME", QT_VOLUME), _
                                           DBParametro_Montar("SQESTOQUESILO", Nothing), _
                                           DBParametro_Montar("SQMOVPILHAARMAZEM", Nothing, , ParameterDirection.Output), _
                                           DBParametro_Montar("SQMOVPILHAARMAZEMHIST", Nothing, , ParameterDirection.Output)) Then GoTo Erro

                If DBTeveRetorno() Then
                    SqMovPilhaArmazem = DBRetorno(1)
                    SqMovPilhaArmazemHist = DBRetorno(2)
                End If

                SqlText = DBMontar_SP("SOF.SP_INCLUI_MOV_PILHA_ARMA_SACA", False, ":CDARMAZEM", _
                                                                                  ":CDPILHAARMAZEM", _
                                                                                  ":SQMOVIMENTACAO", _
                                                                                  ":SQMOVPILHAARMAZEM", _
                                                                                  ":SQMOVPILHAARMAZEMHIST", _
                                                                                  ":CDTIPOSACARIA", _
                                                                                  ":QTSACOS")

                If Not DBExecutar(SqlText, DBParametro_Montar("CDARMAZEM", cboArmazem.SelectedValue), _
                                           DBParametro_Montar("CDPILHAARMAZEM", cboPilhaDestino.SelectedValue), _
                                           DBParametro_Montar("SQMOVIMENTACAO", .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value), _
                                           DBParametro_Montar("SQMOVPILHAARMAZEM", SqMovPilhaArmazem), _
                                           DBParametro_Montar("SQMOVPILHAARMAZEMHIST", SqMovPilhaArmazemHist), _
                                           DBParametro_Montar("CDTIPOSACARIA", .Cells(cnt_GridMovimentarPilhaDestino_CD_TIPO_SACARIA).Value), _
                                           DBParametro_Montar("QTSACOS", .Cells(cnt_GridMovimentarPilhaDestinoSacosMovimentar).Value)) Then GoTo Erro
                'Lançamento de Baixa/Histórico de Entrada da Movimentação no Destino - Fim

                'Lançamento de Baixa de Entrada da Movimentação - Início
                If QT_SACOS = .Cells(cnt_GridMovimentarPilhaDestinoSacosMovimentar).Value Then
                    SqlText = "DELETE FROM SOF.MOV_PILHA_ARMAZEM_SACARIA" & _
                              " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                                " AND CD_PILHA_ARMAZEM = " & cboPilha.SelectedValue & _
                                " AND SQ_MOVIMENTACAO = " & .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value & _
                                " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value
                    If Not DBExecutar(SqlText) Then GoTo Erro

                    SqlText = "DELETE FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM" & _
                              " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                                " AND CD_PILHA_ARMAZEM = " & cboPilha.SelectedValue & _
                                " AND SQ_MOVIMENTACAO = " & .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value & _
                                " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value
                    If Not DBExecutar(SqlText) Then GoTo Erro

                    SqlText = "UPDATE SOF.ARMAZEM_PILHA_LASTRO" & _
                              " SET CD_STATUS_FORMACAO = NULL" & _
                              " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                                " AND CD_PILHA = " & cboPilha.SelectedValue
                    If Not DBExecutar(SqlText) Then GoTo Erro
                Else
                    SqlText = "UPDATE SOF.MOVIMENTACAO_PILHA_ARMAZEM" & _
                              " SET QT_VOLUME = QT_VOLUME - " & QT_VOLUME & _
                              " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                                " AND CD_PILHA_ARMAZEM = " & cboPilha.SelectedValue & _
                                " AND SQ_MOVIMENTACAO = " & .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value & _
                                " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value
                    If Not DBExecutar(SqlText) Then GoTo Erro

                    SqlText = "UPDATE SOF.MOV_PILHA_ARMAZEM_SACARIA" & _
                              " SET QT_SACOS = QT_SACOS - " & .Cells(cnt_GridMovimentarPilhaDestinoSacosMovimentar).Value & _
                              " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                                " AND CD_PILHA_ARMAZEM = " & cboPilha.SelectedValue & _
                                " AND SQ_MOVIMENTACAO = " & .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO).Value & _
                                " AND SQ_MOVIMENTACAO_PILHA_ARMAZEM = " & .Cells(cnt_GridMovimentarPilhaDestino_SQ_MOVIMENTACAO_PILHA_ARMAZEM).Value
                    If Not DBExecutar(SqlText) Then GoTo Erro
                End If
                'Lançamento de Baixa de Entrada da Movimentação - Fim

                'Atualização do zeramento da pilha de origem - Início
                SqlText = DBMontar_SP("SOF.SP_ZERAMENTO_PILHA_UPD", False, ":CD_ARMAZEM", ":CD_PILHA")
                If Not DBExecutar(SqlText, DBParametro_Montar("CD_ARMAZEM", cboArmazem.SelectedValue), _
                                           DBParametro_Montar("CD_PILHA", cboPilha.SelectedValue)) Then GoTo Erro

                SqlText = DBMontar_SP("SOF.SP_ZERAMENTO_PILHA_UPD", False, ":CD_ARMAZEM", ":CD_PILHA")
                If Not DBExecutar(SqlText, DBParametro_Montar("CD_ARMAZEM", cboArmazem.SelectedValue), _
                                           DBParametro_Montar("CD_PILHA", cboPilhaDestino.SelectedValue)) Then GoTo Erro
                'Atualização do zeramento da pilha de destino - Fim

                If bSubPilha Then

                End If
            End With
        Next iCont_01

        If Not DBExecutarTransacao() Then GoTo Erro

        CarregarMovimentacaoEstoque()

        oDS_MovimentarPilhaDestino.Rows.Clear()

        Msg_Mensagem("Movimentação Efetuada")

        Exit Sub

Erro:
        TratarErro(, , "frmMovimentacaoCacau_MovimentarLote.cmdGravar_Click")
    End Sub

    Private Sub Edicao_Habilitar(ByVal bHabilitar As Boolean)
        grpPilhaDestino.Enabled = bHabilitar
        grpMovimentarSacos.Enabled = bHabilitar
        lblR_MovimentacaoEstoque.Enabled = bHabilitar
        grdMovimentacaoEstoque.Enabled = bHabilitar
        cmdDesce.Enabled = bHabilitar
        lblR_MovimentarPilhaDestino.Enabled = bHabilitar
        grdMovimentarPilhaDestino.Enabled = bHabilitar
        cmdSobe.Enabled = bHabilitar
    End Sub

    Private Sub cboPilha_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPilha.SelectedIndexChanged
        Dim SqlText As String

        If ComboBox_LinhaSelecionada(cboPilha) Then
            SqlText = "SELECT CD_PILHA, TO_CHAR(CD_PILHA_FILHA) CD_PILHA_FILHA" & _
                      " FROM " & View_ARMAZEM_PILHA_LASTRO() & _
                      " WHERE CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                        " AND CD_PILHA_FILHA <> " & cboPilha.SelectedValue & _
                        " AND NVL(CD_STATUS_PILHA, 0) NOT IN (" & cnt_StatusFormacaoPilha_Sendodesmanchada & ")" & _
                        " AND (CD_PILHA_MAE = " & CD_PILHA & " OR CD_PILHA_MAE IS NULL)" & _
                      " ORDER BY TO_NUMBER(CD_PILHA_FILHA)"
            DBCarregarComboBox(cboPilhaDestino, SqlText, True)
        Else
            cboPilhaDestino.DataSource = Nothing
        End If

        grpPilhaDestino.Enabled = ComboBox_LinhaSelecionada(cboPilha)

        txtSacosMovimentar.MinValue = 0
        txtSacosMovimentar.MaxValue = 0
        txtSacosMovimentar.Value = 0
    End Sub

    Private Sub cboArmazem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboArmazem.SelectedIndexChanged
        Dim SqlText As String

        If ComboBox_LinhaSelecionada(cboArmazem) Then
            SqlText = "SELECT DISTINCT CD_PILHA_ARMAZEM," & _
                                      "TO_CHAR(CD_PILHA_ARMAZEM) CD_PILHA_ARMAZEM" & _
                      " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM MPA," & _
                             View_ARMAZEM_PILHA_LASTRO() & " APL" & _
                      " WHERE MPA.CD_ARMAZEM = " & cboArmazem.SelectedValue & _
                        " AND APL.CD_ARMAZEM = MPA.CD_ARMAZEM" & _
                        " AND APL.CD_PILHA = MPA.CD_PILHA_ARMAZEM" & _
                      " ORDER BY MPA.CD_PILHA_ARMAZEM"
            DBCarregarComboBox(cboPilha, SqlText, True)
        Else
            cboPilha.DataSource = Nothing
        End If
    End Sub
End Class