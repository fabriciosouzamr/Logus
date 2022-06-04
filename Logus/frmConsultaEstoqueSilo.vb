Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaEstoqueSilo
    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1
    Const cnt_GridGeral_Filial As Integer = 2
    Const cnt_GridGeral_Modalidade As Integer = 3
    Const cnt_GridGeral_Quantidade As Integer = 4
    Const cnt_GridGeral_Valor As Integer = 5
    Const cnt_GridGeral_Utilizado As Integer = 6
    Const cnt_GridGeral_DataUtilizacao As Integer = 7

    Const cnt_SEC_Tela As String = "Transacao_MovCacau_EstoqueSilo"

    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim WithEvents oForm As frmCadastroEstoqueSilo

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub cmdExcell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell.Click
        objGrid_ExportarExcell(grdGeral, Me.Text, cmdExcell)
    End Sub

    Private Sub cmdUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsuario.Click
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        Auditoria(TipoCampoFixo.Todos, "ESTOQUE_SILO", "SQ_ESTOQUE_SILO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))
    End Sub

    Private Sub frmConsultaEstoqueSilo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_Transferencia_Modalidade_Silo(cboModalidade, True)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdGeral, "Código", 0)
        objGrid_Coluna_Add(grdGeral, "Data", 80)
        objGrid_Coluna_Add(grdGeral, "Filial", 120)
        objGrid_Coluna_Add(grdGeral, "Modalidade", 180)
        objGrid_Coluna_Add(grdGeral, "Quantidade", 100)
        objGrid_Coluna_Add(grdGeral, "Valor", 100)
        objGrid_Coluna_Add(grdGeral, "Utilizado?", 100)
        objGrid_Coluna_Add(grdGeral, "Data Utilização", 120)

        SEC_ValidarBotao(cmdNovo, cnt_SEC_Tela, SEC_Validador.SEC_V_Inclusao, True)
        SEC_ValidarBotao(cmdExcluir, cnt_SEC_Tela, SEC_Validador.SEC_V_Exclusao, True)
    End Sub

    Private Sub cmdNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNovo.Click
        oForm = New frmCadastroEstoqueSilo
        Form_Show(Me.MdiParent, oForm, , True)
    End Sub

    Private Sub cmdExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcluir.Click
        Dim bExcluir As Boolean
        Dim SqlText As String

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        bExcluir = Msg_Perguntar("Elimina o estoque do silo?")

        If bExcluir Then
            SqlText = DBMontar_SP("SOF.SP_ELIMINA_ESTOQUE_SILO", False, ":SQESTOQUESILO")
            If Not DBExecutar(SqlText, DBParametro_Montar("SQESTOQUESILO", objGrid_Valor(grdGeral, cnt_GridGeral_Codigo))) Then GoTo Erro

        End If

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        If Not Data_ValidarPeriodo("do estoque silo", txtDataInicial.Value, txtDataFinal.Value, False) Then Exit Sub

        SqlText = "SELECT es.sq_estoque_silo, es.dt_estoque, f.no_filial, "
        SqlText = SqlText & "       tm.no_transferencia_modalidade, es.qt_volume, es.vl_estoque, "
        SqlText = SqlText & "       DECODE (es.ic_utilizado, 'S', 'Sim', 'Não'), es.dt_utilizacao "
        SqlText = SqlText & "  FROM sof.estoque_silo es, sof.filial f, sof.transferencia_modalidade tm "
        SqlText = SqlText & " WHERE f.cd_filial = es.cd_filial "
        SqlText = SqlText & "   AND tm.cd_transferencia_modalidade = es.cd_transferencia_modalidade "

        If IsDate(txtDataInicial.Text) Then
            SqlText = SqlText & " AND TRUNC( ES.dt_estoque ) >= " & QuotedStr(Date_to_Oracle(txtDataInicial.Text))
        End If

        If IsDate(txtDataFinal.Text) Then
            SqlText = SqlText & " AND TRUNC( ES.dt_estoque ) <= " & QuotedStr(Date_to_Oracle(txtDataFinal.Text))
        End If

        Select Case optFiltro.Value
            Case "A"
                SqlText = SqlText & " and ES.IC_UTILIZADO ='N'"
            Case "U"
                SqlText = SqlText & " and ES.IC_UTILIZADO ='S'"
        End Select

        If ComboBox_LinhaSelecionada(cboModalidade) Then
            SqlText = SqlText & " AND ES.CD_TRANSFERENCIA_MODALIDADE=" & cboModalidade.SelectedValue
        End If

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, _
                                                            cnt_GridGeral_Data, _
                                                            cnt_GridGeral_Filial, _
                                                            cnt_GridGeral_Modalidade, _
                                                            cnt_GridGeral_Quantidade, _
                                                            cnt_GridGeral_Valor, _
                                                            cnt_GridGeral_Utilizado, _
                                                            cnt_GridGeral_DataUtilizacao})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub oForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles oForm.FormClosing
        ExecutaConsulta()
    End Sub

    Private Sub frmConsultaEstoqueSilo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Altura
        grdGeral.Height = Me.ClientSize.Height - grdGeral.Top - 53
        'Largura
        grdGeral.Width = Me.ClientSize.Width - grdGeral.Left - 15
        'Posição horizontal
        cmdFechar.Left = Me.ClientSize.Width - cmdFechar.Width - 15
        cmdUsuario.Left = Me.ClientSize.Width - cmdUsuario.Width - 65
        'Posição vertical
        cmdNovo.Top = Me.ClientSize.Height - cmdNovo.Height - 6
        cmdExcell.Top = Me.ClientSize.Height - cmdExcell.Height - 6
        cmdFechar.Top = Me.ClientSize.Height - cmdFechar.Height - 6
        cmdUsuario.Top = Me.ClientSize.Height - cmdUsuario.Height - 6
        cmdExcluir.Top = Me.ClientSize.Height - cmdExcluir.Height - 6
    End Sub
End Class