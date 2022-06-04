Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaSacaria
    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_Documento As Integer = 2
    Const cnt_GridGeral_Fornecedor As Integer = 3
    Const cnt_GridGeral_Filial As Integer = 4
    Const cnt_GridGeral_TipoSacaria As Integer = 5
    Const cnt_GridGeral_Quantidade As Integer = 6
    Const cnt_GridGeral_EntradaSaida As Integer = 7
    Const cnt_GridGeral_FilialDebito As Integer = 8
    Const cnt_GridGeral_TipoMovimentacao As Integer = 9

    Const cnt_SEC_Tela As String = "Transacao_Sacaria_ConsultaMovimentacao"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmConsultaSacaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pesq_Fornecedor.Tipo_Pesquisa = Logus.Pesq_CodigoNome.TPPesquisa.Pq_Logus_Fornecedor
        ComboBox_Carregar_Filial(cboFilial, True)
        ComboBox_Carregar_Tipo_Sacaria(cboTipoSacaria, True)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True, , , , True)

        objGrid_Coluna_Add(grdGeral, "Codigo", 0)
        objGrid_Coluna_Add(grdGeral, "Data", 80, , , , , cnt_Formato_Data)
        objGrid_Coluna_Add(grdGeral, "Documento", 80)
        objGrid_Coluna_Add(grdGeral, "Fornecedor", 0)
        objGrid_Coluna_Add(grdGeral, "Filial", 180)
        objGrid_Coluna_Add(grdGeral, "Tipo Sacaria", 100)
        objGrid_Coluna_Add(grdGeral, "Quantidade", 80, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdGeral, "Modalidade", 100)
        objGrid_Coluna_Add(grdGeral, "Filial Debito", 120)
        objGrid_Coluna_Add(grdGeral, "Tipo Movimentação", 120)

        objGrid_ExibirTotal(grdGeral, New Integer() {cnt_GridGeral_Quantidade})

        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)

        optTipo.CheckedIndex = 0
        optTipo_ValueChanged(Nothing, Nothing)
    End Sub

    Private Sub optTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTipo.ValueChanged
        Select Case optTipo.Value
            Case "FI"
                lblR_Titulo.Text = "Filial"
                Pesq_Fornecedor.Visible = False
                cboFilial.Visible = True
                cboFilial.Top = Pesq_Fornecedor.Top + 2
                cboFilial.Left = Pesq_Fornecedor.Left
                grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridGeral_Fornecedor).Hidden = True
                grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridGeral_TipoMovimentacao).Hidden = False
            Case "FO"
                lblR_Titulo.Text = "Fornecedor"
                Pesq_Fornecedor.Visible = True
                cboFilial.Visible = False
                grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridGeral_Fornecedor).Hidden = False
                grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridGeral_TipoMovimentacao).Hidden = True
            Case "RE"
                lblR_Titulo.Text = "Repassador"
                Pesq_Fornecedor.Visible = True
                cboFilial.Visible = False
                grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridGeral_Fornecedor).Hidden = False
                grdGeral.DisplayLayout.Bands(0).Columns(cnt_GridGeral_TipoMovimentacao).Hidden = True
        End Select
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub


    Private Sub ExecutaConsulta()
        Dim SqlText As String = ""
        Dim SqlOrder As String = ""

        If Not Data_ValidarPeriodo("data de movimentação", txtDataInicial.Text, txtDataFinal.Text, False) Then Exit Sub

        Select Case optTipo.Value
            Case "FI"
                If Not ComboBox_LinhaSelecionada(cboFilial) Then
                    Msg_Mensagem("Informe a filial.")
                    cboFilial.Focus()
                    Exit Sub
                End If

                SqlText = "SELECT SF.SQ_SACARIA_FILIAL," & _
                            "SF.DT_MOVIMENTACAO," & _
                            "SF.NU_DOCUMENTO, '' NO_FORNECEDOR, " & _
                            "FIL.NO_FILIAL, " & _
                            "TS.NO_TIPO_SACARIA," & _
                            "SF.QT_SACOS," & _
                            "decode(sf.ic_entrada_saida,'E','Entrada','Saída')," & _
                            "FILDEB.NO_FILIAL AS NO_FILDEB," & _
                            "TM.NO_TIPO_MOVIMENTACAO" & _
                    " FROM SOF.SACARIA_FILIAL SF," & _
                            "SOF.TIPO_SACARIA TS," & _
                            "SOF.FILIAL FIL," & _
                            "SOF.FILIAL FILDEB," & _
                            "SOF.SACARIA_TIPO_MOVIMENTACAO TM " & _
                    " WHERE SF.CD_TIPO_SACARIA = TS.CD_TIPO_SACARIA" & _
                            " AND SF.CD_FILIAL_CREDITO = FIL.CD_FILIAL" & _
                            " AND SF.CD_FILIAL_DEBITO = FILDEB.CD_FILIAL" & _
                            " AND TM.CD_TIPO_MOVIMENTACAO (+) = SF.CD_TIPO_MOVIMENTACAO" & _
                            " and SF.CD_FILIAL_CREDITO=" & cboFilial.SelectedValue

                SqlOrder = " order by SF.DT_MOVIMENTACAO"
            Case "FO"
                If Pesq_Fornecedor.Codigo <= 0 Then
                    Msg_Mensagem("Informe o fornecedor.")
                    Pesq_Fornecedor.Focus()
                    Exit Sub
                End If

                SqlText = "SELECT sf.sq_sacaria_fornecedor, sf.dt_movimentacao, sf.nu_documento, "
                SqlText = SqlText & "       f.no_razao_social, FIL.NO_FILIAL,  ts.no_tipo_sacaria, sf.qt_sacos, "
                SqlText = SqlText & "       decode(sf.ic_entrada_saida,'E','Entrada','Saída'), fil.no_filial, '' NO_TIPO_MOVIMENTACAO "
                SqlText = SqlText & "  FROM sof.sacaria_fornecedor sf, "
                SqlText = SqlText & "       sof.fornecedor f, "
                SqlText = SqlText & "       sof.filial fil, "
                SqlText = SqlText & "       sof.tipo_sacaria ts "
                SqlText = SqlText & " WHERE sf.cd_fornecedor = f.cd_fornecedor "
                SqlText = SqlText & "   AND sf.cd_filial_credito = fil.cd_filial "
                SqlText = SqlText & "   AND sf.cd_tipo_sacaria = ts.cd_tipo_sacaria "
                SqlText = SqlText & "   and SF.cd_fornecedor=" & Pesq_Fornecedor.Codigo

                SqlOrder = " order by SF.DT_MOVIMENTACAO, F.NO_RAZAO_SOCIAL"
            Case "RE"
                If Pesq_Fornecedor.Codigo <= 0 Then
                    Msg_Mensagem("Informe o repassador.")
                    Pesq_Fornecedor.Focus()
                    Exit Sub
                End If

                SqlText = "SELECT sf.sq_sacaria_fornecedor, sf.dt_movimentacao, sf.nu_documento, "
                SqlText = SqlText & "       f.no_razao_social,FIL.NO_FILIAL,  ts.no_tipo_sacaria, sf.qt_sacos, "
                SqlText = SqlText & "       decode(sf.ic_entrada_saida,'E','Entrada','Saída'), fil.no_filial,  '' NO_TIPO_MOVIMENTACAO  "
                SqlText = SqlText & "  FROM sof.sacaria_fornecedor sf, "
                SqlText = SqlText & "       sof.fornecedor f, "
                SqlText = SqlText & "       sof.filial fil, "
                SqlText = SqlText & "       sof.tipo_sacaria ts "
                SqlText = SqlText & " WHERE sf.cd_fornecedor = f.cd_fornecedor "
                SqlText = SqlText & "   AND sf.cd_filial_credito = fil.cd_filial "
                SqlText = SqlText & "   AND sf.cd_tipo_sacaria = ts.cd_tipo_sacaria "
                SqlText = SqlText & "   and (f.cd_repassador = " & Pesq_Fornecedor.Codigo & " or f.cd_fornecedor=" & Pesq_Fornecedor.Codigo & ")"

                SqlOrder = " order by SF.DT_MOVIMENTACAO, F.NO_RAZAO_SOCIAL"
        End Select

        '>>>>Filtros
        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC(SF.DT_MOVIMENTACAO) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If
        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC(SF.DT_MOVIMENTACAO) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If
        If ComboBox_LinhaSelecionada(cboTipoSacaria) Then
            SqlText = SqlText & " AND SF.CD_TIPO_SACARIA=" & cboTipoSacaria.SelectedValue
        End If

  
        objGrid_Carregar(grdGeral, SqlText & SqlOrder, New Integer() {cnt_GridGeral_Codigo, _
                                                            cnt_GridGeral_Data, _
                                                            cnt_GridGeral_Documento, _
                                                            cnt_GridGeral_Fornecedor, _
                                                            cnt_GridGeral_Filial, _
                                                            cnt_GridGeral_TipoSacaria, _
                                                            cnt_GridGeral_Quantidade, _
                                                            cnt_GridGeral_EntradaSaida, _
                                                            cnt_GridGeral_FilialDebito, _
                                                            cnt_GridGeral_TipoMovimentacao})


    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Select Case optTipo.Value
            Case "FI"
                Auditoria(TipoCampoFixo.Todos, "SACARIA_FILIAL", "SQ_SACARIA_FILIAL = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
            Case "FO", "RE"
                Auditoria(TipoCampoFixo.Todos, "sacaria_fornecedor", "sq_sacaria_fornecedor = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
        End Select
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        If Not Msg_Perguntar("Elimina a movimentação ?") Then Exit Sub

        Dim SqlText As String

        Select Case optTipo.Value
            Case "FI"
                SqlText = "select s.sq_movimentacao  from  sof.sacaria_filial s where s.sq_sacaria_filial =" & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
                If DBQuery_ValorUnico(SqlText, 0) <> 0 Then
                    Msg_Mensagem("Esta movimentacao possue contrapartida")
                    Exit Sub
                End If

                SqlText = "select s.sq_sacaria_fornecedor  from  sof.sacaria_filial s where s.sq_sacaria_filial =" & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
                If DBQuery_ValorUnico(SqlText, 0) <> 0 Then
                    Msg_Mensagem("Esta movimentacao possue contrapartida")
                    Exit Sub
                End If

                SqlText = "select s.cd_filial_credito  from  sof.sacaria_filial s where s.sq_sacaria_filial =" & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
                If FilialFechada(DBQuery_ValorUnico(SqlText)) Then
                    Msg_Mensagem("A Filial está fechada. No momento não é possivel realizar a exclusão.")
                    Exit Sub
                End If

                If Msg_Perguntar("Elimina a movimentação ?") = False Then Exit Sub

                SqlText = DBMontar_SP("SOF.ELIMINA_SACARIA_FILIAL", False, "SQ", ":SQ")

                If Not DBExecutar(SqlText, DBParametro_Montar("SQ", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))) Then GoTo Erro
            Case Else
                SqlText = "select s.sq_movimentacao  from  sof.sacaria_fornecedor s where s.sq_sacaria_fornecedor =" & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
                If DBQuery_ValorUnico(SqlText, 0) <> 0 Then
                    Msg_Mensagem("Esta movimentacao possue contrapartida")
                    Exit Sub
                End If

                SqlText = "SELECT S.CD_FILIAL_CREDITO" & _
                          " FROM  SOF.SACARIA_FORNECEDOR S" & _
                          " WHERE S.SQ_SACARIA_FORNECEDOR = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)

                If FilialFechada(DBQuery_ValorUnico(SqlText)) Then
                    Msg_Mensagem("A Filial está fechada. No momento não é possivel realizar a exclusão.")
                    Exit Sub
                End If

                SqlText = DBMontar_SP("SOF.ELIMINA_SACARIA_FORNECEDOR", False, "SQ", ":SQ")

                If Not DBExecutar(SqlText, DBParametro_Montar("SQ", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))) Then GoTo Erro
        End Select

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub frmConsultaSacaria_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub
End Class