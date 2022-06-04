Imports System.Windows.Forms
Imports Infragistics.Win

Module ComboBox
    Public Sub ComboBox_Carregar(ByVal oCombo As System.Windows.Forms.ComboBox, _
                                 ByVal Texto() As String, _
                                 Optional ByVal Codigo() As Object = Nothing, _
                                 Optional ByVal AdicionarDados As Boolean = False)
        Dim oData As New DataTable
        Dim RC As DataRowCollection
        Dim oRow As DataRow
        Dim oRowVal(1) As Object
        Dim iCont As Integer

        If AdicionarDados Then
            oData = oCombo.DataSource
        Else
            oData.Columns.Add("Codigo")
            oData.Columns.Add("Descricao")
        End If

        RC = oData.Rows

        For iCont = 0 To UBound(Texto)
            If Not Codigo Is Nothing Then
                oRowVal(0) = Codigo(iCont)
            End If
            oRowVal(1) = Texto(iCont)

            oRow = RC.Add(oRowVal)
        Next

        oCombo.DisplayMember = "Descricao"
        oCombo.ValueMember = "Codigo"
        oCombo.DataSource = oData
    End Sub

    Public Sub ComboBox_Possicionar(ByVal oCombo As System.Windows.Forms.ComboBox, ByVal vValor As Object, _
                                    Optional ByVal CdColuna As Integer = 0)
        Dim iIndice As Integer
        Dim bAchou As Boolean

        For iIndice = 0 To oCombo.Items.Count - 1
            If IsNumeric(vValor) Then
                If Val(NVL(oCombo.Items(iIndice)(CdColuna), Nothing)) = NVL(vValor, 0) Then
                    bAchou = True
                    Exit For
                End If
            Else
                If NVL(oCombo.Items(iIndice)(CdColuna), Nothing) = NVL(vValor, 0) Then
                    bAchou = True
                    Exit For
                End If
            End If
        Next

        If bAchou Then
            oCombo.SelectedIndex = iIndice
        Else
            oCombo.SelectedIndex = -1
        End If
    End Sub

    Public Function ComboBox_LinhaSelecionada(ByVal oCombo As System.Windows.Forms.ComboBox, _
                                              Optional ByVal ValidarDescricaoBranco As Boolean = False) As Boolean
        If oCombo.SelectedIndex = -1 Then
            Return False
        Else
            If ((Trim(oCombo.SelectedValue) = "-1" And Not ValidarDescricaoBranco) Or _
                (ValidarDescricaoBranco And Trim(oCombo.Text) = "")) Then
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Public Function ObjUltraComboBox_LinhaSelecionada(ByVal oCombo As Infragistics.Win.UltraWinGrid.UltraCombo) As Boolean
        If oCombo.SelectedRow Is Nothing Then
            Return False
        Else
            If Trim(oCombo.SelectedRow.Cells(0).Value) = "-1" Then
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Public Function ComboBox_QuantidadeItens(ByVal oCombo As System.Windows.Forms.ComboBox) As Integer
        Dim Quantidade As Integer

        If oCombo.Items.Count = 0 Then
            Quantidade = 0
        Else
            Quantidade = oCombo.Items.Count

            If Trim(oCombo.Items(0)(0)) = "-1" Then
                Quantidade = Quantidade - 1
            End If
        End If

        Return Quantidade
    End Function

    Public Sub ListBox_Possicionar(ByVal oList As System.Windows.Forms.ListBox, _
                                   ByVal vValor As Object)
        Dim iIndice As Integer
        Dim bAchou As Boolean

        For iIndice = 0 To oList.Items.Count - 1
            oList.SelectedIndex = iIndice

            If oList.SelectedValue = vValor Then
                bAchou = True
                Exit For
            End If
        Next

        If bAchou Then
            oList.SelectedIndex = iIndice
        Else
            oList.SelectedIndex = -1
        End If
    End Sub

    Public Sub CheckListBox_Possicionar(ByVal oList As System.Windows.Forms.CheckedListBox, _
                                        ByVal vValor As Object)
        Dim iIndice As Integer
        Dim bAchou As Boolean

        For iIndice = 0 To oList.Items.Count - 1
            oList.SelectedIndex = iIndice

            If oList.SelectedValue = vValor Then
                bAchou = True
                Exit For
            End If
        Next

        If bAchou Then
            oList.SetItemCheckState(iIndice, CheckState.Checked)
            oList.SelectedIndex = iIndice
            oList.Refresh()
        End If
    End Sub

    Public Sub objUltraComboBox_Inicializar(ByVal oCombo As Infragistics.Win.UltraWinGrid.UltraCombo, _
                                            Optional ByVal TamanhoLista As Long = 0)
        With oCombo
            .DropDownStyle = UltraWinGrid.UltraComboStyle.DropDownList
            If TamanhoLista > 0 Then
                .DropDownWidth = TamanhoLista
            End If
            .DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Public Sub objUltraComboBox_Carregar(ByVal oCombo As Infragistics.Win.UltraWinGrid.UltraCombo, _
                                         ByVal SqlText As String, _
                                         ByVal oCombo_Informacao() As Combo_Informacao, _
                                         Optional ByVal SelecionaAutomatico As Boolean = True, _
                                         Optional ByVal LinhaBranco As Boolean = False)
        Dim iCont As Integer
        Dim oData As DataTable
        Dim oDataCombo As New DataTable
        Dim iCont_01 As Integer

        oData = DBQuery(SqlText)
        oDataCombo = oData.Copy
      

        'Se for ter linha em branco
        If LinhaBranco Then
            Dim oRow As DataRow

            'LInha em branco
            oDataCombo.Rows.Clear()
            oRow = oDataCombo.NewRow
            oDataCombo.Rows.Add(oRow)
            oRow(0) = -1
            '   For iCont_01 = 1 To oData.Columns.Count - 1
            oRow(1) = Nothing
            '   Next

            For iCont = 0 To oData.Rows.Count - 1
                oRow = oDataCombo.NewRow

                For iCont_01 = 0 To oData.Columns.Count - 1
                    oRow(iCont_01) = oData.Rows(iCont)(iCont_01)
                Next

                oDataCombo.Rows.Add(oRow)
            Next
        End If

        If Not oCombo_Informacao Is Nothing Then
            oCombo.DataSource = oDataCombo
            oCombo.DataBind()

            For iCont = LBound(oCombo_Informacao) To UBound(oCombo_Informacao)
                With oCombo_Informacao(iCont)
                    oCombo.DisplayLayout.Bands(0).Columns(iCont).Header.Caption = .Titulo
                    If .Tamanho > 0 Then
                        oCombo.DisplayLayout.Bands(0).Columns(iCont).Width = .Tamanho
                    End If
                    oCombo.DisplayLayout.Bands(0).Columns(iCont).Hidden = (Not .Visivel)

                    If .Descricao Then
                        oCombo.DisplayMember = oData.Columns(iCont).ColumnName
                    End If
                    If .Codigo Then
                        oCombo.ValueMember = oData.Columns(iCont).ColumnName
                    End If

                    If Trim(.Formato) <> "" Then
                        oCombo.DisplayLayout.Bands(0).Columns(iCont).Format = .Formato
                    End If

                    oCombo.DisplayLayout.Bands(0).Columns(iCont).Style = .Tipo
                End With
            Next

            If SelecionaAutomatico And oCombo.DisplayLayout.Rows.Count > 0 Then
                oCombo.SelectedRow = oCombo.DisplayLayout.Rows(0)
            End If
        End If
    End Sub

    Public Function objUltraComboBox_Informacao(ByVal Titulo As String, ByVal Visivel As Boolean, _
                                                ByVal Tamanho As Long, Optional ByVal Descricao As Boolean = False, _
                                                Optional ByVal Codigo As Boolean = False, _
                                                Optional ByVal Formato As String = "", _
                                                Optional ByVal Tipo As UltraWinGrid.ColumnStyle = UltraWinGrid.ColumnStyle.Default) As Combo_Informacao
        Dim oCombo_Informacao As New Combo_Informacao

        With oCombo_Informacao
            .Titulo = Titulo
            .Visivel = Visivel
            .Tamanho = Tamanho
            .Descricao = Descricao
            .Codigo = Codigo
            .Formato = Formato
            .Tipo = Tipo
        End With

        Return oCombo_Informacao
    End Function

    Public Sub objUltraComboBox_Possicionar(ByVal oCombo As Infragistics.Win.UltraWinGrid.UltraCombo, _
                                            ByVal Coluna As Integer, _
                                            ByVal vValor As Object)
        Dim iIndice As Integer
        Dim bAchou As Boolean

        For iIndice = 0 To oCombo.DisplayLayout.Rows.Count - 1
            If Not CampoNulo(vValor) Then
                If oCombo.DisplayLayout.Rows(iIndice).Cells(Coluna).Value = vValor Then
                    bAchou = True
                    Exit For
                End If
            End If
        Next

        If bAchou Then
            oCombo.SelectedRow = oCombo.DisplayLayout.Rows(iIndice)
        Else
            oCombo.SelectedRow = Nothing
        End If
    End Sub

    Public Sub objUltraComboBox_Carregar_Filial(ByRef oCombo As Infragistics.Win.UltraWinGrid.UltraCombo, _
                                                Optional ByVal LinhaBranco As Boolean = False, _
                                                Optional ByVal SemArmazem As Boolean = True)
        Dim SqlText As String

        SqlText = "SELECT CD_FILIAL, NO_FILIAL" & _
                  " FROM SOF.FILIAL " & _
                  " WHERE IC_ATIVA = 'S'"

        If SemArmazem = True Then
            SqlText = SqlText & " AND IC_ARMAZEM = 'N' "
        End If

        SqlText = SqlText & " ORDER BY NO_FILIAL "

        objUltraComboBox_Carregar(oCombo, SqlText, New Combo_Informacao() {objUltraComboBox_Informacao("", False, 0, False, True, ""), _
                                                                           objUltraComboBox_Informacao("Filial", True, 0, True, False, "")}, , LinhaBranco)

        oCombo.AlwaysInEditMode = True
        oCombo.AlwaysInEditMode = True
        oCombo.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True
        oCombo.DisplayLayout.Override.CellClickAction = UltraWinGrid.CellClickAction.Edit
    End Sub
End Module

Class Combo_Informacao
    Public Titulo As String
    Public Visivel As Boolean
    Public Tamanho As Long
    Public Descricao As Boolean
    Public Codigo As Boolean
    Public Formato As String
    Public Tipo As UltraWinGrid.ColumnStyle
End Class