Imports Infragistics.Win
Imports Infragistics.Win.FormattedLinkLabel
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinSpellChecker

Public Class Editor
    Private prePreviewStyle As String
    Private lastCheckedText As String

    Dim bProcInterno As Boolean
    Dim sFonte_01 As String = "Calibri11"
    Dim sFonte_02 As String = "Arial"

    Private Sub Formatacao_Reiniciar()
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim iIndice As Integer
        Dim sFonte As String

        For iCont_02 = 0 To 1
            Try
                If iCont_02 = 0 Then
                    sFonte = sFonte_01
                Else
                    sFonte = sFonte_02
                End If

                iIndice = CType(tbmFerramenta.Tools("Fontname"), FontListTool).SelectedIndex
                iCont_01 = 0

                Do While True
                    CType(tbmFerramenta.Tools("Fontname"), FontListTool).SelectedIndex = iCont_01

                    If UCase(Trim(CType(tbmFerramenta.Tools("Fontname"), FontListTool).Text)) = UCase(Trim(sFonte)) Then
                        CType(Me.tbmFerramenta.Tools("FontName"), FontListTool).SelectedIndex = iCont_01
                        tbmFerramenta_Formatar(Me.tbmFerramenta.Tools("FontName"))
                        Exit For
                    End If

                    iCont_01 = iCont_01 + 1
                Loop
            Catch ex As Exception
                CType(tbmFerramenta.Tools("Fontname"), FontListTool).SelectedIndex = iIndice
            End Try
        Next

        CType(Me.tbmFerramenta.Tools("FontSize"), ComboBoxTool).SelectedIndex = 1
        CType(Me.tbmFerramenta.Tools("Left"), StateButtonTool).Checked = True
        CType(Me.tbmFerramenta.Tools("Bold"), StateButtonTool).Checked = False
        CType(Me.tbmFerramenta.Tools("Italic"), StateButtonTool).Checked = False
        CType(Me.tbmFerramenta.Tools("Underline"), StateButtonTool).Checked = False

        tbmFerramenta_Formatar(Me.tbmFerramenta.Tools("FontSize"))
        tbmFerramenta_Formatar(Me.tbmFerramenta.Tools("Left"))
        tbmFerramenta_Formatar(Me.tbmFerramenta.Tools("Bold"))
        tbmFerramenta_Formatar(Me.tbmFerramenta.Tools("Italic"))
        tbmFerramenta_Formatar(Me.tbmFerramenta.Tools("Underline"))
    End Sub

    Public Sub Initialize()
        Try
            Me.tbmFerramenta.EventManager.AllEventsEnabled = False

            Me.tbmFerramenta.Ribbon.Tabs("TextTools").Visible = False
            Me.tbmFerramenta.Ribbon.Tabs("Spelling").Visible = False

            Me.Formatacao_Reiniciar()

            Me.tbmFerramenta.EventManager.AllEventsEnabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Function GetCurrentWordStartPosition() As Integer
        Dim cursorPosition As Integer = Me.txtEditor.EditInfo.SelectionStart
        Dim i As Integer

        If cursorPosition = 0 Then
            Return 0
        End If

        For i = cursorPosition - 1 To 0 Step -1
            If Not [Char].IsLetter(Me.lastCheckedText.Chars(i)) Then
                Return i + 1
            End If
        Next i

        Return 0
    End Function

    Private Function IsPresetStyle(ByVal si As StyleInfo, ByRef match As String) As Boolean
        Dim presetGallery As PopupGalleryTool = CType(Me.tbmFerramenta.Tools("PresetsGallery"), PopupGalleryTool)
        Dim styleAttributes As String = si.ToString().ToLower().Replace(" ", [String].Empty)
        Dim item As GalleryToolItem

        For Each item In presetGallery.Items
            Dim itemAttributes As String = item.Tag.ToString().ToLower().Replace(" ", [String].Empty)
            If [String].Equals(itemAttributes, styleAttributes) Then
                match = item.Key
                Return True
            End If
        Next item

        match = [String].Empty

        Return False
    End Function

    Private Sub Fonte_CorLetra_Aplicar()
        Dim fontColor As Color = CType(tbmFerramenta.Tools("FontColor"), PopupColorPickerTool).SelectedColor
        Dim hexColor As String = System.Drawing.ColorTranslator.ToHtml(fontColor)

        txtEditor.EditInfo.ApplyStyle("Color: " + hexColor, False)
        txtEditor.EditInfo.ApplyStyle("Border-color: " + hexColor, False)
    End Sub

    Private Sub tbmFerramenta_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles tbmFerramenta.ToolClick
        Select Case e.Tool.Key
            Case "Bold"
                txtEditor.EditInfo.PerformAction(FormattedLinkEditorAction.ToggleBold)
            Case "Italic"
                txtEditor.EditInfo.PerformAction(FormattedLinkEditorAction.ToggleItalics)
            Case "Underline"
                txtEditor.EditInfo.PerformAction(FormattedLinkEditorAction.ToggleUnderline)
            Case "Left", "Center", "Right", "Justify"
                txtEditor.EditInfo.ApplyStyle("Text-align: " + e.Tool.Key, True)
            Case "FontHighlight"
                Dim highlightTool As PopupColorPickerTool = CType(e.Tool, PopupColorPickerTool)
                Dim highlightColor As Color = Color.White

                If highlightTool.Checked Then
                    highlightColor = highlightTool.SelectedColor
                Else
                    Dim editorBackColor As Color = txtEditor.Appearance.BackColor
                    If Not editorBackColor.IsEmpty Then
                        highlightColor = txtEditor.Appearance.BackColor
                    End If
                End If
                Dim hexHighlightColor As String = System.Drawing.ColorTranslator.ToHtml(highlightColor)
                txtEditor.EditInfo.ApplyStyle("Background-color: " + hexHighlightColor, False)
            Case "FontColor"
                Fonte_CorLetra_Aplicar()
            Case "Reset"
                Formatacao_Reiniciar()
            Case "Imagem"
                txtEditor.EditInfo.ShowImageDialog()
        End Select
    End Sub

    Private Sub txtEditor_EditStateChanged(ByVal sender As Object, ByVal e As Infragistics.Win.FormattedLinkLabel.EditStateChangedEventArgs) Handles txtEditor.EditStateChanged
        Dim si As StyleInfo = txtEditor.EditInfo.GetCurrentStyle()
        Dim iCont As Integer
        Dim iAux As String
        Dim sAux As String

        tbmFerramenta.EventManager.SetEnabled(ToolbarEventIds.ToolClick, False)

        CType(tbmFerramenta.Tools("Bold"), StateButtonTool).Checked = IIf(si.Appearance.FontData.Bold = DefaultableBoolean.True, True, False)
        CType(tbmFerramenta.Tools("Italic"), StateButtonTool).Checked = IIf(si.Appearance.FontData.Italic = DefaultableBoolean.True, True, False)
        CType(tbmFerramenta.Tools("Underline"), StateButtonTool).Checked = IIf(si.Appearance.FontData.Underline = DefaultableBoolean.True, True, False)
        CType(tbmFerramenta.Tools("Left"), StateButtonTool).Checked = si.LineAlignment = LineAlignment.Left Or si.LineAlignment = LineAlignment.Default
        CType(tbmFerramenta.Tools("Center"), StateButtonTool).Checked = si.LineAlignment = LineAlignment.Center
        CType(tbmFerramenta.Tools("Right"), StateButtonTool).Checked = si.LineAlignment = LineAlignment.Right
        CType(tbmFerramenta.Tools("Justify"), StateButtonTool).Checked = si.LineAlignment = LineAlignment.Justify

        Dim isTextSelected As Boolean = txtEditor.EditInfo.Editor.SelectedText.Length > 0

        tbmFerramenta.Ribbon.Tabs("TextTools").Visible = isTextSelected

        Dim cElement As CaretUIElement = txtEditor.UIElement.GetDescendant(GetType(CaretUIElement))

        If Not (cElement Is Nothing) Then
            Dim spellError As [Error] = UltraSpellChecker1.GetErrorAtPoint(txtEditor, cElement.Rect.Location)
            If Not (spellError Is Nothing) Then
                tbmFerramenta.Tools("AutoCorrect").SharedProps.Caption = [String].Format("AutoCorrect '{0}'", spellError.CheckedWord)
                tbmFerramenta.Tools("AutoCorrect").SharedProps.Enabled = spellError.Suggestions.Count > 0
                tbmFerramenta.Ribbon.Tabs("Spelling").Visible = True
            Else
                tbmFerramenta.Ribbon.Tabs("Spelling").Visible = False
            End If
        End If

        Dim gallery As PopupGalleryTool = CType(tbmFerramenta.Tools("PresetsGallery"), PopupGalleryTool)
        Dim presetGroupKey As String = ""

        If IsPresetStyle(si, presetGroupKey) Then
            gallery.SelectedItemKey = presetGroupKey
        Else
            gallery.SelectedItem = Nothing
        End If

        tbmFerramenta.EventManager.SetEnabled(ToolbarEventIds.ToolClick, True)

        'Setar font
        If Not bProcInterno Then
            bProcInterno = True

            iCont = Len("font-family:")
            sAux = txtEditor.EditInfo.GetCurrentStyle.ToString

            If Trim(sAux) <> "" Then
                If InStr(sAux, ";") - iCont - 1 > 0 Then
                    sAux = Mid(sAux, iCont + 1, InStr(sAux, ";") - iCont - 1)
                End If

                iCont = 0
                iAux = CType(tbmFerramenta.Tools("Fontname"), FontListTool).SelectedIndex

                Try
                    Do While True
                        CType(tbmFerramenta.Tools("Fontname"), FontListTool).SelectedIndex = iCont

                        If UCase(Trim(CType(tbmFerramenta.Tools("Fontname"), FontListTool).Text)) = UCase(Trim(sAux)) Then
                            Exit Do
                        End If

                        iCont = iCont + 1
                    Loop
                Catch ex As Exception
                    CType(tbmFerramenta.Tools("Fontname"), FontListTool).SelectedIndex = iAux
                End Try
            End If

            sAux = txtEditor.EditInfo.GetCurrentStyle.ToString

            If Trim(sAux) <> "" And InStr(sAux, "font-size") > 0 Then
                sAux = Mid(sAux, InStr(sAux, "font-size"))
                sAux = Mid(sAux, InStr(sAux, ":") + 1)
                sAux = Mid(sAux, 1, Len(sAux) - 1)

                CType(tbmFerramenta.Tools("FontSize"), ComboBoxTool).Text = sAux
            End If

            bProcInterno = False
        End If
    End Sub

    Private Sub tbmFerramenta_ToolValueChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolEventArgs) Handles tbmFerramenta.ToolValueChanged
        tbmFerramenta_Formatar(e.Tool)
    End Sub

    Private Sub tbmFerramenta_Formatar(ByVal oTool As Infragistics.Win.UltraWinToolbars.ToolBase)
        If bProcInterno Then Exit Sub

        bProcInterno = True

        Select Case oTool.Key
            Case "FontName"
                Dim fontName As String = CType(oTool, FontListTool).Text

                txtEditor.EditInfo.ApplyStyle("Font-family: " + fontName, False)
            Case "FontColor"
                Fonte_CorLetra_Aplicar()
            Case "FontSize"
                Dim selectedSize As String = CType(oTool, ComboBoxTool).Value.ToString()
                txtEditor.EditInfo.ApplyStyle("Font-size: " + selectedSize, False)
        End Select

        txtEditor.Focus()

        bProcInterno = False
    End Sub

    Private Sub tbmFerramenta_GalleryToolItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.GalleryToolItemEventArgs) Handles tbmFerramenta.GalleryToolItemClick
        If e.GalleryTool.Key = "PresetsGallery" Then
            txtEditor.EditInfo.ClearAllStyleAttributes()

            Dim style As String = e.Item.Tag.ToString()

            txtEditor.EditInfo.ApplyStyle(style, False)

            If prePreviewStyle Is e.Item.Tag.ToString() Then
                prePreviewStyle = Nothing
            End If

            Dim manager As UltraToolbarsManager = sender

            manager.EventManager.SetEnabled(ToolbarEventIds.ToolClick, False)
            manager.EventManager.SetEnabled(ToolbarEventIds.ToolValueChanged, False)

            Dim styleAttributes As String() = style.Split(";"c)
            Dim attribute As String

            For Each attribute In styleAttributes
                Dim propertyInfo As String() = attribute.Split(":"c)

                Select Case propertyInfo(0).Trim().ToLower()
                    Case "font-size"
                        CType(manager.Tools("FontSize"), ComboBoxTool).Text = propertyInfo(1)
                    Case "font-family"
                        CType(manager.Tools("FontName"), FontListTool).Text = propertyInfo(1)
                End Select
            Next attribute

            manager.EventManager.SetEnabled(ToolbarEventIds.ToolClick, True)
            manager.EventManager.SetEnabled(ToolbarEventIds.ToolValueChanged, True)
        End If
    End Sub

    Private Sub tbmFerramenta_GalleryToolActiveItemChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.GalleryToolItemEventArgs) Handles tbmFerramenta.GalleryToolActiveItemChange
        Dim applyToBlocks As Boolean = txtEditor.EditInfo.SelectionLength = 0

        If e.Item Is Nothing Then
            If Not (prePreviewStyle Is Nothing) Then
                txtEditor.EditInfo.ClearStyleAttributes(txtEditor.EditInfo.GetCurrentStyle().GetSetAttributes(), applyToBlocks)
                txtEditor.EditInfo.ApplyStyle(prePreviewStyle, applyToBlocks)
                prePreviewStyle = Nothing
            End If
        Else
            If prePreviewStyle Is Nothing Then
                prePreviewStyle = txtEditor.EditInfo.GetCurrentStyle().ToString()
            End If
            txtEditor.EditInfo.ApplyStyle(e.Item.Tag.ToString(), applyToBlocks)
        End If
    End Sub

    Public Property Texto() As String
        Get
            Return txtEditor.Text
        End Get
        Set(ByVal Valor As String)
            txtEditor.Text = Valor
        End Set
    End Property

    Public Sub Texto_Adicionar(ByVal sTexto As String, ByVal Formatado As Boolean)
        If Formatado Then
            txtEditor.EditInfo.Editor.Value = txtEditor.EditInfo.Editor.Value & sTexto
        Else
            txtEditor.Text = txtEditor.Text & sTexto
        End If
    End Sub

    Public Property Texto_Selecao() As String
        Get
            Return txtEditor.EditInfo.Editor.SelectedText
        End Get
        Set(ByVal Valor As String)
            txtEditor.EditInfo.Editor.SelectedText = Valor
        End Set
    End Property

    Public Sub Texto_Selecionar(ByVal Inicio As Integer, ByVal Tamanho As Integer)
        txtEditor.EditInfo.Editor.SelectionStart = Inicio
        txtEditor.EditInfo.SelectionLength = Tamanho
    End Sub

    Public Property Texto_Selecao_Inicio() As Integer
        Get
            Return txtEditor.EditInfo.Editor.SelectionStart
        End Get
        Set(ByVal Valor As Integer)
            txtEditor.EditInfo.SelectionStart = Valor
        End Set
    End Property

    Public Property Texto_Selecao_Tamanho() As Integer
        Get
            Return txtEditor.EditInfo.Editor.SelectionLength
        End Get
        Set(ByVal Valor As Integer)
            txtEditor.EditInfo.SelectionLength = Valor
        End Set
    End Property

    Public Property Texto_HTML(Optional ByVal EnviarEmail As Boolean = False) As String
        Get
            If Microsoft.VisualBasic.Left(txtEditor.EditInfo.Editor.Value, Len("&lt;TABLE width=650&gt;&l")) <> "&lt;TABLE width=650&gt;&l" _
               And EnviarEmail Then
                Return "<TABLE width=650><TR><TD>" & txtEditor.EditInfo.Editor.Value & "</TD></TR></TABLE>"
            Else
                Return txtEditor.EditInfo.Editor.Value
            End If
        End Get
        Set(ByVal Valor As String)
            txtEditor.EditInfo.Editor.Value = Valor
        End Set
    End Property

    Public Property Leitura() As Boolean
        Get
            Return txtEditor.ReadOnly
        End Get
        Set(ByVal Valor As Boolean)
            txtEditor.ReadOnly = Valor
            tbmFerramenta.Enabled = (Not Valor)
        End Set
    End Property

    Private Sub Editor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Initialize()
        Try
            txtEditor.EditInfo.ApplyStyle("Font-family: " + CType(tbmFerramenta.Tools("Fontname"), ComboBoxTool).Text, False)
            txtEditor.EditInfo.ApplyStyle("Font-size: " + CType(tbmFerramenta.Tools("FontSize"), ComboBoxTool).Text, False)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtEditor_StyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEditor.StyleChanged
        Me.Tag = Me.Tag
    End Sub
End Class