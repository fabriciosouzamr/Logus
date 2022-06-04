Imports Infragistics.Win
Imports Infragistics.Excel
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.ExcelExport
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.SupportDialogs.FilterUIProvider
Imports System.Diagnostics

Module Grid
    Public Enum gridTipoValor
        ValorNaoDefinido = 0
        ValorNumero = 1
        ValorTexto = 2
        ValorBooelan = 3
    End Enum

    Public Enum gridTipoLinha
        Linha_Filtro = 1
        Linha_Adicionar = 2
        Linha_Dados = 3
    End Enum

    Const cnt_Grid_PopUp_ItemClicked_ExportarExcell As String = "ExportarExcell"

    Public Sub objGrid_Inicializar(ByVal oGrid As UltraGrid, _
                                   Optional ByVal oAutoAdicionarLinha As AllowAddNew = AllowAddNew.Default, _
                                   Optional ByVal oData As Object = Nothing, _
                                   Optional ByVal CelulaClique As CellClickAction = CellClickAction.CellSelect, _
                                   Optional ByVal PodeAtualizar As DefaultableBoolean = DefaultableBoolean.Default, _
                                   Optional ByVal PodeDeletar As DefaultableBoolean = DefaultableBoolean.Default, _
                                   Optional ByVal ExibirLinhaFiltro As Boolean = False, _
                                   Optional ByVal VisualBand As Infragistics.Win.UltraWinGrid.ViewStyleBand = ViewStyleBand.Horizontal, _
                                   Optional ByVal FormataGrid As Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton, _
                                   Optional ByVal TipoSelecaoLinha As Infragistics.Win.UltraWinGrid.SelectType = SelectType.Default, _
                                   Optional ByVal FixarCabecalho As Boolean = False, _
                                   Optional ByVal AutoFit As AutoFitStyle = AutoFitStyle.None)
        Dim filterUIProvider As New UltraGridFilterUIProvider

        With oGrid
            Dim oAppearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
            Dim oAppearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
            Dim oAppearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
            Dim oAppearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
            Dim oAppearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance


            If Not oData Is Nothing Then
                Select Case TypeName(oData)
                    Case "UltraDataSource"
                        oData.Band.Columns.Clear()
                    Case "DataSet"
                        Dim oDS As DataSet

                        oDS = oData
                        oDS.Tables.Add()
                End Select

                .DataSource = oData
            End If

            oAppearance1.BackColor = System.Drawing.Color.White
            oAppearance2.BackColor = System.Drawing.Color.Transparent
            oAppearance3.BackColor = System.Drawing.Color.FromArgb(CType(89, Byte), CType(135, Byte), CType(214, Byte))
            oAppearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(7, Byte), CType(59, Byte), CType(150, Byte))
            oAppearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
            oAppearance3.FontData.BoldAsString = "True"
            oAppearance3.FontData.Name = "Arial"
            oAppearance3.FontData.SizeInPoints = 10.0!
            oAppearance3.ForeColor = System.Drawing.Color.White
            oAppearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            oAppearance4.BackColor = System.Drawing.Color.FromArgb(CType(89, Byte), CType(135, Byte), CType(214, Byte))
            oAppearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(7, Byte), CType(59, Byte), CType(150, Byte))
            oAppearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
            oAppearance5.BackColor = System.Drawing.Color.FromArgb(CType(251, Byte), CType(230, Byte), CType(148, Byte))
            oAppearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(238, Byte), CType(149, Byte), CType(21, Byte))
            oAppearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical

            With .DisplayLayout
                .AutoFitStyle = AutoFit
                .CaptionVisible = DefaultableBoolean.False
                .UseFixedHeaders = FixarCabecalho
                .ViewStyleBand = VisualBand

                With .Override
                    .AllowMultiCellOperations = AllowMultiCellOperation.Copy
                    .CardAreaAppearance = oAppearance2
                    .FilterUIProvider = filterUIProvider
                    .HeaderAppearance = oAppearance3
                    .MaxSelectedRows = 100
                    .RowSizing = RowSizing.Free
                    .RowSelectorAppearance = oAppearance4
                    .RowSelectorHeaderStyle = FormataGrid
                    .SelectedRowAppearance = oAppearance5
                    .SelectTypeRow = TipoSelecaoLinha
                End With

                .Appearance = oAppearance1

                objGrid_Band_Formatar(.Bands(0), CelulaClique, oAutoAdicionarLinha, PodeAtualizar, PodeDeletar, _
                                       IIf(ExibirLinhaFiltro, FilterUIType.FilterRow, FilterUIType.Default), , _
                                       TipoSelecaoLinha)

                ''Criação do popup
                'If oGrid.ContextMenuStrip Is Nothing Then
                '    Dim oMenu As New System.Windows.Forms.ContextMenuStrip

                '    AddHandler oMenu.ItemClicked, AddressOf objGrid_PopUp_ItemClicked

                '    Menu_Item_Add(cnt_Grid_PopUp_ItemClicked_ExportarExcell, "Exportar para Excell", oMenu).Tag = oGrid

                '    oGrid.ContextMenuStrip = oMenu
                'End If
            End With
        End With

        'objGrid_Formatar(oGrid)
    End Sub

    Public Sub objGrid_Gravar_Configuracao(ByVal oGrid_Control As Control, ByVal sNomeTela As String)
        Dim iCont As Integer
        Dim SqlText As String
        Dim Parametro(7) As DBParamentro
        Dim oGrid As UltraGrid

        oGrid = oGrid_Control

        SqlText = "DELETE FROM " & sBancoDados_OwnerPadrao & ".USUARIO_GRID_CONFIG U" & _
                  " WHERE U.CD_USUARIO = " & QuotedStr(sAcesso_UsuarioLogado) & _
                    " AND U.NO_TELA = " & QuotedStr(sNomeTela) & _
                    " AND U.NO_GRID = " & QuotedStr(oGrid.Name)
        If Not DBExecutar(SqlText) Then GoTo Erro

        For iCont = 0 To oGrid.DisplayLayout.Bands(0).Columns.Count - 1
            SqlText = DBMontar_Insert("USUARIO_GRID_CONFIG", TipoCampoFixo.Nenhum, "CD_USUARIO ", ":CD_USUARIO", _
                                                                                   "NO_TELA", ":NO_TELA", _
                                                                                   "NO_GRID", ":NO_GRID", _
                                                                                   "CD_COLUNA", ":CD_COLUNA", _
                                                                                   "IC_ATIVO", ":IC_ATIVO", _
                                                                                   "ic_cabecalho_fixo", ":ic_cabecalho_fixo", _
                                                                                   "QT_TAMANHO", ":QT_TAMANHO", _
                                                                                   "NR_ORDEM", ":NR_ORDEM")

            Parametro(0) = DBParametro_Montar("CD_USUARIO", sAcesso_UsuarioLogado)
            Parametro(1) = DBParametro_Montar("NO_TELA", sNomeTela)
            Parametro(2) = DBParametro_Montar("NO_GRID", oGrid.Name)
            Parametro(3) = DBParametro_Montar("CD_COLUNA", iCont)
            Parametro(4) = DBParametro_Montar("IC_ATIVO", IIf(oGrid.DisplayLayout.Bands(0).Columns(iCont).Hidden, "N", "S"))
            Parametro(5) = DBParametro_Montar("ic_cabecalho_fixo", IIf(oGrid.DisplayLayout.Bands(0).Columns(iCont).Header.Fixed, "S", "N"))
            Parametro(6) = DBParametro_Montar("QT_TAMANHO", oGrid.DisplayLayout.Bands(0).Columns(iCont).Width)
            Parametro(7) = DBParametro_Montar("NR_ORDEM", oGrid.DisplayLayout.Bands(0).Columns(iCont).Header.VisiblePosition)

            If Not DBExecutar(SqlText, Parametro) Then GoTo Erro
        Next

        Exit Sub

