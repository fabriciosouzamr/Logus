Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Public Class frmParametroBolsa

    Const cnt_GridGeral_Sequencia As Integer = 0
    Const cnt_GridGeral_Papel As Integer = 1
    Const cnt_GridGeral_Descricao As Integer = 2
    Const cnt_GridGeral_LimiteCredito As Integer = 3
    Const cnt_GridGeral_Diferencial As Integer = 4
    Const cnt_GridGeral_Status As Integer = 5
    Const cnt_GridGeral_CotacaoAlternativa As Integer = 6
    Const cnt_GridGeral_Moeda As Integer = 7
    Const cnt_GridGeral_Visivel As Integer = 8
    Dim oDS As New UltraWinDataSource.UltraDataSource

    Const cnt_SEC_Tela As String = "Transacao_Bolsa_Parametro"

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmParametroBolsa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Bolsa_Papel_Moeda(cboPapel, True)

        objGrid_Inicializar(grdGeral, AllowAddNew.FixedAddRowOnTop, oDS, UltraWinGrid.CellClickAction.EditAndSelectText, , DefaultableBoolean.True)

        objGrid_Coluna_Add(grdGeral, "Sequência", 60)
        objGrid_Coluna_Add(grdGeral, "Papel", 70)
        objGrid_Coluna_Add(grdGeral, "Descrição", 150)
        objGrid_Coluna_Add(grdGeral, "Limite Contrato", 100, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "Diferêncial", 100, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Status", 210, , True, , , True)
        objGrid_Coluna_Add(grdGeral, "Cotação Alternativa", 120, , , , , cnt_Formato_Valor)
        objGrid_Coluna_Add(grdGeral, "Moeda", 60, , , ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdGeral, "Visivel", 70, , , ColumnStyle.CheckBox)

        SEC_ValidarBotao(cmdGravar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)

        CarregarDados()
        ExecutaConsulta()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String = ""
        Dim SqlWhere As String = ""

        SqlText = "SELECT   B.NU_SEQUENCIA, B.CD_PAPEL, B.NO_PAPEL, B.DT_LIMITE_ENTREGA, "
        SqlText = SqlText & "         B.VL_DIFERENCIAL, "
        SqlText = SqlText & "         DECODE (B.IC_BOLSA_SEM_SINAL, "
        SqlText = SqlText & "                 'S', 'SS', "
        SqlText = SqlText & "                 DECODE (B.IC_ALTERNATIVO, 'S', 'CA', 'SN') "
        SqlText = SqlText & "                ) AS STATUS, "
        SqlText = SqlText & "         B.VL_COTACAO_ALTERNATIVO, DECODE(B.IC_MOEDA,'S',1,0), DECODE(B.IC_EXIBE,'S',1,0) "
        SqlText = SqlText & "    FROM SOF.BOLSA_PERIODO B "
        SqlText = SqlText & "ORDER BY DT_LIMITE_ENTREGA "

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Sequencia, _
                                                           cnt_GridGeral_Papel, _
                                                           cnt_GridGeral_Descricao, _
                                                           cnt_GridGeral_LimiteCredito, _
                                                           cnt_GridGeral_Diferencial, _
                                                           cnt_GridGeral_Status, _
                                                           cnt_GridGeral_CotacaoAlternativa, _
                                                           cnt_GridGeral_Moeda, _
                                                           cnt_GridGeral_Visivel})

        objGrid_Coluna_AddOption(grdGeral, oDS, cnt_GridGeral_Status, New Object() {"Nomal", "SN", "Alternativa", "CA", "Sem Sinal", "SS"})
    End Sub

    Private Sub CarregarDados()
        Dim SqlText As String
        Dim oData As DataTable

        SqlText = "select * from sof.bolsa_parametro"
        oData = DBQuery(SqlText)

        If Not objDataTable_Vazio(oData) Then
            txtJurosAoDia.Value = oData.Rows(0).Item("vl_juros_dia")
            txtHoraAbertura.Value = "" & oData.Rows(0).Item("dh_bolsa_abertura")
            txtHoraFechamento.Value = "" & oData.Rows(0).Item("dh_bolsa_fechamento")
            ComboBox_Possicionar(cboPapel, oData.Rows(0).Item("cd_papel_dolar"))
            chkAtiva.Checked = IIf(oData.Rows(0).Item("ic_utiliza_bolsa") = "S", True, False)
        End If
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "bolsa_periodo", "cd_papel = " & QuotedStr(objGrid_Valor(grdGeral, cnt_GridGeral_Papel)))
    End Sub

    Private Sub frmParametroBolsa_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdFechar.Height - 6
    End Sub

    Private Sub cmdGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGravar.Click
        Dim SqlText As String
        Dim Parametro(4) As DBParamentro

        If txtHoraAbertura.Text = "__:__" Then
            Msg_Mensagem("Horario de abertura invalido.")
            txtHoraAbertura.Focus()
            Exit Sub
        End If
        If txtHoraFechamento.Text = "__:__" Then
            Msg_Mensagem("Horario de fechamento invalido.")
            txtHoraFechamento.Focus()
            Exit Sub
        End If
        If Not ComboBox_LinhaSelecionada(cboPapel) Then
            Msg_Mensagem("Favor selecionar um papel para o dolar.")
            cboPapel.Focus()
            Exit Sub
        End If

        SqlText = DBMontar_Update("SOF.BOLSA_PARAMETRO", GerarArray("VL_JUROS_DIA", ":VL_JUROS_DIA", _
                                                             "DH_BOLSA_ABERTURA", ":DH_BOLSA_ABERTURA", _
                                                              "DH_BOLSA_FECHAMENTO", ":DH_BOLSA_FECHAMENTO", _
                                                              "CD_PAPEL_DOLAR", ":CD_PAPEL_DOLAR", _
                                                             "IC_UTILIZA_BOLSA", ":IC_UTILIZA_BOLSA"), _
                                                                Nothing, False)


        Parametro(0) = DBParametro_Montar("VL_JUROS_DIA", txtJurosAoDia.Value)
        Parametro(1) = DBParametro_Montar("DH_BOLSA_ABERTURA", txtHoraAbertura.Text)
        Parametro(2) = DBParametro_Montar("DH_BOLSA_FECHAMENTO", txtHoraFechamento.Text)
        Parametro(3) = DBParametro_Montar("CD_PAPEL_DOLAR", cboPapel.SelectedValue)
        Parametro(4) = DBParametro_Montar("IC_UTILIZA_BOLSA", IIf(chkAtiva.Checked, "S", "N"))

        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        Msg_Mensagem("Atualização realizada com sucesso.")

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub grdGeral_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdGeral.AfterRowUpdate
        Dim SqlText As String
        Dim Parametro(12) As DBParamentro

        If DBQuery_ValorUnico("SELECT COUNT(*) FROM SOF.BOLSA_PERIODO WHERE CD_PAPEL='" & e.Row.Cells(cnt_GridGeral_Papel).Value & "'") = 0 Then
            SqlText = DBMontar_Insert("BOLSA_PERIODO", TipoCampoFixo.Todos, "NO_PAPEL", ":NO_PAPEL", _
                                                                 "IC_MOEDA", ":IC_MOEDA", _
                                                                 "DT_LIMITE_ENTREGA", ":DT_LIMITE_ENTREGA", _
                                                                 "VL_DIFERENCIAL", ":VL_DIFERENCIAL", _
                                                                 "IC_BOLSA_SEM_SINAL", ":IC_BOLSA_SEM_SINAL", _
                                                                 "VL_PARAMETRO_MINIMO", ":VL_PARAMETRO_MINIMO", _
                                                                 "VL_PARAMETRO_MAXIMO", ":VL_PARAMETRO_MAXIMO", _
                                                                 "IC_ALTERNATIVO", ":IC_ALTERNATIVO", _
                                                                 "VL_COTACAO_ALTERNATIVO", ":VL_COTACAO_ALTERNATIVO", _
                                                                 "NU_SEQUENCIA", ":NU_SEQUENCIA", _
                                                                 "QT_DIA_ENTREGA", ":QT_DIA_ENTREGA", _
                                                                 "IC_EXIBE", ":IC_EXIBE", _
                                                                 "CD_PAPEL", ":CD_PAPEL")
        Else

            SqlText = DBMontar_Update("BOLSA_PERIODO", GerarArray("NO_PAPEL", ":NO_PAPEL", _
                                                                 "IC_MOEDA", ":IC_MOEDA", _
                                                                 "DT_LIMITE_ENTREGA", ":DT_LIMITE_ENTREGA", _
                                                                 "VL_DIFERENCIAL", ":VL_DIFERENCIAL", _
                                                                 "IC_BOLSA_SEM_SINAL", ":IC_BOLSA_SEM_SINAL", _
                                                                 "VL_PARAMETRO_MINIMO", ":VL_PARAMETRO_MINIMO", _
                                                                 "VL_PARAMETRO_MAXIMO", ":VL_PARAMETRO_MAXIMO", _
                                                                 "IC_ALTERNATIVO", ":IC_ALTERNATIVO", _
                                                                 "VL_COTACAO_ALTERNATIVO", ":VL_COTACAO_ALTERNATIVO", _
                                                                 "NU_SEQUENCIA", ":NU_SEQUENCIA", _
                                                                 "QT_DIA_ENTREGA", ":QT_DIA_ENTREGA", _
                                                                 "IC_EXIBE", ":IC_EXIBE"), _
                                            GerarArray("CD_PAPEL", ":CD_PAPEL"))
        End If

        Parametro(0) = DBParametro_Montar("NO_PAPEL", e.Row.Cells(cnt_GridGeral_Descricao).Value)
        Parametro(1) = DBParametro_Montar("IC_MOEDA", IIf(NVL(e.Row.Cells(cnt_GridGeral_Moeda).Value, 0) = 1, "S", "N"))
        If NVL(e.Row.Cells(cnt_GridGeral_Moeda).Value, 0) = 0 Then
            Parametro(2) = DBParametro_Montar("DT_LIMITE_ENTREGA", Date_to_Oracle(e.Row.Cells(cnt_GridGeral_LimiteCredito).Value), OracleClient.OracleType.DateTime)
            Parametro(3) = DBParametro_Montar("VL_DIFERENCIAL", e.Row.Cells(cnt_GridGeral_Diferencial).Value)
        Else
            Parametro(2) = DBParametro_Montar("DT_LIMITE_ENTREGA", Nothing)
            Parametro(3) = DBParametro_Montar("VL_DIFERENCIAL", Nothing)
        End If
        Parametro(4) = DBParametro_Montar("IC_BOLSA_SEM_SINAL", IIf(NuloParaString(e.Row.Cells(cnt_GridGeral_Status).Value) = "SS", "S", "N"))
        If NuloParaString(e.Row.Cells(cnt_GridGeral_Status).Value) = "CA" Then
            Parametro(5) = DBParametro_Montar("VL_PARAMETRO_MINIMO", e.Row.Cells(cnt_GridGeral_CotacaoAlternativa).Value)
            Parametro(6) = DBParametro_Montar("VL_PARAMETRO_MAXIMO", e.Row.Cells(cnt_GridGeral_CotacaoAlternativa).Value)
        Else
            Parametro(5) = DBParametro_Montar("VL_PARAMETRO_MINIMO", Nothing)
            Parametro(6) = DBParametro_Montar("VL_PARAMETRO_MAXIMO", Nothing)
        End If
        Parametro(7) = DBParametro_Montar("IC_ALTERNATIVO", IIf(NuloParaString(e.Row.Cells(cnt_GridGeral_Status).Value) = "CA", "S", "N"))
        If NuloParaString(e.Row.Cells(cnt_GridGeral_Status).Value) = "CA" Then
            Parametro(8) = DBParametro_Montar("VL_COTACAO_ALTERNATIVO", e.Row.Cells(cnt_GridGeral_CotacaoAlternativa).Value)
        Else
            Parametro(8) = DBParametro_Montar("VL_COTACAO_ALTERNATIVO", Nothing)
        End If
        Parametro(9) = DBParametro_Montar("NU_SEQUENCIA", e.Row.Cells(cnt_GridGeral_Sequencia).Value)
        Parametro(10) = DBParametro_Montar("QT_DIA_ENTREGA", 0)
        Parametro(11) = DBParametro_Montar("IC_EXIBE", IIf(NVL(e.Row.Cells(cnt_GridGeral_Visivel).Value, 0) = 1, "S", "N"))
        Parametro(12) = DBParametro_Montar("CD_PAPEL", e.Row.Cells(cnt_GridGeral_Papel).Value)


        If Not DBExecutar(SqlText, Parametro) Then GoTo Erro

        ExecutaConsulta()

        Exit Sub
