Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaInterfacePagamento
    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_Data As Integer = 1

    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub frmConsultaInterfacePagamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdGeral, "Código", 60)
        objGrid_Coluna_Add(grdGeral, "Data / Hora", 120, , , ColumnStyle.DateTimeWithoutDropDown)
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        If Not IsDate(txtData.Value) Then
            Msg_Mensagem("Informe a data para pesquisa")
            Exit Sub
        End If

        SqlText = "SELECT IP.SQ_INTERFACE_PAGAMENTO," & _
                         "IP.DH_INTERFACE" & _
                  " FROM SOF.INTERFACE_PAGAMENTO IP" & _
                  " WHERE TRUNC (IP.DH_INTERFACE) = " & QuotedStr(Date_to_Oracle(txtData.Text)) & _
                  " ORDER BY IP.SQ_INTERFACE_PAGAMENTO"

        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, cnt_GridGeral_Data})
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisar.Click
        ExecutaConsulta()
    End Sub

    Private Sub grdGeral_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGeral.Click
        Dim SqlText As String
        Dim oData As DataTable
        Dim iCont As Integer

        Me.rctEmail.Text = ""

        If objGrid_LinhaSelecionada(grdGeral) = -1 Then Exit Sub

        SqlText = "SELECT /*+ INDEX_JOIN(INTERFACE_PAG_X_PAG) */ DS_EMAIL" & _
                  " FROM SOF.INTERFACE_PAG_X_PAG " & _
                  " WHERE SQ_INTERFACE_PAGAMENTO = " & objGrid_Valor(grdGeral, cnt_GridGeral_Codigo) & " " & _
                  " ORDER BY NU_SEQ_INTERFACE"
        oData = DBQuery(SqlText)

        Me.rctEmail.Text = "Favor realizar os seguintes pagamentos:" & vbCrLf

        For iCont = 0 To oData.Rows.Count - 1
            Me.rctEmail.Text = Me.rctEmail.Text & vbCrLf & oData.Rows(iCont).Item("ds_email")
        Next
    End Sub
End Class