Erro:
        TratarErro(, , "MOD_Grid.objGrid_Gravar_Configuracao")
    End Sub

    Public Sub objGrid_Carrega_Configuracao(ByVal oGrid_Control As Control, ByVal sNomeTela As String)
        Dim iCont As Integer
        Dim SqlText As String
        Dim oGrid As UltraGrid
        Dim oData As DataTable
        Dim CdColuna As Integer

        On Error GoTo Erro

        oGrid = oGrid_Control

        SqlText = "SELECT CD_COLUNA, QT_TAMANHO, IC_ATIVO, NR_ORDEM, NVL(IC_CABECALHO_FIXO,'N') AS IC_CABECALHO_FIXO FROM " & sBancoDados_OwnerPadrao & ".USUARIO_GRID_CONFIG U "
        SqlText = SqlText & "WHERE U.CD_USUARIO = " & QuotedStr(sAcesso_UsuarioLogado)
        SqlText = SqlText & "AND U.NO_TELA = " & QuotedStr(sNomeTela)
        SqlText = SqlText & "AND U.NO_GRID = " & QuotedStr(oGrid.Name)

        oData = DBQuery(SqlText)

        For iCont = 0 To oData.Rows.Count - 1
            CdColuna = oData.Rows(iCont).Item("CD_COLUNA")

            With oGrid.DisplayLayout.Bands(0).Columns(CdColuna)
                .Width = oData.Rows(iCont).Item("QT_TAMANHO")
                .Hidden = IIf(oData.Rows(iCont).Item("IC_ATIVO") = "S", False, True)
                .Header.VisiblePosition = oData.Rows(iCont).Item("NR_ORDEM")
                .Header.Fixed = IIf(oData.Rows(iCont).Item("IC_CABECALHO_FIXO") = "N", False, True)
            End With
        Next

        Exit Sub

