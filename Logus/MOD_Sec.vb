Imports Infragistics.Win

Module MOD_Sec
    Public Enum SEC_Validador
        SEC_V_QualquerAcesso = -1
        SEC_V_Inclusao = 1
        SEC_V_Exclusao = 2
        SEC_V_Alteracao = 3
        SEC_V_Consulta = 4
    End Enum

    Public Enum SEC_Tipo_AreaAcesso
        SEC_TipoAreaAcesso_Menu = 1
        SEC_TipoAreaAcesso_Permissao = 2
        SEC_TipoAreaAcesso_Configuracao = 3
    End Enum

    Public SEC_SomenteConsulta As Boolean

    Public Sub SEC_CarregarAcessos(ByVal oGridAcesso As Infragistics.Win.UltraWinGrid.UltraGrid, _
                                   ByVal cnt_GridAcesso_NomeAcesso As Integer, _
                                   ByVal cnt_GridAcesso_Codigo As Integer, _
                                   Optional ByVal cnt_GridAcesso_IC_BRANCH_PLANT As Integer = -1)
        Dim oData As DataTable
        Dim oColuna As UltraWinGrid.UltraGridColumn
        Dim SqlText As String
        Dim iCont As Integer
        Dim iCont_2 As Integer
        Dim oCell As UltraWinGrid.UltraGridCell
        Dim sGrupoAcesso As String
        Dim oStyle As New UltraWinGrid.ColumnStyle
        Dim oDS As UltraWinDataSource.UltraDataSource
        Dim iIndice_ColunaAtivo As Integer

        oDS = oGridAcesso.DataSource
        sGrupoAcesso = ""

        oGridAcesso.DisplayLayout.Override.AllowColSizing = UltraWinGrid.AllowColSizing.Synchronized

        '>>> Carrega os acessos
        SqlText = "SELECT CD_AREAACESSO," & _
                         "NO_AREAACESSO," & _
                         "TP_GRUPO_ACESSO," & _
                         IIf(cnt_GridAcesso_IC_BRANCH_PLANT <> -1, "NVL(IC_BRANCH_PLANT, 'N') IC_BRANCH_PLANT", "NULL IC_BRANCH_PLANT") & _
                  " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO" & _
                  " WHERE TP_AREAACESSO = 'M'"

        If bBancoDados_CtrlAcesso_MultiSistema Then
            SqlText = SqlText & _
                      " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso
        End If

        SqlText = SqlText & _
                  " ORDER BY TP_GRUPO_ACESSO, NO_AREAACESSO"
        oData = DBQuery(SqlText)

        With oDS
            For iCont = 0 To oData.Rows.Count - 1
                If Trim(sGrupoAcesso) <> oData.Rows(iCont).Item("TP_GRUPO_ACESSO") Then
                    sGrupoAcesso = oData.Rows(iCont).Item("TP_GRUPO_ACESSO")

                    .Rows.Add()
                    .Rows(.Rows.Count - 1).Item(cnt_GridAcesso_Codigo) = -1
                    .Rows(.Rows.Count - 1).Item(cnt_GridAcesso_NomeAcesso) = UCase(SEC_GrupoMenu(sGrupoAcesso))
                End If

                .Rows.Add()

                '>> BRANCH PLANT
                If cnt_GridAcesso_IC_BRANCH_PLANT <> -1 Then
                    .Rows(.Rows.Count - 1).Item(cnt_GridAcesso_IC_BRANCH_PLANT) = oData.Rows(iCont).Item("IC_BRANCH_PLANT")
                    If NVL(oData.Rows(iCont).Item("IC_BRANCH_PLANT"), "N") = "S" Then
                        oGridAcesso.Rows(.Rows.Count - 1).CellAppearance.ForeColor = Color.Blue
                    End If
                End If
                '>> CÓDIGO DE ACESSO
                .Rows(.Rows.Count - 1).Item(cnt_GridAcesso_Codigo) = oData.Rows(iCont).Item("CD_AREAACESSO")
                '>> NOME DE ACESSO
                .Rows(.Rows.Count - 1).Item(cnt_GridAcesso_NomeAcesso) = oData.Rows(iCont).Item("NO_AREAACESSO")
            Next
        End With

        '>>> Carrega os tipos de acesso da telas
        SqlText = "SELECT CD_TIPOACESSO, NO_TIPOACESSO FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_TIPOACESSO" & _
                  " WHERE CD_TIPOACESSO = 4 " & _
                  " UNION ALL " & _
                  "SELECT CD_TIPOACESSO, NO_TIPOACESSO FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_TIPOACESSO" & _
                  " WHERE CD_TIPOACESSO = 1 " & _
                  " UNION ALL " & _
                  "SELECT CD_TIPOACESSO, NO_TIPOACESSO FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_TIPOACESSO" & _
                  " WHERE CD_TIPOACESSO = 3 " & _
                  " UNION ALL " & _
                  "SELECT CD_TIPOACESSO, NO_TIPOACESSO FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_TIPOACESSO" & _
                  " WHERE CD_TIPOACESSO = 2 " & _
                  " UNION ALL " & _
                  "SELECT CD_TIPOACESSO, NO_TIPOACESSO FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_TIPOACESSO" & _
                  " WHERE CD_TIPOACESSO = 5 " & _
                  " UNION ALL " & _
                  "SELECT CD_TIPOACESSO, NO_TIPOACESSO FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_TIPOACESSO" & _
                  " WHERE CD_TIPOACESSO NOT IN (1, 2, 3, 4, 5)"
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            For iCont = 0 To oData.Rows.Count - 1
                '>>> Código do Tipo de Acesso
                oColuna = oGridAcesso.DisplayLayout.Bands(0).Columns.Add
                oColuna.Tag = Trim(oData.Rows(iCont).Item("CD_TIPOACESSO"))
                oColuna.Hidden = True

                '>>> DESCRIÇÃO DO TIPO DE ACESSO - VISÍVEL
                oColuna = oGridAcesso.DisplayLayout.Bands(0).Columns.Add
                oColuna.Header.Caption = oData.Rows(iCont).Item("NO_TIPOACESSO")
                oColuna.Style = UltraWinGrid.ColumnStyle.Edit
                'oColuna.AutoCompleteMode = True

                If oData.Rows(iCont).Item("CD_TIPOACESSO") = 5 Then
                    iIndice_ColunaAtivo = oColuna.Index - 1
                    oColuna.Width = 50
                Else
                    oColuna.Width = 70
                End If

                '>>> DESCRIÇÃO DO TIPO DE ACESSO - CONTROLADO
                oColuna = oGridAcesso.DisplayLayout.Bands(0).Columns.Add
                oColuna.Header.Caption = oData.Rows(iCont).Item("NO_TIPOACESSO")
                oColuna.Hidden = True
            Next
        End If

        For iCont = 0 To oGridAcesso.Rows.Count - 1
            If oGridAcesso.Rows(iCont).Cells(cnt_GridAcesso_Codigo).Value = -1 Then
                With oGridAcesso.Rows(iCont)
                    .Cells(cnt_GridAcesso_NomeAcesso).Appearance.BackColor = Color.RoyalBlue
                    .Cells(cnt_GridAcesso_NomeAcesso).Appearance.FontData.Bold = DefaultableBoolean.True
                    .Cells(cnt_GridAcesso_NomeAcesso).Appearance.ForeColor = Color.White

                    For iCont_2 = cnt_GridAcesso_NomeAcesso + 1 To .Band.Columns.Count - 1
                        .Cells(iCont_2).Appearance.BackColor = Color.RoyalBlue
                    Next
                End With
            End If
        Next

        '>>> Habilitar os Tipo acesso ref. a cada acesso
        SqlText = "SELECT CD_AREAACESSO_TIPOACESSO," & _
                         "CD_AREAACESSO," & _
                         "CD_TIPOACESSO" & _
                  " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO_TIPOACESSO"

        If bBancoDados_CtrlAcesso_MultiSistema Then
            SqlText = SqlText & _
                      " WHERE CD_SISTEMA = " & cnt_Sistema_ControleAcesso
        End If

        SqlText = SqlText & _
                  " ORDER BY CD_AREAACESSO," & _
                            "CD_TIPOACESSO"
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            oGridAcesso.Rows.Item(0).Activate()
            oCell = Nothing

            For iCont_2 = 0 To oGridAcesso.Rows.Count - 1
                If oGridAcesso.Rows(iCont_2).Cells(cnt_GridAcesso_Codigo).Value = oData.Rows(iCont).Item("CD_AREAACESSO") Then
                    oCell = oGridAcesso.Rows(iCont_2).Cells(cnt_GridAcesso_Codigo)
                    Exit For
                End If
            Next

            If Not oCell Is Nothing Then
                For iCont_2 = cnt_GridAcesso_NomeAcesso + 1 To oGridAcesso.DisplayLayout.Bands(0).Columns.Count - 1 Step 3
                    If oData.Rows(iCont).Item("CD_TIPOACESSO") = _
                       Val(oGridAcesso.DisplayLayout.Bands(0).Columns(iCont_2).Tag) Then
                        oGridAcesso.Rows(oCell.Row.Index).Cells(iCont_2).Value = oData.Rows(iCont).Item("CD_AREAACESSO_TIPOACESSO")
                        oGridAcesso.Rows(oCell.Row.Index).Cells(iCont_2 + 1).Style = UltraWinGrid.ColumnStyle.CheckBox
                        oGridAcesso.Rows(oCell.Row.Index).Cells(iCont_2 + 1).Value = False
                    End If
                Next
            End If
        Next

        '>>> Monta o grid de permissão
        oDS.Rows.Add()

        With oGridAcesso.Rows(oGridAcesso.Rows.Count - 1)
            .Cells(cnt_GridAcesso_Codigo).Value = -2
            .Cells(cnt_GridAcesso_NomeAcesso).Value = "Permissão"
            .Cells(cnt_GridAcesso_NomeAcesso).Appearance.BackColor = Color.Green
            .Cells(cnt_GridAcesso_NomeAcesso).Appearance.FontData.Bold = DefaultableBoolean.True
            .Cells(cnt_GridAcesso_NomeAcesso).Appearance.ForeColor = Color.White
            .Cells(cnt_GridAcesso_Codigo).Value = -1

            For iCont_2 = cnt_GridAcesso_NomeAcesso + 1 To .Band.Columns.Count - 1
                .Cells(iCont_2).Appearance.BackColor = Color.Green
            Next
        End With

        'Carregar acesso
        SqlText = "SELECT TA.CD_AREAACESSO_TIPOACESSO," & _
                         "AA.CD_AREAACESSO," & _
                         "AA.NO_AREAACESSO," & _
                         IIf(cnt_GridAcesso_IC_BRANCH_PLANT <> -1, "NVL(AA.IC_BRANCH_PLANT, 'N') IC_BRANCH_PLANT", "NULL IC_BRANCH_PLANT") & _
                  " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO AA," & _
                             sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO_TIPOACESSO TA" & _
                  " WHERE AA.TP_AREAACESSO = 'P'"

        If bBancoDados_CtrlAcesso_MultiSistema Then
            SqlText = SqlText & _
                    " AND AA.CD_SISTEMA = " & cnt_Sistema_ControleAcesso
        End If

        SqlText = SqlText & _
                    " AND TA.CD_AREAACESSO = AA.CD_AREAACESSO" & _
                  " ORDER BY AA.NO_AREAACESSO"
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            oDS.Rows.Add()

            With oGridAcesso.Rows(oGridAcesso.Rows.Count - 1)
                If cnt_GridAcesso_IC_BRANCH_PLANT <> -1 Then
                    .Cells(cnt_GridAcesso_IC_BRANCH_PLANT).Value = oData.Rows(iCont).Item("IC_BRANCH_PLANT")
                    If NVL(oData.Rows(iCont).Item("IC_BRANCH_PLANT"), "N") = "S" Then
                        .CellAppearance.ForeColor = Color.Blue
                    End If
                End If

                .Cells(cnt_GridAcesso_Codigo).Value = oData.Rows(iCont).Item("CD_AREAACESSO")
                .Cells(cnt_GridAcesso_NomeAcesso).Value = oData.Rows(iCont).Item("NO_AREAACESSO")
                .Cells(iIndice_ColunaAtivo + 1).Style = UltraWinGrid.ColumnStyle.CheckBox
                .Cells(iIndice_ColunaAtivo + 1).Value = False
                .Cells(iIndice_ColunaAtivo).Value = oData.Rows(iCont).Item("CD_AREAACESSO_TIPOACESSO")
            End With
        Next

        '>>> Monta o grid de configuração
        oDS.Rows.Add()

        With oGridAcesso.Rows(oGridAcesso.Rows.Count - 1)
            .Cells(cnt_GridAcesso_Codigo).Value = -3
            .Cells(cnt_GridAcesso_NomeAcesso).Value = "Configuração"
            .Cells(cnt_GridAcesso_NomeAcesso).Appearance.BackColor = Color.Green
            .Cells(cnt_GridAcesso_NomeAcesso).Appearance.FontData.Bold = DefaultableBoolean.True
            .Cells(cnt_GridAcesso_NomeAcesso).Appearance.ForeColor = Color.White

            For iCont_2 = cnt_GridAcesso_NomeAcesso + 1 To .Band.Columns.Count - 1
                .Cells(iCont_2).Appearance.BackColor = Color.Green
            Next
        End With

        SqlText = "SELECT TA.CD_AREAACESSO_TIPOACESSO," & _
                         "AA.CD_AREAACESSO," & _
                         "AA.NO_AREAACESSO," & _
                         IIf(cnt_GridAcesso_IC_BRANCH_PLANT <> -1, "NVL(AA.IC_BRANCH_PLANT, 'N') IC_BRANCH_PLANT", "NULL IC_BRANCH_PLANT") & _
                  " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO AA," & _
                             sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO_TIPOACESSO TA" & _
                  " WHERE AA.TP_AREAACESSO = 'C'"

        If bBancoDados_CtrlAcesso_MultiSistema Then
            SqlText = SqlText & _
                    " AND AA.CD_SISTEMA = " & cnt_Sistema_ControleAcesso
        End If

        SqlText = SqlText & _
                    " AND TA.CD_AREAACESSO = AA.CD_AREAACESSO" & _
                  " ORDER BY AA.NO_AREAACESSO"
        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            oDS.Rows.Add()

            With oGridAcesso.Rows(oGridAcesso.Rows.Count - 1)
                If cnt_GridAcesso_IC_BRANCH_PLANT <> -1 Then
                    .Cells(cnt_GridAcesso_IC_BRANCH_PLANT).Value = oData.Rows(iCont).Item("IC_BRANCH_PLANT")
                    If NVL(oData.Rows(iCont).Item("IC_BRANCH_PLANT"), "N") = "S" Then
                        .CellAppearance.ForeColor = Color.Blue
                    End If
                End If

                .Cells(cnt_GridAcesso_Codigo).Value = oData.Rows(iCont).Item("CD_AREAACESSO")
                .Cells(cnt_GridAcesso_NomeAcesso).Value = oData.Rows(iCont).Item("NO_AREAACESSO")
                .Cells(iIndice_ColunaAtivo + 1).Style = UltraWinGrid.ColumnStyle.CheckBox
                .Cells(iIndice_ColunaAtivo + 1).Value = False
                .Cells(iIndice_ColunaAtivo).Value = oData.Rows(iCont).Item("CD_AREAACESSO_TIPOACESSO")
            End With
        Next

        oData.Dispose()
        oData = Nothing
    End Sub

    Public Sub SEC_CarregarDiretosAcesso(ByVal oGridAcesso As Infragistics.Win.UltraWinGrid.UltraGrid, _
                                         ByVal CD_GRUPO_ACESSO As Integer, _
                                         ByVal CD_USUARIO As String, _
                                         ByVal cnt_GridAcesso_Codigo As Integer, _
                                         ByVal cnt_GridAcesso_NomeAcesso As Integer, _
                                         Optional ByVal bLimparAcessoExistente As Boolean = True, _
                                         Optional ByVal CD_BRANCH_PLANT As Integer = -1)
        Dim oData As DataTable
        Dim SqlText As String
        Dim iCont_1 As Integer
        Dim iCont_2 As Integer
        Dim iRow As Integer
        Dim iIndice_ColunaAtivo As Integer
        Dim iAux As Integer

        If bLimparAcessoExistente Then
            SEC_LimparAcesso(oGridAcesso, cnt_GridAcesso_NomeAcesso)
        End If

        'Carrega os dados do acesso
        If CD_GRUPO_ACESSO > 0 Then
            SqlText = "SELECT GAA.CD_AREAACESSO_TIPOACESSO," & _
                             "ATA.CD_AREAACESSO," & _
                             "GAA.DT_EXPIRACAO" & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO_ACESSO GAA," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO_TIPOACESSO ATA" & _
                      " WHERE GAA.SQ_GRUPOACESSO = " & CD_GRUPO_ACESSO & _
                        " AND ATA.CD_AREAACESSO_TIPOACESSO = GAA.CD_AREAACESSO_TIPOACESSO"
        Else
            SqlText = "SELECT UAC.CD_AREAACESSO_TIPOACESSO," & _
                             "ATA.CD_AREAACESSO," & _
                             "UAC.DT_EXPIRACAO" & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_ACESSO UAC," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO_TIPOACESSO ATA" & _
                      " WHERE UAC.CD_USUARIO = " & QuotedStr(CD_USUARIO) & _
                        " AND ATA.CD_AREAACESSO_TIPOACESSO = UAC.CD_AREAACESSO_TIPOACESSO"

            If CD_BRANCH_PLANT > -1 Then
                SqlText = SqlText & " AND (UAC.CD_BRANCH_PLANT = " & CD_BRANCH_PLANT & " OR " & _
                                          "UAC.CD_BRANCH_PLANT IS NULL)"
            End If

            If bBancoDados_CtrlAcesso_MultiSistema Then
                SqlText = SqlText & " AND UAC.CD_SISTEMA = " & cnt_Sistema_ControleAcesso
            End If

            SqlText = SqlText & _
                      " ORDER BY ATA.CD_AREAACESSO"
        End If

        oData = DBQuery(SqlText)

        For iCont_1 = 0 To oData.Rows.Count - 1
            If iAux <> oData.Rows(iCont_1).Item("CD_AREAACESSO") Then
                iRow = -1

                For iCont_2 = 0 To oGridAcesso.Rows.Count - 1
                    If NVL(oGridAcesso.Rows(iCont_2).Cells(cnt_GridAcesso_Codigo).Value, -1) = oData.Rows(iCont_1).Item("CD_AREAACESSO") Then
                        iRow = iCont_2
                        Exit For
                    End If
                Next

                iAux = oData.Rows(iCont_1).Item("CD_AREAACESSO")
            End If

            If iRow > -1 Then
                For iCont_2 = cnt_GridAcesso_NomeAcesso + 1 To oGridAcesso.DisplayLayout.Bands(0).Columns.Count - 1 Step 3
                    If NVL(oGridAcesso.Rows(iRow).Cells(iCont_2).Value, -1) = oData.Rows(iCont_1).Item("CD_AREAACESSO_TIPOACESSO") Then
                        oGridAcesso.Rows(iRow).Cells(iCont_2 + 1).Value = True
                        oGridAcesso.Rows(iRow).Cells(iCont_2 + 2).Value = "S"

                        Exit For
                    End If
                Next
            End If
        Next

        For iCont_1 = 0 To oGridAcesso.DisplayLayout.Bands(0).Columns.Count - 1
            If oGridAcesso.DisplayLayout.Bands(0).Columns(iCont_1).Tag = 5 Then
                iIndice_ColunaAtivo = iCont_1 + 1
            End If
        Next

        'Carregar os dados das permissões
        If CD_GRUPO_ACESSO > 0 Then
            SqlText = "SELECT AA.CD_AREAACESSO, GA.CD_AREAACESSO_TIPOACESSO" & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO_ACESSO GA," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO_TIPOACESSO TA," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO AA" & _
                      " WHERE GA.SQ_GRUPOACESSO = " & CD_GRUPO_ACESSO & _
                        " AND TA.CD_AREAACESSO_TIPOACESSO = GA.CD_AREAACESSO_TIPOACESSO" & _
                        " AND AA.CD_AREAACESSO = TA.CD_AREAACESSO" & _
                        " AND AA.TP_AREAACESSO = 'P'"
        Else
            SqlText = "SELECT AA.CD_AREAACESSO, UA.CD_AREAACESSO_TIPOACESSO" & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_ACESSO UA," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO_TIPOACESSO TA," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO AA" & _
                      " WHERE UA.CD_USUARIO = " & QuotedStr(CD_USUARIO) & _
                        " AND TA.CD_AREAACESSO_TIPOACESSO = UA.CD_AREAACESSO_TIPOACESSO" & _
                        " AND AA.CD_AREAACESSO = TA.CD_AREAACESSO" & _
                        " AND AA.TP_AREAACESSO = 'P'"

            If CD_BRANCH_PLANT > -1 Then
                SqlText = SqlText & " AND UA.CD_BRANCH_PLANT = " & CD_BRANCH_PLANT
            End If
            If bBancoDados_CtrlAcesso_MultiSistema Then
                SqlText = SqlText & " AND UA.CD_SISTEMA = " & cnt_Sistema_ControleAcesso
            End If
        End If

        oData = DBQuery(SqlText)

        For iCont_1 = 0 To oData.Rows.Count - 1
            For iCont_2 = 0 To oGridAcesso.Rows.Count - 1
                If Val(NVL(oGridAcesso.Rows(iCont_2).Cells(cnt_GridAcesso_Codigo).Value, -1)) = _
                   oData.Rows(iCont_1).Item("CD_AREAACESSO") Then
                    oGridAcesso.Rows(iCont_2).Cells(iIndice_ColunaAtivo).Value = True
                    oGridAcesso.Rows(iRow).Cells(iIndice_ColunaAtivo + 1).Value = "S"
                    Exit For
                End If
            Next
        Next

        'Carregar os dados das configurações
        If CD_GRUPO_ACESSO > 0 Then
            SqlText = "SELECT AA.CD_AREAACESSO, GA.CD_AREAACESSO_TIPOACESSO" & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO_ACESSO GA," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO_TIPOACESSO TA," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO AA" & _
                      " WHERE GA.SQ_GRUPOACESSO = " & CD_GRUPO_ACESSO & _
                        " AND TA.CD_AREAACESSO_TIPOACESSO = GA.CD_AREAACESSO_TIPOACESSO" & _
                        " AND AA.CD_AREAACESSO = TA.CD_AREAACESSO" & _
                        " AND AA.TP_AREAACESSO = 'C'"
        Else
            SqlText = "SELECT AA.CD_AREAACESSO, UA.CD_AREAACESSO_TIPOACESSO" & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_ACESSO UA," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO_TIPOACESSO TA," & _
                                 sBancoDados_OwnerCtrlAcesso & ".SEC_AREAACESSO AA" & _
                      " WHERE UA.CD_USUARIO = " & QuotedStr(CD_USUARIO) & _
                        " AND TA.CD_AREAACESSO_TIPOACESSO = UA.CD_AREAACESSO_TIPOACESSO" & _
                        " AND AA.CD_AREAACESSO = TA.CD_AREAACESSO" & _
                        " AND AA.TP_AREAACESSO = 'C'"

            If CD_BRANCH_PLANT > -1 Then
                SqlText = SqlText & " AND UA.CD_BRANCH_PLANT = " & CD_BRANCH_PLANT
            End If
            If bBancoDados_CtrlAcesso_MultiSistema Then
                SqlText = SqlText & " AND UA.CD_SISTEMA = " & cnt_Sistema_ControleAcesso
            End If
        End If

        oData = DBQuery(SqlText)

        For iCont_1 = 0 To oData.Rows.Count - 1
            For iCont_2 = 0 To oGridAcesso.Rows.Count - 1
                If Val(NVL(oGridAcesso.Rows(iCont_2).Cells(cnt_GridAcesso_Codigo).Value, -1)) = _
                   oData.Rows(iCont_1).Item("CD_AREAACESSO") Then
                    oGridAcesso.Rows(iCont_2).Cells(iIndice_ColunaAtivo).Value = True
                    oGridAcesso.Rows(iRow).Cells(iIndice_ColunaAtivo + 1).Value = "S"
                    Exit For
                End If
            Next
        Next
    End Sub

    Public Sub SEC_LimparAcesso(ByVal oGridAcesso As Infragistics.Win.UltraWinGrid.UltraGrid, _
                                ByVal cnt_GridAcesso_NomeAcesso As Integer)
        Dim iLinha As Integer
        Dim iColuna As Integer

        For iLinha = 0 To oGridAcesso.Rows.Count - 1
            For iColuna = cnt_GridAcesso_NomeAcesso + 2 To oGridAcesso.DisplayLayout.Bands(0).Columns.Count - 1 Step 3
                If oGridAcesso.Rows(iLinha).Cells(iColuna).Style = UltraWinGrid.ColumnStyle.CheckBox Then
                    oGridAcesso.Rows(iLinha).Cells(iColuna).Value = False
                End If

                oGridAcesso.Rows(iLinha).Cells(iColuna + 1).Value = "N"
            Next
        Next
    End Sub

    Public Sub SEC_Gravar(ByVal oGridAcesso As Infragistics.Win.UltraWinGrid.UltraGrid, _
                          ByVal CD_GRUPO_ACESSO As Integer, _
                          ByVal CD_USUARIO As String, _
                          ByVal cnt_GridAcesso_Codigo As Integer, _
                          ByVal cnt_GridAcesso_NomeAcesso As Integer, _
                          Optional ByVal cnt_GridAcesso_IC_BRANCH_PLANT As Integer = -1, _
                          Optional ByVal CD_BRANCH_PLANT As Integer = -1)
        Dim iCont_1 As Integer
        Dim iCont_2 As Integer
        Dim SqlText As String
        Dim sAcesso As String
        Dim sTipoAcesso As String
        Dim sMens_EMail As String = String.Empty
        Dim sDescricao As String = ""
        Dim iIndice_ColunaAtivo As Integer
        Dim bGravarBranchPlant As Boolean
        Dim SqlText_Manter As String = ""

        For iCont_1 = 0 To oGridAcesso.DisplayLayout.Bands(0).Columns.Count - 1
            If oGridAcesso.DisplayLayout.Bands(0).Columns(iCont_1).Tag = 5 Then
                iIndice_ColunaAtivo = iCont_1 + 1
            End If
        Next

        DBUsarTransacao = True

        'If CD_GRUPO_ACESSO > 0 Then
        '    SqlText = "DELETE FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO_ACESSO" & _
        '              " WHERE SQ_GRUPOACESSO = " & CD_GRUPO_ACESSO
        '    DBExecutar(SqlText)
        'Else
        '    SqlText = "DELETE FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_ACESSO" & _
        '              " WHERE CD_USUARIO = " & QuotedStr(CD_USUARIO)

        '    If CD_BRANCH_PLANT > -1 Then
        '        SqlText = SqlText & " AND (CD_BRANCH_PLANT = " & CD_BRANCH_PLANT & " OR " & _
        '                                  "CD_BRANCH_PLANT IS NULL)"
        '    End If
        '    If bBancoDados_CtrlAcesso_MultiSistema Then
        '        SqlText = SqlText & " AND CD_SISTEMA = " & cnt_Sistema_ControleAcesso
        '    End If

        '    DBExecutar(SqlText)
        'End If

        'Grava os acesso
        For iCont_1 = 0 To oGridAcesso.Rows.Count - 1
            sAcesso = vbCrLf & oGridAcesso.Rows(iCont_1).Cells(1).Value
            sTipoAcesso = ""
            bGravarBranchPlant = False

            If cnt_GridAcesso_IC_BRANCH_PLANT <> -1 Then
                bGravarBranchPlant = (NVL(oGridAcesso.Rows(iCont_1).Cells(cnt_GridAcesso_IC_BRANCH_PLANT).Value, "N") = "S")
            End If

            For iCont_2 = cnt_GridAcesso_NomeAcesso + 2 To oGridAcesso.DisplayLayout.Bands(0).Columns.Count - 1 Step 3
                If objGrid_CheckBox_Selecionado(oGridAcesso, iCont_2, iCont_1) Then
                    If oGridAcesso.Rows(iCont_1).Cells(iCont_2 + 1).Value = "N" Then
                        sTipoAcesso = sTipoAcesso & vbCrLf & "    - Concedido tipo de acesso: "
                        sTipoAcesso = sTipoAcesso & oGridAcesso.DisplayLayout.Bands(0).Columns(iCont_2).Header.Caption
                    End If

                    If CD_GRUPO_ACESSO > 0 Then
                        Str_Adicionar(SqlText_Manter, oGridAcesso.Rows(iCont_1).Cells(iCont_2 - 1).Value, ",")

                        SqlText = "SELECT COUNT(*) FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO_ACESSO" & _
                                  " WHERE SQ_GRUPOACESSO = " & CD_GRUPO_ACESSO & _
                                    " AND CD_AREAACESSO_TIPOACESSO = " & oGridAcesso.Rows(iCont_1).Cells(iCont_2 - 1).Value

                        If DBQuery_ValorUnico(SqlText) = 0 Then
                            SqlText = DBMontar_Insert(sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO_ACESSO", TipoCampoFixo.Todos, _
                                                                                                               "SQ_GRUPOACESSO", ":SQ_GRUPOACESSO", _
                                                                                                               "CD_AREAACESSO_TIPOACESSO", ":CD_AREAACESSO_TIPOACESSO")

                            DBExecutar(SqlText, DBParametro_Montar("SQ_GRUPOACESSO", CD_GRUPO_ACESSO), _
                                                DBParametro_Montar("CD_AREAACESSO_TIPOACESSO", oGridAcesso.Rows(iCont_1).Cells(iCont_2 - 1).Value))
                        End If
                    Else
                        If CD_BRANCH_PLANT > -1 And bGravarBranchPlant Then
                            Str_Adicionar(SqlText_Manter, oGridAcesso.Rows(iCont_1).Cells(iCont_2 - 1).Value & "," & _
                                                          CD_BRANCH_PLANT & _
                                                          IIf(bBancoDados_CtrlAcesso_MultiSistema, "," & cnt_Sistema_ControleAcesso, ""), ",")
                        Else
                            Str_Adicionar(SqlText_Manter, oGridAcesso.Rows(iCont_1).Cells(iCont_2 - 1).Value & _
                                                          IIf(bBancoDados_CtrlAcesso_MultiSistema, "," & cnt_Sistema_ControleAcesso, ""), ",")
                        End If

                        If CD_BRANCH_PLANT > -1 And bGravarBranchPlant Then
                            SqlText = DBMontar_Insert(sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_ACESSO", _
                                                      TipoCampoFixo.Todos, _
                                                      IIf(bBancoDados_CtrlAcesso_MultiSistema, "CD_SISTEMA", ""), IIf(bBancoDados_CtrlAcesso_MultiSistema, cnt_Sistema_ControleAcesso, ""), _
                                                      "CD_USUARIO", ":CD_USUARIO", _
                                                      "CD_AREAACESSO_TIPOACESSO", ":CD_AREAACESSO_TIPOACESSO", _
                                                      "CD_BRANCH_PLANT", CD_BRANCH_PLANT)
                        Else
                            SqlText = DBMontar_Insert(sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_ACESSO", _
                                                      TipoCampoFixo.Todos, _
                                                      IIf(bBancoDados_CtrlAcesso_MultiSistema, "CD_SISTEMA", ""), IIf(bBancoDados_CtrlAcesso_MultiSistema, cnt_Sistema_ControleAcesso, ""), _
                                                      "CD_USUARIO", ":CD_USUARIO", _
                                                      "CD_AREAACESSO_TIPOACESSO", ":CD_AREAACESSO_TIPOACESSO")
                        End If

                        DBExecutar(SqlText, DBParametro_Montar("CD_USUARIO", CD_USUARIO), _
                                            DBParametro_Montar("CD_AREAACESSO_TIPOACESSO", oGridAcesso.Rows(iCont_1).Cells(iCont_2 - 1).Value))
                    End If
                Else
                    If oGridAcesso.Rows(iCont_1).Cells(iCont_2 + 1).Value = "S" Then
                        sTipoAcesso = sTipoAcesso & vbCrLf & "    - Removido tipo de acesso: "
                        sTipoAcesso = sTipoAcesso & oGridAcesso.DisplayLayout.Bands(0).Columns(iCont_2).Header.Caption
                    End If
                End If
            Next

            If Trim(sTipoAcesso) <> "" Then
                sMens_EMail = sMens_EMail & " " & sAcesso & _
                                                  sTipoAcesso & vbCrLf
            End If
        Next

        If Trim(SqlText_Manter) <> "" Then
            If CD_GRUPO_ACESSO > 0 Then
                SqlText = "DELETE FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO_ACESSO" & _
                          " WHERE SQ_GRUPOACESSO = " & CD_GRUPO_ACESSO & _
                            " AND (CD_AREAACESSO_TIPOACESSO) NOT IN (" & SqlText_Manter & ")"
            Else
                SqlText = "DELETE FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_ACESSO" & _
                          " WHERE CD_ = " & CD_USUARIO & _
                            " AND (CD_AREAACESSO_TIPOACESSO " & IIf(CD_BRANCH_PLANT > -1 And bGravarBranchPlant, ",CD_BRANCH_PLANT", "") & _
                                                                IIf(bBancoDados_CtrlAcesso_MultiSistema, ",CD_SISTEMA", "") & ") NOT IN (" & SqlText_Manter & ")"
            End If

            DBExecutar(SqlText)
        End If

        'Grava as permissões
        sAcesso = ""

        'For iCont_1 = 0 To oGridAcesso.Rows.Count - 1
        '    If cnt_GridAcesso_IC_BRANCH_PLANT <> -1 Then
        '        bGravarBranchPlant = (NVL(oGridAcesso.Rows(iCont_1).Cells(cnt_GridAcesso_IC_BRANCH_PLANT).Value, "N") = "S")
        '    End If

        '    If oGridAcesso.Rows(iCont_1).Cells(cnt_GridAcesso_Codigo).Value = -2 Then
        '        If objGrid_CheckBox_Selecionado(oGridAcesso, iIndice_ColunaAtivo, iCont_1) Then
        '            If CD_GRUPO_ACESSO > 0 Then
        '                If CD_BRANCH_PLANT > -1 And bGravarBranchPlant Then
        '                    SqlText = DBMontar_Insert(sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO_ACESSO", _
        '                                              TipoCampoFixo.Todos, _
        '                                              "SQ_GRUPOACESSO", ":SQ_GRUPOACESSO", _
        '                                              "CD_AREAACESSO_TIPOACESSO", ":CD_AREAACESSO_TIPOACESSO", _
        '                                              "CD_BRANCH_PLANT", CD_BRANCH_PLANT)
        '                Else
        '                    SqlText = DBMontar_Insert(sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO_ACESSO", _
        '                                              TipoCampoFixo.Todos, _
        '                                              "SQ_GRUPOACESSO", ":SQ_GRUPOACESSO", _
        '                                              "CD_AREAACESSO_TIPOACESSO", ":CD_AREAACESSO_TIPOACESSO")
        '                End If

        '                DBExecutar(SqlText, DBParametro_Montar("SQ_GRUPOACESSO", CD_GRUPO_ACESSO), _
        '                                    DBParametro_Montar("CD_AREAACESSO_TIPOACESSO", oGridAcesso.Rows(iCont_1).Cells(iIndice_ColunaAtivo + 1).Value))
        '            Else
        '                If CD_BRANCH_PLANT > -1 And bGravarBranchPlant Then
        '                    SqlText = DBMontar_Insert(sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_ACESSO", _
        '                                              TipoCampoFixo.Todos, _
        '                                              IIf(bBancoDados_CtrlAcesso_MultiSistema, "CD_SISTEMA", ""), IIf(bBancoDados_CtrlAcesso_MultiSistema, cnt_Sistema_ControleAcesso, ""), _
        '                                              "CD_USUARIO", ":CD_USUARIO", _
        '                                              "CD_AREAACESSO_TIPOACESSO", ":CD_AREAACESSO_TIPOACESSO", _
        '                                              "CD_BRANCH_PLANT", CD_BRANCH_PLANT)
        '                Else
        '                    SqlText = DBMontar_Insert(sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_ACESSO", _
        '                                              TipoCampoFixo.Todos, _
        '                                              IIf(bBancoDados_CtrlAcesso_MultiSistema, "CD_SISTEMA", ""), IIf(bBancoDados_CtrlAcesso_MultiSistema, cnt_Sistema_ControleAcesso, ""), _
        '                                              "CD_USUARIO", ":CD_USUARIO", _
        '                                              "CD_AREAACESSO_TIPOACESSO", ":CD_AREAACESSO_TIPOACESSO")
        '                End If

        '                DBExecutar(SqlText, DBParametro_Montar("CD_USUARIO", CD_USUARIO), _
        '                                    DBParametro_Montar("CD_AREAACESSO_TIPOACESSO", oGridAcesso.Rows(iCont_1).Cells(cnt_GridAcesso_Codigo).Value))
        '            End If

        '            If oGridAcesso.Rows(iCont_1).Cells(iIndice_ColunaAtivo + 1).Value = "N" Then
        '                sAcesso = sAcesso & "    Concedido permissão a " & oGridAcesso.Rows(iCont_1).Cells(cnt_GridAcesso_NomeAcesso).Value & vbCrLf
        '            End If
        '        Else
        '            If oGridAcesso.Rows(iCont_1).Cells(iIndice_ColunaAtivo + 1).Value = "S" Then
        '                sAcesso = sAcesso & "    Retirado permissão a " & oGridAcesso.Rows(iCont_1).Cells(cnt_GridAcesso_NomeAcesso).Value & vbCrLf
        '            End If
        '        End If
        '    End If
        'Next

        'If Trim(sAcesso) <> "" Then
        '    sMens_EMail = sMens_EMail & vbCrLf & vbCrLf & _
        '                                "Alteração de Permissão" & vbCrLf & _
        '                                sAcesso
        'End If

        ''Grava as configuracões
        'sAcesso = ""

        'For iCont_1 = 0 To oGridAcesso.Rows.Count - 1
        '    If cnt_GridAcesso_IC_BRANCH_PLANT <> -1 Then
        '        bGravarBranchPlant = (NVL(oGridAcesso.Rows(iCont_1).Cells(cnt_GridAcesso_IC_BRANCH_PLANT).Value, "N") = "S")
        '    End If

        '    If oGridAcesso.Rows(iCont_1).Cells(cnt_GridAcesso_Codigo).Value = -3 Then
        '        If objGrid_CheckBox_Selecionado(oGridAcesso, iIndice_ColunaAtivo, iCont_1) Then
        '            If CD_GRUPO_ACESSO > 0 Then
        '                If CD_BRANCH_PLANT > -1 And bGravarBranchPlant Then
        '                    SqlText = DBMontar_Insert(sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO_ACESSO", _
        '                                              TipoCampoFixo.Todos, _
        '                                              "SQ_GRUPOACESSO", ":SQ_GRUPOACESSO", _
        '                                              "CD_AREAACESSO_TIPOACESSO", ":CD_AREAACESSO_TIPOACESSO", _
        '                                              "CD_BRANCH_PLANT", CD_BRANCH_PLANT)
        '                Else
        '                    SqlText = DBMontar_Insert(sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO_ACESSO", _
        '                                              TipoCampoFixo.Todos, _
        '                                              "SQ_GRUPOACESSO", ":SQ_GRUPOACESSO", _
        '                                              "CD_AREAACESSO_TIPOACESSO", ":CD_AREAACESSO_TIPOACESSO")
        '                End If

        '                DBExecutar(SqlText, DBParametro_Montar("SQ_GRUPOACESSO", CD_GRUPO_ACESSO), _
        '                                    DBParametro_Montar("CD_AREAACESSO_TIPOACESSO", oGridAcesso.Rows(iCont_1).Cells(cnt_GridAcesso_Codigo).Value))
        '            Else
        '                If CD_BRANCH_PLANT > -1 And bGravarBranchPlant Then
        '                    SqlText = DBMontar_Insert(sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_ACESSO", _
        '                                              TipoCampoFixo.Todos, _
        '                                              IIf(bBancoDados_CtrlAcesso_MultiSistema, "CD_SISTEMA", ""), IIf(bBancoDados_CtrlAcesso_MultiSistema, cnt_Sistema_ControleAcesso, ""), _
        '                                              "CD_USUARIO", ":CD_USUARIO", _
        '                                              "CD_AREAACESSO_TIPOACESSO", ":CD_AREAACESSO_TIPOACESSO", _
        '                                              "CD_BRANCH_PLANT", CD_BRANCH_PLANT)
        '                Else
        '                    SqlText = DBMontar_Insert(sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO_ACESSO", _
        '                                              TipoCampoFixo.Todos, _
        '                                              IIf(bBancoDados_CtrlAcesso_MultiSistema, "CD_SISTEMA", ""), IIf(bBancoDados_CtrlAcesso_MultiSistema, cnt_Sistema_ControleAcesso, ""), _
        '                                              "CD_USUARIO", ":CD_USUARIO", _
        '                                              "CD_AREAACESSO_TIPOACESSO", ":CD_AREAACESSO_TIPOACESSO")
        '                End If

        '                DBExecutar(SqlText, DBParametro_Montar("CD_USUARIO", CD_USUARIO), _
        '                                    DBParametro_Montar("CD_AREAACESSO_TIPOACESSO", oGridAcesso.Rows(iCont_1).Cells(cnt_GridAcesso_Codigo).Value))
        '            End If

        '            If oGridAcesso.Rows(iCont_1).Cells(iIndice_ColunaAtivo + 1).Value = "N" Then
        '                sAcesso = sAcesso & "    Concedido permissão a " & oGridAcesso.Rows(iCont_1).Cells(cnt_GridAcesso_NomeAcesso).Value & vbCrLf
        '            End If
        '        Else
        '            If oGridAcesso.Rows(iCont_1).Cells(iIndice_ColunaAtivo + 1).Value = "S" Then
        '                sAcesso = sAcesso & "    Retirado permissão a " & oGridAcesso.Rows(iCont_1).Cells(cnt_GridAcesso_NomeAcesso).Value & vbCrLf
        '            End If
        '        End If
        '    End If
        'Next

        If Trim(sAcesso) <> "" Then
            sMens_EMail = sMens_EMail & vbCrLf & vbCrLf & _
                                        "Alteração de Configuração" & vbCrLf & _
                                        sAcesso
        End If

        DBExecutarTransacao()

        'If CD_GRUPO_ACESSO > 0 Then
        '    SqlText = "SELECT NO_GRUPOACESSO FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_GRUPOACESSO" & _
        '              " WHERE SQ_GRUPOACESSO = " & CD_GRUPO_ACESSO

        '    If CD_BRANCH_PLANT > -1 Then
        '        SqlText = SqlText & " AND CD_BRANCH_PLANT = " & CD_BRANCH_PLANT
        '    End If

        '    sDescricao = DBQuery_ValorUnico(SqlText)
        'Else
        '    SqlText = "SELECT NO_USUARIO FROM " & sBancoDados_OwnerCtrlAcesso & ".SEC_USUARIO" & _
        '              " WHERE CD_USUARIO = " & QuotedStr(CD_USUARIO)
        '    sDescricao = DBQuery_ValorUnico(SqlText)
        'End If

        ''>>> Envio de E-Mail com alterações nos acessos
        'SqlText = "SELECT DS_EMAIL_FISCAL FROM SRP.PARAMETRO_FISCAL"
        'sEMail = DBQuery_ValorUnico(SqlText, "")

        'SqlText = "SELECT DS_EMAIL FROM SRP.USUARIO WHERE CD_USER = '" & sAcesso_UsuarioLogado & "'"
        'sEMail = Trim(sEMail & ";" & DBQuery_ValorUnico(SqlText, ""))

        'If Left(sEMail, 1) = ";" Then sEMail = Mid(sEMail, 2)

        ''>>> Envio de E-Mail com alterações nos acessos
        'If Trim(sEMail) <> "" And Trim(sMens_EMail) <> "" Then
        '    sMens_EMail = "          Sistema de Controle de Amêndoas          " & vbCrLf & vbCrLf & _
        '                  "Foi realizado alteração no cadastro de Acesso por " & IIf(CD_GRUPO_ACESSO > 0, _
        '                                                                             "Grupo de Acesso", _
        '                                                                             "Usuário") & ". " & _
        '                  "Informações sobre a alteração estão descritas abaixo." & vbCrLf & vbCrLf & _
        '                  IIf(CD_GRUPO_ACESSO > 0, "Grupo de Acesso Alterado: " & sDescricao, _
        '                                           "Usuário Alterado: " & sDescricao) & vbCrLf & _
        '                  "Data da Alteração: " & Now.ToString & vbCrLf & _
        '                  "Usuário que realizou a alteração: " & sAcesso_UsuarioLogado & " - " & sAcesso_NomeUsuarioLogado & _
        '                                                         vbCrLf & vbCrLf & _
        '                  "Alterações realizadas" & vbCrLf & _
        '                  sMens_EMail

        '    spuGerarEmail("Sistema Cargill - Controle de Acesso", _
        '                  sEMail, _
        '                  "Sistema Cargill - Controle de Acesso - Alteração de Acesso por " & IIf(ViewState("TIPO") = "GRUPO", _
        '                                                                                                              "Grupo de Acesso", _
        '                                                                                                              "Usuário"), _
        '                  sMens_EMail, _
        '                  System.Web.Mail.MailFormat.Text, _
        '                  cnt_EMail_Servidor_SMTP, _
        '                  System.Web.Mail.MailPriority.Normal)
        'End If

        Exit Sub

