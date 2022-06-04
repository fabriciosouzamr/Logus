Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmStatusFilial
    Const cnt_GridGeral_Codigo As Integer = 0
    Const cnt_GridGeral_Status As Integer = 1
    Const cnt_GridGeral_Filial As Integer = 2
    Dim oDS As New UltraWinDataSource.UltraDataSource

    Private Sub frmStatusFilial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objGrid_Inicializar(grdGeral, , oDS, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdGeral, "Código", 0)
        objGrid_Coluna_Add(grdGeral, "Filial Aberta?", 90, , True, ColumnStyle.CheckBox)
        objGrid_Coluna_Add(grdGeral, "Filial", 170)

        ExecutaConsulta()
    End Sub

    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub ExecutaConsulta()
        Dim SqlText As String

        SqlText = "select cd_filial,decode( ic_fechada,'S',0,1) ,no_filial from sof.filial where ic_ativa='S' order by no_filial"


        objGrid_Carregar(grdGeral, SqlText, New Integer() {cnt_GridGeral_Codigo, _
                                                            cnt_GridGeral_Status, _
                                                            cnt_GridGeral_Filial})

        Dim iCont As Integer

        For iCont = 0 To grdGeral.Rows.Count - 1
            If grdGeral.Rows(iCont).Cells(cnt_GridGeral_Status).Value = 1 Then
                With grdGeral.Rows(iCont).Appearance
                    .ForeColor = Color.Black
                    .BackColor = Color.LightGreen
                End With
            Else
                With grdGeral.Rows(iCont).Appearance
                    .ForeColor = Color.White
                    .BackColor = Color.Red
                End With
            End If
        Next
    End Sub

    Private Sub cmdAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtualizar.Click
        ExecutaConsulta()
    End Sub

    Private Sub grdGeral_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdGeral.AfterRowUpdate
        Dim SqlText As String

        Revisao_de_Contratos(True)

        SqlText = "update sof.filial set ic_fechada=" & QuotedStr(IIf(e.Row.Cells(cnt_GridGeral_Status).Value = 1, "N", "S")) & " where cd_filial=" & e.Row.Cells(cnt_GridGeral_Codigo).Value

        If Not DBExecutar(SqlText) Then GoTo Erro

        ExecutaConsulta()

        Exit Sub

Erro:
        TratarErro()
    End Sub

    Private Sub grdGeral_BeforeRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles grdGeral.BeforeRowUpdate
        If e.Row.Cells(cnt_GridGeral_Status).Value = 0 Then
            If Msg_Perguntar("Fecha a filial " & e.Row.Cells(cnt_GridGeral_Filial).Value & " ?") = False Then e.Cancel = True
        Else
            If Msg_Perguntar("Abre a filial " & e.Row.Cells(cnt_GridGeral_Filial).Value & " ?") = False Then e.Cancel = True
        End If
    End Sub
End Class