Erro:
        'TratarErro(,, "MOD_Grid.objGrid_Carrega_Configuracao")
    End Sub

    Public Sub objGrid_Linha_Limpar(ByVal oRow As UltraWinGrid.UltraGridRow)
        Dim iCont As Integer

        For iCont = 0 To oRow.Cells.Count - 1
            oRow.Cells(iCont).Value = System.DBNull.Value
        Next
    End Sub

    Public Sub objGrid_Band_Formatar(ByVal oBand As UltraGridBand, _
                                     Optional ByVal CelulaClique As CellClickAction = CellClickAction.CellSelect, _
                                     Optional ByVal oAutoAdicionarLinha As AllowAddNew = AllowAddNew.Default, _
                                     Optional ByVal PodeAtualizar As DefaultableBoolean = DefaultableBoolean.Default, _
                                     Optional ByVal PodeDeletar As DefaultableBoolean = DefaultableBoolean.Default, _
                                     Optional ByVal TipoFiltroGrid As Infragistics.Win.UltraWinGrid.FilterUIType = FilterUIType.FilterRow, _
                                     Optional ByVal TipoFiltroBand As Infragistics.Win.UltraWinGrid.FilterUIType = FilterUIType.HeaderIcons, _
                                     Optional ByVal TipoSelecaoLinha As Infragistics.Win.UltraWinGrid.SelectType = SelectType.Default)
        With oBand.Override
            .AllowUpdate = PodeAtualizar
            .AllowDelete = PodeDeletar
            .ButtonStyle = UIElementButtonStyle.VisualStudio2005Button
            .AllowAddNew = oAutoAdicionarLinha
            .RowSelectors = DefaultableBoolean.True
            .RowSelectorStyle = HeaderStyle.WindowsXPCommand
            .HeaderClickAction = HeaderClickAction.SortMulti
            .HeaderStyle = HeaderStyle.WindowsXPCommand
            .MaxSelectedCells = 1
            .MaxSelectedRows = 1
            .CellClickAction = CelulaClique
            .SelectTypeRow = TipoSelecaoLinha
            .MaxSelectedRows = 100

            .FilterRowPrompt = ""

            If oBand.Index = 0 Then
                .FilterUIType = TipoFiltroGrid
            Else
                .FilterUIType = TipoFiltroBand
            End If

            .SpecialRowSeparator = SpecialRowSeparator.TemplateAddRow
            .SpecialRowSeparatorAppearance.BackColor = SystemColors.Control

            If oAutoAdicionarLinha = AllowAddNew.FixedAddRowOnTop Then
                .AddRowAppearance.BackColor = Color.LightYellow
                .AddRowAppearance.ForeColor = Color.Blue
                .SpecialRowSeparator = SpecialRowSeparator.TemplateAddRow
                .TemplateAddRowAppearance.BackColor = Color.FromArgb(245, 250, 255)
                .TemplateAddRowAppearance.ForeColor = SystemColors.GrayText
                .TemplateAddRowPrompt = "Clique aqui para adicionar um novo registro..."
                .TemplateAddRowPromptAppearance.FontData.Bold = DefaultableBoolean.True
                .TemplateAddRowPromptAppearance.ForeColor = Color.Maroon
            End If
        End With
    End Sub

    Public Sub objGrid_Coluna_Limpar(ByVal oGrid As UltraGrid)
        Dim iCont As Integer

        With oGrid.DisplayLayout.Bands(0).Columns
            For iCont = 0 To .Count
                .Remove(0)
            Next
        End With
    End Sub

    Public Function objGrid_LinhaSelecionada(ByRef oGrid As UltraGrid, Optional ByVal IndexBand As Integer = 0) As Integer
        If oGrid.DisplayLayout.ActiveRow Is Nothing Then
            Return -1
        Else
            If oGrid.DisplayLayout.ActiveRow.IsFilterRow Then
                Return -1
            Else
                If oGrid.DisplayLayout.ActiveRow.Band.Index = IndexBand Then
                    Return oGrid.DisplayLayout.ActiveRow.Index
                Else
                    Return -1
                End If
            End If
        End If
    End Function

    Public Function objGrid_Coluna_Add(ByVal oGrid As UltraGrid, _
                                       ByVal Titulo As String, _
                                       ByVal TamanhoColuna As Integer, _
                                       Optional ByVal ColID As Integer = -1, _
                                       Optional ByVal bEditar As Boolean = False, _
                                       Optional ByVal Tipo As ColumnStyle = ColumnStyle.Default, _
                                       Optional ByVal Lista As ValueList = Nothing, _
                                       Optional ByVal Formato As String = "", _
                                       Optional ByVal Wrap As DefaultableBoolean = DefaultableBoolean.Default, _
                                       Optional ByVal FormataData As Boolean = True, _
                                       Optional ByVal QuantidadeCaracter As Integer = 0, _
                                       Optional ByVal MaiusculaMinuscula As CharacterCasing = CharacterCasing.Normal, _
                                       Optional ByVal MascaraValor As String = "", _
                                       Optional ByVal Alinhamento As HAlign = HAlign.Default, _
                                       Optional ByVal Hidden As Boolean = False, _
                                       Optional ByVal Formula As String = "", _
                                       Optional ByVal ValorMinimo As Object = Nothing, _
                                       Optional ByVal ValorMaximo As Object = Nothing, _
                                       Optional ByVal AdicionarDepoisDe As Integer = 0, _
                                       Optional ByVal ToolTip As String = "", _
                                       Optional ByVal ExibicaoBotao As UltraWinGrid.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.OnRowActivate) As UltraGridColumn
        Dim oColuna As UltraGridColumn = Nothing
        Dim bNovaColuna As Boolean
        Dim bSemOrigemDados As Boolean = False

        With oGrid.DisplayLayout
            If ColID = -1 Then
                If oGrid.DataSource Is Nothing Then
                    bSemOrigemDados = True
                Else
                    Select Case TypeName(oGrid.DataSource)
                        Case "UltraDataSource"
                            '>>> Com objeto de data source
                            Dim oDS As UltraWinDataSource.UltraDataSource

                            oDS = oGrid.DataSource

                            oColuna = .Bands(0).Columns(oDS.Band.Columns.Add(objGrid_DataColunmKey(Titulo, oDS.Band)).Index)

                            If FormataData Then
                                Select Case Formato
                                    Case cnt_Formato_Data, cnt_Formato_DataHoraCurta, cnt_Formato_DataHora, cnt_Formato_Hora
                                        oDS.Band.Columns(oDS.Band.Columns.Count - 1).DataType = GetType(System.DateTime)
                                    Case cnt_Formato_Valor, cnt_Formato_Valor_US, cnt_Formato_Kilos, _
                                         cnt_Formato_NumeroInteiro, cnt_Formato_Porcentagem, cnt_Formato_Fracao_Simples, _
                                         cnt_Formato_Fracao
                                        oDS.Band.Columns(oDS.Band.Columns.Count - 1).DataType = GetType(System.Decimal)
                                    Case cnt_Formato_Imagem
                                        oDS.Band.Columns(oDS.Band.Columns.Count - 1).DataType = GetType(System.Object)
                                        Formato = ""
                                End Select
                            End If
                        Case "DataSet"
                            Dim oDS As DataSet

                            oDS = oGrid.DataSource
                            Dim dc As DataColumn

                            Select Case Formato
                                Case cnt_Formato_Data, cnt_Formato_DataHoraCurta, cnt_Formato_DataHora, cnt_Formato_Hora
                                    dc = New DataColumn(Titulo, System.Type.GetType("System.DateTime"))
                                Case cnt_Formato_Valor, cnt_Formato_Valor_US, cnt_Formato_Kilos, _
                                     cnt_Formato_NumeroInteiro, cnt_Formato_Porcentagem, cnt_Formato_Fracao_Simples, _
                                     cnt_Formato_Fracao
                                    dc = New DataColumn(Titulo, System.Type.GetType("System.Decimal"))
                                    dc.DefaultValue = 0
                                Case cnt_Formato_Imagem
                                    dc = New DataColumn(Titulo, System.Type.GetType("System.Object"))
                                    Formato = ""
                                Case Else
                                    dc = New DataColumn(Titulo)

                            End Select
                            oDS.Tables(0).Columns.Add(dc)
                            oDS.AcceptChanges()

                            oColuna = .Bands(0).Columns(.Bands(0).Columns.Count - 1)

                           
                        Case Else
                            bSemOrigemDados = True
                    End Select
                End If

                If bSemOrigemDados Then
                    '>>> Sem objeto de data source
                    bNovaColuna = True

                    If .Bands(0).Columns.Count = 1 Then
                        If .Bands(0).Columns(0).IsBound And .Tag <> 1 Then
                            oColuna = .Bands(0).Columns(0)
                            bNovaColuna = False
                            .Tag = 1
                        End If
                    End If

                    If bNovaColuna Then
                        oColuna = .Bands(0).Columns.Add
                    End If
                End If
            Else
                oColuna = .Bands(0).Columns(ColID)
            End If
        End With
        If TamanhoColuna = 0 Then
            oColuna.ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
        End If
        If AdicionarDepoisDe > 0 Then
            oColuna.Header.VisiblePosition = oColuna.Band.Columns(AdicionarDepoisDe).Header.VisiblePosition + 1
        End If

        objGrid_Coluna_Formatar(oGrid, oColuna, Titulo, TamanhoColuna, bEditar, Tipo, Lista, Formato, Wrap, QuantidadeCaracter, _
                                MaiusculaMinuscula, MascaraValor, Alinhamento, Hidden, Formula, ValorMinimo, ValorMaximo, ToolTip, _
                                ExibicaoBotao)

        Return oColuna
    End Function

    Public Sub objGrid_Coluna_Formatar(ByVal oGrid As UltraGrid, _
                                       ByVal oColuna As UltraGridColumn, _
                                       ByVal Titulo As String, _
                                       ByVal TamanhoColuna As Integer, _
                                       Optional ByVal bEditar As Boolean = False, _
                                       Optional ByVal Tipo As ColumnStyle = ColumnStyle.Default, _
                                       Optional ByVal Lista As ValueList = Nothing, _
                                       Optional ByVal Formato As String = "", _
                                       Optional ByVal Wrap As DefaultableBoolean = DefaultableBoolean.Default, _
                                       Optional ByVal QuantidadeCaracter As Integer = 0, _
                                       Optional ByVal MaiusculaMinuscula As CharacterCasing = CharacterCasing.Normal, _
                                       Optional ByVal MascaraValor As String = "", _
                                       Optional ByVal Alinhamento As HAlign = HAlign.Default, _
                                       Optional ByVal Hidden As Boolean = False, _
                                       Optional ByVal Formula As String = "", _
                                       Optional ByVal ValorMinimo As Object = Nothing, _
                                       Optional ByVal ValorMaximo As Object = Nothing, _
                                       Optional ByVal ToolTip As String = "", _
                                       Optional ByVal ExibicaoBotao As UltraWinGrid.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always)
        Dim bSemOrigemDados As Boolean = False

        With oColuna
            .CellMultiLine = Wrap
            .CharacterCasing = MaiusculaMinuscula

            If oColuna.IsVisibleInLayout Then
                .Hidden = Hidden
            End If
            
            If ToolTip <> "" Then
                .Header.ToolTipText = ToolTip
            End If

            If Trim(MascaraValor) <> "" Then
                .MaskInput = MascaraValor
            End If

            If bEditar Then
                .CellClickAction = CellClickAction.Edit
            Else
                If oGrid.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect Or _
                   oGrid.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.CellSelect Then
                    .CellActivation = Activation.NoEdit
                End If
            End If

            If Not Titulo Is Nothing Then
                .Header.Caption = Titulo
            End If

            .Style = Tipo
            .ButtonDisplayStyle = ExibicaoBotao

            If Trim(Formato) <> "" Then
                .Format = Formato

                Select Case Formato
                    Case cnt_Formato_Valor, cnt_Formato_Valor_US, cnt_Formato_Kilos, _
                         cnt_Formato_NumeroInteiro, cnt_Formato_Porcentagem, cnt_Formato_Fracao_Simples, _
                         cnt_Formato_Fracao
                        oColuna.CellAppearance.TextHAlign = HAlign.Right
                End Select
            End If

            If Alinhamento <> HAlign.Default Then
                oColuna.CellAppearance.TextHAlign = Alinhamento
            End If

            If TamanhoColuna = 0 Then
                .Hidden = True
            Else
                .Width = TamanhoColuna
            End If

            If Not Lista Is Nothing Then
                oColuna.ValueList = Lista
            End If

            If QuantidadeCaracter > 0 Then
                .MaxLength = QuantidadeCaracter
            End If

            If Trim(Formula) <> "" Then
                .Formula = Formula
            End If

            If Not ValorMinimo Is Nothing Then
                .MinValue = ValorMinimo
            End If
            If Not ValorMaximo Is Nothing Then
                .MaxValue = ValorMaximo
            End If
        End With
    End Sub

    Public Function objGrid_CheckCol_Valor(ByVal oGrid As UltraGrid, ByVal Coluna As Integer, ByVal Linha As Integer) As String
        If CampoNulo(oGrid.Rows(Linha).Cells(Coluna).Value) Then
            Return "N"
        Else
            If CStr(oGrid.Rows(Linha).Cells(Coluna).Value) = "1" Or CStr(oGrid.Rows(Linha).Cells(Coluna).Value) = "True" Then
                Return "S"
            Else
                Return "N"
            End If
        End If
    End Function

    Public Function objGrid_CheckBox_Selecionado(ByVal oGrid As UltraGrid, _
                                                 ByVal Coluna As Integer, _
                                                 ByVal Linha As Integer) As Boolean
        If Coluna >= 0 And Linha >= 0 Then
            If CampoNulo(oGrid.Rows(Linha).Cells(Coluna).Value) Then
                Return False
            Else
                If CStr(oGrid.Rows(Linha).Cells(Coluna).Value) = "1" Or CStr(oGrid.Rows(Linha).Cells(Coluna).Value) = "True" Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If
    End Function

    Public Sub objGrid_CheckBox_DesmarcarTodos(ByVal oGrid As UltraGrid, _
                                               ByVal Coluna As Integer)
        Dim iCont As Integer

        For iCont = 0 To oGrid.Rows.Count - 1
            oGrid.Rows(iCont).Cells(Coluna).Value = False
            oGrid.Rows(iCont).Update()
        Next
    End Sub

    Public Function objGrid_CheckBox_QtdeSelecionado(ByVal oGrid As UltraGrid, _
                                                     ByVal Coluna As Integer) As Integer
        Dim Acumula As Integer = 0
        Dim iCont As Integer = 0

        For iCont = 0 To oGrid.Rows.Count - 1
            If objGrid_CheckBox_Selecionado(oGrid, Coluna, iCont) Then
                Acumula = Acumula + 1
            End If
        Next

        Return Acumula
    End Function

    Public Sub objGrid_SetupPrint(ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs, _
                                  ByVal Titulo As String, _
                                  ByVal Linhas As Integer, _
                                  Optional ByVal TamanhoTitulo As Integer = 20)
        e.PrintLayout.BorderStyle = UIElementBorderStyle.None

        With e.PrintLayout
            .Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.None
        End With

        With e.PrintDocument
            .PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.AllPages
            .DefaultPageSettings.Landscape = True
        End With

        With e.DefaultLogicalPageLayoutInfo
            .FitWidthToPages = Linhas / 50
            .PageFooterBorderStyle = UIElementBorderStyle.None
            .PageHeader = Titulo
            .PageHeaderHeight = 40
            .PageHeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            .PageHeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .PageHeaderAppearance.FontData.SizeInPoints = TamanhoTitulo
        End With
    End Sub

    Public Function objGrid_Posicionar(ByVal oGrid As UltraGrid, _
                                       ByVal Coluna() As Integer, _
                                       ByVal Valor() As Object) As Boolean
        Dim iLinha As Integer
        Dim iCont As Integer
        Dim bAchou As Boolean

        For iLinha = 0 To oGrid.Rows.Count - 1
            With oGrid.Rows(iCont)
                For iCont = Coluna.GetLowerBound(0) To Coluna.GetUpperBound(0)
                    bAchou = True

                    If .Cells(Coluna(iCont)).Value <> Valor(iCont) Then
                        bAchou = False
                        Exit For
                    End If
                Next

                If bAchou Then
                    oGrid.Rows(iCont).Activated = True
                    Exit For
                End If
            End With
        Next

        Return bAchou
    End Function

    Public Function objGrid_Carregar(ByVal oGrid As UltraGrid, _
                                     ByVal SqlText As String, _
                                     ByVal IDColuna() As Integer, _
                                     Optional ByVal ExibirFilme As Boolean = True, _
                                     Optional ByVal AjustarTamanhoCelula As Boolean = False, _
                                     Optional ByVal AdicionarLinhas As Boolean = False, _
                                     Optional ByVal oDataPreenchido As DataTable = Nothing) As Boolean
        Dim oDS As New UltraWinDataSource.UltraDataSource
        Dim oData As New System.Data.DataTable
        Dim oRow As UltraWinDataSource.UltraDataRow = Nothing
        Dim iCont As Integer
        Dim iColuna As Integer
        Dim Array() As System.Data.DataRow = Nothing

        'Abro o filme da busca
        If ExibirFilme Then
            AVI_Carregar(oGrid.Parent)
        End If

        ''Limpa filtros
        'Dim band As Infragistics.Win.UltraWinGrid.UltraGridBand
        'For Each band In oGrid.DisplayLayout.Bands
        '    band.ColumnFilters.ClearAllFilters()
        'Next

        If Not oDataPreenchido Is Nothing Then
            oData = oDataPreenchido
        Else
            oData = DBQuery(SqlText)
        End If

        If DBContemErro() Then
            oData = Nothing
            Return False
        End If

        oDS = oGrid.DataSource
        If Not oDS Is Nothing And Not AdicionarLinhas Then oDS.Rows.Clear()

        If Not objDataTable_Vazio(oData) Then
            'Verifica o tipo da coluna
            For iColuna = 0 To oData.Columns.Count - 1
                With oData.Columns(iColuna)
                    If .DataType Is System.Type.GetType("System.Double") Or .DataType Is System.Type.GetType("System.Decimal") Or _
                       .DataType Is System.Type.GetType("System.Int16") Or .DataType Is System.Type.GetType("System.Int32") Or _
                       .DataType Is System.Type.GetType("System.Int64") Or .DataType Is System.Type.GetType("System.Single") Then
                        oDS.Band.Columns(IDColuna(iColuna)).DataType = .DataType
                    ElseIf .DataType Is System.Type.GetType("System.DateTime") Then
                        oDS.Band.Columns(IDColuna(iColuna)).DataType = .DataType
                    End If
                End With
            Next

            For iCont = 0 To oData.Rows.Count - 1
                oRow = oDS.Rows.Add()

                For iColuna = 0 To oData.Columns.Count - 1
                    If Not objDataTable_CampoVazio(oData.Rows(iCont).Item(iColuna)) Then
                        If oGrid.DisplayLayout.Bands(0).Columns(IDColuna(iColuna)).Format = cnt_Formato_Data Then
                            oRow.SetCellValue(IDColuna(iColuna), Format(oData.Rows(iCont).Item(iColuna), cnt_Formato_Data))
                        Else
                            oRow.SetCellValue(IDColuna(iColuna), oData.Rows(iCont).Item(iColuna))
                        End If
                    End If
                Next
            Next
        End If

        'Fazer a auto formatação
        If AjustarTamanhoCelula Then
            For iCont = 0 To oGrid.Rows.Count - 1
                oGrid.Rows(iCont).PerformAutoSize()
            Next
        End If

        oData = Nothing

        'Fecho o filme da busca
        If ExibirFilme Then
            AVI_Fechar(oGrid.Parent)
        End If

        Return True

