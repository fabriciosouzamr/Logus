Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaNotaRemessa
    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_NF As Integer = 2
    Const cnt_GridGeral_Serie As Integer = 3
    Const cnt_GridGeral_Quantidade As Integer = 4

    Const cnt_SEC_Tela As String = "Transacao_MovCacau_NotaRemessa"

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmConsultaNotaRemessa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, , , , , True)

        objGrid_Coluna_Add(grdGeral, "Código", 0)
        objGrid_Coluna_Add(grdGeral, "Data", 120)
        objGrid_Coluna_Add(grdGeral, "N.F.", 120)
        objGrid_Coluna_Add(grdGeral, "Serie", 120)
        objGrid_Coluna_Add(grdGeral, "Quantidade", 120, , , , , cnt_Formato_Kilos)

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdAlterar, cnt_SEC_Tela, SEC_Validador.SEC_V_Alteracao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub frmConsultaNotaRemessa_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdNovo.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdAlterar.Top = Me.ClientSize.Height - cmdExcell.Height - 6
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim sMens As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        sMens = "Deseja excluir"
        sMens = sMens & " a nota de remessa?"

        If Msg_Perguntar(sMens) Then
            If Not DBExecutar_Delete("SOF.nf_remessa_movimentacao", "SQ_nf_remessa", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro
            If Not DBExecutar_Delete("SOF.nf_remessa", "SQ_nf_remessa", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)) Then GoTo Erro
        End If

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String = ""
        Dim SqlWhere As String = ""

        If Not Data_ValidarPeriodo("", txtDataInicial.Value, txtDataFinal.Value, False) Then Exit Sub

        SqlText = "SELECT SQ_NF_REMESSA," & _
                         "DT_NF_REMESSA," & _
                         "NU_NF," & _
                         "NU_SERIE_NF," & _
                         "QT_KG_NF" & _
                  " FROM SOF.NF_REMESSA"

        If IsDate(txtDataInicial.Text) Then
            Str_Adicionar(SqlWhere, " TRUNC(DT_NF_REMESSA) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text)), " AND ")
        End If
        If IsDate(txtDataFinal.Text) Then
            Str_Adicionar(SqlWhere, " TRUNC(DT_NF_REMESSA) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text)), " AND ")
        End If
        If Trim(txtNFRemessa.Text) <> "" Then
            Str_Adicionar(SqlWhere, "NU_NF = " & QuotedStr(txtNFRemessa.Text), " AND ")
        End If
        If Trim(SqlWhere) <> "" Then
            SqlText = SqlText & " WHERE " & SqlWhere
        End If

        SqlText = SqlText & " ORDER BY DT_NF_REMESSA"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, cnt_GridGeral_Data, cnt_GridGeral_NF, _
                                                           cnt_GridGeral_Serie, cnt_GridGeral_Quantidade})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        ControleEdicaoTela = eControleEdicaoTela.INCLUIR
        Form_Show(Me.MdiParent, frmCadastroNotaRemessa, , True)
    End Sub

    Private Sub cmdAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar um registro.")
            Exit Sub
        End If

        ControleEdicaoTela = eControleEdicaoTela.ALTERAR
        Filtro = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
        Form_Show(Me.MdiParent, frmCadastroNotaRemessa)
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "NF_REMESSA", "SQ_NF_REMESSA = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub
End Class