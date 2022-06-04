Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmAprovacaoCreditoConsulta
    Const cnt_GridGeral_Filial As Integer = 0
    Const cnt_GridGeral_Fornecedor As Integer = 1
    Const cnt_GridGeral_Valor As Integer = 2
    Const cnt_GridGeral_Descricao As Integer = 3
    Const cnt_GridGeral_Solicitante As Integer = 4
    Const cnt_GridGeral_Validade As Integer = 5
    Const cnt_GridGeral_TipoGarantia As Integer = 6
    Const cnt_GridGeral_ValorGarantia As Integer = 7
    Const cnt_GridGeral_ValidadeGarantia As Integer = 8
    Const cnt_GridGeral_Codigo As Integer = 9

    Const cnt_GridAprovacao_Codigo As Integer = 0
    Const cnt_GridAprovacao_Status As Integer = 1
    Const cnt_GridAprovacao_Tipo As Integer = 2
    Const cnt_GridAprovacao_Usuario As Integer = 3
    Const cnt_GridAprovacao_PossuiLimite As Integer = 4
    Const cnt_GridAprovacao_ValorMinimo As Integer = 5
    Const cnt_GridAprovacao_ValorMaximo As Integer = 6
    Const cnt_GridAprovacao_Validade As Integer = 7
    Const cnt_GridAprovacao_Aprova As Integer = 8
    Const cnt_GridAprovacao_CodigoTipo As Integer = 9

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim oDSAprovacao As New UltraWinDataSource.UltraDataSource

    Private Sub frmAprovacaoCreditoConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.CellSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdGeral, "Filial", 120)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 180)
        objGrid_Coluna_Add(grdGeral, "Valor", 80, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Descrição", 200, , , , , , DefaultableBoolean.True)
        objGrid_Coluna_Add(grdGeral, "Solicitante", 120)
        objGrid_Coluna_Add(grdGeral, "Validade", 80, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "Tipo Garantia", 150)
        objGrid_Coluna_Add(grdGeral, "Valor Garantia", 100)
        objGrid_Coluna_Add(grdGeral, "Validade Garantia", 100)
        objGrid_Coluna_Add(grdGeral, "Codigo", 0)

        objGrid_Inicializar(grdAprovacao, , oDSAprovacao, UltraWinGrid.CellClickAction.CellSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdAprovacao, "Código", 0)
        objGrid_Coluna_Add(grdAprovacao, "Status", 160, , True, , , True)
        objGrid_Coluna_Add(grdAprovacao, "Tipo Aprovação", 120)
        objGrid_Coluna_Add(grdAprovacao, "Usuário", 100)
        objGrid_Coluna_Add(grdAprovacao, "Possui Limite", 0)
        objGrid_Coluna_Add(grdAprovacao, "Valor Minimo", 0, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdAprovacao, "Valor Maximo", 0, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdAprovacao, "Validade", 0)
        objGrid_Coluna_Add(grdAprovacao, "Aprova", 0)
        objGrid_Coluna_Add(grdAprovacao, "Código Tipo", 0)

        ExecutaConsulta()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String
        Dim oData As DataTable
        Dim oDataAux As DataTable
        Dim iCont As Integer
        Dim iCont2 As Integer
        Dim icAdiciona As Boolean = False

        SqlText = "SELECT lc.sq_limite_credito, lc.cd_fornecedor, g.cd_tipo_garantia, "
        SqlText = SqlText & "       lc.dt_limite_credito, "
        SqlText = SqlText & "       lc.vl_credito , "
        SqlText = SqlText & "       lc.ds_obs, DECODE (lc.ic_excecao,'S', 'Exceção',"
        SqlText = SqlText & "       DECODE (lc.ic_pre_aprovado,'S', 'Limite Pre-Aprovado',tg.no_tipo_garantia)) AS no_tipo_garantia, f.no_razao_social, trunc(lc.dt_validade) dt_validade, "
        SqlText = SqlText & "       fil.no_filial, "
        SqlText = SqlText & "       u.no_usuario, "
        SqlText = SqlText & "       lc.dt_revisao, lc.cd_tipo_status, decode (g.ic_moeda_garantia,1,'R$ ',2,'US$ ',3, 'QT @ ','') || g.vl_garantia as vl_garantia, "
        SqlText = SqlText & "       g.dt_garantia_validade, "
        SqlText = SqlText & "       ps.no_status AS tipo,lc.ic_moeda_credito "
        SqlText = SqlText & "  FROM sof.fornecedor f, "
        SqlText = SqlText & "       sof.tipo_garantia tg, "
        SqlText = SqlText & "       sof.limite_credito lc, "
        SqlText = SqlText & "       sof.filial fil, "
        SqlText = SqlText & "       (select distinct cd_user, NO_usuario from sof.usuario) u, "
        SqlText = SqlText & "       sof.garantia g, sof.processo_status ps "
        SqlText = SqlText & " WHERE lc.cd_fornecedor = f.cd_fornecedor "
        SqlText = SqlText & "   AND g.cd_tipo_garantia = tg.cd_tipo_garantia (+) "
        SqlText = SqlText & "   AND f.cd_filial_origem = fil.cd_filial "
        SqlText = SqlText & "   AND lc.no_user_criacao = u.cd_user(+) "
        SqlText = SqlText & "   and lc.sq_garantia =g.sq_garantia (+) "
        SqlText = SqlText & "   AND lc.cd_tipo_status IN ('P', 'W') "
        SqlText = SqlText & "   and ps.ic_status = lc.ic_moeda_credito "
        SqlText = SqlText & "   and ps.cd_processo = " & enProcesso_Status.Moeda

        If Not SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_IncluirSolicitacaoCreditoFornecedorOutraFilial) Then
            SqlText = SqlText & " AND F.CD_FILIAL_ORIGEM in (" & ListarIDFiliaisLiberadaUsuario() & ")"
        End If

        oData = DBQuery(SqlText)
        oDS = grdGeral.DataSource
        oDS.Rows.Clear()

        If Not objDataTable_Vazio(oData) Then
            For iCont = 0 To oData.Rows.Count - 1

                SqlText = "SELECT DISTINCT UTA.VL_MINIMO_APROVACAO, UTA.VL_MAXIMO_APROVACAO, " & _
                          "TA.IC_POSSUI_LIMITE, UTA.cd_tipo_aprovacao, decode(uta.dt_validade,null,sysdate,uta.dt_validade) as dt_validade " & _
                          "FROM SOF.USUARIO_TIPO_APROVACAO UTA, SOF.TIPO_APROVACAO TA " & _
                          "WHERE UTA.CD_TIPO_APROVACAO = TA.CD_TIPO_APROVACAO AND " & _
                          "UTA.CD_USER = '" & sAcesso_UsuarioLogado & "' AND " & _
                          "UTA.cd_tipo_aprovacao NOT IN (SELECT CD_TIPO_APROVACAO " & _
                          "From SOF.LIMITE_CREDITO_APROVACAO " & _
                          "WHERE CD_USER = '" & sAcesso_UsuarioLogado & "' AND " & _
                          "SQ_LIMITE_CREDITO = " & oData.Rows(iCont).Item("sq_limite_credito") & ")"

                oDataAux = DBQuery(SqlText)
                icAdiciona = False
                If Not objDataTable_Vazio(oDataAux) Then
                    For iCont2 = 0 To oDataAux.Rows.Count - 1

                        If oDataAux.Rows(iCont2).Item("ic_possui_limite") = "S" Then
                            If oDataAux.Rows(iCont2).Item("vl_minimo_aprovacao") <= oData.Rows(iCont).Item("vl_credito") And _
                                oDataAux.Rows(iCont2).Item("vl_maximo_aprovacao") >= oData.Rows(iCont).Item("vl_credito") And _
                                oDataAux.Rows(iCont2).Item("dt_validade") >= Now.Date Then
                                icAdiciona = True
                                Exit For
                            End If
                        Else
                            icAdiciona = True
                            Exit For
                        End If
                    Next
                End If

                If icAdiciona = True Then
                    With oDS
                        .Rows.Add()

                        .Rows(.Rows.Count - 1).Item(cnt_GridGeral_Filial) = oData.Rows(iCont).Item("no_filial")
                        .Rows(.Rows.Count - 1).Item(cnt_GridGeral_Fornecedor) = oData.Rows(iCont).Item("no_razao_social")
                        .Rows(.Rows.Count - 1).Item(cnt_GridGeral_Valor) = oData.Rows(iCont).Item("vl_credito")
                        .Rows(.Rows.Count - 1).Item(cnt_GridGeral_Solicitante) = oData.Rows(iCont).Item("no_usuario")
                        .Rows(.Rows.Count - 1).Item(cnt_GridGeral_Validade) = oData.Rows(iCont).Item("dt_validade")
                        .Rows(.Rows.Count - 1).Item(cnt_GridGeral_TipoGarantia) = oData.Rows(iCont).Item("no_tipo_garantia")
                        .Rows(.Rows.Count - 1).Item(cnt_GridGeral_ValorGarantia) = oData.Rows(iCont).Item("vl_garantia")
                        .Rows(.Rows.Count - 1).Item(cnt_GridGeral_ValidadeGarantia) = oData.Rows(iCont).Item("dt_garantia_validade")
                        .Rows(.Rows.Count - 1).Item(cnt_GridGeral_Descricao) = oData.Rows(iCont).Item("ds_obs")
                        .Rows(.Rows.Count - 1).Item(cnt_GridGeral_Codigo) = oData.Rows(iCont).Item("sq_limite_credito")
                    End With
                End If
            Next
        End If

        For iCont = 0 To grdGeral.Rows.Count - 1
            grdGeral.Rows(iCont).PerformAutoSize()
        Next
    End Sub

    Private Sub grdGeral_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGeral.AfterRowActivate
        CarregarAprovacao()
    End Sub

    Private Sub CarregarAprovacao()
        Dim SqlText As String
        Dim iCont As Integer

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Exit Sub
        End If

        oDSAprovacao.Rows.Clear()

        SqlText = "SELECT T.CD_TIPO_APROVACAO," & _
                         "NULL APROVADO," & _
                         "T.NO_TIPO_APROVACAO," & _
                         "U.NO_USUARIO," & _
                         "T.IC_POSSUI_LIMITE," & _
                         "UA.VL_MINIMO_APROVACAO," & _
                         "UA.VL_MAXIMO_APROVACAO," & _
                         "UA.DT_VALIDADE," & _
                         "DECODE(UA.CD_TIPO_APROVACAO, NULL, 'N', 'S') AS APROVA," & _
                         "T.CD_TIPO_APROVACAO" & _
                  " FROM SOF.TIPO_APROVACAO T," & _
                        "SOF.LIMITE_CREDITO_APROVACAO L," & _
                        "SOF.USUARIO U," & _
                        "(SELECT DISTINCT UTA.CD_TIPO_APROVACAO," & _
                                         "UTA.VL_MINIMO_APROVACAO," & _
                                         "UTA.VL_MAXIMO_APROVACAO," & _
                                         "NVL(UTA.DT_VALIDADE, SYSDATE) AS DT_VALIDADE" & _
                         " FROM SOF.USUARIO_TIPO_APROVACAO UTA" & _
                         " WHERE UTA.CD_USER = " & QuotedStr(sAcesso_UsuarioLogado) & _
                           " AND UTA.CD_TIPO_APROVACAO NOT IN (SELECT CD_TIPO_APROVACAO" & _
                                                              " FROM SOF.LIMITE_CREDITO_APROVACAO" & _
                                                              " WHERE CD_USER = " & QuotedStr(sAcesso_UsuarioLogado) & _
                                                                " AND SQ_LIMITE_CREDITO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo) & ")) UA" & _
                  " WHERE L.CD_TIPO_APROVACAO (+) = T.CD_TIPO_APROVACAO" & _
                    " AND U.CD_USER (+) = L.CD_USER" & _
                    " AND L.SQ_LIMITE_CREDITO (+) = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo) & _
                    " AND UA.CD_TIPO_APROVACAO(+) = T.CD_TIPO_APROVACAO"
        objGrid_Carregar(grdAprovacao, SqlText, New Integer() {cnt_GridAprovacao_Codigo, _
                                                               cnt_GridAprovacao_Status, _
                                                               cnt_GridAprovacao_Tipo, _
                                                               cnt_GridAprovacao_Usuario, _
                                                               cnt_GridAprovacao_PossuiLimite, _
                                                               cnt_GridAprovacao_ValorMinimo, _
                                                               cnt_GridAprovacao_ValorMaximo, _
                                                               cnt_GridAprovacao_Validade, _
                                                               cnt_GridAprovacao_Aprova, _
                                                               cnt_GridAprovacao_CodigoTipo}, False)

        objGrid_Coluna_AddOption(grdAprovacao, oDSAprovacao, _
                                 cnt_GridAprovacao_Status, New Object() {"Aprovado", True, _
                                                                         "Reprovado", False})

        For iCont = 0 To grdAprovacao.Rows.Count - 1
            If Not objGrid_Valor_SN(grdAprovacao, cnt_GridAprovacao_Aprova, iCont) Or Not CampoNulo(grdAprovacao.Rows(iCont).Cells(cnt_GridAprovacao_Usuario).Value) Then
                grdAprovacao.Rows(iCont).Appearance.BackColor = Color.LightGray
                grdAprovacao.Rows(iCont).Cells(cnt_GridAprovacao_Status).Hidden = True
            Else
                If grdAprovacao.Rows(iCont).Cells(cnt_GridAprovacao_PossuiLimite).Value = "S" Then
                    If Not (grdAprovacao.Rows(iCont).Cells(cnt_GridAprovacao_ValorMinimo).Value <= objGrid_Valor(grdGeral, cnt_GridGeral_Valor) And _
                       grdAprovacao.Rows(iCont).Cells(cnt_GridAprovacao_ValorMaximo).Value >= objGrid_Valor(grdGeral, cnt_GridGeral_Valor) And _
                       grdAprovacao.Rows(iCont).Cells(cnt_GridAprovacao_Validade).Value >= Now.Date) Then
                        grdAprovacao.Rows(iCont).Appearance.BackColor = Color.LightGray
                        grdAprovacao.Rows(iCont).Cells(cnt_GridAprovacao_Status).Hidden = True
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub grdAprovacao_AfterPerformAction(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs) Handles grdAprovacao.AfterPerformAction
        Me.Text = Now.ToString
    End Sub

    Private Sub frmAprovacaoCreditoConsulta_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 228
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 6
        UltraGroupBox5.Width = Me.ClientSize.Width - UltraGroupBox5.Left - 6

        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 6
        ' grdAprovacao.Left = Me.ClientSize.Width - grdAprovacao.Width - 415
        'Posição vertical
        cmdGravar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        grdAprovacao.Top = Me.ClientSize.Height - grdAprovacao.Height - 53
        UltraGroupBox5.Top = Me.ClientSize.Height - UltraGroupBox5.Height - 51
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim iCont As Integer
        Dim sStatusAprovacao As String
        Dim Parametro(3) As DBParamentro
        Dim SQ_SOLICITACAO_CREDITO As Integer

        DBUsarTransacao = True

        AVI_Carregar(Me)

        For iCont = 0 To grdAprovacao.Rows.Count - 1
            'TODAS AS APROVAÇÕES NÃO PODEM SER FEITAS PELO MESMO USUARIO
            SqlText = "SELECT COUNT(*)-SUM(DECODE(L.DT_APROVACAO , NULL,0,1)) AS APROVACAO"
            SqlText = SqlText & "    FROM SOF.LIMITE_CREDITO_APROVACAO L,SOF.TIPO_APROVACAO TA"
            SqlText = SqlText & "   WHERE CD_USER (+)= " & QuotedStr(sAcesso_UsuarioLogado)
            SqlText = SqlText & "   AND L.SQ_LIMITE_CREDITO (+)= " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
            SqlText = SqlText & "   AND TA.CD_TIPO_APROVACAO =L.CD_TIPO_APROVACAO (+)"

            If DBQuery_ValorUnico(SqlText) = 1 Then
                Msg_Mensagem("Pelo menos uma das aprovações deve ser feita por um usuario diferente.")
                SQ_SOLICITACAO_CREDITO = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
                GoTo Erro
            End If

            If Not CampoNulo(grdAprovacao.Rows(iCont).Cells(cnt_GridAprovacao_Status).Value) Then
                If grdAprovacao.Rows(iCont).Cells(cnt_GridAprovacao_Status).Value Then
                    sStatusAprovacao = "A"
                Else
                    sStatusAprovacao = "R"
                End If

                SqlText = DBMontar_SP("SOF.SP_INCLUI_APROVACAO_CREDITO", False, ":SQLIMITE", ":TPAPROV", ":STAPROV", ":DSOBS")

                Parametro(0) = DBParametro_Montar("SQLIMITE", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
                Parametro(1) = DBParametro_Montar("TPAPROV", grdAprovacao.Rows(iCont).Cells(cnt_GridAprovacao_CodigoTipo).Value)
                Parametro(2) = DBParametro_Montar("STAPROV", sStatusAprovacao)

                If rctDescricao.Text = "" Then
                    Parametro(3) = DBParametro_Montar("DSOBS", Nothing, OracleClient.OracleType.VarChar, , 4000)
                Else
                    Parametro(3) = DBParametro_Montar("DSOBS", rctDescricao.Text, OracleClient.OracleType.VarChar, , 4000)
                End If

                If Not DBExecutar(SqlText, Parametro) Then GoTo Erro
            End If
        Next

        If Not DBExecutarTransacao() Then GoTo Erro

        ExecutaConsulta()

        AVI_Fechar(Me)

        Msg_Mensagem("Gravação efetuada")

        Exit Sub

Erro:
        TratarErro()

        SelecioneSolicitacaoCredito(SQ_SOLICITACAO_CREDITO)
        CarregarAprovacao()
        AVI_Fechar(Me)
    End Sub

    Private Sub grdAprovacao_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdAprovacao.CellChange
        If e.Cell.Column.Index <> cnt_GridAprovacao_Status Then Exit Sub

        GridAprovacaoCorLinhaStatus(e.Cell)
    End Sub

    Private Sub GridAprovacaoCorLinhaStatus(ByVal oCell As Infragistics.Win.UltraWinGrid.UltraGridCell)
        With grdAprovacao.Rows(oCell.Row.Index)
            If oCell.Column.Index <> cnt_GridAprovacao_Status Then Exit Sub

            Select Case .Cells(cnt_GridAprovacao_Status).Text
                Case ""
                    .Appearance.ForeColor = Color.Black
                    .Appearance.FontData.Bold = DefaultableBoolean.False
                Case "Aprovado"
                    .Appearance.ForeColor = Color.Green
                    .Appearance.FontData.Bold = DefaultableBoolean.True
                Case "Reprovado"
                    .Appearance.ForeColor = Color.Red
                    .Appearance.FontData.Bold = DefaultableBoolean.True
            End Select
        End With
    End Sub

    Private Sub grdAprovacao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdAprovacao.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Not grdAprovacao.ActiveCell Is Nothing Then
                If grdAprovacao.ActiveCell.Column.Index = cnt_GridAprovacao_Status Then
                    grdAprovacao.ActiveCell.Value = DBNull.Value
                    GridAprovacaoCorLinhaStatus(grdAprovacao.ActiveCell)
                    grdAprovacao.PerformAction(UltraGridAction.ExitEditMode)
                End If
            End If
        End If
    End Sub

    Private Sub SelecioneSolicitacaoCredito(ByVal SQ_SOLICITACAO_CREDITO As Integer)
        Dim iCont As Integer

        For iCont = 0 To grdGeral.Rows.Count - 1
            If objGrid_Valor(grdGeral, cnt_GridGeral_Codigo, iCont) = SQ_SOLICITACAO_CREDITO Then
                grdGeral.Rows(iCont).Activate()
            End If
        Next
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        ExecutaConsulta()
    End Sub
End Class