Erro:
        If ExibirFilme Then
            AVI_Fechar(oGrid.Parent)
        End If
    End Function

    Public Function objGrid_Carregar(ByVal oGrid As UltraGrid, _
                                     ByVal SqlText As String, _
                                     Optional ByVal CopiarTituloColuna As Boolean = False, _
                                     Optional ByVal AjustarTamanhoCelula As Boolean = False) As Boolean
        Dim oData As New System.Data.DataTable
        Dim iCont As Integer = 0

        oData = DBQuery(SqlText)

        If DBContemErro() Then
            oData = Nothing
            Return False
        End If

        oGrid.DataSource = oData
        oGrid.DataBind()

        If AjustarTamanhoCelula Then
            For iCont = 0 To oGrid.Rows.Count - 1
                oGrid.Rows(iCont).PerformAutoSize()
            Next
        End If

        Return True
    End Function

    Public Sub objGrid_ExportarExcell(ByVal oGrid As UltraGrid, _
                                      ByVal Nome As String, _
                                      Optional ByVal oBotao As Infragistics.Win.Misc.UltraButton = Nothing, _
                                      Optional ByRef oExport As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter = Nothing, _
                                      Optional ByVal sArquivoDestino As String = "")
        Dim sArquivo As String
        Dim ps As New ProcessStartInfo
        Dim bEnviarEMail As Boolean = False
        Dim ExportPath As String
        Dim NomeArquivo As String

        If oExport Is Nothing Then
            oExport = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        End If

        If Trim(sArquivoDestino) = "" Then
            If Not oBotao Is Nothing Then
                If Not oBotao.ContextMenuStrip Is Nothing Then
                    If oBotao.Tag Is Nothing Then
                        oBotao.ContextMenuStrip.Show(oBotao.MousePosition)
                        Exit Sub
                    End If

                    If oBotao.Tag = cnt_ExportarGrid_EnviarEMail Then
                        ExportPath = My.Computer.FileSystem.SpecialDirectories.Temp + "\Exported\"

                        If System.IO.Directory.Exists(ExportPath) = False Then
                            System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\Exported\")
                        End If

                        sArquivo = "Arquivo"

                        frmUserDialogo_Texto.Carregar("Exportação de Relatório", "Informe o nome do arquivo")

                        If frmUserDialogo_Texto.Cancelado Then
                            oBotao.Tag = Nothing
                            Exit Sub
                        Else
                            sArquivo = frmUserDialogo_Texto.Texto
                            NomeArquivo = frmUserDialogo_Texto.Texto
                        End If

                        frmUserDialogo_Texto.Dispose()

                        sArquivo = sArquivo & ".xlsx"

                        sArquivo = ExportPath + sArquivo

                        If Dir(sArquivo) <> "" Then
                            Kill(sArquivo)
                        End If

                        bEnviarEMail = True
                    End If
                End If
            End If

            If Not bEnviarEMail Then
                sArquivo = Arquivo_Dialogo_Salvar("Excell|*.xlsx")
            End If
        Else
            sArquivo = sArquivoDestino
        End If

        If Trim(sArquivo) <> "" Then
            oExport.Export(oGrid, sArquivo, WorkbookFormat.Excel2007)
            oExport.Dispose()

            If bEnviarEMail Then
                EMail_Enviar(cnt_EmailExportacaoRelatorio, _
                             sUsuario_EMail, _
                             "Exportação de Consultas - " & NomeArquivo, "", _
                             False, _
                             cnt_EMail_Servidor_SMTP, _
                             System.Net.Mail.MailPriority.Normal, _
                             New String() {sArquivo})
                Msg_Mensagem("Planilha enviada para o seu e-mail")
            Else
                If Trim(sArquivoDestino) = "" Then
                    If Msg_Perguntar("Deseja abrir o arquivo exportado?") Then
                        ps.UseShellExecute = True
                        ps.FileName = sArquivo
                        Process.Start(ps)
                    End If
                End If
            End If
        End If

        If Not oBotao Is Nothing Then
            If Not oBotao.ContextMenuStrip Is Nothing Then
                If oBotao.Tag = cnt_ExportarGrid_EnviarEMail Or _
                   oBotao.Tag = cnt_ExportarGrid_ExportarComputador Then
                    oBotao.Tag = Nothing
                    oBotao.ContextMenuStrip.Hide()
                End If
            End If
        End If
    End Sub

    Public Function objGrid_Valor(ByRef oGrid As UltraGrid, _
                                  ByVal Coluna As Integer, _
                                  Optional ByVal Linha As Integer = -1, _
                                  Optional ByVal ValorPadrao As Object = Nothing, _
                                  Optional ByVal Tipo As gridTipoValor = gridTipoValor.ValorNaoDefinido, _
                                  Optional ByVal IndexBand As Integer = -1) As Object
        Dim iLinha As Integer
        Dim Valor As Object = Nothing
        Dim oRow As UltraGridRow = Nothing

        If Linha = -1 Then
            If oGrid.DisplayLayout.ActiveRow Is Nothing Then
                iLinha = -1
            Else
                If oGrid.DisplayLayout.ActiveRow.Band.Index = IndexBand Or IndexBand = -1 Then
                    oRow = oGrid.DisplayLayout.ActiveRow
                Else
                    iLinha = -1
                End If
            End If
        Else
            iLinha = Linha
            oRow = oGrid.Rows(iLinha)
        End If

        If Not oRow Is Nothing Then
            IndexBand = oRow.Band.Index
        End If

        If Coluna = -1 Or iLinha = -1 Then
            Valor = Nothing
            GoTo Sair
        ElseIf iLinha > -1 And (iLinha <= oGrid.Rows.Count - 1 Or IndexBand > 0) And _
               Coluna <= oGrid.DisplayLayout.Bands(IndexBand).Columns.Count - 1 Then
            Valor = oRow.Cells(Coluna).Value

            GoTo Sair
        Else
            Err.Raise(-7000, "Celula informada não existe no grid ou linha não existe")
        End If

        Return Nothing

        Exit Function

