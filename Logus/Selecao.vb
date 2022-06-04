Public Class Selecao
    Enum enMultiplaSelecao_Codigo_Tipo
        Numero = 1
        Texto = 2
    End Enum

    Dim sBancoDados_Tabela As String
    Dim sBancoDados_Campo_Codigo As String
    Dim sBancoDados_Campo_Descricao As String
    Dim oBancoDados_Campo_Outros As Collection
    Dim oBancoDados_Filtro As Collection
    Dim oBancoDados As Collection
    Dim oMultiplaSelecao As DataTable
    Dim bMultiplaSelecao As Boolean
    Dim bOrdenarConuslta As Boolean = True
    Dim eMultiplaSelecao_Codigo_Tipo As enMultiplaSelecao_Codigo_Tipo = enMultiplaSelecao_Codigo_Tipo.Numero

    Event AlterouRegistro()
    Event FechouList()

    Public Property MultiplaSelecao_Codigo_Tipo() As enMultiplaSelecao_Codigo_Tipo
        Get
            Return eMultiplaSelecao_Codigo_Tipo
        End Get
        Set(ByVal Valor As enMultiplaSelecao_Codigo_Tipo)
            eMultiplaSelecao_Codigo_Tipo = Valor
        End Set
    End Property

    Private Sub AjustarControle()
        If clbSelecao.Visible Then
            Me.Height = cmdMarcarTodos.Top + cmdMarcarTodos.Height + 4
        Else
            Me.Height = lblSelecao.Height + 3
        End If
    End Sub

    Private Sub lblSelecao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSelecao.Click
        ValidarClick()
    End Sub

    Private Sub TratarAlteracaoRegistro()
        RaiseEvent AlterouRegistro()
    End Sub

    Private Sub ValidarClick()
        clbSelecao.Visible = True
        AjustarControle()
        Me.BringToFront()
        Me.BackColor = System.Drawing.Color.FromArgb(CType(230, Byte), CType(238, Byte), CType(249, Byte))

        If clbSelecao.Items.Count = 0 And bMultiplaSelecao Then
            Pesquisar()
        End If
    End Sub

    Public Sub Lista_Selecao_MarcarTodos(ByVal Marcar As Boolean)
        Dim iCont As Integer

        For iCont = 0 To clbSelecao.Items.Count - 1
            clbSelecao.SetItemChecked(iCont, Marcar)
        Next

        ExibirLista()
        TratarAlteracaoRegistro()
    End Sub

    Private Sub ExibirLista()
        Dim iCont As Integer
        Dim sLista As String = ""

        For Each iCont In clbSelecao.CheckedIndices
            Str_Adicionar(sLista, clbSelecao.Items(iCont).ToString, ", ")
        Next

        lblSelecao.Text = sLista
        ToolTip1.SetToolTip(lblSelecao, sLista)
    End Sub

    Private Sub Selecao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        If Not clbSelecao.Visible Then
            ValidarClick()
        End If
    End Sub

    Private Sub Selecao_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lblSelecao.Width = Me.ClientSize.Width - 3
        clbSelecao.Width = Me.ClientSize.Width - 3
        cmdConfirmar.Left = Me.ClientSize.Width - cmdConfirmar.Width - 1
    End Sub

    Property BancoDados_Tabela() As String
        Get
            Return sBancoDados_Tabela
        End Get
        Set(ByVal Valor As String)
            sBancoDados_Tabela = Valor
            Limpar()
        End Set
    End Property

    Property MultiplaSelecao() As Boolean
        Get
            Return bMultiplaSelecao
        End Get
        Set(ByVal bValor As Boolean)
            bMultiplaSelecao = bValor
            cmdPesquisa.Visible = bValor
        End Set
    End Property

    Property BancoDados_Campo_Codigo() As String
        Get
            Return sBancoDados_Campo_Codigo
        End Get
        Set(ByVal Valor As String)
            sBancoDados_Campo_Codigo = Valor
            Limpar()
        End Set
    End Property

    Public Sub BancoDados_Campos_Add(ByVal Campo As String)
        If oBancoDados_Campo_Outros Is Nothing Then
            oBancoDados_Campo_Outros = New Collection
        End If
        oBancoDados_Campo_Outros.Add(Campo)
    End Sub

    Property BancoDados_Campo_Descricao() As String
        Get
            Return sBancoDados_Campo_Descricao
        End Get
        Set(ByVal Valor As String)
            sBancoDados_Campo_Descricao = Valor
            Limpar()
        End Set
    End Property

    Property BancoDados_Campo_OrdenarConsulta() As Boolean
        Get
            Return bOrdenarConuslta
        End Get
        Set(ByVal Valor As Boolean)
            bOrdenarConuslta = Valor
        End Set
    End Property

    Public Sub BancoDados_Filtro_Limpar()
        oBancoDados_Filtro = New Collection
        Limpar()
    End Sub

    Public Sub BancoDados_Filtro_Adicionar(ByVal sFiltro As String)
        oBancoDados_Filtro.Add(sFiltro)
    End Sub

    Public Sub BancoDados_Carregar(Optional ByVal bMantarSelecionados As Boolean = False)
        Dim oData As DataTable
        Dim SqlText As String
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim oCampo As Object

        If Not bMantarSelecionados Then
            oMultiplaSelecao = Nothing
        End If

        If bMultiplaSelecao Then Exit Sub

        SqlText = "SELECT " & sBancoDados_Campo_Codigo & ", " & sBancoDados_Campo_Descricao

        If Not oBancoDados_Campo_Outros Is Nothing Then
            For iCont_01 = 1 To oBancoDados_Campo_Outros.Count
                SqlText = SqlText & ", " & oBancoDados_Campo_Outros(iCont_01)
            Next
        End If

        SqlText = SqlText & _
                  " FROM " & DBObjeto_TratarNome(sBancoDados_Tabela)

        If oBancoDados_Filtro.Count > 0 Then
            SqlText = SqlText & " WHERE " & Montar_Filtro(oBancoDados_Filtro, " ")
        End If

        If bOrdenarConuslta Then
            SqlText = SqlText & " ORDER BY " & sBancoDados_Campo_Descricao
        End If

        oData = DBQuery(SqlText)

        clbSelecao.Items.Clear()
        oBancoDados = New Collection

        For iCont_01 = 0 To oData.Rows.Count - 1
            clbSelecao.Items.Add(Trim(oData.Rows(iCont_01).Item(sBancoDados_Campo_Descricao)))

            oCampo = Nothing

            'Adiciona o campo de Identificador
            Array_Add(oCampo, oData.Rows(iCont_01).Item(sBancoDados_Campo_Codigo))

            'Adiciona os campos auxiliares
            If oData.Columns.Count > 2 Then
                For iCont_02 = 2 To oData.Columns.Count - 1
                    Array_Add(oCampo, oData.Rows(iCont_01).Item(iCont_02))
                Next
            End If

            oBancoDados.Add(oCampo)
        Next
    End Sub

    Private Sub Limpar()
        lblSelecao.Text = ""
        ToolTip1.SetToolTip(lblSelecao, "")
        clbSelecao.Items.Clear()
    End Sub

    Public Function Lista_Selecionado(ByVal Valor As Object) As Boolean
        Dim sAux As String = ""
        Dim iCont As Integer = 0
        Dim bOk As Boolean = False

        For iCont = 0 To clbSelecao.CheckedIndices.Count - 1
            If oBancoDados(clbSelecao.CheckedIndices(iCont) + 1)(0) = Valor Then
                bOk = True
                Exit For
            End If
        Next

        Return bOk
    End Function

    Public Function Lista_Existe(ByVal Valor As Object, Optional ByVal Checked As Boolean = False) As Boolean
        Dim sAux As String = ""
        Dim iCont As Integer = 0
        Dim bOk As Boolean = False

        If Checked Then
            For iCont = 0 To clbSelecao.CheckedIndices.Count - 1
                If clbSelecao.Items(clbSelecao.CheckedIndices(iCont)) = Valor Then
                    bOk = True
                    Exit For
                End If
            Next
        Else
            For iCont = 0 To clbSelecao.Items.Count - 1
                If clbSelecao.Items(iCont) = Valor Then
                    bOk = True
                    Exit For
                End If
            Next
        End If

        Return bOk
    End Function

    Public Sub Lista_Selecionar(ByVal Valor As Object, ByVal bSelecionar As Boolean)
        Dim iCont As Integer = 0

        For iCont = 0 To clbSelecao.Items.Count - 1
            If oBancoDados(iCont + 1)(0) = Valor Then
                clbSelecao.SetItemChecked(iCont, bSelecionar)
                Exit For
            End If
        Next

        ExibirLista()
    End Sub

    Public Function Lista_Campos(ByVal Indice As Integer, ByVal bSomenteSelecionados As Boolean) As String
        Return Lista_Array(Indice, bSomenteSelecionados)
    End Function

    Public Function Lista_ID(Optional ByVal aEliminar() As Object = Nothing) As String
        Return Lista_Array(0, True, aEliminar)
    End Function

    Public Function Lista_TodosID() As String
        Return Lista_Array(0, False)
    End Function

    Public Function Lista_Array(ByVal Indice As Integer, _
                                ByVal bSelecionado As Boolean, _
                                Optional ByVal aEliminar() As Object = Nothing) As String
        Dim sAux As String = ""
        Dim iCont As Integer = 0

        If bSelecionado Then
            For iCont = 0 To clbSelecao.CheckedIndices.Count - 1
                If Not Array_ExisteValor(aEliminar, oBancoDados(clbSelecao.CheckedIndices(iCont) + 1)(0)) Then
                    If IsNumeric(oBancoDados(clbSelecao.CheckedIndices(iCont) + 1)(0)) Then
                        Str_Adicionar(sAux, oBancoDados(clbSelecao.CheckedIndices(iCont) + 1)(Indice), ", ")
                    Else
                        Str_Adicionar(sAux, QuotedStr(oBancoDados(clbSelecao.CheckedIndices(iCont) + 1)(Indice)), ", ")
                    End If
                End If
            Next
        Else
            For iCont = 0 To clbSelecao.Items.Count - 1
                If Not Array_ExisteValor(aEliminar, oBancoDados(iCont + 1)(Indice)) Then
                    If IsNumeric(oBancoDados(iCont + 1)(Indice)) Then
                        Str_Adicionar(sAux, oBancoDados(iCont + 1)(Indice), ", ")
                    Else
                        Str_Adicionar(sAux, QuotedStr(oBancoDados(iCont + 1)(Indice)), ", ")
                    End If
                End If
            Next
        End If

        Return sAux
    End Function

    Public Function Lista_Descricao(Optional ByVal Valor As Object = Nothing, _
                                    Optional ByVal Separador As String = ",") As String
        Dim sAux As String = ""
        Dim iCont As Integer = 0

        If Valor Is Nothing Then
            For iCont = 0 To clbSelecao.CheckedIndices.Count - 1
                Str_Adicionar(sAux, clbSelecao.Items(clbSelecao.CheckedIndices(iCont)), Separador)
            Next
        Else
            For iCont = 0 To clbSelecao.Items.Count - 1
                If oBancoDados(iCont + 1)(0) = Valor Then
                    sAux = clbSelecao.Items(iCont)
                    Exit For
                End If
            Next
        End If

        Return sAux
    End Function

    Public Sub New()
        InitializeComponent()
        AjustarControle()
        oBancoDados_Filtro = New Collection
    End Sub

    Protected Overrides Sub Finalize()
        oBancoDados_Filtro = Nothing
        oBancoDados = Nothing
        MyBase.Finalize()
    End Sub

    Public Sub cmdConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfirmar.Click
        Confirmar()
        RaiseEvent FechouList()
    End Sub

    Private Sub Confirmar()
        ExibirLista()

        Me.BackColor = Color.White
        clbSelecao.Visible = False
        AjustarControle()
    End Sub

    Private Sub cmdDescarmarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDescarmarTodos.Click
        Lista_Selecao_MarcarTodos(False)
    End Sub

    Private Sub cmdMarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMarcarTodos.Click
        Lista_Selecao_MarcarTodos(True)
    End Sub

    Public Function Lista_Quantidade() As Integer
        Return clbSelecao.CheckedItems.Count
    End Function

    Public Sub SelecionarFilial(ByVal sFilial As String)
        Lista_Selecao_MarcarTodos(False)

        Dim iCont As Integer

        For iCont = 0 To clbSelecao.Items.Count - 1
            If oBancoDados(iCont + 1)(0) = Val(sFilial) Then
                clbSelecao.SetItemChecked(iCont, True)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub cmdPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPesquisa.Click
        Pesquisar()
    End Sub

    Private Sub Pesquisar()
        Dim oForm As New frmSelecao_MultiplaSelecao

        If oMultiplaSelecao Is Nothing Then
            Lista_Reiniciar()
        End If

        oForm.oSelecao = oMultiplaSelecao
        oForm.sBancoDados_Tabela = sBancoDados_Tabela
        oForm.sBancoDados_Campo_Codigo = sBancoDados_Campo_Codigo
        oForm.sBancoDados_Campo_Descricao = sBancoDados_Campo_Descricao
        oForm.oBancoDados_Filtro = oBancoDados_Filtro

        Form_Show(Nothing, oForm, True, True)

        oMultiplaSelecao = oForm.oSelecao

        oForm.Dispose()
        oForm = Nothing

        CarregarLista(True)
    End Sub

    Private Sub CarregarLista(ByVal MarcarTodos As Boolean)
        Dim iCont As Integer

        clbSelecao.Items.Clear()
        oBancoDados = New Collection

        For iCont = 0 To oMultiplaSelecao.Rows.Count - 1
            clbSelecao.Items.Add(oMultiplaSelecao.Rows(iCont).Item(1))
            oBancoDados.Add(New Object() {oMultiplaSelecao.Rows(iCont).Item(0)})
        Next

        Lista_Selecao_MarcarTodos(MarcarTodos)
        Confirmar()
    End Sub

    Private Sub clbSelecao_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbSelecao.SelectedValueChanged
        TratarAlteracaoRegistro()
    End Sub

    Public Sub Lista_Adicionar(ByVal Codigo() As Object, _
                               ByVal Descricao() As Object, _
                               Optional ByVal MarcarTodos As Boolean = True)
        Dim iCont As Integer

        If oMultiplaSelecao Is Nothing Then
            Lista_Reiniciar()
        End If

        For iCont = LBound(Codigo) To UBound(Codigo)
            With oMultiplaSelecao.Rows.Add
                .Item(0) = Codigo(iCont)
                .Item(1) = Descricao(iCont)
            End With
        Next

        CarregarLista(MarcarTodos)
    End Sub

    Public Sub Lista_Remover(ByVal Codigo() As Object)
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer

        For iCont_01 = LBound(Codigo) To UBound(Codigo)
            For iCont_02 = 1 To oBancoDados.Count
                If oBancoDados(iCont_02) = Codigo(iCont_01) Then
                    oBancoDados.Remove(iCont_02)
                    clbSelecao.Items.RemoveAt(iCont_01)
                    Exit For
                End If
            Next
        Next
    End Sub

    Public Sub Lista_Reiniciar()
        Dim oTipoCodigo As eDbType
        oMultiplaSelecao = Nothing

        Select Case eMultiplaSelecao_Codigo_Tipo
            Case enMultiplaSelecao_Codigo_Tipo.Numero
                oTipoCodigo = eDbType._Numero
            Case enMultiplaSelecao_Codigo_Tipo.Texto
                oTipoCodigo = eDbType._Texto
        End Select

        objData_Formatar(oMultiplaSelecao, New DataTable_Column() {objData_Formatar_Coluna("Codigo", oTipoCodigo), _
                                                                   objData_Formatar_Coluna("Descricao", eDbType._Texto)})
    End Sub
End Class