Erro:
        TratarErro()
    End Sub

    Private Sub grdGeral_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdGeral.BeforeRowsDeleted
        Dim sMens As String
        Dim SqlText As String

        Try
            sMens = "Deseja excluir o Papel " & e.Rows(0).Cells(cnt_GridGeral_Papel).Value & "?"

            e.DisplayPromptMsg = False

            If Msg_Perguntar(sMens) Then
                If Not CampoNulo(e.Rows(0).Cells(cnt_GridGeral_Papel).Value) Then
                    SqlText = DBMontar_SP("SOF.SP_ELIMINA_BOLSA_PERIODO", False, ":CDPAPEL")

                    If Not DBExecutar(SqlText, DBParametro_Montar("CDPAPEL", objGrid_Valor(grdGeral, cnt_GridGeral_Papel), OracleClient.OracleType.VarChar)) Then GoTo Erro
                End If

            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            Msg_Mensagem(ex.Message)
            e.Cancel = True
        End Try

        Exit Sub
Erro:
        e.Cancel = True
    End Sub

    Private Sub grdGeral_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles grdGeral.BeforeRowUpdate

        If Trim(NuloParaString(e.Row.Cells(cnt_GridGeral_Papel).Value)) = "" Then
            Msg_Mensagem("Favor informar um codigo da bolsa.")
            Exit Sub
        End If
        If Trim(NuloParaString(e.Row.Cells(cnt_GridGeral_Descricao).Value)) = "" Then
            Msg_Mensagem("Favor informar uma descrição para o codigo da bolsa.")
            Exit Sub
        End If
        If NVL(e.Row.Cells(cnt_GridGeral_Moeda).Value, 0) = 0 Then
            If Not IsDate(e.Row.Cells(cnt_GridGeral_LimiteCredito).Value) Then
                Msg_Mensagem("Data limite da entrega invalida.")
                Exit Sub
            End If
        End If

        Select Case NuloParaString(e.Row.Cells(cnt_GridGeral_Status).Value)
            Case "SS", "CA"
                If NVL(e.Row.Cells(cnt_GridGeral_CotacaoAlternativa).Value, 0) = 0 Then
                    Msg_Mensagem("Favor informar um valor da cotação alternativa.")
                    Exit Sub
                End If
        End Select
    End Sub
End Class