Sair:
        If CampoNulo(Valor) And Not ValorPadrao Is Nothing Then
            Valor = ValorPadrao
        End If

        Select Case Tipo
            Case gridTipoValor.ValorTexto
                Return Valor
            Case Else
                If IsNumeric(Valor) Then
                    Return ConvValorFormatoAmericano(Valor)
                Else
                    Return Valor
                End If
        End Select
    End Function

    Public Function objGrid_Valor_SN(ByRef oGrid As UltraGrid, ByVal Coluna As Integer, _
                                     Optional ByVal Linha As Integer = -1) As Boolean
        Dim iLinha As Integer
        Dim Valor As Boolean

        If Linha = -1 Then
            If oGrid.DisplayLayout.ActiveRow Is Nothing Then
                iLinha = -1
            Else
                iLinha = oGrid.DisplayLayout.ActiveRow.Index
            End If
        Else
            iLinha = Linha
        End If

        If Coluna = -1 Then
            Valor = False
        ElseIf iLinha > -1 And iLinha <= oGrid.Rows.Count - 1 And Coluna <= oGrid.DisplayLayout.Bands(0).Columns.Count - 1 Then
            Valor = (oGrid.Rows(iLinha).Cells(Coluna).Value = "S" Or UCase(oGrid.Rows(iLinha).Cells(Coluna).Value) = "SIM")
        Else
            Err.Raise(-7000, "Celula informada não existe no grid ou linha não existe")
        End If

        Return Valor
    End Function

    Public Sub objGrid_Linha_Add(ByRef oGrid As UltraGrid, _
                                 ByVal Coluna_Valor() As Object)
        Dim oDS As UltraWinDataSource.UltraDataSource
        Dim iCont As Integer

        oDS = oGrid.DataSource

        If Not oDS Is Nothing Then
            Dim oRow As UltraWinDataSource.UltraDataRow

            oRow = oDS.Rows.Add()

            For iCont = 0 To UBound(Coluna_Valor) Step 2
                If oRow.Band.Columns(Coluna_Valor(iCont)).DataType Is System.Type.GetType("System.Double") _
                 Or oRow.Band.Columns(Coluna_Valor(iCont)).DataType Is System.Type.GetType("System.Decimal") _
                 Or oRow.Band.Columns(Coluna_Valor(iCont)).DataType Is System.Type.GetType("System.Int16") _
                 Or oRow.Band.Columns(Coluna_Valor(iCont)).DataType Is System.Type.GetType("System.Int32") _
                 Or oRow.Band.Columns(Coluna_Valor(iCont)).DataType Is System.Type.GetType("System.Int64") _
                 Or oRow.Band.Columns(Coluna_Valor(iCont)).DataType Is System.Type.GetType("System.Single") Then
                    oRow.SetCellValue(Coluna_Valor(iCont), Val(Coluna_Valor(iCont + 1)))
                Else
                    oRow.SetCellValue(Coluna_Valor(iCont), Coluna_Valor(iCont + 1))
                End If
            Next
        End If
    End Sub

    Public Sub objGrid_AlterarValor(ByRef oGrid As UltraGrid, ByVal Coluna As Integer, _
                                    ByVal Linha As Integer, ByVal Valor As Object)
        Dim oDS As UltraWinDataSource.UltraDataSource
        Dim iLinha As Integer

        If Linha = -1 Then
            If oGrid.DisplayLayout.ActiveRow Is Nothing Then
                iLinha = -1
            Else
                iLinha = oGrid.DisplayLayout.ActiveRow.Index
            End If
        Else
            iLinha = Linha
        End If

        oDS = oGrid.DataSource

        If Not oDS Is Nothing Then
            If oDS.Rows(iLinha).Band.Columns(Coluna).DataType Is System.Type.GetType("System.Double") _
             Or oDS.Rows(iLinha).Band.Columns(Coluna).DataType Is System.Type.GetType("System.Decimal") _
             Or oDS.Rows(iLinha).Band.Columns(Coluna).DataType Is System.Type.GetType("System.Int16") _
             Or oDS.Rows(iLinha).Band.Columns(Coluna).DataType Is System.Type.GetType("System.Int32") _
             Or oDS.Rows(iLinha).Band.Columns(Coluna).DataType Is System.Type.GetType("System.Int64") _
             Or oDS.Rows(iLinha).Band.Columns(Coluna).DataType Is System.Type.GetType("System.Single") Then
                oDS.Rows(iLinha).SetCellValue(Coluna, Val(Valor))
            Else
                oDS.Rows(iLinha).SetCellValue(Coluna, Valor)
            End If
        End If
    End Sub

    Public Function objGrid_Coluna_ProcurarValor(ByRef oGrid As UltraGrid, _
                                                 ByVal aValor() As Object, _
                                                 Optional ByVal ExcetoLinha As Integer = -1) As Integer
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim bAchou As Boolean
        Dim Valor As Object

        For iCont_01 = 0 To oGrid.Rows.Count - 1
            If iCont_01 <> ExcetoLinha Or ExcetoLinha = -1 Then
                For iCont_02 = 0 To UBound(aValor) Step 2
                    bAchou = False

                    With oGrid.Rows(iCont_01).Cells(aValor(iCont_02))
                        Valor = aValor(iCont_02 + 1)

                        If IsDate(Valor) Or IsNumeric(Valor) Then
                            If Trim(.Value) = Valor Then
                                bAchou = True
                            End If
                        Else
                            If UCase(Trim(NVL(.Value, Nothing))) = UCase(Trim(NVL(Valor, ""))) Then
                                bAchou = True
                            End If
                        End If
                    End With

                    If Not bAchou Then Exit For
                Next

                If bAchou Then Exit For
            End If
        Next

