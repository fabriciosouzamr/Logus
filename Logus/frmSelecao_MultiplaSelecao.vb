Public Class frmSelecao_MultiplaSelecao
    Public oSelecao As DataTable
    Public sBancoDados_Tabela As String
    Public sBancoDados_Campo_Codigo As String
    Public sBancoDados_Campo_Descricao As String
    Public oBancoDados_Filtro As Collection

    Dim oEncontrado As DataTable
    Dim oSelecionado As DataTable

    Private Sub cmdSeleciona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeleciona.Click
        Dim iCont As Integer
        Dim bAchou As Boolean

        If lstEncontratos.SelectedItems.Count = 0 Then
            Msg_Mensagem("Selecione algum item a ser movimentado")
        Else
            Do While lstEncontratos.SelectedItems.Count > 0
                bAchou = False

                For iCont = 0 To oSelecionado.Rows.Count - 1
                    If oEncontrado.Rows(lstEncontratos.SelectedIndices(0)).Item(0) = _
                       oSelecionado.Rows(iCont).Item(0) Then
                        bAchou = True
                        Exit For
                    End If
                Next

                If Not bAchou Then
                    With oSelecionado.Rows.Add
                        .Item(0) = oEncontrado.Rows(lstEncontratos.SelectedIndices(0)).Item(0)
                        .Item(1) = oEncontrado.Rows(lstEncontratos.SelectedIndices(0)).Item(1)
                    End With

                    lstEncontratos.SelectedItems.Remove(lstEncontratos.SelectedItems(0))
                End If
            Loop
        End If

        LimparSelecionado()
    End Sub

    Private Sub cmdExclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExclui.Click
        If lstSelecionado.SelectedItems.Count = 0 Then
            Msg_Mensagem("Selecione algum item a ser excluído")
        Else
            Dim iCont_01 As Integer
            Dim iCont_02 As Integer

            For iCont_01 = 0 To lstSelecionado.SelectedItems.Count - 1
                For iCont_02 = 0 To oSelecionado.Rows.Count - 1
                    If lstSelecionado.SelectedItems(iCont_01)(0) = oSelecionado.Rows(iCont_02)(0) Then
                        oSelecionado.Rows(iCont_02)(0) = -1
                        Exit For
                    End If
                Next
            Next

            iCont_01 = 0

            While iCont_01 < oSelecionado.Rows.Count
                If oSelecionado.Rows(iCont_01)(0) = -1 Then
                    oSelecionado.Rows(iCont_01).Delete()
                Else
                    iCont_01 = iCont_01 + 1
                End If
            End While
        End If
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub cmdSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelecionar.Click
        If oSelecionado.Rows.Count = 0 Then
            Msg_Mensagem("Selecione algum registro ou clique quem cancelar.")
            Exit Sub
        End If

        oSelecao = oSelecionado
        Close()
    End Sub

    Private Sub frmSelecao_MultiplaSelecao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objData_Formatar(oSelecionado, New DataTable_Column() {objData_Formatar_Coluna("Codigo", eDbType._Inteiro), _
                                                               objData_Formatar_Coluna("Descricao", eDbType._Texto)})

        If Not oSelecao Is Nothing Then
            oSelecionado = oSelecao.Copy
        End If

        lstSelecionado.DataSource = oSelecionado
        lstSelecionado.ValueMember = oSelecionado.Columns(0).ColumnName
        lstSelecionado.DisplayMember = oSelecionado.Columns(1).ColumnName
    End Sub

    Private Sub cmdPesquisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisa.Click
        Dim SqlText As String

        If Trim(txtTermoPesquisa.Text) = "" Then
            Msg_Mensagem("Informe o texto para ser pesquisado")
            Exit Sub
        End If

        Dim oForm As frmAvi

        oForm = AVI_AbrirTela()

        SqlText = "SELECT DISTINCT " & sBancoDados_Campo_Codigo & ", " & sBancoDados_Campo_Descricao & _
                  " FROM " & DBObjeto_TratarNome(sBancoDados_Tabela) & _
                  " WHERE UPPER(" & sBancoDados_Campo_Descricao & ") LIKE " & SQL_FormatarLike(txtTermoPesquisa.Text)

        If IsNumeric(txtTermoPesquisa.Text) Then
            SqlText = SqlText & " OR " & sBancoDados_Campo_Codigo & " = " & txtTermoPesquisa.Text
        End If

        If oBancoDados_Filtro.Count > 0 Then
            SqlText = SqlText & " AND " & Montar_Filtro(oBancoDados_Filtro, " ")
        End If

        SqlText = SqlText & " ORDER BY " & sBancoDados_Campo_Descricao

        oEncontrado = DBQuery(SqlText)

        LimparSelecionado()

        lstEncontratos.DataSource = oEncontrado
        lstEncontratos.ValueMember = oEncontrado.Columns(0).ColumnName
        lstEncontratos.DisplayMember = oEncontrado.Columns(1).ColumnName

        If lstEncontratos.Items.Count = 1 Then
            lstEncontratos.SetSelected(0, True)
            cmdSeleciona_Click(Nothing, Nothing)
        End If

        AVI_FechaTela(oForm)
    End Sub

    Private Sub LimparSelecionado()
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        For iCont_01 = 0 To oSelecionado.Rows.Count - 1
            For iCont_02 = 0 To oEncontrado.Rows.Count - 1
                If oSelecionado.Rows(iCont_01).Item(0) = oEncontrado.Rows(iCont_02).Item(0) Then
                    oEncontrado.Rows.RemoveAt(iCont_02)
                    Exit For
                End If
            Next
        Next

        lstSelecionado.DataSource = Nothing
        lstSelecionado.DataSource = oSelecionado
        lstSelecionado.ValueMember = oSelecionado.Columns(0).ColumnName
        lstSelecionado.DisplayMember = oSelecionado.Columns(1).ColumnName
    End Sub

    Private Sub lstEncontratos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstEncontratos.DoubleClick
        cmdSeleciona_Click(Nothing, Nothing)
    End Sub

    Private Sub lstSelecionado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSelecionado.DoubleClick
        cmdExclui_Click(Nothing, Nothing)
    End Sub
End Class