Erro:
        TratarErro(, , "MOD_Sec.SEC_Gravar")
    End Sub

    Public Function SEC_GrupoMenu(ByVal Codigo As String, _
                                  Optional ByVal CampoDECODE As String = "", _
                                  Optional ByRef oCombo As System.Windows.Forms.ComboBox = Nothing) As String
        Dim oGrupoMenu As New Collection
        Dim sAux As String = ""
        Dim iCont As Integer

        oGrupoMenu.Add("ADM|Administração", "ADM")
        oGrupoMenu.Add("CAD|Cadastro", "CAD")
        oGrupoMenu.Add("CNT|Consulta", "CNT")
        oGrupoMenu.Add("CST|Consulta", "CST")
        oGrupoMenu.Add("GFC|Gráfico", "GFC")
        oGrupoMenu.Add("IFC|Interface", "IFC")
        oGrupoMenu.Add("INF|Informação", "INF")
        oGrupoMenu.Add("LVO|Livro de Ocorrência", "LVO")
        oGrupoMenu.Add("LVP|Livro de Produção", "LVP")
        oGrupoMenu.Add("MOD|Módulo", "MOD")
        oGrupoMenu.Add("PRD|Parada", "PRD")
        oGrupoMenu.Add("PTC|Ponto de Controle", "PTC")
        oGrupoMenu.Add("REL|Relatório", "REL")
        oGrupoMenu.Add("SEC|Segurança", "SEC")
        oGrupoMenu.Add("TSC|Transação", "TSC")

        If Not oCombo Is Nothing Then
            Dim oRow As DataRow
            Dim oDataCombo As New DataTable

            oDataCombo.Columns.Add(0)
            oDataCombo.Columns.Add(1)

            oRow = oDataCombo.NewRow
            oRow(0) = "-"
            oRow(1) = ""
            oDataCombo.Rows.Add(oRow)

            For iCont = 1 To oGrupoMenu.Count
                oRow = oDataCombo.NewRow
                oRow(0) = Mid(oGrupoMenu.Item(iCont), 1, InStr(oGrupoMenu.Item(iCont), "|") - 1)
                oRow(1) = Mid(oGrupoMenu.Item(iCont), InStr(oGrupoMenu.Item(iCont), "|") + 1)
                oDataCombo.Rows.Add(oRow)
            Next

            If Not oDataCombo Is Nothing Then
                oCombo.ValueMember = oDataCombo.Columns(0).ColumnName
                oCombo.DisplayMember = oDataCombo.Columns(1).ColumnName
                oCombo.DataSource = oDataCombo
                oCombo.Refresh()
            End If
        ElseIf Trim(CampoDECODE) <> "" Then
            For iCont = 1 To oGrupoMenu.Count
                If Trim(sAux) <> "" Then sAux = sAux & ","
                sAux = sAux & QuotedStr(Mid(oGrupoMenu.Item(iCont), 1, InStr(oGrupoMenu.Item(iCont), "|") - 1)) & "," _
                            & QuotedStr(Mid(oGrupoMenu.Item(iCont), InStr(oGrupoMenu.Item(iCont), "|") + 1))
            Next

            Return "DECODE(" & CampoDECODE & ", " & sAux & ") TP_GRUPO_ACESSO"
        Else
            If oGrupoMenu.Contains(Codigo) Then
                Return Mid(oGrupoMenu.Item(Codigo), InStr(oGrupoMenu.Item(Codigo), "|") + 1)
            Else
                Return ""
            End If
        End If
        Return ""
    End Function

    Public Function SEC_ValidarAcessoInterno(ByVal sTela As String, _
                                             ByVal Validador As SEC_Validador, _
                                             Optional ByVal POR_BRANCH_PLANT As Boolean = False) As Boolean
        Dim SqlText As String
        Dim bPermite As Boolean

        If cnt_Sistema_ControleAcesso = 4 Then
            POR_BRANCH_PLANT = True
        End If

        If (SEC_SomenteConsulta And Validador = SEC_Validador.SEC_V_Consulta) Or _
           Not SEC_SomenteConsulta Then
            SqlText = "SELECT COUNT(*)" & _
                          " FROM (" & SEC_SqlText_Acesso(sAcesso_UsuarioLogado, _
                                                         SEC_Tipo_AreaAcesso.SEC_TipoAreaAcesso_Menu, _
                                                         POR_BRANCH_PLANT) & " )" & _
                          " WHERE UPPER(NO_AREAACESSO_INTERNO) = " & QuotedStr(UCase(sTela))

            If Validador <> SEC_Validador.SEC_V_QualquerAcesso Then
                SqlText = SqlText & _
                        " AND CD_TIPOACESSO = " & Validador
            End If

            bPermite = (DBQuery_ValorUnico(SqlText, 0) > 0)
        Else
            bPermite = False
        End If

        Return bPermite
    End Function

    Public Function SEC_SqlText_Acesso(ByVal sUsuario As String, _
                                       ByVal iTipo_AreaAcesso As SEC_Tipo_AreaAcesso, _
                                       Optional ByVal POR_BRANCH_PLANT As Boolean = False) As String
        Dim SqlText As String

        sUsuario = UCase(sUsuario)

        If POR_BRANCH_PLANT Then
            SqlText = "SELECT UAG.NO_AREAACESSO_INTERNO," & _
                             "NVL(UAG.CD_TIPOACESSO, 0) CD_TIPOACESSO," & _
                             "UAG.CD_BRANCH_PLANT" & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".VW_SEC_USUARIOACESSO_GERAL UAG," & _
                                 sBancoDados_OwnerCtrlAcesso & ".BRANCH_PLANT_USUARIO BPU" & _
                      " WHERE UAG.CD_USUARIO = " & QuotedStr(sUsuario) & _
                        " AND UAG.CD_SISTEMA = " & cnt_Sistema_ControleAcesso & _
                        " AND UAG.TP_AREAACESSO = " & IIf(iTipo_AreaAcesso = SEC_Tipo_AreaAcesso.SEC_TipoAreaAcesso_Menu, "'M'", _
                                                      IIf(iTipo_AreaAcesso = SEC_Tipo_AreaAcesso.SEC_TipoAreaAcesso_Permissao, "'P'", "'C'")) & _
                        " AND UAG.DT_EXPIRACAO > SYSDATE" & _
                        " AND (BPU.CD_BRANCH_PLANT = UAG.CD_BRANCH_PLANT OR UAG.CD_BRANCH_PLANT IS NULL)" & _
                        " AND BPU.CD_USUARIO = " & QuotedStr(sUsuario)
        Else
            SqlText = "SELECT UAG.NO_AREAACESSO_INTERNO," & _
                             "NVL(UAG.CD_TIPOACESSO, 0) CD_TIPOACESSO" & _
                      " FROM " & sBancoDados_OwnerCtrlAcesso & ".VW_SEC_USUARIOACESSO_GERAL UAG" & _
                      " WHERE UAG.CD_USUARIO = " & QuotedStr(sUsuario) & _
                        " AND UAG.CD_SISTEMA = " & cnt_Sistema_ControleAcesso & _
                        " AND UAG.TP_AREAACESSO = " & IIf(iTipo_AreaAcesso = SEC_Tipo_AreaAcesso.SEC_TipoAreaAcesso_Menu, "'M'", _
                                                      IIf(iTipo_AreaAcesso = SEC_Tipo_AreaAcesso.SEC_TipoAreaAcesso_Permissao, "'P'", "'C'")) & _
                        " AND UAG.DT_EXPIRACAO > SYSDATE"
        End If

        If SEC_SomenteConsulta Then
            SqlText = SqlText & _
                    " AND UAG.CD_TIPOACESSO = " & SEC_Validador.SEC_V_Consulta
        End If

        Return SqlText
    End Function

    Public Sub SEC_ValidarBotao(ByVal oBotao As Infragistics.Win.Misc.UltraButton, _
                                ByVal sTela As String, _
                                ByVal Validador As SEC_Validador, _
                                Optional ByVal bValidarVisibilidade As Boolean = False)
        Dim bOk As Boolean

        If SEC_SomenteConsulta And Validador = SEC_Validador.SEC_V_QualquerAcesso Then
            Validador = SEC_Validador.SEC_V_Consulta
        End If

        If (SEC_SomenteConsulta And Validador = SEC_Validador.SEC_V_Consulta) Or _
           Not SEC_SomenteConsulta Then
            bOk = SEC_ValidarAcessoInterno(sTela, Validador, (cnt_Sistema_ControleAcesso = 4))
        Else
            bOk = False
        End If

        If bValidarVisibilidade Then
            oBotao.Visible = bOk
        Else
            oBotao.Enabled = bOk
        End If
    End Sub

    Public Sub SEC_ValidarBotao_Permissao(ByVal oBotao As Infragistics.Win.Misc.UltraButton, _
                                          ByVal Permissao As SEC_Permissao, _
                                          Optional ByVal bValidarVisibilidade As Boolean = False)
        Dim bOk As Boolean

        bOk = SEC_ValidarAcessoPermisao(Permissao)

        If bValidarVisibilidade Then
            oBotao.Visible = bOk
        Else
            oBotao.Enabled = bOk
        End If
    End Sub

    Public Function SEC_ValidarConfiguracao(ByVal Configuracao As SEC_Configuracao) As Boolean
        Dim sConfiguracao As String
        Dim SqlText As String
        Dim bPermite As Boolean

        If SEC_SomenteConsulta Then
            Return False
        Else
            Select Case Configuracao
                Case SEC_Configuracao.SEC_Config_LancaAnalisesLaboratorio
                    sConfiguracao = "LancaAnalisesLaboratorio"
                Case SEC_Configuracao.SEC_Config_CriarTransferenciaAtenderBlend
                    sConfiguracao = "CriarTransferenciaAtenderBlend"
                Case Else
                    sConfiguracao = ""
            End Select

            SqlText = "SELECT COUNT(*)" & _
                      " FROM (" & SEC_SqlText_Acesso(sAcesso_UsuarioLogado, SEC_Tipo_AreaAcesso.SEC_TipoAreaAcesso_Configuracao) & " )" & _
                      " WHERE UPPER(NO_AREAACESSO_INTERNO) = " & QuotedStr(UCase(sConfiguracao))

            bPermite = (DBQuery_ValorUnico(SqlText) > 0)

            Return bPermite
        End If
    End Function

    Public Function SEC_ValidarOffLine(ByVal sUsuario As String, ByVal sSenha As String) As Boolean
        Dim oDBControlX As New DBControlX.DBControlX
        Dim bOk As Boolean

        bOk = False

        If oDBControlX.GS_SenhaUsuarioSistema(cnt_DBControl_Sistema, _
                                              sAcesso_UsuarioLogado, sSenha, _
                                              cnt_DBControl_Chave, cnt_DBControl_Bit) Then
            bOk = True
        Else
            Msg_Mensagem("Não foi possivel validar seu usuário de forma off-line.")
        End If

        oDBControlX.Dispose()
        oDBControlX = Nothing

        Return bOk
    End Function
End Module