Sair:
        Return IIf(bAchou, iCont_01, -1)
    End Function

    Public Sub objGrid_Linha_Remover(ByRef oGrid As UltraGrid, _
                                     Optional ByVal Linha As Integer = -1)
        Dim iLinha As Integer
        Dim oDS As UltraWinDataSource.UltraDataSource

        If Linha = -1 Then
            If oGrid.DisplayLayout.ActiveRow Is Nothing Then
                iLinha = -1
            Else
                iLinha = oGrid.DisplayLayout.ActiveRow.Index
            End If
        Else
            iLinha = Linha
        End If

        oDS = oGrid.DataSource
        oDS.Rows.Remove(oDS.Rows(iLinha))
    End Sub

    Public Sub objGrid_ExibirTotal(ByVal oGrid As UltraGrid, _
                                   ByVal ParamArray ColunasTotal() As Integer)
        objGrid_ExibirCalculado(oGrid, SummaryType.Sum, False, ColunasTotal)
    End Sub

    Public Sub objGrid_ExibirTotal(ByVal oGrid As UltraGrid, _
                                   ByVal AdicionarMesmoQueExista As Boolean, _
                                   ByVal ParamArray ColunasTotal() As Integer)
        objGrid_ExibirCalculado(oGrid, SummaryType.Sum, AdicionarMesmoQueExista, ColunasTotal)
    End Sub

    Public Sub objGrid_ExibirMedia(ByVal oGrid As UltraGrid, _
                                   ByVal AdicionarMesmoQueExista As Boolean, _
                                   ByVal ParamArray ColunasTotal() As Integer)
        objGrid_ExibirCalculado(oGrid, SummaryType.Average, AdicionarMesmoQueExista, ColunasTotal)
    End Sub

    Public Sub objGrid_ExibirCalculado(ByVal oGrid As UltraGrid, _
                                       ByVal TipoSumario As Infragistics.Win.UltraWinGrid.SummaryType, _
                                       ByVal AdicionarMesmoQueExista As Boolean, _
                                       ByVal ParamArray ColunasTotal() As Integer)
        Dim iCont As Integer
        Dim oSumario As Infragistics.Win.UltraWinGrid.SummarySettings
        Dim ColFormat As String
        Dim newSummaryDisplayArea As SummaryDisplayAreas

        newSummaryDisplayArea = SummaryDisplayAreas.Bottom Or SummaryDisplayAreas.InGroupByRows

        With oGrid
            With .DisplayLayout
                With .Bands(0)
                    If .Summaries.Count = 0 Or AdicionarMesmoQueExista Then
                        For iCont = LBound(ColunasTotal) To UBound(ColunasTotal)
                            Select Case TipoSumario
                                Case SummaryType.Formula
                                    oSumario = .Summaries.Add(.Columns(ColunasTotal(iCont)).Header.Caption & Trim(iCont), _
                                                              SummaryType.Formula, _
                                                              .Columns(ColunasTotal(iCont)), _
                                                              SummaryPosition.UseSummaryPositionColumn)
                                    oSumario.Formula = ""
                                    With oSumario
                                        .DisplayFormat = "{0:" + ColFormat + "}"
                                        .Appearance.TextHAlign = HAlign.Right
                                        .SummaryDisplayArea = newSummaryDisplayArea
                                    End With
                                Case Else
                                    oSumario = .Summaries.Add(.Columns(ColunasTotal(iCont)).Header.Caption & Trim(iCont), _
                                                               TipoSumario, _
                                                              .Columns(ColunasTotal(iCont)), _
                                                              SummaryPosition.UseSummaryPositionColumn)

                                    ColFormat = .Columns(ColunasTotal(iCont)).Format

                                    If ColFormat = Nothing Then
                                        ColFormat = "###,###,##0.00"
                                    End If

                                    With oSumario
                                        .DisplayFormat = "{0:" + ColFormat + "}"
                                        .Appearance.TextHAlign = HAlign.Right
                                        .SummaryDisplayArea = newSummaryDisplayArea
                                    End With
                            End Select
                        Next
                    End If

                    Select Case TipoSumario
                        Case SummaryType.Average
                            .SummaryFooterCaption = "Média"
                        Case SummaryType.Sum
                            .SummaryFooterCaption = "Total"
                    End Select

                    .Override.SummaryDisplayArea = SummaryDisplayAreas.Bottom
                    .Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow
                End With
            End With
        End With
    End Sub

    Public Sub objGrid_ExibirCalculadoFormula(ByVal oGrid As UltraGrid, _
                                              ByVal AdicionarMesmoQueExista As Boolean, _
                                              ByVal Formula As String, _
                                              ByVal FooterCaption As String, _
                                              ByVal ColunaTotal As Integer, _
                                              Optional ByVal Formato As String = "")
        Dim iCont As Integer
        Dim oSumario As Infragistics.Win.UltraWinGrid.SummarySettings
        Dim ColFormat As String
        Dim newSummaryDisplayArea As SummaryDisplayAreas

        newSummaryDisplayArea = SummaryDisplayAreas.Bottom Or SummaryDisplayAreas.InGroupByRows

        With oGrid
            With .DisplayLayout
                With .Bands(0)
                    If .Summaries.Count = 0 Or AdicionarMesmoQueExista Then
                        oSumario = .Summaries.Add(.Columns(ColunaTotal).Header.Caption & Trim(iCont), _
                                                  SummaryType.Formula, _
                                                  .Columns(ColunaTotal), _
                                                  SummaryPosition.UseSummaryPositionColumn)

                        If Trim(Formato) = "" Then
                            ColFormat = .Columns(ColunaTotal).Format
                        Else
                            ColFormat = Formato
                        End If

                        oSumario.Formula = Formula
                        With oSumario
                            .DisplayFormat = "{0:" + ColFormat + "}"
                            .Appearance.TextHAlign = HAlign.Right
                            .SummaryDisplayArea = newSummaryDisplayArea
                        End With
                    End If

                    .SummaryFooterCaption = FooterCaption

                    .Override.SummaryDisplayArea = SummaryDisplayAreas.Bottom
                    .Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow
                End With
            End With
        End With
    End Sub

    Public Function objGridBand_Index(ByVal oRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As Integer
        If oRow.ParentRow Is Nothing Then
            Return -1
        Else
            Return oRow.ParentRow.Band.Index
        End If
    End Function

    Public Sub objGrid_Coluna_AddOption(ByRef oGrid As UltraGrid, _
                                        ByVal oDS As UltraWinDataSource.UltraDataSource, _
                                        ByVal Coluna As Integer, _
                                        ByVal Valores() As Object)
        Dim EditorSettings As DefaultEditorOwnerSettings = Nothing
        Dim ValueList As ValueList = Nothing
        Dim Editor As EmbeddableEditorBase
        Dim iCont As Integer
        Dim Valor As Object

        oDS.Band.Columns(Coluna).DataType = GetType(Object)

        EditorSettings = New DefaultEditorOwnerSettings()
        EditorSettings.DataType = GetType(Object)
        EditorSettings.ButtonStyle = UIElementButtonStyle.Flat

        ValueList = New ValueList()

        For iCont = LBound(Valores) To UBound(Valores) Step 2
            ValueList.ValueListItems.Add(Valores(iCont + 1), Valores(iCont))
        Next

        EditorSettings.ValueList = ValueList
        Editor = New OptionSetEditor(New DefaultEditorOwner(EditorSettings))

        For iCont = 0 To oGrid.Rows.Count - 1
            Valor = oGrid.Rows(iCont).Cells(Coluna).Value
            oGrid.Rows(iCont).Cells(Coluna).Editor = Editor
            oGrid.Rows(iCont).Cells(Coluna).Value = Valor
        Next
    End Sub

    Public Function objGrid_TipoLinha(ByRef oGrid As UltraGrid) As gridTipoLinha
        If oGrid.ActiveRow.IsAddRow Then
            Return gridTipoLinha.Linha_Filtro
        ElseIf oGrid.ActiveRow.IsFilterRow Then
            Return gridTipoLinha.Linha_Filtro
        ElseIf oGrid.ActiveRow.IsDataRow Then
            Return gridTipoLinha.Linha_Dados
        Else
            Return gridTipoLinha.Linha_Dados
        End If
    End Function

    Public Function objGrid_CalcularTotalColuna(ByVal oGrid As UltraGrid, ByVal Coluna As Integer) As Double
        Dim iCont As Integer
        Dim Quantidade As Double = 0

        For iCont = 0 To oGrid.Rows.Count - 1
            Quantidade = Quantidade + NVL(oGrid.Rows(iCont).Cells(Coluna).Value, 0)
        Next

        Return Math.Round(Quantidade, 4)
    End Function

    Public Function objGrid_ListarSelecionados(ByVal oGrid As UltraGrid, _
                                               ByVal Separador As Object, _
                                               ByVal Colunas() As Object, _
                                               Optional ByVal Where() As Object = Nothing, _
                                               Optional ByVal Where_CheckColuna() As Integer = Nothing) As String
        Dim sLista As String = ""
        Dim sAux As String = ""
        Dim iLinha As Integer
        Dim iWhere As Integer
        Dim iCont As Integer
        Dim bValido As Boolean

        For iLinha = 0 To oGrid.Rows.Count - 1
            sAux = ""

            With oGrid.Rows(iLinha)
                For iCont = Colunas.GetLowerBound(0) To Colunas.GetUpperBound(0)
                    If IsNumeric(Colunas(iCont)) Then
                        If Where Is Nothing And Where_CheckColuna Is Nothing Then
                            bValido = True
                        Else
                            bValido = True

                            'Coluna de tipos variados
                            If Not Where Is Nothing Then
                                For iWhere = Where.GetLowerBound(0) To Where.GetUpperBound(0) Step 2
                                    If Not .Cells(Where(iWhere)).Value = Where(iWhere + 1) Then
                                        bValido = False
                                        Exit For
                                    End If
                                Next
                            End If
                            'Colunas do tipo check
                            If Not Where_CheckColuna Is Nothing Then
                                For iWhere = Where_CheckColuna.GetLowerBound(0) To Where_CheckColuna.GetUpperBound(0)
                                    If Not objGrid_CheckBox_Selecionado(oGrid, Where_CheckColuna(iWhere), iLinha) Then
                                        bValido = False
                                        Exit For
                                    End If
                                Next
                            End If
                        End If

                        If bValido Then
                            sAux = sAux & Trim(NVL(.Cells(Colunas(iCont)).Value, ""))
                        End If
                    Else
                        sAux = sAux & " " & Trim(Colunas(iCont)) & " "
                    End If
                Next
            End With

            If Trim(sAux) <> "" Then
                Str_Adicionar(sLista, Trim(sAux), Separador)
            End If
        Next

        Return sLista
    End Function

    Private Function objGrid_DataColunmKey(ByVal KeySugerido As String, ByRef oData As UltraWinDataSource.UltraDataBand) As String
        Dim iCont As Integer
        Dim sAux As String = ""
        Dim bAchou As Boolean = False

        For iCont = 0 To oData.Columns.Count - 1
            If UCase(oData.Columns(iCont).Key) = UCase(KeySugerido) Then
                bAchou = True
                Exit For
            End If
        Next

        If bAchou Or Trim(KeySugerido) = "" Then
            sAux = oData.Columns.Count + 1
        Else
            sAux = KeySugerido
        End If

        Return sAux
    End Function

    Public Function objGrid_Grupo_Criar(ByVal oBand As UltraGridBand, _
                                        Optional ByVal Titulo As String = "") As UltraGridGroup
        Dim oGrupo As UltraGridGroup

        oGrupo = oBand.Groups.Add

        If Trim(Titulo) <> "" Then
            oGrupo.Header.Caption = Titulo
        End If
        With oGrupo.Header.Appearance
            .BackColor = System.Drawing.Color.FromArgb(CType(70, Byte), CType(143, Byte), CType(161, Byte))
            .ForeColor = Color.White
            .BackGradientStyle = GradientStyle.VerticalBump
            .BackColor2 = System.Drawing.Color.FromArgb(CType(29, Byte), CType(99, Byte), CType(125, Byte))
            .BorderColor = Color.White
            .BorderColor2 = Color.White
            .BorderColor3DBase = Color.White
            .BorderAlpha = Alpha.Opaque
        End With

        Return oGrupo
    End Function

    Public Sub objGrid_Imprimir(ByVal oGrid As UltraGrid, Optional ByVal Titulo As String = "")
        Dim oPrintPreviewDialog As New Infragistics.Win.Printing.UltraPrintPreviewDialog
        Dim oGridPrint As New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
        Dim TamanhoGrid As Integer
        Dim iCont As Integer

        For iCont = 0 To oGrid.DisplayLayout.Bands(0).Columns.Count - 1
            TamanhoGrid = TamanhoGrid + oGrid.DisplayLayout.Bands(0).Columns(iCont).Width
        Next


        With oGridPrint
            .Grid = oGrid
            .DefaultPageSettings.Landscape = True
            .DefaultPageSettings.Margins.Left = 30
            .DefaultPageSettings.Margins.Right = 30
            .DefaultPageSettings.Margins.Top = 30
            .DefaultPageSettings.Margins.Bottom = 30


            If Titulo <> "" Then
                .Header.TextCenter = Titulo
                .Header.Height = 40
                .Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Header.Appearance.FontData.SizeInPoints = 20
                oGridPrint.FitWidthToPages = Math.Ceiling(TamanhoGrid / 1200)
            End If
        End With

        With oPrintPreviewDialog
            .Document = oGridPrint
            .ShowDialog()
            ' .Dispose()
        End With

        ' oPrintPreviewDialog = Nothing
    End Sub

    Private Sub objGrid_PopUp_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        Select Case e.ClickedItem.Name
            Case cnt_Grid_PopUp_ItemClicked_ExportarExcell
                If Not e.ClickedItem.Tag Is Nothing Then
                    objGrid_ExportarExcell(e.ClickedItem.Tag, Form_ParentForm(e.ClickedItem.Tag).Text)
                End If
        End Select
    End Sub
End Module