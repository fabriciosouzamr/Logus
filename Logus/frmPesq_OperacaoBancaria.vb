Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmPesq_OperacaoBancaria
    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_NomeOperacao As Integer = 1
    Const cnt_GridGeral_DebitoCredito As Integer = 2
    Const cnt_GridGeral_ContaContabil As Integer = 3
    Const cnt_GridGeral_EmiteCheque As Integer = 4
    Const cnt_GridGeral_Lancar As Integer = 5

    Dim oPesq_CodigoNome As Pesq_CodigoNome
    Dim oDS As New UltraWinDataSource.UltraDataSource
    Dim oFiltro As Collection

    Private Sub frmPesq_OperacaoBancaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Carregar_CreditoDebito(cboCreditoDebito)

        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False, True)
        objGrid_Coluna_Add(grdGeral, "Código", 100)
        objGrid_Coluna_Add(grdGeral, "Nome da Operação", 130)
        objGrid_Coluna_Add(grdGeral, "Débito/Crédito", 120)
        objGrid_Coluna_Add(grdGeral, "Conta Contábil", 100)
        objGrid_Coluna_Add(grdGeral, "Emite Cheque?", 100)
        objGrid_Coluna_Add(grdGeral, "Lança RD?", 100)
    End Sub

    Property Form_Pesq_Filtro() As Collection
        Get
            Return oFiltro
        End Get
        Set(ByVal Valor As Collection)
            oFiltro = Valor
        End Set
    End Property

    Property Form_Pesq_CodigoNome() As Pesq_CodigoNome
        Get
            Return oPesq_CodigoNome
        End Get
        Set(ByVal Valor As Pesq_CodigoNome)
            oPesq_CodigoNome = Valor
        End Set
    End Property

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub cmdSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionar.Click
        RegistroSelecionado()
    End Sub

    Private Sub RegistroSelecionado()
        If objGrid_LinhaSelecionada(grdGeral) = -1 Then
            Msg_Mensagem("Favor selecionar uma linha.")
            Exit Sub
        End If

        With oPesq_CodigoNome
            .TelaFiltro = True
            .Codigo = objGrid_Valor(grdGeral, cnt_GridGeral_Codigo)
            .TelaFiltro = False
        End With

        Close()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String
        Dim SqlText_Where As String = ""

        If Trim(txtNomeOperacao.Text) = "" And _
           NVL(txtCodigo.Value, 0) <= 0 And _
           Not ComboBox_LinhaSelecionada(cboCreditoDebito) Then
            Msg_Mensagem("Informe alguma informação de filtro para essa consulta")
            Exit Sub
        End If

        SqlText = "SELECT OP.CD_OPERACAO_BANCARIA," & _
                         "OP.NO_OPERACAO," & _
                         "DECODE(OP.IC_DEBITO_CREDITO, 'C', 'Crédito', 'Débito') DEBITO_CREDITO," & _
                         "OP.CD_CONTA_CONTABIL," & _
                         "DECODE(NVL(OP.IC_EMITE_CHEQUE, 'N'), 'S', 'Sim', 'Não') EMITE_CHEQUE," & _
                         "DECODE(NVL(OP.IC_LANCA_RD, 'N'), 'S', 'Sim', 'Não') LANCA_RD" & _
                  " FROM SOF.OPERACAO_BANCARIA OP"

        If Trim(txtNomeOperacao.Text) <> "" Then
            Str_Adicionar(SqlText_Where, "UPPER(OP.NO_OPERACAO) LIKE " & SQL_FormatarLike(txtNomeOperacao.Text), " AND ")
        End If
        If NVL(txtCodigo.Value, 0) > 0 Then
            Str_Adicionar(SqlText_Where, "OP.CD_OPERACAO_BANCARIA = " & txtCodigo.Value, " AND ")
        End If

        SqlText = SqlText & " WHERE NVL(IC_ATIVO, 'N') = 'S'"

        If Trim(SqlText_Where) <> "" Then
            SqlText = SqlText & " AND " & SqlText_Where
        End If

        If Not oFiltro Is Nothing Then
            If oFiltro.Count > 0 Then
                SqlText = SqlText & Montar_Filtro(oFiltro, " AND ")
            End If
        End If

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, _
                                                           cnt_GridGeral_NomeOperacao, _
                                                           cnt_GridGeral_ContaContabil, _
                                                           cnt_GridGeral_DebitoCredito, _
                                                           cnt_GridGeral_EmiteCheque, _
                                                           cnt_GridGeral_Lancar})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub grdGeral_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdGeral.DoubleClickRow
        RegistroSelecionado()
    End Sub
End Class